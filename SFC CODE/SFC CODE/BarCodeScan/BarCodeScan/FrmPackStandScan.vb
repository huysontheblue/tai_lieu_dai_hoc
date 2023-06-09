''程式功能:線上掃描檢測及打印外箱條碼
''程式開發人員時間:2009/08/05 

#Region "Imports area"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint

#End Region

Public Class FrmPackStandScan

#Region "窗體變量"

    Dim Conn As New SysDataBaseClass
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim PackTestPrint As String = ""    '測試打印的箱號
    Dim Rprintstr As String = ""        '替換打印的舊箱號 
    Dim EndPrint As Boolean             '尾數打印
    Dim PackArrayReplace As New SysMessageClass.PrtStructure

#End Region

#Region "窗體事件"

  

    Private Sub FrmScanHandle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        DisposeWorkData()
        Dispose()

    End Sub

    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'SetGridHeadColumn()
        'LblPackQty.Text = ""    '清空箱應包裝數量
        'LblPackPage.Text = ""   '清空箱號
        'LblTime.Text = "" '
        'TxtMoId.Text = ""
        'TxtPartid.Text = ""
        LabResult.Text = "PASS"
        'TxtLineId.Text = ""
        'TxtSitName.Text = ""
        lblMessage.Text = "掃描資料已設置......"
        TxtBarCode.Focus()
        ToolUsename.Text = "欧翔峰"

    End Sub
#End Region

#Region "生成單頭列、加載查詢數據"
    'Private Sub SetGridHeadColumn()

    '    'Me.dgDataShow.Columns.Clear()
    '    'Dim i As Byte
    '    'For i = 0 To 4
    '    '    Dim col As New DataGridViewRolloverCellColumn()
    '    '    dgDataShow.Columns.Add(col)
    '    'Next

    '    'dgDataShow.Rows.Add("条码序号", "包装箱号", "工单编号", "扫描人员", "扫描时间")
    '    ''dgDataShow.Rows.Add("LBF000709232W000002", "WO12B00A38600009A", "WO12B00A386", "sz17690--欧翔峰", "2012-08-09 10:12:35")
    '    ''dgDataShow.Rows.Add("LBF000709232W000005", "WO12B00A38600009A", "WO12B00A386", "sz17690--欧翔峰", "2012-08-09 10:12:35")
    '    'dgDataShow.Rows(0).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFF0F2")
    '    'dgDataShow.Rows(0).DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000")
    '    ''For i = 0 To 9
    '    ''    DgPartSet.Columns(i).ReadOnly = True
    '    ''Next
    '    'dgDataShow.Rows(0).ReadOnly = True
    '    'DgPartSet.AutoResizeColumns()
    '    'DgPartSet.AutoResizeRows()
    '    ''Me.DGBarCode.Columns(0).ReadOnly = True

    'End Sub

#End Region

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region


