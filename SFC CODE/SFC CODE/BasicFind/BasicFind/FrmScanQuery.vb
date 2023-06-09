Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO
Imports MainFrame

'修改為存儲過程 by:Anday_xu Date:2010-06-19
'add by hgd 2018-01-25 加入箱号条件
Public Class FrmScanQuery
    'Private ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()
    Private Rs As SqlDataReader
    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    Private g_Factory As String

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint, DataGridView1.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub FrmScanQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        FillComboLine(CobMo)
        FillComboLine(CobDept)
        FillComboLine(CobPart)
        FillComboLine(CoboLine)
        LoadDataToCombo(CobCus, 1)
        LoadDataToCombo(CobDept, 2)
        CobStatus.SelectedIndex = 0
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        DtStar.Focus()
        Me.SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub
    Public Shared Sub LogSave(ByVal text As String)
        Dim Path As String = ".\log\" + DateTime.Now.ToString("yyyyMMdd") + ".log"
        If Not Directory.Exists(".\log") Then
            Directory.CreateDirectory(".\log")
        End If
        Using sw As New StreamWriter(Path, True, System.Text.Encoding.Default)
            sw.WriteLine(DateTime.Now.ToString())
            sw.WriteLine(text)
            sw.Flush()
        End Using
    End Sub
    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click

        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            DgMoData.Focus()
            If Not CheckDate(DtStar, DtEnd, Me.CobPPID.Text.Trim) Then Exit Sub

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
        Dim StartDT, EndDT, o_strSQL As String
        Dim ColsText As String = ""
        Dim i As Integer
        Dim ColsName As String()
        Dim DtCtScan As DataTable

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim param(12) As SqlParameter
        param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --起始時間
        param(0).Value = StartDT
        param(1) = New SqlParameter("@endtime", SqlDbType.Char)      '@endtime     varchar(25),  --終止時間
        param(1).Value = EndDT
        param(2) = New SqlParameter("@typeid", SqlDbType.Char)       '@typeid      varchar(1),   --狀態（1：正常掃描；2：錯誤掃描;3:维修扫描）
        '正常扫描 --1
        '错误扫描
        '维修扫描 --3
        '功能不良维修扫描
        '包装删除记录 --5
        '重工扫描
        ' 1：正常掃描；2：錯誤掃描；3：維修品掃描
        If CobStatus.SelectedIndex = 0 Then
            Select Case VbCommClass.VbCommClass.profitcenter
                Case "XT-D"
                    ColsText = "客戶|部门|线别|产品条码|校验码|EAN码|状态|站点编号|站点名称|工单编号|料件编号|电脑名称|扫描人员|扫描时间|维修品"
                Case Else
                    'Pigtail條碼|Cap條碼|PCBA條碼, cq20180103
                    ColsText = "客戶|部门|线别|产品条码|状态|站点编号|站点名称|工单编号|料件编号|电脑名称|扫描人员|扫描时间|维修品|主條碼|副条码一|副条码二|副条码三|测试站点|校验码"
            End Select
            param(2).Value = "1"
        ElseIf CobStatus.SelectedIndex = 1 Then
            ColsText = "客戶|部门|线别|产品条码|工单编号|料件编号|电脑名称|扫描人员|扫描时间|错误描述|解决方法|解锁人员|解锁时间"
            param(2).Value = "2"
        ElseIf CobStatus.SelectedIndex = 2 Then
            ColsText = "客戶|部门|线别|产品条码|工单编号|料件编号|扫描人员|扫描时间"
            param(2).Value = "3"
        ElseIf CobStatus.SelectedIndex = 3 Then
            ColsText = "客戶|部门|线别|产品条码|状态|站点编号|站点名称|工单编号|料件编号|电脑名称|扫描人员|扫描时间|维修品|功能不良品"
            param(2).Value = "4"
        ElseIf CobStatus.SelectedIndex = 4 Then
            'ColsText = "客戶|部门|线别|产品条码|箱号|站点编号|站点名称|工单编号|料件编号|扫描人员|扫描时间|删除人员|删除时间"
            '关晓艳 修改 查询删除原因
            ColsText = "客戶|部门|线别|产品条码|箱号|站点编号|站点名称|工单编号|料件编号|扫描人员|扫描时间|删除人员|删除时间|删除原因"
            param(2).Value = "5"
        ElseIf CobStatus.SelectedIndex = 5 Then
            ColsText = "客戶|部门|线别|产品条码|箱号|站点编号|站点名称|工单编号|料件编号|扫描人员|扫描时间"
            param(2).Value = "6"
        Else
            Exit Sub
        End If

        param(3) = New SqlParameter("@factoryid", SqlDbType.Char)  '@factoryid   varchar(2),   --公司別
        param(3).Value = g_Factory

        param(4) = New SqlParameter("@moid", SqlDbType.Char)    '@moid        varchar(12),  --工單編號
        If Me.CobMo.Text <> "ALL" Then
            param(4).Value = Me.CobMo.Text.Trim
        Else
            param(4).Value = "%"
        End If

        param(5) = New SqlParameter("@partid", SqlDbType.Char)   '@partid      varchar(20),  --料件編號
        If CobPart.Text <> "ALL" Then
            param(5).Value = Me.CobPart.Text.Trim
        Else
            param(5).Value = "%"
        End If


        param(6) = New SqlParameter("@deptid ", SqlDbType.Char)       '@deptid      varchar(6),   --部門編號
        If CobDept.Text <> "ALL" Then
            param(6).Value = Getid(Me.CobDept.Text).Trim
        Else
            param(6).Value = "%"
        End If


        Dim ppid As String = ""
        param(7) = New SqlParameter("@ppid", SqlDbType.Char)       '@ppid        varchar(35),  --條碼序號   改成批量扫面（20140703modified by xuewei）
        If CobPPID.Text <> "" Then
            ' param(7).Value = Me.CobPPID.Text
            If CobPPID.Lines.Length > 0 Then
                Dim ii As Integer = 0
                For ii = 0 To CobPPID.Lines.Length - 1
                    If CobPPID.Lines(ii).ToString.Trim = "" Then
                        Continue For
                    Else
                        ppid = ppid + CobPPID.Lines(ii).ToString.Trim + ","
                    End If
                Next
                ' Dim line1 As String = Me.CobPPID.Lines(0)
            End If
            ' Sqlstr = Sqlstr & " and  a.Exppid='" & CobPPID.Text & "'"
            ppid = ppid.Substring(0, ppid.Length - 1)
            param(7).Value = ppid

        Else
            param(7).Value = "%"
        End If

        param(8) = New SqlParameter("@cusid", SqlDbType.Char)     '@cusid       varchar(6),   --客戶編號
        If Me.CobCus.Text <> "ALL" Then
            param(8).Value = Getid(CobCus.Text)
        Else
            param(8).Value = "%"
        End If


        param(9) = New SqlParameter("@lineid", SqlDbType.NChar)    '@lineid      varchar(6)    --線別編號
        If Me.CoboLine.Text <> "ALL" Then
            param(9).Value = Getid(Me.CoboLine.Text)
        Else
            param(9).Value = "%"
        End If

        param(10) = New SqlParameter("@stationtype ", SqlDbType.Char)       '@stationtype      varchar(6),   --站点类型 制程/包装
        If cboStationType.Text <> "ALL" Then
            param(10).Value = Getid(Me.cboStationType.Text).Trim
        Else
            param(10).Value = "%"
        End If

        param(11) = New SqlParameter("@stationtype ", SqlDbType.Char)
        param(11).Value = VbCommClass.VbCommClass.profitcenter
        param(12) = New SqlParameter("@CartonId", SqlDbType.Char)
        If String.IsNullOrEmpty(Me.txtCartonId.Text.Trim) Then
            param(12).Value = "%"
        Else
            param(12).Value = Me.txtCartonId.Text.Trim
        End If
        Try
            '修改原存储过程 m_QueryScanRecord_pnew 改成使用m_QueryScanRecords_p 从而可以调用历史库数据，
            'DtCtScan = ObjDB.GetDataTable("execute m_QueryScanRecords_p @begintime,@endtime,@typeid,@factoryid,@moid,@partid,@deptid,@ppid,@cusid,@lineid ", param)
            'exec(m_QueryScanRecords_p) '2014/05/13 10:00:00','2014/05/13 17:00:00',1,'KSLANTO','%','%','%','DLC42030ZEVFJP8BV','Cus030','%'
            'o_strSQL = "EXEC m_QueryScanRecords_p '" & param(0).Value & "','" & param(1).Value & "'," & param(2).Value.ToString & ",'" & param(3).Value & "','" & param(4).Value & "','" & param(5).Value & "','" & param(6).Value & "','" & param(7).Value & "','" & param(8).Value & "','" & param(9).Value & "' ,'" & param(10).Value & "' "

            '关晓艳测试修改查询单个删除条码
            o_strSQL = "EXEC m_QueryScanRecords_p '" & param(0).Value & "','" & param(1).Value & "'," & param(2).Value.ToString & ",'" & param(3).Value & "','" & param(4).Value & "','" & param(5).Value & "','" & param(6).Value & "','" & param(7).Value & "','" & param(8).Value & "','" & param(9).Value & "' ,'" & param(10).Value & "','" & param(11).Value & "','" & param(12).Value & "' "
            DtCtScan = DbOperateReportUtils.GetDataTable(o_strSQL)

            ToolCount.Text = DtCtScan.Rows.Count.ToString()
            ColsName = ColsText.Split("|")
            DgMoData.DataSource = DtCtScan
            For i = 0 To DgMoData.Columns.Count - 1
                DgMoData.Columns(i).HeaderText = ColsName(i)
                DgMoData.Columns(i).Name = ColsName(i)
            Next
            DgMoData.Refresh()
            DtCtScan.Dispose()
            'ObjDB.PubConnection.Close()
        Catch ex As Exception
            'ObjDB.PubConnection.Close()
        End Try
    End Sub

    Private Sub CobDept_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobDept.DropDownClosed
        LoadLineIDToCombo(CoboLine, Getid(CobDept.Text))
    End Sub

    Private Function CheckCondition() As Boolean
        If CobPPID.Text = "ALL" And CobMo.Text = "ALL" And CobPart.Text = "ALL" _
           And CobDept.Text = "ALL" And CobCus.Text = "ALL" And CoboLine.Text = "ALL" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CobPPID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DgMoData.DataSource = ""
        Me.ToolCount.Text = "0"
    End Sub

    Private Function GetQueryCondition() As String
        Dim str As String
        str = "起始時間:" & DtStar.Value.ToString() & "至" & DtEnd.Value.ToString() & "  " & "工廠別:" & CobFactory.Text & "  " _
            & "料件編號:" & CobPart.Text & "  " & "線別:" & CoboLine.Text _
            & "產品條碼:" & CobPPID.Text & "  " & "部門編號:" & CobDept.Text & "  " & "狀態:" & CobStatus.Text _
            & "工單編號:" & CobMo.Text & "  " & "客戶名稱:" & CobCus.Text
        Return str
    End Function

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        'ObjDB.InportInExcel(strSaveSql, "掃描記錄查詢", DgMoData, GetQueryCondition)
        ' LoadDataToOpExcel("掃描記錄查詢", DgMoData, "")
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub

    '2009-08-30 by tangxiang ----
