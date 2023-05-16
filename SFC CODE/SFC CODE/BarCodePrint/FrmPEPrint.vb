
'--PE袋条码打印
'--Create by :　byron(黄广都)
'--Create date :　2017/06/17
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports BarCodePrint.SqlClassM
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports MainFrame

#End Region

Public Class FrmPEPrint

#Region "属性字段"
    Dim LoadM As New BarCodePrint.SqlClassM
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim BarCodePartTable As New DataTable
    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()
    Dim pFilePath As String = Nothing
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format

#End Region

#Region "窗体事件"
    Private Sub FrmPEPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass
        SqlClassM.GetPrintersList(CboPrinters)
    End Sub


    Private Sub txtMoid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMoid.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                If String.IsNullOrEmpty(Me.txtMoid.Text.Trim.Trim()) Then
                    Me.lbMsg.Text = "请输入工单编码!"
                    Exit Sub
                End If
                SetBaseData()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "txtMoid_KeyDown", "sys")
        End Try
    End Sub
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim dt As New DataTable
        If String.IsNullOrEmpty(Me.txtMoid.Text.Trim) Then
            Me.lbMsg.Text = "请输入工单编号！"
            Exit Sub
        End If
        SetBaseData()
        dt = GetResetPrintData()

        If dt.Rows.Count > 0 Then
            Me.dgvPrintList.Rows.Clear()

            For i As Int16 = 0 To dt.Rows.Count - 1
                Dim defaultSelected As Boolean = False
                '条码，工单编号，线别，物料编码，标签类型，申请人员，申请时间e()
                Me.dgvPrintList.Rows.Add(defaultSelected, dt.Rows(i)!SBarCode.ToString, dt.Rows(i)!Moid.ToString, dt.Rows(i)!Lineid.ToString, dt.Rows(i)!PartID.ToString, dt.Rows(i)!Packid.ToString, dt.Rows(i)!Userid.ToString, dt.Rows(i)!Intime.ToString, dt.Rows(i)!BartenderFile.ToString)

            Next

        End If

    End Sub
    '条码打印
    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        BarValueStr.Remove(0, BarValueStr.Length)
        BarFile.Remove(0, BarFile.Length)
        Dim makedate As String = String.Empty
        Dim SqlStr As New StringBuilder
        Dim CurrNum As Int16 = 0
        Dim LineId As String = String.Empty
        Dim SBarcode As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        Try
            If InputCheck() = True Then
                LoadD.CurrMoid = Me.txtMoid.Text.Trim
                BarCodePartTable = GetPrintDataTable()
                If BarCodePartTable Is Nothing OrElse BarCodePartTable.Rows.Count = 0 Then
                    Me.lbMsg.Text = "当前没有可打印的记录！"
                    Exit Sub
                End If
                For i As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    SBarcode = BarCodePartTable.Rows(i)!SBarCode.ToString
                    CModlePrintGenRecord(SBarcode)
                    LoadM.DefaultLine = BarCodePartTable.Rows(i)!Lineid.ToString
                    makedate = BarCodePartTable.Rows(i)!Makedate.ToString

                    LineId = BarCodePartTable.Rows(i)!Lineid.ToString
                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & BarCodePartTable.Rows(i)!SBarCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','C',1,'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & makedate & "','" & pFilePath & "','1','C',1);")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & LoadD.CurrAVCPartID & "','" & LoadD.CurrMoid & "','C','1','1','" & SBarcode & "','1');")

                    SqlStr.Append(vbNewLine & "INSERT INTO m_PEBarCodeRecode_t(SBarCode ,Moid,Lineid,PartID,Packid,Userid,Intime,BartenderFile)values('" & SBarcode & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & LoadD.CurrAVCPartID & "','C','" & SysMessageClass.UseId.ToLower & "',GETDATE(),'" & Me.pFilePath & "')")
                    '打印记录
                    If Not String.IsNullOrEmpty(LoadM.Taskid) Then
                        SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                    " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LineId & "','C','" & LoadD.StyleID & "',1,1,'" & SBarcode & "','" & makedate & "','" & SysMessageClass.UseId.ToLower & "',getdate())")

                    End If

                    If pFilePath Is Nothing OrElse String.IsNullOrEmpty(pFilePath) Then
                        GetCodeRuleID()
                    End If

                    CurrNum += 1

                Next

                '更新工单包装
                SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

                BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
                If SqlStr.ToString() <> "" Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                    FileToBarCodePrint(pFilePath, Me.CboPrinters.Text.Trim)
                End If

            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "toolPrint_Click", "sys")
        Finally
            Me.lbMsg.Text = ""
            Me.Cursor = Cursors.Default
        End Try
       
    End Sub

    '标签重新打印
    Private Sub toolAgainPrint_Click(sender As Object, e As EventArgs) Handles toolAgainPrint.Click
        If Me.dgvPrintList.RowCount < 1 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then Exit Sub

        If InputCheck() = True Then
            Dim idx As Int16 = 0
            Dim chkTemp As DataGridViewCheckBoxCell
            For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                chkTemp = dgvPrintList.Rows(i).Cells("Chk")
                If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                    CModlePrintGenRecord(dgvPrintList.Rows(i).Cells("Colppid").Value.ToString)
                    Me.pFilePath = dgvPrintList.Rows(i).Cells("coltemppath").Value.ToString
                    idx += 1
                End If
            Next



            If idx = 0 Then
                Me.lbMsg.Text = "请勾选待打印的标签!"
                Exit Sub
            End If
            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            FileToBarCodePrint(pFilePath, Me.CboPrinters.Text.Trim)

        End If



    End Sub




    Private Sub chkSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("Chk").Value = Me.chkSelect.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "chkSelect_CheckedChanged", "sys")
        End Try
    End Sub


    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region


