Option Explicit On
Option Strict On
Imports System.IO
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports Aspose.Cells
Imports System.Text
Imports SysBasicClass
Imports MainFrame


Public Class FrmOldCutCardModify

    Private rowSpan As New SortedList()
    Private rowValue As String = ""
    Private editRight As Boolean = False
    Dim dv As DataView = Nothing
    Private m_dtRuncardHeader As DataTable
    Private m_preHours As Double = 0  '铆端 01
    Private m_proHours As Double = 0  ' 产线 02
    Private m_ContourHours As Double = 0  '成型 03
    Private m_trimHours As Double = 0 '04,裁切 --  SemiAutoPreChild/ContourHourPreChild/MadeHourPreChild/CutProPreMO
    Private ProPreHours As Double = 0
    Private m_autoHours As Double = 0 'A05 , 半自动压接

    Private Enum CutCardType
        UnFinish = 0
        Finish = 1
        Audit = 2
    End Enum

    Private Enum PartGrid
        PartId = 0
        TypeDest
        DESCRIPTION
    End Enum
#Region "属性"

    Public Structure strCutcard
        Public Status As String
        Public CutCardPartPN As String
        Public CutCardVersion As String
    End Structure

#Region "Version"
    Private _version As String
    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
#End Region

#Region "CutCardPN"
    Private _cutCardPN As String
    Public Property CutCardPN() As String
        Get
            Return _cutCardPN
        End Get
        Set(ByVal value As String)
            _cutCardPN = value
        End Set
    End Property
#End Region

#Region "CutCardStatus"
    Private _cutCardStatus As Integer
    Public Property CutCardStatus() As Integer
        Get
            Return _cutCardStatus
        End Get
        Set(ByVal value As Integer)
            _cutCardStatus = value
        End Set
    End Property
#End Region

#Region "CutCardStationId"
    Private _cutCardStationId As String
    Public Property CutCardStationId() As String
        Get
            Return _cutCardStationId
        End Get
        Set(ByVal value As String)
            _cutCardStationId = value
        End Set
    End Property
#End Region

#Region "CutCardData"
    Private _cutCardData As New DataTable
    Public Property CutCardData() As DataTable
        Get
            Return _cutCardData
        End Get
        Set(ByVal value As DataTable)
            _cutCardData = value
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


#End Region

#Region "窗体加载"


    Private Sub FrmRunCardCut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuHeader)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuBody)
            ERigth.GetContextMenuRight(Me, Me.ContextMenuDetail)
            SetControlStatus()
            '绑定 cutcard 头部
            LoadCutCardHeader("", Nothing, True)
            '绑定 SideBar 菜单
            LoadSideBarByClick("", CutCardType.Finish)
            '隐藏料件面板
            Me.dgvPartNumber.Visible = False
            Me.WindowState = FormWindowState.Maximized

            '绑定右键菜单
            dgvCutCardHeader.ContextMenuStrip = Me.ContextMenuHeader
            '绑定右键菜单
            dgvCutCardBody.ContextMenuStrip = Me.ContextMenuBody
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "FrmRunCardCut_Load", "RCard")
        End Try
    End Sub
#End Region

#Region "菜单事件"

#Region "退出"

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "清除"
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            Me.txtSearch.Text = ""
            LoadSideBarByClick("", CutCardType.Finish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btnClear_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "复制裁线卡"
    Private Sub btnCopyRuncard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If dgvCutCardHeader.Rows.Count <= 0 Or dgvCutCardBody.Rows.Count <= 0 Then
                MessageUtils.ShowError("请选择完整的工艺流程！")
                Exit Sub
            End If
            Dim frmDialog As New FrmCutCardCopy()
            frmDialog.RCPartNumber = Me.CutCardPN
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadCutCardHeader("")
                ''刷新SideBar1
                LoadSideBarByClick("desc", CutCardType.UnFinish)
                '展开
                SideBar1.ExpandedPanel = sbPanelUnfinish
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btnCopyRuncard_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "打印裁线卡"
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim o_Cutcard = New RCardComBusiness.stcCutcard
        Dim o_strCutCardVersion As String = "", o_strTiptopVer As String = ""
        Try
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    o_Cutcard.CutCardPartPN = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    o_Cutcard.Status = row.Cells(CutCardBusiness.HeaderGrid.Status.ToString).Value.ToString

                    o_Cutcard.CutCardVersion = row.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString

                    If _cutCardIDList.IndexOf(o_Cutcard) < 0 Then
                        _cutCardIDList.Add(o_Cutcard)
                    End If
                End If
            Next

            If Me._cutCardIDList.Count <= 0 Then
                MessageUtils.ShowError("请选择裁线卡！")
                Exit Sub
            End If
            For Each CutCard As RCardComBusiness.stcCutcard In Me._cutCardIDList
                If CutCard.CutCardPartPN = "" Then
                    MessageUtils.ShowError("请选择裁线卡！")
                    Exit Sub
                End If

                If Not String.IsNullOrEmpty(CutCard.CutCardPartPN) AndAlso CutCard.CutCardPartPN.Substring(0, 1) <> "L" Then
                    o_strTiptopVer = CutCardBusiness.GetVerFromTiptop(CutCard.CutCardPartPN).ToUpper
                    If (Not String.IsNullOrEmpty(o_strTiptopVer)) AndAlso CutCard.CutCardVersion.ToUpper.Trim <> o_strTiptopVer.Trim Then
                        MessageUtils.ShowError("裁线卡[ " & CutCard.CutCardPartPN & "]版本跟Tiptop不一致！")
                        Exit Sub
                    End If
                End If

                Dim strErrinfo As String = ""
                If Not CheckLeftProcessStandard(CutCard.CutCardPartPN, strErrinfo) Then
                    MessageUtils.ShowError(strErrinfo)
                    Exit Sub
                End If

                If CInt(CutCard.Status) <> 1 Then
                    MessageUtils.ShowError("制作中和审核中的裁线卡不允许打印！")
                    Exit Sub
                End If
            Next

            PrintCutCard("", Me._cutCardIDList)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btnPrint_Click", "RCard")
        Finally
            If (Not Me._cutCardIDList Is Nothing) Then Me._cutCardIDList.Clear()
        End Try
    End Sub


    Private Function CheckLeftProcessStandard(ByVal strPartID As String, ByRef strErrInfo As String) As Boolean
        Dim lsSQL As String = ""
        Dim sql As New StringBuilder
        strErrInfo = ""
        lsSQL = "SELECT a.partid, ProcessStandard, " & _
                " LeftProcessStandard, RightProcessStandard, a.StationID, b.stationname, " & _
                " LEN(processstandard) - LEN(	REPLACE(ProcessStandard,'左',''))  AS LeftItems," & _
                " LEN(LeftProcessStandard) - LEN(REPLACE(LeftProcessStandard,';','')) AS LeftItemsPrint" & _
                " FROM dbo.m_RCardCutD_t a left join m_rstation_t b on  a.stationid = b.stationid " & _
                " WHERE 1=1 AND  LEN(ProcessStandard) -  LEN(REPLACE(ProcessStandard,';',''))>1" & _
                " AND  ( LEN(LeftProcessStandard) -  LEN(REPLACE(LeftProcessStandard,';','')) + LEN(RightProcessStandard) -  LEN(REPLACE(RightProcessStandard,';','')) + 1) <>  LEN(ProcessStandard) -  LEN(REPLACE(ProcessStandard,';',''))" & _
                " AND a.partid ='" & strPartID & "'"

        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows

                    If dr.Item("ProcessStandard").ToString.IndexOf("左脱皮") < 0 Then
                        If dr.Item("LeftProcessStandard").ToString.IndexOf("脱皮") >= 0 Then
                            strErrInfo = "料号：[" & strPartID & "], 工站：[" & dr.Item("stationname").ToString & "] 左参数错误,请检查！"
                            CheckLeftProcessStandard = False
                            Return False
                        End If
                    End If

                    If Val(dr.Item("LeftItems").ToString) > Val(dr.Item("LeftItemsPrint").ToString) Then
                        strErrInfo = "料号：[" & strPartID & "], 工站：[" & dr.Item("stationname").ToString & "] 左参数错误,请检查是否左参数丢失检验项！"
                        CheckLeftProcessStandard = False
                        Return False
                    End If
                Next
                'If Not String.IsNullOrEmpty(sql.ToString) Then
                '    RCardComBusiness.ExecSQL(sql.ToString)
                'End If
            End If
        End Using
        Return True
    End Function


#End Region

#Region "刷新"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            '刷新
            LoadCutCardHeader("")
            LoadSideBarByClick("", CutCardType.Finish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btnRefresh_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "裁线卡审核"
    Private Sub btnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim o_dtSectionHours As DataTable = Nothing
        Dim o_strTempPartID As String = "", o_strTiptopVer As String = String.Empty
        Try
            Dim sql As String = String.Empty, o_strSQL As StringBuilder = Nothing
            Dim index As Integer = 0, i_ECB03 As Integer = 0
            Dim o_IsQAS As Boolean = False
            Dim o_strCreateUserID As String = "", o_strModifyUserID As String = "", o_ModifyTime As Date = Nothing

            o_strSQL = New StringBuilder
            o_strSQL.Append(" Begin")
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_strTempPartID = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    'Add if cq20161031
                    If o_strTempPartID.Substring(0, 1) = "9" Then
                        'Add check version, Add bypass RD abmi100 build partid, 20170206
                        o_strTiptopVer = CutCardBusiness.GetVerFromTiptop(o_strTempPartID).ToUpper
                        If (Not String.IsNullOrEmpty(o_strTiptopVer)) AndAlso row.Cells(CutCardBusiness.NewHeaderGrid.DrawingVer).Value.ToString.ToUpper.Trim <> o_strTiptopVer.Trim Then
                            MessageUtils.ShowError(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "版本跟Tiptop不一致！")
                            Exit Sub
                        End If
                    Else
                        'By pass 
                    End If
                    If Not CheckAutiStatus(row) Then
                        MessageUtils.ShowError(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非审核状态！")
                        Exit Sub
                    Else
                        Dim partID As String = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim RCardVersion As String = row.Cells(CutCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                        o_strCreateUserID = CutCardBusiness.GetUserID(row.Cells(CutCardBusiness.NewHeaderGrid.UserId).Value.ToString)

                        o_strModifyUserID = CutCardBusiness.GetModifyUserID(partID, o_ModifyTime)
                        'cq 20170228
                        sql &= CutCardBusiness.GetUpateCutCardMAndSaveBOMSQL(True, partID, RCardVersion)

                        'ecb17: 生产线前加工
                        '01: 铆端前加工,02:产线,03:成型,04:裁切前加工(仓库),5:生产线前加工 A05 半自动压接连接  
                        'First get every Partid sectionHours 
                        o_dtSectionHours = CutCardBusiness.GetdtSectionHours(partID)
                        If o_dtSectionHours.Select("SECTIONID='01'").Length > 0 Then
                            m_preHours = Val(o_dtSectionHours.Select("sectionid='01'")(0).Item(1))
                        Else
                            m_preHours = 0
                        End If
                        If o_dtSectionHours.Select("SECTIONID='02'").Length > 0 Then
                            m_proHours = Val(o_dtSectionHours.Select("SECTIONID='02'")(0).Item(1))
                        Else
                            m_proHours = 0
                        End If
                        If o_dtSectionHours.Select("SECTIONID='03'").Length > 0 Then
                            m_ContourHours = Val(o_dtSectionHours.Select("SECTIONID='03'")(0).Item(1))
                        Else
                            m_ContourHours = 0
                        End If
                        If o_dtSectionHours.Select("SECTIONID='04'").Length > 0 Then
                            m_trimHours = Val(o_dtSectionHours.Select("SECTIONID='04'")(0).Item(1))
                        Else
                            m_trimHours = 0
                        End If

                        If o_dtSectionHours.Select("SECTIONID='A05'").Length > 0 Then
                            m_autoHours = Val(o_dtSectionHours.Select("SECTIONID='A05'")(0).Item(1))
                        Else
                            m_autoHours = 0
                        End If
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next

            o_strSQL.Append(" END;")
            If Not String.IsNullOrEmpty(sql) Then
                If (MessageUtils.ShowConfirm("确定要审核确认？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                    RCardComBusiness.ExecSQL(sql, o_IsQAS)
                    '提示
                    MessageUtils.ShowInformation("料件审核成功！")
                    '刷新SideBar1
                    LoadCutCardHeader("")
                    LoadSideBarByClick("Desc", CutCardType.Finish)
                    '展开
                    'SideBar1.ExpandedPanel = sbPanelFinish
                End If
            Else
                MessageUtils.ShowError("无选中项！")
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btnAudit_Click", "RCard")
        Finally
            o_dtSectionHours = Nothing
        End Try
    End Sub

    Private Function Convert8859P1ToGB2312(ByVal s As String) As String
        Return System.Text.Encoding.Default.GetString(System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes(s))
    End Function

    Private Function CheckAutiStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable

            dt = CutCardBusiness.GetAutiStatus(True, row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                '是否审核状态？
                If CInt(dt.Rows(0)(0).ToString) = 2 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckAutiStatus", "RCard")
            Return False
        End Try
    End Function
#End Region

#End Region

#Region "左侧"

#Region "txtSearch_KeyPress"
    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim str As String = txtSearch.Text.Trim

                If String.IsNullOrEmpty(str) Then
                    'LoadSideBar("", Me.RunCardData, "asc", False)  
                    LoadSideBarByClick("", CutCardType.Finish)
                Else
                    LoadSideBar(" and PartID like '%" & str & "%'", Me.CutCardData, "asc", True)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "txtSearch_KeyDown", "RCard")
        End Try
    End Sub
#End Region

#Region "SideBar1_ItemClick"
    Private Sub SideBar1_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideBar1.ItemClick
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
                    '赋值
                    If CType(SelectedItem.Tag, ArrayList).Count > 0 Then
                        Me.CutCardPN = CStr(CType(SelectedItem.Tag, ArrayList).Item(0))
                    Else
                        Exit Sub
                    End If

                    If CType(SelectedItem.Tag, ArrayList).Count > 1 Then
                        Me.CutCardStatus = CInt(CType(SelectedItem.Tag, ArrayList).Item(1))
                    End If
                    '
                    rowSpan.Clear()
                    rowValue = ""
                    '隐藏料件面板
                    Me.dgvPartNumber.Visible = False

                    If Me.CutCardData.Select("PartID='" & Me.CutCardPN & "'").Length > 0 Then
                        Me.CutCardData.Select("PartID='" & Me.CutCardPN & "'")(0)("ClickTime") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")
                    End If

                    Me.CutCardData.DefaultView.Sort = "ClickTime Desc"
                    Me.dgvCutCardHeader.DataSource = Me.CutCardData
                    Me.dgvCutCardHeader.Columns("ClickTime").Visible = False
                    LoadCutCardBody(Me.CutCardPN)
                    Me.dgvCutCardHeader.ClearSelection()
                    Me.dgvCutCardHeader.Item("PartID", 0).Selected = True
                    Me.dgvCutCardHeader.FirstDisplayedScrollingRowIndex = 0
                    For i As Integer = 0 To 200
                        If dgvCutCardHeader.Rows.Count > i Then
                            Me.dgvCutCardHeader.Rows(i).Cells(CutCardBusiness.HeaderGrid.CheckBox).Value = "False"
                        Else
                            Exit For
                        End If
                    Next

                    Me.dgvCutCardHeader.Controls.Add(m_ChkboxAll) ' Add by cq20151230
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "SideBar1_ItemClick", "RCard")
        End Try
    End Sub
#End Region

#Region "排序"
    Public sort As String = "desc"
    Public sortMake As String = "desc"
    Public sortOk As String = "desc"
    Private Sub sbPanelUnfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelUnfinish.Click
        Try
            If sort = "desc" Then
                LoadSideBarByClick(sort, CutCardType.UnFinish)
                sbPanelFinish.SubItems.Sort()
                sort = "asc"
            Else
                LoadSideBarByClick(sort, CutCardType.UnFinish)
                sort = "desc"
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "sbPanelUnfinish_Click", "RCard")
        End Try

    End Sub

    Private Sub sbPanelAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelAudit.Click
        Try
            If sortMake = "desc" Then
                LoadSideBarByClick(sortMake, CutCardType.Audit)
                sortMake = "asc"
            Else
                LoadSideBarByClick(sortMake, CutCardType.Audit)
                sortMake = "desc"
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "sbPanelAudit_Click", "RCard")
        End Try
    End Sub

    Private Sub sbPanelFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPanelFinish.Click
        Try
            If sortOk = "desc" Then
                LoadSideBarByClick(sortOk, CutCardType.Finish)
                sortOk = "asc"
            Else
                LoadSideBarByClick(sortOk, CutCardType.Finish)
                sortOk = "desc"
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "sbPanelFinish_Click", "RCard")
        End Try
    End Sub

#End Region

    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As CutCardType)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Try
            item.Image = ImageList1.Images(0)
            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
            '晒选
            dv.Sort = "InTime " & sort & ",MODIFYTIME " & sort

            Select Case type
                Case CutCardType.UnFinish
                    '未完成
                    dv.RowFilter = "Status=0 "
                    '清除现有Item
                    sbPanelUnfinish.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelUnfinish.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelUnfinish
                Case CutCardType.Finish
                    '已完成
                    dv.RowFilter = "Status=1 "
                    '清除现有Item
                    sbPanelFinish.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        'lst.Add(drv.Item("ID").ToString())
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelFinish.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelFinish
                Case CutCardType.Audit
                    '审核中
                    dv.RowFilter = "Status=2 "
                    '清除现有Item
                    sbPanelAudit.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item("PartID").ToString()
                        newItem.Text = drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        'lst.Add(drv.Item("ID").ToString())
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelAudit.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelAudit
            End Select
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "LoadSideBarByClick", "RCard")
        End Try
    End Sub

