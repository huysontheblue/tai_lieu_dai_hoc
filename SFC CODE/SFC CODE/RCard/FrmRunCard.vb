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
'Imports SysBasicClass

Public Class FrmRunCard

    Private rowSpan As New SortedList()
    Private rowValue As String = ""
    Private editRight As Boolean = False
    Dim dv As DataView = Nothing
    Private m_dtRuncardHeader As DataTable
    Private m_dtRuncardLog As DataTable
    Private m_preHours As Double = 0  '铆端 01
    Private m_proHours As Double = 0  ' 产线 02
    Private m_ContourHours As Double = 0  '成型 03
    Private m_trimHours As Double = 0 '04,裁切 --  SemiAutoPreChild/ContourHourPreChild/MadeHourPreChild/CutProPreMO
    Private m_ProPreHours As Double = 0
    Private m_autoHours As Double = 0 'A05 , 半自动压接

    Private MyStationName As String = ""

    Private Enum RunCardType
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

    Public Structure strRuncard
        Public Status As String
        Public RunCardPartPN As String
        Public RCardVersion As String
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

#Region "RunCardPN"
    Private _runCardPN As String
    Public Property RunCardPN() As String
        Get
            Return _runCardPN
        End Get
        Set(ByVal value As String)
            _runCardPN = value
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

#Region "RunCardStationId"
    Private _runCardStationId As String
    Public Property RunCardStationId() As String
        Get
            Return _runCardStationId
        End Get
        Set(ByVal value As String)
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
    Private _isQueryOldVersion As Boolean = False
    Public Property IsQueryOldVersion() As Boolean
        Get
            Return _isQueryOldVersion
        End Get
        Set(ByVal value As Boolean)
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
            SetControlStatus()
            '绑定 runcard 头部
            LoadRunCardHeader("")
            '绑定 SideBar 菜单
            'LoadSideBar("", Me.RunCardData, "asc")

            'add by 马跃平 2018-07-09


            LoadSideBarByClick("desc", RunCardType.Audit)
            '隐藏料件面板
            Me.dgvPartNumber.Visible = False
            Me.WindowState = FormWindowState.Maximized

            '绑定右键菜单
            'dgvRunCardHeader.ContextMenuStrip = Me.ContextMenuHeader
            '绑定右键菜单
            ' dgvRunCardBody.ContextMenuStrip = Me.ContextMenuBody
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "FrmRunCard_Load", "RCard")
        End Try
    End Sub
#End Region

#Region "菜单事件"

#Region "退出"

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'mark by cq 20161102
    'Private Sub FrmRunCard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    'Try
    '    isClose = True
    '    'Add by cq 20161031
    '    Dim runCardId As String = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.PartId.ToString).Value.ToString
    '    If String.IsNullOrEmpty(runCardId) Then Exit Sub

    '    If Me.CheckRCardStatus(runCardId) Then
    '        UpdateData()
    '    End If
    'Catch ex As Exception
    'End Try
    'End Sub

#End Region

#Region "清除"
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            Me.txtSearch.Text = ""
            LoadSideBarByClick("", RunCardType.Finish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnClear_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "复制流程卡"
    Private Sub btnCopyRuncard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Try
            If dgvRunCardHeader.Rows.Count <= 0 Or dgvRunCardBody.Rows.Count <= 0 Then
                MessageUtils.ShowError("请选择完整的工艺流程！")
                Exit Sub
            End If
            Dim frmDialog As New FrmRunCardCopy()
            frmDialog.RCPartNumber = Me.RunCardPN
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ''刷新SideBar1
                ' LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("desc", RunCardType.UnFinish)
                '展开
                SideBar1.ExpandedPanel = sbPanelUnfinish
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnCopyRuncard_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "打印流程卡"
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim o_Runcard = New RCardComBusiness.stcRuncard
        Dim o_strRCardVersion As String = "", o_strErpVer As String = ""
        Try
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    o_Runcard.RunCardPartPN = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    o_Runcard.Status = row.Cells(RunCardBusiness.HeaderGrid.Status.ToString).Value.ToString

                    o_Runcard.RCardVersion = row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString

                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next

            If Me._runCardIDList.Count <= 0 Then
                MessageUtils.ShowError("请选择流程卡！")
                Exit Sub
            End If
            For Each RunCard As RCardComBusiness.stcRuncard In Me._runCardIDList
                If RunCard.RunCardPartPN = "" Then
                    MessageUtils.ShowError("请选择流程卡！")
                    Exit Sub
                End If

                'RunCard.RunCardPartPN.Substring(0, 1)<> "L"
                If Not String.IsNullOrEmpty(RunCard.RunCardPartPN) AndAlso RunCard.RunCardPartPN.Substring(0, 1) = "9" Then
                    'Modify by cq 20170206
                    o_strErpVer = RunCardBusiness.GetVerFromErp(RunCard.RunCardPartPN).ToUpper
                    If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso RunCard.RCardVersion.ToUpper.Trim <> o_strErpVer.Trim Then
                        MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,找SAP确认！",
                                                             RunCard.RunCardPartPN, RunCard.RCardVersion.ToUpper, o_strErpVer.ToUpper))
                        Exit Sub
                    End If
                End If

                If CInt(RunCard.Status) <> 1 Then
                    MessageUtils.ShowError("制作中和审核中的流程卡不允许打印！")
                    Exit Sub
                End If
            Next
            PrintRunCard("", Me._runCardIDList)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnPrint_Click", "RCard")
        Finally
            If (Not Me._runCardIDList Is Nothing) Then Me._runCardIDList.Clear()
        End Try
    End Sub
#End Region

#Region "刷新"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            '刷新
            LoadRunCardHeader("")
            'LoadSideBar("", Me.RunCardData)
            LoadSideBarByClick("", RunCardType.Finish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnRefresh_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "流程卡审核"
    Private Sub btnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit.Click
        Dim o_dtSectionHours As DataTable = Nothing
        Dim o_strTempPartID As String = "", o_strErpVer As String = String.Empty
        Try
            Dim sql As String = String.Empty, o_strSQL As StringBuilder = Nothing, o_strSQLMes As StringBuilder = Nothing
            Dim index As Integer = 0, i_ECB03 As Integer = 0
            Dim o_IsQAS As Boolean = False
            Dim o_strCreateUserID As String = "", o_strModifyUserID As String = "", o_ModifyTime As Date = Nothing, o_strAuditUserID As String = VbCommClass.VbCommClass.UseId, o_AuditTime As Date = DateTime.Now
            o_strSQL = New StringBuilder
            o_strSQLMes = New StringBuilder
            o_strSQL.AppendLine(" Begin")
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_strTempPartID = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    'Add if cq20161031
                    If o_strTempPartID.Substring(0, 1) = "9" Then
                        'Add check version, Add bypass RD abmi100 build partid, 20170206
                        o_strErpVer = RunCardBusiness.GetVerFromErp(o_strTempPartID).ToUpper
                        If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString.ToUpper.Trim <> o_strErpVer.Trim Then
                            MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,找SAP确认！",
                                                        row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString,
                                                        row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString.ToUpper.Trim,
                                                        o_strErpVer.ToUpper))
                            Exit Sub
                        End If
                    Else
                        'By pass 
                    End If
                    If Not CheckAutiStatus(row) Then
                        MessageUtils.ShowError(row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非审核状态！")
                        Exit Sub
                    Else
                        Dim partID As String = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim RCardVersion As String = row.Cells(RunCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                        o_strCreateUserID = RunCardBusiness.GetUserID(row.Cells(RunCardBusiness.HeaderGrid.UserId.ToString).Value.ToString)

                        o_strModifyUserID = RunCardBusiness.GetModifyUserID(partID, o_ModifyTime)

                        'cq 20170228
                        sql &= RunCardBusiness.GetUpateRCardMAndSaveBOMSQL(Me.IsQueryOldVersion, partID, RCardVersion)

                        'ecb17: 生产线前加工
                        '01: 铆端前加工,02:产线,03:成型,04:裁切前加工(仓库),05:生产线前加工 A05 半自动压接连接  
                        'First get every Partid sectionHours 
                        o_dtSectionHours = RunCardBusiness.GetdtSectionHours(partID)
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

                        'add by cq 20180724
                        If o_dtSectionHours.Select("SECTIONID='05'").Length > 0 Then
                            m_ProPreHours = Val(o_dtSectionHours.Select("SECTIONID='05'")(0).Item(1))
                        Else
                            m_ProPreHours = 0
                        End If

                        If o_dtSectionHours.Select("SECTIONID='A05'").Length > 0 Then
                            m_autoHours = Val(o_dtSectionHours.Select("SECTIONID='A05'")(0).Item(1))
                        Else
                            m_autoHours = 0
                        End If

                        SapCommon.syncTTTimeSap(partID, "1", "01", "铆端前加工", m_preHours, o_strSQL)
                        SapCommon.syncTTTimeSap(partID, "2", "02", "产线", m_proHours, o_strSQL)
                        SapCommon.syncTTTimeSap(partID, "3", "03", "成型", m_ContourHours, o_strSQL)
                        SapCommon.syncTTTimeSap(partID, "4", "04", "裁切前加工(仓库)", m_trimHours, o_strSQL) '04.裁切前加工(仓库)
                        SapCommon.syncTTTimeSap(partID, "5", "05", "生产线前加工", m_ProPreHours, o_strSQL) '05.生产线前加工
                        SapCommon.syncTTTimeSap(partID, "15", "A05", "半自动压接连接", m_autoHours, o_strSQL)

                        o_strSQL.AppendLine(" COMMIT;")
                        'Call syncTTTimeLogRecord(partID, o_strModifyUserID, o_ModifyTime, o_strCreateUserID, o_AuditTime, o_strAuditUserID, o_strSQL)  ' PartID,o_strModifyUserID,o_ModifyTime ,o_strCreateUserID , o_AuditTime , ByVal o_strAuditUserID , ByRef o_strSQL 

                        '20190927 田玉琳增加 保存数据在工时表中m_TiptopStandardHours_t
                        SapCommon.syncSTTimeMes(partID, "1", "01", "铆端前加工", m_preHours, o_strSQLMes)
                        SapCommon.syncSTTimeMes(partID, "2", "02", "产线", m_proHours, o_strSQLMes)
                        SapCommon.syncSTTimeMes(partID, "3", "03", "成型", m_ContourHours, o_strSQLMes)
                        SapCommon.syncSTTimeMes(partID, "4", "04", "裁切前加工(仓库)", m_trimHours, o_strSQLMes)
                        SapCommon.syncSTTimeMes(partID, "5", "05", "生产线前加工", m_ProPreHours, o_strSQLMes)
                        SapCommon.syncSTTimeMes(partID, "15", "A05", "半自动压接连接", m_autoHours, o_strSQLMes)

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

                    'Add update std time to erp, cq 20160401
                    System.Environment.SetEnvironmentVariable("NLS_LANG ", " SIMPLIFIED CHINESE_CHINA.ZHS16GBK")

                    If o_IsQAS Then 'Add QAS oracle conn, cq 20160504
                        RCardComBusiness.Oracle_ExecuteNonQuery_QAS(o_strSQL.ToString)
                    Else
                        RCardComBusiness.ExecuteNonQuery(o_strSQL.ToString)
                        'If VbCommClass.VbCommClass.IsConSap = "Y" Then
                        '    ' DBUtility.DbOracleHelperSQL.ExecuteSql(o_strSQL.ToString)
                        '    OracleOperateUtils.ExecuteNonQuerySap(o_strSQL.ToString)
                        'Else
                        '    OracleOperateUtils.ExecuteNonQuery(o_strSQL.ToString)
                        '    ' DBUtility.DbOracleHelperSQL.ExecuteSql(o_strSQL.ToString)
                        'End If
                    End If

                    '先提交工时上传，再更新审核状态 20181217
                    RCardComBusiness.ExecSQL(sql, o_IsQAS)

                    '20190927 田玉琳 更新数据到MES
                    DbOperateUtils.ExecSQL(o_strSQLMes.ToString)

                    '提示
                    MessageUtils.ShowInformation("料件审核成功！")
                    '刷新SideBar1
                    LoadRunCardHeader("")
                    LoadSideBarByClick("Desc", RunCardType.Finish)
                    '展开
                    'SideBar1.ExpandedPanel = sbPanelFinish
                End If
            Else
                MessageUtils.ShowError("无选中项！")
            End If
        Catch ex As Exception
            Dim strFun As String = "btnAudit_Click"
            strFun = strFun + o_strTempPartID
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", strFun, "RCard")
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

            dt = RunCardBusiness.GetAutiStatus(Me.IsQueryOldVersion, row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                '是否审核状态？
                If CInt(dt.Rows(0)(0).ToString) = 2 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckAutiStatus", "RCard")
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
                    LoadSideBarByClick("", RunCardType.Finish)
                Else
                    LoadSideBar(" and PartID like '%" & str & "%'", Me.RunCardData, "asc", True)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "txtSearch_KeyDown", "RCard")
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
                    If CType(SelectedItem.Tag, ArrayList).Count > 0 Then 'CType(SelectedItem.Tag, ArrayList).Item.count > 0 Then
                        Me.RunCardPN = CStr(CType(SelectedItem.Tag, ArrayList).Item(0))
                    Else
                        Exit Sub
                    End If

                    If CType(SelectedItem.Tag, ArrayList).Count > 1 Then
                        Me.RunCardStatus = CInt(CType(SelectedItem.Tag, ArrayList).Item(1))
                    End If
                    '
                    rowSpan.Clear()
                    rowValue = ""
                    '隐藏料件面板
                    Me.dgvPartNumber.Visible = False

                    Dim dt = CType(Me.dgvRunCardHeader.DataSource, DataTable)
                    dt = RunCardBusiness.getNewRunCardData(Me.RunCardPN, dt)
                    If dt.Select("PartID='" & Me.RunCardPN & "'").Length > 0 Then
                        dt.Select("PartID='" & Me.RunCardPN & "'")(0)("ClickTime") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")
                    End If

                    dt.DefaultView.Sort = "ClickTime Desc"
                    Me.dgvRunCardHeader.DataSource = dt
                    'Me.RunCardData.DefaultView.Sort = "ClickTime Desc"
                    'Me.dgvRunCardHeader.DataSource = Me.RunCardData
                    Me.dgvRunCardHeader.Columns("ClickTime").Visible = False
                    LoadRunCardBody(Me.RunCardPN)
                    Me.dgvRunCardHeader.ClearSelection()
                    Me.dgvRunCardHeader.Item("PartID", 0).Selected = True
                    Me.dgvRunCardHeader.FirstDisplayedScrollingRowIndex = 0
                    For i As Integer = 0 To 200
                        If dgvRunCardHeader.Rows.Count > i Then
                            Me.dgvRunCardHeader.Rows(i).Cells(RunCardBusiness.HeaderGrid.CheckBox).Value = "False"
                        Else
                            Exit For
                        End If
                    Next

                    Me.dgvRunCardHeader.Controls.Add(m_ChkboxAll) ' Add by cq20151230
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "SideBar1_ItemClick", "RCard")
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
                LoadSideBarByClick(sort, RunCardType.UnFinish)
                sbPanelFinish.SubItems.Sort()
                sort = "asc"
            Else
                LoadSideBarByClick(sort, RunCardType.UnFinish)
                sort = "desc"
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "sbPanelUnfinish_Click", "RCard")
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
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "sbPanelAudit_Click", "RCard")
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
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "sbPanelFinish_Click", "RCard")
        End Try
    End Sub

