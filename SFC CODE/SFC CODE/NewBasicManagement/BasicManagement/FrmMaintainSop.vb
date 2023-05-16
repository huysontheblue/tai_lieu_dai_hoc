Imports MainFrame
Imports MainFrame.SysDataHandle
Imports DevComponents.WinForms
Imports System.IO
Imports DevComponents.AdvTree
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmMaintainSop

    Dim conn As New SysDataHandle.SysDataBaseClass   '定义连接数据库
    Public opFlag As Int16 = 0  '判断是新增还是修改
    Private colStr As System.Collections.Specialized.StringCollection = New System.Collections.Specialized.StringCollection()   '打开新文件夹时会用到后退，用此字符串记录下前一个文件夹路径，用于后退到前一个文件夹

    Private Sub FrmMaintainSop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdvTree1.Nodes.Clear()
        Dim dt As DataTable = conn.GetDataTable("select * from m_MainSop where Usey ='Y'")
        Bind_Tv(dt, AdvTree1.Nodes, "h0_", "Tkey", "Tparent", "Ttext", True, False)
        If AdvTree1.Nodes.Count > 0 Then
            AdvTree1.SelectedIndex = 0
            AdvTree1_Click(Nothing, Nothing)
        End If
        Me.AdvTree1.Nodes(0).Expand()
        '加载根节点，不可改变
        comFirst.Text = AdvTree1.Nodes(0).Text
        '从数据库获取填充二级菜单
        Dim secondSql As String = "select Ttext from m_MainSop where Tparent ='h0_'"
        LoadDataToCob(secondSql, comSecond)
        BtnMaintainState(opFlag)
    End Sub
    '加载数据库信息到COmbox中
    Private Sub LoadDataToCob(ByVal strSql As String, ByVal cobName As ComboBox)
        Dim dt As DataTable = conn.GetDataTable(strSql)
        cobName.Items.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            cobName.Items.Add(dt.Rows(index)(0).ToString)
        Next
    End Sub
    '当二级菜单改变时加载出对应的三级菜单
    Private Sub comSecond_TextChanged(sender As Object, e As EventArgs) Handles comSecond.TextChanged
        Dim thirdSql As String = "select Ttext from m_MainSop where Usey='Y' and " _
                                & "Tparent = (select Tkey from m_MainSop where Ttext =N'" & comSecond.Text.Trim & "')"
        LoadDataToCob(thirdSql, comThree)
    End Sub

    '设置按钮状态
    Private Sub BtnMaintainState(ByVal flag As Int16)
        Select Case flag
            Case 0  '初始查询状态
                Me.btnAddMaintain.Enabled = IIf(Me.btnAddMaintain.Tag.ToString <> "Yes", False, True)
                'Me.btnMaintainEdit.Enabled = IIf(Me.btnMaintainEdit.Tag.ToString <> "Yes", False, True)
                Me.btnMaintainAban.Enabled = IIf(Me.btnMaintainAban.Tag.ToString <> "Yes", False, True)
                Me.btnMaintainBack.Enabled = False '返回
                Me.btnMaintainSave.Enabled = False '保存
            Case 1, 2
                Me.btnAddMaintain.Enabled = False   '新增
                ' Me.btnMaintainEdit.Enabled = False  '修改
                Me.btnMaintainAban.Enabled = False  '作废
                Me.btnMaintainBack.Enabled = True
                Me.btnMaintainSave.Enabled = True
        End Select
    End Sub

    '绑定数据库成树
    Private Sub Bind_Tv(dt As DataTable, ByVal tnc As DevComponents.AdvTree.NodeCollection, ByVal pid_val As String, ByVal id As String, ByVal pid As String, ByVal text As String, ByVal isFirst As Boolean, ByVal isMultiple As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据
        Dim tn As DevComponents.AdvTree.Node '建立AdvTree的节点（AdvTRee.Node），以便将取出的数据添加到节点中 As AdvTRee.Node
        '以下为if判断，如果父id为空,则为构建“父id字段 is null”的查询条件，否则构建"父id字段=父id字段值"的查询条件
        Dim filter As String = ""
        If isFirst Then
            If String.IsNullOrEmpty(pid_val) Then
                filter = "Tkey is null or Tkey =''"
            Else
                filter = String.Format("Tkey='{0}'", pid_val)
            End If
        Else
            If String.IsNullOrEmpty(pid_val) Then
                filter = pid + " is null or " + pid + " ='' "
            Else
                filter = String.Format("(" + pid + "='{0}') ", pid_val)
            End If
        End If
        dv.RowFilter = filter '利用DataView将数据进行筛选，晒出相同 父id值 的数据
        Dim drv As DataRowView
        For Each drv In dv
            tn = New DevComponents.AdvTree.Node() '建立一个新结点（学名叫：一个实例）
            tn.Name = drv(id).ToString()  '结点的Value值，一般为数据库的id值
            tn.Text = drv(text).ToString()  '结点的Text，结点的文本表示

            If isMultiple Then
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(id).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(pid).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("Enname").ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("TreeTag").ToString()))
            End If
            'tn.Expanded = True
            tnc.Add(tn)   '将该节点加入到AdvTreeNodeCollection（结点集合）中
            Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text, False, isMultiple) '递归（反复调用这个方法，指导把数据取完为止）
        Next
    End Sub

    '选择所要上传的文件路径
    Private Sub btnSelectFile_Click(sender As Object, e As EventArgs) Handles btnSelectFile.Click
        Dim filePath As String '上传文件原路径
        '打开文件
        Dim openFileDialog As New OpenFileDialog()
        '获取或设置当前文件名筛选其字符串，使字符串决定对话框的“另存为文件类型或文件类型框中出现的选择”
        openFileDialog.Filter = "Files | *.*"
        'openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
        openFileDialog.InitialDirectory = "C:\"     '初始选择路径C盘
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            filePath = openFileDialog.FileName
            txtFilepath.Text = filePath
        End If
    End Sub

    '根据树的层次让复选框中出现对应的文字
    Private Sub AdvTree1_Click(sender As Object, e As EventArgs) Handles AdvTree1.Click
        chkUsey.Checked = True
        If Me.AdvTree1.Nodes.Count = 0 OrElse Me.AdvTree1.SelectedNode Is Nothing Then Exit Sub
        Dim key As String = AdvTree1.SelectedNode.Name.ToString.Trim    '当前选中节点的Tkey
        Dim text As String = AdvTree1.SelectedNode.Text.ToString.Trim   '当前选中结点的Ttext
        Dim level As String = AdvTree1.SelectedNode.Level.ToString      '当前选中节点的层次+1
        Dim strSql As String = "select Tparent,Ttext from m_MainSop where tkey = (select Tparent from m_MainSop where Tkey='" + key + "')"
        If level = "0" Then
            Me.comFirst.Text = text
            Me.comSecond.Text = ""
            Me.comThree.Text = ""
            Me.txtFirst.Text = text
            Me.txtSecond.Text = ""
            Me.txtThree.Text = ""
        End If
        If level = "1" Then
            Me.comFirst.Text = conn.GetDataTable(strSql).Rows(0)(1).ToString
            Me.comSecond.Text = text
            Me.comThree.Text = ""
            Me.txtFirst.Text = conn.GetDataTable(strSql).Rows(0)(1).ToString
            Me.txtSecond.Text = text
            Me.txtThree.Text = ""
        End If
        If level = "2" Then
            Me.comSecond.Text = conn.GetDataTable(strSql).Rows(0)(1).ToString
            Dim thirdSql As String = "select Ttext from m_MainSop where Usey='Y' and " _
                          & "Tparent = (select Tkey from m_MainSop where Ttext =N'" & comSecond.Text.Trim & "')"
            LoadDataToCob(thirdSql, comThree)
            Me.comThree.Text = text
            Dim parentKey As String = conn.GetDataTable(strSql).Rows(0)(0).ToString
            Me.comFirst.Text = conn.GetDataTable("select Ttext from m_MainSop where tkey='" & parentKey & "'").Rows(0)(0).ToString
            Me.txtThree.Text = text
            Me.txtSecond.Text = Me.comSecond.Text.ToString
            Me.txtFirst.Text = Me.comFirst.Text.ToString
        End If
    End Sub

    '上传
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim userId As String = VbCommClass.VbCommClass.UseId
        Dim tText As String
        Dim extension As String
        Dim tag As String = ""
        Dim name As String
        Dim fileType As Integer
        Dim strSql As String
        'vb中不需要转义
        Dim desPath As String = "\\192.168.20.123\FuJianCall\" + comFirst.Text.Trim
        If comSecond.Text.Trim <> "" Then
            desPath += "\" + comSecond.Text.Trim
        End If
        If comThree.Text.Trim <> "" Then
            desPath += "\" + comThree.Text.Trim
        End If
        '1.截取\\后面的文本插入数据库的Ttext
        Dim i As Integer = desPath.LastIndexOf("\")
        tText = desPath.Substring(i + "\".Length, desPath.Length - i - "\".Length)

        '文件路径为空时 不上传
        If Not File.Exists(txtFilepath.Text.Trim()) Then
            MessageBox.Show("上传文件不存在")
            Return
        End If

        If Not Directory.Exists(desPath) Then
            Directory.CreateDirectory(desPath)
        End If

        name = Path.GetFileName(txtFilepath.Text.Trim()) '获取制定路径字符串的文件名和扩展名
        '2获取上传目标的全路径
        desPath = desPath + "\" + name
        '判断该SOP是否存在，若存在，则退出该方法
        If Dir(desPath) <> "" Then
            MessageBox.Show("该SOP已存在，请重新上传")
            Return
        End If
        '3.获取文件扩展名FileType
        extension = Path.GetExtension(desPath).ToLower
        Select Case extension
            Case ".mp4", ".wmv"
                fileType = 1  '1视频文件
            Case ".ppt", ".pptx"
                fileType = 2        '2ppt文件
            Case ".doc", ".docx"
                fileType = 3        '3word文档
        End Select
        '4.获取Tag
        Dim dtTag As DataTable = conn.GetDataTable("select TreeTag  from m_Logtree_t where Ttext =N'" & tText & "'   or Ttext =N'" & Microsoft.VisualBasic.Strings.StrConv(tText, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0) & "'")
        If dtTag.Rows.Count > 0 Then
            tag = dtTag.Rows(0)(0).ToString()
        End If

        '5获取PreviousTtext
        Dim previousTtext As String
        If comSecond.Text.Trim <> "" Then
            previousTtext = comSecond.Text.Trim
        End If

        Dim remarks As String = txtRemarks.Text.Trim
        If remarks = "" Then
            MessageBox.Show("文件说明不能为空")
            Return
        End If


        strSql = String.Format("insert into m_HelpSop (Ttext ,FilePath ,FileType ,Tag,Name,UpTime,PreviousTtext,UserId,Remark) values(N'{0}',N'{1}','{2}',N'{3}',N'{4}',{5},N'{6}','{7}',N'{8}')", tText, desPath, fileType, tag, name, "getdate()", previousTtext, userId.ToUpper, txtRemarks.Text.Trim())
        Try
            conn.ExecSql(strSql)
            File.Copy(txtFilepath.Text.Trim(), desPath)
            MessageBox.Show("SOP上传成功")
            '加载刷新
            'Me.ListView1.Clear()
            'CreateItem("\\192.168.20.123\FuJianCall\上传SOP")
            'SetListView()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        txtFilepath.Text = ""
        txtRemarks.Text = ""
    End Sub

    '新增(上传SOP)
    'Private Sub btnAddSop_Click(sender As Object, e As EventArgs) Handles btnAddSop.Click
    '    'comSecond.Items.Clear()
    '    'comThree.Items.Clear()
    '    'Dim secondSql As String = "select Ttext from m_MainSop where Tparent ='h0_'"
    '    'LoadDataToCob(secondSql, comSecond)  '填充二级菜单
    'End Sub

    '获取结点路径
    Private Function GetPathFromNode(ByVal node As Node) As String
        '注意：树形控件只赋值tag/Name，使用Text时赋值即可使用
        If node.Parent Is Nothing Then
            Return "\\192.168.20.123\FuJianCall\" + node.Text
        End If
        'Path.Combine组合产生路径 如Path.Combine("A","B")  则生成 “A\\B”
        Return Path.Combine(GetPathFromNode(node.Parent), node.Text)
    End Function

    '更改选定内容后发生 点击AdvTree listView显示对应的文件及文件夹
    Private Sub AdvTree1_AfterNodeSelect(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        Dim path As String '文件路径
        Dim clickNode As Node = e.Node       '获取当前选中结点
        If clickNode Is Nothing Then Exit Sub '没有选中节点时退出程序
        If clickNode.Text.Trim = "上传SOP" Then
            path = "\\192.168.20.123\FuJianCall\上传SOP"
        Else
            '通过自定义函数GetPathFromNode获取结点路径
            path = GetPathFromNode(clickNode)
        End If

        If Directory.Exists(path) Then
            '下面两个函数的次序不能颠倒，因为CreateItem里有一句命令listView1.clear() 把所有列名都删除了，如果SetListView()在前，listview就没有列名了
            CreateItem(path)
            SetListView()
        Else
            ListView1.Clear()
        End If
        'Try
        '    '定义变量
        '    Dim i As Integer
        '    Dim length As Long  '文件大小
        '    Dim path As String '文件路径
        '    Dim clickedNode As Node = e.Node   '获取当前选中节点
        '    If clickedNode Is Nothing Then Exit Sub
        '    'treeView1.SelectedNode = treeView.Nodes[0]];//选中
        '    'clickedNode = AdvTree1.Nodes(0)
        '    '移除ListView所有项
        '    Me.ListView1.Items.Clear()
        '    '获取路径赋值path
        '    If clickedNode.Text.ToString() = "上传SOP" Then
        '        'path = "\\192.168.20.123\\FuJianCall\\上传SOP"
        '        path = "\\192.168.20.123\FuJianCall\上传SOP"
        '    Else
        '        '通过自定义函数GetPathFromNode获取结点路径
        '        path = GetPathFromNode(clickedNode)
        '    End If

        '    If Directory.Exists(path) Then
        '        '数据更新 UI暂时挂起直到EndUpdate绘制控件，可以有效避免闪烁 并大大提高加载速度
        '        Me.ListView1.BeginUpdate()
        '        '实例目录与字目录
        '        'Dim dir As DirectoryInfo = New DirectoryInfo("\\" + path)
        '        Dim dir As DirectoryInfo = New DirectoryInfo(path)
        '        '获取当前目录及文件列表
        '        Dim fileInfo() As FileInfo = dir.GetFiles()
        '        ' Dim fileInfo() As FileSystemInfo = dir.GetFileSystemInfos()
        '        '循环输出获取文件信息
        '        For i = 0 To fileInfo.Length - 1
        '            Dim listItem As ListViewItem = New ListViewItem()
        '            listItem.Text = fileInfo(i).Name   '显示文件名

        '            'length/1024转换为KB字节数整数值 Ceiling返回最小整数值 Divide除法  
        '            'length = fileInfo(i).Length                                '获取当前文件大小  
        '            'listItem.SubItems.Add(Math.Ceiling(Decimal.Divide(length, 1024)) & " KB")

        '            '获取文件最后访问时间  
        '            'listItem.SubItems.Add(fileInfo[i].LastWriteTime.ToString());  

        '            '获取文件扩展名时可用Substring除去点 否则显示".txt文件"  
        '            listItem.SubItems.Add(fileInfo(i).Extension + "文件")
        '            '加载数据至filesList  
        '            Me.ListView1.Items.Add(listItem)

        '            '添加文件系统图标根据文件路径
        '            ListView1.Items(0).ImageIndex = 0
        '            'Dim fullName As String = path & "\" & fileInfo(i).ToString
        '            'MessageBox.Show(fullName)
        '            'Dim fileIcon As System.Drawing.Icon = System.Drawing.Icon.ExtractAssociatedIcon(fullName)
        '            'Dim imgList As ImageList = New ImageList()
        '            'imgList.Images.Add(fileIcon)
        '            '' View.Details = imgList
        '            'ListView1.SmallImageList = imgList
        '            'ListView1.StateImageList = imgList

        '        Next
        '        '结束数据处理,UI界面一次性绘制 否则可能出现闪动情况  
        '        Me.ListView1.EndUpdate()

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    '设置设置ListView控件初始属性
    Private Sub SetListView()
        Me.ListView1.GridLines = False    '行和列是否显示网格线
        Me.ListView1.View = View.Details   '显示方式(注意View是Details的详细显示)
        Me.ListView1.LabelEdit = False  '是否可编辑
        Me.ListView1.Scrollable = True '没有足够的空间时 是否添加滚动条
        Me.ListView1.HeaderStyle = ColumnHeaderStyle.Clickable  '对表头进行设置
        Me.ListView1.FullRowSelect = True     '是否可以选择行
        '设置listView列标题头  宽度9/13 2.13 2/13 其中设置标题头自动适应宽度 -1根据内容设置宽度 -1根据标题设置宽度
        Me.ListView1.Columns.Add("名称", Convert.ToInt32(5 * ListView1.Width / 13))
        Me.ListView1.Columns.Add("修改日期", Convert.ToInt32(3 * ListView1.Width / 13))
        Me.ListView1.Columns.Add("类型", Convert.ToInt32(2 * ListView1.Width / 13))
        Me.ListView1.Columns.Add("大小", Convert.ToInt32(2 * ListView1.Width / 13))
        Me.ListView1.Columns.Add("", Convert.ToInt32(1 * ListView1.Width / 13))
    End Sub

    '为listView添加选项
    Private Sub CreateItem(ByVal root As String)
        Dim lvi As ListViewItem
        Dim lvsi As ListViewItem.ListViewSubItem
        Dim dir As DirectoryInfo = New DirectoryInfo(root)
        Dim dirs() As DirectoryInfo = dir.GetDirectories()
        Dim files() As FileInfo = dir.GetFiles()
        ListView1.Clear() '把listView里的所有选项与所列名称都删除
        ListView1.BeginUpdate() '避免在调用EndUpdate方法之前描述控件。当插入大量数据时，可以有效地避免控件闪烁，并能大大提高速度
        '首先遍历文件夹
        For Each di As DirectoryInfo In dirs
            lvi = New ListViewItem()
            lvi.Text = di.Name
            lvi.Tag = di.FullName
            lvi.ImageIndex = 0
            lvsi = New ListViewItem.ListViewSubItem()
            lvsi.Text = di.LastAccessTime.ToString()
            lvi.SubItems.Add(lvsi)
            lvsi = New ListViewItem.ListViewSubItem()   '类型
            lvsi.Text = "文件夹"
            lvi.SubItems.Add(lvsi)
            lvsi = New ListViewItem.ListViewSubItem()
            lvsi.Text = ""
            lvi.SubItems.Add(lvsi)
            Me.ListView1.Items.Add(lvi)
        Next

        For Each fi As FileInfo In files    '把文件信息添加到listView的选项中
            lvi = New ListViewItem()
            lvi.Text = fi.Name
            lvi.ImageIndex = 3
            lvi.Tag = fi.FullName
            lvsi = New ListViewItem.ListViewSubItem()  '修改时间
            lvsi.Text = fi.LastAccessTime.ToString()
            lvi.SubItems.Add(lvsi)
            lvsi = New ListViewItem.ListViewSubItem()   '类型
            lvsi.Text = fi.Extension & "文件"
            lvi.SubItems.Add(lvsi)
            '根据文件后缀名显示对应图标
            Select Case fi.Extension
                Case ".mp4"
                    lvi.ImageIndex = 1
                Case ".ppt", ".pptx"
                    lvi.ImageIndex = 2
                Case ".doc", ".docx"
                    lvi.ImageIndex = 3 'word显示3
            End Select
            lvsi = New ListViewItem.ListViewSubItem()   '大小
            lvsi.Text = Math.Ceiling(Decimal.Divide(fi.Length.ToString, 1024)) & " KB"
            lvi.SubItems.Add(lvsi)
            Me.ListView1.Items.Add(lvi)
        Next
        Me.ListView1.EndUpdate()
    End Sub

    '查询
    Private Sub btnQuerySop_Click(sender As Object, e As EventArgs) Handles btnQuerySop.Click
        Me.ListView1.Items.Clear()
        Dim beginTime As String = dtmBegin.Value.ToString("yyyy-MM-dd 00:00:00")
        Dim endTime As String = dtmEnd.Value.ToString("yyyy-MM-dd 23:59:59")
        Dim lvi As ListViewItem
        Dim lvsi As ListViewItem.ListViewSubItem
        Dim strSql As String = "select FilePath  from m_HelpSop where UpTime between '" & beginTime & "' and '" & endTime & "'"
        Dim dt As DataTable = conn.GetDataTable(strSql)
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim fi As FileInfo = New FileInfo(dt.Rows(i)(0).ToString)
            lvi = New ListViewItem()
            lvi.Text = fi.Name
            lvi.ImageIndex = 3
            lvi.Tag = fi.FullName
            lvsi = New ListViewItem.ListViewSubItem()
            lvsi.Text = fi.LastAccessTime.ToString()
            lvi.SubItems.Add(lvsi)
            lvsi = New ListViewItem.ListViewSubItem()  '类型
            lvsi.Text = fi.Extension & "文件"
            lvi.SubItems.Add(lvsi)
            '根据文件后缀名显示对应图标
            Select Case fi.Extension
                Case ".mp4"
                    lvi.ImageIndex = 1
                Case ".ppt", ".pptx"
                    lvi.ImageIndex = 2
                Case ".doc", ".docx"
                    lvi.ImageIndex = 3 'word显示3
            End Select
            lvsi = New ListViewItem.ListViewSubItem()  '大小
            lvsi.Text = Math.Ceiling(Decimal.Divide(fi.Length.ToString, 1024)) & " KB"
            lvi.SubItems.Add(lvsi)
            Me.ListView1.Items.Add(lvi)
        Next
    End Sub

    '新增
    Private Sub btnAddMaintain_Click(sender As Object, e As EventArgs) Handles btnAddMaintain.Click
        Me.txtSecond.Text = ""
        Me.txtThree.Text = ""
        Me.chkUsey.Checked = True
        opFlag = 1   '按钮重置状态为1
        BtnMaintainState(1)
    End Sub
    '新增后保存
    Private Sub btnMaintainSave_Click(sender As Object, e As EventArgs) Handles btnMaintainSave.Click
        Dim treeId As String
        Dim treeCount As String = ""
        Dim tKey As String
        Dim strSql As String = ""
        Dim strSqlt As String = ""
        Dim firstMenu As String = txtFirst.Text.Trim
        Dim secondMenu As String = txtSecond.Text.Trim
        Dim thirdMenu As String = txtThree.Text.Trim
        If secondMenu = "" Then Exit Sub
        If opFlag = 1 Then   '新增后保存执行插入操作
            Dim mCheckSecondRead As SqlDataReader = conn.GetDataReader("select Tkey,Ttext from m_MainSop where Ttext=N'" & secondMenu & "'  and Usey ='Y'")
            If mCheckSecondRead.HasRows Then
                mCheckSecondRead.Close()
                ' MessageBox.Show("该菜单名已经存在", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                mCheckSecondRead.Close()
                Dim mRead As SqlDataReader = conn.GetDataReader("select count(Tkey) as countTkey from m_MainSop where Tparent='h0_'")
                If mRead.HasRows Then
                    While mRead.Read
                        treeCount = Convert.ToInt16(mRead!countTkey) + 1
                    End While
                Else
                    treeCount = "1"
                End If
                mRead.Close()

                treeId = "h0_" + treeCount.PadLeft(2, "0")
                tKey = "h0_" + treeCount.PadLeft(2, "0") + "_"
                '二级菜单写入是否正确
                Dim index As Integer
                index = Me.txtSecond.FindString(Me.txtSecond.Text)
                If index <= -1 Then
                    MessageBox.Show("二级菜单请从下拉列表中选择")
                    Return
                End If

                '插入数据库
                strSql = String.Format("insert into m_MainSop(TreeId,Tkey,Tparent,Ttext,Usey) values('{0}','{1}','{2}',N'{3}',N'{4}')", treeId, tKey, "h0_", secondMenu, "Y")

                Try
                    conn.ExecSql(strSql.ToString)
                    MessageBox.Show("二级菜单保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnMaintainSave_Click", "sys")
                End Try
            End If

          
            'mCheckSecondRead.Close()

            '插入三级菜单
            If thirdMenu = "" Then Exit Sub
            Dim tradWord As String = Microsoft.VisualBasic.Strings.StrConv(thirdMenu, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0)
            Dim dttm As DataTable = conn.GetDataTable("select distinct(Ttext) from m_Logtree_t where TreeTag <> ''  and TreeTag <> 'BarCodeQuery.FrmDCShipQuery' and Ttext not like '%[0-9]%'  and Ttext =N'" & thirdMenu & "'   or Ttext =N'" & tradWord & "'")
            If dttm.Rows.Count <= 0 Then
                MessageBox.Show("该三级菜单[" & thirdMenu & "]无效")
                txtThree.Text = ""
                Return
            End If


            Dim dtp As DataTable = conn.GetDataTable("select Tkey,Ttext from m_MainSop where Ttext=N'" & secondMenu & "'")
            Dim dt As DataTable = conn.GetDataTable("select Tkey,Ttext from m_MainSop where Ttext=N'" + thirdMenu + "'  and Usey ='Y'")
            If dt.Rows.Count <= 0 Then
                treeCount = Convert.ToInt16(conn.GetDataTable("select count(*) from m_MainSop where Tparent='" & dtp.Rows(0)(0).ToString() & "'").Rows(0)(0).ToString()) + 1
                treeId = dtp.Rows(0)(0).ToString & treeCount.PadLeft(2, "0")
                tKey = dtp.Rows(0)(0).ToString & treeCount.PadLeft(2, "0") & "_"

                strSqlt = String.Format(" insert into m_MainSop(TreeId,Tkey,Tparent,Ttext,Usey)  values('{0}','{1}','{2}',N'{3}','{4}')", treeId, tKey, dtp.Rows(0)(0).ToString(), thirdMenu, "Y")
                Try
                    conn.ExecSql(strSqlt)
                    MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnMaintainSave_Click", "sys")
                End Try
            Else
                MessageBox.Show("该菜单名已存在")
            End If
        End If

        If opFlag = 2 Then
            Dim updateSql As String
            Dim chkUsey As String = IIf(Me.chkUsey.Checked, "Y", "N")
            If Me.AdvTree1.Nodes.Count = 0 OrElse Me.AdvTree1.SelectedNode Is Nothing Then Exit Sub
            Dim key As String = AdvTree1.SelectedNode.Name.ToString.Trim    '当前选中节点的Tkey
            Dim text As String = AdvTree1.SelectedNode.Text.ToString.Trim   '当前选中结点的Ttext
            Dim level As String = AdvTree1.SelectedNode.Level.ToString      '当前选中节点的层次+1
            Dim querySql As String = "select Tparent,Ttext from m_MainSop where tkey = (select Tparent from m_MainSop where Tkey='" + key + "')"
            If level = "1" Then
                updateSql = "update m_MainSop set Ttext =N'" & txtSecond.Text & "' where Ttext =N'" & text & "'"
            End If
            If level = "2" Then
                updateSql = "update m_MainSop set Ttext =N'" & txtSecond.Text & "' where Ttext =N'" & conn.GetDataTable(querySql).Rows(0)(1).ToString & "'" _
                           & " update m_MainSop set Ttext =N'" & txtThree.Text & "',Usey='" & chkUsey & "'  where Ttext =N'" & text & "'"
            End If
            Try
                conn.ExecSql(updateSql)
                MessageBox.Show("修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnMaintainSave_Click", "sys")
            End Try
        End If



        txtFirst.Text = ""
        txtSecond.Text = ""
        txtThree.Text = ""

        opFlag = 0
        BtnMaintainState(0)

        'AdvTree1.Nodes.Clear()
        AdvTree1.Nodes.Clear()
        '  TreeView1.Nodes.Remove (TreeView1.Nodes(Index).Child.Key)
        'AdvTree1.Nodes.Remove(AdvTree1.Nodes(0).HasChildNodes)
        Dim dtl As DataTable = conn.GetDataTable("select * from m_MainSop where Usey ='Y'")
        Bind_Tv(dtl, AdvTree1.Nodes, "h0_", "Tkey", "Tparent", "Ttext", True, False)
        If AdvTree1.Nodes.Count > 0 Then
            AdvTree1.SelectedIndex = 0
            AdvTree1_Click(Nothing, Nothing)
        End If
        Me.AdvTree1.Nodes(0).Expand()
        '刷新二级菜单
        Dim secondSql As String = "select Ttext from m_MainSop where Tparent ='h0_'"
        LoadDataToCob(secondSql, comSecond)

    End Sub
    '返回
    Private Sub btnMaintainBack_Click(sender As Object, e As EventArgs) Handles btnMaintainBack.Click
        txtSecond.Text = ""
        txtThree.Text = ""
        chkUsey.Checked = False
        opFlag = 0
        BtnMaintainState(0)
    End Sub
    '修改
    Private Sub btnMaintainEdit_Click(sender As Object, e As EventArgs) Handles btnMaintainEdit.Click
        If Me.txtSecond.Text = "" Then
            MessageBox.Show("二级菜单为空，无法进行修改")
            Return
        End If
        Me.chkUsey.Checked = True
        opFlag = 2
        BtnMaintainState(2)
    End Sub
    '作废
    Private Sub btnMaintainAban_Click(sender As Object, e As EventArgs) Handles btnMaintainAban.Click
        If Me.AdvTree1.Nodes.Count = 0 OrElse Me.AdvTree1.SelectedNode Is Nothing Then Exit Sub
        Dim key As String = AdvTree1.SelectedNode.Name.ToString.Trim    '当前选中节点的Tkey
        Dim text As String = AdvTree1.SelectedNode.Text.ToString.Trim   '当前选中结点的Ttext
        Dim level As String = AdvTree1.SelectedNode.Level.ToString      '当前选中节点的层次+1
        Dim querySql As String = "select Tparent,Ttext from m_MainSop where tkey = (select Tparent from m_MainSop where Tkey='" + key + "')"
        If level = "1" Or level = "0" Then
            MessageBox.Show("您无权作废一级和二级菜单")
            Return
        End If
        Dim abandonSql As String = "update m_MainSop set Usey ='N' where Ttext =N'" & txtThree.Text.Trim & "'"
        If MessageBox.Show("确定要作废三级菜单：[" & Me.txtThree.Text.Trim & "]吗", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            conn.ExecSql(abandonSql)
            MessageBox.Show("成功作废三级菜单：[" & txtThree.Text.Trim & "]")
            AdvTree1.Nodes.Clear()
            Dim dt As DataTable = conn.GetDataTable("select * from m_MainSop where Usey ='Y'")
            Bind_Tv(dt, AdvTree1.Nodes, "h0_", "Tkey", "Tparent", "Ttext", True, False)
            If AdvTree1.Nodes.Count > 0 Then
                AdvTree1.SelectedIndex = 0
                AdvTree1_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnMaintainAban_Click", "sys")
        End Try

    End Sub

    '退出当前窗体
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Dim fileName As String
    '双击打开listView中的文件
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim lv As ListView = sender
        fileName = lv.SelectedItems(0).Tag.ToString()
        If lv.SelectedItems(0).ImageIndex = 0 Then
            CreateItem(fileName)
            SetListView()
            colStr.Add(fileName)   '把打开的文件夹的路径记录下来 这里是因为我们现在的路径是已知的，不用记录
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(fileName)  '设置只读
            dirInfo.Attributes = FileAttribute.ReadOnly
        Else
            System.Diagnostics.Process.Start(fileName)
            File.SetAttributes(fileName, FileAttribute.ReadOnly) 'readonly
        End If
    End Sub
    '大图标显示
    Private Sub rdoLarge_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLarge.CheckedChanged
        If Me.rdoLarge.Checked = True Then
            Me.ListView1.View = View.LargeIcon
        End If
    End Sub
    '小图标
    Private Sub rdoSmall_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSmall.CheckedChanged
        If Me.rdoSmall.Checked = True Then
            Me.ListView1.View = View.SmallIcon
        End If
    End Sub
    '详细信息显示
    Private Sub rdoDetails_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDetails.CheckedChanged
        If Me.rdoDetails.Checked = True Then
            Me.ListView1.View = View.Details
        End If
    End Sub
    '列表显示
    Private Sub rdoList_CheckedChanged(sender As Object, e As EventArgs) Handles rdoList.CheckedChanged
        If Me.rdoList.Checked = True Then
            Me.ListView1.View = View.List
        End If
    End Sub
    '打开文件夹后实现后退功能
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If colStr.Count > 1 Then
            CreateItem(colStr(colStr.Count - 2))
            colStr.RemoveAt(colStr.Count - 1)
            SetListView()
        ElseIf colStr.Count = 1 Then
            'CreateItem(fileName)
            CreateItem("\\192.168.20.123\FuJianCall\上传SOP")
            SetListView()
            colStr.Clear()
        End If
    End Sub
    '修改
    Private Sub btnAddSop_Click(sender As Object, e As EventArgs) Handles btnAddSop.Click
        btnSave.Enabled = True
    End Sub

    '删除SOP
    Private Sub btnDeleteSop_Click(sender As Object, e As EventArgs) Handles btnDeleteSop.Click
        Dim strSql As String
        Dim fileName As String
        Dim digResult As DialogResult

        If ListView1.SelectedItems.Count <> 0 Then
            fileName = Me.ListView1.SelectedItems(0).Tag.ToString
            '文件夹若为空 删除文件夹否则不可以删除
            If Me.ListView1.SelectedItems(0).ImageIndex = 0 Then
                Dim di As DirectoryInfo = New DirectoryInfo(fileName)
                If di.GetFiles().Length + di.GetDirectories().Length = 0 Then
                    di.Attributes = FileAttribute.Normal
                    Directory.Delete(fileName)
                    MessageBox.Show("删除文件夹成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.ListView1.SelectedItems(0).Remove()
                    Return
                Else
                    MessageBox.Show("该文件夹不为空，不能删除")
                    Return
                End If
            End If
            digResult = MessageBox.Show("确定要删除该SOP吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If digResult = digResult.Yes Then
                strSql = "delete from m_HelpSop where Name =N'" & Me.ListView1.SelectedItems(0).Text.ToString() & "'"
                Try
                    conn.ExecSql(strSql)
                    File.SetAttributes(fileName, FileAttribute.Normal)
                    File.Delete(fileName)
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    txtRemarks.Text = ""
                Catch ex As Exception
                    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnDeleteSop", "sys")
                    'MessageBox.Show(ex.ToString)
                End Try

                Me.ListView1.SelectedItems(0).Remove()
            End If
        Else
            MessageBox.Show("请先选择要删除的项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        End If

    End Sub
    '点击listView显示对应文本
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Dim fileNames As String
        Dim strSql As String
        Dim dt As DataTable
        If ListView1.SelectedItems.Count <> 0 Then
            fileNames = Me.ListView1.SelectedItems(0).Tag.ToString
            If File.Exists(fileNames) Then
                Try
                    strSql = "select PreviousTtext,Ttext ,remark from m_HelpSop where FilePath =N'" & fileNames & "'"
                    dt = conn.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        comSecond.Text = dt.Rows(0)(0).ToString
                        comThree.Text = dt.Rows(0)(1).ToString
                        txtRemarks.Text = dt.Rows(0)(2).ToString
                    End If
                Catch ex As Exception
                    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnSave_Click", "sys")
                End Try
            ElseIf Directory.Exists(fileNames) Then
                Return
            End If

        End If
    End Sub

    '保存
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fileNames As String
        Dim strSql As String
        Dim dt As DataTable
        Dim remark As String

        If ListView1.SelectedItems.Count <> 0 Then

            fileNames = Me.ListView1.SelectedItems(0).Tag.ToString
            If File.Exists(fileNames) Then
                Try
                    'strSql = "select PreviousTtext,Ttext ,remark from m_HelpSop where FilePath =N'" & fileNames & "'"
                    'dt = conn.GetDataTable(strSql)
                    'If dt.Rows.Count > 0 Then
                    remark = txtRemarks.Text.Trim
                    Dim updateSql As String = "update m_HelpSop  set remark = N'" & remark & "' where FilePath = N'" & fileNames & "'"
                    conn.ExecSql(updateSql)
                    MessageBox.Show("修改文件说明成功")
                    btnSave.Enabled = False
                    'End If
                Catch ex As Exception
                    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmMaintainSop", "btnSave_Click", "sys")
                End Try
            End If

        ElseIf Directory.Exists(fileNames) Then
            Return
        End If
    End Sub
End Class