#Region "加载SideBar"
    Private Sub LoadSideBar(ByVal filter As String, ByVal dt As DataTable, Optional ByVal sort As String = "asc", Optional ByVal isQuery As Boolean = False)
        Try
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
            '  dv = New DataView(dt)
            dv = New DataView(dt)
            dv.Sort = "InTime " & sort
            '已完成
            dv.RowFilter = "Status=1 " & filter
            '清除现有Item
            sbPanelFinish.SubItems.Clear()
            '遍历
            For Each drv As DataRowView In dv
                newItem = item.Copy()
                newItem.Text = drv.Item("PartID").ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                'lst.Add(drv.Item("ID").ToString())
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
                newItem.Tag = lst
                sbPanelFinish.SubItems.Add(newItem)
                If isQuery Then GoTo Show
            Next
            '未完成
            dv.RowFilter = "Status=0 " & filter
            '清除现有Item
            sbPanelUnfinish.SubItems.Clear()
            '遍历
            For Each drv As DataRowView In dv
                newItem = item.Copy()
                newItem.Text = drv.Item("PartID").ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                'lst.Add(drv.Item("ID").ToString())
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
                newItem.Tag = lst
                sbPanelUnfinish.SubItems.Add(newItem)
                index = 0
                If isQuery Then GoTo Show
            Next
            '审核中
            dv.RowFilter = "Status=2 " & filter
            '清除现有Item
            sbPanelAudit.SubItems.Clear()
            '遍历
            For Each drv As DataRowView In dv
                newItem = item.Copy()
                newItem.Text = drv.Item("PartID").ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(CutCardBusiness.HeaderGrid.Status.ToString).ToString())
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
                SideBar1.ExpandedPanel = CType(IIf(index = 0, sbPanelUnfinish, IIf(index = 1, sbPanelFinish, sbPanelAudit)), SideBarPanelItem)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "LoadSideBar", "RCard")
        End Try

    End Sub
#End Region

#End Region

#Region "CutCardHeader"

