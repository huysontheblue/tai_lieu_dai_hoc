
'--客户端管理
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

Public Class FrmClientManagement

#Region "加载事件"

    Private Sub FrmClientManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvClient.AutoGenerateColumns = False
            GetClient()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim clientMaster As New FrmClientMaster("")
            clientMaster.ShowDialog()
            GetClient()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvClient.Rows.Count = 0 OrElse Me.dgvClient.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要编辑的行!", False)
                Exit Sub
            End If

            Dim strClientInfoId As String
            strClientInfoId = IIf(IsDBNull(Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value), "", Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value)

            If (String.IsNullOrEmpty(strClientInfoId)) Then
                GetMesData.SetMessage(Me.lblMessage, "选择要编辑的连接ID不能为空!", False)
                Exit Sub
            End If

            Dim clientMaster As New FrmClientMaster(strClientInfoId)
            clientMaster.ShowDialog()
            GetClient()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "编辑异常", False)
        End Try
    End Sub

    Private Sub btnEnable_Click(sender As Object, e As EventArgs) Handles btnEnable.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvClient.Rows.Count = 0 OrElse Me.dgvClient.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要启用的连接数据库!", False)
            Exit Sub
        End If

        Dim strClientInfoId As String
        strClientInfoId = IIf(IsDBNull(Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value), "", Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value)

        If (String.IsNullOrEmpty(strClientInfoId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择连接数据ID失败!", False)
            Exit Sub
        End If

        If (Not CheckStatus(strClientInfoId, "Y")) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL.AppendLine("UPDATE m_ClientInfo_t SET StatusFlag = 'Y' WHERE ClientInfoId='" & strClientInfoId & "' ")

            Conn.ExecSql(strSQL.ToString)
            Conn.PubConnection.Close()
            GetClient()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行启用异常!", False)
        End Try
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvClient.Rows.Count = 0 OrElse Me.dgvClient.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要停用的连接数据库!", False)
            Exit Sub
        End If

        Dim strClientInfoId As String
        strClientInfoId = IIf(IsDBNull(Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value), "", Me.dgvClient.Rows(Me.dgvClient.CurrentRow.Index).Cells("ClientInfoId").Value)

        If (String.IsNullOrEmpty(strClientInfoId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择连接数据ID失败!", False)
            Exit Sub
        End If

        If (Not CheckStatus(strClientInfoId, "N")) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL.AppendLine("UPDATE m_ClientInfo_t SET StatusFlag = 'N' WHERE ClientInfoId='" & strClientInfoId & "' ")

            Conn.ExecSql(strSQL.ToString)
            Conn.PubConnection.Close()
            GetClient()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行停用异常!", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            GetClient()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub GetClient()
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.txtClientMacAddress.Text.Trim)) Then
                strWhere = strWhere & " AND ClientMacAddress = '" & Me.txtClientMacAddress.Text.Trim.Replace("'", "''") & "' "
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY ClientInfoId )as RowNum, ClientInfoId, ClientName, ClientMacAddress, AdministratorName, FactoryId, FactoryName, ProfitCenterId, ProfitCenterName, DeptId, LineId, ReleasedVersionId, " & _
               " ReleasedVersionName, Remark, CASE StatusFlag WHEN 'Y' THEN N'启用' ELSE N'停用' END AS StatusFlag, DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime " & _
               " FROM m_ClientInfo_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY  CreateTime DESC"
            Me.dgvClient.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            If Not (DReader.HasRows) Then
                Me.dgvClient.Rows.Clear()
            End If

            Do While DReader.Read()
                Me.dgvClient.Rows.Add(DReader.Item("ClientInfoId").ToString, DReader.Item("RowNum").ToString, DReader.Item("ClientName").ToString, DReader.Item("AdministratorName").ToString, DReader.Item("FactoryName").ToString, DReader.Item("ProfitCenterName").ToString, DReader.Item("DeptId").ToString, DReader.Item("LineId").ToString, DReader.Item("ReleasedVersionName").ToString, DReader.Item("Remark").ToString, DReader.Item("StatusFlag").ToString,
                                           DReader.Item("CreateUserId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUserId").ToString, DReader.Item("UpdateTime").ToString)
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

    Private Function CheckStatus(ByVal strClientInfoId As String, ByVal strCheckType As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT ClientInfoId FROM m_ClientInfo_t WHERE ClientInfoId='" & strClientInfoId & "' AND StatusFlag='" & strCheckType & "'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "启用失败，连接数据库已经启用!", False)
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
            GetMesData.SetMessage(Me.lblMessage, "执行数据状态检查异常!", False)
        End Try
        Return rtValue
    End Function

#End Region

End Class