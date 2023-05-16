Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MainFrame
Public Class FrmLineBorrow

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
        EquipmentNO
        BigCategory
        MiddleCategory
        SmallCategory
        PartNumber
        ProcessParameters
        ServiceCount
        AlertCount
        RemainCount
        Storage
        UserID
    End Enum

    Private Enum EquipmentGrid
        checkbox = 0
        EquipmentNO
        SmallCategory
        PartNumber
        ProcessParameters
        Status
        Storage
        InOut
        LineID
        OutUserID
        OutTime
        UserID
        Intime
        FactoryID
        ProfitCenter
        Remark
        ID
        '状态，储位， 在库状态，借出线别， 借出人，借出时间，创建人，创建时间，厂区，利润中心
    End Enum

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
                '绑定设备分类
                EquManageCommon.BindComboxCategory(cboBigCategory, "BIG")
                EquManageCommon.BindComboxCategory(cboMiddleCategory, "MID")

                '设置工具栏按钮状态
                SetControlStatus(Me.OperateFlag)
                '设置面板组控件状态
                ToogleGroupBox(0)
                '绑定数据
                LoadEquipment()
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
                'Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)
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
        ' toolDelete.Enabled = bFlag
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
        Dim strSql As String
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
            'check partnumber
            strSql = "SELECT TAvcPart FROM m_PartContrast_t(nolock) WHERE TAvcPart=N'" & Me.txtEquipmentPN.Text.Trim & "' AND type ='E' AND (UseY='Y' OR  UseY='1')"
            '
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

            If (dt.Rows.Count = 0) Then
                MessageUtils.ShowError("设备料号:" & Me.txtEquipmentPN.Text.Trim & "不存在或者无效,请检查料件编号")
                txtEquipmentPN.Focus()
                Return False
            End If

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
            If Me.cboSmallCategory.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择设备类别")
                Return False
            End If
            If Me.cboInOut.SelectedIndex = -1 Then
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
        Try
            Dim EquipmentNo As String = Me.txtEquipmentNo.Text.Trim
            Dim CategoryID As Integer = CInt(Me.cboSmallCategory.SelectedValue.ToString)
            Dim PartNumber As String = txtEquipmentPN.Text.Trim
            'Dim ProcessParameters As String = Me.txtProcessParameters.Text.Trim
            'Dim ServiceCount As Integer = CInt(Me.txtServiceCount.Text.Trim)
            'Dim AlertCount As Integer = CInt(Me.txtAlertCount.Text.Trim)
            'Dim RemainCount As Integer = CInt(Me.txtRemainCount.Text.Trim)
            Dim Status As Integer = Convert.ToInt16(cboInOut.SelectedItem.ToString().Substring(0, 1))
            Dim Storage As String = Me.txtStorage.Text.Trim
            Dim line As String = Me.txtLine.Text.Trim
            Dim bigCategory As String = cboBigCategory.SelectedValue.ToString
            Dim midCategory As String = cboMiddleCategory.SelectedValue.ToString
            Dim smallCategory As String = cboSmallCategory.SelectedValue.ToString

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
            Dim strBSQL As New System.Text.StringBuilder
            '
            If OperateFlag = EditMode.ADD Then     '新增
                '设备编号是否存在
                strSql = "SELECT 1 FROM m_Equipment_t(nolock) where EquipmentNo=N'" & EquipmentNo & "'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("设备编号:" + EquipmentNo + " 已存在!")
                    Return False
                Else
                    If EquipmentNo = "" Then
                        EquipmentNo = EquipmentNoMAX(bigCategory, midCategory)
                    End If

                    strSql = " INSERT INTO m_Equipment_t(EquipmentNo,BigCategory,MiddleCategory,SmallCategory,ProcessParameters,ServiceCount,AlertCount,RemainCount," &
                             " Status,UserID,InTime,Storage,PartNumber,InOut,FactoryName,Profitcenter)"

                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", EquipmentNo)
                    strBSQL.AppendFormat("N'{0}',", bigCategory)
                    strBSQL.AppendFormat("N'{0}',", midCategory)
                    strBSQL.AppendFormat("N'{0}',", smallCategory)
                    strBSQL.AppendFormat("N'{0}',", 0)
                    strBSQL.AppendFormat("N'{0}',", 0)
                    strBSQL.AppendFormat("N'{0}',", 0)
                    strBSQL.AppendFormat("N'{0}',", 0)
                    strBSQL.AppendFormat("N'{0}',", Status)
                    strBSQL.AppendFormat("N'{0}',", userId)
                    strBSQL.AppendFormat("getdate(),")
                    strBSQL.AppendFormat("N'{0}',", Storage)
                    strBSQL.AppendFormat("N'{0}',", PartNumber)
                    strBSQL.AppendFormat("1,")
                    strBSQL.AppendFormat("N'{0}',", FactoryName)
                    strBSQL.AppendFormat("N'{0}'", Profitcenter)
                    strBSQL.Append(");")

                End If
            Else    '修改
                strSql = "UPDATE m_Equipment_t "

                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" SET BigCategory = N'{0}', ", bigCategory)
                strBSQL.AppendFormat(" MiddleCategory = N'{0}', ", midCategory)
                strBSQL.AppendFormat(" SmallCategory = N'{0}', ", smallCategory)
                strBSQL.AppendFormat(" PartNumber = N'{0}' ,", PartNumber)
                strBSQL.AppendFormat(" ProcessParameters = N'{0}' ,", 0)
                strBSQL.AppendFormat(" Status = N'{0}',", Status)
                strBSQL.AppendFormat(" ServiceCount = N'{0}', ", 0)
                strBSQL.AppendFormat(" AlertCount = N'{0}', ", 0)
                strBSQL.AppendFormat(" RemainCount = N'{0}', ", 0)
                strBSQL.AppendFormat(" Storage = N'{0}', ", Storage)
                strBSQL.AppendFormat(" UserID = N'{0}', ", userId)
                strBSQL.AppendFormat(" InTime=getdate() ")
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
#End Region

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                Me.txtEquipmentNo.Enabled = False
                Me.txtEquipmentPN.Enabled = False
                'Me.txtProcessParameters.Enabled = False
                'Me.txtRemainCount.Enabled = False
                'Me.txtServiceCount.Enabled = False
                'Me.txtAlertCount.Enabled = False
                Me.cboStatus.Enabled = False
                Me.cboInOut.Enabled = False
                Me.cboBigCategory.Enabled = False
                Me.cboMiddleCategory.Enabled = False
                Me.cboSmallCategory.Enabled = False
                Me.txtStorage.Enabled = False
                Me.txtLine.Enabled = False
                ' Me.cboPrinter.Enabled = True
            Case 1
                Me.txtEquipmentNo.Enabled = True
                Me.txtEquipmentPN.Enabled = True
                ' Me.txtProcessParameters.Enabled = True
                'Me.txtRemainCount.Enabled = True
                'Me.txtServiceCount.Enabled = True
                'Me.txtAlertCount.Enabled = True
                Me.cboStatus.Enabled = True
                Me.cboInOut.Enabled = True
                Me.cboBigCategory.Enabled = True
                Me.cboMiddleCategory.Enabled = True
                Me.cboSmallCategory.Enabled = True
                Me.txtStorage.Enabled = True
                Me.txtLine.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.lblId.Text = ""
        Me.txtEquipmentNo.Text = ""
        Me.txtEquipmentPN.Text = ""
        'Me.txtProcessParameters.Text = ""
        'Me.txtRemainCount.Text = ""
        'Me.txtServiceCount.Text = ""
        'Me.txtAlertCount.Text = ""
        Me.txtStorage.Text = ""
        Me.cboBigCategory.SelectedIndex = 0
        Me.cboMiddleCategory.SelectedIndex = 0
        Me.cboSmallCategory.SelectedIndex = 0
        Me.cboStatus.SelectedIndex = 0
        Me.cboInOut.SelectedIndex = 0
        Me.txtLine.Text = ""
    End Sub
