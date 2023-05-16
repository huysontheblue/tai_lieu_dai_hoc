Imports MainFrame.SysDataHandle

Public Class FormCheckSmall
    Dim sqlConn As New SysDataBaseClass
    Public code As String
    Private Sub FormCheckSmall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combField.Text = "测试小项代码"
        Dim sql As String = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_Usid,ITEM_Small_Time FROM m_QCTestprojectownerson_t where ITEM_Small_Effective='Y' and ITEM_TYPE_ID='" & code & "'"
        Dim data As DataTable = sqlConn.GetDataTable(sql)
        dgvData.DataSource = data
    End Sub

    Private Sub editValue_KeyDown(sender As Object, e As KeyEventArgs) Handles editValue.KeyDown
        If e.KeyValue = 13 Then
            If combField.Text.Trim() = "测试小项代码" Then
                Dim sql As String = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_Usid,ITEM_Small_Time FROM m_QCTestprojectownerson_t where ITEM_Small_Code like '%" & editValue.Text.Trim() & "%' AND ITEM_Small_Effective='Y'"
                Dim data As DataTable = sqlConn.GetDataTable(sql)
                dgvData.DataSource = data
            Else
                Dim sql As String = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_Usid,ITEM_Small_Time FROM m_QCTestprojectownerson_t where ITEM_Small_Name like '%" & editValue.Text.Trim() & "%' AND ITEM_Small_Effective='Y'"
                Dim data As DataTable = sqlConn.GetDataTable(sql)
                dgvData.DataSource = data
            End If
        End If
    End Sub
    Private Sub dgvData_DoubleClick(sender As Object, e As EventArgs) Handles dgvData.DoubleClick, btnOK.Click
        If dgvData.Rows.Count > 0 AndAlso dgvData.CurrentRow IsNot Nothing Then
            DialogResult = DialogResult.OK
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.No
    End Sub
End Class