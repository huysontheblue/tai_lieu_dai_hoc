Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmWireslot
    Public MouldID As String

    '线槽维护
    Private Sub txtSlots_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtSlots.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtSlots.Text.Trim = "" Then
                Return
            Else
                txtParts.Focus()
                txtParts.SelectAll()
            End If
        End If

    End Sub
    Dim M As String
    '机种维护
    Private Sub txtParts_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtParts.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtParts.Text.Trim = "" Then
                Return
            Else
                Dim dr As DataGridViewRow = New DataGridViewRow()
                dr.CreateCells(dgvBasis)
                If RadioButton1.Checked = True Then
                    M = "Y"
                Else
                    M = "N"
                End If
                dr.Cells(0).Value = txtMouldID.Text.Trim
                dr.Cells(1).Value = txtSlots.Text.Trim
                dr.Cells(2).Value = txtParts.Text.Trim
                dr.Cells(3).Value = cboStorage.Text.Trim()
                dr.Cells(4).Value = cboRequestLine.Text.Trim()
                dr.Cells(5).Value = M
                If dgvBasis.Rows().Count = 0 Then

                    '  ((DataTable)dataGridView1.DataSource).Rows.Add(dataRow);
                    dgvBasis.Rows.Insert(0, dr)

                    txtSlots.Focus()
                    txtSlots.SelectAll()
                Else
                    For index = 0 To dgvBasis.Rows.Count - 1
                        If (txtSlots.Text.Trim = dgvBasis.Rows(index).Cells(1).Value.ToString() AndAlso txtParts.Text.Trim = dgvBasis.Rows(index).Cells(2).Value.ToString()) Then
                            MessageBox.Show("机种重复")
                            txtParts.Focus()
                            txtParts.SelectAll()
                            Return

                        End If
                    Next
                    dgvBasis.Rows.Insert(0, dr)
                    txtSlots.Focus()
                    txtSlots.SelectAll()
                    Return
                End If
            End If
        End If
    End Sub
    '加载以保存过的线槽和机种
    Private Sub FrmWireslot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim strSQL As String
        BindComboxLine(cboRequestLine)
        cboRequestLine.SelectedIndex = 1
        FillCombox(cboStorage) '加载储位信息
        txtMouldID.Text = MouldID.ToString
        strSQL = "SELECT MouldID,Slots,Parts,Storage,Line,Library FROM m_Slots_t  WHERE MouldID = '" & txtMouldID.Text & "'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        ' dgvBasis.DataSource = dt
        For Each dr As DataRow In dt.Rows
            dgvBasis.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), dr.Item(5))
        Next
    End Sub
    '删除当前选中行，但不会修改数据库
    Private Sub btnDelect_Click(sender As Object, e As EventArgs) Handles btnDelect.Click
        If Not IsNothing(dgvBasis.CurrentRow) Then
            Dim drv As DataGridViewRow = dgvBasis.CurrentRow
            dgvBasis.Rows.Remove(drv)
        End If
    End Sub
    '保存数据到数据库
    Private Sub btnSubn_Click(sender As Object, e As EventArgs) Handles btnSubn.Click
        Dim strSql As New StringBuilder
        strSql.Append("DELETE FROM m_Slots_t WHERE MouldID = '" & txtMouldID.Text & "'")
        For index = 0 To dgvBasis.Rows.Count - 1
            strSql.Append(" INSERT INTO m_Slots_t (MouldID,Slots,Parts,Storage,Line,Library)  VALUES (N'" & dgvBasis.Rows(index).Cells(0).Value & "',N'" & dgvBasis.Rows(index).Cells(1).Value & "',N'" & dgvBasis.Rows(index).Cells(2).Value & "',N'" & dgvBasis.Rows(index).Cells(3).Value & "',N'" & dgvBasis.Rows(index).Cells(4).Value & "',N'" & dgvBasis.Rows(index).Cells(5).Value & "')")
        Next
        If Not String.IsNullOrEmpty(strSql.ToString) Then
            MainFrame.DbOperateUtils.ExecSQL(strSql.ToString())
            MainFrame.SysCheckData.MessageUtils.ShowInformation("提交成功")
            Me.Close()
        End If
    End Sub
    Dim A As String
    Dim Part As String
    Dim Librar As String
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        toolSave.Enabled = True
        btnSubn.Enabled = False
        btnDelect.Enabled = False
        txtSlots.ReadOnly = True
        If dgvBasis.RowCount < 1 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        A = dgvBasis.CurrentRow.Index
        Try
            txtSlots.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Slots").Value.ToString
            Part = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Parts").Value.ToString
            txtParts.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Parts").Value.ToString
            cboRequestLine.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Line").Value.ToString
            cboStorage.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Storage").Value.ToString
            Librar = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Library").Value.ToString
            If dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Library").Value.ToString = "Y" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If txtParts.Text = "" Then
            MessageBox.Show("机种不能为空")
            txtParts.Focus()
            txtParts.SelectAll()
            Return
        End If
        If RadioButton1.Checked = True Then
            M = "Y"
        Else
            M = "N"
        End If

        If Part <> txtParts.Text Then
            For index = 0 To dgvBasis.Rows.Count - 1
                If (txtSlots.Text.Trim = dgvBasis.Rows(index).Cells(1).Value.ToString() AndAlso txtParts.Text.Trim = dgvBasis.Rows(index).Cells(2).Value.ToString()) Then
                    MessageBox.Show("机种重复")
                    txtParts.Focus()
                    txtParts.SelectAll()
                    Return
                End If
            Next
        End If
        For index = 0 To dgvBasis.Rows.Count - 1
            If (txtSlots.Text.Trim = dgvBasis.Rows(index).Cells(1).Value.ToString()) Then
                dgvBasis.Rows(index).Cells(3).Value = cboStorage.Text
                dgvBasis.Rows(index).Cells(4).Value = cboRequestLine.Text
                dgvBasis.Rows(index).Cells(5).Value = M
            End If
        Next
        dgvBasis.Rows(A).Cells("Parts").Value = txtParts.Text
        txtParts.Text = ""
        txtSlots.Text = ""
        toolSave.Enabled = False
        btnSubn.Enabled = True
        btnDelect.Enabled = True
        txtSlots.ReadOnly = False
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        txtParts.Text = ""
        txtSlots.Text = ""
        toolSave.Enabled = False
        btnSubn.Enabled = True
        btnDelect.Enabled = True
    End Sub

    Public Sub BindComboxLine(ByVal ColComboBox As ComboBox)
        Dim strSQL As New StringBuilder
        strSQL.Append("select '模具室' as OutLineID UNION ALL SELECT DISTINCT OutLineID FROM dbo.m_MouldInOutRecord_t a")
        strSQL.Append(" LEFT JOIN dbo.m_Mould_t b ON  a.MouldID = b.MouldID")
        strSQL.Append(" WHERE b.FactoryID ='" & VbCommClass.VbCommClass.Factory & "'")
        strSQL.Append(" AND B.ProfileID='" & VbCommClass.VbCommClass.profitcenter & "'")
        'GetFatoryOther()

        BindCombox(strSQL.ToString, ColComboBox, "OutLineID", "OutLineID")
    End Sub
    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
    '加载储位信息
    Private Sub FillCombox(ByVal comboBox As ComboBox)
        Dim strSQL As String
        Dim dt As DataTable
        If comboBox.Name = "cboStorage" Then
            strSQL = "select '' StorageID,'' Warehouse union select StorageID,Warehouse  from m_Storage_t where Usey ='Y'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            comboBox.DataSource = dt
            comboBox.DisplayMember = "StorageID"
            comboBox.ValueMember = "StorageID"
        End If
        dt = Nothing
    End Sub
End Class