Public Class FrmInfShow
    Dim Iclass As New InfClass
    Private Sub BtSure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSure.Click
        Iclass.ChoseY = True
        Me.Close()
    End Sub

    Private Sub BtDorp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDorp.Click
        Iclass.ChoseY = False
        Me.Close()
    End Sub

    Private Sub FrmInfShow_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Iclass.StrInf = Nothing
        Iclass.StrColor = Nothing
        Iclass.StrSize = Nothing
        Iclass.StrQInf = Nothing
        Iclass.StrQColor = Nothing
        Iclass.StrQSize = Nothing

    End Sub

    Private Sub FrmInfShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LabInf.Text = Iclass.StrInf
        Me.LabInf.ForeColor = Iclass.StrColor
        Me.LabQust.Text = Iclass.StrQInf
        Me.LabQust.ForeColor = Iclass.StrQColor

    End Sub
End Class