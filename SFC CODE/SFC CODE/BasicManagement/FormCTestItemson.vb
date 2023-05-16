Imports MainFrame.SysDataHandle

Public Class FormCTestItemson
    Dim type As String
    Dim editDescID As String
    Dim editCodeAID As String
    Dim sqlConn As New SysDataBaseClass
    Public Sub New(editCodeAN As String, editNameAN As String, editCodeA As String, editNameA As String, editDescA As String, combHasValueA As String, typeA As String)
        InitializeComponent()
        type = typeA
        editDescID = editCodeA
        editCodeAID = editCodeAN
        combHasValue.Text = "Y"
        LabTypeName.Text = editNameAN
        If typeA = "Update" Then
            editCode.Text = editCodeA
            editName.Text = editNameA
            editDesc.Text = editDescA
            combHasValue.Text = combHasValueA
            editCode.Enabled = False
        End If
    End Sub
    Private Sub Check()
        If editCode.Text.Trim() = "" Then
            MessageBox.Show("测试小项代码不能为空")
            Return
        End If
        If editName.Text.Trim() = "" Then
            MessageBox.Show("测试小项名称不能为空")
            Return
        End If
        Dim sql As String
        Dim Data As DataTable
        If type = "Update" Then
            sql = "UPDATE m_QCTestprojectownerson_t SET ITEM_Small_Code =N'" & editCode.Text.Trim() & "',ITEM_Small_Name=N'" & editName.Text.Trim() & "',ITEM_Small_DESC=N'" & editDesc.Text.Trim() & "',ITEM_Small_default=N'" & combHasValue.Text & "',ITEM_Small_Usid=N'" & VbCommClass.VbCommClass.UseId & "' WHERE ITEM_TYPE_ID =N'" & editCodeAID & "' and ITEM_Small_Code =N'" & editCode.Text.Trim() & "'"
            Data = sqlConn.GetDataTable(sql)
        Else
            sql = "SELECT * FROM m_QCTestprojectownerson_t WHERE ITEM_Small_Code =N'" & editCode.Text.Trim() & "' and ITEM_TYPE_ID='" & editCodeAID & "'"
            Data = sqlConn.GetDataTable(sql)
            If Data.Rows.Count > 0 Then
                MessageBox.Show("测试小项代码已存在")
                Return
            End If
            sql = "INSERT INTO m_QCTestprojectownerson_t(ITEM_TYPE_ID,ITEM_Small_Code,ITEM_Small_Name,ITEM_Small_DESC,ITEM_Small_default,ITEM_Small_Usid,ITEM_Small_Effective) " &
            "VALUES('" & editCodeAID & "',N'" & editCode.Text.Trim() & "',N'" & editName.Text.Trim() & "',N'" & editDesc.Text.Trim() & "',N'" & combHasValue.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "','Y')"
            Data = sqlConn.GetDataTable(sql)
        End If

        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not (System.Text.RegularExpressions.Regex.IsMatch(editCode.Text, "^[A-Za-z0-9]*$")) Then
            MessageBox.Show("测试大项代码只能是英文或者数字")
            Return
        End If
        Check()
    End Sub

End Class