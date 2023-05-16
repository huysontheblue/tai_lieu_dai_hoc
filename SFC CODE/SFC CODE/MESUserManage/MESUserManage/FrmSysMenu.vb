Imports System.Reflection
Imports System.Resources
Imports System.IO
Imports MainFrame.SysCheckData

Public Class FrmSysMenu

    Public Tparent As String = Nothing '储存树父节点ID
    Public op As String = "None"
    Public FileNamePath As String

#Region "窗体加载事件"
    Private Sub FrmSysMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub
#End Region

#Region "窗体加载初始化数据"
    ''' <summary>
    ''' 窗体加载初始化数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Dim dtt As DataTable = New DataTable
        dtt = getAllMenu("and 1=1")
        tvMenu.Nodes.Clear()
        tvMenu.Enabled = True
        LoadMenuTree(dtt, tvMenu.Nodes, "0_")
        tvMenu.SelectedNode = tvMenu.Nodes(0)
        op = "None"
        Tparent = ""
    End Sub
#End Region

#Region "加载系统菜单"
    ''' <summary>
    ''' 加载系统菜单
    ''' </summary>
    ''' <param name="dt">系统菜单数据源</param>
    ''' <param name="treeNodeList">treeNode节点集合</param>
    ''' <param name="tParent">树状父节点</param>
    ''' <remarks></remarks>
    Private Sub LoadMenuTree(ByVal dt As DataTable, ByVal treeNodeList As TreeNodeCollection, ByVal tParent As String)
        Dim dr As DataRow
        For Each dr In dt.Select("tParent='" + tParent + "'")
            Dim tn As TreeNode = New TreeNode
            tn.Tag = dr("Tkey").ToString()
            tn.Text = dr("Tkey").ToString() + "-" + dr("Ttext").ToString()
            tn.ToolTipText = dr("Tparent").ToString()
            treeNodeList.Add(tn)

            If dt.Select("tParent='" + tn.Tag + "'").Length > 0 Then
                LoadMenuTree(dt, tn.Nodes, tn.Tag)
            End If
        Next
        If (tvMenu.Nodes.Count > 0) Then
            tvMenu.Nodes(0).Expand()
        End If

    End Sub
#End Region

#Region "系统菜单数据源"
    ''' <summary>
    ''' 系统菜单数据源
    ''' </summary>
    ''' <param name="strWhre">查询条件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getAllMenu(ByVal strWhre As String) As DataTable
        Dim dt As DataTable = New DataTable
        dt = MainFrame.DbOperateUtils.GetDataTable("SELECT * FROM m_Logtree_t WHERE Rightid='mes00' " + strWhre + " order by isnull(OrderBy,10000) ")
        Return dt
    End Function
#End Region

#Region "树节点选择事件"
    Private Sub tvMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvMenu.AfterSelect
        Dim TreeKey As String = e.Node.Tag.ToString()
        Dim dtt As DataTable = getAllMenu("and 1=1")
        InitTreeNode(dtt, TreeKey)
    End Sub
#End Region

#Region "加载选择树节点详细信息"
    ''' <summary>
    ''' 加载选择树节点详细信息
    ''' </summary>
    ''' <param name="dt">数据源</param>
    ''' <param name="TreeKey">菜单主键</param>
    ''' <remarks></remarks>
    Private Sub InitTreeNode(ByVal dt As DataTable, ByVal TreeKey As String)
        Dim dr As DataRow = dt.Select("Tkey='" + TreeKey + "'")(0)
        TxtMenuKey.Text = dr("Tkey").ToString()
        TxtMenuName.Text = dr("Ttext").ToString()
        txtEnname.Text = dr("Enname").ToString()
        cmbUsey.Text = dr("Usey").ToString()
        Tparent = dr("Tparent").ToString()
        TxtTreeTag.Text = dr("TreeTag").ToString()
        TxtOrderBy.Text = dr("OrderBy").ToString()
        txtFormID.Text = dr("FormId").ToString()
        txtButtonId.Text = dr("ButtonId").ToString()
        cmbolisty.Text = dr("listy").ToString()
        Dim drr As DataRow() = dt.Select("Tkey='" + Tparent + "'") '获取父菜单
        If drr.Length > 0 Then
            TxtParentName.Text = dt.Select("Tkey='" + Tparent + "'")(0)("Ttext")
        Else
            TxtParentName.Text = Nothing
        End If
        txtImageName.Text = dr("ImageName").ToString()
        Dim ImageObj = ""
        If String.IsNullOrEmpty(txtImageName.Text) = False Then
            ImageObj = txtImageName.Text.Substring(0, txtImageName.Text.IndexOf("."))

        End If
        chkboxIsMdiChildren.Checked = Convert.ToBoolean(dr("IsMdiChildren").ToString())
        If dr("ReportUsey").ToString() = "Y" Then
            chkReportUsey.Checked = True
        Else
            chkReportUsey.Checked = False
        End If

        Dim ay = Assembly.Load("MesSystem")
        Dim rm = New ResourceManager("MesSystem.Resources", ay)
        Dim obj = rm.GetObject(ImageObj)
        If Not obj Is Nothing Then
            picBoxImageName.Image = CType(obj, Image)
        Else
            picBoxImageName.Image = Nothing
        End If
        SetEnEdit(True)

        ''20180906增加，
        Me.TxtFieldId.Text = IIf(dr("FSourceFieldId") Is Nothing, "", dr("FSourceFieldId").ToString)
        Me.TxtFieldName.Text = IIf(dr("FSourceFieldName") Is Nothing, "", dr("FSourceFieldName").ToString)
        ''20191101增加 显示权限用户，
        UserName()
        'Dim dg As DataTable
        'Dim strSQL As String
        'strSQL = "SELECT a.UserID AS 工号 ,b.UserName AS 姓名 ,b.Dept AS 部门,b.Team AS 职务 " &
        '         " FROM dbo.m_UserRight_t a LEFT JOIN dbo.m_Users_t b " &
        '         " ON a.UserID=b.UserID WHERE Tkey = '" + TxtMenuKey.Text + "' AND b.Usey = '1' AND A.UserID='" + VbCommClass.VbCommClass.UseId + "'" &
        '         " UNION" &
        '         " SELECT a.UserID AS 工号 ,b.UserName AS 姓名 ,b.Dept AS 部门,b.Team AS 职务 " &
        '         " FROM dbo.m_UserRight_t a LEFT JOIN dbo.m_Users_t b " &
        '         " ON a.UserID=b.UserID WHERE Tkey = '" + TxtMenuKey.Text + "' AND b.Usey = '1' AND A.UserID<>'" + VbCommClass.VbCommClass.UseId + "'"
        'dg = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        'dgvuser.DataSource = dg
        'Label14.Text = String.Format("查询结果{0}笔", dgvuser.RowCount.ToString)
    End Sub
#End Region

#Region "树节点详细信息是否可编辑"
    ''' <summary>
    ''' 树节点详细信息是否可编辑
    ''' </summary>
    ''' <param name="IsReadOnly">是否只读</param>
    ''' <remarks></remarks>
    Private Sub SetEnEdit(ByVal IsReadOnly As Boolean)

        Dim yy As Boolean = False
        If IsReadOnly = True Then
            yy = False
        Else
            yy = True
        End If

        TxtMenuKey.ReadOnly = IsReadOnly
        TxtMenuName.ReadOnly = IsReadOnly
        txtEnname.ReadOnly = IsReadOnly
        cmbUsey.Enabled = yy
        BtnSelect.Enabled = yy
        BtnSelectImage.Enabled = yy
        btnUpload.Enabled = yy
        BtnSelectItem.Enabled = yy
        cmbolisty.Enabled = yy
        txtFormID.Enabled = yy
        txtButtonId.Enabled = yy
        TxtTreeTag.ReadOnly = IsReadOnly
        TxtOrderBy.ReadOnly = IsReadOnly
        'txtImageName.ReadOnly = IsReadOnly
        chkboxIsMdiChildren.Enabled = yy
    End Sub
