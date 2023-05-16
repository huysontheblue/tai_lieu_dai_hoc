Imports System.IO
Imports System.ComponentModel
Imports ICSharpCode.SharpZipLib.Zip
Imports System.Text

Public Class HW_UIDDataAdd
    Dim worker As BackgroundWorker = Nothing
    '是否刷新主界面
    Private _IsRefresh As Boolean = False
    Public ErrorCount As Integer = 0
    Dim ErrorCounts As Integer = 0
    Dim Errors As String
    Dim max As Integer = 0
    Dim strDataFiles As String() = New String() {}
    Dim FOM As HW_IMG = New HW_IMG()
    Dim decompression As String
    Public ReadOnly Property IsRefresh() As Boolean
        Get
            Return _IsRefresh
        End Get
    End Property
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass()
    Public FileList() As String
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        'progressBar1.Minimum = 0
        'progressBar1.Maximum = 100
        worker = New BackgroundWorker()
        worker.WorkerReportsProgress = True
        worker.WorkerSupportsCancellation = True

        AddHandler worker.DoWork, AddressOf worker_DoWork
        AddHandler worker.ProgressChanged, AddressOf worker_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf worker_RunWorkerCompleted
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Try
            If Not e.Argument Is Nothing Then
                worker.ReportProgress(0)
                Dim localPath As String = Application.StartupPath & "\" + Now.ToString("yyyyMMdd")
                Dim obj As SysBasicClass.LogHelper = New SysBasicClass.LogHelper(True, localPath)
                Dim OK As Integer = 0
                Dim NG As Integer = 0
                For i = 0 To FileList.Length - 1
                    decompression = "Y"
                    Dim percent1 As Integer = CType(((i + 1) * 100 / FileList.Length), Integer)
                    worker.ReportProgress(percent1)
                    System.Threading.Thread.Sleep(8000)
                    Dim route As String = Application.StartupPath & "\"
                    Dim s As String() = New String() {FileList(i).ToString(), route + "ZipOutPut\"}
                    UnZip(s)
                    Dim basepath As String = route + "ZipOutPut\"
                    strDataFiles = Directory.GetFiles(basepath)
                    max = strDataFiles.Length
                    decompression = "N"
                    For index = 0 To strDataFiles.Length - 1
                        ErrorCounts = index
                        Dim Message As String = SaveData(strDataFiles(index).ToString())
                        'ListBox1.Items.Add(Str(i).ToString())
                        SetItemValue("更新文件：" & strDataFiles(index).ToString() + " 进行中......", ListBox1, i)
                        If (Message) <> "" Then
                            SetItemValue("文件：" & Path.GetFileName(strDataFiles(index).ToString()) + " 上传失败" + Message, ListBox1, i)
                            NG = NG + 1
                            ErrorCount = ErrorCount + 1
                            obj.WriteLog("文件：" & Path.GetFileName(strDataFiles(index).ToString()) + " 上传失败" + Message)
                            Errors = "文件：" & Path.GetFileName(strDataFiles(index).ToString()) + " 上传失败" + Message
                            'SetText(i, lbmessage)
                        Else
                            SetItemValue("文件：" & Path.GetFileName(strDataFiles(index).ToString()) + " 100%", ListBox1, i)
                            Errors = "文件：" & Path.GetFileName(strDataFiles(index).ToString()) + " 100%" + Message
                            OK = OK + 1
                        End If
                        Dim msg As String = "成功数量:" + OK.ToString + ";失败数量:" + NG.ToString

                        SetText(msg, lbmessage)

                        If ErrorCount > 0 Then
                            SetBgColor(Color.Red, lbmessage)
                        Else
                            SetBgColor(Color.Green, lbmessage)
                        End If

                        Dim percent As Integer = CType(((i + 1) * 100 / FileList.Length), Integer)
                        'SetText(Offset.ToString + "/" + totalByte.ToString, lblprogress)
                        'SetItemValue("更新文件：" & fname + " " & percent & "%", ListBox1, indexcurr)

                        worker.ReportProgress(percent)
                        Threading.Thread.Sleep(100)
                    Next
                Next
                worker.ReportProgress(100)
                USIDUse(txtPartID.Text.Trim, OK.ToString)

            End If
        Catch ex As Exception
            MessageBox.Show("有异常发生：" + ex.Message.ToString + "退出文件上传")
            worker.ReportProgress(100)
        End Try


    End Sub
    Private Sub USIDUse(ByVal Partid As String, ByVal qty As String)
        If qty <= 0 Then
            Return
        End If
        Dim sql As String = "SELECT COUNT(*)  FROM MESDataCenter.dbo.m_HW_C314UIDUse WHERE PartID ='" + Partid + "'"
        Dim dat As DataTable = conn.GetDataTable(sql)
        If dat.Rows(0)(0).ToString() = "0" Then
            sql = "SELECT COUNT(*) FROM MESDataCenter.dbo.m_HW_C314OTAUID_t WHERE PartID ='" + Partid + "'"
            dat = conn.GetDataTable(sql)
            sql = "INSERT INTO MESDataCenter.dbo.m_HW_C314UIDUse(Partid,Total,Alreadyused,Occupy,Tovoid,USID) VALUES ('" + Partid + "','" + dat.Rows(0)(0).ToString() + "','0','0','0','" + VbCommClass.VbCommClass.UseId + "')"
            dat = conn.GetDataTable(sql)
        Else
            sql = "UPDATE MESDataCenter.dbo.m_HW_C314UIDUse SET Total= ((SELECT Total FROM MESDataCenter.dbo.m_HW_C314UIDUse WHERE Partid='" + Partid + "')+" + qty + ") WHERE Partid='" + Partid + "'"
            dat = conn.GetDataTable(sql)
        End If
    End Sub
    Private Sub worker_ProgressChanged(ByVal sender As System.Object, ByVal e As ProgressChangedEventArgs)
        Try
            If Not e.UserState Is Nothing Then
                ' lblMsg.Text = CType(e.UserState, Exception).Message
            Else
                If decompression = "Y" Then
                    Me.Opacity = 0.0R
                    Try
                        FOM.Show()
                    Catch ex As Exception
                        FOM = New HW_IMG()
                        FOM.Show()
                    End Try
                Else
                    FOM.Close()
                    Me.Opacity = 100.0R
                End If
                progressBar1.Value = e.ProgressPercentage
                ProgressBar2.Maximum = max - 1
                ProgressBar2.Value = ErrorCounts
                ListBox2.Items.Add(Errors)
                ListBox2.TopIndex = ListBox2.Items.Count - 1
               
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub worker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'lblMsg.Text = "文件复制完成"
        'If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & StartApp) Then

        '    System.Diagnostics.Process.Start(Application.StartupPath & "\" & StartApp)
        '    Application.ExitThread()
        'Else
        '    Me.ListBox1.Items.Add("启动程序【" & StartApp & "】不存在!自动退出")
        '    MessageBox.Show("启动程序【" & StartApp & "】不存在!程序自动退出")
        '    Me.Close()
        'End If
        If ErrorCount > 0 Then

        Else
            Me._IsRefresh = True
            Me.Close()
        End If

    End Sub
    Delegate Sub SetTextCallback(ByVal val As String, ByVal obj As Object)
    Sub SetText(ByVal TValue As String, ByVal TempC As Object)
        Try
            Dim obj As Control = CType(TempC, Control)
            If (obj.InvokeRequired) Then
                Dim d As SetTextCallback = New SetTextCallback(AddressOf SetText)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.Text = TValue
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Delegate Sub SetBgColorCallback(ByVal val As Color, ByVal obj As Object)
    Sub SetBgColor(ByVal TValue As Color, ByVal TempC As Object)
        Try
            Dim obj As Control = CType(TempC, Control)
            If (obj.InvokeRequired) Then
                Dim d As SetBgColorCallback = New SetBgColorCallback(AddressOf SetBgColor)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.ForeColor = TValue
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Delegate Sub SetAddItemCallback(ByVal val As String, ByVal obj As ListBox)
    Sub SetAddItem(ByVal TValue As String, ByVal TempC As ListBox)
        Try
            Dim obj As ListBox = TempC
            If (obj.InvokeRequired) Then
                Dim d As SetAddItemCallback = New SetAddItemCallback(AddressOf SetAddItem)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.Items.Add(TValue)
                obj.Refresh()

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Delegate Sub SetItemValueCallback(ByVal val As String, ByVal obj As ListBox, ByVal curr As Integer)
    Sub SetItemValue(ByVal TValue As String, ByVal TempC As ListBox, ByVal curr As Integer)
        Try
            Dim obj As ListBox = CType(TempC, ListBox)
            If (obj.InvokeRequired) Then
                Dim d As SetItemValueCallback = New SetItemValueCallback(AddressOf SetItemValue)
                Me.Invoke(d, New Object() {TValue, obj, curr})
            Else
                obj.Items(curr) = TValue
                obj.SelectedIndex = curr
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If txtPartID.Text = "" Then
            MessageBox.Show("请先输入对应的料号")
            Return
            'txtPartID.Text = Now.ToString("yyyyMMddHHmm")
        End If
        ButtonX1.Enabled = False
        txtPartID.Enabled = True
        Me.OpenFileDialog1.Multiselect = True
        ButtonX2.Enabled = False
        Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Me.txtPath.Text = Me.OpenFileDialog1.FileName.Substring(0, Me.OpenFileDialog1.FileName.LastIndexOf("\"))
        ' Dim str() As String = OpenFileDialog1.FileNames
        FileList = OpenFileDialog1.FileNames
        For i = 0 To FileList.Length - 1
            ListBox1.Items.Add(FileList(i).ToString())
            'SaveData(str(i).ToString())
        Next
        If FileList.Length > 0 Then
            worker.RunWorkerAsync(0)
        End If
    End Sub
    Private Function UnZip(args) As String()
        Dim route As String = Application.StartupPath & "\"
        If Not System.IO.Directory.Exists(route + "ZIP") Then
            System.IO.Directory.CreateDirectory(route + "ZIP")
        End If

        If Not System.IO.Directory.Exists(route + "ZipOutPut") Then
            System.IO.Directory.CreateDirectory(route + "ZipOutPut")
        End If
        Dim strFiles As String() = System.IO.Directory.GetFiles(args(1))
        Dim datei As String = DateTime.Now.ToString() & "ZipOutPut.zip"
        datei = datei.Replace("/", String.Empty)
        datei = datei.Replace(":", String.Empty)
        System.IO.File.Copy(args(0), route + "ZIP\" & datei)

        For Each strFile As String In strFiles
            System.IO.File.Delete(strFile)
        Next

        Dim s As ZipInputStream = New ZipInputStream(File.OpenRead(args(0)))
        Dim r As String = s.Length.ToString()
        Try
            Dim theEntry As ZipEntry
            theEntry = s.GetNextEntry()
            While ((theEntry) IsNot Nothing)
                Dim directoryName As String = Path.GetDirectoryName(args(1))
                Dim fileName As String = Path.GetFileName(theEntry.Name)
                Directory.CreateDirectory(directoryName)

                If fileName <> String.Empty Then
                    Dim streamWriter As FileStream = File.Create(args(1) & fileName)
                    Dim size As Integer = 2048
                    Dim data As Byte() = New Byte(2047) {}

                    While True
                        size = s.Read(data, 0, data.Length)

                        If size > 0 Then
                            streamWriter.Write(data, 0, size)
                        Else
                            Exit While
                        End If
                    End While

                    streamWriter.Close()
                End If
                theEntry = s.GetNextEntry()
            End While

            s.Close()
        Catch eu As Exception
            Throw eu
        Finally
            s.Close()
        End Try
    End Function
    Private Function SaveData(filePath) As String

        'Dim filePath As String = "E:\\data\\C314-OTA-test-10ID\\1ddd73b1ce66a374e005f834894ef2e7.conf"
        'If TextBox1.Text.Trim <> "" Then
        '    filePath = "E:\\data\\C314-OTA-test-10ID\\" & TextBox1.Text.Trim & ".conf"
        'End If

        If File.Exists(filePath) Then
            If Path.GetExtension(filePath) <> ".conf" Then
                Return "文件格式不正确格式必须为‘conf’"
            End If
            Dim FileName As String = filePath.Substring(filePath.LastIndexOf("\") + 1)
            FileName = FileName.Substring(0, FileName.LastIndexOf("."))
            If FileName.Length <> 32 Then
                Return "文件名格式不正确"
            End If
            Dim FsFile(0) As FileStream
            Dim Parmter As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}

            FsFile(0) = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim Data(FsFile(0).Length) As Byte
            FsFile(0).Read(Data, 0, Int(FsFile(0).Length))
            Dim picStr As String = Convert.ToBase64String(Data)
            Parmter(0) = New SqlClient.SqlParameter("@CID", Data)
            FsFile(0).Close()
            Try
                Dim sqlstr As System.Text.StringBuilder = New System.Text.StringBuilder
                sqlstr.Append(" declare @tm datetime ")
                sqlstr.Append(" select  @tm=Intime from MESDataCenter.dbo.m_HW_C314OTAUID_t where [FileName]='" & FileName & "'")
                sqlstr.Append("if @tm is null ")
                sqlstr.Append("begin ")
                sqlstr.Append(" select  @tm=Intime from MESDataCenter.dbo.m_HW_C314OTAUID_t where [UIDstring]='" & picStr & "'")
                sqlstr.Append("if @tm is null ")
                sqlstr.Append("begin ")
                sqlstr.Append(" INSERT INTO [MESDataCenter].[dbo].[m_HW_C314OTAUID_t](PartID,FileName,UIDstring,UID,Path,Intime,UserId,Usey) values(N'" & txtPartID.Text.Trim & "',N'" & FileName & "','" + picStr + "',@CID,N'" & filePath & "',getdate(),'" & VbCommClass.VbCommClass.UseId & "','N')")
                sqlstr.Append(" select result=1,message=N'成功'")
                sqlstr.Append("end ")
                sqlstr.Append("else ")
                sqlstr.Append("begin ")
                sqlstr.Append("select result=0,message=N'文件类容重码文件未重码新检查客户提供UID是否存在问题。该文件已上传，时间:'+CONVERT(varchar(100), @tm, 25)")
                sqlstr.Append("end ")
                sqlstr.Append("end ")
                sqlstr.Append("else ")
                sqlstr.Append("begin ")
                sqlstr.Append("select result=0,message=N'该文件已上传，时间:'+CONVERT(varchar(100), @tm, 25)")
                sqlstr.Append("end ")
                'Dim sql As String = " INSERT INTO [MESDataCenter].[dbo].[m_C314OTAID_t](PartID,FileName,UID,Path,Intime,UserId,Usey) values('" & txtPartID.Text.Trim & "','" & FileName & "',@CID,'" & filePath & "',getdate(),'" & VbCommClass.VbCommClass.UseId & "','N')"
                Dim dt As DataTable = conn.GetDataTable(sqlstr.ToString, Parmter)
                If dt.Rows(0)("result").ToString = "1" Then
                    Return ""
                Else
                    Return "失败：文件数据重复" + dt.Rows(0)("message").ToString
                End If
                'MessageBox.Show("成功")
            Catch ex As Exception
                Return "插入失败" + ex.ToString
                ' MessageBox.Show("失败" + ex.ToString)
            End Try
        Else
            Return "路径不存在" + filePath
        End If


    End Function

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me._IsRefresh = True
        Me.Close()
    End Sub

    Private Sub copy_Click(sender As Object, e As EventArgs) Handles copy.Click
        Clipboard.SetText(ListBox1.Items(ListBox1.SelectedIndex).ToString())
    End Sub

    Private Sub HW_UIDDataAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox2.DrawItem
        Dim vColor As Color = e.ForeColor
        Select Case e.Index
            Case 0
                vColor = Color.Red
            Case 1
                vColor = Color.Yellow
            Case 2
                vColor = Color.Blue
        End Select

    End Sub
End Class