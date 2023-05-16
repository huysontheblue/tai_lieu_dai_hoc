Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.Text
Imports SampleManage.SampleCom
Imports System.IO
Imports DevComponents.DotNetBar

''' <summary>
''' 创建者： cq
''' 修改日： 2016/10/27
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>V1.0</remarks>
Public Class FrmSample
    Private dics As New List(Of KeyValue)
    Private Enum enumdgvSample
        ID
        checkbox
        SampleNo ' 
        PartNo
        DevNo
        MadeQty
        DeliveryDate
        RDUserName
        Status
        StdTime
        MOID
        LineID
        MOQty
        OKQty
        NGQty
        PZPath
        ZCPath
        ProjectPath
        ZJPath
    End Enum
    Public Enum SampleFilterType
        生管
        样品室
        PIE
        品质
        Userself
    End Enum

    Public Enum LeftSampe
        SampleNo
        PartNo
        Status
        RDUserName
        YPSUserName
        EquUserName
    End Enum
#Region "属性定义"

    Private m_ChkboxAll As New CheckBox
    Private _sampleNumber As String
    Public Property SampleNumber() As String
        Get
            Return _sampleNumber
        End Get
        Set(ByVal Value As String)
            _sampleNumber = Value
        End Set
    End Property

    Private _pzSumFileName As String
    Public Property PZSumFileName() As String
        Get
            Return _pzSumFileName
        End Get

        Set(ByVal Value As String)
            _pzSumFileName = Value
        End Set
    End Property

    Private _zjFileName As String
    Public Property ZJFileName() As String
        Get
            Return _zjFileName
        End Get

        Set(ByVal Value As String)
            _zjFileName = Value
        End Set
    End Property

    Private _zcSumFileName As String
    Public Property ZCSumFileName() As String
        Get
            Return _zcSumFileName
        End Get

        Set(ByVal Value As String)
            _zcSumFileName = Value
        End Set
    End Property

    Private _madeDocFileName As String
    Public Property MadeDocFileName() As String
        Get
            Return _madeDocFileName
        End Get

        Set(ByVal Value As String)
            _madeDocFileName = Value
        End Set
    End Property


    Private _projectSumFileName As String
    Public Property ProjectSumFileName() As String
        Get
            Return _projectSumFileName
        End Get

        Set(ByVal Value As String)
            _projectSumFileName = Value
        End Set
    End Property
#End Region
#Region "左边树DataTable"
    Private _LeftTreeDataTable As DataTable
    Public Property LeftTreeDataTable() As DataTable
        Get
            Return _LeftTreeDataTable
        End Get

        Set(ByVal Value As DataTable)
            _LeftTreeDataTable = Value
        End Set
    End Property
#End Region
    Private opflag As Integer
    Private m_blnMaintainMO As Boolean
    Private m_strCurrentUserName As String
    Private m_strCurrentUserDept As String

    Private Sub FrmEquipmentReqD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        LabelPrintHelper.InitPrinter(cboPrinter)

        SampleCom.BindComboxStatus(cboQueryStatus)
        ' SampleCom.BindComboxLine(cboLineID)
        GetListData()

        m_strCurrentUserName = SampleCom.GetUserName(VbCommClass.VbCommClass.UseId)
        m_strCurrentUserDept = SampleCom.GetUserDept(VbCommClass.VbCommClass.UseId)

        Me.ToolDownMO.Enabled = IIf(m_strCurrentUserDept = SampleCom.EnumSampleDept.生管.ToString, True, False)
        LoadSideBarByClick("", m_strCurrentUserDept)

        Me.dgvSample.ContextMenuStrip = Me.ContextMenuStrip
    End Sub

    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As String, Optional blnRefresh As Boolean = False)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Dim dvSample As DataView = Nothing
        Dim dvSampleCopy As DataView = Nothing
        Try
            item.Image = ImageList1.Images(0)
            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left

            If LeftTreeDataTable Is Nothing OrElse LeftTreeDataTable.Rows.Count < 1 OrElse blnRefresh Then
                '填充数据
                If SetSideBarData() = False Then Exit Sub
            End If

            dvSample = New DataView(LeftTreeDataTable)
            dvSampleCopy = dvSample
            '晒选
            ' dvSample.Sort = "InTime " & sort & ",MODIFYTIME " & sort

            Call FillUserSelfData(dvSampleCopy)

            Select Case type
                Case SampleFilterType.生管.ToString
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.生管.ToString Then
                        dvSample.RowFilter = "SGUserName='" & m_strCurrentUserName & "' AND  SGFinishFlag='0'"
                    End If
                    '清除现有Item
                    SideBarPanelSG.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelSG.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelSG
                Case SampleFilterType.样品室.ToString
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.样品室.ToString Then
                        dvSample.RowFilter = "YPSUserName='" & m_strCurrentUserName & "' AND YPSFinishFlag = '0'"
                    End If
                    '清除现有Item
                    SideBarPanelYPS.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelYPS.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelYPS
                Case SampleFilterType.品质.ToString
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.品质.ToString Then
                        dvSample.RowFilter = "PZUserName='" & m_strCurrentUserName & "' AND PZFinishFlag = '0'"
                    End If
                    '清除现有Item
                    SideBarPanelPZ.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelPZ.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelPZ
                Case SampleFilterType.PIE.ToString
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.PIE.ToString Then
                        dvSample.RowFilter = "PIEUserName='" & m_strCurrentUserName & "'AND PIEFinishFlag = '0'"
                    End If
                    '清除现有Item
                    SideBarPanelPIE.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelPIE.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelPIE
            End Select

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "LoadSideBarByClick", "Sample")
        End Try
    End Sub

    Private Sub FillUserSelfData(ByVal o_dvSample As DataView)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Try
            Select Case m_strCurrentUserDept
                Case EnumSampleDept.生管.ToString
                    o_dvSample.RowFilter = "SGUserName='" & m_strCurrentUserName & "'AND SGFinishFlag = '1'"
                Case EnumSampleDept.PIE.ToString
                    o_dvSample.RowFilter = "PIEUserName='" & m_strCurrentUserName & "'AND PIEFinishFlag = '1'"
                Case EnumSampleDept.样品室.ToString
                    o_dvSample.RowFilter = "YPSUserName='" & m_strCurrentUserName & "'AND YPSFinishFlag = '1'"
                Case EnumSampleDept.品质.ToString
                    o_dvSample.RowFilter = "PZUserName='" & m_strCurrentUserName & "'AND PZFinishFlag = '1'"
                Case Else
                    Exit Sub
            End Select
            '清除现有Item
            SideBarPanelUserself.SubItems.Clear()
            '遍历
            For Each drv As DataRowView In o_dvSample
                newItem = item.Copy()
                newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                lst = New ArrayList
                lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                newItem.Tag = lst
                SideBarPanelUserself.SubItems.Add(newItem)
                index += 1
                If index > 100 Then Exit For
            Next
            SideBar1.ExpandedPanel = SideBarPanelUserself


            'Select Case m_strCurrentUserDept
            '    Case EnumSampleDept.生管.ToString
            '        dvSample.RowFilter = "SGUserName='" & m_strCurrentUserName & "'AND SGFinishFlag = '1'"
            '    Case EnumSampleDept.PIE.ToString
            '        dvSample.RowFilter = "PIEUserName='" & m_strCurrentUserName & "'AND PIEFinishFlag = '1'"
            '    Case EnumSampleDept.品质.ToString
            '        dvSample.RowFilter = "PZUserName='" & m_strCurrentUserName & "'AND PZFinishFlag = '1'"
            '    Case EnumSampleDept.样品室.ToString
            '        dvSample.RowFilter = "YPSUserName='" & m_strCurrentUserName & "'AND YPSFinishFlag = '1'"
            'End Select
            ''清除现有Item
            'SideBarPanelUserself.SubItems.Clear()
            ''遍历
            'For Each drv As DataRowView In dvSample
            '    newItem = item.Copy()
            '    newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
            '    newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
            '    lst = New ArrayList
            '    lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
            '    lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
            '    newItem.Tag = lst
            '    SideBarPanelUserself.SubItems.Add(newItem)
            '    index += 1
            '    If index > 100 Then Exit For
            'Next
            'SideBar1.ExpandedPanel = SideBarPanelUserself



        Catch ex As Exception
        Finally
            o_dvSample = Nothing
        End Try
    End Sub

    Private Function SetSideBarData() As Boolean
        Dim r As Boolean = False
        Try
            Dim strSQL As String = Nothing
            Dim dt As DataTable = Nothing
            Me._LeftTreeDataTable = Nothing
            strSQL = " SELECT SampleNo,PartNo,Status,SGUserName,YPSUserName, PZUserName,PIEUserName, " & _
                     " isnull(SGFinishFlag,'0')SGFinishFlag, isnull(YPSFinishFlag,'0')YPSFinishFlag, " & _
                     " isnull(PZFinishFlag,'0')PZFinishFlag, isnull(PIEFinishFlag,'0')PIEFinishFlag " & _
                     " FROM m_Sample_t a " & _
                     " Where 1=1 AND  Status ='0'  ORDER BY DeliveryDate DESC "
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me._LeftTreeDataTable = dt
                '统计数量
                SetSideBarPanelAmout()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "SetSideBarData", "Sample")
        End Try
        Return True
    End Function

    Private Sub SetSideBarPanelAmout()
        Try
            Dim dv As DataView = Nothing
            dv = New DataView(LeftTreeDataTable)
            dv.RowFilter = " SGUserName='" & m_strCurrentUserName & "' AND SGFinishFlag ='0'"
            SideBarPanelSG.Text = SideBarPanelSG.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " PZUserName='" & m_strCurrentUserName & "' AND PZFinishFlag ='0'"
            SideBarPanelPZ.Text = SideBarPanelPZ.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " PIEUserName='" & m_strCurrentUserName & "' AND PIEFinishFlag ='0'"
            SideBarPanelPIE.Text = SideBarPanelPIE.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " YPSUserName='" & m_strCurrentUserName & "'AND YPSFinishFlag ='0'"
            SideBarPanelYPS.Text = SideBarPanelYPS.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            Select Case m_strCurrentUserDept
                Case EnumSampleDept.生管.ToString
                    dv.RowFilter = " SGUserName='" & m_strCurrentUserName & "'AND SGFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.PIE.ToString
                    dv.RowFilter = " PIEUserName='" & m_strCurrentUserName & "'AND PIEFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.品质.ToString
                    dv.RowFilter = " PZUserName='" & m_strCurrentUserName & "'AND PZFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.样品室.ToString
                    dv.RowFilter = " YPSUserName='" & m_strCurrentUserName & "'AND YPSFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case Else
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + "0" + ")"
            End Select


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "SetSideBarPanelAmout", "Sample")
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导出
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Dim strSQL As String = String.Empty
        Dim strSGName As String = String.Empty
        Try
            '客户,生管接单,业务下单,需求时间,业务部门,业务(Name),	
            '开发案号,线别,料件编号, E-BOM参考编码,备注,工单编号,批量,出货量	
            '研发	交期	料况	工治具	模具	天数	系统	未完工
            'default get the SG UserName
            If Not String.IsNullOrEmpty(Me.txtRDUserName.Text) Then
                strSGName = GetInputSGName()
            Else
                strSGName = GetSGName()
            End If

            strSQL =
                " SELECT SampleNo 样品单号, b.CusName 客户, '' as 生管接单, '' as 业务下单,  YWUserName as  业务," & _
                " a.DevNo 开发案号, '' as 线别, PartNo 料件编号, EBOMPartNo as EBOM参考编码, " & _
                " '' as 备注, '' as 工单编号,  " & _
                " MadeQty 批量, Qty 出货量, a.RDUserName 研发," & _
                " '' as 交期, '' as 料况, '' as 工治具, '' as  模具, '' as 天数, '' as 系统, ''未完工" & _
                " FROM m_Sample_t a LEFT JOIN  m_Customer_t b ON  a.CustID = b.CusID" & _
                " WHERE 1=1  " &
            SampleCom.GetFatoryProfitcenter()

            If Not String.IsNullOrEmpty(strSGName) Then
                strSQL = strSQL + " AND a.SGUserName=N'" & strSGName & "'"
            End If

            If chkRequsteTime.Checked = True Then
                strSQL = strSQL + String.Format(" AND CONVERT(NVARCHAR(10), A.DeliveryDate ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
                strSQL = strSQL + String.Format(" AND CONVERT(NVARCHAR(10), A.DeliveryDate ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)
            End If

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "toolExcel_Click", "Sample")
        End Try
    End Sub

    Private Function GetSGName() As String
        'first get current user Name
        Dim lsSQL As String = "", strDutyDeptName As String = ""
        GetSGName = ""
        lsSQL = " SELECT DutyDeptName, DutyUserName FROM m_SamplePic_t " & _
                " WHERE DutyUserID ='" & VbCommClass.VbCommClass.UseId & "' AND USEY ='Y' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                strDutyDeptName = o_dt.Rows(0).Item(0)
                If strDutyDeptName = SampleCom.EnumSampleDept.生管.ToString Then
                    GetSGName = o_dt.Rows(0).Item("DutyUserName")
                Else
                    GetSGName = GetInputSGName()
                End If
            Else
                ' get the input SG UserName
                GetSGName = GetInputSGName()
            End If
        End Using
        Return GetSGName
    End Function

    Private Function GetInputSGName() As String
        Dim lsSQL As String = "", strDutyDeptName As String = ""
        GetInputSGName = ""
        lsSQL = " SELECT DutyDeptName, DutyUserName FROM m_SamplePic_t " & _
                " WHERE DutyUserName = N'" & txtRDUserName.Text.Trim & "' AND USEY ='Y' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                strDutyDeptName = o_dt.Rows(0).Item(0)
                If strDutyDeptName = SampleCom.EnumSampleDept.生管.ToString Then
                    GetInputSGName = o_dt.Rows(0).Item("DutyUserName")
                End If
            Else
                GetInputSGName = ""
            End If
        End Using
        Return GetInputSGName
    End Function

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            GetListData()
            LoadSampleDetail(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "toolRefresh_Click", "Sample")
        End Try
    End Sub

    Private Function GetDTbyWhere(strSQL As String) As DataTable
        Dim strQueryRDNamelist As String = ""
        Dim o_strDutyDeptName As String = ""
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtSampleNo.Text) = False Then
            strWhere.AppendFormat(" AND a.SampleNo LIKE '{0}%' ", txtSampleNo.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryDevNo.Text.Trim) = False Then
            strWhere.AppendFormat(" AND DevNo LIKE '{0}%' ", txtQueryDevNo.Text.Trim)
        End If

        If Not String.IsNullOrEmpty(txtQueryPn.Text.Trim) Then
            strWhere.AppendFormat(" AND PartNo LIKE '{0}%' ", txtQueryPn.Text.Trim)
        End If

        'If Not String.IsNullOrEmpty(txtRDUserName.Text.Trim) Then
        '    strWhere.AppendFormat(" AND RDUserName LIKE N'{0}%' ", txtRDUserName.Text.Trim)
        'End If

        'If Me.txtRDUserName.Text <> "" Then
        '    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
        '        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
        '        strWhere.Append(" AND a.RDUserName IN (" & strQueryRDNamelist & ") ")
        '    Else
        '        strWhere.Append(" AND a.RDUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
        '    End If
        'End If

        If Me.txtRDUserName.Text <> "" Then
            o_strDutyDeptName = SampleCom.GetUserDeptByName(Me.txtRDUserName.Text.Split(",")(0))
            Select Case o_strDutyDeptName
                Case SampleCom.EnumSampleDept.研发.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.RDUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.RDUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.样品室.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.YPSUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.YPSUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.生管.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.SGUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.SGUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.设备.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.EquUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.EquUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.治具.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.ZJUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.ZJUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.业务.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.YWUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.YWUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case SampleCom.EnumSampleDept.PIE.ToString
                    If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                        strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                        strWhere.Append(" AND a.PIEUserName IN (" & strQueryRDNamelist & ") ")
                    Else
                        strWhere.Append(" AND a.PIEUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                    End If
                Case Else
                    'do nothing
            End Select
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryStatus.SelectedValue.ToString)) = False Then
            strWhere.AppendFormat(" AND a.Status = '{0}' ", cboQueryStatus.SelectedValue.ToString)
        Else
            ' strWhere.Append(" AND a.Status ='0'")  'mark by cq 20170119
        End If
        If chkRequsteTime.Checked = True Then
            strWhere.AppendFormat(" AND CONVERT(NVARCHAR(10), A.DeliveryDate ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
            strWhere.AppendFormat(" AND CONVERT(NVARCHAR(10), A.DeliveryDate ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)
        End If
        Dim strOrderBy As String = " ORDER BY A.InTime DESC"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrderBy)
        Return dt
    End Function

    '获取样品申请单
    Private Sub GetListData()
        '      SELECT TOP 1000 '0' as chkSelect,a.SampleNo,a.PartNo, DevNo, Qty,DeliveryDate, RDUserName,  
        '(a.Status +'.'+ b.text) Status, 
        '--isnull(d.QuoteHour,a.StdTime) as StdTime, 
        'isnull( (select top 1 dd.QuoteHour from m_RCardQuoteMaintenance dd where dd.PartNumber = a.PartNo order by dd.QuoteNo desc),a.StdTime) StdTime,
        'a.MOID, A.LineID , a.MOQty, a.OKQty, a.NGQty,c.MadeDocPath,c.PZPath, 
        'c.ZCPath, c.ProjectPath  
        'FROM m_Sample_t A  JOIN m_SampleBaseData_t b ON a.Status = b.StatusValue   
        'LEFT JOIN m_SampleSumDocument_t c ON a.SampleNO = c.SampleNO   
        '--LEFT JOIN m_RCardQuoteMaintenance d on a.PartNO = d.PartNumber 
        'WHERE 1=1  AND A.Factoryid='LXXT' AND A.Profitcenter= 'SEE-D' 
        '--and A.SampleNo='SAP16-0000022011'
        'ORDER BY A.InTime DESC
        'ISNULL((select TOP 1 dd.QuoteHour from m_RCardQuoteMaintenance dd WHERE dd.PartNumber = a.PartNo ORDER BY dd.QuoteNo DESC),a.StdTime) StdTime
        Dim strSQL As String =
         " SELECT TOP 1000 '0' as chkSelect,a.SampleNo,a.PartNo, DevNo, MadeQty,DeliveryDate, RDUserName, " & _
        " (a.Status +'.'+ b.text) Status, " & _
        " IIF(ISNULL(a.StdTime,'')='', " & _
        " (select TOP 1 dd.QuoteHour from m_RCardQuoteMaintenance dd WHERE dd.PartNumber = a.PartNo ORDER BY dd.QuoteNo DESC),a.StdTime) StdTime," & _
        " a.MOID, A.LineID , a.MOQty, a.OKQty, a.NGQty, " & _
        " (case  a.PZResult when '0' then N'不合格' when '1' then N'合格' else '' end) PZResult, " & _
        " c.MadeDocPath,c.PZPath, c.ZCPath, c.ProjectPath ,c.ZJPath" & _
        " FROM m_Sample_t A  JOIN m_SampleBaseData_t b ON a.Status = b.StatusValue  " & _
        " LEFT JOIN m_SampleSumDocument_t c ON a.SampleNO = c.SampleNO  " & _
        " WHERE 1=1 " &
        SampleCom.GetFatoryProfitcenter("A")

        dgvSample.DataSource = GetDTbyWhere(strSQL)

        'Add by cq 20170207
        Me.m_ChkboxAll.Text = "选择"
        Me.dgvSample.Controls.Add(Me.m_ChkboxAll)
        AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
        AddHandler dgvSample.CellPainting, AddressOf dgvSample_CellPainting

        dgvSample.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        If Me.dgvSample.Rows.Count <= 0 Then Exit Sub
        Me.dgvSample.EndEdit()

        For Each Row As DataGridViewRow In Me.dgvSample.Rows
            Row.Cells(1).Value = IIf(m_ChkboxAll.Checked = True, "1", "0")
        Next
    End Sub

    Private Sub dgvSample_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvSample.CellClick

        Try
            If e.RowIndex = -1 Then Exit Sub
            Me.dgvSample.Columns(0).ReadOnly = False

            ' LoadSampleMO(e.RowIndex)
            LoadSampleDetail(e.RowIndex)
            LoadSampleDocument(e.RowIndex)

            Me.txtSampleNo.Text = DbOperateUtils.DBNullToStr(Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.SampleNo).Value)
            'If Not IsDBNull(Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.PartNo).Value) Then
            '    Me.txtQueryPn.Text = Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.PartNo).Value
            'End If

            'If Not IsDBNull(Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.MOID).Value) Then
            '    Me.txtMOID.Text = Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.MOID).Value
            'End If

            'If Not IsDBNull(Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.LineID).Value) Then
            '    Me.cboLineID.Text = Me.dgvSample.Rows(e.RowIndex).Cells(enumdgvSample.LineID).Value
            'End If

            ' Me.txtStdTime.Text = SampleBusiness.GetStdTime(Me.txtQueryPn.Text.Trim)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "dgvSample_CellClick", "Sample")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadSampleMO(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim SampleNo As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvSample.Rows.Count = 0 Then
                Exit Sub
            End If
            '     MOID, LineID, LineLeader, MO
            strSQL =
                " SELECT a.MOID, a.LineID, b.LineLeader, a.MOFinishDate, a.MOQty" & _
                " FROM m_SampleMO_t a  LEFT JOIN m_SampleLine_t b ON a.LineID = b.LineID " & _
                " WHERE 1=1 AND a.UseY='1'"

            '0.编号, 1.
            If IsNothing(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) OrElse IsDBNull(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) Then
                Exit Sub
            Else
                SampleNo = dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value
            End If

            strWhere = String.Format(" AND a.SampleNo = '{0}'", SampleNo)
            Dim strOrder As String = " ORDER BY a.Intime DESC "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            ' dgvSampleMO.DataSource = dt
            ' dgvSampleMO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "LoadSampleMO", "Sample")
        End Try
    End Sub

    Private Sub LoadSampleDocument(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim SampleNo As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvSample.Rows.Count = 0 Then
                Exit Sub
            End If
            ' [SampleNo],[type] ,[Path] ,[typedes]
            strSQL = " SELECT SampleNO 样品单号,  type 文档类型, Path 文档路径 " & _
                              " FROM m_SampleDocument_t a  " & _
                              " WHERE 1 = 1 "

            '0.编号, 1.
            If IsNothing(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) OrElse IsDBNull(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) Then
                Exit Sub
            Else
                SampleNo = dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value
            End If

            strWhere = String.Format(" AND a.SampleNo = '{0}'", SampleNo)
            Dim strOrder As String = " ORDER BY a.sampleNo "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvDocument.DataSource = dt

            dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "LoadSampleDocument", "Sample")
        End Try
    End Sub

    Private Sub LoadSampleDetail(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim SampleNo As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvSample.Rows.Count = 0 Then
                Exit Sub
            End If
            '     LevelID Status DutyUserID,StartTime EndTime
            strSQL =
                  " SELECT (Cast(a.LevelID as varchar) + '.' + b.levelName) Levelid  , " & _
                " CASE a.FinishFlag WHEN 0 THEN N'0.进行中' WHEN 1 THEN N'1.已完成' ELSE  N'0.进行中' END STATUS ,d.DutyUserName as PICUserID,a.PlanDueDate" & _
                " ,StartTime,Finishtime" & _
                " FROM m_SampleD_t a " & _
                " LEFT JOIN m_SampleLevel_t b ON a.levelid = b.levelid " & _
                " LEFT JOIN m_SamplePICD_t d ON d.sampleno=a.sampleno AND d.DeptName = b.DutyDept " & _
                " WHERE 1=1 "

            '0.编号, 1.
            If IsNothing(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) OrElse IsDBNull(dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) Then
                Exit Sub
            Else
                SampleNo = dgvSample.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value
            End If

            strWhere = String.Format(" AND a.SampleNo = '{0}'", SampleNo)
            Dim strOrder As String = " ORDER BY a.Levelid "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvSampleD.DataSource = dt

            dgvSampleD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSample", "LoadSampleDetail", "Sample")
        End Try
    End Sub

    Private Sub cboQueryClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' If cboQueryClass.SelectedValue IsNot Nothing Then
        'EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        'End If
    End Sub

    '打印
    Private Sub toolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPrint.Click
        Dim msg As String = Nothing
        Dim fileName As String = Nothing
        Dim copies As Integer = 1
        Dim index As Integer = 1
        Dim prePage As Integer = 1
        Try
            dics.Clear()
            Dim printPath As String = VbCommClass.VbCommClass.PrintDataModle + "SampleTemplate\"

            For Each row As DataGridViewRow In dgvSample.Rows
                If Not row.Cells(enumdgvSample.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(enumdgvSample.checkbox).EditedFormattedValue.ToString = "True" Then
                    dics.Add(New KeyValue(copies, "SampleNo", row.Cells(enumdgvSample.SampleNo).Value.ToString))
                    dics.Add(New KeyValue(copies, "MadeQty", row.Cells(enumdgvSample.MadeQty).Value.ToString))
                    index += 1
                End If
                If index = 4 Then
                    index = 1
                    copies += 1
                End If
            Next
            prePage = 4
            fileName = printPath + "SampleNo.btw"
            ' copies = System.Math.Ceiling(dics.Count / (prePage * 3))

            If Not BasicCheck() Then
                Exit Sub
            End If

            If SampleCom.LabelPrintHelper.PrintLabel(dics, cboPrinter.Text, msg, fileName, prePage, 1) Then
                MessageUtils.ShowInformation("打印成功")
            Else
                MessageUtils.ShowError(msg)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSample", "toolPrint_Click", "Sample")
            ' MessageUtils.ShowError(ex.Message)
        End Try
    End Sub


    Private Function BasicCheck() As Boolean
        If cboPrinter.SelectedIndex = -1 Then
            MessageUtils.ShowError("请选择打印机")
            cboPrinter.Focus()
            Return False
        End If
        If dics.Count <= 0 Then
            MessageUtils.ShowError("请选择需要列印的样品单号")
            Return False
        End If
        Return True
    End Function

#Region "Grid行数"
    Private Sub dgvResult_RowPostPaint(sender As Object, e As Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvSample.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Dim o_strTempStdTime As String = String.Empty

        Me.toolSave.Enabled = True
        Me.toolBack.Enabled = True
        Me.toolEdit.Enabled = False
        Me.txtSampleNo.Enabled = False
        Me.txtQueryDevNo.Enabled = False
        Me.txtQueryPn.Enabled = False

        Me.txtSampleNo.Text = DbOperateUtils.DBNullToStr(Me.dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value)

        If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.DevNo).Value) Then
            Me.txtQueryDevNo.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.DevNo).Value
        End If

        If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.PartNo).Value) Then
            Me.txtQueryPn.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.PartNo).Value
        End If

        'If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.MOID).Value) Then
        '    Me.txtMOID.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.MOID).Value
        'End If

        If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.OKQty).Value) Then
            Me.txtOKQty.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.OKQty).Value
        End If

        'If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.NGQty).Value) Then
        '    Me.txtNGQty.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.NGQty).Value
        'End If

        'If Not IsDBNull(Me.dgvSample.CurrentRow.Cells(enumdgvSample.StdTime).Value) Then
        '    Me.txtStdTime.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.StdTime).Value
        'Else
        '    o_strTempStdTime = SampleCom.GetStdTime(Me.txtQueryPn.Text)
        '    If Not String.IsNullOrEmpty(o_strTempStdTime) Then
        '        Me.txtStdTime.Text = o_strTempStdTime
        '    Else
        '        'Sqlstr.Append(ControlChars.CrLf & " EXEC m_MailSend_p @SUBJECT = N'料号[" & Me.TxtPartid.Text.Trim & "]产品报价工时维护提醒', @Body = N'料号[" & Me.TxtPartid.Text.Trim & "]产品条码标签室已经新增,请进入MES系统审核', @R_EMAIL = '" & Me.txtToMail.Text.Trim & "'")
        '    End If
        'End If
        SampleCom.BindComboxLine(cboQueryStatus)
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim lsSQL As New StringBuilder
        Dim strMOQty As String = String.Empty, strPZResult As String = ""

        If Not CheckInput() Then
            Exit Sub
        End If
        Try
            'If Not String.IsNullOrEmpty(Me.txtStdTime.Text) Then
            '    lsSQL.Append("  UPDATE m_Sample_t Set StdTime = '" & Me.txtStdTime.Text & "' WHERE sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            '    lsSQL.Append(" IF EXISTS (SELECT TOP 1 1 FROM m_SamplePartIDStdTime WHERE PartNo ='" & Me.txtQueryPn.Text.Trim() & "')")
            '    lsSQL.Append("   UPDATE m_SamplePartIDStdTime SET StdTime = '" & Me.txtStdTime.Text & "' WHERE PARTNO ='" & Me.txtQueryPn.Text.Trim() & "'")
            '    lsSQL.Append(" Else  Insert into m_SamplePartIDStdTime(PartNO, StdTime, createuserid, CREATETIME) VALUES ")
            '    lsSQL.Append("  ('" & Me.txtQueryPn.Text.Trim() & "', '" & Me.txtStdTime.Text.Trim() & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            'End If

            'If Not String.IsNullOrEmpty(Me.txtMOID.Text) AndAlso m_blnMaintainMO Then
            '    If String.IsNullOrEmpty(Me.txtMOQty.Text) Then
            '        strMOQty = SampleCom.GetMOQty(Me.txtMOID.Text)
            '    Else
            '        strMOQty = Me.txtMOQty.Text.Trim
            '    End If
            '    lsSQL.Append(" Declare @MOID varchar(200) ")
            '    lsSQL.Append(" If not exists (SELECT TOP 1 1 FROM m_SampleMO_t WHERE sampleno ='" & Me.txtSampleNo.Text.Trim & "' and moid ='" & Me.txtMOID.Text.Trim & "') ")
            '    lsSQL.Append(" Begin ")
            '    lsSQL.Append("  UPDATE m_Sample_t SET MOID = iif(isnull(moid,'')='','',moid+',') + '" & Me.txtMOID.Text.Trim & "', ")
            '    lsSQL.Append("  Lineid =  iif(isnull(lineid,'')='','',lineid+',') +'" & Me.cboLineID.SelectedValue.ToString & "',")
            '    lsSQL.Append("  MOQty = iif(isnull(moqty,'')='','',moqty+',') +'" & Val(strMOQty) & "'")
            '    lsSQL.Append("  WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            '    lsSQL.Append("  Insert into m_SampleMO_t(SampleNO, moid,lineid, MOQty, intime, UserID )")
            '    lsSQL.Append("  VALUES('" & Me.txtSampleNo.Text.Trim & "', '" & Me.txtMOID.Text.Trim & "', '" & Me.cboLineID.SelectedValue.ToString & "', '" & Val(strMOQty) & "', getdate(), '" & VbCommClass.VbCommClass.UseId & "')")
            '    lsSQL.Append(" End")
            'End If
            If rbOK.Checked = True Then
                strPZResult = "1"
            Else
                strPZResult = "0"
            End If
            If Not String.IsNullOrEmpty(Me.txtOKQty.Text) Then
                lsSQL.Append("  UPDATE m_Sample_t Set OKQty = '" & Val(Me.txtOKQty.Text.Trim) & "',")
                lsSQL.Append("  PZResult='" & strPZResult & "'")
                lsSQL.Append("  WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            End If
            If Not String.IsNullOrEmpty(lsSQL.ToString) Then
                DbOperateUtils.ExecSQL(lsSQL.ToString)
            End If
            MessageUtils.ShowInformation("保存成功!")
            '刷新数据显示
            GetListData()
            opflag = 0
            ToolbtnState(0)
            ClearUIValue(opflag)
            dgvSample.Enabled = True
            Me.toolSave.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "toolSave_Click", "Sample")
            'Throw ex
        End Try
    End Sub

    Private Function CheckInput() As Boolean
        'If String.IsNullOrEmpty(Me.txtStdTime.Text) Then
        '    MessageUtils.ShowError("标准工时不能为空!")
        '    Me.txtStdTime.Focus()
        '    Return False
        'End If

        Return True
    End Function

    Private Sub dgvSampleD_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvSampleD.RowPrePaint
        If e.RowIndex = -1 OrElse Me.dgvSampleD.Rows.Count <= 0 Then Exit Sub
        Dim strTempStatus As String = ""
        Dim o_tempPlanDueDate As String
        Try
            For rowIndex As Integer = 0 To Me.dgvSampleD.Rows.Count - 1
                strTempStatus = DbOperateUtils.DBNullToStr(dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.Status).Value)

                If Not String.IsNullOrEmpty(strTempStatus) Then
                    Select Case strTempStatus.Substring(0, 1)
                        Case "0"
                            o_tempPlanDueDate = DbOperateUtils.DBNullToStr(Me.dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.PlanDueDate).Value)
                            If DbOperateUtils.DBNullToStr(Me.dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.PlanDueDate).Value) <> "" AndAlso DateTime.Compare(o_tempPlanDueDate, DateTime.Now.Date) < 0 Then
                                dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Red
                            Else
                                dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        Case "1"
                            dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case Else
                            'do nothing 
                    End Select
                End If
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "RowPrePaint", "Sample")
            Throw ex
        End Try
    End Sub

    Private Sub btnSelectRD_Click(sender As Object, e As EventArgs) Handles btnSelectRD.Click
        Dim frm As FrmUserList = New FrmUserList()
        ' frm.txtSelectedDept.Text = SampleCom.EnumSampleDept.研发.ToString
        Dim result As DialogResult = frm.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            txtRDUserName.Text = frm.checkedLine
        End If
    End Sub

#Region "品质总结文档处理"
    'PZ  Sum 选择
    Private Sub btnSelectPZSum_Click(sender As Object, e As EventArgs) Handles btnSelectPZSum.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        btnSelectPZSum.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPZSumFilePath.Text = OpenFileDialog1.FileName
            Me.PZSumFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSelectPZSum.Enabled = True
    End Sub

    Private Sub btnUploadPZSum_Click(sender As Object, e As EventArgs) Handles btnUploadPZSum.Click
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.PZSumFileName) Then

            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim PZSumFilePath As String = Me.txtPZSumFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.PZSumFileName)
            File.Copy(PZSumFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If
        Call UpdateSumFilePathToDB(SampleCom.enumSumType.PZ, ServerFile)
        MessageUtils.ShowInformation("上传品质总结成功！")
    End Sub
#End Region

    Private Sub UpdateSumFilePathToDB(ByVal iDocumentType As Integer, ByVal strPath As String)
        Dim lsSQL As New StringBuilder

        Dim o_strExecSQLResult As String = ""
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId

            arrayList.Add("SampleNo|" & _sampleNumber)
            arrayList.Add("DocumentType|" & iDocumentType)
            arrayList.Add("Path|" & strPath)
            arrayList.Add("userID|" & userID)
            o_strExecSQLResult = DbOperateUtils.ExecuteNonQureyByProc("m_SampleSumUpload_p", arrayList)
            If o_strExecSQLResult <> "" Then
                ' ShowMessage(File & "导入失败->" & o_strExecSQLResult)
            Else
                'Auto close
                Call UpdateSampleToClose()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "UpdateSumFilePathToDB", "Sample")
        End Try
    End Sub

    Private Sub UpdateSampleToClose()
        Dim lsSQL As New StringBuilder
        Dim o_strExecSQLResult As String = ""
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId

            arrayList.Add("SampleNo|" & _sampleNumber)
            o_strExecSQLResult = DbOperateUtils.ExecuteNonQureyByProc("m_SampleAutoClose_p", arrayList)
            If o_strExecSQLResult <> "" Then
                ' ShowMessage(File & "导入失败->" & o_strExecSQLResult)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "UpdateSampleToClose", "Sample")
        End Try
    End Sub

    Private Sub dgvSample_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSample.CellDoubleClick
        If e.RowIndex = -1 OrElse Me.dgvSample.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName
        o_strColumnName = dgvSample.CurrentCell.OwningColumn.Name

        Select Case o_strColumnName
            Case dgvSample.Columns(enumdgvSample.ProjectPath).Name, dgvSample.Columns(enumdgvSample.ZCPath).Name, dgvSample.Columns(enumdgvSample.PZPath).Name, dgvSample.Columns(enumdgvSample.ZJPath).Name
                If DbOperateUtils.DBNullToStr(Me.dgvSample.CurrentCell.Value) <> "" Then
                    System.Diagnostics.Process.Start(Me.dgvSample.CurrentCell.Value.ToString)
                End If
            Case Else
                'do nothing
        End Select
    End Sub

    Private Sub txtOKQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOKQty.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtOKQty.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtOKQty.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opflag = 0
        ToolbtnState(0)
        ClearUIValue(opflag)
        Me.txtSampleNo.Enabled = True
        Me.txtQueryDevNo.Enabled = True
        Me.txtQueryPn.Enabled = True
        ' Me.txtStdTime.Text = ""
        Me.txtQueryPn.Text = ""
        Me.txtRDUserName.Text = ""
    End Sub

    Private Sub ClearUIValue(ByVal flag As Integer)
        Select Case flag
            Case 0 'default
                Me.txtSampleNo.Text = ""
                Me.txtOKQty.Text = ""
                ' Me.txtNGQty.Text = ""
                Me.txtQueryDevNo.Text = ""
                Me.txtQueryPn.Text = ""
                ' Me.txtStdTime.Text = ""
                ' Me.txtMOQty.Text = ""
                'Me.cboLineID.Text = ""
                Me.rbOK.Checked = False
                Me.rbNG.Checked = False
            Case Else
        End Select
    End Sub


    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0  ''初始查詢狀態
                Me.toolEdit.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolSGDo.Enabled = True
                'GroupBox
                'Me.ChkUsey.Checked = True
                'Me.CboType.Enabled = True
            Case 1, 2
            Case 3
        End Select
    End Sub

    Private Sub btnSelectMadeDoc_Click(sender As Object, e As EventArgs) Handles btnSelectMadeDoc.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If
        btnSelectMadeDoc.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtMadeDocFilePath.Text = OpenFileDialog1.FileName
            Me.MadeDocFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSelectMadeDoc.Enabled = True
    End Sub

    Private Sub btnUploadMadeDoc_Click(sender As Object, e As EventArgs) Handles btnUploadMadeDoc.Click
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.MadeDocFileName) Then

            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim madeDocFilePath As String = Me.txtMadeDocFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.MadeDocFileName)
            File.Copy(madeDocFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If
        Call UpdateSumFilePathToDB(SampleCom.enumSumType.MadeDoc, ServerFile)
        MessageUtils.ShowInformation("上传生产制样记录表成功！")
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        ' SetButtonEnable(False)
        toolSave.Enabled = False
        Me.toolRefresh.Enabled = True
        txtSampleNo.Enabled = True
        Me.txtSampleNo.Text = ""
        txtQueryPn.Enabled = True
        Me.txtQueryPn.Text = ""
        Me.txtQueryDevNo.Enabled = True
        Me.txtQueryDevNo.Text = ""
        Me.txtRDUserName.Enabled = True
        Me.txtRDUserName.Text = ""
        Me.cboQueryStatus.Enabled = True
        Me.cboQueryStatus.Text = ""
        Me.txtMadeDocFilePath.Text = ""
        Me.txtPZSumFilePath.Text = ""
        'Me.txtZCSumFilePath.Text = ""
        'Me.txtProjectSumFilePath.Text = ""
        '需把生产制样记录表/品质总结/制程总结/项目总结，需清理
    End Sub

    Private Sub toolClose_Click(sender As Object, e As EventArgs) Handles toolClose.Click
        Dim lsSQL As String = ""
        If dgvSample.Rows.Count < 1 Then Exit Sub
        If dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString = "" Then Exit Sub
        ' If MessageBox.Show("你是否对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        lsSQL = " UPDATE m_Sample_t SET  Status='1'," & _
                " CloseUserID='" & SysMessageClass.UseId & "'" & _
                " WHERE SampleNO='" & dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString & "'"
        DbOperateUtils.ExecSQL(lsSQL)
        MessageUtils.ShowInformation("已成功结案...")
    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        Dim lsSQL As String = ""
        If dgvSample.Rows.Count < 1 Then Exit Sub
        If dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString = "" Then Exit Sub
        lsSQL = " UPDATE m_Sample_t SET  Status='" & SampleCom.enumSampleStatus.Make & "'," & _
                " CloseUserID='" & SysMessageClass.UseId & "'" & _
                " WHERE SampleNO='" & dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString & "'"
        DbOperateUtils.ExecSQL(lsSQL)
        MessageUtils.ShowInformation("已成功取消结案...")
    End Sub

    Private Sub ToolStdTime_Click(sender As Object, e As EventArgs) Handles ToolStdTime.Click
        Using frm As New FrmSampleStdTime
            frm.m_strSampleNO = Me.dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value
            frm.m_strPartNo = Me.dgvSample.CurrentRow.Cells(enumdgvSample.PartNo).Value
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ToolSGDo_Click(sender As Object, e As EventArgs) Handles ToolSGDo.Click
        Me.ToolSGDo.Enabled = False
        m_blnMaintainMO = True

        Me.toolSave.Enabled = True

        Using frm As New FrmSampleMO
            frm.txtSampleNo.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value
            ' frm.m_strPartNo = Me.dgvSample.CurrentRow.Cells(enumdgvSample.PartNo).Value
            frm.ShowDialog()
        End Using

        Me.ToolSGDo.Enabled = True
    End Sub

    Private Sub SideBar1_ItemClick(sender As Object, e As EventArgs) Handles SideBar1.ItemClick
        Dim _sampleNo As String = ""
        Try
            If TypeOf sender Is ButtonItem Then
                Dim SelectedItem As ButtonItem = CType(sender, ButtonItem)
                If SelectedItem.Tag.ToString() <> "" Then
                    '清除样式
                    For Each item As ButtonItem In SelectedItem.Parent.SubItems
                        item.ForeColor = Color.Black
                        item.FontBold = False
                    Next
                    '添加样式()
                    SelectedItem.ForeColor = Color.Blue
                    SelectedItem.FontBold = True

                    If CType(SelectedItem.Tag, ArrayList).Count < 1 Then
                        Exit Sub
                    End If
                    _sampleNo = CStr(CType(SelectedItem.Tag, ArrayList).Item(0))

                    Me.txtSampleNo.Text = _sampleNo

                    GetListData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "SideBar1_ItemClick", "Sample")
        End Try
    End Sub

    Private Sub ToolAddDutyName_Click(sender As Object, e As EventArgs) Handles ToolAddDutyName.Click
        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName
        Dim frm As FrmSampleDutyName = New FrmSampleDutyName

        frm.m_strSampleNO = DbOperateUtils.DBNullToStr(dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value)
        frm.m_strYWDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.业务.ToString)
        frm.m_strPZDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.品质.ToString)
        frm.m_strYPSDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.样品室.ToString)
        frm.m_strEquDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.设备.ToString)
        frm.m_strSGDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.生管.ToString)
        frm.m_strPIEDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.PIE.ToString)
        frm.m_strZEquDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.治具.ToString)
        frm.m_strRDDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.研发.ToString)
        Dim result As DialogResult = frm.ShowDialog()

        'If result = Windows.Forms.DialogResult.OK Then
        '    SearchRecord(" AND a.sampleno = '" & frm.m_strSampleNO & "'")
        'End If
    End Sub

    Private Sub btnSetFinish_Click(sender As Object, e As EventArgs) Handles btnSetFinish.Click

        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            Exit Sub
        End If

        Dim lsSQL As StringBuilder = New StringBuilder

        Select Case m_strCurrentUserDept
            Case EnumSampleDept.生管.ToString
                lsSQL.Append(" Update m_Sample_t Set SGFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.PIE.ToString
                lsSQL.Append(" Update m_Sample_t Set PIEFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.品质.ToString
                lsSQL.Append(" Update m_Sample_t Set PZFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.样品室.ToString
                lsSQL.Append(" Update m_Sample_t Set YPSFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
        End Select

        If Not String.IsNullOrEmpty(lsSQL.ToString) Then
            DbOperateUtils.ExecSQL(lsSQL.ToString)
            'Refersh data
            LoadSideBarByClick("", m_strCurrentUserDept, True)
        End If
    End Sub


    Private Sub dgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        If e.RowIndex = -1 OrElse Me.dgvDocument.Rows.Count <= 0 Then Exit Sub
        Try
            System.Diagnostics.Process.Start(Me.dgvDocument.CurrentCell.Value.ToString)
        Catch ex As Exception
        End Try
    End Sub

#Region "Not Use"

    '制程总结文件选择
    'Private Sub btnSelectZCSum_Click(sender As Object, e As EventArgs)
    '    If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
    '        MessageUtils.ShowError("请先填写样品单号")
    '        Exit Sub
    '    Else
    '        _sampleNumber = Me.txtSampleNo.Text.Trim
    '    End If
    '    btnSelectZCSum.Enabled = False
    '    'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
    '    Dim result As DialogResult = OpenFileDialog1.ShowDialog()
    '    OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
    '    If result = System.Windows.Forms.DialogResult.OK Then
    '        Cursor.Current = Cursors.WaitCursor
    '        txtZCSumFilePath.Text = OpenFileDialog1.FileName
    '        Me.ZCSumFileName = OpenFileDialog1.SafeFileName
    '        Cursor.Current = Cursors.Default
    '    End If
    '    btnSelectZCSum.Enabled = True
    'End Sub

    'Private Sub btnUploadZCSum_Click(sender As Object, e As EventArgs) Handles btnUploadZCSum.Click
    '    Dim ServerFile As String = ""
    '    If Not String.IsNullOrEmpty(Me.ZCSumFileName) Then

    '        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
    '            MessageUtils.ShowError("请先填写样品单号")
    '            Exit Sub
    '        Else
    '            _sampleNumber = Me.txtSampleNo.Text.Trim
    '        End If

    '        Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
    '        Dim ZCSumFilePath As String = Me.txtZCSumFilePath.Text.Trim
    '        If System.IO.Directory.Exists(destFilePath) = False Then
    '            Directory.CreateDirectory(destFilePath)
    '        End If
    '        ServerFile = Path.Combine(destFilePath, Me.ZCSumFileName)
    '        File.Copy(ZCSumFilePath, ServerFile, True)
    '    Else '未选择上传
    '        'ServerFile = SopFilePath
    '        Exit Sub
    '    End If
    '    Call UpdateSumFilePathToDB(SampleCom.enumSumType.ZC, ServerFile)
    '    MessageUtils.ShowInformation("上传制程总结成功！")
    'End Sub
    'Private Sub btnUploadProjectSum_Click(sender As Object, e As EventArgs) Handles btnUploadProjectSum.Click
    '    Dim ServerFile As String = ""
    '    If Not String.IsNullOrEmpty(Me.ZCSumFileName) Then

    '        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
    '            MessageUtils.ShowError("请先填写样品单号")
    '            Exit Sub
    '        Else
    '            _sampleNumber = Me.txtSampleNo.Text.Trim
    '        End If

    '        Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
    '        Dim ProjectSumFilePath As String = Me.txtProjectSumFilePath.Text.Trim
    '        If System.IO.Directory.Exists(destFilePath) = False Then
    '            Directory.CreateDirectory(destFilePath)
    '        End If
    '        ServerFile = Path.Combine(destFilePath, Me.ProjectSumFileName)
    '        File.Copy(ProjectSumFilePath, ServerFile, True)
    '    Else '未选择上传
    '        'ServerFile = SopFilePath
    '        Exit Sub
    '    End If
    '    Call UpdateSumFilePathToDB(SampleCom.enumSumType.Project, ServerFile)
    '    MessageUtils.ShowInformation("上传项目总结成功！")
    'End Sub

    'Private Sub txtStdTime_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    e.Handled = True
    '    '输入0－9和回连键时有效  
    '    If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
    '        e.Handled = False
    '    End If
    '    '输入小数点情况  
    '    If e.KeyChar = "." Then
    '        '小数点不能在第一位  
    '        If txtStdTime.Text.Length <= 0 Then
    '            e.Handled = True
    '        Else
    '            '小数点不在第一位  
    '            Dim f As Double
    '            If Double.TryParse(txtStdTime.Text + e.KeyChar, f) Then
    '                e.Handled = False
    '            End If
    '        End If
    '    End If
    'End Sub


#End Region

    Private Sub btnSelectZJDoc_Click(sender As Object, e As EventArgs) Handles btnSelectZJDoc.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        btnSelectZJDoc.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtZJFilePath.Text = OpenFileDialog1.FileName
            Me.ZJFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSelectZJDoc.Enabled = True
    End Sub

    Private Sub btnUploadZJDoc_Click(sender As Object, e As EventArgs) Handles btnUploadZJDoc.Click
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.ZJFileName) Then

            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim zjDocFilePath As String = Me.txtZJFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.ZJFileName)
            File.Copy(zjDocFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If
        Call UpdateSumFilePathToDB(SampleCom.enumSumType.ZJ, ServerFile)
        MessageUtils.ShowInformation("上传治具成功！")
    End Sub

    Private Sub dgvSample_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvSample.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 1 Then
                Dim p As Point = Me.dgvSample.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                p.Offset(CInt("0"), CInt("0"))
                Me.m_ChkboxAll.Location = p

                Me.m_ChkboxAll.Size = dgvSample.Columns(1).HeaderCell.Size
                Me.m_ChkboxAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))

                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "dgvSample_CellPainting", "Sample")
        End Try
    End Sub

    Private Sub ToolDownMO_Click(sender As Object, e As EventArgs) Handles ToolDownMO.Click
        Dim strSQL As New StringBuilder
        Dim o_dt As New DataTable
        Try
            For Each dr As DataGridViewRow In Me.dgvSample.Rows
                If dr.Cells(enumdgvSample.checkbox).EditedFormattedValue.ToString.ToUpper = True Then
                    o_dt = GetTiptopMOInfo(dr.Cells(enumdgvSample.PartNo).Value)
                    If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                        For Each drMO As DataRow In o_dt.Rows
                            strSQL.Append(" IF NOT EXISTS (SELECT TOP 1 1 FROM m_SampleMO_t WHERE Sampleno ='" & dr.Cells(enumdgvSample.SampleNo).Value & "' AND moid='" & drMO.Item("MOID") & "')")
                            strSQL.Append("  Begin ")
                            strSQL.Append("   Insert into m_SampleMO_t(SampleNO, MOID, LineID, Intime, UserID, MOQty, MOFinishDate, Usey,Status)")
                            strSQL.Append(" VALUES('" & dr.Cells(enumdgvSample.SampleNo).Value & "','" & drMO.Item("MOID") & "',")
                            strSQL.Append(" '" & drMO.Item("LINEID") & "', '" & drMO.Item("TTModifyDate") & "' , '" & VbCommClass.VbCommClass.UseId & "',")
                            strSQL.Append("  '" & drMO.Item("MOQTY") & "',null, '1', '" & drMO.Item("Status") & "' ) ")
                            strSQL.Append("  End")
                            strSQL.Append(" Else ")
                            strSQL.Append("   Update m_SampleMO_t SET Status='" & drMO.Item("Status") & "' WHERE Sampleno ='" & dr.Cells(enumdgvSample.SampleNo).Value & "' AND moid='" & drMO.Item("MOID") & "' ")
                        Next
                    End If
                End If
            Next

            If Not String.IsNullOrEmpty(strSQL.ToString) Then
                DbOperateUtils.ExecSQL(strSQL.ToString)

                MessageUtils.ShowInformation("批量维护工单成功！")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Function GetTiptopMOInfo(ByVal partID As String) As DataTable
        Dim lsSQL As String = String.Empty
        GetTiptopMOInfo = Nothing

        lsSQL = " SELECT  SFB82 AS LINEID ,SFB08 AS MOQTY, SFB05 as PartID , SFB01 as MOID, " & _
                " SFBDATE as TTModifyDate, SFB04 as Status " & _
                " FROM  " & VbCommClass.VbCommClass.Factory & ".SFB_FILE " & _
                " WHERE 1=1 AND SFB05='" & partID & "' " & _
                " ORDER BY SFB071 DESC"
        Using o_dt As DataTable = SampleComDB.GetDataTableOracle(lsSQL)
            GetTiptopMOInfo = o_dt
        End Using
        Return GetTiptopMOInfo
    End Function

    Private Sub tsmi_LookMO_Click(sender As Object, e As EventArgs) Handles tsmi_LookMO.Click

        Me.ToolSGDo.Enabled = False
        m_blnMaintainMO = True
        Me.toolSave.Enabled = True
        Using frm As New FrmSampleMO
            frm.txtSampleNo.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value
            frm.ShowDialog()
        End Using

        Me.ToolSGDo.Enabled = True
    End Sub

    Private Sub tsmi_LookStep_Click(sender As Object, e As EventArgs) Handles tsmi_LookStep.Click




    End Sub

    Private Sub ToolLookDoc_Click(sender As Object, e As EventArgs) Handles ToolLookDoc.Click
        Using frm As New FrmSampleDoc
            ' frm.txtSampleNo.Text = Me.dgvSample.CurrentRow.Cells(enumdgvSample.SampleNo).Value
            frm.ShowDialog()
        End Using
    End Sub
End Class