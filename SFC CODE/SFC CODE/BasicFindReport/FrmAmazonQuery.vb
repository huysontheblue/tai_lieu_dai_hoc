Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports UIHandler
Imports MainFrame

Public Class FrmAmazonQuery

    Private Sub FrmAmazonQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DgData.AutoGenerateColumns = False
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        FillComboLine(CobMo)
        FillComboLine(CobDept)
        FillComboLine(CobPart)
        FillComboLine(CboCus)
        FillComboLine(CobCarton)
        LoadDataToCombo(CobDept, 2)
        LoadDataToCombo(CboCus, 1)
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim strSQL As String
        Try
            strSQL = "EXEC GetAmazonQuery '" & Me.DtStar.Text.Trim & "', '" & Me.DtEnd.Text.Trim & "', '" & IIf(Me.CobMo.Text.Trim = "ALL", "%", Me.CobMo.Text.Trim) & "', '" & Me.CobPO.Text.Trim & "', '" & Me.cboAsin.Text.Trim & "', '" & Me.CobPPID.Text.Trim & "'"
            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            DgData.DataSource = dts
            DgData.Refresh()
            If Me.DgData.RowCount > 0 Then
                DgData.Columns(0).Visible = False
                DgData.Item(2, 0).Selected = True
            End If

            ToolCount.Text = DgData.RowCount.ToString()
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DgData, Me.Text)
    End Sub
End Class