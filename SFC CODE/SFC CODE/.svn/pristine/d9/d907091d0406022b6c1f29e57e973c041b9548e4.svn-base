Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports SysBasicClass
Imports System.Drawing
Imports System.Web
Imports System.Text
Imports System.IO

Public Class FrmLotScan
    Private Shared rowSpan As New SortedList()
    Private Shared rowValue As String = ""
    Dim scanP As New ScanParam
    Dim cellValue As String = ""
    Dim totalQty As Integer = 0
    Dim LicenceCode As String
    Private nextStationId As String
    Private nextStationName As String
    Private dt As New DataTable

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
    Private _stationId As String
    Public Property StationId() As String
        Get
            Return _stationId
        End Get
        Set(ByVal value As String)
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
    Private _partId As String
    Public Property PartId() As String
        Get
            Return _partId
        End Get
        Set(ByVal value As String)
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

#Region "事件"

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

        Panel2Show(False)
        '
        txtInput.Focus()
        txtInput.SelectAll()
    End Sub

    Private Sub Panel2Show(flag As Boolean)
        For Each con As Control In Panel2.Controls
            con.Visible = flag
        Next
    End Sub

    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                'Dim err As String = ""
                'Me.lblPass.Text = ""
                Dim strInput As String = txtInput.Text.Trim.ToUpper

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

#End Region

#Region "员工号扫描"
    ''' <summary>
    ''' 扫描员工ID号
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <remarks></remarks>
    Private Sub LoadScaningData(ByVal userId As String)
        Dim ds As DataSet
        ds = ScanBusiness.GetScanData(userId)

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
    End Sub
#End Region

