Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmParetoReport

    '初期化
    Private Sub FrmParetoReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KBCom.BindComboxDateIfHaveBlank(cmbType)
    End Sub

    '查询数据
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim strSQL As String = ""
        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        If chkMoid.Checked = True Then
            strSQL = " exec m_QueryGetParetoNgDataReport_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
            strSQL = String.Format(strSQL, cboPartID.Text, cboQueryLine.Text, dateFrom, dateTo,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "MO")
        Else

            Dim type As String = ""

            If cmbType.Text <> "" Then
                type = cmbType.SelectedValue.ToString
            End If

            strSQL = " exec m_QueryGetParetoNgDataReport_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
            strSQL = String.Format(strSQL, cboPartID.Text, cboQueryLine.Text, dateFrom, dateTo,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, type)
        End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("没有查询数据!")
        End If

        Me.dgvNGReport.DataSource = dt


        dgvNGReport.MergeColumnNames.Add("display")
        dgvNGReport.MergeColumnNames.Add("ngDate")
        dgvNGReport.MergeColumnNames.Add("PartID")
        dgvNGReport.MergeColumnNames.Add("LineId")
        'dgvNGReport.MergeColumnNames.Add("display")
        'dgvNGReport.MergeColumnNames.Add("display")

        ToolCount.Text = dgvNGReport.RowCount.ToString()
        Threading.Thread.Sleep(300)
    End Sub

    '导出数据
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.dgvNGReport, Me.Text)
    End Sub

    '工单
    Private Sub chkMoid_CheckedChanged(sender As Object, e As EventArgs) Handles chkMoid.CheckedChanged
        If chkMoid.Checked Then
            Label10.Visible = False
            cmbType.Visible = False
            Label8.Text = "工单:"
            'cboPartID.Items.Clear()
            cboPartID.Text = ""
            cboQueryLine.Text = ""
        Else
            Label10.Visible = True
            cmbType.Visible = True
            Label8.Text = "料号:"
        End If
    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class