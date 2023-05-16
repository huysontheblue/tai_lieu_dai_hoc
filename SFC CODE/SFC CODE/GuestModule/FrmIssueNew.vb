Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO

Public Class FrmIssueNew
    Dim strAllFactory As String
    Dim strAllType As String
    Dim strFilePath As String
    Dim blnSendEmail As Boolean
    Dim strEmailAddressee As String
    Dim strEmailCC As String
    Dim intFileMaxSize As Integer

    Private Sub FrmIssueNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not LoadXMLSetting() Then Exit Sub
        SysMessageClass.UseName = GetUserName(SysMessageClass.UseId)
        BindComboBox(" - ," & strAllFactory, CobFactory)
        BindComboBox(" - ," & strAllType, CobType)
        InitialUI()
    End Sub

    Private _FileName As String
    Public Property FileName() As String
        Get
            Return _FileName
        End Get

        Set(ByVal Value As String)
            _FileName = Value
        End Set
    End Property

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim strLocalFilePath As String = txtFile.Text.Trim
        Dim strFactory As String = String.Empty
        Dim strType As String = String.Empty
        Dim strMsg As String
        Dim dtItems As New DataTable
        Dim strServerFilePath As String=""
        Dim strItems As String
        Dim strBody As String = String.Empty
        Dim strTel As String = TxtTel.Text.Trim
        Dim strEmail As String = TxtEmail.Text.Trim
        Dim strIssue As String = TxtIssue.Text.Trim
        Dim strIssueDes As String = TxtIssueDes.Text.Trim
        Dim strStationName As String = String.Empty
        Dim strPCInfo As String = String.Empty
        Try
            strMsg = CheckValue()
            If Not strMsg.Equals(String.Empty) Then
                MessageBox.Show(strMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            strFactory = CobFactory.SelectedItem("Text").ToString
            strType = CobType.SelectedItem("Text").ToString

            If Not (String.IsNullOrEmpty(Me.FileName) OrElse String.IsNullOrEmpty(strLocalFilePath)) Then
                Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(strLocalFilePath)
                If FileInfo.Length > intFileMaxSize * 1024 * 1024 Then
                    MessageBox.Show("附件不能大于" & intFileMaxSize & "MB！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                strServerFilePath = Path.Combine(strFilePath & CobFactory.SelectedItem("Value").ToString.Trim & "\" & CobType.SelectedItem("Value").ToString.Trim & "\", Now.ToString("yyyyMM"))
                If System.IO.Directory.Exists(strServerFilePath) = False Then
                    Directory.CreateDirectory(strServerFilePath)
                End If
                strServerFilePath = Path.Combine(strServerFilePath, Me.FileName)
                File.Copy(strLocalFilePath, strServerFilePath, True)
            End If

            strPCInfo = GetLocalPCInfo()
            strSql = "INSERT INTO m_IssueRecord_t(Items,Factory,Type,Issue,IssueDetail,FilePath,ContactUser,ContactTel,ContactEmail,CreateUser,CreateDate,Status,PCInfo)" _
            & " OUTPUT INSERTED.Items" _
            & " SELECT CONVERT(INT,RIGHT(CONVERT(VARCHAR , GETDATE(), 112 ),6)+ CONVERT(VARCHAR,RIGHT(ISNULL(MAX(Items),'1000')+1,3)))," _
            & "N'" & CobFactory.SelectedItem("Value").ToString & "',N'" & CobType.SelectedItem("Value").ToString & "',N'" & strIssue & "',N'" & strIssueDes & "',N'" & strServerFilePath & "',N'" _
            & SysMessageClass.UseName & "','" & strTel & "','" & strEmail & "',N'" & SysMessageClass.UseName & "',GETDATE(),'0',N'" & strPCInfo & "'" _
            & " FROM m_IssueRecord_t WHERE LEFT(Items,6) = RIGHT(CONVERT(VARCHAR , GETDATE(), 112 ),6)"

            dtItems = Sdbc.GetDataTable(strSql)
            strItems = dtItems.Rows(0)(0).ToString
            MessageBox.Show("新建问题成功！问题编号: " & strItems & "。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If blnSendEmail Then
                strBody = "<font>联系人: " & SysMessageClass.UseName & "</font><br/><font>联系电话: " & strTel & "</font><br/><font>邮件地址: " & strEmail _
                & "</font><br/><br/><font>咨询编号: " & strItems & "</font><br/><font>咨询PC: " & strPCInfo & "</font><br/><font>问题摘要: " & strIssue & "</font><br/><font>问题描述: " & strIssueDes & "</font>"
                strSql = " EXECUTE [m_MailSend_p] N'帮助中心新问题(" & strFactory & "-" & strType & ")',N'" & strBody & "','" & strEmailAddressee.Replace("，", ",") _
                & "','" & strEmailCC.Replace("，", ",") & "','','ict-luxshare','sfc@it.luxshare-ict.com','sfc'"
                dtItems.Clear()
                dtItems = Sdbc.GetDataTable(strSql)
            End If

            InitialUI(True)
            txtItems.Text = strItems
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc = Nothing
            dtItems.Clear()
            dtItems.Dispose()
        End Try
    End Sub

    Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        InitialUI()
    End Sub

    Private Sub BtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Function LoadXMLSetting() As Boolean
        Dim xmldoc As New XmlDocument
        Try
            LoadXMLSetting = False
            xmldoc.Load(Application.StartupPath & "\Loginlog.xml")
            For Each xn As XmlNode In xmldoc.SelectSingleNode("filelist").ChildNodes
                If LCase(xn.Name) = "helpcenter" Then
                    For Each xe As XmlElement In xn
                        If LCase(xe.Name) = "factory" Then
                            strAllFactory = xe.InnerText.Replace("，", ",")
                        ElseIf LCase(xe.Name) = "type" Then
                            strAllType = xe.InnerText.Replace("，", ",")
                        ElseIf LCase(xe.Name) = "filepath" Then
                            strFilePath = xe.InnerText
                        ElseIf LCase(xe.Name) = "sendemail" Then
                            blnSendEmail = IIf(xe.InnerText.ToUpper.Trim = "Y", True, False)
                        ElseIf LCase(xe.Name) = "emailaddressee" Then
                            strEmailAddressee = xe.InnerText.Replace("，", ",")
                        ElseIf LCase(xe.Name) = "emailcc" Then
                            strEmailCC = xe.InnerText.Replace("，", ",")
                        ElseIf LCase(xe.Name) = "filemaxsize_mb" Then
                            intFileMaxSize = CInt(xe.InnerText.Trim)
                        End If
                    Next
                End If
            Next
            LoadXMLSetting = True
        Catch ex As Exception
            MessageBox.Show("不存在Loginlog.xml文件", "提示信息", MessageBoxButtons.OK)
            Exit Function
        Finally
            xmldoc = Nothing
        End Try
    End Function

    Private Function CheckValue() As String
        CheckValue = String.Empty
        If TxtContactUser.Text.Trim.Equals(String.Empty) OrElse TxtTel.Text.Trim.Equals(String.Empty) OrElse TxtEmail.Text.Trim.Equals(String.Empty) Then
            CheckValue = "联系资料不全！"
        ElseIf CobFactory.SelectedIndex <= 0 Then
            CheckValue = "厂区必须选择！"
        ElseIf CobType.SelectedIndex <= 0 Then
            CheckValue = "类别必须选择！"
        ElseIf TxtIssue.Text.Trim.Equals(String.Empty) Then
            CheckValue = "问题简述不能为空！"
        ElseIf TxtIssueDes.Text.Trim.Equals(String.Empty) Then
            CheckValue = "问题描述不能为空！"
        End If
    End Function

    Private Sub InitialUI(Optional ByVal blnLock = False)
        TxtContactUser.Text = SysMessageClass.UseName
        TxtTel.ReadOnly = blnLock
        TxtEmail.ReadOnly = blnLock
        CobFactory.Enabled = Not blnLock
        CobType.Enabled = Not blnLock
        TxtIssue.ReadOnly = blnLock
        TxtIssueDes.ReadOnly = blnLock
        BtnOpenFile.Enabled = Not blnLock
        BtnSave.Enabled = Not blnLock
        If Not blnLock Then
            txtItems.Text = Now.ToString("yyMMdd") & "---"
            TxtTel.Text = ""
            TxtEmail.Text = ""
            CobFactory.SelectedIndex = 0
            CobType.SelectedIndex = 0
            TxtIssue.Text = ""
            TxtIssueDes.Text = ""
            txtFile.Text = ""
            TxtTel.SelectAll()
        Else
            txtItems.SelectAll()
        End If
    End Sub

    Private Sub BtnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenFile.Click
        BtnOpenFile.Enabled = False
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFile.Text = OpenFileDialog1.FileName
            FileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        BtnOpenFile.Enabled = True
    End Sub

    Private Sub TxtContactUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtContactUser.KeyDown, TxtTel.KeyDown, _
    TxtEmail.KeyDown, CobFactory.KeyDown, CobType.KeyDown, TxtIssue.KeyDown, txtFile.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class