#Region "工单扫描"
    Private Function DoWoScaning(ByVal strInput As String, ByVal functionCodeId As Integer) As String

        Me.dgvRunCard.Visible = True
        Me.PictureBox1.Visible = False

        ShowScanTask(Me.FunctionCodeId)

        SetMoInfo(strInput)

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

    ''' <summary>
    ''' 取得工单信息
    ''' </summary>
    ''' <param name="strInput"></param>
    ''' <remarks></remarks>
    Private Sub SetMoInfo(strInput As String)
        Dim dt As DataTable
        dt = ScanBusiness.GetMoInfo(strInput)

        If dt.Rows.Count > 0 Then
            Me.WoPn = dt.Rows(0)(2).ToString
            Me.WoQty = CInt(dt.Rows(0)(1).ToString)
            Me.WorkOrder = dt.Rows(0)(0).ToString
        End If
    End Sub

#End Region

    ''' <summary>
    ''' 有工装物料要扫的：
    '''刷功能条码-->刷工装治具、物料-->刷IPQC工号确认-->刷员工ID数据录入-->刷功能条码结束
    '''注意：扫完功能条码，只要任意扫描其中一个工装、物料就要按照上述流程走完到IPQC确认
    '''IPQC确认完之后才可以切换做其他的工站或是继续数据录入的动作，如果后续回来刷该功能条码，则可以直接扫描员工ID
    '''进行数据录入即：功能条码-->员工ID数据录入-->功能条码结束
    '''无工装物料：
    '''刷功能条码-->刷IPQC工号确认-->刷员工ID数据录入-->刷功能条码结束
    ''' </summary>
    ''' <param name="inputString"></param>
    ''' <remarks></remarks>
    Private Sub CheckInputType(ByVal inputString As String)
        lblMsg.Text = ""
        '扫描是否处理中
        If Not scanP.isInProcess Then
            ProcessScan(inputString)
        Else
            ProcessIng(inputString)
        End If
        txtInput.Text = ""
        txtInput.Focus()
    End Sub

    Private Sub ProcessScan(InputString As String)
        Me.FunctionCodeId = Me.GetFunctionCodeID(InputString)
        If FunctionCodeId = 1 Then
            ' If CheckIsUserID(inputString) AndAlso Not IsIPQC(inputString) Then
            If CheckIsUserID(InputString) Then
                If scanP.isDoFAI Then
                    If Not CheckUserLicence(InputString) Then
                        lblMsg.Text += " (已做完首检可以刷入员工号录入数据)"
                        Exit Sub
                    End If
                    Me.ScanerUserId = InputString
                    scanP.isInProcess = True
                    SetScanProcess(1)
                    lblMsg.Text += " 接下来请刷功能条码"
                    Exit Sub
                End If
                scanP.isFunctionBarcode = False
                ShowCatagoryByUser(InputString)
            End If
        ElseIf FunctionCodeId = 3 Then
            scanP.isFunctionBarcode = False
            DoWoScaning(InputString, FunctionCodeId)
        ElseIf FunctionCodeId = 2 Then
            If Not DoProcess(InputString, FunctionCodeId) Then Exit Sub
            If CheckRouting(InputString) Then
                GetFaiIPQC(InputString)
                SetScanProcess(1)
                SetScanProcess(3)
                SetVerifyTaskProcess()
                lblMsg.Text = "该工站已经扫描,请勿重复扫描"
                Exit Sub
            End If
            If Not CheckVersion() Then
                Exit Sub
            End If
            If dgvVerifyTask.Rows.Count <= 0 Then '无工装物料
                scanP.isInProcess = True
                scanP.isPnCheckFinish = True
                lblMsg.Text = "请刷入IPQC号"
            End If
            scanP.isFunctionBarcode = True
            scanP.functionBarcode = InputString
            If HasDoneFAI() Then
                scanP.isDoFAI = True
                GetFaiIPQC(InputString)
                SetScanProcess(3)
                SetVerifyTaskProcess()

                lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                Exit Sub
            Else
                scanP.isDoFAI = False
            End If
        Else
            If scanP.isFunctionBarcode AndAlso scanP.isDoFAI Then
                If IsIPQC(InputString) Then
                    Me.RegisterReportData(InputString)
                    lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                    Exit Sub
                Else
                    lblMsg.Text = "已做完首检可以刷入员工号录入数据"
                    Exit Sub
                End If
            End If
            If scanP.isFunctionBarcode Then
                If Not IsIPQC(InputString) Then  '' 不是IPQC，就只能是料件或是工治具编号
                    Dim msg1 As String = VerifyPn(InputString, Me.PartId, Me.StationId, Me.WoQty)
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
                If dgvVerifyTask.Rows.Count <= 0 Then
                    If IsIPQC(InputString) Then
                        RegisterReportData(InputString)
                        Me.IpqcUserId = InputString
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
                        Dim msg As String = VerifyPn(InputString, Me.PartId, Me.StationId, Me.WoQty)
                        If msg <> "" Then
                            lblMsg.Text = msg
                            Exit Sub
                        Else
                            SetVerifyProcess(InputString)
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
    End Sub

    Private Sub ProcessIng(InputString As String)
        If scanP.isDoFAI Then
            If IsIPQC(InputString) Then
                RegisterReportData(InputString)
                lblMsg.Text = "已做完首检并刷完员工号可以刷工站条码录入数据"
                Exit Sub
            End If
            If CheckSNFormat(InputString, 2) = "" Then
                lblMsg.Text = "工站条码""" + InputString + """ 格式不正确"
                Exit Sub
            End If
            If InputString.ToUpper <> scanP.functionBarcode.ToUpper Then
                lblMsg.Text = "刷入的工站条码与做首检的不一致"
                Exit Sub
            End If
            SaveData(InputString)
            Exit Sub
        End If
        If Not scanP.isPnCheckFinish Then
            Dim msg As String = VerifyPn(InputString, Me.PartId, Me.StationId, Me.WoQty)
            If Not VerifyIsFinish() Then
                If msg <> "" Then
                    lblMsg.Text = "请刷入料件或是工治具编号"
                    Exit Sub
                Else
                    SetVerifyProcess(InputString)
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
            If IsIPQC(InputString) Then
                RegisterReportData(InputString)
                Me.IpqcUserId = InputString
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
        ElseIf scanP.isPnCheckFinish AndAlso scanP.isCheckIPQC AndAlso IsIPQC(InputString) Then
            RegisterReportData(InputString)
            If Not scanP.isCheckUserId Then
                lblMsg.Text = "已做完首检可以刷入员工号录入数据"
            Else
                lblMsg.Text = "已做完首检并刷完员工号可以刷工站条码录入数据"
            End If
            'end added
        ElseIf scanP.isPnCheckFinish AndAlso scanP.isCheckIPQC AndAlso Not scanP.isCheckUserId Then
            If Not CheckIsUserID(InputString) Then
                lblMsg.Text = "已做完首检请刷入员工号"
                txtInput.Text = ""
                txtInput.Focus()
                Exit Sub
            Else
                If Not CheckUserLicence(InputString) Then
                    lblMsg.Text += " (已做完首检可以刷入员工号录入数据)"
                    Exit Sub
                End If
                Me.ScanerUserId = InputString
                SetScanProcess(1)
                lblMsg.Text += " 接下来请刷入工站条码"
                scanP.isCheckUserId = True
            End If
        ElseIf scanP.isCheckUserId Then
            If CheckSNFormat(InputString, 2) = "" Then
                lblMsg.Text = "工站条码""" + InputString + """ 格式不正确"
                Exit Sub
            End If
            If InputString.ToUpper <> scanP.functionBarcode.ToUpper Then
                lblMsg.Text = "刷入的工站条码与做首检的不一致"
                Exit Sub
            End If
            SaveData(InputString)
        End If
    End Sub

    'Private Function RCardNoPart() As Boolean
    '    Dim dt As DataTable = ScanBusiness.GetRCardPart(Me.PartId, Me.StationId)
    '    If (dt.Rows.Count = 0) Then
    '        Return True
    '    End If
    '    Return False
    'End Function

#Region "ShowError"
    'Private Sub ShowError(ByVal err As String)
    '    Me.lblMsg.Text = err
    '    Me.lblPass.Text = ""
    '    'Me.lblFormat.Text = ""
    '    Me.txtInput.Text = ""
    '    Me.txtInput.Focus()
    'End Sub
#End Region

#Region "ShowTips"
    'Private Sub ShowTips(ByVal tips As String)
    '    Me.lblTips.Text = tips
    '    Me.txtInput.Text = ""
    '    Me.txtInput.Focus()
    '    Me.lblMsg.Text = ""
    '    'Me.lblFormat.Text = ""
    'End Sub
#End Region

#Region "获取条码格式"
    'Private Function GetSNFormat(ByVal functionCodeId As Integer) As String
    '    Return ScanBusiness.GetSNFormat(functionCodeId)
    'End Function

#End Region

#Region "校验条码格式"
    Private Function CheckSNFormat(ByVal sn As String, ByVal functionCodeId As Integer) As String
        Return ScanBusiness.CheckSNFormat(sn, functionCodeId)
    End Function

#End Region

#Region "保存扫描数据"
    Private Function SaveScanData(ByVal sn As String) As String
        Return ScanBusiness.SaveScanData(sn, Me.ScanerUserId)
    End Function

#End Region

#Region "取工站名称"
    Private Function GetStationNameById(ByVal stationId As String) As String
        Dim dt As DataTable
        Dim dr() As DataRow

        dt = ScanBusiness.GetStationNameById(Me.PartId, stationId)
        dr = dt.Select("STATIONID='" & stationId & "'")

        If dr.Length > 0 Then
            LicenceCode = dr(0)("SkillCode").ToString
            ReportType = dr(0)("ReportTypeCode").ToString
            SID = dr(0)("STATIONSQ").ToString
            Return dr(0)("STATIONNAME").ToString
        End If
        Return ""
    End Function
#End Region

#Region "获取用户名"
    Private Function GetUserNameById(ByVal userId As String) As String
        Dim dt As DataTable

        dt = ScanBusiness.GetUserNameById(userId)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString
        End If
        Return ""
    End Function
#End Region

#Region "解析工单"
    Private Sub ParseWorkOrder(ByVal wo As String)
        Dim dt As DataTable

        dt = ScanBusiness.GetWorkOrder(wo)
        If dt.Rows.Count > 0 Then
            Me.WoPn = dt.Rows(0)(0).ToString
            Me.WoQty = CInt(dt.Rows(0)(1).ToString)
        End If
    End Sub
#End Region

#Region "是否已做过首检"
    Private Function HasDoneFAI() As Boolean
        Dim dt As DataTable

        dt = ScanBusiness.GetFirst(Me.SerialNumber, Me.PartId, Me.StationId)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "读取工站条码数据"
    Private Sub ParseSnData(ByVal sn As String)
        '条码格式:F/WorkId/PartId/StationId
        Me.SerialNumber = sn
        Dim StrArray As String() = sn.Split(CChar("/"))
        Me.WorkOrder = StrArray(1).ToString
        Me.StationId = CStr(StrArray(2).ToString)
        Dim dt As DataTable = ScanBusiness.GetMoInfo(Me.WorkOrder)
        If dt.Rows.Count > 0 Then
            Me.PartId = dt.Rows(0)("PartID").ToString
            'Else
            '    lblMsg.Text = ""
        End If
    End Sub

    Private Function GetStandard(ByRef remark As String, ByRef standard As String, ByRef desc As String) As Integer

        Dim stationSq As Integer = 1
        Dim dt As DataTable = Nothing

        dt = ScanBusiness.GetStandard(Me.PartId, Me.StationId)

        For Each row As DataRow In dt.Rows
            remark = row("REMARK").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
            standard = row("PROCESSSTANDARD").ToString.Replace(vbNewLine, "").Replace(Chr(10), "").Replace(Chr(13), "")
            stationSq = CInt(row("STATIONSQ").ToString)
        Next

        Return stationSq

    End Function

    Private Function GetMoConfigQty() As String
        Return ScanBusiness.GetMoConfigQty(Me.WorkOrder, Me.PartId)
    End Function
#End Region

#Region "显示扫描任务"
    Private Sub ShowScanTask(ByVal functionCodeId As Integer)

        Dim dt As DataTable

        dt = ScanBusiness.ShowScanTask(functionCodeId)

        dgvScanTask.Rows.Clear()

        For Each row As DataRow In dt.Rows
            dgvScanTask.Rows.Add(ImageList1.Images(0), row(1), "")
        Next

    End Sub
#End Region

#Region "显示校验信息"
    Private Sub ShowVerifyTask(ByVal partId As String, ByVal stationId As String)
        Dim dt As DataTable

        dt = ScanBusiness.GetVerifyTask(partId, stationId)

        dgvVerifyTask.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgvVerifyTask.Rows.Add(ImageList1.Images(0), row(2).ToString, row(0).ToString(), row(1).ToString(), "", "N")
        Next
    End Sub
#End Region

#Region "根据治具编号取得料号"
    Private Function GetPartNumberByEquipmentNo(ByVal sn As String) As String
        Dim dt As DataTable

        dt = ScanBusiness.GetPartNumberByEquipmentNo(sn)

        If dt.Rows.Count > 0 Then
            Return CStr(dt.Rows(0)(0))
        End If

        Return ""
    End Function
#End Region

#Region "校验料号/治具编号"
    Private Function VerifyPn(ByVal input As String, ByVal partId As String, ByVal stationId As String, ByVal woQty As Integer) As String
        Return ScanBusiness.VerifyPn(input, partId, stationId, woQty)
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
                        If row.Cells("PartNumber").Value.ToString().ToUpper = eqPartNumber.ToUpper Then
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
                        If row.Cells("PartNumber").Value.ToString().ToUpper = input.ToUpper Then
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
                If GetObjValue(row.Cells("ckVerifyFlag").Value) = "N" Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False
    End Function
#End Region

#Region "作业员是否确认"
    Private Function OperatorIsConfirm() As Boolean
        If dgvScanTask.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvScanTask.Rows
                If row.Cells("TaskName").Value.ToString = "员工工号" Then
                    If GetObjValue(row.Cells("ckScanFlag").Value) = "N" Then
                        Return False
                    End If
                End If
            Next
            Return True
        End If
        Return False
    End Function
#End Region

#Region "IPQC是否确认"
    Private Function IpqcIsConfirm() As Boolean
        If dgvScanTask.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvScanTask.Rows
                If row.Cells("TaskName").Value.ToString = "IPQC工号" Then
                    If GetObjValue(row.Cells("ckScanFlag").Value) = "N" Then
                        Return False
                    End If
                End If
            Next
            Return True
        End If
        Return False
    End Function

    Private Function GetObjValue(obj As Object) As String
        If obj Is Nothing Then
            obj = "N"
        End If
        GetObjValue = obj.ToString
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
                            row.Cells("ckScanFlag").Value = "Y"
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
        Dim al As ArrayList = New ArrayList

        For Each row As DataGridViewRow In dgvVerifyTask.Rows
            If Not al.Contains(row.Cells("PartNumber").Value.ToString) Then  'Add If by CQ 20151106
                al.Add(row.Cells("PartNumber").Value.ToString)
            End If
        Next

        ' ScanBusiness.SaveFAIData(Me.SerialNumber, Me.WorkOrder, Me.PartId, Me.StationId, Me.ScanerUserName, Me.IpqcUserName, Me.IpqcUserId, al)
        ScanBusiness.SaveFAIData(Me.SerialNumber, Me.WorkOrder, Me.PartId, Me.StationId, Me.ScanerUserId, Me.IpqcUserId, Me.IpqcUserId, al)
    End Sub

    Private Function RemoveSame(ByVal o_arrList As ArrayList) As ArrayList
        For i As Integer = 0 To o_arrList.Count - 1
            For j As Integer = i + 1 To o_arrList.Count - 1
                If j < o_arrList.Count Then
                    If o_arrList(i).Equals(o_arrList(j)) Then
                        o_arrList.RemoveAt(j)
                    End If
                End If
            Next
        Next
        Return o_arrList
    End Function

    'Private Function RemoveSame(ByVal o_arrList As ArrayList) As ArrayList
    '    For i As Integer = 0 To o_arrList.Count - 1
    '        For j As Integer = i + 1 To o_arrList.Count - 1
    '            If j < o_arrList.Count Then
    '                If o_arrList(i).Equals(o_arrList(j)) Then
    '                    o_arrList.RemoveAt(j)
    '                End If
    '            End If
    '        Next
    '    Next
    '    Return o_arrList
    'End Function

#End Region

#Region "功能条码"
    ''' <summary>
    ''' 功能条码
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFunctionCodeID(ByVal serialNumber As String) As Integer
        Dim dt As DataTable

        dt = ScanBusiness.GetFunctionCodeID(serialNumber)
        If dt.Rows.Count > 0 Then
            Return Convert.ToInt32(dt.Rows(0)(0).ToString())
        End If

        Return 0
    End Function
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
        Dim dt As DataTable
        dt = ScanBusiness.GetSopFile(Me.PartId, Me.StationId)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString
        Else
            Return ""
        End If
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
        Else
            Me.PictureBox1.Image = Nothing
        End If
    End Sub

    Private Function DownLoadSopFile(ByVal path As String) As String
        Try
            'Dim partNumber As String = GetPartNumber()
            Dim partNumber As String = Me.PartId
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

    'Private Function GetPartNumber() As String
    '    Dim dt As DataTable
    '    dt = ScanBusiness.GetPartNumber(Me.PartId)

    '    If dt.Rows.Count > 0 Then
    '        Return dt.Rows(0)(0).ToString
    '    End If

    '    Return ""
    'End Function

#End Region

#Region "显示流程卡"

    Private Sub ShowRunCard(ByVal wo As String)
        '
        dt.Rows.Clear()
        Me.dgvRunCard.AutoGenerateColumns = True

        'RunCard Tial
        Dim ds As DataSet = ScanBusiness.GetRunCard(wo)

        If Not ds Is Nothing Then
            Dim dtHeader As DataTable = ds.Tables(0)
            Dim dtBody As DataTable = ds.Tables(1)
            'header
            For index As Integer = 0 To dtHeader.Rows.Count - 1
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

            Dim totalHours As Integer = 0
            'Dim preHours As Integer = 0
            'Dim proHours As Integer = 0
            'Dim sufHours As Integer = 0
            Dim preHours As Integer = 0, proHours As Integer = 0, sufHours As Integer = 0
            Dim trimHours As Integer = 0, ProPreHours As Integer = 0, autoHours As Integer = 0

            '添加空行
            'Me.dgvRunCard.Rows.Add("", "", "", "", "", "", "", "", "")
            If dt.Rows.Count > 0 Then
                For index As Integer = 0 To dtBody.Rows.Count - 1
                    Select Case dtBody.Rows(index).Item("SectionID").ToString.Trim()
                        Case "1", "01"
                            preHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                        Case "2", "02"
                            proHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                        Case "3", "03"
                            sufHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                        Case "4", "04"
                            trimHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                        Case "5", "05"
                            ProPreHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                        Case "A05"
                            autoHours = CInt(dtBody.Rows(index)("WorkingHours").ToString)
                    End Select
                Next
            End If

            totalHours = preHours + proHours + sufHours + trimHours + ProPreHours + autoHours
            dt.Rows.Add(Nothing, "总工时(s):" & Convert.ToDouble(preHours + proHours + sufHours + trimHours + ProPreHours + autoHours),
                        "铆端前加工(s): " & preHours.ToString, "产线(s): " & proHours.ToString, "成型(s): " & sufHours.ToString,
                        "裁切前(s):" & trimHours.ToString, "生产线前(s):" & ProPreHours.ToString, "半自动压接(s):" & autoHours.ToString)

            Me.dgvRunCard.DataSource = dt
            Me.dgvRunCard.Columns(0).Width = 35
            Me.dgvRunCard.Columns(2).Width = 50
            Me.dgvRunCard.Columns(4).Width = 220
            Me.dgvRunCard.Columns(5).Width = 220
            Me.dgvRunCard.Columns(6).Width = 160
            Me.dgvRunCard.Columns(7).Width = 70
            Me.dgvRunCard.Columns(8).Width = 130
        End If
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

    Private Sub dgvScaningData_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) _
        Handles dgvScaningData.DataBindingComplete
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

    Private Sub SaveData(ByVal InputString As String)
        'ShowSopImage()
        '解析工站条码格式
        ParseSnData(InputString)
        '校验工站，流程卡，工单信息
        Dim msg As String = ""
        msg = ScanBusiness.VerifySnData(InputString, 2)
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
            ResetScanParm()
            lblMsg.Text = msg
            Exit Sub
        End If
        UpdateFAI()
        Me.lblPass.Text = "PASS"
        '刷新显示
        LoadScaningData(Me.ScanerUserId)
        ResetScanParm()
        Dim result As Boolean = False
        result = GetNextStation()
        If result Then
            lblMsg.Text = "加工流程已完成"
        Else
            lblMsg.Text = "本站完成,请去下一站：" + Me.nextStationName
        End If
        ShowCatagoryByUser(Me.ScanerUserId)
        Me.PictureBox1.Image = Nothing
        dgvScanTask.DataSource = Nothing
        dgvVerifyTask.Rows.Clear()
        ShowAllStation()
    End Sub

    Private Sub ShowCatagoryByUser(ByVal inputString As String)
        Dim msg As String = ""
        msg = ScanBusiness.VerifySnData(inputString, 1)
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
            lblStandard.Text += CStr(IIf(String.IsNullOrEmpty(standard), "", "工艺标准：" + standard + "。")) &
                                CStr(IIf(String.IsNullOrEmpty(remark), "", "备注：" + remark + "。")) &
                                CStr(IIf(String.IsNullOrEmpty(desc), "", desc))
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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckVersion() As Boolean
        Dim dt As DataTable
        dt = ScanBusiness.GetVersion(Me.PartId, Me.WorkOrder)

        If dt.Rows.Count <= 0 Then
            lblMsg.Text = "工单版本与BOM不一致,请确认！！"
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="inputString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckRouting(ByVal inputString As String) As Boolean
        Dim dt As DataTable

        dt = ScanBusiness.GetRouting(inputString)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub GetFaiIPQC(ByVal inputString As String)
        Dim dt As DataTable

        dt = ScanBusiness.GetFaiIPQC(inputString)
        If dt.Rows.Count > 0 Then
            Me.ScanerUserId = dt.Rows(0)("USERID").ToString
            Me.IpqcUserId = dt.Rows(0)("IPQC").ToString
        End If
    End Sub

    Private Function IsIPQC(ByVal inputString As String) As Boolean
        Dim dt As DataTable

        dt = ScanBusiness.GetIPQC(inputString)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckRunCardStatus() As Boolean
        Dim dt As DataTable

        dt = ScanBusiness.GetRunCardStatus(Me.PartId)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            lblMsg.Text = "流程卡未生效，无法扫描作业，请找工程人员处理"
            Return False
        End If
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
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
        Dim url As String = Nothing
        Select Case Me.ReportType
            Case ReportTypeEnum.TP.ToString '裁线脱皮报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/SeeWireCutting/Add?backUrl=%2FPaperLess%2FSeeWireCutting%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.CX.ToString '成型报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/MPQuality/Add?backUrl=%2FPaperLess%2FMPQuality%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.DC.ToString '电测报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/ElectricalMeasurement/Add?backUrl=%2FPaperLess%2FElectricalMeasurement%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.HJ.ToString '焊接报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Welding/Add?backUrl=%2FPaperLess%2FWelding%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.JX.ToString '浸锡报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.YJ.ToString '压接报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Crimp/Add?backUrl=%2FPaperLess%2FCrimp%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case ReportTypeEnum.ZZ.ToString '组装品质报表
                url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Assemble/Add?backUrl=%2FPaperLess%2FAssemble%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}&Factoryid={4}&Profitcenter={5}",
                                    Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString, Factoryid, Profitcenter)
            Case Else
                url = Nothing
        End Select
        'Select Case Me.ReportType
        '    Case ReportTypeEnum.TP.ToString '裁线脱皮报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/SeeWireCutting/Add?backUrl=%2FPaperLess%2FSeeWireCutting%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case ReportTypeEnum.CX.ToString '成型报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/MPQuality/Add?backUrl=%2FPaperLess%2FMPQuality%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case ReportTypeEnum.DC.ToString '电测报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/ElectricalMeasurement/Add?backUrl=%2FPaperLess%2FElectricalMeasurement%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '        'url = "http://dcs.luxshare-ict.com:17888/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode=E511D-150100274-Z001&stationId=523&WorkCode=%E8%A3%81%E7%BA%BF/%E8%84%B1%E7%9A%AE2"
        '    Case ReportTypeEnum.HJ.ToString '焊接报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Welding/Add?backUrl=%2FPaperLess%2FWelding%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case ReportTypeEnum.JX.ToString '浸锡报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Wicking/Add?backUrl=%2FPaperLess%2FWicking%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case ReportTypeEnum.YJ.ToString '压接报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Crimp/Add?backUrl=%2FPaperLess%2FCrimp%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case ReportTypeEnum.ZZ.ToString '组装品质报表
        '        url = String.Format("http://dcs.luxshare-ict.com/PaperLess/Assemble/Add?backUrl=%2FPaperLess%2FAssemble%2FIndex&ProductionCode={0}&stationId={1}&WorkCode={2}&Operator={3}", Me.WorkOrder, Me.StationId, HttpUtility.UrlEncode(Me.StationName, Encoding.GetEncoding("utf-8")).ToUpper, inputString)
        '    Case Else
        '        url = Nothing
        'End Select

        If Not String.IsNullOrEmpty(url) Then

            If (frm.IsDisposed) Then 'Add by cq,20150521
                frm = New FrmLotReportRegister '如果已经销毁，则重新创建子窗口对象
            End If

            frm.url = url
            frm.TopMost = True
            frm.ShowDialog()
        End If
    End Sub

    Private Function CheckIsUserID(ByVal inputString As String) As Boolean
        Dim dt As DataTable

        dt = ScanBusiness.GetUser(inputString)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckUserLicence(ByVal inputString As String) As Boolean
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

    ''' <summary>
    ''' 更新首检
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateFAI()
        ScanBusiness.UpdateFAI(Me.ScanerUserId, Me.SerialNumber, Me.PartId, Me.StationId)
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
        Dim dt As DataTable

        dt = ScanBusiness.GetUserWork(Me.SerialNumber, Me.PartId, Me.StationId)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetNextStation() As Boolean
        Dim dt As DataTable = ScanBusiness.GetNextStation(Me.PartId, Me.StationId)
        If dt.Rows.Count > 0 Then
            Me.nextStationId = dt.Rows(0)("StationID").ToString
            Me.nextStationName = dt.Rows(0)("StationName").ToString
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ShowAllStation()
        Dim dt As DataTable

        dt = ScanBusiness.GetAllStaion(Me.PartId, Me.WorkOrder)

        dgvStationStaus.Rows.Clear()

        For Each row As DataRow In dt.Rows
            dgvStationStaus.Rows.Add(row(StatusEnum.Status1).ToString, row(StatusEnum.Status2).ToString,
                                    row(StatusEnum.Status3).ToString, row(StatusEnum.Status4).ToString,
                                    row(StatusEnum.Status5).ToString, row(StatusEnum.Status6).ToString,
                                    row(StatusEnum.Status7).ToString, row(StatusEnum.Status8).ToString,
                                    row(StatusEnum.Status9).ToString, row(StatusEnum.Status10).ToString)
        Next

        If dgvStationStaus.Rows.Count > 0 Then
            SetStatusColor(CInt((Panel2.Height - 22) / dgvStationStaus.Rows.Count))
            dgvStationStaus.ClearSelection()
            Panel2Show(True)
        End If
    End Sub

    Public Sub FunctionAssign(ByVal input As String)
        Try
            If input = "RESET" Then
                IniteScan()
                ResetScanParm()
                txtInput.Select()
                txtInput.SelectAll()
                lblMsg.Text = "重置成功,请继续"
                'txtAction.Text = "辅助功能"
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
    Private Sub dgvRunCard_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) _
        Handles dgvRunCard.CellToolTipTextNeeded
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
            For i As Integer = 0 To CInt(totalLength / rowLength)
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
                SetStatusColor(row, StatusEnum.Status1)
                SetStatusColor(row, StatusEnum.Status2)
                SetStatusColor(row, StatusEnum.Status3)
                SetStatusColor(row, StatusEnum.Status4)
                SetStatusColor(row, StatusEnum.Status5)
                SetStatusColor(row, StatusEnum.Status6)
                SetStatusColor(row, StatusEnum.Status7)
                SetStatusColor(row, StatusEnum.Status8)
                SetStatusColor(row, StatusEnum.Status9)
                SetStatusColor(row, StatusEnum.Status10)
            Next
        End If
    End Sub

    Private Sub SetStatusColor(row As DataGridViewRow, status As StatusEnum)
        If Not row.Cells(status).Value Is Nothing AndAlso Not String.IsNullOrEmpty(CStr(row.Cells(status).Value)) Then
            If row.Cells(status).Value.ToString.Substring(row.Cells(status).Value.ToString.IndexOf(".") + 1, 2) = "未检" Then
                row.Cells(status).Style.BackColor = Color.White
            ElseIf row.Cells(status).Value.ToString.Substring(row.Cells(status).Value.ToString.IndexOf(".") + 1, 2) = "已检" Then
                row.Cells(status).Style.BackColor = Color.Yellow
            ElseIf row.Cells(status).Value.ToString.Substring(row.Cells(status).Value.ToString.IndexOf(".") + 1, 2) = "已录" Then
                row.Cells(status).Style.BackColor = Color.LimeGreen
            End If
            row.Cells(status).Value = row.Cells(status).Value.ToString.Substring(0, row.Cells(status).Value.ToString.IndexOf("."))
        End If
    End Sub

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
                        celArgs.Graphics.DrawString(totalQty.ToString, celArgs.CellStyle.Font, New SolidBrush(celArgs.CellStyle.ForeColor), CSng(rectBegin.Left + lstr), CSng(rectEnd.Top + rstr), StringFormat.GenericDefault)
                    End If
                End If
            End Using
            celArgs.Handled = True
        End Using
    End Sub
#End Region
End Class

Public Class ScanParam
    ''' <summary>
    ''' 是否处理中
    ''' </summary>
    ''' <remarks></remarks>
    Public isInProcess As Boolean = False
    ''' <summary>
    ''' 是否功能BARcode
    ''' </summary>
    ''' <remarks></remarks>
    Public isFunctionBarcode As Boolean = False
    ''' <summary>
    ''' 是检查用户ID
    ''' </summary>
    ''' <remarks></remarks>
    Public isCheckUserId As Boolean = False
    ''' <summary>
    ''' 是否IPQC
    ''' </summary>
    ''' <remarks></remarks>
    Public isCheckIPQC As Boolean = False
    ''' <summary>
    ''' 是否检查完成
    ''' </summary>
    ''' <remarks></remarks>
    Public isPnCheckFinish As Boolean = False
    ''' <summary>
    ''' 功能BarCode
    ''' </summary>
    ''' <remarks></remarks>
    Public functionBarcode As String = ""
    ''' <summary>
    ''' 是否首检
    ''' </summary>
    ''' <remarks></remarks>
    Public isDoFAI As Boolean = False
End Class