Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms


Public Class FrmAddBOFToolListDetail

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        bindStation()
    End Sub

#Region "属性"
    Private _PartID As String
    ''' <summary>
    ''' 料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartID() As String
        Get
            Return _PartID
        End Get
        Set(ByVal value As String)
            _PartID = value
        End Set
    End Property

    Private _bOFVersion As String
    Public Property BOFVersion() As String
        Get
            Return _bOFVersion
        End Get
        Set(ByVal value As String)
            _bOFVersion = value
        End Set
    End Property

    Private _MyStationID As String
    ''' <summary>
    ''' 工站编号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyStationID() As String
        Get
            Return _MyStationID
        End Get
        Set(ByVal value As String)
            _MyStationID = value
        End Set
    End Property

    Private _MyStationName As String
    ''' <summary>
    ''' 工站名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyStationName() As String
        Get
            Return _MyStationName
        End Get
        Set(ByVal value As String)
            _MyStationName = value
        End Set
    End Property

    Private _MyUserName As String
    ''' <summary>
    ''' 用户
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyUserName() As String
        Get
            Return _MyUserName
        End Get
        Set(ByVal value As String)
            _MyUserName = value
        End Set
    End Property

    Private _MyInTime As Date
    ''' <summary>
    ''' 时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyInTime() As Date
        Get
            Return _MyInTime
        End Get
        Set(ByVal value As Date)
            _MyInTime = value
        End Set
    End Property



    Private _OrderBy As String
    ''' <summary>
    ''' 排序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property



    Private _OP As String = "Add"
    Public Property OP() As String
        Get
            Return _OP
        End Get
        Set(ByVal value As String)
            _OP = value
        End Set
    End Property

    Private _BOFToolListDID As Integer

    Public Property BOFToolListDID() As Integer
        Get
            Return _BOFToolListDID
        End Get
        Set(ByVal value As Integer)
            _BOFToolListDID = value
        End Set
    End Property


#End Region

#Region "窗体加载事件"
    ''' <summary>
    ''' 窗体加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmAddBOFToolListDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEquimentType.SelectedIndex = 0
        If OP = "Modify" Then
            cmbStation.SelectedValue = Me.MyStationID
            dgvData.AutoGenerateColumns = False
            Dim sql = "select * from  V_m_BOFToolListDEquiment_t where PartID=N'" & Me.PartID & "' and StationOrderBy='" & Me.OrderBy & "'"
            dgvData.DataSource = DbOperateUtils.GetDataTable(sql)
            SetControlIsNoEnable()
            dgvData.ReadOnly = False
            dgvData.Columns("StationName").ReadOnly = True
            dgvData.Columns("EquimentType").ReadOnly = True
            lblMessage.Visible = False
            txtOrderBy.Text = Me.OrderBy.ToString()
        ElseIf OP = "Add" Then
            Me.Text = "新增BOF清单明细档"
            dgvData.AutoGenerateColumns = False
            txtOrderBy.Enabled = False
            dgvData.DataSource = DbOperateUtils.GetDataTable("select * from  V_m_BOFToolListDEquiment_t where 1=2")
            txtOrderBy.Value = Convert.ToInt32(DbOperateUtils.GetDataTable("select  isnull(max(OrderBy),0)+1 from  m_BOFToolListD_t where PartID=N'" & Me.PartID & "' AND  isnull(BOFVersion,'" & BOFVersion & "')='" & BOFVersion & "' ").Rows(0)(0))
        ElseIf OP = "Insert" Then
            Me.Text = "新增BOF清单明细档-插入工站"
            dgvData.DataSource = DbOperateUtils.GetDataTable("select * from  V_m_BOFToolListDEquiment_t where 1=2")
            txtOrderBy.Text = (Me.OrderBy).ToString()
            txtOrderBy.Enabled = False
        End If
    End Sub
#End Region

#Region "加载工站"
    ''' <summary>
    ''' 加载工站
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bindStation()
        Dim sql = "select * from dbo.m_Rstation_t"
        cmbStation.DataSource = DbOperateUtils.GetDataTable(sql)
        cmbStation.DisplayMember = "Stationname"
        cmbStation.ValueMember = "Stationid"
        cmbStation.SelectedIndex = -1
    End Sub
#End Region

