Imports System.Data.SqlClient

Public Class FrmMoveHistoryDataBack


    Private l_linkData As New MainFrame.SysDataHandle.SysDataBaseClass


    Private Sub chkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTime.CheckedChanged
        If chkTime.Checked = True Then
            DtStar.Enabled = True
            DtEnd.Enabled = True
        End If

        If chkTime.Checked = False Then
            DtStar.Enabled = False
            DtEnd.Enabled = False
        End If
    End Sub



    Private Sub FrmMoveHistoryDataBack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolMove.Click

        If chkTime.Checked = False AndAlso TxtPpid.Text = "" Then
            MessageBox.Show("时间和产品条码这两个条件必须至少选一个！！", "提示信息")
            Exit Sub
        End If

        Dim StartDT As String = ""
        Dim EndDT As String = ""
        Dim ppid As String = ""
        Dim isMovePrint As String = "N"
        Dim isMoveScan As String = "N"
        Dim isHasTime As String = "N"
        Dim strSQL As String = ""
        Dim RecDr As SqlDataReader = Nothing

        If chkTime.Checked = True Then
            StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
            EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
            isHasTime = "Y"
        End If

        If TxtPpid.Text <> "" Then
            If TxtPpid.Lines.Length > 0 Then
                Dim ii As Integer = 0
                For ii = 0 To TxtPpid.Lines.Length - 1
                    If TxtPpid.Lines(ii).ToString.Trim = "" Then
                        Continue For
                    Else
                        ppid = ppid + TxtPpid.Lines(ii).ToString.Trim + ","
                    End If
                Next
                ppid = ppid.Substring(0, ppid.Length - 1)
            End If
        Else
            ppid = "%"
        End If
        If chkPrint.Checked = True Then
            isMovePrint = "Y"
        End If
        If chkScan.Checked = True Then
            isMoveScan = "Y"
        End If
        strSQL = "declare @Movedrows int exec m_MoveHistoryData_p '" & StartDT & "','" & EndDT & "','" & isHasTime & "','" & ppid & "','" & isMovePrint & "','" & isMoveScan & "', @Movedrows output select @Movedrows"
        Try
            'RecDr = l_linkData.GetDataReader(strSQL)
            Dim dt As DataTable = l_linkData.GetDataTable(strSQL)
            'If RecDr.HasRows Then
            '    RecDr.Read()
            '    lblCount.Text = RecDr.GetString(0)
            'End If
            'RecDr.Close()
            If dt.Rows.Count > 0 Then
                lblCount.Text = dt.Rows(0)(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            TxtPpid.Clear()
            l_linkData.PubConnection.Close()
        End Try
       

    End Sub
End Class