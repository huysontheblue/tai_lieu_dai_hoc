Imports UIHandler
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Threading

Public Class FrmOrderSchQuery


    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.DesignMode = False) Then
            Me.dgOrder.AutoGenerateColumns = False
            'DtStar.Value = Now().ToString("yyyy-MM-01")
            'DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
            SetVisible(False)
        End If
    End Sub

    ''' <summary>
    ''' EXEC [m_QueryKanBanOrderSearch_p] '2014-12-11','2015-12-16','','','','','LXXT','','1','',''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Me.Cursor = Cursors.WaitCursor
        Dim myThread As New Threading.Thread(AddressOf KBCom.ShowWaitWindow)
        Try
            myThread.Start()
            SetVisible(False)

            lblMsg.Text = String.Empty
            Dim strSQL As String
            strSQL = "EXEC m_QueryKanBanOrderSearch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'"
            strSQL = String.Format(strSQL, "", "", Me.txtOrderNo.Text.Trim, Me.txtOrderSeq.Text.Trim, "", "",
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "1", "", "")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            Me.dgOrder.DataSource = dt
            'dgOrder_CellClick(Nothing, Nothing)

            ToolCount.Text = dgOrder.RowCount.ToString()

            Threading.Thread.Sleep(300)
        Catch ex As ThreadAbortException
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
            SysMessageClass.WriteErrLog(ex, "KanBan", "dgDetail_CellDoubleClick", "MES")
        Finally
            Me.Cursor = Cursors.Arrow
            myThread.Abort()
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(dgOrder, Me.Text)
    End Sub

    Private Sub tsbDetail_Click(sender As Object, e As EventArgs) Handles tsbDetail.Click
        ExcelUtils.LoadDataToExcel(dgMoid, Me.Text)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub dgOrder_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOrder.CellClick
        If Me.dgOrder.Rows.Count = 0 Then Exit Sub
        Dim strSQL As String
        Try
            Dim orderNo As String = dgOrder.Rows(dgOrder.SelectedCells(0).RowIndex).Cells("colOrderNo1").Value.ToString
            Dim Orderseq As String = dgOrder.Rows(dgOrder.SelectedCells(0).RowIndex).Cells("colOrderseq1").Value.ToString
            Dim PartID As String = dgOrder.Rows(dgOrder.SelectedCells(0).RowIndex).Cells("colPartID1").Value.ToString
            Dim Cusid As String = dgOrder.Rows(dgOrder.SelectedCells(0).RowIndex).Cells("colCusid1").Value.ToString
            Dim SeriesID As String = dgOrder.Rows(dgOrder.SelectedCells(0).RowIndex).Cells("colSeriesID1").Value.ToString

            strSQL = "EXEC m_QueryKanBanOrderSearch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'"
            strSQL = String.Format(strSQL, "", "", orderNo, Orderseq, "", PartID,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "2", Cusid, SeriesID)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                dgMoid.Visible = True
                lblMoid.Visible = True
            End If
            Me.dgMoid.DataSource = dt

            If dgDetail.Visible = True Then
                dgMoid_CellClick(Nothing, Nothing)
            End If
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub

    Private Sub dgMoid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMoid.CellClick
        Dim strSQL As String
        Try
            Dim moid As String = String.Empty
            If sender Is Nothing Then
                If dgMoid.RowCount > 0 Then
                    moid = dgMoid.Rows(0).Cells("colMoid2").Value.ToString
                End If
            Else
                moid = dgMoid.Rows(dgMoid.SelectedCells(0).RowIndex).Cells("colMoid2").Value.ToString
            End If

            strSQL = "EXEC m_QueryKanBanOrderSearch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'"
            strSQL = String.Format(strSQL, "", "", "", "", moid, "",
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "3", "", "")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                dgDetail.Visible = True
                lblChildMoid.Visible = True
            End If

            Me.dgDetail.DataSource = dt
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub

    Private Sub dgDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetail.CellDoubleClick
        Dim empPhotoUrl As String = String.Empty
        Dim o_strUserID As String = String.Empty
        Try
            If IsNothing(Me.dgDetail.CurrentRow) Then Exit Sub
            o_strUserID = Me.dgDetail.CurrentRow.Cells("colleaderid2").Value.ToString
            If String.IsNullOrEmpty(o_strUserID) Then Exit Sub
            Using o_FrmPic As FrmPic = New FrmPic(o_strUserID)
                o_FrmPic.ShowDialog()
            End Using
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan", "dgDetail_CellDoubleClick", "MES")
        End Try
    End Sub

    Private Sub dgMoid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMoid.CellDoubleClick
        Dim empPhotoUrl As String = String.Empty
        Dim o_strUserID As String = String.Empty
        Try
            If IsNothing(Me.dgMoid.CurrentRow) Then Exit Sub
            o_strUserID = Me.dgMoid.CurrentRow.Cells("colleaderid").Value.ToString
            If String.IsNullOrEmpty(o_strUserID) Then Exit Sub
            Using o_FrmPic As FrmPic = New FrmPic(o_strUserID)
                o_FrmPic.ShowDialog()
            End Using
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan", "dgMoid_CellDoubleClick", "MES")
        End Try
    End Sub

    Private Sub SetVisible(bFlag As Boolean)
        dgMoid.Visible = bFlag
        dgDetail.Visible = bFlag
        lblMoid.Visible = bFlag
        lblChildMoid.Visible = bFlag
    End Sub

End Class