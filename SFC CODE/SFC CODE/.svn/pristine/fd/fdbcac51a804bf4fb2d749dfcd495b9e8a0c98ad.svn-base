Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Drawing
Imports System.IO
Imports NPOI.SS.Formula.Eval
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports System.Text
Imports MainFrame
Imports NPOI.HSSF.Record.Formula.Eval

Public Class BaseInfo
    Dim opFlag As Int16 = 0
    Dim ID As Integer = 0
    Dim ParentTitle As String
    Dim parentIDbyTile As Integer = 0

    Private Sub BaseInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BindDropDown(0)  '显示位置类型父类
        SetStatus(opFlag)
        BindData()
    End Sub
    Private Sub BindData()
        Dim sql As String = "select Title,Parent_Id,case Channel_Id when 0 then N'设备类别' else N'区域位置' end Channel_Id , case Usey  when 'Y' then N'有效' else N'无效' end Usey,Sort_Id,id from m_EquType_t where 1=1  "
        Dim strParent_Id As Integer = 0
        If Me.txtTitle.Text.Trim <> "" Then
            sql += " and Title like N'%" + Me.txtTitle.Text.Trim + "%'"
        End If

        sql += "order by id  "
        GridList.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                Try
                    GridList.Rows.Add(row("Title").ToString(), getTitleById(row("Parent_Id").ToString()), row("Channel_Id").ToString(), row("Usey").ToString(), row("id").ToString())
                Catch ex As Exception

                End Try

            Next
            Me.txtCount.Text = dt.Rows.Count
        End Using
    End Sub

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        opFlag = 1
        SetStatus(opFlag)
        'BindDropDown("0")  '显示位置类型父类
        Me.txtTitle.Text = ""
    End Sub

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        opFlag = 2
        SetStatus(opFlag)
        If (ID = -1) Then
            MessageBox.Show("请选择需要修改的内容")
        Else
            Me.txtTitle.Text = Me.GridList.Item("Title", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
            ID = Me.GridList.Item("XhId", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
            If Me.GridList.Item("Usey", Me.GridList.CurrentRow.Index).Value.ToString.Trim() = "有效" Then
                Me.ckUsery.Checked = True
            Else
                Me.ckUsery.Checked = False
            End If
        End If

    End Sub

    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            Dim StrSql As String = ""
            'Dim EqpType As Integer = CInt(ComType.SelectedIndex.ToString)
            Dim Flag As Integer = 0
            Dim Usey As String = ""
            Dim Title As String = Me.txtTitle.Text
            Dim sParentID As Integer = 0
            Dim Sort_ID As Integer = 0
            If ckUsery.Checked Then
                Usey = "Y"
            Else
                Usey = "N"
            End If

            If Me.txtTitle.Text = "" Then
                MessageBox.Show("请输入名称！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTitle.Select()
                Return
            End If
            Sort_ID = 1
            If (opFlag = 1) Then
                Dim MidSql As String = "select distinct(Title) from m_EquType_t where title=N'" + Title + "' "
                If (GetRecord(MidSql)) Then
                    MessageBox.Show("名称：" + Title + "已存在!")
                    Exit Sub
                End If

                StrSql = "insert into m_EquType_t(Title,Parent_Id,Channel_Id,Sort_Id,Usey) values (" & _
                          "N'" & Title & "',0,0,1,N'" & Usey & "')"

                DbOperateUtils.ExecSQL(StrSql)
            ElseIf (opFlag = 2) Then

                StrSql = String.Format(" update  m_EquType_t set Title=N'{0}',Usey=N'{1}' where ID={2}", Title, Usey, ID)
                DbOperateUtils.ExecSQL(StrSql)

            End If
            Me.txtTitle.Text = ""
            BindData()

            MessageBox.Show("设备区域位置保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        opFlag = 0
        SetStatus(opFlag)
        Me.txtTitle.Text = ""

        BindData()
    End Sub


    Private Function GetRecord(ByVal strsql As String) As Boolean       '是否有记录存在'
        Dim cnt As Integer = DbOperateUtils.GetRowsCount(strsql)
        If (cnt > 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始状态
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCancel.Enabled = False
                Me.ToolSave.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolQueryMO.Enabled = True

                Me.txtTitle.Enabled = False

                Me.ckUsery.Visible = True
                ckUsery.Enabled = False
            Case 1      '新增
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = True

                Me.txtTitle.Enabled = True

                Me.ckUsery.Enabled = True
            Case 2      '修改
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = True
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = True

                Me.txtTitle.Enabled = True

                Me.ckUsery.Enabled = True
                Me.Label2.Visible = True
        End Select
    End Sub

    Private Function GetMaxOrderId(ByVal strChannel_Id As Integer, ByVal strParentID As Integer) As Integer
        Dim dtMaxOrderID As DataTable
        Dim sqlMaxOrderID As String = " select ISNULL(max(Sort_ID)+1,0) Sort_ID from m_EquType_t where  Channel_Id=" & strChannel_Id & " and Parent_ID=" & strParentID
        If (strParentID <> 0) Then
            Try
                dtMaxOrderID = DbOperateUtils.GetDataTable(sqlMaxOrderID)
                If (dtMaxOrderID.Rows(0).Item(0).ToString() <> "0") Then
                    Return (CInt(dtMaxOrderID.Rows(0).Item(0).ToString()))
                Else
                    Return 1
                End If

            Catch ex As Exception
                Return 1
            End Try
        End If

    End Function

    Private Function getInfoByID(ByVal strID As Integer) As Integer
        Dim sqlPid = "select *  from m_EquType_t where id=" & strID
        Dim dtPid As DataTable
        Dim Pid As Integer = 0
        dtPid = DbOperateUtils.GetDataTable(sqlPid)
        If (dtPid.Rows.Count > 0) Then
            Return CInt(dtPid.Rows(0).Item("Parent_ID").ToString)
        Else
            Return Pid
        End If
    End Function

    Private Function getTitleById(ByVal strID As Integer) As String
        If strID <> 0 Then
            Dim sqlPid = "select *  from m_EquType_t where id=" & strID
            Dim dtPrantTitle As DataTable

            dtPrantTitle = DbOperateUtils.GetDataTable(sqlPid)
            If (dtPrantTitle.Rows.Count > 0) Then
                Return dtPrantTitle.Rows(0).Item("Title").ToString
            Else
                Return "一级分类"
            End If
        Else
            Return "一级分类"
        End If
    End Function

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolQueryMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQueryMO.Click
        Me.txtTitle.Enabled = True
        Me.ckUsery.Enabled = True
        BindData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String
            filename = sdfimport.FileName
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

            Dim StrSql As String
            '取得上传表数据
            Dim dt As DataTable
            dt = ExcelHelper.ImportExceltoDt(filename)
            If (dt.Rows.Count > 0) Then
                For Each dr As DataRow In dt.Rows
                    Dim MidSql As String = "select distinct(Title) from m_EquType_t where title=N'" + dr(0).ToString + "' "
                    If (GetRecord(MidSql)) Then
                        MessageBox.Show("名称：" + dr(0).ToString + "已存在!")
                        Return
                    End If
                    StrSql = "insert into m_EquType_t(Title,Parent_Id,Channel_Id,Sort_Id,Usey) values (" & _
                                  "N'" & dr(0).ToString & "',0,0,1,N'Y')"

                    DbOperateUtils.ExecSQL(StrSql)
                Next
                MessageBox.Show("成功到导入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BindData()
            Else
                MessageBox.Show("没有要导出的信息记录！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Class ExcelHelper

        Private Shared Function ImportDt(ByVal sheet As HSSFSheet, ByVal HeaderRowIndex As Integer, ByVal needHeader As Boolean) As DataTable
            Dim table As New DataTable()
            Dim headerRow As HSSFRow
            Dim cellCount As Integer
            If HeaderRowIndex < 0 OrElse Not needHeader Then
                headerRow = TryCast(sheet.GetRow(0), HSSFRow)
                cellCount = headerRow.LastCellNum
                For i As Integer = headerRow.FirstCellNum To cellCount
                    Dim column As New DataColumn(Convert.ToString(i))
                    table.Columns.Add(column)
                Next
            Else
                headerRow = TryCast(sheet.GetRow(HeaderRowIndex), HSSFRow)
                cellCount = headerRow.LastCellNum
                For i As Integer = headerRow.FirstCellNum To cellCount
                    If headerRow.GetCell(i) Is Nothing Then
                        If table.Columns.IndexOf(Convert.ToString(i)) > 0 Then
                            Dim column As New DataColumn(Convert.ToString("重复列名" & i))
                            table.Columns.Add(column)
                        Else
                            Dim column As New DataColumn(Convert.ToString(i))
                            table.Columns.Add(column)
                        End If
                    ElseIf table.Columns.IndexOf(headerRow.GetCell(i).ToString()) > 0 Then
                        Dim column As New DataColumn(Convert.ToString("重复列名" & i))
                        table.Columns.Add(column)
                    Else
                        Dim column As New DataColumn(headerRow.GetCell(i).ToString())
                        table.Columns.Add(column)
                    End If
                Next
            End If
            Dim rowCount As Integer = sheet.LastRowNum
            For i As Integer = (HeaderRowIndex + 1) To sheet.LastRowNum
                Try
                    Dim row As HSSFRow
                    If sheet.GetRow(i) Is Nothing Then
                        row = TryCast(sheet.CreateRow(i), HSSFRow)
                    Else
                        row = TryCast(sheet.GetRow(i), HSSFRow)
                    End If
                    Dim dataRow As DataRow = table.NewRow()
                    For j As Integer = row.FirstCellNum To cellCount
                        Try
                            If row.GetCell(j) IsNot Nothing Then
                                Select Case row.GetCell(j).CellType
                                    Case CellType.[STRING]
                                        Dim str As String = row.GetCell(j).StringCellValue
                                        If str IsNot Nothing AndAlso str.Length > 0 Then
                                            dataRow(j) = str.ToString()
                                        Else
                                            dataRow(j) = Nothing
                                        End If
                                        Exit Select
                                    Case CellType.NUMERIC
                                        If DateUtil.IsCellDateFormatted(row.GetCell(j)) Then
                                            dataRow(j) = DateTime.FromOADate(row.GetCell(j).NumericCellValue)
                                        Else
                                            dataRow(j) = Convert.ToDouble(row.GetCell(j).NumericCellValue)
                                        End If
                                        Exit Select
                                    Case CellType.[BOOLEAN]
                                        dataRow(j) = Convert.ToString(row.GetCell(j).BooleanCellValue)
                                        Exit Select
                                    Case CellType.[ERROR]
                                        dataRow(j) = ErrorEval.GetText(row.GetCell(j).ErrorCellValue)
                                        Exit Select
                                    Case CellType.FORMULA
                                        Select Case row.GetCell(j).CachedFormulaResultType
                                            Case CellType.[STRING]
                                                Dim strFORMULA As String = row.GetCell(j).StringCellValue
                                                If strFORMULA IsNot Nothing AndAlso strFORMULA.Length > 0 Then
                                                    dataRow(j) = strFORMULA.ToString()
                                                Else
                                                    dataRow(j) = Nothing
                                                End If
                                                Exit Select
                                            Case CellType.NUMERIC
                                                dataRow(j) = Convert.ToString(row.GetCell(j).NumericCellValue)
                                                Exit Select
                                            Case CellType.[BOOLEAN]
                                                dataRow(j) = Convert.ToString(row.GetCell(j).BooleanCellValue)
                                                Exit Select
                                            Case CellType.[ERROR]
                                                dataRow(j) = ErrorEval.GetText(row.GetCell(j).ErrorCellValue)
                                                Exit Select
                                            Case Else
                                                dataRow(j) = ""
                                                Exit Select
                                        End Select
                                        Exit Select
                                    Case Else
                                        dataRow(j) = ""
                                        Exit Select
                                End Select
                            End If
                            'wl.WriteLogs(exception.ToString()); 
                        Catch exception As Exception
                        End Try
                    Next
                    table.Rows.Add(dataRow)
                    'wl.WriteLogs(exception.ToString());     
                Catch exception As Exception
                End Try
            Next
            'wl.WriteLogs(exception.ToString());  

            Return table
        End Function

        Public Shared Sub ExportDTtoExcel(ByVal dtSource As DataTable, ByVal strHeaderText As String, ByVal strFileName As String)
            Using ms As MemoryStream = ExportDT(dtSource, strHeaderText)
                Using fs As New FileStream(strFileName, FileMode.Create, FileAccess.Write)
                    Dim data As Byte() = ms.ToArray()
                    fs.Write(data, 0, data.Length)
                    fs.Flush()
                End Using
            End Using
        End Sub

        Public Shared Function ImportExceltoDt(ByVal strFileName As String) As DataTable
            Dim dt As New DataTable()
            Dim hssfworkbook As HSSFWorkbook
            Using file As New FileStream(strFileName, FileMode.Open, FileAccess.Read)
                hssfworkbook = New HSSFWorkbook(file)
            End Using
            Dim sheet As HSSFSheet = TryCast(hssfworkbook.GetSheetAt(0), HSSFSheet)
            dt = ImportDt(sheet, 0, True)
            Return dt
        End Function

        Public Shared Function ImportExceltoDt(ByVal strFileName As String, ByVal SheetName As String, ByVal HeaderRowIndex As Integer) As DataTable
            Dim workbook As HSSFWorkbook
            Using file As New FileStream(strFileName, FileMode.Open, FileAccess.Read)
                workbook = New HSSFWorkbook(file)
            End Using
            Dim sheet As HSSFSheet = TryCast(workbook.GetSheet(SheetName), HSSFSheet)
            Dim table As New DataTable()
            table = ImportDt(sheet, HeaderRowIndex, True)
            'ExcelFileStream.Close();  
            workbook = Nothing
            sheet = Nothing
            Return table
        End Function

        Public Shared Function ImportExceltoDt(ByVal strFileName As String, ByVal SheetIndex As Integer, ByVal HeaderRowIndex As Integer) As DataTable
            Dim workbook As HSSFWorkbook
            Using file As New FileStream(strFileName, FileMode.Open, FileAccess.Read)
                workbook = New HSSFWorkbook(file)
            End Using
            Dim sheet As HSSFSheet = TryCast(workbook.GetSheetAt(SheetIndex), HSSFSheet)
            Dim table As New DataTable()
            table = ImportDt(sheet, HeaderRowIndex, True)
            'ExcelFileStream.Close(); 
            workbook = Nothing
            sheet = Nothing
            Return table
        End Function

        Public Shared Function ImportExceltoDt(ByVal strFileName As String, ByVal SheetName As String, ByVal HeaderRowIndex As Integer, ByVal needHeader As Boolean) As DataTable
            Dim workbook As HSSFWorkbook
            Using file As New FileStream(strFileName, FileMode.Open, FileAccess.Read)
                workbook = New HSSFWorkbook(file)
            End Using
            Dim sheet As HSSFSheet = TryCast(workbook.GetSheet(SheetName), HSSFSheet)
            Dim table As New DataTable()
            table = ImportDt(sheet, HeaderRowIndex, needHeader)
            'ExcelFileStream.Close();  
            workbook = Nothing
            sheet = Nothing
            Return table
        End Function

        Public Shared Function ImportExceltoDt(ByVal strFileName As String, ByVal SheetIndex As Integer, ByVal HeaderRowIndex As Integer, ByVal needHeader As Boolean) As DataTable
            Dim workbook As HSSFWorkbook
            Using file As New FileStream(strFileName, FileMode.Open, FileAccess.Read)
                workbook = New HSSFWorkbook(file)
            End Using
            Dim sheet As HSSFSheet = TryCast(workbook.GetSheetAt(SheetIndex), HSSFSheet)
            Dim table As New DataTable()
            table = ImportDt(sheet, HeaderRowIndex, needHeader)
            'ExcelFileStream.Close();  
            workbook = Nothing
            sheet = Nothing
            Return table
        End Function

        '******************************************************************' * 版权所有： ' * 类 名 称：ExcelHelper' * 作    者：zk' * 电子邮箱：77148918@QQ.com' * 创建日期：2012/2/25 10:17:21 ' * 修改描述：从excel导入datatable时，可以导入日期类型。' *           但对excel中的日期类型有一定要求，要求至少是yyyy/mm/dd类型日期； *           ' * 修改描述：将datatable导入excel中，对类型为字符串的数字进行处理，' *           导出数字为double类型；' * 修改日期：2012年5月4日22:06:29 for Jnz Update to NPOI 1.25 正式版' * ' * ******************************************************************Imports System.Collections.GenericImports System.DataImports System.IOImports System.TextImports System.WebImports NPOIImports NPOI.HPSFImports NPOI.HSSFImports NPOI.HSSF.Record'NPOI.HSSF.Record.Formula.Eval改为了NPOI.SS.Formula.Eval;Imports NPOI.SS.Formula.Eval'同上Imports NPOI.HSSF.UserModelImports NPOI.HSSF.UtilImports NPOI.POIFSImports NPOI.SS.UserModelImports NPOI.UtilImports NPOI.SSImports NPOI.DDFImports NPOI.SS.UtilImports System.CollectionsImports System.Text.RegularExpressionsNamespace DataBaseToExcel Public Class ExcelHelper  'private static WriteLog wl = new WriteLog();  #Region "从datatable中将数据导出到excel"  ''' <summary>  ''' DataTable导出到Excel的MemoryStream  ''' </summary>  ''' <param name="dtSource">源DataTable</param>  ''' <param name="strHeaderText">表头文本</param> 
        Private Shared Function ExportDT(ByVal dtSource As DataTable, ByVal strHeaderText As String) As MemoryStream
            Dim workbook As New HSSFWorkbook()
            Dim sheet As HSSFSheet = TryCast(workbook.CreateSheet(), HSSFSheet)
            Dim dateStyle As HSSFCellStyle = TryCast(workbook.CreateCellStyle(), HSSFCellStyle)
            Dim format As HSSFDataFormat = TryCast(workbook.CreateDataFormat(), HSSFDataFormat)
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd")

            '取得列宽  
            Dim arrColWidth As Integer() = New Integer(dtSource.Columns.Count - 1) {}
            For Each item As DataColumn In dtSource.Columns

                arrColWidth(item.Ordinal) = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length

            Next
            For i As Integer = 0 To dtSource.Rows.Count - 1

                For j As Integer = 0 To dtSource.Columns.Count - 1

                    Dim intTemp As Integer = Encoding.GetEncoding(936).GetBytes(dtSource.Rows(i)(j).ToString()).Length
                    If intTemp > arrColWidth(j) Then
                        arrColWidth(j) = intTemp
                    End If

                Next
            Next

            Dim rowIndex As Integer = 0
            For Each row As DataRow In dtSource.Rows    '#Region "新建表，填充表头，填充列头，样式"

                If rowIndex = 65535 OrElse rowIndex = 0 Then
                    If rowIndex <> 0 Then

                        sheet = TryCast(workbook.CreateSheet(), HSSFSheet)

                    End If
                    If True Then

                        Dim headerRow As HSSFRow = TryCast(sheet.CreateRow(0), HSSFRow)
                        headerRow.HeightInPoints = 25

                        headerRow.CreateCell(0).SetCellValue(strHeaderText)

                        Dim headStyle As HSSFCellStyle = TryCast(workbook.CreateCellStyle(), HSSFCellStyle)
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER

                        Dim font As HSSFFont = TryCast(workbook.CreateFont(), HSSFFont)
                        font.FontHeightInPoints = 20
                        font.Boldweight = 700


                        headStyle.SetFont(font)
                        headerRow.GetCell(0).CellStyle = headStyle

                        sheet.AddMergedRegion(New NPOI.SS.Util.Region(0, 0, 0, dtSource.Columns.Count - 1))

                    End If

                    If True Then

                        Dim headerRow As HSSFRow = TryCast(sheet.CreateRow(1), HSSFRow)

                        Dim headStyle As HSSFCellStyle = TryCast(workbook.CreateCellStyle(), HSSFCellStyle)
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER
                        Dim font As HSSFFont = TryCast(workbook.CreateFont(), HSSFFont)
                        font.FontHeightInPoints = 10
                        font.Boldweight = 700
                        headStyle.SetFont(font)

                        For Each column As DataColumn In dtSource.Columns

                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName)
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle

                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth(column.Ordinal) + 1) * 256)
                        Next

                    End If

                    rowIndex = 2
                End If
                Dim dataRow As HSSFRow = TryCast(sheet.CreateRow(rowIndex), HSSFRow)
                For Each column As DataColumn In dtSource.Columns

                    Dim newCell As HSSFCell = TryCast(dataRow.CreateCell(column.Ordinal), HSSFCell)
                    Dim drValue As String = row(column).ToString()

                    Select Case column.DataType.ToString()
                        Case "System.String"       '字符串类型      
                            Dim result As Double
                            ' If IsNumeric(drValue, result) Then
                            If IsNumeric(drValue) Then
                                Double.TryParse(drValue, result)
                                newCell.SetCellValue(result)
                                Exit Select
                            Else
                                newCell.SetCellValue(drValue)
                                Exit Select
                            End If

                        Case "System.DateTime"
                            '日期类型     
                            Dim dateV As DateTime
                            DateTime.TryParse(drValue, dateV)
                            newCell.SetCellValue(dateV)
                            newCell.CellStyle = dateStyle
                            '格式化显示  
                            Exit Select
                        Case "System.Boolean"
                            '布尔型     
                            Dim boolV As Boolean = False
                            Boolean.TryParse(drValue, boolV)
                            newCell.SetCellValue(boolV)
                            Exit Select

                            '整型     
                        Case "System.Int16", "System.Int32", "System.Int64", "System.Byte"
                            Dim intV As Integer = 0
                            Integer.TryParse(drValue, intV)
                            newCell.SetCellValue(intV)
                            Exit Select



                            '浮点型   
                        Case "System.Decimal", "System.Double"
                            Dim doubV As Double = 0
                            Double.TryParse(drValue, doubV)
                            newCell.SetCellValue(doubV)
                            Exit Select


                        Case "System.DBNull"
                            '空值处理    
                            newCell.SetCellValue("")
                            Exit Select
                        Case Else
                            newCell.SetCellValue("")
                            Exit Select
                    End Select
                Next
                rowIndex += 1
            Next

            Using ms As New MemoryStream()
                workbook.Write(ms)
                ms.Flush()
                ms.Position = 0
                Return ms
            End Using
        End Function

        Public Shared Sub UpdateExcel(ByVal outputFile As String, ByVal sheetname As String, ByVal updateData As String(), ByVal coluid As Integer, ByVal rowid As Integer)
            Dim readfile As New FileStream(outputFile, FileMode.Open, FileAccess.Read)
            Dim hssfworkbook As New HSSFWorkbook(readfile)
            Dim sheet1 As ISheet = hssfworkbook.GetSheet(sheetname)
            For i As Integer = 0 To updateData.Length - 1
                Try
                    If sheet1.GetRow(i + rowid) Is Nothing Then
                        sheet1.CreateRow(i + rowid)
                    End If
                    If sheet1.GetRow(i + rowid).GetCell(coluid) Is Nothing Then
                        sheet1.GetRow(i + rowid).CreateCell(coluid)
                    End If
                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData(i))
                Catch ex As Exception
                    ' wl.WriteLogs(ex.ToString());   
                    Throw
                End Try
            Next
            Try
                readfile.Close()
                Dim writefile As New FileStream(outputFile, FileMode.Create, FileAccess.Write)
                hssfworkbook.Write(writefile)
                writefile.Close()
                ' wl.WriteLogs(ex.ToString());  
            Catch ex As Exception
            End Try
        End Sub
    End Class

End Class

