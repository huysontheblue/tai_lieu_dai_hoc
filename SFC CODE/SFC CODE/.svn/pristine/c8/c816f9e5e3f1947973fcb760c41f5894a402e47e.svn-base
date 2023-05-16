Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysDataHandle

Public Class FrmSelectRole

    Public UserId As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FrmSelectRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim UserDg As DataTable
        Dim i As Integer
        ListBox1.Items.Clear()
        'UserDg = Sdbc.GetDataTable("Select Role_Id,Role_Name from m_Role_t")
        'Role_Acitve=1时取有效状态的角色 
        UserDg = Sdbc.GetDataTable("Select Role_Id,Role_Name,Role_Desc from m_Role_t where Role_Acitve=1 ")

        For i = 0 To UserDg.Rows.Count - 1
            ListBox1.Items.Add(UserDg.Rows(i)(0).ToString() + "-" + UserDg.Rows(i)(1).ToString() + "(" + UserDg.Rows(i)(2).ToString() + ")")
        Next
        Sdbc.PubConnection.Close()

        LoadUserRole(UserId)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AddRole()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RemoveRole()
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        AddRole()
    End Sub

    'add by song
    '2016-03-11
    '添加角色
    Sub AddRole()
        Try
            If ListBox1.SelectedIndex = -1 Then
                Exit Sub
            End If
            If ListBox2.Items.IndexOf(ListBox1.Items(ListBox1.SelectedIndex).ToString()) > -1 Then
                Exit Sub
            End If
            ListBox2.Items.Add(ListBox1.Items(ListBox1.SelectedIndex).ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '删除角色
    Sub RemoveRole()
        Try
            If ListBox2.SelectedIndex = -1 Then
                Exit Sub
            End If
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '读取用户角色
    Sub LoadUserRole(ByVal UserId)
        Try
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim UserDg As DataTable
            Dim i As Integer
            ListBox2.Items.Clear()
            UserDg = Sdbc.GetDataTable("select u.Role_Id,t.Role_Name,t.Role_Desc from m_RoleUser_t u inner join m_Role_t t on u.Role_Id=t.Role_Id and u.User_Id = '" & UserId & "'")
            For i = 0 To UserDg.Rows.Count - 1
                ListBox2.Items.Add(UserDg.Rows(i)(0).ToString() + "-" + UserDg.Rows(i)(1).ToString() + "(" + UserDg.Rows(i)(2).ToString() + ")")
            Next
            Sdbc.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '存盘角色
    Private Sub SaveUserRole()
        Try
            Dim SqlStr As String
            Dim i As Integer
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass
            If ListBox2.Items.Count = -1 Then
                Exit Sub
            End If
            SqlStr = "delete from m_RoleUser_t where User_Id='" & UserId & "'"
            ExeCute.ExecSql(SqlStr)

            For i = 0 To ListBox2.Items.Count - 1
                SqlStr = "insert into m_RoleUser_t(User_Id,Role_Id,Createuser,Intime) values" & " ('" & UserId & "','" & ListBox2.Items(i).ToString().Substring(0, 4) & "','" & MainFrame.SysCheckData.SysMessageClass.UseId.ToLower & "',getdate())"
                ExeCute.ExecSql(SqlStr)
            Next

            ExeCute = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        RemoveRole()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim SqlStr As String
            Dim ExeCute As New MainFrame.SysDataHandle.SysDataBaseClass
            If (MessageBox.Show("确认后，旧的权限将被删除，只保留现选择角色的权限，您确定要确认？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) Then
                SaveUserRole()

                SqlStr = "delete from m_UserRight_t where UserId='" & UserId & "'"
                ExeCute.ExecSql(SqlStr)

                'SqlStr = "insert m_userright_t values('" & StrUserid & "','" & NodeName & "','" & SysMessageClass.UseId & "',getdate())"
                SqlStr = "insert into m_UserRight_t select distinct u.User_Id,r.TKey,'" & MainFrame.SysCheckData.SysMessageClass.UseId.ToLower & "',getdate() from m_RoleUser_t u,m_RoleRight_t r,m_Role_t t where u.Role_Id = r.Role_Id and r.Role_Id = t.Role_Id and t.Role_Acitve=1 and u.User_Id = '" & UserId & "'"
                ExeCute.ExecSql(SqlStr)

                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class