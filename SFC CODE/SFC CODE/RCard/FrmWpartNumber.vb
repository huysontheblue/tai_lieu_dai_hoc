Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports SysBasicClass
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text.RegularExpressions
Imports MainFrame

Public Class FrmWpartNumber

    Private sConn As New SysDataBaseClass

    Private Sub FrmWpartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        sConn.GetControlright(Me)
        SetControlStatus()
        BindComboxWhType(Me.cmbWhType)
    End Sub

    Public Function GetPrinterList() As ArrayList
        Dim list As New ArrayList
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            list.Add(printer)
        Next
        Return list
    End Function

    ''' <summary>
    ''' 设置状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Private Sub BindComboxWhType(ByVal ColComboBox As UIHandler.CheckedComboBox)
        Dim strSQL As String = " select SortID text ,SortName value from m_Sortset_t  where SortType  = 'WHType' order by Orderid "
        Dim dt = DbOperateReportUtils.GetDataTable(strSQL)
        ColComboBox.Items.Clear()
        For Each it As DataRow In dt.Rows
            ColComboBox.Items.Add(it(0).ToString())
        Next
        'BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Private Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    Private Sub LoadData()
        cbxPrint.Items.Clear()
        Dim plist As ArrayList = GetPrinterList()
        For index As Integer = 0 To plist.Count - 1
            cbxPrint.Items.Add(plist.Item(index))
        Next
        cbxPrint.SelectedIndex = 0
        txtPartNumber.Focus()
    End Sub

    Private Sub SetControlStatus()
        'If btnPrint.Tag Is Nothing Then btnPrint.Tag = "NO"
        'If btnPrintAll.Tag Is Nothing Then btnPrintAll.Tag = "NO"
        'If btnPrint.Tag = "YES" Then
        '    btnPrint.Enabled = True
        'Else
        '    btnPrint.Enabled = False
        'End If
        'If btnPrintAll.Tag = "YES" Then
        '    btnPrintAll.Enabled = True
        'Else
        '    btnPrintAll.Enabled = False
        'End If
        If txtPnForPrint.Enabled = False Then
            btnPrint.Enabled = True
            btnPrintAll.Enabled = True
            txtTimes.Visible = False
            Label3.Visible = False
        Else
            txtTimes.Visible = True
            Label3.Visible = True
        End If
    End Sub

    Private Sub dgvPartNumber_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartNumber.CellClick
        Dim S As Integer = e.ColumnIndex
        Dim ss As Integer = e.RowIndex
        '选中打印的项
        chkSelect_CheckedChanged(sender, e)
    End Sub

    Private Sub chkSelect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Me.dgvPartNumber.Rows.Count > 0 Then
                For i As Integer = 0 To Me.dgvPartNumber.Rows.Count - 1
                    If CBool(Me.dgvPartNumber.Rows(i).Cells(0).EditedFormattedValue) Then
                        Me.dgvPartNumber.Rows(i).Cells(0).Value = True
                    Else
                        Me.dgvPartNumber.Rows(i).Cells(0).Value = False
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Dim colName As String = Nothing
        For index = 1 To Me.dgvPartNumber.Columns.Count - 1
            colName &= "," & Me.dgvPartNumber.Columns(index).HeaderText
        Next

        colName = colName.Substring(1, colName.Length - 1)
        '导出
        LoadDataToExcel(Me.dgvPartNumber, "仓库发料", colName)
       
    End Sub
    Private Enum PartGrid
        CheckBox = 0
        MOID
        PartId
        PQTY
        PrintQty
        Lot
        Bin
        LineId
        MdLine
        WHType
        ChildLine
        PPartId
    End Enum

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim PartNumber As String = txtPartNumber.Text.Trim
        LoadBomIntoDataGridViewFromErp()
        ' dgvPartNumber.Columns(0).ReadOnly = False
        dgvPartNumber.Columns(PartGrid.MOID).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.PartId).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.PQTY).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.Lot).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.Bin).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.MdLine).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.LineId).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.WHType).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.ChildLine).ReadOnly = True
        dgvPartNumber.Columns(PartGrid.PPartId).ReadOnly = True
    End Sub

    Private Sub LoadBomIntoDataGridViewFromErp()
        Me.Cursor = Cursors.WaitCursor
        Dim SPartNumber As String = txtPartNumber.Text.ToString.Trim
        Dim Sql As String = String.Empty
        Dim partNumber As String = ""
        '*******************************20160415 田玉琳***********************************************Start
        '更新 20160615 田玉琳 增加杂发数据取得
        If SPartNumber.Contains("|") Then
            Dim SPNList As String() = SPartNumber.Split("|")
            For index As Integer = 0 To SPNList.Length - 1
                partNumber = partNumber + String.Format("'{0}',", SPNList(index))
            Next
        Else
            partNumber = String.Format("'{0}',", SPartNumber)
        End If
        partNumber = partNumber.Substring(0, partNumber.Length - 1)
        'add by hgd 2017-06-07 加入超领单据 sfe_file   已过账SFE_FILE
        'update by hgd 2017-09-13 排除重复数据
        'Sql = " SELECT distinct sfs03 AS JobNumber,sfs04 AS PartNumber,sfs05 AS Quantity ,'1' AS PrintNumbers,sfs09 AS Lot,sfs08 AS Adress,SFB82 LineCategory,sfs07 AS WHType  " &
        '    " FROM {0}.SFS_FILE, {0}.SFB_FILE, {0}.ima_file, {0}.gen_file  " &
        '    " WHERE SFS03 = SFB01 And sfs04 = ima01 And ima23 = gen01 " &
        '    " AND sfs01 in({1}) and gen02 like N'%{2}%'" &
        '    " AND sfs07 like N'%{3}%'" &
        '    " UNION ALL SELECT distinct sfe01 AS JobNumber,sfe07 AS PartNumber,sfe16 AS Quantity ,'1' AS PrintNumbers,sfe10 AS Lot,sfe09  AS Adress," &
        '    " SFB82 LineCategory,sfe08 AS WHType   FROM {0}.SFE_FILE, {0}.SFB_FILE, {0}.ima_file, {0}.gen_file " &
        '    " WHERE sfe01 = SFB01 And sfe07 = ima01 And ima23 = gen01 AND sfe06<>'3' AND sfe02 in({1}) and " &
        '    " gen02 like N'%{2}%' AND sfe08 like N'%{3}%' " &
        '    " UNION ALL SELECT distinct INA01 AS JobNumber,INB04 AS PartNumber,INB09 AS Quantity,'1' PrintNumbers,INB07 AS Lot,INB06 AS Adress,inaud02 AS LineCategory,inb05 AS WHType " &
        '    " FROM {0}.ina_file, {0}.inb_file, {0}.ima_file, {0}.gen_file " &
        '    " WHERE INA01 = INB01 and inb04 = ima01 And ima23 = gen01  " &
        '    " AND INA01 in({1}) and gen02 like N'%{2}%'" &
        '    " AND inb05 like N'%{3}%'" &
        '     " UNION ALL SELECT distinct sfe01 AS JobNumber,sfe07 AS PartNumber,sfe16 AS Quantity ,'1' AS PrintNumbers,sfe10 AS Lot,'' AS Adress,sfe09 as LineCategory,sfe08 AS WHType " &
        '    " FROM    {0}.sfp_file, {0}.sfe_file,  {0}.ima_file,  {0}.gen_file " &
        '    " WHERE sfe06 ='3' and sfe02 = sfp01  And sfe07 = ima01 And ima23 = gen01  " &
        '    " AND sfe02 in({1}) and gen02 like N'%{2}%'" &
        '    " AND sfe08 like N'%{3}%'" &
        '    " ORDER BY PartNumber,JobNumber"

        'Sql = String.Format(Sql, VbCommClass.VbCommClass.Factory, partNumber, txtGuanLi.Text.Trim.ToUpper, cmbWhType.Text.Trim)

        '******************************20160415 田玉琳************************************************End
        Try
            'Dim oracleConn As New OracleDb("")
            'Using dt As DataTable = oracleConn.ExecuteQuery(Sql).Tables(0)
            '    dgvPartNumber.DataSource = dt
            '    ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
            'End Using

            ''--------------------------------------新方式开始-----------------------------------------------
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Sql = " exec GetTiptopWpartNumberPlan @Factory,@WpartNumber,@UserName,@Warehouse,@Rtvalue,@RtMsg"

            Dim paras As SqlParameter() = {New SqlParameter("@Factory", SqlDbType.VarChar, 32),
                                           New SqlParameter("@WpartNumber", SqlDbType.VarChar, 200),
                                           New SqlParameter("@UserName", SqlDbType.NVarChar, 50),
                                           New SqlParameter("@Warehouse", SqlDbType.NVarChar, 50),
                                            New SqlParameter("@Rtvalue", SqlDbType.VarChar, 1),
                                            New SqlParameter("@RtMsg", SqlDbType.NVarChar, 128)
                                          }

            paras(0).Value = VbCommClass.VbCommClass.Factory
            paras(1).Value = txtPartNumber.Text.ToString.Trim
            paras(2).Value = txtGuanLi.Text.Trim.ToUpper
            paras(3).Value = cmbWhType.Text.Trim
            paras(4).Direction = ParameterDirection.Output
            paras(5).Direction = ParameterDirection.Output

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sql, paras)


            Me.Cursor = Cursors.Default
            'Dim dt As DataTable = DbOperateUtils.GetDataTable(Sql, paras)
            If dt.Rows.Count > 0 Then
                dgvPartNumber.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
            Else
                ClearDataGridView(dgvPartNumber)

                lblMsg.Text = "ERP中找不到该料件的信息..."
                MessageBox.Show("ERP中找不到该料件的信息...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '------------------------------------新方式结束----------------------------------------------------
            'If dgvPartNumber.Rows.Count = 0 Then
            '    lblMsg.Text = "ERP中找不到该料件的信息..."
            '    MessageBox.Show("ERP中找不到该料件的信息...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            lblMsg.Text = "该料件在ERP中的数据如下表所示..."

            setGridViewBackColor()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblMsg.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "FrmWpartNumber", "LoadBomIntoDataGridViewFromErp()", "sys")
            'MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 将以完成发料的行的底色设置为黄色  陈忠阳 2015/06/01 14:40 Zhongyang.Chen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGridViewBackColor()
        Dim sqlStr As String = "SELECT (QUANTITY- ISSUED_QUANTITY) AS CountQuantity From  m_SendMaterialRecord_t Where MOID=@MOID And MATERIAL_NO=@MATERIAL_NO And LOTNO=@LOTNO And LOCATION_ID=@LOCATION_ID "
        ''Dim params As SqlParameterCollection
        ''''''''''''''
        Dim paras As SqlParameter() = {New SqlParameter("@MOID", SqlDbType.VarChar, 32), New SqlParameter("@MATERIAL_NO", SqlDbType.VarChar, 32), New SqlParameter("@LOTNO", SqlDbType.VarChar, 32), New SqlParameter("@LOCATION_ID", SqlDbType.VarChar, 32)}
        ''''''''''''''
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            For Each dr As DataGridViewRow In dgvPartNumber.Rows
                paras(0).Value = dr.Cells("JobNumber").Value.ToString
                paras(1).Value = dr.Cells("PartNumber").Value.ToString
                paras(2).Value = dr.Cells("Lot").Value.ToString
                paras(3).Value = dr.Cells("Adress").Value.ToString
                Dim dt As DataTable = Conn.GetDataTable(sqlStr.ToString(), paras)
                If Not dt Is DBNull.Value And dt.Rows.Count > 0 Then
                    If Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString) And dt.Rows(0)(0).ToString = "0" Then
                        dr.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    End If
                End If
            Next
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 将打印信息记录到DB中
    ''' </summary>
    ''' <param name="list"></param>
    ''' <remarks></remarks>
    Private Sub InsertPrinterInfoToDB(ByVal list As List(Of Hashtable))
        Dim userId As String = MainFrame.SysCheckData.SysMessageClass.UseId
        Dim insertSql As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If Not list Is Nothing And list.Count > 0 Then
                For Each ht As Hashtable In list
                    insertSql.Remove(0, insertSql.Length)
                    insertSql.Append("INSERT INTO m_SendMaterialRecord_t (MATERIAL_NO,MOID,QUANTITY,ISSUED_QUANTITY,LOTNO,LOCATION_ID,LINE_ID,MdLineId,CREATEUSER_ID,CREATETIME) ")
                    insertSql.Append(" VALUES(")
                    insertSql.AppendFormat("'{0}',", ht("MATERIAL_NO").ToString)
                    insertSql.AppendFormat("'{0}',", ht("MOID").ToString)
                    insertSql.AppendFormat("{0},", ht("QUANTITY").ToString)
                    insertSql.AppendFormat("{0},", ht("ISSUED_QUANTITY").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LOTNO").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LOCATION_ID").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LINE_ID").ToString)
                    insertSql.AppendFormat("'{0}',", ht("MdLineId").ToString)
                    insertSql.AppendFormat("'{0}',", userId)
                    insertSql.Append("GETDATE()")
                    insertSql.Append(")")
                    Conn.ExecSql(insertSql.ToString)
                Next
            End If
            setGridViewBackColor()
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '全部打印功能
    Private Sub btnPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAll.Click
        dgvPartNumber.EndEdit()
        If dgvPartNumber.Rows.Count = 0 Then
            MessageBox.Show("至少选中一个料号", "提示")
            Exit Sub
        End If
        partList.Clear()
        Dim listdgvRows As New List(Of Hashtable) '记录打印的记录信息'

        Dim strLine As String = ""
        Dim pQty As String = "0"
        Dim pPartId As String = ""
        Dim pChildLine As String = ""
        Dim lot As String = ""
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            Dim ht As New Hashtable
            pQty = "0"
            strLine = dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()
            If dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString() <> "" Then
                strLine = strLine & "(" & dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString().Trim & ")"
            End If
            If dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString() <> "0" Then

                If Not String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()) Then
                    If pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() AndAlso pChildLine = dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString() Then
                        Continue For
                    Else

                        pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()
                        pChildLine = dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()
                    End If

                    pQty = GetPartNumberChildTotal(pPartId, pChildLine)
                Else
                    If (pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() And lot = dgvPartNumber.Rows(index).Cells("LOT").Value.ToString()) AndAlso String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()) Then
                        Continue For
                    Else
                        '无子线别数量汇总
                        pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()
                        lot = dgvPartNumber.Rows(index).Cells("LOT").Value.ToString()
                        pQty = GetPartNumberNoLineTotal(dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString(), lot)
                    End If
                End If

                If pQty = "0" Then
                    MessageBox.Show("料号：" & pPartId & "打印数量合计为0,打印失败,请再试！")
                    Exit Sub
                End If

                ht.Add("MOID", dgvPartNumber.Rows(index).Cells("JobNumber").Value.ToString()) '工单'
                ht.Add("MATERIAL_NO", dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) '料号'
                ht.Add("QUANTITY", pQty) '需求数量'
                ht.Add("ISSUED_QUANTITY", pQty) '已发数量'
                ht.Add("LOTNO", dgvPartNumber.Rows(index).Cells("Lot").Value.ToString()) '批次'
                ht.Add("LOCATION_ID", dgvPartNumber.Rows(index).Cells("Adress").Value.ToString()) '库位'
                'ht.Add("LINE_ID", dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()) '产线'
                ht.Add("LINE_ID", strLine) '产线'
                ht.Add("MdLineId", dgvPartNumber.Rows(index).Cells(PartGrid.MdLine).Value.ToString) '目的工厂线别'
                listdgvRows.Add(ht)
                Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, pChildLine, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString)
                'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, 1))
                'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, countnumber, 1))

                partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, pQty, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, strLine, dgvPartNumber.Rows(index).Cells(PartGrid.MdLine).Value.ToString, countnumber, 1))
            End If

        Next
        Dim printer As String = cbxPrint.SelectedItem.ToString
        LabelHelper.PrintLabelALL(printer, partList, GetPrinterFileFullPath())
        If Not listdgvRows Is Nothing And listdgvRows.Count > 0 Then '将打印信息记录到DB中'
            InsertPrinterInfoToDB(listdgvRows)
            listdgvRows.Clear()
        End If
    End Sub

    '部分打印功能
    Public reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^([1-9]\d{0,6})$")
    Public partList As New List(Of LabelHelper)
    ''' <summary>
    ''' 根据料件编号计算该料件编号需发料的总数
    ''' </summary>
    ''' <param name="partNumber">料件编号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPartNumberTotal(ByVal partNumber As String, ByVal childLine As String, ByVal lot As String) As String
        Dim totalNum As Decimal = 0 '总数
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            'update by hgd 20171108 如果有子线别，则按子线别汇总
            If dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() = partNumber Then
                If Not String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) Then
                    If Not String.IsNullOrEmpty(childLine) Then
                        If dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString() = childLine Then
                            totalNum += Convert.ToDecimal(dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString)
                        End If
                    Else
                        'modify by cq 20190612, when this part the first row have no childline, the next have childline, totol qty no need sum.
                        If Not String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString) Then   'XN071	LD7 null null// XN071 LD7	XN052	904095364-01
                            'do nothing
                        Else
                            totalNum += Convert.ToDecimal(dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString)
                        End If
                    End If
                End If
            End If
        Next
        Return totalNum.ToString
    End Function

    ''' <summary>
    ''' 根据料件编号和子线别计算该料件编号需发料的总数
    ''' </summary>
    ''' <param name="partNumber">料件编号</param>
    ''' <param name="ChildLine">子线别</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPartNumberChildTotal(ByVal partNumber As String, ByVal ChildLine As String) As String
        Dim totalNum As Decimal = 0 '总数
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            If Not dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value Is Nothing AndAlso dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value.ToString = "True" Then
                If dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() = partNumber AndAlso dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString() = ChildLine Then
                    totalNum += Convert.ToDecimal(dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString)
                End If
            End If
        Next
        Return totalNum.ToString
    End Function


    ''' <summary>
    ''' 没有子线别，数量汇总
    ''' </summary>
    ''' <param name="partNumber">料件编号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPartNumberNoLineTotal(ByVal partNumber As String, ByVal lot As String) As String
        Dim totalNum As Decimal = 0 '总数
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            If Not dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value Is Nothing AndAlso dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value.ToString = "True" Then
                If (dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() = partNumber And dgvPartNumber.Rows(index).Cells("LOT").Value.ToString() = lot) AndAlso String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()) Then
                    totalNum += Convert.ToDecimal(dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString)
                End If
            End If
        Next
        Return totalNum.ToString
    End Function

    Private Function GetPrinterFileFullPath() As String
        Dim path As String = VbCommClass.VbCommClass.PrintDataModle & "RunCardPrintFile\LblPrint.btw"
        Return path
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        dgvPartNumber.EndEdit()

        '有线体
        '根据料号和子线体汇总数量

        '无子件
        '同一个料号的汇总数量
        Dim i As Integer = 0
        If dgvPartNumber.Rows.Count = 0 Then
            MessageBox.Show("至少选中一个料号", "提示")
            Exit Sub
        End If
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            If Not dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value Is Nothing AndAlso dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value.ToString = "True" Then
                If Not reg.IsMatch(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString) Then
                    MessageBox.Show("打印份数必须为大于零的整数", "提示")
                    Exit Sub
                End If
                i += 1
            End If
        Next
        If i = 0 Then
            MessageBox.Show("请至少选择一个需打印的料号！！！")
            Exit Sub
        End If
        Try
            partList.Clear()
            Dim listdgvRows As New List(Of Hashtable) '记录打印的记录信息'
            Dim strLine As String = ""
            Dim pQty As String = "0"
            Dim pPartId As String = ""
            Dim pChildLine As String = ""
            Dim lot As String = ""
            For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
                If Not dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value Is Nothing AndAlso dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value.ToString = "True" Then
                    Dim ht As New Hashtable
                    pQty = "0"
                    strLine = dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()
                    If dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString() <> "" Then
                        strLine = strLine & "(" & dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString().Trim & ")"
                    End If
                    If dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString() <> "0" Then
                        If Not String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()) Then
                            If pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() AndAlso pChildLine = dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString() Then
                                Continue For
                            Else
                                pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()
                                pChildLine = dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()

                            End If

                            pQty = GetPartNumberChildTotal(pPartId, pChildLine)
                        Else
                            If (pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() And lot = dgvPartNumber.Rows(index).Cells("LOT").Value.ToString()) AndAlso String.IsNullOrEmpty(dgvPartNumber.Rows(index).Cells("ChildLine").Value.ToString()) Then
                                Continue For
                            Else
                                '无子线别数量汇总
                                pPartId = dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()
                                lot = dgvPartNumber.Rows(index).Cells("LOT").Value.ToString()
                                pQty = GetPartNumberNoLineTotal(dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString(), lot)
                            End If
                        End If
                        If pQty = "0" Then
                            MessageBox.Show("料号：" & pPartId & "打印数量合计为0,打印失败,请再试！")
                            Exit Sub
                        End If

                        ht.Add("MOID", dgvPartNumber.Rows(index).Cells("JobNumber").Value.ToString()) '工单'
                        ht.Add("MATERIAL_NO", dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) '料号'
                        'ht.Add("QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '需求数量'
                        ht.Add("QUANTITY", pQty) '需求数量'
                        ht.Add("ISSUED_QUANTITY", pQty) '已发数量'
                        ht.Add("LOTNO", dgvPartNumber.Rows(index).Cells("Lot").Value.ToString()) '批次'
                        ht.Add("LOCATION_ID", dgvPartNumber.Rows(index).Cells("Adress").Value.ToString()) '库位'
                        'ht.Add("LINE_ID", dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()) '产线'
                        ht.Add("LINE_ID", strLine) '产线'
                        ht.Add("MdLineId", dgvPartNumber.Rows(index).Cells(PartGrid.MdLine).Value.ToString) '目的工厂线别'
                        listdgvRows.Add(ht)
                        Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, pChildLine, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString)
                        'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                        partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString,
                                                     pQty,
                                                     dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString,
                                                     dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString,
                                                      strLine, dgvPartNumber.Rows(index).Cells(PartGrid.MdLine).Value.ToString, countnumber,
                                                     Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))

                    End If


                    'dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, countnumber,
                End If
            Next
            Dim printer As String = cbxPrint.SelectedItem.ToString
            LabelHelper.PrintLabel(printer, partList, GetPrinterFileFullPath())

            If Not listdgvRows Is Nothing And listdgvRows.Count > 0 Then '将打印信息记录到DB中'
                InsertPrinterInfoToDB(listdgvRows)
                listdgvRows.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ''KeyPress
    Private Sub txtPnForPrint_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPnForPrint.KeyDown, txtGuanLi.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Try

                If dgvPartNumber.Rows.Count <= 0 Then
                    MessageBox.Show("请先输入发料单号")
                    Exit Sub
                End If
                If String.IsNullOrEmpty(txtPnForPrint.Text) Then
                    MessageBox.Show("请输入待打印的料号")
                    Exit Sub
                End If
                'If String.IsNullOrEmpty(txtTimes.Text) OrElse Not IsNumeric(txtTimes.Text) Then
                '    MessageBox.Show("请输入打印份数")
                '    Exit Sub
                'End If
                partList.Clear()
                Dim listdgvRows As New List(Of Hashtable) '记录打印的记录信息'
                For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
                    If dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString() = txtPnForPrint.Text Then
                        Dim ht As New Hashtable
                        ht.Add("MOID", dgvPartNumber.Rows(index).Cells("JobNumber").Value.ToString()) '工单'
                        ht.Add("MATERIAL_NO", dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) '料号'
                        ht.Add("QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '需求数量'
                        ht.Add("ISSUED_QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '已发数量'
                        ht.Add("LOTNO", dgvPartNumber.Rows(index).Cells("Lot").Value.ToString()) '批次'
                        ht.Add("LOCATION_ID", dgvPartNumber.Rows(index).Cells("Adress").Value.ToString()) '库位'
                        ht.Add("LINE_ID", dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()) '产线'
                        ht.Add("MdLineId", dgvPartNumber.Rows(index).Cells("MdLineId").Value.ToString()) '目的工厂线别'
                        listdgvRows.Add(ht)
                        'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                        'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                        Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, "", dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString)
                        partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.MdLine).Value.ToString, countnumber, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                    End If
                Next
                If partList.Count <= 0 Then
                    MessageBox.Show("待打印的料号不存在于该发料单,请确认！！")
                    Exit Sub
                End If
                Dim printer As String = cbxPrint.SelectedItem.ToString
                LabelHelper.PrintLabel(printer, partList, GetPrinterFileFullPath())
                If Not listdgvRows Is Nothing And listdgvRows.Count > 0 Then '将打印信息记录到DB中'
                    InsertPrinterInfoToDB(listdgvRows)
                    listdgvRows.Clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                txtPnForPrint.Text = ""
                txtPnForPrint.SelectAll()
            End Try
        End If
    End Sub

    Private Sub txtPartNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnOK_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For i As Int16 = 0 To Me.dgvPartNumber.RowCount - 1
            dgvPartNumber.Rows(i).Cells(PartGrid.CheckBox).Value = Me.chkAll.Checked
        Next
    End Sub

    '物料签收
    Private Sub btnConfimSign_Click(sender As Object, e As EventArgs) Handles btnConfimSign.Click
        If Me.dgvPartNumber.RowCount < 1 Then
            Me.lblMsg.Text = "请先查询!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtPartNumber.Text) Then
            Me.lblMsg.Text = "请输入发料单!"
            Me.txtPartNumber.Focus()
            Exit Sub
        End If
        If GetCheckIsSign(txtSignLine.Text) = True Then
            Me.lblMsg.Text = "当前线别已签收过，请勿重复签收!"
            Me.txtSignLine.Focus()
            Exit Sub
        End If
        Dim o_strSql As New StringBuilder
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            o_strSql.Append("UPDATE m_WpartNumberRecord_t SET IsSign='1' ,SignTime=getdate(),SignUser=N'" & Me.txtSignUser.Text & "' ")
            o_strSql.Append(" WHERE  WpartNo='" & txtPartNumber.Text & "' and (ChildLine='" & txtSignLine.Text & "' or (ChildLine ='' and LineCategory='" & txtSignLine.Text & "')) ")
            DAL.ExecSql(o_strSql.ToString)

            MessageBox.Show("签收成功,将重新载入数据!")

            Me.txtSignLine.Text = ""
            Me.txtSignUser.Text = ""
            btnOK_Click(Nothing, Nothing)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmWpartNumber", "btnConfimSign_Click()", "sys")
        End Try

    End Sub

    '检查该线别是否已签收
    Private Function GetCheckIsSign(ByVal LineId As String) As Boolean
        Dim o_strSql As New StringBuilder
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim i As Integer = 0
        Dim result As Boolean = False
        o_strSql.Append("select * from m_WpartNumberRecord_t where WpartNo='" & Me.txtPartNumber.Text.Trim & "' and IsSign='1' and (ChildLine='" & LineId & "' OR(ChildLine ='' AND LineCategory='" & LineId & "')) ")
        i = DAL.GetRowsCount(o_strSql.ToString)
        If i > 0 Then
            result = True
        End If
        Return result
    End Function

#Region "Grid行数"
    Private Sub dgvPartNumber_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvPartNumber.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

#Region "清空列表"
    ''' <summary>
    ''' 清空DataGridView 数据
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub ClearDataGridView(ByVal dgv As DataGridView)
        Dim dt As New DataTable
        dt = CType(dgv.DataSource, DataTable)
        If Not dt Is Nothing Then
            dt.Rows.Clear()
            dgv.DataSource = dt
        End If

    End Sub

    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Private Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal tbColName As String = "")
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = CType(DgMoData.DataSource, DataTable)

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next
                If Not String.IsNullOrEmpty(tbColName) AndAlso bColName = False Then
                    Swriter.WriteLine(tbColName)
                    bColName = True
                Else
                    If wColName <> "" And bColName = False Then
                        Swriter.WriteLine(wColName)
                        bColName = True

                    End If
                End If


                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


#End Region


 
End Class