
'--标签补数作业
'--Create by :　马锋
'--Create date :　2016/08/11
'--Update date :  
'--Ver : V01

'更新者：田玉琳
'更新日期：2019/08/11
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
Imports System.Data
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmComplementApplication

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

#Region "窗体事件"

    Private Sub FrmComplementApplication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btApp = New BarTender.ApplicationClass
        SetStatus(opFlag)
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)

        LoadControlData()
        ClearObject()

        Me.chbPrintListSelect.Checked = True
        Me.txtMOId.Focus()
    End Sub

    Private Sub FrmComplementApplication_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        DataType = "NEW"
        opFlag = 1
        SetStatus(opFlag)
        ClearObject()
        Me.ActiveControl = Me.txtMOId
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = False
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.FromArgb(0, 122, 204)

    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click

        dgvPrintList.EndEdit()
        Dim StrSavaSQL As New StringBuilder
        SetMessage("")
        Try
            If (CheckLotSava()) Then
                Exit Sub
            End If

            '保存打印申请
            Dim PtaskId As String = ""
            Dim shift As String
            Dim taskPrefix As String = ""

            shift = IIf(Me.CboShift.SelectedIndex = 0, "D", "N")
            If Me.CboShift.SelectedIndex = -1 Then
                shift = ""
            End If

            StrSavaSQL.Append(" INSERT INTO m_ComplementApplication_t(Moid, Orderseq, Tmoid, PartID, Moqty, Outqty, BlueprintVersion, PackageVersion, PO, Createuser, Createtime, Remark)")
            StrSavaSQL.Append(" SELECT Moid, Orderseq, Tmoid, PartID, Moqty, '" & Me.txtQty.Text.Trim & "', N'" & Me.txtBlueprintVersion.Text.Trim & "', N'" & Me.txtPackageVersion.Text.Trim & "', N'" & Me.txtPO.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "', getdate(), N'" & Me.TxtTaskDesc.Text.Trim & "' FROM m_MainMO_t WHERE MOID='" & Me.dgvPrintList.Rows(0).Cells("Moid").Value.ToString & "'")
            StrSavaSQL.Append(" DECLARE @ComplementApplicationId VARCHAR(32) SELECT @ComplementApplicationId=ComplementApplicationId FROM m_ComplementApplication_t WHERE MOID='" & Me.dgvPrintList.Rows(0).Cells("Moid").Value.ToString & "' AND StatusFlag='0'")
            For I As Int16 = 0 To Me.dgvPrintList.RowCount - 1

                Dim chkTemp As DataGridViewCheckBoxCell
                chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")
                If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                    ''跟条码打印申请表关联---by hs ke
                    StrSavaSQL.Append(" INSERT INTO m_ComplementApplicationItem_t(ComplementApplicationId, Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,ConfigurationQty) " _
                       & " VALUES(@ComplementApplicationId, '" & dgvPrintList.Rows(I).Cells("PtaskId").Value.ToString & "','" & "" & "','" & dgvPrintList.Rows(I).Cells("Moid").Value.ToString & "','" & Microsoft.VisualBasic.Left(Me.dgvPrintList.Rows(I).Cells("lableType").Value, 1) & "'," & Me.txtQty.Text.ToString.Trim & "," _
                       & " cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.Trim & "','" & shift & "','" & dgvPrintList.Rows(I).Cells("FileVerNo").Value.ToString.Trim & "','" & "" & "','" & "" & "','" & Me.dgvPrintList.Rows(I).Cells("PackItem").Value & "','" & Me.dgvPrintList.Rows(I).Cells("ConfigurationQty").Value & "')")

                End If
            Next

            If (Not String.IsNullOrEmpty(StrSavaSQL.ToString)) Then
                DbOperateUtils.ExecSQL(StrSavaSQL.ToString())
            End If

            StrSavaSQL = Nothing
            Dim strMoid As String = Me.txtMOId.Text.Trim
            opFlag = 0
            SetStatus(opFlag)
            ClearObject()
            Me.txtMOId.Text = strMoid
            GetLot()
            dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
            dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
            dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black
        Catch ex As Exception
            StrSavaSQL = Nothing
            SetMessage("保存失败,请联系开发人员!")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "ToolCommit_Click", "sys")
        End Try
    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        ClearObject()
        opFlag = 0
        SetStatus(opFlag)
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        If CheckQueryParameter(False) Then
            Return
        End If

        GetLot()
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black
    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrt.Click
        Me.ToolPrt.Enabled = False
        Me.IsmullitStyle = "N"
        Try
            SetMessage("")
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
                    If Me.ChkNotPrint.Checked = False Then
                        index = dgvLotList.CurrentCell.RowIndex
                        DbOperateUtils.ExecSQL("UPDATE m_ComplementApplication_t SET CHECKTEXT=N'打印完成', StatusFlag='2' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "' AND ComplementApplicationId = '" & Me.dgvLotList.Rows(index).Cells("ComplementApplicationId").Value.ToString & "'")
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

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        If CheckQueryParameter(True) Then
            Return
        End If

        GetLot() '出错
        Me.txtPrintCount.Enabled = True
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolMove.Click
        SetMessage("")
        Try
            Dim strMOId, strComplementApplicationId As String
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要审核补数申请工单!")
                Exit Sub
            End If

            strMOId = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("Colmoid").Value.ToString
            strComplementApplicationId = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ComplementApplicationId").Value.ToString
            If (Not CheckStatusFlag(strMOId, strComplementApplicationId, "'0'", "工单:" & strMOId & "非新增状态,不允许退单!")) Then
                Exit Sub
            End If

            DbOperateUtils.ExecSQL("UPDATE m_ComplementApplication_t SET CHECKTEXT=N'" & Me.TxtTaskDesc.Text.Trim & "', StatusFlag='3' where MOID='" & strMOId & "' AND ComplementApplicationId = '" & strComplementApplicationId & "'")
            Me.TxtTaskDesc.Text = ""
            SetMessage("工单号为" + strMOId + "退单成功!")

            If CheckQueryParameter(True) Then
                Return
            End If

            GetLot()
        Catch ex As Exception
            SetMessage(ex.ToString())
        End Try

    End Sub

    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click

        Try

            If (MessageBox.Show("你确定删除？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Dim strMOId As String
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要删除工单!")
                Exit Sub
            End If

            strMOId = Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim

            CheckLotAgain(strMOId)

            If CheckQueryParameter(True) Then
                Return
            End If

            GetLot() '出错
            Me.txtPrintCount.Enabled = True

        Catch ex As Exception
            SetMessage("执行工单删除异常，请联系开发人员!")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "ToolDelete_Click", "sys")
        End Try
    End Sub

    Private Sub ToolCheck_Click(sender As Object, e As EventArgs) Handles ToolCheck.Click
        SetMessage("")
        Try
            Dim strMOId, strComplementApplicationId As String
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要审核补数申请工单!")
                Exit Sub
            End If
            strMOId = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("Colmoid").Value.ToString
            strComplementApplicationId = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ComplementApplicationId").Value.ToString
            If (Not CheckStatusFlag(strMOId, strComplementApplicationId, "'0'", "工单:" & strMOId & "非新增状态,不允许审核!")) Then
                Exit Sub
            End If

            Dim sql As String = "UPDATE m_ComplementApplication_t SET StatusFlag='1', CheckUserId='" & VbCommClass.VbCommClass.UseId &
                                "', CheckTime = Getdate() where MOID='" & strMOId & "' AND ComplementApplicationId = '" & strComplementApplicationId & "'" & _
                                " update b set b.ApplyAddQty=isnull(b.ApplyAddQty,0)+isnull(a.PrtQty,0),b.FinishedAddQty=isnull(b.FinishedAddQty,0)+isnull(a.FinishPrintQty,0) " & _
                                " from m_ComplementApplicationItem_t a join m_SnAssign_t b on a.Ptaskid=b.Ptaskid and a.Packid=b.Packid and a.Packitem=b.Packitem" & _
                                " where ComplementApplicationId='" & strComplementApplicationId & "'"

            DbOperateUtils.ExecSQL(sql)

            SetMessage("执行工单补数申请审核成功!")

            If CheckQueryParameter(True) Then
                Return
            End If

            GetLot()
        Catch ex As Exception
            SetMessage("执行工单补数申请审核异常，请联系开发人员!")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmComplementApplication", "ToolCheck_Click", "sys")
        End Try
    End Sub


    Private Sub ToolExport_Click(sender As Object, e As EventArgs) Handles ToolExport.Click
        If Not Me.dgvLotList Is Nothing AndAlso Me.dgvLotList.RowCount > 0 Then
            SysBasicClass.Export.OutToExcelFromDataGridView("标签补数作业", Me.dgvLotList, False)
        End If


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

            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim,
                            Me.dgvLotList.Item("ComplementApplicationId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim,
                            Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        Catch ex As Exception
            SetMessage("获取工单打印清单异常")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "dgvLotList_CellEnter", "sys")
        End Try
    End Sub

    Private Sub txtMOId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOId.KeyDown, txtQty.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                SetMessage("")
                If (ToolNew.Enabled) Then
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim())) Then
                    SetMessage("新增工单不能为空!")
                    Me.ActiveControl = Me.txtMOId
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtQty.Text.Trim())) Then
                    txtQty.Text = "0"
                End If

                strMOID = String.Empty
                Dim dtLot As New DataTable

                dtLot = DbOperateUtils.GetDataTable(GetCheckLotSQL(Me.txtMOId.Text.Trim()))
                If dtLot.Rows.Count > 0 Then
                    Me.TxtPartid.Text = dtLot.Rows(0).Item("PartId").ToString()
                    If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim()) Then
                        GetLotPrintList(Me.txtMOId.Text.Trim, "", Me.TxtPartid.Text.Trim, Me.txtQty.Text.Trim, False)
                        If (dgvPrintList.Rows.Count = 0) Then
                            SetMessage("请设置工单料件打印参数!")
                        End If
                    End If
                    SetMessage("")
                Else
                    SetMessage("工单" + Me.txtMOId.Text.Trim + "不存在,请熟知!")
                    ClearQuery()
                End If
                strMOID = Me.txtMOId.Text.Trim

                dtLot.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SetMessage("工单" & Me.txtMOId.Text.Trim() & "下载异常!")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmComplementApplication", "txtMOId_KeyDown", "sys")
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

    Private Sub txtPrintCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrintCount.KeyPress

        If Me.txtPrintCount.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Me.txtQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

    Private Sub dgvPrintList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrintList.CellLeave

        dgvPrintList.EndEdit()

    End Sub

