Public Class FrmProductTypeInfo

    Private op As String = "None"

    Private Sub FrmProductTypeInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setViewBrowse()
        dataLoad()
    End Sub

    '浏览模式
    Private Sub setViewBrowse()
        toolAdd.Enabled = True
        toolEdit.Enabled = True
        toolSave.Enabled = False
        toolBack.Enabled = False
        TxtProductType.Enabled = False
    End Sub
    '编辑模式
    Private Sub setViewModify()
        toolAdd.Enabled = False
        toolEdit.Enabled = False
        toolSave.Enabled = True
        toolBack.Enabled = True
        TxtProductType.Enabled = True
    End Sub

    ''' <summary>
    ''' 数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dataLoad()
        Dim sql As String = "select * from ProductType_t"
        DgvData.AutoGenerateColumns = False
        DgvData.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub



    Private Sub DgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvData.CellValueChanged
        Dim sql As String = ""
        If (e.RowIndex <> -1) Then
            Dim ProductType As Object = DgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim ProductTypeID As Object = DgvData.Rows(e.RowIndex).Cells(0).Value
            If IsDBNull(ProductTypeID) Then
                If MainFrame.DbOperateUtils.GetDataTable("select * from ProductType_t where ProductType=N'" + ProductType + "'").Rows.Count > 0 Then
                    MessageBox.Show("已经存在一笔产品类型:" + ProductType + "的记录")
                    Exit Sub
                End If
                sql = "insert into ProductType_t (ProductTypeID,ProductType) values('" + getMaxPTID() + "',N'" + ProductType + "')"
            Else
                sql = "update ProductType_t set ProductType=N'" & ProductType & "' where ProductTypeID='" + ProductTypeID.ToString() + "'"
            End If
            MainFrame.DbOperateUtils.ExecSQL(sql)
            dataLoad()
        End If

    End Sub

    ''' <summary>
    ''' 获取最大产品类型编号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getMaxPTID() As String
        Dim result As String = ""
        If MainFrame.DbOperateUtils.GetDataTable("select ProductTypeID from ProductType_t").Rows.Count = 0 Then
            result = "PT" + "1".PadLeft(5, "0")
        Else
            result = "PT" + MainFrame.DbOperateUtils.GetDataTable("select max(CONVERT(int,SUBSTRING(ProductTypeID,3,5)))+1 from ProductType_t").Rows(0)(0).ToString().PadLeft(5, "0")
        End If
        Return result
    End Function

    Private Sub toolQuery_Click(sender As Object, e As EventArgs)
        dataLoad()
    End Sub

    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        TxtProductType.Text = Nothing
        op = "Add"
        setViewModify()
    End Sub
    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        op = "Edit"
        setViewModify()
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim ProductType As Object = ""
        Dim sql As String = ""
        If String.IsNullOrEmpty(TxtProductType.Text.Trim) = True Then
            MessageBox.Show("请输入产品类型名称")
            Exit Sub
        End If
        ProductType = TxtProductType.Text.Trim
        Try
            If op = "Add" Then
                If MainFrame.DbOperateUtils.GetDataTable("select * from ProductType_t where ProductType=N'" + ProductType + "'").Rows.Count > 0 Then
                    MessageBox.Show("已经存在一笔产品类型:" + ProductType + "的记录")
                    Exit Sub
                End If
                sql = "insert into ProductType_t (ProductTypeID,ProductType,InUserCode,inUser,inTime) values('" + getMaxPTID() + "',N'" + ProductType + "','" + VbCommClass.VbCommClass.UseId + "',N'" + VbCommClass.VbCommClass.UseName + "',getdate())"
            ElseIf op = "Edit" Then
                sql = "update ProductType_t set ProductType=N'" & ProductType & "',InUserCode='" + VbCommClass.VbCommClass.UseId + "',inUser=N'" + VbCommClass.VbCommClass.UseName + "',inTime=getdate() where ProductTypeID='" + DgvData.CurrentRow.Cells("ColProductTypeID").Value + "'"
            End If
            MainFrame.DbOperateUtils.ExecSQL(sql)
            MessageBox.Show("保存成功")
            setViewBrowse()
            op = "Node"
            dataLoad()
        Catch ex As Exception
            MessageBox.Show("保存失败:\n" + ex.Message)
        End Try
      
    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        setViewBrowse()
        dataLoad()
    End Sub

    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        TxtProductType.Text = DgvData.CurrentRow.Cells("ColProductType").Value.ToString
    End Sub
End Class
