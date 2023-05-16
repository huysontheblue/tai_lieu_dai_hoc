Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Xml

Public Class FrmIssueTrace
    Dim strAllFactory As String
    Dim strAllType As String

    Private Enum EnumIssue
        Items = 0
        Factory
        Type
        Issue
        Status
        CreateDate
        ContactUser
        ContactTel
        ContactEmail
    End Enum

    Private Sub FrmIssueTrace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadXMLSetting()
        SysMessageClass.UseName = GetUserName(SysMessageClass.UseId)
        TxtContactUser.Text = SysMessageClass.UseName
        CobStatus.SelectedIndex = 0
        TxtItems.Focus()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim dtIssue As New DataTable
        Dim strItems As String = TxtItems.Text.Trim
        Dim strContactUser As String = TxtContactUser.Text.Trim
        Dim strEmail As String = TxtEmail.Text.Trim
        Dim strStatus As String = CobStatus.SelectedItem.ToString.Substring(0, 1).ToUpper
        Try
            If strItems.Equals(String.Empty) AndAlso strContactUser.Equals(String.Empty) AndAlso strEmail.Equals(String.Empty) Then
                MessageBox.Show("请输入更详细的查询条件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            strSql = "SELECT Items," & DecodeCaseSQL("Factory", strAllFactory) & "," & DecodeCaseSQL("Type", strAllType) & ",Issue," _
            & DecodeCaseSQL("Status", "0-0.新开立,1-1.进行中,2-2.完成") & "," & "CreateDate,ContactUser,ContactTel,ContactEmail" _
            & " FROM m_IssueRecord_t WHERE 1=1" _
            & IIf(strItems.Equals(""), "", " AND Items='" & strItems & "'") _
            & IIf(strContactUser.Equals(""), "", " AND ContactUser LIKE N'%" & strContactUser & "%'") _
            & IIf(strEmail.Equals(""), "", " AND ContactEmail LIKE N'%" & strEmail & "%'") _
            & IIf(strStatus.Equals("A"), "", " AND Status='" & strStatus & "'")

            dtIssue = Sdbc.GetDataTable(strSql)
            DgvIssue.DataSource = dtIssue
            DgvIssue.Refresh()
            ToolStripStatusLabel1.Text = dtIssue.Rows.Count & "笔"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc.PubConnection.Close()
            Sdbc = Nothing
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub DgvIssue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvIssue.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        With DgvIssue.Rows(e.RowIndex)
            ShowDetail(.Cells(EnumIssue.Items).Value.ToString(), .Cells(EnumIssue.Status).Value.ToString(), .Cells(EnumIssue.Type).Value.ToString())
        End With
    End Sub

    Private Sub ShowDetail(ByVal lstrItems As String, ByVal lstrStatus As String, ByVal lstrType As String)
        Dim FrmIssueDetail As New FrmIssueDetail
        With FrmIssueDetail
            .strItems = lstrItems
            .strStatus = lstrStatus
            .strType = lstrType
            .strAllType = strAllType
            .strAllFactory = strAllFactory
            .dType = FrmIssueDetail.DetailType.Trace
            .TabTitle = "问题处理进度详情"
            .ShowDialog()
        End With
    End Sub

    Private Sub TxtItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtItems.KeyDown, TxtContactUser.KeyDown, TxtEmail.KeyDown, _
    CobStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
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

End Class