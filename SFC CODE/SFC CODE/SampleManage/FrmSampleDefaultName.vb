Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmSampleDefaultName
    Public m_strRDUserID As String = String.Empty
    Public m_strYWDutyName As String = String.Empty, m_strInitYWDutyName As String = ""
    Public m_strPIEDutyName As String = String.Empty, m_strIniPIEDutyName As String = ""
    Public m_strSGDutyName As String = String.Empty, m_strIniSGDutyName As String = ""
    Public m_strPZDutyName As String = String.Empty, m_strIniPZDutyName As String = ""
    Public m_strYPSDutyName As String = String.Empty, m_strIniYPSDutyName As String = ""
    Public m_strEquDutyName As String = String.Empty, m_strIniEquDutyName As String = ""
    Public m_strZEquDutyName As String = String.Empty, m_strIniZEquDutyName As String = ""
    ' Public m_strCCDutyName As String = String.Empty, m_strIniCCDutyName As String = ""
    Public m_strRDDutyName As String = String.Empty, m_strIniRDDutyName As String = ""
    Public m_strUserDept As String = String.Empty

    Private Sub FrmSampleDutyName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()

        '[RDUserName],[YWUserName],[PZUserName] ,[YPSUserName],[EquUserName],[SGUserName],PIEUserName,ZJUserName
        SampleCom.BindComboxPZ(cobPZDutyName)
        If Not String.IsNullOrEmpty(m_strPZDutyName) Then
            Me.cobPZDutyName.Text = m_strPZDutyName
        Else
            Me.cobPZDutyName.Text = ""
        End If
        m_strIniPZDutyName = Me.cobPZDutyName.Text

        SampleCom.BindComboxYPS(cobYPSDutyName)
        If Not String.IsNullOrEmpty(m_strYPSDutyName) Then
            Me.cobYPSDutyName.Text = m_strYPSDutyName
        Else
            Me.cobYPSDutyName.Text = ""
        End If
        m_strIniYPSDutyName = Me.cobYPSDutyName.Text

        SampleCom.BindComboxEqu(cobEquDutyName)
        If Not String.IsNullOrEmpty(m_strEquDutyName) Then
            Me.cobEquDutyName.Text = m_strEquDutyName
        Else
            Me.cobEquDutyName.Text = ""
        End If

        SampleCom.BindComboxSG(cobSGDutyName)
        If Not String.IsNullOrEmpty(m_strSGDutyName) Then
            Me.cobSGDutyName.Text = m_strSGDutyName
        Else
            Me.cobSGDutyName.Text = ""
        End If

        SampleCom.BindComboxPIE(cobPIEDutyName)
        If Not String.IsNullOrEmpty(m_strPIEDutyName) Then
            Me.cobPIEDutyName.Text = m_strPIEDutyName
        Else
            Me.cobPIEDutyName.Text = ""
        End If

        SampleCom.BindComboxZEqu(cobZEquDutyName)
        If Not String.IsNullOrEmpty(m_strZEquDutyName) Then
            Me.cobZEquDutyName.Text = m_strZEquDutyName
        Else
            Me.cobZEquDutyName.Text = ""
        End If

        m_strUserDept = SampleCom.GetUserDept(VbCommClass.VbCommClass.UseId)
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'Check whether all select  , '[RDUserName],[YWUserName],[PZUserName] ,[YPSUserName],[EquUserName],[SGUserName],PIEUserName,ZJUserName

        If String.IsNullOrEmpty(Me.cobPZDutyName.Text) Then
            MessageUtils.ShowError("品质不能为空！")
            Exit Sub
        Else
            If m_strIniPZDutyName <> "" AndAlso m_strIniPZDutyName <> Me.cobPZDutyName.Text Then
                'only allow  Own dept modify
                If m_strUserDept <> SampleCom.EnumSampleDept.品质.ToString Then
                    MessageUtils.ShowError("不允许修改其他部门的责任人！")
                    Exit Sub
                End If
            End If
        End If

        If String.IsNullOrEmpty(Me.cobYPSDutyName.Text) Then
            MessageUtils.ShowError("样品室不能为空！")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.cobEquDutyName.Text) Then
            MessageUtils.ShowError("设备责任人不能为空！")
            Exit Sub
        Else
            If m_strIniEquDutyName <> "" AndAlso m_strIniEquDutyName <> Me.cobEquDutyName.Text Then
                'only allow  Own dept modify
                If m_strUserDept <> SampleCom.EnumSampleDept.设备.ToString AndAlso m_strUserDept <> SampleCom.EnumSampleDept.研发.ToString Then
                    MessageUtils.ShowError("不允许修改其他部门的责任人！")
                    Exit Sub
                End If
            End If
        End If

        If String.IsNullOrEmpty(Me.cobSGDutyName.Text) Then
            MessageUtils.ShowError("生管不能为空！")
            Exit Sub
        Else
            'If m_strIniSGDutyName <> "" AndAlso m_strIniSGDutyName <> Me.cobSGDutyName.Text Then
            '    'only allow  Own dept modify
            '    If m_strUserDept <> SampleCom.EnumSampleDept.研发.ToString Then
            '        MessageUtils.ShowError("不允许修改其他部门的责任人！")
            '        Exit Sub
            '    End If
            'End If
        End If

        If String.IsNullOrEmpty(Me.cobPIEDutyName.Text) Then
            MessageUtils.ShowError("PIE不能为空！")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.cobZEquDutyName.Text) Then
            MessageUtils.ShowError("治具不能为空！")
            Exit Sub
        Else
            If m_strIniZEquDutyName <> "" AndAlso m_strIniZEquDutyName <> Me.cobZEquDutyName.Text Then
                'only allow  Own dept modify
                If m_strUserDept <> SampleCom.EnumSampleDept.治具.ToString AndAlso m_strUserDept <> SampleCom.EnumSampleDept.研发.ToString Then
                    MessageUtils.ShowError("不允许修改其他部门的责任人！")
                    Exit Sub
                End If
            End If
        End If

        Call UpdateDutyUserName()
        MessageUtils.ShowInformation("保存成功!")
        Me.Close()
    End Sub

    Private Sub UpdateDutyUserName()
        Try
            Dim lsSQL As New StringBuilder

            lsSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 from m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' and DeptName = N'" & SampleCom.EnumSampleDept.品质.ToString & "') ")
            lsSQL.Append("  Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.品质.ToString & "',N'" & Me.cobPZDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobPZDutyName.Text.Trim & "',intime = getdate(), userid ='" & VbCommClass.VbCommClass.UseId & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.品质.ToString & "'")

            lsSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName = N'" & SampleCom.EnumSampleDept.样品室.ToString & "') ")
            lsSQL.Append(" Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.样品室.ToString & "',N'" & Me.cobYPSDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobYPSDutyName.Text.Trim & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.样品室.ToString & "'")

            lsSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName = N'" & SampleCom.EnumSampleDept.设备.ToString & "') ")
            lsSQL.Append("  Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.设备.ToString & "',N'" & Me.cobEquDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobEquDutyName.Text.Trim & "',intime = getdate(), userid ='" & VbCommClass.VbCommClass.UseId & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.设备.ToString & "'")

            lsSQL.Append(" If NOT EXISTS(SELECT TOP 1 1 FROM m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName = N'" & SampleCom.EnumSampleDept.生管.ToString & "') ")
            lsSQL.Append("  Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.生管.ToString & "',N'" & Me.cobSGDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobSGDutyName.Text.Trim & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.生管.ToString & "'")

            lsSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName = N'" & SampleCom.EnumSampleDept.PIE.ToString & "') ")
            lsSQL.Append("  Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.PIE.ToString & "',N'" & Me.cobPIEDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobPIEDutyName.Text.Trim & "',intime = getdate(), userid ='" & VbCommClass.VbCommClass.UseId & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.PIE.ToString & "'")

            lsSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_SampleDefaultPIC_t WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName = N'" & SampleCom.EnumSampleDept.治具.ToString & "') ")
            lsSQL.Append("  Insert into m_SampleDefaultPIC_t(RDUserID,DeptName,DutyUserName,UserID,intime) VALUES( '" & m_strRDUserID & "',N'" & SampleCom.EnumSampleDept.治具.ToString & "',N'" & Me.cobZEquDutyName.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',getdate()) ")
            lsSQL.Append(" ELSE ")
            lsSQL.Append(" Update m_SampleDefaultPIC_t SET DutyUserName = N'" & Me.cobZEquDutyName.Text.Trim & "',intime = getdate(), userid ='" & VbCommClass.VbCommClass.UseId & "' WHERE RDUserID ='" & m_strRDUserID & "' AND DeptName =N'" & SampleCom.EnumSampleDept.治具.ToString & "'")

            DbOperateUtils.ExecSQL(lsSQL.ToString())
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleDefaultName", "UpdateDutyUserName", "Sample")
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class