Imports MainFrame
Imports System.Xml
Imports MainFrame.SysDataHandle
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Public Class FrmReportMain


    'Dim Conn As New SysDataHandle.SysDataBaseClass
    Dim SysClass As String = "0"
    Dim SqlserverName As String = "" '"data source=172.17.32.12;initial catalog=MESDB;uid=sa;pwd=050033068027066029014023030"
    Dim ServerIP As String
    Public opFlag As Integer = 0
    Private _ChartUsey As String
    Public Property ChartUsey() As String
        Get
            Return _ChartUsey
        End Get
        Set(ByVal value As String)
            _ChartUsey = value
        End Set
    End Property
    Private _ChartTitle As String
    Public Property ChartTitle() As String
        Get
            Return _ChartTitle
        End Get
        Set(ByVal value As String)
            _ChartTitle = value
        End Set
    End Property
    Private _ChartType As String
    Public Property ChartType() As String
        Get
            Return _ChartType
        End Get
        Set(ByVal value As String)
            _ChartType = value
        End Set
    End Property
    Private _ChartScript As String
    Public Property ChartScript() As String
        Get
            Return _ChartScript
        End Get
        Set(ByVal value As String)
            _ChartScript = value
        End Set
    End Property
    Private _DetUsey As String
    Public Property DetUsey() As String
        Get
            Return _DetUsey
        End Get
        Set(ByVal value As String)
            _DetUsey = value
        End Set
    End Property
    Private _DetScript As String
    Public Property DetScript() As String
        Get
            Return _DetScript
        End Get
        Set(ByVal value As String)
            _DetScript = value
        End Set
    End Property
    Private newQryDsValue As DataSet = New DataSet
    Public Property NewQryDs() As DataSet
        Get
            Return newQryDsValue
        End Get
        Set(ByVal value As DataSet)
            newQryDsValue = value
        End Set
    End Property
    Dim PubParam(0) As SqlParameter
    
    Private _ViewState As Boolean = False
    Public Property ViewState() As Boolean
        Get
            Return _ViewState
        End Get
        Set(ByVal value As Boolean)
            _ViewState = value
        End Set
    End Property
    Private _isSelectSQL As Boolean = True
    Public Property isSelectSQL() As Boolean
        Get
            Return _isSelectSQL
        End Get
        Set(ByVal value As Boolean)
            _isSelectSQL = value
        End Set
    End Property
    Public pageData As New SysBasicClass.PageData()
    Private Sub FrmReportMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AdvTree1.Nodes.Clear()
        'Dim dt As DataTable = Conn.GetDataTable("select Tkey,Tparent,Ttext,Enname,TreeTag,ReportUsey=isnull(ReportUsey,'N') from m_Logtree_t")
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable("select a.Tkey,Tparent,Ttext,Enname,TreeTag,ReportUsey=isnull(ReportUsey,'N') from m_Logtree_t a join m_UserRight_t b on a.Tkey=b.Tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' and ReportUsey='Y' order by a.OrderBy")
        Bind_Tv(dt, AdvTree1.Nodes, "m09_", "Tkey", "Tparent", "Ttext", True, False)
        If AdvTree1.Nodes.Count > 0 Then
            AdvTree1.SelectedIndex = 0
            AdvTree1_Click(Nothing, Nothing)
        End If

    End Sub

    '/ <summary>
    '/ 绑定TreeView（利用TreeNodeCollection）
    '/ </summary>
    '/ <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
    '/ <param name="pid_val">父id的值</param>
    '/ <param name="id">数据库 id 字段名</param>
    '/ <param name="pid">数据库 父id 字段名</param>
    '/ <param name="text">数据库 文本 字段值</param>
    Private Sub Bind_Tv(ByVal dt As DataTable, ByVal tnc As TreeNodeCollection, ByVal pid_val As String, ByVal id As String, ByVal pid As String, ByVal text As String, ByVal isfirst As Boolean, ByVal IsMultiple As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据
        Dim tn As TreeNode '建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中 As TreeNode

        '以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
        Dim filter As String = "" ' String.IsNullOrEmpty(pid_val) ? pid + " is null" : String.Format(pid + "='{0}'",pid_val) 
        If isfirst Then
            If String.IsNullOrEmpty(pid_val) Then
                filter = "Tkey is null or Tkey =''"
            Else
                filter = String.Format("Tkey='{0}'", pid_val)
            End If
        Else
            If String.IsNullOrEmpty(pid_val) Then
                filter = pid + " is null or " + pid + " =''"
            Else
                filter = String.Format("(" + pid + "='{0}' and ReportUsey='Y')", pid_val)
            End If
        End If

        dv.RowFilter = filter '利用DataView将数据进行筛选，选出相同 父id值 的数据
        Dim drv As DataRowView
        For Each drv In dv
            tn = New TreeNode() '建立一个新节点（学名叫：一个实例）
            tn.Name = drv(id).ToString() '节点的Value值，一般为数据库的id值
            tn.Text = drv(text).ToString() '节点的Text，节点的文本显示              
            tn.Expand()
            tnc.Add(tn) '将该节点加入到TreeNodeCollection（节点集合）中
            Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text, False, IsMultiple) '递归（反复调用这个方法，直到把数据取完为止）
        Next

    End Sub
    '/ <summary>
    '/ 绑定TreeView（利用TreeNodeCollection）
    '/ </summary>
    '/ <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
    '/ <param name="pid_val">父id的值</param>
    '/ <param name="id">数据库 id 字段名</param>
    '/ <param name="pid">数据库 父id 字段名</param>
    '/ <param name="text">数据库 文本 字段值</param>
    Private Sub Bind_Tv(ByVal dt As DataTable, ByVal tnc As DevComponents.AdvTree.NodeCollection, ByVal pid_val As String, ByVal id As String, ByVal pid As String, ByVal text As String, ByVal isfirst As Boolean, ByVal IsMultiple As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据
        Dim tn As DevComponents.AdvTree.Node '建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中 As TreeNode
        '以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
        Dim filter As String = "" ' String.IsNullOrEmpty(pid_val) ? pid + " is null" : String.Format(pid + "='{0}'",pid_val) 
        If isfirst Then
            If String.IsNullOrEmpty(pid_val) Then
                filter = "Tkey is null or Tkey =''"
            Else
                filter = String.Format("Tkey='{0}'", pid_val)
            End If
        Else
            If String.IsNullOrEmpty(pid_val) Then
                filter = pid + " is null or " + pid + " =''"
            Else
                filter = String.Format("(" + pid + "='{0}' and ReportUsey='Y')", pid_val)
            End If
        End If
        'If Not ViewState Then
        '    filter = filter + String.Format(" ReportUsey='Y' ", pid_val)
        'End If

        dv.RowFilter = filter '利用DataView将数据进行筛选，选出相同 父id值 的数据
        Dim drv As DataRowView
        For Each drv In dv
            tn = New DevComponents.AdvTree.Node() '建立一个新节点（学名叫：一个实例）
            tn.Name = drv(id).ToString() '节点的Value值，一般为数据库的id值
            tn.Text = drv(text).ToString() '节点的Text，节点的文本显示  

            If IsMultiple Then
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(id).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(pid).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("Enname").ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("TreeTag").ToString()))
            End If
            tn.Expanded = True
            tnc.Add(tn) '将该节点加入到TreeNodeCollection（节点集合）中
            Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text, False, IsMultiple) '递归（反复调用这个方法，直到把数据取完为止）
        Next
    End Sub
    Private Sub AdvTree1_Click(sender As Object, e As EventArgs) Handles AdvTree1.Click
        If Me.AdvTree1.Nodes.Count = 0 OrElse Me.AdvTree1.SelectedNode Is Nothing Then Exit Sub
        Dim key As String = AdvTree1.SelectedNode.Name.ToString.Trim
        Dim text As String = AdvTree1.SelectedNode.Text.ToString.Trim
        Dim sql As String = String.Format(" select a.Ttext,b.SqlScript,b.SqlUsey,DetScript,DetUsey,ChartScript,ChartTitle,ChartType,ChartUsey from m_Logtree_t a left join m_Logtree_Det_t b on a.Tkey=b.Tkey  where a.Tkey='{0}'  select * from m_Logtree_Qry_t where  Tkey='{0}' order by QRYSEQ  ", key)
        NewQryDs = DbOperateReportUtils.GetDataSet(sql)
        CreateControlsList()
        Dim dt As DataTable = New DataTable()
        'Me.DataGridViewX1.DataSource = dt
        DataGridViewX1.DataSource = Nothing
        'Records.Text = "0"
    End Sub

    Public Sub CreateControlsList()
        GroupBox1.Controls.Clear()
        'SplitContainer1.Panel1.Controls.Clear()
        Dim ds As DataSet = NewQryDs
        If ds.Tables.Count > 0 Then
            Dim dt_mstr As DataTable = ds.Tables(0)
            Dim dt_det As DataTable = ds.Tables(1)
            'GroupBox1.Text = dt_mstr.Rows(0)("Ttext").ToString
            GroupBox1.Text = ""
            ChartTitle = dt_mstr.Rows(0)("Ttext").ToString
            Dim Ttext As String = dt_mstr.Rows(0)("Ttext").ToString
            DetUsey = dt_mstr.Rows(0)("DetUsey").ToString
            DetScript = dt_mstr.Rows(0)("DetScript").ToString
            ChartUsey = dt_mstr.Rows(0)("ChartUsey").ToString
            ChartScript = dt_mstr.Rows(0)("ChartScript").ToString
            ChartTitle = dt_mstr.Rows(0)("ChartTitle").ToString
            ChartType = dt_mstr.Rows(0)("ChartType").ToString
            If ChartUsey = "Y" Then
                btnReport.Enabled = True
            Else
                btnReport.Enabled = False
            End If

            Dim colcounts As Integer = 4
            Dim rowcounts As Integer = 1
            Dim leftlen As Integer = 0
            Dim heightlen As Integer = 32
            If dt_det.Rows.Count > 0 Then
                ReDim PubParam(dt_det.Rows.Count - 1)
                If (dt_det.Rows.Count Mod colcounts) > 0 Then
                    rowcounts = (dt_det.Rows.Count \ colcounts) + 1
                Else
                    rowcounts = dt_det.Rows.Count \ colcounts
                End If
                heightlen = heightlen * rowcounts
                SplitContainer1.SplitterDistance = heightlen + 11
                If rowcounts = 1 Then
                    SplitContainer1.SplitterDistance = heightlen + 18
                End If
                If rowcounts = 2 Then
                    SplitContainer1.SplitterDistance = heightlen + 18
                End If
                Dim PARA_NAME As String = ""
                Dim PARA_TYPE As String = ""
                Dim DEFAULT_VALUE As String = ""
                Dim PARA_LENGTH As Integer = 0
                Dim TABLENAME As String = ""
                Dim ISNUL As Boolean = True
                For i = 0 To dt_det.Rows.Count - 1
                    PARA_NAME = dt_det.Rows(i)("PARA_NAME").ToString.ToLower
                    PARA_TYPE = dt_det.Rows(i)("PARA_TYPE").ToString.ToUpper
                    DEFAULT_VALUE = dt_det.Rows(i)("DEFAULT_VALUE")
                    PARA_LENGTH = dt_det.Rows(i)("PARA_LENGTH")
                    TABLENAME = dt_det.Rows(i)("TABLENAME")
                    ISNUL = Boolean.Parse(dt_det.Rows(i)("ISNUL"))
                    Dim yu As Integer = i Mod colcounts
                    Dim zn As Integer = i \ colcounts
                    Dim lb As Label = New Label
                    lb.Text = dt_det.Rows(i)("PARA_CHG_NAME") + ":"
                    lb.TextAlign = ContentAlignment.MiddleRight
                    lb.Width = 100
                    lb.Top = 15 + 30 * zn
                    lb.Left = 250 * yu
                    'Dim a As Integer = lb.Height
                    'lb.BackColor = Color.Red
                    GroupBox1.Controls.Add(lb)
                    'SplitContainer1.Panel1.Controls.Add(lb)
                    Select Case PARA_TYPE
                        Case "D"
                            Dim tb As DateTimePicker = New DateTimePicker
                            tb.CustomFormat = "yyyy-MM-dd HH:mm:ss"
                            tb.Format = DateTimePickerFormat.Custom
                            tb.Name = "txt_" + PARA_NAME.Split("@")(1).ToString
                            tb.Width = 150
                            tb.Top = 15 + 30 * zn
                            tb.Left = 250 * yu + 100
                            If DEFAULT_VALUE = "" Then
                                tb.Value = Now().ToString("yyyy-MM-dd HH:mm:ss")
                            Else
                                tb.Value = Convert.ToDateTime(DEFAULT_VALUE)
                            End If
                            GroupBox1.Controls.Add(tb)
                            PubParam(i) = New SqlParameter(PARA_NAME, SqlDbType.DateTime, 8)
                        Case "T"
                            Dim tb As ComboBox = New ComboBox
                            tb.Name = "txt_" + PARA_NAME.Split("@")(1).ToString
                            tb.Width = 150
                            tb.Top = 15 + 30 * zn
                            tb.Left = 250 * yu + 100
                            BindDropDown(tb, TABLENAME, ISNUL)
                            GroupBox1.Controls.Add(tb)
                            tb.Text = DEFAULT_VALUE
                            PubParam(i) = New SqlParameter(PARA_NAME, SqlDbType.NVarChar, PARA_LENGTH * 2)
                        Case "L"
                            Dim tb As ComboBox = New ComboBox
                            tb.Name = "txt_" + PARA_NAME.Split("@")(1).ToString
                            tb.Width = 150
                            tb.Top = 15 + 30 * zn
                            tb.Left = 250 * yu + 100
                            BindDropDownList(tb, TABLENAME, ISNUL, DEFAULT_VALUE)
                            GroupBox1.Controls.Add(tb)
                            tb.SelectedIndex = tb.FindString(DEFAULT_VALUE) '= DEFAULT_VALUE
                            PubParam(i) = New SqlParameter(PARA_NAME, SqlDbType.NVarChar, PARA_LENGTH * 2)
                        Case "S"

                            Dim tb As MaskedTextBoxAdv = New MaskedTextBoxAdv

                            tb.BackgroundStyle.Class = "TextBoxBorder"
                            tb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                            ' tb.ButtonCustom.Image = Global.SysReport.My.Resources.Resources.right
                            tb.ButtonCustom.Visible = True
                            'tb.Location = New System.Drawing.Point(422, 20)
                            tb.Location = New System.Drawing.Point(250 * yu + 100, 15 + 30 * zn)
                            tb.Name = "txt_" + PARA_NAME.Split("@")(1).ToString
                            tb.Size = New System.Drawing.Size(150, 21)
                            tb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
                            tb.TabIndex = 0
                            tb.Text = DEFAULT_VALUE
                            AddHandler tb.ButtonCustomClick, AddressOf MaskedTextBoxAdv_ButtonCustomClick
                            GroupBox1.Controls.Add(tb)
                            PubParam(i) = New SqlParameter(PARA_NAME, SqlDbType.NVarChar, PARA_LENGTH * 2)
                        Case Else
                            Dim tb As TextBox = New TextBox
                            tb.Name = "txt_" + PARA_NAME.Split("@")(1).ToString
                            tb.Width = 150
                            tb.Top = 15 + 30 * zn
                            tb.Left = 250 * yu + 100
                            tb.Text = DEFAULT_VALUE
                            tb.MaxLength = PARA_LENGTH
                            GroupBox1.Controls.Add(tb)
                            PubParam(i) = New SqlParameter(PARA_NAME, SqlDbType.NVarChar, PARA_LENGTH * 2)
                    End Select
                Next

            Else
                Dim lb As Label = New Label
                lb.Text = "该菜单没有进行报表查询设置，请设置查询条件"
                lb.AutoSize = True
                'lb.TextAlign = ContentAlignment.MiddleRight
                'lb.Width = 100
                lb.Top = 20 + 30 * 0
                lb.Left = 250 * 0 + 15
                'Dim a As Integer = lb.Height
                'lb.BackColor = Color.Red
                SplitContainer1.SplitterDistance = 50
                GroupBox1.Controls.Add(lb)

            End If

        End If
    End Sub
    Private Sub MaskedTextBoxAdv_ButtonCustomClick(sender As Object, e As EventArgs)
        Dim obj As InputText = New InputText(CType(sender, MaskedTextBoxAdv))
        obj.ShowDialog()
    End Sub
    Public Sub BindDropDownList(ByVal obj As ComboBox, ByVal StrSql As String, ByVal ISNUL As Boolean, ByVal DEFAULT_VALUE As String, Optional ByVal ValueField As String = "", Optional ByVal TextField As String = "")
        'StrSql = StrSql.ToLower.Replace("@userid", "'" + SysMessageClass.UseId + "'")

        StrSql = ReplaceNoCase(StrSql, "@userid", "'" + SysMessageClass.UseId + "'")
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(StrSql)
        If ValueField = "" Then
            ValueField = dt.Columns(0).ColumnName
        End If
        If dt.Columns.Count = 1 Then
            If TextField = "" Then
                TextField = dt.Columns(0).ColumnName
            End If
        End If
        If dt.Columns.Count = 2 Then
            TextField = dt.Columns(1).ColumnName
        End If
        obj.DropDownStyle = ComboBoxStyle.DropDownList
        obj.DataSource = dt.DefaultView
        obj.ValueMember = ValueField
        obj.DisplayMember = TextField
        obj.SelectedValue = DEFAULT_VALUE

    End Sub
    Public Sub BindDropDown(ByVal obj As ComboBox, ByVal StrSql As String, ByVal ISNUL As Boolean, Optional ByVal ValueField As String = "", Optional ByVal TextField As String = "")
        'StrSql = StrSql.ToLower.Replace("@userid", "'" + SysMessageClass.UseId + "'")
        StrSql = ReplaceNoCase(StrSql, "@userid", "'" + SysMessageClass.UseId + "'")
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(StrSql)
        If ValueField = "" Then
            ValueField = dt.Columns(0).ColumnName
        End If
        If dt.Columns.Count = 1 Then
            If TextField = "" Then
                TextField = dt.Columns(0).ColumnName
            End If
        End If
        If dt.Columns.Count = 2 Then
            TextField = dt.Columns(1).ColumnName
        End If
        If Not ISNUL Then
            obj.DropDownStyle = ComboBoxStyle.DropDown
        End If
        obj.DataSource = dt.DefaultView
        obj.ValueMember = ValueField
        obj.DisplayMember = TextField
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            QueryData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmReportMain", "QueryData", "sys")
        End Try

    End Sub
    Private Sub QueryData()
        Dim ds As DataSet = NewQryDs
        If ds.Tables.Count > 0 Then
            Dim dt_mstr As DataTable = ds.Tables(0)
            Dim dt_det As DataTable = ds.Tables(1)
            If dt_mstr.Rows.Count > 0 Then
                Dim sql As String = dt_mstr.Rows(0)("SQLSCRIPT").ToString
                DetUsey = dt_mstr.Rows(0)("DetUsey").ToString
                isSelectSQL = True
                If sql <> "" Then
                    If sql.Substring(0, 6).ToUpper <> "select".ToUpper Then
                        isSelectSQL = False
                    End If
                End If


                Dim PARA_NAME As String = ""
                Dim PARA_TYPE As String = ""
                Dim DEFAULT_VALUE As String = ""
                Dim PARA_LENGTH As Integer = 0
                Dim ISNUL As String = "0"
                Dim CONDITIONSQL As String = ""
                Dim PARA_CHG_NAME As String = ""

                Dim dt As DataTable = New DataTable
                Try
                    If dt_det.Rows.Count > 0 And sql <> "" Then
                        Dim AllowQry As Boolean = True
                        For i = 0 To dt_det.Rows.Count - 1
                            PARA_NAME = dt_det.Rows(i)("PARA_NAME").ToString.ToLower
                            PARA_TYPE = dt_det.Rows(i)("PARA_TYPE").ToString.ToUpper
                            DEFAULT_VALUE = dt_det.Rows(i)("DEFAULT_VALUE")
                            PARA_CHG_NAME = dt_det.Rows(i)("PARA_CHG_NAME")
                            PARA_LENGTH = dt_det.Rows(i)("PARA_LENGTH")
                            ISNUL = dt_det.Rows(i)("ISNUL").ToString()
                            CONDITIONSQL = dt_det.Rows(i)("CONDITIONSQL").ToString
                            Dim keyname As String = "txt_" + PARA_NAME.Split("@")(1).ToString
                            Dim val As String = ""
                            Select Case PARA_TYPE
                                Case "D"
                                    val = CType(GroupBox1.Controls.Find(keyname, False)(0), DateTimePicker).Value
                                Case "T"
                                    If ISNUL Then
                                        val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).Text.Trim
                                    Else
                                        val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).SelectedValue
                                    End If
                                Case "L"
                                    'If ISNUL Then
                                    '    val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).Text.Split("-")(0)
                                    'Else
                                    '    val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).SelectedValue
                                    'End If
                                    val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).SelectedValue
                                Case "N"
                                    val = CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).Text
                                    If Not IsNumeric(val) Then
                                        MessageBox.Show("请输入数字类型")
                                        CType(GroupBox1.Controls.Find(keyname, False)(0), ComboBox).Focus()
                                        Exit Sub
                                    End If
                                Case "S"
                                    val = CType(GroupBox1.Controls.Find(keyname, False)(0), MaskedTextBoxAdv).Text.ToString.Trim
                                Case Else
                                    val = CType(GroupBox1.Controls.Find(keyname, False)(0), TextBox).Text
                            End Select
                            If val = "" Then
                                If Boolean.Parse(ISNUL) Then
                                    If isSelectSQL Then
                                        If PARA_TYPE = "S" Then
                                            sql = ReplaceNoCase(sql, CONDITIONSQL, " ")
                                        Else
                                            sql = ReplaceNoCase(sql, CONDITIONSQL, "(1=1)")
                                        End If
                                        'sql = sql.Replace(CONDITIONSQL, "(1=1)") '允许为空，将替换

                                    End If
                                Else
                                    MessageBox.Show(PARA_CHG_NAME + "不允许为空")
                                    GroupBox1.Controls.Find(keyname, False)(0).Focus()
                                    AllowQry = False
                                    Exit Sub
                                End If
                            End If
                            PubParam(i).Value = val
                        Next
                        If (isSelectSQL) Then
                            If AllowQry Then
                                pageData.QuerySQL = sql
                                pageData.QueryParam = PubParam
                                ' bind()

                                'dt = Conn.GetDataTable(sql, PubParam)
                            End If
                        End If

                    Else
                        If sql <> "" Then
                            sql = ReplaceNoCase(sql, "@userid", "'" + SysMessageClass.UseId + "'")
                            'sql = sql.ToLower.Replace("@userid", "'" + SysMessageClass.UseId + "'") '专用参数，登陆用户
                            pageData.QuerySQL = sql
                            '   pageData.QueryParam = PubParam

                            ' dt = Conn.GetDataTable(sql)
                        End If

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    Exit Sub
                End Try
                Cursor = Cursors.WaitCursor
                SysBasicClass.WaitFormService.CreateWaitForm()
                Try
                    If (isSelectSQL) Then
                        Pager1.PageCount = 1
                        Pager1.Bind()
                        Pager1.Enabled = True
                        dgvBind()
                    Else
                        'Dim dss As DataTable = New MainFrame.SysDataHandle.SysDataBaseClass().GetDataTable(sql, PubParam)
                        Dim dss As DataTable = DbOperateReportUtils.GetDataTable(sql, PubParam)
                        DataGridViewX1.DataSource = dss
                        Pager1.SetExportEnabled()
                    End If
                    'Pager1.PageCount = 1
                    'Pager1.Bind()
                    'dgvBind()
                Catch ex As Exception
                    MessageBox.Show("有错误发生" + ex.ToString)
                Finally
                    Threading.Thread.Sleep(100)
                    SysBasicClass.WaitFormService.CloseWaitForm()
                    Cursor = Cursors.Default
                End Try
            End If
        End If


    End Sub
    Private Function dgvBind() As Integer
        DataGridViewX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewX1.ColumnHeadersHeight = 30
        pageData.PageIndex = Pager1.PageCurrent
        pageData.PageSize = Pager1.PageSize
        Pager1.bindingSource.DataSource = pageData.QueryDataTable()
        Pager1.bindingNavigator.BindingSource = Pager1.bindingSource
        Pager1.QuerySeconds = pageData.QuerySeconds
        DataGridViewX1.DataSource = Pager1.bindingSource

        DataGridViewX1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewX1.Columns(0).HeaderText = "序号"
        DataGridViewX1.Columns(0).Width = 60
        'DataGridViewX1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Return pageData.TotalCount
    End Function

    Private Sub btnexport_Click(sender As Object, e As EventArgs)
        If Me.DataGridViewX1.RowCount < 1 Then Exit Sub
        Dim name As String = NewQryDs.Tables(0).Rows(0)("Ttext").ToString
        LoadDataToExcel(Me.DataGridViewX1, name)
    End Sub


    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Function ReplaceNoCase(ByVal realaceValue As String, ByVal oldValue As String, ByVal NewValue As String) As String
        Dim returnstr = Replace(realaceValue, oldValue, NewValue)
        If (returnstr.Length = realaceValue.Length) Then
            returnstr = System.Text.RegularExpressions.Regex.Replace(realaceValue, oldValue, NewValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        End If
        Return returnstr
    End Function


    Private Sub DataGridViewX1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewX1.CellMouseDoubleClick
        If DetUsey = "Y" Then
            Dim sql As String = DetScript
            ' Dim cout As Integer = sql.Split("{").Length - 1
            For i = 0 To DataGridViewX1.Rows(e.RowIndex).Cells.Count - 1
                sql = sql.Replace("{" & i.ToString & "}", DataGridViewX1.Rows(e.RowIndex).Cells(i).Value.ToString())
            Next
            Dim obj As FrmShowDetail = New FrmShowDetail
            obj.strSQL = sql
            obj.ShowDialog()

        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If ChartUsey = "Y" Then
            Dim sql As String = ChartScript
            Dim cout As Integer = DetScript.Split("{").Length - 1
            If cout > 0 Then
                If Not DataGridViewX1.CurrentCell Is Nothing Then
                    For i = 0 To cout - 1
                        sql = sql.Replace("{" & i.ToString & "}", DataGridViewX1.CurrentRow.Cells(0).Value.ToString)
                    Next
                Else
                    MessageBox.Show("请选择记录")
                    Exit Sub
                End If
            End If

            Dim ds As DataSet = New DataSet
            DbOperateReportUtils.FillDataSetBySql(sql, ds, PubParam)
            Dim ReportChar As FrmReportChar = New FrmReportChar
            ReportChar.CharTitle = ChartTitle ' GroupBox1.Text
            ReportChar.SummaryTitle = ChartTitle
            ReportChar.ChartViewType = ChartType
            ReportChar.SummaryDs = ds
            ReportChar.ShowDialog()
        End If

    End Sub

    Private Function Pager1_EventPaging(e As SysBasicClass.EventPagingArg) As System.Int32 Handles Pager1.EventPaging
        Return dgvBind()
    End Function

    Public Function GetDgvToTable(ByVal dgv As DataGridView) As DataTable
        Dim dt As DataTable = New DataTable()

        ' 列强制转换
        Dim ColCount As Integer
        For ColCount = 0 To dgv.Columns.Count - 1 Step ColCount + 1
            Dim dc As DataColumn = New DataColumn(dgv.Columns(ColCount).Name.ToString())
            dt.Columns.Add(dc)
        Next

        ' 循环行
        Dim RowCount As Integer
        For RowCount = 0 To dgv.Rows.Count - 1
            Dim dr As DataRow = dt.NewRow()
            Dim countsub As Integer
            For countsub = 0 To dgv.Columns.Count - 1
                dr(countsub) = Convert.ToString(dgv.Rows(RowCount).Cells(countsub).Value)
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub Pager1_ExportData(e As SysBasicClass.ExportDataArg) Handles Pager1.ExportData
        ' SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), pageData.QueryDataTable())
        If isSelectSQL Then
            SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), pageData.QueryDataTable())

        Else
            Dim dt As DataTable = GetDgvToTable(DataGridViewX1)

            SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), dt)
        End If
    End Sub

    Private Sub Pager1_ExportAllData(e As SysBasicClass.ExportAllDataArg) Handles Pager1.ExportAllData
        SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), pageData.QueryAllDataTable())
    End Sub
End Class
