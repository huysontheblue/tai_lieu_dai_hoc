Imports MainFrame
Public Class FrmSampleStdTime
    Public m_strSampleNO As String = ""
    Public m_strPartNo As String = ""

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If Not String.IsNullOrEmpty(Me.txtStdTime.Text) Then
            If Not SaveData() Then
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Function SaveData() As Boolean
        Dim lsSQL As String = String.Empty
        Try
            lsSQL = " UPDATE m_Sample_t SET  StdTime = '" & Me.txtStdTime.Text.Trim & "' Where SampleNo ='" & m_strSampleNO & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            SaveData = True
        Catch ex As Exception
            SaveData = False
        End Try
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtStdTime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStdTime.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtStdTime.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtStdTime.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub

    Private Sub FrmSampleStdTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtPartNo.Text = m_strPartNo
        Me.txtStdTime.Focus()
    End Sub
End Class