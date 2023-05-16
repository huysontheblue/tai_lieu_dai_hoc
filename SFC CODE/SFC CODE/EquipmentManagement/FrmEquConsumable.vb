Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MainFrame
Public Class FrmEquConsumable

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
        ConsumableNO
        ConsumableName
        Qty
        SafeQty
        Storage
        Price
        '消耗品编号, 消耗品名称,库存数量, 安全库存，库位,单价
    End Enum

    Private Enum ConsumableGrid
        ' checkbox = 0
        PartNumber
        ConsumableNO
        ConsumableName
        Storage
        Qty
        SafeQty
        GapQty
        Price
        CreateUserID
        FactoryID
        ProfitCenter
    End Enum

    Private currentBodyValue_Old As String = ""
    Private currentColumnName As String = ""
#End Region

#Region "初期化"

    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Me.DesignMode = False Then
                ' LabelPrintHelper.InitPrinter(cboPrinter)
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
                LoadEquConsumable()

                '绑定右键菜单
                'Me.dgvAsset.ContextMenuStrip = Me.ContextMenuStripAsset
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
        ' Dim strSql As String
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

            If Not String.IsNullOrEmpty(Me.txtSafeQty.Text) Then
                If Not IsNumeric(Me.txtSafeQty.Text.Trim()) Then
                    MessageUtils.ShowError("请填入数字！")
                    Return False
                End If
            End If


            'If Me.cboStatus.SelectedIndex = -1 Then
            '    MessageUtils.ShowError("请选择状态")
            '    Return False
            'End If

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
        Try
            Dim ConsumableNo As String = Me.txtConsumableNo.Text.Trim
            Dim Storage As String = Me.txtStorage.Text.Trim

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
            ' Dim strConsumableName As String = Me.txtConsumableName.Text.Trim()
            Dim strBSQL As New System.Text.StringBuilder
            '
            If OperateFlag = EditMode.ADD Then     '新增
                '消耗品编号是否存在
                strSql = "SELECT 1 FROM m_Consumable_t(nolock) WHERE ConsumableNo=N'" & ConsumableNo & "'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If Not CheckInput() Then
                    Exit Function
                End If

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("物品编号:" + ConsumableNo + " 已存在!")
                    Return False
                Else
                    strSql = " INSERT INTO m_Consumable_t(ConsumableNo, ConsumableName, Qty," &
                             " SafeQty,Storage,FactoryName,Profitcenter, CreateUserID, CreateTime)"
                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", ConsumableNo)
                    'strBSQL.AppendFormat("N'{0}',", strConsumableName)
                    strBSQL.AppendFormat("N'{0}',", Me.txtQty.Text.Trim)
                    strBSQL.AppendFormat("N'{0}',", Val(Me.txtSafeQty.Text.Trim))
                    strBSQL.AppendFormat("N'{0}',", Storage)
                    strBSQL.AppendFormat("N'{0}',", FactoryName)
                    strBSQL.AppendFormat("N'{0}',", Profitcenter)
                    strBSQL.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                    strBSQL.AppendFormat("getdate()")
                    strBSQL.Append(");")
                End If
            Else    '修改
                strSql = "UPDATE m_Consumable_t "
                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" SET ModifyUserID = N'{0}', ", VbCommClass.VbCommClass.UseId)
                strBSQL.AppendFormat(" ModifyTime = getdate(),")
                'strBSQL.AppendFormat("  ConsumableName= N'{0}' ,", strConsumableName)
                strBSQL.AppendFormat("  Qty= N'{0}' ,", Val(Me.txtQty.Text.Trim()))
                strBSQL.AppendFormat("  SafeQty= N'{0}' ,", Val(Me.txtSafeQty.Text.Trim()))
                strBSQL.AppendFormat("  Price = N'{0}' , ", Val(Me.txtPrice.Text))
                strBSQL.AppendFormat(" Storage = N'{0}' ", Storage)
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
        lsSQL = " SELECT UserName FROM m_Users_t(nolock) WHERE UserID ='" & strUserID & "'"
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
                Me.txtConsumableNo.Enabled = True
                ' Me.cboStatus.Enabled = False
                ' Me.cboStatus.Enabled = False
                Me.txtStorage.Enabled = False
            Case 1
                Me.txtConsumableNo.Enabled = True
                ' Me.cboStatus.Enabled = True
                ' Me.cboStatus.Enabled = True
                Me.txtStorage.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.lblId.Text = ""
        Me.txtConsumableNo.Text = ""
        Me.txtStorage.Text = ""
        ' Me.cboStatus.SelectedIndex = 0
        ' Me.cboStatus.SelectedIndex = 0

        ' Me.txtConsumableName.Text = String.Empty  'add by cq20171211
        Me.txtQty.Text = String.Empty
        Me.txtPrice.Text = String.Empty
        Me.txtSafeQty.Text = String.Empty

    End Sub
