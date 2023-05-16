Imports MainFrame.SysDataHandle

Public Class FormProductitemAdd
    Public Partid As String
    Dim sqlConn As New SysDataBaseClass
    Public Type As String = ""
    Public editDescID As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As FormChecklarge = New FormChecklarge()
        If form.ShowDialog() = DialogResult.OK Then
            editCode.Text = form.dgvData.CurrentRow.Cells("ITEM_TYPE_CODE").Value.ToString()
            editName.Text = form.dgvData.CurrentRow.Cells("ITEM_TYPE_NAME").Value.ToString()
        End If
    End Sub

    Private Sub FormProductitemAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabTypeName.Text = Partid
        typeadd()
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If type1.Text.Trim() = "" Then
            MessageBox.Show("测试类型不能为空")
            Return
        End If

        If editCode.Text.Trim() = "" Then
            MessageBox.Show("测试不良代码不能为空")
            Return
        End If
        If editDescID.ToString() <> editCode.Text.ToString() Then
            Dim sql As String
            sql = "SELECT * FROM m_QCProducttestingM_t WHERE TestitemID =N'" & editCode.Text.Trim() & "' and  Partid ='" & Partid & "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            If Data.Rows.Count > 0 Then
                MessageBox.Show("测试大项代码已存在")
                Return
            End If
        End If
        If Type = "Update" Then
            Dim sql, TypeID As String
            Dim Data As DataTable
            sql = "SELECT TypeID FROM m_QCTypedata_t WHERE TypeName = N'" & type1.Text.ToString() & "'"
            Data = sqlConn.GetDataTable(sql)
            TypeID = Data.Rows(0)(0)
            sql = "UPDATE m_QCProducttestingM_t SET  TypedataID=N'" & TypeID & "', TestitemID=N'" & editCode.Text.Trim() & "',TestitemName=N'" & editName.Text.Trim() & "',Usid=N'" & VbCommClass.VbCommClass.UseId & "' WHERE Partid = '" & Partid & "' AND TestitemID =N'" & editDescID & "'"
            Data = sqlConn.GetDataTable(Sql)
        Else
            Try
                Dim sql As String
                Dim Data As DataTable
                Sql = "SELECT TestitemID FROM m_QCProducttesttype_t  WHERE Partid='" & Partid & "' AND TypeName =N'" & type1.Text & "'"
                Data = sqlConn.GetDataTable(Sql)
                If Data.Rows.Count = 0 Then
                    Sql = "SELECT   (SELECT TOP 1  TestitemID FROM m_QCProducttesttype_t  ORDER BY TestitemID DESC)+1"
                    Data = sqlConn.GetDataTable(Sql)
                End If
                Dim ID As String = Data.Rows(0)(0)
                Sql = "INSERT INTO  m_QCProducttesttype_t(TestitemID,Partid,TypeName,Effective,Usid) VALUES(   '" & ID & "'  , '" & Partid & "',N'" & type1.Text & "','Y','" & VbCommClass.VbCommClass.UseId & "')"
                Data = sqlConn.GetDataTable(Sql)
                sql = "INSERT INTO m_QCProducttestingM_t(ID,Partid,TestitemID,TestitemName,Usid,Effective,TypedataID) VALUES" &
               "((SELECT TOP 1  ID FROM m_QCProducttestingM_t  ORDER BY ID DESC)+1,N'" & Partid & "',N'" & editCode.Text.Trim() & "',N'" & editName.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "','Y' , (SELECT TypeID FROM m_QCTypedata_t WHERE TypeName =N'" & type1.Text & "'))"
                Data = sqlConn.GetDataTable(Sql)
            Catch ex As Exception
                Dim sql As String
                Dim Data As DataTable
                Sql = "INSERT INTO m_QCProducttesttype_t (TestitemID,Partid,typeName,Effective,Usid) VALUES('10001','" & Partid & "',N'" & type1.Text & "','Y','" & VbCommClass.VbCommClass.UseId & "')"
                Data = sqlConn.GetDataTable(Sql)
                Sql = "INSERT INTO m_QCProducttestingM_t(ID,Partid,TestitemID,TestitemName,Usid,Effective) VALUES('10001',N'" & Partid & "',N'" & editCode.Text.Trim() & "',N'" & editName.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "','Y')"
                Data = sqlConn.GetDataTable(Sql)
            End Try
        End If
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.No
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Add.Click
        If Add.Text = "增" Then
            type1.DropDownStyle = ComboBoxStyle.Simple
            increase.Visible = True
            Add.Text = "保存"
            Return
        End If
        If Add.Text = "保存" Then
            Dim Addtext = type1.Text.Trim()
            Dim SQL = "SELECT * FROM  m_QCTypedata_t"
            Dim DATA As DataTable = sqlConn.GetDataTable(SQL)
            If DATA.Rows.Count() = 0 Then
                SQL = "INSERT INTO m_QCTypedata_t(TypeID,TypeName,usid) VALUES ('1001',N'" & type1.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "')"
                DATA = sqlConn.GetDataTable(SQL)
                MessageBox.Show("保存成功")
                type1.DropDownStyle = ComboBoxStyle.DropDownList
                increase.Visible = False
                Add.Text = "增"
                typeadd()
                type1.Text = Addtext
            Else
                SQL = "SELECT * FROM  m_QCTypedata_t WHERE TypeName =N'" & type1.Text.Trim() & "'"
                DATA = sqlConn.GetDataTable(SQL)
                If DATA.Rows.Count() = 0 Then
                    SQL = "INSERT INTO m_QCTypedata_t(TypeID,TypeName,usid) VALUES ((SELECT TOP 1  TypeID FROM m_QCTypedata_t  ORDER BY TypeID DESC)+1,N'" & type1.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "')"
                    DATA = sqlConn.GetDataTable(SQL)
                    MessageBox.Show("保存成功")
                    type1.DropDownStyle = ComboBoxStyle.DropDownList
                    increase.Visible = False
                    Add.Text = "增"
                    typeadd()
                    type1.Text = Addtext
                Else
                    MessageBox.Show("产品类型已存在不能重复录入")
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MessageBox.Show("是否要删除" + type1.Text, "系统删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error).ToString = "Yes" Then
            Dim sql As String = "DELETE	m_QCTypedata_t WHERE  TypeName =N'" + type1.Text + "'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            MessageBox.Show("删除成功")
            typeadd()
        End If
    End Sub

    Private Sub increase_Click(sender As Object, e As EventArgs) Handles increase.Click
        increase.Visible = False
        type1.DropDownStyle = ComboBoxStyle.DropDownList
        Add.Text = "增"
    End Sub

    Public Sub typeadd()
        Dim Sql As String = "SELECT TypeName FROM  m_QCTypedata_t "
        Dim Data As DataTable = sqlConn.GetDataTable(Sql)
        type1.Items.Clear()
        Dim index As Integer
        For index = 1 To Data.Rows.Count
            type1.Items.Add(Data.Rows(index - 1)(0))
        Next
        If type1.SelectedIndex > 0 Then
            type1.SelectedIndex = 0
        End If
    End Sub
End Class