Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class FrmPartCategory

    '初期化
    Private Sub FrmPartCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    '查询 
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            Dim SqlStr As String = ""
            If Me.txtPAvcPart.Text <> "" Then
                SqlStr = " and BOM.PRODUCT_ID ='" & Trim(txtPAvcPart.Text.Trim.ToUpper) & "'"
            End If
            SearchRecord(SqlStr)
        Catch ex As Exception
        End Try
    End Sub

    '保存
    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        If Me.DgPartContrast.Rows.Count = 0 OrElse Me.DgPartContrast.CurrentRow Is Nothing Then
            MessageUtils.ShowInformation("没有任何保存数据!")
            Exit Sub
        End If

        If (MessageUtils.ShowConfirm("你确定料号类别修改正确保存,取消继续修改？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.DgPartContrast.EndEdit()
            Dim strSQL As New StringBuilder
            Dim strTPartId As String
            Dim strPartType As String
            Dim strPlanType As String = "Y"
            For i As Integer = 0 To Me.DgPartContrast.RowCount - 1
                strTPartId = IIf(IsDBNull(Me.DgPartContrast.Rows(i).Cells(0).Value), "", Me.DgPartContrast.Rows(i).Cells(0).Value)
                strPartType = IIf(IsDBNull(Me.DgPartContrast.Rows(i).Cells(2).Value), "", Me.DgPartContrast.Rows(i).Cells(2).Value)

                strSQL.AppendLine("UPDATE m_PartContrast_t SET PartSeriesType='" & strPartType & "',PlanType='" & strPlanType & "' WHERE tavcpart='" & strTPartId & "' AND pavcpart=tavcpart ")
            Next

            If Not String.IsNullOrEmpty(strSQL.ToString) Then
                DbOperateUtils.ExecSQL(strSQL.ToString)
                MessageUtils.ShowInformation("保存成功!")
            End If
        End If
    End Sub

    '查询 设置GRID数据
    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Try

            Dim cmbTmp As DataGridViewComboBoxColumn
            cmbTmp = DgPartContrast.Columns(2)
            cmbTmp.DisplayMember = "PartSeriesTypeName"
            cmbTmp.ValueMember = "PartSeriesTypeCode"
            cmbTmp.DataSource = DbOperateUtils.GetDataTable("SELECT PartSeriesTypeCode, PartSeriesTypeName FROM m_PartSeriesType_t WHERE Usey = 'Y' " &
                                                            "UNION SELECT '' AS PartSeriesTypeCode, '' AS PartSeriesTypeName ORDER BY PartSeriesTypeCode ")

            dt = GetPartContrastList("and isnull(PART.Type,'R') = 'R'" & Sqlstring)
            DgPartContrast.DataSource = dt

        Catch ex As Exception
        End Try
    End Sub

    '退出
    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim SqlStr As String = ""
        If Me.txtPAvcPart.Text <> "" Then
            SqlStr = " and BOM.PRODUCT_ID ='" & Trim(txtPAvcPart.Text.Trim.ToUpper) & "'"
        End If
        Dim dt As DataTable = GetPartContrastListOut("and isnull(PART.Type,'R') = 'R'" & SqlStr)

        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click

        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
        If (sdfimport.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        Dim filename As String = ""
        Dim errorMsg As String = ""
        filename = sdfimport.FileName

        '取得用户上传表数据 (5:代表5列数据)
        Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 1, 0, 3, errorMsg)

        Dim DrrR As DataRow() = dtUploadData.Select("Column1  IS NOT NULL ") '防止追加

        If CheckUploadData(DrrR) = False Then
            Exit Sub
        End If

        '批量插入到DB中
        Dim strSQL As String = GetUpdateSQL(DrrR)
        If DbOperateUtils.ExecSQL(strSQL) = "" Then
            MessageUtils.ShowInformation("成功导入！")
        End If

        '查找数据
        ToolQuery_Click(Nothing, Nothing)

    End Sub


    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB不良现象大类别
        Dim codeNameSQL As String = " select distinct PartSeriesTypeCode,PartSeriesTypeName from m_PartSeriesType_t "
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)

        Dim hastable As Hashtable = New Hashtable
        Dim tavPart As String
        Dim pavPart As String
        Dim strTypeName As String
        Dim returnCode As String = ""

        For index As Integer = 0 To DrrR.Length - 1

            tavPart = DrrR(index)(0).ToString.Trim '子件
            pavPart = DrrR(index)(1).ToString.Trim '父件
            strTypeName = DrrR(index)(2).ToString.Trim  '类别

            If hastable.Contains(tavPart + pavPart) Then
                MessageUtils.ShowError("上传文件中有重复的子件：'" + tavPart + "'")
                Return False
            End If

            hastable.Add(tavPart + pavPart, tavPart + pavPart)

            If strTypeName <> "" Then
                If CheckExistUserColumns(codeNameDT, "PartSeriesTypeName", strTypeName, returnCode) = False Then
                    MessageUtils.ShowError(String.Format("[料件类别]{0}内容不在基础类别表中,请检查后重新上传。", strTypeName))
                    Return False
                End If
            Else
                'MessageUtils.ShowError("[类型]有空值,请检查后重新上传。")
                'Return False
            End If
        Next

        Return True
    End Function

    '检查方法
    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function

    '插入SQL文取得
    Private Function GetUpdateSQL(DRS As DataRow()) As String

        Dim strSQL As String = "EXEC [Exec_UpdatePartIdSeriesTypeData] N'{0}',N'{1}',N'{2}'"

        Dim sbSQL As New StringBuilder
        For Each row As DataRow In DRS
            sbSQL.AppendFormat(strSQL, row(0).ToString(), row(2).ToString(), VbCommClass.VbCommClass.UseId)
            sbSQL.AppendLine()
        Next

        Return sbSQL.ToString
    End Function

    '查找模板文件 
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "料件类别更新上传模板")
    End Sub

    '数据操作
    Private Function GetPartContrastList(Sqlstring As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String = "SELECT TOP 100" &
        " part.tavcpart ," &
        " bom.PRODUCT_ID PAvcPart ," &
        " m_PartSeriesType_t.PartSeriesTypeCode ," &
        " bom.quantity ," &
        " part.DESCRIPTION ," &
        " CASE WHEN part.Usey = 'Y' THEN 'Y'" &
        "     ELSE 'N'" &
        " END Usey ," &
        " part.userid ," &
        " CONVERT(VARCHAR(16), part.intime, 120) intime" &
        " FROM    m_PartContrast_t part" &
        " INNER JOIN M_BOM_T bom ON part.TAvcPart = bom.COMPONENT_ID" &
        " LEFT JOIN m_PartSeriesType_t ON part.PartSeriesType = m_PartSeriesType_t.PartSeriesTypeCode" &
        " WHERE 1 = 1" &
        " AND bom.PRODUCT_ID <> bom.COMPONENT_ID" &
        " AND part.TAvcPart = bom.COMPONENT_ID" &
        " AND part.TAvcPart = part.PAvcPart" &
        " AND LEFT(TAvcPart, 1) = '9'" & Sqlstring
        StrSql = StrSql & " ORDER BY part.TAvcPart ASC"
        dt = DbOperateUtils.GetDataTable(StrSql)

        Return dt
    End Function

    '数据操作
    Private Function GetPartContrastListOut(Sqlstring As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String = "SELECT " &
        " part.tavcpart AS 子件编码," &
        " bom.PRODUCT_ID AS 主件编码 ," &
        " m_PartSeriesType_t. PartSeriesTypeName AS 料件类别 ," &
        " part.DESCRIPTION AS 规格" &
        " FROM    m_PartContrast_t part" &
        " INNER JOIN M_BOM_T bom ON part.TAvcPart = bom.COMPONENT_ID" &
        " LEFT JOIN m_PartSeriesType_t ON part.PartSeriesType = m_PartSeriesType_t.PartSeriesTypeCode" &
        " WHERE 1 = 1" &
        " AND bom.PRODUCT_ID <> bom.COMPONENT_ID" &
        " AND part.TAvcPart = bom.COMPONENT_ID" &
        " AND part.TAvcPart = part.PAvcPart" &
        " AND LEFT(TAvcPart, 1) = '9'" & Sqlstring
        StrSql = StrSql & " ORDER BY part.TAvcPart ASC"
        dt = DbOperateUtils.GetDataTable(StrSql)
        '" bom.quantity AS 配置比例," &

        Return dt
    End Function

End Class
