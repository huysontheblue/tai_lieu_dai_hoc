Imports MainFrame.SysDataHandle

Public Class FormCTestItemData
    Dim type As String
    Dim editDescID As String
    Public Sub New(editCodeA As String, editNameA As String, editDescA As String, typeA As String)
        InitializeComponent()
        type = typeA
        editDescID = editCodeA
        If typeA = "Update" Then
            editCode.Text = editCodeA
            editName.Text = editNameA
            editDesc.Text = editDescA
            editCode.Enabled = False
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not (System.Text.RegularExpressions.Regex.IsMatch(editCode.Text, "^[A-Za-z0-9]*$")) Then
            MessageBox.Show("测试大项代码只能是英文或者数字")
            Return
        End If
            Check()
    End Sub
    Private Sub Check()
        If editName.Text.Trim() = "" Then
            MessageBox.Show("测试大项代码不能为空")
            Return
        End If
        If editCode.Text.Trim() = "" Then
            MessageBox.Show("测试大项名称不能为空")
            Return
        End If
        Dim sql As String
        Dim sqlConn As New SysDataBaseClass
        Dim Data As DataTable
        If Type = "Update" Then
            sql = "UPDATE m_QCTestprojectowner_t SET  ITEM_TYPE_CODE=N'" & editCode.Text.Trim() & "',ITEM_TYPE_NAME=N'" & editName.Text.Trim() & "',ITEM_TYPE_DESC=N'" & editDesc.Text.Trim() & "',USID=N'" & VbCommClass.VbCommClass.UseId & "' WHERE ITEM_TYPE_CODE =N'" & editDescID & "'"
            Data = sqlConn.GetDataTable(sql)
        Else
            Try
                sql = "SELECT * FROM m_QCTestprojectowner_t WHERE ITEM_TYPE_CODE =N'" & editCode.Text.Trim() & "'"
                Data = sqlConn.GetDataTable(sql)
                If Data.Rows.Count > 0 Then
                    MessageBox.Show("测试大项代码已存在")
                    Return
                End If
                sql = "INSERT INTO m_QCTestprojectowner_t(ITEM_TYPE_ID,ITEM_TYPE_CODE,ITEM_TYPE_NAME,ITEM_TYPE_DESC,USID,Effective) VALUES((SELECT TOP 1  ITEM_TYPE_ID FROM m_QCTestprojectowner_t  ORDER BY ITEM_TYPE_ID DESC)+1,N'" & editCode.Text.Trim() & "',N'" & editName.Text.Trim() & "',N'" & editDesc.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "','Y')"
                Data = sqlConn.GetDataTable(sql)
            Catch ex As Exception
                sql = "INSERT INTO m_QCTestprojectowner_t(ITEM_TYPE_ID,ITEM_TYPE_NAME,ITEM_TYPE_CODE,ITEM_TYPE_DESC,USID,Effective) VALUES('10001',N'" & editCode.Text.Trim() & "',N'" & editName.Text.Trim() & "',N'" & editDesc.Text.Trim() & "','" & VbCommClass.VbCommClass.UseId & "','Y')"
                Data = sqlConn.GetDataTable(sql)
            End Try
        End If

        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub FormCTestItemData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class