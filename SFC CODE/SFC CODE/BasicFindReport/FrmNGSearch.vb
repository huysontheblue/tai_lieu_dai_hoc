Imports UIHandler
Imports MainFrame

Public Class FrmNGSearch

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            Me.dgMainTain.AutoGenerateColumns = False
            DtStar.Value = Now().ToString("yyyy-MM-dd")
            DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
            LoadDataToCombo(cbbDept, 2)
        End If
    End Sub

    ''' <summary>
    ''' 刷新按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click

        Dim strSQL As String
        Try
            strSQL = "EXEC m_QueryNGSearch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, Me.TxtPpid.Text.Trim, Me.txtWorkCode.Text.Trim, Getid(cbbDept.Text), Me.cbbLine.Text,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "", "1")
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

            Me.dgMainTain.DataSource = dt
            dgMainTain_CellClick(Nothing, Nothing)
            ToolCount.Text = dgMainTain.RowCount.ToString()
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub

    ''' <summary>
    ''' EXCEL 导出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(dgMainTain, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        LoadLineIDToCombo(cbbLine, Getid(cbbDept.Text))
    End Sub

    Private Sub dgMainTain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMainTain.CellClick
        If Me.dgMainTain.Rows.Count = 0 Then Exit Sub

        '选择PPID
        Dim Ppid As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString

        Dim strSQL As String = String.Empty
        strSQL = "EXEC m_QueryNGSearch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'"
        strSQL = String.Format(strSQL, "", "", "", "", "", "", "", "", Ppid, "2")
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

        Me.dgvScrap.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            Me.dgvScrap.Rows.Add(dt.Rows(i)("Tpartid").ToString, dt.Rows(i)("TypeDest").ToString, dt.Rows(i)("ScrapQty").ToString, dt.Rows(i)("DeptName").ToString)
        Next

    End Sub

End Class