#End Region

    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As RunCardType)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Try
            item.Image = ImageList1.Images(0)
            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left

            Dim Factory = VbCommClass.VbCommClass.Factory
            Dim profitcenter = VbCommClass.VbCommClass.profitcenter

            Dim dtt = RunCardBusiness.GetTypeToal(Factory, profitcenter)
            Dim o_strFinishNumT = dtt.Rows(0)("Finish").ToString()
            Dim o_strAuditNumT = dtt.Rows(0)("Audit").ToString()
            Dim o_strUnfinishT = dtt.Rows(0)("Unfinish").ToString()
            sbPanelFinish.Text = sbPanelFinish.Text.Split(CChar("("))(0) + "(" + o_strFinishNumT + ")"
            sbPanelAudit.Text = sbPanelAudit.Text.Split(CChar("("))(0) + "(" + o_strAuditNumT + ")"
            sbPanelUnfinish.Text = sbPanelUnfinish.Text.Split(CChar("("))(0) + "(" + o_strUnfinishT + ")"


            Select Case type
                Case RunCardType.UnFinish
                    dv = New DataView(RunCardBusiness.GetStatusTotal("0", Factory, profitcenter))
                    '晒选
                    dv.Sort = "InTime " & sort & " "
                    '未完成
                    'dv.RowFilter = "Status=0 "

                    '清除现有Item
                    sbPanelUnfinish.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelUnfinish.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelUnfinish
                Case RunCardType.Finish
                    ''已完成
                    'dv.RowFilter = "Status=1 "

                    dv = New DataView(RunCardBusiness.GetStatusTotal("1", Factory, profitcenter))
                    '晒选
                    dv.Sort = "InTime " & sort & " "

                    '清除现有Item
                    sbPanelFinish.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        'lst.Add(drv.Item("ID").ToString())
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelFinish.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelFinish
                Case RunCardType.Audit
                    '审核中
                    'dv.RowFilter = "Status=2 "

                    dv = New DataView(RunCardBusiness.GetStatusTotal("2", Factory, profitcenter))
                    '晒选
                    dv.Sort = "InTime " & sort & " "

                    '清除现有Item
                    sbPanelAudit.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item("PartID").ToString()
                        newItem.Text = drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                            drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                        lst = New ArrayList
                        'lst.Add(drv.Item("ID").ToString())
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                        lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelAudit.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelAudit
            End Select
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "LoadSideBarByClick", "RCard")
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
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                'lst.Add(drv.Item("ID").ToString())
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
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
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                'lst.Add(drv.Item("ID").ToString())
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
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
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                                                    drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
                lst = New ArrayList
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString())
                lst.Add(drv.Item(RunCardBusiness.HeaderGrid.Status.ToString).ToString())
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "LoadSideBar", "RCard")
        End Try

    End Sub
#End Region

#End Region

#Region "RunCardHeader"

#Region "绑定 RunCard 头部"
    Private m_ChkboxAll As New CheckBox
    Private Sub LoadRunCardHeader(ByVal sqlWhere As String, Optional ByVal isQquery As Boolean = False, _
                                  Optional ByVal isQueryOldVersion As Boolean = False, Optional ByVal o_blnReSet As Boolean = True)
        AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
        AddHandler dgvRunCardHeader.CellPainting, AddressOf dgvRunCardHeader_CellPainting
        Try
            Dim dt As DataTable = RunCardBusiness.GetRunCardHeader(isQueryOldVersion, sqlWhere, "")
            txtCount.Text = RunCardBusiness.GetRunCardHeaderTotal(isQueryOldVersion, sqlWhere, "").ToString()
            ' Dim dtSide As DataTable = RunCardBusiness.GetRunCardSide(isQueryOldVersion, sqlWhere)
            Dim o_strFinishNum As String = "0", o_strAuditNum As String = "0", o_strUnfinish As String = "0"
            If (Not IsNothing(Me.dgvRunCardHeader)) AndAlso Me.dgvRunCardHeader.ColumnCount > 0 Then
                Me.dgvRunCardHeader.Columns.Clear()
            End If
            Me.dgvRunCardHeader.DataSource = dt
            'm_dtRuncardHeader = dt 'update by 马跃平 2018-07-09

            'Me.txtCount.Text = CStr(dt.Rows.Count) 'updae by 马跃平 2018-07-09

            'Modfiy by cq20151229,add column 总工时
            Dim ChColsText As String = "ClickTime|料件编号|描述|总工时|规格|版本|形态|标准拍配人力(人)|标准UPPH(PCS/人/H)|标准UPH(PCS/H)|产品系列|文件编号|图纸文件|成品尺寸|状态|制作状态|创建人|创建时间|最近修改日期|备注|旧版本|RCardType"

            Dim colColsText As String() = ChColsText.Split(CChar("|"))



            'update by 马跃平 2018-07-09
            ''0.制作中;1.已生效;2: .待审核
            'If o_blnReSet Then
            '    o_strFinishNum = CStr(dt.Select("status=1").Length) : o_strAuditNum = CStr(dt.Select("status=2").Length) : o_strUnfinish = CStr(dt.Select("status=0").Length)
            '    sbPanelFinish.Text = sbPanelFinish.Text.Split(CChar("("))(0) + "(" + o_strFinishNum + ")"
            '    sbPanelAudit.Text = sbPanelAudit.Text.Split(CChar("("))(0) + "(" + o_strAuditNum + ")"
            '    sbPanelUnfinish.Text = sbPanelUnfinish.Text.Split(CChar("("))(0) + "(" + o_strUnfinish + ")"
            'End If

            'Add by cq 20161103
            If dgvRunCardHeader.Columns.Count > 0 Then
                For i As Integer = 0 To dgvRunCardHeader.Columns.Count - 1
                    dgvRunCardHeader.Columns(i).HeaderText = colColsText(i)
                    dgvRunCardHeader.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If

            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.ClickTime.ToString).Visible = False
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.FinishSize.ToString).Visible = False
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.Status.ToString).Visible = False
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.OldVersion.ToString).Visible = False
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.Shape.ToString).Width = 100
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.TypeDest.ToString).Width = 100 '描述
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Width = 50
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString).Width = 120
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.ZStatus.ToString).Width = 80
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.UserId.ToString).Width = 60
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.InTime.ToString).Width = 110
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.ModifyTime.ToString).Width = 110
            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.Remark.ToString).Width = 120
            Me.dgvRunCardHeader.Columns(RunCardBusiness.NewHeaderGrid.TotalHours.ToString).Width = 60
            Me.dgvRunCardHeader.Columns(RunCardBusiness.NewHeaderGrid.SeriesName.ToString).Width = 100
            Me.dgvRunCardHeader.Columns("StdLabors").Visible = False
            Me.dgvRunCardHeader.Columns("StdUPPH").Visible = False
            Me.dgvRunCardHeader.Columns("StdUPH").Visible = False

            'Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.FileNO.ToString).Visible = False

            Me.dgvRunCardHeader.Columns(RunCardBusiness.HeaderGrid.RCardType.ToString).Visible = False

            Me.dgvRunCardHeader.Columns(RunCardBusiness.NewHeaderGrid.DrawingFilePath.ToString).Width = 76

            'update by 马跃平 2018-07-09
            'If Not isQquery Then
            '    Me.RunCardData = dt
            '    Me.dv = New DataView(Me.RunCardData)
            'End If

            Dim clo As New DataGridViewCheckBoxColumn

            clo.HeaderText = "选择"
            clo.Width = 50
            Me.dgvRunCardHeader.Columns.Insert(0, clo)
            Me.m_ChkboxAll.Text = "选择"
            Me.dgvRunCardHeader.Controls.Add(Me.m_ChkboxAll)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "LoadRunCardHeader", "RCard")
        End Try
    End Sub

    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        Try
            'Add by cq20170518
            Me.dgvRunCardHeader.EndEdit()
            If Me.dgvRunCardHeader.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 0 To Me.dgvRunCardHeader.RowCount - 1
                Me.dgvRunCardHeader.Rows(i).Cells(0).Value = m_ChkboxAll.Checked
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "m_ChkboxAll_CheckedChanged", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvRunCardHeader_CellClick"
    Private Sub dgvRunCardHeader_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                Me.RunCardPN = CStr(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.PartId.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                Me.Version = CStr(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.DrawingVer.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())

                Me.RunCardStatus = CInt(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.Status.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)

                'If Me.dgvRunCardHeader.Rows.Count > 1 Then
                '    Me.IsQueryOldVersion = CBool(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.OldVersion.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)
                'Else
                '    'do nothing ,cq 20160523
                'End If

                '清除单元格及值
                rowSpan.Clear()
                rowValue = ""
                '显示 runcard 工站详情

                LoadRunCardBody(Me.RunCardPN, Me.Version)
                '隐藏料件面板
                Me.dgvPartNumber.Visible = False

                Me.dgvRunCardHeader.Controls.Add(Me.m_ChkboxAll)  'cq 20160321

                If Not CheckStatusNotFinish(dgvRunCardHeader.CurrentRow) Then
                    'MessageUtils.ShowInformation("非制作中状态不允许修改！")
                    For i As Integer = 1 To dgvRunCardHeader.CurrentRow.Cells.Count - 1
                        ' dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        'Modify by cq 20170329
                        If i = RunCardBusiness.NewHeaderGrid.Shape OrElse i = RunCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                    currentHeaderValue = dgvRunCardHeader.CurrentCell.FormattedValue.ToString
                    Exit Sub
                Else
                    ' dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.Shape).ReadOnly = False
                    For i As Integer = 1 To dgvRunCardHeader.CurrentRow.Cells.Count - 1
                        If i = RunCardBusiness.HeaderGrid.Shape + 1 OrElse i = RunCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                End If

                dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.Shape).ReadOnly = False 'Add by cq 20170329
                dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.StdLabors.ToString).ReadOnly = False
                currentHeaderValue = dgvRunCardHeader.CurrentCell.FormattedValue.ToString
                Me.currentRowIndex = -1  'body index  reset cq20161105
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellClick", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvRunCardHeader_CellDoubleClick"

    Private Sub dgvRunCardHeader_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellDoubleClick
        Dim o_iLength As Integer = 0
        Dim o_strPPartID As String = ""
        Try
            Dim o_strFilter As String = "", o_strFilterT As String = "", o_strFilter2 As String = ""
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                'If e.ColumnIndex = 7 Then
                '    Dim imageFile As String = dgvRunCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                '    If imageFile <> "" Then
                '        Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                '        frmDialog.Show()
                '    End If
                'End If
                Dim ColumnName = dgvRunCardHeader.Columns(e.ColumnIndex).Name

                Select Case ColumnName   '系列
                    Case "SeriesName"
                        Dim frmSeries = New FrmRunCardSeries()
                        Dim Series = dgvRunCardHeader.CurrentCell.Value
                        If IsDBNull(Series) = False And Not Series Is Nothing Then
                            frmSeries.Series = Series.ToString().Substring(0, Series.ToString().IndexOf("("))
                        End If
                        frmSeries.PartID = dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.PartId.ToString()).Value.ToString()
                        Dim dr = frmSeries.ShowDialog()
                        If dr = Windows.Forms.DialogResult.OK Then
                            LoadRunCardHeader(strWhere, True, Me.IsQueryOldVersion, False) 'cq20151026, Add flag
                            LoadSideBarByClick("desc", RunCardType.UnFinish)
                        End If
                    Case "DrawingFilePath"  '8  图纸文件
                        Dim arrPara(0) As String
                        Dim dtPLMData As DataTable
                        Dim BomQuery As New com.luxshare_ict.plm.WebService1

                        ' Dim DT As DataTable = BomQuery.GetPLMClassification(VbCommClass.VbCommClass.UseId, CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value))
                        Dim DT As DataTable = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value), "蓝图")

                        'If IsNothing(DT) Then
                        '    MessageUtils.ShowError("请检查是否有在PLM查询图纸的权限！")
                        '    Exit Sub
                        'End If

                        o_strFilter = CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value) + "%"


                        'mark by cq 20160811
                        ' o_strFilter2 = CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value) + "%"
                        If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                            arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                        Else
                            'May be is a child PN (use parent PN get the a whole set file)  'a.Substring(0, InStr(a, "-") - 1)
                            If Not IsNothing(DT) Then
                                DT.Clear()
                            End If

                            o_iLength = InStrRev(CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value), "-") - 1
                            If o_iLength > 0 Then
                                'do nothing
                            Else
                                o_iLength = CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value).Length
                            End If

                            o_strPPartID = RCardComBusiness.GetPPartID(CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(RunCardBusiness.NewHeaderGrid.PartId.ToString()).Value))

                            ' DT = BomQuery.GetPLMClassification(VbCommClass.VbCommClass.UseId, CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength))
                            DT = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, o_strPPartID, "蓝图")
                            o_strFilter = o_strPPartID + "%"   ' CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength) + "%"
                            ' o_strFilterT = CStr(Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(2).Value).Substring(0, o_iLength) + "-%"

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
                            'SetMessage(Me.lblMessage, "ECN图纸路径不存在", False)
                            MessageUtils.ShowError("图纸路径不存在！")
                        End If
                    Case Else
                        'do nothing
                End Select

                If dgvRunCardHeader.CurrentRow Is Nothing Then
                    Exit Sub
                End If

                If Not CheckStatusNotFinish(dgvRunCardHeader.CurrentRow) Then
                    'MessageUtils.ShowInformation("非制作中状态不允许修改！")
                    'dgvRunCardHeader.CurrentRow.ReadOnly = True   'dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.Shape).ReadOnly = True

                    'dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.Shape).ReadOnly = False 'Add by cq 20170329
                    For i As Integer = 0 To Me.dgvRunCardHeader.CurrentRow.Cells.Count - 1
                        If i = RunCardBusiness.NewHeaderGrid.Shape OrElse i = RunCardBusiness.NewHeaderGrid.StdLabors Then
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = False
                        Else
                            dgvRunCardHeader.CurrentRow.Cells(i).ReadOnly = True
                        End If
                    Next
                    Exit Sub
                Else
                    dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.Shape).ReadOnly = False
                    dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.StdLabors.ToString).ReadOnly = False
                    currentHeaderValue = dgvRunCardHeader.CurrentCell.FormattedValue.ToString
                End If
            End If
        Catch ex As Exception
            If ex.Message.Contains("[lx_parts]") Then
                MessageUtils.ShowError("请检查是否有在PLM查询图纸的权限！")
                Exit Sub
            End If
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellDoubleClick", "RCard")
        End Try
    End Sub

