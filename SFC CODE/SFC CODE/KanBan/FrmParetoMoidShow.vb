Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame

''' 修改者： 田玉琳
''' 修改日： 2016/12/14
''' 修改内容：pdf导出
''' 修改日： 前三项不良出力
''' 修改内容：增加按工单生成柏拉图
''' 

Public Class FrmParetoMoidShow


#Region "事件"

    '初期化
    Private Sub FrmParetoMoidShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        Me.toolConifrm_Line.Enabled = IIf(KBCom.DBNullToStr(toolConifrm_Line.Tag) = "YES", True, False)
        Me.toolConifrm_PG.Enabled = IIf(KBCom.DBNullToStr(toolConifrm_PG.Tag) = "YES", True, False)

        KBCom.BindComboxLineAll(cboQueryLine)

    End Sub

    '查询
    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        SetSearchVisible()
        Me.cboMoid.Focus()
    End Sub

    '查询
    Private Sub BtnQuery_Click(sender As Object, e As EventArgs) Handles BtnQuery.Click
        If String.IsNullOrEmpty(Me.cboQueryLine.Text) Then
            MessageUtils.ShowError("请输入查询线别!")
            Me.cboQueryLine.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.cboMoid.Text) Then
            MessageUtils.ShowError("请输入查询工单!")
            Me.cboMoid.Focus()
            Exit Sub
        End If

        '工单号
        lblMoid.Text = cboMoid.Text
        '线别
        Me.lblLineID.Text = Me.cboQueryLine.Text.Trim
        '设置生产数量
        lblMOQty.Text = KBCom.GetProQty(lblMoid.Text.Trim(), Me.lblLineID.Text.Trim)
        '设置对应料号
        lblPartId.Text = KBCom.GetPartIdByMoid(lblMoid.Text.Trim(), Me.lblLineID.Text.Trim)
        '设置确认人
        lblUserName.Text = KBCom.GetConfirmName(lblMoid.Text.Trim(), Me.lblLineID.Text.Trim)
        Dim dt As DataTable = KBCom.GetNGData(Me.lblMoid.Text.Trim(), Me.lblLineID.Text)

        '没有取得数据时
        If dt.Rows.Count = 0 Then
            dgvNG.DataSource = Nothing
            While (dgvNGProcess.Rows.Count <> 0)
                dgvNGProcess.Rows.RemoveAt(0)
            End While

            SplitContainer2.Panel1.Controls.Clear()
            '提示该料号没有NG
            MessageUtils.ShowInformation("该工单没有判定不良数据！")
            Exit Sub
        End If
        'get NG data
        LoadNGData(dt)
        GenerateChart(dt)

        '绑定查询结果
        LoadNGProcess()

        '设置不显示
        SetSearchVisible()
    End Sub

    '线别变更 
    Private Sub cboQueryLine_TextChanged(sender As Object, e As EventArgs) Handles cboQueryLine.TextChanged
        If cboQueryLine.Text.Trim.Length < 4 Then Exit Sub

        KBCom.GetPartIdList(cboMoid, cboQueryLine.Text)
        cboMoid.Text = ""
    End Sub

    'PDF出力
    Private Sub toolPDF_Click(sender As Object, e As EventArgs) Handles toolPDF.Click
        Try
            If dgvNG.RowCount = 0 Then
                MessageUtils.ShowError("请先查询后再导出!")
                Exit Sub
            End If

            Dim ImagePath As String = System.Environment.CurrentDirectory + "\PCBA_Chart.JPEG"
            Dim fileDirectory As String = "c:\MesExport\"
            Dim PpfPath As String = fileDirectory + "制程不良分析柏拉图工单{0}.pdf"

            PpfPath = String.Format(PpfPath, lblMoid.Text)
            If (System.IO.Directory.Exists(fileDirectory)) = False Then
                System.IO.Directory.CreateDirectory(fileDirectory)
            End If

            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim name As String = ""

            dt = KBCom.GetNGData(Me.lblMoid.Text.Trim(), Me.lblLineID.Text)
            dt2 = KBCom.GetNGProcessData(lblMoid.Text, lblLineID.Text)
            dt2.Columns.RemoveAt(0) ' 移除第一条代码数据
            name = KBCom.GetConfirmName(Me.lblMoid.Text.Trim(), Me.lblLineID.Text)

            'PDFCommon.PartId = "工单：" + lblMoid.Text
            PDFCommon.NgDate = "工单：" + lblMoid.Text
            PDFCommon.LineId = "线别：" + lblLineID.Text
            PDFCommon.ProductLabel = "工单数量（PCS）"
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
            SysMessageClass.WriteErrLog(ex, "FrmParetoMoidShow", "toolPDF_Click", "KanBan")
        End Try
    End Sub

    '线长确认
    Private Sub toolConifrm_Line_Click(sender As Object, e As EventArgs) Handles toolConifrm_Line.Click
        Try
            '数据检查
            If CheckData_Line() = False Then
                Exit Sub
            End If
            SaveData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoMoidShow", "toolConifrm_Click", "KanBan")
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    '品管确认
    Private Sub toolConifrm_PG_Click(sender As Object, e As EventArgs) Handles toolConifrm_PG.Click
        Try
            '数据检查
            If CheckData_PG() = False Then
                Exit Sub
            End If

            SaveData("Y")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoMoidShow", "toolConifrm_Click", "KanBan")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

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
            'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
            Using o_dt As DataTable = KBCom.GetNGProcessData(lblMoid.Text, lblLineID.Text)
                Me.dgvNGProcess.DataSource = o_dt
            End Using

            dgvNGProcess.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvNGProcess.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

        'Dim dv As DataView = dtPareto.DefaultView
        'dv.Sort = "YValues DESC"

        ChartCommon.CreateChart(SplitContainer2, dtPareto, 0, 0)
    End Sub


    '检查数据
    Private Function CheckData_Line() As Boolean
        If dgvNGProcess.Rows.Count = 0 Then
            MessageUtils.ShowError("没有要更新数据,请先查询!")
            Return False
        End If

        If KBCom.IsCheckRepairFinish(lblMoid.Text, cboQueryLine.Text) = False Then
            MessageUtils.ShowError("请先维修所有不良产品,且IPQC确认过,再填写!")
            Return False
        End If
        If KBCom.IsCheckConfirm(lblMoid.Text, cboQueryLine.Text) = False Then
            MessageUtils.ShowError("不良项目已经确认过,请确认!")
            Return False
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

        If KBCom.IsCheckConfirm(lblMoid.Text, lblLineID.Text) = False Then
            MessageUtils.ShowError("不良项目已经确认过,请确认!")
            Return False
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

            TableName = "m_AssyTsProcssMoid_t"

            Dim insertSql As New System.Text.StringBuilder
            Dim strInsertSQL As String = " INSERT INTO {0}(Moid,LineId,Codeid,NgReason,Solution,Worker,FinishTime,TrackingResult,UserId,intime) "
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
                insertSql.AppendFormat(" SELECT @result = Codeid FROM {0} WHERE Moid ='{1}' and Codeid = '{2}' and LineId='{3}' ",
                                        TableName, lblMoid.Text, codeId, lblLineID.Text)
                insertSql.AppendFormat(" IF  @result <> '' ")
                insertSql.AppendFormat("    BEGIN ")
                insertSql.Append(strUpdateSQL)
                insertSql.AppendFormat("        SET Solution = N'{0}',", Solution)
                insertSql.AppendFormat("          NgReason = N'{0}',", NgReason)
                insertSql.AppendFormat("          Worker = N'{0}',", Worker)
                insertSql.AppendFormat("          FinishTime = N'{0}',", FinishTime)
                If flag = "Y" Then
                    insertSql.AppendFormat("          TrackingResult = N'{0}', ", TrackingResult)
                    insertSql.AppendFormat("          ConfirmUserId = N'{0}', ", VbCommClass.VbCommClass.UseId)
                    insertSql.AppendFormat("          ConfirmTime = getdate()")
                Else
                    insertSql.AppendFormat("          UserId = N'{0}', ", VbCommClass.VbCommClass.UseId)
                    insertSql.AppendFormat("          Intime = getdate()")
                End If
                insertSql.AppendFormat("        WHERE Moid ='{0}'", lblMoid.Text)
                insertSql.AppendFormat("        AND Codeid = '{0}'", codeId)
                insertSql.AppendFormat("        AND LineId = '{0}'", lblLineID.Text)
                insertSql.AppendFormat("    END ")
                insertSql.Append(" ELSE ")
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", lblMoid.Text)
                insertSql.AppendFormat("N'{0}',", lblLineID.Text)
                insertSql.AppendFormat("N'{0}',", codeId)
                insertSql.AppendFormat("N'{0}',", NgReason)
                insertSql.AppendFormat("N'{0}',", Solution)
                insertSql.AppendFormat("N'{0}',", Worker)
                insertSql.AppendFormat("N'{0}',", FinishTime)
                insertSql.AppendFormat("N'{0}',", TrackingResult)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat("getdate()")
                insertSql.Append(");")
            Next
            DbOperateUtils.ExecSQL(insertSql.ToString)
            MessageUtils.ShowInformation("保存数据成功！")
        Catch ex As Exception
            Throw ex
        End Try
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