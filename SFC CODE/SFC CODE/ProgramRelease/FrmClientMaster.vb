
'--客户端定义
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

Public Class FrmClientMaster

#Region "变量声明"

    Dim _strClientInfoId As String
    Dim _dtClientMac As DataTable

    Public Property strClientInfoId() As String
        Get
            Return _strClientInfoId
        End Get

        Set(value As String)
            _strClientInfoId = value
        End Set
    End Property

    Public Property dtClientMac() As DataTable
        Get
            If (_dtClientMac Is Nothing) Then
                _dtClientMac = New DataTable()
                Dim dc As DataColumn
                'dc = _dtClientMac.Columns.Add("RowNumId", Type.GetType("System.Int32"))
                'dc.AutoIncrement = True
                'dc.AutoIncrementSeed = 1
                'dc.AutoIncrementStep = 1
                'dc.AllowDBNull = False
                _dtClientMac.Columns.Add("ClientMacId", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("ClientInfoId", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("ClientMacAddress", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("Remark", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("StatusFlag", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("CreateTime", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("UpdateUserId", Type.GetType("System.String"))
                _dtClientMac.Columns.Add("UpdateTime", Type.GetType("System.String"))
            End If
            Return _dtClientMac
        End Get

        Set(value As DataTable)
            _dtClientMac = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ClientInfoId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strClientInfoId = _ClientInfoId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmClientMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvClientMac.AutoGenerateColumns = False
            LoadControlData()
            Me.TabControlClient.SelectedIndex = 0
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

                If (String.IsNullOrEmpty(strClientInfoId)) Then
                    strSQL.AppendLine(" INSERT INTO m_ClientInfo_t(ClientName, AdministratorName, FactoryId, FactoryName, ProfitCenterId, ProfitCenterName, DeptId, LineId, ReleasedVersionId, ReleasedVersionName, ")
                    strSQL.AppendLine(" Remark, StatusFlag, DeleteFlag, CreateUserId, CreateTime) VALUES ( ")
                    strSQL.AppendLine(" N'" & Me.txtClientName.Text.Trim & "', N'" & Me.txtAdministratorName.Text.Trim & "', '" & Me.cboFactory.SelectedValue.Trim & "', N'" & Me.cboFactory.Text.Trim & "', '" & Me.cboProfitCenter.SelectedValue.Trim & "', N'" & Me.cboProfitCenter.Text.Trim & "','" & Me.txtDeptId.Text.Trim & "','" & Me.txtLineId.Text.Trim & "','" & Me.cboReleasedVersion.SelectedValue.ToString.Trim & "','" & Me.cboReleasedVersion.Text.Trim & "', ")
                    strSQL.AppendLine(" N'" & Me.txtRemark.Text.Trim & "', 'N', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                Else
                    strSQL.AppendLine(" UPDATE m_ClientInfo_t SET ClientName = N'" & Me.txtClientName.Text.Trim & "', AdministratorName=N'" & Me.txtAdministratorName.Text.Trim & "', FactoryId='" & Me.cboFactory.SelectedValue.Trim & "', FactoryName=N'" & Me.cboFactory.Text.Trim & "', ProfitCenterId=N'" & Me.cboProfitCenter.SelectedValue.Trim & "', ProfitCenterName=N'" & Me.cboProfitCenter.Text.Trim & "', DeptId='" & Me.txtDeptId.Text.Trim & "', LineId='" & Me.txtLineId.Text.Trim & "', ReleasedVersionId='" & Me.cboReleasedVersion.SelectedValue.ToString.Trim & "', ReleasedVersionName=N'" & Me.cboReleasedVersion.Text.Trim & "', ")
                    strSQL.AppendLine(" Remark=N'" & Me.txtRemark.Text.Trim & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() ")
                    strSQL.AppendLine(" WHERE ClientInfoId = '" & strClientInfoId & "'")
                End If

                Dim strClientMacId As String
                Dim strClientMacAddress As String
                Dim strClientRemark As String
                strSQL.AppendLine(" DECLARE @ClientInfoId VARCHAR(32) SELECT @ClientInfoId = ClientInfoId FROM m_ClientInfo_t WHERE ClientName = N'" & Me.txtClientName.Text.Trim & "' ")
                For i As Int16 = 0 To Me.dgvClientMac.RowCount - 1
                    strClientMacId = IIf(IsDBNull(Me.dgvClientMac.Rows(i).Cells("ClientMacId").Value), "", Me.dgvClientMac.Rows(i).Cells("ClientMacId").Value)
                    strClientMacAddress = IIf(IsDBNull(Me.dgvClientMac.Rows(i).Cells("ClientMacAddress").Value), "", Me.dgvClientMac.Rows(i).Cells("ClientMacAddress").Value)
                    strClientRemark = IIf(IsDBNull(Me.dgvClientMac.Rows(i).Cells("Remark").Value), "", Me.dgvClientMac.Rows(i).Cells("Remark").Value)
                    If (String.IsNullOrEmpty(strClientMacId)) Then
                        strSQL.AppendLine(" INSERT INTO m_ClientMac_t(ClientInfoId, ClientMacAddress, Remark, StatusFlag, CreateUserId, CreateTime)VALUES( ")
                        strSQL.AppendLine(" @ClientInfoId, '" & strClientMacAddress & "', N'" & strClientRemark & "', 'Y', '" & VbCommClass.VbCommClass.UseId & "', getdate())")
                    Else
                        strSQL.AppendLine(" UPDATE m_ClientMac_t SET ClientMacAddress='" & strClientMacAddress & "',Remark=N'" & strClientRemark & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE ClientMacId='" & strClientMacId & "' ")
                    End If
                Next

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

    Private Sub btnAddMac_Click(sender As Object, e As EventArgs) Handles btnAddMac.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (Not CheckClientMacColumn()) Then
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = dtClientMac.NewRow()
            drTemp("ClientMacAddress") = Me.txtClientMacAddress.Text.Trim
            drTemp("Remark") = Me.txtMarRemark.Text.Trim()
            dtClientMac.Rows.Add(drTemp)
            dtClientMac.AcceptChanges()

            Me.txtClientMacAddress.Text = String.Empty
            Me.txtMarRemark.Text = String.Empty
            GetMesData.SetMessage(Me.lblMessage, "新增电脑MAC成功!", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增电脑MAC异常!", False)
        End Try
    End Sub

    Private Sub btnDeleteMac_Click(sender As Object, e As EventArgs) Handles btnDeleteMac.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvClientMac.Rows.Count = 0 OrElse Me.dgvClientMac.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Dim strClientMacId As String
            strClientMacId = IIf(IsDBNull(Me.dgvClientMac.Rows(Me.dgvClientMac.CurrentRow.Index).Cells("ClientMacId").Value), "", Me.dgvClientMac.Rows(Me.dgvClientMac.CurrentRow.Index).Cells("ClientMacId").Value)

            If (String.IsNullOrEmpty(strClientMacId)) Then
                Me.dgvClientMac.Rows.RemoveAt(Me.dgvClientMac.CurrentRow.Index)
            Else
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Try
                    Dim strSQL As String
                    strSQL = "UPDATE m_ClientMac_t SET StatusFlag='N', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE ClientMacId='" & strClientMacId & "'"

                    Conn.ExecSql(strSQL)
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                End Try
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除条件SQL异常!", False)
        End Try
    End Sub

    Private Sub btnReadLocal_Click(sender As Object, e As EventArgs) Handles btnReadLocal.Click
        Try
            GetClientMac()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取本机MAC地址异常,请确认当前用户有管理员权限!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadControlData()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            Me.cboFactory.DisplayMember = "name"
            Me.cboFactory.ValueMember = "Factoryid"
            Me.cboFactory.DataSource = Conn.GetDataTable("select Factoryid, Shortname name from m_Dcompany_t")

            Me.cboReleasedVersion.DisplayMember = "ReleasedVersionName"
            Me.cboReleasedVersion.ValueMember = "ReleasedVersionId"
            Me.cboReleasedVersion.DataSource = GetMesData.GetReleasedVersionList("")

            If (Not String.IsNullOrEmpty(strClientInfoId)) Then

                Dim dtTemp As DataTable = GetMesData.GetClientQuery(strClientInfoId)
                If (Not dtTemp Is Nothing) Then
                    If (dtTemp.Rows.Count > 0) Then
                        Me.txtClientName.Text = dtTemp.Rows(0).Item("ClientName").ToString
                        Me.cboFactory.SelectedIndex = Me.cboFactory.FindString(dtTemp.Rows(0).Item("FactoryName").ToString)
                        Me.cboProfitCenter.SelectedIndex = Me.cboProfitCenter.FindString(dtTemp.Rows(0).Item("ProfitCenterName").ToString)

                        Me.txtDeptId.Text = dtTemp.Rows(0).Item("DeptId").ToString
                        Me.txtLineId.Text = dtTemp.Rows(0).Item("LineId").ToString
                        Me.cboReleasedVersion.SelectedIndex = Me.cboReleasedVersion.FindString(dtTemp.Rows(0).Item("ReleasedVersionName").ToString)
                        Me.txtAdministratorName.Text = dtTemp.Rows(0).Item("AdministratorName").ToString
                        Me.txtRemark.Text = dtTemp.Rows(0).Item("Remark").ToString
                        Me.txtCreateUserid.Text = dtTemp.Rows(0).Item("CreateUserId").ToString
                        Me.txtCreateTime.Text = dtTemp.Rows(0).Item("CreateTime").ToString
                    End If
                End If
                dtClientMac = GetMesData.GetClientMacQuery(strClientInfoId)
                Me.dgvClientMac.DataSource = dtClientMac
            Else
                Me.dgvClientMac.DataSource = dtClientMac
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
            If (Not String.IsNullOrEmpty(strClientInfoId)) Then

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件状态异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtClientName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入电脑名称", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboReleasedVersion.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入电脑更新版本", False)
                Return rtValue
                Exit Function
            End If

            If (Me.dgvClientMac.RowCount <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请维护电脑MAC地址", False)
                Return rtValue
                Exit Function
            End If

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim DReader As SqlClient.SqlDataReader
            Try
                DReader = Conn.GetDataReader("SELECT ClientInfoId FROM m_ClientInfo_t WHERE ClientName = '" & Me.txtClientName.Text.Trim & "' AND ClientInfoId <> '" & strClientInfoId & "' ")

                If (DReader.HasRows) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入的客户端名称已经存在", False)
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

    Private Function CheckClientMacColumn() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtClientMacAddress.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入电脑MAC地址", False)
                Return rtValue
                Exit Function
            End If

            Dim strClientMacAddress As String
            For i As Int16 = 0 To Me.dgvClientMac.RowCount - 1
                strClientMacAddress = IIf(IsDBNull(Me.dgvClientMac.Rows(i).Cells("ClientMacAddress").Value), "", Me.dgvClientMac.Rows(i).Cells("ClientMacAddress").Value)

                If (String.IsNullOrEmpty(strClientMacAddress)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "检查客户端MAC地址不能为空", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.txtClientMacAddress.Text.Trim.ToUpper = strClientMacAddress.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "电脑MAC地址已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If
            Next

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim DReader As SqlClient.SqlDataReader
            Try
                DReader = Conn.GetDataReader("SELECT ClientMacId FROM m_ClientMac_t WHERE ClientMacAddress = '" & Me.txtClientName.Text.Trim & "' AND ClientInfoId <> '" & strClientInfoId & "' ")

                If (DReader.HasRows) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入的客户端MAC已经存在", False)
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
            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "MAC地址检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Sub GetClientMac()
        Dim strLocalClientMACAddress As String = ""
        Dim ExistFlag As Boolean = False
        Try
            Dim searcher As New System.Management.ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
            Dim moc2 As System.Management.ManagementObjectCollection = searcher.Get()
            For Each mo As System.Management.ManagementObject In moc2
                If CBool(mo("IPEnabled")) Then
                    strLocalClientMACAddress = mo("MACAddress")
                    For i As Int16 = 0 To Me.dgvClientMac.RowCount - 1
                        If (strLocalClientMACAddress.ToUpper = Me.dgvClientMac.Rows(i).Cells("ClientMacAddress").Value.ToString.ToUpper) Then
                            ExistFlag = True
                            Exit For
                        End If
                    Next
                    If (Not ExistFlag) Then
                        Dim drTemp As DataRow
                        drTemp = dtClientMac.NewRow()
                        drTemp("ClientMacAddress") = strLocalClientMACAddress
                        drTemp("Remark") = ""
                        dtClientMac.Rows.Add(drTemp)
                        dtClientMac.AcceptChanges()
                    End If
                End If
            Next
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取本机MAC地址异常,请确认当前用户有管理员权限!", False)
        End Try
    End Sub

#End Region

   
End Class