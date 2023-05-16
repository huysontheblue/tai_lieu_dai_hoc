Imports MainFrame.SysCheckData

''' <summary>
''' 弹出窗口：系统组织树
''' 1，工厂
''' 2，工厂/利润中心
''' 3，工厂/部门
''' 4，工厂/部门/产线
''' </summary>
''' <remarks></remarks>
Public Class FrmSelectMenuOrg
    '父窗体传过来的值
    Dim _TypeFlag As Integer = 0                '组织要显示的类型（共4类）
    Dim _FieldId As String = ""                 '节点Tkey = 字段ID或主键值
    Dim _FieldName As String = ""               '节点Ttext = 字段名称值

#Region "获取数据源"

    ''' <summary>
    ''' 工厂
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFactoryList(ByVal isFilter As Boolean) As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String = "exec Pro_GetSysMenuOrg_FactoryList '' , 0 "            '参数为空取所有

        If isFilter = True Then
            sql = "exec Pro_GetSysMenuOrg_FactoryList '" & Me._FieldId & "' , 1 "   '参数不为空，则过滤掉菜单中已存在的
        End If

        dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function

    ''' <summary>
    ''' 利润中心
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetProfitcenterList(ByVal isFilter As Boolean) As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String = "exec Pro_GetSysMenuOrg_ProfitcenterList '' , 0 "

        If isFilter = True Then
            sql = "exec Pro_GetSysMenuOrg_ProfitcenterList '" & Me._FieldId & "' , 1 "
        End If

        dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function

    ''' <summary>
    ''' 部门
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDeptList(ByVal isFilter As Boolean) As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String = "exec Pro_GetSysMenuOrg_DeptList '', 0 "

        If isFilter = True Then
            sql = "exec Pro_GetSysMenuOrg_DeptList '" & Me._FieldId & "', 1 "
        End If

        dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function

    ''' <summary>
    ''' 产线
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLineList(ByVal isFilter As Boolean) As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String = "exec Pro_GetSysMenuOrg_LineList '' , 0 "

        If isFilter = True Then
            sql = "exec Pro_GetSysMenuOrg_LineList '" & Me._FieldId & "', 1 "
        End If

        dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function

#End Region

