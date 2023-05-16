Imports MainFrame.SysDataHandle

Public Class FormProductitemAddson
    Public sId As String
    Public Partid As String
    Public Small As String
    Public RelationID As String
    Public Type As String
    Public SmallID As String
    Dim sqlConn As New SysDataBaseClass


    Private Sub FormProductitemAddson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fomPartid.Text = Partid.Trim()
        fomSmall.Text = RelationID.Trim()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As FormCheckSmall = New FormCheckSmall()
        Dim SQL As String = "SELECT ITEM_TYPE_ID FROM m_QCTestprojectowner_t  WHERE ITEM_TYPE_CODE ='" & RelationID & "'"
        Dim Data As DataTable = sqlConn.GetDataTable(SQL)
        If Data.Rows.Count = 0 Then
            MessageBox.Show("大项代码不存在，请检查是否被人删除")
            Return
        End If
        form.code = Data.Rows(0)(0)
        If form.ShowDialog() = DialogResult.OK Then
            editCode.Text = form.dgvData.CurrentRow.Cells("ITEM_Small_Code").Value.ToString()
            editName.Text = form.dgvData.CurrentRow.Cells("ITEM_Small_Name").Value.ToString()
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If editCode.Text.Trim() = "" Then
            MessageBox.Show("测试小项代码不能为空")
            Return
        End If
        If editName.Text = "" Then
            MessageBox.Show("测试小项名称不能为空")
            Return
        End If
        If Not IsNumeric(Serialnumber.Text) Then
            MessageBox.Show("排序序号必须为数字")
            Return
        End If
        Dim sqlq = "SELECT * FROM m_QCProducttestingMson_t  WHERE SmallID ='" & editCode.Text.Trim() & "' AND Partid='" & Partid & "'"
        Dim Datav As DataTable = sqlConn.GetDataTable(sqlq)
        If SmallID <> editCode.Text.Trim() Then
            If Datav.Rows.Count > 0 Then
                MessageBox.Show("不良小类" + editCode.Text.Trim() + "已存在不能重复录入")
                Return
            End If
        End If
        If Type = "Update" Then
            'Dim sql As String = "UPDATE m_QCProducttestingMson_t SET SmallID=N'" & editCode.Text.Trim() & "',SmallName=N'" & editName.Text & "',Serialnumber=N'" & Serialnumber.Text.Trim() & "',Usid='" & VbCommClass.VbCommClass.UseId & "' WHERE large ='" & Small & "' AND Partid='" & Partid & "' AND Effective ='Y'"

            'modify hgd 20200604
            Dim sql As String = "UPDATE m_QCProducttestingMson_t SET SmallID=N'" & editCode.Text.Trim() & "',SmallName=N'" & editName.Text & "',Serialnumber=N'" & Serialnumber.Text.Trim() & "',Usid='" & VbCommClass.VbCommClass.UseId & "' WHERE id='" & sId & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
        Else
            Dim sql As String = "INSERT INTO m_QCProducttestingMson_t(RelationID,Partid,large,SmallID,SmallName,Serialnumber,Effective,Usid) VALUES(N'" & RelationID & "',N'" & Partid & "','" & Small & "', N'" & editCode.Text.Trim() & "',N'" & editName.Text & "',N'" & Serialnumber.Text.Trim() & "','Y','" & VbCommClass.VbCommClass.UseId & "')"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
        End If
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub Serialnumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Serialnumber.KeyPress

        If (Asc(e.KeyChar) < 48 OrElse Asc(e.KeyChar) > 57) AndAlso (Asc(e.KeyChar) <> 46) AndAlso Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub
End Class