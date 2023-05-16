Imports System.Xml
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports System.Text

Public Class FrmConfigSet

#Region "变量定义"
    Dim TimeStyleSet As String
    Private _stationid As String
    '/ <summary>
    '/ 工站编号
    '/ </summary>
    Public Property StationID() As String
        Get
            Return _stationid
        End Get
        Set(ByVal Value As String)
            _stationid = Value
        End Set
    End Property

    Private MoLineID As String = ""

    Dim _Lot_No As String = ""
    '/ <summary>
    '/ 批次号
    '/ </summary>
    Public Property Lot_No() As String
        Get
            Return _Lot_No
        End Get
        Set(ByVal Value As String)
            _Lot_No = Value
        End Set
    End Property
    Dim _Product_no As String = ""
    '/ <summary>
    '/ 成品料号
    '/ </summary>
    Public Property Product_no() As String
        Get
            Return _Product_no
        End Get
        Set(ByVal Value As String)
            _Product_no = Value
        End Set
    End Property
    Dim _CustID As String = ""
    '/ <summary>
    '/ 客户代码
    '/ </summary>
    Public Property CustID() As String
        Get
            Return _CustID
        End Get
        Set(ByVal Value As String)
            _CustID = Value
        End Set
    End Property
    Dim _CusCode As String = ""
    '/ <summary>
    '/ 客户代码
    '/ </summary>
    Public Property CusCode() As String
        Get
            Return _CusCode
        End Get
        Set(ByVal Value As String)
            _CusCode = Value
        End Set
    End Property
    Dim _ProCode As String = ""
    '/ <summary>
    '/ 简码
    '/ </summary>
    Public Property ProCode() As String
        Get
            Return _ProCode
        End Get
        Set(ByVal Value As String)
            _ProCode = Value
        End Set
    End Property
    Dim _CartonQtyI As String = ""
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Property CartonQtyI() As String
        Get
            Return _CartonQtyI
        End Get
        Set(ByVal Value As String)
            _CartonQtyI = Value
        End Set
    End Property
    Dim _LpartID As String = ""
    '/ <summary>
    '/ 立讯料号
    '/ </summary>
    Public Property LpartID() As String
        Get
            Return _LpartID
        End Get
        Set(ByVal Value As String)
            _LpartID = Value
        End Set
    End Property
    Dim IsInitLoadForm As Boolean = True
    Shared m_StationType As String
    Public Shared Property vStationType() As String

        Get
            Return m_StationType
        End Get
        Set(ByVal Value As String)
            m_StationType = Value
        End Set

    End Property
#End Region

