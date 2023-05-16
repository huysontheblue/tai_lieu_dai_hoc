
'--数据迁移管理
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

Public Class FrmDataHistoryManagement

#Region "加载事件"

    Private Sub FrmDataHistoryManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvDataHistory.AutoGenerateColumns = False
            Me.dgvSuccessRecord.AutoGenerateColumns = False
            Me.dgvFailureRecord.AutoGenerateColumns = False

            GetDataHistory()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim dataHistoryMaster As New FrmDataHistoryMaster("")
            dataHistoryMaster.ShowDialog()
            GetDataHistory()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvDataHistory.Rows.Count = 0 OrElse Me.dgvDataHistory.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要编辑的行!", False)
                Exit Sub
            End If

            Dim strDataHistoryId As String
            strDataHistoryId = IIf(IsDBNull(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value), "", Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value)

            If (String.IsNullOrEmpty(strDataHistoryId)) Then
                GetMesData.SetMessage(Me.lblMessage, "选择要编辑的迁移数据ID不能为空!", False)
                Exit Sub
            End If

            Dim dataHistoryMaster As New FrmDataHistoryMaster(strDataHistoryId)
            dataHistoryMaster.ShowDialog()
            GetDataHistory()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnEnable_Click(sender As Object, e As EventArgs) Handles btnEnable.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvDataHistory.Rows.Count = 0 OrElse Me.dgvDataHistory.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要停用的迁移数据!", False)
            Exit Sub
        End If

        Dim StrDataHistoryId As String
        StrDataHistoryId = IIf(IsDBNull(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value), "", Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value)

        If (String.IsNullOrEmpty(StrDataHistoryId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择迁移数据ID失败!", False)
            Exit Sub
        End If

        If (Not CheckEnable(StrDataHistoryId)) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DrExec As SqlDataReader
        Try
            strSQL.AppendLine(" DECLARE @rtValue VARCHAR(8), @rtMsg NVARCHAR(256) ")
            strSQL.AppendLine(" Execute Exec_DataHistoryEnable @rtValue OUTPUT, @rtMsg OUTPUT, '" & VbCommClass.VbCommClass.UseId & "', '" & StrDataHistoryId & "' ")
            strSQL.AppendLine(" SELECT @rtValue, @rtMsg ")

            DrExec = Conn.GetDataReader(strSQL.ToString())
            If (DrExec.HasRows) Then
                DrExec.Read()
                Select Case DrExec(0).ToString()
                    Case "0"
                        GetMesData.SetMessage(Me.lblMessage, DrExec(1).ToString(), False)
                    Case "1"
                        GetMesData.SetMessage(Me.lblMessage, "执行启用成功!", True)
                End Select
            Else
                GetMesData.SetMessage(Me.lblMessage, "执行启用失败，无法获取执行结果!", False)
            End If
            DrExec.Close()
            Conn.PubConnection.Close()
            GetDataHistory()
        Catch ex As Exception
            If (Not DrExec.IsClosed) Then
                DrExec.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行启用异常!", False)
        End Try
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvDataHistory.Rows.Count = 0 OrElse Me.dgvDataHistory.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要停用的迁移数据!", False)
            Exit Sub
        End If

        Dim StrJobID As String
        Dim StrDataHistoryId As String
        StrJobID = IIf(IsDBNull(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("JobID").Value), "", Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("JobID").Value)
        StrDataHistoryId = IIf(IsDBNull(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value), "", Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value)

        If (String.IsNullOrEmpty(StrJobID)) Then
            GetMesData.SetMessage(Me.lblMessage, "请选择迁移数据未启用，不能执行停用!", False)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(StrDataHistoryId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择迁移数据ID失败!", False)
            Exit Sub
        End If

        If (Not CheckDisabled(StrDataHistoryId)) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DrExec As SqlDataReader
        Try
            strSQL.AppendLine(" DECLARE @rtValue VARCHAR(8), @rtMsg NVARCHAR(256) ")
            strSQL.AppendLine(" Execute Exec_DataHistoryDisabled @rtValue OUTPUT, @rtMsg OUTPUT, '" & VbCommClass.VbCommClass.UseId & "', '" & StrDataHistoryId & "' ")
            strSQL.AppendLine(" SELECT @rtValue, @rtMsg ")

            DrExec = Conn.GetDataReader(strSQL.ToString())
            If (DrExec.HasRows) Then
                DrExec.Read()
                Select Case DrExec(0).ToString()
                    Case "0"
                        GetMesData.SetMessage(Me.lblMessage, DrExec(1).ToString(), False)
                    Case "1"
                        GetMesData.SetMessage(Me.lblMessage, "执行停用成功!", True)
                End Select
            Else
                GetMesData.SetMessage(Me.lblMessage, "执行启用失败，无法获取执行结果!", False)
            End If
            DrExec.Close()
            Conn.PubConnection.Close()
            GetDataHistory()
        Catch ex As Exception
            If (Not DrExec.IsClosed) Then
                DrExec.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "停用异常,请确认资料正确性", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            GetDataHistory()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvDataHistory_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDataHistory.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvDataHistory.Rows.Count = 0 OrElse Me.dgvDataHistory.CurrentRow Is Nothing Then
            Me.dgvSuccessRecord.Rows.Clear()
            Me.dgvFailureRecord.Rows.Clear()
            Exit Sub
        End If

        Try
            GeDataHistorySuccessRecord(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value.ToString())
            GeDataHistoryFailureRecord(Me.dgvDataHistory.Rows(Me.dgvDataHistory.CurrentRow.Index).Cells("DataHistoryId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub GetDataHistory()
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.txtMigrateTable.Text.Trim)) Then
                strWhere = strWhere & " AND LinkServerName = '" & Me.txtMigrateTable.Text.Trim.Replace("'", "''") & "' "
            End If

            strSQL = "SELECT DataHistoryId, MigrateServerName, MigrateDataBaseName, DataHistoryTableName, SourceDatabase, LinkServerName, TargetDataBaseName, TargetTableName," & _
              " TreatmentFlag, SequenceColumn, SequenceType, ColumnType, ColumnSQL, TargetColumnSQL, WhereSQL," & _
              " ProcessingNumber, ExecutionInterval, IntervalFrequency, CASE IntervalType WHEN '2' THEN N'秒' WHEN '4' THEN N'分' ELSE N'小时' END AS IntervalType, ChildTableFlag, StartTime, EndTime," & _
              " RetentionDays, Remark, CASE StatusFlag WHEN 'Y' THEN N'启用' ELSE N'停用' END AS StatusFlag, DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime, JobID " & _
              " FROM m_DataHistory_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY  CreateTime DESC"
            Me.dgvDataHistory.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            If Not (DReader.HasRows) Then
                Me.dgvDataHistory.Rows.Clear()
            End If

            Do While DReader.Read()
                Me.dgvDataHistory.Rows.Add(DReader.Item("DataHistoryId").ToString, DReader.Item("DataHistoryTableName").ToString, DReader.Item("MigrateServerName").ToString, DReader.Item("MigrateDataBaseName").ToString, DReader.Item("LinkServerName").ToString, DReader.Item("TargetDataBaseName").ToString, DReader.Item("TargetTableName").ToString, DReader.Item("SourceDatabase").ToString, DReader.Item("TreatmentFlag").ToString, DReader.Item("ProcessingNumber").ToString, DReader.Item("ExecutionInterval").ToString, DReader.Item("IntervalFrequency").ToString,
                                           DReader.Item("IntervalType").ToString, DReader.Item("StartTime").ToString, DReader.Item("EndTime").ToString, DReader.Item("RetentionDays").ToString, DReader.Item("Remark").ToString, DReader.Item("StatusFlag").ToString, DReader.Item("CreateUserId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUserId").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("JobID").ToString)
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

    Private Sub GeDataHistorySuccessRecord(ByVal strDataHistoryId As String)
        Try
            Me.dgvSuccessRecord.DataSource = GetMesData.GetDataHistoryRecordQuery(strDataHistoryId, "1")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载成功日志异常", False)
            Me.dgvSuccessRecord.Rows.Clear()
        End Try
    End Sub

    Private Sub GeDataHistoryFailureRecord(ByVal strDataHistoryId As String)
        Try
            Me.dgvFailureRecord.DataSource = GetMesData.GetDataHistoryRecordQuery(strDataHistoryId, "0")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常日志异常", False)
            Me.dgvFailureRecord.Rows.Clear()
        End Try
    End Sub

    Private Function CheckEnable(ByVal strDataHistoryId As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT DataHistoryId FROM m_DataHistory_t WHERE DataHistoryId='" & strDataHistoryId & "' AND StatusFlag='Y'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "启用失败，迁移定义已经启用!", False)
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
            GetMesData.SetMessage(Me.lblMessage, "执行启用数据状态检查异常!", False)
        End Try
        Return rtValue
    End Function

    Private Function CheckDisabled(ByVal strDataHistoryId As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT DataHistoryId FROM m_DataHistory_t WHERE DataHistoryId='" & strDataHistoryId & "' AND StatusFlag='N'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "停用失败，迁移定义已经停用!", False)
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
            GetMesData.SetMessage(Me.lblMessage, "执行停用数据状态检查异常!", False)
        End Try
        Return rtValue
    End Function

#End Region
    
  
End Class