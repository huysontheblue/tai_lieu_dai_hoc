Imports MainFrame.SysDataHandle
Imports Microsoft.Office.Interop
Imports System.IO
Imports MainFrame

Public Class FrmTaskTime

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim strSQL As String
        Dim Table As New DataTable
        Dim strUPN As String = txtPN.Text.Trim.ToUpper
        Dim strpns As String = ""
        Dim strRateSql As String = ""
        strSQL = "SELECT CAST(ROW_NUMBER() OVER(ORDER BY ppart) AS    INT) ID,* FROM (SELECT a.ppart, a.pn as N'物料编码',a.version as N'版本',a.rateQTY as N'配置',a.summary AS N'总工时(单根)',[铆端(01)] ,[裁切(04)] ,[生产工时] ,[成型(03)],NULL N'配套工时',a.summary*rateQTY as N'工时汇总' from dbo.v_gettasktime a where 1=1 "

        If String.IsNullOrEmpty(strUPN) Then
            MsgBox("请输入料件编码!", 48, "提示")
            Exit Sub
        End If
        Try
            If strUPN.Split(vbCrLf).Length > 1 Then
                Dim ups As String() = strUPN.Split(vbCrLf)
                For Each pn In ups
                    If Not String.IsNullOrEmpty(pn) Then
                        pn = pn.Replace(vbCr, "")
                        pn = pn.Replace(vbLf, "")
                        strpns = strpns & " PPART  LIKE '" & pn.Trim.ToUpper & "%' OR "
                    End If
                Next pn
                strpns = " AND (" + strpns.Substring(0, strpns.Length - 3) + ")"
            Else
                strpns = " AND PPART like'" & strUPN & "%'"
            End If
            strRateSql = " union  SELECT  ppart,PPART as PN ,null,NULL,null,null,NULL,null,null ,SUM(b.RateQTY)*15+3+10+15 N'配套工时',NULL FROM dbo.V_GETTASKTIME B where 1=1   "
            strRateSql = strRateSql & strpns & " GROUP BY ppart"
            strSQL = strSQL & strpns & strRateSql & " ) t ORDER BY ppart"
            Table = DbOperateReportUtils.GetDataTable(strSQL)

            DgTaskTime.DataSource = Table
            DgTaskTime.Refresh()
        Catch ex As Exception
            MsgBox("查询出错!", 48, "提示")
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Try
            Me.LoadDataToExcel(Me.DgTaskTime, "TaskTime")
            Dim xlbook As Excel.Workbook
            Dim xlsApp As Excel.Application
            xlsApp = New Excel.Application
            xlsApp = CreateObject("excel.application")
            xlbook = xlsApp.Workbooks.Open("C:\MesExport\TaskTime.csv")
            xlsApp.Visible = True
        Catch ex As Exception
            MsgBox("查询出错!", 48, "提示")
        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub


    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()
            'MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function FileAccTest(FileName As String) As Boolean
        Dim inUse As Boolean = True
        Dim fs As FileStream = Nothing
        Try
            fs = New FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None)
            inUse = False
        Catch ex As Exception

        Finally
            If (Not (fs Is Nothing)) Then
                fs.Close()
            End If
        End Try
        Return inUse '//true表示正在使用,false没有使用  
    End Function
End Class