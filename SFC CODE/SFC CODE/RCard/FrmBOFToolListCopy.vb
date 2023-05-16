Imports MainFrame.SysCheckData

Public Class FrmBOFToolListCopy
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub



    Private Sub FrmBOFToolListCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If String.IsNullOrEmpty(txtNewPartID.Text.Trim()) Then
                MessageUtils.ShowError("请输入新的料号!")
                Exit Sub
            ElseIf txtOldPartID.Text.Trim() = txtNewPartID.Text.Trim() Then
                MessageUtils.ShowError("新旧料号不能相同!")
                Exit Sub
            ElseIf String.IsNullOrEmpty(txtVersion.Text.Trim()) Then
                MessageUtils.ShowError("请输入版本!")
                Exit Sub
            End If
            Dim UserID = VbCommClass.VbCommClass.UseId
            Dim UserName = VbCommClass.VbCommClass.UseName
            Dim DocID = FrmAddBOFToolListMain.getFileNO()
            Dim sql = String.Format("exec BOFToolListCopy N'{0}',N'{1}','{2}','{3}',N'{4}','{5}'",
            txtOldPartID.Text.Trim(), txtNewPartID.Text.Trim(), txtVersion.Text.Trim(),
            UserID, UserName, DocID)
            MainFrame.DbOperateUtils.ExecSQL(sql)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("提交出错:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
End Class