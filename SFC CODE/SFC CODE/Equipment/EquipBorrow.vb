Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

Public Class EquipBorrow

    '初期化
    Private Sub EquipBorrow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindData()
        InitStatus()
    End Sub

    Private Sub ClearText()
        Me.txtEquCode.Text = ""
        Me.txtTouchUser.Text = ""
        Me.txtLineName.Text = ""

        Me.ComStatus.SelectedIndex = -1
        Me.txtFinishUser.Text = ""
        Me.txtFinishTime.Checked = False
    End Sub

    '查询
    Private Sub ToolQueryMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQueryMO.Click
        BindData()
    End Sub

    '退出 
    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub GridList_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles GridList.CellFormatting
        If (GridList.Columns(e.ColumnIndex).Name = "ReturnTime") Then
            Dim strTime As String = Date.Parse(e.Value).ToString("yyyy-MM-dd")
            If strTime <= Now.ToString("yyyy-MM-dd") Then
                GridList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DeepPink
            End If
        End If
    End Sub

    Private Sub InitStatus()
        ComStatus.Items.Add("有效")
        ComStatus.Items.Add("无效")
        ComStatus.SelectedIndex = -1
    End Sub

    Private Sub BindData()
        Dim sql As String = ""
        sql = " SELECT Machine_Code, CASE WHEN b.username IS NULL THEN TouchUser ELSE b.username END AS TouchUser,a.Usey,CREATEUSERNAME," & _
              " CREATEDATETIME, FinishUser, " & _
              " FinishTime,Remark,LineName,FactoryName,Profitcenter,id " & _
              " FROM m_Equ_MachineShift_t  a LEFT JOIN m_Users_t b ON a.TouchUser= b.userid" & _
              " WHERE 1=1  and factoryname='" + VbCommClass.VbCommClass.Factory + "' and profitcenter='" + VbCommClass.VbCommClass.profitcenter + "'  "
        If Me.txtEquCode.Text.Trim <> "" Then
            sql += " AND Machine_Code like N'%" + Me.txtEquCode.Text.Trim + "%'"
        End If
        If Me.ComStatus.SelectedIndex > -1 Then
            sql += " and a.Usey=N'" + Me.ComStatus.Text + "'"
        End If

        If Me.txtTouchUser.Text.Trim <> "" Then
            sql += " and TouchUser like N'%" + Me.txtTouchUser.Text.Trim + "%'"
        End If
        If Me.txtLineName.Text.Trim <> "" Then
            sql += " and LineName like N'%" + Me.txtLineName.Text.Trim + "%'"
        End If

        If Me.txtFinishUser.Text.Trim <> "" Then
            sql += " and FinishUser like N'%" + Me.txtFinishUser.Text.Trim + "%'"
        End If
        If (Me.txtFinishTime.Checked) Then
            sql += "  and  FinishTime='" + Me.txtFinishTime.Text.Trim + "' "
        End If
        sql += "order by FinishTime desc  "
        GridList.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                Try
                    GridList.Rows.Add(row("Machine_Code").ToString(), row("Usey").ToString(), row("TouchUser").ToString(),
                                      row("CREATEUSERNAME").ToString(), row("CREATEDATETIME").ToString(), row("Remark").ToString(),
                                      row("FinishUser").ToString(), row("FinishTime").ToString(), row("LineName").ToString(),
                                      row("FactoryName").ToString(), row("Profitcenter").ToString(), row("id").ToString())
                Catch ex As Exception

                End Try
            Next
            Me.TlelCount.Text = dt.Rows.Count
        End Using
    End Sub

End Class