Public Class FrmSelectPICNew

    Private dt As DataTable  '存储用户已选择责任人

    Private _DutyEmail As String

    ''' <summary>
    ''' 责任人邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DutyEmail() As String
        Get
            Return _DutyEmail
        End Get
        Set(value As String)
            _DutyEmail = value
        End Set
    End Property

#Region "窗体加载"
    Private Sub FrmSelectPICNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = New DataTable()
        'loadUser()
        selectedUser(True)
    End Sub
#End Region

#Region "加载用户信息"
    ''' <summary>
    ''' 加载用户信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadUser()
        Dim strWhere = " and 1=1 "
        If String.IsNullOrEmpty(TxtEmpNO.Text.Trim) = False Then
            strWhere += " and code='" + TxtEmpNO.Text.Trim.ToUpper + "'"
        End If
        If String.IsNullOrEmpty(txtEmpName.Text.Trim) = False Then
            strWhere += " and name ='" + txtEmpName.Text.Trim + "'"
        End If
        If String.IsNullOrEmpty(TxtDeptName.Text.Trim) = False Then
            strWhere += " and deptname like '%" + TxtDeptName.Text.Trim.ToUpper + "%'"
        End If
        Dim sql As String = "select nvl(deptname,'') deptname,code,name,email,directbossempcode from V_EMPLOYEEONJOB where email is not null and  rownum<=18" + strWhere
        dgvPIC.AutoGenerateColumns = False
        dgvPIC.DataSource = DBUtility.DbOracleForSpcHelperSQL.Query(sql).Tables(0)
    End Sub
#End Region

#Region "加载已经选择了"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IsFormLoad">是否是窗体加载</param>
    ''' <remarks></remarks>
    Private Sub selectedUser(ByVal IsFormLoad As Boolean)
        If IsFormLoad = True Then
            DutyEmail = DutyEmail.TrimEnd(";")
            DutyEmail = DutyEmail.Replace(";", "','")
            DutyEmail = "'" + DutyEmail + "'"
            Dim where = " where 1=1 "
            If String.IsNullOrEmpty(DutyEmail) = False And DutyEmail <> "''" Then
                where += " and email in (" + DutyEmail + ")"
            Else
                where += " and 1=2 "
            End If
            Dim sql As String = "select deptname,code,name,email,directbossempcode from V_EMPLOYEEONJOB " + where
            dt = DBUtility.DbOracleForSpcHelperSQL.Query(sql).Tables(0)
        End If

        dgvSelect.AutoGenerateColumns = False
        dgvSelect.DataSource = dt
    End Sub
#End Region

#Region "选择用户"
    Private Sub dgvPIC_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPIC.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = dgvPIC.ColumnCount - 1 Then
                Dim dgvr As DataGridViewRow = dgvPIC.Rows(e.RowIndex)
                Dim deptname As String = IIf(IsDBNull(dgvr.Cells("coldeptname").Value), "", dgvr.Cells("coldeptname").Value.ToString)
                Dim code As String = dgvr.Cells("colcode").Value
                Dim name As String = dgvr.Cells("colname").Value
                Dim email As String = dgvr.Cells("colemail").Value
                Dim BossEmpNO As String = dgvr.Cells("Coldirectbossempcode").Value
                If dt.Rows.Count > 0 Then
                    If dt.Select("code='" + code + "'").Length > 0 Then
                        MainFrame.SysCheckData.MessageUtils.ShowError("已经选择了用户:" + code + "-" + name)
                        Return
                    End If
                End If
                Dim dr As DataRow = dt.NewRow()
                dr(0) = deptname
                dr(1) = code
                dr(2) = name
                dr(3) = email
                dr(4) = BossEmpNO
                dt.Rows.Add(dr)
                selectedUser(False)
            End If
        End If
    End Sub
#End Region

#Region "移除选择"
    Private Sub dgvSelect_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelect.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = dgvSelect.ColumnCount - 1 Then
                dt.Rows.RemoveAt(e.RowIndex)
                selectedUser(False)
            End If
        End If
    End Sub
#End Region

#Region "确定"
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If dgvSelect.Rows.Count = 0 Then
            MainFrame.SysCheckData.MessageUtils.ShowError("请选择负责人!")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
#End Region

#Region "刷新数据"
    ''' <summary>
    ''' 刷新数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        loadUser()
    End Sub
#End Region

#Region "清空查询条件"
    ''' <summary>
    ''' 清空查询条件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtEmpNO.Text = Nothing
        txtEmpName.Text = Nothing
        TxtDeptName.Text = Nothing
    End Sub
#End Region

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class