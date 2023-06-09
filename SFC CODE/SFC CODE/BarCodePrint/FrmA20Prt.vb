
'--打印作業程序
'--Create by :　Airlo(楊三良)
'--Create date :　2006/11/15
'--Ver : V01

'--Edit : 整理及優化
'--Time : 2007/4/16
'--by : Airlo(楊三良)

#Region "Imports"

Imports System.Windows.Forms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO

#End Region

Public Class FrmA20Prt

#Region "窗體變量"

    Public LoadM As New SqlClassM      '定義主資源對象
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
    Dim ObjAInfoTable As New DataTable      '定義對象信息表
    Dim CurrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim PrtStrTable As New DataTable      '打印命令字符串

    'Dim BarCodeStyle As New StringBuilder   '建立條碼樣式字符串
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串
    Dim PrintPart(,) As String    '建立打印字符串來源信息數組

    Dim BarCodePart(,) As String     '定義條碼組成部分的資源數組，用來記錄條碼各組成部分的各種值
    Dim BarCodePartNum As Int16    '數組變量

    Dim SBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim SBCodeLEN As Int16        '流水號的長度，也是數組的變量

    Dim CboList(,) As String    '存儲打印窗體中的下拉框中的内容
    Dim CboListNum As Int16      '數組變量

    'Public ObjArrayL As New ArrayList   '存儲打印窗體中的控件
    'Public ObjArrayNum As Int16     '數組變量

    Dim MoidAllNum As Int64 = 0        '工單批量
    Dim MoidPrinted As Int64 = 0      '工單已裝箱數量

    'Dim WithEvents FrmType As Form
    'Dim WithEvents ObjTypeCbo As ComboBox
    'Dim WithEvents ObjTypeTxt As TextBox
    'Dim WithEvents ObjTypeLbl As Label
    'Dim WithEvents ObjTypeBnEdit As Button
    'Dim WithEvents ObjTypeBnBeginPrint As Button
    'Dim WithEvents ObjTypeBnTestPrint As Button
    'Dim WithEvents ObjTypeBnQuit As Button

#End Region

    '#Region "重繪datagridview單元格,選中時去除焦點"

    '    Private Sub dgScanShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgCodeRule.RowPrePaint

    '        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    '    End Sub

    '#End Region


#Region "窗體登錄事件"

    Private Sub FrmBarM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim MoBarCode As New PrintJLabelNew
        'Dim PrtArray As New SysMessageClass.PrtStructure

        'PrtArray.AvcPartid = "105-006032-03A"
        'PrtArray.CusName = "Lenovo"
        'PrtArray.Deptid = "DG130"
        'PrtArray.Lineid = "F"
        'PrtArray.Moid = "MA309B0483"
        'PrtArray.NowDate = CDate("2009-11-05").ToString("yyyy-MM-dd")
        'PrtArray.NowMonth = CDate("2009-11-05").ToString("MM")
        'PrtArray.Qty = "10"

        ''MoBarCode.MarkJLabel(PrtArray.ToArray, "Y")
        'MoBarCode.PrintCarton(PrtArray.ToArray, "C001059BV95F006", "Y")
        'MoBarCode = Nothing

        'Me.BnBulidBarCode.Enabled = False
        'LoadM.SetSplitContainer(Me.SplitContainer2)
        'LoadM.SetSplitContainer(Me.SplitContainer3)
        'LoadM.SetSplitContainer(Me.SplitContainer4)

        '注册条码控件
        'Shell("C:\WINDOWS\system32\regsvr32.exe " & My.Application.Info.DirectoryPath & "\MSBCODE9.OCX   -s")
        'Try
        '    'LoadM.LoadDataToTSComboBox("select b.ttext from m_Logtree_t as b join m_SysapForm_t as a on a.ApFormid ='" & Me.Name & "' and b.Formid=a.Apid join m_UserRight_t as c on c.UserID='" & SysMessageClass.UseId & "' and b.Tkey=c.Tkey where b.ButtonID = 'cus' AND b.listy = 'N' order by b.ttext", Me.CboCustID)
        '    LoadM.LoadDataToTSComboBox("select b.ButtonID+ '-' + b.ttext as ttext from m_Logtree_t as b join m_Customer_t as d on b.ButtonID=d.CusID and d.Usey='Y' " _
        '                            & " join m_SysapForm_t as a on a.ApFormid ='" & Me.Name & "' and b.Formid=a.Apid join m_UserRight_t as c on c.UserID='" & SysMessageClass.UseId.ToLower & "' and b.Tkey=c.Tkey " _
        '                            & " where b.listy = 'N' order by b.ttext", Me.CboCustID)
        '    '裝載客戶信息，需考慮用戶所具有的權限
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "FrmBarM_Load", "sys")
        'End Try
    End Sub

#End Region

