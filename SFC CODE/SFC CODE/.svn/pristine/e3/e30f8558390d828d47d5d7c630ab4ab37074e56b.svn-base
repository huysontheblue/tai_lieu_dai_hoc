Imports MainFrame

Public Class FrmCSamplingPlanDatb
    Public g_sUpdateType, SamplingId, LowerLimit, UpperLimit, AppearanceRatio, FunctionRatio, ConfigQty, IsEnable As String
    Private Sub editName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles editName.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46)) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(46) Then
            If TextBox1.Text.Length <= 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46)) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(46) Then
            If TextBox2.Text.Length <= 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub editDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles editDesc.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim L As String = "NG"
        chek(L)
        If L = "NG" Then
            Return
        End If
        If g_sUpdateType = "APPEND" Then
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "Insert into m_QCSamplingPlanCapacityDetail_t (SamplingId,LowerLimit,UpperLimit,AppearanceRatio,FunctionRatio,ConfigQty,IsEnable,CreateUserId,CreateTime) " &
             " Values" &
            "(N'" + SamplingId + "',N'" + editName.Text.ToString.Trim() + "',N'" + editDesc.Text.Trim() + "',N'" + TextBox1.Text.Trim() + "',N'" + TextBox2.Text.Trim() + "',N'" + TextBox3.Text.Trim() + "',N'" + ComboBox1.Text.ToString + "','" + VbCommClass.VbCommClass.UseId + "',getdate())"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If MessageBox.Show("是否继续新增", "系统提示", MessageBoxButtons.YesNo).ToString = "No" Then
                Me.Close()
            Else
                editName.Text = ""
                editDesc.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                strSQL = "SELECT MAX(UpperLimit+1) AS UpperLimit FROM  m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
                dt = DbOperateUtils.GetDataTable(strSQL)
                editName.Text = dt.Rows(0)(0).ToString
                editDesc.Focus()
            End If
        Else
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "UPDATE m_QCSamplingPlanCapacityDetail_t SET AppearanceRatio = '" + TextBox1.Text + "',FunctionRatio='" + TextBox2.Text.Trim() + "',ConfigQty='" + TextBox3.Text.Trim() + "',IsEnable='" + ComboBox1.Text.Trim() + "',CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate()  WHERE SamplingId= '" + SamplingId + "' AND LowerLimit=N'" + LowerLimit + "' AND UpperLimit = N'" + UpperLimit + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            MessageBox.Show("修改成功")
            Me.Close()
        End If
    End Sub
    Private Sub chek(ByRef yy)
        If editDesc.Text.Trim = "" Then
            MessageBox.Show("产量上限范围不能为空")
            editDesc.Focus()
            Return
        End If
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("外观检验比例不能为空")
            TextBox1.Focus()
            Return
        End If
        If TextBox2.Text.Trim = "" Then
            MessageBox.Show("功能检验比例不能为空")
            TextBox2.Focus()
            Return
        End If
        If TextBox3.Text.Trim = "" Then
            MessageBox.Show("送检配置数不能为空")
            TextBox3.Focus()
            Return
        End If
        If Int32.Parse(editName.Text) - Int32.Parse(editDesc.Text) >= 0 Then
            MessageBox.Show("上限不能等于或者小于下限")
            editDesc.Focus()
            Return
        End If
        yy = "OK"
    End Sub

    Private Sub FrmCSamplingPlanDatb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If g_sUpdateType = "APPEND" Then
            Me.Text = "新增"
            editDesc.ReadOnly = False
            ComboBox1.SelectedIndex = 0
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT ISNULL(MAX(UpperLimit+1),0)AS UpperLimit FROM  m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "' "
            dt = DbOperateUtils.GetDataTable(strSQL)
            editName.Text = dt.Rows(0)(0).ToString
        Else
            Me.Text = "修改"
            A()
        End If
    End Sub
    Private Sub A()
        editName.Text = LowerLimit
        editDesc.Text = UpperLimit
        TextBox1.Text = AppearanceRatio
        TextBox2.Text = FunctionRatio
        TextBox3.Text = ConfigQty
        ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(IsEnable.ToString())
    End Sub
End Class