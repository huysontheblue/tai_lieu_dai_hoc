Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO
Imports System.Windows.Forms
Imports MainFrame

Public Class FrmAssetLendBorrowLog

    Private ObjDB As New SysDataBaseClass()
    Private Sub FrmAssetLendBorrowLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        Dim strSql As New StringBuilder

        DataGridView1.DataSource = Nothing

        strSql.Append("Select EquipmentNo '资产编号',FromLineID as '借出人保管位置',")
        strSql.Append(" FromUserID as '借出人' ,ToLineID as '借出给线别' ,ToUserID as '借出给',Intime as '借出时间'")
        strSql.Append(" FROM  dbo.m_AssetLendLog_t ")
        strSql.Append(" WHERE Intime between '" & StartDT & " ' and '" & EndDT & "'")


        Dim dt As DataTable = ObjDB.GetDataTable(strSql.ToString())
        If dt.Rows.Count > 0 Then
            ToolCount.Text = dt.Rows.Count
            DataGridView1.DataSource = dt
        Else
            MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
        End If
    End Sub
End Class