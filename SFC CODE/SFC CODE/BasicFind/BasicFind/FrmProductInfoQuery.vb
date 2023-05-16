Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports UIHandler
Imports MainFrame
Imports System.Threading

Public Class FrmProductInfoQuery

    Private Sub FrmProductInfoReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            Me.DgData.AutoGenerateColumns = False
            DtStar.Value = Now().AddDays(-10).ToString("yyyy-MM-dd")
            DtEnd.Value = Now().ToString("yyyy-MM-dd")
            LoadDataToCombo(cbbDept, 2)
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        Try
            myThread.Start()

            Dim strSQL As String = "EXEC m_QueryTotalNGQuery_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, Getid(cbbDept.Text), Me.cbbLine.Text, Me.txtWorkCode.Text.Trim, Me.txtPartNo.Text.Trim,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            DgData.DataSource = dts
            DgData.Refresh()
            If Me.DgData.RowCount > 0 Then
                DgData.Item(2, 0).Selected = True
            End If

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

    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        LoadLineIDToCombo(cbbLine, Getid(cbbDept.Text))
    End Sub

End Class