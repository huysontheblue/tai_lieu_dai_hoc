Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports Aspose.Cells

Public Class FormProductitem
    Dim sqlConn As New SysDataBaseClass
    Dim TestitemIDvn As String
#Region "测试料号查找"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ssql As String = "SELECT top 100 TAvcPart,PAvcPart,CusID,Userid FROM m_PartContrast_t WHERE TAvcPart like '%" + Partid.Text.Trim() + "%'"
        Dim form As FormCheckPartid = New FormCheckPartid()
        form.sql = Ssql
        If form.ShowDialog() = DialogResult.OK Then
            Partid.Text = form.dgvData.CurrentRow.Cells("TAvcPart").Value.ToString()
            Partid.Enabled = False
            Dim sql As String = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "'  AND Effective ='Y'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            gvData.DataSource = Data
        End If
    End Sub
#End Region
#Region "测试大项新增"
    Private Sub btnAppend_Click(sender As Object, e As EventArgs) Handles btnAppend.Click
        If Partid.Text = "" Then
            MessageBox.Show("料号不能为空")
            Return

        End If
        Dim form As FormProductitemAdd = New FormProductitemAdd()
        form.Partid = Partid.Text.Trim()
        form.Type = "Add"
        If form.ShowDialog() = DialogResult.OK Then
            Dim sql As String = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "'  AND Effective ='Y'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            gvData.DataSource = Data
            'typeadd(Partid.Text.Trim())
        End If
    End Sub
#End Region
#Region "测试大项新增"
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        Dim fom As FormProductitemAdd = New FormProductitemAdd()
        Try
            fom.Type = "Update"
            fom.Partid = Partid.Text.Trim()
            fom.editDescID = gvData.CurrentRow.Cells("TestitemID").Value
            If fom.ShowDialog() = DialogResult.OK Then
                Dim sql As String = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "'  AND Effective ='Y'"
                Dim Data As DataTable = sqlConn.GetDataTable(sql)
                gvData.DataSource = Data
            End If

        Catch ex As Exception
            fom.Dispose()
        End Try
    End Sub
