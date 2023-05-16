Imports MainFrame
Imports MainFrame.SysCheckData
''' <summary>
''' 创建者：田玉琳
''' 创建日期：20181204
''' 创建内容：新查询明细方法
''' 
''' </summary>
''' <remarks></remarks>
Public Class FrmMultiShowDetail

    Public cartonId As String
    Public DeleteType As String

    Private Sub FrmMultiShowDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.DgData
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With

        ShowDetail()
    End Sub

    '汇出资料
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            ShowDetail()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ToolDeleteBarcode_Click(sender As Object, e As EventArgs) Handles ToolDeleteBarcode.Click
        Try
            If Me.DgData.Rows.Count = 0 OrElse Me.DgData.CurrentRow Is Nothing Then
                MessageUtils.ShowInformation("请选择要删除数据")
                Return
            End If

            If (Me.DgData.CurrentRow.Cells(0).Value Is Nothing) Then
                MessageUtils.ShowInformation("删除箱不能为空")
                Return
            Else
                If (String.IsNullOrEmpty(Me.DgData.CurrentRow.Cells(0).Value.ToString.Trim)) Then
                    MessageUtils.ShowInformation("请选择要删除数据")
                    Return
                End If
            End If

            If (Me.DgData.CurrentRow.Cells(1).Value Is Nothing) Then
                MessageUtils.ShowInformation("删除产品不能为空")
                Return
            End If

            If (String.IsNullOrEmpty(Me.txtReason.Text)) Then
                MessageUtils.ShowInformation("请填写删除原因")
                Return
            End If

            If (MessageUtils.ShowConfirm("你确定删除该产品包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Try
                Dim strSQL As String
                Dim strCartonId As String
                Dim strPPId As String

                strCartonId = Me.DgData.CurrentRow.Cells(0).Value.ToString().ToUpper().Replace("'", "''")
                strPPId = Me.DgData.CurrentRow.Cells(1).Value.ToString().ToUpper().Replace("'", "''")

                '关晓艳修改 增加删除原因
                strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                         " EXECUTE Exec_MultiPackingPPIDExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                         VbCommClass.VbCommClass.profitcenter & "'," &
                         "'" & VbCommClass.VbCommClass.UseId & "','" & strCartonId & "','" & strPPId & "','" & DeleteType & "',N'" &
                         Me.txtReason.Text.Trim & "'" &
                         " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "


                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0).ToString()
                        Case "0"
                            MessageUtils.ShowInformation(dt.Rows(0)(1).ToString())
                        Case "1"
                            MessageUtils.ShowInformation("删除成功,请重新设置当前产线[包装扫描设置]!")
                            Me.txtReason.Text = String.Empty
                    End Select
                End If

                ShowDetail()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MessageUtils.ShowInformation("删除条码异常")
        End Try
    End Sub
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    '显示明细资料 
    Private Sub ShowDetail()
        Dim strSQL As String = " select cartonid '箱号',ppid '产品条码',userid '操作用户',intime '操作时间'  from m_cartonsn_t  where cartonid='{0}'  "
        strSQL = String.Format(strSQL, cartonId)

        If Not String.IsNullOrEmpty(Me.txtPPID.Text.Trim()) Then
            strSQL = strSQL + " and ppid = '{0}'"
            strSQL = String.Format(strSQL, txtPPID.Text.Trim)
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        DgData.DataSource = dt

        ToolCount.Text = dt.Rows.Count
    End Sub

End Class