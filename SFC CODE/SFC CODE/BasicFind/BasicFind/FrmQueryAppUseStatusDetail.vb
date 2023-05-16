Imports System.Windows.Forms
Imports Pager
Imports System
Imports MainFrame.SysDataHandle
Imports System.Threading

Public Class FrmQueryAppUseStatusDetail

    Private apid As String
    Private type As String
    Public dtStart As String
    Public dtEnd As String
    Sub New(ByVal _apid As String, ByVal _type As String)
        apid = _apid
        type = _type
        InitializeComponent()
    End Sub


    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim sql As String = Nothing
        Try
            If TabControl1.SelectedIndex = 0 Then
                sql = GetAllRecordSql()
                sql += " ORDER BY 使用者工号 DESC,使用时间 DESC "
            ElseIf TabControl1.SelectedIndex = 1 Then
                sql = GetAllUserSql()
                sql += " ORDER BY 使用者工号 DESC,使用次数 DESC "
            Else
                sql = GetUserUseSql()
                sql += " ORDER BY 使用时间 DESC"
            End If
            LoadDataGridToExcel(sConn.GetDataTable(sql), "MES系统使用状况详情")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmQueryAppUseStatusDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.PagerPaging.PagerGrid.DataGrid = Me.dgvResult
            If type = "SHOWALLRECORD" Then
                Me.PagerPaging.PagerGrid.Sort = " 使用者工号 DESC,使用时间 DESC "
                Me.PagerPaging.PagerGrid.DataGrid = Me.dgvResult
                PagerPaging.LoadData()
                TabControl1.SelectedIndex = 0
            ElseIf type = "SHOWALLUSERS" Then
                Me.PagerPaging.PagerGrid.Sort = " 使用者工号 DESC,使用次数 DESC "
                Me.PagerPaging.PagerGrid.DataGrid = Me.dgvResultUsers
                PagerPaging.LoadData()
                TabControl1.SelectedIndex = 1
            End If
            Me.StartPosition = FormStartPosition.CenterScreen
        Catch ex As Exception

        End Try
    End Sub

    Private _isLock As Boolean = False
    Private Sub LoadDetailData() Handles PagerPaging.Paging
        Dim sql As String = Nothing
        Dim frmwait As New FrmWait()
        Dim myThread As New Threading.Thread(New ParameterizedThreadStart(AddressOf ShowWindow))
        Try
            If type = "SHOWALLRECORD" Then
                sql = GetAllRecordSql()
            ElseIf type = "SHOWALLUSERS" Then
                sql = GetAllUserSql()
            ElseIf type = "SHOWALLUSERSDETAIL" Then
                sql = GetUserUseSql()
            End If
            _isLock = True
            myThread.Start(frmwait)
            Threading.Thread.Sleep(300)
            LoadData(sql)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Try
                If Not frmwait Is Nothing Then frmwait.Dispose()
                myThread.Abort()
                myThread.Join()
            Catch ex As ThreadAbortException
            Catch ex As Exception
            End Try
            Application.DoEvents()
        End Try
    End Sub

    Public Sub ShowWindow(ByVal frm As Object)
        Application.DoEvents()
        CType(frm, Form).ShowDialog()
    End Sub

    Private Function GetAllRecordSql()
        Dim sql As String = Nothing
        sql = "SELECT A.APID,A.APNAME '程序名称',A.USERID '使用者工号',B.USERNAME '使用者姓名',A.USETIME '使用时间',A.WORKSTATION '工作机台'" & vbNewLine
        sql &= " FROM M_APPSERVICECONDITION_T A " & vbNewLine
        sql &= " LEFT JOIN M_USERS_T B ON A.USERID=B.USERID WHERE APID='" & apid & "'" & vbNewLine
        sql &= " AND A.USETIME >= CONVERT(VARCHAR(30),'" & dtStart & " 00:00:00.000" & "',121)" & vbNewLine
        sql &= " AND A.USETIME <= CONVERT(VARCHAR(30),'" & dtEnd & " 23:59:59.999" & "',121)" & vbNewLine
        If Not String.IsNullOrEmpty(txtUserId.Text) Then
            sql &= " AND A.USERID='" & txtUserId.Text & "'"
        End If
        Return sql
    End Function

    Private Function GetAllUserSql()
        Dim sql As String = Nothing
        sql = " SELECT A.APID,B.APNAME '程序名称',A.USERID '使用者工号',C.USERNAME '使用者姓名',A.TCOUNT '使用次数'" & vbNewLine
        sql &= " FROM " & vbNewLine
        sql &= " (SELECT APID,USERID ,COUNT(USERID) TCOUNT " & vbNewLine
        sql &= " FROM M_APPSERVICECONDITION_T" & vbNewLine
        sql &= " WHERE APID='" & apid & "' " & vbNewLine
        sql &= " AND USETIME >= CONVERT(VARCHAR(30),'" & dtStart & " 00:00:00.000" & "',121)" & vbNewLine
        sql &= " AND USETIME <= CONVERT(VARCHAR(30),'" & dtEnd & " 23:59:59.999" & "',121)" & vbNewLine
        If Not String.IsNullOrEmpty(txtUserId.Text) Then
            sql &= " AND USERID='" & txtUserId.Text & "'"
        End If
        sql &= " GROUP BY APID,USERID) A " & vbNewLine
        sql &= " LEFT JOIN M_SYSAPPS_T B ON A.APID=B.APID LEFT JOIN M_USERS_T C ON A.USERID=C.USERID" & vbNewLine
        Return sql
    End Function

    Private userId As String = Nothing
    Private Function GetUserUseSql()
        Dim sql As String = Nothing
        sql = "SELECT A.APID,A.APNAME '程序名称',A.USERID '使用者工号',B.USERNAME '使用者姓名',A.USETIME '使用时间',A.WORKSTATION '工作机台'"
        sql &= " FROM M_APPSERVICECONDITION_T A " & vbNewLine
        sql &= " LEFT JOIN M_USERS_T B ON A.USERID=B.USERID WHERE APID='" & apid & "'" & vbNewLine
        sql &= " AND A.USETIME >= CONVERT(VARCHAR(30),'" & dtStart & " 00:00:00.000" & "',121)" & vbNewLine
        sql &= " AND A.USETIME <= CONVERT(VARCHAR(30),'" & dtEnd & " 23:59:59.999" & "',121)" & vbNewLine
        sql &= " AND A.USERID='" & userId & "'"
        Return sql
    End Function

    Private sConn As New SysDataBaseClass

    Private Sub LoadData(ByVal sql As String)
        Using dt As DataTable = PagerPaging.GetPagingDataTable(Sql, sConn.GetConnectionString(), True)
            Dim recordIndexFrom = PagerPaging.PagerGrid.RecordIndexFrom
            If type = "SHOWALLRECORD" Then
                'dgvResult.Rows.Clear()
                'For Each row As DataRow In dt.Rows
                '    dgvResult.Rows.Add(recordIndexFrom, row(AllRecordGrid.Apid).ToString, row(AllRecordGrid.ApName).ToString, row(AllRecordGrid.UserId).ToString, row(AllRecordGrid.UserName).ToString, row(AllRecordGrid.UseTIme).ToString)
                '    recordIndexFrom += 1
                'Next
                dgvResult.Columns.Clear()
                dgvResult.DataSource = dt
                Me.dgvResult.Columns(AllRecordGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
                Me.dgvResult.Columns(AllRecordGrid.Seq).HeaderText = "序号"
                Me.dgvResult.Columns(AllRecordGrid.Apid).Visible = False
                'For idx As Integer = 1 To dgvResult.Columns.Count - 1
                '    dgvResult.Columns(idx).Width = 150
                'Next
            ElseIf type = "SHOWALLUSERS" Then
                dgvResultUsers.Rows.Clear()
                For Each row As DataRow In dt.Rows
                    dgvResultUsers.Rows.Add(recordIndexFrom, row(AllUserGrid.Apid).ToString, row(AllUserGrid.ApName).ToString, row(AllUserGrid.UserId).ToString, row(AllUserGrid.UserName).ToString, row(AllUserGrid.TotalCount).ToString)
                    recordIndexFrom += 1
                Next
                Me.dgvResultUsers.Columns(AllUserGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
                Me.dgvResultUsers.Columns(AllUserGrid.Apid).Visible = False
                'For idx As Integer = 1 To dgvResult.Columns.Count - 1
                '    dgvResultUsers.Columns(idx).Width = 150
                'Next
            ElseIf type = "SHOWALLUSERSDETAIL" Then
                'dgvResultUse.Rows.Clear()
                'For Each row As DataRow In dt.Rows
                '    dgvResultUse.Rows.Add(recordIndexFrom, row(AllRecordGrid.Apid).ToString, row(AllRecordGrid.ApName).ToString, row(AllRecordGrid.UserId).ToString, row(AllRecordGrid.UserName).ToString, row(AllRecordGrid.UseTIme).ToString)
                '    recordIndexFrom += 1
                'Next
                dgvResultUse.Columns.Clear()
                dgvResultUse.DataSource = dt
                Me.dgvResultUse.Columns(AllRecordGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
                Me.dgvResultUse.Columns(AllRecordGrid.Seq).HeaderText = "序号"
                Me.dgvResultUse.Columns(AllRecordGrid.Apid).Visible = False
                'For idx As Integer = 1 To dgvResult.Columns.Count - 1
                '    dgvResultUse.Columns(idx).Width = 150
                'Next
            End If

        End Using
    End Sub

    Private Enum AllRecordGrid
        Seq
        Apid
        ApName
        UserId
        UserName
        UseTIme
    End Enum
    Private Enum AllUserGrid
        Seq
        Apid
        ApName
        UserId
        UserName
        TotalCount
    End Enum

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        PagerPaging.LoadData()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            ToolStripButton2.Enabled = True
            type = "SHOWALLRECORD"
            PagerPaging.ResetPagerParameters(" 使用者工号 DESC,使用时间 DESC ", Me.dgvResult)
        ElseIf TabControl1.SelectedIndex = 1 Then
            ToolStripButton2.Enabled = True
            type = "SHOWALLUSERS"
            PagerPaging.ResetPagerParameters(" 使用者工号 DESC,使用次数 DESC ", Me.dgvResultUsers)
        Else
            ToolStripButton2.Enabled = False
            type = "SHOWALLUSERSDETAIL"
            PagerPaging.ResetPagerParameters(" 使用时间 DESC ", Me.dgvResultUse)
        End If
        PagerPaging.LoadData()
    End Sub

    Private Sub dgvResultUsers_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultUsers.CellClick
        If e.RowIndex <> -1 Then
            If e.ColumnIndex = 5 Then
                userId = dgvResultUsers.CurrentRow.Cells(AllUserGrid.UserId).Value.ToString
                type = "SHOWALLUSERSDETAIL"
                TabControl1.SelectedIndex = 2
            End If
        End If
    End Sub
End Class