Imports System
Imports System.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports SysBasicClass
Imports MainFrame
''' <summary>
''' 更新者:田玉琳
''' 更新日期:20191014
''' 更新内容:工时获取修改,同步工时到SAP
''' </summary>
''' <remarks></remarks>

Public Class FrmShowRunCardDetail
    Private frmShowReport As FrmShowRunCard
    Private m_dtRunCardD As DataTable
    Private m_blnAllowUpload As Boolean = True
    Public m_IsSynTTSortTime As Boolean = False

    Private _dtOutTotalTime As DataTable
    Public Property dtOutTotalTime() As DataTable
        Get
            Return _dtOutTotalTime
        End Get

        Set(ByVal Value As DataTable)
            _dtOutTotalTime = Value
        End Set
    End Property

    Private Sub FrmShowRunCardDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        Me.ToolUpload.Enabled = IIf(RCardComBusiness.DBNullToStr(ToolUpload.Tag) = "YES", True, False)
        Me.toolExport.Enabled = IIf(RCardComBusiness.DBNullToStr(toolExport.Tag) = "YES", True, False)

        With Me.dgvRunCardDetail
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With

        txtPN.Select()
        cboReportType.Items.Clear()
        cboReportType.Items.Add("工艺流程卡")
        cboReportType.Items.Add("工艺流程卡明细表")
        cboReportType.Items.Add("产品总工时")
        cboReportType.Items.Insert(0, "")
        Me.lblInfo.Text = ""
        m_IsSynTTSortTime = IsSynTTSortTime()
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim o_strNotExistPartiDList As String = "", o_strNotFinishPartiDList As String = "", o_strFinishPartiDList  As String =""
        Dim o_stdPartID As DataTable = Nothing
        Me.lblInfo.Text = String.Empty
        Dim msg As String = String.Empty
        Try
            If Not IsNothing(Me.dgvRunCardDetail) Then
                Me.dgvRunCardDetail.DataSource = Nothing
            End If
            If Not CheckBasic() Then
                Exit Sub
            End If
            If txtPN.Text <> "" Then
                frmShowReport = New FrmShowRunCard(txtPN.Text)
            Else
                frmShowReport = New FrmShowRunCard(GetPnByMo())
            End If
            frmShowReport.reportInputParametersVar.showPrintButton = False

            If cboReportType.SelectedIndex >= 1 Then
                frmShowReport.reportInputParametersVar.reportTypeFlag = (cboReportType.SelectedIndex - 1)
            Else
                frmShowReport.reportInputParametersVar.reportTypeFlag = 0
            End If
            ' IIf(cboReportType.SelectedItem = "工艺流程卡明细表", FrmShowRunCard.ReportType.RunCardDetailReport, FrmShowRunCard.ReportType.RunCardReport)

            frmShowReport.reportInputParametersVar.printTypeFlag = FrmShowRunCard.PrintType.ShowReport
            frmShowReport.reportInputParametersVar.showExportButton = True

            Select Case frmShowReport.reportInputParametersVar.reportTypeFlag
                Case FrmShowRunCard.ReportType.RunCardDetailReport
                    If DownloadBom(txtPN.Text, msg) = False Then
                        Me.lblInfo.Text = msg
                        Exit Sub
                    End If
                Case Else
                    'do nothing
            End Select

            'If frmShowReport.reportInputParametersVar.reportTypeFlag = FrmShowRunCard.ReportType.RunCardDetailReport Then
            Select Case frmShowReport.reportInputParametersVar.reportTypeFlag
                Case FrmShowRunCard.ReportType.RunCardDetailReport
                    Using dt As DataTable = frmShowReport.GetRunCardDetailListDataTable()
                        'First check 是否已经制作完成
                        If ExistUnfinishRCard(txtPN.Text) Then
                            MessageUtils.ShowInformation("该料件下面子件料的流程卡的状态必须为已完成,请检查！！")
                            m_blnAllowUpload = False
                            Exit Sub
                        End If

                        If dt.Rows.Count <= 1 Then
                            MessageUtils.ShowInformation("该料件下面没有要显示的子件料,请确认输入的是成套的料件编号或是成套的工单编号！！")
                            m_blnAllowUpload = False
                            Exit Sub
                        End If

                        'Modify by cq 20170630, Add check special such as "060-2A0000-005R"
                        Me.GetChildPNCount(dt, o_stdPartID)
                        o_strNotExistPartiDList = GetNotExistPartIDList(dt, o_stdPartID)
                        If Not String.IsNullOrEmpty(o_strNotExistPartiDList) Then
                            MessageUtils.ShowInformation("该料件下面有子件料[" & o_strNotExistPartiDList & "]未完成,请检查！！")
                            Me.lblInfo.Text = "该料件下面有子件料[" & o_strNotExistPartiDList & "]未完成,请检查！！"
                            m_blnAllowUpload = False
                            Exit Sub
                        End If

                        'Fix issue, add if condition 20170705
                        If String.IsNullOrEmpty(dt.Rows(dt.Rows.Count - 1).Item("ID")) Then
                            dt.Rows.RemoveAt(dt.Rows.Count - 1)
                        End If
                        GetRunCardDetailListParameters(dt)
                        Using dtResult As DataTable = ChangeDataTableStyle(dt)
                            dgvRunCardDetail.DataSource = dtResult
                            m_dtRunCardD = dtResult
                        End Using

                        dgvRunCardDetail.ColumnHeadersVisible = False
                        dgvRunCardDetail.Columns(RunCardDetailGrid.ID).Width = 60
                        dgvRunCardDetail.Columns(RunCardDetailGrid.Version).Width = 140
                        dgvRunCardDetail.Columns(RunCardDetailGrid.Qty).Width = 140
                        dgvRunCardDetail.Columns(RunCardDetailGrid.ContourHourPreMo).Width = 170
                        dgvRunCardDetail.Columns(RunCardDetailGrid.Pn).Width = 140
                        dgvRunCardDetail.Rows(2).DefaultCellStyle = style
                        dgvRunCardDetail.Columns(0).DefaultCellStyle = style
                        TabControl1.SelectedIndex = 1
                    End Using
                Case FrmShowRunCard.ReportType.RunCardReport
                    Using dt As DataTable = frmShowReport.GetRunCardDataTable()
                        If dt.Rows.Count <= 1 Then
                            MessageUtils.ShowInformation("该料件还没有维护工艺流程卡,请先维护工艺流程卡！！或输入的是成套料件或成套工单,请确认！！")
                            Exit Sub
                        End If
                        dt.Rows.RemoveAt(dt.Rows.Count - 1)
                        GetRunCardReportParameters(dt)
                        Using dtResult As DataTable = ChangeRunCardDataTableStyle(dt)
                            dgvRunCard.DataSource = dtResult
                        End Using
                        dgvRunCard.ColumnHeadersVisible = False
                        dgvRunCard.Columns(RunCardStyleGrid.ID).Width = 60
                        dgvRunCard.Columns(RunCardStyleGrid.WorkStationContent).Width = 130
                        dgvRunCard.Columns(RunCardStyleGrid.WorkHour).Width = 60
                        dgvRunCard.Columns(RunCardStyleGrid.Equipment).Width = 120
                        dgvRunCard.Columns(RunCardStyleGrid.ProcessStandard).Width = 250
                        dgvRunCard.Columns(RunCardStyleGrid.Remark).Width = 200
                        dgvRunCard.Columns(RunCardStyleGrid.RawInfo).Width = 200
                        dgvRunCard.Columns(RunCardStyleGrid.EquipmentInfo).Width = 200
                        TabControl1.SelectedIndex = 0
                        dgvRunCard.Rows(2).DefaultCellStyle = style
                        dgvRunCard.Rows(dgvRunCard.Rows.Count - 2).DefaultCellStyle = style
                        dgvRunCard.Columns(0).DefaultCellStyle = style
                    End Using
                Case FrmShowRunCard.ReportType.StdTimeReport

                    For Each strTmpPN As String In txtPN.Text.Trim.Split(";")
                        If ExistUnfinishRCard(strTmpPN) Then
                            ' MessageUtils.ShowInformation("该料件下面子件料的流程卡的状态必须为已完成,请检查！！")
                            ' Exit Sub
                            o_strNotFinishPartiDList &= strTmpPN + ";"
                        Else
                            o_strFinishPartiDList &= strTmpPN + ";"
                        End If
                    Next

                    o_strNotFinishPartiDList = o_strNotFinishPartiDList.TrimEnd(";")
                    If Not String.IsNullOrEmpty(o_strNotFinishPartiDList) Then
                        MessageUtils.ShowInformation("该料件下面子件料[" + o_strNotFinishPartiDList + "]的流程卡的状态必须为已完成,请检查！！")
                    End If

                    o_strFinishPartiDList = o_strFinishPartiDList.TrimEnd(";")
                    Using dt As DataTable = frmShowReport.GetRunCardDataTable_StdTime(o_strFinishPartiDList)

                        'For Each strTmpPN As String In txtPN.Text.Trim.Split(";")
                        '    If ExistUnfinishRCard(strTmpPN) Then
                        '        MessageUtils.ShowInformation("该料件下面子件料的流程卡的状态必须为已完成,请检查！！")
                        '        'm_blnAllowUpload = False
                        '        Exit Sub
                        '    End If
                        'Next

                        _dtOutTotalTime = dt

                        Using dtResult As DataTable = ChangeRunCardDataTableStyle_StdTime(dt)
                            dgvTotalStdTime.DataSource = dtResult

                        End Using
                        dgvTotalStdTime.ColumnHeadersVisible = False
                        dgvTotalStdTime.Columns(StdTieStyleGrid.PartNumber).Width = 260
                        dgvTotalStdTime.Columns(StdTieStyleGrid.TotalTime).Width = 130
                        TabControl1.SelectedIndex = 2
                        dgvTotalStdTime.Columns(0).DefaultCellStyle = style
                    End Using

            End Select

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "ToolReflsh_Click", "RCard")
        End Try
    End Sub

