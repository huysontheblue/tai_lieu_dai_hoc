Imports MainFrame.SysCheckData

''' <summary>
''' 选择客户列表
''' </summary>
''' <remarks></remarks>
Public Class FrmSelectMenuCustomer

    Dim _TKey As String = ""
    Dim _CustName As String = ""

#Region "自定义方法"

    ''' <summary>
    ''' 给COMBOBOX控件绑定项
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitComboxItem()
        Dim item0 As TComboboxItem = New TComboboxItem()
        Dim item1 As TComboboxItem = New TComboboxItem()
        Dim item2 As TComboboxItem = New TComboboxItem()

        item0.Text = "全部"
        item0.Value = "ALL"
        '
        item1.Text = "客户ID"
        item1.Value = "CusID"
        '
        item2.Text = "客户名称"
        item2.Value = "CusName"

        Me.CmbSelectField.Items.Clear()
        Me.CmbSelectField.Items.Add(item0)
        Me.CmbSelectField.Items.Add(item1)
        Me.CmbSelectField.Items.Add(item2)
        Me.CmbSelectField.DisplayMember = "Text"
        Me.CmbSelectField.ValueMember = "Value"
        Me.CmbSelectField.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' 加载数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        Try
            Me.DgvCustomer.AllowUserToAddRows = False
            Me.DgvCustomer.AutoGenerateColumns = False
            Me.DgvCustomer.MultiSelect = False
            Me.DgvCustomer.DataSource = Nothing

            '客户资料，查询条件
            Dim sqlWhere As String = ""
            If Not Me.CmbSelectField.SelectedItem Is Nothing And String.IsNullOrEmpty(Me.TxtSearch.Text.Trim) = False Then

                Dim item As TComboboxItem = Me.CmbSelectField.SelectedItem

                If item.Value.ToString = "CusID" Then
                    sqlWhere = " and CusID = '" & Me.TxtSearch.Text.Trim & "' "
                End If
                If item.Value.ToString = "CusName" Then
                    sqlWhere = " and CusName like N'%" & Me.TxtSearch.Text.Trim & "%' "
                End If

            End If

            '客户资料
            Dim sql As String = "SELECT * FROM dbo.m_Customer_t " &
                                " WHERE Usey='Y' " & sqlWhere
                                
            '如果有传过来值，则为修改；否则为父窗体为新增操作
            If String.IsNullOrEmpty(Me._TKey) = True Then
                '新增操作时，已加入菜单的不显示
                sql = sql & " AND CusName NOT IN ( " &
                                " SELECT Ttext FROM m_Logtree_t WHERE Rightid='mes00' AND Tkey LIKE'c%' AND Tparent='C0_' " &
                                " ) "
            Else
                '编辑操作时，已加入菜单的不显示，但当前菜单要显示
                sql = sql & " AND CusName NOT IN ( " &
                                " SELECT Ttext FROM m_Logtree_t WHERE Rightid='mes00' AND Tkey LIKE'c%' AND Tparent='C0_' AND Tkey!='" & Me._TKey & "' " &
                                " ) "
            End If
            '获取客户数据表
            Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)

            '数据绑定
            If Not dt Is Nothing Then
                Me.DgvCustomer.DataSource = dt
                '如果是编辑状态，默认选中行
                Dim fkey As String = ""
                Dim fcustname As String = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    fkey = IIf(Me.DgvCustomer.Item("CusID", i).Value Is Nothing, "", Me.DgvCustomer.Item("CusID", i).Value.ToString.Trim)
                    fcustname = IIf(Me.DgvCustomer.Item("CusName", i).Value Is Nothing, "", Me.DgvCustomer.Item("CusName", i).Value.ToString.Trim)
                    If String.IsNullOrEmpty(fkey) = False And String.IsNullOrEmpty(fcustname) = False And String.IsNullOrEmpty(Me._TKey) = False And String.IsNullOrEmpty(Me._CustName) = False Then
                        'If fkey = Me._TKey Then
                        If fcustname = Me._CustName Then
                            '指定当前行，并选中
                            Me.DgvCustomer.Rows(i).Selected = True
                            Me.DgvCustomer.CurrentCell = Me.DgvCustomer.Rows(i).Cells(0)
                            '赋值
                            Me.TxtCustID.Text = fkey
                            Me.TxtCustName.Text = fcustname
                            '部分资料录入不严谨，字符串两边有空格，再次去掉空格
                            Me.TxtCustID.Text = Me.TxtCustID.Text.Trim
                            Me.TxtCustName.Text = Me.TxtCustName.Text.Trim
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MessageUtils.ShowError("显示客户列表时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "标准事件"

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(ByVal tkey As String, ByVal custName As String)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._TKey = tkey
        Me._CustName = custName
    End Sub

    ''' <summary>
    ''' 标准事件：窗体加载
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSelectMenuCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitComboxItem()
        BtnRefresh.PerformClick()
    End Sub

    ''' <summary>
    ''' 标准事件：查询按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        LoadData()
    End Sub

    ''' <summary>
    ''' 标准事件：关闭按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 标准事件：确定按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        Try
            If (Me.DgvCustomer.Rows.Count > 0) Then
                If String.IsNullOrEmpty(Me.TxtCustID.Text.Trim) = True Then
                    MessageBox.Show("请先选择记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Else
                MessageBox.Show("没有可选择的记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            '给父窗口返回数据
            Dim frmParent As FrmSysMenu = Me.Owner
            'frmParent.TxtMenuKey.Text = Me.TxtCustID.Text.Trim     '菜单TKEY值不填，让用户手动编码输入
            frmParent.TxtMenuName.Text = Me.TxtCustName.Text.Trim
            '保存来源值
            frmParent.TxtFieldId.Text = Me.TxtCustID.Text.Trim
            frmParent.TxtFieldName.Text = Me.TxtCustName.Text.Trim
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("点击确定按钮时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 行索引变化时更新选中的栏位值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DgvCustomer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCustomer.CellClick
        If e.RowIndex = -1 OrElse Me.DgvCustomer.RowCount < 1 Then Exit Sub
        Dim iIndex As Integer = Me.DgvCustomer.CurrentRow.Index
        Me.TxtCustID.Text = IIf(Me.DgvCustomer.Item("CusID", iIndex).Value Is Nothing, "", Me.DgvCustomer.Item("CusID", iIndex).Value.ToString)
        Me.TxtCustName.Text = IIf(Me.DgvCustomer.Item("CusName", iIndex).Value Is Nothing, "", Me.DgvCustomer.Item("CusName", iIndex).Value.ToString)
        '部分资料录入不严谨，字符串两边有空格，再次去掉空格
        Me.TxtCustID.Text = Me.TxtCustID.Text.Trim
        Me.TxtCustName.Text = Me.TxtCustName.Text.Trim
    End Sub

    ''' <summary>
    ''' 标准事件：画表格行号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DgvCustomer_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvCustomer.RowPostPaint
        Using b As SolidBrush = New SolidBrush(Me.DgvCustomer.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    ''' <summary>
    ''' 标准事件：查询栏位回车执行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnRefresh.PerformClick()
        End If
    End Sub

#End Region

End Class

#Region "自定义类"

''' <summary>
''' ComboboxItem类
''' 用于Combobox的项绑定
''' </summary>
''' <remarks></remarks>
Public Class TComboboxItem
    Dim _text As String = ""
    Dim _value As String = ""

    '项的显示文本
    Property Text() As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property

    '项的值
    Property Value() As Object
        Get
            Return _value
        End Get
        Set(value As Object)
            _value = value
        End Set
    End Property

End Class

#End Region