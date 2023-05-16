Imports MainFrame
Imports System.Text

Public Class FrmproductHold
    Dim SQL As String
    Dim dt As DataTable
    Private ObjDB As New MainFrame.SysDataHandle.SysDataBaseClassReport()
    Private Sub txtbarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbarCode.KeyDown
        If e.KeyValue = 13 Then
            SQL = "SELECT id,SBarCode,Packid,case when Usey='Y' then N'锁定' when Usey='N' then N'未锁定' else '' END Usey,(SELECT Stationid +'-'+ Stationname FROM m_Rstation_t WHERE Stationid = m_HoldSn_t.Stationid) AS Stationid,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UserId)AS UserId ,Intime,ReMark,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UnlockUserId) AS UnlockUserId,UnlockIntime,UnlockReMark FROM  m_HoldSn_t WHERE SBarCode =N'" + txtbarCode.Text.Trim() + "'"
            dt = DbOperateReportUtils.GetDataTable(SQL)
            dgvUnPackBox.DataSource = dt
        End If
    End Sub

    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        Save.Enabled = True
        txtRemark.Enabled = True
        txtbarCode.Enabled = True
    End Sub
    Dim SBarCode As String
    Dim Stationid As String
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If txtbarCode.Text.ToString() = "" Then
            MessageBox.Show("请输入产品条码")
            Return
        End If
        If txtRemark.Text.ToString() = "" Then
            MessageBox.Show("请输入锁定原因")
            Return
        Else
            If CobPart.Text.ToString() <> "" Then
                If CobStation.Text.Trim() = "" Then
                    MessageBox.Show("请选择工站")
                    Return
                End If
            End If
            SBarCode = txtbarCode.Text.ToString()
            Dim sArray As String() = CobStation.Text.Split("-")
            If sArray.Length = 0 Then
                Stationid = ""
            Else
                Stationid = sArray(0)
            End If
            SQL = "INSERT INTO m_HoldSn_t (SBarCode,Usey,Stationid,UserId,Intime,ReMark) VALUES ('" + txtbarCode.Text.ToString() + "','Y','" + Stationid + "','" + VbCommClass.VbCommClass.UseId + "',getdate(),N'" + txtRemark.Text.ToString() + "')"
            dt = DbOperateUtils.GetDataTable(SQL)
            Dim strSQL As String = "SELECT id,SBarCode,Packid,case when Usey='Y' then N'锁定' when Usey='N' then N'未锁定' else '' END Usey,(SELECT Stationid +'-'+ Stationname FROM m_Rstation_t WHERE Stationid = m_HoldSn_t.Stationid) AS Stationid,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UserId)AS UserId ,Intime,ReMark,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UnlockUserId) AS UnlockUserId,UnlockIntime,UnlockReMark FROM  m_HoldSn_t WHERE SBarCode =N'" + SBarCode + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
                dgvUnPackBox.DataSource = dt
                MessageBox.Show("保存成功")
                txtbarCode.Text = ""
                txtRemark.Text = ""
                txtbarCode.Focus()
                Save.Enabled = False
        End If
    End Sub
    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        Dim id As Int16
        Dim o_strSQL As New StringBuilder
        If txtRemark.Text.ToString() = "" Then
            MessageBox.Show("请输入解锁原因")
            Return
        Else
            SBarCode = dgvUnPackBox.CurrentRow.Cells(1).Value.ToString()
            id = Val(dgvUnPackBox.CurrentRow.Cells(0).Value.ToString())
            Dim UseId As String = VbCommClass.VbCommClass.UseId.ToString()
            Dim remark As String = txtRemark.Text.ToString()
            o_strSQL.Append(" UPDATE m_HoldSn_t SET Usey='N',UnlockUserId = '" & UseId & "',UnlockIntime = GETDATE(),UnlockReMark = N'" & remark & "' WHERE id = " & id & "")
            dt = DbOperateUtils.GetDataTable(o_strSQL.ToString())
            SQL = "SELECT id,SBarCode,Packid,case when Usey='Y' then N'锁定' when Usey='N' then N'未锁定' else '' END Usey,(SELECT Stationid +'-'+ Stationname FROM m_Rstation_t WHERE Stationid = m_HoldSn_t.Stationid) AS Stationid,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UserId)AS UserId ,Intime,ReMark,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UnlockUserId) AS UnlockUserId,UnlockIntime,UnlockReMark FROM  m_HoldSn_t WHERE SBarCode =N'" + SBarCode + "'"
            dt = DbOperateReportUtils.GetDataTable(SQL)
            dgvUnPackBox.DataSource = dt
            MessageBox.Show("解锁成功")
            EditFile.Enabled = False
            txtRemark.Text = ""
        End If
    End Sub

    Private Sub dgvUnPackBox_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnPackBox.CellClick
        Try
            If dgvUnPackBox.CurrentRow.Cells(3).Value = "锁定" Then
                EditFile.Enabled = True
                Label2.Text = "解锁原因"
                txtRemark.Enabled = True
                txtbarCode.Enabled = False
            Else
                EditFile.Enabled = False
                Label2.Text = "锁定原因"
                txtbarCode.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmproductHold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbarCode.Focus()
    End Sub
    Public Sub LoadStationDataToCombo(ByRef ComBox As ComboBox, ByVal PartIDStr As String)
        SQL = ""
        SQL = " select a.Stationid+'-'+cast(StaOrderid as varchar(3))+'-'+b.Stationname from  m_RPartStationD_t a  join m_Rstation_t b on a.Stationid=b.Stationid join SplitToTable('" & PartIDStr & "',';') c on a.PPartid=c.col where  state=1 and ScanOrderid=1  order by PPartid asc,StaOrderid"
        Try

            dt = ObjDB.GetDataTable(SQL)
            ComBox.Items.Clear()
            ComBox.Items.Add("")
            For i As Integer = 0 To dt.Rows.Count - 1
                ComBox.Items.Add(dt.Rows(i)(0).ToString)
            Next
        Catch ex As Exception
        End Try

    End Sub
    Private Sub CobPart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CobPart.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim str As String = CobPart.Text.Trim()
            LoadStationDataToCombo(CobStation, str)
        End If
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Dim i As Int32
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
        If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim filename As String = ""
        Dim errorMsg As String = ""
        Dim ReMark As String = ""
        filename = sdfimport.FileName
        Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAsA(filename, 0, 0, errorMsg)
        If dtUploadData.Columns.Count <> 3 Then
            MessageBox.Show("格式不正确")
            Return
        End If
        dtUploadData.Rows.RemoveAt(0)
        For i = 0 To dtUploadData.Rows.Count - 1
            SBarCode = dtUploadData.Rows(i)(0).ToString()
            Stationid = dtUploadData.Rows(i)(1).ToString()
            ReMark = dtUploadData.Rows(i)(2).ToString()
            If SBarCode.ToString.Trim() = "" Then
                Continue For
            End If
            SQL = "INSERT INTO m_HoldSn_t (SBarCode,Usey,Stationid,UserId,Intime,ReMark) VALUES ('" + SBarCode + "','Y','" + Stationid + "','" + VbCommClass.VbCommClass.UseId + "',getdate(),N'" + ReMark + "')"
            dt = DbOperateUtils.GetDataTable(SQL)
        Next
        MessageBox.Show("导入成功")
        SQL = "SELECT TOP 100 id,SBarCode,Packid,case when Usey='Y' then N'锁定' when Usey='N' then N'未锁定' else '' END Usey,(SELECT Stationid +'-'+ Stationname FROM m_Rstation_t WHERE Stationid = m_HoldSn_t.Stationid) AS Stationid ,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UserId) AS UserId ,Intime,ReMark,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UnlockUserId) AS UnlockUserId,UnlockIntime,UnlockReMark FROM  m_HoldSn_t ORDER BY Intime DESC"
        dt = DbOperateReportUtils.GetDataTable(SQL)
        dgvUnPackBox.DataSource = dt
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolBt_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolBt.ItemClicked

    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        ShowData()
    End Sub

    Private Sub ShowData()
        SQL = "SELECT TOP 100 id,SBarCode,Packid,case when Usey='Y' then N'锁定' when Usey='N' then N'未锁定' else '' END Usey,(SELECT Stationid +'-'+ Stationname FROM m_Rstation_t WHERE Stationid = m_HoldSn_t.Stationid) AS Stationid ,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UserId) AS UserId ,Intime,ReMark,(SELECT UserName FROM dbo.m_Users_t WHERE UserID = m_HoldSn_t.UnlockUserId) AS UnlockUserId,UnlockIntime,UnlockReMark FROM  m_HoldSn_t where 1=1 " + GetSqlWhere() + " ORDER BY Intime DESC"
        dt = DbOperateReportUtils.GetDataTable(SQL)
        dgvUnPackBox.DataSource = dt
    End Sub
    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder
        If Me.txtbarCode.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND SBarCode = N'" & Me.txtbarCode.Text.Trim.ToString & "' ")
        End If
        Return sbSqlWhere.ToString
    End Function
End Class