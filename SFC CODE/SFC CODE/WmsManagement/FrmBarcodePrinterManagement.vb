'--物料条码打印管理
'--Create by :　马锋
'--Create date :　2015/08/20
'--Ver : V01
'--Update date :  
'--

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
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD

#End Region


Public Class FrmBarcodePrinterManagement

#Region "变量声明"

    Dim reelPrint As New ReelPrint
    Dim Sqlstr As New StringBuilder
    Dim opFlag As Int16 = 0
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = Application.StartupPath & "\BartenderFile\ReelBarcode.btw"
    Dim BarFile As New StringBuilder()

#End Region

#Region "加载事件"

    Private Sub FrmBarcodePrinterManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvBarcodePrinter.AutoGenerateColumns = False
            Me.dgvBarcodePrinterItem.AutoGenerateColumns = False
            Me.dtpDate.Value = Now
            btApp = New BarTender.ApplicationClass
            GetTransaction()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub FrmBarcodePrinterManagement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnPrinter_Click(sender As Object, e As EventArgs) Handles btnPrinter.Click
        Try
            GetMesData.SetMessage(Me.lblMessage, "", False)
            dgvBarcodePrinter.Enabled = False
            dgvBarcodePrinterItem.Enabled = False
            If dgvBarcodePrinter.RowCount > 0 Then
                If (CheckPrint(Me.dgvBarcodePrinterItem)) Then
                    Dim chkTemp As DataGridViewCheckBoxXCell
                    For i As Int16 = 0 To Me.dgvBarcodePrinterItem.RowCount - 1
                        chkTemp = dgvBarcodePrinterItem.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            PrintBarCode(dgvBarcodePrinterItem.Rows(i), i + 1)
                        End If
                    Next
                Else
                    dgvBarcodePrinter.Enabled = True
                    dgvBarcodePrinterItem.Enabled = True
                    Exit Sub
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "没有任何可供打印行!", False)
            End If
            dgvBarcodePrinter.Enabled = True
            dgvBarcodePrinterItem.Enabled = True
            GetTransaction()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try

            Dim barcodePrinterMaster As New FrmBarcodePrinterMaster()
            barcodePrinterMaster.ShowDialog()
            GetTransaction()

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            GetTransaction()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvBarcodePrinter_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBarcodePrinter.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvBarcodePrinter.Rows.Count = 0 OrElse Me.dgvBarcodePrinter.CurrentRow Is Nothing Then
            Me.dgvBarcodePrinterItem.Rows.Clear()
            Exit Sub
        End If

        Try
            GetTransactionItem(Me.dgvBarcodePrinter.Rows(Me.dgvBarcodePrinter.CurrentRow.Index).Cells("TransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvBarcodePrinterItem.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvBarcodePrinterItem.RowCount - 1
                    dgvBarcodePrinterItem.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, ("选择执行异常，请联系开发人员!"), False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub GetTransaction()
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.dtpDate.Text.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), m_BarcodePrinter_t.CreateTime, 23) = '" & Me.dtpDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, BarcodePrinterId, TransactionId, Remark, StatusFlag, CreateTime, CreateUser " & _
                     " FROM m_BarcodePrinter_t WHERE FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  CreateTime DESC"

            Me.dgvBarcodePrinter.Rows.Clear()
            Me.dgvBarcodePrinterItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            Do While DReader.Read()
                Me.dgvBarcodePrinter.Rows.Add(DReader.Item("BarcodePrinterId").ToString, DReader.Item("RowNum").ToString, DReader.Item("TransactionId").ToString, DReader.Item("Remark").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

    Private Sub GetTransactionItem(ByVal TransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, TransactionId, MaterialNO, Description, Specification, Uint, Quantity, PrinterQuantity, Remark, DeleteFlag, CreateUser, CreateTime " & _
                     " FROM  m_BarcodePrinterItem_t " & _
                     " WHERE TransactionId = '" & TransactionId & "'"

            Me.dgvBarcodePrinterItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            Dim PrintName As String
            Dim cmbTmp As DataGridViewComboBoxColumn

            cmbTmp = dgvBarcodePrinterItem.Columns("PrinterName")
            GetMesData.GetPrintersList(cmbTmp)

            Do While DReader.Read()
                Me.dgvBarcodePrinterItem.Rows.Add(DReader.Item("TransactionId").ToString, DReader.Item("RowNum").ToString, True, DReader.Item("MaterialNO").ToString, DReader.Item("Specification").ToString, DReader.Item("Description").ToString, DReader.Item("Uint").ToString, DReader.Item("Quantity").ToString, "", DReader.Item("PrinterQuantity").ToString, "0", "0", "", "", Now.ToString("yyyy/MM/dd"), "", "", DReader.Item("Remark").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If Not (DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxXCell

        For I As Int16 = 0 To dgvBarcodePrinterItem.RowCount - 1
            chkTemp = dgvBarcodePrinterItem.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '判断打印数量
                If Not IsNumeric(dgvBarcodePrinterItem.Rows(I).Cells("PrintNum").Value) Then
                    GetMesData.SetMessage(Me.lblMessage, ("第" + (I + 1).ToString + "行输入打印数量有误！"), False)
                    Return False
                    Exit For
                End If
                If (Int(dgvBarcodePrinterItem.Rows(I).Cells("PrintNum").Value) > 1000) Then
                    GetMesData.SetMessage(Me.lblMessage, ("第" + (I + 1).ToString + "行产品条码一次打印數量限制在1-1000以內！"), False)
                    Return False
                    Exit For
                End If

                '判断包装容量数量
                If Not IsNumeric(dgvBarcodePrinterItem.Rows(I).Cells("PackingCapacity").Value) Then
                    GetMesData.SetMessage(Me.lblMessage, ("输入第" + (I + 1).ToString + "行包装容量数量有误！"), False)
                    Return False
                    Exit For
                End If

                If (CLng(dgvBarcodePrinterItem.Rows(I).Cells("PackingCapacity").Value) * CLng(dgvBarcodePrinterItem.Rows(I).Cells("PrintNum").Value) > CLng(dgvBarcodePrinterItem.Rows(I).Cells("Quantity").Value) - CLng(dgvBarcodePrinterItem.Rows(I).Cells("PrinterQuantity").Value)) Then
                    GetMesData.SetMessage(Me.lblMessage, ("输入第" + (I + 1).ToString + "打印数量超过需求数量！"), False)
                    Return False
                    Exit For
                End If

                If (Len(dgvBarcodePrinterItem.Rows(I).Cells("VERSION").Value) <> 2) Then
                    GetMesData.SetMessage(Me.lblMessage, ("输入第" + (I + 1).ToString + "版本有误，请输入两位版本号！"), False)
                    Return False
                    Exit For
                End If

                If (Len(dgvBarcodePrinterItem.Rows(I).Cells("VendorCode").Value) <> 6) Then
                    GetMesData.SetMessage(Me.lblMessage, ("输入第" + (I + 1).ToString + "供应商代码有误，请输入六位供应商代码！"), False)
                    Return False
                    Exit For
                End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvBarcodePrinterItem.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim)) Then
                    GetMesData.SetMessage(Me.lblMessage, ("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!"), False)
                    Return False
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvBarcodePrinterItem.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim
                    If (ps.IsValid = False) Then
                        GetMesData.SetMessage(Me.lblMessage, ("第" + (I + 1).ToString + "行打印机不可用，请检查!"), False)
                        Return False
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            GetMesData.SetMessage(Me.lblMessage, ("请选择打印项目!"), False)
        End If
        Return iSelect
    End Function

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)

        If (Not PrintData Is Nothing) Then
            If Not InitializePrintParameter(PrintData) Then
                Exit Sub
            End If

            BuildSBarCode(PrintData)
        Else
            GetMesData.SetMessage(Me.lblMessage, ("获取行" + rowNum.ToString + "打印数据失败!"), False)
        End If
    End Sub

    Private Function InitializePrintParameter(ByVal PrintData As DataGridViewRow) As Boolean
        Try
            reelPrint.CustomerName = "LUXSHARE-ICT"
            reelPrint.MaterialNO = PrintData.Cells("MaterialNO").Value.ToString
            reelPrint.SupplierPN = PrintData.Cells("MaterialNO").Value.ToString
            reelPrint.DateCode = PrintData.Cells("DateCode").Value.ToString
            reelPrint.Rev = PrintData.Cells("VERSION").Value.ToString
            reelPrint.VendorCode = PrintData.Cells("VendorCode").Value.ToString
            reelPrint.PackingCapacity = PrintData.Cells("PackingCapacity").Value.ToString
            reelPrint.MantissaPackingQty = "0"

            reelPrint.Unit = "Unit(" + PrintData.Cells("Uint").Value.ToString + ")"
            reelPrint.GW = IIf(IsDBNull(PrintData.Cells("GWeight").Value), "", PrintData.Cells("GWeight").Value)
            reelPrint.PONO = PrintData.Cells("ItemTransactionId").Value.ToString
            reelPrint.ItemNO = PrintData.Cells("ItemRowNum").Value.ToString
            reelPrint.LotNO = IIf(IsDBNull(PrintData.Cells("LotNO").Value), "", PrintData.Cells("LotNO").Value)
            reelPrint.PrintCount = CInt(PrintData.Cells("PrintNum").Value)
            reelPrint.PrintName = PrintData.Cells("PrinterName").FormattedValue.ToString
            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, ("获取物料条码初始信息失败，请联系开发人员!"), False)
            Return False
        End Try
    End Function

