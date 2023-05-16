Imports MainFrame.SysCheckData
Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' 新增者： 田玉琳
''' 新增日： 2016/07/26
''' 新增内容：维修报表表示
''' </summary>
''' <remarks>显示维修报表和生成维修报表</remarks>
Public Class FrmMainTainRepairReport

#Region "公共变量"

    Private mLineid As String
    Public WriteOnly Property Lineid() As String
        Set(ByVal value As String)
            mLineid = value
        End Set
    End Property

    Private mNgDate As Date
    Public WriteOnly Property NgDate() As Date
        Set(ByVal value As Date)
            mNgDate = value
        End Set
    End Property

    Private mPartId As String
    Public WriteOnly Property PartId() As String
        Set(ByVal value As String)
            mPartId = value
        End Set
    End Property

    Private mDataTable As DataTable
    Public WriteOnly Property DTable() As DataTable
        Set(ByVal value As DataTable)
            mDataTable = value
        End Set
    End Property

#End Region

#Region "初期化"
    Private Sub FrmMainTainRepairReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.DesignMode = True Then Exit Sub

        txtQueryPn.Text = mPartId
        txtLineId.Text = mLineid
        txtNgDate.Text = mNgDate
        dataGrid.DataSource = mDataTable

        dataGrid.MergeColumnNames.Add("Column1")
        dataGrid.MergeColumnNames.Add("Column2")

    End Sub
#End Region
   
#Region "报表导出"
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim errorMsg As String = Nothing
        Dim fileDirectory As String = "c:\MesExport\"
        Dim ExcelPath As String = fileDirectory +
            String.Format("不良维修记录表日期{0}线别{1}料号{2}.xlsx", mNgDate.ToString("yyyy年MM月dd日"), mLineid, mPartId)

        Dim filePath As String = VbCommClass.VbCommClass.PrintDataModle & "\NGReportTemplate" & "\NGReportTemplate.xlsx"
        'Dim PpfPath As String = String.Format("c:\tiptop\" + "不良维修记录表{0}.xlsx", DateTime.Now.ToFileTimeUtc)
        If (System.IO.Directory.Exists(fileDirectory)) = False Then
            System.IO.Directory.CreateDirectory(fileDirectory)
        End If

        If mDataTable.Rows.Count > 0 Then
            mDataTable.TableName = "report"
            If Import2ExcelByAs(filePath, ExcelPath, mDataTable, errorMsg) Then
                MessageUtils.ShowInformation("导出成功,请查看！")
            Else
                MessageUtils.ShowError(errorMsg)
            End If
        Else
            MessageUtils.ShowInformation("无资料供导出！")
        End If

    End Sub
#End Region

#Region "生成维修报表"
    '生成维修报表
    Private Function Import2ExcelByAs(templateFile As String, ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(templateFile)
            workBookDesigner.Workbook = wk      '工作簿

            workBookDesigner.SetDataSource(dt)
            workBookDesigner.Process()

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            cells(2, 1).PutValue(mLineid.ToUpper)    '填写内容线别
            cells(2, 5).PutValue(mPartId.Trim)      '填写内容料号
            cells(2, 8).PutValue(mNgDate.ToString("yyyy/MM/dd"))   '填写内容日期

            '第一列数据合并
            Dim hashTable As Hashtable = GetHashTable(dt, 0)

            Dim startPos As Integer = 4
            For Each de As DictionaryEntry In hashTable
                cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 0, de.Value.ToString.Split("|")(2), 1) '合并单元格
                cells(de.Value.ToString.Split("|")(1) + startPos, 0).PutValue(de.Value.ToString.Split("|")(0))
            Next

            '第二列数据合并
            Dim hashTable2 As Hashtable = GetHashTable(dt, 1)

            For Each de As DictionaryEntry In hashTable2
                If de.Value.ToString.Split("|")(0) = "全检锡点" Or
                   de.Value.ToString.Split("|")(0) = "全检端子" Or
                   de.Value.ToString.Split("|")(0) = "终检成型" Or
                   de.Value.ToString.Split("|")(0) = "终检外观" Then
                    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 0, de.Value.ToString.Split("|")(2), 2) '合并2列单元格
                Else
                    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 1, de.Value.ToString.Split("|")(2), 1) '合并单元格
                End If
                cells(de.Value.ToString.Split("|")(1) + startPos, 1).PutValue(de.Value.ToString.Split("|")(0))
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

    '处理单元格合并共通方法
    Private Function GetHashTable(dt As DataTable, column As Integer) As Hashtable
        Dim alTemp As Hashtable = New Hashtable
        Dim tempObj As String = ""
        Dim posI As String = "0"
        Dim changeI As Integer = 0
        '合并单元格
        For i As Integer = 0 To dt.Rows.Count - 1 '行
            If dt.Rows(i)(column).ToString = "" Then
                Continue For
            End If
            If tempObj <> dt.Rows(i)(column).ToString Then
                tempObj = dt.Rows(i)(column).ToString
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

#End Region
  
#Region "Grid行数"
    Private Sub dgvResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dataGrid.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class