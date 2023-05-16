Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame.SysDataHandle
Imports Aspose.Cells
Imports System.IO
Imports System.Windows.Forms

Public Class FrmWarehouseInstruct

    Dim FieldList As List(Of String)

#Region "初期化"

    '初期化
    Private Sub FrmWarehouseInstruct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.dgvWHsInstruct
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With

        With Me.dgvWHsDeliver
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With

    End Sub

#End Region

#Region "事件"

    '退出
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            querydata("")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '导入 
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            Dim dtUploadData As DataTable = SysDataBaseClass.ExportFromExcelByAs(filename, 1, 0, errorMsg)

            If errorMsg <> "" Then
                MessageUtils.ShowError(errorMsg)
                Exit Sub
            End If
            '送货日期 DeliverDate
            '客户名称 CustName
            '客户电话 CustTel
            '送货地址 DeliverAddress
            '供应商电话 SupplyTel
            '供应商地址 SupplyAddress
            '线束型号 ProNo
            '单位 Unit
            '出库数量 Qty
            FieldList = Nothing
            FieldList = New List(Of String)
            FieldList.Add("DeliverDate")
            FieldList.Add("CustTel")
            FieldList.Add("SupplyTel")
            FieldList.Add("CustName")
            FieldList.Add("DeliverAddress")
            FieldList.Add("SupplyAddress")
            FieldList.Add("ProNo")
            FieldList.Add("Unit")
            FieldList.Add("Qty")

            If dtUploadData.Columns.Count = 9 Then
                Dim i%
                For i = 0 To dtUploadData.Columns.Count - 1
                    dtUploadData.Columns(i).ColumnName = FieldList(i)
                Next
            Else
                MessageUtils.ShowError("导入文件格式有误！")
                Return
            End If

            Dim DrrR As DataRow() = dtUploadData.Select(" ProNo IS NOT NULL or Qty IS NOT NULL ")

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '批量插入到DB中
            Dim Outwhid As String = ""
            Dim strSQL As String = GetInsertSQL(DrrR, Outwhid)
            If strSQL = "" Then
                Exit Sub
            End If

            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("导入成功！")

            GetAutoDeliverNote(Outwhid)
            querydata(Outwhid)
            SetWhs(0)
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    '自动生成出货指示单
    Private Sub toolGetDeliver_Click(sender As Object, e As EventArgs) Handles toolGetDeliver.Click
        If Check() = False Then Exit Sub

        GetAutoDeliverNote(txtOutwhid.Text)
    End Sub

    '出货指示单
    Private Sub dgvWHsInstruct_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWHsInstruct.CellContentClick
        If e.RowIndex = -1 Then Exit Sub

        SetWhs(e.RowIndex)
    End Sub

    '出货清单表
    Private Sub tsbInstructPrint_Click(sender As Object, e As EventArgs) Handles tsbInstructPrint.Click
        Try

            If Check() = False Then Exit Sub

            Dim Template_File_Path As String = VbCommClass.VbCommClass.SopFilePath & "\MES\出货指示单模板.xlsx"

            '  打开 Excel 模板
            Dim CurrentWorkbook As Workbook = New Workbook(Template_File_Path)

            '  打开第一个sheet
            Dim DetailSheet As Worksheet = CurrentWorkbook.Worksheets(0)

            ' 比如要在 A1 位置写入 Demo这个值
            Dim cells As Cells = DetailSheet.Cells

            Dim dt As DataTable = GetDataTable(txtOutwhid.Text)

            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("没有出货指示单数据，请确认！")
                Exit Sub
            End If


            Dim Outwhid As String = dt.Rows(0)("Outwhid")
            cells(1, 1).PutValue(Outwhid)
            Dim DeliverDate As String = dt.Rows(0)("DeliverDate")
            cells(2, 1).PutValue(DeliverDate)
            Dim CustName As String = dt.Rows(0)("CustName")
            cells(2, 4).PutValue(CustName)
            Dim CustTel As String = dt.Rows(0)("CustTel")
            cells(3, 1).PutValue(CustTel)
            Dim DeliverAddress As String = dt.Rows(0)("DeliverAddress")
            cells(3, 4).PutValue(DeliverAddress)
            Dim SupplyTel As String = dt.Rows(0)("SupplyTel")
            cells(4, 1).PutValue(SupplyTel)
            Dim SupplyAddress As String = dt.Rows(0)("SupplyAddress")
            cells(4, 4).PutValue(SupplyAddress)

            '插入二维码
            SetQR(Outwhid, DetailSheet)

            Dim rownum As Integer = dt.Rows.Count
            Dim colnum As Integer = dt.Columns.Count
            '设置显示开始位置
            Dim startPos As Integer = 6
            Dim sheetRow As Integer = 0
            Dim index = 0
            sheetRow = startPos

            For i As Integer = 0 To rownum - 1  '行
                '序号
                cells(sheetRow, 0).PutValue((i + 1).ToString)
                '线束型号
                cells(sheetRow, 1).PutValue(dt.Rows(i)("ProNo"))
                '单位
                cells(sheetRow, 2).PutValue(dt.Rows(i)("Unit"))
                '数量
                cells(sheetRow, 3).PutValue(dt.Rows(i)("Qty"))

                sheetRow = sheetRow + 1
            Next


            '  生成的文件名称
            Dim ReportFileName As String = String.Format("\出货指示单_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd"))

            Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + ReportFileName
            '  保存文件
            CurrentWorkbook.Save(filePath, SaveFormat.Xlsx)

            MessageUtils.ShowInformation("生成数据成功！")
            '增加打开EXCEL文件
            System.Diagnostics.Process.Start(filePath)

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '出货指示表
    Private Sub toolCargoPrint_Click(sender As Object, e As EventArgs) Handles toolCargoPrint.Click
        Try
            If Check() = False Then Exit Sub

            Dim Template_File_Path As String = VbCommClass.VbCommClass.PrintDataModle & "\MES\备货清单模板.xlsx"

            '  打开 Excel 模板
            Dim CurrentWorkbook As Workbook = New Workbook(Template_File_Path)

            '  打开第一个sheet
            Dim DetailSheet As Worksheet = CurrentWorkbook.Worksheets(0)

            ' 比如要在 A1 位置写入 Demo这个值
            Dim cells As Cells = DetailSheet.Cells

            Dim dt As DataTable = GetDataTable(txtOutwhid.Text)
            Dim dt2 As DataTable = GetDataTable2(txtOutwhid.Text)

            If dt2.Rows.Count = 0 Then
                MessageUtils.ShowError("没有备货清单数据，请确认！")
                Exit Sub
            End If

            Dim Outwhid As String = dt.Rows(0)("Outwhid")
            cells(1, 1).PutValue(Outwhid)
            Dim DeliverDate As String = dt.Rows(0)("DeliverDate")
            cells(2, 1).PutValue(DeliverDate)
            Dim CustName As String = dt.Rows(0)("CustName")
            cells(2, 4).PutValue(CustName)
            Dim CustTel As String = dt.Rows(0)("CustTel")
            cells(3, 1).PutValue(CustTel)
            Dim DeliverAddress As String = dt.Rows(0)("DeliverAddress")
            cells(3, 4).PutValue(DeliverAddress)
            Dim SupplyTel As String = dt.Rows(0)("SupplyTel")
            cells(4, 1).PutValue(SupplyTel)
            Dim SupplyAddress As String = dt.Rows(0)("SupplyAddress")
            cells(4, 4).PutValue(SupplyAddress)


            Dim remark As String = GetRemark(txtOutwhid.Text)
            '插入二维码
            SetQR(Outwhid, DetailSheet)

            Dim rownum As Integer = dt.Rows.Count
            Dim colnum As Integer = dt.Columns.Count
            '设置显示开始位置
            Dim startPos As Integer = 6
            Dim sheetRow As Integer = 0
            Dim index = 0
            sheetRow = startPos

            Dim fullRows() As DataRow = dt2.Select("IsFullCarton = 1")
            Dim fullCartonNum As Integer = fullRows.Length

            Dim zeroRows() As DataRow = dt2.Select("IsFullCarton = 0")
            Dim zeroCartonNum As Integer = zeroRows.Length

            For i As Integer = 0 To fullCartonNum - 2  '行
                DetailSheet.Cells.InsertRow(7)
                DetailSheet.Cells.CopyRow(cells, 6, 8)
            Next

            For i As Integer = 0 To fullCartonNum - 1  '行
                '序号
                cells(sheetRow, 0).PutValue((i + 1).ToString)

                '车型
                cells(sheetRow, 1).PutValue(fullRows(i)("CarType"))

                '产品名称
                cells(sheetRow, 2).PutValue(fullRows(i)("LineName"))

                '产品型号
                cells(sheetRow, 3).PutValue(fullRows(i)("ProNo"))

                '简码
                cells(sheetRow, 4).PutValue(fullRows(i)("Code"))

                '批次
                cells(sheetRow, 5).PutValue(fullRows(i)("LotNo"))

                '数量
                cells(sheetRow, 6).PutValue(fullRows(i)("Qty"))

                sheetRow = sheetRow + 1
            Next
            '增加备注
            cells(sheetRow, 0).PutValue(remark)

            '显示
            sheetRow = sheetRow + 4
            For i As Integer = 0 To zeroCartonNum - 2  '行
                DetailSheet.Cells.InsertRow(11 + fullCartonNum)
                DetailSheet.Cells.CopyRow(cells, 10 + fullCartonNum, 11 + fullCartonNum)
            Next

            For i As Integer = 0 To zeroCartonNum - 1  '行
                '序号
                cells(sheetRow, 0).PutValue((i + 1).ToString)

                '车型
                cells(sheetRow, 1).PutValue(zeroRows(i)("CarType"))

                '产品名称
                cells(sheetRow, 2).PutValue(zeroRows(i)("LineName"))

                '产品型号
                cells(sheetRow, 3).PutValue(zeroRows(i)("ProNo"))

                '简码
                cells(sheetRow, 4).PutValue(zeroRows(i)("Code"))

                '批次
                cells(sheetRow, 5).PutValue(zeroRows(i)("LotNo"))

                '数量
                cells(sheetRow, 6).PutValue(zeroRows(i)("Qty"))

                sheetRow = sheetRow + 1
            Next

            '  生成的文件名称
            Dim ReportFileName As String = String.Format("\备货清单_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd"))

            Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + ReportFileName
            '  保存文件
            CurrentWorkbook.Save(filePath, SaveFormat.Xlsx)

            MessageUtils.ShowInformation("生成数据成功！")
            '增加打开EXCEL文件
            System.Diagnostics.Process.Start(filePath)

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '删除出货指示单
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            If Check() = False Then Exit Sub

            If MessageUtils.ShowConfirm("你确定删除出货指示单吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                DeleteDeliver()
                querydata(txtOutwhid.Text)
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '导入模板
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        Dim FileName As String = "导入出货指示单.xls"
        Dim FileName2 As String = "导入出货指示单.xlsx"
        Dim FilePath As String = Path.Combine(VbCommClass.VbCommClass.PrintDataModle, "MES\IMPORTTEMPLATE\" + FileName)
        If Not File.Exists(FilePath) Then
            FilePath = Path.Combine(VbCommClass.VbCommClass.PrintDataModle, "MES\IMPORTTEMPLATE\" + FileName2)
            If Not File.Exists(FilePath) Then
                MessageUtils.ShowWarning("未找到导入格式文件！")
                Exit Sub
            End If
        End If
        Try
            Dim Process As New System.Diagnostics.Process
            Process.StartInfo.FileName = FilePath
            Process.StartInfo.Verb = "Open"
            Process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
            Process.Start()
        Catch ex As Exception
            MessageUtils.ShowError("名为【" + FileName + "】的文件打开出错！")
        End Try
    End Sub

#End Region

#Region "方法"
    '设置仓库数据
    Private Sub SetWhs(rowIndex As Integer)
        If dgvWHsInstruct.Rows.Count = 0 Then Exit Sub

        Dim Outwhid As String = Me.dgvWHsInstruct.Rows(rowIndex).Cells(0).Value.ToString.Trim
        Dim ProNo As String = Me.dgvWHsInstruct.Rows(rowIndex).Cells(1).Value.ToString.Trim

        Dim strSQL As String = " SELECT ProNo, LotNo, CarType, LineName, Code, Qty FROM m_WHsDeliver_t " &
                          " WHERE Outwhid = '{0}' AND ProNo = '{1}' "

        strSQL = String.Format(strSQL, Outwhid, ProNo)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        dgvWHsDeliver.DataSource = dt
    End Sub

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        Dim strSQL As String = "SELECT SUBSTRING(proNo,0,14) AS proNo FROM m_SmallHarnessInfo_t  "
        Dim dataTable As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim hashtable As Hashtable = New Hashtable

        For index As Integer = 0 To DrrR.Length - 1
            Dim strKey As String = DrrR(index)("ProNo").ToString.Trim
            If hashtable.Contains(strKey) Then
                MessageUtils.ShowError("上传数据中有重复的[线束型号]:'" + strKey + "'")
                Return False
            End If
            Dim drs As DataRow() = dataTable.Select(" ProNo='" & strKey & "' ")
            If (drs.Length = 0) Then
                MessageUtils.ShowError("小线束基础资料表中不存[产品型号]:'" + strKey + "'")
                Return False
            End If
            hashtable.Add(strKey, strKey)
        Next
        Return True
    End Function

    '得到插入SQL
    Private Function GetInsertSQL(DRS As DataRow(), ByRef Outwhid As String) As String
        Dim strSQL As String = "insert into m_WHsInstruct_t(Outwhid, ProNo, Unit, Qty, DeliverDate, CustName, " &
                                "CustTel, DeliverAddress, SupplyTel, SupplyAddress, UserId, Intime) values" &
                                "(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',getdate())"

        Dim strInsertSQL As New StringBuilder

        Outwhid = GenMainNumber()
        If Outwhid = "" Then Return ""

        Dim Qty As Decimal = 0
        For Each row As DataRow In DRS
            Try
                Qty = Convert.ToDecimal(IIf(row("Qty").ToString.Trim = "", "0", row("Qty").ToString.Trim))
            Catch ex As Exception
                MessageUtils.ShowError("数量格式错误！")
                Return ""
            End Try

            strInsertSQL.AppendFormat(strSQL, Outwhid, row("ProNo").ToString.Trim, row("Unit").ToString.Trim, Qty, row("DeliverDate").ToString.Trim,
                                      row("CustName").ToString.Trim, row("CustTel").ToString.Trim, row("DeliverAddress").ToString.Trim,
                                      row("SupplyTel").ToString.Trim, row("SupplyAddress").ToString.Trim, VbCommClass.VbCommClass.UseId)
        Next
        Return strInsertSQL.ToString
    End Function

    '得到自动生成
    Private Sub GetAutoDeliverNote(Outwhid As String)
        Try
            Dim strSQL As String = " declare @strmsgid varchar(1),@strmsgText nvarchar(500) " &
                                 " exec [m_Wh_AutoDeliverNote_p] '{0}','{1}',@strmsgid output,@strmsgText output" &
                                 " select @strmsgid,@strmsgText"

            strSQL = String.Format(strSQL, Outwhid, SysMessageClass.UseId)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        MessageUtils.ShowError(dt.Rows(0)(1).ToString())
                        Exit Sub
                    Case "1"
                        MessageUtils.ShowInformation(dt.Rows(0)(1).ToString())
                End Select
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '自动生成单据编号
    Private Function GenMainNumber() As String

        Dim Sqlstr As String = "select dbo.GetDeliverPO('OUV',getdate()) as Outwhid"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("系统在自动生成出货单号时,发生错误...")
            GenMainNumber = ""
        Else
            GenMainNumber = dt.Rows(0)(0).ToString
        End If
    End Function

    '查询
    Private Sub querydata(Outwhid As String)
        Dim strSQL As String = "SELECT Outwhid, ProNo,Qty FROM m_WHsInstruct_t where 1 = 1 "

        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtProNo.Text)) = False Then
            strWhere.AppendFormat(" and ProNo = '{0}' ", txtProNo.Text)
        End If
        'If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(dtpDeliverDate.Value)) = False Then
        '    strWhere.AppendFormat(" and DeliverDate = '{0}' ", dtpDeliverDate.Value)
        'End If
        strWhere.AppendFormat(" and  convert(varchar,DeliverDate,111) =  '{0}' ", dtpDeliverDate.Value.ToString("yyyy/MM/dd"))
        If Outwhid <> "" Then
            strWhere.AppendFormat(" and Outwhid = '{0}' ", Outwhid)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtOutwhid.Text)) = False Then
            strWhere.AppendFormat(" and Outwhid = '{0}' ", txtOutwhid.Text)
        End If

        strSQL = strSQL + strWhere.ToString

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        dgvWHsInstruct.DataSource = dt
        SetWhs(0)
    End Sub

    '生成二维码
    Private Sub SetQR(Outwhid As String, DetailSheet As Worksheet)
        Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.Code39)
        bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

        Dim o_strPicturePath As String = Environment.CurrentDirectory + "\" & "barcode.bmp"
        bc1.QRSave(Outwhid, o_strPicturePath, 3)

        Dim pictures As Aspose.Cells.Drawing.PictureCollection = DetailSheet.Pictures
        'C1
        pictures.Add(0, 6, o_strPicturePath)
    End Sub

    '得到GRID1数据
    Private Function GetDataTable(outwhid As String) As DataTable
        Dim strSQL As String = " SELECT Outwhid, ProNo, Unit, Qty, DeliverDate, CustName, CustTel, DeliverAddress, SupplyTel, SupplyAddress FROM m_WHsInstruct_t " &
                               " WHERE Outwhid = '{0}' "

        strSQL = String.Format(strSQL, outwhid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

    '得到GRID2数据
    Private Function GetDataTable2(outwhid As String) As DataTable
        Dim strSQL As String = " SELECT Outwhid, ProNo, LotNo, Version, CarType, LineName, Code, Qty, IsFullCarton, IsFinish FROM m_WHsDeliver_t " &
                               " WHERE Outwhid = '{0}'  " ' AND IsFinish = 0

        strSQL = String.Format(strSQL, outwhid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

    '取得说明
    Private Function GetRemark(Outwhid As String) As String
        GetRemark = ""
        Dim strSQL As String =
            " select sum(cnt) cnt ,sum(fullQty) fullQty,sum(Zeroqty) Zeroqty from " &
            "( " &
            "select count(1) cnt, round(cast(sum(qty/CArtonQty)as float),0) fullQty ,0 Zeroqty from m_WHsDeliver_t where outwhid = '{0}' and isfullcarton = 1" &
                    "union all " &
            "select count(1) cnt,count(1)  fullQty,count(1)  Zeroqty from m_WHsDeliver_t where outwhid = '{0}' and isfullcarton = 0 " &
            ") A"

        strSQL = String.Format(strSQL, Outwhid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetRemark = "货清单: 清单项数为（{0}）项，总箱数({1})箱，零箱数量（{2}）箱"
            GetRemark = String.Format(GetRemark, dt.Rows(0)(0).ToString, dt.Rows(0)(1).ToString, dt.Rows(0)(2).ToString)
        End If
    End Function

    '删除出货单
    Private Sub DeleteDeliver()
        Dim strSQL As String =
            " insert into m_WHsDeliver_t_log " &
            " select Outwhid, ProNo, LotNo, Version, CarType, LineName, Code, Qty, CartonQty, IsFullCarton, IsFinish, UserId, Intime, '{0}', getdate() " &
            " from m_WHsDeliver_t where  Outwhid='{1}' " &
            " delete m_WHsInstruct_t where Outwhid='{1}' " &
            " delete m_WHsDeliver_t  where Outwhid='{1}' "
        strSQL = String.Format(strSQL, SysMessageClass.UseId, txtOutwhid.Text.Trim)

        DbOperateUtils.ExecSQL(strSQL)

        MessageUtils.ShowInformation("删除成功！")
    End Sub

    '检查生成
    Private Function Check() As Boolean
        If String.IsNullOrEmpty(txtOutwhid.Text) = True Then
            txtOutwhid.Focus()
            MessageUtils.ShowInformation("请输入出货单号！")
            Return False
        End If
        Return True
    End Function

#End Region

End Class