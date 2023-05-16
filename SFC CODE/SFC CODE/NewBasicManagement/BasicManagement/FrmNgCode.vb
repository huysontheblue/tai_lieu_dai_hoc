#Region "Imports"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

#End Region

Public Class FrmNgCode

#Region "定义"

    Private Enum CDImportGrid
        BigName
        CName
        RName
        MName
        Station
    End Enum
#End Region


#Region "KEYDOWN"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")
            Case 13
                SendKeys.Send("{Tab}")
            Case 27
                Me.Close()
        End Select
    End Sub

    '初期化
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   
        BMComDB.BindComboxNGCategory(cboNGXXType)
        BMComDB.BindComboxNGStation(cmbNgStationId)
        LoadDataToDatagridview()
    End Sub

#End Region


#Region "事件处理"

    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview()
    End Sub

    '退出 
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try

            If chkImport.Checked = True Then
                If txtBigCode.Text = "" Then
                    txtBigCode.Focus()
                    MessageUtils.ShowError("不良大类代码不良为空！")
                    Return
                End If
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
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 6, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            'Dim DrrR As DataRow() = dtUploadData.Select() '防止追加
            Dim DrrR As DataRow() = dtUploadData.Select("BigName  IS NOT NULL ") '防止追加

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("EsortName", "System.String", dtUploadData)

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)
            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入！")
            End If
            LoadDataToDatagridview()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim dt As DataTable = GetDataTable()

        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub

    '确认导入事件
    Private Sub chkImport_CheckedChanged(sender As Object, e As EventArgs) Handles chkImport.CheckedChanged
        If chkImport.Checked Then
            txtBigCode.ReadOnly = False
        Else
            txtBigCode.ReadOnly = True
            txtBigCode.Text = ""
        End If
    End Sub

    '维修方法
    Private Sub ToolM_Click(sender As Object, e As EventArgs) Handles ToolM.Click
        Dim fr As FrmNMethodCode = New FrmNMethodCode
        fr.ShowDialog()
    End Sub

    '不良原因
    Private Sub toolY_Click(sender As Object, e As EventArgs) Handles toolY.Click
        Dim fr As FrmNcauseCode = New FrmNcauseCode
        fr.ShowDialog()
    End Sub

    '不良现象
    Private Sub toolX_Click(sender As Object, e As EventArgs) Handles toolX.Click
        Dim fr As FrmNCode = New FrmNCode
        fr.ShowDialog()
    End Sub

    '查看导入格式 
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "不良原因现象维修方法代码维护导入模板")
    End Sub

#End Region


