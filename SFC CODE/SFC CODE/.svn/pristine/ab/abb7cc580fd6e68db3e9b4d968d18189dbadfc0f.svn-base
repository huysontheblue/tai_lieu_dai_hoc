Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing

Public Class Frmppidcode
#Region "参数定义"

    Public opflag As Int16 = 0  '

    Private Enum CDImportGrid
        moid
        ppid

    End Enum

#End Region
    Private Sub Frmppidcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDataToDatagridview(m_strSqlWhere)
        ToolbtnState(0)
    End Sub
    Private Sub LoadDataToDatagridview(ByVal SqlSearch As String)
        dgvPackingData.Rows.Clear()
        Dim type1 As String = IIf(Me.chkPrintNoScan.Checked, "Y", "N")
        Dim type2 As String = IIf(Me.Checkscan.Checked, "Y", "N")
        If Me.Checkscan.Checked = True Then
            ToolDelete.Enabled = True
            If type2 = "Y" And type1 = "N" Then
                SqlSearch = "EXEC Exec_PrintNoScan '" & txtMoid.Text.Trim & "', '" & txtCartonid.Text.Trim & "', '" & txtppid.Text.Trim & "'," & _
                 "'" & type1 & "', '" & type2 & "','" & VbCommClass.VbCommClass.UseId & "','NULL'"

                Dim DtContrast1 As DataTable = DbOperateUtils.GetDataTable(SqlSearch)
                For rowIndex As Integer = 0 To DtContrast1.Rows.Count - 1
                    dgvPackingData.Rows.Add(DtContrast1.Rows(rowIndex).Item(0).ToString, DtContrast1.Rows(rowIndex).Item(1).ToString, DtContrast1.Rows(rowIndex).Item(2).ToString, _
                DtContrast1.Rows(rowIndex).Item(3).ToString, DtContrast1.Rows(rowIndex).Item(4).ToString)
                Next
            End If
        Else
            ToolDelete.Enabled = False
            SqlSearch = "EXEC Exec_PrintNoScan '" & txtMoid.Text.Trim & "', '" & txtCartonid.Text.Trim & "', '" & txtppid.Text.Trim & "'," & _
                            "'" & type1 & "', '" & type2 & "','" & VbCommClass.VbCommClass.UseId & "','NULL'"
            Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(SqlSearch)
            For rowIndex As Integer = 0 To DtContrast.Rows.Count - 1
                dgvPackingData.Rows.Add(DtContrast.Rows(rowIndex).Item(0).ToString, DtContrast.Rows(rowIndex).Item(1).ToString, DtContrast.Rows(rowIndex).Item(2).ToString, _
                DtContrast.Rows(rowIndex).Item(3).ToString, DtContrast.Rows(rowIndex).Item(4).ToString)
            Next
        End If
        ToolCount.Text = dgvPackingData.RowCount.ToString()
    End Sub
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        If txtMoid.Text = "" Then
            MessageUtils.ShowError("请输入工单！")
            Exit Sub
        End If
        LoadDataToDatagridview("")
    End Sub
    '设置状态
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolQuery.Enabled = True
                Me.toolExit.Enabled = True
                Me.txtCartonid.Enabled = True
                Me.txtMoid.Enabled = True
                Me.chkPrintNoScan.Enabled = True
                ToolDelete.Enabled = False
        End Select
    End Sub
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    Private Sub SetMessage(ByVal Message As String, ByVal Type As Boolean)
        If (Type) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim())) Then
                MessageBox.Show("请填写删除原因")
                Me.txtDeReason.Focus()
                Return
            End If
            If (MsgBox("你确定删除该产品选择工站扫描记录（该功能只适合删除非装配工站扫描记录删除）!", 4 + 32) = MsgBoxResult.No) Then
                Return
            End If
            Dim deleteReason As String
            deleteReason = Me.txtDeReason.Text.ToString.Replace("'", "''")

            Dim type1 As String = IIf(Me.chkPrintNoScan.Checked, "Y", "N")
            Dim type2 As String = "3"
            Dim sql = "EXEC Exec_PrintNoScan '" & txtMoid.Text.Trim & "', '" & txtCartonid.Text.Trim & "', '" & txtppid.Text.Trim & "'," & _
                     "'" & type1 & "', '" & type2 & "','" & VbCommClass.VbCommClass.UseId & "',N'" & deleteReason & "'"
            Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(sql)
            SetMessage("删除成功!", True)
            LoadDataToDatagridview("")
            Me.txtDeReason.Clear()
            Me.lblMessage.Text = ""
        Catch ex As Exception
            SetMessage("删除异常", False)
        End Try
    End Sub

End Class