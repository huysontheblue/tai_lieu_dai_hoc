Imports MainFrame.SysDataHandle
Imports System.Windows.Forms

Public Class FrmStationCheckItemMaintaince

    Private Sub uxSelectedCheckItemTreeView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedCheckItemTreeView.DragDrop
        Try
            '判断是否可以托动
            'If Not Me.IsAllowDrag() Then
            '    MsgBox("存在未完成的'打印申请单',不可改变标签结构", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'End If
            '托动是否为treenode
            If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
            Dim selectedTreeview As TreeView = CType(sender, TreeView)
            '判断node来源
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            If dropNode.TreeView.Name = "uxSelectedCheckItemTreeView" Then
                Exit Sub
            End If
            '结点不可重复
            If Me.ContainsNode(selectedTreeview, dropNode) Then
                MessageBox.Show("检验项已存在，请勿重复")
                Exit Sub
            End If
            If Not _isAdd Then
                MessageBox.Show("你没有权限新增校验项")
                Exit Sub
            End If
            'If MessageBox.Show("新增检查项，包含该工站的所有流程卡都将切回到制作中状态，请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            '    Exit Sub
            'End If
            '复制
            Dim newNode As TreeNode = dropNode.Clone()
            '写入DB
            If Me.WriteToDB(newNode) Then
                '添加结点
                selectedTreeview.Nodes.Add(newNode)
                newNode.EnsureVisible()
                selectedTreeview.SelectedNode = newNode
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub uxSelectedCheckItemTreeView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedCheckItemTreeView.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub uxSelectedCheckItemTreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxSelectedCheckItemTreeView.ItemDrag
        Dim item As TreeNode = CType(e.Item, TreeNode)
        If item.Parent Is Nothing Then
            Me.DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub

    Private Sub uxCheckItemList_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxCheckItemList.DragEnter
        '托动是否为treenode
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            '设置移动效果
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub uxCheckItemList_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxCheckItemList.DragDrop
        Try
            '判断是否可以托动
            'If Not Me.IsAllowDrag() Then
            '    MsgBox("存在未完成的'打印申请单',不可改变标签结构", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'End If
            '是否为treenode
            If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
            '判断node 来源
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            If dropNode.TreeView.Name = "uxCheckItemList" Then
                Exit Sub
            Else
                '从DB中删除
                If Not _isDelete Then
                    MessageBox.Show("你没有权限删除校验项")
                    Exit Sub
                End If
                'If MessageBox.Show("删除检查项，包含该工站的所有流程卡都将切回到制作中状态，请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                '    Exit Sub
                'End If
                If Me.RemoveFromDB(dropNode) Then
                    '移除托动结点
                    dropNode.Remove()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub uxCheckItemList_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxCheckItemList.ItemDrag
        Dim item As TreeNode = CType(e.Item, TreeNode)
        If Not item.Parent Is Nothing Then
            Me.DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Sub New(ByVal stationId As Integer, ByVal stationNo As String, ByVal stationName As String, ByVal isAdd As Boolean, ByVal isDelete As Boolean)
        _stationId = stationId
        _stationNo = stationNo
        _stationName = stationName
        _isAdd = isAdd
        _isDelete = isDelete
        InitializeComponent()
    End Sub

    Private _stationId As Integer
    Private _stationNo As String
    Private _stationName As String
    Private _isAdd As Boolean
    Private _isDelete As Boolean
    Private sConn As New SysDataBaseClass

    Private Sub FrmStationCheckItemMaintain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadRootNotes()
            LoadSubNotes()
            LoadLeftNotes()
            Label1.Text = String.Format("工站:{0} {1}({2})", _stationName, Label1.Text, "从左拖到右为删除")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadRootNotes()
        Dim sql As String = Nothing
        Try
            sql = "SELECT DISTINCT CATEGORY FROM M_RUNCARDCHECKITEM_T WHERE STATUS='Y' ORDER BY CATEGORY"
            Using dt As DataTable = sConn.GetDataTable(sql)
                uxCheckItemList.Nodes.Clear()
                For Each dr As DataRow In dt.Rows
                    Dim node As New TreeNode(dr(0).ToString)
                    node.Tag = dr(0).ToString
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    node.ForeColor = Drawing.Color.Blue
                    Me.uxCheckItemList.Nodes.Add(node)
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("加载父节点错误" + ex.Message)
        End Try
    End Sub

    Private Sub LoadSubNotes()
        Dim sql As String = Nothing
        Try
            sql = "SELECT ID, CODE,DESCRIPTION, CATEGORY,CHECKGROUP FROM M_RUNCARDCHECKITEM_T WHERE STATUS='Y' ORDER BY CATEGORY"
            Using dt As DataTable = sConn.GetDataTable(sql)
                For Each rootNodes As TreeNode In Me.uxCheckItemList.Nodes
                    Dim dv As New DataView(dt)
                    dv.RowFilter = "CATEGORY='" & rootNodes.Tag.ToString & "'"
                    For Each drv As DataRowView In dv
                        Dim subNode As New TreeNode(drv(2).ToString)
                        subNode.Tag = drv(1).ToString
                        subNode.ImageIndex = drv(0)
                        subNode.SelectedImageIndex = 0
                        subNode.Name = drv(4).ToString
                        subNode.ToolTipText = drv(2).ToString
                        rootNodes.Nodes.Add(subNode)
                    Next
                    rootNodes.ExpandAll()
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("加载子节点错误" + ex.Message)
        End Try
    End Sub

    Private Sub LoadLeftNotes()
        Try
            Dim sql As String = "SELECT CHECKITEMID,CHECKITEMCODE,DESCRIPTION,CHECKGROUP FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONNO='" & _stationNo & "' AND STATUS='Y'"
            Using dt As DataTable = sConn.GetDataTable(sql)
                uxSelectedCheckItemTreeView.Nodes.Clear()
                For Each dr As DataRow In dt.Rows
                    Dim node As New TreeNode(dr(2).ToString)
                    node.Tag = dr(1).ToString
                    node.ImageIndex = dr(0).ToString
                    node.SelectedImageIndex = 1
                    node.Name = dr(3).ToString
                    node.ForeColor = Drawing.Color.Blue
                    Me.uxSelectedCheckItemTreeView.Nodes.Add(node)
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("获取工站校验项失败" + ex.Message)
        End Try

    End Sub

