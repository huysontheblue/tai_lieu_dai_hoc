Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmSNCheckSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub BnConFrm_Click(sender As Object, e As EventArgs) Handles BnConFrm.Click
       If (String.IsNullOrEmpty(Me.txtMO.Text)) Then
            MessageBox.Show("工單編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMO.Focus()
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.txtPart.Text)) Then
            MessageBox.Show("料件編號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMO.Focus()
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.CobLine.Text)) Then
            MessageBox.Show("線別不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMO.Focus()
            Exit Sub
        End If
        WorkStantOption.MoidStr = txtMO.Text.ToUpper.Trim
        WorkStantOption.LineStr = CobLine.Text
        WorkStantOption.PartidStr = txtPart.Text.ToUpper.Trim
        Me.Close()
    End Sub

    Private Sub FrmSNCheckSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub LoadData()
        Dim lsSQL As String = String.Empty
        lsSQL = " select distinct lineid from Deptline_t where factoryid='" & VbCommClass.VbCommClass.Factory & "'  and usey='Y' order by lineid"
        LoadDataToCob(lsSQL, CobLine)
    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0))
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub
End Class