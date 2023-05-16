Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports LXWarehouseManage
Imports System.Drawing
Imports System.Web
Imports System.Text
Imports System.IO

#Region "Old"
'
'Public Class FrmLotScan
'    Private Shared rowSpan As New SortedList()
'    Private Shared rowValue As String = ""
'    Dim scanP As New ScanParam
'    Dim cellValue As String = ""
'    Dim totalQty As Integer = 0
'    ''' <summary>
'    ''' 当前
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Enum LotStatus
'        Waiting '等待扫描
'        Scaning '扫描进行中
'        Done    '扫描完成
'    End Enum
'    ''' <summary>
'    ''' 功能条码类别
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Enum FunctionSNType
'        WO      '工单条码
'        Station '工站条码
'        UserID  '工号条码
'    End Enum

'#Region "属性"

'#Region "扫描状态"
'    Private _scanStatus As LotStatus
'    Public Property ScanStatus() As LotStatus
'        Get
'            Return _scanStatus
'        End Get
'        Set(ByVal value As LotStatus)
'            _scanStatus = value
'        End Set
'    End Property
'#End Region

'#Region "条码类型"
'    Private _SNType As FunctionSNType
'    Public Property SNType() As FunctionSNType
'        Get
'            Return _SNType
'        End Get
'        Set(ByVal value As FunctionSNType)
'            _SNType = value
'        End Set
'    End Property
'#End Region

'#Region "扫描步骤"
'    Private _scanStep As Integer
'    Public Property ScanStep() As Integer
'        Get
'            Return _scanStep
'        End Get
'        Set(ByVal value As Integer)
'            _scanStep = value
'        End Set
'    End Property
'#End Region

'#Region "功能条码"
'    Private _fnCode As Integer
'    Public Property FunctionCodeId() As Integer
'        Get
'            Return _fnCode
'        End Get
'        Set(ByVal value As Integer)
'            _fnCode = value
'        End Set
'    End Property
'#End Region

'#Region "员工工号"
'    Private _userId As String
'    Public Property ScanerUserId() As String
'        Get
'            Return _userId
'        End Get
'        Set(ByVal value As String)
'            _userId = value
'        End Set
'    End Property
'#End Region

'#Region "IPQC工号"
'    Private _ipqcId As String
'    Public Property IpqcUserId() As String
'        Get
'            Return _ipqcId
'        End Get
'        Set(ByVal value As String)
'            _ipqcId = value
'        End Set
'    End Property
'#End Region

'#Region "员工姓名"
'    Private _userName As String
'    Public Property ScanerUserName() As String
'        Get
'            Return _userName
'        End Get
'        Set(ByVal value As String)
'            _userName = value
'        End Set
'    End Property
'#End Region

'#Region "IPQC姓名"
'    Private _ipqcName As String
'    Public Property IpqcUserName() As String
'        Get
'            Return _ipqcName
'        End Get
'        Set(ByVal value As String)
'            _ipqcName = value
'        End Set
'    End Property
'#End Region

'#Region "工站ID"
'    Private _stationId As Integer
'    Public Property StationId() As Integer
'        Get
'            Return _stationId
'        End Get
'        Set(ByVal value As Integer)
'            _stationId = value
'        End Set
'    End Property
'#End Region

'#Region "工站序号"
'    Private _stationSQ As Integer
'    Public Property StationSQ() As Integer
'        Get
'            Return _stationSQ
'        End Get
'        Set(ByVal value As Integer)
'            _stationSQ = value
'        End Set
'    End Property
'#End Region

'#Region "工站名称"
'    Private _stationName As String
'    Public Property StationName() As String
'        Get
'            Return _stationName
'        End Get
'        Set(ByVal value As String)
'            _stationName = value
'        End Set
'    End Property
'#End Region

'#Region "序列号"
'    Private _sn As String
'    Public Property SerialNumber() As String
'        Get
'            Return _sn
'        End Get
'        Set(ByVal value As String)
'            _sn = value
'        End Set
'    End Property
'#End Region

'#Region "工单编号"
'    Private _workOrder As String
'    Public Property WorkOrder() As String
'        Get
'            Return _workOrder
'        End Get
'        Set(ByVal value As String)
'            _workOrder = value
'        End Set
'    End Property
'#End Region

'#Region "配置数"
'    Private _configQty As String
'    Public Property ConfigQty() As String
'        Get
'            Return _configQty
'        End Get
'        Set(ByVal value As String)
'            _configQty = value
'        End Set
'    End Property
'#End Region

'#Region "料件ID"
'    Private _partId As Integer
'    Public Property PartId() As Integer
'        Get
'            Return _partId
'        End Get
'        Set(ByVal value As Integer)
'            _partId = value
'        End Set
'    End Property
'#End Region

'#Region "工单料号"
'    Private _woPn As String
'    Public Property WoPn() As String
'        Get
'            Return _woPn
'        End Get
'        Set(ByVal value As String)
'            _woPn = value
'        End Set
'    End Property
'#End Region

'#Region "工单数量"
'    Private _woQty As Integer
'    Public Property WoQty() As Integer
'        Get
'            Return _woQty
'        End Get
'        Set(ByVal value As Integer)
'            _woQty = value
'        End Set
'    End Property
'#End Region

'#End Region

'    Private Sub FrmLotScan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'        If Not dt Is Nothing Then
'            dt.Dispose()
'            dt = Nothing
'        End If
'    End Sub

'    Private Sub FrmLotScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        '
'        IniteScan()
'        '
'        Me.lblPass.Text = ""
'        Me.dgvScanTask.AutoGenerateColumns = False

'        ShowSampleChart()

'        Panel2Hide()
'        '
'        'Me.PictureBox1.Visible = False
'        'Me.Chart1.Visible = False
'        'ShowChart()

'    End Sub

'    Private Sub Panel2Hide()
'        For Each con As Control In Panel2.Controls
'            con.Visible = False
'        Next
'    End Sub
'    Private Sub Panel2Show()
'        For Each con As Control In Panel2.Controls
'            con.Visible = True
'        Next
'    End Sub

'#Region "加载扫描数据"
'    Private Sub LoadScaningData(ByVal userId As String)
'        Dim DAL As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            DAL = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim strSql As String = "select ROW_NUMBER() OVER(ORDER BY UN.INTIME DESC) 序号, UN.WorkOrder 工单,PN.PartNumber 料件编号," & _
'                                "ST.StationName 工站,ISNULL(SP.QTY,UN.Qty) 生产数量,ISNULL(SP.USERID,UN.UserID) 工号,US.UserName 姓名 ,UN.InTime 扫描时间,'' 备注 " & _
'                                "from m_LotUnit_t(nolock) UN LEFT JOIN M_LOTSPLIT_T SP ON UN.ID=SP.LOTUNITID " & _
'                                "join m_PartNumber_t(nolock) PN on UN.PartID=PN.ID " & _
'                                "join m_Station_t(nolock) ST on UN.StationID=ST.ID " & _
'                                "join m_Users_t(nolock) US on ISNULL(SP.USERID,UN.UserID)=US.UserID " & _
'                                "where ISNULL(SP.USERID,UN.UserID)='" & userId & "' and convert(nvarchar(50),UN.InTime,12)=convert(nvarchar(50),getdate(),12) " '& _
'            '"order by Un.InTime ;"
'            Dim sqlSummary As String = "select SUM(ISNULL(B.QTY,A.QTY)) TotalQty from m_LotUnit_t(nolock) A LEFT JOIN M_LOTSPLIT_T B ON A.ID=B.LOTUNITID " & _
'                                       "where ISNULL(B.USERID,A.UserID)='" & userId & "' and convert(nvarchar(50),A.InTime,12)=convert(nvarchar(50),getdate(),12);"
'            Dim ds As DataSet = DAL.GetDataSet(strSql & vbNewLine & sqlSummary)
'            If Not ds Is Nothing Then
'                Dim dt As DataTable = ds.Tables(0)
'                If dt.Rows.Count > 0 Then
'                    Dim dtSummary As DataTable = ds.Tables(1)
'                    If dtSummary.Rows.Count > 0 Then
'                        rowSpan.Clear()
'                        totalQty = CInt(dtSummary.Rows(0)(0).ToString)
'                        '添加一空行(汇总)
'                        dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
'                    End If
'                End If
'                dgvScaningData.DataSource = dt
'                dgvScaningData.Columns("备注").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
'                '禁止排序
'                For Each column As DataGridViewColumn In dgvScaningData.Columns
'                    column.SortMode = DataGridViewColumnSortMode.NotSortable
'                Next
'            End If

'        Catch ex As Exception
'            Throw
'        Finally
'            If Not DAL Is Nothing Then
'                DAL = Nothing
'            End If
'        End Try
'    End Sub
'#End Region

'#Region "作业扫描"
'    Private Function DoWorkScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String

'        Dim msg As String
'        '第一步：扫描工号
'        If Me.ScanStep = 1 Then

'            '校验功能条码
'            msg = VerifySnData(strInput, functionCodeId)
'            If msg <> "" Then
'                Return msg
'            End If
'            Me.ScanerUserId = strInput
'            '显示当天的扫描记录
'            LoadScaningData(Me.ScanerUserId)
'            '显示扫描任务
'            ShowScanTask(1)
'            '设置扫描进度
'            SetScanProcess(1)
'            '显示下一个扫描提示
'            ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))

'        ElseIf Me.ScanStep = 2 Then  '第二步：扫描工站条码

'            '显示条码格式
'            'Me.lblFormat.Text = "条码格式:" + GetSNFormat(2)
'            '校验工站条码格式
'            If CheckSNFormat(strInput, 2) = "" Then
'                Return "工站条码""" + strInput + """ 格式不正确"
'            End If
'            '显示该工位Sop
'            ShowSopImage()
'            '解析工站条码格式
'            ParseSnData(strInput)
'            '校验工站，流程卡，工单信息
'            msg = VerifySnData(strInput, 2)
'            If msg <> "" Then
'                Return msg
'            End If
'            '设置扫描进度
'            SetScanProcess(2)
'            '保存扫描数据
'            msg = SaveScanData(strInput)
'            If msg <> "" Then
'                ''显示工艺程流程图表
'                'ShowRunCardChart()
'                Return msg
'            End If
'            Me.lblPass.Text = "PASS"
'            '刷新显示
'            LoadScaningData(Me.ScanerUserId)
'            '初始化扫描
'            IniteScan()
'            Return ""
'        End If
'        Me.ScanStep = Me.ScanStep + 1
'        Return ""
'    End Function
'#End Region

'#Region "首检扫描"
'    Private Function DoFaiScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String
'        Dim msg As String

'        '第一步：扫描工站条码
'        If Me.ScanStep = 1 Then

'            '校验功能条码
'            msg = VerifySnData(strInput, functionCodeId)
'            If msg <> "" Then
'                Return msg
'            End If
'            ParseSnData(strInput)
'            Me.ShowSopImage()
'            If HasDoneFAI() Then
'                Return "已做过首检,请勿重复"
'            End If
'            '
'            ShowScanTask(2)
'            SetScanProcess(2)
'            ShowVerifyTask(Me.PartId, Me.StationId)
'            '
'            If Me.dgvVerifyTask.Rows.Count <= 0 Then
'                '跳过 第二步
'                Me.ScanStep = 2
'            End If
'            '显示下一个扫描提示
'            ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))

'        ElseIf Me.ScanStep = 2 Then '第二步:扫描线材料号或治具编号

'            '校验线材, 治具
'            msg = VerifyPn(strInput, Me.PartId, Me.StationId, Me.WoQty)
'            If msg <> "" Then
'                Return msg
'            End If
'            '设置扫描进度
'            SetVerifyProcess(strInput)
'            '"校验"是否完成
'            If VerifyIsFinish() Then
'                '显示下一个扫描提示
'                ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))
'            Else
'                Me.txtInput.Text = ""
'                Me.txtInput.Focus()
'                Return ""
'            End If

'        ElseIf Me.ScanStep = 3 Then '第三步:操作员确认

'            msg = VerifySnData(strInput, 1)
'            If msg <> "" Then
'                Return msg
'            End If
'            Me.ScanerUserId = strInput
'            '更新扫描进度
'            SetScanProcess(1)
'            '作业员确认
'            If OperatorIsConfirm() Then
'                '显示下一个扫描提示
'                ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))
'            Else
'                Me.txtInput.Text = ""
'                Me.txtInput.Focus()
'                Return ""
'            End If
'        ElseIf Me.ScanStep = 4 Then  '第三步:IPQC 确认

'            msg = VerifySnData(strInput, 4)
'            If msg <> "" Then
'                Return msg
'            End If
'            Me.IpqcUserId = strInput
'            '更新扫描进度
'            SetScanProcess(3)
'            'IPQC确认
'            If IpqcIsConfirm() Then
'                '保存数据
'                SaveFAIData()
'                Me.lblPass.Text = "PASS"
'                '初始化扫描
'                IniteScan()
'                Return ""
'            End If
'        End If
'        Me.ScanStep = Me.ScanStep + 1
'        Return ""
'    End Function



'#End Region

'#Region "工单扫描"
'    Private Function DoWoScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String

'        Me.dgvRunCard.Visible = True
'        Me.PictureBox1.Visible = False

'        ShowScanTask(Me.FunctionCodeId)
'        GetMoInfo(strInput)
'        Me.ConfigQty = GetMoConfigQty()
'        SetScanProcess(Me.FunctionCodeId)
'        '显示流程卡
'        'Me.dgvRunCard.Rows.Clear()
'        Me.dgvRunCard.DataSource = Nothing
'        Me.dgvRunCard.VirtualMode = False
'        ShowRunCard(strInput)
'        lblStandard.Text = ""
'        lblStationName.Text = "Working In Process"
'        pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
'        Return ""
'    End Function

'    Private Sub GetMoInfo(ByVal mo As String)
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT MOID,MOQTY,PARTID FROM M_MAINMO_T WHERE MOID='" & mo & "'"
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then
'                    Me.WoPn = dt.Rows(0)(2).ToString
'                    Me.WoQty = dt.Rows(0)(1).ToString
'                    Me.WorkOrder = dt.Rows(0)(0).ToString
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try

'    End Sub

'#End Region

'    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
'        Try
'            If Asc(e.KeyChar) = 13 Then
'                'Dim err As String = ""
'                'Me.lblPass.Text = ""
'                Dim strInput As String = txtInput.Text.Trim.ToUpper
'                'If String.IsNullOrEmpty(strInput) Then
'                '    Exit Sub
'                'End If
'                'If Me.ScanStep = 0 Then
'                '    '功能条码(m_FunctionCode_t)
'                '    Me.FunctionCodeId = Me.GetFunctionCodeID(strInput)
'                '    If Me.FunctionCodeId <= 0 Then
'                '        ShowError("功能条码格式不正确、请确认(udpGetFunctionID)!")
'                '        Exit Sub
'                '    End If
'                '    Me.ScanStep = Me.ScanStep + 1
'                'End If
'                'Select Case Me.FunctionCodeId
'                '    Case 1
'                '        err = DoWorkScaning(strInput, Me.FunctionCodeId)
'                '    Case 2
'                '        err = DoFaiScaning(strInput, Me.FunctionCodeId)
'                '    Case 3
'                '        err = DoWoScaning(strInput, Me.FunctionCodeId)
'                'End Select
'                'If err <> "" Then
'                '    ShowError(err)
'                '    Exit Sub
'                'End If
'                If String.IsNullOrEmpty(strInput.Trim) Then
'                    lblMsg.Text = "扫描错误，请确认！！"
'                    Exit Sub
'                End If
'                If strInput.ToUpper = "RESET" OrElse strInput.ToUpper = "SPLIT" Then
'                    FunctionAssign(strInput.ToUpper)
'                    Exit Sub
'                End If
'                CheckInputType(strInput)
'                txtInput.Text = ""
'                txtInput.Focus()
'            End If
'        Catch ex As Exception
'            txtInput.Text = ""
'            txtInput.Focus()
'            SysMessageClass.WriteErrLog(ex, "FrmLotScan", "txtInput_KeyPress", "WIPS")
'        End Try
'    End Sub

'#Region "ShowError"
'    Private Sub ShowError(ByVal err As String)
'        Me.lblMsg.Text = err
'        Me.lblPass.Text = ""
'        'Me.lblFormat.Text = ""
'        Me.txtInput.Text = ""
'        Me.txtInput.Focus()
'        'Me.ScanStatus = LotStatus.Waiting
'        'Me.lblTips.Text = "请扫描"
'        'Me.lblStationName.Text = "Working In Process System"
'        'Me.dgvScanTask.Rows.Clear()
'        'Me.dgvVerifyTask.Rows.Clear()
'    End Sub
'#End Region

'#Region "ShowTips"
'    Private Sub ShowTips(ByVal tips As String)
'        Me.lblTips.Text = tips
'        Me.txtInput.Text = ""
'        Me.txtInput.Focus()
'        Me.lblMsg.Text = ""
'        'Me.lblFormat.Text = ""
'    End Sub
'#End Region

'#Region "取工站名称"
'    Private Function GetTips(ByVal functionCodeId As Integer, ByVal scanStep As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select ScanTips from m_ScanTips_t(nolock) where FunctionCodeID=" & functionCodeId & " and ScanStep=" & scanStep
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Return dt.Rows(0)(0).ToString
'            End If
'        End Using
'        Return ""
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        'If reader.HasRows Then
'        '    reader.Read()
'        '    Return reader.Item(0).ToString()
'        'Else
'        '    reader.Close()
'        '    Return ""
'        'End If
'    End Function
'#End Region

'#Region "校验条码数据"
'    Private Function VerifySnData(ByVal sn As String, ByVal snType As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '参数定义
'        Dim param1 As New SqlParameter("@SerialNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input)
'        Dim param2 As New SqlParameter("@SnType", SqlDbType.Int, ParameterDirection.Input)
'        Dim param3 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
'        '参数赋值
'        param1.Value = sn
'        param2.Value = snType
'        param3.Direction = ParameterDirection.Output '?指定
'        param3.Value = Nothing
'        Dim Paramters As SqlParameter() = Nothing
'        Paramters = New SqlParameter() {param1, param2, param3}
'        '执行SP
'        Dim err As String = DAL.ExecuteNonQureyByProc("udpVerifySn", Paramters)

'        If err <> "" Then
'            Return err
'        Else
'            If TypeOf param3.Value Is DBNull Then
'                Return ""
'            Else
'                Return param3.Value.ToString()
'            End If
'        End If
'    End Function
'#End Region

'#Region "获取条码格式"
'    Private Function GetSNFormat(ByVal functionCodeId As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '参数定义
'        Dim param1 As New SqlParameter("@FunctionID", SqlDbType.Int, ParameterDirection.Input)
'        Dim param2 As New SqlParameter("@SNFormat", SqlDbType.NVarChar, 200)
'        '参数赋值
'        param1.Value = functionCodeId
'        param2.Direction = ParameterDirection.Output '?指定
'        param2.Value = Nothing
'        Dim Paramters As SqlParameter() = Nothing
'        Paramters = New SqlParameter() {param1, param2}
'        '执行SP
'        Dim err As String = DAL.ExecuteNonQureyByProc("udpGetSNFormat", Paramters)
'        If err <> "" Then
'            Return err
'        Else
'            If TypeOf param2.Value Is DBNull Then
'                Return ""
'            Else
'                Return param2.Value.ToString()
'            End If
'        End If
'    End Function

'#End Region

'#Region "校验条码格式"
'    Private Function CheckSNFormat(ByVal sn As String, ByVal functionCodeId As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '参数定义
'        Dim param1 As New SqlParameter("@Serialnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'        Dim param2 As New SqlParameter("@FunctionID", SqlDbType.Int, ParameterDirection.Input)
'        Dim param3 As New SqlParameter("@SNFormat", SqlDbType.NVarChar, 200)
'        '参数赋值
'        param1.Value = sn
'        param2.Value = functionCodeId
'        param3.Direction = ParameterDirection.Output '?指定
'        param3.Value = Nothing
'        Dim Paramters As SqlParameter() = Nothing
'        Paramters = New SqlParameter() {param1, param2, param3}
'        '执行SP
'        Dim err As String = DAL.ExecuteNonQureyByProc("udpCheckSNFormat", Paramters)
'        If err <> "" Then
'            Return err
'        Else
'            If TypeOf param3.Value Is DBNull Then
'                Return ""
'            Else
'                Return param3.Value.ToString()
'            End If
'        End If
'    End Function

'#End Region

'#Region "保存扫描数据"
'    Private Function SaveScanData(ByVal sn As String) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '参数定义
'        Dim param1 As New SqlParameter("@SerialNumber ", SqlDbType.NVarChar, 200, ParameterDirection.Input)
'        Dim param2 As New SqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input)
'        Dim param3 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
'        '参数赋值
'        param1.Value = sn
'        param2.Value = Me.ScanerUserId
'        param3.Direction = ParameterDirection.Output '?指定
'        param3.Value = Nothing
'        Dim Paramters As SqlParameter() = Nothing
'        Paramters = New SqlParameter() {param1, param2, param3}
'        '执行SP
'        Dim err As String = DAL.ExecuteNonQureyByProc("udpSaveScanData", Paramters)
'        If err <> "" Then
'            Return err
'        Else
'            If TypeOf param3.Value Is DBNull Then
'                Return ""
'            Else
'                Return param3.Value.ToString()
'            End If
'        End If
'    End Function

'#End Region

'#Region "取工站名称"
'    Private Function GetStationNameById(ByVal stationId As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select top 1 StationName from m_Station_t(nolock) where ID='" & stationId & "'"
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Return dt.Rows(0)(0).ToString
'            End If
'        End Using
'        Return ""
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        'If reader.HasRows Then
'        '    reader.Read()
'        '    Return reader.Item(0).ToString()
'        'Else
'        '    reader.Close()
'        '    Return ""
'        'End If
'    End Function
'#End Region

'#Region "获取用户名"
'    Private Function GetUserNameById(ByVal userId As String) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select top 1 UserName from m_Users_t(nolock) where UserID='" & userId & "'"
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Return dt.Rows(0)(0).ToString
'            End If
'        End Using
'        Return ""
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        'If reader.HasRows Then
'        '    reader.Read()
'        '    Return reader.Item(0).ToString()
'        'Else
'        '    reader.Close()
'        '    Return ""
'        'End If
'    End Function
'#End Region

'#Region "解析工单"
'    Private Sub ParseWorkOrder(ByVal wo As String)
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select top 1 PartID,Moqty from m_Mainmo_t(nolock) where Moid='" & wo & "'"
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Me.WoPn = dt.Rows(0)(0).ToString
'                Me.WoQty = dt.Rows(0)(1).ToString
'            End If
'        End Using
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        'If reader.HasRows Then
'        '    reader.Read()
'        '    Me.WoPn = reader.Item(0).ToString()
'        '    Me.WoQty = reader.Item(1).ToString()
'        'End If
'    End Sub
'#End Region

'#Region "是否已做过首检"
'    Private Function HasDoneFAI() As Boolean
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select top 1 1 from m_LotUnitFAI_t(nolock) where SerialNumber='" & Me.SerialNumber & "' and PartID=" & Me.PartId & " and StationID=" & Me.StationId
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Return True
'            Else
'                Return False
'            End If
'        End Using
'    End Function
'#End Region

