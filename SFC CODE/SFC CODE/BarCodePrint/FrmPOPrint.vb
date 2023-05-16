
'--物料条码打印作业
'--Create by :　马锋
'--Create date :　2014/09/22
'--Update date :  
'--Ver : V01

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
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD

#End Region

Public Class FrmPOPrint

#Region "窗體變量"

    Dim reelPrint As New ReelPrint
    Dim Sqlstr As New StringBuilder
    Dim opFlag As Int16 = 0
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = Application.StartupPath & "\BartenderFile\ReelBarcode.btw"
    Dim BarFile As New StringBuilder()

#Region "包装"
    Dim MoidAllNum As Int64 = 0         '工單批量
    Dim MoidLastNum As Int64            '工單尾數量
    Dim CtPrtingNum As Int64            '工單可打印箱數
    Dim PackMethod As Int16 = 0         '裝箱數量
    Dim Packlink As String = ""         '箱標簽類型
    Dim PackItems As String = ""         '条码类型
#End Region

#End Region

#Region "窗体事件"

    Private Sub FrmListPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass
        Me.dtpEndDate.Value = Now.AddDays(1)
        Me.dtpStartDate.Value = Now.AddDays(-1)
        'Me.dgvPrintList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub FrmListPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
       
    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click

        
    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        
    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrint.Click
        Try
            dgvPrintList.Enabled = False
            If dgvPrintList.RowCount > 0 Then
                If (CheckPrint(Me.dgvPrintList)) Then
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            PrintBarCode(dgvPrintList.Rows(i), i + 1)
                        End If
                    Next
                Else
                    dgvPrintList.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If
            dgvPrintList.Enabled = True
            GetPO()
        Catch ex As Exception
            dgvPrintList.Enabled = True
            SetMessage(ex.ToString())
        End Try
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        GetPO()
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvPOList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPOList.CellEnter
        Try
            If Me.dgvPOList.Rows.Count = 0 OrElse Me.dgvPOList.CurrentRow Is Nothing Then
                Exit Sub
            End If

            GetPOPrintList(Me.dgvPOList.Item("pmm01", Me.dgvPOList.CurrentRow.Index).Value.ToString.Trim)
        Catch ex As Exception
            SetMessage("获取采购明细失败，请联系开发人员!")
        End Try
    End Sub

    Private Sub txtPONO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONO.KeyDown
        Dim dvTiptopPO As New DataView
        Try
            If (e.KeyCode = Keys.Enter) Then

                If String.IsNullOrEmpty(Me.txtPONO.Text.Trim.Trim()) Then
                    SetMessage("请输入查询Tiptop采购订单号!")
                    dvTiptopPO = Nothing
                    Exit Sub
                End If

                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim dtPO As New DataTable
                dtPO = Conn.GetDataTable(GetCheckPOSQL(Me.txtPONO.Text.Trim()))

                If dtPO.Rows.Count > 0 Then
                    SetMessage("采购订单已经下载，不能重复下载!")
                Else
                    '"Data Source=TOPPROD;user=LX10;password=lux9988;"
                    Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                    dvTiptopPO = TiptopConn.getDataView(GetTiptopPOSQL(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtPONO.Text.Trim()))
                    '获取Tiptop工单信息
                    If Not dvTiptopPO Is Nothing Then
                        SavaPO(dvTiptopPO)
                        dvTiptopPO.Dispose()
                    Else
                        SetMessage("输入采购订单不存在!")
                    End If

                    GetPO()

                    SetMessage("下载采购订单" & Me.txtPONO.Text.Trim & "成功!")
                    TiptopConn = Nothing
                    dtPO.Dispose()
                    Conn = Nothing
                End If
            End If

        Catch ex As Exception
            SetMessage("获取采购单信息失败,请联系开发人员!")
            dvTiptopPO.Dispose()
        End Try
    End Sub

#End Region

