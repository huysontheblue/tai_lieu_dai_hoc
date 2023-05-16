Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame
Imports Dundas.Charting.WinControl
Imports MainFrame.SysDataHandle
Imports Aspose.Cells

''' 修改者： 田玉琳
''' 修改日： 2016/04/01
''' 修改内容：pdf导出
''' 修改日： 前三项不良出力
''' 修改日： 2016/08/05
''' 修改内容：改到存储过程中处理
''' 修改者： 田玉琳
''' 修改日: 2016/12/06
''' 修改内容：增加按周柏拉图，和按月柏拉图
''' 

Public Class FrmParetoShow

#Region "定义"
    Private Enum ProcessExportGrid
        Lineid
        partid
        NgDate
    End Enum
#End Region

#Region "事件"
    '初始化
    Private Sub FrmParetoShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'toolConifrm.Enabled = IsIPQC(VbCommClass.VbCommClass.UseId)
        If Me.DesignMode = True Then Exit Sub
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        Me.toolConifrm_Line.Enabled = IIf(KBCom.DBNullToStr(toolConifrm_Line.Tag) = "YES", True, False)
        Me.toolConifrm_PG.Enabled = IIf(KBCom.DBNullToStr(toolConifrm_PG.Tag) = "YES", True, False)
        Me.toolAbandon.Enabled = Me.toolConifrm_PG.Enabled
        KBCom.BindComboxDateIf(cmbType)
        KBCom.BindComboxLineAll(cboQueryLine)
        SetFindVisible()
        cmbType.SelectedIndex = 0
    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '搜索
    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        SetSearchVisible()
        Me.cboPartID.Focus()
    End Sub

    '不良分析品管确认
    Private Sub toolConifrm_Line_Click(sender As Object, e As EventArgs) Handles toolConifrm_Line.Click
        Try
            '数据检查
            If CheckData_Line() = False Then
                Exit Sub
            End If
            SaveData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoShow", "toolConifrm_Click", "KanBan")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '不良分析产线确认
    Private Sub toolConifrm_PG_Click(sender As Object, e As EventArgs) Handles toolConifrm_PG.Click
        Try
            '数据检查
            If CheckData_PG() = False Then
                Exit Sub
            End If

            SaveData("Y")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoShow", "toolConifrm_Click", "KanBan")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 生成PDF
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolPDF_Click(sender As Object, e As EventArgs) Handles toolPDF.Click
        Try
            If dgvNG.RowCount = 0 Then
                MessageUtils.ShowError("请先查询后再导出!")
                Exit Sub
            End If

            Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
            Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")


            Dim ImagePath As String = System.Environment.CurrentDirectory + "\PCBA_Chart.JPEG"
            Dim fileDirectory As String = "c:\MesExport\"
            Dim PpfPath As String = fileDirectory + "制程不良分析柏拉图{0}.pdf"
            'If cmbType.Text = "日" Then
            '    PpfPath = String.Format(PpfPath, "(日)" + dateFrom)
            'ElseIf cmbType.Text = "周" Then
            '    PpfPath = String.Format(PpfPath, lblDate.Text)
            'Else
            '    PpfPath = String.Format(PpfPath, lblDate.Text)
            'End If
            PpfPath = String.Format(PpfPath, lblDate.Text)
            'Dim PpfPath As String = String.Format("c:\tiptop\" + "制程不良分析柏拉图{0}.pdf", DateTime.Now.ToFileTimeUtc)
            If (System.IO.Directory.Exists(fileDirectory)) = False Then
                System.IO.Directory.CreateDirectory(fileDirectory)
            End If

            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim name As String = ""

            If cmbType.Text = "日" Then
                dt = KBCom.GetNGData(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom)
                dt2 = KBCom.GetNGProcessData(lblPartID.Text, lblLineID.Text, dateFrom)
                dt2.Columns.RemoveAt(0) ' 移除第一条代码数据
                name = KBCom.GetConfirmName(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom)
            Else
                dt = KBCom.GetNGData(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom, dateTo)
                dt2 = KBCom.GetNGProcessData(lblPartID.Text, lblLineID.Text, dateFrom, dateTo)
                dt2.Columns.RemoveAt(0) ' 移除第一条代码数据
                name = KBCom.GetConfirmName(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom, dateTo)
            End If

            PDFCommon.NgDate = "日期：" + lblDate.Text
            PDFCommon.PartId = "料号：" + lblPartID.Text
            PDFCommon.LineId = "线别：" + lblLineID.Text
            PDFCommon.ProductLabel = "生产数量（PCS）"
            PDFCommon.Qty = lblMOQty.Text

            If name <> "" Then
                PDFCommon.Status = "已完结"
                PDFCommon.UserName = name
            Else
                PDFCommon.Status = "生产确认"
                PDFCommon.UserName = ""
            End If

            PDFCommon.CreatePdf(PpfPath, ImagePath, KBCom.GetTable(dt), dt2)

            MessageUtils.ShowInformation("生成PDF成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoShow", "toolPDF_Click", "KanBan")
        End Try
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnQuery_Click(sender As Object, e As EventArgs) Handles BtnQuery.Click
        If String.IsNullOrEmpty(Me.cboPartID.Text) Then
            MessageUtils.ShowError("请输入查询料号!")
            Me.cboPartID.Focus()
            Exit Sub
        End If
        lblPartID.Text = Me.cboPartID.Text
        lblDate.Text = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        lblLineID.Text = cboQueryLine.Text.ToUpper.Trim

        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")
        Dim dt As DataTable
        Dim bLineNoConfirm As Boolean = True

        If cmbType.Text = "日" Then
            '设置生产数量
            lblMOQty.Text = KBCom.GetProQty(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, Me.lblDate.Text)
            '设置确认人
            lblUserName.Text = KBCom.GetConfirmName(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, dateFrom)
            dt = KBCom.GetNGData(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom)
            bLineNoConfirm = KBCom.IsCheckConfirmLine(lblPartID.Text, dateFrom, lblLineID.Text)
        ElseIf cmbType.Text = "周" Then
            Me.lblDate.Text = String.Format("第{0}周（{1}～{2}）", KBCom.WeekOfYear(Me.dtpDate.Value), Me.dtpDate.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"))
            lblMOQty.Text = KBCom.GetProQty(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, dateFrom, dateTo)
            '设置确认人
            lblUserName.Text = KBCom.GetConfirmName(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, dateFrom, dateTo)
            dt = KBCom.GetNGData(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom, dateTo)
            bLineNoConfirm = KBCom.IsCheckConfirmLine(lblPartID.Text, dateFrom, dateTo, lblLineID.Text)
        Else
            Me.lblDate.Text = String.Format("{0}", Me.dtpDate.Value.ToString("yyyy-MM"))
            lblMOQty.Text = KBCom.GetProQty(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, dateFrom, dateTo)
            '设置确认人
            lblUserName.Text = KBCom.GetConfirmName(lblPartID.Text.Trim(), Me.lblLineID.Text.Trim, dateFrom, dateTo)
            dt = KBCom.GetNGData(Me.lblPartID.Text.Trim(), Me.lblLineID.Text, dateFrom, dateTo)
            bLineNoConfirm = KBCom.IsCheckConfirmLine(lblPartID.Text, dateFrom, dateTo, lblLineID.Text)
        End If

        '没有取得数据时
        If dt.Rows.Count = 0 Then
            dgvNG.DataSource = Nothing
            'dgvNGProcess.DataSource = Nothing
            While (dgvNGProcess.Rows.Count <> 0)
                dgvNGProcess.Rows.RemoveAt(0)
            End While

            SplitContainer2.Panel1.Controls.Clear()
            '提示该料号没有NG
            MessageUtils.ShowInformation("该料号在当前日期没有判定不良数据！")
            Exit Sub
        End If
        'get NG data
        LoadNGData(dt)
        GenerateChart(dt)

        lblNgReason.Text = KBCom.GetRejectText(cmbType.Text, lblPartID.Text, lblLineID.Text, dtpDate.Text)
        If lblNgReason.Text <> "" Then
            lblNgReason.Text = "驳回原因：" + lblNgReason.Text
        End If

        '绑定查询结果
        LoadNGProcess()

        SetGridColor(bLineNoConfirm)
        '设置不显示
        SetSearchVisible()
    End Sub

    '显示参照数据
    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        If String.IsNullOrEmpty(Me.cboPartID.Text) Then
            MessageUtils.ShowError("请输入查询料号!")
            Me.cboPartID.Focus()
            Exit Sub
        End If

        Dim frm As FrmParetoShowSub = New FrmParetoShowSub
        frm.cboQueryLine.Text = cboQueryLine.Text.ToUpper.Trim
        frm.cboPartID.Text = Me.cboPartID.Text
        frm.Type = Me.cmbType.Text
        'frm.SDate = dtpDate.Value '查找上一天数据
        frm.dtpDate.Value = dtpDate.Value '查找上一天数据

        frm.Show()
    End Sub

    '时间改变
    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged, dtpDateTo.ValueChanged
        SetFindVisible()
        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        If cmbType.Text = "日" Then
            KBCom.GetPartIdList(cboPartID, dateFrom, cboQueryLine.Text)
        Else
            KBCom.GetPartIdList(cboPartID, dateFrom, dateTo, cboQueryLine.Text)
        End If
        If cboPartID.Items.Count > 0 Then
            cboPartID.SelectedIndex = 0
        Else
            cboPartID.Text = String.Empty
            cboPartID.SelectedIndex = -1
        End If
    End Sub

    '线别改变
    Private Sub cboQueryLine_TextChanged(sender As Object, e As EventArgs) Handles cboQueryLine.TextChanged
        If cboQueryLine.Text.Trim.Length < 4 Then Exit Sub
        If cmbType.Text = "日" Then
            KBCom.GetPartIdList(cboPartID, dtpDate.Value.ToString("yyyy/MM/dd"), cboQueryLine.Text)
        Else
            KBCom.GetPartIdList(cboPartID, dtpDate.Value.ToString("yyyy/MM/dd"), dtpDateTo.Value.ToString("yyyy/MM/dd"), cboQueryLine.Text)
        End If

        If cboPartID.Items.Count > 0 Then
            cboPartID.SelectedIndex = 0
        Else
            cboPartID.Text = String.Empty
            cboPartID.SelectedIndex = -1
        End If
    End Sub

    '方式
    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        SetFindVisible()
    End Sub

    '料号维护 
    Private Sub toolPartId_Click(sender As Object, e As EventArgs) Handles toolPartId.Click
        Dim frm As FrmParetoPartId = New FrmParetoPartId

        frm.ShowDialog()
    End Sub

    '驳回
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If CheckStatus() = False Then Exit Sub
        'If MessageUtils.ShowConfirm("你确定驳回吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If
        Dim frm As FrmReject = New FrmReject
        frm.type = "1"
        frm.SelectType = cmbType.Text
        frm.partId = lblPartID.Text
        frm.ngDate = dtpDate.Text
        frm.lineid = lblLineID.Text
        frm.ShowDialog()

    End Sub

    '驳回内容查看
    Private Sub tsbRejectText_Click(sender As Object, e As EventArgs) Handles tsbRejectText.Click
        Dim frm As FrmReject = New FrmReject
        frm.type = "2"
        frm.SelectType = cmbType.Text
        frm.partId = lblPartID.Text
        frm.ngDate = dtpDate.Text
        frm.lineid = lblLineID.Text
        frm.ShowDialog()
    End Sub

    '检查选择数据状态
    Private Function CheckStatus() As Boolean

        If dgvNGProcess.Rows.Count = 0 Then
            MessageUtils.ShowError("没有要更新数据,请先查询!")
            Return False
        End If

        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        If cmbType.Text = "日" Then
            If KBCom.IsCheckConfirmLine(lblPartID.Text, dateFrom, lblLineID.Text) = True Then
                MessageUtils.ShowError("不良项目线长没有确认,请确认!")
                Return False
            End If
            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, lblLineID.Text) = False Then
                MessageUtils.ShowError("不良项目品管已确认,不能驳回!")
                Return False
            End If
        Else
            If KBCom.IsCheckConfirmLine(lblPartID.Text, dateFrom, dateTo, lblLineID.Text) = True Then
                MessageUtils.ShowError("不良项目线长没有确认,请确认!")
                Return False
            End If
            '增加条件判断
            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, dateTo, lblLineID.Text) = False Then
                MessageUtils.ShowError("不良项目品管已确认,不能驳回!")
                Return False
            End If
        End If

        Return True
    End Function