#Region "绑定 CutCard 头部"
    Private m_ChkboxAll As New CheckBox
    Private Sub LoadCutCardHeader(ByVal sqlWhere As String, Optional ByVal isQquery As Boolean = False, _
                                  Optional ByVal isQueryOldVersion As Boolean = False, Optional ByVal o_blnReSet As Boolean = True)
        AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
        AddHandler dgvCutCardHeader.CellPainting, AddressOf dgvRunCardHeader_CellPainting
        Try
            Dim dt As DataTable = GetOldCutCardHeader(True, sqlWhere)
            Dim o_strFinishNum As String = "0", o_strAuditNum As String = "0", o_strUnfinish As String = "0"
            If (Not IsNothing(Me.dgvCutCardHeader)) AndAlso Me.dgvCutCardHeader.ColumnCount > 0 Then
                Me.dgvCutCardHeader.Columns.Clear()
            End If
            Me.dgvCutCardHeader.DataSource = dt
            m_dtRuncardHeader = dt

            Me.txtCount.Text = CStr(dt.Rows.Count)
            Dim ChColsText As String = "ClickTime|料件编号|描述|总工时|规格|版本|形态|标准拍配人力(人)|标准UPPH(PCS/人/H)|标准UPH(PCS/H)|实时效率|图纸文件|成品尺寸|状态|制作状态|创建人|创建时间|最近修改日期|备注|旧版本"
            Dim colColsText As String() = ChColsText.Split(CChar("|"))
            '0.制作中;1.已生效;2: .待审核
            If o_blnReSet Then
                o_strFinishNum = CStr(dt.Select("status=1").Length) : o_strAuditNum = CStr(dt.Select("status=2").Length) : o_strUnfinish = CStr(dt.Select("status=0").Length)
                sbPanelFinish.Text = sbPanelFinish.Text.Split(CChar("("))(0) + "(" + o_strFinishNum + ")"
                sbPanelAudit.Text = sbPanelAudit.Text.Split(CChar("("))(0) + "(" + o_strAuditNum + ")"
                sbPanelUnfinish.Text = sbPanelUnfinish.Text.Split(CChar("("))(0) + "(" + o_strUnfinish + ")"
            End If

            'Add by cq 20161103
            If dgvCutCardHeader.Columns.Count > 0 Then
                For i As Integer = 0 To dgvCutCardHeader.Columns.Count - 1
                    dgvCutCardHeader.Columns(i).HeaderText = colColsText(i)
                Next
            End If

            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.ClickTime.ToString).Visible = False
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.FinishSize.ToString).Visible = False
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.Status.ToString).Visible = False
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.OldVersion.ToString).Visible = False
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.Shape.ToString).Width = 100
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.TypeDest.ToString).Width = 100 '描述
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Width = 50
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.DESCRIPTION.ToString).Width = 120
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.ZStatus.ToString).Width = 80
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.UserId.ToString).Width = 60
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.InTime.ToString).Width = 110
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.ModifyTime.ToString).Width = 110
            Me.dgvCutCardHeader.Columns(CutCardBusiness.HeaderGrid.Remark.ToString).Width = 120
            Me.dgvCutCardHeader.Columns(CutCardBusiness.NewHeaderGrid.TotalHours.ToString).Width = 80
            Me.dgvCutCardHeader.Columns(CutCardBusiness.NewHeaderGrid.RealTimeEffic.ToString).Width = 65
            If Not isQquery Then
                Me.CutCardData = dt
                Me.dv = New DataView(Me.CutCardData)
            End If

            Dim clo As New DataGridViewCheckBoxColumn

            clo.HeaderText = "选择"
            clo.Width = 50
            Me.dgvCutCardHeader.Columns.Insert(0, clo)
            Me.m_ChkboxAll.Text = "选择"
            Me.dgvCutCardHeader.Controls.Add(Me.m_ChkboxAll)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "LoadRunCardHeader", "RCard")
        End Try
    End Sub

    Public Shared Function GetOldCutCardHeader(ByVal isQueryOldVersion As Boolean, sqlWhere As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty
        Try
            'cq, {0}(nolock) RC,  m_RCardD_t D == > LEFT JOIN 20160406
            strSql =
        " SELECT   '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
        "PC.TypeDest," & _
        " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
        " PC.DESCRIPTION , " &
        "RC.DrawingVer ,RC.Shape ," & _
         " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,RC.RealTimeEffic," & _
        "IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
        "RC.FinishSize, RC.Status, " & _
        "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
        "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion " &
        "FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  " &
        " LEFT JOIN V_m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " WHERE 1=1  " & sqlWhere &
        RCardComBusiness.GetFatoryProfitcenter("RC") & _
        " GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
               " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,RC.RealTimeEffic" & _
        " ORDER BY RC.MODIFYTIME DESC,RC.INTIME DESC "
            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardCutM_t", "m_RCardCutD_t")
            Else
                strSql = String.Format(strSql, "m_CutCardMOldVer_t", "m_CutCardDOldVer_t")
            End If
            dt = DbOperateUtils.GetDataTable(strSql)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardCutBusiness", "GetRunCardCutHeader", "RCard")
            Throw ex
        End Try
        Return dt
    End Function


    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        Try
            'Add by cq20170518
            Me.dgvCutCardHeader.EndEdit()
            If Me.dgvCutCardHeader.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 0 To Me.dgvCutCardHeader.RowCount - 1
                Me.dgvCutCardHeader.Rows(i).Cells(0).Value = m_ChkboxAll.Checked
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "m_ChkboxAll_CheckedChanged", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvCutCardHeader_CellClick"
    Private Sub dgvCutCardHeader_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardHeader.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                Me.CutCardPN = CStr(Me.dgvCutCardHeader.Item(CutCardBusiness.HeaderGrid.PartId.ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString())
                Me.Version = CStr(Me.dgvCutCardHeader.Item(CutCardBusiness.HeaderGrid.DrawingVer.ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString())
                Me.CutCardStatus = CInt(Me.dgvCutCardHeader.Item(CutCardBusiness.HeaderGrid.Status.ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString)

                '清除单元格及值
                rowSpan.Clear()
                rowValue = ""
                '显示 cutcard 工站详情
                LoadCutCardBody(Me.CutCardPN, Me.Version)
                '隐藏料件面板
                Me.dgvPartNumber.Visible = False

                Me.dgvCutCardHeader.Controls.Add(Me.m_ChkboxAll)

                If Not CheckStatusNotFinish(dgvCutCardHeader.CurrentRow) Then
                    For i As Integer = 1 To dgvCutCardHeader.CurrentRow.Cells.Count - 1
                        If i = CutCardBusiness.NewHeaderGrid.Shape OrElse i = CutCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                    currentValue = dgvCutCardHeader.CurrentCell.FormattedValue.ToString
                    Exit Sub
                Else
                    For i As Integer = 1 To dgvCutCardHeader.CurrentRow.Cells.Count - 1
                        If i = CutCardBusiness.NewHeaderGrid.Shape OrElse i = CutCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                End If

                dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.Shape).ReadOnly = False 'Add by cq 20170329
                dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.StdLabors.ToString).ReadOnly = False
                currentValue = dgvCutCardHeader.CurrentCell.FormattedValue.ToString
                Me.currentRowIndex = -1  'body index  reset cq20161105
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvCutCardHeader_CellClick", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvCutCardHeader_CellDoubleClick"

    Private Sub dgvCutCardHeader_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardHeader.CellDoubleClick
        Dim o_iLength As Integer = 0
        Try
            Dim o_strFilter As String = "", o_strFilterT As String = "", o_strFilter2 As String = ""
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                'If e.ColumnIndex = 7 Then
                '    Dim imageFile As String = dgvCutCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                '    If imageFile <> "" Then
                '        Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                '        frmDialog.Show()
                '    End If
                'End If

                Select Case e.ColumnIndex
                    Case 7
                        'mark by cq 20160627, now 7 is [shape] column
                        'Dim imageFile As String = dgvCutCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                        'If imageFile <> "" Then
                        '    Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                        '    frmDialog.Show()
                        'End If
                    Case 12  '8
                        Dim arrPara(0) As String
                        Dim dtPLMData As DataTable
                        Dim BomQuery As New com.luxshare_ict.plm.WebService1

                        Dim DT As DataTable = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value), "蓝图")
                        o_strFilter = CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value) + "%"

                        If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                            arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                        Else
                            'May be is a child PN (use parent PN get the a whole set file)  'a.Substring(0, InStr(a, "-") - 1)
                            If Not IsNothing(DT) Then
                                DT.Clear()
                            End If

                            o_iLength = InStr(CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value), "-") - 1
                            If o_iLength > 0 Then
                                'do nothing
                            Else
                                o_iLength = CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value).Length
                            End If

                            ' DT = BomQuery.GetPLMClassification(VbCommClass.VbCommClass.UseId, CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength))
                            DT = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength), "蓝图")
                            o_strFilter = CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength) + "%"
                            ' o_strFilterT = CStr(Me.dgvCutCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength) + "-%"

                            If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                                arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                            End If
                        End If
                        'GetPLMData,GetPLMData_current, cq20160922
                        dtPLMData = BomQuery.GetPLMData_current(arrPara, "n/K67oxui8q8TFMwoAQKng==")
                        If (Not dtPLMData Is Nothing) Then
                            If (dtPLMData.Rows.Count > 0) Then
                                Dim strEncryptionURL As String = CStr(dtPLMData.Rows(0).Item("url"))
                                If (String.IsNullOrEmpty(strEncryptionURL)) Then
                                    Exit Sub
                                End If
                                Dim strURL As String     'luxshareICT
                                '   http://172.20.22.85:17888/OnlinePreview/plmonline?cdid=D767D62A3496418380BADB96137C54C3
                                ' strURL = CryptoMemoryStream.Decrypt(strEncryptionURL, "linkcode")
                                strURL = "http://172.20.22.85:17888/OnlinePreview/plmonline?cdid=" + dtPLMData.Rows(0).Item("id").ToString()
                                System.Diagnostics.Process.Start(strURL)
                            End If
                        Else
                            MessageUtils.ShowError("图纸路径不存在！")
                        End If
                    Case Else
                        'do nothing
                End Select

                If Not CheckStatusNotFinish(dgvCutCardHeader.CurrentRow) Then
                    For i As Integer = 0 To Me.dgvCutCardHeader.CurrentRow.Cells.Count - 1
                        If i = CutCardBusiness.NewHeaderGrid.Shape OrElse i = CutCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvCutCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                    Exit Sub
                Else
                    dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.Shape).ReadOnly = False
                    dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.StdLabors.ToString).ReadOnly = False
                    currentValue = dgvCutCardHeader.CurrentCell.FormattedValue.ToString
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardCutHeader_CellDoubleClick", "RCard")
        End Try
    End Sub

#End Region

#Region "复制单元格 header "
    Private Sub tsmiHeaderCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCopy.Click
        Dim Selected As String = String.Empty
        Try
            If Not dgvCutCardHeader.CurrentCell Is Nothing Then
                ' Selected = dgvCutCardHeader.CurrentCell.Value.ToString()
                ' Selected = CStr(IIf(IsDBNull(dgvCutCardHeader.CurrentCell.Value), "", dgvCutCardHeader.CurrentCell.Value))
                If IsDBNull(dgvCutCardHeader.CurrentCell.Value) Then
                    Selected = ""
                Else
                    Selected = CStr(dgvCutCardHeader.CurrentCell.Value)
                End If
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderCopy_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "新增 header"
    Private Sub tmisHeaderAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderAdd.Click
        Try
            Dim frmHeader As New FrmCutCardHeaderEdit("add", Nothing)
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadCutCardHeader("")
                LoadSideBarByClick("desc", CutCardType.UnFinish)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tmisHeaderAdd_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "修改 header"
    Private Sub tsmiHeaderModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderModify.Click
        Try
            If Me.tsmiHeaderModify.Tag Is Nothing Then
                MessageUtils.ShowError("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.CutCardStatus = 2 Or Me.CutCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.CutCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If
            Dim frmHeader As New FrmCutCardHeaderEdit("modify", CType(Me.tsmiHeaderModify.Tag, DataGridViewRow))
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                'Modify by cq 20170321
                LoadCutCardHeader("")
                LoadSideBarByClick("desc", CutCardType.UnFinish)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderModify_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "绑定右健菜单 header"
    Private Sub dgvRunCardHeader_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvCutCardHeader.CellContextMenuStripNeeded
        Try
            e.ContextMenuStrip = Me.ContextMenuHeader
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "MenuStripNeeded", "RCard")
        End Try
    End Sub
#End Region