#End Region

#Region "复制单元格 header "
    Private Sub tsmiHeaderCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCopy.Click
        Dim Selected As String = String.Empty
        Try
            If Not dgvRunCardHeader.CurrentCell Is Nothing Then
                ' Selected = dgvRunCardHeader.CurrentCell.Value.ToString()
                ' Selected = CStr(IIf(IsDBNull(dgvRunCardHeader.CurrentCell.Value), "", dgvRunCardHeader.CurrentCell.Value))
                If IsDBNull(dgvRunCardHeader.CurrentCell.Value) Then
                    Selected = ""
                Else
                    Selected = CStr(dgvRunCardHeader.CurrentCell.Value)
                End If
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderCopy_Click", "RCard")
        End Try
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tmisHeaderAdd_Click", "RCard")
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
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If
            Dim frmHeader As New FrmRunCardHeaderEdit("modify", CType(Me.tsmiHeaderModify.Tag, DataGridViewRow))
            If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                'mark by cq 20170321,ADD BY cq20170830,remark by cq20170908
                'LoadRunCardHeader("")
                LoadRunCardHeader(strWhere, True, Me.IsQueryOldVersion, False) 'cq20151026, Add flag
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderModify_Click", "RCard")
        End Try
    End Sub
#End Region

    Private Sub tsmiHeaderLookLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderLookLog.Click
        Try

            Dim frmRCardLog As New FrmRCardLog()

            frmRCardLog.txtPartID.Text = Me.RunCardPN
            If frmRCardLog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'do nothing
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderModify_Click", "RCard")
        End Try

    End Sub

#Region "绑定右健菜单 header"
    Private Sub dgvRunCardHeader_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvRunCardHeader.CellContextMenuStripNeeded
        Try
            e.ContextMenuStrip = Me.ContextMenuHeader
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "MenuStripNeeded", "RCard")
        End Try
    End Sub
#End Region

