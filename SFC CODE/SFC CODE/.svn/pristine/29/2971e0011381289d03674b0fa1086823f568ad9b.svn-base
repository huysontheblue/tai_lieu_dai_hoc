
#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmSetLock

#Region "怠砰秙ㄆン"

    'Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

    '    Data.CheckStr = False
    '    CartonScanOption.CheckStr = False
    '    Me.Close()

    'End Sub

#End Region


    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            ButConfirm.Focus()
            ButConfirm_Click(sender, e)
        End If

    End Sub

    ''Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

    ''    Dim LoginClass As New TextHandle
    ''    Dim CheckRead As SqlClient.SqlDataReader
    ''    Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass

    ''    CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510a_'")
    ''    If Not CheckRead.Read Then
    ''        MessageBox.Show("盞絏ぃタ絋┪礚舦", "岿粇獺", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''        Data.CheckStr = False
    ''        CartonScanOption.CheckStr = False
    ''        Me.TxtPassWord.Focus()
    ''        Me.TxtPassWord.SelectAll()
    ''    Else
    ''        Data.CheckStr = True
    ''        CartonScanOption.CheckStr = True
    ''        Me.Close()
    ''    End If

    ''    CheckRead.Close()

    ''End Sub

    Private Sub FrmOpenLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "ButConfirm" Then CartonScanOption.CheckStr = False
        If Me.ActiveControl Is Nothing Then
            Data.CheckStr = False
            CartonScanOption.CheckStr = False
        End If

    End Sub

    Private Sub ButConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConfirm.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass

        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserId='" & SysMessageClass.UseId & "' and a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510a_'")
        If Not CheckRead.Read Then
            MessageBox.Show("你没有扫描设置的权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Data.CheckStr = False
            CartonScanOption.CheckStr = False
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
        Else
            Data.CheckStr = True
            CartonScanOption.CheckStr = True
            Me.Close()
        End If

        CheckRead.Close()

    End Sub

    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCancel.Click

        Data.CheckStr = False
        CartonScanOption.CheckStr = False
        Me.Close()

    End Sub

    ''Private Sub FrmSetLock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    ''    If e.KeyCode = Keys.F4 And e.Modifiers = Keys.Alt Then e.Handled = True
    ''End Sub

  
End Class