#End Region

#Region "给 GroupBox 面板控件赋值"
    Private Sub SetGroupBox()
        Dim index As Integer = TabEquipment.SelectedIndex
        If index = 0 Then
            SetControlValue(dgvConsumable)
        ElseIf index = 1 Then
            ' SetControlValue(dgvMA)
        ElseIf index = 2 Then
            'SetControlValue(dgvEqu)
        ElseIf index = 3 Then
            'SetControlValue(dgvFX)
        Else
            SetControlValue(dgvConsumable)
        End If
    End Sub

    Private Sub SetControlValue(dgGrid As DataGridView)

        If dgGrid.RowCount < 1 Then Exit Sub
        ''当前行没有时把第一行默认选中
        If Not IsNothing(dgGrid.Item(0, dgGrid.CurrentRow.Index).Value) Then
            Me.lblId.Text = dgGrid.Item(0, dgGrid.CurrentRow.Index).Value.ToString()
        Else
            '  Me.lblId.Text = dgGrid.Item(ConsumableGrid.checkbox, dgGrid.CurrentRow.Index).Value.ToString()
        End If

        Dim bigCategory As String = ""
        Dim middleCategory As String = ""
        Dim smallCategory As String = ""
        '  Dim dt As DataTable = GetCategoryData(Me.lblId.Text)
        'If dt.Rows.Count > 0 Then
        '    bigCategory = dt.Rows(0)(0).ToString
        '    middleCategory = dt.Rows(0)(1).ToString
        '    smallCategory = dt.Rows(0)(2).ToString
        'End If

        Me.txtConsumableNo.Text = dgGrid.Item(ConsumableGrid.ConsumableNO, dgGrid.CurrentRow.Index).Value.ToString()
        ' Me.txtConsumableName.Text = dgGrid.Item(ConsumableGrid.ConsumableName, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtSafeQty.Text = dgGrid.Item(ConsumableGrid.SafeQty, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtStorage.Text = dgGrid.Item(ConsumableGrid.Storage, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtQty.Text = dgGrid.Item(ConsumableGrid.Qty, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtPrice.Text = dgGrid.Item(ConsumableGrid.Price, dgGrid.CurrentRow.Index).Value.ToString()

        'Me.cboStatus.SelectedIndex = Me.cboStatus.FindString((dgGrid.Item(AssetGrid.Status, dgGrid.CurrentRow.Index).Value.ToString))
        ' Me.txtLine.Text = dgGrid.Item(EquipmentGrid.LineID, dgGrid.CurrentRow.Index).Value.ToString()

    End Sub
#End Region

