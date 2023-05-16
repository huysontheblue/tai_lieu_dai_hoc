Imports MainFrame
Imports DevComponents.AdvTree
Imports DevComponents
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.IO
Imports Aspose.Cells
Imports System.Drawing.Imaging

Public Class FrmRStationNgOfPart

#Region "定义 导入列名称"
    Private Enum CDImportGrid
        StationType  '工站类型
        StationName   '不良站点名称
        BCodeName  '不良现象大类
        CodeName    '不良现象名称
    End Enum
#End Region

    Public station As String  '工站编号
    Public stationName As String  '工站名称
    Public m_strPartID As String
    Public m_strCurrentVer As String
    Dim conn As New SysDataHandle.SysDataBaseClass   '定义连接数据库
    Dim sqlCheckStr As New StringBuilder
    Dim treeClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim factory As String = VbCommClass.VbCommClass.Factory '工厂
    Dim profit As String = VbCommClass.VbCommClass.profitcenter  '利润中心
    Dim userID As String = VbCommClass.VbCommClass.UseId   '当前用户工号

    Private Sub FrmRStationNg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = station   '显示当前站点编号
        Label3.Text = stationName  '显示当前站点名称 
        lblPartID.Text = m_strPartID
        Me.lblVer.Text = m_strCurrentVer
        TreeLoad()  '初始化TreeeView树
        CheckData() '勾选当前站点的不良代码
        AdvTreeLoad() '初始化Adv树
    End Sub
#Region "事件"
#Region "退出"
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "查看导入格式"
    ''' <summary>
    ''' 查看导入格式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "站点不良代码关联导入模板")
    End Sub
#End Region

#Region "选中之后的事件"
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            If e.Action = TreeViewAction.ByMouse Then
                If e.Node.Checked = True Then
                    '选中节点之后，选中该节点所有的子节点
                    SetChildNodeCheckedState(e.Node, True)
                    '选中父节点
                    If Not e.Node.Parent Is Nothing Then
                        e.Node.Parent.Checked = True
                        If Not e.Node.Parent.Parent Is Nothing Then
                            e.Node.Parent.Parent.Checked = True
                        End If
                    End If
                Else
                    If e.Node.Checked = False Then
                        '取消节点选中状态之后，取消该节点所有子节点选中状态
                        SetChildNodeCheckedState(e.Node, False)
                        '如果节点存在父节点，取消父节点的选中状态

                        'SetParentChildCheckState(e.Node)
                        If Not e.Node.Parent Is Nothing Then
                            '兄弟节点全不选   取消父节点选中状态

                            ' SetParentNodeCheckedState(e.Node, False)
                            'End If
                            '原来的
                            SetParentChildCheckState(e.Node)
                        End If
                    End If
                End If
            End If

            If e.Action <> TreeViewAction.Unknown Then
                Me.TreeView1.BeginUpdate()
                Try
                    CodeAddorDel(e.Node.Name, e.Node, e.Node.Nodes.Count, e.Node.Checked, True)
                Catch ex As Exception
                    Throw ex
                Finally
                    sqlCheckStr.Remove(0, sqlCheckStr.Length - 1)
                End Try

                Me.TreeView1.EndUpdate()

                AdvTree2.Nodes.Clear()
                AdvTreeLoad()
                AdvTree2.ExpandAll()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationNg", "TreeView1_AfterCheck", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "导入"
    ''' <summary>
    ''' 导入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传数据 (4：代表4列数据)
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 4, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" ")
            '= dtUploadData.Select(" Station is not null") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)

            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入！")
            End If
            CheckData()
            AdvTreeLoad()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRAtationNg", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "导出"
    ''' <summary>
    ''' 导出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Dim strSql As String
            strSql = "select  StationID '不良站点代码',StationName '不良站点名称',ECodeID '大类代码',ECodeName '大类名称',CodeID '不良现象代码'," &
                    " CodeName '不良现象名称',Factory '工厂',Profit  '利润中心',UserID '用户工号',Intime '时间' " &
                    " from m_StationCode_t where StationID ='" & station & "'  order by CodeID "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count <= 0 Then
                MessageUtils.ShowInformation("当前站点没有要导出的不良代码！")
                Return
            End If

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationNg", "toolExcel_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "窗体大小改变 label居中"
    ''' <summary>
    ''' 窗体大小改变 label居中
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmRStationNg_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Label1.Location = New Point((GroupBox1.Width - Label1.Width) / 2 - 2.0 * Label2.Width, (GroupBox1.Height - Label1.Height) / 2)
        Label2.Location = New Point((GroupBox1.Width - Label2.Width) / 2 - 0.6 * Label1.Width, (GroupBox1.Height - Label2.Height) / 2)
        Label3.Location = New Point((GroupBox1.Width - Label4.Width) / 2 + 1.6 * Label4.Width, (GroupBox1.Height - Label3.Height) / 2)
        Label4.Location = New Point((GroupBox1.Width - Label4.Width) / 2 + 0.6 * Label4.Width, (GroupBox1.Height - Label4.Height) / 2)
    End Sub