#Region "鼠标右击处理 header"
    Public _cutCardIDList As List(Of RCardComBusiness.stcCutcard) = New List(Of RCardComBusiness.stcCutcard)
    Private Sub dgvCutCardHeader_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCutCardHeader.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If e.RowIndex > -1 Then
                    Dim row As DataGridViewRow = dgvCutCardHeader.Rows(e.RowIndex)
                    Me.tsmiHeaderModify.Tag = row
                    Me.tsmiPartAdd.Tag = "N"
                    '右健改变当前行号
                    dgvCutCardHeader.Rows(e.RowIndex).Selected = True
                    dgvCutCardHeader.CurrentCell = dgvCutCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    '
                    Me.CutCardPN = CStr(Me.dgvCutCardHeader.Item(CutCardBusiness.HeaderGrid.PartId.ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString())
                    Me.CutCardStatus = CInt(Me.dgvCutCardHeader.Item(CutCardBusiness.HeaderGrid.Status.ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString)
                    Me.Version = CStr(Me.dgvCutCardHeader.Item((CutCardBusiness.HeaderGrid.DrawingVer).ToString, Me.dgvCutCardHeader.CurrentRow.Index).Value.ToString())
                    '清除单元格及值
                    rowSpan.Clear()
                    rowValue = ""
                    '显示 cutcard 工站详情
                    LoadCutCardBody(Me.CutCardPN, Me.Version)
                Else
                    Me.tsmiHeaderModify.Tag = Nothing
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvCutCardHeader_CellMouseDown", "RCard")
        End Try
    End Sub
#End Region

#Region "删除"
    Private Sub tsmiHeaderDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            Dim isOldVersion As Boolean = False
            Dim partID As String = String.Empty
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    If Not CheckStatus(row) Then
                        MessageUtils.ShowError("料件" & row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非制作中的裁线卡，不允许删除！")
                        Exit Sub
                    Else
                        isOldVersion = CBool(row.Cells(CutCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString)
                        partID = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        sql &= CutCardBusiness.DeleteCutHeader(isOldVersion, partID)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageUtils.ShowError("无选中项！")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认要删除选中的裁线卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("删除成功！")
                LoadCutCardHeader("")
                LoadSideBarByClick("", CutCardType.Finish)
                'Add by cq 20161102
                Dim dt As New DataTable
                dt = CType(dgvCutCardBody.DataSource, DataTable)
                If (Not IsNothing(dt)) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = dt
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderDelete_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "隐藏"
    Private Sub tsmiHeaderHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
        Dim sql As String = String.Empty
        Try
            Dim index As Integer = 0
            Dim isOldVersion As Boolean = False
            Dim partID As String = String.Empty, strVersion As String = ""
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    partID = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    strVersion = row.Cells(CutCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                    isOldVersion = CutCardBusiness.IsOldCutCardVersion(partID, strVersion)
                    sql &= CutCardBusiness.GetCutCardEditSQL() 'isOldVersion, partID
                    sql &= CutCardBusiness.HideCutHeader(False, partID, strVersion)
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageUtils.ShowError("无选中项！")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认要隐藏选中的裁线卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                If Not String.IsNullOrEmpty(sql) Then
                    Dim al As ArrayList = New ArrayList
                    al.Add("PartID|" & partID)
                    al.Add("Version|" & Me.Version)
                    al.Add("Factoryid|" & Factoryid)
                    al.Add("Profitcenter|" & Profitcenter)

                    RCardComBusiness.ExecSQL(sql, al)
                End If
                MessageUtils.ShowInformation("隐藏成功！")
                LoadCutCardHeader("")
                LoadSideBarByClick("", CutCardType.Finish)

                'Modify by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvCutCardBody.DataSource, DataTable)

                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderHide_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "取消生效"
    Private Sub tsmiHeaderCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCancel.Click
        Try
            Dim index As Integer = 0
            Dim sql As String = String.Empty
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    If Not CheckCancelStatus(row) Then
                        Exit Sub
                    Else
                        Dim partID As String = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim o_strCutCardVer As String = row.Cells(CutCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                        sql &= CutCardBusiness.GetSaveOldRejectStatusSQL(partID, o_strCutCardVer)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageUtils.ShowInformation("无选中项")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认要取消生效选中的裁线卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("取消生效成功！")

                For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                    If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                           row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                        row.Cells(CutCardBusiness.NewHeaderGrid.ZStatus).Value = "制作中"
                        row.Cells(CutCardBusiness.NewHeaderGrid.Status).Value = "0"
                    End If
                Next
                LoadSideBarByClick("Desc", CutCardType.UnFinish)

                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvCutCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderCancel_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckCancelStatus(ByVal row As DataGridViewRow) As Boolean
        Try

            Dim dt As DataTable = CutCardBusiness.GetOldAutiStatus(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString,
                                                                row.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0)) = 2 Then
                    MessageUtils.ShowInformation(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的旧裁线卡还在审核中，不允许取消生效。")
                    Return False
                ElseIf CInt(dt.Rows(0)(0)) = 0 Then
                    MessageUtils.ShowInformation(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的旧裁线卡还在制作中，不允许取消生效。")
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckCancelStatus", "RCard")
            Return False
        End Try
    End Function

#End Region

#Region "驳回"
    Private Sub tsmiHeaderReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderReject.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckRejectStatus(row) Then
                        Exit Sub
                    Else
                        Dim isOldVer As Boolean = CBool(row.Cells(CutCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString)
                        Dim partID As String = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        sql &= CutCardBusiness.GetSaveRejectStatusSQL(isOldVer, partID)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageUtils.ShowInformation("无选中项")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认要驳回" & Me.CutCardPN & "的裁线卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("驳回成功！")
                LoadCutCardHeader("")
                LoadSideBarByClick("Desc", CutCardType.UnFinish)
                'Add by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvCutCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderReject_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckRejectStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = CutCardBusiness.GetAutiStatus(CBool(row.Cells(CutCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString),
                                                                row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0)) = 1 Then
                    MessageUtils.ShowInformation(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的裁线卡已是审核状态，不允许驳回。")
                    Return False
                ElseIf CInt(dt.Rows(0)(0)) = 0 Then '0
                    MessageUtils.ShowInformation(row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的裁线卡已是审核状态，不允许驳回。")
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckRejectStatus", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "导入"
    Private Sub tsmiHeaderImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderImport.Click
        Try
            Dim frmStation As New FrmRunCardImportStation(Me.CutCardPN, "Import", True)
            frmStation.ShowDialog()
            '刷新
            LoadCutCardHeader("")
            'LoadSideBar("", Me.RunCardData)
            LoadSideBarByClick("desc", CutCardType.UnFinish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderImport_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "导出"

    Private Sub tsmiHeaderExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderExport.Click
        Dim o_Cutcard = New RCardComBusiness.stcCutcard
        Dim strRuncardPNList As String = String.Empty
        Dim o_stcProcessCutcard As List(Of RCardComBusiness.stcCutcard) = New List(Of RCardComBusiness.stcCutcard)
        Try

            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_Cutcard.CutCardPartPN = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    o_Cutcard.Status = row.Cells(CutCardBusiness.HeaderGrid.Status.ToString).Value.ToString
                    o_Cutcard.CutCardVersion = row.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    If _cutCardIDList.IndexOf(o_Cutcard) < 0 Then
                        _cutCardIDList.Add(o_Cutcard)
                    End If
                End If
            Next

            If _cutCardIDList.Count <= 0 Then
                MessageUtils.ShowInformation("请选择裁线卡")
                Exit Sub
            End If

            Dim frmStation As New FrmCutCardImportStation(Me.CutCardPN, "Export", True)

            For Each o_strCutCard As RCardComBusiness.stcCutcard In _cutCardIDList
                If Val(o_strCutCard.Status) <> 1 Then
                    MessageUtils.ShowInformation("制作中和审核中的裁线卡不允许导出！")
                    Exit Sub
                End If

                Dim strErrinfo As String = ""
                If Not CheckLeftProcessStandard(o_strCutCard.CutCardPartPN, strErrinfo) Then
                    MessageUtils.ShowError(strErrinfo)
                    Exit Sub
                End If


                o_stcProcessCutcard.Add(o_strCutCard)
                frmStation.m_stcCutcardList.Add(o_strCutCard)
            Next

            '刷新
            frmStation.SelectPath(o_Cutcard.CutCardPartPN)

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderExport_Click", "RCard")
        Finally
            If Not IsNothing(Me._cutCardIDList) Then Me._cutCardIDList.Clear()
        End Try
    End Sub
#End Region

#Region "查询"
    Private Sub tsmiHeaderSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderSearch.Click
        Try
            Dim frmQuery As New FrmRunCardQuery()
            If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then

                LoadCutCardHeader(frmQuery.SqlWhere, True, True, False) 'cq20151026, Add flag

                'Add by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvCutCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = o_dtBody

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderSearch_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "打印"
    Private Sub tsmiHeaderPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderPrint.Click
        Dim o_Cutcard As New RCardComBusiness.stcCutcard
        Dim o_strTiptopVer As String = String.Empty
        Try
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_Cutcard.CutCardPartPN = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    o_Cutcard.Status = row.Cells(CutCardBusiness.HeaderGrid.Status.ToString).Value.ToString
                    o_Cutcard.CutCardVersion = row.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    If _cutCardIDList.IndexOf(o_Cutcard) < 0 Then
                        _cutCardIDList.Add(o_Cutcard)
                    End If
                End If
            Next
            If _cutCardIDList.Count <= 0 Then
                MessageUtils.ShowInformation("请选择裁线卡！")
                Exit Sub
            End If

            For Each o_strRunCard As RCardComBusiness.stcCutcard In _cutCardIDList
                If Val(o_strRunCard.Status) <> 1 Then
                    MessageUtils.ShowInformation("制作中和审核中的裁线卡不允许打印！")
                    Exit Sub
                End If

                'add by cq 20160722
                'Modify bypass RD build PartID on abmi100, 20170206
                o_strTiptopVer = CutCardBusiness.GetVerFromTiptop(o_Cutcard.CutCardPartPN).ToUpper
                If (Not String.IsNullOrEmpty(o_strTiptopVer)) AndAlso o_Cutcard.CutCardVersion.ToUpper().Trim <> o_strTiptopVer.Trim Then
                    MessageUtils.ShowError("裁线卡[ " & o_Cutcard.CutCardPartPN & "]版本跟Tiptop不一致！")
                    Exit Sub
                End If
            Next

            PrintCutCard("", _cutCardIDList)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiHeaderPrint_Click", "RCard")
        Finally
            If Not IsNothing(Me._cutCardIDList) Then
                Me._cutCardIDList.Clear()
            End If
        End Try
    End Sub
#End Region

#Region "打印裁线卡头部"

    Private Sub PrintRunCardHeader(Optional ByVal pn As String = "")
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Dim filePath As String = String.Empty

        Try
            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardHeaderTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = Environment.CurrentDirectory + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(Me.CutCardPN, "Export", True) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)

            Using dt As DataTable = m_dtRuncardHeader
                If dt.Rows.Count > 0 Then
                    dt.TableName = "RunCard"
                    If SysDataBaseClass.Import2ExcelByAs(filePath, o_outputFile, dt, frmStation.GetNoVariables(dt), errorMsg) Then  'frmStation.GetVariables(dt)
                        Using frmshow As New FrmShowRunCard()
                            frmshow.filePath = o_outputFile
                            frmshow.ShowDialog()
                        End Using
                    Else
                        'MessageBox.Show(errorMsg, 
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的裁线卡表头信息！")
                End If
            End Using

        Catch ex As Exception
            Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "PrintRunCardHeader", "RCard")
        Finally
            If File.Exists(o_outputFile) Then
                ' File.Delete(o_outputFile)
            End If
        End Try
    End Sub
#End Region

    'Add by CQ 20151229
    Private Sub dgvRunCardHeader_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvCutCardHeader.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.dgvCutCardHeader.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                p.Offset(CInt("0"), CInt("0"))
                Me.m_ChkboxAll.Location = p
                Me.m_ChkboxAll.Size = dgvCutCardHeader.Columns(0).HeaderCell.Size
                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardHeader_CellPainting", "RCard")
        End Try
    End Sub

#End Region

#Region "CutCardBody"

    Private dtBody As DataTable

#Region "绑定 CutCard 身体"
    Private Sub LoadCutCardBody(ByVal cutCardPartId As String, Optional ByVal strVersion As String = "")
        Dim preHours As Double = 0, proHours As Double = 0, sufHours As Double = 0
        Dim trimHours As Double = 0, ProPreHours As Double = 0, autoHours As Double = 0
        m_preHours = 0 : m_proHours = 0 : m_ContourHours = 0 : m_trimHours = 0 : m_autoHours = 0
        Dim ds As DataSet = CutCardBusiness.GetOldCutCardBody(True, cutCardPartId, strVersion)
        Try
            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    If Not IsNothing(ds.Tables(1)) AndAlso ds.Tables(1).Rows.Count > 0 Then  'Add if cq 20160629
                        Dim dtTail As DataTable = ds.Tables(1)
                        For index As Integer = 0 To dtTail.Rows.Count - 1
                            Select Case dtTail.Rows(index).Item("SectionID").ToString.Trim()
                                Case "1", "01"
                                    preHours = Math.Round(Val((dtTail.Rows(index)("WorkingHours").ToString)), 1)
                                    m_preHours = preHours
                                Case "2", "02"
                                    proHours = Math.Round(Val(dtTail.Rows(index)("WorkingHours").ToString), 1)
                                    m_proHours = proHours  '产线
                                Case "3", "03"
                                    sufHours = Math.Round(Val(dtTail.Rows(index)("WorkingHours").ToString), 1)
                                    m_ContourHours = sufHours '成型
                                Case "4", "04"
                                    trimHours = Math.Round(Val(dtTail.Rows(index)("WorkingHours").ToString), 1)
                                    m_trimHours = trimHours
                                Case "5", "05"
                                    ProPreHours = Math.Round(Val(dtTail.Rows(index)("WorkingHours").ToString), 1)
                                Case "A05"
                                    autoHours = Math.Round(Val(dtTail.Rows(index)("WorkingHours").ToString), 1)
                                    m_autoHours = autoHours
                            End Select
                        Next
                    End If
                    ' 01-铆端前加工，02-产线加工，03-成型加工， 04-裁切前加工，05-生产线前加工，A05-半自动压接连接 
                    ' PartId ,StationID, StationSQ, StationName, (SectionID),WorkingHours,Equipment,ProcessStandard,NewProcessStandard,Remark,SOP,Status,UserId,InTime,(Shape)
                    dt.Rows.Add(Nothing, Nothing, Nothing, "总工时(s):" & Convert.ToDouble(preHours + proHours + sufHours + trimHours + ProPreHours + autoHours), _
                                Nothing, "铆端前加工(s): " & preHours.ToString, "产线(s): " & proHours.ToString, _
                               "成型(s): " & sufHours.ToString, Nothing, _
                               "裁切前(s):" & trimHours.ToString, "生产线前(s):" & ProPreHours.ToString, Nothing, "半自动压接(s):" & autoHours.ToString, _
                               Nothing)
                    dgvCutCardBody.DataSource = dt
                    '禁止排序
                    For Each column As DataGridViewColumn In dgvCutCardBody.Columns
                        column.SortMode = DataGridViewColumnSortMode.NotSortable
                    Next

                    If dt.Rows.Count > 0 AndAlso dgvCutCardBody.Rows.Count > 0 Then
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(5).Style.BackColor = Color.LightGreen '铆端前加工
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(6).Style.BackColor = Color.Aqua '产线
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(7).Style.BackColor = Color.PeachPuff '成型
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(9).Style.BackColor = Color.WhiteSmoke '裁切前
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(10).Style.BackColor = Color.MistyRose '生产线前
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).Cells(12).Style.BackColor = Color.Tomato '半自动
                    End If

                    If Me.CutCardStatus = 1 Or Me.CutCardStatus = 2 Then
                        dgvCutCardBody.ReadOnly = True
                    End If

                    If Me.CutCardStatus = 0 Then
                        'do nothing
                    Else
                        dgvCutCardBody.ReadOnly = True
                    End If

                    'Add if by cq 20161102
                    If dt.Rows.Count >= 1 AndAlso dgvCutCardBody.Rows.Count > 0 Then
                        dgvCutCardBody.Rows(dt.Rows.Count - 1).ReadOnly = True
                    End If

                    dtBody = dt.Clone

                    'cq add judge 20160701 
                    If dgvCutCardBody.Columns.Count > 2 Then
                        dgvCutCardBody.Columns("StationSQ").Width = 30 '2.StationSQ
                    End If

                    If dgvCutCardBody.Columns.Count > 3 Then
                        dgvCutCardBody.Columns("StationName").Width = 130 '3.StationName
                    End If

                    If dgvCutCardBody.Columns.Count > 5 Then
                        dgvCutCardBody.Columns("WorkingHours").Width = 110 '5.WorkingHours
                    End If

                    If dgvCutCardBody.Columns.Count > 6 Then
                        dgvCutCardBody.Columns("Equipment").Width = 100 '6.Equipment
                    End If
                    If dgvCutCardBody.Columns.Count > 7 Then
                        dgvCutCardBody.Columns("ProcessStandard").Width = 170 '7.ProcessStandard
                    End If

                    If dgvCutCardBody.Columns.Count > 10 Then
                        dgvCutCardBody.Columns("LCLValue").Width = 80
                    End If

                    If dgvCutCardBody.Columns.Count > 12 Then
                        dgvCutCardBody.Columns("UserId").Width = 60 '12.UserId
                    End If
                    If dgvCutCardBody.Columns.Count > 13 Then
                        dgvCutCardBody.Columns("InTime").Width = 110 '13.InTime
                    End If
                Else
                    dgvCutCardBody.DataSource = dt
                    dtBody = dt.Clone
                End If

                If dgvCutCardBody.Columns.Count > 7 Then
                    dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.ProcessStandard.ToString).CellTemplate.Style.WrapMode = DataGridViewTriState.True
                End If
            Else
                If dtBody Is Nothing Then
                    'cq 20161102
                    Dim o_dt As New DataTable
                    o_dt = CType(dgvCutCardBody.DataSource, DataTable)
                    'Add if cq 20161108
                    If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                        o_dt.Rows.Clear()
                    End If
                    dgvCutCardBody.DataSource = o_dt
                Else
                    dgvCutCardBody.DataSource = dtBody
                End If
            End If
        Catch ex As Exception
            'add by cq 20160628
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "LoadRunCardBody", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvRunCardCutBody_CellClick"
    Private Sub dgvRunCardCutBody_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardBody.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                '最后一行是汇总行
                If e.RowIndex <> dgvCutCardBody.Rows.Count - 1 Then
                    Dim CardPN As String = CStr(Me.dgvCutCardBody.Item(CutCardBusiness.BodyGrid.PartId.ToString, Me.dgvCutCardBody.CurrentRow.Index).Value.ToString)
                    Me.CutCardStationId = CStr(Me.dgvCutCardBody.Item(CutCardBusiness.BodyGrid.StationID.ToString, Me.dgvCutCardBody.CurrentRow.Index).Value.ToString)

                    Dim o_strCutCardVer = CStr(Me.dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString)


                    '加载料件信息
                    Me.LoadPartGrid(CardPN, Me.CutCardStationId, o_strCutCardVer)
                    '显示料件面板
                    Me.dgvPartNumber.Visible = True
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardCutBody_CellClick", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvCutCardBody_CellDoubleClick"
    Private Sub dgvCutCardBody_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardBody.CellDoubleClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If e.ColumnIndex = CutCardBusiness.BodyGrid.SOP Then
                    'Mark by cq 20190624
                    'Dim imageFile As String = dgvCutCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                    'If imageFile <> "" Then
                    '    Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                    '    frmDialog.Show()
                    'End If
                Else
                    If editRight Then
                        If Me.CutCardStatus = 0 AndAlso e.RowIndex <> Me.dgvCutCardBody.RowCount - 1 Then
                            dgvCutCardBody.ReadOnly = False
                            'Me.dgvRunCardBody.EditMode = DataGridViewEditMode.EditOnEnter 'Mark by cq 20161216
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.StationSQ.ToString).ReadOnly = True
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.UserId.ToString).ReadOnly = True '修改人
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.InTime.ToString).ReadOnly = True '修改时间
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.StationName.ToString).ReadOnly = True '工站名称
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.SOP.ToString).ReadOnly = True 'SOP
                            dgvCutCardBody.Columns(CutCardBusiness.BodyGrid.ProcessStandard.ToString).ReadOnly = False '工艺标准
                            currentRowIndex = e.RowIndex
                            currentColumnIndex = e.ColumnIndex
                            currentColumnName = dgvCutCardBody.CurrentCell.OwningColumn.Name
                            m_currentBodyValue = dgvCutCardBody.CurrentCell.FormattedValue.ToString

                            If dgvCutCardBody.CurrentCell.OwningColumn.Name = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then
                                '  AddButton(currentColumnIndex, currentRowIndex)
                            End If
                        End If
                    End If
                End If
                dgvCutCardBody.Rows(dgvCutCardBody.Rows.Count - 1).ReadOnly = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardCutBody_CellDoubleClick", "RCard")
        End Try
    End Sub