#End Region

#Region "清空文本信息"
    ''' <summary>
    ''' 清空文本信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearTreeNode()
        TxtMenuKey.Text = Nothing
        TxtMenuName.Text = Nothing
        txtEnname.Text = Nothing
        TxtParentName.Text = Nothing
        TxtTreeTag.Text = Nothing
        TxtOrderBy.Text = Nothing
        Tparent = Nothing
        txtFormID.Text = Nothing
        txtButtonId.Text = Nothing
        txtImageName.Text = Nothing
        picBoxImageName.Image = Nothing
        chkboxIsMdiChildren.Checked = False

        ''20180906增加，
        Me.TxtFieldId.Text = ""
        Me.TxtFieldName.Text = ""
    End Sub
#End Region

#Region "新增事件"
    ''' <summary>
    ''' 新增事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        Try
            op = "Add"
            ClearTreeNode()
            SetEnEdit(False)
            NewFile.Enabled = False
            EditFile.Enabled = False
            Delete.Enabled = False
            Save.Enabled = True
            Back.Enabled = True
            FileRefresh.Enabled = False

            '20180910，添加
            If Not Me.tvMenu.SelectedNode Is Nothing Then
                '新增时，默认当前节点为父节点
                Dim sid As String = Me.tvMenu.SelectedNode.Tag.ToString.Trim()
                Dim stxt As String = Me.tvMenu.SelectedNode.Text.Trim()
                Me.Tparent = sid
                Me.TxtParentName.Text = stxt.Replace(sid + "-", "")

                '生成key值
                Me.TxtMenuKey.Text = GetSysMenuNewKey(sid)
                Me.TxtMenuName.Focus()
            End If
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message)
            Exit Sub
        End Try
    End Sub
