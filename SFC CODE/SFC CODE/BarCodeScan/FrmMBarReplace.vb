''蠢传ゴ    稼稻瞝   2007/05/16

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.IO
#End Region

Public Class FrmMBarReplace

    Dim QtyStr As String = ""
    Dim BarRuleStr As String = ""

    Dim btApp As BarTender.Application

    'Declare a BarTender format variable 

    Dim btFormat As New BarTender.Format

    'Dim btApp As BarTender.Application
    'Dim btFormat As New BarTender.Format
    'Declare a BarTender format variable 

    'Dim btApp As BarTender.Application
    'Private Shared engine As Seagull.BarTender.Print.Engine = Nothing ' T
    ''Private Shared engine As Seagull.BarTender.Print.Engine = Nothing ' The BarTender Print Engine
    'Private Shared format As LabelFormatDocument = Nothing ' The currently open Format
    'Private Const appName As String = "Label Print"
    'Private Const dataSourced As String = "Data Sourced"

    'Shared btApp As New BarTender.ApplicationClass()
    'Shared btFormat As BarTender.Format
    'Shared btMsgs As BarTender.Messages


    Public Sub New(ByVal Partid As String)

        InitializeComponent()
        Me.TxtPartid.Text = Partid

    End Sub

#Region "怠砰秙ㄆン"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.Close()
        ScanPrint.ReplacePrintCheck = False

    End Sub

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnOpenlock
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New SysDataBaseClass

        ''ScanPrint.vReplaceMo = Nothing
        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510c_'")
        If Not CheckRead.Read Then
            MessageBox.Show("你没有权限进行替换打印", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ScanPrint.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If
        CheckRead.Close()
        Dim ReadSn As String = Me.TxtPackNo.Text.Trim
        If InStr(Me.TxtPackNo.Text.ToLower, "accessory serial number:") > 0 Then
            For i As Integer = 0 To TxtPackNo.Lines.Length - 1
                If InStr(TxtPackNo.Lines(i).ToString.ToLower, "accessory serial number:") > 0 Then
                    ReadSn = TxtPackNo.Lines(i).ToString.Split(":")(1).Trim
                    Exit For
                End If
            Next
        End If
        'Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            'BarRprintHandle.BarCodeToFile(ReadSn, TxtPartid.Text)
            BarCodeToFile(UCase(ReadSn), TxtPartid.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

        CheckRead.Close()
        ScanPrint.ReplacePrintCheck = True
        Me.TxtPackNo.Clear()
        Me.TxtPackNo.Focus()
        'Me.Close()

    End Sub


#Region "条码数据生成至File数据库"
    Public Sub BarCodeToFile(ByVal BarDataStr As String, ByVal partid As String)

        Dim TxtFileStr As New StringBuilder
        Dim pFilePath As String = ""
        Dim mDataRaed As SqlClient.SqlDataReader
        Dim PubClass As New SysDataBaseClass
        Dim PPidstr As String = ""
        Try
            Dim sqlstr As String = " select [barcodesnid],[label10],[label11],[label12],[label13],[label14]," & _
                             "[label15],[label16],[label17],[label18],[label19],[label20],[label21],[label22]," & _
                             "[label23],[label24],[label25],[label26],[label27],[label28],[label29],[label30],[label31],[label32],[label33],[label34],[label35],[label36],[label37],[label38],[labe19] from m_BarRecordValue_t   where [barcodesnid]='" & BarDataStr & "'"
            mDataRaed = PubClass.GetDataReader(sqlstr)
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    TxtFileStr.Append("""" & mDataRaed!barcodesnid.ToString & """" & "," & """" & mDataRaed!label10.ToString & """" & "," & """" & mDataRaed!label11.ToString & """" _
                                      & "," & """" & mDataRaed!label12.ToString & """" & "," & """" & mDataRaed!label13.ToString & """" & "," & """" & mDataRaed!label14.ToString & """" _
                                      & "," & """" & mDataRaed!label15.ToString & """" & "," & """" & mDataRaed!label16.ToString & """" & "," & """" & mDataRaed!label17.ToString & """" _
                                      & "," & """" & mDataRaed!label18.ToString & """" & "," & """" & mDataRaed!label19.ToString & """" & "," & """" & mDataRaed!label20.ToString & """" _
                                      & "," & """" & mDataRaed!label21.ToString & """" & "," & """" & mDataRaed!label22.ToString & """" & "," & """" & mDataRaed!label23.ToString & """" _
                                      & "," & """" & mDataRaed!label24.ToString & """" & "," & """" & mDataRaed!label25.ToString & """" & "," & """" & mDataRaed!label26.ToString & """" _
                                      & "," & """" & mDataRaed!label27.ToString & """" & "," & """" & mDataRaed!label28.ToString & """" & "," & """" & mDataRaed!label29.ToString & """" _
                                      & "," & """" & mDataRaed!label30.ToString & """" & "," & """" & mDataRaed!label31.ToString & """" & "," & """" & mDataRaed!label32.ToString & """" _
                                      & "," & """" & mDataRaed!label33.ToString & """" & "," & """" & mDataRaed!label34.ToString & """" & "," & """" & mDataRaed!label35.ToString & """" _
                                      & "," & """" & mDataRaed!label36.ToString & """" & "," & """" & mDataRaed!label37.ToString & """" & "," & """" & mDataRaed!label38.ToString & """" & "," & """" & mDataRaed!labe19.ToString & """")
                    'pFilePath = mDataRaed!BartenderFile.ToString()
                End While
            End If
            mDataRaed.Close()
            'MessageBox.Show(TxtFileStr.ToString)

            'TxtFileStr.Append("""" & BarDataStr & """")
            mDataRaed = PubClass.GetDataReader("select  isnull(isRplacePath,'') isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1 and  IslineMbarcode='Y'")
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    pFilePath = mDataRaed!isRplacePath.ToString
                End While
                mDataRaed.Close()
            End If
            mDataRaed.Close()
            If pFilePath = "" Then
                'mDataRaed.Close()
                'Throw New Exception("模板不能为空")
                mDataRaed = PubClass.GetDataReader("select top 1 BartenderFile from m_SnSBarCode_t where sbarcode='" & BarDataStr & "'")
                If mDataRaed.HasRows Then
                    While mDataRaed.Read
                        pFilePath = mDataRaed!BartenderFile.ToString
                    End While
                Else
                    MessageBox.Show("没有该条码的任何资料...")
                    mDataRaed.Close()
                    Exit Sub
                End If
                mDataRaed.Close()
                'MessageBox.Show("")
                'Exit Sub
            End If
            'MessageBox.Show(pFilePath)
            'MessageBox.Show(pFilePath.ToString)
            If pFilePath = "" Then Exit Sub
            'TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24"",""lable25"",""lable26"",""lable27"",""lable28"",""lable29"",""lable30"",""lable31"",""lable32"",""lable33"",""lable34"",""lable35"",""lable36"",""lable37"",""lable38"",""labe19""" & vbNewLine)
            'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
            'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            'End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
            PubClass.ExecSql("insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime)values('" & BarDataStr & "','" & BarDataStr & "',N'替换打印','" & SysMessageClass.UseId & "',getdate()" & ")")

            FileToBarCodePrint(VbCommClass.VbCommClass.PrintDataModle & pFilePath)

        Catch ex As Exception
            'mDataRaed.Close()
            Throw ex
        End Try


    End Sub
#End Region

#Region "条码打印方法更新，优化速度"

    Private Sub FileToBarCodePrint(ByVal LableFile As String)

        If LableFile = "" Then
            MessageBox.Show("该料件的打印格式，未上传打印模版...")
            Exit Sub
        End If
        Try
           

            btFormat = btApp.Formats.Open(LableFile, False, String.Empty)
            'Me.Timer1.Stop()
            'MessageBox.Show(mytime)
            'btFormat.PrintOut(False, False)
            btFormat.Print("", False, -1, Nothing)
            'Me.Timer1.Stop()
            'End the BarTender process 
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)


            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            'MessageBox.Show("打印成功...")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
      
        'engine = New Engine(True)
        'SyncLock engine
        '    Dim success As Boolean = True
        '    format = engine.Documents.Open(LableFile)

        '    'Cursor.Current = Cursors.WaitCursor

        '    ' Get the printer from the dropdown and assign it to the format.
        '    'If cboPrinters.SelectedItem IsNot Nothing Then
        '    '    format.PrintSetup.PrinterName = cboPrinters.SelectedItem.ToString()
        '    'End If

        '    Dim messages As Messages = Nothing
        '    Dim waitForCompletionTimeout As Integer = 0 ' 10 seconds
        '    Dim result As Result = format.Print(appName, waitForCompletionTimeout, messages)
        '    Dim messageString As String = Constants.vbLf + Constants.vbLf & "Messages:"

        '    'For Each message As Seagull.BarTender.Print.Message In messages
        '    '    messageString &= Constants.vbLf + Constants.vbLf + message.Text
        '    'Next message
        '    format.Close(SaveOptions.DoNotSaveChanges)
        '    engine.Stop()

        'End SyncLock

    End Sub

#End Region

    Private Sub FrmReplaceLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        If Me.ActiveControl.Name <> "BnOpenlock" Then ScanPrint.ReplacePrintCheck = False

    End Sub

    Private Sub FrmReplaceLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        btApp = New BarTender.ApplicationClass
        TxtPackNo.Focus()
        'Dim SqlStr As String
        'Dim PubClass As New SysDataBaseClass
        'Dim Dr As SqlClient.SqlDataReader
        'SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & ScanPrint.PartidStr & " '  and usey='Y' "
        'Dr = PubClass.GetDataReader(SqlStr)
        'If Dr.Read Then
        '    QtyStr = Dr("Qty").ToString
        '    BarRuleStr = Dr("coderuleid").ToString
        'End If
        'Dr.Close()

    End Sub

    Private Sub TxtPackNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPackNo.KeyPress

        'If e.KeyChar = Chr(13) Then
        '    Me.TxtPassWord.Focus()
        'End If

    End Sub

End Class