#End Region

#Region "给 GroupBox 面板控件赋值"
    Private Sub SetGroupBox()
        Dim index As Integer = TabEquipment.SelectedIndex
        If index = 0 Then
            SetControlValue(dgvEqu)
        ElseIf index = 1 Then
            ' SetControlValue(dgvMA)
        ElseIf index = 2 Then
            'SetControlValue(dgvEqu)
        ElseIf index = 3 Then
            'SetControlValue(dgvFX)
        Else
            SetControlValue(dgvEqu)
        End If
    End Sub

    Private Sub SetControlValue(dgGrid As DataGridView)

        If dgGrid.RowCount < 1 Then Exit Sub
        ''当前行没有时把第一行默认选中
        If dgGrid.Item(EquipmentGrid.ID, dgGrid.CurrentRow.Index).Value IsNot Nothing Then
            Me.lblId.Text = dgGrid.Item(EquipmentGrid.ID, dgGrid.CurrentRow.Index).Value.ToString()
        Else
            Me.lblId.Text = dgGrid.Item(EquipmentGrid.checkbox, dgGrid.CurrentRow.Index).Value.ToString()
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

        Me.txtEquipmentNo.Text = dgGrid.Item(EquipmentGrid.EquipmentNO, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtEquipmentPN.Text = dgGrid.Item(EquipmentGrid.PartNumber, dgGrid.CurrentRow.Index).Value.ToString()
        'Me.txtProcessParameters.Text = dgGrid.Item(EquipmentGrid.ProcessParameters, dgGrid.CurrentRow.Index).Value.ToString()
        'Me.txtServiceCount.Text = dgGrid.Item(EquipmentGrid.ServiceCount, dgGrid.CurrentRow.Index).Value.ToString()
        'Me.txtAlertCount.Text = dgGrid.Item(EquipmentGrid.AlertCount, dgGrid.CurrentRow.Index).Value.ToString()
        'Me.txtRemainCount.Text = dgGrid.Item(EquipmentGrid.RemainCount, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtStorage.Text = dgGrid.Item(EquipmentGrid.Storage, dgGrid.CurrentRow.Index).Value.ToString()
        Me.cboBigCategory.SelectedValue = bigCategory
        Me.cboMiddleCategory.SelectedValue = middleCategory
        Me.cboSmallCategory.SelectedValue = smallCategory
        Me.cboStatus.SelectedIndex = Me.cboStatus.FindString((dgGrid.Item(EquipmentGrid.Status, dgGrid.CurrentRow.Index).Value.ToString))
        Me.cboInOut.SelectedIndex = Me.cboInOut.FindString(dgGrid.Item(EquipmentGrid.InOut, dgGrid.CurrentRow.Index).Value.ToString)
        Me.txtLine.Text = dgGrid.Item(EquipmentGrid.LineID, dgGrid.CurrentRow.Index).Value.ToString()

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
        Me.txtEquipmentNo.Focus()
        Me.cboStatus.SelectedIndex = 2 : Me.cboInOut.SelectedIndex = 2
        Me.txtLine.ReadOnly = True
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
        Me.txtEquipmentNo.Enabled = False
        Me.cboInOut.Enabled = False : Me.txtLine.ReadOnly = True
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
                LoadEquipment()
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
        txtLine.Enabled = True
        txtLine.ReadOnly = False
        cboInOut.Enabled = True
        txtEquipmentNo.Enabled = True
        Me.txtEquipmentNo.ReadOnly = False
        Me.txtEquipmentNo.Focus()
    End Sub
    '刷新
    Private Sub toolRefreshClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            LoadEquipment()
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
        strSql = " SELECT A.ID ,A.EquipmentNo 设备编号,D.NAME 设备大类,E.NAME 设备中类,F.NAME 设备小类, A.PartNumber 设备料号, " &
                 " A.ProcessParameters 加工参数,A.ServiceCount 使用次数,A.AlertCount 预警次数," &
                 " A.RemainCount 剩下次数,A.STORAGE 储位,A.UserID AS 创建人ID, C.UserName 创建人姓名 ,A.InTime 创建时间,A.Status 状态,A.Remark 备注 " &
                 " FROM m_Equipment_t(nolock) A " &
                 "  LEFT JOIN m_Users_t(nolock) C ON A.UserID=C.UserID    " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) D ON A.BigCategory=D.CODE AND D.TYPE = 'BIG'  " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) E ON A.MiddleCategory=E.CODE AND E.TYPE = 'MID'  " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) F ON A.SmallCategory=F.CODE AND F.TYPE = A.MiddleCategory " &
                 " WHERE 1=1  AND A.Status =1 " &
                 EquManageCommon.GetFatoryProfitcenter("A")

        If IsSearch = toolRefresh.Enabled Then '如果查询为true,就带查询条件
            If cboSmallCategory.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择设备类别")
                Exit Sub
            End If

            If cboInOut.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Exit Sub
            End If
            sqlWhere = GetSqlWhere()
        End If

        strSql = strSql + "  " & sqlWhere & " ORDER BY A.INTIME DESC"

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

    '中分类选择改变事件
    Private Sub cboMiddleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMiddleCategory.SelectedIndexChanged
        If String.IsNullOrEmpty(cboMiddleCategory.SelectedValue.ToString) = False Then
            EquManageCommon.BindComboxCategory(cboSmallCategory, cboMiddleCategory.SelectedValue.ToString)
            '为EBU处暂时设置，把6.测试设置为默认
            If cboMiddleCategory.SelectedValue.ToString = "FX" Then
                cboSmallCategory.SelectedValue = 6
            End If
        End If
    End Sub
