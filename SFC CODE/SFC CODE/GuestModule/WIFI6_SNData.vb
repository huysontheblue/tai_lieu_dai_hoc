
Imports System
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports System.Collections
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports System.Text
Imports MainFrame
Imports System.Windows.Forms.DataFormats



Public Class WIFI6_SNData

    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass()
    Dim LoadM As New BarCodePrint.SqlClassM
    Public LoadD As New BarCodePrint.SqlClassD
    Dim PrtStrTable As New DataTable
    Dim PrintStr As New StringBuilder
    Dim PrintPart(,) As String
    Dim BarFile As New StringBuilder()
    Dim btFormat As New BarTender.Format
    Dim btApp As BarTender.Application
    Dim pFilePath As String = ""
    'Dim PrintName As String = ""
    Dim tempSN As String = ""
    Dim tempNum As Integer = 0
    Dim tempText5 As String = ""





    Private Sub WIFI6_SNData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.DataGridView1.Columns(0).HeaderText = "ID"
        'Me.DataGridView1.Columns(1).HeaderText = "SN"
        'Me.DataGridView1.Columns(2).HeaderText = "MAC"
        'Me.DataGridView1.Columns(3).HeaderText = "ProductNum"
        'Me.DataGridView1.Columns(4).HeaderText = "Filename"
        'Me.DataGridView1.Columns(5).HeaderText = "UsedBy"
        'Me.DataGridView1.Columns(6).HeaderText = "UsedTime"

        'Me.DataGridView1.Columns.Item(0).Width = 10
        'Me.DataGridView1.Columns.Item(1).Width = 30
        'Me.DataGridView1.Columns.Item(2).Width = 30
        'Me.DataGridView1.Columns.Item(3).Width = 150
        'Me.DataGridView1.Columns.Item(4).Width = 30
        'Me.DataGridView1.Columns.Item(5).Width = 30
        'Me.DataGridView1.Columns.Item(6).Width = 30


        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Me.TextBox6.BackColor = Color.Yellow
        btApp = New BarTender.ApplicationClass
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Try
            If Me.TextBox5.Text <> "" Then
                If Me.DataGridView1.Rows.Count > 0 Then
                    Me.DataGridView1.Rows.Clear()
                End If
                Dim conn1 As OleDbConnection

                Dim dta As OleDbDataAdapter

                Dim sqlCheck As String = "select SN,MAC from Wifi6_sn_mac with(nolock)"
                Dim DataCheck As DataTable = conn.GetDataTable(sqlCheck)

                Dim dts As DataSet
                Dim dts1 As String
                Dim dts2 As String
                Dim dts3 As String




                Dim excel As String
                Dim OpenFileDialog As New OpenFileDialog

                OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

                If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                    Dim fi As New FileInfo(OpenFileDialog.FileName)
                    Dim FullFileName As String = OpenFileDialog.FileName
                    Dim getxie As Integer = FullFileName.LastIndexOf("\")
                    Dim getdian As Integer = FullFileName.LastIndexOf(".")
                    Dim FileName As String = FullFileName.Substring(getxie + 1, getdian - getxie - 1)
                    Dim getOne As Integer
                    Dim getTwo As Integer
                    Dim getID As Integer

                    getID = 1
                    excel = fi.FullName

                    conn1 = New OleDbConnection( _
                                    "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                                    "Data Source=" & excel & ";" & _
                                    "Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'")

                    dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn1)

                    dts = New DataSet

                    dta.Fill(dts, "[Sheet1$]")

                    Dim row As String
                    Dim i As Integer
                    Dim m As Integer
                    Dim getdt As New DataTable
                    Dim getdr As DataRow
                    Dim mecheck As String
                    Dim mycheck As Object

                    getdt.Columns.Add(New DataColumn("ID"))
                    getdt.Columns.Add(New DataColumn("SN"))
                    getdt.Columns.Add(New DataColumn("MAC"))
                    getdt.Columns.Add(New DataColumn("ProductNum"))
                    getdt.Columns.Add(New DataColumn("FileName"))
                    getdt.Columns.Add(New DataColumn("Part_no"))
                    getdt.Columns.Add(New DataColumn("Batch_input"))
                    getdt.Columns.Add(New DataColumn("UsedBy"))
                    getdt.Columns.Add(New DataColumn("UsedTime"))


                    Me.DataGridView1.DataSource = getdt
                    Dim Batch_input As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")

                    If dts.Tables(0).Columns.Count > 1 Then
                        For i = 0 To dts.Tables(0).Rows.Count - 1
                            getdr = getdt.NewRow()

                            row = dts.Tables(0).Rows(i)(0).ToString()

                            'getOne = row.IndexOf(";")
                            'getTwo = row.IndexOf(";", getOne + 1)
                            'dts1 = row.Substring(0, getOne)
                            'dts2 = row.Substring(getOne + 1, getTwo - getOne - 1)
                            'dts3 = row
                            getdr.Item("ID") = getID
                            getdr.Item("SN") = dts.Tables(0).Rows(i)("SAP").ToString()
                            getdr.Item("MAC") = dts.Tables(0).Rows(i)("MAC").ToString()

                            If DataCheck.Rows.Count > 0 Then
                                For j = 0 To DataCheck.Rows.Count - 1
                                    If DataCheck.Rows(j)(0).ToString().Trim() = dts.Tables(0).Rows(i)("SAP").ToString().Trim Then
                                        'mecheck = "重复导入SN: " + dts.Tables(0).Rows(i)("SAP").ToString().Trim()
                                        'mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                                        'If getdt.Rows.Count > 0 Then
                                        '    getdt.Rows.Clear()
                                        'End If
                                        Continue For

                                    End If

                                    If DataCheck.Rows(j)(1).ToString().Trim() = dts.Tables(0).Rows(i)("MAC").ToString().Trim() Then
                                        'mecheck = "重复导入MAC: " + dts.Tables(0).Rows(i)("MAC").ToString().Trim()
                                        'mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                                        'If getdt.Rows.Count > 0 Then
                                        '    getdt.Rows.Clear()
                                        'End If
                                        Continue For
                                    End If

                                Next j
                            End If

                            getdr.Item("ProductNum") = dts.Tables(0).Rows(i)("Model").ToString() & ";" & dts.Tables(0).Rows(i)("Product ID").ToString() & ";" & dts.Tables(0).Rows(i)("Equip ID").ToString() & ";" & dts.Tables(0).Rows(i)("MAC").ToString() & ";" & dts.Tables(0).Rows(i)("SAP").ToString() & ";" & dts.Tables(0).Rows(i)("Altice SN").ToString() & ";" & dts.Tables(0).Rows(i)("Manufacturer SN").ToString() & ";" & dts.Tables(0).Rows(i)("BOM").ToString() & ";" & dts.Tables(0).Rows(i)("HW Version").ToString() & ";" & dts.Tables(0).Rows(i)("SW Version").ToString() & ";" & dts.Tables(0).Rows(i)("CID").ToString()
                            getdr.Item("FileName") = FileName
                            getdr.Item("Part_no") = TextBox5.Text.Trim().ToString()
                            getdr.Item("Batch_input") = Batch_input
                            getdr.Item("UsedBy") = VbCommClass.VbCommClass.UseId
                            getdr.Item("UsedTime") = DateTime.Now

                            getdt.Rows.Add(getdr)

                            'If i > 0 Then
                            '    For m = 1 To i
                            '        If dts.Tables(0).Rows(i)("SAP").ToString().Trim() = Me.DataGridView1.Item(1, m - 1).Value.ToString().Trim() Then
                            '            mecheck = "界面重复导入SN: " + dts.Tables(0).Rows(i)("SAP").ToString().Trim()
                            '            mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                            '            If getdt.Rows.Count > 0 Then
                            '                getdt.Rows.Clear()
                            '            End If
                            '            Continue For
                            '        End If

                            '        If dts.Tables(0).Rows(i)("MAC").ToString().Trim() = Me.DataGridView1.Item(2, m - 1).Value.ToString().Trim() Then
                            '            mecheck = "界面重复导入MAC: " + dts.Tables(0).Rows(i)("SAP").ToString().Trim()
                            '            mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                            '            If getdt.Rows.Count > 0 Then
                            '                getdt.Rows.Clear()
                            '            End If
                            '            Continue For
                            '        End If
                            '    Next m
                            'End If


                            Me.DataGridView1.DataSource = getdt
                            getID = getID + 1

                        Next i
                    Else

                        For i = 0 To dts.Tables(0).Rows.Count - 1
                            getdr = getdt.NewRow()

                            row = dts.Tables(0).Rows(i)(0).ToString()

                            getOne = row.IndexOf(";")
                            getTwo = row.IndexOf(";", getOne + 1)
                            dts1 = row.Substring(0, getOne)
                            dts2 = row.Substring(getOne + 1, getTwo - getOne - 1)
                            dts3 = row
                            getdr.Item("ID") = getID
                            getdr.Item("SN") = dts1
                            getdr.Item("MAC") = dts2

                            If DataCheck.Rows.Count > 0 Then
                                For j = 0 To DataCheck.Rows.Count - 1
                                    If DataCheck.Rows(j)(0).ToString().Trim() = dts1.ToString().Trim() Then
                                        'mecheck = "重复导入SN: " + dts1.ToString().Trim()
                                        'mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                                        'If getdt.Rows.Count > 0 Then
                                        '    getdt.Rows.Clear()
                                        'End If
                                        Continue For
                                    End If

                                    If DataCheck.Rows(j)(1).ToString().Trim() = dts2.ToString().Trim() Then
                                        'mecheck = "重复导入MAC: " + dts2.ToString().Trim()
                                        'mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                                        'If getdt.Rows.Count > 0 Then
                                        '    getdt.Rows.Clear()
                                        'End If
                                        Continue For
                                    End If

                                Next j
                            End If

                            getdr.Item("ProductNum") = dts3
                            getdr.Item("FileName") = FileName
                            getdr.Item("Part_no") = TextBox5.Text.Trim().ToString()
                            getdr.Item("Batch_input") = Batch_input
                            getdr.Item("UsedBy") = VbCommClass.VbCommClass.UseId
                            getdr.Item("UsedTime") = DateTime.Now

                            getdt.Rows.Add(getdr)

                            'If i > 0 Then
                            '    For m = 1 To i
                            '        If dts1.Trim() = Me.DataGridView1.Item(1, m - 1).Value.ToString().Trim() Then
                            '            mecheck = "界面重复导入SN: " + dts1.Trim()
                            '            mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                            '            If getdt.Rows.Count > 0 Then
                            '                getdt.Rows.Clear()
                            '            End If
                            '            Continue For
                            '        End If

                            '        If dts2.Trim() = Me.DataGridView1.Item(2, m - 1).Value.ToString().Trim() Then
                            '            mecheck = "界面重复导入MAC: " + dts2.Trim()
                            '            mycheck = MsgBox(mecheck, vbOKOnly, "重复信息")
                            '            If getdt.Rows.Count > 0 Then
                            '                getdt.Rows.Clear()
                            '            End If
                            '            Continue For
                            '        End If
                            '    Next m
                            'End If


                            Me.DataGridView1.DataSource = getdt
                            getID = getID + 1

                        Next i
                    End If
                    conn1.Close()

                End If
            Else
                Dim myimport As Object
                myimport = MsgBox("请输入要导入的料号", vbOKOnly, "输入提示")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim exewifi6 As String = ""
        Dim getSN As String = ""
        Dim getMAC As String = ""
        Dim getProductNum As String = ""
        Dim getFileName As String = ""
        Dim getBatch_input As String = ""
        Dim getBatch_print As String = ""
        Dim getPart_no As String = ""
        Dim getWork_order As String = ""
        Dim gerApply_num As Integer = 0
        Dim getstatus As Integer = 0
        Dim getIsPrint As Integer = 0
        Dim getPrintby As String = ""
        Dim getPrintTime As DateTime = Convert.ToDateTime("1900-01-01 00:00:00.000")
        Dim getCPrintby As String = ""
        Dim getCPrintTime As DateTime = Convert.ToDateTime("1900-01-01 00:00:00.000")
        Dim getUsedBy As String = VbCommClass.VbCommClass.UseId
        Dim getSUM As Integer = 0

        Dim message1 As String
        Dim myValue1 As Object
        Dim dt As Integer = 0
        Dim cfnum As Integer = 0
        Try
            Dim sql6 As String
            For i = 0 To DataGridView1.RowCount - 1

                getSN = DataGridView1.Item(1, i).Value.ToString()
                getMAC = DataGridView1.Item(2, i).Value.ToString()
                getProductNum = DataGridView1.Item(3, i).Value.ToString()
                getFileName = DataGridView1.Item(4, i).Value.ToString()
                getPart_no = DataGridView1.Item(5, i).Value.ToString()
                getBatch_input = DataGridView1.Item(6, i).Value.ToString()

                sql6 = " select * from  Wifi6_sn_mac where sn='" & getSN & "'or mac='" & getMAC & "'"
                dt = conn.GetRowsCount(sql6)
                If dt > 0 Then
                    cfnum = cfnum + 1
                    Continue For

                End If
                sql6 = "INSERT INTO Wifi6_sn_mac VALUES ('" + getSN + "','" + getMAC + "','" + getProductNum + "',N'" + getFileName + "','" + getPart_no + "','" + getWork_order + "','" + getBatch_input + "','" + getBatch_print + "','0','0','0','" + getPrintby + "','" + getPrintTime + "','" + getCPrintby + "','" + getCPrintTime + "','" + VbCommClass.VbCommClass.UseId + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')"

                exewifi6 = conn.ExecuteNonQuery(sql6)
                getSUM = getSUM + 1

            Next i

            message1 = "成功导入数据总计: " + getSUM.ToString() + " 笔 \n 重复数据总计: " + cfnum.ToString() + " 笔"
            myValue1 = MsgBox(message1, vbOKOnly, "数据导入信息")


        Catch ex As Exception
            exewifi6 = exewifi6 + ex.ToString
        End Try
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Close()
    End Sub


    Private Sub Print1_Click(sender As Object, e As EventArgs) Handles Print1.Click
        Try

        
        Dim m As Int16 = 0
        Dim getpartnop As String = TextBox5.Text.Trim().ToString()
        Dim getWorkorderp As String = TextBox4.Text.Trim().ToString()
        Dim getbatchprint As String = DateTime.Now.ToString("yyyyMMddHHmmssffff")
        Dim SqlStrp As New System.Text.StringBuilder
        Dim getPrintby As String = VbCommClass.VbCommClass.UseId
        Dim myValue2 As Object


        If getpartnop = "" Or getWorkorderp = "" Or TextBox6.Text.Trim().ToString() = "" Then
            myValue2 = MsgBox("请输入工单或申请数量信息", vbOKOnly, "输入提示")

        Else
            If Convert.ToInt32(TextBox6.Text.Trim()) - tempNum > 0 Then
                myValue2 = MsgBox("申请打印数量比工单剩余数量大", vbOKOnly, "输入提示")
            Else
                Dim n As Integer = Convert.ToInt32(TextBox6.Text.Trim())
                tempText5 = Me.TextBox5.Text.Trim().ToString()
                Dim fullfilename As String = "C:\Program Files\默认公司名称\Bartender.txt"
                Dim fs1 As FileStream = New FileStream(fullfilename, FileMode.Create)
                Dim sw1 As StreamWriter = New StreamWriter(fs1, Encoding.UTF8)
                Dim sb As StringBuilder = New StringBuilder()
                Dim temp As Integer = 0
                Dim sqlP As String = "select top " & n & " SN from Wifi6_sn_mac with(nolock) where IsPrint=0 and Part_no ='" & TextBox5.Text.Trim & "' order by UsedTime asc"
                Dim Data As DataTable = conn.GetDataTable(sqlP)
                'PrintName = Data.ToString()
                sb.Append("SN" + Environment.NewLine)

                For i = 0 To Data.Rows.Count - 1

                    sb.Append(Data.Rows(i)(0).ToString().Trim())
                    sb.Append(Environment.NewLine)

                Next i
                sw1.Write(sb)
                sw1.Flush()
                sw1.Close()
                fs1.Close()



                Dim sqlpath As String = "select st.TemplatePath from m_SnMFormat_t st inner join m_PartPack_t k on st.PFormatID = k.PFormatID inner join m_SettingParameter_t  t on k.StatusFlag= t.PARAMETER_VALUE where k.Partid='" + Me.TextBox5.Text.Trim().ToString() + "' and Packid='S' and PARAMETER_CODE='PartStatusFlagText' and t.PARAMETER_VALUE=2"
                Dim Datapath As DataTable = conn.GetDataTable(sqlpath)
                If Datapath.Rows.Count > 0 Then
                    pFilePath = Datapath.Rows(0)(0).ToString()
                End If

                Dim filepath As String = VbCommClass.VbCommClass.PrintDataModle & pFilePath
                Dim TxtFileStr As StringBuilder = New StringBuilder()
                Dim TxtFileStrCommon As StringBuilder = New StringBuilder()
                Dim titlestr As StringBuilder = New StringBuilder()
                Dim printDoc As System.Drawing.Printing.PrintDocument = New System.Drawing.Printing.PrintDocument()

                btFormat = btApp.Formats.Open(filepath, False, String.Empty)
                btFormat.Printer = printDoc.PrinterSettings.PrinterName
                Dim aa As BarTender.Messages
                btFormat.Print("", False, -1, aa)

                For i = 0 To Data.Rows.Count - 1

                    Dim sqlUP As String = "update Wifi6_sn_mac set Work_order='" + getWorkorderp + "',Batch_print='" + getbatchprint + "',IsPrint=1,PrintTime='" + DateTime.Now + "',Printby='" + getPrintby + "' where IsPrint=0 and SN='" + Data.Rows(i)(0).ToString() + "'"
                    Dim Data1 As DataTable = conn.GetDataTable(sqlUP)

                Next i

                Dim sqlsprint As String = "select SN,MAC,ProductNum,FileName,UsedBy,UsedTime,IsPrint from Wifi6_sn_mac where IsPrint=0"
                Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
                If Datasprint.Rows.Count > 0 Then

                    Dim getdrs0 As DataRow
                    Dim getdt0 As New DataTable
                    getdt0.Columns.Clear()
                    getdt0.Rows.Clear()

                    getdt0.Columns.Add(New DataColumn("SN"))
                    getdt0.Columns.Add(New DataColumn("MAC"))
                    getdt0.Columns.Add(New DataColumn("ProductNum"))
                    getdt0.Columns.Add(New DataColumn("FileName"))
                    getdt0.Columns.Add(New DataColumn("UsedBy"))
                    getdt0.Columns.Add(New DataColumn("UsedTime"))
                    getdt0.Columns.Add(New DataColumn("IsPrint"))



                    Me.DataGridView1.DataSource = getdt0

                    For i = 0 To Datasprint.Rows.Count - 1

                        getdrs0 = getdt0.NewRow()
                        getdrs0.Item("SN") = Datasprint.Rows(i)(0).ToString()
                        getdrs0.Item("MAC") = Datasprint.Rows(i)(1).ToString()
                        getdrs0.Item("ProductNum") = Datasprint.Rows(i)(2).ToString()
                        getdrs0.Item("FileName") = Datasprint.Rows(i)(3).ToString()
                        getdrs0.Item("UsedBy") = Datasprint.Rows(i)(4).ToString()
                        getdrs0.Item("UsedTime") = Datasprint.Rows(i)(5).ToString()
                        If Datasprint.Rows(i)(6).ToString() = "0" Then
                            getdrs0.Item("IsPrint") = "待正常打印"
                        End If
                        getdt0.Rows.Add(getdrs0)

                    Next i

                    Me.DataGridView1.DataSource = getdt0
                End If
                Dim sqlM1S As String = "select SN from Wifi6_sn_mac where IsPrint = 1 and Work_order ='" + Me.TextBox4.Text.Trim().ToString() + "'"
                Dim Data1S As DataTable = conn.GetDataTable(sqlM1S)
                If Data1S.Rows.Count > 0 Then
                    Me.TextBox7.Text = (Convert.ToInt32(TextBox3.Text.Trim()) - Data1S.Rows.Count).ToString()
                    tempNum = Convert.ToInt32(TextBox3.Text.Trim()) - Data1S.Rows.Count
                        Me.TextBox6.Text = ""
                    Else
                        tempNum = TextBox3.Text.Trim()
                        Me.TextBox7.Text = Me.TextBox3.Text
                    End If
            End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataGridView1.Columns.Clear()
        If ComboBox1.SelectedIndex = 0 Then
            Dim sqlsprint As String = "select SN,MAC,ProductNum,FileName,UsedBy,UsedTime,IsPrint from Wifi6_sn_mac where IsPrint=0 "

            If TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,ProductNum,FileName,UsedBy,UsedTime,IsPrint from Wifi6_sn_mac where IsPrint=0 and part_no='" & TextBox5.Text & "'"
            End If
            If TextBox4.Text <> "" Then
                sqlsprint = "select SN,MAC,ProductNum,FileName,UsedBy,UsedTime,IsPrint from Wifi6_sn_mac where IsPrint=0 and Work_order='" & TextBox4.Text & "'"
            End If
            If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,ProductNum,FileName,UsedBy,UsedTime,IsPrint from Wifi6_sn_mac where IsPrint=0 and Work_order='" & TextBox4.Text & "' and part_no='" & TextBox5.Text & "'"
            End If

            Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
            If Datasprint.Rows.Count > 0 Then

                Dim getdrs0 As DataRow
                Dim getdt0 As New DataTable
                Dim getID As Integer = 1
                getdt0.Columns.Clear()
                getdt0.Rows.Clear()

                getdt0.Columns.Add(New DataColumn("ID"))
                getdt0.Columns.Add(New DataColumn("SN"))
                getdt0.Columns.Add(New DataColumn("MAC"))
                getdt0.Columns.Add(New DataColumn("ProductNum"))
                getdt0.Columns.Add(New DataColumn("FileName"))
                getdt0.Columns.Add(New DataColumn("UsedBy"))
                getdt0.Columns.Add(New DataColumn("UsedTime"))
                getdt0.Columns.Add(New DataColumn("IsPrint"))



                Me.DataGridView1.DataSource = getdt0

                For i = 0 To Datasprint.Rows.Count - 1

                    getdrs0 = getdt0.NewRow()
                    getdrs0.Item("ID") = getID
                    getdrs0.Item("SN") = Datasprint.Rows(i)(0).ToString()
                    getdrs0.Item("MAC") = Datasprint.Rows(i)(1).ToString()
                    getdrs0.Item("ProductNum") = Datasprint.Rows(i)(2).ToString()
                    getdrs0.Item("FileName") = Datasprint.Rows(i)(3).ToString()
                    getdrs0.Item("UsedBy") = Datasprint.Rows(i)(4).ToString()
                    getdrs0.Item("UsedTime") = Datasprint.Rows(i)(5).ToString()
                    If Datasprint.Rows(i)(6).ToString() = "0" Then
                        getdrs0.Item("IsPrint") = "待正常打印"
                    End If
                    getdt0.Rows.Add(getdrs0)
                    getID = getID + 1
                Next i

                Me.DataGridView1.DataSource = getdt0
            End If
        End If


        If ComboBox1.SelectedIndex = 1 Then
            Dim sqlsprint As String = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=10"
            If TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=10 and part_no='" & TextBox5.Text & "'"
            End If
            If TextBox4.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=10 and Work_order='" & TextBox4.Text & "'"
            End If
            If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=10 and Work_order='" & TextBox4.Text & "' and part_no='" & TextBox5.Text & "'"
            End If
            Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
            If Datasprint.Rows.Count > 0 Then

                Dim getdrs1 As DataRow
                Dim getdt1 As New DataTable
                Dim getID1 As Integer = 1
                getdt1.Columns.Clear()
                getdt1.Rows.Clear()

                getdt1.Columns.Add(New DataColumn("ID"))
                getdt1.Columns.Add(New DataColumn("SN"))
                getdt1.Columns.Add(New DataColumn("MAC"))
                getdt1.Columns.Add(New DataColumn("Part_no"))
                getdt1.Columns.Add(New DataColumn("Work_order"))
                getdt1.Columns.Add(New DataColumn("ProductNum"))
                getdt1.Columns.Add(New DataColumn("Batch_print"))
                getdt1.Columns.Add(New DataColumn("FileName"))
                getdt1.Columns.Add(New DataColumn("UsedBy"))
                getdt1.Columns.Add(New DataColumn("UsedTime"))
                getdt1.Columns.Add(New DataColumn("Printby"))
                getdt1.Columns.Add(New DataColumn("PrintTime"))
                getdt1.Columns.Add(New DataColumn("IsPrint"))

                Me.DataGridView1.DataSource = getdt1

                For i = 0 To Datasprint.Rows.Count - 1

                    getdrs1 = getdt1.NewRow()
                    getdrs1.Item("ID") = getID1
                    getdrs1.Item("SN") = Datasprint.Rows(i)(0).ToString()
                    getdrs1.Item("MAC") = Datasprint.Rows(i)(1).ToString()
                    getdrs1.Item("Part_no") = Datasprint.Rows(i)(2).ToString()
                    getdrs1.Item("Work_order") = Datasprint.Rows(i)(3).ToString()
                    getdrs1.Item("ProductNum") = Datasprint.Rows(i)(4).ToString()
                    getdrs1.Item("Batch_print") = Datasprint.Rows(i)(5).ToString()
                    getdrs1.Item("FileName") = Datasprint.Rows(i)(6).ToString()
                    getdrs1.Item("UsedBy") = Datasprint.Rows(i)(7).ToString()
                    getdrs1.Item("UsedTime") = Datasprint.Rows(i)(8).ToString()
                    getdrs1.Item("Printby") = Datasprint.Rows(i)(9).ToString()
                    getdrs1.Item("PrintTime") = Datasprint.Rows(i)(10).ToString()
                    If Datasprint.Rows(i)(11).ToString() = "10" Then
                        getdrs1.Item("IsPrint") = "待补打印"
                    End If

                    getdt1.Rows.Add(getdrs1)

                    getID1 = getID1 + 1

                Next i

                Me.DataGridView1.DataSource = getdt1
            End If
            Me.TextBox5.Text = ""
            Me.TextBox4.Text = ""
            Me.TextBox3.Text = ""
        End If

        If ComboBox1.SelectedIndex = 2 Then
            If Me.TextBox4.Text.Trim().ToString() <> "" Then
                Dim sqlsprint As String = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=1 and Part_no='" + Me.TextBox5.Text.Trim().ToString() + "'"
                If TextBox5.Text <> "" Then
                    sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=1 and part_no='" & TextBox5.Text & "'"
                End If
                If TextBox4.Text <> "" Then
                    sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=1 and Work_order='" & TextBox4.Text & "'"
                End If
                If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                    sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,IsPrint from Wifi6_sn_mac where IsPrint=1 and Work_order='" & TextBox4.Text & "' and part_no='" & TextBox5.Text & "'"
                End If

                Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
                If Datasprint.Rows.Count > 0 Then

                    Dim getdrs2 As DataRow
                    Dim getdt2 As New DataTable
                    Dim getID2 As Integer = 1
                    getdt2.Columns.Clear()
                    getdt2.Rows.Clear()

                    getdt2.Columns.Add(New DataColumn("ID"))
                    getdt2.Columns.Add(New DataColumn("SN"))
                    getdt2.Columns.Add(New DataColumn("MAC"))
                    getdt2.Columns.Add(New DataColumn("Part_no"))
                    getdt2.Columns.Add(New DataColumn("Work_order"))
                    getdt2.Columns.Add(New DataColumn("ProductNum"))
                    getdt2.Columns.Add(New DataColumn("Batch_print"))
                    getdt2.Columns.Add(New DataColumn("FileName"))
                    getdt2.Columns.Add(New DataColumn("UsedBy"))
                    getdt2.Columns.Add(New DataColumn("UsedTime"))
                    getdt2.Columns.Add(New DataColumn("Printby"))
                    getdt2.Columns.Add(New DataColumn("PrintTime"))
                    getdt2.Columns.Add(New DataColumn("IsPrint"))

                    Me.DataGridView1.DataSource = getdt2

                    For i = 0 To Datasprint.Rows.Count - 1

                        getdrs2 = getdt2.NewRow()
                        getdrs2.Item("ID") = getID2
                        getdrs2.Item("SN") = Datasprint.Rows(i)(0).ToString()
                        getdrs2.Item("MAC") = Datasprint.Rows(i)(1).ToString()
                        getdrs2.Item("Part_no") = Datasprint.Rows(i)(2).ToString()
                        getdrs2.Item("Work_order") = Datasprint.Rows(i)(3).ToString()
                        getdrs2.Item("ProductNum") = Datasprint.Rows(i)(4).ToString()
                        getdrs2.Item("Batch_print") = Datasprint.Rows(i)(5).ToString()
                        getdrs2.Item("FileName") = Datasprint.Rows(i)(6).ToString()
                        getdrs2.Item("UsedBy") = Datasprint.Rows(i)(7).ToString()
                        getdrs2.Item("UsedTime") = Datasprint.Rows(i)(8).ToString()
                        getdrs2.Item("Printby") = Datasprint.Rows(i)(9).ToString()
                        getdrs2.Item("PrintTime") = Datasprint.Rows(i)(10).ToString()
                        If Datasprint.Rows(i)(11).ToString() = "1" Then
                            getdrs2.Item("IsPrint") = "已正常打印"
                        End If

                        getdt2.Rows.Add(getdrs2)

                        getID2 = getID2 + 1

                    Next i

                    Me.DataGridView1.DataSource = getdt2
                End If

            Else
                Dim myquery1 As Object
                myquery1 = MsgBox("正常打印要输入工单信息", vbOKOnly, "输入提示")
                Me.TextBox4.Focus()

            End If

        End If

        If ComboBox1.SelectedIndex = 3 Then
            Dim sqlsprint As String = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,CPrintby,CPrintTime,IsPrint from Wifi6_sn_mac where IsPrint=2"
            If TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,CPrintby,CPrintTime,IsPrint from Wifi6_sn_mac where IsPrint=2 and part_no='" & TextBox5.Text & "'"
            End If
            If TextBox4.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,CPrintby,CPrintTime,IsPrint from Wifi6_sn_mac where IsPrint=2 and Work_order='" & TextBox4.Text & "'"
            End If
            If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                sqlsprint = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime,CPrintby,CPrintTime,IsPrint from Wifi6_sn_mac where IsPrint=2 and Work_order='" & TextBox4.Text & "' and part_no='" & TextBox5.Text & "'"
            End If

            Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
            If Datasprint.Rows.Count > 0 Then

                Dim getdrs3 As DataRow
                Dim getdt3 As New DataTable
                Dim getID3 As Integer = 1
                getdt3.Columns.Clear()
                getdt3.Rows.Clear()

                getdt3.Columns.Add(New DataColumn("ID"))
                getdt3.Columns.Add(New DataColumn("SN"))
                getdt3.Columns.Add(New DataColumn("MAC"))
                getdt3.Columns.Add(New DataColumn("Part_no"))
                getdt3.Columns.Add(New DataColumn("Work_order"))
                getdt3.Columns.Add(New DataColumn("ProductNum"))
                getdt3.Columns.Add(New DataColumn("Batch_print"))
                getdt3.Columns.Add(New DataColumn("FileName"))
                getdt3.Columns.Add(New DataColumn("UsedBy"))
                getdt3.Columns.Add(New DataColumn("UsedTime"))
                getdt3.Columns.Add(New DataColumn("Printby"))
                getdt3.Columns.Add(New DataColumn("PrintTime"))
                getdt3.Columns.Add(New DataColumn("CPrintby"))
                getdt3.Columns.Add(New DataColumn("CPrintTime"))
                getdt3.Columns.Add(New DataColumn("IsPrint"))

                Me.DataGridView1.DataSource = getdt3

                For i = 0 To Datasprint.Rows.Count - 1

                    getdrs3 = getdt3.NewRow()
                    getdrs3.Item("ID") = getID3
                    getdrs3.Item("SN") = Datasprint.Rows(i)(0).ToString()
                    getdrs3.Item("MAC") = Datasprint.Rows(i)(1).ToString()
                    getdrs3.Item("Part_no") = Datasprint.Rows(i)(2).ToString()
                    getdrs3.Item("Work_order") = Datasprint.Rows(i)(3).ToString()
                    getdrs3.Item("ProductNum") = Datasprint.Rows(i)(4).ToString()
                    getdrs3.Item("Batch_print") = Datasprint.Rows(i)(5).ToString()
                    getdrs3.Item("FileName") = Datasprint.Rows(i)(6).ToString()
                    getdrs3.Item("UsedBy") = Datasprint.Rows(i)(7).ToString()
                    getdrs3.Item("UsedTime") = Datasprint.Rows(i)(8).ToString()
                    getdrs3.Item("Printby") = Datasprint.Rows(i)(9).ToString()
                    getdrs3.Item("PrintTime") = Datasprint.Rows(i)(10).ToString()
                    getdrs3.Item("CPrintby") = Datasprint.Rows(i)(11).ToString()
                    getdrs3.Item("CPrintTime") = Datasprint.Rows(i)(12).ToString()

                    If Datasprint.Rows(i)(13).ToString() = "2" Then
                        getdrs3.Item("IsPrint") = "已补打印"
                    End If

                    getdt3.Rows.Add(getdrs3)

                    getID3 = getID3 + 1
                Next i

                Me.DataGridView1.DataSource = getdt3
            End If
            Me.TextBox5.Text = ""
            Me.TextBox4.Text = ""
            Me.TextBox3.Text = ""
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown


        If Me.TextBox1.Text.Trim().ToString() <> "" Then
            Dim sqlsprint As String = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime from Wifi6_sn_mac where IsPrint=10 and (SN='" + Me.TextBox1.Text.Trim().ToString() + "'or MAC='" + Me.TextBox2.Text.Trim().ToString() + "')"
            Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
            If Datasprint.Rows.Count > 0 Then
                Me.TextBox1.Text = Datasprint.Rows(0)(0).ToString()
                Me.TextBox2.Text = Datasprint.Rows(0)(1).ToString()
                Me.TextBox4.Text = Datasprint.Rows(0)(2).ToString()
                Me.TextBox5.Text = Datasprint.Rows(0)(3).ToString()


                tempSN = Datasprint.Rows(0)(0).ToString()

                Dim getdrs As DataRow
                Dim getdt As New DataTable

                getdt.Columns.Add(New DataColumn("SN"))
                getdt.Columns.Add(New DataColumn("MAC"))
                getdt.Columns.Add(New DataColumn("Part_no"))
                getdt.Columns.Add(New DataColumn("Work_order"))
                getdt.Columns.Add(New DataColumn("ProductNum"))
                getdt.Columns.Add(New DataColumn("Batch_print"))
                getdt.Columns.Add(New DataColumn("FileName"))
                getdt.Columns.Add(New DataColumn("UsedBy"))
                getdt.Columns.Add(New DataColumn("UsedTime"))
                getdt.Columns.Add(New DataColumn("Printby"))
                getdt.Columns.Add(New DataColumn("PrintTime"))

                getdrs = getdt.NewRow()
                getdrs.Item("SN") = Datasprint.Rows(0)(0).ToString()
                getdrs.Item("MAC") = Datasprint.Rows(0)(1).ToString()
                getdrs.Item("Part_no") = Datasprint.Rows(0)(2).ToString()
                getdrs.Item("Work_order") = Datasprint.Rows(0)(3).ToString()
                getdrs.Item("ProductNum") = Datasprint.Rows(0)(4).ToString()
                getdrs.Item("Batch_print") = Datasprint.Rows(0)(5).ToString()
                getdrs.Item("FileName") = Datasprint.Rows(0)(6).ToString()
                getdrs.Item("UsedBy") = Datasprint.Rows(0)(7).ToString()
                getdrs.Item("UsedTime") = Datasprint.Rows(0)(8).ToString()
                getdrs.Item("Printby") = Datasprint.Rows(0)(9).ToString()
                getdrs.Item("PrintTime") = Datasprint.Rows(0)(10).ToString()

                getdt.Rows.Add(getdrs)

                Me.DataGridView1.DataSource = getdt
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown

        If Me.TextBox2.Text.Trim().ToString() <> "" Then
            Dim sqlsprint As String = "select SN,MAC,Part_no,Work_order,ProductNum,Batch_print,FileName,UsedBy,UsedTime,Printby,PrintTime from Wifi6_sn_mac where IsPrint=10 and (SN='" + Me.TextBox1.Text.Trim().ToString() + "'or MAC='" + Me.TextBox2.Text.Trim().ToString() + "')"
            Dim Datasprint As DataTable = conn.GetDataTable(sqlsprint)
            If Datasprint.Rows.Count > 0 Then
                Me.TextBox1.Text = Datasprint.Rows(0)(0).ToString()
                Me.TextBox2.Text = Datasprint.Rows(0)(1).ToString()
                Me.TextBox4.Text = Datasprint.Rows(0)(2).ToString()
                Me.TextBox5.Text = Datasprint.Rows(0)(3).ToString()

                tempSN = Datasprint.Rows(0)(0).ToString()

                Dim getdrs As DataRow
                Dim getdt As New DataTable

                getdt.Columns.Add(New DataColumn("SN"))
                getdt.Columns.Add(New DataColumn("MAC"))
                getdt.Columns.Add(New DataColumn("Part_no"))
                getdt.Columns.Add(New DataColumn("Work_order"))
                getdt.Columns.Add(New DataColumn("ProductNum"))
                getdt.Columns.Add(New DataColumn("Batch_print"))
                getdt.Columns.Add(New DataColumn("FileName"))
                getdt.Columns.Add(New DataColumn("UsedBy"))
                getdt.Columns.Add(New DataColumn("UsedTime"))
                getdt.Columns.Add(New DataColumn("Printby"))
                getdt.Columns.Add(New DataColumn("PrintTime"))

                getdrs = getdt.NewRow()
                getdrs.Item("SN") = Datasprint.Rows(0)(0).ToString()
                getdrs.Item("MAC") = Datasprint.Rows(0)(1).ToString()
                getdrs.Item("Part_no") = Datasprint.Rows(0)(2).ToString()
                getdrs.Item("Work_order") = Datasprint.Rows(0)(3).ToString()
                getdrs.Item("ProductNum") = Datasprint.Rows(0)(4).ToString()
                getdrs.Item("Batch_print") = Datasprint.Rows(0)(5).ToString()
                getdrs.Item("FileName") = Datasprint.Rows(0)(6).ToString()
                getdrs.Item("UsedBy") = Datasprint.Rows(0)(7).ToString()
                getdrs.Item("UsedTime") = Datasprint.Rows(0)(8).ToString()
                getdrs.Item("Printby") = Datasprint.Rows(0)(9).ToString()
                getdrs.Item("PrintTime") = Datasprint.Rows(0)(10).ToString()

                getdt.Rows.Add(getdrs)

                Me.DataGridView1.DataSource = getdt
            End If
        End If

    End Sub

    Private Sub Print2_Click(sender As Object, e As EventArgs) Handles Print2.Click
        Try

      
        If Me.TextBox1.Text.Trim().ToString() <> "" Or Me.TextBox2.Text.Trim().ToString() <> "" Then
            Dim fullfilename As String = "C:\Program Files\默认公司名称\Bartender.txt"
            Dim fs1 As FileStream = New FileStream(fullfilename, FileMode.Create)
            Dim sw1 As StreamWriter = New StreamWriter(fs1, Encoding.UTF8)
            Dim sb As StringBuilder = New StringBuilder()
            Dim temp As Integer = 0

            sb.Append("SN" + Environment.NewLine)
            'sb.Append(tempSN.ToString().Trim())
            sb.Append(TextBox1.Text.ToString().Trim())

            sw1.Write(sb)
            sw1.Flush()
            sw1.Close()
            fs1.Close()

            Dim sqlpath As String = "select st.TemplatePath from m_SnMFormat_t st inner join m_PartPack_t k on st.PFormatID = k.PFormatID inner join m_SettingParameter_t  t on k.StatusFlag= t.PARAMETER_VALUE where k.Partid='" + Me.TextBox5.Text.Trim().ToString() + "' and Packid='S' and PARAMETER_CODE='PartStatusFlagText' and t.PARAMETER_VALUE=2"
            Dim Datapath As DataTable = conn.GetDataTable(sqlpath)
            If Datapath.Rows.Count > 0 Then
                pFilePath = Datapath.Rows(0)(0).ToString()
            End If

            Dim filepath As String = VbCommClass.VbCommClass.PrintDataModle & pFilePath
            Dim TxtFileStr As StringBuilder = New StringBuilder()
            Dim TxtFileStrCommon As StringBuilder = New StringBuilder()
            Dim titlestr As StringBuilder = New StringBuilder()
            Dim printDoc As System.Drawing.Printing.PrintDocument = New System.Drawing.Printing.PrintDocument()

            btFormat = btApp.Formats.Open(filepath, False, String.Empty)
            btFormat.Printer = printDoc.PrinterSettings.PrinterName
            Dim aa As BarTender.Messages
            btFormat.Print("", False, -1, aa)

            Dim sqlS As String = "update Wifi6_sn_mac set IsPrint=2,CPrintTime='" + DateTime.Now + "',CPrintby='" + VbCommClass.VbCommClass.UseId + "' where IsPrint=10 and SN='" + TextBox1.Text.ToString().Trim() + "'"
            Dim DataS As DataTable = conn.GetDataTable(sqlS)

        End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If TextBox4.Text.Trim().ToString() <> "" Then
            Dim sqlM As String = "select top 1 PartID,Moqty from M_MAINMO_T with(nolock) where Moid='" + Me.TextBox4.Text.Trim().ToString() + "'"
            Dim Data As DataTable = conn.GetDataTable(sqlM)
            Dim sqlM1 As String = "select SN from Wifi6_sn_mac where IsPrint = 1 and Work_order ='" + Me.TextBox4.Text.Trim().ToString() + "'"
            Dim Data1 As DataTable = conn.GetDataTable(sqlM1)
            If Data.Rows.Count > 0 Then
                Me.TextBox5.Text = Data.Rows(0)(0).ToString()
                Me.TextBox3.Text = Data.Rows(0)(1).ToString()
                If Data1.Rows.Count > 0 Then
                    Me.TextBox7.Text = (Convert.ToInt32(TextBox3.Text.Trim()) - Data1.Rows.Count).ToString()
                    tempNum = Convert.ToInt32(TextBox3.Text.Trim()) - Data1.Rows.Count
                Else
                    tempNum = Convert.ToInt32(TextBox3.Text)
                    Me.TextBox7.Text = Convert.ToInt32(TextBox3.Text)

                End If
                ComboBox1.SelectedIndex = -1
            End If
        End If
    End Sub
End Class