Imports System.Windows.Forms

Public Class MessageUtils

    Public Shared Sub ShowError(message As String)
        MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    End Sub

    Public Shared Sub ShowInformation(message As String)
        MessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Public Shared Sub ShowWarning(message As String)
        MessageBox.Show(message, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Function ShowConfirm(message As String, btn As MessageBoxButtons) As MessageBoxButtons
        Return Show(message, btn, MessageBoxIcon.Question)
    End Function

     Private Shared Function Show(message As String, btn As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        If btn = MessageBoxButtons.OKCancel Or
             btn = MessageBoxButtons.YesNo Or
             btn = MessageBoxButtons.RetryCancel Then
            Return MessageBox.Show(message, "确认信息", btn, icon, MessageBoxDefaultButton.Button2)

        ElseIf btn = MessageBoxButtons.YesNoCancel Or
            btn = MessageBoxButtons.AbortRetryIgnore Then
            Return MessageBox.Show(message, "确认信息", btn, icon, MessageBoxDefaultButton.Button3)
        Else
            Return MessageBox.Show(message, "确认信息", btn, icon, MessageBoxDefaultButton.Button1)
        End If
    End Function

End Class
