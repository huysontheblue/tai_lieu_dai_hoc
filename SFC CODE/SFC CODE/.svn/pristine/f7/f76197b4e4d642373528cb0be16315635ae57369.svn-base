Imports System.Text
Imports System.Data.SqlClient
Public Class SampleBusiness

    Private Shared factoryID As String = VbCommClass.VbCommClass.Factory
    Private Shared profitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId

    Public Enum HeaderGrid
        CheckBox = 0
        ClickTime
        SampleNo
        CustID
        DeliveryDate
        PartId
        Qty
        Status
        '选择 /样品单号/客户号/版本/形态/图纸文件/制作状态/创建人
    End Enum

    Public Enum BodyGrid
        PartId = 0
        StationID
        StationSQ
        StationName
        SectionID
        WorkingHours
        Equipment
        ProcessStandard
        NewProcessStandard
        Remark
        SOP
        Status
        UserId
        InTime
        Shape
    End Enum

    Public Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        ParentFormat
        ChildFormat
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        ExtensibleF
        Qty
        CustID
        SeriesID
    End Enum
    '制样问题分析
    Public Enum SampleProblemGrid
        ProblemName
        RDEngineer
        SampleTime
        SampleQty
        NGQty
        NGRate
        StatusName
        ProblemDesc
        IsDrawingNG
        IsMaterialNG
        IsCraftNG
        IsMouldNG
        IsOtherNG
        PersonLiable
        TempCountermeasure
        LongCountermeasure
        TrackingSummary
        StartTime
        ExpFinishTime
        ActFinishTime
        FilePath
        UserName
        CreateTime
        ProblemNo
        Status
    End Enum
    Public Shared Function GetUserID(ByVal userName As String) As String
        Dim strSQL As String = String.Empty, UserID = ""
        strSQL = " SELECT TOP 1 USERID FROM m_Users_t  WHERE username=N'" & userName & "'"
        Using o_dt As DataTable = SampleComDB.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                UserID = o_dt.Rows(0).Item(0)
            End If
        End Using
        GetUserID = UserID
        Return GetUserID
    End Function

    Public Shared Function GetUserMail(ByVal userID As String) As String
        Dim strSQL As String = String.Empty, UserMailPrefix = ""
        GetUserMail = ""
        strSQL = " SELECT TOP 1 LEFT(DutyEmail,CHARINDEX('@',DutyEmail)-1) MailPrefix  from m_SamplePic_t WHERE dutyUserID=N'" & userID & "'"
        Using o_dt As DataTable = SampleComDB.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                UserMailPrefix = o_dt.Rows(0).Item(0)
            End If
        End Using
        GetUserMail = UserMailPrefix
        Return GetUserMail
    End Function

    Public Shared Function GetStdTime(ByVal strPartNo As String) As String
        Dim strSQL As String = String.Empty
        GetStdTime = ""
        strSQL = " SELECT TOP 1 StdTime FROM m_SamplePartIDStdTime  WHERE PartNo='" & strPartNo & "'"
        Using o_dt As DataTable = SampleComDB.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetStdTime = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetStdTime
    End Function
    ''' <summary>
    ''' 追踪状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select value,text from m_BaseData_t where itemkey = 'SampleProblemStatus' and status = 1 AND VALUE<>'D' order by SORT "
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dt As DataTable = sConn.GetDataTable(strSQL)
        Dim dr As DataRow = dt.NewRow

        dr("text") = ""
        dr("value") = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = "text"
        ColComboBox.ValueMember = "value"
    End Sub
    Shared Sub BindComboxStage(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select value,text from m_BaseData_t where itemkey = 'SampleProblemState' and status = 1 order by SORT "
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dt As DataTable = sConn.GetDataTable(strSQL)
        Dim dr As DataRow = dt.NewRow

        dr("text") = ""
        dr("value") = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = "text"
        ColComboBox.ValueMember = "value"
    End Sub
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
            Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
            o_Subject.Append("MES待办消息:" & EmailTitle & "")
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
            sConn.ExecuteNonQureyByProc("m_MailSend_p", parameters)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
