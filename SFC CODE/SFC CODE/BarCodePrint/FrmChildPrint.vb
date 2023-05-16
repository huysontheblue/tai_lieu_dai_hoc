'--根据母条码，打印出来字条码。
'--Create by :　cq
'--Create date :　2018/10/18
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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmChildPrint

#Region "窗體變量"

    Dim reelPrint As New ReelPrint
    Dim Sqlstr As New StringBuilder
    Dim opFlag As Int16 = 0
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = "" 'Application.StartupPath & "\BartenderFile\ReelBarcode.btw"
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
        '  Me.dtpEndDate.Value = Now.AddDays(1)
        ' Me.dtpStartDate.Value = Now.AddDays(-1)
        'Me.dgvPrintList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter

        SqlClassM.GetPrintersList(CboPrinter)


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
            dgvMotherBarList.Enabled = False
            If dgvMotherBarList.RowCount > 0 Then
                If (CheckPrint(Me.dgvMotherBarList)) Then
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvMotherBarList.RowCount - 1
                        chkTemp = dgvMotherBarList.Rows(i).Cells("ChkSelectM")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            PrintBarCode(dgvMotherBarList.Rows(i), i + 1)
                        End If
                    Next
                Else
                    dgvMotherBarList.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If
            dgvMotherBarList.Enabled = True
            GetMotherBarInfo()
        Catch ex As Exception
            dgvPrintList.Enabled = True
            SetMessage(ex.ToString())
        End Try
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        GetMotherBarInfo()
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"



    Private Sub txtPONO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOID.KeyDown
        Dim dvTiptopPO As New DataView
        Try
            If (e.KeyCode = Keys.Enter) Then

                'If String.IsNullOrEmpty(Me.txtMOID.Text.Trim.Trim()) Then
                '    SetMessage("请输入查询Tiptop采购订单号!")
                '    dvTiptopPO = Nothing
                '    Exit Sub
                'End If

                'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                'Dim dtPO As New DataTable
                'dtPO = Conn.GetDataTable(GetCheckPOSQL(Me.txtMOID.Text.Trim()))

                'If dtPO.Rows.Count > 0 Then
                '    SetMessage("采购订单已经下载，不能重复下载!")
                'Else
                '    '"Data Source=TOPPROD;user=LX10;password=lux9988;"
                '    Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                '    dvTiptopPO = TiptopConn.getDataView(GetTiptopPOSQL(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtMOID.Text.Trim()))
                '    '获取Tiptop工单信息
                '    If Not dvTiptopPO Is Nothing Then
                '        SavaPO(dvTiptopPO)
                '        dvTiptopPO.Dispose()
                '    Else
                '        SetMessage("输入采购订单不存在!")
                '    End If

                '    '  GetPO()

                '    SetMessage("下载采购订单" & Me.txtMOID.Text.Trim & "成功!")
                '    TiptopConn = Nothing
                '    dtPO.Dispose()
                '    Conn = Nothing
                'End If
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
        ' Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

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
                DbOperateUtils.ExecSql(strChildSava.ToString())
            End If

            strChildSava = Nothing

        Catch ex As Exception
            strChildSava = Nothing
        End Try
    End Sub

    Private Function GetCheckPOSQL(ByVal POName As String) As String
        Dim Sql As String
        Sql = " SELECT PONO FROM W_PO_HEADERS_T WHERE PONO=" & FormatQuerySQLString(POName)
        Return Sql
    End Function



    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell

        For I As Int16 = 0 To dgvMotherBarList.RowCount - 1
            chkTemp = dgvMotherBarList.Rows(I).Cells("ChkSelectM")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '判断打印数量
                'If Not IsNumeric(dgvPrintList.Rows(I).Cells("PrintNum").Value) Then
                '    SetMessage("第" + (I + 1).ToString + "行输入打印数量有误！")
                '    Return False
                '    Exit For
                'End If

                'If (Int(dgvPrintList.Rows(I).Cells("PrintNum").Value) > 1000) Then
                '    SetMessage("第" + (I + 1).ToString + "行产品条码一次打印數量限制在1-1000以內！")
                '    Return False
                '    Exit For
                'End If

                'If (Len(dgvPrintList.Rows(I).Cells("VERSION").Value) <> 2) Then
                '    SetMessage("输入第" + (I + 1).ToString + "版本有误，请输入两位版本号！")
                '    Return False
                '    Exit For
                'End If

                '判断打印机是否可用
                'If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim)) Then
                '    SetMessage("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                '    Return False
                '    Exit For
                'Else
                '    Dim ps As New PrinterSettings
                '    ps.PrinterName = dgvPrintList.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim
                '    If (ps.IsValid = False) Then
                '        SetMessage("第" + (I + 1).ToString + "行打印机不可用，请检查!")
                '        Return False
                '        Exit For
                '    End If
                'End If

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
            'reelPrint.CustomerName = "LUXSHARE-ICT"
            'reelPrint.MaterialNO = PrintData.Cells("pmn04").Value.ToString
            'reelPrint.SupplierPN = PrintData.Cells("pmn04").Value.ToString
            'reelPrint.DateCode = PrintData.Cells("DateCode").Value.ToString
            'reelPrint.Rev = PrintData.Cells("VERSION").Value.ToString

            'If (PrintData.Cells("PackingCapacity").Value.ToString = "0") Then
            '    reelPrint.PackingCapacity = PrintData.Cells("MantissaPackingQty").Value.ToString
            '    reelPrint.MantissaPackingQty = PrintData.Cells("PackingCapacity").Value.ToString
            'Else
            '    reelPrint.PackingCapacity = PrintData.Cells("PackingCapacity").Value.ToString
            '    reelPrint.MantissaPackingQty = PrintData.Cells("MantissaPackingQty").Value.ToString
            'End If

            If Me.CboPrinter.Text = String.Empty Then
                MessageUtils.ShowError("请先选择打印机!")
                Return False
            End If

            pFilePath = VbCommClass.VbCommClass.PrintDataModle & PrintData.Cells("BartenderFile").Value.ToString

            Return True
        Catch ex As Exception
            SetMessage("获取物料条码初始信息失败，请联系开发人员!")
        End Try
    End Function

    Private Function CheckPrintQty(ByVal PtaskId As String, ByVal Moid As String, ByVal PackId As String, ByVal DisorderType As String, ByVal PackItem As String) As Boolean
        Dim RecDr As SqlDataReader = Nothing
        Dim Sqlstr As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'AND Packid=
        Sqlstr = "SELECT ISNULL(PrtQty,0) AS PrtQty,ISNULL(FinishPrintQty,0) AS FinishPrintQty " & _
                 " FROM m_SnAssign_t WHERE Ptaskid='" + PtaskId + "' AND Moid='" + Moid + "'"

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
        Me.txtMOID.Text = ""

    End Sub

    ''' <summary>
    ''' 取得母条码信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetMotherBarInfo()
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" SELECT SBarCode as MotherBar, Qty,BartenderFile,Moid")
        Sqlstr.Append(" FROM m_SnSBarCode_t WHERE 1=1 ")

        If Not String.IsNullOrEmpty(Me.txtMOID.Text) Then
            Sqlstr.Append(" AND MOID LIKE '" & Me.txtMOID.Text.ToString.Trim & "%'")
        End If

        If Not String.IsNullOrEmpty(Me.txtMotherBar.Text.Trim) Then
            Sqlstr.Append(" AND SBarCode LIKE '" & Me.txtMotherBar.Text.ToString.Trim & "%'")
        End If
        Sqlstr.Append(" ORDER BY Intime DESC")

        LoadData(Sqlstr.ToString, Me.dgvMotherBarList)
    End Sub


    ''' <summary>
    ''' 取得子条码打印清单
    ''' </summary>
    ''' <param name="strMotherBar"></param>
    ''' <remarks></remarks>
    Private Sub GetChildBarPrintList(ByVal strMotherBar As String, ByVal iChildBarCount As Integer )
        Sqlstr.Remove(0, Sqlstr.Length)

        Sqlstr.Append(" SELECT ChildBarCode, (Case Status WHEN 0 then N'0.未打印' WHEN 1 then N'1.已打印' END) StatusShow, Status,")
        Sqlstr.Append("  UserID, Intime")
        Sqlstr.Append(" FROM m_SnBarcodeChild_t WHERE MotherBarCode='" & strMotherBar & "'")

        LoadChildData(Sqlstr.ToString, Me.dgvPrintList, iChildBarCount, strMotherBar)
    End Sub

    '填充数据
    Private Sub LoadChildData(ByVal Sqlstr As String, ByVal dgvName As DataGridView, ByVal iChildBarCount As Int16, _
                              ByVal strMotherBar As String)
        ' Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        ' Dim DReader As SqlClient.SqlDataReader
        Dim o_sbSQL As New StringBuilder
        dim o_strTmpChildBar As String =""
        Try
            dgvName.Rows.Clear()

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    For Each dr As DataRow In o_dt.Rows
                        dgvPrintList.Rows.Add(
                                                True, dr.Item("ChildBarCode").ToString, dr.Item("StatusShow").ToString)
                    Next
                Else
                    '没有数据
                    For i As Int16 = 0 To iChildBarCount - 1
                        o_strTmpChildBar = strMotherBar + "-" + (i + 1).ToString.PadLeft(4, "0")
                        dgvPrintList.Rows.Add(True, o_strTmpChildBar)

                        o_sbSQL.Append(" Insert into m_SnBarcodeChild_t(ChildBarCode,MotherBarCode,Status,Intime,UserID)")
                        o_sbSQL.Append(" Values('" & o_strTmpChildBar & "','" & strMotherBar & "',0, getdate(), '" & VbCommClass.VbCommClass.UseId & "')")

                    Next


                End If
            End Using

            If Not String.IsNullOrEmpty(o_sbSQL.ToString) Then
                DbOperateUtils.ExecSQL( o_sbSQL.ToString)
            End If

            ' SqlClassM.GetPrintersList(cmbTmp)
            'Me.ToolLblCount.Text = Me.dgvMotherBarList.Rows.Count

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            ' Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("PrinterName")
            ' SqlClassM.GetPrintersList(cmbTmp)

            Do While DReader.Read()
                If dgvName Is Me.dgvMotherBarList Then
                    dgvName.Rows.Add(False,
                                     DReader.Item("MotherBar").ToString,
                                     DReader.Item("QTY").ToString,
                                     DReader.Item("BartenderFile").ToString,
                                     DReader.Item("Moid").ToString
                                     )
                ElseIf dgvName Is Me.dgvPrintList Then

                    dgvName.Rows.Add(True, DReader.Item("ChildBarCode").ToString,
                                     DReader.Item("MATERIAL_NO").ToString)

                End If
            Loop
            Me.ToolLblCount.Text = Me.dgvMotherBarList.Rows.Count
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
            If Not InitializePrintParameter(PrintData) Then
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
        Try
            Sqlstr.Remove(0, Sqlstr.Length)
            Dim strNumber As String
            Dim o_strTmpChildBar As String
            Dim TxtFileStr As New StringBuilder

            '检查样式是否锁定
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            '生成数据库脚本
            For I As Int16 = 0 To dgvPrintList.Rows.Count - 1   'reelPrint.PrintCount - 1

                ' strNumber = (reelPrint.CurrNumber + (I + 1)).ToString.PadLeft(3, "0")

                '写入物料条码
                If (CDbl(reelPrint.MantissaPackingQty) > 0 And I = reelPrint.PrintCount - 1) Then
                    '尾数箱处理
                    o_strTmpChildBar = dgvPrintList.Rows(I).Cells("ChildBarCode").Value.ToString

                    'Sqlstr.Append("INSERT INTO W_PRINTREEL_T(REEL_BARCODE, DATECODE, PONO, ITEM_NO, MATERIAL_ID, QTY, PRINT_USER, PRINT_TIME, STATUS" _
                    '& " )VALUES( '" & strReelBarcode & "','" & reelPrint.DateCode & "','" & reelPrint.PONO & "','" & reelPrint.ItemNO & "','" & reelPrint.MaterialNO & "','" & reelPrint.MantissaPackingQty & "','" & SysMessageClass.UseId.ToUpper & "',Getdate(),'1'" _
                    '& ") ")

                    '生成打印Text
                    If I = 0 Then
                        TxtFileStr.Append("""" & o_strTmpChildBar & """")
                    Else
                        TxtFileStr.Append(vbNewLine & """" & o_strTmpChildBar & """")
                    End If
                Else
                    o_strTmpChildBar = dgvPrintList.Rows(I).Cells("ChildBarCode").Value.ToString
                    'Sqlstr.Append("INSERT INTO W_PRINTREEL_T(REEL_BARCODE, DATECODE, PONO, ITEM_NO, MATERIAL_ID, QTY, PRINT_USER, PRINT_TIME, STATUS" _
                    '    & " )VALUES( '" & strReelBarcode & "','" & reelPrint.DateCode & "','" & reelPrint.PONO & "','" & reelPrint.ItemNO & "','" & reelPrint.MaterialNO & "','" & PrintData.Cells("PackingCapacity").Value.ToString.Trim & "','" & SysMessageClass.UseId.ToUpper & "',Getdate(),'1'" _
                    '    & ") ")

                    Sqlstr.Append("UPDATE m_SnBarcodeChild_t SET Status =  1 WHERE ChildBarCode='" & o_strTmpChildBar & "'")


                    '生成打印Text
                    If I = 0 Then
                        TxtFileStr.Append("""" & o_strTmpChildBar & """")
                    Else
                        TxtFileStr.Append(vbNewLine & """" & o_strTmpChildBar & """")
                    End If
                End If

                '写入BarRecordValue
                'Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                '              "([Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                '             ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                '             ",[label23],[label24]) " & _
                '              "VALUES('" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
            Next



            '更新收料数量，样式流水号(收料暂不自动)
            'Sqlstr.Append("UPDATE W_PO_LINES_T SET PRINT_QTY = PRINT_QTY + '" & CDbl(reelPrint.PackingCapacity) * (CDbl(reelPrint.PrintCount) - IIf(reelPrint.MantissaPackingQty > 0, 1, 0)) + reelPrint.MantissaPackingQty & "' WHERE PONO='" & reelPrint.PONO & "' AND ITEM_NO='" & reelPrint.ItemNO & "' AND MATERIAL_NO='" & reelPrint.MaterialNO & "'")
            'Sqlstr.Append("UPDATE W_PRINTSTYLE_T SET QTY = QTY + '" & reelPrint.PrintCount - IIf(reelPrint.MantissaPackingQty > 0, 1, 0) & "' WHERE STYLEFORMAT='" & reelPrint.StyleID & "'")

            'If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
            '    Sqlstr.Append("UPDATE W_PRINTSTYLE_T SET QTY = QTY + 1 WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID & "'")
            'End If

           
            '写入打印Text
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)


            '打印
            If (Not String.IsNullOrEmpty(Sqlstr.ToString)) Then
                DbOperateUtils.ExecSQL(Sqlstr.ToString)

                FileToBarCodePrint(pFilePath,CboPrinter.Text )
            End If

            '解锁样式
            'reelPrint.OpenPrintLock(reelPrint.StyleID)
            'If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
            '    reelPrint.OpenPrintLock(reelPrint.MantissaStyleID)
            'End If
        Catch ex As Exception
            'reelPrint.OpenPrintLock(reelPrint.StyleID)
            'If (Not String.IsNullOrEmpty(reelPrint.MantissaStyleID)) Then
            '    reelPrint.OpenPrintLock(reelPrint.MantissaStyleID)
            'End If
            SetMessage("打印失败，请联系开发人员!")
        End Try
    End Sub

    '打印参数检查
    Private Function Checking(ByVal PrintData As DataGridViewRow) As Boolean
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim bRtValue As Boolean = False
        Try
            '检查收料数量
            'Dim strSQL As String
            'Dim fQty As Double
            'strSQL = "SELECT PONO, ITEM_NO, MATERIAL_NO, SPECIFICATION, QTY, RECEIVE_QTY FROM W_PO_LINES_T WHERE PONO='" & reelPrint.PONO & "' AND ITEM_NO='" & reelPrint.ItemNO & "' AND MATERIAL_NO='" & reelPrint.MaterialNO & "'"

            'Dim DReader As SqlClient.SqlDataReader = Conn.GetDataReader(strSQL)

            'If (DReader.HasRows) Then
            '    If DReader.Read Then
            '        fQty = CDbl(DReader.Item("QTY").ToString()) - CDbl(DReader.Item("RECEIVE_QTY").ToString())
            '    End If

            '    DReader = Nothing
            '    If ((CDbl(PrintData.Cells("PackingCapacity").Value.ToString) * CDbl(PrintData.Cells("PrintNum").Value.ToString) + CDbl(PrintData.Cells("MantissaPackingQty").Value.ToString)) > fQty) Then
            '        SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项打印数量超过收料数量！")
            '    Else
            '        bRtValue = True
            '    End If
            'Else
            '    SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项无法获取打印采购项次信息")
            'End If
            'Conn = Nothing
        Catch ex As Exception
            SetMessage("打印失败，第" & PrintData.Cells("pmn02").Value.ToString & "项检查打印参数失败")
            'Conn = Nothing
        End Try
        Return True
    End Function

    '檢查樣式
    Private Function CheckStyle() As Boolean
        Dim Sqlstr As String= string.Empty
        '  Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            'reelPrint.StyleID = MakeStyle(reelPrint.PackingCapacity) '產生樣式
            'Sqlstr = "SELECT STYLEFORMAT,QTY,STATUS from W_PRINTSTYLE_T WHERE STYLEFORMAT='" & reelPrint.StyleID.ToString & "'"
            'Dim RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

            'If RecTable.Read Then
            '    If RecTable.GetString(RecTable.GetOrdinal("STATUS")) = "N" Then
            '        reelPrint.CurrNumber = Int(RecTable("QTY").ToString)
            '        RecTable.Close()
            '        Sqlstr = "UPDATE W_PRINTSTYLE_T SET STATUS='Y',HISTORY_USER='" & SysMessageClass.UseId.ToLower & "',HISTORY_TIME=getdate() WHERE STYLEFORMAT='" & reelPrint.StyleID & "'"
            '        Conn.ExecSql(Sqlstr)
            '    Else
            '        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '        Return False
            '    End If
            'Else
            '    reelPrint.CurrNumber = 0
            '    RecTable.Close()
            '    Sqlstr = "INSERT INTO W_PRINTSTYLE_T(MATERIAL_ID, STYLEFORMAT, SYEAR, SMONTH, SDAYS, QTY, STATUS, HISTORY_USER) VALUES('" & reelPrint.MaterialNO & "','" & reelPrint.StyleID & "','" & reelPrint.Years & "','" & reelPrint.Month & "','" & reelPrint.Days & "',0,'Y','" & SysMessageClass.UseId.ToLower & "')"
            '    Conn.ExecSql(Sqlstr)
            'End If

            'If (CDbl(reelPrint.MantissaPackingQty) > 0) Then
            '    reelPrint.MantissaStyleID = MakeStyle(reelPrint.MantissaPackingQty) '產生樣式
            '    Sqlstr = "SELECT STYLEFORMAT,QTY,STATUS from W_PRINTSTYLE_T WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID.ToString & "'"
            '    Dim MantissaRecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

            '    If MantissaRecTable.Read Then
            '        If MantissaRecTable.GetString(MantissaRecTable.GetOrdinal("STATUS")) = "N" Then
            '            reelPrint.MantissaCurrNumber = Int(MantissaRecTable("QTY").ToString)
            '            MantissaRecTable.Close()
            '            Sqlstr = "UPDATE W_PRINTSTYLE_T set STATUS='Y',HISTORY_USER='" & SysMessageClass.UseId.ToLower & "',HISTORY_TIME=getdate() WHERE STYLEFORMAT='" & reelPrint.MantissaStyleID & "'"
            '            Conn.ExecSql(Sqlstr)
            '        Else
            '            MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '            Return False
            '        End If
            '    Else
            '        reelPrint.MantissaCurrNumber = 0
            '        MantissaRecTable.Close()
            '        Sqlstr = "INSERT INTO W_PRINTSTYLE_T(MATERIAL_ID, STYLEFORMAT, SYEAR, SMONTH, SDAYS, QTY, STATUS, HISTORY_USER) VALUES('" & reelPrint.MaterialNO & "','" & reelPrint.MantissaStyleID & "','" & reelPrint.Years & "','" & reelPrint.Month & "'," & reelPrint.Days & ",0,'Y','" & SysMessageClass.UseId.ToLower & "')"
            '        Conn.ExecSql(Sqlstr)
            '    End If
            'End If

            '  Conn = Nothing
            Return True
        Catch ex As Exception
            ' Conn = Nothing
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

    Private Sub dgvMotherBarList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMotherBarList.CellContentClick

        If Me.dgvMotherBarList.Rows.Count < 0 Then Exit Sub

        If Me.dgvMotherBarList.CurrentRow Is Nothing Then Exit Sub

        GetChildBarPrintList(Me.dgvMotherBarList.CurrentRow.Cells("MotherBarCode").Value, Val(Me.dgvMotherBarList.CurrentRow.Cells("QTY").Value))

    End Sub

    Private Sub dgvMotherBarList_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMotherBarList.CellValueChanged

    End Sub

#Region "打印母工单条码"
    '打印母条码工单 关晓艳 2018/10/30
    Private Sub ToolPrintMother_Click(sender As Object, e As EventArgs) Handles ToolPrintMother.Click
        Try
            dgvMotherBarList.Enabled = False
            If dgvMotherBarList.RowCount > 0 Then
                If (CheckPrintMother(Me.dgvMotherBarList)) Then
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvMotherBarList.RowCount - 1
                        chkTemp = dgvMotherBarList.Rows(i).Cells("ChkSelectM")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            'PrintBarCodeMother(dgvMotherBarList.Rows(i), i + 1)
                            BuildSBarCodeMother(dgvMotherBarList.Rows(i))

                            Dim frm As FrmChildPrintMoNum = New FrmChildPrintMoNum
                            frm.motherMoid = dgvMotherBarList.Rows(i).Cells("Moid").Value.ToString
                            frm.motherBarcode = dgvMotherBarList.Rows(i).Cells("MotherBarCode").Value.ToString
                            frm.sqlStr = Sqlstr.ToString
                            frm.printerName = CboPrinter.Text.Trim
                            frm.ShowDialog()
                        End If
                    Next
                Else
                    dgvMotherBarList.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If
            dgvMotherBarList.Enabled = True
            GetMotherBarInfo()
        Catch ex As Exception
            dgvMotherBarList.Enabled = True
            SetMessage(ex.ToString())
        End Try
    End Sub
    '打印母条码前 配置 检查关晓艳 2018/10/30
    Private Function CheckPrintMother(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim num As Integer = 0   '判断选中几个母工单条码 多余1 返回false

        For I As Int16 = 0 To dgvMotherBarList.RowCount - 1
            chkTemp = dgvMotherBarList.Rows(I).Cells("ChkSelectM")

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                num = num + 1
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
            Return False
        End If

        If Me.CboPrinter.Text = String.Empty Then
            MessageUtils.ShowError("请先选择打印机!")
            Return False
        End If

        If num > 1 Then
            iSelect = False
            SetMessage("请选择一行打印项目，不要选择多行!")
            Return False
        End If
        Return iSelect
    End Function
    '打印母条码工单 写入txt文本 关晓艳 2018/10/30
    Private Sub BuildSBarCodeMother(ByVal PrintData As DataGridViewRow)
        Try
            Sqlstr.Remove(0, Sqlstr.Length)
            Dim strNumber As String
            Dim o_strTmpChildBar As String
            Dim TxtFileStr As New StringBuilder

            '生成数据库脚本
            Dim chkTemp As DataGridViewCheckBoxCell
            For i As Int16 = 0 To Me.dgvMotherBarList.RowCount - 1
                chkTemp = dgvMotherBarList.Rows(i).Cells("ChkSelectM")
                If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                    '  o_strTmpChildBar = dgvMotherBarList.Rows(i).Cells("MotherBarCode").Value.ToString
                    o_strTmpChildBar = dgvMotherBarList.Rows(i).Cells("Moid").Value.ToString

                    '生成打印Text
                    If i = 0 Then
                        TxtFileStr.Append("""" & o_strTmpChildBar & """")
                    Else
                        TxtFileStr.Append(vbNewLine & """" & o_strTmpChildBar & """")
                    End If

                End If
            Next

            '写入打印Text
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            Sqlstr.Append("UPDATE m_SnSBarCode_t SET UseY ='Y' WHERE SBarCode='" & o_strTmpChildBar & "'")

            ''打印
            'If (Not String.IsNullOrEmpty(Sqlstr.ToString)) Then
            '    DbOperateUtils.ExecSQL(Sqlstr.ToString)

            '    FileToBarCodePrint(pFilePath, CboPrinter.Text)
            'End If
        Catch ex As Exception
            SetMessage("打印失败，请联系开发人员!")
        End Try
    End Sub
#End Region
End Class
