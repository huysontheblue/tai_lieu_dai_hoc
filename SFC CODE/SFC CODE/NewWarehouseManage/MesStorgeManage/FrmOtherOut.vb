Imports MainFrame
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO

Public Class FrmOtherOut
    'Dim g_Rights As String '權限
    Dim StrflagB As String  '區分大項的“新增”“修改”
    Dim StrflagS As String  '區分小項的“新增”“修改”
    Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass


    Private Sub FrmOtherOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoRights() '權限處理
        FillFactory(CobFacory, MainFrame.SysCheckData.SysMessageClass.UseId)

        'load Invoice單數據到界面
        LoadData()
        'ContorState("RETURN")
    End Sub

    Public Sub FillFactory(ByRef ComBox As ComboBox, ByVal strUser As String)
        Dim strSql As String
        Dim rs As SqlDataReader
        '
        ComBox.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey in " _
               & " (select tkey from m_logtree_t where tparent='F0_') " _
               & " and userid='" & strUser & "') "
        Rs = PubClass.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                'ComBox.Items.Add(rs(0).ToString & "(" & rs(1).ToString & ")")
                ComBox.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)
            End While
            'ComBox.SelectedIndex = 0
        End If
        Rs.Close()

    End Sub

    '按鈕單擊事件

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ContorState("NEW")
        TxtInvoice.Focus()
    End Sub     '新增

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        If TxtInvoice.Text.Trim = "" Then Exit Sub
        ContorState("EDIT")
        TxtInvoice.Focus()
    End Sub    '修改 

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        'Dim StrOutid As String  '出貨單號
        'Dim IntQty As Integer  '已掃描數量
        'Dim i As Integer '用做循環
        'Dim n As Integer  '用做計數
        Dim Strsql As String
        Dim Rs As SqlDataReader

        'If DGItem.Enabled = False Then
        '    MessageBox.Show("請先保存詳細出貨信息，再[保存]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        Try
            If Trim(TxtInvoice.Text) = "" Then
                MessageBox.Show("Invoice 不能為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            
            If CobFacory.Text = "" Then
                MessageBox.Show("請選擇[公司]！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CobFacory.Focus()
                Exit Sub
            End If
            If CobOuttype.Text = "" Then
                MessageBox.Show("請選擇[出貨類型]！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CobOuttype.Focus()
                Exit Sub
            End If
            If CobOuttype.SelectedIndex = 0 And chkCreate.Checked = True Then
                MessageBox.Show("[正常出貨]請手工輸入Invoice單號！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If DGItem.Rows.Count = 0 Then
            '    MessageBox.Show("請輸入詳細出貨信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            If StrflagB = "N" Then  '新增時
                'check Invoice 的長度為10位，前兩位是字母
                If CheckInvoiceLength(Trim(TxtInvoice.Text)) = False Then
                    MessageBox.Show("輸入的Invoice [長度不是十位]或者[前兩位不是字母],請重新輸入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtInvoice.Focus()
                    Exit Sub
                End If
                ''檢驗Invoice是否已存在
                ''Invoice版本
                ''Strsql = "select 1 from m_InvoiceS_t where InvoiceJob='" & Trim(TxtInvoice.Text) & "'"
                Strsql = "select 1 from m_shipm_t where Invoice='" & Trim(TxtInvoice.Text) & "'"
                Rs = PubClass.GetDataReader(Strsql)
                If Rs.Read Then
                    MessageBox.Show("該Invoice已存在，請重新生成！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Rs.Close()
                    Exit Sub
                End If
                Rs.Close()

                ' ''數據保存
                ' ''StrInvJob = GetInvoiceJob() '取得最大Invoice作业单
                ' ''StrApp.Append("insert into m_InvoiceM_t(InvoiceJob,Invoice,Noticeid,Cusid,Receaddr,Remark,Factoryid,InvoiceType," & _
                ' ''              "Userid,Intime,Updateuser,Updatetime)values('" & StrInvJob & "','" & Trim(TxtInvoice.Text) & "','" & Trim(TxtVInvo.Text) & "'," & _
                ' ''              "'" & Trim(TxtCusid.Text) & "','" & Trim(TxtCusAddr.Text) & "','" & Trim(TxtRemark.Text) & "'," & _
                ' ''              "'" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "','2','sz30914',getdate(),'sz30914',getdate())")
                ' ''StrApp.Append(Environment.NewLine)


                'For i = 0 To DGItem.Rows.Count - 1
                '    StrApp.Append("insert into m_InvoiceS_t(InvoiceJob,Partid,Shipqty,Qty,Stateid,factoryid,Usey,Userid,Intime)values('" & Trim(TxtInvoice.Text) & "'," & _
                '                  "'" & DGItem.Item(0, i).Value & "','" & DGItem.Item(1, i).Value & "',0,'0','" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "','Y','sz30914',getdate())  ")
                '    StrApp.Append(Environment.NewLine)
                'Next
                Strsql = "insert into m_shipm_t(Invoice,Cusid,Factory,Flag,Usey,stateid,outtype)values('" & Trim(TxtInvoice.Text) & "'," & _
                         "'','" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "','1','Y','1','" & CobOuttype.Text.Substring(0, 1) & "')"
                PubClass.ExecSql(Strsql)
                ContorState("RETURN")
                MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtDNew_Click(sender, e)
            ElseIf StrflagB = "E" Then  '修改時
                Strsql = "update m_shipm_t set factory='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "'," & _
                         "outtype='" & CobOuttype.Text.Substring(0, 1) & "' where Invoice='" & Trim(TxtInvoice.Text) & "'"
                PubClass.ExecSql(Strsql)
                ContorState("RETURN")
                MessageBox.Show("修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'For i = 0 To DGItem.Rows.Count - 1
                '    '取當前出貨單號
                '    'StrOutid = GetNowOutid(StrInvJobtemp, DGItem.Item(0, i).Value)
                '    StrOutid = GetNowOutid(Trim(TxtInvoice.Text), DGItem.Item(0, i).Value)
                '    '當前表格中料號的處理
                '    If StrOutid = "" Then '還未開始掃描
                '        StrApp.Append("delete from m_InvoiceS_t where InvoiceJob='" & Trim(TxtInvoice.Text) & "'and Partid='" & DGItem.Item(0, i).Value & "'")
                '        StrApp.Append(Environment.NewLine)
                '        StrApp.Append("insert into m_InvoiceS_t(InvoiceJob,Partid,Shipqty,Qty,Stateid,factoryid,Usey,Userid,Intime)values('" & Trim(TxtInvoice.Text) & "'," & _
                '                      "'" & DGItem.Item(0, i).Value & "','" & DGItem.Item(1, i).Value & "',0,'0','" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "','Y','sz30914',getdate())  ")
                '        StrApp.Append(Environment.NewLine)
                '    Else  '已掃描過

                '        '取得當前已掃描數量
                '        IntQty = GetNowQty(Trim(TxtInvoice.Text), DGItem.Item(0, i).Value.ToString)
                '        If DGItem.Item(1, i).Value > IntQty Then '大於當前已掃描數量
                '            StrApp.Append("update m_InvoiceS_t set Shipqty='" & DGItem.Item(1, i).Value & "', Stateid='1',factoryid='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "'," & _
                '                          "Userid='sz30914',Intime=getdate() where InvoiceJob='" & Trim(TxtInvoice.Text) & "'and Partid='" & DGItem.Item(0, i).Value & "'")
                '            StrApp.Append(Environment.NewLine)
                '        ElseIf DGItem.Item(1, i).Value < IntQty Then '小於當前已掃描數量
                '            StrApp.Append("update m_InvoiceS_t set Shipqty='" & DGItem.Item(1, i).Value & "', Stateid='3',factoryid='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "'," & _
                '                          "Userid='sz30914',Intime=getdate() where InvoiceJob='" & Trim(TxtInvoice.Text) & "'and Partid='" & DGItem.Item(0, i).Value & "'")
                '            StrApp.Append(Environment.NewLine)
                '        ElseIf DGItem.Item(1, i).Value = IntQty Then '等於當前已掃描數量
                '            StrApp.Append("update m_InvoiceS_t set Shipqty='" & DGItem.Item(1, i).Value & "', Stateid='2',factoryid='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "'," & _
                '                          "Userid='sz30914',Intime=getdate() where InvoiceJob='" & Trim(TxtInvoice.Text) & "'and Partid='" & DGItem.Item(0, i).Value & "'")
                '            StrApp.Append(Environment.NewLine)
                '        End If
                '    End If
                'Next
                ''當前表格中沒有，而之前有的料號的處理
                'Strsql = "select Partid from m_InvoiceS_t where InvoiceJob='" & Trim(TxtInvoice.Text) & "'"
                'Rs = PubClass.GetDataReader(Strsql)
                'While Rs.Read
                '    n = 0
                '    For i = 0 To DGItem.Rows.Count - 1
                '        If Rs(0).ToString = DGItem.Item(0, i).Value Then
                '            n = n + 1
                '        End If
                '        If n = 1 Then
                '            Continue While
                '        End If
                '    Next
                '    StrApp.Append("update m_InvoiceS_t set Shipqty=0, Stateid='3' ,factoryid='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "'," & _
                '                  "Userid='sz30914',Intime=getdate() where InvoiceJob='" & Trim(TxtInvoice.Text) & "'and Partid='" & Rs(0).ToString & "'")
                '    StrApp.Append(Environment.NewLine)
                'End While
                'Rs.Close()
                'StrApp.Append("update m_InvoiceS_t set factoryid='" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "' where InvoiceJob='" & Trim(TxtInvoice.Text) & "'")
                'PubClass.ExecSql(StrApp.ToString)
                'StrApp.Remove(0, StrApp.ToString.Length)
                'MessageBox.Show("修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ContorState("RETURN")
            End If
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOtherOut", "BtSave_Click", "sys")
        End Try

    End Sub    '保存

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        ContorState("RETURN")
        If StrflagB = "N" Then
            TxtInvoice.Text = ""
            CobFacory.SelectedIndex = -1
            CobOuttype.SelectedIndex = -1
            chkCreate.Checked = False
            TxtInvoice.Enabled = False
        End If
        DGcellclick()
    End Sub  '返回

    Private Sub BtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub    '退出

    '按鈕狀態控制
    Private Sub ContorState(ByVal flag As String)
        Select Case flag
            Case "NEW"
                TxtInvoice.Text = ""
                chkCreate.Checked = False
                CobFacory.SelectedIndex = -1
                CobOuttype.SelectedIndex = -1
                TxtPartNo.Text = ""
                TxtQty.Text = ""
                StrflagB = "N"

                TxtInvoice.Enabled = True
                chkCreate.Enabled = True
                CobFacory.Enabled = True
                CobOuttype.Enabled = True
                BtNew.Enabled = False
                BtEdit.Enabled = False
                BtSave.Enabled = True
                BtCancel.Enabled = True
                BtExit.Enabled = True

                BtDNew.Enabled = False
                BtDEdit.Enabled = False
                BtDDel.Enabled = False
                BtDSave.Enabled = False
                BtDReturn.Enabled = False
                TxtPartNo.Enabled = False
                TxtQty.Enabled = False
                DGItem.Enabled = False
                DGItem.Rows.Clear()

            Case "EDIT"
                StrflagB = "E"
                TxtInvoice.Enabled = False
                chkCreate.Enabled = False
                CobFacory.Enabled = True
                CobOuttype.Enabled = True
               
                BtNew.Enabled = False
                BtEdit.Enabled = False
                BtSave.Enabled = True
                BtCancel.Enabled = True
                BtExit.Enabled = True

                BtDNew.Enabled = False
                BtDEdit.Enabled = False
                BtDDel.Enabled = False
                BtDSave.Enabled = False
                BtDReturn.Enabled = False
                TxtPartNo.Enabled = False
                TxtQty.Enabled = False
                DGItem.Enabled = False

            Case "RETURN"
                TxtPartNo.Text = ""
                TxtQty.Text = ""
                ' StrflagB = "R"

                TxtInvoice.Enabled = False
                chkCreate.Enabled = False
                CobFacory.Enabled = False
                CobOuttype.Enabled = False

                BtNew.Enabled = True
                BtEdit.Enabled = True
                BtSave.Enabled = False
                BtCancel.Enabled = False
                BtExit.Enabled = True

                BtDNew.Enabled = True
                BtDEdit.Enabled = True
                BtDDel.Enabled = True
                BtDSave.Enabled = False
                BtDReturn.Enabled = False
                TxtPartNo.Enabled = False
                TxtQty.Enabled = False
                DGItem.Enabled = True
        End Select

    End Sub


    '小按鈕單擊事件
    Private Sub BtDNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDNew.Click
        If Trim(TxtInvoice.Text) <> "" Then
            ChangeUID("NEW")
        Else
            MessageBox.Show("請先查找出Invoice的信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub     '新增

    Private Sub BtDEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDEdit.Click
        If TxtPartNo.Text = "" Then Exit Sub
        ChangeUID("EDIT")
    End Sub    '修改

    Private Sub BtDDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDDel.Click
        Dim strState As String
        Dim strInvoice As String
        Try
            If TxtPartNo.Text = "" Then Exit Sub

            strInvoice = TxtInvoice.Text.ToUpper.Trim
            strState = GetScanState(strInvoice, TxtPartNo.Text)
            ' If strState = "" Then Exit Sub
            If strState <> "" Then
                MessageBox.Show("此料號已開始掃描,不能刪除。請直接修改數量。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("確定要刪除[料號]為: " & TxtPartNo.Text & " ,[Invoice]為: " & strInvoice & "  的信息嗎？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Invoice 版本
                'PubClass.ExecSql("delete from m_InvoiceS_t where invoice='" & strInvoice & "'and partid='" & Trim(TxtPartNo.Text) & "'")
                PubClass.ExecSql("delete from m_shipdtotal_t where invoice='" & strInvoice & "'and partid='" & Trim(TxtPartNo.Text) & "' " & _
                vbNewLine & " delete from m_shipd_t where invoice='" & strInvoice & "'and partid='" & Trim(TxtPartNo.Text) & "' and items= 1 ")
                LoadDataToDg(Trim(TxtInvoice.Text))
                ChangeUID("RETURN")
                MessageBox.Show("刪除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOtherOut", "BtDDel_Click", "sys")
        End Try
        DGcellclick()
    End Sub     '刪除

    Private Sub BtDSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDSave.Click
        Dim i As Integer
        Dim Strsql As String
        'Dim StrWhid As String '掃描單號
        Try
            'Check 該Invoice 是否已經確認出庫
            If InvoiceIsConfirm(Trim(TxtInvoice.Text)) = True Then
                MessageBox.Show("該Invoice 已經確認出庫，請先駁回！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            '新增時
            If StrflagS = "N" Then
                If TxtPartNo.Text = "" Then
                    MessageBox.Show("請輸入料件編號.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPartNo.Focus()
                    Exit Sub
                End If

                If Not CheckPartNO(TxtPartNo.Text) Then
                    MessageBox.Show("輸入的料號錯誤.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPartNo.Text = ""
                    TxtPartNo.Focus()
                    Exit Sub
                End If
                For i = 0 To DGItem.Rows.Count - 1
                    If TxtPartNo.Text = DGItem.Item(0, i).Value.ToString Then
                        MessageBox.Show("輸入的料號和下表重復，請直接修改數量.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Next

                If TxtQty.Text = "" Then
                    MessageBox.Show("請輸入數量.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtQty.Text = ""
                    TxtQty.Focus()
                    Exit Sub
                End If
                Strsql = "insert into m_shipdtotal_t(Invoice,Partid,Eqty,Qty,States,Usey,Factoryid,userid,intime)" & _
                         "values('" & Trim(TxtInvoice.Text) & "','" & Trim(TxtPartNo.Text) & "'," & Trim(TxtQty.Text) & "," & _
                         "0,'0','Y','" & CobFacory.Text.Substring(0, InStr(CobFacory.Text, "-") - 1) & "','" & SysCheckData.SysMessageClass.UseId & "',getdate())"
                Strsql = Strsql + vbNewLine + "insert into m_shipd_t(invoice,items,partid,eqty,intime,userid,states,flag)" & _
                         "values('" & Trim(TxtInvoice.Text) & "',1,'" & Trim(TxtPartNo.Text) & "'," & Trim(TxtQty.Text) & "," & _
                         "getdate(),'" & SysCheckData.SysMessageClass.UseId & "','E','1')"
                PubClass.ExecSql(Strsql)
                MessageBox.Show("保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            '修改時 
            If StrflagS = "E" Then
                Strsql = "update m_shipdtotal_t set Eqty='" & Trim(TxtQty.Text) & "'where invoice='" & Trim(TxtInvoice.Text) & "'and partid='" & Trim(TxtPartNo.Text) & "'"
                Strsql = Strsql + vbNewLine + "update m_shipd_t set eqty=" & Trim(TxtQty.Text) & ",intime=getdate(),userid='" & SysCheckData.SysMessageClass.UseId & "' " & _
                         "where invoice='" & Trim(TxtInvoice.Text) & "' and items= 1 and partid='" & Trim(TxtPartNo.Text) & "'"
                PubClass.ExecSql(Strsql)
                MessageBox.Show("修改成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            LoadDataToDg(Trim(TxtInvoice.Text))
            ChangeUID("RETURN")
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOtherOut", "BtDSave_Click", "sys")
        End Try
    End Sub '添加

    Private Sub BtDReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDReturn.Click
        ChangeUID("RETURN")
    End Sub  '返回

    '小按鈕狀態控制
    Private Sub ChangeUID(ByVal StrOp As String)
        Select Case StrOp
            Case "NEW"
                BtDNew.Enabled = False
                BtDEdit.Enabled = False
                BtDDel.Enabled = False
                BtDSave.Enabled = True
                BtDReturn.Enabled = True
                TxtPartNo.Enabled = True
                TxtQty.Enabled = True
                TxtPartNo.Text = ""
                TxtQty.Text = ""
                StrflagS = "N"
                TxtPartNo.Focus()
                DGItem.Enabled = False

                TxtInvoice.Enabled = False
                chkCreate.Enabled = False
                CobFacory.Enabled = False
                CobOuttype.Enabled = False
                BtNew.Enabled = False
                BtEdit.Enabled = False
                BtSave.Enabled = False
                BtCancel.Enabled = False
                BtExit.Enabled = False
            Case "EDIT"
                BtDNew.Enabled = False
                BtDEdit.Enabled = False
                BtDDel.Enabled = False
                BtDSave.Enabled = True
                BtDReturn.Enabled = True
                TxtPartNo.Enabled = False
                TxtQty.Enabled = True
                TxtQty.Text = ""
                StrflagS = "E"
                TxtQty.Focus()
                DGItem.Enabled = False

                TxtInvoice.Enabled = False
                chkCreate.Enabled = False
                CobFacory.Enabled = False
                CobOuttype.Enabled = False
                BtNew.Enabled = False
                BtEdit.Enabled = False
                BtSave.Enabled = False
                BtCancel.Enabled = False
                BtExit.Enabled = False
            Case "RETURN"
                BtDNew.Enabled = True
                BtDEdit.Enabled = True
                BtDDel.Enabled = True
                BtDSave.Enabled = False
                BtDReturn.Enabled = False
                TxtPartNo.Enabled = False
                TxtQty.Enabled = False
                TxtPartNo.Text = ""
                TxtQty.Text = ""
                StrflagS = ""
                DGItem.Focus()
                DGItem.Enabled = True
                DGcellclick()

                TxtInvoice.Enabled = False
                chkCreate.Enabled = False
                CobFacory.Enabled = False
                CobOuttype.Enabled = False
                BtNew.Enabled = True
                BtEdit.Enabled = True
                BtSave.Enabled = False
                BtCancel.Enabled = False
                BtExit.Enabled = True
        End Select
    End Sub

    '單選框選擇
    Private Sub chkCreate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCreate.CheckedChanged
        If chkCreate.Checked Then
            TxtInvoice.Text = GetAutoInvoiceNo() '取得最大Invoice單號
            TxtInvoice.Enabled = False
        Else
            TxtInvoice.Text = ""
            TxtInvoice.Enabled = True
        End If
    End Sub

    '取得最大Invoice單號
    Function GetAutoInvoiceNo()
        Dim strSql As String
        Dim strNo As String
        Dim strReturn As String '返回字符串
        Const strFixCode = "XVZX"
        Dim Rs As SqlDataReader

        strNo = ""
        ''Invoice版本
        'strSql = " select substring(max(InvoiceJob), 7, 4) from m_InvoiceS_t where InvoiceJob like'" & strFixCode & GetYearMonth() & "%' "
        '當前版本
        strSql = "select substring(max(Invoice), 7, 4) from m_shipm_t where Invoice like'" & strFixCode & GetYearMonth() & "%' "
        Rs = PubClass.GetDataReader(strSql)
        If Rs.Read Then
            strNo = Rs(0).ToString
            strNo = "1" & strNo
            strNo = Mid(CType(CType(strNo, Integer) + 1, String), 2, 4)
        End If
        If strNo = "" Then
            strNo = "0001"
        End If
        Rs.Close()
        strReturn = strFixCode & GetYearMonth() & strNo

        Return strReturn

    End Function

    ''取得當前Invoice作业单
    'Function GetNowInvoiceJob()
    '    Dim Rs As SqlDataReader
    '    Dim strReturn As String '返回字符串
    '    Dim strSql As String

    '    strReturn = ""
    '    strSql = "select InvoiceJob from m_InvoiceM_t where Invoice='" & Trim(TxtInvoice.Text) & "'"
    '    Rs = PubClass.GetDataReader(strSql)
    '    While Rs.Read
    '        strReturn = Rs(0).ToString
    '    End While
    '    Rs.Close()
    '    Return strReturn
    'End Function

    ''取得最大Invoice作业单
    'Function GetInvoiceJob()
    '    Dim strSql As String
    '    Dim strReturn As String '返回字符串
    '    Dim StrTemp As String = ""
    '    Dim Rs As SqlDataReader

    '    strSql = "select right(max(InvoiceJob),3) From m_InvoiceM_t Where " & _
    '             "InvoiceJob like 'IVO' + convert(varchar(6),getdate(),12)+'%'"
    '    Rs = PubClass.GetDataReader(strSql)
    '    If Rs.Read Then
    '        StrTemp = Rs(0).ToString
    '        StrTemp = "1" & StrTemp
    '        StrTemp = Mid(CType(CType(StrTemp, Integer) + 1, String), 2, 3)
    '    End If
    '    If StrTemp = "" Then
    '        StrTemp = "001"
    '    End If
    '    Rs.Close()
    '    strReturn = "IVO" & Now.Date.ToString("yyMMdd") & StrTemp

    '    Return strReturn

    'End Function

    '取當前出貨單號
    Function GetNowOutid(ByVal StrInvJob As String, ByVal Partid As String)
        Dim Rs As SqlDataReader
        Dim Strsql As String
        Dim StrReturn As String = ""
        ''Invoice版本
        'Strsql = "select isnull(Outwhid,'') from m_InvoiceS_t where InvoiceJob='" & StrInvJob & "'and Partid='" & Partid & "'"
        '當前版本
        Strsql = "select isnull(Outwhid,'') from m_shipdtotal_t where Invoice='" & StrInvJob & "'and Partid='" & Partid & "'"
        Rs = PubClass.GetDataReader(Strsql)
        While Rs.Read
            If Rs(0).ToString = "" Then
                StrReturn = ""
            Else
                StrReturn = Rs(0).ToString
            End If
        End While
        Rs.Close()
        Return StrReturn

    End Function

    '取得當前出貨數量
    Function GetNowQty(ByVal StrInvJob As String, ByVal Partid As String) As Integer
        Dim Strsql As String
        Dim IntReturn As Integer = 0
        Dim Rs As SqlDataReader

        Strsql = "select Qty from m_InvoiceS_t where InvoiceJob='" & StrInvJob & "'and Partid='" & Partid & "'"
        Rs = PubClass.GetDataReader(Strsql)
        While Rs.Read
            IntReturn = Rs(0).ToString
        End While
        Rs.Close()
        Return IntReturn
    End Function

    '取得年月份
    Private Function GetYearMonth() As String
        Dim strSql As String
        Dim strYear, strMonth As String
        Dim strReturn As String
        Dim Rs As SqlDataReader

        strYear = ""
        strMonth = ""
        strSql = " select datepart(yy, getdate()), datepart(m, getdate()) "
        Rs = PubClass.GetDataReader(strSql)
        If Rs.Read Then
            strYear = Rs(0).ToString
            strYear = Mid(strYear, 4, 1)
            strMonth = Rs(1).ToString
            If strMonth.Length > 1 Then
                If strMonth = "10" Then strMonth = "A"
                If strMonth = "11" Then strMonth = "B"
                If strMonth = "12" Then strMonth = "C"
            End If
        Else
            strReturn = "01"
        End If
        Rs.Close()
        strReturn = strYear & strMonth

        Return strReturn

    End Function

    '取得當前料號的掃描狀態
    Function GetScanState(ByVal StrInvoice As String, ByVal StrPartNo As String)
        Dim strSql As String
        Dim Rs As SqlDataReader
        Dim strReturn As String = ""
        ''Invoice 版本
        'strSql = "select a.Stateid from m_InvoiceS_t a left join m_InvoiceM_t b on a.InvoiceJob=b.InvoiceJob " & _
        '         "where a.Partid='" & StrPartNo & "'and b.Invoice='" & StrInvoice & "'"
        '當前版本
        strSql = "select isnull(outwhid,'') from m_shipdtotal_t where Partid='" & StrPartNo & "'and Invoice='" & StrInvoice & "'"
        Rs = PubClass.GetDataReader(strSql)

        If Rs.Read Then
            strReturn = Rs(0).ToString
        End If
        Rs.Close()

        Return strReturn

    End Function

    '檢查輸入料號是否正確
    Public Function CheckPartNO(ByVal strPartNo As String) As Boolean
        Dim strSql As String
        Dim bReturn As Boolean
        Dim Rs As SqlDataReader

        strSql = " select count(*) from matter_tab where partid='" & strPartNo & "' "
        Rs = PubClass.GetDataReader(strSql)
        If Rs.Read Then
            If Rs(0) > 0 Then
                bReturn = True
            Else
                bReturn = False
            End If
        Else
            bReturn = False
        End If

        Rs.Close()
        Return bReturn
    End Function

    '權限處理
    Private Sub DoRights()
        Dim strSql As String
        Dim Rs As SqlDataReader
        'SysCheckData.SysMessageClass.UseId = "sz30914"
        'g_Rights = ""
        CobFacory.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey='F010_' and userid='" & SysCheckData.SysMessageClass.UseId & "' " _
               & " union " _
               & " select tkey from m_userright_t where tkey='F011_' and userid='" & SysCheckData.SysMessageClass.UseId & "') "
        Rs = PubClass.GetDataReader(strSql)
        While Rs.Read
            'g_Rights = g_Rights & "," & "'" & Rs(1).ToString & "'"

            CobFacory.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)
        End While

        'g_Rights = Mid(g_Rights, 2)
        'If g_Rights = "" Then g_Rights = "''"
        Rs.Close()
    End Sub

    '控制文本框隻能輸入數字
    Private Sub TxtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            BtDSave_Click(sender, e)
        End If

    End Sub

    '按 Enter 帶出相關信息
    Private Sub TxtInvoice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInvoice.KeyPress

        If e.KeyChar = Chr(13) And Trim(TxtInvoice.Text) <> "" Then
            '“修改”時
            If StrflagB = "E" Then
                ReuseClass.StrInvos = Trim(TxtInvoice.Text)
                LoadData()
            End If
            '“新增”時
            If StrflagB = "N" Then
                SendKeys.Send("{tab}")
            End If
        End If

    End Sub

    Sub LoadData()
        Dim Strsql, StrInvs As String
        Dim Rs As SqlDataReader

        If ReuseClass.StrInvos = "" Then
            ContorState("NEW")
            TxtInvoice.Focus()
            Exit Sub
        End If

        '主窗體傳出來之InvoiceNo
        StrInvs = ReuseClass.StrInvos
        TxtInvoice.Text = ReuseClass.StrInvos
        Strsql = "select stateid from m_shipm_t where Invoice='" & StrInvs & "'"
        Rs = PubClass.GetDataReader(Strsql)
        If Rs.Read Then
            If Rs(0).ToString = "2" Then
                MessageBox.Show("該 Invoice [已確認出貨]，請先[駁回]!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Rs.Close()
                Exit Sub
            End If
        End If
        Rs.Close()
        'Invoice版本
        'Strsql = "select distinct b.factoryid +'-'+ b.shortname from m_InvoiceS_t a left join m_dcompany_t b " & _
        '         "on a.factoryid=b.factoryid where a.InvoiceJob='" & Trim(TxtInvoice.Text) & "'"
        '當前版本
        Strsql = "select distinct b.factoryid +'-'+ b.shortname,a.outtype from m_shipm_t a left join m_dcompany_t b " & _
                 "on a.factory=b.factoryid where a.Invoice='" & StrInvs & "'"
        Rs = PubClass.GetDataReader(Strsql)
        If Rs.Read Then
            CobFacory.Text = Rs(0).ToString
            If Rs(1).ToString = "O" Then
                CobOuttype.Text = "O-正常出貨"
            ElseIf Rs(1).ToString = "S" Then
                CobOuttype.Text = "S-樣品出貨"
            ElseIf Rs(1).ToString = "I" Then
                CobOuttype.Text = "I-內部領料"
            ElseIf Rs(1).ToString = "T" Then
                CobOuttype.Text = "T-其它出貨"
            End If
        End If
        Rs.Close()
        '加載數據到表格中
        LoadDataToDg(StrInvs)
    End Sub

    '加載數據到表格中
    Private Sub LoadDataToDg(ByVal StrInvoice As String)
        Dim Strsql As String
        Dim Rs As SqlDataReader
        DGItem.Rows.Clear()
        ''Invoice版本
        'Strsql = "select Partid,Shipqty,Userid,substring(convert(varchar,Intime,120),1,16) from m_InvoiceS_t where InvoiceJob='" & StrInvoice & "'"
        '當前版本
        Strsql = "select Partid,eqty,Userid,substring(convert(varchar,Intime,120),1,16) from m_shipdtotal_t where invoice='" & StrInvoice & "'"
        Rs = PubClass.GetDataReader(Strsql)
        While Rs.Read
            DGItem.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString)
        End While
        Rs.Close()
        DGcellclick()
    End Sub

    '單擊表格時發生
    Private Sub DGItem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGItem.CellClick
        DGcellclick()
    End Sub

    '單擊表格時發生
    Private Sub DGcellclick()
        If DGItem.Rows.Count = 0 Then
            TxtPartNo.Text = ""
            TxtQty.Text = ""
            Exit Sub
        End If
        TxtPartNo.Text = DGItem.Item(0, DGItem.CurrentCell.RowIndex).Value.ToString
        TxtQty.Text = DGItem.Item(1, DGItem.CurrentCell.RowIndex).Value.ToString
    End Sub

    '快捷鍵設定
    Private Sub FrmOtherOut_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.N AndAlso e.Alt Then
            BtNew_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            BtEdit_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            BtSave_Click(sender, e)
        ElseIf e.KeyCode = Keys.C AndAlso e.Alt Then
            BtCancel_Click(sender, e)
        ElseIf e.KeyCode = Keys.X AndAlso e.Alt Then
            BtExit_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter And Me.DGItem.Rows.Count > 0 Then
            BtDNew_Click(sender, e)
        End If

    End Sub

    ''取得並保存系統最大掃描單號
    'Private Function GetOutWhid() As String
    '    Dim strMaxID As String
    '    Dim Strsql As String
    '    Dim Str As String = ""
    '    Dim Rs As SqlDataReader
    '    Dim SvrDate As Date

    '    Try
    '        strMaxID = ""
    '        Strsql = " select getdate(), max(outwhid) from m_whoutm_t where " _
    '               & " substring(outwhid,3,6) = convert(varchar(6), getdate(), 12) "
    '        Rs = PubClass.GetDataReader(Strsql)

    '        If Rs.Read Then
    '            SvrDate = Rs(0)
    '            strMaxID = Rs(1).ToString
    '        End If

    '        If strMaxID = "" Then
    '            Str = "WO" & Format(SvrDate, "yyMMdd") & "0001"
    '        Else
    '            Str = "WO" & Mid((1 & Mid(strMaxID, 3)) + 1, 2)
    '        End If
    '        Rs.Close()
    '        PubClass.ExecSql("insert into m_whoutm_t(Outwhid,States,Outtype,Userid,Intime)values('" & Str & "','1','T','sz30914',getdate()) ")
    '    Catch ex As Exception
    '        SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOtherOut", "GetOutWhid", "sys")
    '        Str = ""
    '    End Try

    '    Return Str
    'End Function

    Private Sub TxtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInvoice.TextChanged
        DGItem.Rows.Clear()
        TxtPartNo.Text = ""
        TxtQty.Text = ""
    End Sub

    'check Invoice 的長度為10位，前2位是字母
    Function CheckInvoiceLength(ByVal StrInvoice As String) As Boolean
        Dim Inti As Integer '用於for 循環 

        If StrInvoice.Length <> 10 Then Return False
        StrInvoice.Substring(0, 4).ToCharArray(0, 1)
        For Inti = 0 To 1
            If Asc(StrInvoice(Inti)) < 65 Or Asc(StrInvoice(Inti)) > 90 Then
                Return False
            End If
        Next
        Return True

    End Function

    'Check 該Invoice 是否已經被“確認”
    Function InvoiceIsConfirm(ByVal StrInvoice As String) As Boolean
        Dim Rs As SqlDataReader

        Rs = PubClass.GetDataReader("select stateid from m_shipm_t where Invoice='" & StrInvoice & "'")
        If Rs.Read Then
            If Rs(0).ToString = "2" Then
                Rs.Close()
                Return True
            Else
                Rs.Close()
                Return False
            End If
        Else
            Rs.Close()
            Return False
        End If

    End Function

    Private Sub chkCreate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkCreate.KeyPress, CobFacory.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub CobOuttype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobOuttype.KeyPress
        BtSave_Click(sender, e)
    End Sub

    Private Sub TxtPartNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPartNo.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub BtExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExit.Click
        Me.Close()
    End Sub
End Class