Imports MainFrame.SysDataHandle

Public Class FormChecklarge
    Dim sqlConn As New SysDataBaseClass
    Public code As String
    Private Sub panel2_Paint(sender As Object, e As PaintEventArgs) Handles panel2.Paint


    End Sub

    Private Sub editValue_KeyDown(sender As Object, e As KeyEventArgs) Handles editValue.KeyDown
        If e.KeyValue = 13 Then
            If combField.Text.Trim() = "测试大项代码" Then
                Dim sql As String = "SELECT ITEM_TYPE_CODE,ITEM_TYPE_NAME,ITEM_TYPE_DESC,USID,[Time] FROM m_QCTestprojectowner_t where ITEM_TYPE_CODE like N'%" & editValue.Text.Trim() & "%' and  Effective ='Y'"
                Dim data As DataTable = sqlConn.GetDataTable(sql)
                dgvData.DataSource = data
            Else
                Dim sql As String = "SELECT top 100 ITEM_TYPE_CODE,ITEM_TYPE_NAME,ITEM_TYPE_DESC,USID,[Time] FROM m_QCTestprojectowner_t where ITEM_TYPE_NAME like N'%" & editValue.Text.Trim() & "%' and  Effective ='Y'"
                Dim data As DataTable = sqlConn.GetDataTable(sql)
                dgvData.DataSource = data
            End If
        End If
    End Sub


    Private Sub FormChecklarge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combField.Text = "测试大项代码"
        Dim sql As String = "SELECT top 100 ITEM_TYPE_CODE,ITEM_TYPE_NAME,ITEM_TYPE_DESC,USID,[Time] FROM m_QCTestprojectowner_t WHERE Effective ='Y'"
        Dim data As DataTable = sqlConn.GetDataTable(sql)
        dgvData.DataSource = data
    End Sub

    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If dgvData.Rows.Count > 0 AndAlso dgvData.CurrentRow IsNot Nothing Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.No
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub dgvData_CellDoubleClick(sender As Object, e As EventArgs)

    End Sub
End Class