#Region "工具条事件"

    '新增
    Private Sub toolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolNew.Click
        ''设置操作模式
        'OperateFlag = EditMode.ADD
        ''工具栏控件状态
        'SetControlStatus(EditMode.ADD)
        ''清除面板控件值
        'ClearGroupBox()
        ''面板控件可写
        'ToogleGroupBox(1)
        'Me.txtConsumableNo.Focus()
    End Sub
    '修改
    Private Sub toolModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModify.Click
        ''设置操作模式
        'OperateFlag = EditMode.EDIT
        ''工具栏控件状态
        'SetControlStatus(EditMode.EDIT)
        ''面板控件可写
        'ToogleGroupBox(1)
        ''面板控件赋值
        'SetGroupBox()
        'Me.txtConsumableNo.Enabled = False
        '' Me.cboStatus.Enabled = True
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
                LoadEquConsumable()
                SetControlStatus(EditMode.UNDO)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsumable", "btnSave_Click", "sys")
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
        ' cboStatus.Enabled = True
        'cboStatus.Enabled = True
        txtConsumableNo.Enabled = True
        Me.txtConsumableNo.ReadOnly = False
        Me.txtConsumableNo.Focus()
    End Sub
    '刷新
    Private Sub toolRefreshClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            LoadEquConsumable()

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
        'Dim strSql As String = ""
        'Dim sqlWhere As String = Nothing
        'Dim IsSearch As Boolean = True
        'strSql = " SELECT A.ID ,A.AssetNo 财产编号, A.AssetName 资产名称, " &
        '         " A.Model 规格型号,A.CStatus 资产使用状态," &
        '         " A.Qty 数量,A.STORAGE 储位,A.keeperid AS 保管人工号, A.KeeperName 保管人姓名 ,A.TempLocation 保管地点, A. storage 初始库位  " &
        '         " FROM m_Asset_t(nolock) A " &
        '         "  LEFT JOIN m_Users_t(nolock) C ON A.CreateUserID=C.UserID    " &
        '         " WHERE 1=1  " &
        '         EquManageCommon.GetFatoryProfitcenter("A")

        'If IsSearch = toolRefresh.Enabled Then '如果查询为true,就带查询条件
        '    'If cboSmallCategory.SelectedIndex = -1 Then
        '    '    MessageUtils.ShowError("请选择设备类别")
        '    '    Exit Sub
        '    'End If

        '    'If cboStatus.SelectedIndex = -1 Then
        '    '    MessageUtils.ShowError("请选择状态")
        '    '    Exit Sub
        '    'End If
        '    sqlWhere = GetSqlWhere()
        'End If

        'strSql = strSql + "  " & sqlWhere & " ORDER BY A.ID"

        'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        ''ExcelHelper.ExportDTtoExcel(dt, "载治具基本资料表", filename)
        'ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)


        ExcelUtils.LoadDataToExcel(dgvConsumable, Me.Text)
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

#Region "右健改变当前行号"
    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvConsumable.ClearSelection()
                dgvConsumable.Rows(e.RowIndex).Selected = True
                dgvConsumable.CurrentCell = dgvConsumable.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If
    End Sub

#End Region

#Region "背景色"
    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvConsumable.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    'Private Sub dgvMEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
    '    For Each item As DataGridViewRow In dgvConsumable.Rows

    '        If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
    '            item.DefaultCellStyle.ForeColor = Color.Red
    '        End If

    '        If item.Index Mod 2 = 0 Then
    '            item.DefaultCellStyle.BackColor = Color.WhiteSmoke
    '        End If
    '    Next
    'End Sub
    'Private Sub dgvZEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
    '    For Each item As DataGridViewRow In dgvConsumable.Rows

    '        If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
    '            item.DefaultCellStyle.ForeColor = Color.Red
    '        End If

    '        If item.Index Mod 2 = 0 Then
    '            item.DefaultCellStyle.BackColor = Color.WhiteSmoke
    '        End If
    '    Next
    'End Sub
#End Region

