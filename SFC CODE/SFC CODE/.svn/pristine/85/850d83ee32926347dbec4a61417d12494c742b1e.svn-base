Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports LXWarehouseManage
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text.RegularExpressions

Public Class FrmWpartNumber

    Private sConn As New SysDataBaseClass

    Private Sub FrmWpartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        sConn.GetControlright(Me)
        SetControlStatus()
    End Sub

    Public Function GetPrinterList() As ArrayList
        Dim list As New ArrayList
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            list.Add(printer)
        Next
        Return list
    End Function

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

    Private Enum PartGrid
        CheckBox = 0
        MOID
        PartId
        PQTY
        PrintQty
        Lot
        Bin
        LineId
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
        dgvPartNumber.Columns(PartGrid.LineId).ReadOnly = True
    End Sub

    Private Sub LoadBomIntoDataGridViewFromErp()
        Dim SPartNumber As String = txtPartNumber.Text.ToString.Trim
        Dim Sql As String = String.Empty
        If SPartNumber.Contains("|") Then
            Dim SPNList As String() = SPartNumber.Split("|")
            For index As Integer = 0 To SPNList.Length - 1
                Sql += "SELECT sfs03 JobNumber,sfs04 as PartNumber,sfs05 Quantity ,'1' PrintNumbers,sfs09 Lot,sfs08 Adress,SFB82 LineCategory FROM " & VbCommClass.VbCommClass.Factory & ".SFS_FILE," & VbCommClass.VbCommClass.Factory & ".SFB_FILE Where sfs01 ='" + SPNList(index) + "' AND SFS03=SFB01 union all   "
            Next
            Sql = Sql.Substring(0, Sql.Length - 12)
        Else
            'Sql = "SELECT sfs03 工单号,sfs04 as 料号,sfs05 数量 ,'1' 打印份数,sfs09 批次,sfs08 储位,SFB82 线别 FROM " & VbCommClass.VbCommClass.Factory & ".SFS_FILE," & VbCommClass.VbCommClass.Factory & ".SFB_FILE Where sfs01 ='" + SPartNumber + "' AND SFS03=SFB01   "
            Sql = "SELECT sfs03 JobNumber,sfs04 as PartNumber,sfs05 Quantity ,'1' PrintNumbers,sfs09 Lot,sfs08 Adress,SFB82 LineCategory FROM " & VbCommClass.VbCommClass.Factory & ".SFS_FILE," & VbCommClass.VbCommClass.Factory & ".SFB_FILE Where sfs01 ='" + SPartNumber + "' AND SFS03=SFB01   "
        End If
        '        Sql += "   order by 料号,工单号"
        Sql += "   order by PartNumber,JobNumber"

        '   Sql = "SELECT sfs03 工单号， sfs04 as 料号,sfs05 数量 ,sfs09 批次，sfs08 储位 FROM SFS_FILE Where sfs01 ='" + SPartNumber + "' order by sfs04"
        Try
            Dim oracleConn As New OracleDb("")
            Using dt As DataTable = oracleConn.ExecuteQuery(Sql).Tables(0)
                dgvPartNumber.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"

            End Using
            If dgvPartNumber.Rows.Count = 0 Then
                lblMsg.Text = "ERP中找不到该料件的信息..."
                MessageBox.Show("ERP中找不到该料件的信息...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub
            End If
            lblMsg.Text = "该料件在ERP中的数据如下表所示..."

            setGridViewBackColor()
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 将以完成发料的行的底色设置为黄色  陈忠阳 2015/06/01 14:40 Zhongyang.Chen@luxshare-ict.com
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
                    insertSql.Append("INSERT INTO m_SendMaterialRecord_t (MATERIAL_NO,MOID,QUANTITY,ISSUED_QUANTITY,LOTNO,LOCATION_ID,LINE_ID,CREATEUSER_ID,CREATETIME) ")
                    insertSql.Append(" VALUES(")
                    insertSql.AppendFormat("'{0}',", ht("MATERIAL_NO").ToString)
                    insertSql.AppendFormat("'{0}',", ht("MOID").ToString)
                    insertSql.AppendFormat("{0},", ht("QUANTITY").ToString)
                    insertSql.AppendFormat("{0},", ht("ISSUED_QUANTITY").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LOTNO").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LOCATION_ID").ToString)
                    insertSql.AppendFormat("'{0}',", ht("LINE_ID").ToString)
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
        If dgvPartNumber.Rows.Count = 0 Then
            MessageBox.Show("至少选中一个料号", "提示")
            Exit Sub
        End If
        partList.Clear()
        Dim listdgvRows As New List(Of Hashtable) '记录打印的记录信息'
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            Dim ht As New Hashtable
            ht.Add("MOID", dgvPartNumber.Rows(index).Cells("JobNumber").Value.ToString()) '工单'
            ht.Add("MATERIAL_NO", dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) '料号'
            ht.Add("QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '需求数量'
            ht.Add("ISSUED_QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '已发数量'
            ht.Add("LOTNO", dgvPartNumber.Rows(index).Cells("Lot").Value.ToString()) '批次'
            ht.Add("LOCATION_ID", dgvPartNumber.Rows(index).Cells("Adress").Value.ToString()) '库位'
            ht.Add("LINE_ID", dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()) '产线'
            listdgvRows.Add(ht)
            Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString)
            'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, 1))
            partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, countnumber, 1))
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
    Private Function GetPartNumberTotal(ByVal partNumber As String) As String
        Dim totalNum As Decimal = 0 '总数
        For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
            If dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString() = partNumber Then
                totalNum += Convert.ToDecimal(dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString)
            End If

        Next
        Return totalNum.ToString
    End Function
    Private Function GetPrinterFileFullPath() As String
        Dim path As String = VbCommClass.VbCommClass.PrintDataModle & "RunCardPrintFile\LblPrint.btw"
        Return path
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
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
            For index As Integer = 0 To dgvPartNumber.Rows.Count - 1
                If Not dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value Is Nothing AndAlso dgvPartNumber.Rows(index).Cells(PartGrid.CheckBox).Value.ToString = "True" Then
                    Dim ht As New Hashtable
                    ht.Add("MOID", dgvPartNumber.Rows(index).Cells("JobNumber").Value.ToString()) '工单'
                    ht.Add("MATERIAL_NO", dgvPartNumber.Rows(index).Cells("PartNumber").Value.ToString()) '料号'
                    ht.Add("QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '需求数量'
                    ht.Add("ISSUED_QUANTITY", dgvPartNumber.Rows(index).Cells("Quantity").Value.ToString()) '已发数量'
                    ht.Add("LOTNO", dgvPartNumber.Rows(index).Cells("Lot").Value.ToString()) '批次'
                    ht.Add("LOCATION_ID", dgvPartNumber.Rows(index).Cells("Adress").Value.ToString()) '库位'
                    ht.Add("LINE_ID", dgvPartNumber.Rows(index).Cells("LineCategory").Value.ToString()) '产线'
                    listdgvRows.Add(ht)
                    Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString)
                    'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                    partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, countnumber, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
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
    Private Sub txtPnForPrint_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPnForPrint.KeyDown

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
                        listdgvRows.Add(ht)
                        'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                        'partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
                        Dim countnumber As String = GetPartNumberTotal(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString)
                        partList.Add(New LabelHelper(dgvPartNumber.Rows(index).Cells(PartGrid.PartId).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.PQTY).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Lot).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.Bin).Value.ToString, dgvPartNumber.Rows(index).Cells(PartGrid.LineId).Value.ToString, countnumber, Convert.ToInt32(dgvPartNumber.Rows(index).Cells(PartGrid.PrintQty).Value.ToString)))
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
End Class