#End Region

#Region "打印"
    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        ImportToExcel()
    End Sub
#End Region
#End Region

#Region "方法"
#Region "初始化树"
    ''' <summary>
    '''TreeeView树
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TreeLoad()
        Try
            Dim dt As DataTable = conn.GetDataTable(" SELECT distinct EsortName,CD.CsortName CsortName from m_code_t  CD INNER JOIN m_coder_t CDR  ON CD.CodeID = CDR.rEsortName ")
            Dim dt1 As DataTable = conn.GetDataTable("SELECT distinct  EsortName,CD.CsortName,CodeID  ,CD.CCName CCName  from m_code_t  CD INNER JOIN m_coder_t CDR  ON CD.CodeID = CDR.rEsortName  order by  CodeID asc")
            Dim tnn As TreeNode '建立AdvTree的节点（AdvTRee.Node），以便将取出的数据添加到节点中 As AdvTRee.Node
            TreeView1.Nodes.Clear()
            tnn = New TreeNode()
            tnn.Text = "站点不良代码"
            TreeView1.Nodes.Add(tnn)
            Bind_Tv(dt, dt1, tnn.Nodes, " ", "EsortName", "CsortName", True)
        Catch ex As Exception
            Throw ex
        End Try
        If Not TreeView1 Is Nothing Then
            If TreeView1.Nodes.Count > 0 Then
                TreeView1.Nodes(0).Expand()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 初始化Adv树
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AdvTreeLoad()
        Try
            Dim dt As DataTable = conn.GetDataTable("select distinct ECodeID EsortName,ECodeName  CsortName  from m_StationCode_t where StationID ='" + station + "' and PartID='" + m_strPartID + "' AND Version='" + m_strCurrentVer + "' ")
            Dim dt1 As DataTable = conn.GetDataTable("select distinct ECodeID EsortName,CodeID,CodeName CCName   from m_StationCode_t where StationID ='" + station + "' ")
            AdvTree2.Nodes.Clear()
            Dim tnn As Node '建立AdvTree的节点（AdvTRee.Node），以便将取出的数据添加到节点中 As AdvTRee.Node
            tnn = New Node()
            tnn.Text = "站点不良代码"
            AdvTree2.Nodes.Add(tnn)
            Bind_Tva(dt, dt1, tnn.Nodes, " ", "EsortName", "CsortName", True)
        Catch ex As Exception
            Throw ex
        End Try
        If Not AdvTree2 Is Nothing Then
            If AdvTree2.Nodes.Count > 0 Then
                AdvTree2.ExpandAll()
            End If
        End If
    End Sub
#End Region

