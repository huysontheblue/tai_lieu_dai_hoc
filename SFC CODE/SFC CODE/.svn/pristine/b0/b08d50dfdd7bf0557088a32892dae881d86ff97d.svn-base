Imports MainFrame

''' <summary>
''' 提醒
''' </summary>
''' <remarks></remarks>
Public Class FrmSelEcnChangeRemind

    Public partId As String
    Dim Factory As String = VbCommClass.VbCommClass.Factory
    Dim profitcenter As String = VbCommClass.VbCommClass.profitcenter
    Dim UseId As String = VbCommClass.VbCommClass.UseId

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSelEcnChangeRemind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkBox2.Checked = True
    End Sub

    ''' <summary>
    ''' 确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            If chkBox1.Checked = True Then
                Dim strSQL As String = " update m_PartContrastExtend_t set ecnstate = 'N' ,UserId = '{2}', intime = getdate() " &
                                " WHERE tavcpart = pavcpart AND  pavcpart= '{0}' AND factory = '{1}'"
                strSQL = String.Format(strSQL, partId, Factory, UseId)

                DbOperateUtils.ExecSQL(strSQL)
            End If
            '关闭窗口
            Me.Dispose()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmSelEcnChangeRemind", "btnConfirm_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub chkBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkBox1.CheckedChanged
        If chkBox1.Checked = True Then
            chkBox2.Checked = False
        End If
    End Sub

    Private Sub chkBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chkBox2.CheckedChanged
        If chkBox2.Checked = True Then
            chkBox1.Checked = False
        End If
    End Sub
End Class