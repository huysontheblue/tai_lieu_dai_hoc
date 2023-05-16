Imports System.Text
Imports MainFrame
Imports System.IO

Public Class FrmTiptopPlanQuery

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        GetMOPlan()
    End Sub
    Private Sub GetMOPlan()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine(" SELECT   [LineId],[MOid], [PartId], [Quantity], [NotfinishQTY], ROUND([NeedHours],4)[NeedHours], [InNumberDays], [PlanStartTime],[PlanEndTime], [ActualEndTime], ROUND([StandardWorkingHours],2)StandardWorkingHours, ")
            strSQL.AppendLine(" [Specification],[PlanRework],[PlanStatusFlagText],[Outdate]")
            strSQL.AppendLine(" FROM [V_GetMOPlan] WHERE 1=1")
            'If String.IsNullOrEmpty(Me.txtLineId.Text.Trim()) Then
            '    GetMesData.SetMessage(Me.lblMessage, "请输入线别", False)
            '    Return
            'End If
            Dim lines As String = Nothing
            For Each sLine As String In txtLineId.Text.Trim.ToUpper.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sLine) Then
                    lines &= "'" & sLine.ToUpper.Trim & "'" & ","
                End If
            Next
            If Not String.IsNullOrEmpty(lines) Then
                lines = lines.Trim(CChar(","))
                strSQL.AppendLine(" AND (LineId in (" & lines & ") OR LINEID ='')")
            End If
            If Not String.IsNullOrEmpty(Me.dtpStartDate.Text.Trim) Then
                strSQL.AppendLine(" AND CONVERT(date , PlanEndTime, 111 ) >= '" & Convert.ToDateTime(Me.dtpStartDate.Text.Trim).ToString("yyyy-MM-dd") & "' ")
            End If
            If Not String.IsNullOrEmpty(Me.dtpStartDate.Text.Trim) Then
                strSQL.AppendLine(" AND CONVERT(date , PlanEndTime, 111 ) <= '" & Convert.ToDateTime(Me.dtpEndDate.Text.Trim).ToString("yyyy-MM-dd") & "' ")
            End If
            If Not String.IsNullOrEmpty(Me.txtPartNo.Text.Trim) Then
                strSQL.AppendLine(" AND PartId  like '" & Me.txtPartNo.Text.Trim & "%' ")
            End If
            Me.dgvMoList.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(dgvMoList, "Plan")
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
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
                MessageBox.Show("没有需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub FrmTiptopPlanQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpEndDate.Text = Date.Now.Date.AddDays(7)
        Me.dtpStartDate.Text = Date.Now.Date
    End Sub
End Class