#End Region

#Region "复制单元格 body"
    Private Sub tsmiBodyCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyCopy.Click
        Dim Selected As String = String.Empty
        Try
            If Not dgvCutCardBody.CurrentCell Is Nothing Then
                If IsDBNull(dgvCutCardBody.CurrentCell.Value) Then
                    Selected = ""
                Else
                    Selected = CStr(dgvCutCardBody.CurrentCell.Value)
                End If
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiBodyCopy_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "新增 body"
    Private Sub tsmiBodyAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyAdd.Click
        Try
            If Me.CutCardPN = String.Empty Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.CutCardStatus = 2 Or Me.CutCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.CutCardPN & """ 待审核或是已生效状态,不允许新增 O_O")
                Exit Sub
            End If
            Dim frmEdit As New FrmOldCutCardBodyEdit(Me.CutCardPN, "add", Nothing, Me, Me.Version, True)
            frmEdit.ShowDialog()
            '刷新
            LoadCutCardBody(Me.CutCardPN)
            If Me.CutCardStatus = 1 Then
                Me.CutCardStatus = 0
                LoadCutCardHeader("")
                LoadSideBarByClick("desc", CutCardType.UnFinish)
            End If
            If dgvCutCardBody.Rows.Count <> 0 Then
                dgvCutCardBody.FirstDisplayedScrollingRowIndex = dgvCutCardBody.Rows.Count - CInt(IIf(dgvCutCardBody.Rows.Count > 10, 10, 1))
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiBodyAdd_Click", "RCard")
        End Try
    End Sub
#End Region


#Region "修改 body"
    Private Sub tsmiBodyModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyModify.Click
        Try
            If Me.tsmiBodyModify.Tag Is Nothing Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.CutCardStatus = 2 Or Me.CutCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.CutCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If

            Dim frmDialog As New FrmOldCutCardBodyEdit(Me.CutCardPN, "modify", CType(Me.tsmiBodyModify.Tag, DataGridViewRow), Me, Me.Version, True)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadCutCardBody(Me.CutCardPN, Me.Version)
                If Me.CutCardStatus = 1 Then
                    Me.CutCardStatus = 0
                    LoadCutCardHeader("", True, True, False)
                    LoadSideBarByClick("desc", CutCardType.UnFinish)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiBodyModify_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "旧裁线卡确认body（并且直接当做已完成)"
    Private Sub tsmiBodyConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyConfirm.Click
        Dim strTempPartId As String = String.Empty, strTempVer As String = ""
        Dim sql As String = String.Empty
        Dim strTempStationNameList As String = String.Empty
        Dim strTiptopVer As String = String.Empty
        Try
            If Me.dgvCutCardBody.Rows.Count <= 0 Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If

            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    strTempPartId = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString


                    If Not CheckStatus(row) Then
                        MessageUtils.ShowInformation("非制作中状态不允许确认！")
                    Else
                        strTempPartId = row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        strTempVer = row.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                        sql &= CutCardBusiness.GetOldCutBodyConfirmSQL(strTempPartId, strTempVer)

                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                Exit Sub
            End If

            If MessageUtils.ShowConfirm("确定要确认选中的旧裁线卡信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)


                'mark by cq 20160729
                ' LoadRunCardHeader("")
                ' LoadRunCardBody(Me.RunCardId)
                '刷新
                LoadSideBarByClick("desc", CutCardType.Audit)
                '展开
                'SideBar1.ExpandedPanel = sbPanelAudit
                '提示
                MessageUtils.ShowInformation("旧料件:" & Me.CutCardPN & "确认成功！")

                For Each row As DataGridViewRow In dgvCutCardHeader.Rows
                    If Not row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                           row.Cells(CutCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                        row.Cells(CutCardBusiness.NewHeaderGrid.ZStatus).Value = "已完成"
                        row.Cells(CutCardBusiness.NewHeaderGrid.Status).Value = "1"
                    End If
                Next

                Dim dt As New DataTable
                dt = CType(dgvCutCardBody.DataSource, DataTable)
                'cq 20161108
                If (Not IsNothing(dt)) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.Clear()
                End If
                dgvCutCardBody.DataSource = dt
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiBodyConfirm_Click", "RCard")
        End Try
    End Sub

    Private Sub UpdateTVPNShow(ByVal cutPartID As String, ByRef o_strSQL As String)
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim o_strSQL11 As New StringBuilder

        'first get every station 
        lsSQL = "SELECT StationID from m_RCardCutD_t  WHERE partid ='" & cutPartID & "'"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows()
                    Call ExistLCLCurrentStation(cutPartID, CStr(DBNullToStr(dr.Item(0))), o_strSQL11)
                    If Not String.IsNullOrEmpty(o_strSQL11.ToString) Then
                        o_strSQL = o_strSQL + o_strSQL11.ToString
                    End If
                Next
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateLeftProcessStd(ByVal cutPartID As String, ByRef o_strSQL As String)
        Dim o_strTmpLeftProcessStd As String = ""
        Dim lsSQL As New StringBuilder
        lsSQL.Append("  SELECT LeftProcessStandard,ProcessStandard, a.stationid , b.stationname, a.PartID ")
        lsSQL.Append("  FROM dbo.m_RCardCUtD_t a LEFT JOIN  dbo.m_Rstation_t b  ON a.StationID = b.stationid ")
        lsSQL.Append("   WHERE 1=1 ")
        lsSQL.Append(" AND a.PartID='" & cutPartID & "'")
        lsSQL.Append("AND  CHARINDEX(N'左',ProcessStandard) > 0")
        lsSQL.Append(" AND ISNULL(LeftProcessStandard,'') =''")

        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL.ToString)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    o_strTmpLeftProcessStd = ""
                    ' NULL	裁线尺寸(mm)=124±1; 左脱皮=10.5; 右脱皮=11; 	R02672	裁线/脱皮W9	904093120-02
                    For Each Item As String In dr.Item("ProcessStandard").ToString.Split(CChar(";"))
                        If Item.IndexOf("左") >= 0 Then
                            o_strTmpLeftProcessStd = o_strTmpLeftProcessStd + Item + ";"
                        End If
                    Next

                    If Not String.IsNullOrEmpty(o_strTmpLeftProcessStd) Then
                        o_strSQL = o_strSQL + "Update m_RCardCUtD_t set LeftProcessStandard =N'" & o_strTmpLeftProcessStd.Trim & "' where  partid ='" & cutPartID & "' and stationid ='" & dr.Item("stationid").ToString & " '"
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub UpdateRightProcessStd(ByVal cutPartID As String, ByRef o_strSQL As String)
        Dim o_strTmpRightProcessStd As String = ""
        Dim lsSQL As New StringBuilder
        lsSQL.Append("  SELECT RightProcessStandard,ProcessStandard, a.stationid , b.stationname, a.PartID ")
        lsSQL.Append("  FROM dbo.m_RCardCutD_t a LEFT JOIN  dbo.m_Rstation_t b  ON a.StationID = b.stationid ")
        lsSQL.Append("   WHERE 1=1 ")
        lsSQL.Append(" AND a.PartID='" & cutPartID & "'")
        lsSQL.Append("AND  CHARINDEX(N'右',ProcessStandard) > 0")
        lsSQL.Append(" AND ISNULL(RightProcessStandard,'') =''")

        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL.ToString)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    'frist clear 
                    o_strTmpRightProcessStd = ""

                    ' NULL	裁线尺寸(mm)=124±1; 左脱皮=10.5; 右脱皮=11; 	R02672	裁线/脱皮W9	904093120-02
                    For Each Item As String In dr.Item("ProcessStandard").ToString.Split(CChar(";"))
                        If Item.IndexOf("右") >= 0 Then
                            o_strTmpRightProcessStd = o_strTmpRightProcessStd + Item + ";"
                        End If
                    Next

                    If Not String.IsNullOrEmpty(o_strTmpRightProcessStd) Then
                        o_strSQL = o_strSQL + "Update m_RCardCutD_t set RightProcessStandard =N'" & o_strTmpRightProcessStd.Trim & "' WHERE  partid ='" & cutPartID & "' and stationid ='" & dr.Item("stationid").ToString & " '"
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub ExistLCLCurrentStation(ByVal strPartID As String, ByVal strStationID As String, ByRef strTempSQL As StringBuilder)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lssql As String = "", strLflag As String = "", strRFlag As String = ""
        strTempSQL = New StringBuilder

        lssql = " SELECT TOP 1 LeftTVPN, RightTVPN FROM m_CutCardDCheckItem_t " & _
                " WHERE PARTID ='" & strPartID & "' AND stationid ='" & strStationID & "' AND CheckItemID ='LCL'   "

        Using o_dt As DataTable = sConn.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                '
                ExistLDPart(strPartID, strStationID, CStr(DBNullToStr(o_dt.Rows(0).Item(0))), strLflag)

                If strLflag = "NL" Then
                    strTempSQL.Append(" Update m_CutCardDCheckItem_t SET LeftTVPnShow= ''")
                    strTempSQL.Append("  WHERE PartID ='" & strPartID & "' AND stationid ='" & strStationID & "' AND CheckItemID ='LCL' ")
                Else
                    strTempSQL.Append(" Update m_CutCardDCheckItem_t SET LeftTVPnShow=LeftTVPn ")
                    strTempSQL.Append("  WHERE PartID ='" & strPartID & "' AND stationid ='" & strStationID & "' AND CheckItemID ='LCL' ")
                End If


                ExistRDPart(strPartID, strStationID, CStr(DBNullToStr(o_dt.Rows(0).Item(1))), strRFlag)

                If strRFlag = "NR" Then
                    strTempSQL.Append(" Update m_CutCardDCheckItem_t SET  RightTVPNShow='' WHERE PartID ='" & strPartID & "' AND stationid ='" & strStationID & "' AND CheckItemID ='LCL'")
                Else
                    strTempSQL.Append(" Update m_CutCardDCheckItem_t SET  RightTVPNShow=RightTVPN WHERE PartID ='" & strPartID & "' AND stationid ='" & strStationID & "' AND CheckItemID ='LCL'")
                End If

            End If
        End Using
    End Sub

    '把DBNUll值变为空
    Private Function DBNullToStr(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString().Trim()
            End If
        End If
    End Function

    Private Sub ExistLDPart(ByVal strPartID As String, ByVal strStationID As String, ByVal strLeftTVPN As String, _
                            ByRef strLflag As String)
        Dim lsSQL As String = "", lsSQL1 As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        lsSQL = " SELECT  *  FROM  m_CutCardDPart_t " & _
                " WHERE partid ='" & strPartID & "' AND Stationid='" & strStationID & "' AND  EWPartNumber='" & strLeftTVPN & "' "

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                strLflag = "EL"
            Else
                ' Left TVPN not exist
                strLflag = "NL"
            End If
        End Using
    End Sub

    Private Sub ExistRDPart(ByVal strPartID As String, ByVal strStationID As String, _
                               ByVal strRightTVPN As String, ByRef strRflag As String)

        Dim lsSQL As String = "", lsSQL1 As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass


        lsSQL1 = " SELECT  *  FROM  m_CutCardDPart_t " & _
                 " WHERE partid ='" & strPartID & "' and Stationid='" & strStationID & "' AND  EWPartNumber='" & strRightTVPN & "' "


        Using o_dt As DataTable = sConn.GetDataTable(lsSQL1)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                strRflag = "ER"
            Else
                ' Right TVPN not exist
                strRflag = "NR"
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 检查旧版本的裁线卡
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = CutCardBusiness.GetAutiStatus(True, row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                '??制作中状态
                If CInt(dt.Rows(0)(0).ToString) = 0 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckStatus", "RCard")
            Return False
        End Try
    End Function

    Private Function CheckRCardStatus(ByVal strPartID As String) As Boolean
        Try
            Dim dt As DataTable = CutCardBusiness.GetAutiStatus(True, strPartID)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0).ToString) = 0 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckRCardStatus", "RCard")
            Return False
        End Try
    End Function

    Private Function CheckStatusNotFinish(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = CutCardBusiness.GetAutiStatus(True, row.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0).ToString) = 0 OrElse CInt(dt.Rows(0)(0).ToString) = 2 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CheckStatusNotFinish", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "绑定右健菜单"
    Private Sub dgvRunCardBody_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvCutCardBody.CellContextMenuStripNeeded
        Try
            e.ContextMenuStrip = Me.ContextMenuBody
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "CellContextMenuStripNeeded", "RCard")
        End Try
    End Sub
#End Region

#Region "鼠标右击处理 body"
    Private Sub dgvCutCardBody_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCutCardBody.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If e.RowIndex > -1 Then
                    '最后一行是汇总行
                    If e.RowIndex <> dgvCutCardBody.Rows.Count - 1 Then
                        dgvCutCardBody.CurrentCell = dgvCutCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex)
                        dgvCutCardBody.CurrentCell.Selected = True
                        Dim row As DataGridViewRow = dgvCutCardBody.CurrentRow
                        Me.tsmiBodyModify.Tag = row
                        '右健改变当前行号
                        dgvCutCardBody.ClearSelection()
                        dgvCutCardBody.Rows(e.RowIndex).Selected = True
                        dgvCutCardBody.CurrentCell = dgvCutCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex)
                        '
                        Me.CutCardStationId = CStr(Me.dgvCutCardBody.Item(CutCardBusiness.BodyGrid.StationID.ToString, Me.dgvCutCardBody.CurrentRow.Index).Value.ToString)
                        '加载料件信息
                        Me.LoadPartGrid(Me.CutCardPN, Me.CutCardStationId)
                        '显示料件面板
                        Me.dgvPartNumber.Visible = True
                    End If
                Else
                    Me.tsmiBodyModify.Tag = Nothing
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvCutCardBody_CellMouseDown", "RCard")
        End Try
    End Sub
#End Region

#Region "字体颜色处理 body"
    Private Sub dgvRunCardBody_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvCutCardBody.DataBindingComplete
        Dim tempSectionID As String = ""
        Try
            For Each item As DataGridViewRow In dgvCutCardBody.Rows
                If IsDBNull(item.Cells(CutCardBusiness.BodyGrid.SectionID.ToString).Value) Then
                    tempSectionID = ""
                Else
                    tempSectionID = CStr(item.Cells(CutCardBusiness.BodyGrid.SectionID.ToString).Value)
                End If
                ' tempSectionID = CStr(IIf(IsDBNull(item.Cells(CutCardBusiness.BodyGrid.SectionID.ToString).Value), "", CStr(item.Cells(CutCardBusiness.BodyGrid.SectionID.ToString).Value)))
                Select Case tempSectionID
                    Case "1", "01" '前段加工
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.LightGreen
                    Case "2", "02" '产线加工
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Aqua
                    Case "3", "03" '成型加工
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.PeachPuff
                    Case "4", "04"
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.WhiteSmoke
                    Case "5", "05"
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.MistyRose
                    Case "A05"
                        item.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Tomato
                    Case Else
                        'do nothing
                End Select
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_DataBindingComplete", "RCard")
        End Try
    End Sub
#End Region

#Region "AutoUpdate"

    Private btn As Button = New Button()
    Private currentRowIndex As Integer = -1
    Private currentColumnIndex As Integer = 0
    Private currentColumnName As String = ""
    Private currentLeft As Integer = 0
    Private currentTop As Integer = 0
    Private currentValue As String = ""
    Private m_currentBodyValue As String = ""
    Private currentOldWorkHour As String = ""
    Private isClose As Boolean = False
    Private ft As New System.Drawing.Font("Arial", 7)
    Private reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,4})(\.\d{0,1}[1-9])?$")

    Private Sub dgvCutCardBody_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardBody.CellEnter
        Try
            If e.RowIndex < dgvCutCardBody.Rows.Count - 1 AndAlso Me.dgvCutCardBody.ReadOnly = False Then
                currentRowIndex = e.RowIndex
                If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then
                    Exit Sub
                End If
                currentColumnIndex = e.ColumnIndex
                currentColumnName = dgvCutCardBody.CurrentCell.OwningColumn.Name
                m_currentBodyValue = dgvCutCardBody.CurrentCell.FormattedValue.ToString
                currentOldWorkHour = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours).FormattedValue.ToString

                'Modify by CQ 20151030,工站名称/工艺标准 ==> 工艺标准
                If currentColumnName = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then '工艺标准
                    ' AddButton(currentColumnIndex, currentRowIndex)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_CellEnter", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    Private Sub dgvRunCardBody_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCutCardBody.CellLeave
        Try

            If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then
                Exit Sub
            End If

            Me.dgvCutCardBody.Controls.Clear()
            If dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString <> m_currentBodyValue Then
                'Modify by cq 2018011, Rows(currentRowIndex)==> CurrentRow
                Dim runCardId As String = dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.PartId.ToString).Value.ToString

                If String.IsNullOrEmpty(runCardId) Then Exit Sub

                If Me.CheckRCardStatus(runCardId) Then
                    UpdateData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_CellLeave", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgvRunCardBody_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvCutCardBody.ColumnWidthChanged
        Try
            'Add by cq 20161103
            If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            btn.Width = CInt(Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Width / 5)
            btn.Location = New System.Drawing.Point(CInt(IIf((Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width) < 0, 0, Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width)), Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y)
            If currentRowIndex = 0 Then
                currentLeft = btn.Left
                currentTop = btn.Top
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_ColumnWidthChanged", "RCard")
        End Try
    End Sub

    Private Sub dgvRunCardBody_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvCutCardBody.Scroll
        Try
            'Add by cq 20161103
            If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            btn.Left = Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width
            btn.Top = Me.dgvCutCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y
            If currentRowIndex = 0 AndAlso e.ScrollOrientation = ScrollOrientation.VerticalScroll AndAlso e.NewValue = 0 Then
                btn.Left = currentLeft
                btn.Top = currentTop
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_Scroll", "RCard")
        End Try
    End Sub

    Private Sub btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim frmModify As FrmCutCardBodyModify = Nothing
            If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            'Modify by cq20171229 dgvCutCardBody.Rows(currentRowIndex)==> dgvCutCardBody.CurrentRow
            If currentColumnName = CutCardBusiness.BodyGrid.StationName.ToString Then '工站名称
                frmModify = New FrmCutCardBodyModify(Me.CutCardPN, FrmCutCardBodyModify.ActionType.ModifyStation, dgvCutCardBody.CurrentRow, True, Me.Version)
            ElseIf currentColumnName = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then '工艺标准
                frmModify = New FrmCutCardBodyModify(Me.CutCardPN, FrmCutCardBodyModify.ActionType.ModifyProcessParameter, dgvCutCardBody.CurrentRow, True, Me.Version)
            End If
            If Not frmModify Is Nothing Then
                If frmModify.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If currentColumnName = CutCardBusiness.BodyGrid.StationName.ToString Then
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Value = frmModify.outputStationName
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.StationID.ToString).Value = frmModify.outputStationId
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.ProcessStandard.ToString).Value = ""
                    Else
                        'Modify by cq 20170307  dgvRunCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.ProcessStandard.ToString).Value==> ''
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.ProcessStandard.ToString).Value =
                            IIf(String.IsNullOrEmpty(frmModify.outputProcessStand),
                                "", frmModify.outputProcessStand)

                        'add by cq20190620
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.LCLValue.ToString).Value =
                        IIf(String.IsNullOrEmpty(frmModify.outputLCLValue),
                            "", frmModify.outputLCLValue)

                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                        dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now

                        If Val(dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.WorkingHours).Value) <> frmModify.m_iTotalStdTime AndAlso (frmModify.m_iTotalStdTime > 0) Then
                            Call UpdateStdTime(frmModify.m_iTotalStdTime.ToString)
                            dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.WorkingHours).Value = frmModify.m_iTotalStdTime
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "btn_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgvCutCardBody_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dgvCutCardBody.CellBeginEdit
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            ' 是否可以进行编辑的条件检查
            If dgvCutCardBody.CurrentCell.OwningColumn.Name = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then
                If IsNothing(dgv.CurrentRow) Then
                    Exit Sub
                End If

                Dim stationID As String = dgv.CurrentRow.Cells(CutCardBusiness.BodyGrid.StationID.ToString).Value.ToString()
                If CutCardBusiness.CheckStationMaintainCheckItem(stationID) Then
                    e.Cancel = True
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardBody_CellBeginEdit", "RCard")
        End Try
    End Sub

    Private Sub dgvPartNumber_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPartNumber.MouseDown
        Me.dgvCutCardBody.ReadOnly = True
    End Sub

#End Region

#End Region

#Region "CutCardCutPart"

#Region "绑定 CutCard 料件"
    Private Sub LoadPartGrid(cutCardPartId As String, stationID As String, Optional strCutCardVer As String = "")
        Try
            Dim dt As DataTable = CutCardBusiness.GetCutCardPart(True, cutCardPartId, stationID, strCutCardVer)
            dgvPartNumber.DataSource = dt

            If dgvPartNumber.Columns.Count <= 3 Then
                Dim clo As New DataGridViewCheckBoxColumn
                clo.HeaderText = "选择"
                clo.Width = 50
                clo.TrueValue = True
                Me.dgvPartNumber.Columns.Insert(0, clo)
            End If

            Dim ChColsText As String = "选择|料件编号|品名|规格"
            Dim colColsText As String() = ChColsText.Split(CChar("|"))
            For i As Integer = 0 To dgvPartNumber.Columns.Count - 1
                If dgvPartNumber.Columns.Count >= i + 1 Then
                    dgvPartNumber.Columns(i).HeaderText = colColsText(i)
                End If
            Next
            dgvPartNumber.Columns(PartGrid.DESCRIPTION.ToString).AutoSizeMode = CType(System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, DataGridViewAutoSizeColumnMode)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "LoadPartGrid", "RCard")
        End Try
    End Sub
#End Region

#Region "增加料件信息"
    Private Sub menuAddPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiPartAdd.Click
        Dim o_strCutCardVersion As String = ""
        Try
            '审核中：不可修改
            If Me.CutCardStatus = 2 Then
                MessageUtils.ShowInformation("料件:""" & Me.CutCardPN & """ 待审核状态,不允许修改！")
                Exit Sub
            End If

            '已完成：不可修改
            If Me.CutCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.CutCardPN & """ 已完成状态,不允许修改！")
                Exit Sub
            End If
            '检查BOM是否需要更新
            If NeedUpdateBom() Then
                MessageUtils.ShowInformation("料件""" & Me.CutCardPN & """BOM中的部分物料已失效，请及时更新BOM！")
            End If

            If String.IsNullOrEmpty(Me.Version) Then
                o_strCutCardVersion = CStr(Me.dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.HeaderGrid.DrawingVer.ToString).Value)
            Else
                o_strCutCardVersion = Me.Version
            End If

            Dim frmDialog As New FrmCutCardPartDetail(Me.CutCardPN, Me.CutCardStationId, o_strCutCardVersion, True)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ''刷新
                LoadPartGrid(Me.CutCardPN, Me.CutCardStationId)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "menuAddPart_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "删除料件信息"
    Private Sub tsmiPartDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiPartDelete.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            Dim isOldVersion As Boolean = False
            Dim partID As String = String.Empty

            '已完成：不可修改
            If Me.CutCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.CutCardPN & """ 已完成状态,不允许删除！")
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvPartNumber.Rows
                If Not row.Cells(0).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    partID = row.Cells(1).Value.ToString
                    sql &= CutCardBusiness.DeleteDPartID(True, Me.CutCardPN, partID, Me.CutCardStationId)
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                MessageUtils.ShowError("无选中项！")
                Exit Sub
            End If

            RCardComBusiness.ExecSQL(sql)
            ''刷新
            LoadPartGrid(Me.CutCardPN, Me.CutCardStationId)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiPartDelete_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#End Region

#Region "方法"

#Region "打印裁线卡"

    Private Sub PrintCutCard(Optional ByVal pn As String = "", Optional ByVal o_strCutcard As List(Of RCardComBusiness.stcCutcard) = Nothing)
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Try
            If Not IsNothing(o_strCutcard) Then
                For Each o_strTempCutcard In o_strCutcard
                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempCutcard.CutCardPartPN & ".xlsx" & ","
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempCutcard.CutCardPartPN & ".xlsx"

                    Dim frmStation As New FrmCutCardImportStation(o_strTempCutcard.CutCardPartPN, "Export", True)

                    frmStation.cutCardPartId = o_strTempCutcard.CutCardPartPN

                    Using dt As DataTable = RCardComBusiness.GetDataTable(frmStation.GetExportSql(o_strTempCutcard.CutCardPartPN))
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If CutCardBusiness.Import2ExcelByAs(frmStation.m_strCutfilePath, o_outputFile, dt, frmStation.GetVariables(dt), o_strTempCutcard.CutCardPartPN, errorMsg) Then  'outputFile
                                '先生成excel文件
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件找不到对应的裁线卡！")
                        End If
                    End Using
                Next

                outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Using FrmShow As New FrmShowRunCard()
                    FrmShow.filePath = outputFileList
                    FrmShow.m_iDirection = 1  '纵向
                    FrmShow.ShowDialog()
                End Using
            Else
                o_outputFile = Environment.CurrentDirectory + "\" & pn & ".xlsx"
                Dim frmStation As New FrmCutCardImportStation(Me.CutCardPN, "Export", True)
                frmStation.cutCardPartId = Me.CutCardPN
                Using dt As DataTable = RCardComBusiness.GetDataTable(frmStation.GetExportSql(Me.CutCardPN))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        If CutCardBusiness.Import2ExcelByAs(frmStation.m_strCutfilePath, o_outputFile, dt, frmStation.GetVariables(dt), Me.CutCardPN, errorMsg) Then
                            Using frmshow As New FrmShowRunCard()
                                frmshow.filePath = o_outputFile
                                frmshow.ShowDialog()
                            End Using
                        Else
                            MessageUtils.ShowError(errorMsg)
                        End If
                    Else
                        MessageUtils.ShowError("料件找不到对应的裁线卡！")
                    End If
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "PrintCutCard", "RCard")
            Throw ex
        Finally
            If Not String.IsNullOrEmpty(outputFileList) Then
                For Each outputFile As String In outputFileList.Split(CChar(","))
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
        Try
            Dim dt As DataTable = CutCardBusiness.GetBomInfo(Me.CutCardPN)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "NeedUpdateBom", "RCard")
            Return False
        End Try
    End Function
