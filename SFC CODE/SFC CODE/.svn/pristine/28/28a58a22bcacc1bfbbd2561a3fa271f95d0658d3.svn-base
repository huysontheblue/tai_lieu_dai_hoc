Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO
Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Drawing

Public Class FrmRegLog
    Private m_ChkboxAll As New CheckBox

    Private Sub FrmSetScanQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        DataGridView1.DataSource = Nothing
        Dim strSql As String = ""


        strSql = "EXEC m_QueryEquipmentRegData_p '" & StartDT & "','" & EndDT & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            ToolCount.Text = dt.Rows.Count
            DataGridView1.DataSource = dt
        Else
            MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
        End If


        Dim clo As New DataGridViewCheckBoxColumn

        clo.HeaderText = "勾选"
        clo.Name = "chkbox"
        clo.Width = 150

        If Not Me.DataGridView1.Columns.Contains("chkbox") Then
            Me.DataGridView1.Columns.Insert(0, clo)
        End If

        'Me.Controls.Add(Me.dgvRunCardHeader)
        Me.m_ChkboxAll.Text = "选择"
        Me.DataGridView1.Controls.Add(Me.m_ChkboxAll)

        AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolCheck_Click(sender As Object, e As EventArgs) Handles ToolCheck.Click

        Dim lsSQL As New StringBuilder
        Dim strPartID As String = ""
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        'strPartID = Me.DataGridView1.CurrentRow.Cells(0).Value

        'lsSQL.Append(" Update  m_MaterialRegLog_t Set Status='1'  WHERE PartID='" & strPartID & "' ")

        'DbOperateUtils.ExecSQL(lsSQL.ToString)


        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            If Not dr.Cells(0).EditedFormattedValue Is Nothing AndAlso dr.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                strPartID = dr.Cells(1).Value

                lsSQL.Append(" Update  m_MaterialRegLog_t Set Status='1'  WHERE PartID='" & strPartID & "' ")
            End If
        Next

        If Not String.IsNullOrEmpty(lsSQL.ToString) Then
            DbOperateUtils.ExecSQL(lsSQL.ToString)

            MessageUtils.ShowInformation("审核成功!")
        End If

    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                ' p.Offset(Me.dgvRunCardHeader.Left, Me.dgvRunCardHeader.Top)
                p.Offset(CInt("0"), CInt("0")) 'Me.dgvRunCardHeader.Left, Me.dgvRunCardHeader.Top,182,25
                Me.m_ChkboxAll.Location = p
                Me.m_ChkboxAll.Size = DataGridView1.Columns(0).HeaderCell.Size 'Me.dgvRunCardHeader.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Size
                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRegLog", "DataGridView1_CellPainting", "Equ")
        End Try
    End Sub

    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        Try
            If Me.DataGridView1.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                Me.DataGridView1.Rows(i).Cells(0).Value = m_ChkboxAll.Checked
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRegLog", "m_ChkboxAll_CheckedChanged", "Equ")
        End Try
    End Sub
End Class