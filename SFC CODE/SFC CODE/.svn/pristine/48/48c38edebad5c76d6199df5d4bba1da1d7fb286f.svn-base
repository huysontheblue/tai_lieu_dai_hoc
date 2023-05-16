
'--链接服务器维护
'--Create by :　马锋
'--Create date :　2015/09/18
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

Public Class FrmLinkServerMaster

#Region "变量声明"

    Dim _strLinkServerId As String
    Public Property LinkServerId() As String
        Get
            Return _strLinkServerId
        End Get

        Set(value As String)
            _strLinkServerId = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _LinkServerId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        LinkServerId = _LinkServerId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmLinkServerMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadControlData()
            Me.cboProviders.SelectedIndex = -1
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载数据异常!", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub rBtnDataType_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnSQL.CheckedChanged, rBtnOther.CheckedChanged
        Try
            If (Me.rBtnSQL.Checked) Then
                Me.cboProviders.Enabled = False
                Me.cboProviders.SelectedIndex = -1
                Me.txtProductName.Enabled = False
                Me.txtDataSources.Enabled = False
                Me.txtCatalog.Enabled = False
                Me.txtLocation.Enabled = False
                Me.txtProvidersStrings.Enabled = False
            Else
                Me.cboProviders.Enabled = True
                Me.cboProviders.SelectedIndex = 0
                Me.txtProductName.Enabled = True
                Me.txtDataSources.Enabled = True
                Me.txtCatalog.Enabled = True
                Me.txtLocation.Enabled = True
                Me.txtProvidersStrings.Enabled = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改异常!", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not (CheckSave()) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim strProviders As String
        Dim strProductName As String

        If (String.IsNullOrEmpty(Me.txtProductName.Text.Trim)) Then
            strProductName = "SQL Server"
        Else
            strProductName = Me.txtProductName.Text.Trim
        End If

        If (String.IsNullOrEmpty(Me.cboProviders.Text)) Then
            strProviders = ""
        Else
            strProviders = Me.cboProviders.SelectedValue
        End If

        Try
            If (String.IsNullOrEmpty(LinkServerId)) Then
                strSQL.AppendLine(" INSERT INTO m_LinkServer_t( LinkServerName, LoginUserName, LoginPassword, LinkServerType, Providers, ProductName, DataSources, Catalog, ProvidersStrings, Rework, StatusFlag, CreateUserId, CreateTime)VALUES(")
                strSQL.AppendLine(" '" & Me.txtLinkServerName.Text.Trim.Replace("'", "''") & "', '" & Me.txtLoginUserName.Text.Trim.Replace("'", "''") & "', '" & Me.txtLoginPassword.Text.Trim.Replace("'", "''") & "', '" & IIf(Me.rBtnSQL.Checked, "1", "0") & "', '" & strProviders.Replace("'", "''") & "', '" & strProductName.Trim.Replace("'", "''") & "', '" & Me.txtDataSources.Text.Trim.Replace("'", "''") & "', '" & Me.txtCatalog.Text.Trim.Replace("'", "''") & "', '" & Me.txtProvidersStrings.Text.Trim.Replace("'", "''") & "', N'" & Me.txtRewark.Text.Trim.Replace("'", "''") & "', '" & IIf(Me.chkStatusFlag.Checked, "Y", "N") & "', '" & VbCommClass.VbCommClass.UseId & "', getdate()) ")
            Else
                strSQL.AppendLine(" UPDATE m_LinkServer_t SET LinkServerName='" & Me.txtLinkServerName.Text.Trim.Replace("'", "''") & "', LoginUserName='" & Me.txtLoginUserName.Text.Trim.Replace("'", "''") & "', LoginPassword='" & Me.txtLoginPassword.Text.Trim.Replace("'", "''") & "', LinkServerType='" & IIf(Me.rBtnSQL.Checked, "1", "0") & "', Providers='" & strProviders.Replace("'", "''") & "', ProductName='" & strProductName.Trim.Replace("'", "''") & "', DataSources='" & Me.txtDataSources.Text.Trim.Replace("'", "''") & "', Catalog='" & Me.txtCatalog.Text.Trim.Replace("'", "''") & "', ProvidersStrings='" & Me.txtProvidersStrings.Text.Trim.Replace("'", "''") & "', Rework=N'" & Me.txtRewark.Text.Trim.Replace("'", "''") & "', StatusFlag='" & IIf(Me.chkStatusFlag.Checked, "Y", "N") & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate()")
                strSQL.AppendLine(" WHERE LinkServerId = '" & LinkServerId & "'")
            End If

            If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                Conn.ExecSql(strSQL.ToString())
            End If

            Conn.PubConnection.Close()
            Me.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存异常!", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "函数"

    Private Sub LoadControlData()
        Try

            Me.cboProviders.DisplayMember = "Provider Description"
            Me.cboProviders.ValueMember = "Provider Name"
            Me.cboProviders.DataSource = GetMesData.GetServerProviders()

            If (String.IsNullOrEmpty(_strLinkServerId)) Then
                Me.txtCreateUserId.Text = VbCommClass.VbCommClass.UseId
            Else
                Dim dtLinkServer As DataTable
                dtLinkServer = GetMesData.GetLinkServer(LinkServerId)

                If (Not dtLinkServer Is Nothing And dtLinkServer.Rows.Count > 0) Then
                    Me.txtLinkServerName.Text = dtLinkServer.Rows(0).Item("LinkServerName").ToString
                    Me.chkStatusFlag.Checked = IIf(dtLinkServer.Rows(0).Item("StatusFlag").ToString = "Y", True, False)
                    Me.txtLoginUserName.Text = dtLinkServer.Rows(0).Item("LoginUserName").ToString
                    Me.txtLoginPassword.Text = dtLinkServer.Rows(0).Item("LoginPassword").ToString
                    Me.txtRewark.Text = dtLinkServer.Rows(0).Item("Rework").ToString
                    Me.txtCreateUserId.Text = dtLinkServer.Rows(0).Item("CreateUserId").ToString
                    Me.txtCreateTime.Text = dtLinkServer.Rows(0).Item("CreateTime").ToString
                    Me.rBtnSQL.Checked = IIf(dtLinkServer.Rows(0).Item("LinkServerType").ToString = "1", True, False)
                    Me.rBtnOther.Checked = IIf(dtLinkServer.Rows(0).Item("LinkServerType").ToString = "0", True, False)
                    Me.txtProductName.Text = dtLinkServer.Rows(0).Item("ProductName").ToString
                    Me.txtDataSources.Text = dtLinkServer.Rows(0).Item("DataSources").ToString
                    Me.txtCatalog.Text = dtLinkServer.Rows(0).Item("Catalog").ToString
                    Me.txtLocation.Text = dtLinkServer.Rows(0).Item("Location").ToString
                    Me.txtProvidersStrings.Text = dtLinkServer.Rows(0).Item("ProvidersStrings").ToString

                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtLinkServerName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入服务器名称", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtLoginUserName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入链接服务器登录用户名", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtLoginPassword.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入链接服务器登录密码", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(LinkServerId)) Then
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim DReader As SqlClient.SqlDataReader
                Try
                    '系统链接服务器检查
                    DReader = Conn.GetDataReader("SELECT [name] FROM sys.servers WHERE [name]='" & Me.txtLinkServerName.Text.Trim & "'")
                    If (DReader.HasRows) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请输入链接服务器已经存在", False)
                        DReader.Close()
                        Return rtValue
                    Else
                        DReader.Close()
                        DReader = Conn.GetDataReader("SELECT LinkServerName FROM m_LinkServer_t WHERE LinkServerName='" & Me.txtLinkServerName.Text.Trim & "'")

                        If (DReader.HasRows) Then
                            rtValue = False
                            GetMesData.SetMessage(Me.lblMessage, "请输入链接服务器已经存在", False)
                            Return rtValue
                        Else
                            rtValue = True
                        End If
                        DReader.Close()
                    End If
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