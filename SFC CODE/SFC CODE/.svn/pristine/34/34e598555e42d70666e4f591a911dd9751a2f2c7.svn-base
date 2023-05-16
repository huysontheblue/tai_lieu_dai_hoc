Imports System.IO
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing
Imports Aspose.Cells

Public Class FrmRunCard
    Private Shared rowSpan As New SortedList()
    Private Shared rowValue As String = "" '' 

#Region "属性"

#Region "RunCardId"
    Private _runCardId As Integer
    Public Property RunCardId() As Integer
        Get
            Return _runCardId
        End Get
        Set(ByVal value As Integer)
            _runCardId = value
        End Set
    End Property

#End Region

    'Private _runCardIDList As New List(Of strRuncard)

    Public Structure strRuncard
        Public RuncardID As String
        Public Status As String
        Public RunCardPN As String
    End Structure


#Region "RunCardPartId"
    Private _runCardPartId As Integer
    Public Property RunCardPartId() As Integer
        Get
            Return _runCardPartId
        End Get
        Set(ByVal value As Integer)
            _runCardPartId = value
        End Set
    End Property

#End Region

#Region "RunCardPn"
    Private _runCardPn As String
    Public Property RunCardPn() As String
        Get
            Return _runCardPn
        End Get
        Set(ByVal value As String)
            _runCardPn = value
        End Set
    End Property


#End Region

#Region "RunCardStatus"
    Private _runCardStatus As Integer
    Public Property RunCardStatus() As Integer
        Get
            Return _runCardStatus
        End Get
        Set(ByVal value As Integer)
            _runCardStatus = value
        End Set
    End Property

#End Region

#Region "RunCardDetailId"
    Private _runCardDetailId As Integer
    Public Property RunCardDetailId() As Integer
        Get
            Return _runCardDetailId
        End Get
        Set(ByVal value As Integer)
            _runCardDetailId = value
        End Set
    End Property

#End Region

#Region "RunCardStationId"
    Private _runCardStationId As Integer
    Public Property RunCardStationId() As Integer
        Get
            Return _runCardStationId
        End Get
        Set(ByVal value As Integer)
            _runCardStationId = value
        End Set
    End Property

#End Region

#Region "RunCardData"
    Private _runCardData As New DataTable
    Public Property RunCardData() As DataTable
        Get
            Return _runCardData
        End Get
        Set(ByVal value As DataTable)
            _runCardData = value
        End Set
    End Property

#End Region

#Region "SopFileName"
    Private _sopFileName As String
    Public Property SopFileName() As String
        Get
            Return _sopFileName
        End Get
        Set(ByVal value As String)
            _sopFileName = value
        End Set
    End Property

#End Region

#Region "DrawingFileName"
    Private _drawingFileName As String
    Public Property DrawingFileName() As String
        Get
            Return _drawingFileName
        End Get
        Set(ByVal value As String)
            _drawingFileName = value
        End Set
    End Property

#End Region

#Region "IsQueryOldVersion"
    Private _isQueryOldVersion
    Public Property IsQueryOldVersion() As String
        Get
            Return _isQueryOldVersion
        End Get
        Set(ByVal value As String)
            _isQueryOldVersion = value
        End Set
    End Property
#End Region

#End Region

#Region "窗体加载"
    Private Sub FrmRunCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuHeader)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuBody)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuDetail)

            '
            SetControlStatus()

            '绑定 runcard 头部
            LoadRunCardHeader("")

            '绑定 SideBar 菜单
            'LoadSideBar("", Me.RunCardData, "asc")
            LoadSideBarByClick("", RunCardType.Finish)

            '隐藏料件面板
            Me.dgvPartNumber.Visible = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "FrmRunCard_Load", "sys")
        End Try
    End Sub
#End Region

