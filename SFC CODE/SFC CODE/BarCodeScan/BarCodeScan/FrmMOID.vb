Imports MainFrame

Public Class FrmMOID
    Public mo, Line, MoQt, Part As String
    Private Sub FrmMOID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlStr As String = "select  DISTINCT b.ButtonID from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " &
       " inner JOIN deptline_t c ON c.lineid=b.ButtonID where b.tparent in('z09_','z0s_','z0t_','z0Y_') and a.userid='" + VbCommClass.VbCommClass.UseId + "' AND c.factoryid = '" + VbCommClass.VbCommClass.PCompany + "'"
        Dim dt2 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        Me.CobLine.Items.Clear()
        For cnt As Integer = 0 To dt2.Rows.Count - 1
            CobLine.Items.Add(dt2.Rows(cnt)(0).ToString)
        Next
    End Sub

    Private Sub CobLine_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CobLine.SelectionChangeCommitted
        Dim SQL As String = "SELECT Moid,PartID,Moqty,Remark FROM dbo.m_Mainmo_t WHERE FinalY='N' AND Factory = '" + VbCommClass.VbCommClass.Factory + "' AND Lineid = '" + CobLine.Text.Trim() + "'ORDER BY Createtime DESC"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        dgvQuery.DataSource = dt
    End Sub

    Private Sub dgvQuery_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellClick
        Try
            Dim index As Int16 = dgvQuery.CurrentRow.Index
            txtSupplierCode.Text = dgvQuery.Rows(index).Cells("MOId").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtSupplierCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplierCode.KeyDown
        If e.KeyValue <> 13 Then
            Return
        Else
            Query()
        End If

    End Sub
    Private Sub Query()
        Dim SQL As String = "SELECT Moid,PartID,Moqty,Remark,Lineid  FROM dbo.m_Mainmo_t(NOLOCK) WHERE FinalY='N' AND Moid LIKE '%" + txtSupplierCode.Text.Trim() + "%' AND Factory = '" + VbCommClass.VbCommClass.Factory + "' AND Lineid = '" + CobLine.Text.Trim() + "'ORDER BY Createtime DESC"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        dgvQuery.DataSource = dt
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Query()
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            Dim index As Int16 = dgvQuery.CurrentRow.Index
            mo = dgvQuery.Rows(index).Cells("MOId").Value
            Line = CobLine.Text.Trim()
            MoQt = dgvQuery.Rows(index).Cells("MoQty").Value
            Part = dgvQuery.Rows(index).Cells("PartId").Value
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            Dim index As Int16 = dgvQuery.CurrentRow.Index
            mo = dgvQuery.Rows(index).Cells("MOId").Value
            Line = CobLine.Text.Trim()
            MoQt = dgvQuery.Rows(index).Cells("MoQty").Value
            Part = dgvQuery.Rows(index).Cells("PartId").Value
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class