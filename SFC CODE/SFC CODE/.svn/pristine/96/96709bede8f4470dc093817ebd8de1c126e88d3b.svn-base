Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame

Public Class FrmSelectCarton


    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrEmpty(Me.CobHWCartonID.Text) Then
            MessageUtils.ShowInformation("装箱单号不能为空!")
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmSelectCarton_Load(sender As Object, e As EventArgs) Handles Me.Load

        Call FillCombox(Me.CobHWCartonID)


    End Sub


    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Try
            ' Me.CobHWCartonID.Text

            If ColComboBox.Name = "CobHWCartonID" Then
                UserDg = DbOperateUtils.GetDataTable("SELECT DISTINCT HWCartonID  FROM m_HWPackWeight_t  WHERE state ='0' ")
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "HWCartonID"
                ColComboBox.ValueMember = "HWCartonID"
            End If
        Catch ex As Exception
            Throw ex
        Finally
            UserDg = Nothing
        End Try

    End Sub
End Class