#Region "下载BOM"
    Private Function NeedDownLoadBOM(ByVal PartID As String) As Boolean
        Dim str As String = String.Empty
        str = " SELECT 1 FROM m_RCardM_t WHERE PartID   LIKE '" & PartID & "%'" & _
              " AND PARTID NOT IN (SELECT TAvcPart FROM m_PartContrast_t WHERE TAvcPart LIKE '" & PartID & "%'" & _
              " AND TAvcPart <> PAvcPart)  "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(str)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                NeedDownLoadBOM = True
            Else
                NeedDownLoadBOM = False
            End If
            Return NeedDownLoadBOM
        End Using
    End Function

    ' cq 20160824, label download pn , have error
    Private Function NeedUpdateBOM(ByVal PartID As String) As Boolean
        Dim str As String = String.Empty
        str = " SELECT Amountqty FROM m_PartContrast_t WHERE PAvcPart = '" & PartID & "'" & _
              " AND TAvcPart <> PAvcPart and TAvcPart LIKE '9%' AND (Amountqty is null or Amountqty<=0) "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(str)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                NeedUpdateBOM = True
            Else
                NeedUpdateBOM = False
            End If
            Return NeedUpdateBOM
        End Using
    End Function

    Private Function DownloadBom(ByVal pn As String, ByRef msg As String, Optional ByVal HasUI As Boolean = False) As Boolean
        Dim strCustID As String = "", strSeriesID As String = ""
        Try
            Dim strSQL As String
            Dim dt As DataTable

            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                strSQL = SapCommon.GetErpFilterSqlSap(pn)
                dt = OracleOperateUtils.GetDataTableSap(strSQL)
            Else
                'A. First Download PN from ERP,Add by CQ 20151116
                strSQL = SapCommon.GetErpFilterSql(pn)
                dt = OracleOperateUtils.GetDataTable(strSQL)
            End If

            If dt.Rows.Count <= 0 Then
                msg = "ERP 中找不到料件""" & pn & """ 信息"
                Return False
            Else
                'As is: Get CustID from MES first, if not get, then get from UI 
                'Now: first get from MES  , cq 
                strCustID = RunCardBusiness.GetCustIDFromMES(pn)
                If String.IsNullOrEmpty(strCustID) Then
                    strCustID = "99"
                Else
                    'do nothing
                End If

                'Get Serial from TT first, if not get, then get from UI
                'Now: first get from MES  , cq 2016/06/14
                strSeriesID = RunCardBusiness.GetSerialIDFromMES(pn)
                If String.IsNullOrEmpty(strSeriesID) Then
                    strSeriesID = "018"
                Else
                    'do nothing
                End If

                dt.Columns.Add("CustID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("CustID") = strCustID
                Next

                dt.Columns.Add("SeriesID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("SeriesID") = strSeriesID
                Next
                RunCardBusiness.SaveErpSetPNData(dt)
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "DownloadBom", "RCard")
            ' Throw ex
            Return False
        End Try
    End Function

#End Region


    ''' <summary>
    ''' 华为成套料号是否开启同步配套工时
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsSynTTSortTime() As Boolean
        Dim Sqlstr As String = "select PARAMETER_VALUES from m_SystemSetting_t where  PARAMETER_CODE='IsSynTTSortTime' and PARAMETER_VALUES=1 "
        Return DbOperateUtils.GetRowsCount(Sqlstr) > 0
    End Function

    Private Function ExistUnfinishRCard(ByVal strPartID As String) As Boolean
        Dim str As String = String.Empty
        'str = "SELECT STATUS,PartID  FROM m_RCardM_t WHERE partid LIKE '%" & strPartID & "%'  AND STATUS IN(0)  "
        str = " SELECT STATUS,PartID  FROM m_RCardM_t " &
              " WHERE partid IN (SELECT tavcpart FROM m_PartContrast_t WHERE PAvcPart = '{0}')" &
                RCardComBusiness.GetFatoryProfitcenter() &
              " AND STATUS IN(0)  "
        str = String.Format(str, strPartID)
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(str)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ExistUnfinishRCard = True
            Else
                ExistUnfinishRCard = False
            End If
            Return ExistUnfinishRCard
        End Using
    End Function

    'cq 20160812
    Private Function GetChildPNCount(ByVal dtReal As DataTable, ByRef o_stdPartID As DataTable) As Integer
        Dim strSQL As String = String.Empty
        strSQL = " select Tavcpart from dbo.fun_getRCardStdPartID('" & Me.txtPN.Text.Trim & "')"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNCount = o_dt.Rows.Count
                o_stdPartID = o_dt
            Else
                GetChildPNCount = 0
            End If
            Return GetChildPNCount
        End Using
    End Function

    Private Function GetNotExistPartIDList(ByVal dtReal As DataTable, ByVal o_stdPartID As DataTable) As String
        GetNotExistPartIDList = ""
        Try
            dtReal.Rows.RemoveAt(dtReal.Rows.Count - 1)
            '找出那个料件是没有制作
            For Each dr As DataRow In o_stdPartID.Rows
                If dtReal.Select("PN = '" & dr.Item(0) & "'").Length <= 0 Then
                    GetNotExistPartIDList &= dr.Item(0) & ","
                End If
            Next

            'add by cq 20190311, check eg: 904012831下面的子件没做904046791-A
            For Each dr As DataRow In dtReal.Rows
                If dr.Item("TotalHourPreChild") = 0 Then
                    GetNotExistPartIDList &= dr.Item("PN") & ","
                End If
            Next

            'Dim dt = MainFrame.DbOperateUtils.GetDataTable("SELECT partid,Status FROM dbo.getRCardChildList('" & txtPn.Text.Trim() & "')")
            'Dim dr() As DataRow = dt.Select("Status<>1 ")
            'For Each tempDr As DataRow In dt.Rows
            '    GetNotExistPartIDList &= tempDr.Item(0) & ","
            'Next

            If Not String.IsNullOrEmpty(GetNotExistPartIDList) Then
                GetNotExistPartIDList = GetNotExistPartIDList.Substring(0, GetNotExistPartIDList.Length - 1)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "GetNotExistPartIDList", "RCard")
        End Try
    End Function

    Private Function GetMOIDByPN() As String
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT MOID FROM m_MainMO_t where  partid ='" & Me.txtPN.Text.Trim & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetMOIDByPN = o_dt.Rows(0).Item(0)
            Else
                GetMOIDByPN = ""
            End If
        End Using
    End Function

    Public Function CheckBasic(Optional ByVal isUpload As Boolean = False) As Boolean
        If txtPN.Text = "" Then
            MessageBox.Show("请输入料件编号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboReportType.SelectedItem = "" Then
            MessageBox.Show("请选择报表类型", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If isUpload Then
            If CStr(cboReportType.SelectedItem) <> "工艺流程卡明细表" Then
                MessageBox.Show("请选择报表类型为:工艺流程卡明细表", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
        Return True
    End Function

    Public Function GetPnByMo() As String
        Dim sqlString As String = "SELECT PARTID FROM m_Mainmo_t WHERE MOID='" & txtMoNo.Text & "'AND STATUS<>2"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sqlString)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                MessageBox.Show("工单编号不存在或是已分批结案，请确认！！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
        Return ""
    End Function

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Assort As String = Nothing
    Private TotalHourPreMo As String = Nothing
    Private QTY As String = Nothing
    Private TotalHourPreMoSum As String = Nothing

    Private PreAssemblyHourPreChildSum As String = String.Empty     '铆端（01）
    Private MadeHourPreChildSum As String = String.Empty            '产线（02）
    Private ContourHourPreChildSum As String = String.Empty         '成型（03）
    Private m_CutProPreChildSum As String = String.Empty            '裁切（04）
    Private m_SemiAutoPREChildSum As String = String.Empty          '半自动压接（A05）

    Private PreAssemblyHourPreChildSum2 As String = String.Empty    '铆端（01）
    Private MadeHourPreChildSum2 As String = String.Empty           '产线（02）
    Private ContourHourPreChildSum2 As String = String.Empty        '成型（03）
    Private m_CutProPreChildSum2 As String = String.Empty           '裁切（04）
    Private m_SemiAutoPREChildSum2 As String = String.Empty         '半自动压接（A05）

    Private Version As String = Nothing

    'm_ProPrePREChildSum = CStr(dt.Compute("sum(ProPrePREChild)", "")) '生产线前加工,cq remove 20160328
    Private Sub GetRunCardDetailListParameters(ByVal dt As DataTable)
        'Version = RunCardBusiness.GetVerFromErp(txtPn.Text) 'cq 20160506
        If dt.Rows.Count > 0 Then
            Assort = CStr(CDbl(dt.Compute("sum(QTY)", "").ToString) * RunCardBusiness.GetAssortMultiple()) '15
            TotalHourPreMoSum = dt.Compute("sum(TOTALHOURPRECHILD)", "")   'dt.Compute("sum(TOTALHOURPRECHILD)", "") + 28 + dt.Compute("sum(QTY)", "") * 15
            '铆端前加工/产线/成型/裁切前加工/生产线前加工/半自动压接连接
            '子件总工时	/裁切（04）	/铆端（01）/	半自动压接（A05）/	成型（03）/	产线（02）
            PreAssemblyHourPreChildSum = CStr(dt.Compute("sum(PreAssemblyHourPreChild)", ""))
            ContourHourPreChildSum = dt.Compute("sum(ContourHourPreChild)", "")
            MadeHourPreChildSum = CStr(dt.Compute("sum(MadeHourPreChild)", ""))
            m_CutProPreChildSum = CStr(dt.Compute("sum(CutProPreChild)", "")) '裁切前加工
            m_SemiAutoPREChildSum = CStr(dt.Compute("sum(SemiAutoPREChild)", "")) '半自动压接

            'Dim dr() As DataRow = dt
            PreAssemblyHourPreChildSum2 = 0
            ContourHourPreChildSum2 = 0
            MadeHourPreChildSum2 = 0
            m_CutProPreChildSum2 = 0
            m_SemiAutoPREChildSum2 = 0

            For rowindex As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(rowindex)("Remark") = "" Then
                    PreAssemblyHourPreChildSum2 = PreAssemblyHourPreChildSum2 + Convert.ToDecimal(dt.Rows(rowindex)("PreAssemblyHourPreChild"))
                    ContourHourPreChildSum2 = ContourHourPreChildSum2 + Convert.ToDecimal(dt.Rows(rowindex)("ContourHourPreChild"))
                    MadeHourPreChildSum2 = MadeHourPreChildSum2 + Convert.ToDecimal(dt.Rows(rowindex)("MadeHourPreChild"))
                    m_CutProPreChildSum2 = m_CutProPreChildSum2 + Convert.ToDecimal(dt.Rows(rowindex)("CutProPreChild"))
                    m_SemiAutoPREChildSum2 = m_SemiAutoPREChildSum2 + Convert.ToDecimal(dt.Rows(rowindex)("SemiAutoPREChild"))
                End If
            Next

        Else
            Assort = CStr(0)
            TotalHourPreMoSum = ""
            PreAssemblyHourPreChildSum = ""
            ContourHourPreChildSum = ""
            MadeHourPreChildSum = ""
        End If
    End Sub

    Private Function GetPnVersion(ByVal rpn As String) As String
        Dim sql As String = "SELECT ISNULL(A.DESCRIPTION,'') FROM m_PartContrast_t A,m_PartContrast_t B WHERE B.TAvcPart='" & rpn & "' AND B.PAvcPart=A.TAvcPart"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return GetVersion(dt.Rows(0)(0))
            End If
        End Using
        Return ""
    End Function

    Private Function GetVersion(ByVal format As String) As String
        Dim arr() As String
        arr = format.Split("-")
        If arr.Length > 1 Then 'AndAlso Not reg.IsMatch(arr(arr.Length - 1)) And reg1.IsMatch(arr(arr.Length - 1)) Then
            Return arr(arr.Length - 1)
        End If
        Return ""
    End Function

    Private Function ChangeDataTableStyle_StdTime(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable   
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = "产品料号"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "总工时"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Pn)
            Next
            Return dt
        End Using
    End Function


    Private Function ChangeDataTableStyle(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To RunCardDetailGrid.Remark
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next
            '铆端前加工,产线加工,成型加工,裁切前加工,生产线前加工,半自动压接连接
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "工单量:" + ""
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "产品图号:" + txtPN.Text
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "工单号:" + ""

            If String.IsNullOrEmpty(Version) Then
                Version = RunCardBusiness.GetVerFromErp(txtPN.Text.Trim)
            End If
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "版次:" + Version 'AssemblyHourPreMo
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = "ID"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = "子件"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "子件版本"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "配置"
            ' PreAssemblyHourPreMo 01/MadeHourPreMo 02/ ContourHourPreMo 03/ CutProPREMO 04/ ProPrePREMO/ SemiAutoPREMO A05
            '  裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）, cq 20160325
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "子件总工时"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = "裁切(04)" 'cq 20160105
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "铆端(01)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = "半自动压接(A05)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "成型(03)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = "产线(02)"
            'dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ProPrePREMO) = "子件生产线前加工"

            'dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = "备注项"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = "不展开独立派工"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Pn)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Version)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Qty)
                '  裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）, cq 20160328
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.TotalHourPreChild)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.CutProPREMO)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.PreAssemblyHourPreMo) '6, Modify by cq 20160105
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.SemiAutoPREMO) 'Add by cq 20160105
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ContourHourPreMo)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.MadeHourPreMo)
                ' dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ProPrePREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ProPrePREMO)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Remark + 5)
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "贴标签:"  'Qty, cq 20160331
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "3" ' Qty==>TotalHourPreChild ,cq20170512
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "入/封胶袋(配套):"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = Assort
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "终检:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "10"
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "包装:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "15"

            'Add by cq 20160331
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "配套工时:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = CStr(Val(Assort) + 28) ' Qty==>TotalHourPreChild ,cq20170512


            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "汇总(不含独立派工):"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = m_CutProPreChildSum2
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = PreAssemblyHourPreChildSum2
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = m_SemiAutoPREChildSum2
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = ContourHourPreChildSum2
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = MadeHourPreChildSum2

            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "汇总:"
            '总计/ CutProPREMO/PreAssemblyHourPreMo/SemiAutoPREMO/ContourHourPreMo/MadeHourPreMo/ 
            ' 子件总工时/裁切（04）/铆端（01）/半自动压接（A05）/成型(03)/产线（02）
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = Val(TotalHourPreMoSum) + Val(Assort) + 28 'cq20170512 + 配套工时
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = m_CutProPreChildSum  'cq 20160105
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = PreAssemblyHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = m_SemiAutoPREChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = ContourHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = MadeHourPreChildSum

            Return dt
        End Using
    End Function

    Private Enum RunCardDetailGrid
        ID = 0
        Pn ' 1
        Version
        Qty
        TotalHourPreChild
        PreAssemblyHourPreMo '01
        MadeHourPreMo '02
        ContourHourPreMo '03
        CutProPREMO  '04
        SemiAutoPREMO 'A05
        Remark
        '铆端前加工= rivet point/产线加工/成型加工contour/裁切前加工/生产线前加工/半自动压接连接' 裁切（04）/铆端（01） rivet/半自动压接（A05）Semi-Auto/成型（03）/产线（02）
    End Enum

    Private RunCardGraphPar As String = Nothing
    Private RunCardVersionPar As String = Nothing
    Private RunCardShapePar As String = Nothing
    Private RunCardTotalHourPar As String = Nothing
    Private RunCardPreAssemblyPar As String = Nothing
    Private RunCardAssemblyPar As String = Nothing
    Private RunCardDescriptionPar As String = Nothing
    Private RunCardDescription1Par As String = Nothing
    Private RunCardStatusPar As String = Nothing
    Private RunCardCreateUserPar As String = Nothing
    Private RunCardCreateDatePar As String = Nothing
    Private RunCardApprovalPar As String = Nothing
    Private RunCardCheckPar As String = Nothing
    Private RunCardMadePar As String = Nothing

    Private Sub GetRunCardReportParameters(ByVal dt As DataTable)
        If dt.Rows.Count > 1 Then
            '图号

            RunCardGraphPar = txtPN.Text
            '版本
            RunCardVersionPar = dt.Rows(0)(RunCardEnum.DrawingVer).ToString()
            '形态
            RunCardShapePar = dt.Rows(0)(RunCardEnum.Shape).ToString()
            '总工时
            RunCardTotalHourPar = CStr(Convert.ToDouble(dt.Compute("sum(LaborHour)", "")) * (1 + 0.005 * (dt.Rows.Count)))
            '前加工
            If dt.Select("SECTIONNAME = 1").Length > 0 Then
                RunCardPreAssemblyPar = CStr(dt.Compute("sum(LaborHour)", "SECTIONNAME = 1"))
            Else
                RunCardPreAssemblyPar = CStr(dt.Compute("sum(LaborHour)", ""))
            End If
            '成型
            If dt.Select("SECTIONNAME = 3").Length > 0 Then
                RunCardAssemblyPar = CStr(dt.Compute("sum(LaborHour)", "SECTIONNAME = 3"))
            Else
                RunCardAssemblyPar = ""
            End If
            '描述
            RunCardDescriptionPar = dt.Rows(0)(RunCardEnum.Description).ToString
            '规格 
            RunCardDescription1Par = dt.Rows(0)(RunCardEnum.Description1).ToString
            '状态
            RunCardStatusPar = CStr(IIf(dt.Rows(0)(RunCardEnum.Status).ToString = "0", "制作中", IIf(dt.Rows(0)(RunCardEnum.Status).ToString = "1", "已生效", "待审核")))
            '创建人
            RunCardCreateUserPar = dt.Rows(0)(RunCardEnum.UserId).ToString
            '创建日期
            RunCardCreateDatePar = dt.Rows(0)(RunCardEnum.Intime).ToString
        Else
            '图号
            RunCardGraphPar = ""
            '版本
            RunCardVersionPar = ""
            '形态
            RunCardShapePar = ""
            '总工时
            RunCardTotalHourPar = ""
            '前加工
            RunCardPreAssemblyPar = ""
            '成型
            RunCardAssemblyPar = ""
            '描述
            RunCardDescriptionPar = ""
            '规格
            RunCardDescription1Par = ""
            '状态
            RunCardStatusPar = ""
            '创建人
            RunCardCreateUserPar = ""
            '创建日期
            RunCardCreateDatePar = ""
        End If
        '核准
        RunCardApprovalPar = ""
        '审核
        RunCardCheckPar = ""
        '制作
        RunCardMadePar = ""
    End Sub

    Private Enum RunCardEnum
        DrawingNo = 0
        DrawingVer
        Shape
        ID
        WorkStationContent
        LaborHour
        Equipment
        ProcessStandard
        Comment
        Operater
        IPQC
        SectionName
        Description1
        Description
        Status
        UserId
        Intime
        DID
        RawInfo
        EquipmentInfo
    End Enum

    Private Enum RunCardStyleGrid
        ID = 0
        WorkStationContent
        WorkHour
        Equipment
        ProcessStandard
        Remark
        RawInfo
        EquipmentInfo
    End Enum
    Private Enum StdTieStyleGrid
        PartNumber = 0
        TotalTime
    End Enum
    ''' <summary>
    ''' 单个流程卡显示
    ''' </summary>
    ''' <param name="dtRaw"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChangeRunCardDataTableStyle(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To RunCardStyleGrid.EquipmentInfo
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "图号:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = txtPN.Text
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "形态:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = RunCardShapePar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "描述:" + RunCardDescriptionPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "创建人"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = RunCardCreateUserPar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "版本:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = RunCardVersionPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "规格:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = RunCardDescription1Par
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "状态:" + RunCardStatusPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "创建时间"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = RunCardCreateDatePar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "序号"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = "工站内容"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = "工时(s)"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "设备/治具"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "工艺标准"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "备注"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "物料信息"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = "工装信息"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = dtRaw.Rows(rowIndex)(RunCardEnum.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = dtRaw.Rows(rowIndex)(RunCardEnum.WorkStationContent)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = dtRaw.Rows(rowIndex)(RunCardEnum.LaborHour)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = dtRaw.Rows(rowIndex)(RunCardEnum.Equipment)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = dtRaw.Rows(rowIndex)(RunCardEnum.ProcessStandard)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = dtRaw.Rows(rowIndex)(RunCardEnum.Comment)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = dtRaw.Rows(rowIndex)(RunCardEnum.RawInfo)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = dtRaw.Rows(rowIndex)(RunCardEnum.EquipmentInfo)
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = "总工时(s):"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = RunCardTotalHourPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "前加工(s):" + RunCardPreAssemblyPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "成型(s):" + RunCardAssemblyPar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "核准:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = RunCardApprovalPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "审核:" + RunCardCheckPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "制作:" + RunCardMadePar
            Return dt
        End Using
    End Function


    Private Function ChangeRunCardDataTableStyle_StdTime(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To StdTieStyleGrid.TotalTime
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next

            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(StdTieStyleGrid.PartNumber) = "产品料号"
            dt.Rows(dt.Rows.Count - 1)(StdTieStyleGrid.TotalTime) = "总工时"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(StdTieStyleGrid.PartNumber) = dtRaw.Rows(rowIndex)(0)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = dtRaw.Rows(rowIndex)(1)
            Next

            Return dt
        End Using
    End Function

    Private style As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 10.5, FontStyle.Bold), .Alignment = DataGridViewContentAlignment.MiddleCenter}

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Not IsNothing(m_dtRunCardD) AndAlso m_dtRunCardD.Rows.Count > 0 Then
            PrintRunCardDetail("")
        Else
            MessageUtils.ShowError("请先查询出流程卡明细信息！")
            Exit Sub
        End If
    End Sub

    Private Sub PrintRunCardDetail(Optional ByVal pn As String = "")
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Dim filePath As String = String.Empty
        Dim o_tempTiptopVersion As String = String.Empty
        Try
            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardDListTemplateNew.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = Environment.CurrentDirectory + "\" & Me.txtPN.Text & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(Me.txtPN.Text, "Export", False) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
            ' frmStation.runCardPn = Me.RunCardPn
            Dim dtRCardDCopy As DataTable = m_dtRunCardD.Copy()

            'Check vesion, cq20160506
            '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
            'If Me.txtPn.Text.Trim.StartsWith("9") Then
            '    'Check Version
            '    o_tempTiptopVersion = RunCardBusiness.GetVerFromTiptop(Me.txtPn.Text.Trim)
            '    If GetRCardVersion(Me.txtPn.Text.Trim) <> o_tempTiptopVersion Then
            '        Me.lblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
            '        Exit Sub
            '    End If
            'End If

            If dtRCardDCopy.Rows.Count >= 4 Then
                For i As Integer = 0 To 4
                    dtRCardDCopy.Rows.RemoveAt(0)
                    i = i + 1
                Next
            End If

            'add if by cq 20190614
            If m_IsSynTTSortTime = True Then
                'Auto update the std time to Tiptop
                Call AutoUploadTimeToTiptop()
            End If

            Using o_dt As DataTable = dtRCardDCopy
                If o_dt.Rows.Count > 0 Then
                    o_dt.TableName = "RunCard"
                    If RunCardBusiness.Import2ExcelRCardList(filePath, o_outputFile, o_dt, frmStation.GetRCardListVariable(o_dt, Me.txtPN.Text.Trim), Me.txtPN.Text.Trim, errorMsg) Then  'frmStation.GetVariables(dt)
                        Using frmshow As New FrmShowRunCard()
                            frmshow.m_iDirection = 1  '
                            frmshow.filePath = o_outputFile
                            frmshow.ShowDialog()
                        End Using
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的流程卡明细信息！")
                End If
            End Using

        Catch ex As Exception
            ' PrintRunCardDetail()
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "PrintRunCardDetail", "RCard")
            Throw ex
        Finally
            If File.Exists(o_outputFile) Then
                File.Delete(o_outputFile)
            End If
        End Try
    End Sub

    Private Function GetRCardVersion(ByVal PartID As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = "SELECT TOP 1 DrawingVer FROM m_RCardM_t WHERE partid  LIKE '" & PartID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetRCardVersion = o_dt.Rows(0).Item(0).ToString
            Else
                GetRCardVersion = ""
            End If
        End Using
    End Function

    Private Sub ToolUpload_Click(sender As Object, e As EventArgs) Handles ToolUpload.Click
        Dim o_strSQL As StringBuilder = Nothing
        Dim PartID As String = Me.txtPN.Text.Trim
        Dim o_CreateUserID As String = VbCommClass.VbCommClass.UseId
        Dim o_ModifyUserID As String = VbCommClass.VbCommClass.UseId
        If Not CheckBasic(True) Then
            Exit Sub
        End If
        If Me.dgvRunCardDetail.Rows.Count <= 0 Then
            MessageUtils.ShowError("请先点击查询！")
            Exit Sub
        End If

        'Mark by cq 20160627
        'If Not m_blnAllowUpload Then
        '    MessageUtils.ShowError("请先检查是否所有子件制作完成！")
        '    Exit Sub
        'End If

        If ExistUnfinishRCard(txtPN.Text) Then
            MessageUtils.ShowInformation("该料件下面子件料的流程卡的状态必须为已完成,请检查！！")
            m_blnAllowUpload = False
            Exit Sub
        End If

        Try
            'add if by cq 20180301, hjb 要求9开头的 Substring(1, 4) = "0409") OrElse PartID.Substring(1, 4) = "0401"
            If PartID.Trim.StartsWith("9") Then
                AutoUploadTimeToTiptop()

                MessageUtils.ShowInformation("同步工时到ERP成功！")
            Else
                MessageUtils.ShowWarning("非9开头料号不允许同步工时!")
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "ToolUpload_Click", "RCard")
            Throw ex
        Finally
        End Try
    End Sub


    ''' <summary>
    ''' 自动上传工时
    ''' 20191012 田玉琳 更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AutoUploadTimeToTiptop()
        Dim o_strSQL As StringBuilder = Nothing
        Dim o_strSQLMes As StringBuilder = Nothing
        Dim PartID As String = Me.txtPN.Text.Trim
        Try
            If PartID.Trim.StartsWith("9") Then
                o_strSQL = New StringBuilder
                o_strSQLMes = New StringBuilder

                o_strSQL.Append("BEGIN")

                SapCommon.syncTTTimeSap(PartID, "1", "01", "铆端前加工", PreAssemblyHourPreChildSum2, o_strSQL)
                SapCommon.syncTTTimeSap(PartID, "2", "02", "产线", MadeHourPreChildSum2, o_strSQL)
                SapCommon.syncTTTimeSap(PartID, "3", "03", "成型", ContourHourPreChildSum2, o_strSQL)
                SapCommon.syncTTTimeSap(PartID, "4", "04", "裁切前加工(仓库)", m_CutProPreChildSum2, o_strSQL) '04.裁切前加工(仓库)
                'SapCommon.syncTTTimeSap(PartID, "5", "05", "生产线前加工", m_ProPreHours, o_strSQL) '05.生产线前加工
                SapCommon.syncTTTimeSap(PartID, "9", "09", "子件总工时", CStr(Val(Assort) + 28), o_strSQL)
                SapCommon.syncTTTimeSap(PartID, "15", "A05", "半自动压接连接", m_SemiAutoPREChildSum2, o_strSQL)

                o_strSQL.Append(" COMMIT;")
                o_strSQL.Append(" END;")

                '20190927 田玉琳增加 保存数据在工时表中m_TiptopStandardHours_t
                SapCommon.syncSTTimeMes(PartID, "1", "01", "铆端前加工", PreAssemblyHourPreChildSum2, o_strSQLMes)
                SapCommon.syncSTTimeMes(PartID, "2", "02", "产线", MadeHourPreChildSum2, o_strSQLMes)
                SapCommon.syncSTTimeMes(PartID, "3", "03", "成型", ContourHourPreChildSum2, o_strSQLMes)
                SapCommon.syncSTTimeMes(PartID, "4", "04", "裁切前加工(仓库)", m_CutProPreChildSum2, o_strSQLMes)
                'SapCommon.syncSTTimeMes(PartID, "5", "05", "生产线前加工", m_ProPreHours, o_strSQLMes)
                SapCommon.syncSTTimeMes(PartID, "9", "09", "子件总工时", CStr(Val(Assort) + 28), o_strSQLMes)
                SapCommon.syncSTTimeMes(PartID, "15", "A05", "半自动压接连接", m_SemiAutoPREChildSum2, o_strSQLMes)

                RCardComBusiness.ExecuteNonQuery(o_strSQL.ToString)
                '20191012 田玉琳 更新数据到MES
                DbOperateUtils.ExecSQL(o_strSQLMes.ToString)

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "AutoUploadTimeToTiptop", "RCard")
            Throw ex
        Finally
        End Try
    End Sub

    Private Sub txtPN_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPN.ButtonCustomClick
        Dim obj As New SysBasicClass.InputText(txtPN)
        obj.ShowDialog()
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim strPath As String = ""
        Dim frmStation As New FrmRunCardImportStation("", "Export", False)
        frmStation.SelectExportPath("RunCard", strPath)

        Call DoExportStdTime(strPath)
    End Sub

    Private Sub DoExportStdTime(ByVal strPath As String)
        Dim o_outputFile As String = ""
        Dim errorMsg As String = Nothing
        Dim filePath As String = ""
        Try

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardTotalTimeTemplate.xlsx"
            o_outputFile = strPath + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation("", "Export", False)
            ' frmStation.runCardPn = Me.RunCardPn
            If IsNothing(_dtOutTotalTime) OrElse _dtOutTotalTime.Rows.Count <= 0 Then
                MessageUtils.ShowError("找不到对应的产品总工时信息！")
                Exit Sub
            End If

            Using dt As DataTable = _dtOutTotalTime
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
                    MessageUtils.ShowError("找不到对应的产品总工时信息！")
                    Exit Sub
                End If
            End Using

            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "DoExportStdTime", "RCard")
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class
