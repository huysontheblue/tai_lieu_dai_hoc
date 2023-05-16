Imports UIHandler
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Threading

Public Class FrmProductNGQuery

    Private Sub FrmProductNGQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            'Me.DgData.AutoGenerateColumns = False
            DtStar.Value = Now().AddDays(-1).ToString("yyyy-MM-dd")
            DtEnd.Value = Now().ToString("yyyy-MM-dd")
            LoadDataToCombo(cbbDept, 2)
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        Try
            myThread.Start()
            lblMsg.Text = String.Empty
            Dim strSQL As String = "EXEC m_QueryTotalNGRQuery_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','1'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, Getid(cbbDept.Text), Me.cbbLine.Text, Me.txtWorkCode.Text.Trim, Me.txtPartNo.Text.Trim,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)


            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            DgData.DataSource = dts
            If Me.DgData.RowCount > 0 Then
                DgData.Item(2, 0).Selected = True
                DgData.AutoResizeColumns()
            Else
                'UIFunction.SetMessage("查不到数据！", lblMsg, True, False)
                Exit Sub
            End If

            DgData_CellClick(Nothing, Nothing)
            ToolCount.Text = DgData.RowCount.ToString()
            Threading.Thread.Sleep(300)
        Catch ex As ThreadAbortException
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
            SysMessageClass.WriteErrLog(ex, "BasicFind", "toolQuery_Click", "MES")
        Finally
            myThread.Abort()
        End Try
    End Sub

    Private Sub DgData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgData.CellClick
        Dim strSQL As String
        Try

            Dim depId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colDept").Value.ToString
            Dim line As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("ColLine").Value.ToString
            Dim moid As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colMoid").Value.ToString
            Dim partId As String = DgData.Rows(DgData.SelectedCells(0).RowIndex).Cells("colPartId").Value.ToString

            strSQL = "EXEC m_QueryTotalNGRQuery_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','2'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, "", line, moid, partId,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

            Me.DgDataDetail.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind", "DgData_CellClick", "MES")
        End Try
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        LoadLineIDToCombo(cbbLine, Getid(cbbDept.Text))
    End Sub

End Class