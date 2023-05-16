Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2016/03/01
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>MES所有帮助说明</remarks>
Public Class FrmKBHelp

#Region "变量定义"
    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Enum HelpGrid
        ID
        ModuleName
        FormName
        ItemName
        Formula
        SQL
        Remark
        UserID
        Intime
        'ID，模块，画面名称，功能ID，公式，SQL,备注，创建人，创建时间
    End Enum
#End Region

#Region "初期化"

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmKBHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Me.DesignMode = True Then Exit Sub

            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)

            '设置当前操作模式
            Me.OperateFlag = EditMode.UNDO
            '设置工具栏按钮状态
            SetControlStatus(Me.OperateFlag)

            KBCom.BindComboxMoKuai(cboMES)
            KBCom.BindComboxItems(cboFrmName, cboMES.SelectedValue.ToString)

            '绑定数据
            LoadGrid()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKBHelp", "FrmKBHelp_Load", "sys")
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        ExcelUtils.LoadDataToExcel(gdHelp, Me.Text)
    End Sub
    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            LoadGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnRefresh_Click", "sys")
        End Try
    End Sub
    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
        '清除面板控件值
        ClearGroupBox()
    End Sub
    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
        cboMES.Enabled = True
        cboFrmName.Enabled = True
        txtItemName.Enabled = True
    End Sub
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim strSQL As String = " delete m_MESHelp_t where id = '{0}'"
                strSQL = String.Format(strSQL, lblId.Text)
                DbOperateUtils.ExecSQL(strSQL)

                MessageUtils.ShowInformation("删除成功")
                LoadGrid()
                ClearGroupBox()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
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

                '刷新
                LoadGrid()
                '设置操作模式
                OperateFlag = EditMode.UNDO
                SetControlStatus(EditMode.UNDO)
                cboMES.Enabled = True
                cboFrmName.Enabled = True
                txtItemName.Enabled = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnSave_Click", "sys")
        End Try
    End Sub
    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)

        cboMES.Enabled = False
        cboFrmName.Enabled = False
        txtItemName.Enabled = False
    End Sub
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        '清除面板控件值
        ClearGroupBox()
    End Sub

    Private Sub cboMES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMES.SelectedIndexChanged
        KBCom.BindComboxItems(cboFrmName, cboMES.SelectedValue.ToString)
    End Sub

#End Region

#Region "CellClick事件"
    Private Sub gdHelp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gdHelp.CellClick
        If gdHelp.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        If e.RowIndex < 0 Then Exit Sub

        SetControlValue()
    End Sub

    Private Sub SetControlValue()
        If gdHelp.RowCount < 1 Then Exit Sub
        ''当前行没有时把第一行默认选中
        Me.cboMES.SelectedIndex = Me.cboMES.FindString(gdHelp.Item(HelpGrid.ModuleName, gdHelp.CurrentRow.Index).Value.ToString)
        Me.cboFrmName.SelectedIndex = Me.cboFrmName.FindString(gdHelp.Item(HelpGrid.FormName, gdHelp.CurrentRow.Index).Value.ToString)
        Me.txtItemName.Text = gdHelp.Item(HelpGrid.ItemName, gdHelp.CurrentRow.Index).Value.ToString()
        Me.txtFormula.Text = gdHelp.Item(HelpGrid.Formula, gdHelp.CurrentRow.Index).Value.ToString()
        Me.txtSQL.Text = gdHelp.Item(HelpGrid.SQL, gdHelp.CurrentRow.Index).Value.ToString()
        Me.txtRemark.Text = gdHelp.Item(HelpGrid.Remark, gdHelp.CurrentRow.Index).Value.ToString()
        Me.lblId.Text = gdHelp.Item(HelpGrid.ID, gdHelp.CurrentRow.Index).Value.ToString()
    End Sub
#End Region

#Region "检查输入"

    Private Function CheckInput() As Boolean
        If String.IsNullOrEmpty(cboMES.Text) Then
            MessageUtils.ShowError("请选择模块!")
            Return False
        End If

        If String.IsNullOrEmpty(cboFrmName.Text) Then
            MessageUtils.ShowError("请选择功能名称!")
            Return False
        End If

        If String.IsNullOrEmpty(txtItemName.Text) Then
            MessageUtils.ShowError("请输入计算项目!")
            Return False
        End If

        If String.IsNullOrEmpty(txtFormula.Text) Then
            MessageUtils.ShowError("请输入计算公式!")
            Return False
        End If

        If String.IsNullOrEmpty(txtSQL.Text) Then
            MessageUtils.ShowError("请输入计算SQL文!")
            Return False
        End If

        Return True
    End Function

#End Region

