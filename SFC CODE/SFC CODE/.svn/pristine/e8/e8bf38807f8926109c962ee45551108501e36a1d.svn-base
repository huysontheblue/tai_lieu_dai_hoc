Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports MainFrame
Imports System.Text


Public Class FrmLotShareSetForm

    Dim Conn As New SysDataBaseClass
    Dim TimeStr As String
    Dim BcRule As String
    Dim TimeStyleSet As String
    Const ColZero As Integer = 0
    Dim Datet As New DateTime
    Dim IsReplaceFlag As String
    Dim ReplaceArray(15, 5) As String
    Dim scanSetting As ScanSetting

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

    Private Sub FrmLotShareSetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreePart.ExpandAll()

        Datet = GetDBSysteDate()

        Me.DtpDate.Value = Datet.ToString("yyyy/MM/dd")
        Me.DtpTime.Value = Datet.ToString
        DtpSet.Value = Datet.ToString
        Me.TxtProductLot.Text = Datet.ToString("yyyyMMdd") & "01"

        InitCombox()

        InitScanSetFrom()
    End Sub

    Private Function GetDBSysteDate() As DateTime
        Dim strSQL As String = "select getdate() as Datet"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows(0)(0).ToString
    End Function

    Private Sub InitCombox()
        Dim strSQL As String = " SELECT (A.Cusid + '('+ B.CusName + ')') TEXT  FROM" & _
              " (SELECT DISTINCT Cusid FROM m_Mainmo_t WHERE ISNULL(Cusid,'')<>''" & _
              " UNION " & _
              " SELECT DISTINCT Cusid FROM m_PartContrast_t WHERE ISNULL(Cusid,'')<>'') A" & _
              " INNER JOIN m_Customer_t B ON A.Cusid=B.CusID" & _
              " ORDER BY A.Cusid"
        LoadDataToCob(strSQL, CboSupport) ''填充客戶
    End Sub

    Private Function GetAuthority() As Boolean
        GetAuthority = False

        Dim strSQL As String =
            " select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " &
            " where b.tparent in('z09_','z0s_','z0t_','z0Y_') and userid='" & SysMessageClass.UseId &
            "' and ButtonID='" & CobLine.Text & "'"

        Dim Cnt As Integer = DbOperateUtils.GetRowsCount(strSQL)

        If Cnt > 0 Then
            GetAuthority = True
        End If
    End Function

    Private Sub ButConfirm_Click(sender As Object, e As EventArgs) Handles ButConfirm.Click
        '检查数据
        If ContorlCheck() = True Then


            TimeStr = Format(Me.DtpDate.Value, "yyyy/MM/dd")
            TimeStr = TimeStr + " " + Format(Me.DtpTime.Value, "HH:mm:ss")
            WorkStantOption.TimeStr = TimeStr
            scanSetting.MoidStr = mtxtMOid.Text.Trim  ''工單
            scanSetting.vStandId = CobSitId.Text.Substring(0, InStr(CobSitId.Text, "-") - 1)
            scanSetting.vStandName = CobSitId.Text.Substring(InStr(CobSitId.Text, "-"))
            scanSetting.PartidStr = TxtAvcPart.Text ''料件編號
            scanSetting.LineStr = CobLine.Text ''線別
            scanSetting.MoidqtyStr = TxtMoQty.Text
            scanSetting.SnStyleStr1 = String.Format("L{0}*********", DtpSet.Value.ToString("yyyy"))
            scanSetting.IsExitFlag = False
            CartonScanOption.CheckStr = True

            ModfiyLogInName()

            Me.Close()
        End If
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
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

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmMOQuery.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        CobLine.Text = ""
        CobSitId.Text = ""
        For Each text As Control In GroupShow.Controls
            If TypeOf text Is ULControls.textBoxUL Then
                text.Text = ""
                Me.TreePart.Nodes.Clear()
            End If
        Next

        If (Not String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            Try
                SqlStr = "select distinct  a.deptid,a.Factory,b.djc,a.moqty,c.motype,a.partid,d.custpart,f.flen,f.coderuleid,a.lineid, e.packid,e.packlink  from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where a.moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and a.Cusid='" & CboSupport.Text.Split("(")(0) & "' and e.usey='Y'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                Dim strLine As String = ""
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    DeptStr = dr("deptid").ToString
                    WorkStantOption.DpetId = dr("deptid").ToString
                    If (Not scanSetting Is Nothing) Then
                        scanSetting.DpetId = dr("deptid").ToString
                    End If
                    Me.TxtMoQty.Text = dr("moqty").ToString
                    Me.TxtMotype.Text = dr("motype").ToString
                    Me.TxtAvcPart.Text = dr("partid").ToString
                    Me.TxtCustomPart.Text = dr("custpart").ToString
                    factoryidstr = dr("Factory").ToString
                    BcRule = dr("coderuleid").ToString
                    CobLine.Text = dr("lineid").ToString
                    strLine = dr("lineid").ToString
                    WorkStantOption.BcRuleid = BcRule
                    If (Not scanSetting Is Nothing) Then
                        scanSetting.BcRuleid = BcRule
                    End If
                End If

                SqlStr = "select lineid TEXT from Deptline_t where deptid='" & DeptStr & "' and factoryid='" & factoryidstr & "'  and usey='Y' order by lineid" & vbNewLine

                LoadDataToCob(SqlStr, CobLine)

                SqlStr =
                    "   SELECT DISTINCT b.stationid, b.stationname, a.staorderid, a.asny " &
                    "   FROM m_RPartStationD_t a JOIN m_Rstation_t b ON a.stationid = b.stationid " &
                    "   WHERE ppartid = '{0}' " &
                    "   AND tpartid = ppartid " &
                    "   AND b.stationtype = 'A' " &
                    "   AND state = '1'" &
                    "   ORDER BY staorderid "
                SqlStr = String.Format(SqlStr, TxtAvcPart.Text.Trim)

                dt = DbOperateUtils.GetDataTable(SqlStr)

                Me.CobSitId.Items.Clear()

                For Each dr As DataRow In dt.Rows
                    If UCase(m_StationType) = "A" Then
                        Continue For
                    End If

                    Me.CobSitId.Items.Add(dr("stationid").ToString & " - " & dr("stationname").ToString)

                    WorkStantOption.vSq = dr("asny").ToString
                    If (Not scanSetting Is Nothing) Then
                        scanSetting.vSq = dr("asny").ToString
                    End If
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

            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMoid_textChanged", "sys")
                MessageBox.Show("工单信息加载异常")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub CobSitId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CobSitId.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If
    End Sub


    Private Sub CobLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CobLine.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If
    End Sub


#Region "保存设置内容"

    Private Sub InitScanSetFrom() ''重復設置時保存上一次的設置記錄
        Dim xmlDocument As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDocument.Load(Application.StartupPath & "\ScanConfig.xml")
        Dim xmlnode As Xml.XmlNode
        xmlnode = xmlDocument.DocumentElement

        Me.CboSupport.Text = xmlnode.SelectSingleNode("cus").InnerText
        Me.mtxtMOid.Text = xmlnode.SelectSingleNode("mo").InnerText
        Me.CobLine.Text = xmlnode.SelectSingleNode("line").InnerText
        Me.DtpSet.Text = xmlnode.SelectSingleNode("bardate").InnerText ''.ToString("yyyy/MM/dd")
        Me.CobSitId.Text = xmlnode.SelectSingleNode("station").InnerText
    End Sub

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

    Private Sub Setdd()

        Me.Close()

    End Sub


    Private Function ContorlCheck() As Boolean '''' lrq   2007/01/10 ''''

        If GetAuthority() = False Then
            MessageBox.Show("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If Me.CboSupport.Text = "" Or CobLine.Text = "" Then
            MessageBox.Show("客戶名稱或线别不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboSupport.Focus()
            CboSupport.SelectAll()
            Return False
        End If

        If (String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            MessageBox.Show("工單編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.mtxtMOid.Focus()
            Return False
        End If

        If Me.CobSitId.Text = "" Then
            MessageBox.Show("工站編號不能為空或該料號的工站資料未設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobSitId.Focus()
            CobSitId.SelectAll()
            Return False
        End If

        'If Me.TxtCustomPart.Text = "" Then
        '    MessageBox.Show("資料未設置完整或工單編號不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        If -30 > DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) OrElse DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) > 60 Then
            MessageBox.Show("設置的時間不得偏離當前時間两個月!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Else
            TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")
        End If

        TimeStr = Format(Me.DtpDate.Value, "yyyy/MM/dd")
        TimeStr = TimeStr + " " + Format(Me.DtpTime.Value, "HH:mm:ss")
        If TimeStr > Format(Datet, "yyyy/MM/dd HH:mm:ss") Then
            MessageBox.Show("您選擇的開始時間大於當前時間!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        CobName.Items.Clear()
        For Each dr As DataRow In dt.Rows
            CobName.Items.Add(dr("TEXT").ToString)
        Next
    End Sub

End Class