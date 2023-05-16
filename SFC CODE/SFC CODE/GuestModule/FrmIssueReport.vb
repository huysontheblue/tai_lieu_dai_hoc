Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO

Public Class FrmIssueReport
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
    End Enum

    Private Sub FrmIssueReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not LoadXMLSetting() Then Exit Sub
        DtCreateStar.Value = Now.AddDays(-7).ToString("yyyy-MM-dd")
        DtCreateEnd.Value = Now.ToString("yyyy-MM-dd")
        DtSolveStart.Value = Now.AddDays(-7).ToString("yyyy-MM-dd")
        DtSolveStart.Checked = False
        DtSolveEnd.Value = Now.ToString("yyyy-MM-dd")
        DtSolveEnd.Checked = False
        BindComboBox("All-All," & strAllFactory, CobFactory)
        CobFactory.SelectedIndex = 0
        BindComboBox("All-All," & strAllType, CobType)
        CobType.SelectedIndex = 0
        BindComboBox("All-All,0-0.新开立,1-1.进行中,2-2.完成", CobStatus)
        CobStatus.SelectedIndex = 0
        CobFactory.Focus()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim dtIssue As DataTable
        Dim strColumnName() As String = "咨询编号,厂区,类别,问题摘要,状态,负责人,最后处理时间,完成时间,咨询时间,联系人".Split(",")
        Try
            If Not CheckDateValue() Then Exit Sub

            strSql = "SELECT Items," & DecodeCaseSQL("Factory", strAllFactory) & "," & DecodeCaseSQL("Type", strAllType) & ",REPLACE(REPLACE(Issue,char(13),''),char(10),'') Issue," _
            & DecodeCaseSQL("Status", "0-0.新开立,1-1.进行中,2-2.完成") & ",SolveUser," _
            & "convert(varchar,SolveDate,120) SolveDate,convert(varchar,ClosedDate,120) CloseDate,convert(varchar,CreateDate,120) CreateDate,ContactUser" _
            & " FROM m_IssueRecord_t WHERE 1=1" & GetWhereSql()

            dtIssue = Sdbc.GetDataTable(strSql)
            With dtIssue
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).ColumnName = strColumnName(i)
                Next
                DgvIssue.DataSource = dtIssue
                DgvIssue.Refresh()
            End With
            ToolStripStatusLabel1.Text = dtIssue.Rows.Count & "笔"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc.PubConnection.Close()
            Sdbc = Nothing
        End Try
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Try
            If DgvIssue.RowCount = 0 Then Exit Sub
            LoadDataToExcel(DgvIssue, Me.Text & "_" & Now.ToString("yyyyMMddHHmmss"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnExcelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcelAll.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSql As String = String.Empty
        Dim dtIssue As DataTable = Nothing
        Dim strColumnName() As String = "咨询编号,厂区,类别,问题摘要,问题描述,附件路径,联系人,联系电话,邮件地址,咨询时间,咨询PC,状态,检查步骤,原因,解决方法,改善与提高,负责人,最后处理时间,完成时间".Split(",")
        Try
            If DgvIssue.RowCount = 0 Then Exit Sub

            strSql = "SELECT Items," & DecodeCaseSQL("Factory", strAllFactory) & "," & DecodeCaseSQL("Type", strAllType) _
            & ",REPLACE(REPLACE(Issue,char(13),' '),char(10),' ') Issue,REPLACE(REPLACE(IssueDetail,char(13),' '),char(10),' ') IssueDetail,FilePath," _
            & "ContactUser,ContactTel,ContactEmail,convert(varchar,CreateDate,120) CreateDate,PCInfo," _
            & DecodeCaseSQL("Status", "0-0.新开立,1-1.进行中,2-2.完成") & ",REPLACE(REPLACE(CheckSteps,char(13),' '),char(10),' ') CheckSteps," _
            & "REPLACE(REPLACE(Reason,char(13),' '),char(10),' ') Reason,REPLACE(REPLACE(Solution,char(13),' '),char(10),' ') Solution," _
            & "REPLACE(REPLACE(AnalyImprove,char(13),' '),char(10),' ') AnalyImprove," _
            & "SolveUser,convert(varchar,SolveDate,120) SolveDate,convert(varchar,ClosedDate,120) CloseDate" _
            & " FROM m_IssueRecord_t WHERE 1=1" & GetWhereSql()

            dtIssue = Sdbc.GetDataTable(strSql)
            With dtIssue
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).ColumnName = strColumnName(i)
                Next
                dgvIssueAll.DataSource = dtIssue
                dgvIssueAll.Refresh()
            End With
            LoadDataToExcel(dgvIssueAll, Me.Text & "细项_" & Now.ToString("yyyyMMddHHmmss"))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc.PubConnection.Close()
            Sdbc = Nothing
            dtIssue.Clear()
            dtIssue.Dispose()
        End Try
    End Sub

    Private Sub DgvIssue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvIssue.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        With DgvIssue.Rows(e.RowIndex)
            ShowDetail(.Cells(EnumIssue.Items).Value.ToString(), .Cells(EnumIssue.Status).Value.ToString(), .Cells(EnumIssue.Type).Value.ToString())
        End With
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub CobFactory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CobFactory.KeyDown, CobType.KeyDown, CobStatus.KeyDown, _
               TxtContactUser.KeyDown, TxtIssue.KeyDown, TxtItems.KeyDown, TxtSolveUser.KeyDown, DtCreateEnd.KeyDown, DtCreateStar.KeyDown, DtSolveEnd.KeyDown, DtSolveStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
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

    Private Function CheckDateValue() As Boolean
        CheckDateValue = True
        If Not ((DtCreateStar.Checked AndAlso DtCreateEnd.Checked) OrElse (DtSolveStart.Checked AndAlso DtSolveEnd.Checked)) Then
            MsgBox("请至少选择一组查询时间段！", 48, "提示")
        Else
            If DtCreateStar.Checked AndAlso DtCreateEnd.Checked Then
                If Not CheckDate(DtCreateStar, DtCreateEnd) Then Return False
            End If
            If DtSolveStart.Checked AndAlso DtSolveEnd.Checked Then
                If Not CheckDate(DtSolveStart, DtSolveEnd) Then Return False
            End If
        End If
    End Function

    Private Function GetWhereSql() As String
        Dim strCStr As String = DtCreateStar.Text.Trim
        Dim strCEnd As String = DtCreateEnd.Text.Trim
        Dim strSStr As String = DtSolveStart.Text.Trim
        Dim strSEnd As String = DtSolveEnd.Text.Trim

        Return IIf(CobFactory.SelectedItem("Value").ToString = "All", "", " AND Factory=N'" & CobFactory.SelectedItem("Value").ToString & "'") _
            & IIf(CobType.SelectedItem("Value").ToString = "All", "", " AND Type=N'" & CobType.SelectedItem("Value").ToString & "'") _
            & IIf(CobStatus.SelectedItem("Value").ToString = "All", "", " AND Status='" & CobStatus.SelectedItem("Value").ToString.Substring(0, 1) & "'") _
            & IIf(TxtItems.Text.Trim.Equals(String.Empty), "", " AND Items='" & TxtItems.Text.Trim & "'") _
            & IIf(TxtContactUser.Text.Trim.Equals(String.Empty), "", " AND ContactUser LIKE N'%" & TxtContactUser.Text.Trim.Replace("，", ",").ToUpper & "%'") _
            & IIf(TxtSolveUser.Text.Trim.Equals(String.Empty), "", " AND SolveUser LIKE N'%" & TxtSolveUser.Text.Trim.Replace("，", ",").ToUpper & "%'") _
            & IIf(TxtIssue.Text.Trim.Equals(String.Empty), "", " AND Issue LIKE N'%" & TxtIssue.Text.Trim & "%'") _
            & IIf(DtCreateStar.Checked, " AND CreateDate >='" & strCStr & " 00:00:00'", "") _
            & IIf(DtCreateEnd.Checked, " AND CreateDate <='" & strCEnd & " 23:59:59'", "") _
            & IIf(DtSolveStart.Checked, " AND SolveDate >='" & strSStr & " 00:00:00'", "") _
            & IIf(DtSolveEnd.Checked, " AND SolveDate <='" & strSEnd & " 23:59:59'", "")
    End Function

End Class