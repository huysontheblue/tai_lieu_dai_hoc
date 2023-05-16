Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports MainFrame

Public Class FrmSetUserProfit

    Dim SqlCheckStr As New StringBuilder

    '初始化
    Private Sub FrmSetUserProfit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageUtils.ShowWarning("温馨提示，请选择您正确的利润中心！")
        Treeload()
        CheckData(SysMessageClass.UseId)
    End Sub

    '选择数据
    Private Sub UserTree_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles UserTree.AfterCheck

        If e.Action <> TreeViewAction.Unknown Then
            Me.UserTree.BeginUpdate()
            Try

                If e.Node.Parent IsNot Nothing Then
                    Dim bFlag As Boolean = False
                    For Each node As TreeNode In e.Node.Parent.Nodes
                        If node.Checked = True Then
                            bFlag = True
                            Exit For
                        End If
                    Next
                    '子节点都没有选择
                    If bFlag = False Then
                        e.Node.Parent.Checked = False
                        RightAddorDel(e.Node.Parent.Name, e.Node.Parent, SysMessageClass.UseId, 0, False, True)
                    End If
                End If

                RightAddorDel(e.Node.Name, e.Node, SysMessageClass.UseId, e.Node.Nodes.Count, e.Node.Checked, True)
            Catch ex As Exception
                Throw ex
            Finally
                SqlCheckStr.Remove(0, SqlCheckStr.Length - 1)
            End Try

            Me.UserTree.EndUpdate()
        End If

    End Sub

    '确定
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        Dim seletedCnt As Integer = 0
        '
        For Each node As TreeNode In UserTree.Nodes
            If node.Checked = True Then
                seletedCnt = seletedCnt + 1
            End If
        Next

        If seletedCnt = 0 Then
            MessageUtils.ShowError("请至少选择一个厂区利润中心！")
            Exit Sub
        End If

        If seletedCnt <> 1 Then
            MessageUtils.ShowError("只能选择一个厂区,特殊权限人员，请联系MES人员增加权限！")
            Exit Sub
        End If
        '更新用户标志
        SetUpdateUser()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    '取消
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "方法"

    Private Sub SetUpdateUser()
        Dim strSQL As String = "update m_Users_t set  OMd = 'Y' where UserID = '{0}'"
        strSQL = String.Format(strSQL, SysMessageClass.UseId)

        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    Private Sub RightAddorDel(ByVal NodeName As String, ByVal Node As TreeNode, ByVal StrUserid As String, ByVal NodesCount As Integer, ByVal AddOrDel As Boolean, ByVal NodeChecky As Boolean)

        SqlCheckStr = New StringBuilder
        If AddOrDel = True Then
            SqlCheckStr.Append("insert m_userright_t values('" & StrUserid & "','" & NodeName & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            CheckAllParentNodes(Node, StrUserid, NodeChecky)
            If NodesCount > 0 Then
                Me.CheckAllChildNodes(Node, StrUserid, AddOrDel, NodeChecky)
            End If
        Else
            SqlCheckStr.Append("delete from m_userright_t where tkey='" & NodeName & "' and userid='" & StrUserid & "'")
            SqlCheckStr.Append(Environment.NewLine)
            If NodesCount > 0 Then
                Me.CheckAllChildNodes(Node, StrUserid, AddOrDel, NodeChecky)
            End If
        End If
        DbOperateUtils.ExecSQL(SqlCheckStr.ToString)

    End Sub

    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal userid As String, ByVal nodeChecked As Boolean, ByVal NodeChecky As Boolean)

        Dim node As TreeNode
        For Each node In treeNode.Nodes
            If NodeChecky Then
                node.Checked = nodeChecked
            End If
            If nodeChecked Then
                SqlCheckStr.Append("insert m_userright_t values('" & userid & "','" & node.Name & "','" & SysMessageClass.UseId & "',getdate())")
                SqlCheckStr.Append(Environment.NewLine)
            Else
                SqlCheckStr.Append("delete from m_userright_t where userid='" & userid & "' and tkey='" & node.Name & "'")
                SqlCheckStr.Append(Environment.NewLine)
            End If
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively
                Me.CheckAllChildNodes(node, userid, nodeChecked, NodeChecky)
            End If
        Next node

    End Sub

    Private Sub CheckAllParentNodes(ByVal treeNode As TreeNode, ByVal Userid As String, ByVal NodeChecky As Boolean)

        If (treeNode Is UserTree.Nodes(0)) Then Exit Sub
        If treeNode.Parent Is Nothing Then Exit Sub

        If treeNode.Parent.Checked = False Then
            If NodeChecky Then
                treeNode.Parent.Checked = True
            End If
            SqlCheckStr.Append("insert m_userright_t values('" & Userid & "','" & treeNode.Parent.Name & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
            treeNode = treeNode.Parent
            Me.CheckAllParentNodes(treeNode, Userid, NodeChecky)
        End If

    End Sub

    Private Sub Treeload()
        Try
            Dim UserTreeDt As DataTable = DbOperateUtils.GetDataTable("select * from m_LogTree_t where rightid='mes00' and Tparent like 'F%' and Usey = 'Y' order by treeid ")
            CreateTree(UserTree, "F0_", Nothing, UserTreeDt, SysMessageClass.Language)
        Catch ex As Exception
            Throw ex
        End Try
        Me.UserTree.ExpandAll()
    End Sub

    Public Sub CreateTree(ByVal treeview As TreeView, ByVal ParentID As String, ByVal pNode As TreeNode, ByVal TreeDt As DataTable, ByVal LagStr As String)
        Dim tempRow As DataRowView
        Dim tempview As DataView
        Dim tableview As New DataView(TreeDt)
        tempview = tableview
        tempview.RowFilter = "Tparent='" & ParentID & "'"
        If tempview.Count > 0 Then
            For Each tempRow In tempview
                Dim Node As New TreeNode
                Try
                    If pNode Is Nothing Then
                        Node.Text = tempRow("Ttext").ToString()

                        treeview.Nodes.Add(Node)
                        Node.ImageIndex = 0
                        Node.SelectedImageIndex = 0
                        Node.Name = tempRow("tkey").ToString()
                        Node.Tag = tempRow("TreeTag").ToString()
                    Else
                        Node.Text = tempRow("Ttext").ToString()
                        pNode.Nodes.Add(Node)
                        Node.Name = tempRow("tkey").ToString()
                        Node.Tag = tempRow("TreeTag").ToString()
                        If Node.Tag = "" Then

                            Node.ImageIndex = 1
                            Node.SelectedImageIndex = 1
                        Else
                            Node.ImageIndex = 2
                            Node.SelectedImageIndex = 2
                        End If
                    End If

                    CreateTree(treeview, tempRow("Tkey").ToString, Node, TreeDt, LagStr)
                Catch err As Exception
                End Try
            Next
        End If

    End Sub

    Private Sub CheckData(ByVal UserIDstring As String)

        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select tkey from m_userright_t where userid='" & UserIDstring & "' and Tkey like 'F%'  order by tkey")

            For Each node As TreeNode In UserTree.Nodes

                node.Checked = False
                ClearAllCheck(node)

                If dt.Rows.Count > 0 Then
                    'node.Checked = True

                    For icnt As Integer = 0 To dt.Rows.Count - 1
                        If node.Name = dt.Rows(icnt)(0).ToString Then
                            node.Checked = True
                        End If
                        CheckSet(node, dt.Rows(icnt)(0).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearAllCheck(ByVal UserNode As TreeNode)

        Dim node As TreeNode
        For Each node In UserNode.Nodes
            node.Checked = False
            If node.Nodes.Count > 0 Then
                'If the current node has child nodes, call the CheckSet method recursively.
                Me.ClearAllCheck(node)
            End If
        Next node

    End Sub

    Private Sub CheckSet(ByVal UserNode As TreeNode, ByVal NodeString As String)

        Dim node As TreeNode
        For Each node In UserNode.Nodes

            If node.Name = NodeString Then
                node.Checked = True
            End If

            If node.Nodes.Count > 0 Then
                'If the current node has child nodes, call the CheckSet method recursively.
                Me.CheckSet(node, NodeString)
            End If
        Next node
    End Sub

#End Region

End Class