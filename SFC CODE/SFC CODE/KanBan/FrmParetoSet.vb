Imports MainFrame.SysCheckData
Public Class FrmParetoSet
    Private frm As FrmParetoShow
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try

            If String.IsNullOrEmpty(Me.txtPartID.Text) Then
                MessageUtils.ShowError("请输入料号!")
                Me.txtPartID.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.No
                Exit Sub
            End If

            frm = New FrmParetoShow()
            frm.lblPartID.Text = Me.txtPartID.Text
            frm.lblDate.Text = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")

            frm.ShowDialog()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmParetoSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class