
'--华3条码打印作业
'--Create by :　马锋
'--Create date :　2016/07/08
'--Update date :  
'--d
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


Public Class FrmH3Print

#Region "窗體變量"

    Dim LoadM As New BarCodePrint.SqlClassM
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim Sqlstr As New StringBuilder
    Dim CustPart As String          '客戶料號
    Dim opFlag As Int16 = 0
    Dim dvTiptopLot As New DataView
    Dim TemplateStatus As Boolean = False    '模板状态
    Dim BarCodePartTable As New DataTable
    Dim CurrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim PrtStrTable As New DataTable      '打印命令字符串
    Dim PrtArray As New MainFrame.SysCheckData.SysMessageClass.PrtStructure
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = ""
    Dim PrintPart(,) As String    '建立打印字符串來源信息數組
    Dim SBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim SBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串

    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()

    Dim MoidPrinted As Int64 = 0      '工單已打印數量
    Dim AxTempCode As New StringBuilder
    Dim LblTempCode As New StringBuilder
    Dim PrintCodeValue As StringBuilder '标签各元素的值
    Dim YMDCode As New StringBuilder

    Dim CurrSeriNo As String

    Dim DataType As String

    Dim strMOID As String
    ''***********************多流水码修改
    Dim IsmullitStyle As String = "N"
    Dim PubAtrributeStype As String = "" '附属条码的样式
    Dim CurrAtrrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim AtrrSBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim AtrrSBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim AtrrCode As String = ""
    Dim AtrrCodeLen As Int16 ''附属条码
    Dim AtrrAxTempCode As New StringBuilder
    Dim AtrrCurrSeriNo As String
    ''***********************多流水码修改
    Private m_strOrderNO As String = String.Empty
    Private m_strOrderSeq As String = String.Empty
    Private m_DeliveryDate As String = String.Empty
    Private m_ScheFinishDate As String = String.Empty

#Region "包装"
    Dim MoidAllNum As Int64 = 0         '工單批量
    Dim MoidLastNum As Int64            '工單尾數量
    Dim CtPrtingNum As Int64            '工單可打印箱數
    Dim PackMethod As Int16 = 0         '裝箱數量
    Dim Packlink As String = ""         '箱標簽類型
    Dim PackItems As String = ""         '条码类型
#End Region

#End Region

#Region "加载事件"

    Private Sub FrmH3Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btApp = New BarTender.ApplicationClass
        LoadControlData()
        Me.chbPrintListSelect.Checked = True
        Me.txtMOId.Focus()
    End Sub

    Private Sub FrmListPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

#End Region

