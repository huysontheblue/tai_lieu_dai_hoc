
'Create By:  Nan
'Create Time: 2009/8/7
'條碼編碼原則設置程序

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
'Imports Seagull.BarTender.Print
Imports System.Net.Mail
Imports System.Net

Imports System.Drawing
Imports System.Text
Imports System.IO
Imports System.ComponentModel
Imports System.Resources
Imports System.Drawing.Imaging
'Imports Microsoft.Office.Interop.Outlook

#End Region

Public Class FrmKETPrintSetting

#Region "窗體變量"

    Dim opFlag As Int16 = 0    '新增,修改,初始狀態的標誌 
#Region "Fields"
    ' Common strings.
    Private Const appName As String = "Print Preview"

    'Private engine As Engine = Nothing ' The BarTender Print Engine.
    'Private format As LabelFormatDocument = Nothing ' The format that will be exported.
    Private previewPath As String = "" ' The path to the folder where the previews will be exported.
    Private currentPage As Integer = 1 ' The current page being viewed.
    Private totalPages As Integer ' Number of pages.
    'Private messages As Messages
    Private IsUpload As Boolean = False ''是否有上传
    Private FileNameStr As String = "" ''上传的文件名
#End Region

#End Region

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgm_SnPFormat_t.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

#Region "窗體初始化工作"

    Private Sub FrmKETCodeSet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'If engine IsNot Nothing Then
        '    engine.Stop(SaveOptions.DoNotSaveChanges)
        'End If

        '' Remove the temporary path and all the images.
        'If previewPath.Length <> 0 Then
        '    Directory.Delete(previewPath, True)
        'End If

    End Sub
    '回車轉Tab鍵
    Private Sub FrmKETCodeSet_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case 37 '左方向鍵
                SendKeys.Send("+{Tab}")  '按Shift + Tab 組合鍵 '
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 '上方向鍵 
            Case 39 '右方向鍵 
                'SendKeys.Send("{Tab}")
            Case 40  '下方向鍵 
                'SendKeys.Send("{Tab}")
        End Select
    End Sub

    '#Region "生成單頭列、加載查詢數據"
    '    Private Sub SetGridHeadColumn()

    '        Me.dgM_SnRuleM_t.Columns.Clear()
    '        Dim i As Byte
    '        For i = 0 To 9
    '            Dim col As New DataGridViewRolloverCellColumn()
    '            dgM_SnRuleM_t.Columns.Add(col)
    '        Next
    '        dgM_SnRuleM_t.Rows.Add("編碼原則", "料件編號", "參數代碼", "參數名稱", "參數值", "有效否", "設置人員", "設置時間", "確認人員", "確認時間")
    '        dgM_SnRuleM_t.Rows(0).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#CCFFFF")
    '        dgM_SnRuleM_t.Rows(0).DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("# 0")
    '        'For i = 0 To 9
    '        '    DgPartSet.Columns(i).ReadOnly = True
    '        'Next
    '        dgM_SnRuleM_t.Rows(0).ReadOnly = True
    '        'DgPartSet.AutoResizeColumns()
    '        'DgPartSet.AutoResizeRows()
    '        ''Me.DGBarCode.Columns(0).ReadOnly = True
    '    End Sub

    '#End Region

    '界面加載時
    Private Sub FrmKETCodeSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '檢視用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        '設置初始狀態
        Me.TabControl2.SelectedIndex = 0
        SetStatus(opFlag)
        '清除控件
        ClearPformat()
        ClearRuleD()
        ClearRuleM()
        '加載具體數據
        LoadCbo()
        LoadDataToDgrid(" select a.CodeRuleID, a.Fstyle, a.Fdest, " _
                      & " case a.LabelType when 'S' then 'S-產品條碼' when 'C' then 'C-外箱條碼' when 'P' then 'P-棧板條碼' when 'N' then 'N-無流水號標籤' end as LabelType,  " _
                      & " a.Flen, a.Gflen, a.BarCodeQty, a.TextQty, case a.Usey when 'Y' then 'Y-有效' when 'N' then 'N-無效' end as Usey, a.Remark, b.username as Userid, a.Intime, c.username as Canceluser, a.Canceltime " _
                      & " from M_SnRuleM_t a left join dbo.m_Users_t b on a.Userid=b.Userid left join dbo.m_Users_t c on a.Canceluser=c.userid ", dgM_SnRuleM_t)

        'inItBarPrivie()

    End Sub

    'Private Sub inItBarPrivie()

    '    Try
    '        engine = New Engine(True)
    '    Catch exception As PrintEngineException
    '        ' If the engine is unable to start, a PrintEngineException will be thrown.
    '        MessageBox.Show(Me, exception.Message, appName)
    '        Me.Close() ' Close this app. We cannot run without connection to an engine.
    '        Return
    '    End Try

    ' Get the list of printers
    'Dim printers As New Printers()
    'For Each printer As Printer In printers
    '    cboPrinters.Items.Add(printer.PrinterName)
    'Next printer


    'If printers.Count > 0 Then
    '    ' Automatically select the default printer.
    '    cboPrinters.SelectedItem = printers.Default.PrinterName
    'End If

    '' Hide/Disable preview controls.
    'DisablePreview()

    ' Create a temporary folder to hold the images.
    'Dim tempPath As String = Path.GetTempPath() ' Something like "C:\Documents and Settings\<username>\Local Settings\Temp""
    'Dim newFolder As String

    '' It's not likely we'll have a path that already exists, but we'll check for it anyway.
    '    Do
    '        newFolder = Path.GetRandomFileName()
    '        previewPath = tempPath & newFolder ' newFolder is something crazy like "gulvwdmt.3r4"
    '    Loop While Directory.Exists(previewPath)
    '    Directory.CreateDirectory(previewPath)

    'End Sub

    'Load Data to Combox
    Private Sub LoadCbo()
        LoadDataToCombox("select SortID+'-'+SortName from m_Sortset_t where SortType='labeltype'", cmbLabelType)
        LoadDataToCombox("select distinct(PaperMaterial) from M_SnPFormat_t ", cmbPaperMaterial)
        LoadDataToCombox("select distinct(CodeID) from M_SnPFormat_t ", Me.cmbCodeID)
        LoadDataToCombox("select distinct(FontID) from M_SnPFormat_t ", cmbFontID)
        LoadDataToCombox("select unitid + '-' + descripe as unit from dbo.m_SnUnitM_t", cmbUnitID)

    End Sub
    '清理主表各個控件的內容
    Private Sub ClearRuleM()
        Me.txtCodeRuleID.Text = ""
        Me.txtFlen.Text = ""
        Me.txtGlen.Text = ""
        Me.txtBarCodeQty.Text = ""
        Me.txtTextQty.Text = ""
        Me.txtFstyle.Text = ""
        Me.txtFdest.Text = ""
        Me.txtRemark.Text = ""
        Me.cmbLabelType.SelectedIndex = -1
    End Sub
    '初始化碼元明細表控件內容
    Private Sub ClearRuleD()
        Me.txtF_codeID.Text = ""
        Me.txtF_codename.Text = ""
        Me.txtF_codelen.Text = ""
        Me.txtF_codestart.Text = ""
        Me.TxtSnSet.Text = ""
        Me.TxtSplitChar.Text = ""
        Me.cmbDResource.SelectedIndex = -1
        Me.cmbUnitID.SelectedIndex = -1
        Me.cmbBarArea.SelectedIndex = -1
        Me.cmbType.SelectedIndex = -1
        Me.cmbIsStyle.SelectedIndex = -1
        Me.CobIsPrintStyle.SelectedIndex = -1
        Me.LblMsg.Text = ""
        Me.ChkDate.Checked = False
        If dgM_SnRuleD_t.Rows.Count > 0 Then
            Me.txtF_codestart.Text = CInt(dgM_SnRuleD_t.Rows(dgM_SnRuleD_t.Rows.Count - 1).Cells("F_codestart").Value) + CInt(dgM_SnRuleD_t.Rows(dgM_SnRuleD_t.Rows.Count - 1).Cells("F_codelen").Value)
        Else
            Me.txtF_codestart.Text = 1
        End If

    End Sub
    '清空格式主表控件內容
    Private Sub ClearPformat()
        txtPFormatID.Text = ""
        txtKLabelid.Text = ""
        txtPrinterID.Text = ""
        txtPTemperature.Text = ""
        txtCarbonTape.Text = ""
        txtPaperSize.Text = ""
        txtCusName.Text = ""
        txtDescripe.Text = ""
        cmbColNum.SelectedIndex = -1
        cmbCodeID.SelectedIndex = -1
        cmbFontID.SelectedIndex = -1
        cmbPaperMaterial.SelectedIndex = -1
    End Sub
    '把數據加裁到DataGrid中
    Private Sub LoadDataToDgrid(ByVal Sqlstr As String, ByVal DGrid As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            DGrid.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)
            While DReader.Read()
                If DGrid Is Me.dgM_SnRuleM_t Then
                    DGrid.Rows.Add(DReader.Item("CodeRuleID").ToString, DReader.Item("LabelType").ToString, _
                                   DReader.Item("Flen").ToString, DReader.Item("Gflen").ToString, DReader.Item("BarCodeQty").ToString, _
                                   DReader.Item("TextQty").ToString, DReader.Item("Remark").ToString, DReader.Item("Fstyle").ToString, _
                                   DReader.Item("Fdest").ToString, DReader.Item("UseY").ToString, DReader.Item("Userid").ToString, _
                                   DReader.Item("Intime").ToString)
                ElseIf DGrid Is Me.dgM_SnRuleD_t Then
                    DGrid.Rows.Add(DReader.Item("F_orderid").ToString, DReader.Item("F_codeID").ToString, _
                                   DReader.Item("F_codename").ToString, DReader.Item("F_codelen").ToString, _
                                   DReader.Item("DResource").ToString, DReader.Item("UnitID").ToString, _
                                   DReader.Item("SnSet").ToString, DReader.Item("BarArea").ToString, _
                                   DReader.Item("F_codestart").ToString, DReader.Item("SplitChar").ToString, _
                                   DReader.Item("IsStyle").ToString, _
                                   DReader.Item("IsPrintStyle").ToString, _
                                   DReader.Item("Userid").ToString, DReader.Item("intime").ToString)
                ElseIf DGrid Is Me.dgm_SnPFormat_t Then
                    DGrid.Rows.Add(DReader.Item("PFormatID").ToString, DReader.Item("TemplatePath").ToString, DReader.Item("CusName").ToString, _
                                   DReader.Item("CodeID").ToString, DReader.Item("FontID").ToString, _
                                   DReader.Item("ColNum").ToString, DReader.Item("RowNum").ToString, DReader.Item("KLabelid").ToString, _
                                   DReader.Item("PrinterID").ToString, DReader.Item("PTemperature").ToString, DReader.Item("CarbonTape").ToString, _
                                   DReader.Item("PaperMaterial").ToString, DReader.Item("PaperSize").ToString, _
                                   DReader.Item("Descripe").ToString, DReader.Item("UseY").ToString, _
                                   DReader.Item("Userid").ToString, DReader.Item("Intime").ToString, DReader.Item("PrintStyle").ToString)
                    'ElseIf DGrid Is Me.dgm_SnFormat_t Then
                    '    Me.dgm_SnFormat_t.Rows.Add(DReader.Item("Orderid").ToString, DReader.Item("Commands").ToString, DReader.Item("Areaid").ToString, DReader.Item("Style").ToString)
                End If
            End While
            If DGrid.Rows.Count > 0 Then
                DGrid.CurrentCell = DGrid.Item(0, 0)
            End If
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '把數據加載到combox中
    Private Sub LoadDataToCombox(ByVal sql As String, ByVal cmb As ComboBox)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DReader As SqlClient.SqlDataReader
        Try
            cmb.Items.Clear()
            DReader = Conn.GetDataReader(sql)
            Do While DReader.Read
                cmb.Items.Add(DReader.Item(0).ToString)
            Loop
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            'DReader.Close()
            Throw ex
        End Try
    End Sub
    '設置工具條按鈕的可用
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始狀態
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolCancel.Enabled = IIf(ToolCancel.Tag.ToString = "YES", True, False)
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True
                ToolInPortTxt.Enabled = False
                ToolExportTxt.Enabled = False

                Me.txtFdest.Enabled = False
                Me.txtFstyle.Enabled = False
                Me.txtRemark.Enabled = False
                Me.txtCodeRuleID.Enabled = True
                Me.cmbLabelType.Enabled = True
                Me.dgM_SnRuleM_t.Enabled = True
                Me.ActiveControl = Me.txtCodeRuleID
                Me.btnOpen.Enabled = False
            Case 1, 2 '編碼原則主表的狀態：新增/修改
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolCancel.Enabled = False
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolRefresh.Enabled = False
                ToolInPortTxt.Enabled = False
                ToolExportTxt.Enabled = False

                Me.txtFdest.Enabled = True
                Me.txtFstyle.Enabled = True
                Me.txtRemark.Enabled = True
                Me.txtCodeRuleID.Enabled = False
                Me.dgM_SnRuleM_t.Enabled = False
                Me.ActiveControl = Me.cmbLabelType
                Me.btnOpen.Enabled = False
            Case 3 '編碼原則明細表的狀態： 初始
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolCancel.Enabled = IIf(ToolCancel.Tag.ToString = "YES", True, False)
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True
                ToolInPortTxt.Enabled = False
                ToolExportTxt.Enabled = False

                Me.cmbType.Enabled = True
                Me.txtF_codeID.Enabled = True
                Me.txtF_codename.Enabled = True
                Me.cmbDResource.Enabled = True
                Me.TxtSnSet.Enabled = True
                Me.cmbUnitID.Enabled = True
                Me.CboRuleID.Enabled = True
                Me.txtF_codelen.Enabled = True
                Me.dgM_SnRuleD_t.Enabled = True
                Me.ActiveControl = Me.cmbType
                Me.btnOpen.Enabled = False
            Case 4, 5 '設置編碼原則明細表中按鈕的可用: 新增/修改
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolCancel.Enabled = False
                ToolInPortTxt.Enabled = False
                ToolExportTxt.Enabled = False
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolRefresh.Enabled = False

                Me.CboRuleID.Enabled = False
                Me.cmbType.Enabled = IIf(opFlag = 4, True, False)
                Me.btnOpen.Enabled = False
                Me.dgM_SnRuleD_t.Enabled = False
            Case 6   '設置格式主表狀態： 初始
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolCancel.Enabled = IIf(ToolCancel.Tag.ToString = "YES", True, False)
                ToolInPortTxt.Enabled = False
                ToolExportTxt.Enabled = True
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True

                Me.txtPFormatID.Enabled = True
                Me.CboRuleID2.Enabled = True
                Me.dgm_SnPFormat_t.Enabled = True
                Me.ActiveControl = Me.txtPFormatID
                Me.btnOpen.Enabled = False
                Me.txtFilename.Clear()
                Me.btnOpen.Enabled = False

                Areaid.ReadOnly = True
                Areaid.DefaultCellStyle.BackColor = Color.White
                Style.ReadOnly = True
                Style.DefaultCellStyle.BackColor = Color.White
            Case 7, 8 '設置格式主表狀態： 新增/修改
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolCancel.Enabled = False
                ToolInPortTxt.Enabled = True
                ToolExportTxt.Enabled = False
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolRefresh.Enabled = False

                Me.txtPFormatID.Enabled = False
                Me.dgm_SnPFormat_t.Enabled = False
                Me.CboRuleID2.Enabled = False
                Me.ActiveControl = Me.txtKLabelid
                Me.btnOpen.Enabled = True

                Areaid.ReadOnly = False
                Areaid.DefaultCellStyle.BackColor = Color.LightGreen
                Style.ReadOnly = False
                Style.DefaultCellStyle.BackColor = Color.LightGreen
        End Select
    End Sub