#Region "Function"

    Private Sub SavaPO(ByVal dvTiptopPO As DataView)
        Dim strChildSava As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            'PMM_FILE.PMM01, PMM_FILE.PMM04, PMM_FILE.PMM09, PMM_FILE.PMM13,
            'PMN_FILE.PMN02, PMN_FILE.PMN04, PMN_FILE.PMN041, PMN_FILE.PMN07, PMN_FILE.PMN20, PMN_FILE.PMN50, PMN_FILE.PMN55

            strChildSava.Append("INSERT INTO W_PO_HEADERS_T( PONO, PURCHAING_DATE, VENDOR_ID, VENDOR_NAME, DEPT_ID, DEPT_NAME) " & _
                    "VALUES('" & dvTiptopPO.Item(0).Item("PMM01").ToString & "','" & dvTiptopPO.Item(0).Item("PMM04").ToString & "','" & dvTiptopPO.Item(0).Item("PMM09").ToString & "'" & _
                    ",'" & dvTiptopPO.Item(0).Item("PMM09").ToString & "','" & dvTiptopPO.Item(0).Item("PMM13").ToString & "','" & dvTiptopPO.Item(0).Item("PMM13").ToString & "')")

            For i As Int16 = 0 To dvTiptopPO.Count - 1
                strChildSava.Append(vbNewLine & "IF NOT EXISTS(SELECT ITEM_NO FROM W_PO_LINES_T WHERE PONO='" & dvTiptopPO.Item(i).Item("PMM01").ToString & "' AND ITEM_NO='" & dvTiptopPO.Item(i).Item("PMN02").ToString & "' AND MATERIAL_NO='" & dvTiptopPO.Item(i).Item("PMN04").ToString & "') BEGIN INSERT INTO W_PO_LINES_T(PONO, ITEM_NO, MATERIAL_NO, SPECIFICATION, QTY, RECEIVE_QTY, PRINT_NUMBER, UNIT_MEASURE_ID, UOM_NAME, VENDOR_ID, " & _
                                " VENDOR_NAME, STATUS, USER_NAME, CREATE_DATE) " & _
                                "VALUES('" & dvTiptopPO.Item(i).Item("PMM01").ToString & "','" & dvTiptopPO.Item(i).Item("PMN02").ToString & "','" & dvTiptopPO.Item(i).Item("PMN04").ToString & "',N'" & dvTiptopPO.Item(i).Item("PMN041").ToString & "'," & dvTiptopPO.Item(i).Item("PMN20").ToString & ",0,0" & _
                                ",N'" & dvTiptopPO.Item(i).Item("PMN07").ToString & "',N'" & dvTiptopPO.Item(i).Item("PMN07").ToString & "',N'" & dvTiptopPO.Item(i).Item("PMM09").ToString & "',N'" & dvTiptopPO.Item(i).Item("PMM09").ToString & "','1','" & SysMessageClass.UseId.ToLower.Trim & "',GetDate()) END")
            Next

            If (Not String.IsNullOrEmpty(strChildSava.ToString)) Then
                Conn.ExecSql(strChildSava.ToString())
            End If

            strChildSava = Nothing
            Conn = Nothing
        Catch ex As Exception
            strChildSava = Nothing
            Conn = Nothing
        End Try
    End Sub

    Private Function GetCheckPOSQL(ByVal POName As String) As String
        Dim Sql As String
        Sql = " SELECT PONO FROM W_PO_HEADERS_T WHERE PONO=" & FormatQuerySQLString(POName)
        Return Sql
    End Function

    Private Function GetTiptopPOSQL(ByVal OperationsCenter As String, ByVal ProfitCenter As String, ByVal POName As String) As String
        Dim Sql As String

        Sql = "SELECT PMM01, PMM04, PMM09, PMM13," _
            & " PMN02, PMN04, PMN041, PMN07, PMN20, PMN50, PMN55" _
            & " FROM " + OperationsCenter + ".PMM_FILE" _
            & " INNER JOIN " + OperationsCenter + ".PMN_FILE ON " + OperationsCenter + ".PMN_FILE.PMN01=" + OperationsCenter + ".PMM_FILE.PMM01" _
            & " WHERE PMMACTI='Y' AND PMM25='2'" _
            & " AND PMM01=PMN01  AND PMN20>(PMN50-PMN55) AND (NOT PMM02 LIKE 'WB%') AND PMM01='" & POName & "' AND NVL(PMMBU,' ') = NVL('" & ProfitCenter & "',' ')"
        Return Sql
    End Function

    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '判断打印数量
                If Not IsNumeric(dgvPrintList.Rows(I).Cells("PrintNum").Value) Then
                    SetMessage("第" + (I + 1).ToString + "行输入打印数量有误！")
                    Return False
                    Exit For
                End If
                If (Int(dgvPrintList.Rows(I).Cells("PrintNum").Value) > 1000) Then
                    SetMessage("第" + (I + 1).ToString + "行产品条码一次打印數量限制在1-1000以內！")
                    Return False
                    Exit For
                End If

                '判断包装容量数量
                If Not IsNumeric(dgvPrintList.Rows(I).Cells("PackingCapacity").Value) Then
                    SetMessage("输入第" + (I + 1).ToString + "行包装容量数量有误！")
                    Return False
                    Exit For
                End If

                If (CLng(dgvPrintList.Rows(I).Cells("PackingCapacity").Value) * CLng(dgvPrintList.Rows(I).Cells("PrintNum").Value) > CLng(dgvPrintList.Rows(I).Cells("ToReceivedAmount").Value)) Then
                    SetMessage("输入第" + (I + 1).ToString + "打印数量超过待收数量！")
                    Return False
                    Exit For
                End If

                If (Len(dgvPrintList.Rows(I).Cells("VERSION").Value) <> 2) Then
                    SetMessage("输入第" + (I + 1).ToString + "版本有误，请输入两位版本号！")
                    Return False
                    Exit For
                End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim)) Then
                    SetMessage("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                    Return False
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvPrintList.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim
                    If (ps.IsValid = False) Then
                        SetMessage("第" + (I + 1).ToString + "行打印机不可用，请检查!")
                        Return False
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
        End If
        Return iSelect
    End Function

    Private Function FormatSQLString(ByVal Value As String) As String
        Return Value.Replace("'", "''")
    End Function

    Private Function FormatQuerySQLString(ByVal Value As String) As String
        Return "N'" & Value.Replace("'", "''") & "'"
    End Function

    Private Function InitializePrintParameter(ByVal PrintData As DataGridViewRow) As Boolean
        Try
            reelPrint.CustomerName = "LUXSHARE-ICT"
            reelPrint.MaterialNO = PrintData.Cells("pmn04").Value.ToString
            reelPrint.SupplierPN = PrintData.Cells("pmn04").Value.ToString
            reelPrint.DateCode = PrintData.Cells("DateCode").Value.ToString
            reelPrint.Rev = PrintData.Cells("VERSION").Value.ToString

            If (PrintData.Cells("PackingCapacity").Value.ToString = "0") Then
                reelPrint.PackingCapacity = PrintData.Cells("MantissaPackingQty").Value.ToString
                reelPrint.MantissaPackingQty = PrintData.Cells("PackingCapacity").Value.ToString
            Else
                reelPrint.PackingCapacity = PrintData.Cells("PackingCapacity").Value.ToString
                reelPrint.MantissaPackingQty = PrintData.Cells("MantissaPackingQty").Value.ToString
            End If
            
            reelPrint.Unit = "Unit(" + PrintData.Cells("pmn07").Value.ToString + ")"
            reelPrint.GW = PrintData.Cells("GWeight").Value.ToString
            reelPrint.PONO = PrintData.Cells("PONO").Value.ToString
            reelPrint.ItemNO = PrintData.Cells("pmn02").Value.ToString
            reelPrint.PrintCount = CInt(PrintData.Cells("PrintNum").Value) + CInt(IIf(CDbl(PrintData.Cells("MantissaPackingQty").Value) > 0, "1", "0"))
            reelPrint.PrintName = PrintData.Cells("PrinterName").FormattedValue.ToString
        Catch ex As Exception
            SetMessage("获取物料条码初始信息失败，请联系开发人员!")
        End Try
    End Function

    Private Function CheckPrintQty(ByVal PtaskId As String, ByVal Moid As String, ByVal PackId As String, ByVal DisorderType As String, ByVal PackItem As String) As Boolean
        Dim RecDr As SqlDataReader = Nothing
        Dim Sqlstr As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'AND Packid=
        Sqlstr = "SELECT ISNULL(PrtQty,0) AS PrtQty,ISNULL(FinishPrintQty,0) AS FinishPrintQty FROM m_SnAssign_t WHERE Ptaskid='" + PtaskId + "' AND Moid='" + Moid + "'"

        RecDr = Conn.GetDataReader(Sqlstr)
        If RecDr.HasRows Then
            RecDr.Read()
            Dim D As String = RecDr("FinishPrintQty").ToString
            Dim S As String = RecDr("PrtQty").ToString
            If (CInt(RecDr("FinishPrintQty").ToString) + CInt("1")) > CInt(RecDr("PrtQty").ToString) Then
                Return False
            Else
                Return True
            End If
        End If

        If Not RecDr Is Nothing Then
            RecDr.Close()
            Conn.PubConnection.Close()
        End If
        RecDr = Nothing
        Conn = Nothing
        Return False
    End Function

#End Region

#Region "Bind"


#End Region

#Region "方法"

    Private Sub ClearQuery()
        Me.txtPONO.Text = ""

    End Sub

    '取得采购订单清单
    Private Sub GetPO()
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append("SELECT PONO, PURCHAING_DATE, VENDOR_ID, VENDOR_NAME, DEPT_ID, DEPT_NAME FROM W_PO_HEADERS_T WHERE PURCHAING_DATE between cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 00:00:00" & "' as datetime) and cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)")

        If Not String.IsNullOrEmpty(Me.txtPONO.Text.Trim) Then
            Sqlstr.Append(" and PONO like '%" & Me.txtPONO.Text.ToString.Trim & "%'")
        End If
        Sqlstr.Append(" ORDER BY PURCHAING_DATE DESC")

        LoadData(Sqlstr.ToString, Me.dgvPOList)
    End Sub

    '取得工单打印清单
    Private Sub GetPOPrintList(ByVal strPONO As String)
        Sqlstr.Remove(0, Sqlstr.Length)

        Sqlstr.Append(" SELECT PONO, ITEM_NO, MATERIAL_NO, SPECIFICATION, QTY, RECEIVE_QTY, PRINT_NUMBER, UNIT_MEASURE_ID, UOM_NAME, VENDOR_ID, ")
        Sqlstr.Append(" VENDOR_NAME, STATUS, USER_NAME, CREATE_DATE")
        Sqlstr.Append(" FROM W_PO_LINES_T WHERE PONO='" & strPONO & "'")

        LoadData(Sqlstr.ToString, Me.dgvPrintList)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("PrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            Do While DReader.Read()
                If dgvName Is Me.dgvPOList Then
                    dgvName.Rows.Add(DReader.Item("PONO").ToString, DReader.Item("PURCHAING_DATE").ToString, DReader.Item("VENDOR_ID").ToString, DReader.Item("DEPT_ID").ToString)
                ElseIf dgvName Is Me.dgvPrintList Then

                    If (SqlClassM.CheckPrintersList("")) Then
                        PrintName = DReader.Item("PrinterName").ToString
                    Else
                        PrintName = ""
                    End If

                    '增加栈板条码打印

                    dgvName.Rows.Add(True, DReader.Item("PONO").ToString, DReader.Item("ITEM_NO").ToString, DReader.Item("MATERIAL_NO").ToString, DReader.Item("SPECIFICATION").ToString, PrintName, DReader.Item("UNIT_MEASURE_ID").ToString, _
                    DReader.Item("Qty").ToString, DReader.Item("RECEIVE_QTY").ToString, (CLng(DReader.Item("Qty")) - CLng(DReader.Item("RECEIVE_QTY"))).ToString, "0", "0", "0", "", Now.ToString("yyyy/MM/dd"), "", "")

                End If
            Loop
            Me.ToolLblCount.Text = Me.dgvPOList.Rows.Count
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BindPrintList(ByVal strSQL As String, ByVal dgvName As DataGridView)
        Dim dtTemp As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            dtTemp = DataHand.GetDataTable(strSQL)

            dtTemp = Nothing
            DataHand = Nothing
        Catch ex As Exception
            dtTemp = Nothing
            DataHand = Nothing
        End Try
    End Sub

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)

        If (Not PrintData Is Nothing) Then
            If InitializePrintParameter(PrintData) Then
                Exit Sub
            End If

            BuildSBarCode(PrintData)
        Else
            SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
        End If
    End Sub

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

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
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
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
                    Sqlstr.Append("INSERT INTO W_PRINTREEL_T(REEL_BARCODE, DATECODE, PONO, ITEM_NO, MATERIAL_ID, QTY, PRINT_USER, PRINT_TIME, STATUS" _
                        & " )VALUES( '" & strReelBarcode & "','" & reelPrint.DateCode & "','" & reelPrint.PONO & "','" & reelPrint.ItemNO & "','" & reelPrint.MaterialNO & "','" & PrintData.Cells("PackingCapacity").Value.ToString.Trim & "','" & SysMessageClass.UseId.ToUpper & "',Getdate(),'1'" _
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

            '更新收料数量，样式流水号(收料暂不自动)
            'Sqlstr.Append("UPDATE W_PO_LINES")
            Sqlstr.Append("UPDATE W_PO_LINES_T SET PRINT_QTY = PRINT_QTY + '" & CDbl(reelPrint.PackingCapacity) * (CDbl(reelPrint.PrintCount) - IIf(reelPrint.MantissaPackingQty > 0, 1, 0)) + reelPrint.MantissaPackingQty & "' WHERE PONO='" & reelPrint.PONO & "' AND ITEM_NO='" & reelPrint.ItemNO & "' AND MATERIAL_NO='" & reelPrint.MaterialNO & "'")
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
            SetMessage("打印失败，请联系开发人员!")
        End Try
    End Sub

    '打印参数检查
    Private Function Checking(ByVal PrintData As DataGridViewRow) As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim bRtValue As Boolean = False
        Try
            '检查收料数量
            Dim strSQL As String
            Dim fQty As Double
            strSQL = "SELECT PONO, ITEM_NO, MATERIAL_NO, SPECIFICATION, QTY, RECEIVE_QTY FROM W_PO_LINES_T WHERE PONO='" & reelPrint.PONO & "' AND ITEM_NO='" & reelPrint.ItemNO & "' AND MATERIAL_NO='" & reelPrint.MaterialNO & "'"

            Dim DReader As SqlClient.SqlDataReader = Conn.GetDataReader(strSQL)

            If (DReader.HasRows) Then
                If DReader.Read Then
                    fQty = CDbl(DReader.Item("QTY").ToString()) - CDbl(DReader.Item("RECEIVE_QTY").ToString())
                End If

                DReader = Nothing
                If ((CDbl(PrintData.Cells("PackingCapacity").Value.ToString) * CDbl(PrintData.Cells("PrintNum").Value.ToString) + CDbl(PrintData.Cells("MantissaPackingQty").Value.ToString)) > fQty) Then
                    SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项打印数量超过收料数量！")
                Else
                    bRtValue = True
                End If
            Else
                SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项无法获取打印采购项次信息")
            End If
            Conn = Nothing
        Catch ex As Exception
            SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项检查打印参数失败")
            Conn = Nothing
        End Try
        Return bRtValue
    End Function

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
                        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
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
            BarCodeStyle = reelPrint.MaterialNO + reelPrint.Rev + GetBarCodeFormatDate(reelPrint.DateCode) + Qty.ToString.PadLeft(7, "0")
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
            Case Else
                Return CurrMonth
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
            Case Else
                Return CurrDays
        End Select
    End Function

#Region "有序条码"

    Private Sub ModlePrintGenRecord(ByVal UseY As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
        '              "([Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
        '             ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
        '             ",[label23],[label24]) " & _
        '              "VALUES('" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        'Dim nPrintStr = New StringBuilder()
        'Try
        '    Mreader = Conn.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
        '    Dim Dview As New DataView(Mreader)
        '    Dtable = Dview.ToTable(True, "BarArea")
        '    For Each dr As DataRow In Dtable.Rows
        '        Areaid = dr!BarArea.ToString
        '        Using TempView As DataView = New DataView(BarCodePartTable)
        '            If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
        '                TempView.RowFilter = "BarArea='" & Areaid & "'"
        '                TempView.Sort = "F_orderid asc"
        '                'PrintStr.Append(CommandStr)
        '                For I = 0 To TempView.Count - 1
        '                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
        '                Next
        '                Continue For
        '                'Exit Try
        '            End If
        '            If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
        '                'PrintStr.Append(CommandStr)
        '                If Areaid.ToLower = "barcode1" Then
        '                    If PrintStr.ToString = "" Then
        '                        nPrintStr.Append(PrintPart(1, 1))
        '                    Else
        '                        nPrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
        '                    End If
        '                    Continue For
        '                    'Exit Try
        '                End If
        '                TempView.RowFilter = "BarArea='" & Areaid & "'"
        '                TempView.Sort = "F_orderid asc"
        '                nPrintStr.Append(vbNewLine)
        '                For I = 0 To TempView.Count - 1
        '                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString)
        '                Next
        '                nPrintStr.Append(CurrSeriNo)
        '                Continue For
        '                'Exit Try
        '            End If
        '            If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
        '                'PrintStr.Append(CommandStr)
        '                If Areaid.ToLower = "barlabel1" Then
        '                    If UseY = "N" Then
        '                        nPrintStr.Append(vbNewLine & "This is test")
        '                    Else
        '                        nPrintStr.Append(vbNewLine & PrintPart(2, 1))
        '                    End If
        '                    Continue For
        '                    'Exit Try
        '                End If
        '                TempView.RowFilter = "BarArea='" & Areaid & "'"
        '                TempView.Sort = "F_orderid asc"
        '                For I = 0 To TempView.Count - 1
        '                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
        '                Next
        '                Continue For
        '                'Exit Try
        '            End If
        '        End Using
        '    Next

        '    ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
        '    Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        '    Dim StrLen As Integer = sArray.Length
        '    BarValueStr.Append(FixStr)
        '    If BarFile.ToString() <> "" Then
        '        BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
        '    End If
        '    Dim Index As Integer = 0
        '    For Each ifalg As String In sArray

        '        If Index = 0 Then
        '            BarFile.Append("""" & ifalg.ToString() & """")
        '            BarValueStr.Append("'" & ifalg.ToString() & "'")
        '        Else
        '            BarFile.Append(",""" & ifalg.ToString() & """")
        '            BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
        '        End If

        '        Index = Index + 1
        '    Next
        '    Dim SpaceStr As String = ","
        '    For j As Int16 = 1 To 16 - StrLen - 1
        '        SpaceStr = SpaceStr & "'',"
        '    Next
        '    SpaceStr = SpaceStr & "'')"
        '    BarValueStr.Append(SpaceStr)

        '    Conn = Nothing
        'Catch ex As Exception
        '    Conn = Nothing
        '    Throw ex
        'End Try
    End Sub

#End Region

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)VbCommClass.VbCommClass.PrintDataModle & 
        btFormat = btApp.Formats.Open(pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

#End Region

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            SetMessage("选择执行异常，请联系开发人员!")
        End Try
    End Sub

    Private Sub dgvPrintList_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrintList.CellValueChanged
        Try
            Dim FCLNumber As Int16
            Dim TrunkNumber As Int16
            If (dgvPrintList.Rows.Count > 0) Then
                If (Not dgvPrintList.Rows(e.RowIndex).IsNewRow And e.RowIndex >= 0 And e.RowIndex <> -1) Then
                    If (e.ColumnIndex = 10) Then
                        If (Not String.IsNullOrEmpty(Me.dgvPrintList.Rows(e.RowIndex).Cells(10).Value)) Then
                            If (IsNumeric(Me.dgvPrintList.Rows(e.RowIndex).Cells(10).Value.ToString.Trim)) Then
                                If (CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(10).Value.ToString.Trim) <= 0) Then
                                    SetMessage("第" + e.RowIndex.ToString + "行输入包装容量必须大于0!")
                                    Me.dgvPrintList.Rows(e.RowIndex).Cells(10).Value = "0"
                                    Me.dgvPrintList.Rows(e.RowIndex).Cells(11).Value = "0"
                                    Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value = "0"
                                Else

                                    If (CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim) > CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(9).Value.ToString.Trim)) Then
                                        SetMessage("第" + e.RowIndex.ToString + "行包装容量大于待收数量!")
                                    Else
                                        If ((CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(9).Value.ToString.Trim) Mod CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim)) = 0) Then
                                            FCLNumber = CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(9).Value.ToString.Trim) / CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim)
                                            TrunkNumber = 0
                                            Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value = 0
                                        Else
                                            FCLNumber = Int(CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(9).Value.ToString.Trim) / CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim))
                                            TrunkNumber = 1
                                            Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value = CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(9).Value.ToString.Trim) Mod CLng(Me.dgvPrintList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim)
                                        End If
                                        Me.dgvPrintList.Rows(e.RowIndex).Cells(11).Value = FCLNumber + TrunkNumber
                                    End If
                                End If
                            Else
                                SetMessage("第" + e.RowIndex.ToString + "行包装容量输入有误!")
                            End If
                        Else
                            Me.dgvPrintList.Rows(e.RowIndex).Cells(10).Value = "0"
                            Me.dgvPrintList.Rows(e.RowIndex).Cells(11).Value = "0"
                            Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value = "0"
                        End If
                    End If

                    If (e.ColumnIndex = 11) Then
                        If (String.IsNullOrEmpty(Me.dgvPrintList.Rows(e.RowIndex).Cells(11).Value)) Then
                            Me.dgvPrintList.Rows(e.RowIndex).Cells(11).Value = "0"
                        End If
                    End If
                    If (e.ColumnIndex = 12) Then
                        If (String.IsNullOrEmpty(Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value)) Then
                            Me.dgvPrintList.Rows(e.RowIndex).Cells(12).Value = "0"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SetMessage("执行打印数量转换错误，请联系开发人员!")
        End Try
    End Sub

    Private Sub dgvPrintList_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPrintList.EditingControlShowing
        Try
            'Dim tb As TextBox
            'If (TypeOf e.Control Is TextBox) Then
            '    tb = e.Control
            '    tb. += new KeyPressEventHandler(tb_KeyPress);
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class
