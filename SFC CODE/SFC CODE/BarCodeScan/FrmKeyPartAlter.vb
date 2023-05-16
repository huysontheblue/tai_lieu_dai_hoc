Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient

Public Class FrmKeyPartAlter

    Dim Conn As New SysDataBaseClass
    Dim count As Long
    Dim formtype As String = ""

    Private isEnd As Boolean = False

    Private Sub TextBox_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtinput.MouseClick

        If isEnd = False Then
            txtinput.Text = ""
            txtinput.SelectionStart = 0
            isEnd = True
        End If

    End Sub


    Private Sub ToolStar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStar.Click

        Me.Txtpartid.Enabled = True
        Me.Txtpartid.Focus()
        Me.ButSet.Enabled = True
        ToolCancel.Enabled = True
        ToolStar.Enabled = False

    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click


        Me.Close()

    End Sub

    Private Sub ButSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSet.Click

        If Txtpartid.SelectedIndex = -1 Then
            LblMsg.Text = "请选择要作业的料件编号..."
            Exit Sub
        End If
        Me.txtinput.Enabled = True
        Me.txtinput.Focus()
        Me.ButSet.Enabled = False
        Me.Txtpartid.Enabled = False

    End Sub

    Private Sub FrmPartTranc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim PubClass As New SysDataBaseClass
        Dim CheckRead As SqlDataReader
        'CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m0710q_' and a.userid='" & SysMessageClass.UseId & "'")
        'If Not CheckRead.Read Then
        '    Me.Butdelete.Enabled = False
        '    Me.Toolcomfire.Enabled = False
        'Else
        '    Me.Butdelete.Enabled = True
        '    Me.Toolcomfire.Enabled = True
        'End If
        'CheckRead.Close()


        CheckRead = PubClass.GetDataReader("select PartCode,TAvcPart from  m_PartContrast_t where IsAlter='Y'")
        If CheckRead.HasRows Then
            While CheckRead.Read
                Txtpartid.Items.Add(CheckRead!PartCode & "-" & CheckRead!TAvcPart)
            End While
        End If
        CheckRead.Close()

        'formtype = VbCommClass.VbCommClass.vFormType

        'CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m031d_' and a.userid='" & SysMessageClass.UseId & "'")
        'If Not CheckRead.Read Then
        '    Me.Toolcomfire.Enabled = False
        'Else
        '    Me.Toolcomfire.Enabled = True
        'End If
        'CheckRead.Close()
        count = 0
        ''Q、IQC
        ''I、入库
        ''O、领料出库
        ''B、退料
        ''C、报废
        'If formtype = "Q" Then
        '    Me.Text = "关键物料IQC进料检验"
        '    Me.CobType.Items.Add("QA-关键物料IQC进料检验")
        'End If
        'If formtype = "I" Then
        '    Me.Text = "关键物料入库作业"
        '    Me.CobType.Items.Add("IA-半成品入库")
        '    Me.CobType.Items.Add("IB-原材料入库")
        'End If
        'If formtype = "O" Then
        '    Me.Text = "关键物料出库作业"
        '    Me.CobType.Items.Add("OA-半成品领料出库")
        '    Me.CobType.Items.Add("0B-原材料领料出库")
        'End If
        'If formtype = "B" Then
        '    Me.Text = "关键物料退库作业"
        '    Me.CobType.Items.Add("BA-半成品入库")
        '    Me.CobType.Items.Add("BB-原材料退库")
        'End If
        'Me.Text = "P03 Barcode Check Program" & "(" & Application.ProductVersion & ")"
        '********************************************************************************************20140223ouxiangfeng***************
        'Dim sqlStr As String = "select (SortID + '-'+SortName +'-' + SortDesc) as SortID from m_UserRight_t a" & _
        '" join  m_logtree_t b on a.tkey=b.tkey " & _
        '" join m_Sortset_t c on b.ButtonID=c.SortID and SortTypeName='KeyPart' where a.UserID='L031976' and a.Tkey like 'm0710%' and len(a.tkey)=7 and c.usey='Y'"
        'Dim mRead As SqlDataReader = Conn.GetDataReader(sqlStr)
        'If mRead.HasRows Then
        '    While mRead.Read
        '        CobType.Items.Add(mRead!SortID.ToString)
        '    End While
        'End If
        'mRead.Close()
        'Conn.PubConnection.Close()
        '********************************************************************************************20140223ouxiangfeng***************
        Dim sqlStr As String = "SELECT   SortID, SortName FROM m_Sortset_t WHERE SortType = 'AlterType' and Usey='Y' order by Orderid"
        Dim mRead As SqlDataReader = Conn.GetDataReader(sqlStr)
        If mRead.HasRows Then
            While mRead.Read
                CobType.Items.Add(mRead!SortID.ToString & "-" & mRead!SortName.ToString)
                ' CobType.Items.Add(mRead!SortName.ToString)
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()


        txtbagbarcode.Enabled = False
        txtcablebarcode.Enabled = False
        mRead = Conn.GetDataReader("select SortID from m_Sortset_t where SortType='E75Type' and Usey='Y' order by Orderid")
        If mRead.HasRows Then
            While mRead.Read
                cmbstage.Items.Add(mRead!SortID.ToString)
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()
        'cmbstage.Items.Add("pPR")
        'cmbstage.Items.Add("PRO")
        'cmbstage.Items.Add("pEV")
        'cmbstage.Items.Add("EVT")
        'cmbstage.Items.Add("DVT")
        'cmbstage.Items.Add("PVT")
        cmbstage.SelectedIndex = 0
        txtinput.Select()
        txtinput.SelectAll()
        'LblMsg.BackColor = Color.Gray

    End Sub

    ''Private Sub txtinput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinput.TextChanged


    ''    If Me.CobType.Text = "" Then
    ''        txtinput.Text = ""
    ''        txtinput.Clear()
    ''        txtinput.Focus()
    ''        LblMsg.Text = "请选择作业类型..."
    ''        Exit Sub
    ''    End If
    ''    Dim sqlstr As String
    ''    LblMsg.Text = ""
    ''    LblMsg.Refresh()
    ''    Dim Inputstr As String = ""
    ''    Inputstr = txtinput.Text & Inputstr
    ''    'LblMsg.BackColor = Color.Gray
    ''    If Microsoft.VisualBasic.Right(txtinput.Text, 1) = vbLf Then
    ''        count = count + 1
    ''    End If
    ''    If count >= 6 Then
    ''        count = 0
    ''        If InStr(LCase(txtinput.Text), "module serial number") < 1 Then
    ''            txtinput.Text = ""
    ''            txtinput.Clear()
    ''            txtinput.Focus()
    ''            LblMsg.Text = "Module SN读取出错，请重新读取..."
    ''            Exit Sub
    ''        End If
    ''        txtmsn.Text = Mid(txtinput.Lines(4), 33, 17)
    ''        txtmsn.Refresh()
    ''        'txtinput.Text = "" '''''txtmsn
    ''        If (Len(txtmsn.Text) <> Len(txtMSNrule.Text)) And (Microsoft.VisualBasic.Left(txtmsn.Text, 3) <> Microsoft.VisualBasic.Left(txtMSNrule.Text, 3)) Then
    ''            LblMsg.Text = "Module SN编码原则样式不正确..."
    ''            txtinput.Select()
    ''            txtinput.SelectAll()
    ''            Exit Sub
    ''        End If
    ''        Dim state As String = ""
    ''        Dim mRead As SqlDataReader = Conn.GetDataReader("select top 1 isnull([type],'') stateid from m_KeyPartTranc_t where ppid='" & txtmsn.Text & "' and stateid='Y'")
    ''        If mRead.HasRows Then
    ''            While mRead.Read
    ''                state = mRead!stateid.ToString
    ''            End While
    ''        End If
    ''        mRead.Close()
    ''        Conn.PubConnection.Close()

    ''        'A(IQC来料检验)
    ''        'B(原材料入库)
    ''        'C(原材料出库)
    ''        'D(原材料实验室领料)
    ''        'E(半成品入库)
    ''        'G(半成品出库)
    ''        'H(半成品实验室领料)
    ''        'J(原材料退库)
    ''        'K(半成品退库)
    ''        'L(成品入库)
    ''        'P(成品重工出库)
    ''        'Q(成品实验室领料)
    ''        'T(报废)
    ''        'W(成品出货)
    ''        formtype = Microsoft.VisualBasic.Left(CobType.Text, 1)
    ''        If Chk.Checked = True Then
    ''            formtype = "T"
    ''        End If
    ''        If state = "" And formtype <> "A" Then
    ''            LblMsg.Text = "该产品序号未经过IQC检验,不允许其它操作.."
    ''            txtinput.Clear()
    ''            Exit Sub
    ''        End If
    ''        If formtype = "A" Then
    ''            If state <> "" Then
    ''                LblMsg.Text = "该产品序号已经过IQC检验,不允许重复作业.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If
    ''        If state = "W" Then
    ''            LblMsg.Text = "该产品序号已出货给客户,不允许其它操作.."
    ''            txtinput.Clear()
    ''            Exit Sub
    ''        End If
    ''        If state = "T" Then
    ''            LblMsg.Text = "该产品序号已报废,不允许其它操作.."
    ''            txtinput.Clear()
    ''            Exit Sub
    ''        End If
    ''        If formtype = "B" Then
    ''            If state <> "A" Then
    ''                LblMsg.Text = "该产品序号不在IQC检验状态,不允许原材料入库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If
    ''        If formtype = "C" Or formtype = "D" Then
    ''            If state <> "B" Then
    ''                LblMsg.Text = "该产品序号不在原材料仓,不能进行原材料出库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If
    ''        If formtype = "E" Then
    ''            If state <> "C" AndAlso state <> "D" Then
    ''                LblMsg.Text = "该产品序号不在生产线上,不能进行半成品入库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If
    ''        If formtype = "G" Or formtype = "H" Then
    ''            If state <> "E" AndAlso state <> "K" Then
    ''                LblMsg.Text = "该产品序号不在半成品仓,不能进行半成品出库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If

    ''        If formtype = "J" Or formtype = "K" Then
    ''            If state <> "G" AndAlso state <> "H" Then
    ''                LblMsg.Text = "该产品序号不在生产线上,不能进行半成品入库或退库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If

    ''        If formtype = "L" Then
    ''            If state <> "C" AndAlso state <> "G" AndAlso state <> "D" AndAlso state <> "H" AndAlso state <> "P" Then
    ''                LblMsg.Text = "该产品序号不在生产线上,不能进行成品入库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If

    ''        If formtype = "P" Or formtype = "Q" Then
    ''            If state <> "L" Then
    ''                LblMsg.Text = "该产品序号不在成品仓,不能进行成品出库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If

    ''        If formtype = "W" Then
    ''            If state <> "L" Then
    ''                LblMsg.Text = "该产品在成品仓中不存在,不能进行半成品出库.."
    ''                txtinput.Clear()
    ''                Exit Sub
    ''            End If
    ''        End If
    ''        'A(IQC来料检验)
    ''        'B(原材料入库)
    ''        'C(原材料出库)
    ''        'D(原材料实验室领料)
    ''        'E(半成品入库)
    ''        'G(半成品出库)
    ''        'H(半成品实验室领料)
    ''        'J(原材料退库)
    ''        'K(半成品退库)
    ''        'L(成品入库)
    ''        'P(成品重工出库)
    ''        'Q(成品实验室领料)
    ''        'T(报废)
    ''        'W(成品出货)

    ''        sqlstr = "update m_KeyPartTranc_t set stateid='N' where [ppid]='" & txtmsn.Text & "'"
    ''        sqlstr = sqlstr & vbNewLine & " INSERT INTO [MESDB].[dbo].[m_KeyPartTranc_t]([ppid],[partid],[property],[stateid],[type],[stationid],[userid],[intime]) " & _
    ''       "VALUES('" & txtmsn.Text & "','" & Txtpartid.Text.Trim & "','" & txtinput.Text & "','Y','" & formtype & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

    ''        Conn.ExecSql(sqlstr)
    ''        Conn.PubConnection.Close()
    ''        DGMainTain.Rows.Add(Txtpartid.Text, txtmsn.Text, Inputstr, formtype, My.Computer.Name, SysMessageClass.UseId, Now.Date)
    ''        txtinput.Enabled = True
    ''        LblMsg.Text = "Module芯片序号读取成功..."
    ''        LblQty.Text = CInt(LblQty.Text) + 1
    ''        txtinput.Clear()
    ''        txtinput.Focus()
    ''        'LblMsg.Refresh()
    ''        ''txtbagbarcode.Text = ""
    ''        ''txtcablebarcode.Text = ""
    ''        ''txtbagbarcode.Enabled = True
    ''        ''txtbagbarcode.Select()
    ''        ''txtbagbarcode.SelectAll()
    ''        ''LblMsg.Text = "Please Scan Bag Barcode"
    ''        'LblMsg.Refresh()
    ''    End If

    ''End Sub

    Private Sub cmbstage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstage.SelectedIndexChanged

        txtbarcoderule.Text = "DLCFF9Q" & cmbstage.Text & "*******"

    End Sub

    Private Sub txtbagbarcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbagbarcode.KeyDown

        If e.KeyCode = Keys.Return Then
            txtbagbarcode.Text = Microsoft.VisualBasic.Left(txtbagbarcode.Text, 17)
            If Len(txtbagbarcode.Text) < 17 Or Microsoft.VisualBasic.Left(txtbagbarcode.Text, 10) <> Microsoft.VisualBasic.Left(txtbarcoderule.Text, 10) Then ' Or Val(Microsoft.VisualBasic.Right(txtbagbarcode.Text, 4)) < 0 Or Val(Microsoft.VisualBasic.Right(txtbagbarcode.Text, 4)) > 9999 
                LblMsg.Text = "Bag Barcode Error"
                LblMsg.Refresh()
                txtbagbarcode.Select()
                txtbagbarcode.SelectAll()
                Exit Sub
            Else
                txtbagbarcode.Enabled = False
                LblMsg.Text = "Bag Barcode Checked"
                LblMsg.Refresh()
                txtcablebarcode.Enabled = True
                txtcablebarcode.Select()
                txtcablebarcode.SelectAll()
            End If
        End If

    End Sub

    'Private Sub txtcablebarcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcablebarcode.KeyDown

    '    If e.KeyCode = Keys.Return Then
    '        Call ReadE75SnHanle()
    '    End If

    'End Sub

    'Private Sub ReadE75SnHanle()


    '    If Chk.Checked = True Then
    '        formtype = "C"
    '    End If
    '    If formtype = "" Then
    '        LblMsg.Text = "窗体类型参数未传递，请重开窗体.."
    '        Exit Sub
    '    End If
    '    Dim sqlstr As String
    '    If Len(txtcablebarcode.Text) < 17 Or Microsoft.VisualBasic.Left(txtcablebarcode.Text, 10) <> Microsoft.VisualBasic.Left(txtbarcoderule.Text, 10) Or txtcablebarcode.Text <> txtbagbarcode.Text Then ' Or Val(Microsoft.VisualBasic.Right(txtbagbarcode.Text, 4)) < 0 Or Val(Microsoft.VisualBasic.Right(txtbagbarcode.Text, 4)) > 9999 
    '        LblMsg.Text = "Cable Barcode Error"
    '        'LblMsg.Refresh()
    '        txtcablebarcode.Select()
    '        txtcablebarcode.SelectAll()
    '        Exit Sub
    '    Else
    '        Dim state As String = ""
    '        Dim mRead As SqlDataReader = Conn.GetDataReader("select top 1 stateid from m_KeyPartTranc_t where ppid='" & txtcablebarcode.Text & "' order by itemid desc")
    '        If mRead.HasRows Then
    '            While mRead.Read
    '                state = mRead!stateid.ToString
    '            End While
    '        End If
    '        mRead.Close()
    '        If state = "C" Then
    '            LblMsg.Text = "该产品序号已报废,不能再使用.."
    '            Exit Sub
    '        End If
    '        If state = formtype Then
    '            LblMsg.Text = "该产品序号已读取过,不能重复读取.."
    '            Exit Sub
    '        End If
    '        If state = "" And formtype <> "Q" Then
    '            LblMsg.Text = "该产品序号未经过IQC检验,不允许其它操作.."
    '            Exit Sub
    '        End If
    '        If state <> "Q" And formtype = "I" Then
    '            LblMsg.Text = "该产品序号未经过IQC检验,不允许入库.."
    '            Exit Sub
    '        End If
    '        If (state <> "I" And formtype = "O") Or (state <> "B" And formtype = "O") Then
    '            LblMsg.Text = "该产品序号未经过入库,不允许领料出库.."
    '            Exit Sub
    '        End If
    '        If state <> "O" And formtype = "B" Then
    '            LblMsg.Text = "该产品序号未经过出库,不允许退料.."
    '            Exit Sub
    '        End If
    '        txtcablebarcode.Text = Microsoft.VisualBasic.Left(txtcablebarcode.Text, 17)
    '        txtcablebarcode.Enabled = False
    '        LblMsg.Text = "Cable Barcode Checked"
    '        LblMsg.Refresh()
    '        txtinput.Enabled = True
    '        'LblMsg.BackColor = Color.Green
    '        LblMsg.Text = "PASSED"
    '        LblMsg.Refresh()
    '        txtcablebarcode.Refresh()
    '        txtinput.Text = ""
    '        txtinput.Refresh()
    '        Dim date1, time1 As String
    '        date1 = DateString
    '        time1 = TimeString
    '        ''Q、IQC
    '        ''I、入库
    '        ''O、领料出库
    '        ''B、退料
    '        ''C、报废
    '        sqlstr = " INSERT INTO [MESDB].[dbo].[m_KeyPartTranc_t]([ppid],[partid],[property],[type],[stateid],[stationid],[userid],[intime]) " & _
    '        "VALUES('" & txtcablebarcode.Text & "','" & Txtpartid.Text.Trim & "','" & txtinput.Text.Trim & "','" & Me.CobType.SelectedText.Split("-")(0).ToString & "','" & formtype & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

    '        Conn.ExecSql(sqlstr)
    '        LblQty.Text = CInt(LblQty.Text) + 1
    '        System.Threading.Thread.Sleep(3000)
    '        txtinput.Select()
    '        txtinput.SelectAll()
    '        txtmsn.Text = ""
    '        txtbagbarcode.Text = ""
    '        txtcablebarcode.Text = ""
    '        LblMsg.Text = ""
    '        'LblMsg.BackColor = Color.Gray
    '        LblMsg.Text = "Wait for plugging DUT"
    '        LblMsg.Refresh()
    '    End If
    'End Sub

    Private Sub Toolcomfire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolcomfire.Click

        Me.Chk.Enabled = True
        Me.TxtMark.Enabled = True
        Me.Txtbarcode.Enabled = True
        'Me.Butdelete.Enabled = True

    End Sub

    Private Sub Butdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butdelete.Click

        If Me.Txtbarcode.Text.Trim = "" Then
            LblMsg.Text = "作废产品序号时，产品序号不能为空..."
            Exit Sub
        End If
        If Me.TxtMark.Text.Trim = "" Then
            LblMsg.Text = "作废产品序号时，备注不能为空，不能为空.."
            Exit Sub
        End If
        Dim state As String = ""
        Dim mRead As SqlDataReader = Conn.GetDataReader("select top 1 [Type] Typea from m_KeyPartTranc_t where ppid='" & Txtbarcode.Text & "'  order by itemid desc")
        If mRead.HasRows Then
            While mRead.Read
                state = mRead!Typea.ToString
            End While
        End If
        mRead.Close()
        If state = "T" Then
            LblMsg.Text = "该产品序号已报废,不能再报废.."
            Exit Sub
        End If
        Try
            Dim sqlstr As String = "update m_KeyPartTranc_t set stateid='N' where [ppid]='" & Txtbarcode.Text & "'"
            sqlstr = sqlstr & vbNewLine & " INSERT INTO [MESDB].[dbo].[m_KeyPartTranc_t]([ppid],[partid],[property],[stateid],[Type],[stationid],[userid],[intime],mark) " & _
             "VALUES('" & Txtbarcode.Text & "','" & Txtpartid.Text.Trim & "','" & txtinput.Text.Trim & "','Y','T','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate(),N'" & TxtMark.Text & "')"

            Conn.ExecSql(sqlstr)
            LblQty.Text = CInt(LblQty.Text) + 1
            Conn.PubConnection.Close()
            DGMainTain.Rows.Add(Txtpartid.Text, Txtbarcode.Text, "", "T-报废", My.Computer.Name, SysMessageClass.UseId, Now.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try


    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click

        ToolCancel.Enabled = False
        ToolStar.Enabled = True
        Me.txtinput.Clear()
        Me.txtinput.Enabled = False
        Txtpartid.SelectedIndex = -1
        Txtpartid.Enabled = False
        ButSet.Enabled = False


    End Sub


    Private Sub txtinput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinput.KeyPress

        If e.KeyChar = Chr(13) Then
            StandScan()
        End If

    End Sub

    Private Sub StandScan()

        Dim ReadSn As String = ""
        Dim BarCode As String = ""
        'Dim CurreState As String = ""

        If Me.CobType.Text = "" Then
            txtinput.Text = ""
            txtinput.Clear()
            txtinput.Focus()
            LblMsg.Text = "请选择作业类型..."
            isEnd = False
            Exit Sub
        End If

       

        Dim CurrState As String = ""
        Dim mSqlstr = "SELECT  isnull([type],'') as currType FROM m_KeyPartAlter_t WHERE stateid='Y' and ppid='" & txtinput.Text.Trim & "'"
        Dim mRead As SqlDataReader = Conn.GetDataReader(mSqlstr)
        If mRead.HasRows Then
            While mRead.Read
                CurrState = mRead!currType.ToString.Trim
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()

       
       


        If RadPPID.Checked Then
            If CobType.Text.Split("-")(0) = "delivery" Then
                If CurrState <> "Warehous" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须为完成成品入库状态的产品，才允许仓库出货扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If
            If CobType.Text.Split("-")(0) = "Goodsfactory" Then
                If CurrState <> "delivery" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须为完成成品出货状态的产品，才允许货物出厂..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If CobType.Text.Split("-")(0) = "MaterialOutlab" Then
                If CurrState <> "" Then
                    If CurrState.ToString.ToString = "Materialstroage" Or CurrState <> "MaterialOutlab" Then
                    Else
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料必须为在在库状态，才允许仓库原材料实验室出库扫描..."
                        isEnd = False
                        Exit Sub
                    End If

                End If
            End If

            If CobType.Text.Split("-")(0) = "MaterialInlab" Then
                If CurrState <> "MaterialOutlab" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "原材料必须为实验室领料状态，才允许实验室原材料入库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If


            If CobType.Text.Split("-")(0) = "MaterialOut" Then
                If CurrState <> "" Then
                    If CurrState.ToString.ToString = "Materialstroage" And CurrState <> "MaterialOutlab" Then
                    Else
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料必须为在在库状态，才允许仓库原材料出库扫描..."
                        isEnd = False
                        Exit Sub
                    End If

                End If
            End If
            If CobType.Text.Split("-")(0) = "Materialstroage" Then
                If CurrState <> "MaterialOut" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "原材料必须为生产领料状态，才允许原材料入库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If CobType.Text.Split("-")(0) = "MaterialToA5" Then
                Select Case CurrState
                    Case "MaterialToA5" '代码已经在出过库了                       
                        LblMsg.Text = "物料\成品 " + txtinput.Text + " 已经扫描出库。."
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        isEnd = False
                        Exit Sub
                    Case "MaterialA5Out" '代码已经在A5出过货了
                        LblMsg.Text = "物料\成品 " + txtinput.Text + " 已经在A5扫描出货。"
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        isEnd = False
                        Exit Sub
                End Select

                
            End If
            If CobType.Text.Split("-")(0) = "MaterialA5Out" Then
                If CurrState <> "MaterialToA5" Then
                    LblMsg.Text = "物料\成品 " + txtinput.Text + " 必须为出库状态才允许扫描出货..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If
            End If

        Else

        End If
        Dim CurrStation As String = ""
        If CobType.Text.Split("-")(0) = "Warehous" Then
            If RadPPID.Checked Then
                mRead = Conn.GetDataReader("select top 1 Stationid from m_ppidlink_t where ppid='" & txtinput.Text & "' order by intime desc")
                If mRead.HasRows Then
                    While mRead.Read
                        CurrStation = mRead!Stationid
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                If CurrStation <> "P00001" And CurrStation <> "A00004" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须产线生产包装完成的产品，才允许进行入库作业..."
                    isEnd = False
                    Exit Sub
                End If
            Else
                mRead = Conn.GetDataReader("select CartonStatus from m_Carton_t where Cartonid='" & txtinput.Text & " '")
                If mRead.HasRows = False Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "该外箱并没有进行外箱包装扫描，不允许进行入库作业..."
                    isEnd = False
                    mRead.Close()
                    Conn.PubConnection.Close()
                    Exit Sub
                End If
                mRead.Close()
                Conn.PubConnection.Close()
            End If

        End If

        mSqlstr = " update m_KeyPartAlter_t set stateid='N' where ppid='" & txtinput.Text & "'"
        mSqlstr = mSqlstr & vbNewLine & " insert into m_KeyPartAlter_t(ppid,partid,[type],[stationid],stateid,userid,intime,mark)" & _
          "values('" & txtinput.Text & "','" & Txtpartid.Text & "','" & CobType.Text.Split("-")(0) & "','" & My.Computer.Name & "','Y'," & _
          "'" & SysMessageClass.UseId & "',getdate(),N'" & TxtMark.Text & "')"
        Try
            Conn.ExecSql(mSqlstr)
            isEnd = False
            LblMsg.Text = "产品序号" + txtinput.Text + "扫描成功..."
            LblQty.Text = CInt(LblQty.Text) + 1
            DGMainTain.Rows.Add(txtinput.Text, CobType.Text.Split("-")(1), SysMessageClass.UseId, Now.Date)
            DGMainTain.AutoResizeColumns()
            txtinput.Clear()
            txtinput.Focus()
        Catch ex As Exception
            LblMsg.Text = "产品序号" + txtinput.Text + "扫描失败..."
        End Try

        'DGMainTain.Rows.Add(Txtpartid.Text, txtmsn.Text, Inputstr, formtype, My.Computer.Name, SysMessageClass.UseId, Now.Date)
        'txtinput.Enabled = True


    End Sub

End Class