#Region "獲取掃描記錄"

    Private Sub GetScanItem(ByVal Cartonid As String) ''根據當前箱號load出箱裝的產品序號 Now.ToString(("yyyy-MM-dd HH:mm:ss")

        If Cartonid = "" Then Exit Sub
        Dim DtCtScan As SqlDataReader
        'Dim PackQty As Integer = 0
        dgDataShow.Rows.Clear()
        'SetGridHeadColumn()
        DtCtScan = Conn.GetDataReader("select a.ppid,a.Cartonid,b.username,a.intime from m_CartonSn_t a join m_users_t b on a.userid=b.userid where cartonid='" & Cartonid & "'  order by a.intime desc ")
        While DtCtScan.Read()
            dgDataShow.Rows.Add(DtCtScan("ppid"), DtCtScan("Cartonid"), Me.TxtMoId.Text, DtCtScan("username"), DtCtScan("intime").ToString)
            'PackQty = PackQty + 1
        End While
        dgDataShow.AutoResizeColumns()
        'Me.LblCurrQty.Text = PackQty.ToString
        Me.LblCurrQty.Text = dgDataShow.Rows.Count
        DtCtScan.Close()

    End Sub

#End Region

    'Private Sub GenPackNumber(ByVal PackFlag As Char) ''為生成箱號或打印提供相關參數

    '    Dim ServerDate As New DateTime ''''服務器日期時間
    '    Dim PackBarCode As New PrintJLabelNew
    '    Dim TimeSqlstr As String = ""

    '    PackArray.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
    '    PackArray.CusName = CartonScanOption.CustStr ''Me.TxtCustoner.Text.Trim '客戶名稱
    '    PackArray.Deptid = CartonScanOption.DpetId.Trim '部門
    '    PackArray.Lineid = Me.TxtLineId.Text.Trim  '線別
    '    PackArray.Moid = Me.TxtMoId.Text.Trim   '工單
    '    TimeSqlstr = "select getdate() as nowtime"
    '    Dim RecTable As SqlDataReader = Conn.GetDataReader(TimeSqlstr)
    '    While (RecTable.Read)
    '        ServerDate = CDate(RecTable("nowtime").ToString)
    '    End While
    '    PackArray.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
    '    PackArray.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
    '    RecTable.Close()
    '    RecTable.Dispose()
    '    'If PackFlag = "4" Then ''尾數打印
    '    '    PackArray.Qty = CartonScanOption.LastPrintQty ''外箱實際箱裝數量
    '    'Else
    '    '    If EndPrint = False Then
    '    'If CartonScanOption.LastPrintQty Is Nothing Then
    '    If CartonScanOption.LastPrintCheck = True AndAlso PackFlag = "1" AndAlso CartonScanOption.vNoFullFlag = False AndAlso CartonScanOption.vIsPalletStyle = False Then
    '        PackArray.Qty = CartonScanOption.vLastPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '    ElseIf CartonScanOption.vLastPalletCheck = False AndAlso PackFlag = "1" AndAlso CartonScanOption.vNoFullFlag = False AndAlso CartonScanOption.vIsPalletStyle = False Then
    '        If CartonScanOption.vCurrentPalletCartonIndex = 0 Then CartonScanOption.vCurrentPalletCartonIndex = 1
    '        PackArray.Qty = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '    ElseIf CartonScanOption.vIsPalletStyle Then
    '        If CartonScanOption.vCurrentPalletCartonIndex = 0 Then CartonScanOption.vCurrentPalletCartonIndex = 1
    '        PackArray.Qty = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '    Else
    '        If CartonScanOption.vCurrentPalletCartonIndex = 1 Then CartonScanOption.vCurrentPalletCartonIndex = 1
    '        PackArray.Qty = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '    End If
    '    ''PackArray.Qty = 10 ''CartonScanOption.PartPackQty
    '    ''Else
    '    'PackArray.Qty = CartonScanOption.LastPrintQty
    '    'End If
    '    '    End If
    '    'End If
    '    If PackFlag = "1" Then  '正常掃描打印
    '        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y") Then
    '            If CartonScanOption.LastPrintCheck = True AndAlso LblPalletNo.Text = "" AndAlso CartonScanOption.vIsPalletStyle = False Then
    '                CartonScanOption.vPalletNo = GeneratePalletNo()
    '                '' CartonScanOption.vCurrentPalletCartonCount = LblPackQty.Text ''CartonScanOption.vNormalPalletCartonCount
    '                PackArray.Qty = CartonScanOption.vLastPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '                CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vLastPalletMultQty)
    '            ElseIf CartonScanOption.vLastPalletCheck = False AndAlso LblPalletNo.Text = "" AndAlso CartonScanOption.vIsPalletStyle = False Then
    '                CartonScanOption.vPalletNo = GeneratePalletNo()
    '                '' CartonScanOption.vCurrentPalletCartonCount = LblPackQty.Text ''CartonScanOption.vNormalPalletCartonCount
    '                '' CartonScanOption.vCurrentPalletCartonIndex = 1
    '                PackArray.Qty = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '                CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vNormalPalletMultQty)
    '            ElseIf CartonScanOption.vLastPalletCheck = True AndAlso LblPalletNo.Text = "" AndAlso CartonScanOption.vIsPalletStyle = False Then
    '                CartonScanOption.vPalletNo = GeneratePalletNo()
    '                '' CartonScanOption.vCurrentPalletCartonCount = LblPackQty.Text
    '                '' CartonScanOption.vCurrentPalletCartonIndex = 1
    '                PackArray.Qty = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '                CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vPalletMultQty)
    '            ElseIf CartonScanOption.vIsPalletStyle AndAlso LblPalletNo.Text = "" Then
    '                CartonScanOption.vPalletNo = GeneratePalletNo()
    '                '' CartonScanOption.vCurrentPalletCartonCount = LblPackQty.Text
    '                PackArray.Qty = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    '                CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vNormalPalletMultQty)
    '            End If
    '            CartonScanOption.PackNumber = PackBarCode.JLabelStr ''生成箱號
    '        End If
    '    ElseIf PackFlag = "2" Then  '替換打印
    '        ''If LblPalletNo.Text = "" Then
    '        ''    CartonScanOption.vPalletNo = GeneratePalletNo()
    '        ''End If
    '        'PackArray.Qty = CartonScanOption.vReplaceQty
    '        'If PackBarCode.MarkJLabel(PackArray.ToArray, "Y") Then
    '        '    PackPageStr = PackBarCode.JLabelStr ''生成箱號
    '        'End If
    '    ElseIf PackFlag = "3" Then ''測試打印
    '        If PackArray.Qty = Nothing Then PackArray.Qty = "0"
    '        If PackBarCode.MarkJLabel(PackArray.ToArray, "N") Then
    '            PackTestPrint = PackBarCode.JLabelStr ''生成箱號
    '        End If
    '    ElseIf PackFlag = "4" Then ''尾數打印
    '        If LblPalletNo.Text = "" Then CartonScanOption.vPalletNo = GeneratePalletNo()
    '        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y") Then
    '            CartonScanOption.PackNumber = PackBarCode.JLabelStr ''生成箱號
    '        End If
    '    End If

    'End Sub

    ''''''''打描操作
    Private Sub TxtBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarCode.KeyPress

        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(32) Then
            e.Handled = True
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            ExecuteScan() ''調用掃描處理程序
        Else
            e.Handled = False
        End If

    End Sub

#Region "生成棧板編號"

    Private Function GeneratePalletNo() ''生成棧板編號，工單+線別+流水號(4位)

        If TxtLineId.Text.Trim = "" Then
            MessageBox.Show("沒有選擇線別資料或線別資料異常丟失,不能生成棧板號")
            GeneratePalletNo = ""
            Exit Function
        End If
        Dim palletNoStr As String = String.Empty
        Dim cnn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim palletReader As SqlDataReader = cnn.GetDataReader("select isnull(max(Palletid),'') maxpallno from m_PalletM_t where Moid='" & TxtMoId.Text.Trim & "' and Teamid='" & TxtLineId.Text.Trim & "'")
        If palletReader.HasRows Then
            While palletReader.Read
                If palletReader!maxpallno = "" Then
                    palletNoStr = TxtMoId.Text.Trim + TxtLineId.Text.Trim + "0001"
                Else
                    palletNoStr = Replace(palletReader!maxpallno, TxtMoId.Text.Trim & TxtLineId.Text.Trim, "1")
                    palletNoStr = TxtMoId.Text.Trim & TxtLineId.Text.Trim & (palletNoStr + 1).ToString.Substring(1)
                End If
            End While
        End If
        palletReader.Close()
        Return palletNoStr

    End Function

#End Region


#Region "條碼掃描處理程序"

    Private Sub ExecuteScan()

        Dim RecDr As SqlDataReader = Nothing
        Dim Sqlstr As String
        Dim Flag As Char = "0"

        If InStr(TxtBarCode.Text, "'") > 0 Then
            Exit Sub
        End If

        Dim DecideFlag As Char

        '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*
        If Me.TxtMoId.Text.Trim = "" Then
            MessageBox.Show("請先設置好掃描基本信息！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Clear()
            TxtBarCode.Focus()
            Exit Sub
        End If
        If Not PackArray.AvcPartid Is Nothing Then
            If Me.TxtMoId.Text.Trim <> PackArray.Moid Then
                MessageBox.Show("資料設置或程序有誤" & vbNewLine & "請關閉當前窗體重新設置！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBarCode.Clear()
                TxtBarCode.Focus()
                Exit Sub
            End If
        End If
        If Trim(TxtBarCode.Text) = "" Then
            MessageBox.Show("條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Clear()
            TxtBarCode.Focus()
            Exit Sub ''
        End If
        If Len(Trim(TxtBarCode.Text)) <> Len(Trim(TxtSnStyle2.Text)) Then
            CartonScanOption.ErrorStr = "條碼長度有誤!"
            CartonScanOption.BarCodeStr = Trim(TxtBarCode.Text)
            Conn.ExecSql("insert m_AssysnE_t (ppid,moid,stationid,teamid,spoint,errordest,userid,intime) values ('" & Trim(TxtBarCode.Text) & "','" & Trim(Me.TxtMoId.Text) & "','AA','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','L條碼長度有誤','" & SysMessageClass.UseId & "',getdate())")
            Dim FrmError As New FrmCartonPrompt
            FrmError.ShowDialog()
            TxtBarCode.Clear()
            TxtBarCode.Focus()
            Exit Sub
        End If
        DecideFlag = DecideIsCheckStyle() ''''判斷是否為重工工單打印條碼
        If (LblType.Text <> "0") Or (DecideFlag = "0" And LblType.Text = "0") Then '''' 重工記錄不更換外箱 不檢查標准樣式.
            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text.Trim, TxtBarCode.Text.Trim, TxtSnStyle2.Text.Trim) = False Then
                CartonScanOption.ErrorStr = "條碼不符合標準樣式!"
                CartonScanOption.BarCodeStr = Trim(TxtBarCode.Text)
                Conn.ExecSql("insert m_AssysnE_t (ppid,moid,stationid,teamid,spoint,errordest,userid,intime) values ('" & Trim(TxtBarCode.Text) & "','" & Trim(Me.TxtMoId.Text) & "','AA','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','R條碼不符合標準樣式','" & SysMessageClass.UseId & "',getdate())")
                Dim FrmError As New FrmCartonPrompt
                FrmError.ShowDialog()
                TxtBarCode.Clear()
                TxtBarCode.Focus()
                Exit Sub
            End If
        End If
        '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*
        Try
            'If Int(LblCurrQty.Text.Trim) = 0 Then
            '    Flag = "1"
            '    If CartonScanOption.PackNumber Is Nothing Or TxtCartonNo.Text = "" Then GenPackNumber("1")
            'Else
            '    If PackArray.AvcPartid Is Nothing Then GenPackNumber("0")
            'End If
            'If CartonScanOption.PackNumber = "" Then
            '    MessageBox.Show("箱號不能為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Exit Sub
            'End If
            If CartonScanOption.vPalletNo = "" Then
                MessageBox.Show("棧板編號不能為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            ''if LblPalletCartonCount.Text
            Dim rFlag As Integer
            Dim sFlag As String
            '' rFlag = InStr(CartonScanOption.vMultQtyStr, ",")
            rFlag = CartonScanOption.vMultQtyStr.Length
            sFlag = CartonScanOption.vMultQtyStr.Replace(",", "")
            If LblPalletCartonCount.Text <> (rFlag - sFlag.Length + 1).ToString Then
                LblPalletCartonCount.Text = rFlag - sFlag.Length + 1
            End If

            ''''''''''''''''''''''''''''''''' 2008/04/02  修改2008/04/21
            'If (LblType.Text = "") Or (DecideFlag = "0" And LblType.Text <> "") Then
            Sqlstr = "declare @msg varchar(1),@currqty int,@strmsgText nvarchar(100),@ScanMoQty int,@palletflag varchar(1) execute m_CheckPPID_04P_NEW " & _
       "'" & Trim(TxtBarCode.Text) & "','" & Trim(Me.TxtMoId.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
       "'" & Trim(CartonScanOption.PackNumber) & "','" & Flag & "','" & CInt(LblPackQty.Text) & "','" & CartonScanOption.vPalletNo & "','" & LblPalletCartonCount.Text & "'," & _
       "'" & CartonScanOption.vMultQtyStr & "','" & CartonScanOption.vCurrentPalletCartonIndex & "','" & CartonScanOption.vCartonSitNo & "','" & CartonScanOption.vStandIndex & "'," & _
      "@msg output,@currqty output,@strmsgText output,@ScanMoQty output,@palletflag output select " & _
       "@msg,isnull(@currqty,1),@strmsgText,@ScanMoQty,@palletflag"
            '       Else ''''重工工單條碼掃描
            '       Sqlstr = "declare @msg varchar(1),@currqty int,@strmsgText nvarchar(100),@ScanMoQty int,@palletflag varchar(1) execute m_CheckPPID_03P_NEW " & _
            ' "'" & Trim(TxtBarCode.Text) & "','" & Trim(Me.TxtMoId.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
            ' "'" & Trim(CartonScanOption.PackNumber) & "','" & Flag & "','" & CInt(LblPackQty.Text) & "','" & CartonScanOption.vPalletNo & "','" & LblPalletCartonCount.Text & "'," & _
            ' "'" & CartonScanOption.vMultQtyStr & "','" & CartonScanOption.vCurrentPalletCartonIndex & "','" & CartonScanOption.vCartonSitNo & "','" & CartonScanOption.vStandIndex & "','" & TxtPartid.Text & "'," & _
            '"@msg output,@currqty output,@strmsgText output,@ScanMoQty output,@palletflag output select " & _
            ' "@msg,isnull(@currqty,1),@strmsgText,@ScanMoQty,@palletflag"
            '       End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''


            '' Sqlstr = "declare @msg varchar(1),@currqty int,@strmsgText nvarchar(100),@ScanMoQty int,@palletflag varchar(1) execute m_CheckPPID_04P_NEW " & _
            '' "'" & Trim(TxtBarCode.Text) & "','" & Trim(Me.TxtMoId.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
            '' "'" & Trim(CartonScanOption.PackNumber) & "','" & Flag & "','" & CInt(LblPackQty.Text) & "','" & CartonScanOption.vPalletNo & "','" & LblPalletCartonCount.Text & "'," & _
            '' "'" & CartonScanOption.vMultQtyStr & "','" & CartonScanOption.vCurrentPalletCartonIndex & "','" & CartonScanOption.vCartonSitNo & "','" & CartonScanOption.vStandIndex & "'," & _
            ''"@msg output,@currqty output,@strmsgText output,@ScanMoQty output,@palletflag output select " & _
            '' "@msg,isnull(@currqty,1),@strmsgText,@ScanMoQty,@palletflag"
            RecDr = Conn.GetDataReader(Sqlstr) ''執行存儲過程校驗當然掃描的產品序號條碼是否正確.

            If RecDr.HasRows Then
                RecDr.Read()
                Select Case RecDr.GetString(0)
                    '**************************************************************
                    ''1、此條碼不屬於當前工單2、此條碼為打印重復或重復掃描條碼,並提示第一次掃描的時間
                    ''3、此條碼為測試條碼4、掃描成功且當前箱尚未裝滿5、當前箱已裝數量等於應裝數量
                    ''6、掃描成功,此箱已經掃滿7、碼掃描數量不能超過工單生產數量
                    ''8、工單剩余掃描數量不足以裝滿一整箱,請設置尾數掃描與打印 
                    '**************************************************************
                    Case "0" To "3", "5", "7", "8", "9"
                        CartonScanOption.ErrorStr = RecDr(2).ToString '' --此條碼不存在
                        Exit Select
                    Case "4" ''--掃描成功 箱尚未裝滿
                        Me.LblCurrQty.Text = RecDr.GetInt32(1).ToString() ''當前箱已裝的數量
                        LblMoQty.Text = RecDr.GetInt32(3).ToString() ''當前工單已掃描過的條碼數量
                        RecDr.Close()
                        TxtCartonNo.Text = CartonScanOption.PackNumber
                        LblPalletNo.Text = CartonScanOption.vPalletNo
                        LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
                        dgDataShow.Rows.Insert(0, TxtBarCode.Text.Trim, TxtCartonNo.Text, Me.TxtMoId.Text, SysMessageClass.UseName, Now.ToString(("yyyy-MM-dd HH:mm:ss")))
                        dgDataShow.AutoResizeColumns()
                        dgDataShow.ClearSelection()
                        dgDataShow.Rows(0).Cells(0).Selected = True
                        LabResult.Text = TxtBarCode.Text.Trim & Space(3) & "掃描成功"
                        lblMessage.Text = "PASS"
                        lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
                        TxtBarCode.Clear()
                        Exit Sub
                    Case "6"
                        LblMoQty.Text = RecDr.GetInt32(3).ToString() ''當前工單已掃描過的條碼數量
                        If RecDr(4).ToString = "0" Then '''''
                            LblPalletNo.Text = CartonScanOption.vPalletNo
                            CartonScanOption.vCurrentPalletCartonIndex = CartonScanOption.vCurrentPalletCartonIndex + 1
                            If CartonScanOption.vIsLastPallet Or CartonScanOption.vNoFullFlag Or CartonScanOption.vLastPalletCheck Then
                                '' CartonScanOption.vCurrentPalletCartonCount = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1).ToString
                                LblPackQty.Text = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1).ToString
                            ElseIf CartonScanOption.LastPrintCheck Then
                                LblPackQty.Text = CartonScanOption.vLastPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1).ToString
                            Else
                                LblPackQty.Text = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
                            End If
                            LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
                            'LblPackQty.Text = CartonScanOption.vCurrentPalletCartonCount
                            'CartonScanOption.LastPrintCheck = False
                        Else
                            LblPalletNo.Text = ""
                            CartonScanOption.vCurrentPalletCartonIndex = 1
                            CartonScanOption.PartPackQty = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
                            ''CartonScanOption.vCurrentPalletCartonCount = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
                            LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
                            LblPalletCartonCount.Text = CartonScanOption.vNormalPalletCartonCount
                            LblPackQty.Text = CartonScanOption.vNormalPalletMultQty(0)

                            CartonScanOption.LastPrintCheck = False
                            CartonScanOption.vIsLastPallet = False
                            If CartonScanOption.vLastPalletCheck Then
                                CartonScanOption.vLastPalletCheck = False
                            End If
                            If CartonScanOption.vNoFullFlag Then
                                CartonScanOption.vNoFullFlag = False
                            End If
                            CartonScanOption.vPalletNo = Nothing
                        End If
                        RecDr.Close()
                        'If LblPalletNo.Text = "" Then
                        '    ''LoadPalletPaceQty()
                        '    LoadPalletCurrQty()
                        'End If
                        Dim RecordPackNo As String = "" ''定義變量以保存需打印的外箱編號
                        Dim BarCodePrint As New PrintJLabelNew ''實例化調用打印過程的類
                        LblCurrQty.Text = "0"               ''初始當前該箱已裝數量為0
                        CartonScanOption.LastPrintQty = Nothing
                        TxtCartonNo.Text = ""
                        dgDataShow.Rows.Clear()
                        'SetGridHeadColumn()
                        ''  LblPalletCartonCount.Text = (CInt(LblPalletCartonCount.Text) + 1).ToString

                        '' LblPackQty.Text = CInt(CartonScanOption.PartPackQty)
                        EndPrint = False

                        RecordPackNo = CartonScanOption.PackNumber
                        CartonScanOption.PackNumber = Nothing
                        BarCodePrint.PrintCarton(PackArray.ToArray, RecordPackNo, "Y")
                        BarCodePrint = Nothing
                        LabResult.Text = TxtBarCode.Text.Trim & Space(3) & "掃描成功"
                        lblMessage.Text = "PASS"
                        lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
                        TxtBarCode.Clear()
                        Exit Sub
                End Select
                RecDr.Close()
                CartonScanOption.BarCodeStr = TxtBarCode.Text.Trim
                If Me.LblCurrQty.Text = "0" Then
                    dgDataShow.Rows.Clear()
                    'SetGridHeadColumn()
                End If

                ''LabResult.Text = ""
                LabResult.Text = TxtBarCode.Text.Trim & Space(3) & "掃描失敗"
                lblMessage.Text = "NG"
                Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
                ''System.Windows.Forms.Application.EnableVisualStyles()
                Dim FrmError As New FrmCartonPrompt
                FrmError.ShowDialog()
                TxtBarCode.Clear()
                TxtBarCode.Focus()
            End If
        Catch ex As Exception
            '' Me.LblCurrQty.Text = "0"
            '' Me.TxtCartonNo.Text = ""
            '' Me.LblPalletNo.Text = ""
            RecDr.Close()
            '' Me.Close()
            SysMessageClass.WriteErrLog(ex, Me.Name, "BtEnter_Click", "sys")
            Exit Sub
        End Try

    End Sub

