Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports UIHandler
Imports MainFrame
Imports System.IO

'э纗筁祘 by anday_xu Date:2010-06-21  竒ЧΘ

Public Class FrmL01PackQuery
    Private ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()
    Private Rs As SqlDataReader
    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    Private g_Factory As String

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

#Region "酶datagridview虫じ,匡い埃礘翴"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub FrmPackQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DtStar.Value = Now().AddDays(-7).ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        FillComboLine(CobMo)
        ' FillComboLine(CobDept)
        FillComboLine(CobPart)
        ' FillComboLine(CboCus)
        FillComboLine(CobLine)
        '  FillComboLine(CobCarton)
        '  FillComboLine(CobDC)
        ' LoadDataToCombo(CobDept, 2)
        '  LoadDataToCombo(CboCus, 1)
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        '檢視用戶權限()
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        'Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        UIFunction.SetMessage("数据加载中，请稍后....", lblMsg, True, False)
        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            DgMoData.Focus()
            If Not CheckDate(DtStar, DtEnd, Me.CobPPID.Text.Trim, True, 2) Then Return
            If txtCustOrder.Text.Trim = "" Then
                UIFunction.SetMessage("出货单不能为空！", lblMsg, True, False)
            End If
            ' DgMoData.Rows.Clear()
            'myThread.Start()
            ShowPackMaster(0)
            UIFunction.SetMessage("数据加载成功！", lblMsg, False, True)
            'Threading.Thread.Sleep(300)
        Catch
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        Finally
            'myThread.Abort()
        End Try
    End Sub

    Private Function SetSqlparameter(ByVal type As String, ByVal cartonid As String, ByVal linkid As String) As SqlParameter()
        Dim StartDT, EndDT As String

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim ppid As String = CobPPID.Text.Trim

        Dim param(10) As SqlParameter
        param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --癬﹍丁
        param(0).Value = StartDT
        param(1) = New SqlParameter("@endtime", SqlDbType.NChar)     '@endtime     varchar(25),  --沧ゎ丁
        param(1).Value = EndDT
        'varchar(10),  --D/C
        param(2) = New SqlParameter("@ppid", SqlDbType.NChar)   'varchar(2),   --そ
        param(2).Value = ppid

        param(3) = New SqlParameter("@factoryid", SqlDbType.NChar)   'varchar(2),   --そ
        param(3).Value = g_Factory

        param(4) = New SqlParameter("@moid", SqlDbType.Char)        'varchar(12),  --虫絪腹

        If CobMo.Text <> "ALL" And String.IsNullOrEmpty(CobMo.Text) = False Then
            param(4).Value = CobMo.Text
        Else
            param(4).Value = ""
        End If

        param(5) = New SqlParameter("@partid", SqlDbType.NChar)      'varchar(20),  --ン絪腹
        If CobPart.Text <> "ALL" And String.IsNullOrEmpty(CobPart.Text) = False Then
            param(5).Value = CobPart.Text
        Else
            param(5).Value = ""
        End If

        param(6) = New SqlParameter("@deptid", SqlDbType.NChar)      'varchar(20),  --ン絪腹
        param(6).Value = ""
        param(7) = New SqlParameter("@cartonid", SqlDbType.Char)     'varchar(35),  --絚兵絏

        If String.IsNullOrEmpty(txtCartonid.Text) = False Then
            param(7).Value = txtCartonid.Text.Trim
        Else
            param(7).Value = ""
        End If

        param(8) = New SqlParameter("@cusid", SqlDbType.NChar)      'varchar(20),  --ン絪腹
        param(8).Value = ""
        'Dim ppid As String = ""
        'param(8) = New SqlParameter("@ppid", SqlDbType.NChar)        'varchar(6),   --玻珇兵絏
        'If CobPPID.Text <> "" Then
        '    ' param(8).Value = CobPPID.Text
        '    If CobPPID.Lines.Length > 0 Then
        '        Dim ii As Integer = 0
        '        For ii = 0 To CobPPID.Lines.Length - 1
        '            If CobPPID.Lines(ii).ToString.Trim = "" Then
        '                Continue For
        '            Else
        '                ppid = ppid + CobPPID.Lines(ii).ToString.Trim + ","
        '            End If
        '        Next
        '        ' Dim line1 As String = Me.CobPPID.Lines(0)
        '        ppid = ppid.Substring(0, ppid.Length - 1)
        '        param(8).Value = ppid
        '    End If

        'Else
        '    param(8).Value = "%"
        'End If

        param(9) = New SqlParameter("@lineid", SqlDbType.NChar)      'varchar(6),  xianbie
        If CobLine.Text <> "ALL" And String.IsNullOrEmpty(CobLine.Text) = False Then
            param(9).Value = CobLine.Text
        Else
            param(9).Value = ""
        End If
        param(10) = New SqlParameter("@custorder", SqlDbType.NChar)      'varchar(6),  xianbie
        If String.IsNullOrEmpty(txtCustOrder.Text.Trim) = False Then
            param(10).Value = txtCustOrder.Text.Trim.ToUpper
        Else
            param(10).Value = ""
        End If
        Return param
    End Function

    Private Sub ShowPackMaster(ByVal intCheck)
        'Dim strDt As String
        'Dim dt As Date
        Dim param(12) As SqlParameter
        param = SetSqlparameter("T", "", "")
        ' Rs = ObjDB.GetDataReader("execute m_QueryPackRecord_p @begintime,@endtime,@dcno,@factoryid,@moid,@partid,@deptid,@cartonid,@ppid,@cusid,@linkid,@flag", param)
        'Do While Rs.Read
        '    dt = Rs(10).ToString
        '    strDt = dt.ToString("yyyy-MM-dd HH:mm")
        '    DgMoData.Rows.Add(intCheck, Rs(0), Rs(1), Rs(2), Rs(3), Rs(4), Rs(5), Rs(6), Rs(7), Rs(8), Rs(9), strDt)

        'Loop
        Try
            Dim sql As String = "exec p_L01PackReport '" & param(0).Value.ToString & "','" & param(1).Value.ToString & "','" & param(2).Value.ToString & "','" & param(3).Value.ToString & "','" & param(4).Value.ToString & "','" & param(5).Value.ToString & "','" & param(6).Value.ToString & "','" & param(7).Value.ToString & "','" & param(8).Value.ToString & "','" & param(9).Value.ToString & "','" & param(10).Value.ToString & "'"
            Dim dts As DataTable = DbOperateReportUtils.GetDataTable(sql)

            'Dim dts As DataTable = ObjDB.GetDataTable("execute m_QueryPackRecords_p @begintime,@endtime,@dcno,@factoryid,@moid,@partid,@deptid,@cartonid,@ppid,@cusid,@linkid,@flag", param)
            DgMoData.DataSource = dts
            DgMoData.Refresh()
            If Me.DgMoData.RowCount > 0 Then
                DgMoData.Columns(0).Visible = False
                DgMoData.Item(2, 0).Selected = True
            End If

            '  Rs.Close()
            'DgMoData.DataSource
            ToolCount.Text = DgMoData.RowCount.ToString()
            dts.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ShowDetail(ByVal strKey As String, ByVal strLink As String)
        Dim FrmShowDetail As New FrmShowDetail
        Dim bSelect As Boolean
        Dim strValue As String
        Dim i As Integer

        If strLink = "不連PPID和Date Code" Then
            MsgBox("没有明细资料!", 48, "矗ボ")
            Exit Sub
        End If

        strCondition = ""

        If strKey <> "" Then
            strCondition = strKey
        Else
            For i = 0 To DgMoData.Rows.Count - 1
                bSelect = DgMoData.Item(0, i).Value
                strValue = DgMoData.Item(1, i).Value.ToString()
                If bSelect Then
                    strCondition += strValue + ","
                End If
            Next
            If strCondition <> "" Then strCondition = strCondition.Remove(strCondition.Length - 1, 1)
        End If

        If strCondition = "" Then
            MsgBox("生成查询条件时发生错误!", 48, "矗ボ")
            Exit Sub
        End If

        FrmShowDetail.strSQL = "execute p_L01PackReport  @begintime,@endtime,@ppid,@factoryid,@moid,@partid,@deptid,@cartonid,@cusid,@linkid,@Lineid,@custorder"
        Dim sqlparam(11) As SqlParameter
        'If strLink = "連接PPID" Or strLink = "" Then
        '    FrmShowDetail.TabTitle = "外箱编号|产品序号|扫描人员|扫描时间"
        'End If

        'If strLink = "連接Date Code" Then
        '    FrmShowDetail.TabTitle = "外箱编号|Date Code|扫描人员|扫描时间"
        'End If
        sqlparam = SetSqlparameter("D", strCondition, strLink)
        FrmShowDetail.Sqlparam = sqlparam
        FrmShowDetail.ShowDialog()
    End Sub

    Private Sub DgMoData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Dim strCarton, strLink As String
        'If e.RowIndex = -1 Then Exit Sub
        'strCarton = DgMoData.Rows(e.RowIndex).Cells(1).Value.ToString()
        'strLink = DgMoData.Rows(e.RowIndex).Cells(6).Value.ToString() '5, Modify by cq 20180531
        'ShowDetail(strCarton, strLink)
    End Sub

    Private Sub MenuItemAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAll.Click
        DgMoData.Rows.Clear()
        ShowPackMaster(1)
    End Sub

    Private Sub MenuItemNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNone.Click
        If DgMoData.RowCount > 0 Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub MenuItemDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDetail.Click
        'If DgMoData.Rows.Count = 0 Then Exit Sub
        'DgMoData.Item(2, 0).Selected = True
        'ShowDetail("", "")
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DgMoData, Me.Text)
        'If Me.DgMoData.RowCount < 1 Then Exit Sub
        ''ObjDB.InportInExcel("select ' ' , a.* from  (" & strSaveSql & ") a", "杆癘魁琩高", Me.DgMoData, GetQueryCondition)
        'LoadDataToOpExcel("杆癘魁琩高", DgMoData, "")
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DgMoData.RowCount <= 0 Then
            MenuItemAll.Enabled = False
            MenuItemNone.Enabled = False
            MenuItemDetail.Enabled = False
        Else
            MenuItemAll.Enabled = True
            MenuItemNone.Enabled = True
            MenuItemDetail.Enabled = True
        End If
    End Sub

    Private Sub CobCarton_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobPart.TextChanged, CobMo.TextChanged, CobFactory.TextChanged
        'Me.DgMoData.Rows.Clear()
        Me.ToolCount.Text = "0"
    End Sub





    Private Sub ToolTxt_Click(sender As Object, e As EventArgs) Handles ToolTxt.Click

        If txtCustOrder.Text.Trim = "" Then
            MsgBox("请填写订单号!", 48, "")
            Exit Sub
        End If
        If DgMoData.RowCount < 1 Then
            MsgBox("没有要导出的数据!", 48, "")
            Exit Sub
        End If
        Try
            Dim startdate As String = Date.Now.Date
            Dim material As String = DgMoData.Rows(0).Cells("ppid").Value.ToString.Substring(2, 10) '4XD0T04868
            'Dim custorder As String = txtCustOrder.Text.Trim.ToUpper.ToString

            Dim bMachinfile As StringBuilder = New StringBuilder
            bMachinfile.Insert(0, "Machine_No" & vbTab & "Material_No" & vbTab & "Packing_Lot_No" & vbTab & "Start_Date" & vbTab & "Flag_Linked" & vbTab & "Check_Code" & vbTab & "VF_NAME")
            bMachinfile.Append(Microsoft.VisualBasic.Constants.vbNewLine)


            Dim bMaterialfile As StringBuilder = New StringBuilder
            bMaterialfile.Insert(0, "Line_no" & vbTab & "USN" & vbTab & "Lenovo_barebond_PN" & vbTab & "MO" & vbTab & "UPN" & vbTab & "CPN" & vbTab & "Qty" & vbTab & "CSN" & vbTab & "Description" & vbTab & "Create_date" & vbTab & "Update_date" & vbTab & "Lenovo_Sub_PN" & vbTab & "Lenovo_PN_Code" & vbTab & "Supplier_name" & vbTab & "Sub_Supplier_Name" & vbTab & "Collect_time")
            bMaterialfile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            Dim sn As String = ""
            For index = 0 To DgMoData.Rows.Count - 1 Step 1
                If material = "4XD0T04868" Or material = "4XD0T44459" Then
                    sn = "8" + DgMoData.Rows(index).Cells("ppid").Value.ToString.Substring(1, 19)
                End If
                bMachinfile.Append(sn & vbTab)
                bMachinfile.Append(material & vbTab)
                bMachinfile.Append("XX" + DgMoData.Rows(index).Cells("custno").Value.ToString + "Z00" & vbTab)
                bMachinfile.Append(startdate & vbTab)
                bMachinfile.Append("0" & vbTab)
                bMachinfile.Append(vbTab)
                bMachinfile.Append("NA")
                bMachinfile.Append(Microsoft.VisualBasic.Constants.vbNewLine)

                bMaterialfile.Append((index + 1).ToString & vbTab)
                bMaterialfile.Append(sn & vbTab)
                bMaterialfile.Append(material & vbTab)
                bMaterialfile.Append(DgMoData.Rows(index).Cells("custno").Value.ToString & vbTab)
                bMaterialfile.Append(material & vbTab)
                bMaterialfile.Append("NA" & vbTab)
                bMaterialfile.Append("1" & vbTab)
                bMaterialfile.Append("NA" & vbTab)
                bMaterialfile.Append("S520" & vbTab)
                bMaterialfile.Append(startdate & vbTab)
                bMaterialfile.Append(startdate & vbTab)
                bMaterialfile.Append("NA" & vbTab)
                bMaterialfile.Append("SPK" & vbTab)
                bMaterialfile.Append("LUXSHARE" & vbTab)
                bMaterialfile.Append("NA" & vbTab)
                bMaterialfile.Append(startdate)
                bMaterialfile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            Next
            Dim machinefilename As String = "TBL_MACHINE_SEQUENCE_" + Date.Now.Date.ToString("yyyyMMdd")
            Dim materialfilename As String = "TBL_MATERIAL_BARCODE_L6_" + Date.Now.Date.ToString("yyyyMMdd")
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If
            File.WriteAllText("c:\MesExport\" & machinefilename & ".txt", bMachinfile.ToString, Encoding.UTF8)
            File.WriteAllText("c:\MesExport\" & materialfilename & ".txt", bMaterialfile.ToString, Encoding.UTF8)
            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetQueryCondition() As String
        Dim str As String
        str = "开始时间：" & DtStar.Value.ToString() & "" & DtEnd.Value.ToString() _
            & "营运中心：" & CobFactory.Text & "  " & "外箱编号：" & txtCartonid.Text & "客户名称：" & "联想 " _
            & "产品条码：" & CobPPID.Text & "  " & "料件编号：" & CobPart.Text & "  " & "工单编号：" & CobMo.Text
        Return str
    End Function

    '2009-08-30 by tangxiang ----
#Region "Enter-->Tab"

    Private Sub DtStar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtStar.KeyPress, DtEnd.KeyPress, CobPart.KeyPress, CobMo.KeyPress, CobFactory.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub CboCus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub
    Public Sub GetControlright(ByVal FromName As Form)

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim RightDr As SqlDataReader

        RightDr = Sdbc.GetDataReader("select ButtonID from m_Logtree_t a left join m_userright_t b on a.Tkey=b.tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' AND a.Formid=(select apid from m_SysapForm_t where Apformid='" & FromName.Name & "' ) and a.listy='N'")
        'FormRead = PubClass.FormBtset("select Ttext from E_UserRight_t where userid='sz19096'and listy= 'Y'and Tparent= (select Tkey from E_UserRight_t where Ttext= '入庫單維護'and userid='sz19096' )")
        If RightDr.HasRows Then
            While RightDr.Read
                Setright(FromName, RightDr("ButtonID"))
            End While
        End If
        RightDr.Close()

    End Sub

    Private Sub Setright(ByVal ParentControl As Control, ByVal ControlName As String)

        Dim MyControl As Control

        For Each MyControl In ParentControl.Controls

            If UCase(MyControl.Name).Trim = UCase(ControlName).ToString Then
                MyControl.Enabled = True
                Exit For
            End If
            If TypeOf MyControl Is ToolStrip Then
                Dim TempControl As ToolStrip
                TempControl = MyControl
                Dim FormStripButton As ToolStripItem
                For Each FormStripButton In TempControl.Items
                    If TypeOf FormStripButton Is System.Windows.Forms.ToolStripButton Then

                        If UCase(FormStripButton.Name) = UCase(ControlName).ToString Then
                            FormStripButton.Tag = "YES"
                            FormStripButton.Enabled = True
                            Exit For
                        End If
                    End If
                Next
            End If
            If MyControl.HasChildren Then
                Setright(MyControl, ControlName)
            End If
        Next
    End Sub
#End Region

End Class