#End Region

#Region "Function"

    Private Sub GetProductModify(ByVal dvBOM As DataView, ByRef ProductId As String, ByRef ModifyDate As String)
        If Not dvBOM Is Nothing Then
            For i As Int16 = 0 To dvBOM.Count - 1
                If (dvBOM.Item(i).Item("PARENT_PART").ToString = dvBOM.Item(i).Item("IMA01").ToString) Then
                    ProductId = dvBOM.Item(i).Item("PARENT_PART").ToString()
                    ModifyDate = dvBOM.Item(i).Item("MODIFYDATE").ToString()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Function CheckBOM(ByVal ProductId As String, ByVal ModifyDate As String) As Boolean
        Dim dtPrintStatus As New DataTable
        Try
            dtPrintStatus = DbOperateUtils.GetDataTable("SELECT TOP 1 COMPONENT_ID, ISNULL(MODIFIY_DATE, DATEADD(year,-10,GETDATE())) AS MODIFIY_DATE FROM M_BOM_T WHERE PRODUCT_ID='" & ProductId & "' AND COMPONENT_ID='" & ProductId & "'")
            If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
                If (DateDiff("d", CDate(dtPrintStatus.Rows(0).Item("MODIFIY_DATE").ToString()), CDate(ModifyDate)) <= 0) Then
                    Return False
                Else
                    DbOperateUtils.ExecSQL("DELETE M_BOM_T WHERE PRODUCT_ID='" & ProductId & "'")
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckLotAgain(ByVal strMOid As String) As Boolean
        Try
            If (String.IsNullOrEmpty(strMOid.Trim)) Then
                SetMessage("工单" & strMOid.Trim() & "不存在!")
                Return True
            End If

            '检查是否已经打印
            Dim dtPrintStatus As New DataTable

            dtPrintStatus = DbOperateUtils.GetDataTable("SELECT Ptaskid FROM m_Mainmo_t INNER JOIN m_ComplementApplication_t ON m_ComplementApplication_t.MOID=m_Mainmo_t.MOID WHERE m_Mainmo_t.ParentMo='" & strMOid.Trim & "' AND FinishPrintQty>0")
            If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
                SetMessage("工单" & strMOid.Trim() & "已经打印，不允许重新下载或删除!")
                Return True
            End If

            '执行删除
            Dim SqlStr As String
            SqlStr = " DELETE m_ComplementApplication_t WHERE Moid IN (SELECT MOID FROM m_Mainmo_t WHERE ParentMo='" & strMOid.Trim & "')"

            DbOperateUtils.ExecSQL(SqlStr)

            dtPrintStatus = Nothing
        Catch ex As Exception
            SetMessage("工单" & strMOid.Trim() & "删除失败，请联系开发人员!")
            Return True
        End Try
        Return False
    End Function

    Private Function CheckLotSava() As Boolean
        If (String.IsNullOrEmpty(strMOID)) Then
            SetMessage("工单BOM下载超时，请重新下载工单!")
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim())) Then
            SetMessage("请输入下载工单!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.TxtPartid.Text.Trim())) Then
            SetMessage("工单料号不能为空!")
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtQty.Text.Trim())) Then
            SetMessage("工单数量不能为空!")
            Return True
        Else
            If (CInt(Me.txtQty.Text.Trim()) <= 0) Then
                SetMessage("工单数量不能为空!")
                Return True
            End If
        End If

        If (String.IsNullOrEmpty(Me.txtBlueprintVersion.Text.Trim())) Then
            SetMessage("请输入蓝图版本!")
            Me.txtBlueprintVersion.Focus()
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtPackageVersion.Text.Trim())) Then
            SetMessage("请输入包规版本!")
            Me.txtPackageVersion.Focus()
            Return True
        End If

        If (String.IsNullOrEmpty(Me.TxtTaskDesc.Text.Trim())) Then
            SetMessage("备注补数原因不能为空!")
            Me.TxtTaskDesc.Focus()
            Return True
        End If

        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT ComplementApplicationId FROM m_ComplementApplication_t WHERE Moid='" & Me.dgvPrintList.Rows(0).Cells("Moid").Value.ToString & "' AND StatusFlag = '0' ")

        If (dtTemp.Rows.Count > 0) Then
            SetMessage("保存失败,该工单有未确认申请,不能重复申请!")
            Return True
        End If

        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        For i As Int16 = 0 To Me.dgvPrintList.Rows.Count - 1
            chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("lableType").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (i + 1).ToString + "行料件打印参数，并确保其他料件参数已经配置OK!")
                    Exit For
                End If
                '判断是否设置模板
                If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("LabelTemplates").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (i + 1).ToString + "行料件打印模板，并确保其他料件打印模板已经配置OK!")
                    Exit For
                End If
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(i).Cells("lableType").Value.ToString.Trim, 1) = "C") Then
                    If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("PackingQty").Value.ToString.Trim) Or CInt(dgvPrintList.Rows(i).Cells("PackingQty").Value.ToString.Trim) <= 0) Then
                        SetMessage("请配置第" + (i + 1).ToString + "行包装容量，并确保其他包装打印料件包装容量已经配置OK!")
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("没有任何保存数据!")
            Return True
        End If

        Return False
    End Function

    Private Sub GridViewColumnEdit(ByVal gvName As DataGridView, ByVal ColumnNum As Integer)
        For I As Int16 = 0 To gvName.Columns.Count - 1
            gvName.Columns(1).ReadOnly = True
        Next
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

    Private Function GetCheckLotSQL(ByVal LotName As String) As String
        Dim Sql As String
        Sql = " SELECT a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname,a.PartID " _
            & "FROM m_Mainmo_t as a LEFT JOIN m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
            & "LEFT JOIN m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' WHERE moid=" & FormatQuerySQLString(LotName)
        Return Sql
    End Function


    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim strTeskId As String
        Dim strMoid As String
        Dim strPartid As String
        Dim strPackItem As String
        Dim strPackId As String
        Dim strDisorderType As String
        Dim strVersion As String
        Dim strVersionType As String

        '增加审核检查
        If (Not CheckStatusFlag(dgvPrintList.Rows(0).Cells("Moid").Value.ToString, dgvLotList.Rows(dgvLotList.CurrentRow.Index).Cells("ComplementApplicationId").Value.ToString(), "'1','2'", "打印工单状态，非审核/打印，不允许打印！")) Then
            Exit Function
        End If

        If Not IsNumeric(Me.txtPrintCount.Text.Trim) Then
            SetMessage("输入打印数量有误！")
            Return False
        End If
        If (Int(Me.txtPrintCount.Text.Trim) > 1000) Then
            SetMessage("产品条码一次打印數量限制在1-1000以內！")
            Return False
        End If

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")

            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                strTeskId = dgvPrintList.Rows(I).Cells("PtaskId").Value.ToString
                strMoid = dgvPrintList.Rows(I).Cells("Moid").Value.ToString
                strPartid = dgvPrintList.Rows(I).Cells("PartId").Value.ToString
                strPackId = Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString, 1)
                strDisorderType = dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString
                strPackItem = dgvPrintList.Rows(I).Cells("PackItem").Value.ToString
                strVersion = dgvPrintList.Rows(I).Cells("Remark").Value.ToString
                strVersionType = dgvPrintList.Rows(I).Cells("VersionTypeText").Value.ToString.Trim.Split("-")(0)

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

                If (Not CheckPrintQuantity(strTeskId, Me.txtPrintCount.Text.Trim, I + 1)) Then
                    Return False
                    Exit For
                End If

                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
        End If
        Return iSelect
    End Function

    Private Function CheckVersion(ByVal strPartid As String, ByRef strRtMessage As String) As Boolean
        Dim strMessage As String
        Try
            Dim strBlueprintVersion As String = Nothing
            Dim strPackageVersion As String = Nothing
            Dim strClassification As String
            Dim strSQL As New StringBuilder
            Dim dtPartVersion As DataTable
            Dim strPartTemp As String
            Dim strCheckVersionFlag As String
            Dim strVersion As String

            strSQL.AppendLine(" SELECT * FROM OPENQUERY([172.20.22.101],'SELECT A.SOP_VER + CAST(A.SOP_GEN AS VARCHAR(8)) AS VERSION, A.CLASSIFICATION ")
            strSQL.AppendLine(" FROM OPENPLM.INNOVATOR.cad a INNER JOIN OPENPLM.INNOVATOR.cad_part b on a.id=b.source_id INNER JOIN OPENPLM.INNOVATOR.part c on b.related_id=c.id ")
            strSQL.AppendLine(" WHERE C.LX_IMA01 = ''" & strPartid & "'' AND A.STATE = ''Released'' AND A.IS_CURRENT = ''1'' ORDER BY A.SOP_GEN DESC, A.STATE DESC ')")

            dtPartVersion = DbOperateUtils.GetDataTable(strSQL.ToString)

            If (dtPartVersion Is Nothing) Then
                strRtMessage = "料件[" & strPartid & "],PLM版本获取异常"
                Return False
            Else
                If (dtPartVersion.Rows.Count > 0) Then
                    For i As Int16 = 0 To dtPartVersion.Rows.Count - 1
                        strClassification = dtPartVersion.Rows(i).Item("CLASSIFICATION").ToString

                        If (InStr(strClassification, "蓝图") <> 0) Then
                            strBlueprintVersion = dtPartVersion.Rows(i).Item("VERSION").ToString
                        End If

                        If (InStr(strClassification, "包规") <> 0) Then
                            strPackageVersion = dtPartVersion.Rows(i).Item("VERSION").ToString
                        End If
                    Next

                    Dim chkTemp As DataGridViewCheckBoxCell
                    Dim bCheckVersion As Boolean = True

                    strMessage = "料件[" & strPartid & "],"
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            strPartTemp = Me.dgvPrintList.Rows(i).Cells("PartId").Value.ToString
                            If (strPartTemp = strPartid) Then
                                strCheckVersionFlag = Me.dgvPrintList.Rows(i).Cells("VersionTypeText").Value.ToString.Split("-")(0)
                                If (strCheckVersionFlag <> 0) Then
                                    strVersion = IIf(IsDBNull(Me.dgvPrintList.Rows(i).Cells("Remark").Value), "", Me.dgvPrintList.Rows(i).Cells("Remark").Value.ToString)

                                    Select Case (strCheckVersionFlag)
                                        Case ("1")
                                            If (strBlueprintVersion <> strVersion) Then
                                                bCheckVersion = False
                                                strMessage = strMessage + "蓝图版本[PLM:" & IIf(String.IsNullOrEmpty(strBlueprintVersion), "", strBlueprintVersion) & ",MES:" & strVersion & "]"
                                            End If
                                        Case ("2")
                                            If (strPackageVersion <> strVersion) Then
                                                bCheckVersion = False
                                                strMessage = strMessage + "包规版本[PLM:" & IIf(String.IsNullOrEmpty(strPackageVersion), "", strPackageVersion) & ",MES:" & strVersion & "]"
                                            End If
                                    End Select
                                End If
                            End If
                        End If
                    Next
                    If (bCheckVersion = False) Then
                        strRtMessage = strMessage + "和PLM不一致"
                        Return False
                    Else
                        Return True
                    End If
                Else
                    strRtMessage = "料件[" & strPartid & "],PLM版本获取异常"
                    Return False
                End If
            End If
        Catch ex As Exception
            strRtMessage = "料件[" & strPartid & "],PLM版本获取异常"
            Return False
        End Try
    End Function

    Private Function FormatSQLString(ByVal Value As String) As String
        Return Value.Replace("'", "''")
    End Function

    Private Function FormatQuerySQLString(ByVal Value As String) As String
        Return "N'" & Value.Replace("'", "''") & "'"
    End Function

    Private Function InitializePrintParameter(ByVal PrintData As DataGridViewRow) As Boolean
        Dim Dtable As DataTable
        Try

            Dtable = DbOperateUtils.GetDataTable("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid from m_Mainmo_t as a join m_ComplementApplicationItem_t as b " _
                                        & " on b.Moid=a.Moid and b.Estateid in('1','2') join m_PartPack_t as c on a.PartID=c.Partid and c.Packid=b.Packid AND c.Packitem= b.Packitem and c.Usey='Y' " _
                                        & " where b.Ptaskid='" & PrintData.Cells("Ptaskid").Value.ToString & "'")
            If Dtable.Rows.Count > 0 Then
                LoadM.CodeRule = Dtable.Rows(0)!CodeRuleID.ToString
                LoadM.Packitem = PrintData.Cells("PackItem").Value.ToString
                LoadM.DisorderType = Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1)
                LoadM.PackingLevel = PrintData.Cells("PackingLevel").Value.ToString
                LoadM.Taskid = Dtable.Rows(0)!Ptaskid.ToString
                LoadM.DefaultMoid = Dtable.Rows(0)!Moid.ToString
                LoadM.DefaultLine = Dtable.Rows(0)!Lineid.ToString
                LoadM.CustID = Dtable.Rows(0)!Cusid.ToString
                LoadM.Factory = VbCommClass.VbCommClass.Factory
                LoadM.DeptJm = PrintData.Cells("djmdc").Value.ToString
                LoadM.vShift = PrintData.Cells("shift").Value.ToString
                LoadM.vLineJm = PrintData.Cells("LineJm").Value.ToString
                LoadM.vRequestDate = PrintData.Cells("Demandtime").Value.ToString
                LoadM.vIsprint = IIf(Me.ChkNotPrint.Checked, "Y", "N")
                LoadM.vCodeType = Dtable.Rows(0)!Packid.ToString
                LoadM.vVerNo = PrintData.Cells("FileVerNo").Value.ToString
                LoadM.vDriFlag = PrintData.Cells("DriFlag").Value.ToString
                LoadM.vBuildAttribute = PrintData.Cells("BuildAttribute").Value.ToString

                Dtable.Reset()
                Dtable = DbOperateUtils.GetDataTable("select distinct a.TAvcPart,a.CustPart,c.CusName,b.Deptid,f.djc,b.Lineid,b.Moqty,b.Ppidprtqty,b.PkgPrtqty,d.Packid,j.TemplatePath,e.PFormatID,e.PaperSize,e.ColNum,e.RowNum,d.Packlink,d.Multiy,d.MultiQty,d.Qty,d.StartInt,d.StartSn,d.EndInt,d.EndSn " _
                        & "from m_PartContrast_t as a join m_Mainmo_t as b on a.TAvcPart=b.PartID and b.Moid='" & LoadM.DefaultMoid & "' and b.FinalY='N' " _
                        & "left join m_Dept_t as f on b.Deptid=f.Deptid left join m_Customer_t as c on a.CusID=c.CusID join m_PartPack_t as d on a.TAvcPart=d.Partid and d.CodeRuleID='" & LoadM.CodeRule & "' and d.usey='Y'  and d.PackItem='" & PrintData.Cells("PackItem").Value.ToString & "'" _
                        & "left join m_SnPFormat_t as e on d.PFormatID=e.PFormatID  left join m_SnMFormat_t as j on d.PFormatID=j.PFormatID")
                If Dtable.Rows.Count > 0 Then
                    LoadD.CurrAVCPartID = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
                    LoadD.CurrMoid = LoadM.DefaultMoid
                    LoadD.PFormat = Dtable.Rows(0)("PFormatID").ToString
                    LoadD.PrintColNum = Int(IIf(Dtable.Rows(0)("ColNum").ToString <> "", Dtable.Rows(0)("ColNum").ToString, 0)) * CInt(Dtable.Rows(0)("RowNum").ToString)
                    LoadD.StartSn = Dtable.Rows(0)("StartSn").ToString
                    LoadD.EndSn = Dtable.Rows(0)("EndSn").ToString
                    LoadD.EndInt = Int(IIf(Dtable.Rows(0)("EndInt").ToString <> "", Dtable.Rows(0)("EndInt").ToString, "0"))
                    LoadD.StartInt = Int(IIf(Dtable.Rows(0)("StartInt").ToString <> "", Dtable.Rows(0)("StartInt").ToString, "0"))

                    PackItems = Dtable.Rows(0)("Packid").ToString
                    Packlink = Dtable.Rows(0)("Packlink").ToString
                    MoidAllNum = Int(IIf(Dtable.Rows(0)("Moqty").ToString <> "", Dtable.Rows(0)("Moqty").ToString, 0))
                    MoidPrinted = Int(IIf(Dtable.Rows(0)("PkgPrtqty").ToString <> "", Dtable.Rows(0)("PkgPrtqty").ToString, 0))

                    PrtArray.AvcPartid = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
                    PrtArray.CusName = Dtable.Rows(0)("CusName").ToString.Trim
                    PrtArray.Deptid = Dtable.Rows(0)("Deptid").ToString.ToUpper.Trim
                    PrtArray.Lineid = LoadM.vLineJm
                    PrtArray.Moid = LoadD.CurrMoid.ToUpper.Trim
                    PrtArray.Qty = IIf(Dtable.Rows(0)("Qty").ToString <> "", Dtable.Rows(0)("Qty").ToString, "1")     'IIf(Dtable("Qty").ToString <> "", Dtable("Qty").ToString, 0)
                    PrtArray.ConfigFlag = LoadM.vVerNo
                    PrtArray.DriFlag = LoadM.vDriFlag
                    PrtArray.BuildAttribute = LoadM.vBuildAttribute
                    PrtArray.DateCode = ""
                    PrtArray.WorkType = LoadM.vShift
                    PrtArray.ContainerNo = "##/##"
                    pFilePath = Dtable.Rows(0)("TemplatePath").ToString

                    If MarkBarTable(Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1), PrintData.Cells("PackItem").Value.ToString) = False Then
                        Exit Try
                    End If

                    SetArrayLbl(PrtArray.ToArray)

                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CheckPrintQty(ByVal PtaskId As String, ByVal Moid As String, ByVal PackId As String, ByVal DisorderType As String, ByVal PackItem As String) As Boolean
        Dim RecDr As DataTable = Nothing
        Dim Sqlstr As String
        'AND Packid=
        Sqlstr = "SELECT ISNULL(PrtQty,0) AS PrtQty,ISNULL(FinishPrintQty,0) AS FinishPrintQty FROM m_ComplementApplication_t WHERE Ptaskid='" + PtaskId + "' AND Moid='" + Moid + "'"

        RecDr = DbOperateUtils.GetDataTable(Sqlstr)
        If RecDr.Rows.Count > 0 Then
            Dim D As String = RecDr.Rows(0)("FinishPrintQty").ToString
            Dim S As String = RecDr.Rows(0)("PrtQty").ToString
            If (CInt(RecDr.Rows(0)("FinishPrintQty").ToString) + CInt(Me.txtPrintCount.Text.Trim)) > CInt(RecDr.Rows(0)("PrtQty").ToString) Then
                Return False
            Else
                Return True
            End If
        End If

        Return False
    End Function

    '建立條碼打印數組
    Private Function MarkBarTable(ByVal PackId As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        '建立條碼組成部分並分別賦初值
        Try
            Sqlstr = "SELECT DISTINCT a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128))," _
                   & " LEFT(IIF(a.f_codeid='PO',ISNULL(mo.PO,c.DValues),c.DValues),F_codelen)) as ShortName," _
                   & " a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
                   & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
                   & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
                   & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
                   & " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y'  and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "' " _
                   & " LEFT JOIN m_Mainmo_t mo on mo.partid = c.Partid  and mo.moid ='" & LoadD.CurrMoid.ToString.Trim() & "'" _
                   & " where a.CodeRuleID='" & LoadM.CodeRule.ToString & "'"

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

    '檢查樣式
    Private Function CheckStyle() As Boolean
        Dim Sqlstr As String
        Try
            LoadD.StyleID = MakeStyle() '產生樣式
            Sqlstr = "select StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'"
            Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

                If RecTable.Rows.Count > 0 Then
                    If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                        LoadD.BarCodeStyleMax = RecTable.Rows(0)("MaxSN").ToString
                        LoadD.CurrMaxInt = Int(RecTable.Rows(0)("MaxInt").ToString)

                        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'"
                        DbOperateUtils.ExecSQL(Sqlstr)
                    Else
                        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.CurrMaxInt = LoadD.StartInt
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    DbOperateUtils.ExecSQL(Sqlstr)
                End If
            End Using
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID.Replace("'", "''"))
            Throw ex
            Return False
        End Try
    End Function

    '例行檢查
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
        Return True
    End Function

    '產生樣式
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

    'Private Function GetTaskId() As String
    '    Dim SqlStr As String
    '    Dim DReader As DataTable
    '    Dim Taskid As String = ""
    '    Try

    '        SqlStr = "declare @Taskid varchar(11) " & _
    '            " select @Taskid=Ptaskid from m_ComplementApplicationItem_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " & _
    '            " if @@rowcount=0 begin set @Taskid='A' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " & _
    '            " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End  SELECT @Taskid AS Taskid"
    '        DReader = DbOperateUtils.GetDataTable(SqlStr)
    '        If DReader.Rows.Count > 0 Then
    '            Taskid = DReader.Rows(0).Item("Taskid").ToString
    '        End If

    '    Catch ex As Exception
    '        Taskid = ""
    '    End Try
    '    Return Taskid
    'End Function

    Private Function CheckDemand(ByVal DemandTime As String) As Boolean
        Dim strTemp As String = ""
        Try
            strTemp = FormatDateTime(DemandTime)
            Return True
        Catch
            Return False
        End Try
    End Function