#Region "鼠标右击处理 header"
    Public _runCardIDList As List(Of RCardComBusiness.stcRuncard) = New List(Of RCardComBusiness.stcRuncard)
    Private Sub dgvRunCardHeader_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRunCardHeader.CellMouseDown
        Try
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
                    Me.RunCardPN = CStr(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.PartId.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                    Me.RunCardStatus = CInt(Me.dgvRunCardHeader.Item(RunCardBusiness.HeaderGrid.Status.ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString)
                    Me.Version = CStr(Me.dgvRunCardHeader.Item((RunCardBusiness.HeaderGrid.DrawingVer).ToString, Me.dgvRunCardHeader.CurrentRow.Index).Value.ToString())
                    '清除单元格及值
                    rowSpan.Clear()
                    rowValue = ""
                    '显示 runcard 工站详情
                    LoadRunCardBody(Me.RunCardPN, Me.Version)
                Else
                    Me.tsmiHeaderModify.Tag = Nothing
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellMouseDown", "RCard")
        End Try
    End Sub
#End Region

#Region "删除"
    Private Sub tsmiHeaderDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderDelete.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            Dim isOldVersion As Boolean = False
            Dim partID As String = String.Empty
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    If Not CheckStatus(row) Then
                        MessageUtils.ShowError("料件" & row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非制作中的流程卡，不允许删除！")
                        Exit Sub
                    Else
                        isOldVersion = CBool(row.Cells(RunCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString)
                        partID = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        sql &= RunCardBusiness.DeleteHeader(isOldVersion, partID)
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
            If MessageUtils.ShowConfirm("确认要删除选中的流程卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("删除成功！")
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("", RunCardType.Finish)
                ' Me.dgvRunCardBody.DataSource = Nothing
                'Add by cq 20161102
                Dim dt As New DataTable
                dt = CType(dgvRunCardBody.DataSource, DataTable)
                If (Not IsNothing(dt)) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = dt

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderDelete_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "隐藏"
    Private Sub tsmiHeaderHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderHide.Click
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
        Dim sql As String = String.Empty
        Try
            Dim index As Integer = 0
            Dim isOldVersion As Boolean = False
            Dim partID As String = String.Empty, strVersion As String = ""
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    'If Not CheckStatus(row) Then
                    '    MessageUtils.ShowError("料件" & row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非制作中的流程卡，不允许删除！")
                    '    Exit Sub
                    'Else
                    'isOldVersion = CBool(row.Cells(RunCardBusiness.NewHeaderGrid.OldVersion.ToString).Value.ToString)

                    partID = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    strVersion = row.Cells(RunCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                    isOldVersion = RunCardBusiness.IsOldRCardVersion(partID, strVersion)
                    sql &= RunCardBusiness.GetRCardEditSQL() 'isOldVersion, partID
                    sql &= RunCardBusiness.HideHeader(False, partID, strVersion)
                    ' End If
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
            If MessageUtils.ShowConfirm("确认要隐藏选中的流程卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                If Not String.IsNullOrEmpty(sql) Then
                    Dim al As ArrayList = New ArrayList
                    al.Add("PartID|" & partID)
                    al.Add("Version|" & Me.Version)
                    al.Add("Factoryid|" & Factoryid)
                    al.Add("Profitcenter|" & Profitcenter)

                    RCardComBusiness.ExecSQL(sql, al)
                End If
                ' RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("隐藏成功！")
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("", RunCardType.Finish)
                ' Me.dgvRunCardBody.DataSource = Nothing
                'Modify by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvRunCardBody.DataSource, DataTable)

                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderHide_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "取消生效"
    Private Sub tsmiHeaderCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderCancel.Click
        Try
            Dim index As Integer = 0
            Dim sql As String = String.Empty
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    If Not CheckCancelStatus(row) Then
                        Exit Sub
                    Else
                        Dim isOldVer As Boolean = CBool(row.Cells(RunCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString)
                        Dim partID As String = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim o_strRCardVer As String = row.Cells(RunCardBusiness.NewHeaderGrid.DrawingVer.ToString).Value.ToString
                        sql &= RunCardBusiness.GetSaveRejectStatusSQL(isOldVer, partID)
                        sql &= RunCardBusiness.GetRejectStatusDeleteLogSQL(partID, o_strRCardVer)
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
            If MessageUtils.ShowConfirm("确认要取消生效选中的流程卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("取消生效成功！")
                'Mark by cq 20161201, cancle refesh the data
                ' LoadRunCardHeader("")

                For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                    If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                           row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                        row.Cells("ZStatus").Value = "制作中"
                        row.Cells("Status").Value = "0"
                    End If
                Next


                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("Desc", RunCardType.UnFinish)

                ' Me.dgvRunCardBody.DataSource = Nothing
                'Modfiy by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvRunCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderCancel_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckCancelStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetAutiStatus(CBool(row.Cells(RunCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString),
                                                                row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0)) = 2 Then
                    MessageUtils.ShowInformation(row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的流程卡还在审核中，不允许取消生效。")
                    Return False
                ElseIf CInt(dt.Rows(0)(0)) = 0 Then
                    MessageUtils.ShowInformation(row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的流程卡还在制作中，不允许取消生效。")
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckCancelStatus", "RCard")
            Return False
        End Try
    End Function

#End Region

#Region "驳回"
    Private Sub tsmiHeaderReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderReject.Click
        Try
            Dim sql As String = String.Empty
            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    If Not CheckRejectStatus(row) Then
                        Exit Sub
                    Else
                        Dim isOldVer As Boolean = CBool(row.Cells(RunCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString)
                        Dim partID As String = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        sql &= RunCardBusiness.GetSaveRejectStatusSQL(isOldVer, partID)
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
            If MessageUtils.ShowConfirm("确认要驳回" & Me.RunCardPN & "的流程卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("驳回成功！")
                LoadRunCardHeader("")
                'LoadSideBar("", Me.RunCardData)
                LoadSideBarByClick("Desc", RunCardType.UnFinish)
                ' Me.dgvRunCardBody.DataSource = Nothing
                'If Not IsNothing(Me.dgvRunCardBody) AndAlso Me.dgvRunCardBody.Rows.Count > 0 Then
                '    Me.dgvRunCardBody.Rows.Clear()
                'End If
                'Add by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvRunCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = o_dtBody
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderReject_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckRejectStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetAutiStatus(CBool(row.Cells(RunCardBusiness.HeaderGrid.OldVersion.ToString).Value.ToString),
                                                                row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0)) = 1 Then
                    MessageUtils.ShowInformation(row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的流程卡已是审核状态，不允许驳回。")
                    Return False
                ElseIf CInt(dt.Rows(0)(0)) = 0 Then '0
                    MessageUtils.ShowInformation(row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "该料件的流程卡已是审核状态，不允许驳回。")
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckRejectStatus", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "导入"
    Private Sub tsmiHeaderImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderImport.Click
        Try
            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Import", True)
            frmStation.ShowDialog()
            '刷新
            LoadRunCardHeader("")
            'LoadSideBar("", Me.RunCardData)
            LoadSideBarByClick("desc", RunCardType.UnFinish)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderImport_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "导出"

    Private Sub tsmiHeaderExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderExport.Click
        Dim o_Runcard = New RCardComBusiness.stcRuncard
        Dim strRuncardPNList As String = String.Empty
        Dim o_stcProcessRuncard As List(Of RCardComBusiness.stcRuncard) = New List(Of RCardComBusiness.stcRuncard)
        Try

            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_Runcard.RunCardPartPN = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    o_Runcard.Status = row.Cells(RunCardBusiness.HeaderGrid.Status.ToString).Value.ToString
                    o_Runcard.RCardVersion = row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next

            If _runCardIDList.Count <= 0 Then
                MessageUtils.ShowInformation("请选择流程卡")
                Exit Sub
            End If

            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion)

            For Each o_strRunCard As RCardComBusiness.stcRuncard In _runCardIDList
                If Val(o_strRunCard.Status) <> 1 Then
                    'MessageBox.Show("制作中和审核中的流程卡不允许导出!")
                    MessageUtils.ShowInformation("制作中和审核中的流程卡不允许导出！")
                    Exit Sub
                End If
                o_stcProcessRuncard.Add(o_strRunCard)
                frmStation.m_stcRuncardList.Add(o_strRunCard)
            Next

            '刷新
            frmStation.SelectPath(o_Runcard.RunCardPartPN)

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderExport_Click", "RCard")
        Finally
            If Not IsNothing(Me._runCardIDList) Then Me._runCardIDList.Clear()
        End Try
    End Sub
#End Region

    Private strWhere As String

#Region "查询"
    Private Sub tsmiHeaderSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderSearch.Click
        Try
            Dim frmQuery As New FrmRunCardQuery()
            If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.IsQueryOldVersion = frmQuery.IsQueryOldVersion
                LoadRunCardHeader(frmQuery.SqlWhere, True, frmQuery.IsQueryOldVersion, False) 'cq20151026, Add flag
                strWhere = frmQuery.SqlWhere
                Me.IsQueryOldVersion = frmQuery.IsQueryOldVersion
                'For Each dr As DataGridViewRow In Me.dgvRunCardBody.Rows
                '    dgvRunCardBody.Rows.Clear() ' = Nothing
                'Next

                'Add by cq 20161102
                Dim o_dtBody As New DataTable
                o_dtBody = CType(dgvRunCardBody.DataSource, DataTable)
                If (Not IsNothing(o_dtBody)) AndAlso o_dtBody.Rows.Count > 0 Then
                    o_dtBody.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = o_dtBody

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardQuery", "tsmiHeaderSearch_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "打印"
    Private Sub tsmiHeaderPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHeaderPrint.Click
        Dim o_Runcard As New RCardComBusiness.stcRuncard
        Dim o_strErpVer As String = String.Empty
        Try
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing _
                      AndAlso row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    o_Runcard.RunCardPartPN = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString.Trim
                    o_Runcard.Status = row.Cells(RunCardBusiness.HeaderGrid.Status.ToString).Value.ToString
                    o_Runcard.RCardVersion = row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    If _runCardIDList.IndexOf(o_Runcard) < 0 Then
                        _runCardIDList.Add(o_Runcard)
                    End If
                End If
            Next
            If _runCardIDList.Count <= 0 Then
                MessageUtils.ShowInformation("请选择流程卡！")
                Exit Sub
            End If

            For Each o_strRunCard As RCardComBusiness.stcRuncard In _runCardIDList
                If Val(o_strRunCard.Status) <> 1 Then
                    MessageUtils.ShowInformation("制作中和审核中的流程卡不允许打印！")
                    Exit Sub
                End If

                'add by cq 20160722
                'Modify bypass RD build PartID on abmi100, 20170206
                If o_Runcard.RunCardPartPN.Substring(0, 1) = "9" Then
                    o_strErpVer = RunCardBusiness.GetVerFromErp(o_Runcard.RunCardPartPN).ToUpper
                    If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso o_Runcard.RCardVersion.ToUpper().Trim <> o_strErpVer.Trim Then
                        MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,找SAP确认！",
                                                o_Runcard.RunCardPartPN, o_Runcard.RCardVersion.ToUpper, o_strErpVer.ToUpper))
                        Exit Sub
                    End If
                End If
            Next

            PrintRunCard("", _runCardIDList)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderPrint_Click", "RCard")
        Finally
            If Not IsNothing(Me._runCardIDList) Then
                Me._runCardIDList.Clear()
            End If
        End Try
    End Sub
#End Region

#Region "打印流程卡头部"

    Private Sub PrintRunCardHeader(Optional ByVal pn As String = "")
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Dim filePath As String = String.Empty

        Try
            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardHeaderTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = Environment.CurrentDirectory + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
            ' frmStation.runCardPn = Me.RunCardPn

            Using dt As DataTable = m_dtRuncardHeader  'RCardComBusiness.GetDataTable(frmStation.GetExportSql(Me.RunCardPN))
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
                    MessageUtils.ShowError("找不到对应的流程卡表头信息！")
                End If
            End Using

        Catch ex As Exception
            Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "PrintRunCardHeader", "RCard")
        Finally
            If File.Exists(o_outputFile) Then
                ' File.Delete(o_outputFile)
            End If
        End Try
    End Sub
#End Region

    'Add by CQ 20151229
    Private Sub dgvRunCardHeader_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvRunCardHeader.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.dgvRunCardHeader.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                ' p.Offset(Me.dgvRunCardHeader.Left, Me.dgvRunCardHeader.Top)
                p.Offset(CInt("0"), CInt("0")) 'Me.dgvRunCardHeader.Left, Me.dgvRunCardHeader.Top,182,25
                Me.m_ChkboxAll.Location = p
                Me.m_ChkboxAll.Size = dgvRunCardHeader.Columns(0).HeaderCell.Size 'Me.dgvRunCardHeader.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Size
                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellPainting", "RCard")
        End Try
    End Sub

#End Region

#Region "RunCardBody"

    Private dtBody As DataTable

#Region "绑定 RunCard 身体"
    Private Sub LoadRunCardBody(ByVal runCardPartId As String, Optional ByVal strVersion As String = "")
        Dim preHours As Double = 0, proHours As Double = 0, sufHours As Double = 0
        Dim trimHours As Double = 0, ProPreHours As Double = 0, autoHours As Double = 0
        'Add clear public variable value, cq 20160414
        m_preHours = 0 : m_proHours = 0 : m_ContourHours = 0 : m_trimHours = 0 : m_autoHours = 0
        Dim ds As DataSet = RunCardBusiness.GetRunCardBody(Me.IsQueryOldVersion, runCardPartId, strVersion)
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
                                    m_autoHours = autoHours  'Add by cq 20160401
                            End Select
                        Next
                    End If
                    ' 01-铆端前加工，02-产线加工，03-成型加工， 04-裁切前加工，05-生产线前加工，A05-半自动压接连接 
                    ' PartId ,StationID, StationSQ, StationName, (SectionID),WorkingHours,Equipment,ProcessStandard,NewProcessStandard,Remark,SOP,Status,UserId,InTime,(Shape)
                    dt.Rows.Add(Nothing, Nothing, Nothing, "总工时(s):" & Convert.ToDouble(preHours + proHours + sufHours + trimHours + ProPreHours + autoHours), _
                                Nothing, "铆端前加工(s): " & preHours.ToString, "产线(s): " & proHours.ToString, _
                               "成型(s): " & sufHours.ToString, Nothing, _
                               "裁切前(s):" & trimHours.ToString, Nothing, Nothing, "生产线前(s):" & ProPreHours.ToString, "半自动压接(s):" & autoHours.ToString)
                    dgvRunCardBody.DataSource = dt
                    'Dim cmd = New CmbDatagridbiew(dgvRunCardBody)
                    'cmd.Add(dgvRunCardBody.Rows.Count - 1, 12, dgvRunCardBody.Rows.Count - 1, 13)
                    '禁止排序
                    For Each column As DataGridViewColumn In dgvRunCardBody.Columns
                        column.SortMode = DataGridViewColumnSortMode.NotSortable
                    Next

                    If dt.Rows.Count > 0 AndAlso dgvRunCardBody.Rows.Count > 0 Then
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(5).Style.BackColor = Color.LightGreen '铆端前加工
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(6).Style.BackColor = Color.Aqua '产线
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(7).Style.BackColor = Color.PeachPuff '成型
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(9).Style.BackColor = Color.WhiteSmoke '裁切前
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(10).Style.BackColor = Color.MistyRose '生产线前
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(12).Style.BackColor = Color.Tomato '半自动
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).Cells(13).Style.BackColor = Color.Tomato '半自动
                    End If

                    If Me.RunCardStatus = 1 Or Me.RunCardStatus = 2 Then
                        dgvRunCardBody.ReadOnly = True
                    End If
                    ' "Add for auto update"
                    If Me.RunCardStatus = 0 Then
                        ' dgvRunCardBody.ReadOnly = False 'mark by cq 20161215
                    Else
                        dgvRunCardBody.ReadOnly = True
                        'mark by cq 20161102
                        ' Me.dgvRunCardBody.Controls.Clear()
                    End If

                    'Add if by cq 20161102
                    If dt.Rows.Count >= 1 AndAlso dgvRunCardBody.Rows.Count > 0 Then
                        dgvRunCardBody.Rows(dt.Rows.Count - 1).ReadOnly = True
                    End If

                    dtBody = dt.Clone

                    'cq add judge 20160701 
                    If dgvRunCardBody.Columns.Count > 2 Then
                        dgvRunCardBody.Columns(2).Width = 30 '2.StationSQ
                    End If
                    If dgvRunCardBody.Columns.Count > 3 Then
                        dgvRunCardBody.Columns(3).Width = 130 '3.StationName
                    End If

                    If dgvRunCardBody.Columns.Count > 5 Then
                        dgvRunCardBody.Columns(5).Width = 110 '5.WorkingHours
                    End If

                    If dgvRunCardBody.Columns.Count > 6 Then
                        dgvRunCardBody.Columns(6).Width = 120 '6.Equipment
                    End If
                    If dgvRunCardBody.Columns.Count > 7 Then
                        dgvRunCardBody.Columns(7).Width = 424 '7.ProcessStandard
                    End If

                    If dgvRunCardBody.Columns.Count > 10 Then
                        dgvRunCardBody.Columns(10).Width = 50 '10.SOP
                    End If

                    If dgvRunCardBody.Columns.Count > 12 Then
                        dgvRunCardBody.Columns("UserId").Width = 70 '12.UserId
                    End If
                    If dgvRunCardBody.Columns.Count > 13 Then
                        dgvRunCardBody.Columns("InTime").Width = 115 '13.InTime
                    End If

                    dgvRunCardBody.Columns("Remark").Width = 212

                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.StationSQ.ToString).Width = 30 '2.StationSQ
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.StationName.ToString).Width = 130 '3.StationName
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.WorkingHours.ToString).Width = 110 '5.WorkingHours
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.Equipment.ToString).Width = 120 '6.Equipment
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Width = 170 '7.ProcessStandard
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.UserId.ToString).Width = 60 '12.UserId
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.SOP.ToString).Width = 50 '10.SOP
                    'dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.InTime.ToString).Width = 110 '13.InTime
                Else
                    dgvRunCardBody.DataSource = dt
                    dtBody = dt.Clone
                End If

                If dgvRunCardBody.Columns.Count > 7 Then
                    dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.ProcessStandard.ToString).CellTemplate.Style.WrapMode = DataGridViewTriState.True
                End If
            Else
                '  dgvRunCardBody.DataSource = IIf(dtBody Is Nothing, Nothing, dtBody)
                If dtBody Is Nothing Then
                    'cq 20161102
                    Dim o_dt As New DataTable
                    o_dt = CType(dgvRunCardBody.DataSource, DataTable)
                    'Add if cq 20161108
                    If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                        o_dt.Rows.Clear()
                    End If
                    dgvRunCardBody.DataSource = o_dt
                Else
                    dgvRunCardBody.DataSource = dtBody
                End If
            End If
        Catch ex As Exception
            'add by cq 20160628
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "LoadRunCardBody", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvRunCardBody_CellClick"
    Private Sub dgvRunCardBody_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                '最后一行是汇总行
                If e.RowIndex <> dgvRunCardBody.Rows.Count - 1 Then
                    Dim CardPN As String = CStr(Me.dgvRunCardBody.Item(RunCardBusiness.BodyGrid.PartId.ToString, Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    Me.RunCardStationId = CStr(Me.dgvRunCardBody.Item(RunCardBusiness.BodyGrid.StationID.ToString, Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                    MyStationName = Me.dgvRunCardBody.Rows(e.RowIndex).Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString()
                    If Not IsNothing(Me.dgvRunCardHeader.CurrentRow) Then
                        Me.Version = Me.dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString()
                    Else
                        Me.Version = Me.dgvRunCardHeader.Rows(e.RowIndex).Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString()
                    End If
                    If dgvRunCardBody.Columns(e.ColumnIndex).Name <> "ProcessStandard" Then
                        dgvRunCardBody.Columns("ProcessStandard").Width = 250
                    End If

                    If dgvRunCardBody.Columns(e.ColumnIndex).Name <> "Remark" Then
                        dgvRunCardBody.Columns("Remark").Width = 135
                    End If

                    '加载料件信息
                    Me.LoadPartGrid(CardPN, Me.RunCardStationId, Me.Version)
                    '显示料件面板
                    Me.dgvPartNumber.Visible = True
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellClick", "RCard")
        End Try
    End Sub
#End Region

#Region "dgvRunCardBody_CellDoubleClick"
    Private Sub dgvRunCardBody_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellDoubleClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If e.ColumnIndex = RunCardBusiness.BodyGrid.SOP Then
                    Dim imageFile As String = dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim
                    If imageFile <> "" Then
                        Dim frmDialog As New FrmRunCardShowPicture(imageFile)
                        frmDialog.Show()
                    End If
                Else
                    If editRight Then
                        If Me.RunCardStatus = 0 AndAlso e.RowIndex <> Me.dgvRunCardBody.RowCount - 1 Then
                            dgvRunCardBody.ReadOnly = False
                            'Me.dgvRunCardBody.EditMode = DataGridViewEditMode.EditOnEnter 'Mark by cq 20161216
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.StationSQ.ToString).ReadOnly = True
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.UserId.ToString).ReadOnly = True '修改人
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.InTime.ToString).ReadOnly = True '修改时间
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.StationName.ToString).ReadOnly = True '工站名称
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.SOP.ToString).ReadOnly = True 'SOP
                            dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.ProcessStandard.ToString).ReadOnly = False '工艺标准
                            'add by cq 20180622
                            If Me.btnModifyTime.Enabled = False Then
                                dgvRunCardBody.Columns(RunCardBusiness.BodyGrid.WorkingHours.ToString).ReadOnly = True
                            End If
                            currentRowIndex = e.RowIndex
                            currentColumnIndex = e.ColumnIndex
                            currentColumnName = dgvRunCardBody.CurrentCell.OwningColumn.Name
                            currentBodyValue = dgvRunCardBody.CurrentCell.FormattedValue.ToString
                            'If dgvRunCardBody.CurrentCell.OwningColumn.Name = RunCardBusiness.BodyGrid.StationName.ToString Or
                            '   dgvRunCardBody.CurrentCell.OwningColumn.Name = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then
                            '    AddButton(currentColumnIndex, currentRowIndex)
                            'End If
                            If dgvRunCardBody.CurrentCell.OwningColumn.Name = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then
                                AddButton(currentColumnIndex, currentRowIndex)
                            End If
                        End If
                    End If
                End If
                dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).ReadOnly = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellDoubleClick", "RCard")
        End Try
    End Sub
