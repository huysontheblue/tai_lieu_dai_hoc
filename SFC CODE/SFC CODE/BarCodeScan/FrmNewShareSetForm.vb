''功能說明：提供條碼掃描所需的基本資料
''開發人員：马锋
''開發日期：2015/04/02
''修改日期：2015/04/02
'UPDATE:
'--2015-02-10   马锋    增加页面scanSetting，用于解决多页面同时扫描，扫描配置异常问题
'--扫描

Imports System.Data.SqlClient
Imports System.Text
Imports BarCodePrint
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Collections
Imports System.Xml
Imports System.IO
Imports MainFrame
Imports SysBasicClass

Public Class FrmNewShareSetForm

    Dim Conn As New SysDataBaseClass
    Dim TimeStr As String
    Dim BcRule As String
    Dim TimeStyleSet As String
    Const ColZero As Integer = 0
    Dim Datet As New DateTime
    Dim IsReplaceFlag As String
    Dim ReplaceArray(15, 5) As String
    Dim scanSetting As ScanSetting
    Dim IsPackType As String
    Dim IsPrtSelf As String
    Dim CodeRuleIDFix As String
    Shared m_StationType As String ''!=A---组装扫描、P---包装扫描i'

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
    End Sub

    Private Sub FrmSnSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl Is Nothing Then scanSetting.IsExitFlag = True
        If Me.ActiveControl.Name = "ButConfirm" Then scanSetting.IsExitFlag = False

    End Sub

    Private Sub FrmSnSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sqlstr As String = String.Empty
        Try
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
            InitScanSetFrom()
        Catch ex As Exception
        End Try
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

    Private Function ContorlCheck() As Boolean ''

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
            MessageUtils.ShowInformation("工單編號不能為空!")
            Me.mtxtMOid.Focus()
            Return False
            Exit Function
        End If

        If Me.CobSitId.Text = "" Then
            MessageUtils.ShowInformation("工站編號不能為空或該料號的工站資料未設置!")
            CobSitId.Focus()
            CobSitId.SelectAll()
            Return False
            Exit Function
        End If

        TimeStr = Format(Me.DtpDate.Value, "yyyy/MM/dd")
        TimeStr = TimeStr + " " + Format(Me.DtpTime.Value, "HH:mm:ss")
        If TimeStr > Format(Datet, "yyyy/MM/dd HH:mm:ss") Then
            MessageUtils.ShowInformation("您選擇的開始時間大於當前時間!")
            Return False
        End If

        'update by 2017-08-21 不限制条码日期
        TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")
        'If DateDiff(DateInterval.Month, Me.DtpSet.Value, Datet) > 6 Then
        '    MessageUtils.ShowInformation("設置的時間不得偏離當前時間六個月!")
        '    Return False
        '    Exit Function
        'Else
        '    TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")
        'End If

        Return True
    End Function

