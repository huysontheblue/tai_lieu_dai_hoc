Imports System.Xml
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

Public Class FrmConfigPackSet
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

    '是否所有的都通过
    Private IsAllPass As Boolean = False
    '错误信息
    Private StrErrMsg As String = ""
    '是否扫描固定外箱参数 Add By KyLinQiu20180315
    Private IsScanFixedCarton As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Optional ByVal No As String = "")
        Me.StationID = No
        InitializeComponent()
    End Sub

    '取消
    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        ScanOption.IsExitFlag = True
        Me.Close()
    End Sub

    Private Sub FrmConfigSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadLineData()
        InitControlData()
        chk_LastRetailBox.Enabled = True
        ' chk_LastRetailBox.Visible = False
        ScanOption.IsExitFlag = True
        Dim stationid As String = GetXMLNodeData("stationid")
        Dim lineid As String = GetXMLNodeData("lineid")
        Dim moid As String = GetXMLNodeData("moid")
        If (stationid <> "") Then
            txtstationid.Text = stationid
        End If
        If (lineid <> "") Then
            Me.CbbLine.Text = lineid
        End If
        If (moid <> "") Then
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim StrSql As String = String.Format("SELECT Moid,Lineid FROM dbo.m_Mainmo_t WHERE Moid='{0}' AND Factory='" & VbCommClass.VbCommClass.Factory & "'", moid)
            Dim dtMoData As DataTable = Sdbc.GetDataTable(StrSql)
            If (Not dtMoData Is Nothing) AndAlso dtMoData.Rows.Count > 0 Then
                Me.mtxtMOid.Text = moid
                MoLineID = dtMoData.Rows(0)("Lineid").ToString.Trim

                LoadScanStyleData(moid)
            End If
        End If
        'Me.ActiveControl = mtxtMOid
        mtxtMOid.Focus()

        '改成动态从数据库中读取 Modified By KyLinQiu
        'Dim IsScanCarton As String = GetXMLNodeData("IsScanCarton")
        'Dim CartonStyle As String = GetXMLNodeData("CartonStyle")
        'Dim CartonQty As String = GetXMLNodeData("CartonQty")
        'Dim IsScanQrCode As String = GetXMLNodeData("IsScanQrCode")
        'Dim QrCodeStyle As String = GetXMLNodeData("QrCodeStyle")

        'Dim IsScanSecond As String = GetXMLNodeData("IsScanSecond")
        'Dim SecondStyle As String = GetXMLNodeData("SecondStyle")
        'Dim SecondQty As String = GetXMLNodeData("SecondQty")
        'Dim IsScanThird As String = GetXMLNodeData("IsScanThird")
        'Dim ThirdStyle As String = GetXMLNodeData("ThirdStyle")
        'Dim ThirdQty As String = GetXMLNodeData("ThirdQty")
        'Dim IsScanPpid As String = GetXMLNodeData("IsScanPpid")
        'Dim PpidStyle As String = GetXMLNodeData("PpidStyle")
        'Dim PpidQty As String = GetXMLNodeData("PpidQty")
        ''add by song
        ''2017-09-02
        'Dim CartonAutoGen As String = GetXMLNodeData("CartonAutoGen")
        'Dim PpidN As String = GetXMLNodeData("Ppid_N")

        'chkScanCarton.Checked = IIf(IsScanCarton = "Y", True, False)
        'If chkScanCarton.Checked Then
        '    txtCartonStyle.Text = CartonStyle
        '    txtCartonQty.Text = CartonQty
        'End If
        'chkScanQrCode.Checked = IIf(IsScanQrCode = "Y", True, False)
        'If chkScanQrCode.Checked Then
        '    txtQrCodeStyle.Text = QrCodeStyle
        'End If

        'chkScanSecond.Checked = IIf(IsScanSecond = "Y", True, False)
        'If chkScanSecond.Checked Then
        '    txtSecondStyle.Text = SecondStyle
        '    txtSecondQty.Text = SecondQty
        'End If
        'chkScanThird.Checked = IIf(IsScanThird = "Y", True, False)
        'If chkScanThird.Checked Then
        '    txtThirdStyle.Text = ThirdStyle
        '    txtThirdQty.Text = ThirdQty
        'End If

        'chkScanPpid.Checked = IIf(IsScanPpid = "Y", True, False)
        'If chkScanPpid.Checked Then
        '    txtPpidStyle.Text = PpidStyle
        '    txtPpidQty.Text = PpidQty
        'End If

        ''add by song
        ''2017-09-02
        'Carton_AutoGen.Checked = IIf(CartonAutoGen = "Y", True, False)
        'Ppid_N.Checked = IIf(PpidN = "Y", True, False)
    End Sub

    '加载线别
    Private Sub LoadLineData()
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = String.Format(" SELECT DISTINCT b.ButtonID AS lineid FROM m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " &
                                             " INNER JOIN deptline_t c ON b.ButtonID=c.lineid " &
                                             " WHERE b.tparent in('z09_','z0s_','z0t_','z0Y_','yx0T_','z0Q_') AND a.UserID='{0}' " &
                                             " AND c.factoryid='{1}' AND c.usey='Y' ", VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.Factory)
        Me.CbbLine.DataSource = Sdbc.GetDataTable(StrSql)
        Me.CbbLine.DisplayMember = "lineid"
        Me.CbbLine.ValueMember = "lineid"
    End Sub

    '初始化控件设置
    Private Sub InitControlData()
        Me.txtstationid.Text = ""
        Me.mtxtMOid.Text = ""
        Me.chkScanCarton.Checked = True
        Me.chkScanQrCode.Checked = False
        Me.Carton_AutoGen.Checked = False
        Me.ChkIsScanCustProAndQtyI.Checked = False
        Me.ChkIsSystemPrintCarton.Checked = False
        Me.ChkIsSystemPrintQRCode.Checked = False
        Me.ChkIsSystemPrintPECarton.Checked = False
        Me.ChkIsSystemPrintPpID.Checked = False
        Me.txtCartonStyle.Text = ""
        Me.txtCartonQty.Text = ""
        Me.txtQrCodeStyle.Text = ""
        Me.chkScanSecond.Checked = False
        Me.txtSecondStyle.Text = ""
        Me.txtSecondQty.Text = ""
        Me.chkScanThird.Checked = False
        Me.txtThirdStyle.Text = ""
        Me.txtThirdQty.Text = ""
        Me.chkScanPpid.Checked = True
        Me.Ppid_N.Checked = False
        Me.txtPpidStyle.Text = ""
        Me.txtPpidQty.Text = "1"
    End Sub

    Private Sub BnConFrm_Click(sender As Object, e As EventArgs) Handles BnConFrm.Click
        If txtstationid.Text.Trim = "" Then
            MessageBox.Show("站点编号不能为空！")
            Exit Sub
        End If
        If Me.mtxtMOid.Text.Trim = "" Then
            MessageBox.Show("工单不能为空！")
            Exit Sub
        End If
        If Me.CbbLine.Text = "" Then
            MessageBox.Show("线别不能为空！")
            Exit Sub
        End If
        If Me.CbbLine.Text.Trim <> MoLineID Then
            MessageBox.Show("所选线别与工单线别不匹配！")
            Exit Sub
        End If
        If VbCommClass.VbCommClass.Factory = "02J0" Then
            ScanOption.SelMOID = mtxtMOid.Text.Trim
            Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim strSQL_Check As String = String.Format("SELECT * from m_Lock  where Status_Lock='Y' and Moid='{0}'", mtxtMOid.Text.Trim)
            Dim dt_Check As DataTable
            dt_Check = ConnectDB.GetDataTable(strSQL_Check)
            If dt_Check.Rows.Count > 0 Then
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = " Failed "
                FrmError.MyErrorStr = "You have to unlock , Please contact to QC "
                FrmError.MyCobError = "You have to unlock , Please contact to QC！"
                FrmError.ShowDialog()
                Exit Sub
            End If
        End If
        If txtstationid.Text.Trim <> "" And Me.mtxtMOid.Text.Trim <> "" And Me.CbbLine.Text <> "" Then
            If IsAllPass = False Then
                MessageBox.Show(StrErrMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '外箱一定要扫描  手工扫描或自动生成
            If chkScanCarton.Checked Then
                If txtCartonStyle.Text.Trim = "" Then
                    MessageBox.Show("外箱条码样式不能为空")
                    'txtCartonStyle.Focus()
                    Exit Sub
                End If
                If txtCartonQty.Text.Trim = "" Then
                    MessageBox.Show("外箱装箱数量不能为空")
                    'txtCartonQty.Focus()
                    Exit Sub
                End If
            End If
            If chkScanQrCode.Checked Then
                If txtQrCodeStyle.Text.Trim = "" Then
                    MessageBox.Show("Qr条码样式不能为空")
                    'txtQrCodeStyle.Focus()
                    Exit Sub
                End If
            End If
            If chkScanSecond.Checked Then
                If txtSecondStyle.Text.Trim = "" Then
                    MessageBox.Show("二层外箱条码样式不能为空")
                    'txtSecondStyle.Focus()
                    Exit Sub
                End If
                If txtSecondQty.Text.Trim = "" Then
                    MessageBox.Show("二层外箱装箱数量不能为空")
                    'txtSecondQty.Focus()
                    Exit Sub
                End If
            End If

            '暂时未用到三层外箱
            'If chkScanThird.Checked Then
            '    If txtThirdStyle.Text = "" Then
            '        MessageBox.Show("三层外箱条码样式不能为空")
            '        txtThirdStyle.Focus()
            '        Exit Sub
            '    End If
            '    If txtThirdQty.Text = "" Then
            '        MessageBox.Show("三层外箱装箱数量不能为空")
            '        txtThirdQty.Focus()
            '        Exit Sub
            '    End If
            'End If

            If chkScanPpid.Checked = False Then
                MessageBox.Show("产品条码必须扫描")
                'chkScanPpid.Focus()
                Exit Sub
            Else
                If txtPpidStyle.Text.Trim = "" Then
                    MessageBox.Show("产品条码样式不能为空")
                    'txtPpidStyle.Focus()
                    Exit Sub
                End If
                If txtPpidQty.Text.Trim = "" Then
                    MessageBox.Show("产品条码扫描数量不能为空")
                    'txtPpidQty.Focus()
                    Exit Sub
                End If
            End If

            'Mr Luu Added 20201211
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass

                Dim strSQL_MOSetupQty As String = String.Format(" Select top 1 Moqty From m_Mainmo_t  where  Moid='{0}' ", mtxtMOid.Text.Trim)
                Dim dt_MOSetupQty As DataTable
                dt_MOSetupQty = ConnectDB.GetDataTable(strSQL_MOSetupQty)
                Dim MOSetupQty As Integer
                If dt_MOSetupQty.Rows.Count > 0 Then
                    MOSetupQty = Convert.ToInt32(dt_MOSetupQty.Rows(0)("Moqty").ToString())
                    ScanOption.MOSetupQty = MOSetupQty
                Else
                    MOSetupQty = 0
                    ScanOption.MOSetupQty = MOSetupQty
                End If

                Dim strSQL_MOScannedQty As String = String.Format(" Select count(ppid) as MOScannedQty from m_Cartonsn_t p where p.Cartonid in (select Cartonid from m_Carton_HY_t where Moid='{0}') ", mtxtMOid.Text.Trim)
                Dim dt_MOScannedQty As DataTable
                dt_MOScannedQty = ConnectDB.GetDataTable(strSQL_MOScannedQty)
                Dim MOScannedQty As Integer
                If dt_MOScannedQty.Rows.Count > 0 Then
                    MOScannedQty = Convert.ToInt32(dt_MOScannedQty.Rows(0)("MOScannedQty").ToString())
                    ScanOption.MOScannedQty = MOScannedQty
                Else
                    MOScannedQty = 0
                    ScanOption.MOScannedQty = MOScannedQty
                End If

                Dim strSQL_MONGQty As String = String.Format(" Select count(Moid) as MONGQty from m_AssysnE_t where Moid='{0}' ", mtxtMOid.Text.Trim)
                Dim dt_MONGQty As DataTable
                dt_MONGQty = ConnectDB.GetDataTable(strSQL_MONGQty)
                Dim MONGQty As Integer
                If dt_MONGQty.Rows.Count > 0 Then
                    MONGQty = Convert.ToInt32(dt_MONGQty.Rows(0)("MONGQty").ToString())
                    ScanOption.MONGQty = MONGQty
                Else
                    MONGQty = 0
                    ScanOption.MONGQty = MONGQty
                End If
            End If
            'End Mr Luu Added 20201211

            Try
                ScanOption.CartonQty = Convert.ToInt32(txtCartonQty.Text.Trim)
                If Me.chkScanSecond.Checked Then
                    ScanOption.SelSecondQty = Convert.ToInt32(txtSecondQty.Text.Trim)
                End If
                'ScanOption.SelThirdQty = txtThirdQty.Text.Trim
                ScanOption.SelPpidQty = Convert.ToInt32(txtPpidQty.Text.Trim)
            Catch ex As Exception
                MessageBox.Show("数量格式有误,请重新输入！")
                Exit Sub
            End Try

            ScanOption.SelStationID = txtstationid.Text.Trim
            ScanOption.SelLineID = CbbLine.Text.Trim
            ScanOption.SelMOID = mtxtMOid.Text.Trim

            '外箱为必扫描  分手动扫描和自动生成
            ScanOption.IsScanCarton = True
            ScanOption.SelCartonStyle = txtCartonStyle.Text.Trim


            ScanOption.IsScanCartonQrCode = chkScanQrCode.Checked
            ScanOption.SelQrCodeStyle = txtQrCodeStyle.Text.Trim

            ScanOption.IsScanSecondCode = chkScanSecond.Checked
            ScanOption.SelSecondStyle = txtSecondStyle.Text.Trim

            '目前不支持第三层
            'ScanOption.IsScanThirdCode = chkScanThird.Checked
            'ScanOption.SelThirdStyle = txtThirdStyle.Text.Trim

            '条码为必扫描选项
            ScanOption.SelPpidStyle = txtPpidStyle.Text.Trim

            'add by song
            '2017-09-02
            ScanOption.CartonAutoGen = Carton_AutoGen.Checked
            ScanOption.PPid_N = Ppid_N.Checked

            'Add By KyLinQiu20180315
            ScanOption.IsScanFixedCarton = Me.IsScanFixedCarton

            '是否扫描客户料号及装箱数量  Add By KyLinQiu20171010
            ScanOption.IsScanCustProAndQtyI = Me.ChkIsScanCustProAndQtyI.Checked
            ScanOption.IsSystemPrintCarton = Me.ChkIsSystemPrintCarton.Checked
            ScanOption.IsSystemPrintQRCode = Me.ChkIsSystemPrintQRCode.Checked
            ScanOption.IsSystemPrintPECarton = Me.ChkIsSystemPrintPECarton.Checked
            ScanOption.IsSystemPrintPpID = Me.ChkIsSystemPrintPpID.Checked

            '只保存工站,线别,工单信息即可
            SetXMLNodeData("stationid", txtstationid.Text.Trim)
            SetXMLNodeData("lineid", CbbLine.Text.Trim)
            SetXMLNodeData("moid", mtxtMOid.Text.Trim)
            'SetXMLNodeData("IsScanCarton", IIf(chkScanCarton.Checked, "Y", "N"))
            'SetXMLNodeData("CartonStyle", txtCartonStyle.Text)
            'SetXMLNodeData("CartonQty", txtCartonQty.Text)
            'SetXMLNodeData("IsScanQrCode", IIf(chkScanQrCode.Checked, "Y", "N"))
            'SetXMLNodeData("QrCodeStyle", txtQrCodeStyle.Text)
            'SetXMLNodeData("IsScanSecond", IIf(chkScanSecond.Checked, "Y", "N"))
            'SetXMLNodeData("SecondStyle", txtSecondStyle.Text)
            'SetXMLNodeData("SecondQty", txtSecondQty.Text)
            'SetXMLNodeData("IsScanThird", IIf(chkScanThird.Checked, "Y", "N"))
            'SetXMLNodeData("ThirdStyle", txtThirdStyle.Text)
            'SetXMLNodeData("ThirdQty", txtThirdQty.Text)
            'SetXMLNodeData("IsScanPpid", IIf(chkScanPpid.Checked, "Y", "N"))
            'SetXMLNodeData("PpidStyle", txtPpidStyle.Text)
            'SetXMLNodeData("PpidQty", txtPpidQty.Text)
            'add by song
            '2017-09-02
            'SetXMLNodeData("CartonAutoGen", IIf(Carton_AutoGen.Checked, "Y", "N"))
            'SetXMLNodeData("Ppid_N", IIf(Ppid_N.Checked, "Y", "N"))

            ScanOption.IsExitFlag = False
            Me.Close()
        End If
    End Sub

    '写入XML配置信息
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

    '读取XML配置信息
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

    '扫描设置编辑
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'If scanset.Enabled Then
        '    scanset.Enabled = False
        '    btnEdit.Text = "扫描设置编辑"
        'Else
        '    Dim FrmOpenLock As New FrmSetLock
        '    FrmShareSetForm.vStationType = "P"
        '    'add by song
        '    '2016-10-12
        '    If MultLanguage.Language.lang <> "zh-chs" Then
        '        MultLanguage.Language.SetControlText(FrmOpenLock)
        '        MultLanguage.Tips.FormTip(FrmOpenLock)
        '    End If
        '    FrmOpenLock.ShowDialog()
        '    If CartonScanOption.CheckStr = True Then
        '        scanset.Enabled = True
        '        btnEdit.Text = "取消编辑"
        '    End If
        'End If
    End Sub

    '工单回车事件
    Private Sub txtMoid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtxtMOid.KeyPress
        If e.KeyChar = Chr(13) Then
            If mtxtMOid.Text.Trim = "" Then
                Exit Sub
            End If
            BnConFrm_Click(Nothing, Nothing)
        End If
    End Sub

    '筛选工单事件
    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Dim frm As New FrmMOQuery(Me.mtxtMOid, "")
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MoLineID = ""
            CbbLine.Text = ""
            IsAllPass = False
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim StrSql As String = "SELECT Lineid FROM m_Mainmo_t WHERE Moid='" & Me.mtxtMOid.Text.Trim & "'"
            Dim dtData As DataTable = Sdbc.GetDataTable(StrSql)
            If (Not dtData Is Nothing) AndAlso dtData.Rows.Count > 0 Then
                Me.CbbLine.SelectedIndex = Me.CbbLine.FindString(dtData.Rows(0)("Lineid").ToString.Trim)
                MoLineID = dtData.Rows(0)("Lineid").ToString.Trim

                If String.IsNullOrEmpty(MoLineID) Then
                    CbbLine.SelectedIndex = -1
                Else
                    CbbLine.Items.Add(MoLineID)
                    CbbLine.Text = MoLineID
                End If

                LoadScanStyleData(Me.mtxtMOid.Text.Trim)
            End If
        End If
    End Sub

    Private Sub chkScanThird_CheckedChanged(sender As Object, e As EventArgs) Handles chkScanThird.CheckedChanged
        If chkScanThird.Checked Then
            chkScanSecond.Checked = True
        End If
    End Sub

    Private Sub LoadScanStyleData(ByVal StrMoID As String)
        Dim StrSql As String = String.Format(" SELECT a.Moid,a.Cusid, b.LPartID,ISNULL(c.Packid,'') AS CartonStylePackID,ISNULL(c.Packitem,0) AS CartonStylePackItem,ISNULL(c.CodeRuleID,'') AS CartonCodeRuleID,ISNULL(c.Usey,'') AS CartonCodeRuleUsey, " &
                " b.CartonQtyI,b.IsAutoGenerateCarton,b.IsScanFixedCarton,b.IsSystemPrintCarton,b.IsScanCustProAndQtyI,b.IsScanQRCode,ISNULL(d.Packid,'') AS QRCodeStylePackID,ISNULL(d.Packitem,0) AS QRCodeStylePackItem,ISNULL(d.CodeRuleID,'') AS QRCodeCodeRuleID,ISNULL(d.Usey,'') AS QRCodeRuleUsey,b.IsSystemPrintQRCode, " &
                " b.IsScanPECarton,ISNULL(e.Packid,'') AS PECartonStylePackID,ISNULL(e.Packitem,0) AS PECartonStylePackItem,b.PECartonQtyI,b.IsSystemPrintPECarton,ISNULL(e.CodeRuleID,'') AS PECartonCodeRuleID,ISNULL(e.Usey,'') AS PECartonCodeRuleUsey, " &
                " b.IsFixedCode,b.PpIDQtyI,b.IsSystemPrintPpID,b.IsChecked,ISNULL(f.Packid,'') AS PpIDCodeStylePackID,ISNULL(f.Packitem,0) AS PpIDCodeStylePackItem,ISNULL(f.CodeRuleID,'') AS PPIDCodeRuleID,ISNULL(f.Usey,'') AS PPIDCodeRuleUsey,g.CustPart " &
                " FROM dbo.m_Mainmo_t a INNER JOIN dbo.m_PartScanStyleInof_t b ON a.PartID=b.LPartID " &
                " LEFT JOIN dbo.m_PartPack_t c ON b.LPartID=c.Partid AND b.CartonStylePackID=c.Packid AND b.CartonStylePackItem=c.Packitem " &
                " LEFT JOIN dbo.m_PartPack_t d ON b.LPartID=d.Partid AND b.QRCodeStylePackID=d.Packid AND b.QRCodeStylePackItem=d.Packitem " &
                " LEFT JOIN dbo.m_PartPack_t e ON b.LPartID=e.Partid AND b.PECartonStylePackID=e.Packid AND b.PECartonStylePackItem=e.Packitem " &
                " LEFT JOIN dbo.m_PartPack_t f ON b.LPartID=f.Partid AND b.PpIDCodeStylePackID=f.Packid AND b.PpIDCodeStylePackItem=f.Packitem " &
                " LEFT JOIN dbo.m_PartContrast_t g ON b.LPartID=g.TAvcPart " &
                " WHERE a.Moid='{0}' ", StrMoID)
        Dim dtScanStyle As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If (dtScanStyle Is Nothing) OrElse dtScanStyle.Rows.Count <= 0 Then
            StrErrMsg = "未找到该工单号对应料件的扫描设置信息！"
            Exit Sub
        End If
        Dim IsChecked As String = dtScanStyle.Rows(0)("IsChecked").ToString.Trim
        If IsChecked <> "Y" Then
            StrErrMsg = "该工单号对应料件的扫描设置信息未审核！"
            Exit Sub
        End If
        Dim CartonStylePackID As String = dtScanStyle.Rows(0)("CartonStylePackID").ToString.Trim
        Dim CartonStylePackItem As Integer = Convert.ToInt32(dtScanStyle.Rows(0)("CartonStylePackItem").ToString.Trim)
        If CartonStylePackID = "" Then
            StrErrMsg = "该工单号对应料件的外箱条码样式未设置！"
            Exit Sub
        End If
        Dim CartonCodeRuleUsey As String = dtScanStyle.Rows(0)("CartonCodeRuleUsey").ToString.Trim
        If (CartonCodeRuleUsey <> "C") AndAlso (CartonCodeRuleUsey <> "Y") Then
            StrErrMsg = "该工单号对应料件的外箱条码样式还未确认！"
            Exit Sub
        End If
        Dim IsScanQRCode As String = dtScanStyle.Rows(0)("IsScanQRCode").ToString.Trim
        Dim QRCodeStylePackID As String = dtScanStyle.Rows(0)("QRCodeStylePackID").ToString.Trim
        Dim QRCodeStylePackItem As Integer = Convert.ToInt32(dtScanStyle.Rows(0)("QRCodeStylePackItem").ToString.Trim)
        Dim QRCodeRuleUsey As String = dtScanStyle.Rows(0)("QRCodeRuleUsey").ToString.Trim
        If IsScanQRCode = "Y" Then
            If QRCodeStylePackID = "" Then
                StrErrMsg = "该工单号对应料件的QR条码样式未设置！"
                Exit Sub
            End If
            If (QRCodeRuleUsey <> "C") AndAlso (QRCodeRuleUsey <> "Y") Then
                StrErrMsg = "该工单号对应料件的QR条码样式还未确认！"
                Exit Sub
            End If
        End If
        Dim IsScanPECarton As String = dtScanStyle.Rows(0)("IsScanPECarton").ToString.Trim
        Dim PECartonStylePackID As String = dtScanStyle.Rows(0)("PECartonStylePackID").ToString.Trim
        Dim PECartonStylePackItem As Integer = Convert.ToInt32(dtScanStyle.Rows(0)("PECartonStylePackItem").ToString.Trim)
        Dim PECartonCodeRuleUsey As String = dtScanStyle.Rows(0)("PECartonCodeRuleUsey").ToString.Trim
        Dim PECartonQtyI As String = dtScanStyle.Rows(0)("PECartonQtyI").ToString.Trim
        If IsScanPECarton = "Y" Then
            If PECartonStylePackID = "" Then
                StrErrMsg = "该工单号对应料件的PE袋条码样式未设置！"
                Exit Sub
            End If
            If (PECartonCodeRuleUsey <> "C") AndAlso (PECartonCodeRuleUsey <> "Y") Then
                StrErrMsg = "该工单号对应料件的PE袋条码样式还未确认！"
                Exit Sub
            End If
            Me.txtSecondQty.Text = PECartonQtyI
        End If
        Dim PpIDCodeStylePackID As String = dtScanStyle.Rows(0)("PpIDCodeStylePackID").ToString.Trim
        Dim PpIDCodeStylePackItem As Integer = Convert.ToInt32(dtScanStyle.Rows(0)("PpIDCodeStylePackItem").ToString.Trim)
        Dim PPIDCodeRuleUsey As String = dtScanStyle.Rows(0)("PPIDCodeRuleUsey").ToString.Trim
        If PpIDCodeStylePackID = "" Then
            StrErrMsg = "该工单号对应料件的产品条码样式未设置！"
            Exit Sub
        End If
        If (PPIDCodeRuleUsey <> "C") AndAlso (PPIDCodeRuleUsey <> "Y") Then
            StrErrMsg = "该工单号对应料件的产品条码样式还未确认！"
            Exit Sub
        End If

        Me.chkScanCarton.Checked = True
        Me.chkScanPpid.Checked = True
        Dim CartonQtyI As String = dtScanStyle.Rows(0)("CartonQtyI").ToString.Trim
        Me.txtCartonQty.Text = CartonQtyI
        Dim IsAutoGenerateCarton As String = dtScanStyle.Rows(0)("IsAutoGenerateCarton").ToString.Trim
        If IsAutoGenerateCarton = "Y" Then
            Me.Carton_AutoGen.Checked = True
        Else
            Me.Carton_AutoGen.Checked = False
        End If

        Dim strIsScanFixedCarton As String = dtScanStyle.Rows(0)("IsScanFixedCarton").ToString.Trim
        If strIsScanFixedCarton = "Y" Then
            IsScanFixedCarton = True
        Else
            IsScanFixedCarton = False
        End If

        '是否扫描客户料号及装箱数量 Add By KyLinQiu20171010
        Dim IsScanCustProAndQtyI As String = dtScanStyle.Rows(0)("IsScanCustProAndQtyI").ToString.Trim
        Dim CustPart As String = dtScanStyle.Rows(0)("CustPart").ToString.Trim
        If IsScanCustProAndQtyI = "Y" Then
            Me.ChkIsScanCustProAndQtyI.Checked = True
            If (CustPart = "") OrElse (CartonQtyI.ToString = "") Then
                StrErrMsg = "该工单号对应料件的客户料号或装箱数量未设置！"
                Exit Sub
            End If
            ScanOption.CustPartStyle = CustPart
            '华为料号数量条码以Q打头
            ScanOption.CartonQtyIStyle = "Q" & CartonQtyI.ToString
        Else
            Me.ChkIsScanCustProAndQtyI.Checked = False
            ScanOption.CustPartStyle = ""
            ScanOption.CartonQtyIStyle = ""
        End If

        '是否系统打印条码 Add By KyLinQiu 20171016
        Dim IsSystemPrintCarton As String = dtScanStyle.Rows(0)("IsSystemPrintCarton").ToString.Trim
        Dim IsSystemPrintQRCode As String = dtScanStyle.Rows(0)("IsSystemPrintQRCode").ToString.Trim
        Dim IsSystemPrintPECarton As String = dtScanStyle.Rows(0)("IsSystemPrintPECarton").ToString.Trim
        Dim IsSystemPrintPpID As String = dtScanStyle.Rows(0)("IsSystemPrintPpID").ToString.Trim
        If IsSystemPrintCarton = "Y" Then
            Me.ChkIsSystemPrintCarton.Checked = True
        Else
            Me.ChkIsSystemPrintCarton.Checked = False
        End If
        If IsSystemPrintQRCode = "Y" Then
            Me.ChkIsSystemPrintQRCode.Checked = True
        Else
            Me.ChkIsSystemPrintQRCode.Checked = False
        End If
        If IsSystemPrintPECarton = "Y" Then
            Me.ChkIsSystemPrintPECarton.Checked = True
        Else
            Me.ChkIsSystemPrintPECarton.Checked = False
        End If
        If IsSystemPrintPpID = "Y" Then
            Me.ChkIsSystemPrintPpID.Checked = True
        Else
            Me.ChkIsSystemPrintPpID.Checked = False
        End If

        If IsScanQRCode = "Y" Then
            Me.chkScanQrCode.Checked = True
        Else
            Me.chkScanQrCode.Checked = False
        End If
        If IsScanPECarton = "Y" Then
            Me.chkScanSecond.Checked = True
        Else
            Me.chkScanSecond.Checked = False
        End If
        Dim IsFixedCode As String = dtScanStyle.Rows(0)("IsFixedCode").ToString.Trim
        If IsFixedCode = "Y" Then
            Me.Ppid_N.Checked = True
        Else
            Me.Ppid_N.Checked = False
        End If
        Dim PpIDQtyI As String = dtScanStyle.Rows(0)("PpIDQtyI").ToString.Trim
        Me.txtPpidQty.Text = PpIDQtyI

        Dim LPartID As String = dtScanStyle.Rows(0)("LPartID").ToString.Trim
        Dim StrDate As String = Date.Now.ToString("yyyy-MM-dd")
        Dim CartonCodeRuleID As String = dtScanStyle.Rows(0)("CartonCodeRuleID").ToString.Trim
        Dim QRCodeCodeRuleID As String = dtScanStyle.Rows(0)("QRCodeCodeRuleID").ToString.Trim
        Dim PECartonCodeRuleID As String = dtScanStyle.Rows(0)("PECartonCodeRuleID").ToString.Trim
        Dim PPIDCodeRuleID As String = dtScanStyle.Rows(0)("PPIDCodeRuleID").ToString.Trim
        Dim dtRuleTemp As DataTable = Nothing
        StrSql = String.Format("declare @SnStyle1 varchar(150),@SnStyle2 varchar(150),@Gflen varchar(8) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_p_AssembleSta_ByNewScan '{0}','{1}','{2}','{3}',{4},@SnStyle1 output ,@SnStyle2 output,@Gflen output,'{5}','{6}','{7}' select @SnStyle1,@SnStyle2,@Gflen",
                               LPartID, CartonCodeRuleID, StrDate, CartonStylePackID, CartonStylePackItem, StrMoID, Me.CbbLine.Text.Trim, CartonQtyI)
        dtRuleTemp = DbOperateUtils.GetDataTable(StrSql)
        If (dtRuleTemp Is Nothing) OrElse dtRuleTemp.Rows.Count <= 0 Then
            StrErrMsg = "该工单号对应料件的外箱条码样式未设置！"
            Exit Sub
        Else
            Me.txtCartonStyle.Text = dtRuleTemp.Rows(0)(0).ToString.Trim
        End If
        If IsScanQRCode = "Y" Then
            StrSql = String.Format("declare @SnStyle1 varchar(150),@SnStyle2 varchar(150),@Gflen varchar(8) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_p_AssembleSta_ByNewScan '{0}','{1}','{2}','{3}',{4},@SnStyle1 output ,@SnStyle2 output,@Gflen output,'{5}','{6}','{7}' select @SnStyle1,@SnStyle2,@Gflen",
                               LPartID, QRCodeCodeRuleID, StrDate, QRCodeStylePackID, QRCodeStylePackItem, StrMoID, Me.CbbLine.Text.Trim, CartonQtyI)
            dtRuleTemp = DbOperateUtils.GetDataTable(StrSql)
            If (dtRuleTemp Is Nothing) OrElse dtRuleTemp.Rows.Count <= 0 Then
                StrErrMsg = "该工单号对应料件的QR条码样式未设置！"
                Exit Sub
            Else
                Me.txtQrCodeStyle.Text = dtRuleTemp.Rows(0)(0).ToString.Trim
            End If
        End If
        If IsScanPECarton = "Y" Then
            StrSql = String.Format("declare @SnStyle1 varchar(150),@SnStyle2 varchar(150),@Gflen varchar(8) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_p_AssembleSta_ByNewScan '{0}','{1}','{2}','{3}',{4},@SnStyle1 output ,@SnStyle2 output,@Gflen output,'{5}','{6}','{7}' select @SnStyle1,@SnStyle2,@Gflen",
                               LPartID, PECartonCodeRuleID, StrDate, PECartonStylePackID, PECartonStylePackItem, StrMoID, Me.CbbLine.Text.Trim, CartonQtyI)
            dtRuleTemp = DbOperateUtils.GetDataTable(StrSql)
            If (dtRuleTemp Is Nothing) OrElse dtRuleTemp.Rows.Count <= 0 Then
                StrErrMsg = "该工单号对应料件的PE袋条码样式未设置！"
                Exit Sub
            Else
                Me.txtSecondStyle.Text = dtRuleTemp.Rows(0)(0).ToString.Trim
            End If
        End If
        StrSql = String.Format("declare @SnStyle1 varchar(150),@SnStyle2 varchar(150),@Gflen varchar(8) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_p_AssembleSta_ByNewScan '{0}','{1}','{2}','{3}',{4},@SnStyle1 output ,@SnStyle2 output,@Gflen output,'{5}','{6}','{7}' select @SnStyle1,@SnStyle2,@Gflen",
                               LPartID, PPIDCodeRuleID, StrDate, PpIDCodeStylePackID, PpIDCodeStylePackItem, StrMoID, Me.CbbLine.Text.Trim, CartonQtyI)
        dtRuleTemp = DbOperateUtils.GetDataTable(StrSql)
        If (dtRuleTemp Is Nothing) OrElse dtRuleTemp.Rows.Count <= 0 Then
            StrErrMsg = "该工单号对应料件的产品条码样式未设置！"
            Exit Sub
        Else
            Me.txtPpidStyle.Text = dtRuleTemp.Rows(0)(0).ToString.Trim
        End If
        '所有都通过了
        IsAllPass = True
    End Sub
    'Mr Luu Add Scan Retail Box for VietNam Factory
    Private Sub chk_LastRetailBox_CheckedChanged(sender As Object, e As EventArgs) Handles chk_LastRetailBox.CheckedChanged
        Dim StrSql As String = String.Format(" SELECT a.Moid,a.Cusid, b.LPartID,ISNULL(c.Packid,'') AS CartonStylePackID,ISNULL(c.Packitem,0) AS CartonStylePackItem,ISNULL(c.CodeRuleID,'') AS CartonCodeRuleID,ISNULL(c.Usey,'') AS CartonCodeRuleUsey, " &
                  " b.CartonQtyI,b.IsAutoGenerateCarton,b.IsScanFixedCarton,b.IsSystemPrintCarton,b.IsScanCustProAndQtyI,b.IsScanQRCode,ISNULL(d.Packid,'') AS QRCodeStylePackID,ISNULL(d.Packitem,0) AS QRCodeStylePackItem,ISNULL(d.CodeRuleID,'') AS QRCodeCodeRuleID,ISNULL(d.Usey,'') AS QRCodeRuleUsey,b.IsSystemPrintQRCode, " &
                  " b.IsScanPECarton,ISNULL(e.Packid,'') AS PECartonStylePackID,ISNULL(e.Packitem,0) AS PECartonStylePackItem,b.PECartonQtyI,b.IsSystemPrintPECarton,ISNULL(e.CodeRuleID,'') AS PECartonCodeRuleID,ISNULL(e.Usey,'') AS PECartonCodeRuleUsey, " &
                  " b.IsFixedCode,b.PpIDQtyI,b.IsSystemPrintPpID,b.IsChecked,ISNULL(f.Packid,'') AS PpIDCodeStylePackID,ISNULL(f.Packitem,0) AS PpIDCodeStylePackItem,ISNULL(f.CodeRuleID,'') AS PPIDCodeRuleID,ISNULL(f.Usey,'') AS PPIDCodeRuleUsey,g.CustPart " &
                  " FROM dbo.m_Mainmo_t a INNER JOIN dbo.m_PartScanStyleInof_t b ON a.PartID=b.LPartID " &
                  " LEFT JOIN dbo.m_PartPack_t c ON b.LPartID=c.Partid AND b.CartonStylePackID=c.Packid AND b.CartonStylePackItem=c.Packitem " &
                  " LEFT JOIN dbo.m_PartPack_t d ON b.LPartID=d.Partid AND b.QRCodeStylePackID=d.Packid AND b.QRCodeStylePackItem=d.Packitem " &
                  " LEFT JOIN dbo.m_PartPack_t e ON b.LPartID=e.Partid AND b.PECartonStylePackID=e.Packid AND b.PECartonStylePackItem=e.Packitem " &
                  " LEFT JOIN dbo.m_PartPack_t f ON b.LPartID=f.Partid AND b.PpIDCodeStylePackID=f.Packid AND b.PpIDCodeStylePackItem=f.Packitem " &
                  " LEFT JOIN dbo.m_PartContrast_t g ON b.LPartID=g.TAvcPart " &
                  " WHERE a.Moid='{0}' ", mtxtMOid.Text.Trim())
        Dim dtScanStyle As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If mtxtMOid.Text.Trim() <> "" Then
            If chk_LastRetailBox.Checked = True Then
                Dim StrMoCheckSql As String = String.Format("SELECT ISNULL(SUM(a.PackingQuantity),0) AS PackingQuantity,b.Moqty FROM m_Carton_HY_t a INNER JOIN dbo.m_Mainmo_t b ON a.Moid=b.Moid  WHERE a.Moid='{0}' AND a.CartonLevel=1 GROUP BY b.Moqty", mtxtMOid.Text.Trim())
                Dim dtMoCheckData As DataTable = DbOperateUtils.GetDataTable(StrMoCheckSql)
                If dtMoCheckData.Rows.Count > 0 Then
                    If Convert.ToInt32(dtMoCheckData.Rows(0)("Moqty")) - Convert.ToInt32(dtMoCheckData.Rows(0)("PackingQuantity")) > 0 And Convert.ToInt32(dtMoCheckData.Rows(0)("Moqty")) - Convert.ToInt32(dtMoCheckData.Rows(0)("PackingQuantity")) < Convert.ToInt32(dtScanStyle.Rows(0)("CartonQtyI")) Then
                        Dim LastRetailBox As String = Convert.ToString(Convert.ToInt32(dtMoCheckData.Rows(0)("Moqty").ToString) Mod Convert.ToInt32(txtCartonQty.Text.Trim()))
                        txtCartonQty.Text = LastRetailBox
                    Else
                        MessageBox.Show(" This is not last retail box , Do not allow scanning .")
                        chk_LastRetailBox.Checked = False
                        Exit Sub
                    End If
                End If
            Else
                txtCartonQty.Text = Convert.ToString(dtScanStyle.Rows(0)("CartonQtyI"))
            End If
        Else
            MessageBox.Show(" MO can not empty, Please Input MO")
        End If

    End Sub
    'End  'Mr Luu Add Scan Retail Box for VietNam Factory

End Class