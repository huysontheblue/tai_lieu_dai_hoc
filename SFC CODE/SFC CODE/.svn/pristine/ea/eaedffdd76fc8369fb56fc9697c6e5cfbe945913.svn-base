Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Resources
Imports System.Reflection
Imports DevComponents.DotNetBar

Public Class Language

    Public Shared lang As String = "zh-chs"
    ''' <summary>  
    ''' 改变程序当前使用的语言特性  
    ''' </summary>
    ''' <param name="languageName">语言名称</param>  
    Public Shared Function SetLanguage(ByVal languageName As String) As Boolean
        Try
            '改变当前线程的UI资源文件  
            lang = languageName
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>  
    ''' 改变程序当前使用的语言特性  
    ''' </summary>  
    ''' <param name="languageName">语言名称</param>  
    ''' <param name="frm">Form类别</param>  
    ''' <returns></returns>  
    ''' <remarks></remarks>  
    Public Shared Function SetLanguage(ByVal languageName As String, ByVal frm As Form) As Boolean
        Try
            '改变当前线程的UI资源文件  
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageName)
            '改变当前线程的资源文件  
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(languageName)
            '创建一个资源管理器  
            Dim res As ComponentResourceManager = New ComponentResourceManager(frm.GetType)
            '将资源文件的内容更新至表单上 $this在资源文件中表示窗体本身。  
            res.ApplyResources(frm, "$this")
            '递归更新资源文件的内容到表单控件上  
            ApplyResouce(frm, res)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>  
    ''' 更新资源文件的内容到表单控件上  
    ''' </summary>  
    ''' <param name="control">要更新的控件</param>  
    ''' <param name="res">资源文件管理器</param>  
    '''   
    Private Shared Sub ApplyResouce(ByVal control As Control, ByVal res As ComponentResourceManager)
        For Each c As Control In control.Controls
            res.ApplyResources(c, c.Name)
            ApplyResouce(c, res)
            If c.GetType().IsSubclassOf(GetType(ToolStrip)) Then
                ApplyResouce(CType(c, ToolStrip), res)
            End If
        Next
    End Sub

    ''' <summary>  
    ''' set language for toolstrip all child item  
    ''' </summary>  
    ''' <param name="toolstrip"></param>  
    ''' <param name="resources"></param>  
    Private Shared Sub ApplyResouce(ByVal toolstrip As ToolStrip, ByVal resources As ComponentResourceManager)
        If toolstrip.Items.Count > 0 Then
            For Each item As ToolStripItem In toolstrip.Items
                ApplyResouce(item, resources)
            Next
        End If
    End Sub

    ''' <summary>  
    ''' 递归更新Menu的子菜单  
    ''' </summary>  
    ''' <param name="item"></param>  
    ''' <param name="resources"></param>  
    Private Shared Sub ApplyResouce(ByVal item As ToolStripItem, ByVal resources As ComponentResourceManager)

        resources.ApplyResources(item, item.Name)
        If (item.GetType.IsSubclassOf(GetType(ToolStripDropDownItem))) Then
            Dim ditem As ToolStripDropDownItem = CType(item, ToolStripDropDownItem)
            If ditem.DropDownItems.Count > 0 Then
                For Each sitem As ToolStripItem In ditem.DropDownItems
                    ApplyResouce(sitem, resources)
                Next
            End If
        End If
    End Sub

    'add by song
    '2016-08-03
    '获取窗口上的控件
    Public Shared Sub SetControlText(ByVal fm As Form)
        For Each c As Control In fm.Controls
            '设置窗口标题
            fm.Text = GetText(fm.Name, fm.Name)

            If (c.HasChildren And c.Name <> "mdiClient1") Then
                SetSubControlText(fm, c)
            End If

            If ((TypeOf c Is Label) Or (TypeOf c Is CheckBox) Or (TypeOf c Is Button) Or (TypeOf c Is TabPage) Or (TypeOf c Is GroupBox) Or (TypeOf c Is RadioButton) Or (TypeOf c Is DevComponents.DotNetBar.Controls.CheckBoxX)) Then
                c.Text = GetText(fm.Name, c.Name)
                '当为越南语时，字体设为Arial
                If MultLanguage.Language.lang = "vt" Then
                    c.Font = New System.Drawing.Font("Arial", 8)
                End If
            End If

            '当为越南语时，字体设为Arial
            If MultLanguage.Language.lang = "vt" Then
                c.Font = New System.Drawing.Font("Arial", 8)
            End If

            If (c.GetType().ToString = "System.Windows.Forms.MenuStrip") Then
                GetSubMenuStripText(fm.Name, c)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.ToolStrip") Then
                GetSubToolStripText(fm.Name, c)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.DataGridView") Then
                GetDataViewListText(fm.Name, c)
            ElseIf (c.GetType().ToString = "DevComponents.DotNetBar.RibbonControl") Then
                GetSubRibbonControlText(fm.Name, c)
            ElseIf (c.GetType().ToString = "DevComponents.DotNetBar.Controls.DataGridViewX") Then
                GetDataViewXListText(fm.Name, c)
            ElseIf (c.GetType().ToString = "DevComponents.DotNetBar.Bar") Then
                GetSubBarText(fm.Name, c)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.StatusStrip") Then
                GetSubStatusStripText(fm.Name, c)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.ToolStrip") Then
                GetSubToolStripText(fm.Name, c)
            End If
        Next
    End Sub

    'add by song
    '2016-08-05
    '获取窗口上的控件
    Private Shared Sub SetSubControlText(ByVal fm As Form, ByRef c As Control)
        Dim dd As String
        For Each d As Control In c.Controls
            If (d.HasChildren And d.Name <> "mdiClient1") Then
                SetSubControlText(fm, d)
            End If

            If ((TypeOf d Is Label) Or (TypeOf d Is CheckBox) Or (TypeOf d Is Button) Or (TypeOf d Is TabPage) Or (TypeOf d Is GroupBox) Or (TypeOf d Is RadioButton) Or (TypeOf d Is DevComponents.DotNetBar.Controls.CheckBoxX)) Then
                d.Text = GetText(fm.Name, d.Name)
                '当为越南语时，字体设为Arial
                If MultLanguage.Language.lang = "vt" Then
                    d.Font = New System.Drawing.Font("Arial", 8)
                End If
            End If

            'If (d.GetType.ToString = "System.Windows.Forms.ToolStrip") Then
            'd.Text = GetText(fm.Name, d.Name)
            'End If

            '当为越南语时，字体设为Arial
            If MultLanguage.Language.lang = "vt" Then
                d.Font = New System.Drawing.Font("Arial", 8)
            End If

            If (d.GetType.ToString = "DevComponents.DotNetBar.ButtonItem") Then
                d.Text = GetText(fm.Name, d.Name)
                '当为越南语时，字体设为Arial
                If MultLanguage.Language.lang = "vt" Then
                    c.Font = New System.Drawing.Font("Arial", 8)
                End If
            ElseIf (d.GetType().ToString = "System.Windows.Forms.ToolStrip") Then
                GetSubToolStripText(fm.Name, d)
            ElseIf (d.GetType().ToString = "System.Windows.Forms.DataGridView") Then
                GetDataViewListText(fm.Name, d)
            ElseIf (d.GetType().ToString = "DevComponents.DotNetBar.RibbonBar") Then
                GetSubRibbonBarText(fm.Name, d)
            ElseIf (d.GetType().ToString = "DevComponents.DotNetBar.Controls.DataGridViewX") Then
                GetDataViewXListText(fm.Name, d)
            ElseIf (d.GetType().ToString = "DevComponents.DotNetBar.Bar") Then
                GetSubBarText(fm.Name, d)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.StatusStrip") Then
                GetSubStatusStripText(fm.Name, d)
            ElseIf (c.GetType().ToString = "System.Windows.Forms.ToolStrip") Then
                GetSubToolStripText(fm.Name, d)
            End If
        Next
    End Sub

    'add by song
    '2016-08-08
    '获取ComboBox的列表值
    Private Shared Sub GetComboListText(ByRef fn As String, ByRef c As ComboBox)
        Dim i As Integer
        If c.Items.Count < 1 Then
            Return
        End If
        For i = 0 To c.Items.Count - 1
            'If (CheckComboBox(fn, c.Name & "_" & i.ToString) = False) Then
            '    SaveComboBox(fn, c.Name & "_" & i.ToString, c.GetItemText(c.Items(i)))
            'End If
        Next
    End Sub

    'add by song
    '2016-08-08
    '获取DataGridView的列值
    Private Shared Sub GetDataViewListText(ByRef fn As String, ByRef c As DataGridView)
        Dim i As Integer
        If c.Columns.Count < 1 Then
            Return
        End If
        For i = 0 To c.Columns.Count - 1
            c.Columns(i).HeaderText = GetText(fn, c.Name & "_" & i.ToString)
        Next
    End Sub

    'add by song
    '2016-09-28
    '获取DataGridViewX的列值
    Private Shared Sub GetDataViewXListText(ByRef fn As String, ByRef c As DevComponents.DotNetBar.Controls.DataGridViewX)
        Dim i As Integer
        If c.Columns.Count < 1 Then
            Return
        End If
        For i = 0 To c.Columns.Count - 1
            c.Columns(i).HeaderText = GetText(fn, c.Name & "_" & i.ToString)
        Next
    End Sub

    'add by song
    '2016-09-28
    '获取ButtonItem的列值
    Private Shared Sub GetSubBarText(ByRef fn As String, ByRef c As DevComponents.DotNetBar.Bar)
        Dim i As Integer
        If c.Items.Count < 1 Then
            Return
        End If
        For i = 0 To c.Items.Count - 1
            c.Items(i).Text = GetText(fn, c.Items(i).Name)
        Next
    End Sub

    'add by song
    '2016-09-30
    '获取StatusStrip下的Label值
    Private Shared Sub GetSubStatusStripText(ByRef fn As String, ByRef c As System.Windows.Forms.StatusStrip)
        Dim i As Integer
        If c.Items.Count < 1 Then
            Return
        End If
        For i = 0 To c.Items.Count - 1
            If (c.Items(i).GetType.ToString = "System.Windows.Forms.ToolStripStatusLabel") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
            End If
        Next
    End Sub

    'add by song
    '2016-08-08
    '获取ToolStripMenuItem控件的Text值
    Private Shared Sub GetSubMenuStripText(ByRef fn As String, ByRef c As MenuStrip)
        Dim i As Integer = 0
        For i = 0 To c.Items.Count - 1
            If (c.Items(i).GetType.ToString = "System.Windows.Forms.ToolStripMenuItem") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
            End If
        Next
    End Sub

    'add by song
    '2016-08-08
    '获取ToolStripMenuItem控件的Text值
    Private Shared Sub GetSubToolStripText(ByRef fn As String, ByRef c As ToolStrip)
        Dim i As Integer = 0
        For i = 0 To c.Items.Count - 1
            If (c.Items(i).GetType.ToString = "System.Windows.Forms.ToolStripButton") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
                c.Items(i).ToolTipText = c.Items(i).Text
            ElseIf (c.Items(i).GetType.ToString = "System.Windows.Forms.ToolStripLabel") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
            End If
        Next
    End Sub

    'add by song
    '2016-08-09
    '获取RibbonContrl控件的Text值
    Private Shared Sub GetSubRibbonControlText(ByRef fn As String, ByRef c As RibbonControl)
        Dim i As Integer = 0
        For i = 0 To c.Items.Count - 1
            If (c.Items(i).GetType.ToString = "DevComponents.DotNetBar.RibbonTabItem") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
            End If
        Next
    End Sub

    'add by song
    '2016-08-09
    '获取RibbonBar控件的Text值
    Private Shared Sub GetSubRibbonBarText(ByRef fn As String, ByRef c As RibbonBar)
        Dim i As Integer = 0
        For i = 0 To c.Items.Count - 1
            If (c.Items(i).GetType.ToString = "DevComponents.DotNetBar.ButtonItem") Then
                c.Items(i).Text = GetText(fn, c.Items(i).Name)
                If lang = "en" Then
                    Dim cb As ButtonItem = CType(c.Items(i), ButtonItem)
                    cb.RibbonWordWrap = False
                End If
                'Begin Mr Luu Add 2018-05-12 : Add Vietnamese Language
                If lang = "vt" Then
                    Dim cb As ButtonItem = CType(c.Items(i), ButtonItem)
                    cb.RibbonWordWrap = False
                End If
                'End Mr Luu Add 2018-05-12
            End If
        Next
    End Sub

    'add by song
    '2016-08-03
    '获取控件的Text值
    Private Shared Function GetText(ByVal Form_Id As String, ByVal Control_Id As String) As String
        Dim result As String = ""
        Dim ds = New DataSet()
        Dim dr As DataRow

        'add by song
        '2016-08-31
        Dim rm As ResourceManager = New ResourceManager("MultLanguage.Resource1", Assembly.GetExecutingAssembly())
        Dim s As String = rm.GetObject(Form_Id)
        Dim xml As New Xml.XmlDocument()
        xml.LoadXml(s)

        Dim reader As Xml.XmlNodeReader = New Xml.XmlNodeReader(xml)
        ds.ReadXml(reader)
        reader.Close()
        rm.ReleaseAllResources()

        dr = ds.Tables(0).Rows.Find(Control_Id)

        If Not dr Is Nothing Then
            If lang = "zh-chs" Then
                result = dr(1).ToString
            ElseIf lang = "zh-cht" Then
                result = dr(2).ToString
            ElseIf lang = "en" Then
                result = dr(3).ToString
            ElseIf lang = "vt" Then
                Try
                    result = dr(5).ToString
                Catch ex As Exception
                    result = dr(3).ToString
                End Try
            End If
        End If

        Return result
    End Function

    'add by song
    '2016-09-30
    '获取英语Text值的详细说明
    Public Shared Function GetFullText(ByVal Form_Id As String, ByVal Control_Id As String) As String
        Dim result As String = ""
        Dim ds = New DataSet()
        Dim dr As DataRow

        'add by song
        '2016-08-31
        Dim rm As ResourceManager = New ResourceManager("MultLanguage.Resource1", Assembly.GetExecutingAssembly())
        Dim s As String = rm.GetObject(Form_Id)
        Dim xml As New Xml.XmlDocument()
        xml.LoadXml(s)

        Dim reader As Xml.XmlNodeReader = New Xml.XmlNodeReader(xml)
        ds.ReadXml(reader)
        reader.Close()
        rm.ReleaseAllResources()

        dr = ds.Tables(0).Rows.Find(Control_Id)
        result = dr(4).ToString
        Return result
    End Function

    'add by song
    '2016-10-15
    '调整控件位置
    Public Shared Sub SetContrilLocation(ByVal sender As Control, ByVal x As Integer, ByVal w As Integer)
        If (sender.GetType.ToString = "System.Windows.Forms.TextBox") Then
            CType(sender, TextBox).Location = New Drawing.Point(CType(sender, TextBox).Location.X + x, CType(sender, TextBox).Location.Y)
            CType(sender, TextBox).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.ComboBox") Then
            CType(sender, ComboBox).Location = New Drawing.Point(CType(sender, ComboBox).Location.X + x, CType(sender, ComboBox).Location.Y)
            CType(sender, ComboBox).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.Button") Then
            CType(sender, Button).Location = New Drawing.Point(CType(sender, Button).Location.X + x, CType(sender, Button).Location.Y)
            CType(sender, Button).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.DateTimePicker") Then
            CType(sender, DateTimePicker).Location = New Drawing.Point(CType(sender, DateTimePicker).Location.X + x, CType(sender, DateTimePicker).Location.Y)
            CType(sender, DateTimePicker).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.RadioButton") Then
            CType(sender, RadioButton).Location = New Drawing.Point(CType(sender, RadioButton).Location.X + x, CType(sender, RadioButton).Location.Y)
            CType(sender, RadioButton).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.ListBox") Then
            CType(sender, ListBox).Location = New Drawing.Point(CType(sender, ListBox).Location.X + x, CType(sender, ListBox).Location.Y)
            CType(sender, ListBox).Width -= w
        ElseIf (sender.GetType.ToString = "System.Windows.Forms.CheckBox") Then
            CType(sender, CheckBox).Location = New Drawing.Point(CType(sender, CheckBox).Location.X + x, CType(sender, CheckBox).Location.Y)
            CType(sender, CheckBox).Width -= w
        End If
    End Sub
End Class