'#Region "读取工站条码数据"
'    Private Sub ParseSnData(ByVal sn As String)
'        '条码格式:F/WorkId/PartId/StationId
'        Me.SerialNumber = sn
'        Dim StrArray As String() = sn.Split("/")
'        Me.WorkOrder = StrArray(1).ToString
'        Me.PartId = CInt(StrArray(2).ToString)
'        Me.StationId = CInt(StrArray(3).ToString)
'        Me.StationName = Me.GetStationNameById(Me.StationId)
'        Me.ParseWorkOrder(Me.WorkOrder)
'        Me.lblStationName.Text = Me.StationName
'        Dim remark As String = ""
'        Dim standard As String = ""
'        Dim desc As String = ""
'        Me.StationSQ = GetStandard(remark, standard, desc)
'        If standard <> "" OrElse remark <> "" Then
'            pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
'            pnlStandard.Width = Me.Width - pnlStandard.Left - 2
'            lblStandard.Text = ""
'            lblStandard.Text += IIf(String.IsNullOrEmpty(standard), "", "工艺标准：" + standard + "。") + IIf(String.IsNullOrEmpty(remark), "", "备注：" + remark + "。") + IIf(String.IsNullOrEmpty(desc), "", desc)
'        Else
'            lblStandard.Text = ""
'        End If
'        Me.ConfigQty = GetMoConfigQty()
'    End Sub

'    Private Function GetStandard(ByRef remark As String, ByRef standard As String, ByRef desc As String) As Integer
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Dim stationSq As Integer = 1
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT REPLACE(REPLACE(PROCESSSTANDARD,CHAR(32),''),CHAR(13)+CHAR(10),'') PROCESSSTANDARD," & vbNewLine & _
'"REPLACE(REPLACE(A.REMARK,CHAR(32),''),CHAR(13)+CHAR(10),'') REMARK,B.STATIONSQ, " & vbNewLine & _
'"REPLACE(REPLACE(D.DESCRIPTION1,CHAR(32),''),CHAR(13)+CHAR(10),'') DESCRIPTION1" & vbNewLine & _
'" FROM M_RUNCARD_T A " & vbNewLine & _
'" JOIN M_RUNCARDDETAIL_T B" & vbNewLine & _
'" ON A.ID=B.RUNCARDID " & vbNewLine & _
'" LEFT JOIN M_RUNCARDPARTDETAIL_T C " & vbNewLine & _
'" ON B.ID = C.RUNCARDDETAILID" & vbNewLine & _
'" LEFT JOIN M_PARTNUMBER_T D" & vbNewLine & _
'" ON   C.PARTID=D.ID" & vbNewLine & _
'" AND ISNULL(D.TYPE,'R')='R'" & vbNewLine & _
'" WHERE(A.PARTID = " & Me.PartId & ")" & vbNewLine & _
'" AND B.STATIONID=" & Me.StationId & ""
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                For Each row As DataRow In dt.Rows
'                    remark = row("REMARK").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
'                    standard = row("PROCESSSTANDARD").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
'                    desc += "规格：" + row("DESCRIPTION1").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "") + "。"
'                    stationSq = row("STATIONSQ").ToString
'                Next
'            End Using
'            'If Not String.IsNullOrEmpty(desc) Then desc = desc.Substring(0, desc.Length - 3)
'            Return stationSq
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try

'    End Function

'    Private Function GetMoConfigQty() As String
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT TOP 1 C.ID FROM M_MAINMO_T A ,M_MAINMO_T B,M_PARTNUMBER_T C WHERE A.PARENTMO=B.MOID AND B.PARTID=C.PARTNUMBER AND A.MOID='" & Me.WorkOrder & "'"
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then
'                    sql = "SELECT ISNULL(A.QTY,1) FROM M_BOM_T A WHERE A.PARENTPARTID='" & dt.Rows(0)(0) & "' AND PARTID='" & Me.PartId & "'"
'                    Using dt1 As DataTable = sConn.GetDataTable(sql)
'                        If dt1.Rows.Count > 0 Then
'                            Return dt1.Rows(0)(0).ToString
'                        Else
'                            Return 1
'                        End If
'                    End Using
'                Else
'                    Return 1
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function
'#End Region

'#Region "显示扫描任务"
'    Private Sub ShowScanTask(ByVal functionCodeId As Integer)

'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select Item,Title from m_ScanTask_t(nolock) where FunctionCodeID=" & functionCodeId & " and IsPrompt=0 "
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        dgvScanTask.Rows.Clear()
'        'While reader.Read()
'        '    dgvScanTask.Rows.Add(ImageList1.Images(0), reader.Item("Title").ToString(), "")
'        'End While
'        'reader.Close()
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            For Each row As DataRow In dt.Rows
'                dgvScanTask.Rows.Add(ImageList1.Images(0), row(1), "")
'            Next
'        End Using

'        'dgvScanTask.Columns("TaskContent").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
'    End Sub
'#End Region

'#Region "显示校验信息"
'    Private Sub ShowVerifyTask(ByVal partId As Integer, ByVal stationId As Integer)
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "SELECT D.PARTNUMBER,E.RemainCount," & vbNewLine & _
'" CASE " & vbNewLine & _
'" WHEN E.RemainCount IS NULL THEN N'物料'" & vbNewLine & _
'" ELSE N'工装' END TYPE " & vbNewLine & _
'" FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B" & vbNewLine & _
'",M_PARTNUMBER_T D,M_RUNCARDPARTDETAIL_T C" & vbNewLine & _
'"LEFT JOIN (SELECT A.* FROM " & vbNewLine & _
'"(" & vbNewLine & _
'" SELECT B.PARTID,B.RemainCount," & vbNewLine & _
'" ROW_NUMBER() OVER(PARTITION BY B.PARTID ORDER BY B.PARTID) ID " & vbNewLine & _
'" FROM M_EQUIPMENT_T B" & vbNewLine & _
'" ) A WHERE ID=1)E ON C.PARTID=E.PARTID " & vbNewLine & _
'" WHERE(A.ID = B.RUNCARDID) " & vbNewLine & _
'" AND B.ID=C.RUNCARDDETAILID" & vbNewLine & _
'" AND C.PARTID=D.ID " & vbNewLine & _
'" AND A.PARTID=" & partId & " " & vbNewLine & _
'" AND B.STATIONID=" & stationId & " " & vbNewLine & _
'" ORDER BY TYPE "
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        dgvVerifyTask.Rows.Clear()
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            For Each row As DataRow In dt.Rows
'                dgvVerifyTask.Rows.Add(ImageList1.Images(0), row(2).ToString, row(0).ToString(), row(1).ToString(), "", "N")
'            Next
'        End Using
'        'While reader.Read()
'        '    dgvVerifyTask.Rows.Add(ImageList1.Images(0), reader.Item("TYPE").ToString(), reader.Item("PartNumber").ToString(), reader.Item("ProcessParameters").ToString(), "", "N")
'        'End While
'        'reader.Close()
'    End Sub
'#End Region

'#Region "根据治具编号取得料号"
'    Private Function GetPartNumberByEquipmentNo(ByVal sn As String) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select PartNumber from m_PartNumber_t(nolock) where id in(select PartID from m_Equipment_t(nolock) where EquipmentNo='" & sn & "')"
'        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
'        'If reader.HasRows Then
'        '    reader.Read()
'        '    Return reader.Item(0).ToString()
'        'Else
'        '    reader.Close()
'        '    Return ""
'        'End If
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then Return dt.Rows(0)(0)
'        End Using
'        Return ""
'    End Function
'#End Region

'#Region "校验料号/治具编号"
'    Private Function VerifyPn(ByVal input As String, ByVal partId As Integer, ByVal stationId As Integer, ByVal woQty As Integer) As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '参数定义
'        Dim param1 As New SqlParameter("@sn", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'        Dim param2 As New SqlParameter("@PartID", SqlDbType.Int, ParameterDirection.Input)
'        Dim param3 As New SqlParameter("@StationID", SqlDbType.Int, ParameterDirection.Input)
'        Dim param4 As New SqlParameter("@WoQty ", SqlDbType.Int, ParameterDirection.Input)
'        Dim param5 As New SqlParameter("@msg ", SqlDbType.NVarChar, 1000)
'        '参数赋值
'        param1.Value = input
'        param2.Value = partId
'        param3.Value = stationId
'        param4.Value = woQty
'        param5.Direction = ParameterDirection.Output '?指定
'        param5.Value = Nothing
'        Dim Paramters As SqlParameter() = Nothing
'        Paramters = New SqlParameter() {param1, param2, param3, param4, param5}
'        '执行SP
'        Dim err As String = DAL.ExecuteNonQureyByProc("udpVerifyPn", Paramters)
'        If err <> "" Then
'            Return err
'        Else
'            If TypeOf param5.Value Is DBNull Then
'                Return ""
'            Else
'                Return param5.Value.ToString()
'            End If
'        End If
'    End Function
'#End Region

'#Region "设置料号/治具编号列表"
'    Private Sub SetVerifyTaskProcess()
'        For Each row As DataGridViewRow In dgvVerifyTask.Rows
'            row.Cells("ImageItem").Value = ImageList1.Images(1)
'            row.Cells("PartNumber").Style.ForeColor = Color.Green
'            row.Cells("ckVerifyFlag").Value = "Y"
'            row.Cells("result").Style.ForeColor = Color.Blue
'            row.Cells("result").Value = "正确"
'        Next
'    End Sub

'    Private Sub SetVerifyProcess(ByVal input As String)
'        If dgvVerifyTask.Rows.Count > 0 Then
'            Dim eqPartNumber As String = GetPartNumberByEquipmentNo(input)
'            If eqPartNumber <> "" Then '将治具编号转换成料号
'                For Each row As DataGridViewRow In dgvVerifyTask.Rows
'                    If row.Cells("ckVerifyFlag").Value.ToString = "N" Then
'                        If row.Cells("PartNumber").Value.ToString() = eqPartNumber Then
'                            row.Cells("ImageItem").Value = ImageList1.Images(1)
'                            row.Cells("PartNumber").Value = input  '将料号替换成设备编号
'                            row.Cells("PartNumber").Style.ForeColor = Color.Green
'                            row.Cells("ckVerifyFlag").Value = "Y"
'                            row.Cells("result").Style.ForeColor = Color.Blue
'                            row.Cells("result").Value = "正确"
'                        End If
'                    End If
'                Next
'            Else
'                For Each row As DataGridViewRow In dgvVerifyTask.Rows
'                    If row.Cells("ckVerifyFlag").Value.ToString = "N" Then
'                        If row.Cells("PartNumber").Value.ToString() = input Then
'                            row.Cells("ImageItem").Value = ImageList1.Images(1)
'                            row.Cells("PartNumber").Style.ForeColor = Color.Green
'                            row.Cells("ckVerifyFlag").Value = "Y"
'                            row.Cells("result").Style.ForeColor = Color.Blue
'                            row.Cells("result").Value = "正确"
'                        End If
'                    End If
'                Next
'            End If
'        End If
'    End Sub
'#End Region

'#Region "校验任务是否完成"
'    Private Function VerifyIsFinish() As Boolean
'        If dgvVerifyTask.Rows.Count > 0 Then
'            For Each row As DataGridViewRow In dgvVerifyTask.Rows
'                If row.Cells("ckVerifyFlag").Value = "N" Then
'                    Return False
'                End If
'            Next
'            Return True
'        End If
'    End Function
'#End Region

'#Region "作业员是否确认"
'    Private Function OperatorIsConfirm() As Boolean
'        If dgvScanTask.Rows.Count > 0 Then
'            For Each row As DataGridViewRow In dgvScanTask.Rows
'                If row.Cells("TaskName").Value = "员工工号" Then
'                    If row.Cells("ckScanFlag").Value = "N" Then
'                        Return False
'                    End If
'                End If
'            Next
'            Return True
'        End If
'    End Function
'#End Region

'#Region "IPQC是否确认"
'    Private Function IpqcIsConfirm() As Boolean
'        If dgvScanTask.Rows.Count > 0 Then
'            For Each row As DataGridViewRow In dgvScanTask.Rows
'                If row.Cells("TaskName").Value = "IPQC工号" Then
'                    If row.Cells("ckScanFlag").Value = "N" Then
'                        Return False
'                    End If
'                End If
'            Next
'            Return True
'        End If
'    End Function
'#End Region

'#Region "设置扫描进度"
'    Private Sub SetScanProcess(ByVal taskType As Integer)
'        Select Case taskType
'            Case 1
'                For Each row As DataGridViewRow In dgvScanTask.Rows
'                    Select Case row.Cells("TaskName").Value.ToString()
'                        Case "员工工号"
'                            row.Cells("TaskContent").Value = Me.ScanerUserId
'                            row.Cells("TaskContent").Style.ForeColor = Color.Green
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "员工姓名"
'                            Me.ScanerUserName = Me.GetUserNameById(Me.ScanerUserId)
'                            row.Cells("TaskContent").Value = Me.ScanerUserName
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                    End Select
'                Next
'            Case 2
'                For Each row As DataGridViewRow In dgvScanTask.Rows
'                    Select Case row.Cells("TaskName").Value.ToString()
'                        Case "工站名称"
'                            row.Cells("TaskContent").Value = Me.StationName
'                            'row.Cells("TaskContent").Style.ForeColor = Color.Green
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单编号"
'                            row.Cells("TaskContent").Value = Me.WorkOrder
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单料号"
'                            row.Cells("TaskContent").Value = Me.WoPn
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单数量"
'                            row.Cells("TaskContent").Value = Me.WoQty.ToString + " * " + Me.ConfigQty
'                            row.Cells("TaskContent").Style.ForeColor = Color.Red
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                    End Select
'                Next
'            Case 3
'                For Each row As DataGridViewRow In dgvScanTask.Rows
'                    Select Case row.Cells("TaskName").Value.ToString()
'                        'Case "员工工号"
'                        '    row.Cells("TaskContent").Value = Me.ScanerUserName
'                        '    row.Cells("TaskContent").Style.ForeColor = Color.Green
'                        '    row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "IPQC工号"
'                            Me.IpqcUserName = Me.GetUserNameById(Me.IpqcUserId)
'                            row.Cells("TaskContent").Value = Me.IpqcUserName
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单编号"
'                            row.Cells("TaskContent").Value = Me.WorkOrder
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单料号"
'                            row.Cells("TaskContent").Value = Me.WoPn
'                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                        Case "工单数量"
'                            row.Cells("TaskContent").Value = Me.WoQty.ToString + " * " + Me.ConfigQty
'                            row.Cells("TaskContent").Style.ForeColor = Color.Red
'                            row.Cells("ImageList").Value = ImageList1.Images(1)
'                    End Select
'                Next

'        End Select

'    End Sub
'#End Region

'#Region "保存首检数据"
'    Private Sub SaveFAIData()
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = ""
'        StrSql = StrSql & "DELETE FROM m_lotUnitFAI_t WHERE SERIALNUMBER='" & Me.SerialNumber & "' AND PARTID='" & Me.PartId & "' AND STATIONID='" & Me.StationId & "'"
'        For Each row As DataGridViewRow In dgvVerifyTask.Rows
'            StrSql = StrSql & "insert into m_lotUnitFAI_t(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC) values('" & _
'                      Me.SerialNumber & "','" & Me.WorkOrder & "'," & Me.PartId & "," & Me.StationId & ",'" & row.Cells("PartNumber").Value.ToString & "',N'" & Me.ScanerUserName & "',N'" & Me.IpqcUserName & "',getdate() ,'" & Me.IpqcUserId & "'); "
'        Next
'        If dgvVerifyTask.Rows.Count = 0 Then
'            StrSql = StrSql & "insert into m_lotUnitFAI_t(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC) values('" & _
'                   Me.SerialNumber & "','" & Me.WorkOrder & "'," & Me.PartId & "," & Me.StationId & ",'',N'" & Me.ScanerUserName & "',N'" & Me.IpqcUserName & "',getdate(),'" & Me.IpqcUserId & "' ); "

'        End If
'        DAL.ExecSql(StrSql)
'    End Sub
'#End Region

