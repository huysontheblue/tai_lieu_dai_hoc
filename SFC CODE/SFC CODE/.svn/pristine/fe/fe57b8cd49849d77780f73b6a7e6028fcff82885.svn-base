Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Collections.Generic
Imports System.Web
Imports System.Collections
Imports System.Text.RegularExpressions
Imports MainFrame
Imports System.Drawing
Imports SysBasicClass
'Imports SysBasicClass

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表变更
''' -------------------修改记录---------------------
''' 黄广都   2016-10-20   工装设备五金关系需求变更：1.输入五金料号自动带出五金料号规格、
'''                       没有料号规格也可以让其保存、输入测试五金料号，自动带出测试五金料号规格。添加数量、储位
''' 
''' </summary>
''' <remarks>修改流程卡后影响范围</remarks>
Public Class FrmProductEquipment

#Region "属性"

    Dim ID As Integer

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Enum Grid
        PartNumber
        PartNumberFormat
        HardWarePartNumber
        HardWareFortmat
        TestPart
        TestDescription
        Qty
        Storage
        CreateTime
        FactoryName
        Profitcenter
        ID
        CreatUser
        

    End Enum

    Private Enum CDImportGrid
        PartNumber
        PartNumberFormat
        HardWarePartNumber
        HardWareFortmat
        TestPart
        TestDescription
        Qty
        Storage
        CreatUser
    End Enum
#End Region

