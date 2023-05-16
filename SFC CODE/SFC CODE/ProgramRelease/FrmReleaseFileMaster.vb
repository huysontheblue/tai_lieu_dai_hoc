
'--程序发布维护
'--Create by :　马锋
'--Create date :　2015/11/10
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls

#End Region

Public Class FrmReleaseFileMaster

#Region "变量声明"

    Dim strFileSize As String
    Dim _strFileno As String

    Public Property strFileno() As String
        Get
            Return _strFileno
        End Get

        Set(value As String)
            _strFileno = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _Fileno As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strFileno = _Fileno
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmReleaseFileMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Not (CheckSave()) Then
                Exit Sub
            End If

            Dim fsStream As FileStream
            Dim parmter As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}
            Dim strSQL As New StringBuilder
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

            Try
                If (String.IsNullOrEmpty(strFileno)) Then
                    fsStream = New FileStream(Me.mtxtFilePath.Text.Trim, FileMode.Open, FileAccess.Read)
                    Dim bFile(fsStream.Length) As Byte

                    fsStream.Read(bFile, 0, Int(fsStream.Length))
                    parmter(0) = New SqlClient.SqlParameter("@BFILESTREAM", bFile)

                    strSQL.AppendLine(" DECLARE @FILENO VARCHAR(32) ")
                    strSQL.AppendLine(" SELECT @FILENO = case when max(fileno) is null then'1001' else max(fileno)+1 end FROM M_SystemFile_t ")
                    strSQL.AppendLine(" UPDATE M_SystemFile_t SET usey='N' WHERE filename='" & Me.txtFileName.Text.Trim & "' AND usey='Y' AND ReleasedVersionId=N'" & Me.cboReleasedVersion.SelectedValue.ToString.Trim & "' ")
                    strSQL.AppendLine(" INSERT INTO M_Systemfile_t(Fileno, Factory_Id, ProfitCenter_Id, ReleasedVersionId, ReleasedVersionName, Filename, Fileclass, Filecontent, Fileversion, ProgramVersion, ")
                    strSQL.AppendLine(" Filetime, Usey, SystemUpdateStatus, MinimumVersion, UpdateType, Remark, Userid, Intime, Size) VALUES( ")
                    strSQL.AppendLine(" @FILENO, N'" & Me.cboFactory.SelectedValue.Trim & "', N'" & Me.cboProfitCenter.SelectedValue & "', '" & Me.cboReleasedVersion.SelectedValue.ToString.Trim & "', N'" & Me.cboReleasedVersion.Text.Trim & "', N'" & Me.txtFileName.Text.Trim & "','" & Me.cboFileClass.SelectedValue.Trim & "', @BFILESTREAM, '" & Me.txtFileVersion.Text.Trim & "', '" & Me.txtProgramVersion.Text.Trim & "', ")
                    strSQL.AppendLine(" '" & Me.txtFileModifyDate.Text.Trim & "', 'Y', '" & Me.cboSystemUpdateStatus.SelectedValue & "', '" & Me.txtMinimumVersion.Text.Trim & "', '" & Me.cboUpdateType.SelectedValue & "', N'" & Me.txtRemark.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '" & strFileSize & "' )")
                Else
                    strSQL.AppendLine(" UPDATE M_SystemFile_t SET ReleasedVersionId = N'" & Me.cboReleasedVersion.SelectedValue.ToString.Trim & "', ReleasedVersionName=N'" & Me.cboReleasedVersion.Text.Trim & "', FactoryId='" & Me.cboFactory.SelectedValue.Trim & "', ProfitCenterId='" & Me.cboProfitCenter.SelectedValue.Trim & "', Fileclass='" & Me.cboFileClass.SelectedValue.Trim & "', SystemUpdateStatus='" & Me.cboSystemUpdateStatus.SelectedValue.Trim & "', MinimumVersion='" & Me.txtMinimumVersion.Text.Trim & "', UpdateType='" & Me.cboUpdateType.SelectedValue.ToString.Trim & "', ")
                    strSQL.AppendLine(" Remark=N'" & Me.txtRemark.Text.Trim & "', Updateuser='" & VbCommClass.VbCommClass.UseId & "', Updatetime=GETDATE() ")
                    strSQL.AppendLine(" WHERE Fileno = '" & strFileno & "'")
                End If

                If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                    If (String.IsNullOrEmpty(strFileno)) Then
                        Conn.ExecSqlAddParameter(strSQL.ToString(), parmter)
                    Else
                        Conn.ExecSql(strSQL.ToString)
                    End If
                End If

                Conn.PubConnection.Close()
                Me.Close()
            Catch ex As Exception
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
                GetMesData.SetMessage(Me.lblMessage, "保存异常!", False)
            End Try
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常!", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFactory.SelectedIndexChanged
        If (String.IsNullOrEmpty(Me.cboFactory.SelectedValue.ToString.Trim)) Then
            Exit Sub
        End If

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSQL As String
        Try
            Me.cboProfitCenter.DataSource = Nothing
            Me.cboProfitCenter.Items.Clear()
            strSQL = "SELECT PROFITCENTER_CODE, PROFITCENTER_CODE+'('+PROFITCENTER_NAME+')' AS PROFITCENTER_NAME FROM m_ProfitCenter_t WHERE FACTORY_ID='" & Me.cboFactory.SelectedValue.ToString.Trim & "'"

            Dim dtGroup As DataTable = Conn.GetDataTable(strSQL)

            Me.cboProfitCenter.DisplayMember = "PROFITCENTER_NAME"
            Me.cboProfitCenter.ValueMember = "PROFITCENTER_CODE"
            Me.cboProfitCenter.DataSource = dtGroup

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            MessageBox.Show("获取工厂利润中心失败,请确认网络是否连接正常，重启后重试。")
        End Try
    End Sub

    Private Sub mtxtFilePath_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtFilePath.ButtonCustomClick
        Try
            Me.OpenFileDialogRelease.ShowDialog()
            Me.OpenFileDialogRelease.Multiselect = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "打开选择文件窗口异常!", False)
        End Try
    End Sub

    Private Sub OpenFileDialogRelease_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialogRelease.FileOk
        Try
            If (Me.cboReleasedVersion.SelectedIndex = -1) Then
                Exit Sub
            End If

            Dim strFilePath As String
            Dim strFileName As String
            Dim strFileVersion As String
            Dim strReleasedVersionId As String

            strReleasedVersionId = Me.cboReleasedVersion.SelectedValue

            If (String.IsNullOrEmpty(strReleasedVersionId)) Then
                Exit Sub
            End If

            strFilePath = Me.OpenFileDialogRelease.FileName
            strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\") + 1)

            If FileVersionInfo.GetVersionInfo(strFilePath).ProductVersion Is Nothing Then
                strFileVersion = ""
            Else
                strFileVersion = FileVersionInfo.GetVersionInfo(strFilePath).ProductVersion.ToString()
            End If

            If (Not CheckSelectFile(strFileName, strFileVersion, strReleasedVersionId)) Then
                Me.mtxtFilePath.Text = ""
                Me.txtFileName.Text = ""
                Me.txtProgramVersion.Text = ""
                Me.txtFileVersion.Text = ""
                Me.txtFileModifyDate.Text = ""
                Me.ActiveControl = Me.mtxtFilePath
                Exit Sub
            End If

            Me.txtFileName.Text = Me.OpenFileDialogRelease.FileName.Substring(Me.OpenFileDialogRelease.FileName.LastIndexOf("\") + 1)
            Me.mtxtFilePath.Text = Me.OpenFileDialogRelease.FileName
            Dim LoacalFileModifyDateTime As String = File.GetLastWriteTime(Me.mtxtFilePath.Text)
            Me.txtFileModifyDate.Text = File.GetLastWriteTime(Me.mtxtFilePath.Text).ToString("yyyy/MM/dd HH:mm:ss")

            If FileVersionInfo.GetVersionInfo(Me.mtxtFilePath.Text).ProductVersion Is Nothing Then
                Me.txtProgramVersion.Text = ""
            Else
                Me.txtProgramVersion.Text = FileVersionInfo.GetVersionInfo(Me.mtxtFilePath.Text).ProductVersion.ToString()
            End If

            If FileVersionInfo.GetVersionInfo(Me.mtxtFilePath.Text).FileVersion Is Nothing Then
                Me.txtFileVersion.Text = ""
            Else
                Me.txtFileVersion.Text = FileVersionInfo.GetVersionInfo(Me.mtxtFilePath.Text).FileVersion.ToString()
            End If

            Dim fi As New System.IO.FileInfo(Me.mtxtFilePath.Text)
            strFileSize = fi.Length.ToString

            Me.txtCreateUserId.Text = VbCommClass.VbCommClass.UseId
            Me.ChkUsey.Checked = True
        Catch ex As Exception
            Me.mtxtFilePath.Text = ""
            Me.txtFileName.Text = ""
            Me.txtProgramVersion.Text = ""
            Me.txtFileVersion.Text = ""
            Me.txtFileModifyDate.Text = ""
            GetMesData.SetMessage(Me.lblMessage, "选择文件加载异常!", False)
        End Try
    End Sub

    Private Sub cboReleasedVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReleasedVersion.SelectedIndexChanged
        Try
            If (Not String.IsNullOrEmpty(Me.mtxtFilePath.Text.Trim)) Then
                Dim strFilePath As String
                Dim strFileName As String
                Dim strFileVersion As String
                Dim strReleasedVersionId As String

                strReleasedVersionId = Me.cboReleasedVersion.SelectedValue

                If (String.IsNullOrEmpty(strReleasedVersionId)) Then
                    Exit Sub
                End If

                strFilePath = Me.OpenFileDialogRelease.FileName
                strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\") + 1)

                If FileVersionInfo.GetVersionInfo(strFilePath).ProductVersion Is Nothing Then
                    strFileVersion = ""
                Else
                    strFileVersion = FileVersionInfo.GetVersionInfo(strFilePath).ProductVersion.ToString()
                End If

                If (Not CheckSelectFile(strFileName, strFileVersion, strReleasedVersionId)) Then
                    Me.mtxtFilePath.Text = ""
                    Me.txtFileName.Text = ""
                    Me.txtProgramVersion.Text = ""
                    Me.txtFileVersion.Text = ""
                    Me.txtFileModifyDate.Text = ""
                    Me.ActiveControl = Me.mtxtFilePath
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Me.mtxtFilePath.Text = ""
            Me.txtFileName.Text = ""
            Me.txtProgramVersion.Text = ""
            Me.txtFileVersion.Text = ""
            Me.txtFileModifyDate.Text = ""
            GetMesData.SetMessage(Me.lblMessage, "检查程序版本信息异常!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadControlData()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.cboFileClass.DisplayMember = "PARAMETER_NAME"
            Me.cboFileClass.ValueMember = "PARAMETER_VALUES"
            Me.cboFileClass.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("FileClass"))

            Me.cboSystemUpdateStatus.DisplayMember = "PARAMETER_NAME"
            Me.cboSystemUpdateStatus.ValueMember = "PARAMETER_VALUES"
            Me.cboSystemUpdateStatus.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("SystemUpdateStatus"))

            Me.cboUpdateType.DisplayMember = "PARAMETER_NAME"
            Me.cboUpdateType.ValueMember = "PARAMETER_VALUES"
            Me.cboUpdateType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("UpdateType"))

            Me.cboFactory.DisplayMember = "name"
            Me.cboFactory.ValueMember = "Factoryid"
            Me.cboFactory.DataSource = Conn.GetDataTable("select Factoryid,Factoryid+'-'+Shortname name from m_Dcompany_t")

            Me.cboReleasedVersion.DisplayMember = "ReleasedVersionName"
            Me.cboReleasedVersion.ValueMember = "ReleasedVersionId"
            Me.cboReleasedVersion.DataSource = GetMesData.GetReleasedVersionList("")

            If (Not String.IsNullOrEmpty(strFileno)) Then

                Dim dtTemp As DataTable = GetMesData.GetClientQuery(strFileno)
                If (Not dtTemp Is Nothing) Then
                    If (dtTemp.Rows.Count > 0) Then
                        'Me.txtClientMacAddress.Text = dtTemp.Rows(0).Item("ClientMacAddress").ToString
                        'Me.cboFactory.SelectedIndex = Me.cboFactory.FindString(dtTemp.Rows(0).Item("FactoryId").ToString)
                        'Me.cboProfitCenter.SelectedIndex = Me.cboProfitCenter.FindString(dtTemp.Rows(0).Item("ProfitCenterId").ToString)

                        'Me.txtDeptId.Text = dtTemp.Rows(0).Item("DeptId").ToString
                        'Me.txtLineId.Text = dtTemp.Rows(0).Item("LineId").ToString
                        'Me.cboReleasedVersion.SelectedIndex = Me.cboProfitCenter.FindString(dtTemp.Rows(0).Item("ReleasedVersionName").ToString)
                        'Me.txtAdministratorName.Text = dtTemp.Rows(0).Item("AdministratorName").ToString
                        'Me.txtRemark.Text = dtTemp.Rows(0).Item("Remark").ToString
                        'Me.txtCreateUserid.Text = dtTemp.Rows(0).Item("CreateUserId").ToString
                        'Me.txtCreateTime.Text = dtTemp.Rows(0).Item("CreateTime").ToString
                    End If
                End If
            End If
            LoadControlStatus()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub LoadControlStatus()
        Try
            If (Not String.IsNullOrEmpty(strFileno)) Then

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件状态异常", False)
        End Try
    End Sub

    Private Function CheckSelectFile(ByVal strFileName As String, ByVal strFileVersion As String, ByVal strReleasedVersionId As String) As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(strFileName)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择更新文件目录!", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(strReleasedVersionId)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择发布版本!", False)
                Return rtValue
                Exit Function
            End If

            If (strFileName.Substring(strFileName.LastIndexOf(".") + 1).ToUpper = "DLL".ToUpper) Then
                If (String.IsNullOrEmpty(strFileVersion)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "选择更新文件程序版本不能为空!", False)
                    Return rtValue
                    Exit Function
                End If

                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim DReader As SqlClient.SqlDataReader
                Try
                    DReader = Conn.GetDataReader("SELECT TOP 1 Fileno FROM M_Systemfile_t WHERE [Filename]='" & strFileName & "' AND Usey='Y' AND ReleasedVersionId='" & strReleasedVersionId & "' AND REPLACE(FileVersion, '.', '') >= REPLACE('" & strFileVersion & "', '.', '') ")

                    If (DReader.HasRows) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "选择更新文件版本不能低于系统版本!", False)
                        Return rtValue
                    Else
                        rtValue = True
                    End If
                    DReader.Close()
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                        DReader.Close()
                    End If

                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If

                    GetMesData.SetMessage(Me.lblMessage, "检查文件版本异常", False)
                    rtValue = False
                End Try
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查文件版本异常!", False)
            rtValue = False
        End Try
        Return rtValue
    End Function

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtFileName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择发布更新文件!", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboReleasedVersion.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择发布版本", False)
                Return rtValue
                Exit Function
            End If

            Dim strFileName As String = Me.txtFileName.Text.Trim
            Dim strFileVersion As String = Me.txtProgramVersion.Text.Trim

            If (strFileName.Substring(strFileName.LastIndexOf(".") + 1).ToUpper = "DLL".ToUpper) Then
                If (String.IsNullOrEmpty(strFileVersion)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "选择更新文件程序版本不能为空!", False)
                    Return rtValue
                    Exit Function
                End If
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim DReader As SqlClient.SqlDataReader
                Try
                    DReader = Conn.GetDataReader("SELECT TOP 1 Fileno FROM M_Systemfile_t WHERE [Filename]='" & strFileName & "' AND Usey='Y' AND REPLACE(FileVersion, '.', '') >= REPLACE('" & strFileVersion & "', '.', '') ")

                    If (DReader.HasRows) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "选择更新文件版本不能低于系统版本", False)
                        Return rtValue
                    Else
                        rtValue = True
                    End If
                    DReader.Close()
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                        DReader.Close()
                    End If

                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If

                    GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
                    rtValue = False
                End Try
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

#End Region

End Class