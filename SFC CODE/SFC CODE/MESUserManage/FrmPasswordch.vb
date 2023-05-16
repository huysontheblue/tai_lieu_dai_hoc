
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.Text

Public Class FrmPasswordch

    Dim PassWordTest As New TextHandle

    Private Sub SaveRecord()

        Dim Sqlstr As String = ""
        Dim SaveEms As New SysDataBaseClass
        Dim SmUser As New SysMessageClass

        Try

            'Add by cq, 2016/01/13
            If Me.CbCheckin.Checked = True Then  'cq, 20160113, Modify login password
                If VbCommClass.VbCommClass.IsAdLink = "Y" Then
                    MessageUtils.ShowError("LDAP账号密码不能在此处修改！如需修改请联系系统课杨焱武,分机:86276")
                    Exit Sub
                End If
            End If

            CheckRecord()

            If CbCheckin.Checked = True Then
                Sqlstr = "update M_Users_t set password='" & PassWordTest.EnCryptPassword(Trim(TxtNewPwd.Text)) & "'" & " where userid='" & SysMessageClass.UseId & "'" & vbNewLine
            End If
            If CbCheckout.Checked = True Then
                Sqlstr = Sqlstr & "update M_Users_t set AutoID='" & Trim(TxtCheckOutOne.Text) & "'" & " where userid='" & SysMessageClass.UseId & "'"

            End If
            If CbCheckoutReprint.Checked = True Then
                Sqlstr = Sqlstr & "update M_Users_t set PWDOfRePrint='" & Trim(TxtCheckOutPwdOfRePrint1.Text) & "'" & "where userid='" & SysMessageClass.UseId & "'"
            End If
            '' Sqlstr = Sqlstr & " where userid='" & SysMessageClass.UseId & "'"
            If CheckBox1.Checked = True Then
                Sqlstr = Sqlstr & "update m_users_t set password='" & MD5Encrypt(Me.TextBox2.Text.Trim()) & "' where userid='" & SysMessageClass.UseId & "'"
            End If

            SaveEms.ExecSql(Sqlstr)
            MessageBox.Show("修改成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "系统出现错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Finally
            SaveEms = Nothing
        End Try

    End Sub

    Private Sub CheckRecord()

        Dim Ser As New SysDataBaseClass
        Dim SmUser As New SysMessageClass

        Dim SysRead As SqlClient.SqlDataReader

        Dim OldNoErr As New Exception("信息提示!")
        OldNoErr.Source = "CheckRecord"

        SysRead = Ser.GetDataReader("select userid from m_users_t where userid='" & Trim(SysMessageClass.UseId) & "'")

        'Cmd.CommandText = "select * from m_users_t where userid='sz19096' and password='" & PassWordTest.EnCryptPassword(TxtOldPwd.Text) & "'"

        If Not SysRead.Read Then
            SysRead.Close()
            Throw OldNoErr
            Exit Sub
        End If
        SysRead.Close()

        If CbCheckin.Checked = True Then
            Dim TypeNoErr As New Exception("新密码不能为空!")
            TypeNoErr.Source = "CheckRecord"
            If TxtNewPwd.Text = "" Then
                Throw TypeNoErr
                TxtNewPwd.SelectAll()
                Exit Sub
            End If

            Dim TypeNameErr As New Exception("输入的两次新密码不相同!")
            TypeNameErr.Source = "CheckRecord"
            If Trim(TxtNewPwd.Text) <> Trim(TxtagainPwd.Text) Then
                Throw TypeNameErr
                TxtagainPwd.SelectAll()
                Exit Sub
            End If


        End If

        If CbCheckout.Checked = True Then
            Dim TypeNoErr As New Exception("解锁密码不能为空!")
            TypeNoErr.Source = "CheckRecord"
            If TxtCheckOutOne.Text = "" Then
                Throw TypeNoErr
                TxtCheckOutOne.SelectAll()
                Exit Sub
            End If

            Dim TypeNameErr As New Exception("输入的两次新解锁密码不相同!")
            TypeNameErr.Source = "CheckRecord"
            If Trim(TxtCheckOutOne.Text) <> Trim(TxtCheckOutTwo.Text) Then
                Throw TypeNameErr
                TxtCheckOutTwo.SelectAll()
                Exit Sub
            End If
        End If


        If CbCheckoutReprint.Checked = True Then
            Dim TypeNoErr As New Exception("外箱重新打印密码不能为空!")
            TypeNoErr.Source = "CheckRecord"
            If TxtCheckOutPwdOfRePrint1.Text = "" Then
                Throw TypeNoErr
                TxtCheckOutPwdOfRePrint1.SelectAll()
                Exit Sub
            End If

            Dim TypeNameErr As New Exception("输入的两次新密码不相同!")
            TypeNameErr.Source = "CheckRecord"
            If Trim(TxtCheckOutPwdOfRePrint1.Text) <> Trim(TxtCheckOutPwdOfRePrint2.Text) Then
                Throw TypeNameErr
                TxtCheckOutPwdOfRePrint2.SelectAll()
                Exit Sub
            End If
        End If

        If CheckBox1.Checked = True Then
            Dim TypeNoErr As New Exception("密码不能为空!")
            TypeNoErr.Source = "CheckRecord"
            If TextBox2.Text = "" Then
                Throw TypeNoErr
                TextBox2.SelectAll()
                Exit Sub
            End If

            Dim TypeNameErr As New Exception("输入的两次新解锁密码不相同!")
            TypeNameErr.Source = "CheckRecord"
            If Trim(TextBox2.Text) <> Trim(TextBox1.Text) Then
                Throw TypeNameErr
                TextBox1.SelectAll()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcheckout2.Click

        Me.Close()

    End Sub

    Private Sub FrmPasswordch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Dim ff As New TextHandle
        ff.TabTransEnter(sender, e)
        ff = Nothing

    End Sub

    Private Sub FrmPasswordch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim EngSetClass As New SysDataBaseClass
        If LCase(SysMessageClass.Language) = "english" Then
            EngSetClass.GetControlEnglishText(Me)
        End If

        '关晓艳 不设置登录密码修改 2018-4-24
        CbCheckout.Checked = True
        TxtNewPwd.Enabled = False
        TxtagainPwd.Enabled = False
        'CbCheckin.Checked = True
        'Me.TxtCheckOutOne.Enabled = False
        'Me.TxtCheckOutTwo.Enabled = False

        Me.CbCheckoutReprint.Checked = False


    End Sub
    '<summary>
    ' </summary>
    ' <param name="strSource">待加密字串</param>
    ' <returns>加密后的字串</returns>
    Public Shared Function MD5Encrypt(ByVal strSource As String) As String
        Return MD5Encrypt(strSource, 16)
    End Function
    Public Shared Function MD5Encrypt(ByVal strSource As String, ByVal length As Integer) As String
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(strSource)
        Dim hashValue As Byte() = (CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm)).ComputeHash(bytes)
        Dim sb As StringBuilder = New StringBuilder()
        Select Case length
            Case 16

                For i As Integer = 4 To 12 - 1
                    sb.Append(hashValue(i).ToString("x2"))
                Next

            Case 32

                For i As Integer = 0 To 16 - 1
                    sb.Append(hashValue(i).ToString("x2"))
                Next

            Case Else

                For i As Integer = 0 To hashValue.Length - 1
                    sb.Append(hashValue(i).ToString("x2"))
                Next
        End Select

        Return sb.ToString()
    End Function

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click

        SaveRecord()

    End Sub

    Private Sub CbCheckin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCheckin.CheckedChanged

        TxtNewPwd.Enabled = CbCheckin.Checked
        TxtagainPwd.Enabled = CbCheckin.Checked

    End Sub

    Private Sub CbCheckout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCheckout.CheckedChanged

        Me.TxtCheckOutOne.Enabled = CbCheckout.Checked
        Me.TxtCheckOutTwo.Enabled = CbCheckout.Checked

    End Sub

    Private Sub CbCheckoutReprint_CheckedChanged(sender As Object, e As EventArgs) Handles CbCheckoutReprint.CheckedChanged
        Me.TxtCheckOutPwdOfRePrint1.Enabled = CbCheckoutReprint.Checked
        Me.TxtCheckOutPwdOfRePrint2.Enabled = CbCheckoutReprint.Checked
    End Sub


    'Private Sub TxtOldPwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOldPwd.KeyPress

    '    If Asc(e.KeyChar.ToString) = "13" Then
    '        If Me.CbCheckin.CheckAlign = True Then  'cq, 20160113, Modify login password
    '            If VbCommClass.VbCommClass.IsAdLink = "Y" Then
    '                MessageUtils.ShowError("LDAP账号密码不能在此处修改！如需修改请联系系统课杨焱武,分机:86276")
    '                Exit Sub
    '            End If
    '        End If
    '    End If

    'End Sub

    'Private Sub TxtOldPwd_Leave(sender As Object, e As EventArgs) Handles TxtOldPwd.Leave
    '    If Not String.IsNullOrEmpty(TxtOldPwd.Text) Then
    '        If Me.CbCheckin.Checked = True Then  'cq, 20160113, Modify login password
    '            If VbCommClass.VbCommClass.IsAdLink = "Y" Then
    '                MessageUtils.ShowError("LDAP账号密码不能在此处修改！如需修改请联系系统课杨焱武,分机:86276")
    '                Exit Sub
    '            End If
    '        End If
    '    End If
    'End Sub




End Class