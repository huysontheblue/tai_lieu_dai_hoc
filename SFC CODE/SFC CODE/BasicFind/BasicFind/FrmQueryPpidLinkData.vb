Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO
Imports MainFrame

Public Class FrmQueryPpidLinkData
    'Private ObjDB As New SysDataBaseClass()
    Private Sub FrmQueryPpidLinkData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim Moid As String = "%"
        Dim Pppid As String = "%"
        Dim ppid As String = "%"
        Dim LineID As String = "%"
        Dim lot As String = "%"
        Dim strSql As String = ""

        If CobMo.Text <> "" And CobMo.Text <> "ALL" Then
            Moid = CobMo.Text.Trim()
        End If
        If CobPppid.Text <> "" And CobPppid.Text <> "ALL" Then
            Pppid = CobPppid.Text.Trim

        End If
        If CobLot.Text <> "" And CobLot.Text <> "ALL" Then
            lot = CobLot.Text.Trim

        End If
        If CobLine.Text <> "" And CobLine.Text <> "ALL" Then
            LineID = CobLine.Text.Trim

        End If
        If CobTppid.Text <> "" And CobTppid.Text <> "ALL" Then
            ppid = CobTppid.Text.Trim
        End If
        strSql = "exec m_QueryPpidLinkData_p '" & StartDT & "','" & EndDT & "','" & Moid & "','" & Pppid & "','" & ppid & "','" & lot & "','" & LineID & "'"
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            ToolCount.Text = dt.Rows.Count
            DataGridView1.DataSource = dt
        Else
            MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
        End If
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
End Class