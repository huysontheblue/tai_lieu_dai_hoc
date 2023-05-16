Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindData()
    End Sub

    Private Sub BindData()
        Dim sql As String = "select Machine_Code,CheckUser,Remark,CheckStatus, CREATEUSERNAME,convert(varchar(100),CREATEDATETIME,23) CREATEDATETIME from m_Equ_MachineChecks_t where 1=1 and CREATEUSERNAME=N'" + VbCommClass.VbCommClass.UseId + "'  "
        'If (Me.txtEquCode.Text.Trim <> "") Then
        '    sql += " and  Machine_Code like '%" + Me.txtEquCode.Text.Trim + "%'"
        'End If
        'If (Me.txtCheckUser.Text.Trim <> "") Then
        '    sql += "and  CheckUser like '%" + Me.txtCheckUser.Text.Trim + "%'"
        'End If
        'sql += " and CheckStatus=N'" + Me.ComCheckStatus.Text + "'"
        'If (Me.DateTimePicker1.Checked = True) Then
        '    sql += " and CREATEDATETIME='" + Me.DateTimePicker1.Text.Trim + "'"
        'End If

        GridList.Rows.Clear()
        Using dt As DataTable = ExecuteCmd.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                Try
                    GridList.Rows.Add(row("Machine_Code").ToString(), row("CheckUser").ToString(), row("CheckStatus").ToString(), row("CREATEUSERNAME").ToString(), row("CREATEDATETIME").ToString(), row("Remark").ToString())
                Catch ex As Exception

                End Try

            Next
            TlelCount.Text = dt.Rows.Count
        End Using
    End Sub
End Class