#End Region

#Region "Bind"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable

        If ColComboBox.Name = "CboMoType" Then
            UserDg = DbOperateUtils.GetDataTable("select typeid,motype from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboDept" Then
            UserDg = DbOperateUtils.GetDataTable("select djc as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = DbOperateUtils.GetDataTable("Select (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "ComMoType" Then
            UserDg = DbOperateUtils.GetDataTable("Select  motype,typeid from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboSeries" Then
            UserDg = DbOperateUtils.GetDataTable(" SELECT ([SeriesID]+'---'+[SeriesName])SeriesName ,[SeriesID] FROM [m_Series_t] WHERE Usey='Y'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "SeriesName"
            ColComboBox.ValueMember = "SeriesID"
        End If
        UserDg = Nothing
    End Sub
#End Region

#Region "方法"

    Private Function CheckPrintQuantity(ByVal strPtaskid As String, ByVal strPrintQuantity As String, ByVal strRowId As String) As Boolean
        Try
            Dim dtTemp As DataTable
            dtTemp = DbOperateUtils.GetDataTable("SELECT ISNULL(PrtQty, 0) AS PrtQty, ISNULL(FinishPrintQty, 0) AS FinishPrintQty FROM m_ComplementApplicationItem_t WHERE Ptaskid='" & strPtaskid & "'")

            If (dtTemp.Rows.Count > 0) Then
                If (CInt(dtTemp.Rows(0).Item("PrtQty")) < CInt(strPrintQuantity) + CInt(dtTemp.Rows(0).Item("FinishPrintQty"))) Then
                    SetMessage("第" + strRowId + "行打印项目超过申请数量!")
                    Return False
                Else
                    Return True
                End If
            Else
                SetMessage("第" + strRowId + "行打印项目不存在!")
                Return False
            End If
        Catch ex As Exception
            SetMessage("检查第" + strRowId + "行打印数量异常!")
            Return False
        End Try
    End Function

    Private Function CheckStatusFlag(ByVal strMOid As String, ByVal strComplementApplicationId As String, ByVal strStatusType As String, ByVal strMessage As String) As Boolean
        Try
            Dim dtTemp As DataTable
            dtTemp = DbOperateUtils.GetDataTable("SELECT MOID FROM m_ComplementApplication_t WHERE MOID='" & strMOid &
                                                 "' AND ComplementApplicationId='" & strComplementApplicationId & "' AND StatusFlag IN (" & strStatusType & ")")

            If (dtTemp.Rows.Count > 0) Then
                Return True
            Else
                SetMessage(strMessage)
                Return False
            End If

        Catch ex As Exception
            SetMessage("执行工单补数申请单据状态检查异常!")
            Return False
        End Try

    End Function

    Private Sub SavaProductBOM(ByVal dvChildPart As DataView)
        Dim strChildSava As New StringBuilder
        Dim strPartType As String
        Dim strBomVersion As String
        Dim strItemNumber As String
        Try
            '后续关闭 AmountQty组件用量更新(配置数)
            '更改使用BOM检查
            strBomVersion = "V1.0"
            For i As Int16 = 0 To dvChildPart.Count - 1
                strItemNumber = i + 1
                If (Not String.IsNullOrEmpty(dvChildPart.Item(i).Item("IMA01").ToString) And Convert.ToInt16(dvChildPart.Item(i).Item("BMD03").ToString) <= 1) Then

                    If dvChildPart.Item(i).Item("PARENT_PART").ToString = dvChildPart.Item(i).Item("IMA01").ToString Then
                        strPartType = "0"
                    Else
                        strPartType = "1"
                    End If

                    strChildSava.Append(vbNewLine & "IF NOT EXISTS(SELECT COMPONENT_ID FROM M_BOM_T WHERE COMPONENT_ID='" & dvChildPart.Item(i).Item("IMA01").ToString & "' AND PRODUCT_ID='" & dvChildPart.Item(i).Item("PARENT_PART").ToString & "' ) BEGIN INSERT INTO M_BOM_T(COMPONENT_ID, PRODUCT_ID, VERSION, ITEM_NUMBER, PART_NUMBER, QUANTITY, NAME, DESCRIPTION, SPECIFICATION, " & _
                    "PART_TYPE, TYPE_NAME, REF_DES, FLAGS, MODIFIY_DATE) VALUES(N'" & dvChildPart.Item(i).Item("IMA01").ToString & "',N'" & dvChildPart.Item(i).Item("PARENT_PART").ToString & "',N'" & strBomVersion & "','" & strItemNumber & "',N'" & dvChildPart.Item(i).Item("IMA01").ToString & "',N'" & dvChildPart.Item(i).Item("BMB06").ToString & "' " & _
                    ",N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "',N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "',N'" & strPartType & "',N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") & "',NULL, '1','" & dvChildPart.Item(i).Item("MODIFYDATE").ToString & "') END ")
                End If
            Next
            If (Not String.IsNullOrEmpty(strChildSava.ToString)) Then
                DbOperateUtils.ExecSQL(strChildSava.ToString())
            End If
            strChildSava = Nothing
        Catch ex As Exception
            strChildSava = Nothing
        End Try
    End Sub


    Private Function GetVersion(ByVal parPN As String) As String
        Dim lsSQL As String = ""
        GetVersion = ""
        Try
            lsSQL = " SELECT ISNULL(VERSION,'') as VERSION  FROM m_PartContrast_t WHERE TAvcPart  = '" & parPN & "'"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetVersion = o_dt.Rows(0).Item("VERSION").ToString
                Else
                    GetVersion = ""
                End If
            End Using
            Return GetVersion
        Catch ex As Exception
        Finally
        End Try
    End Function

    Private Sub LoadControlData()
        Me.dtpEndDate.Value = Now.AddDays(-1)
        Me.dtpStartDate.Value = Now.AddDays(1)

        Dim DateT As New DateTime
        Dim RecTable As DataTable
        RecTable = DbOperateUtils.GetDataTable("select getdate() as nowtime")
        If RecTable.Rows.Count > 0 Then
            DateT = CDate(RecTable.Rows(0)!nowtime.ToString)
        End If
        Me.LblPrintDate.Text = DateT.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        PrtArray.NowDate = CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString
        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text.ToString).ToString("MM").ToString
    End Sub

    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                Me.ToolDelete.Enabled = IIf(Me.ToolDelete.Tag.ToString = "YES", True, False)
                Me.ToolCheck.Enabled = IIf(Me.ToolCheck.Tag.ToString = "YES", True, False)
                Me.ToolCommit.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolBack.Enabled = False
                Me.ToolPrt.Enabled = True
                Me.ToolMove.Enabled = IIf(Me.ToolMove.Tag.ToString = "YES", True, False)

                Me.txtMOId.Text = ""
                Me.TxtPartid.Text = ""
                Me.txtQty.Text = ""
                Me.TxtTaskDesc.Text = ""
                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = True
                Me.txtQty.Enabled = False
                Me.txtPrintCount.Enabled = True
                Me.TxtTaskDesc.Enabled = False

            Case 1    '新增
                Me.ToolNew.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.ToolMove.Enabled = False
                Me.ToolDelete.Enabled = False
                Me.ToolCheck.Enabled = False

                Me.txtMOId.Text = ""
                Me.TxtPartid.Text = ""
                Me.txtQty.Text = ""
                Me.TxtTaskDesc.Text = ""

                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.txtPrintCount.Enabled = False
                Me.TxtTaskDesc.Enabled = True

            Case 2  '修改
                Me.ToolNew.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.ToolMove.Enabled = False
                Me.ToolDelete.Enabled = False

                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.txtPrintCount.Enabled = True
                Me.TxtTaskDesc.Enabled = True

        End Select
    End Sub

    Private Sub ClearObject()
        Me.txtMOId.Text = ""
        strMOID = ""
        Me.TxtPartid.Text = ""
        Me.txtBlueprintVersion.Text = ""
        Me.txtPackageVersion.Text = ""
        Me.txtPO.Text = "" 'cq 20160718

        Me.dgvLotList.Rows.Clear()
        Me.dgvPrintList.Rows.Clear()
        Me.dgvRuleList.Rows.Clear()
    End Sub

    Private Sub ClearQueryObject()
        Me.txtMOId.Text = ""
        Me.TxtPartid.Text = ""
        Me.txtPrintCount.Text = ""
    End Sub

    Private Sub ClearQuery()

        Me.txtMOId.Text = ""
        Me.txtQty.Text = ""
        Me.TxtPartid.Text = ""
        Me.DtMoNeedTime.Text = ""
        Me.txtMOId.Focus()
        Me.dgvLotList.Rows.Clear()
        Me.dgvPrintList.Rows.Clear()
        Me.dgvRuleList.Rows.Clear()

    End Sub

    '取得打印工单
    Private Sub GetLot()
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" SELECT ComplementApplicationId, m_Mainmo_t.Moid,m_Mainmo_t.PartID,m_ComplementApplication_t.Outqty, m_Mainmo_t.Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, ")
        Sqlstr.Append(" m_Dept_t.DQC, m_Mainmo_t.Lineid, m_ComplementApplication_t.CHECKTEXT, CONVERT(VARCHAR(10),m_Mainmo_t.Plandate,120) AS Plandate, m_Customer_t.CusName, m_ComplementApplication_t.Createuser, m_ComplementApplication_t.Createtime, m_ComplementApplication_t.Remark, ")
        Sqlstr.Append(" m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime, m_ComplementApplication_t.BlueprintVersion, m_ComplementApplication_t.PackageVersion, m_ComplementApplication_t.PO, m_SettingParameter_t.PARAMETER_NAME AS StatusFlagText, m_ComplementApplication_t.CheckUserId, m_ComplementApplication_t.CheckTime ")
        Sqlstr.Append(" FROM m_Mainmo_t INNER JOIN m_ComplementApplication_t ON m_ComplementApplication_t.MOID=m_Mainmo_t.MOID ")
        Sqlstr.Append(" INNER JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE=m_ComplementApplication_t.StatusFlag AND PARAMETER_CODE = 'SStatusFlagText'  ")
        Sqlstr.Append(" LEFT JOIN m_Customer_t ON m_Customer_t.CusID=m_Mainmo_t.Cusid ")
        Sqlstr.Append(" LEFT JOIN m_Dept_t ON m_Dept_t.deptid=m_Mainmo_t.Deptid ")
        Sqlstr.Append(" WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' ")
        Sqlstr.Append("  and m_ComplementApplication_t.CreateTime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)")

        If Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
            Sqlstr.Append(" and m_Mainmo_t.moid like '%" & Me.txtMOId.Text.ToString.Trim & "%'")
        End If

        If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
            Sqlstr.Append(" and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'")
        End If

        Sqlstr.Append(" ORDER BY m_ComplementApplication_t.CreateTime DESC")

        LoadData(Sqlstr.ToString, Me.dgvLotList)
    End Sub

    '取得工单打印清单
    Private Sub GetLotPrintList(ByVal strMOid As String, ByVal strComplementApplicationId As String, ByVal strPartId As String, ByVal strQty As String, ByVal QueryFlag As Boolean)

        Sqlstr.Remove(0, Sqlstr.Length)

        If (QueryFlag) Then
            Sqlstr.Append(" SELECT distinct m_ComplementApplicationItem_t.Ptaskid, m_Mainmo_t.Moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append(" m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_ComplementApplicationItem_t.Packitem,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append(" m_Mainmo_t.Moqty AS Qty,m_ComplementApplicationItem_t.PrtQty*ISNULL(m_ComplementApplicationItem_t.ConfigurationQty,1) PrintQty, ISNULL(m_ComplementApplicationItem_t.FinishPrintQty,0) AS FinishPrintQty,ISNULL(m_ComplementApplicationItem_t.ConfigurationQty,1) AS ConfigurationQty, m_PartPack_t.PrinterName, ")
            Sqlstr.Append(" case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append(" m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" djmdc,shift,linejm,convert(varchar(10),m_ComplementApplicationItem_t.Demandtime,120) as Demandtime,(FileVerNo + iif(isnull(m_ComplementApplicationItem_t.Remark,'')='','','#'+ m_ComplementApplicationItem_t.Remark ))FileVerNo,m_PartPack_t.Remark,DriFlag,BuildAttribute, case m_ComplementApplicationItem_t.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, m_Mainmo_t.PartID as applyPart, ISNULL(m_PartPack_t.VersionType, '0') + '-' + PartVersionType.PARAMETER_NAME AS VersionTypeText ")
            Sqlstr.Append(" FROM m_Mainmo_t INNER JOIN m_ComplementApplicationItem_t ON m_Mainmo_t.Moid= m_ComplementApplicationItem_t.Moid AND m_ComplementApplicationItem_t.ComplementApplicationId='" & strComplementApplicationId & "' ")
            Sqlstr.Append(" INNER JOIN m_PartContrast_t ON m_PartContrast_t.TAvcPart=m_Mainmo_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart ")
            Sqlstr.Append(" INNER JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("    m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND  m_PartPack_t.Packid=m_ComplementApplicationItem_t.Packid AND m_PartPack_t.Packitem=m_ComplementApplicationItem_t.Packitem")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Dept_t on m_Mainmo_t.Deptid=m_Dept_t.Deptid and m_Mainmo_t.factory=m_Dept_t.factoryid ")
            Sqlstr.Append(" LEFT JOIN Deptline_t on m_Dept_t.deptid=Deptline_t.deptid and m_ComplementApplicationItem_t.lineid=Deptline_t.lineid ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            Sqlstr.Append(" INNER JOIN m_SettingParameter_t PartVersionType ON PartVersionType.PARAMETER_VALUE = m_PartPack_t.VersionType AND PartVersionType.PARAMETER_CODE = 'PartVersionType' ")
            Sqlstr.Append(" WHERE m_Mainmo_t.Moid='" & strMOid & "' AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' ORDER BY m_PartContrast_t.TAvcPart ASC ")
        Else
            Sqlstr.Append(" SELECT distinct m_SnAssign_t.Ptaskid,m_SnAssign_t.moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append("     m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_PartPack_t.Packitem, ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append("     " + strQty + " AS Qty,CONVERT(INT,'" + strQty + "')* CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE '1' END AS PrintQty, CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE '1' END AS ConfigurationQty, 0 AS FinishPrintQty, m_PartPack_t.PrinterName, ")
            Sqlstr.Append("     case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append("     m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" '' djmdc, '' shift, ''linejm, '' as Demandtime, '' FileVerNo, m_PartPack_t.Remark, '' AS VersionTypeText, '' DriFlag, ''BuildAttribute, '0-待保存' as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, '" + strPartId + "' as applyPart")
            Sqlstr.Append(" FROM m_PartContrast_t ")
            Sqlstr.Append(" INNER JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' ")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            Sqlstr.Append(" join m_SnAssign_t on m_SnAssign_t.Packid=m_PartPack_t.Packid and m_SnAssign_t.Packitem=m_PartPack_t.Packitem and m_SnAssign_t.moid='" + strMOid + "' ")
            Sqlstr.Append(" WHERE m_PartContrast_t.TAvcPart='" + strPartId + "' AND m_PartContrast_t.PAvcPart= TAvcPart")
            Sqlstr.Append(" ORDER BY m_PartContrast_t.TAvcPart ASC")

        End If

        LoadData(Sqlstr.ToString, Me.dgvPrintList)
    End Sub

    '取得工单打印项参数配置
    Private Sub GetPrintItemParameter(ByVal strMOid As String, ByVal strPartId As String, ByVal strPackid As String, ByVal strPactItem As String)
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" select distinct a.F_codeID,c.F_codename, IIF(a.f_codeid ='PO', ISNULL(MO.PO,a.DValues), a.DValues )DValues")
        Sqlstr.Append(" from m_SnPartSet_t as a  ")
        Sqlstr.Append(" join m_PartPack_t as b on a.partid=b.partid and a.Packid=b.Packid and a.Packitem=b.Packitem  ")
        Sqlstr.Append(" join m_SnRuleD_t as c on a.F_codeID=c.F_codeID and b.CodeRuleID=c.CodeRuleID  ")
        Sqlstr.Append(" join m_Mainmo_t mo on a.partid = mo.PartID and mo.moid ='" & strMOid & "'")
        Sqlstr.Append(" where a.Partid='" & strPartId & "' and a.Packid='" & strPackid & "' and a.Packitem='" & strPactItem & "' order by a.F_codeID")
        LoadData(Sqlstr.ToString, Me.dgvRuleList)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim DReader As DataTable
        Try
            dgvName.Rows.Clear()
            DReader = DbOperateUtils.GetDataTable(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("PrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            If DReader.Rows.Count > 0 Then
                If dgvName Is Me.dgvLotList Then
                    For rowIndex As Integer = 0 To DReader.Rows.Count - 1
                        dgvName.Rows.Add(DReader.Rows(rowIndex).Item("ComplementApplicationId").ToString, DReader.Rows(rowIndex).Item("Moid").ToString,
                                  DReader.Rows(rowIndex).Item("Partid").ToString, DReader.Rows(rowIndex).Item("Moqty").ToString, DReader.Rows(rowIndex).Item("Outqty").ToString,
                                  DReader.Rows(rowIndex).Item("Ppidprtqty").ToString, DReader.Rows(rowIndex).Item("PpidprtCount").ToString,
                                  DReader.Rows(rowIndex).Item("Pkgprtqty").ToString, DReader.Rows(rowIndex).Item("Lineid").ToString,
                                  DReader.Rows(rowIndex).Item("BlueprintVersion").ToString, DReader.Rows(rowIndex).Item("PackageVersion").ToString,
                                  DReader.Rows(rowIndex).Item("PO").ToString, DReader.Rows(rowIndex).Item("CHECKTEXT").ToString, DReader.Rows(rowIndex).Item("StatusFlagText").ToString,
                                  DReader.Rows(rowIndex).Item("DemandInfo").ToString, DReader.Rows(rowIndex).Item("Plandate").ToString, DReader.Rows(rowIndex).Item("DQC").ToString,
                                  DReader.Rows(rowIndex).Item("CusName").ToString, DReader.Rows(rowIndex).Item("demandTime").ToString, DReader.Rows(rowIndex).Item("Createuser").ToString,
                                  DReader.Rows(rowIndex).Item("Createtime").ToString, DReader.Rows(rowIndex).Item("Remark").ToString, DReader.Rows(rowIndex).Item("CheckUserId").ToString,
                                  DReader.Rows(rowIndex).Item("CheckTime").ToString)
                    Next
                ElseIf dgvName Is Me.dgvRuleList Then
                    For rowIndex As Integer = 0 To DReader.Rows.Count - 1
                        dgvName.Rows.Add(DReader.Rows(rowIndex).Item("F_codeID").ToString, DReader.Rows(rowIndex).Item("F_codename").ToString,
                                         DReader.Rows(rowIndex).Item("DValues").ToString)
                    Next

                ElseIf dgvName Is Me.dgvPrintList Then
                    For rowIndex As Integer = 0 To DReader.Rows.Count - 1
                        If (SqlClassM.CheckPrintersList(DReader.Rows(rowIndex).Item("PrinterName").ToString)) Then
                            PrintName = DReader.Rows(rowIndex).Item("PrinterName").ToString
                        Else
                            PrintName = ""
                        End If

                        If (Microsoft.VisualBasic.Left(DReader.Rows(rowIndex).Item("LabelType").ToString, 1) = "C" Or
                            Microsoft.VisualBasic.Left(DReader.Rows(rowIndex).Item("DisorderType").ToString, 1) = "C" Or
                            Microsoft.VisualBasic.Left(DReader.Rows(rowIndex).Item("DisorderType").ToString, 1) = "P") Then
                            If ((CInt(DReader.Rows(rowIndex).Item("PrintQTY").ToString) - CInt(DReader.Rows(rowIndex).Item("FinishPrintQty").ToString)) Mod CInt(DReader.Rows(rowIndex).Item("PackingQty").ToString) = 0) Then
                                FCLNumber = (CInt(DReader.Rows(rowIndex).Item("PrintQTY").ToString) - CInt(DReader.Rows(rowIndex).Item("FinishPrintQty").ToString)) / CInt(DReader.Rows(rowIndex).Item("PackingQty").ToString)
                                TrunkNumber = 0
                            Else
                                FCLNumber = (CInt(DReader.Rows(rowIndex).Item("PrintQTY").ToString) - CInt(DReader.Rows(rowIndex).Item("FinishPrintQty").ToString)) / CInt(DReader.Rows(rowIndex).Item("PackingQty").ToString)
                                TrunkNumber = 1
                            End If
                        Else
                            FCLNumber = 0
                            TrunkNumber = 0
                        End If

                        dgvName.Rows.Add(True, DReader.Rows(rowIndex).Item("Ptaskid").ToString, DReader.Rows(rowIndex).Item("Moid").ToString, DReader.Rows(rowIndex).Item("TAvcPart").ToString,
                                         DReader.Rows(rowIndex).Item("PAvcPart").ToString, DReader.Rows(rowIndex).Item("LabelType").ToString, DReader.Rows(rowIndex).Item("PackItem").ToString,
                                         DReader.Rows(rowIndex).Item("FileVerNo").ToString, DReader.Rows(rowIndex).Item("VersionTypeText").ToString, DReader.Rows(rowIndex).Item("Remark").ToString,
                                         DReader.Rows(rowIndex).Item("Qty").ToString, DReader.Rows(rowIndex).Item("PrintQTY").ToString, DReader.Rows(rowIndex).Item("FinishPrintQty").ToString,
                                         DReader.Rows(rowIndex).Item("ConfigurationQty").ToString, PrintName, DReader.Rows(rowIndex).Item("PackingQty").ToString, FCLNumber, TrunkNumber,
                                         DReader.Rows(rowIndex).Item("KLabelid").ToString, DReader.Rows(rowIndex).Item("Description").ToString, DReader.Rows(rowIndex).Item("PrintStatus").ToString,
                                         DReader.Rows(rowIndex).Item("DisorderType").ToString, DReader.Rows(rowIndex).Item("djmdc").ToString, DReader.Rows(rowIndex).Item("shift").ToString,
                                         DReader.Rows(rowIndex).Item("linejm").ToString, DReader.Rows(rowIndex).Item("Demandtime").ToString, DReader.Rows(rowIndex).Item("DriFlag").ToString,
                                         DReader.Rows(rowIndex).Item("BuildAttribute").ToString, DReader.Rows(rowIndex).Item("Estateid").ToString, DReader.Rows(rowIndex).Item("PackingLevel").ToString,
                                         DReader.Rows(rowIndex).Item("applyPart").ToString)
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex '出错
        End Try
    End Sub

    'Private Sub BindPrintList(ByVal strSQL As String, ByVal dgvName As DataGridView)
    '    Try
    '        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL)
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)

        If (Not PrintData Is Nothing) Then
            If InitializePrintParameter(PrintData) Then
                Exit Sub
            End If

            If (Microsoft.VisualBasic.Left(PrintData.Cells("Estateid").Value.ToString, 1) = "1") Then
                DbOperateUtils.ExecSQL("Update m_ComplementApplicationItem_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            End If

            Select Case (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1))
                Case "A"
                    BuildABarCode(PrintData)
                Case "S", "K"
                    BuildSBarCode(PrintData)
                Case "C"
                    BuildCBarCode(PrintData)
                Case "P"
                    BuildSBarCode(PrintData)
                Case "N"
                    BuildNBarCode(PrintData)
            End Select
        Else
            SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
        End If
    End Sub

    '數組傳遞參數
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

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

    Private Sub FormatMantissaBoxQty(ByVal MantissaQty As Int16)
        Try
            If (Not BarCodePartTable Is Nothing) Then
                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
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


    ' ''' <summary>
    ' ''' DataGridView数据导出excel 公共方法
    ' ''' </summary>
    ' ''' <param name="DgMoData">DataGridView控件ID</param>
    ' ''' <param name="tbname">导出文件名称</param>
    ' ''' <remarks></remarks>
    'Private Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal tbColName As String = "")
    '    Try


    '        If DgMoData.RowCount = 0 Then
    '            MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim getTable As New DataTable
    '        getTable.TableName = tbname

    '        getTable = CType(DgMoData.DataSource, DataTable)

    '        '导出CSV文件格式，以便用户查询，以,号区分

    '        If Not Directory.Exists("c:\MesExport") Then
    '            Directory.CreateDirectory("c:\MesExport")
    '        End If

    '        Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

    '        Dim wValue As String = ""                   '保存每行的徝
    '        Dim nColqty As Integer = 0
    '        Dim bColName As Boolean = False             '是否写了标题行
    '        Dim wColName As String = ""                 '标题行的内容

    '        For Each r As DataRow In getTable.Rows

    '            nColqty = 0

    '            For Each c As DataColumn In getTable.Columns
    '                '写入标题行
    '                If bColName = False Then
    '                    If wColName = "" Then
    '                        wColName = c.ColumnName.Replace(",", "，")
    '                    Else
    '                        wColName = wColName + "," + c.ColumnName.Replace(",", "，")
    '                    End If
    '                End If

    '                '写入每行的值
    '                If nColqty = 0 Then
    '                    wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
    '                Else
    '                    wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
    '                End If
    '                nColqty = nColqty + 1

    '            Next
    '            If Not String.IsNullOrEmpty(tbColName) AndAlso bColName = False Then
    '                Swriter.WriteLine(tbColName)
    '                bColName = True
    '            Else
    '                If wColName <> "" And bColName = False Then
    '                    Swriter.WriteLine(wColName)
    '                    bColName = True

    '                End If
    '            End If


    '            Swriter.WriteLine(wValue)

    '        Next
    '        Swriter.Close()

    '        MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub



#End Region

#Region "打印"

    Private Sub BuildABarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If
            AMainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildABarCode", "sys")
        End Try
    End Sub

#Region "多流水码样式程式"

    '產生樣式
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

    '檢查樣式 oxf20151116
    Private Function CheckAtrrStyle() As Boolean
        Dim Sqlstr As String
        Try
            PubAtrributeStype = MakeAtrributeStyle()
            Sqlstr = "select StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & PubAtrributeStype & "'"
            Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)


                If RecTable.Rows.Count > 0 Then
                    If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                        LoadD.AtrrBarCodeStyleMax = RecTable.Rows(0)("MaxSN").ToString
                        LoadD.AtrrCurrMaxInt = Int(RecTable.Rows(0)("MaxInt").ToString)
                        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & PubAtrributeStype & "'"
                        DbOperateUtils.ExecSQL(Sqlstr)
                    Else
                        MsgBox("标签中第二对象的流水码正在打印中...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.AtrrBarCodeStyleMax = ""
                    LoadD.AtrrCurrMaxInt = 0
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & PubAtrributeStype & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & PubAtrributeStype & "','0','','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    DbOperateUtils.ExecSQL(Sqlstr)
                End If
            End Using
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID)
            Throw ex
            Return False
        End Try
    End Function

#End Region

    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            ''********************************************************
            Dim Sqlstr As String = "select ISNULL(IsMultCode,'') IsMultCode from m_partpack_t a WITH(NOLOCK) join m_SnRuleM_t b WITH(NOLOCK) " & _
                " on a.CodeRuleID=b.CodeRuleID  where Partid='" & PrintData.Cells("PartId").Value.ToString() & "' and " & _
                " Packid='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' and a.Usey='Y'"
            Dim Mread As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If Mread.Rows.Count > 0 Then
                IsmullitStyle = Mread.Rows(0)!IsMultCode
            End If
            If IsmullitStyle = "Y" Then
                If CheckAtrrStyle() = False Then
                    Exit Sub
                End If
            End If
            ''********************************************************

            MainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString, PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildSBarCode", "sys")
        End Try
    End Sub

    Private Sub BuildCBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If Icount = 2 Then Exit For
                If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
                    If Me.CboShift.Text = "白班" Then
                        WorkStr = "D"
                    Else
                        WorkStr = "N"
                    End If
                    BarCodePartTable.Rows(I)("shortname") = WorkStr
                    Icount = Icount + 1
                End If
            Next

            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            CMainMarkSCode(PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
        End Try
    End Sub

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

#Region "有序条码"

    '生成序號並打印條碼
    Private Function MainMarkSCode(ByVal printName As String, ByVal taskId As String, ByVal PrintData As DataGridViewRow) As Boolean

        Dim I, N As Int16
        Dim SqlStr As New StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim AtrrrCurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim GPParameters As String = ""

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

            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)

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
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)

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

                TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel,GPParameters) values('" &
                              TextHandle.DeleteUnVisibleChar(AxTempCode.ToString) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine &
                              "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'B' then 'S' when 'D' then 'S' when 'K' then 'K' end,'1','Y','" &
                              SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" &
                              LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "','" & GPParameters & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            End If
            SqlStr.Append(vbNewLine & "update m_Mainmo_t set Ppidprtqty=isnull(Ppidprtqty,0)+" & CurrNum & ",PpidprtCount=PpidprtCount+" & LoadD.CurrPrintNum & "*" & PrtArray.Qty & " where Moid='" & LoadD.CurrMoid & "'")
            SqlStr.Append(vbNewLine & "update m_ComplementApplicationItem_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'D' then 'S' when 'K' then 'K' end,'" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")

            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
            End If

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString())
                If ChkNotPrint.Checked = True Then
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
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
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

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

#Region "附属标签打印"

    '生成序號並打印條碼
    Private Function AMainMarkSCode(ByVal PrintName As String, ByVal taskId As String) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0
        Try
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            '
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString
                If N = LoadD.PrintColNum Then
                    NModlePrintGenRecord("N", False, 0)
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    NModlePrintGenRecord("N", False, 0)
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next

            Dim BarFlag As String = LoadD.StyleID
            SqlStr &= ControlChars.CrLf & ABarCodePrint(BarFlag, PrintStr.ToString)
            SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & BarFlag.Replace("'", "''") & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & TextHandle.DeleteUnVisibleChar(AxTempCode.ToString.Replace("'", "''")) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "','1','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end "
            SqlStr &= " update m_ComplementApplicationItem_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'"

            If SqlStr <> "" Then
                DbOperateUtils.ExecSQL(SqlStr)
                If ChkNotPrint.Checked = True Then
                    FileToBarCodePrint(pFilePath, PrintName)
                End If
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID.Trim.Replace("'", "''"))
        End Try
    End Function

    Private Function ABarCodePrint(ByVal BarFlag As String, ByVal PrintStr As String) As String

        Try

            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag
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

            For k As Int16 = 0 To Str.Length - 1
                If (k = 0) Then
                    SqlStr.Append(FixStr)
                End If

                SpaceStr = ""
                BarValue = Str(k).ToString.Trim.Split(vbNewLine) ''
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1

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

                If (k = 0) Then
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
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try

    End Function

#End Region

#Region "无序打印"
    '生成序號並打印條碼
    Private Function NMainMarkSCode(ByVal PrintName As String, ByVal UseY As String, ByVal DisorderType As String, ByVal taskId As String, ByVal PackItem As String, ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0
        Dim BarFlag As String = LoadD.StyleID
        Try
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)

            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    LoadD.StyleID = MakeStyle()
                    SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & LoadD.StyleID & "')  begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & LoadD.StyleID & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & LoadD.MantissaBoxQty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & DisorderType & "','" & LoadM.PackingLevel & "')  end "
                    SqlStr &= " IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & LoadD.StyleID & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty,DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & LoadD.StyleID & "','" & LoadD.MantissaBoxQty & "','" & DisorderType & "') End "
                    PrintPart(1, 1) = LoadD.StyleID
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                If N = LoadD.PrintColNum Then
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next

            If UseY = "Y" Then
                LoadD.CurrMaxInt = LoadD.CurrMaxInt + LoadD.CurrPrintNum
                SqlStr &= ControlChars.CrLf & " update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.CurrMaxInt & "',IsUsed='N' where StyleID='" & BarFlag & "'"
                MoidPrinted += LoadD.CurrPrintNum
                SqlStr &= ControlChars.CrLf & " insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime,sBarCode) " & _
                                                                  " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','N','" & BarFlag & "'," & PrtArray.Qty & "," & LoadD.CurrPrintNum & ",'','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & BarFlag & "')"
            End If

            SqlStr &= ControlChars.CrLf & NBarCodePrint(BarFlag, PrintStr.ToString)
            If (LoadD.CurrPrintNum > 1 Or LoadD.MantissaFlag = False) Then
                SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & BarFlag & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & BarFlag & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & PrtArray.Qty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end "
                SqlStr &= " IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & BarFlag & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel, SBarCode,qty, DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & BarFlag & "','" & PrtArray.Qty & "', '" & DisorderType & "') End "
            End If

            If DisorderType = "C" Then
                SqlStr &= " update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'"
            End If

            SqlStr &= " DECLARE @PrinteQuantity FLOAT, @NotPrinteQuantity FLOAT, @CustomerOrderDetailID VARCHAR(32) "
            SqlStr &= " SET @PrinteQuantity = '" & CurrNum & "' "
            SqlStr &= " IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0) "
            SqlStr &= " BEGIN WHILE(@PrinteQuantity > 0) BEGIN "
            SqlStr &= " IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0) "
            SqlStr &= " BEGIN SELECT TOP 1 @CustomerOrderDetailID = CustomerOrderDetailID, @NotPrinteQuantity = ExportQuantity - PrinteQuantity "
            SqlStr &= " FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0 ORDER BY CreateTime ASC "

            SqlStr &= " IF (@PrinteQuantity > @NotPrinteQuantity) BEGIN UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @NotPrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID "
            SqlStr &= " SET @PrinteQuantity = @PrinteQuantity - @NotPrinteQuantity End ELSE BEGIN UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @PrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID "
            SqlStr &= " SET @PrinteQuantity = 0 End End ELSE BEGIN SET @PrinteQuantity = 0 End End End "

            SqlStr &= " UPDATE m_ComplementApplicationItem_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid ='" & PrintData.Cells("PtaskId").Value.ToString & "' "

            If SqlStr <> "" Then
                DbOperateUtils.ExecSQL(SqlStr)
                If ChkNotPrint.Checked = True Then
                    FileToBarCodePrint(pFilePath, PrintName)
                End If
            End If

            If (LoadD.MantissaFlag) Then
                LoadM.OpenLock(BarFlag)
            End If
            LoadM.OpenLock(LoadD.StyleID)

            Return True
        Catch ex As Exception
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
            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag
            Dim Str As String() = PrintStr.Split(StrSplit, StringSplitOptions.RemoveEmptyEntries)
            Dim FixStr As String
            Dim BarValue As String()
            Dim SqlStr As New StringBuilder
            Dim strPrintRecard As String

            Dim SpaceStr As String
            Dim strSpace As String
            Dim TxtFileStr As New StringBuilder

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

                BarValue = Str(k).Trim.ToString.Split(vbNewLine)
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1

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
                TxtFileStr.Replace("##/##", String.Format("{0}/{1}", (k + 1).ToString, LoadD.CurrPrintNum.ToString))

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
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try

    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub NModlePrintGenRecord(ByVal UseY As String, ByVal MantissaFlag As Boolean, ByVal MantissaBoxQty As Int16)

        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Try
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString

                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1

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
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                PrintStr.Append(PrintPart(1, 1))
                            Else
                                PrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                PrintStr.Append(vbNewLine & "This is test")
                            Else
                                PrintStr.Append(vbNewLine & PrintPart(2, 1))
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                    End If
                End Using
            Next
            Mreader = Nothing
            Dtable = Nothing
        Catch ex As Exception
            Mreader = Nothing
            Dtable = Nothing
            Throw ex
        End Try

    End Sub

#End Region

#Region "包装打印"
    '生成序號並打印條碼
    Private Function CMainMarkSCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""

        Try
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)

            For I = 1 To LoadD.CurrPrintNum
                CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                If CurrSBCode.ToString = "" Then
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If

                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & LoadD.MantissaBoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & LoadD.MantissaBoxQty & "')")
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                If N = LoadD.PrintColNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0S
                End If

                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & PrtArray.Qty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
            SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & "" & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())

            SqlStr.Append(vbNewLine & " update m_ComplementApplicationItem_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                If ChkNotPrint.Checked = True Then
                    FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").Value.ToString)
                End If
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID)
        End Try
    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub CModlePrintGenRecord()
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
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"

                        For I = 0 To TempView.Count - 1

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
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then

                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(PrintPart(1, 1))
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        If Areaid.ToLower = "barlabel1" Then
                            nPrintStr.Append(vbNewLine & PrintPart(2, 1))
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
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

            Mreader = Nothing
            Dtable = Nothing
        Catch ex As Exception
            Mreader = Nothing
            Dtable = Nothing
            Throw ex
        End Try

    End Sub

#End Region

#End Region
  

End Class