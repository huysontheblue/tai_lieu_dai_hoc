''功能：設置包裝站掃描資料
''開發人員：歐翔烽
''開發日期：2009/08/04

Imports System.Data.SqlClient
Imports System.Text
Imports BarCodePrint
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmPackCartonSet

    Dim Conn As New SysDataBaseClass
    Dim TimeStr As String
    Dim BcRule As String
    Dim TimeStyleSet As String
    Dim Datet As New DateTime
    Dim standNo As String
    Dim standIndex As String
    Dim standname As String

    Dim multiboxStr As String
    ''Dim multiqtyStr As String

    Private Sub FrmBarCodeScanSet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboMoid.KeyPress, CboSupport.KeyPress, DtpDate.KeyPress, DtpSet.KeyPress

        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
            Exit Sub
        End If
        If sender.name.ToString = "CboMoid" Then
            CboMoid.DroppedDown = True
            If (Char.IsLower(e.KeyChar)) Then
                CboMoid.SelectedText = Char.ToUpper(e.KeyChar).ToString()
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub FrmBarCodeScanSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "BnConFrm" Then CartonScanOption.IsExitFlag = True
        ''Conn = Nothing

    End Sub

    Private Sub FrmBarCodeScanSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecTable As New DataTable
        Dim Sqlstr As String= ""
        Dim Pubclass As New SysDataBaseClass
        CartonScanOption.LastPrintQty = Nothing  '
        If Not CartonScanOption.PackNumber Is Nothing Then
            CartonScanOption.PackNumber = Nothing
        End If
        Sqlstr = "select getdate() as Datet"
        RecTable = Pubclass.GetDataTable(Sqlstr)
        Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
        RecTable.Dispose()
        Me.DtpDate.Value = Datet.ToString
        Me.DtpTime.Value = Datet.ToString
        DtpSet.Value = Datet.ToString

        'SELECT A.Cusid,B.CusName  FROM
        '(SELECT DISTINCT Cusid FROM m_Mainmo_t WHERE ISNULL(Cusid,'')<>''
        'UNION
        'SELECT DISTINCT Cusid FROM m_PartContrast_t WHERE ISNULL(Cusid,'')<>'') A
        'INNER JOIN m_Customer_t B ON A.Cusid=B.CusID
        'ORDER BY A.Cusid
        Sqlstr = _
                "SELECT A.Cusid, B.CusName" + vbCrLf + _
                "  FROM (SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_Mainmo_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''" + vbCrLf + _
                "        UNION" + vbCrLf + _
                "        SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_PartContrast_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> '') A" + vbCrLf + _
                "       INNER JOIN m_Customer_t B ON A.Cusid = B.CusID" + vbCrLf + _
                "ORDER BY A.Cusid"
        '"select * from m_Customer_t where usey='Y' and  cusid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='c0_' and userid='" & SysMessageClass.UseId & "')"
        LoadDataToCob(Sqlstr, CboSupport) ''填充客戶
        If Not CartonScanOption.MoidStr Is Nothing Then
            InitScanSetFrom()
        End If

    End Sub

    Private Sub InitScanSetFrom() ''重復設置時保存上一次的設置記錄

        CboSupport.Text = CartonScanOption.CustIdString
        CboMoid.Text = CartonScanOption.MoidStr
        Me.CobLine.Text = CartonScanOption.LineStr
        Me.DtpSet.Value = CartonScanOption.TimeStr
        Me.CobPalletStyle.Text = CartonScanOption.vMultQtyStr

    End Sub

