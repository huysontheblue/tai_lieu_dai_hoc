Imports MainFrame
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports DevComponents.AdvTree

Public Class FrmRoleManage
    Public opFlag As Int16 = 0 '判断是新增还是修改
    Dim TreeClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim sqlCheckStr As New StringBuilder

    Private Sub FrmRoleManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataToDatagridview("  ")  '加载角色表
        TreeLoad() '角色对应权限
        ToolBtnState(opFlag) '按钮状态
        CheckTree() '角色对应权限
    End Sub

#Region "事件"
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.txtRoleName.Text = ""
        Me.txtRoleDetail.Text = ""
        Me.chkUsey.Checked = True
        opFlag = 1
        ToolBtnState(1)
    End Sub
    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        '判断记录是否可以被修改
        If Me.dgvRole.Rows.Count = 0 OrElse Me.dgvRole.CurrentRow Is Nothing Then Exit Sub
        '控件赋值
        Me.txtRoleName.Text = dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim
        Me.txtRoleDetail.Text = dgvRole.Item(1, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim
        Me.chkUsey.Checked = IIf(dgvRole.Item(2, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim = "Y", True, False)
        '改变窗体状态
        opFlag = 2
        ToolBtnState(2)
        Me.txtRoleName.Enabled = False
    End Sub
    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass

        '判断记录是否可以被作废
        If Me.dgvRole.Rows.Count = 0 OrElse Me.dgvRole.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvRole.Item(2, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim <> "Y" Then
            MessageBox.Show("该角色名称已经被作废，不允许再作废！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim roleName As String = Me.dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim
        Dim roleDetail As String = Me.dgvRole.Item(1, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("确定要作废角色:[" + roleName + "]吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Try
            conn.ExecSql("update [dbo].[m_Role_t] set [Role_Acitve]=0,[Createuser]='" & MainFrame.SysCheckData.SysMessageClass.UseId.ToLower.Trim & "',[Intime]=getdate() where [Role_Name]=N'" & Me.dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim & "'")
            MessageBox.Show("成功作废工厂：[" + Me.dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim + "]", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" ")
        Catch ex As Exception

        End Try
    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        txtRoleName.Text = ""
        txtRoleDetail.Text = ""
        opFlag = 0
        ToolBtnState(0)
    End Sub
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim flag As Boolean = False
        Dim sql As String = " where 1=1 "

        If Me.txtRoleName.Text.Trim <> "" Then
            sql = sql & " and Role_Name like N'%" & Me.txtRoleName.Text.Trim & "%' "
        End If
        If Me.txtRoleDetail.Text.Trim <> "" Then
            sql = sql & " and Role_Desc like N'%" & Me.txtRoleDetail.Text.Trim & "%' "
        End If
        LoadDataToDatagridview(sql)
        CheckTree()
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sqlStr As New StringBuilder
        Dim roleCount As String = ""
        Dim roleId As String

        If CheckData() = False Then Exit Sub

        If opFlag = 1 Then  '新增后保存执行插入操作
            Dim mCheckNameRead As SqlDataReader = conn.GetDataReader("select Role_Name,Role_Desc from m_Role_t  where Role_Name=N'" & Me.txtRoleName.Text.Trim & "'")
            If mCheckNameRead.HasRows Then
                mCheckNameRead.Close()
                MessageBox.Show("角色名称已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckNameRead.Close()

            Dim mRead As SqlDataReader = conn.GetDataReader("select Count(*)  as countRoleId from m_Role_t ")
            If mRead.HasRows Then
                While mRead.Read
                    roleCount = Convert.ToInt16(mRead!countRoleId) + 1
                End While
            Else
                roleCount = "1"
            End If
            mRead.Close()

            roleId = "R" + roleCount.PadLeft(3, "0")
            '增加角色数据
            sqlStr.Append(ControlChars.CrLf & "INSERT INTO [dbo].[m_Role_t] ([Role_Id],[Role_Name],[Role_Desc],[Role_Acitve],[Createuser],[Intime]) " _
                    & "  VALUES('" & roleId & "',N'" & Me.txtRoleName.Text.Trim & "',N'" & Me.txtRoleDetail.Text.Trim & "',1,'" & MainFrame.SysCheckData.SysMessageClass.UseId.ToLower & "',getdate())")
        ElseIf opFlag = 2 Then
            sqlStr.Append("update [dbo].[m_Role_t] set [Role_Desc]=N'" & Me.txtRoleDetail.Text.Trim & "',[Role_Acitve]='" & IIf(Me.chkUsey.Checked, 1, 0) & "',[Createuser]='" & MainFrame.SysCheckData.SysMessageClass.UseId.ToLower.Trim & "',[Intime]=getdate() where [Role_Name]=N'" & Me.txtRoleName.Text.Trim & "'")
        End If

        Try
            conn.ExecSql(sqlStr.ToString)
            LoadDataToDatagridview(" where Role_Name=N'" & Me.txtRoleName.Text.Trim & "'")
            MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.txtRoleName.Text = ""
            Me.txtRoleDetail.Text = ""
            chkUsey.Checked = True

            CheckTree()

            opFlag = 0
            ToolBtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "", "tsbSave_Click", "sys")
            Exit Sub
        End Try
    End Sub
    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    'datagridView最前面一列显示为序号
    Private Sub dgvRole_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvRole.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgvRole.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    '选中treeview后
    Private Sub UserTree_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterCheck
        If e.Action <> TreeViewAction.Unknown Then

            '当datagridview中没有选中角色时  不执行此方法
            If Me.dgvRole.Rows.Count = 0 OrElse Me.dgvRole.CurrentRow Is Nothing Then Exit Sub

            Me.UserTree.BeginUpdate()
            Try
                Dim sqlStr As String = "select Role_Id from m_Role_t   where [Role_Name]=N'" & Me.dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim & "'"
                Dim roleId As String = TreeClass.GetDataTable(sqlStr).Rows(0)(0).ToString
                RightAddorDel(e.Node.Name, e.Node, roleId, e.Node.Nodes.Count, e.Node.Checked, True)
            Catch ex As Exception
                Throw ex
            Finally
                sqlCheckStr.Remove(0, sqlCheckStr.Length - 1)
            End Try

            Me.UserTree.EndUpdate()
        End If
    End Sub

    '选中datagridview  右面显示角色权限
    Private Sub dgvRole_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRole.CellClick
        If e.RowIndex = -1 OrElse Me.dgvRole.RowCount < 1 Then Exit Sub
        CheckTree()
        Me.UserTree.Focus()
        Me.UserTree.SelectedNode = Me.UserTree.Nodes(0)
        Me.UserTree.Nodes(0).Checked = True
    End Sub
#End Region
  
#Region "方法"
    ''' <summary>
    ''' 填充角色datagridview
    ''' </summary>
    ''' <param name="sqlWhere"></param>
    ''' <remarks></remarks>
    Private Sub LoadDataToDatagridview(ByVal sqlWhere As String)
        Dim conn As New SysDataHandle.SysDataBaseClass
        Dim dReader As SqlDataReader
        Dim sqlStr As String = ""
        Try
            dgvRole.Rows.Clear()
            sqlStr = "select Role_Name,Role_Desc,Role_Acitve from m_Role_t  "
            dReader = conn.GetDataReader(sqlStr & sqlWhere & " order by Role_Acitve desc ")
            Do While dReader.Read()
                Dim usey As String
                If dReader.Item(2).ToString = 0 Then
                    usey = "N"
                ElseIf dReader.Item(2).ToString = 1 Then
                    usey = "Y"
                End If

                dgvRole.Rows.Add(dReader.Item(0).ToString, dReader.Item(1).ToString, usey)
            Loop
            dReader.Close()
        Catch ex As Exception

        Finally
            conn = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 设置按钮及Textbox状态
    ''' </summary>
    ''' <param name="flag"></param>
    ''' <remarks></remarks>
    Private Sub ToolBtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '判断查询状态
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.txtRoleName.Enabled = True
                Me.chkUsey.Checked = True
                ' Me.ActiveControl = Me.txtRoleName  'ActiveControl属性：用来获取或设置容器控件中的活动控件。窗体也是一种容器控件
            Case 1, 2  '判断新增修改状态
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.ActiveControl = Me.txtRoleName
        End Select
    End Sub

    ''' <summary>
    ''' 保存之前进行判断
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        If Me.txtRoleName.Text.Trim = "" Then
            MessageBox.Show("请选择角色名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtRoleName
            Return False
        End If
        If Me.txtRoleDetail.Text.Trim = "" Then
            MessageBox.Show("请输入角色描述！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtRoleDetail
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 加载TreeView树
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TreeLoad()
        Dim userTreeDT As DataTable
        Try
            Dim sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            userTreeDT = TreeClass.GetDataTable(" select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where rightid='mes00' order by Tparent,OrderBy  ")
            TreeClass.PubConnection.Close()
            CreateTree(UserTree, "0_", Nothing, userTreeDT)
            userTreeDT = Nothing
        Catch ex As Exception
            Throw ex
        End Try

        '展开一级节点
        If Not UserTree Is Nothing Then
            If UserTree.Nodes.Count > 0 Then
                UserTree.Nodes(0).Expand()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 递归遍历权限表到TreeView中
    ''' </summary>
    ''' <param name="treeview"></param>
    ''' <param name="parentId"></param>
    ''' <param name="pNode"></param>
    ''' <param name="treeDt"></param>
    ''' <remarks></remarks>
    Private Sub CreateTree(ByVal treeview As TreeView, ByVal parentId As String, ByVal pNode As TreeNode, ByVal treeDt As DataTable)
        Dim tempRow As DataRowView
        Dim tempview As DataView
        Dim tableview As New DataView(treeDt) '将DateTable存到DataView中 便于筛选数据
        tempview = tableview
        tempview.RowFilter = "Tparent='" & parentId & "'"    '利用DataView将数据进行筛选，筛选出相同父id值相同的数据
        Try
            If tempview.Count > 0 Then
                For Each tempRow In tempview
                    Dim node As New TreeNode  '建立TreeNode的节点 将取出的数据添加到节点中
                    Try
                        If pNode Is Nothing Then
                            node.Text = tempRow("Ttext").ToString
                            node.Name = tempRow("tkey").ToString
                            node.Tag = tempRow("TreeTag").ToString
                            treeview.Nodes.Add(node)
                        Else
                            node.Text = tempRow("Ttext").ToString
                            node.Name = tempRow("tkey").ToString
                            node.Tag = tempRow("TreeTag").ToString
                            pNode.Nodes.Add(node)
                        End If
                        CreateTree(treeview, tempRow("Tkey").ToString, node, treeDt)
                    Catch ex As Exception

                    End Try
                Next
            End If
        Catch ex As Exception
        Finally
            If Not IsNothing(tableview) Then tableview = Nothing
            If Not IsNothing(tempview) Then tempview = Nothing
        End Try

    End Sub
    ''' <summary>
    ''' '选中时插入权限 取消时 删除权限
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="node"></param>
    ''' <param name="roleId"></param>
    ''' <param name="nodesCount"></param>
    ''' <param name="addOrDel"></param>
    ''' <param name="nodeChecky"></param>
    ''' <remarks></remarks>
    Private Sub RightAddorDel(ByVal nodeName As String, ByVal node As TreeNode, ByVal roleId As String, ByVal nodesCount As Integer, ByVal addOrDel As Boolean, ByVal nodeChecky As Boolean)
        sqlCheckStr = New StringBuilder
        If addOrDel = True Then
            sqlCheckStr.Append(" INSERT INTO [dbo].[m_RoleRight_t]  values('" & roleId & "','" & nodeName & "','" & SysMessageClass.UseId.ToLower & "',GETDATE()) ")
            sqlCheckStr.Append(Environment.NewLine)
            CheckAllParentNodes(node, roleId, nodeChecky)
            If nodesCount > 0 Then
                Me.CheckAllChildNodes(node, roleId, addOrDel, nodeChecky)
                TreeClass.ExecSql(sqlCheckStr.ToString)
            Else
                TreeClass.ExecSql(sqlCheckStr.ToString)
            End If
            TreeClass.PubConnection.Close()
        Else
            sqlCheckStr.Append(" delete from [dbo].[m_RoleRight_t]  where Role_Id ='" & roleId & "' and TKey ='" & nodeName & "' ")
            sqlCheckStr.Append(Environment.NewLine)
            If nodesCount > 0 Then
                Me.CheckAllChildNodes(node, roleId, addOrDel, nodeChecky)
                TreeClass.ExecSql(sqlCheckStr.ToString)

            Else
                Dim curNodeParent As TreeNode = node.Parent
                Dim nodeChild As TreeNode
                Dim IsCheck As Boolean = False
                For Each nodeChild In curNodeParent.Nodes
                    If nodeChild.Checked = True Then
                        IsCheck = True
                        Exit For
                    End If
                Next
                curNodeParent.Checked = IsCheck
                If curNodeParent.Checked = False Then
                    sqlCheckStr.Append("  delete from [dbo].[m_RoleRight_t]  where Role_Id ='" & roleId & "' and TKey ='" & curNodeParent.Name & "'")
                    sqlCheckStr.Append(Environment.NewLine)
                End If
                TreeClass.ExecSql(sqlCheckStr.ToString)
            End If
            TreeClass.PubConnection.Close()
        End If
    End Sub
    ''' <summary>
    ''' 选中该节点时 若父节点未选中 选中并插入数据库表
    ''' </summary>
    ''' <param name="treeNode"></param>
    ''' <param name="roleId"></param>
    ''' <param name="nodeChecky"></param>
    ''' <remarks></remarks>
    Private Sub CheckAllParentNodes(ByVal treeNode As TreeNode, ByVal roleId As String, ByVal nodeChecky As Boolean)
        If (treeNode Is UserTree.Nodes(0)) Then Exit Sub

        If treeNode.Parent.Checked = False Then
            If nodeChecky Then
                treeNode.Parent.Checked = True
            End If
            sqlCheckStr.Append("  INSERT INTO [dbo].[m_RoleRight_t]  values('" & roleId & "','" & treeNode.Parent.Name & "','" & SysMessageClass.UseId.ToLower & "',GETDATE())  ")
            sqlCheckStr.Append(Environment.NewLine)
            treeNode = treeNode.Parent
            Me.CheckAllParentNodes(treeNode, roleId, nodeChecky)
        End If
    End Sub
    ''' <summary>
    ''' 选中时  选中所有子节点 取消时  取消所有子节点
    ''' </summary>
    ''' <param name="treeNode"></param>
    ''' <param name="roleId"></param>
    ''' <param name="nodeChecked"></param>
    ''' <param name="nodeChecky"></param>
    ''' <remarks></remarks>
    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal roleId As String, ByVal nodeChecked As Boolean, ByVal nodeChecky As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            If nodeChecky Then
                node.Checked = nodeChecked
            End If
            If nodeChecked Then
                sqlCheckStr.Append("  INSERT INTO [dbo].[m_RoleRight_t]  values('" & roleId & "','" & node.Name & "','" & SysMessageClass.UseId.ToLower & "',GETDATE())  ")
                sqlCheckStr.Append(Environment.NewLine)
            Else
                sqlCheckStr.Append(" delete from [dbo].[m_RoleRight_t]  where Role_Id ='" & roleId & "' and TKey ='" & node.Name & "'")
                sqlCheckStr.Append(Environment.NewLine)
            End If
            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, roleId, nodeChecked, nodeChecky)
            End If
        Next node
    End Sub
    ''' <summary>
    ''' 角色对应权限
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckTree()
        If Me.dgvRole.RowCount > 0 Then
            Dim sqlStr As String = "select Role_Id from m_Role_t   where [Role_Name]=N'" & Me.dgvRole.Item(0, Me.dgvRole.CurrentRow.Index).Value.ToString.Trim & "'"
            Dim roleId As String = TreeClass.GetDataTable(sqlStr).Rows(0)(0).ToString
            CheckData(roleId)
            'Me.UserTree.Focus()
            'Me.UserTree.SelectedNode = Me.UserTree.Nodes(0)
        Else
            ClearAllCheck(UserTree.Nodes(0))
        End If
    End Sub
    ''' <summary>
    ''' 角色的对应权限在treeview中进行勾选
    ''' </summary>
    ''' <param name="roleId"></param>
    ''' <remarks></remarks>
    Private Sub CheckData(ByVal roleId As String)
        Dim drCheck As SqlDataReader
        Try
            drCheck = TreeClass.GetDataReader(" select TKey from m_RoleRight_t where Role_Id ='" & roleId & "' order by tkey ")
            If drCheck.HasRows Then
                UserTree.Nodes(0).Checked = True
                ClearAllCheck(UserTree.Nodes(0))
                While drCheck.Read()
                    CheckSet(UserTree.Nodes(0), drCheck.GetString(0))
                End While
            Else
                UserTree.Nodes(0).Checked = False
                ClearAllCheck(UserTree.Nodes(0))
            End If
            TreeClass.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
        drCheck.Close()
    End Sub
    ''' <summary>
    ''' 清空TreeView所有节点
    ''' </summary>
    ''' <param name="userNode"></param>
    ''' <remarks></remarks>
    Private Sub ClearAllCheck(ByVal userNode As TreeNode)
        Dim node As TreeNode
        For Each node In userNode.Nodes
            node.Checked = False
            If node.Nodes.Count > 0 Then
                Me.ClearAllCheck(node)
            End If
        Next node
    End Sub
    ''' <summary>
    ''' 根据权限勾选treeview对应的节点
    ''' </summary>
    ''' <param name="userNode"></param>
    ''' <param name="nodeString"></param>
    ''' <remarks></remarks>
    Private Sub CheckSet(ByVal userNode As TreeNode, ByVal nodeString As String)
        Dim node As TreeNode
        For Each node In userNode.Nodes
            If node.Name = nodeString Then
                node.Checked = True
            End If

            If node.Nodes.Count > 0 Then
                Me.CheckSet(node, nodeString)
            End If
        Next node
    End Sub
#End Region

End Class