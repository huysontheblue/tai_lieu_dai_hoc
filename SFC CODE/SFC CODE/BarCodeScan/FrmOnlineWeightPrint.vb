Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.IO.Ports
Imports System.Xml
Imports System.IO

''' <summary>
''' 称重打印
''' </summary>
''' <remarks></remarks>
Public Class FrmOnlineWeightPrint

    Private m_moid As String
    Private m_partId As String
    Private m_printName As String
    Private m_cartonId As String
    Private m_cartonQty As String
    Private m_LabelNum As String
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format
    '内箱条码
    Private m_CartonIdOne As String
    Private m_CartonIdTwo As String
    Private m_CartonIdTre As String
    Private m_CartonIdFou As String
    ''' <summary>
    ''' 是否打印外箱，Y 称重打印 N代表只称重不打印
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IsLinePrintFullCode As String = True
    Public WriteOnly Property IsLinePrintFullCode() As String
        Set(value As String)
            m_IsLinePrintFullCode = value
        End Set
    End Property
    ''' <summary>
    ''' 箱称重上限
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UpLimitWeight As String = ""
    Public WriteOnly Property UpLimitWeight() As String
        Set(value As String)
            m_UpLimitWeight = value
        End Set
    End Property
    ''' <summary>
    ''' 箱称重下限
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LowLimitWeight As String = ""
    Public WriteOnly Property LowLimitWeight() As String
        Set(value As String)
            m_LowLimitWeight = value
        End Set
    End Property
    ''' <summary>
    ''' RS232端口参数字符串
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Rs232Pars As String = "" ' "COM1|9600|0|8|1"
    Public WriteOnly Property Rs232Pars() As String
        Set(value As String)
            m_Rs232Pars = value
        End Set
    End Property
    '编码原则
    Private m_CodeRuleId As String
    Public WriteOnly Property Moid() As String
        Set(value As String)
            m_moid = value
        End Set
    End Property

    Public WriteOnly Property PartId() As String
        Set(value As String)
            m_partId = value
        End Set
    End Property

    Public WriteOnly Property PrintName() As String
        Set(value As String)
            m_printName = value
        End Set
    End Property

    Public WriteOnly Property LabelNum() As String
        Set(value As String)
            m_LabelNum = value
        End Set
    End Property

    Public WriteOnly Property CartonId() As String
        Set(value As String)
            m_cartonId = value
            TxtCotainerNo.Text = value
        End Set
    End Property

    Public WriteOnly Property SetTabVisible
        Set(value)
            If value = True Then
                TabPage1.Parent = TabControl1
                TabPage2.Parent = Nothing
                TabPage3.Parent = Nothing

            Else
                TabPage1.Parent = Nothing
                TabPage2.Parent = TabControl1
                TabPage3.Parent = TabControl1

            End If
        End Set
    End Property

    Private Sub FrmOnlineWeightPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次
        If m_IsLinePrintFullCode = True Then
            RadIsLinePrintFullCode.Checked = True
            RadIsLineNOPrintFullCode.Checked = False
            btApp = New BarTender.Application
            btFormat = New BarTender.Format
        Else
            RadIsLinePrintFullCode.Checked = False
            RadIsLineNOPrintFullCode.Checked = True
        End If
        txtLowlimit.Text = m_LowLimitWeight
        txtUpLimit.Text = m_UpLimitWeight
        ''是否启动自动称重设置
        Dim m_WeightAuto As String = GetXMLNodeData("WeightAuto")
        If m_WeightAuto = "Y" Then
            m_Rs232Pars = GetXMLNodeData("WeightComPar")
            If m_Rs232Pars <> "" Then
                txtComInfo.Text = m_Rs232Pars
                RbAuto.Checked = True
                RbManual.Checked = False
                Rs232Init()

            Else
                RbAuto.Checked = False
                RbManual.Checked = True
                lbComDes.Text = ""
                txtComInfo.Text = ""
                lbComDes.ForeColor = Color.Red
                lbComDes.Text = "未开启"
                txtWeight.ReadOnly = False
                txtWeight2.ReadOnly = False
                txtWeight3.ReadOnly = False
            End If
        Else
            RbAuto.Checked = False
            RbManual.Checked = True
            lbComDes.Text = ""
            txtComInfo.Text = ""
            lbComDes.ForeColor = Color.Red
            lbComDes.Text = "未开启"
            txtWeight.ReadOnly = False
            txtWeight2.ReadOnly = False
            txtWeight3.ReadOnly = False
        End If

    End Sub

    Private Sub FrmOnlineWeightPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not btApp Is Nothing Then
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        End If

        If Not RS232 Is Nothing Then
            If RS232.IsOpen Then  '開啟
                RS232.Close()
                RS232.Dispose()
                RS232 = Nothing
            End If
        End If

    End Sub

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub

    Private Sub BnOpenlock_Click(sender As Object, e As EventArgs) Handles BnOpenlock.Click
        Try
            Dim weight As String = ""
            Dim IsListCarton As Boolean = False

            If TabControl1.SelectedTab.Name = TabPage1.Name Then
                weight = txtWeight.Text.Trim
                'Decimal.Round(weight, 3, MidpointRounding.AwayFromZero)
                If ScanCommon.IsTextBoxBlank(txtWeight, "请输入箱称重重量!") = False Then Exit Sub
                If ScanCommon.IsWeight(txtWeight, "请输入正确的箱重量格式为(XX.XXX)!") = False Then Exit Sub
                Dim checkstr As String = CheckWeight(weight, txtUpLimit.Text, txtLowlimit.Text)
                If checkstr <> "" Then
                    MessageUtils.ShowError(checkstr)
                    txtWeight.Focus()
                    txtWeight.SelectAll()
                    Exit Sub
                End If
            ElseIf TabControl1.SelectedTab.Name = TabPage2.Name Then
                weight = txtWeight2.Text.Trim
                Dim checkstr As String = CheckWeight(weight, txtUpLimit.Text, txtLowlimit.Text)
                If checkstr <> "" Then
                    MessageUtils.ShowError(checkstr)
                    txtWeight2.Focus()
                    txtWeight2.SelectAll()
                    Exit Sub
                End If
                If ScanCommon.IsTextBoxBlank(txtWeight2, "请输入箱称重重量!") = False Then Exit Sub
                If ScanCommon.IsWeight(txtWeight2, "请输入正确的箱重量格式为(XX.XXX)!") = False Then Exit Sub
                If ScanCommon.IsTextBoxBlank(txtBarcode, "请输入箱号或者产品条码!") = False Then Exit Sub
                If ScanCommon.IsTextBoxBlank(TxtPassWord, "请输入解锁密码!") = False Then Exit Sub
                If ScanCommon.IsOpenLock(TxtPassWord, "没有解锁权限!") = False Then Exit Sub
                If ScanCommon.IsNotExsitCarton(txtBarcode, m_moid, m_cartonId, "输入的箱号或者产品条码没有录入到系统中或者条码和工单配!") = False Then Exit Sub
                If IsCheckA(m_cartonId) = False Then
                    Exit Sub
                End If
                '20181009 田玉琳 增加生新打印
                ScanCommon.RePrintRecord(m_moid, m_cartonId)

            ElseIf TabControl1.SelectedTab.Name = TabPage3.Name Then
                weight = txtWeight3.Text.Trim
                Dim checkstr As String = CheckWeight(weight, txtUpLimit.Text, txtLowlimit.Text)
                If checkstr <> "" Then
                    MessageUtils.ShowError(checkstr)
                    txtWeight3.Focus()
                    txtWeight3.SelectAll()
                    Exit Sub
                End If
                If ScanCommon.IsTextBoxBlank(txtWeight3, "请输入箱称重重量!") = False Then Exit Sub
                If ScanCommon.IsWeight(txtWeight3, "请输入正确的箱重量格式为(XX.XXX)!") = False Then Exit Sub
                If ScanCommon.IsTextBoxBlank(txtOldBarCode, "请输入原产品条码!") = False Then Exit Sub
                If ScanCommon.IsTextBoxBlank(txtNewBarCode, "请输入新产品条码!") = False Then Exit Sub
                If ScanCommon.IsTextBoxBlank(txtPassword2, "请输入解锁密码!") = False Then Exit Sub
                If ScanCommon.IsOpenLock(txtPassword2, "没有解锁权限!") = False Then Exit Sub
                If ScanCommon.IsNotEqual(txtNewBarCode, txtOldBarCode, "新产品条码和旧产品条码不能相同!") = False Then Exit Sub
                If ScanCommon.IsExsitCarton(txtNewBarCode, m_moid, "输入的条码录入已经录入到系统中,不能替换!") = False Then Exit Sub
                If ScanCommon.IsNotExsitCarton(txtOldBarCode, m_moid, m_cartonId, "输入的条码没有录入到系统中或者条码和工单配!") = False Then Exit Sub
                '条码替换
                ScanCommon.UpdateCartonsn(txtNewBarCode.Text.Trim, txtOldBarCode.Text.Trim)
            End If
            If m_IsLinePrintFullCode = True Then
                PrintCarton(weight)
            End If
            SaveCartonWeight(m_cartonId, m_moid, weight)
            'If IsListCarton = True Then
            '    PrintCartonList(weight)
            '    lbMsg.Text = ""
            'Else
            '    PrintCarton(weight)
            'End If
            If RbAuto.Checked Then
                SetXMLNodeData("WeightComPar", txtComInfo.Text)
                SetXMLNodeData("WeightAuto", "Y")
            Else
                SetXMLNodeData("WeightAuto", "N")
            End If

            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmCartonRepeatPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub


#Region "函数"
    Private Sub PrintCarton(weight As String)
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(weight) '包装数量
        alist.Add(m_moid)  '工单
        printBarcode.PrintFullCartonWeight(m_cartonId, m_LabelNum, alist)
    End Sub

    '多个内箱打印外箱
    Private Sub PrintCartonList(weight As String)
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(weight) '包装数量
        '内箱数组
        Dim CartonList As New ArrayList
        If Not String.IsNullOrEmpty(Me.m_CartonIdOne) Then
            CartonList.Add(Me.m_CartonIdOne)
        End If
        If Not String.IsNullOrEmpty(Me.m_CartonIdTwo) Then
            CartonList.Add(Me.m_CartonIdTwo)
        End If
        If Not String.IsNullOrEmpty(Me.m_CartonIdTre) Then
            CartonList.Add(Me.m_CartonIdTre)
        End If
        If Not String.IsNullOrEmpty(Me.m_CartonIdFou) Then
            CartonList.Add(Me.m_CartonIdFou)
        End If

        printBarcode.PrintFullCartonWeightList(m_cartonId, CartonList, m_LabelNum, alist, Me.m_CodeRuleId)
    End Sub

    '根据产品条码获取外箱条码
    Private Function GetCartonId(ByVal Ppid As String) As String
        Dim CartonId As String = ""
        Dim o_strSql As New StringBuilder
        Dim dt As New DataTable
        Try
            o_strSql.Append("select a.Cartonid from m_Cartonsn_t a left join ")
            o_strSql.Append(" m_Carton_t b on b.Cartonid=a.Cartonid")
            o_strSql.Append(" where a.ppid='" & Ppid & "' and b.Moid='" & Me.m_moid & "'")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                CartonId = dt.Rows(0)!Cartonid.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlineWeightPrint", "GetCartonId", "sys")
        End Try
        Return CartonId
    End Function

    '获取编码原则
    Private Sub SetCodeRuleId()
        Me.m_CodeRuleId = ""
        Dim o_strSql As New StringBuilder
        Dim dt As New DataTable
        Try
            o_strSql.Append("select  CodeRuleID from m_PartPack_t where Partid='" & Me.m_partId & "' and packid in('C','N') AND Usey='Y' ")
            o_strSql.Append(" AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' ORDER BY qty desc ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)

            If dt.Rows.Count > 0 Then
                Me.m_CodeRuleId = dt.Rows(0)!CodeRuleID.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlineWeightPrint", "GetCartonId", "sys")
        End Try

    End Sub



    '校验是否进行了附属检查
    Private Function IsCheckA(ByVal cartionId As String) As Boolean
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            Dim Flag As String
            Dim Msg As String
            o_strSql.Append(" DECLARE @Msg nvarchar(200);DECLARE @Falg int;	")
            o_strSql.Append(" EXEC m_OnlinePrintCheckEan_P '" & cartionId & "', @Msg OUTPUT,  @Falg OUTPUT ")
            o_strSql.Append(" select @Msg,@Falg")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Flag = dt.Rows(0)(1).ToString
                If Flag = "0" Then
                    Msg = dt.Rows(0)(0).ToString
                    MessageBox.Show(Msg, "系统提示")
                    Return False
                End If
            End If
            Return True

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlineWeightPrint", "IsCheckA", "sys")
        End Try

    End Function

    '保存箱重量
    Private Sub SaveCartonWeight(ByVal CartonId As String, ByVal Moid As String, ByVal Weight As String)
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("delete m_OnlineWeightPrint_t where Cartonid='" & CartonId & "' ;")
            o_strSql.Append(" insert into m_OnlineWeightPrint_t(Cartonid,Moid,Weight,Userid,Intime) ")
            o_strSql.Append("values('" & CartonId & "','" & Moid & "','" & Weight & "','" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlineWeightPrint", "SaveCartonWeight", "sys")
        End Try
    End Sub

#End Region







    Private Sub txtWeight2_Leave(sender As Object, e As EventArgs) Handles txtWeight2.Leave
        Try
            If Not String.IsNullOrEmpty(txtWeight2.Text) AndAlso txtWeight2.Text.Length > 3 Then
                Dim s As String = Math.Round(CDbl(txtWeight2.Text), 3)

                If s.Contains(".") = True Then
                    Dim s1 = s.Split(".")(1).ToString.PadRight(3, "0")
                    txtWeight2.Text = s.Split(".")(0) & "." & s1
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("请输入正确的重量!")
        End Try
    End Sub
    Dim scanparsKey As String = "AUTOSCANPATS232" '扫描端口相关内容取得KEY
    Dim MachineType As String = "1"         '东莞机台
    Dim comname As String = ""
    Private Function GetRs232Pars() As String
        Dim result As String = ""
        Dim strSQL As String = ""

        strSQL = "  SELECT TEXT, isnull(MachineType,'1') MachineType FROM m_AutoScanBaseData_t WHERE [ITEMKEY] = '{0}' and VALUE = '{1}'"
        strSQL = String.Format(strSQL, scanparsKey, My.Computer.Name)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            result = dt.Rows(0)(0).ToString
            MachineType = dt.Rows(0)(1).ToString
        End If
        Return result
    End Function
    Private Sub Rs232Init()
        Try
            Dim values As String = m_Rs232Pars

            If values <> "" Then

                If values.Split("|").Length <> 5 Then
                    '  MessageUtils.ShowError("连接设备的扫描参数设置格式不正确！")
                    Exit Sub
                End If

                If Not RS232 Is Nothing Then
                    If RS232.IsOpen Then  '開啟
                        RS232.Close()
                        RS232.Dispose()
                    End If
                End If

                '  设置参数()
                RS232 = New SerialPort
                RS232.PortName = values.Split("|")(0)  '欲開啟的通訊埠
                RS232.BaudRate = values.Split("|")(1)  '通訊速度
                RS232.Parity = values.Split("|")(2)    '不发生奇偶校验位检查
                RS232.DataBits = values.Split("|")(3)  '資料位元設定值
                RS232.StopBits = values.Split("|")(4)  '停止位 

                Try
                    'SP_ReadData.DataReceived += SP_ReadData_DataReceived;
                    AddHandler RS232.DataReceived, AddressOf RS232_DataReceived
                    RS232.Open()

                    lbComDes.ForeColor = Color.Green
                    lbComDes.Text = "电子秤通讯端口已打开"
                    txtWeight.ReadOnly = True
                    txtWeight2.ReadOnly = True
                    txtWeight3.ReadOnly = True

                    'lblMessage.ForeColor = Color.Lime

                    'lblMessage.Text = "请先称重后扫描"
                Catch ex As Exception
                    lbComDes.ForeColor = Color.DarkRed
                    lbComDes.Text = ex.Message
                    txtWeight.ReadOnly = False
                    txtWeight2.ReadOnly = False
                    txtWeight3.ReadOnly = False

                    'MessageUtils.ShowError(ex.Message)
                    'SetMessage("Fail", ex.Message)
                    'SysMessageClass.WriteErrLog(ex, "BarCodeScan.SendMessageInit", "Load", "sys")
                End Try

                '  txtOnLineWeight.ReadOnly = True

            End If


        Catch ex As Exception
            lbComDes.ForeColor = Color.DarkRed
            lbComDes.Text = ex.Message
            txtWeight.ReadOnly = False
            txtWeight2.ReadOnly = False
            txtWeight3.ReadOnly = False
            'MessageUtils.ShowError(ex.Message)
            'SetMessage("Fail", ex.Message)
            'SysMessageClass.WriteErrLog(ex, "BarCodeScan.SendMessageInit", "Load", "sys")
            'MessageUtils.ShowError("没有打开RS232端口或没有连接对应设备！")
        End Try
    End Sub
#Region "公共接收端口指令数据方法函数"
    Dim WithEvents RS232 As SerialPort
    Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)

        Dim buffer() As Byte = Nothing
        Dim data() As Byte = New Byte(2048) {}
        Dim receiveCount As Integer = 0
        While (True)
            System.Threading.Thread.Sleep(20)
            If RS232.BytesToRead < 1 Then
                buffer = New Byte(receiveCount) {}
                Array.Copy(data, 0, buffer, 0, receiveCount)
                Exit While
            End If
            receiveCount += RS232.Read(data, receiveCount, RS232.BytesToRead)
        End While
        If receiveCount = 0 Then
            Return
        End If
        Dim msg As String = String.Empty
        msg = Encoding.ASCII.GetString(buffer)
        msg = msg.Replace("KG", "").Replace("kg", "").Trim()

        If msg.Contains(".") = True Then
            If msg.Split(".")(1).Length > 3 Then
                msg = msg.Split(".")(0) & "." & msg.Split(".")(1).ToString.Substring(0, 3)
            End If 
        End If

        SetCValues(txtWeight, msg)
        SetCValues(txtWeight2, msg)
        SetCValues(txtWeight3, msg)
        'SetCValues(LabResult, "称重成功，请继续扫描产品条码")
        'SetCValues(lblMessage, "称重重量：" + msg)

    End Sub
#End Region

    Private Sub SetCValues(ByVal TempC As Object, ByVal TValue As String)
        Dim obj_delegate As New ThreadControl(AddressOf SetControlValue)
        Me.Invoke(obj_delegate, TValue, TempC)
    End Sub
    Sub SetControlValue(ByVal TValue As String, ByVal TempC As Object)
        If TempC.GetType().Name = "TextBox" Then
            CType(TempC, TextBox).Text = TValue
            'ElseIf TempC.GetType().Name = "textBoxUL" Then
            '    CType(TempC, ULControls.textBoxUL).Text = TValue
        ElseIf TempC.GetType().Name = "ListBox" Then
            CType(TempC, ListBox).Items.Add(TValue)
        ElseIf TempC.GetType().Name = "Label" Then
            CType(TempC, Label).Text = TValue
        ElseIf TempC.GetType().Name = "CheckBox" Then
            CType(TempC, CheckBox).Checked = Convert.ToBoolean(TValue)
        Else
            TempC.Text = TValue
        End If
    End Sub
    ''' <summary>
    ''' 控制項賦值必須使用委託
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Delegate Sub ThreadControl(ByVal val As String, ByVal obj As Object)
    Private Function CheckWeight(ByVal Weight As String, ByVal UpLimit As String, ByVal LowLimit As String) As String

        Dim lblMessage As String = ""
        If Weight = "" Then
            lblMessage = "重量不能为空"
            Return lblMessage
        End If

        If Not IsNumeric(Weight) Then
            lblMessage = "重量格式不正确！"
            Return lblMessage
        End If

        If (UpLimit = "0" Or UpLimit = "") And (LowLimit = "0" Or LowLimit = "") Then
            Return ""
        End If

        If CDec(UpLimit) < CDec(LowLimit) Then
            Dim dec As Decimal = UpLimit
            UpLimit = LowLimit
            LowLimit = dec
        End If

        If CDec(Weight) < CDec(LowLimit) Or CDec(Weight) > CDec(UpLimit) Then
            Dim _ErrMsg As String = "重量" & Weight & ",超出标准重量,该产品重量上下限为(" & UpLimit & "-" & LowLimit & ")"
            lblMessage = _ErrMsg
            Return lblMessage
        End If
        Return lblMessage
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

    Private Sub btnSetCOM_Click(sender As Object, e As EventArgs) Handles btnSetCOM.Click
        Dim FrmOpenLock As New FrmSetLock
        FrmNewShareSetForm.vStationType = "P"
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then
            Dim FrmCOMSet As New FrmCOMSet()
            FrmCOMSet.ShowDialog()
            txtComInfo.Text = FrmCOMSet.txtCOMValue.Text.Trim
            If txtComInfo.Text.Trim <> "" Then
                ''自动扫描初始化
                m_Rs232Pars = GetRs232Pars()
                txtComInfo.Text = m_Rs232Pars
                Rs232Init()
                '   SetXMLNodeData("ComPar", txtComInfo.Text.Trim)
            End If
        End If


    End Sub


    Private Sub RadIsLinePrintFullCode_Click(sender As Object, e As EventArgs) Handles RadIsLinePrintFullCode.Click
        If RadIsLinePrintFullCode.Checked = True Then
            btnSetCOM.Visible = True
            txtWeight.ReadOnly = True
            txtWeight2.ReadOnly = True
            txtWeight3.ReadOnly = True
        Else
            btnSetCOM.Visible = False
            txtWeight.ReadOnly = False
            txtWeight2.ReadOnly = False
            txtWeight3.ReadOnly = False
        End If
    End Sub

    Private Sub RbManual_Click(sender As Object, e As EventArgs) Handles RbManual.Click
        If RbManual.Checked = True Then
            btnSetCOM.Visible = False
            txtWeight.ReadOnly = False
            txtWeight2.ReadOnly = False
            txtWeight3.ReadOnly = False
        Else
            btnSetCOM.Visible = True
            txtWeight.ReadOnly = True
            txtWeight2.ReadOnly = True
            txtWeight3.ReadOnly = True
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub txtWeight_Leave(sender As Object, e As EventArgs) Handles txtWeight.Leave
        Try
            If Not String.IsNullOrEmpty(txtWeight.Text) AndAlso txtWeight.Text.Length > 3 Then
                Dim s As String = Math.Round(CDbl(txtWeight.Text), 3)

                If s.Contains(".") = True Then
                    Dim s1 = s.Split(".")(1).ToString.PadRight(3, "0")
                    txtWeight.Text = s.Split(".")(0) & "." & s1
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("请输入正确的重量!")
        End Try
    End Sub
End Class