#End Region

#Region "打印"

    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Sqlstr.Remove(0, Sqlstr.Length)
            Dim strNumber As String
            Dim strReelBarcode As String
            Dim TxtFileStr As New StringBuilder

            '检查样式是否锁定
            If CheckStyle() = False Then
                Exit Sub
            End If

            '生成数据库脚本
            For I As Int16 = 0 To reelPrint.PrintCount - 1

                strNumber = (reelPrint.CurrNumber + (I + 1)).ToString.PadLeft(3, "0")

                '写入物料条码
                If (CDbl(reelPrint.MantissaPackingQty) > 0 And I = reelPrint.PrintCount - 1) Then
                    '尾数箱处理
                    strReelBarcode = reelPrint.MantissaStyleID + (reelPrint.MantissaCurrNumber + 1).ToString.PadLeft(3, "0")

                    Sqlstr.Append("INSERT INTO W_PRINTREEL_T(REEL_BARCODE, DATECODE, PONO, ITEM_NO, MATERIAL_ID, QTY, PRINT_USER, PRINT_TIME, STATUS" _
                    & " )VALUES( '" & strReelBarcode & "','" & reelPrint.DateCode & "','" & reelPrint.PONO & "','" & reelPrint.ItemNO & "','" & reelPrint.MaterialNO & "','" & reelPrint.MantissaPackingQty & "','" & SysMessageClass.UseId.ToUpper & "',Getdate(),'1'" _
                    & ") ")

                    '生成打印Text
                    If I = 0 Then
                        TxtFileStr.Append("""" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.MantissaPackingQty & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                    Else
                        TxtFileStr.Append(vbNewLine & """" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.MantissaPackingQty & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                    End If
                Else
                    strReelBarcode = reelPrint.StyleID + strNumber
                    Sqlstr.Append("INSERT INTO W_PRINTREEL_T(REEL_BARCODE, DATECODE, PONO, ITEM_NO, MATERIAL_ID, QTY, PRINT_USER, PRINT_TIME, STATUS, UOM_NAME, LOT_NO, WEIGHT, REV, PrinterType " _
                        & " )VALUES( '" & strReelBarcode & "','" & reelPrint.DateCode & "','" & reelPrint.PONO & "','" & reelPrint.ItemNO & "','" & reelPrint.MaterialNO & "','" & PrintData.Cells("PackingCapacity").Value.ToString.Trim & "','" & SysMessageClass.UseId.ToUpper & "',Getdate(),'1', '" & reelPrint.Unit & "', '" & reelPrint.LotNO & "', '" & reelPrint.GW & "', '" & reelPrint.Rev & "', '1'" _
                        & ") ")

                    '生成打印Text
                    If I = 0 Then
                        TxtFileStr.Append("""" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.PackingCapacity & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                    Else
                        TxtFileStr.Append(vbNewLine & """" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.PackingCapacity & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                    End If
                End If

                '写入W_REELS
                'INSERT INTO W_REELS_T(FACTORY_ID, FACTORY_NAME, PROFITCENTER, PONO, ITEM_NO, RECEIVE_ITEM_NO, REEL_BARCODE, 
                '                MATERIAL_ID, MATERIAL_NO, SPECIFICATION, DESCRIPTION, UNIT_MEASURE_ID, UOM_NAME, VENDOR_ID, 
                '                VENDOR_NAME, RECEIVENO, MATERIAL_BACHT, QUANTITY, REMAINING_QUANTITY, WAREHOUSE, LOCATION, 
                '                LOT_NO, DATECODE, PARENT_REEL_ID, CREATE_USERID, CREATE_TIME, STATUS, CREATE_DATECODE, 
                '                TYPEFLAG)VALUES()
                '写入BarRecordValue
                'Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                '              "([Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                '             ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                '             ",[label23],[label24]) " & _
                '              "VALUES('" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
            Next

            '更新打印数量
            Sqlstr.Append("UPDATE m_BarcodePrinterItem_t SET PrinterQuantity = PrinterQuantity + '" & CDbl(reelPrint.PackingCapacity) * (CDbl(reelPrint.PrintCount) - IIf(reelPrint.MantissaPackingQty > 0, 1, 0)) + reelPrint.MantissaPackingQty & "' WHERE TransactionId='" & reelPrint.PONO & "' AND MaterialNO='" & reelPrint.MaterialNO & "'")
            Sqlstr.Append("UPDATE W_PRINTSTYLE_T SET QTY = QTY + '" & reelPrint.PrintCount - IIf(reelPrint.MantissaPackingQty > 0, 1, 0) & "' WHERE STYLEFORMAT='" & reelPrint.StyleID & "'")
            If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
                Sqlstr.Append("UPDATE W_PRINTSTYLE_T SET QTY = QTY + 1 WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID & "'")
            End If

            '写入打印Text
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            '打印
            If (Not String.IsNullOrEmpty(Sqlstr.ToString)) Then
                Conn.ExecSql(Sqlstr.ToString)
                FileToBarCodePrint(pFilePath, reelPrint.PrintName)
            End If
            Conn = Nothing
            '解锁样式
            reelPrint.OpenPrintLock(reelPrint.StyleID)
            If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
                reelPrint.OpenPrintLock(reelPrint.MantissaStyleID)
            End If
        Catch ex As Exception
            Conn = Nothing
            reelPrint.OpenPrintLock(reelPrint.StyleID)
            If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
                reelPrint.OpenPrintLock(reelPrint.MantissaStyleID)
            End If
            GetMesData.SetMessage(Me.lblMessage, ("打印失败，请联系开发人员!"), False)
        End Try
    End Sub


    '檢查樣式
    Private Function CheckStyle() As Boolean
        Dim Sqlstr As String
        'Dim RecTable As New DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            reelPrint.StyleID = MakeStyle(reelPrint.PackingCapacity) '產生樣式
            Sqlstr = "SELECT STYLEFORMAT,QTY,STATUS from W_PRINTSTYLE_T WHERE STYLEFORMAT='" & reelPrint.StyleID.ToString & "'"
            Dim RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

            If RecTable.Read Then
                If RecTable.GetString(RecTable.GetOrdinal("STATUS")) = "N" Then
                    reelPrint.CurrNumber = Int(RecTable("QTY").ToString)
                    RecTable.Close()
                    Sqlstr = "UPDATE W_PRINTSTYLE_T SET STATUS='Y',HISTORY_USER='" & SysMessageClass.UseId.ToLower & "',HISTORY_TIME=getdate() WHERE STYLEFORMAT='" & reelPrint.StyleID & "'"
                    Conn.ExecSql(Sqlstr)
                Else
                    MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                End If
            Else
                reelPrint.CurrNumber = 0
                RecTable.Close()
                Sqlstr = "INSERT INTO W_PRINTSTYLE_T(MATERIAL_ID, STYLEFORMAT, SYEAR, SMONTH, SDAYS, QTY, STATUS, HISTORY_USER) VALUES('" & reelPrint.MaterialNO & "','" & reelPrint.StyleID & "','" & reelPrint.Years & "','" & reelPrint.Month & "','" & reelPrint.Days & "',0,'Y','" & SysMessageClass.UseId.ToLower & "')"
                Conn.ExecSql(Sqlstr)
            End If

            If (CDbl(reelPrint.MantissaPackingQty) > 0) Then
                reelPrint.MantissaStyleID = MakeStyle(reelPrint.MantissaPackingQty) '產生樣式
                Sqlstr = "SELECT STYLEFORMAT,QTY,STATUS from W_PRINTSTYLE_T WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID.ToString & "'"
                Dim MantissaRecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

                If MantissaRecTable.Read Then
                    If MantissaRecTable.GetString(MantissaRecTable.GetOrdinal("STATUS")) = "N" Then
                        reelPrint.MantissaCurrNumber = Int(MantissaRecTable("QTY").ToString)
                        MantissaRecTable.Close()
                        Sqlstr = "UPDATE W_PRINTSTYLE_T set STATUS='Y',HISTORY_USER='" & SysMessageClass.UseId.ToLower & "',HISTORY_TIME=getdate() WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID & "'"
                        Conn.ExecSql(Sqlstr)
                    Else
                        MsgBox("此当前料号正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    reelPrint.MantissaCurrNumber = 0
                    MantissaRecTable.Close()
                    Sqlstr = "INSERT INTO W_PRINTSTYLE_T(MATERIAL_ID, STYLEFORMAT, SYEAR, SMONTH, SDAYS, QTY, STATUS, HISTORY_USER) VALUES('" & reelPrint.MaterialNO & "','" & reelPrint.MantissaStyleID & "','" & reelPrint.Years & "','" & reelPrint.Month & "'," & reelPrint.Days & ",0,'Y','" & SysMessageClass.UseId.ToLower & "')"
                    Conn.ExecSql(Sqlstr)
                End If
            End If

            Conn = Nothing
            Return True
        Catch ex As Exception
            Conn = Nothing
            reelPrint.OpenPrintLock(reelPrint.StyleID)
            If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
                reelPrint.OpenPrintLock(reelPrint.MantissaStyleID)
            End If
            Throw ex
            Return False
        End Try
    End Function

    '產生樣式
    Private Function MakeStyle(ByVal Qty As String) As String
        Dim BarCodeStyle As String
        Try
            '2014-11-27     条码格式调整，数量码为7为       Qty.ToString.PadLeft(7, "0")   
            BarCodeStyle = reelPrint.MaterialNO + reelPrint.VendorCode + reelPrint.Rev + GetBarCodeFormatDate(reelPrint.DateCode) + Qty.ToString.PadLeft(7, "0")
            Return BarCodeStyle
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    Private Function GetBarCodeFormatDate(ByVal CurrDate As DateTime) As String
        Try
            Dim sDateCode As String

            reelPrint.Years = CurrDate.ToString("yy")
            reelPrint.Month = GetFormatMonth(CurrDate.ToString("MM"))
            reelPrint.Days = GetFormatDays(CurrDate.ToString("dd"))

            sDateCode = reelPrint.Years + reelPrint.Month + reelPrint.Days
            Return sDateCode
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetFormatMonth(ByVal CurrMonth As String) As String
        Select Case (CurrMonth)
            Case "01"
                Return "1"
            Case "02"
                Return "2"
            Case "03"
                Return "3"
            Case "04"
                Return "4"
            Case "05"
                Return "5"
            Case "06"
                Return "6"
            Case "07"
                Return "7"
            Case "08"
                Return "8"
            Case "09"
                Return "9"
            Case "10"
                Return "A"
            Case "11"
                Return "B"
            Case "12"
                Return "C"
        End Select
    End Function

    Private Function GetFormatDays(ByVal CurrDays As String) As String
        Select Case (CurrDays)
            Case "01"
                Return "1"
            Case "02"
                Return "2"
            Case "03"
                Return "3"
            Case "04"
                Return "4"
            Case "05"
                Return "5"
            Case "06"
                Return "6"
            Case "07"
                Return "7"
            Case "08"
                Return "8"
            Case "09"
                Return "9"
            Case "10"
                Return "A"
            Case "11"
                Return "B"
            Case "12"
                Return "C"
            Case "13"
                Return "D"
            Case "14"
                Return "E"
            Case "15"
                Return "F"
            Case "16"
                Return "G"
            Case "17"
                Return "H"
            Case "18"
                Return "J"
            Case "19"
                Return "K"
            Case "20"
                Return "L"
            Case "21"
                Return "M"
            Case "22"
                Return "N"
            Case "23"
                Return "P"
            Case "24"
                Return "Q"
            Case "25"
                Return "R"
            Case "26"
                Return "S"
            Case "27"
                Return "T"
            Case "28"
                Return "U"
            Case "29"
                Return "V"
            Case "30"
                Return "W"
            Case "31"
                Return "X"
        End Select
    End Function

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)VbCommClass.VbCommClass.PrintDataModle & 
        btFormat = btApp.Formats.Open(pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

#End Region

End Class