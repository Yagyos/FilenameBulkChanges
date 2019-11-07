Public Class FilenameBulkChanges

    Private DatFBC As New FBCCls
    Private DatFBCList As New FBCList

    'フォルダ選択
    '[Select]実行
    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Call BtnSelect_Exec()
    End Sub
    Public Sub BtnSelect_Exec()

        'フォルダ選択
        If SelectFolder.BtnSelect_Core(Me, FolderPathName.Text) = True Then
            'フォルダが選択された場合

            '[BtnReacquire]実行
            Call BtnReacquire_Exec()

        End If
    End Sub

    'ファイル名を検索
    '[BtnReacquire]実行
    Private Sub BtnReacquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReacquire.Click
        Call BtnReacquire_Exec()
    End Sub
    Public Sub BtnReacquire_Exec()

        'ファイル名を検索
        Call DatFBC.BtnReacquire_Core(DatFBCList.DataList, SelectFolder.FolderNameCheck(FolderPathName.Text), TxtTempName.Text)

        '[BtnRenum]実行
        Call BtnRenum_Exec()

    End Sub

    '新ファイル名生成
    '[BtnRenum]実行
    Private Sub BtnRenum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRenum.Click
        Call BtnRenum_Exec()
    End Sub
    Public Sub BtnRenum_Exec()

        '新ファイル名生成
        Call DatFBC.BtnRenum_Core(DatFBCList.DataList, TxtFormat.Text, CInt(TxtStartNo.Text), CInt(TxtStepNo.Text), ChkReverse.Checked)

        'リスト再表示
        Call ListView(DatFBCList.DataList)

    End Sub

    'リスト再表示
    Public Sub ListView(ByVal WrkFBCList() As FBCList.FBC_Structure)

        FilenameList.Items.Clear()

        If Not WrkFBCList Is Nothing Then

            For WrkIdx As Integer = 0 To WrkFBCList.Count - 1
                FilenameList.Items.Add(WrkFBCList(WrkIdx).SrcFileName & " → " & WrkFBCList(WrkIdx).DstFileName)
            Next

        End If

    End Sub

    '[Go]実行
    Private Sub BtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGo.Click
        Call BtnGo_Exec()
    End Sub
    Public Sub BtnGo_Exec()

        If DatFBCList.DataList Is Nothing Then
            Call MessageBox.Show("対象データがありません。" & vbCrLf & "There is no target data.", "確認 Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("ファイル名を変更します。" & vbCrLf & "Change the file name.", "確認 Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Exit Sub
        End If

        Dim ErrMsg As String = ""

        If DatFBC.BtnGo_Core(DatFBCList.DataList, ErrMsg) = True Then
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

End Class