#Region "GridClick"
    Private Sub dgvConsumable_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumable.CellClick
        GridClick(dgvConsumable, e)
    End Sub

    Private Sub GridClick(dgGrid As DataGridView, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgGrid.RowCount < 1 Then Exit Sub
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
        Dim strConsumableNo As String = String.Empty

        'DB中消耗品编号
        Dim ConsumableNoSql As String = " SELECT ConsumableNO from m_Consumable_t WHERE usey='1' " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtConsumableNo As DataTable = DbOperateUtils.GetDataTable(ConsumableNoSql)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1

            Dim returnCode As String = ""

            '比对设备编号 
            If (DrrR(index)("ConsumableNO").ToString <> "") Then
                strConsumableNo = DrrR(index)("ConsumableNO").ToString
                If hastable.Contains(strConsumableNo) Then
                    MessageUtils.ShowError("上传文件中有重复的消耗品编号：'" + strConsumableNo + "'")
                    Return False
                End If
                If CheckExistUserColumns(dtConsumableNo, "ConsumableNO", strConsumableNo, returnCode) = True Then
                    MessageUtils.ShowError("不能上传重复的消耗品编号：'" + strConsumableNo + "'")
                    Return False
                End If
                hastable.Add(strConsumableNo, strConsumableNo)
            End If
        Next

        Return True
    End Function


    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.txtConsumableNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [ConsumableNo] LIKE N'%" & txtConsumableNo.Text.Trim().Replace("'", "''") & "%' ")
        End If

        'If Me.txtConsumableName.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND ConsumableName LIKE N'%" & txtConsumableName.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        'If Me.txtQty.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND CreateUserID like N'%" & txtQty.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        'If Not cboStatus.SelectedItem Is Nothing AndAlso Me.cboStatus.SelectedItem().ToString <> "" Then
        '    sbSqlWhere.Append(" AND A.Status = " & cboStatus.SelectedItem().ToString().Substring(0, 1) & " ")
        'End If

        '库位
        If Me.txtStorage.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        ''是否有效
        'If Me.ChkUseY.Checked = True Then
        '    sbSqlWhere.Append(" AND isnull(a.usey,'1') ='1' ")
        'End If

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
        'If cboPrinter.SelectedIndex = -1 Then
        '    MessageUtils.ShowError("请选择打印机")
        '    cboPrinter.Focus()
        '    Return False
        'End If
        If dics.Count <= 0 Then
            MessageUtils.ShowError("请选择需要列印的消耗品编号")
            Return False
        End If
        Return True
    End Function

    Private Function GetDeleteSQL(dgvGrid As DataGridView) As String
        Dim strSQL As String = String.Empty
        '移除删除功能，改为更新。
        For Each row As DataGridViewRow In dgvGrid.Rows
            'If Not row.Cells(ConsumableGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
            '       row.Cells(ConsumableGrid.checkbox).EditedFormattedValue.ToString = "True" Then
            '    ' strSQL &= " DELETE FROM m_Asset_t WHERE ID=" & row.Cells(AssetGrid.ID).Value.ToString & "" & vbNewLine
            '    'Modify by cq 20171213 
            '    strSQL &= " UPDATE m_Consumable_t SET usey='0'  WHERE ID=" & row.Cells(0).Value.ToString & "" & vbNewLine
            'End If
        Next
        GetDeleteSQL = strSQL
    End Function

    'Private Function GetCategoryData(id As String)
    '    Dim strSQL As String = " SELECT BigCategory ,MiddleCategory,SmallCategory  FROM m_Equipment_t WHERE id = '{0}'"
    '    strSQL = String.Format(strSQL, id)

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
    '    Return dt
    'End Function

#Region "加载数据"

    Private Sub LoadEquConsumable()
        Dim StrSql As String = ""
        Try

            'StrSql = " SELECT ProcessParameters 消耗品编号, A.ProcessParameters 消耗品名称," & _
            '"  A.Storage 库位, SUM((CASE INOUT  WHEN  1 THEN 1 ELSE 0 END ))  数量,A.SafeQty 安全库存," & _
            '"  '130' 单价," & _
            '"  A.UserID+'/'+E.UserName 创建人," &
            '"  FactoryName 厂区, Profitcenter 利润中心" &
            '" FROM m_Equipment_t(NOLOCK) A   " &
            '" LEFT JOIN m_Users_t E ON A.UserID=E.UserID WHERE 1=1 " &
            'EquManageCommon.GetFatoryProfitcenter("A")

            'If OperateFlag = EditMode.SEARCH Then
            '    StrSql = StrSql + GetSqlWhere()
            'End If

            ''是否有效
            ''If Me.ChkUseY.Checked = True Then
            'StrSql = StrSql + "  AND a.Status=1 "
            '' End If

            'StrSql = StrSql + " AND MiddleCategory='PJ' "

            'StrSql = StrSql + "  GROUP BY ProcessParameters,Storage,SafeQty,A.UserID,E.UserName,FactoryName,Profitcenter"
            'LoadData(StrSql, [Enum].Parse(GetType(EquipmentType), 0))



            ' Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
            ' Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
            Dim o_strEquPartID As String = Me.txtEquPartID.Text.Trim
            Dim ProcessParameters As String = Me.txtConsumableNo.Text.Trim
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter

            dgvConsumable.DataSource = Nothing 'Add by cq 20160701
            ' Dim strSql As String = ""

            'If CobMo.Text <> "" And CobMo.Text <> "ALL" Then
            '    Moid = CobMo.Text.Trim()
            'End If


            'If CobLineID.Text <> "" And CobLineID.Text <> "ALL" Then
            '    strLineID = CobLineID.Text.Trim
            'End If

            StrSql = " EXEC m_QueryEquConsumableData_p N'" & o_strEquPartID & "', N'" & ProcessParameters & "','" & FactoryName & "','" & Profitcenter & "'"
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                ToolStatusLabel.Text = dt.Rows.Count
                dgvConsumable.DataSource = dt

            Else
                MsgBox("未查询到相关信息！", MsgBoxStyle.DefaultButton1, "提示信息")
            End If

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
                        SetColumnsProperty(col, dgvConsumable, dt)
                    Case Else
                        SetColumnsProperty(col, dgvConsumable, dt)
                End Select
            End Using
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsumable", "LoadData", "Equ")
        End Try
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        Try
            If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
            dgGrid.DataSource = dt
            ' dgGrid.Columns.Insert(0, col)
            '"备注"列全屏显示
            ' dgGrid.Columns(ConsumableGrid.ID).Visible = False
            ' dgGrid.Columns(ConsumableGrid.Remark).Visible = False
            dgGrid.ReadOnly = False
            ' dgGrid.Columns(0).HeaderText = "   选择"
            ' SetSelectAll(dgGrid)
            ' dgGrid.Columns(ConsumableGrid.ID).Width = 40
            ' dgGrid.Columns(ConsumableGrid.checkbox).Width = 60
            dgGrid.Columns(ConsumableGrid.ConsumableNO).Width = 100
            dgGrid.Columns(ConsumableGrid.ConsumableName).Width = 105
            ' dgGrid.Columns(ConsumableGrid.Model).Width = 105
            ' dgGrid.Columns(ConsumableGrid.Status).Width = 80
            dgGrid.Columns(ConsumableGrid.Qty).Width = 80
            ' dgGrid.Columns(ConsumableGrid.KeeperName).Width = 95
            dgGrid.Columns(ConsumableGrid.Storage).Width = 105
            dgGrid.Columns(ConsumableGrid.FactoryID).Width = 60
            dgGrid.Columns(ConsumableGrid.ProfitCenter).Width = 80
            ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
            '
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsumable", "SetColumnsProperty", "sys")
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
                'row.Cells(ConsumableGrid.checkbox).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gvr.Rows
                ' row.Cells(ConsumableGrid.checkbox).Value = False
            Next
        End If
    End Sub
#End Region

    Private Sub toolImport_Click(sender As Object, e As EventArgs)
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
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 6, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" ConsumableNo IS NOT NULL  ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("FactoryName", "System.String", dtUploadData)
            TableAddColumns("Profitcenter", "System.String", dtUploadData)
            TableAddColumns("CreateUserID", "System.String", dtUploadData)
            TableAddColumns("CreateTime", "System.String", dtUploadData)


            '批量插入到DB中
            '设备类型及料号要将string 转int
            '消耗品编号, 消耗品名称， 库位,库存数量, 安全库存，单价
            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)

            dics2.Add("ConsumableNo", "ConsumableNo")
            dics2.Add("ConsumableName", "ConsumableName")
            dics2.Add("Qty", "Qty")
            dics2.Add("SafeQty", "SafeQty")
            dics2.Add("Storage", "Storage")
            dics2.Add("Price", "Price")
            dics2.Add("FactoryName", "FactoryName")
            dics2.Add("Profitcenter", "Profitcenter")
            dics2.Add("CreateUserID", "CreateUserID")
            dics2.Add("CreateTime", "CreateTime")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), _
                                      row(3).ToString(), row(4).ToString(),
                                      row(5).ToString(), _
                                      VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, _
                                      VbCommClass.VbCommClass.UseId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                                      )
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_Consumable_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    LoadEquConsumable()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsumable", "toolImport_Click", "sys")
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
                sql = GetDeleteSQL(dgvConsumable)
            Case Else
                sql = GetDeleteSQL(dgvConsumable)
        End Select
        If String.IsNullOrEmpty(sql) Then
            MessageUtils.ShowError("请选择要删除的财产!")
            Exit Sub
        End If
        Try
            If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                DbOperateUtils.ExecSQL(sql)
                MessageUtils.ShowInformation("删除成功")
                LoadEquConsumable()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub ToolLend_Click(sender As Object, e As EventArgs)
        Dim strIDList As String = String.Empty
        For Each row As DataGridViewRow In dgvConsumable.Rows
            'If Not row.Cells(ConsumableGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
            '       row.Cells(ConsumableGrid.checkbox).EditedFormattedValue.ToString = "True" Then
            '    ' strIDList = strIDList + row.Cells(ConsumableGrid.ID).Value.ToString + ","
            'End If
        Next

        If Not String.IsNullOrEmpty(strIDList) AndAlso strIDList.Length > 0 Then
            strIDList = strIDList.Substring(0, strIDList.Length - 1)
        End If

        If String.IsNullOrEmpty(strIDList) Then
            MessageUtils.ShowError("请勾选要领用的消耗品！")
            Exit Sub
        End If

        Dim frmLend As New FrmConsumableLend
        frmLend.lblID.Text = strIDList
        '  frmLend.txtLineID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value
        frmLend.StartPosition = FormStartPosition.CenterScreen
        frmLend.Owner = Me
        frmLend.ShowDialog()

    End Sub

    Private Sub ToolReturn_Click(sender As Object, e As EventArgs)

        Dim strConsumableNo As String = String.Empty
        Dim strStorage As String = String.Empty

        For Each row As DataGridViewRow In dgvConsumable.Rows
            'If Not row.Cells(ConsumableGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
            '       row.Cells(ConsumableGrid.checkbox).EditedFormattedValue.ToString = "True" Then
            '    strConsumableNo = strConsumableNo + row.Cells(ConsumableGrid.ConsumableNO).Value.ToString
            '    strStorage = strStorage + row.Cells(ConsumableGrid.Storage).Value.ToString
            '    Exit For
            'End If
        Next

        If String.IsNullOrEmpty(strConsumableNo) Then
            MessageUtils.ShowError("请勾选要归还的消耗品！")
            Exit Sub
        End If

        Dim frmStoreIn As New FrmConsumableIn
        frmStoreIn.txtConsumableNo.Text = strConsumableNo
        frmStoreIn.txtStorage.Text = strStorage
        '  frmLend.txtLineID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value
        frmStoreIn.StartPosition = FormStartPosition.CenterScreen
        frmStoreIn.Owner = Me
        frmStoreIn.ShowDialog()
    End Sub

    Private Sub toolLendRecord_Click(sender As Object, e As EventArgs)
        Dim frmLendBorrow As New FrmAssetLendBorrowLog

        frmLendBorrow.StartPosition = FormStartPosition.CenterScreen
        frmLendBorrow.Owner = Me
        frmLendBorrow.ShowDialog()
    End Sub

    Private Sub dgvConsumable_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvConsumable.CellPainting
        If e.RowIndex = -1 Then Exit Sub
        Dim o_iTempSafeQty As Integer = 0

        For Each dr As DataGridViewRow In Me.dgvConsumable.Rows

            If IsDBNull(dr.Cells(ConsumableGrid.SafeQty).Value) Then
                o_iTempSafeQty = 0
            Else
                o_iTempSafeQty = Val(dr.Cells(ConsumableGrid.SafeQty).Value.ToString)
            End If

            If Val(dr.Cells(ConsumableGrid.Qty).Value.ToString) < o_iTempSafeQty Then
                dr.DefaultCellStyle.BackColor = Drawing.Color.Tomato
            End If
        Next

        '     Case "5", "05"
        'item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.MistyRose
        '            Case "A05"
        'item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Tomato
    End Sub


    '  PartNumber 五金料号, ProcessParameters 消耗品编号, A.Storage 库位, 

    Private Sub dgvConsumable_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsumable.CellLeave

        If dgvConsumable.CurrentCell.EditedFormattedValue.ToString <> currentBodyValue_Old Then
            '
            Dim PartId As String = dgvConsumable.CurrentRow.Cells(ConsumableGrid.PartNumber).Value.ToString

            If String.IsNullOrEmpty(PartId) Then Exit Sub


            UpdateData(PartId)

        End If


    End Sub

    Private Sub UpdateData(PartId)
        Try
            Dim ConsumableNO As String = dgvConsumable.CurrentRow.Cells(ConsumableGrid.ConsumableNO).Value.ToString
            Dim Storage As String = dgvConsumable.CurrentRow.Cells(ConsumableGrid.Storage).Value.ToString
            Dim editValue As String = dgvConsumable.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

            Dim strSQL As String = GetBodyUpdateSQL(currentColumnName, editValue, PartId, currentBodyValue_Old, ConsumableNO, Storage)

            If Not String.IsNullOrEmpty(strSQL) Then
                DbOperateUtils.ExecSQL(strSQL)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Function GetBodyUpdateSQL(currentColumnName As String, editValue As String, PartId As String, oldValue As String, ConsumableNO As String, Storage As String) As String
        Dim strSQL As String = String.Empty

        '  Dim strWhere As String = "WHERE PartID='" & runCardId & "' AND StationID = '" & stationId & "' and StationSQ='" & StationSeq & "' " &

        ' a.PartNumber 五金料号,ProcessParameters消耗品编号

        If currentColumnName = "安全库存" Then

            strSQL = " UPDATE m_Equipment_t SET SafeQty=" & editValue & "  " & _
                     " WHERE PartNumber = N'" & PartId & "' " & _
                     " AND ProcessParameters=N'" & ConsumableNO & "' AND  Storage=N'" & Storage & "'  " & _
                     " AND FactoryName='" & VbCommClass.VbCommClass.Factory & "' " & _
                     " AND Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' "


        End If
        GetBodyUpdateSQL = strSQL
    End Function


    'Private Sub dgvConsumable_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvConsumable.DataBindingComplete
    '    If dgvConsumable.RowCount > 0 Then

    '    End If
    'End Sub

    Private Sub dgvConsumable_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsumable.CellEnter

        If Not IsNothing(dgvConsumable.CurrentCell) Then
            currentBodyValue_Old = dgvConsumable.CurrentCell.FormattedValue.ToString
            currentColumnName = dgvConsumable.CurrentCell.OwningColumn.Name
        End If
    End Sub
End Class