#Region "方法函数"



    Private Function InputCheck() As Boolean
        If String.IsNullOrEmpty(Me.txtMoid.Text.Trim()) Then
            Me.lbMsg.Text = "请输入工单编码!"
            Me.txtMoid.Focus()
            Return False
        End If
        If (String.IsNullOrEmpty(Me.CboPrinters.Text.Trim)) Then
            Me.lbMsg.Text = "请选择打印机!"
            Me.CboPrinters.Focus()
            Return False
        End If
        

        Return True
    End Function


    Private Function GetPrintDataTable() As DataTable
        Dim dt As New DataTable
        Dim printQty As String = "10000"

        Try
            Dim o_strSql As New StringBuilder
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            If Not String.IsNullOrEmpty(Me.txtPrintQty.Text) AndAlso Me.txtPrintQty.Text <> "" Then
                printQty = Me.txtPrintQty.Text
            End If
            o_strSql.Append("select top " & printQty & "   SBarCode,Moid,Lineid,Packid,Makedate from m_SnSBarCode_t WHERE Moid='" & Me.txtMoid.Text.Trim() & "'")
            o_strSql.Append(" and not exists (select 1 from  m_PEBarCodeRecode_t b where b.Moid=m_SnSBarCode_t.Moid ")
            o_strSql.Append(" and b.Packid='C' and b.SBarCode=m_SnSBarCode_t.SBarCode ) and Packid='S' ORDER BY SBarCode,Intime asc")
            dt = DAL.GetDataTable(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "GetPrintDataTable()", "sys")
        End Try
        Return dt
    End Function


    Private Sub SetBaseData()
        Dim dt As New DataTable
        Try
            Dim o_strSql As New StringBuilder
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            o_strSql.Append("select a.PartId,b.Ptaskid from m_Mainmo_t  a left join  ")
            o_strSql.Append(" m_SnAssign_t b on b.Moid=a.Moid and b.Packid='C' and b.Packitem=1  where a.Moid='" & Me.txtMoid.Text.Trim & "'")
          
            dt = DAL.GetDataTable(o_strSql.ToString)

            If dt.Rows.Count > 0 Then
                LoadD.CurrAVCPartID = dt.Rows(0)!PartId.ToString
                LoadD.CurrMoid = Me.txtMoid.Text.Trim
                LoadM.Taskid = dt.Rows(0)!Ptaskid.ToString
                Me.txtPartId.Text = dt.Rows(0)!PartId.ToString

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "SetBaseData()", "sys")
        End Try
    End Sub

    ''码元值生成至数据库，供exce调用
    Private Sub CModlePrintGenRecord(ByVal snbarcode As String)
   
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24]) " & _
                      "VALUES('C','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate()," & _
                      "'" & snbarcode & "','','','','','','','','','','','','','','',''"
        Dim nPrintStr = New StringBuilder()
        Try
            nPrintStr.Append(snbarcode)

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray


                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If



                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

            Dtable = Nothing
        Catch ex As Exception
            Dtable = Nothing
            Throw ex
        End Try

    End Sub

    '获取编码原则
    Private Sub GetCodeRuleID()
        Try
            Dim o_strSql As New StringBuilder
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim dt As New DataTable
            o_strSql.Append("select  distinct A.CodeRuleID,a.PFormatID,b.TemplatePath from m_PartPack_t a  inner join ")
            o_strSql.Append(" M_SnMFormat_t b on b.PFormatID=a.PFormatID where a.Packid='C'and a.Usey='Y'  and a.Partid='" & LoadD.CurrAVCPartID & "'  AND Qty=1  ")
            dt = DAL.GetDataTable(o_strSql.ToString)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                LoadM.CodeRule = dt.Rows(0)!CodeRuleID.ToString
                Me.pFilePath = dt.Rows(0)!TemplatePath.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "GetCodeRuleID()", "sys")
        End Try
    End Sub


    '打印
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub


    '补打标签检验是否已经打印过
    Private Function checkIsExistsPpId(ByVal ppid As String) As Boolean
        Try
            'select * from m_PEBarCodeRecode_t where Moid='5121E-170601051' and PartID='LA05US018-1N' and Packid='C'

            Dim o_strSql As New StringBuilder
            Dim iCount As Int16 = 0
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            o_strSql.Append("select * from m_PEBarCodeRecode_t where Moid='" & LoadD.CurrMoid & "' and PartID='" & LoadD.CurrAVCPartID & "' and Packid='C'  ")
            iCount = DAL.GetRowsCount(o_strSql.ToString)
            If iCount <= 0 Then
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "checkIsExistsPpId()", "sys")
        End Try
        Return True
    End Function

    Private Function GetResetPrintData() As DataTable

        Dim dt As New DataTable
        Try
          
            Dim o_strSql As New StringBuilder

            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            o_strSql.Append("select top 2000  SBarCode,Moid,Lineid ,PartID,Packid,Userid,Intime,BartenderFile from m_PEBarCodeRecode_t where Moid='" & Me.txtMoid.Text & "' and Packid='C'  ")
            If Not String.IsNullOrEmpty(Me.txtPpid.Text) Then
                o_strSql.Append(" and SBarCode like '%" & Me.txtPpid.Text & "%' ")
            End If
            o_strSql.Append(" order by SBarCode,Intime asc ")
            dt = DAL.GetDataTable(o_strSql.ToString)
        
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPEPrint", "GetResetPrintData()", "sys")
        End Try
        Return dt
    End Function
#End Region






End Class