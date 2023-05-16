#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmCartonLastQtySet

#Region "取消"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnOpenlock
            BnOpenlock_Click(sender, e)
        End If
    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click
        If ScanCommon.GetOpenLock(Me.TxtPassWord.Text.Trim) = False Then
            MessageUtils.ShowError("没有解锁权限!")
            WorkStantOption.LastPrintCheck = False
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If

        WorkStantOption.LastPrintQty = CInt(TxtLastQty.Text.Trim)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub TxtLastQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLastQty.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.TxtPassWord.Focus()
        End If
        If Me.TxtLastQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

End Class