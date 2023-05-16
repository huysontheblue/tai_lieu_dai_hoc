Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO
Imports System.Windows.Forms
Imports MainFrame

Public Class FrmLineBorrowLog

    Private Sub FrmSetScanQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
  
        DataGridView1.DataSource = Nothing
        Dim strSql As String = ""

        strSql = "EXEC m_QueryEquipmentLendData_p '" & StartDT & "','" & EndDT & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            ToolCount.Text = dt.Rows.Count
            DataGridView1.DataSource = dt
        Else
            MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
        End If
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

End Class