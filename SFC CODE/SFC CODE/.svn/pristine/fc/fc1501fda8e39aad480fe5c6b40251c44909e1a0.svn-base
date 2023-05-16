Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

Public Class EquipCheck
    Dim opFlag As Int16 = 0
    Dim CheckTime As String = ""
    Dim NextCheckTime As String = ""
    Dim ID As Integer = 0

    Private Sub EquipCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitStatus()
        BindData()
    End Sub
    Private Sub InitStatus()
        ComCheckStatus.Items.Add("有效")
        ComCheckStatus.Items.Add("无效")
        ComCheckStatus.SelectedIndex = 0
    End Sub

    Private Sub ClearText()
        Me.txtEquCode.Text = ""
        Me.txtCheckUser.Text = ""
        Me.txtCREATEUSERNAME.Text = ""
        Me.ComCheckStatus.SelectedIndex = -1
        Me.DateTimePicker1.Checked = False
    End Sub

    Private Sub BindData()
        Dim sql As String = " SELECT c.Machine_Code,c.CheckUser,c.Remark,c.CheckStatus, c.CREATEUSERNAME,convert(varchar(100),c.CREATEDATETIME,23) CREATEDATETIME,convert(varchar(100),m.CheckTime,23) CheckTime,convert(varchar(100),m.NextCheckTime,23) NextCheckTime,m.CheckInterval,c.FactoryName,c.Profitcenter from m_Equ_MachineChecks_t c,m_Equ_MachineM_t m where c.Machine_Code=m.Machine_Code  and c.factoryname='" + VbCommClass.VbCommClass.Factory + "' and c.profitcenter='" + VbCommClass.VbCommClass.profitcenter + "'  "
        If (Me.txtEquCode.Text.Trim <> "") Then
            sql += " and  c.Machine_Code like '%" + Me.txtEquCode.Text.Trim + "%'"
        End If
        If (Me.txtCheckUser.Text.Trim <> "") Then
            sql += " AND  c.CheckUser like '%" + Me.txtCheckUser.Text.Trim + "%'"
        End If
        If (Me.ComCheckStatus.SelectedIndex <> -1) Then
            sql += " and c.CheckStatus=N'" + Me.ComCheckStatus.Text + "'"
        End If

        If (Me.DateTimePicker1.Checked = True) Then
            sql += " and c.CREATEDATETIME='" + Me.DateTimePicker1.Text.Trim + "'"
        End If

        GridList.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                Try
                    GridList.Rows.Add(row("Machine_Code").ToString(), row("CheckUser").ToString(), row("CheckStatus").ToString(), row("CREATEUSERNAME").ToString(), row("CREATEDATETIME").ToString(), row("CheckTime").ToString(), row("NextCheckTime").ToString(), row("CheckInterval").ToString(), row("Remark").ToString(), row("FactoryName").ToString(), row("Profitcenter").ToString())
                Catch ex As Exception

                End Try
            Next
            TlelCount.Text = dt.Rows.Count
        End Using
    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        ClearText()
        BindData()
    End Sub

    Private Sub ToolQueryMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQueryMO.Click
        BindData()
    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub txtEquCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEquCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BindData()
        End If
    End Sub
End Class