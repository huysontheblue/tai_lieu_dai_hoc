Imports DevComponents.DotNetBar
Imports MainFrame
Imports MainFrame.SysCheckData
Imports RouteManagement
Imports System.IO
Imports System.ComponentModel
Imports System.Xml

''' <summary>
''' 主界面窗体
''' 动态加载界控件与菜单
''' CreateDate: 2018-08-24
''' CreateBy: Yuanfeng.Yu
''' </summary>
''' <remarks></remarks>

Public Class FrmMainDynamic
    Inherits DevComponents.DotNetBar.Office2007RibbonForm
    Dim Language As String = ""

#Region "公共方法"

    ''' <summary>
    ''' 显示子窗口
    ''' </summary>
    ''' <param name="Tag">子窗体Tag字符串对象(窗口的命名空间等)</param>
    ''' <param name="FromText">菜单窗体标题</param>
    ''' <param name="IsMdiChildren">是否是MdiChildren窗体</param>
    ''' <remarks></remarks>
    Private Sub ShowForm(ByVal Tag As String, ByVal FromText As String, ByVal IsMdiChildren As Boolean)
        Try
            If String.IsNullOrEmpty(Tag) = False Then
                If Tag.Contains(".") Then   '防止漏填窗口的命名空间
                    Dim NameSpaceStr = Tag.Substring(0, Tag.IndexOf(".")) '命名空间
                    Dim FormName = Tag.Substring(Tag.IndexOf(".") + 1) '窗体名称
                    Dim frm = CType(Activator.CreateInstance(Type.GetType(Tag & "," & NameSpaceStr)), Form)
                    If IsMdiChildren = True Then
                        For Each ShowChildForm In Me.MdiChildren
                            If ShowChildForm.GetType.Name = FormName Then
                                ShowChildForm.Focus()
                                Exit Sub
                            End If
                        Next
                        frm.MdiParent = Me
                    Else
                        frm.MdiParent = Nothing
                    End If
                    frm.Text = FromText
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                End If
            End If
        Catch ex As Exception
            MessageUtils.ShowError("打开子窗体异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "显示登录等信息"

    ''' <summary>
    ''' 界面UI基本设置
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetUI()
        MetroTilePanel1.Visible = False
        GroupPanel1.Visible = False
        PanPic.Visible = True
        Me.PanPic.BackColor = SystemColors.InactiveCaption
        Me.PanPic.BackgroundImageLayout = ImageLayout.Stretch
        ' Me.GroupPanel1.BackColor = Color.Transparent    '此处背景色应和PanPic的背景色一致，影响系统消息框颜色
        '主窗口设置
        Me.Text = ""
        Me.IsMdiContainer = True
        '
        ' 居中定位：常用功能与公告栏；
        If Me.PanPic.Width >= Me.MetroTilePanel1.Width And Me.PanPic.Height >= (Me.MetroTilePanel1.Height + Me.GroupPanel1.Height) Then
            Dim iWidth = Me.PanPic.Width / 2        '中心点W=容器宽度的一半
            Dim iHeight = Me.PanPic.Height / 2      '中心点H=容器高度的一半
            Dim iSetWidth = Me.GroupPanel1.Width / 2                                        '宽度按GroupPanel1
            Dim iSetHeight = (Me.MetroTilePanel1.Height + Me.GroupPanel1.Height) / 2 + 17  '高度按GroupPanel1 + MetroTilePanel1
            Me.MetroTilePanel1.Location = New System.Drawing.Point(iWidth - iSetWidth - 17, iHeight - iSetHeight)   '17是个微调值
            Me.GroupPanel1.Location = New System.Drawing.Point(iWidth - iSetWidth, iHeight - iSetHeight + 329)
        Else
            Me.MetroTilePanel1.Location = New System.Drawing.Point(3, 11)
            Me.GroupPanel1.Location = New System.Drawing.Point(20, 339)
        End If

        SetBackgroundLoad()
        '
        '值班信息控件，在状态栏上靠右边显示
        Me.lblUser.Text = ""    '先清空
        If Language = "简体中文" Then
            Me.lblServerName.Text = "服务器："
        ElseIf Language = "繁體中文" Then
            Me.lblServerName.Text = "服務器："
        ElseIf Language = "English" Then
            Me.lblServerName.Text = "The server："
        Else
            Me.lblServerName.Text = "Máy chủ："
        End If

        Me.cbxStyle.ItemAlignment = eItemAlignment.Far
        Me.lblServerName.ItemAlignment = eItemAlignment.Far
        '
        '加载皮肤样式选项
        Dim item As eStyle
        For Each item In [Enum].GetValues(GetType(eStyle))
            If item = eStyle.VisualStudio2012Dark Then
                Continue For
            End If
            If item = eStyle.Metro Then
                Continue For
            End If
            Dim obj As DevComponents.Editors.ComboItem = New DevComponents.Editors.ComboItem
            obj.Value = Integer.Parse(item)
            obj.Text = item.ToString
            Me.cbxStyle.Items.Add(obj)
        Next
        '用户的默认皮肤样式
        If VbCommClass.VbCommClass.StyleID = "99" Then
            Me.cbxStyle.SelectedItem = Me.cbxStyle.Items(4)
        Else
            If Integer.Parse(VbCommClass.VbCommClass.StyleID) < 11 Then
                Me.cbxStyle.SelectedItem = Me.cbxStyle.Items(Integer.Parse(VbCommClass.VbCommClass.StyleID))
            Else
                Me.cbxStyle.SelectedItem = Me.cbxStyle.Items(11)
            End If
        End If

        '定时器，5分钟刷新值班信息(暂停用，若后续要这个功能，则取消下面几行的注释)
        'Dim timer1 As Timer = New Timer()
        'timer1.Interval = 50000
        'timer1.Enabled = True
        'AddHandler timer1.Tick, AddressOf timer1_Tick

        '启动时要设置主页的背景图片
        'SetBackground()

    End Sub

    ''' <summary>
    ''' 定时器事件
    ''' 定时5分钟刷新值班信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs)
        'ShowCurDutyUser()
        'ShowNotice()
    End Sub

    ''' <summary>
    ''' 显示登录信息与窗体标题
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowLoginInfo()
        Dim xmldoc As New Xml.XmlDocument
        Try
            Dim LoadFactory As String = ""
            Dim LoadProfitCenter As String = ""
            Dim LoadIP As String = ""

            xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '读取XML中的上次登录信息
            Dim nodeList As Xml.XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As Xml.XmlNode In nodeList
                '营运中心
                If LCase(xn.Name) = "servername" Then
                    LoadFactory = xn.InnerText
                    Continue For
                End If
                '利润中心
                If LCase(xn.Name) = "profitcenter" Then
                    LoadProfitCenter = xn.InnerText
                    Continue For
                End If
            Next

            LoadIP = GetIPAddress()
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                If Language = "简体中文" Then
                    btnTitle.Text += String.Format("(公司代码:{0} 工厂代码:{1} 当前用户:{2} IP:{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                ElseIf Language = "繁體中文" Then
                btnTitle.Text += String.Format("(公司程式碼:{0} 工廠程式碼:{1} 當前用戶:{2} IP:{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                ElseIf Language = "English" Then
                    btnTitle.Text += String.Format("(Company code:{0} Factory code:{1} Current user:{2} IP:{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                Else
                    btnTitle.Text += String.Format("(Mã công ty:{0} Mã nhà máy:{1} Người dùng hiện tại:{2} IP:{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                End If
            Else
                If Language = "简体中文" Then
                    btnTitle.Text += String.Format("(营运中心:{0} 利润中心:{1} 当前用户:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                ElseIf Language = "繁體中文" Then
                    btnTitle.Text += String.Format("(營運中心:{0} 利潤中心:{1} 當前用戶:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                ElseIf Language = "English" Then
                    btnTitle.Text += String.Format("(Operation center:{0} Profit center:{1} Current user:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                Else
                    btnTitle.Text += String.Format("(Trung tâm hoạt động:{0} Trung tâm lợi:{1} Người dùng hiện tại:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "软件根目录下无Loginlog.xml文件，请联系管理员配置", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 获取当前用户的电脑IP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIPAddress() As String
        Dim ips As String = ""
        Try
            Dim ipHost As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            Dim ipaddress As Net.IPAddress = Nothing
            Dim list As ArrayList = New ArrayList

            For i As Integer = 0 To ipHost.AddressList.Length - 1
                ipaddress = ipHost.AddressList(i)
                If (ipaddress.AddressFamily.ToString() = "InterNetwork") Then
                    If ipaddress.ToString.Length <> 19 Then
                        ips = ipaddress.ToString
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return ips
    End Function

    ''' <summary>
    ''' 获取数据库服务器名称
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowServerInfo()
        Dim serverName As String = MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName.ToString
        If serverName.Contains("DG-MESDB.luxshare.com.cn") Then
            lblServerName.Text = Me.lblServerName.Text & String.Format("（{0}:{1}）", serverName.Split("=")(1).Split(";")(0), VbCommClass.VbCommClass.SapServer)
        ElseIf serverName.Contains("172.18.20.170") Then
            lblServerName.Text = Me.lblServerName.Text & String.Format("（{0}）", serverName.Split("=")(1).Split(";")(0))
        ElseIf serverName.Contains("172.20.20.155") Then
            lblServerName.Text = Me.lblServerName.Text & String.Format("（{0}:{1}）", serverName.Split("=")(1).Split(";")(0), VbCommClass.VbCommClass.SapServer)
        Else
            lblServerName.Text = Me.lblServerName.Text & String.Format("（{0}）", serverName.Split("=")(1).Split(";")(0))
        End If
    End Sub

    ''' <summary>
    ''' 值班信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowCurDutyUser()
        Try
            'Dim sql As String = " exec [usp_Duty_WeekPlan] '{0}','2' "
            'sql = String.Format(sql, "")

            Dim dt As DataTable = DtDuty ' DbOperateUtils.GetDataTable(sql)

            lblUser.Text = ""
            If dt.Rows.Count > 0 Then
                If Language = "简体中文" Then
                    lblUser.Text = dt.Rows(0)(0).ToString
                ElseIf Language = "繁體中文" Then
                    lblUser.Text = dt.Rows(0)(0).ToString.Replace("当日值班人员(姓名|电话|分机号|短号)（", "當日值班人員(姓名|電話|分機號|短號)（")
                ElseIf Language = "English" Then
                    lblUser.Text = dt.Rows(0)(0).ToString.Replace("当日值班人员(姓名|电话|分机号|短号)（", "Person on duty on the day(Name|Telephone|Extension number|Short number)（")
                Else
                    lblUser.Text = dt.Rows(0)(0).ToString.Replace("当日值班人员(姓名|电话|分机号|短号)（", "Người trực ngày hôm đó(tên « 124|điện thoại « 124|số mở rộng s124|số ngắn)（")
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "获取值班信息失败", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 公告栏信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowNotice()
        Try
            ' MetroTilePanel1.Visible = False
            'GroupPanel1.Visible = False

            Dim NoticeText As String = ""
            Dim GroupPanel1Text As String = ""


            If Language = "简体中文" Then
                NoticeText = "暂无公告"
                GroupPanel1Text = "系统公告"

            ElseIf Language = "繁體中文" Then
                NoticeText = "暫無公告"
                GroupPanel1Text = "系統公告"

            ElseIf Language = "English" Then
                NoticeText = "No announcement"
                GroupPanel1Text = "System announcement"
            Else
                NoticeText = "Không thông báo"
                GroupPanel1Text = "Thông báo hệ thống"
            End If

            Me.txtNotice.Text = NoticeText
            Me.GroupPanel1.Text = GroupPanel1Text

            '取系统消息
            'Dim sql2 As String = "select top 1 title,contents from m_Advert_t where usey='Y' order by intime desc"
            '  Dim sql2 As String = "select top 1 title,contents,DetailID=isnull(richID,'-1') from m_Advert_t a left join m_richAdv_t b on a.id=b.richID where usey='Y' order by a.intime desc"
            Dim dt1 As DataTable = DtAdvert ' DbOperateUtils.GetDataTable(sql2)
            If dt1.Rows.Count > 0 Then
                Me.txtNotice.Text = IIf(IsDBNull(dt1.Rows(0)("contents")), NoticeText, dt1.Rows(0)("contents").ToString)
                Me.GroupPanel1.Text = IIf(IsDBNull(dt1.Rows(0)("title")), GroupPanel1Text, dt1.Rows(0)("title").ToString)
                If (dt1.Rows(0)("DetailID").ToString >= 0) Then
                    btnAdvDetail.Visible = True
                Else
                    btnAdvDetail.Visible = False
                End If
            Else
                btnAdvDetail.Visible = False
            End If
            '没有公告详情 隐藏按钮
            'Dim sql3 As String = " select 1 from m_richAdv_t a left join m_Advert_t b on a.richID =b.id  where b.usey ='Y' "
            'Dim dt3 As DataTable = DbOperateUtils.GetDataTable(sql3)
            'If dt3.Rows.Count <= 0 Then
            '    btnAdvDetail.Visible = False
            'Else
            '    btnAdvDetail.Visible = True
            'End If

            Animation.ShowControl(GroupPanel1, True, AnchorStyles.Bottom)
            ' GroupPanel1.Visible = True
            MetroTilePanel1.Visible = True


        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    ''' <summary>
    ''' 加载同公司所有工厂列表，以便切换
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InLoadFactoryList()

        Dim XmlDoc As New XmlDocument
        Try
            XmlDoc.Load(Application.StartupPath & "\Loginlog.xml")  ''打開XML文件
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            DevComponents.DotNetBar.Controls.DesktopAlert.Show(ex.Message & vbNewLine & "不存在XML文件", DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
        File.SetAttributes(Application.StartupPath & "\Loginlog.xml", FileAttributes.Normal) ''設置XML文件為可讀寫
        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes
        For Each xn As XmlNode In nodeList
            If LCase(xn.Name) = "language" Then
                Language = xn.InnerText
                Continue For
            End If
        Next

        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            If Language = "简体中文" Then
                btnSelectFactory.Text = "切换利润工厂"
            ElseIf Language = "繁體中文" Then
                btnSelectFactory.Text = "切換利潤工廠"
            ElseIf Language = "English" Then
                btnSelectFactory.Text = "Switch Profit Factory"
            Else
                btnSelectFactory.Text = "Đổi nhà máy lợi nhuận"
            End If
        Else
            If Language = "简体中文" Then
                btnSelectFactory.Text = "切换利润中心"
            ElseIf Language = "繁體中文" Then
                btnSelectFactory.Text = "切換利潤中心"
            ElseIf Language = "English" Then
                btnSelectFactory.Text = "Switch Profit Center"
            Else
                btnSelectFactory.Text = "Đổi trung tâm lợi nhuận"
            End If
        End If
        Me.btnSelectFactory.SubItems.Clear()
        Dim dv As DataView = Me.dvPro
        Dim dv_item As DataRowView = Nothing
        For Each dv_item In dv
            Dim Subitem As ButtonItem = New ButtonItem
            Subitem.Name = dv_item("PROFITCENTER_CODE").ToString()
            Subitem.Text = dv_item("PROFITCENTER_NAME").ToString()
            Subitem.CommandParameter = dv_item("PROFITCENTER_NAME").ToString()
            Subitem.Command = AppCommandFactory
            btnSelectFactory.SubItems.Add(Subitem)
        Next

    End Sub



#End Region
#Region "加载初始数据"
    Dim _dtbg As DataTable
    ''' <summary>
    ''' 背景图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Dtbg() As DataTable
        Get
            Return _dtbg
        End Get
        Set(value As DataTable)
            _dtbg = value
        End Set
    End Property

    Dim _dtDuty As DataTable
    ''' <summary>
    ''' 值班信息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtDuty() As DataTable
        Get
            Return _dtDuty
        End Get
        Set(value As DataTable)
            _dtDuty = value
        End Set
    End Property

    Dim _dtSysMenu As DataTable
    ''' <summary>
    ''' 系统主菜单
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtSysMenu() As DataTable
        Get
            Return _dtSysMenu
        End Get
        Set(value As DataTable)
            _dtSysMenu = value
        End Set
    End Property

    Dim _dtSysSubMenu As DataTable
    ''' <summary>
    ''' 子菜单
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtSysSubMenu() As DataTable
        Get
            Return _dtSysSubMenu
        End Get
        Set(value As DataTable)
            _dtSysSubMenu = value
        End Set
    End Property

    Dim _dtSixMenu As DataTable
    ''' <summary>
    ''' 6个最近打开菜单
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtSixMenu() As DataTable
        Get
            Return _dtSixMenu
        End Get
        Set(value As DataTable)
            _dtSixMenu = value
        End Set
    End Property

    Dim _dtAdvert As DataTable
    ''' <summary>
    ''' 载入通知
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtAdvert() As DataTable
        Get
            Return _dtAdvert
        End Get
        Set(value As DataTable)
            _dtAdvert = value
        End Set
    End Property

    Dim _dvPro As DataView
    ''' <summary>
    ''' 载入所在公司对应的子工厂列表、利润中心列表，以方便随时切换
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property dvPro() As DataView
        Get
            Return _dvPro
        End Get
        Set(value As DataView)
            _dvPro = value
        End Set
    End Property
    ''' <summary>
    ''' 初始加载函数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InLoadData()
        Dim sqlAll = "exec usp_User_InLoad '" & VbCommClass.VbCommClass.UseId & "'"
        Dim ds As DataSet = DbOperateUtils.GetDataSet(sqlAll)
        Dtbg = ds.Tables(0)
        DtDuty = ds.Tables(1)
        DtSysMenu = ds.Tables(2)
        DtSysSubMenu = ds.Tables(3)
        DtSixMenu = ds.Tables(4)
        DtAdvert = ds.Tables(5)

    End Sub
#End Region

#Region "加载系统菜单"


    ''' <summary>
    ''' 加载主菜单
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMenu()
        Try
            '按当前用户的权限，获取菜单列表
            'Dim sqlMain = "exec Pro_GetSysMenu '" & VbCommClass.VbCommClass.UseId & "'"
            'Dim sqlSub = "exec Pro_GetSysSubMenu '" & VbCommClass.VbCommClass.UseId & "'"

            Dim dtMenuMaster = DtSysMenu ' DbOperateUtils.GetDataTable(sqlMain)
            Dim dtMenuSub = DtSysSubMenu ' DbOperateUtils.GetDataTable(sqlSub)     '子菜单一次查出来，优化菜单加载速度
            '显示菜单（主菜单，子菜单）
            If Not dtMenuMaster Is Nothing And dtMenuMaster.Rows.Count > 0 Then
                Dim menuKey As String = ""
                Dim menuText As String = ""

                For i As Integer = 0 To dtMenuMaster.Rows.Count - 1

                    menuKey = IIf(IsDBNull(dtMenuMaster.Rows(i)("Tkey")), "", dtMenuMaster.Rows(i)("Tkey").ToString)
                    If Language = "简体中文" Then
                        menuText = IIf(IsDBNull(dtMenuMaster.Rows(i)("Ttext")), "", dtMenuMaster.Rows(i)("Ttext").ToString)
                    End If
                    If Language = "繁體中文" Then
                        menuText = IIf(IsDBNull(dtMenuMaster.Rows(i)("TWname")), "", dtMenuMaster.Rows(i)("TWname").ToString)
                    End If
                    If Language = "English" Then
                        menuText = IIf(IsDBNull(dtMenuMaster.Rows(i)("Enname")), "", dtMenuMaster.Rows(i)("Enname").ToString)
                    End If
                    If Language = "Vi?t nam" Or Language = "Việt nam" Then
                        menuText = IIf(IsDBNull(dtMenuMaster.Rows(i)("VNname")), "", dtMenuMaster.Rows(i)("VNname").ToString)
                    End If

                    If (menuKey <> "" And menuText <> "") Then
                        Dim rt As RibbonTabItem = New RibbonTabItem
                        Dim rtp As RibbonPanel = New RibbonPanel

                        '页签
                        rt.Name = menuKey
                        rt.Text = menuText
                        rt.Checked = IIf(i = 0, True, False)    '默认选中第一个页签
                        rtp.Name = "rtp" + i.ToString
                        rtp.Dock = DockStyle.Fill
                        '页签内面板
                        rt.Panel = rtp
                        '
                        '页签面板内，显示子菜单按钮的容器RibbonBar
                        Dim rb = New RibbonBar()
                        rb.Dock = System.Windows.Forms.DockStyle.Fill
                        rb.TitleVisible = False
                        rb.Size = New System.Drawing.Size(1354, 96) '须设置大小，否则尺寸子菜单无法显示
                        rb.VerticalItemAlignment = eVerticalItemsAlignment.Middle
                        rtp.Controls.Add(rb)
                        '
                        '将上述控件加载到界面上
                        Me.RibbonControl1.Controls.Add(rtp)
                        Me.RibbonControl1.Items.Add(rt)
                        '并显示其下对应的子菜单
                        If Not dtMenuSub Is Nothing And dtMenuSub.Rows.Count > 0 Then
                            LoadSubMenu(rb, dtMenuSub, menuKey)
                        End If
                    End If
                Next
            Else
                MessageUtils.ShowError("提示：未查询到当前用户的菜单项，请检查网络或用户权限")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("创建菜单时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 加载子菜单
    ''' </summary>
    ''' <param name="rb">子菜单容器控件</param>
    ''' <param name="dtSub">子菜单列表</param>
    ''' <param name="Tparent">当前主菜单的Tkey</param>
    ''' <remarks></remarks>
    Private Sub LoadSubMenu(ByRef rb As RibbonBar, ByVal dtSub As DataTable, ByVal Tparent As String)
        Try
            '获取当前主菜单下的所有子菜单
            Dim conditions As String = "Tparent='" & Tparent & "'"
            Dim drs() As DataRow = dtSub.Select(conditions)

            '查看其数据
            'Dim dt As New DataTable
            'dt = dtSub.Clone()
            'For i As Integer = 0 To drs.Length - 1
            '    dt.ImportRow(drs(i))
            'Next

            '数据列字段
            Dim menuKey As String = ""
            Dim menuText As String = ""
            Dim menuImge As String = ""
            Dim menuTreeTag As String = ""
            Dim IsMdiChildren As String = ""

            '循环加载子菜单
            For Each dr As DataRow In drs
                menuKey = IIf(IsDBNull(dr("Tkey")), "", dr("Tkey").ToString)


                If Language = "简体中文" Then
                    menuText = IIf(IsDBNull(dr("Ttext")), "", dr("Ttext").ToString)
                End If
                If Language = "繁體中文" Then
                    menuText = IIf(IsDBNull(dr("TWname")), "", dr("TWname").ToString)
                End If
                If Language = "English" Then
                    menuText = IIf(IsDBNull(dr("Enname")), "", dr("Enname").ToString)
                End If
                If Language = "Vi?t nam" Or Language = "Việt nam" Then
                    menuText = IIf(IsDBNull(dr("VNname")), "", dr("VNname").ToString)
                End If

                menuImge = IIf(IsDBNull(dr("ImageName")), "", dr("ImageName").ToString)
                menuTreeTag = IIf(IsDBNull(dr("TreeTag")), "", dr("TreeTag").ToString)
                IsMdiChildren = IIf(IsDBNull(dr("IsMdiChildren")), "", dr("IsMdiChildren").ToString)
                '按子菜单生成按钮对像
                Dim btn = New ButtonItem()
                btn.Name = menuKey
                If Language = "English" Or Language = "Vi?t nam" Or Language = "Việt nam" Then
                    If menuText.Length > 12 Then
                        btn.Text = menuText.Substring(0, 12) '+ "..."
                        btn.Tooltip = menuText
                    Else
                        btn.Text = menuText
                        btn.Tooltip = menuText
                    End If
                Else
                    btn.Text = menuText
                End If

                Dim menuImgePath As String = menuImge

                If String.IsNullOrEmpty(menuImge) = False Then
                    menuImge = menuImge.Substring(0, menuImge.LastIndexOf("."))
                End If
                '找菜单图片资源
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(menuImge)
                If Not obj Is Nothing Then
                    btn.ButtonStyle = eButtonStyle.ImageAndText
                    btn.ImagePosition = eImagePosition.Top
                    btn.Image = CType(obj, Image)
                Else
                    '资源文件不存在 直接取数据库路径图片 关晓艳 2019/1/28
                    If Dir(menuImgePath) = "" AndAlso InStr(menuImgePath, "http") <= 0 Then
                        menuImgePath = "\\192.168.20.123\PrintFile2\SFC_Icon\up.png"
                        btn.Image = Image.FromFile(menuImgePath)
                    ElseIf Dir(menuImgePath) <> "" Then
                        btn.Image = Image.FromFile(menuImgePath)
                    Else
                        Dim web As System.Net.WebClient = New System.Net.WebClient()
                        Dim buffer() As Byte = web.DownloadData(menuImgePath)
                        web.Dispose()
                        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(buffer)
                        Dim img As Image = Image.FromStream(stream)
                        btn.Image = Image.FromStream(stream)
                    End If

                    btn.ButtonStyle = eButtonStyle.ImageAndText
                    btn.ImagePosition = eImagePosition.Top
                    
                End If
                btn.SubItemsExpandWidth = 14
                btn.Tag = menuTreeTag
                btn.KeyTips = IsMdiChildren

                '按钮点击事件
                AddHandler btn.Click, AddressOf Btn_Click
                '控件加载到界面上
                rb.Items.Add(btn)
            Next
        Catch ex As Exception
            MessageUtils.ShowError("创建子菜单时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "菜单点击事件"
    ''' <summary>
    ''' 通用子菜单点击事件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Click(ByVal Sender As Object, ByVal e As EventArgs)
        Dim bi = CType(Sender, ButtonItem)
        PanPic.Visible = False
        Select Case bi.Text
            Case "显示功能区"
                SetBackground()
            Case "文本文档"
                Process.Start("notepad.exe")
            Case "计算器"
                Process.Start("calc.exe")
            Case Else
                Dim IsMdiChildren As Boolean = Convert.ToBoolean(bi.KeyTips)
                ShowForm(bi.Tag, bi.Text, IsMdiChildren)
                SetOpenMenuInfo(bi.Name, bi.Tag, bi.Text)   '保存打开的窗体
                If IsMdiChildren = False And TabStrip1.Tabs.Count = 0 Then
                    SetBackground()
                End If
        End Select
    End Sub
#End Region

#Region "设置主界面背景"

    ''' <summary>
    ''' 设置背景图
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBackground()
        ''异步线程操作，解决控件闪烁问题 by hske
        If Not worker.IsBusy Then
            worker.RunWorkerAsync()
        End If
    End Sub
    Private Sub SetBackgroundLoad()
        Dim mainbg = "http://mes.luxshare-ict.com/bg/BackgroundPic.png" '采用网络背景图
        'Dim sql = "select PARAMETER_CODE,PARAMETER_NAME,PARAMETER_VALUES from m_SystemSetting_t " & vbCrLf &
        '           "where MODE_NAME='MES' and PARAMETER_CODE='mainbg' and PARAMETER_NAME='Y'"
        Try
            Dim dt = Dtbg ' DbOperateUtils.GetDataTable(sql)
            If Not dt Is Nothing And dt.Rows.Count > 0 Then
                mainbg = dt.Rows(0)("PARAMETER_VALUES").ToString()
            Else
                mainbg = ""
            End If

            '是否显示背景图,最近操作不显示
            'PanPic.Visible = True
            If mainbg <> "" And IsWebFileExist(mainbg) Then
                'Dim PicPath = Application.StartupPath + "\\BackgroundPic.png"
                PanPic.BackgroundImage = Image.FromStream(System.Net.WebRequest.Create(mainbg).GetResponse().GetResponseStream())
                ItemContainer1.TitleStyle.TextColor = Color.White
                ItemContainer2.TitleStyle.TextColor = Color.White
            Else
                PanPic.BackgroundImage = Global.MesSystem.My.Resources.logobackground
                'Me.MetroTilePanel1.Visible = True   '6个小面板可见
                ItemContainer1.TitleStyle.TextColor = Color.Black
                ItemContainer2.TitleStyle.TextColor = Color.Black
            End If

            ' ShowNotice()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Function IsWebFileExist(ByVal uri As String) As Boolean
        Dim req As Net.HttpWebRequest = Nothing
        Dim res As Net.HttpWebResponse = Nothing
        Try
            req = CType(Net.WebRequest.Create(uri), Net.HttpWebRequest)
            req.Method = "HEAD"
            req.Timeout = 100
            res = CType(req.GetResponse(), Net.HttpWebResponse)
            Return (res.StatusCode = Net.HttpStatusCode.OK)
        Catch
            Return False
        Finally
            If Not res Is Nothing Then
                res.Close()
                res = Nothing
            End If
            If Not req Is Nothing Then
                req.Abort()
                req = Nothing
            End If
        End Try
    End Function
#End Region

#Region "保存打开的窗体信息"
    ''' <summary>
    ''' 保存打开的窗体信息
    ''' </summary>
    ''' <param name="Tkey">菜单Key</param>
    ''' <param name="TreeTag">子窗体Tag字符串对象</param>
    ''' <param name="FromText">窗体Text名称</param>
    ''' <remarks></remarks>
    Private Sub SetOpenMenuInfo(ByVal Tkey As String, ByVal TreeTag As String, ByVal FromText As String)
        Try
            Dim WorkStation = System.Net.Dns.GetHostName() '电脑名称
            Dim UseId = VbCommClass.VbCommClass.UseId
            Dim sql = String.Format(" exec Proc_ModifyTopMenu '{0}','{1}',N'{2}','{3}',N'{4}'",
            Tkey, TreeTag, FromText, UseId, WorkStation)
            DbOperateUtils.ExecSQL(sql)
        Catch ex As Exception
            'MessageUtils.ShowError("保存打开窗体信息出现异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub
#End Region

#Region "打开6个最近菜单信息"

    ''' <summary>
    ''' 最近打开6个菜单信息及图片
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTopSixMenu()
        Try
            '6个常用菜单
            'Dim sql = "select top 6 isnull(a.Tkey,b.Tkey) Tkey,a.APID,a.APNAME,isnull(b.ImageName,'')ImageName " & vbCrLf &
            '                    ",isnull(b.IsMdiChildren,'True') IsMdiChildren" & vbCrLf &
            '            "from M_APPSERVICECONDITION_T a" & vbCrLf &
            '                    "left join m_Logtree_t  b on b.TreeTag=a.APID and  isnull(a.Tkey,b.Tkey)=b.Tkey" & vbCrLf &
            '            "where a.USERID='" & VbCommClass.VbCommClass.UseId & "' and b.Usey='Y'" & vbCrLf &
            '            "group by a.APID,a.APNAME,b.ImageName,isnull(a.Tkey,b.Tkey),isnull(b.IsMdiChildren,'True')" & vbCrLf &
            '            "order by max(a.USETIME) desc "

            Dim dt = DtSixMenu ' DbOperateUtils.GetDataTable(sql)
            If Not dt Is Nothing And dt.Rows.Count > 0 Then
                Dim iIndex As Integer = 0
                Dim sTkey As String
                Dim sAPId As String
                Dim sAPName As String
                Dim sImageName As String
                Dim IsMdiChildren As String
                Dim menuImgePath As String   '图标完整路径 关晓艳 2019/1/28
                Dim stream As System.IO.MemoryStream   'url图片

                For Each dr As DataRow In dt.Rows
                    sTkey = IIf(IsDBNull(dr("Tkey")), "", dr("Tkey").ToString)
                    sAPId = IIf(IsDBNull(dr("APID")), "", dr("APID").ToString)
                    If Language = "简体中文" Then
                        sAPName = IIf(IsDBNull(dr("Ttext")), "", dr("Ttext").ToString)
                    ElseIf Language = "繁體中文" Then
                        sAPName = IIf(IsDBNull(dr("TWname")), "", dr("TWname").ToString)
                    ElseIf Language = "English" Then
                        sAPName = IIf(IsDBNull(dr("Enname")), "", dr("Enname").ToString)
                    Else
                        sAPName = IIf(IsDBNull(dr("VNname")), "", dr("VNname").ToString)
                    End If
                    'sAPName = IIf(IsDBNull(dr("APNAME")), "", dr("APNAME").ToString)
                    sImageName = IIf(IsDBNull(dr("ImageName")), "", dr("ImageName").ToString)
                    IsMdiChildren = IIf(IsDBNull(dr("IsMdiChildren")), "", dr("IsMdiChildren").ToString)

                    Dim ImageObj = ""
                    If String.IsNullOrEmpty(sImageName) = False Then
                        menuImgePath = sImageName  '图标完整路径
                        If sImageName.IndexOf(".") > 0 Then
                            ImageObj = sImageName.Substring(0, sImageName.IndexOf("."))
                        End If
                    End If
                    Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)

                    'lblTopTwo.AccessibleName = dt.Rows(1)("Tkey").ToString() + ";" + dt.Rows(1)("IsMdiChildren").ToString()
                    'lblTopTwo.AccessibleDescription = dt.Rows(1)("APID").ToString()

                    '判断是网络路径 进行转化   关晓艳2019/1/29
                    If InStr(menuImgePath, "http") > 0 Then
                        Dim web As System.Net.WebClient = New System.Net.WebClient()
                        Dim buffer() As Byte = web.DownloadData(menuImgePath)
                        web.Dispose()
                        stream = New System.IO.MemoryStream(buffer)
                    End If

                    iIndex = iIndex + 1
                    Select Case iIndex
                        Case 1
                            Me.MetroTileItem1.Text = sAPName
                            'Me.MetroTileItem1.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            If Not obj Is Nothing Then
                                Me.MetroTileItem1.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem1.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem1.Image = Image.FromFile(menuImgePath)
                            End If
                            Me.MetroTileItem1.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem1.AccessibleDescription = sAPId
                        Case 2
                            Me.MetroTileItem2.Text = sAPName
                            'Me.MetroTileItem2.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            If Not obj Is Nothing Then
                                Me.MetroTileItem2.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem2.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem2.Image = Image.FromFile(menuImgePath)
                            End If
                            Me.MetroTileItem2.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem2.AccessibleDescription = sAPId
                        Case 3
                            Me.MetroTileItem3.Text = sAPName
                            'Me.MetroTileItem3.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            If Not obj Is Nothing Then
                                Me.MetroTileItem3.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem3.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem3.Image = Image.FromFile(menuImgePath)
                            End If
                            Me.MetroTileItem3.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem3.AccessibleDescription = sAPId
                        Case 4
                            Me.MetroTileItem4.Text = sAPName
                            'Me.MetroTileItem4.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            If Not obj Is Nothing Then
                                Me.MetroTileItem4.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem4.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem4.Image = Image.FromFile(menuImgePath)
                            End If
                            Me.MetroTileItem4.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem4.AccessibleDescription = sAPId
                        Case 5
                            Me.MetroTileItem5.Text = sAPName
                            ' Me.MetroTileItem5.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            'Me.MetroTileItem5.Image = IIf(Not obj Is Nothing, CType(obj, Image), Image.FromFile(menuImgePath))
                            If Not obj Is Nothing Then
                                Me.MetroTileItem5.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem5.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem5.Image = Image.FromFile(menuImgePath)
                            End If

                            Me.MetroTileItem5.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem5.AccessibleDescription = sAPId
                        Case 6
                            Me.MetroTileItem6.Text = sAPName
                            ' Me.MetroTileItem6.Image = IIf(Not obj Is Nothing, CType(obj, Image), Nothing)
                            If Not obj Is Nothing Then
                                Me.MetroTileItem6.Image = CType(obj, Image)
                            ElseIf InStr(menuImgePath, "http") > 0 Then
                                Me.MetroTileItem6.Image = Image.FromStream(stream)
                            Else
                                Me.MetroTileItem6.Image = Image.FromFile(menuImgePath)
                            End If
                            Me.MetroTileItem6.AccessibleName = sTkey + ";" + IsMdiChildren
                            Me.MetroTileItem6.AccessibleDescription = sAPId
                    End Select
                Next
            End If
            MetroTilePanel1.Visible = True
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

#End Region

#Region "标准事件"



    Dim worker As BackgroundWorker = Nothing
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf worker_DoWork

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Try
            SetPanelVisible(True, PanPic)
        Catch ex As Exception

        End Try
    End Sub
    Delegate Sub SetPanelVisibleCallback(ByVal val As Boolean, ByVal obj As Panel)
    Sub SetPanelVisible(ByVal TValue As Boolean, ByVal TempC As Panel)
        Try
            Dim obj As Panel = CType(TempC, Panel)
            If (obj.InvokeRequired) Then
                Dim d As SetPanelVisibleCallback = New SetPanelVisibleCallback(AddressOf SetPanelVisible)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.Visible = TValue
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' 窗体默认加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMainDynamic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InLoadFactoryList() '加载本公司/工厂下面所有生产工厂列表或者利润中心列表
            InLoadData() '一次载入所有需要的数据，避免多次打开数据库--by hs ke,

            SetUI()             '界面UI基本设置（此项必须最先调用）
            ShowLoginInfo()     '显示当前登录信息
            ShowCurDutyUser()   '值班信息
            ShowServerInfo()    '服务器信息           
            LoadMenu()          '加载菜单
            ShowTopSixMenu()    '获取6个常用菜单
            ShowNotice()        '显示公告信息

        Catch ex As Exception
            MessageUtils.ShowError("系统加载异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 页签关闭事件
    ''' 关闭所有子窗口，仅显示主页常用功能页
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabStrip1_TabItemClose(sender As Object, e As TabStripActionEventArgs)
        If TabStrip1.Tabs.Count = 1 Then
            SetBackground()
        End If
    End Sub

    ''' <summary>
    ''' 窗口关闭前事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMainDynamic_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ''' <summary>
    ''' 界面皮肤样式变化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxStyle_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If Me.cbxStyle.SelectedIndex >= 0 Then
                Dim StyleIndex As Integer = Me.cbxStyle.SelectedIndex
                Me.StyleManager1.ManagerStyle = [Enum].Parse((GetType(eStyle)), CType(Me.cbxStyle.SelectedItem, DevComponents.Editors.ComboItem).Text)
                '更新用户样式设置
                Dim sql As String = "update m_Users_t set StyleID='" & StyleIndex.ToString & "' where UserID='" & VbCommClass.VbCommClass.UseId & "' "
                DbOperateUtils.ExecSQL(sql)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 6个常用功能按钮的，通用点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MetroTileItem_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click, MetroTileItem2.Click, MetroTileItem3.Click, MetroTileItem4.Click, MetroTileItem5.Click, MetroTileItem6.Click
        Try
            Dim obj As DevComponents.DotNetBar.Metro.MetroTileItem = CType(sender, DevComponents.DotNetBar.Metro.MetroTileItem)

            For index = 1 To 6
                If obj.Name = "MetroTileItem" + index.ToString Then
                    Me.PanPic.Visible = False
                    Dim IsMdiChildren As Boolean = Convert.ToBoolean(obj.AccessibleName.Split(";")(1))
                    ShowForm(obj.AccessibleDescription, obj.Text, IsMdiChildren)
                    Dim Tkey = obj.AccessibleName.Split(";")(0)
                    '保存打开的窗体
                    SetOpenMenuInfo(Tkey, obj.AccessibleDescription, obj.Text)
                    If IsMdiChildren = False Then
                        '  SetBackground()
                    End If
                    Return
                End If
            Next
        Catch ex As Exception
            MessageUtils.ShowError("点击菜单发生异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 链接并登录到SPC系统
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub metroLinkSPC_Click(sender As Object, e As EventArgs) Handles metroLinkSPC.Click
        Dim spcURL As String = "http://spc.luxshare-ict.com/Account/Login?loginkey=" & SysBasicClass.DESEncrypt.GetLoginKey(SysMessageClass.UseId)
        System.Diagnostics.Process.Start(spcURL)
    End Sub

    ''' <summary>
    ''' 页签索引变化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabStrip1_TabIndexChanged(sender As Object, e As EventArgs)
    End Sub

    ''' <summary>
    ''' 页签选择变化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabStrip1_SelectedTabChanged(sender As Object, e As TabStripTabChangedEventArgs)
        If Me.TabStrip1.SelectedTabIndex >= 0 Then
            '切换页签窗体时，如果当前显示主页小面板，则将其隐藏，让窗体可见
            If Me.MetroTilePanel1.Visible = True Then
                Me.PanPic.Visible = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' SOP按钮事件：单击
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_Click(sender As Object, e As EventArgs) Handles HelpSOP.Click
        Try
            Dim Help As New HelpSOP(Me.TabStrip1.SelectedTab.Text)
            Help.ShowDialog()
        Catch ex As Exception
            Dim Help As New HelpSOP("Maximization")
            Help.ShowDialog()
        End Try
    End Sub

    ''' <summary>
    ''' SOP按钮事件：鼠标进入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_MouseEnter(sender As Object, e As EventArgs) Handles HelpSOP.MouseEnter
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X - 30, Y)
    End Sub

    ''' <summary>
    ''' SOP按钮事件：鼠标离开
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_MouseLeave(sender As Object, e As EventArgs) Handles HelpSOP.MouseLeave
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X + 30, Y)
    End Sub

    ''' <summary>
    ''' 公告详情
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdvDetail_Click(sender As Object, e As EventArgs)
        Dim frmAdv As FrmAdv = New FrmAdv
        frmAdv.ShowDialog()
    End Sub
#End Region

    Private Sub metroLinkWebSFC_Click(sender As Object, e As EventArgs) Handles metroLinkWebSFC.Click
        Dim spcURL As String = "http://mes.luxshare-ict.com:8118/Board/WorkOrder?type=B"
        System.Diagnostics.Process.Start(spcURL)
    End Sub

    Private Sub AppCommandFactory_Executed(sender As Object, e As EventArgs) Handles AppCommandFactory.Executed
        Dim source As ICommandSource = TryCast(sender, ICommandSource)
        If TypeOf source.CommandParameter Is String Then
            Dim factoryStr As String = source.CommandParameter.ToString()
            Dim _PCompany As String = VbCommClass.VbCommClass.PCompany
            Dim _Factory As String = VbCommClass.VbCommClass.Factory
            Dim _profitcenter As String = VbCommClass.VbCommClass.profitcenter
            Dim factoryid As String = factoryStr.ToString.Split("(")(0).ToString
            Dim LoadIP As String = GetIPAddress()
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                VbCommClass.VbCommClass.Factory = factoryid
                btnTitle.Text = String.Format("立讯精密MES现场执行管理系统(公司代码:{0} 工厂代码:{1} 当前用户:{2} IP：{3}) ", VbCommClass.VbCommClass.PCompany, factoryStr.ToString, SysMessageClass.UseId, LoadIP)
            Else
                VbCommClass.VbCommClass.profitcenter = factoryid
                btnTitle.Text = String.Format("立讯精密MES现场执行管理系统(营运中心:{0} 利润中心:{1} 当前用户:{2} IP：{3}) ", VbCommClass.VbCommClass.PCompany, factoryStr.ToString, SysMessageClass.UseId, LoadIP)

            End If
            btnTitle.Refresh()
            RibbonControl1.Refresh()
        End If
    End Sub

End Class