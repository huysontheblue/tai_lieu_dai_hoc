Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmPartMacAddress
    Private buttonStatus As EnumStatus

    Private Enum EnumStatus
        UnDo = -1
        NewAdd = 0
        Edit = 1
        Delete = 2
        DownLoad = 3
        Search = 4
    End Enum
    Private Sub FrmPartMacAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TxtTavcPart.Enabled = True
        SearchRecord("")
    End Sub
    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        Me.TxtTavcPart.Text = ""
        Me.txtMacMin.Text = ""
        Me.txtMacMax.Text = ""
        Me.TxtTavcPart.Enabled = True
        Me.txtMacMin.Enabled = True
        Me.txtMacMax.Enabled = True
        txtMacMin.ReadOnly = False
        txtMacMax.ReadOnly = False
        Me.Save.Enabled = True
        Me.UnDo.Enabled = True
        Me.chkUse.Checked = True
        buttonStatus = EnumStatus.NewAdd
    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Me.TxtTavcPart.Enabled = True
        Me.txtMacMin.Enabled = False
        Me.txtMacMin.Enabled = False
        Me.chkUse.Enabled = False
    End Sub

    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        Me.Save.Enabled = True
        Me.UnDo.Enabled = True
        Me.TxtTavcPart.Enabled = True
        Me.txtMacMin.Enabled = True
        Me.txtMacMax.Enabled = True
        Me.TxtTavcPart.Enabled = False
        Me.chkUse.Enabled = True
        If dgvMac.CurrentRow.Cells(0).Value = Nothing Then
            MessageUtils.ShowError("请选择要修改的料件!")
            Return
        End If

        Me.lblID.Text = dgvMac.CurrentRow.Cells(0).Value
        Me.TxtTavcPart.Text = dgvMac.CurrentRow.Cells(1).Value
        Me.txtMacMin.Text = dgvMac.CurrentRow.Cells(2).Value
        Me.txtMacMax.Text = dgvMac.CurrentRow.Cells(3).Value
        txtMacMin.ReadOnly = True
        txtMacMax.ReadOnly = True
        Me.chkUse.Checked = IIf(dgvMac.CurrentRow.Cells(4).Value = "Y", True, False)
        buttonStatus = EnumStatus.Edit
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click

        'Dim SqlStr As String = "exec p_GetCustMac"

        'SqlStr = SqlStr + "'" + TxtTavcPart.Text.Trim + "'"

        'Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        'ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub
    Private Sub SearchRecord(ByVal partid As String)
        Dim dt As DataTable = Nothing
        dgvMac.Rows.Clear()
        'dgvMac.DataSource = Nothing
        '       Dim sql As String = "SELECT  [ID],a.[PartId] ,[MacStartNo] ,[MacEndNo],[USEY],b.MACADDRESS   FROM m_PartMacaddress_t a LEFT JOIN " _
        '& "(SELECT  x.PARTID ,x.MACADDRESS FROM MESDataCenter .dbo .m_MacaddressUsed_t X,(SELECT  max( MESDataCenter.[dbo].[f_xToDec1](MACADDRESS,'Hex')) mac,PARTID " _
        '& " FROM MESDataCenter .dbo .m_MacaddressUsed_t group BY PARTID)Y WHERE MESDataCenter.[dbo].[f_xToDec1](X.MACADDRESS,'Hex')=Y.mac  " _
        '       '& " AND X.PARTID =Y.PARTID) b ON a.PARTID =b.PARTID WHERE 1=1   "
        '       Dim sql As String = "SELECT TOP 100 [ID],a.[PartId] ,[MacStartNo] ,[MacEndNo],a.[USEY],b.MACADDRESS,    a.CreateUserID +'-'+UserName as username  ,a.CreateTime FROM m_PartMacaddress_t a  LEFT JOIN " _
        '& "(SELECT  max  (MACADDRESS ) MACADDRESS,PARTID FROM MESDataCenter .dbo .m_MacaddressUsed_t  group BY PARTID  UNION  " _
        '  & " SELECT   max(MACADDRESS) MACADDRESS,Material PARTID " _
        '  & " FROM MESDataCenter .dbo .m_MSRJBMACWrite_t  group BY Material) b " _
        '  & "  ON a.PARTID =b.PARTID left join m_Users_t c on   a.CreateUserID  = c.UserID   WHERE 1=1 AND  ApplyUserID  IS NULL  "
        '       Try
        '           If Sqlstring <> "" Then

        '               sql = sql + Sqlstring
        '           End If
        '           sql = sql + " order by a.CreateTime desc"
        Try
            Dim sql As String = "exec p_GetCustPartMac"
            If partid <> "" Then
                sql = sql + "'" + partid + "'"
            Else
                sql = sql + "''"
            End If

            dt = DbOperateUtils.GetDataTable(sql)

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    dgvMac.Rows.Add(row("id").ToString, row("PartID").ToString, row("MacMin").ToString, row("MacMax").ToString, row("UsedMaxMac").ToString, row("TotalMacCount").ToString, row("RemainMacCount").ToString, row("usey").ToString, row("CreateUserID").ToString, row("Intime").ToString)
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartMacAddress", "SearchRecord", "BasicM")
        End Try
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If CheckData() Then
            If SaveData() Then
                Me.SearchRecord("")
                MessageUtils.ShowInformation("保存成功")
            End If
        End If
    End Sub
    Private Function SaveData() As Boolean
        Dim sql As String = ""
        Dim partid As String = TxtTavcPart.Text.ToUpper.Trim
        Dim start As String = txtMacMin.Text.ToUpper.Trim
        Dim endno As String = txtMacMax.Text.ToUpper.Trim
        Dim id As String = lblID.Text
        Dim result As Boolean = True
        Dim use As String = ""
        Dim iTotalMacCount As Integer
        Try
            use = IIf(chkUse.Checked = True, "Y", "N")

            iTotalMacCount = CLng("&H" & endno) - CLng("&H" & start) + 1
            If iTotalMacCount <= 0 Then
                result = False
                MessageUtils.ShowError("请检查输入的mac 起始和结束是否正确! ")
                result = False
                Return False
            End If
            If buttonStatus = EnumStatus.NewAdd Then
                sql = " INSERT INTO dbo.m_Macaddress_Part_t(PartID,MacMin,MacMax,TotalMacCount,RemainMacCount,UsedMaxMac,CreateUserID,Intime) " & _
                 " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate())"
                sql = String.Format(sql, partid, start, endno, iTotalMacCount, iTotalMacCount, "", IIf(SysMessageClass.UseId = "", "sysuser", SysMessageClass.UseId))
                DbOperateUtils.ExecSQL(sql.ToString)
            End If

            If buttonStatus = EnumStatus.Edit Then
                sql = "UPDATE dbo.m_Macaddress_Part_t SET UpdateTime=getdate(),UpdateUserID='{1}',USEY='{2}' WHERE ID='{0}'"
                sql = String.Format(sql, id, SysMessageClass.UseId, use)
                DbOperateUtils.ExecSQL(sql.ToString)
            End If


        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmPartMacAddress", "Save", "FrmPartMacAddress")
            result = False
        End Try
        Return result
    End Function
    'Private Function SaveData() As Boolean
    '    Dim sql As String = ""
    '    Dim partid As String = TxtTavcPart.Text.ToUpper.Trim
    '    Dim start As String = txtStartNo.Text.ToUpper.Trim
    '    Dim endno As String = txtEndNum.Text.ToUpper.Trim
    '    Dim id As String = lblID.Text
    '    Dim result As Boolean = True
    '    Dim use As String = ""
    '    Try
    '        use = IIf(chkUse.Checked = True, "Y", "N")
    '        If buttonStatus = EnumStatus.NewAdd Then
    '            sql = "INSERT INTO dbo.m_PartMacaddress_t(PARTID,MacStartNo,MacEndNo,Usey,CreateUserID) VALUES('{0}','{1}','{2}','{3}','{4}')"
    '            sql = String.Format(sql, partid, start, endno, use, SysMessageClass.UseId)
    '            DbOperateUtils.ExecSQL(sql.ToString)
    '        End If
    '        If buttonStatus = EnumStatus.Edit Then
    '            sql = "UPDATE dbo.m_PartMacaddress_t SET MacStartNo='{0}',MacEndNo='{1}',UpdateTime=getdate(),UpdateUserID='{3}',USEY='{4}' WHERE ID='{2}'"
    '            sql = String.Format(sql, start, endno, id, SysMessageClass.UseId, use)
    '            DbOperateUtils.ExecSQL(sql.ToString)
    '        End If
    '    Catch ex As Exception
    '        MessageUtils.ShowError(ex.Message)
    '        SysMessageClass.WriteErrLog(ex, "FrmPartMacAddress", "Save", "BasicM")
    '        result = False
    '    End Try
    '    Return result
    'End Function
    Private Function CheckData() As Boolean
        Dim result As Boolean = True
        If TxtTavcPart.Text.Trim = "" Then
            MessageUtils.ShowError("料件不能为空,请检查!")
            result = False
            Return result
        End If
        If txtMacMin.Text.Trim = "" Then
            MessageUtils.ShowError("起始值不能为空,请检查!")
            result = False
            Return result
        End If
        If txtMacMax.Text.Trim = "" Then
            MessageUtils.ShowError("结束值不能为空,请检查!")
            result = False
            Return result
        End If
        Dim sql As String = "SELECT  [PartID] ,[MacMin] ,[MacMax] FROM m_Macaddress_Part_t WHERE PartID='" & TxtTavcPart.Text.Trim & "' AND  MacMin='" & txtMacMin.Text.Trim & "' AND MacMax='" & txtMacMax.Text.Trim & "'"

        Try

            Dim startnum As Long = CLng("&H" & txtMacMin.Text.Trim.ToUpper)
            Dim endnum As Long = CLng("&H" & txtMacMax.Text.Trim.ToUpper)
            If startnum > endnum Then
                MessageUtils.ShowError("起始值必须小于结束值,请检查!")
                result = False
                Return result
            End If
            If sql <> "" And buttonStatus = EnumStatus.NewAdd Then
                Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("已维护此料号区间!")
                    result = False
                    Return result
                End If
            End If
        Catch ex As Exception
            MessageUtils.ShowError("输入的不是16进制,请检查!" + ex.ToString)
            result = False
            Return result
        End Try
        Return result
    End Function

    Private Sub UnDo_Click(sender As Object, e As EventArgs) Handles UnDo.Click
        Me.lblID.Text = ""
        Me.TxtTavcPart.Text = ""
        Me.txtMacMin.Text = ""
        Me.txtMacMax.Text = ""
        Me.UnDo.Enabled = False
        Me.Save.Enabled = False
        Me.TxtTavcPart.Enabled = True
        Me.txtMacMin.Enabled = True
        Me.txtMacMax.Enabled = True
    End Sub

    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles FileRefresh.Click

        SearchRecord(Me.TxtTavcPart.Text.Trim)

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim sql As String = ""
        Dim partid As String = TxtTavcPart.Text.ToUpper.Trim
        Dim start As String = txtMacMin.Text.ToUpper.Trim
        Dim endno As String = txtMacMax.Text.ToUpper.Trim
        If dgvMac.CurrentRow.Cells(0).Value = Nothing Then
            MessageUtils.ShowError("请选择删除的行!")
            Return
        End If

        lblID.Text = dgvMac.CurrentRow.Cells(0).Value
        Dim id As String = lblID.Text
        sql = "UPDATE dbo.m_Macaddress_Part_t SET USEY='N',UpdateTime=getdate(),UpdateUserID='{1}' WHERE ID='{0}'"
        sql = String.Format(sql, id, SysMessageClass.UseId)
        DbOperateUtils.ExecSQL(sql.ToString)
        SearchRecord("")
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub
End Class