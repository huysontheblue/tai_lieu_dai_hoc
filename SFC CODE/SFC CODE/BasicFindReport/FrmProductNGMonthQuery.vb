Imports UIHandler
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports Aspose.Cells
Imports System.Text.RegularExpressions
Imports MainFrame.SysCheckData
Imports System.Threading

Public Class FrmProductNGMonthQuery

    '初期化
    Private Sub FrmProductNGQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            cmbType.SelectedIndex = 0
            dtMonth.Value = Now().ToString("yyyy/MM")
            LoadDataToCombo(cbbDept, 2)
        End If
    End Sub

    '下拉框
    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        LoadLineIDToCombo(cbbLine, Getid(cbbDept.Text))
    End Sub

    '查询事件
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        Try
            myThread.Start()
            lblMsg.Text = String.Empty

            cDgData.DataSource = Nothing
            cDgData.DataSource = GetDataTable()

            For i As Integer = 0 To cDgData.Rows.Count - 1
                For k As Integer = 2 To cDgData.Columns.Count - 1  '列
                    If i Mod 2 = 0 And i > 1 Then ' 
                        cDgData.Rows(i).Cells(k).Value = cDgData.Rows(i).Cells(k).EditedFormattedValue.ToString + "%"
                    End If
                Next
            Next

            For k As Integer = 0 To cDgData.Columns.Count - 1  '列
                cDgData.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            Next
            Threading.Thread.Sleep(300)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProductNGMonthQuery", " toolQuery_Click", "BasicFind")
        Finally
            myThread.Abort()
        End Try
    End Sub

    'EXCEL导出
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim reportFileName As String
            If Me.cmbType.SelectedIndex = 0 Then
                reportFileName = Me.Text + "（客户）" + Convert.ToDateTime(dtMonth.Text).ToString("yyyy年MM月")
            Else
                reportFileName = Me.Text + "（系列别）" + Convert.ToDateTime(dtMonth.Text).ToString("yyyy年MM月")
            End If

            Dim o_TempoutputFile As String = String.Format("c:\MesExport\{0}.xlsx", reportFileName)
            Dim errorMsg As String = Nothing

            Dim dts As DataTable = GetDataTable()

            If Import2ExcelByAs(o_TempoutputFile, dts, errorMsg) = False Then
                MessageUtils.ShowError(errorMsg)
            Else
                MessageUtils.ShowInformation("成功导出")
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProductNGMonthQuery", " toolQuery_Click", "BasicFind")
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    '取得导出数据
    Private Function GetDataTable() As DataTable
        Dim strSQL As String
        Dim strType As String
        Try
            If Me.cmbType.SelectedIndex = 0 Then
                strType = "1"
            Else
                strType = "2"
            End If
            strSQL = "EXEC m_QueryTotalMonthNGQuery_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'"
            strSQL = String.Format(strSQL, Me.dtMonth.Text, Getid(cbbDept.Text), Me.cbbLine.Text, Me.txtPartId.Text.Trim,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, strType)
            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            SetDataNgTotalRate(dts)

            Return dts
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
            Return Nothing
        End Try
    End Function

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '错误处理
    Private Sub cDgData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles cDgData.DataError

    End Sub

#Region "报表导出用"

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
            styleTitle.HorizontalAlignment = TextAlignmentType.Center '文字居中 
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
            cells.SetRowHeight(0, 30)

            '设置显示开始位置
            Dim startPos As Integer = 1
            '从第二行开始 列显示 
            For i As Integer = 0 To colnum - 1
                cells(startPos, i).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i).SetStyle(style1) ' 设置列头样式
            Next
            cells.SetRowHeight(startPos, 33) ' 设置行高度

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

    Private ReadOnly HalfWidthNumberPattern As Regex = New Regex("^[0-9]+$")

    Public Function HalfWidthNumChecker(target As String) As Boolean
        Dim result As Boolean = False

        If target <> "" Then
            result = HalfWidthNumberPattern.IsMatch(target.Replace(".", ""))
        End If

        HalfWidthNumChecker = result
    End Function

    Private Function GetDecValue(target As Object) As Object
        Dim result As Decimal = 0
        Try
            If target Is Nothing Then
                result = 0
            Else
                If HalfWidthNumChecker(target) = True Then
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
            If target Is Nothing Then
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