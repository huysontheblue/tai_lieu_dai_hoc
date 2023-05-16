Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.IO

Public Class FrmWorkDayPlan
    Public pageData As New SysBasicClass.PageData()
    Dim ButtonPermission As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)
    Private dtData As DataTable = Nothing

    Private Sub FrmWorkOrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitButtonPermission()
        FillCombox(CboDept)
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
        Me.txtDt1.Value = Date.Now.AddDays(-7)
        Me.txtDt2.Value = Date.Now
        txtUserId.Text = VbCommClass.VbCommClass.UseId


        'Me.CobUsey.SelectedIndex = 0
    End Sub
    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = String.Empty
        'dqc+'--'+deptid
        If ColComboBox.Name = "CboDept" Then
            ' lsSQL = " SELECT deptid, deptid+'--'+dqc as dqc FROM  m_Dept_t WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "'"
            UserDg = VbCommClass.CommClass.GetUserDeptDt() ''DataHand.GetDataTable(lsSQL)

            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
            'ElseIf ColComboBox.Name = "ComMoType" Then
            '    UserDg = DataHand.GetDataTable("SELECT motype,typeid FROM motype_t")

            '    ColComboBox.DataSource = UserDg
            '    ColComboBox.DisplayMember = "motype"
            '    ColComboBox.ValueMember = "typeid"
        End If
        UserDg = Nothing
    End Sub
    '按钮权限
    Private Sub InitButtonPermission()

        ButtonPermission = SysMessageClass.GetUserFormButtonPermission(SysMessageClass.UseId, "ProductionPlan.FrmWorkDayPlan")
        Me.toolAdd.Enabled = ButtonPermission("toolAdd")
        Me.toolEdit.Enabled = ButtonPermission("toolEdit")
        Me.toolAbandon.Enabled = ButtonPermission("toolAbandon")
        Me.toolQuery.Enabled = ButtonPermission("toolQuery")
        '    Me.Import.Enabled = ButtonPermission("toolImport")
    End Sub

    Private Function dgvBind() As Integer
        DGOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DGOrder.ColumnHeadersHeight = 30
        pageData.PageIndex = Pager1.PageCurrent
        pageData.PageSize = Pager1.PageSize
        dtData = pageData.QueryDataTable()
        Pager1.bindingSource.DataSource = dtData
        Pager1.bindingNavigator.BindingSource = Pager1.bindingSource
        DGOrder.AutoGenerateColumns = False
        DGOrder.DataSource = Pager1.bindingSource
        'DGOrder.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGOrder.Columns(0).HeaderText = "序号"
        'DGOrder.Columns(0).Width = 60
        Return pageData.TotalCount
    End Function
    Private Function Pager1_EventPaging(e As SysBasicClass.EventPagingArg) As System.Int32 Handles Pager1.EventPaging
        Return dgvBind()
    End Function

    Private Sub Pager1_ExportAllData(e As SysBasicClass.ExportAllDataArg) Handles Pager1.ExportAllData
        SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), pageData.QueryAllDataTable())
    End Sub

    Private Sub Pager1_ExportData(e As SysBasicClass.ExportDataArg) Handles Pager1.ExportData
        SysBasicClass.Export.ExportExcel(DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), pageData.QueryDataTable())
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        querydata()
    End Sub
    Private Sub querydata()
        Dim deptid As String = IIf(CboDept.SelectedValue Is DBNull.Value, "", CboDept.SelectedValue)
        Dim lineid As String = IIf(CboLine.SelectedValue Is DBNull.Value, "", CboLine.SelectedValue)
        

        Dim moid As String = TxtMoid.Text.Trim
        Dim CreateUserid As String = txtUserId.Text.Trim
        Dim PlanDay As Date = Convert.ToDateTime(txtPlanDay.Value.ToString("yyyy-MM-dd"))
        Dim dt1 As Date = Convert.ToDateTime(txtDt1.Value.ToString("yyyy-MM-dd"))
        Dim dt2 As Date = Convert.ToDateTime(txtDt2.Value.ToString("yyyy-MM-dd"))


        If Date.Compare(dt1, dt2) > 0 Then
            MessageUtils.ShowWarning("开始时间不能大于结束时间")
            Exit Sub
        End If

        Dim strwhere As String = ""
        If (Deptid <> "") Then
            strwhere = strwhere + " and Deptid='" + Deptid + "'"
        End If
        If (Lineid <> "") Then
            strwhere = strwhere + " and lineid='" + Lineid + "'"
        End If
        If (PlanDay.ToString <> "") Then
            strwhere = strwhere + " and PlanDay='" + PlanDay.ToString("yyyy-MM-dd") + "'"
        End If
        If moid <> "" Then
            strwhere = strwhere + " and moid like N'%" + moid + "%' "
        End If

        If CboUsey.Text <> "" And CboUsey.Text <> "ALL" Then
            strwhere = strwhere + " and usey= '" & CboUsey.Text.ToString.Split("-")(0) & "' "
        End If
        'If Me.chkusey.Checked Then
        '    strwhere = strwhere + " and usey= 'Y' "
        'Else
        '    strwhere = strwhere + " and usey= 'N' "
        'End If
        strwhere = strwhere + " and CONVERT(varchar(100), intime, 23) >= '" + dt1.ToString("yyyy-MM-dd") + "' and CONVERT(varchar(100), intime, 23) <= '" + dt2.ToString("yyyy-MM-dd") + "'"
        If (CreateUserid <> "") Then
            strwhere = strwhere + " and a.Userid='" + CreateUserid + "'"
        End If

        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append("select * ")
        strSql.Append(" FROM dbo.m_WorkDayPlan_t a ")
        strSql.Append(" where 1=1 and usey='Y' ")
        strSql.Append(strwhere)
        pageData.QuerySQL = strSql.ToString
        Cursor = Cursors.WaitCursor
        SysBasicClass.WaitFormService.CreateWaitForm()
        Pager1.PageCount = 1
        Pager1.Bind()
        dgvBind()
        SysBasicClass.WaitFormService.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Dim fr As FrmWorkDayPlanInfo = New FrmWorkDayPlanInfo("0")
        fr.ShowDialog()
        If fr.IsRefresh Then
            querydata()
        End If
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.DGOrder.Rows.Count = 0 OrElse Me.DGOrder.CurrentRow Is Nothing Then Exit Sub
        Dim id As String = DGOrder.Item("id", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
       
        Dim fr As FrmWorkDayPlanInfo = New FrmWorkDayPlanInfo("1", id)
        If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            querydata()
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click

        If Me.DGOrder.Rows.Count = 0 OrElse Me.DGOrder.CurrentRow Is Nothing Then Exit Sub
        Dim id As String = DGOrder.Item("id", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        Dim usey As String = DGOrder.Item("usey", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        If (usey = "N") Then
            MessageBox.Show("已作废")
            Exit Sub
        End If
        DialogResult = MessageUtils.ShowConfirm("确定要作废？", MessageBoxButtons.YesNo)
        If DialogResult = Windows.Forms.DialogResult.Yes Then
            Dim sql As String = String.Format("update m_WorkDayPlan_t set usey='N' where id='{0}'  ", id)
            Dim returnval As String = ""
            Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass()
            Try
                returnval = conn.ExecuteNonQuery(sql)
            Catch ex As Exception
                returnval = returnval + ex.ToString
            End Try
            If returnval = "" Then
                SysMessageClass.SaveUserOpLog(Me, "作废ID：" + id)
                MessageBox.Show("作废成功")
                querydata()
            Else
                MessageBox.Show("作废发生错误：" + returnval)
                Exit Sub
            End If
        End If
    End Sub

    'Private Sub DataGridViewX1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
    '    If Me.DGOrder.Rows.Count = 0 OrElse Me.DGOrder.CurrentRow Is Nothing Then Exit Sub
    '    Dim usey As String = DGOrder.Item("usey", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
    '    Dim id As String = DGOrder.Item("id", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
    '    If (usey = "N") Then
    '        MessageBox.Show("已作废")
    '        Exit Sub
    '    End If
    '    Dim fr As FrmWorkDayPlanInfo = New FrmWorkDayPlanInfo("1", id)
    '    If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        querydata()
    '    End If
    'End Sub

   

    Private Sub CboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDept.SelectedIndexChanged
        If Not CboDept.SelectedValue Is Nothing AndAlso CboDept.SelectedValue.ToString <> "" Then
            'Dim sql As String = " SELECT lineid as value, lineid as text  FROM deptline_t " & _
            '                    " WHERE factoryid ='" & VbCommClass.VbCommClass.Factory & "' " & _
            '                    " AND deptid='" & Me.CboDept.SelectedValue.ToString() & "' "
            'UserDg = VbCommClass.CommClass.GetDeptLineDt(Me.CboDept.SelectedValue.ToString())
            Using dt As DataTable = VbCommClass.CommClass.GetDeptLineDt(Me.CboDept.SelectedValue.ToString()) ' DbOperateUtils.GetDataTable(sql)
                dt.Rows.InsertAt(dt.NewRow, 0)
                CboLine.ValueMember = "lineid"
                CboLine.DisplayMember = "lineid"
                CboLine.DataSource = dt.DefaultView
            End Using
        End If
    End Sub

    Private Sub ToolKanban_Click(sender As Object, e As EventArgs) Handles ToolKanban.Click
        If Me.DGOrder.Rows.Count = 0 OrElse Me.DGOrder.CurrentRow Is Nothing Then Exit Sub
        Dim id As String = DGOrder.Item("id", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        Dim deptid As String = DGOrder.Item("deptid", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        Dim lineid As String = DGOrder.Item("lineid", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        Dim PlanDay As String = DGOrder.Item("PlanDay", Me.DGOrder.CurrentRow.Index).Value.ToString.Trim
        OpenProdBoard(deptid, lineid, PlanDay)
    End Sub
    '打开产品看板
    Dim frmBoard As FrmProdBoard          '看板窗体
    ''' <summary>
    ''' 调用看板窗体
    ''' </summary>
    ''' <param name="deptid">部门</param>
    ''' <param name="lineid">线别</param>
    ''' <param name="planday">看板日期</param>
    ''' <remarks></remarks>
    Private Sub OpenProdBoard(ByVal deptid As String, ByVal lineid As String, Optional ByVal planday As String = "")
        If planday = "" Then
            planday = Now.ToString("yyyy-MM-dd")
        End If
        '显示看板页面
        If (frmBoard Is Nothing) Then
            frmBoard = New FrmProdBoard
            frmBoard.DeptId = deptid
            frmBoard.LineId = lineid
            frmBoard.PlanDay = planday
            frmBoard.Show()
        ElseIf frmBoard IsNot Nothing AndAlso frmBoard.IsDisposed Then
            frmBoard = New FrmProdBoard
            frmBoard.DeptId = deptid
            frmBoard.LineId = lineid
            frmBoard.PlanDay = planday
            frmBoard.Show()
        Else
            frmBoard.Activate()
        End If
    End Sub

    Private Sub txtDt1_ValueChanged(sender As Object, e As EventArgs) Handles txtDt1.ValueChanged

    End Sub
End Class