#Region "校驗設置是否完整或正確"
    Private Function ContorlCheck() As Boolean
        ''
        Dim Sqlstr As String
        Dim Pubclass As New SysDataBaseClass
        Dim RecTable As SqlDataReader

        If Me.CboSupport.Text.Trim = "" Then
            MessageBox.Show("客戶名稱不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboSupport.Focus()
            CboSupport.SelectAll()
            Return False
            Exit Function
        End If
        If Me.CboMoid.Text.Trim = "" Then
            MessageBox.Show("工單編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboMoid.Focus()
            CboMoid.SelectAll()
            Return False
            Exit Function
        End If
        If Me.CobPalletStyle.Text = "" Then
            MessageBox.Show("棧板裝箱方式不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobPalletStyle.Focus()
            CobPalletStyle.SelectAll()
            Return False
            Exit Function
        End If
        If Me.TxtAvcPart.Text = "" Then
            MessageBox.Show("資料未設置完整或工單不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        Sqlstr = "select   c.staorderid,c.scanorderid,c.stationid,c.stationname from m_PartPack_t a inner join m_Mainmo_t b on a.partid=b.partid join (select a.staorderid,a.scanorderid,b.stationname,a.stationid,a.ppartid,a.state from m_RPartStationD_t a join m_Rstation_t b on a.stationid=b.stationid where stationtype='P') c on a.partid=c.ppartid where a.usey='Y' and a.packid='C' and c.state='1'  and  b.moid='" & CboMoid.Text.Trim & "'"
        RecTable = Pubclass.GetDataReader(Sqlstr)
        If Not RecTable.Read Then
            MessageBox.Show("該料號包裝資料未設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RecTable.Close()
            Return False
            Exit Function
        Else
            standNo = RecTable!stationid
            standIndex = RecTable!staorderid
            standname = RecTable!stationname
        End If
        If RecTable.IsClosed = False Then RecTable.Close()
        'If Me.LblLine.Text.Trim = "" Then
        '    MessageBox.Show("該工單未設置線別" & vbNewLine & "請在終端站點維護中新增線別資料", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        If CobLine.Text = "" Then

        End If
        'If CartonScanOption.LineStr Is Nothing Or CartonScanOption.LineStr = "" Then
        If Me.CobLine.Text.Trim = "" Then
            MessageBox.Show("該工單未設置線別資料", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If -30 > DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) OrElse DateDiff(DateInterval.Day, Datet, Me.DtpSet.Value) > 30 Then
            MessageBox.Show("設置的時間不得偏離當前時間一個月!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        Else
            TimeStyleSet = Format(Me.DtpSet.Value, "yyyy/MM/dd")
        End If
        TimeStr = Format(Me.DtpDate.Value, "yyyy/MM/dd")
        TimeStr = TimeStr + " " + Format(Me.DtpTime.Value, "HH:mm:ss")
        If TimeStr > Format(Datet, "yyyy/MM/dd HH:mm:ss") Then
            MessageBox.Show("您選擇的開始時間大於當前時間!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        ' Sqlstr = "select a.Cartonid,b.qty from M_Carton_t a inner join m_SnSBarCode_t b on a.Cartonid=b.sbarcode where a.Moid='" & Me.CboMoid.Text.Trim & "' and a.Teamid='" & Me.LblLine.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
        Sqlstr = "select a.Cartonid,b.qty from M_Carton_t a inner join m_SnSBarCode_t b on a.Cartonid=b.sbarcode where a.Moid='" & Me.CboMoid.Text.Trim & "' and a.Teamid='" & Me.CobLine.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
        RecTable = Pubclass.GetDataReader(Sqlstr)
        While RecTable.Read()
            CartonScanOption.PackNumber = RecTable.Item("Cartonid").ToString
            CartonScanOption.LastPrintQty = RecTable.Item("qty").ToString
            If CartonScanOption.PackNumber = "" Then
                MessageBox.Show("存在外箱編號為空的情況", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                RecTable.Close()
                Return False
                Exit Function
            End If
        End While
        RecTable.Close()
        Return True

    End Function
#End Region
#Region "Cbo客戶選擇事件"

    Private Sub CboSupport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSupport.SelectedIndexChanged
        ''填充客戶對應工單．未結案工單,並清空
        LoadDataToCboMoid("SELECT Moid FROM  m_Mainmo_t where cusid='" & Mid(CboSupport.Text, 1, InStr(CboSupport.Text, "(") - 1) & "' and finaly='N' order by moid", CboMoid)
        ClearLabelControl() '清空相關label

    End Sub

    Private Sub ClearLabelControl() '清空相關label

        For Each text As Control In GbMessage.Controls
            If TypeOf text Is ULControls.textBoxUL Then
                text.Text = ""
            End If
        Next

    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox) ''加載客戶到對應的下拉框中

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        While PubDataReader.Read
            CobName.Items.Add(PubDataReader("cusid") & "(" & PubDataReader("cusname") & ")")
        End While
        PubDataReader.Close()
        PubClass = Nothing

    End Sub

#End Region

#Region "Cbo工單選擇事件"

    Private Sub CboMoid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMoid.LostFocus
        CboMoid_SelectedIndexChanged(sender, e)
    End Sub
    ''依工單load基本資料
    Private Sub CboMoid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoid.SelectedIndexChanged

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader = Nothing
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        ClearLabelControl() '清空相關label
        LblMoType.Text = ""
        Dim reMoldFlag As String = String.Empty
        If Me.CboMoid.Text <> "" Then
            Try
                SqlStr = "select a.deptid,a.Factory,b.djc,a.moqty,isnull(c.motype,'') motype,a.partid,a.lineid,d.custpart,f.flen,f.coderuleid,isnull(j.ChangeY,'') ChangeY,g.multibox,g.multiqty ,g.qty,g.multiy from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid left join M_Requestm_t j on a.moid=j.moid left join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid join (select multibox,multiqty ,qty,multiy,partid from m_PartPack_t where packid='C' and usey='Y' and multiy='Y') g on a.partid=g.partid where e.packid='S'and a.moid='" & Trim(Me.CboMoid.Text) & "' and e.usey='Y'"
                PubDataReader = PubClass.GetDataReader(SqlStr)
                If PubDataReader.HasRows Then
                    While PubDataReader.Read
                        CartonScanOption.LineStr = PubDataReader("lineid").ToString
                        CartonScanOption.DpetId = PubDataReader("deptid").ToString
                        Me.TxtDeptName.Text = PubDataReader("djc").ToString
                        Me.TxtMoQty.Text = PubDataReader("moqty").ToString
                        Me.TxtMoType.Text = PubDataReader("motype").ToString
                        Me.TxtAvcPart.Text = PubDataReader("partid").ToString
                        Me.TxtCustomerPart.Text = PubDataReader("custpart").ToString
                        factoryidstr = PubDataReader("Factory").ToString
                        Me.TxtBarcodeLen.Text = PubDataReader("flen").ToString
                        BcRule = PubDataReader("coderuleid").ToString
                        CartonScanOption.BcRuleid = BcRule
                        ''LblMoType.Text = PubDataReader("motype").ToString
                        ''reMoldFlag = PubDataReader("ChangeY").ToString
                        LblMoType.Text = PubDataReader("ChangeY").ToString
                        ''multiboxStr = PubDataReader!multibox
                        CobPalletStyle.Items.Clear()
                        If UCase(PubDataReader!multiy.ToString) = "Y" Then
                            Dim multStr() As String = PubDataReader!multiqty.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(";")
                            For i As Integer = 0 To multStr.Length - 1
                                CobPalletStyle.Items.Add(multStr(i).ToString)
                            Next
                        Else
                            Me.CobPalletStyle.Items.Add(PubDataReader!qty)
                        End If
                    End While
                    PubDataReader.Close()
                    If reMoldFlag = "1" Then
                        MessageBox.Show("該重工工單的重工方式為更換外箱和主條碼,不能進行包裝掃描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    SqlStr = "select lineid from Deptline_t where deptid='" & CartonScanOption.DpetId & "' and usey='Y' and factoryid='" & factoryidstr & "' order by lineid"
                    PubDataReader = PubClass.GetDataReader(SqlStr)
                    Me.CobLine.Items.Clear()
                    While PubDataReader.Read
                        Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
                    End While
                    CobLine.Text = CartonScanOption.LineStr
                    PubDataReader.Close()
                    PubClass = Nothing
                Else
                    PubDataReader.Close()
                End If

            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "CboMoid_SelectedIndexChanged", "sys")
                PubDataReader.Close()
                PubClass = Nothing
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub LoadDataToCboMoid(ByVal SqlStr As String, ByVal CobName As ComboBox)
        ''根據選擇客戶Load對應的未結案工單
        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        While PubDataReader.Read
            CobName.Items.Add(PubDataReader("moid"))
        End While
        PubDataReader.Close()
        PubClass = Nothing

    End Sub

#End Region



    '設置確定按鈕.
    Private Sub BnConFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnConFrm.Click

        Dim Dr As SqlDataReader = Nothing
        Dim PubClass As New SysDataBaseClass
        Dim SqlStr As String
        '' Dim PalletFlag As Boolean = True

        If ContorlCheck() = True Then
            Try
                SqlStr = "declare @SnStyle1 varchar(50),@SnStyle2 varchar(50),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_P '" & Trim(Me.TxtAvcPart.Text) & "','" & BcRule & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"
                Dr = PubClass.GetDataReader(SqlStr)
                While Dr.Read()
                    CartonScanOption.SnStyleStr1 = Dr.GetString(1)
                    CartonScanOption.SnStyleStr2 = Dr.GetString(0)
                    CartonScanOption.GflenStr = Dr.GetString(2)
                End While
                If Trim(CartonScanOption.SnStyleStr2).Length <> CType(Trim(Me.TxtBarcodeLen.Text), Integer) Then
                    Dr.Close()
                    MessageBox.Show("該料號打印參數未設置或未確認!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dr.Close()

                SqlStr = "select * from m_PalletM_t where Moid='" & Me.CboMoid.Text & "' and  Teamid ='" & Me.CobLine.Text & "' and PalletStatus = 'N'"
                Dr = PubClass.GetDataReader(SqlStr)
                If Dr.HasRows Then
                    While Dr.Read
                        CartonScanOption.vCurrentPalletCartonCount = Dr!MultiBox
                        CartonScanOption.vCurrentPalletCartonIndex = Dr!Palletqty
                        CartonScanOption.vPalletNo = Dr!Palletid
                        CartonScanOption.vPalletMultQty = Dr!MultiQty.ToString.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(",")
                        CartonScanOption.vMultQtyStr = Dr!MultiQty.ToString
                        CartonScanOption.vNoFullFlag = True
                        ''CartonScanOption.PackNumber = CartonScanOption.MoidStr & CartonScanOption.vPalletNo & Dr!Palletqty
                        '' PalletFlag = False
                    End While
                Else
                    CartonScanOption.vNoFullFlag = False
                    CartonScanOption.vPalletNo = Nothing
                End If
                Dr.Close()
                'If PalletFlag Then
                'SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & Me.TxtAvcPart.Text.Trim & " '  and usey='Y'"
                'Dr = PubClass.GetDataReader(SqlStr)
                'If Dr.Read Then
                ''If LCase(Dr("coderuleid")) = "c001" Then
                ''    CartonScanOption.PartPackQty = Microsoft.VisualBasic.Right(StrDup(3, "0") & IIf(UCase(Dr!Multiy.ToString) = "N", Dr("Qty").ToString, Dr("MultiQty").ToString), 3)
                ''Else
                ''    CartonScanOption.PartPackQty = IIf(UCase(Dr!Multiy.ToString) = "N", Dr("Qty").ToString, Dr("MultiQty").ToString)
                ''End If
                ''If UCase(Dr!multiy.ToString) = "Y" Then
                Dim multStr() As String = Me.CobPalletStyle.Text.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(",")

                CartonScanOption.vNormalPalletCartonCount = multStr.Length
                CartonScanOption.vNormalPalletMultQty = Me.CobPalletStyle.Text.ToString.Split(",")
                'Else
                'CartonScanOption.vNormalPalletCartonCount = Dr!MultiBox
                'CartonScanOption.vNormalPalletMultQty = Dr!MultiQty.ToString.Split(",")
                ''Else
                'CartonScanOption.vNormalPalletCartonCount = Dr!qty
                'CartonScanOption.vNormalPalletMultQty = Dr!qty.ToString.Split(",")
                'End If
                'End If
                'Dr.Close()
                'End If
                LoadControlInData() ''Load控件里的數據到對象里。
                Me.Close()
            Catch ex As Exception
                If Dr.IsClosed = False Then Dr.Close()
                SysMessageClass.WriteErrLog(ex, Me.Name, "BnConFrm_Click", "sys")
                Exit Sub
            End Try
        End If

    End Sub

    ''#Region "生成棧板編號"

    ''    Private Function GeneratePalletNo() ''生成棧板編號，工單+線別+流水號(4位)

    ''        Dim palletNoStr As String = String.Empty
    ''        Dim cnn As New MainFrame.SysDataHandle.SysDataBaseClass
    ''        Dim palletReader As SqlDataReader = cnn.GetDataReader("select isnull(max(Palletid),'') maxpallno from m_PalletM_t where Moid='" & Me.CboMoid.Text & "' and Teamid='" & Me.CobLine.Text & "'")
    ''        If palletReader.HasRows Then
    ''            While palletReader.Read
    ''                If palletReader!maxpallno = "" Then
    ''                    palletNoStr = CartonScanOption.MoidStr + CartonScanOption.LineStr + "0001"
    ''                Else
    ''                    palletNoStr = Replace(palletReader!maxpallno, CboMoid.Text & CobLine.Text, "1")
    ''                    palletNoStr = CboMoid.Text & CobLine.Text & (palletNoStr + 1).ToString.Substring(1)
    ''                End If
    ''            End While
    ''        End If
    ''        palletReader.Close()
    ''        Return palletNoStr

    ''    End Function

    ''#End Region

    Private Sub LoadControlInData() ''Load控件里的數據到對象里。

        CartonScanOption.MoidStr = CboMoid.Text
        CartonScanOption.MoidqtyStr = Me.TxtMoQty.Text
        CartonScanOption.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
        CartonScanOption.PartidStr = Me.TxtAvcPart.Text
        CartonScanOption.MoCustStr = Me.TxtCustomerPart.Text
        CartonScanOption.DpetNameStr = Me.TxtDeptName.Text
        CartonScanOption.LineStr = Me.CobLine.Text
        CartonScanOption.LengthStr = Me.TxtBarcodeLen.Text
        CartonScanOption.TimeStr = TimeStr
        CartonScanOption.PrintPort = SysMessageClass.PrinterPort
        CartonScanOption.CustIdString = CboSupport.Text.Trim
        CartonScanOption.vCartonSitNo = standNo
        CartonScanOption.vStandIndex = standIndex
        CartonScanOption.vCartonSitName = standname
        CartonScanOption.vIsLastPallet = False
        CartonScanOption.IsExitFlag = False
        CartonScanOption.TimeStr = Me.DtpSet.Value
        CartonScanOption.moType = Me.LblMoType.Text

    End Sub

    Private Sub DtpTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpTime.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnConFrm
            BnConFrm_Click(sender, e)
        End If

    End Sub

    Private Sub CobLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobLine.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            CobPalletStyle.Focus()
        End If

    End Sub

    Private Sub CboMoid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMoid.TextChanged

        ClearLabelControl()
        CobLine.Items.Clear()
        LblMoType.Text = ""
        Me.CobLine.Items.Clear()
        Me.CobLine.Text = ""

    End Sub

    Private Sub CobPalletStyle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobPalletStyle.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            DtpSet.Focus()
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CartonScanOption.IsExitFlag = True
        CartonScanOption.CheckStr = False
        ''Conn = Nothing
        Me.Close()
    End Sub
End Class