#Region "初期化"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Optional ByVal No As String = "")
        Me.StationID = No
        InitializeComponent()
    End Sub
    '初期化
    Private Sub FrmConfigSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.btnEdit.Visible = False
        'LoadLineData()
        ScanOption.IsExitFlag = True
        Dim stationid As String = GetXMLNodeData("stationid")
        Dim lineid As String = GetXMLNodeData("lineid")
        Dim moid As String = GetXMLNodeData("moid")
        If (stationid <> "") Then
            Me.CobSitId.Text = stationid
        End If
        If (lineid <> "") Then
            Me.CobLine.Text = lineid
        End If
        If (moid <> "") Then
            'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim StrSql As String = String.Format("SELECT Moid,Lineid FROM dbo.m_Mainmo_t WHERE Moid='{0}' ", moid)
            Dim dtMoData As DataTable = DbOperateUtils.GetDataTable(StrSql)
            If (Not dtMoData Is Nothing) AndAlso dtMoData.Rows.Count > 0 Then
                Me.mtxtMOid.Text = moid
                MoLineID = dtMoData.Rows(0)("Lineid").ToString.Trim
            End If
        End If
        Me.ActiveControl = mtxtMOid
        mtxtMOid.Focus()

        'Dim IsScanCarton As String = GetXMLNodeData("IsScanCarton")

        Dim selType As String = GetXMLNodeData("selType")

        layerType.SelectedIndex = 0
        '  SetXMLNodeData("selType", ComboBox1.SelectedIndex)

        Dim IsScanCarton As String = "Y"
        Dim CartonStyle As String = GetXMLNodeData("CartonStyle")
        Dim CartonQty As String = GetXMLNodeData("CartonQty")
        Dim IsScanQrCode As String = GetXMLNodeData("IsScanQrCode")
        Dim QrCodeStyle As String = GetXMLNodeData("QrCodeStyle")

        Dim IsScanSecond As String = GetXMLNodeData("IsScanSecond")
        Dim SecondStyle As String = GetXMLNodeData("SecondStyle")
        Dim SecondQty As String = GetXMLNodeData("SecondQty")
        Dim IsScanThird As String = GetXMLNodeData("IsScanThird")
        Dim ThirdStyle As String = GetXMLNodeData("ThirdStyle")
        Dim ThirdQty As String = GetXMLNodeData("ThirdQty")
        'Dim IsScanPpid As String = GetXMLNodeData("IsScanPpid")
        Dim IsScanPpid As String = "Y"
        Dim PpidStyle As String = GetXMLNodeData("PpidStyle")
        Dim PpidQty As String = GetXMLNodeData("PpidQty")
        If String.IsNullOrEmpty(PpidQty) Then
            PpidQty = "1"
        End If
        chkScanCarton.Checked = IIf(IsScanCarton = "Y", True, False)
        If chkScanCarton.Checked Then
            txtCartonStyle.Text = CartonStyle
            txtCartonQty.Text = CartonQty
        End If
        'chkScanQrCode.Checked = IIf(IsScanQrCode = "Y", True, False)
        'If chkScanQrCode.Checked Then
        '    txtCartonCheckCode.Text = QrCodeStyle
        'End If

        chkScanSecond.Checked = IIf(IsScanSecond = "Y", True, False)
        If chkScanSecond.Checked Then
            txtSecondStyle.Text = SecondStyle
            txtSecondQty.Text = SecondQty
        End If
        chkScanThird.Checked = IIf(IsScanThird = "Y", True, False)
        If chkScanThird.Checked Then
            txtThirdStyle.Text = ThirdStyle
            txtThirdQty.Text = ThirdQty
        End If

        chkScanPpid.Checked = IIf(IsScanPpid = "Y", True, False)
        If chkScanPpid.Checked Then
            txtPpidStyle.Text = PpidStyle
            txtPpidQty.Text = PpidQty
        End If
        If moid <> "" Then
            mtxtMOid_TextChanged(Nothing, Nothing)
        End If
    End Sub

    '加载线别
    Private Sub LoadLineData()
        Dim StrSql As String = " SELECT lineid FROM dbo.deptline_t WHERE usey='Y' "
        Me.CobLine.DataSource = DbOperateUtils.GetDataTable(StrSql)
        Me.CobLine.DisplayMember = "lineid"
        Me.CobLine.ValueMember = "lineid"
    End Sub

#End Region

