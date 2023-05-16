Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text

Public Class FrmMJSMGK

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select * from M_EQUIPMENT_T where EquipmentNo='" + txtMouid.Text.Trim + "'")
            Dim num As Integer = 0
            If String.IsNullOrEmpty(txtMouid.Text.Trim) = True Then
                SysCheckData.MessageUtils.ShowWarning("模具编号不能为空!")
                Return
            ElseIf String.IsNullOrEmpty(txtMouidNum.Text.Trim) = True Then
                SysCheckData.MessageUtils.ShowWarning("使用次数不能为空!")
                Return
            ElseIf Integer.TryParse(txtMouidNum.Text.Trim, num) = False Then
                SysCheckData.MessageUtils.ShowWarning("使用次数必须是数字类型!")
                Return
            ElseIf Integer.Parse(txtMouidNum.Text.Trim) <= 0 Then
                SysCheckData.MessageUtils.ShowWarning("使用次数必须大于0!")
                Return
            ElseIf dt.Rows.Count = 0 Then
                SysCheckData.MessageUtils.ShowWarning("不存在模具编号:" + txtMouid.Text.Trim)
                Return
            End If


            '使用上限次数
            Dim ServiceCount As Double = Double.Parse(dt.Rows(0)("ServiceCount").ToString)
            '预警次数
            Dim AlertCount As Integer = Integer.Parse(dt.Rows(0)("AlertCount").ToString)
            '剩下次数
            Dim RemainCount As Integer = Integer.Parse(dt.Rows(0)("RemainCount").ToString)
            If ServiceCount - RemainCount + Integer.Parse(txtMouidNum.Text.Trim) > AlertCount Then
                SysCheckData.MessageUtils.ShowError("超出预警数,不可提交!")
                Return
            End If
            Dim sqlStr As StringBuilder = New StringBuilder()
            sqlStr.AppendLine("update m_Equipment_t set  RemainCount=RemainCount-" + txtMouidNum.Text.Trim + " where EquipmentNo='" + txtMouid.Text.Trim + "';")
            sqlStr.AppendLine(" insert into m_EquipmentLog_t (EquipmentNo")
            sqlStr.AppendLine(",ServiceCount")
            sqlStr.AppendLine(",AlertCount")
            sqlStr.AppendLine(",RemainCount")
            sqlStr.AppendLine(",UseNum")
            sqlStr.AppendLine(",RemainCountAfter")
            sqlStr.AppendLine(",UserID")
            sqlStr.AppendLine(",InTime")
            sqlStr.AppendLine(")")
            sqlStr.AppendLine(" values ('" & txtMouid.Text.Trim & "',")
            sqlStr.AppendLine("" & ServiceCount & "")
            sqlStr.AppendLine("," & AlertCount & "")
            sqlStr.AppendLine("," & RemainCount & "")
            sqlStr.AppendLine(",'" & txtMouidNum.Text.Trim & "'")
            sqlStr.AppendLine(",'" & (RemainCount - Integer.Parse(txtMouidNum.Text.Trim)) & "'")
            sqlStr.AppendLine(",'" & VbCommClass.VbCommClass.UseId & "'")
            sqlStr.AppendLine(",getdate()")
            sqlStr.AppendLine(")")
            DbOperateUtils.ExecSQL(sqlStr.ToString)

            SysCheckData.MessageUtils.ShowInformation("模具编号:" + txtMouid.Text.Trim + ",维护数据成功!")
            txtMouid.Text = Nothing
            txtMouidNum.Text = Nothing
            Dim frmEqu As FrmEquipment = Me.Owner
            frmEqu.LoadEquipment()
        Catch ex As Exception
            SysCheckData.MessageUtils.ShowError("提交异常:" + ex.Message)
        End Try
    End Sub
End Class