#End Region

#Region "方法"

    '设置显示和隐藏
    Private Sub SetSearchVisible()
        If Me.SplitContainer6.Panel1Collapsed = True Then
            Me.SplitContainer6.Panel1Collapsed = False
        Else
            Me.SplitContainer6.Panel1Collapsed = True
        End If
    End Sub

    Private Sub SetFindVisible()
        If cmbType.Text = "日" Then
            lblStartDate.Text = "日期:"
            Me.SplitContainer4.Panel1Collapsed = True
            'dtpDate.Value = Date.Now
        Else
            Me.SplitContainer4.Panel1Collapsed = False
            lblStartDate.Text = "开始日:"
            lblEndDate.Text = "结束日:"

            If cmbType.Text = "周" Then
                dtpDate.Value = KBCom.GetWeekFirstDaySun(dtpDate.Value)
                dtpDateTo.Value = KBCom.GetWeekLastDaySat(dtpDate.Value)
            ElseIf cmbType.Text = "月" Then
                Dim d1 As DateTime = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, 1)
                Dim d2 As DateTime = d1.AddMonths(1).AddDays(-1)
                dtpDate.Value = d1
                dtpDateTo.Value = d2
            End If
        End If
    End Sub

    '检查数据
    Private Function CheckData_Line() As Boolean
        If dgvNGProcess.Rows.Count = 0 Then
            MessageUtils.ShowError("没有要更新数据,请先查询!")
            Return False
        End If

        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        If cmbType.Text = "日" Then
            If KBCom.IsCheckRepairFinish(lblPartID.Text, dateFrom, cboQueryLine.Text) = False Then
                MessageUtils.ShowError("请先维修所有不良产品,且IPQC确认过,再填写!")
                Return False
            End If
            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, cboQueryLine.Text) = False Then
                MessageUtils.ShowError("不良项目已经确认过,请确认!")
                Return False
            End If
        Else
            '增加条件判断
            If cmbType.Text = "周" Then
                If dateTo >= DateTime.Now.ToString("yyyy-MM-dd") Then
                    MessageUtils.ShowError("请在这周结束后再填写!")
                    Return False
                End If
            Else
                If Me.dtpDateTo.Value.ToString("yyyyMM") >= DateTime.Now.ToString("yyyyMM") Then
                    MessageUtils.ShowError("请在这月结束后再填写!")
                    Return False
                End If
            End If

            If KBCom.IsCheckRepairFinish(lblPartID.Text, dateFrom, dateTo, cboQueryLine.Text) = False Then
                MessageUtils.ShowError("请先维修所有不良产品,且IPQC确认过,再填写!")
                Return False
            End If
            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, dateTo, cboQueryLine.Text) = False Then
                MessageUtils.ShowError("不良项目已经确认过,请确认!")
                Return False
            End If
        End If



        Dim NgReason As String = ""
        Dim Solution As String = ""
        Dim Worker As String = ""
        Dim FinishTime As String = ""
        For rowIndex As Integer = 0 To dgvNGProcess.Rows.Count - 1
            NgReason = dgvNGProcess.Rows(rowIndex).Cells("colNGReason").EditedFormattedValue.ToString.Trim
            Solution = dgvNGProcess.Rows(rowIndex).Cells("colSolution").EditedFormattedValue.ToString.Trim
            Worker = dgvNGProcess.Rows(rowIndex).Cells("colWorker").EditedFormattedValue.ToString.Trim
            FinishTime = dgvNGProcess.Rows(rowIndex).Cells("colFinishTime").EditedFormattedValue.ToString.Trim
            If String.IsNullOrEmpty(NgReason) Then
                MessageUtils.ShowError(String.Format("第{0}行不良原因不能为空！", (rowIndex + 1).ToString))
                Return False
            End If
            If String.IsNullOrEmpty(Solution) Then
                MessageUtils.ShowError(String.Format("第{0}行处理方案不能为空！", (rowIndex + 1).ToString))
                Return False
            End If
            If String.IsNullOrEmpty(Worker) Then
                MessageUtils.ShowError(String.Format("第{0}行责任人不能为空！", (rowIndex + 1).ToString))
                Return False
            End If
            If String.IsNullOrEmpty(FinishTime) Then
                MessageUtils.ShowError(String.Format("第{0}行完成时间不能为空！", (rowIndex + 1).ToString))
                Return False
            End If
        Next
        CheckData_Line = True
    End Function

    '检查数据
    Private Function CheckData_PG() As Boolean
        If dgvNGProcess.Rows.Count = 0 Then
            MessageUtils.ShowError("没有要更新数据,请先查询!")
            Return False
        End If

        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        If cmbType.Text = "日" Then
            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, lblLineID.Text) = False Then
                MessageUtils.ShowError("不良项目已经确认过,请确认!")
                Return False
            End If
        Else
            '增加条件判断
            If cmbType.Text = "周" Then
                If dateTo >= DateTime.Now.ToString("yyyy-MM-dd") Then
                    MessageUtils.ShowError("请在这周结束后再填写!")
                    Return False
                End If
            Else
                If Me.dtpDateTo.Value.ToString("yyyyMM") >= DateTime.Now.ToString("yyyyMM") Then
                    MessageUtils.ShowError("请在这月结束后再填写!")
                    Return False
                End If
            End If

            If KBCom.IsCheckConfirm(lblPartID.Text, dateFrom, dateTo, lblLineID.Text) = False Then
                MessageUtils.ShowError("不良项目已经确认过,请确认!")
                Return False
            End If
        End If

        Dim TrackingResult As String = ""
        For rowIndex As Integer = 0 To dgvNGProcess.Rows.Count - 1
            TrackingResult = dgvNGProcess.Rows(rowIndex).Cells("colTrackingResult").EditedFormattedValue.ToString.Trim
            If String.IsNullOrEmpty(TrackingResult) Then
                MessageUtils.ShowError(String.Format("第{0}行结果追踪不能为空！", (rowIndex + 1).ToString))
                Return False
            End If
        Next
        CheckData_PG = True
    End Function

    '保存不良分析确认
    Private Sub SaveData(Optional flag As String = "")
        Dim codeId As String = ""
        Dim NgReason As String = ""
        Dim Solution As String = ""
        Dim Worker As String = ""
        Dim FinishTime As String = ""
        Dim TrackingResult As String = ""
        Dim TableName As String = ""
        Dim ColumnDate As String = ""
        Try

            If cmbType.Text = "日" Then
                TableName = "m_AssyTsProcss_t"
            ElseIf cmbType.Text = "周" Then
                TableName = "m_AssyTsProcssWeek_t"
            ElseIf cmbType.Text = "月" Then
                TableName = "m_AssyTsProcssMonth_t"
            End If

            Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
            Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")
            Dim dateMonth As String = Me.dtpDate.Value.ToString("yyyyMM")

            Dim insertSql As New System.Text.StringBuilder
            Dim strInsertSQL As String = " INSERT INTO {0}(PartID,NgDate,LineId,Codeid,NgReason,Solution,Worker,FinishTime,TrackingResult,UserId,intime) "
            strInsertSQL = String.Format(strInsertSQL, TableName)
            Dim strUpdateSQL As String = " UPDATE {0} "
            strUpdateSQL = String.Format(strUpdateSQL, TableName)
            insertSql.AppendFormat(" DECLARE @result NVARCHAR(10)")

            For rowIndex As Integer = 0 To dgvNGProcess.Rows.Count - 1
                codeId = dgvNGProcess.Rows(rowIndex).Cells("colCodeid").EditedFormattedValue.ToString
                NgReason = dgvNGProcess.Rows(rowIndex).Cells("colNGReason").EditedFormattedValue.ToString
                Solution = dgvNGProcess.Rows(rowIndex).Cells("colSolution").EditedFormattedValue.ToString.Trim
                Worker = dgvNGProcess.Rows(rowIndex).Cells("colWorker").EditedFormattedValue.ToString.Trim
                FinishTime = dgvNGProcess.Rows(rowIndex).Cells("colFinishTime").EditedFormattedValue.ToString.Trim
                TrackingResult = dgvNGProcess.Rows(rowIndex).Cells("colTrackingResult").EditedFormattedValue.ToString.Trim

                insertSql.AppendFormat(" SET @result = '' ")
                'If cmbType.Text = "日" Then
                '    insertSql.AppendFormat(" SELECT @result = Codeid FROM {0} WHERE PartID ='{1}' and NgDate ='{2}' and Codeid = '{3}' and LineId='{4}' ",
                '                      TableName, lblPartID.Text, dateFrom, codeId, lblLineID.Text)
                'ElseIf cmbType.Text = "周" Then
                '    insertSql.AppendFormat(" SELECT @result = Codeid FROM {0} WHERE PartID ='{1}' and NgDateFrom ='{2}' and NgDateTo ='{3}' and Codeid = '{4}' and LineId='{5}' ",
                '                      TableName, lblPartID.Text, dateFrom, dateTo, codeId, lblLineID.Text)
                'ElseIf cmbType.Text = "月" Then
                '    insertSql.AppendFormat(" SELECT @result = Codeid FROM {0} WHERE PartID ='{1}' and NgDate ='{2}' and Codeid = '{3}' and LineId='{4}' ",
                '                      TableName, lblPartID.Text, dateMonth, codeId, lblLineID.Text)
                'End If
                insertSql.AppendFormat(" SELECT @result = Codeid FROM {0} WHERE PartID ='{1}' and NgDate ='{2}' and Codeid = '{3}' and LineId='{4}' ",
                                        TableName, lblPartID.Text, dateFrom, codeId, lblLineID.Text)
                insertSql.AppendFormat(" IF  @result <> '' ")
                insertSql.AppendFormat("    BEGIN ")
                insertSql.Append(strUpdateSQL)
                insertSql.AppendFormat("        SET Solution = N'{0}',", Solution)
                insertSql.AppendFormat("          NgReason = N'{0}',", NgReason)
                insertSql.AppendFormat("          Worker = N'{0}',", Worker)
                insertSql.AppendFormat("          FinishTime = N'{0}',", FinishTime)
                If flag = "Y" Then
                    insertSql.AppendFormat("          RejectReason = '', ")
                    insertSql.AppendFormat("          TrackingResult = N'{0}', ", TrackingResult)
                    insertSql.AppendFormat("          ConfirmUserId = N'{0}', ", VbCommClass.VbCommClass.UseId)
                    insertSql.AppendFormat("          ConfirmTime = getdate()")
                Else
                    insertSql.AppendFormat("          UserId = N'{0}', ", VbCommClass.VbCommClass.UseId)
                    insertSql.AppendFormat("          Intime = getdate()")
                End If
                insertSql.AppendFormat("        WHERE PartID ='{0}'", lblPartID.Text)
                insertSql.AppendFormat("        AND NgDate = '{0}'", dateFrom)
                'If cmbType.Text = "日" Then
                '    insertSql.AppendFormat("        AND NgDate = '{0}'", dateFrom)
                'ElseIf cmbType.Text = "周" Then
                '    insertSql.AppendFormat("        AND NgDateFrom = '{0}'", dateFrom)
                '    insertSql.AppendFormat("        AND NgDateTo = '{0}'", dateTo)
                'ElseIf cmbType.Text = "月" Then
                '    insertSql.AppendFormat("        AND NgDate = '{0}'", dateMonth)
                'End If
                insertSql.AppendFormat("        AND Codeid = '{0}'", codeId)
                insertSql.AppendFormat("        AND LineId = '{0}'", lblLineID.Text)
                insertSql.AppendFormat("    END ")
                insertSql.Append(" ELSE ")
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", lblPartID.Text)
                'If cmbType.Text = "日" Then
                '    insertSql.AppendFormat("N'{0}',", dateFrom)
                'ElseIf cmbType.Text = "周" Then
                '    insertSql.AppendFormat("N'{0}',", dateFrom)
                '    insertSql.AppendFormat("N'{0}',", dateTo)
                'ElseIf cmbType.Text = "月" Then
                '    insertSql.AppendFormat("N'{0}',", dateMonth)
                'End If
                insertSql.AppendFormat("N'{0}',", dateFrom)
                insertSql.AppendFormat("N'{0}',", lblLineID.Text)
                insertSql.AppendFormat("N'{0}',", codeId)
                insertSql.AppendFormat("N'{0}',", NgReason)
                insertSql.AppendFormat("N'{0}',", Solution)
                insertSql.AppendFormat("N'{0}',", Worker)
                insertSql.AppendFormat("N'{0}',", FinishTime)
                insertSql.AppendFormat("N'{0}',", TrackingResult)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat("getdate()")
                insertSql.Append(");" + vbNewLine)
            Next
            '*****************************************田玉琳 20170331 开始*****************************************
            '删除旧保存的其他数据
            Dim deleteSQL As String = GetDeleteOldCodeId(TableName, dateFrom)
            DbOperateUtils.ExecSQL(deleteSQL + insertSql.ToString)
            '*****************************************田玉琳 20170331 结束*****************************************

            MessageUtils.ShowInformation("保存数据成功！")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '删除旧保存的其他数据
    Private Function GetDeleteOldCodeId(TableName As String, dateFrom As String)
        Dim codeIds As String = ""
        For rowIndex As Integer = 0 To dgvNGProcess.Rows.Count - 1
            codeIds = codeIds + "'" + dgvNGProcess.Rows(rowIndex).Cells("colCodeid").EditedFormattedValue.ToString + "',"
        Next
        If codeIds <> "" Then
            codeIds = codeIds.Substring(0, codeIds.Length - 1)
        End If

        GetDeleteOldCodeId = String.Format(" UPDATE {0} SET Usey = 'N' WHERE PartID ='{1}' and NgDate ='{2}' and Codeid NOT IN ({3}) and LineId='{4}' ",
                                             TableName, lblPartID.Text, dateFrom, codeIds, lblLineID.Text)
    End Function

    '创建表用数据
    Private Sub GenerateChart(dt As DataTable)
        Dim dtPareto As DataTable = New DataTable
        If dtPareto.Columns.Count = 0 Then
            dtPareto.Columns.Add(0)
            dtPareto.Columns.Add("YValues")
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim PRows As DataRow = dtPareto.NewRow()
            PRows(0) = dt.Rows(i).Item("CCName")
            PRows("YValues") = dt.Rows(i).Item("NGqty")
            dtPareto.Rows.Add(PRows)
        Next

        Dim dv As DataView = dtPareto.DefaultView
        dv.Sort = "YValues DESC"

        ChartCommon.CreateChart(SplitContainer2, dtPareto, 0, 0)
    End Sub

    Private Sub LoadNGData(dt As DataTable)
        dgvNG.DataSource = Nothing
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        If dt.Rows.Count > 0 Then
            dgvNG.DataSource = KBCom.GetTable(dt)
        End If
        dgvNG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvNG.Width = 540
    End Sub

    Private Sub LoadNGProcess()
        Try
            Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
            Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

            If cmbType.Text = "日" Then
                'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
                Using o_dt As DataTable = KBCom.GetNGProcessData(lblPartID.Text, lblLineID.Text, dateFrom)
                    Me.dgvNGProcess.DataSource = o_dt
                End Using
            Else
                'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
                Using o_dt As DataTable = KBCom.GetNGProcessData(lblPartID.Text, lblLineID.Text, dateFrom, dateTo)
                    Me.dgvNGProcess.DataSource = o_dt
                End Using
            End If
            dgvNGProcess.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvNGProcess.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '设置Grid颜色
    Private Sub SetGridColor(bLineConfirm As Boolean)
        For rowIndex As Integer = 0 To dgvNGProcess.Rows.Count - 1
            If lblNgReason.Text <> "" And bLineConfirm = True Then
                dgvNGProcess.Rows(rowIndex).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
            Else
                dgvNGProcess.Rows(rowIndex).DefaultCellStyle.ForeColor = System.Drawing.Color.Black
            End If
        Next
    End Sub

#End Region

#Region "Grid行数"
    Private Sub dgvNG_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvNG.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvNGProcess_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvNGProcess.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region


End Class