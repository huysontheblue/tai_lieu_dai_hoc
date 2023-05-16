Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmLineClassSpecial

    Public pLineId As String
    Dim iState As Integer = 0

    Private Sub FrmLineClassSpecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLineID.Text = pLineId
        SetStatus(0)
        GetListData()
    End Sub


    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            iState = 0
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
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
                Dim ID As String = Me.dgvQuery.CurrentRow.Cells("ID").Value
                Dim strSQL As String = "UPDATE m_LineClassSpecial_t SET usey='N' WHERE ID ='" & ID & "'"
                DbOperateUtils.ExecSQL(strSQL)
                'Me.dgvQuery.Rows.Remove(Me.dgvQuery.CurrentRow)
                GetListData()

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

            strSQL.AppendFormat(" update m_LineClassSpecial_t set usey = 'N' where LineID = '{0}' ", txtLineID.Text)
            strSQL.AppendFormat(" INSERT INTO m_LineClassSpecial_t(LineID, StartDt, EndDt, Remark, Usey, UserID, Intime)VALUES" &
                                "( '{0}','{1}','{2}',N'{3}','Y','{4}',getdate())",
                                txtLineID.Text, txtTimeStart.Text, txtTimeEnd.Text, txtRemark.Text, VbCommClass.VbCommClass.UseId)

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

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 设置按钮是否可用
    ''' </summary>
    ''' <param name="statusFlag"></param>
    ''' <remarks></remarks>
    Private Sub SetStatus(ByVal statusFlag As Int16)
        Select Case (statusFlag)
            Case 0
                Me.ToolNew.Enabled = True
                Me.toolSave.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True

                Me.ToolDelete.Enabled = True
                Me.ToolExitFrom.Enabled = True
                Me.txtLineID.Enabled = True
            Case 1
                Me.ToolNew.Enabled = False
                Me.toolSave.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolExitFrom.Enabled = False
                Me.txtLineID.Text = ""
        End Select
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
            If (String.IsNullOrEmpty(Me.txtRemark.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "备注不能为空", False)
                Return False
            End If
            If (Me.txtTimeStart.Value.ToString > Me.txtTimeEnd.Value.ToString) Then
                GetMesData.SetMessage(Me.lblMessage, "开始时间不能大于结束时间", False)
                Return False
            End If
            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, ex.ToString, False)
            Return False
        End Try
    End Function

    Private Sub GetListData()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT TOP 500 ID,LineID, StartDt, EndDt,  Usey, Remark, UserID, Intime FROM m_LineClassSpecial_t(nolock) WHERE 1 =1 ")

            If Not String.IsNullOrEmpty(Me.txtLineID.Text.Trim()) Then
                strSQL.AppendLine(" AND LineID LIKE '%" & Me.txtLineID.Text.Trim & "%' ")
            End If
            strSQL.AppendLine(" order by id desc ")

            Dim Dreader As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            dgvQuery.Rows.Clear()
            For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
                dgvQuery.Rows.Add(
                    Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString, _
                    Dreader.Rows(rowIndex).Item(3).ToString, Dreader.Rows(rowIndex).Item(4).ToString, Dreader.Rows(rowIndex).Item(5).ToString, _
                    Dreader.Rows(rowIndex).Item(6).ToString, Dreader.Rows(rowIndex).Item(7).ToString
                    )
            Next

            GetMesData.SetMessage(Me.lblMessage, "数据加载完成", True)
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
            GetMesData.SetMessage(Me.lblMessage, ex.ToString, False)
        End Try
    End Sub

End Class