#Region "方法"
    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview()
        Dim dt As DataTable = GetDataTable()

        dataGrid.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            dataGrid.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString,
            dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString, dt.Rows(i).Item(5).ToString, dt.Rows(i).Item(6).ToString,
            dt.Rows(i).Item(7).ToString, dt.Rows(i).Item(8).ToString, dt.Rows(i).Item(9).ToString, dt.Rows(i).Item(10).ToString)
        Next

        dataGrid.MergeColumnNames.Add("colBigName")
        dataGrid.MergeColumnNames.Add("colBigCode")
        dataGrid.MergeColumnNames.Add("colCodeName")
        dataGrid.MergeColumnNames.Add("colCode")
        'dataGrid.MergeColumnNames.Add("colMName")
        'dataGrid.MergeColumnNames.Add("colMCode")
        'dataGrid.MergeColumnNames.Add("colStationName")
        'dataGrid.MergeColumnNames.Add("colStationCode")
        dataGrid.AutoResizeColumns()
    End Sub

    Private Function GetDataTable() As DataTable
        Dim ngType As String = ""
        Dim NgStationId As String = ""
        If Me.cboNGXXType.Text.Trim <> "" Then
            ngType = Me.cboNGXXType.Text.Trim.Split("-")(0)
        End If
        If Me.cmbNgStationId.Text.Trim <> "" Then
            NgStationId = Me.cmbNgStationId.Text.Trim.Split("-")(0)
        End If

        Dim strSQL As String = String.Format(" EXEC Exec_NgCode '{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}' ", VbCommClass.VbCommClass.UseId,
                                             NgStationId, ngType, txtNGXXName.Text.Trim, txtNRName.Text.Trim, txtMName.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If Me.cboNGXXType.Text.Trim <> "" Then
            Sql = Sql & " and EsortName='" & Me.cboNGXXType.Text.Trim.Split("-")(0) & "' "
        End If
        If Me.cmbNgStationId.Text.Trim <> "" Then
            Sql = Sql & " and station like '%" & Me.cmbNgStationId.Text.Trim.Split("-")(0) & "%' "
        End If
        If Me.txtNGXXName.Text.Trim <> "" Then
            Sql = Sql & " and CCName like N'%" & Me.txtNGXXName.Text.Trim & "%' "
        End If
        If Me.txtNRName.Text.Trim <> "" Then
            Sql = Sql & " and rCCName like N'%" & Me.txtNRName.Text.Trim & "%' "
        End If
        If Me.txtMName.Text.Trim <> "" Then
            Sql = Sql & " and MstyleName like N'%" & Me.txtMName.Text.Trim & "%' "
        End If

        Return Sql
    End Function

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String

        Dim strSQL As String = "EXEC [Exec_InsertNgCodeData] N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}'"

        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(4).ToString(), txtBigCode.Text.Trim, row(5).ToString().ToUpper,
                                      VbCommClass.VbCommClass.UseId)
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

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB不良现象大类别
        Dim codeNameSQL As String = " select distinct EsortName,CsortName from m_Code_t  where Usey = 'Y'  "
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)

        Dim staionSQL As String = " select Stationid,Stationname from m_Rstation_t where  NGY = 'Y' "
        Dim staionDT As DataTable = DbOperateUtils.GetDataTable(staionSQL)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""

        If chkImport.Checked = True Then
            If CheckExistUserColumns(codeNameDT, "EsortName", txtBigCode.Text.Trim, "") = True Then
                MessageUtils.ShowError("上传[不良现象大类代码]在资料库中：'" + txtBigCode.Text.Trim.ToUpper + "'")
                Return False
            End If
        End If

        For index As Integer = 0 To DrrR.Length - 1

            '不良现象大类别
            Dim strCodeName As String = DrrR(index)("BIGNAME").ToString.Trim

            Dim returnCode As String = ""
            If strCodeName <> "" Then
                If CheckExistUserColumns(codeNameDT, "CsortName", strCodeName, returnCode) = False Then
                    If chkImport.Checked = True Then
                        DrrR(index)("EsortName") = txtBigCode.Text.Trim
                    Else
                        MessageUtils.ShowError("上传[不良现象大类]没有在资料库中：'" + strCodeName + "'")
                        Return False
                    End If
                End If
            Else
                MessageUtils.ShowError("[不良现象大类]有空值,请检查后重新上传。")
                Return False
            End If

            '不良站点名称
            Dim staionName As String = DrrR(index)("Station").ToString.Trim
            If staionName <> "" Then
                If CheckExistUserColumns(staionDT, "Stationname", staionName, returnCode) = False Then
                    MessageUtils.ShowError("上传[不良站点名称]没有在资料库中：'" + staionName + "'")
                    Return False
                Else
                    'DrrR(index)("StationId") = returnCode
                End If
            Else
                MessageUtils.ShowError("[不良站点名称]有空值,请检查后重新上传。")
                Return False
            End If

            '不良代码
            Dim codeName As String = DrrR(index)("CName").ToString.Trim
            If codeName = "" Then
                MessageUtils.ShowError("[不良现象项目]有空值,请检查后重新上传。")
                Return False
            End If

            '不良原因
            Dim rCodeName As String = DrrR(index)("RName").ToString.Trim
            If rCodeName = "" Then
                MessageUtils.ShowError("[不良原因项目]有空值,请检查后重新上传。")
                Return False
            End If


            '维修方法
            Dim MName As String = DrrR(index)("MName").ToString.Trim
            If MName = "" Then
                MessageUtils.ShowError("[维修方法]有空值,请检查后重新上传。")
                Return False
            End If
        Next

        Return True
    End Function

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

#End Region


#Region "Grid行数"
    Private Sub dataGrid_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dataGrid.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class