Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.IO

'--类别维护
'--Create by :　田玉琳
'--Create date :　2017/08/18

Public Class FrmCategory

    Public opflag As Int16 = 0  '
    Dim lastindex As Int16 = -1

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab 
            Case 13
                SendKeys.Send("{Tab}")
            Case 27 '
                Me.Close()
        End Select
    End Sub

    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '设定用戶權限
        'Dim ERigth As New SysDataBaseClass
        'ERigth.GetControlright(Me)

        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvType.Enabled = True
    End Sub

    '按钮
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.txtPartSeriesTypeCode.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.ActiveControl = Me.txtPartSeriesTypeCode
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtPartSeriesTypeCode.Enabled = False
                Me.txtPartSeriesTypeName.Enabled = True

            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.ActiveControl = Me.txtPartSeriesTypeName
        End Select
    End Sub

    'GRID显示
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""

        dgvType.Rows.Clear()

        SqlStr = "SELECT * FROM dbo.m_PartSeriesType_t"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)

        dgvType.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgvType.Rows.Add(row.Item("PartSeriesTypeCode").ToString, row.Item("PartSeriesTypeName").ToString, row.Item("BigName").ToString,
                                 row.Item("Lev").ToString, row.Item("Usey").ToString, row.Item("CreateUserId").ToString, row.Item("CreateTime").ToString)
        Next

    End Sub

#Region "数据检查"

    Private Function Checkdata() As Boolean
        If Me.txtPartSeriesTypeName.Text.Trim = "" Then
            LblMsg.Text = "类别名称不能为空"
            Me.ActiveControl = Me.txtPartSeriesTypeName
            Return False
        End If

        Return True
    End Function

#End Region

