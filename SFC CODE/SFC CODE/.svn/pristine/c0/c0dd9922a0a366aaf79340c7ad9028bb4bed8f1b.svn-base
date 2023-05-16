Imports MainFrame

Public Class FrmCSamplingPlanData
    Public g_sUpdateType, SamplingId, SamplingName, SamplingDesc, SamplingType, MA_RejectQty, MI_RejectQty, CR_RejectQty, Remark As String
    Dim SamplingType1 As String
    
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim L As String = "NG"
        chek(L)
        If L = "NG" Then
            Return
        End If
        If ComboBox1.Text.ToString = "产量" Then
            SamplingType1 = "C"
        Else
            SamplingType1 = "N"
        End If

        If g_sUpdateType = "APPEND" Then
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT * FROM m_QCSamplingPlan_t WHERE SamplingName =N'" + editName.Text.Trim() + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("抽样计划重复，请重新输入！")
                Return
            Else
                strSQL = "Insert into m_QCSamplingPlan_t(SamplingName,SamplingDesc,SamplingType,MA_RejectQty,MI_RejectQty,CR_RejectQty,Remark,CreateUserId,CreateTime)" &
                    " Values" &
                    "(N'" + editName.Text.Trim() + "',N'" + editDesc.Text.ToString.Trim() + "',N'" + SamplingType1 + "',N'" + TextBox1.Text.Trim() + "',N'" + TextBox2.Text.Trim() + "',N'" + TextBox3.Text.Trim() + "',N'" + TextBox4.Text.Trim() + "','" + VbCommClass.VbCommClass.UseId + "',getdate())"
                dt = DbOperateUtils.GetDataTable(strSQL)
                If MessageBox.Show("是否继续新增", "系统提示", MessageBoxButtons.YesNo).ToString = "No" Then
                    Me.Close()
                End If
                editName.Text = ""
                editDesc.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                editName.Focus()
            End If
        Else
            L = "NG"
            chek(L)
            If L = "NG" Then
                Return
            End If
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "UPDATE m_QCSamplingPlan_t SET SamplingName = N'" + editName.Text.Trim() + "',SamplingDesc = N'" + editDesc.Text.ToString.Trim() + "',SamplingType = N'" + SamplingType1 + "',MA_RejectQty='" + TextBox1.Text.Trim() + "',MI_RejectQty='" + TextBox2.Text.Trim() + "',CR_RejectQty='" + TextBox3.Text.Trim() + "',Remark=N'" + TextBox4.Text.Trim() + "',CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime=getdate() WHERE SamplingId='" + SamplingId + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            MessageBox.Show("修改成功")
            Me.Close()
        End If
    End Sub
    Private Sub chek(ByRef yy)
        If editName.Text.Trim = "" Then
            MessageBox.Show("抽验计划不能为空")
            editName.Focus()
            Return
        End If
        If editDesc.Text.Trim = "" Then
            MessageBox.Show("抽验计划描述不能为空")
            editDesc.Focus()
            Return
        End If
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("主缺不能为空")
            TextBox1.Focus()
            Return
        End If
        If TextBox2.Text.Trim = "" Then
            MessageBox.Show("次缺不能为空")
            TextBox2.Focus()
            Return
        End If
        If TextBox3.Text.Trim = "" Then
            MessageBox.Show("重缺不能为空")
            TextBox3.Focus()
            Return
        End If
        yy = "OK"
    End Sub
    Private Sub A()
        editName.Text = SamplingName
        editDesc.Text = SamplingDesc
        TextBox1.Text = MA_RejectQty
        TextBox2.Text = MI_RejectQty
        TextBox3.Text = CR_RejectQty
        ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(SamplingType.ToString())
        TextBox4.Text = Remark
    End Sub
    Private Sub FrmCSamplingPlanData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If g_sUpdateType = "APPEND" Then
            Me.Text = "新增"
            ComboBox1.SelectedIndex = 0
        Else
            Me.Text = "修改"
            A()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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