#Region "主窗體各控件事件"
    '選擇客戶下拉 2007/1/13
    'Private Sub CboCustID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCustID.SelectedIndexChanged

    '    'Dim RecTable As New DataTable
    '    Dim SqlStr As String = ""
    '    Try
    '        SqlStr = "select CusID from m_Customer_t where CusID='" & Me.CboCustID.Text.ToString.Split("-")(0) & "'"
    '        Using RecTable As SqlDataReader = Conn.GetDataReader(Trim(SqlStr))
    '            If RecTable.Read Then
    '                LoadM.CustID = RecTable("CusID").ToString
    '                LoadM.CustName = Me.CboCustID.SelectedItem.ToString
    '            Else
    '                LoadM.CustID = ""
    '                LoadM.CustName = ""
    '            End If
    '        End Using
    '        'LoadM.LoadDataToDataGrid("select a.CodeRuleID,case a.LabelType when 'S' then '產品條碼' when 'C' then '箱號條碼' when 'P' then '棧包裝' when 'N' then '無流水號標簽' end as LabelType,a.Remark,a.Fstyle,a.Fdest,a.Flen,a.Gflen,b.UserName,a.Intime from m_SnRuleM_t as a left join m_Users_t  as b on a.userid=b.userid join ( select a.buttonid,b.ttext from  m_Logtree_t as a join m_Logtree_t as b on  a.Tparent = b.Tkey and  b.Ttext ='" & LoadM.CustName.ToString.Trim & "' join m_SysapForm_t as c on  a.Formid = c.Apid and c.ApFormid ='" & Me.Name & "' join m_UserRight_t as d on d.tkey = a.tkey and d.UserID ='" & SysMessageClass.UseId.ToLower & "') as h on a.CodeRuleID=h.buttonid", Me.DgCodeRule)
    '        'LoadM.LoadDataToDataGrid("select a.CodeRuleID,case a.LabelType when 'S' then '產品條碼' when 'C' then '箱號條碼' when 'P' then '棧包裝' when 'N' then '無流水號標簽' end as LabelType,a.Remark,a.Fstyle,a.Fdest,a.Flen,a.Gflen,b.UserName,a.Intime " _
    '        '                     & " from m_SnRuleM_t as a join ( select a.buttonid,b.ttext from  m_Logtree_t as a join m_Logtree_t as b on  a.Tparent = b.Tkey and  b.ButtonID ='" & Me.CboCustID.Text.Trim.Split("-")(0) & "' join m_SysapForm_t as c " _
    '        '                     & " on  a.Formid = c.Apid and c.ApFormid ='" & Me.Name & "' join m_UserRight_t as d on d.tkey = a.tkey and d.UserID ='" & SysMessageClass.UseId.ToLower & "') as h on a.CodeRuleID=h.buttonid left join m_Users_t as b on a.userid=b.userid ", Me.DgCodeRule)

    '        LoadM.LoadDataToDataGrid("select a.CodeRuleID,case a.LabelType when 'S' then '产品条码' when 'C' then '箱号条码' when 'P' then '栈板条码' when 'N' then '无流水号标签' end as LabelType,a.Remark,a.Fstyle,a.Fdest,a.Flen,a.Gflen,b.UserName,a.Intime " _
    '                            & " from m_SnRuleM_t as a join ( select a.buttonid,b.ttext from  m_Logtree_t as a join m_Logtree_t as b on  a.Tparent = b.Tkey and  b.ButtonID ='" & Me.CboCustID.Text.Trim.Split("-")(0) & "' join m_SysapForm_t as c " _
    '                            & " on  a.Formid = c.Apid and c.ApFormid ='" & Me.Name & "' join m_UserRight_t as d on d.tkey = a.tkey and d.UserID ='" & SysMessageClass.UseId.ToLower & "') as h on a.CodeRuleID=h.buttonid left join m_Users_t as b on a.userid=b.userid ", Me.DgCodeRule)
    '        ToolLblCount.Text = Me.DgCodeRule.RowCount
    '        '裝載編碼原則信息，需考慮當前用戶的權限
    '        'Me.BnBulidBarCode.Enabled = IIf(LoadM.CodeRule <> "", True, False)
    '    Catch ex As Exception
    '        LoadM.CustID = ""
    '        LoadM.CustName = ""
    '        LoadM.CodeRule = ""
    '        SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "CboCustID_SelectedIndexChanged", "sys")
    '    End Try
    'End Sub


    ''建立條碼打印窗體
    'Public Sub BnBulidBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnBulidBarCode.Click
    '    Dim I, J As Int16
    '    Dim t As Int16 = 0
    '    Dim Sqlstr As String = ""
    '    Dim RecTable As New DataTable
    '    Dim TempView As DataView
    '    Dim Flag As Boolean = False

    '    Try
    '        '檢查編碼原則
    '        If LoadM.CodeRule.Trim = "" Then
    '            MsgBox("請先選擇客戶和條碼編碼原則！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '            Exit Sub
    '        Else
    '            Sqlstr = "select * from m_SnRuleM_t where CodeRuleID='" & LoadM.CodeRule.Trim & "'"
    '            RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '            Select Case RecTable.Rows(0)("LabelType").ToString
    '                Case "S"
    '                    If LoadM.CheckCodeRule(LoadM.CodeRule.Trim) = True Then
    '                        Dim FrmCheckDigitPrt As New FrmCheckDigitPrt
    '                        FrmCheckDigitPrt.LoadM.CodeRule = LoadM.CodeRule
    '                        FrmCheckDigitPrt.LoadM.CustID = LoadM.CustID
    '                        FrmCheckDigitPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        FrmCheckDigitPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                        FrmCheckDigitPrt.LoadM.Taskid = LoadM.Taskid
    '                        FrmCheckDigitPrt.ShowDialog()          '打印含有校驗位的條碼
    '                        FrmCheckDigitPrt.TopMost = True
    '                        Exit Sub
    '                    End If
    '                    If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "d" Then
    '                        Dim Frm2DPrt As New Frm2DPrt
    '                        Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                        Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                        Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                        Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                        Frm2DPrt.ShowDialog()          '打印2D標簽
    '                        Frm2DPrt.TopMost = True
    '                        Exit Sub
    '                    End If
    '                    If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "b" AndAlso Int(Microsoft.VisualBasic.Right(LoadM.CodeRule.Trim.ToLower, 3)) > 9 Then
    '                        If LoadM.CodeRule.Trim.ToUpper = "B021" Then
    '                            Dim FrmHeatPipe As New FrmHeatPipe
    '                            FrmHeatPipe.LoadM.CodeRule = LoadM.CodeRule
    '                            FrmHeatPipe.LoadM.CustID = LoadM.CustID
    '                            FrmHeatPipe.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                            FrmHeatPipe.LoadM.DefaultLine = LoadM.DefaultLine
    '                            FrmHeatPipe.LoadM.Taskid = LoadM.Taskid
    '                            FrmHeatPipe.ShowDialog()          '打印熱管內部管控條碼
    '                            FrmHeatPipe.TopMost = True
    '                            Exit Sub
    '                        Else
    '                            Dim Frm2DPrt As New Frm2DPrt
    '                            Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                            Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                            Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                            Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                            Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                            Frm2DPrt.ShowDialog()          '打印2D標簽
    '                            Frm2DPrt.TopMost = True
    '                            Exit Sub
    '                        End If
    '                    End If
    '                Case "C"
    '                    If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "c" AndAlso Int(Microsoft.VisualBasic.Right(LoadM.CodeRule.Trim.ToLower, 3)) > 2 Then
    '                        Dim FrmCartonV2 As New FrmCartonV2
    '                        FrmCartonV2.LoadM.CodeRule = LoadM.CodeRule
    '                        FrmCartonV2.LoadM.CustID = LoadM.CustID
    '                        FrmCartonV2.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        FrmCartonV2.LoadM.DefaultLine = LoadM.DefaultLine
    '                        FrmCartonV2.LoadM.Taskid = LoadM.Taskid
    '                        FrmCartonV2.ShowDialog()          '新版外箱標簽打印程序
    '                        FrmCartonV2.TopMost = True
    '                        Exit Sub
    '                    Else
    '                        Dim FrmCarton As New FrmCarton
    '                        FrmCarton.LoadM.CodeRule = LoadM.CodeRule
    '                        FrmCarton.LoadM.CustID = LoadM.CustID
    '                        FrmCarton.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        FrmCarton.LoadM.DefaultLine = LoadM.DefaultLine
    '                        FrmCarton.LoadM.Taskid = LoadM.Taskid
    '                        FrmCarton.ShowDialog()          '舊版外箱標簽打印程序
    '                        FrmCarton.TopMost = True
    '                        Exit Sub
    '                    End If
    '                Case "N"
    '                    If LoadM.CodeRule.Trim.ToUpper = "N003" Then
    '                        Dim FrmLEDpkg As New FrmLEDpkg
    '                        FrmLEDpkg.LoadM.CodeRule = LoadM.CodeRule
    '                        FrmLEDpkg.LoadM.CustID = LoadM.CustID
    '                        FrmLEDpkg.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        FrmLEDpkg.LoadM.DefaultLine = LoadM.DefaultLine
    '                        FrmLEDpkg.LoadM.Taskid = LoadM.Taskid
    '                        FrmLEDpkg.ShowDialog()          '打印LED箱標簽
    '                        FrmLEDpkg.TopMost = True
    '                        Exit Sub
    '                    Else
    '                        Dim FrmNoSerial As New FrmNoSerial
    '                        FrmNoSerial.LoadM.CodeRule = LoadM.CodeRule
    '                        FrmNoSerial.LoadM.CustID = LoadM.CustID
    '                        FrmNoSerial.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        FrmNoSerial.LoadM.DefaultLine = LoadM.DefaultLine
    '                        FrmNoSerial.LoadM.Taskid = LoadM.Taskid
    '                        FrmNoSerial.ShowDialog()          '打印無流水號條碼
    '                        FrmNoSerial.TopMost = True
    '                        Exit Sub
    '                    End If
    '                Case "P"
    '                    If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "p" Then
    '                        Dim Frm2DPrt As New Frm2DPrt
    '                        Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                        Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                        Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                        Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                        Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                        Frm2DPrt.ShowDialog()          '打印棧板標簽
    '                        Frm2DPrt.TopMost = True
    '                        Exit Sub
    '                    End If
    '            End Select
    '            RecTable.Dispose()
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
    '        Exit Sub
    '    End Try

    '    '建立條碼組成部分並分別賦初值
    '    Try
    '        Sqlstr = "select distinct a.F_codeID,d.ShortName from m_SnRuleD_t as a left join (select b.F_codeid,c.ShortName from m_SnSet_t as b join m_SnSet_t as c " & _
    '                "on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule & "' group by b.F_codeid,c.ShortName having count(b.f_codeid)=1) as d " & _
    '                "on  a.F_codeid=d.F_codeid where a.CodeRuleID = '" & LoadM.CodeRule & "' AND a.F_codeID NOT IN ('M', 'Y')"
    '        RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '        ReDim BarCodePart(4, 0)
    '        BarCodePartNum = 0
    '        For I = 0 To RecTable.Rows.Count - 1
    '            BarCodePartNum += 1
    '            ReDim Preserve BarCodePart(4, BarCodePartNum)
    '            BarCodePart(1, BarCodePartNum) = RecTable.Rows(I).Item("F_codeID").ToString    '條碼組成部分的馬元
    '            BarCodePart(2, BarCodePartNum) = RecTable.Rows(I).Item("ShortName").ToString   '條碼組成部分中的編碼原則設定值
    '            BarCodePart(4, BarCodePartNum) = 1
    '        Next
    '        RecTable.Dispose()

    '        Sqlstr = "select F_codeID,F_codestart,F_codelen,SplitChar from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' order by F_orderid asc"
    '        RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '        For I = 1 To BarCodePartNum
    '            t = 0
    '            Select Case BarCodePart(1, I)
    '                Case "S"
    '                    If Flag = False Then
    '                        TempView = New DataView(RecTable)
    '                        TempView.RowFilter = "F_codeID='S'"
    '                        TempView.Sort = "F_codestart ASC"
    '                        BarCodePart(2, I) = StrDup(TempView.Count, "S")    '產生重復的字符串函數
    '                        BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString  '條碼分割符
    '                        TempView.Dispose()
    '                        Flag = True
    '                    End If
    '                Case "D"
    '                    TempView = New DataView(RecTable)
    '                    TempView.RowFilter = "F_codeID='Y' or F_codeID='M' OR F_codeID='D'"
    '                    TempView.Sort = "F_codestart ASC"
    '                    For J = 1 To TempView.Count
    '                        t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
    '                    Next
    '                    BarCodePart(2, I) = StrDup(t, "#")
    '                    BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
    '                    TempView.Dispose()
    '                Case "W"
    '                    TempView = New DataView(RecTable)
    '                    TempView.RowFilter = "F_codeID='Y' or F_codeID='W'"
    '                    TempView.Sort = "F_codestart ASC"
    '                    For J = 1 To TempView.Count
    '                        t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
    '                    Next
    '                    BarCodePart(2, I) = StrDup(t, "#")
    '                    BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
    '                    TempView.Dispose()
    '                Case Else
    '                    TempView = New DataView(RecTable)
    '                    TempView.RowFilter = "F_codeID='" & BarCodePart(1, I) & "'"
    '                    If BarCodePart(2, I) <> "" Then
    '                    Else
    '                        BarCodePart(2, I) = StrDup(CInt(TempView.Item(0).Item("F_codelen").ToString.Trim), "#")
    '                    End If
    '                    BarCodePart(3, I) = TempView.Item(0).Item("SplitChar").ToString
    '                    TempView.Dispose()
    '            End Select
    '        Next
    '        RecTable.Dispose()
    '        BuildBar()
    '    Catch ex As Exception
    '        ReDim BarCodePart(4, 0)
    '        BarCodePartNum = 0
    '        SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
    '    End Try
    'End Sub

    ''YFH 2010/06/29
    '建立條碼打印窗體
    Public Sub BnBulidBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim I, J As Int16
        Dim t As Int16 = 0
        Dim Sqlstr As String = ""

        'Dim TempView As DataView
        Dim Flag As Boolean = False

        Try
            '檢查編碼原則
            If LoadM.CodeRule.Trim = "" Then
                MsgBox("請先選擇客戶和條碼編碼原則！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            Else
                'Sqlstr = "select LabelType from m_SnRuleM_t where CodeRuleID='" & LoadM.CodeRule.Trim & "'"
                'Using RecTable As SqlDataReader = Conn.GetDataReader(Trim(Sqlstr))
                '    If RecTable.Read Then
                '        Select Case RecTable("LabelType").ToString
                Select Case LoadM.vCodeType
                    Case "S"
                        If LoadM.CheckCodeRule(LoadM.CodeRule.Trim) = True Then
                            Dim FrmCheckDigitPrt As New FrmCheckDigitPrt
                            FrmCheckDigitPrt.LoadM.CodeRule = LoadM.CodeRule
                            FrmCheckDigitPrt.LoadM.CustID = LoadM.CustID
                            FrmCheckDigitPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
                            FrmCheckDigitPrt.LoadM.DefaultLine = LoadM.DefaultLine
                            FrmCheckDigitPrt.LoadM.Taskid = LoadM.Taskid
                            FrmCheckDigitPrt.LoadM.vIsprint = LoadM.vIsprint
                            FrmCheckDigitPrt.LoadM.Factory = LoadM.Factory '''''工廠別
                            FrmCheckDigitPrt.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
                            FrmCheckDigitPrt.LoadM.vShift = LoadM.vShift '''''班別
                            FrmCheckDigitPrt.LoadM.vVerNo = LoadM.vVerNo
                            FrmCheckDigitPrt.LoadM.vDriFlag = LoadM.vDriFlag
                            FrmCheckDigitPrt.ShowDialog()          '打印含有校驗位的條碼
                            FrmCheckDigitPrt.TopMost = True
                            Exit Sub
                        Else
                            Dim Frm2DPrt As New Frm2DPrt
                            Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
                            Frm2DPrt.LoadM.CustID = LoadM.CustID
                            Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
                            Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
                            Frm2DPrt.LoadM.Taskid = LoadM.Taskid
                            Frm2DPrt.LoadM.Taskid = LoadM.Taskid
                            Frm2DPrt.LoadM.Factory = LoadM.Factory '''''工廠別
                            Frm2DPrt.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
                            Frm2DPrt.LoadM.vShift = LoadM.vShift '''''班別
                            Frm2DPrt.LoadM.vLineJm = LoadM.vLineJm ''線別簡碼
                            Frm2DPrt.LoadM.vVerNo = LoadM.vVerNo
                            Frm2DPrt.LoadM.vDriFlag = LoadM.vDriFlag
                            Frm2DPrt.ShowDialog()          '打印2D標簽
                            Frm2DPrt.TopMost = True
                            Exit Sub
                        End If

                    Case "C", "P"
                        Dim strCodeRule As String = LoadM.CodeRule.Trim.ToLower
                        'If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "c" AndAlso Int(Microsoft.VisualBasic.Right(LoadM.CodeRule.Trim.ToLower, 3)) > 2 Then
                        'If Microsoft.VisualBasic.Left(strCodeRule, 1) = "c" AndAlso Int(Microsoft.VisualBasic.Right(strCodeRule, 3)) > 2 Then
                        Dim FrmCartonV2 As New FrmCartonV2
                        FrmCartonV2.LoadM.CodeRule = LoadM.CodeRule
                        FrmCartonV2.LoadM.CustID = LoadM.CustID
                        FrmCartonV2.LoadM.DefaultMoid = LoadM.DefaultMoid
                        FrmCartonV2.LoadM.DefaultLine = LoadM.DefaultLine
                        FrmCartonV2.LoadM.Taskid = LoadM.Taskid
                        FrmCartonV2.LoadM.Factory = LoadM.Factory '''''工廠別
                        FrmCartonV2.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
                        FrmCartonV2.LoadM.vShift = LoadM.vShift '''''班別
                        FrmCartonV2.LoadM.vLineJm = LoadM.vLineJm ''線別簡碼
                        FrmCartonV2.LoadM.vRequestDate = LoadM.vRequestDate ''申请日期
                        FrmCartonV2.LoadM.vVerNo = LoadM.vVerNo
                        FrmCartonV2.LoadM.vDriFlag = LoadM.vDriFlag
                        'FrmCartonV2.LoadM.vVerNo = LoadM.vVerNo
                        FrmCartonV2.ShowDialog()          '新版外箱標簽打印程序
                        FrmCartonV2.TopMost = True
                        Exit Sub
                    Case "N"
                        Dim FrmNoSerial As New FrmNoSerial
                        FrmNoSerial.LoadM.CodeRule = LoadM.CodeRule
                        FrmNoSerial.LoadM.CustID = LoadM.CustID
                        FrmNoSerial.LoadM.DefaultMoid = LoadM.DefaultMoid
                        FrmNoSerial.LoadM.DefaultLine = LoadM.DefaultLine
                        FrmNoSerial.LoadM.Taskid = LoadM.Taskid
                        FrmNoSerial.LoadM.vShift = LoadM.vShift
                        FrmNoSerial.ShowDialog()          '打印無流水號條碼
                        FrmNoSerial.TopMost = True
                        Exit Sub

                End Select
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
            Exit Sub
        End Try

        ''建立條碼組成部分並分別賦初值
        'Try
        '    Sqlstr = "select distinct a.F_codeID,d.ShortName from m_SnRuleD_t as a left join (select b.F_codeid,c.ShortName from m_SnSet_t as b join m_SnSet_t as c " & _
        '            "on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule & "' group by b.F_codeid,c.ShortName having count(b.f_codeid)=1) as d " & _
        '            "on  a.F_codeid=d.F_codeid where a.CodeRuleID = '" & LoadM.CodeRule & "' AND a.F_codeID NOT IN ('M', 'Y')"
        '    Using RecTable As SqlDataReader = Conn.GetDataReader(Trim(Sqlstr))
        '        ReDim BarCodePart(4, 0)
        '        BarCodePartNum = 0
        '        While RecTable.Read
        '            BarCodePartNum += 1
        '            ReDim Preserve BarCodePart(4, BarCodePartNum)
        '            BarCodePart(1, BarCodePartNum) = RecTable("F_codeID").ToString    '條碼組成部分的馬元
        '            BarCodePart(2, BarCodePartNum) = RecTable("ShortName").ToString   '條碼組成部分中的編碼原則設定值
        '            BarCodePart(4, BarCodePartNum) = 1
        '        End While
        '    End Using

        '    Sqlstr = "select F_codeID,F_codestart,F_codelen,SplitChar from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' order by F_orderid asc"
        '    Using TempView As DataView = Conn.GetDataTable(Trim(Sqlstr)).DefaultView
        '        For I = 1 To BarCodePartNum
        '            Select Case BarCodePart(1, I)
        '                Case "S"
        '                    If Flag = False Then
        '                        TempView.RowFilter = "F_codeID='S'"
        '                        TempView.Sort = "F_codestart ASC"
        '                        BarCodePart(2, I) = StrDup(TempView.Count, "S")    '產生重復的字符串函數
        '                        BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString  '條碼分割符
        '                        Flag = True
        '                    End If
        '                Case "D"
        '                    TempView.RowFilter = "F_codeID='Y' or F_codeID='M' OR F_codeID='D'"
        '                    TempView.Sort = "F_codestart ASC"
        '                    For J = 1 To TempView.Count
        '                        t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
        '                    Next
        '                    BarCodePart(2, I) = StrDup(t, "#")
        '                    BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
        '                Case "W"
        '                    TempView.RowFilter = "F_codeID='Y' or F_codeID='W'"
        '                    TempView.Sort = "F_codestart ASC"
        '                    For J = 1 To TempView.Count
        '                        t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
        '                    Next
        '                    BarCodePart(2, I) = StrDup(t, "#")
        '                    BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
        '                Case Else
        '                    TempView.RowFilter = "F_codeID='" & BarCodePart(1, I) & "'"
        '                    If BarCodePart(2, I) <> "" Then
        '                    Else
        '                        BarCodePart(2, I) = StrDup(CInt(TempView.Item(0).Item("F_codelen").ToString.Trim), "#")
        '                    End If
        '                    BarCodePart(3, I) = TempView.Item(0).Item("SplitChar").ToString
        '            End Select
        '        Next
        '    End Using
        '    'BuildBar()
        'Catch ex As Exception
        '    ReDim BarCodePart(4, 0)
        '    BarCodePartNum = 0
        '    SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
        'End Try
    End Sub
    'DataGrid單擊事件
    'Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCodeRule.CellClick
    '    On Error Resume Next
    '    If DgCodeRule.Item(0, e.RowIndex).Value.ToString <> "" Then
    '        LoadM.CodeRule = DgCodeRule.Item(0, e.RowIndex).Value
    '        'Me.BnBulidBarCode.Enabled = True
    '        ''Me.PictureBox1.ImageLocation = "\\pc-434\CodeRulePicture\" & LoadObject.CodeRule & ".bmp"
    '        ''Me.PictureBox1.Refresh()
    '    Else
    '        LoadM.CodeRule = ""
    '        'Me.BnBulidBarCode.Enabled = False
    '    End If
    'End Sub

