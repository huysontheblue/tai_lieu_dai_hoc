Imports MainFrame
Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmLineClass

    Dim iState As Integer = 0


#Region "初始化"

    Private Sub FrmLineClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sConn As New SysDataBaseClass
            sConn.GetControlright(Me)

            SetStatus(0)

            BMComDB.BindComboxClass(cmbClass)
            GetBaseData()
            GetListData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region


#Region "事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            iState = 0
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要修改数据", False)
                Exit Sub
            End If
            iState = 1
            SetStatus(1)

            Me.txtLineID.Text = Me.dgvQuery.CurrentRow.Cells("LineID").Value
            Me.cmbClass.Text = Me.dgvQuery.CurrentRow.Cells("DClass").Value
            Me.chkUsey.Checked = IIf(Me.dgvQuery.CurrentRow.Cells("Usey").Value = "Y", True, False)
            txtLineID.Enabled = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要删除的数据", False)
                Exit Sub
            End If
            Dim msg As String = "确定要删除线别" & Me.dgvQuery.CurrentRow.Cells("LineID").Value & "?"
            If MessageUtils.ShowConfirm(msg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Dim strSQL As String = "UPDATE m_LineClass_t SET usey='N' where LineID ='" & Me.dgvQuery.CurrentRow.Cells("LineID").Value & "'"
                DbOperateUtils.ExecSQL(strSQL)
                Me.dgvQuery.Rows.Remove(Me.dgvQuery.CurrentRow)
                GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            If (Not CheckSave()) Then
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            Dim dClass As String = Me.cmbClass.Text.Trim.Split("-")(0)

            If iState = 0 Then '新增保存
                strSQL.AppendLine(" SELECT LineID FROM m_LineClass_t WHERE LineID = '" & Me.txtLineID.Text.Trim & "' AND DClass=N'" & dClass & "'")
                If DbOperateUtils.GetDataTable(strSQL.ToString).Rows.Count > 0 Then
                    MessageBox.Show("已存在相同线别的班别！")
                    Exit Sub
                Else
                    strSQL.Remove(0, strSQL.Length)
                    strSQL.AppendLine(" INSERT INTO m_LineClass_t(LineID, DClass, Usey, UserID, Intime)VALUES( '" & Me.txtLineID.Text.Trim & "', N'" &
                                      dClass & "', '" & IIf(Me.chkUsey.Checked, "Y", "N") & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                End If
            Else '修改保存
                strSQL.Remove(0, strSQL.Length)
                strSQL.AppendLine("UPDATE m_LineClass_t SET DClass=N'" & dClass & "',Usey='" & IIf(Me.chkUsey.Checked, "Y", "N") &
                                  "',UserID='" & VbCommClass.VbCommClass.UseId & "', Intime=GETDATE() WHERE LineID = '" &
                                  Me.txtLineID.Text.Trim & "'")
            End If
            DbOperateUtils.ExecSQL(strSQL.ToString)
            SetStatus(0)
            GetListData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetListData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetListData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub


    Private Sub toolSpecialScanSet_Click(sender As Object, e As EventArgs) Handles toolSpecialScanSet.Click
        Dim frm As FrmLineClassSpecial = New FrmLineClassSpecial

        'If dgvQuery.CurrentRow.Index > -1 Then
        '    frm.pLineId = dgvQuery.SelectedCells (
        'End If

        frm.ShowDialog()
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region


#Region "方法"
    ''' <summary>
    ''' 设置按钮是否可用
    ''' </summary>
    ''' <param name="statusFlag"></param>
    ''' <remarks></remarks>
    Private Sub SetStatus(ByVal statusFlag As Int16)
        Select Case (statusFlag)
            Case 0
                Me.ToolNew.Enabled = IIf(ToolNew.Tag = "YES", True, False)
                Me.ToolEdit.Enabled = IIf(ToolEdit.Tag = "YES", True, False)
                Me.toolSpecialScanSet.Enabled = IIf(toolSpecialScanSet.Tag = "YES", True, False)
                Me.toolSave.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True

                Me.ToolDelete.Enabled = True
                Me.ToolExitFrom.Enabled = True
                Me.txtLineID.Enabled = True
                Me.chkUsey.Checked = True
            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolSave.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolExitFrom.Enabled = False
                Me.txtLineID.Text = ""
        End Select
    End Sub

    ''' <summary>
    ''' 查询班别数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetListData()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT LineID,DClass + '-' + CASE WHEN  DClass = 'D001' THEN '白班' ELSE'夜班' end DClassName , Usey, UserID, Intime " &
                              "FROM m_LineClass_t WHERE 1 =1 and Usey='" & IIf(Me.chkUsey.Checked, "Y", "N") & "'")

            If Not String.IsNullOrEmpty(Me.txtLineID.Text.Trim()) Then
                strSQL.AppendLine(" AND LineID LIKE '%" & Me.txtLineID.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.cmbClass.Text.Trim()) Then
                strSQL.AppendLine(" AND DClass = '" & Me.cmbClass.Text.Trim.Split("-")(0) & "' ")
            End If

            Dim Dreader As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            dgvQuery.Rows.Clear()
            For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
                dgvQuery.Rows.Add(
                    Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString, _
                    Dreader.Rows(rowIndex).Item(3).ToString, Dreader.Rows(rowIndex).Item(4).ToString
                    )
            Next
            lblRecord.Text = Me.dgvQuery.Rows.Count

            GetMesData.SetMessage(Me.lblMessage, "数据加载完成", True)
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
            GetMesData.SetMessage(Me.lblMessage, ex.ToString, False)
        End Try
    End Sub

    Private Sub GetBaseData()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine(" SELECT DISTINCT ClassName, StartDt, EndDt FROM m_KanbanClass_t WHERE classtype like 'D%' ")

            Dim Dreader As DataTable

            dgvBase.Rows.Clear()
            Dreader = DbOperateUtils.GetDataTable(strSQL.ToString)
            For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
                dgvBase.Rows.Add(
                    Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString
                    )
            Next
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
            GetMesData.SetMessage(Me.lblMessage, ex.ToString, False)
        End Try
    End Sub


    ''' <summary>
    ''' 资料填写检查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSave() As Boolean
        Try
            If (String.IsNullOrEmpty(Me.txtLineID.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "线别不能为空", False)
                Return False
            End If
            If (Me.txtLineID.Text.Trim.Length < 3) Then
                GetMesData.SetMessage(Me.lblMessage, "线别不能少于三位", False)
                Return False
            End If
            If (String.IsNullOrEmpty(Me.cmbClass.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择上班时间段！", False)
                Return False
            End If
            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, ex.ToString, False)
            Return False
        End Try
    End Function

#End Region

#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvQuery.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub


#End Region


End Class