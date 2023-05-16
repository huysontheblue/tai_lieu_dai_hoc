Imports System.Text
Imports MainFrame
Imports System.IO

'--批次条码打印作业共通部分
'--Create by :　田玉琳
'--Create date :　2016/01/28
'--Update date :  
'--Update by :
'--Ver : V01

Public Class LotPrint

    '取得打印数据，设置打印数据内容
    Public Shared Function GetPrintData(BarTend As String) As StringBuilder
        Dim BarFile As New StringBuilder()
        Try
            Dim strSQL As String =
            "select label10,label11,label12,label13,label14,label15,label16,label17,label18,label19,label20,label21,label22,label23,label24 " &
            "from m_BarRecordValue_t " &
            "where barcodesnid = '{0}'"
            strSQL = String.Format(strSQL, BarTend)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If (dt.Rows.Count = 0) Then
                Throw New Exception("MES打印表中没有要打印数据，请联系标签室!")
            End If

            For Each dr As DataRow In dt.Rows
                BarFile.Append("""" & BarTend & """")
                For Each dc As DataColumn In dt.Columns
                    BarFile.Append(",""" & dr(dc.ColumnName).ToString() & """")
                Next
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            Next

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

        Catch ex As Exception
            Throw ex
        End Try
        Return BarFile
    End Function

    '取得打印内容
    Public Shared Function GetPrintDataContent(ByRef BarFile As StringBuilder,
                                               moid As String, partId As String, barCode As String,
                                               makedate As String, moidQty As String, lotQty As String) As String
        'Dim strBSQL As New StringBuilder
        'Dim strSQL As String = vbNewLine & " INSERT INTO [m_BarRecordValue_t]" & _
        '          "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
        '         ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
        '         ",[label23],[label24]) " & _
        '          "VALUES('L','" & My.Computer.Name & "','" & moid & "','" & partId & "',getdate(),"
        'strBSQL.Append(strSQL)
        'strBSQL.AppendFormat("N'{0}',", barCode)        'barcodeSNID
        'strBSQL.AppendFormat("N'{0}',", stationId)      'label10
        'strBSQL.AppendFormat("N'{0}',", befStationId)   'label11
        'strBSQL.AppendFormat("N'{0}',", aftStationId)   'label12
        'strBSQL.AppendFormat("N'{0}',", makedate)       'label13
        'strBSQL.AppendFormat("N'{0}',", moidQty)        'label14
        'strBSQL.AppendFormat("N'{0}',", lotQty)         'label15
        'strBSQL.Append(");")
        BarFile.Append("""" & barCode & """")
        BarFile.Append(",""" & moid & """")
        BarFile.Append(",""" & partId & """")
        'BarFile.Append(",""" & stationId & """")
        'BarFile.Append(",""" & befStationId & """")
        'BarFile.Append(",""" & aftStationId & """")
        BarFile.Append(",""" & makedate & """")
        BarFile.Append(",""" & moidQty & """")
        BarFile.Append(",""" & lotQty & """")
        BarFile.Append(Constants.vbNewLine)

        Return BarFile.ToString
    End Function

    '写入数据到文件中
    Public Shared Sub FileToBarCodePrint(strTemplatePath As String, BarFile As StringBuilder, printName As String)

        'add by hgd 20180406 更改为当前安装路径
        Dim path As String = System.Windows.Forms.Application.StartupPath & "\Bartender.txt"
        'Dim path As String = "C:\Program Files\默认公司名称\Bartender.txt"
        BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

        File.WriteAllText(path, BarFile.ToString, Encoding.UTF8)
        FileToBarCodePrint(strTemplatePath, printName)
    End Sub

    '打印条码
    Private Shared Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        '每次新建，用完再释放，看是否影响性能
        Dim btApp As BarTender.Application = New BarTender.ApplicationClass
        Dim btFormat As BarTender.Format = New BarTender.Format

        btFormat = btApp.Formats.Open(pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub


End Class
