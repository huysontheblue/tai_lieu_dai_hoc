
Imports System.IO
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports Aspose.Cells
Imports System.Text
Imports System.Net.Mail
Imports System.Data.SqlClient
Imports MainFrame
Imports SysBasicClass
''' <summary>
''' 修改者： 黄广都
''' 修改日： 2016/11/17
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>在线SOP制作</remarks>
Public Class FrmOnlineSop

#Region "字段、属性"
    Private m_ChkboxAll As New CheckBox

    Dim IsQueryOld = False

    ''SOP模板文件

    'Private _SopTemplateFile As String = "D:\OnlineSop\Template\OnlineSop_Template.xls"
    'Private _SopTemplateImportantFile As String = "D:\OnlineSop\Template\OnlineSop_Template_Important.xls"
    ''SOP清单
    'Private _SopTemplateListFile As String = "D:\OnlineSop\Template\OnlineSopList_Template.xls"
    'Private _SketchDirector As String = "D:\OnlineSop\Template\SketchImg\"
    '----------------------------正式------------------------------------------------
    Private _SopTemplateFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSop_Template.xls"
    Private _SopTemplateImportantFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSop_Template_Important.xls"
    Private _SopTemplateListFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSopList_Template.xls"
    Private _SketchDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\SketchImg\"


    '复制行ID数组
    Private CopySopRowID() As String = Nothing
    '(制作中(N)、待审核(S)、待生产审核(P)、待品管审核(Q)、待核准(A)、已作废(D)、已生效(Y))
    Private Enum SopType
        ''' <summary>
        ''' 制作中
        ''' </summary>
        ''' <remarks></remarks>
        Make = 0
        ''' <summary>
        ''' 待审核
        ''' </summary>
        ''' <remarks></remarks>
        Verify = 1
        ''' <summary>
        ''' 待生产审核
        ''' </summary>
        ''' <remarks></remarks>
        Prod = 2
        ''' <summary>
        ''' 待品管审核
        ''' </summary>
        ''' <remarks></remarks>
        QC = 3
        ''' <summary>
        ''' 待核准
        ''' </summary>
        ''' <remarks></remarks>
        Approval = 4
        ''' <summary>
        ''' DCC审核
        ''' </summary>
        ''' <remarks></remarks>
        DCC = 5
        ''' <summary>
        ''' 已生效
        ''' </summary>
        ''' <remarks></remarks>
        Finish = 6
    End Enum

#Region "左边树DataTable"
    Private _LeftTreeDataTable As DataTable
    Public Property LeftTreeDataTable() As DataTable
        Get
            Return _LeftTreeDataTable
        End Get

        Set(ByVal Value As DataTable)
            _LeftTreeDataTable = Value
        End Set
    End Property
#End Region

#Region "打印、导出相关DataTable"
    Private _MainDataTable As DataTable
    Public Property MainDataTable() As DataTable
        Get
            _MainDataTable.TableName = "MainDt"
            Return _MainDataTable
        End Get

        Set(ByVal Value As DataTable)
            _MainDataTable = Value
        End Set
    End Property

    Private _PartDataTable As DataTable
    Public Property PartDataTable() As DataTable
        Get
            _PartDataTable.TableName = "PartDt"
            Return _PartDataTable
        End Get

        Set(ByVal Value As DataTable)
            _PartDataTable = Value
        End Set
    End Property

    Private _EquimentDataTable As DataTable
    Public Property EquimentDataTable() As DataTable
        Get
            _EquimentDataTable.TableName = "EquiDt"
            Return _EquimentDataTable
        End Get

        Set(ByVal Value As DataTable)
            _EquimentDataTable = Value
        End Set
    End Property

    Private _PictureDataTable As DataTable
    Public Property PictureDataTable() As DataTable
        Get
            _PictureDataTable.TableName = "PicDt"
            Return _PictureDataTable
        End Get

        Set(ByVal Value As DataTable)
            _PictureDataTable = Value
        End Set
    End Property

    Private _ItemDataTable As DataTable
    Public Property ItemDataTable() As DataTable
        Get
            _ItemDataTable.TableName = "Item"
            Return _ItemDataTable
        End Get

        Set(ByVal Value As DataTable)
            _ItemDataTable = Value
        End Set
    End Property

    '是否开启权限验证
    Private _StartRight As Boolean
    Public Property StartRight() As Boolean
        Get
            Return _StartRight
        End Get

        Set(ByVal Value As Boolean)
            _StartRight = Value
        End Set
    End Property
#End Region
  
#Region "左边树焦点面板索引"

    Private _SideActivate As SopType
    Private Property SideActivate() As SopType
        Get
            Return _SideActivate
        End Get

        Set(ByVal Value As SopType)
            _SideActivate = Value
        End Set
    End Property
#End Region


#End Region

#Region "窗体事件、左侧菜单"
    ''' <summary>
    ''' 窗体加载
    ''' </summary>
    Private Sub FrmOnlineSop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            'ERigth.GetContextMenuRight(Me, Me.ContextMenuHeader)
            'ERigth.GetContextMenuRight(Me, Me.ContextMenuBody)
            '是否开启权限验证(打印、导出、审批)
            Me._StartRight = True
            '绑定右键菜单
            dgvSopHeader.ContextMenuStrip = Me.ContextMenuHeader
            '绑定右键菜单
            dgvSopBody.ContextMenuStrip = Me.ContextMenuBody
            '设置打印、导出权限
            SetPrintRight()
            '菜单权限
            SetMenuRight()

            '加载树菜单
            LoadSideBarTree(SopType.Make)
            '加载数据-单头
            LoadOnlineSopHeader()
            '加载数据-单身
            LoadOnlineSopBody()




        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "FrmOnlineSop_Load", "sys")
        End Try
    End Sub



    ''' <summary>
    ''' 筛选
    ''' </summary>
    Private Sub txtSearch_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtSearch.ButtonCustomClick
        Try
            Dim str As String = txtSearch.Text.Trim

            If String.IsNullOrEmpty(str) Then
                LoadSideBarTree(SopType.Make)
            Else
                BrushSideBarTree()
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "txtSearch_KeyDown", "sys")
        End Try

    End Sub
    ''' <summary>
    ''' 已生效
    ''' </summary>
    Private Sub sbPanelFinish_Click(sender As Object, e As EventArgs) Handles sbPanelFinish.Click
        LoadSideBarTree(SopType.Finish)
    End Sub
    ''' <summary>
    ''' 待DCC审核
    ''' </summary>
    Private Sub sbPanelDCC_Click(sender As Object, e As EventArgs) Handles sbPanelDCC.Click
        LoadSideBarTree(SopType.DCC)
    End Sub
    ''' <summary>
    ''' 待核准
    ''' </summary>
    Private Sub sbPanelApproval_Click(sender As Object, e As EventArgs) Handles sbPanelApproval.Click
        LoadSideBarTree(SopType.Approval)
    End Sub

    ''' <summary>
    ''' 待品质审核
    ''' </summary>
    Private Sub sbPanelQC_Click(sender As Object, e As EventArgs) Handles sbPanelQC.Click
        LoadSideBarTree(SopType.QC)
    End Sub

    ''' <summary>
    ''' 待生产审批
    ''' </summary>
    Private Sub sbPanelProd_Click(sender As Object, e As EventArgs) Handles sbPanelProd.Click
        LoadSideBarTree(SopType.Prod)
    End Sub

    ''' <summary>
    ''' 待确认
    ''' </summary>
    Private Sub sbPanelVerify_Click(sender As Object, e As EventArgs) Handles sbPanelVerify.Click
        LoadSideBarTree(SopType.Verify)
    End Sub

    ''' <summary>
    ''' 制作中
    ''' </summary>
    Private Sub sbPanelMake_Click(sender As Object, e As EventArgs) Handles sbPanelMake.Click
        LoadSideBarTree(SopType.Make)
    End Sub

    Dim _HeaderTable As DataTable

    ''' <summary>
    ''' 左边菜单选择
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sbStatus_ItemClick(sender As Object, e As EventArgs) Handles sbStatus.ItemClick
        Try
            If TypeOf sender Is ButtonItem Then
                Dim SelectedItem As ButtonItem = CType(sender, ButtonItem)
                If SelectedItem.Tag.ToString() <> "" Then
                    '清除样式
                    For Each item As ButtonItem In SelectedItem.Parent.SubItems
                        item.ForeColor = Color.Black
                        item.FontBold = False
                    Next
                    '添加样式()
                    SelectedItem.ForeColor = Color.Blue
                    SelectedItem.FontBold = True

                    Dim _docId As String
                    If CType(SelectedItem.Tag, ArrayList).Count < 1 Then
                        Exit Sub
                    End If
                    _docId = CStr(CType(SelectedItem.Tag, ArrayList).Item(1))
                    Dim _RowIndex As Integer = 0

                    '-------------------------------------------------------------

                    Dim _CopyHeaderTable As DataTable
                    ' _HeaderTable = CType(Me.dgvSopHeader.DataSource, DataTable)
                    Me.dgvSopHeader.ClearSelection()

                    _CopyHeaderTable = _HeaderTable.Copy()
                    Dim dvHeard() As DataRow

                    Dim drRow As DataRow
                    dvHeard = _CopyHeaderTable.Select("DocId='" & _docId & "'")

                    'add by 马跃平 2018-07-25
                    '因为_HeaderTable是页面记载的流程状态,不是最新的
                    If dvHeard.Length > 0 Then
                        Dim sql = "select case when a.Status='N' then N'制作中' " & vbCrLf &
                        "when a.Status='S' then N'待审核'" & vbCrLf &
                        "when a.Status='P' then N'待生产审核'" & vbCrLf &
                        "when a.Status='Q' then N'待品管审核'" & vbCrLf &
                        "when a.Status='A' then N'待核准'" & vbCrLf &
                        "when a.Status='C' then N'待DCC审核'" & vbCrLf &
                        "when a.Status='D' then N'已作废' else N'已生效' end Status" & vbCrLf &
                        "from m_OnlineSop_t a where DocId='" & _docId & "'"
                        dvHeard(0)("Status") = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
                    End If
                    'end

                    Dim _Irow As Integer = 0
                    For Each dr As DataRow In _HeaderTable.Rows

                        If dr("DocId").ToString = _docId Then
                            _HeaderTable.Rows.RemoveAt(_Irow)
                            '_HeaderTable.Rows.InsertAt(dvHeard(0), 0)
                            drRow = _HeaderTable.NewRow

                            For index = 0 To _HeaderTable.Columns.Count - 1
                                drRow(index) = dvHeard(0)(index)
                            Next

                            _HeaderTable.Rows.InsertAt(drRow, 0)

                            Exit For
                        End If
                        _Irow = _Irow + 1
                    Next

                    Me.dgvSopHeader.DataSource = _HeaderTable
                    Me.dgvSopHeader.ClearSelection()
                    Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, 0).Selected = True



                    LoadOnlineSopBody()


                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "SideBar1_ItemClick", "sys")
        End Try
    End Sub


#End Region