#End Region

#Region "修改事件"
    ''' <summary>
    ''' 修改事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        op = "Edit"
        SetEnEdit(False)
        NewFile.Enabled = False
        EditFile.Enabled = False
        Delete.Enabled = False
        Save.Enabled = True
        Back.Enabled = True
        FileRefresh.Enabled = False
        TxtMenuKey.ReadOnly = True
    End Sub
#End Region

#Region "删除事件"
    ''' <summary>
    ''' 删除事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If MainFrame.SysCheckData.MessageUtils.ShowConfirm("确定要删除吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            Dim sql As String
            sql = "delete m_Logtree_t  " &
            "where Tkey='" + TxtMenuKey.Text + "'"
            MainFrame.DbOperateUtils.ExecSQL(sql)
            MainFrame.SysCheckData.MessageUtils.ShowInformation("删除成功!")
            ClearTreeNode()
            init()
            NewFile.Enabled = True
            EditFile.Enabled = True
            Delete.Enabled = True
            Save.Enabled = False
            Back.Enabled = False
            FileRefresh.Enabled = True
        End If
    End Sub
#End Region

#Region "保存事件"
    ''' <summary>
    ''' 保存事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Try
            Dim Tkey As String = TxtMenuKey.Text.Trim()
            Dim Treeid As String = Tkey
            Dim Ttext As String = TxtMenuName.Text.Trim()
            Dim Enname As String = txtEnname.Text.Trim()
            Dim TreeTag As String = TxtTreeTag.Text.Trim()
            Dim Rightid As String = "mes00"
            Dim listy As String = cmbolisty.Text
            Dim Usey As String = cmbUsey.Text
            Dim FormID As String = txtFormID.Text.Trim()
            Dim ButtonID As String = txtButtonId.Text.Trim()
            Dim OrderBy As String = TxtOrderBy.Text.Trim()
            Dim ImageName As String '上传图标保存路径
            If String.IsNullOrEmpty(Tparent) = True Then
                Tparent = "m0_"
            End If
            Dim ReportUsey As String = "N"
            If chkReportUsey.Checked Then
                ReportUsey = "Y"
            End If

            '菜单key不能为空 关晓艳 2019/1/28
            If String.IsNullOrEmpty(Tkey) OrElse String.IsNullOrEmpty(Ttext) Then
                MessageUtils.ShowInformation("菜单Key或菜单名称不能为空!")
                Return
            End If

            Dim sql As String = ""


            '图片复制到服务器 保存到配置数据库表 关晓艳 2019/1/28
            ImageName = txtImageName.Text.Trim()
            '2019-04-03 图片名称不为空，才检查
            If Not String.IsNullOrEmpty(ImageName) Then
                Dim strsql As String = String.Format("select 1 from  m_LogtreeImage_t where FImageName='{0}'", ImageName)
                If InStr(ImageName, "http") <= 0 Then
                    Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(strsql)
                    If dt.Rows.Count = 0 AndAlso ImageName <> "" AndAlso IsImage(ImageName) Then
                        MessageUtils.ShowInformation("不是图片文件或宽高不是32*32！")
                        Return
                    End If
                    If dt.Rows.Count = 0 AndAlso Dir(ImageName) = "" Then
                        'MessageUtils.ShowInformation("该图片路径不对或未存在于资源文件中！")
                        'Return
                    ElseIf (Not FileNamePath Is Nothing AndAlso FileNamePath <> "") OrElse Dir(ImageName) <> "" Then
                        FileNamePath = ImageName
                        Dim fileName As String = System.IO.Path.GetFileName(FileNamePath)
                        Dim newPath As String = "\\192.168.20.123\PrintFile2\SFC_Icon\" + fileName
                        If Dir(newPath) = "" Then
                            File.Copy(FileNamePath, newPath)
                        End If
                        ImageName = newPath
                    End If
                ElseIf IsURLImage(ImageName) Then
                    MessageUtils.ShowInformation("网络路径不是合法图片文件！")
                    Return
                End If
            End If

            If op = "Add" Then

                sql = "insert m_Logtree_t (Tkey,Treeid,Ttext,Tparent,Enname" &
                ",TreeTag,Rightid,listy,Usey,OrderBy,FormID,ButtonID,ImageName,IsMdiChildren,ReportUsey) values ('" + Tkey + "'" &
                ",'" + Treeid + "',N'" + Ttext + "','" + Tparent + "',N'" + Enname + "','" + TreeTag + "'" &
                ",'" + Rightid + "','" + listy + "','" + Usey + "','" + OrderBy + "','" + FormID + "','" + ButtonID + "','" & ImageName & "','" & chkboxIsMdiChildren.Checked & "','" & ReportUsey & "')"
            ElseIf op = "Edit" Then
                sql = "update m_Logtree_t set Ttext=N'" + Ttext + "',Enname=N'" + Enname + "',Tparent='" + Tparent + "'" &
                ",listy='" + listy + "',Usey='" + Usey + "',TreeTag='" + TreeTag + "',OrderBy='" + OrderBy + "'" &
                ",FormID='" + FormID + "',ButtonID='" + ButtonID + "',ImageName='" & ImageName & "',IsMdiChildren='" & chkboxIsMdiChildren.Checked & "',ReportUsey='" & ReportUsey & "' where Tkey='" + Tkey + "'"
            End If



            MainFrame.DbOperateUtils.ExecSQL(sql)
            FileNamePath = ""
            MainFrame.SysCheckData.MessageUtils.ShowInformation("提交成功!")
            'ClearTreeNode()
            'init()
            SetEnEdit(True)
            NewFile.Enabled = True
            EditFile.Enabled = True
            Delete.Enabled = True
            Save.Enabled = False
            Back.Enabled = False
            FileRefresh.Enabled = True

            '20180906增加，保存来源字段值的ID和名称(例如，部门ID，部门名称)
            SaveSourceField(Tkey, Me.TxtFieldId.Text.Trim, Me.TxtFieldName.Text.Trim)

            '20181029增加， 
            '保存菜单节点时, m_Logtree_t表之外的, 其它信息的保存
            '保存其它的数据（例如：以“apm”开头的FormId写入M_SYSAPFORM_T）等等
            SaveOther(Tkey)
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 20181029增加， 
    ''' 保存菜单节点时，m_Logtree_t表之外的，其它信息的保存
    ''' 说明：保存其它的数据（例如：以“apm”开头的FormId写入M_SYSAPFORM_T）等等
    ''' </summary>
    ''' <param name="Tkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveOther(ByVal Tkey As String) As String
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection()
        Try
            cn.ConnectionString = sConn.GetConnectionString
            cn.Open()
            Dim cm As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("Exec_ZSaveFrmSysMenuInfo", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.Add("@FKey", SqlDbType.VarChar, 50).Value = Tkey
            cm.Parameters.Add("@FUser", SqlDbType.VarChar, 50).Value = VbCommClass.VbCommClass.UseId
            cm.Parameters.Add("@RTVALUE", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
            cm.Parameters.Add("@RTMSG", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()

            Dim resultV As String = ""
            Dim resultMsg As String = ""
            If Not cm.Parameters("@RTVALUE").Value Is Nothing Then
                resultV = cm.Parameters("@RTVALUE").Value.ToString()
            End If
            If Not cm.Parameters("@RTMSG").Value Is Nothing Then
                resultMsg = cm.Parameters("@RTMSG").Value.ToString()
            End If
            Return resultMsg
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return ""
        Finally
            If Not cn Is Nothing Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                    cn.Dispose()
                End If
                sConn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "刷新事件"
    ''' <summary>
    ''' 刷新事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles FileRefresh.Click
        init()
    End Sub
#End Region

#Region "选择父级菜单"
    ''' <summary>
    ''' 选择父级菜单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        '=====20180830，Yuanfeng.Yu，新建树状选择窗口=====================
        '并将当前父节点Tkey值传过去()
        Dim FrmOjb As Form = New FrmSelectMenuTree(Me.Tparent)

        'Dim FrmOjb As Form = New FrmSelectMenu
        FrmOjb.Owner = Me
        FrmOjb.ShowDialog()
    End Sub
#End Region

#Region "返回事件"
    ''' <summary>
    ''' 返回事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        op = "None"
        NewFile.Enabled = True
        EditFile.Enabled = True
        Delete.Enabled = True
        Save.Enabled = False
        Back.Enabled = False
        FileRefresh.Enabled = True
        Dim TreeKey As String = tvMenu.SelectedNode.Tag.ToString()
        Dim dtt As DataTable = getAllMenu("and 1=1")
        InitTreeNode(dtt, TreeKey)
    End Sub
#End Region

#Region "退出事件"
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "选择菜单图标"

    ''' <summary>
    ''' 选择菜单图标事件
    ''' 20180831，Yuanfeng.Yu，新建菜单图标选择窗口
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectImage_Click(sender As Object, e As EventArgs) Handles BtnSelectImage.Click
        '如果当前菜单有图标，传过去
        Dim FrmOjb As Form = New FrmSelectMenuImage(Me.txtImageName.Text.Trim)
        FrmOjb.Owner = Me
        FrmOjb.ShowDialog()

        '选择本地路径清空  关晓艳 2018/1/28
        FileNamePath = ""
    End Sub

#End Region

#Region "选择客户/部门/权限"

    ''' <summary>
    ''' 获取新生成的菜单KEY值
    ''' </summary>
    ''' <param name="PMenuKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSysMenuNewKey(ByVal PMenuKey As String) As String
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection()
        Try
            cn.ConnectionString = sConn.GetConnectionString
            cn.Open()
            Dim cm As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("Pro_GetSysMenuNewKey", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.Add("@PMenuKey", SqlDbType.VarChar, 50).Value = PMenuKey
            cm.Parameters.Add("@DocNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()

            Dim result As String = ""
            If Not cm.Parameters("@DocNo").Value Is Nothing Then
                result = cm.Parameters("@DocNo").Value.ToString()
            End If
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return ""
        Finally
            If Not cn Is Nothing Then
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                    cn.Dispose()
                End If
                sConn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 保存来源的字段值
    ''' 因原菜单的相关内容与基础表内容填写不严谨，需要增加字段保存来源值，用于值比较
    ''' </summary>
    ''' <param name="tkey"></param>
    ''' <param name="fieldId">ID</param>
    ''' <param name="fieldName">名称</param>
    ''' <remarks></remarks>
    Private Sub SaveSourceField(ByVal tkey As String, ByVal fieldId As String, ByVal fieldName As String)
        Try
            If String.IsNullOrEmpty(tkey) = True Or String.IsNullOrEmpty(fieldId) = True Then
                Exit Sub
            End If

            Dim sql As String = ""
            sql = " UPDATE [m_Logtree_t] " &
                     " SET [FSourceFieldId] = '" + fieldId + "' " &
                        " ,[FSourceFieldName] = N'" + fieldName + "' " &
                " WHERE 1 = 1 " &
                      " AND [Tkey] = N'" + tkey + "' "

            MainFrame.DbOperateUtils.ExecSQL(sql)
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError(ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 父节点栏位，文本变化时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtParentName_TextChanged(sender As Object, e As EventArgs) Handles TxtParentName.TextChanged
        Try
            Dim sname As String = Me.TxtParentName.Text.Trim()
            Dim isShow As Boolean = False
            If sname.Contains("客戶權限") Or sname.Contains("工廠權限") Or sname.Contains("部門權限") Or sname.Contains("線別權限") Then
                isShow = True
            End If

            '利润中心，工厂权限的子级
            '判断如果父节点的名称在工厂表中存在，则可选择利润中心
            If String.IsNullOrEmpty(Me.Tparent) = False Then
                Dim sql As String = ""
                sname = Me.TxtParentName.Text.Trim()
                sql = "SELECT 1 as rows FROM m_Dcompany_t WHERE Shortname=N'" & sname & "' OR Fullname=N'" & sname & "' AND Usey='Y' "
                If MainFrame.DbOperateUtils.GetRowsCount(sql) > 0 Then
                    '利润中心
                    isShow = True
                End If
            End If

            If isShow = True Then
                Me.TxtMenuName.Width = Me.TxtParentName.Width
                Me.BtnSelectItem.Left = Me.BtnSelect.Left
                Me.BtnSelectItem.Visible = True
            Else
                Me.TxtMenuName.Width = Me.TxtMenuKey.Width
                Me.BtnSelectItem.Visible = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 选择节点名称
    ''' 范围：工厂，部门，利润中心，产线
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectItem_Click(sender As Object, e As EventArgs) Handles BtnSelectItem.Click
        Try
            Dim frm As Form
            Dim fieldId As String = Me.TxtFieldId.Text.Trim()
            Dim fieldName As String = Me.TxtFieldName.Text.Trim()
            Dim tkey As String = Me.TxtMenuKey.Text.Trim()
            Dim ttext As String = Me.TxtMenuName.Text.Trim()

            'A、弹出客户选择窗口
            If Me.TxtParentName.Text.Trim = "客戶權限" Then
                frm = New FrmSelectMenuCustomer(Me.TxtMenuKey.Text.Trim, Me.TxtMenuName.Text.Trim)
            End If

            'B、弹出组织权限选择窗口
            '1，工厂
            '2，工厂/利润中心
            '3，工厂/部门
            '4，工厂/部门/产线
            If Me.TxtParentName.Text.Trim.Contains("工廠權限") Then
                frm = New FrmSelectMenuOrg(1, fieldId, fieldName)
            ElseIf Me.TxtParentName.Text.Trim.Contains("部門權限") Then
                frm = New FrmSelectMenuOrg(3, fieldId, fieldName)
            ElseIf Me.TxtParentName.Text.Trim.Contains("線別權限") Then
                frm = New FrmSelectMenuOrg(4, fieldId, fieldName)
            End If

            'C、利润中心，工厂权限的子级
            '   判断如果父节点的名称在工厂表中存在，则可选择利润中心
            If frm Is Nothing Then
                If String.IsNullOrEmpty(Me.Tparent) = False Then
                    Dim sql As String = ""
                    Dim sName As String = Me.TxtParentName.Text.Trim()
                    sql = "SELECT 1 as rows FROM m_Dcompany_t WHERE Shortname=N'" & sName & "' OR Fullname=N'" & sName & "' AND Usey='Y' "
                    If MainFrame.DbOperateUtils.GetRowsCount(sql) > 0 Then
                        '利润中心
                        frm = New FrmSelectMenuOrg(2, fieldId, fieldName)
                    End If
                End If
            End If

            If Not frm Is Nothing Then
                frm.Owner = Me
                frm.ShowDialog()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub



#End Region

#Region "上传网络图片"
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Title = "请选择要上传的图标"
        ofd.Filter = "Files(*.png,*.jpg)|*.png;*.jpg;*.jpeg;*.bmp;*.gif"

        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFileName(ofd.FileName)
            'Dim strSql As String = String.Format(" select 1 from m_LogtreeImage_t where FImageName='{0}'", fileName)
            'Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(strSql)
            'If Dir("\\192.168.20.123\PrintFile2\SFC_Icon\" + fileName) <> "" OrElse dt.Rows.Count > 0 Then
            '    MessageBox.Show("该图标名称已存在，请重新选择！")
            '    txtImageName.Text = ""
            '    picBoxImageName.Image = Nothing
            '    Return
            'End If
            If Dir("\\192.168.20.123\PrintFile2\SFC_Icon\" + fileName) <> "" Then
                txtImageName.Text = "\\192.168.20.123\PrintFile2\SFC_Icon\" + fileName
                picBoxImageName.Image = Image.FromFile(ofd.FileName)
                If MessageUtils.ShowConfirm("该图标名称已存在，请确认！", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then
                    txtImageName.Text = ""
                    picBoxImageName.Image = Nothing
                    Return
                End If
            End If

            If Dir(ofd.FileName) = "" Then
                MessageUtils.ShowInformation("上传图标不存在！")
                Return
            End If


            '上传图片大小
            Dim bmp As Bitmap = New Bitmap(ofd.FileName)
            Dim height As Integer = bmp.Height  '高
            Dim width As String = bmp.Width  '宽
            If height <> 32 OrElse width <> 32 Then
                MessageUtils.ShowInformation("图片宽高不符合比例，请检查！")
                Return
            End If

            FileNamePath = ofd.FileName
            picBoxImageName.Image = Image.FromFile(ofd.FileName)
            txtImageName.Text = ofd.FileName
        End If
    End Sub

    '
    '上传网络图片 关晓艳 2019/1/29
    ''' <summary>
    ''' 判断文件是否为图片
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Function IsImage(ByVal path As String)
        Try
            Dim img As Image = Image.FromFile(path)
            Dim height As Integer = img.Height  '高
            Dim width As String = img.Width  '宽
            If height <> 32 OrElse width <> 32 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    ''' <summary>
    ''' 判断文件是否为网络图片
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Function IsURLImage(ByVal path As String)
        Try
            Dim web As System.Net.WebClient = New System.Net.WebClient()
            Dim buffer() As Byte = web.DownloadData(path)
            web.Dispose()
            Dim streama As System.IO.MemoryStream = New System.IO.MemoryStream(buffer)
            Dim img As Image = Image.FromStream(streama)
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
#End Region
#Region "加载权限事件"
    Private Sub UserName()
        Dim dg As DataTable
        Dim strSQL As String
        strSQL = "SELECT a.UserID AS 工号 ,b.UserName AS 姓名  ,b.Team AS 部门名称,b.Jobs AS 职务" &
                 " FROM dbo.m_UserRight_t a LEFT JOIN dbo.m_Users_t b " &
                 " ON a.UserID=b.UserID WHERE Tkey = '" + TxtMenuKey.Text + "' AND b.Usey = '1' AND A.UserID='" + VbCommClass.VbCommClass.UseId + "'" &
                 " UNION" &
                 " SELECT a.UserID AS 工号 ,b.UserName AS 姓名 ,b.Team AS 部门名称,b.Jobs AS 职务 " &
                 " FROM dbo.m_UserRight_t a LEFT JOIN dbo.m_Users_t b " &
                 " ON a.UserID=b.UserID WHERE Tkey = '" + TxtMenuKey.Text + "' AND b.Usey = '1' AND A.UserID<>'" + VbCommClass.VbCommClass.UseId + "'"
        dg = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        dgvuser.DataSource = dg
        Label14.Text = String.Format("查询结果{0}笔", dgvuser.RowCount.ToString)
    End Sub
#End Region
#Region "移除权限"
    Private Sub tsmi_MaintenanceType_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceType.Click
        Dim UserID As String
        Dim Tkey As String
        Dim dv As DataTable
        Dim sSQL As String
        If dgvuser.RowCount < 1 OrElse dgvuser.CurrentRow Is Nothing Then Exit Sub
        UserID = dgvuser.Rows(dgvuser.CurrentRow.Index).Cells(0).Value.ToString()
        Tkey = TxtMenuKey.Text.Trim
        sSQL = "DELETE m_UserRight_t WHERE UserID = '" + UserID + "' AND Tkey = '" + Tkey + "'"
        dv = MainFrame.DbOperateUtils.GetDataTable(sSQL)
        UserName()
    End Sub
#End Region
End Class