#End Region

#Region "加載條碼打印窗體"

    '#Region "裝載控制項"

    '    Private Sub BuildBar()
    '        Dim Sqlstr As String = ""
    '        Dim RecTable As New DataTable
    '        Dim ConnRow As DataRow
    '        'Dim FrmBar As New FrmBarBuild

    '        ''定義條碼打印窗體，並定義其中的控件
    '        'Try
    '        '    Sqlstr = "select ObjName,ObjText,ObjLeft,ObjTop,ObjWidth,ObjHight,FontColor,ObjType,Areaid,ObjTabIndex,F_Codeid,ObjTag,ObjParent from m_SnFrmObj_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' and IsPrt='1'"
    '        '    RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '        '    ObjAInfoTable = RecTable
    '        '    If RecTable.Rows.Count > 0 Then
    '        '        For Each ConnRow In RecTable.Rows
    '        '            Select Case ConnRow.Item("ObjType").ToString
    '        '                Case "Cbo"
    '        '                    Dim Cbo As New ComboBox
    '        '                    LoadObj(Cbo, ConnRow)
    '        '                Case "Txt"
    '        '                    Dim Txt As New TextBox
    '        '                    LoadObj(Txt, ConnRow)
    '        '                Case "Lbl"
    '        '                    Dim Lbl As New Label
    '        '                    LoadObj(Lbl, ConnRow)
    '        '                Case "Grp"
    '        '                    Dim Grp As New GroupBox
    '        '                    LoadObj(Grp, ConnRow)
    '        '                Case "Frm"
    '        '                    LoadObj(FrmBar, ConnRow)
    '        '                Case "Bn"
    '        '                    Dim Bn As New Button
    '        '                    LoadObj(Bn, ConnRow)
    '        '                Case "Panel"
    '        '                    Dim Panel As New Panel
    '        '                    LoadObj(Panel, ConnRow)
    '        '                Case "ABarCtrl"
    '        '                    Select Case ConnRow.Item("ObjName").ToString
    '        '                        Case "AxBarCodeCtrl1"
    '        '                            LoadObj(FrmBar.AxBarCodeCtrl1, ConnRow)
    '        '                        Case "AxBarCodeCtrl2"
    '        '                            LoadObj(FrmBar.AxBarCodeCtrl2, ConnRow)
    '        '                        Case "AxBarCodeCtrl3"
    '        '                            LoadObj(FrmBar.AxBarCodeCtrl3, ConnRow)
    '        '                    End Select
    '        '            End Select
    '        '        Next
    '        '    Else
    '        '        Exit Sub
    '        '    End If
    '        '    ConnRow = Nothing
    '        '    RecTable.Dispose()

    '        '    SetParentAndSort()
    '        '    SetEvents()
    '        '    SetLbl()
    '        '    FrmBar.Refresh()
    '        '    FrmBar.ShowDialog()
    '        '    FrmBar.TopMost = True

    '        'Catch ex As Exception
    '        '    Dim sender As New Object
    '        '    Dim e As New System.EventArgs

    '        '    ObjAInfoTable.Dispose()
    '        '    SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarBuild", "BuildBar", "sys")
    '        '    ObjTypeBnQuit_Click(sender, e)
    '        'End Try
    '    End Sub

    '    Private Sub LoadObj(ByVal Obj As Object, ByVal DataR As DataRow)

    '        Try
    '            'Lable初始化
    '            If DataR.Item("ObjType").ToString.Trim = "Lbl" Then
    '                If DataR.Item("ObjTag").ToString = "" And DataR.Item("F_codeID").ToString = "" Then
    '                    Obj.autosize = False
    '                    Obj.TextAlign = ContentAlignment.MiddleRight
    '                End If
    '            End If

    '            '定義控件的位置
    '            If DataR.Item("ObjType").ToString.Trim = "Frm" Then
    '            Else
    '                Obj.Location = New Point(CInt(DataR.Item("ObjLeft").ToString.Trim), CInt(DataR.Item("ObjTop").ToString.Trim))
    '            End If
    '            Obj.Size = New Size(CInt(DataR.Item("ObjWidth").ToString.Trim), CInt(DataR.Item("ObjHight").ToString.Trim))

    '            '定義控件的初始化 Name , Value 及 Tag
    '            Obj.Text = DataR.Item("ObjText").ToString
    '            Obj.Name = DataR.Item("ObjName").ToString
    '            Obj.Tag = DataR.Item("ObjTag").ToString

    '            '定義控件的初始化字體顔色
    '            If DataR.Item("FontColor").ToString.Trim = "B" Then
    '                Obj.ForeColor = Color.Blue
    '            ElseIf DataR.Item("FontColor").ToString.Trim = "R" Then
    '                Obj.ForeColor = Color.Red
    '            End If

    '            '定義控件的 TabIndex 屬性
    '            If DataR.Item("ObjTabIndex").ToString.Trim <> "" Then
    '                Obj.tabindex = CInt(DataR.Item("ObjTabIndex").ToString.Trim)
    '            Else
    '                Obj.tabstop = False
    '            End If

    '            '分別定義各個控件
    '            Select Case DataR.Item("ObjType").ToString.Trim
    '                Case "Cbo"
    '                    LoadCbo(Obj, DataR)
    '                Case "Txt"
    '                    Obj.BorderStyle = BorderStyle.FixedSingle
    '                    If DataR.Item("ObjTag").ToString.Trim = "TxtPrintNum" Then
    '                        Obj.maxlength = 4
    '                    End If
    '                Case "Lbl"
    '                    LoadLbl(Obj, DataR)
    '                Case "Panel"
    '                    Obj.BackColor = Color.White
    '                Case "Bn"
    '                    LoadBn(Obj, DataR)
    '                Case "ABarCtrl"
    '                    Obj.Value = DataR.Item("ObjText").ToString
    '                    Obj.ShowData = 0
    '                    Obj.Style = 7
    '                    Obj.Visible = True
    '            End Select

    '            ObjArrayNum += 1
    '            ObjArrayL.Add(Obj)
    '        Catch ex As Exception
    '            ObjArrayL.Clear()
    '            ObjArrayNum = 0
    '            Throw ex
    '        End Try

    '    End Sub

    'Private Sub LoadCbo(ByVal Obj As Object, ByVal DataR As DataRow)
    '    Dim Sqlstr As String = ""
    '    Dim RecTable As New DataTable
    '    Dim ConnRow As DataRow

    '    Try
    '        If DataR.Item("F_codeID").ToString.Trim <> "" Then
    '            '設置打印窗體中非工單的下拉框
    '            Sqlstr = "select F_codeID,ShortName,FullName from m_SnSet_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' and F_codeID='" & DataR.Item("F_codeID").ToString.Trim & "'"
    '            RecTable = Conn.GetDataTable(Sqlstr)
    '            CboListNum = 0
    '            ReDim CboList(3, CboListNum)
    '            For Each ConnRow In RecTable.Rows
    '                Obj.Items.Add(ConnRow.Item("FullName").ToString.Trim)
    '                CboListNum += 1
    '                ReDim Preserve CboList(3, CboListNum)
    '                CboList(1, CboListNum) = ConnRow.Item("F_codeID").ToString.Trim
    '                CboList(2, CboListNum) = ConnRow.Item("ShortName").ToString
    '                CboList(3, CboListNum) = ConnRow.Item("FullName").ToString
    '            Next
    '            RecTable.Dispose()
    '        ElseIf Obj.tag.ToString = "CboMoID" Then
    '            '設置打印窗體中工單下拉框
    '            LoadM.LoadDataToTSComboBox("select distinct a.moid from m_Mainmo_t as a join m_PartPack_t as b on a.PartID=b.PartID and b.CodeRuleID='" & LoadM.CodeRule & "' and b.Usey='Y' join m_Logtree_t as c on a.Deptid=c.ButtonID join m_UserRight_t as d on c.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "' where a.FinalY='N' order by a.moid", Obj)
    '            'Sqlstr = "select distinct Moid from m_Mainmo_t as a join m_SnPartSet_t as b on a.PartID=b.TAvcPart and b.CodeRuleID='" & LoadM.CodeRule & "' and b.Usey='Y' join m_Logtree_t as c on a.Deptid=c.ButtonID join m_UserRight_t as d on  c.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "' where  a.Cusid='" & LoadM.CustID & "' and a.FinalY='N' order by a.moid"
    '            ''Sqlstr = "Select distinct(Moid) from (select moid,PartID,Deptid from m_Mainmo_t where Cusid='" & LoadM.CustID & "' and FinalY='N' ) as a join m_SnPartSet_t as b on a.PartID=b.TAvcPart and b.CodeRuleID='" & LoadM.CodeRule & "' and b.Usey='Y' join (select ButtonID from m_Logtree_t as e join m_UserRight_t as d  on e.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "') as c on a.Deptid=c.ButtonID"
    '            'RecTable = Conn.GetDataTable(Sqlstr)
    '            'For Each ConnRow In RecTable.Rows
    '            '    Obj.Items.Add(ConnRow.Item("Moid").ToString.Trim)
    '            'Next
    '            RecTable.Dispose()
    '        End If
    '        Obj.DropDownStyle = ComboBoxStyle.DropDownList
    '    Catch ex As Exception
    '        ReDim CboList(3, 0)
    '        CboListNum = 0
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub LoadLbl(ByVal Obj As Object, ByVal DataR As DataRow)
    '    Dim RecTable As New DataTable
    '    Dim Datet As New DateTime
    '    Dim I As Int16
    '    Dim Sqlstr As String

    '    Try
    '        '設置用來生産日期(全日期格式)的標簽
    '        If DataR.Item("ObjTag").ToString.Trim = "LblFullTime" Then
    '            Sqlstr = "select getdate() as Datet"
    '            RecTable = Conn.GetDataTable(Sqlstr)
    '            Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
    '            Obj.Text = Datet.AddHours(-7.5).Date.ToString("yyyy-MM-dd")
    '            RecTable.Dispose()
    '        End If

    '        '設置用來生産日期代碼的標簽
    '        If DataR.Item("F_Codeid").ToString.Trim = "D" OrElse DataR.Item("F_Codeid").ToString.Trim = "W" OrElse DataR.Item("F_Codeid").ToString.Trim = "DW" Then
    '            Sqlstr = "select getdate() as Datet"
    '            RecTable = Conn.GetDataTable(Sqlstr)
    '            Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
    '            RecTable.Dispose()
    '            Obj.Text = LoadM.ShowShortTime(Datet.AddHours(-7.5).Date, DataR.Item("F_Codeid").ToString.Trim)
    '            For I = 1 To BarCodePartNum
    '                If BarCodePart(1, I) = DataR.Item("F_Codeid").ToString.Trim Then
    '                    BarCodePart(2, I) = Obj.Text.ToString
    '                    Exit For
    '                End If
    '            Next
    '        End If

    '        '設置用來顯示條碼的標簽
    '        If DataR.Item("ObjParent").ToString.Trim = "Panel1" OrElse DataR.Item("Areaid").ToString.Trim <> "" Then
    '            Obj.BackColor = Color.White
    '            Obj.font = New Font(FontFamily.GenericSansSerif, 11.0F, FontStyle.Bold)
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub LoadBn(ByVal Obj As Object, ByVal DataR As DataRow)
    '    Dim Sqlstr As String = ""

    '    Try
    '        '設置按鈕的基本屬性
    '        Obj.TextAlign = ContentAlignment.BottomRight
    '        Obj.FlatStyle = Windows.Forms.FlatStyle.Popup

    '        '設置按鈕的顯示圖片及顯示,需要考慮用戶的權限
    '        Select Case Obj.tag.ToString.Trim
    '            Case "BnEdit"
    '                Obj.Image = Global.BarCodePrint.My.Resources.EditTableHS
    '                Me.ToolTip1.SetToolTip(Obj, "修改生產時間")
    '                Sqlstr = "select a.buttonid from m_Logtree_t as a join m_SysapForm_t as b on a.Formid=b.Apid and  b.ApFormid='" & Me.Name & "' join m_Logtree_t as c on a.Tparent=c.Tkey and c.Ttext='" & LoadM.CodeRule & "' join m_UserRight_t as d on a.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "' where a.buttonid='edit'"
    '                LoadM.SetObjRight(Sqlstr, Obj)
    '            Case "BnTestPrint"
    '                Obj.Image = Global.BarCodePrint.My.Resources.PrintPreviewHS
    '                Sqlstr = "select a.buttonid from m_Logtree_t as a join m_SysapForm_t as b on a.Formid=b.Apid and  b.ApFormid='" & Me.Name & "' join m_Logtree_t as c on a.Tparent=c.Tkey and c.Ttext='" & LoadM.CodeRule & "' join m_UserRight_t as d on a.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "' where a.buttonid='print'"
    '                LoadM.SetObjRight(Sqlstr, Obj)
    '            Case "BnBeginPrint"
    '                Obj.Image = Global.BarCodePrint.My.Resources.PrintHS
    '                Sqlstr = "select a.buttonid from m_Logtree_t as a join m_SysapForm_t as b on a.Formid=b.Apid and  b.ApFormid='" & Me.Name & "' join m_Logtree_t as c on a.Tparent=c.Tkey and c.Ttext='" & LoadM.CodeRule & "' join m_UserRight_t as d on a.Tkey=d.Tkey and d.UserID='" & SysMessageClass.UseId.ToLower & "' where a.buttonid='print'"
    '                LoadM.SetObjRight(Sqlstr, Obj)
    '            Case "BnQuit"
    '                Obj.Image = Global.BarCodePrint.My.Resources.Snap3
    '        End Select
    '        Obj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

