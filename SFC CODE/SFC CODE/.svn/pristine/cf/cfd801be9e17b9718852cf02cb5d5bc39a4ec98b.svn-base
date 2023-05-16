Imports MainFrame.SysCheckData
Imports System.Text.RegularExpressions
Imports System.Text
Imports MainFrame

Public Class FrmMOQtyChangeRequest

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lssql As New StringBuilder
        Try
            If Not BaseDataCheck() Then
                Exit Sub
            End If

            lssql.Append(" Insert into m_MOQtyChangeRequest_t([MOID],[BeforeQty],[AfterQty],[ChangeReason],[UserID],[Intime])")
            lssql.Append(" values('{0}',{1},{2},N'{3}','{4}',GETDATE())")

            Dim o_strSQL As String = String.Format(lssql.ToString, Me.txtMOID.Text, Val(Me.txtBeforeQty.Text.Trim), Val(Me.txtAfterQty.Text), Me.txtReason.Text.Trim.Replace("'", ""), VbCommClass.VbCommClass.UseId)
            o_strSQL = o_strSQL + "  UPDATE m_mainmo_t SET moqty='" & Val(Me.txtAfterQty.Text) & "' where moid ='" & Me.txtMOID.Text.Trim & "' and factory='" & VbCommClass.VbCommClass.Factory & "' and profitcenter ='" & VbCommClass.VbCommClass.profitcenter & "'"

            DbOperateUtils.ExecSQL(o_strSQL)
            MessageUtils.ShowInformation("工单补数操作成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    '基础检查 
    Private Function BaseDataCheck() As Boolean
        If Me.txtReason.Text = "" Then
            MessageUtils.ShowError(" 必须输入工单调整原因！")
            txtReason.Focus()
            Return False
        End If
        If Val(Me.txtAfterQty.Text) <= 0 Then
            'MessageUtils.ShowInformation("必须输入上级工单(包装站工单),如为成品工单则相同...")
            MessageUtils.ShowError(" 调整后的工单数量必须大于0！")
            txtAddQty.Focus()
            Return False
        End If

        Return True
    End Function

    Public Function IsWholeNumber(ByVal strNumber As String) As Boolean
        Dim notWholePattern As Regex = New Regex("^[\-]?[0-9]*$")    '^[\-]?[0-9]*$
        Return notWholePattern.IsMatch(strNumber, 0)
    End Function

    Private Sub txtAddQty_Leave(sender As Object, e As EventArgs) Handles txtAddQty.Leave
        If Not String.IsNullOrEmpty(Me.txtAddQty.Text) Then
            If (Not IsWholeNumber(Me.txtAddQty.Text.Trim())) Then
                '  MessageBox.Show("请输入数字！", "提交提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageUtils.ShowError("请输入数字！")
                Me.txtAddQty.Focus()
                Me.txtAddQty.Select()
                Return
            Else
                Me.txtAfterQty.Text = CStr(Val(Me.txtBeforeQty.Text) + Val(Me.txtAddQty.Text))
            End If
        End If
    End Sub

    Private Sub txtAddQty_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtAddQty.KeyPress
        '    Dim ch As Char = e.KeyChar

        '    If Not Char.IsDigit(ch) Then
        '        MessageUtils.ShowError("请输入数字!")
        '        e.Handled = True
        '    End If
    End Sub

    Private Sub FrmMOQtyChangeRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(Me.txtMOID.Text) Then
            Dim lssql As String = String.Empty
            lssql = " select moqty from m_mainmo_t where moid='" & Me.txtMOID.Text & "'"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtBeforeQty.Text = o_dt.Rows(0).Item(0)
                End If
            End Using
        End If
    End Sub
End Class