#Region "绑定AdvTree"""
    ''' <summary>
    ''' 绑定AdvTree
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dt1"></param>
    ''' <param name="tnc"></param>
    ''' <param name="code_val"></param>
    ''' <param name="code"></param>
    ''' <param name="codeName"></param>
    ''' <param name="isFirst"></param>
    ''' <remarks></remarks>
    Private Sub Bind_Tva(ByVal dt As DataTable, ByVal dt1 As DataTable, ByVal tnc As NodeCollection, ByVal code_val As String, ByVal code As String, ByVal codeName As String, ByVal isFirst As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据 
        Dim tn As Node   '建立AdvTree的节点（AdvTRee.Node），以便将取出的数据添加到节点中 As TreeNode

        '以下为if判断，如果父id为空,则为构建“父id字段 is null”的查询条件，否则构建"父id字段=父id字段值"的查询条件
        Dim filter As String = String.Empty
        If isFirst Then
            If String.IsNullOrEmpty(code_val) Then
                'filter =
            Else
                'filter =             
            End If
        Else
            If String.IsNullOrEmpty(code_val) Then
                'filter =
            Else
                filter = String.Format(" EsortName ='{0}' ", code_val)
            End If
        End If
        dv.RowFilter = filter '利用DataView将数据进行筛选，晒出相同 父id值 的数据

        Dim drv As DataRowView
        If dv.Count > 0 Then
            For Each drv In dv
                tn = New Node() '建立一个新结点（学名叫：一个实例）
                tn.Name = drv(code).ToString()  '结点的Value值，一般为数据库的id值
                tn.Text = drv(code).ToString() + "-" + drv(codeName).ToString()  '结点的Text，结点的文本表示

                tnc.Add(tn)   '将该节点加入到AdvTreeNodeCollection（结点集合）中
                Bind_Tva(dt1, dt, tn.Nodes, tn.Name, "CodeID", "CCName", False) '递归（反复调用这个方法，指导把数据取完为止）
            Next
        End If
    End Sub
#End Region
#Region "绑定TreeView（利用TreeNodeCollection）"
    ''' <summary>
    ''' 绑定TreeView（利用TreeNodeCollection）
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dt1"></param>
    ''' <param name="tnc"></param>
    ''' <param name="code_val"></param>
    ''' <param name="code"></param>
    ''' <param name="codeName"></param>
    ''' <param name="isFirst"></param>
    ''' <remarks></remarks>
    Private Sub Bind_Tv(ByVal dt As DataTable, ByVal dt1 As DataTable, ByVal tnc As TreeNodeCollection, ByVal code_val As String, ByVal code As String, ByVal codeName As String, ByVal isFirst As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据 
        Dim tn As TreeNode  '建立AdvTree的节点（AdvTRee.Node），以便将取出的数据添加到节点中 As TreeNode

        '以下为if判断，如果父id为空,则为构建“父id字段 is null”的查询条件，否则构建"父id字段=父id字段值"的查询条件
        Dim filter As String = String.Empty
        If isFirst Then
            If String.IsNullOrEmpty(code_val) Then
                'filter =
            Else
                'filter =             
            End If
        Else
            If String.IsNullOrEmpty(code_val) Then
                'filter =
            Else
                filter = String.Format(" EsortName ='{0}' ", code_val)
            End If
        End If
        dv.RowFilter = filter '利用DataView将数据进行筛选，晒出相同 父id值 的数据

        Dim drv As DataRowView
        If dv.Count > 0 Then
            For Each drv In dv
                tn = New TreeNode() '建立一个新结点（学名叫：一个实例）
                tn.Name = drv(code).ToString()  '结点的Value值，一般为数据库的id值
                tn.Text = drv(code).ToString() + "-" + drv(codeName).ToString()  '结点的Text，结点的文本表示

                tnc.Add(tn)   '将该节点加入到AdvTreeNodeCollection（结点集合）中
                Bind_Tv(dt1, dt, tn.Nodes, tn.Name, "CodeID", "CCName", False) '递归（反复调用这个方法，指导把数据取完为止）
            Next
        End If
    End Sub
#End Region


#Region "取消节点选中状态之后，取消所有父节点的选中状态"
    ''' <summary>
    ''' 取消节点选中状态之后，取消所有父节点的选中状态
    ''' </summary>
    ''' <param name="currNode"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub SetParentNodeCheckedState(ByVal currNode As TreeNode, ByVal state As Boolean)
        Dim parentNode As TreeNode = currNode.Parent
        parentNode.Checked = state
        If Not currNode.Parent.Parent Is Nothing Then
            SetParentNodeCheckedState(currNode.Parent, state)
        End If
    End Sub
#End Region

#Region "选中节点之后，选中节点的所有子节点"
    ''' <summary>
    ''' 选中节点之后，选中节点的所有子节点
    ''' </summary>
    ''' <param name="currNode"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub SetChildNodeCheckedState(ByVal currNode As TreeNode, ByVal state As Boolean)
        Dim nodes As TreeNodeCollection = currNode.Nodes
        If nodes.Count > 0 Then
            For Each tn As TreeNode In nodes
                tn.Checked = state
                SetChildNodeCheckedState(tn, state)
            Next
        End If
    End Sub
#End Region

#Region "取消节点之后 若相邻节点有选中 父级节点仍然选中 "
    ''' <summary>
    ''' 取消节点之后 若相邻节点有选中 父级节点仍然选中 
    ''' </summary>
    ''' <param name="currNode"></param>
    ''' <remarks></remarks>
    Private Sub SetParentChildCheckState(ByVal currNode As TreeNode)
        Dim nodes As TreeNodeCollection = currNode.Parent.Nodes
        Dim i As Integer
        If nodes.Count > 0 Then
            For Each tn As TreeNode In nodes
                If tn.Checked = True Then
                    i = 2
                End If
            Next

            If i = 2 Then
                SetParentNodeCheckedState(currNode, True)
            Else
                Dim parentNode As TreeNode = currNode.Parent
                parentNode.Checked = False
                If Not currNode.Parent.Parent Is Nothing Then
                    SetParentChildCheckState(currNode.Parent)
                    ' SetParentNodeCheckedState(currNode.Parent, state)
                End If
                'SetParentNodeCheckedState(currNode, False)
            End If
        End If


    End Sub
#End Region

#Region "选中节点 插入或删除数据库"
    ''' <summary>
    ''' 选中节点 插入或删除数据库
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="node"></param>
    ''' <param name="nodesCount"></param>
    ''' <param name="addOrDel"></param>
    ''' <param name="nodeChecky"></param>
    ''' <remarks></remarks>
    Private Sub CodeAddorDel(ByVal nodeName As String, ByVal node As TreeNode, ByVal nodesCount As Integer, ByVal addOrDel As Boolean, ByVal nodeChecky As Boolean)
        Try
            sqlCheckStr = New StringBuilder
            Dim level As Integer = node.Level

            If string.IsNullOrEmpty(station) Then
                station = Label2.Text.Trim()
            End If

            If String.IsNullOrEmpty(stationName) Then
                stationName = Label3.Text.Trim()
            End If

            If addOrDel = True Then
                '当前选中节点的层次+1
                If level = 2 Then
                    Dim n As Integer = (node.Text.ToString).IndexOf("-")
                    Dim codeName As String = (node.Text.ToString).Remove(0, n + 1)
                    sqlCheckStr.Append("INSERT INTO [dbo].[m_StationCode_t] ([StationID],[StationName],[ECodeID],[ECodeName],[CodeID],[CodeName],[Factory],[Profit],[UserID],[Intime],PartID,Version) ")
                    sqlCheckStr.Append(" VALUES('" + station + "',N'" + stationName + "','" + Split(node.Parent.Text.ToString, "-")(0) + "',N'" + Split(node.Parent.Text.ToString, "-")(1) + "','" + Split(node.Text.ToString, "-")(0) + "',N'" + codeName + "',N'" + factory + "',N'" + profit + "','" + userID + "',GETDATE (),'" + m_strPartID + "','" + m_strCurrentVer + "')")
                    sqlCheckStr.Append(Environment.NewLine)

                    treeClass.ExecSql(sqlCheckStr.ToString)
                ElseIf level = 1 Or level = 0 Then
                    If nodesCount > 0 Then
                        Me.CheckAllChildNodes(node, addOrDel, nodeChecky)
                        treeClass.ExecSql(sqlCheckStr.ToString)
                        'Else
                        'treeClass.ExecSql(sqlCheckStr.ToString)
                    End If
                End If
                treeClass.PubConnection.Close()
            Else

                '为false选定
                If level = 2 Then
                    sqlCheckStr.Append("delete from [dbo].[m_StationCode_t] where StationID='" + station + "' and ECodeID='" + Split(node.Parent.Text.ToString, "-")(0) + "' and CodeID='" + Split(node.Text.ToString, "-")(0) + "' ")
                    sqlCheckStr.Append(Environment.NewLine)

                    treeClass.ExecSql(sqlCheckStr.ToString)
                ElseIf level = 1 Or level = 0 Then
                    If nodesCount > 0 Then
                        Me.CheckAllChildNodes(node, addOrDel, nodeChecky)
                        treeClass.ExecSql(sqlCheckStr.ToString)
                        'Else
                        'treeClass.ExecSql(sqlCheckStr.ToString)
                    End If
                End If
                treeClass.PubConnection.Close()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationNg", "CodeAddorDel", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

#Region "子节点插入或删除数据库"
    ''' <summary>
    ''' 子节点插入或删除数据库
    ''' </summary>
    ''' <param name="treeNode"></param>
    ''' <param name="nodeChecked"></param>
    ''' <param name="nodeChecky"></param>
    ''' <remarks></remarks>
    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean, ByVal nodeChecky As Boolean)
        Try
            Dim node As TreeNode
            For Each node In treeNode.Nodes
                If nodeChecky Then
                    node.Checked = nodeChecked
                End If

                If nodeChecked Then
                    If node.Level = 2 Then
                        Dim n As Integer = (node.Text.ToString).IndexOf("-")
                        Dim codeName As String = (node.Text.ToString).Remove(0, n + 1)
                        sqlCheckStr.Append("INSERT INTO [dbo].[m_StationCode_t] ([StationID],[StationName],[ECodeID],[ECodeName],[CodeID],[CodeName],[Factory],[Profit],[UserID],[Intime],PartID,Version) " &
                        "VALUES('" + station + "',N'" + stationName + "','" + Split(node.Parent.Text.ToString, "-")(0) + "',N'" + Split(node.Parent.Text.ToString, "-")(1) + "','" + Split(node.Text.ToString, "-")(0) + "',N'" + codeName + "',N'" + factory + "',N'" + profit + "','" + userID + "',GETDATE (),'" + m_strPartID + "','" + m_strCurrentVer + "')")

                        sqlCheckStr.Append(Environment.NewLine)
                        ' else
                    End If

                Else
                    If node.Level = 2 Then
                        sqlCheckStr.Append("delete from [dbo].[m_StationCode_t] where StationID='" + station + "' and ECodeID='" + Split(node.Parent.Text.ToString, "-")(0) + "' and CodeID='" + Split(node.Text.ToString, "-")(0) + "'  and partid ='" + m_strPartID + "' and Version ='" + m_strCurrentVer + "'")
                        sqlCheckStr.Append(Environment.NewLine)
                        ' else
                    End If
                End If

                If node.Nodes.Count > 0 Then
                    Me.CheckAllChildNodes(node, nodeChecked, nodeChecky)
                End If
            Next node
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationNg", "CheckAllChildNodes", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub
#End Region
#End Region

#Region "改变Table列名 ChangeCDDataTableColumnName"
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub
#End Region

#Region "追加列 TableAddColumns"
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub
#End Region

#Region "检查上传数据 CheckUploadData"
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        '站点类型
        Dim stationTypeSQL As String = "SELECT SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' order by Orderid"
        Dim stationTypeDT As DataTable = DbOperateUtils.GetDataTable(stationTypeSQL)

        '站点
        ' Dim stationSQL As String = "SELECT  Stationname,Stationtype  FROM m_RStation_t  WHERE usey='Y'"
        Dim stationSQL As String = " select SortName,Stationname from " _
                                   & "( SELECT  Stationname,Stationtype FROM m_RStation_t WHERE usey='Y')A " _
                                   & " inner Join " _
                                   & " (SELECT SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' ) B " _
                                   & " on A.Stationtype=B.SortID"
        Dim stationDT As DataTable = DbOperateUtils.GetDataTable(stationSQL)
        'DB不良现象大类别
        Dim bCodeNameSQL As String = "SELECT distinct CD.CsortName CsortName  from m_code_t  CD INNER JOIN m_coder_t CDR  ON CD.CodeID = CDR.rEsortName order by  CD.CsortName  desc"
        Dim bCodeNameDT As DataTable = DbOperateUtils.GetDataTable(bCodeNameSQL)
        '不良现象名称
        Dim codeNameSQL As String = "SELECT distinct CD.CsortName CsortName,CodeID,CD.CCName CCName from m_code_t  CD INNER JOIN m_coder_t CDR  ON CD.CodeID = CDR.rEsortName  order by  CD.CCName  asc"
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)
        '不良现象名称与不良现象大类别是否匹配
        Dim sameSQL As String = "SELECT distinct CsortName,CCName  from m_code_t"
        Dim sameDT As DataTable = DbOperateUtils.GetDataTable(sameSQL)
        '不良站点名称 不良现象大类别 不良现象名称是否已经关联过
        Dim uniSQL As String = "select StationName, CodeName ,ECodeName from m_StationCode_t "
        Dim uniDT As DataTable = DbOperateUtils.GetDataTable(uniSQL)

        For index As Integer = 0 To DrrR.Length - 1
            Dim returnCode As String = ""

            '站点类型
            Dim stationType As String = DrrR(index)("StationType").ToString.Trim
            If stationType <> "" Then
                If CheckExistUserColumnsnum(stationTypeDT, "SortName", stationType, "1", "1", returnCode) = 0 Then
                    MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[工站类别]：" + stationType + "没有在资料库中")
                    Return False
                End If
            Else
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 [工站类别]有空值，请检查后重新上传")
                Return False
            End If



            '不良站点名称
            Dim stationName As String = DrrR(index)("StationName").ToString.Trim
            If stationName <> "" Then
                If CheckExistUserColumnsnum(stationDT, "Stationname", stationName, "1", "1", returnCode) = 0 Then
                    MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[不良站点名称]：" + stationName + "没有在资料库中")
                    Return False
                Else
                    If CheckExistUserColumnsnum(stationDT, "Stationname", stationName, "SortName", stationType, returnCode) > 1 Then
                        MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[不良站点名称]：" + stationName + " 在资料库中该站点类型下有重复，请先修改")
                        Return False
                    End If
                End If
            Else
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 [不良站点名称]有空值，请检查后重新上传")
                Return False
            End If


            '不良现象大类别
            Dim strBCodeName As String = DrrR(index)("BCodeName").ToString.Trim
            If strBCodeName <> "" Then
                If CheckExistUserColumnsMore(bCodeNameDT, "CsortName", strBCodeName, "1", "1", "1", "1", returnCode) = False Then
                    MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[不良大类现象]没有在资料库中: '" + strBCodeName + "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 [不良现象大类]有空值,请检查后重新上传")
                Return False
            End If


            '不良现象名称
            Dim codeName As String = DrrR(index)("CodeName").ToString.Trim
            If codeName <> "" Then
                If CheckExistUserColumnsMore(codeNameDT, "CCName", codeName, "1", "1", "1", "1", returnCode) = False Then
                    MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[不良现象名称]没有在资料库中：'" + codeName + "'")
                    Return False
                Else
                    If CheckExistUserColumnsnum(codeNameDT, "CCName", codeName, "CsortName", strBCodeName, returnCode) > 1 Then
                        MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 上传[不良现象名称]：" + codeName + " 在大类代码中有重复，请先修改")
                        Return False
                    End If
                End If
            Else
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 [不良现象名称]有空值，请检查后重新上传")
                Return False
            End If

            '不良现象大类与不良现象名称是否相符
            If CheckExistUserColumnsMore(sameDT, "CCName", codeName, "CsortName", strBCodeName, "1", "1", returnCode) = False Then
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行 [不良现象大类]" + strBCodeName + " 与[不良现象名称]" + codeName + "不符，请检查后重新上传")
                Return False
            End If

            '站点关联不良代码是否存在
            If CheckExistUserColumnsMore(uniDT, "CodeName", codeName, "ECodeName", strBCodeName, "StationName", stationName, returnCode) = True Then
                MessageUtils.ShowError("第[" + (index + 2).ToString + "]行  [不良现象大类]" + strBCodeName + " 与[不良现象名称]" + codeName + " 在[站点名称] " + stationName + "中已存在，请检查后重新上传")
                Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region "检查方法 CheckExistUserColumns"
    '检查站点名称是否重复
    Public Function CheckExistUserColumnsnum(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByVal DBColumns2 As String, ByVal ColumnsValue2 As String, ByRef code As String) As Integer
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}' and {2} = '{3}'", DBColumns, ColumnsValue, DBColumns2, ColumnsValue2))
        If dr.Length > 0 Then
            If dr.Length > 1 Then
                Return dr.Length
            End If
            code = dr(0).ItemArray(0).ToString
            Return dr.Length
        Else
            Return dr.Length
        End If
    End Function

    Public Function CheckExistUserColumnsMore(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByVal DBColumns2 As String, ByVal ColumnsValue2 As String, ByVal DBColumns3 As String, ByVal ColumnsValue3 As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}' and {2}='{3}' and {4}='{5}'", DBColumns, ColumnsValue, DBColumns2, ColumnsValue2, DBColumns3, ColumnsValue3))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "插入SQL文本 GetInsertSQL"
    ''' <summary>
    ''' 插入SQL文本
    ''' </summary>
    ''' <param name="DRS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim strSQL As String = ""
        strSQL = "INSERT INTO [dbo].[m_StationCode_t] ([StationID],[StationName],[ECodeID],[ECodeName],[CodeID],[CodeName],[Factory],[Profit],[UserID],[Intime]) " &
                         "VALUES('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}','{8}',GETDATE ())  "


        'Dim stationSQL As String = " SELECT Stationid,Stationname    FROM m_RStation_t   WHERE usey='Y' "
        Dim stationSQL As String = "select Stationid,SortName,Stationname from " _
                                & "( SELECT  Stationid,Stationname,Stationtype FROM m_RStation_t WHERE usey='Y')A " _
                                & " inner Join " _
                                & " (SELECT SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' ) B " _
                                & " on A.Stationtype=B.SortID"
        Dim stationDT As DataTable = DbOperateUtils.GetDataTable(stationSQL)

        Dim bCodeSQL As String = "SELECT distinct EsortName,CsortName   from m_code_t"
        Dim bCodeDT As DataTable = DbOperateUtils.GetDataTable(bCodeSQL)

        Dim codeSQL As String = "SELECT distinct  CodeID,CCName,CsortName   from m_code_t"
        Dim codeDT As DataTable = DbOperateUtils.GetDataTable(codeSQL)

        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS


            '获取站点编号
            Dim stationdr() As DataRow = stationDT.Select(String.Format("{0} = '{1}' and {2}='{3}' ", "SortName", row(0).ToString(), "stationName", row(1).ToString()))
            Dim stationCode As String = stationdr(0).ItemArray(0).ToString
            '大类名称
            Dim bCodedr() As DataRow = bCodeDT.Select(String.Format("{0} = '{1}'", " CsortName", row(2).ToString()))
            Dim bCode As String = bCodedr(0).ItemArray(0).ToString
            '不良现象名称
            Dim codedr() As DataRow = codeDT.Select(String.Format("{0} = '{1}' and {2} = '{3}'", "CCName", row(3).ToString(), "CsortName", row(2).ToString()))
            Dim code As String = codedr(0).ItemArray(0).ToString
            strInsertSQL.AppendFormat(strSQL, stationCode, row(1).ToString(), bCode, row(2).ToString(), code, row(3).ToString(), factory, profit, userID)
            strInsertSQL.AppendLine()
        Next
        Return strInsertSQL.ToString
    End Function
