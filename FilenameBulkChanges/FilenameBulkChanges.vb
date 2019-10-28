Public Class FilenameBulkChanges

    Public Structure FBCList_Str
        Dim SrcFileName As String
        Dim DstFileName As String
    End Structure
    Public DatFBCList() As FBCList_Str
    Public DatFBCPathNm As String
    Public DatTempName As String

    'フォルダ選択
    '[Select]実行
    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Call BtnSelect_Exec(DatFBCList)
    End Sub
    Public Sub BtnSelect_Exec(ByRef WrkFBCList() As FBCList_Str)

        'フォルダ選択
        If BtnSelect_Core() = True Then
            'フォルダが選択された場合

            '[BtnReacquire]実行
            Call BtnReacquire_Exec(WrkFBCList)

        End If
    End Sub
    Public Function BtnSelect_Core() As Boolean

        Dim WrkFBD As New FolderBrowserDialog
        With WrkFBD

            .RootFolder = Environment.SpecialFolder.Desktop 'ルートフォルダ
            .SelectedPath = FolderNameCheck(FolderPathName.Text) '初期フォルダ
            .ShowNewFolderButton = False '新しいフォルダの作成

            'ダイアログ表示
            If .ShowDialog(Me) = DialogResult.OK Then

                FolderPathName.Text = .SelectedPath

                Return True

            End If

        End With

        Return False
    End Function

    'フォルダ名をきれいにする
    Public Function FolderNameCheck(ByVal WrkStr As String) As String

        If Strings.Left(WrkStr, 1) = """" And Strings.Right(WrkStr, 1) = """" Then
            '前後に["]が付いている場合

            '前後の["]を除ける
            WrkStr = Microsoft.VisualBasic.Strings.Mid(WrkStr, 2, WrkStr.Length - 2)

        End If

        If Strings.Right(WrkStr, 1) = "\" Then
            '文字列の最後が[\]の場合

            '[\]を除ける
            WrkStr = Microsoft.VisualBasic.Strings.Left(WrkStr, WrkStr.Length - 1)

        End If

        Return WrkStr
    End Function

    'ファイル名を検索
    '[BtnReacquire]実行
    Private Sub BtnReacquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReacquire.Click
        Call BtnReacquire_Exec(DatFBCList)
    End Sub
    Public Sub BtnReacquire_Exec(ByRef WrkFBCList() As FBCList_Str)

        'ファイル名を検索
        Call BtnReacquire_Core(WrkFBCList)

        '[BtnRenum]実行
        Call BtnRenum_Exec(WrkFBCList)

    End Sub
    Public Sub BtnReacquire_Core(ByRef WrkFBCList() As FBCList_Str)

        DatFBCPathNm = FolderNameCheck(FolderPathName.Text)
        DatTempName = TxtTempName.Text

        On Error Resume Next
        Dim WrkFileList As String() = System.IO.Directory.GetFiles(DatFBCPathNm)
        On Error GoTo 0

        Erase WrkFBCList

        If Not WrkFileList Is Nothing Then

            'ファイル名部分のみに変換
            For Each WrkStr As String In WrkFileList

                If WrkFBCList Is Nothing Then
                    ReDim WrkFBCList(0)
                Else
                    ReDim Preserve WrkFBCList(WrkFBCList.Count)
                End If

                WrkFBCList(WrkFBCList.Count - 1).SrcFileName = System.IO.Path.GetFileName(WrkStr)

            Next
        End If

    End Sub

    '新ファイル名生成
    '[BtnRenum]実行
    Private Sub BtnRenum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRenum.Click
        Call BtnRenum_Exec(DatFBCList)
    End Sub
    Public Sub BtnRenum_Exec(ByRef WrkFBCList() As FBCList_Str)

        '新ファイル名生成
        Call BtnRenum_Core(WrkFBCList)

        'リスト再表示
        Call ListView(WrkFBCList)

    End Sub
    Public Sub BtnRenum_Core(ByRef WrkFBCList() As FBCList_Str)

        Dim StartNo As Integer
        StartNo = CInt(TxtStartNo.Text)

        If Not WrkFBCList Is Nothing Then

            For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

                WrkFBCList(WrkIdx).DstFileName = StartNo.ToString(TxtFormat.Text)

                StartNo = StartNo + CInt(TxtStepNo.Text)
            Next

        End If

    End Sub

    'リスト再表示
    Public Sub ListView(ByVal WrkFBCList() As FBCList_Str)

        FilenameList.Items.Clear()

        If Not WrkFBCList Is Nothing Then

            For WrkIdx As Integer = 0 To WrkFBCList.Count - 1
                FilenameList.Items.Add(WrkFBCList(WrkIdx).SrcFileName & " → " & WrkFBCList(WrkIdx).DstFileName)
            Next

        End If

    End Sub

    '[Go]実行
    Private Sub BtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGo.Click
        Call BtnGo_Exec(DatFBCList, DatFBCPathNm, DatTempName)
    End Sub
    Public Sub BtnGo_Exec(ByVal WrkFBCList() As FBCList_Str, ByVal WrkFBCPathNm As String, ByVal WrkTempName As String)

        If WrkFBCList Is Nothing Then
            Call MessageBox.Show("対象データがありません。" & vbCrLf & "There is no target data.", "確認 Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("ファイル名を変更します。" & vbCrLf & "Change the file name.", "確認 Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Exit Sub
        End If

        Dim ErrMsg As String = ""

        If BtnGo_Core(WrkFBCList, WrkFBCPathNm, WrkTempName, ErrMsg) = True Then
            Call MessageBox.Show("完了しました" & vbCrLf & "Completed.", "完了 Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("完了しましたが、エラーが発生しています。" & vbCrLf & "Completed with errors." & vbCrLf & vbCrLf _
                               & "エラー内容をクリップボードに保存しますか？" & vbCrLf & "Do you want to save the error contents to the clipboard?" _
                               , "完了 Complete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then

                Do

                    'エラー内容をクリップボードに保存
                    Clipboard.SetText(ErrMsg)

                Loop While Windows.Forms.DialogResult.No = MessageBox.Show( _
                            "クリップボードに保存しました。" & vbCrLf & _
                            "Saved to clipboard." & vbCrLf & _
                            vbCrLf & _
                            "[いいえ]で再度保存を行います。" & vbCrLf & _
                            "Save again with [No]." & vbCrLf & _
                            "", "保存しました Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If
        End If

    End Sub
    Public Function BtnGo_Core(ByVal WrkFBCList() As FBCList_Str, ByVal WrkFBCPathNm As String, ByVal WrkTempName As String, ByRef ErrMsg As String) As Boolean

        Dim RetCode As Boolean = True

        For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

            '一時ファイル名にファイル名変更
            If BtnGo_Core_ReNM(WrkFBCPathNm & "\" & WrkFBCList(WrkIdx).SrcFileName _
                             , WrkFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName & WrkTempName _
                             , ErrMsg) = False Then
                RetCode = False
            End If

        Next

        If WrkTempName = "" Then
            '一時ファイル名が指定されていない場合

            'そのまま終了
            Return RetCode
        End If

        '一時ファイル名から正規ファイル名に変更
        For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

            If BtnGo_Core_ReNM(WrkFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName & WrkTempName _
                             , WrkFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName _
                             , ErrMsg) = False Then
                RetCode = False
            End If

        Next

        Return RetCode
    End Function
    Public Function BtnGo_Core_ReNM(ByVal WrkSrcFile As String, ByVal WrkDstFile As String, ByRef ErrMsg As String) As Boolean

        Dim RetCode As Boolean = True

        Try

            'ファイル名の変更
            System.IO.File.Move(WrkSrcFile, WrkDstFile)

        Catch ex As Exception
            ErrMsg = ErrMsg & WrkSrcFile & vbTab & "→" & vbTab & WrkDstFile & vbTab & ex.Message & vbCrLf
            RetCode = False
        End Try

        Return RetCode
    End Function

End Class
