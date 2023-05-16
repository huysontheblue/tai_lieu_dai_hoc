
'--工单系列别资料维护
'--Create by :　马锋
'--Create date :　2017/02/13
'--Update date :  
'--Ver : V01
'更新者：田玉琳
'更新日期：20190614
'更新内容：为SAP开发准备


#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class FrmSeriesMaster
    Dim ty As Integer = 0
#Region "窗体事件"

    Private Sub FrmSeriesMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            SetStatus(0)
            GetSeries()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            ty = 0
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
            ty = 1
            SetStatus(1)

            Me.txtSeriesID.Text = Me.dgvQuery.CurrentRow.Cells("SeriesID").Value
            Me.txtSeriesName.Text = Me.dgvQuery.CurrentRow.Cells("SeriesName").Value
            Me.chkUsey.Checked = IIf(Me.dgvQuery.CurrentRow.Cells("Usey").Value = "Y", True, False)
            txtSeriesID.Enabled = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    ''' <summary>
    ''' 删除系列别
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要删除的数据", False)
                Exit Sub
            End If
            Dim msg As String = "确定要删除系列别" & Me.dgvQuery.CurrentRow.Cells("SeriesName").Value & "?"
            Dim Response As String = MsgBox(msg, vbYesNo + vbCritical + vbDefaultButton1, "提示")
            If Response = vbYes Then
                Dim strSQL As String = "UPDATE m_Series_t SET usey='N' where SeriesID ='" & Me.dgvQuery.CurrentRow.Cells("SeriesID").Value & "'"
                'Dim strSQL As String = "delete from m_Series_t where SeriesID ='" & Me.dgvQuery.CurrentRow.Cells("SeriesID").Value & "'"
                DbOperateUtils.ExecSQL(strSQL)
                Me.dgvQuery.Rows.Remove(Me.dgvQuery.CurrentRow)
                GetMesData.SetMessage(Me.lblMessage, "删除成功", False)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            If (Not CheckSave()) Then
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            If ty = 0 Then '新增保存
                strSQL.AppendLine(" SELECT SeriesID FROM m_Series_t WHERE SeriesID = '" & Me.txtSeriesID.Text.Trim & "' or SeriesName=N'" & Me.txtSeriesName.Text.Trim & "'")
                If DbOperateUtils.GetDataTable(strSQL.ToString).Rows.Count > 0 Then
                    MessageBox.Show("已存在相同系列别代码或名称！")
                    Exit Sub
                Else
                    strSQL.Remove(0, strSQL.Length)
                    strSQL.AppendLine(" INSERT INTO m_Series_t(SeriesID, SeriesName, Usey, SeriesCreateUserId, SeriesCreateTime)VALUES( '" & Me.txtSeriesID.Text.Trim & "', N'" & Me.txtSeriesName.Text.Trim & "', '" & IIf(Me.chkUsey.Checked, "Y", "N") & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                End If
            Else '修改保存
                strSQL.Remove(0, strSQL.Length)
                strSQL.AppendLine("UPDATE m_Series_t SET SeriesName=N'" & Me.txtSeriesName.Text.Trim & "',Usey='" & IIf(Me.chkUsey.Checked, "Y", "N") & "',SeriesCreateUserId='" & VbCommClass.VbCommClass.UseId & "', SeriesCreateTime=GETDATE() WHERE SeriesID = '" & Me.txtSeriesID.Text.Trim & "'")
            End If
            DbOperateUtils.ExecSQL(strSQL.ToString)
            SetStatus(0)
            GetSeries()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetSeries()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetSeries()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "退出异常", False)
        End Try
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
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.toolSave.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True

                Me.ToolDelete.Enabled = True
                Me.ToolExitFrom.Enabled = True
                Me.txtSeriesID.Enabled = True
                Me.chkUsey.Checked = True
            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolSave.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolExitFrom.Enabled = False
                Me.txtSeriesID.Text = ""
                Me.txtSeriesName.Text = ""
        End Select
    End Sub

    ''' <summary>
    ''' 查询系列别数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetSeries()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT   SeriesID, SeriesName, Usey, SeriesCreateUserId, SeriesCreateTime FROM m_Series_t WHERE 1=1 and Usey='" & IIf(Me.chkUsey.Checked, "Y", "N") & "'")

            If Not String.IsNullOrEmpty(Me.txtSeriesID.Text.Trim()) Then
                strSQL.AppendLine(" AND SeriesID LIKE '%" & Me.txtSeriesID.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.txtSeriesName.Text.Trim()) Then
                strSQL.AppendLine(" AND SeriesName LIKE N'%" & Me.txtSeriesName.Text.Trim & "%' ")
            End If

            Dim Dreader As DataTable

            dgvQuery.Rows.Clear()

            Dreader = DbOperateUtils.GetDataTable(strSQL.ToString)
            For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
                dgvQuery.Rows.Add(
                    Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString, _
                    Dreader.Rows(rowIndex).Item(3).ToString, Dreader.Rows(rowIndex).Item(4).ToString
                    )
            Next
            lblRecord.Text = Me.dgvQuery.Rows.Count

            GetMesData.SetMessage(Me.lblMessage, "数据加载完成", False)
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
            If (String.IsNullOrEmpty(Me.txtSeriesID.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "代码不能为空", False)
                Return False
            End If
            If (Me.txtSeriesID.Text.Trim.Length < 3) Then
                GetMesData.SetMessage(Me.lblMessage, "代码不能少于三位", False)
                Return False
            End If
            If (String.IsNullOrEmpty(Me.txtSeriesName.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "名称不能为空", False)
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