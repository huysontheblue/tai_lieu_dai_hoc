
#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmOptionSet

    Dim lbloption As Label

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Txtoption.Focus()
        End If

    End Sub

    Public Sub New(ByVal mLabel As Label)

        InitializeComponent()
        lbloption = mLabel

    End Sub
    'Private Sub Txtoption_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtoption.KeyPress

    '    If e.KeyChar = Chr(13) Then
    '        ButConfirm.Focus()
    '        ButConfirm_Click(sender, e)
    '    End If

    'End Sub

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
        If Me.Txtoption.Text.Trim = "" Then
            MessageBox.Show("解锁密码不正确...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Data.CheckStr = False
            CartonScanOption.CheckStr = False
            Me.Txtoption.Focus()
            Exit Sub
        End If

        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510a_'")
        If Not CheckRead.Read Then
            MessageBox.Show("你没有设置时间参数的权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Data.CheckStr = False
            CartonScanOption.CheckStr = False
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        Else
            Data.CheckStr = True
            CartonScanOption.CheckStr = True
            lbloption.Text = Me.Txtoption.Text.Trim
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


    Private Sub Txtoption_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtoption.KeyPress

        If e.KeyChar = Chr(13) Then
            ButConfirm.Focus()
            ButConfirm_Click(sender, e)
        End If
        If Me.Txtoption.Text = "" And e.KeyChar = "0" Then
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