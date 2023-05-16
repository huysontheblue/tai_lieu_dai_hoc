Imports System.Xml

Public Class FrmIssueSolve
    Dim strAllFactory As String
    Dim strAllType As String

    Private Enum EnumIssue
        Items = 0
        Factory
        Type
        Issue
        Status
        SolveUser
        SolveDate
        CloseDate
        CreateDate
        ContactUser
        ContactTel
        ContactEmail
    End Enum

    Private Sub FrmIssueSolve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now.AddDays(-7).ToString("yyyy-MM-dd")
        DtEnd.Value = Now.ToString("yyyy-MM-dd")
        If Not LoadXMLSetting() Then Exit Sub
        BindComboBox("All-All," & strAllFactory, CobFactory)
        CobFactory.SelectedIndex = 0
        BindComboBox("All-All," & strAllType, CobType)
        CobType.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim strStartDate As String
        Dim strEndDate As String
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim strStatus As String = String.Empty
        Dim dtIssue As New DataTable
        Dim strMsg As String
        Try
            strMsg = CheckValue()
            If Not strMsg = String.Empty Then
                MessageBox.Show(strMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            strStartDate = DtStar.Value.ToString("yyyy/MM/dd") & " 00:00:00"
            strEndDate = DtEnd.Value.ToString("yyyy/MM/dd") & " 23:59:59"
            If ChkNew.Checked Then strStatus &= ",0"
            If ChkOnGoing.Checked Then strStatus &= ",1"
            If ChkClose.Checked Then strStatus &= ",2"

            strSql = "SELECT Items," & DecodeCaseSQL("Factory", strAllFactory) & "," & DecodeCaseSQL("Type", strAllType) & ",Issue," _
            & DecodeCaseSQL("Status", "0-0.新开立,1-1.进行中,2-2.完成") & "," _
            & "SolveUser,convert(varchar,SolveDate,120) SolveDate,convert(varchar,ClosedDate,120) CloseDate," _
            & "convert(varchar,CreateDate,120) CreateDate,ContactUser,ContactTel,ContactEmail" _
            & " FROM m_IssueRecord_t WHERE Status IN('" & strStatus.Substring(1).Replace(",", "','") & "')" _
            & IIf(CobFactory.SelectedItem("Value").ToString = "All", "", " AND Factory=N'" & CobFactory.SelectedItem("Value").ToString & "'") _
            & IIf(CobType.SelectedItem("Value").ToString = "All", "", " AND Type=N'" & CobType.SelectedItem("Value").ToString & "'") _
            & IIf(TxtItems.Text.Trim.Equals(String.Empty), "", " AND Items='" & TxtItems.Text.Trim & "'") _
            & IIf(TxtContactUser.Text.Trim.Equals(String.Empty), "", " AND ContactUser LIKE N'%" & TxtContactUser.Text.Trim.Replace("，", ",").ToUpper & "%'") _
            & IIf(TxtSolveUser.Text.Trim.Equals(String.Empty), "", " AND SolveUser LIKE N'%" & TxtSolveUser.Text.Trim.Replace("，", ",").ToUpper & "%'") _
            & IIf(TxtIssue.Text.Trim.Equals(String.Empty), "", " AND Issue LIKE N'%" & TxtIssue.Text.Trim & "%'") _
            & IIf(DtStar.Text.Trim.Equals(String.Empty), "", " AND CreateDate >='" & strStartDate & "'") _
            & IIf(DtEnd.Text.Trim.Equals(String.Empty), "", " AND CreateDate <='" & strEndDate & "'")

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

    Private Sub DgvIssue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvIssue.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        With DgvIssue.Rows(e.RowIndex)
            ShowDetail(.Cells(EnumIssue.Items).Value.ToString(), .Cells(EnumIssue.Status).Value.ToString(), .Cells(EnumIssue.Type).Value.ToString())
            btnSearch_Click(sender, e)
        End With
    End Sub

    Private Sub btnSolve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolve.Click
        If DgvIssue.RowCount < 1 Then Exit Sub
        With DgvIssue.CurrentRow
            If .Index = -1 Then Exit Sub
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
            .dType = IIf(lstrStatus.StartsWith("2"), FrmIssueDetail.DetailType.Trace, FrmIssueDetail.DetailType.Solve)
            .TabTitle = IIf(lstrStatus.StartsWith("2"), "问题详情", "问题处理")
            .ShowDialog()
        End With
    End Sub

    Private Function CheckValue() As String
        CheckValue = String.Empty
        If Not (ChkNew.Checked OrElse ChkOnGoing.Checked OrElse ChkClose.Checked) Then
            CheckValue = "请先选择问题状态！"
        ElseIf Not (DtStar.Value.ToString.Trim.Equals(String.Empty) OrElse DtEnd.Value.ToString.Trim.Equals(String.Empty)) Then
            If DtStar.Value > DtEnd.Value Then
                CheckValue = "起始时间不能大于结束时间！"
            End If
        End If
    End Function

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

    Private Sub CobFactory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CobFactory.KeyDown, CobType.KeyDown, ChkClose.KeyDown, _
    ChkNew.KeyDown, ChkOnGoing.KeyDown, TxtContactUser.KeyDown, TxtIssue.KeyDown, TxtItems.KeyDown, TxtSolveUser.KeyDown, DtEnd.KeyDown, DtStar.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class