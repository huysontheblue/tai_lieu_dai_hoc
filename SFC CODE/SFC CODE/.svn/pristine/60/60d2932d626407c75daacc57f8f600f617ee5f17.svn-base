Public Class FrmCopyPeiZhi
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        Try
            If String.IsNullOrEmpty(txtNewPartID.Text.Trim()) Then
                MainFrame.SysCheckData.MessageUtils.ShowError("请输入新料号!")
                Exit Sub
            End If
            Dim PartID = txtNewPartID.Text.Trim()
            Dim sql As System.Text.StringBuilder = New System.Text.StringBuilder()
            sql.AppendLine("delete m_EMCEquipmentconfig_t where PartID='" & PartID & "'")
            sql.AppendLine("insert into m_EMCEquipmentconfig_t select '" & PartID & "',[NO],[StationName]" & vbCrLf &
            ",[EquimentName],[EquimentNO],[EmpCode],[EmpName],[JobName],[ApplicationDate],[ExpirationDate]" & vbCrLf &
            ",[Status] from m_EMCEquipmentconfig_t where PartID='" & txtOldPartID.Text.Trim() & "'")
            MainFrame.DbOperateUtils.ExecSQL(sql.ToString())
            MainFrame.SysCheckData.MessageUtils.ShowInformation("复制成功!")
            Me.Close()
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError("复制失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
End Class