#End Region

#Region "設置父控制項和子控制項的關聯"

    Private Sub SetParentAndSort()
        'Dim I, J As Int16
        'Dim ObjSon As Object
        'Dim ObjParent As Object

        'For I = 0 To ObjArrayNum - 1
        '    ObjSon = ObjArrayL.Item(I)
        '    If ObjAInfoTable.Rows(I).Item("ObjParent").ToString = "Hide" Then
        '        ObjSon.Visible = False
        '    ElseIf ObjAInfoTable.Rows(I).Item("ObjParent").ToString <> "" Then
        '        For J = 0 To ObjArrayNum - 1
        '            ObjParent = ObjArrayL.Item(J)
        '            If ObjParent.name = ObjAInfoTable.Rows(I).Item("ObjParent").ToString Then
        '                ObjParent.Controls.Add(ObjSon)
        '                ObjSon.BringToFront()
        '                Exit For
        '            End If
        '        Next
        '    End If
        'Next
    End Sub

#End Region

#Region "為窗體中的控件定義事件"

    Private Sub SetEvents()
        'Dim I As Int16
        'Dim Obj As New Object

        'For I = 0 To ObjArrayNum - 1
        '    Obj = ObjArrayL.Item(I)
        '    Select Case Obj.GetType.Name
        '        Case "ComboBox"
        '            Dim ObjCbo As New ComboBox
        '            ObjCbo = Obj
        '            AddHandler ObjCbo.SelectedIndexChanged, AddressOf ObjTypeCbo_SelectedIndexChanged
        '            If ObjCbo.Tag.ToString = "CboMoID" AndAlso LoadM.DefaultMoid.Trim <> "" Then LoadM.LockMoid(LoadM.DefaultMoid, ObjCbo)
        '        Case "Button"
        '            Dim ObjBn As New Button
        '            ObjBn = Obj
        '            Select Case Obj.tag
        '                Case "BnEdit"
        '                    AddHandler ObjBn.Click, AddressOf ObjTypeBnEdit_Click
        '                Case "BnTestPrint"
        '                    AddHandler ObjBn.Click, AddressOf ObjTypeBnTestPrint_Click
        '                Case "BnBeginPrint"
        '                    AddHandler ObjBn.Click, AddressOf ObjTypeBnBeginPrint_Click
        '                Case "BnQuit"
        '                    AddHandler ObjBn.Click, AddressOf ObjTypeBnQuit_Click
        '            End Select
        '        Case "TextBox"
        '            If Obj.tag = "TxtPrintNum" Then
        '                Dim ObjTxt As New TextBox
        '                ObjTxt = Obj
        '                AddHandler ObjTxt.KeyPress, AddressOf ObjTypeTxt_KeyPress
        '                AddHandler ObjTxt.TextChanged, AddressOf ObjTypeTxt_TextChanged
        '            End If
        '        Case "FrmBarBuild"
        '            Dim Frm As New Form
        '            Frm = Obj
        '            AddHandler Frm.FormClosing, AddressOf FrmType_FormClosing
        '        Case "Label"
        '            If Obj.Tag = "LblFullTime" Then
        '                Dim ObjLbl As New Label
        '                ObjLbl = Obj
        '                AddHandler ObjLbl.TextChanged, AddressOf ObjTypeLbl_TextChanged
        '            End If
        '    End Select
        'Next
    End Sub

#End Region

    '#Region "Lbl的Text改變事件"

    '    Private Sub ObjTypeLbl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjTypeLbl.TextChanged
    '        Dim I, J As Int16
    '        Dim Obj As New Object

    '        Try
    '            For I = 0 To ObjArrayNum - 1
    '                If ObjAInfoTable.Rows(I).Item("F_codeID").ToString = "D" OrElse ObjAInfoTable.Rows(I).Item("F_codeID").ToString = "W" OrElse ObjAInfoTable.Rows(I).Item("F_codeID").ToString = "DW" Then
    '                    Obj = ObjArrayL.Item(I)
    '                    Obj.Text = LoadM.ShowShortTime(CType(sender.text.ToString.Trim, DateTime), ObjAInfoTable.Rows(I).Item("F_codeID").ToString)
    '                    For J = 1 To BarCodePartNum
    '                        If BarCodePart(1, J) = ObjAInfoTable.Rows(I).Item("F_codeID").ToString Then
    '                            BarCodePart(2, J) = Obj.text.ToString
    '                            Exit For
    '                        End If
    '                    Next
    '                    Exit For
    '                End If
    '            Next
    '            SetLbl()
    '        Catch ex As Exception
    '            Dim sender1 As New Object
    '            Dim e1 As New System.EventArgs

    '            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarBuild", "ObjTypeLbl_TextChanged", "sys")
    '            ObjTypeBnQuit_Click(sender1, e1)
    '        End Try
    '    End Sub

    '#End Region

#Region "窗體關閉事件"

    'Private Sub FrmType_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles FrmType.FormClosing
    '    'ReDim SBCodeUnit(SBCodeLEN - 1, 0)
    '    'SBCodeLEN = 0
    '    'ReDim BarCodePart(4, 0)
    '    'BarCodePartNum = 0
    '    'ObjAInfoTable.Dispose()
    '    'CurrCodeUnitTable.Dispose()
    '    'PrtStrTable.Dispose()
    '    'ObjArrayL.Clear()
    '    'ObjArrayNum = 0
    '    'ReDim CboList(3, 0)
    '    'CboListNum = 0
    '    'PrintStr.Remove(0, PrintStr.Length)
    '    ''BarCodeStyle.Remove(0, BarCodeStyle.Length)
    '    'ReDim PrintPart(2, 0)
    '    'MoidAllNum = 0
    '    'MoidPrinted = 0

    '    'LoadD.dispose()
    '    'SqlClassD.UpdateTime = ""
    'End Sub

