Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.IO

Public Class FrmKeyPartAlter

    Dim Conn As New SysDataBaseClass
    Dim count As Long
    Dim formtype As String = ""

    Private isEnd As Boolean = False

    Private Sub TextBox_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtinput.MouseClick

        'If isEnd = False Then
        '    txtinput.Text = ""
        '    txtinput.SelectionStart = 0
        '    isEnd = True
        'End If

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
        ToolExcel.Enabled = True
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


        CheckRead = PubClass.GetDataReader("select PartCode=REPLACE(REPLACE(PartCode,'B263','P07'),'B237','P06'),TAvcPart from  m_PartContrast_t where IsAlter='Y'")
        If CheckRead.HasRows Then
            While CheckRead.Read
                Txtpartid.Items.Add(CheckRead!PartCode & "-" & CheckRead!TAvcPart)
            End While
        End If
        CheckRead.Close()

      
        count = 0
       
        Dim sqlStr As String = "SELECT   SortID, SortName FROM m_Sortset_t WHERE SortType = 'AlterType' and Usey='Y' order by Orderid"
        Dim mRead As SqlDataReader = Conn.GetDataReader(sqlStr)
        If mRead.HasRows Then
            While mRead.Read
                CobType.Items.Add(mRead!SortName.ToString & "-" & mRead!SortID.ToString)
                ' CobType.Items.Add(mRead!SortName.ToString)
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()

        Dim sqlbz As String = "select distinct mark from (select top 10 mark from m_KeyPartAlter_t where mark <>'' and isnull(extend,'')='' order by intime desc) AA"
        Dim mRemark As SqlDataReader = Conn.GetDataReader(sqlbz)
        If mRemark.HasRows Then
            While mRemark.Read
                txtremarks.Items.Add(mRemark!mark.ToString)
            End While
        End If
        mRemark.Close()
        Conn.PubConnection.Close()


        Dim sqlyy As String = "select SortName  from m_Sortset_t where Usey ='Y' and SortType ='AlterCourse' order by Orderid "
        Dim mCourse As SqlDataReader = Conn.GetDataReader(sqlyy)
        If mCourse.HasRows Then
            While mCourse.Read
                CobCourse.Items.Add(mCourse!SortName.ToString)
            End While
        End If
        mCourse.Close()
        Conn.PubConnection.Close()



        'txtbagbarcode.Enabled = False
        'txtcablebarcode.Enabled = False
        'mRead = Conn.GetDataReader("select SortID from m_Sortset_t where SortType='E75Type' and Usey='Y' order by Orderid")
        'If mRead.HasRows Then
        '    While mRead.Read
        '        cmbstage.Items.Add(mRead!SortID.ToString)
        '    End While
        'End If
        'mRead.Close()
        'Conn.PubConnection.Close()
        ''cmbstage.Items.Add("pPR")
        ''cmbstage.Items.Add("PRO")
        ''cmbstage.Items.Add("pEV")
        ''cmbstage.Items.Add("EVT")
        ''cmbstage.Items.Add("DVT")
        ''cmbstage.Items.Add("PVT")
        'cmbstage.SelectedIndex = 0
        txtinput.Select()
        txtinput.SelectAll()
        'LblMsg.BackColor = Color.Gray

    End Sub



    Private Sub Toolcomfire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolcomfire.Click

        Me.Chk.Enabled = True
        Me.TxtMark.Enabled = True
        'Me.Txtbarcode.Enabled = True
        'Me.Butdelete.Enabled = True

    End Sub

    Private Sub Butdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If Me.Txtbarcode.Text.Trim = "" Then
        '    LblMsg.Text = "作废产品序号时，产品序号不能为空..."
        '    Exit Sub
        'End If
        'If Me.TxtMark.Text.Trim = "" Then
        '    LblMsg.Text = "作废产品序号时，备注不能为空，不能为空.."
        '    Exit Sub
        'End If
        'Dim state As String = ""
        'Dim mRead As SqlDataReader = Conn.GetDataReader("select top 1 [Type] Typea from m_KeyPartTranc_t where ppid='" & Txtbarcode.Text & "'  order by itemid desc")
        'If mRead.HasRows Then
        '    While mRead.Read
        '        state = mRead!Typea.ToString
        '    End While
        'End If
        'mRead.Close()
        'If state = "T" Then
        '    LblMsg.Text = "该产品序号已报废,不能再报废.."
        '    Exit Sub
        'End If
        'Try
        '    Dim sqlstr As String = "update m_KeyPartTranc_t set stateid='N' where [ppid]='" & Txtbarcode.Text & "'"
        '    sqlstr = sqlstr & vbNewLine & " INSERT INTO [MESDB].[dbo].[m_KeyPartTranc_t]([ppid],[partid],[property],[stateid],[Type],[stationid],[userid],[intime],mark) " & _
        '     "VALUES('" & Txtbarcode.Text & "','" & Txtpartid.Text.Trim & "','" & txtinput.Text.Trim & "','Y','T','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate(),N'" & TxtMark.Text & "')"

        '    Conn.ExecSql(sqlstr)
        '    LblQty.Text = CInt(LblQty.Text) + 1
        '    Conn.PubConnection.Close()
        '    DGMainTain.Rows.Add(Txtpartid.Text, Txtbarcode.Text, "", "T-报废", My.Computer.Name, SysMessageClass.UseId, Now.Date)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        '    Exit Sub
        'End Try


    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click

        ToolCancel.Enabled = False
        ToolStar.Enabled = True
        Me.txtinput.Clear()
        Me.txtinput.Enabled = False
        Txtpartid.SelectedIndex = -1
        Txtpartid.Enabled = False
        ButSet.Enabled = False
        ToolExcel.Enabled = False

    End Sub
    Private Function ClearStr(ByVal str As String) As String
        Return str.Replace(Chr(10), "").Replace(Chr(13), "")
    End Function

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
        If txtinput.Lines.Length > 1 Then
            If txtinput.Lines.Length = 2 Then
                txtinput.Text = txtinput.Lines(1).ToString.Trim
            Else
                If InStr(txtinput.Text.ToLower, "module serial number:") >= 0 Then
                    Try

                        For i As Integer = 0 To txtinput.Lines.Length - 1
                            If InStr(txtinput.Lines(i).ToString.ToLower, "accessory serial number:") > 0 And i > 1 Then Exit Sub
                            If InStr(txtinput.Lines(i).ToString.ToLower, "module serial number:") > 0 Then
                                ReadSn = txtinput.Lines(i).ToString.Split(":")(1).Trim
                                txtinput.Text = ReadSn
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        LblMsg.Text = "条码格式不正确..."
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        Exit Sub
                    End Try
                End If
            End If
           

        End If

        'If e.KeyChar <> Chr(13) Then Exit Sub
     
        Dim inputbarcode As String = Strings.StrConv(txtinput.Text, VbStrConv.Narrow, 0).Trim
        txtinput.Text = ClearStr(inputbarcode.Trim)
        inputbarcode = txtinput.Text

        If Not CheckCode(txtinput.Text) Then
            LblMsg.Text = "条码必须为字母数字组合格式..." + txtinput.Text
            txtinput.Text = ""
            txtinput.Clear()
            txtinput.Focus()
            Exit Sub
        End If
        Dim CurrState As String = ""
        Dim CurrName As String = ""
        Dim CurrID As String = ""
        Dim CurrExtend As String = ""
        Dim mSqlstr = "SELECT  isnull([type],'') as currType,SortName,itemid,isnull(extend,'') as extend FROM  m_KeyPartAlter_t a join m_Sortset_t b on a.type=b.SortID WHERE stateid='Y' and ppid='" & txtinput.Text.Trim & "'"
        Dim mRead As SqlDataReader = Conn.GetDataReader(mSqlstr)
        If mRead.HasRows Then
            While mRead.Read
                CurrState = mRead!currType.ToString.Trim
                CurrName = mRead!SortName.ToString.Trim
                CurrID = mRead!itemid.ToString.Trim
                CurrExtend = mRead!extend.ToString.Trim
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()



        Dim cbtype As String = CobType.Text.Split("-")(1).ToString
        If RadPPID.Checked Then

            If cbtype = "delivery" Then
                If CurrState <> "Warehous" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须为完成成品入库状态的产品，才允许仓库出货扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If
            If cbtype = "Goodsfactory" Then
                If CurrState <> "delivery" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须为完成成品出货状态的产品，才允许货物出厂..."
                    isEnd = False
                    Exit Sub
                End If
            End If
            If cbtype = "Materialstroage" Then
                If CurrState <> "" Then
                    If CurrState = "Materialstroage" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料已为在库状态，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        'If CurrState <> "MaterialOutlab" Then
                        '    txtinput.Text = ""
                        '    txtinput.Clear()
                        '    txtinput.Focus()
                        '    LblMsg.Text = "原材料状态:" + CurrName + "，不允许做扫描入库..."
                        '    isEnd = False
                        '    Exit Sub
                        'End If
                    End If

                End If

            End If
            If cbtype = "MaterialOutlab" Then
                If CurrState <> "" Then
                    If CurrState = "MaterialOutlab" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料已做实验室出库扫描，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        If CurrState <> "MaterialInlab" Then
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            LblMsg.Text = "编码状态:" + CurrName + "，不允许做实验室出库扫描..."
                            isEnd = False
                            Exit Sub
                        End If
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "编码状态:不存在，不允许做实验室出库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If cbtype = "MaterialInlab" Then
                If CurrState <> "" Then
                    If CurrState = "MaterialInlab" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料已做实验室收料扫描，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        If CurrState <> "MaterialOut" Then
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            LblMsg.Text = "编码状态:" + CurrName + "，不允许做实验室收料扫描..."
                            isEnd = False
                            Exit Sub
                        End If
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "编码状态:不存在，不允许做实验室进库收料扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If cbtype = "MaterialOut" Then
                If CurrState <> "" Then
                    If CurrState = "MaterialOut" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料已做出库至实验室扫描，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        If CurrState <> "Materialstroage" Then
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            LblMsg.Text = "编码状态:" + CurrName + "，不允许做出库扫描..."
                            isEnd = False
                            Exit Sub
                        End If
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "编码状态:不存在，不允许做出库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If



            If cbtype = "MaterialToA5" Then
                If CurrState <> "" Then
                    If CurrState = "MaterialToA5" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "原材料已做出库至A5扫描，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        If CurrState <> "Materialstroage" Then
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            LblMsg.Text = "编码状态:" + CurrName + "，不允许做出库A5扫描..."
                            isEnd = False
                            Exit Sub
                        End If
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "编码状态:不存在，不允许做出库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If cbtype = "MaterialToWork" Then
                If CurrState <> "" Then
                    If CurrState = "MaterialToWork" Then
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        LblMsg.Text = "条码已出库，不需要重复扫描..."
                        isEnd = False
                        Exit Sub
                    Else
                        If CurrState <> "Materialstroage" Then
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            LblMsg.Text = "条码状态:" + CurrName + "，不允许做出库生产加工扫描..."
                            isEnd = False
                            Exit Sub
                        End If
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "编码状态:不存在，不允许做出库扫描..."
                    isEnd = False
                    Exit Sub
                End If
            End If

            If cbtype = "MaterialA5Out" Then
                If CurrState <> "" Then
                    If CurrState <> "MaterialToA5" Then
                        LblMsg.Text = "原材料状态:" + CurrName + "，不允许做扫描出货..." '"物料\成品 " + txtinput.Text + " 必须为出库状态才允许扫描出货..."
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        isEnd = False
                        Exit Sub
                    End If
                Else
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "原材料状态:不存在，不允许做出货扫描..."
                    isEnd = False
                    Exit Sub
                End If

            End If

            If cbtype = "GetInToWarehous" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "GetInToWarehous" '编码已经在仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为已经在库,无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "ReturnToWarehous" '编码:已经在仓库了
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为已经在库,无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeAssembleTest" '编码:EE领用组装测试
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为EE领用组装测试，请使用领用归还入库..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeCompareVerify" '编码:EE领用比对验证
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为EE领用比对验证，请使用领用归还入库..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeExperimentTest" '编码:为实验室领用测试
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为实验室领用测试，请使用领用归还入库..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else


                    End Select
                End If

            End If
            If cbtype = "ReturnToWarehous" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "GetInToWarehous" '编码已经在仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为已经在库,无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "ReturnToWarehous" '编码已经在仓库了
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为已经在库,无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "TakeAssembleTest" AndAlso CurrState <> "TakeCompareVerify" AndAlso CurrState <> "TakeExperimentTest" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，不允许使用领用归还入库..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 状态不存在,不允许使用领用归还入库..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If
            End If

            If cbtype = "ReturnOutToCSMC" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "ReturnOutToCSMC" '编码已经在仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 已经领取归还CSMC,无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "GetInToWarehous" AndAlso CurrState <> "ReturnToWarehous" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，不允许使用领取归还CSMC..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，不允许使用领取归还CSMC..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If

            If cbtype = "TakeAssembleTest" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "ReturnOutToCSMC" '编码出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 已经领取归还CSMC..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeAssembleTest" '编码出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeCompareVerify" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许EE领用组装测试..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeExperimentTest" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许EE领用组装测试..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "GetInToWarehous" AndAlso CurrState <> "ReturnToWarehous" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，不允许使用EE领用组装测试..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，不允许使用EE领用组装测试..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If


            '领用比对验证
            If cbtype = "TakeCompareVerify" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "ReturnOutToCSMC" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 已经领取归还CSMC..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeCompareVerify" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeAssembleTest" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许EE领用比对验证..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeExperimentTest" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许EE领用组装测试..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "GetInToWarehous" AndAlso CurrState <> "ReturnToWarehous" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，无法使用EE领用组装测试..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，不允许使用EE领用组装测试..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If

            '实验室领用测试
            If cbtype = "TakeExperimentTest" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "ReturnOutToCSMC" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 已经领取归还CSMC..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeCompareVerify" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许实验室领用测试..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeAssembleTest" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",不允许实验室领用测试..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "TakeExperimentTest" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",无需再次扫描..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "GetInToWarehous" AndAlso CurrState <> "ReturnToWarehous" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，无法使用EE领用组装测试..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，不允许使用EE领用组装测试..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If

            '延长领用时间
            If cbtype = "SetExtendTime" Then
                If CurrState <> "" Then
                    Select Case CurrState
                        Case "ReturnOutToCSMC" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 已经领取归还CSMC..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "GetInToWarehous"
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",无法延长领用时间..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case "ReturnToWarehous" '编码:出仓库了                       
                            LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + ",无法延长领用时间..."
                            txtinput.Text = ""
                            txtinput.Clear()
                            txtinput.Focus()
                            isEnd = False
                            Exit Sub
                        Case Else
                            If CurrState <> "TakeCompareVerify" AndAlso CurrState <> "TakeAssembleTest" AndAlso CurrState <> "TakeExperimentTest" Then
                                LblMsg.Text = "编码:" + txtinput.Text + " 当前状态为" + CurrName + "，无法延长领用时间..."
                                txtinput.Text = ""
                                txtinput.Clear()
                                txtinput.Focus()
                                isEnd = False
                                Exit Sub
                            End If
                    End Select

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，无法延长领用时间..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If

            If cbtype.ToLower = "setalarmdeal" Then
                If CurrState <> "" Then
                    If CurrExtend.ToLower <> "setextendtime" And CurrExtend.ToLower <> "setalarmdeal" Then
                        LblMsg.Text = "编码:" + txtinput.Text + "必须已经延长过或者发过警报的才能进行警报确认处理..."
                        txtinput.Text = ""
                        txtinput.Clear()
                        txtinput.Focus()
                        isEnd = False
                        Exit Sub
                    End If

                Else
                    LblMsg.Text = "编码:" + txtinput.Text + " 当前没有记录" + CurrName + "，无法进行警报确认处理..."
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    isEnd = False
                    Exit Sub
                End If

            End If

        End If





        If Len(inputbarcode) < 8 Or Len(inputbarcode) > 32 Then
            MessageBox.Show("条码字符长度超出条码限制长度")
            txtinput.Clear()
            txtinput.Focus()
            Exit Sub
        End If
        Dim CurrStation As String = ""
        If cbtype = "Warehous" Then
            If RadPPID.Checked Then
                mRead = Conn.GetDataReader("select top 1 Stationid from m_ppidlink_t where ppid='" & inputbarcode & "' order by intime desc")
                If mRead.HasRows Then
                    While mRead.Read
                        CurrStation = mRead!Stationid
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                If CurrStation <> "P00001" And CurrStation <> "A00004" And CurrStation <> "A00011" Then
                    txtinput.Text = ""
                    txtinput.Clear()
                    txtinput.Focus()
                    LblMsg.Text = "必须产线生产包装完成的产品，才允许进行入库作业..."
                    isEnd = False
                    Exit Sub
                End If
            Else
                mRead = Conn.GetDataReader("select CartonStatus from m_Carton_t where Cartonid='" & inputbarcode & " '")
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

        'If CobType.Text.Split("-")(0) = "MaterialToWork" Then
        '    If RadCartonID.Checked Then
        '        mRead = Conn.GetDataReader("select top 1 Stationid from m_ppidlink_t where ppid='" & inputbarcode & "' order by intime desc")
        '        If mRead.HasRows Then
        '            While mRead.Read
        '                CurrStation = mRead!Stationid
        '            End While
        '        End If
        '        mRead.Close()
        '        Conn.PubConnection.Close()
        '        If CurrStation <> "P00001" And CurrStation <> "A00004" And CurrStation <> "A00011" Then
        '            txtinput.Text = ""
        '            txtinput.Clear()
        '            txtinput.Focus()
        '            LblMsg.Text = "必须产线生产包装完成的产品，才允许进行入库作业..."
        '            isEnd = False
        '            Exit Sub
        '        End If
        '    Else
        '        mRead = Conn.GetDataReader("select CartonStatus from m_Carton_t where Cartonid='" & inputbarcode & " '")
        '        If mRead.HasRows = False Then
        '            txtinput.Text = ""
        '            txtinput.Clear()
        '            txtinput.Focus()
        '            LblMsg.Text = "该外箱并没有进行外箱包装扫描，不允许进行入库作业..."
        '            isEnd = False
        '            mRead.Close()
        '            Conn.PubConnection.Close()
        '            Exit Sub
        '        End If
        '        mRead.Close()
        '        Conn.PubConnection.Close()
        '    End If

        'End If



        If cbtype.Trim.ToLower = "setextendtime" Or cbtype.Trim.ToLower = "setalarmdeal" Then
            If CobCourse.Text.Trim <> "" Then
                mSqlstr = " exec m_KeyPartAlterSetExtendTime_P '" & inputbarcode & "',N'" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & CobHours.Text.ToString.Trim & ",N'" & CobType.Text.Split("-")(0).Trim & "',N'" & txtremarks.Text.Trim & "',N'" & CobCourse.Text.Split("-")(0).Trim & "'"
            Else
                LblMsg.Text = "请输入原因和处理结果..."
                CobCourse.Focus()
                Exit Sub
            End If
            ' update m_KeyPartAlter_t set stateid='N' where ppid='" & txtinput.Text & "'"
            'mSqlstr = mSqlstr & vbNewLine & " insert m_KeyPartAlter_t(ppid,partid,[type],[stationid],stateid,userid,intime,mark,warned,updatetime,hours) select ppid,partid,[type],[stationid]=N'" & My.Computer.Name & "',stateid='Y',userid='" & SysMessageClass.UseId & "',intime,mark=N'在'+convert(varchar(19),GETDATE(),121)+N',延长" & CobHours.Text.Trim & "小时',warned=0,getdate(),hours=" & CobHours.Text.ToString.Trim & " from m_KeyPartAlter_t where  itemid ='" & CurrID & "'"
        Else
            mSqlstr = " exec m_KeyPartAlterScan_P '" & inputbarcode & "','" & Txtpartid.Text & "','" & cbtype & "',N'" & My.Computer.Name & "','" & SysMessageClass.UseId & "',N'" & txtremarks.Text.Trim & "'"

            'mSqlstr = " update m_KeyPartAlter_t set stateid='N' where ppid='" & inputbarcode & "'"
            'mSqlstr = mSqlstr & vbNewLine & " insert into m_KeyPartAlter_t(ppid,partid,[type],[stationid],stateid,userid,intime,mark,updatetime)" & _
            '  "values('" & inputbarcode & "','" & Txtpartid.Text & "','" & cbtype & "',N'" & My.Computer.Name & "','Y'," & _
            '  "'" & SysMessageClass.UseId & "',getdate(),N'" & txtremarks.Text & "',getdate())"
        End If
        Try
            Conn.ExecSql(mSqlstr)
            isEnd = False
            LblMsg.Text = "产品序号" + inputbarcode + "扫描成功..."
            LblQty.Text = CInt(LblQty.Text) + 1
            DGMainTain.Rows.Add(txtinput.Text, CobType.Text.Split("-")(0), SysMessageClass.UseId, Now.Date.ToString("yyyy-MM-dd HH:mm:ss").ToString)
            DGMainTain.AutoResizeColumns()
            txtinput.Clear()
            txtinput.Focus()
        Catch ex As Exception
            LblMsg.Text = "产品序号" + inputbarcode + "扫描失败..."
            txtinput.Clear()
            txtinput.Focus()
        End Try

        'DGMainTain.Rows.Add(Txtpartid.Text, txtmsn.Text, Inputstr, formtype, My.Computer.Name, SysMessageClass.UseId, Now.Date)
        'txtinput.Enabled = True


    End Sub

    Private Sub Txtpartid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtpartid.SelectedIndexChanged
        CobType.Items.Clear()

        If Txtpartid.Text.Trim.ToLower = "golden unit" Then
            Dim sqlStr As String = "SELECT   SortID, SortName FROM m_Sortset_t WHERE SortType = 'AlterType' and Usey='Y' and SortTypeName=N'golden' order by Orderid"
            Dim mRead As SqlDataReader = Conn.GetDataReader(sqlStr)
            If mRead.HasRows Then
                While mRead.Read
                    CobType.Items.Add(mRead!SortName.ToString & "-" & mRead!SortID.ToString)
                    ' CobType.Items.Add(mRead!SortName.ToString)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
        Else
            Dim sqlStr As String = "SELECT   SortID, SortName FROM m_Sortset_t WHERE SortType = 'AlterType' and Usey='Y' and SortTypeName<>N'golden' order by Orderid"
            Dim mRead As SqlDataReader = Conn.GetDataReader(sqlStr)
            If mRead.HasRows Then
                While mRead.Read
                    CobType.Items.Add(mRead!SortName.ToString & "-" & mRead!SortID.ToString)
                    ' CobType.Items.Add(mRead!SortName.ToString)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
        End If
    End Sub

    Private Sub CobType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobType.SelectedIndexChanged
        Dim selval As String = CobType.Text.Split("-")(1)
        If selval = "SetExtendTime" Or selval = "SetAlarmDeal" Then
            lblhours.Visible = True
            CobHours.Visible = True
            CobHours.SelectedIndex = 0
            lbcourse.Visible = True
            CobCourse.Visible = True
            CobCourse.SelectedIndex = 0
            txtremarks.Enabled = False
        Else
            lblhours.Visible = False
            CobHours.Visible = False
            lbcourse.Visible = False
            CobCourse.Visible = False
            txtremarks.Enabled = True
        End If
        If selval = "Warehous" Or selval = "delivery" Or selval = "Goodsfactory" Then
            RadCartonID.Enabled = True
        Else
            RadCartonID.Enabled = False
        End If
        RadCartonID.Checked = False
        RadPPID.Checked = True
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        If txtinput.Enabled = True Then
            Me.OpenFileDialog1.ShowDialog()
            Me.OpenFileDialog1.Multiselect = False
        Else
            MessageBox.Show("无法导入")
        End If
    End Sub
   
    Private Function CheckCode(ByVal strIn As String)
        Dim strRegex As String = "^([\w\d_]|[\u4e00-\u9fa5]){6,32}$"
        Return System.Text.RegularExpressions.Regex.IsMatch(strIn, strRegex)
    End Function

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Dim TxtFileName As String = Me.OpenFileDialog1.FileName.Substring(Me.OpenFileDialog1.FileName.LastIndexOf("\") + 1)
        Dim TxtFilePathName As String = Me.OpenFileDialog1.FileName
        Dim dt As DataTable = New DataTable
        Dim Suffix As String = TxtFilePathName.Trim.Substring(TxtFilePathName.Trim.IndexOf(".") + 1)
        If Suffix.ToLower = "txt" Or Suffix.ToLower = "csv" Then
            dt = ReadFileData(TxtFilePathName)
        Else
            MessageBox.Show("请上传txt或者CSV文件格式")
            Exit Sub
        End If
        'Dim dt As DataTable = ReadTXT(TxtFilePathName) 'GetExcelTableName(TxtFilePathName)

        Dim i As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            Dim str As String = dt.Rows(i)(0).ToString
            txtinput.Text = str
            StandScan()
            Me.txtinput.Focus()
        Next
    End Sub


    Public Shared Function ReadFileData(ByVal dirTXT As String) As System.Data.DataTable

        Dim objReader As StreamReader = New StreamReader(dirTXT)

        Dim dt As System.Data.DataTable = New System.Data.DataTable()

        dt.Columns.Add("SN", System.Type.GetType("System.String"))

        Dim sLine As String = ""

        Do While Not sLine Is Nothing
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                If sLine.Trim.Length > 0 Then
                    Dim dr As DataRow = dt.NewRow()
                    dr("SN") = sLine
                    dt.Rows.Add(dr)
                Else
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        objReader.Close()
        Return dt

    End Function

    Private Sub RadCartonID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCartonID.Click
        RadPPID.Checked = False
        RadPPID.ForeColor = Drawing.Color.LightGray
        RadCartonID.ForeColor = Drawing.Color.LimeGreen
        txtinput.Focus()


    End Sub

    Private Sub RadPPID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPPID.Click
        RadCartonID.Checked = False
        RadPPID.ForeColor = Drawing.Color.LimeGreen
        RadCartonID.ForeColor = Drawing.Color.LightGray
        txtinput.Focus()
    End Sub
End Class