#Region "判断结点是否重复"
    Private Function ContainsNode(ByVal treeView As TreeView, ByVal node As TreeNode)
        For Each item As TreeNode In treeView.Nodes
            'FormatID 相同 侧为重复
            If item.Tag.ToString = node.Tag.ToString Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
    Private Function WriteToDB(ByRef node As TreeNode) As Boolean
        Dim strSql As String = "SELECT CHECKITEMCODE FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONNO='" & _stationNo & "' AND CHECKITEMCODE='" & node.Tag & "' AND STATUS='Y'"
        If sConn.GetRowsCount(strSql) > 0 Then
            MessageBox.Show(String.Format("工站:{0},校验项{1}已经存在，请勿重复添加", _stationName, node.Tag))
            Return False
        End If
        strSql = "IF ISNULL((SELECT 1 FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONNO='" & _stationNo & "' AND CHECKITEMCODE='" & node.Tag & "'),0)<>1" & _
                    " BEGIN" & _
                    " INSERT INTO M_RUNCARDSTATIONCHECKITEM_T(STATIONID,STATIONNO,STATIONNAME,CHECKITEMID,CHECKITEMCODE,DESCRIPTION,STATUS,INTIME,USERID,CHECKGROUP) VALUES" & _
                    " (" & _stationId & ",'" & _stationNo & "',N'" & _stationName & "'," & node.ImageIndex & ",'" & node.Tag & "',N'" & node.Text & "','Y',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','" & node.Name & "')" & _
                    " END ELSE BEGIN" & _
                    " UPDATE M_RUNCARDSTATIONCHECKITEM_T SET STATUS='Y',INTIME=GETDATE(),STATIONNAME='" & _stationName & "',USERID='" & VbCommClass.VbCommClass.UseId & "',DESCRIPTION=N'" & node.Text & "' WHERE STATIONNO='" & _stationNo & "' AND CHECKITEMCODE='" & node.Tag & "' " & _
                    " END"
        sConn.ExecSql(strSql)
        Return True
    End Function

    Private Function RemoveFromDB(ByRef node As TreeNode) As Boolean
        Dim strSql As String = " DELETE FROM M_RUNCARDSTATIONCHECKITEM_T  WHERE STATIONNO='" & _stationNo & "' AND CHECKITEMCODE='" & node.Tag & "'" & vbNewLine & _
