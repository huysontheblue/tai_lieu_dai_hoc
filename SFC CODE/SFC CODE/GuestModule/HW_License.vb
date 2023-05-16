Imports MainFrame.SysCheckData
Imports System.Text

Public Class HW_License
    Public pageData As New SysBasicClass.PageData()
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass()
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        QueryData()
    End Sub
    Private Sub QueryData()
        Dim strwhere As String = ""

        If DtStar.Checked Then
            Dim dt1 As Date = Convert.ToDateTime(DtStar.Value.ToString("yyyy-MM-dd"))
            Dim dt2 As Date = Convert.ToDateTime(DtEnd.Value.ToString("yyyy-MM-dd"))
            If Date.Compare(dt1, dt2) > 0 Then
                MessageUtils.ShowWarning("开始时间不能大于结束时间")
                Exit Sub
            End If
            strwhere = strwhere + " and intime between '" + DtStar.Value.ToString("yyyy-MM-dd") + "' and '" + DtEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "'"
        End If
        If Partide.Text.Trim <> "" Then
            strwhere = strwhere + " and PartID='" & Partide.Text.Trim & "'"
        End If
        If txtFileName.Text.Trim <> "" Then
            strwhere = strwhere + " and FileName='" & txtFileName.Text.Trim & "'"
        End If
        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append("select id,PartID,FileName,UID,Path,Intime,UserId,Usey,LockBy,LockTime,UsedBy,UsedTime,Remark from MESDataCenter.dbo.m_HW_C314OTALicense_t ")
        strSql.Append(" where 1=1  ")
        strSql.Append(strwhere)
        pageData.QuerySQL = strSql.ToString
        Cursor = Cursors.WaitCursor
        SysBasicClass.WaitFormService.CreateWaitForm()
        Pager1.PageCount = 1
        Pager1.Bind()
        dgvBind()
        SysBasicClass.WaitFormService.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub
    Private Function dgvBind() As Integer
        DataGridViewX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewX1.ColumnHeadersHeight = 30
        pageData.PageIndex = Pager1.PageCurrent
        pageData.PageSize = Pager1.PageSize

        Pager1.bindingSource.DataSource = pageData.QueryDataTable()
        Pager1.bindingNavigator.BindingSource = Pager1.bindingSource
        DataGridViewX1.AutoGenerateColumns = False
        DataGridViewX1.DataSource = Pager1.bindingSource

        'DataGridViewX1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' DataGridViewX1.Columns(0).HeaderText = "序号"
        'DataGridViewX1.Columns(0).Width = 60
        Return pageData.TotalCount
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim fr As HW_LicenseAdd = New HW_LicenseAdd()
        fr.ShowDialog()
        If fr.IsRefresh Then
            QueryData()
        End If
    End Sub

    Private Sub btnUnLock_Click(sender As Object, e As EventArgs) Handles btnUnLock.Click
        If Me.DataGridViewX1.Rows.Count = 0 OrElse Me.DataGridViewX1.CurrentRow Is Nothing Then Exit Sub
        Dim id As String = DataGridViewX1.Item("id", Me.DataGridViewX1.CurrentRow.Index).Value.ToString.Trim
        Dim usey As String = DataGridViewX1.Item("usey", Me.DataGridViewX1.CurrentRow.Index).Value.ToString.Trim
        If (usey = "Y") Then
            MessageBox.Show("已使用状态，不允许解锁")
            Exit Sub
        End If
        Dim UserID As String = "C027902"
        DialogResult = Windows.Forms.DialogResult.Yes  'MessageUtils.ShowConfirm("确定要作废？", MessageBoxButtons.YesNo)
        If DialogResult = Windows.Forms.DialogResult.Yes Then
            Dim sql As String = "update MESDataCenter.dbo.m_HW_C314OTALicense_t set Usey='N',LockBy=null,LockTime=null,UsedBy=null,UsedTime=null,Remark=isnull((case when len(Remark)>100 then '' else Remark end),'')+N'解除锁定By'+N'" & UserID & "'+','+convert(varchar(25),getdate() ,21)+';' where ID='" & id & "'"
            Dim returnval As String = ""

            Try
                Dim sqlL As String = "SELECT Usey,Partid FROM MESDataCenter.dbo.m_HW_C314OTALicense_t WHERE  id='" + id + "'"
                Dim Data As DataTable = conn.GetDataTable(sqlL)
                If Data.Rows(0)(0).ToString() <> "N" Then
                    sqlL = "UPDATE MESDataCenter.dbo.m_HW_C314LicenseUse  SET Alreadyused = Alreadyused-1  WHERE Partid ='" + Data.Rows(0)(1) + "'"
                    Data = conn.GetDataTable(sqlL)
                End If
                returnval = conn.ExecuteNonQuery(sql)
            Catch ex As Exception
                returnval = returnval + ex.ToString
            End Try
            If returnval = "" Then
                SysMessageClass.SaveUserOpLog(Me, "作废ID：" + id)
                MessageBox.Show("解锁成功")

                QueryData()
            Else
                MessageBox.Show("解锁发生错误：" + returnval)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If Me.DataGridViewX1.Rows.Count = 0 OrElse Me.DataGridViewX1.CurrentRow Is Nothing Then Exit Sub
        Dim id As String = DataGridViewX1.Item("id", Me.DataGridViewX1.CurrentRow.Index).Value.ToString.Trim
        Dim usey As String = DataGridViewX1.Item("usey", Me.DataGridViewX1.CurrentRow.Index).Value.ToString.Trim

        Dim UserID As String = "C027902"
        DialogResult = Windows.Forms.DialogResult.Yes  'MessageUtils.ShowConfirm("确定要作废？", MessageBoxButtons.YesNo)
        If DialogResult = Windows.Forms.DialogResult.Yes Then

            Dim sql As String = "update MESDataCenter.dbo.m_HW_C314OTALicense_t set Usey='N',LockBy=null,LockTime=null,UsedBy=null,UsedTime=null,Remark=isnull((case when len(Remark)>100 then '' else Remark end),'')+N'清除使用记录By'+N'" & UserID & "'+','+convert(varchar(25),getdate() ,21)+';' where ID='" & id & "'"
            Dim returnval As String = ""
            'Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass()
            Try
                Dim sqlL As String = "SELECT Usey,Partid FROM MESDataCenter.dbo.m_HW_C314OTALicense_t WHERE  id='" + id + "'"
                Dim Data As DataTable = conn.GetDataTable(sqlL)
                If Data.Rows(0)(0).ToString() <> "N" Then
                    sqlL = "UPDATE MESDataCenter.dbo.m_HW_C314LicenseUse  SET Alreadyused = Alreadyused-1  WHERE Partid ='" + Data.Rows(0)(1) + "'"
                    Data = conn.GetDataTable(sqlL)
                End If
                returnval = conn.ExecuteNonQuery(sql)
            Catch ex As Exception
                returnval = returnval + ex.ToString
            End Try
            If returnval = "" Then
                SysMessageClass.SaveUserOpLog(Me, "作废ID：" + id)
                MessageBox.Show("清除成功")

                QueryData()
            Else
                MessageBox.Show("清除发生错误：" + returnval)
                Exit Sub
            End If
        End If
    End Sub
End Class