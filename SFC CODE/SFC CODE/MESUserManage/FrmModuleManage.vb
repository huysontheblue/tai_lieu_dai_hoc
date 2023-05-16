Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Data
Imports System.Data.SqlClient
Imports System.Resources
Imports System.IO

Public Class FrmModuleManage

    Dim TreeClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Public con As New SysDataBaseClass
    Public FsFile(0) As FileStream
    Public Parmter As SqlClient.SqlParameter() = New SqlClient.SqlParameter(2) {}
    Dim DataStatus As String = ""
    Dim SelectNode As TreeNode = Nothing

    Public Hwnd As Int32
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        DataStatus = "A"
        SetTextStatus(3)
    End Sub

#Region "装载模块树"
    '装载模块树
    Private Sub Treeload(ByVal treeview As TreeView)

        Dim UserTreeDt As DataTable
        'Me.ModuleTree.Nodes.Clear()
        treeview.Nodes.Clear()
        'Dim systemTreeDt As DataTable

        Try
            If treeview.Name = "ModuleTree" Then
                UserTreeDt = TreeClass.GetDataTable("select * from m_LogTree_t where rightid='mes00' order by treeid")
            Else
                UserTreeDt = TreeClass.GetDataTable("select a.* from m_LogTree_t a inner join m_logtree_img_t b on a.Tkey=b.Tkey and a.rightid='mes00' order by a.treeid")
            End If
            TreeClass.PubConnection.Close()
            'CreateTree(ModuleTree, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            CreateTree(treeview, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            UserTreeDt = Nothing

        Catch ex As Exception
            Throw ex
        End Try

        'Me.ModuleTree.Nodes(0).Expand()
        If Not treeview Is Nothing Then
            If treeview.Nodes.Count > 0 Then
                treeview.Nodes(0).Expand()
            End If
        End If

        '' TreeViewShow.ExpandAll()
        'Me.SysTree.ExpandAll()

    End Sub
#End Region