#End Region

    '#Region "Txt的事件"

    'Private Sub ObjTypeTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ObjTypeTxt.KeyPress
    '    If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub ObjTypeTxt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjTypeTxt.TextChanged
    '    If sender.text <> "" Then
    '        CheckPrintNum(Int(sender.text.ToString))
    '    Else
    '        CheckPrintNum(0)
    '        Exit Sub
    '    End If
    'End Sub

    '    Private Function CheckPrintNum(ByVal num As Int16) As Boolean
    '        Dim Sqlstr As String
    '        'Dim RecTable As New DataTable
    '        Dim ObjLbl As New Object
    '        Dim I As Int16

    '        LoadD.CurrPrintNum = 0
    '        For I = 0 To ObjArrayNum - 1
    '            ObjLbl = ObjArrayL.Item(I)
    '            If ObjLbl.tag.ToString = "LblStartSn" Then
    '                ObjLbl.text = "######"
    '            ElseIf ObjLbl.tag.ToString = "LblEndSn" Then
    '                ObjLbl.text = "######"
    '            End If
    '        Next

    '        If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
    '            MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '            Return False
    '        End If
    '        Try
    '            LoadD.StyleID = LoadM.MakeStyle(BarCodePart, BarCodePartNum)
    '            If LoadD.StyleID = "" Then
    '                MsgBox("生成樣式錯誤！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                Return False
    '            Else
    '                Sqlstr = "select MaxSN,MaxInt from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString & "'"
    '                Using RecTable As SqlDataReader = Conn.GetDataReader(Sqlstr)
    '                    If RecTable.Read Then
    '                        LoadD.BarCodeStyleMax = RecTable("MaxSN").ToString
    '                        LoadD.CurrMaxInt = Int(RecTable("MaxInt").ToString)
    '                    Else
    '                        LoadD.BarCodeStyleMax = ""
    '                        LoadD.CurrMaxInt = 0
    '                    End If
    '                End Using
    '            End If

    '            If num > 1000 Then
    '                MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                Return False
    '            ElseIf num <= 0 Then
    '                Return False
    '            End If
    '            LoadD.CurrPrintNum = num

    '            For I = 0 To ObjArrayNum - 1
    '                ObjLbl = ObjArrayL.Item(I)
    '                If ObjLbl.tag.ToString = "LblStartSn" Then
    '                    ObjLbl.text = LoadM.IntToCode(LoadD.CurrMaxInt + 1, LoadM.CodeRule)
    '                    If ObjLbl.text = "" Then
    '                        Return False
    '                    End If
    '                ElseIf ObjLbl.tag.ToString = "LblEndSn" Then
    '                    ObjLbl.text = LoadM.IntToCode(LoadD.CurrMaxInt + LoadD.CurrPrintNum, LoadM.CodeRule)
    '                    If ObjLbl.text = "" Then
    '                        Return False
    '                    End If
    '                End If
    '            Next

    '            Return True
    '        Catch ex As Exception
    '            Dim sender As New Object
    '            Dim e As New System.EventArgs
    '            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarBuild", "CheckPrintNum", "sys")
    '            ObjTypeBnQuit_Click(sender, e)
    '        End Try
    '    End Function

    '#End Region

