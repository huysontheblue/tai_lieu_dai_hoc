Imports MainFrame
Imports MainFrame.SysCheckData


Public Class FrmAddBOFToolListEquiment

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        cmbEquimentType.SelectedIndex = 0
    End Sub

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

    Private _Stationid As String
    ''' <summary>
    ''' 工站编号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Stationid() As String
        Get
            Return _Stationid
        End Get
        Set(ByVal value As String)
            _Stationid = value
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

    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Private _OrderBy As String
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property


#Region "窗体加载事件"
    Private Sub FrmAddBOFToolListEquiment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OP = "Modify" Then
            Dim sql = String.Format("select * from V_m_BOFToolListDEquiment_t" & vbCrLf &
            "where id={0}", ID)
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                cmbEquimentType.Text = dt.Rows(0)("EquimentType").ToString()
                txtEquimentName.Text = dt.Rows(0)("EquimentName").ToString()
                txtDemandQty.Text = dt.Rows(0)("DemandQty").ToString()
                txtPrice.Text = dt.Rows(0)("Price").ToString()
                txtCapacity.Text = dt.Rows(0)("Capacity").ToString()
                txtFixtureNumber.Text = dt.Rows(0)("FixtureNumber").ToString()
                txtRemark.Text = dt.Rows(0)("Remark").ToString()
            End If
        ElseIf OP = "Add" Then
            Me.Text = "新增设备&工治具资料"
        End If
    End Sub
#End Region

#Region "验证数据有效性"
    ''' <summary>
    ''' 验证数据有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CheckIsValite() As Boolean
        Dim yy = True
        Dim num As Integer = 0
        Dim num1 As Double = 0
        Try
            If String.IsNullOrEmpty(txtEquimentName.Text.Trim()) Then
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
            ElseIf  String.IsNullOrEmpty(txtPrice.Text.Trim()) = False Then
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
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim sql = New System.Text.StringBuilder()
        If CheckIsValite() = False Then
            Exit Sub
        End If
        Try

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

            If OP = "Add" Then
                sql.AppendLine(String.Format(" insert into m_BOFToolListDEquiment_t " & vbCrLf & "(PartID,Stationid,StationName,EquimentType,EquimentName,DemandQty,Price,Capacity,FixtureNumber,Remark,UserID,UserName,InTime,StationOrderBy,EquimentNameZhiJu,DemandQtyZhiJu,PriceZhiJu,BOFVersion) " & vbCrLf &
                    "VALUES(N'{0}','{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}',N'{8}',N'{9}','{10}',N'{11}','{12}','{13}',N'{14}',{15},{16},'{17}')", Me.PartID, Me.Stationid, Me.txtStationName.Text, cmbEquimentType.Text, EquimentName, DemandQty, Price, txtCapacity.Text.Trim(), txtFixtureNumber.Text.Trim(), txtRemark.Text.Trim(), VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Date.Now, OrderBy, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu, BOFVersion))

            Else
                Dim dr = DbOperateUtils.GetDataTable("select * from V_m_BOFToolListDEquiment_t where id=" + ID).Rows(0)
                If dr("EquimentName").ToString().Trim() <> txtEquimentName.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
                "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
                "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "设备/治具名称", dr("UserName").ToString(), dr("InTime").ToString(), dr("EquimentName").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtEquimentName.Text.Trim(), Me.txtStationName.Text.Trim(), dr("EquimentName").ToString().Trim(), Me.OrderBy))
                End If
                If dr("DemandQty").ToString().Trim() <> txtDemandQty.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
            "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
            "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "需求数量", dr("UserName").ToString(), dr("InTime").ToString(), dr("DemandQty").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtDemandQty.Text.Trim(), Me.txtStationName.Text.Trim(), txtEquimentName.Text.Trim(), Me.OrderBy))
                End If
                If dr("Price").ToString().Trim() <> txtPrice.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
          "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
          "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "价格", dr("UserName").ToString(), dr("InTime").ToString(), dr("Price").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtPrice.Text.Trim(), Me.txtStationName.Text.Trim(), txtEquimentName.Text.Trim(), Me.OrderBy))
                End If
                If dr("Capacity").ToString().Trim() <> txtCapacity.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
         "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
         "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "产能", dr("UserName").ToString(), dr("InTime").ToString(), dr("Capacity").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtCapacity.Text.Trim(), Me.txtStationName.Text.Trim(), txtEquimentName.Text.Trim(), Me.OrderBy))
                End If
                If dr("FixtureNumber").ToString().Trim() <> txtFixtureNumber.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
      "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
      "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "治具料号", dr("UserName").ToString(), dr("InTime").ToString(), dr("FixtureNumber").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtFixtureNumber.Text.Trim(), Me.txtStationName.Text, txtEquimentName.Text.Trim(), Me.OrderBy))
                End If
                If dr("Remark").ToString().Trim() <> txtRemark.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
    "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
    "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", Me.PartID, "备注", dr("UserName").ToString(), dr("InTime").ToString(), dr("Remark").ToString().Trim(), VbCommClass.VbCommClass.UseName, Date.Now, txtRemark.Text.Trim(), Me.txtStationName.Text.Trim(), txtEquimentName.Text.Trim(), Me.OrderBy))
                End If
                sql.AppendLine(String.Format("update m_BOFToolListDEquiment_t" & vbCrLf &
            "set EquimentType=N'{1}',EquimentName=N'{2}',DemandQty={3},Price={4}," & vbCrLf &
            "Capacity=N'{5}',FixtureNumber=N'{6}',Remark=N'{7}',UserID='{8}',UserName=N'{9}',InTime='{10}',EquimentNameZhiJu=N'{11}',DemandQtyZhiJu={12} ,PriceZhiJu={13} where ID={0}",
            ID, cmbEquimentType.Text, EquimentName,
            DemandQty, Price, txtCapacity.Text.Trim(),
            txtFixtureNumber.Text.Trim(), txtRemark.Text.Trim(), VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, Date.Now, EquimentNameZhiJu, DemandQtyZhiJu, PriceZhiJu))
            End If

            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("提交成功!")

            If OP <> "Add" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            ElseIf OP = "Add" Then
                ClearText()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ClearText()
        txtEquimentName.Text = Nothing
        txtDemandQty.Text = Nothing
        txtPrice.Text = Nothing
        txtCapacity.Text = Nothing
        txtFixtureNumber.Text = Nothing
        txtRemark.Text = Nothing
    End Sub

#Region "设备/治具 SelectedValueChanged事件"
    ''' <summary>
    ''' 设备/治具 SelectedValueChanged事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbEquimentType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEquimentType.SelectedValueChanged
        If cmbEquimentType.Text = "设备" Then
            txtFixtureNumber.Text = Nothing
            txtFixtureNumber.ReadOnly = True
        Else
            txtFixtureNumber.ReadOnly = False
        End If
    End Sub
#End Region

End Class