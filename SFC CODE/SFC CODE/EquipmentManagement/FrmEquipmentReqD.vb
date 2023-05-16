Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentReqD

    Private Sub FrmEquipmentReqD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        EquManageCommon.BindComboxClass(cboQueryClass)
        If cboQueryClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        End If
        '状态
        EquManageCommon.BindComboxStatus(cboQueryStatus)
        GetListData()
        'LoadEquipmentDetail(0)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Dim strSQL As String =
                "select AppUserName 申请人, Dept 部门, Line 线别, MOID 工单, PNumber 料号, " &
                "HardWarePartNumber 五金料号,EquipmentPNumber 设备料号, " &
                "(select TEXT from m_BaseData_t where ITEMKEY = 'EqpAppStatus' and VALUE = AStatus1) 状态, " &
                "(select top 1 DESCRIPTION from m_PartContrast_t where [TAvcPart] = EquipmentPNumber ) 工治具规格, " &
                "REPLACE(QTY,' Set','') 需求数量,AlreadyBorrowQty 已借出数量, ReturnQty 已归还数量,InTime 申请时间, FactoryName 厂区, Profitcenter 利润中心 " &
                "from m_Equipment_App_t where 1=1  " &
                 EquManageCommon.GetFatoryProfitcenter()

            Dim dt As DataTable = GetDTbyWhere(strSQL,False)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReqD", "toolExcel_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            GetListData()
            LoadEquipmentDetail(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReqD", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function GetDTbyWhere(strSQL As String,Optional ByVal IsQuery As Boolean = True) As DataTable
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtQueryUser.Text) = False Then
            strWhere.AppendFormat(" and a.AppID LIKE '{0}%' ", txtQueryUser.Text.Trim)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryClass.SelectedValue)) = False Then
            strWhere.AppendFormat(" and DeptID = '{0}' ", cboQueryClass.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(cboQueryLine.Text) = False Then
            strWhere.AppendFormat(" and A.Line = '{0}' ", cboQueryLine.Text.ToString)
        End If

        If String.IsNullOrEmpty(txtQueryMo.Text.Trim) = False Then
            strWhere.AppendFormat(" and MOID LIKE '{0}%' ", txtQueryMo.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPn.Text.Trim) = False Then
            strWhere.AppendFormat(" and PNumber LIKE '{0}%' ", txtQueryPn.Text.Trim)
        End If

        If String.IsNullOrEmpty(cboQueryStatus.SelectedValue.ToString) = False Then
            strWhere.AppendFormat(" and AStatus1 = '{0}' ", cboQueryStatus.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(txtQueryHardwarePartNumber.Text.Trim) = False Then
            strWhere.AppendFormat(" and HardWarePartNumber LIKE '{0}%' ", txtQueryHardwarePartNumber.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPartNumber.Text.Trim) = False Then
            strWhere.AppendFormat(" and EquipmentPNumber LIKE '{0}%' ", txtQueryPartNumber.Text.Trim)
        End If

        If chkRequsteTime.Checked = True Then
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)
        End If

        If chkOutTime.Checked = True Then
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", dtpOutTimeStart.Value)
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", dtpOutTimeEnd.Value)
        End If

        If String.IsNullOrEmpty(txtEquNo.Text) = False Then
            strWhere.AppendFormat(" and B.EquipmentNo LIKE '{0}%' ", txtEquNo.Text.Trim)
        End If

        If chkOutTime.Checked = True Then
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), B.OutTime ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", dtpOutTimeStart.Value)
            strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), B.OutTime ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", dtpOutTimeEnd.Value)
        End If

        'Modify by cq 20171212 A==> m_Equipment_App_t
         Dim strOrderBy As String =string.Empty
        If IsQuery Then
            strOrderBy = " ORDER BY A.InTime DESC"
        Else
            strOrderBy = " ORDER BY m_Equipment_App_t.InTime DESC"
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrderBy)
        Return dt
    End Function

    '注：根据工治具编号、借出时间，通过[工治具出入库明细：m_Equipment_BorrRetu_t]找到对应的申请单ID
    '再查出工治具申请表的数据
    Private Sub GetListData()

        Dim strSQL As String =
        "select distinct top 1000 AppUserName, Dept, A.Line, MOID, PNumber, " &
        "HardWarePartNumber,EquipmentPNumber,AStatus1, " &
        "(select TEXT from m_BaseData_t where ITEMKEY = 'EqpAppStatus' and VALUE = AStatus1) AStatus, " &
        "(select top 1 DESCRIPTION from m_PartContrast_t where [TAvcPart] = EquipmentPNumber ) DESCRIPTION, " &
        "REPLACE(QTY,' Set','') QTY,AlreadyBorrowQty, ReturnQty,A.InTime, A.FactoryName, A.Profitcenter,A.ID " &
        "from m_Equipment_App_t A " &
        "inner join m_Equipment_BorrRetu_t B " &
        "on A.ID = B.RequestID  where 1=1 " &
        EquManageCommon.GetFatoryProfitcenter("A")

        dgvResult.DataSource = GetDTbyWhere(strSQL)

    End Sub

    Private Sub dgvResult_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            LoadEquipmentDetail(e.RowIndex)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReqD", "dgvResult_CellClick", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadEquipmentDetail(curRowIndex As Integer)
        If dgvResult.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim strSQL As String =
            "SELECT EquipmentNo,Line, CASE EEnable WHEN '0' THEN N'0.出库' else N'1.入库' END STATUS, OutTime , Storage, InTime, " &
            "(select UserName from m_Users_t where UserID = Receiver) Receiver,  " &
            " DATEDIFF(day,OutTime, isnull(InTime,GETDATE()) ) OutDay " & _
            " FROM m_Equipment_BorrRetu_t  " &
            " WHERE 1=1 "

        Dim RequestID As String = dgvResult.Rows(curRowIndex).Cells("txtId").Value.ToString

        Dim strWhere As String = String.Format(" and RequestID = '{0}'", RequestID)
        Dim strOrder As String = " order by InTime desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

        dgvResultD.DataSource = dt

    End Sub

    Private Sub cboQueryClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQueryClass.SelectedIndexChanged
        If cboQueryClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        End If
    End Sub

#Region "Grid行数"
    Private Sub dgvResult_RowPostPaint(sender As Object, e As Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvResult.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class