#Region "SetControlStatus"
    Private Sub SetControlStatus()
        If btnCopy.Tag Is Nothing Then btnCopy.Tag = ""
        If btnAudit.Tag Is Nothing Then btnAudit.Tag = ""
        Me.btnCopy.Enabled = IIf(btnCopy.Tag.ToString = "YES", True, False)
        Me.btnAudit.Enabled = IIf(btnAudit.Tag.ToString = "YES", True, False)


        If tsmiHeaderAdd.Tag Is Nothing Then tsmiHeaderAdd.Tag = ""
        If tsmiHeaderModify.Tag Is Nothing Then tsmiHeaderModify.Tag = ""
        If tsmiHeaderSearch.Tag Is Nothing Then tsmiHeaderSearch.Tag = ""
        If tsmiHeaderPrint.Tag Is Nothing Then tsmiHeaderPrint.Tag = ""
        If tsmiHeaderDelete.Tag Is Nothing Then tsmiHeaderDelete.Tag = ""
        If tsmiHeaderImport.Tag Is Nothing Then tsmiHeaderImport.Tag = ""
        If tsmiHeaderExport.Tag Is Nothing Then tsmiHeaderExport.Tag = ""
        If tsmiHeaderReject.Tag Is Nothing Then tsmiHeaderReject.Tag = ""
        If tsmiHeaderCancel.Tag Is Nothing Then tsmiHeaderCancel.Tag = ""

        Me.tsmiHeaderAdd.Enabled = IIf(tsmiHeaderAdd.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderModify.Enabled = IIf(tsmiHeaderModify.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderSearch.Enabled = IIf(tsmiHeaderSearch.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderPrint.Enabled = IIf(tsmiHeaderPrint.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderDelete.Enabled = IIf(tsmiHeaderDelete.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderImport.Enabled = IIf(tsmiHeaderImport.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderExport.Enabled = IIf(tsmiHeaderExport.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderReject.Enabled = IIf(tsmiHeaderReject.Tag.ToString = "YES", True, False)
        Me.tsmiHeaderCancel.Enabled = IIf(tsmiHeaderCancel.Tag.ToString = "YES", True, False)

        If tsmiBodyAdd.Tag Is Nothing Then tsmiBodyAdd.Tag = ""
        If tsmiBodyModify.Tag Is Nothing Then tsmiBodyModify.Tag = ""
        If tsmiBodyConfirm.Tag Is Nothing Then tsmiBodyConfirm.Tag = ""
        If tsmiBodyDelete.Tag Is Nothing Then tsmiBodyDelete.Tag = ""
        If RToolStripMenuItem.Tag Is Nothing Then RToolStripMenuItem.Tag = ""
        If tsmiPartAdd.Tag Is Nothing Then tsmiPartAdd.Tag = ""

        Me.tsmiBodyAdd.Enabled = IIf(tsmiBodyAdd.Tag.ToString = "YES", True, False)
        Me.tsmiBodyModify.Enabled = IIf(tsmiBodyModify.Tag.ToString = "YES", True, False)
        Me.tsmiBodyConfirm.Enabled = IIf(tsmiBodyConfirm.Tag.ToString = "YES", True, False)
        Me.tsmiBodyDelete.Enabled = IIf(tsmiBodyDelete.Tag.ToString = "YES", True, False)
        Me.RToolStripMenuItem.Enabled = IIf(tsmiBodyModify.Tag.ToString = "YES", True, False)
        Me.tsmiPartAdd.Enabled = IIf(tsmiPartAdd.Tag.ToString = "YES", True, False)
        editRight = IIf(tsmiBodyModify.Tag.ToString = "YES", True, False)
        tsmiBodyModify.Enabled = False
    End Sub
    Private editRight As Boolean = False
#End Region

#Region "加载SideBar"
    Private Sub LoadSideBar(ByVal filter As String, ByVal dt As DataTable, Optional ByVal sort As String = "asc", Optional ByVal isQuery As Boolean = False)
        If dt.Rows.Count < 0 Then
            Exit Sub
        End If
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 1
        item.Image = ImageList1.Images(0)
        item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
        '晒选
        dv = New DataView(dt)
        dv.Sort = "创建时间 " & sort
        '已完成
        dv.RowFilter = "状态=1 " & filter
        '清除现有Item
        sbPanelFinish.SubItems.Clear()
        '遍历
        For Each drv As DataRowView In dv
            newItem = item.Copy()
            newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
            newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
            lst = New ArrayList
            lst.Add(drv.Item("ID").ToString())
            lst.Add(drv.Item("PartID").ToString())
            lst.Add(drv.Item("状态").ToString())
            newItem.Tag = lst
            sbPanelFinish.SubItems.Add(newItem)
            If isQuery Then GoTo Show
        Next
        '未完成
        dv.RowFilter = "状态=0 " & filter
        '清除现有Item
        sbPanelUnfinish.SubItems.Clear()
        '遍历
        For Each drv As DataRowView In dv
            newItem = item.Copy()
            newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
            newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
            lst = New ArrayList
            lst.Add(drv.Item("ID").ToString())
            lst.Add(drv.Item("PartID").ToString())
            lst.Add(drv.Item("状态").ToString())
            newItem.Tag = lst
            sbPanelUnfinish.SubItems.Add(newItem)
            index = 0
            If isQuery Then GoTo Show
        Next
        '审核中
        dv.RowFilter = "状态=2 " & filter
        '清除现有Item
        sbPanelAudit.SubItems.Clear()
        '遍历
        For Each drv As DataRowView In dv
            newItem = item.Copy()
            newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
            newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
            lst = New ArrayList
            lst.Add(drv.Item("ID").ToString())
            lst.Add(drv.Item("PartID").ToString())
            lst.Add(drv.Item("状态").ToString())
            newItem.Tag = lst
            sbPanelAudit.SubItems.Add(newItem)
            index = 2
            If isQuery Then GoTo Show
        Next
        '展开页
Show:
        If Not isQuery Then
            SideBar1.ExpandedPanel = sbPanelFinish
        Else
            SideBar1.ExpandedPanel = IIf(index = 0, sbPanelUnfinish, IIf(index = 1, sbPanelFinish, sbPanelAudit))
        End If
        '刷新
        sbPanelFinish.Refresh()
    End Sub
#End Region

#Region "绑定Combox"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If ColComboBox.Name = "cboStation" Then
                'ColComboBox.Items.Clear()
                'ColComboBox.Items.Add("")
                UserDg = DataHand.GetDataTable("select ID,StationName from m_RUNCARDStation_t(nolock)")
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "StationName"
                ColComboBox.ValueMember = "ID"
            End If
        Catch ex As Exception
            Throw ex
        Finally
            DataHand = Nothing
        End Try
    End Sub
#End Region

#Region "退出"
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "清除"
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtSearch.Text = ""
        'LoadSideBar("", Me.RunCardData)
        LoadSideBarByClick("", RunCardType.Finish)
    End Sub
#End Region

#Region "txtSearch_KeyPress"
    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        Dim str As String = txtSearch.Text.Trim
        If Asc(e.KeyChar) = 8 Then 'backspace
            If str <> "" Then
                str = str.Substring(0, str.Length - 1)
            End If
        End If
        If String.IsNullOrEmpty(str) Then
            'LoadSideBar("", Me.RunCardData, "asc", False)
            LoadSideBarByClick("", RunCardType.Finish)
        End If
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = txtSearch.Text.Trim
            'If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then '数字，字母，标点符号
            '    str = str & e.KeyChar.ToString
            'ElseIf Asc(e.KeyChar) = 8 Then 'backspace
            '    If str <> "" Then
            '        str = str.Substring(0, str.Length - 1)
            '    End If
            'End If
            If String.IsNullOrEmpty(str) Then
                'LoadSideBar("", Me.RunCardData, "asc", False)
                LoadSideBarByClick("", RunCardType.Finish)
            Else
                LoadSideBar(" and 料件编号 like '%" & str & "%'", Me.RunCardData, "asc", True)
            End If
        End If
    End Sub
#End Region

#Region "SideBar1_ItemClick"
    Private Sub SideBar1_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideBar1.ItemClick
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
                '赋值
                Me.RunCardPn = SelectedItem.Text.Trim
                Me.RunCardId = CInt(CType(SelectedItem.Tag, ArrayList).Item(0))
                Me.RunCardPartId = CInt(CType(SelectedItem.Tag, ArrayList).Item(1))
                Me.RunCardStatus = CInt(CType(SelectedItem.Tag, ArrayList).Item(2))
                '
                rowSpan.Clear()
                rowValue = ""
                '隐藏料件面板
                Me.dgvPartNumber.Visible = False

                If Me.RunCardData.Select("ID='" & Me.RunCardId & "'").Length > 0 Then
                    Me.RunCardData.Select("ID='" & Me.RunCardId & "'")(0)("ClickTime") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")
                End If
                ' Me.dgvRunCardHeader.DataSource = Nothing

                Me.RunCardData.DefaultView.Sort = "ClickTime Desc"
                Me.dgvRunCardHeader.DataSource = Me.RunCardData
                Me.dgvRunCardHeader.Columns("ClickTime").Visible = False
                Me.dgvRunCardHeader.Columns("ID").Visible = False
                Me.dgvRunCardHeader.Columns("PartID").Visible = False
                LoadRunCardBody(Me.RunCardId)
                Me.dgvRunCardHeader.ClearSelection()
                Me.dgvRunCardHeader.Item("料件编号", 0).Selected = True
                Me.dgvRunCardHeader.FirstDisplayedScrollingRowIndex = 0
                For i As Integer = 0 To 200
                    If dgvRunCardHeader.Rows.Count > i Then
                        Me.dgvRunCardHeader.Rows(i).Cells(HeaderGrid.CheckBox).Value = "False"
                    Else
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#Region "打印"
    Private Sub 打印ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(ContextMenuHeader.Text)
    End Sub
#End Region

#Region "获取文件名"
    Private Function GetFileName(ByVal filePath As String) As String
        Dim pos As Integer
        Dim fileName As String
        pos = filePath.LastIndexOf("\")
        fileName = filePath.Substring(pos + 1)
        Return fileName
    End Function
#End Region

#Region "BOM更新检查"
    Private Function NeedUpdateBom() As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select 1 from M_RUNCARDBOMINFO_T(nolock) where ParentPartID=" & Me.RunCardPartId & " and ExpirationDate<>'' and convert(datetime,ExpirationDate,120 )< getdate()"
        Dim dt As DataTable = DAL.GetDataTable(StrSql)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "复制流程卡"
    Private Sub btnCopyRuncard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If dgvRunCardHeader.Rows.Count <= 0 Or dgvRunCardBody.Rows.Count <= 0 Then
            MessageBox.Show("请选择完整的工艺流程O_O")
            Exit Sub
        End If
        Dim frmDialog As New FrmRunCardCopy()
        frmDialog.RCPartID = Me.RunCardPartId
        frmDialog.RCPartNumber = Me.RunCardPn
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ''刷新SideBar1
            LoadRunCardHeader("")
            'LoadSideBar("", Me.RunCardData)
            LoadSideBarByClick("desc", RunCardType.UnFinish)
            '展开
            SideBar1.ExpandedPanel = sbPanelUnfinish
        End If
    End Sub
#End Region

#Region "打印流程卡"
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim o_Runcard = New strRuncard
        Try

            'If Me.RunCardPn = "" Then
            '    MessageBox.Show("请选择流程卡")
            '    Exit Sub
            'End If
            'If Me.RunCardStatus <> 1 Then
            '    MessageBox.Show("制作中和审核中的流程卡不允许打印")
            '    Exit Sub
            'End If
            'PrintRunCard(Me.RunCardPn)

            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then

                    '        o_Runcard.RuncardID = CInt(Me.dgvRunCardHeader.Item("ID", 1).Value.ToString())
                    '        o_Runcard.RunCardPN = Me.dgvRunCardHeader.Item("料件编号", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString()
                    '        o_Runcard.Status = CInt(Me.dgvRunCardHeader.Item("状态", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)
                    o_Runcard.RuncardID = row.Cells(HeaderGrid.ID).Value.ToString
                    o_Runcard.RunCardPN = row.Cells(HeaderGrid.PartNumber).Value.ToString
                    o_Runcard.Status = row.Cells(HeaderGrid.Status).Value.ToString
                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next

            If Me._runCardIDList.Count <= 0 Then
                MessageBox.Show("请选择流程卡")
                Exit Sub
            End If
            For Each RunCard As strRuncard In Me._runCardIDList
                If RunCard.RuncardID = "" Then
                    MessageBox.Show("请选择流程卡")
                    Exit Sub
                End If

                If RunCard.Status <> 1 Then
                    MessageBox.Show("制作中和审核中的流程卡不允许打印")
                    Exit Sub
                End If
            Next
            PrintRunCard("", Me._runCardIDList)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnPrint_Click", "WIP")
        Finally
            If (Not Me._runCardIDList Is Nothing) Then Me._runCardIDList.Clear()
        End Try
    End Sub
#End Region

#Region "刷新"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        '刷新
        LoadRunCardHeader("")
        'LoadSideBar("", Me.RunCardData)
        LoadSideBarByClick("", RunCardType.Finish)
    End Sub
#End Region

#Region "流程卡审核"
    Private Sub btnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckAutiStatus(row) Then
                        MessageBox.Show(row.Cells(HeaderGrid.PartNumber).Value.ToString & "非审核状态O_O")
                        Exit Sub
                    Else
                        If Me.IsQueryOldVersion = "false" Then
                            sql &= " update m_RunCard_t set Status=1,MODIFYTIME=getdate() where ID=" & row.Cells(HeaderGrid.ID).Value.ToString & "; insert into m_RunCardAuditLog_t select ID,PartID,'" & SysMessageClass.UseId & "',getdate(),PartNumber from m_RunCard_t(nolock) where ID=" & row.Cells(HeaderGrid.ID).Value.ToString
                        Else
                            sql &= " update m_RunCardoldversion_t set Status=1,MODIFYTIME=getdate() where ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
                        End If
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If Not String.IsNullOrEmpty(sql) Then
                If (MessageBox.Show("确定要审核确认", "提示信息", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                    sConn.ExecSql(sql)
                    '提示
                    MessageBox.Show("料件审核成功^_^")
                    '刷新SideBar1
                    LoadRunCardHeader("")
                    'LoadSideBar("", Me.RunCardData)
                    LoadSideBarByClick("Desc", RunCardType.Finish)
                    '展开
                    'SideBar1.ExpandedPanel = sbPanelFinish
                End If
            Else
                MessageBox.Show("无选中项")
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnAudit_Click", "WIP")
        End Try
    End Sub

    Private Function CheckAutiStatus(ByVal row As DataGridViewRow) As Boolean
        Dim sql As String = Nothing
        If Me.IsQueryOldVersion = "false" Then
            sql = "SELECT STATUS FROM M_RUNCARD_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql = "SELECT STATUS FROM M_RUNCARDOLDVERSION_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString = 2
            End If
        End Using
        Return False
    End Function
#End Region

#Region "RunCardHeader"

#Region "绑定 RunCard 头部"
    Public Enum HeaderGrid
        CheckBox = 0
        ClickTime
        ID
        PartId
        PartNumber
        Description
        Description1
        DrawingVer
        Shape
        DrawingFilePath
        Status
        ZStatus
        UserId
        InTime
        ModifyTime
        Remark
        OldVersion
    End Enum

    Public clo As New DataGridViewCheckBoxColumn
    Private Sub LoadRunCardHeader(ByVal sqlWhere As String, Optional ByVal isQquery As Boolean = False, Optional ByVal isQueryOldVersion As Boolean = False)
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = Nothing
        If Not isQueryOldVersion Then
            StrSql = "select '2013-10-10 10:10:10:001' ClickTime, RC.ID,RC.PartID,PN.PartNumber 料件编号,PN.Description 描述,PN.Description1 规格," & _
                                   " RC.DrawingVer 版本,RC.Shape 形态,RC.DrawingFilePath 图纸文件,RC.STATUS 状态," & _
                                   " CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END 制作状态,RC.UserID 创建人,RC.InTime 创建时间,MODIFYTIME 最近修改日期,REMARK as 备注,'false' as 旧版本  " & _
                                   "from m_RunCard_t(nolock) RC join M_RUNCARDPARTNUMBER_T(nolock) PN on RC.PartID=PN.ID where 1=1 " & sqlWhere & " ORDER BY RC.MODIFYTIME DESC,RC.INTIME DESC"
        Else
            StrSql = "select '2013-10-10 10:10:10:001' ClickTime, RC.ID,RC.PartID,PN.PartNumber 料件编号,PN.Description 描述,PN.Description1 规格," & _
                                " RC.DrawingVer 版本,RC.Shape 形态,RC.DrawingFilePath 图纸文件,RC.STATUS 状态," & _
                                " CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END 制作状态,RC.UserID 创建人,RC.InTime 创建时间,MODIFYTIME 最近修改日期,REMARK as 备注,'true' as 旧版本  " & _
                                "from m_RunCardOldVersion_t(nolock) RC join M_RUNCARDPARTNUMBER_T(nolock) PN on RC.PartID=PN.ID where 1=1 " & sqlWhere & " ORDER BY RC.MODIFYTIME DESC,RC.INTIME DESC"
        End If
        Dim dt As DataTable = DAL.GetDataTable(StrSql)
        Me.dgvRunCardHeader.Columns.Clear()
        Me.dgvRunCardHeader.DataSource = dt

        Me.dgvRunCardHeader.Columns("ClickTime").Visible = False
        Me.dgvRunCardHeader.Columns("ID").Visible = False
        Me.dgvRunCardHeader.Columns("PartID").Visible = False
        Me.dgvRunCardHeader.Columns("状态").Visible = False
        Me.dgvRunCardHeader.Columns("旧版本").Visible = False
        'Me.dgvRunCardHeader.Columns("备注").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If Not isQquery Then
            Me.RunCardData = dt
            Me.dv = New DataView(Me.RunCardData)
        End If
        clo.HeaderText = "选择"
        clo.Width = 50
        Me.dgvRunCardHeader.Columns.Insert(0, clo)
        For Each rw As DataGridViewColumn In Me.dgvRunCardHeader.Columns
            If rw.HeaderText = "选择" Then
                rw.ReadOnly = False
            Else
                rw.ReadOnly = True
            End If
        Next
    End Sub
#End Region

#Region "dgvRunCardHeader_CellClick"
    Private Sub dgvRunCardHeader_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                Me.RunCardId = CInt(Me.dgvRunCardHeader.Item("ID", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                Me.RunCardPartId = CInt(Me.dgvRunCardHeader.Item("PartID", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                Me.RunCardPn = Me.dgvRunCardHeader.Item("料件编号", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString()
                Me.RunCardStatus = CInt(Me.dgvRunCardHeader.Item("状态", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)
                Me.IsQueryOldVersion = Me.dgvRunCardHeader.Item("旧版本", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString
                '清除单元格及值
                rowSpan.Clear()
                rowValue = ""
                '显示 runcard 工站详情
                LoadRunCardBody(Me.RunCardId)
                '隐藏料件面板
                Me.dgvPartNumber.Visible = False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellClick", "WIP")
        End Try

    End Sub
#End Region

#Region "复制单元格 header "
    Private Sub tsmiHeaderCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCopy.Click
        If Not dgvRunCardHeader.CurrentCell Is Nothing Then
            Dim Selected As String = dgvRunCardHeader.CurrentCell.Value.ToString()
            Clipboard.SetDataObject(Selected)
        End If
    End Sub
#End Region

#Region "新增 header"
    Private Sub tmisHeaderAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderAdd.Click
        Try
            Dim frmHeader As New FrmRunCardHeaderEdit("add", Nothing)
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tmisHeaderAdd_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "修改 header"
    Private Sub tsmiHeaderModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderModify.Click
        Try
            If Me.tsmiHeaderModify.Tag Is Nothing Then
                MessageBox.Show("请选择O_O")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许修改 O_O")
                Exit Sub
            End If
            Dim frmHeader As New FrmRunCardHeaderEdit("modify", CType(Me.tsmiHeaderModify.Tag, DataGridViewRow))
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderModify_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "绑定右健菜单 header"
    Private Sub dgvRunCardHeader_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvRunCardHeader.CellContextMenuStripNeeded
        'If e.RowIndex >= 0 Then
        e.ContextMenuStrip = Me.ContextMenuHeader
        'End If
    End Sub
#End Region

#Region "鼠标右击处理 header"

    Public _runCardIDList As List(Of strRuncard) = New List(Of strRuncard)
    Private Sub dgvRunCardHeader_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRunCardHeader.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex > -1 Then
                Dim row As DataGridViewRow = dgvRunCardHeader.Rows(e.RowIndex)
                Me.tsmiHeaderModify.Tag = row
                Me.tsmiPartAdd.Tag = "N"
                '右健改变当前行号
                'dgvRunCardHeader.ClearSelection()
                dgvRunCardHeader.Rows(e.RowIndex).Selected = True
                dgvRunCardHeader.CurrentCell = dgvRunCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex)
                '
                Me.RunCardId = CInt(Me.dgvRunCardHeader.Item("ID", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                Me.RunCardPartId = CInt(Me.dgvRunCardHeader.Item("PartID", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                Me.RunCardPn = Me.dgvRunCardHeader.Item("料件编号", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString()
                Me.RunCardStatus = CInt(Me.dgvRunCardHeader.Item("状态", Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)
                '清除单元格及值
                rowSpan.Clear()
                rowValue = ""
                '显示 runcard 工站详情
                LoadRunCardBody(Me.RunCardId)
            Else
                Me.tsmiHeaderModify.Tag = Nothing
            End If
        End If
    End Sub
#End Region

#Region "删除"
    Private Sub tsmiHeaderDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderDelete.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckStatus(row) Then
                        MessageBox.Show("料件" & row.Cells(HeaderGrid.PartNumber).Value.ToString & "非制作中的流程卡，不允许删除", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        GetReleateInfo(sql, row)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("无选中项")
                Exit Sub
            End If
            If MessageBox.Show("确认要删除选中的流程卡信息", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                sConn.ExecSql(sql)
                MessageBox.Show("删除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("", RunCardType.Finish)
                Me.dgvRunCardBody.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function CheckStatus(ByVal row As DataGridViewRow) As Boolean
        Dim sql As String = Nothing
        If row.Cells(HeaderGrid.OldVersion).Value.ToString = "false" Then
            sql = "SELECT STATUS FROM M_RUNCARD_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql = "SELECT STATUS FROM M_RUNCARDOLDVERSION_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0) = 0
            End If
        End Using
        Return False
    End Function


    Private Sub GetReleateInfo(ByRef sql As String, ByVal row As DataGridViewRow)
        If row.Cells(HeaderGrid.OldVersion).Value.ToString = "false" Then
            sql &= " INSERT INTO M_RUNCARDLOG_T SELECT ID, PARTID,'','" & VbCommClass.VbCommClass.UseId & "'," & vbNewLine & _
            " STATUS, INTIME, DRAWINGVER, DRAWINGFILEPATH, 'DELETE', GETDATE(),PARTNUMBER" & vbNewLine & _
            " FROM M_RUNCARD_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " " & vbNewLine & _
            " DELETE A FROM M_RUNCARDDETAILCHECKITEM_T A,M_RUNCARDDETAIL_T B " & vbNewLine & _
            " WHERE B.RUNCARDID=" & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " AND B.PARTNUMBER=A.PARTNUMBER AND B.STATIONID=B.STATIONID " & vbNewLine & _
            " DELETE A FROM M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T B " & vbNewLine & _
            " WHERE B.RUNCARDID = " & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " AND B.ID=A.RUNCARDDETAILID" & vbNewLine & _
            " DELETE FROM M_RUNCARDDETAIL_T WHERE RUNCARDID=" & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " DELETE FROM M_RUNCARD_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & " "
        Else
            sql &= " DELETE A FROM M_RUNCARDPARTDETAILOLDVERSION_T A,M_RUNCARDDETAILOLDVERSION_T B " & vbNewLine & _
            " WHERE B.RUNCARDID = " & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " AND B.ID=A.RUNCARDDETAILID" & vbNewLine & _
            " DELETE FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=" & row.Cells(HeaderGrid.ID).Value.ToString & "" & vbNewLine & _
            " DELETE FROM M_RUNCARDOLDVERSION_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & " "
        End If
    End Sub
#End Region

#Region "取消生效"

    Private Sub tsmiHeaderCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCancel.Click
        Try
            Dim index As Integer = 0
            Dim sql As String = String.Empty
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckCancelStatus(row) Then
                        Exit Sub
                    Else
                        SaveRejectStatus(sql, row)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("无选中项")
                Exit Sub
            End If
            If MessageBox.Show("确认要取消生效选中的流程卡信息", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                sConn.ExecSql(sql)
                MessageBox.Show("取消生效成功", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("Desc", RunCardType.UnFinish)
                Me.dgvRunCardBody.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function CheckCancelStatus(ByVal row As DataGridViewRow) As Boolean
        Dim sConn As New SysDataBaseClass
        Dim sql As String = Nothing
        If row.Cells(HeaderGrid.OldVersion).Value.ToString = "false" Then
            sql = "SELECT A.STATUS FROM M_RUNCARD_T A WHERE A.ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql = "SELECT A.STATUS FROM M_RUNCARDOLDVERSION_T A WHERE A.ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0) = 2 Then
                    MessageBox.Show(row.Cells(HeaderGrid.PartNumber).Value.ToString & "该料件的流程卡还在审核中，不允许取消生效", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Return False
                ElseIf dt.Rows(0)(0) = 0 Then
                    MessageBox.Show(row.Cells(HeaderGrid.PartNumber).Value.ToString & "该料件的流程卡还在制作中，不允许取消生效", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        End Using
        Return True
    End Function

#End Region

#Region "驳回"
    Private Sub tsmiHeaderReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderReject.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckRejectStatus(row) Then
                        Exit Sub
                    Else
                        SaveRejectStatus(sql, row)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("无选中项")
                Exit Sub
            End If
            If MessageBox.Show("确认要驳回" & Me.RunCardPn & "的流程卡信息", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                sConn.ExecSql(sql)
                MessageBox.Show("驳回成功", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("Desc", RunCardType.UnFinish)
                Me.dgvRunCardBody.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function CheckRejectStatus(ByVal row As DataGridViewRow) As Boolean
        Dim sConn As New SysDataBaseClass
        Dim sql As String = Nothing
        If row.Cells(HeaderGrid.OldVersion).Value.ToString = "false" Then
            sql = "SELECT A.STATUS FROM M_RUNCARD_T A WHERE A.ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql = "SELECT A.STATUS FROM M_RUNCARDOLDVERSION_T A WHERE A.ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0) = 1 Then
                    MessageBox.Show(row.Cells(HeaderGrid.PartNumber).Value.ToString & "该料件的流程卡已是审核状态，不允许驳回", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Return False
                ElseIf dt.Rows(0)(0) = 0 Then
                    MessageBox.Show(row.Cells(HeaderGrid.PartNumber).Value.ToString & "该料件的流程卡还在制作中，不允许驳回", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        End Using
        Return True
    End Function

    Private Sub SaveRejectStatus(ByRef sql As String, ByVal row As DataGridViewRow)
        If row.Cells(HeaderGrid.OldVersion).Value.ToString = "false" Then
            sql &= " UPDATE M_RUNCARD_T SET STATUS=0,INTIME=GETDATE(),USERID='" & VbCommClass.VbCommClass.UseId & "' WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql &= " UPDATE M_RUNCARDOLDVERSION_T SET STATUS=0,INTIME=GETDATE(),USERID='" & VbCommClass.VbCommClass.UseId & "' WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If
    End Sub
#End Region

#Region "导入"
    Private Sub tsmiHeaderImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderImport.Click
        Try
            Dim frmStation As New FrmRunCardImportStation(Me.RunCardId, Me.RunCardPn, "Import", "true")
            frmStation.ShowDialog()
            '刷新
            LoadRunCardHeader("")
            'LoadSideBar("", Me.RunCardData)
            LoadSideBarByClick("desc", RunCardType.UnFinish)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "导出"

    Private Sub tsmiHeaderExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderExport.Click
        Dim o_Runcard = New strRuncard
        Dim strRuncardPNList As String = String.Empty
        Try
            'If Me.RunCardPn = "" Then
            '    MessageBox.Show("请选择流程卡")
            '    Exit Sub
            'End If

            'If Me.RunCardStatus <> 1 Then
            '    MessageBox.Show("制作中和审核中的流程卡不允许导出!")
            '    Exit Sub
            'End If
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then

                    o_Runcard.RuncardID = row.Cells(HeaderGrid.ID).Value.ToString
                    o_Runcard.RunCardPN = row.Cells(HeaderGrid.PartNumber).Value.ToString
                    o_Runcard.Status = row.Cells(HeaderGrid.Status).Value.ToString
                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next

            If _runCardIDList.Count <= 0 Then
                MessageBox.Show("请选择流程卡")
                Exit Sub
            End If

            Dim frmStation As New FrmRunCardImportStation(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)

            For Each o_strRunCard As strRuncard In _runCardIDList
                If Val(o_strRunCard.Status) <> 1 Then
                    MessageBox.Show("制作中和审核中的流程卡不允许导出!")
                    Exit Sub
                End If
                strRuncardPNList &= o_strRunCard.RunCardPN & ","
            Next

            strRuncardPNList = strRuncardPNList.Substring(0, strRuncardPNList.Length - 1)
            frmStation.m_RuncardList = strRuncardPNList

            '刷新
            frmStation.SelectPath(Me.RunCardPn, Me.RunCardId)

        Catch ex As Exception

        Finally
            If Not IsNothing(Me._runCardIDList) Then Me._runCardIDList.Clear()
        End Try
    End Sub

    'Private Sub tsmiHeaderExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderExport.Click
    '    Try
    '        If Me.RunCardPn = "" Then
    '            MessageBox.Show("请选择流程卡")
    '            Exit Sub
    '        End If

    '        If Me.RunCardStatus <> 1 Then
    '            MessageBox.Show("制作中和审核中的流程卡不允许导出!")
    '            Exit Sub
    '        End If

    '        Dim frmStation As New FrmRunCardImportStation(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
    '        'If frmStation.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        '刷新
    '        frmStation.SelectPath(Me.RunCardPn, Me.RunCardId)
    '        'LoadRunCardHeader("")
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#End Region

#Region "RunCardBody"
    Private dtBody As DataTable
#Region "绑定 RunCard 身体"
    Private Sub LoadRunCardBody(ByVal runCardId As Integer)
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sql As String = Nothing
        Dim sqlTail As String = Nothing
        If Me.IsQueryOldVersion = "false" Then

            sql = "select A.ID,B.ID 工站ID,A.StationSQ 工序,B.StationNo 工站编号 ,B.StationName 工站名称,CAST(B.SectionID AS VARCHAR) 工段ID,cast(A.WorkingHours as varchar) 工时,A.Equipment 设备治具,A.ProcessStandard 工艺标准,A.NEWPROCESSSTANDARD 新工艺标准,A.Remark 备注,A.SopFilePath SOP,A.Status 状态,A.UserID 修改人,A.InTime 修改时间 " & _
                 "from m_RunCardDetail_t(nolock) A  join m_RUNCARDStation_t(nolock) B on A.StationID=B.ID " & _
                 "where A.RunCardID=" & runCardId & " order by A.StationSQ ; "
            sqlTail = "select sum(RCD.WorkingHours)  WorkingHours " & _
                                    "from m_RunCardDetail_t(nolock) RCD join m_RUNCARDStation_t(nolock) ST on RCD.StationID=ST.ID " & _
                                    "where RCD.RunCardID=" & runCardId & " group by ST.SectionID ; "
        Else
            sql = "select A.ID,B.ID 工站ID,A.StationSQ 工序,B.StationNo 工站编号 ,B.StationName 工站名称,CAST(B.SectionID AS VARCHAR) 工段ID,cast(A.WorkingHours as varchar) 工时,A.Equipment 设备治具,A.ProcessStandard 工艺标准,A.NEWPROCESSSTANDARD 新工艺标准,A.Remark 备注,A.SopFilePath SOP,A.Status 状态,A.UserID 修改人,A.InTime 修改时间 " & _
               "from m_RunCardDetailOldVersion_t(nolock) A  join M_RUNCARDSTATION_T(nolock) B on A.StationID=B.ID " & _
               "where A.RunCardID=" & runCardId & " order by A.StationSQ ; "
            sqlTail = "select sum(RCD.WorkingHours)  WorkingHours " & _
                                    "from m_RunCardDetailOldVersion_t(nolock) RCD join M_RUNCARDSTATION_T(nolock) ST on RCD.StationID=ST.ID " & _
                                    "where RCD.RunCardID=" & runCardId & " group by ST.SectionID ; "
        End If

        Dim ds As DataSet = DAL.GetDataSet(sql & vbNewLine & sqlTail)
        If Not ds Is Nothing Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dtTail As DataTable = ds.Tables(1)
                Dim preHours As Integer = 0
                Dim proHours As Integer = 0
                Dim sufHours As Integer = 0
                For index As Integer = 0 To dtTail.Rows.Count - 1
                    If index = 0 Then
                        preHours = dtTail.Rows(index)("WorkingHours").ToString
                    ElseIf index = 1 Then
                        proHours = dtTail.Rows(index)("WorkingHours").ToString
                    ElseIf index = 2 Then
                        sufHours = dtTail.Rows(index)("WorkingHours").ToString
                    End If
                Next
                'rowValue = "总工时(s): " & Convert.ToDouble(preHours + proHours + sufHours) * (1 + 0.005 * dt.Rows.Count) & "  前加工(S): " & preHours.ToString & "  产线(s): " & Convert.ToDouble(preHours + proHours + sufHours) * (1 + 0.005 * dt.Rows.Count) - sufHours - preHours & "  成型(s): " & sufHours.ToString
                '添加一空行(汇总)
                'dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                'dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, "总工时(s): " & Convert.ToDouble(preHours + proHours + sufHours) * (1 + 0.005 * dt.Rows.Count), Nothing, "前加工(S): " & preHours.ToString, "产线(s): " & Convert.ToDouble(preHours + proHours + sufHours) * (1 + 0.005 * dt.Rows.Count) - sufHours - preHours, "成型(s): " & sufHours.ToString, Nothing, Nothing, Nothing, Nothing)
                dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, "总工时(s): " & Convert.ToDouble(preHours + proHours + sufHours), Nothing, "前加工(S): " & preHours.ToString, "产线(s): " & Convert.ToDouble(preHours + proHours + sufHours) - sufHours - preHours, "成型(s): " & sufHours.ToString, Nothing, Nothing, Nothing, Nothing)
                dgvRunCardBody.DataSource = dt
                '禁止排序
                For Each column As DataGridViewColumn In dgvRunCardBody.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                dgvRunCardBody.Rows(dt.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
                If Me.RunCardStatus = 1 Or Me.RunCardStatus = 2 Then
                    dgvRunCardBody.ReadOnly = True
                End If
                dgvRunCardBody.Columns("ID").Visible = False
                dgvRunCardBody.Columns("工站ID").Visible = False
                dgvRunCardBody.Columns("工站编号").Visible = False
                dgvRunCardBody.Columns("工段ID").Visible = False
                dgvRunCardBody.Columns("状态").Visible = False
                dgvRunCardBody.Columns("新工艺标准").Visible = False
                'dgvRunCardBody.Columns("修改时间").Visible = False
                dgvRunCardBody.Columns("工艺标准").CellTemplate.Style.WrapMode = DataGridViewTriState.True
                dgvRunCardBody.Columns("工序").Width = 50
                dgvRunCardBody.Columns("工时").Width = 100
                dgvRunCardBody.Columns("设备治具").Width = 120
                dgvRunCardBody.Columns("工站名称").Width = 140
                ' "Add for auto update"
                If Me.RunCardStatus = 0 Then
                    'dgvRunCardBody.ReadOnly = False
                    'Me.dgvRunCardBody.EditMode = DataGridViewEditMode.EditOnEnter
                    'dgvRunCardBody.Columns("工序").ReadOnly = True
                    'dgvRunCardBody.Columns("修改人").ReadOnly = True
                    'dgvRunCardBody.Columns("修改时间").ReadOnly = True
                    'dgvRunCardBody.Columns("工站名称").ReadOnly = True
                    'dgvRunCardBody.Columns("SOP").ReadOnly = True
                    dgvRunCardBody.ReadOnly = True
                Else
                    dgvRunCardBody.ReadOnly = True
                    Me.dgvRunCardBody.Controls.Clear()
                End If

                dgvRunCardBody.Rows(dt.Rows.Count - 1).ReadOnly = True
                dtBody = dt.Clone
            Else
                dgvRunCardBody.DataSource = dt
                dtBody = dt.Clone
            End If
        Else
            dgvRunCardBody.DataSource = IIf(dtBody Is Nothing, Nothing, dtBody)
        End If
    End Sub
#End Region

#Region "dgvRunCardBody_CellClick"
    Private Sub dgvRunCardBody_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                '最后一行是汇总行
                If e.RowIndex <> dgvRunCardBody.Rows.Count - 1 Then
                    Me.RunCardDetailId = CInt(Me.dgvRunCardBody.Item("ID", Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    Me.RunCardStationId = CInt(Me.dgvRunCardBody.Item("工站ID", Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    '加载料件信息
                    Me.LoadPartGrid(Me.RunCardDetailId)
                    '显示料件面板
                    Me.dgvPartNumber.Visible = True
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellClick", "WIP")
        End Try
    End Sub
#End Region

#Region "复制单元格 body"
    Private Sub tsmiBodyCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyCopy.Click
        If Not dgvRunCardBody.CurrentCell Is Nothing Then
            Dim Selected As String = dgvRunCardBody.CurrentCell.Value.ToString()
            Clipboard.SetDataObject(Selected)
        End If
    End Sub
#End Region

#Region "新增 body"
    Private Sub tsmiBodyAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyAdd.Click
        Try
            If Me.RunCardPartId = 0 Then
                MessageBox.Show("请选择!")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许新增 O_O")
                Exit Sub
            End If
            'Dim frmEdit As New FrmRunCardBodyEdit(Me.RunCardId, Me.RunCardPn, "add", Nothing)
            'If frmEdit.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    '刷新
            '    LoadRunCardBody(Me.RunCardId)
            '    If Me.RunCardStatus = 1 Then
            '        Me.RunCardStatus = 0
            '        LoadRunCardHeader("")
            '        LoadSideBarByClick("desc", RunCardType.UnFinish)
            '    End If
            'End If
            Dim frmEdit As New FrmRunCardBodyEdit(Me.RunCardId, Me.RunCardPn, "add", Nothing, Me, Me.IsQueryOldVersion)
            frmEdit.ShowDialog()
            '刷新
            LoadRunCardBody(Me.RunCardId)
            If Me.RunCardStatus = 1 Then
                Me.RunCardStatus = 0
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If

            If dgvRunCardBody.Rows.Count > 0 Then
                dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - IIf(dgvRunCardBody.Rows.Count > 10, 10, 1)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiAdd_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "修改 body"
    Private Sub tsmiBodyModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyModify.Click
        Try
            If Me.tsmiBodyModify.Tag Is Nothing Then
                MessageBox.Show("请选择O_O")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许修改 O_O")
                Exit Sub
            End If
            Dim frmDialog As New FrmRunCardBodyEdit(Me.RunCardId, Me.RunCardPn, "modify", CType(Me.tsmiBodyModify.Tag, DataGridViewRow), Me.IsQueryOldVersion)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardBody(Me.RunCardId)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiModify_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "删除 body"
    Private Sub tsmiBodyDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyDelete.Click
        Try
            If Me.tsmiBodyDelete.Tag Is Nothing Then
                MessageBox.Show("请选择O_O")
                Exit Sub
            End If
            Dim row As DataGridViewRow = CType(Me.tsmiBodyDelete.Tag, DataGridViewRow)
            Dim runCardDetialId As Integer = CInt(row.Cells("ID").Value.ToString)
            Dim stationNo As String = row.Cells("工站编号").Value.ToString
            Dim stationName As String = row.Cells("工站名称").Value.ToString
            '审核中：不可删除
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许删除 O_O")
                Exit Sub
            End If
            '
            If (MessageBox.Show("确认删除所选工站:""" & stationNo & "-" & stationName & """ ?", "", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                Dim StrSql As String = Nothing
                If Me.IsQueryOldVersion = "false" Then
                    StrSql = "delete m_RunCardDetail_t where ID=" & runCardDetialId & "" & vbNewLine & _
                " UPDATE  M_RUNCARDDETAIL_T  SET STATIONSQ=B.ID FROM M_RUNCARDDETAIL_T A," & vbNewLine & _
                " (SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM M_RUNCARDDETAIL_T WHERE RUNCARDID=" & Me.RunCardId & ") B" & vbNewLine & _
                " WHERE A.RUNCARDID=" & Me.RunCardId & " AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" & vbNewLine & _
                " DELETE FROM M_RUNCARDPARTDETAIL_T WHERE RUNCARDDETAILID=" & runCardDetialId & "" & vbNewLine & _
                " DELETE FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _runCardStationId & "" & vbNewLine & _
                " update m_RunCard_t set Status=0 where ID=" & Me.RunCardId & ";"
                Else
                    StrSql = "delete m_RunCardDetailOldVersion_t where ID=" & runCardDetialId & "" & vbNewLine & _
               " UPDATE  M_RUNCARDDETAILOldVersion_T  SET STATIONSQ=B.ID FROM M_RUNCARDDETAILOldVersion_T A," & vbNewLine & _
               " (SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM M_RUNCARDDETAILOldVersion_T WHERE RUNCARDID=" & Me.RunCardId & ") B" & vbNewLine & _
               " WHERE A.RUNCARDID=" & Me.RunCardId & " AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" & vbNewLine & _
               " DELETE FROM M_RUNCARDPARTDETAILOldVersion_T WHERE RUNCARDDETAILID=" & runCardDetialId & "" & vbNewLine & _
               " update m_RunCardOldVersion_t set Status=0 where ID=" & Me.RunCardId & ";"
                End If
                Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
                DAL.ExecSql(StrSql)
                '刷新
                LoadRunCardBody(Me.RunCardId)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnDelete_Click", "sys")
        End Try
    End Sub
#End Region

#Region "重置"
    Private Sub RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RToolStripMenuItem.Click
        Try
            If Me.RToolStripMenuItem.Tag Is Nothing Then
                MessageBox.Show("请选择O_O")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许修改 O_O")
                Exit Sub
            End If
            Dim frmDialog As New FrmRunCardBodyEdit(Me.RunCardId, Me.RunCardPn, "reset", CType(Me.RToolStripMenuItem.Tag, DataGridViewRow), Me, Me.IsQueryOldVersion)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardBody(Me.RunCardId)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiModify_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "确认body"
    Private Sub tsmiBodyConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyConfirm.Click
        Try
            If Me.dgvRunCardBody.Rows.Count <= 0 Then
                MessageBox.Show("请选择O_O")
                Exit Sub
            End If
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckSureStatus(row) Then
                        MessageBox.Show("非制作中状态不允许确认O_O")
                    Else
                        If Me.IsQueryOldVersion = "false" Then
                            sql &= " update m_RunCard_t set Status=2,remark=null,modifytime=getdate(),userid='" & VbCommClass.VbCommClass.UseId & "' where ID=" & row.Cells(HeaderGrid.ID).Value.ToString
                        Else
                            sql &= " update m_RunCardOldVersion_t set Status=2,remark=null,modifytime=getdate(),userid='" & VbCommClass.VbCommClass.UseId & "' where ID=" & row.Cells(HeaderGrid.ID).Value.ToString
                        End If
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("无选中项")
                Exit Sub
            End If
            If MessageBox.Show("确定要确认选中的流程卡信息", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                sConn.ExecSql(sql)
                '
                LoadRunCardHeader("")
                'LoadRunCardBody(Me.RunCardId)
                '刷新
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("desc", RunCardType.Audit)
                '展开
                'SideBar1.ExpandedPanel = sbPanelAudit
                '提示
                MessageBox.Show("料件:" & Me.RunCardPn & "确认成功^_^")
                'dgvRunCardBody.ReadOnly = True
                'Me.dgvRunCardBody.Controls.Clear()
                'LoadRunCardBody(Me.RunCardId)
                Me.dgvRunCardBody.DataSource = Nothing
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnComfrm_Click", "sys")
        End Try
    End Sub

    Private Function CheckSureStatus(ByVal row As DataGridViewRow)
        Dim sql As String = Nothing
        If Me.IsQueryOldVersion = "false" Then
            sql = "SELECT STATUS FROM M_RUNCARD_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        Else
            sql = "SELECT STATUS FROM M_RUNCARDOLDVERSION_T WHERE ID=" & row.Cells(HeaderGrid.ID).Value.ToString & ""
        End If

        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString = 0
            End If
        End Using
        Return False
    End Function
#End Region

#Region "复制工站"
    Private Sub ToolCopyBodyStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCopyBodyStation.Click
        'If ToolCopyBodyStation.Tag Is Nothing Then
        '    MessageBox.Show("请选择其中一个工站O_O")
        '    Exit Sub
        'End If
        If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
            MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核或是已生效状态,不允许修改 O_O")
            Exit Sub
        End If

        Dim frmStationCopy As New FrmRunCardStationCopy(Me.RunCardId, Me.RunCardStationId, "copy", CType(Me.RToolStripMenuItem.Tag, DataGridViewRow), Me.IsQueryOldVersion)

        If frmStationCopy.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '刷新
            LoadRunCardBody(Me.RunCardId)

        End If
        ' frmStationCopy.RCOldStation = Me.RunCardStationId
        ' frmStationCopy.ShowDialog()
        '  End Using
    End Sub
#End Region

#Region "绑定右健菜单"
    Private Sub dgvRunCardBody_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvRunCardBody.CellContextMenuStripNeeded
        'If e.RowIndex >= 0 Then
        e.ContextMenuStrip = Me.ContextMenuBody
        'End If
    End Sub
#End Region

#Region "鼠标右击处理 body"
    Private Sub dgvRunCardBody_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRunCardBody.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex > -1 Then
                '最后一行是汇总行
                If e.RowIndex <> dgvRunCardBody.Rows.Count - 1 Then
                    dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    dgvRunCardBody.CurrentCell.Selected = True
                    Dim row As DataGridViewRow = dgvRunCardBody.CurrentRow
                    Me.tsmiBodyModify.Tag = row
                    Me.tsmiBodyDelete.Tag = row
                    Me.RToolStripMenuItem.Tag = row
                    '右健改变当前行号
                    dgvRunCardBody.ClearSelection()
                    dgvRunCardBody.Rows(e.RowIndex).Selected = True
                    dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    '
                    Me.RunCardDetailId = CInt(Me.dgvRunCardBody.Item("ID", Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    Me.RunCardStationId = CInt(Me.dgvRunCardBody.Item("工站ID", Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    '加载料件信息
                    Me.LoadPartGrid(Me.RunCardDetailId)
                    '显示料件面板
                    Me.dgvPartNumber.Visible = True
                End If
            Else
                Me.tsmiBodyModify.Tag = Nothing
                Me.tsmiBodyDelete.Tag = Nothing
                Me.RToolStripMenuItem.Tag = Nothing
            End If
        End If
    End Sub

#End Region

#Region "字体颜色处理 body"
    Private Sub dgvRunCardBody_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvRunCardBody.DataBindingComplete
        For Each item As DataGridViewRow In dgvRunCardBody.Rows
            Select Case item.Cells("工段ID").Value.ToString()
                Case "1" '前段加工
                    item.Cells("工站名称").Style.ForeColor = Color.Green
                    'item.DefaultCellStyle.ForeColor = Color.Black
                Case "2" '产线加工
                    item.Cells("工站名称").Style.ForeColor = Color.Blue
                    'item.DefaultCellStyle.ForeColor = Color.Green
                Case "3" '成型加工
                    item.Cells("工站名称").Style.ForeColor = Color.Black
                    'item.DefaultCellStyle.ForeColor = Color.Blue
            End Select
            'If item.Index Mod 2 = 0 Then
            '    item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            'End If
        Next
    End Sub
#End Region

#End Region

#Region "RunCardPart"

#Region "绑定 RunCard 料件"
    Private Sub LoadPartGrid(ByVal runCardDetailId As Integer)
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = Nothing
        If Me.IsQueryOldVersion = "false" Then
            StrSql = "select B.ID,B.PartNumber 料件编号,B.Description 品名,B.Description1 规格 from  m_RunCardPartDetail_t(nolock) A join M_RUNCARDPARTNUMBER_T(nolock) B on A.PartID=B.ID " & _
                        " where A.RunCardDetailID=" & runCardDetailId & " "
        Else
            StrSql = "select B.ID,B.PartNumber 料件编号,B.Description 品名,B.Description1 规格 from  m_RunCardPartDetailOldVersion_t(nolock) A join M_RUNCARDPARTNUMBER_T(nolock) B on A.PartID=B.ID " & _
                        " where A.RunCardDetailID=" & runCardDetailId & " "
        End If
        Dim dt As DataTable = DAL.GetDataTable(StrSql)
        dgvPartNumber.DataSource = dt
        '"规格"列全屏显示
        dgvPartNumber.Columns("ID").Visible = False
        dgvPartNumber.Columns("规格").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub

#End Region

#Region "增加料件信息"
    Private Sub menuAddPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiPartAdd.Click
        Try
            '审核中：不可修改
            If Me.RunCardStatus = 2 Then
                MessageBox.Show("料件:""" & Me.RunCardPn & """ 待审核状态,不允许修改 O_O")
                Exit Sub
            End If
            '检查BOM是否需要更新
            If NeedUpdateBom() Then
                MessageBox.Show("料件""" & Me.RunCardPn & """BOM中的部分物料已失效，请及时更新BOM")
            End If
            Dim frmDialog As New FrmRunCardPartDetail(Me.RunCardDetailId, Me.RunCardStationId, Me.RunCardId, Me.RunCardPartId, Me.IsQueryOldVersion)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ''刷新
                LoadPartGrid(Me.RunCardDetailId)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "menuAddPart_Click", "WIP")
        End Try
    End Sub
#End Region

#End Region

#Region "查询"
    Private Sub tsmiHeaderSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderSearch.Click
        Try
            Dim frmQuery As New FrmRunCardQuery
            If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'If frmQuery.SqlWhere <> "" Then
                '    LoadRunCardHeader(frmQuery.SqlWhere)
                'End If
                LoadRunCardHeader(frmQuery.SqlWhere, True, frmQuery.IsQueryOldVersion)
                dgvRunCardBody.DataSource = Nothing
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardQuery", "tsmiHeaderSearch_Click", "WIP")
        End Try
    End Sub
#End Region

#Region "打印流程卡"
    Private Sub PrintRunCard(Optional ByVal pn As String = "", Optional ByVal o_strRuncard As List(Of strRuncard) = Nothing)  'ByVal pn As string
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        'Dim outputFile As String = Environment.CurrentDirectory + "\" & o_strRuncard.RunCardPN & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"
        Try

            If Not IsNothing(o_strRuncard) Then
                For Each o_strTempRuncard In o_strRuncard
                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPN & ".xlsx" & ","
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPN & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"

                    Dim frmStation As New FrmRunCardImportStation(o_strTempRuncard.RuncardID, o_strTempRuncard.RunCardPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                    ' frmStation.runCardPn = Me.RunCardPn
                    frmStation.runCardPn = o_strTempRuncard.RunCardPN

                    Using dt As DataTable = sConn.GetDataTable(frmStation.GetExportSql(o_strTempRuncard.RunCardPN))
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If SysDataBaseClass.Import2ExcelByAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt), errorMsg) Then  'outputFile
                                'Using frmshow As New FrmShowRunCard()
                                '    frmshow.filePath = outputFile
                                '    frmshow.ShowDialog()
                                'End Using
                            Else
                                MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("料件找不到对应的流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                Next

                outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Using FrmShow As New FrmShowRunCard()
                    FrmShow.filePath = outputFileList
                    FrmShow.ShowDialog()
                End Using
            Else
                o_outputFile = Environment.CurrentDirectory + "\" & pn & ".xlsx"
                Dim frmStation As New FrmRunCardImportStation(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                FrmStation.runCardPn = Me.RunCardPn
                Using dt As DataTable = sConn.GetDataTable(frmStation.GetExportSql(Me.RunCardPn))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        If SysDataBaseClass.Import2ExcelByAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt), errorMsg) Then
                            Using frmshow As New FrmShowRunCard()
                                frmshow.filePath = o_outputFile
                                frmshow.ShowDialog()
                            End Using
                        Else
                            MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("料件找不到对应的流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not String.IsNullOrEmpty(outputFileList) Then
                For Each outputFile As Object In outputFileList.Split(",")
                    If File.Exists(outputFile) Then
                        File.Delete(outputFile)
                    End If
                Next
            Else
                If File.Exists(o_outputFile) Then
                    File.Delete(o_outputFile)
                End If
            End If
        End Try
    End Sub

    'Private Sub PrintRunCard(Optional ByVal pn As String = "", Optional ByVal o_strRuncard As List(Of strRuncard) = Nothing)  'ByVal pn As string
    '    Dim errorMsg As String = Nothing
    '    'Dim outputFile As String = Environment.CurrentDirectory + "\" & o_strRuncard.RunCardPN & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"
    '    Try
    '        Dim frmStation As New FrmRunCardImportStation(o_strRuncard.RuncardID, o_strRuncard.RunCardPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
    '        ' frmStation.runCardPn = Me.RunCardPn
    '        frmStation.runCardPn = o_strRuncard.RunCardPN

    '        Using dt As DataTable = sConn.GetDataTable(frmStation.GetExportSql())
    '            If dt.Rows.Count > 0 Then
    '                dt.TableName = "RunCard"
    '                If SysDataBaseClass.Import2ExcelByAs(frmStation.filePath, outputFile, dt, frmStation.GetVariables(dt), errorMsg) Then
    '                    Using frmshow As New FrmShowRunCard()
    '                        frmshow.filePath = outputFile
    '                        frmshow.ShowDialog()
    '                    End Using
    '                Else
    '                    MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If
    '            Else
    '                MessageBox.Show("料件找不到对应的流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If File.Exists(outputFile) Then
    '            File.Delete(outputFile)
    '        End If
    '    End Try
    'End Sub

#End Region

    Private Sub tsmiHeaderPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderPrint.Click
        Dim o_Runcard As New strRuncard
        Try
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then

                    o_Runcard.RuncardID = row.Cells(HeaderGrid.ID).Value.ToString
                    o_Runcard.RunCardPN = row.Cells(HeaderGrid.PartNumber).Value.ToString
                    o_Runcard.Status = row.Cells(HeaderGrid.Status).Value.ToString
                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next
            If _runCardIDList.Count <= 0 Then
                MessageBox.Show("请选择流程卡")
                Exit Sub
            End If

            For Each o_strRunCard As strRuncard In _runCardIDList
                If Val(o_strRunCard.Status) <> 1 Then
                    MessageBox.Show("制作中和审核中的流程卡不允许导出!")
                    Exit Sub
                End If
            Next

            PrintRunCard("", _runCardIDList)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderPrint_Click", "WIP")
        Finally
            If Not IsNothing(Me._runCardIDList) Then
                Me._runCardIDList.Clear()
            End If
        End Try
    End Sub

    'Private Sub tsmiHeaderPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderPrint.Click
    '    Try
    '        If Me.RunCardPn = "" Then
    '            MessageBox.Show("请选择流程卡")
    '            Exit Sub
    '        End If
    '        If Me.RunCardStatus <> 1 Then
    '            MessageBox.Show("制作中和审核中的流程卡不允许打印")
    '            Exit Sub
    '        End If
    '        PrintRunCard(Me.RunCardPn)

    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderPrint_Click", "WIP")
    '    End Try
    'End Sub

    Private Sub dgvRunCardHeader_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellDoubleClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If e.ColumnIndex = 7 Then
                    Dim imageFile As String = dgvRunCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                    If imageFile <> "" Then
                        Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                        frmDialog.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellDoubleClick", "WIP")
        End Try
    End Sub

#Region "横向合并单元格"
    Private Sub HorizontalMerageCell(ByVal dgv As DataGridView, ByVal celArgs As DataGridViewCellPaintingEventArgs, ByVal minColIndex As Integer, ByVal maxColIndex As Integer)
        If celArgs.RowIndex = -1 Or celArgs.ColumnIndex > maxColIndex Or celArgs.ColumnIndex < minColIndex Then
            Exit Sub
        End If
        Dim rect As New Rectangle
        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
            celArgs.Graphics.FillRectangle(backColorBrush, celArgs.CellBounds)
        End Using
        'celArgs.Handled = True
        'IsPostMerage(dgv, celArgs, minColIndex, maxColIndex)
        Dim rectArgs As Rectangle = CType(rowSpan(celArgs.ColumnIndex), Rectangle)
        'If rectArgs.X <> celArgs.CellBounds.X Or rectArgs.Y <> celArgs.CellBounds.Y Or rectArgs.Width <> celArgs.CellBounds.Width Or rectArgs.Height <> celArgs.CellBounds.Height Then
        rectArgs.X = celArgs.CellBounds.X
        rectArgs.Y = celArgs.CellBounds.Y
        rectArgs.Width = celArgs.CellBounds.Width
        rectArgs.Height = celArgs.CellBounds.Height
        rowSpan(celArgs.ColumnIndex) = rectArgs
        '
        Dim width As Integer = 0
        Dim height As Integer = celArgs.CellBounds.Height
        For index As Integer = minColIndex To maxColIndex
            width += CType(rowSpan(index), Rectangle).Width
        Next
        Dim rectBegin As Rectangle = CType(rowSpan(minColIndex), Rectangle)
        Dim rectEnd As Rectangle = CType(rowSpan(maxColIndex), Rectangle)
        Dim reBounds As New Rectangle()
        reBounds.X = rectBegin.X
        reBounds.Y = rectBegin.Y
        reBounds.Width = width - 1
        reBounds.Height = height - 1
        Using gridBrush As New SolidBrush(dgv.GridColor), backColorBrush As New SolidBrush(celArgs.CellStyle.BackColor)
            Using gridLinePen As New Pen(gridBrush)

                Dim blPoint As New Point(rectBegin.Left, rectBegin.Bottom - 1)
                Dim brPoint As New Point(rectEnd.Right, rectEnd.Bottom - 1)
                celArgs.Graphics.DrawLine(gridLinePen, blPoint, brPoint)

                Dim rtPoint As New Point(rectEnd.Right - 1, rectEnd.Top)
                Dim rbPoint As New Point(rectEnd.Right - 1, rectEnd.Bottom - 1)
                celArgs.Graphics.DrawLine(gridLinePen, rtPoint, rbPoint)

                Dim sf As SizeF = celArgs.Graphics.MeasureString(rowValue, celArgs.CellStyle.Font)
                Dim lstr As Double = (width - sf.Width) / 2
                Dim rstr As Double = (height - sf.Height) / 2
                '
                If celArgs.ColumnIndex = maxColIndex Then
                    If rowValue <> "" Then
                        celArgs.Graphics.DrawString(rowValue, celArgs.CellStyle.Font, New SolidBrush(celArgs.CellStyle.ForeColor), rectBegin.Left + lstr, rectEnd.Top + rstr, StringFormat.GenericDefault)
                    End If
                End If


            End Using
            celArgs.Handled = True
        End Using

    End Sub
#End Region

    Private Sub dgvRunCardBody_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellDoubleClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If e.ColumnIndex = BodyGrid.SOP Then
                    Dim imageFile As String = dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                    If imageFile <> "" Then
                        Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                        frmDialog.Show()
                    End If
                Else
                    If editRight Then
                        If Me.RunCardStatus = 0 AndAlso e.RowIndex <> Me.dgvRunCardBody.RowCount - 1 Then
                            dgvRunCardBody.ReadOnly = False
                            Me.dgvRunCardBody.EditMode = DataGridViewEditMode.EditOnEnter
                            dgvRunCardBody.Columns("工序").ReadOnly = True
                            dgvRunCardBody.Columns("修改人").ReadOnly = True
                            dgvRunCardBody.Columns("修改时间").ReadOnly = True
                            dgvRunCardBody.Columns("工站名称").ReadOnly = True
                            dgvRunCardBody.Columns("SOP").ReadOnly = True
                            dgvRunCardBody.Columns("工艺标准").ReadOnly = False
                            currentRowIndex = e.RowIndex
                            currentColumnIndex = e.ColumnIndex
                            currentColumnName = dgvRunCardBody.CurrentCell.OwningColumn.Name
                            currentValue = dgvRunCardBody.CurrentCell.FormattedValue.ToString
                            If dgvRunCardBody.CurrentCell.OwningColumn.Name = "工站名称" Or dgvRunCardBody.CurrentCell.OwningColumn.Name = "SOP" Or dgvRunCardBody.CurrentCell.OwningColumn.Name = "工艺标准" Then
                                AddButton(currentColumnIndex, currentRowIndex)
                            End If
                        End If
                    End If
                End If
                dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).ReadOnly = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellDoubleClick", "WIP")
        End Try
    End Sub

#Region "排序"
    Public sort As String = "desc"
    Public sortMake As String = "desc"
    Public sortOk As String = "desc"
    Private Sub sbPanelUnfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelUnfinish.Click
        Try
            If sort = "desc" Then
                LoadSideBarByClick(sort, RunCardType.UnFinish)
                sbPanelFinish.SubItems.Sort()
                sort = "asc"
            Else
                LoadSideBarByClick(sort, RunCardType.UnFinish)
                sort = "desc"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub sbPanelAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelAudit.Click
        Try
            If sortMake = "desc" Then
                LoadSideBarByClick(sortMake, RunCardType.Audit)
                sortMake = "asc"
            Else
                LoadSideBarByClick(sortMake, RunCardType.Audit)
                sortMake = "desc"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub sbPanelFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelFinish.Click
        Try
            If sortOk = "desc" Then
                LoadSideBarByClick(sortOk, RunCardType.Finish)
                sortOk = "asc"
            Else
                LoadSideBarByClick(sortOk, RunCardType.Finish)
                sortOk = "desc"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region

    Private Enum RunCardType
        UnFinish = 0
        Finish = 1
        Audit = 2

    End Enum

    Dim dv As DataView = Nothing
    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As RunCardType)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        item.Image = ImageList1.Images(0)
        item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
        '晒选
        dv.Sort = "创建时间 " & sort & ",最近修改日期 " & sort

        Select Case type
            Case RunCardType.UnFinish
                '未完成
                dv.RowFilter = "状态=0 "
                '清除现有Item
                sbPanelUnfinish.SubItems.Clear()
                '遍历
                For Each drv As DataRowView In dv
                    newItem = item.Copy()
                    newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
                    newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
                    lst = New ArrayList
                    lst.Add(drv.Item("ID").ToString())
                    lst.Add(drv.Item("PartID").ToString())
                    lst.Add(drv.Item("状态").ToString())
                    newItem.Tag = lst
                    sbPanelUnfinish.SubItems.Add(newItem)
                    index += 1
                    If index > 100 Then Exit For
                Next
                SideBar1.ExpandedPanel = sbPanelUnfinish
            Case RunCardType.Finish
                '已完成
                dv.RowFilter = "状态=1 "
                '清除现有Item
                sbPanelFinish.SubItems.Clear()
                '遍历
                For Each drv As DataRowView In dv
                    newItem = item.Copy()
                    newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
                    newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
                    lst = New ArrayList
                    lst.Add(drv.Item("ID").ToString())
                    lst.Add(drv.Item("PartID").ToString())
                    lst.Add(drv.Item("状态").ToString())
                    newItem.Tag = lst
                    sbPanelFinish.SubItems.Add(newItem)
                    index += 1
                    If index > 100 Then Exit For
                Next
                SideBar1.ExpandedPanel = sbPanelFinish
            Case RunCardType.Audit
                '审核中
                dv.RowFilter = "状态=2 "
                '清除现有Item
                sbPanelAudit.SubItems.Clear()
                '遍历
                For Each drv As DataRowView In dv
                    newItem = item.Copy()
                    newItem.Text = IIf(IsDBNull(drv.Item("料件编号")), "", drv.Item("料件编号").ToString())
                    newItem.Tooltip = IIf(IsDBNull(drv.Item("规格")), "", drv.Item("规格").ToString())
                    lst = New ArrayList
                    lst.Add(drv.Item("ID").ToString())
                    lst.Add(drv.Item("PartID").ToString())
                    lst.Add(drv.Item("状态").ToString())
                    newItem.Tag = lst
                    sbPanelAudit.SubItems.Add(newItem)
                    index += 1
                    If index > 100 Then Exit For
                Next
                SideBar1.ExpandedPanel = sbPanelAudit
        End Select
    End Sub

#Region "AutoUpdate"
    Private Enum BodyGrid
        RID = 0
        SID
        StationSq = 2
        StationNo = 3
        StationName = 4
        SectionId = 5
        WorkHours = 6
        Equipment = 7
        ProcessStand = 8
        NewProcessStand = 9
        Remark = 10
        SOP = 11
        Status = 12
        UserId = 13
        InTime = 14
    End Enum

    Private btn As Button = New Button()
    Private currentRowIndex As Integer = 0
    Private currentColumnIndex As Integer = 0
    Private currentColumnName As String = ""
    Private currentLeft As Integer = 0
    Private currentTop As Integer = 0
    Private currentValue As String = ""
    Private currentDataRow As DataGridViewRow
    Private isClose As Boolean = False
    Private sConn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private ft As New System.Drawing.Font("Arial", 7)

    Private Sub dgvRunCardBody_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellEnter
        Try
            If e.RowIndex < dgvRunCardBody.Rows.Count - 1 AndAlso Me.dgvRunCardBody.ReadOnly = False Then
                currentDataRow = dgvRunCardBody.CurrentRow
                currentRowIndex = e.RowIndex
                currentColumnIndex = e.ColumnIndex
                currentColumnName = dgvRunCardBody.CurrentCell.OwningColumn.Name
                currentValue = dgvRunCardBody.CurrentCell.FormattedValue.ToString
                If dgvRunCardBody.CurrentCell.OwningColumn.Name = "工站名称" Or dgvRunCardBody.CurrentCell.OwningColumn.Name = "SOP" Or dgvRunCardBody.CurrentCell.OwningColumn.Name = "工艺标准" Then
                    AddButton(currentColumnIndex, currentRowIndex)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub AddButton(ByVal cIndex As Integer, ByVal rIndex As Integer)
        Me.dgvRunCardBody.Controls.Clear()
        If Me.RunCardStatus = 0 Then
            btn.Text = "Q"
            btn.Font = ft
            btn.Visible = True
            btn.ForeColor = Color.Black
            btn.BackColor = Color.WhiteSmoke
            btn.Width = Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Width / 5
            btn.Height = Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height ' IIf(Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height > 20, 20, Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height)
            Me.dgvRunCardBody.Controls.Add(btn)
            btn.Location = New System.Drawing.Point((Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Right - btn.Width), Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Y)
            If currentColumnName = "工站名称" Then
                RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
            End If
            If currentColumnName = "SOP" Then
                RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
            End If
            If currentColumnName = "工艺标准" Then
                RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
            End If
            If rIndex = 0 Then
                currentLeft = btn.Left
                currentTop = btn.Top
            End If
        End If
    End Sub

    Private reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,4})(\.\d{0,1}[1-9])?$")
    Private updateSql As String = ""

    Private Sub dgvRunCardBody_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellLeave
        Try
            Me.dgvRunCardBody.Controls.Clear()
            If dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                UpdateData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UpdateData()
        If dgvRunCardBody.RowCount > 0 Then
            If dgvRunCardBody.IsCurrentCellInEditMode Or isClose Then
                updateSql = Nothing
                If Not dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                    If currentColumnName = "工时" Then
                        If Not reg.IsMatch(dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim) Then
                            dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours)
                            dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours).Selected = True
                            MessageBox.Show("工时格式不正确，请确认！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                        If Me.IsQueryOldVersion = "false" Then
                            updateSql = "UPDATE M_RUNCARDDETAIL_T SET WORKINGHOURS=" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim & "" & _
                             ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        Else
                            updateSql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET WORKINGHOURS=" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim & "" & _
                          ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        End If
                    ElseIf currentColumnName = "设备治具" Then
                        If Me.IsQueryOldVersion = "false" Then
                            updateSql = "UPDATE M_RUNCARDDETAIL_T SET EQUIPMENT=N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                             ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        Else
                            updateSql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET EQUIPMENT=N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                            ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        End If
                    ElseIf currentColumnName = "工艺标准" Then
                        If Me.IsQueryOldVersion = "false" Then
                            updateSql = "UPDATE M_RUNCARDDETAIL_T SET PROCESSSTANDARD= N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                             ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        Else
                            updateSql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET PROCESSSTANDARD= N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                     ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        End If
                    ElseIf currentColumnName = "备注" Then
                        If Me.IsQueryOldVersion = "false" Then
                            updateSql = "UPDATE M_RUNCARDDETAIL_T SET REMARK=N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                             ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        Else
                            updateSql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET REMARK=N'" & dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''") & "'" & _
                            ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.RID).Value & "'"
                        End If
                    End If
                    If Not String.IsNullOrEmpty(updateSql) Then
                        sConn.ExecSql(updateSql)
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.UserId).Value = VbCommClass.VbCommClass.UseId
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.InTime).Value = Date.Now
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvRunCardBody_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvRunCardBody.ColumnWidthChanged
        btn.Width = Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Width / 5
        btn.Location = New System.Drawing.Point(IIf((Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width) < 0, 0, Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width), Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y)
        If currentRowIndex = 0 Then
            currentLeft = btn.Left
            currentTop = btn.Top
        End If
    End Sub

    Private Sub dgvRunCardBody_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvRunCardBody.Scroll
        btn.Left = Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width
        btn.Top = Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y
        If currentRowIndex = 0 AndAlso e.ScrollOrientation = ScrollOrientation.VerticalScroll AndAlso e.NewValue = 0 Then
            btn.Left = currentLeft
            btn.Top = currentTop
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            Select Case keyData
                Case Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.Enter, Keys.Tab, Keys.Home, Keys.PageDown, Keys.PageUp, Keys.End
                    If dgvRunCardBody.IsCurrentCellInEditMode Then
                        If currentColumnName = "工时" Then
                            dgvRunCardBody.EndEdit()
                            If Not reg.IsMatch(Me.dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours).Value.ToString) Then
                                dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours)
                                dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours).Selected = True
                                MessageBox.Show("工时必须是数字，请确认！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.WorkHours).Selected = True
                                Return True
                            End If
                        End If
                    End If
                Case Else
                    Return False
            End Select
            Select Case keyData
                Case Keys.Enter
                    SendKeys.Send("{Tab}")
                    '返回True代表已处理。
                    Return True
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Function

    Private Sub btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim frmModify As FrmRunCardBodyModify = Nothing
            If currentColumnName = "SOP" Then
                frmModify = New FrmRunCardBodyModify(Me.RunCardId, Me.RunCardPn, FrmRunCardBodyModify.ActionType.ModifySop, dgvRunCardBody.Rows(currentRowIndex), Me.IsQueryOldVersion)
            ElseIf currentColumnName = "工站名称" Then
                frmModify = New FrmRunCardBodyModify(Me.RunCardId, Me.RunCardPn, FrmRunCardBodyModify.ActionType.ModifyStation, dgvRunCardBody.Rows(currentRowIndex), Me.IsQueryOldVersion)
            ElseIf currentColumnName = "工艺标准" Then
                frmModify = New FrmRunCardBodyModify(Me.RunCardId, Me.RunCardPn, FrmRunCardBodyModify.ActionType.ModifyProcessParameter, dgvRunCardBody.Rows(currentRowIndex), Me.IsQueryOldVersion)
            End If
            If Not frmModify Is Nothing Then
                If frmModify.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If currentColumnName = "SOP" Then
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.SOP).Value = frmModify.outputSop
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.UserId).Value = VbCommClass.VbCommClass.UseId
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.InTime).Value = Date.Now
                    ElseIf currentColumnName = "工站名称" Then
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.StationName).Value = frmModify.outputStationName
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.SID).Value = frmModify.outputStationId
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.UserId).Value = VbCommClass.VbCommClass.UseId
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.InTime).Value = Date.Now
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.ProcessStand).Value = ""
                    Else
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.ProcessStand).Value = IIf(String.IsNullOrEmpty(frmModify.outputProcessStand), dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.ProcessStand).Value, frmModify.outputProcessStand)
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.UserId).Value = VbCommClass.VbCommClass.UseId
                        dgvRunCardBody.Rows(currentRowIndex).Cells(BodyGrid.InTime).Value = Date.Now
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub BindBodyWhenAdd(ByVal runId As Integer)
        LoadRunCardBody(runId)
        If Me.RunCardStatus = 1 Then
            Me.RunCardStatus = 0
            LoadRunCardHeader("")
            LoadSideBarByClick("desc", RunCardType.UnFinish)
        End If

        If dgvRunCardBody.Rows.Count > 0 Then
            dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - IIf(dgvRunCardBody.Rows.Count > 10, 10, 1)
        End If

        '导致0 -1 = -1
        'index无效会报错
        '你改下, 判断如果gvRunCardBody.Rows为0
        '就不要设定FirstDisplayedScrollingRowIndex
        '否则就设定
    End Sub

    Private Sub FrmRunCard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            isClose = True
            UpdateData()
        Catch ex As Exception
        End Try
    End Sub

    Private Function CheckStationMaintainCheckItem()
        Dim sql As String = "SELECT CHECKITEMCODE FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONID=" & currentDataRow.Cells(BodyGrid.SID).Value.ToString & " AND STATUS='Y'"
        If sConn.GetRowsCount(sql) > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub dgvRunCardBody_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dgvRunCardBody.CellBeginEdit
        Dim dgv As DataGridView = CType(sender, DataGridView)
        ' 是否可以进行编辑的条件检查
        If dgvRunCardBody.CurrentCell.OwningColumn.Name = "工艺标准" Then
            currentDataRow = dgv.CurrentRow
            If CheckStationMaintainCheckItem() Then
                e.Cancel = True
            End If
        End If
    End Sub
#End Region


    Private Sub dgvPartNumber_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPartNumber.MouseDown
        Me.dgvRunCardBody.ReadOnly = True
    End Sub
End Class