#Region "检查数据有效性"
    ''' <summary>
    ''' 检查数据有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckValidateData() As Boolean
        Dim yy = True
        Dim num As Integer = 0
        Dim num1 As Double = 0
        Try
            If String.IsNullOrEmpty(Convert.ToString(cmbStation.SelectedValue)) Then
                MessageUtils.ShowError("工站不能为空!")
                Return yy = False
            ElseIf String.IsNullOrEmpty(txtEquimentName.Text.Trim()) Then
                MessageUtils.ShowError("设备/治具名称不能为空!")
                Return yy = False
            ElseIf String.IsNullOrEmpty(txtDemandQty.Text.Trim()) Then
                MessageUtils.ShowError("需求数量不能为空!")
                Return yy = False
            ElseIf Integer.TryParse(txtDemandQty.Text.Trim(), num) = False Then
                MessageUtils.ShowError("需求数量必须是整数类型!")
                Return yy = False
            ElseIf Integer.Parse(txtDemandQty.Text.Trim()) <= 0 Then
                MessageUtils.ShowError("需求数量必须大于0!")
                Return yy = False
            ElseIf String.IsNullOrEmpty(txtPrice.Text.Trim()) = False Then
                If Double.TryParse(txtPrice.Text.Trim(), num1) = False Then
                    MessageUtils.ShowError("价格必须是数字类型!")
                    Return yy = False
                ElseIf Double.Parse(txtPrice.Text.Trim()) < 0 Then
                    MessageUtils.ShowError("价格必须是大于0!")
                    Return yy = False
                End If
            ElseIf String.IsNullOrEmpty(txtCapacity.Text.Trim()) = False Then
                If Double.TryParse(txtCapacity.Text.Trim(), num1) = False Then
                    MessageUtils.ShowError("产能必须是数字类型")
                    Return yy = False
                ElseIf Double.Parse(txtCapacity.Text.Trim()) < 0 Then
                    MessageUtils.ShowError("产能必须大于0")
                    Return yy = False
                End If
            End If
            If String.IsNullOrEmpty(txtPrice.Text.Trim()) = False Then
                txtPrice.Text = Double.Parse(txtPrice.Text.Trim()).ToString()
            End If
            If String.IsNullOrEmpty(txtDemandQty.Text.Trim()) = False Then
                txtDemandQty.Text = Integer.Parse(txtDemandQty.Text.Trim()).ToString()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("检查数据类型异常:" & vbCrLf & "" + ex.Message)
            yy = False
        End Try
        Return yy
    End Function
#End Region

