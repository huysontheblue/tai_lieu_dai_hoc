Imports MainFrame
Imports UIHandler

Public Class FrmWhStockQuery

#Region "初始化"
    Private Sub FrmWhStockQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub
#End Region

#Region "事件"
    '刷新
    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim strSQL As String
        Try
            strSQL = " EXEC m_QueryWhStockSearch_p '{0}','{1}','{2}','{3}','{4}' "
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, Me.txtStockId.Text.Trim, Me.txtPartNo.Text.Trim, Me.txtLocationName.Text.Trim)
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

            Me.dgvStock.DataSource = dt
            Me.ToolCount.Text = Me.dgvStock.RowCount.ToString()
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub
    '汇出
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(dgvStock, Me.Text)
    End Sub
    '退出
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Close()
    End Sub
#End Region

End Class