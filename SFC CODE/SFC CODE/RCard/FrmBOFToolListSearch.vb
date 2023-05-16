Public Class FrmBOFToolListSearch

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private _Where As String
    ''' <summary>
    ''' 查询条件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Where() As String
        Get
            Return _Where
        End Get
        Set(ByVal value As String)
            _Where = value
        End Set
    End Property

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 确定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Me.Where = " where 1=1 "
        If String.IsNullOrEmpty(txtPartID.Text.Trim()) = False Then
            Me.Where += " and PartID LIKE N'%" & txtPartID.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtCustName.Text.Trim()) = False Then
            Me.Where += " and CustName =N'" & txtCustName.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtProductName.Text.Trim()) = False Then
            Me.Where += " and ProductName like N'%" & txtProductName.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtDescription.Text.Trim()) = False Then
            Me.Where += " and Description like N'%" & txtDescription.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtShape.Text.Trim()) = False Then
            Me.Where += " and Shape like N'%" & txtShape.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(cmbStatus.SelectedValue) = False Then
            Me.Where += " and State='" & cmbStatus.SelectedValue & "'"
        End If
        If String.IsNullOrEmpty(txtPIEName.Text.Trim()) = False Then
            Me.Where += " and PIEName=N'" & txtPIEName.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtFEName.Text.Trim()) = False Then
            Me.Where += " and FEName=N'" & txtFEName.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtDocID.Text.Trim()) = False Then
            Me.Where += " and DocID='" & txtDocID.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(dtpStart.Text.Trim()) = False Then
            Me.Where += " and cast(InTime as date)>=cast('" & dtpStart.Text & "' as date)"
        End If
        If String.IsNullOrEmpty(dtpEnd.Text.Trim()) = False Then
            Me.Where += " and cast(InTime as date)<=cast('" & dtpEnd.Text & "' as date)"
        End If
        If cmbFESchedule.Text <> "请选择" Then
            Me.Where += " and FESchedule=N'" & cmbFESchedule.Text & "'"
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        dtpStart.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        dtpEnd.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub FrmBOFToolListSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFESchedule.SelectedIndex = 0
        bindStatus()
    End Sub

    Private Sub bindStatus()
        Dim dt = New DataTable()
        dt.Columns.AddRange(New DataColumn() {New DataColumn("ID"), New DataColumn("Name")})
        Dim dr = dt.NewRow()
        dr(0) = ""
        dr(1) = "全部"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "0"
        dr(1) = "制作中"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "1"
        dr(1) = "待审核"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "2"
        dr(1) = "已完成"
        dt.Rows.Add(dr)
        cmbStatus.DataSource = dt
        cmbStatus.ValueMember = "ID"
        cmbStatus.DisplayMember = "Name"
        cmbStatus.SelectedIndex = 0
    End Sub

End Class