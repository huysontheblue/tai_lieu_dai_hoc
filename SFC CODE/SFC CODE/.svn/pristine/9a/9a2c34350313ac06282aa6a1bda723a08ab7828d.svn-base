Imports DBUtility
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmLaserDailyInspection_Log

    Private Sub FrmLaserDailyInspection_Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

    Private Sub DataLoad()
        Dim where = " where 1=1 "
        If (String.IsNullOrEmpty(dtpStart.Text.Trim()) = False) Then
            where = where + " and inspectionDate>='" + dtpStart.Text.Trim() + "'"
        End If
        If (String.IsNullOrEmpty(dtpEnd.Text.Trim()) = False) Then
            where = where + " and inspectionDate<='" + dtpEnd.Text.Trim() + "'"
        End If
        If (String.IsNullOrEmpty(txtMachineNumber.Text.Trim()) = False) Then
            where = where + " and MachineNumber like'%" + txtMachineNumber.Text.Trim() + "%'"
        End If
        If (String.IsNullOrEmpty(txtModelNumber.Text.Trim()) = False) Then
            where = where + " and ModelNumber like '%" + txtModelNumber.Text.Trim() + "%'"
        End If
        Dim sql = "select * from m_LaserDailyInspection_Log_t" & where
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = dt
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        dtpStart.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        dtpEnd.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class