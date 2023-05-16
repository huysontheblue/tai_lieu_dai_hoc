Imports MainFrame
Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Drawing
Imports MainFrame.SysDataHandle
''' <summary>
''' 导入华为PO单号
''' 创建者：田玉琳
''' 创建日期：20171020
''' 创建者：田玉琳
''' 更新日期：20190708
''' 更新内容：按新的华为附件格式导入
''' </summary>
''' <remarks></remarks>
Public Class FrmHWPONumber

#Region "定义"

    Private Enum CDImportGrid
        HWCartonID
        HWPONumber
        Qty
        HWPartID
    End Enum

    Private Enum CDImportGridNew
        HWCartonID
        col2
        col3
        HWPartID
        col5
        col6
        col7
        col8
        col9
        col10
        Qty
        col12
        col13
        col14
        col15
        col16
        HWPONumber
    End Enum

#End Region

    '初期化
    Private Sub FrmHWPONumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)

        '初期化数据
        LoadDataToDatagridview(GetSqlWhere())
    End Sub

    '模板文件查找
    Private Sub lkFile_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "HWPO单导入模板")
    End Sub

    '模板文件查找新
    Private Sub lkFileNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFileNew.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "HWPO单导入模板（新）")
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If txtHWShippOrder.Text.Trim = "" Then
                MessageUtils.ShowError("请输入预约单号！")
                Return
            End If

            If CheckShippOrder() = False Then
                Return
            End If

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据 (5:代表5列数据)
            Dim dtUploadData As DataTable
            If (chkIsNew.Checked = True) Then
                dtUploadData = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 17, errorMsg)
                ChangeCDDataTableColumnNameNew(dtUploadData)
            Else
                dtUploadData = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 5, errorMsg)
                ChangeCDDataTableColumnName(dtUploadData)
            End If


            Dim DrrR As DataRow() = dtUploadData.Select("HWPONumber IS NOT NULL AND HWCartonID IS NOT NULL") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            If DrrR.Length = 0 Then
                MessageUtils.ShowInformation("没有可以导入的数据,请确认！")
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)

            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入！")
            End If
            LoadDataToDatagridview(GetSqlWhere())
            Threading.Thread.Sleep(300)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmHWPONumber", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview(GetSqlWhere())
    End Sub

    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            Dim strSQL As String = " DELETE m_WhHWPONumber_t WHERE HWShippOrder = '{0}' "
            strSQL = String.Format(strSQL, txtHWShippOrder.Text.Trim)
            DbOperateUtils.ExecSQL(strSQL)

            MessageUtils.ShowInformation("删除成功!")

            LoadDataToDatagridview(GetSqlWhere())
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmHWPONumber", "toolImport_Click", "sys")
        End Try
    End Sub

    '检查
    Private Function CheckShippOrder() As Boolean
        Dim strSQL As String = " SELECT HWCartonID FROM m_WhHWPONumber_t WHERE HWShippOrder = '{0}' "
        strSQL = String.Format(strSQL, txtHWShippOrder.Text.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            MessageUtils.ShowError("系统中已存在预约单号:" + txtHWShippOrder.Text.Trim)
            Return False
        End If
        Return True
    End Function

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""

        For index As Integer = 0 To DrrR.Length - 1

            '华为料号
            Dim hwCartonID As String = DrrR(index)("HWCartonID").ToString.Trim
            Dim strSQL As String = " SELECT HWShippOrder FROM m_WhHWPONumber_t WHERE HWCartonID = '{0}' "
            strSQL = String.Format(strSQL, hwCartonID)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError(String.Format("系统中已存在箱ID号:{0},对应的预约单号：{1},请确认！", hwCartonID, dt.Rows(0)(0).ToString))
                Return False
            End If

            '华为料号
            Dim hwPartID As String = DrrR(index)("HWPartID").ToString.Trim
            If hwPartID = "" Then
                MessageUtils.ShowError("[华为料号]有空值,请检查后重新上传。")
                Return False
            End If

            '华为料号
            Dim qty As String = DrrR(index)("Qty").ToString.Trim
            If qty = "" Then
                MessageUtils.ShowError("[每箱数量]有空值,请检查后重新上传。")
                Return False
            End If

        Next

        Return True
    End Function

    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""

        SqlStr = " SELECT TOP 1000 HWShippOrder, HWPONumber, HWCartonID, HWPartID, TotalQty, Qty, [ZeroNineBarCode], UserID ,InTime FROM m_WhHWPONumber_t " &
                 " where 1=1 " & SqlWhere &
                 " order by  InTime desc,HWCartonID asc "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        dataGrid.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            dataGrid.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString,
                              dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString, dt.Rows(i).Item(5).ToString,
                              dt.Rows(i).Item(6).ToString, dt.Rows(i).Item(7).ToString, dt.Rows(i).Item(8).ToString)
        Next

        dataGrid.AutoResizeColumns()
        tsbLabel1.Text = "行数：" + dataGrid.Rows.Count.ToString
    End Sub

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If Me.txtHWPONumber.Text.Trim <> "" Then
            Sql = Sql & " and HWPONumber like '%" & Me.txtHWPONumber.Text.Trim & "%' "
        End If
        If Me.txtHWShippOrder.Text.Trim <> "" Then
            Sql = Sql & " and HWShippOrder like '%" & Me.txtHWShippOrder.Text.Trim & "%' "
        End If

        Return Sql
    End Function

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String

        Dim strInsertSQL As New StringBuilder
        Dim hwPO As String = txtHWShippOrder.Text.Trim

        'strSQL = "INSERT m_WhHWPONumber_t (HWCartonID,HWPONumber, Qty,HWPartID,UserID,InTime) Values " &
        '"( N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',getdate())"
        Dim strSQL As String = "INSERT m_WhHWPONumber_t (HWCartonID,HWPONumber, Qty,HWPartID,HWShippOrder,ZeroNineBarCode,UserID,InTime) Values " &
                             "( N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',getdate())"

        Dim code09 As String
        For Each row As DataRow In DRS
            code09 = "09" + row("HWPartID").ToString() + hwPO
            strInsertSQL.AppendFormat(strSQL, row("HWCartonID").ToString(), row("HWPONumber").ToString(), row("Qty").ToString(), row("HWPartID").ToString(), hwPO,
                                      code09, VbCommClass.VbCommClass.UseId)
            strInsertSQL.AppendLine()
        Next

        strSQL = " DECLARE @totalQtys FLOAT "
        strSQL = strSQL + " SELECT @totalQtys = sum(qty) FROM m_WhHWPONumber_t WHERE HWShippOrder = '{0}' "
        strSQL = strSQL + " UPDATE m_WhHWPONumber_t SET TotalQty = @totalQtys WHERE HWShippOrder = '{0}' "
        strInsertSQL.AppendFormat(strSQL, hwPO)
        strInsertSQL.AppendLine()

        Return strInsertSQL.ToString
    End Function

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnNameNew(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGridNew In [Enum].GetValues(GetType(CDImportGridNew))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGridNew), i).ToString
        Next
    End Sub

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

    '检查方法
    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function

#Region "Grid行数"
    Private Sub dgvResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dataGrid.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class