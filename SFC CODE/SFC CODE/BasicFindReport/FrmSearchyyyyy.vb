Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

'修改為存儲過程 by:Anday_xu Date:2010-06-19

Public Class FrmSearchyyyyy
    Private Rs As SqlDataReader
    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    Private g_Factory As String

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub FrmScanQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        FillComboLine(CobMo)
        FillComboLine(CobDept)
        FillComboLine(CobPart)
        'FillComboLine(CobPPID)
        FillComboLine(CoboLine)
        'LoadDataToCombo(CobCus, 1)
        LoadDataToCombo(CobDept, 2)
        'CobStatus.SelectedIndex = 0
        'FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        DtStar.Focus()
        Me.SplitContainer1.Panel2Collapsed = True

    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        Try
            'If CobFactory.Text <> "" Then
            '    g_Factory = GetFactoryCode(CobFactory.Text)
            'Else
            '    g_Factory = ""
            'End If

            DgMoData.Focus()
            If Not CheckDate(DtStar, DtEnd) Then Exit Sub

            If Not CheckCondition() Then
                MsgBox("由于数据量较大，请输入更精确的查询条件...", 48, "提示")
                Exit Sub
            End If
            myThread.Start()
            ShowData()
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub

    Private Sub ShowData()
        Dim StartDT, EndDT As String
        Dim ColsText As String
        Dim i As Integer
        Dim ColsName As String()
        Dim DtCtScan As DataTable

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim param(9) As SqlParameter
        param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --起始時間
        param(0).Value = StartDT
        param(1) = New SqlParameter("@endtime", SqlDbType.Char)      '@endtime     varchar(25),  --終止時間
        param(1).Value = EndDT

        ColsText = "工单|机种代码|料件编号|工站代码|工站名称|投入数量|产出数量|不良数量|不良率"

        param(2) = New SqlParameter("@moid", SqlDbType.Char)    '@moid        varchar(12),  --工單編號
        If Me.CobMo.Text <> "ALL" AndAlso CobMo.Text <> "" Then
            param(2).Value = Me.CobMo.Text
        Else
            param(2).Value = "%"
        End If

        param(3) = New SqlParameter("@partid", SqlDbType.Char)   '@partid      varchar(20),  --料件編號
        If CobPart.Text <> "ALL" AndAlso CobPart.Text <> "" Then
            param(3).Value = Me.CobPart.Text
        Else
            param(3).Value = "%"
        End If


        param(4) = New SqlParameter("@deptid ", SqlDbType.Char)       '@deptid      varchar(6),   --部門編號
        If CobDept.Text <> "ALL" AndAlso CobDept.Text <> "" Then
            param(4).Value = Getid(Me.CobDept.Text)
        Else
            param(4).Value = "%"
        End If



        param(5) = New SqlParameter("@lineid", SqlDbType.NChar)    '@lineid      varchar(6)    --線別編號
        If Me.CoboLine.Text <> "ALL" AndAlso Me.CoboLine.Text <> "" Then
            param(5).Value = Getid(Me.CoboLine.Text)
        Else
            param(5).Value = "%"
        End If
        Try
            DtCtScan = DbOperateReportUtils.GetDataTable("execute m_QueryScanRecord_pnew @begintime,@endtime,@moid,@partid,@deptid,@lineid ", param)
            ToolCount.Text = DtCtScan.Rows.Count.ToString()
            ColsName = ColsText.Split("|")
            DgMoData.DataSource = DtCtScan
            For i = 0 To DgMoData.Columns.Count - 1
                DgMoData.Columns(i).HeaderText = ColsName(i)
                DgMoData.Columns(i).Name = ColsName(i)
            Next
            DgMoData.Refresh()
            DtCtScan.Dispose()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CobDept_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadLineIDToCombo(CoboLine, Getid(CobDept.Text))
    End Sub

    Private Function CheckCondition() As Boolean
        If CobMachina.Text = "ALL" And CobMo.Text = "ALL" And CobPart.Text = "ALL" _
           And CobDept.Text = "ALL" And CoboLine.Text = "ALL" Then
            Return False
        Else
            Return True
        End If
    End Function

    'Private Sub CobPPID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.DgMoData.DataSource = ""
    '    Me.ToolCount.Text = "0"
    'End Sub

    'Private Function GetQueryCondition() As String
    '    Dim str As String
    '    str = "起始時間:" & DtStar.Value.ToString() & "至" & DtEnd.Value.ToString() & "  " & "工廠別:" & CobFactory.Text & "  " _
    '        & "料件編號:" & CobPart.Text & "  " & "線別:" & CoboLine.Text _
    '        & "產品條碼:" & CobPPID.Text & "  " & "部門編號:" & CobDept.Text & "  " & "狀態:" & CobStatus.Text _
    '        & "工單編號:" & CobMo.Text & "  " & "客戶名稱:" & CobCus.Text
    '    Return str
    'End Function

    'Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
    '    If Me.DgMoData.RowCount < 1 Then Exit Sub
    '    'ObjDB.InportInExcel(strSaveSql, "掃描記錄查詢", DgMoData, GetQueryCondition)
    '    LoadDataToOpExcel("掃描記錄查詢", DgMoData, "")
    'End Sub

    '    '2009-08-30 by tangxiang ----
    '#Region "Enter-->Tab"

    '    Private Sub CoboLine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        If e.KeyChar = Chr(13) Then
    '            ToolReflsh_Click(sender, e)
    '        End If
    '    End Sub

    '    Private Sub DtStar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        If e.KeyChar = Chr(13) Then
    '            SendKeys.Send("{tab}")
    '        End If
    '    End Sub

    '#End Region

    'Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.SplitContainer1.Panel2Collapsed = True
    'End Sub


    Private Sub ToolReflsh111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh111.Click
        'Me.SplitContainer1.Panel2Collapsed = False
    End Sub

    'Private Sub DgMoData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellContentClick

    '    Dim MyTable As DataTable
    '    Dim SqlString As String = "select CableSN,LineSn,LineMsg,intime  from dbo.M_LineReadSn_t where CableSN='" & Me.DgMoData.CurrentRow.Cells(3).Value.ToString.Trim & "'"
    '    MyTable = ObjDB.GetDataTable(SqlString)
    '    Me.DataGridView1.DataSource = MyTable

    'End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub
End Class