
'--华为栈板打印
'--Create by :(田玉琳)
'--Create date :　2017/09/06
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports BarCodePrint.SqlClassM
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports MainFrame

#End Region

Public Class FrmPalletPrint

#Region "属性字段"
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()
    Dim pFilePath As String = Nothing
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim numbers As ArrayList = New ArrayList()
#End Region

#Region "窗体事件"
    Private Sub FrmPalletPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btApp = New BarTender.ApplicationClass
        SqlClassM.GetPrintersList(CboPrinters)
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName '取得默认的打印
        CboPrinters.Text = sDefaultPrinter

        DtStar.Value = Now().AddDays(-7).ToString("yyyy-MM-dd")
        DtEnd.Value = Now().ToString("yyyy-MM-dd")
        LoadD.CurrMoid = "HWMOID"
    End Sub


    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        If Check() = False Then
            Exit Sub
        End If
        '取得打印数据
        Dim dt As DataTable = GetPrintData()

        If dt.Rows.Count > 0 Then
            Me.dgvPrintList.Rows.Clear()
            For i As Int16 = 0 To dt.Rows.Count - 1
                Dim defaultSelected As Boolean = False
                'HW单，栈板号，栈板数量，华为料号，申请人员，申请时间
                Me.dgvPrintList.Rows.Add(defaultSelected, dt.Rows(i)!HWShippingNO.ToString, dt.Rows(i)!PallteID.ToString,
                                         dt.Rows(i)!QTY.ToString, dt.Rows(i)!Partid.ToString, dt.Rows(i)!userName.ToString, dt.Rows(i)!Intime.ToString)
            Next
        End If

    End Sub

    Private Function GetPrintData() As DataTable
        Dim strOrder As String = " ORDER BY CONVERT(varchar(100), whd2.intime, 112) DESC "
        Dim strSQL As String =
            "   SELECT DISTINCT WHD.HWShippingNO,PallteID = WHD.PallteID, QTY = WHD.Qty, whm.Partid, " &
            "        (select userName FROM dbo.m_Users_t WHERE USERid = whd2.userId) userName,Intime=CONVERT(varchar(100), whd2.intime, 112)" &
            "   FROM (SELECT  Outwhid,PallteID,HWShippingNO,sum(CartonOutqty)Qty FROM m_WhOutD_t GROUP BY Outwhid,PallteID,HWShippingNO)  WHD" &
            "   INNER JOIN m_WhOutM_t(NOLOCK)  WHM ON WHD.Outwhid = WHM.Outwhid" &
            "   LEFT JOIN m_WhOutD_t(NOLOCK) WHD2 ON WHD2.Outwhid = WHM.Outwhid  AND whd.PallteID = whd2.PallteID" &
            "   LEFT JOIN m_Cartonsn_t(NOLOCK) CTS ON CTS.Cartonid=WHD2.CartonID" &
            "	LEFT JOIN m_Carton_t(NOLOCK) CT ON CT.Cartonid=WHD2.CartonID" &
            "	LEFT JOIN m_Mainmo_t(NOLOCK) MM ON MM.Moid=CT.Moid " &
            "   WHERE ISNULL(WHD.PallteID,'') <> '' "
        Dim strWhere As New StringBuilder
        strWhere.Append(GetSQLWhere(txtHWShippingNO, "WHD.HWShippingNO"))
        strWhere.Append(GetSQLWhere(txtPalletNo, "WHD.PallteID"))
        strWhere.Append(GetSQLWhere(txtHWPartId, "WHM.Partid"))
        strWhere.Append(GetSQLWhere(txtLXCartonId, "WHD2.CartonID"))

        strWhere.Append(" AND WHD2.Intime BETWEEN '" & Me.DtStar.Text & "' AND '" & Me.DtEnd.Text & "' ")
        strSQL = strSQL + strWhere.ToString + strOrder


        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

    Private Function GetSQLWhere(textId As TextBox, dbName As String) As String
        Dim strWhere As String = ""
        If String.IsNullOrEmpty(textId.Text.Trim) = False Then
            strWhere = String.Format(" AND {0} LIKE '%{1}%'", dbName, textId.Text.Trim)
        End If
        GetSQLWhere = strWhere
    End Function

    '条码打印
    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)
        Dim makedate As String = String.Empty
        Dim SqlStr As New StringBuilder
        Dim SBarcode As String = String.Empty
        Dim DefaultLine As String = "WMS"
        Dim qtys As String
        numbers.Clear()

        Me.Cursor = Cursors.WaitCursor
        Try
            If InputCheck() = True Then
                Dim chkTemp As DataGridViewCheckBoxCell

                For i As Int16 = 0 To dgvPrintList.Rows.Count - 1

                    chkTemp = dgvPrintList.Rows(i).Cells("Chk")
                    If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                        SBarcode = dgvPrintList.Rows(i).Cells(PallteID.Name).Value.ToString
                        numbers.Add(SBarcode)
                        LoadD.CurrAVCPartID = dgvPrintList.Rows(i).Cells(Partid.Name).Value.ToString
                        qtys = dgvPrintList.Rows(i).Cells(QTY.Name).Value.ToString
                        CModlePrintGenRecord(SBarcode, LoadD.CurrAVCPartID, qtys)
                        If pFilePath Is Nothing OrElse String.IsNullOrEmpty(pFilePath) Then
                            GetCodeRuleID()
                        End If
                    End If
                Next
                '检查栈板是否打印过
                Dim SQL As String
                For i As Int16 = 0 To numbers.Count - 1
                    SQL = "SELECT PallteID FROM  m_WhOutD_t  WHERE PallteID ='" + numbers(i) + "'and PrintStatus = 'Y'"
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
                    If dt.Rows.Count >= 1 Then
                        Me.lbMsg.Text = dt.Rows(0)(0).ToString() + "栈板已打印，不允许重复打印"
                        Return
                    End If

                Next

                BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)

                SqlStr.Append(vbNewLine & BarValueStr.ToString())
                If SqlStr.ToString() <> "" Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                    FileToBarCodePrint(pFilePath, Me.CboPrinters.Text.Trim)
                    '更新栈板打印状态
                    Dim strsql As String
                    For i As Int16 = 0 To numbers.Count - 1
                        strsql += "UPDATE m_WhOutD_t SET PrintStatus = 'Y' WHERE PallteID = '" + numbers(i) + "' "
                    Next
                    DbOperateUtils.GetDataTable(strsql)
                End If
                Me.lbMsg.Text = ""
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPalletPrint", "toolPrint_Click", "sys")
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    '整箱称重
    Public Sub PrintFullCartonWeight(CartonBarcode As String, pallateqty As String)
        Dim moid As String
        Dim partId As String
        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim Weight As String = ""

        Try
            '检查栈板是否打印过
            Dim SQL As String

            SQL = "SELECT PallteID FROM  m_WhOutD_t  WHERE PallteID ='" + CartonBarcode + "'and PrintStatus = 'Y'"
            Dim dt1 As DataTable = DbOperateUtils.GetDataTable(SQL)
            If dt1.Rows.Count >= 1 Then
                Me.lbMsg.Text = dt1.Rows(0)(0).ToString() + "栈板已打印，不允许重复打印"
                Return
            End If


            'Dim sqlstr As String =
            '    " SELECT b.CARTONID,a.CartonOutqty FROM m_WhOutD_t a LEFT JOIN m_PalletCarton_t b on b.PalletID=LEFT(a.Cartonid, 25) WHERE a.PallteID='" & CartonBarcode & "'  "
            Dim sqlstr As String =
                "SELECT CARTONID,CartonOutqty FROM ( SELECT b.CARTONID,a.CartonOutqty FROM m_WhOutD_t a LEFT JOIN m_PalletCarton_t b on b.PalletID=a.Cartonid WHERE a.PallteID='" & CartonBarcode & "' UNION SELECT b.CARTONID,a.CartonOutqty FROM m_WhOutD_t a LEFT JOIN m_Carton_t b on b.CARTONID=a.Cartonid WHERE a.PallteID='" & CartonBarcode & "' )C WHERE CARTONID IS NOT NULL "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrCommonOther As New StringBuilder
            'Dim titlestrCommon As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            TxtFileStrCommon.Append("""" & pallateqty & """" & ",")
            titlestr.Append("""lable10"",")

            If dt.Rows.Count > 0 Then
                scanQty = dt.Rows.Count
                cartonQty = CInt(pallateqty / dt.Rows(0)!CartonOutqty.ToString)
                pageQty = CInt(cartonQty / 1)
            End If



            TxtFileStr.Append(TxtFileStrCommon)


            Dim col As Integer = 15
            For iCnt As Integer = 1 To pageQty
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next


            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0

                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!CARTONID.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next

            'add by hgd 20200313 如果是尾数箱，则填补剩余空格
            If CInt(scanQty) < pageQty Then
                Dim itemQty As Integer
                itemQty = pageQty - CInt(scanQty)
                For iCnt As Integer = 0 To itemQty - 1
                    TxtFileStr.Append("""" & "" & """" & ",")
                Next
            End If
            'ADD by  hgd  20200306
            If Not String.IsNullOrEmpty(TxtFileStrCommonOther.ToString) Then
                TxtFileStr.Append("""" & "" & """" & ",")
                TxtFileStr.Append(TxtFileStrCommonOther)   'ADD by 20200306 hgd
            End If


            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Return
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, Me.CboPrinters.Text.Trim)
            DbOperateUtils.GetDataTable("UPDATE m_WhOutD_t SET PrintStatus = 'Y' WHERE PallteID = '" + CartonBarcode + "' ")
            DbOperateUtils.GetDataTable("UPDATE m_PalletMLot_t SET PalletStatus = 'Y' WHERE PalletID = '" + CartonBarcode + "' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("Chk").Value = Me.chkSelect.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "chkSelect_CheckedChanged", "sys")
        End Try
    End Sub


    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    ' 解锁栈板打印
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles toolRePrint.Click
        Dim SqlStr As New StringBuilder
        Dim SBarcode As String = String.Empty
        Dim chkPalletId As String
        Dim chkPalletList As New ArrayList

        Try
            Dim chkTemp As DataGridViewCheckBoxCell

            For i As Int16 = 0 To dgvPrintList.Rows.Count - 1
                chkTemp = dgvPrintList.Rows(i).Cells("Chk")
                If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                    SBarcode = dgvPrintList.Rows(i).Cells(PallteID.Name).Value.ToString
                    chkPalletList.Add(SBarcode)
                End If
            Next

            '每次操作只允许解锁一个栈板
            If chkPalletList.Count <> 1 Then
                Me.lbMsg.Text = "请选择一个栈板"
                Return
            End If
            chkPalletId = chkPalletList(0).ToString()

            '检查栈板是否打印过
            Dim SQL = "SELECT PallteID FROM  m_WhOutD_t  WHERE PallteID ='" + chkPalletId + "'and PrintStatus = 'Y'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
            If dt.Rows.Count = 0 Then
                Me.lbMsg.Text = "栈板没有打印，不需要解锁打印"
                Return
            End If

            If MessageUtils.ShowConfirm("确定要解锁栈板【" & chkPalletId & "】打印吗？", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                '更新栈板打印状态
                Dim strSql = "UPDATE m_WhOutD_t SET PrintStatus = 'N' WHERE PallteID = '" + chkPalletId + "' " &
                String.Format(" INSERT INTO m_BarcodeExch_t (Oldbarcode,Newbarcode,Moid,Userid,Intime)VALUES('{0}','{1}',N'{2}','{3}',GETDATE())", chkPalletId, chkPalletId, "栈板解锁", VbCommClass.VbCommClass.UseId)
                DbOperateUtils.GetDataTable(strSql)
                Me.lbMsg.Text = "栈板【" & chkPalletId & "】已解锁"
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPalletPrint", "toolPrint_Click", "sys")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "方法函数"

    Private Function InputCheck() As Boolean
        Dim bFlag As Boolean = False

        If (String.IsNullOrEmpty(Me.CboPrinters.Text.Trim)) Then
            Me.lbMsg.Text = "请选择打印机!"
            Me.CboPrinters.Focus()
            Return bFlag
        End If

        Dim chkTemp As DataGridViewCheckBoxCell
        For i As Int16 = 0 To dgvPrintList.Rows.Count - 1
            chkTemp = dgvPrintList.Rows(i).Cells("Chk")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                bFlag = True
            End If
        Next
        If bFlag = False Then
            Me.lbMsg.Text = "请选择要打印数据!"
            Return bFlag
        End If

        Return bFlag
    End Function

    '查询检查 
    Private Function Check() As Boolean

        'mark by cq 20171201
        'If String.IsNullOrEmpty(txtHWShippingNO.Text.Trim) = True And
        '    String.IsNullOrEmpty(txtPalletNo.Text.Trim) = True And
        '    String.IsNullOrEmpty(txtHWPartId.Text.Trim) = True And
        '    String.IsNullOrEmpty(txtLXCartonId.Text.Trim) = True Then
        '    Me.lbMsg.Text = "请选择至少输入一个查询条件！"
        '    Return False
        'End If

        If Not CheckDate(DtStar, DtEnd) Then Exit Function

        Return True
    End Function

    Private Function CheckDate(ByVal starDT As DateTimePicker, ByVal endDT As DateTimePicker, _
                                   Optional ByVal checkt As Boolean = True, Optional ByVal months As Integer = 2)
        If starDT.Value > endDT.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            endDT.Value = Now()
            Return False
        End If

        If starDT.Value < "2007-01-01" Then
            MsgBox("起始時間不能小於2007-01-01!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        If checkt Then
            Dim startDate As DateTime = DateTime.Parse(starDT.Text)
            Dim endDate As DateTime = DateTime.Parse(endDT.Text)
            If startDate.AddMonths(months) < endDate Then
                MsgBox("查询时间相隔最多请不要超过" & months.ToString & "个月", 48, "提示")
                starDT.Value = DateAdd(DateInterval.Month, -1, endDate)
                Return False
            End If
        Else
            Return True
        End If
        Return True
    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub CModlePrintGenRecord(ByVal snbarcode As String, ByVal partId As String, qty As String)

        Dim FixStr As String = ""

        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & snbarcode & "' and PackId = 'P' ) " & _
                    " begin INSERT INTO m_BarRecordValue_t" &
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                      ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                      ",[label23],[label24]) " & _
                      "VALUES('P','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            nPrintStr.Append(snbarcode)
            nPrintStr.Append(vbNewLine & partId)
            nPrintStr.Append(vbNewLine & qty)

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray
                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If
                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'') end"
            BarValueStr.Append(SpaceStr)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '获取编码原则
    Private Sub GetCodeRuleID()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append(" select  distinct A.CodeRuleID,a.PFormatID,b.TemplatePath from m_PartPack_t a  inner join ")
            o_strSql.Append(" M_SnMFormat_t b on b.PFormatID=a.PFormatID where a.Packid='P'and a.Usey='Y'  and a.Partid='" & LoadD.CurrAVCPartID & "' ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                LoadD.StyleID = dt.Rows(0)!CodeRuleID.ToString
                Me.pFilePath = dt.Rows(0)!TemplatePath.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPalletPrint", "GetCodeRuleID()", "sys")
        End Try
    End Sub

    '打印
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub toolOPPOPrint_Click(sender As Object, e As EventArgs) Handles toolOPPOPrint.Click
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)
        Dim makedate As String = String.Empty
        Dim SqlStr As New StringBuilder
        Dim SBarcode As String = String.Empty
        Dim DefaultLine As String = "WMS"
        Dim qtys As String
        numbers.Clear()

        Me.Cursor = Cursors.WaitCursor
        Try
            If InputCheck() = True Then


                Dim chkTemp As DataGridViewCheckBoxCell

                For i As Int16 = 0 To dgvPrintList.Rows.Count - 1

                    chkTemp = dgvPrintList.Rows(i).Cells("Chk")
                    If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                        SBarcode = dgvPrintList.Rows(i).Cells(PallteID.Name).Value.ToString
                        LoadD.CurrAVCPartID = dgvPrintList.Rows(i).Cells(Partid.Name).Value.ToString
                        qtys = dgvPrintList.Rows(i).Cells(QTY.Name).Value.ToString
                        If pFilePath Is Nothing OrElse String.IsNullOrEmpty(pFilePath) Then
                            GetCodeRuleID()
                        End If 
                        PrintFullCartonWeight(SBarcode, qtys) 
                    End If
                Next

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPalletPrint", "toolPrint_Click", "sys")
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region


End Class