#Region "Enter-->Tab"

    Private Sub CoboLine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub DtStar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

#End Region

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.SplitContainer1.Panel2Collapsed = True
    End Sub


    Private Sub ToolReflsh111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh111.Click
        Me.SplitContainer1.Panel2Collapsed = False
    End Sub

    Private Sub DgMoData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellContentClick
        If CobStatus.SelectedIndex = 0 Then

            Dim MyTable As DataTable
            Dim custid As String = IIf(IsDBNull(DgMoData.CurrentRow.Cells(3).Value), "", DgMoData.CurrentRow.Cells(3).Value)
            Dim SqlString As String = "select exppid 成品条码,ppid 部件条码,stationid 站点编号,partid 成品料号,Intime 扫描日期  from dbo.m_ppidlink_t where exppid='" & Me.DgMoData.CurrentRow.Cells(3).Value.ToString.Trim & "'"
            If Not String.IsNullOrEmpty(custid) Then
                SqlString = SqlString + " Union SELECT PPID 成品条码, '' 部件条码, B.TestTypeName  站点编号,  MATERIAL 成品料号, A.intime 扫描日期 FROM MESDataCenter.dbo.m_TestResult_t A ,MESDataCenter.dbo.m_TestType_t  B where ppid IN ('" & custid & "','" & Me.DgMoData.CurrentRow.Cells(3).Value & "') AND A.stationid =b.TestTypeID "
            End If
            SqlString = SqlString + " ORDER BY Intime"
            MyTable = DbOperateReportUtils.GetDataTable(SqlString)
            Me.DataGridView1.DataSource = MyTable

            Dim MyLotTable As DataTable
            Dim Sqlstr As String = " select a.CableSN,a.intime,b.CustPart,b.TypeDest,a.LineSn,case b.PartCode  when 'B141' then 'D01-5FT-01A' else 'D01-5FT-01A' end, " & _
           " '','',b.Supplierid,SUBSTRING(LineSn,12,4),'A','',b.PartCode from M_LineReadSn_t a   " & _
        " join m_PartContrast_t c on a.partid=c.TAvcPart " & _
        " join m_PartContrast_t b on a.partid=b.pavcpart  and isnull(b.Isasseble,'')='Y' and c.IsUpload='Y' where a.CableSN='" & Me.DgMoData.CurrentRow.Cells(3).Value.ToString.Trim & "'  union  " & _
        " select  a.CableSN,a.intime,b.tavcpart,b.TypeDest,'',case b.PartCode  when 'B141' then 'D01-5FT-01A' else 'D01-5FT-01A' end,  " & _
        " f.Lotid,'',b.Supplierid,SUBSTRING(LineSn,12,4),'A','',c.PartCode from M_LineReadSn_t a  " & _
        " join m_Mainmo_t e on a.Partid=e.PartID and a.moid=e.moid  join m_PartContrast_t b on e.partid=b.pavcpart   " & _
        " join m_PartContrast_t c on e.partid=c.TAvcPart join M_PCBLot_t f on e.Moid=f.Moid and a.PartID=f.Ppartid and f.Partid=b.TAvcPart and isnull(f.IsNew,'')='Y'   " & _
        " where   b.TAvcPart<>b.PAvcPart and isnull(c.IsUpload,'')='Y' and b.TypeDest<>'E75 Plug' and a.CableSN='" & Me.DgMoData.CurrentRow.Cells(3).Value.ToString.Trim & " ' " & _
        " union select VPPID,intime,'','USB LOT',PPID,'','','','','','','','' from M_AssemblyLotSn_t where VPPID='" & Me.DgMoData.CurrentRow.Cells(3).Value.ToString.Trim & " '"
            MyLotTable = DbOperateReportUtils.GetDataTable(Sqlstr)
            Me.DgLot.DataSource = MyLotTable

        End If

    End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click



    'End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub
End Class