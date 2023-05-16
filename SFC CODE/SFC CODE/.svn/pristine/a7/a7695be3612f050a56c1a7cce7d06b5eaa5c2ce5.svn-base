Imports MainFrame
Imports Aspose.Cells

Public Class FrmCDefect
    Dim DEFECT_ID As String
    Private Sub FrmCDefect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combShow.SelectedIndex = 0
        combFilter.SelectedIndex = 0
        ShowData()
    End Sub
    Public Sub ShowData()
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "SELECT DEFECT_CODE AS 不良現象代碼, DEFECT_LEVEL AS 不良等级,DEFECT_DESC AS 描述 FROM m_QCDEFECT_t WHERE ENABLED = 'Y'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvData.DataSource = dt
    End Sub



    Private Sub btnAppend_Click(sender As Object, e As EventArgs) Handles btnAppend.Click
        Dim strSQL As String
        Dim dt As DataTable
        Dim frm As FrmQCData = New FrmQCData
        frm.g_sUpdateType = "APPEND"
        frm.ShowDialog()
        strSQL = "SELECT TOP 100 DEFECT_CODE AS 不良現象代碼, DEFECT_LEVEL AS 不良等级,DEFECT_DESC AS 描述 FROM m_QCDEFECT_t WHERE ENABLED = 'Y' ORDER BY DEFECT_ID DESC"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvData.DataSource = dt
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim f As FrmQCData = New FrmQCData()
        Try
            f.g_sUpdateType = "Update"
            Dim index As Integer = gvData.CurrentRow.Index
            f.DEFECT_CODE = gvData.Rows(index).Cells("不良現象代碼").Value.ToString()
            f.DEFECT_LEVEL = gvData.Rows(index).Cells("不良等级").Value.ToString()
            f.DEFECT_DESC = gvData.Rows(index).Cells("描述").Value.ToString()
            Dim strSQL As String
            Dim dt As DataTable
            f.ShowDialog()
            Check()
            strSQL = "SELECT DEFECT_CODE AS 不良現象代碼, DEFECT_LEVEL AS 不良等级,DEFECT_DESC AS 描述 FROM m_QCDEFECT_t WHERE DEFECT_ID = '" + DEFECT_ID + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            gvData.DataSource = dt
        Catch ex As Exception
        End Try
    End Sub

    Private Sub combShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combShow.SelectedIndexChanged
        S()
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        Dim index As Integer = gvData.CurrentRow.Index
        Check()
        strSQL = "UPDATE m_QCDEFECT_t SET Enabled = 'N',UPDATE_USERID='" + VbCommClass.VbCommClass.UseId + "',UPDATE_TIME = getdate() WHERE DEFECT_ID = '" + DEFECT_ID + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        MessageBox.Show("已停用")
        S()
    End Sub

    Private Sub btnEnabled_Click(sender As Object, e As EventArgs) Handles btnEnabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        Check()
        strSQL = "UPDATE m_QCDEFECT_t SET Enabled = 'Y',UPDATE_USERID='" + VbCommClass.VbCommClass.UseId + "',UPDATE_TIME = getdate() WHERE DEFECT_ID = '" + DEFECT_ID + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        MessageBox.Show("已恢复")
        S()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        Dim index As Integer = gvData.CurrentRow.Index
        Check()
        strSQL = "DELETE m_QCDEFECT_t WHERE DEFECT_ID ='" + DEFECT_ID + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        S()
    End Sub
    Private Sub S()
        Dim strSQL As String
        Dim dt As DataTable
        btnDelete.Visible = (combShow.SelectedIndex = 1)
        btnDisabled.Visible = (combShow.SelectedIndex = 0)
        btnEnabled.Visible = (combShow.SelectedIndex = 1)
        strSQL = "SELECT DEFECT_CODE AS 不良現象代碼, DEFECT_LEVEL AS 不良等级,DEFECT_DESC AS 描述 FROM m_QCDEFECT_t where 1=1"
        If combShow.SelectedIndex = 0 Then
            strSQL = strSQL + " and Enabled = 'Y'"
        ElseIf (combShow.SelectedIndex = 1) Then
            strSQL = strSQL + " and Enabled = 'N'"
        End If
        If combFilter.Text.Trim = "不良代码" Then
            strSQL = strSQL + " and DEFECT_CODE like'%" + editFilter.Text + "%'"
        ElseIf combFilter.Text.Trim = "不良等级" Then
            strSQL = strSQL + " and DEFECT_LEVEL like'%" + editFilter.Text.Trim() + "%'"
        ElseIf combFilter.Text.Trim = "不良描述" Then
            strSQL = strSQL + " and DEFECT_DESC like'%" + editFilter.Text.Trim() + "%'"
        End If
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvData.DataSource = dt
    End Sub
    Public Sub Check()
        Dim strSQL As String
        Dim dt As DataTable
        Dim index As Integer = gvData.CurrentRow.Index
        strSQL = "SELECT DEFECT_ID FROM m_QCDEFECT_t WHERE DEFECT_CODE = '" + gvData.Rows(index).Cells("不良現象代碼").Value.ToString() + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        DEFECT_ID = dt.Rows(0)(0).ToString()
    End Sub
    Private Sub editFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles editFilter.KeyDown
        If e.KeyValue = 13 Then
            S()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        LoadDataToExcel1(gvData, "不良现象基础数据_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
    End Sub
    Private Sub LoadDataToExcel1(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim wb = New Aspose.Cells.Workbook()
            Dim style = wb.Styles(wb.Styles.Add())
            style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0)
            style.Pattern = BackgroundType.Solid
            style.Font.IsBold = True

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            Dim strpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            'Environment.SpecialFolder.Desktop()
            'If Not Directory.Exists("c:\MesExport") Then
            '    Directory.CreateDirectory("c:\MesExport")
            'End If
            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                Dim columnName As String = DgMoData.Columns(comIndex).HeaderText
                wb.Worksheets(0).Cells(0, comIndex).PutValue(columnName)
                wb.Worksheets(0).Cells(0, comIndex).SetStyle(style)
                wb.Worksheets(0).AutoFitColumn(comIndex, 0, 150)
            Next
            nColqty = 1
            For Each r As DataRow In getTable.Rows
                For comIndex As Integer = 0 To getTable.Columns.Count - 1
                    wb.Worksheets(0).Cells(nColqty, comIndex).PutValue(r(comIndex).ToString())
                Next
                nColqty = nColqty + 1
            Next
            wb.Worksheets(0).FreezePanes(1, 0, 1, getTable.Columns.Count)
            Dim filepath As String = strpath + "\" + tbname + ".xlsx"
            wb.Save(filepath)
            MessageBox.Show("文件导出成功,导出位置：" + tbname + ".xlsx !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class