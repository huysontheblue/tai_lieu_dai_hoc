'--条码打印作业
'--Create by :　安明禹
'--Create date :　2017/3/21
'--Update date :  
'--Ver : V01j

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

Public Class FrmListPrintLine

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
    Private m_CheckAqci120 As String = String.Empty
    Private strPrintNumber As String = "0"
    Private strConfigurationQty As String = "0"
    Private strGroupPrintFlag As String = "N"  '附属条码是否组合打印

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

        '檢視用戶權限()
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        SetStatus(opFlag)

        LoadControlData()
        ClearObject()

        Me.chbPrintListSelect.Checked = True
        Me.txtMOId.Focus()
    End Sub

    Private Sub FrmListPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

#End Region

#Region "菜单事件"
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
        Dim iFirstSelectedRowIndex As Integer = -1
        Try
            Me.lblMessage.Text = String.Empty
            If dgvPrintList.RowCount > 0 Then
                If (CheckPrint(Me.dgvPrintList)) Then
                    Dim strErrorMessage As String
                    If (Not CheckVersion(Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ColPartid").Value.ToString, strErrorMessage)) Then
                        If (MessageBox.Show(strErrorMessage, "PLM版本检查", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Cancel) Then
                            Me.ToolPrt.Enabled = True
                            Exit Sub
                        End If
                    End If

                    Dim index As Integer
                    Dim chkTemp As DataGridViewCheckBoxCell

                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            iFirstSelectedRowIndex = i
                            Exit For
                        End If
                    Next
                    strPrintNumber = Me.txtPrintCount.Text.Trim
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            ' If Me.chkConfirm.Checked = True Then
                            ' PrintBarCode(dgvPrintList.Rows(i), i + 1)
                            'End If     
                            If Me.chkConfirm.Checked = True AndAlso i > iFirstSelectedRowIndex Then
                                If (MessageBox.Show("继续下一个标签打印", "标签确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                                    PrintBarCode(dgvPrintList.Rows(i), i + 1)
                                Else
                                    Application.DoEvents()
                                End If
                            Else
                                TxtTaskDesc.Text = "当前抛出" & txtPrintCount.Text & " PCS"
                                PrintBarCode(dgvPrintList.Rows(i), i + 1)
                            End If
                        End If
                    Next
                    If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update
                        index = dgvLotList.CurrentCell.RowIndex
                        DbOperateUtils.ExecSQL("UPDATE M_MAINMO_T SET CHECKTEXT=N'打印完成' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "'")
                    End If
                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        InitJxPar()
                        Me.ToolPrt.Enabled = True
                        Exit Sub
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

    ', Timer.Tick
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

    Private Sub ToolPrintLoak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrintLoak.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Conn.ExecSql("UPDATE m_SnStyle_t SET IsUsed='N' WHERE IsUsed='Y'")
        Conn = Nothing
    End Sub

    Private Sub ToolCommitInfo_Click(sender As Object, e As EventArgs) Handles ToolCommitInfo.Click
        Try
            SetMessage("")
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                SetMessage("请选择提交需求工单")
                Exit Sub
            End If

            If (String.IsNullOrEmpty(Me.txtDemandInfo.Text.Trim)) Then
                SetMessage("提交需求信息不能为空")
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strMOid As String = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("Colmoid").Value

            strSQL.AppendLine(" INSERT INTO m_MODemand_t(MOID, DemandNote, CreateUserId, CreateTime)VALUES('" & strMOid & "', N'" & Me.txtDemandInfo.Text.Trim.Replace("'", "''") & "' , '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
            strSQL.AppendLine(" UPDATE m_Mainmo_t SET DemandInfo = N'" & Me.txtDemandInfo.Text.Trim & "', CHECKTEXT = N'新增需求' WHERE MOID='" & strMOid & "'")

            DbOperateUtils.ExecSQL(strSQL.ToString())
            GetLot()
        Catch ex As Exception
            SetMessage("保存失败!" + ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvPrintList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrintList.CellEnter
        On Error Resume Next

        If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
            Exit Sub
        End If

        GetPrintItemParameter(Me.dgvPrintList.Item("Moid", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Me.dgvPrintList.Item("PartId", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Microsoft.VisualBasic.Left(Me.dgvPrintList.Item("lableType", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, 1), Me.dgvPrintList.Item("PackItem", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim)
        GetPrintInfo(Me.dgvPrintList.Item("Moid", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Me.dgvPrintList.Item("PartId", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Microsoft.VisualBasic.Left(Me.dgvPrintList.Item("lableType", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, 1), Me.dgvPrintList.Item("PackItem", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim)
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

            Me.txtDemandInfo.Text = Me.dgvLotList.Item("DemandInfo", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim

            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        Catch ex As Exception
            SetMessage("获取工单打印清单异常")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "dgvLotList_CellEnter", "sys")
        End Try
    End Sub

    Private Sub CboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDept.SelectedIndexChanged
        If Me.CboDept.SelectedIndex <> -1 Then
            CboLine.DataSource = Nothing
            FillCombox(CboLine)
            CboLine.SelectedIndex = -1
        Else
            Me.CboLine.DataSource = Nothing
            Me.CboLine.Items.Clear()
            Me.CboLine.SelectedIndex = -1
        End If
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
        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
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
        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            dtPrintStatus = Conn.GetDataTable("SELECT TOP 1 COMPONENT_ID, ISNULL(MODIFIY_DATE, DATEADD(year,-10,GETDATE())) AS MODIFIY_DATE FROM M_BOM_T WHERE PRODUCT_ID='" & ProductId & "' AND COMPONENT_ID='" & ProductId & "'")
            If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
                If (DateDiff("d", CDate(dtPrintStatus.Rows(0).Item("MODIFIY_DATE").ToString()), CDate(ModifyDate)) <= 0) Then
                    Return False
                Else
                    Conn.ExecSql("DELETE M_BOM_T WHERE PRODUCT_ID='" & ProductId & "'")
                    Return True
                End If
            Else
                Return True
            End If

            dtPrintStatus = Nothing
            Conn = Nothing
        Catch ex As Exception
            dtPrintStatus = Nothing
            Conn = Nothing
            Return False
        End Try
    End Function

    Private Function CheckLotAgain(ByVal strMOid As String) As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            If (String.IsNullOrEmpty(strMOid.Trim)) Then
                SetMessage("工单" & strMOid.Trim() & "不存在!")
                Return True
            End If

            '检查是否已经打印
            Dim dtPrintStatus As New DataTable

            dtPrintStatus = Conn.GetDataTable("SELECT Ptaskid FROM m_Mainmo_t INNER JOIN m_SnAssign_t ON m_SnAssign_t.MOID=m_Mainmo_t.MOID WHERE m_Mainmo_t.ParentMo='" & strMOid.Trim & "' AND FinishPrintQty>0")
            If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
                SetMessage("工单" & strMOid.Trim() & "已经打印，不允许重新下载或删除!")
                Return True
            End If

            '执行删除
            Dim SqlStr As String
            SqlStr = " DELETE m_SnAssign_t WHERE Moid IN (SELECT MOID FROM m_Mainmo_t WHERE ParentMo='" & strMOid.Trim & "')" & _
                    " DELETE m_Mainmo_t WHERE ParentMo='" & strMOid.Trim & "'"
            Conn.ExecSql(SqlStr)

            dtPrintStatus = Nothing
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("工单" & strMOid.Trim() & "删除失败!" + ex.Message.ToString())
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
        If (String.IsNullOrEmpty(Me.CboShift.Text.Trim())) Then
            SetMessage("请选择班别!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboDept.Text.Trim())) Then
            SetMessage("请选择部门!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboLine.Text.Trim())) Then
            SetMessage("请选择线别!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboMoType.Text.Trim())) Then
            SetMessage("请选择工单类型!")
            Return True
        End If

        Dim strUserName As String = ""
        Dim dt As DataTable = DbOperateUtils.GetDataTable("exec [usp_Duty_WeekPlanUserName] '','2'")

        If dt.Rows.Count > 0 Then
            strUserName = dt.Rows(0)(0).ToString
        End If

        If (String.IsNullOrEmpty(Me.CboCust.Text.Trim())) OrElse String.IsNullOrEmpty(Me.CboCust.SelectedValue.ToString()) Then
            SetMessage("请选择客户,如客户不存在,请联系值班人员" & strUserName & "维护客户资料!")
            Return True
        End If

        If (String.IsNullOrEmpty(Me.CboSeries.Text.Trim())) OrElse String.IsNullOrEmpty(Me.CboSeries.SelectedValue.ToString()) Then
            SetMessage("请选择系列别,如系列别不存在,请联系值班人员" & strUserName & "维护系列别资料!")
            Return True
        End If
        'If (String.IsNullOrEmpty(Me.TxtFileVerNo.Text.Trim)) Then
        '    SetMessage("请输入图面版号!")
        '    Return True
        'End If
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

        If (String.IsNullOrEmpty(Me.txtPO.Text.Trim())) Then
            SetMessage("请输入合同号!")
            Me.txtPO.Focus()
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
            SetMessage("料号未设置标签信息，请找标签室维护【料件打印参数】!")
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

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

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
                If Not IsNumeric(Me.txtPrintCount.Text.Trim) Then
                    SetMessage("输入打印数量有误！")
                    Return False
                    Exit For
                End If

                'If Microsoft.VisualBasic.Left(Me.dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString, 1) = "S" Then
                '    If (Int(Me.txtPrintCount.Text.Trim) > 1000) Then
                '        SetMessage("产品条码一次打印數量限制在1-1000以內！")
                '        Return False
                '        Exit For
                '    End If
                'End If
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

    Private Function CheckVersion(ByVal strPartid As String, ByRef strRtMessage As String) As Boolean
        Dim strMessage As String
        Try
            Dim strBlueprintVersion As String
            Dim strPackageVersion As String
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
                strRtMessage = "料件[" & strPartid & "],PLM版本不存在"
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
                        strRtMessage = strMessage + "和PLM不存在"
                        Return False
                    Else
                        Return True
                    End If
                Else
                    strRtMessage = "料件[" & strPartid & "],PLM版本不存在"
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dtable As SqlDataReader
        Try

            Dtable = Conn.GetDataReader("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid,A.PO, c.DistributionFlag,c.GroupPrintFlag from m_Mainmo_t as a join m_SnAssign_t as b " _
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
                    LoadM.PO = Dtable!PO.ToString
                    LoadM.DistributionFlag = Dtable!DistributionFlag.ToString
                    LoadM.GroupPrintFlag = Dtable!GroupPrintFlag.ToString
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
                        PrtArray.PO = LoadM.PO
                        pFilePath = Dtable("TemplatePath").ToString
                    End While

                    'Me.LblAVCPart.Text = LoadD.CurrAVCPartID.ToUpper.Trim
                    'Me.LblCusPart.Text = RecTable("CustPart").ToString.ToUpper.Trim
                    'Me.LblCusName.Text = RecTable("CusName").ToString.Trim
                    'Me.LblDeptid.Text = RecTable("djc").ToString.ToUpper.Trim
                    'Me.txtQty.Text = RecTable("Qty").ToString
                    'Me.LblPrintPaper.Text = RecTable("PaperSize").ToString
                    'Me.LblMoidNum.Text = RecTable("Moqty").ToString



                    'MoidPrinted = Int(IIf(RecTable("Ppidprtqty").ToString <> "", RecTable("Ppidprtqty").ToString, 0)) * Int(IIf(RecTable("Qty").ToString <> "", RecTable("Qty").ToString, 0))
                    'Me.LblMoidPrinted.Text = MoidPrinted


                    ''''''''''''''''''''''**********************************''''''''''''''''''''''
                    '2015-06-16     马锋     打印班别界面不许要变更，直接取 LoadM.vShift 
                    'If LoadM.vShift.ToString = "D" Then '''''班別,
                    '    Me.CboShift.Text = "白班"
                    'ElseIf LoadM.vShift.ToString = "N" Then
                    '    Me.CboShift.Text = "夜班"
                    'Else
                    '    Me.CboShift.Text = "白班"
                    'End If

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
            If (CInt(RecDr("FinishPrintQty").ToString) + CInt(Me.txtPrintCount.Text.Trim)) > CInt(RecDr("PrtQty").ToString) Then
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

    '建立條碼打印數組
    Private Function MarkBarTable(ByVal PackId As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        '建立條碼組成部分並分別賦初值
        Try
            'Sqlstr = "select distinct a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128)),left(c.DValues,F_codelen)) as ShortName,a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
            '& " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
            '& " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
            '& " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
            '& " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y'  and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "' where a.CodeRuleID='" & LoadM.CodeRule.ToString & "'"
            'cq 20160719
            'left(c.DValues,F_codelen)) as ShortName,
            'left(iif(a.f_codeid='PO',isnull(mo.PO,c.DValues),c.DValues),F_codelen)) as ShortName,

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
        'Dim RecTable As New DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            LoadD.StyleID = MakeStyle() '產生樣式

            If (LoadM.DistributionFlag = "Y") Then

                Dim dtDistribution As DataTable = DbOperateUtils.GetDataTable(" SELECT MinInt, MinSN, MaxInt, MaxSN, PrintInt, PrintSN FROM m_SNDistribution_t WHERE FactoryID = '" & VbCommClass.VbCommClass.Factory & "' AND PartId = '" & LoadD.CurrAVCPartID & "' AND CodeRuleId = '" & LoadM.CodeRule & "' ")

                If dtDistribution Is Nothing Or dtDistribution.Rows.Count = 0 Then
                    MsgBox("料号：" & LoadD.CurrAVCPartID & "分段流水码,未设置工厂号段！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                Else
                    If (Int(dtDistribution.Rows(0).Item("PrintInt").ToString) + LoadD.CurrPrintNum > Int(dtDistribution.Rows(0).Item("MaxInt").ToString)) Then
                        MsgBox("料号：" & LoadD.CurrAVCPartID & ",打印超过工厂号段设置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                End If

                '2016-12-26 马锋  增加解决多工厂流水码，不同码元和料号按样式起止号生成
                Dim dtSNDistributionStyle As DataTable = DbOperateUtils.GetDataTable(" SELECT StyleID,MaxInt,MaxSN,IsUsed from m_SnDistributionStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' AND FactoryId = '" & VbCommClass.VbCommClass.Factory & "' ")

                If Not dtSNDistributionStyle Is Nothing And dtSNDistributionStyle.Rows.Count > 0 Then
                    If dtSNDistributionStyle.Rows(0).Item("IsUsed").ToString = "N" Then
                        LoadD.BarCodeStyleMax = dtSNDistributionStyle.Rows(0).Item("MaxSN").ToString
                        LoadD.CurrMaxInt = Int(dtSNDistributionStyle.Rows(0).Item("MaxInt").ToString)
                        Sqlstr = "update m_SnDistributionStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' "
                        DbOperateUtils.ExecSQL(Sqlstr)
                    Else
                        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else
                    LoadD.StartSn = dtDistribution.Rows(0).Item("MinSN").ToString
                    LoadD.StartInt = Int(dtDistribution.Rows(0).Item("MinInt").ToString)
                    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.CurrMaxInt = LoadD.StartInt
                    Sqlstr = "insert into m_SnDistributionStyle_t(StyleID, FactoryId, StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "', '" & VbCommClass.VbCommClass.Factory & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    DbOperateUtils.ExecSQL(Sqlstr)
                End If
                '*****************************  马锋 2016-12-26   *************************

                'Dim dtSNStyle As DataTable = DbOperateUtils.GetDataTable(" SELECT StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'")

                'If Not dtSNStyle Is Nothing And dtSNStyle.Rows.Count > 0 Then
                '    If dtSNStyle.Rows(0).Item("IsUsed").ToString = "N" Then
                '        LoadD.BarCodeStyleMax = dtDistribution.Rows(0).Item("PrintSN").ToString
                '        LoadD.CurrMaxInt = Int(dtDistribution.Rows(0).Item("PrintInt").ToString)
                '        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'"
                '        DbOperateUtils.ExecSQL(Sqlstr)
                '    Else
                '        MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                '        Return False
                '    End If
                'Else
                '    LoadD.StartSn = dtDistribution.Rows(0).Item("PrintSN").ToString
                '    LoadD.StartInt = Int(dtDistribution.Rows(0).Item("PrintInt").ToString)
                '    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                '    LoadD.CurrMaxInt = LoadD.StartInt
                '    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                '    DbOperateUtils.ExecSQL(Sqlstr)
                'End If
            Else
                Sqlstr = "select StyleID,MaxInt,MaxSN,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'"
                Using RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)

                    If RecTable.Read Then
                        If RecTable.GetString(RecTable.GetOrdinal("IsUsed")) = "N" Then
                            LoadD.BarCodeStyleMax = RecTable("MaxSN").ToString
                            LoadD.CurrMaxInt = Int(RecTable("MaxInt").ToString)
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
            End If

            Conn = Nothing
            Return True
        Catch ex As Exception
            Conn = Nothing
            LoadM.OpenLock(LoadD.StyleID.Replace("'", "''"))

            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory)
            End If

            Throw ex
            Return False
        End Try
    End Function

    '例行檢查
    Private Function Checking(ByVal PrintData As DataGridViewRow) As Boolean

        Dim FCLNumber As Int32
        Dim TrunkNumber As Int32

        '測試端口是否存在
        'If SysMessageClass.PrinterPort.Trim = "" Then
        '    MsgBox("請選擇打印端口,並下載字體！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Return False
        'End If
        '檢測AVC料件

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
        'If Int(Me.LblMoidPrinted.Text.Trim) + LoadD.CurrPrintNum > Int(Me.LblMoidNum.Text.Trim) Then
        '    If MessageBox.Show("你申請的打印量已超標，請確認是否需要打印這么多量？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return False
        'End If
        Return True
    End Function

    Private Function CheckingPrintQuantity(ByVal strPOInfo As String, ByVal PrintData As DataGridViewRow) As Boolean
        Try
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim strPOValue As String
            Dim strPrintQuantity As String
            Dim arrPOInfo As Array = Split(strPOInfo, "*")
            strPOValue = arrPOInfo(0)
            strPrintQuantity = arrPOInfo(1)

            If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
                MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If

            If IsNumeric(strPrintQuantity) Then
                If (CInt(strPrintQuantity) <= 0) Then
                    MsgBox("打印数量必须大于0！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                End If
                If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "P") Then

                    If ((CInt(strPrintQuantity) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) = 0) Then
                        FCLNumber = CInt(strPrintQuantity) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                        TrunkNumber = 0
                        LoadD.MantissaFlag = False
                    Else
                        FCLNumber = Int(CInt(strPrintQuantity) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim))
                        TrunkNumber = 1
                        LoadD.MantissaFlag = True
                        LoadD.MantissaBoxQty = CInt(strPrintQuantity) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    End If
                    LoadD.CurrPrintNum = FCLNumber + TrunkNumber

                Else
                    LoadD.CurrPrintNum = CInt(strPrintQuantity) * CInt(PrintData.Cells("ConfigurationQty").Value.ToString.Trim)
                    LoadD.MantissaFlag = False
                End If

                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "PO") Then
                        BarCodePartTable.Rows(I).Item("ShortName") = strPOValue
                    End If
                Next
            Else
                LoadD.CurrPrintNum = 0
                MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckPOString(ByVal strPO As String, ByRef POQuantity As Double) As Boolean
        Dim rtValue As Boolean = True
        Try
            If (InStr(strPO, "，") > 0 And InStr(strPO, "*") > 0) Then
                Dim arrPrintList As New ArrayList(Split(strPO, "，"))
                Dim arrPOInfo As Array

                For i As Integer = 0 To arrPrintList.Count - 1
                    If arrPrintList(i) = "-" Then
                        Continue For
                    End If

                    arrPOInfo = Split(arrPrintList(i), "*")

                    If (arrPOInfo.Length >= 2) Then
                        If (IsNumeric(arrPOInfo(1))) Then
                            POQuantity = POQuantity + arrPOInfo(1)
                        Else
                            rtValue = False
                            Exit For
                        End If
                    Else
                        rtValue = False
                        Exit For
                    End If
                Next
            Else
                rtValue = False
            End If

        Catch ex As Exception
            rtValue = False
        End Try
        Return rtValue
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

    Private Function GetTaskId() As String
        Dim SqlStr As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Dim Taskid As String = ""
        Try

            SqlStr = "declare @Taskid varchar(11) " & _
                " select @Taskid=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " & _
                " if @@rowcount=0 begin set @Taskid='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " & _
                " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End  SELECT @Taskid AS Taskid"
            DReader = Conn.GetDataReader(SqlStr)
            Do While DReader.Read()
                Taskid = DReader.Item("Taskid").ToString
            Loop

            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Taskid = ""
            Conn = Nothing
        End Try
        Return Taskid
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
#End Region

#Region "Bind"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        If ColComboBox.Name = "CboMoType" Then
            UserDg = DataHand.GetDataTable("select typeid,motype from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboDept" Then
            UserDg = DataHand.GetDataTable("select djc as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = DataHand.GetDataTable("Select (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "CboLine" Then
            UserDg = DataHand.GetDataTable("Select  lineid,lineid from Deptline_t where deptid='" & CboDept.SelectedValue.ToString() & "'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        ElseIf ColComboBox.Name = "ComMoType" Then
            UserDg = DataHand.GetDataTable("Select  motype,typeid from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboSeries" Then
            UserDg = DataHand.GetDataTable(" SELECT ([SeriesID]+'---'+[SeriesName])SeriesName ,[SeriesID] FROM [m_Series_t] WHERE Usey='Y'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "SeriesName"
            ColComboBox.ValueMember = "SeriesID"
        End If
        UserDg = Nothing
    End Sub
#End Region

#Region "方法"
    Private Sub SavaProductBOM(ByVal dvChildPart As DataView)
        Dim strChildSava As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
                Conn.ExecSql(strChildSava.ToString())
            End If
            strChildSava = Nothing
            Conn = Nothing
            SetStepMessage("BOM基本信息更新完成!", True)
        Catch ex As Exception
            SetStepMessage("BOM基本信息更新异常!", False)
            strChildSava = Nothing
            Conn = Nothing
        End Try
    End Sub

    Private Sub SavaChildPart(ByVal dvChildPart As DataView)
        Dim strChildSava As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim o_strCusID As String = String.Empty
        Try
            o_strCusID = Me.CboCust.SelectedValue.ToString
            If String.IsNullOrEmpty(o_strCusID) Then
                SetStepMessage("保存料件基本信息异常,客户不能为空!", False)
                Exit Sub
            End If

            '后续关闭 AmountQty组件用量更新(配置数), (Add column Extensible,Version, cq 20150916)
            '更改使用BOM检查
            For i As Int16 = 0 To dvChildPart.Count - 1
                If (Not String.IsNullOrEmpty(dvChildPart.Item(i).Item("IMA01").ToString)) Then

                    strChildSava.Append(vbNewLine & " IF('" & dvChildPart.Item(i).Item("PARENT_PART").ToString & "'='" & dvChildPart.Item(i).Item("PRODUCT_ID").ToString.Replace("'", "''") & "' AND '" & dvChildPart.Item(i).Item("PARENT_PART").ToString & "'='" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "' ) BEGIN " & _
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "' AND PAvcPart='" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "') BEGIN " & _
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " & _
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION, SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID) " & _
                    " SELECT N'" & dvChildPart.Item(i).Item("PARENT_PART").ToString & "',NULL,N'" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "','" & o_strCusID & "'," & _
                    " N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',NULL, N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") & "'," & _
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & dvChildPart.Item(i).Item("BMB06").ToString.Replace("'", "''") & "', N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "', 0, NULL, 0,'" & dvChildPart.Item(i).Item("EXTENSIABLE").ToString.Replace("'", "''") & "', " & _
                    " '" & dvChildPart.Item(i).Item("VERSION").ToString.Replace("'", "''") & "', '" & CboSeries.SelectedValue & "' END" & _
                    " END ELSE BEGIN IF ('" & dvChildPart.Item(i).Item("BMD03").ToString & "'='0' OR '" & dvChildPart.Item(i).Item("BMD03").ToString & "'='1') " & _
                    " BEGIN " & _
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_Partcontrast_t WHERE TAvcPart=N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "' AND PAvcPart='" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "') BEGIN " & _
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " & _
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, " & _
                    " IsChkTransData, AmountQty, DESCRIPTION, SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID) " & _
                    " SELECT N'" & dvChildPart.Item(i).Item("IMA01").ToString & "',NULL,N'" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "'," & _
                    " '" & o_strCusID & "',N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',NULL, N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") + (i + 1).ToString & "'," & _
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & dvChildPart.Item(i).Item("BMB06").ToString.Replace("'", "''") & "', N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "', 0, NULL,0,'" & dvChildPart.Item(i).Item("EXTENSIABLE").ToString.Replace("'", "''") & "', " & _
                    " '" & dvChildPart.Item(i).Item("VERSION").ToString.Replace("'", "''") & "', '" & CboSeries.SelectedValue & "' END " & _
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "' AND PAvcPart='" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "') " & _
                    " BEGIN " & _
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " & _
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION, SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID) " & _
                    " SELECT N'" & dvChildPart.Item(i).Item("IMA01").ToString & "',NULL,N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "','" & o_strCusID & "',N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',NULL, N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") + (i + 1).ToString & "'," & _
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & dvChildPart.Item(i).Item("BMB06").ToString.Replace("'", "''") & "', N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "', 0, NULL, 0," & _
                    " '" & dvChildPart.Item(i).Item("EXTENSIABLE").ToString.Replace("'", "''") & "','" & dvChildPart.Item(i).Item("VERSION").ToString.Replace("'", "''") & "', '" & CboSeries.SelectedValue & "' " & _
                    " END END " & _
                    " IF (ISNULL('" & dvChildPart.Item(i).Item("BMD04").ToString.Replace("'", "''") & "','')<>'')" & _
                    " BEGIN " & _
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & dvChildPart.Item(i).Item("BMD04").ToString.Replace("'", "''") & "' AND PAvcPart='" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "') BEGIN " & _
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " & _
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION, SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID) " & _
                    " SELECT N'" & dvChildPart.Item(i).Item("BMD04").ToString & "',NULL,N'" & dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''") & "'," & _
                    " '" & o_strCusID & "',N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',NULL, N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") & "'," & _
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & dvChildPart.Item(i).Item("BMB06").ToString.Replace("'", "''") & "', N'" & dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "'," & _
                    " 1, '" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "', '" & dvChildPart.Item(i).Item("BMD03").ToString.Replace("'", "''") & "'," & _
                    " '" & dvChildPart.Item(i).Item("EXTENSIABLE").ToString.Replace("'", "''") & "','" & dvChildPart.Item(i).Item("VERSION").ToString.Replace("'", "''") & "', '" & CboSeries.SelectedValue & "' END " & _
                    " END END")
                End If
            Next
            If (Not String.IsNullOrEmpty(strChildSava.ToString)) Then
                Conn.ExecSql(strChildSava.ToString())
            End If
            strChildSava = Nothing
            Conn = Nothing
            SetStepMessage("料件基本信息更新完成!", True)
        Catch ex As Exception
            strChildSava = Nothing
            Conn = Nothing
            SetStepMessage("料件基本信息更新异常!", False)
        End Try
    End Sub

    Private Function GetVersion(ByVal parPN As String) As String
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim lsSQL As String = ""
        GetVersion = ""
        Try
            lsSQL = " SELECT ISNULL(VERSION,'') as VERSION  FROM m_PartContrast_t WHERE TAvcPart  = '" & parPN & "'"
            Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetVersion = o_dt.Rows(0).Item("VERSION").ToString
                Else
                    GetVersion = ""
                End If
            End Using
            Return GetVersion
        Catch ex As Exception
        Finally
            sConn = Nothing
        End Try
    End Function

    Private Sub LoadControlData()

        FillCombox(CboMoType)
        FillCombox(CboDept)
        FillCombox(CboCust)
        FillCombox(CboSeries) 'Add by CQ 20151123

        Me.CboDept.SelectedIndex = -1
        Me.CboLine.SelectedIndex = -1
        Me.CboMoType.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1

        Me.dtpEndDate.Value = Now.AddDays(-1)
        Me.dtpStartDate.Value = Now.AddDays(1)

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DateT As New DateTime
        Dim RecTable As SqlDataReader
        RecTable = Conn.GetDataReader("select getdate() as nowtime")
        If RecTable.Read Then
            DateT = CDate(RecTable!nowtime.ToString)
        End If
        Dim dtCheckAqci120 As DataTable = DbOperateUtils.GetDataTable("SELECT CheckAqci120 FROM m_Dcompany_t WHERE Factoryid = '" & VbCommClass.VbCommClass.Factory & "'")

        If (Not dtCheckAqci120 Is Nothing And dtCheckAqci120.Rows.Count > 0) Then
            m_CheckAqci120 = dtCheckAqci120.Rows(0).Item("CheckAqci120").ToString
        End If
        Me.LblPrintDate.Text = DateT.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        PrtArray.NowDate = CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString
        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text.ToString).ToString("MM").ToString
        Conn = Nothing
    End Sub

    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                
                'Me.ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                Me.ToolCommitInfo.Enabled = IIf(Me.ToolCommitInfo.Tag.ToString = "YES", True, False)
                Me.ToolQuery.Enabled = True
                Me.ToolBack.Enabled = False
                Me.ToolPrt.Enabled = True
                Me.Timer.Enabled = True

                Me.txtMOId.Text = ""
                Me.TxtPartid.Text = ""
                Me.txtQty.Text = ""
                Me.TxtFileVerNo.Text = ""
                Me.TxtDriFlag.Text = ""
                Me.txtPrintCount.Text = ""
                Me.TxtBuildAttribute.Text = ""
                Me.TxtTaskDesc.Text = ""
                Me.CboShift.SelectedIndex = -1
                Me.CboDept.SelectedIndex = -1
                Me.CboLine.SelectedIndex = -1
                Me.CboMoType.SelectedIndex = -1
                Me.CboCust.SelectedIndex = -1
                Me.CboSeries.SelectedIndex = -1
                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = True
                Me.txtQty.Enabled = False
                Me.TxtFileVerNo.Enabled = False
                Me.TxtDriFlag.Enabled = False
                Me.txtPrintCount.Enabled = False
                Me.TxtBuildAttribute.Enabled = False
                Me.TxtTaskDesc.Enabled = False
                Me.CboShift.Enabled = False
                Me.CboDept.Enabled = False
                Me.CboLine.Enabled = False
                Me.CboMoType.Enabled = False
                Me.CboCust.Enabled = False
                Me.CboSeries.Enabled = False
                'DgVer.Enabled = False
            Case 1    '新增
                'Me.ToolEdit.Enabled = False
                'Me.ToolCancel.Enabled = False
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.Timer.Enabled = False
                Me.ToolCommitInfo.Enabled = False

                Me.CboShift.SelectedIndex = -1
                Me.CboDept.SelectedIndex = -1
                Me.CboLine.SelectedIndex = -1
                Me.CboMoType.SelectedIndex = -1
                Me.CboCust.SelectedIndex = -1
                Me.CboSeries.SelectedIndex = -1
                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.TxtFileVerNo.Enabled = True
                Me.TxtDriFlag.Enabled = True
                Me.txtPrintCount.Enabled = True
                Me.TxtBuildAttribute.Enabled = True
                Me.TxtTaskDesc.Enabled = True
                Me.CboShift.Enabled = True
                Me.CboDept.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboMoType.Enabled = True
                Me.CboCust.Enabled = True

                If VbCommClass.VbCommClass.Factory = "LXXT" Then
                    Me.CboSeries.Enabled = False
                Else
                    Me.CboSeries.Enabled = True
                End If

                'DgVer.Enabled = True
                'DgVer.Columns(0).ReadOnly = True
                'DgVer.Columns(1).ReadOnly = True
            Case 2  '修改
                'Me.ToolEdit.Enabled = False
                'Me.ToolCancel.Enabled = False
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.Timer.Enabled = False
                Me.ToolCommitInfo.Enabled = False

                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.TxtFileVerNo.Enabled = True
                Me.TxtDriFlag.Enabled = True
                Me.txtPrintCount.Enabled = True
                Me.TxtBuildAttribute.Enabled = True
                Me.TxtTaskDesc.Enabled = True
                Me.CboShift.Enabled = True
                Me.CboDept.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboMoType.Enabled = True
                Me.CboCust.Enabled = True
                Me.CboSeries.Enabled = True
                'DgVer.Enabled = True
                'DgVer.Columns(0).ReadOnly = True
                'DgVer.Columns(1).ReadOnly = True
        End Select
    End Sub

    Private Sub ClearObject()
        Me.txtMOId.Text = ""
        strMOID = ""
        Me.TxtPartid.Text = ""
        Me.CboLine.DataSource = Nothing
        Me.CboLine.Items.Clear()
        Me.txtBlueprintVersion.Text = ""
        Me.txtPackageVersion.Text = ""
        Me.txtPO.Text = "" 'cq 20160718
        Me.txtQty.Text = ""
        Me.txtQty.Enabled = False

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
        Me.CboDept.SelectedIndex = -1
        Me.CboLine.SelectedIndex = -1
        Me.CboMoType.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.txtMOId.Focus()
        Me.dgvLotList.Rows.Clear()
        Me.dgvPrintList.Rows.Clear()
        Me.dgvRuleList.Rows.Clear()

    End Sub

    '取得打印工单
    Private Sub GetLot()

        Sqlstr.Remove(0, Sqlstr.Length)
        If VbCommClass.VbCommClass.Factory = "LX53" Then
            Dim sql As String = GetJxSql()
            If Not String.IsNullOrEmpty(sql) Then
                LoadData(sql, Me.dgvLotList)
            End If
        Else
            'and m_dept_t.Factoryid='" & VbCommClass.VbCommClass.Factory & "'
            Sqlstr.Append(" SELECT Moid,PartID,Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, ")
            Sqlstr.Append(" m_Dept_t.DQC, m_Mainmo_t.Lineid,m_Mainmo_t.CHECKTEXT, CONVERT(VARCHAR(10),m_Mainmo_t.Plandate,120) AS Plandate, m_Customer_t.CusName, Createuser, Createtime, m_Mainmo_t.Remark, ")
            Sqlstr.Append(" m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime, BlueprintVersion, PackageVersion,PO ")
            Sqlstr.Append(" FROM m_Mainmo_t(NOLOCK) ")
            Sqlstr.Append(" LEFT JOIN m_Customer_t(NOLOCK) ON m_Customer_t.CusID=m_Mainmo_t.Cusid ")
            Sqlstr.Append(" LEFT JOIN m_Dept_t(NOLOCK) ON m_Dept_t.deptid=m_Mainmo_t.Deptid ")
            Sqlstr.Append(" WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' ")
            Sqlstr.Append(" AND m_Mainmo_t.Moid=m_Mainmo_t.ParentMo and m_Mainmo_t.Createtime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)")

            If Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                Sqlstr.Append(" and m_Mainmo_t.moid like '%" & Me.txtMOId.Text.ToString.Trim & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
                Sqlstr.Append(" and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'")
            End If

            'add exclude mo, which mo not line leader request label,  cq 20160901 
            ' Sqlstr.Append(" and m_Mainmo_t.DemandInfo  is not null")
            Sqlstr.Append(" ORDER BY m_Mainmo_t.Createtime DESC")
            LoadData(Sqlstr.ToString, Me.dgvLotList)
        End If



        'LoadTypeInGrid(TxtPartid.Text)
    End Sub

    '取得工单打印清单
    Private Sub GetLotPrintList(ByVal strMOid As String, ByVal strPartId As String, ByVal strQty As String, ByVal QueryFlag As Boolean)

        Sqlstr.Remove(0, Sqlstr.Length)
        'AND TAvcPart!=PAvcPart
        If (QueryFlag) Then
            Sqlstr.Append(" SELECT m_SnAssign_t.Ptaskid,m_Mainmo_t.Moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append(" m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_SnAssign_t.Packitem,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append(" m_Mainmo_t.Moqty AS Qty,m_SnAssign_t.PrtQty*ISNULL(m_SnAssign_t.ConfigurationQty,1) PrintQty, ISNULL(m_SnAssign_t.FinishPrintQty,0) AS FinishPrintQty,ISNULL(m_SnAssign_t.ConfigurationQty,1) AS ConfigurationQty, m_PartPack_t.PrinterNameOnline AS PrinterName, ")
            Sqlstr.Append(" case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append(" m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" djmdc,shift,linejm,convert(varchar(10),m_SnAssign_t.Demandtime,120) as Demandtime,(FileVerNo + iif(isnull(m_SnAssign_t.Remark,'')='','','#'+ m_SnAssign_t.Remark ))FileVerNo,m_PartPack_t.Remark,DriFlag,BuildAttribute, case m_SnAssign_t.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, m_Mainmo_t.PartID as applyPart, ISNULL(m_PartPack_t.VersionType, '0') + '-' + PartVersionType.PARAMETER_NAME AS VersionTypeText,m_SnAssign_t.LABELPN, m_SnAssign_t.PrintNumber,m_PartPack_t.GroupPrintFlag ")
            Sqlstr.Append(" FROM m_Mainmo_t(NOLOCK) INNER JOIN m_SnAssign_t(NOLOCK) ON m_Mainmo_t.Moid= m_SnAssign_t.Moid ")
            Sqlstr.Append(" INNER JOIN m_PartContrast_t(NOLOCK) ON m_PartContrast_t.TAvcPart=m_Mainmo_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart ")
            Sqlstr.Append(" INNER JOIN m_PartPack_t(NOLOCK) ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND  m_PartPack_t.Packid=m_SnAssign_t.Packid AND m_PartPack_t.Packitem=m_SnAssign_t.Packitem")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t(NOLOCK)  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK)  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Dept_t(NOLOCK) on m_Mainmo_t.Deptid=m_Dept_t.Deptid and m_Mainmo_t.factory=m_Dept_t.factoryid ")
            Sqlstr.Append(" LEFT JOIN Deptline_t(NOLOCK) on m_Dept_t.deptid=Deptline_t.deptid and m_SnAssign_t.lineid=Deptline_t.lineid ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK) AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            Sqlstr.Append(" INNER JOIN m_SettingParameter_t(NOLOCK) PartVersionType ON PartVersionType.PARAMETER_VALUE = m_PartPack_t.VersionType AND PartVersionType.PARAMETER_CODE = 'PartVersionType' ")
            Sqlstr.Append(" WHERE m_Mainmo_t.ParentMo='" & strMOid & "' AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'  ")
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                Sqlstr.Append(" AND m_SnAssign_t.ESTATEID NOT IN(3,4) ORDER BY m_SnAssign_t.INTIME DESC")
            Else
                Sqlstr.Append(" ORDER BY m_PartContrast_t.TAvcPart ASC")
            End If
        Else
            'Sqlstr.Append(" SELECT '' AS Ptaskid,'" + strMOid + "' AS 'MOID', m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            'Sqlstr.Append("     m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_PartPack_t.Packitem, ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            'Sqlstr.Append("     " + strQty + " AS Qty,CONVERT(INT,'" + strQty + "')* CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE M_BOM_T.QUANTITY END AS PrintQty, CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE M_BOM_T.QUANTITY END AS ConfigurationQty, 0 AS FinishPrintQty, m_PartPack_t.PrinterName, ")
            'Sqlstr.Append("     case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            'Sqlstr.Append("     m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            'Sqlstr.Append(" '' djmdc, '' shift, ''linejm, '' as Demandtime, '' FileVerNo, '' DriFlag, ''BuildAttribute, '0-待保存' as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel ")
            'Sqlstr.Append(" FROM  M_BOM_T ")
            'Sqlstr.Append(" INNER JOIN m_PartContrast_t ON m_PartContrast_t.TAvcPart=M_BOM_T.COMPONENT_ID AND m_PartContrast_t.PAvcPart=M_BOM_T.PRODUCT_ID ")
            ''料件必须设置参数，不然确定打印标签类型
            'Sqlstr.Append(" INNER JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            'Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' ")
            'Sqlstr.Append(" LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            'Sqlstr.Append(" LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            'Sqlstr.Append(" LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            'Sqlstr.Append(" WHERE m_PartContrast_t.PAvcPart='" + strPartId + "' ORDER BY m_PartContrast_t.TAvcPart ASC")

            Sqlstr.Append(" WITH BOM( PRODUCT_ID, COMPONENT_ID, QUANTITY) AS")
            Sqlstr.Append(" (")
            Sqlstr.Append(" SELECT PRODUCT_ID, COMPONENT_ID, QUANTITY")
            Sqlstr.Append(" FROM M_BOM_T(NOLOCK) ")
            Sqlstr.Append(" WHERE PRODUCT_ID='" + strPartId + "' AND COMPONENT_ID<>PRODUCT_ID")
            Sqlstr.Append(" UNION ALL")
            Sqlstr.Append(" SELECT M_BOM_T.PRODUCT_ID, M_BOM_T.COMPONENT_ID, M_BOM_T.QUANTITY")
            Sqlstr.Append(" FROM BOM ")
            Sqlstr.Append(" INNER JOIN M_BOM_T(NOLOCK) ON M_BOM_T.PRODUCT_ID=BOM.COMPONENT_ID  AND M_BOM_T.COMPONENT_ID<>M_BOM_T.PRODUCT_ID")
            Sqlstr.Append(" )")
            Sqlstr.Append(" SELECT '' AS Ptaskid,'" + strMOid + "' AS 'MOID', m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append("     m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_PartPack_t.Packitem, ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append("     " + strQty + " AS Qty,CONVERT(INT,'" + strQty + "')* CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE M_BOM_T.QUANTITY END AS PrintQty, CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE M_BOM_T.QUANTITY END AS ConfigurationQty, 0 AS FinishPrintQty, m_PartPack_t.PrinterName, ")
            Sqlstr.Append("     case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append("     m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" '' djmdc, '' shift, ''linejm, '' as Demandtime, '' FileVerNo, m_PartPack_t.Remark, '' AS VersionTypeText, '' DriFlag, ''BuildAttribute, '0-待保存' as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, '" + strPartId + "' as applyPart,'' as LABELPN, '0' AS PrintNumber,m_PartPack_t.GroupPrintFlag ")
            Sqlstr.Append(" FROM (")
            Sqlstr.Append(" SELECT PRODUCT_ID, COMPONENT_ID, QUANTITY")
            Sqlstr.Append(" FROM BOM ")
            Sqlstr.Append(" UNION ALL")
            Sqlstr.Append(" SELECT M_BOM_T.PRODUCT_ID, M_BOM_T.COMPONENT_ID, M_BOM_T.QUANTITY")
            Sqlstr.Append(" FROM M_BOM_T(NOLOCK) ")
            Sqlstr.Append(" WHERE(M_BOM_T.PRODUCT_ID = M_BOM_T.COMPONENT_ID AND M_BOM_T.PRODUCT_ID='" + strPartId + "')")

            'Sqlstr.Append(" SELECT DISTINCT M_BOM_T.PRODUCT_ID, M_BOM_T.COMPONENT_ID, M_BOM_T.QUANTITY")
            'Sqlstr.Append(" FROM BOM ")
            'Sqlstr.Append(" INNER JOIN M_BOM_T ON M_BOM_T.PRODUCT_ID=BOM.PRODUCT_ID ")
            'Sqlstr.Append(" WHERE(M_BOM_T.PRODUCT_ID = M_BOM_T.COMPONENT_ID)")
            Sqlstr.Append(" ) M_BOM_T ")
            Sqlstr.Append(" INNER JOIN m_PartContrast_t(NOLOCK) ON m_PartContrast_t.TAvcPart=M_BOM_T.COMPONENT_ID AND m_PartContrast_t.PAvcPart=M_BOM_T.PRODUCT_ID ")
            '料件必须设置参数，不然确定打印标签类型
            Sqlstr.Append(" INNER JOIN m_PartPack_t(NOLOCK) ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' ")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t(NOLOCK)  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK)  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK) AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            'WHERE m_PartContrast_t.PAvcPart='" + strPartId + "' 
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
                    , DReader.Item("PpidprtCount").ToString, DReader.Item("Pkgprtqty").ToString, DReader.Item("Lineid").ToString, _
                    DReader.Item("BlueprintVersion").ToString, DReader.Item("PackageVersion").ToString, DReader.Item("PO").ToString, _
                    DReader.Item("CHECKTEXT").ToString, DReader.Item("DemandInfo").ToString, DReader.Item("Plandate").ToString _
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
                            FCLNumber = System.Math.Truncate((CInt(DReader.Item("PrintQTY").ToString) - CInt(DReader.Item("FinishPrintQty").ToString)) / CInt(DReader.Item("PackingQty").ToString))
                            TrunkNumber = 1
                        End If
                    Else
                        FCLNumber = 0
                        TrunkNumber = 0
                    End If

                    Dim defaultSelected As Boolean = True
                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        defaultSelected = False
                    End If
                    dgvName.Rows.Add(defaultSelected, DReader.Item("Ptaskid").ToString, DReader.Item("Moid").ToString, DReader.Item("TAvcPart").ToString, DReader.Item("PAvcPart").ToString, DReader.Item("LabelType").ToString, DReader.Item("PackItem").ToString, DReader.Item("FileVerNo").ToString, DReader.Item("VersionTypeText").ToString, DReader.Item("Remark").ToString, _
                    DReader.Item("Qty").ToString, DReader.Item("PrintQTY").ToString, DReader.Item("FinishPrintQty").ToString, DReader.Item("ConfigurationQty").ToString, DReader.Item("LABELPN").ToString, PrintName, DReader.Item("PackingQty").ToString, FCLNumber, TrunkNumber, DReader.Item("PrintNumber").ToString, DReader.Item("KLabelid").ToString, DReader.Item("Description").ToString, DReader.Item("PrintStatus").ToString, DReader.Item("DisorderType").ToString, _
                    DReader.Item("djmdc").ToString, DReader.Item("shift").ToString, DReader.Item("linejm").ToString, DReader.Item("Demandtime").ToString, DReader.Item("DriFlag").ToString, DReader.Item("BuildAttribute").ToString, DReader.Item("Estateid").ToString, DReader.Item("PackingLevel").ToString, DReader.Item("applyPart").ToString, DReader.Item("GroupPrintFlag").ToString)

                End If
            Loop
            Me.ToolLblCount.Text = Me.dgvLotList.Rows.Count
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex '出错
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
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)
        strConfigurationQty = IIf(IsDBNull(PrintData.Cells("ConfigurationQty").Value), "1", PrintData.Cells("ConfigurationQty").Value)


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
                    '需增加尾箱处理
                    BuildCBarCode(PrintData)
                Case "P"

                Case "N"
                    '需增加尾箱处理
                    'BuildCBarCode(PrintData)
                    BuildNBarCode(PrintData)
            End Select
        Else
            SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
        End If
    End Sub

    '數組傳遞參數
    Private Sub SetArrayLbl(ByVal Array() As String)
        'Dim I As Int16
        'Dim IsCheckCode As String = "N"
        'Dim ArrayCheck As Integer = 0
        'Try
        '    For I = 0 To BarCodePartTable.Rows.Count - 1
        '        If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(Replace(BarCodePartTable.Rows(I).Item("DResource").ToString, "Array", ""))).Trim


        '        End If
        '        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
        '        End If
        '    Next
        'Catch ex As Exception
        '    Throw ex
        'End Try

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
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
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

    Private Sub SetStepMessage(ByVal StrMessage As String, ByVal MessageType As Boolean)

        Me.rtxtStepMessage.AppendText(StrMessage + Environment.NewLine)
        Dim p1 As Integer = Me.rtxtStepMessage.Text.IndexOf(StrMessage)
        Dim p2 As Integer = StrMessage.Length
        Me.rtxtStepMessage.Select(Me.rtxtStepMessage.Text.Length - p2 - 1, p2)
        If (MessageType) Then
            Me.rtxtStepMessage.SelectionColor = Color.Lime
        Else
            Me.rtxtStepMessage.SelectionColor = Color.Red
        End If

    End Sub

    Private Sub ProcessLoadMo(ByVal strMOid As String, ByVal dgvPrintList As DataGridView)
        If (Not dgvPrintList Is Nothing) Then
            Dim strPartId As String
            Dim strParentPartId As String
            Dim strApplyPartId As String
            Dim strItemNum As String
            Dim MaxItemNum As Int16 = 0
            Dim strChildMoid As String

            For I As Int16 = 0 To Me.dgvPrintList.Rows.Count - 1
                strPartId = Me.dgvPrintList.Rows(I).Cells("PartId").Value.ToString
                strParentPartId = Me.dgvPrintList.Rows(I).Cells("ParentPartId").Value.ToString
                strApplyPartId = Me.dgvPrintList.Rows(I).Cells("applyPart").Value.ToString

                If (strPartId.ToUpper <> strParentPartId.ToUpper) Then
                    strItemNum = Microsoft.VisualBasic.Right(strPartId, Len(strPartId) - InStrRev(strPartId, "-"))
                    'If (IsNumeric(strItemNum)) Then
                    '    If (Convert.ToInt16(strItemNum) > MaxItemNum) Then
                    '        MaxItemNum = Convert.ToInt16(strItemNum)
                    '    Else
                    '        MaxItemNum = MaxItemNum + 1
                    '    End If
                    'Else
                    '    If MaxItemNum > I Then
                    '        MaxItemNum = MaxItemNum + 1
                    '    Else
                    '        MaxItemNum = I + 1
                    '    End If
                    'End If

                    If (IsNumeric(strItemNum)) Then
                        If (strApplyPartId = strParentPartId) Then
                            strChildMoid = strMOid + "-" + (strItemNum).ToString.PadLeft(2, "0")
                        Else
                            If (strParentPartId = strPartId.Split("-")(0)) Then
                                strChildMoid = strMOid + "-" + strParentPartId + "-" + (strItemNum).ToString.PadLeft(2, "0")
                            Else
                                strChildMoid = strMOid + "-" + strParentPartId + "-" + strPartId
                            End If
                        End If

                    Else
                        'strChildMoid = strMOid + "-" + (I).ToString.PadLeft(2, "0")    '全部按流水号自增
                        strChildMoid = strMOid + "-" + strPartId
                    End If

                    Me.dgvPrintList.Rows(I).Cells("Moid").Value = strChildMoid
                End If
            Next
        End If
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

#End Region

#Region "打印"

    Private Sub BuildABarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            Me.strGroupPrintFlag = PrintData.Cells("GroupPrintFlag").Value.ToString

            '2015-06-16     马锋      InitializePrintParameter已经处理BarCodePartTable集合值，取消该段异常代码
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    
            '    'If BarCodePartTable.Rows(I)("DResource").ToString = "Array5" Then
            '    '    '' PkgOldQtyStr = BarCodePartTable.Rows(I)("shortname")
            '    '    BarCodePartTable.Rows(I)("shortname") = Me.CboLine.Text.Split("-")(1)
            '    '    Icount = Icount + 1
            '    'End If
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
        'LblTempCode.Remove(0, LblTempCode.Length)
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
                'BarCodeStyle.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Flag = False
            'TempView = New DataView(BarCodePartTable)
            'TempView.RowFilter = "bararea='BarLabel1'"
            'TempView.Sort = "f_orderid asc"
            ''產生樣式Label1
            'For I = 0 To TempView.Count - 1
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
            '        LoadD.LblSPos = LblTempCode.Length
            '        Flag = True
            '    End If
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper <> "S" Then
            '        LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
            '    End If
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
            '        LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
            '    End If
            '    LblTempCode.Append(TempView.Item(I).Item("SplitChar").ToString)
            'Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    '檢查樣式 oxf20151116
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
                    'LoadD.AtrrBarCodeStyleMax = ""
                    'LoadD.AtrrCurrMaxInt = 0
                    LoadD.AtrrBarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.AtrrCurrMaxInt = LoadD.StartInt
                    RecTable.Close()
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & PubAtrributeStype & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & PubAtrributeStype & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
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
                    If Me.CboShift.Text = "白班" Then '''''班別,
                        WorkStr = "D"
                    Else
                        WorkStr = "N"
                    End If
                    BarCodePartTable.Rows(I)("shortname") = WorkStr
                    Icount = Icount + 1
                End If
            Next
            ''打印前例行檢查及生成樣式和檢測樣式
            'If Checking(PrintData) = False OrElse CheckStyle() = False Then
            '    Exit Sub
            'End If

            'CMainMarkSCode(PrintData) '生成序號並打印

            Dim existPO As Boolean = False
            Dim strPO As String = ""

            For i As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If (BarCodePartTable.Rows(i).Item("f_codeid") = "PO") Then
                    strPO = BarCodePartTable.Rows(i).Item("ShortName")
                    existPO = True
                End If
            Next

            Dim printPOQuantity As Double = 0

            If (VbCommClass.VbCommClass.Factory = "LXXT") And existPO = True And CheckPOString(strPO, printPOQuantity) Then

                Dim arrPrintList As New ArrayList(Split(strPO, "，"))

                If (CDbl(Me.txtPrintCount.Text.Trim) > printPOQuantity) Then
                    arrPrintList.Add("*" & CStr(CDbl(Me.txtPrintCount.Text.Trim) - printPOQuantity))
                End If

                If CheckStyle() = False Then
                    Exit Sub
                End If

                '增加工单总数量，非合同号打印
                For i As Integer = 0 To arrPrintList.Count - 1
                    '打印数量和PO更新

                    If (CheckingPrintQuantity(arrPrintList(i), PrintData) = False) Then
                        Exit Sub
                    End If

                    CMainMarkSCode(PrintData) '生成序號並打印
                Next
            Else

                If Checking(PrintData) = False OrElse CheckStyle() = False Then
                    Exit Sub
                End If

                CMainMarkSCode(PrintData) '生成序號並打印
            End If
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

            'If CboLine.Text = "" Then
            '    MsgBox("请选择自动线线别...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '    Exit Sub
            'End If
            If String.IsNullOrEmpty(DisorderType) Then
                MsgBox("请配置无序打印条码类型...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If

            '2015-06-16     马锋      InitializePrintParameter已经处理BarCodePartTable集合值，取消该段异常代码
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array5" Then
            '        '' PkgOldQtyStr = BarCodePartTable.Rows(I)("shortname")
            '        BarCodePartTable.Rows(I)("shortname") = Me.CboLine.Text.Split("-")(1)
            '        Icount = Icount + 1
            '    End If
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

            ' ''打印前例行檢查及生成樣式和檢測樣式s
            'If Checking(PrintData) = False OrElse CheckStyle() = False Then
            '    Exit Sub
            'End If
            ''增加尾数箱处理 , PrintData.Cells("PtaskId").Value.ToString
            'NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印

            Dim existPO As Boolean = False
            Dim strPO As String = ""

            For i As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If (BarCodePartTable.Rows(i).Item("f_codeid") = "PO") Then
                    strPO = BarCodePartTable.Rows(i).Item("ShortName")
                    existPO = True
                End If
            Next

            Dim printPOQuantity As Double = 0

            If (VbCommClass.VbCommClass.Factory = "LXXT") And existPO = True And CheckPOString(strPO, printPOQuantity) Then
                Dim strPOTemp As String = strPO
                If InStr(strPO, "，-") > 0 Then
                    strPO = strPO.Replace("，-", "")
                End If

                Dim arrPrintList As New ArrayList(Split(strPO, "，"))

                If (CDbl(Me.txtPrintCount.Text.Trim) > printPOQuantity) And Microsoft.VisualBasic.Right(strPOTemp, 1) = "-" Then
                    arrPrintList.Add("*" & CStr(CDbl(Me.txtPrintCount.Text.Trim) - printPOQuantity))
                End If

                If CheckStyle() = False Then
                    Exit Sub
                End If

                '增加工单总数量，非合同号打印
                For i As Integer = 0 To arrPrintList.Count - 1
                    '打印数量和PO更新

                    If (CheckingPrintQuantity(arrPrintList(i), PrintData) = False) Then
                        Exit Sub
                    End If

                    NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印
                Next
            Else

                If Checking(PrintData) = False OrElse CheckStyle() = False Then
                    Exit Sub
                End If

                '增加尾数箱处理 , PrintData.Cells("PtaskId").Value.ToString
                NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildNBarCode", "sys")
        End Try
    End Sub

#Region "有序条码"

    '生成序號並打印條碼
    Private Function MainMarkSCode(ByVal printName As String, ByVal taskId As String, ByVal PrintData As DataGridViewRow) As Boolean
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

            LoadD.AtrrBarCodeStyleMax = AtrrrCurrSBCode.ToString
            LoadD.AtrrCurrMaxInt = LoadD.AtrrCurrMaxInt + CurrNum

            MoidPrinted += LoadD.CurrPrintNum
            SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")

            If (LoadM.DistributionFlag = "Y") Then
                SqlStr.Append(vbNewLine & " UPDATE m_SNDistribution_t SET PrintInt=" & LoadD.CurrMaxInt & ", PrintSN='" & LoadD.BarCodeStyleMax & "' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND PartId='" & LoadD.CurrAVCPartID & "' AND CodeRuleId='" & LoadM.CodeRule & "' ")
                SqlStr.Append(vbNewLine & " UPDATE m_SnDistributionStyle_t SET MaxInt=" & LoadD.CurrMaxInt & ", MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND StyleID='" & LoadD.StyleID & "' ")
            End If

            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            End If
            SqlStr.Append(vbNewLine & "update m_Mainmo_t set Ppidprtqty=isnull(Ppidprtqty,0)+" & CurrNum & ",PpidprtCount=PpidprtCount+" & LoadD.CurrPrintNum & "*" & PrtArray.Qty & " where Moid='" & LoadD.CurrMoid & "'")
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid='" & taskId & "'")
            Else
                SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & " where Ptaskid='" & taskId & "'")
            End If

            'SqlStr.Append(vbNewLine & "INSERT into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
            '                             " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'D' then 'S' when 'K' then 'K' end,'" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            'Modify insert print record, cq 20170310
            SqlStr.Append(vbNewLine & "INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " VALUES('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "', '" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")

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

            'SqlStr &= ControlChars.CrLf & BarCodePrint(BarFlag, PrintStr.ToString)
            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString())
                If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update
                    FileToBarCodePrint(pFilePath, printName)
                End If
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            DbOperateUtils.ExecSQL(" update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'" & vbNewLine &
                                   " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory)
            End If
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

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)
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
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        'Add by Byron.Huang 2017-01-19  加入条码类型
        Dim lableType As String = Nothing

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

                '尾数箱处理
                'If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                '    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                'End If

                '生成打印指令
                If N = LoadD.PrintColNum Then
                    'PrintBarCode(UseY)
                    'Add by Byron.Huang 2017-01-19  添加类型
                    NModlePrintGenRecord("N", False, 0, "A")
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    'Add by Byron.Huang 2017-01-19 添加类型
                    NModlePrintGenRecord("N", False, 0, "A")
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
            SqlStr &= " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & " where Ptaskid='" & taskId & "'"

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

#Region "无序打印"
    '生成序號並打印條碼
    Private Function NMainMarkSCode(ByVal PrintName As String, ByVal UseY As String, ByVal DisorderType As String, ByVal taskId As String, ByVal PackItem As String, ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim BarFlag As String = LoadD.StyleID
        Dim tempCurrentPrintQty As String = "0"
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
                    FormatMantissaWeight(LoadD.MantissaBoxQty, PrintData)
                    LoadD.StyleID = MakeStyle()
                    'BarFlag = LoadD.StyleID
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

                FormatMantissaBoxQty(PrintData.Cells("PackingQty").Value.ToString)
                LoadD.StyleID = MakeStyle()
                PrintPart(1, 1) = LoadD.StyleID
                BarFlag = LoadD.StyleID
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
            Else
                'Add by cq 20170309
                If Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "N" Then
                    tempCurrentPrintQty = Me.txtPrintCount.Text
                Else
                    tempCurrentPrintQty = LoadD.CurrPrintNum
                End If
                'LoadD.CurrPrintNum ==> tempCurrentPrintQty
                SqlStr &= ControlChars.CrLf & " INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime,sBarCode) " & _
                                              " VALUES('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','N','" & BarFlag & "'," & PrtArray.Qty & "," & Val(tempCurrentPrintQty) & ",'','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & BarFlag & "')"

            End If
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            '插入數據庫並傳送打印指令到打印機
            'My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            'MakeStyle()

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

            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr &= " UPDATE m_SnAssign_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid ='" & PrintData.Cells("PtaskId").Value.ToString & "' "
            Else
                SqlStr &= " UPDATE m_SnAssign_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & " where Ptaskid ='" & PrintData.Cells("PtaskId").Value.ToString & "' "
            End If

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

    ''码元值生成至数据库，供exce调用
    Private Sub NModlePrintGenRecord(ByVal UseY As String, ByVal MantissaFlag As Boolean, ByVal MantissaBoxQty As Int16, Optional ByVal LableType As String = Nothing)

        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Dim TmpStr As New StringBuilder
        Dim OtherStr As New StringBuilder
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
                                If Me.strGroupPrintFlag = "Y" Then
                                    'Add by Byron.Huang 2017-01-19  附属条码的参数，每个参数都需要打印一个条码
                                    If LableType = "A" AndAlso TempView.Item(I).Item("ShortName").ToString <> "" AndAlso TempView.Item(I).Item("DResource").ToString = "PartSet" Then
                                        If TempView.Item(I).Item("UnitId").ToString = "" Then
                                            PrintStr.Append(TmpStr.ToString + OtherStr.ToString)
                                            TmpStr = New StringBuilder()

                                            TmpStr.Append(vbNewLine & "~#" & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                            Continue For
                                        Else
                                            TmpStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                        End If

                                    End If

                                    'Add by Byron.Byron 2017-01-19 附属条码，其它条码部分
                                    OtherStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

                                End If



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


            'Add by Byron.Huang 2017-01-19  附属条码，拼接字符
            If LableType = "A" AndAlso Me.strGroupPrintFlag = "Y" AndAlso TmpStr.ToString.Length > 0 Then
                PrintStr.Append(TmpStr.ToString + OtherStr.ToString)
            End If

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

#Region "包装打印"
    '生成序號並打印條碼
    Private Function CMainMarkSCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼
            ''''''''''''''''''''''''''''''''''''
            '正式打印條碼
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

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    'LoadD.StyleID = MakeStyle()LoadD.StyleID
                    'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & LoadD.MantissaBoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & LoadD.MantissaBoxQty & "')")
                    'PrintPart(1, 1) = LoadD.StyleID
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                If (I = 1) Then
                    FormatMantissaBoxQty(PrintData.Cells("PackingQty").Value.ToString)
                    'LoadD.StyleID = MakeStyle()
                End If

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

            If (LoadM.DistributionFlag = "Y") Then
                SqlStr.Append(vbNewLine & " UPDATE m_SNDistribution_t SET PrintInt=" & LoadD.CurrMaxInt & ", PrintSN='" & LoadD.BarCodeStyleMax & "' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND PartId='" & LoadD.CurrAVCPartID & "' AND CodeRuleId='" & LoadM.CodeRule & "' ")
                SqlStr.Append(vbNewLine & " UPDATE m_SnDistributionStyle_t SET MaxInt=" & LoadD.CurrMaxInt & ", MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND StyleID='" & LoadD.StyleID & "' ")
            End If

            SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & Me.CboLine.Text.Trim & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            Else
                '2016-09-21     马锋      CurrNum更改为txtPrintCount.Text，CurrNum是打印张数
                SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            End If

            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            'LK5MF052-CS-R  
            SqlStr.Append(vbNewLine & "DECLARE @PrinteQuantity FLOAT, @NotPrinteQuantity FLOAT, @CustomerOrderDetailID VARCHAR(32), @PRDimensions VARCHAR(32) ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = '" & txtPrintCount.Text & "' SET @PRDimensions = '" & Microsoft.VisualBasic.Left(LoadD.StyleID, Microsoft.VisualBasic.Len(LoadD.StyleID) - 4) & "' ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN WHILE(@PrinteQuantity > 0) BEGIN ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN SELECT TOP 1 @CustomerOrderDetailID = CustomerOrderDetailID, @NotPrinteQuantity = ExportQuantity - PrinteQuantity  ")
            SqlStr.Append(vbNewLine & "FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0 ORDER BY CreateTime ASC  ")
            SqlStr.Append(vbNewLine & "	IF (@PrinteQuantity > @NotPrinteQuantity) BEGIN	UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @NotPrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & " SET @PrinteQuantity = @PrinteQuantity - @NotPrinteQuantity End ELSE BEGIN  ")
            SqlStr.Append(vbNewLine & "UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @PrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = 0 End End ELSE BEGIN SET @PrinteQuantity = 0 End End End ")

            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            'If UseY = "Y" Then '
            '    MoidPrinted += LoadD.CurrPrintNum
            '    CtPrtingNum -= LoadD.CurrPrintNum
            '    Me.LblMoidOkNum.Text = MoidPrinted & " Box"
            '    Me.LblCartonPrintNum.Text = CtPrtingNum & " Box"
            'End If
            '插入數據庫並傳送打印指令到打印機

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                Conn.ExecSql(SqlStr.ToString)
                FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").Value.ToString)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID)
            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory)
            End If
        End Try
    End Function

    ''码元值生成至数据库，供exce调用
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


#End Region

#End Region


    Private Sub dgvPrintList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrintList.CellLeave

        dgvPrintList.EndEdit()
        TxtDriFlag.Clear()
        TxtBuildAttribute.Clear()
    End Sub

    Private Sub GetPrintInfo(ByVal strMOid As String, ByVal strPartId As String, ByVal strPackid As String, ByVal strPactItem As String)
        Dim sql As String = "SELECT SUM(PRTQTY) QTY FROM m_SnAssign_t WHERE MOID='" & strMOid & "' AND PACKID='" & strPackid & "' GROUP BY MOID"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Using dt As DataTable = Conn.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    TxtDriFlag.Text = "工单申请了" + dt.Rows(0)("qty").ToString
                End If
            End Using
        Catch ex As Exception
        Finally
            If Not Conn Is Nothing Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

    Private Sub FormatMantissaWeight(ByVal missingQty As Integer, ByVal row As DataGridViewRow)
        Try
            If (Not BarCodePartTable Is Nothing) And VbCommClass.VbCommClass.Factory = "LX53" Then
                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso BarCodePartTable.Rows(I).Item("DResource").ToString = "PartSet" Then
                        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "MW") OrElse (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "JW") Then
                            BarCodePartTable.Rows(I).Item("ShortName") = Math.Round(((BarCodePartTable.Rows(I).Item("ShortName") / CInt(row.Cells("PackingQty").Value.ToString)) * missingQty), 2)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitJxPar()
        If VbCommClass.VbCommClass.Factory = "LX53" Then
            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        End If
    End Sub

    Private Function GetJxSql()
        Dim moids As String = Nothing


        'add exclude mo, which mo not line leader request label,  cq 20160901 
        ' Sqlstr.Append(" and m_Mainmo_t.DemandInfo  is not null")

        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtMOId.Text) Then
            moids = "'" & txtMOId.Text & "'"
        Else
            sql = "SELECT DISTINCT A.MOID FROM m_SnAssign_t A JOIN M_MAINMO_T B ON A.MOID=B.MOID WHERE A.ESTATEID NOT IN(3,4) AND PRTQTY>FINISHPRINTQTY AND INTIME BETWEEN CAST('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 00:00:00" & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) AND B.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and B.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' "
            Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        moids &= "'" & dr("MOID") & "',"
                    Next
                End If
            End Using
        End If


        If Not String.IsNullOrEmpty(moids) Then
            moids = moids.Trim(",")
            sql = " SELECT Moid,PartID,Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, " & vbNewLine
            sql &= " m_Dept_t.DQC, m_Mainmo_t.Lineid,m_Mainmo_t.CHECKTEXT, CONVERT(VARCHAR(10),m_Mainmo_t.Plandate,120) AS Plandate, m_Customer_t.CusName, Createuser, Createtime, m_Mainmo_t.Remark, " & vbNewLine
            sql &= " m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime, BlueprintVersion, PackageVersion,PO " & vbNewLine
            sql &= " FROM m_Mainmo_t " & vbNewLine
            sql &= " LEFT JOIN m_Customer_t ON m_Customer_t.CusID=m_Mainmo_t.Cusid " & vbNewLine
            sql &= " LEFT JOIN m_Dept_t ON m_Dept_t.deptid=m_Mainmo_t.Deptid " & vbNewLine
            sql &= " WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' " & vbNewLine
            sql &= " AND m_Mainmo_t.Moid=m_Mainmo_t.ParentMo AND M_MAINMO_T.MOID IN(" & moids & ")"
            If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
                sql += sql & vbNewLine & " and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'"
            End If
            sql += " ORDER BY m_Mainmo_t.Createtime DESC"
            Return sql
        Else
            Return Nothing
        End If
    End Function
End Class