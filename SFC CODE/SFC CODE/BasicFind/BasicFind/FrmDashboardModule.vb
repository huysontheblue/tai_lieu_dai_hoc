Public Class FrmDashboardModule

    Private Sub FrmDashboardModule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            Me.WindowState = FormWindowState.Normal
        Else
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Maximized
            End If
        End If

    End Sub

   

    Private Sub FrmDashboardModule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

    End Sub
End Class