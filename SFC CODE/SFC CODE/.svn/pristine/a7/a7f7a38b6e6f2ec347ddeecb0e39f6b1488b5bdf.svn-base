#Region "Imports"
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.IO

#End Region

Public Class FrmEditTime

#Region "公用变量"

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim Flag As Boolean
    Dim Datet As New DateTime

#End Region

#Region "方法"

    Private Sub BnConFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnConFrm.Click
        If Me.DtpTime.Value.ToString <> "" Then
            If -1080 > DateDiff(DateInterval.Day, Datet, Me.DtpTime.Value) OrElse DateDiff(DateInterval.Day, Datet, Me.DtpTime.Value) > 1080 Then
                MessageBox.Show("設置的時間不得偏離當前時間三年!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Flag = False
                Exit Sub
            Else
                SampleCom.SqlClassD.UpdateTime = Me.DtpTime.Value.ToString
                Flag = True
            End If
        End If
        Me.Close()
    End Sub

    Private Sub FrmEditTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Flag = True Then
        ElseIf Flag = False Then
            SampleCom.SqlClassD.UpdateTime = ""
        End If
        e.Cancel = False
    End Sub

    Private Sub FrmEditTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecTable As New DataTable

        Dim Sqlstr As String

        Sqlstr = "select getdate() as Datet"
        RecTable = Conn.GetDataTable(Sqlstr)
        Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
        RecTable.Dispose()

        Me.DtpTime.Value = Datet.AddHours(-7.5).Date
    End Sub

    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnBack.Click
        Me.Close()
    End Sub

#End Region

End Class