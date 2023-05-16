Partial Class RunCardDataSet

    Partial Class ProcessCardDataTable

        Private Sub ProcessCardDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IDColumn.ColumnName) Then
                '在此处添加用户代码
            End If

        End Sub

    End Class

    Partial Class RunCardDetailListDataTableDataTable


    End Class

End Class
