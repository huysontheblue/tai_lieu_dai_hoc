Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmStandardJobSchedulingAddDetails

    ''' <summary>
    ''' 表头ID
    ''' </summary>
    ''' <remarks></remarks>
    Public MainID As String

    ''' <summary>
    ''' 表身ID标识
    ''' </summary>
    ''' <remarks></remarks>
    Public DetailID As String

    ''' <summary>
    ''' 操作类型
    ''' </summary>
    ''' <remarks></remarks>
    Public OP As String

    ''' <summary>
    ''' 被选中行的工序
    ''' </summary>
    ''' <remarks></remarks>
    Public OrderBy As String

    ''' <summary>
    ''' 做插入动作的时候要插入工站类型
    ''' </summary>
    ''' <remarks></remarks>
    Public StationType As String
    Public m_IniSumStdHours As Double = 0
    Public m_IniPerson As Double = 1


#Region "窗体加载事件"
    Private Sub FrmStandardJobSchedulingAddDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataBindStationType()
        'DataBindStation()
        If OP = "Edit" Then
            Me.Text = "修改工站"
            Dim sql = "select * from dbo.m_ProductStandardAllocationD_t where id=" + DetailID
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                If Val(dt.Rows(0)("BalancePerson").ToString()) <= 0 Then
                    m_IniPerson = 1
                Else
                    m_IniPerson = Val(dt.Rows(0)("BalancePerson").ToString())
                End If
                m_IniSumStdHours = Val(dt.Rows(0)("BalanceHours").ToString()) * m_IniPerson
                cmbStationType.SelectedValue = dt.Rows(0)("StationType").ToString()
                txtOrderBy.Text = dt.Rows(0)("OrderBy").ToString()
                txtStationName.Text = dt.Rows(0)("StationName").ToString()
                txtSWorkingHours.Text = dt.Rows(0)("SWorkingHours").ToString()
                txtUndulationTime.Text = dt.Rows(0)("UndulationTime").ToString()
                txtOutPut.Text = dt.Rows(0)("OutPut").ToString()
                txtEquiment.Text = dt.Rows(0)("Equiment").ToString()
                txtQty.Text = dt.Rows(0)("Qty").ToString()
                txtBalancePerson.Text = dt.Rows(0)("BalancePerson").ToString()
                txtBalanceHours.Text = dt.Rows(0)("BalanceHours").ToString()
                txtBalanceQty.Text = dt.Rows(0)("BalanceQty").ToString()
                txtRemark.Text = dt.Rows(0)("Remark").ToString()
            End If
        ElseIf OP = "Insert" Then '插入工站
            Me.Text = "插入工站"
            cmbStationType.SelectedValue = Me.StationType
            cmbStationType.Enabled = False
            txtOrderBy.Enabled = False
            txtOrderBy.Text = Me.OrderBy
        ElseIf OP = "Add" Then
            txtOrderBy.Enabled = False
        End If
    End Sub
#End Region

    '#Region "绑定工站"
    '    ''' <summary>
    '    ''' 绑定工站
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub DataBindStation()
    '        Dim sql = "select a.Stationid,a.Stationname+'-'+b.SortName as Stationname " & vbCrLf &
    '        "from m_Rstation_t a" & vbCrLf &
    '        "Join" & vbCrLf &
    '        "(" & vbCrLf &
    '        "select * from m_Sortset_t where SortType = 'StationType' and Usey='Y'	" & vbCrLf &
    '        ")  b on b.SortID=a.Stationtype" & vbCrLf &
    '        "where a.Stationtype in('R','U','H') and a.usey='Y'"
    '        cmbStationName.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    '        cmbStationName.ValueMember = "Stationid"
    '        cmbStationName.DisplayMember = "Stationname"
    '        cmbStationName.SelectedIndex = -1
    '    End Sub
    '#End Region

#Region "绑定工站类型"
    ''' <summary>
    ''' 绑定工站类型
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataBindStationType()
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add(New DataColumn("ID"))
        dt.Columns.Add(New DataColumn("Name"))
        Dim dr As DataRow = dt.NewRow()
        dr("ID") = "R"
        dr("Name") = "流程工站"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("ID") = "U"
        dr("Name") = "线外工站"
        dt.Rows.Add(dr)
        cmbStationType.DataSource = dt
        cmbStationType.ValueMember = "ID"
        cmbStationType.DisplayMember = "Name"
        cmbStationType.SelectedIndex = 0
    End Sub
#End Region

#Region "获取流程工站的最大工序"
    ''' <summary>
    ''' 获取流程工站的最大工序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMaxOrderByR() As String
        Dim yy = ""
        Dim sql = "select isnull(max(cast(OrderBy as int)),0)+1 from m_ProductStandardAllocationD_t " & vbCrLf &
        "where MainID = " + MainID + "  and StationType='R'"
        yy = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        Return yy
    End Function
