Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Windows.Forms

Public Class FrmAccessquery
    Dim dt As DataTable
    Dim strSQL As String
    Private Sub Btnquery_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        If ComboBox1.Text.Trim = "领用" Then
            strSQL = "SELECT ConsumableNo AS 消耗品编号,LineID AS 领用线别,Qty AS 领用数量,PartID AS 料号,(select UserName from m_users_t where UserID=m_ConsumableLendLog_t.UserID) AS 领用人," &
               "Intime AS 领用时间,Remark AS 备注,DeptName AS 领用课别 " &
               "FROM m_ConsumableLendLog_t  WHERE  Intime >='" + dtCheckDate.Value + "' AND Intime <='" + dtCheckDate1.Value + "'"

        Else
            strSQL = "SELECT ConsumableNo AS 消耗品编号, Qty AS 入库数量 , Storage AS 仓库储位 ,(select UserName from m_users_t " &
                     "where UserID=m_ConsumableInlog_t.UserID) AS 入库人员, Intime AS 入库时间 FROM m_ConsumableInlog_t WHERE  Intime >='" + dtCheckDate.Value + "' AND Intime <='" + dtCheckDate1.Value + "'"
        End If
        If Txtuser.Text.Trim <> "" Then
            strSQL = strSQL + "AND UserID = '" + Txtuser.Text.Trim + "'"
        End If
        If cboRequestClass.Text.Trim <> "" Then
            strSQL = strSQL + "AND DeptName = N'" + cboRequestClass.Text.Trim + "'"
        End If
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        dgvConsumable.DataSource = dt
        If ComboBox1.Text.Trim = "领用" Then
            dgvConsumable.Columns(0).HeaderText = "Mã vật liệu tiêu hao 消耗品编码"
            dgvConsumable.Columns(1).HeaderText = "Chuyền nhận dùng 领用线别"
            dgvConsumable.Columns(2).HeaderText = "Số lượng nhận dùng 领用数量"
            dgvConsumable.Columns(3).HeaderText = "Mã liệu 料号"
            dgvConsumable.Columns(4).HeaderText = "Người nhận 领用人"
            dgvConsumable.Columns(5).HeaderText = "Thời gian nhận 领用时间"
            dgvConsumable.Columns(6).HeaderText = "Chú ý 备注"
            dgvConsumable.Columns(7).HeaderText = "Bộ phận nhận hàng 领用课别"
        Else
            dgvConsumable.Columns(0).HeaderText = "Mã vật liệu tiêu hao 消耗品编码"
            dgvConsumable.Columns(1).HeaderText = "Số lượng nhập kho 入库数量"
            dgvConsumable.Columns(2).HeaderText = "Vị trí kho 仓库储位"
            dgvConsumable.Columns(3).HeaderText = "Nhân viên nhập kho 入库人员"
            dgvConsumable.Columns(4).HeaderText = "Thời gian nhập kho 入库时间"
        End If
    End Sub

    Private Sub FrmAccessquery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
        dtCheckDate.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")
        dtCheckDate1.Value = System.DateTime.Now.ToString("yyyy/MM/dd")
        ComboBox1.SelectedIndex = 0
        EquManageCommon.BindComboxClass(cboRequestClass)
        FillCombox(cboRequestClass)
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable

        If ColComboBox.Name = "cboRequestClass" Then
            UserDg = DbOperateUtils.GetDataTable("select dqc from m_Dept_t where usey='Y' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "dqc"
            ColComboBox.ValueMember = "dqc"
        ElseIf ColComboBox.Name = "cboRequestLine" Then
            UserDg = DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where usey='Y' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        End If
        UserDg = Nothing
    End Sub


    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim strSql As String = ""
        Dim sqlWhere As String = Nothing
        Dim IsSearch As Boolean = True
        If ComboBox1.Text.Trim = "领用" Then
            strSql = "SELECT ConsumableNo AS 消耗品编号,LineID AS 领用线别,Qty AS 领用数量,PartID AS 料号,(select UserName from m_users_t where UserID=m_ConsumableLendLog_t.UserID) AS 领用人," &
               "Intime AS 领用时间,Remark AS 备注,DeptName AS 领用课别 " &
               "FROM m_ConsumableLendLog_t  WHERE  Intime >='" + dtCheckDate.Value + "' AND Intime <='" + dtCheckDate1.Value + "'"
        Else
            strSql = "SELECT ConsumableNo AS 消耗品编号, Qty AS 入库数量 , Storage AS 仓库储位 ,(select UserName from m_users_t " &
                     "where UserID=m_ConsumableInlog_t.UserID) AS 入库人员, Intime AS 入库时间 FROM m_ConsumableInlog_t WHERE  Intime >='" + dtCheckDate.Value + "' AND Intime <='" + dtCheckDate1.Value + "'"
        End If
        If Txtuser.Text.Trim <> "" Then
            strSql = strSql + "AND UserID = '" + Txtuser.Text.Trim + "'"
        End If
        If cboRequestClass.Text.Trim <> "" Then
            strSql = strSql + "AND DeptName = N'" + cboRequestClass.Text.Trim + "'"
        End If
        Dim d As DataTable = DbOperateUtils.GetDataTable(strSql)
        ExcelUtils.LoadDataToExcelFromDT(d, Me.Text)
    End Sub
End Class