#Region "创建树"

    '创建树
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
                        '睰竊翴

                        'Select Case LagStr
                        '    Case "big5"
                        Node.Text = tempRow("Ttext").ToString()

                        '    Case "english"
                        'Node.Text = tempRow("Enname").ToString()

                        'End Select
                        treeview.Nodes.Add(Node)
                        Node.ImageIndex = 0
                        Node.SelectedImageIndex = 0
                        Node.Name = tempRow("tkey").ToString()
                        Node.Tag = tempRow("TreeTag").ToString()
                    Else
                        '睰讽玡竊翴竊翴

                        'Select Case LagStr
                        '    Case "big5"
                        Node.Text = tempRow("Ttext").ToString()
                        '    Case "english"
                        'Node.Text = tempRow("Enname").ToString()
                        'End Select
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
                    MessageBox.Show(err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
        End If

    End Sub

#End Region

    Private Sub FrmModuleManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '获取主窗口句柄
        Hwnd = Int32.Parse(Me.Text.Substring(Me.Text.IndexOf(":") + 1, Me.Text.Length - Me.Text.IndexOf(":") - 1))
        Me.Text = Me.Text.Substring(0, Me.Text.IndexOf(":"))

        Treeload(Me.ModuleTree)
        SetTextStatus(1)
    End Sub

    'add by song
    '2015-04-01
    '获取ButtonId
    Public Function GetButtonId(ByVal Tkey As String) As String
        Try
            Dim dt As New DataTable
            Dim str As String = ""
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass

            dt = ExeCute.GetDataTable("select ButtonId from m_LogTree_t where Tkey='" & Tkey & "'")
            If dt.Rows.Count > 0 Then
                str = dt.Rows(0)(0).ToString.Trim()
            End If
            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'add by song
    '2016-01-13
    '设置文本框状态（1：浏览，2：修改，3：新增, 4:返回）
    Private Sub SetTextStatus(ByVal status As Integer)
        Dim tn As New TreeNode()
        tn = Me.ModuleTree.SelectedNode

        Clear_Text()

        TextBox_Parent_Id.Enabled = False
        TextBox_Parent_Name.Enabled = False
        TextBox_Id.Enabled = False
        TextBox_Frm_Name.Enabled = False
        TextBox_Module_Name.Enabled = False
        TextBox_ButtonId.Enabled = False

        NewFile.Enabled = True
        EditFile.Enabled = True
        Save.Enabled = False
        Delete.Enabled = False
        DataRefresh.Enabled = True
        Back.Enabled = False

        If tn Is Nothing Then
            Exit Sub
        ElseIf tn.Parent Is Nothing Then
            'Exit Sub
        End If

        TextBox_Id.Text = tn.Name
        TextBox_Frm_Name.Text = tn.Tag
        TextBox_Module_Name.Text = tn.Text
        TextBox_ButtonId.Text = GetButtonId(tn.Name)


        'modify by song
        '2016-03-04
        'If Not tn.Parent Is Nothing Then
        '    TextBox_Parent_Id.Text = tn.Name
        '    TextBox_Parent_Name.Text = tn.Text
        'End If
        If status = 1 Or status = 2 Then
            If tn.Parent Is Nothing Then
                TextBox_Parent_Id.Text = Nothing
                TextBox_Parent_Name.Text = Nothing
            Else
                TextBox_Parent_Id.Text = tn.Parent.Name
                TextBox_Parent_Name.Text = tn.Parent.Text
            End If
        ElseIf status = 3 Then
            TextBox_Parent_Id.Text = tn.Name
            TextBox_Parent_Name.Text = tn.Text
        End If

        Select Case status
            Case 1
                TextBox_Parent_Id.Enabled = False
                TextBox_Parent_Name.Enabled = False
                TextBox_Id.Enabled = False
                TextBox_Frm_Name.Enabled = False
                TextBox_Module_Name.Enabled = False
                TextBox_ButtonId.Enabled = False

                NewFile.Enabled = True
                EditFile.Enabled = True
                Save.Enabled = False
                Delete.Enabled = True
                DataRefresh.Enabled = True
                Back.Enabled = False

                GroupBox_Ico.Enabled = False
            Case 2
                TextBox_Parent_Id.Enabled = False
                TextBox_Parent_Name.Enabled = False
                TextBox_Id.Enabled = False
                TextBox_Frm_Name.Enabled = True
                TextBox_Module_Name.Enabled = True
                TextBox_ButtonId.Enabled = True
                TextBox_Module_Name.Focus()

                NewFile.Enabled = False
                EditFile.Enabled = False
                Save.Enabled = True
                Delete.Enabled = False
                DataRefresh.Enabled = False
                Back.Enabled = True

                GroupBox_Ico.Enabled = True

                If TextBox_Frm_Name.Text <> "" Then
                    GroupBox_Ico.Visible = True
                Else
                    GroupBox_Ico.Visible = False
                End If
            Case 3
                TextBox_Parent_Id.Enabled = False
                TextBox_Parent_Name.Enabled = False
                TextBox_Id.Enabled = False
                TextBox_Frm_Name.Enabled = True
                TextBox_Module_Name.Enabled = True
                TextBox_ButtonId.Enabled = True

                TextBox_Id.Text = Gen_Module_Id(TextBox_Parent_Id.Text.Trim())
                TextBox_Frm_Name.Text = ""
                TextBox_Module_Name.Text = ""
                Back.Enabled = True

                NewFile.Enabled = False
                EditFile.Enabled = False
                Save.Enabled = True
                Delete.Enabled = False
                DataRefresh.Enabled = False

                TextBox_Module_Name.Focus()

                GroupBox_Ico.Enabled = True
            Case 4
                TextBox_Parent_Id.Enabled = False
                TextBox_Parent_Name.Enabled = False
                TextBox_Id.Enabled = False
                TextBox_Frm_Name.Enabled = False
                TextBox_Module_Name.Enabled = False
                TextBox_ButtonId.Enabled = False

                NewFile.Enabled = True
                EditFile.Enabled = True
                Save.Enabled = False
                Delete.Enabled = False
                DataRefresh.Enabled = True
                Back.Enabled = False

                GroupBox_Ico.Enabled = False
        End Select
    End Sub

    'add by song
    '2015-01-14
    '新增模块数据
    Public Sub Add_Module()
        Try
            Dim SqlStr As String
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass
            SqlStr = "insert into m_LogTree_t(Treeid,Tkey,Tparent,Ttext,TreeTag,Rightid,ButtonId) values" & " ('" & TextBox_Id.Text.Trim() & "','" & TextBox_Id.Text.Trim() & "','" & TextBox_Parent_Id.Text.Trim() & "','" & Microsoft.VisualBasic.Strings.StrConv(TextBox_Module_Name.Text.Trim(), Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0) & "','" & TextBox_Frm_Name.Text.Trim() & "','mes00','" & TextBox_ButtonId.Text.Trim() & "')"
            ExeCute.ExecSql(SqlStr)
            If TextBox_Frm_Name.Text.Trim() <> "" Then
                SqlStr = "insert into m_LogTree_img_t(Tkey) values" & " ('" & TextBox_Id.Text.Trim() & "')"
                ExeCute.ExecSql(SqlStr)
                Save_Img_Data(TextBox_Id.Text.Trim(), TextBox_Frm_Name.Text.Trim(), TextBox_Img.Text.Trim())
            End If
            ExeCute = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2015-01-14
    '删除模块数据
    Public Sub Del_Module()
        Try
            Dim SqlStr As String
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass
            SqlStr = "delete from m_LogTree_t where Tkey=" & "'" & TextBox_Id.Text.Trim() & "'"
            ExeCute.ExecSql(SqlStr)
            SqlStr = "delete from m_LogTree_img_t where Tkey=" & "'" & TextBox_Id.Text.Trim() & "'"
            ExeCute.ExecSql(SqlStr)
            ExeCute = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2015-01-14
    '修改模块数据
    Public Sub Mdf_Module()
        Try
            Dim SqlStr As String
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass

            SqlStr = "update m_LogTree_t set Ttext=" & "'" & Microsoft.VisualBasic.Strings.StrConv(TextBox_Module_Name.Text.Trim(), Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0) & "'" & ",TreeTag=" & "'" & TextBox_Frm_Name.Text.Trim() & "'" & " from m_Logtree_t where Tkey =" & "'" & TextBox_Id.Text.Trim() & "'"
            ExeCute.ExecSql(SqlStr)
            If TextBox_Frm_Name.Text.Trim() <> "" And Check_Img_Exists(TextBox_Id.Text.Trim()) = False Then
                SqlStr = "insert into m_LogTree_img_t(Tkey) values" & " ('" & TextBox_Id.Text.Trim() & "')"
                ExeCute.ExecSql(SqlStr)
                Save_Img_Data(TextBox_Id.Text.Trim(), TextBox_Frm_Name.Text.Trim(), TextBox_Img.Text.Trim())
            ElseIf TextBox_Frm_Name.Text.Trim() <> "" Then
                Save_Img_Data(TextBox_Id.Text.Trim(), TextBox_Frm_Name.Text.Trim(), TextBox_Img.Text.Trim())
            End If
            ExeCute = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2015-01-19
    '清空文本框内容
    Public Sub Clear_Text()
        TextBox_Parent_Id.Clear()
        TextBox_Parent_Name.Clear()
        TextBox_Id.Clear()
        TextBox_Frm_Name.Clear()
        TextBox_Module_Name.Clear()

        TextBox_Img.Clear()
    End Sub

    'add by song
    '2015-01-19
    '判断Img表是否存该数据
    Public Function Check_Img_Exists(ByVal Tkey As String) As Boolean
        Try
            Dim Rows As Integer = 0
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass

            Rows = ExeCute.GetRowsCount("select Tkey from m_LogTree_img_t where Tkey='" & TextBox_Id.Text.Trim() & "'")
            If Rows > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            Throw ex
        End Try
    End Function

    'add by song
    '2015-01-15
    '生成模块编号
    Public Function Gen_Module_Id(ByVal Parent_Id As String) As String
        Try
            Dim SqlStr As String
            Dim RecTable As SqlDataReader
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim Id As String = ""
            Dim i As Integer = 1

            'RecTable = ExeCute.GetDataReader("select convert(int,right(convert(varchar,isnull(convert(int,substring(max(Tkey),charindex('_',max(Tkey))+len('_'),10)),0)+1),2)) from m_Logtree_t where Tparent='" & TextBox_Parent_Id.Text.Trim() & "' and len(substring(Tkey,charindex('_',Tkey)+len('_'),10))=len(Tkey)-charindex('_',Tkey)")
            RecTable = ExeCute.GetDataReader("select isnull(max(right(Tkey,2)),1)+1 from m_Logtree_t where Tparent='" & TextBox_Parent_Id.Text.Trim() & "' and len(substring(Tkey,charindex('_',Tkey)+len('_'),10))=len(Tkey)-charindex('_',Tkey) and right(Tkey,1)<>'_'")
            If RecTable.HasRows Then
                RecTable.Read()
                i = RecTable.GetValue(0)
                If i < 10 Then
                    Id = Parent_Id + "0" + i.ToString()
                Else
                    Id = Parent_Id + i.ToString()
                End If
            Else
                Id = Parent_Id + "01"
            End If
            Return Id
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'add by song
    '2015-01-19
    '存储数据到模块图片表
    Public Function Save_Img_Data(ByVal key As String, ByVal frm As String, ByVal img1 As String) As Boolean
        Try

            Dim img As Image = Image.FromFile(img1) '从文件读取图片
            '保存为字节流byte()
            Dim ms As New MemoryStream
            img.Save(ms, img.RawFormat)
            Dim Data(ms.Length) As Byte

            ms.Seek(0, SeekOrigin.Begin)
            ms.Read(Data, 0, ms.Length)
            ms.Close()
            Parmter(0) = New SqlClient.SqlParameter("@File", Data)
            Parmter(1) = New SqlClient.SqlParameter("@Tkey", key)
            Parmter(2) = New SqlClient.SqlParameter("@Frm", frm)

            con.ExecSqlAddParameter("update m_Logtree_img_t set Img= @File,MName= @Frm where Tkey=@Tkey", Parmter)
            con.PubConnection.Close()
            Return True
        Catch ex As Exception
            con.PubConnection.Close()
            Return False
            Throw ex
        End Try
    End Function

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        If Not Me.ModuleTree.SelectedNode Is Nothing Then
            DataStatus = "M"
            SetTextStatus(2)
        End If
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If TextBox_Id.Text.Trim().Length > 10 Then
            MessageBox.Show("模块编号长度不能超过10位！")
            Exit Sub
        End If
        If DataStatus = "A" Then
            Add_Module()
            Treeload(Me.ModuleTree)
            SetTextStatus(1)
            '发送消息刷新主窗口
            SendMessage(Hwnd, &HF, 100, 100)
        ElseIf DataStatus = "M" Then
            Mdf_Module()
            Treeload(Me.ModuleTree)
            SetTextStatus(1)
            '发送消息刷新主窗口
            SendMessage(Hwnd, &HF, 100, 100)
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            If Me.ModuleTree.SelectedNode Is Nothing Then
                Exit Sub
            ElseIf Me.ModuleTree.SelectedNode.Nodes.Count > 0 Then
                MessageBox.Show("该模块还有子模块，只有没有子模块的模块才允许删除！")
                Exit Sub
            End If

            If (MessageBox.Show("你确定删除？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) Then
                Del_Module()
                Treeload(Me.ModuleTree)
                SetTextStatus(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs)
        SetTextStatus(1)
    End Sub

    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles DataRefresh.Click
        Treeload(Me.ModuleTree)
        SetTextStatus(1)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox_Img.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub ModuleTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ModuleTree.AfterSelect
        SelectNode = Me.ModuleTree.SelectedNode
        SetTextStatus(1)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Clear_Text()
        Treeload(ModuleTree)
    End Sub

    Private Sub TextBox_Frm_Name_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Frm_Name.TextChanged
        If TextBox_Frm_Name.Text.Trim().Length > 0 Then
            GroupBox_Ico.Visible = True
        Else
            GroupBox_Ico.Visible = False
        End If
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        SetTextStatus(4)
    End Sub
End Class