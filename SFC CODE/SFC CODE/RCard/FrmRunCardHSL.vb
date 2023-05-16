Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Text


Public Class FrmRunCardHSL



#Region "属性"
    Private _IsQueryOldVersion As Boolean = False
    ''' <summary>
    ''' 是否查询旧版本
    ''' </summary>
    ''' <returns></returns>
    Public Property IsQueryOldVersion() As Boolean
        Get
            Return _IsQueryOldVersion
        End Get
        Set(ByVal value As Boolean)
            _IsQueryOldVersion = value
        End Set
    End Property

    Private _strWhere As String
    ''' <summary>
    ''' 查询条件
    ''' </summary>
    ''' <returns></returns>
    Public Property strWhere() As String
        Get
            Return _strWhere
        End Get
        Set(ByVal value As String)
            _strWhere = value
        End Set
    End Property

    Private _dv As DataView
    Public Property dv() As DataView
        Get
            Return _dv
        End Get
        Set(ByVal value As DataView)
            _dv = value
        End Set
    End Property


    Dim RunCardData As DataTable = Nothing

    Private Enum RunCardType
        UnFinish = 0
        Finish = 1
        Audit = 2
    End Enum

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

    ''' <summary>
    ''' 铆端 01
    ''' </summary>
    ''' <remarks></remarks>
    Private m_preHours As Double = 0

    ''' <summary>
    ''' 产线 02
    ''' </summary>
    ''' <remarks></remarks>
    Private m_proHours As Double = 0

    ''' <summary>
    ''' 成型 03
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ContourHours As Double = 0

    ''' <summary>
    ''' 04,裁切
    ''' </summary>
    ''' <remarks></remarks>
    Private m_trimHours As Double = 0

    ''' <summary>
    ''' A05 半自动压接
    ''' </summary>
    ''' <remarks></remarks>
    Private m_autoHours As Double = 0

    Private _isQquery As Boolean = False
    ''' <summary>
    ''' 是否查询
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isQquery() As Boolean
        Get
            Return _isQquery
        End Get
        Set(ByVal value As Boolean)
            _isQquery = value
        End Set
    End Property

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


#End Region


#Region "SideBar点击事件"
    ''' <summary>
    ''' SideBar点击事件
    ''' </summary>
    ''' <param name="sort"></param>
    ''' <param name="type"></param>
    ''' <remarks></remarks>
    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As RunCardType)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Try
            item.Image = ImageList1.Images(0)
            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left
            '晒选
            dv.Sort = "InTime " & sort & " "

            Select Case type
                Case RunCardType.UnFinish
                    '未完成
                    dv.RowFilter = "Status=0 "
                    '清除现有Item
                    sbPanelUnfinish.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dv
                        newItem = item.Copy()
                        newItem.Text = drv.Item(RunCardBusiness.HeaderGrid.PartId.ToString).ToString()
                        'newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)), "",
                        '                                    drv.Item(RunCardBusiness.HeaderGrid.DESCRIPTION.ToString)))
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
                    '已完成
                    dv.RowFilter = "Status=1 "
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
                    dv.RowFilter = "Status=2 "
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
#End Region

#Region "窗体加载事件"
    Private Sub FrmRunCardHSL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSideBar()
        LoadRunCardHeader(False, "")
        LoadSideBarByClick("desc", RunCardType.Finish)
    End Sub
#End Region

#Region "加载流程卡单头数据"
    ''' <summary>
    ''' 加载流程卡单头数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadRunCardHeader(ByVal isQueryOldVersion As Boolean, ByVal sqlWhere As String)
        Dim dt As DataTable = RunCardBusiness.GetRunCardHeader(isQueryOldVersion, sqlWhere, "H")
        dgvRunCardHeader.AutoGenerateColumns = False
        dgvRunCardHeader.DataSource = dt
        dgvRunCardHeader.ClearSelection()
        dgvRunCardHeader.Rows(0).Cells(1).Selected = True
        dgvRunCardHeader.CurrentCell = dgvRunCardHeader.Rows(0).Cells(1)
    End Sub
#End Region

#Region "加载"
    ''' <summary>
    ''' 加载SideBar
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadSideBar()
        Dim Sql =
        " SELECT   '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
        "PC.TypeDest," & _
        " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
        " PC.DESCRIPTION , " &
        "RC.DrawingVer ,RC.Shape ," & _
         " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  " & _
         " round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,rc.SeriesID+'('+a.SeriesName+')' as SeriesName," & _
        "IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
        "RC.FinishSize, RC.Status, " & _
        "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
        "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion " &
        "FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  " &
        " LEFT JOIN m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " left join m_Series_t a on a.SeriesID=rc.SeriesID " &
        " WHERE 1=1  and RC.RCardType='H' " & vbCrLf &
        RCardComBusiness.GetFatoryProfitcenter("RC") & _
        " GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
               " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' " & _
        " ORDER BY RC.INTIME DESC "
        If IsQueryOldVersion = False Then
            Sql = String.Format(Sql, "m_RCardM_t", "m_RCardD_t")
        Else
            Sql = String.Format(Sql, "m_RCardMOldVer_t", "m_RCardDOldVer_t")
        End If
        Dim dt = DbOperateUtils.GetDataTable(Sql)
        RunCardData = dt
        Dim o_strFinishNum As String = "0", o_strAuditNum As String = "0", o_strUnfinish As String = "0"
        If dt.Rows.Count > 0 Then

            '0.制作中;1.已生效;2: .待审核
            o_strFinishNum = CStr(dt.Select("status=1").Length) : o_strAuditNum = CStr(dt.Select("status=2").Length) : o_strUnfinish = CStr(dt.Select("status=0").Length)
            sbPanelFinish.Text = sbPanelFinish.Text.Split(CChar("("))(0) + "(" + o_strFinishNum + ")"
            sbPanelAudit.Text = sbPanelAudit.Text.Split(CChar("("))(0) + "(" + o_strAuditNum + ")"
            sbPanelUnfinish.Text = sbPanelUnfinish.Text.Split(CChar("("))(0) + "(" + o_strUnfinish + ")"
        Else
            sbPanelFinish.Text = "已生效(0)"
            sbPanelAudit.Text = "待审核(0)"
            sbPanelUnfinish.Text = "制作中(0)"
        End If
        dv = New DataView(RunCardData)

        Me.txtCount.Text = CStr(dt.Rows.Count)
    End Sub
#End Region


#Region "新增流程卡单头"
    ''' <summary>
    ''' 新增流程卡单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderAdd_Click(sender As Object, e As EventArgs) Handles tsmiHeaderAdd.Click
        Dim frmHeader As New FrmRunCardHeaderEdit("add", Nothing)
        If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
            loadSideBar()
            LoadSideBarByClick("desc", RunCardType.UnFinish)
            LoadRunCardHeader(False, Me.strWhere)
        End If
    End Sub
#End Region

#Region "流程卡单头复制"
    ''' <summary>
    ''' 流程卡单头复制
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsmiHeaderCopy_Click(sender As Object, e As EventArgs) Handles tsmiHeaderCopy.Click
        Dim Selected As String = String.Empty
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        If Not dgvRunCardHeader.CurrentCell Is Nothing Then
            If IsDBNull(dgvRunCardHeader.CurrentCell.FormattedValue) Then
                Selected = ""
            Else
                Selected = CStr(dgvRunCardHeader.CurrentCell.FormattedValue)
            End If
            Clipboard.SetDataObject(Selected)
        End If
    End Sub
#End Region