#Region "事件"
    '取消
    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        ScanOption.IsExitFlag = True
        Me.Close()
    End Sub

    '确认
    Private Sub BnConFrm_Click(sender As Object, e As EventArgs) Handles BnConFrm.Click
        If CobSitId.Text.Trim = "" Then
            MessageBox.Show("站点编号不能为空！")
            Exit Sub
        End If
        If Me.mtxtMOid.Text.Trim = "" Then
            MessageBox.Show("工单不能为空！")
            Exit Sub
        End If
        If Me.CobLine.Text = "" Then
            MessageBox.Show("线别不能为空！")
            Exit Sub
        End If
        If Me.DtpSet.Text = "" Then
            MessageBox.Show("日期不能为空！")
            Exit Sub
        End If
        'If Me.CbbLine.Text.Trim <> MoLineID Then
        '    MessageBox.Show("所选线别与工单线别不匹配！")
        '    Exit Sub
        'End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(
                " select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " & _
                " where b.tparent in('z09_','z0s_','z0t_','z0Y_') and userid='" & SysMessageClass.UseId & "' and ButtonID='" & CobLine.Text & "'")
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...")
            Exit Sub
        End If

        If CobSitId.Text.Trim <> "" And Me.mtxtMOid.Text.Trim <> "" And Me.CobLine.Text <> "" Then
            If chkScanCarton.Checked Then
                If txtCartonStyle.Text = "" Then
                    MessageBox.Show("外箱条码样式不能为空")
                    txtCartonStyle.Focus()
                    Exit Sub
                End If
                If txtCartonQty.Text = "" Then
                    MessageBox.Show("外箱装箱数量不能为空")
                    txtCartonQty.Focus()
                    Exit Sub
                End If
            End If

            If chkScanThird.Checked Then
                If txtThirdStyle.Text = "" Then
                    MessageBox.Show("三层外箱条码样式不能为空")
                    txtThirdStyle.Focus()
                    Exit Sub
                End If
                If txtThirdQty.Text = "" Then
                    MessageBox.Show("三层外箱装箱数量不能为空")
                    txtThirdQty.Focus()
                    Exit Sub
                Else
                    If CInt(txtCartonQty.Text) Mod CInt(txtThirdQty.Text) <> 0 Then
                        MessageBox.Show("三层外箱数与最外层箱数量不对应!")
                        txtThirdQty.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If chkScanSecond.Checked Then
                If txtSecondStyle.Text = "" Then
                    MessageBox.Show("二层外箱条码样式不能为空")
                    txtSecondStyle.Focus()
                    Exit Sub
                End If
                If txtSecondQty.Text = "" Then
                    MessageBox.Show("二层外箱装箱数量不能为空")
                    txtSecondQty.Focus()
                        Exit Sub
                    Else
                        If CInt(txtCartonQty.Text) Mod CInt(txtSecondQty.Text) <> 0 Then
                            MessageBox.Show("二层外箱数与最外层箱数量不对应!")
                            txtThirdQty.Focus()
                            Exit Sub
                        End If
                    End If
            End If
            If chkScanPpid.Checked = False Then
                MessageBox.Show("产品条码必须扫描")
                chkScanPpid.Focus()
                Exit Sub
            Else
                If txtPpidStyle.Text = "" Then
                    MessageBox.Show("产品条码样式不能为空")
                    txtPpidStyle.Focus()
                    Exit Sub
                End If
                If txtPpidQty.Text = "" Then
                    MessageBox.Show("产品条码扫描数量不能为空")
                    txtPpidQty.Focus()
                    Exit Sub
                End If
            End If


            ScanOption.SelStationID = CobSitId.Text.Trim
            ScanOption.SelLineID = CobLine.Text.Trim
            ScanOption.SelMOID = mtxtMOid.Text.Trim
            ScanOption.Partid = Me.TxtAvcPart.Text.Trim
            ScanOption.IsScanCarton = chkScanCarton.Checked
            ScanOption.SelCartonStyle = txtCartonStyle.Text.Trim


            'ScanOption.IsScanCartonQrCode = chkScanQrCode.Checked
            ScanOption.SelQrCodeStyle = txtCartonCheckCode.Text.Trim

            ScanOption.IsScanSecondCode = chkScanSecond.Checked
            ScanOption.SelSecondStyle = txtSecondStyle.Text.Trim

            ScanOption.IsScanThirdCode = chkScanThird.Checked
            ScanOption.SelThirdStyle = txtThirdStyle.Text.Trim


            ScanOption.SelPpidStyle = txtPpidStyle.Text.Trim


            Try
                ScanOption.LayerType = layerType.SelectedIndex
                ScanOption.CartonQty = txtCartonQty.Text.Trim
                ScanOption.SelSecondQty = IIf(String.IsNullOrEmpty(txtSecondQty.Text.Trim), 0, txtSecondQty.Text.Trim)
                ScanOption.SelThirdQty = IIf(String.IsNullOrEmpty(txtThirdQty.Text.Trim), 0, txtThirdQty.Text.Trim)
                ScanOption.SelPpidQty = IIf(String.IsNullOrEmpty(txtPpidQty.Text.Trim), 0, txtPpidQty.Text.Trim)

            Catch ex As Exception
                MessageBox.Show("数量格式有误,请重新输入！")
                Exit Sub
            End Try

            SetXMLNodeData("stationid", CobSitId.Text)
            SetXMLNodeData("lineid", CobLine.Text)
            SetXMLNodeData("moid", mtxtMOid.Text)
            SetXMLNodeData("IsScanCarton", IIf(chkScanCarton.Checked, "Y", "N"))
            SetXMLNodeData("CartonStyle", txtCartonStyle.Text)
            SetXMLNodeData("CartonQty", txtCartonQty.Text)
            ' SetXMLNodeData("IsScanQrCode", IIf(chkScanQrCode.Checked, "Y", "N"))
            SetXMLNodeData("QrCodeStyle", txtCartonCheckCode.Text)
            SetXMLNodeData("IsScanSecond", IIf(chkScanSecond.Checked, "Y", "N"))
            SetXMLNodeData("SecondStyle", txtSecondStyle.Text)
            SetXMLNodeData("SecondQty", txtSecondQty.Text)
            SetXMLNodeData("IsScanThird", IIf(chkScanThird.Checked, "Y", "N"))
            SetXMLNodeData("ThirdStyle", txtThirdStyle.Text)
            SetXMLNodeData("ThirdQty", txtThirdQty.Text)
            SetXMLNodeData("IsScanPpid", IIf(chkScanPpid.Checked, "Y", "N"))
            SetXMLNodeData("PpidStyle", txtPpidStyle.Text)
            SetXMLNodeData("PpidQty", txtPpidQty.Text)
            SetXMLNodeData("selType", layerType.SelectedIndex)

            ScanOption.IsExitFlag = False

            'ModfiyLogInName()

            Me.Close()
        End If
    End Sub

    '编辑
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If scanset.Enabled Then
            scanset.Enabled = False
            btnEdit.Text = "扫描设置编辑"
        Else
            Dim FrmOpenLock As New FrmSetLock

            FrmOpenLock.ShowDialog()
            If ScanOption.CheckStr = True Then
                scanset.Enabled = True

                btnEdit.Text = "取消编辑"
            End If
        End If
    End Sub
    '工单快速选择
    Private Sub txtMoid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtxtMOid.KeyPress
        If e.KeyChar = Chr(13) Then
            If mtxtMOid.Text.Trim = "" Then
                Exit Sub
            End If
            BnConFrm_Click(Nothing, Nothing)
        End If
    End Sub
    '工单选择
    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, "")
        If frmMOQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mtxtMOid_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged

        If Me.IsInitLoadForm = True Then
            Me.IsInitLoadForm = False
            Exit Sub
        End If
        Dim PubDataReader As DataTable
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        Dim strLine As String = ""

        CobLine.Text = ""
        CobSitId.Text = ""
        txtCartonStyle.Text = ""
        txtThirdStyle.Text = ""
        txtSecondStyle.Text = ""
        txtPpidStyle.Text = ""
        txtCartonQty.Text = ""
        txtThirdQty.Text = ""
        txtSecondQty.Text = ""
        txtCartonCheckCode.Text = ""
        txtPPIDCheckCode.Text = ""
        chkScanCarton.Checked = False
        chkScanThird.Checked = False
        chkScanSecond.Checked = False

        CobSitId.Items.Clear()
        If (Not String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            Try

                If VbCommClass.VbCommClass.Factory = "BZLANTO" Then 'hzf 2016-11-16 14:43:58 BZ扫描设置读取全部订单不区分客户代码
                    SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,d.mscusttype,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink,a.Cusid  from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid in('S','C','N') and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and e.usey='Y'"
                Else
                    SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,d.mscusttype,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink,a.Cusid   from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid left join  m_Customer_t g on g.CusID=a.Cusid  where e.packid in('S','C','N') and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "'  and e.usey='Y'"
                End If
                PubDataReader = DbOperateUtils.GetDataTable(SqlStr)

                Dim strCusid As String = ""
                Dim strms As String = ""
                If PubDataReader.Rows.Count > 0 Then
                    DeptStr = PubDataReader.Rows(0)("deptid").ToString
                    factoryidstr = PubDataReader.Rows(0)("Factory").ToString
                    Me.TxtAvcPart.Text = PubDataReader.Rows(0)("partid").ToString
                    CobLine.Text = PubDataReader.Rows(0)("lineid").ToString
                    strLine = PubDataReader.Rows(0)("lineid").ToString
                    ScanOption.Deptid = DeptStr
                    ScanOption.CustID = PubDataReader.Rows(0)("Cusid").ToString
                End If

                SqlStr = " select lineid from Deptline_t where deptid='" & DeptStr & "'  and usey='Y' order by lineid"

                Dim dt2 As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                Me.CobLine.Items.Clear()
                Me.CobSitId.Items.Clear()
                For cnt As Integer = 0 To dt2.Rows.Count - 1
                    CobLine.Items.Add(dt2.Rows(cnt)(0).ToString)
                Next

                SqlStr =
                    " select distinct b.stationid,b.stationname,a.staorderid,a.asny from m_RPartStationD_t a join" & _
                    " m_Rstation_t b on a.stationid=b.stationid where ppartid='" & TxtAvcPart.Text & "' and tpartid='" & TxtAvcPart.Text &
                    " ' and state='1' and isnull(ScanY,'Y')='Y'  order by staorderid"
                Dim dt3 As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                For cnt As Integer = 0 To dt3.Rows.Count - 1
                    If UCase(m_StationType) = "A" And InStr(dt3.Rows(cnt)("stationid").ToString, "P") > 0 Then
                        Continue For
                    End If
                    Me.CobSitId.Items.Add(dt3.Rows(cnt)("stationid").ToString & " - " & dt3.Rows(cnt)("stationname").ToString)
                Next

                If String.IsNullOrEmpty(strLine) Then
                    CobLine.SelectedIndex = -1
                Else
                    CobLine.Text = strLine
                End If

                If CobSitId.Items.Count = 1 Then
                    Me.CobSitId.SelectedIndex = 0
                Else
                    CobSitId.SelectedIndex = -1
                End If

                CobSitId.Enabled = True
                '获取样式
                getPartStyle()
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMoid_textChanged", "sys")
                MessageBox.Show("工单信息加载异常")
                Exit Sub
            End Try
        End If
    End Sub
    '扫描第三层外箱
    Private Sub chkScanThird_CheckedChanged(sender As Object, e As EventArgs) Handles chkScanThird.CheckedChanged
        If chkScanThird.Checked Then
            'chkScanSecond.Checked = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles layerType.SelectedIndexChanged
        ' Dim cuur As Integer = layerType.SelectedIndex
        'SetPale(cuur)
    End Sub
#End Region

#Region "方法"

    '检查相同线体相同料号对应数据，有没有其他没有扫描完成的工单数据
    Private Function CheckIsSamePartId()
        Dim strSQL As String = " SELECT  TopCartonid,MOID FROM M_CARTON_T WHERE Teamid = '{0}'AND CARTONSTATUS = 'N' " &
                               " AND MOID IN (SELECT Work_Ord_No FROM m_WorkOrds_t WHERE  product_no = '{1}') " &
                               " AND MOID != '{2}'"

        strSQL = String.Format(strSQL, CobLine.Text, _Product_no, Me.mtxtMOid.Text.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            MessageUtils.ShowError(String.Format("线体【{0}】，料号【{1}】对应工单【{2}】未完成，请确认！", CobLine.Text, _Product_no, dt.Rows(0)(1).ToString))
            Return False
        End If
        Return True
    End Function

    Private Sub SetXMLNodeData(ByVal XmlNodeName As String, ByVal XmlNodeValue As String)
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        If File.Exists(FilePath) Then
            Dim IsExistsNode As Boolean = False
            lXmlDocument.Load(FilePath)
            Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
            Dim xn As XmlNode
            For Each xn In lXmlNodeList
                If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                    xn.InnerText = XmlNodeValue
                    IsExistsNode = True
                    Continue For
                End If
            Next
            If Not IsExistsNode Then
                Dim lChildXmlElement As XmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlDocument.SelectSingleNode("Info").AppendChild(lChildXmlElement)
            End If
            lXmlDocument.Save(FilePath)
        Else
            Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
            Dim lChildXmlElement As XmlElement = Nothing
            lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
            lChildXmlElement.InnerText = XmlNodeValue
            lXmlNode.AppendChild(lChildXmlElement)
            lXmlDocument.AppendChild(lXmlNode)
            lXmlDocument.Save(FilePath)
        End If
    End Sub

    Private Function GetXMLNodeData(ByVal XmlNodeName As String) As String
        Dim XmlNodeValue As String = ""
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        Try
            If File.Exists(FilePath) Then
                lXmlDocument.Load(FilePath)
                Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
                Dim xn As XmlNode
                For Each xn In lXmlNodeList
                    If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                        XmlNodeValue = xn.InnerText
                    End If
                Next
            Else
                Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
                Dim lChildXmlElement As XmlElement = Nothing
                lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlNode.AppendChild(lChildXmlElement)
                lXmlDocument.AppendChild(lXmlNode)
                lXmlDocument.Save(FilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return XmlNodeValue
    End Function

    Private Sub SetPale(ByVal Sel As Integer)
        Select Case Sel
            Case 0
                chkScanSecond.Checked = False
                chkScanThird.Checked = False
                SplitContainer2.Panel1.Enabled = False
                SplitContainer3.Panel1.Enabled = False
            Case 1
                chkScanSecond.Checked = True
                chkScanThird.Checked = False
                SplitContainer2.Panel1.Enabled = True
                SplitContainer3.Panel1.Enabled = False
            Case 2
                chkScanSecond.Checked = True
                ' chkScanThird.Checked = True
                SplitContainer2.Panel1.Enabled = True
                SplitContainer3.Panel1.Enabled = True
            Case Else
                chkScanSecond.Checked = True
                chkScanThird.Checked = True
                SplitContainer2.Panel1.Enabled = True
                SplitContainer3.Panel1.Enabled = True
        End Select
    End Sub

    Private Function GetProNo(strProNo As String)
        Dim retvals As String = ""
        Dim strProNoList As String() = strProNo.Split("-")
        If strProNoList.Length > 2 Then
            retvals = strProNo.Substring(0, strProNo.Length - strProNoList(strProNoList.Length - 1).Length - strProNoList(strProNoList.Length - 2).Length - 2)
        Else
            retvals = strProNoList(0)
        End If
        Return retvals
    End Function

    Private Sub getPartStyle()
        Dim Sqlstring As New StringBuilder
        Dim Dt1 As DataTable
        Dim Dr As SqlDataReader
        Dim partTable As New NoSortHashtable.NoSortHashtable ''Hashtable
        Dim Conn As New SysDataBaseClass
        Dim SqlStr As String = ""
        '包装层级
        Sqlstring.Append("select Packid ,partid,e.coderuleid,PackingLevel,Qty  from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid  where  e.partid='" & Me.TxtAvcPart.Text & "'  and e.usey='Y' and PackingLevel<5 order by PackingLevel DESC")
        Dt1 = Conn.GetDataTable(Sqlstring.ToString)
        Dim totallevel As String = Dt1.Rows.Count - 1
        Me.layerType.SelectedIndex = totallevel
        ScanOption.TotalPackLevel = totallevel
        TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")

        Try
            For Each dr1 As DataRow In Dt1.Rows
                ''*************************************************
                'PACKID=N 无流水
                ''  SqlStr = "declare @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute [m_StyleShow_PartArrayStat_p]'" & str.Split("|")(1).ToString & "','" & Me.CboMoid.Text & "','" & Me.TxtAvcPart.Text & "','" & partTable(str) & "','" & WorkStantOption.vStandId & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"
                SqlStr = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                         " EXECUTE m_StyleMultiShow_AssembleSta '" & dr1("partid").ToString & "','" & dr1("coderuleid").ToString & "','" & dr1("PackingLevel").ToString & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output,'" & Me.mtxtMOid.Text.Trim & "' " & _
                         " SELECT @SnStyle1 st1,@SnStyle2 st2,@Gflen"
                Dr = Conn.GetDataReader(SqlStr)

                If Dr.HasRows Then
                    While Dr.Read()
                        '大箱
                        If dr1("PackingLevel").ToString = totallevel Then
                            txtCartonStyle.Text = DeleteUnVisibleChar(Dr("st1").ToString)
                            txtCartonQty.Text = dr1("Qty")
                            chkScanCarton.Checked = True
                            ScanOption.IsSameCartonStyle = IIf(dr1("Packid").ToString = "N", "Y", "N")
                            ScanOption.CartonCodeRuleID = dr1("coderuleid").ToString
                        End If
                        '产品
                        If dr1("PackingLevel").ToString = "0" Then
                            txtPpidStyle.Text = DeleteUnVisibleChar(Dr("st1").ToString)
                            txtPpidQty.Text = "1"
                            Exit For
                        End If
                        If totallevel = 3 Then '四层包装
                            If dr1("PackingLevel").ToString = totallevel - 1 Then
                                txtThirdStyle.Text = DeleteUnVisibleChar(Dr.GetString(0))
                                txtThirdQty.Text = dr1("Qty")
                                ScanOption.IsSameThirdStyle = IIf(dr1("Packid").ToString = "N", "Y", "N")
                                chkScanThird.Checked = True
                            End If
                            If dr1("PackingLevel").ToString = totallevel - 2 Then
                                txtSecondStyle.Text = DeleteUnVisibleChar(Dr.GetString(0).ToString)
                                txtSecondQty.Text = dr1("Qty")
                                ScanOption.IsSameSecondStyle = IIf(dr1("Packid").ToString = "N", "Y", "N")
                                chkScanSecond.Checked = True
                            End If
                        ElseIf totallevel = 2 Then '三层包装
                            If dr1("PackingLevel").ToString = 1 Then
                                txtSecondStyle.Text = DeleteUnVisibleChar(Dr.GetString(0).ToString)
                                txtSecondQty.Text = dr1("Qty")
                                ScanOption.IsSameSecondStyle = IIf(dr1("Packid").ToString = "N", "Y", "N")
                                chkScanSecond.Checked = True
                            End If
                        End If
                    End While
                End If
                Dr.Close()
            Next
            Dr.Close()

            SqlStr = "declare @REVID int DECLARE @Routeid int select @Routeid=Routeid from m_mainmo_t where moid='" & mtxtMOid.Text.Trim & "' " & _
                 " if(isnull(@Routeid,'')<>'') " & _
                 " begin" & _
                 "   set @REVID=@Routeid;" & _
                 " SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                 " isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                 " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                 " isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                 " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                 " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                 " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN,UpLimitWeight,LowLimitWeight, " & _
                 " isnull(IsPpidLineWeight,'N') as IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight ," & _
                 " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf ,isnull(BigCartonRepeatStyle,'') BigCartonRepeatStyle,isnull(BigCartonRepeatPara,'') BigCartonRepeatPara FROM m_RPartStationD_t WHERE " & _
                 " TPartid='" & Me.TxtAvcPart.Text & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y' and Revid=@REVID;" & _
                 " end" & _
                 " else" & _
                 " begin" & _
                 " SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                 " isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                 " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                 " isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                 " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                 " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                 " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN,UpLimitWeight,LowLimitWeight, " & _
                 " isnull(IsPpidLineWeight,'N') as IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight ," & _
                 " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf,isnull(IsNotCaseSensitive,'N') IsNotCaseSensitive,isnull(BigCartonRepeatStyle,'') BigCartonRepeatStyle,isnull(BigCartonRepeatPara,'') BigCartonRepeatPara " & _
                 " FROM m_RPartStationD_t WHERE " & _
                 " TPartid='" & Me.TxtAvcPart.Text & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y' and STATE='1'; " & _
                 " end"
            Dr = Conn.GetDataReader(SqlStr)
            ScanOption.vRepeatStyle = ""
            ScanOption.vRepeatPara = ""
            ScanOption.vCartonRepeatStyle = ""
            ScanOption.vCartonRepeatPara = ""
            ScanOption.IsOnelinePrintCarton = False
            ScanOption.IsOnlineGenCartonID = False
            txtPPIDCheckCode.Text = ""
            txtCartonCheckCode.Text = ""
            If Dr.HasRows Then
                While Dr.Read()
                    ScanOption.vRepeatStyle = Dr("RepeatStyle").ToString
                    ScanOption.vRepeatPara = Dr("RepeatPara").ToString
                    txtPPIDCheckCode.Text = Dr("RepeatPara").ToString
                    ScanOption.vCartonRepeatStyle = Dr("CartonRepeatStyle").ToString
                    ScanOption.vCartonRepeatPara = Dr("CartonRepeatPara").ToString
                    ScanOption.IsOnlineGenCartonID = IIf(Dr("IsOnlineGenCartonID").ToString = "Y", True, False)
                    ScanOption.IsOnelinePrintCarton = IIf(Dr("IsLinePrintFullCode").ToString = "Y", True, False)
                    txtCartonCheckCode.Text = Dr("CartonRepeatPara").ToString
                End While
                Dr.Close()
            End If

            ScanOption.VirtualTrayQty = 0
            lblTrayQTY.Visible = False
            SqlStr = String.Format("SELECT top 1 a.LayerNum,a.PcsOfEachLayer,a.PackageNum, a.PartId FROM dbo.m_PartGroupWithOutPEBag_t a INNER JOIN dbo.m_Mainmo_t b ON a.PartId=b.PartID WHERE b.Moid='{0}' AND a.factory ='{1}' AND A.PROFITCENTER='{2}' AND a.IsUseY='Y'", Me.mtxtMOid.Text, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dr = Conn.GetDataReader(SqlStr)
            If Dr.HasRows Then
                While Dr.Read()
                    ScanOption.VirtualTrayQty = Dr("PcsOfEachLayer").ToString
                    lblTrayQTY.Visible = True
                    lblTrayQTY.Text = String.Format("每个Tray盘应装数量:{0}", ScanOption.VirtualTrayQty)
                End While
                Dr.Close()
            End If
        Catch ex As Exception
        
        End Try

    End Sub
    ''' <summary>
    ''' 功能描述：删除不可见字符。
    ''' </summary>
    ''' <param name="sourceString">原字符串</param>
    ''' <returns></returns>
    Public Shared Function DeleteUnVisibleChar(ByVal sourceString As String) As String
        Dim strBuilder As New System.Text.StringBuilder(131)

        Dim aaa() As Byte = Encoding.UTF8.GetBytes(sourceString)
        ' ''  Dim cc As String = Convert.ToBase64String(sourceString)
        Dim uc() As Char = Encoding.UTF8.GetChars(aaa)
        For k As Integer = 0 To uc.Length - 1
            If Char.IsControl(uc(k)) = False Then
                strBuilder.Append(uc(k))
            End If
        Next
        Return strBuilder.ToString()
    End Function
#End Region

End Class