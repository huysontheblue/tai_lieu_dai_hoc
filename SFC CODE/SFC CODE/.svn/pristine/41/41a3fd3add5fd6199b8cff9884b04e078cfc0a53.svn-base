#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmCartonPrompt

    Dim ExitFlag As Boolean

    Private Sub FrmScanError_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ExitFlag = True Then
            Exit Sub
        Else
            e.Cancel = True
        End If

    End Sub


    Private Sub FrmScanError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LabSn.Text = "條碼序號:" & CartonScanOption.BarCodeStr
        Me.LabError.Text = CartonScanOption.ErrorStr
        Me.CobError.SelectedIndex = 0
        Me.TxtUserPass.Focus()

    End Sub

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.TxtUserPass.Text = ""

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
        If CobError.Text = "" Then
            MessageBox.Show("錯誤備注不能為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtUserPass.Text & "' and b.tkey='m0510b_'")
        If Not CheckRead.Read Then
            MessageBox.Show("密碼不正確或無權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Data.CheckStr = False'
            CheckRead.Close()
            Me.TxtUserPass.Focus()
            Me.TxtUserPass.SelectAll()
        Else
            'Data.CheckStr = True
            CheckRead.Close()
            PubClass.ExecSql("update m_AssysnE_t with(ROWLOCK) set Errormark='" & CobError.Text & "',Solvetime=getdate() where ppid='" & Data.BarCodeStr & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')=''")
            ' PubClass.ExecSql("update m_AssysnE_t set Errormark='" & CobError.Text & "', Solveuser=(select userid from m_Users_t where autoid= '" & Me.TxtUserPass.Text & "' ),Solvetime=getdate() where Spoint='" & My.Computer.Name & "' and intime=(select max(intime) from m_AssysnE_t where Spoint='" & My.Computer.Name & "')")
            ExitFlag = True
            Me.Close()
        End If

    End Sub


End Class