#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

#End Region

Public Class FrmScanErrPrompt

    Public ExitFlag As Boolean
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmScanError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtUserPass.Focus()
    End Sub

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click
        Me.ExitFlag = False
        Me.Close()
    End Sub

    Private Sub TxtUserPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserPass.KeyPress

        If e.KeyChar = Chr(13) Then
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass

        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtUserPass.Text & "' and b.tkey='m0510b_'")
        If Not CheckRead.Read Then
            MessageBox.Show("密碼不正確或無權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Data.CheckStr = False
            CheckRead.Close()
            Me.TxtUserPass.Focus()
            Me.TxtUserPass.SelectAll()
        Else
            ExitFlag = True
            Me.Close()
        End If

    End Sub

End Class