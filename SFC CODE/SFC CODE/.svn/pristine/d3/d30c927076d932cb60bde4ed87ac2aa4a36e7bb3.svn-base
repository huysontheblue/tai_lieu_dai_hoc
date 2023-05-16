Imports UIHandler
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports Aspose.Cells
Imports System.Text.RegularExpressions
Imports MainFrame.SysCheckData
Imports Aspose.Cells.Charts
Imports Aspose.Cells.Drawing
Imports System.Threading
Imports System.IO

Public Class FrmProductNGDayQuery

    Private totalRate As String
    Private ReadOnly HalfWidthNumberPattern As Regex = New Regex("^[0-9]+$")
    Private _NgDay_TemplateFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\NGQtyReprotLD_Template.xls"
    Private Enum SelectType
        Customer
        Series
        LineId
        AllLine
        PartId
        CustomerOrSeries
        Dept
        PG
        Trend
        NGLD
    End Enum

#Region "事件"

    '初期化
    Private Sub FrmProductNGQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            rdoCustomer.Checked = True
            cbbCustomer.SelectedIndex = 0
            dtpStart.Value = Now().ToString("yyyy/MM/dd")
            dtpEnd.Value = Now().ToString("yyyy/MM/dd")
            'LoadDataToCombo(cbbDept, 2)
            'FillCombox(cbbDept)
            FillCombox(cbbCustomer)
            FillCombox(cbbSeries)
            FillCombox(cbbNgStationId)
            LoadDataToCombo(cbbDept)
            LoadLineIDToCombo(cbbLine, "")
        End If
    End Sub

    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        LoadLineIDToCombo(cbbLine, Getids(cbbDept.Text))
    End Sub

    'EXCEL导出
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lblMsg.Text = ""
            If CheckData() = False Then Return

            EXCELOUTPUT()
        Catch ex As ThreadAbortException
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind.FrmProductNGDayQuery", "toolExcel_Click", "WIP")
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    '选择线别
    Private Sub btnSelectLine_Click(sender As Object, e As EventArgs) Handles btnSelectLine.Click
        Dim frm As FrmProductNGDayQuerySub = New FrmProductNGDayQuerySub()

        frm.txtSelectedDept.Text = cbbDept.Text
        frm.checkedType = "LINE"
        Dim result As DialogResult = frm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            cbbLine.Text = frm.checkedLine
        End If
    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '错误处理
    Private Sub cDgData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)

    End Sub

    Private Sub cbbLine_TextChanged(sender As Object, e As EventArgs) Handles cbbLine.TextChanged
        If cbbLine.Text.Trim.Length < 4 Then Exit Sub
        '可编辑时才设置料号
        If rdoPartId.Checked = True Or rdoPG.Checked = True Or rdoTrend.Checked = True Then
            SetPartIdList(cbbPartId)
            If cbbPartId.Items.Count > 0 Then
                cbbPartId.SelectedIndex = 0
            Else
                cbbPartId.Text = String.Empty
                cbbPartId.SelectedIndex = -1
            End If
        Else
            cbbPartId.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbbNgStationId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbNgStationId.SelectedIndexChanged
        If rdoTrend.Checked = True Then
            'If cbbLine.Text.Trim = "ALL" Or cbbLine.Text.Trim = "" Then
            '    MessageUtils.ShowError("请选择线别！")
            '    Exit Sub
            'End If
            'If cbbPartId.Text.Trim = "" Then
            '    MessageUtils.ShowError("请输入料号！")
            '    Exit Sub
            'End If

            txtNgRate.Text = GetSeriesNgTargetbyStation()
        End If
    End Sub

    ''' <summary>
    ''' 取得料号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGetPartId_Click(sender As Object, e As EventArgs) Handles btnGetPartId.Click
        If cbbLine.Text.Trim = "ALL" Or cbbLine.Text.Trim = "" Then
            MessageUtils.ShowError("请选择线别！")
            Exit Sub
        End If

        SetPartIdList(cbbPartId)
        If rdoTrend.Checked = True Then
            txtNgRate.Text = GetSeriesNgTargetbyStation()
        End If
    End Sub

    '取得子料号
    Private Sub btnGetSubPartId_Click(sender As Object, e As EventArgs) Handles btnGetSubPartId.Click
        'If cbbLine.Text.Trim = "ALL" Or cbbLine.Text.Trim = "" Then
        '    MessageUtils.ShowError("请选择线别！")
        '    Exit Sub
        'End If

        Dim frm As FrmProductNGDayQuerySub = New FrmProductNGDayQuerySub()

        frm.txtSelectedLine.Text = cbbLine.Text
        frm.checkedType = "PARTID"
        '设置料号
        SetPartIdList(frm.cbbPartId)
        frm.cbbPartId.Text = cbbPartId.Text

        Dim result As DialogResult = frm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            cbbPartId.Text = frm.checkedPartId
        End If
    End Sub

#Region "RadionBox"

    Private Sub rdoCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCustomer.CheckedChanged
        SetControlEdit(SelectType.Customer)
    End Sub

    Private Sub rdoSeries_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSeries.CheckedChanged
        SetControlEdit(SelectType.Series)
    End Sub

    Private Sub rdoCustomerSeries_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCustomerSeries.CheckedChanged
        SetControlEdit(SelectType.CustomerOrSeries)
    End Sub

    Private Sub rdoPG_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPG.CheckedChanged
        SetControlEdit(SelectType.PG)
    End Sub

    Private Sub rdoPartId_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPartId.CheckedChanged
        SetControlEdit(SelectType.PartId)
    End Sub

    Private Sub rdoAllLine_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAllLine.CheckedChanged
        SetControlEdit(SelectType.AllLine)
    End Sub

    Private Sub rdoLine_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLine.CheckedChanged
        SetControlEdit(SelectType.LineId)
    End Sub

    Private Sub rdoDept_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDept.CheckedChanged
        SetControlEdit(SelectType.Dept)
    End Sub

    Private Sub rdoTrend_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTrend.CheckedChanged
        SetControlEdit(SelectType.Trend)
    End Sub
    Private Sub rdoNgDay_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNgDay.CheckedChanged
        SetControlEdit(SelectType.NGLD)
    End Sub
#End Region

#End Region

