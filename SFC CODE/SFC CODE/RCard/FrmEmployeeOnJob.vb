Imports System.Net.Mail
Imports MainFrame
Imports DBUtility

Public Class FrmEmployeeOnJob

    ''' <summary>
    ''' 料号
    ''' </summary>
    ''' <remarks></remarks>
    Public _PartID As String
    Public _BOFVersion As String
    Public _BOFFile As String

    Private dtSelect As DataTable

    Private Sub FrmEmployeeOnJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtSelect = New DataTable()
        dtSelect.Columns.Add(New DataColumn("CompanyName"))
        dtSelect.Columns.Add(New DataColumn("DeptName"))
        dtSelect.Columns.Add(New DataColumn("EmpCode"))
        dtSelect.Columns.Add(New DataColumn("EmpName"))
        dtSelect.Columns.Add(New DataColumn("Email"))
    End Sub

    Private Sub DataLoad()
        Dim where = " and 1=1 "
        If String.IsNullOrEmpty(txtEmpNo.Text.Trim()) = False Then
            where += " and EmpCode='" & txtEmpNo.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtEmpName.Text.Trim()) = False Then
            where += " and EmpName like N'%" & txtEmpName.Text.Trim() & "%'"
        End If
        Dim sql = "select top 5 * from m_employeeonjob_t " & vbCrLf &
        "where CompanyCode='LXXT'  and Email is not null " + where
        dgvData.AutoGenerateColumns = False
        Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
        dgvData.DataSource = dt
    End Sub


    Private Sub BtnTuiSong_Click(sender As Object, e As EventArgs) Handles BtnTuiSong.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dgvr As DataGridViewRow = dgvData.CurrentRow
            If dgvSelect.Rows.Count > 0 Then
                Dim FilePath = Application.StartupPath + "\" + Replace(_PartID, "/", "_") & "-" & "治具BOF清单.xls"
                Dim frm = New FrmBOFToolList()
                frm.CreateXls(FilePath, _PartID, _BOFVersion)

                FilePath = FilePath + ";" + _BOFFile

                SendEmailAndAttachment(FilePath, _PartID)
                If System.IO.File.Exists(FilePath) Then
                    System.IO.File.Delete(FilePath)
                End If
                MainFrame.SysCheckData.MessageUtils.ShowInformation("邮件推送成功!")
                Me.Close()
            Else
                MainFrame.SysCheckData.MessageUtils.ShowError("请选择要推送的用户")
            End If
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError("推送失败:" & vbCrLf & "" + ex.Message + "'" & _PartID & "'")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub

#Region "主档治具进度完成,生成Excel文档邮件通知FE负责人"
    ''' <summary>
    ''' 主档治具进度完成,生成Excel文档邮件通知FE负责人
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SendEmailAndAttachment(ByVal FileName As String, ByVal partid As String)
        Try

            Dim dt = DbOperateUtils.GetDataTable("select * from m_BOFToolList_t where PartID='" & partid & "'")

            Dim FEDutyEmail = dt.Rows(0)("FEDutyEmail").ToString()
            Dim MailBody = "<p>尊敬的MES用户</p> 料号:" & partid & "已经生成BOF治具清单列表,详情请看邮件附档"
            MailBody += "<p>治具入库,请及时核对BOF治具数量,有问题及时反馈!</p><br/>"
            Dim sc = New SmtpClient()
            sc.EnableSsl = False
            sc.Credentials = New System.Net.NetworkCredential("sfc@it.luxshare-ict.com", "Share888")
            sc.Host = "192.168.20.40"
            sc.Port = 25
            Dim mm = New MailMessage()
            mm.From = New MailAddress("sfc@it.luxshare-ict.com")
            mm.Priority = MailPriority.High
            mm.Subject = "料号:" & partid & ",BOF治具清单治具进度完成,FE负责人和生技负责人推送通知"
            mm.Body = MailBody
            mm.IsBodyHtml = True
            mm.BodyEncoding = System.Text.Encoding.UTF8

            Dim MailToStr = FEDutyEmail.Split(";")
            For Each item As String In MailToStr
                mm.To.Add(item)
            Next

            'mm.To.Add(FEDutyEmail)
            For Each dgvr As DataGridViewRow In dgvSelect.Rows
                mm.To.Add(dgvr.Cells("Email1").Value.ToString())
            Next
            mm.CC.Add("Jun.Deng@luxshare-ict.com")
            mm.CC.Add("Chenqi.Chen@luxshare-ict.com")
            mm.CC.Add(dt.Rows(0)("PIEMail").ToString())
            mm.Headers.Add("X-Priority", "3")
            mm.Headers.Add("X-MSMail-Priority", "Normal")
            mm.Headers.Add("X-Mailer", "Microsoft Outlook Express 6.00.2900.2869")
            mm.Headers.Add("X-MimeOLE", "Produced By Microsoft MimeOLE V6.00.2900.2869")
            mm.Headers.Add("ReturnReceipt", "1")


            ' mm.Attachments.Add(New Attachment(FileName))
            '1.txt;2.txt
            For Each o_tempFile As String In FileName.Split(";")
                If Not String.IsNullOrEmpty(o_tempFile) Then
                    mm.Attachments.Add(New Attachment(o_tempFile))
                End If
            Next

            sc.Send(mm)
            mm.Dispose()
        Catch ex As Exception
            Dim MainCC = "Chenqi.Chen@luxshare-ict.com;"
            Dim EmailTitle = "BOF治具清单治具进度完成-推送通知"
            MainFrame.MailUtils.SeedMail(MainCC, EmailTitle, partid + ex.Message)
        End Try
    End Sub
#End Region

    Private Sub dgvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellClick
        If dgvData.Columns(e.ColumnIndex).Name = "Chk" Then
            Dim CompanyName = dgvData.Rows(e.RowIndex).Cells("CompanyName").Value
            Dim DeptName = dgvData.Rows(e.RowIndex).Cells("DeptName").Value
            Dim EmpCode = dgvData.Rows(e.RowIndex).Cells("EmpCode").Value
            Dim EmpName = dgvData.Rows(e.RowIndex).Cells("EmpName").Value
            Dim Email = dgvData.Rows(e.RowIndex).Cells("Email").Value
            If dtSelect.Rows.Count > 0 Then
                If dtSelect.Select("EmpCode='" & EmpCode & "'").Length > 0 Then
                    MainFrame.SysCheckData.MessageUtils.ShowError("已经选择了该用户：" & EmpName & ",不可重复选择")
                    Exit Sub
                End If
            End If
            Dim dr As DataRow = dtSelect.NewRow()
            dr("CompanyName") = CompanyName
            dr("DeptName") = DeptName
            dr("EmpCode") = EmpCode
            dr("EmpName") = EmpName
            dr("Email") = Email
            dtSelect.Rows.Add(dr)
            dgvSelect.AutoGenerateColumns = False
            dgvSelect.DataSource = dtSelect
        End If
    End Sub


    Private Sub dgvSelect_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelect.CellClick
        If dgvSelect.Columns(e.ColumnIndex).Name = "ColRemove" Then
            If dtSelect.Rows.Count > 0 Then
                dtSelect.Rows.RemoveAt(e.RowIndex)
                dgvSelect.AutoGenerateColumns = False
                dgvSelect.DataSource = dtSelect
            End If
        End If
    End Sub
End Class