#Region "菜单事件"
    ''' <summary>
    ''' 复制SOP
    ''' </summary>
    Private Sub btnCopySop_Click(sender As Object, e As EventArgs) Handles btnCopySop.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                Dim _DocId As String
                Dim _SopName As String
                Dim _VerNo As String
                Dim _Shape As String
                _DocId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
                _VerNo = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Version).Value.ToString
                _Shape = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Shape).Value.ToString
                Dim frmSopCopy As New FrmOnlineSopCopy(_DocId, _SopName, _VerNo, _Shape)
                If frmSopCopy.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '刷新单头
                    LoadOnlineSopHeader()
                    '加载数据-单身
                    LoadOnlineSopBody()
                    '重新设置Tree数据
                    SetSideBarData()
                    '加载tree
                    LoadSideBarTree(_SideActivate)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnCopySop_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 在线打印
    ''' </summary>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.tslMsg.Text = "正在打印,请耐心等待..."
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim docIdList As List(Of String) = New List(Of String)
            Dim status As String = Nothing
            Dim docId As String = Nothing
            Dim _SopName As String = Nothing

            If Me.dgvSopHeader.CurrentRow Is Nothing Then Exit Sub
           

            Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, Me.dgvSopHeader.CurrentRow.Index).Selected = True

            For Each Row As DataGridViewRow In Me.dgvSopHeader.Rows
                If Not Row.Cells(0).Value Is Nothing Then
                    If Row.Cells(0).Value.ToString = "True" Then
                        _SopName = Row.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

                        status = Row.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                        docId = Row.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString

                        If status <> "已生效" Then
                            MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 非已生效的SOP,不允许打印！")
                            Exit Sub
                        End If
                        docIdList.Add(docId)
                    End If
                End If
            Next
            '是否打印整个SOP
            If docIdList.Count > 0 Then
                '导出并打印
                ExprotOrPrintSop(docIdList, True)
            Else
                '单独打印单身工站SOP
                If Me.dgvSopHeader.RowCount > 0 Then
                    ExprotOrPrintSopBody(True, Nothing)
                End If
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try
        Me.tslMsg.Text = ""
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' 审核
    ''' </summary>
    Private Sub btnAudit_Click(sender As Object, e As EventArgs) Handles btnAudit.Click
        Try
            '是否多选审批
            Dim _IsMoreSelect As Boolean = False

            Dim _CurrRowIndex As Integer = 0
            If Me.dgvSopHeader.RowCount < 1 OrElse Me.dgvSopHeader.CurrentRow Is Nothing Then Exit Sub

            '多选审批
            MoreSopApproval()

            Me.dgvSopHeader.ClearSelection()
            Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, _CurrRowIndex).Selected = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnAudit_Click", "sys")
        End Try

    End Sub


    ''' <summary>
    ''' 刷新
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'If Me.dgvSopHeader.CurrentRow Is Nothing AndAlso Me.dgvSopHeader.Rows.Count < 1 Then Exit Sub
        Me.IsQueryOld = False
        LoadOnlineSopHeader()
        LoadOnlineSopBody()
        '加载树菜单
        LoadSideBarTree(SopType.Make)
    End Sub


 
    ''' <summary>
    ''' 导出SOP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportSop_Click(sender As Object, e As EventArgs) Handles btnExportSop.Click
        Me.tslMsg.Text = "正在导出....."
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim docIdList As List(Of String) = New List(Of String)
            Dim status As String = Nothing
            Dim docId As String = Nothing
            Dim _SopName As String = Nothing

            If Me.dgvSopHeader.CurrentRow Is Nothing Then Exit Sub
            Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.DocId, Me.dgvSopHeader.CurrentRow.Index).Selected = True

            For Each Row As DataGridViewRow In Me.dgvSopHeader.Rows
                If Not Row.Cells(0).Value Is Nothing Then
                    If Row.Cells(0).Value.ToString = "True" Then
                        _SopName = Row.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

                        status = Row.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                        docId = Row.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString

                        If status <> "已生效" Then
                            MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 非已生效的SOP,不允许导出！")
                            Exit Sub
                        End If
                        docIdList.Add(docId)
                    End If
                End If
            Next
            '是否导出整个SOP
            If docIdList.Count > 0 Then
                If ExprotOrPrintSop(docIdList, False) = True Then
                    MessageBox.Show("SOP文件导出成功,导出位置：c:\MesExport文件夹中", " 导出SOP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                '单独打印单身工站SOP
                If ExprotOrPrintSopBody(False) = True Then
                    MessageBox.Show("SOP文件导出成功,导出位置：c:\MesExport文件夹中", " 导出SOP", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

           
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try
        Me.tslMsg.Text = ""
        Me.Cursor = Cursors.Default

    End Sub


    ''' <summary>
    ''' 导出单头
    ''' </summary>
    Private Sub btnExportHeader_Click(sender As Object, e As EventArgs) Handles btnExportHeader.Click
        Dim colName As String = Nothing
        For index = 1 To Me.dgvSopHeader.Columns.Count - 1
            colName &= "," & Me.dgvSopHeader.Columns(index).HeaderText
        Next

        colName = colName.Substring(1, colName.Length - 1)
        '导出
        LoadDataToExcel(Me.dgvSopHeader, "在线SOP单头", colName)
    End Sub

    ''' <summary>
    ''' 邮件设置
    ''' </summary>
    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim frmEmail As New FrmOnlineSopEMail()
        frmEmail.Show()
    End Sub
    ''' <summary>
    ''' 退出
    ''' </summary>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "单头-右键菜单事件"
    ''' <summary>
    ''' 查询
    ''' </summary>
    Private Sub tsmiHeaderSearch_Click(sender As Object, e As EventArgs) Handles tsmiHeaderSearch.Click
        Try
            Dim frmQuery As New FrmOnlineSopQuery()

            If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim dt As New DataTable
                dt = CType(Me.dgvSopBody.DataSource, DataTable)
                dt.Rows.Clear()
                Me.dgvSopBody.DataSource = dt
                '刷新
                LoadOnlineSopHeader(frmQuery.QueryWhere, frmQuery.IsQueryOld)
                Me.IsQueryOld = frmQuery.IsQueryOld
                '加载数据-单身
                LoadOnlineSopBody(frmQuery.IsQueryOld)

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderAdd_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 新增
    ''' </summary>
    Private Sub tsmiHeaderAdd_Click(sender As Object, e As EventArgs) Handles tsmiHeaderAdd.Click
        Try

            If GetMakeRight() = False Then
                MessageUtils.ShowWarning("对不起，您没有制作SOP的权限!")
                Exit Sub
            End If

            Dim frmHeader As New FrmOnlineSopNew("Add", Nothing)
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then

                '更新单头
                LoadOnlineSopHeader()
                '更新单身
                LoadOnlineSopBody()
                '重新设置Tree数据
                SetSideBarData()
                '加载tree
                LoadSideBarTree(_SideActivate)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderAdd_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 复制单元格
    ''' </summary>
    Private Sub tsmiHeaderCopy_Click(sender As Object, e As EventArgs) Handles tsmiHeaderCopy.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                Dim Selected As String = dgvSopHeader.CurrentCell.Value.ToString
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderCopy_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 作废:等MES全部测试OK后，作废整份SOP权限只给到一个人即可。
    ''' </summary>
    Private Sub tsmiHeaderDelete_Click(sender As Object, e As EventArgs) Handles tsmiHeaderDelete.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                Dim status As String
                '文件编码
                Dim docID As String
                Dim _SopName As String
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

                status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                If status <> "制作中" Then
                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 非制作中的SOP,不允许作废！")
                    Exit Sub
                End If
                '2017-04-28注释掉，不限制
                'If GetConfirmInvRight() = False Then
                '    MessageUtils.ShowWarning("SOP名称:" & _SopName & ", 不允许作废其他人制作的SOP！")
                '    Exit Sub
                'End If
                If (MessageUtils.ShowConfirm("确定要作废吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                    '流入下一状态
                    FlowNextStatus(docID, "D")

                    '刷新
                    LoadOnlineSopHeader()

                    '刷新左边树
                    LoadSideBarTree(Me.SideActivate)

                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderDelete_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 修改SOP
    ''' </summary>
    Private Sub tsmiHeaderModify_Click(sender As Object, e As EventArgs) Handles tsmiHeaderModify.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                Dim status As String = "", docId As String, _SopName As String
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

                status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                If status <> "制作中" AndAlso status <> "已生效" Then
                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 审核中的SOP,不允许修改！")
                    Exit Sub
                End If

                '2017-04-28 调整为不限制仅制作人才能修改，其它人也可以
                'If GetConfirmInvRight() = False Then

                '    MessageUtils.ShowWarning("不允许修改其他人制作的SOP！")
                '    Exit Sub
                'End If
                Dim frmHeader As New FrmOnlineSopNew("Modify", CType(Me.dgvSopHeader.CurrentRow, DataGridViewRow))
                If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If status = "已生效" Then
                        '下一状态
                        FlowNextStatus(docId, "N")
                        '邮件提醒
                        SeedMailNoticeToMsg(docId, _SopName, "N", "制作中")
                    End If

                    '单头
                    LoadOnlineSopHeader()
                    '刷新单身
                    LoadOnlineSopBody()
                    '刷新左边树
                    LoadSideBarTree(Me.SideActivate)

                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderModify_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 驳回：返回到制作中
    ''' </summary>
    Private Sub tsmiHeaderReject_Click(sender As Object, e As EventArgs) Handles tsmiHeaderReject.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                '文件编码
                Dim docID As String
                Dim _Status As String
                Dim _SopName As String
                docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                If Me.dgvSopBody.RowCount < 1 Then
                    MessageUtils.ShowInformation("文件编码:" & docID & ",尚未添加SOP单身资料，请添加后再试！")
                    Exit Sub
                End If
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
                _Status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                If _Status = "制作中" OrElse _Status = "已生效" Then
                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", " & _Status & "中,不允许驳回！")
                    Exit Sub
                End If

                'Dim Receiver As String = String.Empty,strReason As String =""
                'While (1 = 1)
                '    strReason = InputBox("请输入原因", "提示")

                '    If CheckScanUser(Receiver) = True Then
                '        Exit While
                '    End If
                'End While


                Dim frmRemark As New FrmOnlineRemark(docID, "驳回原因:")
                If frmRemark.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' LoadOnlineSopBody()
                Else
                    MessageUtils.ShowError("请填写原因！")
                    Exit Sub
                End If

                ''验证是否有审核权限
                'If GetSignRight(_Status) = False Then
                '    MessageUtils.ShowWarning("对不起，您没有[" & _SopName & "]SOP的驳回权限!")
                '    Exit Sub
                'End If

                If (MessageUtils.ShowConfirm("确定要驳回吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                    '下一状态
                    FlowNextStatus(docID, "N")
                    '更新单头
                    LoadOnlineSopHeader()
                    '重新设置Tree数据
                    SetSideBarData()
                    '刷新左边树
                    LoadSideBarTree(Me.SideActivate)

                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "N", "制作中")
                    MessageUtils.ShowInformation("驳回成功！")
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderDelete_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 撤回，制作人可以撤回正在审核中的SOP
    ''' </summary>
    Private Sub tsmiHeaderRetract_Click(sender As Object, e As EventArgs) Handles tsmiHeaderRetract.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                '文件编码
                Dim docID As String
                Dim _SopName As String
                Dim _Status As String
                Dim _CurrRowIndex As Integer = 0
                _CurrRowIndex = Me.dgvSopHeader.CurrentRow.Index
                docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
                _Status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString

                If _Status = "制作中" Then
                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 未开始审核撤回无效！")
                    Exit Sub
                End If
                ''检查是否自己创建的SOP
                'If GetConfirmInvRight() = False Then
                '    MessageUtils.ShowWarning("SOP名称:" & _SopName & ", 不允许撤回其他人制作的SOP！")
                '    Exit Sub
                'End If


                Dim frmRemark As New FrmOnlineRemark(docID, "撤回原因:")
                If frmRemark.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' LoadOnlineSopBody()
                Else
                    MessageUtils.ShowError("请填写原因！")
                    Exit Sub
                End If

                If (MessageUtils.ShowConfirm("确定要撤回吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                    '更新状态,撤回后进入制作中
                    FlowNextStatus(docID, "N")

                    '加载单头
                    LoadOnlineSopHeader()
                    '重新设置Tree数据
                    SetSideBarData()
                    '加载tree
                    LoadSideBarTree(_SideActivate)
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "N", "制作中")

                    Me.dgvSopHeader.ClearSelection()
                    Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, _CurrRowIndex).Selected = True
                    MessageUtils.ShowInformation("撤回成功！")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiHeaderRetract_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 确认
    ''' </summary>
    Private Sub tsmiHeaderComfirm_Click(sender As Object, e As EventArgs) Handles tsmiHeaderComfirm.Click
        Try
            If Not dgvSopHeader.CurrentCell Is Nothing Then
                '文件编码
                Dim docID As String
                Dim _SopName As String
                Dim _Status As String
                Dim _CurrRowIndex As Integer = 0
                _CurrRowIndex = Me.dgvSopHeader.CurrentRow.Index
                docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

                If Me.dgvSopBody.RowCount < 1 Then
                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 尚未完善SOP工站资料，请完善后再试！")
                    Exit Sub
                End If


                _Status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString

                If _Status <> "制作中" Then

                    MessageUtils.ShowInformation("SOP名称:" & _SopName & ", 非制作中,不允许确认！")
                    Exit Sub
                End If
                'If GetConfirmInvRight() = False Then
                '    MessageUtils.ShowWarning("SOP名称:" & _SopName & ", 不允许确认其他人制作的SOP！")
                '    Exit Sub
                'End If
                '更新状态

                ' 贺声平 2018-09-04 提出需求  请帮忙将在点击确认时，后台自动判断是否存在两个大版本，若存在，不准予确认，并提示存在两个大版本的红字 add by马跃平
                Dim sql = "select t.DocId,count(1) 'ExistMoreVersion' from " & vbCrLf &
                         "(" & vbCrLf &
                        "select distinct  DocId, substring(VerNo,1,1) VerNo " & vbCrLf &
                        "from m_OnlineSopItem_t" & vbCrLf &
                        "where DocId in (select DocId from  m_OnlineSop_t where [Status]<>'D')" & vbCrLf &
                        "group by DocId,substring(VerNo,1,1)" & vbCrLf &
                        ") t where t.DocId='" & docID & "'  group by t.DocId" & vbCrLf &
                        "having count(1)>1"
                If DbOperateUtils.GetDataTable(sql).Rows.Count > 0 Then
                    MessageUtils.ShowError("存在两个大版本,确认失败!")
                    Exit Sub
                End If

                Dim CreateUserId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.CreateUserId).Value.ToString

                Dim bFlag As Boolean = CustomDetermination(CreateUserId, docID, _SopName)
                '错误退出 
                If bFlag = False Then Exit Sub

                '加载单头
                LoadOnlineSopHeader()
                '重新设置Tree数据
                SetSideBarData()
                '加载tree
                LoadSideBarTree(_SideActivate)
                Me.dgvSopHeader.ClearSelection()
                Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, _CurrRowIndex).Selected = True
                MessageUtils.ShowInformation("确认成功！")
            End If

        Catch ex As Exception
            MessageUtils.ShowError("出现异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 自定义审核
    ''' add by 马跃平 2018-07-24
    ''' </summary>
    ''' <param name="CreateUserId">建立人工号</param>
    ''' <param name="docID">文件编码</param>
    ''' <param name="_SopName">SOP名称</param>
    ''' <param name="NextStatus">下一个状态</param>
    ''' <remarks></remarks>
    Private Sub CustomCheck(ByVal CreateUserId As String, ByVal docID As String, ByVal _SopName As String, ByVal NextStatus As String)
        Dim sql = New StringBuilder()
        Dim o_strTempUserID As String = ""

        Select Case NextStatus
            Case "Q"
                Dim CurrentStatus = NextStatus
                '待审->待品管审核
                'Dim UserName = getUser(IsAutoCheck(CreateUserId, "S").Rows(0)(1).ToString()).Rows(0)("UserName")
                Dim UserName = VbCommClass.VbCommClass.UseName
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',VerifyUserName=N'{1}',VerifyTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                '品管自动审核
                If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                    CurrentStatus = "P"
                    UserName = getUser(IsAutoCheck(CreateUserId, "Q").Rows(0)(1).ToString()).Rows(0)("UserName")
                    sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',QCUserName=N'{1}',QCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                    '生产自动审核
                    If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                        CurrentStatus = "A"
                        UserName = getUser(IsAutoCheck(CreateUserId, "P").Rows(0)(1).ToString()).Rows(0)("UserName")
                        sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ProdUserName=N'{1}',ProdTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                        '自动核准
                        If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                            CurrentStatus = "C"
                            o_strTempUserID = IsAutoCheck(CreateUserId, "A").Rows(0)(1).ToString
                            Dim o_dt As DataTable = getUser(o_strTempUserID)
                            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                                UserName = getUser(o_strTempUserID).Rows(0)("UserName")
                            Else
                                MessageUtils.ShowError("获取工号：【" & o_strTempUserID & "】的信息失败，请在MES维护相关的信息！")
                                Exit Sub
                            End If

                            sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                            'DCC自动核准
                            If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                                CurrentStatus = "Y"
                                UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                                '已生效状态:
                                Dim Falg As Integer = 0
                                Dim para(4) As SqlParameter
                                Dim parameters() As SqlParameter = {
                                    New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                                    New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                                    New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                                    New SqlParameter("@Falg", SqlDbType.Int, 20)
                                }
                                parameters(0).Value = docID
                                parameters(1).Value = UserName
                                parameters(2).Value = "Y"
                                parameters(3).Value = Falg
                                parameters(3).Direction = ParameterDirection.Output
                                DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                            Else
                                '邮件提醒
                                SeedMailNoticeToMsg(docID, _SopName, "C", "待审核")
                            End If
                        Else
                            '邮件提醒
                            SeedMailNoticeToMsg(docID, _SopName, "A", "待审核")
                        End If
                        Else
                            '邮件提醒
                            SeedMailNoticeToMsg(docID, _SopName, "P", "待审核")
                        End If
                Else
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "Q", "待审核")
                End If
            Case "P"
                Dim CurrentStatus = NextStatus
                '品管审核->生产审核
                Dim UserName = getUser(IsAutoCheck(CreateUserId, "Q").Rows(0)(1).ToString()).Rows(0)("UserName")
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',QCUserName=N'{1}',QCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                '生产自动审核
                If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                    CurrentStatus = "A"
                    UserName = getUser(IsAutoCheck(CreateUserId, "P").Rows(0)(1).ToString()).Rows(0)("UserName")
                    sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ProdUserName=N'{1}',ProdTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                    '自动核准
                    If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                        CurrentStatus = "C"
                        UserName = getUser(IsAutoCheck(CreateUserId, "A").Rows(0)(1).ToString()).Rows(0)("UserName")
                        sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                        'DCC自动核准
                        If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                            CurrentStatus = "Y"
                            UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                            sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                            '已生效状态:
                            Dim Falg As Integer = 0
                            Dim para(4) As SqlParameter
                            Dim parameters() As SqlParameter = {
                                New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                                New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                                New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                                New SqlParameter("@Falg", SqlDbType.Int, 20)
                            }
                            parameters(0).Value = docID
                            parameters(1).Value = UserName
                            parameters(2).Value = "Y"
                            parameters(3).Value = Falg
                            parameters(3).Direction = ParameterDirection.Output
                            DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                        Else
                            '邮件提醒
                            SeedMailNoticeToMsg(docID, _SopName, "C", "待审核")
                        End If
                    Else
                        '邮件提醒
                        SeedMailNoticeToMsg(docID, _SopName, "A", "待审核")
                    End If
                Else
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "P", "待审核")
                End If
            Case "A"
                Dim CurrentStatus = NextStatus
                Dim UserName = getUser(IsAutoCheck(CreateUserId, "P").Rows(0)(1).ToString()).Rows(0)("UserName")
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ProdUserName=N'{1}',ProdTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                '自动核准
                If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                    CurrentStatus = "C"
                    UserName = getUser(IsAutoCheck(CreateUserId, "A").Rows(0)(1).ToString()).Rows(0)("UserName")
                    sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                    'DCC自动核准
                    If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                        CurrentStatus = "Y"
                        UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                        sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                        '已生效状态:
                        Dim Falg As Integer = 0
                        Dim para(4) As SqlParameter
                        Dim parameters() As SqlParameter = {
                            New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                            New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                            New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                            New SqlParameter("@Falg", SqlDbType.Int, 20)
                        }
                        parameters(0).Value = docID
                        parameters(1).Value = UserName
                        parameters(2).Value = "Y"
                        parameters(3).Value = Falg
                        parameters(3).Direction = ParameterDirection.Output
                        DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                    Else
                        '邮件提醒
                        SeedMailNoticeToMsg(docID, _SopName, "C", "待审核")
                    End If
                Else
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "A", "待审核")
                End If
            Case "C"
                Dim CurrentStatus = NextStatus
                Dim UserName = getUser(IsAutoCheck(CreateUserId, "A").Rows(0)(1).ToString()).Rows(0)("UserName")
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                'DCC自动核准
                If Convert.ToBoolean(IsAutoCheck(CreateUserId, CurrentStatus).Rows(0)(0)) = True Then
                    CurrentStatus = "Y"
                    UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                    sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                    '已生效状态:
                    Dim Falg As Integer = 0
                    Dim para(4) As SqlParameter
                    Dim parameters() As SqlParameter = {
                        New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                        New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                        New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                        New SqlParameter("@Falg", SqlDbType.Int, 20)
                    }
                    parameters(0).Value = docID
                    parameters(1).Value = UserName
                    parameters(2).Value = "Y"
                    parameters(3).Value = Falg
                    parameters(3).Direction = ParameterDirection.Output
                    DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                Else
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "C", "待审核")
                End If
            Case "Y"
                Dim CurrentStatus = NextStatus
                Dim UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", CurrentStatus, UserName, docID))
                '已生效状态:
                Dim Falg As Integer = 0
                Dim para(4) As SqlParameter
                Dim parameters() As SqlParameter = {
                    New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                    New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                    New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                    New SqlParameter("@Falg", SqlDbType.Int, 20)
                }
                parameters(0).Value = docID
                parameters(1).Value = UserName
                parameters(2).Value = "Y"
                parameters(3).Value = Falg
                parameters(3).Direction = ParameterDirection.Output
                DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
        End Select
        If String.IsNullOrEmpty(sql.ToString()) = False Then
            DbOperateUtils.ExecSQL(sql.ToString())
        End If
    End Sub

    ''' <summary>
    ''' 自定义确定,判断其中的流程是否包含自动签核
    ''' add by 马跃平 2018-07-24
    ''' </summary>
    ''' <param name="CreateUserId">建立人工号</param>
    ''' <param name="docID">文件编码</param>
    ''' <param name="_SopName">SOP名称</param>
    ''' <remarks></remarks>
    Private Function CustomDetermination(ByVal CreateUserId As String, ByVal docID As String, ByVal _SopName As String) As Boolean

        Dim Status = "S"
        Dim sql = New StringBuilder()
        Dim dt As DataTable = IsAutoCheck(CreateUserId, Status)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("用户:" & VbCommClass.VbCommClass.UseId & "没有自动签核权限,请确认！")
            Return False
        End If

        Dim sautocheck As String = dt.Rows(0)(0).ToString

        If Convert.ToBoolean(sautocheck) = True Then '自动审核
            Status = "Q"
            Dim UserName = getUser(IsAutoCheck(CreateUserId, "S").Rows(0)(1).ToString()).Rows(0)("UserName")
            'add clear remarkSign by cq 20180803
            sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',VerifyUserName=N'{1}',VerifyTime=getdate(),RemarkSign='' where DocId='{2}'", Status, UserName, docID))

            If Convert.ToBoolean(IsAutoCheck(CreateUserId, Status).Rows(0)(0)) = True Then '品管自动审核
                Status = "P"
                UserName = getUser(IsAutoCheck(CreateUserId, "Q").Rows(0)(1).ToString()).Rows(0)("UserName")
                sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',QCUserName=N'{1}',QCTime=getdate(),RemarkSign='' where DocId='{2}'", Status, UserName, docID))

                '生产自动审核
                If Convert.ToBoolean(IsAutoCheck(CreateUserId, Status).Rows(0)(0)) = True Then
                    Status = "A"
                    UserName = getUser(IsAutoCheck(CreateUserId, "P").Rows(0)(1).ToString()).Rows(0)("UserName")
                    sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ProdUserName=N'{1}',ProdTime=getdate(),RemarkSign='' where DocId='{2}'", Status, UserName, docID))

                    '自动核准
                    If Convert.ToBoolean(IsAutoCheck(CreateUserId, Status).Rows(0)(0)) = True Then
                        Status = "C"
                        UserName = getUser(IsAutoCheck(CreateUserId, "A").Rows(0)(1).ToString()).Rows(0)("UserName")
                        sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate(),RemarkSign='' where DocId='{2}'", Status, UserName, docID))

                        'DCC自动核准
                        If Convert.ToBoolean(IsAutoCheck(CreateUserId, Status).Rows(0)(0)) = True Then
                            Status = "Y"
                            UserName = getUser(IsAutoCheck(CreateUserId, "C").Rows(0)(1).ToString()).Rows(0)("UserName")
                            sql.AppendLine(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',DCCUserName=N'{1}',DCCTime=getdate() where DocId='{2}'", Status, UserName, docID))
                            '已生效状态:
                            Dim Falg As Integer = 0
                            Dim para(4) As SqlParameter
                            Dim parameters() As SqlParameter = {
                                New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                                New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                                New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                                New SqlParameter("@Falg", SqlDbType.Int, 20)
                            }
                            parameters(0).Value = docID
                            parameters(1).Value = UserName
                            parameters(2).Value = "Y"
                            parameters(3).Value = Falg
                            parameters(3).Direction = ParameterDirection.Output
                            DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                        Else
                            '邮件提醒
                            SeedMailNoticeToMsg(docID, _SopName, "C", "待审核")
                        End If
                    Else
                        '邮件提醒
                        SeedMailNoticeToMsg(docID, _SopName, "A", "待审核")
                    End If
                Else
                    '邮件提醒
                    SeedMailNoticeToMsg(docID, _SopName, "P", "待审核")
                End If
            Else
                '邮件提醒
                SeedMailNoticeToMsg(docID, _SopName, "Q", "待审核")
            End If
        Else
            FlowNextStatus(docID, "S")
            '邮件提醒
            SeedMailNoticeToMsg(docID, _SopName, "S", "待审核")
        End If
        If String.IsNullOrEmpty(sql.ToString()) = False Then
            DbOperateUtils.ExecSQL(sql.ToString())
        End If
        Return True
    End Function

    ''' <summary>
    ''' 判断是否自动签核
    ''' add by 马跃平 2018-07-23
    ''' </summary>
    ''' <param name="CreateUserId">创建人工号</param>
    ''' <param name="Status">流程状态</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsAutoCheck(ByVal CreateUserId As String, ByVal Status As String) As DataTable
        Dim dt = New DataTable()
        Dim sql = "select IsAutoCheck,RelationUserId from m_OnlineSopMailRelation_t" & vbCrLf &
              "where MakeUserId='" & CreateUserId & "' and RelationType='" & Status & "'"
        dt = DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function

    ''' <summary>
    ''' 获取MES用户信息
    ''' add by 马跃平 2018-07-23
    ''' </summary>
    ''' <param name="UserID">用户ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getUser(ByVal UserID As String) As DataTable
        Dim dt = New DataTable()
        Dim sql = "select * from m_Users_t where UserID='" & UserID & "' "
        Return DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function


    ''' <summary>
    ''' 打印此SOP
    ''' </summary>
    Private Sub tsmiHeaderPrint_Click(sender As Object, e As EventArgs) Handles tsmiHeaderPrint.Click

        Me.Cursor = Cursors.WaitCursor
        Me.tslMsg.Text = "正在打印,请耐心等待...."
        Try
            Dim docIdList As List(Of String) = New List(Of String)
            Dim status As String = Nothing
            Dim docId As String = Nothing
            Dim sopname As String = Nothing

            If Me.dgvSopHeader.CurrentRow Is Nothing Then Exit Sub



            docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            sopname = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            If status <> "已生效" Then
                MessageUtils.ShowInformation("SOP名称:" & sopname & ", 非已生效的SOP,不允许打印！")
                Exit Sub
            End If
            docIdList.Add(docId)
            ExprotOrPrintSop(docIdList, True)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try
        Me.tslMsg.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' 导出
    ''' </summary>
    Private Sub tsmiHeaderExport_Click(sender As Object, e As EventArgs) Handles tsmiHeaderExport.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim docIdList As List(Of String) = New List(Of String)
            Dim status As String = Nothing
            Dim docId As String = Nothing
            Dim sopname As String = Nothing

            If Me.dgvSopHeader.CurrentRow Is Nothing Then Exit Sub
            docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            sopname = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            If status <> "已生效" Then
                MessageUtils.ShowInformation("SOP名称:" & sopname & ", 非已生效的SOP,不允许导出！")
                Exit Sub
            End If
            docIdList.Add(docId)

            If ExprotOrPrintSop(docIdList, False) = True Then
                MessageBox.Show("SOP文件导出成功,导出位置：c:\MesExport文件夹中", " 导出SOP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try

        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "单身-右键菜单事件"

    ''' <summary>
    ''' 查看
    ''' </summary>
    Private Sub tsmiBodyDetail_Click(sender As Object, e As EventArgs) Handles tsmiBodyDetail.Click
        Try
            If Me.dgvSopBody.RowCount < 1 OrElse Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub

            '文件编码
            Dim docID As String = "", SopName As String = ""
            '主键ID
            Dim Id As String
            Dim status As String
            docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            status = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            Dim frmBody As New FrmOnlineSopDetailEdit("View", docID, Nothing, Id, IIf(status = "已生效", True, False), SopName)
            frmBody.ShowDialog()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyModify_Click", "sys")
        End Try

    End Sub
    ''' <summary>
    ''' 复制单元格
    ''' </summary>
    Private Sub tsmiBodyCopy_Click(sender As Object, e As EventArgs) Handles tsmiBodyCopy.Click

        Try
            If Not dgvSopBody.CurrentCell Is Nothing Then
                Dim Selected As String = dgvSopBody.CurrentCell.Value.ToString
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyCopy_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 新增
    ''' </summary>
    Private Sub tsmiBodyAdd_Click(sender As Object, e As EventArgs) Handles tsmiBodyAdd.Click

        Try
            If dgvSopHeader.CurrentCell Is Nothing Then Exit Sub
            '文件编码
            Dim docID As String
            Dim status As String

            If GetMakeRight() = False Then
                MessageUtils.ShowWarning("对不起，您没有制作SOP的权限!")
                Exit Sub
            End If
            docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString

            'SOP名称
            Dim sopName As String
            sopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString


            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString

            If status <> "制作中" Then
                MessageUtils.ShowInformation("SOP名称:" & sopName & " ,非制作状态不允许新增工站信息！")
                Exit Sub
            End If

            'ByVal actionType As String, ByVal docId As String, _
            ' ByVal partId As String, ByVal Id As String, Optional ByVal _IsSeal As Boolean = False,Optional ByVal sopName As String=""

            ' Dim frmBody As New FrmOnlineSopDetailEdit("Add", docID, sopName, sopName, "")

            Dim frmBody As New FrmOnlineSopDetailEdit("Add", docID, sopName, "", False, sopName)

            frmBody.ShowDialog()

            '加载数据-单身
            LoadOnlineSopBody()

            '重新设置Tree数据
            SetSideBarData()
            '加载tree
            LoadSideBarTree(_SideActivate)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyAdd_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 修改单身
    ''' </summary>
    Private Sub tsmiBodyModify_Click(sender As Object, e As EventArgs) Handles tsmiBodyModify.Click
        Try
            If Me.dgvSopBody.RowCount < 1 OrElse Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            '文件编码
            Dim docID As String = "", sopName As String = ""
            '主键ID
            Dim Id As String
            '状态
            Dim status As String
            'SOP名称
            Dim stationName As String
            docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            sopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            stationName = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.StationName).Value.ToString
            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString

            If status <> "制作中" AndAlso status <> "已生效" Then
                MessageUtils.ShowInformation("工站名称:" & stationName & " ,审核状态,不允许修改！")
                Exit Sub
            End If

            'If GetConfirmInvRight() = False Then
            '    MessageUtils.ShowWarning("不允许修改其他人制作的SOP！")
            '    Exit Sub
            'End If
            Dim frmBody As New FrmOnlineSopDetailEdit("Modify", docID, Nothing, Id, False, sopName)
            If frmBody.ShowDialog() = Windows.Forms.DialogResult.OK Then

                If status = "已生效" Then

                    FlowNextStatus(docID, "N")
                End If
                LoadOnlineSopHeader()
                '加载数据-单身
                LoadOnlineSopBody()

                '刷新左边树
                LoadSideBarTree(Me.SideActivate)

            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyModify_Click", "sys")
        End Try

    End Sub
    ''' <summary>
    ''' 删除
    ''' </summary>
    Private Sub tsmiBodyDelete_Click(sender As Object, e As EventArgs) Handles tsmiBodyDelete.Click
        Try
            'If Me.dgvSopBody.RowCount < 0 OrElse Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub

            '状态
            'Dim Id As String
            'Dim status As String
            'Dim stationName As String
            'Dim confirmMsg As String
            'stationName = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.StationName).Value.ToString
            'status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            'Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            'If status <> "制作中" Then
            '    MessageUtils.ShowInformation("工站名称:" & stationName & " ,非制作中的SOP,不允许删除！")
            '    Exit Sub
            'End If
            'confirmMsg = "确定要删除[" & stationName & "]工站的SOP资料吗？"
            'If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            '    DeleteStationSop(Id)
            '    '加载单身
            '    LoadOnlineSopBody()
            '    ' Me.dgvSopBody.Rows.RemoveAt(Me.dgvSopBody.CurrentRow.Index)
            'End If


            'add by 马跃平 2018-04-16 贺声平提出需求批量删除
            If dgvSopBody.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim dr = MessageUtils.ShowConfirm("确定要删除选择工站的SOP资料吗？", MessageBoxButtons.OKCancel)
            If Not dr = Windows.Forms.DialogResult.OK Then
                MessageUtils.ShowInformation("删除失败!")
                Exit Sub
            End If

            For Each dgr As DataGridViewRow In dgvSopBody.Rows
                Dim objValue As Boolean = Convert.ToBoolean(dgr.Cells(0).FormattedValue)
                Dim id As String = dgr.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
                Dim status As String = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                Dim stationName As String = dgr.Cells(OnlineSopBusiness.BodyGridView.StationName).Value.ToString
                If objValue = True Then
                    If status <> "制作中" Then
                        MessageUtils.ShowInformation("工站名称:" & stationName & " ,非制作中的SOP,不允许删除！")
                        Continue For
                    End If
                    DeleteStationSop(id)
                End If
            Next
            LoadOnlineSopBody()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyDelete_Click", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 复制行
    ''' </summary>
    Private Sub tsmiBodyCopyRow_Click(sender As Object, e As EventArgs) Handles tsmiBodyCopyRow.Click
        If Me.dgvSopBody.RowCount < 1 OrElse Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub
        Dim rCount As Int16 = 0
        Dim rId As String = String.Empty


        Me.dgvSopBody.EndEdit()
        For Each row As DataGridViewRow In Me.dgvSopBody.Rows
            If Not row.Cells(0).Value Is Nothing Then
                If row.Cells(0).Value.ToString = "True" Then
                    rCount += 1
                End If
            End If
        Next
        If rCount = 0 Then
            MessageUtils.ShowInformation("请勾选需要复制的行！")
            Exit Sub
        End If
        ReDim Me.CopySopRowID(rCount - 1)
        rCount = 0
        For Each row As DataGridViewRow In Me.dgvSopBody.Rows
            If Not row.Cells(0).Value Is Nothing Then
                If row.Cells(0).Value.ToString = "True" Then
                    rId = row.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
                    Me.CopySopRowID(rCount) = rId
                    rCount += 1
                End If
            End If
        Next

        Me.tsmiBodyPasteRow.Enabled = True
    End Sub

    ''' <summary>
    ''' 粘贴行
    ''' </summary>
    Private Sub tsmiBodyPasteRow_Click(sender As Object, e As EventArgs) Handles tsmiBodyPasteRow.Click

        Dim _DocId As String = String.Empty
        Dim _PartId As String = String.Empty
        Dim o_strSql As New StringBuilder
        Dim _Id As String = String.Empty
        Dim tempID As String
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim _PageSize As Int16 = 0
        _PageSize = Me.dgvSopBody.Rows.Count
        Try
            For Each tempID In Me.CopySopRowID
                _Id = Guid.NewGuid.ToString
                _DocId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                _PartId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
                o_strSql.Append(" INSERT INTO m_OnlineSopItem_t(Id,DocId,PartId,StationName,VerNo,EcnNo,PageSize,IsFinger,IsAS,IsLF,IsHF,IsOth,IsFocusStation,InsItems,ModifyUserId,ModifyTime) ")
                o_strSql.Append(" SELECT '" + _Id + "','" & _DocId & "',N'" & _PartId & "',StationName,'X1','NEW','" & (_PageSize + 1).ToString & "',IsFinger,IsAS,IsLF,IsHF,IsOth,IsFocusStation,InsItems,'" & UserID & "',getdate() FROM m_OnlineSopItem_t WHERE Id='" & tempID & "';")
                '经贺声平2018-09-04提出改善 所有复制粘贴的工站数据统一改成X1版本 update by 马跃平

                o_strSql.Append(" INSERT INTO m_OnlineSopPart_t(PId,PartId,PartName,Amount,Spec,ModifyUserId,ModifyTime)")
                o_strSql.Append(" SELECT '" & _Id & "',PartId,PartName,Amount,Spec,'" & UserID & "',getdate() FROM m_OnlineSopPart_t WHERE  PId ='" & tempID & "';")

                'add by 马跃平 复制粘贴 重复料号数据 异常处理 2018-08-21
                'o_strSql.Append(" INSERT INTO m_OnlineSopPart_t(PId,PartId,PartName,Amount,Spec,ModifyUserId,ModifyTime)")
                'o_strSql.Append(" SELECT '" & _Id & "',PartId,PartName,Amount,Spec,'" & UserID & "',getdate() FROM m_OnlineSopPart_t WHERE  PId ='" & tempID & "';")

                o_strSql.Append(" INSERT INTO m_OnlineSopEquipment_t(PId,EquiName,EquiNo,EquiDesc)")
                o_strSql.Append(" SELECT '" & _Id & "',EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipment_t WHERE  PId ='" & tempID & "';")

                o_strSql.Append(" INSERT INTO m_OnlineSopPicture_t(PId,OrdIndex,PicPath,PicDesc) ")
                o_strSql.Append(" SELECT '" & _Id & "',OrdIndex,PicPath,PicDesc FROM m_OnlineSopPicture_t WHERE  PId ='" & tempID & "';")

                _PageSize += 1
            Next

            DbOperateUtils.ExecSQL(o_strSql.ToString)
            '加载数据-单身
            LoadOnlineSopBody()
            Me.tsmiBodyPasteRow.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "tsmiBodyPasteRow_Click", "sys")
        End Try

    End Sub
    ''' <summary>
    ''' 加入备注
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiRemark_Click(sender As Object, e As EventArgs) Handles tsmiRemark.Click

        If Me.dgvSopBody.RowCount < 1 OrElse Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub

        '状态
        Dim Id As String

        Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString

        Dim frmRemark As New FrmOnlineRemark(Id)
        If frmRemark.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '加载数据-单身
            LoadOnlineSopBody()
        End If
    End Sub

    ''' <summary>
    ''' 右键打印
    ''' </summary>
    Private Sub tsmiBodyPrint_Click(sender As Object, e As EventArgs) Handles tsmiBodyPrint.Click
        Me.tslMsg.Text = "正在打印,请耐心等待..."
        Me.Cursor = Cursors.WaitCursor
        Dim m_Id As String

        Try
            If Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub


            m_Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            '单独打印单身工站SOP

            ExprotOrPrintSopBody(True, m_Id)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try
        Me.tslMsg.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' 右键导出
    ''' </summary>
    Private Sub tsmiBodyExprot_Click(sender As Object, e As EventArgs) Handles tsmiBodyExprot.Click
        Me.tslMsg.Text = "正在导出,请耐心等待..."
        Me.Cursor = Cursors.WaitCursor
        Dim m_Id As String

        Try
            If Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub
            m_Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            '单独打印单身工站SOP
            If ExprotOrPrintSopBody(False, m_Id) = True Then
                MessageBox.Show("SOP文件导出成功,导出位置：c:\MesExport文件夹中", " 导出SOP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageUtils.ShowInformation("导出失败,请联系MES开发团队！")
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnExportSop_Click", "sys")
        End Try
        Me.tslMsg.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "dataGridView事件"


    ''' <summary>
    ''' 全选
    ''' </summary>
    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        Me.dgvSopHeader.EndEdit()
        If Me.dgvSopHeader.Rows.Count <= 0 Then Exit Sub

        For Each Row As DataGridViewRow In Me.dgvSopHeader.Rows
            Row.Cells(0).Value = IIf(m_ChkboxAll.Checked = True, True, False)
        Next
    End Sub
    Private Sub dgvSopHeader_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvSopHeader.CellBeginEdit
        If e.ColumnIndex > 0 Then
            e.Cancel = True
        End If
    End Sub


    ''' <summary>
    ''' 重绘,绘制选择复选框
    ''' </summary>
    Private Sub dgvSopHeader_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvSopHeader.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.dgvSopHeader.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                p.Offset(CInt("0"), CInt("0"))
                Me.m_ChkboxAll.Location = p

                Me.m_ChkboxAll.Size = dgvSopHeader.Columns(0).HeaderCell.Size
                Me.m_ChkboxAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))

                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "dgvSopHeader_CellPainting", "sys")
        End Try
    End Sub


    Private Sub dgvSopHeader_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSopHeader.CellFormatting
        If e.RowIndex > -1 AndAlso e.ColumnIndex = CInt(OnlineSopBusiness.HeaderGridView.Status) AndAlso Me.dgvSopHeader.RowCount > 0 Then

            '设置状态字体颜色
            Dim _Status As String
            If e.ColumnIndex = CInt(OnlineSopBusiness.HeaderGridView.Status) Then
                _Status = Me.dgvSopHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString

                If _Status = "已生效" Then
                    e.CellStyle.ForeColor = Color.Blue
                ElseIf _Status = "已作废" Then
                    e.CellStyle.ForeColor = Color.Gray
                ElseIf _Status <> "制作中" Then
                    e.CellStyle.ForeColor = Color.Red
                Else
                    e.CellStyle.ForeColor = Color.Black
                End If

            End If

        End If


    End Sub

    Private Sub dgvSopHeader_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSopHeader.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvSopHeader.RowCount > 0 Then
            '加载单身
            LoadOnlineSopBody()

        End If
    End Sub

    ''' <summary>
    ''' 单元格双击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSopHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSopHeader.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvSopHeader.RowCount > 0 Then
            '文件编码
            Dim docID As String
            Dim status As String

            docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            If status <> "制作中" AndAlso status <> "已生效" Then

                Dim frmBody As New FrmOnlineSopDetailEdit("View", docID, Nothing, Nothing, IIf(status = "已生效", True, False))
                frmBody.ShowDialog()
            Else
                '检查是否有制作人权限
                If GetMakeRight() = False Then
                    Dim frmBodyDialog As New FrmOnlineSopDetailEdit("View", docID, Nothing, Nothing, IIf(status = "已生效", True, False))
                    frmBodyDialog.ShowDialog()
                Else
                    Dim frmBody As New FrmOnlineSopDetailEdit("Modify", docID, Nothing, Nothing, IIf(status = "已生效", True, False))
                    If frmBody.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        If status = "已生效" Then
                            FlowNextStatus(docID, "N")
                        End If
                        '加载单头
                        LoadOnlineSopHeader()
                        '加载数据-单身
                        LoadOnlineSopBody()

                        '刷新左边树
                        LoadSideBarTree(Me.SideActivate)
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 双击单身
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSopBody_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSopBody.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvSopBody.RowCount > 0 Then
            '文件编码
            Dim _DocId As String
            '状态
            Dim _Status As String
            Dim _Id As String
            Dim _StationName As String, _sopName As String = ""
            _DocId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            _sopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            _Status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            _Id = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
            _StationName = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.StationName).Value.ToString

            If _Status <> "制作中" AndAlso _Status <> "已生效" Then
                Dim frmBody As New FrmOnlineSopDetailEdit("View", _DocId, Nothing, _Id, False)
                frmBody.ShowDialog()
            Else
                '   ByVal actionType As String, ByVal docId As String, _
                'ByVal partId As String, ByVal Id As String, Optional ByVal _IsSeal As Boolean = False, Optional sopName As String = ""
                Dim frmBody As New FrmOnlineSopDetailEdit("Modify", _DocId, Nothing, _Id, IIf(_Status = "已生效", True, False), _sopName)
                If frmBody.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    If _Status = "已生效" Then

                        FlowNextStatus(_DocId, "N")
                    End If
                    LoadOnlineSopHeader()
                    '加载数据-单身
                    LoadOnlineSopBody()

                    '刷新左边树
                    LoadSideBarTree(Me.SideActivate)
                End If

            End If


        End If
    End Sub

    ''' <summary>
    ''' 复选框选中事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSopHeader_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSopHeader.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim _SelectValue As String

            _SelectValue = IIf(CType(Me.dgvSopHeader.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell).EditingCellFormattedValue = True, True, False)
            For Each Row As DataGridViewRow In Me.dgvSopBody.Rows
                Row.Cells(0).Value = _SelectValue
            Next

        End If
    End Sub



    Private Sub dgvSopBody_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSopBody.CellFormatting
        If e.RowIndex > -1 AndAlso e.ColumnIndex = CInt(OnlineSopBusiness.BodyGridView.StationName) AndAlso Me.dgvSopBody.RowCount > 0 Then

            '设置状态字体颜色
            Dim m_IsColor As Boolean
            If e.ColumnIndex = CInt(OnlineSopBusiness.BodyGridView.StationName) Then
                m_IsColor = CBool(Me.dgvSopBody.Rows(e.RowIndex).Cells(CInt(OnlineSopBusiness.BodyGridView.IsColor)).Value.ToString)

                If m_IsColor = True Then
                    e.CellStyle.BackColor = Color.Yellow
                End If
            End If

        End If
    End Sub
#End Region

#Region "自定义函数"

    ''' <summary>
    ''' 加载SOP单头
    ''' </summary>
    Private Sub LoadOnlineSopHeader(Optional ByVal sWhere As String = Nothing, Optional ByVal isQueryOld AS Boolean = False)
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim o_strSql As New StringBuilder()

        If isQueryOld =False
            o_strSql.Append("SELECT a.SopName,a.DocId,a.PartName,a.PartDesc,a.Version,ISNULL(d.PageAmount,0) AS PageAmount,a.Shape ,")
            o_strSql.Append("case when a.Status='N' then N'制作中'")
            o_strSql.Append(" when a.Status='S' then N'待审核'")
            o_strSql.Append(" when a.Status='P' then N'待生产审核'")
            o_strSql.Append(" when a.Status='Q' then N'待品管审核'")
            o_strSql.Append(" when a.Status='A' then N'待核准'")
            o_strSql.Append(" when a.Status='C' then N'待DCC审核'")
            o_strSql.Append(" when a.Status='D' then N'已作废' else N'已生效' end Status ")
            o_strSql.Append(",a.Remark,c.UserName,a.CreateTime,d.ModifyTime as RecentlyModifyTime,a.ModifyUserId,a.ModifyTime,a.CreateUserId,a.RemarkSign FROM  m_OnlineSop_t a ")
            o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=a.CreateUserId ")
            o_strSql.Append(" LEFT JOIN (SELECT  DocId,max(ModifyTime) as ModifyTime,count(1) as PageAmount FROM m_OnlineSopItem_t group by DocId) d on d.DocId=a.DocId   ")
            o_strSql.Append(" WHERE a.Status<>'D' ")
        Else
            o_strSql.Append("SELECT a.SopName,a.DocId,a.PartName,a.PartDesc,a.Version,ISNULL(d.PageAmount,0) AS PageAmount,a.Shape ,")
            o_strSql.Append("case when a.Status='N' then N'制作中'")
            o_strSql.Append(" when a.Status='S' then N'待审核'")
            o_strSql.Append(" when a.Status='P' then N'待生产审核'")
            o_strSql.Append(" when a.Status='Q' then N'待品管审核'")
            o_strSql.Append(" when a.Status='A' then N'待核准'")
            o_strSql.Append(" when a.Status='C' then N'待DCC审核'")
            o_strSql.Append(" when a.Status='D' then N'已作废' else N'已生效' end Status ")
            o_strSql.Append(",a.Remark,c.UserName,a.CreateTime,d.ModifyTime as RecentlyModifyTime,a.ModifyUserId,a.ModifyTime,a.CreateUserId,a.RemarkSign FROM  m_OnlineSopOldVer_t a ")
            o_strSql.Append(" LEFT JOIN m_Users_t c ON c.UserID=a.CreateUserId ")
            o_strSql.Append(" LEFT JOIN (SELECT  DocId, VerNo,max(ModifyTime) as ModifyTime,count(1) as PageAmount FROM m_OnlineSopItemOldVer_t GROUP BY DocId,VerNo) d on d.DocId=a.DocId AND d.VerNo= a.Version  ")
            o_strSql.Append(" WHERE a.Status<>'D' ")

        End If

        If Not sWhere Is Nothing Then
            o_strSql.Append(sWhere)
        End If
        o_strSql.Append("  ORDER BY  isnull(d.ModifyTime,a.CreateTime) DESC ")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString())
        Me.dgvSopHeader.DataSource = dt
        _HeaderTable = dt
        'If _HeaderTable Is Nothing Then
        '    _HeaderTable = dt
        'End If

        '添加全选
        Me.m_ChkboxAll.Text = "选择"

        Me.dgvSopHeader.Controls.Add(Me.m_ChkboxAll)
        Me.txtCount.Text = CStr(dt.Rows.Count)

        AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
        AddHandler dgvSopHeader.CellPainting, AddressOf dgvSopHeader_CellPainting
        Me.dgvSopHeader.ClearSelection()
        If Me.dgvSopHeader.RowCount > 0 Then
            Me.dgvSopHeader.Item(OnlineSopBusiness.HeaderGridView.SopName, 0).Selected = True
        End If

    End Sub


    ''' <summary>
    ''' 加载SOP单身
    ''' </summary>
    ''' 
    Private Sub LoadOnlineSopBody(Optional ByVal isQueryOld As Boolean = False)


        If Me.dgvSopHeader.RowCount < 1 OrElse Me.dgvSopHeader.CurrentRow Is Nothing Then
            Dim dtBody As New DataTable
            dtBody = CType(Me.dgvSopBody.DataSource, DataTable)
            Me.dgvSopBody.DataSource = dtBody
            Exit Sub
        End If
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim docID As String = "", strVersion As String = ""
        docID = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
        strVersion = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Version).Value.ToString

        Dim strSql As String = ""
        If Me.IsQueryOld = False Then
            strSql = "select  a.StationName,a.VerNo,a.EcnNo,a.PageSize,case when a.IsFocusStation=1 then N'重点' else N'非重点' end IsFocusStation ,b.UserName,a.ModifyTime, " &
                      " a.Remark,a.IsColor,a.ID from m_OnlineSopItem_t a left join  m_Users_t b on b.UserID=a.ModifyUserId" &
                      " WHERE a.DocId='" & docID & "'  ORDER BY a.PageSize "
        Else
            strSql = "select  a.StationName,a.VerNo,a.EcnNo,a.PageSize,case when a.IsFocusStation=1 then N'重点' else N'非重点' end IsFocusStation ,b.UserName,a.ModifyTime, " &
                   " a.Remark,a.IsColor,a.ID from m_OnlineSopItemOldVer_t a left join  m_Users_t b on b.UserID=a.ModifyUserId" &
                   " WHERE a.DocId='" & docID & "' AND HeaderVer ='" & strVersion & "' ORDER BY a.PageSize "
        End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        dgvSopBody.AutoGenerateColumns = False
        Me.dgvSopBody.DataSource = dt
    End Sub

    Private Function IsExistsInHisTable(ByVal docID As String, ByVal strVersion As String) As Boolean
        Dim strSQL As String = ""
        strSQL = " SELECT 1 FROM m_OnlineSopItemOldVer_t WHERE  DocId='" & docID & "' AND verno='" & strVersion & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsExistsInHisTable = True
            Else
                IsExistsInHisTable = False
            End If
        End Using
    End Function



    ''' <summary>
    ''' 加载SideBar树
    ''' </summary>
    ''' <param name="_sopType">Sop状态类型</param>
    ''' <remarks></remarks>
    Private Sub LoadSideBarTree(ByVal _sopType As SopType)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Dim dvSop As DataView = Nothing
        Try
            If LeftTreeDataTable Is Nothing OrElse LeftTreeDataTable.Rows.Count < 1 Then
                '填充数据
                If SetSideBarData() = False Then Exit Sub
            End If

            dvSop = New DataView(LeftTreeDataTable)
            item.Image = ImageList1.Images(1)

            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left

            Select Case _sopType

                Case SopType.Make

                    '筛选
                    dvSop.RowFilter = "Status='N'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelMake.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelMake.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelMake
                    Me._SideActivate = SopType.Make

                Case SopType.Verify

                    '筛选
                    dvSop.RowFilter = "Status='S'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelVerify.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        Me.sbPanelVerify.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelVerify
                    Me._SideActivate = SopType.Verify
                Case SopType.Prod

                    '筛选
                    dvSop.RowFilter = "Status='P'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelProd.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        Me.sbPanelProd.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelProd
                    Me._SideActivate = SopType.Prod
                Case SopType.QC

                    '筛选
                    dvSop.RowFilter = "Status='Q'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelQC.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        Me.sbPanelQC.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelQC
                    Me._SideActivate = SopType.QC
                Case SopType.Approval

                    '筛选
                    dvSop.RowFilter = "Status='A'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelApproval.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        Me.sbPanelApproval.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelApproval
                    Me._SideActivate = SopType.Approval
                Case SopType.DCC

                    '筛选
                    dvSop.RowFilter = "Status='C'"

                    sbPanelDCC.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelDCC.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelDCC
                    Me._SideActivate = SopType.DCC

                Case Else
                    item.Image = ImageList1.Images(4)

                    item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                    item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
                    '筛选
                    dvSop.RowFilter = "Status='Y'"
                    ''排序
                    'dvSop.Sort = " CreateTime"
                    sbPanelFinish.SubItems.Clear()
                    For Each drv As DataRowView In dvSop
                        newItem = item.Copy()
                        newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                           "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                           " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                        lst = New ArrayList
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                        lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                        'lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.Status.ToString).ToString())
                        newItem.Tag = lst
                        Me.sbPanelFinish.SubItems.Add(newItem)

                        index += 1
                        If index > 100 Then Exit For
                    Next
                    Me.sbStatus.ExpandedPanel = Me.sbPanelFinish
                    Me._SideActivate = SopType.Finish

            End Select



        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "LoadSideBarByClick", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 筛选Tree
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BrushSideBarTree()
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Dim dvSop As DataView = Nothing
        Dim sFiter As String = ""
        Try
            If LeftTreeDataTable Is Nothing OrElse LeftTreeDataTable.Rows.Count < 1 Then
                Exit Sub
            End If

            dvSop = New DataView(LeftTreeDataTable)
            If Not String.IsNullOrEmpty(Me.txtSearch.Text.Trim) Then
                sFiter = "  AND SopName like'%" & txtSearch.Text.Trim & "%' "
            End If

            item.Image = ImageList1.Images(1)

            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
            '筛选
            dvSop.RowFilter = "Status='N' " & sFiter
            ''排序
            'dvSop.Sort = " CreateTime"
            sbPanelMake.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                sbPanelMake.SubItems.Add(newItem)
                index = 0
            Next

            '筛选
            dvSop.RowFilter = "Status='S' " & sFiter
            ''排序
            'dvSop.Sort = " CreateTime"
            sbPanelVerify.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelVerify.SubItems.Add(newItem)
                index = 1
            Next

            '筛选
            dvSop.RowFilter = "Status='P'  " & sFiter

            sbPanelProd.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelProd.SubItems.Add(newItem)
                index = 2
            Next

            '筛选
            dvSop.RowFilter = "Status='Q'  " & sFiter

            sbPanelQC.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelQC.SubItems.Add(newItem)
                index = 3
            Next

            '筛选
            dvSop.RowFilter = "Status='A' " & sFiter

            sbPanelApproval.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelApproval.SubItems.Add(newItem)

                index = 4
            Next
            '筛选
            dvSop.RowFilter = "Status='C' " & sFiter

            sbPanelDCC.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelDCC.SubItems.Add(newItem)

                index = 5
            Next
            '筛选
            dvSop.RowFilter = "Status='Y'  " & sFiter
            sbPanelFinish.SubItems.Clear()
            For Each drv As DataRowView In dvSop
                newItem = item.Copy()
                newItem.Text = drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString)), "",
                                                   "SOP名称:" & drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString &
                                                   " 文件编码:" & drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString))
                lst = New ArrayList
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.SopName.ToString).ToString())
                lst.Add(drv.Item(OnlineSopBusiness.HeaderGridView.DocId.ToString).ToString())
                newItem.Tag = lst
                Me.sbPanelFinish.SubItems.Add(newItem)

                index = 6
            Next

            Select Case index

                Case 0
                    Me.sbStatus.ExpandedPanel = sbPanelMake
                Case 1
                    Me.sbStatus.ExpandedPanel = sbPanelVerify
                Case 2
                    Me.sbStatus.ExpandedPanel = sbPanelProd
                Case 3
                    Me.sbStatus.ExpandedPanel = sbPanelQC
                Case 4
                    Me.sbStatus.ExpandedPanel = sbPanelApproval
                Case 5
                    Me.sbStatus.ExpandedPanel = sbPanelDCC
                Case Else
                    Me.sbStatus.ExpandedPanel = sbPanelFinish
            End Select



        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "BrushSideBarTree()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 设置左边树结构的数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetSideBarData() As Boolean
        Dim r As Boolean = False
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As DataTable = Nothing
            Me._LeftTreeDataTable = Nothing
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            '是否开启权限控制
            If Me.StartRight = False Then
                o_strSql.Append("SELECT  DocId,SopName,Status,CreateTime FROM m_OnlineSop_t ORDER BY CreateTime DESC ")
            Else
                'o_strSql.Append("SELECT distinct a.DocId,a.SopName,a.Status,a.CreateTime FROM m_OnlineSop_t  a left join  ")
                'o_strSql.Append(" m_OnlineSopEmail_t b on b.Satus=a.Status left join ")
                'o_strSql.Append(" m_OnlineSopEmail_t c on c.UserId=a.CreateUserId and c.Satus='N' ")
                'o_strSql.Append(String.Format(" WHERE (a.CreateUserId='{0}' and b.UserId='{0}'  OR A.Status in('N','Y') )    or (a.Status<>'P' and  b.UserId='{0}' )", UserID))
                'o_strSql.Append(String.Format(" or (a.Status='P' and b.UserId='{0}'  and c.ProdPM='{0}')", UserID))
                o_strSql.Append("SELECT  DocId,SopName,Status,CreateTime FROM m_OnlineSop_t ORDER BY CreateTime DESC ")
            End If
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me._LeftTreeDataTable = dt
                '统计数量
                SetSideBarPanelAmout()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "SetSideBarData()", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 统计各状态下的数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSideBarPanelAmout()
        Try
            Dim dv As DataView = Nothing

            '制作中-N，审核中-S，已作废-D,生产审核-P,品管审核-Q,核准-A,已生效-Y
            dv = New DataView(LeftTreeDataTable)
            dv.RowFilter = " Status='N'"
            sbPanelMake.Text = sbPanelMake.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='S'"
            sbPanelVerify.Text = sbPanelVerify.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='P'"
            sbPanelProd.Text = sbPanelProd.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='Q'"
            sbPanelQC.Text = sbPanelQC.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='A'"
            sbPanelApproval.Text = sbPanelApproval.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='C'"
            sbPanelDCC.Text = sbPanelDCC.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
            dv.RowFilter = " Status='Y'"
            sbPanelFinish.Text = sbPanelFinish.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "SetSideBarPanelAmout()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 删除工站SOP资料
    ''' </summary>
    ''' <param name="_Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteStationSop(ByVal _Id As String) As Boolean
        Dim r As Boolean = True
        Try
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim o_strSql As New StringBuilder
            Dim docId As String
            docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            o_strSql.Append(" DELETE m_OnlineSopPart_t WHERE PId='" & _Id & "';")
            o_strSql.Append(" DELETE m_OnlineSopPicture_t WHERE PId='" & _Id & "';")
            o_strSql.Append(" DELETE m_OnlineSopEquipment_t WHERE PId='" & _Id & "';")
            o_strSql.Append(" DELETE m_OnlineSopItem_t WHERE Id='" & _Id & "';")

            '更新页次
            o_strSql.Append(" SELECT  Row_Number() OVER (ORDER BY PageSize ASC) as Idx,Id  INTO #temp_m_OnlineSop from m_OnlineSopItem_t where  DocId='" & docId & "';")
            o_strSql.Append(" UPDATE m_OnlineSopItem_t SET PageSize =(select Idx from #temp_m_OnlineSop where #temp_m_OnlineSop.Id=m_OnlineSopItem_t.Id) where  DocId='" & docId & "';")
            o_strSql.Append(" drop table #temp_m_OnlineSop;")

            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "DeleteStationSop()", "sys")
        End Try
        Return r
    End Function


    ' ''' <summary>
    ' ''' 单一审批
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub SingleSopApproval()
    '    Try
    '        '单一审批
    '        If Not dgvSopHeader.CurrentCell Is Nothing Then
    '            Dim status As String
    '            Dim docId As String
    '            Dim _SopName As String
    '            Dim CreateUserId As String
    '            Dim _CurrStatus As String = Nothing
    '            Dim _NextStatus As String = Nothing
    '            Dim _NextStatusName As String = Nothing

    '            _SopName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString

    '            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
    '            docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
    '            CreateUserId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.CreateUserId).Value.ToString
    '            If status = "制作中" OrElse status = "已作废" OrElse status = "已生效" Then
    '                MessageUtils.ShowInformation("SOP名称:" & _SopName & ", " & status & "的SOP,不允许审核！")
    '                Exit Sub
    '            End If


    '            '待审核(S)、待品管审核(Q)、待生产审核(P)、待核准(A)、待DCC审核(C)

    '            If status = "待审核" Then
    '                _CurrStatus = "S"
    '                _NextStatus = "Q"
    '                _NextStatusName = "待品管审核"

    '            ElseIf status = "待品管审核" Then
    '                _CurrStatus = "Q"
    '                _NextStatus = "P"
    '                _NextStatusName = "待生产审核"

    '            ElseIf status = "待生产审核" Then
    '                _CurrStatus = "P"
    '                _NextStatus = "A"
    '                _NextStatusName = "待核准"
    '            ElseIf status = "待核准" Then
    '                _CurrStatus = "A"
    '                _NextStatus = "C"
    '                _NextStatusName = "待DCC签核"

    '            Else
    '                _CurrStatus = "C"
    '                _NextStatus = "Y"
    '                _NextStatusName = "已生效"


    '            End If

    '            '验证是否有审核权限
    '            If GetSignRight(_CurrStatus, CreateUserId) = False Then
    '                MessageUtils.ShowWarning("对不起，您没有[" & _SopName & "]SOP的审批权限!")
    '                Exit Sub
    '            End If

    '            CustomCheck(CreateUserId, docId, _SopName, _NextStatus)

    '            ''邮件提醒
    '            'SeedMailNoticeToMsg(docId, _SopName, _NextStatus, _NextStatusName)

    '            ''审核至下一状态
    '            'If FlowNextStatus(docId, _NextStatus) = True Then

    '            '更新单头
    '            LoadOnlineSopHeader()
    '            '更新单身
    '            LoadOnlineSopBody()
    '            '重新设置Tree数据
    '            SetSideBarData()
    '            '加载tree
    '            LoadSideBarTree(_SideActivate)
    '            MessageUtils.ShowInformation("审核成功！")
    '            'End If

    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnAudit_Click", "sys")
    '    End Try
    'End Sub


    ''' <summary>
    ''' 多选审批
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoreSopApproval()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim status As String = Nothing
            Dim docId As String = Nothing
            Dim _SopName As String = Nothing
            Dim MakeUserId As String = Nothing
            Dim _CurrStatus As String = Nothing
            Dim _NextStatus As String = Nothing
            Dim _NextStatusName As String = Nothing
            Dim _ApprovalRow As Integer = 0
      
            For Each Row As DataGridViewRow In Me.dgvSopHeader.Rows
                If Not Row.Cells(0).EditedFormattedValue Is Nothing Then
                    If Row.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                        _SopName = Row.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
                        status = Row.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
                        docId = Row.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
                        MakeUserId = Row.Cells(OnlineSopBusiness.HeaderGridView.CreateUserId).Value.ToString

                        If status <> "制作中" AndAlso status <> "已作废" AndAlso status <> "已生效" Then
                            '待审核(S)、待品管审核(Q)、待生产审核(P)、待核准(A)

                            If status = "待审核" Then
                                _CurrStatus = "S"
                                _NextStatus = "Q"
                                _NextStatusName = "待品管审核"

                            ElseIf status = "待品管审核" Then
                                _CurrStatus = "Q"
                                _NextStatus = "P"
                                _NextStatusName = "待生产审核"

                            ElseIf status = "待生产审核" Then
                                _CurrStatus = "P"
                                _NextStatus = "A"
                                _NextStatusName = "待核准"

                            ElseIf status = "待核准" Then
                                _CurrStatus = "A"
                                _NextStatus = "C"
                                _NextStatusName = "待DCC签核"

                            Else
                                _CurrStatus = "C"
                                _NextStatus = "Y"

                                _NextStatusName = "已生效"
                            End If

                            '验证是否有审核权限()
                            If GetSignRight(_CurrStatus, MakeUserId) = False Then
                                MessageUtils.ShowWarning("对不起，您没有[" & _SopName & "]SOP的审批权限!")
                                Exit Sub
                            End If

                            CustomCheck(MakeUserId, docId, _SopName, _NextStatus)
                            _ApprovalRow = _ApprovalRow + 1

                            ''邮件提醒
                            'SeedMailNoticeToMsg(docId, _SopName, _NextStatus, _NextStatusName)
                            ''审核至下一状态
                            'If FlowNextStatus(docId, _NextStatus) = True Then
                            '    _ApprovalRow = _ApprovalRow + 1
                            'End If
                        End If
                    End If
                End If
            Next
            '单一审批
            If _ApprovalRow > 0 Then
                MessageUtils.ShowInformation("审核成功！")
                '更新单头
                LoadOnlineSopHeader()
                '更新单身
                LoadOnlineSopBody()
                '重新设置Tree数据
                SetSideBarData()

                '加载tree
                LoadSideBarTree(_SideActivate)
            Else
                MessageUtils.ShowInformation("暂无需要审核或审核失败！")
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "btnAudit_Click", "sys")
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' 审核至下一状态
    ''' </summary>
    ''' <param name="_DocId">文件编码</param>
    ''' <param name="_NextStatus">下一个状态</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FlowNextStatus(ByVal _DocId As String, ByVal _NextStatus As String) As Boolean
        Dim r As Boolean = True
        Try
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim UserName As String = VbCommClass.VbCommClass.UseName
            Dim o_strSql As New StringBuilder
            '制作中-N，待审核-S，已作废-D,生产审核-P,品管审核-Q,核准-A,已生效-Y,DCC审核-C
            Select Case _NextStatus
                Case "P"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',QCUserName=N'{1}',QCTime=getdate() where DocId='{2}'", _NextStatus, UserName, _DocId))
                Case "Q"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',VerifyUserName=N'{1}',VerifyTime=getdate() where DocId='{2}'", _NextStatus, UserName, _DocId))
                Case "A"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ProdUserName=N'{1}',ProdTime=getdate() where DocId='{2}'", _NextStatus, UserName, _DocId))
                Case "C"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',ApprovalUserName=N'{1}',ApprovalTime=getdate() where DocId='{2}'", _NextStatus, UserName, _DocId))
                Case "D"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',InvalidUserName=N'{1}',InvalidTime=getdate() where DocId='{2}'", _NextStatus, UserName, _DocId))
                Case "N"
                    o_strSql.Append(String.Format("UPDATE m_OnlineSop_t SET Status=N'{0}',VerifyUserName=NULL,ProdUserName=NULL,QCUserName=NULL,ApprovalUserName=NULL where DocId='{1}'", _NextStatus, _DocId))
                Case "Y"
                    '已生效状态:
                    Dim Falg As Integer = 0
                    Dim para(4) As SqlParameter
                    Dim parameters() As SqlParameter = {
                        New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                        New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                        New SqlParameter("@NextStatus", SqlDbType.VarChar, 50),
                        New SqlParameter("@Falg", SqlDbType.Int, 20)
                    }
                    parameters(0).Value = _DocId
                    parameters(1).Value = UserName
                    parameters(2).Value = _NextStatus
                    parameters(3).Value = Falg
                    parameters(3).Direction = ParameterDirection.Output
                    DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSign", parameters)
                    If parameters(3).Value.ToString = "0" Then
                        MessageUtils.ShowError("保存失败!")
                        Return False
                    End If
                    Return True
                Case Else
                    'Add clear remark by cq20180803
                    o_strSql.Append(String.Format(" UPDATE m_OnlineSop_t SET Status=N'{0}',REMARKSign='' where DocId='{1}';", _NextStatus, _DocId))
            End Select
            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "ApprovalNextStatus()", "sys")
        End Try
        Return r

    End Function

    ''' <summary>
    ''' 发送邮件通知给相关人员
    ''' </summary>
    ''' <param name="docId">文件编码</param>
    ''' <param name="sopName">Sop名称</param>
    ''' <param name="status">审核状态</param>
    ''' <param name="mailTilte">邮件标题</param>
    ''' <remarks></remarks>
    Private Sub SeedMailNoticeToMsg(ByVal docId As String, ByVal sopName As String, ByVal status As String, ByVal mailTilte As String)
        Try
            'Return
            Dim MailTo As String = GetMailToByString(status, docId)
            Dim o_StrBody As New StringBuilder
            Dim o_Subject As New StringBuilder
            o_Subject.Append("MES待办消息:SOP名称[" & sopName & "]" & mailTilte & "")
            o_StrBody.Append("<p>尊敬的MES用户:<p>")
            o_StrBody.Append("<p>SOP名称[" & sopName & "],其文件编码为[" & docId & "],当前审核状态为【" & mailTilte & "】,请进入MES系统审核!</p>")
            Dim para(3) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@SUBJECT", SqlDbType.NVarChar, 200),
                New SqlParameter("@Body", SqlDbType.NVarChar, 4000),
                New SqlParameter("@R_EMAIL", SqlDbType.NVarChar, 1000)
            }
            parameters(0).Value = o_Subject.ToString
            parameters(1).Value = o_StrBody.ToString
            parameters(2).Value = MailTo
            DbOperateUtils.ExecuteNonQureyByProc("m_MailSend_p", parameters)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "SeedMailNoticeToMsg()", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 获取消息提醒名单邮件地址
    ''' </summary>
    ''' <param name="status"></param>
    ''' <param name="docId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMailToByString(ByVal status As String, ByVal docId As String) As String
        Dim o_strSql As New StringBuilder
        Dim dt As DataTable
        Dim MailTo As String = Nothing
        Try
            '驳回、审核、非初版修改后等，邮件通知制作人
            If status = "N" OrElse status = "Y" Then
                o_strSql.Append("select A.* from m_OnlineSopEmail_t a INNER join m_OnlineSop_t b on b.CreateUserId=a.UserId ")
                o_strSql.Append("WHERE b.DocId=N'" & docId & "' and a.Satus=N'" & status & "'")
            Else
                o_strSql.Append("SELECT b.* FROM m_OnlineSopMailRelation_t A INNER JOIN m_OnlineSopEmail_t b ON b.UserId=a.RelationUserId AND b.Usey='Y' inner join ")
                o_strSql.Append(vbNewLine & " m_OnlineSop_t c on c.DocId='" & docId & "' and c.CreateUserId=a.MakeUserId ")
                o_strSql.Append(vbNewLine & " WHERE A.RelationType='" & status & "' AND A.Usey='Y' ")
            End If


            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                '多个邮件地址用分号
                For Each dr As DataRow In dt.Rows
                    MailTo &= ";" & dr("Email").ToString
                Next
            End If
            If Not String.IsNullOrEmpty(MailTo) Then
                MailTo = MailTo.Substring(1, MailTo.Length - 1)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetMailToByString()", "sys")
        End Try

        Return MailTo
    End Function

    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Private Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal tbColName As String = "")
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = CType(DgMoData.DataSource, DataTable)

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next
                If Not String.IsNullOrEmpty(tbColName) AndAlso bColName = False Then
                    Swriter.WriteLine(tbColName)
                    bColName = True
                Else
                    If wColName <> "" And bColName = False Then
                        Swriter.WriteLine(wColName)
                        bColName = True

                    End If
                End If


                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "整个SOP打印、导出作业"

    ''' <summary>
    ''' 导出或打印SOP
    ''' </summary>
    ''' <param name="ListDocID">文件编码列表</param>
    ''' <param name="IsPrint">是否打印</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExprotOrPrintSop(ByVal ListDocID As List(Of String), ByVal IsPrint As Boolean, Optional ByVal m_Orientation As Integer = 2) As Boolean
        Dim result As Boolean = False
        Dim temp As String

        Dim ExcelFileList As List(Of String) = New List(Of String)
        Try

            If ListDocID Is Nothing OrElse ListDocID.Count < 1 Then
                Return False
            End If

            For Each _DocId In ListDocID
                '生产Excel
                temp = GetOutputExclePath(_DocId)
                If Not String.IsNullOrEmpty(temp) Then
                    ExcelFileList.Add(temp)
                End If
            Next
            '需打印的SOP
            If Not ExcelFileList Is Nothing AndAlso ExcelFileList.Count > 0 AndAlso IsPrint = True Then
                For Each _File In ExcelFileList
                    PrintSop(_File)
                Next
                Return True
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "ExprotSopList()", "sys")
        End Try
        Return True
    End Function


    ''' <summary>
    ''' 生产Excel并返回Excel地址
    ''' </summary>
    ''' <param name="docID">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOutputExclePath(ByVal docID As String) As String
        Dim excelPath As String = Nothing
        Dim o_TempoutputFile As String
        Dim _ListId As List(Of String) = New List(Of String)
        Dim errorMsg As String = Nothing

        Dim ds As DataSet
        Dim TemplatePath As String = Nothing
        Dim _tempFilePathList As List(Of String) = New List(Of String)
        Try
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If
            '获取明细ID列表
            _ListId = GetPrintListId(docID)

            '------------生成清单------------------
            o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"

            'If SimpleExprotExcel(Me._SopTemplateListFile, o_TempoutputFile, Me.ItemDataTable, GetBodyVariables(), errorMsg) Then
            '    _tempFilePathList.Add(o_TempoutputFile)
            'End If

            If ExprotPrintListExcel(Me._SopTemplateListFile, o_TempoutputFile, GetListVariable(docID), errorMsg) Then
                _tempFilePathList.Add(o_TempoutputFile)
            End If

            '--------------生成SOP--------------------------------

            '单个SOP,
            For Each _Id As String In _ListId
                ds = GetSopExprotData(_Id, IIf(Len(docID) <= 15, False, True))
                If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Me._MainDataTable = ds.Tables(0)
                    Me._PartDataTable = ds.Tables(1)
                    Me._EquimentDataTable = ds.Tables(2)
                    Me._PictureDataTable = ds.Tables(3)

                    o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"

                    '判断是否为重点工站
                    If ds.Tables(0).Rows(0)("IsFocusStation").ToString.ToLower = "true" Then
                        TemplatePath = Me._SopTemplateImportantFile
                    Else
                        'TemplatePath = Me._SopTemplateFile
                        TemplatePath = Me._SopTemplateImportantFile 'add by 马跃平 2018-08-27
                    End If

                    If SopDataOutPutExcel(TemplatePath, o_TempoutputFile, GetVariables(), errorMsg) = True Then
                        _tempFilePathList.Insert(1, o_TempoutputFile)
                    End If
                End If
            Next

            If Not _tempFilePathList Is Nothing AndAlso _tempFilePathList.Count > 0 Then
                '列出清单
                '合并成一个Excel
                Dim m_SopName = "c:\MesExport\" & docID & "_" & Now.ToString("yyyyMMddHHmmss") & ".xlsx"
                Dim fstreamAll As New FileStream(_tempFilePathList(0), FileMode.Open)
                Dim workbook As New Workbook(fstreamAll)
                workbook.Worksheets(0).Name = "明细"

                For idx = 1 To _tempFilePathList.Count - 1

                    Dim fstream As New FileStream(_tempFilePathList(idx), FileMode.Open)
                    Dim tempBook As New Workbook(fstream)
                    tempBook.Worksheets(0).Name = (idx)
                    workbook.Combine(tempBook)
                    o_TempoutputFile = m_SopName
                    workbook.Save(o_TempoutputFile, SaveFormat.Xlsx)
                    fstream.Close()
                    excelPath = o_TempoutputFile

                Next
                fstreamAll.Close()

                '删除临时文件
                For Each _fPath As String In _tempFilePathList

                    If (File.Exists(_fPath)) Then
                        File.Delete(_fPath)
                    End If
                Next
                Return excelPath
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetOutputExclePath()", "sys")
        End Try
        Return excelPath
    End Function


    ''' <summary>
    ''' SOP数据输出Excel
    ''' </summary>
    ''' <param name="TemplatePath">SOP模板路径</param>
    ''' <param name="OutPutFile">输出Excel路径</param>
    ''' <param name="dics">变量集合</param>
    ''' <param name="errorMsg">错误消息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SopDataOutPutExcel(ByVal TemplatePath As String, ByVal OutPutFile As String, _
                                               ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim img As Integer = 0
        Dim _IsFinger As Boolean = False '手指套
        Dim _IsAs As Boolean = False     '防静电
        Dim _ImgLeft As Int16 = 0   '图片左偏移
        Dim _ImgTop As Int16 = 0   '图片上偏移
        Dim _PicIndex As Int16 = 0 '图片索引
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(TemplatePath)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(Me.MainDataTable)
            workBookDesigner.SetDataSource(Me.PartDataTable)
            workBookDesigner.SetDataSource(Me.EquimentDataTable)
            workBookDesigner.SetDataSource(Me.PictureDataTable)

            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next
            '图片（210x200）

            If Me.PictureDataTable.Rows.Count > 0 Then
                For index = 0 To Me.PictureDataTable.Rows.Count - 1
                    img = Me.PictureDataTable.Rows(index)("PicPath").ToString.Length
                    Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
                    If index = 0 Then
                        If img > 0 Then
                            pictures.Add(4, 2, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 1 Then
                        If img > 0 Then
                            pictures.Add(4, 7, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 2 Then
                        If img > 0 Then
                            pictures.Add(4, 12, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 3 Then
                        If img > 0 Then
                            pictures.Add(23, 2, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 4 Then
                        If img > 0 Then
                            pictures.Add(23, 7, Me.PictureDataTable.Rows(index)("PicPath").ToString)

                        End If

                    Else
                        If img > 0 Then
                            pictures.Add(23, 12, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    End If
                    '图片限定6个
                    If index > 5 Then
                        Exit For
                    End If
                Next

            End If
            'add by hgd 2017-05-02插入示意图，手指套或防静电标识
            If Me.MainDataTable.Rows.Count > 0 Then
                _IsFinger = CBool(Me.MainDataTable.Rows(0)("IsFinger").ToString)
                _IsAs = CBool(Me.MainDataTable.Rows(0)("IsAS").ToString)
                Dim IsLeftHand As Boolean = CBool(Me.MainDataTable.Rows(0)("IsLeftHand").ToString()) '左手套
                Dim IsRightHand As Boolean = CBool(Me.MainDataTable.Rows(0)("IsRightHand").ToString()) '右手套
                Dim SketchPic As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
                'If _IsFinger = True AndAlso _IsAs = False Then
                '    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Fingersleeve.png")
                '    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                '    pictureFingersleeve.Left = 3
                '    pictureFingersleeve.Top = 10
                If IsLeftHand = True And IsRightHand = True AndAlso _IsAs = False Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Fingersleeve.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 3
                    pictureFingersleeve.Top = 10
                ElseIf IsLeftHand = True And IsRightHand = False AndAlso _IsAs = False Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "LeftHand.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 3
                    pictureFingersleeve.Top = 10
                ElseIf IsRightHand = True And IsLeftHand = False AndAlso _IsAs = False Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "RightHand.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 3
                    pictureFingersleeve.Top = 10
                    'ElseIf _IsFinger = False AndAlso _IsAs = True Then
                    '    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    '    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    '    pictureAntistatic.Left = 3
                    '    pictureAntistatic.Top = 10
                ElseIf IsLeftHand = False And IsRightHand = False AndAlso _IsAs = True Then ' Modify by cq 20190618,IsRightHand = False And
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                    'ElseIf _IsFinger = True AndAlso _IsAs = True Then
                    '    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    '    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    '    pictureAntistatic.Left = 3
                    '    pictureAntistatic.Top = 10
                    '    _PicIndex = SketchPic.Add(37, 17, Me._SketchDirector + "Fingersleeve.png")
                    '    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    '    pictureFingersleeve.Left = 55
                    '    pictureFingersleeve.Top = 10
                ElseIf IsLeftHand = True And IsRightHand = True AndAlso _IsAs = True Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                    _PicIndex = SketchPic.Add(37, 17, Me._SketchDirector + "Fingersleeve.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 55
                    pictureFingersleeve.Top = 10
                ElseIf IsLeftHand = True And IsRightHand = False AndAlso _IsAs = True Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                    _PicIndex = SketchPic.Add(37, 17, Me._SketchDirector + "LeftHand.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 55
                    pictureFingersleeve.Top = 10
                ElseIf IsLeftHand = False And IsRightHand = True AndAlso _IsAs = True Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                    _PicIndex = SketchPic.Add(37, 17, Me._SketchDirector + "RightHand.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 55
                    pictureFingersleeve.Top = 10
                Else
                End If
            End If
            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(OutPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function


    ''' <summary>
    ''' 获取模板变量并赋值
    ''' </summary>
    ''' <returns>Dictionary(Of String, String)</returns>
    ''' <remarks></remarks>
    Private Function GetVariables() As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim o_tempStep As String = String.Empty
        Dim ColInx() As String
        ColInx = {"One", "Two", "Tre", "Four", "Five", "Six", "Sev", "Eig"}

        Dim StepColInx() As String
        StepColInx = {"❶", "❷", "❸", "❹", "❺", "❻", "⑦", "⑧"}
        Dim Pre_ColName As String = Nothing
        If Me.MainDataTable.Rows.Count > 0 Then
            dics.Add("PartID", Me.MainDataTable.Rows(0)("PartID").ToString)
            dics.Add("StationName", Me.MainDataTable.Rows(0)("StationName").ToString)
            dics.Add("EcnNo", Me.MainDataTable.Rows(0)("EcnNo").ToString)
            dics.Add("VerNo", Me.MainDataTable.Rows(0)("VerNo").ToString)
            dics.Add("PageSize", Me.MainDataTable.Rows(0)("PageSize").ToString)
            dics.Add("InsItems", Me.MainDataTable.Rows(0)("InsItems").ToString)
            dics.Add("UserName", Me.MainDataTable.Rows(0)("UserName").ToString)
            dics.Add("VerifyUserName", Me.MainDataTable.Rows(0)("VerifyUserName").ToString)
            dics.Add("ProdUserName", Me.MainDataTable.Rows(0)("ProdUserName").ToString)
            dics.Add("QCUserName", Me.MainDataTable.Rows(0)("QCUserName").ToString)
            dics.Add("ApprovalUserName", Me.MainDataTable.Rows(0)("ApprovalUserName").ToString)
            Dim WorkInfo = ""

            'add by 马跃平 2018-08-28
            Dim IsFocusStation = Me.MainDataTable.Rows(0)("IsFocusStation").ToString
            WorkInfo &= IIf(CBool(IsFocusStation), "■重点工站 ", "")

            Dim IsMask = Me.MainDataTable.Rows(0)("IsMask").ToString
            WorkInfo &= IIf(CBool(IsMask), "■佩戴口罩 ", "")

            Dim IsEarplugs = Me.MainDataTable.Rows(0)("IsEarplugs").ToString
            WorkInfo &= IIf(CBool(IsEarplugs), "■佩戴耳塞 ", "")

            Dim IsProtectiveGlasses = Me.MainDataTable.Rows(0)("IsProtectiveGlasses").ToString
            WorkInfo &= IIf(CBool(IsProtectiveGlasses), "■佩戴防护眼镜", "")
            dics.Add("WorkInfo", WorkInfo)

            'add by 马跃平 2018-12-05
            Dim MyProject = ""
            MyProject &= IIf(CBool(Me.MainDataTable.Rows(0)("IsAS").ToString()), "   ■防静电   ", "   □防静电   ")
            MyProject &= IIf(CBool(Me.MainDataTable.Rows(0)("IsLF").ToString()), "■L/F制程   ", "□L/F制程   ")
            MyProject &= IIf(CBool(Me.MainDataTable.Rows(0)("IsHF").ToString()), "■H/F制程   ", "□H/F制程   ")
            MyProject &= IIf(CBool(Me.MainDataTable.Rows(0)("IsOth").ToString()), "■其它   ", "□其它   ")
            dics.Add("MyProject", MyProject)
        End If
        '使用物料
        If Me.PartDataTable.Rows.Count > 0 Then
            For index = 0 To Me.PartDataTable.Rows.Count - 1
                Pre_ColName = "Part_" & ColInx(index)
                dics.Add(Pre_ColName & "Idx", Me.PartDataTable.Rows(index)("Idx").ToString)
                dics.Add(Pre_ColName & "PartName", Me.PartDataTable.Rows(index)("PartName").ToString)
                dics.Add(Pre_ColName & "PartId", Me.PartDataTable.Rows(index)("PartId").ToString)
                dics.Add(Pre_ColName & "Amount", Me.PartDataTable.Rows(index)("Amount").ToString)
                dics.Add(Pre_ColName & "Spec", Me.PartDataTable.Rows(index)("Spec").ToString)
                '限定只取6行数据,否则导出的模板因内容过多，导致错位
                If index > 6 Then
                    Exit For
                End If
            Next

        End If
        '治工具
        If Me.EquimentDataTable.Rows.Count > 0 Then
            For index = 0 To Me.EquimentDataTable.Rows.Count - 1
                Pre_ColName = "Equi_" & ColInx(index)
                dics.Add(Pre_ColName & "Idx", Me.EquimentDataTable.Rows(index)("Idx").ToString)
                dics.Add(Pre_ColName & "EquiName", Me.EquimentDataTable.Rows(index)("EquiName").ToString)
                dics.Add(Pre_ColName & "EquiNo", Me.EquimentDataTable.Rows(index)("EquiNo").ToString)
                dics.Add(Pre_ColName & "EquiDesc", Me.EquimentDataTable.Rows(index)("EquiDesc").ToString)
                '限定只取6行数据,否则导出的模板因内容过多，导致错位
                If index > 4 Then
                    Exit For
                End If
            Next
        End If
        '图片
        If Me.PictureDataTable.Rows.Count > 0 Then
            For index = 0 To Me.PictureDataTable.Rows.Count - 1
                Pre_ColName = "Pic_" & ColInx(index)
                dics.Add(Pre_ColName & "PicDesc", Me.PictureDataTable.Rows(index)("PicDesc").ToString)  '&=$Pic_SixPicDesc

                'add by cq 20190605, 贺声平说浪潮客户提出:如下有步骤多少的，但没有文字，直接质疑我们的动作有遗漏
                If String.IsNullOrEmpty(Me.PictureDataTable.Rows(index)("PicDesc").ToString) Then
                    o_tempStep=""
                Else
                    o_tempStep = "步" + vbCrLf + "骤" + vbCrLf + StepColInx(index)
                End If

                dics.Add(Pre_ColName & "Step", o_tempStep) '&=$Pic_SixStep


                If index > 5 Then
                    Exit For
                End If
            Next
        End If
        Return dics
    End Function


    ''' <summary>
    ''' 获取打印清单模板变量
    ''' </summary>
    ''' <param name="docId">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetListVariable(ByVal docId As String) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim o_strSql As New StringBuilder
        Dim ds As New DataSet
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '单头
            If Len(docId) <= 15 Then
                o_strSql.Append("select a.DocId,a.SopName,a.Version,(N'制作:'+b.UserName) as UserName, ")
                o_strSql.Append(" (N'审核:'+a.VerifyUserName) as VerifyUserName,(N'品管:'+a.QCUserName) as QCUserName, ")
                o_strSql.Append(" (N'生产:'+a.ProdUserName) as ProdUserName,(N'核准:'+a.ApprovalUserName) as ApprovalUserName  from m_OnlineSop_t a ")
                o_strSql.Append(String.Format(" left join  m_Users_t b on b.UserID=a.CreateUserId WHERE DocId='{0}';", docId))
            Else
                o_strSql.Append("select a.DocId,a.SopName,a.Version,(N'制作:'+b.UserName) as UserName, ")
                o_strSql.Append(" (N'审核:'+a.VerifyUserName) as VerifyUserName,(N'品管:'+a.QCUserName) as QCUserName, ")
                o_strSql.Append(" (N'生产:'+a.ProdUserName) as ProdUserName,(N'核准:'+a.ApprovalUserName) as ApprovalUserName  from m_OnlineSopOldVer_t a ")
                o_strSql.Append(String.Format(" left join  m_Users_t b on b.UserID=a.CreateUserId WHERE DocId='{0}';", docId))
            End If

            '单身
            If Len(docId) <= 15 Then
                o_strSql.Append(" SELECT  ID,StationName,VerNo,EcnNo,PageSize,RecentlyEdit ")
                o_strSql.Append(String.Format(" FROM m_OnlineSopItem_t where DocId='{0}' ORDER BY  PageSize ", docId))
            Else
                o_strSql.Append(" SELECT  ID,StationName,VerNo,EcnNo,PageSize,RecentlyEdit ")
                o_strSql.Append(String.Format(" FROM m_OnlineSopItemOldVer_t where DocId='{0}' ORDER BY  PageSize ", docId))
            End If
            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    dics.Add("DocId", ds.Tables(0).Rows(0)("DocId").ToString)
                    dics.Add("SopName", ds.Tables(0).Rows(0)("SopName").ToString)
                    dics.Add("Version", ds.Tables(0).Rows(0)("Version").ToString)
                    dics.Add("PageCount", ds.Tables(1).Rows.Count)
                    dics.Add("UserName", ds.Tables(0).Rows(0)("UserName").ToString)
                    dics.Add("VerifyUserName", ds.Tables(0).Rows(0)("VerifyUserName").ToString)
                    dics.Add("QCUserName", ds.Tables(0).Rows(0)("QCUserName").ToString)
                    dics.Add("ProdUserName", ds.Tables(0).Rows(0)("ProdUserName").ToString)
                    dics.Add("ApprovalUserName", ds.Tables(0).Rows(0)("ApprovalUserName").ToString)
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    For item = 0 To ds.Tables(1).Rows.Count - 1
                        dics.Add("StationName_" + (item + 1).ToString, ds.Tables(1).Rows(item)("StationName").ToString)
                        dics.Add("VerNo_" + (item + 1).ToString, ds.Tables(1).Rows(item)("VerNo").ToString)
                        dics.Add("EcnNo_" + (item + 1).ToString, ds.Tables(1).Rows(item)("EcnNo").ToString)
                        dics.Add("PageSize_" + (item + 1).ToString, ds.Tables(1).Rows(item)("PageSize").ToString)
                        dics.Add("RecentlyEdit_" + (item + 1).ToString, ds.Tables(1).Rows(item)("RecentlyEdit").ToString)
                    Next
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetListVariable()", "sys")
        End Try
        Return dics
    End Function


    ''' <summary>
    ''' 根据DOCID获取明细表ID
    ''' </summary>
    ''' <param name="docId">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPrintListId(ByVal docId As String) As List(Of String)
        Dim o_strSql As New StringBuilder
        Dim _List As List(Of String) = New List(Of String)
        Dim ds As DataSet
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

        If Len(docId) <= 15 Then
            o_strSql.Append("select Id from m_OnlineSopItem_t  a inner join  m_OnlineSop_t b on b.DocId=a.DocId where a.DocId='" & docId & "'  ORDER BY a.PageSize ;")
            'SOP清单
            o_strSql.Append(" select  Row_Number() OVER (ORDER BY a.PageSize ASC) as Idx, ")
            o_strSql.Append(" a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.Remark,c.DocId,c.SopName,c.Version,(N'制作:'+b.UserName) as UserName,")
            o_strSql.Append("  (N'审核:'+c.VerifyUserName) as VerifyUserName,(N'品管:'+c.QCUserName) as QCUserName, ")
            o_strSql.Append(" (N'生产:'+c.ProdUserName) as ProdUserName,(N'核准:'+c.ApprovalUserName) as ApprovalUserName ")
            o_strSql.Append(" from m_OnlineSopItem_t a left join  m_Users_t b on b.UserID=a.ModifyUserId  left join ")
            o_strSql.Append(" m_OnlineSop_t c on c.DocId=a.DocId  WHERE a.DocId='" & docId & "' ORDER BY a.PageSize")
        Else
            o_strSql.Append("select Id from m_OnlineSopItemOldVer_t  a inner join  m_OnlineSopOldVer_t b on b.DocId=a.DocId where a.DocId='" & docId & "'  ORDER BY a.PageSize ;")
            'SOP清单
            o_strSql.Append(" select  Row_Number() OVER (ORDER BY a.PageSize ASC) as Idx, ")
            o_strSql.Append(" a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.Remark,c.DocId,c.SopName,c.Version,(N'制作:'+b.UserName) as UserName,")
            o_strSql.Append("  (N'审核:'+c.VerifyUserName) as VerifyUserName,(N'品管:'+c.QCUserName) as QCUserName, ")
            o_strSql.Append(" (N'生产:'+c.ProdUserName) as ProdUserName,(N'核准:'+c.ApprovalUserName) as ApprovalUserName ")
            o_strSql.Append(" from m_OnlineSopItemOldVer_t a left join  m_Users_t b on b.UserID=a.ModifyUserId  left join ")
            o_strSql.Append(" m_OnlineSopOldVer_t c on c.DocId=a.DocId  WHERE a.DocId='" & docId & "' ORDER BY a.PageSize")
        End If

        ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                _List = New List(Of String)
                For Each Row As DataRow In ds.Tables(0).Rows
                    _List.Insert(0, Row(0).ToString)
                Next
            End If
            'If ds.Tables(1).Rows.Count > 0 Then
            '    Me._ItemDataTable = ds.Tables(1)
            'End If
        End If
        Return _List
    End Function

    ''' <summary>
    ''' 获取待导出SOP数据
    ''' </summary>
    ''' <param name="_Id">明细表ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSopExprotData(ByVal _Id As String, Optional ByVal isOldVer As Boolean =False) As DataSet
        Dim o_strSql As New StringBuilder
        Dim ds As DataSet = Nothing
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If isOldVer = False Then
                o_strSql.Append("SELECT A.Id,a.PartId,a.DocId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.IsFocusStation,a.InsItems,")
                o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName,a.IsFinger,a.IsAS,a.IsLF,a.IsHF,a.IsOth,isnull(a.IsMask,0) IsMask,isnull(a.IsEarplugs,0) IsEarplugs,isnull(a.IsProtectiveGlasses,0) IsProtectiveGlasses,IsLeftHand,IsRightHand")
                o_strSql.Append(" FROM m_OnlineSopItem_t a  INNER JOIN m_OnlineSop_t b on b.DocId=a.DocId")
                o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE A.Id='" & _Id & "';")
                o_strSql.Append(" SELECT  Row_Number() OVER (ORDER BY PartId desc) as Idx, PartName,PartId,Amount,Spec FROM m_OnlineSopPart_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT Row_Number() OVER (ORDER BY EquiNo desc) as Idx,EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipment_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT OrdIndex,PicPath,PicDesc FROM m_OnlineSopPicture_t WHERE PId='" & _Id & "' ORDER BY OrdIndex ASC;")
            Else
                o_strSql.Append("SELECT A.Id,a.PartId,a.DocId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.IsFocusStation,a.InsItems,")
                o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName,a.IsFinger,a.IsAS")
                o_strSql.Append(" FROM m_OnlineSopItemOldVer_t a  INNER JOIN m_OnlineSopOldVer_t b on b.DocId=a.DocId")
                o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE A.Id='" & _Id & "';")
                o_strSql.Append(" SELECT  Row_Number() OVER (ORDER BY PartId desc) as Idx, PartName,PartId,Amount,Spec FROM m_OnlineSopPartOldVer_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT Row_Number() OVER (ORDER BY EquiNo desc) as Idx,EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipmentOldVer_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT OrdIndex,PicPath,PicDesc FROM m_OnlineSopPictureOldVer_t WHERE PId='" & _Id & "' ORDER BY OrdIndex ASC;")

            End If
            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetSopExprotData()", "sys")
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 获取工站信息并设置源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBodyVariables() As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Try
            If Not Me.ItemDataTable Is Nothing AndAlso Me.ItemDataTable.Rows.Count > 0 Then

                dics.Add("SopName", Me.ItemDataTable.Rows(0)("SopName").ToString)
                dics.Add("Version", Me.ItemDataTable.Rows(0)("Version").ToString)

                dics.Add("DocId", Me.ItemDataTable.Rows(0)("DocId").ToString)
                dics.Add("PageCount", Me.ItemDataTable.Rows.Count.ToString)
                dics.Add("UserName", Me.ItemDataTable.Rows(0)("UserName").ToString)

                dics.Add("VerifyUserName", Me.ItemDataTable.Rows(0)("VerifyUserName").ToString)
                dics.Add("QCUserName", Me.ItemDataTable.Rows(0)("QCUserName").ToString)
                dics.Add("ProdUserName", Me.ItemDataTable.Rows(0)("ProdUserName").ToString)
                dics.Add("ApprovalUserName", Me.ItemDataTable.Rows(0)("ApprovalUserName").ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetBodyVariables()", "sys")
        End Try
        Return dics
    End Function

    ''' <summary>
    ''' 汇出Excel打印清单
    ''' </summary>
    ''' <param name="TemplatePath"></param>
    ''' <param name="OutPutFile"></param>
    ''' <param name="dics"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExprotPrintListExcel(ByVal TemplatePath As String, ByVal OutPutFile As String, ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(TemplatePath)
            workBookDesigner.Workbook = wk
            Dim s As Aspose.Cells.Style = workBookDesigner.Workbook.Styles(workBookDesigner.Workbook.Styles.Add())

            s.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            s.Font.Color = Color.Black
            s.Font.Name = "宋体"
            s.Font.Size = 12

            s.ForegroundColor = Color.LimeGreen
            s.Pattern = Aspose.Cells.BackgroundType.Solid


            Dim r_Index As Integer = 0
            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
                If dic.Key.Contains("RecentlyEdit") AndAlso dic.Value = "Y" Then

                    r_Index = dic.Key.Split("_")(1)
                    If r_Index <= 28 Then
                        For index = 0 To 4
                            Dim cel As Aspose.Cells.Cell = workBookDesigner.Workbook.Worksheets(0).Cells(r_Index + 2, index)
                            cel.SetStyle(s)
                        Next
                    Else
                        For index = 5 To 9
                            Dim cel As Aspose.Cells.Cell = workBookDesigner.Workbook.Worksheets(0).Cells(r_Index - 26, index)
                            cel.SetStyle(s)
                        Next
                    End If

                End If


            Next
            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(OutPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 简易模板汇出Excel--取消使用
    ''' </summary>
    ''' <param name="TemplatePath">模板地址</param>
    ''' <param name="OutPutFile">输出Excel</param>
    ''' <param name="dtSouce">数据源</param>
    ''' <param name="errorMsg">异常消息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SimpleExprotExcel(ByVal TemplatePath As String, ByVal OutPutFile As String, ByVal dtSouce As DataTable, ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(TemplatePath)
            workBookDesigner.Workbook = wk



            workBookDesigner.SetDataSource(Me.ItemDataTable)


            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next
            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(OutPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function




    ''' <summary>
    ''' 打印SOP-共用打印
    ''' </summary>
    ''' <param name="o_filePath">文档路径</param>
    ''' <remarks></remarks>
    Private Sub PrintSop(ByVal o_filePath As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim printerName As String = Nothing
        Dim m_Orientation As Integer = 2
        Dim m_Zoom As Integer = 100

        Try
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(o_filePath)
            For index = 1 To xlWorkBook.Sheets.Count
                If String.IsNullOrEmpty(printerName) Then

                    Dim pd As New PrintDialog
                    pd.ShowDialog()
                    printerName = Trim(pd.PrinterSettings.PrinterName)
                End If

                xlWorkSheet = xlWorkBook.Sheets(index)
                xlApp.Visible = False
                xlWorkSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4
                '页眉、页脚
                xlWorkSheet.PageSetup.HeaderMargin = 0.8
                xlWorkSheet.PageSetup.FooterMargin = 0.8
                '边距
                xlWorkSheet.PageSetup.LeftMargin = 0
                xlWorkSheet.PageSetup.TopMargin = 0
                xlWorkSheet.PageSetup.RightMargin = 0
                xlWorkSheet.PageSetup.BottomMargin = 0


                xlWorkSheet.PageSetup.CenterVertically = False
                xlWorkSheet.PageSetup.CenterHorizontally = True
                m_Orientation = IIf(index > 1, 2, 1)
                'm_Zoom = IIf(index > 1, 71, 75)
                m_Zoom = IIf(index > 1, 71, 88)
                '页面横向打印方向 1：竖向，2：横向
                'xlWorkSheet.PageSetup.Orientation = m_Orientation
                xlWorkSheet.PageSetup.Orientation = 2
                xlWorkSheet.PageSetup.Zoom = m_Zoom

                '打印
                xlWorkSheet.PrintOut(1, 10, 1, Nothing, printerName, Nothing, True, Nothing)

            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not xlWorkBook Is Nothing Then
                xlWorkBook.Close(False, Nothing, Nothing)
            End If
            If Not xlApp Is Nothing Then
                xlApp.Workbooks.Close()
                xlApp.Quit()
            End If
            If Not xlWorkSheet Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
            End If
            If Not xlWorkBook Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
            End If
            If Not xlApp Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            End If
            xlWorkSheet = Nothing
            xlWorkBook = Nothing
            xlApp = Nothing
            GC.Collect()
        End Try
    End Sub







#End Region

#Region "单个单身工站打印、导出作业"

    ''' <summary>
    ''' 导出或打印SOP
    ''' </summary>
    ''' <param name="IsPrint">是否打印</param>
    ''' <param name="m_Id">主键</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExprotOrPrintSopBody(ByVal IsPrint As Boolean, Optional ByVal m_Id As String = Nothing) As Boolean
        Dim result As Boolean = False
        Dim temp As String
        Dim docId As String
        Dim tempId As String
        Dim status As String
        Dim sopname As String
        '文件列表
        Dim ExcelFileList As List(Of String) = New List(Of String)
        'Id列表
        Dim IdList As List(Of String) = New List(Of String)
        Try

            If Me.dgvSopBody.RowCount < 1 Then
                Return False
            End If
            docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            status = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.Status).Value.ToString
            sopname = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            If status <> "已生效" Then
                MessageUtils.ShowInformation("SOP名称:" & sopname & ", 非已生效的SOP,不允许打印或导出！")
                Return False
            End If
            If m_Id Is Nothing Then
                For Each Row As DataGridViewRow In Me.dgvSopBody.Rows

                    If Row.Cells(0).EditedFormattedValue = True Then
                        tempId = Row.Cells(OnlineSopBusiness.BodyGridView.ID).Value.ToString
                        If Not String.IsNullOrEmpty(tempId) Then
                            IdList.Add(tempId)
                        End If
                    End If

                Next
            Else
                IdList.Add(m_Id)
            End If


            '单独打印
            If Not IdList Is Nothing AndAlso IdList.Count > 0 Then
                '生产Excel
                temp = GetOutputExclePathBody(docId, IdList)
                If Not String.IsNullOrEmpty(temp) Then
                    ExcelFileList.Add(temp)
                End If

                '需打印的SOP
                If Not ExcelFileList Is Nothing AndAlso ExcelFileList.Count > 0 AndAlso IsPrint = True Then
                    For Each _File In ExcelFileList
                        PrintSop(_File)
                    Next
                    Return True
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "ExprotOrPrintSopBody()", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 生产Excel并返回Excel地址--单身
    ''' </summary>
    ''' <param name="docID">文件编码</param>
    ''' <param name="IdList">ID列表</param>
    ''' <returns>返回Excel地址</returns>
    ''' <remarks></remarks>
    Private Function GetOutputExclePathBody(ByVal docID As String, ByVal IdList As List(Of String)) As String
        Dim excelPath As String = Nothing
        Dim o_TempoutputFile As String
        Dim _ListId As List(Of String) = New List(Of String)
        Dim errorMsg As String = Nothing

        Dim ds As DataSet
        Dim TemplatePath As String = Nothing
        Dim _tempFilePathList As List(Of String) = New List(Of String)
        Try
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If


            _ListId = GetPrintListId(docID)
            '------------整个生成清单------------------
            o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"



            If ExprotPrintListExcel(Me._SopTemplateListFile, o_TempoutputFile, GetListVariable(docID), errorMsg) Then
                _tempFilePathList.Add(o_TempoutputFile)
            End If

            'If SimpleExprotExcel(Me._SopTemplateListFile, o_TempoutputFile, Me.ItemDataTable, GetBodyVariables(), errorMsg) Then
            '    _tempFilePathList.Add(o_TempoutputFile)
            'End If



            ''------------个别生成清单------------------
            'o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"
            ''设置数据员
            'SetPrintListDataBody(_ListId)


            'If SimpleExprotExcel(Me._SopTemplateListFile, o_TempoutputFile, Me.ItemDataTable, GetBodyVariables(), errorMsg) Then
            '    _tempFilePathList.Add(o_TempoutputFile)
            'End If
            '--------------生成SOP--------------------------------

            '单个SOP,
            For Each _Id As String In IdList
                ds = GetSopExprotData(_Id)
                If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Me._MainDataTable = ds.Tables(0)
                    Me._PartDataTable = ds.Tables(1)
                    Me._EquimentDataTable = ds.Tables(2)
                    Me._PictureDataTable = ds.Tables(3)

                    o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"


                    '判断是否为重点工站
                    If ds.Tables(0).Rows(0)("IsFocusStation").ToString.ToLower = "true" Then
                        TemplatePath = Me._SopTemplateImportantFile
                    Else
                        'TemplatePath = Me._SopTemplateFile
                        TemplatePath = Me._SopTemplateImportantFile 'add by 马跃平 2018-12-05
                    End If
                    If SopDataOutPutExcel(TemplatePath, o_TempoutputFile, GetVariables(), errorMsg) = True Then
                        _tempFilePathList.Insert(1, o_TempoutputFile)
                    End If
                End If
            Next

            If Not _tempFilePathList Is Nothing Then
                '列出清单
                '合并成一个Excel
                Dim m_SopName = "c:\MesExport\" & docID & "_" & Now.ToString("yyyyMMddHHmmss") & ".xlsx"
                Dim fstreamAll As New FileStream(_tempFilePathList(0), FileMode.Open)
                Dim workbook As New Workbook(fstreamAll)
                workbook.Worksheets(0).Name = "明细"

                For idx = 1 To _tempFilePathList.Count - 1

                    Dim fstream As New FileStream(_tempFilePathList(idx), FileMode.Open)
                    Dim tempBook As New Workbook(fstream)
                    tempBook.Worksheets(0).Name = (idx)
                    workbook.Combine(tempBook)
                    o_TempoutputFile = m_SopName
                    workbook.Save(o_TempoutputFile, SaveFormat.Xlsx)
                    fstream.Close()
                    excelPath = o_TempoutputFile

                Next
                fstreamAll.Close()

                '删除临时文件
                For Each _fPath As String In _tempFilePathList

                    If (File.Exists(_fPath)) Then
                        File.Delete(_fPath)
                    End If
                Next
                Return excelPath
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetOutputExclePathBody()", "sys")
        End Try
        Return excelPath
    End Function


    ''' <summary>
    ''' 根据ID设置打印数据
    ''' </summary>
    ''' <param name="IdList">ID 列表</param>
    ''' <remarks></remarks>
    Private Sub SetPrintListDataBody(ByVal IdList As List(Of String))
        Dim o_strSql As New StringBuilder
        Dim dt As DataTable
        Dim _Temp As String = Nothing
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

        For Each item As String In IdList
            _Temp &= ",'" & item & "'"
        Next
        If Not _Temp Is Nothing Then
            _Temp = _Temp.Substring(1, _Temp.Length - 1)
            'SOP清单
            o_strSql.Append(" select  Row_Number() OVER (ORDER BY a.PageSize ASC) as Idx, ")
            o_strSql.Append(" a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.Remark,c.DocId,c.SopName,c.Version,(N'制作:'+b.UserName) as UserName,")
            o_strSql.Append("  (N'审核:'+c.VerifyUserName) as VerifyUserName,(N'品管:'+c.QCUserName) as QCUserName, ")
            o_strSql.Append(" (N'生产:'+c.ProdUserName) as ProdUserName,(N'核准:'+c.ApprovalUserName) as ApprovalUserName ")
            o_strSql.Append(" from m_OnlineSopItem_t a left join  m_Users_t b on b.UserID=a.ModifyUserId  left join ")
            o_strSql.Append(" m_OnlineSop_t c on c.DocId=a.DocId  WHERE a.Id in (" & _Temp & ") ORDER BY a.PageSize")

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Me._ItemDataTable = dt
                End If
            End If
        End If
    End Sub

#End Region


#Region "权限控制"

    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.btnEmail.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.btnEmail.Tag) = "YES", True, False)
    End Sub

    ''' <summary>
    ''' 验证打印权限
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPrintRight()
        Dim b As Boolean = False
        Dim o_strSql As String
        Dim iCount As Integer = 0
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim dtRight As New DataTable
        Dim IsPrint As Boolean = False
        Dim IsExprot As Boolean = False
        '权限验证是否开启
        If Me.StartRight = True Then
            '仅DCC有打印权限,
            'add by hgd 2017-04-28 制作人有导出权限
            o_strSql = String.Format("select * from m_OnlineSopEmail_t where Usey='Y' and  Satus IN('C','N') and UserId=N'{0}'", UserID)
            dtRight = DbOperateUtils.GetDataTable(o_strSql)
            If dtRight.Rows.Count > 0 Then

                For Each dr As DataRow In dtRight.Rows
                    If dr!Satus.ToString = "C" Then
                        IsPrint = True
                        IsExprot = True
                    End If

                    If dr!Satus.ToString = "N" Then
                        IsExprot = True
                    End If
                Next
            End If

            Me.btnPrint.Enabled = IsPrint
            Me.btnExportSop.Enabled = IsExprot
            Me.tsmiHeaderPrint.Enabled = IsPrint
            Me.tsmiHeaderExport.Enabled = IsExprot
            Me.tsmiBodyExprot.Enabled = IsExprot
            Me.tsmiBodyPrint.Enabled = IsPrint
            Me.toolStationChange.Enabled = IsExprot 'add by cq 20180802
        End If
    End Sub

    ''' <summary>
    ''' 验证审核权限
    ''' </summary>
    ''' <param name="CurrentStatus">当前审批节点</param>
    ''' <param name="MakeUserId">当前审批节点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSignRight(ByVal CurrentStatus As String, ByVal MakeUserId As String) As Boolean
        Dim b As Boolean = False
        Dim o_strSql As New StringBuilder
        Dim iCount As Integer = 0
        Dim Status As String = Nothing
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        '检查是否开启权限验证
        If Me.StartRight = False Then
            Return True
        End If

        ''审核权限
        o_strSql.Append("select MakeUserId from m_OnlineSopMailRelation_t where MakeUserId='" & MakeUserId &
                        "' and RelationType='" & CurrentStatus & "' AND RelationUserId='" & UserID & "' ")

        'o_strSql.Append(" select a.UserId,a.UserName,b.TEXT from m_OnlineSopEmail_t a ")
        'o_strSql.Append(" inner join  m_BaseData_t b on b.VALUE=a.Satus inner join m_OnlineSop_t c on c.Status=a.Satus INNER  join ")
        'o_strSql.Append(" m_OnlineSopEmail_t d on d.UserId=c.CreateUserId and d.Satus='N'  ")
        'o_strSql.Append(String.Format(" where (c.Status<>'P' AND a.UserId='{0}' and  b.TEXT=N'{1}')", UserID, CurrentStatus))
        'o_strSql.Append(String.Format(" or  (a.UserId='{0}' and  b.TEXT=N'{1}' AND c.Status='P' AND d.ProdPM=N'{0}')", UserID, CurrentStatus))

        iCount = DbOperateUtils.GetRowsCount(o_strSql.ToString)
        If iCount > 0 Then
            b = True
        End If
        Return b
    End Function

    ''' <summary>
    ''' 验证确认和作废、修改SOP的权限
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetConfirmInvRight() As Boolean
        Dim o_strSql As String = Nothing
        Dim iCount As Integer = 0
        Dim b As Boolean = False
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim docId As String = Nothing


        docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
        o_strSql = String.Format("select * from m_OnlineSop_t where DocId=N'{0}' and CreateUserId=N'{1}'", docId, UserID)
        iCount = DbOperateUtils.GetRowsCount(o_strSql)
        If iCount > 0 Then
            b = True
        End If
        Return b
    End Function


    ''' <summary>
    ''' 获取是否有制作权限
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMakeRight() As Boolean
        Dim o_strSql As String = Nothing
        Dim iCount As Integer = 0
        Dim b As Boolean = False
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim docId As String = Nothing

        '检查是否开启权限验证
        If Me.StartRight = False Then
            Return True
        End If
        o_strSql = String.Format("select * from m_OnlineSopEmail_t where UserId='{0}' AND Satus='N'", UserID)
        iCount = DbOperateUtils.GetRowsCount(o_strSql)
        If iCount > 0 Then
            b = True
        End If
        Return b
    End Function

#End Region


    Private Sub dgvSopBody_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSopBody.CellClick
        If e.ColumnIndex = 0 Then
            Dim chkCell As DataGridViewCheckBoxCell = dgvSopBody.Rows(e.RowIndex).Cells(0)
            Dim objValue As Boolean = Convert.ToBoolean(chkCell.FormattedValue)
            chkCell.Value = IIf(objValue, False, True)
        End If
    End Sub

    Private Sub dgvSopHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvSopHeader.DataError

    End Sub

    Private Sub toolExportChangeLog_Click(sender As Object, e As EventArgs) Handles toolExportChangeLog.Click
        Try
            'Dim strPath As String = ""
            'Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion)
            'frmStation.SelectExportPath("RunCard", strPath)

            'Call DoExportLog(strPath)
            Dim frmlog As New FrmSOPLog
            frmlog.ShowDialog()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "toolExportChangeLog_Click", "RCard")
        End Try
    End Sub

    Private Sub toolStationChange_Click(sender As Object, e As EventArgs) Handles toolStationChange.Click

        dim docId as String ="",strStationName As String ="", strSOPName As String =""

        If Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub
        docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
        strSOPName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
        strStationName = Me.dgvSopBody.CurrentRow.Cells(OnlineSopBusiness.BodyGridView.StationName).Value.ToString

        Dim frmSOPLog As New FrmSOPLog()
        frmSOPLog.txtSOPName.Text = strSOPName
        frmSOPLog.txtStationID.Text = strStationName
        If frmSOPLog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'do nothing
        End If

    End Sub

    Private Sub tsmiHeaderChangeLog_Click(sender As Object, e As EventArgs) Handles tsmiHeaderChangeLog.Click
        Dim docId As String = "", strStationName As String = "", strSOPName As String = ""

        If Me.dgvSopBody.CurrentRow Is Nothing Then Exit Sub
        docId = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
        strSOPName = Me.dgvSopHeader.CurrentRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString


        Dim frmSOPLog As New FrmSOPLog()
        frmSOPLog.txtSOPName.Text = strSOPName
        frmSOPLog.txtDocID.Text = docId

        If frmSOPLog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'do nothing
        End If
    End Sub

    Private Sub dgvSopHeader_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSopHeader.SelectionChanged
        '加载单身
        LoadOnlineSopBody()
    End Sub
End Class