#Region "流程卡单头修改"
    ''' <summary>
    ''' 流程卡单头修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsmiHeaderModify_Click(sender As Object, e As EventArgs) Handles tsmiHeaderModify.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        '审核状态不可修改
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowError("料件:""" & PartID & """ 待审核或是已生效状态,不允许修改！")
            Exit Sub
        End If
        Dim frmHeader As New FrmRunCardHeaderEdit("modify", dgvRunCardHeader.CurrentRow)
        If frmHeader.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadRunCardHeader(False, Me.strWhere)
            LoadSideBarByClick("desc", RunCardType.UnFinish)
        End If
    End Sub
#End Region

#Region "流程卡单头查询"
    ''' <summary>
    ''' 流程卡单头查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderSearch_Click(sender As Object, e As EventArgs) Handles tsmiHeaderSearch.Click
        Dim frmQuery As New FrmRunCardQuery()
        If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.isQquery = True
            LoadRunCardHeader(frmQuery.IsQueryOldVersion, frmQuery.SqlWhere)
            strWhere = frmQuery.SqlWhere
            Me.IsQueryOldVersion = frmQuery.IsQueryOldVersion
            txtCount.Text = dgvRunCardHeader.Rows.Count.ToString
        End If
    End Sub
#End Region

#Region "流程卡单头SelectionChanged事件"
    Private Sub dgvRunCardHeader_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRunCardHeader.SelectionChanged
        Try
            Me.RunCardPN = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            Me.Version = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
            Me.RunCardStatus = dgvRunCardHeader.CurrentRow.Cells("Status").Value
            currentHeaderValue = dgvRunCardHeader.CurrentCell.FormattedValue.ToString
            LoadRunCardBody()
            '隐藏料件面板
            Me.dgvPartNumber.Visible = False
        Catch ex As Exception

        End Try
        
    End Sub
#End Region

#Region "流程卡单头驳回"
    ''' <summary>
    ''' 流程卡单头驳回
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderReject_Click(sender As Object, e As EventArgs) Handles tsmiHeaderReject.Click
        Try
            If dgvRunCardHeader.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选中一行数据")
                Exit Sub
            End If
            Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            'If Convert.ToInt32(Status) = 1 Or Convert.ToInt32(Status) = 0 Then
            '    MessageUtils.ShowError("该料件的流程卡已是审核状态，不允许驳回！")
            '    Exit Sub
            'End If
            If MessageUtils.ShowConfirm("确认要驳回" & PartID & "的流程卡信息？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                DbOperateUtils.ExecSQL("UPDATE m_RCardM_t SET STATUS=0 where PartID='" & PartID & "'")
                MessageUtils.ShowInformation("驳回成功")
                LoadRunCardHeader(Me.IsQueryOldVersion, Me.strWhere)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("数据异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "流程卡单头打印"
    ''' <summary>
    ''' 流程卡单头打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderPrint_Click(sender As Object, e As EventArgs) Handles tsmiHeaderPrint.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选中一行数据")
            Exit Sub
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
        If PartID.ToString().Substring(0, 1) = "9" Then
            Dim o_strErpVer = RunCardBusiness.GetVerFromErp(PartID).ToUpper 'TT料号版本
            If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso DrawingVer.ToUpper().Trim <> o_strErpVer.Trim Then
                MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,请确认！",
                                        PartID, DrawingVer.ToUpper, o_strErpVer.ToUpper))
                Exit Sub
            End If
        End If
        If CInt(Status) <> 1 Then
            MessageUtils.ShowError("制作中和审核中的流程卡不允许打印！")
            Exit Sub
        End If
        Dim _runCardIDList As List(Of RCardComBusiness.stcRuncard) = New List(Of RCardComBusiness.stcRuncard)
        Dim o_Runcard = New RCardComBusiness.stcRuncard()
        o_Runcard.RunCardPartPN = PartID
        o_Runcard.Status = Status
        o_Runcard.RCardVersion = DrawingVer
        _runCardIDList.Add(o_Runcard)
        PrintRunCard("", _runCardIDList)
    End Sub
#End Region

#Region "打印流程卡单头"

    Private Sub PrintRunCard(Optional ByVal pn As String = "", Optional ByVal o_strRuncard As List(Of RCardComBusiness.stcRuncard) = Nothing)  'ByVal pn As string
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Try
            If Not IsNothing(o_strRuncard) Then
                For Each o_strTempRuncard In o_strRuncard
                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPartPN & ".xlsx" & ","
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempRuncard.RunCardPartPN & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"

                    Dim frmStation As New FrmRunCardImportStation(o_strTempRuncard.RunCardPartPN, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                    ' frmStation.runCardPn = Me.RunCardPn
                    frmStation.runCardPartId = o_strTempRuncard.RunCardPartPN

                    Using dt As DataTable = RCardComBusiness.GetDataTable(frmStation.GetExportSql(o_strTempRuncard.RunCardPartPN))
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
                            Exit Sub
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
                Dim frmStation As New FrmRunCardImportStation(PartID, "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                frmStation.runCardPartId = PartID
                Using dt As DataTable = RCardComBusiness.GetDataTable(frmStation.GetExportSql(PartID))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        If RunCardBusiness.Import2ExcelByAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt), PartID, errorMsg) Then
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

#Region "导出流程卡单头"
    ''' <summary>
    ''' 导出流程卡单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderExport_Click(sender As Object, e As EventArgs) Handles tsmiHeaderExport.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选中一行数据")
            Exit Sub
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value

        Dim _runCardIDList As List(Of RCardComBusiness.stcRuncard) = New List(Of RCardComBusiness.stcRuncard)

        Dim frmStation As New FrmRunCardImportStation(PartID, "Export", Me.IsQueryOldVersion)

        Dim o_Runcard = New RCardComBusiness.stcRuncard()
        o_Runcard.RunCardPartPN = PartID
        o_Runcard.Status = Status
        o_Runcard.RCardVersion = DrawingVer
        _runCardIDList.Add(o_Runcard)

        For Each o_strRunCard As RCardComBusiness.stcRuncard In _runCardIDList
            'If Val(o_strRunCard.Status) <> 1 Then
            '    'MessageBox.Show("制作中和审核中的流程卡不允许导出!")
            '    MessageUtils.ShowInformation("制作中和审核中的流程卡不允许导出！")
            '    Exit Sub
            'End If
            frmStation.m_stcRuncardList.Add(o_strRunCard)
        Next

        '刷新
        frmStation.SelectPath(o_Runcard.RunCardPartPN)
    End Sub
#End Region

#Region "流程卡单头变更记录"
    ''' <summary>
    ''' 流程卡单头变更记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderLookLog_Click(sender As Object, e As EventArgs) Handles tsmiHeaderLookLog.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选中一行数据")
            Exit Sub
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim frmRCardLog As New FrmRCardLog()
        frmRCardLog.txtPartID.Text = PartID
        frmRCardLog.ShowDialog()
    End Sub
#End Region

#Region "流程卡单头单元格双击事件"
    Private Sub dgvRunCardHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellDoubleClick
        Try
            Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value

            If dgvRunCardHeader.Columns(e.ColumnIndex).Name = "DrawingFilePath" Then
                Dim arrPara(0) As String
                Dim dtPLMData As DataTable
                Dim o_iLength As Integer
                Dim BomQuery As New com.luxshare_ict.plm.WebService1
                Dim Valueyy As String = dgvRunCardHeader.CurrentRow.Cells("PartID").Value

                Dim DT As DataTable = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, Valueyy, "蓝图")
                Dim o_strFilter As String = Valueyy + "%"
                If DT.Rows.Count = 0 Then
                    MessageUtils.ShowError("图纸路径不存在！")
                    Exit Sub
                End If
                If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                    arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                Else
                    If Not IsNothing(DT) Then
                        DT.Clear()
                    End If
                    o_iLength = InStr(Valueyy, "-") - 1
                    If o_iLength <= 0 Then
                        o_iLength = CStr(Valueyy).Length
                    End If
                End If
                DT = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, Valueyy.Substring(0, o_iLength), "蓝图")
                o_strFilter = Valueyy.Substring(0, o_iLength) + "%"
                If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                    arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                End If
                dtPLMData = BomQuery.GetPLMData_current(arrPara, "n/K67oxui8q8TFMwoAQKng==")
                If dtPLMData.Rows.Count > 0 Then
                    Dim strEncryptionURL As String = CStr(dtPLMData.Rows(0).Item("url"))
                    If (String.IsNullOrEmpty(strEncryptionURL)) Then
                        Exit Sub
                    End If
                    Dim strURL As String = "http://172.20.22.85:17888/OnlinePreview/plmonline?cdid=" + dtPLMData.Rows(0).Item("id").ToString()
                    System.Diagnostics.Process.Start(strURL)
                Else
                    MessageUtils.ShowError("图纸路径不存在！")
                End If
            End If

            If dgvRunCardHeader.Columns(e.ColumnIndex).Name = "Shape" Then
                If Convert.ToInt32(Status) = 0 Or Convert.ToInt32(Status) = 2 Then
                    dgvRunCardHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                    CurrentHeadRowIndex = e.RowIndex
                    CurrentHeadColumnIndex = e.ColumnIndex
                    CurrentHeadColumnName = "Shape"
                    CurrentHeadPartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
                End If
            End If
            If dgvRunCardHeader.Columns(e.ColumnIndex).Name = "SeriesName" Then
                Dim frmSeries = New FrmRunCardSeries()
                Dim Series = dgvRunCardHeader.CurrentCell.Value
                If IsDBNull(Series) = False And Not Series Is Nothing Then
                    frmSeries.Series = Series.ToString().Substring(0, Series.ToString().IndexOf("("))
                End If
                frmSeries.PartID = dgvRunCardHeader.CurrentRow.Cells(RunCardBusiness.NewHeaderGrid.PartId.ToString()).Value.ToString()
                Dim dr = frmSeries.ShowDialog()
                If dr = Windows.Forms.DialogResult.OK Then
                    LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
                    LoadSideBarByClick("desc", RunCardType.UnFinish)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "复制流程卡单身"
    ''' <summary>
    ''' 复制流程卡单身
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyCopy_Click(sender As Object, e As EventArgs) Handles tsmiBodyCopy.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Selected As String = String.Empty
        If IsDBNull(dgvRunCardBody.CurrentCell.Value) Then
            Selected = ""
        Else
            Selected = CStr(dgvRunCardBody.CurrentCell.Value)
        End If
        Clipboard.SetDataObject(Selected)
    End Sub
#End Region

#Region "流程卡单身新增"
    ''' <summary>
    ''' 流程卡单身新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyAdd_Click(sender As Object, e As EventArgs) Handles tsmiBodyAdd.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行流程卡单头数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowError("料件:""" & PartID & """ 待审核或是已生效状态,不允许新增 O_O")
            Exit Sub
        End If
        Dim frmEdit As New FrmRunCardBodyEdit(PartID, "add", Nothing, Me.IsQueryOldVersion)
        frmEdit.RCardType = "H"
        frmEdit.Owner = Me
        frmEdit.drawingVer = DrawingVer
        frmEdit.ShowDialog()
    End Sub
#End Region

#Region " 加载流程卡单身数据"
    ''' <summary>
    ''' 加载流程卡单身数据
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadRunCardBody()
        Try
            If Not dgvRunCardHeader.CurrentRow Is Nothing Then
                Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
                Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
                Dim ds As DataSet = RunCardBusiness.GetRunCardBody(Me.IsQueryOldVersion, PartID, DrawingVer)
                dgvRunCardBody.AutoGenerateColumns = False
                Dim dtCardBody As DataTable = ds.Tables(0)

                If dtCardBody.Rows.Count > 0 Then
                    Dim dtDetail = ds.Tables(1)
                    Dim preHours As Double = 0, proHours As Double = 0, sufHours As Double = 0,
                    trimHours As Double = 0, autoHours As Double = 0, ProPreHours As Double = 0
                    For i As Integer = 0 To dtDetail.Rows.Count - 1
                        Select Case dtDetail.Rows(i)("SectionID").ToString()
                            Case "1", "01"
                                preHours = Math.Round(Val((dtDetail.Rows(i)("WorkingHours").ToString)), 1)
                                m_preHours = preHours
                            Case "2", "02"
                                '产线
                                proHours = Math.Round(Val(dtDetail.Rows(i)("WorkingHours").ToString), 1)
                                m_proHours = proHours
                            Case "3", "03"
                                '成型
                                sufHours = Math.Round(Val(dtDetail.Rows(i)("WorkingHours").ToString), 1)
                                m_ContourHours = sufHours
                            Case "4", "04"
                                trimHours = Math.Round(Val(dtDetail.Rows(i)("WorkingHours").ToString), 1)
                                m_trimHours = trimHours
                            Case "5", "05"
                                ProPreHours = Math.Round(Val(dtDetail.Rows(i)("WorkingHours").ToString), 1)
                            Case "A05"
                                autoHours = Math.Round(Val(dtDetail.Rows(i)("WorkingHours").ToString), 1)
                                m_autoHours = autoHours
                        End Select
                    Next
                    dtCardBody.Rows.Add(Nothing, Nothing, "工段汇总", "总工时(s):" & Convert.ToDouble(preHours + proHours + sufHours + trimHours + ProPreHours + autoHours), _
                                 Nothing, "铆端前加工(s):" & preHours.ToString, "产线(s):" & proHours.ToString, _
                                "成型(s):" & sufHours.ToString, Nothing, _
                                "裁切前(s):" & trimHours.ToString, Nothing, Nothing, "生产线前(s):" & ProPreHours.ToString, "半自动压接(s):" & autoHours.ToString)

                End If
                dgvRunCardBody.EndEdit()
                dgvRunCardBody.DataSource = dtCardBody

                If dtCardBody.Rows.Count > 0 AndAlso dgvRunCardBody.Rows.Count > 0 Then
                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(3).Style.BackColor = Color.LightGreen '铆端前加工
                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(4).Style.BackColor = Color.Aqua '产线
                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(5).Style.BackColor = Color.PeachPuff '成型

                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(6).Style.BackColor = Color.WhiteSmoke '裁切前
                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(8).Style.BackColor = Color.MistyRose '生产线前
                    dgvRunCardBody.Rows(dgvRunCardBody.Rows.Count - 1).Cells(9).Style.BackColor = Color.Tomato '半自动
                End If
                dgvPartNumber.Visible = False

                dgvRunCardBody.Columns("StationSQ").Width = 52
                dgvRunCardBody.Columns("StationName").Width = 120
                dgvRunCardBody.Columns("WorkingHours").Width = 75
                dgvRunCardBody.Columns("Equipment").Width = 100
                dgvRunCardBody.Columns("ProcessStandard").Width = 310
                dgvRunCardBody.Columns("BodyRemark").Width = 120
                dgvRunCardBody.Columns("Uid").Width = 75
                dgvRunCardBody.Columns("BodyInTime").Width = 110
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "流程卡单身修改"
    ''' <summary>
    ''' 流程卡单身修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyModify_Click(sender As Object, e As EventArgs) Handles tsmiBodyModify.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核或是已生效状态,不允许修改！")
            Exit Sub
        End If
        'Dim frmDialog As New FrmRunCardBodyEdit("modify", dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
        'frmDialog.RCardType = "H"
        'If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    LoadRunCardBody()
        '    LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
        '    LoadSideBarByClick("desc", RunCardType.UnFinish)
        'End If
    End Sub
#End Region

#Region "流程卡单身删除"
    ''' <summary>
    ''' 流程卡单身删除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyDelete_Click(sender As Object, e As EventArgs) Handles tsmiBodyDelete.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
        Dim StationName = dgvRunCardBody.CurrentRow.Cells("StationName").Value
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核或是已生效状态,不允许删除 O_O")
            Exit Sub
        End If
        If MessageUtils.ShowConfirm("确认删除所选工站:""" & StationID & "-" & StationName & """ ?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            RunCardBusiness.DeleteBody(Me.IsQueryOldVersion, PartID, StationID, "")
            LoadRunCardBody()
        End If
    End Sub
#End Region

#Region "流程卡单身确认"
    ''' <summary>
    ''' 流程卡单身确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyConfirm_Click(sender As Object, e As EventArgs) Handles tsmiBodyConfirm.Click
        Dim num = 0
        Try
            If dgvRunCardBody.CurrentRow Is Nothing Then
                MessageUtils.ShowError("没有工站资料不能确认!")
                Exit Sub
            End If

            For Each dgvr As DataGridViewRow In dgvRunCardHeader.Rows
                Dim objValue = dgvr.Cells("ColChk").FormattedValue
                If Convert.ToBoolean(objValue) Then

                    Dim PartID = dgvr.Cells("PartID").Value
                    Dim DrawingVer = dgvr.Cells("DrawingVer").Value
                    Dim o_strErpVer = RunCardBusiness.GetVerFromErp(PartID).ToUpper 'TT料号版本
                    Dim Status = dgvr.Cells("Status").Value 'Status
                    Dim strTempStationNameList As String = String.Empty
                    If PartID.ToString().Substring(0, 1) = "9" Then
                        If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso DrawingVer.ToUpper().Trim <> o_strErpVer.Trim Then
                            MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,请确认！",
                                                   PartID, DrawingVer.ToUpper, o_strErpVer.ToUpper))
                            Exit Sub
                        End If
                    End If
                    If RunCardBusiness.CheckIsPartLoss(PartID, strTempStationNameList) Then
                        If MessageUtils.ShowConfirm("" & strTempStationNameList & " 这些工站没有维护料件的信息,仍然要确定吗? ", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            'bypass check
                        Else
                            Exit Sub
                        End If
                    End If
                    If Convert.ToInt32(Status) <> 0 Then  ' =  ==> <>
                        MessageUtils.ShowInformation("非制作中状态不允许确认！")
                        Exit Sub
                    End If
                    Dim sql As String = RunCardBusiness.GetBodyConfirmSQL(Me.IsQueryOldVersion, PartID)
                    RCardComBusiness.ExecSQL(sql)
                    num = num + 1
                End If
            Next
            If num = 0 Then
                MessageUtils.ShowError("请勾选一项")
                Exit Sub
            End If
            MessageUtils.ShowInformation("料件确认成功！")
            loadSideBar()
            LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
            LoadSideBarByClick("Desc", RunCardType.Finish)
        Catch ex As Exception
            MessageUtils.ShowError("数据异常" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region

#Region "流程卡单身重置"
    ''' <summary>
    ''' 流程卡单身重置
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RToolStripMenuItem.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核或是已生效状态,不允许重置！")
            Exit Sub
        End If
        'Dim frmDialog As New FrmRunCardBodyEdit("reset", dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
        'frmDialog.RCardType = "H"
        'If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    LoadRunCardBody()
        'End If
    End Sub
#End Region

#Region "流程卡单身复制"
    ''' <summary>
    ''' 流程卡单身复制
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolCopyBodyStation_Click(sender As Object, e As EventArgs) Handles ToolCopyBodyStation.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
        If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
            MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核或是已生效状态,不允许重置！")
            Exit Sub
        End If
        Dim frmStationCopy As New FrmRunCardStationCopy(PartID, StationID, "copy", dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
        frmStationCopy.RCardType = "H"
        If frmStationCopy.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadRunCardBody()
        End If
    End Sub
#End Region

#Region "流程卡单身工站变更记录"
    ''' <summary>
    ''' 流程卡单身工站变更记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyStationLog_Click(sender As Object, e As EventArgs) Handles tsmiBodyStationLog.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
            Exit Sub
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
        Dim frmRCardLog As New FrmRCardLog()
        frmRCardLog.txtPartID.Text = PartID
        frmRCardLog.txtStationID.Text = StationID
        frmRCardLog.ShowDialog()
    End Sub
#End Region

#Region "添加料号"
    ''' <summary>
    ''' 添加料号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiPartAdd_Click(sender As Object, e As EventArgs) Handles tsmiPartAdd.Click
        If dgvRunCardBody.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行工站数据")
            Exit Sub
        End If
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
        Dim StationName = dgvRunCardBody.CurrentRow.Cells("StationName").Value
        If Convert.ToInt32(Status) = 2 Then '审核中：不可修改
            MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核状态,不允许修改！")
            Exit Sub
        ElseIf Convert.ToInt32(Status) = 1 Then '已完成：不可修改
            MessageUtils.ShowInformation("料件:""" & PartID & """ 已完成状态,不允许修改！")
            Exit Sub
        ElseIf NeedUpdateBom(PartID) Then
            MessageUtils.ShowInformation("料件""" & PartID & """BOM中的部分物料已失效，请及时更新BOM！")
        End If
        Dim frmDialog As New FrmRunCardPartDetail(PartID, StationID, DrawingVer, Me.IsQueryOldVersion, StationName)
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ''刷新
            LoadPartGrid(PartID, StationID)
        End If
    End Sub
#End Region

#Region "BOM更新检查"
    ''' <summary>
    ''' BOM更新检查
    ''' </summary>
    ''' <param name="PartID">料号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NeedUpdateBom(ByVal PartID As String) As Boolean
        Try
            Dim dt As DataTable = RunCardBusiness.GetBomInfo(PartID)
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

#Region "绑定 RunCard 料件"
    ''' <summary>
    ''' 绑定 RunCard 料件
    ''' </summary>
    ''' <param name="PartID">料号</param>
    ''' <param name="StationID">工站编号</param>
    ''' <remarks></remarks>
    Private Sub LoadPartGrid(ByVal PartID As String, ByVal StationID As String)
        Dim dt As DataTable = RunCardBusiness.GetRunCardPart(Me.IsQueryOldVersion, PartID, StationID)
        dgvPartNumber.AutoGenerateColumns = False
        dgvPartNumber.DataSource = dt
        dgvPartNumber.ClearSelection()
    End Sub
#End Region

#Region "删除料号"
    ''' <summary>
    ''' 删除料号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiPartDelete_Click(sender As Object, e As EventArgs) Handles tsmiPartDelete.Click
        Try
            Dim num = 0
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            Dim StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
            Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
            If Convert.ToInt32(Status) = 2 Or Convert.ToInt32(Status) = 1 Then
                MessageUtils.ShowInformation("料件:""" & PartID & """ 待审核或是已生效状态,不允许删除！")
                Exit Sub
            End If

            For Each dgvr As DataGridViewRow In dgvPartNumber.Rows
                Dim PartIDChk = dgvr.Cells("ColPartIDChk").FormattedValue
                If Convert.ToBoolean(PartIDChk) Then

                    Dim EWPartNumber = dgvr.Cells("EWPartNumber").Value
                    Dim sql As String = RunCardBusiness.DeleteDPartID(Me.IsQueryOldVersion, PartID, EWPartNumber, StationID)

                    'add by 马跃平 2018-05-14
                    Dim dt As DataTable = RCardComBusiness.GetDataTable("select * from m_RCardDPart_t" & vbCrLf &
                    "where PartID='" & PartID & "' and Stationid='" & StationID & "'" & vbCrLf &
                    "and EWPartNumber='" & EWPartNumber & "'")

                    '删除之前的料号list
                    Dim oldPartList As String = getPartNumList(PartID, StationID)

                    RCardComBusiness.ExecSQL(sql)
                    '删除之后的料号list
                    Dim NewPartList As String = getPartNumList(PartID, StationID)

                    Dim OldUserID As String = dt.Rows(0)("UserID").ToString
                    Dim OldMofifyTime As String = Convert.ToDateTime(dt.Rows(0)("InTime")).ToString("yyyy-MM-dd HH:mm:ss")

                    Dim StrSql As String = " insert into m_RCardChangeLog_t" & vbCrLf &
                                     "(PartID,StationID,TYPE,OldUserID,OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & vbCrLf &
            " values ('" & PartID & "','" & StationID & "',N'物料','" & OldUserID & "'" & vbCrLf &
            ",'" & OldMofifyTime & "','" & oldPartList & "','" & SysMessageClass.UseId & "',getdate(),'" & NewPartList & "')"
                    RCardComBusiness.ExecSQL(StrSql)
                    num = num + 1
                End If
            Next

            If num = 0 Then
                MessageUtils.ShowError("请勾选一项,删除失败!")
                Exit Sub
            End If
            LoadPartGrid(PartID, StationID)

        Catch ex As Exception
            MessageUtils.ShowError("删除失败" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region

#Region "获取料号列表"
    ''' <summary>
    ''' 获取料号列表
    ''' </summary>
    ''' <param name="PartID">料号</param>
    ''' <param name="partStationID">工站编号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPartNumList(ByVal PartID As String, ByVal partStationID As String) As String
        Dim lsSQL As String = String.Empty
        getPartNumList = ""
        lsSQL = " DECLARE @EWPartNumbers NVARCHAR(max)='' " & _
                " SELECT  @EWPartNumbers=@EWPartNumbers+ISNULL(A.EWPartNumber,'')+','" & _
                " FROM m_RCardDPart_t  AS A   WHERE  PARTID ='" & PartID & "'" & _
                " AND Stationid='" & partStationID & "'" & _
               " SELECT @EWPartNumbers AS 'EWPartNumbers'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                getPartNumList = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                If getPartNumList.Length > 0 Then
                    getPartNumList = getPartNumList.Substring(0, Len(getPartNumList) - 1)
                End If
            End If
        End Using
        Return getPartNumList
    End Function
#End Region


#Region "流程卡单身SelectionChanged事件"
    ''' <summary>
    ''' 流程卡单身SelectionChanged事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRunCardBody_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRunCardBody.SelectionChanged

        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim StationID = ""
        If IsDBNull(dgvRunCardBody.CurrentRow.Cells("StationID").Value) = False Then
            StationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
        End If

        LoadPartGrid(PartID, StationID)
        'add by cq 20180619
        Me.dgvPartNumber.Visible = True

    End Sub
#End Region


    Public sort As String = "desc"
    Public sortMake As String = "desc"
    Public sortOk As String = "desc"

#Region "已生效"
    ''' <summary>
    ''' 已生效
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sbPanelFinish_Click(sender As Object, e As EventArgs) Handles sbPanelFinish.Click
        If sortOk = "desc" Then
            LoadSideBarByClick(sortOk, RunCardType.Finish)
            sortOk = "asc"
        Else
            LoadSideBarByClick(sortOk, RunCardType.Finish)
            sortOk = "desc"
        End If
    End Sub
#End Region

#Region "待审核"
    ''' <summary>
    ''' 待审核
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sbPanelAudit_Click(sender As Object, e As EventArgs) Handles sbPanelAudit.Click
        If sortMake = "desc" Then
            LoadSideBarByClick(sortMake, RunCardType.Audit)
            sortMake = "asc"
        Else
            LoadSideBarByClick(sortMake, RunCardType.Audit)
            sortMake = "desc"
        End If
    End Sub
#End Region

#Region "制作中"
    ''' <summary>
    ''' 制作中
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sbPanelUnfinish_Click(sender As Object, e As EventArgs) Handles sbPanelUnfinish.Click
        If sort = "desc" Then
            LoadSideBarByClick(sort, RunCardType.UnFinish)
            sbPanelFinish.SubItems.Sort()
            sort = "asc"
        Else
            LoadSideBarByClick(sort, RunCardType.UnFinish)
            sort = "desc"
        End If
    End Sub
#End Region

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

#Region "清空图片按钮"
    ''' <summary>
    ''' 清空图片按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtSearch.Text = ""
        LoadSideBarByClick("desc", RunCardType.Finish)
    End Sub
#End Region

#Region "txtSearch_KeyPress事件"
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim str As String = txtSearch.Text.Trim
            If String.IsNullOrEmpty(str) Then
                LoadSideBarByClick("", RunCardType.Finish)
            Else
                loadSideBar(" and PartID like '%" & str & "%'", Me.RunCardData, "asc", True)
            End If
        End If
    End Sub
#End Region

#Region "工具栏项点击事件"
    ''' <summary>
    ''' 工具栏项点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SideBar1_ItemClick(sender As Object, e As EventArgs) Handles SideBar1.ItemClick
        If TypeOf sender Is ButtonItem Then
            Dim SelectedItem As ButtonItem = CType(sender, ButtonItem)
            Dim partID As String = ""
            'Dim status As String = ""
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
                    partID = CStr(CType(SelectedItem.Tag, ArrayList).Item(0))
                Else
                    Exit Sub
                End If

                If Me.RunCardData.Select("PartID='" & partID & "'").Length > 0 Then
                    Me.RunCardData.Select("PartID='" & partID & "'")(0)("ClickTime") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")
                End If
                Me.RunCardData.DefaultView.Sort = "ClickTime Desc"
                Me.dgvRunCardHeader.DataSource = Me.RunCardData
                dgvRunCardHeader.ClearSelection()
                dgvRunCardHeader.CurrentCell = dgvRunCardHeader.Rows(0).Cells(1)
                dgvRunCardHeader.Rows(0).Selected = True
            End If
        End If
    End Sub
#End Region

#Region "复制流程"
    ''' <summary>
    ''' 复制流程
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据")
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim frmDialog As New FrmRunCardCopy()
        frmDialog.RCPartNumber = PartID
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadSideBarByClick("desc", RunCardType.UnFinish)
            '展开
            SideBar1.ExpandedPanel = sbPanelUnfinish
        End If
    End Sub
#End Region

#Region "打印"
    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvRunCardHeader.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选中一行数据")
            Exit Sub
        End If
        Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
        If PartID.ToString().Substring(0, 1) = "9" Then
            Dim o_strErpVer = RunCardBusiness.GetVerFromErp(PartID).ToUpper 'TT料号版本
            If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso DrawingVer.ToUpper().Trim <> o_strErpVer.Trim Then
                MessageUtils.ShowError(String.Format("流程卡[{0}]版本[{1}]跟ERP[{2}]不一致,请确认！",
                                        PartID, DrawingVer.ToUpper, o_strErpVer.ToUpper))
                Exit Sub
            End If
        End If

        'add by cq 20180619
        If CInt(Status) <> 1 Then
            MessageUtils.ShowError("制作中和审核中的流程卡不允许打印！")
            Exit Sub
        End If

        Dim _runCardIDList As List(Of RCardComBusiness.stcRuncard) = New List(Of RCardComBusiness.stcRuncard)
        Dim o_Runcard = New RCardComBusiness.stcRuncard()
        o_Runcard.RunCardPartPN = PartID
        o_Runcard.Status = Status
        o_Runcard.RCardVersion = DrawingVer
        _runCardIDList.Add(o_Runcard)
        PrintRunCard("", _runCardIDList)
    End Sub
#End Region

#Region "审核流程卡"

   

    ''' <summary>
    ''' 审核流程卡
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAudit_Click(sender As Object, e As EventArgs) Handles btnAudit.Click
        Try

            Dim num = 0
            For Each dgvr As DataGridViewRow In dgvRunCardHeader.Rows
                Dim objValue = dgvr.Cells("ColChk").FormattedValue
                If Convert.ToBoolean(objValue) Then

                    Dim PartID = dgvr.Cells("PartID").Value
                    Dim Status = dgvr.Cells("Status").Value
                    Dim DrawingVer = dgvr.Cells("DrawingVer").Value

                    Dim CreateUserID = RunCardBusiness.GetUserID(dgvRunCardHeader.CurrentRow.Cells("UserID").Value.ToString())
                    Dim ModifyTime As Date
                    Dim ModifyUserID = RunCardBusiness.GetModifyUserID(PartID, ModifyTime)

                    If PartID.ToString().Substring(0, 1) = "9" Then
                        Dim o_strErpVer = RunCardBusiness.GetVerFromErp(PartID).ToUpper 'TT料号版本
                        If (Not String.IsNullOrEmpty(o_strErpVer)) AndAlso DrawingVer.ToUpper().Trim <> o_strErpVer.Trim Then
                            MessageUtils.ShowError(String.Format("流程卡['{0}']版本['{1}']跟ERP['{2}']不一致,找SAP确认！",
                                                        PartID, DrawingVer.ToUpper, o_strErpVer.ToUpper))
                            Exit Sub
                        End If
                    End If

                    If Convert.ToInt32(Status) <> 2 Then
                        MessageUtils.ShowError("非审核状态")
                        Exit Sub
                    End If

                    'cq 20170228
                    Dim Sql As String = RunCardBusiness.GetUpateRCardMAndSaveBOMSQL(Me.IsQueryOldVersion, PartID, DrawingVer)

                    'ecb17: 生产线前加工
                    '01: 铆端前加工,02:产线,03:成型,04:裁切前加工(仓库),5:生产线前加工 A05 半自动压接连接  
                    'First get every Partid sectionHours 
                    Dim o_dtSectionHours As DataTable = New DataTable()
                    o_dtSectionHours = RunCardBusiness.GetdtSectionHours(PartID)
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

                    Dim o_strSQL As StringBuilder = Nothing
                    'add by cq 20180619
                    o_strSQL = New StringBuilder
                    o_strSQL.AppendLine(" begin ")
                    Dim i_ECB03 As Integer = 0
                    If m_preHours > 0 Then
                        o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                        o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'01' ECB06 FROM DUAL) T2")
                        o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND T1.ECB06 = T2.ECB06)")
                        o_strSQL.Append(" WHEN MATCHED THEN")
                        o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & m_preHours & "'")
                        o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND ECB06='01'")
                        o_strSQL.Append("  WHEN NOT MATCHED THEN")
                        o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                        o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                        o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
                        o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                        o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                        o_strSQL.Append(" VALUES")
                        o_strSQL.Append("  ('" & PartID & "', 1, 1,0,'01',")
                        o_strSQL.Append("  'A00', 1, N'铆端前加工',0,'" & m_preHours & "',")
                        o_strSQL.Append("  '0', 0, 0,0,'N',")
                        o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                        o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
                        i_ECB03 = i_ECB03 + 1
                    Else
                        o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                        o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                        o_strSQL.Append("AND  ECB06='01' ;")
                    End If

                    If m_proHours > 0 Then
                        o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                        o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'02' ECB06 FROM DUAL) T2")
                        o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND T1.ECB06 = T2.ECB06)")
                        o_strSQL.Append(" WHEN MATCHED THEN")
                        o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & m_proHours & "'")
                        o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='02'")
                        o_strSQL.Append("  WHEN NOT MATCHED THEN")
                        o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                        o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                        o_strSQL.Append("ECB20, ECB21, ECB34, ECB38, ECB39,")
                        o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                        o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                        o_strSQL.Append(" VALUES")
                        o_strSQL.Append("  ('" & PartID & "', 1, 2,0,'02',")
                        o_strSQL.Append("  '0', 0,N'产线',0,'" & m_proHours & "',")
                        o_strSQL.Append("  '0', 0, 0,0,'N',")
                        o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                        o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0, SYSDATE);")
                        i_ECB03 = i_ECB03 + 1
                    Else
                        o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                        o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                        o_strSQL.Append("AND ECB06='02' ;")
                    End If

                    If m_ContourHours > 0 Then  '03
                        o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                        o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'03' ECB06 FROM DUAL) T2")
                        o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06)")
                        o_strSQL.Append(" WHEN MATCHED THEN")
                        o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & m_ContourHours & "'")
                        o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='03'")
                        o_strSQL.Append("  WHEN NOT MATCHED THEN")
                        o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                        o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                        o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
                        o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                        o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                        o_strSQL.Append(" VALUES")
                        o_strSQL.Append("  ('" & PartID & "', 1,3,0,'03',")
                        o_strSQL.Append("  '0', 0,N'成型',0,'" & m_ContourHours & "',")
                        o_strSQL.Append("  '0', 0, 0,0,'N',")
                        o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                        o_strSQL.Append("  'Y', SYSDATE, '0', 'MES',0,SYSDATE);")
                        i_ECB03 = i_ECB03 + 1
                    Else
                        'ecbud13     date,  /*变更日期 */
                        o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                        o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                        o_strSQL.Append("AND  ECB06='03' ;")
                    End If

                    If m_trimHours > 0 Then  '04
                        o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                        o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'04' ECB06 FROM DUAL) T2")
                        o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
                        o_strSQL.Append(" WHEN MATCHED THEN")
                        o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & m_trimHours & "'")
                        o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='04'")
                        o_strSQL.Append("  WHEN NOT MATCHED THEN")
                        o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                        o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                        o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
                        o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                        o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                        o_strSQL.Append(" VALUES")
                        o_strSQL.Append("  ('" & PartID & "', 1, 4,0,'04',")
                        o_strSQL.Append("  '0', 0,N'裁切前加工(仓库)',0,'" & m_trimHours & "',")
                        o_strSQL.Append("  '0', 0, 0,0,'N',")
                        o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                        o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
                        i_ECB03 = i_ECB03 + 1
                    Else
                        o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                        o_strSQL.Append("SET ECB19='" & m_trimHours & "' , ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                        o_strSQL.Append("AND  ECB06='04' ;")
                    End If
                    'ecb38    /*單位人力 */ （标准产量 ）
                    'ecb15     number(15,3),    /*标准标配人工數  */  ( 标准排配人数)
                    'ecb34    number(15,3),   /*工作时间(H) */  ( 工作时间H)
                    If m_autoHours > 0 Then  'A05
                        o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                        o_strSQL.Append("  USING (SELECT '" & PartID & "' ECB01,'A05' ECB06 FROM DUAL) T2")
                        o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
                        o_strSQL.Append(" WHEN MATCHED THEN")
                        o_strSQL.Append("  UPDATE SET T1.ECB19 = '" & m_autoHours & "'")
                        o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='A05'")
                        o_strSQL.Append("  WHEN NOT MATCHED THEN")
                        o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                        o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                        o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
                        o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                        o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                        o_strSQL.Append(" VALUES")
                        o_strSQL.Append("  ('" & PartID & "', 1, 15,0,'A05',")
                        o_strSQL.Append("  '0', 0,N'半自动压接连接',0,'" & m_autoHours & "',")
                        o_strSQL.Append("  '0', 0, 0,0,'N',")
                        o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                        o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
                    Else
                        o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                        o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                        o_strSQL.Append("AND  ECB06='A05' ;")
                    End If

                    o_strSQL.Append("  MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECU_FILE T1")
                    o_strSQL.Append("  USING (SELECT '" & PartID & "' ECU01 FROM DUAL) T2")
                    o_strSQL.Append(" ON (T1.ECU01 = T2.ECU01) ")
                    o_strSQL.Append("  WHEN  MATCHED THEN")
                    o_strSQL.Append("  UPDATE SET T1.ECUMODU = '" & ModifyUserID & "',T1.ECUDATE = TO_DATE('" & ModifyTime & "','YYYY-MM-DD HH24:MI:SS')")
                    o_strSQL.Append("    WHERE ECU01='" & PartID & "'")
                    o_strSQL.Append("  WHEN NOT MATCHED THEN")
                    o_strSQL.Append(" INSERT (ECU01, ECU02, ECU04, ECU05, ECUACTI, ")
                    o_strSQL.Append(" ECUUSER, ECUGRUP, ECUMODU, ECUDATE, ECU10, ")
                    o_strSQL.Append(" ECU11)")
                    o_strSQL.Append(" VALUES")
                    o_strSQL.Append("  ('" & PartID & "','1', 10, 30,'Y',")
                    o_strSQL.Append("  '" & CreateUserID & "','P17234','" & ModifyUserID & "',TO_DATE('" & ModifyTime & "','YYYY-MM-DD HH24:MI:SS'), ")
                    o_strSQL.Append(" 'Y', 0);")
                    o_strSQL.Append("COMMIT;")
                    o_strSQL.Append(" END;")
                    Dim o_IsQAS As Boolean = False

                    RCardComBusiness.ExecSQL(Sql, o_IsQAS)
                    'Add update std time to Erp, cq 20160401
                    System.Environment.SetEnvironmentVariable("NLS_LANG ", " SIMPLIFIED CHINESE_CHINA.ZHS16GBK")

                    If o_IsQAS Then 'Add QAS oracle conn, cq 20160504
                        RCardComBusiness.Oracle_ExecuteNonQuery_QAS(o_strSQL.ToString)
                    Else
                        RCardComBusiness.Oracle_ExecuteNonQuery(o_strSQL.ToString)
                    End If
                    num = num + 1
                End If
            Next
            If num = 0 Then
                MessageUtils.ShowError("请勾选一项")
                Exit Sub
            End If
            MessageUtils.ShowInformation("料件审核成功！")
            loadSideBar()
            LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
            LoadSideBarByClick("Desc", RunCardType.Finish)
        Catch ex As Exception
            MessageUtils.ShowError("审核流程卡失败" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region

#Region "刷新"
    ''' <summary>
    ''' 刷新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        loadSideBar()
        LoadRunCardHeader(False, "")
        LoadSideBarByClick("desc", RunCardType.Finish)
    End Sub
#End Region

#Region "导出单头"
    ''' <summary>
    ''' 导出单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportHeader_Click(sender As Object, e As EventArgs) Handles btnExportHeader.Click
        Dim strPath As String = ""
        Dim frmStation As New FrmRunCardImportStation("", "Export", Me.IsQueryOldVersion)
        frmStation.SelectExportPath("RunCard", strPath)

        Call DoExport(strPath)
    End Sub
#End Region

#Region "导出单头方法"
    ''' <summary>
    ''' 导出单头方法
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <remarks></remarks>
    Private Sub DoExport(ByVal strPath As String)
        Dim o_outputFile As String = ""
        Dim errorMsg As String = Nothing
        Dim filePath As String = ""
        Try

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardHeaderTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = strPath + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation("", "Export", Me.IsQueryOldVersion) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
            ' frmStation.runCardPn = Me.RunCardPn

            Using dt As DataTable = RunCardData  'RCardComBusiness.GetDataTable(frmStation.GetExportSql(Me.RunCardPN))
                '有导出单头工时权限就打印工时 add by 马跃平 2018-05-30
                If DbOperateUtils.GetDataTable("select * from dbo.m_UserRight_t " & vbCrLf &
"where UserID='" & MainFrame.SysCheckData.SysMessageClass.UseId & "' and Tkey='RCard2_22'").Rows.Count > 0 Then
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
#End Region

#Region "查看变更履历"
    ''' <summary>
    ''' 查看变更履历
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExportChangeLog_Click(sender As Object, e As EventArgs) Handles toolExportChangeLog.Click
        Dim frmlog As New FrmRCardLog
        frmlog.txtPartID.Text = dgvRunCardHeader.CurrentRow.Cells("PartID").Value.ToString()
        frmlog.ShowDialog()
    End Sub
#End Region

#Region "退出"
    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "删除流程卡单头"
    ''' <summary>
    ''' 删除流程卡单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderDelete_Click(sender As Object, e As EventArgs) Handles tsmiHeaderDelete.Click
        Try
            If dgvRunCardHeader.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选中一行数据")
                Exit Sub
            End If
            Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            If Not Convert.ToInt32(Status) = 0 Then
                MessageUtils.ShowError("料号:" + PartID + ",非制作中,不允许删除!")
                Exit Sub
            End If
            If MessageUtils.ShowConfirm("确认要删除选中的流程卡:" + PartID + "信息？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Dim sql = RunCardBusiness.DeleteHeader(Me.IsQueryOldVersion, PartID)
                DbOperateUtils.ExecSQL(sql)
                MessageUtils.ShowInformation("删除成功!")
                loadSideBar()
                LoadSideBarByClick("desc", RunCardType.UnFinish)
                LoadRunCardHeader(False, Me.strWhere)

            End If
        Catch ex As Exception
            MessageUtils.ShowError("删除出错:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "取消生效流程卡单头"
    ''' <summary>
    ''' 取消生效流程卡单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderCancel_Click(sender As Object, e As EventArgs) Handles tsmiHeaderCancel.Click
        Try
            If dgvRunCardHeader.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选中一行数据")
                Exit Sub
            End If
            Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            Dim DrawingVer = dgvRunCardHeader.CurrentRow.Cells("DrawingVer").Value
            Dim sql As String = String.Empty
            If Convert.ToInt32(Status) = 2 Then
                MessageUtils.ShowError(PartID + "该料件的流程卡还在审核中，不允许取消生效。")
                Exit Sub
            ElseIf Convert.ToInt32(Status) = 0 Then
                MessageUtils.ShowError(PartID + "该料件的流程卡还在制作中，不允许取消生效。")
                Exit Sub
            End If
            sql &= RunCardBusiness.GetSaveRejectStatusSQL(False, PartID)
            sql &= RunCardBusiness.GetRejectStatusDeleteLogSQL(PartID, DrawingVer)
            If MessageUtils.ShowConfirm("确认要取消生效选中的流程卡信息？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                RCardComBusiness.ExecSQL(sql)
                MessageUtils.ShowInformation("取消生效成功！")
                loadSideBar()
                LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
                LoadSideBarByClick("Desc", RunCardType.UnFinish)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("取消生效失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "流程卡单头导入"
    ''' <summary>
    ''' 流程卡单头导入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderImport_Click(sender As Object, e As EventArgs) Handles tsmiHeaderImport.Click
        Try
            If dgvRunCardHeader.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选中一行数据")
                Exit Sub
            End If
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            Dim frmStation As New FrmRunCardImportStation(PartID, "Import", True)
            frmStation.ShowDialog()
            LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
            LoadSideBarByClick("desc", RunCardType.UnFinish)
        Catch ex As Exception
            MessageUtils.ShowError("导入异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

    Private currentHeaderValue As String = ""


#Region "CheckStatusNotFinish"
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

#Region "CheckAll_CheckedChanged"
    Private Sub CheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAll.CheckedChanged
        Try
            'Add by cq20170518
            Me.dgvRunCardHeader.EndEdit()
            If Me.dgvRunCardHeader.Rows.Count <= 0 Then Exit Sub
            For i As Integer = 0 To Me.dgvRunCardHeader.RowCount - 1
                Me.dgvRunCardHeader.Rows(i).Cells(0).Value = CheckAll.Checked
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHSL", "m_ChkboxAll_CheckedChanged", "RCard")
        End Try
    End Sub
#End Region

#Region "双击流程卡单身需求属性"
    Private _CurrentRowIndex As Integer = 0
    Public Property CurrentRowIndex() As Integer
        Get
            Return _CurrentRowIndex
        End Get
        Set(ByVal value As Integer)
            _CurrentRowIndex = value
        End Set
    End Property

    Private _CurrentColumnIndex As Integer
    Public Property CurrentColumnIndex() As Integer
        Get
            Return _CurrentColumnIndex
        End Get
        Set(ByVal value As Integer)
            _CurrentColumnIndex = value
        End Set
    End Property

    Private _CurrentColumnName As String = ""
    Public Property CurrentColumnName() As String
        Get
            Return _CurrentColumnName
        End Get
        Set(ByVal value As String)
            _CurrentColumnName = value
        End Set
    End Property

    Private _CurrentStationID As String
    Public Property CurrentStationID() As String
        Get
            Return _CurrentStationID
        End Get
        Set(ByVal value As String)
            _CurrentStationID = value
        End Set
    End Property

    Private _OldEditValue As String
    Public Property OldEditValue() As String
        Get
            Return _OldEditValue
        End Get
        Set(ByVal value As String)
            _OldEditValue = value
        End Set
    End Property


#End Region

#Region "流程卡单身单元格双击事件"
    Private Sub dgvRunCardBody_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardBody.CellDoubleClick
        Dim columnName = dgvRunCardBody.Columns(e.ColumnIndex).Name
        Dim Status = dgvRunCardHeader.CurrentRow.Cells("Status").Value
        Dim IsReadOnly = True
        If Convert.ToInt32(Status) = 0 Then
            Select Case columnName
                Case "WorkingHours", "Equipment", "ProcessStandard", "BodyRemark"
                    IsReadOnly = False
                    CurrentColumnName = columnName
                    CurrentRowIndex = e.RowIndex
                    CurrentColumnIndex = e.ColumnIndex
                    CurrentStationID = dgvRunCardBody.CurrentRow.Cells("StationID").Value
                    If IsDBNull(dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False Then
                        OldEditValue = dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    End If
            End Select
        End If
        dgvRunCardBody.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = IsReadOnly
    End Sub
#End Region

#Region "流程卡单身单元中结束编辑事件"
    Private Sub dgvRunCardBody_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardBody.CellEndEdit
        Try
            Dim PartID = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
            Dim editValue = dgvRunCardBody.Rows(CurrentRowIndex).Cells(CurrentColumnIndex).Value
            editValue = IIf(IsDBNull(editValue), "", editValue)
            CurrentColumnName = IIf(CurrentColumnName = "BodyRemark", "Remark", CurrentColumnName)
            If editValue <> OldEditValue Then
                Dim strSQL As String = RunCardBusiness.GetBodyUpdateSQL(Me.IsQueryOldVersion, CurrentColumnName, editValue, PartID, CurrentStationID, OldEditValue, 0)
                RCardComBusiness.ExecSQL(strSQL)
                LoadRunCardBody()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "流程卡单身插入事件"
    ''' <summary>
    ''' 流程卡单身插入事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBodyInsert_Click(sender As Object, e As EventArgs) Handles tsmiBodyInsert.Click
        Dim i_MaxStationSQ As Integer = -1
        Try
            If IsNothing(Me.dgvRunCardBody.CurrentRow) Then Exit Sub
            Me.RunCardPN = dgvRunCardHeader.CurrentRow.Cells("PartID").Value
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

            'Dim frmEdit As New FrmRunCardBodyEdit("insert", Me.dgvRunCardBody.CurrentRow, Me.IsQueryOldVersion)
            'frmEdit.RCardType = "H"
            'frmEdit.RunCardPN = Me.RunCardPN
            'frmEdit.ShowDialog()
            '刷新
            LoadRunCardBody()
            If Me.RunCardStatus = 1 Then
                Me.RunCardStatus = 0
                LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
                LoadSideBarByClick("desc", RunCardType.UnFinish)
            End If
            If dgvRunCardBody.Rows.Count <> 0 Then
                dgvRunCardBody.FirstDisplayedScrollingRowIndex = dgvRunCardBody.Rows.Count - CInt(IIf(dgvRunCardBody.Rows.Count > 10, 10, 1))
            End If
        Catch ex As Exception
            MessageUtils.ShowError("操作异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "流程卡单身RowPostPaint事件"
    Private Sub dgvRunCardBody_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvRunCardBody.RowPostPaint
        Dim color = New System.Drawing.Color
        Dim SectionID = dgvRunCardBody.Rows(e.RowIndex).Cells("SectionID").Value
        Select Case SectionID.ToString()
            Case "1", "01" '前段加工
                color = System.Drawing.Color.LightGreen
            Case "2", "02" '产线
                color = System.Drawing.Color.Aqua
            Case "3", "03" '成型加工
                color = System.Drawing.Color.PeachPuff
            Case "4", "04"
                color = System.Drawing.Color.WhiteSmoke
            Case "5", "05"
                color = System.Drawing.Color.MistyRose
            Case "A05"
                color = System.Drawing.Color.Tomato
        End Select
        dgvRunCardBody.Rows(e.RowIndex).Cells("StationName").Style.BackColor = color
    End Sub
#End Region

#Region "料号单元格点击事件"
    Private Sub dgvPartNumber_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartNumber.CellClick
        If e.ColumnIndex = 0 Then
            Dim chkValue = dgvPartNumber.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue
            If Convert.ToBoolean(chkValue) Then
                dgvPartNumber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            Else
                dgvPartNumber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            End If
        End If
    End Sub
#End Region

#Region "流程卡单头单元格结束编辑事件"

    Private CurrentHeadRowIndex As Integer = 0

    Private CurrentHeadColumnIndex As Integer = 0

    Private CurrentHeadColumnName As String = ""

    Private CurrentHeadPartID As String = ""

    ''' <summary>
    ''' 流程卡单头单元格结束编辑事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRunCardHeader_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellEndEdit
        Try
            Dim columnValue = dgvRunCardHeader.Rows(CurrentHeadRowIndex).Cells(CurrentHeadColumnIndex).Value
            Dim sql = "update m_RCardM_t set " & CurrentHeadColumnName & " = '" & columnValue & "',ModifyTime=getdate() where PartID='" & CurrentHeadPartID & "'"
            DbOperateUtils.ExecSQL(sql)
            LoadRunCardHeader(Me.IsQueryOldVersion, strWhere)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "流程卡单身单元格离开事件"
    Private Sub dgvRunCardBody_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardBody.CellLeave
        dgvRunCardBody.EndEdit()
    End Sub
#End Region

#Region "流程卡单头单元格离开事件"
    Private Sub dgvRunCardHeader_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRunCardHeader.CellLeave
        dgvRunCardHeader.EndEdit()
    End Sub
#End Region

End Class