Imports MainFrame
Imports UIHandler
Imports System.Threading

Public Class FrmProductPlanQuery

    Private Sub FrmProductPlanQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            Me.DgData.AutoGenerateColumns = False
            DtStar.Value = Now().AddDays(-10).ToString("yyyy-MM-dd")
            DtEnd.Value = Now().ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        Try
            myThread.Start()
            lblMsg.Text = String.Empty
            Dim strSQL As String = "EXEC m_QueryTodayMoidQty_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, "", Me.cbbLine.Text, Me.txtWorkCode.Text.Trim, Me.txtPartNo.Text.Trim,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            DgData.DataSource = dts

            ToolCount.Text = DgData.RowCount.ToString()

            Threading.Thread.Sleep(300)
        Catch ex As ThreadAbortException
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        Finally
            myThread.Abort()
        End Try
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#Region "Grid行数"
    Private Sub dgvMOID_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgData.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class