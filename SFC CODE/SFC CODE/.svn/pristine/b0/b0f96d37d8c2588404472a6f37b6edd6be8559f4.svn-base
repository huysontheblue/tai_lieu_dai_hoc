Imports System.Windows.Forms
Imports MainFrame
Imports System.IO
Imports Aspose.Cells
Imports System.Net
Imports MainFrame.SysCheckData

Public Class FrmHMshipment
    Dim sArray As String()

    Private Sub FrmHMshipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As String = " SELECT [PARAMETER_VALUES] FROM m_SystemSetting_t WHERE PARAMETER_CODE = 'hmftp'"
        Dim dt As DataTable
        dt = DbOperateReportUtils.GetDataTable(SQL)
        sArray = dt.Rows(0)(0).Split("%")
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "exec GetH01andH02WhsOutDataZH '" & txtFilter.Text.Trim & "'"
        dt = DbOperateReportUtils.GetDataTable(strSQL)
        Detailed.DataSource = ""
        Detailed.DataSource = dt
        ToolCount.Text = Detailed.RowCount.ToString
    End Sub
    Private Sub CuteFTP_Click(sender As Object, e As EventArgs) Handles btnCuteFTP.Click
        Dim carton = New List(Of String)()
        Dim strSQL As String
        Dim dt As DataTable
        Dim filename As String = ""
        '获取去重后的箱号
        For index = 0 To Detailed.Rows.Count - 1
            If Not carton.Contains(Detailed.Rows(index).Cells(14).Value.ToString) Then
                carton.Add(Detailed.Rows(index).Cells(14).Value.ToString)
            End If
        Next
        '检查箱号是否存在出货表中
        strSQL = "SELECT COUNT(1) FROM dbo.m_H01upload WHERE Cartonid IN("
        For index = 0 To carton.Count - 1

            If carton.Count - 1 = index Then
                strSQL += "'" + carton(index) + "'"
            Else
                strSQL += "'" + carton(index) + "',"
            End If

        Next
        strSQL += ") "
        dt = DbOperateReportUtils.GetDataTable(strSQL)
        If dt.Rows(0)(0) <> ToolCount.Text Then
            MessageUtils.ShowInformation("存在缺少数据")
            Return
        End If
        '检查文件是否存在
        LoadDataToExcel1(Detailed, "" & txtFilter.Text.Trim & "", "", "2")
        Dim path As String = "\\192.168.20.123\SFCShare\HM"
        If Directory.Exists(path) Then
            filename = path & "\" & "" & txtFilter.Text & ".xlsx"
            If File.Exists(filename) Then
            Else
                MessageUtils.ShowInformation("文件不存在")
                Return
            End If
        End If
        '调用FTP上传文件
        Upload(filename)
    End Sub

    Public Function Upload(ByVal path As String) As String
        Dim client = New WebClient()
        Dim strSQL, Sql As String
        'client.Credentials = New NetworkCredential("hmw042132", "hmw042132@")
        client.Credentials = New NetworkCredential("" & sArray(1) & "", "" & sArray(2) & "")
        client.BaseAddress = "" & sArray(0) & ""
        'client.BaseAddress = "ftp://hmw042132.my3w.com/TEST"
        Dim ftpPath As String = client.BaseAddress & "" & txtFilter.Text & ".xlsx "
        Dim returnPath As String = ""
        Try
            client.UploadFile(ftpPath, path)
            returnPath = ftpPath
            strSQL = " IF NOT EXISTS(SELECT amount FROM dbo.m_EDItypefile_t WHERE FileName = '" & txtFilter.Text.Trim & "')" &
                 "  BEGIN INSERT INTO m_EDItypefile_t (FileName,usey,intime,amount) VALUES ('" & txtFilter.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),'1') END" &
                 "  ELSE BEGIN UPDATE m_EDItypefile_t SET amount = amount +1 , upusey = '" & VbCommClass.VbCommClass.UseId & "',uptime = getdate() WHERE FileName = '" & txtFilter.Text.Trim & "' END "

            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("上传成功！")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
        Return returnPath
    End Function
    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        'If Detailed.Rows.Count < 1 Then
        '    Return
        'End If
        LoadDataToExcel1(Detailed, "" & txtFilter.Text.Trim & "", "", "1")
    End Sub
    '导出文件方法
    Private Sub LoadDataToExcel1(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "", Optional ByVal A As String = "")
        Try
            Dim strpath As String = ""
            If DgMoData.RowCount = 0 Then
                MessageUtils.ShowError("请确认需导出的数据资料！")
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
            '判断点击的是上传还是导出按钮
            If A = 1 Then
                strpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            Else
                strpath = "\\192.168.20.123\SFCShare\HM"
            End If

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
            If A = 1 Then
                MessageUtils.ShowInformation("文件导出成功,导出位置：" + tbname + ".xlsx !")
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
End Class