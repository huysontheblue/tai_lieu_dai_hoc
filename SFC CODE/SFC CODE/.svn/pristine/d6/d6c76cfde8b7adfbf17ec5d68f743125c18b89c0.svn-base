'--数据库定义
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

Public Class FrmConnectDatabaseMaster

#Region "变量声明"

    Dim _strConnectDatabaseId As String

    Public Property strConnectDatabaseId() As String
        Get
            Return _strConnectDatabaseId
        End Get

        Set(value As String)
            _strConnectDatabaseId = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ConnectDatabaseId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strConnectDatabaseId = _ConnectDatabaseId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmConnectDatabaseMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

                If (String.IsNullOrEmpty(strConnectDatabaseId)) Then
                    strSQL.AppendLine(" INSERT INTO m_ConnectDatabase_t(ConnectDatabaseName, ConnectDatabaseAddress, ConnnectDataBase, LoginUserId, ")
                    strSQL.AppendLine(" LoginPassword, Remark, StatusFlag, DeleteFlag, CreateUserId, CreateTime) VALUES ( ")
                    strSQL.AppendLine(" N'" & Me.txtConnectDatabaseName.Text.Trim & "', '" & Me.txtConnectDatabaseAddress.Text.Trim & "', '" & Me.txtConnnectDataBase.Text.Trim & "','" & Me.txtLoginUserId.Text.Trim & "', ")
                    strSQL.AppendLine(" '" & Me.txtLoginPassword.Text.Trim.Replace("'", "''") & "', N'" & Me.txtRemark.Text.Trim & "', 'N', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                Else
                    strSQL.AppendLine(" UPDATE m_ConnectDatabase_t SET ConnectDatabaseName = N'" & Me.txtConnectDatabaseName.Text.Trim & "', ConnectDatabaseAddress='" & Me.txtConnectDatabaseAddress.Text.Trim & "', ConnnectDataBase='" & Me.txtConnnectDataBase.Text.Trim & "', LoginUserId='" & Me.txtLoginUserId.Text.Trim & "', ")
                    strSQL.AppendLine(" LoginPassword='" & Me.txtLoginPassword.Text.Trim.Replace("'", "''") & "', Remark=N'" & Me.txtRemark.Text.Trim & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() ")
                    strSQL.AppendLine(" WHERE ConnectDatabaseId = '" & strConnectDatabaseId & "'")
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

#End Region

#Region "函数"

    Private Sub LoadControlData()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            If (Not String.IsNullOrEmpty(strConnectDatabaseId)) Then

                Dim dtTemp As DataTable = GetMesData.GetConnectDatabaseQuery(strConnectDatabaseId)
                If (Not dtTemp Is Nothing) Then
                    If (dtTemp.Rows.Count > 0) Then
                        Me.txtConnectDatabaseName.Text = dtTemp.Rows(0).Item("ConnectDatabaseName").ToString
                        Me.txtConnectDatabaseAddress.Text = dtTemp.Rows(0).Item("ConnectDatabaseAddress").ToString
                        Me.txtConnnectDataBase.Text = dtTemp.Rows(0).Item("ConnnectDataBase").ToString
                        Me.txtLoginUserId.Text = dtTemp.Rows(0).Item("LoginUserId").ToString
                        Me.txtLoginPassword.Text = dtTemp.Rows(0).Item("LoginPassword").ToString
                        Me.txtRemark.Text = dtTemp.Rows(0).Item("Remark").ToString
                        Me.txtCreateUserId.Text = dtTemp.Rows(0).Item("CreateUserId").ToString
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
            If (Not String.IsNullOrEmpty(strConnectDatabaseId)) Then

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件状态异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtConnectDatabaseName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入连接名称", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtConnectDatabaseAddress.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入连接地址", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtConnnectDataBase.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入连接数据库", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtLoginUserId.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入登录名称", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtLoginPassword.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入登录密码", False)
                Return rtValue
                Exit Function
            End If

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim DReader As SqlClient.SqlDataReader
            Try
                DReader = Conn.GetDataReader("SELECT ConnectDatabaseId FROM m_ConnectDatabase_t WHERE ConnectDatabaseName = '" & Me.txtConnectDatabaseName.Text.Trim & "' AND ConnectDatabaseId <> '" & strConnectDatabaseId & "' ")

                If (DReader.HasRows) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入的连接名称已经存在", False)
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