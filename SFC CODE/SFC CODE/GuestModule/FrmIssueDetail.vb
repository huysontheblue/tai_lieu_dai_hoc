Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports Owc = Microsoft.Office.Interop.Excel
Imports System.Xml
Imports System.Net
Imports Microsoft.Office.Interop
Imports System.IO
Imports MainFrame.SysCheckData


Public Class FrmIssueDetail
    Public strItems As String
    Public TabTitle As String
    Public dType As DetailType = DetailType.Solve
    Public strStatus As String = "0"
    Public strType As String = String.Empty
    Public strAllType As String = String.Empty
    Public strAllFactory As String = String.Empty
    Private strFilePath As String

    Public Enum DetailType
        Trace = 0
        Solve
    End Enum

    Private Sub FrmIssueDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SysMessageClass.UseName = GetUserName(SysMessageClass.UseId)
        BindComboBox(strAllType, CobType)
        ShowDetailData()
        InitialUI()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim dt As New DataTable
        Try
            strMsg = CheckValue()
            If Not strMsg = String.Empty Then
                MessageBox.Show(strMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If rbClose.Checked Then
                strStatus = "2.完成"
                txtStatus.Text = "2.完成"
                dType = DetailType.Trace
            Else
                strStatus = "1.进行中"
                txtStatus.Text = "1.进行中"
            End If
            strType = CobType.SelectedItem("Value").ToString

            strSql = "UPDATE m_IssueRecord_t SET Type=N'" & strType & "',Status='" & strStatus.Substring(0, 1) & "',CheckSteps=N'" & TxtCheckSteps.Text.Trim & "'," _
            & "Reason=N'" & TxtReason.Text.Trim & "',Solution=N'" & TxtSolution.Text.Trim & "',AnalyImprove=N'" & TxtAnalyImprove.Text.Trim & "'," _
            & "SolveUser=N'" & TxtSolveUser.Text.Trim.Replace("，", ",").ToUpper & "',SolveDate=GETDATE()" & IIf(rbClose.Checked, ",ClosedDate=GETDATE()", "") _
            & " OUTPUT INSERTED.SolveDate WHERE Items='" & strItems & "'"

            dt = Sdbc.GetDataTable(strSql)
            txtSolveDate.Text = dt.Rows(0)(0).ToString
            InitialUI()
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc = Nothing
            dt.Dispose()
        End Try
    End Sub

    Private Sub LnkFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFile.LinkClicked
        Dim strFileName As String = LnkFile.Text
        Dim strFileType As String
        Try
            If Not strFilePath.Equals(String.Empty) Then
                With SaveFileDialog1
                    .FileName = LnkFile.Text
                    strFileType = Strings.Right(strFileName, strFileName.Length - strFileName.LastIndexOf(".") - 1)
                    .Filter = "(*." & strFileType & ")|*." & strFileType & "|" + "(*.*)|*.*"
                    .RestoreDirectory = True
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        My.Computer.Network.DownloadFile(New Uri(strFilePath), .FileName, "", "", False, 200000, True)
                        MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim app As Excel.Application = Nothing
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim strFiled As String = String.Empty
        Dim bln As Boolean = False
        Try
            BtnExcel.Enabled = False : BtnExit.Enabled = False : BtnSave.Enabled = False
            app = New Excel.Application
            app.Visible = False : app.DisplayAlerts = False
            workbook = app.Workbooks.Open(Application.StartupPath & "\Temple_IssueDetail.xlsx")
            worksheet = workbook.Sheets(1)

            For i As Integer = 1 To workbook.Sheets.Count
                If workbook.Sheets(i).Name.Equals("Detail") Then
                    worksheet = workbook.Sheets(i)
                    bln = True
                    Exit For
                End If
            Next

            If bln = False Then
                MsgBox("打印模板没有找到！")
            Else
                worksheet.Select()
                With (worksheet)
                    .Cells(1, 2) = Me.TxtItems.Text.Trim
                    .Cells(1, 5) = Me.txtStatus.Text.Trim
                    .Cells(1, 8) = Me.TxtCreateDate.Text.Trim
                    .Cells(4, 2) = Me.TxtContactUser.Text.Trim
                    .Cells(4, 5) = Me.TxtTel.Text.Trim
                    .Cells(4, 8) = Me.TxtEmail.Text.Trim
                    .Cells(5, 2) = Me.TxtFactory.Text.Trim
                    .Cells(5, 5) = Me.CobType.SelectedItem("Text").ToString
                    .Cells(5, 8) = Me.TxtPCInfo.Text.Trim
                    .Cells(6, 2) = Me.TxtIssue.Text.Trim
                    .Cells(7, 2) = Me.TxtIssueDes.Text.Trim
                    .Cells(13, 2) = Me.TxtSolveUser.Text.Trim
                    .Cells(13, 8) = Me.txtSolveDate.Text.Trim
                    .Cells(14, 2) = Me.TxtCheckSteps.Text.Trim
                    .Cells(17, 2) = Me.TxtReason.Text.Trim
                    .Cells(20, 2) = Me.TxtSolution.Text.Trim
                    .Cells(24, 2) = Me.TxtAnalyImprove.Text.Trim
                End With
                If Not Directory.Exists("c:\MesExport") Then
                    Directory.CreateDirectory("c:\MesExport")
                End If
                workbook.SaveAs("c:\MesExport\" & Me.Text & "_" & Me.TxtItems.Text.Trim & ".xlsx")
            End If

            workbook.Close()
            MessageBox.Show("导出 c:\MesExport\" & Me.Text & "_" & Me.TxtItems.Text.Trim & ".xlsx 成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            If Not app Is Nothing Then
                app.Quit()
                app = Nothing
            End If
            BtnExcel.Enabled = True : BtnExit.Enabled = True : BtnSave.Enabled = True
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Close()
    End Sub

    Private Sub TxtItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtItems.KeyDown, txtStatus.KeyDown, TxtCreateDate.KeyDown, _
        TxtContactUser.KeyDown, TxtTel.KeyDown, TxtEmail.KeyDown, TxtFactory.KeyDown, CobType.KeyDown, TxtIssue.KeyDown, TxtIssueDes.KeyDown, TxtSolveUser.KeyDown, _
        rbClose.KeyDown, rbOnGoing.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub InitialUI()
        Me.Text = TabTitle
        If strStatus.StartsWith("2") Then
            rbClose.Checked = True
        ElseIf strStatus.StartsWith("1") Then
            rbOnGoing.Checked = True
        Else
            rbClose.Checked = False
            rbOnGoing.Checked = False
        End If
        TxtItems.Text = strItems
        txtStatus.Text = strStatus.ToString
        lblSolveDate.Visible = True
        txtSolveDate.Visible = True
        CobType.Enabled = False
        Select Case dType
            Case DetailType.Trace
                BtnSave.Visible = False
                TxtSolveUser.ReadOnly = True
                TxtCheckSteps.ReadOnly = True
                TxtReason.ReadOnly = True
                TxtAnalyImprove.ReadOnly = True
                TxtSolution.ReadOnly = True
                rbClose.Enabled = False
                rbOnGoing.Enabled = False
                TxtItems.Focus()
            Case DetailType.Solve
                BtnSave.Visible = True
                If Not strStatus.StartsWith("2") Then
                    CobType.Enabled = True
                    If Not strStatus.StartsWith("1") Then
                        TxtSolveUser.Text = SysMessageClass.UseName
                        lblSolveDate.Visible = False
                        txtSolveDate.Visible = False
                    End If
                End If
                TxtSolveUser.ReadOnly = False
                TxtCheckSteps.ReadOnly = False
                TxtReason.ReadOnly = False
                TxtAnalyImprove.ReadOnly = False
                TxtSolution.ReadOnly = False
                rbClose.Enabled = True
                rbOnGoing.Enabled = True
                TxtSolveUser.Focus()
        End Select
        CobType.SelectedIndex = strAllType.Substring(0, strAllType.IndexOf(strType)).Split(",").Length - 1
    End Sub

    Private Sub ShowDetailData()
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtIssue As DataTable = Nothing
        Dim strSql As String = String.Empty
        Try
            strSql = "SELECT " & DecodeCaseSQL("Factory", strAllFactory) & ",Issue,IssueDetail,FilePath,ContactUser,ContactTel,ContactEmail,convert(varchar,CreateDate,120) CreateDate," _
            & "(CASE WHEN Status='0' THEN N'0.新开立' WHEN Status='1' THEN N'1.进行中'  ELSE  N'2.完成' END) Status,PCInfo," _
            & "CheckSteps,Reason,Solution,AnalyImprove,SolveUser,convert(varchar,SolveDate,120) SolveDate" _
            & " FROM m_IssueRecord_t WHERE Items='" & strItems & "'"

            dtIssue = Sdbc.GetDataTable(strSql)
            With dtIssue.Rows(0)
                TxtFactory.Text = .Item("Factory").ToString
                TxtIssue.Text = .Item("Issue").ToString
                TxtIssueDes.Text = .Item("IssueDetail").ToString
                strFilePath = .Item("FilePath").ToString
                LnkFile.Text = Strings.Right(strFilePath, strFilePath.Length - strFilePath.LastIndexOf("\") - 1)
                TxtContactUser.Text = .Item("ContactUser").ToString
                TxtTel.Text = .Item("ContactTel").ToString
                TxtEmail.Text = .Item("ContactEmail").ToString
                TxtPCInfo.Text = .Item("PCInfo").ToString
                TxtCreateDate.Text = .Item("CreateDate").ToString
                TxtCheckSteps.Text = .Item("CheckSteps").ToString
                TxtReason.Text = .Item("Reason").ToString
                TxtSolution.Text = .Item("Solution").ToString
                TxtAnalyImprove.Text = .Item("AnalyImprove").ToString
                TxtSolveUser.Text = .Item("SolveUser").ToString
                txtSolveDate.Text = .Item("SolveDate").ToString
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc.PubConnection.Close()
            Sdbc = Nothing
            dtIssue.Dispose()
        End Try
    End Sub

    Private Function CheckValue() As String
        CheckValue = String.Empty
        If TxtSolveUser.Text.Trim.Equals(String.Empty) Then
            CheckValue = "负责人不能为空！"
        ElseIf TxtCheckSteps.Text.Trim.Equals(String.Empty) Then
            CheckValue = "检查步骤不能为空！"
        ElseIf rbClose.Checked = False AndAlso rbOnGoing.Checked = False Then
            CheckValue = "请选择处理进度！"
        End If
        If rbClose.Checked Then
            If TxtReason.Text.Trim.Equals(String.Empty) Then
                CheckValue = "原因不能为空！"
            ElseIf TxtSolution.Text.Trim.Equals(String.Empty) Then
                CheckValue = "解决方法不能为空！"
                'ElseIf TxtAnalyImprove.Text.Trim.Equals(String.Empty) Then
                '    CheckValue = "分析与改善不能为空！"
            End If
        End If
    End Function

    Private Sub TxtCheckSteps_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCheckSteps.KeyDown, TxtReason.KeyDown, TxtSolution.KeyDown, _
        TxtAnalyImprove.KeyDown
        If dType = DetailType.Trace AndAlso e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class