#Region "Cbo客戶選擇事件"

    Private Sub CboSupport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSupport.SelectedIndexChanged
        'Me.mtxtMOid.Text = String.Empty
        'TxtMotype.Clear()
        'TxtCustomPart.Clear()
        'TxtAvcPart.Clear()
        'TxtMoQty.Clear()
        'CobLine.Items.Clear()
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
        scanSetting.IsExitFlag = True
        scanSetting.SnStyleStr1 = Nothing
        scanSetting.SnStyleStr2 = Nothing
        scanSetting.GflenStr = Nothing
        scanSetting.CheckStr = False

        Me.Close()
    End Sub

    '設置確定按鈕.
    Private Sub BnConFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConfirm.Click
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable(
                        " select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " & _
                        " where b.tparent in('z09_','z0s_','z0t_','z0Y_') and userid='" & SysMessageClass.UseId & "' and ButtonID='" & CobLine.Text & "'")
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowInformation("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...")
                Exit Sub
            End If


            If ContorlCheck() = True Then
                '增加检查
                If CheckIsSetCS() = False Then Exit Sub

                getPartStyle()

                Dim SitIndex As String = Me.CobSitId.SelectedIndex
                If CobSitId.Items.Count <> 1 Then
                    For i As Integer = 0 To Me.CobSitId.Items.Count - 1
                        If SitIndex = 0 Then
                            scanSetting.vPreStation = ""
                        ElseIf i = SitIndex - 1 Then
                            scanSetting.vPreStation = CobSitId.Items(i).ToString.Split(" - ")(0)
                        End If
                    Next
                Else
                    scanSetting.vPreStation = ""
                End If
                ModfiyLogInName()
            End If



        Catch ex As Exception
            MessageBox.Show("设置异常，请重新设置!")
        End Try
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

        Dim tnRet As String = String.Empty
        For Each tn As TreeNode In tnParent.Nodes
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

    Private Function CheckIsSetCS() As Boolean
        Dim strSQL As String = " DECLARE @strmsgid varchar(1), @strmsgText varchar(150) " &
                               " EXECUTE [m_NewCheckPackScanCheckHaveRule_P] '{0}',@strmsgid output,@strmsgText output" &
                               " SELECT @strmsgid,@strmsgText"
        strSQL = String.Format(strSQL, Me.TxtAvcPart.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            '错误时，提示错误信息
            If dt.Rows(0)(0).ToString = "1" Then
                MessageUtils.ShowInformation(dt.Rows(0)(1).ToString)
                Return False
            End If
        End If
        Return True
    End Function


    Private Sub getPartStyle()  ''WorkStantOption

        Array.Clear(scanSetting.vstyleArray, 0, scanSetting.vstyleArray.Length)

        Dim Sqlstring As New StringBuilder
        Dim Dr, DrPartPack As SqlDataReader  '''''DrStation
        Dim partTable As New NoSortHashtable.NoSortHashtable ''Hashtable

        Dim SqlStr As String
        Dim partArray(15) As String
        Dim strfalsg As String = ""
        Dim strTempSql As String = ""
        Dim strTempFix As String = "N"
        Dim orderStr As String = Me.TxtAvcPart.Text
        Dim sPackIDFlag As String = ""  ''m_PartPack_t 裡面的PackLink欄位
        Dim PubClass As New SysDataBaseClass
        Dim k As Integer = 1
        Dim j As Integer = 1
        Dim styleArray(15, 5) As String
        Dim tnRet As String = Me.TxtAvcPart.Text
        Dim sationId As String = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)

        '獲取該料號的PackId   2011-05-10
        'Dim Pplink As String
        SqlStr = "select partid,packid,packlink,qty from m_PartPack_t where partid='" & tnRet & "' and usey='Y'  "
        DrPartPack = PubClass.GetDataReader(SqlStr)
        If DrPartPack.HasRows Then
            While DrPartPack.Read
                sPackIDFlag = DrPartPack("packid").ToString
                'Pplink = DrPartPack("packlink").ToString
                If sPackIDFlag = "C" Then
                    scanSetting.PartPackQty = DrPartPack("qty")
                End If
            End While
        End If

        '科尔通产品条码为N处理
        Dim sPackIDTempFlag As String

        If (sPackIDFlag = "N") Then
            sPackIDTempFlag = "S"
        Else
            sPackIDTempFlag = sPackIDFlag
        End If

        DrPartPack.Close()
        Conn.PubConnection.Close()
        Dim CartpartCount As Integer = 0 '料件總數 
        If Me.TreePart.Nodes.Count = 0 Then
            '****************************************************
            '是非系统打印条码时,为了样式检查
            'IsPackType
            CheckIsSelfPrint(tnRet, sationId)

            If IsPackType = "Y" Then
                '**************20170503 田玉琳 开始*****************************************
                '箱包装时, Modify by cq

                Sqlstring.Append("SELECT partid,e.coderuleid FROM  m_PartPack_t e join M_SnRuleM_t f ON e.coderuleid=f.coderuleid WHERE ")
                Sqlstring.Append(" e.partid='" & tnRet & "' AND e.usey='Y' ")
                Sqlstring.Append(" AND e.packid NOT IN ('A','S') ") 'update by hgd 2017-09-05 箱包装排除S类型
                Sqlstring.Append(" AND ISNULL(DisorderTypeId,'') <>'P'") 'update by CQ 2017-09-08 箱包装排除P类型
                Sqlstring.Append(" AND NOT (e.Packid='N' AND ISNULL(DisorderTypeId,'')='S')") 'update by CQ 2017-10-17 箱包装排除S
                Sqlstring.Append(" ORDER BY ")
                ' Sqlstring.Append(" CASE WHEN  e.CodeRuleID LIKE 'C%' THEN 1 ELSE 2 END ,") 'update by CQ 20171121, 先C,后N
                Sqlstring.Append(" cast(e.Qty as int) ASC,e.PackingLevel asc ")
                '**************20170503 田玉琳 结束*****************************************
            Else
                '****************************************************
                '是非系统打印条码时,为了样式检查
                If IsPrtSelf = "N" And sPackIDFlag = "N" Then
                    Sqlstring.Append(" declare @cnt varchar(10) ")
                    strTempFix = IIf(Me.CodeRuleIDFix <> "", Me.CodeRuleIDFix, sPackIDFlag)
                    Sqlstring.Append(" select @cnt= count(1) from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & strTempFix &
                                     "' and e.partid='" & tnRet & "'  and e.usey='Y' and  e.coderuleid not in ('C002','C010')")
                    Sqlstring.Append(" if @cnt >1 begin  ")
                    If Me.CodeRuleIDFix = "N" OrElse Me.CodeRuleIDFix = "" Then
                        Sqlstring.Append(" select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag &
                                        "' and e.partid='" & tnRet & "'  and e.usey='Y' and DisorderTypeId='S' ")
                    Else
                        Sqlstring.Append(" select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & strTempFix &
                              "' and e.partid='" & tnRet & "'  and e.usey='Y' ")
                    End If

                    Sqlstring.Append(" end else begin ")


                    Sqlstring.Append(" select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag &
                                     "' and e.partid='" & tnRet & "'  and e.usey='Y' and  e.coderuleid not in ('C002','C010')")
                    Sqlstring.Append(" end  ")
                Else
                    '**************20160823 田玉琳 开始*****************************************
                    '扫描箱条码作为产品条码时，暂时以数量为最少的作为产品条码
                    '实际中最好箱也能设置 DisorderTypeId = 'S' 
                    Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag &
                                     "' and e.partid='" & tnRet & "' and e.usey='Y' ORDER BY cast(e.Qty as int) asc,e.PackingLevel asc ")
                    '**************20160823 田玉琳 结束*****************************************
                End If
            End If
            '****************************************************
        Else

            For Each tn As TreeNode In Me.TreePart.Nodes
                strfalsg = FindNode(tn)
                If strfalsg = "" Then
                    MessageBox.Show("請選擇需要掃描的料號")
                    Exit Sub
                End If
            
                If k = 1 And k = Me.TreePart.Nodes.Count Then
                    'Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDTempFlag & "'  and e.partid='" & tnRet & "' and e.usey='Y' and  union all" & vbNewLine)

                    If (sPackIDFlag = "N") Then
                        ' union all
                        Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'  and e.partid='" & tnRet & "' and DisorderTypeId='S' and e.usey='Y' " & vbNewLine)
                    Else
                        Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDTempFlag & "'  and e.partid='" & tnRet & "' and e.usey='Y'  " & vbNewLine)
                    End If
                    ' add by hgd 20191106 添加部件条码支持DisorderTypeId 类型
                    Sqlstring.Append(" UNION ALL select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where  e.partid='" & strfalsg & "'  and e.usey='Y' and (e.packid='" & sPackIDTempFlag & "' or e.DisorderTypeId='" & sPackIDTempFlag & "')" & vbNewLine)
                    CartpartCount = CartpartCount + 2
                ElseIf k = 1 And k <> Me.TreePart.Nodes.Count Then
                    'Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'   and e.partid='" & tnRet & "'  and e.usey='Y' union all" & vbNewLine)
                    If (sPackIDFlag = "N") Then
                        ' union all
                        Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDFlag & "'  and e.partid='" & tnRet & "' and DisorderTypeId='S' and e.usey='Y' " & vbNewLine)
                    Else
                        '  and  union all
                        Sqlstring.Append("select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDTempFlag & "'  and e.partid='" & tnRet & "' and e.usey='Y' " & vbNewLine)
                    End If
                    ' union all
                    ' add by hgd 20191121 添加部件条码支持DisorderTypeId 类型
                    'Sqlstring.Append("UNION ALL select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDTempFlag & "'  and e.partid='" & strfalsg & "'  and e.usey='Y'" & vbNewLine)
                    Sqlstring.Append("UNION ALL select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where (e.packid='" & sPackIDTempFlag & "' or e.DisorderTypeId='" & sPackIDTempFlag & "')  and e.partid='" & strfalsg & "'  and e.usey='Y'" & vbNewLine)

                    CartpartCount = CartpartCount + 2
             

                Else
                    ' add by hgd 20191121 添加部件条码支持DisorderTypeId 类型

                    Sqlstring.Append(" union all select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where (e.packid='" & sPackIDTempFlag & "' or e.DisorderTypeId='" & sPackIDTempFlag & "')  and e.partid='" & strfalsg & "'  and e.usey='Y' " & vbNewLine)
                    'Sqlstring.Append(" union all select partid,e.coderuleid from  m_PartPack_t e join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='" & sPackIDTempFlag & "'  and e.partid='" & strfalsg & "'  and e.usey='Y' " & vbNewLine)
                    CartpartCount = CartpartCount + 1
                End If
                k = k + 1
            Next
        End If
        Dr = Conn.GetDataReader(Sqlstring.ToString)

        If Dr.HasRows Then
            While Dr.Read
                partTable.Add(j & "|" & Dr!partid, Dr!coderuleid)
                j = j + 1
            End While
            scanSetting.vStandMaxStaIndex = j - 1
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

                Dim spName As String = "m_StyleShow_p_AssembleSta"
                'If IsPackType = "Y" Then
                '    spName = "m_StyleShow_p_AssembleSta_C"
                'End If

                ''*************************************************
                SqlStr = " DECLARE @SnStyle1 varchar(200),@SnStyle2 varchar(200),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                         " EXECUTE " & spName & " '" & str.Split("|")(1).ToString & "','" & partTable(str) & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output, '" & Me.mtxtMOid.Text & "' " & _
                         " SELECT @SnStyle1,@SnStyle2,@Gflen"
                ''************************************************************
                'add by hgd 2017-09-04 梅州兴宁 特殊工单取料件工艺流程 临时处理，后续删除

                SqlStr = SqlStr & ";declare @REVID int DECLARE @Routeid int select @Routeid=Routeid from m_mainmo_t where moid='" & mtxtMOid.Text.Trim & "' " & _
                    " if(isnull(@Routeid,'')<>'') " & _
                    " begin" & _
                    "   set @REVID=@Routeid;" & _
                    " SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                    " isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                    " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                    " isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                    " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                    " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                    " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN, ISNULL(ScanNumber,'1') AS ScanNumber,UpLimitWeight,UpLimitWeight,LowLimitWeight, " & _
                    " isnull(IsPpidLineWeight,'N') as IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight ," & _
                    " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf ,isnull(IsNotCaseSensitive,'N') IsNotCaseSensitive,isnull(BigCartonRepeatStyle,'') BigCartonRepeatStyle,isnull(BigCartonRepeatPara,'') BigCartonRepeatPara FROM m_RPartStationD_t WHERE " & _
                    " TPartid='" & str.Split("|")(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y' and Revid=@REVID;" & _
                    " end" & _
                    " else" & _
                    " begin" & _
                    " SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                    " isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                    " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                    " isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                    " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                    " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                    " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN,ISNULL(ScanNumber,'1') AS ScanNumber,UpLimitWeight,UpLimitWeight,LowLimitWeight, " & _
                    " isnull(IsPpidLineWeight,'N') as IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight ," & _
                    " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf,isnull(IsNotCaseSensitive,'N') IsNotCaseSensitive,isnull(BigCartonRepeatStyle,'') BigCartonRepeatStyle,isnull(BigCartonRepeatPara,'') BigCartonRepeatPara " & _
                    " FROM m_RPartStationD_t WHERE " & _
                    " TPartid='" & str.Split("|")(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y' and STATE='1'; " & _
                    " end"
                Dr = Conn.GetDataReader(SqlStr)
                'If Me.mtxtMOid.Text = "1511T-170900001" Then
                '    Dr = Conn.GetDataReader(SqlStr & ";SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                '      "isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                '      " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                '      "isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                '      " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                '      " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                '      " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN, " & _
                '      " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf FROM m_RPartStationD_t WHERE " & _
                '      " TPartid='" & str.Split("|")(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y' and Revid=34")

                'Else
                '    Dr = Conn.GetDataReader(SqlStr & ";SELECT isnull(IsUsb,'') IsUsb,isnull(IsScanPallet,'') IsScanPallet,isnull(IsCustPart,'') IsCustPart," & _
                '    "isnull(IsPrtPacking,'') IsPrtPacking,isnull(IsOnlineGenCartonID,'') IsOnlineGenCartonID,isnull(IsPrtPallet,'') IsPrtPallet,isnull(RepeatStyle,'') RepeatStyle,isnull(RepeatPara,'') RepeatPara, " & _
                '    " isnull(CartonRepeatStyle,'') CartonRepeatStyle,isnull(CartonRepeatPara,'') CartonRepeatPara," & _
                '    "isnull(IsPackingSame,'') IsPackingSame,isnull(IsWritePCB,'') IsWritePCB,isnull(IsReadPCB,'') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame," & _
                '    " ISNULL(IsCartonSame,'') AS IsCartonSame, isnull(IsAllowRe,'N') as IsAllowRe, isnull(IsPackType,'N') as IsPackType, isnull(IsPPackingProduct,'N') as IsPPackingProduct, " & _
                '    " ISNULL(IsSamePacking,'N') AS IsSamePacking, ISNULL(IsLinePrintFullCode,'N') AS IsLinePrintFullCode,ISNULL(LabelNum,'1') AS LabelNum, ISNULL(CodeRuleID, 'N') AS CodeRuleID, " & _
                '    " ISNULL(IsOnlineGenCartonID2,'') IsOnlineGenCartonID2,ISNULL(CodeRuleID2, 'N') AS CodeRuleID2,ISNULL(IsScanN,'') as IsScanN, " & _
                '    " ISNULL(IsLineWeight,'N') IsLineWeight,isnull(chkIsOnlineGenPalletID,'') IsOnlineGenPalletID,isnull(IsPrtSelf,'N') IsPrtSelf FROM m_RPartStationD_t WHERE " & _
                '    " TPartid='" & str.Split("|")(1).ToString & "' and Stationid='" & CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1) & "' and IsMainBarcode='Y'  and STATE='1'")

                'End If


                If Dr.HasRows Then
                    While Dr.Read()

                        Dim aa As String = DeleteUnVisibleChar(Dr.GetString(0))
                        If CobSitId.Text.Split("-")(0).ToUpper.Trim <> "C00022" Then
                            styleArray(i, 0) = DeleteUnVisibleChar(Dr.GetString(0)) ''樣式一
                            styleArray(i, 1) = DeleteUnVisibleChar(Dr.GetString(1)) ''樣式二   
                        Else
                            styleArray(i, 0) = Dr.GetString(0).Replace(Dr.GetString(0).Substring(4, 2), "**") ''樣式一
                            styleArray(i, 1) = Dr.GetString(1).Replace(Dr.GetString(1).Substring(4, 2), "**") ''樣式二   
                        End If
                        styleArray(i, 2) = DeleteUnVisibleChar(Dr.GetString(0).ToString).Length ''Dr.GetString(2) ''固定長度
                        'styleArray(i, 3) = partArray(i) ''子條碼名稱
                        styleArray(i, 3) = ReplaceArray(i, 2)
                        styleArray(i, 4) = str ''子料號
                        ReplaceArray(i, 1) = str ''子料號

                    End While
                    If Dr.NextResult Then
                        While Dr.Read
                            styleArray(i, 5) = Dr!IsUsb.ToString
                            '2015-02-10    马锋
                            scanSetting.ScanPalletCheck = IIf(Dr("IsScanPallet").ToString = "Y", True, False)
                            scanSetting.CustPartCheck = IIf(Dr("IsCustPart").ToString = "Y", True, False)
                            scanSetting.PrtPackingCheck = IIf(Dr("IsPrtPacking").ToString = "Y", True, False)

                            'add if by cq 20171207, main partid 
                            If str.Split("|")(1).ToString = tnRet Then
                                scanSetting.IsOnlineGenCartonID = IIf(Dr("IsOnlineGenCartonID").ToString = "Y", True, False)
                            End If

                            scanSetting.IsOnlineGenCartonID2 = IIf(Dr("IsOnlineGenCartonID2").ToString = "Y", True, False)
                            scanSetting.PrtPalletCheck = IIf(Dr("IsPrtPallet").ToString = "Y", True, False)
                            scanSetting.vRepeatStyle = Dr("RepeatStyle").ToString
                            scanSetting.vRepeatPara = Dr("RepeatPara").ToString

                            scanSetting.vCartonRepeatStyle = Dr("CartonRepeatStyle").ToString 'cq20171103
                            scanSetting.vCartonRepeatPara = Dr("CartonRepeatPara").ToString

                            scanSetting.vReadPCB = Dr("IsReadPCB").ToString = "Y"
                            scanSetting.vWritePCB = Dr("IsWritePCB").ToString = "Y"

                            scanSetting.vCartonSame = Dr("IsCartonSame").ToString
                            scanSetting.vPalletSame = Dr("IsPalletSame").ToString

                            'add by hgd 2019-10-29 相同产品，仅取主料号设置
                            scanSetting.vProductSame = IIf(str.Split("|")(0).ToString = 1, Dr("IsAllowRe").ToString, "Y")
                            'scanSetting.vProductSame = Dr("IsAllowRe").ToString
                            scanSetting.vPackType = Dr("IsPackType").ToString
                            scanSetting.vPPackingProduct = Dr("IsPPackingProduct").ToString
                            scanSetting.vSamePacking = Dr("IsSamePacking").ToString
                            scanSetting.CodeRuleID = Dr("CodeRuleID").ToString
                            scanSetting.CodeRuleID2 = Dr("CodeRuleID2").ToString
                            scanSetting.IsPrtSelf = Dr("IsPrtSelf").ToString
                            'add 20190909 周可海
                            scanSetting.IsScanN = Dr("IsScanN").ToString
                            scanSetting.ScanNumber = Dr("ScanNumber").ToString

                            '2016-04-26 田玉琳
                            scanSetting.IsLinePrintFullCode = IIf(Dr("IsLinePrintFullCode").ToString = "Y", True, False)
                            'scanSetting.IsLinePrintFullCode = IIf(Dr("IsLinePrintFullCode").ToString = "Y", "Y", "N")  'Modify by cq20190418
                            scanSetting.LabelNum = Dr("LabelNum").ToString
                            '2016-05-04 田玉琳
                            scanSetting.IsLineWeight = IIf(Dr("IsLineWeight").ToString = "Y", True, False)
                            scanSetting.IsOnlineGenPalletID = IIf(Dr("IsOnlineGenPalletID").ToString = "Y", True, False)

                            'add by hgd 2018-05-31 重量上下限
                            scanSetting.UpLimitWeight = Dr("UpLimitWeight").ToString
                            scanSetting.LowLimitWeight = Dr("LowLimitWeight").ToString
                            scanSetting.IsPpidLineWeight = IIf(Dr("IsPpidLineWeight").ToString = "Y", True, False)

                            scanSetting.PpidUpLimitWeight = Dr("PpidUpLimitWeight").ToString
                            scanSetting.PpidLowLimitWeight = Dr("PpidLowLimitWeight").ToString
                            scanSetting.IsNotCaseSensitive = Dr("IsNotCaseSensitive").ToString

                            scanSetting.vBigCartonRepeatStyle = Dr("BigCartonRepeatStyle").ToString 'cq20181103
                            scanSetting.vBigCartonRepeatPara = Dr("BigCartonRepeatPara").ToString

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

        '2015-02-10    马锋
        Array.Copy(styleArray, scanSetting.vstyleArray(), styleArray.Length)
        Array.Copy(ReplaceArray, scanSetting.vmReplaceArray(), ReplaceArray.Length)

        scanSetting.vStandIndex = CobSitId.SelectedIndex + 1
        scanSetting.MoidStr = Me.mtxtMOid.Text
        scanSetting.MoidqtyStr = Me.TxtMoQty.Text

        If CboSupport.Text <> "" Then
            scanSetting.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
        End If

        scanSetting.PartidStr = Me.TxtAvcPart.Text
        scanSetting.MoCustStr = Me.CboSupport.Text
        scanSetting.LineStr = Me.CobLine.Text
        scanSetting.TimeStr = TimeStr
        scanSetting.vStandId = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)
        scanSetting.vStandName = CobSitId.Text.Substring(InStr(CobSitId.Text, "-"))
        scanSetting.IsExitFlag = False
        scanSetting.CustIdString = Me.CboSupport.Text
        scanSetting.vProductLot = Me.TxtProductLot.Text
        scanSetting.vLabelDate = TimeStyleSet
        '  scanSetting.TTPackQty = GetPackQtyFromTT(Me.TxtAvcPart.Text)
        Me.Close()
    End Sub

    Private Function GetPackQtyFromTT(ByVal strPartID As String) As String
        Dim lsSQL As String = String.Empty

        lsSQL = "SELECT PAvcPart  FROM m_PartContrast_t WHERE TAvcPart ='" & strPartID & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPackQtyFromTT = GetPackQtyFromTTByPPartID(o_dt.Rows(0).Item(0))
            Else
                GetPackQtyFromTT = ""
            End If
        End Using

    End Function

    Private Function GetPackQtyFromTTByPPartID() As String
        Dim lssql As String = ""
        Dim o_ds As New DataSet
        Try
            o_ds = DBUtility.DbOracleHelperSQL.Query(lssql)

            If Not IsNothing(o_ds) AndAlso o_ds.Tables.Count > 0 Then
                GetPackQtyFromTTByPPartID = o_ds.Tables(0).Rows(0).Item(0)
            Else
                GetPackQtyFromTTByPPartID = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CobSitId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobSitId.KeyPress

        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If

    End Sub

    Private Sub CheckIsSelfPrint(partId As String, stationId As String)
        Dim strSQL As String = " SELECT ISNULL(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY," & _
                              " ISNULL(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType, " & _
                              " ISNULL(IsPrtSelf,'N') as IsPrtSelf ,SUBSTRING(isnull(CodeRuleID,''),dbo.lastindexof(isnull(CodeRuleID,''),'/',0)-1,1) as CodeRuleID" & _
                              " FROM m_RPartStationD_t where PPartid='" & partId & "' and TPartid='" & partId & "' " & _
                              " AND Stationid='" & stationId & "'  and State='1'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            IsPrtSelf = dt.Rows(0)!IsPrtSelf
            IsPackType = dt.Rows(0)!IsPackType
            CodeRuleIDFix = dt.Rows(0)!CodeRuleID 'add by hgd 20170908 获取编码原则前缀
        End If
    End Sub

    Private Sub CobSitId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobSitId.SelectedIndexChanged

        Me.TreePart.Nodes.Clear()
        LoadDataToTreeView()

    End Sub

    '加載treeview數據
    Private Sub LoadDataToTreeView()
        Dim dtable As New DataTable
        Dim dStaView As New DataView
        Dim dScanView As New DataView
        Dim node As TreeNode = Nothing
        Dim SqlStr As String
        If CobSitId.SelectedIndex = -1 Then
            Exit Sub
        End If
        'add by hgd 2018-06-21

        ''站点编号 add by 马跃平 2018-05-04
        Dim StationID = ""
        'If InStr(CobSitId.Text, "-") - 1 >= 0 Then
        '    StationID = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)
        'End If
        StationID = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)
 

        '加載明細子節點103-006024-04A
        SqlStr = "select  tparttext,TPartid,scanorderid,isnull(ReplaceID,'') ReplaceID,ismainbarcode from m_RPartStationD_t where Stationid='" & StationID & "' and state='1' and PPartid='" & Me.TxtAvcPart.Text & "'  order by StaOrderid ASC"
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
                SqlStr = " select a.Tpartid mTpartid,a.tparttext,b.TPartid,a.scanorderid from m_RPartStationD_t a left join m_RPartStationT_t b on a.ReplaceID=b.ReplaceID " &
                         " where a.TPartid='" & dStaView.Item(i)(1).ToString & "' and Stationid='" & StationID.ToString.Trim &
                         " ' and state='1' and b.replaceid='" & dStaView.Item(i)(3).ToString & "' and isreplaceable='Y'"
                dtable1 = DbOperateUtils.GetDataTable(SqlStr)

                For j As Int16 = 0 To dtable1.Rows.Count - 1
                    Dim node2 As TreeNode

                    node2 = New TreeNode(dtable1.Rows(j)(2).ToString.Trim)
                    node2.Tag = dtable1.Rows(j)(3).ToString.Trim
                    node1.Nodes.Add(node2)
                Next
            Next
        End If
        '' TreePart.Nodes.Add(node1)
        TreePart.ExpandAll()
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
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, "")
            'Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            FrmMOQuery.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub
    Dim factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN"
    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        CobLine.Items.Clear()
        CobLine.Text = ""
        CobSitId.Text = ""
        Me.CobSitId.Items.Clear()
        For Each text As Control In GroupShow.Controls
            If TypeOf text Is ULControls.textBoxUL Then
                text.Text = ""
                Me.TreePart.Nodes.Clear()
            End If
        Next

        If (Not String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            Try

                SqlStr = "select distinct a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink,a.Cusid+'('+g.CusName+')' as Cusid " &
                        " from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d  " &
                        " on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid left join  m_Customer_t g on g.CusID=a.Cusid  where e.packid in('S','C','N') " &
                        " and a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and isnull(a.profitcenter,'') = '" & VbCommClass.VbCommClass.profitcenter & "'  and e.usey='Y'"

                'update by hgd 20180129 取消按客户筛选，都按功能带出
                'If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                'Else
                '    If Not String.IsNullOrEmpty(CboSupport.Text.Trim) Then
                '        SqlStr = SqlStr + " and a.Cusid='" & CboSupport.Text.Split("(")(0) & "' "
                '    End If

                'End If

                Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                Dim strLine As String = ""
                Dim strCosid As String = ""
                If dt.Rows.Count > 0 Then
                    DeptStr = dt.Rows(0)("deptid").ToString
                    scanSetting.DpetId = dt.Rows(0)("deptid").ToString

                    Me.TxtMoQty.Text = dt.Rows(0)("moqty").ToString
                    Me.TxtMotype.Text = dt.Rows(0)("motype").ToString
                    Me.TxtAvcPart.Text = dt.Rows(0)("partid").ToString
                    Me.TxtCustomPart.Text = dt.Rows(0)("custpart").ToString
                    factoryidstr = dt.Rows(0)("Factory").ToString
                    BcRule = dt.Rows(0)("coderuleid").ToString
                    CobLine.Text = dt.Rows(0)("lineid").ToString
                    strLine = dt.Rows(0)("lineid").ToString
                    strCosid = dt.Rows(0)("Cusid").ToString
                    scanSetting.BcRuleid = BcRule
                End If

                '"' and factoryid='" & factoryidstr &
                'SqlStr = " select lineid from Deptline_t where deptid='" & DeptStr & "'  and usey='Y' order by lineid"

                'Dim dt2 As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                'Me.CobLine.Items.Clear()
                'Me.CobSitId.Items.Clear()
                'For cnt As Integer = 0 To dt2.Rows.Count - 1
                '    CobLine.Items.Add(dt2.Rows(cnt)(0).ToString)
                'Next

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
                    scanSetting.vSq = dt3.Rows(cnt)("asny").ToString
                Next
                If String.IsNullOrEmpty(strCosid) Then
                    CboSupport.SelectedIndex = -1
                Else
                    CboSupport.Text = strCosid
                    

                End If
                If String.IsNullOrEmpty(strLine) Then
                    CobLine.SelectedIndex = -1
                Else
                    CobLine.Items.Add(strLine)
                    CobLine.Text = strLine
                End If

                If CobSitId.Items.Count = 1 Then
                    Me.CobSitId.SelectedIndex = 0
                Else
                    CobSitId.SelectedIndex = -1
                End If
                CobSitId.Enabled = True
                'Add by hgd 2018-03-01 亚马逊扫描工站编码，不用选择工站
                If strCosid = "6L(AMAZON)" AndAlso TxtAvcPart.Text.Contains("L6LU2003-CS-H") Then
                    CobSitId.SelectedIndex = -1
                    CobSitId.Enabled = False

                    Dim frmScanStation As New FrmScanStation(Me.mtxtMOid.Text)
                    If frmScanStation.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        CobSitId.Text = frmScanStation.StationId
                    End If

                End If
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMoid_textChanged", "sys")
                MessageBox.Show("工单信息加载异常")
                Exit Sub
            End Try
        End If
    End Sub
End Class
