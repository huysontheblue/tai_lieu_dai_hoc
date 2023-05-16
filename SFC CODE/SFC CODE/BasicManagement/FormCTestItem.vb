Imports MainFrame.SysDataHandle
Imports Aspose.Cells

Public Class FormCTestItem
    Dim sqlConn As New SysDataBaseClass
    ''' 测试大类新增
    Private Sub btnAppend_Click(sender As Object, e As EventArgs) Handles btnAppend.Click
        Dim fom As FormCTestItemData = New FormCTestItemData("", "", "", "Add")
        Try
            If fom.ShowDialog() = DialogResult.OK Then
                FormCTestItem_Load(sender, e)
            End If
        Catch ex As Exception
            fom.Dispose()
        End Try
    End Sub


    ''测试大类修改
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        Dim fom As FormCTestItemData = New FormCTestItemData(gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value, gvData.CurrentRow.Cells("ITEM_TYPE_NAME").Value, gvData.CurrentRow.Cells("ITEM_TYPE_DESC").Value, "Update")
        Try
            If fom.ShowDialog() = DialogResult.OK Then
                FormCTestItem_Load(sender, e)
            End If

        Catch ex As Exception
            fom.Dispose()
        End Try
    End Sub
    ''窗体加载事件
    Private Sub FormCTestItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combShow.Text = "是否有效"
        combFilter.Text = "测试大项代码"
        combDetailShow.Text = "是否有效"
        combDetailFilter.Text = "测试小项代码"
        Dim SQL As String
        SQL = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE Effective ='Y'"
        Dim Data As DataTable = sqlConn.GetDataTable(SQL)
        gvData.DataSource = Data
        query()
    End Sub
    ''测试大类停用
    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        If MessageBox.Show("是否要停用" + gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value, "系统作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString = "Yes" Then
            Dim sql As String = "UPDATE m_QCTestprojectowner_t SET Effective='N' WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
        End If
        FormCTestItem_Load(sender, e)
    End Sub
    ''测试大类是否有效筛选条件
    Private Sub combShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combShow.SelectedIndexChanged
        Dim sql As String
        If combShow.Text = "停用" Then
            btnEnabled.Enabled = True
            btnDisabled.Enabled = False
            sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE Effective ='N'"
        Else
            btnDisabled.Enabled = True
            btnEnabled.Enabled = False
            sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE Effective ='Y'"
        End If
        Dim Data As DataTable = sqlConn.GetDataTable(sql)
        gvData.DataSource = Data
    End Sub
    ''测试大类恢复
    Private Sub btnEnabled_Click(sender As Object, e As EventArgs) Handles btnEnabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        If MessageBox.Show("是否要恢复" + gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value, "系统恢复提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).ToString = "Yes" Then
            Dim sql As String = "UPDATE m_QCTestprojectowner_t SET Effective='Y' WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
        End If
        FormCTestItem_Load(sender, e)
    End Sub
    ''测试大项筛选查询
    Private Sub editFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles editFilter.KeyDown
        If e.KeyValue = 13 Then
            Dim sql As String = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t"
            If combFilter.Text = "测试大项代码" Then
                sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & editFilter.Text.Trim() & "'"
            ElseIf combFilter.Text = "测试大项名称" Then
                sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_NAME =N'" & editFilter.Text.Trim() & "'"
            ElseIf combFilter.Text = "测试大项描述" Then
                sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_DESC =N'" & editFilter.Text.Trim() & "'"
            End If
            If editFilter.Text.Trim() = "" Then
                sql = "SELECT ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective,Time FROM m_QCTestprojectowner_t"
            End If
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            gvData.DataSource = Data
        End If
    End Sub
    ''测试小项新增
    Private Sub btnDetailAppend_Click(sender As Object, e As EventArgs) Handles btnDetailAppend.Click
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        Dim fom As FormCTestItemson = New FormCTestItemson(Data.Rows(0)(0), gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value, "", "", "", "", "Add")
        Try
            If fom.ShowDialog() = DialogResult.OK Then
                query()
            End If
        Catch ex As Exception
            fom.Dispose()
        End Try
    End Sub
    ''测试小项修改
    Private Sub btnDetailModify_Click(sender As Object, e As EventArgs) Handles btnDetailModify.Click
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then Return
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        Dim fom As FormCTestItemson = New FormCTestItemson(Data.Rows(0)(0), gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value, gvDetail.CurrentRow.Cells("ITEM_Small_Code").Value, gvDetail.CurrentRow.Cells("ITEM_Small_Name").Value, gvDetail.CurrentRow.Cells("ITEM_Small_DESC").Value, gvDetail.CurrentRow.Cells("ITEM_Small_default").Value, "Update")
        Try
            If fom.ShowDialog() = DialogResult.OK Then
                query()
            End If
        Catch ex As Exception
            fom.Dispose()
        End Try
    End Sub
    ''大项查询方法
    Private Sub query()

        combDetailShow.Text = "是否有效"
        btnDetailDisabled.Enabled = True
        btnDetailEnabled.Enabled = False
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time FROM m_QCTestprojectownerson_t WHERE ITEM_Small_Effective ='Y' and ITEM_TYPE_ID = '" & Data.Rows(0)(0) & "'"
        Data = sqlConn.GetDataTable(Sql)
        gvDetail.DataSource = Data
    End Sub

    Private Sub combDetailShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combDetailShow.SelectedIndexChanged
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return

        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        If combDetailShow.Text = "停用" Then
            btnDetailEnabled.Enabled = True
            btnDetailDisabled.Enabled = False
            Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time  FROM m_QCTestprojectownerson_t  WHERE ITEM_Small_Effective ='N' and ITEM_TYPE_ID = '" & Data.Rows(0)(0) & "'"
        Else
            btnDetailDisabled.Enabled = True
            btnDetailEnabled.Enabled = False
            Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time  FROM m_QCTestprojectownerson_t  WHERE ITEM_Small_Effective ='Y' and ITEM_TYPE_ID = '" & Data.Rows(0)(0) & "'"
        End If
        Data = sqlConn.GetDataTable(Sql)
        gvDetail.DataSource = Data
    End Sub
    ''测试小项作废
    Private Sub btnDetailDisabled_Click(sender As Object, e As EventArgs) Handles btnDetailDisabled.Click
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then Return
        If MessageBox.Show("是否要停用" + gvDetail.CurrentRow.Cells("ITEM_Small_Code").Value, "系统作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString = "Yes" Then
            Sql = "UPDATE m_QCTestprojectownerson_t  SET ITEM_Small_Effective='N' WHERE ITEM_TYPE_ID =N'" & Data.Rows(0)(0) & "' and ITEM_Small_Code ='" & gvDetail.CurrentRow.Cells("ITEM_Small_Code").Value & "'"
            Data = sqlConn.GetDataTable(Sql)
        End If
        query()
    End Sub
    ''测试小项恢复
    Private Sub btnDetailEnabled_Click(sender As Object, e As EventArgs) Handles btnDetailEnabled.Click
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        If gvData.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then Return
        If MessageBox.Show("是否要恢复" + gvDetail.CurrentRow.Cells("ITEM_Small_Code").Value, "系统恢复提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).ToString = "Yes" Then
            Sql = "UPDATE m_QCTestprojectownerson_t SET  ITEM_Small_Effective='Y' WHERE ITEM_Small_Code =N'" & gvDetail.CurrentRow.Cells("ITEM_Small_Code").Value & "' and ITEM_TYPE_ID ='" & Data.Rows(0)(0) & "'"
            Data = sqlConn.GetDataTable(Sql)
        End If
        query()
    End Sub
    Private Sub gvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvData.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            query()
        End If
    End Sub
    ''测试小项筛选
    Private Sub editDetailFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles editDetailFilter.KeyDown
        Dim Sql As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & gvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("测试大项代码对应ID不存在请核实")
            Return
        End If
        If e.KeyValue = 13 Then

            If combDetailFilter.Text = "测试小项代码" Then
                Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time FROM m_QCTestprojectownerson_t WHERE ITEM_Small_Code =N'" & editDetailFilter.Text.Trim() & "' and ITEM_TYPE_ID ='" & Data.Rows(0)(0) & "' "
            ElseIf combDetailFilter.Text = "测试小项名称" Then
                Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time FROM m_QCTestprojectownerson_t WHERE ITEM_Small_Name =N'" & editDetailFilter.Text.Trim() & "' and ITEM_TYPE_ID ='" & Data.Rows(0)(0) & "'"
            ElseIf combDetailFilter.Text = "测试小项描述" Then
                Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time FROM m_QCTestprojectownerson_t WHERE ITEM_Small_DESC =N'" & editDetailFilter.Text.Trim() & "' and ITEM_TYPE_ID ='" & Data.Rows(0)(0) & "'"
            End If
            If editDetailFilter.Text.Trim() = "" Then
                Sql = "SELECT ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective,ITEM_Small_Time FROM m_QCTestprojectownerson_t where  ITEM_TYPE_ID =N'" & Data.Rows(0)(0) & "'"
            End If

            Data = sqlConn.GetDataTable(Sql)
            gvDetail.DataSource = Data
        End If
    End Sub

    Private Sub gvData_DataSourceChanged(sender As Object, e As EventArgs) Handles gvData.DataSourceChanged
        If gvData.Rows.Count > 0 Then
            query()
        Else
            gvDetail.DataSource = Nothing
        End If
    End Sub
    Dim sql As String


    Private Sub LoadDataToExcel1(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim wb = New Aspose.Cells.Workbook()
            Dim style = wb.Styles(wb.Styles.Add())
            style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0)
            style.Pattern = BackgroundType.Solid
            style.Font.IsBold = True

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            Dim strpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            'Environment.SpecialFolder.Desktop()
            'If Not Directory.Exists("c:\MesExport") Then
            '    Directory.CreateDirectory("c:\MesExport")
            'End If
            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                Dim columnName As String = DgMoData.Columns(comIndex).HeaderText
                wb.Worksheets(0).Cells(0, comIndex).PutValue(columnName)
                wb.Worksheets(0).Cells(0, comIndex).SetStyle(style)
                wb.Worksheets(0).AutoFitColumn(comIndex, 0, 150)
            Next
            nColqty = 1
            For Each r As DataRow In getTable.Rows
                For comIndex As Integer = 0 To getTable.Columns.Count - 1
                    wb.Worksheets(0).Cells(nColqty, comIndex).PutValue(r(comIndex).ToString())
                Next
                nColqty = nColqty + 1
            Next
            wb.Worksheets(0).FreezePanes(1, 0, 1, getTable.Columns.Count)
            Dim filepath As String = strpath + "\" + tbname + ".xlsx"
            wb.Save(filepath)
            MessageBox.Show("文件导出成功,导出位置：" + tbname + ".xlsx !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        LoadDataToExcel1(gvData, "QC项目大类_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
    End Sub

    Private Sub btnDetailExport_Click(sender As Object, e As EventArgs) Handles btnDetailExport.Click
        LoadDataToExcel1(gvDetail, "QC项目小类_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
    End Sub
End Class