#Region "提交"
    ''' <summary>
    ''' 提交
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try

            If String.IsNullOrEmpty(cmbStation.SelectedValue) Then
                MessageUtils.ShowError("请选中一个工站!")
                Exit Sub
            End If

            '用户修改工序的时候最大上限
            Dim MaxOrderBy As Integer = DbOperateUtils.GetDataTable("select * from m_BOFToolListD_t where PartID=N'" & Me.PartID & "'").Rows.Count

            Dim sql = New System.Text.StringBuilder()
            If OP = "Add" Then

                If dgvData.Rows.Count = 0 Then
                    If CheckValidateData() = False Then
                        Exit Sub
                    End If
                End If

                Dim OrderBy = txtOrderBy.Value

                sql.AppendLine(String.Format("insert into m_BOFToolListD_t" & vbCrLf &
                "(PartID,Stationid,StationName,InTime,UserID,UserName,OrderBy,BOFVersion)" & vbCrLf &
                 " values(N'{0}','{1}',N'{2}',getdate(),'{3}',N'{4}','{5}','{6}')",
                 PartID, cmbStation.SelectedValue, cmbStation.Text.Trim(),
                VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, OrderBy, BOFVersion))

                If dgvData.Rows.Count = 0 Then
                    Dim EquimentName = ""
                    Dim DemandQty = ""
                    Dim Price = ""
                    Dim EquimentNameZhiJu = ""
                    Dim DemandQtyZhiJu = ""
                    Dim PriceZhiJu = ""
                    If cmbEquimentType.Text = "设备" Then
                        EquimentName = txtEquimentName.Text.Trim()
                        DemandQty = IIf(String.IsNullOrEmpty(txtDemandQty.Text.Trim()), "0", txtDemandQty.Text.Trim())
                        Price = IIf(String.IsNullOrEmpty(txtPrice.Text.Trim()), "0", txtPrice.Text.Trim())
                        DemandQtyZhiJu = "0"   ' Modify by cq 20190619"null"
                        PriceZhiJu = "0"
                    Else
                        EquimentNameZhiJu = txtEquimentName.Text.Trim()
                        DemandQtyZhiJu = txtDemandQty.Text.Trim()
                        PriceZhiJu = IIf(String.IsNullOrEmpty(txtPrice.Text.Trim()), "0", txtPrice.Text.Trim())
                        DemandQty = "0"
                        Price = "0"
                    End If
                    sql.AppendLine(String.Format(" insert into m_BOFToolListDEquiment_t " & vbCrLf & "(PartID,Stationid,StationName,EquimentType,EquimentName,DemandQty,Price,Capacity,FixtureNumber,Remark,UserID,UserName,InTime,StationOrderBy,EquimentNameZhiJu,DemandQtyZhiJu,PriceZhiJu,BOFVersion) " & vbCrLf &
                          " values(N'{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}',N'{8}',N'{9}','{10}',N'{11}','{12}','{13}',N'{14}',{15},'{16}','{17}')", Me.PartID, cmbStation.SelectedValue, cmbStation.Text, cmbEquimentType.Text, EquimentName, DemandQty, Price, txtCapacity.Text.Trim(), txtFixtureNumber.Text.Trim(), txtRemark.Text.Trim(), VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Date.Now, OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu, BOFVersion))
                Else
                    For Each dgrv As DataGridViewRow In dgvData.Rows
                        Dim StationID = dgrv.Cells("StationID").Value.ToString().Trim()
                        Dim StationName = dgrv.Cells("StationName").Value.ToString().Trim()
                        Dim EquimentType = dgrv.Cells("EquimentType").Value.ToString().Trim()
                        Dim EquimentName = ""
                        Dim DemandQty = ""
                        Dim Price = ""
                        Dim Capacity = dgrv.Cells("Capacity").Value.ToString().Trim()
                        Dim FixtureNumber = dgrv.Cells("FixtureNumber").Value.ToString().Trim()
                        Dim Remark = dgrv.Cells("Remark").Value.ToString().Trim()
                        Dim UserID = dgrv.Cells("UserID").Value.ToString()
                        Dim UserName = dgrv.Cells("UserName").Value.ToString()
                        Dim InTime = dgrv.Cells("InTime").Value.ToString()


                        Dim EquimentNameZhiJu = ""
                        Dim DemandQtyZhiJu = ""
                        Dim PriceZhiJu = ""
                        If EquimentType = "设备" Then
                            EquimentName = dgrv.Cells("EquimentName").Value.ToString().Trim()
                            DemandQty = dgrv.Cells("DemandQty").Value.ToString().Trim()
                            Price = dgrv.Cells("Price").Value.ToString().Trim()
                            Price = IIf(String.IsNullOrEmpty(Price), "0", Price)
                            DemandQtyZhiJu = "0"
                            PriceZhiJu = "0"
                        Else
                            EquimentNameZhiJu = dgrv.Cells("EquimentName").Value.ToString().Trim()
                            DemandQtyZhiJu = dgrv.Cells("DemandQty").Value.ToString().Trim()
                            PriceZhiJu = dgrv.Cells("Price").Value.ToString().Trim()
                            PriceZhiJu = IIf(String.IsNullOrEmpty(PriceZhiJu), "0", PriceZhiJu)
                            DemandQty = "0"
                            Price = "0"
                        End If


                        sql.AppendLine(String.Format(" insert into m_BOFToolListDEquiment_t " & vbCrLf &
                                     "(PartID,Stationid,StationName,EquimentType,EquimentName,DemandQty,Price,Capacity,FixtureNumber,Remark,UserID,UserName,InTime,StationOrderBy,EquimentNameZhiJu,DemandQtyZhiJu,PriceZhiJu,BOFVersion) " & vbCrLf &
                                     "values(N'{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}',N'{8}',N'{9}','{10}',N'{11}','{12}','{13}',N'{14}',{15},{16},'{17}')", Me.PartID, StationID, StationName, EquimentType, EquimentName, DemandQty, Price, Capacity, FixtureNumber, Remark, UserID, UserName, InTime, OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu, BOFVersion))
                    Next
                End If
            ElseIf OP = "Modify" Then
                If txtOrderBy.Value < 1 Or txtOrderBy.Value > MaxOrderBy Then
                    MessageUtils.ShowError("工序只能是1~" & txtOrderBy.Value & "之间")
                    Exit Sub
                End If

                If Me.OrderBy <> txtOrderBy.Value Then '用户修改调整当前工序
                    sql.AppendLine(String.Format("exec Proc_ModifyBOFToolListDOrderBy N'{0}',{1},'{2}',{3}", Me.PartID, Me.OrderBy, "Modify", txtOrderBy.Value))

                End If

                sql.AppendLine(String.Format("update m_BOFToolListD_t" & vbCrLf &
             "set Stationid='{2}',StationName=N'{3}'," & vbCrLf &
             "InTime=getdate(),UserID='{4}',UserName=N'{5}',OrderBy={6} where PartID=N'{0}' and ID='{1}' and Stationid='{7}' ",
             Me.PartID, Me.BOFToolListDID, cmbStation.SelectedValue, cmbStation.Text.Trim(),
             VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, txtOrderBy.Value, Me.MyStationID))
               

                If Me.MyStationName.Trim() <> cmbStation.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
                    "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,OrderBy) " & vbCrLf &
                    "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}',getdate(),N'{6}',N'{7}','{8}')", Me.PartID, "工站", Me.MyUserName, Me.MyInTime, Me.MyStationName, VbCommClass.VbCommClass.UseName, cmbStation.Text.Trim(), Me.MyStationName, Me.OrderBy))
                End If
                For Each dgrv As DataGridViewRow In dgvData.Rows
                    Dim ID = dgrv.Cells("ID").Value.ToString().Trim()
                    Dim StationID = dgrv.Cells("StationID").Value.ToString().Trim()
                    Dim EquimentType = dgrv.Cells("EquimentType").Value.ToString().Trim()
                    Dim StationName = dgrv.Cells("StationName").Value.ToString().Trim()
                    Dim EquimentName = ""
                    Dim DemandQty = ""
                    Dim Price = ""
                    Dim Capacity = dgrv.Cells("Capacity").Value.ToString().Trim()
                    Dim FixtureNumber = dgrv.Cells("FixtureNumber").Value.ToString().Trim()
                    Dim Remark = dgrv.Cells("Remark").Value.ToString().Trim()
                    Dim UserID = dgrv.Cells("UserID").Value.ToString().Trim()
                    Dim UserName = dgrv.Cells("UserName").Value.ToString().Trim()
                    Dim InTime = dgrv.Cells("InTime").Value.ToString().Trim()

                    Dim EquimentNameZhiJu = ""
                    Dim DemandQtyZhiJu = ""
                    Dim PriceZhiJu = ""
                    If EquimentType = "设备" Then
                        EquimentName = dgrv.Cells("EquimentName").Value.ToString().Trim()
                        DemandQty = dgrv.Cells("DemandQty").Value.ToString().Trim()
                        Price = dgrv.Cells("Price").Value.ToString().Trim()
                        Price = IIf(String.IsNullOrEmpty(Price), "0", Price)
                        DemandQtyZhiJu = "0"
                        PriceZhiJu = "0"
                    Else
                        EquimentNameZhiJu = dgrv.Cells("EquimentName").Value.ToString().Trim()
                        DemandQtyZhiJu = dgrv.Cells("DemandQty").Value.ToString().Trim()
                        PriceZhiJu = dgrv.Cells("Price").Value.ToString().Trim()
                        PriceZhiJu = IIf(String.IsNullOrEmpty(PriceZhiJu), "0", PriceZhiJu)
                        DemandQty = "0"
                        Price = "0"
                    End If

                    Dim dr = DbOperateUtils.GetDataTable("select * from m_BOFToolListDEquiment_t where id=" + ID).Rows(0)
                    If dr("EquimentName").ToString().Trim() <> EquimentName Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
                    "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
                    "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "设备/治具名称", dr("UserName").ToString(), dr("InTime").ToString(), dr("EquimentName").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, EquimentName, StationName, dr("EquimentName").ToString().Trim(), Me.OrderBy))
                    End If
                    If (EquimentType = "设备" And dr("DemandQty").ToString().Trim() <> DemandQty And String.IsNullOrEmpty(dr("DemandQty").ToString().Trim()) = False) Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
                "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
                "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "需求数量", dr("UserName").ToString(), dr("InTime").ToString(), dr("DemandQty").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, DemandQty, StationName, EquimentName, Me.OrderBy))

                    ElseIf (EquimentType = "治具" And dr("DemandQtyZhiJu").ToString().Trim() <> DemandQtyZhiJu And String.IsNullOrEmpty(dr("DemandQtyZhiJu").ToString().Trim()) = False) Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
               "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
               "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "需求数量", dr("UserName").ToString(), dr("InTime").ToString(), dr("DemandQtyZhiJu").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, DemandQtyZhiJu, StationName, EquimentNameZhiJu, Me.OrderBy))
                    End If
                    If (EquimentType = "设备" And dr("Price").ToString().Trim() <> Price And String.IsNullOrEmpty(dr("Price").ToString().Trim()) = False) Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
              "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
              "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "价格", dr("UserName").ToString(), dr("InTime").ToString(), dr("Price").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, Price, StationName, EquimentName, Me.OrderBy))

                    ElseIf (EquimentType = "治具" And dr("PriceZhiJu").ToString().Trim() <> PriceZhiJu And String.IsNullOrEmpty(dr("PriceZhiJu").ToString().Trim()) = False) Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
             "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
             "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "价格", dr("UserName").ToString(), dr("InTime").ToString(), dr("PriceZhiJu").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, PriceZhiJu, StationName, EquimentNameZhiJu, Me.OrderBy))

                    End If
                    If dr("Capacity").ToString().Trim() <> Capacity Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
             "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
             "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "产能", dr("UserName").ToString(), dr("InTime").ToString(), dr("Capacity").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, Capacity, StationName, EquimentName, Me.OrderBy))
                    End If
                    If dr("FixtureNumber").ToString().Trim() <> FixtureNumber Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
          "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
          "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "治具料号", dr("UserName").ToString(), dr("InTime").ToString(), dr("FixtureNumber").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, FixtureNumber, StationName, EquimentName, Me.OrderBy))
                    End If
                    If dr("Remark").ToString().Trim() <> Remark Then
                        sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
        "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
        "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "备注", dr("UserName").ToString(), dr("InTime").ToString(), dr("Remark").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, Remark, StationName, EquimentName, Me.OrderBy))
                    End If
                    sql.AppendLine(String.Format("update m_BOFToolListDEquiment_t set " & vbCrLf &
                   "StationID='{1}',StationName=N'{2}',EquimentName=N'{3}'" & vbCrLf &
                   ",DemandQty={4},Price={5},Capacity=N'{6}',FixtureNumber=N'{7}',Remark=N'{8}',UserID='{9}',UserName=N'{10}',InTime='{11}',StationOrderBy={12},EquimentNameZhiJu=N'{14}',DemandQtyZhiJu={15},PriceZhiJu={16} where id={0} and StationOrderBy={13}",
                   ID, StationID, StationName, EquimentName, DemandQty, Price, Capacity, FixtureNumber, Remark, VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Date.Now, txtOrderBy.Value, Me.OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu))
                Next
            ElseIf OP = "Insert" Then '插入工站
                If dgvData.Rows.Count = 0 Then
                    If CheckValidateData() = False Then
                        Exit Sub
                    End If
                End If
                '在当前工序及以后的工序往后移一位
                sql.AppendLine(String.Format("exec  Proc_ModifyBOFToolListDOrderBy N'{0}',{1},'{2}',{3},{4}", Me.PartID, Me.OrderBy, "Insert", -1, BOFVersion))

                '在当前工序插入一个新的工站
                sql.AppendLine(String.Format("insert into m_BOFToolListD_t" & vbCrLf &
                "(PartID,Stationid,StationName,InTime,UserID,UserName,OrderBy,BOFVersion)" & vbCrLf &
                 " values(N'{0}','{1}',N'{2}',getdate(),'{3}',N'{4}','{5}','" & BOFVersion & "')",
                 PartID, cmbStation.SelectedValue, cmbStation.Text.Trim(),
                VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Me.OrderBy))

                If dgvData.Rows.Count = 0 Then
                    Dim EquimentName = ""
                    Dim DemandQty = ""
                    Dim Price = ""
                    Dim EquimentNameZhiJu = ""
                    Dim DemandQtyZhiJu = ""
                    Dim PriceZhiJu = ""
                    If cmbEquimentType.Text = "设备" Then
                        EquimentName = txtEquimentName.Text.Trim()
                        DemandQty = IIf(String.IsNullOrEmpty(txtDemandQty.Text.Trim()), "0", txtDemandQty.Text.Trim())
                        Price = IIf(String.IsNullOrEmpty(txtPrice.Text.Trim()), "0", txtPrice.Text.Trim())
                        DemandQtyZhiJu = "0"
                        PriceZhiJu = "0"
                    Else
                        EquimentNameZhiJu = txtEquimentName.Text.Trim()
                        DemandQtyZhiJu = txtDemandQty.Text.Trim()
                        PriceZhiJu = IIf(String.IsNullOrEmpty(txtPrice.Text.Trim()), "0", txtPrice.Text.Trim())
                        DemandQty = "0"
                        Price = "0"
                    End If
                    sql.AppendLine(String.Format(" insert into m_BOFToolListDEquiment_t " & vbCrLf & "(PartID,Stationid,StationName,EquimentType,EquimentName,DemandQty,Price,Capacity,FixtureNumber,Remark,UserID,UserName,InTime,StationOrderBy,EquimentNameZhiJu,DemandQtyZhiJu,PriceZhiJu) " & vbCrLf &
                    "values(N'{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}',N'{8}',N'{9}','{10}',N'{11}','{12}','{13}',N'{14}',{15},{16})", Me.PartID, cmbStation.SelectedValue, cmbStation.Text, cmbEquimentType.Text, EquimentName, DemandQty, Price, txtCapacity.Text.Trim(), txtFixtureNumber.Text.Trim(), txtRemark.Text.Trim(), VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Date.Now, OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu))
                Else
                    For Each dgrv As DataGridViewRow In dgvData.Rows
                        Dim StationID = dgrv.Cells("StationID").Value.ToString().Trim()
                        Dim StationName = dgrv.Cells("StationName").Value.ToString().Trim()
                        Dim EquimentType = dgrv.Cells("EquimentType").Value.ToString().Trim()
                        Dim EquimentName = ""
                        Dim DemandQty = ""
                        Dim Price = ""
                        Dim Capacity = dgrv.Cells("Capacity").Value.ToString().Trim()
                        Dim FixtureNumber = dgrv.Cells("FixtureNumber").Value.ToString().Trim()
                        Dim Remark = dgrv.Cells("Remark").Value.ToString().Trim()
                        Dim UserID = dgrv.Cells("UserID").Value.ToString()
                        Dim UserName = dgrv.Cells("UserName").Value.ToString()
                        Dim InTime = dgrv.Cells("InTime").Value.ToString()


                        Dim EquimentNameZhiJu = ""
                        Dim DemandQtyZhiJu = ""
                        Dim PriceZhiJu = ""
                        If EquimentType = "设备" Then
                            EquimentName = dgrv.Cells("EquimentName").Value.ToString().Trim()
                            DemandQty = dgrv.Cells("DemandQty").Value.ToString().Trim()
                            Price = dgrv.Cells("Price").Value.ToString().Trim()
                            Price = IIf(String.IsNullOrEmpty(Price), "0", Price)
                            DemandQtyZhiJu = "0"
                            PriceZhiJu = "0"
                        Else
                            EquimentNameZhiJu = dgrv.Cells("EquimentName").Value.ToString().Trim()
                            DemandQtyZhiJu = dgrv.Cells("DemandQty").Value.ToString().Trim()
                            PriceZhiJu = dgrv.Cells("Price").Value.ToString().Trim()
                            PriceZhiJu = IIf(String.IsNullOrEmpty(PriceZhiJu), "0", PriceZhiJu)
                            DemandQty = "0"
                            Price = "0"
                        End If
                        sql.AppendLine(String.Format(" insert into m_BOFToolListDEquiment_t " & vbCrLf &
                           "(PartID,Stationid,StationName,EquimentType,EquimentName,DemandQty,Price,Capacity,FixtureNumber,Remark,UserID,UserName,InTime,StationOrderBy,EquimentNameZhiJu,DemandQtyZhiJu,PriceZhiJu) " & vbCrLf &
                                     "values(N'{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}',N'{8}',N'{9}','{10}',N'{11}','{12}','{13}',N'{14}',{15},{16})", Me.PartID, StationID, StationName, EquimentType, EquimentName, DemandQty, Price, Capacity, FixtureNumber, Remark, UserID, UserName, InTime, OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu))
                    Next
                End If
            End If
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("提交成功")
            txtOrderBy.Value = Convert.ToInt32(DbOperateUtils.GetDataTable("select  isnull(max(OrderBy),0)+1 from  m_BOFToolListD_t where PartID=N'" & Me.PartID & "'").Rows(0)(0))
            ClearText()
            dgvData.DataSource = DbOperateUtils.GetDataTable("select * from  m_BOFToolListDEquiment_t where 1=2")

            cmbStation.SelectedIndex = -1
            If OP <> "Add" Then
                Me.Close()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "取消"
    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "暂存添加的设备数据"
    ''' <summary>
    ''' 暂存添加的设备数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            If CheckValidateData() = False Then
                Exit Sub
            End If
            Dim dt = CType(dgvData.DataSource, DataTable)
            If dt.Rows.Count > 0 Then
                If dt.Select("StationName ='" & cmbStation.Text & "'").Length = 0 Then
                    MessageUtils.ShowError("确保数据的准确性,只能暂存一个工站类型的设备数据!")
                    Exit Sub
                End If
            End If
            Dim dr = dt.NewRow()
            dr("StationID") = cmbStation.SelectedValue
            dr("StationName") = cmbStation.Text
            dr("EquimentType") = cmbEquimentType.Text
            dr("EquimentName") = txtEquimentName.Text.Trim()
            dr("DemandQty") = txtDemandQty.Text.Trim()
            dr("Price") = txtPrice.Text.Trim()
            dr("Capacity") = txtCapacity.Text.Trim()
            dr("FixtureNumber") = txtFixtureNumber.Text.Trim()
            dr("Remark") = txtRemark.Text.Trim()
            dr("UserID") = VbCommClass.VbCommClass.UseId
            dr("UserName") = VbCommClass.VbCommClass.UseName
            dr("InTime") = Date.Now
            dt.Rows.Add(dr)
            dgvData.AutoGenerateColumns = False
            dgvData.DataSource = dt
            ClearText()
        Catch ex As Exception
            MessageUtils.ShowError("暂存设备数据出现异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "清空文本"
    ''' <summary>
    ''' 清空文本
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearText()
        txtEquimentName.Text = Nothing
        txtDemandQty.Text = Nothing
        txtPrice.Text = Nothing
        txtCapacity.Text = Nothing
        txtFixtureNumber.Text = Nothing
        txtRemark.Text = Nothing
    End Sub
#End Region

#Region "设置控件不可用"
    ''' <summary>
    ''' 设置控件不可用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlIsNoEnable()
        cmbEquimentType.Enabled = False
        txtEquimentName.Enabled = False
        txtDemandQty.Enabled = False
        txtPrice.Enabled = False
        txtCapacity.Enabled = False
        txtFixtureNumber.Enabled = False
        txtRemark.Enabled = False
        BtnAdd.Enabled = False
        BtnRemove.Enabled = False
    End Sub
#End Region

#Region "工站值改变事件"
    ''' <summary>
    ''' 工站值改变事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbStation_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStation.SelectedValueChanged
        If cmbStation.SelectedIndex > 0 Then
            For Each dgvr As DataGridViewRow In dgvData.Rows
                dgvr.Cells("StationID").Value = cmbStation.SelectedValue
                dgvr.Cells("StationName").Value = cmbStation.Text
            Next
        End If
    End Sub
#End Region

#Region "移除新增的设备信息"
    ''' <summary>
    ''' 移除新增的设备信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If dgvData.Rows.Count > 0 Then
            If MessageUtils.ShowConfirm("是否要移除当前行?", MessageBoxButtons.OKCancel) = MessageBoxButtons.OK Then
                dgvData.Rows.Remove(dgvData.CurrentRow)
            End If
        End If
    End Sub
#End Region

End Class