#End Region

    Public Sub BindBodyWhenAdd(ByVal cutCardPartId As String)
        Try
            LoadCutCardBody(cutCardPartId)
            If Me.CutCardStatus = 1 Then
                Me.CutCardStatus = 0
                LoadCutCardHeader("")
                LoadSideBarByClick("desc", CutCardType.UnFinish)
            End If
            dgvCutCardBody.FirstDisplayedScrollingRowIndex = dgvCutCardBody.Rows.Count - CInt(IIf(dgvCutCardBody.Rows.Count > 10, 10, 1))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "BindBodyWhenAdd", "RCard")
        End Try
    End Sub

    Private Sub AddButton(ByVal cIndex As Integer, ByVal rIndex As Integer)
        Try
            Me.dgvCutCardBody.Controls.Clear()
            If Me.CutCardStatus = 0 Then
                btn.Text = "Q"
                btn.Font = ft
                btn.Visible = True
                btn.ForeColor = Color.Black
                btn.BackColor = Color.WhiteSmoke
                btn.Width = CInt(Me.dgvCutCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Width / 5)
                btn.Height = Me.dgvCutCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height
                Me.dgvCutCardBody.Controls.Add(btn)
                btn.Location = New System.Drawing.Point((Me.dgvCutCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Right - btn.Width), Me.dgvCutCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Y)
                If currentColumnName = CutCardBusiness.BodyGrid.StationName.ToString Then
                    RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                    AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
                End If
                If currentColumnName = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then
                    RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                    AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
                End If
                If rIndex = 0 Then
                    currentLeft = btn.Left
                    currentTop = btn.Top
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "AddButton", "RCard")
        End Try
    End Sub

    Private Sub UpdateData()
        Try
            If dgvCutCardBody.RowCount > 0 Then
                If dgvCutCardBody.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString <> m_currentBodyValue Then
                        If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then
                            Exit Sub
                        End If
                        Dim runCardId As String = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.PartId.ToString).Value.ToString
                        Dim stationId As String = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.StationID.ToString).Value.ToString
                        Dim WorkingHours As String = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours.ToString).EditedFormattedValue.ToString
                        Dim editValue As String = dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

                        If currentColumnName = CutCardBusiness.BodyGrid.WorkingHours.ToString Then
                            If Not reg.IsMatch(dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString.Trim) Then
                                dgvCutCardBody.CurrentCell = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours.ToString)
                                dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
                                MessageUtils.ShowError("工时格式不正确，请确认！")
                                Return
                            End If
                        End If

                        If currentColumnName = CutCardBusiness.BodyGrid.ProcessStandard.ToString Then
                            'Add reg in order to check not allow the error ProcessStandard key in to DB 
                            If reg.IsMatch(dgvCutCardBody.CurrentCell.EditedFormattedValue.ToString.Trim) Then
                                dgvCutCardBody.CurrentCell = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.ProcessStandard.ToString)
                                dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.ProcessStandard.ToString).Selected = True
                                ' 
                                Return
                            End If

                            If m_currentBodyValue.IndexOf("裁线尺寸") >= 0 OrElse m_currentBodyValue.IndexOf("左端脱皮") >= 0 OrElse m_currentBodyValue.IndexOf("左高度mm") >= 0 OrElse m_currentBodyValue.IndexOf("右高度mm") >= 0 Then
                                Return
                            End If
                        End If

                        Dim strSQL As String = CutCardBusiness.GetBodyUpdateSQL(True, currentColumnName, editValue, runCardId, stationId, m_currentBodyValue)

                        If Not String.IsNullOrEmpty(strSQL) Then
                            RCardComBusiness.ExecSQL(strSQL)

                            If currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then
                                dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.LCLValue.ToString).Value = editValue
                            End If

                            currentRowIndex = -1

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "UpdateData", "RCard")
        End Try
    End Sub

    Private Sub UpdateStdTime(ByVal parCountWorkHoursValue As String)
        Try
            If dgvCutCardBody.RowCount > 0 Then
                If currentRowIndex < 0 OrElse Me.dgvCutCardBody.RowCount <= currentRowIndex Then
                    Exit Sub
                End If

                Dim runCardId As String = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.PartId.ToString).Value.ToString
                Dim stationId As String = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.StationID.ToString).Value.ToString

                If Not reg.IsMatch(parCountWorkHoursValue) Then
                    dgvCutCardBody.CurrentCell = dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours.ToString)
                    dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
                    MessageUtils.ShowError("工时格式不正确，请确认！")
                    Return
                End If

                Dim strSQL As String = CutCardBusiness.GetBodyUpdateSQL(True, CutCardBusiness.BodyGrid.WorkingHours.ToString, parCountWorkHoursValue, runCardId, stationId, "")

                If Not String.IsNullOrEmpty(strSQL) Then
                    RCardComBusiness.ExecSQL(strSQL)
                    dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                    dgvCutCardBody.Rows(currentRowIndex).Cells(CutCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "UpdateStdTime", "RCard")
        End Try
    End Sub