#End Region

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        DisposeWorkData() ''關閉時釋放變量
        PackArray = Nothing
        Conn = Nothing
        Me.Close()

    End Sub

    ''#Region "尾數打印設置"
    ''    Private Sub ToolLastCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLastCarton.Click

    ''        Dim BarCodePrint As New PrintJLabelNew
    ''        If Me.TxtMoId.Text = "" Then
    ''            MsgBox("請先設置打印資料！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    ''            Exit Sub
    ''        End If

    ''        If TxtCartonNo.Text = "" And LblCurrQty.Text <> "0" Then
    ''            MsgBox("當前箱未掃描完,不允許尾數設置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    ''            Exit Sub
    ''        End If

    ''        If Me.TxtCartonNo.Text <> "" And Me.LblCurrQty.Text <> "0" Then
    ''            MsgBox("正在掃描中,不允許尾數打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    ''            Exit Sub
    ''        End If
    ''        'If Me.LblCurrQty.Text <> "0" Then
    ''        '    MsgBox("當前掃描數量不為零時,不允許尾數設置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    ''        '    Exit Sub
    ''        'End If


    ''        ''   If MsgBox("是否進行尾箱掃描打印設置？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.Yes Then
    ''        Try
    ''            ''CartonScanOption.LastPrintCheck = True
    ''            ''CartonScanOption.LastPrintQty = CartonScanOption.PartPackQty.ToString
    ''            Dim FrmLastLock As New FrmCartonLastSet
    ''            FrmLastLock.ShowDialog()
    ''            If CartonScanOption.LastPrintCheck = False Then
    ''                EndPrint = False
    ''                Exit Sub
    ''            End If
    ''            EndPrint = True
    ''            LblPackQty.Text = CInt(CartonScanOption.LastPrintQty)
    ''            '' GenPackNumber("4")
    ''            'LblCurrQty.Text = "0"
    ''            'Me.TxtCartonNo.Text = ""
    ''            'LblPackQty.Text = CInt(CartonScanOption.LastPrintQty)
    ''        Catch ex As Exception
    ''            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ''            Exit Sub
    ''        End Try
    ''        '' End If

    ''    End Sub
    ''#End Region

    Private Sub ToolRprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReplacePrint.Click

        Dim SqlItemStr As New StringBuilder
        Dim BarCodePrint As New PrintJLabelNew
        If TxtMoId.Text = "" Then
            MsgBox("你還未設置掃描資料,不能進行替換打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        If Me.TxtCartonNo.Text <> "" And Me.LblCurrQty.Text <> "0" Then
            MsgBox("正在掃描中或存在未掃滿箱,不允許替換打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        If MsgBox("是否進行箱號替換打印？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.Yes Then
            Try
                ''System.Windows.Forms.Application.EnableVisualStyles()
                'Dim FrmReplaceForm As New FrmCartonReplace
                Dim FrmReplaceForm As New FrmCartonReplace(TxtPartid.Text)
                CartonScanOption.ReplacePrintCheck = True
                CartonScanOption.vReplaceMo = Me.TxtMoId.Text.Trim
                FrmReplaceForm.ShowDialog()
                If CartonScanOption.ReplacePrintCheck = False Then Exit Sub
                Rprintstr = FrmReplaceForm.TxtPackNo.Text.Trim
                '' GenPackNumber("2") ''新生成新外箱編號
                Dim PackPageStr As String = RepalceCartonPrint()
                If PackPageStr = "" Then
                    Me.lblMessage.Text = "替換外箱失敗,生成箱號出錯！"
                    Exit Sub
                End If
                SqlItemStr.Append("update M_Carton_t set CartonStatus='E' where cartonid='" & Rprintstr & "'" & vbNewLine)
                SqlItemStr.Append("update m_cartonsn_t set cartonid='" & PackPageStr & "' where cartonid='" & Rprintstr & "'" & vbNewLine)
                SqlItemStr.Append("insert into M_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & PackPageStr & "','" & Me.TxtMoId.Text.Trim & "','" & CInt(CartonScanOption.vReplaceQty) & "','Y','" & Me.TxtLineId.Text.Trim & "','" & SysMessageClass.UseId.ToLower & "',getdate())" & vbNewLine)
                SqlItemStr.Append("update m_SnSBarCode_t set  usey='N' where  Sbarcode='" & Rprintstr & "' and packid='C'" & vbNewLine)
                SqlItemStr.Append("update m_SnSBarCode_t set usey='S' where Sbarcode='" & PackPageStr & "'" & vbNewLine)
                SqlItemStr.Append("update m_WhInD_t  set cartonid='" & PackPageStr & "' where cartonid='" & Rprintstr & "'" & vbNewLine)
                SqlItemStr.Append("update m_WhOutD_t  set cartonid='" & PackPageStr & "' where cartonid='" & Rprintstr & "'" & vbNewLine)
                SqlItemStr.Append("update m_PalletCarton_t set Cartonid='" & PackPageStr & "' where Cartonid ='" & Rprintstr & "'" & vbNewLine)
                SqlItemStr.Append("update a set packlink=b.packlink from  M_Carton_t a ,(select packlink from M_Carton_t b where cartonid='" & Rprintstr & "') b where a.cartonid='" & PackPageStr & "'" & vbNewLine)
                SqlItemStr.Append("insert into m_BarcodeExch_t values('" & Rprintstr & "','" & PackPageStr & "','" & TxtMoId.Text & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
                Conn.ExecSql(SqlItemStr.ToString)
                ''  CartonScanOption.PackNumber = Nothing
                BarCodePrint.PrintCarton(PackArrayReplace.ToArray, PackPageStr, "Y")
                BarCodePrint = Nothing
                SqlItemStr = Nothing
            Catch ex As Exception
                'CartonScanOption.PackNumber = Nothing
                SqlItemStr = Nothing
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If

    End Sub

    Private Function RepalceCartonPrint() As String

        Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""

        RepalceCartonPrint = ""
        PackArrayReplace.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
        PackArrayReplace.CusName = CartonScanOption.CustStr ''Me.TxtCustoner.Text.Trim '客戶名稱
        PackArrayReplace.Deptid = CartonScanOption.DpetId.Trim '部門
        PackArrayReplace.Lineid = Me.TxtLineId.Text.Trim  '線別
        PackArrayReplace.Moid = Me.TxtMoId.Text.Trim   '工單
        TimeSqlstr = "select getdate() as nowtime"
        Dim RecTable As SqlDataReader = Conn.GetDataReader(TimeSqlstr)
        While (RecTable.Read)
            ServerDate = CDate(RecTable("nowtime").ToString)
        End While
        PackArrayReplace.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
        PackArrayReplace.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
        RecTable.Close()
        RecTable.Dispose()
        PackArrayReplace.Qty = CartonScanOption.vReplaceQty
        If PackBarCode.MarkJLabel(PackArrayReplace.ToArray, "Y") Then
            RepalceCartonPrint = PackBarCode.JLabelStr ''生成箱號
        End If
        ''  PackArrayReplace = Nothing
        ''  RepalceCartonPrint = Nothing

    End Function

    Private Sub ToolTestPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolTestPrint.Click
        ''測試打印
        Dim BarCodePrint As New PrintJLabelNew
        Dim PackArrayTest As New SysMessageClass.PrtStructure
        Try
            ''If Me.TxtMoId.Text = "" Then
            ''    MsgBox("你還未設置掃描資料,不能測試打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            ''    Exit Sub
            ''End If
            ''If Me.TxtCartonNo.Text <> "" And Me.LblCurrQty.Text <> "0" Then
            ''    MsgBox("正在掃描中,不允許測試打印打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            ''    Exit Sub
            ''End If
            ''GenPackNumber("3")

            Dim ServerDate As New DateTime ''''服務器日期時間
            Dim PackBarCode As New PrintJLabelNew
            Dim TimeSqlstr As String = ""
            ''MAD-990028
            PackArrayTest.AvcPartid = "103-006038-06A" 'AVC料號
            PackArrayTest.CusName = "Lenovo" ''Me.TxtCustoner.Text.Trim '客戶名稱
            PackArrayTest.Deptid = "DG130" '部門
            PackArrayTest.Lineid = "B" '線別
            PackArrayTest.Moid = "MAD-990028"   '工單

            PackArrayTest.NowDate = Now.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
            PackArrayTest.NowMonth = Now.AddHours(-7.5).ToString("MM").ToString ''服務器月份
            PackArrayTest.Qty = "10"

            If PackArrayTest.Qty = Nothing Then PackArrayTest.Qty = "0"
            If PackBarCode.MarkJLabel(PackArrayTest.ToArray, "N") Then
                PackTestPrint = PackBarCode.JLabelStr ''生成箱號
            End If

            ''CartonScanOption.PackNumber = Nothing
            BarCodePrint.PrintCarton(PackArrayTest.ToArray, PackTestPrint, "N")
            '' BarCodePrint = Nothing
            PackBarCode = Nothing
            PackArrayTest = Nothing
            Exit Sub
        Catch ex As Exception
           '' BarCodePrint = Nothing
            PackArrayTest = Nothing
            '' CartonScanOption.PackNumber = Nothing
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub ClearSetData()

        Me.TxtMoId.Text = ""
        Me.TxtPartid.Text = ""
        Me.TxtSitName.Text = ""
        Me.TxtLineId.Text = ""
        Me.TxtCartonNo.Text = ""
        Me.TxtSnStyle1.Text = ""
        Me.TxtSnStyle2.Text = ""
        Me.LabResult.Text = "'"
        Me.LblCurrentCartonIndex.Text = ""
        Me.LblCurrQty.Text = "0"
        Me.lblMessage.Text = "掃描資料未設置"
        Me.LblPackQty.Text = "0"
        Me.LblPalletCartonCount.Text = "0"
        Me.LblPalletNo.Text = ""
        Me.LblMoQty.Text = "0"

    End Sub
    Private Sub ToolScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolScanSet.Click

        ''If Me.TxtMoId.Text <> "" Then
        ''    MessageBox.Show("不能重新設置資料" & vbNewLine & "請關閉當前窗體再進行設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ''    Exit Sub
        ''End If
        ''System.Windows.Forms.Application.EnableVisualStyles()
        Dim FrmScanLock As New FrmSetLock
        FrmScanLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then
            'If (MessageBox.Show("你確定要更換當前的資料設置？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) AndAlso Me.TxtMoId.Text <> "" Then
            '    DisposeWorkData()
            '    ClearSetData()
            'Else
            '    Exit Sub
            'End If

            Dim Frm As New FrmPackCartonSet
            Frm.ShowDialog()               ''show出設置窗體設定相關的參數
            If CartonScanOption.IsExitFlag = True Then Exit Sub
            Me.LblPalletNo.Text = ""

            TxtCartonNo.Text = ""
            Me.LblPalletNo.Text = ""
            Me.LblPackQty.Text = "0"
            LblCurrQty.Text = "0"
            LblPackQty.Text = "0"
            Me.dgDataShow.Rows.Clear()
            'SetGridHeadColumn()
            LoadWorkDataInControl() ''初始化控件值
            lblMessage.Text = "掃描資料已設置"
            'LoadPalletPaceQty()
            ''  LoadMoPaceQty()
            ''TxtSitName.Text = CartonScanOption.
        End If
        CartonScanOption.CheckStr = False


    End Sub


    ''Private Sub LoadMoPaceQty()

    ''    Dim PalletStr As String = String.Empty
    ''    Dim read As SqlDataReader = Conn.GetDataReader("select isnull(sum(cartonqty),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' and cartonstatus<>'E' ")
    ''    If read.HasRows Then
    ''        While read.Read
    ''            LblMoQty.Text = read!packcount.ToString
    ''        End While
    ''    End If

    ''    read.Close()

    ''End Sub

    'Private Sub LoadPalletPaceQty()

    '    Dim PalletStr As String = String.Empty
    '    Dim read As SqlDataReader = Conn.GetDataReader("select COUNT(MultiBox) palletCout,MultiQty from dbo.m_PalletM_t where Moid='" & Me.TxtMoId.Text & "' and teamid='" & Me.TxtLineId.Text & "' group by MultiQty" & vbNewLine & " select isnull(sum(cartonqty),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' and cartonstatus<>'E' ")
    '    If read.HasRows Then
    '        While read.Read
    '            PalletStr = PalletStr & read!MultiQty + "棧板方式已裝數量為:" & read!palletCout & Space(3)
    '        End While
    '        read.NextResult()
    '        While read.Read
    '            LblMoQty.Text = read!packcount.ToString
    '        End While
    '    End If
    '    TxtPalletCout.Text = PalletStr
    '    read.Close()

    'End Sub

    'Private Sub LoadPalletCurrQty()

    '    Dim PalletStr As String = String.Empty
    '    Dim read As SqlDataReader = Conn.GetDataReader("select COUNT(MultiBox) palletCout,MultiQty from dbo.m_PalletM_t where Moid='" & Me.TxtMoId.Text & "' and teamid='" & Me.TxtLineId.Text & "' group by MultiQty")
    '    If read.HasRows Then
    '        While read.Read
    '            PalletStr = PalletStr & read!MultiQty + "棧板方式已裝數量為:" & read!palletCout & Space(3)
    '        End While
    '    End If
    '    TxtPalletCout.Text = PalletStr
    '    read.Close()

    'End Sub

    Private Sub LoadWorkDataInControl() ''初始化控件值

        If CartonScanOption.TimeStr Is Nothing Then Exit Sub
        Dim CountTime As DateTime
        ''Dim ScanReader As SqlWorkDataReader

        Me.TxtMoId.Text = CartonScanOption.MoidStr           ''工單
        Me.LblMoProduceQty.Text = CartonScanOption.MoidqtyStr    ''工單數量
        ''Me.TxtCustoner.Text = CartonScanOption.CustStr ''工單類型
        Me.TxtPartid.Text = CartonScanOption.PartidStr ''料件編號
        ''  LabMoCust.Text = CartonScanOption.MoCustStr ''客戶料號
        Me.TxtLineId.Text = CartonScanOption.LineStr ''線別
        TxtSnStyle1.Text = CartonScanOption.SnStyleStr1 ''樣式一
        TxtSnStyle2.Text = CartonScanOption.SnStyleStr2 ''樣式二
        LblType.Text = CartonScanOption.moType
        LblPalletNo.Text = CartonScanOption.vPalletNo
        LblCurrentCartonIndex.Text = IIf(LblPalletNo.Text = "", 1, CartonScanOption.vCurrentPalletCartonIndex)
        CartonScanOption.vCurrentPalletCartonIndex = IIf(LblPalletNo.Text = "", 1, CartonScanOption.vCurrentPalletCartonIndex)
        LblPalletCartonCount.Text = IIf(LblPalletNo.Text = "", CartonScanOption.vNormalPalletCartonCount, CartonScanOption.vCurrentPalletCartonCount)

        If CartonScanOption.vPalletMultQty Is Nothing Then
            LblPackQty.Text = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
        Else
            LblPackQty.Text = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
        End If
        TxtCartonNo.Text = IIf(LblPalletNo.Text = "", "", CartonScanOption.PackNumber)

        Me.TxtSitName.Text = CartonScanOption.vCartonSitName
        Me.TxtCartonNo.Text = CartonScanOption.PackNumber ''外箱編號
        CountTime = CartonScanOption.TimeStr ''掃描開始時間
        '' LblTime.Text = CountTime.ToString("yyyy-MM-dd HH:mm:ss")  ''轉換掃描開始時間
        Me.TxtBarCode.MaxLength = TxtSnStyle1.Text.Length
        GetScanItem(Me.TxtCartonNo.Text.Trim) ''根據當前箱號load出箱裝的產品序號
        Me.TxtBarCode.Focus()  ''產品序號對應文本框獲得光標
        'ScanReader = Conn.GetWorkDataReader("select count(*) from m_Carton_t where moid='" & Me.TxtMoId.Text & "' and cartonstatus='Y' and teamid='" & Me.TxtLineId.Text & "' and intime > '" & Trim(LblTime.Text) & "'")
        'While ScanReader.Read()
        '    LblPackCount.Text = ScanReader.GetInt32(0).ToString
        'End While
        'ScanReader.Close()
        LabResult.Text = ""
        '' LblPackQty.Text = "0"

    End Sub

    Private Sub DisposeWorkData() ''釋放WorkData對象

        CartonScanOption.PackNumber = Nothing
        CartonScanOption.BarCodeStr = Nothing
        CartonScanOption.DpetNameStr = Nothing
        CartonScanOption.ErrorStr = Nothing
        CartonScanOption.LineStr = Nothing
        CartonScanOption.MoCustStr = Nothing
        CartonScanOption.MoidqtyStr = Nothing
        CartonScanOption.MoidStr = Nothing
        CartonScanOption.PartidStr = Nothing
        CartonScanOption.PartPackQty = Nothing
        CartonScanOption.SnidStr = Nothing
        CartonScanOption.SnStyleStr1 = Nothing
        CartonScanOption.SnStyleStr2 = Nothing
        CartonScanOption.TimeStr = Nothing
        CartonScanOption.CustStr = Nothing
        CartonScanOption.BcRuleid = Nothing
        CartonScanOption.LastPrintQty = Nothing
        CartonScanOption.vReplaceMo = Nothing
        CartonScanOption.vReplaceQty = Nothing
        CartonScanOption.IsExitFlag = Nothing
        CartonScanOption.ReplacePrintCheck = Nothing
        CartonScanOption.LastPrintCheck = Nothing
        CartonScanOption.vPalletNo = Nothing
        CartonScanOption.vLastPalletCheck = Nothing
        CartonScanOption.vCurrentPalletCartonIndex = Nothing
        CartonScanOption.vCurrentPalletCartonCount = Nothing
        CartonScanOption.vPalletMultQty = Nothing
        CartonScanOption.vNormalPalletCartonCount = Nothing
        CartonScanOption.vNormalPalletMultQty = Nothing
        CartonScanOption.vCartonSitNo = Nothing
        CartonScanOption.vStandIndex = Nothing
        CartonScanOption.vIsLastPallet = Nothing
        CartonScanOption.vMultQtyStr = Nothing
        CartonScanOption.vNoFullFlag = Nothing
        CartonScanOption.vLastPalletMultQty = Nothing
        CartonScanOption.vCartonSitName = Nothing
        CartonScanOption.TimeStr = Nothing
        CartonScanOption.moType = Nothing
        PackArray = Nothing

    End Sub


    Private Sub dgWorkDataShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgDataShow.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

    ''#Region "尾數棧板的設置"
    ''    Private Sub toolPalletSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPalletSet.Click

    ''        If Me.TxtMoId.Text = "" Then
    ''            MessageBox.Show("你還未設置掃描資料,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    ''            Exit Sub
    ''        End If

    ''        If Me.LblPalletNo.Text <> "" Then
    ''            MessageBox.Show("目前棧板未包裝完成,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    ''            Exit Sub
    ''        End If
    ''        Dim sqlreader As SqlDataReader
    ''        sqlreader = Conn.GetDataReader("select * from m_PartPack_t where Partid='" & CartonScanOption.PartidStr & "' and  packid = 'C' and multiy = 'Y'")
    ''        If sqlreader.HasRows = False Then
    ''            MessageBox.Show("該棧板為單箱棧板,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ''            sqlreader.Close()
    ''            Exit Sub
    ''        End If
    ''        sqlreader.Close()
    ''        sqlreader = Conn.GetDataReader("select * from m_PalletM_t where Moid='" & CartonScanOption.MoidStr & "' and  Teamid ='" & CartonScanOption.LineStr & "' and PalletStatus = 'N'")
    ''        If sqlreader.HasRows Then
    ''            MessageBox.Show("該工單在當前線別上存在未裝滿棧,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ''            sqlreader.Close()
    ''            Exit Sub
    ''        End If
    ''        sqlreader.Close()
    ''        Dim frm As New FrmLastPalletSet
    ''        CartonScanOption.ReplacePrintCheck = True
    ''        CartonScanOption.vReplaceMo = Me.TxtMoId.Text.Trim
    ''        frm.ShowDialog()
    ''        If CartonScanOption.vLastPalletCheck = False Then Exit Sub
    ''        '' LblPalletNo.Text = CartonScanOption.vPalletNo
    ''        LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
    ''        LblPalletCartonCount.Text = CartonScanOption.vCurrentPalletCartonCount
    ''        LblPackQty.Text = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    ''        ''TxtCartonNo.Text = CartonScanOption.PackNumber

    ''    End Sub
    ''#End Region

    Private Sub TxtSnStyle2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnStyle2.GotFocus, TxtSnStyle1.GotFocus

        TxtBarCode.Focus()

    End Sub


    Private Sub FrmPackStandScan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ToolScanSet_Click(sender, e)
            Case Keys.F2
                ToolTestPrint_Click(sender, e)
            Case Keys.F3
                ToolPalletCarton_Click(sender, e)
            Case Keys.Alt + Keys.L
                LastCartonSet_Click(sender, e)
            Case Keys.Alt + Keys.P
                toolLastPalletSet_Click(sender, e)
            Case Keys.F5
                ToolRprint_Click(sender, e)
            Case Keys.F6
                toolca_Click(sender, e)
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub

    Private Sub toolca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolca.Click

        Dim frm As New FrmPartition
        frm.ShowDialog()

    End Sub
#Region "尾數打印設置"

    Private Sub LastCartonSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastCartonSet.Click

        Dim BarCodePrint As New PrintJLabelNew
        If Me.TxtMoId.Text = "" Then
            MsgBox("請先設置打印資料！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        If TxtCartonNo.Text = "" And LblCurrQty.Text <> "0" Then
            MsgBox("當前箱未掃描完,不允許尾數設置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        If Me.TxtCartonNo.Text <> "" And Me.LblCurrQty.Text <> "0" Then
            MsgBox("正在掃描中,不允許尾數打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        Try
            ''System.Windows.Forms.Application.EnableVisualStyles()
            Dim FrmLastLock As New FrmCartonLastSet
            FrmLastLock.ShowDialog()
            If CartonScanOption.LastPrintCheck = False Then
                EndPrint = False
                Exit Sub
            End If
            EndPrint = True
            LblPackQty.Text = CInt(CartonScanOption.LastPrintQty)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        '' End If

    End Sub

#End Region

#Region "尾數棧板的設置"

    Private Sub toolLastPalletSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolLastPalletSet.Click

        If Me.TxtMoId.Text = "" Then
            MessageBox.Show("請先設置掃描資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        If Me.LblPalletNo.Text <> "" Then
            MessageBox.Show("目前棧板未包裝完成,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If LblPackQty.Text = "1" Then
            MessageBox.Show("目前應裝數量為1時，不能再設置當前箱的尾數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim sqlreader As SqlDataReader
        sqlreader = Conn.GetDataReader("select * from m_PartPack_t where Partid='" & CartonScanOption.PartidStr & "' and  packid = 'C' and multiy = 'Y'")
        If sqlreader.HasRows = False Then
            MessageBox.Show("該棧板為單箱棧板,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sqlreader.Close()
            Exit Sub
        End If
        sqlreader.Close()
        sqlreader = Conn.GetDataReader("select * from m_PalletM_t where Moid='" & CartonScanOption.MoidStr & "' and  Teamid ='" & CartonScanOption.LineStr & "' and PalletStatus = 'N'")
        If sqlreader.HasRows Then
            MessageBox.Show("該工單在當前線別上存在未裝滿棧,不能設置尾數棧板!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sqlreader.Close()
            Exit Sub
        End If
        sqlreader.Close()
        ''System.Windows.Forms.Application.EnableVisualStyles()
        Dim frm As New FrmLastPalletSet
        CartonScanOption.ReplacePrintCheck = True
        CartonScanOption.vReplaceMo = Me.TxtMoId.Text.Trim
        frm.ShowDialog()
        If CartonScanOption.vLastPalletCheck = False Then Exit Sub
        '' LblPalletNo.Text = CartonScanOption.vPalletNo
        LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
        LblPalletCartonCount.Text = CartonScanOption.vCurrentPalletCartonCount
        LblPackQty.Text = CartonScanOption.vPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
        ''TxtCartonNo.Text = CartonScanOption.PackNumber

    End Sub

#End Region

#Region "設置棧板裝箱方式"
    Private Sub ToolPalletCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPalletCarton.Click

        If Me.TxtMoId.Text = "" Then
            MessageBox.Show("請先設置掃描資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Me.LblPalletNo.Text <> "" Then
            MessageBox.Show("當前棧板還未裝滿,不能設置棧板裝箱方式!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        Dim sqlreader As SqlDataReader
        sqlreader = Conn.GetDataReader("select * from m_PartPack_t where Partid='" & CartonScanOption.PartidStr & "' and  packid = 'C' and multiy = 'Y'")
        If sqlreader.HasRows = False Then
            MessageBox.Show("該棧板為單箱棧板,不能設置棧板裝箱方式!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sqlreader.Close()
            Exit Sub
        End If
        sqlreader.Close()
        Dim frm As New FrmPalletSetStyleSet()
        frm.ShowDialog()
        If CartonScanOption.vIsPalletStyle = False Then Exit Sub
        LblCurrentCartonIndex.Text = CartonScanOption.vCurrentPalletCartonIndex
        LblPalletCartonCount.Text = CartonScanOption.vNormalPalletCartonCount
        LblPackQty.Text = CartonScanOption.vNormalPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1)
    End Sub
#End Region


    ''//2008/04/18   新增 對重工作業中發現不良條碼的處理
    Private Function DecideIsCheckStyle() As Char

        Dim DecideReader As SqlDataReader
        DecideReader = Conn.GetDataReader("select  * from m_SnSBarCode_t where moid='" & Me.TxtMoId.Text & "' and sbarcode='" & Me.TxtBarCode.Text & "'")
        If (DecideReader.HasRows) Then
            DecideIsCheckStyle = "0"
            DecideReader.Close()
            DecideReader.Dispose()
            Exit Function
        End If
        DecideReader.Close()
        DecideReader.Dispose()
        DecideIsCheckStyle = "1"

    End Function

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub


#Region "工单状态设置"

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click
        Try
            If (String.IsNullOrEmpty(Me.TxtMoId.Text.Trim)) Then
                MessageBox.Show("请设置工单！")
                Exit Sub
            End If

            Dim FrmMOStatusSetting As New FrmMOStatusSetting(Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim)
            FrmMOStatusSetting.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("打开工单状态设置异常！")
        End Try
    End Sub

#End Region


End Class