Imports MainFrame

Public Class FrmCSamplingPlanDate
    Public g_sUpdateType, SamplingId, ConfigQty, ConfigUnit, FuncQCRatio, ContinBatchQty, RejectBatchQty, IsDefault, CheckLevel, NextCheckLevel As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim L As String = "NG"
        chek(L)
        If L = "NG" Then
            Return
        End If
        If g_sUpdateType = "APPEND" Then
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT * FROM m_QCSamplingPlanDetail_t WHERE SamplingId= '" + SamplingId + "' AND CheckLevel=N'" + ComboBox3.Text.ToString + "' AND NextCheckLevel = N'" + ComboBox4.Text.ToString + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("抽验计划明细重复，请重新输入！")
                Return
            Else
                If ComboBox2.Text.ToString = "Y" Then
                    strSQL = "UPDATE m_QCSamplingPlanDetail_t SET IsDefault = 'N' ,CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate() WHERE SamplingId= '" + SamplingId + "'"
                    dt = DbOperateUtils.GetDataTable(strSQL)
                End If
                strSQL = "Insert into m_QCSamplingPlanDetail_t(SamplingId,ConfigQty,ConfigUnit,FuncQCRatio,ContinBatchQty,RejectBatchQty,IsDefault,CheckLevel,NextCheckLevel,CreateUserId,CreateTime) " &
                " Values" &
                "(N'" + SamplingId + "',N'" + editName.Text.ToString.Trim() + "',N'" + ComboBox1.Text.Trim() + "',N'" + TextBox1.Text.Trim() + "',N'" + TextBox2.Text.Trim() + "',N'" + TextBox3.Text.Trim() + "',N'" + ComboBox2.Text.Trim() + "',N'" + ComboBox3.Text.Trim() + "',N'" + ComboBox4.Text.Trim() + "','" + VbCommClass.VbCommClass.UseId + "',getdate())"
                dt = DbOperateUtils.GetDataTable(strSQL)
                If MessageBox.Show("是否继续新增", "系统提示", MessageBoxButtons.YesNo).ToString = "No" Then
                    Me.Close()
                Else
                    editName.Text = ""
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    editName.Focus()
                End If
            End If
        Else
            'L = "NG"
            'chek(L)
            'If L = "NG" Then
            '    Return
            'End If
            Dim strSQL As String
            Dim dt As DataTable
            If ComboBox3.Text.ToString <> CheckLevel OrElse ComboBox4.Text.ToString <> NextCheckLevel Then
                strSQL = "SELECT * FROM m_QCSamplingPlanDetail_t WHERE SamplingId= '" + SamplingId + "' AND CheckLevel=N'" + ComboBox3.Text.ToString + "' AND NextCheckLevel = N'" + ComboBox4.Text.ToString + "'"
                dt = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("抽验计划明细重复，请重新输入！")
                    Return
                End If
            End If
            If ComboBox2.Text.ToString = "Y" Then
                strSQL = "UPDATE m_QCSamplingPlanDetail_t SET IsDefault = 'N' ,CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate() WHERE SamplingId= '" + SamplingId + "'"
                dt = DbOperateUtils.GetDataTable(strSQL)
            End If
            strSQL = "UPDATE m_QCSamplingPlanDetail_t SET ConfigQty = '" + editName.Text + "',ConfigUnit='" + ComboBox1.Text.Trim() + "',FuncQCRatio='" + TextBox1.Text.Trim() + "',ContinBatchQty='" + TextBox2.Text.Trim() + "',RejectBatchQty='" + TextBox3.Text.Trim() + "',IsDefault='" + ComboBox2.Text.Trim() + "',CheckLevel=N'" + ComboBox3.Text.Trim() + "',NextCheckLevel=N'" + ComboBox4.Text.Trim() + "',CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate()  WHERE SamplingId= '" + SamplingId + "' AND CheckLevel=N'" + CheckLevel + "' AND NextCheckLevel = N'" + NextCheckLevel + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            MessageBox.Show("修改成功")
            Me.Close()
            End If
    End Sub
    Private Sub chek(ByRef yy)
        If editName.Text.Trim = "" Then
            MessageBox.Show("配置数不能为空")
            editName.Focus()
            Return
        End If
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("功能检验比例不能为空")
            TextBox1.Focus()
            Return
        End If
        If TextBox2.Text.Trim = "" Then
            MessageBox.Show("连续检验批不能为空")
            TextBox2.Focus()
            Return
        End If
        If TextBox3.Text.Trim = "" Then
            MessageBox.Show("批次批退标准不能为空")
            TextBox3.Focus()
            Return
        End If
        If ComboBox3.Text.ToString() = ComboBox4.Text.ToString() Then
            MessageBox.Show("当前检验程度不能和下一检验程度相同")
            ComboBox3.Focus()
            Return
        End If
        If ComboBox3.Text.ToString() = "减量" AndAlso ComboBox4.Text.ToString() <> "正常" Then
            MessageBox.Show("当前检验程度减量下一检验程度只能选择正常，请重选选择！")
            ComboBox4.Focus()
            Return
        End If
        If ComboBox3.Text.ToString() = "加严" AndAlso ComboBox4.Text.ToString() <> "正常" Then
            MessageBox.Show("当前检验程度加严下一检验程度只能选择正常，请重选选择！")
            ComboBox4.Focus()
            Return
        End If
        yy = "OK"
    End Sub

    Private Sub FrmCSamplingPlanDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If g_sUpdateType = "APPEND" Then
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0
            ComboBox3.SelectedIndex = 0
            ComboBox4.SelectedIndex = 0
            Me.Text = "新增"
        Else
            Me.Text = "修改"
            A()
        End If
       
    End Sub
    Private Sub A()
        editName.Text = ConfigQty
        ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(ConfigUnit.ToString())
        TextBox1.Text = FuncQCRatio
        TextBox2.Text = ContinBatchQty
        TextBox3.Text = RejectBatchQty
        ComboBox2.SelectedIndex = ComboBox2.Items.IndexOf(IsDefault.ToString())
        ComboBox3.SelectedIndex = ComboBox3.Items.IndexOf(CheckLevel.ToString())
        ComboBox4.SelectedIndex = ComboBox4.Items.IndexOf(NextCheckLevel.ToString())
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub editName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles editName.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (Not (Char.IsNumber(e.KeyChar)) AndAlso e.KeyChar <> ChrW(8)) Then
            e.Handled = True
        End If
    End Sub
End Class