Imports MainFrame
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

Public Class frmPackingPGCheck

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPackingPGCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Search()
      
    End Sub

    '设置Grid颜色
    Private Sub SetGridColor(gridView As DataGridView, colName As String)
        For rowIndex As Integer = 0 To gridView.Rows.Count - 1
            If gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("D") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.White
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("P") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen
            End If
        Next
    End Sub

    Private Sub Search()
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim strSQL As String
        Dim Moid As String = ""
        Dim PartID As String = ""
        Dim LineID As String = ""
        Dim PPid As String = ""
        Dim Table As New DataTable
        Try

            Moid = txtMoid.Text.Trim
            PartID = txtPartNo.Text.Trim
            PPid = txtPPid.Text.Trim

            If Not CheckDate(DtStar, DtEnd, True, 6) Then Exit Sub

            'If CobMo.Text = "" And CobPart.Text = "" And TokenEditor1.Text = "" Then
            '    MessageUtils.ShowError("请至少输入一个查询条件！")
            '    Exit Sub
            'End If

            strSQL = "exec m_SearchPpidNgWeightReport_p '" & StartDT & "','" & EndDT & "','" & PartID & "','" & Moid & "','" & PPid & "' ,1"
            Table = DbOperateUtils.GetDataTable(strSQL)
            dgQueryMain.DataSource = Table

            '设置Grid颜色
            SetGridColor(dgQueryMain, "Stateid")
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 退出 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' IPQC确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolIPQC_Click(sender As Object, e As EventArgs) Handles toolIPQC.Click
        Try
            '检查数据 
            If CheckStatus() = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定IPQC确认吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim tType As String
            Dim ppid As String
            Dim stationid As String
            Dim tablename As String

            For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
                If Me.dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    tType = Me.dgQueryMain.Rows(rowIndex).Cells("tType").EditedFormattedValue.ToString
                    ppid = Me.dgQueryMain.Rows(rowIndex).Cells("ppid").EditedFormattedValue.ToString
                    stationid = Me.dgQueryMain.Rows(rowIndex).Cells("StationName").EditedFormattedValue.ToString.Split("-")(0)

                    If tType = 1 Then
                        tablename = "m_OnlineWeightBarePpidNg_t"
                    Else
                        tablename = "m_OnlineWeightPpidNg_t"
                    End If

                    strSQL.AppendFormat(" update {0} set State='P', Reason = N'{1}', ConfirmUserId = '{2}',ConfirmTime = getdate() where ppid='{3}' and stationid = '{4}' ",
                                        tablename, txtReason.Text, VbCommClass.VbCommClass.UseId, ppid, stationid)

                End If
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)

            txtReason.Text = ""
            '重新更新查询
            Search()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '检查选择数据状态
    Private Function CheckStatus() As Boolean
        Dim alList As ArrayList = New ArrayList

        GetStatus(alList)
        If alList.Count = 0 Then
            MessageUtils.ShowInformation("请选择数据！")
            Return False
        End If

        For index As Integer = 0 To alList.Count - 1
            If alList(index).Contains("P") Then
                MessageUtils.ShowInformation("该产品IPQC已确认，不能再确认，请确认！！")
                Return False
            End If
        Next

        If String.IsNullOrEmpty(txtReason.Text) = True Then
            MessageUtils.ShowInformation("请输入异常原因，再确认！！")
            txtReason.Focus()
            Return False
        End If

        Return True
    End Function

    '取得选择数据
    Private Sub GetStatus(ByRef alList As ArrayList)
        For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
            If Not dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                alList.Add(dgQueryMain.Rows(rowIndex).Cells("Stateid").EditedFormattedValue.ToString)
            End If
        Next
    End Sub

    ''' <summary>
    ''' 检查时间
    ''' </summary>
    ''' <param name="starDT"></param>
    ''' <param name="endDT"></param>
    ''' <param name="checkt">默认检测时间间隔</param>
    ''' <param name="months">检测时间间隔月份数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckDate(ByVal starDT As DateTimePicker, ByVal endDT As DateTimePicker, Optional ByVal checkt As Boolean = True, Optional ByVal months As Integer = 2)
        If starDT.Value > endDT.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            endDT.Value = Now()
            Return False
        End If

        If starDT.Value < "2007-01-01" Then
            MsgBox("起始時間不能小於2007-01-01!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        'If endDT.Value > Now Then
        '    MsgBox("結束時間不能大於現在時間!", 48, "提示")
        '    endDT.Value = Now()
        '    Return False
        'End If
        If checkt Then
            Dim startDate As DateTime = DateTime.Parse(starDT.Text)
            Dim endDate As DateTime = DateTime.Parse(endDT.Text)
            If startDate.AddMonths(months) < endDate Then
                MsgBox("查询时间相隔最多请不要超过" & months.ToString & "个月", 48, "提示")
                starDT.Value = DateAdd(DateInterval.Month, -1, endDate)
                Return False
            End If
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub chbSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbSelectAll.CheckedChanged
        If (Me.dgQueryMain.RowCount > 0) Then
            For i As Int16 = 0 To Me.dgQueryMain.RowCount - 1
                dgQueryMain.Rows(i).Cells("QueryCheckBox").Value = Me.chbSelectAll.Checked
            Next
        End If
    End Sub

#Region "Grid行数"
    Private Sub dgResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgQueryMain.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region



End Class