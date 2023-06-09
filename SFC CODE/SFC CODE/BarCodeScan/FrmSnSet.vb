Imports System.Data.SqlClient
Imports System.Text
Imports BarCodePrint
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmSnSet

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim TimeStr As String
    Dim BcRule As String
    Dim TimeStyleSet As String
    'Const FourCol As Integer = 5
    Const ColZero As Integer = 0
    Dim Datet As New DateTime

    Private Sub FrmSnSet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboMoid.KeyPress, CboSupport.KeyPress, DtpDate.KeyPress, DtpSet.KeyPress

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

    Private Sub CboMoid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMoid.LostFocus
        CboMoid_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub FrmSnSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl Is Nothing Then Data.IsExitFlag = True

    End Sub

    Private Sub FrmSnSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim RecTable As New DataTable
        Dim Sqlstr As String=""
        Dim Pubclass As New SysDataBaseClass

        'CboPort.Text = CboPort.Items.Item(ColZero)
        LblLine.Text = ""
        Sqlstr = "select getdate() as Datet"
        RecTable = Pubclass.GetDataTable(Sqlstr)
        Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
        RecTable.Dispose()

        Me.DtpDate.Value = Datet.ToString
        Me.DtpTime.Value = Datet.ToString
        DtpSet.Value = Datet.ToString

        Sqlstr = _
                "SELECT A.Cusid, B.CusName" + vbCrLf + _
                "  FROM (SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_Mainmo_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''" + vbCrLf + _
                "        UNION" + vbCrLf + _
                "        SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_PartContrast_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> '') A" + vbCrLf + _
                "       INNER JOIN m_Customer_t B" + vbCrLf + _
                "          ON     A.Cusid = B.CusID" + vbCrLf + _
                "             AND A.cusid IN (SELECT buttonid" + vbCrLf + _
                "                               FROM m_UserRight_t a" + vbCrLf + _
                "                                    INNER JOIN m_Logtree_t b" + vbCrLf + _
                "                                       ON a.tkey = b.tkey" + vbCrLf + _
                "                              WHERE b.tparent = 'c0_' AND userid = '" & SysMessageClass.UseId & "')"

        LoadDataToCob(Sqlstr, CboSupport) '填充客戶
        ' LoadDataToCob("select * from m_Customer_t where usey='Y' and  cusid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='c0_' and userid='" & SysMessageClass.UseId & "')", CboSupport) ''填充客戶

    End Sub

    Private Function ContorlCheck() As Boolean '''' lrq   2007/01/10 ''''

        If Me.CboSupport.Text = "" Then
            MessageBox.Show("客戶名稱不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboSupport.Focus()
            CboSupport.SelectAll()
            Return False
            Exit Function
        End If

        If Me.CboMoid.Text = "" Then
            MessageBox.Show("工單編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboMoid.Focus()
            CboMoid.SelectAll()
            Return False
            Exit Function
        End If

        If Me.LabPartid.Text = "" Then
            MessageBox.Show("資料未設置完整或工單編號不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If Me.LblLine.Text = "" Then
            MessageBox.Show("該工單未設置線別,請在工單維護中維護線別", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If -30 > DateDiff(DateInterval.Day, Now, Me.DtpSet.Value) OrElse DateDiff(DateInterval.Day, Now, Me.DtpSet.Value) > 30 Then
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
        Return True

    End Function

#Region "Cbo客戶選擇事件"

    Private Sub CboSupport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSupport.SelectedIndexChanged
        ''填充客戶對應工單．未結案工單
        LoadDataToCboMoid("SELECT Moid FROM  m_Mainmo_t where cusid='" & Mid(CboSupport.Text, 1, InStr(CboSupport.Text, "(") - 1) & "' and finaly='N' order by moid", CboMoid)
        LabDept.Text = ""
        LabMoqty.Text = ""
        LabMtype.Text = ""
        LabPartid.Text = ""
        LabCust.Text = ""
        LabSnLen.Text = ""
        LblLine.Text = ""
        'CboLine.Items.Clear()

    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0) & "(" & PubDataReader.GetString(1) & ")")
            End While
        End If
        PubDataReader.Close()
        PubClass = Nothing
    End Sub

#End Region

#Region "Cbo工單選擇事件"
    ''依工單load基本資料
    Private Sub CboMoid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoid.SelectedIndexChanged

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        LabDept.Text = ""
        LabMoqty.Text = ""
        LabMtype.Text = ""
        LabPartid.Text = ""
        LabCust.Text = ""
        LabSnLen.Text = ""
        If Me.CboMoid.Text <> "" Then
            Try
                ''If LCase(Data.FormName) = "frmpackpartscan" Then
                ''    SqlStr = "select a.deptid,b.djc,a.moqty,c.motype,a.partid,d.custpart,f.flen,f.coderuleid,a.lineid from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='C'and a.moid='" & Trim(Me.CboMoid.Text) & "' and e.usey='Y'"
                ''Else
                SqlStr = "select a.deptid,b.djc,a.moqty,c.motype,a.partid,d.custpart,f.flen,f.coderuleid,a.lineid from m_Mainmo_t a inner join m_Dept_t b on a.deptid=b.deptid  join motype_t c on a.typeid=c.typeid join m_PartContrast_t d on a.partid=d.tavcpart join m_PartPack_t e on e.partid=a.partid join M_SnRuleM_t f on e.coderuleid=f.coderuleid where e.packid='S'and a.moid='" & Trim(Me.CboMoid.Text) & "' and e.usey='Y'"
                ''End If
                PubDataReader = PubClass.GetDataReader(SqlStr)
                If PubDataReader.HasRows Then
                    While PubDataReader.Read()
                        DeptStr = PubDataReader("deptid").ToString
                        Data.DpetId = PubDataReader("deptid").ToString
                        LabDept.Text = PubDataReader("djc").ToString
                        LabMoqty.Text = PubDataReader("moqty").ToString
                        LabMtype.Text = PubDataReader("motype").ToString
                        LabPartid.Text = PubDataReader("partid").ToString
                        LabCust.Text = PubDataReader("custpart").ToString
                        LabSnLen.Text = PubDataReader("flen").ToString
                        BcRule = PubDataReader("coderuleid").ToString
                        LblLine.Text = PubDataReader("lineid").ToString
                        Data.BcRuleid = BcRule
                    End While
                End If
                PubDataReader.Close()


                PubDataReader = PubClass.GetDataReader("select lineid from Deptline_t where   usey='Y' order by lineid")
                CobLine.Items.Clear()
                If PubDataReader.HasRows Then
                    While PubDataReader.Read
                        Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
                    End While
                End If
                PubDataReader.Close()
                PubClass = Nothing
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "CboMoid_SelectedIndexChanged", "sys")
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub LoadDataToCboMoid(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0))
            End While
        End If
        PubDataReader.Close()
        PubClass = Nothing

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Data.IsExitFlag = True
        Data.SnStyleStr1 = Nothing
        Data.SnStyleStr2 = Nothing
        Data.GflenStr = Nothing
        Data.CheckStr = False
        Me.Close()

    End Sub

    '設置確定按鈕.

    Private Sub BnConFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnConFrm.Click

        Dim Mread As SqlDataReader = Conn.GetDataReader("select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " & _
  " where b.tparent in('z09_','z0s_','z0t_') and userid='" & SysMessageClass.UseId & "' and ButtonID='" & CobLine.Text & "'")
        If Mread.HasRows = False Then
            MessageBox.Show("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mread.Close()
            Exit Sub
        End If
        Mread.Close()

        '' lrq   2007/01/10 ''''
        Dim Dr As SqlDataReader
        Dim PubClass As New SysDataBaseClass
        Dim SqlStr As String
        Dr = Nothing

        If ContorlCheck() = True Then
            Try
                If Data.ShowStyle = 1 Then
                    SqlStr = "declare @SnStyle1 varchar(50),@SnStyle2 varchar(50),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShowfox_p '" & Trim(LabPartid.Text) & "','" & BcRule & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"
                Else
                    SqlStr = "declare @SnStyle1 varchar(50),@SnStyle2 varchar(50),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' execute m_StyleShow_P '" & Trim(LabPartid.Text) & "','" & BcRule & "','" & TimeStyleSet & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"
                End If
                Dr = PubClass.GetDataReader(SqlStr)
                If Dr.HasRows Then
                    While Dr.Read()
                        Data.SnStyleStr1 = Dr.GetString(1)
                        Data.SnStyleStr2 = Dr.GetString(0)
                        Data.GflenStr = Dr.GetString(2)
                    End While
                End If
                '''''''' 2007/05/11''''''''''''''''''''''''''
                If Trim(Data.SnStyleStr2).Length <> CType(Trim(LabSnLen.Text), Integer) And BcRule <> "B021" Then
                    Dr.Close()
                    MessageBox.Show("该料件编码的资料未确认或设置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''

            Catch ex As Exception
                Dr.Close()
                SysMessageClass.WriteErrLog(ex, Me.Name, "BnConFrm_Click", "sys")
                Exit Sub
            End Try
            Dr.Close()
            ' '' SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & LabPartid.Text.Trim & "' "
            ' '''''''''''''''''''''''''''''''''''''2007/05/28  ''''''''''''''''''
            'SqlStr = "select Qty from m_PartPack_t where packid='C' and partid='" & LabPartid.Text.Trim & " '  and usey='Y' "
            ' '''''''''''''''''''''''''''''''''''''2007/05/28  ''''''''''''''''''
            'Dr = PubClass.GetDataReader(SqlStr)
            'If Dr.Read Then
            '    Data.PartPackQty = Int(Dr("Qty").ToString)
            'End If
            'Dr.Close()
            'If LCase(Data.FormName) = "frmscanhandle" Then
            '    SqlStr = "select Cartonid from M_Carton_t where Moid='" & Me.CboMoid.Text.Trim & "' and Teamid='" & Me.LblLine.Text.Trim & "' and CartonStatus='N' order by Intime desc"
            '    Dr = PubClass.GetDataReader(SqlStr)
            '    If Dr.HasRows Then
            '        Dr.Read()
            '        If MsgBox("這條綫有未裝滿的箱[" & Dr.Item("Cartonid").ToString & "]，是否要使用舊箱號？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "系統提示") = MsgBoxResult.Yes Then
            '            Data.PackNumber = Dr.Item("Cartonid").ToString
            '            Dr.Close()
            '        Else
            '            Dr.Close()
            '            Dim RecTable As New DataTable
            '            Dim DateT As New DateTime
            '            RecTable = Conn.GetDataTable("select getdate() as nowtime")
            '            DateT = CDate(RecTable.Rows(0).Item("nowtime").ToString).Date
            '            RecTable.Dispose()

            '            Dim MoBarCode As New PrintJLabel
            '            Dim b() As String
            '            ReDim b(6)
            '            b(1) = DateT.ToString("MM")
            '            b(2) = Data.DpetId
            '            b(3) = DateT.ToString("yyyy-MM-dd")
            '            b(4) = Me.LblLine.Text.Trim
            '            b(5) = Data.PartPackQty
            '            b(6) = Me.CboMoid.Text
            '            If MoBarCode.MarkJLabel(b, "Y") Then
            '                Data.PackNumber = MoBarCode.JLabelStr
            '            End If
            '            MoBarCode = Nothing
            '        End If
            '    Else
            '        Dr.Close()
            '        Dim RecTable As New DataTable
            '        Dim DateT As New DateTime
            '        RecTable = Conn.GetDataTable("select getdate() as nowtime")
            '        DateT = CDate(RecTable.Rows(0).Item("nowtime").ToString).Date
            '        RecTable.Dispose()

            '        Dim MoBarCode As New PrintJLabel
            '        Dim b() As String
            '        ReDim b(6)
            '        b(1) = DateT.ToString("MM")
            '        b(2) = Data.DpetId
            '        b(3) = DateT.ToString("yyyy-MM-dd")
            '        b(4) = Me.LblLine.Text.Trim
            '        b(5) = Data.PartPackQty
            '        b(6) = Me.CboMoid.Text
            '        If MoBarCode.MarkJLabel(b, "Y") Then
            '            Data.PackNumber = MoBarCode.JLabelStr
            '        End If
            '        MoBarCode = Nothing
            '    End If
            'End If
            ''If Data.PackNumber Is Nothing Then
            ''    MessageBox.Show("該料號未進行包裝設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''    Exit Sub
            ''End If
            Data.MoidStr = CboMoid.Text
            Data.MoidqtyStr = LabMoqty.Text
            Data.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
            Data.PartidStr = LabPartid.Text
            Data.MoCustStr = Me.LabCust.Text
            Data.DpetNameStr = LabDept.Text
            Data.LineStr = CobLine.Text
            Data.LengthStr = LabSnLen.Text
            Data.TimeStr = TimeStr
            Data.PrintPort = SysMessageClass.PrinterPort
            Data.IsExitFlag = False
            Me.Close()
        End If

    End Sub

    Private Sub DtpTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpTime.KeyPress

        If e.KeyChar = Chr(13) Then
            BnConFrm_Click(sender, e)
        End If

    End Sub

    Private Sub CboMoid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMoid.TextChanged
        LabDept.Text = ""
        LabMoqty.Text = ""
        LabMtype.Text = ""
        LabPartid.Text = ""
        LabCust.Text = ""
        LabSnLen.Text = ""
        LblLine.Text = ""
    End Sub
End Class