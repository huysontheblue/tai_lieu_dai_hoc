Imports System.Data.SqlClient
Imports System.Text

Public Class MailUtils


    ''' <summary>
    ''' 发送邮件通知给相关人员
    ''' </summary>
    ''' <param name="MailTo">邮件人</param>
    ''' <param name="EmailTitle">邮件标题</param>
    ''' <param name="EmailBody">邮件内容</param>
    ''' <remarks></remarks>
    Public Shared Sub SeedMail(ByVal MailTo As String, ByVal EmailTitle As String, ByVal EmailBody As String)
        Try
            Dim o_StrBody As New StringBuilder
            Dim o_Subject As New StringBuilder
            'Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
            o_Subject.Append("" & EmailTitle & "")
            o_StrBody.Append("<p>尊敬的MES用户:<p>")
            o_StrBody.Append("<p>" & EmailBody & "</p>")
            Dim para(3) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@SUBJECT", SqlDbType.NVarChar, 200),
                New SqlParameter("@Body", SqlDbType.NVarChar, 4000),
                New SqlParameter("@R_EMAIL", SqlDbType.NVarChar, 1000)
            }
            parameters(0).Value = o_Subject.ToString
            parameters(1).Value = o_StrBody.ToString
            parameters(2).Value = MailTo
            DbOperateUtils.ExecuteNonQureyByProc("m_MailSend_p", parameters)
        Catch ex As Exception
        End Try
    End Sub

End Class