#Region "工具事件"

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            GetLot()
            Me.txtPrintCount.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolTestPrinte_Click(sender As Object, e As EventArgs) Handles ToolTestPrinte.Click

    End Sub

    Private Sub ToolPrt_Click(sender As Object, e As EventArgs) Handles ToolPrt.Click
        Me.ToolPrt.Enabled = False
        Me.IsmullitStyle = "N"
        Try
            Me.lblMessage.Text = String.Empty
            If dgvPrintList.RowCount > 0 Then
                If (CheckPrint(Me.dgvPrintList)) Then
                    Dim index As Integer
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            PrintBarCode(dgvPrintList.Rows(i), i + 1)
                        End If
                    Next
                    If ChkNotPrint.Checked = False Then 'By 田玉琳 20151210 Update
                        index = dgvLotList.CurrentCell.RowIndex
                        DbOperateUtils.ExecSQL("UPDATE M_MAINMO_T SET CHECKTEXT=N'打印完成' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "'")
                    End If
                Else
                    Me.ToolPrt.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If

            GetLot()
        Catch ex As Exception
            SetMessage(ex.ToString())
        End Try
        Me.ToolPrt.Enabled = True
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvPrintList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrintList.CellEnter
        On Error Resume Next

        If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
            Exit Sub
        End If

        GetPrintItemParameter(Me.dgvPrintList.Item("Moid", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Me.dgvPrintList.Item("PartId", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Microsoft.VisualBasic.Left(Me.dgvPrintList.Item("lableType", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, 1), Me.dgvPrintList.Item("PackItem", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim)
    End Sub

    Private Sub dgvLotList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotList.CellEnter
        Try

            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                Exit Sub
            End If
            Me.txtPrintCount.Text = CInt(Me.dgvLotList.Item("ColQty", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim) - CInt(Me.dgvLotList.Item("Ppidprtqty", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)

            If (Me.ChkDemandTime.Checked) Then
                If (Not String.IsNullOrEmpty(Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)) Then
                    If (CheckDemand(Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)) Then
                        Me.LblPrintDate.Text = Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim
                        PrtArray.NowDate = CDate(Me.LblPrintDate.Text).ToString("yyyy-MM-dd").ToString
                        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text).ToString("MM").ToString
                        SetArrayLbl(PrtArray.ToArray)
                    End If
                End If
            End If

            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        Catch ex As Exception
            SetMessage("获取工单打印清单异常")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "dgvLotList_CellEnter", "sys")
        End Try
    End Sub

    Private Sub BnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnEdit.Click
        Try
            Dim FrmEditTime As New FrmEditTime
            FrmEditTime.ShowDialog()
            If SqlClassD.UpdateTime.ToString <> "" Then
                Me.LblPrintDate.Text = String.Format(CDate(SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                SqlClassD.UpdateTime = ""
                PrtArray.NowDate = CDate(Me.LblPrintDate.Text).ToString("yyyy-MM-dd").ToString
                PrtArray.NowMonth = CDate(Me.LblPrintDate.Text).ToString("MM").ToString
                SetArrayLbl(PrtArray.ToArray)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BnEdit_Click", "sys")
        End Try
    End Sub

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "chbPrintListSelect_CheckedChanged", "sys")
        End Try
    End Sub


#End Region

#Region "方法"

    Private Sub GetLot()
        Sqlstr.Remove(0, Sqlstr.Length)

        Sqlstr.Append(" SELECT Moid,PartID,Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, ")
        Sqlstr.Append(" m_Dept_t.DQC, m_Mainmo_t.Lineid,m_Mainmo_t.CHECKTEXT, CONVERT(VARCHAR(10),m_Mainmo_t.Plandate,120) AS Plandate, m_Customer_t.CusName, Createuser, Createtime, m_Mainmo_t.Remark, m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime ")
        Sqlstr.Append(" FROM m_Mainmo_t ")
        Sqlstr.Append(" INNER JOIN m_Customer_t ON m_Customer_t.CusID=m_Mainmo_t.Cusid AND m_Mainmo_t.Cusid='7K' ")
        Sqlstr.Append(" LEFT JOIN m_Dept_t ON m_Dept_t.deptid=m_Mainmo_t.Deptid ")
        Sqlstr.Append(" WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' ")
        Sqlstr.Append(" AND m_Mainmo_t.Moid=m_Mainmo_t.ParentMo and m_Mainmo_t.Createtime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)")

        If Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
            Sqlstr.Append(" and m_Mainmo_t.moid like '%" & Me.txtMOId.Text.ToString.Trim & "%'")
        End If

        If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
            Sqlstr.Append(" and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'")
        End If

        Sqlstr.Append(" ORDER BY m_Mainmo_t.Createtime DESC")

        LoadData(Sqlstr.ToString, Me.dgvLotList)
    End Sub

    Private Sub GetLotPrintList(ByVal strMOid As String, ByVal strPartId As String, ByVal strQty As String, ByVal QueryFlag As Boolean)
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" SELECT m_SnAssign_t.Ptaskid,m_Mainmo_t.Moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
        Sqlstr.Append(" m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_SnAssign_t.Packitem,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
        Sqlstr.Append(" m_Mainmo_t.Moqty AS Qty,m_SnAssign_t.PrtQty*ISNULL(m_SnAssign_t.ConfigurationQty,1) PrintQty, ISNULL(m_SnAssign_t.FinishPrintQty,0) AS FinishPrintQty,ISNULL(m_SnAssign_t.ConfigurationQty,1) AS ConfigurationQty, m_PartPack_t.PrinterName, ")
        Sqlstr.Append(" case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
        Sqlstr.Append(" m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
        Sqlstr.Append(" djmdc,shift,linejm,convert(varchar(10),m_SnAssign_t.Demandtime,120) as Demandtime,(FileVerNo + iif(isnull(m_SnAssign_t.Remark,'')='','','#'+ m_SnAssign_t.Remark ))FileVerNo ,m_PartPack_t.Remark,DriFlag,BuildAttribute, case m_SnAssign_t.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, m_Mainmo_t.PartID as applyPart ")
        Sqlstr.Append(" FROM m_Mainmo_t INNER JOIN m_SnAssign_t ON m_Mainmo_t.Moid= m_SnAssign_t.Moid ")
        Sqlstr.Append(" INNER JOIN m_PartContrast_t ON m_PartContrast_t.TAvcPart=m_Mainmo_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart ")
        Sqlstr.Append(" INNER JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
        Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND  m_PartPack_t.Packid=m_SnAssign_t.Packid AND m_PartPack_t.Packitem=m_SnAssign_t.Packitem")
        Sqlstr.Append(" LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
        Sqlstr.Append(" LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
        Sqlstr.Append(" LEFT JOIN m_Dept_t on m_Mainmo_t.Deptid=m_Dept_t.Deptid and m_Mainmo_t.factory=m_Dept_t.factoryid ")
        Sqlstr.Append(" LEFT JOIN Deptline_t on m_Dept_t.deptid=Deptline_t.deptid and m_SnAssign_t.lineid=Deptline_t.lineid ")
        Sqlstr.Append(" LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
        Sqlstr.Append(" WHERE m_Mainmo_t.ParentMo='" & strMOid & "' AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' ORDER BY m_PartContrast_t.TAvcPart ASC ")

        LoadData(Sqlstr.ToString, Me.dgvPrintList)
    End Sub

    Private Sub GetPrintItemParameter(ByVal strMOid As String, ByVal strPartId As String, ByVal strPackid As String, ByVal strPactItem As String)
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" select distinct a.F_codeID,c.F_codename,a.DValues ")
        Sqlstr.Append(" from m_SnPartSet_t as a  ")
        Sqlstr.Append(" join m_PartPack_t as b on a.partid=b.partid and a.Packid=b.Packid and a.Packitem=b.Packitem  ")
        Sqlstr.Append(" join m_SnRuleD_t as c on a.F_codeID=c.F_codeID and b.CodeRuleID=c.CodeRuleID  ")
        Sqlstr.Append(" where a.Partid='" & strPartId & "' and a.Packid='" & strPackid & "' and a.Packitem='" & strPactItem & "' order by a.F_codeID")
        LoadData(Sqlstr.ToString, Me.dgvRuleList)
    End Sub

    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("PrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            Do While DReader.Read()
                If dgvName Is Me.dgvLotList Then
                    dgvName.Rows.Add(DReader.Item("Moid").ToString, DReader.Item("Partid").ToString, DReader.Item("Moqty").ToString, DReader.Item("Ppidprtqty").ToString _
                    , DReader.Item("PpidprtCount").ToString, DReader.Item("Pkgprtqty").ToString, DReader.Item("Lineid").ToString, DReader.Item("CHECKTEXT").ToString, DReader.Item("DemandInfo").ToString, DReader.Item("Plandate").ToString _
                    , DReader.Item("DQC").ToString, DReader.Item("CusName").ToString, DReader.Item("demandTime").ToString, DReader.Item("Createuser").ToString, DReader.Item("Createtime").ToString, DReader.Item("Remark").ToString)
                ElseIf dgvName Is Me.dgvRuleList Then
                    dgvName.Rows.Add(DReader.Item("F_codeID").ToString, DReader.Item("F_codename").ToString, DReader.Item("DValues").ToString)
                ElseIf dgvName Is Me.dgvPrintList Then

                    'If (Not String.IsNullOrEmpty(DReader.Item("PrinterName").ToString)) Then
                    '    cmbTmp.ValueMember = DReader.Item("PrinterName").ToString
                    'Else
                    '    cmbTmp.ValueMember = -1
                    'End If

                    If (SqlClassM.CheckPrintersList(DReader.Item("PrinterName").ToString)) Then
                        PrintName = DReader.Item("PrinterName").ToString
                    Else
                        PrintName = ""
                    End If

                    If (Microsoft.VisualBasic.Left(DReader.Item("LabelType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Item("DisorderType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Item("DisorderType").ToString, 1) = "P") Then
                        If ((CInt(DReader.Item("PrintQTY").ToString) - CInt(DReader.Item("FinishPrintQty").ToString)) Mod CInt(DReader.Item("PackingQty").ToString) = 0) Then
                            FCLNumber = (CInt(DReader.Item("PrintQTY").ToString) - CInt(DReader.Item("FinishPrintQty").ToString)) / CInt(DReader.Item("PackingQty").ToString)
                            TrunkNumber = 0
                        Else
                            FCLNumber = (CInt(DReader.Item("PrintQTY").ToString) - CInt(DReader.Item("FinishPrintQty").ToString)) / CInt(DReader.Item("PackingQty").ToString)
                            TrunkNumber = 1
                        End If
                    Else
                        FCLNumber = 0
                        TrunkNumber = 0
                    End If

                    dgvName.Rows.Add(True, DReader.Item("Ptaskid").ToString, DReader.Item("Moid").ToString, DReader.Item("TAvcPart").ToString, DReader.Item("PAvcPart").ToString, DReader.Item("LabelType").ToString, DReader.Item("PackItem").ToString, DReader.Item("FileVerNo").ToString, DReader.Item("Remark").ToString, _
                    DReader.Item("Qty").ToString, DReader.Item("PrintQTY").ToString, DReader.Item("FinishPrintQty").ToString, DReader.Item("ConfigurationQty").ToString, PrintName, DReader.Item("PackingQty").ToString, FCLNumber, TrunkNumber, DReader.Item("KLabelid").ToString, DReader.Item("Description").ToString, DReader.Item("PrintStatus").ToString, DReader.Item("DisorderType").ToString, _
                    DReader.Item("djmdc").ToString, DReader.Item("shift").ToString, DReader.Item("linejm").ToString, DReader.Item("Demandtime").ToString, DReader.Item("DriFlag").ToString, DReader.Item("BuildAttribute").ToString, DReader.Item("Estateid").ToString, DReader.Item("PackingLevel").ToString, DReader.Item("applyPart").ToString)

                End If
            Loop
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex '出错
        End Try
    End Sub

    Private Sub SetArrayLbl(ByVal Array() As String)
        Dim I As Int16
        Try
            For I = 0 To BarCodePartTable.Rows.Count - 1
                If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                    If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
                        If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                        Else
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                        End If
                    Else
                        BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                    End If

                End If
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
                    BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim strTeskId As String
        Dim strMoid As String
        Dim strPackItem As String
        Dim strPackId As String
        Dim strDisorderType As String

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                strTeskId = dgvPrintList.Rows(I).Cells("PtaskId").Value.ToString
                strMoid = dgvPrintList.Rows(I).Cells("Moid").Value.ToString
                strPackId = Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString, 1)
                strDisorderType = dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString
                strPackItem = dgvPrintList.Rows(I).Cells("PackItem").Value.ToString

                '判断打印数量
                If Microsoft.VisualBasic.Left(Me.dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString, 1) = "S" Then
                    If Not IsNumeric(Me.txtPrintCount.Text.Trim) Then
                        SetMessage("输入打印数量有误！")
                        Return False
                        Exit For
                    End If
                    If (Int(Me.txtPrintCount.Text.Trim) > 1000) Then
                        SetMessage("产品条码一次打印數量限制在1-1000以內！")
                        Return False
                        Exit For
                    End If
                End If
                '检查打印数量
                'If (Not CheckPrintQty(strTeskId, strMoid, strPackId, strPackItem, strDisorderType)) Then
                '    SetMessage("请配置第" + (I + 1).ToString + "行打印数量超过工单数量!")
                '    Return False
                '    Exit For
                'End If

                '判断是否配置料件参数
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (I + 1).ToString + "行料件打印参数，并确保其他料件参数已经配置OK!")
                    Return False
                    Exit For
                End If
                '判断是否设置模板
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("LabelTemplates").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (I + 1).ToString + "行料件打印模板，并确保其他料件打印模板已经配置OK!")
                    Return False
                    Exit For
                End If
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim, 1) = "C") Then
                    If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PackingQty").Value.ToString.Trim) Or CInt(dgvPrintList.Rows(I).Cells("PackingQty").Value.ToString.Trim) <= 0) Then
                        SetMessage("请配置第" + (I + 1).ToString + "行包装容量，并确保其他包装打印料件包装容量已经配置OK!")
                        Return False
                        Exit For
                    End If
                End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PrinterName").EditedFormattedValue.ToString.Trim)) Then
                    SetMessage("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                    Return False
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvPrintList.Rows(I).Cells("PrinterName").EditedFormattedValue.ToString.Trim
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

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)

        If (Not PrintData Is Nothing) Then
            If InitializePrintParameter(PrintData) Then
                Exit Sub
            End If

            If (Microsoft.VisualBasic.Left(PrintData.Cells("Estateid").Value.ToString, 1) = "1") Then
                DbOperateUtils.ExecSQL("Update m_SnAssign_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            End If

            Select Case (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1))
                Case "A"
                    BuildABarCode(PrintData)
                Case "S", "K"
                    BuildSBarCode(PrintData) 'modify by paul 20150310 增加制程条码 K
                Case "C"
                    BuildCBarCode(PrintData)
                Case "P"

                Case "N"
                    BuildNBarCode(PrintData)
            End Select
        Else
            SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
        End If
    End Sub


#End Region

#Region "打印"

#Region "A附属条码"

    Private Sub BuildABarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If
            AMainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildABarCode", "sys")
        End Try
    End Sub

    Private Function AMainMarkSCode(ByVal PrintName As String, ByVal taskId As String) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '打印前準備工作
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            '
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼
            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                '生成打印指令
                If N = LoadD.PrintColNum Then
                    'PrintBarCode(UseY)
                    NModlePrintGenRecord("N", False, 0)
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    NModlePrintGenRecord("N", False, 0)
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            '插入數據庫並傳送打印指令到打印機
            'My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")      MakeStyle()
            Dim BarFlag As String = LoadD.StyleID
            SqlStr &= ControlChars.CrLf & ABarCodePrint(BarFlag, PrintStr.ToString)
            '新增条码记录到SnBarCode        " & Me.CboBarCodeType.Text.Trim.Split("-")(0) & "" & PrtArray.Qty & "
            SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & BarFlag.Replace("'", "''") & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & TextHandle.DeleteUnVisibleChar(AxTempCode.ToString.Replace("'", "''")) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "','1','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end "
            SqlStr &= " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'"

            If SqlStr <> "" Then
                Conn.ExecSql(SqlStr)
                FileToBarCodePrint(pFilePath, PrintName)
            End If
            Return True
        Catch ex As Exception
            Conn = Nothing
            Throw ex
        Finally
            Conn = Nothing
            LoadM.OpenLock(LoadD.StyleID.Trim.Replace("'", "''"))
        End Try
    End Function

    Private Function ABarCodePrint(ByVal BarFlag As String, ByVal PrintStr As String) As String

        Try

            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16 ''临时方法，建议直接获取数据库表字段，进行循环。
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag '' My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim Str As String() = PrintStr.Split(StrSplit, StringSplitOptions.RemoveEmptyEntries)

            Dim FixStr As String = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & printFlag.Replace("'", "''") & "')" & _
                       " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                       "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                       ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                       ",[label23],[label24]) " & _
                       "VALUES('A','" & printFlag.Replace("'", "''") & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"
            Dim BarValue As String()
            Dim SqlStr As New StringBuilder

            Dim SpaceStr As String
            Dim TxtFileStr As New StringBuilder
            'Dim BarRecord() As String = PrintStr.ToString.Split("~#") 30
            For k As Int16 = 0 To Str.Length - 1
                If (k = 0) Then
                    SqlStr.Append(FixStr)
                End If

                SpaceStr = ""
                BarValue = Str(k).ToString.Trim.Split(vbNewLine) ''
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1
                    'If BarValue(i).ToString.Replace(Chr(10), "").Trim = "" Then
                    '    Continue For
                    'End If

                    If (k = 0) Then
                        SqlStr.Append("," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "").Replace("'", "''")) & "'")
                    End If

                    If k = 0 Then
                        If i = 0 Then
                            TxtFileStr.Append("""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    Else
                        If i = 0 Then
                            TxtFileStr.Append(vbNewLine & """" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    End If
                Next

                'If k = Str.Length - 1 Then
                '    NoValueLenth = NoValueLenth - 1
                'End If

                If (k = 0) Then
                    'If LoadD.CurrPrintNum = 1 Then
                    '    NoValueLenth = NoValueLenth - 1
                    'End If
                    For j As Int16 = 1 To NoValueLenth - 1
                        SpaceStr = SpaceStr & "'',"
                    Next
                    SpaceStr = SpaceStr & "'') END"
                    SqlStr.Append("," & SpaceStr & vbNewLine)
                End If
            Next
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, Encoding.UTF8)
            ABarCodePrint = SqlStr.ToString
            'File.AppendAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try

    End Function

#End Region

#Region "产品流水码"

    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            ''********************************************************
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim Sqlstr As String = "select ISNULL(IsMultCode,'') IsMultCode from m_partpack_t a WITH(NOLOCK) join m_SnRuleM_t b WITH(NOLOCK) " & _
                " on a.CodeRuleID=b.CodeRuleID  where Partid='" & PrintData.Cells("PartId").Value.ToString() & "' and " & _
                " Packid='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' and a.Usey='Y'"
            Dim Mread As SqlDataReader = Conn.GetDataReader(Sqlstr)
            If Mread.HasRows Then
                While Mread.Read
                    IsmullitStyle = Mread!IsMultCode
                End While
            End If
            Mread.Close()
            Conn.PubConnection.Close()
            If IsmullitStyle = "Y" Then
                If CheckAtrrStyle() = False Then
                    Exit Sub
                End If
            End If
            ''********************************************************

            MainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildSBarCode", "sys")
        End Try
    End Sub

    Private Function MakeAtrributeStyle() As String
        Dim I As Integer
        Dim Flag As Boolean = False
        Dim TempView As DataView

        Dim BarCodeStyle As New StringBuilder
        AtrrAxTempCode.Remove(0, AtrrAxTempCode.Length)
        Try
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarCode2'"
            TempView.Sort = "f_orderid asc"
            '產生樣式
            For I = 0 To TempView.Count - 1
                If TempView.Item(I).Item("IsPrintStyle").ToString = "Y" Then
                    BarCodeStyle.Append(TempView.Item(I).Item("ShortName").ToString)
                    AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                Else
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                        AtrrCodeLen = AtrrAxTempCode.Length
                        Flag = True
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "Q" Then
                        AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                    Else
                        If TempView.Item(I).Item("ShortName").ToString.Trim <> "" Then
                            AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                        Else
                            AtrrAxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                        End If
                    End If
                    BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
            Next

            Flag = False

            Return BarCodeStyle.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    Private Function CheckAtrrStyle() As Boolean
        Dim Sqlstr As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            PubAtrributeStype = MakeAtrributeStyle()
            Sqlstr = "select StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & PubAtrributeStype & "'"
            Using RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)


                If RecTable.Read Then
                    If RecTable.GetString(RecTable.GetOrdinal("IsUsed")) = "N" Then
                        LoadD.AtrrBarCodeStyleMax = RecTable("MaxSN").ToString
                        LoadD.AtrrCurrMaxInt = Int(RecTable("MaxInt").ToString)
                        RecTable.Close()
                        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & PubAtrributeStype & "'"
                        Conn.ExecSql(Sqlstr)
                    Else
                        MsgBox("标签中第二对象的流水码正在打印中...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.AtrrBarCodeStyleMax = ""
                    LoadD.AtrrCurrMaxInt = 0
                    RecTable.Close()
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & PubAtrributeStype & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & PubAtrributeStype & "','0','','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    Conn.ExecSql(Sqlstr)
                End If
            End Using
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID)
            Throw ex
            Return False
        End Try
    End Function

    Private Function MainMarkSCode(ByVal printName As String, ByVal taskId As String) As Boolean
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim I, N As Int16
        Dim SqlStr As New StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim AtrrrCurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim GPParameters As String = ""

        '清空，避免获取前面 m_BarRecordValue_t
        'BarValueStr.Remove(0, BarValueStr.Length)
        Try
            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            ''**********************************************
            If IsmullitStyle = "Y" Then
                LoadM.SetAttributeSBCode(AtrrrCurrSBCode, AtrrSBCodeLEN, AtrrSBCodeUnit, LoadD.AtrrBarCodeStyleMax)
                CurrAtrrCodeUnitTable = LoadM.SetCurrCodeUnitTable(AtrrSBCodeLEN, AtrrSBCodeUnit)
            End If
            'Dim pFilePath As String = LoadM.PrintFilePath(LoadD.PFormat)
            If pFilePath = "" Then
                MsgBox("该料号未设置打印模板...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Function
            End If

            'PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat) 改为模板打印，不需要取指令数据
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼

            '正式打印條碼
            '处理打印张数
            For I = 1 To LoadD.CurrPrintNum
                '根據舊序號產生新序號
                CurrSeriNo = ""
                CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                CurrSeriNo = CurrSBCode.ToString
                ''**********************************************
                If IsmullitStyle = "Y" Then
                    AtrrCurrSeriNo = ""
                    AtrrrCurrSBCode = LoadM.AtrriMarkSBCode(AtrrrCurrSBCode, 1, AtrrSBCodeLEN, AtrrSBCodeUnit, CurrAtrrCodeUnitTable)
                    AtrrCurrSeriNo = AtrrrCurrSBCode.ToString()
                End If
                ''**********************************************
                If CurrSBCode.ToString = "" Then
                    'SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                'LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                'LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If
                ''**********************************************
                If IsmullitStyle = "Y" Then
                    AtrrAxTempCode.Remove(AtrrCodeLen, AtrrSBCodeLEN)
                    AtrrAxTempCode.Insert(AtrrCodeLen, AtrrrCurrSBCode.ToString)
                End If
                ''**********************************************
                '臨時數組
                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString
                '生成打印指令If N = LoadD.PrintColNum Then
                If N = 1 Then
                    'PrintBarCode(UseY)   '
                    ModlePrintGenRecord("Y")
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    ModlePrintGenRecord("Y")
                    ReDim PrintPart(2, 0)
                    N = 0
                End If

                '******************ADD 田玉琳 2016/03/21**********************************Start
                '#20160314#70A1#客户格式的时间(我推测是63E)#十进制的流水
                '十进制作时间#客户格式的流水#客户格式的时间#十进制的流水 '2016/03/28 Update
                'Dim StartSn As Integer = IIf(LoadD.StartSn <> "", LoadD.StartSn, 0)
                'Dim SSSS As Integer = StartSn + LoadD.CurrMaxInt + I
                'GPParameters = String.Format("{0}#{1}#{2}#{3}",
                '               CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyyMMdd"), CurrSBCode, YMDCode, SSSS)
                '******************ADD 田玉琳 2016/03/21**********************************end
                TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                '生成存儲Sql語句dd
                'SqlStr &= ControlChars.CrLf & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'B' then 'S' when 'D' then 'S' end,1,'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "')"          " & PrtArray.Qty & "
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel,GPParameters) values('" &
                              TextHandle.DeleteUnVisibleChar(AxTempCode.ToString) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine &
                              "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'B' then 'S' when 'D' then 'S' when 'K' then 'K' end,'1','Y','" &
                              SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" &
                              LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "','" & GPParameters & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            End If
            SqlStr.Append(vbNewLine & "update m_Mainmo_t set Ppidprtqty=isnull(Ppidprtqty,0)+" & CurrNum & ",PpidprtCount=PpidprtCount+" & LoadD.CurrPrintNum & "*" & PrtArray.Qty & " where Moid='" & LoadD.CurrMoid & "'")
            SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'D' then 'S' when 'K' then 'K' end,'" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
            End If
            'If chkGetCodeNoPrint.Checked = True Then 'By 田玉琳 20151210 Update
            '    SqlStr.Append(vbNewLine & String.Format("update m_SnSBarCode_t set noUsed = 1 where SBarCode='{0}'", TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)))
            'End If
            'Me.LblMoidPrinted.Text = MoidPrinted
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum

            '插入數據庫並傳送打印指令到打印機
            'If SqlStr <> "" Then Conn.ExecSql(SqlStr)
            'LoadM.OpenLock(LoadD.StyleID)
            'If PrintStr.ToString <> "" Then PrintBar.PrintCodeBar(SysMessageClass.PrinterPort, PrintStr.ToString)
            'Dim BarFlag As String = My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            'SqlStr &= ControlChars.CrLf & BarCodePrint(BarFlag, PrintStr.ToString)
            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString())
                If ChkNotPrint.Checked = False Then 'By 田玉琳 20151210 Update
                    FileToBarCodePrint(pFilePath, printName)
                End If
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            DbOperateUtils.ExecSQL(" update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'" & vbNewLine &
                                   " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
        End Try
    End Function

    Private Sub ModlePrintGenRecord(ByVal UseY As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24]) " & _
                      "VALUES('S','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Mreader = Conn.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(PrintPart(1, 1))
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************ouxiangfeng 20151116********************
                        If Areaid.ToLower = "barcode2" Then
                            If nPrintStr.ToString = "" Then
                                nPrintStr.Append(AtrrAxTempCode.ToString)
                            Else
                                nPrintStr.Append(vbNewLine & AtrrAxTempCode.ToString)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************ouxiangfeng 20151116********************
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        nPrintStr.Append(vbNewLine)
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString)
                        Next
                        nPrintStr.Append(CurrSeriNo)
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                nPrintStr.Append(vbNewLine & "This is test")
                            Else
                                nPrintStr.Append(vbNewLine & PrintPart(2, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using
            Next

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
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

            Conn = Nothing
        Catch ex As Exception
            Conn = Nothing
            Throw ex
        End Try
    End Sub

#End Region

#Region "包装条码"

    Private Sub BuildCBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
            '        If Me.CboShift.Text = "白班" Then '''''班別,
            '            WorkStr = "D"
            '        Else
            '            WorkStr = "N"
            '        End If
            '        BarCodePartTable.Rows(I)("shortname") = WorkStr
            '        Icount = Icount + 1
            '    End If
            'Next

            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            CMainMarkSCode(PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
        End Try
    End Sub

    Private Function CMainMarkSCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim BarCodeStyle As String
        Try
            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼
            ''''''''''''''''''''''''''''''''''''
            '正式打印條碼
            BarCodeStyle = LoadD.StyleID

            For I = 1 To LoadD.CurrPrintNum
                '根據舊序號產生新序號
                CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                If CurrSBCode.ToString = "" Then
                    'SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    LoadD.StyleID = MakeStyle()

                    AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                    AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                    If LblTempCode.ToString <> "" Then
                        LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                        LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                    End If

                    '臨時數組
                    CurrNum += 1
                    N += 1
                    ReDim Preserve PrintPart(2, N)
                    PrintPart(1, N) = AxTempCode.ToString
                    PrintPart(2, N) = LblTempCode.ToString

                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & LoadD.MantissaBoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & LoadD.MantissaBoxQty & "')")

                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If

                '臨時數組
                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                '生成打印指令
                If N = LoadD.PrintColNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0S
                End If
                'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & PrtArray.Qty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
            SqlStr.Append(vbNewLine & "update m_SnCustomizeStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where CustomizeStyleID='" & LoadD.CustomizeStyleID & "'")

            If (LoadD.MantissaFlag = True) And LoadD.CurrPrintNum > 1 Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & BarCodeStyle & "'")
            End If

            SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())

            SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")

            '插入數據庫並傳送打印指令到打印機
            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                Conn.ExecSql(SqlStr.ToString)
                'PrintData.Cells("PrinterName").EditedFormattedValue.ToString
                ' FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").Value.ToString)

                FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").EditedFormattedValue.ToString)
            End If
            Return True
        Catch ex As Exception
            Throw ex
            'Finally
            '    'LoadM.OpenLock(LoadD.StyleID)
            '    'LoadM.OpenCustomizeLock(LoadD.CustomizeStyleID.Replace("'", "''"))
        End Try
    End Function

    Private Sub CModlePrintGenRecord()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24]) " & _
                      "VALUES('C','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Mreader = Conn.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(PrintPart(1, 1))
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            nPrintStr.Append(vbNewLine & PrintPart(2, 1))
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using

            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray
                'if (BarValueStr.ToString() == "")
                '{
                '    BarFile.Append("\"" + i.ToString() + "\"");
                '    BarValueStr.Append("," + "'" + i.ToString() + "'");
                '}
                'else
                '{

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                '}

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

            Conn = Nothing
            Mreader = Nothing
            Dtable = Nothing
        Catch ex As Exception
            Conn = Nothing
            Mreader = Nothing
            Dtable = Nothing
            Throw ex
        End Try

    End Sub

    Private Sub FormatMantissaBoxQty(ByVal MantissaQty As Int16)
        Try
            If (Not BarCodePartTable Is Nothing) Then
                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q" Or BarCodePartTable.Rows(I).Item("DResource").ToString() = "Array6") Then
                            If (BarCodePartTable.Rows(I).Item("BarArea").ToString() <> "BarCode1") Then
                                BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty
                            Else
                                If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                                    BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty
                                Else
                                    BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty.ToString.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "无序N条码"

    Private Sub BuildNBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            Dim DisorderType As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString
            DisorderType = Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1)

            If String.IsNullOrEmpty(DisorderType) Then
                MsgBox("请配置无序打印条码类型...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If

            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildNBarCode", "sys")
        End Try
    End Sub

    Private Function NMainMarkSCode(ByVal PrintName As String, ByVal UseY As String, ByVal DisorderType As String, ByVal taskId As String, ByVal PackItem As String, ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim BarFlag As String = LoadD.StyleID
        Try
            '打印前準備工作
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            '--
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼

            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString
                '尾数箱处理
                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    LoadD.StyleID = MakeStyle()
                    'PrintData.Cells("PackingLevel").Value.ToString()
                    SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & LoadD.StyleID & "')  begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & LoadD.StyleID & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & LoadD.MantissaBoxQty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & DisorderType & "','" & LoadM.PackingLevel & "')  end "
                    SqlStr &= " IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & LoadD.StyleID & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty,DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & LoadD.StyleID & "','" & LoadD.MantissaBoxQty & "','" & DisorderType & "') End "
                    '" ELSE BEGIN UPDATE m_MOPackingLevel SET PACKID='" & DisorderType & "',PackItem='" & PrintData.Cells("PackItem").Value.ToString & "',PackingLevel='" & PrintData.Cells("PackingLevel").Value.ToString & "',Qty='" & LoadD.MantissaBoxQty & "' Where PartId='" & PrintData.Cells("PartId").Value.ToString & "' and MOId='" & LoadD.CurrMoid & "' END "
                    PrintPart(1, 1) = LoadD.StyleID
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                '生成打印指令
                If N = LoadD.PrintColNum Then
                    'PrintBarCode(UseY)

                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next

            If UseY = "Y" Then
                LoadD.CurrMaxInt = LoadD.CurrMaxInt + LoadD.CurrPrintNum
                SqlStr &= ControlChars.CrLf & " update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.CurrMaxInt & "',IsUsed='N' where StyleID='" & BarFlag & "'"
                MoidPrinted += LoadD.CurrPrintNum
                '打印記錄信息
                SqlStr &= ControlChars.CrLf & " insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime,sBarCode) " & _
                                                                  " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','N','" & BarFlag & "'," & PrtArray.Qty & "," & LoadD.CurrPrintNum & ",'','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & BarFlag & "')"
            End If

            SqlStr &= ControlChars.CrLf & NBarCodePrint(BarFlag, PrintStr.ToString)
            '新增条码记录到SnBarCode        " & Me.CboBarCodeType.Text.Trim.Split("-")(0) & "
            If (LoadD.CurrPrintNum > 1 Or LoadD.MantissaFlag = False) Then
                SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & BarFlag & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & BarFlag & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & PrtArray.Qty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end "
                'SqlStr &= " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'"
                SqlStr &= " IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & BarFlag & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel, SBarCode,qty, DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & BarFlag & "','" & PrtArray.Qty & "', '" & DisorderType & "') End "
                '" ELSE BEGIN UPDATE m_MOPackingLevel SET PACKID='" & DisorderType & "',PackItem='" & PrintData.Cells("PackItem").Value.ToString & "',PackingLevel='" & PrintData.Cells("PackingLevel").Value.ToString & "',Qty='" & PrtArray.Qty & "' Where PartId='" & PrintData.Cells("PartId").Value.ToString & "' and MOId='" & LoadD.CurrMoid & "' END "
            End If

            '更新已打印数量
            If DisorderType = "C" Then
                SqlStr &= " update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'"
            End If

            SqlStr &= " UPDATE m_SnAssign_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid ='" & PrintData.Cells("PtaskId").Value.ToString & "' "

            If SqlStr <> "" Then
                Conn.ExecSql(SqlStr)
                FileToBarCodePrint(pFilePath, PrintName)
            End If
            'If SqlStr.Trim <> "" Then Conn.ExecSql(SqlStr)
            If (LoadD.MantissaFlag) Then
                LoadM.OpenLock(BarFlag)
            End If
            LoadM.OpenLock(LoadD.StyleID)
            'If PrintStr.ToString <> "" Then PrintBar.PrintCodeBar(SysMessageClass.PrinterPort, PrintStr.ToString)

            Conn = Nothing
            Return True
        Catch ex As Exception
            Conn = Nothing
            Throw ex
        Finally
            LoadM.OpenLock(BarFlag.Trim)
            If (LoadD.MantissaFlag = True) Then
                LoadM.OpenLock(LoadD.StyleID.Trim)
            End If
        End Try
    End Function

    Private Function NBarCodePrint(ByVal BarFlag As String, ByVal PrintStr As String) As String

        Try
            '增加对打印记录无法查询数据记录
            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16 ''临时方法，建议直接获取数据库表字段，进行循环。
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag '' My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim Str As String() = PrintStr.Split(StrSplit, StringSplitOptions.RemoveEmptyEntries)
            Dim FixStr As String
            Dim BarValue As String()
            Dim SqlStr As New StringBuilder
            Dim strPrintRecard As String

            Dim SpaceStr As String
            Dim strSpace As String
            Dim TxtFileStr As New StringBuilder
            'Dim BarRecord() As String = PrintStr.ToString.Split("~#") 30
            For k As Int16 = 0 To Str.Length - 1
                strPrintRecard = ""
                strSpace = ""
                If k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1) Then
                    If (LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1 Then
                        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & LoadD.StyleID & "' and PackId = 'N' )" & _
                           " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                           "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                           ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                           ",[label23],[label24]) " & _
                           "VALUES('N','" & LoadD.StyleID & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"


                        SqlStr.Append(FixStr)
                    Else
                        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & printFlag & "' and PackId = 'N' )" & _
                           " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                           "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                           ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                           ",[label23],[label24]) " & _
                           "VALUES('N','" & printFlag & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"
                        SqlStr.Append(FixStr)
                    End If

                    strPrintRecard = "INSERT INTO M_NPrintRecord_t(PRINT_COMPUTER, MOID, PARTID, PACKID, PACKITEM, PRINT_USER, CREATE_TIME, BARCODE, LABEL10, LABEL11, LABEL12, LABEL13, " & _
                                    "LABEL14, LABEL15, LABEL16, LABEL17, LABEL18, LABEL19, LABEL20, LABEL21, LABEL22, LABEL23, LABEL24)VALUES(" & _
                                    "'" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "','N','" & LoadM.Packitem & "','" & SysMessageClass.UseId.ToLower & "',GetDate()"
                End If

                SpaceStr = ""

                BarValue = Str(k).Trim.ToString.Split(vbNewLine) ''
                'NoValueLenth = MaxFileLenth - BarValue.Length + 1  
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1
                    'If BarValue(i).ToString.Replace(Chr(10), "").Trim = "" Then
                    'Continue For
                    'End If
                    If (k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1)) Then
                        SqlStr.Append("," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & "'")
                        strPrintRecard = strPrintRecard & "," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & "'"
                    End If

                    If k = 0 Then
                        If i = 0 Then
                            TxtFileStr.Append("""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    Else
                        If i = 0 Then
                            TxtFileStr.Append(vbNewLine & """" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    End If
                Next
                'If k = Str.Length - 1 Then
                '    NoValueLenth = NoValueLenth - 1
                'End If
                '**********************2016/04/01 田玉琳  Add'**********************Start
                '箱号的要求设置时替换内容
                TxtFileStr.Replace("##/##", String.Format("{0}/{1}", (k + 1).ToString, LoadD.CurrPrintNum.ToString))
                '**********************2016/04/01 田玉琳  Add'**********************End

                If k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1) Then
                    For j As Int16 = 1 To NoValueLenth - 1
                        SpaceStr = SpaceStr & "'',"
                        strSpace = strSpace & "'',"
                    Next
                    SpaceStr = SpaceStr & "'') END"

                    strPrintRecard = strPrintRecard & "," & strSpace & "'')"
                    SqlStr.Append("," & SpaceStr & vbNewLine)
                    SqlStr.Append(strPrintRecard & vbNewLine)
                End If
            Next

            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, Encoding.UTF8)
            NBarCodePrint = SqlStr.ToString
            'File.AppendAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try


    End Function

    Private Sub NModlePrintGenRecord(ByVal UseY As String, ByVal MantissaFlag As Boolean, ByVal MantissaBoxQty As Int16)

        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Mreader = Conn.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString

                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'If(TempView.Item(I).Item("ShortName").ToString
                            If I = 0 Then
                                If (I > 0) Then
                                    PrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                PrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If

                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                PrintStr.Append(PrintPart(1, 1))
                            Else
                                PrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                PrintStr.Append(vbNewLine & "This is test")
                            Else
                                PrintStr.Append(vbNewLine & PrintPart(2, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using
            Next
            Mreader = Nothing
            Dtable = Nothing
            Conn = Nothing
        Catch ex As Exception
            Mreader = Nothing
            Dtable = Nothing
            Conn = Nothing
            Throw ex
        End Try

    End Sub


#End Region

#End Region

#Region "函数"

    Private Sub LoadControlData()
        Me.dtpEndDate.Value = Now.AddDays(-1)
        Me.dtpStartDate.Value = Now.AddDays(1)

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DateT As New DateTime
        Dim RecTable As SqlDataReader
        RecTable = Conn.GetDataReader("select getdate() as nowtime")
        If RecTable.Read Then
            DateT = CDate(RecTable!nowtime.ToString)
        End If
        Me.LblPrintDate.Text = DateT.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        PrtArray.NowDate = CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString
        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text.ToString).ToString("MM").ToString
        Conn = Nothing
    End Sub

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpStartDate.Value < dtpEndDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Private Function CheckDemand(ByVal DemandTime As String) As Boolean
        Dim strTemp As String = ""
        Try
            strTemp = FormatDateTime(DemandTime)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function InitializePrintParameter(ByVal PrintData As DataGridViewRow) As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dtable As SqlDataReader
        Try

            Dtable = Conn.GetDataReader("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid from m_Mainmo_t as a join m_SnAssign_t as b " _
                                        & " on b.Moid=a.Moid and b.Estateid in('1','2') join m_PartPack_t as c on a.PartID=c.Partid and c.Packid=b.Packid AND c.Packitem= b.Packitem and c.Usey='Y' " _
                                        & " where b.Ptaskid='" & PrintData.Cells("Ptaskid").Value.ToString & "'")
            If Dtable.HasRows Then
                While Dtable.Read
                    LoadM.CodeRule = Dtable!CodeRuleID.ToString
                    LoadM.Packitem = PrintData.Cells("PackItem").Value.ToString
                    LoadM.DisorderType = Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1)
                    LoadM.PackingLevel = PrintData.Cells("PackingLevel").Value.ToString
                    LoadM.Taskid = Dtable!Ptaskid.ToString
                    LoadM.DefaultMoid = Dtable!Moid.ToString
                    LoadM.DefaultLine = Dtable!Lineid.ToString
                    LoadM.CustID = Dtable!Cusid.ToString
                    LoadM.Factory = VbCommClass.VbCommClass.Factory
                    LoadM.DeptJm = PrintData.Cells("djmdc").Value.ToString
                    LoadM.vShift = PrintData.Cells("shift").Value.ToString
                    LoadM.vLineJm = PrintData.Cells("LineJm").Value.ToString
                    LoadM.vRequestDate = PrintData.Cells("Demandtime").Value.ToString
                    LoadM.vIsprint = IIf(Me.ChkNotPrint.Checked, "Y", "N")
                    LoadM.vCodeType = Dtable!Packid.ToString
                    LoadM.vVerNo = PrintData.Cells("FileVerNo").Value.ToString
                    LoadM.vDriFlag = PrintData.Cells("DriFlag").Value.ToString
                    LoadM.vBuildAttribute = PrintData.Cells("BuildAttribute").Value.ToString

                End While

                Dtable.Close()
                Dtable = Conn.GetDataReader("select distinct a.TAvcPart,a.CustPart,c.CusName,b.Deptid,f.djc,b.Lineid,b.Moqty,b.Ppidprtqty,b.PkgPrtqty,d.Packid,j.TemplatePath,e.PFormatID,e.PaperSize,e.ColNum,e.RowNum,d.Packlink,d.Multiy,d.MultiQty,d.Qty,d.StartInt,d.StartSn,d.EndInt,d.EndSn " _
                        & "from m_PartContrast_t as a join m_Mainmo_t as b on a.TAvcPart=b.PartID and b.Moid='" & LoadM.DefaultMoid & "' and b.FinalY='N' " _
                        & "left join m_Dept_t as f on b.Deptid=f.Deptid left join m_Customer_t as c on a.CusID=c.CusID join m_PartPack_t as d on a.TAvcPart=d.Partid and d.CodeRuleID='" & LoadM.CodeRule & "' and d.usey='Y'  and d.PackItem='" & PrintData.Cells("PackItem").Value.ToString & "'" _
                        & "left join m_SnPFormat_t as e on d.PFormatID=e.PFormatID  left join m_SnMFormat_t as j on d.PFormatID=j.PFormatID")
                If Dtable.HasRows Then
                    While Dtable.Read
                        LoadD.CurrAVCPartID = Dtable("TAvcPart").ToString.ToUpper.Trim
                        LoadD.CurrMoid = LoadM.DefaultMoid
                        LoadD.PFormat = Dtable("PFormatID").ToString
                        LoadD.PrintColNum = Int(IIf(Dtable("ColNum").ToString <> "", Dtable("ColNum").ToString, 0)) * CInt(Dtable("RowNum").ToString)
                        LoadD.StartSn = Dtable("StartSn").ToString
                        LoadD.EndSn = Dtable("EndSn").ToString
                        LoadD.EndInt = Int(IIf(Dtable("EndInt").ToString <> "", Dtable("EndInt").ToString, "0"))
                        LoadD.StartInt = Int(IIf(Dtable("StartInt").ToString <> "", Dtable("StartInt").ToString, "0"))

                        PackItems = Dtable("Packid").ToString
                        Packlink = Dtable("Packlink").ToString
                        MoidAllNum = Int(IIf(Dtable("Moqty").ToString <> "", Dtable("Moqty").ToString, 0))
                        MoidPrinted = Int(IIf(Dtable("PkgPrtqty").ToString <> "", Dtable("PkgPrtqty").ToString, 0))

                        'CtPrtingNum = Int(MoidAllNum / PackMethod) - MoidPrinted  '可打印箱數
                        'MoidLastNum = MoidAllNum Mod PackMethod  '尾數
                        PrtArray.AvcPartid = Dtable("TAvcPart").ToString.ToUpper.Trim
                        PrtArray.CusName = Dtable("CusName").ToString.Trim
                        PrtArray.Deptid = Dtable("Deptid").ToString.ToUpper.Trim
                        PrtArray.Lineid = LoadM.vLineJm
                        PrtArray.Moid = LoadD.CurrMoid.ToUpper.Trim
                        PrtArray.Qty = IIf(Dtable("Qty").ToString <> "", Dtable("Qty").ToString, "1")     'IIf(Dtable("Qty").ToString <> "", Dtable("Qty").ToString, 0)
                        PrtArray.ConfigFlag = LoadM.vVerNo
                        PrtArray.DriFlag = LoadM.vDriFlag
                        PrtArray.BuildAttribute = LoadM.vBuildAttribute
                        PrtArray.DateCode = ""
                        PrtArray.WorkType = LoadM.vShift
                        PrtArray.ContainerNo = "##/##"
                        pFilePath = Dtable("TemplatePath").ToString
                    End While

                    If MarkBarTable(Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1), PrintData.Cells("PackItem").Value.ToString) = False Then
                        Exit Try
                    End If

                    SetArrayLbl(PrtArray.ToArray)

                    Dtable.Close()
                    Conn = Nothing
                    Return False
                Else
                    Dtable.Close()
                    Conn = Nothing
                    Return True
                    Exit Function
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function MarkBarTable(ByVal PackId As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        '建立條碼組成部分並分別賦初值
        Try
            Sqlstr = "select distinct a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128)),left(c.DValues,F_codelen)) as ShortName,a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
            & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
            & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
            & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
            & " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y'  and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "' where a.CodeRuleID='" & LoadM.CodeRule.ToString & "'"

            RecTable = DbOperateUtils.GetDataTable(Trim(Sqlstr))
            If RecTable.Rows.Count > 0 Then
                BarCodePartTable = RecTable
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            RecTable.Dispose()
        End Try
    End Function

    Private Function CheckStyle() As Boolean
        Dim Sqlstr As String
        'Dim RecTable As New DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            LoadD.StyleID = MakeStyle() '產生樣式
            Sqlstr = "select StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'"
            Using RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

                If RecTable.Read Then
                    If RecTable.GetString(RecTable.GetOrdinal("IsUsed")) = "N" Then
                        'LoadD.BarCodeStyleMax = RecTable("MaxSN").ToString
                        'LoadD.CurrMaxInt = Int(RecTable("MaxInt").ToString)
                        RecTable.Close()
                        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'"
                        Conn.ExecSql(Sqlstr)
                    Else
                        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.CurrMaxInt = LoadD.StartInt
                    RecTable.Close()
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    Conn.ExecSql(Sqlstr)
                End If
            End Using

            LoadD.CustomizeStyleID = LoadD.StyleID.ToString.Split(" {")(8)

            Sqlstr = "select CustomizeStyleID,MaxInt,MaxSN,IsUsed from m_SnCustomizeStyle_t where CustomizeStyleID='" & LoadD.CustomizeStyleID.ToString.Replace("'", "''") & "'"
            Using RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

                If RecTable.Read Then
                    If RecTable.GetString(RecTable.GetOrdinal("IsUsed")) = "N" Then
                        LoadD.BarCodeStyleMax = RecTable("MaxSN").ToString
                        LoadD.CurrMaxInt = Int(RecTable("MaxInt").ToString)
                        RecTable.Close()
                        Sqlstr = "update m_SnCustomizeStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where CustomizeStyleID='" & LoadD.CustomizeStyleID.Replace("'", "''") & "'"
                        Conn.ExecSql(Sqlstr)
                    Else
                        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.CurrMaxInt = LoadD.StartInt
                    RecTable.Close()
                    Sqlstr = "insert into m_SnCustomizeStyle_t(StyleID, CustomizeStyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "', '" & LoadD.CustomizeStyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.CustomizeStyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    Conn.ExecSql(Sqlstr)
                End If
            End Using

            Conn = Nothing
            Return True
        Catch ex As Exception
            Conn = Nothing
            LoadM.OpenLock(LoadD.StyleID.Replace("'", "''"))
            LoadM.OpenCustomizeLock(LoadD.CustomizeStyleID.Replace("'", "''"))
            Throw ex
            Return False
        End Try
    End Function

    Private Function Checking(ByVal PrintData As DataGridViewRow) As Boolean

        Dim FCLNumber As Int32
        Dim TrunkNumber As Int32

        If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
            MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Return False
        End If
        '檢測打印數量   AndAlso Int(Me.txtPrintCount.Text.Trim) <= 1000
        If IsNumeric(Me.txtPrintCount.Text.Trim) Then
            If (CInt(Me.txtPrintCount.Text.Trim) <= 0) Then
                MsgBox("打印数量必须大于0！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If
            If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "P") Then

                If ((CInt(Me.txtPrintCount.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) = 0) Then
                    FCLNumber = CInt(Me.txtPrintCount.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    TrunkNumber = 0
                    LoadD.MantissaFlag = False
                Else
                    FCLNumber = Int(CInt(Me.txtPrintCount.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim))
                    TrunkNumber = 1
                    LoadD.MantissaFlag = True
                    LoadD.MantissaBoxQty = CInt(Me.txtPrintCount.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    If (CInt(Me.txtPrintCount.Text.Trim) < CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) Then
                        FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    End If
                End If
                LoadD.CurrPrintNum = FCLNumber + TrunkNumber

            Else
                LoadD.CurrPrintNum = CInt(Me.txtPrintCount.Text.Trim) * CInt(PrintData.Cells("ConfigurationQty").Value.ToString.Trim)
                LoadD.MantissaFlag = False
            End If
        Else
            LoadD.CurrPrintNum = 0
            MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Return False
        End If
        'If Int(Me.LblMoidPrinted.Text.Trim) + LoadD.CurrPrintNum > Int(Me.LblMoidNum.Text.Trim) Then
        '    If MessageBox.Show("你申請的打印量已超標，請確認是否需要打印這么多量？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return False
        'End If
        Return True
    End Function

    Private Function MakeStyle() As String
        Dim I As Integer
        Dim Flag As Boolean = False
        Dim TempView As DataView

        Dim BarCodeStyle As New StringBuilder
        AxTempCode.Remove(0, AxTempCode.Length)
        LblTempCode.Remove(0, LblTempCode.Length)
        YMDCode.Remove(0, YMDCode.Length)  'ADD 田玉琳 2016/03/21
        Try
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarCode1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式
            For I = 0 To TempView.Count - 1
                '******************ADD 田玉琳 2016/03/21**********************************Start
                If (TempView.Item(I).Item("F_codeID").ToString = "Y" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "M" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "D" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "W") AndAlso
                 TempView.Item(I).Item("UnitID").ToString <> "" Then
                    YMDCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If
                '******************ADD 田玉琳 2016/03/21**********************************end
                If TempView.Item(I).Item("IsPrintStyle").ToString = "Y" Then
                    BarCodeStyle.Append(TempView.Item(I).Item("ShortName").ToString)
                    AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                Else
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                        LoadD.AxSPos = AxTempCode.Length
                        Flag = True
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "Q" Then
                        AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                    Else
                        If TempView.Item(I).Item("ShortName").ToString.Trim <> "" Then
                            AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                        Else
                            AxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                        End If
                    End If
                    BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
                'BarCodeStyle.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Flag = False
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarLabel1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式Label1
            For I = 0 To TempView.Count - 1
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                    LoadD.LblSPos = LblTempCode.Length
                    Flag = True
                End If
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper <> "S" Then
                    LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
                    LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
                LblTempCode.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function


    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

#End Region



    Private Sub ToolPrintLoak_Click(sender As Object, e As EventArgs) Handles ToolPrintLoak.Click
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim styleId As String = "",strCustomizeStyleID As String =""
        Dim strSQL As String = "", strSQL2 As String = ""

        For i As Integer = 0 To Me.dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                InitializePrintParameter(dgvPrintList.Rows(i))
                styleId = MakeStyle() '產生樣式
                If Not String.IsNullOrEmpty(styleId) AndAlso styleId.Split("{").Length >= 8 Then
                    strCustomizeStyleID = styleId.Split(" {")(8)
                Else
                    strCustomizeStyleID =""
                End If
                'strSQL = strSQL + " UPDATE m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where IsUsed='Y' AND StyleID='{0}' AND FactoryId='{1}' "
                'strSQL = String.Format(strSQL, styleId.Replace("'", "''"), VbCommClass.VbCommClass.Factory)

                strSQL = strSQL + " UPDATE m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where IsUsed='Y' AND StyleID='" & styleId.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "'"

                strSQL = strSQL + " UPDATE m_SnCustomizeStyle_t SET IsUsed='N',Intime=getdate() where IsUsed='Y' AND CustomizeStyleID='" & strCustomizeStyleID.Replace("'", "''") & "'"

                ' strSQL = strSQL + " UPDATE m_SnStyle_t SET IsUsed='N' WHERE IsUsed='Y' and StyleID = '{0}' "
                strSQL = strSQL + " UPDATE m_SnStyle_t SET IsUsed='N' WHERE IsUsed='Y' and StyleID = '" & styleId.Replace("'", "''") & "' "
                'strSQL = strSQL & String.Format(strSQL2, styleId.Replace("'", "''"))
            End If
        Next

        If strSQL <> "" Then
            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("解锁成功！")
        Else
            MessageUtils.ShowInformation("没有锁定条码！")
        End If
    End Sub
End Class