#End Region
#Region "测试大项停用"
    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        If MessageBox.Show("是否要停用" + gvData.CurrentRow.Cells("TestitemID").Value, "系统作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString = "Yes" Then
            Dim sql As String = "UPDATE m_QCProducttestingM_t SET Effective='N' WHERE TestitemID =N'" & gvData.CurrentRow.Cells("TestitemID").Value & "' and Partid ='" & Partid.Text.Trim() & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            sql = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and Effective='Y'"
            Data = sqlConn.GetDataTable(sql)
            gvData.DataSource = Data
        End If
    End Sub
#End Region
#Region "测试大项作废恢复"
    Private Sub btnEnabled_Click(sender As Object, e As EventArgs) Handles btnEnabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        Dim sql As String
        Dim Data As DataTable
        If MessageBox.Show("是否要恢复" + gvData.CurrentRow.Cells("TestitemID").Value, "系统恢复提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).ToString = "Yes" Then
            sql = "UPDATE m_QCProducttestingM_t SET Effective='Y' WHERE TestitemID =N'" & gvData.CurrentRow.Cells("TestitemID").Value & "' and Partid ='" & Partid.Text.Trim() & "'"
            Data = sqlConn.GetDataTable(sql)
        End If
        sql = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and Effective='N'"
        Data = sqlConn.GetDataTable(sql)
        gvData.DataSource = Data
    End Sub
#End Region
#Region "小类新增"
    Private Sub btnDetailAppend_Click(sender As Object, e As EventArgs) Handles btnDetailAppend.Click
        Dim form As FormProductitemAddson = New FormProductitemAddson()
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim sql As String = "SELECT ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and TestitemID ='" & gvData.CurrentRow.Cells("TestitemID").Value & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(sql)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("ID不能为空请检查数据")
            Return
        End If

        form.Partid = gvData.CurrentRow.Cells("Partidv").Value
        form.Type = "Add"
        form.RelationID = gvData.CurrentRow.Cells("TestitemID").Value
        form.Small = Data.Rows(0)(0).ToString()
        If form.ShowDialog() = DialogResult.OK Then
            sql = "SELECT RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM  m_QCProducttestingMson_t WHERE  RelationID ='" & gvData.CurrentRow.Cells("TestitemID").Value & "' AND Effective ='Y' and large ='" & Data.Rows(0)(0) & "'"
            Data = sqlConn.GetDataTable(sql)
            gvDetail.DataSource = Data
            sql = "SELECT ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and TestitemID ='" & gvData.CurrentRow.Cells("TestitemID").Value & "'"
            Data = sqlConn.GetDataTable(sql)
            If Data.Rows.Count = 0 Then
                MessageBox.Show("ID不能为空请检查数据")
                Return
            End If

        End If
    End Sub
#End Region
#Region "测试大类gvData属性改变事件"
    Private Sub gvData_DataSourceChanged(sender As Object, e As EventArgs) Handles gvData.DataSourceChanged
        If gvData.Rows.Count > 0 Then

            TestitemIDvn = gvData.CurrentRow.Cells("TestitemID").Value

            Dim sql As String = "SELECT ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and TestitemID =N'" & TestitemIDvn & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            If Data.Rows.Count = 0 Then
                MessageBox.Show("ID不能为空请检查数据")
                Return
            End If
            sql = "SELECT RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM  m_QCProducttestingMson_t WHERE RelationID='" & TestitemIDvn & "' AND Effective ='Y' AND	Partid='" & Partid.Text.Trim() & "'"
            Data = sqlConn.GetDataTable(sql)
            gvDetail.DataSource = Data
        Else
            Dim sql As String = "SELECT RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM  m_QCProducttestingMson_t WHERE RelationID='" & TestitemIDvn & "' AND Effective ='Y' AND	Partid='" & Partid.Text.Trim() & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            gvDetail.DataSource = Data
        End If
    End Sub
#End Region
#Region "测试大类gvData点击事件"
    Private Sub gvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvData.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            TestitemIDvn = gvData.CurrentRow.Cells("TestitemID").Value
            Dim sql As String = "SELECT ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and TestitemID ='" & TestitemIDvn & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            If Data.Rows.Count = 0 Then
                MessageBox.Show("ID不能为空请检查数据")
                Return
            End If
            sql = "SELECT RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM  m_QCProducttestingMson_t WHERE RelationID='" & TestitemIDvn & "' AND Effective ='Y' AND	Partid='" & Partid.Text.Trim() & "'"
            Data = sqlConn.GetDataTable(sql)
            gvDetail.DataSource = Data
        End If
    End Sub
#End Region
#Region "小类修改"
    Private Sub btnDetailModify_Click(sender As Object, e As EventArgs) Handles btnDetailModify.Click
        If gvDetail.Rows.Count < 1 OrElse gvDetail.CurrentRow Is Nothing Then Return
        Dim form As FormProductitemAddson = New FormProductitemAddson()
        Dim sql As String
        Dim Data As DataTable

        'Dim sql As String = "SELECT ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and TestitemID ='" & TestitemIDvn & "'"
        'Dim Data As DataTable = sqlConn.GetDataTable(sql)
        'If Data.Rows.Count = 0 Then
        '    MessageBox.Show("ID不能为空请检查数据")
        '    Return
        'End If


        Try
            form.Partid = gvData.CurrentRow.Cells("Partidv").Value
            form.Type = "Update"
            form.RelationID = gvData.CurrentRow.Cells("TestitemID").Value
            form.Small = gvData.CurrentRow.Cells("colmID").Value
            form.editCode.Text = gvDetail.CurrentRow.Cells("SmallID").Value
            form.SmallID = gvDetail.CurrentRow.Cells("SmallID").Value
            form.editName.Text = gvDetail.CurrentRow.Cells("SmallName").Value
            form.Serialnumber.Text = gvDetail.CurrentRow.Cells("SmallName1").Value
            'modify by hgd 20200604 
            form.sId = gvDetail.CurrentRow.Cells("colSonID").Value
            If form.ShowDialog() = DialogResult.OK Then
                Sql = "SELECT RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM m_QCProducttestingMson_t WHERE Partid='" & Partid.Text.Trim() & "' and RelationID='" & TestitemIDvn & "' AND Effective ='Y'"
                Data = sqlConn.GetDataTable(Sql)
                gvDetail.DataSource = Data
            End If
        Catch ex As Exception
            form.Dispose()
        End Try
    End Sub
#End Region
#Region "小类作废"
    Private Sub btnDetailDisabled_Click(sender As Object, e As EventArgs) Handles btnDetailDisabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        Dim sSmall As String
        sSmall = gvDetail.CurrentRow.Cells("SmallID").Value.ToString
        If MessageBox.Show("是否要停用" + sSmall, "系统作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString = "Yes" Then
            Dim sql As String = "UPDATE m_QCProducttestingMson_t SET Effective='N' WHERE RelationID =N'" & gvData.CurrentRow.Cells("TestitemID").Value & "' and SmallID ='" & gvDetail.CurrentRow.Cells("SmallID").Value & "' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            sql = "SELECT  RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM m_QCProducttestingMson_t WHERE RelationID='" & gvData.CurrentRow.Cells("TestitemID").Value & "' AND Effective ='Y' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
            Data = sqlConn.GetDataTable(sql)
            gvDetail.DataSource = Data
        End If
    End Sub
#End Region
#Region "小类作废恢复"
    Private Sub btnDetailEnabled_Click(sender As Object, e As EventArgs) Handles btnDetailEnabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then Return
        Dim sql As String
        Dim Data As DataTable
        If MessageBox.Show("是否要恢复" + gvDetail.CurrentRow.Cells("SmallID").Value, "系统恢复提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).ToString = "Yes" Then
            sql = "UPDATE m_QCProducttestingMson_t SET Effective='Y' WHERE RelationID =N'" & gvData.CurrentRow.Cells("TestitemID").Value & "' and SmallID ='" & gvDetail.CurrentRow.Cells("SmallID").Value & "' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
            Data = sqlConn.GetDataTable(sql)
        End If
        sql = "SELECT  RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM m_QCProducttestingMson_t WHERE RelationID='" & gvData.CurrentRow.Cells("TestitemID").Value & "' AND Effective ='N' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
        Data = sqlConn.GetDataTable(sql)
        gvDetail.DataSource = Data
    End Sub
#End Region
#Region "窗体加载事件"
    Private Sub FormProductitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combShow.Text = "是否有效"
        combDetailShow.Text = "是否有效"
    End Sub
#End Region
#Region "大类筛选"
    Private Sub combShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combShow.SelectedIndexChanged
        Dim sql As String
        If combShow.Text = "停用" Then
            btnEnabled.Enabled = True
            btnDisabled.Enabled = False
            sql = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and Effective='N'"
        Else
            btnDisabled.Enabled = True
            btnEnabled.Enabled = False
            sql = "SELECT Partid,TestitemID,TestitemName,(SELECT TypeName FROM m_QCTypedata_t WHERE TypeID = TypedataID) AS TypeName,  Effective,Usid,ID FROM m_QCProducttestingM_t WHERE Partid='" & Partid.Text.Trim() & "' and Effective='Y'"
        End If
        Dim Data As DataTable = sqlConn.GetDataTable(sql)
        gvData.DataSource = Data
    End Sub
#End Region
#Region "小类筛选"
    Private Sub combDetailShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combDetailShow.SelectedIndexChanged
        If gvData.Rows.Count = 0 Then
            Return
        End If
        Dim sql As String
        If combDetailShow.Text = "停用" Then
            btnDetailEnabled.Enabled = True
            btnDetailDisabled.Enabled = False
            sql = "SELECT  RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM m_QCProducttestingMson_t WHERE RelationID='" & gvData.CurrentRow.Cells("TestitemID").Value & "' AND Effective ='N' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
        Else
            btnDetailDisabled.Enabled = True
            btnDetailEnabled.Enabled = False
            sql = "SELECT  RelationID,Partid,SmallID,SmallName,Serialnumber,Effective,Usid,[TIME],ID FROM m_QCProducttestingMson_t WHERE RelationID='" & gvData.CurrentRow.Cells("TestitemID").Value & "' AND Effective ='Y' AND Partid ='" & gvData.CurrentRow.Cells("Partidv").Value & "'"
        End If
        Dim Data As DataTable = sqlConn.GetDataTable(sql)
        gvDetail.DataSource = Data
    End Sub
#End Region

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        LoadDataToExcel1(gvData, "产品测试项目大类_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
    End Sub
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

    Private Sub btnDetailExport_Click(sender As Object, e As EventArgs) Handles btnDetailExport.Click
        LoadDataToExcel1(gvDetail, "产品测试项目小类_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
    End Sub


End Class