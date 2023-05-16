Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmRugenProductTrace

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim barcode As String = txtBarCode.Text.Trim
        Dim sql As StringBuilder = New StringBuilder
        sql.Append(" select a.PCBASN,MACAddress=case when b.Stationid in ('A00078','A00080') then '' else a.MACAddress end,LaserSN=case when b.Stationid in ('A00078','A00080','A00081','A00082','A00083','A00084') then '' else a.LaserSN end,ISNULL(f.result,'PASS') as result,f.Test1,f.Test2,f.Test3,b.Moid,b.Intime,b.Teamid,b.Stationid,c.Stationname,d.partid from m_AmzMACSNLink_t a")
        sql.Append(" left join m_AssysnD_t b on a.PCBASN=b.Ppid")
        sql.Append(" left join m_Rstation_t c on b.Stationid=c.Stationid")
        sql.Append(" left join m_mainmo_t d on b.Moid=d.Moid")
        sql.Append(" left join m_TestStation_t e on e.MesStationId=b.Stationid ")
        sql.Append(" left join MESDataCenter.dbo.m_TestResult_t f on f.ppid=a.PCBASN and f.stationid=e.TestTypeId ")
        sql.Append("  where (LaserSN='" & barcode & "' or PCBASN='" & barcode & "' or MACAddress='" & barcode & "')")
        sql.Append(" order by b.Intime")
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
        '  ToolCount.Text = DgData.RowCount.ToString()
        Threading.Thread.Sleep(300)
    End Sub

    Private Sub DgData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgData.CellClick
        Dim strSQL As StringBuilder = New StringBuilder
        Try

            'Dim depId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colDept").Value.ToString
            'Dim line As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("ColLine").Value.ToString
            Dim moid As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("Moid").Value.ToString
            'Dim partId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colPartId").Value.ToString
            strSQL.Append(" select Moid,Lotid,Ppartid,Partid,Partdes,Stationid,CustPart,UserID=a.UserID+'/'+b.UserName,a.Intime from M_PCBLot_t a")
            strSQL.Append(" left join m_Users_t b on a.UserID=b.UserID")
            strSQL.Append(" where moid='" & moid & "'")
            strSQL.Append(" order by a.Partid,a.Intime ")
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL.ToString)

            Me.DgDataDetail.DataSource = dt
            If Me.DgDataDetail.RowCount > 0 Then
                '   DgDataDetail.AutoResizeColumns()
            Else
                'UIFunction.SetMessage("查不到数据！", lblMsg, True, False)
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind", "DgData_CellClick", "FrmRugenProductTrace")
        End Try
    End Sub

    Private Sub DgData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgData.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.DgData.RowCount > 0 Then
      
            Dim sPcbaSn As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("PCBASN").Value.ToString
            Dim sStationId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("Stationid").Value.ToString

            Dim frmTestResultDetail As FrmTestResultDetail = New FrmTestResultDetail(sPcbaSn, sStationId)
            frmTestResultDetail.ShowDialog()
        End If
    End Sub



End Class