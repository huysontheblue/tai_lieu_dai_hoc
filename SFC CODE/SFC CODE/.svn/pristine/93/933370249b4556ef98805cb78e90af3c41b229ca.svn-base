Imports System.Windows.Forms
Imports Pager
Imports System
Imports MainFrame.SysDataHandle
Imports System.IO

Public Class FrmQueryAppUseStatus

    Private Sub FrmQueryAppUseStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not dtApps Is Nothing Then
            dtApps.Dispose()
        End If
    End Sub

    Private Sub FrmQueryAppUseStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.PagerPaging.PagerGrid.DataGrid = Me.dgvResult
            Me.PagerPaging.PagerGrid.Sort = " APID DESC "
            LoadApp()
            SetTime()
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private sConn As New SysDataBaseClass
    Private dtApps As New DataTable

    Private Sub LoadApp()
        Dim sql As String = "SELECT DISTINCT APID VALUE,APNAME TEXT FROM M_SYSAPPS_T WHERE STATUS='Y'"
        dtApps.Rows.Clear()
        dtApps = sConn.GetDataTable(sql)
        dtApps.Rows.InsertAt(dtApps.NewRow, 0)
        cboApps.DisplayMember = "TEXT"
        cboApps.ValueMember = "APID"
        cboApps.DataSource = dtApps
    End Sub

    Private Sub SetTime()
        dtEnd.Value = Now().ToString("yyyy-MM-dd")
        dtStart.Value = Now().AddDays(-7).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        PagerPaging.LoadData()
    End Sub

    Public Function GetSqlWhere()
        Dim sql As String = Nothing
        Dim row As System.Data.DataRowView = cboApps.SelectedItem
        If Not row Is Nothing AndAlso Not String.IsNullOrEmpty(row.Item(0).ToString) Then
            sql &= " AND APID='" & row.Item(0).ToString & "'" & vbNewLine
        End If
        'If Not String.IsNullOrEmpty(txtUserId.Text.Trim) Then
        '    sql &= " AND USERID='" & txtUserId.Text.Trim & "'" & vbNewLine
        'End If
        If Not String.IsNullOrEmpty(dtStart.Text) Then
            sql &= " AND USETIME >= CONVERT(VARCHAR(30),'" & dtStart.Text & " 00:00:00.000" & "',121)" & vbNewLine
        End If
        If Not String.IsNullOrEmpty(dtEnd.Text) Then
            sql &= " AND USETIME <= CONVERT(VARCHAR(30),'" & dtEnd.Text & " 23:59:59.999" & "',121)" & vbNewLine
        End If
        Return sql
    End Function

    Private Sub LoadApps() Handles PagerPaging.Paging
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        If Not BasicCheck() Then Exit Sub
        Try
            myThread.Start()
            Threading.Thread.Sleep(500)
            LoadData(GetAppSql)
            'Threading.Thread.Sleep(300)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Try
                myThread.Abort()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Function GetAppSql()
        Dim dd As Integer = 1
        Dim sql As String = Nothing
        dd = (Convert.ToDateTime(dtEnd.Text) - Convert.ToDateTime(dtStart.Text)).Days
        If dd = 0 Then dd = 1
        sql &= "SELECT A.APID,B.APNAME '程序名称',A.TOTALUSECOUNT '总共使用次数',C.TOTALUSERS '总使用人数'," & vbNewLine
        sql &= " HZ '每天平均使用次数',HZ1 '平均N天使用一次',LASTTIME '第一次使用时间',FIRSTTIME '最后一次使用时间'" & vbNewLine
        sql &= " FROM (SELECT APID,COUNT(APID) TOTALUSECOUNT," & vbNewLine
        sql &= " CONVERT(DECIMAL(15,3),(COUNT(APID)+0.0)/" & dd & ",1) HZ," & vbNewLine
        sql &= " CONVERT(DECIMAL(15,3)," & dd & "/(COUNT(APID)+0.0),1) HZ1," & vbNewLine
        sql &= " MAX(USETIME) LASTTIME,MIN(USETIME) FIRSTTIME" & vbNewLine
        sql &= " FROM M_APPSERVICECONDITION_T WHERE 1=1 " & vbNewLine
        sql &= GetSqlWhere()
        sql &= " GROUP BY APID) A JOIN " & vbNewLine
        sql &= " (SELECT APID,COUNT(DISTINCT USERID) TOTALUSERS" & vbNewLine
        sql &= " FROM M_APPSERVICECONDITION_T WHERE 1=1 " & vbNewLine
        sql &= GetSqlWhere()
        sql &= " GROUP BY APID) C ON A.APID=C.APID" & vbNewLine
        sql &= " LEFT JOIN M_SYSAPPS_T B ON A.APID=B.APID " & vbNewLine
        Return sql
    End Function

    Private Function BasicCheck()
        If String.IsNullOrEmpty(dtStart.Text) Then
            MessageBox.Show("请选择起始时间")
            Return False
        End If
        If String.IsNullOrEmpty(dtEnd.Text) Then
            MessageBox.Show("请选择结束时间")
            Return False
        End If
        If DateTime.Compare(Convert.ToDateTime(dtStart.Text), Convert.ToDateTime(dtEnd.Text)) > 0 Then
            MessageBox.Show("起始时间必须小于结束时间")
            Return False
        End If
        If Convert.ToDateTime(dtStart.Text).AddMonths(1) < Convert.ToDateTime(dtEnd.Text) Then
            MessageBox.Show("查询时间相隔最多请不要超过1个月")
            Return False
        End If
        Return True
    End Function

    Private Sub LoadData(ByVal sql)
        Using dt As DataTable = PagerPaging.GetPagingDataTable(sql, sConn.GetConnectionString(), True)
            Me.dgvResult.Columns(ResultGrid.RID).ReadOnly = True
            Me.dgvResult.Columns(ResultGrid.RID).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.dgvResult.Columns(ResultGrid.APID).Visible = False
            dgvResult.Rows.Clear()
            Dim recordIndexFrom = PagerPaging.PagerGrid.RecordIndexFrom
            For Each row As DataRow In dt.Rows
                dgvResult.Rows.Add(recordIndexFrom, row(ResultGrid.APID).ToString, row(ResultGrid.APNAME).ToString, row(ResultGrid.TOTALCOUNT).ToString, row(ResultGrid.TOTALUSERS).ToString, row(ResultGrid.HZ).ToString, row(ResultGrid.HZ1).ToString, row(ResultGrid.FIRSTTIME).ToString, row(ResultGrid.LASTTIME).ToString)
                recordIndexFrom += 1
            Next
            For idx As Integer = 1 To ResultGrid.LASTTIME
                dgvResult.Columns(idx).Width = 150
            Next
        End Using
    End Sub

    Private Enum ResultGrid
        RID = 0
        APID
        APNAME
        TOTALCOUNT
        TOTALUSERS
        HZ
        HZ1
        FIRSTTIME
        LASTTIME
    End Enum

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            LoadDataGridToExcel(sConn.GetDataTable(GetAppSql() + " ORDER BY A.APID DESC "), "MES系统使用状况")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvResult_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellClick
        If e.RowIndex <> -1 Then
            Dim frm As FrmQueryAppUseStatusDetail = Nothing
            Try
                If e.ColumnIndex = ResultGrid.TOTALCOUNT Then
                    frm = New FrmQueryAppUseStatusDetail(dgvResult.CurrentRow.Cells(ResultGrid.APID).Value.ToString, "SHOWALLRECORD")
                ElseIf e.ColumnIndex = ResultGrid.TOTALUSERS Then
                    frm = New FrmQueryAppUseStatusDetail(dgvResult.CurrentRow.Cells(ResultGrid.APID).Value.ToString, "SHOWALLUSERS")
                End If
                If Not frm Is Nothing Then
                    frm.dtEnd = dtEnd.Text
                    frm.dtStart = dtStart.Text
                    frm.StartPosition = FormStartPosition.CenterScreen
                    frm.Show()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class