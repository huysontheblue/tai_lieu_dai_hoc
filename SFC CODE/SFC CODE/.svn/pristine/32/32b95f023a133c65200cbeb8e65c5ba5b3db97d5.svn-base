Imports MainFrame
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Text

'--批次条码打印作业
'--Create by :　田玉琳
'--Create date :　2016/01/28
'--Update date :  
'--Update by :
'--Ver : V01
Public Class FrmLotPrint

    '打印模板文件/ 存放路径：\\192.168.20.123\PrintFile2
    Private BartenderFile As String = "LotPrint\LotBarCode.btw"

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmLotPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次

        DtStar.Value = Now().AddDays(-7).ToString("yyyy-MM-dd")
        DtEnd.Value = Now().ToString("yyyy-MM-dd")

        'SqlClassM.GetPrintersList(CboPrinter)
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            BindGrid()
        Catch ex As Exception
            SetMessage(ex.Message.ToString())
            SysMessageClass.WriteErrLog(ex, "BarCodePrint", "toolQuery_Click", "sys")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolPrint_Click(sender As Object, e As EventArgs) Handles ToolPrint.Click
        Try
            dgvPrintList.Enabled = False
            lblInfo.Text = ""
            Me.Cursor = Cursors.WaitCursor
            PrintData()
        Catch ex As Exception
            SetMessage(ex.Message.ToString)
            SysMessageClass.WriteErrLog(ex, "BarCodePrint_FrmLotPrint", "toolQuery_Click", "sys")
        Finally
            Me.Cursor = Cursors.Default
            dgvPrintList.Enabled = True
        End Try
    End Sub

    ''' <summary>
    ''' 退出 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '邦定打印数据
    Private Sub BindGrid()
        Try

            chbPrintListSelect.Checked = True

            lblInfo.Text = String.Empty
            Dim strWhere As String = String.Empty

            Dim cmbTmp As DataGridViewComboBoxColumn
            'Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("colPrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            If String.IsNullOrEmpty(txtMultiMO.Text) Then
                strWhere = String.Format(" AND A.Createtime  BETWEEN '{0}' AND '{1}'", DtStar.Value.ToShortDateString, DtEnd.Value.ToShortDateString)
            Else
                strWhere = String.Format(" AND A.Moid in ({0})", GetMoidList())
            End If

            Dim strSQL As String =
            " SELECT TOP {0} A.MOID, " &
            " A.PartID," &
            " B.dqc," &
            " A.Lineid," &
            " A.Moqty," &
            " ISNULL(COUNT(C.SBarCode),0) AlreayPrtTimes," &
            " ISNULL(SUM(C.Qty),0) AlreayPrtQty," &
            " CASE" &
            "   WHEN A.Moqty<=ISNULL(SUM(C.QTY),0) THEN 0 " &
            "   ELSE A.Moqty-ISNULL(SUM(C.QTY),0)" &
            " END PrtQty, " &
            " GETDATE() MakeDate" &
            " FROM m_Mainmo_t A" &
            " LEFT JOIN m_Dept_t B ON A.Deptid=B.deptid" &
            " LEFT JOIN m_snsbarcode_t C ON A.Moid=C.Moid" &
            " WHERE 1=1" &
            strWhere &
            " GROUP BY A.Moid, " &
            "          A.PartID, " &
            "          B.dqc," &
            "          A.Lineid," &
            "          A.Moqty "
            '只显示前1000条打印数据
            strSQL = String.Format(strSQL, 50)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            dgvPrintList.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dgvPrintList.Rows.Add(True, dr("MOID").ToString, dr("PartID").ToString, dr("dqc").ToString, dr("Lineid").ToString,
                                      dr("Moqty").ToString, dr("AlreayPrtTimes").ToString, dr("AlreayPrtQty").ToString, "",
                                      "", dr("PrtQty").ToString, dr("MakeDate").ToString)
            Next
            Me.ToolLblCount.Text = Me.dgvPrintList.Rows.Count

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '取得工单条件LiST
    Private Function GetMoidList() As String
        Dim m_strMultiMO As String = ""
        Dim o_strErrMOList As String = String.Empty
        If Me.txtMultiMO.Lines.Length > 0 Then
            For i As Integer = 0 To Me.txtMultiMO.Lines.Length - 1
                If Not Me.txtMultiMO.Lines(i).ToString.Trim = "" Then
                    If Not CheckIsMO(Me.txtMultiMO.Lines(i).ToString.Trim) Then
                        o_strErrMOList &= IIf(o_strErrMOList.Equals(String.Empty), "", ",") + Me.txtMultiMO.Lines(i).ToString.Trim
                        SetMessage("工单: " & o_strErrMOList & " 不存在")
                        Continue For
                    End If
                    m_strMultiMO = m_strMultiMO + Me.txtMultiMO.Lines(i).ToString.Trim + "','"
                End If
            Next
            If m_strMultiMO.Length > 0 Then m_strMultiMO = "'" + m_strMultiMO.Substring(0, m_strMultiMO.Length - 2)
        End If
        '为空时，给初始值
        If m_strMultiMO = "" Then
            m_strMultiMO = "''"
        End If

        Return m_strMultiMO
    End Function

    '检查工单存在性
    Private Function CheckIsMO(ByVal parMO As String) As Boolean
        Dim lsSQL As String = String.Empty
        Try
            lsSQL = " SELECT MOID FROM m_MainMO_t WHERE  MOID='" & parMO & "'"
            If DbOperateUtils.GetRowsCount(lsSQL) > 0 Then
                CheckIsMO = True
            Else
                CheckIsMO = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return CheckIsMO
    End Function

    '设置错误信息
    Private Sub SetMessage(ByVal Message As String)
        Me.lblInfo.Text = Message
    End Sub

    '打印
    Private Sub PrintData()
        Try
            'dgvPrintList.Enabled = False
            If dgvPrintList.RowCount > 0 Then
                If (CheckPrint(Me.dgvPrintList)) Then
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            If (PrintBarCode(dgvPrintList.Rows(i)) = False) Then
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    'dgvPrintList.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If
            'dgvPrintList.Enabled = True

            BindGrid()
        Catch ex As Exception
            'dgvPrintList.Enabled = True
            lblInfo.Text = ex.Message
            Throw ex
        End Try
    End Sub

    Private Function CheckStyle(styleSSS As String, partid As String)

        Dim Sqlstr As String = "select StyleID,MaxInt,MaxSN,ISNULL(IsUsed,'N')IsUsed from m_SnStyle_t where StyleID='{0}'"
        Sqlstr = String.Format(Sqlstr, styleSSS)
        Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            If RecTable.Rows.Count > 0 Then
                If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                    Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & styleSSS & "'"
                    DbOperateUtils.ExecSQL(Sqlstr)
                Else
                    SetMessage("此工單正在打印中!")
                    Return False
                End If
            Else
                Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & styleSSS & "','" & partid & "','" & "L001" & "','" & styleSSS & "',0,'0','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                DbOperateUtils.ExecSQL(Sqlstr)
            End If
        End Using
        Return True
    End Function


    '保存打印数据
    Private Function PrintBarCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim styleID As String = ""
        Try
            Dim strBSQL As New System.Text.StringBuilder

            Dim dt As DataTable = Nothing
            Dim partID As String = PrintData.Cells("colPartID").Value.ToString
            Dim moid As String = PrintData.Cells("colMOID").Value.ToString
            Dim line As String = PrintData.Cells("colLINEID").Value.ToString
            Dim makedate As String = CDate(PrintData.Cells("colMakedate").Value).ToString("yyyyMMdd")
            Dim moidQtys As String = PrintData.Cells("colMoidQtys").Value.ToString
            Dim printName As String = PrintData.Cells("colPrinterName").Value.ToString

            Dim lotQty As Integer = 0
            Dim OneLotQty As Integer = CLng(PrintData.Cells("colOneLotQty").Value.ToString)
            Dim PrintQtys As Integer = CLng(PrintData.Cells("colPrintQtys").Value.ToString)

            Dim pCnt As Integer = PrintQtys \ OneLotQty
            Dim pRemainQty As Integer = PrintQtys Mod OneLotQty
            If pRemainQty <> 0 Then '不为零加入尾箱
                pCnt = pCnt + 1
            End If

            Dim barCode As String
            styleID = String.Format("L{0}*****", makedate)
            If CheckStyle(styleID, partID) = False Then
                  Return False
            End If

            Dim barCodeList As DataTable
            Dim barFile As StringBuilder = New StringBuilder
            barCodeList = GetNewBarCode(makedate, pCnt)
            If barCodeList Is Nothing Then
                Return False
            End If

            Dim strSQL As String = "INSERT INTO m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,PackingLevel)"

            For iIndex As Integer = 1 To pCnt
                barCode = barCodeList.Rows(iIndex - 1)(0).ToString
                strBSQL.Append(strSQL)
                strBSQL.Append(" VALUES(")
                strBSQL.AppendFormat("N'{0}',", barCode)
                strBSQL.AppendFormat("N'{0}',", moid)
                strBSQL.AppendFormat("N'{0}',", line)
                strBSQL.AppendFormat("N'{0}',", "L")
                If iIndex = pCnt And pRemainQty <> 0 Then '最后一箱数量为余数
                    lotQty = pRemainQty
                Else
                    lotQty = OneLotQty
                End If
                strBSQL.AppendFormat("N'{0}',", lotQty)
                strBSQL.AppendFormat("N'{0}',", "Y")
                strBSQL.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                strBSQL.AppendFormat("getdate(),")
                strBSQL.AppendFormat("N'{0}',", makedate)
                strBSQL.AppendFormat("N'{0}',", BartenderFile)
                strBSQL.AppendFormat("1,")
                strBSQL.AppendFormat("0")
                strBSQL.Append(");" & vbNewLine)

                LotPrint.GetPrintDataContent(barFile, moid, partID, barCode, makedate, moidQtys, lotQty)

            Next
            '保存生成的批次条码记录
            DbOperateUtils.ExecSQL(strBSQL.ToString)

            Dim templateFilePath As String = VbCommClass.VbCommClass.PrintDataModle + BartenderFile

            LotPrint.FileToBarCodePrint(templateFilePath, barFile, printName)
        Catch ex As Exception
            Throw ex
        Finally
            CheckAllowUnLock(styleID)
        End Try
    End Function

    '取得维护 维护有工艺流程数据
    Private Function GetPartStationD(partId As String) As Boolean
        Dim strSQL As String =
            " SELECT TOP 1 1" &
            " FROM m_RPartStationD_t" &
            " WHERE ppartid='{0}'" &
            " AND tpartid=ppartid" &
            " AND STATE='1'"
        strSQL = String.Format(strSQL, partId)

        'If chkNoScan.Checked Then
        '    Dim strWhere As String =
        '      " AND STATIONID IN  (SELECT STATIONID FROM m_Rstation_t WHERE ScanY='N')" &
        '      " AND Stationid NOT IN (SELECT TestTypeID  FROM MESDataCenter.DBO.m_TestType_t)"
        '    strSQL = strSQL + strWhere
        'End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function

    '自动生成单据编号
    Private Function GetNewBarCode(dd As String, cnt As Integer) As DataTable
        Dim strSQL As String = " exec [GetLotPrintID] '{0}','{1}','{2}' "
        strSQL = String.Format(strSQL, dd, cnt, VbCommClass.VbCommClass.UseId)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            lblInfo.Text = "系统在自动生成条码时,发生错误..."
            GetNewBarCode = Nothing
            Exit Function
        End If
        GetNewBarCode = dt
    End Function

    '检查打印数据
    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '单批次量
                If Not IsNumeric(dgvPrintList.Rows(I).Cells("colOneLotQty").Value) Then
                    SetMessage("第" + (I + 1).ToString + "行输入单批次量有误！")
                    Return False
                    Exit For
                End If

                If CLng(dgvPrintList.Rows(I).Cells("colOneLotQty").Value) = 0 Then
                    SetMessage("第" + (I + 1).ToString + "行输入单批次量不能为<=0！")
                    Return False
                    Exit For
                End If

                '判断打印数量
                If Not IsNumeric(dgvPrintList.Rows(I).Cells("colPrintQtys").Value) Then
                    SetMessage("第" + (I + 1).ToString + "行输入打印数量有误！")
                    Return False
                    Exit For
                End If

                If CLng(dgvPrintList.Rows(I).Cells("colPrintQtys").Value) = 0 Then
                    SetMessage("第" + (I + 1).ToString + "行输入打印数量不能为<=0！")
                    Return False
                    Exit For
                End If

                '标签日期
                If String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("colMakedate").Value) Then
                    SetMessage("输入第" + (I + 1).ToString + "标签日期不能为空！")
                    Return False
                    Exit For
                End If

                '已打印+打印数量不能超过工单数量
                'If (CLng(dgvPrintList.Rows(I).Cells("colPrintQtys").Value) + CLng(dgvPrintList.Rows(I).Cells("colAlreayPrtQty").Value) >
                '    CLng(dgvPrintList.Rows(I).Cells("colMoidQtys").Value)) Then
                '    SetMessage("输入第" + (I + 1).ToString + "(已打印+打印数量)不能超过工单数量！")
                '    Return False
                '    Exit For
                'End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("colPrinterName").FormattedValue.ToString.Trim)) Then
                    SetMessage("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                    Return False
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvPrintList.Rows(I).Cells("colPrinterName").FormattedValue.ToString.Trim
                    If (ps.IsValid = False) Then
                        SetMessage("第" + (I + 1).ToString + "行打印机不可用，请检查!")
                        Return False
                        Exit For
                    End If
                End If

                Dim partId As String = dgvPrintList.Rows(I).Cells("colPartID").Value.ToString
                'If Not GetPartStationD(partId) Then
                '    SetMessage(String.Format("第{0}行料号{1}无相关工站需打印标签，请检查料件工艺流程设置!", (I + 1).ToString, partId))
                '    Return False
                '    Exit For
                'End If

                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
        End If
        Return iSelect
    End Function

    'GRID全选
    Private Sub chbPrintListSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    '检查是否可以强制解锁
    Private Function CheckAllowUnLock(ByVal StyleId As String) As Boolean
        Dim b As Boolean = True
        Dim sb As New StringBuilder
        Dim ds As New DataSet
        sb.Append(" SELECT * FROM m_SnStyle_t where StyleID='" & StyleId & "' and IsUsed='Y' and  DATEDIFF(MI,Intime,getdate())<=3 ;")
        ds = DbOperateUtils.GetDataSet(sb.ToString)
        If Not ds Is Nothing Then
            If Not ds.Tables(0) Is Nothing And ds.Tables(0).Rows.Count > 0 Then
                b = False
            End If
        End If
        Return b
    End Function

#Region "Grid行数"
    Private Sub dgvPrintList_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvPrintList.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class