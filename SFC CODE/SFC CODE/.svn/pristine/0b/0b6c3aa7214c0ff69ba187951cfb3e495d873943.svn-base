Imports MainFrame
Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Drawing
Imports MainFrame.SysDataHandle

Public Class FrmBBYPONumber

#Region "定义"

    Private Enum CDImportGrid
        Palace
        DeliveryDate
        CUSPartID
        PARTID
        SKU
        PONumber
        PO
        TOTALQty
        Qty
        CBM
        GW
    End Enum
#End Region

    '初期化
    Private Sub FrmBBYPONumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)

        '初期化数据
        LoadDataToDatagridview(GetSqlWhere())
    End Sub

    '模板文件查找
    Private Sub lkFile_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "BBYPO单导入模板")
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据 (5:代表5列数据)
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 1, 1, 11, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select("PONumber IS NOT NULL AND SKU IS NOT NULL") '防止追加

            If CheckUploadData(DrrR) = False Then
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
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmBBYPONumber", "toolImport_Click", "sys")
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
            'Dim strSQL As String = " DELETE m_WhBBYPONumber_t WHERE HWShippOrder = '{0}' "
            'strSQL = String.Format(strSQL, txtSKU.Text.Trim)
            'DbOperateUtils.ExecSQL(strSQL)

            'MessageUtils.ShowInformation("删除成功!")

            'LoadDataToDatagridview(GetSqlWhere())
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmHWPONumber", "toolImport_Click", "sys")
        End Try
    End Sub

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""

        For index As Integer = 0 To DrrR.Length - 1

            '华为料号
            Dim qty As String = DrrR(index)("TotalQty").ToString.Trim
            If qty = "" Then
                MessageUtils.ShowError("[出货数量]有空值,请检查后重新上传。")
                Return False
            End If

        Next

        Return True
    End Function

    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""

        SqlStr = " SELECT TOP 1000  Palace,convert(varchar(10),DeliveryDate,111)DeliveryDate, CUSPartID,PartID,SKU, PONumber,TotalQty, Qty, CBM,GW,UserID, Intime,state FROM m_WhBBYPONumber_t " &
                 " where 1=1 " & SqlWhere &
                 " order by state asc, DeliveryDate desc ,PONumber asc, SKU asc "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        dataGrid.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            dataGrid.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString,
                              dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString, dt.Rows(i).Item(5).ToString,
                              dt.Rows(i).Item(6).ToString, dt.Rows(i).Item(7).ToString, dt.Rows(i).Item(8).ToString,
                              dt.Rows(i).Item(9).ToString, dt.Rows(i).Item(10).ToString, dt.Rows(i).Item(11).ToString,
                              dt.Rows(i).Item(12).ToString)
        Next

        dataGrid.AutoResizeColumns()

        For rowIndex As Integer = 0 To dataGrid.Rows.Count - 1
            If dataGrid.Rows(rowIndex).Cells("state").Value.ToString = "1" Then
                dataGrid.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGray
            Else
                dataGrid.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        Next

        tsbLabel1.Text = "行数：" + dataGrid.Rows.Count.ToString
    End Sub

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If Me.txtPONumber.Text.Trim <> "" Then
            Sql = Sql & " and PONumber like '%" & Me.txtPONumber.Text.Trim & "%' "
        End If
        If Me.txtSKU.Text.Trim <> "" Then
            Sql = Sql & " and SKU like '%" & Me.txtSKU.Text.Trim & "%' "
        End If
        If chkDeliveryDate.Checked = True Then
            Sql = Sql & String.Format(" and convert(varchar(10),DeliveryDate,111) = convert(varchar(10),CAST('{0}' AS DATETIME),111)  ", dtpDeliveryDate.Value)
        End If

        Return Sql
    End Function

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String

        Dim strInsertSQL As New StringBuilder
        Dim hwPO As String = txtSKU.Text.Trim


        Dim strSQL As String =
            " DELETE m_WhBBYPONumber_t WHERE SKU = '{4}' AND PONumber = '{5}' AND state = 0 " &
            " IF NOT EXISTS (SELECT TOP 1 SKU FROM m_WhBBYPONumber_t WHERE PONumber = '{5}' and SKU='{4}' AND DeliveryDate = '{1}')" &
            " INSERT m_WhBBYPONumber_t (Palace,DeliveryDate,CUSPartID, PartID, SKU, PONumber,PO, TotalQty, Qty, CBM,GW, UserID, Intime ) Values " &
            " ( N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',getdate())"

        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(4).ToString(),
                                      row(5).ToString(), row(6).ToString(), row(7).ToString(), row(8).ToString(), row(9).ToString(),
                                      row(10).ToString(), VbCommClass.VbCommClass.UseId)
            strInsertSQL.AppendLine()
        Next

        Return strInsertSQL.ToString
    End Function

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
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