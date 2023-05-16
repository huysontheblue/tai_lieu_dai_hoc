Imports System.Data
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing
Imports MainFrame.SysDataHandle
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentStock


    Private Sub FrmEquipmentStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            FormLoad()
        End If
    End Sub

    Public Sub FormLoad()
        Try
            '绑定设备分类
            EquManageCommon.BindComboxCategory(cboBigCategory, "BIG")
            EquManageCommon.BindComboxCategory(cboMiddleCategory, "MID")

            Search()
            LoadEquipmentDetail(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentStock", "FrmEquipmentStock_Load", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cboMiddleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMiddleCategory.SelectedIndexChanged
        If String.IsNullOrEmpty(cboMiddleCategory.SelectedValue.ToString) = False Then
            EquManageCommon.BindComboxCategory(cboSmallCategory, cboMiddleCategory.SelectedValue.ToString)
        End If
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Dim strSQL As String =
          "select distinct A.Category 工治具类别,B.PartNumber 工治具料号,A.CNT 库存数量,A.DESCRIPTION 工治具规格,A.CategoryID 目录ID " &
          "FROM (select (select Category from m_EquipmentCategory_t where id = CategoryID) Category, " &
          "(select top 1 DESCRIPTION from m_PartContrast_t where [TAvcPart] = PartNumber  AND TYPE='E') DESCRIPTION, " &
          "PartNumber,CategoryID, count(1) Cnt  " &
          "from m_Equipment_t where InOut =1   " &
          "group by CategoryID,PartNumber) A " &
          "INNER JOIN m_Equipment_t B " &
          "ON A.PartNumber = B.PartNumber " &
          "WHERE InOut=1 " &
            EquManageCommon.GetFatoryProfitcenter("B")

            Dim dt As DataTable = GetDTbyWhere(strSQL)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentStock", "toolExcel_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        Try
            Search()
            LoadEquipmentDetail(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentStock", "toolExcel_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function GetDTbyWhere(strSQL As String) As DataTable
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboBigCategory.SelectedValue)) = False Then
            strWhere.AppendFormat(" and B.BigCategory = '{0}' ", cboBigCategory.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboMiddleCategory.SelectedValue)) = False Then
            strWhere.AppendFormat(" and B.MiddleCategory = '{0}' ", cboMiddleCategory.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboSmallCategory.SelectedValue)) = False Then
            strWhere.AppendFormat(" and B.SmallCategory = '{0}' ", cboSmallCategory.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(txtPartNumber.Text) = False Then
            strWhere.AppendFormat(" and B.PartNumber LIKE N'%{0}%' ", txtPartNumber.Text)
        End If

        If String.IsNullOrEmpty(cboUserY.Text) = False Then
            If cboUserY.Text.Contains("1") Then
                strWhere.AppendFormat(" and B.Status = '{0}' ", "1")
            Else
                strWhere.AppendFormat(" and B.Status = '{0}' ", "0")
            End If
        End If

        Dim strOrder As String = " order by B.BigCategory,B.MiddleCategory,B.SmallCategory,B.PartNumber ASC"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder.ToString)
        Return dt
    End Function

    Private Sub Search()
        Dim strSQL As String =
            " SELECT DISTINCT C.NAME BigCategory, D.NAME MiddleCategory,E.NAME SmallCategory , B.PartNumber," & _
            " A.CNT, A.DESCRIPTION, B.SafeQty," & _
            " B.BigCategory BigCategoryCode, B.MiddleCategory MiddleCategoryCode,B.SmallCategory SmallCategoryCode " & _
            " FROM (select BigCategory,MiddleCategory,SmallCategory, " &
            " (select top 1 DESCRIPTION from m_PartContrast_t WHERE [TAvcPart] = PartNumber  AND TYPE='E') DESCRIPTION,  " &
            " PartNumber,count(1) Cnt   " &
            " FROM m_Equipment_t where InOut =1 and status=1   " &
              EquManageCommon.GetFatoryProfitcenter() &
            " group by BigCategory,MiddleCategory,SmallCategory, PartNumber  ) A  " &
            " INNER JOIN m_Equipment_t B  " &
            " ON A.PartNumber = B.PartNumber AND A.BigCategory = B.BigCategory AND A.MiddleCategory = B.MiddleCategory " &
            " LEFT JOIN m_EquipmentCategory_t C " &
            " ON B.BigCategory = C.CODE " &
            " LEFT JOIN m_EquipmentCategory_t D " &
            " ON B.MiddleCategory = D.CODE " &
            " LEFT JOIN m_EquipmentCategory_t E " &
            " ON ISNULL(B.SmallCategory,'') = E.CODE AND B.MiddleCategory = E.TYPE  " &
            " WHERE InOut=1 " &
        EquManageCommon.GetFatoryProfitcenter("B")

        dgvEquipment.DataSource = GetDTbyWhere(strSQL)

    End Sub

    Private Sub dgvEquipment_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipment.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            LoadEquipmentDetail(e.RowIndex)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentStock", "dgvEquipment_CellClick", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadEquipmentDetail(curRowIndex As Integer)
        If dgvEquipment.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim strSQL As String =
            " select EquipmentNo, B.NAME SmallCategory,  " &
            " PartNumber,ProcessParameters,case A.Status when '1' then N'1.有效' else N'0.无效'end Status,Storage,A.RemainCount  " &
            " from dbo.m_Equipment_t  A " &
            " LEFT JOIN m_EquipmentCategory_t B" &
            " ON A.SmallCategory = B.CODE AND B.TYPE =A.MiddleCategory" &
            " where InOut=1 " &
            EquManageCommon.GetFatoryProfitcenter("A")

        Dim partNumber As String = dgvEquipment.Rows(curRowIndex).Cells("PartNumber").Value.ToString
        Dim bigcategory As String = dgvEquipment.Rows(curRowIndex).Cells("BigCategoryCode").Value.ToString
        Dim middlecategory As String = dgvEquipment.Rows(curRowIndex).Cells("MiddleCategoryCode").Value.ToString
        Dim smallcategory As String = dgvEquipment.Rows(curRowIndex).Cells("SmallCategoryCode").Value.ToString

        Dim strWhere As String = String.Format(" and PartNumber = N'{0}'", partNumber)
        If String.IsNullOrEmpty(bigcategory) = False Then
            strWhere = strWhere + String.Format(" and A.BigCategory = N'{0}'", bigcategory)
        End If
        If String.IsNullOrEmpty(middlecategory) = False Then
            strWhere = strWhere + String.Format(" and A.MiddleCategory = N'{0}'", middlecategory)
        End If
        If String.IsNullOrEmpty(smallcategory) = False Then
            strWhere = strWhere + String.Format(" and A.SmallCategory = N'{0}'", smallcategory)
        End If
        If String.IsNullOrEmpty(cboUserY.Text) = False Then
            If cboUserY.Text.Contains("1") Then
                strWhere = strWhere + String.Format(" and A.Status = '{0}'", 1)
            Else
                strWhere = strWhere + String.Format(" and A.Status = '{0}'", 0)
            End If
        End If
        Dim strOrder As String = " order by InOut desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

        dgvEquipmentD.DataSource = dt

    End Sub

#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvEquipment.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvEquipmentD_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvEquipmentD.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

    Private Sub dgvEquipment_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEquipment.CellPainting

        If e.RowIndex = -1 Then Exit Sub
        If (Not IsDBNull(dgvEquipment.Rows(e.RowIndex).Cells("SafeQty").Value)) AndAlso (Not String.IsNullOrEmpty(dgvEquipment.Rows(e.RowIndex).Cells("SafeQty").Value)) Then
            If Val(dgvEquipment.Rows(e.RowIndex).Cells("CNT").Value) <= Val(dgvEquipment.Rows(e.RowIndex).Cells("SafeQty").Value) Then
                dgvEquipment.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.Red
            End If
        End If
        'If e.RowIndex = -1 Then Exit Sub
        'Try
        '    For Each dr As DataGridViewRow In Me.dgvEquipment.Rows
        '        If (Not IsDBNull(dr.Cells("SafeQty").Value)) AndAlso (Not String.IsNullOrEmpty(dr.Cells("SafeQty").Value)) Then
        '            If Val(dr.Cells("CNT").Value) <= Val(dr.Cells("SafeQty").Value) Then
        '                dr.DefaultCellStyle.BackColor = Drawing.Color.Red
        '            End If
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try
    End Sub
End Class

