Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports BarCodePrint
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports BarCodeScan


Public Class FrmMaterialInStorage_KS
    Dim strSql As String
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim btApp As BarTender.Application
    Dim MaxLen As Integer = 0
    'Declare a BarTender format variable 
    Dim indexFlag As Integer = -1
    Dim indexFlagWo As Integer = -1
    Dim btFormat As New BarTender.Format

    Private Sub FrmMaterialInStorage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

    Private Sub FrmMaterialInStorage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass
        btFormat = btApp.Formats.Open(Application.StartupPath & "\PrintFile\yanan.btw", False, String.Empty)
        Dim dt As SqlDataReader
        dt = Conn.GetDataReader("select SortName,SortType from m_Sortset_t where SortType='InvoiceType'")
        If dt.HasRows Then
            While dt.Read
                cobInvoType.Items.Add(dt!SortName.ToString())
            End While
        End If
        dt.Close()
        Conn.PubConnection.Close()
        dt = Conn.GetDataReader("select  Moid from  m_Mainmo_t where  finaly='N' and partid in('LB09LM016-1H','LB09LM017-1H','LB09LM018-1H')")
        If dt.HasRows Then
            While dt.Read
                TxtMoid.Items.Add(dt!Moid.ToString())
            End While
        End If
        dt.Close()
        Conn.PubConnection.Close()
        If radPallet.Checked Then
            TxtPalletId.Enabled = True
        End If


    End Sub

    Private Function CartonPrint(ByVal partid As String, ByVal cusid As String, ByVal deptid As String, ByVal lineid As String) As String

        Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""

        CartonPrint = ""
        PackArray.AvcPartid = partid 'AVC料號
        PackArray.CusName = cusid ' 客戶名稱
        PackArray.Deptid = deptid ' '部門
        PackArray.Lineid = lineid ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.TxtMoid.Text.Trim   '工單
        TimeSqlstr = "select getdate() as nowtime"
        Dim RecTable As SqlDataReader = Conn.GetDataReader(TimeSqlstr)
        While (RecTable.Read)
            ServerDate = CDate(RecTable("nowtime").ToString)
        End While
        PackArray.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
        PackArray.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
        RecTable.Close()
        RecTable.Dispose()
        PackArray.Qty = 1 ' 200 ' CartonScanOption.vReplaceQty
        'If PackArray.AvcPartid = "LB09LM016-1H" Or PackArray.AvcPartid = "LB09LM017-1H" Or PackArray.AvcPartid = "LB09LM018-1H" Then
        '    If PackBarCode.MarkJLabel(PackArray.ToArray, "A") Then
        '        CartonPrint = PackBarCode.JLabelStr ''生成箱號
        '    End If
        'Else
        '    If PackBarCode.MarkJLabel(PackArray.ToArray, "S") Then
        '        CartonPrint = PackBarCode.JLabelStr ''生成箱號
        '    End If
        'End If

        If PackBarCode.MarkJLabel(PackArray.ToArray, "S1") Then
            CartonPrint = PackBarCode.JLabelStr ''生成箱號
        End If

        'If PackBarCode.MarkJLabel(PackArray.ToArray, "S") Then
        '    CartonPrint = PackBarCode.JLabelStr ''生成箱號
        'End If
        ''  PackArray = Nothing
        ''  RepalceCartonPrint = Nothing


    End Function


#Region "判斷掃描條碼樣式是否正確"

    Private Function verfyBarCodeStyle(ByVal TxtSnStyle1 As String, ByVal TxtBarCode As String, ByVal TxtSnStyle2 As String) As Boolean


        Dim NewStylesStr As String = ""
        Dim SnStryle() As Char
        Dim SnBarCode() As Char
        Dim I As Byte
        Dim MultSnStyle As String()
        'If InStr(TxtSnStyle1, ";") > 0 Then
        '    MultSnStyle = (TxtSnStyle1 & ";" & TxtSnStyle2).Split(";")
        '    SnStryle = MultSnStyle(0)
        'Else
        SnStryle = TxtSnStyle1.ToCharArray
        'End If


        SnBarCode = TxtBarCode.ToCharArray
        For I = 0 To UBound(SnStryle)
            If SnStryle(I) = "*" Then
                SnBarCode(I) = "*"
            End If
            NewStylesStr = NewStylesStr + SnBarCode(I)
        Next
        If InStr(TxtSnStyle1, ";") > 0 Then
            For IFlag As Byte = 0 To MultSnStyle.Length - 1
                If MultSnStyle(IFlag) = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
                    verfyBarCodeStyle = True
                    Exit Function
                End If
            Next
        Else
            If TxtSnStyle2 = NewStylesStr OrElse TxtSnStyle1 = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
                verfyBarCodeStyle = True
                Exit Function
            End If
        End If

    End Function

