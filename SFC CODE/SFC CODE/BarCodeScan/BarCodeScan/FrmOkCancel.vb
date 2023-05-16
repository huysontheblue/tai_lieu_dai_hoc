Public Class FrmOkCancel


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text.ToUpper = "NEWBOX" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Label2.Text = "换箱指令错误，请从新刷入"
                TextBox1.Clear()
            End If
        End If
    End Sub
End Class