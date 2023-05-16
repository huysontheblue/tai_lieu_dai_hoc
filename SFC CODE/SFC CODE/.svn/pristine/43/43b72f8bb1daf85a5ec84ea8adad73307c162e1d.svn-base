
'--程序发布管理
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

Public Class FrmReleaseFileManagement

#Region "变量声明"

    Dim nodeTag As String
    Dim nodeText As String
#End Region

#Region "加载事件"

    Private Sub FrmReleaseFileManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvReleaseFile.AutoGenerateColumns = False
            '加载菜单
            LoadTree()
            GetReleaseFile(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim releaseFileMaster As New FrmReleaseFileMaster("")
            releaseFileMaster.ShowDialog()
            GetReleaseFile(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvReleaseFile.Rows.Count = 0 OrElse Me.dgvReleaseFile.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要编辑的行!", False)
                Exit Sub
            End If

            Dim strFileno As String
            strFileno = IIf(IsDBNull(Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value), "", Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value)

            If (String.IsNullOrEmpty(strFileno)) Then
                GetMesData.SetMessage(Me.lblMessage, "选择要编辑的连接ID不能为空!", False)
                Exit Sub
            End If

            Dim releaseFileMaster As New FrmReleaseFileMaster(strFileno)
            releaseFileMaster.ShowDialog()
            GetReleaseFile(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "编辑异常", False)
        End Try
    End Sub

    Private Sub btnEnable_Click(sender As Object, e As EventArgs) Handles btnEnable.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvReleaseFile.Rows.Count = 0 OrElse Me.dgvReleaseFile.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要启用的更新!", False)
            Exit Sub
        End If

        Dim strFileno As String
        strFileno = IIf(IsDBNull(Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value), "", Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value)

        If (String.IsNullOrEmpty(strFileno)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择启用更新ID失败!", False)
            Exit Sub
        End If

        If (Not CheckStatus(strFileno, "Y")) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL.AppendLine("UPDATE M_Systemfile_t SET Usey = 'Y' WHERE Fileno='" & strFileno & "' ")

            Conn.ExecSql(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行启用异常!", False)
        End Try
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvReleaseFile.Rows.Count = 0 OrElse Me.dgvReleaseFile.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要停用的更新文件!", False)
            Exit Sub
        End If

        Dim strFileno As String
        strFileno = IIf(IsDBNull(Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value), "", Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.CurrentRow.Index).Cells("Fileno").Value)

        If (String.IsNullOrEmpty(strFileno)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取选择更新文件ID失败!", False)
            Exit Sub
        End If

        If (Not CheckStatus(strFileno, "N")) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL.AppendLine("UPDATE M_Systemfile_t SET Usey = 'N' WHERE Fileno='" & strFileno & "' ")

            Conn.ExecSql(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行停用异常!", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            GetReleaseFile(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub tvReleasedVersion_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvReleasedVersion.NodeMouseClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        nodeTag = e.Node.Tag
        nodeText = e.Node.Text
        If (String.IsNullOrEmpty(e.Node.Tag)) Then
            Me.dgvReleaseFile.Rows.Clear()
            Exit Sub
        End If
        GetReleaseFile(nodeTag, nodeText)
    End Sub

#End Region

#Region "函数"

    Private Sub LoadTree()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Me.ActiveControl = Me.tvReleasedVersion
        Dim node As TreeNode = New TreeNode
        node.Tag = ""
        node.Text = "发布版本"

        Me.tvReleasedVersion.Nodes.Add(node)

        Try
            strSQL = "SELECT ReleasedVersionId, ReleasedVersionName FROM m_ReleasedVersion_t WHERE StatusFlag='Y' AND DeleteFlag='0'"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()

            If (Not dtTemp Is Nothing) Then
                For I As Int16 = 0 To dtTemp.Rows.Count - 1
                    Dim nodeChild As TreeNode = New TreeNode
                    nodeChild.Tag = dtTemp.Rows(I).Item("ReleasedVersionId").ToString
                    nodeChild.Text = dtTemp.Rows(I).Item("ReleasedVersionName").ToString
                    node.Nodes.Add(nodeChild)
                    'If (I = 0) Then
                    '    Me.tvStoreRequisition.SelectedNode = nodeChild
                    'End If
                Next
            End If
            Me.tvReleasedVersion.ExpandAll()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub GetReleaseFile(ByVal nodeTag As String, ByVal nodeText As String)
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try
            If Not (String.IsNullOrEmpty(nodeTag)) Then
                strWhere = strWhere & " AND ReleasedVersionId = '" & nodeTag & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtReleaseFileName.Text.Trim)) Then
                strWhere = strWhere & " AND Filename = '" & Me.txtReleaseFileName.Text.Trim.Replace("'", "''") & "' "
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY Fileno )as RowNum, Factory_Id, ProfitCenter_Id, ReleasedVersionId, ReleasedVersionName, Filename, FileClassSetting.PARAMETER_NAME AS Fileclass, ProgramVersion, Fileversion, " & _
               " Filetime, SystemUpdateStatusSetting.PARAMETER_NAME AS SystemUpdateStatus, MinimumVersion, UpdateTypeSetting.PARAMETER_NAME AS UpdateType, Remark, Userid, Intime, Size, Fileno, CASE Usey WHEN 'Y' THEN N'启用' ELSE N'停用' END AS Usey " & _
               " FROM M_Systemfile_t INNER JOIN m_SystemSetting_t FileClassSetting ON FileClassSetting.PARAMETER_VALUES = M_Systemfile_t.Fileclass " & _
               " INNER JOIN m_SystemSetting_t SystemUpdateStatusSetting ON SystemUpdateStatusSetting.PARAMETER_VALUES = M_Systemfile_t.SystemUpdateStatus " & _
               " INNER JOIN m_SystemSetting_t UpdateTypeSetting ON UpdateTypeSetting.PARAMETER_VALUES = M_Systemfile_t.UpdateType " & _
               " WHERE FileClassSetting.PARAMETER_CODE='FileClass' AND SystemUpdateStatusSetting.PARAMETER_CODE='SystemUpdateStatus' AND UpdateTypeSetting.PARAMETER_CODE='UpdateType' " & strWhere & " ORDER BY Usey DESC,Intime DESC"
            Me.dgvReleaseFile.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            If Not (DReader.HasRows) Then
                Me.dgvReleaseFile.Rows.Clear()
            End If

            Do While DReader.Read()
                Me.dgvReleaseFile.Rows.Add(DReader.Item("Fileno").ToString, DReader.Item("RowNum").ToString, DReader.Item("ReleasedVersionName").ToString, DReader.Item("Filename").ToString, DReader.Item("ProgramVersion").ToString, DReader.Item("Fileversion").ToString, DReader.Item("Factory_Id").ToString, DReader.Item("ProfitCenter_Id").ToString, DReader.Item("Fileclass").ToString, DReader.Item("SystemUpdateStatus").ToString, DReader.Item("UpdateType").ToString,
                                           DReader.Item("MinimumVersion").ToString, DReader.Item("Filetime").ToString, DReader.Item("Remark").ToString, DReader.Item("Userid").ToString, DReader.Item("Intime").ToString, DReader.Item("Size").ToString, DReader.Item("Usey").ToString)
                If (DReader.Item("Usey").ToString = "启用") Then
                    Me.dgvReleaseFile.Rows(Me.dgvReleaseFile.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Green
                End If
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

    Private Function CheckStatus(ByVal strFileno As String, ByVal strCheckType As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Try
            strSQL.AppendLine("SELECT Fileno FROM M_Systemfile_t WHERE Fileno='" & strFileno & "' AND Usey='" & strCheckType & "'")

            DrCheck = Conn.GetDataReader(strSQL.ToString())
            If (DrCheck.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "执行失败，选择更新已经启用或停用!", False)
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
            GetMesData.SetMessage(Me.lblMessage, "执行更新状态检查异常!", False)
        End Try
        Return rtValue
    End Function

#End Region

End Class