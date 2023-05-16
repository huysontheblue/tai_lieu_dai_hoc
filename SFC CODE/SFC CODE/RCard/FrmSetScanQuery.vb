Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO

Public Class FrmSetScanQuery
    Private ObjDB As New SysDataBaseClass()
    Private Sub FrmSetScanQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim Moid As String = String.Empty
        Dim PPartID As String = String.Empty
        Dim PackBarcode As String = String.Empty
        Dim ChildBarcode As String = String.Empty
        Dim ChildPartID As String = String.Empty
        Dim strLineID As String = String.Empty

        DataGridView1.DataSource = Nothing 'Add by cq 20160701
        Dim strSql As String = ""

        If CobMo.Text <> "" And CobMo.Text <> "ALL" Then
            Moid = CobMo.Text.Trim()
        End If

        If CobPPartID.Text <> "" And CobPPartID.Text <> "ALL" Then
            PPartID = CobPPartID.Text.Trim()
        End If

        If CobChildPartID.Text <> "" And CobChildPartID.Text <> "ALL" Then
            ChildPartID = CobChildPartID.Text.Trim
        End If
        If CobPackBarcode.Text <> "" And CobPackBarcode.Text <> "ALL" Then
            PackBarcode = CobPackBarcode.Text.Trim
        End If

        If CobChildBarcode.Text <> "" And CobChildBarcode.Text <> "ALL" Then
            ChildBarcode = CobChildBarcode.Text.Trim
        End If

        If CobLineID.Text <> "" And CobLineID.Text <> "ALL" Then
            strLineID = CobLineID.Text.Trim
        End If
        '@begintime   varchar(25),  --起始時間  
        '@endtime     varchar(25),  --終止時間  
        '@moid        varchar(30),   --工單編號  
        '@PPartID       varchar(30),   --父料件編號  
        '@Pppid       varchar(50),  --成品条码  
        '@ChildBarcode        varchar(50),  --子条码
        '@PartID     varchar(20) --线别  
        strSql = "EXEC m_QuerySetScanData_p '" & StartDT & "','" & EndDT & "','" & Moid & "','" & PPartID & "'," & _
                 "'" & PackBarcode & "','" & ChildBarcode & "','" & ChildPartID & "', '" & strLineID & "'"
        Dim dt As DataTable = ObjDB.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            ToolCount.Text = dt.Rows.Count
            DataGridView1.DataSource = dt
        Else
            MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
        End If
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
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

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class