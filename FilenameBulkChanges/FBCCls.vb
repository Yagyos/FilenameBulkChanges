
Public Class FBCCls

    Private DatFBCPathNm As String '対象フォルダ
    Private DatTempName As String '一時ファイル名

    Public Sub BtnReacquire_Core(ByRef WrkFBCList() As FBCList.FBC_Structure, ByVal WrkFBCPathNm As String, ByVal WrkTempName As String)

        DatFBCPathNm = WrkFBCPathNm '対象フォルダを保持
        DatTempName = WrkTempName '一時ファイル名を保持

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

    '変更後ファイル名を設定
    Public Sub BtnRenum_Core(ByRef WrkFBCList() As FBCList.FBC_Structure, ByVal WrkFormat As String, ByVal WrkStartNo As Integer, ByVal WrkStepNo As Integer, ByVal IsReverse As Boolean)

        Dim StartNo As Integer
        StartNo = CInt(WrkStartNo)

        If Not WrkFBCList Is Nothing Then

            For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

                If IsReverse = False Then
                    '正順
                    WrkFBCList(WrkIdx).DstFileName = StartNo.ToString(WrkFormat)
                Else
                    '逆順
                    WrkFBCList(WrkFBCList.Count - 1 - WrkIdx).DstFileName = StartNo.ToString(WrkFormat)
                End If

                StartNo = StartNo + CInt(WrkStepNo)
            Next

        End If

    End Sub

    '一括でファイル名変更を実行
    Public Function BtnGo_Core(ByVal WrkFBCList() As FBCList.FBC_Structure, ByRef ErrMsg As String) As Boolean

        Dim RetCode As Boolean = True

        For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

            '一時ファイル名にファイル名変更
            If BtnGo_Core_ReNM(DatFBCPathNm & "\" & WrkFBCList(WrkIdx).SrcFileName _
                             , DatFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName & DatTempName _
                             , ErrMsg) = False Then
                RetCode = False
            End If

        Next

        If DatTempName = "" Then
            '一時ファイル名が指定されていない場合

            'そのまま終了
            Return RetCode
        End If

        '一時ファイル名から正規ファイル名に変更
        For WrkIdx As Integer = 0 To WrkFBCList.Count - 1

            If BtnGo_Core_ReNM(DatFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName & DatTempName _
                             , DatFBCPathNm & "\" & WrkFBCList(WrkIdx).DstFileName _
                             , ErrMsg) = False Then
                RetCode = False
            End If

        Next

        Return RetCode
    End Function

    '一件だけファイル名変更を実行
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
