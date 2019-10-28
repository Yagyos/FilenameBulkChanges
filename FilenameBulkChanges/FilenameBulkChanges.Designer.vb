<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilenameBulkChanges
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.FilenameList = New System.Windows.Forms.ListBox()
        Me.FolderPathName = New System.Windows.Forms.TextBox()
        Me.TxtFormat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStartNo = New System.Windows.Forms.TextBox()
        Me.BtnRenum = New System.Windows.Forms.Button()
        Me.BtnReacquire = New System.Windows.Forms.Button()
        Me.TxtStepNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnGo = New System.Windows.Forms.Button()
        Me.TxtTempName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnSelect
        '
        Me.BtnSelect.Location = New System.Drawing.Point(12, 12)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(66, 19)
        Me.BtnSelect.TabIndex = 3
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'FilenameList
        '
        Me.FilenameList.FormattingEnabled = True
        Me.FilenameList.HorizontalScrollbar = True
        Me.FilenameList.ItemHeight = 12
        Me.FilenameList.Location = New System.Drawing.Point(12, 42)
        Me.FilenameList.Name = "FilenameList"
        Me.FilenameList.Size = New System.Drawing.Size(196, 196)
        Me.FilenameList.TabIndex = 2
        '
        'FolderPathName
        '
        Me.FolderPathName.Location = New System.Drawing.Point(84, 12)
        Me.FolderPathName.Name = "FolderPathName"
        Me.FolderPathName.Size = New System.Drawing.Size(196, 19)
        Me.FolderPathName.TabIndex = 4
        '
        'TxtFormat
        '
        Me.TxtFormat.Location = New System.Drawing.Point(261, 42)
        Me.TxtFormat.Name = "TxtFormat"
        Me.TxtFormat.Size = New System.Drawing.Size(137, 19)
        Me.TxtFormat.TabIndex = 5
        Me.TxtFormat.Text = """Page""0000"".jpg"""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(214, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Format"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "StartNo"
        '
        'TxtStartNo
        '
        Me.TxtStartNo.Location = New System.Drawing.Point(261, 67)
        Me.TxtStartNo.Name = "TxtStartNo"
        Me.TxtStartNo.Size = New System.Drawing.Size(137, 19)
        Me.TxtStartNo.TabIndex = 8
        Me.TxtStartNo.Text = "1"
        '
        'BtnRenum
        '
        Me.BtnRenum.Location = New System.Drawing.Point(261, 117)
        Me.BtnRenum.Name = "BtnRenum"
        Me.BtnRenum.Size = New System.Drawing.Size(66, 19)
        Me.BtnRenum.TabIndex = 9
        Me.BtnRenum.Text = "Renum"
        Me.BtnRenum.UseVisualStyleBackColor = True
        '
        'BtnReacquire
        '
        Me.BtnReacquire.Location = New System.Drawing.Point(286, 12)
        Me.BtnReacquire.Name = "BtnReacquire"
        Me.BtnReacquire.Size = New System.Drawing.Size(66, 19)
        Me.BtnReacquire.TabIndex = 10
        Me.BtnReacquire.Text = "Reacquire"
        Me.BtnReacquire.UseVisualStyleBackColor = True
        '
        'TxtStepNo
        '
        Me.TxtStepNo.Location = New System.Drawing.Point(261, 92)
        Me.TxtStepNo.Name = "TxtStepNo"
        Me.TxtStepNo.Size = New System.Drawing.Size(137, 19)
        Me.TxtStepNo.TabIndex = 12
        Me.TxtStepNo.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "StepNo"
        '
        'BtnGo
        '
        Me.BtnGo.Location = New System.Drawing.Point(216, 191)
        Me.BtnGo.Name = "BtnGo"
        Me.BtnGo.Size = New System.Drawing.Size(182, 47)
        Me.BtnGo.TabIndex = 13
        Me.BtnGo.Text = "Go"
        Me.BtnGo.UseVisualStyleBackColor = True
        '
        'TxtTempName
        '
        Me.TxtTempName.Location = New System.Drawing.Point(261, 160)
        Me.TxtTempName.Name = "TxtTempName"
        Me.TxtTempName.Size = New System.Drawing.Size(137, 19)
        Me.TxtTempName.TabIndex = 15
        Me.TxtTempName.Text = "TMP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TempName"
        '
        'FilenameBulkChanges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 279)
        Me.Controls.Add(Me.TxtTempName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnGo)
        Me.Controls.Add(Me.TxtStepNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnReacquire)
        Me.Controls.Add(Me.BtnRenum)
        Me.Controls.Add(Me.TxtStartNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFormat)
        Me.Controls.Add(Me.FolderPathName)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.FilenameList)
        Me.Name = "FilenameBulkChanges"
        Me.Text = "FilenameBulkChanges"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
    Friend WithEvents FilenameList As System.Windows.Forms.ListBox
    Friend WithEvents FolderPathName As System.Windows.Forms.TextBox
    Friend WithEvents TxtFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStartNo As System.Windows.Forms.TextBox
    Friend WithEvents BtnRenum As System.Windows.Forms.Button
    Friend WithEvents BtnReacquire As System.Windows.Forms.Button
    Friend WithEvents TxtStepNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnGo As System.Windows.Forms.Button
    Friend WithEvents TxtTempName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
