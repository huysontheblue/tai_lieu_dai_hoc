
'--发布版本定义
'--Create by :　马锋
'--Create date :　2015/11/09
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

Public Class FrmReleasedVersionMaster

#Region "变量声明"

    Dim _strReleasedVersionId As String

    Public Property strReleasedVersionId() As String
        Get
            Return _strReleasedVersionId
        End Get

        Set(value As String)
            _strReleasedVersionId = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ReleasedVersionId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strReleasedVersionId = _ReleasedVersionId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmReleasedVersionMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Dim strSQL As New StringBuilder
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Try

                If (String.IsNullOrEmpty(strReleasedVersionId)) Then
                    strSQL.AppendLine(" INSERT INTO m_ReleasedVersion_t(ReleasedVersionName, ReleasedVersionTypeId, ReleasedVersionTypeName, SoftWareName, CustomerId, CustomerName, ConnectDatabaseId, ConnectDatabaseName, ")
                    strSQL.AppendLine(" FactoryId, FactoryName, ProfitCenterId, ProfitCenterName, Remark, StatusFlag, DeleteFlag, CreateUserId, CreateTime) VALUES ( ")
                    strSQL.AppendLine(" N'" & Me.txtReleasedVersionName.Text.Trim & "', '" & Me.cboReleasedVersionType.SelectedValue.ToString & "', N'" & Me.cboReleasedVersionType.Text.ToString & "', N'" & Me.txtSoftWareName.Text.Trim & "', '" & Me.cboCustomer.SelectedValue.ToString.Trim & "', N'" & Me.cboCustomer.Text.Trim & "','" & Me.cboConnectDatabase.SelectedValue.ToString.Trim & "',N'" & Me.cboConnectDatabase.Text.Trim & "', ")
                    strSQL.AppendLine(" '" & Me.cboFactory.SelectedValue.ToString.Trim & "', N'" & Me.cboFactory.Text.ToString.Trim & "', N'" & Me.cboProfitCenter.SelectedValue.ToString.Trim & "', N'" & Me.cboProfitCenter.Text.ToString.Trim & "', N'" & Me.txtRemark.Text.Trim & "', 'N', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                Else
                    strSQL.AppendLine(" UPDATE m_ReleasedVersion_t SET ReleasedVersionName = N'" & Me.txtReleasedVersionName.Text.Trim & "', ReleasedVersionTypeId='" & Me.cboReleasedVersionType.SelectedValue.ToString & "', ReleasedVersionTypeName= N'" & Me.cboReleasedVersionType.Text.ToString & "', SoftWareName=N'" & Me.txtSoftWareName.Text.Trim & "', CustomerId='" & Me.cboCustomer.SelectedValue.ToString.Trim & "', CustomerName=N'" & Me.cboCustomer.Text.Trim & "', ConnectDatabaseId='" & Me.cboConnectDatabase.SelectedValue.ToString.Trim & "', ConnectDatabaseName=N'" & Me.cboConnectDatabase.Text.Trim & "', ")
                    strSQL.AppendLine(" FactoryId='" & Me.cboFactory.SelectedValue.ToString.Trim & "', FactoryName=N'" & Me.cboFactory.Text.ToString.Trim & "', ProfitCenterId='" & Me.cboProfitCenter.SelectedValue.Trim & "', ProfitCenterName=N'" & Me.cboProfitCenter.Text.Trim & "', Remark=N'" & Me.txtRemark.Text.Trim & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() ")
                    strSQL.AppendLine(" WHERE ReleasedVersionId = '" & strReleasedVersionId & "'")
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
            strSQL = "SELECT PROFITCENTER_CODE, PROFITCENTER_NAME FROM m_ProfitCenter_t WHERE FACTORY_ID='" & Me.cboFactory.SelectedValue.ToString.Trim & "'"

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

#End Region

#Region "函数"

    Private Sub LoadControlData()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.cboReleasedVersionType.DisplayMember = "PARAMETER_NAME"
            Me.cboReleasedVersionType.ValueMember = "PARAMETER_VALUES"
            Me.cboReleasedVersionType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("ReleasedVersionType"))

            Me.cboFactory.DisplayMember = "name"
            Me.cboFactory.ValueMember = "Factoryid"
            Me.cboFactory.DataSource = Conn.GetDataTable("select Factoryid, Shortname name from m_Dcompany_t")

            Me.cboCustomer.DisplayMember = "CusName"
            Me.cboCustomer.ValueMember = "CusID"
            Me.cboCustomer.DataSource = GetMesData.GetCustomerList("")

            Me.cboConnectDatabase.DisplayMember = "ConnectDatabaseName"
            Me.cboConnectDatabase.ValueMember = "ConnectDatabaseId"
            Me.cboConnectDatabase.DataSource = GetMesData.GetConnectDatabaseList("")

            If (Not String.IsNullOrEmpty(strReleasedVersionId)) Then

                Dim dtTemp As DataTable = GetMesData.GetReleasedVersionQuery(strReleasedVersionId)
                If (Not dtTemp Is Nothing) Then
                    If (dtTemp.Rows.Count > 0) Then
                        Me.txtReleasedVersionName.Text = dtTemp.Rows(0).Item("ReleasedVersionName").ToString
                        Me.txtSoftWareName.Text = dtTemp.Rows(0).Item("SoftWareName").ToString
                        Me.cboReleasedVersionType.SelectedIndex = Me.cboReleasedVersionType.FindString(dtTemp.Rows(0).Item("ReleasedVersionTypeName").ToString)
                        Me.cboConnectDatabase.SelectedIndex = Me.cboConnectDatabase.FindString(dtTemp.Rows(0).Item("ConnectDatabaseName").ToString)
                        Me.cboCustomer.SelectedIndex = Me.cboCustomer.FindString(dtTemp.Rows(0).Item("CustomerName").ToString)
                        Me.cboFactory.SelectedIndex = Me.cboFactory.FindString(dtTemp.Rows(0).Item("FactoryName").ToString)
                        Me.cboProfitCenter.SelectedIndex = Me.cboProfitCenter.FindString(dtTemp.Rows(0).Item("ProfitCenterName").ToString)
                        Me.txtRemark.Text = dtTemp.Rows(0).Item("Remark").ToString
                        Me.txtCreateUserid.Text = dtTemp.Rows(0).Item("CreateUserId").ToString
                        Me.txtCreateTime.Text = dtTemp.Rows(0).Item("CreateTime").ToString
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
            If (Not String.IsNullOrEmpty(strReleasedVersionId)) Then

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件状态异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtReleasedVersionName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入连接名称", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboConnectDatabase.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入连接地址", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboConnectDatabase.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择连接数据库", False)
                Return rtValue
                Exit Function
            End If

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim DReader As SqlClient.SqlDataReader
            Try
                DReader = Conn.GetDataReader("SELECT ReleasedVersionId FROM m_ReleasedVersion_t WHERE ReleasedVersionName = '" & Me.txtReleasedVersionName.Text.Trim & "' AND ReleasedVersionId <> '" & strReleasedVersionId & "' ")

                If (DReader.HasRows) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入的版本名称已经存在", False)
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
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

#End Region

End Class