'#Region "功能条码"
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="serialNumber"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    ''' 
'    Private Function GetFunctionCodeID(ByVal serialNumber As String) As Integer
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT TOP 1 1 ID FROM M_USERS_T WHERE USERID='" & serialNumber & "' UNION " & vbNewLine & _
'        "SELECT TOP 1 3 ID FROM M_MAINMO_T WHERE MOID='" & serialNumber & "' UNION " & vbNewLine & _
'        "SELECT TOP 1 2 ID WHERE '" & serialNumber & "' LIKE 'F/%/%/%' "
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then
'                    Return Convert.ToInt32(dt.Rows(0)(0).ToString())
'                End If
'            End Using
'            Return 0

'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try

'    End Function
'    'Private Function GetFunctionCodeID(ByVal serialNumber As String) As Integer
'    '    '
'    '    Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'    '    '参数定义
'    '    Dim param1 As New SqlParameter("@Serialnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'    '    Dim param2 As New SqlParameter("@FunctionID", SqlDbType.NVarChar, 200)
'    '    '参数赋值
'    '    param1.Value = serialNumber
'    '    param2.Direction = ParameterDirection.Output '?指定
'    '    param2.Value = Nothing
'    '    Dim Paramters As SqlParameter() = Nothing
'    '    Paramters = New SqlParameter() {param1, param2}
'    '    '执行SP
'    '    DAL.ExecuteNonQureyByProc("udpGetFunctionID", Paramters)
'    '    '
'    '    If TypeOf param2.Value Is DBNull Then
'    '        Return 0
'    '    Else
'    '        Return CInt(param2.Value.ToString)
'    '    End If
'    'End Function
'#End Region

'#Region "初始化扫描"
'    Private Sub IniteScan()
'        Me.lblMsg.Text = ""

'        'Me.lblFormat.Text = ""
'        Me.lblTips.Text = "请扫描"
'        Me.lblStationName.Text = "Working In Process"
'        'Me.lstBoxDisplay.Items.Clear()
'        Me.txtInput.Text = ""
'        Me.txtInput.Focus()
'        Me.ScanStatus = LotStatus.Waiting
'        Me.PictureBox1.Visible = False
'        'Me.Chart1.Visible = True
'        Me.ScanStep = 0
'        Me.dgvScanTask.Rows.Clear()
'        Me.dgvVerifyTask.Rows.Clear()
'        'Me.dgvScaningData.DataSource = Nothing
'        dt.Columns.Clear()
'        dt.Columns.Add("ID1", GetType(String))
'        dt.Columns.Add("ID2", GetType(String))
'        dt.Columns.Add("ID3", GetType(String))
'        dt.Columns.Add("ID4", GetType(String))
'        dt.Columns.Add("ID5", GetType(String))
'        dt.Columns.Add("ID6", GetType(String))
'        dt.Columns.Add("ID7", GetType(String))
'        dt.Columns.Add("ID8", GetType(String))
'        dt.Columns.Add("ID9", GetType(String))
'    End Sub
'#End Region

'#Region "GetSopFile"
'    Private Function GetSopFile() As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select top 1 B.SopFilePath from m_RunCard_t(nolock)  A join m_RunCardDetail_t(nolock) B on A.ID=B.RunCardID " & _
'                               "where A.PartID=" & Me.PartId & " and B.StationID=" & Me.StationId
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count Then
'                Return dt.Rows(0)(0).ToString
'            Else
'                Return ""
'            End If
'        End Using
'    End Function
'#End Region

'#Region "显示SOP"
'    Private Sub ShowSopImage()

'        Me.dgvRunCard.Visible = False
'        Me.PictureBox1.Visible = True
'        Dim file As String = Me.GetSopFile()
'        Dim localFile As String = ""
'        If file <> "" Then
'            'localFile = DownLoadSopFile(file)
'            'If localFile <> "" Then
'            '    Me.PictureBox1.Image = Image.FromFile(localFile)
'            'Else
'            Me.PictureBox1.Image = Image.FromFile(file)
'            'End If
'        Else
'            Me.PictureBox1.Image = Nothing
'        End If
'    End Sub
'    Private Function DownLoadSopFile(ByVal path As String) As String
'        Try
'            Dim partNumber As String = GetPartNumber()
'            Dim localPath As String = Environment.CurrentDirectory
'            If partNumber <> "" Then
'                localPath = localPath + "\\SOP\\" + partNumber
'            Else : localPath = localPath + "\\SOP\\" + Me.PartId.ToString
'            End If
'            If System.IO.Directory.Exists(localPath) = False Then
'                System.IO.Directory.CreateDirectory(localPath)
'            End If
'            localPath = localPath + "\\" + path.Substring(path.LastIndexOf("\") + 1)
'            System.IO.File.Copy(path, localPath, True)
'            Return localPath
'        Catch ex As Exception
'            Return ""
'        End Try
'    End Function

'    Private Function GetPartNumber() As String
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT PARTNUMBER FROM M_PARTNUMBER_T WHERE ID=" & Me.PartId & ""
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString
'            End Using
'            Return ""
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function
'#End Region

'#Region "显示样本图表"
'    Private Sub ShowSampleChart()
'        'Me.Chart1.Visible = True
'        ''X轴坐标间隔
'        'Me.Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
'        ''是否交叉显示
'        'Me.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.IsStaggered = False
'        'Me.Chart1.Series("ProductQty").Points.Clear()
'        'For index As Integer = 8 To 20
'        '    Chart1.Series("ProductQty").Points.AddXY(index.ToString & ":00", New Random(index).Next(100, 160))
'        'Next
'    End Sub
'#End Region

'#Region "显示图表"
'    Private Sub ShowRunCardChart()
'        'Me.Chart1.Visible = True
'        ''X轴坐标间隔
'        'Me.Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
'        ''是否交叉显示
'        'Me.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.IsStaggered = False
'        'Me.Chart1.Series("ProductQty").Points.Clear()
'        '
'        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        'Dim StrSql As String = "select RCD.StationSQ,ST.StationName,UN.Qty from m_RunCard_t(nolock)  RC " & _
'        '                       "join m_RunCardDetail_t(nolock) RCD on RC.ID=RCD.RunCardID " & _
'        '                       "join m_Station_t(nolock) ST on RCD.StationID=ST.ID " & _
'        '                       "left join m_LotUnit_t(nolock) UN on RC.PartID=Un.PartID and ST.ID=UN.StationID " & _
'        '                       "where RC.PartID = " & Me.PartId & " order by RCD.StationSQ "
'        'Dim dt As DataTable = DAL.GetDataTable(StrSql)
'        'For Each row As DataRow In dt.Rows
'        '    Chart1.Series("ProductQty").Points.AddXY(row("StationSQ").ToString & "-" & row("StationName").ToString, row("Qty").ToString)
'        'Next
'    End Sub
'#End Region


'#Region "显示流程卡"

'    Private dt As New DataTable

'    Private Sub ShowRunCard(ByVal wo As String)
'        '
'        dt.Rows.Clear()
'        Me.dgvRunCard.AutoGenerateColumns = True
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        'RunCard Header
'        '        Dim sqlHeader As String = "select PN.PARTNUMBER DrawingNo,RC.DrawingVer,RC.Shape,WO.Moid,WO.Moqty,WO.Lineid " & _
'        '                               "from m_Mainmo_t(nolock) WO " & _
'        '                               "join m_PartNumber_t(nolock) PN on WO.PartID=PN.PartNumber " & _
'        '                               "join m_RunCard_t(nolock) RC on PN.ID=RC.PartID " & _
'        '                               "where Wo.Moid='" & wo & "'; "
'        '        'RunCard Body
'        '        Dim sqlBody As String = "SELECT A.STATIONSQ,A.STATIONNAME," & vbNewLine & _
'        '" A.WORKINGHOURS,A.EQUIPMENT,LEFT(RAWINFO,LEN(RAWINFO)-3) RAWI," & vbNewLine & _
'        '        " A.PROCESSSTANDARD, A.REMARK, A.SHAPE, " & vbNewLine & _
'        '        " A.OPERATORUSERNAME, A.CONFIRMUSERNAME" & vbNewLine & _
'        '" FROM (" & vbNewLine & _
'        '" SELECT A.*,(SELECT PARTD.DESCRIPTION1+' || ' " & vbNewLine & _
'        ' "  FROM M_RUNCARDDETAIL_T DETAIL, " & vbNewLine & _
'        '  " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_PARTNUMBER_T PARTD " & vbNewLine & _
'        '   "        WHERE(DETAIL.ID = A.ID) " & vbNewLine & _
'        '   " AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID " & vbNewLine & _
'        '   " AND PARTDETAIL.PARTID=PARTD.ID " & vbNewLine & _
'        '   " AND ISNULL(PARTD.TYPE,'R')='R' " & vbNewLine & _
'        '   " FOR XML PATH('')) AS RAWINFO FROM" & vbNewLine & _
'        '" (SELECT RCD.STATIONSQ,ST.STATIONNAME," & vbNewLine & _
'        '  "       RCD.WORKINGHOURS, RCD.EQUIPMENT, " & vbNewLine & _
'        '   "      RCD.PROCESSSTANDARD, RCD.REMARK, RCD.SHAPE, " & vbNewLine & _
'        '" FAI.OPERATORUSERNAME,FAI.CONFIRMUSERNAME,RCD.ID  " & vbNewLine & _
'        '" FROM M_MAINMO_T(NOLOCK ) WO " & vbNewLine & _
'        '" JOIN M_PARTNUMBER_T(NOLOCK) PN " & vbNewLine & _
'        '" ON WO.PARTID=PN.PARTNUMBER " & vbNewLine & _
'        '" JOIN M_RUNCARD_T(NOLOCK) RC " & vbNewLine & _
'        '" ON PN.ID=RC.PARTID " & vbNewLine & _
'        '" JOIN M_RUNCARDDETAIL_T(NOLOCK) RCD " & vbNewLine & _
'        '" ON RC.ID=RCD.RUNCARDID " & vbNewLine & _
'        '" JOIN M_STATION_T(NOLOCK) ST " & vbNewLine & _
'        '" ON ST.ID=RCD.STATIONID " & vbNewLine & _
'        '" LEFT JOIN (SELECT DISTINCT STATIONID,OPERATORUSERNAME," & vbNewLine & _
'        '" CONFIRMUSERNAME FROM M_LOTUNITFAI_T(NOLOCK) " & vbNewLine & _
'        '" WHERE WORKORDER='" & wo & "')FAI " & vbNewLine & _
'        '" ON RCD.STATIONID=FAI.STATIONID " & vbNewLine & _
'        '" WHERE WO.MOID='" & wo & "' )A)A" & vbNewLine & _
'        '" ORDER BY A.STATIONSQ; "

'        'RunCard Tial
'        Dim sqlHeader = "SELECT A.DRAWINGNO,A.DRAWINGVER,A.SHAPE," & vbNewLine & _
'" A.MOID,A.MOQTY,A.LINEID,A.STATIONSQ,A.STATIONNAME," & vbNewLine & _
'" A.WORKINGHOURS,A.EQUIPMENT,LEFT(RAWINFO,LEN(RAWINFO)-3) RAWI," & vbNewLine & _
'  "       A.PROCESSSTANDARD, A.REMARK, A.SHAPE, " & vbNewLine & _
'    "     A.OPERATORUSERNAME, A.CONFIRMUSERNAME" & vbNewLine & _
'" FROM (" & vbNewLine & _
'" SELECT A.*,(SELECT PARTD.DESCRIPTION1+' || ' " & vbNewLine & _
'" FROM M_RUNCARDDETAIL_T DETAIL, " & vbNewLine & _
'" M_RUNCARDPARTDETAIL_T PARTDETAIL,M_PARTNUMBER_T PARTD " & vbNewLine & _
'"           WHERE(DETAIL.ID = A.ID) " & vbNewLine & _
'"    AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID " & vbNewLine & _
'"    AND PARTDETAIL.PARTID=PARTD.ID " & vbNewLine & _
'"    AND ISNULL(PARTD.TYPE,'R')='R' " & vbNewLine & _
'"    FOR XML PATH('')) AS RAWINFO FROM" & vbNewLine & _
'" (SELECT PN.PARTNUMBER DrawingNo,RC.DrawingVer," & vbNewLine & _
'"         RC.Shape, wo.Moid, wo.Moqty, wo.Lineid, RCD.STATIONSQ, ST.STATIONNAME, " & vbNewLine & _
'"         RCD.WORKINGHOURS, RCD.EQUIPMENT, " & vbNewLine & _
'"         RCD.PROCESSSTANDARD, RCD.REMARK, " & vbNewLine & _
'" FAI.OPERATORUSERNAME,FAI.CONFIRMUSERNAME,RCD.ID " & vbNewLine & _
'" FROM M_MAINMO_T(NOLOCK ) WO " & vbNewLine & _
'" JOIN M_PARTNUMBER_T(NOLOCK) PN " & vbNewLine & _
'" ON WO.PARTID=PN.PARTNUMBER " & vbNewLine & _
'" JOIN M_RUNCARD_T(NOLOCK) RC " & vbNewLine & _
'" ON PN.ID=RC.PARTID " & vbNewLine & _
'" JOIN M_RUNCARDDETAIL_T(NOLOCK) RCD " & vbNewLine & _
'" ON RC.ID=RCD.RUNCARDID " & vbNewLine & _
'" JOIN M_STATION_T(NOLOCK) ST " & vbNewLine & _
'" ON ST.ID=RCD.STATIONID " & vbNewLine & _
'" LEFT JOIN (SELECT DISTINCT  A.STATIONID,C.USERNAME AS OPERATORUSERNAME" & vbNewLine & _
'",A.CONFIRMUSERNAME  FROM M_LOTUNITFAI_T  A " & vbNewLine & _
'" LEFT JOIN M_LOTUNIT_T B " & vbNewLine & _
'" ON A.SERIALNUMBER=B.SERIALNUMBER " & vbNewLine & _
'" AND A.WORKORDER=B.WORKORDER" & vbNewLine & _
'" LEFT JOIN M_USERS_T C" & vbNewLine & _
'" ON B.UserID=C.USERID" & vbNewLine & _
'" WHERE A.WORKORDER='" & wo & "')FAI " & vbNewLine & _
'" ON RCD.STATIONID=FAI.STATIONID " & vbNewLine & _
'" WHERE WO.MOID='" & wo & "' )A)A" & vbNewLine & _
'" ORDER BY A.STATIONSQ; "


'        Dim sqlTail As String = "select ST.SectionID, case " & vbNewLine & _
'" when ST.SectionID=1 " & vbNewLine & _
'" then sum(RCD.WorkingHours) " & vbNewLine & _
'" when ST.SectionID=2 " & vbNewLine & _
'" then sum(RCD.WorkingHours) " & vbNewLine & _
'" when ST.SectionID=3 " & vbNewLine & _
'" then sum(RCD.WorkingHours) " & vbNewLine & _
'" end WorkingHours " & vbNewLine & _
'" from m_Mainmo_t(nolock) WO " & vbNewLine & _
'" join m_PartNumber_t(nolock) PN " & vbNewLine & _
'" on WO.PartID=PN.PartNumber " & vbNewLine & _
'" join m_RunCard_t(nolock) RC " & vbNewLine & _
'" on PN.ID=RC.PartID" & vbNewLine & _
'"  join m_RunCardDetail_t(nolock) RCD " & vbNewLine & _
'"  on RC.ID=RCD.RunCardID " & vbNewLine & _
'"  join m_Station_t(nolock) ST " & vbNewLine & _
'"  on RCD.StationID=ST.ID " & vbNewLine & _
'"  where Wo.Moid='" & wo & "' " & vbNewLine & _
'"  group by ST.SectionID ;"

'        '"where RC.PartId=368 order by RCD.StationSQ "
'        Dim ds As DataSet = DAL.GetDataSet(sqlHeader & vbNewLine & vbNewLine & sqlTail)
'        If Not ds Is Nothing Then
'            Dim dtHeader As DataTable = ds.Tables(0)
'            Dim dtBody As DataTable = ds.Tables(1)
'            'header
'            For index As Integer = 0 To dtHeader.Rows.Count - 1
'                'Me.dgvRunCard.Rows.Add("图号", dtHeader.Rows(index)("DrawingNo").ToString, "", "", "", "", "工单号", wo, "")
'                'Me.dgvRunCard.Rows.Add("版本", dtHeader.Rows(index)("DrawingVer").ToString, "线别", dtHeader.Rows(index)("Lineid").ToString, "", "", "责任线长", "", "")
'                'Me.dgvRunCard.Rows.Add("形态", dtHeader.Rows(index)("Shape").ToString, "", "", "", "", "工单量", dtHeader.Rows(index)("Moqty").ToString, "")
'                'Me.dgvRunCard.Rows.Add("序号", "工站内容", "工时(s)", "设备/治具", "工艺标准", "备注", "操作员", "IPQC", "")
'                If index = 0 Then
'                    dt.Rows.Add("图号", dtHeader.Rows(index)("DrawingNo").ToString, "", "", "", "", "", "工单号", wo)
'                    dt.Rows.Add("版本", dtHeader.Rows(index)("DrawingVer").ToString, "线别", dtHeader.Rows(index)("Lineid").ToString, "", "", "", "责任线长", "")
'                    dt.Rows.Add("形态", dtHeader.Rows(index)("Shape").ToString, "", "", "", "", "", "工单量", dtHeader.Rows(index)("Moqty").ToString)
'                    dt.Rows.Add("序号", "工站内容", "工时(s)", "设备/治具", "工艺标准", "物料规格", "备注", "操作员", "IPQC")
'                End If
'                dt.Rows.Add(dtHeader.Rows(index)("StationSQ").ToString, dtHeader.Rows(index)("StationName").ToString, dtHeader.Rows(index)("WorkingHours").ToString, _
'                                   dtHeader.Rows(index)("Equipment").ToString, dtHeader.Rows(index)("ProcessStandard").ToString, dtHeader.Rows(index)("RAWI").ToString, _
'                                   dtHeader.Rows(index)("Remark").ToString, dtHeader.Rows(index)("OperatorUserName").ToString, dtHeader.Rows(index)("ConfirmUserName").ToString)
'            Next
'            ''body
'            'For index As Integer = 0 To dtBody.Rows.Count - 1
'            '    'Me.dgvRunCard.Rows.Add(dtBody.Rows(index)("StationSQ").ToString, dtBody.Rows(index)("StationName").ToString, dtBody.Rows(index)("WorkingHours").ToString, _
'            '    '                       dtBody.Rows(index)("Equipment").ToString, dtBody.Rows(index)("ProcessStandard").ToString, dtBody.Rows(index)("Remark").ToString _
'            '    '                       , dtBody.Rows(index)("OperatorUserName").ToString, dtBody.Rows(index)("ConfirmUserName").ToString, "")
'            '    dt.Rows.Add(dtBody.Rows(index)("StationSQ").ToString, dtBody.Rows(index)("StationName").ToString, dtBody.Rows(index)("WorkingHours").ToString, _
'            '                          dtBody.Rows(index)("Equipment").ToString, dtBody.Rows(index)("ProcessStandard").ToString, dtBody.Rows(index)("Remark").ToString _
'            '                          , dtBody.Rows(index)("OperatorUserName").ToString, dtBody.Rows(index)("ConfirmUserName").ToString, "")
'            'Next
'            'tail

'            Dim totalHours As Integer = 0
'            Dim preHours As Integer = 0
'            Dim proHours As Integer = 0
'            Dim sufHours As Integer = 0
'            '添加空行
'            'Me.dgvRunCard.Rows.Add("", "", "", "", "", "", "", "", "")
'            If dt.Rows.Count > 0 Then
'                For index As Integer = 0 To dtBody.Rows.Count - 1
'                    If dtBody.Rows(index)("SectionID").ToString = "1" Then
'                        preHours = dtBody.Rows(index)("WorkingHours").ToString
'                    ElseIf dtBody.Rows(index)("SectionID").ToString = "2" Then
'                        proHours = dtBody.Rows(index)("WorkingHours").ToString
'                    ElseIf dtBody.Rows(index)("SectionID").ToString = "3" Then
'                        sufHours = dtBody.Rows(index)("WorkingHours").ToString
'                    End If
'                Next
'            End If

'            totalHours = preHours + proHours + sufHours
'            'Me.dgvRunCard.Rows.Add("总工时(s):" & totalHours.ToString, "", "", "前加工(S):" & preHours.ToString & "产线" & proHours.ToString(), "", "成型" & sufHours.ToString, "", "")
'            dt.Rows.Add("", "总工时(s):" & totalHours.ToString, "", "前加工(s):" & preHours.ToString, "", "产线(s):" & proHours.ToString(), "成型(s):" & sufHours.ToString, "", "")
'            'Me.dgvRunCard.VirtualMode = True
'            Me.dgvRunCard.DataSource = dt
'            Me.dgvRunCard.Columns(0).Width = 35
'            Me.dgvRunCard.Columns(2).Width = 50
'            Me.dgvRunCard.Columns(4).Width = 220
'            Me.dgvRunCard.Columns(5).Width = 220
'            Me.dgvRunCard.Columns(6).Width = 160
'            Me.dgvRunCard.Columns(7).Width = 70
'            Me.dgvRunCard.Columns(8).Width = 130
'            'Me.dgvRunCard.RowCount = dt.Rows.Count
'        End If
'    End Sub
'#End Region

'#Region "横向合并单元格"
'    Private Sub HorizontalMerageCell(ByVal dgv As DataGridView, ByVal celArgs As DataGridViewCellPaintingEventArgs, ByVal minColIndex As Integer, ByVal maxColIndex As Integer)
'        If celArgs.RowIndex = -1 Or celArgs.ColumnIndex > maxColIndex Or celArgs.ColumnIndex < minColIndex Then
'            Exit Sub
'        End If
'        Dim rect As New Rectangle
'        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
'            celArgs.Graphics.FillRectangle(backColorBrush, celArgs.CellBounds)
'        End Using
'        'celArgs.Handled = True
'        'IsPostMerage(dgv, celArgs, minColIndex, maxColIndex)
'        Dim rectArgs As Rectangle = CType(rowSpan(celArgs.ColumnIndex), Rectangle)
'        'If rectArgs.X <> celArgs.CellBounds.X Or rectArgs.Y <> celArgs.CellBounds.Y Or rectArgs.Width <> celArgs.CellBounds.Width Or rectArgs.Height <> celArgs.CellBounds.Height Then
'        rectArgs.X = celArgs.CellBounds.X
'        rectArgs.Y = celArgs.CellBounds.Y
'        rectArgs.Width = celArgs.CellBounds.Width
'        rectArgs.Height = celArgs.CellBounds.Height
'        rowSpan(celArgs.ColumnIndex) = rectArgs
'        '
'        Dim width As Integer = 0
'        Dim height As Integer = celArgs.CellBounds.Height
'        For index As Integer = minColIndex To maxColIndex
'            width += CType(rowSpan(index), Rectangle).Width
'        Next
'        Dim rectBegin As Rectangle = CType(rowSpan(minColIndex), Rectangle)
'        Dim rectEnd As Rectangle = CType(rowSpan(maxColIndex), Rectangle)
'        Dim reBounds As New Rectangle()
'        reBounds.X = rectBegin.X
'        reBounds.Y = rectBegin.Y
'        reBounds.Width = width - 1
'        reBounds.Height = height - 1
'        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
'            Using gridLinePen As New Pen(gridBrush)

'                Dim blPoint As New Point(rectBegin.Left, rectBegin.Bottom - 1)
'                Dim brPoint As New Point(rectEnd.Right, rectEnd.Bottom - 1)
'                celArgs.Graphics.DrawLine(gridLinePen, blPoint, brPoint)

'                Dim rtPoint As New Point(rectEnd.Right - 1, rectEnd.Top)
'                Dim rbPoint As New Point(rectEnd.Right - 1, rectEnd.Bottom - 1)
'                celArgs.Graphics.DrawLine(gridLinePen, rtPoint, rbPoint)

'                Dim sf As SizeF = celArgs.Graphics.MeasureString(rowValue, celArgs.CellStyle.Font)
'                Dim lstr As Double = (width - sf.Width) / 2
'                Dim rstr As Double = (height - sf.Height) / 2
'                '
'                If celArgs.ColumnIndex = maxColIndex Then
'                    If totalQty <> 0 Then
'                        celArgs.Graphics.DrawString(totalQty.ToString, celArgs.CellStyle.Font, New SolidBrush(celArgs.CellStyle.ForeColor), rectBegin.Left + lstr, rectEnd.Top + rstr, StringFormat.GenericDefault)
'                    End If
'                End If


'            End Using
'            celArgs.Handled = True
'        End Using

'    End Sub
'#End Region

'    '#Region "纵向合并单元格"
'    '    Private Sub VerticalMerageCell(ByRef dgv As DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, ByVal colIndex As Integer, ByVal minRoxIndex As Integer, ByVal maxRowIndex As Integer)
'    '        '合并第 rowId行 第 minColIndex-maxColIndex 列
'    '        If e.ColumnIndex = colIndex And e.RowIndex >= minRoxIndex And e.RowIndex <= maxRowIndex Then
'    '            '删除背景单元格
'    '            Dim rect As New Rectangle
'    '            Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(e.CellStyle.BackColor)
'    '                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
'    '            End Using
'    '            'e.Handled = True
'    '            Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(e.CellStyle.BackColor)
'    '                Using gridLinePen As New Pen(gridBrush)

'    '                    If e.RowIndex <> dgv.RowCount - 1 Then
'    '                        If e.RowIndex = maxRowIndex Then
'    '                            '划下底线
'    '                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
'    '                            '绘值
'    '                            If e.Value <> Nothing Then
'    '                                e.Graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault)
'    '                            End If
'    '                        End If
'    '                    Else

'    '                    End If

'    '                    '右侧的线
'    '                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
'    '                    e.Handled = True
'    '                End Using
'    '            End Using
'    '        End If
'    '    End Sub

'    '#End Region

'    '#Region "横向合并单元格"

'    '    Private Sub HorizontalMerageCell(ByRef dgv As DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, ByVal rowId As Integer, ByVal minColIndex As Integer, ByVal maxColIndex As Integer)
'    '        '合并第 rowId行 第 minColIndex-maxColIndex 列
'    '        If e.RowIndex = rowId And e.ColumnIndex >= minColIndex And e.ColumnIndex <= maxColIndex Then
'    '            '删除背景单元格
'    '            Dim rect As New Rectangle
'    '            Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(e.CellStyle.BackColor)
'    '                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
'    '            End Using
'    '            'e.Handled = True
'    '            Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(e.CellStyle.BackColor)
'    '                Using gridLinePen As New Pen(gridBrush)
'    '                    '保留最左边的值
'    '                    If e.ColumnIndex = minColIndex Then
'    '                        cellValue = e.Value
'    '                    End If

'    '                    If e.ColumnIndex = maxColIndex Then
'    '                        '画右边线
'    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
'    '                        '绘值
'    '                        'If e.Value <> Nothing Then
'    '                        '    e.Graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault)
'    '                        'End If
'    '                        If cellValue <> "" Then
'    '                            e.Graphics.DrawString(cellValue, e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault)
'    '                        End If

'    '                    End If
'    '                    '划底线
'    '                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
'    '                End Using
'    '                e.Handled = True
'    '            End Using
'    '        End If
'    '    End Sub

'    '#End Region

'    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
'        IniteScan()
'        ResetScanParm()
'    End Sub

'    Private Sub tsmiScanTaskCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiScanTaskCopy.Click
'        If Not dgvScanTask.CurrentCell Is Nothing Then
'            Dim Selected As String = dgvScanTask.CurrentCell.Value.ToString()
'            Clipboard.SetDataObject(Selected)
'        End If
'    End Sub

'    Private Sub tsmiVerifyTaskCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiVerifyTaskCopy.Click
'        If Not dgvVerifyTask.CurrentCell Is Nothing Then
'            Dim Selected As String = dgvVerifyTask.CurrentCell.Value.ToString()
'            Clipboard.SetDataObject(Selected)
'        End If
'    End Sub

'    'Private Sub dgvRunCard_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvRunCard.CellPainting

'    '    If e.RowIndex > -1 And e.ColumnIndex > -1 Then
'    '        '
'    '        'HorizontalMerageCell(dgvRunCard, e, 0, 1, 3)
'    '        'HorizontalMerageCell(dgvRunCard, e, 0, 5, 6)
'    '        'HorizontalMerageCell(dgvRunCard, e, 2, 1, 3)
'    '        'HorizontalMerageCell(dgvRunCard, e, 1, 5, 6)
'    '        'HorizontalMerageCell(dgvRunCard, e, 2, 5, 6)
'    '        ''
'    '        'VerticalMerageCell(dgvRunCard, e, 4, 0, 2)

'    '        ''最后一行

'    '        'If e.RowIndex = dgvRunCard.Rows.Count - 1 Then
'    '        '    HorizontalMerageCell(dgvRunCard, e, e.RowIndex, 0, 2)
'    '        '    HorizontalMerageCell(dgvRunCard, e, e.RowIndex, 3, 4)
'    '        '    HorizontalMerageCell(dgvRunCard, e, e.RowIndex, 5, 7)
'    '        'End If


'    '    End If


'    'End Sub

'    Private Sub dgvScaningData_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvScaningData.DataBindingComplete
'        For Each column As DataGridViewColumn In dgvScaningData.Columns
'            If column.Name = "生产数量" Or column.Name = "姓名" Then
'                column.DefaultCellStyle.ForeColor = Color.Blue
'            End If
'        Next
'    End Sub

'    Private Sub dgvScaningData_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvScaningData.CellPainting
'        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
'            If dgvScaningData.Rows.Count > 0 Then
'                If e.RowIndex = dgvScaningData.Rows.Count - 1 Then
'                    HorizontalMerageCell(Me.dgvScaningData, e, 0, 8)
'                End If
'            End If
'        End If
'    End Sub

'    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
'        Try
'            Dim frmSplit As New FrmLotSplit()
'            frmSplit.ShowDialog()
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmLotSplit", "ToolStripButton1_Click", "WIP")
'        End Try

'    End Sub

'    Private Sub CheckInputType(ByVal inputString As String)
'        lblMsg.Text = ""
'        If Not scanP.isInProcess Then
'            Me.FunctionCodeId = Me.GetFunctionCodeID(inputString)
'            If CheckIsUserID(inputString) AndAlso Not IsIPQC(inputString) Then
'                If scanP.isDoFAI Then
'                    Me.ScanerUserId = inputString
'                    scanP.isInProcess = True
'                    SetScanProcess(1)
'                    lblMsg.Text = "接下来请刷功能条码"
'                    Exit Sub
'                End If
'                scanP.isFunctionBarcode = False
'                ShowCatagoryByUser(inputString)
'            ElseIf FunctionCodeId = 3 Then
'                scanP.isFunctionBarcode = False
'                DoWoScaning(inputString, FunctionCodeId)
'            ElseIf FunctionCodeId = 2 Then
'                DoProcess(inputString, FunctionCodeId)
'                If CheckRouting(inputString) Then
'                    Me.IpqcUserId = GetFaiIPQC(inputString)
'                    SetScanProcess(1)
'                    SetScanProcess(3)
'                    SetVerifyTaskProcess()
'                    lblMsg.Text = "该工站已经扫描,请勿重复扫描"
'                    Exit Sub
'                End If
'                If Not CheckVersion() Then
'                    'lblMsg.Text = "工单版本与BOM不一致,请确认！！"
'                    Exit Sub
'                End If
'                scanP.isFunctionBarcode = True
'                scanP.functionBarcode = inputString
'                If HasDoneFAI() Then
'                    scanP.isDoFAI = True
'                    Me.IpqcUserId = GetFaiIPQC(inputString)
'                    SetScanProcess(3)
'                    SetVerifyTaskProcess()
'                    'ParseSnData(inputString)
'                    lblMsg.Text = "已做完首检可以刷入员工号录入数据"
'                    Exit Sub
'                End If
'            Else
'                If scanP.isDoFAI Then
'                    lblMsg.Text = "刷入错误！！请确认"
'                    ResetScanParm()
'                    Exit Sub
'                End If
'                If scanP.isFunctionBarcode Then
'                    If Not IsIPQC(inputString) Then  '' 不是IPQC，就只能是料件或是工治具编号
'                        Dim msg1 As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
'                        If msg1 <> "" Then
'                            lblMsg.Text = "刷入错误！！请确认" & msg1
'                            If scanP.isFunctionBarcode Then scanP.isFunctionBarcode = False
'                            Exit Sub
'                        End If
'                    End If
'                End If
'                If scanP.isFunctionBarcode Then
'                    If HasDoneFAI() AndAlso UserDoWork() Then
'                        lblMsg.Text = "该工站条码已扫描完成,请勿重复"
'                        If scanP.isFunctionBarcode Then scanP.isFunctionBarcode = False
'                        Exit Sub
'                    End If
'                    'Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
'                    If dgvVerifyTask.Rows.Count <= 0 Then
'                        If IsIPQC(inputString) Then
'                            Me.IpqcUserId = inputString
'                            '更新扫描进度
'                            SetScanProcess(3)
'                            'IPQC确认
'                            If IpqcIsConfirm() Then
'                                '保存数据
'                                SaveFAIData()
'                                ShowAllStation()
'                                Me.lblPass.Text = "PASS"
'                                scanP.isPnCheckFinish = True
'                                scanP.isInProcess = True
'                                scanP.isCheckIPQC = True
'                                lblMsg.Text = "接下来请刷入员工编号"
'                                '初始化扫描
'                            End If
'                        Else
'                            scanP.isFunctionBarcode = False
'                            lblMsg.Text = "刷入错误，请确认！！"
'                        End If
'                    Else
'                        If Not VerifyIsFinish() Then
'                            Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
'                            If msg <> "" Then
'                                lblMsg.Text = msg
'                                Exit Sub
'                            Else
'                                SetVerifyProcess(inputString)
'                                scanP.isPnCheckFinish = VerifyIsFinish()
'                                scanP.isInProcess = True
'                                If Not VerifyIsFinish() Then
'                                    lblMsg.Text = "请刷下一个料件或是工治具编号"
'                                Else
'                                    lblMsg.Text = "请刷入IPQC号"
'                                End If
'                            End If
'                        Else
'                            scanP.isPnCheckFinish = True
'                            scanP.isInProcess = True
'                            lblMsg.Text = "请刷入IPQC号"
'                        End If
'                    End If
'                Else
'                    lblMsg.Text = "扫描不正确！！请确认"
'                    Me.PictureBox1.Image = Nothing
'                    Exit Sub
'                End If

'                End If
'        Else
'                If scanP.isDoFAI Then
'                    If CheckSNFormat(inputString, 2) = "" Then
'                        lblMsg.Text = "工站条码""" + inputString + """ 格式不正确"
'                        Exit Sub
'                    End If
'                    If inputString.ToUpper <> scanP.functionBarcode.ToUpper Then
'                        lblMsg.Text = "刷入的工站条码与做首检的不一致"
'                        Exit Sub
'                    End If
'                    SaveData(inputString)
'                    Exit Sub
'                End If
'                If Not scanP.isPnCheckFinish Then
'                    Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
'                    If Not VerifyIsFinish() Then
'                        If msg <> "" Then
'                            lblMsg.Text = "请刷入料件或是工治具编号"
'                            Exit Sub
'                        Else
'                            SetVerifyProcess(inputString)
'                            scanP.isPnCheckFinish = VerifyIsFinish()
'                        End If
'                    Else
'                        scanP.isPnCheckFinish = True
'                    End If
'                    If scanP.isPnCheckFinish Then
'                        lblMsg.Text = "接下来请刷入IPQC号"
'                    Else
'                        lblMsg.Text = "请刷下一个料件或是工治具编号"
'                    End If
'                ElseIf scanP.isPnCheckFinish AndAlso Not scanP.isCheckIPQC Then
'                    If IsIPQC(inputString) Then
'                        Me.IpqcUserId = inputString
'                        '更新扫描进度
'                        SetScanProcess(3)
'                        'IPQC确认
'                        If IpqcIsConfirm() Then
'                            '保存数据
'                        SaveFAIData()
'                        ShowAllStation()
'                            Me.lblPass.Text = "PASS"
'                            scanP.isCheckIPQC = True
'                            lblMsg.Text = "接下来请刷入操作员ID"
'                            '初始化扫描
'                        End If
'                    Else
'                        lblMsg.Text = "请刷入IPQC号"
'                        Exit Sub
'                    End If
'                ElseIf scanP.isPnCheckFinish AndAlso scanP.isCheckIPQC AndAlso Not scanP.isCheckUserId Then
'                    If Not CheckIsUserID(inputString) Then
'                        lblMsg.Text = "请刷入操作员ID"
'                        txtInput.Text = ""
'                        txtInput.Focus()
'                        Exit Sub
'                    Else
'                        Me.ScanerUserId = inputString
'                        SetScanProcess(1)
'                        lblMsg.Text = "接下来请刷入工站条码"
'                        scanP.isCheckUserId = True
'                    End If
'                ElseIf scanP.isCheckUserId Then
'                    If CheckSNFormat(inputString, 2) = "" Then
'                        lblMsg.Text = "工站条码""" + inputString + """ 格式不正确"
'                        Exit Sub
'                    End If
'                    If inputString.ToUpper <> scanP.functionBarcode.ToUpper Then
'                        lblMsg.Text = "刷入的工站条码与做首检的不一致"
'                        Exit Sub
'                    End If
'                    SaveData(inputString)
'                End If
'        End If
'        txtInput.Text = ""
'        txtInput.Focus()
'    End Sub

'    Private Sub SaveData(ByVal InputString As String)
'        'ShowSopImage()
'        '解析工站条码格式
'        ParseSnData(InputString)
'        '校验工站，流程卡，工单信息
'        Dim msg As String = ""
'        msg = VerifySnData(InputString, 2)
'        If msg <> "" Then
'            lblMsg.Text = msg
'            Exit Sub
'        End If
'        '设置扫描进度
'        SetScanProcess(2)
'        '保存扫描数据
'        msg = SaveScanData(InputString)
'        If msg <> "" Then
'            ''显示工艺程流程图表
'            'ShowRunCardChart()
'            ResetScanParm()
'            lblMsg.Text = msg
'            Exit Sub
'        End If
'        UpdateFAI()
'        Me.lblPass.Text = "PASS"
'        '刷新显示
'        LoadScaningData(Me.ScanerUserId)
'        ResetScanParm()
'        Dim result As Integer = -1
'        result = GetNextStation()
'        If result = 0 Then
'            lblMsg.Text = "加工流程已完成"
'        Else
'            lblMsg.Text = "本站完成,请去下一站：" + GetNextStationName(result)
'        End If
'        ShowCatagoryByUser(Me.ScanerUserId)
'        Me.PictureBox1.Image = Nothing
'        dgvScanTask.DataSource = Nothing
'        dgvVerifyTask.Rows.Clear()
'        ShowAllStation()
'    End Sub

'    Private Sub ShowCatagoryByUser(ByVal inputString As String)
'        Dim msg As String = ""
'        msg = VerifySnData(inputString, FunctionCodeId)
'        If msg <> "" Then
'            lblMsg.Text = msg
'            Exit Sub
'        End If
'        Me.ScanerUserId = inputString
'        '显示当天的扫描记录
'        LoadScaningData(Me.ScanerUserId)
'        '显示扫描任务
'        ShowScanTask(1)
'        '设置扫描进度
'        SetScanProcess(1)
'        dgvVerifyTask.Rows.Clear()
'        ' ShowSopImage()
'        Me.PictureBox1.Image = Nothing
'        Me.PictureBox1.Visible = False
'        'Me.Chart1.Visible = False
'        Me.dgvRunCard.Visible = False
'        lblStandard.Text = ""
'        lblStationName.Text = "Working In Process"
'        pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
'    End Sub

'    Private Sub DoProcess(ByVal inputString As String, ByVal functionId As Integer)
'        'Dim msg As String = ""
'        'msg = VerifySnData(inputString, FunctionCodeId)
'        'If msg <> "" Then
'        '    lblMsg.Text = msg
'        '    Exit Sub
'        'End If
'        ParseSnData(inputString)
'        Me.dgvScaningData.DataSource = Nothing
'        Me.ShowSopImage()
'        Me.PictureBox1.Visible = True
'        ShowScanTask(2)
'        SetScanProcess(2)
'        ShowVerifyTask(Me.PartId, Me.StationId)
'        ShowAllStation()
'    End Sub

'    Private Function CheckVersion() As Boolean
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        'Dim oConn As OracleDb
'        Dim zPn As String = Nothing
'        'Dim pPn As String = Nothing
'        Dim version As String = Nothing
'        Dim format As String = Nothing
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT 1 FROM M_RUNCARD_T A,M_MAINMO_T B" & vbNewLine & _
'            " WHERE A.PARTID=" & Me.PartId & " AND B.MOID='" & Me.WorkOrder & "' AND A.DRAWINGVER=B.VERSION"
'            'oConn = New OracleDb("")
'            'Dim sql = "SELECT TOP 1 A.PARTNUMBER,B.DRAWINGVER " & vbNewLine & _
'            '" FROM M_PARTNUMBER_T A,M_RUNCARD_T B " & vbNewLine & _
'            '" WHERE A.ID=B.PARTID AND B.PARTID=" & Me.PartId & " AND B.STATUS=1"
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count <= 0 Then
'                    lblMsg.Text = "工单版本与BOM不一致,请确认！！"
'                    Return False
'                Else
'                    Return True
'                End If
'            End Using
'            'sql = "SELECT TOP 1 A.PARTNUMBER FROM M_MAINMO_T A,M_MIANMO_T B WHERE A.MOID=B.PARENTMO AND A.MOID=A.PARENTMO AND B.MOID='" & Me.WorkOrder & "'"
'            'Using dt As DataTable = sConn.GetDataTable(sql)
'            '    If dt.Rows.Count > 0 Then
'            '        pPn = dt.Rows(0)("PARTNUMBER").ToString
'            '    End If
'            'End Using
'            'sql = "SELECT IMA021 FROM IMA_FILE WHERE IMA01='" & zPn & "' AND ROWNUM=1"
'            'Dim retur = oConn.ExecuteScalar(sql)
'            'If Not retur Is Nothing Then format = retur.ToString
'            'If Not String.IsNullOrEmpty(retur) Then
'            '    If (format.Split("-").Length > 1) Then
'            '        If Not version.Trim.ToUpper = format.Split("-")(format.Split("-").Length - 1).Trim.ToUpper Then
'            '            lblMsg.Text = "工单版本与BOM不一致"
'            '            Return False
'            '        Else
'            '            Return True
'            '        End If
'            '    ElseIf format.Trim.ToUpper <> version.Trim.ToUpper Then
'            '        lblMsg.Text = "工单版本与BOM不一致"
'            '        Return False
'            '    End If
'            'Else
'            '    lblMsg.Text = "料号{" & zPn & "}不存在于Titop"
'            '    Return False
'            'End If
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'            'If Not oConn Is Nothing Then
'            '    oConn = Nothing
'            'End If
'        End Try
'    End Function

'    Private Function CheckRouting(ByVal input As String) As Boolean
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Using dt As DataTable = sConn.GetDataTable("SELECT TOP 1 SERIALNUMBER FROM M_LOTUNIT_T WHERE SERIALNUMBER='" & input & "'")
'                If dt.Rows.Count > 0 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function

'    Private Function GetFaiIPQC(ByVal input As String)
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Using dt As DataTable = sConn.GetDataTable("SELECT TOP 1 A.IPQC,B.USERID FROM M_LOTUNITFAI_T A LEFT JOIN M_LOTUNIT_T B ON  A.SERIALNUMBER=B.SERIALNUMBER  WHERE A.SERIALNUMBER='" & input & "' ")
'                If dt.Rows.Count > 0 Then
'                    Me.ScanerUserId = dt.Rows(0)("USERID").ToString
'                    Return dt.Rows(0)("IPQC").ToString
'                Else
'                    Return ""
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function

'    Private Function IsIPQC(ByVal inputString As String)
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Using dt As DataTable = sConn.GetDataTable("SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND GROUPID='IPQC'")
'                If dt.Rows.Count > 0 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try

'    End Function

'    Private Function CheckIsUserID(ByVal inputString As String)
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Using dt As DataTable = sConn.GetDataTable("SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND GROUPID<>'IPQC'")
'                If dt.Rows.Count > 0 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function

'    Private Function CheckIsMO(ByVal inputString As String) As Boolean
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT MOID FROM M_MAINMO_T WHERE MOID='" & inputString & "'"
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function

'    Private Sub UpdateFAI()
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            sConn.ExecuteNonQuery("UPDATE m_LotUnitfai_t SET OPERATORUSERNAME='" & Me.ScanerUserId & "'where SerialNumber='" & Me.SerialNumber & "' and PartID='" & Me.PartId & "' and StationID='" & Me.StationId & "'")
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Sub

'    Private Sub ResetScanParm()
'        scanP.isInProcess = False
'        scanP.isCheckIPQC = False
'        scanP.isFunctionBarcode = False
'        scanP.isCheckUserId = False
'        scanP.isPnCheckFinish = False
'        scanP.functionBarcode = ""
'        scanP.isDoFAI = False
'    End Sub

'    Private Function UserDoWork() As Boolean
'        Dim DAL As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
'        Try
'            Dim StrSql As String = "select top 1 1 from m_LotUnit_t(nolock) where SerialNumber='" & Me.SerialNumber & "' and PartID=" & Me.PartId & " and StationID=" & Me.StationId
'            Using dt As DataTable = DAL.GetDataTable(StrSql)
'                If dt.Rows.Count > 0 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        Catch ex As Exception
'            Throw ex
'        Finally
'            If Not DAL Is Nothing Then
'                DAL = Nothing
'            End If
'        End Try

'    End Function

'    Private Function GetNextStation() As Integer
'        Dim result As Integer = 0
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            '    Dim sql As String = "SELECT TOP 1 C.STATIONID FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B,M_RUNCARDDETAIL_T C " & vbNewLine & _
'            '" WHERE A.PARTID='" & Me.PartId & "'" & vbNewLine & _
'            '" AND A.ID=B.RUNCARDID" & vbNewLine & _
'            '" AND A.STATUS=1" & vbNewLine & _
'            '" AND B.STATUS=1" & vbNewLine & _
'            '" AND B.STATIONID=" & Me.StationId & "" & vbNewLine & _
'            '" AND A.ID=C.RUNCARDID " & vbNewLine & _
'            '" AND C.STATUS=1" & vbNewLine & _
'            '" AND C.STATIONSQ=B.STATIONSQ+1"

'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim param1 As New SqlParameter("@PARTID", SqlDbType.VarChar, 50, ParameterDirection.Input)
'            Dim param3 As New SqlParameter("@INPUTSTATIONID", SqlDbType.VarChar, 50, ParameterDirection.Input)
'            Dim param2 As New SqlParameter("@STATIONID", SqlDbType.VarChar, 50)
'            '参数赋值
'            ' param2.Value = 0
'            param1.Value = Me.PartId
'            param3.Value = Me.StationId
'            param2.Direction = ParameterDirection.Output
'            Dim Paramters As SqlParameter() = Nothing
'            Paramters = New SqlParameter() {param1, param3, param2}
'            sConn.ExecuteNonQureyByProc("GetNextStation", Paramters)
'            If TypeOf param2.Value Is DBNull Then
'                Return 0
'            Else
'                Return CInt(param2.Value.ToString)
'            End If
'            'Using dt As DataTable = sConn.GetDataTable(sql)
'            '    If dt.Rows.Count > 0 Then
'            '        result = dt.Rows(0)(0)
'            '            End If
'            '        End Using
'            'Return result
'        Catch ex As Exception
'            lblMsg.Text = ex.Message
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Function

'    Private Function GetNextStationName(ByVal stationId As Integer) As String
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = "SELECT STATIONNAME FROM M_STATION_T WHERE ID=" & stationId & ""
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                If dt.Rows.Count > 0 Then
'                    Return dt.Rows(0)(0)
'                End If
'            End Using
'            Return ""
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try

'    End Function

'    Private Sub ShowAllStation()
'        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
'            Dim sql As String = " SELECT  " & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 1 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS1," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 2 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS2," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 3 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS3," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 4 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS4," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 5 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS5," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 6 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS6," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 7 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS7," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 8 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS8," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 9 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS9," & vbNewLine & _
'" MAX(CASE WHEN ID % 10 = 0 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS10" & vbNewLine & _
'" FROM(" & vbNewLine & _
'" SELECT ROW_NUMBER() OVER( ORDER BY A.STATIONSQ) ID ," & vbNewLine & _
'" CEILING((ROW_NUMBER() OVER( ORDER BY A.STATIONSQ)+0.0)/10) RID ," & vbNewLine & _
'" CASE  " & vbNewLine & _
'" WHEN A.IPQC IS NULL THEN N'未检'" & vbNewLine & _
'" WHEN A.IPQC IS NOT NULL AND A.USERID IS NULL THEN N'已检'" & vbNewLine & _
'" ELSE N'已录' END STATUS" & vbNewLine & _
'" FROM ( " & vbNewLine & _
'" SELECT DISTINCT B.STATIONSQ,C.IPQC,D.USERID" & vbNewLine & _
'" FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B" & vbNewLine & _
'" LEFT JOIN M_LOTUNITFAI_T  C " & vbNewLine & _
'" ON  B.STATIONID=C.STATIONID" & vbNewLine & _
'" AND C.PARTID=" & Me.PartId & "" & vbNewLine & _
'" AND C.WORKORDER='" & Me.WorkOrder & "' " & vbNewLine & _
'" LEFT JOIN M_LOTUNIT_T D" & vbNewLine & _
'" ON C.SERIALNUMBER=D.SERIALNUMBER" & vbNewLine & _
'"             WHERE(A.ID = B.RUNCARDID)" & vbNewLine & _
'" AND A.PARTID=" & Me.PartId & "" & vbNewLine & _
'" ) A )A GROUP BY RID"
'            dgvStationStaus.Rows.Clear()
'            Using dt As DataTable = sConn.GetDataTable(sql)
'                For Each row As DataRow In dt.Rows
'                    dgvStationStaus.Rows.Add(row(StatusEnum.Status1).ToString, row(StatusEnum.Status2).ToString, row(StatusEnum.Status3).ToString, row(StatusEnum.Status4).ToString, row(StatusEnum.Status5).ToString, row(StatusEnum.Status6).ToString, row(StatusEnum.Status7).ToString, row(StatusEnum.Status8).ToString, row(StatusEnum.Status9).ToString, row(StatusEnum.Status10).ToString)
'                Next
'            End Using
'            If dgvStationStaus.Rows.Count > 0 Then
'                SetStatusColor((Panel2.Height - 22) / dgvStationStaus.Rows.Count)
'                dgvStationStaus.ClearSelection()
'                Panel2Show()
'            End If
'        Catch ex As Exception
'            Throw
'        Finally
'            If Not sConn Is Nothing Then
'                sConn = Nothing
'            End If
'        End Try
'    End Sub

'    Private Sub txtAction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAction.KeyPress
'        Try
'            If Asc(e.KeyChar) = 13 Then
'                If txtAction.Text = "RESET" Then
'                    ResetScanParm()
'                    txtInput.Select()
'                    txtInput.SelectAll()
'                    lblMsg.Text = "重置成功,请继续"
'                    txtAction.Text = "辅助功能"
'                ElseIf txtAction.Text = "SPLIT" Then
'                    Try
'                        Dim frmSplit As New FrmLotSplit()
'                        frmSplit.ShowDialog()
'                        txtInput.Select()
'                        txtInput.SelectAll()
'                        txtAction.Text = "辅助功能"
'                    Catch ex As Exception
'                        txtInput.Select()
'                        txtInput.SelectAll()
'                        lblMsg.Text = ex.Message
'                        txtAction.Text = "辅助功能"
'                    End Try
'                    lblMsg.Text = "拆分成功,请继续"
'                    txtAction.Text = "辅助功能"
'                Else
'                    txtInput.Select()
'                    txtInput.SelectAll()
'                    lblMsg.Text = "系统不是别的条码，请确认"
'                    txtAction.Text = "辅助功能"
'                End If
'            End If
'        Catch ex As Exception
'            txtInput.Select()
'            txtInput.SelectAll()
'            lblMsg.Text = ex.Message
'            txtAction.Text = "辅助功能"
'        End Try
'    End Sub

'    Public Sub FunctionAssign(ByVal input As String)
'        Try
'            If input = "RESET" Then
'                ResetScanParm()
'                txtInput.Select()
'                txtInput.SelectAll()
'                lblMsg.Text = "重置成功,请继续"
'                txtAction.Text = "辅助功能"
'            ElseIf input = "SPLIT" Then
'                Try
'                    Dim frmSplit As New FrmLotSplit()
'                    frmSplit.ShowDialog()
'                    ResetScanParm()
'                    txtInput.Select()
'                    txtInput.SelectAll()
'                Catch ex As Exception
'                    txtInput.Select()
'                    txtInput.SelectAll()
'                    lblMsg.Text = ex.Message
'                End Try
'                lblMsg.Text = "拆分成功,请继续"
'            Else
'                txtInput.Select()
'                txtInput.SelectAll()
'                lblMsg.Text = "系统不是别的辅助条码，请确认"
'            End If
'        Catch ex As Exception
'            txtInput.Select()
'            txtInput.SelectAll()
'            lblMsg.Text = ex.Message
'        End Try
'    End Sub

'    Private tipText As New System.Text.StringBuilder
'    Private rowLength As Integer = 30
'    Private totalLength As Integer = 0
'    Private startIndex As Integer = 0
'    Private Sub dgvRunCard_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles dgvRunCard.CellToolTipTextNeeded
'        If e.ColumnIndex = -1 OrElse e.RowIndex = -1 Then
'            Return
'        End If
'        If e.ColumnIndex <> 4 AndAlso e.ColumnIndex <> 5 AndAlso e.ColumnIndex <> 6 Then
'            Return
'        End If
'        If tipText.Length > 0 Then
'            tipText.Remove(0, tipText.Length)
'        End If
'        If dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
'            Return
'        End If
'        If String.IsNullOrEmpty(dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) Then
'            Return
'        End If

'        tipText.Append(dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
'        totalLength = tipText.Length
'        If totalLength > rowLength Then
'            startIndex = rowLength
'            For i As Integer = 0 To totalLength / rowLength
'                If startIndex > totalLength Then
'                    Exit For
'                End If
'                tipText.Insert(startIndex, vbNewLine)
'                startIndex += rowLength + 2
'            Next
'        End If
'        e.ToolTipText = tipText.ToString()
'    End Sub

'    Private Enum StatusEnum
'        Status1 = 0
'        Status2
'        Status3
'        Status4
'        Status5
'        Status6
'        Status7
'        Status8
'        Status9
'        Status10
'    End Enum

'    Private Sub SetStatusColor(ByVal height As Integer)
'        If dgvStationStaus.Rows.Count > 0 Then
'            For Each row As DataGridViewRow In dgvStationStaus.Rows
'                row.Height = height
'                If Not row.Cells(StatusEnum.Status1).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status1).Value) Then
'                    If row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status1).Value = row.Cells(StatusEnum.Status1).Value.ToString.Substring(0, row.Cells(StatusEnum.Status1).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status2).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status2).Value) Then
'                    If row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status2).Value = row.Cells(StatusEnum.Status2).Value.ToString.Substring(0, row.Cells(StatusEnum.Status2).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status3).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status3).Value) Then
'                    If row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status3).Value = row.Cells(StatusEnum.Status3).Value.ToString.Substring(0, row.Cells(StatusEnum.Status3).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If


'                If Not row.Cells(StatusEnum.Status4).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status4).Value) Then
'                    If row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status4).Value = row.Cells(StatusEnum.Status4).Value.ToString.Substring(0, row.Cells(StatusEnum.Status4).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status5).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status5).Value) Then
'                    If row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status5).Value = row.Cells(StatusEnum.Status5).Value.ToString.Substring(0, row.Cells(StatusEnum.Status5).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status6).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status6).Value) Then
'                    If row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status6).Value = row.Cells(StatusEnum.Status6).Value.ToString.Substring(0, row.Cells(StatusEnum.Status6).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status7).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status7).Value) Then
'                    If row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status7).Value = row.Cells(StatusEnum.Status7).Value.ToString.Substring(0, row.Cells(StatusEnum.Status7).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status8).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status8).Value) Then
'                    If row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status8).Value = row.Cells(StatusEnum.Status8).Value.ToString.Substring(0, row.Cells(StatusEnum.Status8).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status9).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status9).Value) Then
'                    If row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status9).Value = row.Cells(StatusEnum.Status9).Value.ToString.Substring(0, row.Cells(StatusEnum.Status9).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If

'                If Not row.Cells(StatusEnum.Status10).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status10).Value) Then
'                    If row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
'                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.White
'                    ElseIf row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
'                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.Yellow
'                    ElseIf row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
'                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.LimeGreen
'                    End If
'                    row.Cells(StatusEnum.Status10).Value = row.Cells(StatusEnum.Status10).Value.ToString.Substring(0, row.Cells(StatusEnum.Status10).Value.ToString.IndexOf("."))
'                Else
'                    Exit For
'                End If
'            Next
'        End If
'    End Sub
'End Class



'Public Class ScanParam
'    Public isInProcess As Boolean = False
'    Public isFunctionBarcode As Boolean = False
'    Public isCheckUserId As Boolean = False
'    Public isCheckIPQC As Boolean = False
'    Public isPnCheckFinish As Boolean = False
'    Public functionBarcode As String = ""
'    Public isDoFAI As Boolean = False
'End Class
#End Region

Public Class FrmLotScan
    Private Shared rowSpan As New SortedList()
    Private Shared rowValue As String = ""
    Dim scanP As New ScanParam
    Dim cellValue As String = ""
    Dim totalQty As Integer = 0
    Dim LicenceCode As String
    ''' <summary>
    ''' 当前
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LotStatus
        Waiting '等待扫描
        Scaning '扫描进行中
        Done    '扫描完成
    End Enum
    ''' <summary>
    ''' 功能条码类别
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FunctionSNType
        WO      '工单条码
        Station '工站条码
        UserID  '工号条码
    End Enum

#Region "属性"

#Region "扫描状态"
    Private _scanStatus As LotStatus
    Public Property ScanStatus() As LotStatus
        Get
            Return _scanStatus
        End Get
        Set(ByVal value As LotStatus)
            _scanStatus = value
        End Set
    End Property
#End Region

#Region "条码类型"
    Private _SNType As FunctionSNType
    Public Property SNType() As FunctionSNType
        Get
            Return _SNType
        End Get
        Set(ByVal value As FunctionSNType)
            _SNType = value
        End Set
    End Property
#End Region

#Region "扫描步骤"
    Private _scanStep As Integer
    Public Property ScanStep() As Integer
        Get
            Return _scanStep
        End Get
        Set(ByVal value As Integer)
            _scanStep = value
        End Set
    End Property
#End Region

#Region "功能条码"
    Private _fnCode As Integer
    Public Property FunctionCodeId() As Integer
        Get
            Return _fnCode
        End Get
        Set(ByVal value As Integer)
            _fnCode = value
        End Set
    End Property
#End Region

#Region "员工工号"
    Private _userId As String
    Public Property ScanerUserId() As String
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property
#End Region

#Region "IPQC工号"
    Private _ipqcId As String
    Public Property IpqcUserId() As String
        Get
            Return _ipqcId
        End Get
        Set(ByVal value As String)
            _ipqcId = value
        End Set
    End Property
#End Region

#Region "员工姓名"
    Private _userName As String
    Public Property ScanerUserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
#End Region

#Region "IPQC姓名"
    Private _ipqcName As String
    Public Property IpqcUserName() As String
        Get
            Return _ipqcName
        End Get
        Set(ByVal value As String)
            _ipqcName = value
        End Set
    End Property
#End Region

#Region "工站ID"
    Private _stationId As Integer
    Public Property StationId() As Integer
        Get
            Return _stationId
        End Get
        Set(ByVal value As Integer)
            _stationId = value
        End Set
    End Property
#End Region

#Region "工站序号"
    Private _stationSQ As Integer
    Public Property StationSQ() As Integer
        Get
            Return _stationSQ
        End Get
        Set(ByVal value As Integer)
            _stationSQ = value
        End Set
    End Property
#End Region

#Region "工站名称"
    Private _stationName As String
    Public Property StationName() As String
        Get
            Return _stationName
        End Get
        Set(ByVal value As String)
            _stationName = value
        End Set
    End Property
#End Region

#Region "工站顺序"
    Private _Id As String
    Public Property SID() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
#End Region

#Region "序列号"
    Private _sn As String
    Public Property SerialNumber() As String
        Get
            Return _sn
        End Get
        Set(ByVal value As String)
            _sn = value
        End Set
    End Property
#End Region

#Region "工单编号"
    Private _workOrder As String
    Public Property WorkOrder() As String
        Get
            Return _workOrder
        End Get
        Set(ByVal value As String)
            _workOrder = value
        End Set
    End Property
#End Region

#Region "配置数"
    Private _configQty As String
    Public Property ConfigQty() As String
        Get
            Return _configQty
        End Get
        Set(ByVal value As String)
            _configQty = value
        End Set
    End Property
#End Region

#Region "料件ID"
    Private _partId As Integer
    Public Property PartId() As Integer
        Get
            Return _partId
        End Get
        Set(ByVal value As Integer)
            _partId = value
        End Set
    End Property
#End Region

#Region "工单料号"
    Private _woPn As String
    Public Property WoPn() As String
        Get
            Return _woPn
        End Get
        Set(ByVal value As String)
            _woPn = value
        End Set
    End Property
#End Region

#Region "工单数量"
    Private _woQty As Integer
    Public Property WoQty() As Integer
        Get
            Return _woQty
        End Get
        Set(ByVal value As Integer)
            _woQty = value
        End Set
    End Property
#End Region

#Region "品质报表类型"
    Private _reportType As String
    Public Property ReportType() As String
        Get
            Return _reportType
        End Get
        Set(ByVal value As String)
            _reportType = value
        End Set
    End Property
#End Region
#End Region

    Private Sub FrmLotScan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub

    Private Sub FrmLotScan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not dt Is Nothing Then
            dt.Dispose()
            dt = Nothing
        End If
    End Sub

    Private Sub FrmLotScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        IniteScan()
        '
        Me.lblPass.Text = ""
        Me.dgvScanTask.AutoGenerateColumns = False

        ShowSampleChart()

        Panel2Hide()
        '
        'Me.PictureBox1.Visible = False
        'Me.Chart1.Visible = False
        'ShowChart()
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub

    Private Sub Panel2Hide()
        For Each con As Control In Panel2.Controls
            con.Visible = False
        Next
    End Sub
    Private Sub Panel2Show()
        For Each con As Control In Panel2.Controls
            con.Visible = True
        Next
    End Sub

#Region "加载扫描数据"
    Private Sub LoadScaningData(ByVal userId As String)
        Dim DAL As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            DAL = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim strSql As String = "select ROW_NUMBER() OVER(ORDER BY UN.INTIME DESC) 序号, UN.WorkOrder 工单,PN.PartNumber 料件编号," & _
                                "ST.StationName 工站,ISNULL(SP.QTY,UN.Qty) 生产数量,ISNULL(SP.USERID,UN.UserID) 工号,US.UserName 姓名 ,UN.InTime 扫描时间,'' 备注 " & _
                                "from m_RUNCARDLotUnit_t(nolock) UN LEFT JOIN M_RUNCARDLOTSPLIT_T SP ON UN.ID=SP.LOTUNITID " & _
                                "join m_RUNCARDPartNumber_t(nolock) PN on UN.PartID=PN.ID " & _
                                "join m_RUNCARDStation_t(nolock) ST on UN.StationID=ST.ID " & _
                                "join m_Users_t(nolock) US on ISNULL(SP.USERID,UN.UserID)=US.UserID " & _
                                "where ISNULL(SP.USERID,UN.UserID)='" & userId & "' and convert(nvarchar(50),UN.InTime,12)=convert(nvarchar(50),getdate(),12) " '& _
            '"order by Un.InTime ;"
            Dim sqlSummary As String = "select SUM(ISNULL(B.QTY,A.QTY)) TotalQty from m_RUNCARDLotUnit_t(nolock) A LEFT JOIN M_RUNCARDLOTSPLIT_T B ON A.ID=B.LOTUNITID " & _
                                       "where ISNULL(B.USERID,A.UserID)='" & userId & "' and convert(nvarchar(50),A.InTime,12)=convert(nvarchar(50),getdate(),12);"
            Dim ds As DataSet = DAL.GetDataSet(strSql & vbNewLine & sqlSummary)
            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dtSummary As DataTable = ds.Tables(1)
                    If dtSummary.Rows.Count > 0 Then
                        rowSpan.Clear()
                        totalQty = CInt(dtSummary.Rows(0)(0).ToString)
                        '添加一空行(汇总)
                        dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    End If
                End If
                dgvScaningData.DataSource = dt
                dgvScaningData.Columns("备注").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '禁止排序
                For Each column As DataGridViewColumn In dgvScaningData.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End If

        Catch ex As Exception
            Throw
        Finally
            If Not DAL Is Nothing Then
                DAL = Nothing
            End If
        End Try
    End Sub
#End Region

#Region "作业扫描"
    Private Function DoWorkScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String

        Dim msg As String
        '第一步：扫描工号
        If Me.ScanStep = 1 Then

            '校验功能条码
            msg = VerifySnData(strInput, functionCodeId)
            If msg <> "" Then
                Return msg
            End If
            Me.ScanerUserId = strInput
            '显示当天的扫描记录
            LoadScaningData(Me.ScanerUserId)
            '显示扫描任务
            ShowScanTask(1)
            '设置扫描进度
            SetScanProcess(1)
            '显示下一个扫描提示
            ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))

        ElseIf Me.ScanStep = 2 Then  '第二步：扫描工站条码

            '显示条码格式
            'Me.lblFormat.Text = "条码格式:" + GetSNFormat(2)
            '校验工站条码格式
            If CheckSNFormat(strInput, 2) = "" Then
                Return "工站条码""" + strInput + """ 格式不正确"
            End If
            '显示该工位Sop
            ShowSopImage()
            '解析工站条码格式
            ParseSnData(strInput)
            '校验工站，流程卡，工单信息
            msg = VerifySnData(strInput, 2)
            If msg <> "" Then
                Return msg
            End If
            '设置扫描进度
            SetScanProcess(2)
            '保存扫描数据
            msg = SaveScanData(strInput)
            If msg <> "" Then
                ''显示工艺程流程图表
                'ShowRunCardChart()
                Return msg
            End If
            Me.lblPass.Text = "PASS"
            '刷新显示
            LoadScaningData(Me.ScanerUserId)
            '初始化扫描
            IniteScan()
            Return ""
        End If
        Me.ScanStep = Me.ScanStep + 1
        Return ""
    End Function
#End Region

#Region "首检扫描"
    Private Function DoFaiScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String
        Dim msg As String

        '第一步：扫描工站条码
        If Me.ScanStep = 1 Then

            '校验功能条码
            msg = VerifySnData(strInput, functionCodeId)
            If msg <> "" Then
                Return msg
            End If
            ParseSnData(strInput)
            Me.ShowSopImage()
            If HasDoneFAI() Then
                Return "已做过首检,请勿重复"
            End If
            '
            ShowScanTask(2)
            SetScanProcess(2)
            ShowVerifyTask(Me.PartId, Me.StationId)
            '
            If Me.dgvVerifyTask.Rows.Count <= 0 Then
                '跳过 第二步
                Me.ScanStep = 2
            End If
            '显示下一个扫描提示
            ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))

        ElseIf Me.ScanStep = 2 Then '第二步:扫描线材料号或治具编号

            '校验线材, 治具
            msg = VerifyPn(strInput, Me.PartId, Me.StationId, Me.WoQty)
            If msg <> "" Then
                Return msg
            End If
            '设置扫描进度
            SetVerifyProcess(strInput)
            '"校验"是否完成
            If VerifyIsFinish() Then
                '显示下一个扫描提示
                ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))
            Else
                Me.txtInput.Text = ""
                Me.txtInput.Focus()
                Return ""
            End If

        ElseIf Me.ScanStep = 3 Then '第三步:操作员确认

            msg = VerifySnData(strInput, 1)
            If msg <> "" Then
                Return msg
            End If
            Me.ScanerUserId = strInput
            '更新扫描进度
            SetScanProcess(1)
            '作业员确认
            If OperatorIsConfirm() Then
                '显示下一个扫描提示
                ShowTips(GetTips(Me.FunctionCodeId, Me.ScanStep))
            Else
                Me.txtInput.Text = ""
                Me.txtInput.Focus()
                Return ""
            End If
        ElseIf Me.ScanStep = 4 Then  '第三步:IPQC 确认

            msg = VerifySnData(strInput, 4)
            If msg <> "" Then
                Return msg
            End If
            Me.IpqcUserId = strInput
            '更新扫描进度
            SetScanProcess(3)
            'IPQC确认
            If IpqcIsConfirm() Then
                '保存数据
                SaveFAIData()
                Me.lblPass.Text = "PASS"
                '初始化扫描
                IniteScan()
                Return ""
            End If
        End If
        Me.ScanStep = Me.ScanStep + 1
        Return ""
    End Function



#End Region

#Region "工单扫描"
    Private Function DoWoScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String

        Me.dgvRunCard.Visible = True
        Me.PictureBox1.Visible = False

        ShowScanTask(Me.FunctionCodeId)
        GetMoInfo(strInput)
        Me.ConfigQty = GetMoConfigQty()
        SetScanProcess(Me.FunctionCodeId)
        '显示流程卡
        'Me.dgvRunCard.Rows.Clear()
        Me.dgvRunCard.DataSource = Nothing
        Me.dgvRunCard.VirtualMode = False
        ShowRunCard(strInput)
        lblStandard.Text = ""
        lblStationName.Text = "Working In Process"
        pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
        Return ""
    End Function

    Private Sub GetMoInfo(ByVal mo As String)
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT MOID,MOQTY,PARTID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & mo & "'"
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Me.WoPn = dt.Rows(0)(2).ToString
                    Me.WoQty = dt.Rows(0)(1).ToString
                    Me.WorkOrder = dt.Rows(0)(0).ToString
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

    End Sub

#End Region

    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                'Dim err As String = ""
                'Me.lblPass.Text = ""
                Dim strInput As String = txtInput.Text.Trim.ToUpper
                'If String.IsNullOrEmpty(strInput) Then
                '    Exit Sub
                'End If
                'If Me.ScanStep = 0 Then
                '    '功能条码(m_FunctionCode_t)
                '    Me.FunctionCodeId = Me.GetFunctionCodeID(strInput)
                '    If Me.FunctionCodeId <= 0 Then
                '        ShowError("功能条码格式不正确、请确认(udpGetFunctionID)!")
                '        Exit Sub
                '    End If
                '    Me.ScanStep = Me.ScanStep + 1
                'End If
                'Select Case Me.FunctionCodeId
                '    Case 1
                '        err = DoWorkScaning(strInput, Me.FunctionCodeId)
                '    Case 2
                '        err = DoFaiScaning(strInput, Me.FunctionCodeId)
                '    Case 3
                '        err = DoWoScaning(strInput, Me.FunctionCodeId)
                'End Select
                'If err <> "" Then
                '    ShowError(err)
                '    Exit Sub
                'End If
                If String.IsNullOrEmpty(strInput.Trim) Then
                    lblMsg.Text = "扫描错误，请确认！！"
                    Exit Sub
                End If
                If strInput.ToUpper = "RESET" OrElse strInput.ToUpper = "SPLIT" Then
                    FunctionAssign(strInput.ToUpper)
                    Exit Sub
                End If
                CheckInputType(strInput)
                txtInput.Text = ""
                txtInput.Focus()
            End If
        Catch ex As Exception
            txtInput.Text = ""
            txtInput.Focus()
            SysMessageClass.WriteErrLog(ex, "FrmLotScan", "txtInput_KeyPress", "WIPS")
        End Try
    End Sub

#Region "ShowError"
    Private Sub ShowError(ByVal err As String)
        Me.lblMsg.Text = err
        Me.lblPass.Text = ""
        'Me.lblFormat.Text = ""
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
        'Me.ScanStatus = LotStatus.Waiting
        'Me.lblTips.Text = "请扫描"
        'Me.lblStationName.Text = "Working In Process System"
        'Me.dgvScanTask.Rows.Clear()
        'Me.dgvVerifyTask.Rows.Clear()
    End Sub
#End Region

#Region "ShowTips"
    Private Sub ShowTips(ByVal tips As String)
        Me.lblTips.Text = tips
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
        Me.lblMsg.Text = ""
        'Me.lblFormat.Text = ""
    End Sub
#End Region

#Region "取工站名称"
    Private Function GetTips(ByVal functionCodeId As Integer, ByVal scanStep As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select ScanTips from m_RUNCARDScanTips_t(nolock) where FunctionCodeID=" & functionCodeId & " and ScanStep=" & scanStep
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            End If
        End Using
        Return ""
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        'If reader.HasRows Then
        '    reader.Read()
        '    Return reader.Item(0).ToString()
        'Else
        '    reader.Close()
        '    Return ""
        'End If
    End Function
#End Region

#Region "校验条码数据"
    Private Function VerifySnData(ByVal sn As String, ByVal snType As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '参数定义
        Dim param1 As New SqlParameter("@SerialNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@SnType", SqlDbType.Int, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = snType
        param3.Direction = ParameterDirection.Output '?指定
        param3.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3}
        '执行SP
        Dim err As String = DAL.ExecuteNonQureyByProc("udpVerifySn", Paramters)

        If err <> "" Then
            Return err
        Else
            If TypeOf param3.Value Is DBNull Then
                Return ""
            Else
                Return param3.Value.ToString()
            End If
        End If
    End Function
#End Region

#Region "获取条码格式"
    Private Function GetSNFormat(ByVal functionCodeId As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '参数定义
        Dim param1 As New SqlParameter("@FunctionID", SqlDbType.Int, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@SNFormat", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = functionCodeId
        param2.Direction = ParameterDirection.Output '?指定
        param2.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2}
        '执行SP
        Dim err As String = DAL.ExecuteNonQureyByProc("udpGetSNFormat", Paramters)
        If err <> "" Then
            Return err
        Else
            If TypeOf param2.Value Is DBNull Then
                Return ""
            Else
                Return param2.Value.ToString()
            End If
        End If
    End Function

#End Region

#Region "校验条码格式"
    Private Function CheckSNFormat(ByVal sn As String, ByVal functionCodeId As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '参数定义
        Dim param1 As New SqlParameter("@Serialnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@FunctionID", SqlDbType.Int, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@SNFormat", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = functionCodeId
        param3.Direction = ParameterDirection.Output '?指定
        param3.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3}
        '执行SP
        Dim err As String = DAL.ExecuteNonQureyByProc("udpCheckSNFormat", Paramters)
        If err <> "" Then
            Return err
        Else
            If TypeOf param3.Value Is DBNull Then
                Return ""
            Else
                Return param3.Value.ToString()
            End If
        End If
    End Function

#End Region

#Region "保存扫描数据"
    Private Function SaveScanData(ByVal sn As String) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '参数定义
        Dim param1 As New SqlParameter("@SerialNumber ", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = Me.ScanerUserId
        param3.Direction = ParameterDirection.Output '?指定
        param3.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3}
        '执行SP
        Dim err As String = DAL.ExecuteNonQureyByProc("udpSaveScanData", Paramters)
        If err <> "" Then
            Return err
        Else
            If TypeOf param3.Value Is DBNull Then
                Return ""
            Else
                Return param3.Value.ToString()
            End If
        End If
    End Function

#End Region

#Region "取工站名称"
    Private dr() As DataRow
    Private Function GetStationNameById(ByVal stationId As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        ' Dim StrSql As String = "select top 1 StationName,SkillCode,ReportTypeCode from m_Station_t(nolock) where ID='" & stationId & "'"
        Dim StrSql As String = "SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID ,B.STATIONID,C.STATIONNAME,C.SkillCode,C.ReportTypeCode " & _
" FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B,M_RUNCARDSTATION_T C WHERE A.PARTID=" & Me.PartId & " AND A.ID=B.RUNCARDID AND B.STATIONID=C.ID"
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            dr = dt.Select("STATIONID='" & stationId & "'")
            If dr.Length > 0 Then
                LicenceCode = dr(0)("SkillCode").ToString
                _reportType = dr(0)("ReportTypeCode").ToString
                SID = dr(0)("ID").ToString
                Return dr(0)("STATIONNAME").ToString
            End If
        End Using
        Return ""
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        'If reader.HasRows Then
        '    reader.Read()
        '    Return reader.Item(0).ToString()
        'Else
        '    reader.Close()
        '    Return ""
        'End If
    End Function
#End Region

#Region "获取用户名"
    Private Function GetUserNameById(ByVal userId As String) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select top 1 UserName from m_Users_t(nolock) where UserID='" & userId & "'"
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            End If
        End Using
        Return ""
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        'If reader.HasRows Then
        '    reader.Read()
        '    Return reader.Item(0).ToString()
        'Else
        '    reader.Close()
        '    Return ""
        'End If
    End Function
#End Region

#Region "解析工单"
    Private Sub ParseWorkOrder(ByVal wo As String)
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select top 1 PartID,Moqty from M_RUNCARDWORKORDER_T(nolock) where Moid='" & wo & "'"
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then
                Me.WoPn = dt.Rows(0)(0).ToString
                Me.WoQty = dt.Rows(0)(1).ToString
            End If
        End Using
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        'If reader.HasRows Then
        '    reader.Read()
        '    Me.WoPn = reader.Item(0).ToString()
        '    Me.WoQty = reader.Item(1).ToString()
        'End If
    End Sub
#End Region

#Region "是否已做过首检"
    Private Function HasDoneFAI() As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select top 1 1 from m_RUNCARDLotUnitFAI_t(nolock) where SerialNumber='" & Me.SerialNumber & "' and PartID=" & Me.PartId & " and StationID=" & Me.StationId
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
#End Region

#Region "读取工站条码数据"
    Private Sub ParseSnData(ByVal sn As String)
        '条码格式:F/WorkId/PartId/StationId
        Me.SerialNumber = sn
        Dim StrArray As String() = sn.Split("/")
        Me.WorkOrder = StrArray(1).ToString
        Me.PartId = CInt(StrArray(2).ToString)
        Me.StationId = CInt(StrArray(3).ToString)
    End Sub

    Private Function GetStandard(ByRef remark As String, ByRef standard As String, ByRef desc As String) As Integer
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Dim stationSq As Integer = 1
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT REPLACE(REPLACE(PROCESSSTANDARD,CHAR(32),''),CHAR(13)+CHAR(10),'') PROCESSSTANDARD," & vbNewLine & _
"REPLACE(REPLACE(A.REMARK,CHAR(32),''),CHAR(13)+CHAR(10),'') REMARK,B.STATIONSQ, " & vbNewLine & _
"REPLACE(REPLACE(D.DESCRIPTION1,CHAR(32),''),CHAR(13)+CHAR(10),'') DESCRIPTION1" & vbNewLine & _
" FROM M_RUNCARD_T A " & vbNewLine & _
" JOIN M_RUNCARDDETAIL_T B" & vbNewLine & _
" ON A.ID=B.RUNCARDID " & vbNewLine & _
" LEFT JOIN M_RUNCARDPARTDETAIL_T C " & vbNewLine & _
" ON B.ID = C.RUNCARDDETAILID" & vbNewLine & _
" LEFT JOIN M_RUNCARDPARTNUMBER_T D" & vbNewLine & _
" ON   C.PARTID=D.ID" & vbNewLine & _
" AND ISNULL(D.TYPE,'R')='R'" & vbNewLine & _
" WHERE(A.PARTID = " & Me.PartId & ")" & vbNewLine & _
" AND B.STATIONID=" & Me.StationId & ""
            Using dt As DataTable = sConn.GetDataTable(sql)
                For Each row As DataRow In dt.Rows
                    remark = row("REMARK").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
                    standard = row("PROCESSSTANDARD").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
                    'desc += "规格：" + row("DESCRIPTION1").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "") + "。"
                    stationSq = row("STATIONSQ").ToString
                Next
            End Using
            'If Not String.IsNullOrEmpty(desc) Then desc = desc.Substring(0, desc.Length - 3)
            Return stationSq
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

    End Function

    Private Function GetMoConfigQty() As String
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT TOP 1 C.ID FROM M_RUNCARDWORKORDER_T A ,M_RUNCARDWORKORDER_T B,M_RUNCARDPARTNUMBER_T C WHERE A.PARENTMO=B.MOID AND B.PARTID=C.PARTNUMBER AND A.MOID='" & Me.WorkOrder & "'"
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    sql = "SELECT ISNULL(A.QTY,1) FROM M_RUNCARDBOMINFO_T A WHERE A.PARENTPARTID='" & dt.Rows(0)(0) & "' AND PARTID='" & Me.PartId & "'"
                    Using dt1 As DataTable = sConn.GetDataTable(sql)
                        If dt1.Rows.Count > 0 Then
                            Return dt1.Rows(0)(0).ToString
                        Else
                            Return 1
                        End If
                    End Using
                Else
                    Return 1
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "显示扫描任务"
    Private Sub ShowScanTask(ByVal functionCodeId As Integer)

        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select Item,Title from m_RUNCARDScanTask_t(nolock) where FunctionCodeID=" & functionCodeId & " and IsPrompt=0 "
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        dgvScanTask.Rows.Clear()
        'While reader.Read()
        '    dgvScanTask.Rows.Add(ImageList1.Images(0), reader.Item("Title").ToString(), "")
        'End While
        'reader.Close()
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            For Each row As DataRow In dt.Rows
                dgvScanTask.Rows.Add(ImageList1.Images(0), row(1), "")
            Next
        End Using

        'dgvScanTask.Columns("TaskContent").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub
#End Region

#Region "显示校验信息"
    Private Sub ShowVerifyTask(ByVal partId As Integer, ByVal stationId As Integer)
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "SELECT D.PARTNUMBER,E.RemainCount," & vbNewLine & _
" CASE " & vbNewLine & _
" WHEN E.RemainCount IS NULL THEN N'物料'" & vbNewLine & _
" ELSE N'工装' END TYPE " & vbNewLine & _
" FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B" & vbNewLine & _
",M_RUNCARDPARTNUMBER_T D,M_RUNCARDPARTDETAIL_T C" & vbNewLine & _
"LEFT JOIN (SELECT A.* FROM " & vbNewLine & _
"(" & vbNewLine & _
" SELECT B.PARTID,B.RemainCount," & vbNewLine & _
" ROW_NUMBER() OVER(PARTITION BY B.PARTID ORDER BY B.PARTID) ID " & vbNewLine & _
" FROM M_EQUIPMENT_T B" & vbNewLine & _
" ) A WHERE ID=1)E ON C.PARTID=E.PARTID " & vbNewLine & _
" WHERE(A.ID = B.RUNCARDID) " & vbNewLine & _
" AND B.ID=C.RUNCARDDETAILID" & vbNewLine & _
" AND C.PARTID=D.ID " & vbNewLine & _
" AND A.PARTID=" & partId & " " & vbNewLine & _
" AND B.STATIONID=" & stationId & " " & vbNewLine & _
" ORDER BY TYPE "
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        dgvVerifyTask.Rows.Clear()
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            For Each row As DataRow In dt.Rows
                dgvVerifyTask.Rows.Add(ImageList1.Images(0), row(2).ToString, row(0).ToString(), row(1).ToString(), "", "N")
            Next
        End Using
        'While reader.Read()
        '    dgvVerifyTask.Rows.Add(ImageList1.Images(0), reader.Item("TYPE").ToString(), reader.Item("PartNumber").ToString(), reader.Item("ProcessParameters").ToString(), "", "N")
        'End While
        'reader.Close()
    End Sub
#End Region

#Region "根据治具编号取得料号"
    Private Function GetPartNumberByEquipmentNo(ByVal sn As String) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select PartNumber from m_RUNCARDPartNumber_t(nolock) where id in(select PartID from m_Equipment_t(nolock) where EquipmentNo='" & sn & "')"
        'Dim reader As SqlClient.SqlDataReader = DAL.GetDataReader(StrSql)
        'If reader.HasRows Then
        '    reader.Read()
        '    Return reader.Item(0).ToString()
        'Else
        '    reader.Close()
        '    Return ""
        'End If
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then Return dt.Rows(0)(0)
        End Using
        Return ""
    End Function
#End Region

#Region "校验料号/治具编号"
    Private Function VerifyPn(ByVal input As String, ByVal partId As Integer, ByVal stationId As Integer, ByVal woQty As Integer) As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '参数定义
        Dim param1 As New SqlParameter("@sn", SqlDbType.NVarChar, 50, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@PartID", SqlDbType.Int, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@StationID", SqlDbType.Int, ParameterDirection.Input)
        Dim param4 As New SqlParameter("@WoQty ", SqlDbType.Int, ParameterDirection.Input)
        Dim param5 As New SqlParameter("@msg ", SqlDbType.NVarChar, 1000)
        '参数赋值
        param1.Value = input
        param2.Value = partId
        param3.Value = stationId
        param4.Value = woQty
        param5.Direction = ParameterDirection.Output '?指定
        param5.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3, param4, param5}
        '执行SP
        Dim err As String = DAL.ExecuteNonQureyByProc("udpVerifyPn", Paramters)
        If err <> "" Then
            Return err
        Else
            If TypeOf param5.Value Is DBNull Then
                Return ""
            Else
                Return param5.Value.ToString()
            End If
        End If
    End Function
#End Region

#Region "设置料号/治具编号列表"
    Private Sub SetVerifyTaskProcess()
        For Each row As DataGridViewRow In dgvVerifyTask.Rows
            row.Cells("ImageItem").Value = ImageList1.Images(1)
            row.Cells("PartNumber").Style.ForeColor = Color.Green
            row.Cells("ckVerifyFlag").Value = "Y"
            row.Cells("result").Style.ForeColor = Color.Blue
            row.Cells("result").Value = "正确"
        Next
    End Sub

    Private Sub SetVerifyProcess(ByVal input As String)
        If dgvVerifyTask.Rows.Count > 0 Then
            Dim eqPartNumber As String = GetPartNumberByEquipmentNo(input)
            If eqPartNumber <> "" Then '将治具编号转换成料号
                For Each row As DataGridViewRow In dgvVerifyTask.Rows
                    If row.Cells("ckVerifyFlag").Value.ToString = "N" Then
                        If row.Cells("PartNumber").Value.ToString() = eqPartNumber Then
                            row.Cells("ImageItem").Value = ImageList1.Images(1)
                            row.Cells("PartNumber").Value = input  '将料号替换成设备编号
                            row.Cells("PartNumber").Style.ForeColor = Color.Green
                            row.Cells("ckVerifyFlag").Value = "Y"
                            row.Cells("result").Style.ForeColor = Color.Blue
                            row.Cells("result").Value = "正确"
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In dgvVerifyTask.Rows
                    If row.Cells("ckVerifyFlag").Value.ToString = "N" Then
                        If row.Cells("PartNumber").Value.ToString() = input Then
                            row.Cells("ImageItem").Value = ImageList1.Images(1)
                            row.Cells("PartNumber").Style.ForeColor = Color.Green
                            row.Cells("ckVerifyFlag").Value = "Y"
                            row.Cells("result").Style.ForeColor = Color.Blue
                            row.Cells("result").Value = "正确"
                        End If
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#Region "校验任务是否完成"
    Private Function VerifyIsFinish() As Boolean
        If dgvVerifyTask.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvVerifyTask.Rows
                If row.Cells("ckVerifyFlag").Value = "N" Then
                    Return False
                End If
            Next
            Return True
        End If
    End Function
#End Region

#Region "作业员是否确认"
    Private Function OperatorIsConfirm() As Boolean
        If dgvScanTask.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvScanTask.Rows
                If row.Cells("TaskName").Value = "员工工号" Then
                    If row.Cells("ckScanFlag").Value = "N" Then
                        Return False
                    End If
                End If
            Next
            Return True
        End If
    End Function
#End Region

#Region "IPQC是否确认"
    Private Function IpqcIsConfirm() As Boolean
        If dgvScanTask.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvScanTask.Rows
                If row.Cells("TaskName").Value = "IPQC工号" Then
                    If row.Cells("ckScanFlag").Value = "N" Then
                        Return False
                    End If
                End If
            Next
            Return True
        End If
    End Function
#End Region

#Region "设置扫描进度"
    Private Sub SetScanProcess(ByVal taskType As Integer)
        Select Case taskType
            Case 1
                For Each row As DataGridViewRow In dgvScanTask.Rows
                    Select Case row.Cells("TaskName").Value.ToString()
                        Case "员工工号"
                            row.Cells("TaskContent").Value = Me.ScanerUserId
                            row.Cells("TaskContent").Style.ForeColor = Color.Green
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "员工姓名"
                            Me.ScanerUserName = Me.GetUserNameById(Me.ScanerUserId)
                            row.Cells("TaskContent").Value = Me.ScanerUserName
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                    End Select
                Next
            Case 2
                For Each row As DataGridViewRow In dgvScanTask.Rows
                    Select Case row.Cells("TaskName").Value.ToString()
                        Case "工站名称"
                            row.Cells("TaskContent").Value = Me.StationName
                            'row.Cells("TaskContent").Style.ForeColor = Color.Green
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单编号"
                            row.Cells("TaskContent").Value = Me.WorkOrder
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单料号"
                            row.Cells("TaskContent").Value = Me.WoPn
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单数量"
                            row.Cells("TaskContent").Value = Me.WoQty.ToString + " * " + Me.ConfigQty
                            row.Cells("TaskContent").Style.ForeColor = Color.Red
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                    End Select
                Next
            Case 3
                For Each row As DataGridViewRow In dgvScanTask.Rows
                    Select Case row.Cells("TaskName").Value.ToString()
                        'Case "员工工号"
                        '    row.Cells("TaskContent").Value = Me.ScanerUserName
                        '    row.Cells("TaskContent").Style.ForeColor = Color.Green
                        '    row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "IPQC工号"
                            Me.IpqcUserName = Me.GetUserNameById(Me.IpqcUserId)
                            row.Cells("TaskContent").Value = Me.IpqcUserName
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单编号"
                            row.Cells("TaskContent").Value = Me.WorkOrder
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单料号"
                            row.Cells("TaskContent").Value = Me.WoPn
                            row.Cells("TaskContent").Style.ForeColor = Color.Blue
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                        Case "工单数量"
                            row.Cells("TaskContent").Value = Me.WoQty.ToString + " * " + Me.ConfigQty
                            row.Cells("TaskContent").Style.ForeColor = Color.Red
                            row.Cells("ImageList").Value = ImageList1.Images(1)
                    End Select
                Next

        End Select

    End Sub
#End Region

#Region "保存首检数据"
    Private Sub SaveFAIData()
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = ""
        StrSql = StrSql & "DELETE FROM m_RUNCARDlotUnitFAI_t WHERE SERIALNUMBER='" & Me.SerialNumber & "' AND PARTID='" & Me.PartId & "' AND STATIONID='" & Me.StationId & "'"
        For Each row As DataGridViewRow In dgvVerifyTask.Rows
            StrSql = StrSql & "INSERT INTO m_RUNCARDlotUnitFAI_t(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC) values('" & _
                      Me.SerialNumber & "','" & Me.WorkOrder & "'," & Me.PartId & "," & Me.StationId & ",'" & row.Cells("PartNumber").Value.ToString & "',N'" & Me.ScanerUserName & "',N'" & Me.IpqcUserName & "',getdate() ,'" & Me.IpqcUserId & "'); "
        Next
        If dgvVerifyTask.Rows.Count = 0 Then
            StrSql = StrSql & "insert into m_RUNCARDlotUnitFAI_t(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC) values('" & _
                   Me.SerialNumber & "','" & Me.WorkOrder & "'," & Me.PartId & "," & Me.StationId & ",'',N'" & Me.ScanerUserName & "',N'" & Me.IpqcUserName & "',getdate(),'" & Me.IpqcUserId & "' ); "

        End If
        DAL.ExecSql(StrSql)
    End Sub
#End Region

#Region "功能条码"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Private Function GetFunctionCodeID(ByVal serialNumber As String) As Integer
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT TOP 1 1 ID FROM M_USERS_T WHERE USERID='" & serialNumber & "' UNION " & vbNewLine & _
        "SELECT TOP 1 3 ID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & serialNumber & "' UNION " & vbNewLine & _
        "SELECT TOP 1 2 ID WHERE '" & serialNumber & "' LIKE 'F/%/%/%' "
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)(0).ToString())
                End If
            End Using
            Return 0

        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

    End Function
    'Private Function GetFunctionCodeID(ByVal serialNumber As String) As Integer
    '    '
    '    Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
    '    '参数定义
    '    Dim param1 As New SqlParameter("@Serialnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
    '    Dim param2 As New SqlParameter("@FunctionID", SqlDbType.NVarChar, 200)
    '    '参数赋值
    '    param1.Value = serialNumber
    '    param2.Direction = ParameterDirection.Output '?指定
    '    param2.Value = Nothing
    '    Dim Paramters As SqlParameter() = Nothing
    '    Paramters = New SqlParameter() {param1, param2}
    '    '执行SP
    '    DAL.ExecuteNonQureyByProc("udpGetFunctionID", Paramters)
    '    '
    '    If TypeOf param2.Value Is DBNull Then
    '        Return 0
    '    Else
    '        Return CInt(param2.Value.ToString)
    '    End If
    'End Function
#End Region

#Region "初始化扫描"
    Private Sub IniteScan()
        Me.lblMsg.Text = ""

        'Me.lblFormat.Text = ""
        Me.lblTips.Text = "请扫描"
        Me.lblStationName.Text = "Working In Process"
        'Me.lstBoxDisplay.Items.Clear()
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
        Me.ScanStatus = LotStatus.Waiting
        Me.PictureBox1.Visible = False
        'Me.Chart1.Visible = True
        Me.ScanStep = 0
        Me.dgvScanTask.Rows.Clear()
        Me.dgvVerifyTask.Rows.Clear()
        'Me.dgvScaningData.DataSource = Nothing
        lblStandard.Text = ""
        pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
        dgvStationStaus.Rows.Clear()
        dt.Columns.Clear()
        dt.Columns.Add("ID1", GetType(String))
        dt.Columns.Add("ID2", GetType(String))
        dt.Columns.Add("ID3", GetType(String))
        dt.Columns.Add("ID4", GetType(String))
        dt.Columns.Add("ID5", GetType(String))
        dt.Columns.Add("ID6", GetType(String))
        dt.Columns.Add("ID7", GetType(String))
        dt.Columns.Add("ID8", GetType(String))
        dt.Columns.Add("ID9", GetType(String))
    End Sub
#End Region

#Region "GetSopFile"
    Private Function GetSopFile() As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select top 1 B.SopFilePath from m_RunCard_t(nolock)  A join m_RunCardDetail_t(nolock) B on A.ID=B.RunCardID " & _
                               "where A.PartID=" & Me.PartId & " and B.StationID=" & Me.StationId
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count Then
                Return dt.Rows(0)(0).ToString
            Else
                Return ""
            End If
        End Using
    End Function
#End Region

#Region "显示SOP"
    Private Sub ShowSopImage()

        Me.dgvRunCard.Visible = False
        Me.PictureBox1.Visible = True
        Dim file As String = Me.GetSopFile()
        Dim localFile As String = ""
        If file <> "" Then
            'localFile = DownLoadSopFile(file)
            'If localFile <> "" Then
            '    Me.PictureBox1.Image = Image.FromFile(localFile)
            'Else
            Using fs As New FileStream(file, FileMode.Open, FileAccess.Read)
                Dim img As Image = Image.FromStream(fs)
                Me.PictureBox1.Image = img
            End Using
            'Me.PictureBox1.Image = Image.FromFile(file)
            'End If
        Else
            Me.PictureBox1.Image = Nothing
        End If
    End Sub
    Private Function DownLoadSopFile(ByVal path As String) As String
        Try
            Dim partNumber As String = GetPartNumber()
            Dim localPath As String = Environment.CurrentDirectory
            If partNumber <> "" Then
                localPath = localPath + "\\SOP\\" + partNumber
            Else : localPath = localPath + "\\SOP\\" + Me.PartId.ToString
            End If
            If System.IO.Directory.Exists(localPath) = False Then
                System.IO.Directory.CreateDirectory(localPath)
            End If
            localPath = localPath + "\\" + path.Substring(path.LastIndexOf("\") + 1)
            System.IO.File.Copy(path, localPath, True)
            Return localPath
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetPartNumber() As String
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT PARTNUMBER FROM M_RUNCARDPARTNUMBER_T WHERE ID=" & Me.PartId & ""
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString
            End Using
            Return ""
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "显示样本图表"
    Private Sub ShowSampleChart()
        'Me.Chart1.Visible = True
        ''X轴坐标间隔
        'Me.Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        ''是否交叉显示
        'Me.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.IsStaggered = False
        'Me.Chart1.Series("ProductQty").Points.Clear()
        'For index As Integer = 8 To 20
        '    Chart1.Series("ProductQty").Points.AddXY(index.ToString & ":00", New Random(index).Next(100, 160))
        'Next
    End Sub
#End Region

#Region "显示图表"
    Private Sub ShowRunCardChart()
        'Me.Chart1.Visible = True
        ''X轴坐标间隔
        'Me.Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        ''是否交叉显示
        'Me.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.IsStaggered = False
        'Me.Chart1.Series("ProductQty").Points.Clear()
        '
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim StrSql As String = "select RCD.StationSQ,ST.StationName,UN.Qty from m_RunCard_t(nolock)  RC " & _
        '                       "join m_RunCardDetail_t(nolock) RCD on RC.ID=RCD.RunCardID " & _
        '                       "join m_Station_t(nolock) ST on RCD.StationID=ST.ID " & _
        '                       "left join m_LotUnit_t(nolock) UN on RC.PartID=Un.PartID and ST.ID=UN.StationID " & _
        '                       "where RC.PartID = " & Me.PartId & " order by RCD.StationSQ "
        'Dim dt As DataTable = DAL.GetDataTable(StrSql)
        'For Each row As DataRow In dt.Rows
        '    Chart1.Series("ProductQty").Points.AddXY(row("StationSQ").ToString & "-" & row("StationName").ToString, row("Qty").ToString)
        'Next
    End Sub
#End Region


#Region "显示流程卡"

    Private dt As New DataTable

    Private Sub ShowRunCard(ByVal wo As String)
        '
        dt.Rows.Clear()
        Me.dgvRunCard.AutoGenerateColumns = True
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        'RunCard Header
        '        Dim sqlHeader As String = "select PN.PARTNUMBER DrawingNo,RC.DrawingVer,RC.Shape,WO.Moid,WO.Moqty,WO.Lineid " & _
        '                               "from m_Mainmo_t(nolock) WO " & _
        '                               "join m_PartNumber_t(nolock) PN on WO.PartID=PN.PartNumber " & _
        '                               "join m_RunCard_t(nolock) RC on PN.ID=RC.PartID " & _
        '                               "where Wo.Moid='" & wo & "'; "
        '        'RunCard Body
        '        Dim sqlBody As String = "SELECT A.STATIONSQ,A.STATIONNAME," & vbNewLine & _
        '" A.WORKINGHOURS,A.EQUIPMENT,LEFT(RAWINFO,LEN(RAWINFO)-3) RAWI," & vbNewLine & _
        '        " A.PROCESSSTANDARD, A.REMARK, A.SHAPE, " & vbNewLine & _
        '        " A.OPERATORUSERNAME, A.CONFIRMUSERNAME" & vbNewLine & _
        '" FROM (" & vbNewLine & _
        '" SELECT A.*,(SELECT PARTD.DESCRIPTION1+' || ' " & vbNewLine & _
        ' "  FROM M_RUNCARDDETAIL_T DETAIL, " & vbNewLine & _
        '  " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_PARTNUMBER_T PARTD " & vbNewLine & _
        '   "        WHERE(DETAIL.ID = A.ID) " & vbNewLine & _
        '   " AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID " & vbNewLine & _
        '   " AND PARTDETAIL.PARTID=PARTD.ID " & vbNewLine & _
        '   " AND ISNULL(PARTD.TYPE,'R')='R' " & vbNewLine & _
        '   " FOR XML PATH('')) AS RAWINFO FROM" & vbNewLine & _
        '" (SELECT RCD.STATIONSQ,ST.STATIONNAME," & vbNewLine & _
        '  "       RCD.WORKINGHOURS, RCD.EQUIPMENT, " & vbNewLine & _
        '   "      RCD.PROCESSSTANDARD, RCD.REMARK, RCD.SHAPE, " & vbNewLine & _
        '" FAI.OPERATORUSERNAME,FAI.CONFIRMUSERNAME,RCD.ID  " & vbNewLine & _
        '" FROM M_MAINMO_T(NOLOCK ) WO " & vbNewLine & _
        '" JOIN M_PARTNUMBER_T(NOLOCK) PN " & vbNewLine & _
        '" ON WO.PARTID=PN.PARTNUMBER " & vbNewLine & _
        '" JOIN M_RUNCARD_T(NOLOCK) RC " & vbNewLine & _
        '" ON PN.ID=RC.PARTID " & vbNewLine & _
        '" JOIN M_RUNCARDDETAIL_T(NOLOCK) RCD " & vbNewLine & _
        '" ON RC.ID=RCD.RUNCARDID " & vbNewLine & _
        '" JOIN M_STATION_T(NOLOCK) ST " & vbNewLine & _
        '" ON ST.ID=RCD.STATIONID " & vbNewLine & _
        '" LEFT JOIN (SELECT DISTINCT STATIONID,OPERATORUSERNAME," & vbNewLine & _
        '" CONFIRMUSERNAME FROM M_LOTUNITFAI_T(NOLOCK) " & vbNewLine & _
        '" WHERE WORKORDER='" & wo & "')FAI " & vbNewLine & _
        '" ON RCD.STATIONID=FAI.STATIONID " & vbNewLine & _
        '" WHERE WO.MOID='" & wo & "' )A)A" & vbNewLine & _
        '" ORDER BY A.STATIONSQ; "

        'RunCard Tial
        Dim sqlHeader = "SELECT A.DRAWINGNO,A.DRAWINGVER,A.SHAPE," & vbNewLine & _
" A.MOID,A.MOQTY,A.LINEID,A.STATIONSQ,A.STATIONNAME," & vbNewLine & _
" A.WORKINGHOURS,A.EQUIPMENT,LEFT(RAWINFO,LEN(RAWINFO)-3) RAWI," & vbNewLine & _
  "       A.PROCESSSTANDARD, A.REMARK, A.SHAPE, " & vbNewLine & _
    "     A.OPERATORUSERNAME, A.CONFIRMUSERNAME" & vbNewLine & _
" FROM (" & vbNewLine & _
" SELECT A.*,(SELECT PARTD.DESCRIPTION1+' || ' " & vbNewLine & _
" FROM M_RUNCARDDETAIL_T DETAIL, " & vbNewLine & _
" M_RUNCARDPARTDETAIL_T PARTDETAIL,M_RUNCARDPARTNUMBER_T PARTD " & vbNewLine & _
"           WHERE(DETAIL.ID = A.ID) " & vbNewLine & _
"    AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID " & vbNewLine & _
"    AND PARTDETAIL.PARTID=PARTD.ID " & vbNewLine & _
"    AND ISNULL(PARTD.TYPE,'R')='R' " & vbNewLine & _
"    FOR XML PATH('')) AS RAWINFO FROM" & vbNewLine & _
" (SELECT PN.PARTNUMBER DrawingNo,RC.DrawingVer," & vbNewLine & _
"         RC.Shape, wo.Moid, wo.Moqty, wo.Lineid, RCD.STATIONSQ, ST.STATIONNAME, " & vbNewLine & _
"         RCD.WORKINGHOURS, RCD.EQUIPMENT, " & vbNewLine & _
"         RCD.PROCESSSTANDARD, RCD.REMARK, " & vbNewLine & _
" FAI.OPERATORUSERNAME,FAI.CONFIRMUSERNAME,RCD.ID " & vbNewLine & _
" FROM M_RUNCARDWORKORDER_T(NOLOCK ) WO " & vbNewLine & _
" JOIN M_RUNCARDPARTNUMBER_T(NOLOCK) PN " & vbNewLine & _
" ON WO.PARTID=PN.PARTNUMBER " & vbNewLine & _
" JOIN M_RUNCARD_T(NOLOCK) RC " & vbNewLine & _
" ON PN.ID=RC.PARTID " & vbNewLine & _
" JOIN M_RUNCARDDETAIL_T(NOLOCK) RCD " & vbNewLine & _
" ON RC.ID=RCD.RUNCARDID " & vbNewLine & _
" JOIN M_RUNCARDSTATION_T(NOLOCK) ST " & vbNewLine & _
" ON ST.ID=RCD.STATIONID " & vbNewLine & _
" LEFT JOIN (SELECT DISTINCT  A.STATIONID,C.USERNAME AS OPERATORUSERNAME" & vbNewLine & _
",A.CONFIRMUSERNAME  FROM M_RUNCARDLOTUNITFAI_T  A " & vbNewLine & _
" LEFT JOIN M_RUNCARDLOTUNIT_T B " & vbNewLine & _
" ON A.SERIALNUMBER=B.SERIALNUMBER " & vbNewLine & _
" AND A.WORKORDER=B.WORKORDER" & vbNewLine & _
" LEFT JOIN M_USERS_T C" & vbNewLine & _
" ON B.UserID=C.USERID" & vbNewLine & _
" WHERE A.WORKORDER='" & wo & "')FAI " & vbNewLine & _
" ON RCD.STATIONID=FAI.STATIONID " & vbNewLine & _
" WHERE WO.MOID='" & wo & "' )A)A" & vbNewLine & _
" ORDER BY A.STATIONSQ; "


        Dim sqlTail As String = "select ST.SectionID, case " & vbNewLine & _
" when ST.SectionID=1 " & vbNewLine & _
" then sum(RCD.WorkingHours) " & vbNewLine & _
" when ST.SectionID=2 " & vbNewLine & _
" then sum(RCD.WorkingHours) " & vbNewLine & _
" when ST.SectionID=3 " & vbNewLine & _
" then sum(RCD.WorkingHours) " & vbNewLine & _
" end WorkingHours " & vbNewLine & _
" from M_RUNCARDWORKORDER_T(nolock) WO " & vbNewLine & _
" join m_RUNCARDPartNumber_t(nolock) PN " & vbNewLine & _
" on WO.PartID=PN.PartNumber " & vbNewLine & _
" join m_RunCard_t(nolock) RC " & vbNewLine & _
" on PN.ID=RC.PartID" & vbNewLine & _
"  join m_RunCardDetail_t(nolock) RCD " & vbNewLine & _
"  on RC.ID=RCD.RunCardID " & vbNewLine & _
"  join m_RUNCARDStation_t(nolock) ST " & vbNewLine & _
"  on RCD.StationID=ST.ID " & vbNewLine & _
"  where Wo.Moid='" & wo & "' " & vbNewLine & _
"  group by ST.SectionID ;"

        '"where RC.PartId=368 order by RCD.StationSQ "
        Dim ds As DataSet = DAL.GetDataSet(sqlHeader & vbNewLine & vbNewLine & sqlTail)
        If Not ds Is Nothing Then
            Dim dtHeader As DataTable = ds.Tables(0)
            Dim dtBody As DataTable = ds.Tables(1)
            'header
            For index As Integer = 0 To dtHeader.Rows.Count - 1
                'Me.dgvRunCard.Rows.Add("图号", dtHeader.Rows(index)("DrawingNo").ToString, "", "", "", "", "工单号", wo, "")
                'Me.dgvRunCard.Rows.Add("版本", dtHeader.Rows(index)("DrawingVer").ToString, "线别", dtHeader.Rows(index)("Lineid").ToString, "", "", "责任线长", "", "")
                'Me.dgvRunCard.Rows.Add("形态", dtHeader.Rows(index)("Shape").ToString, "", "", "", "", "工单量", dtHeader.Rows(index)("Moqty").ToString, "")
                'Me.dgvRunCard.Rows.Add("序号", "工站内容", "工时(s)", "设备/治具", "工艺标准", "备注", "操作员", "IPQC", "")
                If index = 0 Then
                    dt.Rows.Add("图号", dtHeader.Rows(index)("DrawingNo").ToString, "", "", "", "", "", "工单号", wo)
                    dt.Rows.Add("版本", dtHeader.Rows(index)("DrawingVer").ToString, "线别", dtHeader.Rows(index)("Lineid").ToString, "", "", "", "责任线长", "")
                    dt.Rows.Add("形态", dtHeader.Rows(index)("Shape").ToString, "", "", "", "", "", "工单量", dtHeader.Rows(index)("Moqty").ToString)
                    dt.Rows.Add("序号", "工站内容", "工时(s)", "设备/治具", "工艺标准", "物料规格", "备注", "操作员", "IPQC")
                End If
                dt.Rows.Add(dtHeader.Rows(index)("StationSQ").ToString, dtHeader.Rows(index)("StationName").ToString, dtHeader.Rows(index)("WorkingHours").ToString, _
                                   dtHeader.Rows(index)("Equipment").ToString, dtHeader.Rows(index)("ProcessStandard").ToString, dtHeader.Rows(index)("RAWI").ToString, _
                                   dtHeader.Rows(index)("Remark").ToString, dtHeader.Rows(index)("OperatorUserName").ToString, dtHeader.Rows(index)("ConfirmUserName").ToString)
            Next
            ''body
            'For index As Integer = 0 To dtBody.Rows.Count - 1
            '    'Me.dgvRunCard.Rows.Add(dtBody.Rows(index)("StationSQ").ToString, dtBody.Rows(index)("StationName").ToString, dtBody.Rows(index)("WorkingHours").ToString, _
            '    '                       dtBody.Rows(index)("Equipment").ToString, dtBody.Rows(index)("ProcessStandard").ToString, dtBody.Rows(index)("Remark").ToString _
            '    '                       , dtBody.Rows(index)("OperatorUserName").ToString, dtBody.Rows(index)("ConfirmUserName").ToString, "")
            '    dt.Rows.Add(dtBody.Rows(index)("StationSQ").ToString, dtBody.Rows(index)("StationName").ToString, dtBody.Rows(index)("WorkingHours").ToString, _
            '                          dtBody.Rows(index)("Equipment").ToString, dtBody.Rows(index)("ProcessStandard").ToString, dtBody.Rows(index)("Remark").ToString _
            '                          , dtBody.Rows(index)("OperatorUserName").ToString, dtBody.Rows(index)("ConfirmUserName").ToString, "")
            'Next
            'tail

            Dim totalHours As Integer = 0
            Dim preHours As Integer = 0
            Dim proHours As Integer = 0
            Dim sufHours As Integer = 0
            '添加空行
            'Me.dgvRunCard.Rows.Add("", "", "", "", "", "", "", "", "")
            If dt.Rows.Count > 0 Then
                For index As Integer = 0 To dtBody.Rows.Count - 1
                    If dtBody.Rows(index)("SectionID").ToString = "1" Then
                        preHours = dtBody.Rows(index)("WorkingHours").ToString
                    ElseIf dtBody.Rows(index)("SectionID").ToString = "2" Then
                        proHours = dtBody.Rows(index)("WorkingHours").ToString
                    ElseIf dtBody.Rows(index)("SectionID").ToString = "3" Then
                        sufHours = dtBody.Rows(index)("WorkingHours").ToString
                    End If
                Next
            End If

            totalHours = preHours + proHours + sufHours
            'Me.dgvRunCard.Rows.Add("总工时(s):" & totalHours.ToString, "", "", "前加工(S):" & preHours.ToString & "产线" & proHours.ToString(), "", "成型" & sufHours.ToString, "", "")
            dt.Rows.Add("", "总工时(s):" & totalHours.ToString, "", "前加工(s):" & preHours.ToString, "", "产线(s):" & proHours.ToString(), "成型(s):" & sufHours.ToString, "", "")
            'Me.dgvRunCard.VirtualMode = True
            Me.dgvRunCard.DataSource = dt
            Me.dgvRunCard.Columns(0).Width = 35
            Me.dgvRunCard.Columns(2).Width = 50
            Me.dgvRunCard.Columns(4).Width = 220
            Me.dgvRunCard.Columns(5).Width = 220
            Me.dgvRunCard.Columns(6).Width = 160
            Me.dgvRunCard.Columns(7).Width = 70
            Me.dgvRunCard.Columns(8).Width = 130
            'Me.dgvRunCard.RowCount = dt.Rows.Count
        End If
    End Sub
#End Region

#Region "横向合并单元格"
    Private Sub HorizontalMerageCell(ByVal dgv As DataGridView, ByVal celArgs As DataGridViewCellPaintingEventArgs, ByVal minColIndex As Integer, ByVal maxColIndex As Integer)
        If celArgs.RowIndex = -1 Or celArgs.ColumnIndex > maxColIndex Or celArgs.ColumnIndex < minColIndex Then
            Exit Sub
        End If
        Dim rect As New Rectangle
        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
            celArgs.Graphics.FillRectangle(backColorBrush, celArgs.CellBounds)
        End Using
        'celArgs.Handled = True
        'IsPostMerage(dgv, celArgs, minColIndex, maxColIndex)
        Dim rectArgs As Rectangle = CType(rowSpan(celArgs.ColumnIndex), Rectangle)
        'If rectArgs.X <> celArgs.CellBounds.X Or rectArgs.Y <> celArgs.CellBounds.Y Or rectArgs.Width <> celArgs.CellBounds.Width Or rectArgs.Height <> celArgs.CellBounds.Height Then
        rectArgs.X = celArgs.CellBounds.X
        rectArgs.Y = celArgs.CellBounds.Y
        rectArgs.Width = celArgs.CellBounds.Width
        rectArgs.Height = celArgs.CellBounds.Height
        rowSpan(celArgs.ColumnIndex) = rectArgs
        '
        Dim width As Integer = 0
        Dim height As Integer = celArgs.CellBounds.Height
        For index As Integer = minColIndex To maxColIndex
            width += CType(rowSpan(index), Rectangle).Width
        Next
        Dim rectBegin As Rectangle = CType(rowSpan(minColIndex), Rectangle)
        Dim rectEnd As Rectangle = CType(rowSpan(maxColIndex), Rectangle)
        Dim reBounds As New Rectangle()
        reBounds.X = rectBegin.X
        reBounds.Y = rectBegin.Y
        reBounds.Width = width - 1
        reBounds.Height = height - 1
        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
            Using gridLinePen As New Pen(gridBrush)

                Dim blPoint As New Point(rectBegin.Left, rectBegin.Bottom - 1)
                Dim brPoint As New Point(rectEnd.Right, rectEnd.Bottom - 1)
                celArgs.Graphics.DrawLine(gridLinePen, blPoint, brPoint)

                Dim rtPoint As New Point(rectEnd.Right - 1, rectEnd.Top)
                Dim rbPoint As New Point(rectEnd.Right - 1, rectEnd.Bottom - 1)
                celArgs.Graphics.DrawLine(gridLinePen, rtPoint, rbPoint)

                Dim sf As SizeF = celArgs.Graphics.MeasureString(rowValue, celArgs.CellStyle.Font)
                Dim lstr As Double = (width - sf.Width) / 2
                Dim rstr As Double = (height - sf.Height) / 2
                '
                If celArgs.ColumnIndex = maxColIndex Then
                    If totalQty <> 0 Then
                        celArgs.Graphics.DrawString(totalQty.ToString, celArgs.CellStyle.Font, New SolidBrush(celArgs.CellStyle.ForeColor), rectBegin.Left + lstr, rectEnd.Top + rstr, StringFormat.GenericDefault)
                    End If
                End If


            End Using
            celArgs.Handled = True
        End Using

    End Sub
#End Region


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        IniteScan()
        ResetScanParm()
    End Sub

    Private Sub tsmiScanTaskCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiScanTaskCopy.Click
        If Not dgvScanTask.CurrentCell Is Nothing Then
            Dim Selected As String = dgvScanTask.CurrentCell.Value.ToString()
            Clipboard.SetDataObject(Selected)
        End If
    End Sub

    Private Sub tsmiVerifyTaskCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiVerifyTaskCopy.Click
        If Not dgvVerifyTask.CurrentCell Is Nothing Then
            Dim Selected As String = dgvVerifyTask.CurrentCell.Value.ToString()
            Clipboard.SetDataObject(Selected)
        End If
    End Sub



    Private Sub dgvScaningData_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvScaningData.DataBindingComplete
        For Each column As DataGridViewColumn In dgvScaningData.Columns
            If column.Name = "生产数量" Or column.Name = "姓名" Then
                column.DefaultCellStyle.ForeColor = Color.Blue
            End If
        Next
    End Sub

    Private Sub dgvScaningData_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvScaningData.CellPainting
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            If dgvScaningData.Rows.Count > 0 Then
                If e.RowIndex = dgvScaningData.Rows.Count - 1 Then
                    HorizontalMerageCell(Me.dgvScaningData, e, 0, 8)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim frmSplit As New FrmLotSplit()
            frmSplit.ShowDialog()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLotSplit", "ToolStripButton1_Click", "WIP")
        End Try

    End Sub

    Private Sub CheckInputType(ByVal inputString As String)
        lblMsg.Text = ""
        If Not scanP.isInProcess Then
            Me.FunctionCodeId = Me.GetFunctionCodeID(inputString)
            If CheckIsUserID(inputString) AndAlso Not IsIPQC(inputString) Then
                If scanP.isDoFAI Then
                    If Not CheckLicence(inputString) Then
                        lblMsg.Text += " (已做完首检可以刷入员工号录入数据)"
                        Exit Sub
                    End If
                    Me.ScanerUserId = inputString
                    scanP.isInProcess = True
                    SetScanProcess(1)
                    lblMsg.Text += " 接下来请刷功能条码"
                    Exit Sub
                End If
                scanP.isFunctionBarcode = False
                ShowCatagoryByUser(inputString)
            ElseIf FunctionCodeId = 3 Then
                scanP.isFunctionBarcode = False
                DoWoScaning(inputString, FunctionCodeId)
            ElseIf FunctionCodeId = 2 Then
                If Not DoProcess(inputString, FunctionCodeId) Then Exit Sub
                If CheckRouting(inputString) Then
                    Me.IpqcUserId = GetFaiIPQC(inputString)
                    SetScanProcess(1)
                    SetScanProcess(3)
                    SetVerifyTaskProcess()
                    lblMsg.Text = "该工站已经扫描,请勿重复扫描"
                    Exit Sub
                End If
                If Not CheckVersion() Then
                    'lblMsg.Text = "工单版本与BOM不一致,请确认！！"
                    Exit Sub
                End If
                scanP.isFunctionBarcode = True
                scanP.functionBarcode = inputString
                If HasDoneFAI() Then
                    scanP.isDoFAI = True
                    Me.IpqcUserId = GetFaiIPQC(inputString)
                    SetScanProcess(3)
                    SetVerifyTaskProcess()
                    'ParseSnData(inputString)
                    lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                    Exit Sub
                Else
                    scanP.isDoFAI = False
                End If
            Else
                If scanP.isFunctionBarcode AndAlso scanP.isDoFAI Then
                    If IsIPQC(inputString) Then
                        Me.RegisterReportData(inputString)
                        lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                        Exit Sub
                    Else
                        lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                        Exit Sub
                    End If
                End If
                If scanP.isFunctionBarcode Then
                    If Not IsIPQC(inputString) Then  '' 不是IPQC，就只能是料件或是工治具编号
                        Dim msg1 As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
                        If msg1 <> "" Then
                            lblMsg.Text = "刷入错误！！请确认" & msg1
                            'If scanP.isFunctionBarcode Then scanP.isFunctionBarcode = False
                            Exit Sub
                        End If
                    End If
                End If
                If scanP.isFunctionBarcode Then
                    If HasDoneFAI() AndAlso UserDoWork() Then
                        lblMsg.Text = "该工站条码已扫描完成,请勿重复"
                        If scanP.isFunctionBarcode Then scanP.isFunctionBarcode = False
                        Exit Sub
                    End If
                    'Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
                    If dgvVerifyTask.Rows.Count <= 0 Then
                        If IsIPQC(inputString) Then
                            RegisterReportData(inputString)
                            Me.IpqcUserId = inputString
                            '更新扫描进度
                            SetScanProcess(3)
                            'IPQC确认
                            If IpqcIsConfirm() Then
                                '保存数据
                                SaveFAIData()
                                ShowAllStation()
                                Me.lblPass.Text = "PASS"
                                scanP.isPnCheckFinish = True
                                scanP.isInProcess = True
                                scanP.isCheckIPQC = True
                                lblMsg.Text = "接下来请刷入员工编号"
                                '初始化扫描
                            End If
                        Else
                            scanP.isFunctionBarcode = False
                            lblMsg.Text = "不需要校验工装物料，可以刷IPQC做首检！！"
                        End If
                    Else
                        If Not VerifyIsFinish() Then
                            Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
                            If msg <> "" Then
                                lblMsg.Text = msg
                                Exit Sub
                            Else
                                SetVerifyProcess(inputString)
                                scanP.isPnCheckFinish = VerifyIsFinish()
                                scanP.isInProcess = True
                                If Not VerifyIsFinish() Then
                                    lblMsg.Text = "请刷下一个料件或是工治具编号"
                                Else
                                    lblMsg.Text = "请刷入IPQC号做首检"
                                End If
                            End If
                        Else
                            scanP.isPnCheckFinish = True
                            scanP.isInProcess = True
                            lblMsg.Text = "请刷入IPQC号做首检"
                        End If
                    End If
                Else
                    lblMsg.Text = "扫描不正确！！请确认"
                    Me.PictureBox1.Image = Nothing
                    Exit Sub
                End If

            End If
        Else
            If scanP.isDoFAI Then
                If IsIPQC(inputString) Then
                    RegisterReportData(inputString)
                    lblMsg.Text = "已做完首检并刷完员工号可以刷工站条码录入数据"
                    Exit Sub
                End If
                If CheckSNFormat(inputString, 2) = "" Then
                    lblMsg.Text = "工站条码""" + inputString + """ 格式不正确"
                    Exit Sub
                End If
                If inputString.ToUpper <> scanP.functionBarcode.ToUpper Then
                    lblMsg.Text = "刷入的工站条码与做首检的不一致"
                    Exit Sub
                End If
                SaveData(inputString)
                Exit Sub
            End If
            If Not scanP.isPnCheckFinish Then
                Dim msg As String = VerifyPn(inputString, Me.PartId, Me.StationId, Me.WoQty)
                If Not VerifyIsFinish() Then
                    If msg <> "" Then
                        lblMsg.Text = "请刷入料件或是工治具编号"
                        Exit Sub
                    Else
                        SetVerifyProcess(inputString)
                        scanP.isPnCheckFinish = VerifyIsFinish()
                    End If
                Else
                    scanP.isPnCheckFinish = True
                End If
                If scanP.isPnCheckFinish Then
                    lblMsg.Text = "接下来请刷入IPQC号做首检"
                Else
                    lblMsg.Text = "请刷下一个料件或是工治具编号"
                End If
            ElseIf scanP.isPnCheckFinish AndAlso Not scanP.isCheckIPQC Then
                If IsIPQC(inputString) Then
                    RegisterReportData(inputString)
                    Me.IpqcUserId = inputString
                    '更新扫描进度
                    SetScanProcess(3)
                    'IPQC确认
                    If IpqcIsConfirm() Then
                        '保存数据
                        SaveFAIData()
                        ShowAllStation()
                        Me.lblPass.Text = "PASS"
                        scanP.isCheckIPQC = True
                        lblMsg.Text = "接下来请刷入操作员ID"
                        '初始化扫描
                    End If
                Else
                    lblMsg.Text = "请刷入IPQC号"
                    Exit Sub
                End If
                'modfiy by paul 20150310
                '
            ElseIf scanP.isPnCheckFinish AndAlso scanP.isCheckIPQC AndAlso IsIPQC(inputString) Then
                RegisterReportData(inputString)
                If Not scanP.isCheckUserId Then
                    lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                Else
                    lblMsg.Text = "已做完首检并刷完员工号可以刷工站条码录入数据"
                End If
                'end added
            ElseIf scanP.isPnCheckFinish AndAlso scanP.isCheckIPQC AndAlso Not scanP.isCheckUserId Then
                If Not CheckIsUserID(inputString) Then
                    lblMsg.Text = "已做完首检请刷入员工号"
                    txtInput.Text = ""
                    txtInput.Focus()
                    Exit Sub
                Else
                    If Not CheckLicence(inputString) Then
                        lblMsg.Text += " (已做完首检可以刷入员工号录入数据)"
                        Exit Sub
                    End If
                    Me.ScanerUserId = inputString
                    SetScanProcess(1)
                    lblMsg.Text += " 接下来请刷入工站条码"
                    scanP.isCheckUserId = True
                End If
            ElseIf scanP.isCheckUserId Then
                If CheckSNFormat(inputString, 2) = "" Then
                    lblMsg.Text = "工站条码""" + inputString + """ 格式不正确"
                    Exit Sub
                End If
                If inputString.ToUpper <> scanP.functionBarcode.ToUpper Then
                    lblMsg.Text = "刷入的工站条码与做首检的不一致"
                    Exit Sub
                End If
                SaveData(inputString)
            End If
        End If
        txtInput.Text = ""
        txtInput.Focus()
    End Sub

    Private Sub SaveData(ByVal InputString As String)
        'ShowSopImage()
        '解析工站条码格式
        ParseSnData(InputString)
        '校验工站，流程卡，工单信息
        Dim msg As String = ""
        msg = VerifySnData(InputString, 2)
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        '设置扫描进度
        SetScanProcess(2)
        '保存扫描数据
        msg = SaveScanData(InputString)
        If msg <> "" Then
            ''显示工艺程流程图表
            'ShowRunCardChart()
            ResetScanParm()
            lblMsg.Text = msg
            Exit Sub
        End If
        UpdateFAI()
        Me.lblPass.Text = "PASS"
        '刷新显示
        LoadScaningData(Me.ScanerUserId)
        ResetScanParm()
        Dim result As Integer = -1
        result = GetNextStation()
        If result = 0 Then
            lblMsg.Text = "加工流程已完成"
        Else
            lblMsg.Text = "本站完成,请去下一站：" + GetNextStationName(result)
        End If
        ShowCatagoryByUser(Me.ScanerUserId)
        Me.PictureBox1.Image = Nothing
        dgvScanTask.DataSource = Nothing
        dgvVerifyTask.Rows.Clear()
        ShowAllStation()
    End Sub

    Private Sub ShowCatagoryByUser(ByVal inputString As String)
        Dim msg As String = ""
        msg = VerifySnData(inputString, FunctionCodeId)
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Me.ScanerUserId = inputString
        '显示当天的扫描记录
        LoadScaningData(Me.ScanerUserId)
        '显示扫描任务
        ShowScanTask(1)
        '设置扫描进度
        SetScanProcess(1)
        dgvVerifyTask.Rows.Clear()
        ' ShowSopImage()
        Me.PictureBox1.Image = Nothing
        Me.PictureBox1.Visible = False
        'Me.Chart1.Visible = False
        Me.dgvRunCard.Visible = False
        lblStandard.Text = ""
        lblStationName.Text = "Working In Process"
        pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
    End Sub

    Private Function DoProcess(ByVal inputString As String, ByVal functionId As Integer) As Boolean
        'Dim msg As String = ""
        'msg = VerifySnData(inputString, FunctionCodeId)
        'If msg <> "" Then
        '    lblMsg.Text = msg
        '    Exit Sub
        'End If
        ParseSnData(inputString)
        If Not CheckRunCardStatus() Then Return False
        Me.StationName = Me.GetStationNameById(Me.StationId)
        Me.ParseWorkOrder(Me.WorkOrder)
        Me.lblStationName.Text = SID + "." + Me.StationName
        Dim remark As String = ""
        Dim standard As String = ""
        Dim desc As String = ""
        Me.StationSQ = GetStandard(remark, standard, desc)
        If standard <> "" OrElse remark <> "" Then
            pnlStandard.Left = lblStationName.Left + lblStationName.Width + 1
            pnlStandard.Width = Me.Width - pnlStandard.Left - 2
            lblStandard.Text = ""
            lblStandard.Text += IIf(String.IsNullOrEmpty(standard), "", "工艺标准：" + standard + "。") + IIf(String.IsNullOrEmpty(remark), "", "备注：" + remark + "。") + IIf(String.IsNullOrEmpty(desc), "", desc)
        Else
            lblStandard.Text = ""
        End If
        Me.ConfigQty = GetMoConfigQty()
        Me.dgvScaningData.DataSource = Nothing
        Me.ShowSopImage()
        Me.PictureBox1.Visible = True
        ShowScanTask(2)
        SetScanProcess(2)
        ShowVerifyTask(Me.PartId, Me.StationId)
        ShowAllStation()
        Return True
    End Function

    Private Function CheckVersion() As Boolean
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        'Dim oConn As OracleDb
        Dim zPn As String = Nothing
        'Dim pPn As String = Nothing
        Dim version As String = Nothing
        Dim format As String = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT 1 FROM M_RUNCARD_T A,M_RUNCARDWORKORDER_T B" & vbNewLine & _
            " WHERE A.PARTID=" & Me.PartId & " AND B.MOID='" & Me.WorkOrder & "' AND A.DRAWINGVER=B.VERSION"
            'oConn = New OracleDb("")
            'Dim sql = "SELECT TOP 1 A.PARTNUMBER,B.DRAWINGVER " & vbNewLine & _
            '" FROM M_PARTNUMBER_T A,M_RUNCARD_T B " & vbNewLine & _
            '" WHERE A.ID=B.PARTID AND B.PARTID=" & Me.PartId & " AND B.STATUS=1"
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count <= 0 Then
                    lblMsg.Text = "工单版本与BOM不一致,请确认！！"
                    Return False
                Else
                    Return True
                End If
            End Using
            'sql = "SELECT TOP 1 A.PARTNUMBER FROM M_MAINMO_T A,M_MIANMO_T B WHERE A.MOID=B.PARENTMO AND A.MOID=A.PARENTMO AND B.MOID='" & Me.WorkOrder & "'"
            'Using dt As DataTable = sConn.GetDataTable(sql)
            '    If dt.Rows.Count > 0 Then
            '        pPn = dt.Rows(0)("PARTNUMBER").ToString
            '    End If
            'End Using
            'sql = "SELECT IMA021 FROM IMA_FILE WHERE IMA01='" & zPn & "' AND ROWNUM=1"
            'Dim retur = oConn.ExecuteScalar(sql)
            'If Not retur Is Nothing Then format = retur.ToString
            'If Not String.IsNullOrEmpty(retur) Then
            '    If (format.Split("-").Length > 1) Then
            '        If Not version.Trim.ToUpper = format.Split("-")(format.Split("-").Length - 1).Trim.ToUpper Then
            '            lblMsg.Text = "工单版本与BOM不一致"
            '            Return False
            '        Else
            '            Return True
            '        End If
            '    ElseIf format.Trim.ToUpper <> version.Trim.ToUpper Then
            '        lblMsg.Text = "工单版本与BOM不一致"
            '        Return False
            '    End If
            'Else
            '    lblMsg.Text = "料号{" & zPn & "}不存在于Titop"
            '    Return False
            'End If
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
            'If Not oConn Is Nothing Then
            '    oConn = Nothing
            'End If
        End Try
    End Function

    Private Function CheckRouting(ByVal input As String) As Boolean
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Using dt As DataTable = sConn.GetDataTable("SELECT TOP 1 SERIALNUMBER FROM M_RUNCARDLOTUNIT_T WHERE SERIALNUMBER='" & input & "'")
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function

    Private Function GetFaiIPQC(ByVal input As String)
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Using dt As DataTable = sConn.GetDataTable("SELECT TOP 1 A.IPQC,B.USERID FROM M_RUNCARDLOTUNITFAI_T A LEFT JOIN M_RUNCARDLOTUNIT_T B ON  A.SERIALNUMBER=B.SERIALNUMBER  WHERE A.SERIALNUMBER='" & input & "' ")
                If dt.Rows.Count > 0 Then
                    Me.ScanerUserId = dt.Rows(0)("USERID").ToString
                    Return dt.Rows(0)("IPQC").ToString
                Else
                    Return ""
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function

    Private Function IsIPQC(ByVal inputString As String)
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Using dt As DataTable = sConn.GetDataTable("SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND GROUPID='IPQC'")
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

    End Function

    Private Function CheckRunCardStatus() As Boolean
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Using dt As DataTable = sConn.GetDataTable("SELECT STATUS FROM M_RUNCARD_T WHERE PARTID=" & Me.PartId & " AND STATUS=1")
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    lblMsg.Text = "流程卡未生效，无法扫描作业，请找工程人员处理"
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
        Return True
    End Function


    Private frm As New FrmLotReportRegister

    Public Enum ReportTypeEnum
        TP = 0
        CX
        DC
        HJ
        JX
        YJ
        ZZ
    End Enum

    Private Sub RegisterReportData(ByVal inputString As String)
        Dim url As String = Nothing
        Select Case Me.ReportType
            Case ReportTypeEnum.TP.ToString '裁线脱皮报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/SeeWireCutting/Add?backUrl=%2FPaperLess%2FSeeWireCutting%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case ReportTypeEnum.CX.ToString '成型报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/MPQuality/Add?backUrl=%2FPaperLess%2FMPQuality%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case ReportTypeEnum.DC.ToString '电测报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/ElectricalMeasurement/Add?backUrl=%2FPaperLess%2FElectricalMeasurement%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
                'url = "http://dcs.luxshare-ict.com:17888/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode=E511D-150100274-Z001&stationId=523&WorkCode=%E8%A3%81%E7%BA%BF/%E8%84%B1%E7%9A%AE2"
            Case ReportTypeEnum.HJ.ToString '焊接报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Welding/Add?backUrl=%2FPaperLess%2FWelding%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case ReportTypeEnum.JX.ToString '浸锡报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case ReportTypeEnum.YJ.ToString '压接报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Crimp/Add?backUrl=%2FPaperLess%2FCrimp%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case ReportTypeEnum.ZZ.ToString '组装品质报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Assemble/Add?backUrl=%2FPaperLess%2FAssemble%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
            Case Else
                url = Nothing
        End Select
        'If Me.StationName.Contains("压接") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Crimp/Add?backUrl=%2FPaperLess%2FCrimp%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'ElseIf Me.StationName.Contains("成型") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/MPQuality/Add?backUrl=%2FPaperLess%2FMPQuality%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'ElseIf Me.StationName.Contains("浸锡") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'ElseIf Me.StationName.Contains("焊接") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Welding/Add?backUrl=%2FPaperLess%2FWelding%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'ElseIf Me.StationName.Contains("电测") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/ElectricalMeasurement/Add?backUrl=%2FPaperLess%2FElectricalMeasurement%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'ElseIf Me.StationName.Contains("裁线") Or Me.StationName.Contains("脱皮") Then
        '    url = String.Format("http://dcs.luxshare-ict.com/PaperLess/SeeWireCutting/Add?backUrl=%2FPaperLess%2FSeeWireCutting%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        'End If


        If Not String.IsNullOrEmpty(url) Then

            If (frm.IsDisposed) Then 'Add by cq,20150521
                frm = New FrmLotReportRegister '如果已经销毁，则重新创建子窗口对象
            End If

            frm.url = url
            frm.TopMost = True
            frm.ShowDialog()
        End If
    End Sub

    Private Function CheckIsUserID(ByVal inputString As String)
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            'Add GroupID is null, by CQ 20150514
            Using dt As DataTable = sConn.GetDataTable("SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND ISNULL(GROUPID,'NA')<>'IPQC'")
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function

    Private Function CheckLicence(ByVal inputString As String) As Integer
        If Not String.IsNullOrEmpty(Me.LicenceCode.Trim) Then
            Dim service As DcsWebReference.WorkStationService = Nothing
            Dim result As Integer = -1
            Try
                service = New DcsWebReference.WorkStationService
                result = service.getLicenceCode(inputString, Me.LicenceCode.Trim)
                Select Case result
                    Case 0
                        lblMsg.Text = "上岗证已被吊销"
                    Case 1
                        lblMsg.Text = "该重点工站考核OK" '"上岗证正常", 错别字，工作==》工站 
                    Case 2
                        lblMsg.Text = "上岗证失效"
                    Case 3
                        lblMsg.Text = "未获得上岗证"
                    Case 4
                        lblMsg.Text = "上岗证即将失效"
                    Case Else
                        lblMsg.Text = "该重点工站考核未申请或未合格"
                End Select
                Select Case result
                    Case 1, 4
                        Return True
                    Case Else
                        Return False
                End Select
                Return False
            Catch ex As Exception
                lblMsg.Text = "从E-Learing获取考试资格证异常,请通知工程人员"
                Return True
            Finally
                If Not service Is Nothing Then
                    service.Dispose()
                End If
            End Try
        Else
            Return True
        End If
    End Function

    Private Function CheckIsMO(ByVal inputString As String) As Boolean
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & inputString & "'"
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function

    Private Sub UpdateFAI()
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            sConn.ExecuteNonQuery("UPDATE m_RUNCARDLotUnitfai_t SET OPERATORUSERNAME='" & Me.ScanerUserId & "'where SerialNumber='" & Me.SerialNumber & "' and PartID='" & Me.PartId & "' and StationID='" & Me.StationId & "'")
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

    Private Sub ResetScanParm()
        scanP.isInProcess = False
        scanP.isCheckIPQC = False
        scanP.isFunctionBarcode = False
        scanP.isCheckUserId = False
        scanP.isPnCheckFinish = False
        scanP.functionBarcode = ""
        scanP.isDoFAI = False
    End Sub

    Private Function UserDoWork() As Boolean
        Dim DAL As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            Dim StrSql As String = "select top 1 1 from m_RUNCARDLotUnit_t(nolock) where SerialNumber='" & Me.SerialNumber & "' and PartID=" & Me.PartId & " and StationID=" & Me.StationId
            Using dt As DataTable = DAL.GetDataTable(StrSql)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If Not DAL Is Nothing Then
                DAL = Nothing
            End If
        End Try

    End Function

    Private Function GetNextStation() As Integer
        Dim result As Integer = 0
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            '    Dim sql As String = "SELECT TOP 1 C.STATIONID FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B,M_RUNCARDDETAIL_T C " & vbNewLine & _
            '" WHERE A.PARTID='" & Me.PartId & "'" & vbNewLine & _
            '" AND A.ID=B.RUNCARDID" & vbNewLine & _
            '" AND A.STATUS=1" & vbNewLine & _
            '" AND B.STATUS=1" & vbNewLine & _
            '" AND B.STATIONID=" & Me.StationId & "" & vbNewLine & _
            '" AND A.ID=C.RUNCARDID " & vbNewLine & _
            '" AND C.STATUS=1" & vbNewLine & _
            '" AND C.STATIONSQ=B.STATIONSQ+1"

            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim param1 As New SqlParameter("@PARTID", SqlDbType.VarChar, 50, ParameterDirection.Input)
            Dim param3 As New SqlParameter("@INPUTSTATIONID", SqlDbType.VarChar, 50, ParameterDirection.Input)
            Dim param2 As New SqlParameter("@STATIONID", SqlDbType.VarChar, 50)
            '参数赋值
            ' param2.Value = 0
            param1.Value = Me.PartId
            param3.Value = Me.StationId
            param2.Direction = ParameterDirection.Output
            Dim Paramters As SqlParameter() = Nothing
            Paramters = New SqlParameter() {param1, param3, param2}
            sConn.ExecuteNonQureyByProc("GetNextStation", Paramters)
            If TypeOf param2.Value Is DBNull Then
                Return 0
            Else
                Return CInt(param2.Value.ToString)
            End If
            'Using dt As DataTable = sConn.GetDataTable(sql)
            '    If dt.Rows.Count > 0 Then
            '        result = dt.Rows(0)(0)
            '            End If
            '        End Using
            'Return result
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Function

    Private Function GetNextStationName(ByVal stationId As Integer) As String
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = "SELECT STATIONNAME FROM M_RUNCARDSTATION_T WHERE ID=" & stationId & ""
            Using dt As DataTable = sConn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(0)
                End If
            End Using
            Return ""
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

    End Function

    Private Sub ShowAllStation()
        Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sql As String = " SELECT  " & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 1 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS1," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 2 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS2," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 3 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS3," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 4 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS4," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 5 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS5," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 6 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS6," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 7 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS7," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 8 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS8," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 9 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS9," & vbNewLine & _
" MAX(CASE WHEN ID % 10 = 0 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS10" & vbNewLine & _
" FROM(" & vbNewLine & _
" SELECT ROW_NUMBER() OVER( ORDER BY A.STATIONSQ) ID ," & vbNewLine & _
" CEILING((ROW_NUMBER() OVER( ORDER BY A.STATIONSQ)+0.0)/10) RID ," & vbNewLine & _
" CASE  " & vbNewLine & _
" WHEN A.IPQC IS NULL THEN N'未检'" & vbNewLine & _
" WHEN A.IPQC IS NOT NULL AND A.USERID IS NULL THEN N'已检'" & vbNewLine & _
" ELSE N'已录' END STATUS" & vbNewLine & _
" FROM ( " & vbNewLine & _
" SELECT DISTINCT B.STATIONSQ,C.IPQC,D.USERID" & vbNewLine & _
" FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B" & vbNewLine & _
" LEFT JOIN M_RUNCARDLOTUNITFAI_T  C " & vbNewLine & _
" ON  B.STATIONID=C.STATIONID" & vbNewLine & _
" AND C.PARTID=" & Me.PartId & "" & vbNewLine & _
" AND C.WORKORDER='" & Me.WorkOrder & "' " & vbNewLine & _
" LEFT JOIN M_RUNCARDLOTUNIT_T D" & vbNewLine & _
" ON C.SERIALNUMBER=D.SERIALNUMBER" & vbNewLine & _
"             WHERE(A.ID = B.RUNCARDID)" & vbNewLine & _
" AND A.PARTID=" & Me.PartId & "" & vbNewLine & _
" ) A )A GROUP BY RID"


            dgvStationStaus.Rows.Clear()
            Using dt As DataTable = sConn.GetDataTable(sql)
                For Each row As DataRow In dt.Rows
                    dgvStationStaus.Rows.Add(row(StatusEnum.Status1).ToString, row(StatusEnum.Status2).ToString, row(StatusEnum.Status3).ToString, row(StatusEnum.Status4).ToString, row(StatusEnum.Status5).ToString, row(StatusEnum.Status6).ToString, row(StatusEnum.Status7).ToString, row(StatusEnum.Status8).ToString, row(StatusEnum.Status9).ToString, row(StatusEnum.Status10).ToString)
                Next
            End Using
            If dgvStationStaus.Rows.Count > 0 Then
                SetStatusColor((Panel2.Height - 22) / dgvStationStaus.Rows.Count)
                dgvStationStaus.ClearSelection()
                Panel2Show()
            End If
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

    Private Sub txtAction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAction.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If txtAction.Text = "RESET" Then
                    ResetScanParm()
                    txtInput.Select()
                    txtInput.SelectAll()
                    lblMsg.Text = "重置成功,请继续"
                    txtAction.Text = "辅助功能"
                ElseIf txtAction.Text = "SPLIT" Then
                    Try
                        Dim frmSplit As New FrmLotSplit()
                        frmSplit.ShowDialog()
                        txtInput.Select()
                        txtInput.SelectAll()
                        txtAction.Text = "辅助功能"
                    Catch ex As Exception
                        txtInput.Select()
                        txtInput.SelectAll()
                        lblMsg.Text = ex.Message
                        txtAction.Text = "辅助功能"
                    End Try
                    lblMsg.Text = "拆分成功,请继续"
                    txtAction.Text = "辅助功能"
                Else
                    txtInput.Select()
                    txtInput.SelectAll()
                    lblMsg.Text = "系统不是别的条码，请确认"
                    txtAction.Text = "辅助功能"
                End If
            End If
        Catch ex As Exception
            txtInput.Select()
            txtInput.SelectAll()
            lblMsg.Text = ex.Message
            txtAction.Text = "辅助功能"
        End Try
    End Sub

    Public Sub FunctionAssign(ByVal input As String)
        Try
            If input = "RESET" Then
                IniteScan()
                ResetScanParm()
                txtInput.Select()
                txtInput.SelectAll()
                lblMsg.Text = "重置成功,请继续"
                txtAction.Text = "辅助功能"
            ElseIf input = "SPLIT" Then
                Try
                    Dim frmSplit As New FrmLotSplit()
                    frmSplit.ShowDialog()
                    ResetScanParm()
                    txtInput.Select()
                    txtInput.SelectAll()
                Catch ex As Exception
                    txtInput.Select()
                    txtInput.SelectAll()
                    lblMsg.Text = ex.Message
                End Try
                lblMsg.Text = "拆分成功,请继续"
            Else
                txtInput.Select()
                txtInput.SelectAll()
                lblMsg.Text = "系统不是别的辅助条码，请确认"
            End If
        Catch ex As Exception
            txtInput.Select()
            txtInput.SelectAll()
            lblMsg.Text = ex.Message
        End Try
    End Sub

    Private tipText As New System.Text.StringBuilder
    Private rowLength As Integer = 30
    Private totalLength As Integer = 0
    Private startIndex As Integer = 0

    Private Sub dgvRunCard_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles dgvRunCard.CellToolTipTextNeeded
        If e.ColumnIndex = -1 OrElse e.RowIndex = -1 Then
            Return
        End If
        If e.ColumnIndex <> 4 AndAlso e.ColumnIndex <> 5 AndAlso e.ColumnIndex <> 6 Then
            Return
        End If
        If tipText.Length > 0 Then
            tipText.Remove(0, tipText.Length)
        End If
        If dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
            Return
        End If
        If String.IsNullOrEmpty(dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) Then
            Return
        End If

        tipText.Append(dgvRunCard.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
        totalLength = tipText.Length
        If totalLength > rowLength Then
            startIndex = rowLength
            For i As Integer = 0 To totalLength / rowLength
                If startIndex > totalLength Then
                    Exit For
                End If
                tipText.Insert(startIndex, vbNewLine)
                startIndex += rowLength + 2
            Next
        End If
        e.ToolTipText = tipText.ToString()
    End Sub

    Private Enum StatusEnum
        Status1 = 0
        Status2
        Status3
        Status4
        Status5
        Status6
        Status7
        Status8
        Status9
        Status10
    End Enum

    Private Sub SetStatusColor(ByVal height As Integer)
        If dgvStationStaus.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvStationStaus.Rows
                row.Height = height
                If Not row.Cells(StatusEnum.Status1).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status1).Value) Then
                    If row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status1).Value.ToString.Substring(row.Cells(StatusEnum.Status1).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status1).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status1).Value = row.Cells(StatusEnum.Status1).Value.ToString.Substring(0, row.Cells(StatusEnum.Status1).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status2).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status2).Value) Then
                    If row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status2).Value.ToString.Substring(row.Cells(StatusEnum.Status2).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status2).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status2).Value = row.Cells(StatusEnum.Status2).Value.ToString.Substring(0, row.Cells(StatusEnum.Status2).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status3).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status3).Value) Then
                    If row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status3).Value.ToString.Substring(row.Cells(StatusEnum.Status3).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status3).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status3).Value = row.Cells(StatusEnum.Status3).Value.ToString.Substring(0, row.Cells(StatusEnum.Status3).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If


                If Not row.Cells(StatusEnum.Status4).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status4).Value) Then
                    If row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status4).Value.ToString.Substring(row.Cells(StatusEnum.Status4).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status4).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status4).Value = row.Cells(StatusEnum.Status4).Value.ToString.Substring(0, row.Cells(StatusEnum.Status4).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status5).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status5).Value) Then
                    If row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status5).Value.ToString.Substring(row.Cells(StatusEnum.Status5).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status5).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status5).Value = row.Cells(StatusEnum.Status5).Value.ToString.Substring(0, row.Cells(StatusEnum.Status5).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status6).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status6).Value) Then
                    If row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status6).Value.ToString.Substring(row.Cells(StatusEnum.Status6).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status6).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status6).Value = row.Cells(StatusEnum.Status6).Value.ToString.Substring(0, row.Cells(StatusEnum.Status6).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status7).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status7).Value) Then
                    If row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status7).Value.ToString.Substring(row.Cells(StatusEnum.Status7).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status7).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status7).Value = row.Cells(StatusEnum.Status7).Value.ToString.Substring(0, row.Cells(StatusEnum.Status7).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status8).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status8).Value) Then
                    If row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status8).Value.ToString.Substring(row.Cells(StatusEnum.Status8).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status8).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status8).Value = row.Cells(StatusEnum.Status8).Value.ToString.Substring(0, row.Cells(StatusEnum.Status8).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status9).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status9).Value) Then
                    If row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status9).Value.ToString.Substring(row.Cells(StatusEnum.Status9).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status9).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status9).Value = row.Cells(StatusEnum.Status9).Value.ToString.Substring(0, row.Cells(StatusEnum.Status9).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If

                If Not row.Cells(StatusEnum.Status10).Value Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells(StatusEnum.Status10).Value) Then
                    If row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.White
                    ElseIf row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.Yellow
                    ElseIf row.Cells(StatusEnum.Status10).Value.ToString.Substring(row.Cells(StatusEnum.Status10).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                        row.Cells(StatusEnum.Status10).Style.BackColor = Color.LimeGreen
                    End If
                    row.Cells(StatusEnum.Status10).Value = row.Cells(StatusEnum.Status10).Value.ToString.Substring(0, row.Cells(StatusEnum.Status10).Value.ToString.IndexOf("."))
                Else
                    Exit For
                End If
            Next
        End If
    End Sub
End Class



Public Class ScanParam
    Public isInProcess As Boolean = False
    Public isFunctionBarcode As Boolean = False
    Public isCheckUserId As Boolean = False
    Public isCheckIPQC As Boolean = False
    Public isPnCheckFinish As Boolean = False
    Public functionBarcode As String = ""
    Public isDoFAI As Boolean = False
End Class