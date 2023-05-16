Imports System.IO
Imports System.ComponentModel
Public Class HW_LicenseAdd
    Dim worker As BackgroundWorker = Nothing
    '是否刷新主界面
    Private _IsRefresh As Boolean = False
    Public ErrorCount As Integer = 0
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
    Private Sub USIDUse(ByVal Partid As String, ByVal qty As String)
        If qty <= 0 Then
            Return
        End If
        Dim sql As String = "SELECT COUNT(*)  FROM MESDataCenter.dbo.m_HW_C314LicenseUse WHERE PartID ='" + Partid + "'"
        Dim dat As DataTable = conn.GetDataTable(sql)
        If dat.Rows(0)(0).ToString() = "0" Then
            sql = "SELECT COUNT(*) FROM MESDataCenter.dbo.m_HW_C314OTALicense_t WHERE PartID ='" + Partid + "'"
            dat = conn.GetDataTable(sql)
            sql = "INSERT INTO MESDataCenter.dbo.m_HW_C314LicenseUse(Partid,Total,Alreadyused,Occupy,Tovoid,USID) VALUES ('" + Partid + "','" + dat.Rows(0)(0).ToString() + "','0','0','0','" + VbCommClass.VbCommClass.UseId + "')"
            dat = conn.GetDataTable(sql)
        Else
            sql = "UPDATE MESDataCenter.dbo.m_HW_C314LicenseUse SET Total= ((SELECT Total FROM MESDataCenter.dbo.m_HW_C314LicenseUse WHERE Partid='" + Partid + "')+" + qty + ") WHERE Partid='" + Partid + "'"
            dat = conn.GetDataTable(sql)
        End If
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
                    'ListBox1.Items.Add(Str(i).ToString())
                    SetItemValue("更新文件：" & FileList(i).ToString() + " 进行中......", ListBox1, i)
                    Dim Message As String = SaveData(FileList(i).ToString())
                    If (Message) <> "" Then
                        SetItemValue("文件：" & FileList(i).ToString() + " 上传失败" + Message, ListBox1, i)
                        NG = NG + 1
                        ErrorCount = ErrorCount + 1
                        obj.WriteLog("文件：" & FileList(i).ToString() + " 上传失败" + Message)
                        'SetText(i, lbmessage)
                    Else
                        SetItemValue("文件：" & FileList(i).ToString() + " 100%", ListBox1, i)
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
                    Threading.Thread.Sleep(1000)
                Next

                worker.ReportProgress(100)
                USIDUse(txtPartID.Text.Trim, OK.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("有异常发生：" + ex.Message.ToString + "退出文件上传")
            worker.ReportProgress(100)
        End Try


    End Sub

    Private Sub worker_ProgressChanged(ByVal sender As System.Object, ByVal e As ProgressChangedEventArgs)
        Try
            If Not e.UserState Is Nothing Then
                ' lblMsg.Text = CType(e.UserState, Exception).Message
            Else
                progressBar1.Value = e.ProgressPercentage
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


    Private Function SaveData(filePath) As String

        'Dim filePath As String = "E:\\data\\C314-OTA-test-10ID\\1ddd73b1ce66a374e005f834894ef2e7.conf"
        'If TextBox1.Text.Trim <> "" Then
        '    filePath = "E:\\data\\C314-OTA-test-10ID\\" & TextBox1.Text.Trim & ".conf"
        'End If
        If File.Exists(filePath) Then
            Dim FileName As String = filePath.Substring(filePath.LastIndexOf("\") + 1)
            FileName = FileName.Substring(0, FileName.LastIndexOf("."))
            Dim FsFile(0) As FileStream
            Dim Parmter As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}

            FsFile(0) = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim Datas(FsFile(0).Length) As Byte
            FsFile(0).Read(Datas, 0, Int(FsFile(0).Length))
            Dim Data As String = System.Text.Encoding.UTF8.GetString(Datas)
            Parmter(0) = New SqlClient.SqlParameter("@CID", Data)
            FsFile(0).Close()
            Try
                Dim sqlstr As System.Text.StringBuilder = New System.Text.StringBuilder
                sqlstr.Append(" declare @tm datetime ")
                sqlstr.Append(" select  @tm=Intime from MESDataCenter.dbo.m_HW_C314OTALicense_t where [FileName]='" & FileName & "'")
                sqlstr.Append("if @tm is null ")
                sqlstr.Append("begin ")
                sqlstr.Append(" INSERT INTO [MESDataCenter].[dbo].[m_HW_C314OTALicense_t](PartID,FileName,UID,Path,Intime,UserId,Usey) values(N'" & txtPartID.Text.Trim & "',N'" & FileName & "',@CID,N'" & filePath & "',getdate(),'" & VbCommClass.VbCommClass.UseId & "','N')")
                sqlstr.Append(" select result=1,message=N'成功'")
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

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If txtPartID.Text = "" Then
            MessageBox.Show("请先输入对应的料号")
            Return
            'txtPartID.Text = Now.ToString("yyyyMMddHHmm")
        End If
        ButtonX1.Enabled = False
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me._IsRefresh = True
        Me.Close()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk

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
End Class