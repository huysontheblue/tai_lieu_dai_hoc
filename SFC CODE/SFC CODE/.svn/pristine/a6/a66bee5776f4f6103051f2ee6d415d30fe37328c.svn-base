Imports DevComponents.DotNetBar
Imports MainFrame
Imports MainFrame.SysCheckData
Imports RouteManagement

''' <summary>
''' 新版本动态菜单加载
''' add by 马跃平 2018-07-26
''' </summary>
''' <remarks></remarks>
Public Class FrmMesMain
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

#Region "窗体加载事件"
    ''' <summary>
    ''' 窗体加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMesMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetTitleInfo()
            SetCurDutyUser()
            SetMainFormInfo()
            GetTopSixMenu()
            LoadMenu()
        Catch ex As Exception
            MessageUtils.ShowError("系统出现异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "窗体关闭事件"
    ''' <summary>
    ''' 窗体关闭事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMesMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        System.Environment.Exit(0)
    End Sub
#End Region

#Region "设置背景色"
    ''' <summary>
    ''' 设置背景色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBackground()
        Dim mainbg = "N"
        Dim sql = "select PARAMETER_CODE,PARAMETER_VALUES from m_SystemSetting_t " & vbCrLf &
        "where MODE_NAME='MES' and PARAMETER_CODE='mainbg'"
        Dim dt = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            mainbg = dt.Rows(0)("PARAMETER_VALUES").ToString()
        End If
        If mainbg = "Y" Then
            Dim PicPath = Application.StartupPath + "\\BackgroundPic.png"
            If System.IO.File.Exists(PicPath) Then
                PanPic.Visible = True
                PanPic.BackgroundImage = Image.FromFile(PicPath)
                gpTop.Visible = False
            End If
        Else
            PanPic.Visible = True
            PanPic.BackgroundImage = Global.MesSystem.My.Resources.logobackground
            gpTop.Visible = True
        End If
        GetTopSixMenu()
    End Sub
#End Region

#Region "获取当前用户的电脑IP"
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
#End Region

#Region "窗体标题信息"
    ''' <summary>
    ''' 窗体标题信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTitleInfo()
        Dim xmldoc As New Xml.XmlDocument
        Try
            Dim LoadFactory As String = ""
            Dim LoadProfitCenter As String = ""
            Dim LoadIP As String = ""
            xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '讀取XML中的上次登錄用戶名
            Dim nodeList As Xml.XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As Xml.XmlNode In nodeList
                If LCase(xn.Name) = "servername" Then
                    LoadFactory = xn.InnerText
                    Continue For
                End If

                If LCase(xn.Name) = "profitcenter" Then
                    LoadProfitCenter = xn.InnerText
                    Continue For
                End If
            Next

            LoadIP = GetIPAddress()
            ButTitle.Text += String.Format("(营运中心:{0} 利润中心:{1} 当前用户:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub
#End Region

#Region "值班信息"
    ''' <summary>
    ''' 值班信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCurDutyUser()
        Dim strSQL As String = " exec [usp_Duty_WeekPlan] '{0}','2' "
        strSQL = String.Format(strSQL, "")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            LblUser.Text = dt.Rows(0)(0).ToString
        End If
    End Sub
#End Region

#Region "获取数据库服务器名称"
    ''' <summary>
    ''' 获取数据库服务器名称
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMainFormInfo()
        Dim serverName As String = MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName.ToString
        If serverName.Contains("DG-MESDB.luxshare.com.cn") Then
            LblSname.Text = LblSname.Text & String.Format("正式区（{0}）", serverName.Split("=")(1).Split(";")(0))
        ElseIf serverName.Contains("172.18.20.170") Then
            LblSname.Text = LblSname.Text & String.Format("正式区（{0}）", serverName.Split("=")(1).Split(";")(0))
        Else
            LblSname.Text = LblSname.Text & String.Format("测试区（{0}）", serverName.Split("=")(1).Split(";")(0))
            LblUser.Visible = False
        End If
    End Sub
#End Region

#Region "最近打开6个菜单信息及图片"
    ''' <summary>
    ''' 最近打开6个菜单信息及图片
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetTopSixMenu()
        Dim UserID = VbCommClass.VbCommClass.UseId
        Dim sql = "select   top 6 isnull(a.Tkey,b.Tkey) Tkey,a.APID,a.APNAME,isnull(b.ImageName,'')ImageName " & vbCrLf &
        ",isnull(b.IsMdiChildren,'True') IsMdiChildren" & vbCrLf &
        "from M_APPSERVICECONDITION_T a" & vbCrLf &
        "left join m_Logtree_t  b on b.TreeTag=a.APID and  isnull(a.Tkey,b.Tkey)=b.Tkey" & vbCrLf &
        "where a.USERID='" & UserID & "' and b.Usey='Y'" & vbCrLf &
        "group by a.APID,a.APNAME,b.ImageName,isnull(a.Tkey,b.Tkey),isnull(b.IsMdiChildren,'True')" & vbCrLf &
        "order by max(a.USETIME) desc"
        Dim dt = DbOperateUtils.GetDataTable(sql)

        If dt.Rows.Count > 0 Then
            lblTopOne.Text = dt.Rows(0)("APNAME").ToString()
            lblTopOne.AccessibleName = dt.Rows(0)("Tkey").ToString() + ";" + dt.Rows(0)("IsMdiChildren").ToString()
            lblTopOne.AccessibleDescription = dt.Rows(0)("APID").ToString()
            Dim ImageName = dt.Rows(0)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopOne.Image = CType(obj, Image)
            Else
                PicTopOne.Image = Nothing
            End If
        Else
            lblTopOne.Text = Nothing
        End If

        If dt.Rows.Count > 1 Then
            lblTopTwo.Text = dt.Rows(1)("APNAME").ToString()
            lblTopTwo.AccessibleName = dt.Rows(1)("Tkey").ToString() + ";" + dt.Rows(1)("IsMdiChildren").ToString()
            lblTopTwo.AccessibleDescription = dt.Rows(1)("APID").ToString()
            Dim ImageName = dt.Rows(1)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopTwo.Image = CType(obj, Image)
            Else
                PicTopTwo.Image = Nothing
            End If
        Else
            lblTopTwo.Text = Nothing
        End If

        If dt.Rows.Count > 2 Then
            lblTopThree.Text = dt.Rows(2)("APNAME").ToString()
            lblTopThree.AccessibleName = dt.Rows(2)("Tkey").ToString() + ";" + dt.Rows(2)("IsMdiChildren").ToString()
            lblTopThree.AccessibleDescription = dt.Rows(2)("APID").ToString()
            Dim ImageName = dt.Rows(2)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopThree.Image = CType(obj, Image)
            Else
                PicTopThree.Image = Nothing
            End If
        Else
            lblTopThree.Text = Nothing
        End If

        If dt.Rows.Count > 3 Then
            lblTopFour.Text = dt.Rows(3)("APNAME").ToString()
            lblTopFour.AccessibleName = dt.Rows(3)("Tkey").ToString() + ";" + dt.Rows(3)("IsMdiChildren").ToString()
            lblTopFour.AccessibleDescription = dt.Rows(3)("APID").ToString()
            Dim ImageName = dt.Rows(3)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopFour.Image = CType(obj, Image)
            Else
                PicTopFour.Image = Nothing
            End If
        Else
            lblTopFour.Text = Nothing
        End If

        If dt.Rows.Count > 4 Then
            lblTopFive.Text = dt.Rows(4)("APNAME").ToString()
            lblTopFive.AccessibleName = dt.Rows(4)("Tkey").ToString() + ";" + dt.Rows(4)("IsMdiChildren").ToString()
            lblTopFive.AccessibleDescription = dt.Rows(4)("APID").ToString()
            Dim ImageName = dt.Rows(4)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopFive.Image = CType(obj, Image)
            Else
                PicTopFive.Image = Nothing
            End If
        Else
            lblTopFive.Text = Nothing
        End If

        If dt.Rows.Count > 5 Then
            lblTopSix.Text = dt.Rows(5)("APNAME").ToString()
            lblTopSix.AccessibleName = dt.Rows(5)("Tkey").ToString() + ";" + dt.Rows(5)("IsMdiChildren").ToString()
            lblTopSix.AccessibleDescription = dt.Rows(5)("APID").ToString()
            Dim ImageName = dt.Rows(5)("ImageName").ToString().Trim()
            Dim ImageObj = ""
            If String.IsNullOrEmpty(ImageName) = False Then
                If ImageName.IndexOf(".") > 0 Then
                    ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                End If
            End If
            Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
            If Not obj Is Nothing Then
                PicTopSix.Image = CType(obj, Image)
            Else
                PicTopSix.Image = Nothing
            End If
        Else
            lblTopSix.Text = Nothing
        End If

        Dim strSql As String = "select top 1 title,contents from m_Advert_t where usey='Y' order by intime desc"
        Dim dt1 As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt1.Rows.Count > 0 Then
            RichtxtNotice.Text = dt1.Rows(0)("contents").ToString
            GroupPanel1.Text = dt1.Rows(0)("title").ToString
            'GroupPanel1.Visible = True
        Else
            RichtxtNotice.Text = ""
            GroupPanel1.Text = "系统公告"
            'GroupPanel1.Visible = False
        End If

    End Sub
#End Region

#Region "前6个快捷菜单共通点击事件"
    ''' <summary>
    ''' 前6个快捷菜单共通点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblTopOne.Click, lblTopTwo.Click, lblTopThree.Click, lblTopSix.Click, lblTopFour.Click, lblTopFive.Click
        Try
            PanPic.Visible = False
            Dim lbl = CType(sender, Label)
            Dim IsMdiChildren As Boolean = Convert.ToBoolean(lbl.AccessibleName.Split(";")(1))
            ShowForm(lbl.AccessibleDescription, lbl.Text, IsMdiChildren)
            Dim Tkey = lbl.AccessibleName.Split(";")(0)
            SetOpenMenuInfo(Tkey, lbl.AccessibleDescription, lbl.Text)
            If IsMdiChildren = False Then
                SetBackground()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("点击菜单发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "加载系统菜单"
    ''' <summary>
    ''' 加载系统菜单
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMenu()
        Dim sql = "exec Pro_GetSysMenu '" & VbCommClass.VbCommClass.UseId & "'"
        Dim dtFirst = DbOperateUtils.GetDataTable(sql)
        Dim num As Integer = 0
        For Each dr As DataRow In dtFirst.Rows '加载一级菜单
            Dim rtt = New RibbonTabItem() '建立一个页签
            rtt.Name = dr("Tkey").ToString()
            rtt.Text = dr("Ttext").ToString()

            Dim rp = New RibbonPanel() '建立一个页签面板
            rtt.Panel = rp
            rp.Location = New System.Drawing.Point(0, 54)
            rp.Dock = System.Windows.Forms.DockStyle.Fill
            rp.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            rp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            RibbonControl1.Controls.Add(rp)
            RibbonControl1.Items.Add(rtt)
            If num = 0 Then
                rtt.Checked = True '第一个页签为选中状态
            Else
                rtt.Checked = False
            End If
            Dim rb = New RibbonBar() '建立一个带状条Bar
            rb.Dock = System.Windows.Forms.DockStyle.Fill
            rb.TitleVisible = False
            rb.Size = New System.Drawing.Size(1354, 96)
            rb.VerticalItemAlignment = eVerticalItemsAlignment.Middle
            rp.Controls.Add(rb)


            sql = "select Tkey,Tparent,Ttext,TreeTag,Usey, isnull(IsMdiChildren,'True') " & vbCrLf &
        "IsMdiChildren,OrderBy,ImageName from m_Logtree_t " & vbCrLf &
         "where Tkey in" & vbCrLf &
         "(" & vbCrLf &
         "select  Tkey from m_UserRight_t" & vbCrLf &
         "where UserID='" & VbCommClass.VbCommClass.UseId & "'" & vbCrLf &
         ") and Usey='Y' and listy='Y' and Tparent='" & rtt.Name & "'" & vbCrLf &
         "order by isnull(OrderBy,10000)"
            Dim dtSecond = DbOperateUtils.GetDataTable(sql)
            '循环加载二级菜单
            For Each drTwo As DataRow In dtSecond.Rows
                Dim bi = New ButtonItem() '按钮对象
                bi.Text = drTwo("Ttext").ToString()
                bi.Name = drTwo("Tkey").ToString()
                Dim ImageName = drTwo("ImageName").ToString()
                If String.IsNullOrEmpty(ImageName) = False Then
                    ImageName = ImageName.Substring(0, ImageName.LastIndexOf("."))
                End If
                '找菜单图片资源
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageName)
                If Not obj Is Nothing Then
                    bi.ButtonStyle = eButtonStyle.ImageAndText
                    bi.ImagePosition = eImagePosition.Top
                    bi.Image = CType(obj, Image)
                End If
                bi.SubItemsExpandWidth = 14
                bi.Tag = drTwo("TreeTag").ToString()
                bi.KeyTips = drTwo("IsMdiChildren").ToString()
                AddHandler bi.Click, AddressOf Btn_Click
                rb.Items.Add(bi)
            Next
            num = num + 1

        Next
    End Sub
#End Region

#Region "菜单点击事件"
    ''' <summary>
    ''' 菜单点击事件
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
                SetOpenMenuInfo(bi.Name, bi.Tag, bi.Text)
                If IsMdiChildren = False And TabStrip1.Tabs.Count = 0 Then
                    SetBackground()
                End If
        End Select
    End Sub
#End Region

#Region "显示子窗口"
    ''' <summary>
    ''' 显示子窗口
    ''' </summary>
    ''' <param name="Tag">子窗体Tag字符串对象</param>
    ''' <param name="FromText">菜单窗体名称</param>
    ''' <param name="IsMdiChildren">是否是MdiChildren窗体</param>
    ''' <remarks></remarks>
    Private Sub ShowForm(ByVal Tag As String, ByVal FromText As String, ByVal IsMdiChildren As Boolean)
        Try
            If String.IsNullOrEmpty(Tag) = False Then
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
        Catch ex As Exception
            MessageUtils.ShowError("打开子窗体异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
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
            MessageUtils.ShowError("保存打开窗体信息出现异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region


#Region "定时5分钟刷新值班信息"
    ''' <summary>
    ''' 定时5分钟刷新值班信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SetCurDutyUser()
    End Sub
#End Region

#Region "SPC单点登录"
    ''' <summary>
    ''' SPC单点登录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picSPC_Click(sender As Object, e As EventArgs) Handles picSPC.Click
        Dim spcURL As String = "http://spc.luxshare-ict.com/Account/Login?loginkey=" & SysBasicClass.DESEncrypt.GetLoginKey(SysMessageClass.UseId)
        System.Diagnostics.Process.Start(spcURL)
    End Sub
#End Region

#Region "TabStrip Tab页签关闭事件,关闭所有的Mdi子菜单就显示背景图片"
    ''' <summary>
    ''' TabStrip Tab页签关闭事件,关闭所有的Mdi子菜单就显示背景图片
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabStrip1_TabItemClose(sender As Object, e As TabStripActionEventArgs) Handles TabStrip1.TabItemClose
        If TabStrip1.Tabs.Count = 1 Then
            SetBackground()
        End If
    End Sub
#End Region

#Region "SOP点击事件"
    ''' <summary>
    ''' SOP点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_Click(sender As Object, e As EventArgs) Handles HelpSOP.Click
        Try
            Dim Help As New HelpSOP(Me.TabStrip1.SelectedTab.Text.ToString)
            Help.ShowDialog()
        Catch ex As Exception
            Dim Help As New HelpSOP("Maximization")
            Help.ShowDialog()
        End Try
    End Sub
#End Region

#Region "SOP鼠标进入事件"
    ''' <summary>
    ''' SOP鼠标进入事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_MouseEnter(sender As Object, e As EventArgs) Handles HelpSOP.MouseEnter
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X - 24, Y)
    End Sub
#End Region

#Region "SOP鼠标离开事件"
    ''' <summary>
    ''' SOP鼠标离开事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HelpSOP_MouseLeave(sender As Object, e As EventArgs) Handles HelpSOP.MouseLeave
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X + 24, Y)
    End Sub
#End Region

End Class