#Region "保存操作"
    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        txtPartSeriesTypeCode.Text = ""
        txtPartSeriesTypeCode.Enabled = False
        txtPartSeriesTypeName.Text = ""
        chkUsey.Checked = True
        opflag = 1
        ToolbtnState(1)
        LblMsg.Text = "请新增数据"
        Me.ActiveControl = Me.txtPartSeriesTypeName
    End Sub

    '编辑
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvType.Rows.Count = 0 OrElse Me.dgvType.CurrentRow Is Nothing Then Exit Sub

        txtPartSeriesTypeCode.Text = dgvType.CurrentRow.Cells("PartSeriesTypeCode").Value
        txtPartSeriesTypeName.Text = dgvType.CurrentRow.Cells("PartSeriesTypeName").Value
        txtBigName.Text = dgvType.CurrentRow.Cells("bigName").Value
        Dim usey As String = dgvType.CurrentRow.Cells("Usey").Value
        If usey = "Y" Then
            chkUsey.Checked = True
        Else
            chkUsey.Checked = False
        End If

        opflag = 2
        ToolbtnState(2)
        If lastindex <> -1 Then
            dgvType.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        dgvType.Rows(dgvType.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = dgvType.CurrentRow.Index
        LblMsg.Text = "请修改数据"
    End Sub

    '作废
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvType.Rows.Count = 0 OrElse Me.dgvType.CurrentRow Is Nothing Then
            MessageUtils.ShowInformation("请选择要作废的数据！")
            Exit Sub
        End If

        Try
            DbOperateUtils.ExecSQL("update m_PartSeriesType_t set usey='N',CreateUserId='" & SysMessageClass.UseId.ToLower.Trim & "',CreateTime=getdate() where PartSeriesTypeCode = '" & dgvType.CurrentRow.Cells("PartSeriesTypeCode").Value & "'")
            MessageUtils.ShowInformation("作废操作成功")

            LoadDataToDatagridview(" where PartSeriesTypeCode='" & dgvType.CurrentRow.Cells("PartSeriesTypeCode").Value & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmProduceLine", "tsbAbandon_Click", "sys")
        End Try
    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim strSQL As String = ""
        If Checkdata() = False Then Exit Sub

        Dim usey As String = "N"
        If chkUsey.Checked Then
            usey = "Y"
        End If
        Dim msg As String = ""
        If opflag = 1 Then  '新增
            strSQL = "EXEC [Exec_InsertPartSeriesTypeData] N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'"
            strSQL = String.Format(strSQL, "", txtPartSeriesTypeName.Text.Trim, txtBigName.Text.Trim, "0", VbCommClass.VbCommClass.UseId)
            msg = "保存"
        ElseIf opflag = 2 Then     '修改
            '检查文件名相同,相同不允许修改
            strSQL = "update m_PartSeriesType_t set PartSeriesTypeName =N'{0}',Usey =N'{1}',BigName='{2}' where PartSeriesTypeCode = '{3}'"
            strSQL = String.Format(strSQL, txtPartSeriesTypeName.Text.Trim(), usey, txtBigName.Text.Trim(), txtPartSeriesTypeCode.Text.Trim())
            msg = "修改"
        End If
        Try

            DbOperateUtils.ExecSQL(strSQL)
            LblMsg.Text = msg + "操作成功..."
            MessageUtils.ShowInformation(LblMsg.Text)
            If txtPartSeriesTypeCode.Text.Trim <> "" Then
                LoadDataToDatagridview("  where PartSeriesTypeCode='" & txtPartSeriesTypeCode.Text.Trim & "'")
            Else
                LoadDataToDatagridview("")
            End If
            txtPartSeriesTypeCode.Text = ""
            txtPartSeriesTypeName.Text = ""
            opflag = 0
            ToolbtnState(0)
            lastindex = -1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmCategory", "tsbSave_Click", "sys")
            MessageUtils.ShowInformation("保存数据失败！")
            Exit Sub
        End Try

    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtPartSeriesTypeCode.Text = ""
        txtPartSeriesTypeName.Text = ""
        txtBigName.Text = ""
        chkUsey.Checked = False

        opflag = 0
        ToolbtnState(0)
        If lastindex <> -1 Then
            dgvType.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    '查询 
    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim str As String = " where (1=1) "
        If txtPartSeriesTypeCode.Text <> "" Then
            str = str + " and PartSeriesTypeCode like '%" & txtPartSeriesTypeCode.Text.Trim & "%'"
        End If
        If txtPartSeriesTypeName.Text <> "" Then
            str = str + " and PartSeriesTypeName like '%" & txtPartSeriesTypeName.Text.Trim & "%'"
        End If

        LoadDataToDatagridview(str)
        lastindex = -1
        LblMsg.Text = "数据加载成功"
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim strSQL As String = "SELECT bigname 大类 ,PartSeriesTypeName 类型,lev 工艺难度级别 FROM m_PartSeriesType_t "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

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

        TableAddColumns("PartSeriesTypeCode", "System.String", dtUploadData)
        TableAddColumns("ID", "System.Int32", dtUploadData)
        For rowIndex As Integer = 0 To dtUploadData.Rows.Count - 1
            If String.IsNullOrEmpty(dtUploadData.Rows(rowIndex)(1).ToString) = False Then
                dtUploadData.Rows(rowIndex)("ID") = rowIndex + 1
            End If
        Next

        Dim DrrR As DataRow() = dtUploadData.Select("Column2  IS NOT NULL ", "ID") '防止追加

        If CheckUploadData(DrrR) = False Then
            Exit Sub
        End If

        '批量插入到DB中
        Dim strSQL As String = GetInsertSQL(DrrR)
        If DbOperateUtils.ExecSQL(strSQL) = "" Then
            MessageUtils.ShowInformation("成功导入！")
        End If

        LoadDataToDatagridview("")

    End Sub

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String

        Dim strSQL As String = "EXEC [Exec_InsertPartSeriesTypeData] N'{0}',N'{1}',N'{2}',N'{3}',N'{4}'"

        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(3).ToString(), row(1).ToString(), row(0).ToString(), row(2).ToString(), VbCommClass.VbCommClass.UseId)
            strInsertSQL.AppendLine()
        Next

        Return strInsertSQL.ToString
    End Function

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB不良现象大类别
        Dim codeNameSQL As String = " select distinct PartSeriesTypeCode,PartSeriesTypeName from m_PartSeriesType_t "
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)

        Dim hastable As Hashtable = New Hashtable

        Dim PartSeriesTypeCode As String
        Dim maxCode As String
        maxCode = TypeCodeMAX()
        For index As Integer = 0 To DrrR.Length - 1
            '类别
            Dim strCodeName As String = DrrR(index)(1).ToString.Trim
            Dim returnCode As String = ""

            If hastable.Contains(strCodeName) Then
                MessageUtils.ShowError("上传文件中有重复的类型：'" + strCodeName + "'")
                Return False
            End If
            hastable.Add(strCodeName, strCodeName)

            If strCodeName <> "" Then
                If CheckExistUserColumns(codeNameDT, "PartSeriesTypeName", strCodeName, returnCode) = False Then
                    PartSeriesTypeCode = "S" + ((maxCode + 1).ToString.PadLeft(4, "0"))
                    maxCode = maxCode + 1
                Else
                    PartSeriesTypeCode = returnCode
                End If
                DrrR(index)("PartSeriesTypeCode") = PartSeriesTypeCode
            Else
                MessageUtils.ShowError("[类型]有空值,请检查后重新上传。")
                Return False
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

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

    '取得最大的值
    Private Function TypeCodeMAX() As String
        Dim strSQL As String =
                    "   SELECT  CAST((SUBSTRING (PartSeriesTypeCode,2,4)) AS VARCHAR)  " &
                    "   FROM  m_PartSeriesType_t ORDER BY PartSeriesTypeCode DESC "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            TypeCodeMAX = "0"
        Else
            TypeCodeMAX = dt.Rows(0)(0).ToString
        End If
        Return TypeCodeMAX
    End Function

    '导入模板查看
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "料件分类上传模板")
    End Sub
End Class