
'--链接服务器管理
'--Create by :　马锋
'--Create date :　2015/09/21
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

Public Class FrmLinkServerManagement

#Region "加载事件"
    Private Sub FrmLinkServerManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.dgvLinkServer.AutoGenerateColumns = False
            GetLinkServer()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim warehouseingMaster As New FrmLinkServerMaster("")
            warehouseingMaster.ShowDialog()
            GetLinkServer()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvLinkServer.Rows.Count = 0 OrElse Me.dgvLinkServer.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除链接服务器", False)
            Exit Sub
        End If
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL.AppendLine(" UPDATE m_LinkServer_t SET DeleteFlag='1', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() WHERE LinkServerId='" & Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim & "' ")
            strSQL.AppendLine(" IF EXISTS(SELECT LinkServerId FROM m_LinkServer_t WHERE LinkServerId='" & Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim & "' AND StatusFlag='Y') BEGIN EXEC master.dbo.sp_dropserver @server=N'" & Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerName").Value.ToString.Trim & "', @droplogins='droplogins' END ")
            Conn.ExecSql(strSQL.ToString())
            GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvLinkServer.Rows.Count = 0 OrElse Me.dgvLinkServer.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改的链接服务器", False)
            Exit Sub
        End If
        Try
            Dim warehouseingMaster As New FrmLinkServerMaster(Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim)
            warehouseingMaster.ShowDialog()
            GetLinkServer()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "编辑异常", False)
        End Try
    End Sub

    Private Sub btnEnable_Click(sender As Object, e As EventArgs) Handles btnEnable.Click
        If Me.dgvLinkServer.Rows.Count = 0 OrElse Me.dgvLinkServer.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要启用的链接服务器", False)
            Exit Sub
        End If
        Dim strLinkServerId As String
        Dim strLinkServerName As String
        strLinkServerId = Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim
        strLinkServerName = Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerName").Value.ToString.Trim

        If (String.IsNullOrEmpty(strLinkServerId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择链接服务器ID失败!", False)
            Exit Sub
        End If

        If (Not CheckEnable(strLinkServerId)) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

        Try

            'strSQL.AppendLine(" UPDATE m_LinkServer_t SET StatusFlag='Y' WHERE LinkServerId='" & Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim & "' ")
            strSQL.AppendLine(" IF EXISTS(SELECT LinkServerId FROM m_LinkServer_t WHERE LinkServerId='" & strLinkServerId & "' AND StatusFlag='N') BEGIN ")
            strSQL.AppendLine(" DECLARE @LinkServerName VARCHAR(32), @LoginServerUser VARCHAR(32), @LoginPassWord VARCHAR(64), @Providers NVARCHAR(64), @ProductName NVARCHAR(64), @DataSources NVARCHAR(512), @Catalog NVARCHAR(512), @ProvidersStrings NVARCHAR(512) ")
            strSQL.AppendLine(" SELECT  @LinkServerName = LinkServerName, @LoginServerUser =  LoginUserName, @LoginPassWord = LoginPassword, @Providers = Providers, @ProductName=ProductName, @DataSources=DataSources, @Catalog=Catalog, @ProvidersStrings=ProvidersStrings FROM m_LinkServer_t WHERE LinkServerId='" & strLinkServerId & "' ")
            strSQL.AppendLine(" IF (ISNULL(@ProductName,'')='SQL Server' ) BEGIN EXEC master.dbo.sp_addlinkedserver @server = @LinkServerName, @srvproduct=@ProductName END ")
            ', @provstr=@ProvidersStrings, @catalog=@Catalog
            strSQL.AppendLine(" ELSE BEGIN EXEC master.dbo.sp_addlinkedserver @server = @LinkServerName, @srvproduct=@ProductName, @provider=@Providers, @datasrc=@DataSources END ")

            strSQL.AppendLine(" EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname= @LinkServerName,@useself=N'False',@locallogin=NULL,@rmtuser=@LoginServerUser,@rmtpassword=@LoginPassWord ")

            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'collation compatible', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'data access', @optvalue=N'true' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'dist', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'pub', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'rpc', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'rpc out', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'sub', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'connect timeout', @optvalue=N'0' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'collation name', @optvalue=null ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'lazy schema validation', @optvalue=N'false' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'query timeout', @optvalue=N'0' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'use remote collation', @optvalue=N'true' ")
            strSQL.AppendLine(" EXEC master.dbo.sp_serveroption @server=@LinkServerName, @optname=N'remote proc transaction promotion', @optvalue=N'true' END ")
            Conn.ExecNOCommandSql(strSQL.ToString)

            Conn.ExecNOCommandSql(" EXEC sp_testlinkedserver N'" & strLinkServerName & "'")
            Conn.ExecNOCommandSql(" UPDATE m_LinkServer_t SET StatusFlag='Y', EnableUserId = '" & VbCommClass.VbCommClass.UseId & "', EnableTime = GETDATE(), UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() WHERE LinkServerId='" & strLinkServerId & "' ")
            Conn.PubConnection.Close()
            GetMesData.SetMessage(Me.lblMessage, "启用成功", True)
            GetLinkServer()
        Catch ex As Exception
            Conn.ExecNOCommandSql(" EXEC master.dbo.sp_dropserver @server=N'" & strLinkServerName & "', @droplogins='droplogins' ")
            Conn.ExecNOCommandSql(" UPDATE m_LinkServer_t SET StatusFlag='N', EnableUserId=NULL, EnableTime=NULL, UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() WHERE LinkServerId='" & strLinkServerId & "' ")
            Conn.PubConnection.Close()
            GetMesData.SetMessage(Me.lblMessage, "启用异常,请确认服务器地址和登录信息是否正确", False)
        End Try
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        If Me.dgvLinkServer.Rows.Count = 0 OrElse Me.dgvLinkServer.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除链接服务器", False)
            Exit Sub
        End If

        Dim strLinkServerId As String
        Dim strLinkServerName As String
        strLinkServerId = Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerId").Value.ToString.Trim
        strLinkServerName = Me.dgvLinkServer.Rows(Me.dgvLinkServer.CurrentRow.Index).Cells("LinkServerName").Value.ToString.Trim

        If (String.IsNullOrEmpty(strLinkServerId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择链接服务器ID失败!", False)
            Exit Sub
        End If

        If (Not CheckDisabled(strLinkServerId)) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Conn.ExecNOCommandSql(" UPDATE m_LinkServer_t SET StatusFlag='N', DisabledUserId = " & VbCommClass.VbCommClass.UseId & ", DisabledTime = GETDATE(), UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() WHERE LinkServerId='" & strLinkServerId & "' ")
            Conn.ExecNOCommandSql(" IF EXISTS(SELECT LinkServerId FROM m_LinkServer_t WHERE LinkServerId='" & strLinkServerId & "' AND StatusFlag='Y') BEGIN EXEC master.dbo.sp_dropserver @server=N'" & strLinkServerName & "', @droplogins='droplogins' END ")

            GetMesData.SetMessage(Me.lblMessage, "停用成功", True)
            GetLinkServer()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "停用异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            GetLinkServer()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub GetLinkServer()
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.txtLinkServerName.Text.Trim)) Then
                strWhere = strWhere & " AND LinkServerName = '" & Me.txtLinkServerName.Text.Trim.Replace("'", "''") & "' "
            End If

            strSQL = "SELECT  LinkServerId, LinkServerName, LoginUserName, LoginPassword, Rework, CASE StatusFlag WHEN 'Y' THEN N'启用' ELSE N'停用' END AS StatusFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime FROM m_LinkServer_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY  CreateTime DESC"

            Me.dgvLinkServer.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            If Not (DReader.HasRows) Then
                Me.dgvLinkServer.Rows.Clear()
            End If

            Do While DReader.Read()
                Me.dgvLinkServer.Rows.Add(DReader.Item("LinkServerId").ToString, DReader.Item("LinkServerName").ToString, DReader.Item("LoginUserName").ToString, DReader.Item("Rework").ToString, DReader.Item("StatusFlag").ToString, DReader.Item("CreateUserId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUserId").ToString, DReader.Item("UpdateTime").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckEnable(ByVal strLinkServerId As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT LinkServerId FROM m_LinkServer_t WHERE LinkServerId='" & strLinkServerId & "' AND StatusFlag='Y'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "启用失败，链接服务器已经启用!", False)
                rtValue = False
            Else
                rtValue = True
            End If
            DrCheck.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DrCheck.IsClosed) Then
                DrCheck.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            rtValue = False
            GetMesData.SetMessage(Me.lblMessage, "执行启用链接服务器状态检查异常!", False)
        End Try
        Return rtValue
    End Function

    Private Function CheckDisabled(ByVal strLinkServerId As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT LinkServerId FROM m_LinkServer_t WHERE LinkServerId='" & strLinkServerId & "' AND StatusFlag='N'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "停用失败，链接服务器已经停用!", False)
                rtValue = False
            Else
                rtValue = True
            End If
            DrCheck.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DrCheck.IsClosed) Then
                DrCheck.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            rtValue = False
            GetMesData.SetMessage(Me.lblMessage, "执行停用链接服务器状态检查异常!", False)
        End Try
        Return rtValue
    End Function

#End Region


    
End Class