#Region "事件"

    Private Sub FrmProductEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        BindData()
    End Sub

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        ClearText()
        txtCreateUser.Text = VbCommClass.VbCommClass.UseName
    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String
            If CheckInput() = False Then
                Exit Sub
            End If

            Dim CreateUser As String = VbCommClass.VbCommClass.UseId
            Dim partNumber As String = Me.txtPartNumber.Text.Trim
            Dim pnFormat As String = Me.txtFormat.Text.Trim
            Dim hardWarepartNumber As String = Me.txtHardWarePartNumber.Text.Trim
            Dim hardWareFormat As String = Me.txtHardWareFormat.Text.Trim

            Dim testpart As String = Me.txtTestPart.Text.Trim
            Dim testdescription As String = Me.txtTestDescription.Text.Trim
            Dim storage As String = Me.txtStorage.Text.Trim

            Dim qty, adviceQTY As Int32


            Try
                qty = IIf(txtQty.Text = "", 0, Int32.Parse(txtQty.Text))
                adviceQTY = IIf(txtadviceQTY.Text = "", 0, Int32.Parse(txtadviceQTY.Text))
            Catch ex As Exception
                MessageUtils.ShowError("输入的数量不为数值！")
                Return
            End Try
            If OperateFlag = EditMode.ADD Then 'add

                '2016-10-20 hgd modify 注释说明：张艳锋提出没有料号也可以让其保存
                'Dim des As String = getFormat(partNumber)

                'If des = "" Then
                '    MessageUtils.ShowError("工装治具料号:" + Me.txtPartNumber.Text.Trim + " 不存在!")
                '    Exit Sub
                'End If

                If (CheckIsRepeat(partNumber, hardWarepartNumber) = False) Then
                    MessageUtils.ShowError(String.Format("工装治具料号{0}五金料号{1}已存在!", partNumber, hardWarepartNumber))
                    Return
                End If

                strSQL = " INSERT into m_equipmenthardware_t(PartNumber,HardWarePartNumber,CreateTime,CreatUser,PartNumberFormat,HardWareFortmat" &
                        ",TestPart,TestDescription,Qty,Storage,FactoryName,Profitcenter,adviceQTY) values (" &
                       "N'" & partNumber & "',N'" & hardWarepartNumber & "',getdate(),N'" & CreateUser & "',N'" & pnFormat & "',N'" & hardWareFormat & "',N'" &
                       testpart & "',N'" & testdescription & "'," & qty & ",N'" & storage & "',N'" &
                        VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & adviceQTY & "') "

                DbOperateUtils.ExecSQL(strSQL)
            ElseIf OperateFlag = EditMode.EDIT Then 'update
                strSQL = String.Format(" update  m_equipmenthardware_t set PartNumber=N'{0}',HardWarePartNumber=N'{1}',CreatUser=N'{2}',PartNumberFormat=N'{3}'," &
                                       " HardWareFortmat=N'{4}',TestPart=N'{5}',TestDescription=N'{6}',Qty={7},Storage=N'{8}',FactoryName=N'{9}',Profitcenter=N'{10}',adviceQTY = {12} where ID={11}",
                                       partNumber, hardWarepartNumber, CreateUser, pnFormat, hardWareFormat, testpart, testdescription, qty, storage,
                                       VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, ID, adviceQTY)
                DbOperateUtils.ExecSQL(strSQL)
            End If
            MessageUtils.ShowInformation("工装治具料号五金料号关系保存成功!")

            OperateFlag = EditMode.UNDO
            SetControlStatus(EditMode.UNDO)
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProductEquipment", "ToolSave_Click", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckIsRepeat(PartNumber As String, HardWarePartNumber As String) As Boolean
        Dim strSQL As String = ""
        strSQL = " select PartNumber,HardWarePartNumber from m_equipmenthardware_t " &
                 " where  PartNumber=N'" + PartNumber + "' and  HardWarePartNumber=N'" + HardWarePartNumber + "'" &
                 EquManageCommon.GetFatoryProfitcenter()

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub GridList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellClick
        If Me.dgvResult.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.EDIT Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If

        Dim bv = CType(dgvResult.CurrentRow.Cells("ChkItem").FormattedValue, Boolean)

        If dgvResult.Columns(e.ColumnIndex).Name = "ChkItem" Then
            dgvResult.CurrentRow.Cells("ChkItem").Value = IIf(bv, False, True)
        End If


        Me.txtPartNumber.Text = Me.dgvResult.Item("PartNumber", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Me.txtFormat.Text = Me.dgvResult.Item("PartNumberFormat", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Me.txtHardWarePartNumber.Text = Me.dgvResult.Item("HardWarePartNumber", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Me.txtHardWareFormat.Text = Me.dgvResult.Item("HardWareFortmat", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Me.txtCreateUser.Text = Me.dgvResult.Item("CreatUser", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()

        Me.txtTestPart.Text = Me.dgvResult.Item("TestPart", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Me.txtTestDescription.Text = Me.dgvResult.Item("TestDescription", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        Dim qty As Int32
        Try
            qty = Int32.Parse(Me.dgvResult.Item("Qty", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim())
        Catch ex As Exception
            qty = 0
        End Try
        Dim adviceQTY As Int32
        Try
            adviceQTY = Int32.Parse(Me.dgvResult.Item("adviceQTY", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim())
        Catch ex As Exception
            adviceQTY = 0
        End Try
        Me.txtQty.Text = qty.ToString()
        Me.txtadviceQTY.Text = adviceQTY.ToString()
        Me.txtStorage.Text = Me.dgvResult.Item("Storage", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim()
        ID = CInt(Me.dgvResult.Item("eid", Me.dgvResult.CurrentRow.Index).Value.ToString.Trim())
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
        If Me.dgvResult.RowCount < 1 Then Exit Sub
        Me.txtPartNumber.Text = Me.dgvResult.Item(Grid.PartNumber.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtFormat.Text = Me.dgvResult.Item(Grid.PartNumberFormat.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtHardWarePartNumber.Text = Me.dgvResult.Item(Grid.HardWarePartNumber.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtHardWareFormat.Text = Me.dgvResult.Item(Grid.HardWareFortmat.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtTestPart.Text = Me.dgvResult.Item(Grid.TestPart.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtTestDescription.Text = Me.dgvResult.Item(Grid.TestDescription.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtQty.Text = Me.dgvResult.Item(Grid.Qty.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtStorage.Text = Me.dgvResult.Item(Grid.Storage.ToString, dgvResult.CurrentRow.Index).Value.ToString()
        Me.txtCreateUser.Text = Me.dgvResult.Item(Grid.CreatUser.ToString, dgvResult.CurrentRow.Index).Value.ToString()


    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
    End Sub

    Private Sub tooSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
        ClearText()
        'Me.txtPartNumber.Enabled = True
        'Me.txtFormat.Enabled = True
        'Me.txtHardWarePartNumber.Enabled = True
        'Me.txtHardWareFormat.Enabled = True
        SetControlEnable(True)
    End Sub

    Private Sub txtPartNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (OperateFlag = EditMode.SEARCH) Then
                BindData()
                '2016-10-20 Modify hgd 用户不限制料号是否存在，都可保存
                'Else
                '    Dim des As String = getFormat(Me.txtPartNumber.Text.Trim)
                '    If des = "" Then
                '        MessageUtils.ShowError("工装治具料号:" + Me.txtPartNumber.Text.Trim + " 不存在!")
                '    Else
                '        Me.Label2.Visible = True
                '        Me.txtFormat.Visible = True
                '        Me.txtFormat.Text = des
                '        Me.txtFormat.Enabled = False
                '    End If
            End If
        End If
    End Sub

    Private Sub txtPartNumber_TextChanged(sender As Object, e As EventArgs) Handles txtPartNumber.TextChanged
        Dim des As String = getFormat(Me.txtPartNumber.Text.Trim)
        Me.txtFormat.Text = des
    End Sub

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        BindData()
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Function GetChecked() As String
        Dim IDStr As String = ""
        For Each dgvr As DataGridViewRow In dgvResult.Rows
            Dim bv = CType(dgvr.Cells("ChkItem").Value, Boolean)
            Dim ID = dgvr.Cells("eid").Value.ToString()
            If bv = True Then
                IDStr += ID + ","
            End If
        Next
        Return IDStr.TrimEnd(",")
    End Function

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        'If Me.dgvResult.Rows.Count = 0 OrElse Me.dgvResult.CurrentRow Is Nothing OrElse ID = 0 Then
        '    MessageUtils.ShowInformation("请选择需要删除的项！")
        '    Exit Sub
        'Else
        '    If MessageUtils.ShowConfirm("确认删除吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
        '        DbOperateUtils.ExecSQL(" delete from m_EquipmentHardWare_t where ID=" & ID)
        '        MessageUtils.ShowInformation("删除成功！")
        '        ClearText()
        '        BindData()
        '    End If
        'End If
        Dim IDStr = GetChecked()
        If String.IsNullOrEmpty(IDStr) Then
            MessageUtils.ShowInformation("请选择需要删除的项！")
            Exit Sub
        End If
        If MessageUtils.ShowConfirm("确认删除吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            DbOperateUtils.ExecSQL(" delete from m_EquipmentHardWare_t where ID in (" + IDStr + ")")
            MessageUtils.ShowInformation("删除成功！")
            ClearText()
            BindData()
        End If
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 9, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PartNumber IS NOT NULL AND HardWarePartNumber IS NOT NULL ") '防止追加

            '检验数据
            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("FactoryName", "System.String", dtUploadData)
            TableAddColumns("Profitcenter", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New Dictionary(Of String, String)
            dics2.Add("PartNumber", "PartNumber")
            dics2.Add("HardWarePartNumber", "HardWarePartNumber")
            dics2.Add("PartNumberFormat", "PartNumberFormat")
            dics2.Add("HardWareFortmat", "HardWareFortmat")
            dics2.Add("TestPart", "TestPart")
            dics2.Add("TestDescription", "TestDescription")
            dics2.Add("Qty", "Qty")
            dics2.Add("Storage", "Storage")
            dics2.Add("CreatUser", "CreatUser")
            dics2.Add("FactoryName", "FactoryName")
            dics2.Add("Profitcenter", "Profitcenter")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                 
                    usercopy.Rows.Add(row(0).ToString().Trim, row(1).ToString().Trim, row(2).ToString().Trim, row(3).ToString().Trim, row(4).ToString().Trim,
                                      row(5).ToString(), row(6).ToString().Trim, row(7).ToString(), row(8).ToString().Trim,
                                 VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_EquipmentHardWare_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    BindData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProductEquipment.toolImport_Click", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        'Dim StrSql As String = "select PartNumber 设备治具料号,PartNumberFormat 设备治具规格 ,HardWarePartNumber 五金料号,HardWareFortmat 五金料号规格, " &
        '                    "(select UserName from m_Users_t where CreatUser = USERID) 创建用户, " &
        '                    "CreateTime 创建时间,FactoryName 厂区,Profitcenter 利润中心,TestPart 测试五金料号,TestDescription 测试五金料号规格,Qty 数量,Storage 储位 " &
        '                    "from  m_EquipmentHardWare_t  where 1=1  " &
        '                    EquManageCommon.GetFatoryProfitcenter()

        'StrSql = StrSql + "  " & GetSqlWhere() & " order by CreateTime desc "

        'Dim dt As DataTable = DbOperateUtils.GetDataTable(StrSql)

        Dim dt As DataTable
        dt = dgvResult.DataSource
        'ExcelHelper.ExportDTtoExcel(dt, "工装设备五金对照关系", filename)
        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub

    Private Sub dgvResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvResult.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 4, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

#Region "方法"

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB中设备编号
        Dim equPNSql As String = " select EquipmentNo from m_Equipment_t where 1=1 " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtEquPN As DataTable = DbOperateUtils.GetDataTable(equPNSql)

        'DB中设备料号
        Dim partnumberSql As String = " select DESCRIPTION,TAvcPart PartNumber from m_PartContrast_t where type = 'E' "
        Dim dtPN As DataTable = DbOperateUtils.GetDataTable(partnumberSql)

        Dim strSQL As String = " select PartNumber,HardWarePartNumber from m_equipmenthardware_t where 1= 1 " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtHardWare As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'Dim ht As New Hashtable
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1

            Dim PartNumber As String = DrrR(index)(CDImportGrid.PartNumber.ToString).ToString.Trim
            Dim HardWarePartNumber As String = DrrR(index)(CDImportGrid.HardWarePartNumber.ToString).ToString.Trim

            Dim returnCode As String = ""

            'If PartNumber <> "" Then
            '2016-10-20 Modify hgd 取消检查料号是否存在, 不存在也可以让其保持
            '    If CheckExistUserColumns(dtPN, "PartNumber", PartNumber, returnCode) = False Then
            '        MessageUtils.ShowError("上传设备料号没有在资料库中：'" + PartNumber + "'")
            '        Return False
            '    Else
            '        DrrR(index)(CDImportGrid.PartNumberFormat.ToString) = returnCode
            '    End If
            'Else
            '    MessageUtils.ShowError("设备治具料号有空值,请检查后重新上传。")
            '    Return False
            'End If

            If PartNumber.Length < 1 Then
                MessageUtils.ShowError("设备治具料号有空值,请检查后重新上传。")
                Return False
            End If

            Dim values As String = PartNumber + ":" + HardWarePartNumber
            If hastable.Contains(values) Then
                MessageUtils.ShowError(String.Format("上传文件中有重复的设备治具料号{0}和五金料号{1}", PartNumber, HardWarePartNumber))
                Return False
            Else
                hastable.Add(values, values)
            End If

            If PartNumber <> "" And HardWarePartNumber <> "" Then
                Dim dr() As DataRow = dtHardWare.Select(String.Format(" {0} = '{1}' and {2} = '{3}'", "PartNumber",
                                                                      PartNumber, "HardWarePartNumber", HardWarePartNumber))
                If dr.Length > 0 Then
                    MessageUtils.ShowError("设备治具料号和五金料号重复数据,请检查后重新上传。")
                    Return False
                End If
            Else
                MessageUtils.ShowError("设备治具料号或五金料号有空值,请检查后重新上传。")
                Return False
            End If
        Next

        Return True
    End Function

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

    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If (Me.txtPartNumber.Text.Trim <> "") Then
            sbSqlWhere.Append(" and PartNumber like N'%" + Me.txtPartNumber.Text.Trim + "%'")
        End If
        If (Me.txtHardWarePartNumber.Text.Trim <> "") Then
            sbSqlWhere.Append(" and HardWarePartNumber like N'%" + Me.txtHardWarePartNumber.Text.Trim + "%'")
        End If
        If (Me.txtHardWareFormat.Text.Trim <> "") Then
            sbSqlWhere.Append(" and HardWareFortmat like N'%" + Me.txtHardWareFormat.Text.Trim + "%'")
        End If
        If (Me.txtTestPart.Text.Trim <> "") Then
            sbSqlWhere.Append(" and TestPart like N'%" + Me.txtTestPart.Text.Trim + "%'")
        End If
        If (Me.txtTestDescription.Text.Trim <> "") Then
            sbSqlWhere.Append(" and TestDescription like N'%" + Me.txtTestDescription.Text.Trim + "%'")
        End If
        If (Me.txtStorage.Text.Trim <> "") Then
            sbSqlWhere.Append(" and Storage like N'%" + Me.txtStorage.Text.Trim + "%'")
        End If
        If (Me.txtQty.Text.Trim <> "") And (txtQty.Tag.ToString() <> "y") And (txtQty.Text.ToString() <> "0") Then
        
            sbSqlWhere.Append(" and Qty = " + Me.txtQty.Text.Trim)
        End If
        txtQty.Tag = ""

        Return sbSqlWhere.ToString
    End Function

    Private Sub BindData()

        If (Me.txtQty.Text.Trim <> "") Then
            Dim qty As Int32
            Try
                qty = Int32.Parse(txtQty.Text)
            Catch ex As Exception
                MessageUtils.ShowError("输入的数量不为数值！")
                Return
            End Try
        End If


        Dim StrSql As String = " SELECT TOP 500 PartNumber,PartNumberFormat,HardWarePartNumber,HardWareFortmat,TestPart, TestDescription," & _
                               "  ( SELECT COUNT(1) FROM m_Equipment_t WHERE PartNumber = A.PARTNUMBER AND m_Equipment_t.Status=1  AND FactoryName='" & VbCommClass.VbCommClass.Factory & "' " & _
                               "    AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "') as QTY," & _
                               " Storage,CreateTime,FactoryName,Profitcenter " &
                               "    , ID, CreatUser = b.UserName ,ISNULL(adviceQTY,0) AS adviceQTY  " & _
                               " FROM  m_EquipmentHardWare_t a " &
                               "	 LEFT JOIN m_Users_t b ON a.CreatUser=b.UserID  WHERE 1=1  " & EquManageCommon.GetFatoryProfitcenter()

        StrSql = StrSql + "  " & GetSqlWhere() & " order by CreateTime desc "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(StrSql)

        dgvResult.DataSource = dt
    End Sub

    Private Function getFormat(ByVal stringPartNumber As String) As String
        Dim dt As DataTable
        dt = DbOperateUtils.GetDataTable(" SELECT TAvcPart,DESCRIPTION FROM m_PartContrast_t WHERE TAvcPart=N'" + stringPartNumber + "' ")
        If (dt.Rows.Count > 0) Then
            Return dt.Rows(0).Item("DESCRIPTION").ToString
        Else
            Return ""
        End If
    End Function

    Private Sub ClearText()

        For Each contr As Control In Panel1.Controls
            If (TypeOf contr Is TextBox) Then
                contr.Text = ""
            End If
        Next
    End Sub

    Private Function CheckInput() As Boolean
        If Me.txtPartNumber.Text = "" Then
            MessageUtils.ShowError("请输入工装治具料号！")
            txtPartNumber.Select()
            Return False
        End If
        If Me.txtHardWarePartNumber.Text = "" Then
            MessageUtils.ShowError("请输入五金料号！")
            txtHardWarePartNumber.Select()
            Return False
        End If

        'Re-add by cq20170728
        If Me.txtFormat.Text = "" Then
            MessageBox.Show("请输入工装治具规格！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFormat.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub SetControlStatus(ByVal flag As EditMode)

        SetButtonEnable(False)

        Select Case UCase(flag)
            Case EditMode.ADD '新增   
                toolSave.Enabled = True
                toolUndo.Enabled = True
                SetControlEnable(True)
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
                SetControlEnable(True)
            Case EditMode.UNDO '初始化
                toolNew.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolSearch.Enabled = True
                SetControlEnable(False)
                ClearText()
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolRefresh.Enabled = True
                dgvResult.Enabled = True
                SetControlEnable(True)
        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolEdit.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
    End Sub

    Private Sub SetControlEnable(bFlag As Boolean)
        'Me.txtPartNumber.Enabled = bFlag
        'Me.txtHardWareFormat.Enabled = bFlag
        'Me.txtHardWarePartNumber.Enabled = bFlag

        For Each contr As Control In Panel1.Controls
            If (TypeOf contr Is TextBox) Then
                contr.Enabled = bFlag
            End If
        Next
    End Sub

#End Region
    ''' <summary>
    ''' 获取TTop料号表中料号品名规格
    ''' </summary>
    ''' <param name="part">料号</param>
    ''' <returns>料号品名规格</returns>
    Private Function GetPartDescription(ByRef part As String) As String
        Dim TTopdb As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
        Try
            Dim sqlStr As String
            sqlStr = String.Format("select  IMA02 || ' ' || IMA021 as PartDes from LXXT.ima_file where IMA01='{0}'", part)
            Return TTopdb.ExecuteScalar(sqlStr).ToString()
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''五金料号失去焦点时获取此料号品名规格
    Private Sub txtHardWarePartNumber_Leave(sender As Object, e As EventArgs) Handles txtHardWarePartNumber.Leave
        If txtHardWarePartNumber.Text.Trim().Length > 1 Then
            txtHardWareFormat.Text = GetPartDescription(txtHardWarePartNumber.Text)
        End If
    End Sub
    ''测试五金料号失去焦点时获取此料号品名规格
    Private Sub txtTestPart_Leave(sender As Object, e As EventArgs) Handles txtTestPart.Leave
        If txtTestPart.Text.Trim().Length > 1 Then
            txtTestDescription.Text = GetPartDescription(txtTestPart.Text)
        End If
    End Sub

    Private Sub dgvResult_CellLeave(sender As Object, e As DataGridViewCellEventArgs)


    End Sub
    Dim adviceQTY1 As String = ""
    Dim adviceQTY2 As String = ""
    Dim A As String = ""
    Dim PartNumber1 As String
    Private Sub dgvResult_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvResult.CellBeginEdit
        adviceQTY1 = dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value
        A = dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(12).Value
        PartNumber1 = dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(1).Value
    End Sub

    Private Sub dgvResult_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellEndEdit
        If dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value Is Nothing OrElse dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value.ToString() = "" Then
            dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value = adviceQTY1
            Return
        End If
        If dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value.ToString() = adviceQTY1 Then
            Return
        End If
        adviceQTY2 = dgvResult.Rows(dgvResult.CurrentRow.Index).Cells(14).Value.ToString()

        Dim Sql As String = "UPDATE m_equipmenthardware_t SET adviceQTY = '" & adviceQTY2 & "',CreatUser='" & VbCommClass.VbCommClass.UseId & "' WHERE ID = '" & A & "' AND PartNumber = '" & PartNumber1 & "'"
        DbOperateUtils.GetDataSet(Sql)
    End Sub
End Class