#End Region

    Private Sub TxtPalletId_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletId.KeyPress
        If e.KeyChar = Chr(13) Then
            LblMsg.Text = ""
            If cobInvoType.Text = "" Then
                LblMsg.Text = "单据类型不能为空，请选择单据类型..."
                TxtPalletId.Clear()
                cobInvoType.Focus()
                Exit Sub
            End If
            If cobOutShNo.Text = "" And cobInvoType.Text <> "原材料批次上料" Then
                LblMsg.Text = "送货单号不能为空，请选择或输入送货单号..."
                TxtPalletId.Clear()
                cobOutShNo.Focus()
                Exit Sub
            End If
            If txtblMaterial.Text = "" Then
                LblMsg.Text = "料件编号不能为空，请输入料件编号..."
                TxtPalletId.Clear()
                txtblMaterial.Focus()
                Exit Sub
            End If
            If txtblQty.Text.Trim = "" Then
                LblMsg.Text = "入库/出库数量不能为空，请输入入库/出库数量..."
                TxtPalletId.Clear()
                txtblQty.Focus()
                Exit Sub
            End If
            If TxtPalletId.Text.Length <> MaxLen Then
                LblMsg.Text = "扫描的批次序号长度：" & TxtPalletId.Text.Length & "与编码原则的长度：" & MaxLen & "不符"
                TxtPalletId.Clear()
                TxtPalletId.Focus()
                Exit Sub
            End If
            'MessageBox.Show(Txtstyleone.Text & "-" & TxtStyleTwo.Text & "-" & TxtPalletId.Text)
            'MessageBox.Show(Txtstyleone.Text.Length & "-" & TxtStyleTwo.Text.Length & "-" & TxtPalletId.Text.Length)
            If verfyBarCodeStyle(Txtstyleone.Text.Trim, TxtPalletId.Text.Trim, TxtStyleTwo.Text.Trim) = False Then
                LblMsg.Text = "扫描的批次序号与标准样式不符..."
                TxtPalletId.Clear()
                TxtPalletId.Focus()
                Exit Sub
            End If

            If cobInvoType.SelectedIndex = 2 Then



                If Integer.Parse(txtblQty.Text.Trim) > 30 Then

                    LblMsg.Text = "条码的数量不能大于30个..."
                    txtblQty.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If


            End If

            If cobInvoType.Text = "原材料入库" Then

                If CInt(txtblQty.Text) > 1000 Then
                    LblMsg.Text = "上料数量一次不允许超过1000..."
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If


                Dim Outqty As Integer = 0
                strSql = "select sum(isnull(aa.PrintQty,0)) InQty  from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                            "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                            "bb.TypeDest in('Raw Cable') and  cc.Moid='" & TxtMoid.Text.Trim & "' "

                Dim re As DataTable = Conn.GetDataTable(strSql)

                If re.Rows.Count > 0 And re.Rows(0)(0).ToString() <> "" Then
                    Outqty = CType(re.Rows(0)("InQty"), Integer)
                End If

                If CInt(Outqty) + CInt(txtblQty.Text) > CInt(LblMoQty.Text.Trim()) Then
                    LblMsg.Text = "入库数量不允许超过工单生产数量..."
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If

                strSql = "INSERT INTO [m_MaterialLotInOut_t]([Moid],[Lotid],[DeliveryNo],[Ppartid],[Partdes],[InQty],[OutQty],[PrintQty]," & _
                "[MaterialStatus],[InvoiceStatus],[StorageNo],[FloorNo],[MaterialLocation],[InStorageType],[MaterialAttribute]," & _
                "[IsIQC],[InUserID],[Intime],[OutUserID],[Outtime],[Mark1])VALUES('" & TxtMoid.Text.Trim & "', '" & TxtPalletId.Text.Trim & "','" & cobOutShNo.Text.Trim & "'," & _
                "'" & txtblMaterial.Text.Split("(")(0).Trim & "',NULL,'" & txtblQty.Text.Trim & "','0','0','N',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & SysMessageClass.UseId & "',getdate(),NULL,NULL,NULL)"

                Try
                    Conn.ExecSql(strSql)
                    dgScanData.Rows.Add(False, cobInvoType.Text, cobOutShNo.Text, TxtPalletId.Text, txtblMaterial.Text, txtblQty.Text, "0", SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), "0", "", "")

                    'Dim partid As String = "" : Dim lineid As String = "" : Dim deptid As String = "" : Dim cusid As String = "" : Dim Moqty As Integer = 0
                    'Dim BarFile As New StringBuilder() : Dim Sqlstr As New StringBuilder()

                    'Dim mRead As SqlDataReader = Conn.GetDataReader("select partid,lineid,deptid,cusid,Moqty from m_mainmo_t where moid='" & TxtMoid.Text.Trim & "' ")
                    'If mRead.HasRows Then
                    '    While mRead.Read
                    '        partid = mRead!partid
                    '        lineid = mRead!lineid
                    '        deptid = mRead!deptid
                    '        cusid = mRead!cusid
                    '        Moqty = mRead!Moqty
                    '    End While
                    'Else
                    '    mRead.Close()
                    '    Conn.PubConnection.Close()
                    '    LblMsg.Text = "该工单在系统中不存在..."
                    '    Exit Sub
                    'End If
                    'mRead.Close()
                    'Conn.PubConnection.Close()

                    strSql = "select isnull(sum(aa.InQty-isnull(aa.PrintQty,0)),0) InQty,bb.TypeDest from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                             "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                             "bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim & "' group by bb.typedest"


                    Dim dt As DataTable = Conn.GetDataTable(strSql)
                    LblRawQty.Text = "0"
                    If dt.Rows.Count = 3 Then '满足三科料已经上料

                        dt.DefaultView.Sort = "InQty asc"
                        Dim res As DataTable = dt.DefaultView.ToTable()
                        Dim maxPrintQty As Integer = CType(res.Rows(0)("InQty"), Integer)

                        LblRawQty.Text = maxPrintQty
                    End If

                    LabCartCoun.Text = CType(LabCartCoun.Text.Trim, Integer) + CType(txtblQty.Text.Trim, Integer)
                    txtblQty.Clear()
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                End Try
                Conn.PubConnection.Close()
            ElseIf cobInvoType.Text = "原材料批次上料" Then
                If TxtMoid.Text.Trim = "" Then
                    LblMsg.Text = "生产领料时，工单编号不能为空..."
                    TxtPalletId.Clear()
                    TxtMoid.Focus()
                    Exit Sub
                End If
                If CInt(txtblQty.Text) > 1000 Then
                    LblMsg.Text = "上料数量一次不允许超过1000..."
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If


                Dim partid As String = "" : Dim lineid As String = "" : Dim deptid As String = "" : Dim cusid As String = "" : Dim Moqty As Integer = 0
                Dim BarFile As New StringBuilder() : Dim ReturnBar As String : Dim Sqlstr As New StringBuilder()

                Dim mRead As SqlDataReader = Conn.GetDataReader("select partid,lineid,deptid,cusid,Moqty from m_mainmo_t where moid='" & TxtMoid.Text.Trim & "' ")
                If mRead.HasRows Then
                    While mRead.Read
                        partid = mRead!partid
                        lineid = mRead!lineid
                        deptid = mRead!deptid
                        cusid = mRead!cusid
                        Moqty = mRead!Moqty
                    End While
                Else
                    mRead.Close()
                    Conn.PubConnection.Close()
                    LblMsg.Text = "该工单在系统中不存在..."
                    Exit Sub
                End If
                mRead.Close()
                Conn.PubConnection.Close()

                Dim Outqty As Integer = 0
                'mRead = Conn.GetDataReader("select isnull(sum(InQty),0) InQty from m_MaterialLotInOut_t where moid='" & TxtMoid.Text.Trim & "' and  Ppartid='" & txtblMaterial.Text.Split("(")(0) & "'")
                'mRead = Conn.GetDataReader("select isnull(sum(InQty),0) InQty from m_MaterialLotInOut_t where moid='" & TxtMoid.Text.Trim & "' and  Ppartid='" & txtblMaterial.Text.Split("(")(0) & "'")
                Dim rawCableString = "select isnull(sum(aa.InQty),0) InQty from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                                  " where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                                  " bb.TypeDest='Raw Cable' and cc.Moid='" & TxtMoid.Text.Trim & "'"
                mRead = Conn.GetDataReader(rawCableString)
                If mRead.HasRows Then
                    While mRead.Read
                        Outqty = mRead!InQty
                        LabCartCoun.Text = Outqty
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                If CInt(Outqty) + CInt(txtblQty.Text) > CInt(Moqty) Then
                    LblMsg.Text = "上料数量不允许超过工单生产数量..."
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If

                Dim SumInQty As Integer = 0
                Dim PartStr As String = ""
                ' Dim MySql As String = "select top 1 ppartid, SUM(InQty) InSumQty from m_MaterialLotInOut_t  where Moid='" & TxtMoid.Text.Trim & "' and ppartid in" & _
                ' "('004-031H-9086', '004-031H-9087','004-031H-9089', '004-031H-9090') group by Ppartid order by InSumQty asc"
                Dim MySql As String = "select top 1 aa.ppartid, SUM(InQty) InSumQty from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                                     "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                                    "bb.TypeDest in('Recept Boot','Recept Faceplate','USB-C Faceplate','USB-C Boot','ConnectorM','ConnectorG') " & _
                                     "and cc.Moid='" & TxtMoid.Text.Trim & "' group by aa.ppartid order by InSumQty asc"
                mRead = Conn.GetDataReader(MySql)
                If mRead.HasRows Then
                    While mRead.Read
                        SumInQty = mRead!InSumQty
                        PartStr = mRead!ppartid
                        LblQPartid.Text = PartStr
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                'MessageBox.Show("已经上料数量：" & Outqty & "  当前上料数量：" & txtblQty.Text & "最小数量：" & SumInQty)
                If CInt(Outqty) + CInt(txtblQty.Text) > CInt(SumInQty) Then
                    LblMsg.Text = "Raw Cable上料的总数量不允许超过4个部件批次的最小数量：" & SumInQty
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If

                For i As Integer = 1 To CInt(txtblQty.Text)
                    ReturnBar = CartonPrint(partid, cusid, deptid, lineid)
                    If i = CInt(txtblQty.Text) Then
                        BarFile.Append("""" & ReturnBar & """")
                    Else
                        BarFile.Append("""" & ReturnBar & """" & vbNewLine)
                    End If

                    Sqlstr.Append("INSERT INTO [M_AssemblyLotSn_t]([VPPID],[PPID],[Userid],[Intime],Mark1)VALUES('" & ReturnBar & "'" & _
                                  ",'" & Me.TxtPalletId.Text & "','" & SysMessageClass.UseId & "',getdate(),'" & txtblMaterial.Text.Split("(")(0) & "')" & vbNewLine)
                    Sqlstr.Append("insert into m_BarRecordValue_t(barcodeSNID,Printpc,moid,partid,intime)values('" & ReturnBar & "'," & _
                                  "'" & My.Computer.Name & "','" & TxtMoid.Text & "','" & partid & "',getdate() )" & vbNewLine)
                Next
                Sqlstr.Append("INSERT INTO [m_MaterialLotInOut_t](Moid,[Lotid],[DeliveryNo],[Ppartid],[Partdes],[InQty],[OutQty],[PrintQty]," & _
               "[MaterialStatus],[InvoiceStatus],[StorageNo],[FloorNo],[MaterialLocation],[InStorageType],[MaterialAttribute]," & _
               "[IsIQC],[InUserID],[Intime],[OutUserID],[Outtime],[Mark1])VALUES('" & TxtMoid.Text & "','" & TxtPalletId.Text.Trim & "','" & cobOutShNo.Text.Trim & "'," & _
               "'" & txtblMaterial.Text.Split("(")(0) & "',NULL,'" & txtblQty.Text.Trim & "','0','0','N',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & SysMessageClass.UseId & "',getdate(),NULL,NULL,NULL)" & vbNewLine)
                Try
                    Conn.ExecSql(Sqlstr.ToString)
                    LabCartCoun.Text = CInt(LabCartCoun.Text) + CInt(txtblQty.Text)
                    BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                    File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
                    FileToBarCodePrint("")
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    Conn.PubConnection.Close()
                    MessageBox.Show(ex.Message)
                End Try

            ElseIf cobInvoType.Text = "原材料出库" Then
                If TxtMoid.Text.Trim = "" Then
                    LblMsg.Text = "生产领料时，工单编号不能为空..."
                    TxtPalletId.Clear()
                    TxtMoid.Focus()
                    Exit Sub
                End If

                Dim pOutqty As Integer = 0
                Dim mRead As SqlDataReader = Conn.GetDataReader("select isnull(sum(InQty),0) InQty from m_MaterialLotInOut_t where moid='" & TxtMoid.Text.Trim & "' and  Ppartid='" & txtblMaterial.Text.Split("(")(0) & "'")
                If mRead.HasRows Then
                    While mRead.Read
                        pOutqty = mRead!InQty
                        LabCartCoun.Text = pOutqty
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                'Dim Moqty As Integer = 0
                'mRead = Conn.GetDataReader("select Moqty from m_mainmo_t where moid='" & TxtMoid.Text.Trim & "' ")
                'If mRead.HasRows Then
                '    While mRead.Read
                '    End While
                'Else
                '    mRead.Close()
                '    Conn.PubConnection.Close()
                '    LblMsg.Text = "该工单在系统中不存在..."
                '    Exit Sub
                'End If
                'mRead.Close()
                'Conn.PubConnection.Close()
                'MessageBox.Show(pOutqty & "-" & txtblQty.Text & "-" & LblMoQty.Text)
                If CInt(pOutqty) + CInt(txtblQty.Text) > CInt(LblMoQty.Text) Then
                    LblMsg.Text = "上料数量一次不允许超过工单数量..."
                    TxtPalletId.Clear()
                    txtblQty.Focus()
                    Exit Sub
                End If

                If ChkInMessage.Checked = True Then
                    strSql = "INSERT INTO [m_MaterialLotInOut_t]([Lotid],[Moid],[DeliveryNo],[Ppartid],[Partdes],[InQty],[OutQty]," & _
                           "[MaterialStatus],[InvoiceStatus],[StorageNo],[FloorNo],[MaterialLocation],[InStorageType],[MaterialAttribute]," & _
                           "[IsIQC],[InUserID],[Intime],[OutUserID],[Outtime],[Mark1])VALUES('" & TxtPalletId.Text.Trim & "','" & TxtMoid.Text & "','" & cobOutShNo.Text.Trim & "'," & _
                            "'" & txtblMaterial.Text.Split("(")(0) & "',NULL,'" & txtblQty.Text.Trim & "','0','N',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & SysMessageClass.UseId & "',getdate(),NULL,NULL,NULL)"
                    Try
                        Conn.ExecSql(strSql)
                        dgScanData.Rows.Add(False, cobInvoType.Text, cobOutShNo.Text, TxtPalletId.Text, txtblMaterial.Text, txtblQty.Text, "0", SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), "0", "", "")
                        LabCartCoun.Text = CInt(LabCartCoun.Text) + CInt(txtblQty.Text)
                        'LblRawQty.Text = CInt(LblRawQty.Text) - CInt(txtblQty.Text)
                        txtblQty.Clear()
                        TxtPalletId.Clear()
                        txtblQty.Focus()
                        Conn.PubConnection.Close()
                    Catch ex As Exception
                        Conn.PubConnection.Close()
                        LblMsg.Text = ex.Message
                    End Try
                    Exit Sub
                End If

                'Dim dt As DataTable
                'Dim mRead As SqlDataReader
                Dim sMatStatus As String
                Dim inQty As Integer
                Dim outQty As Integer
                Dim outTotal As Integer
                Dim strInuser As String = ""
                Dim strIntime As String = ""
                mRead = Conn.GetDataReader("select MaterialStatus,InQty,OutQty,InUserID,Intime from m_MaterialLotInOut_t where Lotid = '" & TxtPalletId.Text.Trim & "' and DeliveryNo='" & cobOutShNo.Text.Trim & "' and Ppartid='" & txtblMaterial.Text.Trim & "'")
                If mRead.HasRows Then
                    While mRead.Read
                        sMatStatus = mRead!MaterialStatus
                        inQty = mRead!InQty
                        outQty = mRead!OutQty
                        outTotal = outQty + CInt(txtblQty.Text)
                        strInuser = mRead!InUserID
                        strIntime = mRead!Intime
                    End While
                    mRead.Close()
                    Conn.PubConnection.Close()
                    If inQty = outQty Then
                        LblMsg.Text = "该送货单下的该批次已经出库，请确认..."
                        Exit Sub
                    Else
                        If CInt(txtblQty.Text) > inQty Then
                            LblMsg.Text = "该批次的出库数量大于入库数量，无法出库，请确认..."
                            Exit Sub
                        ElseIf outTotal > inQty Then
                            LblMsg.Text = "该批次的当前出库数量加上之前的出库数量大于入库数量，无法出库，请确认..."
                            Exit Sub
                        ElseIf outTotal = inQty Then
                            strSql = "update m_MaterialLotInOut_t set OutQty='" & outTotal & "',MaterialStatus='Y',OutUserID='" & SysMessageClass.UseId & "',Outtime= getdate() where Lotid = '" & TxtPalletId.Text.Trim & "' and DeliveryNo='" & cobOutShNo.Text.Trim & "' and Ppartid='" & txtblMaterial.Text.Trim & "'"
                        ElseIf outTotal < inQty Then
                            Dim response As MsgBoxResult

                            response = MsgBox("该批次的当前出库数量小于入库数量，是否需要出库？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "提示信息")

                            If response = 6 Then
                                strSql = "update m_MaterialLotInOut_t set OutQty='" & outTotal & "',OutUserID='" & SysMessageClass.UseId & "',Outtime= getdate() where Lotid = '" & TxtPalletId.Text.Trim & "' and DeliveryNo='" & cobOutShNo.Text.Trim & "' and Ppartid='" & txtblMaterial.Text.Trim & "'"
                            ElseIf response = 7 Then
                                txtblQty.Clear()
                                TxtPalletId.Clear()
                                txtblQty.Focus()
                                Exit Sub
                            End If

                        End If
                        Try
                            Conn.ExecSql(strSql)
                            dgScanData.Rows.Add(False, cobInvoType.Text, cobOutShNo.Text, TxtPalletId.Text, txtblMaterial.Text, inQty, "0", strInuser, strIntime, outTotal, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"))
                            txtblQty.Clear()
                            TxtPalletId.Clear()
                            txtblQty.Focus()
                        Catch ex As Exception
                            Conn.PubConnection.Close()
                            MsgBox(ex.Message)
                        End Try
                        mRead.Close()
                        Conn.PubConnection.Close()
                    End If
                Else
                    LblMsg.Text = "没有找到该送货单下的该批次入库信息，无法出库，请确认..."
                    Exit Sub
                End If

            End If
        End If
    End Sub

#Region "条码打印方法更新，优化速度"

    Private Sub FileToBarCodePrint(ByVal pFilePath As String)


        'btFormat = btApp.Formats.Open(Application.StartupPath & "\PrintFile\yanan.btw", False, String.Empty)

        btFormat.Print("", False, -1, Nothing)

        'btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)


        'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)



    End Sub

#End Region

    Private Sub cobInvoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobInvoType.SelectedIndexChanged

        'cobOutShNo.Focus()




        If cobInvoType.Items.IndexOf(cobInvoType.Text) = indexFlag Then



            Exit Sub

        End If
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()

        If CartonScanOption.CheckStr = True Then


            indexFlag = cobInvoType.Items.IndexOf(cobInvoType.Text)
        Else

            cobInvoType.SelectedIndex = indexFlag

        End If


    End Sub

    Private Sub cobOutShNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobOutShNo.SelectedIndexChanged
        InitControlStatus()
        txtblMaterial.Focus()
        txtblUser.Text = SysMessageClass.UseId
    End Sub

    Private Sub cobOutShNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobOutShNo.KeyPress
        cobOutShNo.DroppedDown = True
        If e.KeyChar = Chr(13) Then
            If cobInvoType.Text = "" Then
                LblMsg.Text = "单据类型不能为空，请选择单据类型..."
                Exit Sub
            End If
            cobOutShNo_SelectedIndexChanged(sender, e)
        End If
    End Sub


    Private Sub ToolInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolInit.Click
        InitControlStatus()

    End Sub

    Private Sub InitControlStatus()
        txtblMaterial.Items.Clear()
        txtblQty.Clear()
        txtblUser.Clear()
        TxtPalletId.Clear()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click
        Me.Close()
    End Sub

    Private Sub TxtMoid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoid.SelectedIndexChanged


        If TxtMoid.Items.IndexOf(TxtMoid.Text) = indexFlagWo Then



            Exit Sub

        End If


        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()

        If CartonScanOption.CheckStr = True Then


            indexFlagWo = TxtMoid.Items.IndexOf(TxtMoid.Text)
        Else

            TxtMoid.SelectedIndex = indexFlagWo

        End If



        Dim mReader As SqlDataReader = Conn.GetDataReader("select Moqty from m_mainmo_t where moid='" & TxtMoid.Text & "'")
        If mReader.HasRows Then
            While mReader.Read
                LblMoQty.Text = mReader!Moqty
            End While
        End If
        mReader.Close()

        txtblMaterial.SelectedIndex = -1
        txtblMaterial.Items.Clear()

        'mReader = Conn.GetDataReader("select TAvcPart+'('+TypeDest+')' from m_PartContrast_t a,m_Mainmo_t b where b.PartID=a.PAvcPart and b.Moid='" & TxtMoid.Text & "'")
        Dim stringSql = "select TAvcPart+'('+TypeDest+')'  from m_PartContrast_t a,m_Mainmo_t b where b.PartID=a.PAvcPart and b.Moid='" & TxtMoid.Text & "'"
        'If cobInvoType.Items.IndexOf(cobInvoType.Text) = 1 Then

        '    stringSql = stringSql + "and TypeDest in('ConnectorM','ConnectorG')"

        'ElseIf cobInvoType.Items.IndexOf(cobInvoType.Text) = 2 Then

        '    stringSql = stringSql + "and TypeDest='Raw Cable'"

        'End If

        stringSql = stringSql + "and TypeDest in('ConnectorM','ConnectorG','Raw Cable')"

        mReader = Conn.GetDataReader(stringSql)
        If mReader.HasRows Then
            While mReader.Read
                txtblMaterial.Items.Add(mReader(0).ToString())

            End While
        End If
        mReader.Close()
        Conn.PubConnection.Close()

    End Sub

    Private Sub txtblMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtblMaterial.SelectedIndexChanged

        Try

       
        Dim RuleID As String = ""
        Dim mReader As SqlDataReader = Conn.GetDataReader("select CodeRuleID from m_PartPack_t where partid='" & txtblMaterial.Text.Split("(")(0).ToString & "' and usey='Y' and Packid='S'")
        If mReader.HasRows Then
            While mReader.Read
                RuleID = mReader!CodeRuleID
            End While
        Else
            mReader.Close()
            Conn.PubConnection.Close()
            LblMsg.Text = "该料号没有维护编码原则，不能进行批次扫描..."
            Exit Sub
        End If
        mReader.Close()
        Conn.PubConnection.Close()

        Dim SqlStr As String = "declare @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1=''" & _
" set @SnStyle2=''  set @Gflen='' execute m_StyleShow_p_AssembleSta '" & txtblMaterial.Text.Split("(")(0).ToString & "','" & RuleID & "'" & _
",'" & Now.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output select @SnStyle1,@SnStyle2,@Gflen"

        mReader = Conn.GetDataReader(SqlStr)
        If mReader.HasRows Then
            While mReader.Read
                Txtstyleone.Text = mReader.GetString(0).ToString.Trim
                TxtStyleTwo.Text = mReader.GetString(1).ToString.Trim
                MaxLen = TxtStyleTwo.Text.Trim.Length
            End While
        Else
            mReader.Close()
            Conn.PubConnection.Close()
            LblMsg.Text = "未生成标准样式，不允许扫描..."
            Exit Sub
        End If
        mReader.Close()
        Conn.PubConnection.Close()

        If cobInvoType.Text = "原材料入库" Then

            Dim Outqty As Integer = 0
            Dim rawCableString = "select isnull(sum(aa.PrintQty),0) InQty from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                                    " where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                                    " bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and cc.Moid='" & TxtMoid.Text.Trim & "' and aa.ppartid='" & txtblMaterial.Text.Split("(")(0).Trim & "'"

            Dim dt As DataTable = Conn.GetDataTable(rawCableString)

                LabCartCoun.Text = "0"

            If dt.Rows.Count > 0 And dt.Rows(0)(0).ToString() <> "" Then

                LabCartCoun.Text = dt.Rows(0)(0).ToString()
            End If




            strSql = "select isnull(aa.InQty,0) inqty,isnull(aa.PrintQty,0) printqty,aa.lotid,aa.ppartid,aa.deliveryno,aa.intime from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                         "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                         "bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim & "' and aa.ppartid='" & txtblMaterial.Text.Split("(")(0).Trim & "'"

            dt = Conn.GetDataTable(strSql)

            dgScanData.Rows.Clear()

            For Each dr In dt.Rows

                dgScanData.Rows.Add(False, cobInvoType.Text, dr("deliveryno").ToString(), dr("lotid").ToString(), txtblMaterial.Text, dr("inqty").ToString(), dr("printqty").ToString(), SysMessageClass.UseId, dr("intime").ToString(), "0", "", "")
            Next


            strSql = "select isnull(sum(aa.InQty-isnull(aa.PrintQty,0)),0) InQty,bb.TypeDest from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                   "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                   "bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim & "' group by bb.typedest"


            dt = Conn.GetDataTable(strSql)
            LblRawQty.Text = "0"

            If dt.Rows.Count = 3 Then '三科料已经上料
                dt.DefaultView.Sort = "InQty asc"
                Dim res As DataTable = dt.DefaultView.ToTable()

                LblRawQty.Text = res.Rows(0)("InQty")
            End If

        Else
            ' If txtblMaterial.Text = "015-601H-1692(Raw Cable)" Then
            If txtblMaterial.Text.IndexOf("(Raw Cable)") > -1 Then
                Dim Outqty As Integer = 0
                ' mReader = Conn.GetDataReader("select isnull(sum(InQty),0) InQty from m_MaterialLotInOut_t where moid='" & TxtMoid.Text.Trim & "' and  Ppartid='" & txtblMaterial.Text.Split("(")(0) & "'")
                Dim rawCableString = "select isnull(sum(aa.InQty),0) InQty from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                                    " where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                                    " bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and cc.Moid='" & TxtMoid.Text.Trim & "'"
                mReader = Conn.GetDataReader(rawCableString)
                If mReader.HasRows Then
                    While mReader.Read
                        Outqty = mReader!InQty
                        LabCartCoun.Text = Outqty
                    End While
                End If
                mReader.Close()
                Conn.PubConnection.Close()

                Dim SumInQty As Integer = 0
                Dim partStr As String = ""
                'Dim MySql As String = "select top 1 ppartid, SUM(InQty) InSumQty from m_MaterialLotInOut_t  where Moid='" & TxtMoid.Text.Trim & "' and ppartid in" & _
                ' "('004-031H-9086', '004-031H-9087','004-031H-9089', '004-031H-9090') group by Ppartid order by InSumQty asc"
                Dim MySql As String = "select top 1 aa.ppartid, SUM(InQty) InSumQty from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                                      "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                                     "bb.TypeDest in('Recept Boot','Recept Faceplate','USB-C Faceplate','USB-C Boot','ConnectorM','ConnectorG') " & _
                                      "and cc.Moid='" & TxtMoid.Text.Trim & "' group by aa.ppartid order by InSumQty asc"
                mReader = Conn.GetDataReader(MySql)
                If mReader.HasRows Then
                    While mReader.Read
                        SumInQty = mReader!InSumQty
                        partStr = mReader!ppartid
                    End While
                End If
                mReader.Close()
                Conn.PubConnection.Close()
                LblRawQty.Text = CInt(SumInQty) - CInt(Outqty)
                LblQPartid.Text = partStr
            End If
        End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try


            If txtPerPrintQty.Text.Trim() = "0" Then
                MessageBox.Show("请输入每次打印数量", "提示信息")
                txtPerPrintQty.Focus()
                Return
            End If

            If CType(txtPerPrintQty.Text.Trim(), Integer) > CType(LblRawQty.Text.Trim, Integer) Then
                MessageBox.Show("每次打印数量不能大于最大可打印数量", "提示信息")
                txtPerPrintQty.Focus()
                Return
            End If

            Dim partid As String = "" : Dim lineid As String = "" : Dim deptid As String = "" : Dim cusid As String = "" : Dim Moqty As Integer = 0
            Dim BarFile As New StringBuilder() : Dim Sqlstr As New StringBuilder()

            Dim mRead As SqlDataReader = Conn.GetDataReader("select partid,lineid,deptid,cusid,Moqty from m_mainmo_t where moid='" & TxtMoid.Text.Trim & "' ")
            If mRead.HasRows Then
                While mRead.Read
                    partid = mRead!partid
                    lineid = mRead!lineid
                    deptid = mRead!deptid
                    cusid = mRead!cusid
                    Moqty = mRead!Moqty
                End While
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                LblMsg.Text = "该工单在系统中不存在..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()

            strSql = "select isnull(sum(aa.InQty-isnull(aa.PrintQty,0)),0) InQty,bb.TypeDest from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                     "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                     "bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim & "' group by bb.typedest"


            Dim dt As DataTable = Conn.GetDataTable(strSql)

            If dt.Rows.Count = 3 Then '三科料已经上料

                dt.DefaultView.Sort = "InQty asc"
                Dim res As DataTable = dt.DefaultView.ToTable()

                Dim maxPrintQty As Integer = CType(res.Rows(0)("InQty"), Integer)

                maxPrintQty = IIf(CType(txtPerPrintQty.Text.Trim(), Integer) > CType(res.Rows(0)("InQty"), Integer), CType(res.Rows(0)("InQty"), Integer), CType(txtPerPrintQty.Text.Trim(), Integer))

                Dim barcode As String
                ' LblRawQty.Text = maxPrintQty

                Dim dConnectorM As DataTable = Conn.GetDataTable("select aa.InQty-isnull(aa.PrintQty,0) sumQty,aa.lotid ,aa.itemid ,aa.ppartid from m_MaterialLotInOut_t aa," & _
                                                                  "  m_PartContrast_t bb,m_Mainmo_t cc where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid " & _
                                                                   "  and cc.PartID=bb.PAvcPart and bb.TypeDest in('ConnectorM') " & _
                                                                    " and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim() & "' order by aa.intime asc")

                Dim dConnectorG As DataTable = Conn.GetDataTable("select aa.InQty-isnull(aa.PrintQty,0) sumQty,aa.lotid,aa.itemid ,aa.ppartid from m_MaterialLotInOut_t aa," & _
                                                                  "  m_PartContrast_t bb,m_Mainmo_t cc where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid" & _
                                                                   "  and cc.PartID=bb.PAvcPart and bb.TypeDest in('ConnectorG') " & _
                                                                    " and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim() & "' order by aa.intime asc")

                Dim dRaw As DataTable = Conn.GetDataTable("select aa.InQty-isnull(aa.PrintQty,0) sumQty,aa.lotid ,aa.itemid ,aa.ppartid from m_MaterialLotInOut_t aa," & _
                                                          "  m_PartContrast_t bb,m_Mainmo_t cc where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid " & _
                                                           "  and cc.PartID=bb.PAvcPart and bb.TypeDest in('Raw Cable') " & _
                                                          "   and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim() & "' order by aa.intime asc")

                strSql = ""

                Dim t1 As Integer = 0
                Dim t2 As Integer = 0
                Dim t3 As Integer = 0
                Dim count1 As Integer = 0
                Dim count2 As Integer = 0
                Dim count3 As Integer = 0

                ' Dim updateSql As String = ""
                Dim tempQty1 As Integer = 0
                Dim insertFlag1 As Boolean = True
                Dim tempQty2 As Integer = 0
                Dim insertFlag2 As Boolean = True
                Dim tempQty3 As Integer = 0
                Dim insertFlag3 As Boolean = True


                tempQty1 = maxPrintQty
                tempQty2 = maxPrintQty
                tempQty3 = maxPrintQty

                For i As Integer = 1 To maxPrintQty
                    barcode = CartonPrint(partid, cusid, deptid, lineid)
                    If i = maxPrintQty Then
                        BarFile.Append("""" & barcode & """")
                    Else
                        BarFile.Append("""" & barcode & """" & vbNewLine)
                    End If

                    If CType(dConnectorG.Rows(t1)("sumQty"), Integer) >= tempQty1 Then

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                  ",'" & dConnectorG.Rows(t1)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dConnectorG.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag1 Then
                            Sqlstr.Append("update m_MaterialLotInOut_t set printqty=printqty+" & tempQty1 & " where itemid='" & dConnectorG.Rows(t1)("itemid") & "'" & vbNewLine)
                            insertFlag1 = False
                        End If
                    ElseIf CType(dConnectorG.Rows(t1)("sumQty"), Integer) < tempQty1 Then

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                ",'" & dConnectorG.Rows(t1)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dConnectorG.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag1 Then
                            Sqlstr.Append("  update m_MaterialLotInOut_t set printqty=printqty+" & dConnectorG.Rows(t1)("sumQty") & " where itemid='" & dConnectorG.Rows(t1)("itemid") & "'" & vbNewLine)
                            insertFlag1 = False
                        End If

                        count1 = count1 + 1

                        If count1 = CType(dConnectorG.Rows(t1)("sumQty"), Integer) Then
                            'updateSql = updateSql + "  update m_MaterialLotInOut_t set printqty=printqty+" & dConnectorG.Rows(t1)("sumQty") & " where itemid='" & dConnectorG.Rows(t1)("itemid")
                            If dConnectorG.Rows.Count - 1 > t1 Then
                                t1 = t1 + 1
                                insertFlag1 = True
                            End If

                            tempQty1 = maxPrintQty - i
                            count1 = 0

                        End If
                    End If


                    If CType(dConnectorM.Rows(t2)("sumQty"), Integer) >= tempQty2 Then 'ConnectorM material

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                  ",'" & dConnectorM.Rows(t2)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dConnectorM.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag2 Then
                            Sqlstr.Append("update m_MaterialLotInOut_t set printqty=printqty+" & tempQty2 & " where itemid='" & dConnectorM.Rows(t2)("itemid") & "'" & vbNewLine)
                            insertFlag2 = False
                        End If
                    ElseIf CType(dConnectorM.Rows(t2)("sumQty"), Integer) < tempQty2 Then

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                ",'" & dConnectorM.Rows(t2)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dConnectorM.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag2 Then
                            Sqlstr.Append("  update m_MaterialLotInOut_t set printqty=printqty+" & dConnectorM.Rows(t2)("sumQty") & " where itemid='" & dConnectorM.Rows(t2)("itemid") & "'" & vbNewLine)
                            insertFlag2 = False
                        End If

                        count2 = count2 + 1

                        If count2 = CType(dConnectorM.Rows(t2)("sumQty"), Integer) Then
                            If dConnectorM.Rows.Count - 1 > t2 Then
                                t2 = t2 + 1
                                insertFlag2 = True
                            End If
                            tempQty2 = maxPrintQty - i
                            count2 = 0
                        End If
                    End If

                    If CType(dRaw.Rows(t3)("sumQty"), Integer) >= tempQty3 Then

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                  ",'" & dRaw.Rows(t3)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dRaw.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag3 Then
                            Sqlstr.Append("update m_MaterialLotInOut_t set printqty=printqty+" & tempQty3 & " where itemid='" & dRaw.Rows(t3)("itemid") & "'" & vbNewLine)
                            insertFlag3 = False
                        End If
                    ElseIf CType(dRaw.Rows(t3)("sumQty"), Integer) < tempQty3 Then

                        Sqlstr.Append("INSERT INTO [M_AssemblyLotSnMultip_t]([VPPID],[LOTID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                                ",'" & dRaw.Rows(t3)("lotid") & "','" & SysMessageClass.UseId & "',getdate(),'" & dRaw.Rows(t1)("ppartid") & "')" & vbNewLine)
                        If insertFlag3 Then
                            Sqlstr.Append("  update m_MaterialLotInOut_t set printqty=printqty+" & dRaw.Rows(t3)("sumQty") & " where itemid='" & dRaw.Rows(t3)("itemid") & "'" & vbNewLine)
                            insertFlag3 = False
                        End If

                        count3 = count3 + 1
                        If count3 = CType(dRaw.Rows(t3)("sumQty"), Integer) Then
                            If dRaw.Rows.Count - 1 > t3 Then
                                t3 = t3 + 1
                                insertFlag3 = True
                            End If
                            tempQty3 = maxPrintQty - i
                            count3 = 0

                        End If
                    End If

                    'Sqlstr.Append("INSERT INTO [M_AssemblyLotSn_t]([VPPID],[PPID],[Userid],[Intime],Mark1)VALUES('" & barcode & "'" & _
                    '              ",'" & Me.TxtPalletId.Text & "','" & SysMessageClass.UseId & "',getdate(),'" & txtblMaterial.Text.Split("(")(0) & "')" & vbNewLine)

                    Sqlstr.Append("insert into m_BarRecordValue_t(barcodeSNID,Printpc,moid,partid,intime)values('" & barcode & "'," & _
                                      "'" & My.Computer.Name & "','" & TxtMoid.Text & "','" & partid & "',getdate() )" & vbNewLine)
                Next
                Conn.ExecSql(Sqlstr.ToString)
                'LabCartCoun.Text = CInt(LabCartCoun.Text) + CInt(txtblQty.Text)

                BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
                FileToBarCodePrint("")


                strSql = "select isnull(sum(aa.InQty-isnull(aa.PrintQty,0)),0) InQty,bb.TypeDest from m_MaterialLotInOut_t aa,m_PartContrast_t bb,m_Mainmo_t cc " & _
                     "where aa.Ppartid=bb.TAvcPart and aa.Moid=cc.Moid and cc.PartID=bb.PAvcPart and " & _
                     "bb.TypeDest in('Raw Cable','ConnectorM','ConnectorG') and (aa.InQty-isnull(aa.PrintQty,0))>0 and cc.Moid='" & TxtMoid.Text.Trim & "' group by bb.typedest"


                dt = Conn.GetDataTable(strSql)

                LblRawQty.Text = "0"

                If dt.Rows.Count = 3 Then '三科料已经上料

                    dt.DefaultView.Sort = "InQty asc"
                    res = dt.DefaultView.ToTable()

                    LblRawQty.Text = CType(res.Rows(0)("InQty"), Integer)
                End If

            Else
                MessageBox.Show("没有完成上料不能打印，必须上足三颗料", "提示信息")
                Return
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

   
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then

                Dim s As New FrmReprintBarcode

                s.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class