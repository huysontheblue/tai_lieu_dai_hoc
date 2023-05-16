
'--不良条码打印申请作业
'--Create by :　马锋
'--Create date :　2014/08/21
'--Update date :  
'--Ver : V01
'更新者：田玉琳
'更新日期：2019/08/09
'更新内容：连接数据库方式高速，打印数据显示调整

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region


Public Class FrmReprint
    ' Alias "Sleep" 
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim TxtFileStr As New StringBuilder
    Dim PrintTxt As New StringBuilder
    Dim strMOId As String

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAddNew.Click
        Try
            SetStatus(1)
            Me.txtMOId.Focus()
        Catch ex As Exception
            Me.lblMessage.Text = "新增失败，系统异常！"
        End Try
    End Sub

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolAddNew.Enabled = IIf(ToolAddNew.Tag.ToString = "YES", True, False)
                Me.ToolPrt.Enabled = IIf(ToolPrt.Tag.ToString = "YES", True, False)
                Me.ToolDelTask.Enabled = IIf(ToolDelTask.Tag.ToString = "YES", True, False)
                Me.toolCheck.Enabled = IIf(toolCheck.Tag.ToString = "YES", True, False)

                Me.ToolBack.Enabled = False
                Me.ToolFind.Enabled = True
                Me.txtBarCode.Enabled = False
                Me.rbtnProduct.Enabled = False
                Me.rbtnAssembly.Enabled = False
                Me.rbtnAffiliated.Enabled = False
                Me.rbtnProduct.Checked = False
                Me.rbtnAffiliated.Checked = False
                Me.rbtnAssembly.Checked = False
                Me.txtBarCode.Text = ""
                Me.txtAffiliatedQty.Text = ""
                Me.txtMOId.Text = ""
            Case 1
                Me.ToolAddNew.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolDelTask.Enabled = False
                Me.ToolPrt.Enabled = False
                Me.ToolFind.Enabled = False
                Me.rbtnProduct.Enabled = True
                Me.rbtnAffiliated.Enabled = True
                Me.rbtnAssembly.Enabled = True
        End Select
    End Sub

    Private Sub txtMOId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOId.KeyDown
        Dim dtTemp As DataTable
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.lblMessage.Text = ""

                dtTemp = DbOperateUtils.GetDataTable("SELECT MOID FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "'")
                If dtTemp Is Nothing Or dtTemp.Rows.Count = 0 Then
                    Me.lblMessage.Text = "输入工单不存在！"
                    Me.txtMOId.Text = ""
                    Me.txtMOId.Focus()
                Else
                    If (Me.rbtnAffiliated.Checked) Then
                        dtTemp = DbOperateUtils.GetDataTable("SELECT Packitem,Packid+'-'+Description AS Description FROM m_Mainmo_t INNER JOIN m_PartPack_t ON m_PartPack_t.PartId=m_Mainmo_t.PartId WHERE m_Mainmo_t.MOID='" & Me.txtMOId.Text.Trim & "' AND m_PartPack_t.PackId='A' AND UseY='Y'")
                        Me.cboAffiliated.DataSource = dtTemp
                        Me.cboAffiliated.DisplayMember = "Description"
                        Me.cboAffiliated.ValueMember = "Packitem"
                    Else
                        Me.cboAffiliated.DataSource = Nothing
                        Me.cboAffiliated.Items.Clear()
                    End If
                End If
            End If
            dtTemp = Nothing
        Catch ex As Exception
            dtTemp = Nothing
            Me.lblMessage.Text = "系统异常,检查工单信息失败！"
        End Try
    End Sub

    Private Sub txtBarCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarCode.KeyDown, txtAffiliatedQty.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Dim reprintType As String = String.Empty
                Me.lblMessage.Text = ""
                'String.IsNullOrEmpty(Me.txtBarCode.Text.Trim) Or 
                If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim)) Then
                    Me.lblMessage.Text = "请扫描工单!"
                    Exit Sub
                End If

                Dim strSQL As String

                If (Me.rbtnAffiliated.Checked) Then
                    reprintType = "1"
                    If Not IsNumeric(Me.txtAffiliatedQty.Text.Trim) Then
                        Me.lblMessage.Text = "输入数量必须为数字!"
                        Exit Sub
                    End If

                    If Int(Me.txtAffiliatedQty.Text.Trim) <= 0 Then
                        Me.lblMessage.Text = "输入数量必须大于0!"
                        Exit Sub
                    End If
                Else
                    reprintType = "0"
                End If

                strSQL = "declare @msg NVARCHAR(64),@rtValue NVARCHAR(1) " & _
                        " execute GetBarCodeReprint '" & Me.txtMOId.Text.Trim & "','" & reprintType & "','" & Me.txtBarCode.Text.Trim & "','" &
                        cboAffiliated.SelectedValue & "','" & Me.txtAffiliatedQty.Text & "','" & SysMessageClass.UseId & "', @msg output,@rtValue output " &
                        " select @msg AS msg,@rtValue AS rtValue "
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                For rowIndex As Integer = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows(0)("rtValue").ToString()
                        Case "0"
                            Me.lblMessage.Text = dt.Rows(0)("msg").ToString()
                        Case "1"
                            Me.lblMessage.Text = "申请成功!"
                    End Select
                Next

                Me.txtBarCode.Text = ""
                Me.txtBarCode.Focus()
            End If
        Catch ex As Exception
            Me.lblMessage.Text = "扫描失败，系统异常！"
        End Try
    End Sub

    Private Sub FrmReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rbtnProduct.Enabled = False
        Me.rbtnAffiliated.Enabled = False
        Me.txtBarCode.Enabled = False
        Me.cboAffiliated.Enabled = False
        Me.txtAffiliatedQty.Enabled = False
        btApp = New BarTender.ApplicationClass
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        SetStatus(0)
        Dim DateT As New DateTime
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select getdate() as nowtime")
        If dt.Rows.Count > 0 Then
            DateT = CDate(dt.Rows(0)!nowtime.ToString)
        End If
        Me.LblPrintDate.Text = DateT.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFind.Click
        Try
            '0 申请 1.取消/打印完成 2审核完成 
            Dim strWhere As String = ""
            If String.IsNullOrEmpty(txtMOId.Text) = False Then
                strWhere = String.Format("  and a.moid = '{0}' ", txtMOId.Text.Trim)
            End If

            If String.IsNullOrEmpty(txtBarCode.Text) = False Then
                strWhere = strWhere + String.Format("  and a.Sbarcode = '{0}' ", txtBarCode.Text.Trim)
            End If

            Dim strSQL As String
            strSQL = " SELECT a.MOID, a.PartId, SUM(CASE Packid  WHEN 'N' THEN ReprintQty WHEN 'C' THEN ReprintQty WHEN 'P' THEN ReprintQty ELSE 0 END) AS PackingReprintCount," & _
                     " SUM(CASE Packid WHEN 'S' THEN ReprintQty ELSE 0 END) AS ProductReprintCount," & _
                     " SUM(CASE Packid WHEN 'A' THEN ReprintQty ELSE 0 END) AS AffiliatedReprintCount, a.LineId,A.STATE  " & _
                    " FROM m_BarCodeReprint_t  a left join m_Mainmo_t b on a.MOid = b.moid " & _
                    " WHERE STATE IN('0','2')" & _
                    " and b.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and b.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "'" &
                    strWhere &
                    " GROUP BY a.MOID,a.PartId,a.LineId,A.STATE  ORDER BY state desc "


            LoadData(strSQL, Me.dgvLot)
        Catch ex As Exception
            Me.lblMessage.Text = "查询失败，系统异常！"
        End Try
    End Sub

    '作废
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelTask.Click
        Me.lblMessage.Text = ""
        Dim strSQL As String
        Dim strMOID As String
        Try
            If dgvBarcode.RowCount > 0 Then
                If Me.dgvBarcode.Rows.Count = 0 OrElse Me.dgvBarcode.CurrentRow Is Nothing Then
                    Me.lblMessage.Text = "请选择要作废的不良申请！"
                    Exit Sub
                End If

                strMOID = Me.dgvLot.Item("Moid", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim

                If (String.IsNullOrEmpty(strMOID)) Then
                    Me.lblMessage.Text = "选择不良申请工单不能为空！"
                    Exit Sub
                End If

                strSQL = "UPDATE m_BarCodeReprint_t SET STATE='1', InvalidUserName='" & SysMessageClass.UseId & "' WHERE MOID='" & strMOID & "'"
                DbOperateUtils.ExecSQL(strSQL)

                ToolFind_Click(Nothing, Nothing)
            Else
                Me.lblMessage.Text = "请选择要作废的不良申请！"
            End If
        Catch ex As Exception
            Me.lblMessage.Text = "打印作废异常！"
        End Try
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Try
            dgvName.Rows.Clear()
            Dim DReader As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            cmbTmp = dgvBarcode.Columns("PrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            'For i As Int16 = 0 To Me.dgvBarcode.RowCount - 1
            For rowIndex As Integer = 0 To DReader.Rows.Count - 1
                If dgvName Is Me.dgvLot Then
                    dgvName.Rows.Add(DReader.Rows(rowIndex).Item("MOID").ToString, DReader.Rows(rowIndex).Item("PartId").ToString,
                                     DReader.Rows(rowIndex).Item("PackingReprintCount").ToString, DReader.Rows(rowIndex).Item("ProductReprintCount").ToString,
                                     DReader.Rows(rowIndex).Item("AffiliatedReprintCount").ToString, DReader.Rows(rowIndex).Item("LineId").ToString,
                                     DReader.Rows(rowIndex).Item("STATE").ToString)
                ElseIf dgvName Is Me.dgvBarcode Then
                    Dim PrintName As String
                    If (SqlClassM.CheckPrintersList(DReader.Rows(rowIndex).Item("PrinterName").ToString)) Then
                        PrintName = DReader.Rows(rowIndex).Item("PrinterName").ToString
                    Else
                        PrintName = ""
                    End If
                    dgvName.Rows.Add(True, DReader.Rows(rowIndex).Item("PartId").ToString, DReader.Rows(rowIndex).Item("SBarCode").ToString,
                                     DReader.Rows(rowIndex).Item("LabelType").ToString, PrintName, DReader.Rows(rowIndex).Item("KLabelid").ToString,
                                     DReader.Rows(rowIndex).Item("Description").ToString, DReader.Rows(rowIndex).Item("DisorderType").ToString,
                                     DReader.Rows(rowIndex).Item("ReprintQty").ToString, DReader.Rows(rowIndex).Item("Username").ToString,
                                     DReader.Rows(rowIndex).Item("createdate").ToString, DReader.Rows(rowIndex).Item("TemplatePath").ToString)
                End If
            Next

        Catch ex As Exception
            Me.lblMessage.Text = "查询失败，系统异常！"
        End Try

    End Sub

    Private Sub dgvLot_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLot.CellEnter
        Try

            If Me.dgvLot.Rows.Count = 0 OrElse Me.dgvLot.CurrentRow Is Nothing Then
                Exit Sub
            End If

            Dim state As String = Me.dgvLot.Item("STATE", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim

            Dim strSQL As String
            strSQL = "SELECT distinct m_BarCodeReprint_t.MOID, m_BarCodeReprint_t.partid, m_BarCodeReprint_t.SBarCode, " & _
                    " m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType ,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType,  " & _
                    " m_BarCodeReprint_t.Packid, m_PartPack_t.PrinterName,  " & _
                    " ReprintQty, UserName, createdate, m_SnPFormat_t.KLabelid, m_PartPack_t.Description, m_SnMFormat_t.TemplatePath " & _
                    " FROM m_BarCodeReprint_t  " & _
                    "  LEFT JOIN m_PartContrast_t ON m_PartContrast_t.TAvcPart=m_BarCodeReprint_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart  " & _
                    "  LEFT JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND   " & _
                    " m_PartPack_t.Packid = m_BarCodeReprint_t.Packid And m_PartPack_t.Packitem = m_BarCodeReprint_t.Packitem " & _
                    "  LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID  " & _
                    "  LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y'  " & _
                    "  LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y'  " & _
                    "  left join m_SnMFormat_t on m_PartPack_t.PFormatID=m_SnMFormat_t.PFormatID " & _
                    "  WHERE MOID='" & Me.dgvLot.Item("Moid", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim & "' "
            'If VbCommClass.VbCommClass.Factory = "LXXT" And VbCommClass.VbCommClass.profitcenter = "XT-D" Then
            '    strSQL = strSQL + " AND state='2'"
            'Else
            '    strSQL = strSQL + " AND (state='0' or state='2')"
            'End If

            strSQL = strSQL + String.Format(" AND state='{0}'", state)

            strMOId = Me.dgvLot.Item("Moid", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim

            LoadData(strSQL, Me.dgvBarcode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrt.Click
        Try
            If dgvLot.SelectedRows.Count > 0 Then
                If VbCommClass.VbCommClass.Factory = "LXXT" And VbCommClass.VbCommClass.profitcenter = "XT-D" Then
                    If dgvLot.CurrentRow.Cells("STATE").Value.ToString <> "2" Then
                        Me.lblMessage.Text = "请先审核！"
                        Exit Sub
                    End If
                End If
            End If
            If dgvBarcode.RowCount > 0 Then
                If (CheckPrint(Me.dgvBarcode)) Then
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvBarcode.RowCount - 1
                        chkTemp = dgvBarcode.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            Call Sleep(1000)
                            PrintBarCode(dgvBarcode.Rows(i), i + 1)
                        End If
                    Next
                Else
                    Exit Sub
                End If
            Else
                Me.lblMessage.Text = "没有任何可供打印行！"
            End If

            ToolFind_Click(Nothing, Nothing)
        Catch ex As Exception
            Me.lblMessage.Text = "打印失败，系统异常！" & ex.Message
        End Try
    End Sub

    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        For I As Int16 = 0 To dgvBarcode.RowCount - 1
            chkTemp = dgvBarcode.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue
            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '判断是否配置料件参数
                If (String.IsNullOrEmpty(dgvBarcode.Rows(I).Cells("lableType").Value.ToString.Trim)) Then
                    Me.lblMessage.Text = "请配置第" + (I + 1).ToString + "行料件打印参数，并确保其他料件参数已经配置OK!"
                    Exit For
                End If
                '判断是否设置模板
                If (String.IsNullOrEmpty(dgvBarcode.Rows(I).Cells("LabelTemplates").Value.ToString.Trim)) Then
                    Me.lblMessage.Text = "请配置第" + (I + 1).ToString + "行料件打印模板，并确保其他料件打印模板已经配置OK!"
                    Exit For
                End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvBarcode.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim)) Then
                    Me.lblMessage.Text = "请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!"
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvBarcode.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim
                    If (ps.IsValid = False) Then
                        Me.lblMessage.Text = "第" + (I + 1).ToString + "行打印机不可用，请检查!"
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            Me.lblMessage.Text = "请选择打印项目!"
        End If
        Return iSelect
    End Function

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)
        Dim SqlStr As String
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim GetPrint As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtPrint As DataTable
        Dim strValue As String
        Try
            PrintTxt.Remove(0, PrintTxt.Length)
            TxtFileStr.Remove(0, TxtFileStr.Length)

            dtPrint = DbOperateUtils.GetDataTable("SELECT barcodeSNID, label10, label11, label12, label13, label14, label15, label16, label17, label18, labe19, label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34, label35, label36, label37, label38 FROM m_BarRecordValue_t WHERE barcodeSNID='" & PrintData.Cells("sBarCode").Value.ToString.Replace("'", "''") & "'")

            If dtPrint.Rows.Count = 0 Then
                Me.lblMessage.Text = "打印失败，获取打印数据失败！"
                Exit Sub
            End If
            'Dim str As String = Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString(), 1)

            For j As Int16 = 0 To dtPrint.Columns.Count - 1

                If (IsDate(dtPrint.Rows(0).Item(j).ToString)) Then
                    If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString(), 1) <> "A") Then
                        strValue = CDate(Me.LblPrintDate.Text.ToString).ToString("yy/MM/dd").ToString()
                    Else
                        strValue = Trim(dtPrint.Rows(0).Item(j).ToString)
                    End If
                Else
                    strValue = Trim(dtPrint.Rows(0).Item(j).ToString)
                End If

                If j = 0 Then
                    TxtFileStr.Append("""" & strValue & """")
                Else
                    TxtFileStr.Append(",""" & strValue & """")
                End If
            Next

            For I As Int16 = 0 To CInt(PrintData.Cells("ReprintQty").Value.ToString) - 1
                PrintTxt.Append(vbNewLine & TxtFileStr.ToString)
            Next

            PrintTxt.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", PrintTxt.ToString)
            If VbCommClass.VbCommClass.Factory = "LXXT" And VbCommClass.VbCommClass.profitcenter = "XT-D" Then
                SqlStr = "UPDATE m_BarCodeReprint_t SET STATE='1',PrintDate=GetDate(),PrintUserName='" & SysMessageClass.UseId & "'  WHERE SBarCode='" & PrintData.Cells("sBarCode").Value.ToString.Replace("'", "''") & "' AND MOID='" & strMOId & "' AND STATE ='2' "
            Else
                SqlStr = "UPDATE m_BarCodeReprint_t SET STATE='1',PrintDate=GetDate(),PrintUserName='" & SysMessageClass.UseId & "'  WHERE SBarCode='" & PrintData.Cells("sBarCode").Value.ToString.Replace("'", "''") & "' AND MOID='" & strMOId & "' AND STATE ='0' "
            End If

            If (Not String.IsNullOrEmpty(SqlStr)) Then
                If (Not String.IsNullOrEmpty(PrintTxt.ToString)) Then
                    FileToBarCodePrint(PrintData.Cells("TemplatePath").Value.ToString.Trim, PrintData.Cells("PrinterName").FormattedValue.ToString.Trim)
                    DbOperateUtils.ExecSQL(SqlStr)
                End If
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "打印失败，系统异常！" & ex.Message
        End Try
    End Sub

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub FrmReprint_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        SetStatus(0)
    End Sub

    Private Sub rbtnSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAffiliated.CheckedChanged, rbtnProduct.CheckedChanged, rbtnAssembly.CheckedChanged
        If (rbtnAffiliated.Checked) Then
            If (String.IsNullOrEmpty(txtMOId.Text.Trim)) Then
                rbtnAffiliated.Checked = False
                Exit Sub
            Else
                '检查工单是否有效
                Dim dtTemp As DataTable
                Try
                    dtTemp = DbOperateUtils.GetDataTable("SELECT MOID FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "'")
                    If dtTemp Is Nothing Or dtTemp.Rows.Count = 0 Then
                        Me.lblMessage.Text = "打印失败，获取打印数据失败！"
                        Exit Sub
                    Else
                        dtTemp = DbOperateUtils.GetDataTable("SELECT Packitem,Packid+'-'+Description AS Description FROM m_Mainmo_t INNER JOIN m_PartPack_t ON m_PartPack_t.PartId=m_Mainmo_t.PartId WHERE m_Mainmo_t.MOID='" & Me.txtMOId.Text.Trim & "' AND m_PartPack_t.PackId='A' AND UseY='Y'")
                        Me.cboAffiliated.DataSource = dtTemp
                        Me.cboAffiliated.DisplayMember = "Description"
                        Me.cboAffiliated.ValueMember = "Packitem"
                    End If
                Catch ex As Exception
                End Try
            End If

            Me.cboAffiliated.Enabled = True
            Me.txtAffiliatedQty.Enabled = True
            Me.txtBarCode.Enabled = False
            Me.txtAffiliatedQty.Text = ""
        Else
            'If (String.IsNullOrEmpty(txtMOId.Text.Trim)) Then
            '    Exit Sub
            'End If
            Me.cboAffiliated.Enabled = False
            Me.txtAffiliatedQty.Enabled = False
            Me.txtBarCode.Enabled = True
            Me.txtAffiliatedQty.Text = ""
            Me.cboAffiliated.SelectedIndex = -1
        End If
    End Sub

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvBarcode.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvBarcode.RowCount - 1
                    dgvBarcode.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnEdit.Click
        Try
            Dim FrmEditTime As New FrmEditTime
            FrmEditTime.ShowDialog()
            If SqlClassD.UpdateTime.ToString <> "" Then
                Me.LblPrintDate.Text = String.Format(CDate(SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                'PrtArray.NowDate = CDate(Me.LblPrintDate.Text).ToString("yyyy-MM-dd").ToString
                'PrtArray.NowMonth = CDate(Me.LblPrintDate.Text).ToString("MM").ToString
                'SetArrayLbl(PrtArray.ToArray)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarPrt", "BnEdit_Click", "sys")
        End Try
    End Sub

    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        Me.lblMessage.Text = ""
        Dim strSQL As String
        Dim strMOID As String
        Try
            If dgvLot.RowCount > 0 Then
                If Me.dgvLot.Rows.Count = 0 OrElse Me.dgvLot.CurrentRow Is Nothing Then
                    Me.lblMessage.Text = "请选择要审核的不良申请！"
                    Exit Sub
                End If

                strMOID = Me.dgvLot.Item("Moid", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim

                If (String.IsNullOrEmpty(strMOID)) Then
                    Me.lblMessage.Text = "选择不良申请工单不能为空！"
                    Exit Sub
                End If

                strSQL = "UPDATE m_BarCodeReprint_t SET STATE='2', InvalidUserName='" & SysMessageClass.UseId & "' WHERE MOID='" & strMOID & "'"
                DbOperateUtils.ExecSQL(strSQL)

                ToolFind_Click(Nothing, Nothing)
            Else
                Me.lblMessage.Text = "请选择要审核的不良申请！"
            End If
        Catch ex As Exception
            Me.lblMessage.Text = "审核异常！"
        End Try
    End Sub
End Class