Imports MainFrame

Public Class Frmshipreport

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)
        Try
            txtCustomer.Focus()
            If txtCustomer.Text = "" And txtPack.Text = "" Then
                MsgBox("请输入更精确的查询条件...", 48, "提示")
                Exit Sub
            End If
            myThread.Start()
            ShowData()
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub

    Private Sub ShowData()
        Try
            Dim CustCode As String = ""
            If txtCustomer.Text <> "" Then
                CustCode = txtCustomer.Text.Trim
            Else
                CustCode = ""
            End If

            Dim CartonID As String = ""
            If txtPack.Text.Trim <> "" Then
                CartonID = txtPack.Text.Trim
            Else
                CartonID = ""
            End If

            Dim strSql As String
            strSql = "EXEC m_Shipmentinquiry_p '" & CustCode & "','" & CartonID & "'"            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSql)            If dt.Rows.Count > 0 Then                ToolCount.Text = dt.Rows.Count                DgMoData.DataSource = dt                DgMoData.Refresh()
                dt.Dispose()            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
End Class