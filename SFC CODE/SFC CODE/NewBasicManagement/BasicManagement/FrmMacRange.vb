Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmMacRange



    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles ToolNewAdd.Click


        'Me.txtPartID.Text = ""
        'Me.txtQty.Text = ""
        Me.txtMacMax.Text = ""
        Me.txtMacMin.Text =""

        'Me.txtPartID.Enabled = True
        'Me.txtQty.Enabled = True

        Me.Save.Enabled = True
        Me.UnDo.Enabled = True
        Me.chkUse.Checked = True

        Me.txtMacMin.Enabled = True
        Me.txtMacMax.Enabled = True

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click

        If checkData() Then
            If SaveData() Then
                Me.SearchRecord("")
                MessageUtils.ShowInformation("保存成功")
            End If
        End If


    End Sub

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing

        '起始值，结束值，最大已分配MAC，MAC总数量, 剩余MAC数量
        Dim sql As String = "SELECT [macMin] ,[MacMax], UsedMaxMac,TotalMacCount,RemainMacCount,CreateUserID,Intime" & _
         "  FROM m_MacaddressM_t a  WHERE 1=1   "
        Try
            If Sqlstring = "" Then
                dt = DbOperateUtils.GetDataTable(sql)
                dgvMac.DataSource = dt
            Else
                sql = sql + Sqlstring
                dt = DbOperateUtils.GetDataTable(sql)
                dgvMac.DataSource = dt
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMacRange", "SearchRecord", "BasicM")
        End Try
    End Sub

    Private Function SaveData() As Boolean
        Dim sql As String = ""
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
                result =False
                MessageUtils.ShowError("请检查输入的mac 起始和结束是否正确! ")
                Exit Function
            End If

            sql = " INSERT INTO dbo.m_MacaddressM_t(MacMin,MacMax,TotalMacCount,RemainMacCount,UsedMaxMac,CreateUserID,Intime) " & _
                  " VALUES('{0}','{1}','{2}','{3}','{4}','{5}',getdate())"
            sql = String.Format(sql, start, endno, iTotalMacCount, iTotalMacCount, "", SysMessageClass.UseId)
            DbOperateUtils.ExecSQL(sql.ToString)
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmMacRange", "Save", "BasicM")
            result = False
        End Try
        Return result
    End Function

    Private Function checkData() As Boolean
        checkData = True
        If Me.txtMacMin.Text.Trim.Length < 12 Then
            checkData = False
            lblMsg.Text = "起始输入的长度为12,请检查是否输入错误..."
            Return checkData
        End If

        If Me.txtMacMin.Text.Trim.Length < 12 Then
            checkData = False
            lblMsg.Text = "MAC结束输入的长度为12,请检查是否输入错误..."
            Return checkData
        End If
        Return checkData
    End Function

    Private Sub FrmMacRange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchRecord("")
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub UnDo_Click(sender As Object, e As EventArgs) Handles UnDo.Click
        Me.lblID.Text = ""
        ' Me.txtPartID.Text = ""
        Me.UnDo.Enabled = False
        Me.Save.Enabled = False
        '  Me.txtPartID.Enabled = True
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        ExcelUtils.LoadDataToExcel(Me.dgvMac, Me.Text)
    End Sub
End Class