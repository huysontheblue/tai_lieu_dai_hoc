Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MainFrame
Public Class FrmAsset

#Region "变量定义"

    Private dics As New List(Of KeyValue)

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Public Enum EquipmentType
        PA = 0
        MA
        MJ
        FX
    End Enum

    Private Enum CDImportGrid
        AssetNO
        AssetName
        Model
        CStatus
        Qty
        KeeperID
        KeeperName
        Storage
        '序号	财产编号	资产名称	规格型号	资产使用状态	数量	保管人	保管姓名	保管地点
    End Enum

    Private Enum AssetGrid
        checkbox = 0
        AssetNO
        AssetName
        Model
        Status
        Qty
        KeeperName
        TempLocation
        Storage
        CreateUserID
        CreateTime
        FactoryID
        ProfitCenter
        ID
    End Enum

#End Region

#Region "初期化"

    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Me.DesignMode = False Then
                LabelPrintHelper.InitPrinter(cboPrinter)
                '设定用戶權限
                Dim ERigth As New SysDataBaseClass
                ERigth.GetControlright(Me)
                '
                ' ERigth.GetContextMenuRight(Me, Me.ContextMenuStrip1)
                '设置当前操作模式
                Me.OperateFlag = EditMode.UNDO
                '设置工具栏按钮状态
                SetControlStatus(Me.OperateFlag)
                '设置面板组控件状态
                ToogleGroupBox(0)

                Me.ChkUseY.Checked = True  'default only filter usey='1'
                '绑定数据
                LoadAsset()

                '绑定右键菜单
                Me.dgvAsset.ContextMenuStrip = Me.ContextMenuStripAsset

                If VbCommClass.VbCommClass.profitcenter = "SEE-D" Then
                    tsmi_MaintenanceDay.Visible = False
                    ' SubMonthmaintain.Visible = False
                End If

                ERigth.GetContextMenuRight(Me, Me.ContextMenuStripAsset)
            End If

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

#End Region

#Region "设置工具栏控件状态"
    Private Sub SetControlStatus(ByVal flag As EditMode)
        SetButtonEnable(False)
        Select Case UCase(flag)
            Case EditMode.ADD '新增
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.UNDO '初始化
                Me.toolNew.Enabled = IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False)
                Me.toolModify.Enabled = IIf(DbOperateUtils.DBNullToStr(toolModify.Tag) = "YES", True, False)
                ' Me.tsmiCopyRecord.Enabled = IIf(DbOperateUtils.DBNullToStr(tsmiCopyRecord.Tag) = "YES", True, False)
                Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)
                Me.SubMonthmaintain.Enabled = IIf(DbOperateUtils.DBNullToStr(SubMonthmaintain.Tag) = "YES", True, False)
                'toolPrint.Enabled = True
                'toolImport.Enabled = True
                toolExport.Enabled = True
                toolSearch.Enabled = True
                TabEquipment.Enabled = True
            Case EditMode.SEARCH '搜索
                TabEquipment.Enabled = True
                ' Me.tsmiCopyRecord.Enabled = False
                toolUndo.Enabled = True
                toolSearch.Enabled = True
                toolRefresh.Enabled = True
                toolExport.Enabled = True
        End Select
    End Sub
    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
        ' toolPrint.Enabled = bFlag
        'toolImport.Enabled = bFlag
        toolExport.Enabled = bFlag
        TabEquipment.Enabled = bFlag
    End Sub
#End Region

#Region "检查输入"
    Private Function CheckInput() As Boolean
        Dim txtBox As Control
        Dim strSql As String = String.Empty
        Try
            'check text
            For Each txtBox In Me.GroupBox1.Controls
                If TypeOf txtBox Is System.Windows.Forms.TextBox Then
                    If String.IsNullOrEmpty(txtBox.Text) AndAlso Not txtBox.Tag Is Nothing Then
                        MessageUtils.ShowError(txtBox.Tag.ToString() & ":不能为空!")
                        txtBox.Focus()
                        Return False
                    End If
                End If
            Next

            'Dim ServiceCount As Integer = CInt(Me.txtServiceCount.Text.Trim)
            'Dim AlertCount As Integer = CInt(Me.txtAlertCount.Text.Trim)
            'Dim RemainCount As Integer = CInt(Me.txtRemainCount.Text.Trim)

            'If ServiceCount = 0 Then
            '    MessageUtils.ShowError("使用次数不可为0")
            '    Return False
            'End If

            'If AlertCount > ServiceCount Then
            '    MessageUtils.ShowError("预警次数不可大于使用次数")
            '    Return False
            'End If
            'If RemainCount > ServiceCount Then
            '    MessageUtils.ShowError("剩余次数不可大于使用次数")
            '    Return False
            'End If
            '
            'If Me.cboSmallCategory.SelectedIndex = -1 Then
            '    MessageUtils.ShowError("请选择设备类别")
            '    Return False
            'End If

            If Not String.IsNullOrEmpty(Me.txtQty.Text) Then
                If Not IsNumeric(Me.txtQty.Text.Trim()) Then
                    MessageUtils.ShowError("请填入数字！")
                    Return False
                End If
            End If


            If Me.cboStatus.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return True

    End Function
#End Region

