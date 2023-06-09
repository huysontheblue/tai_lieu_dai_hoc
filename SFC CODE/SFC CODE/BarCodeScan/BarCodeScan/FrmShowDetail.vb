Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData

''' <summary>
''' 修改者：田玉琳
''' 修改日期：20181204
''' 修改内容：更新查询明细方法
''' 
''' </summary>
''' <remarks></remarks>
Public Class FrmShowDetail
    Public cartonId As String
    Public strLink As String

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgData.RowPrePaint
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

#End Region

    '初期化
    Private Sub FrmShowDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ShowDetailData()
        With Me.DgData
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With

        ShowDetail()
    End Sub

    '导出EXCEL
    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    '退出
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    '删除条码
    Private Sub ToolDeleteBarcode_Click(sender As Object, e As EventArgs) Handles ToolDeleteBarcode.Click
        Try
            If Me.DgData.Rows.Count = 0 OrElse Me.DgData.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要删除数据")
                Return
            End If

            If (Me.DgData.CurrentRow.Cells(0).Value Is Nothing) Then
                MessageBox.Show("删除箱不能为空")
                Return
            Else
                If (String.IsNullOrEmpty(Me.DgData.CurrentRow.Cells(0).Value.ToString.Trim)) Then
                    MessageBox.Show("请选择要删除数据")
                    Return
                End If
            End If

            If (Me.DgData.CurrentRow.Cells(1).Value Is Nothing) Then
                MessageBox.Show("删除产品不能为空")
                Return
            End If

            If (String.IsNullOrEmpty(Me.txtReason.Text)) Then
                MessageBox.Show("请填写删除原因")
                Return
            End If

            If (MessageUtils.ShowConfirm("你确定删除该产品包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Try
                Dim strSQL As String
                Dim strCartonId As String
                Dim strPPId As String
                Dim strHandleType As String

                strCartonId = Me.DgData.CurrentRow.Cells(0).Value.ToString().ToUpper().Replace("'", "''")
                strPPId = Me.DgData.CurrentRow.Cells(1).Value.ToString().ToUpper().Replace("'", "''")
                strHandleType = "0"

                '关晓艳修改 增加删除原因
                strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                         " EXECUTE Exec_PackingPPIDExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                         VbCommClass.VbCommClass.profitcenter & "'," &
                         "'" & VbCommClass.VbCommClass.UseId & "','" & strCartonId & "','" & strPPId & "','" & strHandleType.Replace("'", "''") & "',N'" &
                         Me.txtReason.Text.Trim & "'" &
                         " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

                Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If drGetSQLRecor.Rows.Count > 0 Then
                    Select Case drGetSQLRecor.Rows(0)(0).ToString()
                        Case "0"
                            MessageUtils.ShowInformation(drGetSQLRecor.Rows(0)(1).ToString())
                        Case "1"
                            MessageUtils.ShowInformation("删除成功,请重新设置当前产线[包装扫描设置]!")
                            Me.txtReason.Text = String.Empty   'add by cq 20171227
                    End Select
                End If
                ShowDetail()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MessageBox.Show("删除条码异常")
        End Try
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            ShowDetail()
        Catch ex As Exception
        End Try
    End Sub

    '显示明细资料 
    Private Sub ShowDetail()
        Dim ppid As String = "%"
        If Not String.IsNullOrEmpty(Me.txtPPID.Text.Trim()) Then
            ppid = txtPPID.Text.Trim
        End If

        Dim sql As String = "exec m_QueryPackRecord_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'"
        sql = String.Format(sql, "", "", "", "", "", "", "", cartonId, ppid, "%", strLink, "D", "%")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)

        DgData.DataSource = dt

        Dim ChColsText As String = ""
        If strLink = "連接PPID" Or strLink = "" Then
            ChColsText = "外箱编号|产品序号|扫描人员|扫描时间"
        End If

        If strLink = "連接Date Code" Then
            ChColsText = "外箱编号|Date Code|扫描人员|扫描时间"
        End If
        Dim colNames As String() = ChColsText.Split("|")

        If ChColsText <> "" Then
            For i As Integer = 0 To DgData.Columns.Count - 1
                DgData.Columns(i).HeaderText = colNames(i)
                DgData.Columns(i).Name = colNames(i)
            Next
        End If
        ToolCount.Text = dt.Rows.Count
    End Sub

End Class