#Region "SetControlStatus"
    Private Sub SetControlStatus()
        Try

            If tsmiHeaderAdd.Tag Is Nothing Then tsmiHeaderAdd.Tag = ""
            If tsmiHeaderModify.Tag Is Nothing Then tsmiHeaderModify.Tag = ""
            If tsmiHeaderSearch.Tag Is Nothing Then tsmiHeaderSearch.Tag = ""
            If tsmiHeaderPrint.Tag Is Nothing Then tsmiHeaderPrint.Tag = ""
            If tsmiHeaderImport.Tag Is Nothing Then tsmiHeaderImport.Tag = ""
            If tsmiHeaderExport.Tag Is Nothing Then tsmiHeaderExport.Tag = ""
            If tsmiHeaderReject.Tag Is Nothing Then tsmiHeaderReject.Tag = ""
            If tsmiHeaderCancel.Tag Is Nothing Then tsmiHeaderCancel.Tag = ""

            Me.tsmiHeaderAdd.Enabled = CBool(IIf(tsmiHeaderAdd.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderModify.Enabled = CBool(IIf(tsmiHeaderModify.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderSearch.Enabled = CBool(IIf(tsmiHeaderSearch.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderPrint.Enabled = CBool(IIf(tsmiHeaderPrint.Tag.ToString = "YES", True, False))

            Me.tsmiHeaderImport.Enabled = CBool(IIf(tsmiHeaderImport.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderExport.Enabled = CBool(IIf(tsmiHeaderExport.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderReject.Enabled = CBool(IIf(tsmiHeaderReject.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderCancel.Enabled = CBool(IIf(tsmiHeaderCancel.Tag.ToString = "YES", True, False))

            If tsmiBodyAdd.Tag Is Nothing Then tsmiBodyAdd.Tag = ""
            If tsmiBodyModify.Tag Is Nothing Then tsmiBodyModify.Tag = ""
            If tsmiBodyConfirm.Tag Is Nothing Then tsmiBodyConfirm.Tag = ""

            If tsmiPartAdd.Tag Is Nothing Then tsmiPartAdd.Tag = ""

            Me.tsmiBodyAdd.Enabled = CBool(IIf(tsmiBodyAdd.Tag.ToString = "YES", True, False))
            Me.tsmiBodyModify.Enabled = CBool(IIf(tsmiBodyModify.Tag.ToString = "YES", True, False))
            Me.tsmiBodyConfirm.Enabled = CBool(IIf(tsmiBodyConfirm.Tag.ToString = "YES", True, False))

            Me.tsmiPartAdd.Enabled = CBool(IIf(tsmiPartAdd.Tag.ToString = "YES", True, False))
            editRight = CBool(IIf(tsmiBodyModify.Tag.ToString = "YES", True, False))

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "SetControlStatus", "RCard")
        End Try
    End Sub
#End Region

#End Region

    Private Sub dgvCutCardHeader_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCutCardHeader.CellLeave
        Dim strAllowEditColList As String = "Shape,StdLabors"
        Try
            Me.dgvCutCardHeader.Controls.Clear()

            If IsNothing(dgvCutCardHeader.CurrentRow) Then
                Exit Sub
            End If

            If ("," & strAllowEditColList & ",").IndexOf(dgvCutCardHeader.CurrentCell.OwningColumn.Name) < 0 Then
                Exit Sub
            End If

            If IsNothing(dgvCutCardHeader.CurrentCell) Then
                Exit Sub
            End If

            If dgvCutCardHeader.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                If Not Me.tsmiBodyModify.Enabled = True Then
                    Exit Sub
                End If

                UpdateHeaderData(dgvCutCardHeader.CurrentCell.OwningColumn.Name)
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "dgvRunCardHeader_CellLeave", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub UpdateHeaderData(ByVal parcurrentColumnName As String)
        Dim strSQL As String = ""
        Dim o_strExecutSQLResult As String = ""
        Try
            If dgvCutCardHeader.RowCount > 0 Then
                If dgvCutCardHeader.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvCutCardHeader.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvCutCardHeader.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                        If IsNothing(dgvCutCardHeader.CurrentRow) Then
                            Exit Sub
                        End If
                        Dim runCardId As String = dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim editValue As String = dgvCutCardHeader.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

                        strSQL = CutCardBusiness.GetHeaderUpdateSQL(True, parcurrentColumnName, editValue, runCardId)

                        If Not String.IsNullOrEmpty(strSQL) Then
                            o_strExecutSQLResult = RCardComBusiness.ExecSQL(strSQL)
                            If o_strExecutSQLResult <> "" Then
                                MessageUtils.ShowError(o_strExecutSQLResult)
                                Exit Sub
                            End If

                            dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.HeaderGrid.ModifyTime.ToString).Value = Date.Now
                            If parcurrentColumnName.ToUpper = "STDLABORS" Then
                                dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.StdUPH.ToString).Value = Math.Round(Val(dgvCutCardHeader.CurrentRow.Cells(CutCardBusiness.NewHeaderGrid.StdUPPH.ToString).Value.ToString) * Val(editValue), 1)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "UpdateHeaderData", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub tsmiBodyDelete_Click(sender As Object, e As EventArgs) Handles tsmiBodyDelete.Click
        Try
            If IsNothing(Me.dgvCutCardBody.CurrentRow) Then   'Me.tsmiBodyDelete.Tag Is Nothing Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '  Dim row As DataGridViewRow = Me.dgvCutCardBody.CurrentRow     'CType(Me.tsmiBodyDelete.Tag, DataGridViewRow)
            Dim stationNo As String = Me.dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.StationID.ToString).Value.ToString
            Dim stationName As String = Me.dgvCutCardBody.CurrentRow.Cells(CutCardBusiness.BodyGrid.StationName.ToString).Value.ToString


            '审核中：不可删除
            If Me.CutCardStatus = 2 Or Me.CutCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.CutCardPN & """ 待审核或是已生效状态,不允许删除 O_O")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认删除所选工站:""" & stationNo & "-" & stationName & """ ?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                CutCardBusiness.DeleteCutBody(True, Me.CutCardPN, Me.CutCardStationId, Me.Version)

                '刷新
                LoadCutCardBody(Me.CutCardPN)
                If Me.CutCardStatus = 1 Then
                    Me.CutCardStatus = 0
                    LoadCutCardHeader("")
                    LoadSideBarByClick("desc", CutCardType.UnFinish)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCut", "tsmiBodyDelete_Click", "RCard")
        End Try
    End Sub
End Class