#End Region

#Region "右健改变当前行号"
    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvEqu.ClearSelection()
                dgvEqu.Rows(e.RowIndex).Selected = True
                dgvEqu.CurrentCell = dgvEqu.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If
    End Sub

#End Region


#Region "背景色"
    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvEqu.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvMEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvEqu.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvZEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvEqu.Rows

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
    Private Sub dgvEqu_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEqu.CellClick
        GridClick(dgvEqu, e)
    End Sub

    'Private Sub dgvFX_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFX.CellClick, dgvEqu.CellClick
    '    GridClick(dgvFX, e)
    'End Sub
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
        'DB中设备类别
        Dim categorytypesql As String = " SELECT CODE,NAME FROM m_EquipmentCategory_t where status = 1"
        Dim cytypeDT As DataTable = DbOperateUtils.GetDataTable(categorytypesql)

        Dim categorytypeSmallsql As String = " SELECT CODE,NAME FROM m_EquipmentCategory_t where status = 1 and TYPE <> 'MID'"
        Dim cytypeSamallDT As DataTable = DbOperateUtils.GetDataTable(categorytypeSmallsql)

        'DB中设备编号
        Dim equPNSql As String = " select EquipmentNo from m_Equipment_t where 1=1 " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtEquPN As DataTable = DbOperateUtils.GetDataTable(equPNSql)

        'DB中设备料号
        Dim partnumberSql As String = " select TAvcPart from m_PartContrast_t where type = 'E' "
        Dim dtPN As DataTable = DbOperateUtils.GetDataTable(partnumberSql)

        'Dim ht As New Hashtable
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1
            '设备类别
            Dim bigCategory As String = DrrR(index)(CDImportGrid.BigCategory.ToString).ToString.Trim
            Dim returnCode As String = ""
            If bigCategory <> "" Then
                If CheckExistUserColumns(cytypeDT, "NAME", bigCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备大类没有在资料库中：'" + bigCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.BigCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备大类有空值,请检查后重新上传。")
                Return False
            End If

            Dim middleCategory As String = DrrR(index)(CDImportGrid.MiddleCategory.ToString).ToString.Trim
            If middleCategory <> "" Then
                If CheckExistUserColumns(cytypeDT, "NAME", middleCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备中类没有在资料库中：'" + middleCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.MiddleCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备中类有空值,请检查后重新上传。")
                Return False
            End If

            Dim smallCategory As String = DrrR(index)(CDImportGrid.SmallCategory.ToString).ToString.Trim
            If smallCategory <> "" Then
                If CheckExistUserColumns(cytypeSamallDT, "NAME", smallCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备小类没有在资料库中：'" + smallCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.SmallCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备小类有空值,请检查后重新上传。")
                Return False
            End If


            '比对设备编号 
            If (DrrR(index)("EquipmentNO").ToString <> "") Then
                If hastable.Contains(DrrR(index)("EquipmentNO")) Then
                    MessageUtils.ShowError("上传文件中有重复的设备编号：'" + DrrR(index)("EquipmentNO").ToString + "'")
                    Return False
                End If
                If CheckExistUserColumns(dtEquPN, "EquipmentNo", DrrR(index)("EquipmentNO").ToString, returnCode) = True Then
                    MessageUtils.ShowError("不能上传重复的设备编号：'" + DrrR(index)("EquipmentNO").ToString + "'")
                    Return False
                End If
                hastable.Add(DrrR(index)("EquipmentNO"), DrrR(index)("EquipmentNO"))
            Else
                '自动生成新的设备编号
                Dim bigCategoryCode As String = DrrR(index)(CDImportGrid.BigCategory.ToString)
                Dim middelCategoryCode As String = DrrR(index)(CDImportGrid.MiddleCategory.ToString)
                If hastable.Contains(bigCategoryCode + middelCategoryCode) = False Then
                    firstNo = EquipmentNoMAX(bigCategoryCode, middelCategoryCode)
                    hastable.Add(bigCategoryCode + middelCategoryCode, firstNo)
                    DrrR(index)("EquipmentNO") = firstNo
                Else
                    firstNo = hastable(bigCategoryCode + middelCategoryCode).ToString
                    DrrR(index)("EquipmentNO") = firstNo.Substring(0, 4) + CStr(CInt(firstNo.Substring(4)) + 1)
                    hastable.Remove(bigCategoryCode + middelCategoryCode)
                    hastable.Add(bigCategoryCode + middelCategoryCode, DrrR(index)("EquipmentNO"))
                End If
            End If

            '比对设备料号
            If DrrR(index)("PartNumber").ToString <> "" Then
                If CheckExistUserColumns(dtPN, "TAvcPart", DrrR(index)("PartNumber").ToString, returnCode) = False Then
                    MessageUtils.ShowError("上传设备料号没有在资料库中：'" + DrrR(index)("PartNumber").ToString + "'")
                    Return False
                Else
                    'DrrR(index)("PartNumber") = returnCode
                End If
            Else
                MessageUtils.ShowError("设备料号有空值,请检查后重新上传。")
                Return False
            End If
        Next

        Return True
    End Function

    '根据厂区和分类取得设备中最大的值
    Private Function EquipmentNoMAX(bigCategory As String, midCategory As String) As String
        Dim strSQL As String =
            "   DECLARE @STARTNO VARCHAR(20)" &
            "   DECLARE @EquipmentNo VARCHAR(20)" &
            "   SET @STARTNO = @BigCategory + @MiddleCategory + CONVERT(VARCHAR(4),GETDATE(),112) + '000000' " &
            "   SELECT @EquipmentNo = ISNULL(MAX(EquipmentNo),@STARTNO) FROM m_Equipment_t " &
            "   WHERE FactoryName=@FactoryName AND Profitcenter=@Profitcenter  " &
            "   AND BigCategory = @BigCategory AND MiddleCategory = @MiddleCategory AND EquipmentNo LIKE @BigCategory + @MiddleCategory + '%'" &
            "   SET @EquipmentNo = @BigCategory + @MiddleCategory + CAST((SUBSTRING (@EquipmentNo,5,10)+1) AS VARCHAR)" &
            "   SELECT  ISNULL(@EquipmentNo,'')"

        Dim pars As ArrayList = New ArrayList

        pars.Add(String.Format("FactoryName|{0}", VbCommClass.VbCommClass.Factory))
        pars.Add(String.Format("Profitcenter|{0}", VbCommClass.VbCommClass.profitcenter))
        pars.Add(String.Format("BigCategory|{0}", bigCategory))
        pars.Add(String.Format("MiddleCategory|{0}", midCategory))

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL, pars)
        Return dt.Rows(0)(0).ToString
    End Function

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If cboSmallCategory.Enabled = True Then
                If Not cboSmallCategory.SelectedValue Is Nothing AndAlso cboSmallCategory.SelectedValue.ToString <> "" Then
                    Dim id As String = cboSmallCategory.SelectedValue.ToString
                    If id = "System.Data.DataRowView" Then Exit Sub

                    Dim sql As String = " SELECT ServiceCount,AlertCount,RemainCount  FROM m_EquipmentCategory_t WHERE ID = " + id

                    Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)

                    If dt.Rows.Count > 0 Then
                        'Me.txtServiceCount.Text = dt.Rows(0)(0).ToString
                        'Me.txtAlertCount.Text = dt.Rows(0)(1).ToString
                        'Me.txtRemainCount.Text = dt.Rows(0)(2).ToString
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabEquipment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabEquipment.SelectedIndexChanged
        cboMiddleCategory.SelectedIndex = TabEquipment.SelectedIndex + 1
        LoadEquipment()
    End Sub

    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.cboBigCategory.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND A.BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboMiddleCategory.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND A.MiddleCategory = N'" & Me.cboMiddleCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboSmallCategory.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND A.SmallCategory = N'" & Me.cboSmallCategory.SelectedValue.ToString & "' ")
        End If

        If Me.txtEquipmentNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [EquipmentNo] like N'%" & txtEquipmentNo.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.txtEquipmentPN.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [PartNumber] like N'%" & txtEquipmentPN.Text.Trim().Replace("'", "''") & "%' ")
        End If

        '是否有效
        If Not cboStatus.SelectedItem Is Nothing AndAlso Me.cboStatus.SelectedItem().ToString <> "" Then
            sbSqlWhere.Append(" AND A.Status = " & cboStatus.SelectedItem().ToString().Substring(0, 1) & " ")
        End If

        '是否在库
        If Not cboInOut.SelectedItem Is Nothing AndAlso Me.cboInOut.SelectedItem().ToString <> "" Then
            sbSqlWhere.Append(" AND A.InOut = " & cboInOut.SelectedItem().ToString().Substring(0, 1) & " ")
        End If

        'If Me.txtServiceCount.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND ServiceCount like N'%" & txtServiceCount.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        'If Me.txtAlertCount.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND AlertCount like N'%" & txtAlertCount.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        'If Me.txtRemainCount.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND RemainCount like N'%" & txtRemainCount.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        'If Me.txtProcessParameters.Text.Trim() <> "" Then
        '    sbSqlWhere.Append(" AND ProcessParameters like N'%" & txtProcessParameters.Text.Trim().Replace("'", "''") & "%' ")
        'End If

        If Me.txtStorage.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        If Me.txtLine.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND A.LineId like N'%" & Me.txtLine.Text.Trim & "%' ")
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
        'If cboPrinter.SelectedIndex = -1 Then
        '    MessageUtils.ShowError("请选择打印机")
        '    cboPrinter.Focus()
        '    Return False
        'End If
        If dics.Count <= 0 Then
            MessageUtils.ShowError("请选择需要列印的工治具编号")
            Return False
        End If
        Return True
    End Function

    '检查 借出的工治具不能删除
    Private Function CheckStatus(dgvGrid As DataGridView) As Boolean
        Dim strSQL As String = String.Empty

        '借出的工治具不能删除。
        For Each row As DataGridViewRow In dgvGrid.Rows
            If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                If Not row.Cells(EquipmentGrid.InOut).EditedFormattedValue Is Nothing AndAlso
                row.Cells(EquipmentGrid.InOut).EditedFormattedValue.ToString.Substring(0, 1) = "0" Then
                    MessageUtils.ShowError("借出的工治具不能删除!")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function GetDeleteSQL(dgvGrid As DataGridView) As String
        Dim strSQL As String = String.Empty

        '移除删除功能，改为更新。
        For Each row As DataGridViewRow In dgvGrid.Rows
            If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                   row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                strSQL &= " DELETE FROM M_EQUIPMENT_T WHERE ID=" & row.Cells(EquipmentGrid.ID).Value.ToString & "" & vbNewLine
                'strSQL &= " UPDATE M_EQUIPMENT_T SET Status = 0 WHERE ID=" & row.Cells(EquipmentGrid.ID).Value.ToString & "" & vbNewLine
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

    Private Sub LoadEquipment()
        Try
            '  " A.SERVICECOUNT 使用次数,A.ALERTCOUNT 预警次数,A.REMAINCOUNT 剩下次数," &
            Dim StrSql As String = ""

            StrSql = " SELECT TOP 200 A.EQUIPMENTNO 设备编号, C.NAME 设备类型, A.PARTNUMBER 设备料号," & _
            " A.PROCESSPARAMETERS 加工参数," & _
            " CASE A.STATUS WHEN 1 THEN N'1.有效' ELSE N'0.无效' END 状态,A.STORAGE 储位," &
            " CASE A.InOut WHEN 1 THEN N'1.在库' ELSE N'0.借出' END 在库状态,A.LINEID 借出线别," &
            " OutUserID+'/'+D.UserName 借出人,OutTime 借出时间 ,A.USERID+'/'+E.UserName 创建人," &
            " A.INTIME 创建时间 ,A.FactoryName 厂区,A.Profitcenter 利润中心,A.REMARK 备注,A.ID " &
            " FROM M_EQUIPMENT_T(NOLOCK) A  LEFT JOIN M_EQUIPMENTCATEGORY_T(NOLOCK) C " &
            " ON A.SmallCategory=C.CODE AND C.TYPE =A.MiddleCategory  LEFT JOIN m_Users_t D ON A.OutUserID=D.UserID" &
            " LEFT JOIN m_Users_t E ON A.UserID=E.UserID WHERE 1=1 and A.InOut =0  " &
            EquManageCommon.GetFatoryProfitcenter("A")

            If OperateFlag = EditMode.SEARCH Then
                StrSql = StrSql + GetSqlWhere()
            End If

            'Dim index = TabEquipment.SelectedIndex
            'If cboMiddleCategory.Text = "" Then
            '    StrSql = StrSql + " AND A.MiddleCategory='" & [Enum].Parse(GetType(EquipmentType), index.ToString).ToString & "'"
            'Else
            '    StrSql = StrSql + " AND A.MiddleCategory='" & cboMiddleCategory.SelectedValue.ToString & "'"
            '    TabEquipment.SelectedIndex = cboMiddleCategory.SelectedIndex - 1
            'End If

            StrSql = StrSql + " ORDER BY A.INTIME DESC "
            LoadData(StrSql, [Enum].Parse(GetType(EquipmentType), 0))
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
        Using dt As DataTable = DbOperateUtils.GetDataTable(Sql)
            Select Case type
                Case EquipmentType.PA
                    SetColumnsProperty(col, dgvEqu, dt)
                Case Else
                    SetColumnsProperty(col, dgvEqu, dt)
            End Select
        End Using
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
        dgGrid.DataSource = dt
        dgGrid.Columns.Insert(0, col)
        '"备注"列全屏显示
        dgGrid.Columns(EquipmentGrid.ID).Visible = False
        dgGrid.Columns(EquipmentGrid.Remark).Visible = False
        dgGrid.ReadOnly = False
        dgGrid.Columns(0).HeaderText = "   选择"
        SetSelectAll(dgGrid)
        dgGrid.Columns(EquipmentGrid.ID).Width = 40
        dgGrid.Columns(EquipmentGrid.checkbox).Width = 60
        dgGrid.Columns(EquipmentGrid.EquipmentNO).Width = 100
        dgGrid.Columns(EquipmentGrid.SmallCategory).Width = 80
        dgGrid.Columns(EquipmentGrid.PartNumber).Width = 80
        dgGrid.Columns(EquipmentGrid.ProcessParameters).Width = 110
        'dgGrid.Columns(EquipmentGrid.ServiceCount).Width = 80
        'dgGrid.Columns(EquipmentGrid.AlertCount).Width = 80
        'dgGrid.Columns(EquipmentGrid.RemainCount).Width = 80
        dgGrid.Columns(EquipmentGrid.Status).Width = 60
        dgGrid.Columns(EquipmentGrid.Storage).Width = 60
        dgGrid.Columns(EquipmentGrid.InOut).Width = 80
        dgGrid.Columns(EquipmentGrid.LineID).Width = 80
        dgGrid.Columns(EquipmentGrid.OutUserID).Width = 95
        dgGrid.Columns(EquipmentGrid.Intime).Width = 105
        dgGrid.Columns(EquipmentGrid.FactoryID).Width = 60
        dgGrid.Columns(EquipmentGrid.ProfitCenter).Width = 80

        ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
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
                row.Cells(EquipmentGrid.checkbox).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(EquipmentGrid.checkbox).Value = False
            Next
        End If
    End Sub
#End Region


#Region "借出"
    Private Sub ToolLend_Click(sender As Object, e As EventArgs) Handles ToolLend.Click
        If IsDBNull(Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value) Then
            MessageUtils.ShowError("线别为空的不允许转借")
            Exit Sub
        End If
        Dim frmLine As New FrmSelectLine
        frmLine.txtEquNo.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value
        frmLine.txtLineID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.LineID).Value
        frmLine.txtEquPN.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.PartNumber).Value
        If Not IsDBNull(Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.OutUserID).Value) Then
            frmLine.txtGiveUserID.Text = Me.dgvEqu.CurrentRow.Cells(EquipmentGrid.OutUserID).Value.ToString.Split("/")(0)
        End If
        frmLine.StartPosition = FormStartPosition.CenterScreen
        frmLine.Owner = Me
        frmLine.ShowDialog()
    End Sub
#End Region

    Private Sub btnLookLendRecord_Click(sender As Object, e As EventArgs) Handles btnLookLendRecord.Click

        Dim frmlog As New FrmLineBorrowLog
        frmlog.StartPosition = FormStartPosition.CenterScreen
        frmlog.Owner = Me
        frmlog.ShowDialog()


    End Sub
End Class

Public Class KeyValue2
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