" DELETE FROM  M_RUNCARDDETAILCHECKITEM_T WHERE STATIONNO='" & _stationNo & "' AND CHECKITEMCODE='" & node.Tag & "'"
        ' " UPDATE M_RUNCARDDETAIL_T SET PROCESSSTANDARD=B.RVAL" & vbNewLine & _
        '" FROM M_RUNCARDDETAIL_T A,(" & vbNewLine & _
        '" SELECT A.PARTNUMBER,( " & vbNewLine & _
        '" SELECT (B.DESCRIPTION+':'+B.RESULTVALUE)+'; ' " & vbNewLine & _
        '" FROM M_RUNCARDDETAILCHECKITEM_T B " & vbNewLine & _
        '"        WHERE(B.STATIONID = " & _stationId & ")" & _
        '" AND  B.RESULTVALUE<>'' AND B.STATUS='Y' AND B.CHECKITEMCODE<>'" & node.Tag & "' " & vbNewLine & _
        '" AND B.PARTNUMBER=A.PARTNUMBER" & vbNewLine & _
        '" ORDER BY B.CHECKGROUP FOR XML PATH('') ) RVAL " & vbNewLine & _
        '" FROM M_RUNCARDDETAILCHECKITEM_T A WHERE A.STATIONID=" & _stationId & " AND CHECKITEMCODE='" & node.Tag & "'" & vbNewLine & _
        '" GROUP BY A.PARTNUMBER)B WHERE A.PARTNUMBER=B.PARTNUMBER" & _
        '" AND A.STATIONID=" & _stationId & "" & vbNewLine & _

        sConn.ExecSql(strSql)
        Return True
    End Function

    'Private Sub uxCheckItemList_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxCheckItemList.ItemDrag
    '    Dim item As TreeNode = CType(e.Item, TreeNode)
    '    If Not item.Parent Is Nothing Then
    '        Me.DoDragDrop(e.Item, DragDropEffects.Move)
    '    End If
    'End Sub

    'Private Sub uxSelectedCheckItemTreeView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedCheckItemTreeView.DragDrop
    '    Try
    '        '判断是否可以托动
    '        'If Not Me.IsAllowDrag() Then
    '        '    MsgBox("存在未完成的'打印申请单',不可改变标签结构", MsgBoxStyle.OkOnly)
    '        '    Exit Sub
    '        'End If
    '        '托动是否为treenode
    '        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
    '        Dim selectedTreeview As TreeView = CType(sender, TreeView)
    '        '判断node来源
    '        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
    '        If dropNode.TreeView.Name = "uxSelectedCheckItemTreeView" Then
    '            Exit Sub
    '        End If
    '        '结点不可重复
    '        If Me.ContainsNode(selectedTreeview, dropNode) Then
    '            MessageBox.Show("检验项已存在，请勿重复")
    '            Exit Sub
    '        End If
    '        If Not _isAdd Then
    '            MessageBox.Show("你没有权限新增校验项")
    '            Exit Sub
    '        End If
    '        'If MessageBox.Show("新增检查项，包含该工站的所有流程卡都将切回到制作中状态，请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
    '        '    Exit Sub
    '        'End If
    '        '复制
    '        Dim newNode As TreeNode = dropNode.Clone()
    '        '写入DB
    '        If Me.WriteToDB(newNode) Then
    '            '添加结点
    '            selectedTreeview.Nodes.Add(newNode)
    '            newNode.EnsureVisible()
    '            selectedTreeview.SelectedNode = newNode
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub uxSelectedCheckItemTreeView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedCheckItemTreeView.DragEnter
    '    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
    '        e.Effect = DragDropEffects.Move
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub uxSelectedCheckItemTreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxSelectedCheckItemTreeView.ItemDrag
    '    Dim item As TreeNode = CType(e.Item, TreeNode)
    '    If item.Parent Is Nothing Then
    '        Me.DoDragDrop(e.Item, DragDropEffects.Move)
    '    End If
    'End Sub

    'Private Sub uxCheckItemList_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxCheckItemList.DragDrop
    '    Try
    '        '判断是否可以托动
    '        'If Not Me.IsAllowDrag() Then
    '        '    MsgBox("存在未完成的'打印申请单',不可改变标签结构", MsgBoxStyle.OkOnly)
    '        '    Exit Sub
    '        'End If
    '        '是否为treenode
    '        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
    '        '判断node 来源
    '        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
    '        If dropNode.TreeView.Name = "uxCheckItemList" Then
    '            Exit Sub
    '        Else
    '            '从DB中删除
    '            If Not _isDelete Then
    '                MessageBox.Show("你没有权限删除校验项")
    '                Exit Sub
    '            End If
    '            'If MessageBox.Show("删除检查项，包含该工站的所有流程卡都将切回到制作中状态，请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
    '            '    Exit Sub
    '            'End If
    '            If Me.RemoveFromDB(dropNode) Then
    '                '移除托动结点
    '                dropNode.Remove()

    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub uxCheckItemList_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxCheckItemList.DragEnter
    '    '托动是否为treenode
    '    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
    '        '设置移动效果
    '        e.Effect = DragDropEffects.Move
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub


End Class