#Region "保存数据"
    Private Function SaveData() As Boolean
        Dim strSql As String = ""
        Dim o_strExcelSQLResult As String = ""
        Try
            Dim strMK As String = cboMES.SelectedValue.ToString
            Dim strFrmName As String = cboFrmName.SelectedValue.ToString
            Dim strItemName As String = txtItemName.Text.Trim
            Dim strFormula As String = Me.txtFormula.Text.Trim.Replace("'", "''")
            Dim strSQLContent As String = Me.txtSQL.Text.Trim.Replace("'", "''")
            Dim strRemark As String = Me.txtRemark.Text.Trim.Replace("'", "''")

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim strBSQL As New System.Text.StringBuilder
            '
            If OperateFlag = EditMode.ADD Then     '新增
                '设备编号是否存在
                strSql = "SELECT 1 FROM m_MESHelp_t(nolock) where ModuleName='{0}' and FormName = '{1}' and ItemName = N'{2}'"
                strSql = String.Format(strSql, strMK, strFrmName, strItemName)
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError(String.Format("模块{0}功能名称{1}计算项目{2}已存在!", cboMES.Text, cboFrmName.Text, strItemName))
                    Return False
                Else
                    strSql = " INSERT INTO m_MESHelp_t(ModuleName,FormName,ItemName,formula,SQL,remark," &
                             " UserID,InTime)"

                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", strMK)
                    strBSQL.AppendFormat("N'{0}',", strFrmName)
                    strBSQL.AppendFormat("N'{0}',", strItemName)
                    strBSQL.AppendFormat("N'{0}',", strFormula)
                    strBSQL.AppendFormat("N'{0}',", strSQLContent)
                    strBSQL.AppendFormat("N'{0}',", strRemark)
                    strBSQL.AppendFormat("N'{0}',", userId)
                    strBSQL.AppendFormat("getdate()")
                    strBSQL.Append(");")

                End If
            Else    '修改
                strSql = "UPDATE m_MESHelp_t "

                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" SET formula = N'{0}', ", strFormula)
                strBSQL.AppendFormat(" SQL = N'{0}', ", strSQLContent)
                strBSQL.AppendFormat(" remark = N'{0}' ,", strRemark)
                strBSQL.AppendFormat(" UserID = N'{0}', ", userId)
                strBSQL.AppendFormat(" InTime=getdate() ")
                strBSQL.AppendFormat(" WHERE ID = {0}", Val(Me.lblId.Text.Trim))

            End If
            '执行SQL
            Dim result As String = DbOperateUtils.ExecSQL(strBSQL.ToString)

            If String.IsNullOrEmpty(result) Then
                Return True
            Else
                MessageUtils.ShowError(result)
                Return False
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "加载数据"

    Private Sub LoadGrid()
        Try
            Dim StrSql As String = ""
            StrSql = " select ID, (select SortName from m_Sortset_t where ModuleName = SortID and SortType = 'MES' ) ModuleName, " &
                     "(select SortName from m_Sortset_t where SortID = FormName and  SortType = ModuleName ) FormName,  " &
                     "ItemName, formula, SQL, remark, Intime , " &
                     "(select top 1 username from m_Users_t users where users.UserID = help.userid)userid " &
                     " from m_MESHelp_t help WHERE 1=1 "

            If OperateFlag = EditMode.SEARCH Then
                StrSql = StrSql + GetDTbyWhere(StrSql)
            End If

            Dim strOrderby As String = " order by id asc"

            StrSql = StrSql + strOrderby

            gdHelp.DataSource = DbOperateUtils.GetDataTable(StrSql)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
    End Sub

    Private Function GetDTbyWhere(strSQL As String) As String
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(cboMES.Text) = False Then
            strWhere.AppendFormat(" and ModuleName = '{0}' ", cboMES.SelectedValue.Trim)
        End If

        If String.IsNullOrEmpty(KBCom.DBNullToStr(cboFrmName.SelectedValue)) = False Then
            strWhere.AppendFormat(" and FormName = '{0}' ", cboFrmName.SelectedValue.ToString)
        End If

        Return strWhere.ToString
    End Function

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
                Me.toolNew.Enabled = IIf(KBCom.DBNullToStr(toolNew.Tag) = "YES", True, False)
                Me.toolModify.Enabled = IIf(KBCom.DBNullToStr(toolModify.Tag) = "YES", True, False)
                Me.toolDelete.Enabled = IIf(KBCom.DBNullToStr(toolDelete.Tag) = "YES", True, False)
                Me.toolExport.Enabled = IIf(KBCom.DBNullToStr(toolExport.Tag) = "YES", True, False)
                Me.toolSearch.Enabled = IIf(KBCom.DBNullToStr(toolSearch.Tag) = "YES", True, False)
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolSearch.Enabled = False
                toolRefresh.Enabled = True
        End Select
    End Sub
    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
        toolExport.Enabled = bFlag
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.txtItemName.Text = ""
        Me.txtFormula.Text = ""
        Me.txtSQL.Text = ""
        Me.txtRemark.Text = ""
        Me.cboMES.SelectedIndex = 0
        Me.cboFrmName.SelectedIndex = 0
    End Sub
#End Region

#Region "Grid行数"
    Private Sub dgvMOID_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gdHelp.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region


End Class