Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Drawing
Imports MainFrame


Public Class EquipReport

    Private Sub EquipReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDropDownList(ComType)
        BindData()
    End Sub

    Private Sub InitDropDownList(ByVal ColComboBox As ComboBox)
        EquMachineCommon.BindComboxStatus(ComStatus)
        EquMachineCommon.BindComboxMachineType(ComType)
    End Sub
   
    Private Sub BindData()
        'Dim StrStatus As String = "有效"
        Dim sql As String = ""
        'CASE WHEN b.username IS NULL THEN ResponUser ELSE b.username END as ResponUser
        sql = " SELECT Machine_Code,JsNo,ZcNo,Machine_Title,Machine_Type,Storage,Status," & _
              " convert(varchar(100),CheckTime,23) CheckTime,CheckInterval, " & _
              " convert(varchar(100),NextCheckTime,23) NextCheckTime," & _
              " CASE WHEN b.username IS NULL THEN ResponUser ELSE b.username END as ResponUser, " & _
              " CASE WHEN C.username IS NULL THEN TouchUser ELSE C.username END AS TouchUser, " & _
              " LineName,VendCode,Remark,FactoryName,Profitcenter, " & _
              " case Status when 0 then N'0:未校' when 1 then N'1:正常' when 2 then N'2:停用' when 3 then N'3.退修' when 4 then N'4.报废' end StatusName " & _
              " FROM m_Equ_MachineM_t a Left JOin m_Users_t  b on  a.ResponUser= b.UserID   " & _
              " Left JOin m_Users_t  C on  a.TouchUser= C.UserID   " & _
              " WHERE  factoryname='" + VbCommClass.VbCommClass.Factory + "' and profitcenter='" + VbCommClass.VbCommClass.profitcenter + "'  "
        If (Me.txtEquCode.Text.Trim <> "") Then
            sql += " AND Machine_Code like N'%" + Me.txtEquCode.Text.Trim + "%'"
        End If
        If (Me.txtJsNo.Text.Trim <> "") Then
            sql += " AND JsNo like N'%" + Me.txtJsNo.Text.Trim + "%'"
        End If
        If (Me.txtZcNo.Text.Trim <> "") Then
            sql += " AND ZcNo like N'%" + Me.txtZcNo.Text.Trim + "%'"
        End If
        If (Me.txtTitle.Text.Trim <> "") Then
            sql += " AND Machine_Title like N'%" + Me.txtTitle.Text.Trim + "%'"
        End If
        If (Me.ComType.Text <> "") Then
            sql += " AND Machine_Type=" & Me.ComType.Text.Trim
        End If
        If (Me.txtStorage.Text.Trim <> "") Then
            sql += " AND Storage like N'%" + Me.txtStorage.Text.Trim + "%'"
        End If

        If (Me.ComStatus.Text <> "") Then
            sql += " AND Status=" & Me.ComStatus.SelectedValue.ToString
        End If

        If (Me.txtResponUser.Text <> "") Then
            ' sql += " AND ResponUser like N'%" + Me.txtResponUser.Text + "%'"
            '  AND (ResponUser LIKE N'%张艳锋%' or b.username like N'%张艳锋%')
            sql += " AND (ResponUser like N'%" + Me.txtResponUser.Text.Trim() + "%' OR b.username like N'%" & Me.txtResponUser.Text.Trim() & "%') "
        End If
        If (Me.DateTimePicker1.Checked) Then
            sql += " AND CheckTime='" + Me.DateTimePicker1.Text + "'"
        End If
        If (Me.txtVendCode.Text.Trim <> "") Then
            sql += " AND VendCode like N'%" + Me.txtVendCode.Text.Trim + "%'"
        End If
        If (Me.txtCheckInterval.Text.Trim > "0") Then
            sql += " AND CheckInterval =" & CInt(Me.txtCheckInterval.Text.Trim)
        End If

        sql += " order by  Status,NextCheckTime desc "
        GridList.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                GridList.Rows.Add(
                    row("Machine_Code").ToString(), row("JsNo").ToString(), row("ZcNo").ToString(),
                    row("Machine_Title").ToString(), row("Machine_Type").ToString(),
                    row("Storage").ToString(), row("StatusName").ToString(), row("VendCode").ToString(), row("CheckTime").ToString(),
                    row("CheckInterval").ToString(), row("NextCheckTime").ToString(), row("ResponUser").ToString(),
                    row("TouchUser").ToString(), row("LineName").ToString(), row("Remark").ToString(),
                    row("FactoryName").ToString(), row("Profitcenter").ToString())
            Next
            TlelCount.Text = dt.Rows.Count
        End Using
        '设置颜色
        For rowIndex As Integer = 0 To GridList.Rows.Count - 1
            If GridList.Item("Status", rowIndex).Value.ToString.Contains(2) Then '2:停用
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.DarkCyan
            ElseIf GridList.Item("Status", rowIndex).Value.ToString.Contains(3) Then '3.退修
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf GridList.Item("Status", rowIndex).Value.ToString.Contains(4) Then '4.报废
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub ToolEquipMent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEquipMent.Click
        BindData()
    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        ClearText()
        BindData()
    End Sub

    Private Sub ClearText()
        Me.txtCheckInterval.Text = 0
        Me.txtEquCode.Text = ""
        Me.txtStorage.Text = ""
        Me.txtResponUser.Text = ""
        Me.txtJsNo.Text = ""
        Me.txtVendCode.Text = ""
        Me.ComStatus.SelectedIndex = -1
        Me.ComType.SelectedIndex = -1
        Me.txtJsNo.Text = ""
        Me.txtZcNo.Text = ""
        Me.txtStorage.Text = ""
    End Sub

    Private Sub txtEquCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEquCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BindData()
        End If
    End Sub

End Class