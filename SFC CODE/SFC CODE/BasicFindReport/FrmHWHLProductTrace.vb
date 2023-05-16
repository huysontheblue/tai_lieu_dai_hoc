Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmHWHLProductTrace

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        GetTestData()
    End Sub

    Private Sub DgData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgData.CellClick
        Dim strSQL As StringBuilder = New StringBuilder
        Try

            'Dim depId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colDept").Value.ToString
            'Dim line As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("ColLine").Value.ToString
            Dim ppid As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("ppid").Value.ToString
            'Dim partId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colPartId").Value.ToString
            strSQL.Append("exec dbo.P_HWHLSNQuery '" & ppid & "','2'")
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL.ToString)

            Me.DgDataDetail.DataSource = dt
            If Me.DgDataDetail.RowCount > 0 Then
                '   DgDataDetail.AutoResizeColumns()
            Else
                'UIFunction.SetMessage("查不到数据！", lblMsg, True, False)
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind", "DgData_CellClick", "FrmHWHLProductTrace")
        End Try
    End Sub

    Private Sub DgData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgData.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.DgData.RowCount > 0 Then

            Dim sPcbaSn As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("PPID").Value.ToString
            Dim sStationId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("Station").Value.ToString.Split("/")(0)

            Dim frmTestResultDetail As FrmHWHLTestResultDetail = New FrmHWHLTestResultDetail(sPcbaSn, sStationId, "HWHL")
            frmTestResultDetail.ShowDialog()
        End If
    End Sub


#Region "函数"
    Private Sub GetTestData()
        Dim barcode As String = txtBarCode.Text.Trim
        Dim sql As StringBuilder = New StringBuilder

        sql.Append("exec dbo.P_HWHLSNQuery '" & barcode & "','1'")
        Dim dts As DataTable = DbOperateReportUtils.GetDataTable(sql.ToString)
        DgData.DataSource = dts
        If Me.DgData.RowCount > 0 Then
            DgData.Item(0, 0).Selected = True
            ' DgData.AutoResizeColumns()
        Else
            'UIFunction.SetMessage("查不到数据！", lblMsg, True, False)
            Exit Sub
        End If
        DgData_CellClick(Nothing, Nothing)
        Threading.Thread.Sleep(300)
    End Sub
 
#End Region

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not String.IsNullOrEmpty(txtBarCode.Text) Then
            ToolReflsh_Click(Nothing, Nothing)
        End If
    End Sub
End Class