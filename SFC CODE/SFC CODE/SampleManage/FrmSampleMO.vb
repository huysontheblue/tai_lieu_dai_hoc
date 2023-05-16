Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text

Public Class FrmSampleMO
    Public opflag As Int16 = 0  '
    Private m_strOldLineID As String
    Private m_strOldMOQty As String
    Private m_strOldMOIDList As String
    Private m_strOldLineIDList As String
    Private m_strOldMOQtyList As String
    Private m_blnChange As Boolean

    Public Enum enumdgvMO
        SampleNo
        MOID
        LineID
        LineLeader
        MOQty
        MOFinishDate
        UserID
        Intime
    End Enum

    Public Structure stcMO
        Public MOID As String
        Public LineID As String
        Public MOQty As String
    End Structure

    Private Sub FrmSampleMO_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        SampleCom.BindComboxLine(cboLineID)
        ToolbtnState(0)
        BindData()
    End Sub

    '邦定数据
    Private Sub BindData()
        Dim sql As String = ""
        sql = " SELECT SampleNO, a.MOID, a.LineID, c.LineLeader,a.MOQty,b.UserName,a.Intime, " & _
              " Convert(varchar(100), a.MOFinishDate ,23 ) MOFinishDate" & _
              " FROM m_SampleMO_t a LEFT JOIN m_Users_t b ON a.userid = b.userid" & _
              " LEFT JOIN m_SampleLine_t c ON a.LineID = c.LineID" & _
              " WHERE  1=1 AND a.usey='1' and status < 8" & _
              " AND SampleNO = '" & Me.txtSampleNo.Text.Trim & "' "
        sql += " ORDER BY  a.Intime DESC"
        dgvMO.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                dgvMO.Rows.Add(row("SampleNO").ToString(), row("MOID").ToString(), row("LineID").ToString(),
                                   row("LineLeader").ToString(), row("MOQty").ToString(), row("MOFinishDate"),
                                   row("UserName").ToString(), _
                                   row("Intime").ToString())
                m_strOldMOIDList &= IIf(String.IsNullOrEmpty(m_strOldMOIDList), "", ",") + row("MOID").ToString()
                m_strOldLineIDList &= IIf(String.IsNullOrEmpty(m_strOldLineIDList), "", ",") + row("LineID").ToString()
                m_strOldMOQtyList &= IIf(String.IsNullOrEmpty(m_strOldMOQtyList), "", ",") + row("MOQty").ToString()
            Next
            ' TlelCount.Text = dt.Rows.Count
            Me.lblRecordCount.Text = dt.Rows.Count
        End Using
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim o_strLineID As String = "", o_strSQL As String = "", o_strCustID As String = "", o_strEmail As String = ""
        Dim o_strDutyUserID As String = "", o_strDutyUserName As String = ""
        Dim o_strCurrentLineIDList As String = "", o_strCurrentMOQtyList As String = ""
        Dim strdtMOFinishDate As String = String.Empty
        Me.LblMsg.Text = ""
        If Checkdata() = False Then Exit Sub

        If IsNothing(cboLineID.SelectedValue) Then
            o_strLineID = Me.cboLineID.Text.Trim
        Else
            o_strLineID = cboLineID.SelectedValue.ToString.Trim
        End If

        If opflag = 1 Then
            o_strSQL = " SELECT MOID FROM m_SampleMO_t " & _
                       " WHERE 1=1 " & _
                       " AND SampleNo=N'" & Me.txtSampleNo.Text.Trim & "' AND MOID ='" & Me.txtMOID.Text.Trim & "' And usey='1' "
            Dim rowCnt As Integer = DbOperateUtils.GetRowsCount(o_strSQL)
            If rowCnt > 0 Then
                Me.LblMsg.Text = "该工单已经存在!"
                Exit Sub
            End If
            SqlStr.Append("INSERT INTO m_SampleMO_t( SampleNO,MOID, LineID, MOQty, UserID, Intime,useY, MOFinishDate) ")
            SqlStr.Append(" VALUES ( N'" & Me.txtSampleNo.Text.Trim & "',N'" & Me.txtMOID.Text.Trim & "', N'" & o_strLineID & "', '" & Val(Me.txtMOQty.Text.Trim) & "',")
            SqlStr.Append(" '" & SysCheckData.SysMessageClass.UseId & "',GETDATE(), '1','" & dtMOFinishDate.Value.ToShortDateString & "')")
     
            SqlStr.Append("  UPDATE m_Sample_t SET MOID = iif(isnull(moid,'')='','',moid+',') + '" & Me.txtMOID.Text.Trim & "', ")
            SqlStr.Append("  Lineid =  iif(isnull(lineid,'')='','',lineid+',') +'" & o_strLineID & "',")
            SqlStr.Append("  MOQty = iif(isnull(moqty,'')='','',moqty+',') +'" & Val(Me.txtMOQty.Text.Trim) & "'")
            SqlStr.Append("  WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
        ElseIf opflag = 2 Then 'edit
            'Dim o_index As Integer, i As Integer = 0
            'Dim currMO As String = Me.txtMOID.Text.Trim
            'For Each mo As String In m_strOldMOIDList.Split(",")
            '    If mo = currMO Then
            '        o_index = i
            '    End If
            '    i = i + 1
            'Next
            'If m_strOldLineID <> o_strLineID Then
            '    o_strCurrentLineIDList = m_strOldLineIDList.Replace(m_strOldLineID, o_strLineID)
            'Else
            '    o_strCurrentLineIDList = m_strOldLineIDList
            'End If
            'If m_strOldMOQty <> Me.txtMOQty.Text.Trim Then
            '    For j As Integer = 0 To m_strOldMOIDList.Split(",").Length - 1
            '        If j = o_index Then
            '            o_strCurrentMOQtyList &= IIf(String.IsNullOrEmpty(o_strCurrentMOQtyList), "", ",") + Me.txtMOQty.Text.Trim
            '        Else
            '            o_strCurrentMOQtyList &= IIf(String.IsNullOrEmpty(o_strCurrentMOQtyList), "", ",") + m_strOldMOQtyList.Split(",")(j)
            '        End If
            '    Next
            'Else
            '    o_strCurrentMOQtyList = m_strOldMOQtyList
            'End If

            SqlStr.Append(" UPDATE m_SampleMO_t SET MOQty= N'" & Val(Me.txtMOQty.Text.Trim) & "',")
            SqlStr.Append(" LineID='" & Me.cboLineID.SelectedValue.ToString & "',")
            If Me.dtMOFinishDate.Checked = True Then
                SqlStr.Append(" MOFinishDate='" & dtMOFinishDate.Value.ToShortDateString & "',")
            End If
            SqlStr.Append(" intime=getdate(),userid='" & SysCheckData.SysMessageClass.UseId & "' ")
            SqlStr.Append(" WHERE  Sampleno =N'" & Me.txtSampleNo.Text.Trim & "' AND MOID ='" & Me.txtMOID.Text.Trim & "' ")

            'SqlStr.Append("  UPDATE m_Sample_t SET moid ='" & m_strOldMOIDList & "'")
            'SqlStr.Append("  Lineid = '" & o_strCurrentLineIDList & "',")
            'SqlStr.Append("  MOQty = '" & o_strCurrentMOQtyList & "'")
            'SqlStr.Append("  WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")

            End If
            Try
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                BindData()
                opflag = 0
                ToolbtnState(0)
                ' ClearUIValue(opflag)
                dgvMO.Enabled = True
                MessageUtils.ShowInformation("保存成功")

                Me.Close()
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "FrmSampleMO", "toolSave_Click", "Sample")
                Exit Sub
            End Try
    End Sub

    Private Function Checkdata() As Boolean
        If String.IsNullOrEmpty(Me.txtMOID.Text) Then
            MessageUtils.ShowError("工单不能为空!")
            Return False
        End If
        If String.IsNullOrEmpty(Me.cboLineID.Text) Then
            MessageUtils.ShowError("线别不能为空!")
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtMOQty.Text) Then
            MessageUtils.ShowError("数量不能为空!")
            Return False
        End If
        Return True
    End Function

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.cboLineID.SelectedIndex = -1
        ' txtLineLeaderID.Text = ""
        ' Me.txtLineManQty.Text = ""
        opflag = 1
        ToolbtnState(1)
        ' Me.ChkUsey.Checked = True 'Default
        Me.LblMsg.Text = ""
        ' Me.ToolReUse.Enabled = False 'Add by cq 20151222
        m_blnChange = True
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0  ''初始查詢狀態
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                ' Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                ' Me.toolQuery.Enabled = True
                'GroupBox
                'Me.CobDept.Enabled = True
                'Me.ActiveControl = Me.CobDept
                Me.txtMOID.Enabled = False
            Case 1
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                'Me.toolQuery.Enabled = False
                'GroupBox
                ' CobDept.Enabled = IIf(opflag = 1, True, False)
                Me.txtMOID.Enabled = True
            Case 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                ' Me.toolQuery.Enabled = False
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                ' Me.toolQuery.Enabled = True
                'GroupBox
                'Me.CobDept.Enabled = True
                'Me.ActiveControl = Me.CobDept
        End Select
    End Sub


    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvMO.Rows.Count = 0 OrElse Me.dgvMO.CurrentRow Is Nothing Then Exit Sub
        Dim strMOFinishDate As String = String.Empty

        ' CobDept.SelectedIndex = Me.CobDept.FindString(DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.DutyDeptName).Value))


        Me.txtMOID.Text = DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.MOID).Value)

        Me.cboLineID.Text = DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.LineID).Value)
        m_strOldLineID = Me.cboLineID.Text.Trim

        Me.txtMOQty.Text = DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.MOQty).Value)
        m_strOldMOQty = Me.txtMOQty.Text.Trim

        strMOFinishDate = DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.MOFinishDate).Value)

        If String.IsNullOrEmpty(strMOFinishDate) Then
            Me.dtMOFinishDate.Checked = False
        Else
            Me.dtMOFinishDate.Value = DbOperateUtils.DBNullToStr(dgvMO.CurrentRow.Cells(enumdgvMO.MOFinishDate).Value)
        End If
        ' txtLineManQty.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineman).Value)
        opflag = 2
        ToolbtnState(2)
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opflag = 0
        ToolbtnState(0)
        ClearUIValue(opflag)
        ' Me.ToolReUse.Enabled = True
    End Sub

    Private Sub ClearUIValue(ByVal flag As Integer)
        Select Case flag
            Case 0 'default
                ' Me.CobDept.Text = ""
                Me.LblMsg.Text = ""
            Case Else
        End Select
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        If Me.dgvMO.Rows.Count = 0 OrElse Me.dgvMO.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择需要删除的工单!")
            Exit Sub
        End If
        Dim lsSQL As String = String.Empty

        Try
            'If MessageUtils.ShowConfirm("确定要报废吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim strMOID As String = Me.dgvMO.Item("MOID", Me.dgvMO.CurrentRow.Index).Value.ToString.Trim()

            DbOperateUtils.ExecSQL(" UPDATE  m_SampleMO_t  SET usey=0 where SampleNo=N'" + Me.txtSampleNo.Text.Trim + "'  AND moid ='" & strMOID & "'")
            MessageUtils.ShowInformation("该工单已报废!")
            BindData()
            ' End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub FrmSampleMO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim SqlStr As New StringBuilder
        Dim o_strNowMOIDList As String = "", o_strNowLineIDList As String = "", o_strNowMOQtyList As String = ""
        For Each dr As DataGridViewRow In Me.dgvMO.Rows
            o_strNowMOIDList &= IIf(String.IsNullOrEmpty(o_strNowMOIDList), "", ",") + dr.Cells(enumdgvMO.MOID).Value
            o_strNowLineIDList &= IIf(String.IsNullOrEmpty(o_strNowLineIDList), "", ",") + dr.Cells(enumdgvMO.LineID).Value
            o_strNowMOQtyList &= IIf(String.IsNullOrEmpty(o_strNowMOQtyList), "", ",") + dr.Cells(enumdgvMO.MOQty).Value
        Next
        SqlStr.Append("  UPDATE m_Sample_t SET moid ='" & o_strNowMOIDList & "',")
        SqlStr.Append("  Lineid = '" & o_strNowLineIDList & "',")
        SqlStr.Append("  MOQty = '" & o_strNowMOQtyList & "'")
        SqlStr.Append("  WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")

        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleMO", "FormClosing", "Sample")
        End Try
    End Sub

    Private Sub txtMOQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMOQty.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtMOQty.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtMOQty.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub
End Class