#Region "保存数据"
    Private Function SaveData() As Boolean
        Dim strSql As String = ""
        Dim o_strExcelSQLResult As String = ""
        Dim o_strUseY As String =""
        Try
            Dim AssetNo As String = Me.txtAssetNo.Text.Trim
            Dim Status As Integer = Convert.ToInt16(cboStatus.SelectedItem.ToString().Substring(0, 1))
            Dim CStatus As String = cboStatus.SelectedItem.ToString().Split(".")(1)
            Dim Storage As String = Me.txtStorage.Text.Trim

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
            Dim strAssetName As String = Me.txtAssetName.Text.Trim()
            Dim strBSQL As New System.Text.StringBuilder
            If Me.ChkUseY.Checked Then
                o_strUseY = 1
            Else
                o_strUseY = 0
            End If
            '
            If OperateFlag = EditMode.ADD Then     '新增
                '设备编号是否存在
                strSql = "SELECT 1 FROM m_Asset_t(nolock) WHERE AssetNo=N'" & AssetNo & "' AND isnull(usey,'1')='1'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If Not CheckInput() Then
                    'do nothing
                End If


                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("资产编号:" + AssetNo + " 已存在!")
                    Return False
                Else
                    strSql = " INSERT INTO m_Asset_t(AssetNo, AssetName, Model, Qty," &
                             " Status,CStatus,KeeperID,KeeperName,Storage,FactoryName,Profitcenter, CreateUserID, CreateTime)"
                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", AssetNo)
                    strBSQL.AppendFormat("N'{0}',", strAssetName)
                    strBSQL.AppendFormat("N'{0}',", Me.txtModel.Text.Trim)
                    strBSQL.AppendFormat("N'{0}',", Val(Me.txtQty.Text.Trim))
                    strBSQL.AppendFormat("N'{0}',", Status)
                    strBSQL.AppendFormat("N'{0}',", CStatus)
                    strBSQL.AppendFormat("N'{0}',", Me.txtKeeperID.Text.Trim)
                    strBSQL.AppendFormat("N'{0}',", GetUserName(Me.txtKeeperID.Text.Trim))
                    strBSQL.AppendFormat("N'{0}',", Storage)
                    strBSQL.AppendFormat("N'{0}',", FactoryName)
                    strBSQL.AppendFormat("N'{0}',", Profitcenter)
                    strBSQL.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                    strBSQL.AppendFormat("getdate()")
                    strBSQL.Append(");")

                End If
            Else    '修改
                strSql = "UPDATE m_Asset_t "

                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" SET ModifyUserID = N'{0}', ", VbCommClass.VbCommClass.UseId)
                strBSQL.AppendFormat(" ModifyTime = getdate(),")
                strBSQL.AppendFormat("  AssetName= N'{0}' ,", strAssetName)
                strBSQL.AppendFormat("  Qty= N'{0}' ,", Val(Me.txtQty.Text.Trim()))
                strBSQL.AppendFormat("  Model= N'{0}' ,", Me.txtModel.Text.Trim())
                strBSQL.AppendFormat(" Status = N'{0}',", Status)
                strBSQL.AppendFormat(" CStatus = N'{0}',", CStatus)
                strBSQL.AppendFormat(" Storage = N'{0}' ,", Storage)
                strBSQL.AppendLine(" KeeperID='" & txtKeeperID.Text.Trim() & "',")
                strBSQL.AppendLine(" usey='" & o_strUseY & "',")
                strBSQL.AppendLine(" KeeperName=N'" & GetUserName(Me.txtKeeperID.Text.Trim) & "'")
                strBSQL.AppendFormat(" WHERE ID = {0}", Val(Me.lblId.Text.Trim))

            End If
            '执行SQL
            DbOperateUtils.ExecSQL(strBSQL.ToString)
            Return True
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function

    Private Function GetUserName(ByVal strUserID As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT UserName FROM m_Users_t(nolock) Where UserID ='" & strUserID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserName = o_dt.Rows(0).Item(0)
            Else
                GetUserName = ""
            End If
        End Using
    End Function


#End Region

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                Me.txtAssetNo.Enabled = False
                Me.cboStatus.Enabled = False
                Me.cboStatus.Enabled = False
                Me.txtStorage.Enabled = False
            Case 1
                Me.txtAssetNo.Enabled = True
                Me.cboStatus.Enabled = True
                Me.cboStatus.Enabled = True
                Me.txtStorage.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.lblId.Text = ""
        Me.txtAssetNo.Text = ""
        Me.txtStorage.Text = ""
        Me.cboStatus.SelectedIndex = 0
        Me.cboStatus.SelectedIndex = 0

        Me.txtAssetName.Text = String.Empty  'add by cq20171211
        Me.txtKeeperID.Text = String.Empty
        Me.txtModel.Text = String.Empty

    End Sub
#End Region

#Region "给 GroupBox 面板控件赋值"
    Private Sub SetGroupBox()
        Dim index As Integer = TabEquipment.SelectedIndex
        If index = 0 Then
            SetControlValue(dgvAsset)
        ElseIf index = 1 Then
            ' SetControlValue(dgvMA)
        ElseIf index = 2 Then
            'SetControlValue(dgvEqu)
        ElseIf index = 3 Then
            'SetControlValue(dgvFX)
        Else
            SetControlValue(dgvAsset)
        End If
    End Sub

    Private Sub SetControlValue(dgGrid As DataGridView)

        If dgGrid.RowCount < 1 Then Exit Sub
        ''当前行没有时把第一行默认选中
        If dgGrid.Item(AssetGrid.ID, dgGrid.CurrentRow.Index).Value IsNot Nothing Then
            Me.lblId.Text = dgGrid.Item(AssetGrid.ID, dgGrid.CurrentRow.Index).Value.ToString()
        Else
            Me.lblId.Text = dgGrid.Item(AssetGrid.checkbox, dgGrid.CurrentRow.Index).Value.ToString()
        End If
        Dim bigCategory As String = ""
        Dim middleCategory As String = ""
        Dim smallCategory As String = ""
        Dim dt As DataTable = GetCategoryData(Me.lblId.Text)
        If dt.Rows.Count > 0 Then
            bigCategory = dt.Rows(0)(0).ToString
            middleCategory = dt.Rows(0)(1).ToString
            smallCategory = dt.Rows(0)(2).ToString
        End If

        Me.txtAssetNo.Text = dgGrid.Item(AssetGrid.AssetNO, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtAssetName.Text = dgGrid.Item(AssetGrid.AssetName, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtQty.Text = dgGrid.Item(AssetGrid.Qty, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtStorage.Text = dgGrid.Item(AssetGrid.Storage, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtKeeperID.Text = dgGrid.CurrentRow.Cells("KeeperID").Value.ToString()
        Me.txtModel.Text = dgGrid.Item(AssetGrid.Model, dgGrid.CurrentRow.Index).Value.ToString()

        Me.cboStatus.SelectedIndex = Me.cboStatus.FindString((dgGrid.Item(AssetGrid.Status, dgGrid.CurrentRow.Index).Value.ToString))
        ' Me.txtLine.Text = dgGrid.Item(EquipmentGrid.LineID, dgGrid.CurrentRow.Index).Value.ToString()

    End Sub
#End Region

#Region "工具条事件"

    '新增
    Private Sub toolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        Me.txtAssetNo.Focus()
        Me.cboStatus.SelectedIndex = 2 : Me.cboStatus.SelectedIndex = 2
        ' Me.txtLine.ReadOnly = True
        'Me.cboStatus.Enabled = False : Me.cboInOut.Enabled = False : Me.txtLine.ReadOnly = True : Me.cboPrinter.Enabled = False
    End Sub
    '修改
    Private Sub toolModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
        '面板控件可写
        ToogleGroupBox(1)
        '面板控件赋值
        SetGroupBox()
        Me.txtAssetNo.Enabled = False
        Me.cboStatus.Enabled = True
        'Me.txtLine.ReadOnly = True
        'Me.cboPrinter.Enabled = False
    End Sub
    '保存
    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Try
            Dim index As Integer = TabEquipment.SelectedIndex
            If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
                '检查输入
                If CheckInput() = False Then
                    Exit Sub
                End If
                '确认信息
                If MessageUtils.ShowConfirm("你确定保存吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                '保存
                If SaveData() = False Then Exit Sub

                MessageUtils.ShowInformation("保存成功")
                '清除面板控件值
                ClearGroupBox()

                ToogleGroupBox(0)
                '刷新
                LoadAsset()
                SetControlStatus(EditMode.UNDO)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnSave_Click", "sys")
        End Try
    End Sub
    '退出
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '查找 
    Private Sub toolSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        cboStatus.Enabled = True
        cboStatus.Enabled = True
        txtAssetNo.Enabled = True
        Me.txtAssetNo.ReadOnly = False
        Me.txtAssetNo.Focus()
    End Sub
    '刷新
    Private Sub toolRefreshClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            LoadAsset()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnRefresh_Click", "sys")
        End Try
    End Sub
    '返回
    Private Sub toolUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
        '面板控件只读
        ToogleGroupBox(0)
        ''
    End Sub

    '导出
    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExport.Click
        Dim strSql As String = ""
        Dim sqlWhere As String = Nothing
        Dim IsSearch As Boolean = True
        strSql = " SELECT A.ID ,A.AssetNo 财产编号, A.AssetName 资产名称, " &
                 " A.Model 规格型号,A.CStatus 资产使用状态," &
                 " A.Qty 数量,A.STORAGE 储位,A.keeperid AS 保管人工号, A.KeeperName 保管人姓名 ,A.TempLocation 保管地点, A. storage 初始库位  " &
                 " FROM m_Asset_t(nolock) A " &
                 "  LEFT JOIN m_Users_t(nolock) C ON A.CreateUserID=C.UserID    " &
                 " WHERE 1=1  " &
                 EquManageCommon.GetFatoryProfitcenter("A")

        If IsSearch = toolRefresh.Enabled Then '如果查询为true,就带查询条件
            'If cboSmallCategory.SelectedIndex = -1 Then
            '    MessageUtils.ShowError("请选择设备类别")
            '    Exit Sub
            'End If

            If cboStatus.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Exit Sub
            End If
            sqlWhere = GetSqlWhere()
        End If

        strSql = strSql + "  " & sqlWhere & " ORDER BY A.ID"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        'ExcelHelper.ExportDTtoExcel(dt, "载治具基本资料表", filename)
        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub
    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

#End Region


#Region "右键菜单"
    ''' <summary>
    ''' 日保养
    ''' </summary>
    Private Sub tsmi_MaintenanceDay_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceDay.Click
        If Me.dgvAsset.CurrentRow Is Nothing OrElse Me.dgvAsset.RowCount < 1 Then Exit Sub
        Dim AssetName As String
        Dim AssetNo As String
        Dim Model As String
        AssetNo = Me.dgvAsset.CurrentRow.Cells(AssetGrid.AssetNO).Value.ToString
        AssetName = Me.dgvAsset.CurrentRow.Cells(AssetGrid.AssetName).Value.ToString
        Model = Me.dgvAsset.CurrentRow.Cells(AssetGrid.Model).Value.ToString
        Dim frmMpDay As New FrmAssetMaintenanceDay(AssetNo, AssetName, Model)
        frmMpDay.ShowDialog()

    End Sub
    ''' <summary>
    ''' 月、季保养
    ''' </summary>
    Private Sub tsmi_MaintenanceMonth_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceMonth.Click
        If Me.dgvAsset.CurrentRow Is Nothing OrElse Me.dgvAsset.RowCount < 1 Then Exit Sub
        Dim AssetName As String
        Dim AssetNo As String
        Dim Model As String
        Dim Storage As String
        AssetNo = Me.dgvAsset.CurrentRow.Cells(AssetGrid.AssetNO).Value.ToString
        AssetName = Me.dgvAsset.CurrentRow.Cells(AssetGrid.AssetName).Value.ToString
        Model = Me.dgvAsset.CurrentRow.Cells(AssetGrid.Model).Value.ToString
        Storage = Me.dgvAsset.CurrentRow.Cells(AssetGrid.Storage).Value.ToString
        Dim frmMpMorQ As New FrmAssetMaintenanceMonth(AssetNo, AssetName, Model, Storage)
        frmMpMorQ.ShowDialog()
    End Sub

    Private Sub tsmi_MaintenanceType_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceType.Click

        Dim frmmaintenType As New FrmAssetMaintenanceType()
        frmmaintenType.ShowDialog()

    End Sub
#End Region
#Region "右健改变当前行号"
    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvAsset.ClearSelection()
                dgvAsset.Rows(e.RowIndex).Selected = True
                dgvAsset.CurrentCell = dgvAsset.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If
    End Sub

#End Region


#Region "背景色"
    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvAsset.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvMEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvAsset.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvZEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvAsset.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
#End Region

#Region "GridClick"
    Private Sub dgvAsset_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsset.CellClick
        GridClick(dgvAsset, e)
    End Sub

    Private Sub GridClick(dgGrid As DataGridView, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgGrid.RowCount < 1 Then Exit Sub

        If dgvAsset.Columns(e.ColumnIndex).Name = "选择" Then
            Dim vb = CType(dgvAsset.CurrentRow.Cells("选择").FormattedValue, Boolean)
            dgvAsset.CurrentRow.Cells("选择").Value = IIf(vb, False, True)
        End If


        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        If e.RowIndex < 0 Then Exit Sub
        SetGroupBox()
    End Sub
#End Region

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        Dim strAssetNo_Name As String = String.Empty

        'DB中财产编号
        Dim AssetNoSql As String = " SELECT  (AssetNO+ AssetName) as  AssetNO from m_Asset_t where ISNULL(UseY,'1')='1' " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtAssetNo As DataTable = DbOperateUtils.GetDataTable(AssetNoSql)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1

            Dim returnCode As String = ""

            '比对设备编号 
            If (DrrR(index)("AssetNO").ToString <> "") Then
                strAssetNo_Name = DrrR(index)("AssetNO").ToString + DrrR(index)("AssetName").ToString
                If hastable.Contains(strAssetNo_Name) Then
                    MessageUtils.ShowError("上传文件中有重复的财产编号：'" + strAssetNo_Name + "'")
                    Return False
                End If
                If CheckExistUserColumns(dtAssetNo, "AssetNo", strAssetNo_Name, returnCode) = True Then
                    MessageUtils.ShowError("不能上传重复的设备编号：'" + strAssetNo_Name + "'")
                    Return False
                End If
                hastable.Add(strAssetNo_Name, strAssetNo_Name)
            End If
        Next

        Return True
    End Function


    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.txtAssetNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [AssetNo] like N'%" & txtAssetNo.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtAssetName.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND AssetName like N'%" & txtAssetName.Text.Trim().Replace("'", "''") & "%' ")

        End If

        If Me.txtModel.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND Model like N'%" & txtModel.Text.Trim().Replace("'", "''") & "%' ")

        End If

        If Me.txtKeeperID.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND CreateUserID like N'%" & txtKeeperID.Text.Trim().Replace("'", "''") & "%' ")
        End If




        If Not cboStatus.SelectedItem Is Nothing AndAlso Me.cboStatus.SelectedItem().ToString <> "" Then
            sbSqlWhere.Append(" AND A.Status = " & cboStatus.SelectedItem().ToString().Substring(0, 1) & " ")
        End If

        '初始库位位置
        If Me.txtStorage.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        If Me.txtStorage.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        If Not String.IsNullOrEmpty(Me.txtTempLocation.text.trim) Then
            sbSqlWhere.Append(" AND TempLocation like N'%" & Me.txtTempLocation.Text.Trim & "%' ")
        End If

        '是否有效
        If Me.ChkUseY.Checked = True Then
            sbSqlWhere.Append(" AND isnull(a.usey,'1') ='1' ")
        Else
            sbSqlWhere.Append(" AND isnull(a.usey,'1') ='0' ")
        End If

        Return sbSqlWhere.ToString
    End Function

    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function

    Private Function BasicCheck() As Boolean
        If cboPrinter.SelectedIndex = -1 Then
            MessageUtils.ShowError("请选择打印机")
            cboPrinter.Focus()
            Return False
        End If
        If dics.Count <= 0 Then
            MessageUtils.ShowError("请选择需要列印的资产!")
            Return False
        End If
        Return True
    End Function

    Private Function GetDeleteSQL(dgvGrid As DataGridView) As String
        Dim strSQL As String = String.Empty

        '移除删除功能，改为更新。
        For Each row As DataGridViewRow In dgvGrid.Rows
            If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                   row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                ' strSQL &= " DELETE FROM m_Asset_t WHERE ID=" & row.Cells(AssetGrid.ID).Value.ToString & "" & vbNewLine
                'Modify by cq 20171213 
                strSQL &= " UPDATE m_Asset_t SET usey='0'  WHERE ID=" & row.Cells(AssetGrid.ID).Value.ToString & "" & vbNewLine
            End If
        Next
        GetDeleteSQL = strSQL
    End Function

    Private Function GetCategoryData(id As String)
        Dim strSQL As String = " SELECT BigCategory ,MiddleCategory,SmallCategory  FROM m_Equipment_t WHERE id = '{0}'"
        strSQL = String.Format(strSQL, id)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

#Region "加载数据"

    Private Sub LoadAsset()
        Dim StrSql As New StringBuilder
        Try
            StrSql.Append(" SELECT A.AssetNO 财产编号, A.AssetNAME 资产名称, A.Model 规格型号,")
            StrSql.Append(" Cast( A.STATUS as varchar(10)) + '.' + A.CSTATUS  使用状态, A.Qty 数量, ")
            StrSql.Append(" A.KeeperName 保管人姓名,a.TempLocation 保管地点, a.Storage 初始库位,")
            StrSql.Append(" A.CreateUserID+'/'+E.UserName 创建人,")
            StrSql.Append(" A.CreateTime 创建时间, FactoryName 厂区, Profitcenter 利润中心,A.ID,A.KeeperID ")
            StrSql.Append(" FROM M_Asset_T(NOLOCK) A   ")
            StrSql.Append(" LEFT JOIN m_Users_t E ON A.CreateUserID=E.UserID WHERE 1=1 " & EquManageCommon.GetFatoryProfitcenter("A"))

            If OperateFlag = EditMode.SEARCH Then
                StrSql.Append(GetSqlWhere())
            End If

            Select Case VbCommClass.VbCommClass.profitcenter
                Case "XT-D"
                    StrSql.Append(" AND A.CreateUserID IN ( ")
                    StrSql.Append("   SELECT UserID FROM m_users_t WHERE Dept = (SELECT dept FROM dbo.m_Users_t WHERE userid = '" & VbCommClass.VbCommClass.UseId & "')")
                    StrSql.Append(" AND dbo.m_Users_t.Usey='1')")
                Case Else
                    'do nothing
            End Select

            StrSql.Append(" ORDER BY A.Status DESC ")

            LoadData(StrSql.ToString, [Enum].Parse(GetType(EquipmentType), 0))
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadData(ByVal Sql As String, ByVal type As EquipmentType)
        Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
        col.Name = "选择"
        col.ReadOnly = False
        col.TrueValue = True
        col.FalseValue = False
        Try

            Using dt As DataTable = DbOperateUtils.GetDataTable(Sql)
                Select Case type
                    Case EquipmentType.PA
                        SetColumnsProperty(col, dgvAsset, dt)
                    Case Else
                        SetColumnsProperty(col, dgvAsset, dt)
                End Select
            End Using
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "LoadData", "sys")
        End Try
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        Try
            If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
            dgGrid.DataSource = dt
            dgGrid.Columns.Insert(0, col)
            '"备注"列全屏显示
            dgGrid.Columns(AssetGrid.ID).Visible = False
            dgGrid.Columns("KeeperID").Visible = False
            dgGrid.ReadOnly = False
            dgGrid.Columns(0).HeaderText = "   选择"
            SetSelectAll(dgGrid)
            dgGrid.Columns(AssetGrid.ID).Width = 40
            dgGrid.Columns(AssetGrid.checkbox).Width = 60
            dgGrid.Columns(AssetGrid.AssetNO).Width = 100
            dgGrid.Columns(AssetGrid.AssetName).Width = 105
            dgGrid.Columns(AssetGrid.Model).Width = 105
            dgGrid.Columns(AssetGrid.Status).Width = 80
            dgGrid.Columns(AssetGrid.Qty).Width = 80
            dgGrid.Columns(AssetGrid.KeeperName).Width = 95
            dgGrid.Columns(AssetGrid.Storage).Width = 105
            dgGrid.Columns(AssetGrid.FactoryID).Width = 60
            dgGrid.Columns(AssetGrid.ProfitCenter).Width = 80
            ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
            'CheckBox = 0 AssetNO,AssetName,Model,Status,Qty,KeeperName,Storage,CreateUserID,CreateTime,FactoryID,ProfitCenter,ID
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "SetColumnsProperty", "sys")
        End Try
    End Sub

    Private Sub SetSelectAll(dgGrid As DataGridView)
        Dim rect As Rectangle = dgGrid.GetCellDisplayRectangle(0, -1, True)
        rect.X = rect.Location.X + rect.Width / 4 - 20
        rect.Y = rect.Location.Y + (rect.Height / 2 - 9)
        Dim cbHeader As CheckBox = New CheckBox()
        cbHeader.Name = "checkboxHeader"
        cbHeader.Size = New Size(18, 18)
        cbHeader.Location = rect.Location
        cbHeader.Checked = False
        AddHandler cbHeader.CheckedChanged, AddressOf cbHeader_CheckedChanged
        dgGrid.Controls.Add(cbHeader)
    End Sub

    Private Sub cbHeader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim gvr As DataGridView = DirectCast(chk.Parent, DataGridView)

        SetCheckBox(chk, gvr)
    End Sub

    Private Sub SetCheckBox(chk As CheckBox, gvr As DataGridView)
        If chk.Checked Then
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(AssetGrid.checkbox).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(AssetGrid.checkbox).Value = False
            Next
        End If
    End Sub
#End Region

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 8, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" AssetNo IS NOT NULL  ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("FactoryName", "System.String", dtUploadData)
            TableAddColumns("Profitcenter", "System.String", dtUploadData)
            TableAddColumns("CreateUserID", "System.String", dtUploadData)
            TableAddColumns("CreateTime", "System.String", dtUploadData)
            TableAddColumns("Status", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)
            dics2.Add("AssetNo", "AssetNo")
            dics2.Add("AssetName", "AssetName")
            dics2.Add("Model", "Model")
            dics2.Add("CStatus", "CStatus")
            dics2.Add("Qty", "Qty")
            dics2.Add("KeeperID", "KeeperID")
            dics2.Add("KeeperName", "KeeperName")
            dics2.Add("Storage", "Storage")
            dics2.Add("FactoryName", "FactoryName")
            dics2.Add("Profitcenter", "Profitcenter")
            dics2.Add("CreateUserID", "CreateUserID")
            dics2.Add("CreateTime", "CreateTime")
            dics2.Add("Status", "Status")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    ' 0财产编号	资产名称	2规格型号	3资产使用状态	4数量	5保管人	 6保管姓名	7保管地点
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), _
                                      row(3).ToString(), row(4).ToString(),
                                      row(5).ToString(), row(6).ToString(), row(7).ToString(), _
                                      VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, _
                                      VbCommClass.VbCommClass.UseId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    GetStatusFromMES(row(3).ToString())
                                      )
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_Asset_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    LoadAsset()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    Private Function GetStatusFromMES(ByVal strStatusName As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT VALUE FROM m_BaseData_t WHERE TEXT = N'" & strStatusName & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetStatusFromMES = o_dt.Rows(0).Item(0)
            Else
                GetStatusFromMES = ""
            End If
        End Using
    End Function

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim sql As String = String.Empty
        Select Case TabEquipment.SelectedIndex
            Case 0
                sql = GetDeleteSQL(dgvAsset)
            Case Else

                sql = GetDeleteSQL(dgvAsset)
        End Select
        If String.IsNullOrEmpty(sql) Then
            MessageUtils.ShowError("请选择要删除的财产!")
            Exit Sub
        End If
        Try
            If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                DbOperateUtils.ExecSQL(sql)
                MessageUtils.ShowInformation("删除成功")
                LoadAsset()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub ToolLend_Click(sender As Object, e As EventArgs) Handles ToolLend.Click
        Dim strIDList As String = String.Empty
        Dim strStatus As String = String.Empty
        For Each row As DataGridViewRow In dgvAsset.Rows
            If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                   row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                strIDList = strIDList + row.Cells(AssetGrid.ID).Value.ToString + ","
                strStatus = strStatus + row.Cells(AssetGrid.Status).Value.ToString() + ","
                'Exit For
            End If
        Next

        If Not String.IsNullOrEmpty(strIDList) AndAlso strIDList.Length > 0 Then
            strIDList = strIDList.Substring(0, strIDList.Length - 1)
        End If
        If String.IsNullOrEmpty(strIDList) Then
            MessageUtils.ShowError("请勾选要借出的财产！")
            Exit Sub
        End If

        ''实际一次只能借出一笔记录
        'If Not String.IsNullOrEmpty(strStatus) AndAlso strStatus.Substring(0, 1) = "1" Then
        '    MessageUtils.ShowError("已经借出,不允许再借出！")
        '    Exit Sub
        'End If

        If strStatus.Contains("1") Then
            MessageUtils.ShowError("勾选的资产编号中有存在借出的数据,不可重复借出,请核实!")
            Exit Sub
        End If



        Dim frmLend As New FrmAssetLend
        frmLend.lblID.Text = strIDList
        '  frmLend.txtLineID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value
        frmLend.StartPosition = FormStartPosition.CenterScreen
        frmLend.Owner = Me
        frmLend.ShowDialog()
        LoadAsset()
    End Sub

    Private Sub ToolReturn_Click(sender As Object, e As EventArgs) Handles ToolReturn.Click

        Dim strIDList As String = String.Empty
        For Each row As DataGridViewRow In dgvAsset.Rows
            If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                   row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                strIDList = strIDList + row.Cells(AssetGrid.ID).Value.ToString + ","
            End If
        Next

        If Not String.IsNullOrEmpty(strIDList) AndAlso strIDList.Length > 0 Then
            strIDList = strIDList.Substring(0, strIDList.Length - 1)
        End If

        If String.IsNullOrEmpty(strIDList) Then
            MessageUtils.ShowError("请勾选要归还的财产！")
            Exit Sub
        End If

        ''限制一次只能归还一笔资料
        'If strIDList.Split(",").Length > 1 Then
        '    MessageUtils.ShowError("限制一次只允许归还一笔记录！")
        '    Exit Sub
        'End If

        Dim strLendUserList As String = String.Empty
        For Each row As DataGridViewRow In dgvAsset.Rows
            If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                If (("," + row.Cells(AssetGrid.KeeperName).Value.ToString + ",").IndexOf(strLendUserList) < 0) OrElse String.IsNullOrEmpty(strLendUserList) Then
                    strLendUserList = strLendUserList + row.Cells(AssetGrid.KeeperName).Value.ToString + ","
                End If
            End If
        Next

        If Not String.IsNullOrEmpty(strLendUserList) AndAlso strLendUserList.Length > 0 Then
            strLendUserList = strLendUserList.Substring(0, strLendUserList.Length - 1)
        End If


        Dim strLendDeptList As String = String.Empty
        For Each row As DataGridViewRow In dgvAsset.Rows
            If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                If (("," + row.Cells(AssetGrid.TempLocation).Value.ToString + ",").IndexOf(strLendDeptList) < 0) OrElse String.IsNullOrEmpty(strLendDeptList) Then
                    strLendDeptList = strLendDeptList + row.Cells(AssetGrid.TempLocation).Value.ToString + ","
                End If
            End If
        Next

        If Not String.IsNullOrEmpty(strLendDeptList) AndAlso strLendDeptList.Length > 0 Then
            strLendDeptList = strLendDeptList.Substring(0, strLendDeptList.Length - 1)
        End If

        Dim frmReturn As New FrmAssetReturn
        frmReturn.lblIDList.Text = strIDList
        frmReturn.txtLendUser.Text = strLendUserList
        frmReturn.txtLendDept.Text = strLendDeptList
        '  frmLend.txtLineID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value
        frmReturn.StartPosition = FormStartPosition.CenterScreen
        frmReturn.Owner = Me
        frmReturn.ShowDialog()
        LoadAsset()
        'Dim o_strSQL As New StringBuilder
        'For Each row As DataGridViewRow In dgvAsset.Rows
        '    If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
        '           row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
        '        o_strSQL.Append(" Update m_Asset_t Set CStatus =N'闲置中', Status='0' , ModifyUserID ='" & VbCommClass.VbCommClass.UseId & "', ModifyTime = getdate(), ")
        '        o_strSQL.Append(" KeeperID = null, keeperName = null, storage = null ")
        '        o_strSQL.Append(" Where ID = '" & row.Cells(AssetGrid.ID).Value.ToString & "' ")
        '    End If
        'Next

        'If String.IsNullOrEmpty(o_strSQL.ToString) Then
        '    MessageUtils.ShowError("请勾选要归还的财产！")
        '    Exit Sub
        'Else
        '    DbOperateUtils.ExecSQL(o_strSQL.ToString)
        '    MessageUtils.ShowInformation("归还成功!")
        '    LoadAsset()
        'End If
    End Sub

    Private Sub tooltLeedEquipment_Click(sender As Object, e As EventArgs) Handles tooltLeedEquipment.Click
        Dim _Storage As String = Me.dgvAsset.CurrentRow.Cells(AssetGrid.Storage).Value
        'If IsDBNull(_Storage) OrElse Not _Storage.Contains("XT") Then

        '    MessageUtils.ShowError("保存地点不包含线别不允许转借")
        '    Exit Sub
        'End If
        If String.IsNullOrEmpty(_Storage.ToString().Trim()) Then
            MessageUtils.ShowError("保存地点不包含线别不允许转借")
            Exit Sub
        End If
        Dim frmLine As New FrmAssetLendBorrow
        frmLine.txtEquipmentNo.Text = Me.dgvAsset.CurrentRow.Cells(AssetGrid.AssetNO).Value
        frmLine.txtFromLineID.Text = Me.dgvAsset.CurrentRow.Cells(AssetGrid.Storage).Value
        frmLine.lbId.Text = Me.dgvAsset.CurrentRow.Cells(AssetGrid.ID).Value


        If Not IsDBNull(Me.dgvAsset.CurrentRow.Cells(AssetGrid.KeeperName).Value) Then
            frmLine.txtFromUserID.Text = Me.dgvAsset.CurrentRow.Cells(AssetGrid.KeeperName).Value
        End If
        frmLine.StartPosition = FormStartPosition.CenterScreen
        frmLine.Owner = Me
        frmLine.ShowDialog()

        LoadAsset()

    End Sub

    Private Sub toolLendRecord_Click(sender As Object, e As EventArgs) Handles toolLendRecord.Click
        Dim frmLendBorrow As New FrmAssetLendBorrowLog

        frmLendBorrow.StartPosition = FormStartPosition.CenterScreen
        frmLendBorrow.Owner = Me
        frmLendBorrow.ShowDialog()
    End Sub


    Private Sub tsmi_NonDayMantenance_Click(sender As Object, e As EventArgs) Handles tsmi_NonDayMantenance.Click

        Dim frmNonDaymainten As New FrmAssetNonDayMaintenance()
        frmNonDaymainten.ShowDialog()
    End Sub

    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        Dim msg As String = Nothing
        Dim fileName As String = Nothing
        Dim copies As Integer = 1
        Dim index As Integer = 1
        Dim prePage As Integer = 1
        Try
            dics.Clear()
            Dim printPath As String = VbCommClass.VbCommClass.PrintDataModle + "EquipmentTemplate\"

            Select Case TabEquipment.SelectedIndex
                Case 0
                    For Each row As DataGridViewRow In dgvAsset.Rows
                        If Not row.Cells(AssetGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(AssetGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                            dics.Add(New KeyValue(copies, "AssetNo1", row.Cells(AssetGrid.AssetNO).Value.ToString))
                            dics.Add(New KeyValue(copies, "AssetName1", row.Cells(AssetGrid.AssetName).Value.ToString))
                            dics.Add(New KeyValue(copies, "Model1", row.Cells(AssetGrid.Model).Value.ToString))
                            'dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                            index += 1
                            copies += 1
                        End If
                    Next

                    index -= 1
                    copies -= 1
                    fileName = printPath + "ASSET.btw"
                Case 1  '辅助设备
                    'For Each row As DataGridViewRow In dgvMA.Rows
                    '    If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                    '        dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                    '        dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                    '        dics.Add(New KeyValue(copies, "EquipmentName" + index.ToString, "机台设备名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                    '        dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                    '        index += 1
                    '    End If
                    '    If index = 4 Then
                    '        index = 1
                    '        copies += 1
                    '    End If
                    'Next
                    'prePage = 4
                    'fileName = printPath + "EquipmentMA.btw"
                    'copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                Case 2  '模具标签
                    'For Each row As DataGridViewRow In dgvMJ.Rows
                    '    If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                    '        dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                    '        dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                    '        'dics.Add(New KeyValue("EquipmentName" + index.ToString, row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                    '        index += 1
                    '    End If
                    '    If index = 4 Then
                    '        index = 1
                    '        copies += 1
                    '    End If
                    'Next
                    'prePage = 2
                    'fileName = printPath + "EquipmentMJ.btw"
                    'copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                    'If index <> 1 Then
                    '    For i As Integer = index To 3
                    '        dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                    '        dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                    '        dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                    '    Next
                    'End If
            End Select
            If Not BasicCheck() Then
                Exit Sub
            End If
            If LabelPrintHelper.PrintLabel(dics, cboPrinter.Text, msg, fileName, prePage, copies) Then
                MessageUtils.ShowInformation("打印成功")
            Else
                MessageUtils.ShowError(msg)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "toolPrint_Click", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 批量月保养
    ''' add by马跃平 2018-10-16
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SubMonthmaintain_Click(sender As Object, e As EventArgs) Handles SubMonthmaintain.Click
        Dim list = GetCheckAsset()
        If list.Count = 0 Then
            MessageUtils.ShowError("请勾选要保养的资产!")
            Exit Sub
        ElseIf IsHaveMaintenanceProjectMonth() = True Then
            Exit Sub
        ElseIf ExistMaintenanceToMonth() = True Then
            Exit Sub
        End If
        Dim sql As System.Text.StringBuilder = New StringBuilder()
        For Each Str As String In list '循环资产

            Dim sqlProject = "SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,0 AS IsNotUsed,'' as  Remark  " & vbCrLf &
"FROM m_AssetMaintenanceType_t WHERE AssetName =N'" & Str.Split("|")(1) & "' and IsMpDay=1  "
            Dim dt = DbOperateUtils.GetDataTable(sqlProject) '资产维护的项目
            For Each dr As DataRow In dt.Rows
                sql.AppendLine("INSERT INTO m_AssetMaintenanceMonth_t(AssetNo,MaintenanceProject,Months,Status,Remark,CreateTime,CreateUserID,year) VALUES(N'" & Str.Split("|")(0) & "',N'" & dr("MaintenanceProject").ToString() & "',CAST( datepart(MONTH,GETDATE()) as varchar(10)),N'O',N'批量月保养',GETDATE(),N'" & VbCommClass.VbCommClass.UseId & "'," & Date.Now.Year & ")")
            Next
        Next
        Try
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("批量月保养成功!")
            LoadAsset()
        Catch ex As Exception
            MessageUtils.ShowError("批量月保养失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 是否存在月保养记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistMaintenanceToMonth() As Boolean
        Dim yy = False
        Dim year As Integer = Date.Now.Year
        Dim month As String = Date.Now.Month

        For Each Str As String In GetCheckAsset()
            Dim strSql = String.Format("SELECT 1 FROM m_AssetMaintenanceMonth_t WHERE AssetNo='{0}' AND Months='{1}' and  year='{2}'",
                                       Str.Split("|")(0), month, year)
            Dim dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("资产编号:" + Str.Split("|")(0) + ",在" & year & "年" + month + "月份已经存在保养记录!")
                yy = True
                Exit For
            End If
        Next
        Return yy
    End Function

    ''' <summary>
    ''' 是否存在季度保养
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistMaintenanceToQuarter() As Boolean
        Dim yy = False
        Dim year As Integer = Date.Now.Year
        Dim QUARTER As String = EquManageCommon.GetQuarter.ToString
        For Each Str As String In GetCheckAsset()
            Dim strSql = String.Format("SELECT * FROM m_AssetMaintenanceQuarter_t WHERE AssetNo='{0}' AND  Quarter='{1}' and year='{2}'  ",
                                       Str.Split("|")(0), QUARTER, year)
            Dim dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("资产编号:" + Str.Split("|")(0) + ",在" & year & "年" + QUARTER + "季度已经存在保养记录!")
                yy = True
                Exit For
            End If
        Next
        Return yy
    End Function

    ''' <summary>
    ''' 记录用户勾选的固定资产
    ''' add by马跃平 2018-10-16
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetCheckAsset() As List(Of String)
        Dim list As List(Of String) = New List(Of String)()
        For Each dgvr As DataGridViewRow In dgvAsset.Rows
            Dim yy = CType(dgvr.Cells("选择").FormattedValue, Boolean)
            If yy = True Then
11:             Dim AssetNO = dgvr.Cells("财产编号").Value.ToString()
                Dim AssetNAME = dgvr.Cells("资产名称").Value.ToString()
                list.Add(AssetNO + "|" + AssetNAME)
            End If
        Next
        Return list
    End Function

    ''' <summary>
    ''' 勾选的资产是否没有维护项目
    ''' add by马跃平 2018-10-16
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveMaintenanceProjectMonth() As Boolean
        Dim yy = False
        For Each Str As String In GetCheckAsset()
            Dim sql = "SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,0 AS IsNotUsed,'' as  Remark  " & vbCrLf &
"FROM m_AssetMaintenanceType_t WHERE AssetName =N'" & Str.Split("|")(1) & "' and IsMpMonth=1  "
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("资产:" + Str.Split("|")(1) + "，没有设置保养项目,请核实!")
                yy = True
                Exit For
            End If
        Next
        Return yy
    End Function

    ''' <summary>
    ''' 勾选的资产是否没有维护项目
    ''' add by马跃平 2018-10-16
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsHaveMaintenanceProjectQuater() As Boolean
        Dim yy = False
        For Each Str As String In GetCheckAsset()
            Dim sql = "SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,0 AS IsNotUsed,'' as  Remark  " & vbCrLf &
"FROM m_AssetMaintenanceType_t WHERE AssetName =N'" & Str.Split("|")(1) & "' and IsMpQuarter=1  "
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("资产:" + Str.Split("|")(1) + "，没有设置保养项目,请核实!")
                yy = True
                Exit For
            End If
        Next
        Return yy
    End Function

    ''' <summary>
    ''' 批量季度保养
    ''' add by马跃平 2018-10-16
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SubQuartermaintain_Click(sender As Object, e As EventArgs) Handles SubQuartermaintain.Click
        Dim list = GetCheckAsset()
        If list.Count = 0 Then
            MessageUtils.ShowError("请勾选要保养的资产!")
            Exit Sub
        ElseIf IsHaveMaintenanceProjectQuater() = True Then
            Exit Sub
        ElseIf ExistMaintenanceToQuarter() = True Then
            Exit Sub
        End If
        Dim sql As System.Text.StringBuilder = New StringBuilder()
        For Each Str As String In list
            Dim sqlProject = "SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,0 AS IsNotUsed,'' as  Remark  " & vbCrLf &
"FROM m_AssetMaintenanceType_t WHERE AssetName =N'" & Str.Split("|")(1) & "' and IsMpQuarter=1  "
            Dim dt = DbOperateUtils.GetDataTable(sqlProject) '资产维护的项目
            For Each dr As DataRow In dt.Rows
                sql.Append("INSERT INTO m_AssetMaintenanceQuarter_t(AssetNo,MaintenanceProject,Quarter,Status,Remark,CreateTime,CreateUserID,year)")
                sql.Append(String.Format(" VALUES(N'{0}',N'{1}',CAST( datepart(quarter,GETDATE()) as varchar(10)),N'{2}',N'{3}',GETDATE(),N'{4}','{5}')",
                                           Str.Split("|")(0), dr("MaintenanceProject").ToString, "O", "批量季度保养", VbCommClass.VbCommClass.UseId, Date.Now.Year))
            Next
        Next
        Try
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("批量季度保养成功!")
            LoadAsset()
        Catch ex As Exception
            MessageUtils.ShowError("批量季度保养失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 保养记录明细
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiMaintenanceLog_Click(sender As Object, e As EventArgs) Handles tsmiMaintenanceLog.Click
        Dim frm = New FrmAssetMaintenanceLog()
        frm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 保养计划
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiMaintenancePlan_Click(sender As Object, e As EventArgs) Handles tsmiMaintenancePlan.Click
        Dim frm = New FrmMaintenancePlan()
        frm.ShowDialog()
    End Sub
End Class

Public Class KeyValue1
    Private _key As String
    Private _value As String
    Private _index As Integer

    Public Property Key() As String
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property
    Public Property Index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property
    Public Sub New(ByVal index As Integer, ByVal key As String, ByVal value As String)
        _index = index
        _key = key
        _value = value
    End Sub
End Class