#End Region

#Region "复制单元格 body"
    Private Sub tsmiBodyCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyCopy.Click
        Dim Selected As String = String.Empty
        Try
            If Not dgvRunCardBody.CurrentCell Is Nothing Then
                If IsDBNull(dgvRunCardBody.CurrentCell.Value) Then
                    Selected = ""
                Else
                    Selected = CStr(dgvRunCardBody.CurrentCell.Value)
                End If
                Clipboard.SetDataObject(Selected)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellDoubleClick", "RCard")
        End Try
    End Sub
#End Region

#Region "新增 body"
    Private Sub tsmiBodyAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyAdd.Click
        Dim o_strVersion As String = ""
        Try
            If Me.RunCardPN = String.Empty Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许新增 O_O")
                Exit Sub
            End If

            If (Not IsNothing(Me.dgvRunCardHeader.CurrentRow)) Then
                o_strVersion = Me.dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString()).Value.ToString
            Else
                o_strVersion = Me.Version
            End If

            Dim frmEdit As New FrmRunCardBodyEdit(Me.RunCardPN, "add", Nothing, Me, o_strVersion, Me.IsQueryOldVersion)
            frmEdit.RCardType = dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.RCardType.ToString()).Value.ToString()
            frmEdit.ShowDialog()
            '刷新
            LoadRunCardBody(Me.RunCardPN)
            If Me.RunCardStatus = 1 Then
                Me.RunCardStatus = 0
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
            If dgvRunCardBody.Rows.Count <> 0 Then
                dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - CInt(IIf(dgvRunCardBody.Rows.Count > 10, 10, 1))
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiBodyAdd_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "插入 body"

    Private Sub tsmiBodyInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyInsert.Click
        Dim i_MaxStationSQ As Integer = -1
        Try
            If IsNothing(Me.dgvRunCardBody.CurrentRow) Then Exit Sub

            If Me.RunCardPN = String.Empty Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许插入 O_O")
                Exit Sub
            End If

            If IsDBNull(Me.dgvRunCardBody.CurrentRow.Cells(0).Value) OrElse String.IsNullOrEmpty(CStr(Me.dgvRunCardBody.CurrentRow.Cells(0).Value)) Then
                i_MaxStationSQ = CInt(Me.dgvRunCardBody.Rows(Me.dgvRunCardBody.CurrentRow.Index - 1).Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value) + 1
            End If

            Dim frmEdit As New FrmRunCardBodyEdit(Me.RunCardPN, "insert", Me.dgvRunCardBody.CurrentRow, Me, Me.Version, Me.IsQueryOldVersion, i_MaxStationSQ)

            'add by 马跃平 2018-08-07
            frmEdit.RCardType = dgvRunCardHeader.CurrentRow.Cells("RCardType").Value.ToString()

            frmEdit.ShowDialog()
            '刷新
            LoadRunCardBody(Me.RunCardPN)
            If Me.RunCardStatus = 1 Then
                Me.RunCardStatus = 0
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
            If dgvRunCardBody.Rows.Count <> 0 Then
                dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - CInt(IIf(dgvRunCardBody.Rows.Count > 10, 10, 1))
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiBodyInsert_Click", "RCard")
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
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If

            Dim frmDialog As New FrmRunCardBodyEdit(Me.RunCardPN, "modify", CType(Me.tsmiBodyModify.Tag, DataGridViewRow), Me.IsQueryOldVersion)
            frmDialog.stationSeq = dgvRunCardBody.CurrentRow.Cells("StationSQ").Value.ToString()
            frmDialog.RCardType = dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.RCardType.ToString()).Value.ToString()

            If Me.btnModifyTime.Enabled = False Then
                frmDialog.m_blnAllowModifyWorkHour = False
            Else
                frmDialog.m_blnAllowModifyWorkHour = True
            End If

            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                'LoadRunCardHeader("") 何建邦提出需求 修改工站,工站修改时，单头 能不能不要刷新顺序 2018-04-23
                LoadRunCardBody(Me.RunCardPN)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiBodyModify_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "删除 body"
    Private Sub tsmiBodyDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyDelete.Click
        Try
            If Me.tsmiBodyDelete.Tag Is Nothing Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            Dim row As DataGridViewRow = CType(Me.tsmiBodyDelete.Tag, DataGridViewRow)
            Dim stationNo As String = row.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
            Dim stationName As String = row.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString
            '审核中：不可删除
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许删除 O_O")
                Exit Sub
            End If
            Dim StationSQ = dgvRunCardBody.CurrentRow.Cells("StationSQ").Value

            If MessageUtils.ShowConfirm("确认删除所选工站:""" & stationNo & "-" & stationName & """ ?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                RunCardBusiness.DeleteBody(Me.IsQueryOldVersion, Me.RunCardPN, Me.RunCardStationId, StationSQ.ToString())

                '刷新
                LoadRunCardBody(Me.RunCardPN)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiBodyDelete_Click", "RCard")
        End Try
    End Sub
#End Region


    Private Sub tsmiBodyStationLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyStationLog.Click
        Try

            Dim frmRCardLog As New FrmRCardLog()

            frmRCardLog.txtPartID.Text = Me.RunCardPN
            frmRCardLog.txtStationID.Text = Me._runCardStationId
            If frmRCardLog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'do nothing
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiHeaderModify_Click", "RCard")
        End Try
    End Sub

#Region "重置"
    Private Sub RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RToolStripMenuItem.Click
        Try
            If Me.RToolStripMenuItem.Tag Is Nothing Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If
            '审核状态不可修改
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If
            Dim frmDialog As New FrmRunCardBodyEdit(Me.RunCardPN, "reset", CType(Me.RToolStripMenuItem.Tag, DataGridViewRow), Me, Me.Version, Me.IsQueryOldVersion)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardBody(Me.RunCardPN)
                If Me.RunCardStatus = 1 Then
                    Me.RunCardStatus = 0
                    LoadRunCardHeader("")
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "RToolStripMenuItem_Click", "RCard")
        End Try
    End Sub
#End Region

#Region "确认body"
    Private Sub tsmiBodyConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiBodyConfirm.Click
        Dim strTempPartId As String = String.Empty
        Dim sql As String = String.Empty
        Dim strTempStationNameList As String = String.Empty
        Dim strErpVer As String = String.Empty
        Try
            If Me.dgvRunCardBody.Rows.Count <= 0 Then
                MessageUtils.ShowInformation("请选择！")
                Exit Sub
            End If

            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then

                    strTempPartId = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    'Add by cq 20160920
                    If strTempPartId.Substring(0, 1) = "9" Then
                        'Modify by cq20170206, add pass the abmi100 RD build partid
                        strErpVer = RunCardBusiness.GetVerFromErp(strTempPartId).ToUpper
                        If (Not String.IsNullOrEmpty(strErpVer)) AndAlso row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString.ToUpper.Trim <> strErpVer.Trim Then
                            MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,找SAP确认！",
                                                        strTempPartId, row.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString.ToUpper.Trim,
                                                        strErpVer.ToUpper))
                            Exit For
                        End If
                    Else
                        'bypass check
                    End If

                    If RunCardBusiness.CheckIsPartLoss(strTempPartId, strTempStationNameList) Then
                        If MessageUtils.ShowConfirm("" & strTempStationNameList & " 这些工站没有维护料件的信息,仍然要确定吗? ", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            'bypass check
                        Else
                            Exit Sub
                        End If
                    End If

                    If Not CheckStatus(row) Then
                        MessageUtils.ShowInformation("非制作中状态不允许确认！")
                    Else
                        strTempPartId = row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        sql &= RunCardBusiness.GetBodyConfirmSQL(Me.IsQueryOldVersion, strTempPartId)
                    End If
                End If
                index += 1
                If index = 200 Then
                    Exit For
                End If
            Next
            If String.IsNullOrEmpty(sql) Then
                'mark by cq 20160725
                ' MessageUtils.ShowInformation("无选中项！")
                Exit Sub
            End If

            If MessageUtils.ShowConfirm("确定要确认选中的流程卡信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RCardComBusiness.ExecSQL(sql)
                'mark by cq 20160729
                ' LoadRunCardHeader("")
                ' LoadRunCardBody(Me.RunCardId)
                '刷新
                LoadSideBarByClick("desc", RunCardType.Audit)
                '展开
                'SideBar1.ExpandedPanel = sbPanelAudit
                '提示
                MessageUtils.ShowInformation("料件:" & Me.RunCardPN & "确认成功！")

                For Each row As DataGridViewRow In dgvRunCardHeader.Rows
                    If Not row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                           row.Cells(RunCardBusiness.HeaderGrid.CheckBox).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                        row.Cells("ZStatus").Value = "待审核"
                        row.Cells("Status").Value = "2"
                    End If
                Next
                ' Me.dgvRunCardBody.DataSource = Nothing
                'cq 20161102
                Dim dt As New DataTable
                dt = CType(dgvRunCardBody.DataSource, DataTable)
                'cq 20161108
                If (Not IsNothing(dt)) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.Clear()
                End If
                dgvRunCardBody.DataSource = dt
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiBodyConfirm_Click", "RCard")
        End Try
    End Sub

    Private Function CheckStatus(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetAutiStatus(Me.IsQueryOldVersion, row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                '??制作中状态
                If CInt(dt.Rows(0)(0).ToString) = 0 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckStatus", "RCard")
            Return False
        End Try
    End Function

    Private Function CheckRCardStatus(ByVal strPartID As String) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetAutiStatus(Me.IsQueryOldVersion, strPartID)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0).ToString) = 0 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckRCardStatus", "RCard")
            Return False
        End Try
    End Function

    Private Function CheckStatusNotFinish(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetAutiStatus(Me.IsQueryOldVersion, row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString)

            If dt.Rows.Count > 0 Then
                If CInt(dt.Rows(0)(0).ToString) = 0 OrElse CInt(dt.Rows(0)(0).ToString) = 2 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CheckStatusNotFinish", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "复制工站"
    Private Sub ToolCopyBodyStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCopyBodyStation.Click

        Try
            'If ToolCopyBodyStation.Tag Is Nothing Then
            '    MessageBox.Show("请选择其中一个工站O_O")
            '    Exit Sub
            'End If
            If Me.RunCardStatus = 2 Or Me.RunCardStatus = 1 Then
                MessageUtils.ShowError("料件:""" & Me.RunCardPN & """ 待审核或是已生效状态,不允许修改！")
                Exit Sub
            End If

            Dim frmStationCopy As New FrmRunCardStationCopy(Me.RunCardPN, Me.RunCardStationId, "copy", CType(Me.RToolStripMenuItem.Tag, DataGridViewRow), Me.IsQueryOldVersion)

            If frmStationCopy.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '刷新
                LoadRunCardBody(Me.RunCardPN)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "ToolCopyBodyStation_Click", "RCard")
        End Try
    End Sub
#End Region

    'mark by cq 20161216
#Region "绑定右健菜单"
    Private Sub dgvRunCardBody_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvRunCardBody.CellContextMenuStripNeeded
        Try
            e.ContextMenuStrip = Me.ContextMenuBody
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "CellContextMenuStripNeeded", "RCard")
        End Try
    End Sub
#End Region

#Region "鼠标右击处理 body"
    Private Sub dgvRunCardBody_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRunCardBody.CellMouseDown
        Try
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
                        Me.RunCardStationId = CStr(Me.dgvRunCardBody.Item(RunCardBusiness.BodyGrid.StationID.ToString, Me.dgvRunCardBody.CurrentRow.Index).Value.ToString)
                        '加载料件信息
                        Me.LoadPartGrid(Me.RunCardPN, Me.RunCardStationId)
                        '显示料件面板
                        Me.dgvPartNumber.Visible = True
                    End If
                Else
                    Me.tsmiBodyModify.Tag = Nothing
                    Me.tsmiBodyDelete.Tag = Nothing
                    Me.RToolStripMenuItem.Tag = Nothing
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellMouseDown", "RCard")
        End Try
    End Sub
#End Region

#Region "字体颜色处理 body"
    Private Sub dgvRunCardBody_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvRunCardBody.DataBindingComplete
        Dim tempSectionID As String = ""
        Try
            For Each item As DataGridViewRow In dgvRunCardBody.Rows
                If IsDBNull(item.Cells(RunCardBusiness.BodyGrid.SectionID.ToString).Value) Then
                    tempSectionID = ""
                Else
                    tempSectionID = CStr(item.Cells(RunCardBusiness.BodyGrid.SectionID.ToString).Value)
                End If

                Select Case tempSectionID
                    Case "1", "01" '前段加工
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.LightGreen
                    Case "2", "02" '产线加工
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Aqua
                    Case "3", "03" '成型加工
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.PeachPuff
                    Case "4", "04"
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.WhiteSmoke
                    Case "5", "05"
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.MistyRose
                    Case "A05"
                        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Tomato
                    Case Else
                        'do nothing
                End Select

                'add by cq 20180622
                If Me.btnModifyTime.Enabled = False Then
                    item.Cells("WorkingHours").ReadOnly = True
                End If

            Next


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_DataBindingComplete", "RCard")
        End Try
    End Sub
#End Region

#Region "AutoUpdate"

    Private btn As Button = New Button()
    Private currentRowIndex As Integer = -1  '0, modify by cq 20161108
    ' Private currentRowIndex As Integer = -1  '0, modify by cq 20161108
    Private currentColumnIndex As Integer = 0
    Private currentColumnName As String = ""
    Private currentLeft As Integer = 0
    Private currentTop As Integer = 0
    ' Private currentValue As String = ""
    Private currentHeaderValue As String = ""
    Private currentBodyValue As String = ""
    Private currentOldWorkHour As String = ""
    Private isClose As Boolean = False
    Private ft As New System.Drawing.Font("Arial", 7)
    Private reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,4})(\.\d{0,1}[1-9])?$")
    'Private updateSql As String = ""

    Private Sub dgvRunCardBody_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellEnter
        Try
            If e.RowIndex < dgvRunCardBody.Rows.Count - 1 AndAlso Me.dgvRunCardBody.ReadOnly = False Then
                currentRowIndex = e.RowIndex

                'Add by cq 20161103
                If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then 'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                    Exit Sub
                End If
                currentColumnIndex = e.ColumnIndex
                currentColumnName = dgvRunCardBody.CurrentCell.OwningColumn.Name
                currentBodyValue = dgvRunCardBody.CurrentCell.FormattedValue.ToString
                currentOldWorkHour = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours).FormattedValue.ToString
                'If currentColumnName = RunCardBusiness.BodyGrid.StationName.ToString Or currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then '工站名称/工艺标准
                '    AddButton(currentColumnIndex, currentRowIndex)
                'End If
                'Modify by CQ 20151030,工站名称/工艺标准 ==> 工艺标准
                If currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then '工艺标准
                    AddButton(currentColumnIndex, currentRowIndex)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellEnter", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    Private Sub dgvRunCardBody_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRunCardBody.CellLeave

        Try
            'Add by cq 20161103, eg: 共1行, 但是currentRowIndex =3 ,报错. 当rowcount = 1, index 只能用到0
            If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then
                Exit Sub
            End If

            Me.dgvRunCardBody.Controls.Clear()
            If dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString <> currentBodyValue Then
                'cq 20161031，Rows(currentRowIndex)==》CurrentRow 20180111
                Dim runCardId As String = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.PartId.ToString).Value.ToString



                If String.IsNullOrEmpty(runCardId) Then Exit Sub

                If Me.CheckRCardStatus(runCardId) Then
                    UpdateData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellLeave", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgvRunCardBody_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvRunCardBody.ColumnWidthChanged
        Try
            'Add by cq 20161103
            If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            btn.Width = CInt(Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Width / 5)
            btn.Location = New System.Drawing.Point(CInt(IIf((Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width) < 0, 0, Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width)), Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y)
            If currentRowIndex = 0 Then
                currentLeft = btn.Left
                currentTop = btn.Top
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_ColumnWidthChanged", "RCard")
        End Try
    End Sub

    Private Sub dgvRunCardBody_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvRunCardBody.Scroll
        Try
            'Add by cq 20161103
            If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            btn.Left = Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Right - btn.Width
            btn.Top = Me.dgvRunCardBody.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, True).Y
            If currentRowIndex = 0 AndAlso e.ScrollOrientation = ScrollOrientation.VerticalScroll AndAlso e.NewValue = 0 Then
                btn.Left = currentLeft
                btn.Top = currentTop
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_Scroll", "RCard")
        End Try
    End Sub

    Private Sub btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim frmModify As FrmRunCardBodyModify = Nothing
            'Add by cq 20161103，Modify by cq20161105
            If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                Exit Sub
            End If
            If currentColumnName = RunCardBusiness.BodyGrid.StationName.ToString Then '工站名称
                'dgvRunCardBody.Rows(currentRowIndex) ==》 dgvRunCardBody.CurrentRow 20171229
                frmModify = New FrmRunCardBodyModify(Me.RunCardPN, FrmRunCardBodyModify.ActionType.ModifyStation, dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
            ElseIf currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then '工艺标准
                frmModify = New FrmRunCardBodyModify(Me.RunCardPN, FrmRunCardBodyModify.ActionType.ModifyProcessParameter, dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
            End If
            If Not frmModify Is Nothing Then
                If frmModify.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If currentColumnName = RunCardBusiness.BodyGrid.StationName.ToString Then
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value = frmModify.outputStationName
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value = frmModify.outputStationId
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Value = ""
                    Else
                        'Modify by cq 20170307  dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Value==> ''
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Value =
                            IIf(String.IsNullOrEmpty(frmModify.outputProcessStand),
                                "", frmModify.outputProcessStand)

                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseName
                        dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now

                        If Val(dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.WorkingHours).Value) <> frmModify.m_iTotalStdTime AndAlso (frmModify.m_iTotalStdTime > 0) Then
                            Call UpdateStdTime(frmModify.m_iTotalStdTime.ToString)
                            dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.WorkingHours).Value = frmModify.m_iTotalStdTime
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btn_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgvRunCardBody_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dgvRunCardBody.CellBeginEdit
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            ' 是否可以进行编辑的条件检查
            If dgvRunCardBody.CurrentCell.OwningColumn.Name = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then
                'currentDataRow = dgv.CurrentRow

                'Add by cq 20161103
                If IsNothing(dgv.CurrentRow) Then
                    Exit Sub
                End If

                Dim stationID As String = dgv.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString()
                If RunCardBusiness.CheckStationMaintainCheckItem(stationID) Then
                    e.Cancel = True
                End If

                ''输入0－9和回连键时有效  
                'If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
                '    e.Handled = False
                'End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardBody_CellBeginEdit", "RCard")
        End Try
    End Sub

    Private Sub dgvPartNumber_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPartNumber.MouseDown
        Me.dgvRunCardBody.ReadOnly = True
    End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    Try
    '        'Select Case keyData
    '        '    Case Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.Enter, Keys.Tab, Keys.Home, Keys.PageDown, Keys.PageUp, Keys.End
    '        '        If dgvRunCardBody.IsCurrentCellInEditMode Then
    '        '            If currentColumnName = RunCardBusiness.BodyGrid.WorkingHours.ToString Then
    '        '                dgvRunCardBody.EndEdit()
    '        '                If Not reg.IsMatch(Me.dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Value.ToString) Then
    '        '                    dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString)
    '        '                    dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
    '        '                    dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
    '        '                    MessageUtils.ShowError("工时必须是数字，请确认！")
    '        '                    Return True
    '        '                End If
    '        '            End If
    '        '        End If
    '        '    Case Else
    '        '        Return False
    '        'End Select
    '        'Select Case keyData
    '        '    Case Keys.Enter
    '        '        SendKeys.Send("{Tab}")
    '        '        '返回True代表已处理。
    '        '        Return True
    '        'End Select
    '    Catch ex As Exception
    '        MessageUtils.ShowError(ex.Message)
    '    End Try
    '    Return True
    'End Function
#End Region

#End Region

#Region "RunCardPart"

#Region "绑定 RunCard 料件"
    Private Sub LoadPartGrid(runCardPartId As String, stationID As String, Optional ByVal strVersion As String = "")
        Try
            Dim dt As DataTable = RunCardBusiness.GetRunCardPart(Me.IsQueryOldVersion, runCardPartId, stationID, strVersion)
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "LoadPartGrid", "RCard")
        End Try
    End Sub
#End Region


#Region "增加料件信息"
    Private Sub menuAddPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiPartAdd.Click
        Try
            '审核中：不可修改
            If Me.RunCardStatus = 2 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 待审核状态,不允许修改！")
                Exit Sub
            End If

            '已完成：不可修改, cq 20160329
            If Me.RunCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 已完成状态,不允许修改！")
                Exit Sub
            End If
            '检查BOM是否需要更新
            If NeedUpdateBom() Then
                MessageUtils.ShowInformation("料件""" & Me.RunCardPN & """BOM中的部分物料已失效，请及时更新BOM！")
            End If
            Dim frmDialog As New FrmRunCardPartDetail(Me.RunCardPN, Me.RunCardStationId, Me.Version, Me.IsQueryOldVersion, MyStationName)
            If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ''刷新
                LoadPartGrid(Me.RunCardPN, Me.RunCardStationId)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "menuAddPart_Click", "RCard")
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

            '已完成：不可修改, cq 20160329
            If Me.RunCardStatus = 1 Then
                MessageUtils.ShowInformation("料件:""" & Me.RunCardPN & """ 已完成状态,不允许删除！")
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvPartNumber.Rows
                If Not row.Cells(0).EditedFormattedValue Is Nothing AndAlso
                       row.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    'If Not CheckStatus(row) Then
                    '    MessageUtils.ShowError("料件" & row.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString & "非制作中的流程卡，不允许删除！")
                    '    Exit Sub
                    'Else
                    partID = row.Cells(1).Value.ToString
                    sql &= RunCardBusiness.DeleteDPartID(Me.IsQueryOldVersion, Me.RunCardPN, partID, Me.RunCardStationId)
                    'End If
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
            ' If MessageUtils.ShowConfirm("确认要删除选中的料件信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            'add by 马跃平 2018-05-14
            Dim dt As DataTable = RCardComBusiness.GetDataTable("select * from m_RCardDPart_t" & vbCrLf &
            "where PartID='" & Me.RunCardPN & "' and Stationid='" & Me.RunCardStationId & "'" & vbCrLf &
            "and EWPartNumber='" & partID & "'")

            '删除之前的料号list
            Dim oldPartList As String = RCardComBusiness.getPartNumList(Me.RunCardPN, Me.RunCardStationId)
            RCardComBusiness.ExecSQL(sql)

            '删除之后的料号list
            Dim NewPartList As String = RCardComBusiness.getPartNumList(Me.RunCardPN, Me.RunCardStationId)

            Dim OldUserID As String = dt.Rows(0)("UserID").ToString
            Dim OldMofifyTime As String = Convert.ToDateTime(dt.Rows(0)("InTime")).ToString("yyyy-MM-dd HH:mm:ss")

            Dim StrSql As String = " insert into m_RCardChangeLog_t" & vbCrLf &
                          "(PartID,StationID,TYPE,OldUserID,OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & vbCrLf &
" values ('" & Me.RunCardPN & "','" & Me.RunCardStationId & "',N'物料','" & OldUserID & "'" & vbCrLf &
",'" & OldMofifyTime & "','" & oldPartList & "','" & SysMessageClass.UseId & "',getdate(),'" & NewPartList & "')"
            RCardComBusiness.ExecSQL(StrSql)
            ' MessageUtils.ShowInformation("删除成功！")
            ''刷新
            LoadPartGrid(Me.RunCardPN, Me.RunCardStationId)
            ' End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "tsmiPartDelete_Click", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#End Region

    'Add by CQ 20151023
    Private Sub dgvRunCardHeader_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellLeave
        Dim strAllowEditColList As String = "Shape,StdLabors"
        Try
            Me.dgvRunCardHeader.Controls.Clear()

            'Add by cq 20161103
            If IsNothing(dgvRunCardHeader.CurrentRow) Then
                Exit Sub
            End If

            'If dgvRunCardHeader.CurrentCell.OwningColumn.Name <> RunCardBusiness.HeaderGrid.Shape.ToString  Then
            If ("," & strAllowEditColList & ",").IndexOf(dgvRunCardHeader.CurrentCell.OwningColumn.Name) < 0 Then
                Exit Sub
            End If

            'Add by cq 20170729
            If IsNothing(dgvRunCardHeader.CurrentCell) Then
                Exit Sub
            End If

            If dgvRunCardHeader.CurrentCell.EditedFormattedValue.ToString <> currentHeaderValue Then
                If Not Me.tsmiBodyModify.Enabled = True Then
                    Exit Sub
                    '  MessageUtils.ShowWarning("你没有权限修改！")
                End If
                'cq 20160708，remove the check, allow user all staus can modify 20170329
                'If Not CheckStatusNotFinish(dgvRunCardHeader.CurrentRow) Then
                '    'MessageUtils.ShowInformation("非制作中状态不允许修改！")
                '    ' dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.Shape).ReadOnly = True
                '    Exit Sub
                'Else
                '    UpdateHeaderData(dgvRunCardHeader.CurrentCell.OwningColumn.Name)
                'End If
                'add by cq 20170922
                If dgvRunCardHeader.CurrentCell.OwningColumn.Name.ToUpper = "STDLABORS" Then
                    With dgvRunCardHeader.CurrentCell
                        If Val(.EditedFormattedValue.ToString) <= 0 AndAlso (Not String.IsNullOrEmpty(.EditedFormattedValue.ToString)) Then
                            Exit Sub
                        End If
                    End With
                End If

                UpdateHeaderData(dgvRunCardHeader.CurrentCell.OwningColumn.Name)
            End If
            ' End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_CellLeave", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub UpdateHeaderData(ByVal parcurrentColumnName As String)
        Dim strSQL As String = ""
        Dim o_strExecutSQLResult As String = ""
        Try
            If dgvRunCardHeader.RowCount > 0 Then
                If dgvRunCardHeader.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvRunCardHeader.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvRunCardHeader.CurrentCell.EditedFormattedValue.ToString <> currentHeaderValue Then
                        'Add by cq 20161103
                        If IsNothing(dgvRunCardHeader.CurrentRow) Then
                            Exit Sub
                        End If
                        Dim runCardId As String = dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                        Dim editValue As String = dgvRunCardHeader.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

                        strSQL = RunCardBusiness.GetHeaderUpdateSQL(Me.IsQueryOldVersion, parcurrentColumnName, editValue, runCardId)

                        If Not String.IsNullOrEmpty(strSQL) Then
                            o_strExecutSQLResult = RCardComBusiness.ExecSQL(strSQL)
                            If o_strExecutSQLResult <> "" Then
                                MessageUtils.ShowError(o_strExecutSQLResult)
                                Exit Sub
                            End If
                            ' dgvRunCardHeader.Rows(currentRowIndex).Cells(RunCardBusiness.HeaderGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                            dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.HeaderGrid.ModifyTime.ToString).Value = Date.Now
                            If parcurrentColumnName.ToUpper = "STDLABORS" Then
                                dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.StdUPH.ToString).Value = Math.Round(Val(dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.StdUPPH.ToString).Value.ToString) * Val(editValue), 1)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "UpdateHeaderData", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub btnExportHeader_Click(sender As Object, e As EventArgs) Handles btnExportHeader.Click
        Try
            Dim strPath As String = ""
            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion)
            frmStation.SelectExportPath("RunCard", strPath)

            Call DoExport(strPath)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "btnExportHeader_Click", "RCard")
        End Try
    End Sub

    Private Sub DoExport(ByVal strPath As String)
        Dim o_outputFile As String = ""
        Dim errorMsg As String = Nothing
        Dim filePath As String = ""
        Try

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardHeaderTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = strPath + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
            ' frmStation.runCardPn = Me.RunCardPn

            ''Using dt As DataTable = m_dtRuncardHeader  'RCardComBusiness.GetDataTable(frmStation.GetExportSql(Me.RunCardPN))

            'add by 马跃平 2018-07-09
            Using dt As DataTable = RunCardBusiness.GetRunCardHeaderExport(Me.IsQueryOldVersion, Me.strWhere, "")

                '有导出单头工时权限就打印工时 add by 马跃平 2018-05-30
                If DbOperateUtils.GetDataTable(" select * from dbo.m_UserRight_t " & vbCrLf &
                              " where UserID='" & MainFrame.SysCheckData.SysMessageClass.UseId & "' and Tkey='RCard2_22'").Rows.Count > 0 Then
                    dt.Columns("TotalHours").ColumnName = "WorkingHours"
                End If


                If dt.Rows.Count > 0 Then
                    dt.TableName = "RunCard"
                    If SysDataBaseClass.Import2ExcelByAs(filePath, o_outputFile, dt, frmStation.GetNoVariables(dt), errorMsg) Then  'frmStation.GetVariables(dt)
                        'Using frmshow As New FrmShowRunCard()
                        '    frmshow.filePath = o_outputFile
                        '    frmshow.ShowDialog()
                        'End Using
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的流程卡表头信息！")
                End If
            End Using

            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "DoExport", "RCard")
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function GetLogTable() As DataTable
        Dim lssql As String = ""
        Dim strOrderbySQL As String = String.Empty

        lssql = " SELECT ID, a.PartID ,b.StationName ,type ,c.UserName as OldUserID ,a.OldModifyTime ," & _
                " OldValue ,d.UserName as NewUserID, a.NewModifyTime , a.NewValue  " & _
                " FROM m_RCardChangeLog_t a left join m_RStation_t b on a.stationid = b.stationid" & _
                " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                " WHERE 1=1 "

        strOrderbySQL = " ORDER BY a.ID DESC"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql + strOrderbySQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                m_dtRuncardLog = o_dt
            Else
                m_dtRuncardLog = Nothing
            End If
        End Using
        Return m_dtRuncardLog
    End Function

    Private Sub DoExportLog(ByVal strPath As String)
        Dim o_outputFile As String = ""
        Dim errorMsg As String = Nothing
        Dim filePath As String = ""
        Try

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardLogTemplate.xlsx"
            o_outputFile = strPath + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion)
            ' frmStation.runCardPn = Me.RunCardPn

            Using dt As DataTable = GetLogTable()
                If dt.Rows.Count > 0 Then
                    dt.TableName = "RunCard"
                    If SysDataBaseClass.Import2ExcelByAs(filePath, o_outputFile, dt, frmStation.GetNoVariablesLog(dt), errorMsg) Then
                        'Using frmshow As New FrmShowRunCard()
                        '    frmshow.filePath = o_outputFile
                        '    frmshow.ShowDialog()
                        'End Using
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的流程卡修改日志信息！")
                End If
            End Using

            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "DoExportLog", "RCard")
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub toolExportChangeLog_Click(sender As Object, e As EventArgs) Handles toolExportChangeLog.Click
        Try
            'Dim strPath As String = ""
            'Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion)
            'frmStation.SelectExportPath("RunCard", strPath)

            'Call DoExportLog(strPath)
            Dim frmlog As New FrmRCardLog
            frmlog.ShowDialog()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "toolExportChangeLog_Click", "RCard")
        End Try
    End Sub

    Private Sub ToolReEnd_Click(sender As Object, e As EventArgs) Handles ToolReInsertRCard.Click

        Dim frmUndo As New FrmRCardDelUndo
        frmUndo.ShowDialog()


    End Sub


#Region "方法"

#Region "打印流程卡"

    Private Sub PrintRunCard(Optional ByVal pn As String = "", Optional ByVal o_strRuncard As List(Of RCardComBusiness.stcRuncard) = Nothing)  'ByVal pn As string
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = "", lssql As String = String.Empty
        Try
            If Not IsNothing(o_strRuncard) Then
                For Each o_strTempRuncard In o_strRuncard
                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPartPN & ".xlsx" & ","
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPartPN & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"

                    Dim frmStation As New FrmRunCardImportStation(o_strTempRuncard.RunCardPartPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                    ' frmStation.runCardPn = Me.RunCardPn
                    frmStation.runCardPartId = o_strTempRuncard.RunCardPartPN

                    ' lssql = "  SELECT * FROM dbo.fun_GetRCardPrint('" & pn.Trim & "','"& VbCommClass.&"') "
                    'Using dt As DataTable = sqlConn.GetDataTable(lssql)

                    Using dt As DataTable = RCardComBusiness.GetDataTable(FrmRunCardImportStation.GetExportSql(o_strTempRuncard.RunCardPartPN))
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If RunCardBusiness.Import2ExcelByAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt), o_strTempRuncard.RunCardPartPN, errorMsg) Then  'outputFile
                                'Using frmshow As New FrmShowRunCard()
                                '    frmshow.filePath = outputFile
                                '    frmshow.ShowDialog()
                                'End Using
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件找不到对应的流程卡！")
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
                Dim frmStation As New FrmRunCardImportStation(Me.RunCardPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                frmStation.runCardPartId = Me.RunCardPN
                Using dt As DataTable = RCardComBusiness.GetDataTable(FrmRunCardImportStation.GetExportSql(Me.RunCardPN))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        If RunCardBusiness.Import2ExcelByAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt), Me.RunCardPN, errorMsg) Then
                            Using frmshow As New FrmShowRunCard()
                                frmshow.filePath = o_outputFile
                                frmshow.ShowDialog()
                            End Using
                        Else
                            MessageUtils.ShowError(errorMsg)
                        End If
                    Else
                        MessageUtils.ShowError("料件找不到对应的流程卡！")
                    End If
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "PrintRunCard", "RCard")
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
            Dim dt As DataTable = RunCardBusiness.GetBomInfo(Me.RunCardPN)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "NeedUpdateBom", "RCard")
            Return False
        End Try
    End Function
#End Region

    Public Sub BindBodyWhenAdd(ByVal runId As String)
        Try
            LoadRunCardBody(runId)
            If Me.RunCardStatus = 1 Then
                Me.RunCardStatus = 0
                LoadRunCardHeader("")
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
            dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - CInt(IIf(dgvRunCardBody.Rows.Count > 10, 10, 1))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "BindBodyWhenAdd", "RCard")
        End Try
    End Sub

    Private Sub AddButton(ByVal cIndex As Integer, ByVal rIndex As Integer)
        Try
            Me.dgvRunCardBody.Controls.Clear()
            If Me.RunCardStatus = 0 Then
                btn.Text = "Q"
                btn.Font = ft
                btn.Visible = True
                btn.ForeColor = Color.Black
                btn.BackColor = Color.WhiteSmoke
                btn.Width = CInt(Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Width / 5)
                btn.Height = Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height ' IIf(Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height > 20, 20, Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Height)
                Me.dgvRunCardBody.Controls.Add(btn)
                btn.Location = New System.Drawing.Point((Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Right - btn.Width), Me.dgvRunCardBody.GetCellDisplayRectangle(cIndex, rIndex, True).Y)
                If currentColumnName = RunCardBusiness.BodyGrid.StationName.ToString Then
                    RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                    AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
                End If
                If currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then
                    RemoveHandler btn.Click, New EventHandler(AddressOf btn_Click)
                    AddHandler btn.Click, New EventHandler(AddressOf btn_Click)
                End If
                If rIndex = 0 Then
                    currentLeft = btn.Left
                    currentTop = btn.Top
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "AddButton", "RCard")
        End Try
    End Sub

    Private Sub UpdateData()
        Try
            If dgvRunCardBody.RowCount > 0 Then
                If dgvRunCardBody.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString <> currentBodyValue Then

                        'Add by cq 20161103
                        If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then  'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                            Exit Sub
                        End If
                        Dim runCardId As String = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.PartId.ToString).Value.ToString
                        'Rows(currentRowIndex)  ==> CurrentRow 20180814
                        Dim stationId As String = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
                        Dim WorkingHours As String = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).EditedFormattedValue.ToString
                        Dim editValue As String = dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

                        If currentColumnName = RunCardBusiness.BodyGrid.WorkingHours.ToString Then
                            If Not reg.IsMatch(dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim) Then
                                dgvRunCardBody.CurrentCell = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString)
                                dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
                                MessageUtils.ShowError("工时格式不正确，请确认！")
                                Return
                            End If
                        End If

                        If currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then 'cq 20160323
                            'Add reg in order to check not allow the error ProcessStandard key in to DB 
                            If reg.IsMatch(dgvRunCardBody.CurrentCell.EditedFormattedValue.ToString.Trim) Then
                                dgvRunCardBody.CurrentCell = dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString)
                                dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Selected = True
                                ' 
                                Return
                            End If

                            If (IsExistsCheckItem(runCardId, stationId)) AndAlso (currentBodyValue.IndexOf("裁线尺寸") >= 0 OrElse currentBodyValue.IndexOf("左端脱皮") >= 0 OrElse currentBodyValue.IndexOf("左高度mm") >= 0 OrElse currentBodyValue.IndexOf("右高度mm") >= 0) Then
                                Return
                            End If
                        End If
                        Dim StationSeq As Integer = Convert.ToInt32(dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value)
                        Dim strSQL As String = RunCardBusiness.GetBodyUpdateSQL(Me.IsQueryOldVersion, currentColumnName, editValue, runCardId, stationId, currentBodyValue, StationSeq)

                        If Not String.IsNullOrEmpty(strSQL) Then
                            RCardComBusiness.ExecSQL(strSQL)
                            ' dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                            'mark by cq 20161218
                            ' dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now
                            currentRowIndex = -1
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "UpdateData", "RCard")
        End Try
    End Sub

    Private Function IsExistsCheckItem(ByVal strPartID As String, ByVal strStationID As String) As Boolean
        Dim lssql As String = String.Empty

        lssql = " SELECT 1 FROM dbo.m_RCardDCheckItem_t  WHERE " & _
                " PartID ='" & strPartID & "'" & _
                " AND StationID ='" & strStationID & "'   "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsExistsCheckItem = True
            Else
                IsExistsCheckItem = False
            End If
        End Using
        Return IsExistsCheckItem
    End Function

    Private Sub UpdateStdTime(ByVal parCountWorkHoursValue As String)
        Try
            If dgvRunCardBody.RowCount > 0 Then

                'Add by cq 20161103, modify by cq 20161105
                If currentRowIndex < 0 OrElse Me.dgvRunCardBody.RowCount <= currentRowIndex Then 'IsNothing(dgvRunCardBody.Rows(currentRowIndex)) Then
                    Exit Sub
                End If

                Dim runCardId As String = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.PartId.ToString).Value.ToString
                Dim stationId As String = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString

                If Not reg.IsMatch(parCountWorkHoursValue) Then
                    dgvRunCardBody.CurrentCell = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString)
                    dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Selected = True
                    MessageUtils.ShowError("工时格式不正确，请确认！")
                    Return
                End If
                Dim StationSeq As Integer = Convert.ToInt32(dgvRunCardBody.CurrentRow.Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value)
                Dim strSQL As String = RunCardBusiness.GetBodyUpdateSQL(Me.IsQueryOldVersion, RunCardBusiness.BodyGrid.WorkingHours.ToString, parCountWorkHoursValue, runCardId, stationId, "", StationSeq)

                If Not String.IsNullOrEmpty(strSQL) Then
                    RCardComBusiness.ExecSQL(strSQL)
                    dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.UserId.ToString).Value = VbCommClass.VbCommClass.UseId
                    dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.InTime.ToString).Value = Date.Now
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "UpdateStdTime", "RCard")
        End Try
    End Sub

#Region "SetControlStatus"
    Private Sub SetControlStatus()
        Try
            If btnCopy.Tag Is Nothing Then btnCopy.Tag = ""
            If btnAudit.Tag Is Nothing Then btnAudit.Tag = ""
            If toolExportChangeLog.Tag Is Nothing Then toolExportChangeLog.Tag = ""
            Me.btnCopy.Enabled = CBool(IIf(btnCopy.Tag.ToString = "YES", True, False))
            Me.btnAudit.Enabled = CBool(IIf(btnAudit.Tag.ToString = "YES", True, False))

            'add by cq 20180622
            Me.btnModifyTime.Enabled = CBool(IIf(btnModifyTime.Tag.ToString = "YES", True, False))
            Me.toolExportChangeLog.Enabled = CBool(IIf(toolExportChangeLog.Tag.ToString = "YES", True, False))

            If tsmiHeaderAdd.Tag Is Nothing Then tsmiHeaderAdd.Tag = ""
            If tsmiHeaderModify.Tag Is Nothing Then tsmiHeaderModify.Tag = ""
            If tsmiHeaderSearch.Tag Is Nothing Then tsmiHeaderSearch.Tag = ""
            If tsmiHeaderPrint.Tag Is Nothing Then tsmiHeaderPrint.Tag = ""
            If tsmiHeaderDelete.Tag Is Nothing Then tsmiHeaderDelete.Tag = ""
            If tsmiHeaderHide.Tag Is Nothing Then tsmiHeaderHide.Tag = ""
            If tsmiHeaderImport.Tag Is Nothing Then tsmiHeaderImport.Tag = ""
            If tsmiHeaderExport.Tag Is Nothing Then tsmiHeaderExport.Tag = ""
            If tsmiHeaderReject.Tag Is Nothing Then tsmiHeaderReject.Tag = ""
            If tsmiHeaderCancel.Tag Is Nothing Then tsmiHeaderCancel.Tag = ""

            Me.tsmiHeaderAdd.Enabled = CBool(IIf(tsmiHeaderAdd.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderModify.Enabled = CBool(IIf(tsmiHeaderModify.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderSearch.Enabled = CBool(IIf(tsmiHeaderSearch.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderPrint.Enabled = CBool(IIf(tsmiHeaderPrint.Tag.ToString = "YES", True, False))

            'cq 20160721
            Me.tsmiHeaderHide.Enabled = CBool(IIf(tsmiHeaderHide.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderDelete.Enabled = CBool(IIf(tsmiHeaderDelete.Tag.ToString = "YES", True, False))

            Me.tsmiHeaderImport.Enabled = CBool(IIf(tsmiHeaderImport.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderExport.Enabled = CBool(IIf(tsmiHeaderExport.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderReject.Enabled = CBool(IIf(tsmiHeaderReject.Tag.ToString = "YES", True, False))
            Me.tsmiHeaderCancel.Enabled = CBool(IIf(tsmiHeaderCancel.Tag.ToString = "YES", True, False))

            If tsmiBodyAdd.Tag Is Nothing Then tsmiBodyAdd.Tag = ""
            If tsmiBodyModify.Tag Is Nothing Then tsmiBodyModify.Tag = ""
            If tsmiBodyConfirm.Tag Is Nothing Then tsmiBodyConfirm.Tag = ""
            If tsmiBodyDelete.Tag Is Nothing Then tsmiBodyDelete.Tag = ""
            If RToolStripMenuItem.Tag Is Nothing Then RToolStripMenuItem.Tag = ""
            If tsmiPartAdd.Tag Is Nothing Then tsmiPartAdd.Tag = ""

            Me.tsmiBodyAdd.Enabled = CBool(IIf(tsmiBodyAdd.Tag.ToString = "YES", True, False))
            Me.tsmiBodyModify.Enabled = CBool(IIf(tsmiBodyModify.Tag.ToString = "YES", True, False))
            Me.tsmiBodyConfirm.Enabled = CBool(IIf(tsmiBodyConfirm.Tag.ToString = "YES", True, False))
            Me.tsmiBodyDelete.Enabled = CBool(IIf(tsmiBodyDelete.Tag.ToString = "YES", True, False))


            Me.RToolStripMenuItem.Enabled = CBool(IIf(tsmiBodyModify.Tag.ToString = "YES", True, False))
            Me.tsmiPartAdd.Enabled = CBool(IIf(tsmiPartAdd.Tag.ToString = "YES", True, False))
            editRight = CBool(IIf(tsmiBodyModify.Tag.ToString = "YES", True, False))
            'tsmiBodyModify.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "SetControlStatus", "RCard")
        End Try
    End Sub
#End Region

#End Region


    'Mark by cq 20170710
    'Private Sub dgvRunCardHeader_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvRunCardHeader.DataBindingComplete
    '    Try
    '        If Me.m_ChkboxAll.Checked = True Then
    '            ' Me.dgvRunCardHeader.Row(0).Cells(RunCardBusiness.HeaderGrid.CheckBox)
    '            'cq 20161104
    '            If Not IsNothing(dgvRunCardHeader) AndAlso dgvRunCardHeader.Rows.Count > 0 Then
    '                'mark by cq 20170710
    '                ' dgvRunCardHeader.Rows(0).Cells(RunCardBusiness.HeaderGrid.CheckBox).Value = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "FrmRunCard", "dgvRunCardHeader_DataBindingComplete", "RCard")
    '    End Try
    'End Sub

    'Private Sub syncTTTimeLogRecord(ByVal PartID As String, ByVal o_strModifyUserID As String, ByVal o_ModifyTime As Date, _
    '                               ByVal o_strCreateUserID As String, ByVal o_AuditTime As Date, ByVal o_strAuditUserID As String, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then
    '        o_strSQL.AppendLine(" COMMIT;")
    '    Else
    '        '塞入头部
    '        ' Insert into LXXT.ECU_FILE
    '        '(ECU01, ECU02, ECU04, ECU05, ECUACTI, 
    '        ' ECUUSER, ECUGRUP, ECUMODU, ECUDATE, ECU10, 
    '        ' ECU11) Values
    '        '('904040838', '1', 10, 30, 'Y', 
    '        '    'C022918', 'P17234', 'C039318', TO_DATE('10/14/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS'), 'Y',  3);
    '        ' ecuud13 写入日期 ,ecuud02 审核人工号
    '        o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECU_FILE T1")
    '        o_strSQL.Append("  USING (SELECT '" & PartID & "' ECU01 FROM DUAL) T2")
    '        o_strSQL.Append(" ON (T1.ECU01 = T2.ECU01) ")
    '        o_strSQL.Append("  WHEN  MATCHED THEN")
    '        o_strSQL.Append("  UPDATE SET T1.ECUMODU = '" & o_strModifyUserID & "',T1.ECUDATE = TO_DATE('" & o_ModifyTime & "','YYYY-MM-DD HH24:MI:SS'),ecuud13= TO_DATE('" & o_AuditTime & "','YYYY-MM-DD HH24:MI:SS'),ecuud02='" & o_strAuditUserID & "'")
    '        o_strSQL.Append("    WHERE ECU01='" & PartID & "'")
    '        o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '        o_strSQL.Append(" INSERT (ECU01, ECU02, ECU04, ECU05, ECUACTI, ")
    '        o_strSQL.Append(" ECUUSER, ECUGRUP, ECUMODU, ECUDATE, ECU10, ")
    '        o_strSQL.Append(" ECU11,ECUUD13,ECUUD02)")
    '        o_strSQL.Append(" VALUES")
    '        o_strSQL.Append("  ('" & PartID & "','1', 10, 30,'Y',")
    '        o_strSQL.Append("  '" & o_strCreateUserID & "','P17234','" & o_strModifyUserID & "',TO_DATE('" & o_ModifyTime & "','YYYY-MM-DD HH24:MI:SS'), ")
    '        o_strSQL.Append(" 'Y', 0,TO_DATE('" & o_AuditTime & "','YYYY-MM-DD HH24:MI:SS'),'" & o_strAuditUserID & "');")
    '        o_strSQL.Append(" COMMIT;")
    '    End If

    'End Sub

    'Private Sub syncA05TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        'ecb38    /*單位人力 */ （标准产量 ）
    '        'ecb15     number(15,3),    /*标准标配人工數  */  ( 标准排配人数)
    '        'ecb34    number(15,3),   /*工作时间(H) */  ( 工作时间H)
    '        If hous > 0 Then  'A05
    '            o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'A05' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='A05'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1, 15,0,'A05',")
    '            o_strSQL.Append("  '0', 0,N'半自动压接连接',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
    '        Else
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND  ECB06='A05' ;")
    '        End If
    '    End If
    'End Sub

    'Private Sub sync05TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        If hous > 0 Then  '05, add by cq 20180724
    '            o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'05' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='05'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1, 5,0,'05',")
    '            o_strSQL.Append("  '0', 0,N'生产线前加工',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
    '        Else
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19='" & m_ProPreHours & "' , ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND  ECB06='05' ;")
    '        End If
    '    End If
    'End Sub

    'Private Sub sync04TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        If hous > 0 Then  '04
    '            o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'04' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='04'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1, 4,0,'04',")
    '            o_strSQL.Append("  '0', 0,N'裁切前加工(仓库)',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
    '        Else
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19='" & m_trimHours & "' , ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND  ECB06='04' ;")
    '        End If
    '    End If
    'End Sub

    'Private Sub sync03TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        If hous > 0 Then  '03
    '            o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'03' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06)")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='03'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1,3,0,'03',")
    '            o_strSQL.Append("  '0', 0,N'成型',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES',0,SYSDATE);")
    '        Else
    '            'ecbud13     date,  /*变更日期 */
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND  ECB06='03' ;")
    '        End If
    '    End If

    'End Sub

    'Private Sub sync02TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        If hous > 0 Then
    '            o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'02' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND T1.ECB06 = T2.ECB06)")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE ")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='02'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append("ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1, 2,0,'02',")
    '            o_strSQL.Append("  '0', 0,N'产线',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0, SYSDATE);")
    '        Else
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND ECB06='02' ;")
    '        End If
    '    End If
    'End Sub

    'Private Sub sync01TTTime(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
    '    If VbCommClass.VbCommClass.IsConSap = "Y" Then  'VbCommClass.VbCommClass.IsConSap
    '        SapCommon.syncTTTimeSap(PartID, ECB03, ECB06, ECB17, hous, o_strSQL)
    '    Else
    '        If hous > 0 Then '01
    '            o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
    '            o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'01' ECB06 FROM DUAL) T2")
    '            o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND T1.ECB06 = T2.ECB06)")
    '            o_strSQL.Append(" WHEN MATCHED THEN")
    '            o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & hous & "',ECBUD13=SYSDATE")
    '            o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND ECB06='01'")
    '            o_strSQL.Append("  WHEN NOT MATCHED THEN")
    '            o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
    '            o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
    '            o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
    '            o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
    '            o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
    '            o_strSQL.Append(" VALUES")
    '            o_strSQL.Append("  ('" & PartID & "', 1, 1,0,'01',")
    '            o_strSQL.Append("  'A00', 1, N'铆端前加工',0,'" & hous & "',")
    '            o_strSQL.Append("  '0', 0, 0,0,'N',")
    '            o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
    '            o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
    '        Else
    '            o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
    '            o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
    '            o_strSQL.Append("AND  ECB06='01' ;")
    '        End If
    '    End If
    'End Sub

End Class