#Region "生成/打印條碼/退出按鈕事件"
    '正式打印
    'Private Sub ObjTypeBnBeginPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjTypeBnBeginPrint.Click
    '    BuildBarCode("Y")   '
    'End Sub
    ''測試打印
    'Private Sub ObjTypeBnTestPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjTypeBnTestPrint.Click
    '    BuildBarCode("N")   '
    'End Sub
    '生成條碼/打印條碼函數入口
    Private Sub BuildBarCode(ByVal UseY As String)
        'Dim I As Int16
        'Dim Obj As New Object

        'Try
        '    If MsgBox("請確認打印機是否已開啓及連接是否正確！", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If

        '    '打印前例行檢查及生成樣式和檢測樣式
        '    If Checking() = False OrElse CheckStyle() = False Then
        '        Exit Sub
        '    End If

        '    '生成序號並送打印機
        '    For I = 0 To ObjArrayNum - 1
        '        Obj = ObjArrayL.Item(I)
        '        If Obj.name = "GroupBox2" OrElse Obj.name = "GroupBox1" Then
        '            Obj.enabled = False
        '        End If
        '    Next

        '    MainMarkSCode(UseY) '產生序號 

        '    For I = 0 To ObjArrayNum - 1
        '        Obj = ObjArrayL.Item(I)
        '        If Obj.name = "GroupBox2" OrElse Obj.name = "GroupBox1" Then
        '            Obj.enabled = True
        '        End If
        '    Next

        'Catch ex As Exception
        '    Dim sender As New Object
        '    Dim e As New System.EventArgs
        '    SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarBuild", "BuildBarCode", "sys")
        '    ObjTypeBnQuit_Click(sender, e)
        'End Try
    End Sub
    '例行檢查
    Private Function Checking() As Boolean
        'Dim I As Int16
        'Dim Obj As New Object
        ''測試端口是否存在
        'If SysMessageClass.PrinterPort.Trim <> "" Then
        '    'If SysMessageClass.CheckPrinterPort(SysMessageClass.PrinterPort.Trim) = False Then
        '    '    MsgBox("端口連接出錯!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    '    Return False
        '    'End If
        'Else
        '    MsgBox("請選擇打印端口,並下載字體！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Return False
        'End If
        ''檢測AVC料件
        'If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
        '    MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Return False
        'End If
        ''檢測打印數量
        'For I = 0 To ObjArrayNum - 1
        '    Obj = ObjArrayL.Item(I)
        '    If Obj.tag = "TxtPrintNum" Then
        '        If IsNumeric(Obj.text.ToString) Then
        '            LoadD.CurrPrintNum = Int(Obj.text.ToString)
        '        Else
        '            LoadD.CurrPrintNum = 0
        '        End If
        '        If CheckPrintNum(LoadD.CurrPrintNum) = False Then
        '            Return False
        '        End If
        '        Exit For
        '    End If
        'Next
        'If MoidPrinted + LoadD.CurrPrintNum > MoidAllNum Then
        '    If MessageBox.Show("你申請的打印量已超標，請確認是否需要打印這么多量？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Function
        'End If
        Return True
    End Function
    '檢查樣式
    Private Function CheckStyle() As Boolean
        Dim Sqlstr As String
        Dim RecTable As New DataTable

        Try
            '核查樣式表
            Sqlstr = "select StyleID,MaxSN,MaxInt,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString & "'"
            RecTable = Conn.GetDataTable(Sqlstr)
            If RecTable.Rows.Count > 0 Then
                If RecTable.Rows(0).Item("IsUsed").ToString = "N" Then
                    LoadD.BarCodeStyleMax = RecTable.Rows(0).Item("MaxSN").ToString
                    LoadD.CurrMaxInt = Int(RecTable.Rows(0).Item("MaxInt").ToString)

                    Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID & "'"
                    Conn.ExecSql(Sqlstr)
                Else
                    MsgBox("此料號正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                End If
            Else
                LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                LoadD.CurrMaxInt = LoadD.StartInt

                Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                Conn.ExecSql(Sqlstr)
            End If

            RecTable.Dispose()
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID)
            Throw ex
            Return False
        End Try
    End Function

    'Private Sub ObjTypeBnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjTypeBnQuit.Click
    '    'Dim I As Int16
    '    'Dim Obj As New Object

    '    'For I = 0 To ObjArrayNum - 1
    '    '    Obj = ObjArrayL.Item(I)
    '    '    If Obj.GetType.Name = "FrmBarBuild" Then
    '    '        Obj.Close()
    '    '        Exit Sub
    '    '    End If
    '    'Next
    'End Sub

#End Region

#Region "修改生産時間"

    'Private Sub ObjTypeBnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjTypeBnEdit.Click
    '    'Dim FrmEditTime As New FrmEditTime
    '    'Dim J As Int16
    '    'Dim Obj As New Object

    '    'FrmEditTime.ShowDialog()
    '    'If SqlClassD.UpdateTime.ToString <> "" Then
    '    '    For J = 0 To ObjArrayNum - 1
    '    '        Obj = ObjArrayL.Item(J)
    '    '        If Obj.tag.ToString = "LblFullTime" Then
    '    '            Obj.Text = Format(CDate(SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '    '            SqlClassD.UpdateTime = ""
    '    '            Exit For
    '    '        End If
    '    '    Next
    '    'End If
    'End Sub

#End Region

    '#Region "窗體的Cbo的索引改變事件"

    '    Private Sub ObjTypeCbo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjTypeCbo.SelectedIndexChanged
    '        Dim J, K As Int16
    '        Dim Sqlstr As String = ""
    '        Dim Obj As New Object
    '        Dim RecTable As New DataTable
    '        Dim PrtArray As New SysMessageClass.PrtStructure
    '        Dim ReStr As String

    '        Try
    '            If sender.tag.ToString = "CboMoID" Then
    '                LoadD.CurrMoid = sender.SelectedItem.ToString

    '                ReStr = LoadM.CheckMoid(sender.SelectedItem.ToString, "S", LoadM.CodeRule.Trim.ToUpper)
    '                If ReStr <> "1" Then
    '                    MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                    Exit Sub
    '                End If

    '                '設置料件基本信息
    '                Sqlstr = "select a.Partid,b.Moqty,b.Ppidprtqty,a.StartInt,a.StartSn,a.EndInt,EndSn,a.PFormatID from m_PartPack_t as a join m_Mainmo_t as b on a.Partid=b.PartID and b.Moid='" & LoadD.CurrMoid & "' and a.Packid='S' and b.FinalY='N' and a.Usey='Y'"
    '                'Sqlstr = "select a.Partid,b.Moqty,b.Ppidprtqty,a.StartInt,a.StartSn,a.EndInt,EndSn,a.PFormatID from m_PartPack_t as a join m_Mainmo_t as b on a.Partid=b.PartID and b.Moid='" & LoadD.CurrMoid & "' and a.Packid='S'"
    '                RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '                If RecTable.Rows.Count > 0 Then
    '                    LoadD.CurrAVCPartID = RecTable.Rows(0).Item("Partid").ToString.Trim.ToUpper
    '                    MoidAllNum = Int(IIf(RecTable.Rows(0).Item("Moqty").ToString <> "", RecTable.Rows(0).Item("Moqty").ToString, 0))
    '                    MoidPrinted = Int(IIf(RecTable.Rows(0).Item("Ppidprtqty").ToString <> "", RecTable.Rows(0).Item("Ppidprtqty").ToString, 0))
    '                    LoadD.PFormat = RecTable.Rows(0).Item("PFormatID").ToString
    '                    LoadD.StartSn = RecTable.Rows(0).Item("StartSn").ToString
    '                    LoadD.EndSn = RecTable.Rows(0).Item("EndSn").ToString
    '                    LoadD.EndInt = Int(IIf(RecTable.Rows(0).Item("EndInt").ToString <> "", RecTable.Rows(0).Item("EndInt").ToString, "0"))
    '                    LoadD.StartInt = Int(IIf(RecTable.Rows(0).Item("StartInt").ToString <> "", RecTable.Rows(0).Item("StartInt").ToString, "0"))
    '                End If
    '                RecTable.Dispose()

    '                Sqlstr = "select a.F_codeID,a.DValues from m_SnPartSet_t a join m_SnRuleM_t b on b.LabelType=a.Packid where a.Partid='" & LoadD.CurrAVCPartID & "' and a.usey='Y' and b.coderuleid='" & LoadM.CodeRule & "'"
    '                'Sqlstr = "select F_codeID,DValues from m_SnPartSet_t where  TAvcPart='" & LoadD.CurrAVCPartID & "' and  usey='Y' and coderuleid='" & LoadM.CodeRule & "'"
    '                RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '                If RecTable.Rows.Count > 0 Then
    '                    For J = 0 To RecTable.Rows.Count - 1
    '                        For K = 1 To BarCodePartNum
    '                            If RecTable.Rows(J).Item("F_codeID").ToString.Trim = BarCodePart(1, K) Then
    '                                BarCodePart(2, K) = RecTable.Rows(J).Item("DValues").ToString
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next
    '                End If
    '                RecTable.Dispose()
    '                '數組參數的設置()
    '                PrtArray.AvcPartid = LoadD.CurrAVCPartID.ToUpper.Trim
    '                Sqlstr = "select a.F_codeID,b.ObjTag from m_SnRuleD_t as a join m_SnFrmObj_t as b on a.CodeRuleID=b.CodeRuleID and a.F_codeID=b.F_codeID and Left(b.ObjTag, 5) ='Array' and b.isprt='1' where a.CodeRuleID='" & LoadM.CodeRule & "'"
    '                RecTable = Conn.GetDataTable(Sqlstr)
    '                For J = 0 To RecTable.Rows.Count - 1
    '                    For K = 1 To BarCodePartNum
    '                        If BarCodePart(1, K) = RecTable.Rows(J).Item("F_Codeid").ToString Then
    '                            BarCodePart(2, K) = PrtArray.ToArray(Int(Microsoft.VisualBasic.Right(RecTable.Rows(J).Item("ObjTag").ToString, 1))).ToString.Trim
    '                            Exit For
    '                        End If
    '                    Next
    '                Next
    '            Else
    '                If sender.Items.Count > 0 Then
    '                    For K = 1 To CboListNum
    '                        If sender.SelectedItem.ToString = CboList(3, K) Then
    '                            For J = 1 To BarCodePartNum
    '                                If CboList(1, K) = BarCodePart(1, J) Then
    '                                    BarCodePart(2, J) = CboList(2, K)
    '                                    Exit For
    '                                End If
    '                            Next
    '                            Exit For
    '                        End If
    '                    Next
    '                End If
    '            End If

    '            SetLbl()
    '        Catch ex As Exception
    '            Dim sender1 As New Object
    '            Dim e1 As New System.EventArgs
    '            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarBuild", "ObjTypeCbo_SelectedIndexChanged", "sys")
    '            ObjTypeBnQuit_Click(sender1, e1)
    '        End Try
    '    End Sub

    '#End Region

    '#Region "設置每個需要變更的Lbl的Text"

    '    Private Sub SetLbl()
    '        Dim I, J, K As Int16
    '        Dim Sqlstr As String = ""
    '        Dim RecTable As New DataTable
    '        Dim ObjLbl As New Object

    '        Try
    '            For I = 0 To ObjArrayNum - 1
    '                ObjLbl = ObjArrayL.Item(I)
    '                If TypeOf ObjLbl Is Label Then
    '                    '設置F_Codeid字段有值的標簽
    '                    If ObjAInfoTable.Rows(I).Item("F_codeID").ToString <> "" Then
    '                        ObjLbl.Text = ObjAInfoTable.Rows(I).Item("ObjText").ToString
    '                        For J = 1 To BarCodePartNum
    '                            If BarCodePart(1, J) = ObjAInfoTable.Rows(I).Item("F_codeID").ToString Then
    '                                ObjLbl.text = IIf(BarCodePart(2, J) <> "", ObjLbl.text & BarCodePart(2, J), "")
    '                                Exit For
    '                            End If
    '                        Next
    '                        Continue For
    '                    End If

    '                    '更新與2007/3/29，為了適應Foxconn客戶的HHP P/N與HP P/N設置
    '                    If Microsoft.VisualBasic.Left(ObjLbl.tag.ToString, 5) = "Label" Then
    '                        ObjLbl.Text = ObjAInfoTable.Rows(I).Item("ObjText").ToString
    '                        Sqlstr = "select F_codeID from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' and BarArea='" & ObjLbl.tag.ToString & "' order by F_orderid asc"
    '                        RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '                        For J = 0 To RecTable.Rows.Count - 1
    '                            For K = 1 To BarCodePartNum
    '                                If BarCodePart(1, K) = RecTable.Rows(J).Item("F_codeID").ToString Then
    '                                    ObjLbl.text &= BarCodePart(2, K)
    '                                    Exit For
    '                                End If
    '                            Next
    '                        Next
    '                        RecTable.Dispose()
    '                        Continue For
    '                    End If

    '                    '設置用來顯示AVC料號的標簽，以及用來顯示打印紙張大小的標簽
    '                    Select Case ObjLbl.tag.ToString
    '                        Case "LblAVCPartID"
    '                            ObjLbl.text = LoadD.CurrAVCPartID
    '                        Case "LblPaper"
    '                            If LoadD.PFormat.ToString <> "" Then
    '                                Sqlstr = "select PaperSize,ColNum from m_SnPFormat_t where PFormatID='" & LoadD.PFormat & "'"
    '                                RecTable = Conn.GetDataTable(Sqlstr)
    '                                If RecTable.Rows.Count > 0 Then
    '                                    ObjLbl.text = RecTable.Rows(0).Item("PaperSize").ToString
    '                                    LoadD.PrintColNum = Int(RecTable.Rows(0).Item("ColNum").ToString)
    '                                End If
    '                            Else
    '                                ObjLbl.text = "##########"
    '                            End If
    '                        Case "LblMoidAll"
    '                            ObjLbl.text = MoidAllNum
    '                        Case "LblMoidNum"
    '                            ObjLbl.text = MoidPrinted
    '                        Case "LblPNMax"
    '                            '生成樣式
    '                            LoadD.StyleID = LoadM.MakeStyle(BarCodePart, BarCodePartNum)
    '                            If LoadD.StyleID = "" Then
    '                                MsgBox("生成樣式錯誤！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                                Exit Sub
    '                            Else
    '                                Sqlstr = "select MaxSN,MaxInt from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString & "'"
    '                                RecTable = Conn.GetDataTable(Sqlstr)
    '                                If RecTable.Rows.Count > 0 Then
    '                                    LoadD.BarCodeStyleMax = RecTable.Rows(0).Item("MaxSN").ToString
    '                                    LoadD.CurrMaxInt = Int(RecTable.Rows(0).Item("MaxInt").ToString)
    '                                Else
    '                                    LoadD.BarCodeStyleMax = ""
    '                                    LoadD.CurrMaxInt = 0
    '                                End If
    '                            End If
    '                            ObjLbl.text = LoadD.CurrMaxInt & " ( " & LoadD.BarCodeStyleMax & " )"
    '                        Case "BarCode1"      '設置用來顯示BarCode字符串的標簽
    '                            ObjLbl.Text = ObjAInfoTable.Rows(I).Item("ObjText").ToString
    '                            SetBarCodeLbl(ObjLbl, ObjAInfoTable.Rows(I).Item("ObjParent").ToString)
    '                        Case "BarCode2"
    '                            ObjLbl.Text = ObjAInfoTable.Rows(I).Item("ObjText").ToString
    '                            SetBarCodeLbl(ObjLbl, ObjAInfoTable.Rows(I).Item("ObjParent").ToString)
    '                        Case "BarCode3"
    '                            ObjLbl.Text = ObjAInfoTable.Rows(I).Item("ObjText").ToString
    '                            SetBarCodeLbl(ObjLbl, ObjAInfoTable.Rows(I).Item("ObjParent").ToString)
    '                    End Select
    '                End If
    '            Next

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Private Sub SetBarCodeLbl(ByVal ObjLbl As Label, ByVal ParentStr As String)
    '        Dim J, K As Int16
    '        Dim Sqlstr As String = ""
    '        Dim RecTable As New DataTable

    '        Try
    '            If ParentStr = "Hide" Then
    '                Sqlstr = "select F_codeID,BarArea from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' and BarArea in('" & ObjLbl.Tag.ToString & "') order by F_orderid asc"
    '            Else
    '                Sqlstr = "select F_codeID,BarArea from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' and BarArea in('" & ObjLbl.Tag.ToString & "','BarLabel" & Microsoft.VisualBasic.Right(ObjLbl.Tag.ToString, 1) & "') order by F_orderid asc"
    '            End If
    '            RecTable = Conn.GetDataTable(Trim(Sqlstr))
    '            For J = 0 To RecTable.Rows.Count - 1
    '                For K = 1 To BarCodePartNum
    '                    If BarCodePart(1, K) = RecTable.Rows(J).Item("F_codeID").ToString AndAlso BarCodePart(4, K) = 1 Then
    '                        If ParentStr = "Hide" Then
    '                            If RecTable.Rows(J).Item("F_codeID").ToString = "S" Then
    '                                LoadD.AxSPos = Len(ObjLbl.Text)
    '                            End If
    '                            ObjLbl.Text &= BarCodePart(2, K)
    '                        Else
    '                            If RecTable.Rows(J).Item("F_codeID").ToString = "S" Then
    '                                LoadD.LblSPos = Len(ObjLbl.Text)
    '                            End If
    '                            ObjLbl.Text &= BarCodePart(2, K)

    '                            If BarCodePart(3, K) <> "" Then
    '                                ObjLbl.Text &= BarCodePart(3, K)
    '                            End If
    '                        End If
    '                        BarCodePart(4, K) = 2
    '                        Exit For
    '                    End If
    '                Next
    '            Next
    '            RecTable.Dispose()

    '            For K = 1 To BarCodePartNum
    '                BarCodePart(4, K) = 1
    '            Next

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '#End Region

    '#End Region

    '#Region "生成序號"

    '    Private Function MainMarkSCode(ByVal UseY As String) As Boolean
    '        Dim I, N As Int16
    '        Dim Obj As New Object
    '        Dim CurrNum As Int16 = 0
    '        Dim SqlStr As String = ""
    '        Dim StartCode As String = ""

    '        Dim PrintBar As New MainFrame.SysCheckData.SysMessageClass
    '        Dim CurrSBCode As New StringBuilder
    '        Dim LblTempCode As New StringBuilder
    '        Dim AxTempCode As New StringBuilder

    '        Try
    '            '打印前準備工作
    '            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
    '            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
    '            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)

    '            For I = 0 To ObjArrayNum - 1
    '                Obj = ObjArrayL.Item(I)
    '                If Obj.tag.ToString = "BarCode1" Then
    '                    If ObjAInfoTable.Rows(I).Item("ObjParent").ToString = "Hide" Then
    '                        AxTempCode.Append(Obj.text)
    '                    Else
    '                        LblTempCode.Append(Obj.text)
    '                    End If
    '                End If
    '            Next

    '            PrintStr.Remove(0, PrintStr.Length)
    '            ReDim PrintPart(2, 0)

    '            If UseY = "N" Then
    '                '測試打印條碼
    '                For I = 1 To LoadD.CurrPrintNum
    '                    '臨時數組
    '                    CurrNum += 1
    '                    N += 1
    '                    ReDim Preserve PrintPart(2, N)
    '                    PrintPart(1, N) = AxTempCode.ToString
    '                    PrintPart(2, N) = LblTempCode.ToString

    '                    '生成打印指令
    '                    If N = LoadD.PrintColNum Then
    '                        PrintBarCode(PrintPart, UseY)   '
    '                        ReDim PrintPart(2, 0)
    '                        N = 0
    '                    ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
    '                        PrintBarCode(PrintPart, UseY)
    '                        ReDim PrintPart(2, 0)
    '                        N = 0
    '                    End If
    '                Next
    '            Else
    '                '正式打印條碼
    '                For I = 1 To LoadD.CurrPrintNum
    '                    '檢查CurrSBcode是否已達最大值
    '                    If CurrSBCode.ToString = LoadD.EndSn.ToString Then
    '                        SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
    '                        MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                        Exit For
    '                    End If

    '                    '根據舊序號產生新序號
    '                    CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
    '                    If CurrSBCode.ToString = "" Then
    '                        SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
    '                        MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '                        Exit For
    '                    End If
    '                    '起始流水號
    '                    If I = 1 Then
    '                        StartCode = CurrSBCode.ToString
    '                    End If
    '                    '根據新序號產生新的條碼信息
    '                    AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
    '                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
    '                    AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
    '                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)

    '                    '臨時數組
    '                    CurrNum += 1
    '                    N += 1
    '                    ReDim Preserve PrintPart(2, N)
    '                    PrintPart(1, N) = AxTempCode.ToString
    '                    PrintPart(2, N) = LblTempCode.ToString
    '                    '生成打印指令
    '                    If N = LoadD.PrintColNum Then
    '                        PrintBarCode(PrintPart, UseY)   '
    '                        ReDim PrintPart(2, 0)
    '                        N = 0
    '                    ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
    '                        PrintBarCode(PrintPart, UseY)
    '                        ReDim PrintPart(2, 0)
    '                        N = 0
    '                    End If

    '                    '生成存儲Sql語句
    '                    SqlStr &= ControlChars.CrLf & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','S',1,'" & UseY & "','" & SysMessageClass.UseId.ToLower & "',getdate(),convert(varchar(10),getdate(),21))"

    '                    If I = LoadD.CurrPrintNum Then
    '                        LoadD.BarCodeStyleMax = CurrSBCode.ToString
    '                        LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
    '                        SqlStr &= ControlChars.CrLf & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'"
    '                        SqlStr &= ControlChars.CrLf & "update m_Mainmo_t set PpidPrtQty=isnull(PpidPrtQty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'"
    '                        SqlStr &= ControlChars.CrLf & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
    '                                             " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','S','" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "',convert(varchar(10),getdate(),21),'" & SysMessageClass.UseId.ToLower & "',getdate())"
    '                    End If
    '                Next
    '            End If

    '            For I = 0 To ObjArrayNum - 1
    '                Obj = ObjArrayL.Item(I)
    '                If Obj.tag = "LblY/N" Then
    '                    Obj.text = CurrNum & "/" & LoadD.CurrPrintNum
    '                ElseIf Obj.tag.ToString = "LblPNMax" AndAlso UseY = "Y" Then
    '                    Obj.text = LoadD.CurrMaxInt & " ( " & LoadD.BarCodeStyleMax & " )"
    '                ElseIf Obj.tag.ToString = "LblMoidNum" AndAlso UseY = "Y" Then
    '                    MoidPrinted += LoadD.CurrPrintNum
    '                    Obj.text = MoidPrinted
    '                End If
    '            Next
    '            '插入數據庫並傳送打印指令到打印機
    '            If SqlStr <> "" Then Conn.ExecSql(SqlStr)
    '            LoadM.OpenLock(LoadD.StyleID)
    '            If PrintStr.ToString <> "" Then PrintBar.PrintCodeBar(SysMessageClass.PrinterPort, PrintStr.ToString)

    '            Return True
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            LoadM.OpenLock(LoadD.StyleID)
    '        End Try
    '    End Function

    '    Private Function CheckCurrSBCode(ByVal N As String, ByVal UseY As String, ByVal CurrNum As Int16, ByVal CurrSBCode As String) As String
    '        Dim Sqlstr As String = ""

    '        If N > 0 Then
    '            PrintBarCode(PrintPart, UseY)  '生成打印指令
    '            ReDim PrintPart(2, 0)
    '            N = 0
    '        End If
    '        If Sqlstr <> "" Then
    '            LoadD.BarCodeStyleMax = CurrSBCode.ToString
    '            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
    '            Sqlstr &= ControlChars.CrLf & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'"
    '            Sqlstr &= ControlChars.CrLf & "update m_Mainmo_t set PpidPrtQty=isnull(PpidPrtQty,0) +" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'"
    '        End If

    '        Return Sqlstr
    '    End Function

    '#End Region

    '#Region "生成條碼打印字符串"

    '    Private Sub PrintBarCode(ByVal PrintPartTemp(,) As String, ByVal UseY As String)
    '        Dim I As Int16
    '        Dim Obj As New Object

    '        Try
    '            With PrtStrTable
    '                For I = 0 To .Rows.Count - 1
    '                    If .Rows(I).Item("Areaid").ToString <> "" Then     '需要與程序相連接的命令行
    '                        MarkPrint(PrintPartTemp, UseY, .Rows(I).Item("Areaid").ToString, .Rows(I).Item("Commands").ToString)
    '                    Else     '不需要與程序相連接的命令行
    '                        PrintStr.Append(ControlChars.CrLf)
    '                        PrintStr.Append(.Rows(I).Item("Commands").ToString)
    '                    End If
    '                Next
    '            End With
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Private Function MarkPrint(ByVal PrintPartTemp(,) As String, ByVal UseY As String, ByVal Areaid As String, ByVal CommandStr As String) As Boolean
    '        Dim Obj As New Object
    '        Dim I, J As Int16

    '        For J = 0 To ObjArrayNum - 1
    '            If ObjAInfoTable.Rows(J).Item("Areaid").ToString <> "" Then
    '                For I = 0 To PrintPartTemp.GetUpperBound(1) - 1
    '                    If Int(ObjAInfoTable.Rows(J).Item("Areaid").ToString) + I * 50 = Int(Areaid) Then
    '                        Obj = ObjArrayL(J)
    '                        PrintStr.Append(ControlChars.CrLf)

    '                        If Obj.tag.ToString = "BarCode1" Then
    '                            If ObjAInfoTable.Rows(J).Item("ObjParent").ToString = "Hide" Then
    '                                PrintStr.Append(CommandStr & PrintPartTemp(1, I + 1))
    '                            Else
    '                                PrintStr.Append(IIf(UseY = "Y", CommandStr & PrintPartTemp(2, I + 1), CommandStr & "This is test"))
    '                            End If
    '                            Return True
    '                        Else
    '                            PrintStr.Append(CommandStr & Obj.text.ToString)
    '                            Return True
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        Next
    '    End Function

    '#End Region

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    'Private Sub ToolSetRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSetRule.Click

    '    Dim I, J As Int16
    '    Dim t As Int16 = 0
    '    Dim Sqlstr As String = ""

    '    'Dim TempView As DataView
    '    Dim Flag As Boolean = False

    '    Try
    '        '檢查編碼原則
    '        If LoadM.CodeRule.Trim = "" Then
    '            MsgBox("請先選擇客戶和條碼編碼原則！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
    '            Exit Sub
    '        Else
    '            Sqlstr = "select * from m_SnRuleM_t where CodeRuleID='" & LoadM.CodeRule.Trim & "'"
    '            Using RecTable As SqlDataReader = Conn.GetDataReader(Trim(Sqlstr))
    '                If RecTable.Read Then
    '                    Select Case RecTable("LabelType").ToString
    '                        Case "S"
    '                            If LoadM.CheckCodeRule(LoadM.CodeRule.Trim) = True Then
    '                                Dim FrmCheckDigitPrt As New FrmCheckDigitPrt
    '                                FrmCheckDigitPrt.LoadM.CodeRule = LoadM.CodeRule
    '                                FrmCheckDigitPrt.LoadM.CustID = LoadM.CustID
    '                                FrmCheckDigitPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                FrmCheckDigitPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                                FrmCheckDigitPrt.LoadM.Taskid = LoadM.Taskid
    '                                FrmCheckDigitPrt.LoadM.Factory = LoadM.Factory '''''工廠別
    '                                FrmCheckDigitPrt.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
    '                                FrmCheckDigitPrt.LoadM.vShift = LoadM.vShift '''''班別
    '                                FrmCheckDigitPrt.ShowDialog()          '打印含有校驗位的條碼
    '                                FrmCheckDigitPrt.TopMost = True
    '                                Exit Sub
    '                            End If
    '                            If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "d" Then
    '                                Dim Frm2DPrt As New Frm2DPrt
    '                                Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                                Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                                Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                                Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                                Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                                Frm2DPrt.LoadM.Factory = LoadM.Factory '''''工廠別
    '                                Frm2DPrt.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
    '                                Frm2DPrt.LoadM.vShift = LoadM.vShift '''''班別
    '                                Frm2DPrt.LoadM.vLineJm = LoadM.vLineJm ''線別簡碼
    '                                Frm2DPrt.ShowDialog()          '打印2D標簽
    '                                Frm2DPrt.TopMost = True
    '                                Exit Sub
    '                            End If
    '                            If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "b" AndAlso Int(Microsoft.VisualBasic.Right(LoadM.CodeRule.Trim.ToLower, 3)) > 9 Then
    '                                If LoadM.CodeRule.Trim.ToUpper = "B021" Then
    '                                    'Dim FrmHeatPipe As New FrmHeatPipe
    '                                    'FrmHeatPipe.LoadM.CodeRule = LoadM.CodeRule
    '                                    'FrmHeatPipe.LoadM.CustID = LoadM.CustID
    '                                    'FrmHeatPipe.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                    'FrmHeatPipe.LoadM.DefaultLine = LoadM.DefaultLine
    '                                    'FrmHeatPipe.LoadM.Taskid = LoadM.Taskid
    '                                    'FrmHeatPipe.ShowDialog()          '打印熱管內部管控條碼
    '                                    'FrmHeatPipe.TopMost = True
    '                                    'Exit Sub
    '                                Else
    '                                    Dim Frm2DPrt As New Frm2DPrt
    '                                    Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                                    Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                                    Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                    Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                                    Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                                    Frm2DPrt.LoadM.Factory = LoadM.Factory '''''工廠別
    '                                    Frm2DPrt.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
    '                                    Frm2DPrt.LoadM.vShift = LoadM.vShift '''''班別
    '                                    Frm2DPrt.LoadM.vLineJm = LoadM.vLineJm ''線別簡碼
    '                                    Frm2DPrt.ShowDialog()          '打印2D標簽
    '                                    Frm2DPrt.TopMost = True
    '                                    Exit Sub
    '                                End If
    '                            End If
    '                        Case "C"
    '                            Dim strCodeRule As String = LoadM.CodeRule.Trim.ToLower
    '                            'If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "c" AndAlso Int(Microsoft.VisualBasic.Right(LoadM.CodeRule.Trim.ToLower, 3)) > 2 Then
    '                            If Microsoft.VisualBasic.Left(strCodeRule, 1) = "c" AndAlso Int(Microsoft.VisualBasic.Right(strCodeRule, 3)) > 2 Then
    '                                Dim FrmCartonV2 As New FrmCartonV2
    '                                FrmCartonV2.LoadM.CodeRule = LoadM.CodeRule
    '                                FrmCartonV2.LoadM.CustID = LoadM.CustID
    '                                FrmCartonV2.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                FrmCartonV2.LoadM.DefaultLine = LoadM.DefaultLine
    '                                FrmCartonV2.LoadM.Taskid = LoadM.Taskid
    '                                FrmCartonV2.LoadM.Factory = LoadM.Factory '''''工廠別
    '                                FrmCartonV2.LoadM.DeptJm = LoadM.DeptJm ''''部門簡碼
    '                                FrmCartonV2.LoadM.vShift = LoadM.vShift '''''班別
    '                                FrmCartonV2.LoadM.vLineJm = LoadM.vLineJm ''線別簡碼
    '                                FrmCartonV2.ShowDialog()          '新版外箱標簽打印程序
    '                                FrmCartonV2.TopMost = True
    '                                Exit Sub
    '                                'Else
    '                                'Dim FrmCarton As New FrmCarton
    '                                'FrmCarton.LoadM.CodeRule = LoadM.CodeRule
    '                                'FrmCarton.LoadM.CustID = LoadM.CustID
    '                                'FrmCarton.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                'FrmCarton.LoadM.DefaultLine = LoadM.DefaultLine
    '                                'FrmCarton.LoadM.Taskid = LoadM.Taskid
    '                                'FrmCarton.ShowDialog()          '舊版外箱標簽打印程序
    '                                'FrmCarton.TopMost = True
    '                                'Exit Sub
    '                            End If
    '                        Case "N"
    '                            'If LoadM.CodeRule.Trim.ToUpper = "N003" Then
    '                            '    Dim FrmLEDpkg As New FrmLEDpkg
    '                            '    FrmLEDpkg.LoadM.CodeRule = LoadM.CodeRule
    '                            '    FrmLEDpkg.LoadM.CustID = LoadM.CustID
    '                            '    FrmLEDpkg.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                            '    FrmLEDpkg.LoadM.DefaultLine = LoadM.DefaultLine
    '                            '    FrmLEDpkg.LoadM.Taskid = LoadM.Taskid
    '                            '    FrmLEDpkg.ShowDialog()          '打印LED箱標簽
    '                            '    FrmLEDpkg.TopMost = True
    '                            '    Exit Sub
    '                            'Else
    '                            'Dim FrmNoSerial As New FrmNoSerial
    '                            'FrmNoSerial.LoadM.CodeRule = LoadM.CodeRule
    '                            'FrmNoSerial.LoadM.CustID = LoadM.CustID
    '                            'FrmNoSerial.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                            'FrmNoSerial.LoadM.DefaultLine = LoadM.DefaultLine
    '                            'FrmNoSerial.LoadM.Taskid = LoadM.Taskid
    '                            'FrmNoSerial.ShowDialog()          '打印無流水號條碼
    '                            'FrmNoSerial.TopMost = True
    '                            Exit Sub
    '                            'End If
    '                        Case "P"
    '                            If Microsoft.VisualBasic.Left(LoadM.CodeRule.Trim.ToLower, 1) = "p" Then
    '                                Dim Frm2DPrt As New Frm2DPrt
    '                                Frm2DPrt.LoadM.CodeRule = LoadM.CodeRule
    '                                Frm2DPrt.LoadM.CustID = LoadM.CustID
    '                                Frm2DPrt.LoadM.DefaultMoid = LoadM.DefaultMoid
    '                                Frm2DPrt.LoadM.DefaultLine = LoadM.DefaultLine
    '                                Frm2DPrt.LoadM.Taskid = LoadM.Taskid
    '                                Frm2DPrt.ShowDialog()          '打印棧板標簽
    '                                Frm2DPrt.TopMost = True
    '                                Exit Sub
    '                            End If
    '                    End Select
    '                End If
    '            End Using

    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
    '        Exit Sub
    '    End Try

    '    '建立條碼組成部分並分別賦初值
    '    Try
    '        Sqlstr = "select distinct a.F_codeID,d.ShortName from m_SnRuleD_t as a left join (select b.F_codeid,c.ShortName from m_SnSet_t as b join m_SnSet_t as c " & _
    '                "on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule & "' group by b.F_codeid,c.ShortName having count(b.f_codeid)=1) as d " & _
    '                "on  a.F_codeid=d.F_codeid where a.CodeRuleID = '" & LoadM.CodeRule & "' AND a.F_codeID NOT IN ('M', 'Y')"
    '        Using RecTable As SqlDataReader = Conn.GetDataReader(Trim(Sqlstr))
    '            ReDim BarCodePart(4, 0)
    '            BarCodePartNum = 0
    '            While RecTable.Read
    '                BarCodePartNum += 1
    '                ReDim Preserve BarCodePart(4, BarCodePartNum)
    '                BarCodePart(1, BarCodePartNum) = RecTable("F_codeID").ToString    '條碼組成部分的馬元
    '                BarCodePart(2, BarCodePartNum) = RecTable("ShortName").ToString   '條碼組成部分中的編碼原則設定值
    '                BarCodePart(4, BarCodePartNum) = 1
    '            End While
    '        End Using

    '        Sqlstr = "select F_codeID,F_codestart,F_codelen,SplitChar from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule.Trim & "' order by F_orderid asc"
    '        Using TempView As DataView = Conn.GetDataTable(Trim(Sqlstr)).DefaultView
    '            For I = 1 To BarCodePartNum
    '                Select Case BarCodePart(1, I)
    '                    Case "S"
    '                        If Flag = False Then
    '                            TempView.RowFilter = "F_codeID='S'"
    '                            TempView.Sort = "F_codestart ASC"
    '                            BarCodePart(2, I) = StrDup(TempView.Count, "S")    '產生重復的字符串函數
    '                            BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString  '條碼分割符
    '                            Flag = True
    '                        End If
    '                    Case "D"
    '                        TempView.RowFilter = "F_codeID='Y' or F_codeID='M' OR F_codeID='D'"
    '                        TempView.Sort = "F_codestart ASC"
    '                        For J = 1 To TempView.Count
    '                            t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
    '                        Next
    '                        BarCodePart(2, I) = StrDup(t, "#")
    '                        BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
    '                    Case "W"
    '                        TempView.RowFilter = "F_codeID='Y' or F_codeID='W'"
    '                        TempView.Sort = "F_codestart ASC"
    '                        For J = 1 To TempView.Count
    '                            t += CInt(TempView.Item(J - 1).Item("F_codelen").ToString.Trim)
    '                        Next
    '                        BarCodePart(2, I) = StrDup(t, "#")
    '                        BarCodePart(3, I) = TempView.Item(TempView.Count - 1).Item("SplitChar").ToString
    '                    Case Else
    '                        TempView.RowFilter = "F_codeID='" & BarCodePart(1, I) & "'"
    '                        If BarCodePart(2, I) <> "" Then
    '                        Else
    '                            BarCodePart(2, I) = StrDup(CInt(TempView.Item(0).Item("F_codelen").ToString.Trim), "#")
    '                        End If
    '                        BarCodePart(3, I) = TempView.Item(0).Item("SplitChar").ToString
    '                End Select
    '            Next
    '        End Using
    '        BuildBar()
    '    Catch ex As Exception
    '        ReDim BarCodePart(4, 0)
    '        BarCodePartNum = 0
    '        SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarM", "BnBulidBarCode_Click", "sys")
    '    End Try

    'End Sub

    Private Sub ToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFind.Click
        LoadPrintRecord()
    End Sub

    Private Sub FrmA20Prt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CboMoid.Text = LoadM.DefaultMoid
        'Me.CboMoid.Enabled = False
        'Me.CobLine.Text = LoadM.DefaultLine
        'CobLine.Enabled = False
        Dim sql As String = " select Moid from m_Mainmo_t where FinalY ='N'"
        CboMoid.Items.Clear()
        Dim CheckRead As SqlDataReader = Conn.GetDataReader(sql)
        If CheckRead.HasRows Then
            While CheckRead.Read
                CboMoid.Items.Add(CheckRead!Moid)
            End While
        End If
        CheckRead.Close()
        CobQty.SelectedIndex = 0
        CobIsPrint.SelectedIndex = 0
        CobCodeBurningResult.SelectedIndex = 0
        CobTestResult.SelectedIndex = 0
        'LoadPrintRecord()
    End Sub
    Private Sub LoadPrintRecord()

        Dim SqlStr As String = ""
        Dim Moid As String = ""
        Dim LineID As String = ""
        Dim SN As String = ""
        Dim PN As String = ""
        Dim strwhere As String = ""
        If CboMoid.Text <> "" AndAlso CboMoid.Text <> "ALL" Then
            strwhere = strwhere + " and b.Moid='" & CboMoid.Text & "'"
        End If
        If Me.CobLine.Text <> "" AndAlso CobLine.Text <> "ALL" Then
            strwhere = strwhere + " and b.Lineid='" & CobLine.Text & "'"
        End If
        If Me.CobSN.Text <> "" AndAlso CobSN.Text <> "ALL" Then
            strwhere = strwhere + " and a.SN='" & CobSN.Text & "'"
        End If
        If Me.CobPN.Text <> "" AndAlso CobPN.Text <> "ALL" Then
            strwhere = strwhere + " and a.PN='" & CobPN.Text & "'"
        End If
        If Me.CobIsPrint.Text <> "" AndAlso CobIsPrint.Text <> "ALL" Then
            strwhere = strwhere + " and a.IsPrint='" & CobIsPrint.Text.Split("-")(0) & "'"
        End If
        If Me.CobTestResult.Text <> "" AndAlso CobTestResult.Text <> "ALL" Then
            strwhere = strwhere + " and a.TestResult='" & CobTestResult.Text.Split("-")(0) & "' "
        End If
        If Me.CobCodeBurningResult.Text <> "" AndAlso CobCodeBurningResult.Text <> "ALL" Then
            strwhere = strwhere + " and a.CodeBurningResult='" & CobCodeBurningResult.Text.Split("-")(0) & "' "
        End If
        Dim sql As String = "select a.[SN] N'SN编号',a.[PN] N'PN编号',[IMEI] N'IMEI编号',[TestResult] N'测试结果',[CodeBurningResult] N'烧入结果',[IsPrint] N'打印结果',b.Moid N'工单',b.Lineid N'线别',b.Intime N'打印时间',b.Userid N'操作人',[EMAC],[WMAC],TID,a.ID from dbo.m_A20Box_t a left join m_SnSBarCode_t b on a.SN =b.SBarCode   where  (1=1) " & strwhere
        Dim dt As DataTable = Conn.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            ToolLblCount.Text = dt.Rows.Count.ToString
        End If
        DgCodeRule.DataSource = dt
        'DgCodeRule.Refresh()
    End Sub


    Private Sub BnBulidBarCode_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnBulidBarCode.Click

        Dim Moid As String = ""
        Dim LineID As String = ""
        Dim Qty As Integer = 0
        If CboMoid.Text <> "" AndAlso CboMoid.Text <> "ALL" Then
            Moid = CboMoid.Text
        Else
            MessageBox.Show("工单不能为空")
            CboMoid.Focus()
            Exit Sub
        End If
        If Me.CobLine.Text <> "" AndAlso CobLine.Text <> "ALL" Then
            LineID = CobLine.Text
        Else
            MessageBox.Show("线别不能为空")
            CobLine.Focus()
            Exit Sub
        End If
        If Me.CobQty.Text <> "" AndAlso CobQty.Text <> "ALL" Then
            Qty = CInt(CobQty.Text)
        Else
            Qty = 0
        End If
        'If Qty = 0 Then
        '    MessageBox.Show("没有可以导入的条码数据")
        '    Exit Sub
        'End If
        Dim sql As String = String.Format(" DECLARE @result int exec m_SetA20Print_p '{0}','{1}',{2},'{3}',@result = @result OUTPUT SELECT	@result as N'result'", Moid, LineID, Qty, SysMessageClass.UseId)
        Try
            ' Conn.ExecSql(sql)
            Dim rev As Integer = 0
            Dim RecDr As SqlDataReader = Conn.GetDataReader(sql)
            If RecDr.HasRows Then
                RecDr.Read()
                rev = RecDr.GetInt32(0)
                RecDr.Close()
            End If
            If rev >= 0 Then
                MessageBox.Show("导入成功" & rev.ToString & "条数据")
                LoadPrintRecord()
            Else
                MessageBox.Show("导入失败,返回值-1")
            End If
        Catch ex As Exception
            MessageBox.Show("导入失败" & ex.ToString)
        End Try
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        Dim i As Integer = 0
        If ChkAll.Checked Then
            For i = 0 To DgCodeRule.Rows.Count - 1
                DgCodeRule.Rows(i).Cells("chkid").Value = True
            Next
        Else
            For i = 0 To DgCodeRule.Rows.Count - 1
                DgCodeRule.Rows(i).Cells("chkid").Value = False
            Next
        End If
    End Sub

    Private Sub CboMoid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoid.SelectedIndexChanged
        Dim Moid As String = ""
        If CboMoid.Text <> "" AndAlso CboMoid.Text <> "ALL" Then
            Moid = CboMoid.Text
            Dim sql As String = "select distinct Lineid  from m_Mainmo_t where FinalY='N' and Moid='" & Moid & "'"
            CobLine.Items.Clear()
            Dim CheckRead As SqlDataReader = Conn.GetDataReader(sql)
            If CheckRead.HasRows Then
                While CheckRead.Read
                    CobLine.Items.Add(CheckRead!Lineid)
                End While
            End If
            CheckRead.Close()
        End If

    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(DgCodeRule, "外部条码明细")
    End Sub
    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

   
End Class


