Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Text
Imports MainFrame

Public Class FrmLineType

    Private Sub uxSelectedCheckItemTreeView_DragDrop(ByVal sender As System.Object, _
                                                     ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedTypeTreeView.DragDrop
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
            If dropNode.TreeView.Name = "uxSelectedTypeTreeView" Then
                Exit Sub
            End If
            '结点不可重复
            If Me.ContainsNode(selectedTreeview, dropNode) Then
                MessageBox.Show("产品类型已存在，请勿重复")
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

    Private Sub uxSelectedCheckItemTreeView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxSelectedTypeTreeView.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub uxSelectedCheckItemTreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxSelectedTypeTreeView.ItemDrag
        Dim item As TreeNode = CType(e.Item, TreeNode)
        If item.Parent Is Nothing Then
            Me.DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub

    Private Sub uxCheckItemList_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxTypeList.DragEnter
        '托动是否为treenode
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            '设置移动效果
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub uxCheckItemList_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uxTypeList.DragDrop
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

    Private Sub uxCheckItemList_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles uxTypeList.ItemDrag
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

    Sub New(ByVal lineId As String, ByVal isAdd As Boolean, ByVal isDelete As Boolean)
        _lineId = lineId
        _isAdd = isAdd
        _isDelete = isDelete
        InitializeComponent()
    End Sub

    Private _lineId As String 'Integer
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
            Label1.Text = String.Format("线别:{0} {1}({2})", _lineId, Label1.Text, "从左拖到右为删除")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadRootNotes()
        Dim sql As String = Nothing
        Try
            sql = "SELECT DISTINCT N'产品类型' as typename FROM m_ProductType_t WHERE usey='Y'"
            Using dt As DataTable = sConn.GetDataTable(sql)
                uxTypeList.Nodes.Clear()
                For Each dr As DataRow In dt.Rows
                    Dim node As New TreeNode(dr(0).ToString)
                    node.Tag = dr(0).ToString
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    node.ForeColor = Drawing.Color.Blue
                    Me.uxTypeList.Nodes.Add(node)
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("加载父节点错误" + ex.Message)
        End Try
    End Sub
    '子节点
    Private Sub LoadSubNotes()
        Dim sql As String = Nothing
        Dim o_index As Integer = 0
        Try
            sql = " SELECT  typeid ,typename " & _
                  " FROM m_ProductType_t WHERE usey='Y' ORDER BY typeid"
            Using dt As DataTable = sConn.GetDataTable(sql)
                For Each rootNodes As TreeNode In Me.uxTypeList.Nodes
                    Dim dv As New DataView(dt)
                    ' dv.RowFilter = "CATEGORY='" & rootNodes.Tag.ToString & "'"
                    For Each drv As DataRowView In dv
                        o_index = o_index + 1
                        Dim subNode As New TreeNode(drv(1).ToString)
                        subNode.Tag = drv(0).ToString
                        subNode.ImageIndex = o_index 'drv(0)
                        subNode.SelectedImageIndex = 0
                        subNode.Name = drv(1).ToString
                        subNode.ToolTipText = drv(1).ToString
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
        Dim o_Index As Integer = 0
        Dim o_strSQL As String = String.Empty
        Try

            o_strSQL = " SELECT  a.typeid, a.typename" & _
                                " FROM m_LineProductType_t a " & _
                                " LEFT JOIN m_ProductType_t b ON a.typeid = b.typeid " & _
                                " WHERE a.lineid='" & _lineId & "'" & _
                                " ORDER BY b.typeid"
            Using dt As DataTable = sConn.GetDataTable(o_strSQL)
                uxSelectedTypeTreeView.Nodes.Clear()
                For Each dr As DataRow In dt.Rows
                    o_Index = o_Index + 1
                    Dim node As New TreeNode(dr(1).ToString)
                    node.Tag = dr(0).ToString 'dr(1).ToString
                    node.ImageIndex = o_Index 'dr(0).ToString
                    node.SelectedImageIndex = 1
                    node.Name = dr(1).ToString 'dr(3).ToString
                    node.ForeColor = Drawing.Color.Blue
                    Me.uxSelectedTypeTreeView.Nodes.Add(node)
                Next
            End Using
        Catch ex As Exception
            Throw New Exception("获取该线别的产品类型失败" + ex.Message)
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
        Dim strSql As String = String.Empty
        Dim o_sbSQL As StringBuilder = New StringBuilder
        strSql = " SELECT typeid FROM M_LineProductType_t " & _
                 " WHERE Lineid='" & _lineId & "' AND typeid='" & node.Tag & "'"
        If sConn.GetRowsCount(strSql) > 0 Then
            MessageBox.Show(String.Format("线别:{0},产品类型{1}已经存在，请勿重复添加", _stationName, node.Tag))
            Return False
        End If

        o_sbSQL.Append("IF ISNULL((SELECT 1 FROM m_LineProductType_t WHERE Lineid='" & _lineId & "' AND typeid='" & node.Tag & "'),0)<>1")
        o_sbSQL.Append(" BEGIN ")
        o_sbSQL.Append(" INSERT INTO m_LineProductType_t(Lineid,typeid,typename,INTIME,USERID) VALUES")
        o_sbSQL.Append(" ('" & _lineId & "','" & node.Tag & "',N'" & node.Text & "',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "')")
        o_sbSQL.Append(" END ELSE BEGIN ")
        o_sbSQL.Append(" UPDATE m_LineProductType_t SET INTIME=GETDATE(),USERID='" & VbCommClass.VbCommClass.UseId & "'")
        o_sbSQL.Append("  WHERE Lineid='" & _lineId & "' AND typeid='" & node.Tag & "' ")
        o_sbSQL.Append("  END")

        '       update deptlineD_t set typeid = ISNULL(typeid,'') + IIF(ISNULL(TYPEID,'')='','',',') +  'E04'
        'WHERE LINEID ='XT001'

        o_sbSQL.Append(" UPDATE deptlineD_t SET typeid = ISNULL(typeid,'') + IIF(ISNULL(TYPEID,'')='','',',')+ '" & node.Tag & "', ")
        o_sbSQL.Append(" typename = isnull(typename,'') + iif(isnull(typename,'')='','',',') + N'" & node.Text & "'")
        o_sbSQL.Append(" WHERE LINEID ='" & _lineId & "'")

        sConn.ExecSql(o_sbSQL.ToString)
        Return True
    End Function

    Private Function RemoveFromDB(ByRef node As TreeNode) As Boolean
        Dim o_sbSQL As StringBuilder = New StringBuilder
        Dim strSQL As String = String.Empty
        Dim o_strTypeid As String = "", o_strFinshTypeid As String = ""
        'First get the typeid list
        strSQL = " SELECT typeid FROM deptlineD_t " & _
                 " WHERE Lineid='" & _lineId & "'"
        Using o_dt As DataTable = sConn.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                o_strTypeid = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
            End If
        End Using
        If Not String.IsNullOrEmpty(o_strTypeid) Then
            For Each tempTypeid As String In o_strTypeid.Split(",")
                If tempTypeid = node.Tag Then
                    'do nothing 
                Else
                    o_strFinshTypeid = o_strFinshTypeid + IIf(o_strFinshTypeid = "", "", ",") + tempTypeid
                End If
            Next
        End If

        o_sbSQL.Append(" DELETE FROM m_LineProductType_t  WHERE LineID='" & _lineId & "' AND typeid='" & node.Tag & "'")
        o_sbSQL.Append(" UPDATE deptlineD_t set typeid = '" & o_strFinshTypeid & "' ")
        o_sbSQL.Append(" WHERE LINEID ='" & _lineId & "'")

        sConn.ExecSql(o_sbSQL.ToString)
        Return True
    End Function

End Class