#Region "方法"

    Private Sub FillCombox(ByVal ColComboBox As System.Windows.Forms.ComboBox)
        Dim strSQL As String
        If ColComboBox.Name = "cbbDept" Then
            strSQL = "select dqc as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory &
                                   "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')"
            BindComboxAll(strSQL, ColComboBox, "djc", "deptid")
        ElseIf ColComboBox.Name = "cbbCustomer" Then
            'strSQL = " Select (CusID+'-'+CusName) CusName ,CusID from m_Customer_t"
            'BindComboxAll(strSQL, ColComboBox, "CusName", "CusID")
            LoadDataToCombo(cbbCustomer, 1)
        ElseIf ColComboBox.Name = "CbbLine" Then
            strSQL = " Select  lineid,lineid from Deptline_t where deptid='" & Getid(cbbDept.Text) & "'"
            BindComboxAll(strSQL, ColComboBox, "lineid", "lineid")
        ElseIf ColComboBox.Name = "cbbSeries" Then
            strSQL = " SELECT ([SeriesID]+'-'+[SeriesName])SeriesName ,[SeriesID] FROM [m_Series_t] WHERE Usey='Y'"
            BindComboxAll(strSQL, ColComboBox, "SeriesName", "SeriesID")
        ElseIf ColComboBox.Name = "cbbNgStationId" Then
            strSQL = " SELECT (Stationid+'-'+Stationname)Stationname,Stationid from m_Rstation_t where NGY = 'Y'"
            BindComboxAll(strSQL, ColComboBox, "Stationname", "Stationid")
        End If
    End Sub

    Public Shared Sub BindComboxAll(ByVal SQL As String, ByVal ColComboBox As System.Windows.Forms.ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = "ALL"
        dr(value) = "ALL"
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As System.Windows.Forms.ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(SQL)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    '取得导出数据
    Private Function GetExcelDataTable(strType As String) As DataTable
        Dim strSQL As String
        Dim ngrate As String = ""

        If strType = "8" Then '计算已经嵌入存储过程 update by 马跃平 2018-01-22
            'strSQL = "declare @CL varchar(10)  "
            'strSQL = strSQL + " EXEC m_QueryTotalDayNGQuery_CL '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', @CL output "
            'strSQL = strSQL + " SELECT @CL "
            'strSQL = String.Format(strSQL, Me.dtpStart.Value.ToString("yyyy/MM/dd"), Me.dtpEnd.Value.ToString("yyyy/MM/dd"),
            '              Me.cbbLine.Text, Me.cbbPartId.Text.Trim, Getid(cbbNgStationId.Text),
            '              VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            'Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    ngrate = dt.Rows(0)(0).ToString
            'Else
            '    ngrate = 0
            'End If
        ElseIf strType = "9" Then
            ngrate = txtNgRate.Text.Trim
        End If

        strSQL = "EXEC m_QueryTotalDayNGQuery_p_1 '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}','{12}'"
        strSQL = String.Format(strSQL, Me.dtpStart.Value.ToString("yyyy-MM-dd"), Me.dtpEnd.Value.ToString("yyyy-MM-dd"), Getids2(cbbDept.Text), Me.cbbLine.Text,
                            Me.cbbPartId.Text.Trim, Getid(cbbCustomer.Text), Getid(cbbSeries.Text), Getid(cbbNgStationId.Text), ngrate,
                            VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, strType, VbCommClass.VbCommClass.UseId)

        Dim dts As DataTable

        If strType = "5" Then
            Dim ds As DataSet = DbOperateReportUtils.GetDataSet(strSQL)
            dts = ds.Tables(0)
            If ds.Tables(1).Rows.Count > 0 Then
                totalRate = ds.Tables(1).Rows(0)(0).ToString
            Else
                totalRate = "0"
            End If
        Else
            dts = DbOperateReportUtils.GetDataTable(strSQL)
        End If

        Return dts
    End Function

    ''' <summary>
    ''' 指定料号导出,新增料号字符串栏位 add by 马跃平 20180201
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetExcelDataSetByPartIDStr() As DataSet
        Dim strSQL As String
        Dim ngrate As String = ""
        strSQL = "EXEC m_QueryTotalDayNGQuery_p_1 '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}','{12}'"
        strSQL = String.Format(strSQL, Me.dtpStart.Value.ToString("yyyy-MM-dd"), Me.dtpEnd.Value.ToString("yyyy-MM-dd"), Getids2(cbbDept.Text), Me.cbbLine.Text,
                            Me.cbbPartId.Text.Trim, Getid(cbbCustomer.Text), Getid(cbbSeries.Text), Getid(cbbNgStationId.Text), ngrate,
                            VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 5, VbCommClass.VbCommClass.UseId)
        Dim ds As DataSet = DbOperateReportUtils.GetDataSet(strSQL)
        Return ds
    End Function

    Private Function CheckHaveData(ByVal dt As DataTable)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("查询条件没有数据，请重新输入条件。")
            Return False
        End If
        Return True
    End Function

    Private Function CheckHaveDataByColumn(ByVal dt As DataTable)
        If dt.Columns.Count < 3 Then
            MessageUtils.ShowError("查询条件没有数据，请重新输入条件。")
            Return False
        End If
        Return True
    End Function

    '获取不良生产日报
    Private Function GetNgDayReportTable() As DataTable
        Dim strSQL As String

        strSQL = " DECLARE @Rtvalue VARCHAR(1),@RtMsg NVARCHAR(128) EXEC GetTotalDayNGQuery_LD '{0}', '{1}', '{2}', '{3}', '{4}', '{5}' ,@Rtvalue,@RtMsg"
        strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory, Me.dtpStart.Value.ToString("yyyy/MM/dd"), Me.dtpEnd.Value.ToString("yyyy/MM/dd"), Getids2(cbbDept.Text), Me.cbbLine.Text,
                            Me.cbbPartId.Text.Trim)

        Dim dts As DataTable
        dts = DbOperateReportUtils.GetDataTable(strSQL)
        Return dts
    End Function

    '根据模板导出
    Private Function TemplateDataOutPutExcel(ByVal dt As DataTable, ByVal OutPutFile As String, _
                                               ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(_NgDay_TemplateFile)
            workBookDesigner.Workbook = wk
            dt.TableName = "Item"
            workBookDesigner.SetDataSource(dt)
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

    'EXCEL导出
    Private Sub EXCELOUTPUT()
        Dim reportFileName As String = ""
        Dim dts As DataTable = Nothing
        Dim bFlag As Boolean = True
        Dim errorMsg As String = Nothing
        Dim directoryPath As String = "c:\MesExport\"
        Dim ng_TempoutputFile As String

        Dim dtPartStr As DataTable = New DataTable()


        If rdoCustomer.Checked Then
            reportFileName = String.Format("{0}（按客户导出）{1}～{2}部门{3}", Me.Text,
                                           Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"),
                                           Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"),
                                           cbbDept.Text)
            dts = GetExcelDataTable("1")
            If CheckHaveData(dts) = False Then Exit Sub
            SetDataNgTotalRate(dts)
        ElseIf rdoSeries.Checked Then
            reportFileName = String.Format("{0}（按系列导出）{1}～{2}部门{3}", Me.Text,
                                           Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"),
                                           Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"),
                                           cbbDept.Text)
            dts = GetExcelDataTable("2")
            If CheckHaveData(dts) = False Then Exit Sub
            SetDataNgTotalRateBySeries(dts)
            SetDataST(dts)
        ElseIf rdoLine.Checked Then
            reportFileName = String.Format("{0}（按指定线别{3}导出）{1}～{2}", Me.Text,
                                           Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"), Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"),
                                           cbbLine.Text.Trim)
            dts = GetExcelDataTable("3")
            If CheckHaveData(dts) = False Then Exit Sub
            SetDataNgTotalRate(dts)
        ElseIf rdoAllLine.Checked Then
            reportFileName = String.Format("{0}（所有线别导出）{1}～{2}", Me.Text, Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"), Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"))
            dts = GetExcelDataTable("4")
            If CheckHaveData(dts) = False Then Exit Sub
            SetDataNgTotalRate(dts)
        ElseIf rdoPartId.Checked Then
            Dim partId As String = cbbPartId.Text.Trim
            If cbbPartId.Text.Trim.Contains(",") Then
                partId = cbbPartId.Text.Trim.Split(",")(0) + "包括子料号"
            End If
            reportFileName = String.Format("{0}（指定料号{3}导出）{1}～{2}", Me.Text,
                                           Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"), Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"),
                                           partId)
            'dts = GetExcelDataTable("5")
            'add by 马跃平 20180201
            Dim ds As DataSet = GetExcelDataSetByPartIDStr()
            dts = ds.Tables(0)
            If ds.Tables(1).Rows.Count > 0 Then
                totalRate = ds.Tables(1).Rows(0)(0).ToString
            Else
                totalRate = "0"
            End If
            dtPartStr = ds.Tables(2)
            'end

            If CheckHaveData(dts) = False Then Exit Sub
            If CheckHaveDataByColumn(dts) = False Then Exit Sub
        ElseIf rdoCustomerSeries.Checked Then
            reportFileName = String.Format("{0}（按系列或客户导出）{1}～{2}", Me.Text, Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"), Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"))
            dts = GetExcelDataTable("6")
            If CheckHaveData(dts) = False Then Exit Sub
        ElseIf rdoDept.Checked Then
            reportFileName = String.Format("{0}（部门导出）{1}～{2}", Me.Text, Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"), Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"))
            dts = GetExcelDataTable("7")
            SetDataNgTotalRate(dts)
        ElseIf rdoPG.Checked Then
            reportFileName = String.Format("{0}（P管制图导出）{1}～{2}料号_{3}不良_{4}", Me.Text, Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"),
                                           Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"), cbbPartId.Text.Trim, cbbNgStationId.Text)
            dts = GetExcelDataTable("8")
            If CheckHaveData(dts) = False Then Exit Sub
        ElseIf rdoTrend.Checked Then
            reportFileName = String.Format("{0}（不良趋势导出）{1}～{2}料号_{3}不良_{4}", Me.Text, Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"),
                                           Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"), cbbPartId.Text.Trim, cbbNgStationId.Text)
            dts = GetExcelDataTable("9")
            If CheckHaveData(dts) = False Then Exit Sub
        ElseIf rdoNgDay.Checked Then

            '不良生产日报表
            reportFileName = String.Format("{0}（不良生产日报）{1}～{2}部门{3}", Me.Text,
                                      Convert.ToDateTime(dtpStart.Text).ToString("yyyy年MM月dd日"),
                                      Convert.ToDateTime(dtpEnd.Text).ToString("yyyy年MM月dd日"),
                                      cbbDept.Text)
            dts = GetNgDayReportTable()
            If CheckHaveData(dts) = False Then Exit Sub
            Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
            Dim sDete As String
            sDete = Convert.ToDateTime(dtpStart.Text).ToString("yyyy/MM/dd") & " 至 " & Convert.ToDateTime(dtpEnd.Text).ToString("yyyy/MM/dd")
            dics.Add("LineId", Me.cbbLine.Text)
            dics.Add("PartId", Me.cbbPartId.Text.Trim)
            dics.Add("sDete", sDete)
            If dts.Rows.Count > 0 Then
                dics.Add("SUM_ProQty", dts.Rows(0)("SUM_ProQty").ToString)
                dics.Add("SUM_ScanQty", dts.Rows(0)("SUM_ScanQty").ToString)
                dics.Add("J1_ProQty", dts.Rows(0)("J1_ProQty").ToString)
                dics.Add("J2_ProQty", dts.Rows(0)("J2_ProQty").ToString)
                dics.Add("J3_ProQty", dts.Rows(0)("J3_ProQty").ToString)
                dics.Add("J4_ProQty", dts.Rows(0)("J4_ProQty").ToString)
                dics.Add("J5_ProQty", dts.Rows(0)("J5_ProQty").ToString)
                dics.Add("J1_NGQty", dts.Rows(0)("J1_NGQty").ToString)
                dics.Add("J2_NGQty", dts.Rows(0)("J2_NGQty").ToString)
                dics.Add("J3_NGQty", dts.Rows(0)("J3_NGQty").ToString)
                dics.Add("J4_NGQty", dts.Rows(0)("J4_NGQty").ToString)
                dics.Add("J5_NGQty", dts.Rows(0)("J5_NGQty").ToString)

                dics.Add("J1_ScanQty", dts.Rows(0)("J1_ScanQty").ToString)
                dics.Add("J2_ScanQty", dts.Rows(0)("J2_ScanQty").ToString)
                dics.Add("J3_ScanQty", dts.Rows(0)("J3_ScanQty").ToString)
                dics.Add("J4_ScanQty", dts.Rows(0)("J4_ScanQty").ToString)
                dics.Add("J5_ScanQty", dts.Rows(0)("J5_ScanQty").ToString)
            End If
            'o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"
            ng_TempoutputFile = String.Format(directoryPath & "{0}.xlsx", reportFileName)
            If TemplateDataOutPutExcel(dts, ng_TempoutputFile, dics, errorMsg) = True Then
                MessageUtils.ShowInformation("成功导出!")
                '增加打开EXCEL文件
                System.Diagnostics.Process.Start(ng_TempoutputFile)
                Exit Sub
            End If

            'SetDataNgTotalRate(dts)
        End If

        'Dim directoryPath As String = "c:\MesExport\"
        Dim o_TempoutputFile As String = String.Format(directoryPath & "{0}.xlsx", reportFileName)

        If Directory.Exists(directoryPath) = False Then
            Directory.CreateDirectory(directoryPath)
        End If


        If rdoCustomer.Checked Or rdoAllLine.Checked Or rdoDept.Checked Then
            bFlag = Import2ExcelByAs(o_TempoutputFile, dts, errorMsg)
        ElseIf rdoSeries.Checked Then
            bFlag = Import2ExcelBySeries(o_TempoutputFile, dts, errorMsg)
        ElseIf rdoLine.Checked Then
            bFlag = ImportExcelByLineId(o_TempoutputFile, dts, errorMsg)
        ElseIf rdoCustomerSeries.Checked Then
            bFlag = ImportExcelByCusSer(o_TempoutputFile, dts, errorMsg)
        ElseIf rdoPartId.Checked Then
            bFlag = ImportExcelByPartId(o_TempoutputFile, dts, errorMsg, dtPartStr)
        ElseIf rdoPG.Checked Then
            bFlag = ImportExcelByPG(o_TempoutputFile, dts, errorMsg)
        ElseIf rdoTrend.Checked Then
            bFlag = ImportExcelByTrend(o_TempoutputFile, dts, errorMsg)
        End If
        If bFlag = False Then
            MessageUtils.ShowError(errorMsg)
            Throw New Exception(errorMsg)
        Else
            MessageUtils.ShowInformation("成功导出!")
            '增加打开EXCEL文件
            System.Diagnostics.Process.Start(o_TempoutputFile)
        End If

    End Sub

    '设置不良总计比率
    Private Sub SetDataNgTotalRate(dt As DataTable)
        Dim TotalQty As String = "0"
        Dim CurRowQty As String
        If dt.Rows.Count > 0 Then
            TotalQty = dt.Rows(0)(dt.Columns.Count - 1).ToString
        End If
        If TotalQty = 0 Then
            Exit Sub
        End If

        For index As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(index)(1).ToString.Contains("不良率") Then
                CurRowQty = dt.Rows(index - 1)(dt.Columns.Count - 1).ToString
                dt.Rows(index)(dt.Columns.Count - 1) = Math.Round((CDbl(CurRowQty) / CDbl(TotalQty)) * 100, 2)
            End If
        Next
    End Sub

    '设置不良总计比率
    Private Sub SetDataNgTotalRateBySeries(dt As DataTable)
        Dim TotalQty As String = "0"
        Dim CurRowQty As String
        If dt.Rows.Count > 0 Then
            TotalQty = dt.Rows(0)(dt.Columns.Count - 1).ToString
        End If
        If TotalQty = 0 Then
            Exit Sub
        End If

        For index As Integer = dt.Rows.Count - 1 To 0 Step -1
            If dt.Rows(index)(1).ToString.Contains("不良率") Then
                For cIndex As Integer = 2 To dt.Columns.Count - 1
                    CurRowQty = dt.Rows(index - 2)(cIndex).ToString
                    TotalQty = dt.Rows(0)(cIndex).ToString
                    dt.Rows(index)(cIndex) = Math.Round((CDbl(CurRowQty) / CDbl(TotalQty)) * 100, 2)
                Next
            End If
        Next
    End Sub

    '设置不良总计比率
    Private Sub SetDataST(dt As DataTable)
        For index As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(index)(1).ToString.Contains("達成狀況") Then
                '目標值:dt.Rows(index - 2)(cIndex)
                '不良率:dt.Rows(index - 1)(cIndex)
                For cIndex As Integer = 2 To dt.Columns.Count - 1
                    dt.Rows(index)(cIndex) = IIf(CDec(dt.Rows(index - 1)(cIndex)) <= CDec(dt.Rows(index - 2)(cIndex)), "●", "◎")
                Next
            End If
        Next
    End Sub

    '检查数据
    Private Function CheckData() As Boolean
        If rdoLine.Checked = True Then
            If cbbLine.Text.Trim = "ALL" Or cbbLine.Text.Trim = "" Then
                MessageUtils.ShowError("请选择线别！")
                cbbLine.Focus()
                Return False
            End If
        ElseIf rdoPartId.Checked Then
            If cbbPartId.Text.Trim = "" Then
                MessageUtils.ShowError("请选择料号！")
                cbbPartId.Focus()
                Return False
            End If
        ElseIf rdoPG.Checked Then
            If cbbPartId.Text.Trim = "" Then
                MessageUtils.ShowError("请选择料号！")
                cbbPartId.Focus()
                Return False
            End If
        ElseIf rdoTrend.Checked Then
            If cbbPartId.Text.Trim = "" Then
                MessageUtils.ShowError("请选择料号！")
                cbbPartId.Focus()
                Return False
            End If
            If txtNgRate.Text.Trim = "" Then
                MessageUtils.ShowError("请输入目标不良率！")
                txtNgRate.Focus()
                Return False
            End If
            If HalfWidthDecimalChecker(txtNgRate.Text.Trim, 10, 3) = False Then
                MessageUtils.ShowError("请输入正确目标不良率！")
                txtNgRate.Focus()
                Return False
            End If

        End If

        Return True
    End Function

    '设置料号数据
    Private Sub SetPartIdList(comBox As System.Windows.Forms.ComboBox)
        Dim strSQL As String =
            " select distinct partid from m_mainmo_t MM" &
            " inner join REPORTDB.dbo.m_AssysnDReportTotal_t CT " &
            " on MM .Moid = CT.Moid " &
            " where CT.Teamid = '{0}' " &
            " and Convert(varchar(10), CT.Intime,111) BETWEEN '{1}' AND '{2}'" &
            " and MM.Factory = '{3}' and MM.profitcenter = '{4}' "
        strSQL = String.Format(strSQL, cbbLine.Text, dtpStart.Value.ToString("yyyy/MM/dd"), dtpEnd.Value.ToString("yyyy/MM/dd"),
                               VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

        BindCombox(strSQL, comBox, "partid", "partid")
    End Sub

    '清空所有数据
    Private Sub ClearAllData()
        cbbDept.Text = ""
        cbbDept.SelectedIndex = -1
        cbbLine.SelectedIndex = -1
        cbbCustomer.SelectedIndex = -1
        cbbSeries.SelectedIndex = -1
        cbbPartId.SelectedIndex = -1
        cbbNgStationId.SelectedIndex = -1
        cbbLine.Text = ""
        txtNgRate.Text = ""
    End Sub

    '设置控件编辑性
    Private Sub SetControlEdit(ByVal selectval As SelectType)
        ClearAllData()
        SetAllControlEnabled(True)
        Select Case selectval
            Case SelectType.Customer
                cbbCustomer.Enabled = False
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.Series
                cbbSeries.Enabled = False
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.LineId
                cbbCustomer.Enabled = False
                cbbSeries.Enabled = False
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.AllLine
                cbbDept.Enabled = False
                cbbLine.Enabled = False
                btnSelectLine.Enabled = False
                cbbCustomer.Enabled = False
                cbbSeries.Enabled = False
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.PartId
                cbbCustomer.Enabled = False
                cbbSeries.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.CustomerOrSeries
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.Dept
                cbbDept.Enabled = False
                cbbNgStationId.Enabled = False
                cbbPartId.Enabled = False
                btnGetPartId.Enabled = False
                btnGetSubPartId.Enabled = False
                cbbLine.Enabled = False
                btnSelectLine.Enabled = False
                txtNgRate.Enabled = False
            Case SelectType.PG
                txtNgRate.Enabled = False
                cbbCustomer.Enabled = False
                cbbSeries.Enabled = False
                btnGetSubPartId.Enabled = False
            Case SelectType.Trend
                cbbCustomer.Enabled = False
                cbbSeries.Enabled = False
                btnGetSubPartId.Enabled = False

            Case SelectType.NGLD
                'add by hgd 20171116 立德不良日报
                cbbCustomer.Enabled = False

                btnGetSubPartId.Enabled = False
                cbbNgStationId.Enabled = False
                txtNgRate.Enabled = False
        End Select
    End Sub

    '设置所有控件编辑性
    Private Sub SetAllControlEnabled(bFlag As Boolean)
        cbbDept.Enabled = bFlag
        cbbLine.Enabled = bFlag
        btnSelectLine.Enabled = bFlag
        cbbCustomer.Enabled = bFlag
        cbbSeries.Enabled = bFlag
        cbbPartId.Enabled = bFlag
        btnGetPartId.Enabled = bFlag
        btnGetSubPartId.Enabled = bFlag
        cbbNgStationId.Enabled = bFlag
        txtNgRate.Enabled = bFlag
    End Sub

    '取得不良工站不良率
    Private Function GetSeriesNgTargetbyStation() As String
        Dim result As String = "0"
        Dim strSQL As String
        strSQL = "EXEC m_QueryTotalGetSeriesNgTargetbyStation '{0}', '{1}', '{2}','{3}','{4}'"
        strSQL = String.Format(strSQL, Me.dtpStart.Text, Getid(cbbNgStationId.Text), cbbPartId.Text, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            result = dt.Rows(0)("Quarter").ToString
        End If
        Return result
    End Function

#End Region

#Region "报表导出用"

    ''' <summary>
    ''' 月报导出方法
    ''' </summary>
    ''' <param name="outPutFile"></param>
    ''' <param name="dt"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Import2ExcelByAs(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "生产不良统计月报"
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字样式
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            '生成行1 标题行   
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 35)

            '设置显示开始位置
            Dim startPos As Integer = 1
            '从第二行开始 列显示 
            For i As Integer = 0 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            cells.SetRowHeight(startPos, 40) ' 设置行高度

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    If i Mod 2 = 0 And i > 1 Then ' 
                        cells(startPos + 1 + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style3)
                    Else
                        cells(startPos + 1 + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style2)
                    End If
                Next

                If i Mod 2 = 1 And i > 1 And i < rownum - 1 Then ' 第一列中间几行合并
                    cells.Merge(i, 0, 2, 1)
                    cells(i, 0).SetStyle(style2)
                End If
            Next

            cells.Merge(startPos, 0, 1, 2) '第一行
            cells.Merge(startPos + 1, 0, 1, 2) '第二行
            cells.Merge(rownum + startPos - 1, 0, 1, 2) '最后二行
            cells.Merge(rownum + startPos, 0, 1, 2) '最后一行
            cells(startPos, 0).SetStyle(style2)
            cells(startPos + 1, 0).SetStyle(style2)
            cells(rownum + startPos - 1, 0).SetStyle(style2)
            cells(rownum + startPos, 0).SetStyle(style2)

            Dim chartIndex As Integer = sheet.Charts.Add(Charts.ChartType.Column, rownum + 4, 0, 40, colnum)
            Dim chart As Charts.Chart = sheet.Charts(chartIndex)
            chart.Title.Text = "不良率"
            chart.Title.TextFont.IsBold = True
            chart.Title.TextFont.Size = 16
            Dim series As String = String.Format("C{0}:{1}{0}", (rownum + startPos + 1).ToString, GetColumnName(colnum))
            chart.NSeries.Add(series, False)
            chart.NSeries.CategoryData = String.Format("C{0}:{1}{0}", startPos + 1, GetColumnName(colnum))
            '//每个折线向显示出值
            chart.NSeries(0).DataLabels.ShowValue = True
            chart.NSeries(0).DataLabels.TextFont.Color = Color.Black
            chart.ShowLegend = False

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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
    ''' 月报导出方法
    ''' </summary>
    ''' <param name="outPutFile"></param>
    ''' <param name="dt"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Import2ExcelBySeries(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "生产不良统计月报"
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True
            styleTitle.Font.Name = "宋体"

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True
            style1.Font.Name = "宋体"

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            style2.Font.Name = "宋体"

            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字样式
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style3.Font.Name = "宋体"

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            '生成行1 标题行   
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 35)

            '设置显示开始位置
            Dim startPos As Integer = 1
            '从第二行开始 列显示 
            For i As Integer = 0 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            cells.SetRowHeight(startPos, 40) ' 设置行高度

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    If (i Mod 4 = 2 Or i Mod 4 = 3) And i > 1 Then ' 
                        cells(startPos + 1 + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style3)
                    Else
                        cells(startPos + 1 + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style2)
                    End If
                Next
                '合并第一列内容
                If i Mod 4 = 1 And i > 1 And i < rownum - 1 Then ' 第一列中间几行合并
                    cells.Merge(i - 2, 0, 4, 1)
                    cells(i - 2, 0).SetStyle(style2)
                End If
            Next

            cells.Merge(startPos, 0, 1, 2)     '第一行
            cells.Merge(startPos + 1, 0, 1, 2) '第二行
            cells.Merge(rownum + startPos - 3, 0, 1, 2) '最后第四行
            cells.Merge(rownum + startPos - 2, 0, 1, 2) '最后第三行
            cells.Merge(rownum + startPos - 1, 0, 1, 2) '最后第二行
            cells.Merge(rownum + startPos, 0, 1, 2)     '最后第一行
            cells(startPos, 0).SetStyle(style2)
            cells(startPos + 1, 0).SetStyle(style2)
            cells(rownum + startPos - 1, 0).SetStyle(style2)
            cells(rownum + startPos, 0).SetStyle(style2)

            Dim chartIndex As Integer = sheet.Charts.Add(Charts.ChartType.Column, rownum + 4, 0, 60, colnum)
            Dim chart As Charts.Chart = sheet.Charts(chartIndex)
            chart.Title.Text = "序列别不良率"
            chart.Title.TextFont.IsBold = True
            chart.Title.TextFont.Size = 16
            Dim series As String = String.Format("C{0}:{1}{2}", (rownum + startPos - 1).ToString, GetColumnName(colnum), (rownum + startPos).ToString)
            chart.NSeries.Add(series, False)
            chart.NSeries.CategoryData = String.Format("C{0}:{1}{0}", startPos + 1, GetColumnName(colnum))
            'chart.ShowLegend = True

            chart.NSeries(0).Name = "目標不良率"
            chart.NSeries(1).Name = "实际值"
            '//每个折线向显示出值
            chart.NSeries(0).DataLabels.ShowValue = True
            chart.NSeries(1).DataLabels.ShowValue = True
            '设置y轴的样式
            chart.ValueAxis.TickLabelPosition = TickLabelPositionType.Low
            chart.ValueAxis.TickLabels.Font.Color = Color.Gray
            chart.Legend.Position = LegendPositionType.Bottom

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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

    Private Function ImportExcelByCusSer(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "料号对应线别数据时间：{0} 至{1}"
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True
            styleTitle.IsTextWrapped = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            style2.IsTextWrapped = True

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            titleName = String.Format(titleName, dtpStart.Value, dtpEnd.Value.AddHours(23).AddMinutes(59).AddSeconds(59))
            '生成行1 标题行   
            cells.Merge(0, 0, 10, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '

            '设置显示开始位置
            Dim startPos As Integer = 11
            '从第二行开始 列显示 
            For i As Integer = 0 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            cells.SetRowHeight(startPos, 33) ' 设置行高度

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    cells(startPos + 1 + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                    cells(startPos + 1 + i, k).SetStyle(style2)
                    cells.SetRowHeight(startPos + 1 + i, 30)
                Next
            Next

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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

    Private Function ImportExcelByLineId(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "依线别不良数据汇总"
        Dim partNo As String = String.Format("线别：{0}", cbbLine.Text.Trim.ToUpper)
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True
            styleTitle.IsTextWrapped = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            style2.IsTextWrapped = True

            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字居中 
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style3.VerticalAlignment = TextAlignmentType.Center

            Dim style4 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style4.VerticalAlignment = TextAlignmentType.Center

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            '生成行1 标题行   
            titleName = String.Format(titleName, dtpStart.Value, dtpEnd.Value)
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 30) ' 设置行高度
            cells.SetRowHeight(1, 20) ' 设置行高度
            cells.SetRowHeight(2, 30) ' 设置行高度
            cells.SetRowHeight(3, 40) ' 设置行高度
            cells.SetRowHeight(4, 20) ' 设置行高度

            '第二行写入料号
            cells.Merge(1, 0, 1, colnum)     '合并单元格
            cells(1, 0).PutValue(partNo)
            cells(1, 0).SetStyle(style4)
            '设置显示开始位置
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells.Merge(2, 0, 1, 2) '合并单元格
            cells.Merge(3, 0, 1, 2) '合并单元格
            cells.Merge(4, 0, 1, 2) '合并单元格
            cells.Merge(2, dt.Columns.Count - 1, 2, 1) '合并单元格
            cells(2, 0).PutValue("日期")
            cells(3, 0).PutValue("料号")
            cells(2, 0).SetStyle(style2)
            cells(3, 0).SetStyle(style2)
            cells(4, 0).SetStyle(style2)
            cells(2, dt.Columns.Count - 1).SetStyle(style2)
            cells.SetColumnWidth(2, 12)                     ' 第二列列宽度
            cells.SetColumnWidth(dt.Columns.Count - 1, 10)  ' 最后一列宽度
            '从第三行开始 列显示 
            For i As Integer = 2 To colnum - 1
                If dt.Columns(i).ColumnName.Contains("#") Then
                    cells(2, i).PutValue(dt.Columns(i).ColumnName.Split("#")(0))
                    cells(3, i).PutValue(dt.Columns(i).ColumnName.Split("#")(1))
                    cells(2, i).SetStyle(style2)
                    cells(3, i).SetStyle(style2)
                Else
                    cells(2, i).PutValue(dt.Columns(i).ColumnName)
                    cells(3, i).PutValue(dt.Columns(i).ColumnName)
                End If
            Next

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To colnum - 1 '列
                    cells(4, i).PutValue(GetObjectValue(dt.Rows(0)(i)))
                    cells(4, i).SetStyle(style2)
                    cells.SetColumnWidth(i, 10)
                Next
            End If

            Dim startPos As Integer = 4
            For i As Integer = 1 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    cells.SetRowHeight(startPos + i, 12)
                    If dt.Rows(i)(0).ToString.Contains("合計率") Then ' 加符号%
                        cells(startPos + i, k).SetStyle(style3)
                        cells(startPos + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                    Else
                        cells(startPos + i, k).SetStyle(style2)
                        cells(startPos + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                    End If
                Next
            Next

            '第一列数据合并
            Dim hashTable As Hashtable = GetHashTable(dt, 0)

            For Each de As DictionaryEntry In hashTable
                cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 0, de.Value.ToString.Split("|")(2), 1) '合并单元格
                cells(de.Value.ToString.Split("|")(1) + startPos, 0).PutValue(de.Value.ToString.Split("|")(0))
                cells(de.Value.ToString.Split("|")(1) + startPos, 0).SetStyle(style2)
            Next

            For i As Integer = 1 To dt.Rows.Count - 1 '行
                If dt.Rows(i)(0).ToString.Contains("合計") Then
                    cells.Merge(i + startPos, 0, 2, 2) '合并单元格
                    cells(i + startPos, 0).PutValue("合計")
                    cells(i + startPos, 0).SetStyle(style2)
                    i = i + 1
                End If
            Next

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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

    Private Function ImportExcelByPartId(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String, ByVal dtPartStr As DataTable) As Boolean
        Dim titleName As String = "料号不良数据汇总"
        Dim partNo As String = String.Format("料号：{0}", cbbPartId.Text.Trim)
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True
            styleTitle.IsTextWrapped = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            style2.IsTextWrapped = True

            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字居中 
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style3.VerticalAlignment = TextAlignmentType.Center

            Dim style4 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style4.VerticalAlignment = TextAlignmentType.Center

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            titleName = String.Format(titleName, dtpStart.Value, dtpEnd.Value)
            '生成行1 标题行   


            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 30) ' 设置行高度
            cells.SetRowHeight(1, 20) ' 设置行高度
            cells.SetRowHeight(2, 20) ' 设置行高度
            cells.SetRowHeight(3, 20) ' 设置行高度
            cells.SetRowHeight(4, 20) ' 设置行高度

            ' update by 马跃平 20180201
            ''第二行写入料号
            'cells.Merge(1, 0, 1, colnum)     '合并单元格
            'cells(1, 0).PutValue(partNo)
            'cells(1, 0).SetStyle(style4)


            '设置显示开始位置
            cells.SetColumnWidth(2, 15)                     ' 第二列列宽度

            cells.Merge(0, 0, 2, colnum) '合并单元格
            cells.Merge(2, 0, 1, 3) '合并单元格
            cells.Merge(3, 0, 1, 3) '合并单元格
            cells.Merge(4, 0, 1, 3) '合并单元格
            cells(2, 0).PutValue("日期")
            cells(3, 0).PutValue("线别")
            cells(2, 0).SetStyle(style2)
            cells(3, 0).SetStyle(style2)
            cells(4, 0).SetStyle(style2)

            cells(4, 0).PutValue("料号") 'add by 马跃平 20180201
            'If dt.Columns(3).ColumnName.Split("#").Length = 3 Then
            '    cells.Merge(5, 0, 1, 3) '合并单元格
            '    cells(4, 0).PutValue("料号")
            '    cells.SetRowHeight(4, 25) ' 设置行高度
            'End If

            Dim startPos As Integer = 4
            '有子料号时
            If dt.Columns(3).ColumnName.Split("#").Length = 3 Then
                startPos = 5 '设置新的位置
                '从第三行开始 列显示 
                For i As Integer = 3 To colnum - 1
                    cells(2, i).PutValue(dt.Columns(i).ColumnName.Split("#")(0))
                    cells(3, i).PutValue(dt.Columns(i).ColumnName.Split("#")(1))
                    cells(4, i).PutValue(dt.Columns(i).ColumnName.Split("#")(2))
                    cells(2, i).SetStyle(style2)
                    cells(3, i).SetStyle(style2)
                    cells(4, i).SetStyle(style2)
                Next
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To colnum - 1 '列
                        cells(5, i).PutValue(GetObjectValue(dt.Rows(0)(i)))
                        cells(5, i).SetStyle(style2)
                        cells.SetColumnWidth(i, 10)
                    Next
                End If
            Else
                '从第三行开始 列显示 
                For i As Integer = 3 To colnum - 1
                    cells(2, i).PutValue(dt.Columns(i).ColumnName.Split("#")(0))
                    cells(3, i).PutValue(dt.Columns(i).ColumnName.Split("#")(1))
                    cells(2, i).SetStyle(style2)
                    cells(3, i).SetStyle(style2)
                    'add by 马跃平20180201
                    Dim PartIDStr As String = ""
                    Dim drl As DataRow() = dtPartStr.Select("item='" + dt.Columns(i).ColumnName + "'")
                    If drl.Length > 0 Then
                        PartIDStr = drl(0)(1).ToString()
                    End If
                    cells(4, i).PutValue(PartIDStr)
                Next
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To colnum - 1 '列
                        'cells(4, i).PutValue(GetObjectValue(dt.Rows(0)(i)))
                        'cells(4, i).SetStyle(style2)
                        'add by 马跃平 20180201
                        cells(5, i).PutValue(GetObjectValue(dt.Rows(0)(i)))
                        cells(5, i).SetStyle(style2)
                        cells.SetColumnWidth(i, 10)
                    Next
                End If
            End If

            'cells.SetRowHeight(startPos, 20) ' 设置行高度
            'Dim startPos As Integer = 4
            For i As Integer = 1 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    cells.SetRowHeight(startPos + i, 12)
                    If dt.Rows(i)(2).ToString.Contains("不良率") Then ' 加符号%
                        cells(startPos + i, k).SetStyle(style3)
                        cells(startPos + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                    Else
                        cells(startPos + i, k).SetStyle(style2)
                        cells(startPos + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                    End If
                Next
            Next

            '********************************* 总不良 **********************
            cells(dt.Rows.Count + startPos + 1, 0).PutValue("总不良")
            cells(dt.Rows.Count + startPos + 1, 0).SetStyle(style2)
            cells(dt.Rows.Count + startPos + 1, 1).PutValue(GetDecValue(totalRate))
            cells(dt.Rows.Count + startPos + 1, 1).SetStyle(style3)
            '********************************* 总不良 **********************

            '第一列数据合并
            Dim hashTable As Hashtable = GetHashTable(dt, 0)

            For Each de As DictionaryEntry In hashTable
                If de.Key = "合計" Then
                    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 0, de.Value.ToString.Split("|")(2), 2) '合并单元格
                Else
                    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 0, de.Value.ToString.Split("|")(2), 1) '合并单元格
                End If
                cells(de.Value.ToString.Split("|")(1) + startPos, 0).PutValue(de.Value.ToString.Split("|")(0))
                cells(de.Value.ToString.Split("|")(1) + startPos, 0).SetStyle(style2)
            Next

            '第二列数据合并
            Dim hashTable2 As Hashtable = Nothing
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                hashTable2 = GetJXHashTable(dt, 1)
            Else

                hashTable2 = GetHashTable(dt, 1)
            End If
            For Each de As DictionaryEntry In hashTable2
                cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 1, de.Value.ToString.Split("|")(2), 1) '合并单元格
                cells(de.Value.ToString.Split("|")(1) + startPos, 1).PutValue(de.Value.ToString.Split("|")(0))
                cells(de.Value.ToString.Split("|")(1) + startPos, 1).SetStyle(style2)
            Next

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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
    ''' 月报导出方法 -PG
    ''' </summary>
    ''' <param name="outPutFile"></param>
    ''' <param name="dt"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ImportExcelByPG(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "P管制图_" + IIf(cbbNgStationId.Text.Trim = "", "ALL", cbbNgStationId.Text.Trim)
        Dim LinePartNo As String = String.Format("料号：{0}", cbbPartId.Text.Trim)
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字样式
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            '生成行1 标题行   
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 35)

            '第二行写入料号
            cells.Merge(1, 0, 1, 7)     '合并单元格
            cells(1, 0).PutValue(LinePartNo)
            cells(2, 0).PutValue("序号")
            cells(3, 0).PutValue("日期")
            cells(4, 0).PutValue("线别")
            cells(5, 0).PutValue("节次")
            cells(6, 0).PutValue("生产总数")
            cells(7, 0).PutValue("不良总数")
            cells(8, 0).PutValue("不良率")
            cells(9, 0).PutValue("UCL")
            cells(10, 0).PutValue("LCL")
            cells(11, 0).PutValue("CL")

            '设置显示开始位置
            Dim startPos As Integer = 2
            '从第三行开始 列显示 
            For i As Integer = 1 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            'cells.SetRowHeight(startPos, 40) ' 设置行高度

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 1 To colnum - 1 '列
                    If i > 4 Then ' 
                        cells(startPos + 1 + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style3)
                    Else
                        cells(startPos + 1 + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style2)
                    End If
                Next
            Next

            '合并列数据
            Dim hashTable As Hashtable = GetHashTableCol(dt, 0)
            For Each de As DictionaryEntry In hashTable
                cells.Merge(3, de.Value.ToString.Split("|")(1), 1, de.Value.ToString.Split("|")(2)) '合并单元格
                cells(3, de.Value.ToString.Split("|")(1)).PutValue(de.Value.ToString.Split("|")(0))
                cells(3, de.Value.ToString.Split("|")(1)).SetStyle(style2)
            Next

            hashTable.Clear()
            hashTable = GetHashTableCol(dt, 1)
            For Each de As DictionaryEntry In hashTable
                cells.Merge(4, de.Value.ToString.Split("|")(1), 1, de.Value.ToString.Split("|")(2)) '合并单元格
                cells(4, de.Value.ToString.Split("|")(1)).PutValue(de.Value.ToString.Split("|")(0).Split("$")(1))
                cells(4, de.Value.ToString.Split("|")(1)).SetStyle(style2)
            Next

            Dim chartIndex As Integer = sheet.Charts.Add(Charts.ChartType.Line, rownum + 7, 0, 40, colnum)
            Dim chart As Charts.Chart = sheet.Charts(chartIndex)
            chart.Title.Text = "不良P管制图"
            chart.Title.TextFont.IsBold = True
            chart.Title.TextFont.Size = 16

            Dim series As String = String.Format("B9:{0}12", GetColumnName(colnum))
            chart.NSeries.Add(series, False)
            chart.NSeries.CategoryData = String.Format("B3:{0}3", GetColumnName(colnum))
            chart.ShowLegend = True

            For i As Integer = 0 To chart.NSeries.Count - 1
                chart.NSeries(i).Name = cells(i + 8, 0).Value.ToString()
                ' //设置每个值坐标点的样式
                chart.NSeries(i).MarkerStyle = ChartMarkerType.Automatic
                chart.NSeries(i).Type = ChartType.LineWithDataMarkers
                chart.NSeries(i).MarkerSize = 5
                '//每个折线向显示出值
                'chart.NSeries(i).DataLabels.ShowValue = True
                'chart.NSeries(i).DataLabels.TextFont.Color = Color.Black
            Next
            '//每个折线向显示出值
            chart.NSeries(0).DataLabels.ShowValue = True
            chart.NSeries(0).DataLabels.TextFont.Color = Color.Black
            chart.NSeries(1).DataLabels.ShowValue = True
            chart.NSeries(1).DataLabels.TextFont.Color = Color.Black

            '设置x轴的样式
            chart.CategoryAxis.TickLabelPosition = TickLabelPositionType.NextToAxis
            chart.CategoryAxis.TickLabels.Font.Color = Color.Gray
            'chart.CategoryAxis.Title.Text = "不良率（%）"

            '设置y轴的样式
            chart.ValueAxis.TickLabelPosition = TickLabelPositionType.Low
            chart.ValueAxis.TickLabels.Font.Color = Color.Gray
            chart.ValueAxis.Title.Text = "不良率（%）"
            'chart.ValueAxis.MajorUnit = 0.1 '设置y轴开始最大值
            'chart.ValueAxis.MaxValue = 1 '设置y轴开始最大值
            'chart.ValueAxis.MinValue = 0 '
            chart.Legend.Position = LegendPositionType.Bottom

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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
    ''' 月报导出方法 - 不良趋势导出
    ''' </summary>
    ''' <param name="outPutFile"></param>
    ''' <param name="dt"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ImportExcelByTrend(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "不良趋势图外观"
        Dim LinePartNo As String = String.Format("线别：{0}  料号：{1}", cbbLine.Text.ToUpper, cbbPartId.Text.Trim)
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.Custom = "0.00%" '文字样式
            style3.HorizontalAlignment = TextAlignmentType.Center '文字居中 

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count

            '生成行1 标题行   
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 35)

            '第二行写入料号
            cells.Merge(1, 0, 1, 7)     '合并单元格
            cells(1, 0).PutValue(LinePartNo)
            cells(2, 0).PutValue("序号")
            cells(3, 0).PutValue("日期")
            cells(4, 0).PutValue("节次")
            cells(5, 0).PutValue("生产总数")
            cells(6, 0).PutValue("不良总数")
            cells(7, 0).PutValue("目标不良率")
            cells(8, 0).PutValue("实际不良率")
            cells(9, 0).PutValue("不良原因")
            cells(10, 0).PutValue("改善措施")

            '设置显示开始位置
            Dim startPos As Integer = 2
            '从第三行开始 列显示 
            For i As Integer = 1 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            'cells.SetRowHeight(startPos, 40) ' 设置行高度

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 1 To colnum - 1 '列
                    If i > 3 Then ' 
                        cells(startPos + 1 + i, k).PutValue(GetDecValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style3)
                    Else
                        cells(startPos + 1 + i, k).PutValue(GetObjectValue(dt.Rows(i)(k)))
                        cells(startPos + 1 + i, k).SetStyle(style2)
                    End If
                Next
            Next

            '合并列数据
            Dim hashTable As Hashtable = GetHashTableCol(dt, 0)
            For Each de As DictionaryEntry In hashTable
                cells.Merge(3, de.Value.ToString.Split("|")(1), 1, de.Value.ToString.Split("|")(2)) '合并单元格
                cells(3, de.Value.ToString.Split("|")(1)).PutValue(de.Value.ToString.Split("|")(0))
                cells(3, de.Value.ToString.Split("|")(1)).SetStyle(style2)
            Next

            Dim chartIndex As Integer = sheet.Charts.Add(Charts.ChartType.Line, rownum + 7, 0, 40, colnum)
            Dim chart As Charts.Chart = sheet.Charts(chartIndex)
            chart.Title.Text = "不良趋势图"
            chart.Title.TextFont.IsBold = True
            chart.Title.TextFont.Size = 16

            Dim series As String = String.Format("B8:{0}9", GetColumnName(colnum))
            chart.NSeries.Add(series, False)
            chart.NSeries.CategoryData = String.Format("B3:{0}3", GetColumnName(colnum))
            chart.ShowLegend = True

            For i As Integer = 0 To chart.NSeries.Count - 1
                chart.NSeries(i).Name = cells(i + 7, 0).Value.ToString()
                ' //设置每个值坐标点的样式
                chart.NSeries(i).MarkerStyle = ChartMarkerType.Automatic
                chart.NSeries(i).Type = ChartType.LineWithDataMarkers
                chart.NSeries(i).MarkerSize = 5

                '//每个折线向显示出值
                chart.NSeries(1).DataLabels.ShowValue = True
                chart.NSeries(1).DataLabels.TextFont.Color = Color.Black
            Next

            '设置x轴的样式
            chart.CategoryAxis.TickLabelPosition = TickLabelPositionType.NextToAxis
            chart.CategoryAxis.TickLabels.Font.Color = Color.Gray
            'chart.CategoryAxis.Title.Text = "不良率（%）"

            '设置y轴的样式
            chart.ValueAxis.TickLabelPosition = TickLabelPositionType.Low
            chart.ValueAxis.TickLabels.Font.Color = Color.Gray
            chart.ValueAxis.Title.Text = "不良率（%）"
            'chart.ValueAxis.MajorUnit = 0.1 '设置y轴开始最大值
            'chart.ValueAxis.MaxValue = 1 '设置y轴开始最大值
            'chart.ValueAxis.MinValue = 0 '
            chart.Legend.Position = LegendPositionType.Bottom

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
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

    '行单格合并
    Private Function GetHashTable(dt As DataTable, column As Integer) As Hashtable
        Dim alTemp As Hashtable = New Hashtable
        Dim tempObj As String = ""
        Dim posI As String = "0"
        Dim changeI As Integer = 0
        '合并单元格
        For i As Integer = 1 To dt.Rows.Count - 1 '行
            If dt.Rows(i)(column).ToString = "" Then
                Continue For
            End If
            If tempObj <> dt.Rows(i)(column).ToString Then
                tempObj = dt.Rows(i)(column).ToString
                posI = i
                changeI = 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(tempObj)
                End If
                alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
            Else
                changeI = changeI + 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(tempObj)
                    alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
                End If
            End If
        Next
        Return alTemp
    End Function

    Private Function GetJXHashTable(dt As DataTable, column As Integer) As Hashtable
        Dim alTemp As Hashtable = New Hashtable
        Dim tempObj As String = ""
        Dim posI As String = "0"
        Dim changeI As Integer = 0
        '合并单元格
        Dim badItem As String = ""
        For i As Integer = 1 To dt.Rows.Count - 1 '行
            If dt.Rows(i)(column).ToString = "" Then
                Continue For
            End If
            If tempObj <> dt.Rows(i)(column).ToString Then
                tempObj = dt.Rows(i)(column).ToString
                badItem = dt.Rows(i)(column - 1).ToString
                posI = i
                changeI = 1
                alTemp.Add(badItem + "|" + tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
            Else
                changeI = changeI + 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(badItem + "|" + tempObj)
                    alTemp.Add(badItem + "|" + tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
                End If
            End If
        Next
        Return alTemp
    End Function

    '列单格合并
    Private Function GetHashTableCol(dt As DataTable, rowIndx As Integer) As Hashtable
        Dim alTemp As Hashtable = New Hashtable
        Dim tempObj As String = ""
        Dim posI As String = "0"
        Dim changeI As Integer = 0
        '合并单元格
        For i As Integer = 1 To dt.Columns.Count - 1 '行
            If dt.Rows(rowIndx)(i).ToString = "" Then
                Continue For
            End If
            If tempObj <> dt.Rows(rowIndx)(i).ToString Then
                tempObj = dt.Rows(rowIndx)(i).ToString
                posI = i
                changeI = 1
                alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
            Else
                changeI = changeI + 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(tempObj)
                    alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
                End If
            End If
        Next
        Return alTemp
    End Function

    Public Function HalfWidthDecimalChecker(s As String, precision As String, scale As String) As Boolean
        If ((precision = 0) AndAlso (scale = 0)) Then
            Return False
        End If
        Dim pattern As String = "(^\d{1," + precision + "}"
        If (scale > 0) Then
            pattern = pattern + "\.\d{0," + scale + "}$)|" + pattern
        End If
        pattern = pattern + "$)"

        Return Regex.IsMatch(s, pattern)
    End Function

    Private Function GetDecValue(target As Object) As Object
        Dim result As Decimal = 0
        Try
            If target Is DBNull.Value Then
                result = 0
            Else
                If HalfWidthDecimalChecker(target.ToString.Replace("-", ""), 10, 2) = True Then
                    result = target / 100
                Else
                    Return target
                End If
            End If
        Catch ex As Exception
            Return target
        End Try

        Return result
    End Function

    Private Function GetObjectValue(target As Object) As Object
        Dim result As Decimal = 0
        Try
            If target Is DBNull.Value Then
                result = 0
            Else
                result = Convert.ToDecimal(target)
            End If
        Catch ex As Exception
            Return target
        End Try

        Return result
    End Function

    Private Function GetColumnName(intValue As Integer) As String
        Dim dividend As Integer = intValue
        Dim columnName As String = String.Empty

        While (dividend > 0)
            Dim modulo As Integer = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo) + columnName
            dividend = (dividend - modulo) / 26
        End While
        Return columnName
    End Function

#End Region


End Class