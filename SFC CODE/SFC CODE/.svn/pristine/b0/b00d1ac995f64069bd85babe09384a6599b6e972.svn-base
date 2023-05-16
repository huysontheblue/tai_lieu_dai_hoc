
''' <summary>
''' 弹出窗口：系统菜单树
''' </summary>
''' <remarks></remarks>
Public Class FrmSelectMenuTree

    Dim _Tkey As String = ""    '父窗体传递过来的父节点Tkey值

#Region "加载菜单树"

    ''' <summary>
    ''' 窗体加载初始化数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        '获取菜单数据
        Dim dt As DataTable = New DataTable
        dt = GetAllMenu(" AND 1=1 ")  '加载菜单和权限节点
        'dt = GetAllMenu(" AND 1=1 AND listy='Y' ")  '只加载菜单节点

        '显示菜单树
        Me.tvMenu.Nodes.Clear()
        Me.tvMenu.Enabled = True
        If Not dt Is Nothing And dt.Rows.Count > 0 Then
            LoadMenuTree(dt, Me.tvMenu.Nodes, "0_")

            '展开一级树节点，并默认选中
            If (Me.tvMenu.Nodes.Count > 0) Then
                Me.tvMenu.Nodes(0).Expand()
                'Me.tvMenu.SelectedNode = tvMenu.Nodes(0)   '停用此句
            End If
        Else
            MessageBox.Show("未查询到菜单数据", "提示")
        End If
    End Sub

    ''' <summary>
    ''' 系统菜单数据源
    ''' </summary>
    ''' <param name="strWhre">查询条件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllMenu(ByVal strWhre As String) As DataTable
        Dim dt As DataTable = New DataTable
        dt = MainFrame.DbOperateUtils.GetDataTable("SELECT * FROM m_Logtree_t WHERE Rightid='mes00' " + strWhre + "")
        Return dt
    End Function

    ''' <summary>
    ''' 加载系统菜单
    ''' </summary>
    ''' <param name="dt">系统菜单数据源</param>
    ''' <param name="treeNodeList">treeNode节点集合</param>
    ''' <param name="tParent">树状父节点</param>
    ''' <remarks></remarks>
    Private Sub LoadMenuTree(ByVal dt As DataTable, ByVal treeNodeList As TreeNodeCollection, ByVal tParent As String)
        Try
            Dim tkey As String = ""
            Dim ttext As String = ""
            Dim dr As DataRow
            For Each dr In dt.Select("tParent='" + tParent + "'")
                tkey = IIf(dr("Tkey") Is Nothing, "", dr("Tkey").ToString())
                ttext = IIf(dr("Ttext") Is Nothing, "", dr("Ttext").ToString())
                If String.IsNullOrEmpty(tkey) = False Then
                    '加载节点
                    Dim tn As TreeNode = New TreeNode
                    tn.Tag = tkey
                    tn.Text = tkey + "-" + ttext
                    tn.ToolTipText = dr("Tparent").ToString()
                    treeNodeList.Add(tn)
                    '如果有子节点，递归加载
                    If dt.Select("tParent='" + tn.Tag + "'").Length > 0 Then
                        LoadMenuTree(dt, tn.Nodes, tn.Tag)
                    End If

                    '如父窗体有传过来节点值，则默认选中
                    If String.IsNullOrEmpty(Me._Tkey) = False Then
                        If tn.Tag = Me._Tkey Then
                            Me.tvMenu.SelectedNode = tn
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            'MessageBox.Show(ex.Message & vbNewLine & "加载菜单树失败", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "标准事件"

    Sub New(ByVal Tkey As String)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._Tkey = Tkey
    End Sub

    ''' <summary>
    ''' 窗体的默认加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSelectMenuTree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnRefresh.PerformClick()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        LoadData()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        If String.IsNullOrEmpty(Me.TxtTkey.Text.Trim) = True Then
            MessageBox.Show("请先选择一个菜单节点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        '给父窗口返回数据
        Dim frmParent As FrmSysMenu = Me.Owner
        frmParent.Tparent = Me.TxtTkey.Text.Trim
        frmParent.TxtParentName.Text = Me.TxtTtext.Text.Trim
        Me.Close()
    End Sub

    ''' <summary>
    ''' 选中节点后，显示到文本框内
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvMenu.AfterSelect
        If Not Me.tvMenu.SelectedNode Is Nothing Then
            Me.TxtTkey.Text = IIf(Me.tvMenu.SelectedNode.Tag Is Nothing, "", Me.tvMenu.SelectedNode.Tag.ToString)
            Me.TxtTtext.Text = IIf(Me.tvMenu.SelectedNode.Text Is Nothing, "", Me.tvMenu.SelectedNode.Text.ToString)
            Me.TxtTtext.Text = TxtTtext.Text.Replace(Me.TxtTkey.Text + "-", "")   '去掉前缀
        End If
    End Sub

#End Region

End Class

