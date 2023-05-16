Imports MainFrame

Public Class FrmProductNGDayQuerySub

    Public checkedType As String = ""
    '返回选择线别
    Public checkedLine As String = ""
    '返回选择料号
    Public checkedPartId As String = ""


#Region "线别选择"

    Private Sub FrmProductNGDayQuerySub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(420, 457)

        If checkedType = "LINE" Then
            Me.Text = "线别选择-部门对应线别列表"
            Me.SplitContainer3.Panel1Collapsed = False
            Me.SplitContainer3.Panel2Collapsed = True
            SetLineData()
        Else
            Me.Text = "料号选择-扫描线别对应料号列表"
            Me.SplitContainer3.Panel1Collapsed = True
            Me.SplitContainer3.Panel2Collapsed = False
            SetPartIdData()
            cbbPartId_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetLineData()
        Dim strDepts As String = Getids(txtSelectedDept.Text)

        Dim strSQL As String
        If txtSelectedDept.Text = "" Then
            strSQL =
            " select distinct a.lineid from deptline_t a, m_dept_t b  " &
            " where a.deptid=b.deptid  and a.usey='Y' "
        Else
            strSQL =
             " select distinct a.lineid from deptline_t a, m_dept_t b " &
             " where a.deptid=b.deptid and b.deptid in(" & strDepts & ") and a.usey='Y' "
        End If

        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

        checkListBoxLine.DataSource = dt
        checkListBoxLine.ValueMember = "lineid"
        checkListBoxLine.DisplayMember = "lineid"

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        For i As Integer = 0 To checkListBoxLine.Items.Count - 1
            If checkListBoxLine.GetItemChecked(i) = True Then
                checkedLine = checkedLine + "," + DirectCast(checkListBoxLine.Items(i), System.Data.DataRowView).Row.ItemArray(0)
            End If
        Next
        If checkedLine.Contains(",") Then
            checkedLine = checkedLine.Substring(1)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '全选
    Private Sub btnSelectedAll_Click(sender As Object, e As EventArgs) Handles btnSelectedAll.Click
        If btnSelectedAll.Text = "全选" Then
            btnSelectedAll.Text = "反选"
            For i As Integer = 0 To checkListBoxLine.Items.Count - 1
                Me.checkListBoxLine.SetItemChecked(i, True)
            Next
        Else
            btnSelectedAll.Text = "全选"
            For i As Integer = 0 To checkListBoxLine.Items.Count - 1
                Me.checkListBoxLine.SetItemChecked(i, False)
            Next
        End If
    End Sub
#End Region

#Region "子料号数据选择"
    Private Sub SetPartIdData()
        Dim strDepts As String = Getids(txtSelectedDept.Text)

        Dim strSQL As String
        If txtSelectedDept.Text = "" Then
            strSQL =
            " select distinct a.lineid from deptline_t a, m_dept_t b  " &
            " where a.deptid=b.deptid  "
        Else
            strSQL =
             " select distinct a.lineid from deptline_t a, m_dept_t b " &
             " where a.deptid=b.deptid and b.deptid in(" & strDepts & ") "
        End If

        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

        checkListBoxLine.DataSource = dt
        checkListBoxLine.ValueMember = "lineid"
        checkListBoxLine.DisplayMember = "lineid"

    End Sub

    '设置子料号
    Private Sub cbbPartId_TextChanged(sender As Object, e As EventArgs) Handles cbbPartId.TextChanged
        If cbbPartId.Text = "System.Data.DataRowView" Then Exit Sub
        If cbbPartId.Text.Trim.Length <= 8 Then Exit Sub

        Dim strSQL As String
        strSQL = " select TAvcPart from m_PartContrast_t where PAvcPart ='{0}' and TAvcPart LIKE '{0}%' "
        strSQL = String.Format(strSQL, cbbPartId.Text)

        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

        checkListPartId.DataSource = dt
        checkListPartId.ValueMember = "TAvcPart"
        checkListPartId.DisplayMember = "TAvcPart"
    End Sub

    '全选，反选
    Private Sub btnSelectedAll2_Click(sender As Object, e As EventArgs) Handles btnSelectedAll2.Click
        If btnSelectedAll2.Text = "全选" Then
            btnSelectedAll2.Text = "反选"
            For i As Integer = 0 To checkListPartId.Items.Count - 1
                Me.checkListPartId.SetItemChecked(i, True)
            Next
        Else
            btnSelectedAll2.Text = "全选"
            For i As Integer = 0 To checkListPartId.Items.Count - 1
                Me.checkListPartId.SetItemChecked(i, False)
            Next
        End If
    End Sub

    '关闭
    Private Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        Me.Close()
    End Sub

    '确认
    Private Sub btnOk2_Click(sender As Object, e As EventArgs) Handles btnOk2.Click
        For i As Integer = 0 To checkListPartId.Items.Count - 1
            If checkListPartId.GetItemChecked(i) = True Then
                checkedPartId = checkedPartId + "," + DirectCast(checkListPartId.Items(i), System.Data.DataRowView).Row.ItemArray(0)
            End If
        Next
        If checkedPartId.Contains(",") Then
            checkedPartId = checkedPartId.Substring(1)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

End Class