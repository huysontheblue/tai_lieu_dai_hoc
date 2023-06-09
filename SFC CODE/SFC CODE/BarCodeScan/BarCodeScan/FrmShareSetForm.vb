''功能說明：提供條碼掃描所需的基本資料
''開發人員：
''開發日期：2009/08/03
''修改日期：2009/11/03
'UPDATE:
'--2015-02-10   马锋    增加页面scanSetting，用于解决多页面同时扫描，扫描配置异常问题

Imports System.Data.SqlClient
Imports System.Text
Imports BarCodePrint
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Collections
Imports System.Xml
Imports System.IO
Imports MainFrame

Public Class FrmShareSetForm

    Dim Conn As New SysDataBaseClass
    Dim TimeStr As String
    Dim BcRule As String
    Dim TimeStyleSet As String
    Const ColZero As Integer = 0
    Dim Datet As New DateTime
    Dim IsReplaceFlag As String
    Dim ReplaceArray(100, 100) As String
    'Private frmParent As FrmNewStantPackScan
    Dim scanSetting As ScanSetting

    Shared m_StationType As String ''!=A---组装扫描、P---包装扫描i'

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String

    Dim IsInitLoadForm As Boolean = True '是否首次加载窗体 2018-03-13
    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _scanSetting As ScanSetting)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        scanSetting = _scanSetting

    End Sub

    Public Shared Property vStationType() As String

        Get
            Return m_StationType
        End Get
        Set(ByVal Value As String)
            m_StationType = Value
        End Set

    End Property

    Private Sub FrmSnSet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpSet.KeyPress, DtpDate.KeyPress, CboSupport.KeyPress

        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If
        'If sender.name.ToString = "CboMoid" Then
        '    CboMoid.DroppedDown = True
        '    If (Char.IsLower(e.KeyChar)) Then
        '        CboMoid.SelectedText = Char.ToUpper(e.KeyChar).ToString()
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Private Sub FrmSnSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.ActiveControl Is Nothing Then WorkStantOption.IsExitFlag = True
        If Me.ActiveControl.Name = "ButConfirm" Then WorkStantOption.IsExitFlag = False
    End Sub

    Private Sub FrmSnSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sqlstr As String = String.Empty

        TreePart.ExpandAll()
        Sqlstr = "select getdate() as nowtime"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Datet = CDate(dt.Rows(0)("nowtime").ToString)
        End If
        Me.DtpDate.Value = Datet.ToString("yyyy/MM/dd")
        Me.DtpTime.Value = Datet.ToString
        DtpSet.Value = Datet.ToString
        Me.TxtProductLot.Text = Datet.ToString("yyyyMMdd") & "01"

        Sqlstr = "SELECT A.Cusid,B.CusName  FROM" & _
                     " (SELECT DISTINCT Cusid FROM m_Mainmo_t WHERE ISNULL(Cusid,'')<>''" & _
                     " UNION " & _
                     " SELECT DISTINCT Cusid FROM m_PartContrast_t WHERE ISNULL(Cusid,'')<>'') A" & _
                     " INNER JOIN m_Customer_t B ON A.Cusid=B.CusID" & _
                     " ORDER BY A.Cusid"
        LoadDataToCob(Sqlstr, CboSupport) ''填充客戶
        mtxtMOid_TextChanged(Nothing, Nothing)

        InitScanSetFrom()
    End Sub

    Private Sub InitScanSetFrom() ''重復設置時保存上一次的設置記錄
        Dim xmlDocument As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDocument.Load(Application.StartupPath & "\ScanConfig.xml")
        Dim xmlnode As Xml.XmlNode
        xmlnode = xmlDocument.DocumentElement
        Me.CboSupport.Text = xmlnode.SelectSingleNode("cus").InnerText
        Me.mtxtMOid.Text = xmlnode.SelectSingleNode("mo").InnerText
        Me.CobLine.Text = xmlnode.SelectSingleNode("line").InnerText
        Me.DtpSet.Text = xmlnode.SelectSingleNode("bardate").InnerText ''
        Me.CobSitId.Text = xmlnode.SelectSingleNode("station").InnerText
    End Sub

    Private Function ContorlCheck() As Boolean '''' lrq   2007/01/10 ''''
        '连接到SAP
        If VbCommClass.VbCommClass.IsConSap = "N" Then
            If Me.CboSupport.Text = "" Then
                MessageUtils.ShowInformation("客戶名稱不能為空!")
                CboSupport.Focus()
                CboSupport.SelectAll()
                Return False
                Exit Function
            End If
        End If

        If CobLine.Text = "" Then
            MessageUtils.ShowInformation("线别不能為空!")
            CboSupport.Focus()
            CboSupport.SelectAll()
            Return False
            Exit Function
        End If


        If (String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            MessageBox.Show("工單編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.mtxtMOid.Focus()
            Return False
            Exit Function
        End If

        If Me.CobSitId.Text = "" Then
            MessageBox.Show("工站編號不能為空或該料號的工站資料未設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobSitId.Focus()
            CobSitId.SelectAll()
            Return False
            Exit Function
        End If

        'If Me.TxtCustomPart.Text = "" Then
        '    MessageBox.Show("資料未設置完整或工單編號不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        If -30 > DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) OrElse DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) > 60 Then
            MessageBox.Show("設置的時間不得偏離當前時間两個月!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        Else
            TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")
        End If
        TimeStr = Format(Me.DtpDate.Value, "yyyy/MM/dd")
        TimeStr = TimeStr + " " + Format(Me.DtpTime.Value, "HH:mm:ss")
        If TimeStr > Format(Datet, "yyyy/MM/dd HH:mm:ss") Then
            MessageBox.Show("您選擇的開始時間大於當前時間!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If WorkStantOption.IsMsCustType = "Y" And String.IsNullOrEmpty(cboCustType.Text) Then
            MessageBox.Show("微軟廠商來料請選擇來料類型!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        Return True

    End Function

#Region "Cbo客戶選擇事件"

    Private Sub CboSupport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSupport.SelectedIndexChanged

        'If VbCommClass.VbCommClass.Factory <> "BZLANTO" Then
        '    Me.mtxtMOid.Text = String.Empty
        '    TxtMotype.Clear()
        '    TxtCustomPart.Clear()
        '    TxtAvcPart.Clear()
        '    TxtMoQty.Clear()
        '    CobLine.Items.Clear()
        'End If
    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        CobName.Items.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            CobName.Items.Add(dt.Rows(index)(0).ToString & "(" & dt.Rows(index)(1).ToString & ")")
        Next
    End Sub

#End Region

    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCancel.Click

        WorkStantOption.IsExitFlag = True
        WorkStantOption.SnStyleStr1 = Nothing
        WorkStantOption.SnStyleStr2 = Nothing
        WorkStantOption.GflenStr = Nothing
        WorkStantOption.CheckStr = False

        If (Not scanSetting Is Nothing) Then
            scanSetting.IsExitFlag = True
            scanSetting.SnStyleStr1 = Nothing
            scanSetting.SnStyleStr2 = Nothing
            scanSetting.GflenStr = Nothing
            scanSetting.CheckStr = False
        End If

        Me.Close()

    End Sub

    '設置確定按鈕.
    Private Sub BnConFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConfirm.Click
        Dim Mread As SqlDataReader = Conn.GetDataReader("select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " & _
   " where b.tparent in('z09_','z0s_','z0t_','z0Y_') and userid='" & SysMessageClass.UseId & "' and ButtonID='" & CobLine.Text & "'")
        If Mread.HasRows = False Then
            MessageBox.Show("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mread.Close()
            Exit Sub
        End If
        Mread.Close()
        Conn.PubConnection.Close()
        ' /01/10 ''''
        'Dim Dr As SqlDataReader
        'Dim PubClass As New SysDataBaseClass
        ''Dim SqlStr As String
        'Dr = Nothing

        If ContorlCheck() = True Then
            getPartStyle()

            Dim SitIndex As String = Me.CobSitId.SelectedIndex
            If CobSitId.Items.Count <> 1 Then
                For i As Integer = 0 To Me.CobSitId.Items.Count - 1
                    If SitIndex = 0 Then
                        WorkStantOption.vPreStation = ""
                        If (Not scanSetting Is Nothing) Then
                            scanSetting.vPreStation = ""
                        End If
                    ElseIf i = SitIndex - 1 Then
                        WorkStantOption.vPreStation = CobSitId.Items(i).ToString.Split(" - ")(0)
                        If (Not scanSetting Is Nothing) Then
                            scanSetting.vPreStation = CobSitId.Items(i).ToString.Split(" - ")(0)
                        End If
                    End If
                Next
            Else
                WorkStantOption.vPreStation = ""
                If (Not scanSetting Is Nothing) Then
                    scanSetting.vPreStation = ""
                End If
            End If
            ModfiyLogInName()
        End If
    End Sub

#Region "保存设置内容"

    Private Sub ModfiyLogInName()

        Dim XmlDoc As New XmlDocument
        Try
            XmlDoc.Load(Application.StartupPath & "\ScanConfig.xml")  ''打開XML文件
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
        End Try
        File.SetAttributes(Application.StartupPath & "\ScanConfig.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes
        For Each xn As XmlNode In nodeList
            If xn.Name = "cus" Then
                xn.InnerText = Me.CboSupport.Text
                Continue For
            End If
            If xn.Name = "mo" Then
                xn.InnerText = Me.mtxtMOid.Text
                Continue For
            End If
            If xn.Name = "line" Then
                xn.InnerText = Me.CobLine.Text
                Continue For
            End If
            If xn.Name = "station" Then
                xn.InnerText = Me.CobSitId.Text
                Continue For
            End If
            If xn.Name = "bardate" Then
                xn.InnerText = Me.DtpSet.Text
                Continue For
            End If

        Next

        XmlDoc.Save(Application.StartupPath & "\ScanConfig.xml")

    End Sub

#End Region

    Private Sub DtpTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpTime.KeyPress

        If e.KeyChar = Chr(13) Then
            BnConFrm_Click(sender, e)
        End If

    End Sub

    Private Function FindNode(ByVal tnParent As TreeNode) As String
        If tnParent Is Nothing Then
            Return Nothing
        End If
        ''If tnParent.Text = strValue Then
        ''    Return tnParent
        ''End If

        Dim tnRet As String = String.Empty
        For Each tn As TreeNode In tnParent.Nodes
            'tnRet = FindNode(tn, strValue)
            'If tnRet IsNot Nothing Then
            '    Exit For
            'End If
            If tn.Checked = True Then
                tnRet = tn.Text
            End If
        Next

        Return tnRet
    End Function

    ''' <summary>
    ''' 功能描述：删除不可见字符。
    ''' </summary>
    ''' <param name="sourceString">原字符串</param>
    ''' <returns></returns>
    Public Shared Function DeleteUnVisibleChar(ByVal sourceString As String) As String
        Dim strBuilder As New System.Text.StringBuilder(131)
        'Dim aa() As Char
        'aa = sourceString.ToCharArray
        'For j As Integer = 0 To aa.Length - 1
        '    If aa(j) <> "" Then strBuilder.Append(aa(j))
        'Next
        ' ''  byte[] bytes = Convert.FromBase64String(s);
        ''byte[] data = Encoding.UTF8.GetBytes("哈哈23");
        ''            char[] c = Encoding.UTF8.GetChars(data);

        Dim aaa() As Byte = Encoding.UTF8.GetBytes(sourceString)
        ' ''  Dim cc As String = Convert.ToBase64String(sourceString)
        Dim uc() As Char = Encoding.UTF8.GetChars(aaa)
        For k As Integer = 0 To uc.Length - 1
            If Char.IsControl(uc(k)) = False Then
                strBuilder.Append(uc(k))
            End If
        Next

        'For i As Integer = 0 To sourceString.Length - 1
        '    Dim Unicode As Integer = Val(sourceString(i))
        '    Dim bb As String = Convert.ToChar(sourceString(i))
        '    If Unicode >= 16 Then
        '        strBuilder.Append(sourceString(i).ToString())
        '    End If
        'Next
        Return strBuilder.ToString()
    End Function

    Private Sub getPartStyle()  ''WorkStantOption
        'WorkStantOption.vstyleArray = Nothing
        Array.Clear(WorkStantOption.vstyleArray, 0, WorkStantOption.vstyleArray.Length)

        If (Not scanSetting Is Nothing) Then
            Array.Clear(scanSetting.vstyleArray, 0, scanSetting.vstyleArray.Length)
        End If

        Dim Sqlstring As New StringBuilder
        Dim Dr, DrPartPack As SqlDataReader  '''''DrStation
        Dim partTable As New NoSortHashtable.NoSortHashtable ''Hashtable
        ''Dim jj As New ArrayList
        Dim SqlStr As String
        Dim partArray(100) As String
        Dim strfalsg As String = ""
        Dim orderStr As String = Me.TxtAvcPart.Text
        Dim sPackIDFlag As String = ""  ''m_PartPack_t 裡面的PackLink欄位
        Dim PubClass, PubClassStation, DAL As New SysDataBaseClass

        Dim k As Integer = 1
        Dim j As Integer = 1
        Dim styleArray(100, 100) As String
        Dim tnRet As String = Me.TxtAvcPart.Text

        '獲取該料號的PackId   2011-05-10
        Dim Pplink As String
        SqlStr = "select partid,packid,packlink,qty from m_PartPack_t where partid='" & tnRet & "' and usey='Y'"
        DrPartPack = PubClass.GetDataReader(SqlStr)
        If DrPartPack.HasRows Then
            While DrPartPack.Read

                sPackIDFlag = DrPartPack("packid").ToString
                Pplink = DrPartPack("packlink").ToString
                If sPackIDFlag = "C" Then
                    WorkStantOption.PartPackQty = DrPartPack("qty")
                End If
            End While
        End If
        DrPartPack.Close()
        Conn.PubConnection.Close()
        Dim CartpartCount As Integer = 0 '料件總數 

        If Me.TreePart.Nodes.Count = 0 Then
            'Sqlstring.Append("select * from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='S'   and e.partid='" & tnRet & "'  and e.usey='Y' ")
            'Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'   and e.partid='" & tnRet & "'  and e.usey='Y' ")

            'If tnRet <> "L01H1018-DT-R-P-T" Then
            '    Sqlstring.Append(" select e.partid,e.coderuleid from m_RPartStationD_t a join m_PartPack_t e on a.TPartid=e.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "' and a.ppartid='" & tnRet & "' and  a.state='1' AND e.usey = 'Y' and  stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' ")
            'Else
            '    Sqlstring.Append(" select e.partid,e.coderuleid from m_RPartStationD_t a join m_PartPack_t e on a.TPartid=e.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where 1=1 AND E.CodeRuleID <> 'B346' AND e.Usey='Y' and a.ppartid='" & tnRet & "'  AND e.packid IN ('K' ,'S') and  a.state='1' and  stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' ")
            'End If
            If IsPartNeedExcludeCodeRule(tnRet) Then
                Sqlstring.Append(" SELECT ppartid AS partid, coderuleid FROM V_m_RPartStationDStyle_t WHERE PPartid='" & tnRet & "' AND stationid ='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "'")
            Else
                Sqlstring.Append(" select e.partid,e.coderuleid from m_RPartStationD_t a join m_PartPack_t e on a.TPartid=e.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "' and a.ppartid='" & tnRet & "' and  a.state='1' AND e.usey = 'Y' and  stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' ")
            End If
        Else

            For Each tn As TreeNode In Me.TreePart.Nodes
                strfalsg = FindNode(tn)
                If strfalsg = "" Then
                    MessageBox.Show("請選擇需要掃描的料號")
                    Exit Sub
                End If

                'If k = Me.TreePart.Nodes.Count And k <> 1 Then
                '    Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'   and e.partid='" & strfalsg & "'  and e.usey='Y' " & vbNewLine)
                '    CartpartCount = CartpartCount + 1
                If k = 1 And k = Me.TreePart.Nodes.Count Then
                    'add by hgd 20191106 添加部件条码允许 DisorderTypeId的类型
                    Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'  and e.partid='" & tnRet & "'  and e.usey='Y' union all" & vbNewLine)
                    Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.partid='" & strfalsg & "'  and e.usey='Y' and (e.packid='" & sPackIDFlag & "' or e.DisorderTypeId='" & sPackIDFlag & "') " & vbNewLine)
                    CartpartCount = CartpartCount + 2
                ElseIf k = 1 And k <> Me.TreePart.Nodes.Count Then
                    Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'   and e.partid='" & tnRet & "'  and e.usey='Y' union all" & vbNewLine)

                    ' add by hgd 20191121 添加部件条码支持DisorderTypeId 类型
                    Sqlstring.Append(" select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where  (e.packid='" & sPackIDFlag & "' or e.DisorderTypeId='" & sPackIDFlag & "')  and e.partid='" & strfalsg & "'  and e.usey='Y' " & vbNewLine)
                    'Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'  and e.partid='" & strfalsg & "'  and e.usey='Y' union all" & vbNewLine)
                    CartpartCount = CartpartCount + 2
                Else
                    ' add by hgd 20191121 添加部件条码支持DisorderTypeId 类型
                    Sqlstring.Append(" union all select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where (e.packid='" & sPackIDFlag & "' or e.DisorderTypeId='" & sPackIDFlag & "')   and e.partid='" & strfalsg & "'  and e.usey='Y' " & vbNewLine)
                    'Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'  and e.partid='" & strfalsg & "'  and e.usey='Y' union all" & vbNewLine)
                    CartpartCount = CartpartCount + 1
                End If
                k = k + 1

                'tnRet = tnRet & "','" & strfalsg
                'orderStr = orderStr & "," & strfalsg
                ''If tnRet IsNot Nothing Then
                ''    Exit For
                ''End If
            Next
        End If
        Dr = Conn.GetDataReader(Sqlstring.ToString)
        ''Dr = Conn.GetDataReader("select * from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='S'   and e.partid in('" & tnRet & "')   and e.usey='Y' order by charindex(partid,'" & orderStr & "')")
        ''''''''''''''''2009/10/15
        ''Dr = Conn.GetDataReader("select * from m_RPartStationD_t a  join m_PartPack_t e on e.partid=a.tpartid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='S'  and a.ppartid='" & TxtAvcPart.Text.Trim & "' and a.state='1' and a.stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "'  and e.usey='Y' order by a.scanorderid")
        ''''''''''''''''''
        ' Dr = Conn.GetDataReader("select * from m_RPartStationD_t where ppartid='" & TxtAvcPart.Text.Trim & "' and state='1' and stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' order by scanorderid")
        If Dr.HasRows Then
            While Dr.Read
                'tempStr = Dr!TPartid
                'partStr = partStr & IIf(partStr = "", tempStr, "," & tempStr)
                partTable.Add(j & "|" & Dr!partid, Dr!coderuleid)
                j = j + 1
            End While
            WorkStantOption.vStandMaxStaIndex = j - 1
            If (Not scanSetting Is Nothing) Then
                scanSetting.vStandMaxStaIndex = j - 1
            End If
            '' partArray = partStr.Split(",")
            Dr.Close()
            Conn.PubConnection.Close()
        Else
            Dr.Close()
            Conn.PubConnection.Close()
            ''  Return partArray
            MessageBox.Show("該站點沒有設置需要掃描的部件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim i As Integer = 1
        If CartpartCount > partTable.Keys.Count Then
            MessageBox.Show("料號未設置打印參數！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            For Each str As String In partTable.Keys


                ''*************************************************
                ''  SqlStr = "declare @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute [m_StyleShow_PartArrayStat_p]'" & str.Split("|")(1).ToString & "','" & Me.CboMoid.Text & "','" & Me.TxtAvcPart.Text & "','" & partTable(str) & "','" & WorkStantOption.vStandId & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"
                SqlStr = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                         " EXECUTE m_StyleShow_p_AssembleSta_A '" & str.Split("|")(1).ToString & "','" & partTable(str) & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                         " SELECT @SnStyle1,@SnStyle2,@Gflen"
                ''************************************************************
                Dr = Conn.GetDataReader(SqlStr & ";SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," &
                " isnull(IsPrtPacking,'') IsPrtPacking,ISNULL(IsOnlinegenCartonid,'') IsOnlinegenCartonid,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle, " &
                " isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame, " &
                " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct,isnull(IsCheckLink,'N') IsCheckLink," &
                " ISNULL(IsSamePacking,'N') AS IsSamePacking,isnull(IsLinePrintFullCode,'N') IsLinePrintFullCode,isnull(LabelNum,'N') LabelNum, IsMainBarcode," &
                " isnull(IsLineWeight,'N') IsLineWeight,UpLimitWeight,LowLimitWeight,isnull(IsPpidLineWeight,'N') IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight,BarePpidUpLimitWeight,BarePpidLowLimitWeight, " &
                " isnull(RepeatPara,'') RepeatPara,ISNULL(IsOnlineWorkPrint,'N') IsOnlineWorkPrint,ISNULL(IsNotCaseSensitive,'N') IsNotCaseSensitive,IsScanN,ScanNumber " &
                " FROM m_RPartStationD_t WHERE " &
                " PPartid='" & TxtAvcPart.Text & "' and TPartid='" & str.Split("|")(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "'  and State=1")
                'and IsMainBarcode='Y' remove by cq 20180425
                '增加父料号查询条件

                If Dr.HasRows Then
                    While Dr.Read()
                        styleArray(i, 0) = DeleteUnVisibleChar(Dr.GetString(0)) ''樣式一
                        styleArray(i, 1) = DeleteUnVisibleChar(Dr.GetString(1)) ''樣式二   
                        styleArray(i, 2) = DeleteUnVisibleChar(Dr.GetString(0).ToString).Length ''Dr.GetString(2) ''固定長度
                        styleArray(i, 3) = ReplaceArray(i, 2) ''子條碼名稱
                        styleArray(i, 4) = str ''子料號
                        ReplaceArray(i, 1) = str ''子料號
                    End While
                    If Dr.NextResult Then
                        While Dr.Read
                            styleArray(i, 5) = Dr!IsUsb.ToString
                            WorkStantOption.ScanPalletCheck = IIf(Dr("IsScanPallet").ToString = "Y", True, False)
                            WorkStantOption.CustPartCheck = IIf(Dr("IsCustPart").ToString = "Y", True, False)
                            WorkStantOption.PrtPackingCheck = IIf(Dr("IsPrtPacking").ToString = "Y", True, False)
                            WorkStantOption.IsOnlineGenCartionID = IIf(Dr("IsOnlinegenCartonid").ToString = "Y", True, False)
                            WorkStantOption.PrtPalletCheck = IIf(Dr("IsPrtPallet").ToString = "Y", True, False)

                            WorkStantOption.vReadPCB = Dr("IsReadPCB").ToString = "Y"
                            WorkStantOption.vWritePCB = Dr("IsWritePCB").ToString = "Y"

                            'add by hgd 2018-04-03是否打印制程外箱
                            WorkStantOption.IsOnlineWorkPrint = IIf(Dr("IsOnlineWorkPrint").ToString = "Y", True, False)

                            WorkStantOption.vCartonSame = Dr("IsCartonSame").ToString
                            WorkStantOption.vPalletSame = Dr("IsPalletSame").ToString

                            'add by hgd 2019-10-29 主条码是否唯一，仅取主料号设置
                            WorkStantOption.vProductSame = IIf(str.Split("|")(0).ToString = 1, Dr("IsAllowRe").ToString, "Y")
                            'WorkStantOption.vProductSame = Dr("IsAllowRe").ToString
                            WorkStantOption.vPackType = Dr("IsPackType").ToString
                            WorkStantOption.vPPackingProduct = Dr("IsPPackingProduct").ToString
                            WorkStantOption.vSamePacking = Dr("IsSamePacking").ToString
                            'WorkStantOption.CodeRuleID = Dr("CodeRuleID").ToString
                            '2016-04-26 田玉琳
                            WorkStantOption.IsLinePrintFullCode = IIf(Dr("IsLinePrintFullCode").ToString = "Y", True, False)
                            WorkStantOption.LabelNum = Dr("LabelNum").ToString
                            WorkStantOption.IsLineWeight = IIf(Dr("IsLineWeight").ToString = "Y", True, False)
                            WorkStantOption.IsPpidLineWeight = IIf(Dr("IsPpidLineWeight").ToString = "Y", True, False)
                            'add by hgd 2018-05-31 重量上下限
                            WorkStantOption.UpLimitWeight = Dr("UpLimitWeight").ToString
                            WorkStantOption.LowLimitWeight = Dr("LowLimitWeight").ToString

                            WorkStantOption.PpidUpLimitWeight = Dr("PpidUpLimitWeight").ToString
                            WorkStantOption.PpidLowLimitWeight = Dr("PpidLowLimitWeight").ToString

                            WorkStantOption.BarePpidUpLimitWeight = DbOperateUtils.DBNullToStr(Dr("BarePpidUpLimitWeight").ToString)
                            WorkStantOption.BarePpidLowLimitWeight = DbOperateUtils.DBNullToStr(Dr("BarePpidLowLimitWeight").ToString)
                            If Not String.IsNullOrEmpty(WorkStantOption.BarePpidLowLimitWeight) Then
                                WorkStantOption.IsBarePpidLineWeight = True
                            Else
                                WorkStantOption.IsBarePpidLineWeight = False
                            End If
                            WorkStantOption.IsNotCaseSensitive = Dr("IsNotCaseSensitive").ToString
                            'add 20190909 拼接扫描多次
                            WorkStantOption.ScanNumber = Val(Dr("ScanNumber").ToString)
                            WorkStantOption.IsScanN = Dr("IsScanN").ToString
                            WorkStantOption.IsCheckLink = Dr("IsCheckLink").ToString

                            Select Case i
                                Case 1
                                    WorkStantOption.vRepeatStyle = Dr("RepeatStyle").ToString
                                    WorkStantOption.vRepeatPara = Dr("RepeatPara").ToString 'cq20171030, 增加校验条码功能
                                Case 2
                                    WorkStantOption.vRepeatParaChild1 = Dr("RepeatPara").ToString 'cq20171030, 增加校验条码功能
                                    WorkStantOption.vRepeatStyleChild1 = Dr("RepeatStyle").ToString 'cq20171030, 增加校验条码功能
                                Case Else
                            End Select

                        End While
                    End If
                    i = i + 1
                Else
                    MessageBox.Show("该料号" & str.Split("|")(1).ToString & "未设置编码原则...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dr.Close()
                Dr.Dispose()
                Conn.PubConnection.Close()
            Next
        End If

        Array.Copy(styleArray, WorkStantOption.vstyleArray(), styleArray.Length)
        Array.Copy(ReplaceArray, WorkStantOption.vmReplaceArray(), ReplaceArray.Length)

        WorkStantOption.vStandIndex = CobSitId.SelectedIndex + 1
        WorkStantOption.MoidStr = Me.mtxtMOid.Text
        WorkStantOption.MoidqtyStr = Me.TxtMoQty.Text

        If CboSupport.Text <> "" Then
            WorkStantOption.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
        End If

        WorkStantOption.PartidStr = Me.TxtAvcPart.Text
        WorkStantOption.MoCustStr = Me.CboSupport.Text
        ''WorkStantOption.DpetNameStr = LabDept.Text
        WorkStantOption.LineStr = Me.CobLine.Text
        '' WorkStantOption.LengthStr = LabSnLen.Text
        WorkStantOption.TimeStr = TimeStr
        'WorkStantOption.PrintPort = SysMessageClass.PrinterPort
        WorkStantOption.vStandId = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)
        WorkStantOption.vStandName = CobSitId.Text.Substring(InStr(CobSitId.Text, "-"))
        WorkStantOption.IsExitFlag = False
        WorkStantOption.CustIdString = Me.CboSupport.Text
        WorkStantOption.vProductLot = Me.TxtProductLot.Text
        WorkStantOption.MsCustCodeType = String.Empty
        If WorkStantOption.IsMsCustType = "Y" Then
            WorkStantOption.MsCustCodeType = cboCustType.Text.Substring(0, InStr(cboCustType.Text, "-") - 1)
        End If

        'WorkStantOption.TTPackQty = GetPackQtyFromTT(Me.TxtAvcPart.Text)'不需要 邓炯 20181227
        WorkStantOption.TTPackQty = 0
        Me.Close()
    End Sub

    Private Function IsPartNeedExcludeCodeRule(ByVal strPartID As String) As Boolean
        Dim lsSQL As String = String.Empty
        IsPartNeedExcludeCodeRule =False

        lsSQL = "SELECT 1  FROM m_RPartStationDExRule_t WHERE Partid ='" & strPartID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsPartNeedExcludeCodeRule =  True
            Else
                IsPartNeedExcludeCodeRule = False
            End If
        End Using
        Return IsPartNeedExcludeCodeRule
    End Function
    'Private Function GetPackQtyFromTTByPPartID(ByVal strPPartID As String) As String
    '    Dim lssql As String = ""
    '    Dim o_ds As New DataSet
    '    Try

    '        lssql = "SELECT IMA1027  FROM " & VbCommClass.VbCommClass.Factory & ".Ima_File WHERE IMA01='" & strPPartID & "'"
    '        o_ds = DBUtility.DbOracleHelperSQL.Query(lssql)

    '        If Not IsNothing(o_ds) AndAlso o_ds.Tables.Count > 0 AndAlso (Not IsNothing(o_ds.Tables(0))) AndAlso o_ds.Tables(0).Rows.Count > 0 Then
    '            GetPackQtyFromTTByPPartID = DbOperateUtils.DBNullToStr(o_ds.Tables(0).Rows(0).Item(0))
    '        Else
    '            GetPackQtyFromTTByPPartID = ""
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub CobSitId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobSitId.KeyPress

        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If

    End Sub


    Private Sub CobSitId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobSitId.SelectedIndexChanged

        Me.TreePart.Nodes.Clear()
        LoadDataToTreeView()

    End Sub

    '加載treeview數據
    Private Sub LoadDataToTreeView()
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtable As New DataTable
        Dim dStaView As New DataView
        Dim dScanView As New DataView
        Dim node As TreeNode = Nothing
        Dim SqlStr As String
        If CobSitId.SelectedIndex = -1 Then
            Exit Sub
        End If
        '加載明細子節點103-006024-04A
        SqlStr = "select  tparttext,TPartid,scanorderid,isnull(ReplaceID,'') ReplaceID,ismainbarcode from m_RPartStationD_t where Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and state='1' and PPartid='" & Me.TxtAvcPart.Text & "'  order by StaOrderid ASC"
        ''SqlStr = "select  tparttext,TPartid,scanorderid,isnull(ReplaceID,'') ReplaceID from m_RPartStationD_t where Stationid='A00001' and state='1' and PPartid='103-006026-07A' and ismainbarcode='N' order by StaOrderid ASC"
        dtable = DbOperateUtils.GetDataTable(SqlStr)
        dStaView = New DataView(dtable)
        dScanView = New DataView(dtable)
        If dtable.Rows.Count <> 0 Then
            For i As Int16 = 0 To dStaView.Count - 1
                ReplaceArray(i + 1, 1) = dStaView.Item(i)(1).ToString ''默認料號
                ''ReplaceArray(i, 2) = "主條碼" ''條碼名稱
                ReplaceArray(i + 1, 2) = dStaView.Item(i)(0).ToString ''條碼名稱
                ReplaceArray(i + 1, 3) = dStaView.Item(i)(2).ToString ''站點順序
                If UCase(dStaView.Item(i)(4).ToString) = "Y" Then
                    Continue For
                End If
                Dim node1 As TreeNode = New TreeNode(dStaView.Item(i)(0).ToString)
                TreePart.Nodes.Add(node1)
                node1.Checked = True
                node1.Tag = "1"

                Dim node3 As TreeNode
                node3 = New TreeNode(dStaView.Item(i)(1).ToString)
                node3.Tag = dStaView.Item(i)(2).ToString
                node3.Checked = True
                node1.Nodes.Add(node3)
                '' node1.Tag = dStaView.Item(i)(0).ToString.Trim
                'node.Nodes.Add(node1)
                Dim dtable1 As New DataTable
                SqlStr = "select a.Tpartid mTpartid,a.tparttext,b.TPartid,a.scanorderid from m_RPartStationD_t a left join m_RPartStationT_t b on a.ReplaceID=b.ReplaceID where a.TPartid='" & dStaView.Item(i)(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and state='1' and b.replaceid='" & dStaView.Item(i)(3).ToString & "' and isreplaceable='Y'"
                dtable1 = Conn.GetDataTable(SqlStr)

                For j As Int16 = 0 To dtable1.Rows.Count - 1
                    Dim node2 As TreeNode
                    node2 = New TreeNode(dtable1.Rows(j)(2).ToString.Trim)
                    node2.Tag = dtable1.Rows(j)(3).ToString.Trim
                    node1.Nodes.Add(node2)
                Next
                dtable1.Dispose()
            Next
        End If
        '' TreePart.Nodes.Add(node1)
        TreePart.ExpandAll()

        'dStaView.Dispose()
        'dScanView.Dispose()
        'dtable.Dispose()
        'Conn.PubConnection.Close()
        'Conn = Nothing
    End Sub

    Private Sub TreePart_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreePart.NodeMouseClick
        If e.Node.Tag = "1" Then
            e.Node.Checked = True
            Exit Sub
        Else
            If e.Node.Checked = True Then

                For i As Integer = 0 To e.Node.Parent.Nodes.Count - 1
                    If e.Node.Parent.Nodes.Item(i).Text <> e.Node.Text Then
                        e.Node.Parent.Nodes.Item(i).Checked = False
                    End If
                Next
            Else
                If e.Node.Parent.Nodes.Count = 1 Then
                    e.Node.Checked = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub CobLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobLine.KeyPress

        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If

    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery
            frmMOQuery = New FrmMOQuery(Me.mtxtMOid, "")
            'update by hgd 2018-01-29都不按客户带出工单
            'If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
            '    frmMOQuery = New FrmMOQuery(Me.mtxtMOid, "")
            'Else
            '    frmMOQuery = New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            'End If

            If frmMOQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
                mtxtMOid_TextChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged

        If Me.IsInitLoadForm = True Then
            Me.IsInitLoadForm = False
            Exit Sub
        End If
        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader = Nothing
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        CobLine.Items.Clear()
        CobLine.Text = ""
        CobSitId.Text = ""
        Me.CobSitId.Items.Clear()
        Me.cboCustType.Text = ""
        Me.cboCustType.Items.Clear()
        For Each text As Control In GroupShow.Controls
            If TypeOf text Is ULControls.textBoxUL Then
                text.Text = ""
                Me.TreePart.Nodes.Clear()
            End If
        Next

        If VbCommClass.VbCommClass.Factory = "BZLANTO" Then '根据单号自动查找客户 hzf 2016-11-16 13:46:59
            SqlStr = "select Cusid from m_Mainmo_t where moid='" & mtxtMOid.Text & "'"
            PubDataReader = PubClass.GetDataReader(SqlStr)
            If PubDataReader.HasRows Then
                While PubDataReader.Read()
                    Me.CboSupport.SelectedIndex = Me.CboSupport.FindString(PubDataReader("Cusid").ToString)
                End While
            End If
            PubDataReader.Close()
            PubClass.PubConnection.Close()
        End If
        If (Not String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            Try
                If VbCommClass.VbCommClass.Factory = "BZLANTO" Then 'hzf 2016-11-16 14:43:58 BZ扫描设置读取全部订单不区分客户代码
                    SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,d.mscusttype,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink,a.Cusid  from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid in('S','C','N') and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and e.usey='Y'"
                Else
                    SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,d.mscusttype,f.flen,f.coderuleid,a.lineid, " &
                        " e.packid,e.packlink,a.Cusid+'('+g.CusName+')' as Cusid  from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid " &
                        " join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid " &
                        " join M_SnRuleM_t f on e.coderuleid=f.coderuleid left join  m_Customer_t g on g.CusID=a.Cusid  where e.packid in('S','C','N') " &
                        " and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and isnull(a.profitcenter,'') = '" & VbCommClass.VbCommClass.profitcenter & "'  and e.usey='Y'"
                    'SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,d.mscusttype,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink  from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid in('S','C','N') and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and a.Cusid='" & CboSupport.Text.Split("(")(0) & "' and e.usey='Y'"
                End If
                PubDataReader = PubClass.GetDataReader(SqlStr)
                Dim strLine As String = ""
                Dim strCusid As String = ""
                Dim strms As String = ""
                If PubDataReader.HasRows Then
                    While PubDataReader.Read()
                        DeptStr = PubDataReader("deptid").ToString
                        WorkStantOption.DpetId = PubDataReader("deptid").ToString
                        If (Not scanSetting Is Nothing) Then
                            scanSetting.DpetId = PubDataReader("deptid").ToString
                        End If
                        Me.TxtMoQty.Text = PubDataReader("moqty").ToString
                        Me.TxtMotype.Text = PubDataReader("motype").ToString
                        Me.TxtAvcPart.Text = PubDataReader("partid").ToString
                        Me.TxtCustomPart.Text = PubDataReader("custpart").ToString
                        factoryidstr = PubDataReader("Factory").ToString
                        BcRule = PubDataReader("coderuleid").ToString
                        CobLine.Text = PubDataReader("lineid").ToString
                        strLine = PubDataReader("lineid").ToString
                        strCusid = PubDataReader("Cusid").ToString
                        CboSupport.Text = strCusid
                        If strCusid = "5Q" Then
                            strms = PubDataReader("mscusttype").ToString
                        End If
                        'If CboSupport.Text.Split("(")(0) = "5Q" Then
                        '    strms = PubDataReader("mscusttype").ToString
                        'End If
                        WorkStantOption.BcRuleid = BcRule
                        WorkStantOption.IsMsCustType = strms

                        If (Not scanSetting Is Nothing) Then
                            scanSetting.BcRuleid = BcRule
                        End If
                    End While
                End If
                PubDataReader.Close() ''and stationtype " & StationStyle & "'P'
                PubClass.PubConnection.Close()
                Dim StationStyle As String = IIf(m_StationType = "P", "=", "!=")

                '"' and factoryid='" & factoryidstr &
                SqlStr = "select lineid from Deptline_t where deptid='" & DeptStr & "'  and usey='Y' order by lineid" & vbNewLine & "select distinct b.stationid,b.stationname,a.staorderid,a.asny from m_RPartStationD_t a join" & _
                " m_Rstation_t b on a.stationid=b.stationid where ppartid='" & TxtAvcPart.Text & "' and tpartid='" & TxtAvcPart.Text & "'  and state='1' and isnull(ScanY,'Y')='Y'    order by staorderid"
                PubDataReader = PubClass.GetDataReader(SqlStr)
                Me.CobLine.Items.Clear()
                Me.CobSitId.Items.Clear()
                While PubDataReader.Read
                    Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
                End While

                PubDataReader.NextResult()

                If PubDataReader.HasRows Then
                    While PubDataReader.Read
                        If UCase(m_StationType) = "A" And InStr(PubDataReader("stationid").ToString, "P") > 0 Then
                            Continue While
                        End If
                        Me.CobSitId.Items.Add(PubDataReader("stationid").ToString & " - " & PubDataReader("stationname").ToString)

                        WorkStantOption.vSq = PubDataReader("asny").ToString
                        If (Not scanSetting Is Nothing) Then
                            scanSetting.vSq = PubDataReader("asny").ToString
                        End If
                    End While
                End If
                '微軟廠商來料
                PubDataReader.Close()
                PubClass.PubConnection.Close()
                If WorkStantOption.IsMsCustType = "Y" Then
                    SqlStr = " select value,text   from m_BaseData_t where itemkey='MSCustCodeType' and status='1'order by sort "
                    PubDataReader = PubClass.GetDataReader(SqlStr)
                    If PubDataReader.HasRows Then
                        While PubDataReader.Read
                            Me.cboCustType.Items.Add(PubDataReader("value").ToString & "-" & PubDataReader("text").ToString)
                        End While
                    End If
                End If


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
                'Add by hgd 2018-03-01 亚马逊扫描工站编码，不用选择工站
                CobSitId.Enabled = True
                'L6LU2003-CS-H
                If strCusid = "6L(AMAZON)" AndAlso TxtAvcPart.Text.Contains("L6LU2003-CS-H") Then
                    CobSitId.SelectedIndex = -1
                    CobSitId.Enabled = False

                    Dim frmScanStation As New FrmScanStation(Me.mtxtMOid.Text)
                    If frmScanStation.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        CobSitId.Text = frmScanStation.StationId
                    End If

                End If

                PubDataReader.Close()
                PubClass.PubConnection.Close()
                PubClass = Nothing
            Catch ex As Exception
                If (PubDataReader.IsClosed = False) Then
                    PubDataReader.Close()
                End If

                If (PubClass.PubConnection.State = ConnectionState.Open) Then
                    PubClass.PubConnection.Close()
                End If
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMoid_textChanged", "sys")
                MessageBox.Show("工单信息加载异常")
                Exit Sub
            End Try
        End If
    End Sub
End Class

Namespace NoSortHashtable
    ' 
    ''' <summary> 
    ''' Summary description for NoSortedHashtable. 
    ''' </summary> 
    Public Class NoSortHashtable
        Inherits Hashtable
        Private m_keys As New ArrayList()

        Public Sub New()
        End Sub


        Public Overloads Overrides Sub Add(ByVal key As Object, ByVal value As Object)
            MyBase.Add(key, value)
            m_keys.Add(key)
        End Sub

        Public Overloads Overrides ReadOnly Property Keys() As ICollection
            Get
                Return m_keys
            End Get
        End Property

        Public Overloads Overrides Sub Clear()
            MyBase.Clear()
            m_keys.Clear()
        End Sub

        Public Overloads Overrides Sub Remove(ByVal key As Object)
            MyBase.Remove(key)
            m_keys.Remove(key)
        End Sub
        Public Overloads Overrides Function GetEnumerator() As IDictionaryEnumerator
            Return MyBase.GetEnumerator()
        End Function

    End Class
End Namespace
