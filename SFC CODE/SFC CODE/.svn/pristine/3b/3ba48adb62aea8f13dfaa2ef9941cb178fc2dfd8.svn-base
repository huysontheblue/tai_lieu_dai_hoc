Imports System.Data.SqlClient

Public Class FrmFWModify
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Public opflag As Int16 = 0
    Private Sub FrmFWModify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String
        Dim dt As DataTable
        strSql = "select distinct Ppartid 料件编码,Stationid 站点编号,IsFWCheck 是否校验峰位,FWCheckValue 峰位值 from m_RPartStationD_t where State=1"
        Try
            Dim ds As DataSet = Conn.GetDataSet(strSql)
            dt = ds.Tables(0)
            dgvRstation.DataSource = dt
            dt.Dispose()
            Conn.PubConnection.Close()
        Catch ex As Exception
            Conn.PubConnection.Close()
        End Try
    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        '编辑选中的行
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        cobPpart.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        cobStation.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtFWValue.Text = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        ChkFW.Checked = IIf(Me.dgvRstation.Item(2, dgvRstation.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.cobPpart.Enabled = False
        cobStation.Enabled = False
        opflag = 1
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        If opflag = 1 Then
            Dim IsChkFW As String = IIf(ChkFW.Checked, "Y", "N")
            If IsChkFW = "Y" AndAlso txtFWValue.Text.Trim = "" Then
                MessageBox.Show("如果校验峰位，峰位值不能为空！", "提示信息")
                Exit Sub
            End If
            If IsChkFW = "N" AndAlso txtFWValue.Text.Trim <> "" Then
                MessageBox.Show("如果不校验峰位，峰位值必须为空！", "提示信息")
                txtFWValue.Clear()
                Exit Sub
            End If
            Dim StrSql As String = "update m_RPartStationD_t set IsFWCheck='" & IsChkFW & "',FWCheckValue='" & txtFWValue.Text.Trim() & "' where State=1 and PPartid ='" & cobPpart.Text & "' and Stationid='" & cobStation.Text & "'"
            Dim Sql As String = "select distinct Ppartid 料件编码,Stationid 站点编号,IsFWCheck 是否校验峰位,FWCheckValue 峰位值 from m_RPartStationD_t where State=1 and PPartid ='" & cobPpart.Text & "' and Stationid='" & cobStation.Text & "'"
            Dim dts As DataTable

            Try
                Conn.ExecSql(StrSql)
                dts = Conn.GetDataTable(Sql)
                dgvRstation.DataSource = dts
                dts.Dispose()
                Conn.PubConnection.Close()
                cobPpart.Enabled = True
                cobStation.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Conn.PubConnection.Close()
            End Try

        End If
        

    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim Sql As String = "select distinct Ppartid 料件编码,Stationid 站点编号,IsFWCheck 是否校验峰位,FWCheckValue 峰位值 from m_RPartStationD_t where State=1 "
        If Me.cobPpart.Text.Trim <> "" Then

            Sql = Sql & " and PPartid='" & Me.cobPpart.Text.Trim & "' "

        End If
        If Me.cobStation.Text.Trim <> "" Then

            Sql = Sql & " and Stationid = '" & Me.cobStation.Text.Trim & "'"

        End If
        Dim dts As DataTable
        Try
            dts = Conn.GetDataTable(Sql)
            dgvRstation.DataSource = dts
            dts.Dispose()
            Conn.PubConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Conn.PubConnection.Close()
        End Try
       
    End Sub

    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        cobPpart.Enabled = True
        cobStation.Enabled = True
        cobPpart.Text = ""
        cobStation.Text = ""
        txtFWValue.Clear()
        ChkFW.Checked = False

    End Sub
End Class