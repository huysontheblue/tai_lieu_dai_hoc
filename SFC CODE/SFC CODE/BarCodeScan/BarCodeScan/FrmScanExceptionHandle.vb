
'--产品扫描异常处理
'--Create by :　马锋
'--Create date :　2015/06/29
'--Update date :  
'--
'--Ver : V01

Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports MainFrame

Public Class FrmScanExceptionHandle

    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    Private g_Factory As String

    Private Sub FrmScanQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        DgScanData.AutoGenerateColumns = False
        toolsProductDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsProductDelete.Tag) = "YES", True, False))
        toolsMODelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsMODelete.Tag) = "YES", True, False))
        toolsProductUnDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsProductUnDelete.Tag) = "YES", True, False))
        toolsMOUnDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsMOUnDelete.Tag) = "YES", True, False))
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        'FillComboLine(CobMo)
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        Me.DgScanData.AutoGenerateColumns = False
        Me.ActiveControl = Me.CobMo
    End Sub

#Region "菜单事件"

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        SetMessage("", False)
        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            If Not CheckDate() Then
                Exit Sub
            End If

            ShowData()
        Catch
            SetMessage("查询异常", False)
        End Try
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        'SetMessage("", False)
        'If Me.DgScanData.RowCount < 1 Then Exit Sub

        'add by 马跃平 2018-12-19
        If CobFactory.Text <> "" Then
            g_Factory = GetFactoryCode(CobFactory.Text)
        Else
            g_Factory = ""
        End If
        ShowData()
        Dim ay() As String = {"客户名称", "部门编号", "线别", "条码", "扫描状态", "扫描工站编号", "扫描工站名称", "工单", "料号", "电脑名称", "扫描工号", "扫描时间", "是否维修", "主条码", "Pigtail条码", "Cap条码", "PCBA条码", "checkcode"}
        VbCommClass.NPOIExcle.DataTableExportToExcle(dtOutPut, ay, "制程扫描异常作业" + Date.Now.ToString("yyyyMMdd") + ".xls")
        'LoadDataToExcel(Me.DgScanData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub toolsMODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolsMODelete.Click
        '按工单删除
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要删除数据", False)
            Return
        End If

        '凃美超修改 增加删除原因
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim())) Then
            MessageBox.Show("请填写删除原因")
            Me.txtDeReason.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("moid").Value.ToString.Trim)) Then
            SetMessage("选择删除工单不能为空!", False)
            Return
        End If

        If (MsgBox("你确定删除该工单成品扫描记录（该功能只适合删除非装配工站扫描记录删除）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If

        Dim drGetResult As SqlDataReader = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            Dim deleteReason As String
            deleteReason = Me.txtDeReason.Text.ToString.Replace("'", "''")

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "1"
            Dim h As DataTable = Conn.GetDataTable("select *FROM m_Carton_t  WHERE Moid='" + strMOId + "' ")
            If (h.Rows.Count >= 1) Then
                MessageBox.Show("清除工单失败！该工单存在包装记录无法删除", "请核实", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "',N'" & deleteReason & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            'Dim drGetSQLRecor As SqlDataReader = Conn.GetDataReader(strSQL)
            'If drGetSQLRecor.HasRows Then
            '    drGetSQLRecor.Read()
            '    Select Case drGetSQLRecor(0).ToString()
            '        Case "0"
            '            SetMessage(drGetSQLRecor(1).ToString(), False)
            '        Case "1"
            '            SetMessage("删除成功!", True)
            '    End Select
            'End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(dt.Rows(0)(1).ToString(), False)
                    Case "1"
                        SetMessage("删除成功!", True)
                End Select
            End If

            drGetResult = Nothing
            Conn.PubConnection.Close()

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            drGetResult.Close()
            Conn.PubConnection.Close()
            SetMessage("删除异常", False)
        End Try
    End Sub

    Private Sub toolsProductDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolsProductDelete.Click
        Dim blnDeleteOK As Boolean = False
        '按选择产品删除
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要删除数据", False)
            Return
        End If

        '凃美超修改 增加删除原因
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim())) Then
            MessageBox.Show("请填写删除原因")
            Me.txtDeReason.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString.Trim)) Then
            SetMessage("选择删除产品条码不能为空！", False)
            Return
        End If

        If (MsgBox("你确定删除该产品选择工站扫描记录（该功能只适合删除非装配工站扫描记录删除）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If
        Dim drGetResult As SqlDataReader = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            Dim deleteReason As String
            deleteReason = Me.txtDeReason.Text.ToString.Replace("'", "''")

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "0"
            Dim h As DataTable = Conn.GetDataTable("select *FROM m_Cartonsn_t  WHERE ppid='" + strBarCode + "'")
            If (h.Rows.Count >= 1) Then
                MessageBox.Show("你要删除的产品在包装已经扫描，请先删除包装记录", "请核实", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "',N'" & deleteReason & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        blnDeleteOK = False
                        'SetMessage(dt.Rows(0)(1).ToString(), False)
                    Case "1"
                        blnDeleteOK = True
                        ' SetMessage("删除成功!", True)
                End Select
            End If
            ToolReflsh_Click(Nothing, Nothing)
            If blnDeleteOK = True Then
                ToolReflsh_Click(Nothing, Nothing)
                SetMessage("删除成功!", True)

            Else
                SetMessage(dt.Rows(0)(1).ToString(), False)
            End If
        Catch ex As Exception
            SetMessage("删除异常", False)
        End Try
    End Sub

    Private Sub toolsCancelRepair_Click(sender As Object, e As EventArgs) Handles toolsCancelRepair.Click
        '按选择取消维修产品
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要维修产品数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString.Trim)) Then
            SetMessage("选择要已维修产品条码不能为空！", False)
            Return
        End If

        If (Me.DgScanData.CurrentRow.Cells("colRepaired").Value.ToString.Trim.ToUpper = "N") Then
            SetMessage("产品为已为非维修产品，请重新选择！", False)
            Return
        End If

        If (MsgBox("你确定要把产品条码取消维修标记？", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If

        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "3"

            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(dt.Rows(0)(1).ToString(), False)
                    Case "1"
                        SetMessage("取消维修成功!", True)
                End Select
            End If

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("处理异常", False)
        End Try
    End Sub
    Private Sub toolsRepair_Click(sender As Object, e As EventArgs) Handles toolsRepair.Click
        '按选择标记维修产品
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要标记维修产品数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString.Trim)) Then
            SetMessage("选择要标记维修产品条码不能为空！", False)
            Return
        End If

        If (Me.DgScanData.CurrentRow.Cells("colRepaired").Value.ToString.Trim.Trim = "Y") Then
            SetMessage("产品为已为维修产品，请重新选择！", False)
            Return
        End If

        If (MsgBox("你确定要把产品条码标记为维修产品？", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If

        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "2"

            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(dt.Rows(0)(1).ToString(), False)
                    Case "1"
                        SetMessage("标记维修成功!", True)
                End Select
            End If

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("处理异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub DgMoData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim MyTable As DataTable
            Dim SqlString As String = "select exppid 成品条码,ppid 部件条码,stationid 站点编号,partid 成品料号  from dbo.m_ppidlink_t where exppid='" & Me.DgScanData.CurrentRow.Cells(3).Value.ToString.Trim & "'"
            MyTable = DbOperateUtils.GetDataTable(SqlString)
            Me.DgScanData.DataSource = MyTable

            Dim MyLotTable As DataTable
            Dim Sqlstr As String = " select a.CableSN,a.intime,b.CustPart,b.TypeDest,a.LineSn,case b.PartCode  when 'B141' then 'D01-5FT-01A' else 'D01-5FT-01A' end, " & _
                " '','',b.Supplierid,SUBSTRING(LineSn,12,4),'A','',b.PartCode from M_LineReadSn_t a   " & _
                " join m_PartContrast_t c on a.partid=c.TAvcPart " & _
                " join m_PartContrast_t b on a.partid=b.pavcpart  and isnull(b.Isasseble,'')='Y' and c.IsUpload='Y' where a.CableSN='" & Me.DgScanData.CurrentRow.Cells(3).Value.ToString.Trim & "'  union  " & _
                " select  a.CableSN,a.intime,b.tavcpart,b.TypeDest,'',case b.PartCode  when 'B141' then 'D01-5FT-01A' else 'D01-5FT-01A' end,  " & _
                " f.Lotid,'',b.Supplierid,SUBSTRING(LineSn,12,4),'A','',c.PartCode from M_LineReadSn_t a  " & _
                " join m_Mainmo_t e on a.Partid=e.PartID and a.moid=e.moid  join m_PartContrast_t b on e.partid=b.pavcpart   " & _
                " join m_PartContrast_t c on e.partid=c.TAvcPart join M_PCBLot_t f on e.Moid=f.Moid and a.PartID=f.Ppartid and f.Partid=b.TAvcPart and isnull(f.IsNew,'')='Y'   " & _
                " where   b.TAvcPart<>b.PAvcPart and isnull(c.IsUpload,'')='Y' and b.TypeDest<>'E75 Plug' and a.CableSN='" & Me.DgScanData.CurrentRow.Cells(3).Value.ToString.Trim & " ' " & _
                " union select VPPID,intime,'','USB LOT',PPID,'','','','','','','','' from M_AssemblyLotSn_t where VPPID='" & Me.DgScanData.CurrentRow.Cells(3).Value.ToString.Trim & " '"
            MyLotTable = DbOperateUtils.GetDataTable(Sqlstr)
            Me.DgScanData.DataSource = MyLotTable

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "函数"

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

    Public Function CheckDate()
        If DtStar.Value > Me.DtEnd.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
            DtEnd.Value = Now()
            Return False
        End If

        If DtStar.Value < "2007-01-01" Then
            MsgBox("起始時間不能小於2007-01-01!", 48, "提示")
            DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        Dim startDate As DateTime = DateTime.Parse(DtStar.Text)
        Dim endDate As DateTime = DateTime.Parse(DtEnd.Text)

        If startDate.AddMonths(2) < endDate Then
            MsgBox("查询时间相隔最多请不要超过2天", 48, "提示")
            Me.DtStar.Value = DateAdd(DateInterval.Month, -1, endDate)
            Return False
        End If

        If (String.IsNullOrEmpty(Me.CobFactory.Text.Trim())) Then
            MsgBox("请选择工厂", 48, "提示")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.CobMo.Text.Trim()) And String.IsNullOrEmpty(Me.CobPPID.Text.Trim())) Then
            MsgBox("请输入查询条件", 48, "提示")
            Return False
        End If

        Return True
    End Function

    '定义导出Excel数据源
    Dim dtOutPut As DataTable = New DataTable()

    Private Sub ShowData()
        Dim StartDT, EndDT As String
        Dim DtCtScan As DataTable

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim param(9) As SqlParameter
        param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --起始時間
        param(0).Value = StartDT
        param(1) = New SqlParameter("@endtime", SqlDbType.Char)      '@endtime     varchar(25),  --終止時間
        param(1).Value = EndDT
        param(2) = New SqlParameter("@typeid", SqlDbType.Char)       '@typeid      varchar(1),   --狀態（1：正常掃描；2：錯誤掃描）
        param(2).Value = "1"

        param(3) = New SqlParameter("@factoryid", SqlDbType.Char)  '@factoryid   varchar(2),   --公司別
        param(3).Value = g_Factory

        param(4) = New SqlParameter("@moid", SqlDbType.Char)    '@moid        varchar(12),  --工單編號
        If Me.CobMo.Text <> "ALL" And Me.CobMo.Text.Trim <> "" Then
            param(4).Value = Me.CobMo.Text
        Else
            param(4).Value = "%"
        End If

        param(5) = New SqlParameter("@partid", SqlDbType.Char)   '@partid      varchar(20),  --料件編號
        param(5).Value = "%"

        param(6) = New SqlParameter("@deptid ", SqlDbType.Char)       '@deptid      varchar(6),   --部門編號
        param(6).Value = "%"

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
        param(8).Value = "%"

        param(9) = New SqlParameter("@lineid", SqlDbType.NChar)    '@lineid      varchar(6)    --線別編號
        param(9).Value = "%"

        Dim ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()

        Try
            '修改原存储过程 m_QueryScanRecord_pnew 改成使用m_QueryScanRecords_p 从而可以调用历史库数据，
            'DtCtScan = ObjDB.GetDataTable("execute m_QueryScanRecords_p @begintime,@endtime,@typeid,@factoryid,@moid,@partid,@deptid,@ppid,@cusid,@lineid ", param)
            'exec(m_QueryScanRecords_p) '2014/05/13 10:00:00','2014/05/13 17:00:00',1,'KSLANTO','%','%','%','DLC42030ZEVFJP8BV','Cus030','%'
            Dim s As String = ""
            If Me.chkIsDelete.Checked = True Then
                DtCtScan = DbOperateReportUtils.GetDataTable("exec m_QueryScanRecordsOfDeleted_p '" & param(0).Value & "','" & param(1).Value & "'," & param(2).Value.ToString & ",'" & param(3).Value & "','" & param(4).Value & "','" & param(5).Value & "','" & param(6).Value & "','" & param(7).Value & "','" & param(8).Value & "','" & param(9).Value & "','%' ,'%','%' ")
            Else
                DtCtScan = DbOperateReportUtils.GetDataTable("exec m_QueryScanRecords_p '" & param(0).Value & "','" & param(1).Value & "'," & param(2).Value.ToString & ",'" & param(3).Value & "','" & param(4).Value & "','" & param(5).Value & "','" & param(6).Value & "','" & param(7).Value & "','" & param(8).Value & "','" & param(9).Value & "','%' ,'%','%' ")
            End If
            dtOutPut = DtCtScan
            If (DtCtScan Is Nothing) Then
                ToolCount.Text = DtCtScan.Rows.Count.ToString()
            Else
                ToolCount.Text = DtCtScan.Rows.Count.ToString()
                DgScanData.DataSource = DtCtScan
                DgScanData.Refresh()
                DtCtScan.Dispose()
            End If

            'ObjDB.PubConnection.Close()
        Catch ex As Exception
            'ObjDB.PubConnection.Close()
        End Try

    End Sub

    Private Function GetQueryCondition() As String
        Dim str As String
        str = "起始時間:" & DtStar.Value.ToString() & "至" & DtEnd.Value.ToString() & "  " & "工廠別:" & CobFactory.Text & "  " _
            & "產品條碼:" & CobPPID.Text & "  " & "工單編號:" & CobMo.Text
        Return str
    End Function

    Private Sub SetMessage(ByVal Message As String, ByVal Type As Boolean)
        If (Type) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub
#End Region

    ''' <summary>
    ''' 恢复删除的数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolsProductUnDelete_Click(sender As Object, e As EventArgs) Handles toolsProductUnDelete.Click
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要恢复的数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString.Trim)) Then
            SetMessage("选择恢复产品条码不能为空！", False)
            Return
        End If

        If (MsgBox("你确定恢复该产品选择工站扫描记录（该功能只适合恢复非装配工站扫描记录）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If
        Dim drGetResult As DataTable = Nothing

        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "0"
            Dim h As DataTable = DbOperateUtils.GetDataTable("select * FROM m_Cartonsn_t  WHERE ppid='" + strBarCode + "'")
            If (h.Rows.Count >= 1) Then
                MessageBox.Show("你要恢复的产品在包装已经扫描，不允许恢复", "请核实", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle_UnDelete @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'," & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count = 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString(), False)
                    Case "1"
                        SetMessage("恢复成功!", True)
                End Select
            End If

            drGetResult = Nothing

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("恢复删除异常", False)
        End Try
    End Sub

    '按工单恢复
    Private Sub toolsMOUnDelete_Click(sender As Object, e As EventArgs) Handles toolsMOUnDelete.Click

        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要恢复数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("moid").Value.ToString.Trim)) Then
            SetMessage("选择恢复工单不能为空!", False)
            Return
        End If

        If (MsgBox("你确定恢复该工单成品扫描记录（该功能只适合恢复非装配工站扫描记录）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If

        Dim drGetResult As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "1"
            Dim h As DataTable = DbOperateUtils.GetDataTable("select * FROM m_Carton_t  WHERE Moid='" + strMOId + "' ")
            If (h.Rows.Count >= 1) Then
                MessageBox.Show("恢复工单失败！该工单存在包装记录无法恢复", "请核实", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_ScanExceptionHandle_UnDelete @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString(), False)
                    Case "1"
                        SetMessage("恢复成功!", True)
                End Select
            End If

            drGetResult = Nothing

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("恢复异常", False)
        End Try
    End Sub
End Class