#End Region

#Region "主表工具條各事件"
    '新建
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        TxtRow.Text = 1
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                opFlag = 1
                SetStatus(opFlag)
                ClearRuleM()
            Case 1   '編碼原則明細
                opFlag = 4
                SetStatus(opFlag)
                ClearRuleD()
            Case 2   '格式主表
                opFlag = 7
                SetStatus(opFlag)
                ClearPformat()
                Me.dgm_SnFormat_t.Rows.Clear()
        End Select
    End Sub
    '修改
    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                RuleMEdit()
            Case 1   '編碼原則明細
                RuleDEdit()
            Case 2   '格式主表
                PformatEdit()
        End Select
    End Sub

    '作廢
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                RuleMDel()
            Case 1   '編碼原則明細
                RuleDDel()
            Case 2   '格式主表
                PformatDel()
        End Select
    End Sub
    '保存
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                RuleMSave()
            Case 1   '編碼原則明細
                RuleDSave()
            Case 2   '格式主表
                PformatSave()
        End Select
    End Sub
    '返回
    Private Sub ToolUnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolUnDo.Click
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                opFlag = 0
                SetStatus(opFlag)
                ClearRuleM()
            Case 1   '編碼原則明細
                opFlag = 3
                SetStatus(opFlag)
                ClearRuleD()
            Case 2   '格式主表
                opFlag = 6
                SetStatus(opFlag)
                ClearPformat()
        End Select
    End Sub
    '刷新
    Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click
        Select Case Me.TabControl2.SelectedIndex
            Case 0   '編碼原則主表
                RushDataRuleM()
            Case 1   '編碼原則明細
            Case 2   '格式主表
        End Select
    End Sub
    '導入格式
    Private Sub ToolInPortTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolInPortTxt.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim myreader As StreamReader
            Dim myreceiver As String

            If Me.cmbColNum.Text.Trim = "" Then
                MessageBox.Show("請選擇每行打印列數！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cmbColNum
                Exit Sub
            End If
            dgm_SnFormat_t.Rows.Clear() '清空原來的記錄
            FillDGFormatCbo(Me.CboRuleID2.Text.Trim.Split("-")(0), Me.cmbColNum.Text.Trim)
            myreader = New System.IO.StreamReader(OpenFileDialog1.FileName, System.Text.Encoding.Default)
            myreceiver = myreader.ReadLine
            While Not myreceiver Is Nothing
                If myreceiver.ToString = "" Then '如果為空行跳過
                    myreceiver = myreader.ReadLine
                    Continue While
                End If
                dgm_SnFormat_t.Rows.Add(Me.dgm_SnFormat_t.Rows.Count + 1, myreceiver.ToString, "", "")
                myreceiver = myreader.ReadLine
            End While
        End If
    End Sub
    '導出格式
    Private Sub ToolExportTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExportTxt.Click
        If Me.dgm_SnFormat_t.Rows.Count = 0 Then Exit Sub
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim writer As New StreamWriter(SaveFileDialog1.FileName)
            For i As Int16 = 0 To dgm_SnFormat_t.Rows.Count - 1
                writer.WriteLine(dgm_SnFormat_t.Item("Commands", i).Value.ToString)
            Next
            writer.Close()
        End If
    End Sub
    '退出
    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#End Region

#Region "表格數據刷新"
    '刷新函數塊
    Private Sub RushDataRuleM()
        Dim Sqlstr As New StringBuilder
        Dim Flag As Boolean = False

        Sqlstr.Append(" select a.CodeRuleID, a.Fstyle, a.Fdest, " _
                    & " case a.LabelType when 'S' then 'S-產品條碼' when 'C' then 'C-外箱條碼' when 'P' then 'P-棧板條碼' when 'N' then 'N-無流水號標籤' end as LabelType,  " _
                    & " a.Flen, a.Gflen, a.BarCodeQty, a.TextQty, case a.Usey when 'Y' then 'Y-有效' when 'N' then 'N-無效' end as Usey, a.Remark, b.username as Userid, a.Intime, c.username as Canceluser, a.Canceltime " _
                    & " from M_SnRuleM_t a left join dbo.m_Users_t b on a.Userid=b.Userid left join dbo.m_Users_t c on a.Canceluser=c.userid ")
        If Me.txtCodeRuleID.Text <> "" Then
            Sqlstr.Append(" where a.CodeRuleID='" & Me.txtCodeRuleID.Text.Trim & "'")
            Flag = True
        End If
        If cmbLabelType.Text.Trim <> "" Then
            If Flag = True Then
                Sqlstr.Append(" and a.LabelType='" & Me.cmbLabelType.Text.Trim.Split("-")(0) & "'")
            Else
                Sqlstr.Append(" where a.LabelType='" & Me.cmbLabelType.Text.Trim.Split("-")(0) & "'")
            End If
            Flag = True
        End If
        If Me.txtFlen.Text.Trim <> "" Then
            If Flag = True Then
                Sqlstr.Append(" and a.Flen=" & CInt(Me.txtFlen.Text.Trim))
            Else
                Sqlstr.Append(" where a.Flen=" & CInt(Me.txtFlen.Text.Trim))
            End If
            Flag = True
        End If
        If Me.txtGlen.Text.Trim <> "" Then
            If Flag = True Then
                Sqlstr.Append(" and a.Glen=" & CInt(Me.txtGlen.Text.Trim))
            Else
                Sqlstr.Append(" where a.Glen=" & CInt(Me.txtGlen.Text.Trim))
            End If
            Flag = True
        End If
        If Me.txtBarCodeQty.Text.Trim <> "" Then
            If Flag = True Then
                Sqlstr.Append(" and a.BarCodeQty=" & CInt(Me.txtBarCodeQty.Text.Trim))
            Else
                Sqlstr.Append(" where a.BarCodeQty=" & CInt(Me.txtBarCodeQty.Text.Trim))
            End If
            Flag = True
        End If
        If Me.txtTextQty.Text.Trim <> "" Then
            If Flag = True Then
                Sqlstr.Append(" and a.TextQty=" & CInt(Me.txtTextQty.Text.Trim))
            Else
                Sqlstr.Append(" where a.TextQty=" & CInt(Me.txtTextQty.Text.Trim))
            End If
            Flag = True
        End If
        LoadDataToDgrid(Sqlstr.ToString, dgM_SnRuleM_t)
    End Sub
    '顯示格式表格中的下拉列字段
    Private Sub FillDGFormatCbo(ByVal CodeRuleID As String, ByVal ColNum As Int16)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Rtable As New DataTable
        '打印字串
        Areaid.DataPropertyName = "Areaid"
        Rtable = Conn.GetDataTable("select distinct BarArea from dbo.m_SnRuleD_t where coderuleid='" & CodeRuleID & "' order by BarArea")
        Areaid.DataSource = Rtable
        Areaid.DisplayMember = "BarArea"
        Areaid.ValueMember = "BarArea"
        '所在列
        Style.DataPropertyName = "Style"
        Rtable = Conn.GetDataTable("Create table #temp(a varchar(5)) declare @a varchar(5),@i int set @i=1 set @a=" & ColNum _
                        & " while @i<=convert(int,@a) begin if @i>convert(int,@a) begin BREAK end Else begin insert #temp select @i " _
                        & " set @i=@i+1 Continue End End select a from #temp drop table #temp")
        Dim dr As DataRow = Rtable.NewRow
        dr(0) = ""
        dr("a") = ""
        Rtable.Rows.InsertAt(dr, 0)
        Style.DataSource = Rtable
        Style.DisplayMember = "a"
        Style.ValueMember = "a"
    End Sub

#End Region

#Region "保存前的數據檢驗"
    '編碼原則主表
    Private Function CheckdataRuleM() As Boolean
        '非空校驗
        If Me.cmbLabelType.Text.Trim = "" Then
            MsgBox("請選擇標籤類型!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.cmbLabelType
            Return False
        End If
        If Me.txtFlen.Text = "" OrElse IsNumeric(Me.txtFlen.Text.Trim) = False Then
            MsgBox("請輸入條碼總長度!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtFlen
            Return False
        End If
        If Me.txtGlen.Text = "" OrElse IsNumeric(Me.txtGlen.Text.Trim) = False Then
            MsgBox("請輸入條碼固定部分長度！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtGlen
            Return False
        End If
        If Me.txtBarCodeQty.Text = "" OrElse IsNumeric(Me.txtBarCodeQty.Text.Trim) = False Then
            MsgBox("請輸入條碼數量！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtBarCodeQty
            Return False
        End If
        If Me.txtTextQty.Text = "" OrElse IsNumeric(Me.txtTextQty.Text.Trim) = False Then
            MsgBox("請輸入文本數量！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtTextQty
            Return False
        End If
        'If TxtRow.Text.Trim = "" Then
        '    MsgBox("條碼打印行數不能為空！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Me.ActiveControl = Me.TxtRow
        '    Return False
        'End If
        If CInt(Me.txtFlen.Text.Trim) < CInt(Me.txtGlen.Text.Trim) Then
            MsgBox("固定字符數不應大於總字符數!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtGlen
            Return False
        End If
        Return True
    End Function
    '碼元參數明細表
    Private Function CheckDataRuleD() As Boolean
        '數據校驗
        If Me.txtF_codeID.Text.Trim = "" Then
            MsgBox("请输入码元代码!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtF_codeID
            Return False
        End If
        If Me.cmbType.Text.Trim.Split("-")(0) = "0" AndAlso (Me.txtF_codeID.Text.Trim = "Y" OrElse Me.txtF_codeID.Text.Trim = "DW" OrElse Me.txtF_codeID.Text.Trim = "W" OrElse Me.txtF_codeID.Text.Trim = "D" OrElse Me.txtF_codeID.Text.Trim = "M" OrElse Me.txtF_codeID.Text.Trim = "Q" OrElse Me.txtF_codeID.Text.Trim = "S" OrElse Me.txtF_codeID.Text.Trim = "XC" OrElse Me.txtF_codeID.Text.Trim = "DY") Then
            MsgBox("輸入碼元代碼不能為[Y/M/W/D/S/Q/DW/XC/DY]，请重新输入码元代码!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtF_codeID
            Return False
        End If
        If Me.txtF_codename.Text.Trim = "" Then
            MsgBox("请输入码元名称!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtF_codename
            Return False
        End If
        If Me.cmbDResource.Enabled = True AndAlso Me.cmbDResource.Text = "" Then
            MsgBox("请选择码元的数据来源!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.cmbDResource
            Return False
        End If
        If Me.cmbUnitID.Enabled = True AndAlso Me.cmbUnitID.Text = "" Then
            MsgBox("请选择码元的进制编码!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.cmbUnitID
            Return False
        End If
        If Me.TxtSnSet.Enabled = True AndAlso Me.TxtSnSet.Text.Trim = "" Then
            MsgBox("请输入码元的固定值 !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.TxtSnSet
            Return False
        End If
        If Me.txtF_codelen.Text.Trim = "" OrElse IsNumeric(Me.txtF_codelen.Text.Trim) = False Then
            MsgBox("请输入码元长度!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtF_codelen
            Return False
        End If
        If Me.txtF_codestart.Text.Trim = "" OrElse IsNumeric(Me.txtF_codestart.Text.Trim) = False Then
            MsgBox("请输入开始位置!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.txtF_codestart
            Return False
        End If
        If Me.cmbBarArea.Text.Trim = "" Then
            MsgBox("请选择要加入的对象中!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.cmbBarArea
            Return False
        End If
        If Me.cmbIsStyle.Text.Trim = "" Then
            MsgBox("请选择是否要扫描时检测", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.cmbIsStyle
            Return False
        End If

        If Me.CobIsPrintStyle.Text.Trim = "" Then
            MsgBox("请选择是否要打印时检测", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.CobIsPrintStyle
            Return False
        End If
        If Me.ChkIsSame.Checked AndAlso TxtSplitStr.Text = "" Then
            MsgBox("请输入分隔符", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.TxtSplitStr
            Return False
        End If
        If Me.ChkSnIsSplit.Checked AndAlso TxtSplitQty.Text = "" Then
            MsgBox("请输入流水码长度", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = Me.TxtSplitStr
            Return False
        End If
        Return True
    End Function
    '格式主表
    Private Function CheckDataPformat() As Boolean
        '非空校驗
        If cmbCodeID.Text.Trim = "" Then
            MsgBox("請選擇條碼碼制！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = cmbCodeID
            Return False
        End If
        If cmbFontID.Text = "" Then
            MsgBox("請選擇顯示字體！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = cmbFontID
            Return False
        End If
        If cmbPaperMaterial.Text.Trim = "" Then
            MsgBox("請輸入標籤材質！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = cmbPaperMaterial
            Return False
        End If
        If txtPaperSize.Text.Trim = "" Then
            MsgBox("請輸入標籤尺寸！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtPaperSize
            Return False
        End If
        If txtKLabelid.Text.Trim = "" Then
            MsgBox("請輸入空白標籤料號！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtKLabelid
            Return False
        End If
        If txtPrinterID.Text.Trim = "" Then
            MsgBox("請輸入打印機編號！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtPrinterID
            Return False
        End If
        If txtPTemperature.Text.Trim = "" Then
            MsgBox("請輸入打印溫度！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtPTemperature
            Return False
        End If
        If txtCarbonTape.Text.Trim = "" Then
            MsgBox("請輸入適用碳帶！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtCarbonTape
            Return False
        End If
        'If cmbColNum.Text.Trim = "" Then
        '    MsgBox("請輸入每行打印列數！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Me.ActiveControl = cmbColNum
        '    Return False
        'End If
        If txtCusName.Text.Trim = "" Then
            MsgBox("請輸入客戶名！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Me.ActiveControl = txtCusName
            Return False
        End If
        Return True
    End Function

#End Region

#Region "數據編輯處理"
    '編碼原則主表
    Private Sub RuleMEdit()
        If Me.dgM_SnRuleM_t.Rows.Count = 0 OrElse Me.dgM_SnRuleM_t.CurrentRow Is Nothing Then Exit Sub
        If Me.dgM_SnRuleM_t.Item("Usey", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "N" Then
            MsgBox("該編碼原則已經作廢，不可再修改！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        '給控件賦值
        Me.txtCodeRuleID.Text = Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtFstyle.Text = Me.dgM_SnRuleM_t.Item("Fstyle", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtFdest.Text = Me.dgM_SnRuleM_t.Item("Fdest", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtFlen.Text = Me.dgM_SnRuleM_t.Item("Flen", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtGlen.Text = Me.dgM_SnRuleM_t.Item("Gflen", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtRemark.Text = Me.dgM_SnRuleM_t.Item("Remark", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtBarCodeQty.Text = Me.dgM_SnRuleM_t.Item("BarCodeQty", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.txtTextQty.Text = Me.dgM_SnRuleM_t.Item("TextQty", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
        Me.cmbLabelType.SelectedIndex = Me.cmbLabelType.FindStringExact(Me.dgM_SnRuleM_t.Item("LabelType", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString.Trim)

        opFlag = 2
        SetStatus(opFlag)
        Me.cmbLabelType.Enabled = False
        Me.ActiveControl = Me.txtFlen
    End Sub
    '碼元參數明細表
    Private Sub RuleDEdit()
        If Me.dgM_SnRuleD_t.Rows.Count = 0 Or Me.dgM_SnRuleD_t.CurrentRow Is Nothing Then Exit Sub
        '控件賦值
        opFlag = 5
        SetStatus(opFlag)
        Me.txtF_codeID.Text = Me.dgM_SnRuleD_t.Item("F_codeID", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.txtF_codename.Text = Me.dgM_SnRuleD_t.Item("F_codename", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.txtF_codelen.Text = Me.dgM_SnRuleD_t.Item("F_codelen", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.txtF_codestart.Text = Me.dgM_SnRuleD_t.Item("F_codestart", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.TxtSnSet.Text = Me.dgM_SnRuleD_t.Item("SnSet", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.TxtSplitChar.Text = Me.dgM_SnRuleD_t.Item("SplitChar", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
        Me.cmbBarArea.SelectedIndex = Me.cmbBarArea.FindString(Me.dgM_SnRuleD_t.Item("BarArea", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString.Trim)
        Me.cmbIsStyle.SelectedIndex = Me.cmbIsStyle.FindString(Me.dgM_SnRuleD_t.Item("IsStyle", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString.Trim.Split("-")(0))
        '依據碼元類型決定控件顯示
        Select Case Me.dgM_SnRuleD_t.Item("F_codeID", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString
            Case "Y", "M", "D", "W", "S", "DW", "XC", "DY" '年/月/日/周/流水號/星期幾/校驗位/一年中第幾天
                Me.txtF_codeID.Enabled = False
                Me.txtF_codename.Enabled = False
                Me.txtF_codelen.Enabled = False
                Me.TxtSnSet.Enabled = False
                Me.cmbDResource.SelectedIndex = -1
                Me.cmbDResource.Enabled = False
                Me.cmbUnitID.Enabled = True
                LoadDataToCombox("select UnitID +'-' + Descripe from M_SnUnitM_t where UnitType='" & Me.dgM_SnRuleD_t.Item("F_codeID", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString & "'", Me.cmbUnitID)

                cmbType.SelectedIndex = cmbType.FindString(Me.dgM_SnRuleD_t.Item("F_codeID", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString)
                cmbUnitID.SelectedIndex = cmbUnitID.FindString(Me.dgM_SnRuleD_t.Item("UnitID", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString)
                Me.ActiveControl = Me.cmbUnitID
            Case "Q"
                Me.txtF_codeID.Enabled = False
                Me.txtF_codename.Enabled = True
                Me.TxtSnSet.Enabled = False
                Me.txtF_codelen.Enabled = True
                Me.cmbDResource.Enabled = True
                Me.cmbUnitID.SelectedIndex = -1
                Me.cmbUnitID.Enabled = False

                cmbType.SelectedIndex = 6
                cmbDResource.SelectedIndex = cmbDResource.FindString(Me.dgM_SnRuleD_t.Item("DResource", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString)
                Me.ActiveControl = Me.txtF_codename
            Case Else
                Me.txtF_codeID.Enabled = True
                Me.txtF_codename.Enabled = True
                Me.TxtSnSet.Enabled = False
                Me.txtF_codelen.Enabled = False
                Me.cmbDResource.Enabled = True
                Me.cmbUnitID.SelectedIndex = -1
                Me.cmbUnitID.Enabled = False

                cmbType.SelectedIndex = 0
                cmbDResource.SelectedIndex = cmbDResource.FindString(Me.dgM_SnRuleD_t.Item("DResource", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString)
                Me.ActiveControl = Me.txtF_codeID
        End Select
    End Sub
    '格式主表
    Private Sub PformatEdit()
        If Me.dgm_SnPFormat_t.Rows.Count = 0 Or Me.dgm_SnPFormat_t.CurrentRow Is Nothing Then Exit Sub
        If dgm_SnPFormat_t.Item("PFormatUsey", dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim = "N" Then
            MessageBox.Show("該格式已經作廢，不允許修改！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '控件賦值dgm_SnPFormat_t
        opFlag = 8
        SetStatus(opFlag)
        TxtRow.Text = Me.dgm_SnPFormat_t.Item("RowNum", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtPFormatID.Text = Me.dgm_SnPFormat_t.Item("PFormatID", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtKLabelid.Text = Me.dgm_SnPFormat_t.Item("KLabelid", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtPrinterID.Text = Me.dgm_SnPFormat_t.Item("PrinterID", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtPTemperature.Text = Me.dgm_SnPFormat_t.Item("PTemperature", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtCarbonTape.Text = Me.dgm_SnPFormat_t.Item("CarbonTape", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtPaperSize.Text = Me.dgm_SnPFormat_t.Item("PaperSize", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtDescripe.Text = Me.dgm_SnPFormat_t.Item("Descripe", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        txtCusName.Text = Me.dgm_SnPFormat_t.Item("CusName", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString
        cmbColNum.SelectedIndex = Me.cmbColNum.FindString(dgm_SnPFormat_t.Item("ColNum", dgm_SnPFormat_t.CurrentRow.Index).Value.ToString)
        cmbCodeID.SelectedIndex = Me.cmbCodeID.FindString(dgm_SnPFormat_t.Item("CodeID", dgm_SnPFormat_t.CurrentRow.Index).Value.ToString)
        cmbFontID.SelectedIndex = Me.cmbFontID.FindString(dgm_SnPFormat_t.Item("FontID", dgm_SnPFormat_t.CurrentRow.Index).Value.ToString)
        cmbPaperMaterial.SelectedIndex = Me.cmbPaperMaterial.FindString(dgm_SnPFormat_t.Item("PaperMaterial", dgm_SnPFormat_t.CurrentRow.Index).Value.ToString)
        FillDGFormatCbo(Me.CboRuleID2.Text.Trim.Split("-")(0), CInt(dgm_SnPFormat_t.Item("ColNum", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim) * CInt(dgm_SnPFormat_t.Item("RowNum", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim))
    End Sub

#End Region

#Region "數據作廢處理"
    '編碼原則主表
    Private Sub RuleMDel()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        If Me.dgM_SnRuleM_t.Rows.Count = 0 OrElse Me.dgM_SnRuleM_t.CurrentRow Is Nothing Then Exit Sub
        If Me.dgM_SnRuleM_t.Item("Usey", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "N" Then
            MsgBox("該編碼原則已經作廢，不可再作廢！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        If MsgBox("確定要作廢此編碼原則嗎？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Try
            Conn.ExecSql("update dbo.m_SnRuleM_t set usey='N',canceluser='" & SysMessageClass.UseId.Trim.ToLower & "',canceltime=getdate() where CodeRuleID='" & Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString & "'")
            Me.txtCodeRuleID.Text = Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString
            RushDataRuleM() '修改完畢刷新顯示
            MessageBox.Show("作廢成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "ToolCancel_Click", "sys")
        End Try
    End Sub
    '碼元參數明細表
    Private Sub RuleDDel()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Sqlstr As String
        If Me.dgM_SnRuleD_t.Rows.Count = 0 Or Me.dgM_SnRuleD_t.CurrentRow Is Nothing Then Exit Sub

        If MsgBox("請確認是否刪除?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Try
            Sqlstr = " delete from M_SnRuleD_t where CodeRuleID='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' and F_orderid=" & Me.dgM_SnRuleD_t.Item("F_orderid", Me.dgM_SnRuleD_t.CurrentRow.Index).Value.ToString.Trim
            Sqlstr = Sqlstr & " create table #a(CodeRuleID varchar(8), " _
                     & " F_codeID  varchar(2),F_codename  varchar(50),F_orderid  smallint, " _
                     & " F_codestart  smallint,F_codelen  smallint,UnitID varchar(5),BarArea  varchar(20), " _
                     & " SplitChar  varchar(1),DResource  varchar(50),IsStyle  varchar(1),Userid varchar(10),Intime  datetime) "
            Sqlstr = Sqlstr & " insert #a(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, " _
                    & " UnitID, BarArea, SplitChar, DResource, IsStyle, Userid, Intime) " _
                    & " select CodeRuleID, F_codeID, F_codename, ROW_NUMBER() OVER(ORDER BY BarArea,F_codestart) as F_orderid, " _
                    & " F_codestart, F_codelen, UnitID, BarArea, SplitChar, DResource, IsStyle, Userid, Intime " _
                    & " from dbo.m_SnRuleD_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' " _
                    & " delete  from dbo.m_SnRuleD_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' " _
                    & " insert dbo.m_SnRuleD_t(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, " _
                    & " UnitID, BarArea, SplitChar, DResource, IsStyle, Userid, Intime) select * from #a drop table #a"
            Conn.ExecSql(Sqlstr)
            LoadDataToDgrid("select  a.F_orderid, a.F_codeID, a.F_codename,a.F_codelen,a.DResource,a.UnitID,c.ShortName as Snset,BarArea,F_codestart, SplitChar,case IsStyle when 'Y' " _
                    & " then 'Y-掃描檢測' when 'N' then 'N-掃描不檢測' end as IsStyle,case IsPrintStyle when  then 'Y-打印檢測' when 'N' then 'N-打印不檢測' end as IsPrintStyle,b.username as Userid,a.Intime " _
                    & " from M_SnRuleD_t as a left join dbo.m_Users_t as b on a.userid=b.userid left join dbo.m_SnSet_t as c on a.f_codeid=c.f_codeid and a.coderuleid=c.coderuleid " _
                    & " where a.coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "'", dgM_SnRuleD_t)
            MessageBox.Show("刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "BtnDelete_Click", "sys")
        End Try
    End Sub
    '格式主表
    Private Sub PformatDel()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        If Me.dgm_SnPFormat_t.Rows.Count = 0 Or Me.dgm_SnPFormat_t.CurrentRow Is Nothing Then Exit Sub
        If Me.dgm_SnPFormat_t.Item("PFormatUsey", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString = "N" Then
            MessageBox.Show("該格式已經作廢，不允許作廢！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MsgBox("確定要作廢此打印格式嗎？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Try
            Conn.ExecSql("update dbo.M_SnPFormat_t set usey='N' where PFormatID='" & Me.dgm_SnPFormat_t.Item("PFormatID", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString & "'")
            LoadDataToDgrid("select a.PFormatID,f.TemplatePath, a.CusName, a.CodeID, a.FontID, a.ColNum,a.RowNum,a.KLabelid,a.PrinterID,a.PTemperature,a.CarbonTape,a.PaperMaterial, a.PaperSize,a.Descripe, case a.UseY when 'Y' then 'Y-有效' when 'N' " _
                         & " then 'N-無效' end as UseY, b.username as Userid,a.Intime from m_SnPFormat_t as a left join M_SnMFormat_t f on a.PFormatID=f.PFormatID " _
                         & " left join dbo.m_Users_t as b on a.userid=b.userid where CodeRuleID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "'", dgm_SnPFormat_t)  '完畢刷新顯示
            MessageBox.Show("作廢成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "PformatDel", "sys")
        End Try
    End Sub

#End Region

#Region "數據保存"
    '編碼原則主表
    Private Sub RuleMSave()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder
        '數據檢驗
        If CheckdataRuleM() = False Then Exit Sub
        If MsgBox("請確認資料是否正確?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Try
            If opFlag = 1 Then
                '獲取編碼原則代碼
                SqlStr.Append("declare @CodeRuleid varchar(8) " _
                            & " select @CodeRuleid=max(Coderuleid) from m_SnRuleM_t where LabelType='" & Me.cmbLabelType.Text.Trim.Split("-")(0) _
                            & " ' and left(Coderuleid,1)=case '" & Me.cmbLabelType.Text.Trim.Split("-")(0) & "' when 'S' then 'B' when 'P' then 'P' when 'C' then 'C' when 'N' then 'N' end " _
                            & " if @CodeRuleid is NULL begin " _
                            & " Set @CodeRuleid=case '" & cmbLabelType.Text.Trim.Split("-")(0) & "' when 'S' then 'B' when 'P' then 'P' when 'C' then 'C' when 'N' then 'N' end + '001' " _
                            & " End Else begin Set @CodeRuleid=left(@CodeRuleid,1) + right('000'+ cast(cast(right(@Coderuleid,3) as int)+1 as varchar),3) End ")
                'insert編碼原則
                SqlStr.Append("insert M_SnRuleM_t(CodeRuleID, LabelType, Flen, Gflen,BarCodeQty, TextQty,Usey,Fstyle,Fdest,Remark, userid, intime) values(@CodeRuleid" _
                            & ",'" & Me.cmbLabelType.Text.Trim.Split("-")(0) & "'," & CInt(Me.txtFlen.Text.ToString.Trim) & "," & CInt(Me.txtGlen.Text.ToString.Trim) & "," & CInt(Me.txtBarCodeQty.Text.ToString.Trim) _
                            & "," & CInt(Me.txtTextQty.Text.ToString.Trim) & ",'Y',N'" & Me.txtFstyle.Text.ToString & "',N'" & Me.txtFdest.Text.ToString.Trim _
                            & "',N'" & Me.txtRemark.Text.ToString.Trim & "','" & SysMessageClass.UseId.Trim.ToLower & "',getdate())")
                '返回編碼原則代碼
                SqlStr.Append(" select @CodeRuleid as CodeRuleid ")
            ElseIf opFlag = 2 Then
                'update編碼原則
                SqlStr.Append("update dbo.m_SnRuleM_t set Fstyle='" & Me.txtFstyle.Text.ToString.Trim & "',Fdest=N'" & Me.txtFdest.Text.ToString.Trim _
                      & "', Flen=" & Me.txtFlen.Text.ToString.Trim & ", Gflen=" & Me.txtGlen.Text.Trim & ", BarCodeQty=" & Me.txtBarCodeQty.Text.Trim _
                      & ", TextQty=" & Me.txtTextQty.Text.Trim & ",Remark=N'" & Me.txtRemark.Text.Trim & "', Userid='" & SysMessageClass.UseId.ToLower.Trim & "', Intime=getdate() " _
                      & " where CodeRuleID='" & Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString & "'")
                '返回編碼原則代碼
                SqlStr.Append(" select '" & Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString & "' as CodeRuleid ")
            End If
            opFlag = 0
            SetStatus(opFlag)
            ClearRuleM()
            Rtable = Conn.GetDataTable(SqlStr.ToString.Trim)
            Me.txtCodeRuleID.Text = Rtable.Rows(0)("CodeRuleid").ToString.Trim
            RushDataRuleM() '修改完畢刷新顯示
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtCodeRuleID
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "RuleMSave", "sys")
        End Try
    End Sub
    '碼元參數明細表
    Private Sub RuleDSave()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim SqlStr As New StringBuilder
        '數據檢驗
        If CheckDataRuleD() = False Then Exit Sub
        'If MsgBox("請確認資料是否正確?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Try
            If opFlag = 4 Then '新增
                '產生最大Orderid
                SqlStr.Append(" declare @maxorderid smallint " _
                     & " select @maxorderid=max(F_orderid) from dbo.m_SnRuleD_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' " _
                     & " if @maxorderid is null begin set @maxorderid=1 end else begin set @maxorderid=@maxorderid+1 end ")
                SqlStr.Append(" insert M_SnRuleD_t(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, UnitID, BarArea, SplitChar, DResource, IsStyle,IsPrintStyle,IsDate,IsBoxQty,Userid, Intime) " _
                         & " values('" & Me.CboRuleID.Text.Trim.Split("-")(0) & "','" & txtF_codeID.Text.ToString.Trim _
                         & "',N'" & txtF_codename.Text.ToString.Trim & "',@maxorderid," & txtF_codestart.Text.ToString.Trim & _
                         "," & txtF_codelen.Text.ToString.Trim & ",'" & Me.cmbUnitID.Text.Trim.Split("-")(0) & "','" & cmbBarArea.Text.ToString.Split("-")(0) & "','" & _
                         TxtSplitChar.Text.ToString & "','" & cmbDResource.Text.ToString.Trim.Split("-")(0) & "','" & _
                         cmbIsStyle.Text.Trim.Split("-")(0) & "','" & CobIsPrintStyle.Text.Trim.Split("-")(0) & "','" & IIf(ChkDate.Checked, "Y", "N") & "','" & IIf(ChkPackQty.Checked, "Y", "N") & "','" & SysMessageClass.UseId.Trim.ToLower & "',getdate())")
                If UCase(txtF_codeID.Text.Trim) = "S" And Me.ChkSnIsSplit.Checked = True Then
                    Dim codeStar As Int16 = CInt(txtF_codestart.Text.ToString.Trim)
                    For i As Byte = 0 To CInt(TxtSplitQty.Text) - 2
                        codeStar = codeStar + 1
                        SqlStr.Append(vbNewLine & " insert M_SnRuleD_t(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, UnitID, BarArea, SplitChar, DResource, IsStyle,IsPrintStyle,IsDate,IsBoxQty,Userid, Intime) " _
                         & " values('" & Me.CboRuleID.Text.Trim.Split("-")(0) & "','" & txtF_codeID.Text.ToString.Trim _
                         & "',N'" & txtF_codename.Text.ToString.Trim & "',@maxorderid +1+ " & i & "," & codeStar & _
                         "," & txtF_codelen.Text.ToString.Trim & ",'" & Me.cmbUnitID.Text.Trim.Split("-")(0) & "','" & cmbBarArea.Text.ToString.Split("-")(0) & "','" & _
                         TxtSplitStr.Text.ToString & "','" & cmbDResource.Text.ToString.Trim.Split("-")(0) & "','" & _
                         cmbIsStyle.Text.Trim.Split("-")(0) & "','" & CobIsPrintStyle.Text.Trim.Split("-")(0) & "','" & IIf(ChkDate.Checked, "Y", "N") & "','" & IIf(ChkPackQty.Checked, "Y", "N") & "','" & SysMessageClass.UseId.Trim.ToLower & "',getdate())")
                    Next
                End If
                'If InStr(LCase(cmbBarArea.Text), "barcode") > 0 Then
                '    Dim BarcodeLable As String = Replace(LCase(SqlStr.ToString), "barcode", "BarLabel")
                '    SqlStr.Append(vbNewLine & BarcodeLable)
                'End If
            ElseIf opFlag = 5 Then '修改
                SqlStr.Append(" update M_SnRuleD_t set F_codeID='" & txtF_codeID.Text.ToString.Trim & "', F_codename=N'" & _
                         txtF_codename.Text.ToString.Trim & "', F_codestart=" & txtF_codestart.Text.ToString.Trim & _
                         ", F_codelen=" & txtF_codelen.Text.ToString.Trim & ", UnitID= '" & IIf(cmbUnitID.Text.ToString.Trim <> "", cmbUnitID.Text.Trim.Split("-")(0), "") & _
                          "', BarArea='" & cmbBarArea.Text.ToString.Split("-")(0) & "', SplitChar='" & TxtSplitChar.Text.ToString & _
                          "', DResource=N'" & IIf(cmbDResource.Text.ToString.Trim <> "", cmbDResource.Text.Trim.Split("-")(0), "") & "', IsStyle='" & cmbIsStyle.Text.Trim.Split("-")(0) & _
                          "',IsPrintStyle='" & CobIsPrintStyle.Text.Trim.Split("-")(0) & "',IsDate='" & IIf(ChkDate.Checked, "Y", "N") & "',IsBoxQty='" & IIf(ChkPackQty.Checked, "Y", "N") & "', userid='" & SysMessageClass.UseId.Trim.ToLower & "', intime=getdate() where CodeRuleID='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' and F_orderid=" & _
                          dgM_SnRuleD_t.Item("F_orderid", dgM_SnRuleD_t.CurrentRow.Index).Value.ToString)
            End If
            '添加SnSet固定碼元值
            If Me.TxtSnSet.Enabled = True Then
                SqlStr.Append(" delete  from m_SnSet_t where CodeRuleID='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' and F_codeID='" & txtF_codeID.Text.ToString.Trim & "'")
                SqlStr.Append(" insert m_SnSet_t(CodeRuleID, F_codeID, ShortName, FullName, Userid, Intime) values('" & Me.CboRuleID.Text.Trim.Split("-")(0) & "',N'" & txtF_codeID.Text.ToString.Trim & "'" _
                              & ",N'" & Me.TxtSnSet.Text.ToString & "','','" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
            End If
            '重新排序作業
            SqlStr.Append(" CREATE TABLE #a(CodeRuleID [varchar](8),F_codeID [varchar](2),F_codename [nvarchar](50), " _
                        & " F_orderid [smallint] ,F_codestart [smallint],F_codelen [smallint],UnitID [varchar](5), " _
                        & " BarArea [varchar](20),SplitChar [varchar](1),DResource [varchar](50),IsStyle [varchar](1),IsPrintStyle [varchar](1),IsDate [varchar](1),IsBoxQty [varchar](1), " _
                        & " Userid [varchar](10),Intime [datetime]) ")
            SqlStr.Append(" insert #a(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, " _
                    & " UnitID, BarArea, SplitChar, DResource, IsStyle,IsPrintStyle,IsDate,IsBoxQty, Userid, Intime) " _
                    & " select CodeRuleID, F_codeID, F_codename, ROW_NUMBER() OVER(ORDER BY BarArea,F_codestart) as F_orderid, " _
                    & " F_codestart, F_codelen, UnitID, BarArea, SplitChar, DResource, IsStyle,IsPrintStyle,IsDate,IsBoxQty, Userid, Intime " _
                    & " from dbo.m_SnRuleD_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' " _
                    & " delete  from dbo.m_SnRuleD_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "' " _
                    & " insert dbo.m_SnRuleD_t(CodeRuleID, F_codeID, F_codename, F_orderid, F_codestart, F_codelen, " _
                    & " UnitID, BarArea, SplitChar, DResource, IsStyle,IsPrintStyle,IsDate,IsBoxQty, Userid, Intime) select * from #a drop table #a")
            Conn.ExecSql(SqlStr.ToString)

            opFlag = 3
            SetStatus(opFlag)
            ClearRuleD()
            LoadDataToDgrid(" select  a.F_orderid, a.F_codeID, a.F_codename,a.F_codelen,a.DResource,a.UnitID,c.ShortName as Snset,BarArea,F_codestart, SplitChar,case IsStyle when 'Y' " _
                    & " then N'Y-扫描檢測' when 'N' then N'N-扫描不檢測' end as IsStyle,case IsPrintStyle when 'Y' then N'Y-打印檢測' when 'N' then N'N-打印不檢測' end as IsPrintStyle,IsDate,b.username as Userid,a.Intime " _
                    & " from M_SnRuleD_t as a left join dbo.m_Users_t as b on a.userid=b.userid left join dbo.m_SnSet_t as c on a.f_codeid=c.f_codeid and a.coderuleid=c.coderuleid " _
                    & " where a.coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "'", dgM_SnRuleD_t)
            ''MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.LblMsg.Text = "保存成功..."
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "RuleDSave", "sys")
        End Try
    End Sub


    Private Sub SavePictureToServer(ByVal PathStr As String, ByVal FileName As String)

        '创建一个bitmap类型的bmp变量来读取文件。
        Dim bmp As New Bitmap(Me.picPreview.Image)
        '新建第二个bitmap类型的bmp2变量，我这里是根据我的程序需要设置的。
        Dim bmp2 As New Bitmap(1024, 768, PixelFormat.Format16bppRgb555)
        '将第一个bmp拷贝到bmp2中
        picPreview.Dispose()
        Dim draw As Graphics = Graphics.FromImage(bmp2)
        draw.DrawImage(bmp, 0, 0)
        Dim aImage As Image = DirectCast(bmp2, Image)
        aImage.Save(PathStr & "\" & txtPFormatID.Text.Trim & ".jpg")
        '读取bmp2到picturebox
        'File = OpenFileDialog1.FileName
        'OpenFileDialog1.Dispose()
        draw.Dispose()
        bmp.Dispose()
        '释放bmp文件资源


    End Sub
    '格式主表
    Private Sub PformatSave()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim SqlStr As New StringBuilder
        '數據檢驗
        Me.dgm_SnFormat_t.EndEdit()
        cmbColNum.Text = "1"
        TxtRow.Text = "1"
        If CheckDataPformat() = False Then Exit Sub
        'If MsgBox("請確認資料是否正確?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then Exit Sub '保存前的確認提示
        Dim PrintStyle As String
        PrintStyle = IIf(ChkModle.Checked, "1", "0") ''''0为指令打印  1为模板打印
        Try
            If opFlag = 7 Then  '新建
                '產生格式ID
                Dim PFormatID As String = ""
                SqlStr.Append("declare @PFormatID varchar(8) select @PFormatID=max(PFormatID) from dbo.m_SnPFormat_t where CodeRuleID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "'" _
                         & " if @PFormatID is NULL begin Set @PFormatID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "' + '-F' + '01' End Else begin " _
                         & " Set @PFormatID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "' + '-F' + right('00'+ cast(cast(right(@PFormatID,2) as int)+1 as varchar),2) End select @PFormatID as PFormatID")
                Dim Mreader As SqlDataReader = Conn.GetDataReader(SqlStr.ToString)
                If Mreader.HasRows Then
                    While Mreader.Read
                        PFormatID = Mreader!PFormatID.ToString
                    End While
                Else
                    Exit Sub
                    Mreader.Close()
                End If
                Mreader.Close()
                SqlStr.Remove(0, SqlStr.Length)
                '保存格式主表
                SqlStr.Append(ControlChars.CrLf & "insert M_SnPFormat_t(PFormatID,CodeRuleID,CusName,CodeID,FontID,Papermaterial,PaperSize,ColNum,RowNum," & _
                "KLabelid,PrinterID,PTemperature,CarbonTape,Descripe,UseY,Userid,Intime,PrintStyle) values('" & PFormatID & "','" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "',N'" & _
                txtCusName.Text.Trim & "','" & cmbCodeID.Text.Trim & "','" & cmbFontID.Text.Trim & "',N'" & _
                cmbPaperMaterial.Text.Trim & "',N'" & txtPaperSize.Text.Trim & "','" & cmbColNum.Text.Trim & "','" & Me.TxtRow.Text.Trim & "',N'" & _
                 txtKLabelid.Text.Trim & "',N'" & txtPrinterID.Text.Trim & "',N'" & txtPTemperature.Text.Trim & "',N'" & txtCarbonTape.Text.Trim & "'," & _
                  "'" & txtDescripe.Text.Trim & "','Y','" & SysMessageClass.UseId.ToLower.Trim & "',getdate(),'" & PrintStyle & "')")
                '保存格式命令
                If ChkModle.Checked = False Then  '''''条码打印机指令打印。
                    For i As Int16 = 0 To Me.dgm_SnFormat_t.Rows.Count - 1
                        SqlStr.Append(ControlChars.CrLf & "insert m_SnFormat_t(PFormatID,Orderid,Commands,Areaid,Style,Description,Userid,Intime) values ('" & PFormatID & "'," & _
                                dgm_SnFormat_t.Rows(i).Cells("Orderid").Value.ToString & ",'" & dgm_SnFormat_t.Rows(i).Cells("Commands").Value.ToString & "','" & _
                                dgm_SnFormat_t.Rows(i).Cells("Areaid").Value & "','" & dgm_SnFormat_t.Rows(i).Cells("Style").Value & "','','" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
                    Next
                Else ''''''''采用bartender或codesoft模板打印方式  
                    Dim SavePathFileName As String = String.Empty
                    'Dim resourceMgrIns As ResourceManager
                    Dim value As String
                    Dim FilePath As String
                    Dim picPath As String
                    'resourceMgrIns = New ResourceManager("BarCodePrint.Resources", GetType(My.Resources.Resources).Assembly)
                    value = PFormatID & "\" & FileNameStr
                    'value = VbCommClass.VbCommClass.PrintDataModle & PFormatID & "\" & FileNameStr
                    FilePath = VbCommClass.VbCommClass.PrintDataModle & PFormatID
                    picPath = FilePath & "\" & txtPFormatID.Text.Trim & DateTime.Now.ToString("yyyyMMddhhmmss") & ".jpg"
                    SqlStr.Append(vbNewLine & "insert M_SnMFormat_t(PFormatID,TemplatePath,OldPath,Descript,userid,intime)values('" & PFormatID & "',N'" & value & "',N'" & _
                      picPath & "',N'" & txtDescripe.Text & "','" & SysMessageClass.UseId & "',getdate())")
                    If Me.txtFilename.Text <> "" Then
                        If System.IO.Directory.Exists(FilePath) = False Then
                            Directory.CreateDirectory(FilePath)
                            'File.Create(FilePath & FilePath)
                        End If
                        File.Copy(Me.txtFilename.Text, VbCommClass.VbCommClass.PrintDataModle & value, True)
                    End If
                    'If Not IsNothing(picPreview.Image) Then
                    '    picPreview.Image.Save(picPath)
                    'End If
                End If
            ElseIf opFlag = 8 Then '修改
                '保存格式主表
                SqlStr.Append("update M_SnPFormat_t set CusName='" & txtCusName.Text.Trim & "',CodeID='" & cmbCodeID.Text.Trim & _
                "',FontID='" & cmbFontID.Text.Trim & "',PaperMaterial=N'" & cmbPaperMaterial.Text.Trim & "',PaperSize=N'" & _
                txtPaperSize.Text.Trim & "',ColNum='" & cmbColNum.Text.Trim & "',RowNum='" & Me.TxtRow.Text.Trim & "',KLabelid=N'" & txtKLabelid.Text.Trim & _
                "',PrinterID=N'" & txtPrinterID.Text.Trim & "',PTemperature=N'" & txtPTemperature.Text.Trim & "',CarbonTape=N'" & txtCarbonTape.Text.Trim & _
                "',Descripe='" & txtDescripe.Text.Trim & "',Userid='" & SysMessageClass.UseId.ToLower.Trim & "',Intime=getdate(),PrintStyle='" & PrintStyle & "'  where PFormatID='" & _
                txtPFormatID.Text.Trim & "'")
                '保存格式命令   
                If ChkModle.Checked = False Then  '''''条码打印机指令打印。
                    SqlStr.Append(ControlChars.CrLf & "delete from m_SnFormat_t where PFormatID='" & Me.txtPFormatID.Text.Trim & "'")
                    For i As Int16 = 0 To Me.dgm_SnFormat_t.Rows.Count - 1
                        SqlStr.Append(ControlChars.CrLf & "insert m_SnFormat_t(PFormatID,Orderid,Commands,Areaid,Style,Description,Userid,Intime) values ('" & Me.txtPFormatID.Text.Trim & "'," & _
                                dgm_SnFormat_t.Rows(i).Cells("Orderid").Value.ToString & ",'" & dgm_SnFormat_t.Rows(i).Cells("Commands").Value.ToString & "','" & _
                                dgm_SnFormat_t.Rows(i).Cells("Areaid").Value & "','" & dgm_SnFormat_t.Rows(i).Cells("Style").Value & "','','" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
                    Next
                Else ''''模板打印
                    If IsUpload = True Then
                        Dim SavePathFileName As String = String.Empty
                        'Dim resourceMgrIns As ResourceManager
                        Dim value As String
                        Dim FilePath As String
                        Dim picPath As String
                        'resourceMgrIns = New ResourceManager("BarCodePrint.Resources", GetType(My.Resources.Resources).Assembly)

                        FilePath = VbCommClass.VbCommClass.PrintDataModle & txtPFormatID.Text
                        'value = VbCommClass.VbCommClass.PrintDataModle & txtPFormatID.Text & "\" & FileNameStr
                        value = txtPFormatID.Text & "\" & FileNameStr
                        picPath = FilePath & "\" & txtPFormatID.Text.Trim & DateTime.Now.ToString("yyyyMMddhhmmss") & ".jpg"


                        SqlStr.Append(vbNewLine & "delete from M_SnMFormat_t where PFormatID='" & txtPFormatID.Text & "'")
                        SqlStr.Append(vbNewLine & "insert M_SnMFormat_t(PFormatID,TemplatePath,OldPath,Descript,userid,intime)values('" & txtPFormatID.Text & "',N'" & value & "',N'" & _
                        picPath & "',N'" & txtDescripe.Text & "','" & SysMessageClass.UseId & "',getdate())")
                        'SqlStr.Append(vbNewLine & "update M_SnMFormat_t set TemplatePath=N'" & value & "' ,OldPath=TemplatePath,Descript=N'" & txtDescripe.Text & "'," & _
                        '   " userid='" & SysMessageClass.UseId & "',intime =getdate() where PFormatID='" & Me.txtPFormatID.Text.Trim & "'")
                        If Me.txtFilename.Text <> "" Then
                            If System.IO.Directory.Exists(FilePath) = False Then
                                Directory.CreateDirectory(FilePath)
                                'File.Create(FilePath & FilePath)
                            End If
                            File.Copy(Me.txtFilename.Text, VbCommClass.VbCommClass.PrintDataModle & value, True)
                            'If Not IsNothing(picPreview.Image) Then
                            '    picPreview.Image.Save(picPath)
                            'End If
                        End If
                    End If
                End If
            End If
            Conn.ExecSql(SqlStr.ToString)

            '保存后顯示更新數據
            LoadDataToDgrid("select a.PFormatID,f.TemplatePath, a.CusName, a.CodeID, a.FontID, a.ColNum,a.RowNum,a.KLabelid,a.PrinterID,a.PTemperature,a.CarbonTape,a.PaperMaterial, a.PaperSize,a.Descripe, case a.UseY when 'Y' then 'Y-有效' when 'N' " _
                     & " then 'N-無效' end as UseY, b.username as Userid,a.Intime,a.PrintStyle from m_SnPFormat_t as a left join M_SnMFormat_t f on a.PFormatID=f.PFormatID" _
                     & " left join dbo.m_Users_t as b on a.userid=b.userid where CodeRuleID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "'", dgm_SnPFormat_t)
            opFlag = 6
            SetStatus(opFlag)
            ClearPformat()
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPFormatID.Text = Me.dgm_SnPFormat_t.Item(0, Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim
            Me.ActiveControl = Me.txtPFormatID
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCodeSet", "PformatSave", "sys")
        End Try
    End Sub

#End Region

#Region "Txt/Cbo/Dg/TabControl2"
    '對輸入進行檢驗，隻能輸入數字
    Private Sub txtFlen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFlen.KeyPress, txtGlen.KeyPress, txtBarCodeQty.KeyPress, txtTextQty.KeyPress, txtF_codelen.KeyPress, txtF_codestart.KeyPress
        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
    '輸入固定碼元后，自動帶出字符長度
    Private Sub TxtSnSet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnSet.Leave
        If Me.TxtSnSet.Text.ToString <> "" Then Me.txtF_codelen.Text = Len(Me.TxtSnSet.Text.ToString)
    End Sub
    '不同類型，進制自動顯示
    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If Me.cmbType.Text = "" OrElse opFlag = 5 Then Exit Sub
        Select Case cmbType.Text.Trim.Split("-")(0)
            Case "0" '自定義
                Me.txtF_codeID.Enabled = True
                Me.txtF_codename.Enabled = True
                Me.TxtSnSet.Enabled = False
                Me.txtF_codelen.Enabled = False
                Me.txtF_codeID.Text = ""
                Me.txtF_codename.Text = ""
                Me.TxtSnSet.Text = ""
                Me.txtF_codelen.Text = ""

                Me.cmbDResource.SelectedIndex = -1
                Me.cmbDResource.Enabled = True
                Me.cmbUnitID.SelectedIndex = -1
                Me.cmbUnitID.Enabled = False
                Me.ActiveControl = Me.txtF_codeID
            Case "Y", "M", "D", "W", "DW", "S", "XC", "DY" 'Y-年份,M-月份,D-日期,W-周別,DW-星期幾,S-流水號,XC-校驗位
                Me.txtF_codeID.Enabled = False
                Me.txtF_codename.Enabled = False
                Me.txtF_codeID.Text = Me.cmbType.Text.Trim.Split("-")(0)
                Me.txtF_codename.Text = Me.cmbType.Text.Trim.Split("-")(1)
                Me.txtF_codelen.Enabled = False
                Me.txtF_codelen.Text = ""
                Me.TxtSnSet.Enabled = False
                Me.TxtSnSet.Text = ""

                Me.cmbDResource.SelectedIndex = -1
                Me.cmbDResource.Enabled = False
                Me.cmbUnitID.SelectedIndex = -1
                Me.cmbUnitID.Enabled = True
                Me.ActiveControl = Me.cmbUnitID
                LoadDataToCombox("select UnitID +'-' + Descripe from M_SnUnitM_t where UnitType='" & Me.cmbType.Text.Trim.Split("-")(0) & "'", Me.cmbUnitID)

            Case "Q" 'Q-數量
                Me.txtF_codeID.Enabled = False
                Me.txtF_codename.Enabled = True
                Me.txtF_codeID.Text = "Q"
                Me.txtF_codename.Text = "數量"
                Me.TxtSnSet.Enabled = False
                Me.txtF_codelen.Enabled = True
                Me.TxtSnSet.Text = ""
                Me.txtF_codelen.Text = ""

                Me.cmbDResource.SelectedIndex = -1
                Me.cmbDResource.Enabled = True
                Me.cmbUnitID.SelectedIndex = -1
                Me.cmbUnitID.Enabled = False
                Me.ActiveControl = Me.txtF_codename
        End Select
    End Sub
    '選擇數據來源，控制固定字符的是否可設置
    Private Sub cmbDResource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDResource.SelectedIndexChanged
        If Me.cmbDResource.Text.Trim = "" Then Exit Sub
        Me.TxtSnSet.Enabled = IIf(Me.cmbDResource.Text.Trim.Split("-")(0) = "SnSet", True, False)
        Me.txtF_codelen.Enabled = IIf(Me.cmbDResource.Text.Trim.Split("-")(0) = "SnSet", False, True)
    End Sub
    '選擇不同進制，自動帶出字符長度
    Private Sub cmbUnitID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUnitID.SelectedIndexChanged
        If Me.cmbUnitID.Text = "" Then Exit Sub
        Dim Conn As New SysDataBaseClass
        Dim RData As New DataTable
        RData = Conn.GetDataTable("select Charqty from M_SnUnitM_t where UnitID='" & Me.cmbUnitID.Text.Trim.Split("-")(0) & "'")
        Me.txtF_codelen.Text = RData.Rows(0)(0).ToString.Trim
        Conn = Nothing
    End Sub
    '選擇編碼原則，帶出編碼原則明細碼元
    Private Sub CboRuleID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuleID.SelectedIndexChanged
        Dim Conn As New SysDataBaseClass
        Dim Rtable As New DataTable
        '刷出碼元參數明細
        LoadDataToDgrid("select  a.F_orderid, a.F_codeID, a.F_codename,a.F_codelen,a.DResource,a.UnitID,c.ShortName as Snset,BarArea,F_codestart, SplitChar,case IsStyle when 'Y' " _
                    & " then 'Y-掃描檢測' when 'N' then 'N-掃描不檢測' end as IsStyle,case IsPrintStyle when 'Y' then 'Y-打印檢測' when 'N' then 'N-打印不檢測' end as IsPrintStyle,b.username as Userid,a.Intime " _
                    & " from M_SnRuleD_t as a left join dbo.m_Users_t as b on a.userid=b.userid left join dbo.m_SnSet_t as c on a.f_codeid=c.f_codeid and a.coderuleid=c.coderuleid " _
                    & " where a.coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "'", dgM_SnRuleD_t)
        Rtable = Conn.GetDataTable("select BarCodeQty,TextQty,Usey from dbo.m_SnRuleM_t where coderuleid='" & Me.CboRuleID.Text.Trim.Split("-")(0) & "'")
        '自動生成打印字串
        Me.cmbBarArea.Items.Clear()
        If Rtable.Rows.Count = 0 Then Exit Sub
        ToolNew.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        ToolEdit.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        ToolCancel.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        If Rtable.Rows(0)(0).ToString.Trim <> "" Then
            For i As Integer = 1 To Rtable.Rows(0)(0).ToString.Trim
                Me.cmbBarArea.Items.Add("BarCode" & i.ToString & "-条码")
                Me.cmbBarArea.Items.Add("BarLabel" & i.ToString & "-条码文本")
            Next
        End If
        If Rtable.Rows(0)(1).ToString.Trim <> "" Then
            For i As Integer = 1 To Rtable.Rows(0)(1).ToString.Trim
                Me.cmbBarArea.Items.Add("Label" & i.ToString & "-标签文本")
            Next
        End If
    End Sub
    '選擇編碼原則，帶出格式主表及明細表
    Private Sub CboRuleID2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuleID2.SelectedIndexChanged
        Dim Conn As New SysDataBaseClass
        Dim Rtable As New DataTable
        Rtable = Conn.GetDataTable("select BarCodeQty,TextQty,Usey from dbo.m_SnRuleM_t where coderuleid='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "'")
        If Rtable.Rows.Count = 0 Then Exit Sub
        ToolNew.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        ToolEdit.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        ToolCancel.Enabled = IIf(Rtable.Rows(0)(2).ToString.Trim = "Y", True, False)
        '刷出格式主表
        LoadDataToDgrid("select a.PFormatID,f.TemplatePath,a.CusName, a.CodeID, a.FontID, a.ColNum,a.RowNum,a.KLabelid,a.PrinterID,a.PTemperature,a.CarbonTape,a.PaperMaterial, a.PaperSize,a.Descripe, case a.UseY when 'Y' then 'Y-有效' when 'N' " _
                     & " then 'N-無效' end as UseY, b.username as Userid,a.Intime,PrintStyle from m_SnPFormat_t as a left join m_SnMFormat_t f on a.PFormatID=f.PFormatID " _
                     & " left join dbo.m_Users_t as b on a.userid=b.userid where CodeRuleID='" & Me.CboRuleID2.Text.Trim.Split("-")(0) & "'", dgm_SnPFormat_t)
        Me.dgm_SnFormat_t.Rows.Clear()
        If Me.dgm_SnPFormat_t.Rows.Count = 0 OrElse Me.dgm_SnPFormat_t.CurrentRow Is Nothing Then Exit Sub
        FillDGFormatCbo(Me.CboRuleID2.Text.Trim.Split("-")(0), CInt(dgm_SnPFormat_t.Item("ColNum", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim) * CInt(dgm_SnPFormat_t.Item("RowNum", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString.Trim))
        '刷出格式明細
        'LoadDataToDgrid("select Orderid,isnull(Commands,'') as Commands,isnull(Areaid,'') as Areaid,isnull(Style,'') as Style " _
        '         & " from m_SnFormat_t where PFormatID='" & Me.dgm_SnPFormat_t.Item("PFormatID", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString & "'", dgm_SnFormat_t)
    End Sub
    '單擊刷出打印格式具體指令
    'Private Sub dgm_SnPFormat_t_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgm_SnPFormat_t.CellEnter
    '    dgm_SnFormat_t.Rows.Clear()
    '    Me.picPreview.Image = Nothing
    '    If Me.dgm_SnPFormat_t.Rows.Count = 0 OrElse Me.dgm_SnPFormat_t.CurrentRow Is Nothing Then Exit Sub
    '    Try

    '        If dgm_SnPFormat_t.CurrentRow.Cells("ColPstyle").Value = 0 Then
    '            LoadDataToDgrid("select Orderid,isnull(Commands,'') as Commands,isnull(Areaid,'') as Areaid,isnull(Style,'') as Style,Description,b.username as Userid,a.Intime " _
    '                    & " from m_SnFormat_t as a left join dbo.m_Users_t as b on a.userid=b.userid where a.PFormatID='" & Me.dgm_SnPFormat_t.Item("PFormatID", Me.dgm_SnPFormat_t.CurrentRow.Index).Value.ToString & "'", dgm_SnFormat_t)
    '        Else
    '            'Dim resourceMgrIns As ResourceManager
    '            'Dim FilePath As String
    '            'resourceMgrIns = New ResourceManager("BarCodePrint.Resources", GetType(My.Resources.Resources).Assembly)
    '            'FilePath = resourceMgrIns.GetString("TemplatePath") & dgm_SnPFormat_t.CurrentRow.Cells("PFormatID").Value & "\" & dgm_SnPFormat_t.CurrentRow.Cells("PFormatID").Value & ".jpg"
    '            'Me.picPreview.Image = Image.FromFile(FilePath)
    '            Dim Conn As New SysDataBaseClass
    '            'Dim Mreader As SqlDataReader
    '            Dim PriveStr As String
    '            Dim Mreader As SqlDataReader = Conn.GetDataReader("select OldPath from m_SnMFormat_t where PFormatID='" & Me.dgm_SnPFormat_t.CurrentRow.Cells("PFormatID").Value & "'")
    '            If Mreader.HasRows Then
    '                While Mreader.Read
    '                    PriveStr = Mreader!OldPath
    '                End While
    '            End If
    '            Mreader.Close()
    '            Me.picPreview.Image = Image.FromFile(PriveStr)
    '        End If


    '    Catch ex As Exception
    '        'MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    '錯誤事件
    'Private Sub dgm_SnFormat_t_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgm_SnFormat_t.DataError
    '    e.Cancel = True
    'End Sub


    Private Sub ForbidSortColumn(ByVal dgv As DataGridView)
        For i As Integer = 0 To dgv.Columns.Count - 1
            dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub


    'TabControl1事件
    Private Sub TabControl2_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl2.Selecting
        If opFlag <> 0 AndAlso opFlag <> 3 AndAlso opFlag <> 6 Then Me.TabControl2.SelectedIndex = Me.TabControl2.Tag : Exit Sub
        Me.TabControl2.Tag = Me.TabControl2.SelectedIndex
        Select Case Me.TabControl2.SelectedIndex
            Case 0
                opFlag = 0
                SetStatus(opFlag)
            Case 1
                opFlag = 3
                SetStatus(opFlag)
                '顯示碼元明細表數據
                cmbBarArea.Items.Clear()
                dgM_SnRuleD_t.Rows.Clear()
                LoadDataToCombox("select CodeRuleID + '-' + Remark from dbo.m_SnRuleM_t", Me.CboRuleID)
                Me.CboRuleID.SelectedIndex = Me.CboRuleID.FindString(Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString)
                ForbidSortColumn(dgM_SnRuleD_t)
            Case 2
                opFlag = 6
                SetStatus(opFlag)
                '顯示格式主表和明細表數據
                dgm_SnPFormat_t.Rows.Clear()
                dgm_SnFormat_t.Rows.Clear()
                LoadDataToCombox("select CodeRuleID + '-' + Remark from dbo.m_SnRuleM_t", Me.CboRuleID2)
                Me.CboRuleID2.SelectedIndex = Me.CboRuleID2.FindString(Me.dgM_SnRuleM_t.Item("CodeRuleID", Me.dgM_SnRuleM_t.CurrentRow.Index).Value.ToString)
                If Me.ChkModle.Checked Then
                    dgm_SnFormat_t.Visible = False
                    Me.panel1.Visible = True
                Else
                    dgm_SnFormat_t.Visible = True
                    panel1.Visible = False
                End If
        End Select
    End Sub

#End Region

    Private Sub TxtRow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRow.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ChkModle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkModle.CheckedChanged

        If Me.ChkModle.Checked Then
            dgm_SnFormat_t.Visible = False
            Me.panel1.Visible = True
        Else
            dgm_SnFormat_t.Visible = True
            panel1.Visible = False
        End If

    End Sub

    'Private Sub PriveiwImage(ByVal FilePath As String)
    '    ' Let's disable some controls until we are done.
    '    btnOpen.Enabled = False
    '    'cboPrinters.Enabled = False
    '    'btnPreview.Enabled = False

    '    Dim result As DialogResult = openFileDialog.ShowDialog()
    '    'If result = System.Windows.Forms.DialogResult.OK Then
    '    Cursor.Current = Cursors.WaitCursor

    '    ' Close the previous format.
    '    If format IsNot Nothing Then
    '        format.Close(SaveOptions.DoNotSaveChanges)
    '    End If

    '    ' We need to delete the files associated with the last format.
    '    Dim files() As String = Directory.GetFiles(previewPath)
    '    For Each filename As String In files
    '        File.Delete(filename)
    '    Next filename

    '    ' Put the UI back into a non-preview state.
    '    'DisablePreview()
    '    'txtFilename.Text = openFileDialog.FileName
    '    ' Open the format.

    '    Try
    '        format = engine.Documents.Open(FilePath)
    '        FileNameStr = format.Title

    '    Catch comException As System.Runtime.InteropServices.COMException
    '        MessageBox.Show(Me, String.Format("Unable to open format: {0}" & Constants.vbLf & "Reason: {1}", openFileDialog.FileName, comException.Message), appName)
    '        format = Nothing
    '    End Try

    '    ' Only allow preview button if we successfully loaded the format.
    '    'btnPreview.Enabled = (format IsNot Nothing)

    '    If format IsNot Nothing Then
    '        ' Select the printer in use by the format.
    '        'cboPrinters.SelectedItem = format.PrintSetup.PrinterName
    '        'format.
    '    End If

    '    'Cursor.Current = Cursors.Default
    '    'End If
    '    ' Restore some controls.
    '    btnOpen.Enabled = True
    '    'cboPrinters.Enabled = True

    '    'format.PrintSetup.PrinterName = cboPrinters.SelectedItem.ToString()

    '    ' Set control states to show working. These will be reset when the work completes.
    '    picUpdating.Visible = True

    '    ' Have the background worker export the BarTender format.
    '    'format.PageSetup.LabelHeight = 600
    '    'format.PageSetup.LabelWidth = 600
    '    backgroundWorker.RunWorkerAsync(format)
    '    If opFlag = 8 Then
    '        IsUpload = True
    '    End If

    'End Sub

    Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpen.Click


        ''Public Sub Demo()
        '' Initialize a new BarTender print engine.
        'Using btEngine As New Engine()
        '    ' Start the BarTender print engine.
        '    btEngine.Start()
        '    Dim result1 As DialogResult = openFileDialog.ShowDialog()
        '    If result1 = System.Windows.Forms.DialogResult.OK Then
        '        ' Open a format document.
        '        Dim btFormat As LabelFormatDocument = btEngine.Documents.Open(openFileDialog.FileName)

        '        ' Export the print preview to an image file.
        '        Dim sPath As String = "E:\PrintPreview"
        '        If System.IO.Directory.Exists(sPath) = False Then
        '            Directory.CreateDirectory(sPath)
        '        End If
        '        Dim sFileName As String = "Preview%PageNumber%.jpg"
        '        Dim btMessages As Messages = Nothing
        '        btFormat.ExportPrintPreviewToFile(sPath, sFileName, ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth256, New Resolution(300), Color.Green, OverwriteOptions.DoNotOverwrite, True, True, btMessages)
        '        picPreview.Image = Image.FromFile(sPath & "\" & sFileName)
        '        ' Close the current format without saving.
        '        btFormat.Close(SaveOptions.DoNotSaveChanges)

        '        ' Stop the BarTender print engine.
        '        btEngine.Stop()
        '    End If
        'End Using
        'Return
        ''End Sub






        ' Let's disable some controls until we are done.
        btnOpen.Enabled = False
        'cboPrinters.Enabled = False
        'btnPreview.Enabled = False
        'Dim files() As String
        openFileDialog.Filter = "(*.btw)|*.btw"
        Dim result As DialogResult = openFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor

            ' Close the previous format.
            'If format IsNot Nothing Then
            '    format.Close(SaveOptions.DoNotSaveChanges)
            'End If

            ' We need to delete the files associated with the last format.
            'files = openFileDialog.SafeFileNames(0).ToString
            'For Each filename As String In files
            '    File.Delete(filename)
            'Next filename

            ' Put the UI back into a non-preview state.
            'Me.picPreview.Image = Nothing
            'DisablePreview()
            txtFilename.Text = openFileDialog.FileName
            ' Open the format.
            IsUpload = True
            Try
                'format = engine.Documents.Open(openFileDialog.FileName)
                FileNameStr = openFileDialog.SafeFileNames(0).ToString

            Catch comException As System.Runtime.InteropServices.COMException
                MessageBox.Show(Me, String.Format("Unable to open format: {0}" & Constants.vbLf & "Reason: {1}", openFileDialog.FileName, comException.Message), appName)
                'format = Nothing
            End Try

            ' Only allow preview button if we successfully loaded the format.
            'btnPreview.Enabled = (format IsNot Nothing)

            'If format IsNot Nothing Then
            '    ' Select the printer in use by the format.
            '    'cboPrinters.SelectedItem = format.PrintSetup.PrinterName
            '    'format.
            'End If
            btnOpen.Enabled = True
            'Cursor.Current = Cursors.Default
        End If
        ' Restore some controls.

        'cboPrinters.Enabled = True

        'format.PrintSetup.PrinterName = cboPrinters.SelectedItem.ToString()

        ' Set control states to show working. These will be reset when the work completes.
        'picUpdating.Visible = True

        ' Have the background worker export the BarTender format.
        'format.PageSetup.LabelHeight = 600
        'format.PageSetup.LabelWidth = 600

        'backgroundWorker.RunWorkerAsync(format)

    End Sub

    ' <summary>
    '    ''' Show the preview of the first label.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub btnFirst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFirst.Click
    '        currentPage = 1
    '        ShowPreview()
    '    End Sub

    '    ''' <summary>
    '    ''' Show the preview of the previous label.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrev.Click
    '        currentPage -= 1
    '        ShowPreview()
    '    End Sub

    '    ''' <summary>
    '    ''' Show the preview of the next label.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
    '        currentPage += 1
    '        ShowPreview()
    '    End Sub

    '    ''' <summary>
    '    ''' Show the preview of the last label.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub btnLast_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLast.Click
    '        currentPage = totalPages
    '        ShowPreview()
    '    End Sub

    '#Region "Print Preview Thread Methods"
    '    ''' <summary>
    '    ''' Runs in a separate thread to allow BarTender to export the preview while allowing UI updates.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub backgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker.DoWork

    '        If txtFilename.Text = "" Then Exit Sub
    '        Dim format As LabelFormatDocument = CType(e.Argument, LabelFormatDocument)
    '        'format.PageSetup.LabelColumns = 2
    '        'format.PageSetup.LabelRows = 1
    '        'Dim aa As String = format.SubStrings.Item(0).Value
    '        ' Delete any existing files.
    '        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
    '        For index As Integer = 0 To oldFiles.Length - 1
    '            File.Delete(oldFiles(index))
    '        Next index

    '        ' Export the format's print previews.
    '        'format.ExportPrintPreviewRangeToFil(1, previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, New Resolution(picPreview.Width, picPreview.Height), System.Drawing.Color.White, OverwriteOptions.Overwrite, True, True, messages)
    '        format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, New Resolution(picPreview.Width, picPreview.Height), System.Drawing.Color.White, OverwriteOptions.Overwrite, True, True, messages)
    '        Dim files() As String = Directory.GetFiles(previewPath, "*.*")
    '        totalPages = files.Length
    '    End Sub

    '    ''' <summary>
    '    ''' We are done exporting the preview, so let's show any messages
    '    ''' and display the first label.
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
    '        ' Report any messages.
    '        If messages.Count > 5 Then
    '            MessageBox.Show(Me, "There are more than 5 messages from the print preview. Only the first 5 will be displayed.", appName)
    '        End If
    '        'message.Text=
    '        Dim count As Integer = 0
    '        For Each message As Seagull.BarTender.Print.Message In messages
    '            'MessageBox.Show(Me, message.Text, appName)
    '            ' if (++count >= 5)
    '            count += 1
    '            If count >= 5 Then
    '                Exit For
    '            End If
    '        Next message

    '        picUpdating.Visible = False

    '        btnOpen.Enabled = True
    '        'btnPreview.Enabled = True
    '        'cboPrinters.Enabled = True

    '        ' Only enable the preview if we actual got some pages.
    '        If totalPages <> 0 Then
    '            lblNumPreviews.Visible = True
    '            IsUpload = True
    '            currentPage = 1
    '            ShowPreview()
    '        End If
    '    End Sub
    '#End Region

    '#Region "Methods"
    '    ''' <summary>
    '    ''' Disable/Hide preview controls.
    '    ''' </summary>
    '    Private Sub DisablePreview()
    '        picPreview.ImageLocation = ""
    '        picPreview.Visible = False
    '        picPreview.Width = 800
    '        picPreview.Height = 700
    '        btnPrev.Enabled = False
    '        btnFirst.Enabled = False
    '        lblNumPreviews.Visible = False
    '        btnNext.Enabled = False
    '        btnLast.Enabled = False
    '    End Sub

    '    ''' <summary>
    '    ''' Show the preview of the current page.
    '    ''' </summary>
    '    Private Sub ShowPreview()
    '        ' Our current preview number shouldn't be out of range,
    '        ' but we'll practice good programming by checking it.
    '        If (currentPage < 1) OrElse (currentPage > totalPages) Then
    '            currentPage = 1
    '        End If

    '        ' Update the page label and the preview Image.
    '        lblNumPreviews.Text = String.Format("Page {0} of {1}", currentPage, totalPages)
    '        Dim filename As String = String.Format("{0}\PrintPreview{1}.jpg", previewPath, currentPage)

    '        picPreview.ImageLocation = filename
    '        picPreview.Visible = True

    '        ' Enable or Disable controls as needed.
    '        If currentPage = 1 Then
    '            btnPrev.Enabled = False
    '            btnFirst.Enabled = False
    '        Else
    '            btnPrev.Enabled = True
    '            btnFirst.Enabled = True
    '        End If

    '        If currentPage = totalPages Then
    '            btnNext.Enabled = False
    '            btnLast.Enabled = False
    '        Else
    '            btnNext.Enabled = True
    '            btnLast.Enabled = True
    '        End If
    '    End Sub
    '#End Region

    '    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    '    Demo()

    '    'End Sub

    '    'Public Sub Demo()
    '    '    ' Initialize a new BarTender print engine.
    '    '    Using btEngine As New Engine()
    '    '        ' Start the BarTender print engine.
    '    '        btEngine.Start()

    '    '        ' Open a format document.
    '    '        '' this.format = this.engine.Documents.Open(btwPath);

    '    '        Dim btFormat As LabelFormatDocument = btEngine.Documents.Open("E:\Documents\BarTender\Formats\oxf\aa.btw")

    '    '        ' Display the number of substrings in the format.
    '    '        Console.WriteLine("SubStrings Count: " & btFormat.SubStrings.Count)

    '    '        ' Iterate through and read each SubString Name, Type and Value.
    '    '        For Each substring As SubString In btFormat.SubStrings
    '    '            Console.WriteLine("SubString Name: " & substring.Name & ", SubString Type: " & substring.Type & ", SubString Value: " & substring.Value)
    '    '        Next substring

    '    '        ' Set a SubString Value using its index.
    '    '        btFormat.SubStrings(0).Value = "New SubString Value"

    '    '        ' Set a SubString Value using its name (case sensitive).
    '    '        btFormat.SubStrings("SubString1").Value = "New SubString Value"

    '    '        ' Close the current format without saving.
    '    '        btFormat.Close(SaveOptions.DoNotSaveChanges)

    '    '        ' Stop the BarTender print engine.
    '    '        btEngine.Stop()
    '    '    End Using
    '    'End Sub


    Private Sub TxtSplitQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSplitQty.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub ChkIsSame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIsSame.CheckedChanged

        If ChkIsSame.Checked Then
            TxtSplitStr.Enabled = True
            TxtSplitStr.Focus()
        Else
            TxtSplitStr.Enabled = False
        End If

    End Sub

    Private Sub ChkSnIsSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSnIsSplit.CheckedChanged

        If ChkSnIsSplit.Checked Then
            TxtSplitQty.Enabled = True
            TxtSplitQty.Focus()
        Else
            TxtSplitQty.Enabled = False
        End If

    End Sub

#Region "自动生成barcodelabel"

    Private Sub ButGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButGen.Click



    End Sub

#End Region


    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim app As New Microsoft.Office.Interop.Outlook.Application()
    '    Dim ns As Microsoft.Office.Interop.Outlook.NameSpace = app.GetNamespace("mapi")
    '    ns.Logon("L031976", "feng1981)", False, True)
    '    Dim message As Microsoft.Office.Interop.Outlook.MailItem = DirectCast(app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem), Microsoft.Office.Interop.Outlook.MailItem)
    '    message.To = "luke.chen@luxshare-ict.com;harvey.yuan@luxshare-ict.com;jack.gao@luxshare-ict.com;Xiangfeng.Ou@luxshare-ict.com"
    '    message.Subject = "A simple test message"
    '    message.Body = "This is a test......."
    '    message.Send()
    '    ns.Logoff()
    '    'Console.Read()
    'End Sub
End Class