#End Region

#Region "勾选当前站点不良代码 CheckData"
    ''' <summary>
    ''' 勾选当前站点不良代码
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckData()
        Dim Drcheck As SqlDataReader

        Try
            Drcheck = treeClass.GetDataReader("select CodeID from m_StationCode_t where StationID ='" & station & "'")
            If Drcheck.HasRows Then
                TreeView1.Nodes(0).Checked = True
                ClearAllCheck(TreeView1.Nodes(0))
                While Drcheck.Read()
                    CheckSet(TreeView1.Nodes(0), Drcheck.GetString(0))
                End While
            Else
                TreeView1.Nodes(0).Checked = False
                ClearAllCheck(TreeView1.Nodes(0))
            End If
            treeClass.PubConnection.Close()

        Catch ex As Exception
            Throw ex
        End Try

        Drcheck.Close()
    End Sub
#End Region

#Region "检查清空节点"
    ''' <summary>
    ''' 检查清空节点
    ''' </summary>
    ''' <param name="treeNode"></param>
    ''' <remarks></remarks>
    Private Sub ClearAllCheck(ByVal treeNode As TreeNode)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = False
            If node.Nodes.Count > 0 Then
                Me.ClearAllCheck(node)
            End If
        Next node
    End Sub
#End Region

#Region "勾选选中的"
    ''' <summary>
    ''' 勾选选中的
    ''' </summary>
    ''' <param name="treeNode"></param>
    ''' <param name="nodeString"></param>
    ''' <remarks></remarks>
    Private Sub CheckSet(ByVal treeNode As TreeNode, ByVal nodeString As String)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            If Split(node.Text, "-")(0).ToString = nodeString Then
                node.Checked = True

                'add 父节点也选中
                If Not node.Parent Is Nothing Then
                    If node.Parent.Checked = False Then
                        node.Parent.Checked = True
                    End If
                End If

            End If

            If node.Nodes.Count > 0 Then
                Me.CheckSet(node, nodeString)
            End If
        Next node
    End Sub
#End Region

#Region "二维码打印到Excel"
    ''' <summary>
    ''' 二维码打印到Excel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportToExcel()
        Dim strQRPrefix as String =""
        Try
            Dim book As New Workbook    '创建一个工作簿
            Dim sheet As Worksheet = book.Worksheets(0)   '创建一个sheet
            sheet.Name = "站点不良代码"
            '给单元格加样式
            Dim style As Style = book.Styles(book.Styles.Add()) '标题头
            style.HorizontalAlignment = TextAlignmentType.Center
            style.Font.IsBold = True
            style.VerticalAlignment = TextAlignmentType.Top
            style.Font.Size = 26

            Dim style2 As Style = book.Styles(book.Styles.Add()) '文本
            style2.Font.Size = 13
            style2.VerticalAlignment = TextAlignmentType.Top
            style2.IsTextWrapped = True
            style2.HorizontalAlignment = TextAlignmentType.Center

            Dim style3 As Style = book.Styles(book.Styles.Add()) '第二行
            style3.Font.Size = 18
            style3.VerticalAlignment = TextAlignmentType.Top
            style3.HorizontalAlignment = TextAlignmentType.Center

            Dim cells As Cells = sheet.Cells
            cells.SetRowHeight(0, 45)  '设置标题行高

            '设置标题行
            sheet.Cells(0, 0).PutValue("站点不良代码")
            sheet.Cells(1, 0).PutValue("站点编号：" & station & "         " & "站点名称：" & stationName)
            sheet.Cells(0, 0).SetStyle(style)
            sheet.Cells(1, 0).SetStyle(style3)
            sheet.Cells.SetRowHeight(1, 37)
            cells.Merge(0, 0, 1, 5)  '合并单元格
            cells.Merge(1, 0, 1, 5)

            Select Case VbCommClass.VbCommClass.Factory

                Case "LX81"
                    strQRPrefix=""
                Case Else
                    strQRPrefix = "SFCSNG#"
            End Select

            Dim strSQL As String = "select distinct CodeID,CodeName from m_StationCode_t  where StationID ='" & station & "' "
            Dim dt As DataTable = conn.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim barcodeInfo As String = strQRPrefix & dt.Rows(i)("CodeID").ToString

                    sheet.Cells.SetRowHeight(2 * Fix(i / 5) + 2, 75)
                    sheet.Cells.SetRowHeight(2 * Fix(i / 5) + 3, 49)
                    sheet.Cells.SetColumnWidth(i Mod 5, 16)

                    Dim index As Integer = sheet.Pictures.Add(2 * Fix(i / 5) + 2, i Mod 5, Print_Qrcode(barcodeInfo.Trim))
                    Dim pic As Aspose.Cells.Drawing.Picture = sheet.Pictures(index)
                    pic.Placement = Drawing.PlacementType.Move

                    sheet.Cells(2 * Fix(i / 5) + 3, i Mod 5).SetStyle(style2)
                    sheet.Cells(2 * Fix(i / 5) + 3, i Mod 5).PutValue(dt.Rows(i)("CodeID").ToString & vbNewLine & dt.Rows(i)("CodeName").ToString)
                Next
            Else
                MessageUtils.ShowInformation("当前站点没有要打印的不良代码！")
                Return
            End If

            '保存文件路径
            Dim strDirectory As String = "C:\MesExport\"
            If Not Directory.Exists(strDirectory) Then
                Directory.CreateDirectory(strDirectory)
            End If
            strDirectory = strDirectory + "站点不良代码（打印）.xls"
            book.Save(strDirectory)
            MessageUtils.ShowInformation(String.Format("文件打印成功,打印位置：{0}!", strDirectory))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationNg", "ImportToExcel", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "生成二维码图片"
    ''' <summary>
    ''' 生成二维码图片
    ''' </summary>
    ''' <param name="QrBarcodeInfo">二维码扫描出来信息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Print_Qrcode(ByVal QrBarcodeInfo As String) As Stream
        Dim qrCode As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
        qrCode.QRQuitZone = 0
        Dim bitmap As Bitmap = New Bitmap(110, 93)

        Dim gp As Graphics = Graphics.FromImage(bitmap) '取图片作为 Graphics
        'gp.Clear(Color.Transparent)
        gp.FillRectangle(Brushes.White, New Rectangle(0, 0, 140, 140)) '把b1涂成白色
        'qrCode.QRWriteBar(QrBarcodeInfo, 0, 0, 2, gp)
        qrCode.WriteBar(QrBarcodeInfo, 15, 3, bitmap.Width - 20, bitmap.Width - 20, gp)
        gp.Dispose()

        Dim img As Image = New Bitmap(bitmap)
        Dim stream As Stream = New MemoryStream()
        img.Save(stream, ImageFormat.Bmp)
        'stream.Close()
        Return stream
    End Function
#End Region
#End Region
End Class