#End Region

#Region "获取线外工站的最大工序"
    ''' <summary>
    ''' 获取线外工站的最大工序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMaxOrderByU() As String
        Dim yy = ""
        Dim sql = "select '0-'+cast(isnull(max(cast(replace(OrderBy,'0-','') as int )),0)+1 as varchar) from m_ProductStandardAllocationD_t" & vbCrLf &
        "where MainID =" & MainID & "  and StationType='U'"
        yy = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        Return yy
    End Function
#End Region

#Region "验证数据的有效性"
    ''' <summary>
    ''' 验证数据的有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DataIsValidated() As Boolean
        Dim yy = True
        Dim a As Integer = 0
        Dim b As Double = 0
        If String.IsNullOrEmpty(txtStationName.Text.Trim()) = True Then
            MessageUtils.ShowError("请选择一个工站!")
            yy = False
        ElseIf cmbStationType.SelectedValue.ToString() = "R" And Integer.TryParse(txtOrderBy.Text.Trim(), a) <= 0 = False Then
            MessageUtils.ShowError("流程工站序号是非法的,请输入有效工序!")
            yy = False
        ElseIf cmbStationType.SelectedValue.ToString() = "U" And Integer.TryParse(txtOrderBy.Text.Trim().Replace("0-", ""), a) <= 0 = False Then
            MessageUtils.ShowError("线外工站序号是非法的,请输入有效工序!")
            yy = False
        ElseIf String.IsNullOrEmpty(txtSWorkingHours.Text.Trim()) Then
            MessageUtils.ShowError("请填写标准工时!")
            yy = False
        ElseIf Double.TryParse(txtSWorkingHours.Text.Trim(), b) = False Then
            MessageUtils.ShowError("标准工时只能是数字类型")
            yy = False
            'ElseIf String.IsNullOrEmpty(txtUndulationTime.Text.Trim()) And cmbStationType.SelectedValue = "R" Then
            '    MessageUtils.ShowError("请填写波动时间!")
            '    yy = False
        ElseIf String.IsNullOrEmpty(txtOutPut.Text.Trim()) Then
            MessageUtils.ShowError("请填写产量!")
            yy = False
        ElseIf String.IsNullOrEmpty(txtBalancePerson.Text.Trim()) Then
            MessageUtils.ShowError("请填写平衡人力!")
            yy = False
        ElseIf Double.TryParse(txtBalancePerson.Text.Trim(), b) = True Then
            If Double.Parse(txtBalancePerson.Text.Trim()) < 0 Then
                MessageUtils.ShowError("平衡人力只能大于或者等于0")
                yy = False
            End If
            If Double.Parse(txtBalancePerson.Text.Trim()) < 1 And Double.Parse(txtBalancePerson.Text.Trim()) > 0 Then
                If txtBalancePerson.Text.Trim() <> "0.5" Then
                    MessageUtils.ShowError("平衡人力输入小于1的数字只能输入0.5")
                    yy = False
                End If
            End If
        ElseIf String.IsNullOrEmpty(txtBalanceHours.Text.Trim()) Then
            MessageUtils.ShowError("请填写平衡工时!")
            yy = False
        ElseIf String.IsNullOrEmpty(txtBalanceQty.Text.Trim()) Then
            MessageUtils.ShowError("请填写平衡产量!")
            yy = False
        End If
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
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Try

            If DataIsValidated() = False Then
                Exit Sub
            End If

            Dim StationType = cmbStationType.SelectedValue.ToString()
            Dim OrderBy = txtOrderBy.Text.Trim()

            'Dim StationID = cmbStationName.SelectedValue.ToString()
            Dim StationName = txtStationName.Text.Trim()
            Dim SWorkingHours = txtSWorkingHours.Text.Trim()
            Dim UndulationTime = txtUndulationTime.Text.Trim()
            Dim OutPut = txtOutPut.Text.Trim()
            Dim Equiment = txtEquiment.Text.Trim()
            Dim Qty = txtQty.Text.Trim()
            Dim BalancePerson = txtBalancePerson.Text.Trim()
            Dim BalanceHours = txtBalanceHours.Text.Trim()
            Dim BalanceQty = txtBalanceQty.Text.Trim()
            Dim Remark = txtRemark.Text.Trim()

            SWorkingHours = IIf(String.IsNullOrEmpty(SWorkingHours), "null", "" & SWorkingHours & "")
            UndulationTime = IIf(String.IsNullOrEmpty(UndulationTime), "null", "" & UndulationTime & "")
            OutPut = IIf(String.IsNullOrEmpty(OutPut), "null", "" & OutPut & "")
            Qty = IIf(String.IsNullOrEmpty(Qty), "null", "" & Qty & "")
            BalancePerson = IIf(String.IsNullOrEmpty(BalancePerson) Or BalancePerson = "0" Or BalancePerson = "0.0", "null", "" & BalancePerson & "")
            BalanceHours = IIf(String.IsNullOrEmpty(BalanceHours), "null", "" & BalanceHours & "")
            BalanceQty = IIf(String.IsNullOrEmpty(BalanceQty), "null", "" & BalanceQty & "")
            Dim UserID = VbCommClass.VbCommClass.UseId
            Dim UserName = VbCommClass.VbCommClass.UseName
            Dim sql = New System.Text.StringBuilder()
            If OP = "Add" Then
                sql.AppendLine("insert into m_ProductStandardAllocationD_t ")
                sql.AppendLine("(MainID,OrderBy,StationType,StationName,SWorkingHours" & vbCrLf &
                ",UndulationTime,OutPut,Equiment,Qty,BalancePerson,BalanceHours,BalanceQty" & vbCrLf &
                ",Remark,InTime,EmpNo,EmpName) values ( " & vbCrLf &
                "" & MainID & ",'" & OrderBy & "','" & StationType & "'" & vbCrLf &
                ",N'" & StationName & "'," & SWorkingHours & "," & UndulationTime & "" & vbCrLf &
                "," & OutPut & ",N'" & Equiment & "'," & Qty & "," & BalancePerson & "" & vbCrLf &
                "," & BalanceHours & "," & BalanceQty & ",N'" & Remark & "'" & vbCrLf &
                ",getdate(),'" & UserID & "',N'" & UserName & "')")
            ElseIf OP = "Edit" Then

                sql.AppendLine("exec Proc_ModifyProductStandardAllocationD 'Edit'," & MainID & "," & DetailID & ",'" & Me.StationType & "','" & Me.OrderBy & "','" & StationType & "','" & OrderBy & "','" & UserID & "',N'" & UserName & "'")

                sql.AppendLine("update m_ProductStandardAllocationD_t ")
                'sql.AppendLine("set StationID='" & StationID & "'")
                sql.AppendLine("set OrderBy='" & txtOrderBy.Text.Trim() & "'")
                sql.AppendLine(",StationType='" & StationType & "'")
                sql.AppendLine(",StationName=N'" & StationName & "'")
                sql.AppendLine(",SWorkingHours=" & SWorkingHours & "")
                sql.AppendLine(",UndulationTime=" & UndulationTime & "")
                sql.AppendLine(",OutPut=" & OutPut & "")
                sql.AppendLine(",Equiment=N'" & Equiment & "'")
                sql.AppendLine(",Qty=" & Qty & "")
                sql.AppendLine(",BalancePerson=" & BalancePerson & "")
                sql.AppendLine(",BalanceHours=" & BalanceHours & "")
                sql.AppendLine(",BalanceQty=" & BalanceQty & "")
                sql.AppendLine(",Remark=N'" & Remark & "'")
                sql.AppendLine(",InTime=getdate()")
                sql.AppendLine(",EmpNo='" & UserID & "'")
                sql.AppendLine(",EmpName=N'" & UserName & "' ")
                sql.AppendLine(" where id=" + DetailID)
            ElseIf OP = "Insert" Then
                sql.AppendLine("exec Proc_ModifyProductStandardAllocationD 'Insert'," & MainID & "," & DetailID & ",'" & StationType & "','" & Me.OrderBy & "','','','" & UserID & "',N'" & UserName & "'")

                sql.AppendLine("insert into m_ProductStandardAllocationD_t ")
                sql.AppendLine("(MainID,OrderBy,StationType,StationName,SWorkingHours" & vbCrLf &
                ",UndulationTime,OutPut,Equiment,Qty,BalancePerson,BalanceHours,BalanceQty" & vbCrLf &
                ",Remark,InTime,EmpNo,EmpName) values ( " & vbCrLf &
                "" & MainID & ",'" & Me.OrderBy & "','" & StationType & "' " & vbCrLf &
                ",N'" & StationName & "'," & SWorkingHours & "," & UndulationTime & "" & vbCrLf &
                "," & OutPut & ",N'" & Equiment & "'," & Qty & "," & BalancePerson & "" & vbCrLf &
                "," & BalanceHours & "," & BalanceQty & ",N'" & Remark & "'" & vbCrLf &
                ",getdate(),'" & UserID & "',N'" & UserName & "')")
            End If
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("提交成功!")
            If OP <> "Add" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            ElseIf OP = "Add" Then
                cmbStationType_SelectedValueChanged(Nothing, Nothing)
                ClearText()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("提交发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "新增一笔数据后清空文本"
    ''' <summary>
    ''' 新增一笔数据后清空文本
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearText()
        cmbStationType.SelectedIndex = 0
        txtStationName.Text = Nothing
        txtSWorkingHours.Text = Nothing
        txtUndulationTime.Text = Nothing
        txtOutPut.Text = Nothing
        txtEquiment.Text = Nothing
        txtQty.Text = Nothing
        txtBalancePerson.Text = Nothing
        txtBalanceHours.Text = Nothing
        txtBalanceQty.Text = Nothing
        txtRemark.Text = Nothing
    End Sub
#End Region


    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

#Region "输入标准工时计算"
    ''' <summary>
    ''' 输入标准工时计算
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSWorkingHours_TextChanged(sender As Object, e As EventArgs) Handles txtSWorkingHours.TextChanged
        '2019-12-14增加标准工时为0.0的异常Try起来
        Try
            Dim o_BalancePer As Double
            If String.IsNullOrEmpty(txtSWorkingHours.Text.Trim()) = False Then
                txtOutPut.Text = Convert.ToInt32(3600 / Double.Parse(txtSWorkingHours.Text.Trim()))
                If String.IsNullOrEmpty(txtBalancePerson.Text.Trim()) = False Then
                    Double.TryParse(txtBalancePerson.Text.Trim(), o_BalancePer)
                    txtBalanceHours.Text = Double.Parse(txtSWorkingHours.Text.Trim()) / o_BalancePer    'Integer.Parse(txtBalancePerson.Text.Trim())
                Else
                    txtBalanceHours.Text = Nothing
                End If
            Else
                txtOutPut.Text = Nothing
            End If
        Catch
        End Try
    End Sub
#End Region


#Region "通过平衡工时计算平衡产量"
    ''' <summary>
    ''' 通过平衡工时计算平衡产量
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtBalanceHours_TextChanged(sender As Object, e As EventArgs) Handles txtBalanceHours.TextChanged
        '2019-12-14增加标准工时为0.0的异常Try起来
        Try
            If String.IsNullOrEmpty(txtBalanceHours.Text.Trim()) = False Then
                txtBalanceQty.Text = String.Format("{0:0.0}", Convert.ToInt32(3600 / Double.Parse(txtBalanceHours.Text.Trim())))
                'String.Format("{0:0.0}", Convert.ToInt32(3600 / Double.Parse(txtBalanceHours.Text.Trim())))
            Else
                txtBalanceQty.Text = Nothing
            End If
        Catch
        End Try
    End Sub
#End Region


#Region "通过平衡人力计算平衡工时"
    ''' <summary>
    ''' 通过平衡人力计算平衡工时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtBalancePerson_TextChanged(sender As Object, e As EventArgs) Handles txtBalancePerson.TextChanged
        If String.IsNullOrEmpty(txtSWorkingHours.Text.Trim()) = False And String.IsNullOrEmpty(txtBalancePerson.Text.Trim()) = False Then
            Dim o_strSumBalanceHours As Double = 0

            If txtBalancePerson.Text.Trim() <> "0" And txtBalancePerson.Text.Trim() <> "0.0" And (Not String.IsNullOrEmpty(txtBalanceHours.Text)) Then
                If m_IniSumStdHours > 0 Then
                    txtBalanceHours.Text = String.Format("{0:0.0}", m_IniSumStdHours / Convert.ToDouble(txtBalancePerson.Text.Trim()))
                Else
                    txtBalanceHours.Text = String.Format("{0:0.0}", Double.Parse(txtSWorkingHours.Text.Trim()) / Convert.ToDouble(txtBalancePerson.Text.Trim()))
                End If
                'txtBalanceHours.Text = String.Format("{0:0.0}", Double.Parse(txtBalanceHours.Text.Trim()) / Convert.ToDouble(txtBalancePerson.Text.Trim()))
                'String.Format("{0:0.0}", Double.Parse(txtSWorkingHours.Text.Trim()) / Convert.ToDouble(txtBalancePerson.Text.Trim()))
            Else
                txtBalanceHours.Text = Nothing
            End If
        Else
            txtBalanceHours.Text = Nothing
        End If
    End Sub
#End Region


#Region "编辑的时候变更工站类型计算最大工序"
    ''' <summary>
    ''' 编辑的时候变更工站类型计算最大工序
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbStationType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStationType.SelectedValueChanged
        Dim SelectedValue = cmbStationType.SelectedValue.ToString()
        If OP = "Add" Then
            txtOrderBy.Text = IIf(SelectedValue = "R", GetMaxOrderByR(), GetMaxOrderByU())
        ElseIf OP = "Edit" Then
            If Me.StationType = SelectedValue Then
                txtOrderBy.Text = Me.OrderBy
            Else
                txtOrderBy.Text = IIf(SelectedValue = "R", GetMaxOrderByR(), GetMaxOrderByU())
            End If
        End If
    End Sub
#End Region

End Class