#Region "自定义方法"

    ''' <summary>
    ''' 展开指定节的所有父节点
    ''' </summary>
    ''' <param name="tn"></param>
    ''' <remarks></remarks>
    Private Sub TreeNodeExpand(ByVal tn As TreeNode)
        If Not tn.Parent Is Nothing Then
            tn.Parent.Expand()
            TreeNodeExpand(tn.Parent)
        End If
    End Sub

    ''' <summary>
    ''' 窗体加载初始化数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        Me.TxtTkey.Text = ""
        Me.TxtTtext.Text = ""
        Me.LblRecord.Text = "记录总数：0"
        Me.LblRecord.Text = "记录总数：0"
        Me.tvMenu.HideSelection = False
        Me.tvMenu.Nodes.Clear()
        Select Case Me._TypeFlag
            Case 1
                '工厂
                Me.Text = "选择工厂"
                LoadTreeFactory()
            Case 2
                '利润中心
                Me.Text = "选择利润中心"
                LoadTreeFactoryAndProfitcenter()
            Case 3
                '部门
                Me.Text = "选择部门"
                LoadTreeFactoryAndDept()
            Case 4
                '产线
                Me.Text = "选择产线"
                LoadTreeFactoryAndDeptLine()
        End Select
    End Sub

    ''' <summary>
    ''' 1，工厂
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTreeFactory()
        Try
            '获取菜单数据
            Dim dt As DataTable = New DataTable
            dt = GetFactoryList(Me.RbFilter.Checked)  '工厂数据表

            '显示菜单树
            Me.tvMenu.Nodes.Clear()
            Me.tvMenu.Enabled = True
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Me.LblRecord.Text = "记录总数：" + dt.Rows.Count.ToString()
                    For Each dr As DataRow In dt.Rows
                        Dim factoryID As String = IIf(dr("Factoryid") Is Nothing, "", dr("Factoryid").ToString)
                        Dim shortName As String = IIf(dr("Shortname") Is Nothing, "", dr("Shortname").ToString)
                        Dim factoryName As String = IIf(dr("Fullname") Is Nothing, "", dr("Fullname").ToString)
                        If String.IsNullOrEmpty(factoryID) = False Then
                            '加载节点
                            Dim tn As TreeNode = New TreeNode()
                            tn.Tag = factoryID
                            tn.Text = factoryID + "-" + factoryName
                            LoadTree(tn, Nothing)
                            '默认选中
                            If String.IsNullOrEmpty(Me._FieldId) = False Then
                                If factoryID = Me._FieldId Then
                                    Me.tvMenu.SelectedNode = tn
                                End If
                            End If
                        End If
                    Next
                    '展开一级树节点，并默认选中
                    'If (Me.tvMenu.Nodes.Count > 0) Then
                    '    Me.tvMenu.Nodes(0).Expand()
                    'End If
                End If
            Else
                MessageBox.Show("未查询到工厂数据", "提示")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("加载数据时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 2，工厂/利润中心
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTreeFactoryAndProfitcenter()
        Try
            '获取菜单数据
            Dim dtFac As DataTable = New DataTable
            Dim dtPro As DataTable = New DataTable
            dtFac = GetFactoryList(False)        '工厂数据表
            dtPro = GetProfitcenterList(Me.RbFilter.Checked)   '利润中心数据表

            '显示菜单树
            Me.tvMenu.Nodes.Clear()
            Me.tvMenu.Enabled = True
            '工厂
            If Not dtFac Is Nothing And Not dtPro Is Nothing Then
                If dtFac.Rows.Count > 0 Then
                    For Each dr As DataRow In dtFac.Rows
                        Dim factoryID As String = IIf(dr("Factoryid") Is Nothing, "", dr("Factoryid").ToString)
                        Dim factoryName As String = IIf(dr("Fullname") Is Nothing, "", dr("Fullname").ToString)
                        If String.IsNullOrEmpty(factoryID) = False And String.IsNullOrEmpty(factoryName) = False Then
                            Dim tn As TreeNode = New TreeNode()
                            tn.Tag = factoryID
                            tn.Text = factoryID + "-" + factoryName
                            LoadTree(tn, Nothing)   '加载树节点
                            '利润中心
                            If dtPro.Rows.Count > 0 Then
                                Me.LblRecord.Text = "记录总数：" + dtPro.Rows.Count.ToString()
                                Dim conditions As String = "FACTORY_ID='" & factoryID & "'"
                                Dim drs() As DataRow = dtPro.Select(conditions)
                                For Each drp As DataRow In drs
                                    Dim proCode As String = IIf(drp("PROFITCENTER_CODE") Is Nothing, "", drp("PROFITCENTER_CODE").ToString)
                                    Dim proName As String = IIf(drp("PROFITCENTER_NAME") Is Nothing, "", drp("PROFITCENTER_NAME").ToString)
                                    If String.IsNullOrEmpty(proCode) = False And String.IsNullOrEmpty(proName) = False Then
                                        Dim tns As TreeNode = New TreeNode()
                                        tns.Tag = proCode
                                        tns.Text = proCode + "-" + proName
                                        LoadTree(tns, tn)   '加载树节点
                                        '默认选中
                                        If String.IsNullOrEmpty(Me._FieldId) = False Then
                                            If proCode = Me._FieldId Then
                                                Me.tvMenu.SelectedNode = tns
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '展开一级树节点，并默认选中
                    'If (Me.tvMenu.Nodes.Count > 0) Then
                    '    Me.tvMenu.Nodes(0).Expand()
                    'End If
                End If
            Else
                MessageBox.Show("未查询到工厂/利润中心数据记录", "提示")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("加载数据时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 3，工厂/部门
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTreeFactoryAndDept()
        Try
            '获取菜单数据
            Dim dtFac As DataTable = New DataTable
            Dim dtDep As DataTable = New DataTable
            dtFac = GetFactoryList(False)        '工厂数据表
            dtDep = GetDeptList(Me.RbFilter.Checked)   '利润中心数据表

            '显示菜单树
            Me.tvMenu.Nodes.Clear()
            Me.tvMenu.Enabled = True
            '工厂
            If Not dtFac Is Nothing And Not dtDep Is Nothing Then
                If dtFac.Rows.Count > 0 Then
                    For Each dr1 As DataRow In dtFac.Rows
                        Dim factoryID As String = IIf(dr1("Factoryid") Is Nothing, "", dr1("Factoryid").ToString)
                        Dim factoryName As String = IIf(dr1("Fullname") Is Nothing, "", dr1("Fullname").ToString)
                        If String.IsNullOrEmpty(factoryID) = False And String.IsNullOrEmpty(factoryName) = False Then
                            Dim tn As TreeNode = New TreeNode()
                            tn.Tag = factoryID
                            tn.Text = factoryID + "-" + factoryName
                            LoadTree(tn, Nothing)   '加载树节点
                            '部门
                            If dtDep.Rows.Count > 0 Then
                                Me.LblRecord.Text = "记录总数：" + dtDep.Rows.Count.ToString()
                                Dim conditions As String = "Factoryid='" & factoryID & "'"
                                Dim drs() As DataRow = dtDep.Select(conditions)
                                For Each dr2 As DataRow In drs
                                    Dim deptId As String = IIf(dr2("deptid") Is Nothing, "", dr2("deptid").ToString)
                                    Dim deptName As String = IIf(dr2("dqc") Is Nothing, "", dr2("dqc").ToString)
                                    If String.IsNullOrEmpty(deptId) = False And String.IsNullOrEmpty(deptName) = False Then
                                        Dim tns As TreeNode = New TreeNode()
                                        tns.Tag = deptId
                                        tns.Text = deptId + "-" + deptName
                                        LoadTree(tns, tn)   '加载树节点
                                        '默认选中
                                        If String.IsNullOrEmpty(Me._FieldId) = False Then
                                            If deptId = Me._FieldId Then
                                                Me.tvMenu.SelectedNode = tns
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '展开一级树节点，并默认选中
                    'If (Me.tvMenu.Nodes.Count > 0) Then
                    '    Me.tvMenu.Nodes(0).Expand()
                    'End If
                End If
            Else
                MessageBox.Show("未查询到工厂/部门数据记录", "提示")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("加载数据时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 4，工厂/部门/产线
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTreeFactoryAndDeptLine()
        Try
            '获取菜单数据
            Dim dtFac As DataTable = New DataTable
            Dim dtDep As DataTable = New DataTable
            Dim dtLine As DataTable = New DataTable
            dtFac = GetFactoryList(False)        '工厂数据表
            dtDep = GetDeptList(False)           '利润中心数据表
            dtLine = GetLineList(Me.RbFilter.Checked)          '产线数据表

            '显示菜单树
            Me.tvMenu.Nodes.Clear()
            Me.tvMenu.Enabled = True
            '1工厂
            If Not dtFac Is Nothing And Not dtDep Is Nothing Then
                If dtFac.Rows.Count > 0 Then
                    For Each dr1 As DataRow In dtFac.Rows
                        Dim factoryID As String = IIf(dr1("Factoryid") Is Nothing, "", dr1("Factoryid").ToString)
                        Dim factoryName As String = IIf(dr1("Fullname") Is Nothing, "", dr1("Fullname").ToString)
                        If String.IsNullOrEmpty(factoryID) = False And String.IsNullOrEmpty(factoryName) = False Then
                            Dim tn As TreeNode = New TreeNode()
                            tn.Tag = factoryID
                            tn.Text = factoryID + "-" + factoryName
                            LoadTree(tn, Nothing)   '加载树节点
                            '2部门
                            If dtDep.Rows.Count > 0 Then
                                Dim conditions As String = "Factoryid='" & factoryID & "'"
                                Dim drs() As DataRow = dtDep.Select(conditions)
                                For Each dr2 As DataRow In drs
                                    Dim deptId As String = IIf(dr2("deptid") Is Nothing, "", dr2("deptid").ToString)
                                    Dim deptName As String = IIf(dr2("dqc") Is Nothing, "", dr2("dqc").ToString)
                                    If String.IsNullOrEmpty(deptId) = False And String.IsNullOrEmpty(deptName) = False Then
                                        Dim tn2 As TreeNode = New TreeNode()
                                        tn2.Tag = deptId
                                        tn2.Text = deptId + "-" + deptName
                                        LoadTree(tn2, tn)   '加载树节点
                                        '3产线
                                        If dtLine.Rows.Count > 0 Then
                                            Me.LblRecord.Text = "记录总数：" + dtLine.Rows.Count.ToString()
                                            Dim conditions3 As String = "factoryid='" & factoryID & "' AND deptid='" & deptId & "' "
                                            Dim drs3() As DataRow = dtLine.Select(conditions3)
                                            For Each dr3 As DataRow In drs3
                                                Dim lineid As String = IIf(dr3("lineid") Is Nothing, "", dr3("lineid").ToString)
                                                Dim partSeriesTypeName As String = IIf(dr3("PartSeriesTypeName") Is Nothing, "", dr3("PartSeriesTypeName").ToString)
                                                If String.IsNullOrEmpty(lineid) = False Then
                                                    Dim tn3 As TreeNode = New TreeNode()
                                                    tn3.Tag = lineid
                                                    tn3.Text = lineid + IIf(partSeriesTypeName = "", "", "-" + partSeriesTypeName)
                                                    LoadTree(tn3, tn2)   '加载树节点
                                                    If String.IsNullOrEmpty(Me._FieldId) = False Then
                                                        If lineid = Me._FieldId Then
                                                            Me.tvMenu.SelectedNode = tn3
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '展开一级树节点，并默认选中
                    'If (Me.tvMenu.Nodes.Count > 0) Then
                    '    Me.tvMenu.Nodes(0).Expand()
                    'End If
                End If
            Else
                MessageBox.Show("未查询到工厂/部门/产线数据记录", "提示")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("加载数据时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 加载节点
    ''' </summary>
    ''' <param name="tn">当前节点</param>
    ''' <param name="parentNode">父节点</param>
    ''' <remarks></remarks>
    Private Sub LoadTree(ByVal tn As TreeNode, ByVal parentNode As TreeNode)
        '加载节点
        If parentNode Is Nothing Then
            tn.ToolTipText = ""
            Me.tvMenu.Nodes.Add(tn)
        Else
            tn.ToolTipText = parentNode.Text
            parentNode.Nodes.Add(tn)
        End If
    End Sub

#End Region

#Region "标准事件"

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(ByVal typeFlag As Integer, ByVal fieldId As String, ByVal fieldName As String)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._TypeFlag = typeFlag
        Me._FieldId = fieldId
        Me._FieldName = fieldName
    End Sub

    ''' <summary>
    ''' 标准事件：窗体加载
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSelectMenuOrg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnRefresh.PerformClick()
    End Sub

    ''' <summary>
    ''' 标准事件：刷新按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        LoadData()
    End Sub

    ''' <summary>
    ''' 标准事件：退出按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 标准事件：关闭按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 标准事件：确定按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        If String.IsNullOrEmpty(Me.TxtTkey.Text.Trim) = True Then
            MessageBox.Show("请先选择一个菜单节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        '给父窗口返回数据，只返回用于菜单名称，Tkey值为用户手工配置
        Dim frmParent As FrmSysMenu = Me.Owner
        frmParent.TxtMenuName.Text = Me.TxtTtext.Text.Trim
        '保存来源值
        frmParent.TxtFieldId.Text = Me.TxtTkey.Text.Trim
        frmParent.TxtFieldName.Text = Me.TxtTtext.Text.Trim
        Me.Close()
    End Sub

    ''' <summary>
    ''' 标准事件：树节点选择
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvMenu.AfterSelect
        Try
            If Not Me.tvMenu.SelectedNode Is Nothing Then
                '最末级是否可选择检查
                Select Case Me._TypeFlag
                    'Case 1
                    '工厂             '只有一级不检查
                    'Case 2
                    '工厂/利润中心    '都可做利润中心，不检查
                    Case 3
                        '工厂/部门：部门有无父节点
                        If Me.tvMenu.SelectedNode.Parent Is Nothing Then
                            Return
                        End If
                    Case 4
                        '工厂/部门/产线：产线有无两级父节点
                        If Me.tvMenu.SelectedNode.Parent Is Nothing Then
                            Return
                        ElseIf Me.tvMenu.SelectedNode.Parent.Parent Is Nothing Then
                            Return
                        End If
                End Select

                '是最末级节点，才取值
                If Me.tvMenu.SelectedNode.Nodes.Count <= 0 Then
                    Me.TxtTkey.Text = IIf(Me.tvMenu.SelectedNode.Tag Is Nothing, "", Me.tvMenu.SelectedNode.Tag.ToString)
                    Me.TxtTtext.Text = IIf(Me.tvMenu.SelectedNode.Text Is Nothing, "", Me.tvMenu.SelectedNode.Text.ToString)
                    Me.TxtTtext.Text = TxtTtext.Text.Replace(Me.TxtTkey.Text + "-", "")   '去掉前缀
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 过滤
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RbFilter_CheckedChanged(sender As Object, e As EventArgs) Handles RbFilter.CheckedChanged
        BtnRefresh.PerformClick()
    End Sub

    ''' <summary>
    ''' 全部，不过滤
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RbUnFilter_CheckedChanged(sender As Object, e As EventArgs) Handles RbUnFilter.CheckedChanged
    End Sub

#End Region

End Class