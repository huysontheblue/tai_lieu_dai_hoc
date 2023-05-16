
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

Public Class FrmDataHistoryMaster

#Region "变量声明"

    Dim _strDataHistoryId As String
    Dim _dtDataColumn As DataTable
    Dim _dtWhereColumn As DataTable
    Dim _dtChildColumn As DataTable
    Dim _dtPrimaryKey As DataTable
    Dim CheckColumn As Boolean = False
    Dim _strMigrateServerType As String
    Dim _strLinkServerType As String

    Public Property strDataHistoryId() As String
        Get
            Return _strDataHistoryId
        End Get

        Set(value As String)
            _strDataHistoryId = value
        End Set
    End Property

    Public Property dtDataColumn() As DataTable
        Get
            If (_dtDataColumn Is Nothing) Then
                _dtDataColumn = New DataTable()
                Dim dc As DataColumn
                dc = _dtDataColumn.Columns.Add("RowNumId", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _dtDataColumn.Columns.Add("DataHistoryColumnId", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("DataHistoryId", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("SourceColumn", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("TargetColumn", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("DateColumnFlag", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _dtDataColumn.Columns.Add("CreateTime", Type.GetType("System.String"))
            End If
            Return _dtDataColumn
        End Get

        Set(value As DataTable)
            _dtDataColumn = value
        End Set
    End Property

    Public Property dtWhereColumn() As DataTable
        Get
            If (_dtWhereColumn Is Nothing) Then
                _dtWhereColumn = New DataTable()
                Dim dc As DataColumn
                dc = _dtWhereColumn.Columns.Add("RowNumId", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _dtWhereColumn.Columns.Add("DataHistoryWhereId", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("DataHistoryId", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("WhereColumn", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("SQLWhere", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("WhereType", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("OperatorsType", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _dtWhereColumn.Columns.Add("CreateTime", Type.GetType("System.String"))
            End If
            Return _dtWhereColumn
        End Get

        Set(value As DataTable)
            _dtWhereColumn = value
        End Set
    End Property

    Public Property dtChildColumn() As DataTable
        Get
            If (_dtChildColumn Is Nothing) Then
                _dtChildColumn = New DataTable()
                Dim dc As DataColumn
                dc = _dtChildColumn.Columns.Add("ItemNo", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _dtChildColumn.Columns.Add("DataHistoryWhereId", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("DataHistoryId", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("ChildTableName", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("ParentColumnName", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("ChildColumnName", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("WhereSQL", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("Remark", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _dtChildColumn.Columns.Add("CreateTime", Type.GetType("System.String"))
            End If
            Return _dtChildColumn
        End Get

        Set(value As DataTable)
            _dtChildColumn = value
        End Set
    End Property

    Public Property dtPrimaryKey() As DataTable
        Get
            If (_dtPrimaryKey Is Nothing) Then
                _dtPrimaryKey = New DataTable()
                Dim dc As DataColumn
                dc = _dtPrimaryKey.Columns.Add("ItemNo", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _dtPrimaryKey.Columns.Add("DataHistoryPrimaryKeyId", Type.GetType("System.String"))
                _dtPrimaryKey.Columns.Add("DataHistoryId", Type.GetType("System.String"))
                _dtPrimaryKey.Columns.Add("SourcePrimaryKeyColumn", Type.GetType("System.String"))
                _dtPrimaryKey.Columns.Add("TargetPrimaryKeyColumn", Type.GetType("System.String"))
                _dtPrimaryKey.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _dtPrimaryKey.Columns.Add("CreateTime", Type.GetType("System.String"))
            End If
            Return _dtPrimaryKey
        End Get

        Set(value As DataTable)
            _dtPrimaryKey = value
        End Set
    End Property

    Public Property strMigrateServerType() As String
        Get
            Return _strMigrateServerType
        End Get

        Set(value As String)
            _strMigrateServerType = value
        End Set
    End Property

    Public Property strLinkServerType() As String
        Get
            Return _strLinkServerType
        End Get

        Set(value As String)
            _strLinkServerType = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _DataHistoryId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strDataHistoryId = _DataHistoryId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmDataHistoryMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '待增加启用状态数据编辑检查
            Me.dgvColumn.AutoGenerateColumns = False
            Me.dgvWhere.AutoGenerateColumns = False
            Me.dgvChild.AutoGenerateColumns = False
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

#Region "源设置"

    Private Sub mtxtMigrateServer_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMigrateServer.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            strMigrateServerType = ""
            Dim linkServerQuery As New FrmLinkServerQuery(Me.mtxtMigrateServer, strMigrateServerType)
            linkServerQuery.ShowDialog()
            'Me.mtxtTargetDataBase.Text = String.Empty
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "链接服务器选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtMigrateServer_TextChanged(sender As Object, e As EventArgs) Handles mtxtMigrateServer.TextChanged
        Try
            If (Not String.IsNullOrEmpty(Me.mtxtMigrateServer.Text.Trim)) Then
                Dim dtTemp As DataTable = GetMesData.GetLinkServerQuery(Me.mtxtMigrateServer.Text.Trim, "")
                If (dtTemp.Rows.Count <= 0) Then
                    strMigrateServerType = ""
                Else
                    strMigrateServerType = dtTemp.Rows(0).Item("LinkServerType").ToString
                End If
            Else
                strMigrateServerType = "1"
            End If

            If (Not String.IsNullOrEmpty(strMigrateServerType)) Then
                Me.cboDataHistoryType.SelectedValue = strMigrateServerType
            End If

            Me.mtxtMigrateTable.Text = ""
            Me.mtxtSequenceColumn.Text = ""
            Me.dtDataColumn.Rows.Clear()
            Me.dtWhereColumn.Rows.Clear()
            Me.dtChildColumn.Rows.Clear()
            Me.dtPrimaryKey.Rows.Clear()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取源服务器类型失败!", False)
        End Try
    End Sub

    Private Sub mtxtMigrateTable_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMigrateTable.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            'If (Me.cboDataHistoryType.SelectedIndex = -1) Then
            '    GetMesData.SetMessage(Me.lblMessage, "请选择数据迁移类型!", False)
            '    Exit Sub
            'End If
            If (String.IsNullOrEmpty(Me.mtxtMigrateServer.Text.Trim)) Then
                strMigrateServerType = "1"
                Me.cboDataHistoryType.SelectedValue = strMigrateServerType
            End If
            Dim frmTable As New FrmTableQuery(Me.mtxtMigrateTable, Me.mtxtMigrateServer.Text.Trim, Me.mtxtMigrateDataBase.Text.Trim, strMigrateServerType)
            frmTable.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "迁移表选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtMigrateTable_TextChanged(sender As Object, e As EventArgs) Handles mtxtMigrateTable.TextChanged
        Try
            If (Not String.IsNullOrEmpty(Me.mtxtTargetTableName.Text.Trim) And Not String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim)) Then
                mtxtTargetTableName_TextChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "比对数据库列失败!", False)
        End Try
    End Sub

    Private Sub mtxtSequenceColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtSequenceColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                Exit Sub
            End If

            Dim sequenceColumnQuery As New FrmSequenceColumnQuery(Me.mtxtSequenceColumn, Me.mtxtMigrateServer.Text.Trim, Me.mtxtMigrateDataBase.Text.Trim, Me.strMigrateServerType, Me.mtxtMigrateTable.Text.Trim, "Y")
            sequenceColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtMigrateDataBase_TextChanged(sender As Object, e As EventArgs) Handles mtxtMigrateDataBase.TextChanged
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            Me.mtxtMigrateTable.Text = ""
            Me.dtDataColumn.Rows.Clear()
            Me.dtWhereColumn.Rows.Clear()
            Me.dtChildColumn.Rows.Clear()
            Me.dtPrimaryKey.Rows.Clear()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "源数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtMigrateDataBase_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMigrateDataBase.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateServer.Text.Trim)) Then
                strMigrateServerType = "1"
            End If
            Dim targetDataBaseQuery As New FrmTargetDataBaseQuery(Me.mtxtMigrateDataBase, Me.mtxtMigrateServer.Text.Trim, strMigrateServerType)
            targetDataBaseQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "源数据库选择异常!", False)
        End Try
    End Sub

#End Region

#Region "目标设置"

    Private Sub mtxtLinkServer_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtLinkServer.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            Dim linkServerQuery As New FrmLinkServerQuery(Me.mtxtLinkServer, "1")
            linkServerQuery.ShowDialog()
            'Me.mtxtTargetDataBase.Text = String.Empty
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "链接服务器选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtLinkServer_TextChanged(sender As Object, e As EventArgs) Handles mtxtLinkServer.TextChanged
        Try
            If (Not String.IsNullOrEmpty(Me.mtxtLinkServer.Text.Trim)) Then
                Dim dtTemp As DataTable = GetMesData.GetLinkServerQuery(Me.mtxtLinkServer.Text.Trim, "")
                If (dtTemp.Rows.Count <= 0) Then
                    strLinkServerType = ""
                Else
                    strLinkServerType = dtTemp.Rows(0).Item("LinkServerType").ToString
                End If
            Else
                strLinkServerType = "1"
            End If

            Me.mtxtTargetDataBase.Text = ""
            Me.mtxtTargetTableName.Text = ""
            Me.dtDataColumn.Rows.Clear()
            Me.dtWhereColumn.Rows.Clear()
            Me.dtChildColumn.Rows.Clear()
            Me.dtPrimaryKey.Rows.Clear()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取链接服务器类型异常!", False)
        End Try
    End Sub

    Private Sub mtxtTargetDataBase_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtTargetDataBase.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            'If (String.IsNullOrEmpty(Me.mtxtLinkServer.Text.Trim())) Then
            '    GetMesData.SetMessage(Me.lblMessage, "请先选择链接服务器", False)
            '    Exit Sub
            'End If
            If (String.IsNullOrEmpty(Me.mtxtLinkServer.Text.Trim)) Then
                strLinkServerType = "1"
            End If
            Dim targetDataBaseQuery As New FrmTargetDataBaseQuery(Me.mtxtTargetDataBase, Me.mtxtLinkServer.Text.Trim, strLinkServerType)
            targetDataBaseQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtTargetDataBase_TextChanged(sender As Object, e As EventArgs) Handles mtxtTargetDataBase.TextChanged
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            Me.mtxtTargetTableName.Text = ""
            Me.dtDataColumn.Rows.Clear()
            Me.dtWhereColumn.Rows.Clear()
            Me.dtChildColumn.Rows.Clear()
            Me.dtPrimaryKey.Rows.Clear()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtTargetTableName_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtTargetTableName.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtTargetDataBase.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择目标数据库!", False)
                Exit Sub
            End If
            If (String.IsNullOrEmpty(Me.mtxtLinkServer.Text.Trim)) Then
                strLinkServerType = "1"
            End If
            Dim frmTable As New FrmTableQuery(Me.mtxtTargetTableName, Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, strLinkServerType)
            frmTable.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtTargetTableName_TextChanged(sender As Object, e As EventArgs) Handles mtxtTargetTableName.TextChanged
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim)) Then
                Exit Sub
            End If

            If (String.IsNullOrEmpty(strLinkServerType)) Then
                If (String.IsNullOrEmpty(Me.mtxtLinkServer.Text)) Then
                    strLinkServerType = "1"
                End If
            End If

            If (String.IsNullOrEmpty(strMigrateServerType)) Then
                If (String.IsNullOrEmpty(Me.mtxtMigrateServer.Text)) Then
                    strMigrateServerType = "1"
                End If
            End If

            If (strLinkServerType = "1") Then

                Dim dtTableIdentity As DataTable
                dtTableIdentity = GetMesData.GetCheckTableIdentity(Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, Me.mtxtTargetTableName.Text.Trim)
                If (dtTableIdentity Is Nothing) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取源迁移表自增列信息失败，请确认网络连接", False)
                    Me.mtxtTargetTableName.Text = ""
                    Exit Sub
                Else
                    If (dtTableIdentity.Rows.Count > 0) Then
                        Dim strIdentityColumn As String = ""
                        For i As Int16 = 0 To dtTableIdentity.Rows.Count - 1
                            strIdentityColumn = strIdentityColumn + dtTableIdentity.Rows(i).Item(0).ToString + "/"
                        Next

                        GetMesData.SetMessage(Me.lblMessage, "目标迁移表存在自增列" + strIdentityColumn + ",请调整", False)
                        Me.mtxtTargetTableName.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            If (Not Me.chkColumnType.Checked) Then
                If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim)) Then
                    Exit Sub
                End If

                Dim dtTableColumn As DataTable
                Dim dtTargetTableColumn As DataTable

                dtTableColumn = GetMesData.GetColumnQuery(Me.mtxtMigrateServer.Text.Trim, Me.mtxtMigrateDataBase.Text.Trim, Me.mtxtMigrateTable.Text.Trim, strMigrateServerType)
                dtTargetTableColumn = GetMesData.GetColumnQuery(Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, Me.mtxtTargetTableName.Text.Trim, strLinkServerType)

                If (dtTableColumn Is Nothing) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取源迁移表列失败，请确认网络连接", False)
                    Me.mtxtTargetTableName.Text = ""
                    Exit Sub
                Else
                    If (dtTableColumn.Rows.Count = 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "获取源迁移表列失败，请确认网络连接", False)
                        Me.mtxtTargetTableName.Text = ""
                        Exit Sub
                    End If
                End If

                If (dtTargetTableColumn Is Nothing) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取目标表列失败,请确认链接服务器是否正常!", False)
                    Me.mtxtTargetTableName.Text = ""
                    Exit Sub
                End If

                If (dtTableColumn.Rows.Count <> dtTargetTableColumn.Rows.Count) Then
                    GetMesData.SetMessage(Me.lblMessage, "源表与目标列不一致", False)
                    Me.mtxtTargetTableName.Text = ""
                    Exit Sub
                End If

                Dim strColumnName As String
                Dim strColumnType As String
                Dim strTypeLenght As String
                Dim bCheck As Boolean = False

                For i As Int16 = 0 To dtTableColumn.Rows.Count - 1
                    bCheck = False
                    strColumnName = dtTableColumn.Rows(i).Item("COLUMNNAME").ToString
                    strColumnType = dtTableColumn.Rows(i).Item("TYPENAME").ToString
                    strTypeLenght = dtTableColumn.Rows(i).Item("TYPELENGTH").ToString
                    For j As Int16 = 0 To dtTargetTableColumn.Rows.Count - 1
                        If (strColumnName.ToUpper = dtTargetTableColumn.Rows(j).Item("COLUMNNAME").ToString.ToUpper) Then
                            bCheck = True
                        End If
                    Next
                    If (bCheck = False) Then
                        GetMesData.SetMessage(Me.lblMessage, "列[" & strColumnName & "]在目标表中不存在!", False)
                        Me.mtxtTargetTableName.Text = ""
                        Exit Sub
                    End If
                Next
                CheckColumn = True
            Else
                CheckColumn = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "表列检查异常,请确认链接服务器是否正常!", False)
            Me.mtxtTargetTableName.Text = ""
        End Try
    End Sub

#End Region

#Region "列对应关系"

    Private Sub mtxtSourceColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtSourceColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtSourceColumn, Me.mtxtMigrateServer.Text.Trim, Me.mtxtMigrateDataBase.Text.Trim, Me.mtxtMigrateTable.Text.Trim(), strMigrateServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtTargetColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtTargetColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtTargetTableName.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择目标表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtTargetColumn, Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, Me.mtxtTargetTableName.Text.Trim(), strLinkServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标栏位选择异常!", False)
        End Try
    End Sub

    Private Sub btnAddColumn_Click(sender As Object, e As EventArgs) Handles btnAddColumn.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (Not CheckAddColumn()) Then
                Me.mtxtSourceColumn.Text = ""
                Me.mtxtTargetColumn.Text = ""
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = dtDataColumn.NewRow()
            drTemp("SourceColumn") = Me.mtxtSourceColumn.Text.Trim
            drTemp("TargetColumn") = Me.mtxtTargetColumn.Text.Trim
            drTemp("DateColumnFlag") = IIf(Me.chkDateColumnFlag.Checked, "Y", "N")
            dtDataColumn.Rows.Add(drTemp)
            dtDataColumn.AcceptChanges()

            Me.mtxtSourceColumn.Text = String.Empty
            Me.mtxtTargetColumn.Text = String.Empty
            GetMesData.SetMessage(Me.lblMessage, "新增列关系成功!", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增列关系异常!", False)
        End Try
    End Sub

    Private Sub btnDeleteColumn_Click(sender As Object, e As EventArgs) Handles btnDeleteColumn.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvColumn.Rows.Count = 0 OrElse Me.dgvColumn.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Dim strDataHistoryColumnId As String
            strDataHistoryColumnId = IIf(IsDBNull(Me.dgvColumn.Rows(Me.dgvColumn.CurrentRow.Index).Cells("DataHistoryColumnId").Value), "", Me.dgvColumn.Rows(Me.dgvColumn.CurrentRow.Index).Cells("DataHistoryColumnId").Value)

            If (String.IsNullOrEmpty(strDataHistoryColumnId)) Then
                Me.dgvColumn.Rows.RemoveAt(Me.dgvColumn.CurrentRow.Index)
            Else

                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Try

                    Dim strSQL As String

                    strSQL = "UPDATE m_DataHistoryColumn_t SET DeleteFlag='1', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE DataHistoryColumnId='" & strDataHistoryColumnId & "'"

                    Conn.ExecSql(strSQL)
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                End Try
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除列关系异常!", False)
        End Try
    End Sub

#End Region

#Region "目标条件设置"

    Private Sub mtxtWhereColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtWhereColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtWhereColumn, "", "", Me.mtxtMigrateTable.Text.Trim(), strLinkServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "条件栏位选择异常!", False)
        End Try
    End Sub

    Private Sub btnAddWhere_Click(sender As Object, e As EventArgs) Handles btnAddWhere.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (Not CheckWhereColumn()) Then
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = dtWhereColumn.NewRow()
            drTemp("WhereColumn") = Me.mtxtWhereColumn.Text.Trim
            drTemp("SQLWhere") = Me.txtWhereSQL.Text.Trim()
            drTemp("WhereType") = Me.cboWhereType.SelectedValue.ToString
            drTemp("OperatorsType") = Me.cboOperatorsType.SelectedValue.ToString
            dtWhereColumn.Rows.Add(drTemp)
            dtWhereColumn.AcceptChanges()

            Me.mtxtWhereColumn.Text = String.Empty
            Me.txtWhereSQL.Text = String.Empty
            GetMesData.SetMessage(Me.lblMessage, "新增条件列成功!", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增条件SQL异常!", False)
        End Try
    End Sub

    Private Sub btnDeleteWhere_Click(sender As Object, e As EventArgs) Handles btnDeleteWhere.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvWhere.Rows.Count = 0 OrElse Me.dgvWhere.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Dim strDataHistoryWhereId As String
            strDataHistoryWhereId = IIf(IsDBNull(Me.dgvWhere.Rows(Me.dgvWhere.CurrentRow.Index).Cells("DataHistoryWhereId").Value), "", Me.dgvWhere.Rows(Me.dgvWhere.CurrentRow.Index).Cells("DataHistoryWhereId").Value)

            If (String.IsNullOrEmpty(strDataHistoryWhereId)) Then
                Me.dgvWhere.Rows.RemoveAt(Me.dgvWhere.CurrentRow.Index)
            Else
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Try

                    Dim strSQL As String

                    strSQL = "UPDATE m_DataHistoryWhere_t SET DeleteFlag='1', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE DataHistoryWhereId='" & strDataHistoryWhereId & "'"

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

#End Region

#Region "摘要"

    Private Sub itxtProcessingNumber_ValueChanged(sender As Object, e As EventArgs) Handles itxtProcessingNumber.ValueChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub itxtExecutionInterval_ValueChanged(sender As Object, e As EventArgs) Handles itxtExecutionInterval.ValueChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub itxtIntervalFrequency_ValueChanged(sender As Object, e As EventArgs) Handles itxtIntervalFrequency.ValueChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub cboIntervalType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboIntervalType.SelectionChangeCommitted
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub dtStartTime_TextChanged(sender As Object, e As EventArgs) Handles dtStartTime.TextChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub itxtRetentionDays_ValueChanged(sender As Object, e As EventArgs) Handles itxtRetentionDays.ValueChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

    Private Sub dtEndTime_TextChanged(sender As Object, e As EventArgs) Handles dtEndTime.TextChanged
        Try
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新摘要异常!", False)
        End Try
    End Sub

#End Region

#Region "子表关系"

    Private Sub mtxtChildTableName_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtChildTableName.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtTargetDataBase.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择目标数据库!", False)
                Exit Sub
            End If
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                Exit Sub
            End If
            Dim frmTable As New FrmTableQuery(Me.mtxtChildTableName, Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, strLinkServerType)
            frmTable.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtParentColumnName_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtParentColumnName.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtParentColumnName, "", "", Me.mtxtMigrateTable.Text.Trim(), strMigrateServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub mtxtChildColumnName_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtChildColumnName.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtChildTableName.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择子表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtChildColumnName, "", "", Me.mtxtChildTableName.Text.Trim(), strMigrateServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
        End Try
    End Sub

    Private Sub btnChildAdd_Click(sender As Object, e As EventArgs) Handles btnChildAdd.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (Not CheckChlid()) Then
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = dtChildColumn.NewRow()
            drTemp("ChildTableName") = Me.mtxtChildTableName.Text.Trim
            drTemp("ParentColumnName") = Me.mtxtParentColumnName.Text.Trim
            drTemp("ChildColumnName") = Me.mtxtChildColumnName.Text.Trim
            drTemp("WhereSQL") = Me.txtChildWhereSQL.Text.Trim
            drTemp("Remark") = Me.txtChildRemark.Text.Trim
            dtChildColumn.Rows.Add(drTemp)
            dtChildColumn.AcceptChanges()

            Me.mtxtWhereColumn.Text = String.Empty
            Me.txtWhereSQL.Text = String.Empty
            GetMesData.SetMessage(Me.lblMessage, "新增子表关系成功!", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增子表关系异常!", False)
        End Try
    End Sub

    Private Sub btnChildDelete_Click(sender As Object, e As EventArgs) Handles btnChildDelete.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvChild.Rows.Count = 0 OrElse Me.dgvChild.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Dim strDataHistoryChildId As String
            strDataHistoryChildId = IIf(IsDBNull(Me.dgvChild.Rows(Me.dgvChild.CurrentRow.Index).Cells("DataHistoryChildId").Value), "", Me.dgvWhere.Rows(Me.dgvWhere.CurrentRow.Index).Cells("DataHistoryChildId").Value)

            If (String.IsNullOrEmpty(strDataHistoryChildId)) Then
                Me.dgvChild.Rows.RemoveAt(Me.dgvChild.CurrentRow.Index)
            Else
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Try

                    Dim strSQL As String

                    strSQL = "UPDATE m_DataHistoryChild_t SET DeleteFlag='1', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE DataHistoryChildId='" & strDataHistoryChildId & "'"

                    Conn.ExecSql(strSQL)
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                End Try
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除子表关系异常!", False)
        End Try
    End Sub

#End Region

#Region "主键关系"

    Private Sub btnPrimaryKeyAdd_Click(sender As Object, e As EventArgs) Handles btnPrimaryKeyAdd.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (Not CheckPrimaryKeyColumn()) Then
                Me.mtxtSourcePrimaryKeyColumn.Text = ""
                Me.mtxtTargetPrimaryKeyColumn.Text = ""
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = dtPrimaryKey.NewRow()
            drTemp("SourcePrimaryKeyColumn") = Me.mtxtSourcePrimaryKeyColumn.Text.Trim
            drTemp("TargetPrimaryKeyColumn") = Me.mtxtTargetPrimaryKeyColumn.Text.Trim
            dtPrimaryKey.Rows.Add(drTemp)
            dtPrimaryKey.AcceptChanges()

            Me.mtxtSourcePrimaryKeyColumn.Text = String.Empty
            Me.mtxtTargetPrimaryKeyColumn.Text = String.Empty
            GetMesData.SetMessage(Me.lblMessage, "新增主键关系成功!", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增主键关系异常", False)
        End Try
    End Sub

    Private Sub btnPrimaryKeyDelete_Click(sender As Object, e As EventArgs) Handles btnPrimaryKeyDelete.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvPrimaryKey.Rows.Count = 0 OrElse Me.dgvPrimaryKey.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Dim strDataHistoryPrimaryKeyId As String
            strDataHistoryPrimaryKeyId = IIf(IsDBNull(Me.dgvPrimaryKey.Rows(Me.dgvPrimaryKey.CurrentRow.Index).Cells("DataHistoryPrimaryKeyId").Value), "", Me.dgvPrimaryKey.Rows(Me.dgvPrimaryKey.CurrentRow.Index).Cells("DataHistoryPrimaryKeyId").Value)

            If (String.IsNullOrEmpty(strDataHistoryPrimaryKeyId)) Then
                Me.dgvPrimaryKey.Rows.RemoveAt(Me.dgvPrimaryKey.CurrentRow.Index)
            Else

                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Try

                    Dim strSQL As String

                    strSQL = "UPDATE m_DataHistoryPrimaryKey_t SET DeleteFlag='1', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=GETDATE() WHERE DataHistoryPrimaryKeyId='" & strDataHistoryPrimaryKeyId & "'"

                    Conn.ExecSql(strSQL)
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                End Try
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除主键关系异常", False)
        End Try
    End Sub

    Private Sub mtxtSourcePrimaryKeyColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtSourcePrimaryKeyColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            GetMesData.SetMessage(Me.lblMessage, "", False)
            Try
                If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "请先选择迁移表!", False)
                    Exit Sub
                End If

                Dim ColumnQuery As New FrmColumnQuery(Me.mtxtSourcePrimaryKeyColumn, Me.mtxtMigrateServer.Text.Trim, Me.mtxtMigrateDataBase.Text.Trim, Me.mtxtMigrateTable.Text.Trim, strMigrateServerType)
                ColumnQuery.ShowDialog()
            Catch ex As Exception
                GetMesData.SetMessage(Me.lblMessage, "目标数据库选择异常!", False)
            End Try
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择源主键列异常", False)
        End Try
    End Sub

    Private Sub mtxtTargetPrimaryKeyColumn_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtTargetPrimaryKeyColumn.ButtonCustomClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.mtxtTargetTableName.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "请先选择目标表!", False)
                Exit Sub
            End If

            Dim ColumnQuery As New FrmColumnQuery(Me.mtxtTargetPrimaryKeyColumn, Me.mtxtLinkServer.Text.Trim, Me.mtxtTargetDataBase.Text.Trim, Me.mtxtTargetTableName.Text.Trim(), strLinkServerType)
            ColumnQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择目标主键列异常", False)
        End Try
    End Sub

#End Region

#Region "其他"

    Private Sub cboDataHistoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDataHistoryType.SelectedIndexChanged
        Try
            'If (Me.cboDataHistoryType.SelectedIndex = -1) Then
            '    Me.btnPrimaryKeyAdd.Enabled = False
            '    Me.btnPrimaryKeyDelete.Enabled = False
            '    Me.mtxtSourcePrimaryKeyColumn.ButtonCustom.Enabled = False
            '    Me.mtxtTargetPrimaryKeyColumn.ButtonCustom.Enabled = False
            'Else
            '    If (Me.cboDataHistoryType.SelectedValue = "0") Then
            '        Me.btnPrimaryKeyAdd.Enabled = True
            '        Me.btnPrimaryKeyDelete.Enabled = True
            '        Me.mtxtSourcePrimaryKeyColumn.ButtonCustom.Enabled = True
            '        Me.mtxtTargetPrimaryKeyColumn.ButtonCustom.Enabled = True
            '    Else
            '        Me.btnPrimaryKeyAdd.Enabled = False
            '        Me.btnPrimaryKeyDelete.Enabled = False
            '        Me.mtxtSourcePrimaryKeyColumn.ButtonCustom.Enabled = False
            '        Me.mtxtTargetPrimaryKeyColumn.ButtonCustom.Enabled = False
            '    End If
            'End If
            If (Not dtPrimaryKey Is Nothing) Then
                Me.dtPrimaryKey.Rows.Clear()
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改数据迁移类型失败!", False)
        End Try
    End Sub

    Private Sub rBtnDate_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnEndDate.CheckedChanged, rBtnNoEndDate.CheckedChanged
        Try
            If (Me.rBtnEndDate.Checked) Then
                Me.dtEndTime.Text = DateTime.Now
                Me.dtEndTime.Enabled = True
            Else
                Me.dtEndTime.Enabled = False
                Me.dtEndTime.Text = String.Empty
            End If
            SummaryString()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新选项异常", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Me.btnSave.Enabled = False
        Try
            If Not (CheckSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim strTemp As New StringBuilder
            Dim strColumn As String = ""
            Dim strSelectColumn As String = ""
            Dim strDateColumnFlag As String = ""
            Dim strColumnTemp As String = ""
            Dim strUpdateColumnSQL As String = ""
            Dim strPrimaryKeyColumnSQL As String = ""
            Dim strNOPrimaryKeyColumnSQL As String = ""
            Dim strTargetColumn As String = ""
            Dim strTargetColumnTemp As String = ""
            Dim strWhere As String = ""
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Dim strEndDate As String
            Dim strChildTableFlag As String
            Try
                If (Me.dgvChild.RowCount > 0) Then
                    strChildTableFlag = "1"
                Else
                    strChildTableFlag = "0"
                End If

                If (String.IsNullOrEmpty(strDataHistoryId)) Then
                    '生成列对应关系
                    For i As Int16 = 0 To Me.dgvColumn.Rows.Count - 1
                        strColumnTemp = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        strTargetColumnTemp = Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                        strDateColumnFlag = Me.dgvColumn.Rows(i).Cells("DateColumnFlag").Value.ToString
                        If (i = 0) Then
                            strColumn = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            strTargetColumn = Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                            If (strDateColumnFlag.ToUpper = "N".ToUpper) Then
                                strSelectColumn = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            Else
                                strSelectColumn = "CASE WHEN " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " < TO_DATE(''1753-01-01'', ''YYYY-MM-DD'') THEN TO_DATE(''1753-01-01'',''YYYY-MM-DD'') ELSE " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " END " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            End If
                            strUpdateColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        Else
                            strColumn = strColumn + ", " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            strTargetColumn = strTargetColumn + ", " + Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                            If (strDateColumnFlag.ToUpper = "N".ToUpper) Then
                                strSelectColumn = strSelectColumn + ", " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            Else
                                strSelectColumn = strSelectColumn + ", " + "CASE WHEN " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " < TO_DATE(''''1753-01-01'''', ''''YYYY-MM-DD'''') THEN TO_DATE(''''1753-01-01'''',''''YYYY-MM-DD'''') ELSE " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " END " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            End If
                            strUpdateColumnSQL = strUpdateColumnSQL + "," + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        End If
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryColumn_t( DataHistoryId, SourceColumn, TargetColumn, DateColumnFlag, CreateUserId, CreateTime, DeleteFlag)VALUES(")
                        strTemp.AppendLine(" @DataHistoryId, '" & strColumnTemp & "', '" & strTargetColumnTemp & "', '" + strDateColumnFlag + "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    If (String.IsNullOrEmpty(strSelectColumn)) Then
                        strSelectColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strColumn)) Then
                        strColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strTargetColumn)) Then
                        strTargetColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strUpdateColumnSQL)) Then
                        strUpdateColumnSQL = " * "
                    End If

                    '生成主键列关系
                    For i As Int16 = 0 To Me.dgvPrimaryKey.Rows.Count - 1
                        If (i = 0) Then
                            strPrimaryKeyColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                            strNOPrimaryKeyColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "<>" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                        Else
                            strPrimaryKeyColumnSQL = strPrimaryKeyColumnSQL + " AND " + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                            strNOPrimaryKeyColumnSQL = strNOPrimaryKeyColumnSQL + " AND " + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "<>" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                        End If
                    Next

                    '生成条件
                    For i As Int16 = 0 To Me.dgvWhere.Rows.Count - 1
                        strWhere = strWhere + " " + Me.dgvWhere.Rows(i).Cells("WhereType").Value.ToString + " " + Me.dgvWhere.Rows(i).Cells("WhereColumn").Value.ToString + " " & Me.dgvWhere.Rows(i).Cells("OperatorsType").Value.ToString & " " + Me.dgvWhere.Rows(i).Cells("SQLWhere").Value.ToString.Replace("'", "''")
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryWhere_t( DataHistoryId, WhereColumn, SQLWhere, WhereType, OperatorsType, CreateUserId, CreateTime, DeleteFlag) VALUES(")
                        strTemp.AppendLine(" @DataHistoryId, '" & Me.dgvWhere.Rows(i).Cells("WhereColumn").Value.ToString & "', N'" & Me.dgvWhere.Rows(i).Cells("SQLWhere").Value.ToString.Replace("'", "''") & "', '" & Me.dgvWhere.Rows(i).Cells("WhereType").Value.ToString & "', '" & Me.dgvWhere.Rows(i).Cells("OperatorsType").Value.ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    '子表关系
                    For i As Int16 = 0 To Me.dgvChild.Rows.Count - 1
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryChild_t( DataHistoryId, ItemNo, ChildTableName, ParentColumnName, ChildColumnName, WhereSQL, Remark, DeleteFlag, CreateUserId, CreateTime) VALUES(")
                        strTemp.AppendLine(" @DataHistoryId, '" & Me.dgvChild.Rows(i).Cells("ItemNo").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ChildTableName").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ParentColumnName").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ChildColumnName").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("WhereSQL").Value.ToString & "', N'" & Me.dgvChild.Rows(i).Cells("Remark").Value.ToString & "', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
                    Next

                    '主键关系
                    For i As Int16 = 0 To Me.dgvPrimaryKey.Rows.Count - 1
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryPrimaryKey_t( DataHistoryId, SourcePrimaryKeyColumn, TargetPrimaryKeyColumn, CreateUserId, CreateTime, DeleteFlag) VALUES(")
                        strTemp.AppendLine(" @DataHistoryId, '" & Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString & "', '" & Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    'Me.dtStartTime.Text.Trim.Replace("/", "") 
                    strSQL.AppendLine(" DECLARE @DATABASE NVARCHAR(32), @DataHistoryId FLOAT SET @DATABASE = DB_NAME() ")

                    strSQL.AppendLine(" INSERT INTO m_DataHistory_t(ExecuteType, DataHistoryType, MigrateServerName, MigrateDataBaseName, DataHistoryTableName, SourceDatabase, LinkServerName, TargetDataBaseName, TargetTableName, TreatmentFlag, SequenceColumn, SequenceType, ProcessingNumber, ColumnType, ")
                    strSQL.AppendLine(" ExecutionInterval, IntervalFrequency, IntervalType, StartTime, EndTime, RetentionDays, ColumnSelectSQL, ColumnSQL, TargetColumnSQL, WhereSQL, UpdateColumnSQL, PrimaryKeyColumnSQL, NOPrimaryKeyColumnSQL, ExecIncrementalTime, IncrementalType, MigrateDataDelete, Remark, StatusFlag, DeleteFlag, CreateUserId, CreateTime, ChildTableFlag, ExecEndTime, MigrateServerConfigName, TargetServerConfigName)VALUES(")
                    strSQL.AppendLine(" '" & Me.cboExecuteType.SelectedValue & "', '" & Me.cboDataHistoryType.SelectedValue & "', '" & Me.mtxtMigrateServer.Text.Trim & "', '" & Me.mtxtMigrateDataBase.Text.Trim & "', '" & Me.mtxtMigrateTable.Text.Trim & "', @DATABASE, '" & Me.mtxtLinkServer.Text.Trim.Trim & "', '" & Me.mtxtTargetDataBase.Text.Trim & "', '" & Me.mtxtTargetTableName.Text.Trim & "', '" & Me.cboTreatment.SelectedValue.ToString & "', '" & Me.mtxtSequenceColumn.Text.Trim & "', '" & Me.cboSequenceType.SelectedValue & "', '" & Me.itxtProcessingNumber.Text.Trim & "', '" & IIf(Me.chkColumnType.Checked, "1", "0") & "', ")
                    strSQL.AppendLine(" '" & Me.itxtExecutionInterval.Text.Trim & "', '" & Me.itxtIntervalFrequency.Text.Trim & "', '" & Me.cboIntervalType.SelectedValue & "', '" & Me.dtStartTime.Text.Trim & "', '" & Me.dtEndTime.Text.Trim & "', '" & Me.itxtRetentionDays.Text.Trim & "', '" & strSelectColumn & "', '" & strColumn & "', '" & strTargetColumn & "', N'" & strWhere & "', N'" & strUpdateColumnSQL & "', N'" & strPrimaryKeyColumnSQL & "', N'" & strNOPrimaryKeyColumnSQL & "', '" & Me.itxtExecIncrementalTime.Text.Trim & "', '" & Me.cboIncrementalType.SelectedValue.ToString & "', N'" & Me.cboMigrateDataDelete.SelectedValue.ToString & "', N'" & Me.txtRewark.Text.Trim.Replace("'", "''") & "', 'N', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '" & strChildTableFlag & "', '" & Me.dtpExecEndTime.Text.Trim & "', '" & Me.cboServerConfigName.Text.Trim & "', '" & Me.cboTargetServerConfigName.Text.Trim & "') ")
                    If (strTemp.Length > 0) Then
                        strSQL.AppendLine(" SELECT @DataHistoryId = DataHistoryId FROM m_DataHistory_t WHERE DataHistoryTableName='" & Me.mtxtMigrateTable.Text.Trim & "' AND LinkServerName='" & Me.mtxtLinkServer.Text.Trim.Trim & "' AND TargetDataBaseName='" & Me.mtxtTargetDataBase.Text.Trim & "' AND TargetTableName='" & Me.mtxtTargetTableName.Text.Trim & "' ")
                    End If
                    strSQL.AppendLine(strTemp.ToString)
                Else
                    '清除原有数据
                    strSQL.AppendLine(" UPDATE m_DataHistoryColumn_t SET DeleteFlag='1' WHERE DataHistoryId='" & strDataHistoryId & "'")
                    strSQL.AppendLine(" UPDATE m_DataHistoryWhere_t SET DeleteFlag='1' WHERE DataHistoryId='" & strDataHistoryId & "'")
                    strSQL.AppendLine(" UPDATE m_DataHistoryChild_t SET DeleteFlag='1' WHERE DataHistoryId='" & strDataHistoryId & "'")
                    strSQL.AppendLine(" UPDATE m_DataHistoryPrimaryKey_t SET DeleteFlag='1' WHERE DataHistoryId='" & strDataHistoryId & "'")

                    '生成列对应关系
                    For i As Int16 = 0 To Me.dgvColumn.Rows.Count - 1
                        strColumnTemp = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        strTargetColumnTemp = Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                        strDateColumnFlag = Me.dgvColumn.Rows(i).Cells("DateColumnFlag").Value.ToString
                        If (i = 0) Then
                            strColumn = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            strTargetColumn = Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                            If (strDateColumnFlag.ToUpper = "N".ToUpper) Then
                                strSelectColumn = Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            Else
                                strSelectColumn = "CASE WHEN " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " < TO_DATE(''1753-01-01'', ''YYYY-MM-DD'') THEN TO_DATE(''1753-01-01'',''YYYY-MM-DD'') ELSE " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " END " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            End If
                            strUpdateColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "_TEMP." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        Else
                            strColumn = strColumn + ", " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            strTargetColumn = strTargetColumn + ", " + Me.dgvColumn.Rows(i).Cells("TargetColumn").Value.ToString
                            If (strDateColumnFlag.ToUpper = "N".ToUpper) Then
                                strSelectColumn = strSelectColumn + ", " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            Else
                                strSelectColumn = strSelectColumn + ", " + "CASE WHEN " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " < TO_DATE(''1753-01-01'', ''YYYY-MM-DD'') THEN TO_DATE(''1753-01-01'',''YYYY-MM-DD'') ELSE " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + " END " + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                            End If
                            strUpdateColumnSQL = strUpdateColumnSQL + "," + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "_TEMP." + Me.dgvColumn.Rows(i).Cells("SourceColumn").Value.ToString
                        End If
                        strSQL.AppendLine(" INSERT INTO m_DataHistoryColumn_t( DataHistoryId, SourceColumn, TargetColumn, DateColumnFlag, CreateUserId, CreateTime, DeleteFlag)VALUES(")
                        strSQL.AppendLine(" '" & strDataHistoryId & "', '" & strColumnTemp & "', '" & strTargetColumnTemp & "', '" & strDateColumnFlag & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    If (String.IsNullOrEmpty(strSelectColumn)) Then
                        strSelectColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strColumn)) Then
                        strColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strTargetColumn)) Then
                        strTargetColumn = " * "
                    End If

                    If (String.IsNullOrEmpty(strUpdateColumnSQL)) Then
                        strUpdateColumnSQL = " * "
                    End If

                    '生成主键列关系
                    For i As Int16 = 0 To Me.dgvPrimaryKey.Rows.Count - 1
                        If (i = 0) Then
                            strPrimaryKeyColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                            strNOPrimaryKeyColumnSQL = Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "<>" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                        Else
                            strPrimaryKeyColumnSQL = strPrimaryKeyColumnSQL + " AND " + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "=" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                            strNOPrimaryKeyColumnSQL = strNOPrimaryKeyColumnSQL + " AND " + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtTargetTableName.Text.Trim + "." + Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString + "<>" + Me.mtxtTargetDataBase.Text.Trim + ".dbo." + Me.mtxtMigrateTable.Text.Trim + "_TEMP." + Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString
                        End If
                    Next

                    '生成条件
                    For i As Int16 = 0 To Me.dgvWhere.Rows.Count - 1
                        strWhere = strWhere + " " + Me.dgvWhere.Rows(i).Cells("WhereType").Value.ToString + " " + Me.dgvWhere.Rows(i).Cells("WhereColumn").Value.ToString + " = " + Me.dgvWhere.Rows(i).Cells("SQLWhere").Value.ToString.Replace("'", "''")
                        strSQL.AppendLine(" INSERT INTO m_DataHistoryWhere_t( DataHistoryId, WhereColumn, SQLWhere, WhereType, OperatorsType, CreateUserId, CreateTime, DeleteFlag) VALUES(")
                        strSQL.AppendLine(" '" & strDataHistoryId & "', '" & Me.dgvWhere.Rows(i).Cells("WhereColumn").Value.ToString & "', N'" & Me.dgvWhere.Rows(i).Cells("SQLWhere").Value.ToString.Replace("'", "''") & "', '" & Me.dgvWhere.Rows(i).Cells("WhereType").Value.ToString & "', '" & Me.dgvWhere.Rows(i).Cells("OperatorsType").Value.ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    '子表关系
                    For i As Int16 = 0 To Me.dgvChild.Rows.Count - 1
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryChild_t( DataHistoryId, ItemNo, ChildTableName, ParentColumnName, ChildColumnName, WhereSQL, Remark, DeleteFlag, CreateUserId, CreateTime) VALUES(")
                        strTemp.AppendLine(" '" & strDataHistoryId & "', '" & Me.dgvChild.Rows(i).Cells("ItemNo").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ChildTableName").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ParentColumnName").Value.ToString & "', '" & Me.dgvChild.Rows(i).Cells("ChildColumnName").Value.ToString & "', N'" & Me.dgvChild.Rows(i).Cells("WhereSQL").Value.ToString.Replace("'", "''") & "', N'" & Me.dgvChild.Rows(i).Cells("Remark").Value.ToString & "', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
                    Next

                    '主键关系
                    For i As Int16 = 0 To Me.dgvPrimaryKey.Rows.Count - 1
                        strTemp.AppendLine(" INSERT INTO m_DataHistoryPrimaryKey_t( DataHistoryId, SourcePrimaryKeyColumn, TargetPrimaryKeyColumn, CreateUserId, CreateTime, DeleteFlag) VALUES(")
                        strTemp.AppendLine(" '" & strDataHistoryId & "', '" & Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value.ToString & "', '" & Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value.ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '0')")
                    Next

                    strSQL.AppendLine(" UPDATE m_DataHistory_t SET TreatmentFlag='" & Me.cboTreatment.SelectedValue & "', SequenceColumn='" & Me.mtxtSequenceColumn.Text.Trim & "', SequenceType='" & Me.cboSequenceType.SelectedValue & "', ProcessingNumber='" & Me.itxtProcessingNumber.Text.Trim & "', ColumnType='" & IIf(Me.chkColumnType.Checked, "1", "0") & "', ")
                    strSQL.AppendLine(" ExecutionInterval = '" & Me.itxtExecutionInterval.Text.Trim & "', IntervalFrequency = '" & Me.itxtIntervalFrequency.Text.Trim & "', IntervalType='" & Me.cboIntervalType.SelectedValue & "', StartTime='" & Me.dtStartTime.Text.Trim & "', EndTime='" & Me.dtEndTime.Text.Trim & "', RetentionDays='" & Me.itxtRetentionDays.Text.Trim & "', ColumnSelectSQL='" & strSelectColumn & "', ColumnSQL='" & strColumn & "', TargetColumnSQL = '" & strTargetColumn & "', WhereSQL = N'" & strWhere & "', ExecIncrementalTime='" & Me.itxtExecIncrementalTime.Text.Trim & "', IncrementalType=N'" & Me.cboIncrementalType.SelectedValue.ToString & "', Remark = N'" & Me.txtRewark.Text.Trim & "', ")
                    strSQL.AppendLine(" MigrateDataDelete = '" & Me.cboMigrateDataDelete.SelectedValue.ToString & "', UpdateColumnSQL = N'" & strUpdateColumnSQL & "', PrimaryKeyColumnSQL = N'" & strPrimaryKeyColumnSQL & "', NOPrimaryKeyColumnSQL = '" & strNOPrimaryKeyColumnSQL & "', UpdateUserId='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate(), ChildTableFlag= '" & strChildTableFlag & "', ExecEndTime='" & Me.dtpExecEndTime.Text.Trim & "', MigrateServerConfigName = '" & Me.cboServerConfigName.Text.Trim & "', TargetServerConfigName = '" & Me.cboTargetServerConfigName.Text.Trim & "' ")
                    strSQL.AppendLine(" WHERE DataHistoryId = '" & strDataHistoryId & "'")
                End If

                If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                    Conn.ExecSql(strSQL.ToString())
                End If

                If (Not String.IsNullOrEmpty(strDataHistoryId) And Me.cboExecuteType.SelectedValue = "0") Then
                    '更新Job计划
                    Dim strUpdateJob As New StringBuilder
                    strUpdateJob.Append(" DECLARE @StatusFlag VARCHAR(8), @DataHistoryId FLOAT, @JobId VARCHAR(64), @ScheduleId FLOAT, @StepId FLOAT, ")
                    strUpdateJob.Append(" @ExecutionInterval VARCHAR(32), @IntervalFrequency VARCHAR(32), @IntervalType VARCHAR(32), @StartTime INT, @EndTime INT ")
                    strUpdateJob.Append(" SET @DataHistoryId='" & strDataHistoryId & "' ")
                    strUpdateJob.Append(" SELECT @StatusFlag=StatusFlag, @JobId=JobId, @ScheduleId=ScheduleId, @StepId=StepId, @ExecutionInterval=ExecutionInterval, @IntervalFrequency=IntervalFrequency, @IntervalType=IntervalType, @StartTime=CONVERT(INT, REPLACE(StartTime, '/', '')), @EndTime=CONVERT(INT, REPLACE(EndTime, '/', '')) ")
                    strUpdateJob.Append(" FROM m_DataHistory_t WHERE DataHistoryId = @DataHistoryId ")
                    strUpdateJob.Append(" IF(ISNULL(@StatusFlag,'N')='Y') BEGIN ")
                    strUpdateJob.Append(" EXEC msdb.dbo.sp_update_schedule @schedule_id=@ScheduleId, ")
                    strUpdateJob.Append(" @freq_interval=@ExecutionInterval, @freq_subday_type=@IntervalType, @freq_subday_interval=@IntervalFrequency, ")
                    strUpdateJob.Append(" @active_start_date=@StartTime, @active_end_date=@EndTime END ")

                    Conn.ExecNOCommandSql(strUpdateJob.ToString())
                End If

                Conn.PubConnection.Close()
                Me.btnSave.Enabled = True
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
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "取消异常!", False)
        End Try
    End Sub

    Private Sub chkColumnType_CheckedChanged(sender As Object, e As EventArgs) Handles chkColumnType.CheckedChanged
        Try
            If (Me.chkColumnType.Checked) Then
                Me.mtxtSourceColumn.Enabled = True
                Me.mtxtTargetColumn.Enabled = True
                Me.btnAddColumn.Enabled = True
                Me.btnDeleteColumn.Enabled = True
                Me.chkDateColumnFlag.Enabled = True
                If (Not String.IsNullOrEmpty(Me.mtxtTargetTableName.Text.Trim) And Not String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim)) Then
                    mtxtTargetTableName_TextChanged(Nothing, Nothing)
                End If
            Else
                Me.mtxtSourceColumn.Enabled = False
                Me.mtxtTargetColumn.Enabled = False
                Me.btnAddColumn.Enabled = False
                Me.btnDeleteColumn.Enabled = False
                Me.chkDateColumnFlag.Enabled = False
                Me.dtDataColumn.Rows.Clear()
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改选择异常!", False)
        End Try
    End Sub

    Private Sub cboExecuteType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExecuteType.SelectedIndexChanged
        Try
            If (Me.cboExecuteType.SelectedValue = "1") Then
                Me.cboServerConfigName.Enabled = True
            Else
                Me.cboServerConfigName.Enabled = False
                Me.cboServerConfigName.SelectedIndex = -1
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改选择异常!", False)
        End Try
    End Sub

#End Region

#End Region

#Region "函数"

    Private Sub LoadControlData()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.cboTreatment.DisplayMember = "PARAMETER_NAME"
            Me.cboTreatment.ValueMember = "PARAMETER_VALUES"
            Me.cboTreatment.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("DateHistoryTreatment"))

            Me.cboIntervalType.DisplayMember = "PARAMETER_NAME"
            Me.cboIntervalType.ValueMember = "PARAMETER_VALUES"
            Me.cboIntervalType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("IntervalType"))

            Me.cboSequenceType.DisplayMember = "PARAMETER_NAME"
            Me.cboSequenceType.ValueMember = "PARAMETER_VALUES"
            Me.cboSequenceType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("SequenceType"))

            Me.cboSequenceType.SelectedIndex = Me.cboSequenceType.FindString("ASC")

            Me.cboWhereType.DisplayMember = "PARAMETER_NAME"
            Me.cboWhereType.ValueMember = "PARAMETER_VALUES"
            Me.cboWhereType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("SQLWhereType"))

            Me.cboOperatorsType.DisplayMember = "PARAMETER_NAME"
            Me.cboOperatorsType.ValueMember = "PARAMETER_VALUES"
            Me.cboOperatorsType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("OperatorsType"))

            Me.cboDataHistoryType.DisplayMember = "PARAMETER_NAME"
            Me.cboDataHistoryType.ValueMember = "PARAMETER_VALUES"
            Me.cboDataHistoryType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("DataHistoryType"))

            Me.cboExecuteType.DisplayMember = "PARAMETER_NAME"
            Me.cboExecuteType.ValueMember = "PARAMETER_VALUES"
            Me.cboExecuteType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("ExecuteType"))

            Me.cboMigrateDataDelete.DisplayMember = "PARAMETER_NAME"
            Me.cboMigrateDataDelete.ValueMember = "PARAMETER_VALUES"
            Me.cboMigrateDataDelete.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("MigrateDataDelete"))

            Me.cboIncrementalType.DisplayMember = "PARAMETER_NAME"
            Me.cboIncrementalType.ValueMember = "PARAMETER_VALUES"
            Me.cboIncrementalType.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("IncrementalType"))

            Me.cboServerConfigName.DisplayMember = "PARAMETER_NAME"
            Me.cboServerConfigName.ValueMember = "PARAMETER_VALUES"
            Me.cboServerConfigName.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("ServerConfigName"))

            Me.cboTargetServerConfigName.DisplayMember = "PARAMETER_NAME"
            Me.cboTargetServerConfigName.ValueMember = "PARAMETER_VALUES"
            Me.cboTargetServerConfigName.DataSource = Conn.GetDataTable(GetMesData.GetSettingSQL("ServerConfigName"))


            If (Not String.IsNullOrEmpty(strDataHistoryId)) Then

                Dim dtTemp As DataTable = GetMesData.GetDataHistoryQuery(strDataHistoryId)
                If (Not dtTemp Is Nothing) Then
                    If (dtTemp.Rows.Count > 0) Then
                        Me.cboDataHistoryType.SelectedIndex = Me.cboDataHistoryType.FindString(dtTemp.Rows(0).Item("DataHistoryTypeName").ToString)
                        Me.cboExecuteType.SelectedIndex = Me.cboExecuteType.FindString(dtTemp.Rows(0).Item("ExecuteTypeName").ToString)

                        Me.mtxtMigrateServer.Text = dtTemp.Rows(0).Item("MigrateServerName").ToString
                        Me.mtxtMigrateDataBase.Text = dtTemp.Rows(0).Item("MigrateDataBaseName").ToString
                        Me.mtxtMigrateTable.Text = dtTemp.Rows(0).Item("DataHistoryTableName").ToString
                        Me.chkStatusFlag.Checked = IIf(dtTemp.Rows(0).Item("StatusFlag").ToString = "Y", True, False)
                        Me.mtxtLinkServer.Text = dtTemp.Rows(0).Item("LinkServerName").ToString
                        Me.cboTreatment.SelectedIndex = Me.cboTreatment.FindString(dtTemp.Rows(0).Item("DateHistoryTreatmentName").ToString)
                        Me.chkColumnType.Checked = IIf(dtTemp.Rows(0).Item("ColumnType") = "1", True, False)

                        Me.mtxtTargetDataBase.Text = dtTemp.Rows(0).Item("TargetDataBaseName").ToString
                        Me.mtxtSequenceColumn.Text = dtTemp.Rows(0).Item("SequenceColumn").ToString
                        Me.mtxtTargetTableName.Text = dtTemp.Rows(0).Item("TargetTableName").ToString
                        Me.cboSequenceType.SelectedIndex = Me.cboSequenceType.FindString(dtTemp.Rows(0).Item("SequenceType").ToString)
                        Me.itxtProcessingNumber.Text = dtTemp.Rows(0).Item("ProcessingNumber").ToString
                        Me.itxtExecutionInterval.Text = dtTemp.Rows(0).Item("ExecutionInterval").ToString
                        Me.itxtIntervalFrequency.Text = dtTemp.Rows(0).Item("IntervalFrequency").ToString
                        Me.cboIntervalType.SelectedIndex = Me.cboIntervalType.FindString(dtTemp.Rows(0).Item("IntervalTypeName").ToString)
                        Me.dtStartTime.Text = dtTemp.Rows(0).Item("StartTime").ToString
                        Me.rBtnEndDate.Checked = IIf(String.IsNullOrEmpty(dtTemp.Rows(0).Item("EndTime")), False, True)
                        Me.rBtnNoEndDate.Checked = IIf(String.IsNullOrEmpty(dtTemp.Rows(0).Item("EndTime")), True, False)
                        Me.dtEndTime.Text = dtTemp.Rows(0).Item("EndTime").ToString
                        Me.itxtRetentionDays.Text = dtTemp.Rows(0).Item("RetentionDays").ToString
                        Me.itxtExecIncrementalTime.Text = dtTemp.Rows(0).Item("ExecIncrementalTime").ToString
                        Me.cboIncrementalType.SelectedIndex = Me.cboIncrementalType.FindString(dtTemp.Rows(0).Item("IncrementalType").ToString)
                        Me.txtRewark.Text = dtTemp.Rows(0).Item("Remark").ToString
                        Me.txtCreateUserId.Text = dtTemp.Rows(0).Item("CreateUserId").ToString
                        Me.txtCreateTime.Text = dtTemp.Rows(0).Item("CreateTime").ToString
                        Me.dtpExecEndTime.Text = dtTemp.Rows(0).Item("ExecEndTime").ToString
                        Me.cboMigrateDataDelete.SelectedIndex = Me.cboMigrateDataDelete.FindString(dtTemp.Rows(0).Item("MigrateDataDeleteName").ToString)
                        Me.cboServerConfigName.SelectedIndex = Me.cboServerConfigName.FindString(dtTemp.Rows(0).Item("MigrateServerConfigName").ToString)
                        Me.cboTargetServerConfigName.SelectedIndex = Me.cboTargetServerConfigName.FindString(dtTemp.Rows(0).Item("TargetServerConfigName").ToString)

                    End If
                End If

                dtDataColumn = GetMesData.GetDataHistoryColumn(strDataHistoryId)
                Me.dgvColumn.DataSource = dtDataColumn
                dtWhereColumn = GetMesData.GetDataHistoryWhere(strDataHistoryId)
                Me.dgvWhere.DataSource = dtWhereColumn
                dtChildColumn = GetMesData.GetDataHistoryChild(strDataHistoryId)
                Me.dgvChild.DataSource = dtChildColumn
                dtPrimaryKey = GetMesData.GetDataHistoryPrimaryKey(strDataHistoryId)
                Me.dgvPrimaryKey.DataSource = dtPrimaryKey
                Me.dtStartTime.Text = Now
            Else
                Me.dgvColumn.DataSource = dtDataColumn
                Me.dgvWhere.DataSource = dtWhereColumn
                Me.dgvChild.DataSource = dtChildColumn
                Me.dgvPrimaryKey.DataSource = dtPrimaryKey
                Me.cboDataHistoryType.SelectedIndex = -1
                Me.cboExecuteType.SelectedIndex = -1
            End If
            Conn.PubConnection.Close()
            SummaryString()
            LoadControlStatus()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.mtxtMigrateTable.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择迁移表", False)
                Return rtValue
                Exit Function
            End If

            'If (String.IsNullOrEmpty(Me.mtxtLinkServer.Text.Trim)) Then
            '    rtValue = False
            '    GetMesData.SetMessage(Me.lblMessage, "请选择链接服务器", False)
            '    Return rtValue
            '    Exit Function
            'End If

            If (String.IsNullOrEmpty(Me.mtxtTargetDataBase.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择目标数据库", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtTargetTableName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择目标表", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtSequenceColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择排序列", False)
                Return rtValue
                Exit Function
            End If

            If (Me.chkColumnType.Checked) Then
                If (Me.dgvColumn.RowCount = 0) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请维护自定义迁移列关系", False)
                    Return rtValue
                    Exit Function
                End If
            End If

            If (String.IsNullOrEmpty(Me.cboExecuteType.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择数据迁移执行类型", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboDataHistoryType.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择数据迁移类型", False)
                Return rtValue
                Exit Function
            End If

            If (Me.cboDataHistoryType.SelectedValue = "0") Then
                If (Me.dgvColumn.RowCount = 0) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请维护迁移表列对应关系", False)
                    Return rtValue
                    Exit Function
                End If
                If (Me.dgvPrimaryKey.RowCount = 0) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请维护迁移表主键列关系", False)
                    Return rtValue
                    Exit Function
                End If
            End If

            If (String.IsNullOrEmpty(strDataHistoryId)) Then
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim DReader As SqlClient.SqlDataReader
                Try
                    DReader = Conn.GetDataReader("SELECT DataHistoryId FROM m_DataHistory_t WHERE DataHistoryTableName = '" & Me.mtxtMigrateTable.Text.Trim & "' AND LinkServerName = '" & Me.mtxtLinkServer.Text.Trim & "' AND TargetDataBaseName = '" & Me.mtxtTargetDataBase.Text.Trim & "'")

                    If (DReader.HasRows) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "选择迁移表已经存在", False)
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
            Else
                rtValue = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Function CheckAddColumn() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.mtxtSourceColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择源栏位", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtTargetColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择目标栏位", False)
                Return rtValue
                Exit Function
            End If

            Dim strSourceColumn As String
            Dim strTargetColumn As String

            For i As Int16 = 0 To Me.dgvColumn.RowCount - 1
                strSourceColumn = IIf(IsDBNull(Me.dgvColumn.Rows(i).Cells("SourceColumn").Value), "", Me.dgvColumn.Rows(i).Cells("SourceColumn").Value)
                strTargetColumn = IIf(IsDBNull(Me.dgvColumn.Rows(i).Cells("TargetColumn").Value), "", Me.dgvColumn.Rows(i).Cells("TargetColumn").Value)

                If (String.IsNullOrEmpty(strSourceColumn)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请选择源栏位", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.mtxtSourceColumn.Text.Trim.ToUpper = strSourceColumn.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请选择源栏位已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If

                If (String.IsNullOrEmpty(strTargetColumn)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请选择目标栏位", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.mtxtTargetColumn.Text.Trim.ToUpper = strTargetColumn.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请选择目标栏位已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If
            Next

            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Function CheckWhereColumn() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.mtxtWhereColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择条件列", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtWhereSQL.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请填写条件SQL", False)
                Return rtValue
                Exit Function
            End If

            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Function CheckChlid() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.mtxtChildTableName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择子表", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtParentColumnName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择主关系ID列", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtChildColumnName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择子关系ID列", False)
                Return rtValue
                Exit Function
            End If

            Dim strChildTableName As String
            Dim strParentColumnName As String
            Dim strChildColumnName As String

            For i As Int16 = 0 To Me.dgvColumn.RowCount - 1
                strChildTableName = IIf(IsDBNull(Me.dgvChild.Rows(i).Cells("ChildTableName").Value), "", Me.dgvChild.Rows(i).Cells("ChildTableName").Value)
                strParentColumnName = IIf(IsDBNull(Me.dgvChild.Rows(i).Cells("ParentColumnName").Value), "", Me.dgvChild.Rows(i).Cells("ParentColumnName").Value)
                strChildColumnName = IIf(IsDBNull(Me.dgvChild.Rows(i).Cells("ChildColumnName").Value), "", Me.dgvChild.Rows(i).Cells("ChildColumnName").Value)

                If (String.IsNullOrEmpty(strChildTableName)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请关系子表不能为空", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.mtxtChildTableName.Text.Trim.ToUpper = strChildTableName.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请关系子表已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If
            Next

            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Function CheckPrimaryKeyColumn() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.mtxtSourcePrimaryKeyColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择源栏位", False)
                Return rtValue
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.mtxtTargetPrimaryKeyColumn.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择目标栏位", False)
                Return rtValue
                Exit Function
            End If

            Dim strSourcePrimaryKeyColumn As String
            Dim strTargetPrimaryKeyColumn As String

            For i As Int16 = 0 To Me.dgvPrimaryKey.RowCount - 1
                strSourcePrimaryKeyColumn = IIf(IsDBNull(Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value), "", Me.dgvPrimaryKey.Rows(i).Cells("SourcePrimaryKeyColumn").Value)
                strTargetPrimaryKeyColumn = IIf(IsDBNull(Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value), "", Me.dgvPrimaryKey.Rows(i).Cells("TargetPrimaryKeyColumn").Value)

                If (String.IsNullOrEmpty(strSourcePrimaryKeyColumn)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请选择源主键栏位", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.mtxtSourceColumn.Text.Trim.ToUpper = strSourcePrimaryKeyColumn.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请选择源主键栏位已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If

                If (String.IsNullOrEmpty(strTargetPrimaryKeyColumn)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请选择目标主键栏位", False)
                    Return rtValue
                    Exit Function
                Else
                    If (Me.mtxtTargetPrimaryKeyColumn.Text.Trim.ToUpper = strTargetPrimaryKeyColumn.Trim.ToUpper) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请选择目标主键栏位已经存在", False)
                        Return rtValue
                        Exit Function
                    End If
                End If
            Next

            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Sub SummaryString()
        Try
            Dim strSummaryString As String

            If (String.IsNullOrEmpty(Me.dtStartTime.Text)) Then
                Me.dtStartTime.Value = Now
            End If

            If (Convert.ToInt16(Me.itxtExecutionInterval.Value) > 1) Then
                strSummaryString = "每" + Me.itxtExecutionInterval.Value.ToString + "天" + "在 0:00:00 和 23:59:59 之间、"
            Else
                strSummaryString = "每天在 0:00:00 和 23:59:59 之间、"
            End If

            strSummaryString = strSummaryString + "每间隔 " + Me.itxtIntervalFrequency.Value.ToString + " " + Me.cboIntervalType.Text + " 执行一次。"

            If (Me.rBtnEndDate.Checked) Then
                strSummaryString = strSummaryString + "将从 " + Me.dtStartTime.Text + " 到 " + Me.dtEndTime.Text + " 之间使用计划。"
            Else
                strSummaryString = strSummaryString + "将从 " + Me.dtStartTime.Text + " 开始使用计划。"
            End If

            strSummaryString = strSummaryString + " 数据保留 " + Me.itxtRetentionDays.Value.ToString + " 天数据、计划每次处理 " + Me.itxtProcessingNumber.Value.ToString + " 笔资料。"

            Me.txtSummary.Text = strSummaryString
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "生成摘要异常", False)
        End Try
    End Sub

    Private Sub LoadControlStatus()
        Try
            If (Not String.IsNullOrEmpty(strDataHistoryId)) Then
                Me.mtxtMigrateServer.ButtonCustom.Enabled = False
                Me.mtxtMigrateDataBase.ButtonCustom.Enabled = False
                Me.mtxtMigrateTable.ButtonCustom.Enabled = False
                Me.mtxtTargetTableName.ButtonCustom.Enabled = False
                Me.mtxtLinkServer.ButtonCustom.Enabled = False
                Me.mtxtTargetDataBase.ButtonCustom.Enabled = False
                Me.mtxtTargetTableName.ButtonCustom.Enabled = False
                Me.cboDataHistoryType.Enabled = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件状态异常", False)
        End Try
    End Sub

#End Region
  
End Class