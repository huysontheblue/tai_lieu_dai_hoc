
#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmLock

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubUseClass As New MainFrame.SysDataHandle.SysDataBaseClass

        CheckRead = PubUseClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0820a_'")
        If Not CheckRead.Read Then
            MessageBox.Show("密碼不正確或無權限！", "錯誤信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ReuseClass.ReUseLock = False
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
        Else
            ReuseClass.ReUseLock = True
            Me.Close()
        End If

        CheckRead.Close()

    End Sub

    Private Sub FrmOpenLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl Is Nothing Then
            ReuseClass.ReUseLock = False
        End If

    End Sub

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click
        ReuseClass.ReUseLock = False
        Me.Close()
    End Sub
End Class