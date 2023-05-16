Imports MainFrame
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

''' <summary>
''' 创建者：田玉琳
''' 创建时间：20181127
''' 创建内容：多层包装删除
''' 
''' </summary>
''' <remarks></remarks>
Public Class FrmMultiPackScanDetail

    Private Sub FrmMultiPackScanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.DgPackingData
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

    '
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    '删除最外层外箱
    Private Sub toolDeleteCartonid4_Click(sender As Object, e As EventArgs) Handles toolDeleteCartonid.Click
        Try
            If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
                MessageUtils.ShowWarning("请选择要删除数据")
                Return
            End If

            If (Me.DgPackingData.CurrentRow.Cells(0).Value Is Nothing) Then
                MessageUtils.ShowWarning("删除箱不能为空")
                Return
            Else
                If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(0).Value.ToString.Trim)) Then
                    MessageUtils.ShowWarning("请选择要删除数据")
                    Return
                End If
            End If

            If (Me.DgPackingData.CurrentRow.Cells(1).Value Is Nothing) Then
                MessageUtils.ShowWarning("删除产品不能为空")
                Return
            End If

            If (String.IsNullOrEmpty(Me.txtReason.Text)) Then
                MessageUtils.ShowWarning("请填写删除原因")
                Return
            End If

            If (MessageUtils.ShowConfirm("你确定删除该产品包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                Return
            End If

            Dim strSQL As String
            Dim strMoid As String
            Dim strCartonId As String
            Dim strHandleType As String

            strMoid = Me.DgPackingData.CurrentRow.Cells(0).Value.ToString().ToUpper().Replace("'", "''")
            strCartonId = Me.DgPackingData.CurrentRow.Cells(1).Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = cbmType.SelectedIndex

            strSQL = " DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128) " & _
                   " EXECUTE [Exec_MultiPackingExceptionHandle] @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'{0}','{1}','{2}','{3}','{4}','{5}','{6}'" &
                   " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "
            strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, VbCommClass.VbCommClass.UseId,
                                   strMoid, strCartonId, strHandleType, txtReason.Text.Trim)


            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        MessageBox.Show(dt.Rows(0)(1).ToString())
                    Case "1"
                        MessageUtils.ShowWarning("删除成功,请重新设置当前产线[包装扫描设置]!")
                        Me.txtReason.Text = String.Empty
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
            Dim errMsg As Exception = New Exception(ex.ToString)
            SysMessageClass.WriteErrLog(ex, "FrmMultiPackScanDetail", "toolDeleteCartonid4_Click", "sys")
        End Try
    End Sub

    '刷新
    Private Sub ToolReflesh_Click(sender As Object, e As EventArgs) Handles ToolReflesh.Click
        Try

            Dim strSQL As String = " exec p_GetMultiPackingDataDetail '{0}','{1}','{2}','{3}'"

            strSQL = String.Format(strSQL, txtmoid.Text.Trim, "", txtcartonid.Text.Trim, TxtPPID.Text.Trim)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            DgPackingData.DataSource = dt

        Catch ex As Exception
            Dim errMsg As Exception = New Exception(ex.ToString)
            SysMessageClass.WriteErrLog(ex, "FrmMultiPackScanDetail", "ToolReflesh_Click", "sys")
        End Try
    End Sub

    'GRID双击事件
    Private Sub DgPackingData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPackingData.CellDoubleClick
        Dim strCarton As String
        If e.RowIndex = -1 Then Exit Sub
        strCarton = DgPackingData.Rows(e.RowIndex).Cells(1).Value.ToString()
        If (String.IsNullOrEmpty(strCarton)) Then
            MessageUtils.ShowWarning("未扫描任何中箱和产品")
            Return
        End If

        Dim FrmShowDetail As New FrmMultiShowDetail
        FrmShowDetail.cartonId = strCarton
        FrmShowDetail.DeleteType = cbmType.SelectedIndex
        FrmShowDetail.ShowDialog()
    End Sub


End Class