Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame


''' <summary>
''' 修改者： 黄广都
''' 修改日： 2018/05/29
''' 修改内容：
''' </summary>
''' <remarks>非当日/月保养</remarks>
Public Class FrmAssetNonDayMaintenance


#Region "事件"

    Private Sub FrmAssetNonDayMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbQuarter.Text = EquManageCommon.GetQuarter()
        dtpStartDate.Value = Date.Now
        dtpEndDate.Value = Date.Now
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        lbMsg.Text = "开始保养,可能需要花费点时间,请勿关闭窗口......"
        If TabControl1.SelectedIndex = 0 Then
            If dtpStartDate.Text > dtpEndDate.Text Then
                MessageUtils.ShowInformation("开始日期不能大于结束日期,请重新选择!")
                Exit Sub
            End If
            SaveDayMaintenance()
        ElseIf TabControl1.SelectedIndex = 1 Then

            If String.IsNullOrEmpty(txtStartYearMon.Text) Then
                MessageUtils.ShowInformation("请输入开始年月!")
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtEndYearMon.Text) Then
                MessageUtils.ShowInformation("请输入结束年月!")
                Exit Sub
            End If

            If txtStartYearMon.Text > txtEndYearMon.Text Then
                MessageUtils.ShowInformation("开始年月不能大于结束年月,请重新输入!")
                Exit Sub
            End If
            SaveMonthMaintenance()
        ElseIf TabControl1.SelectedIndex = 2 Then
            If String.IsNullOrEmpty(txtYear.Text) Then
                MessageUtils.ShowInformation("请输入年份!")
                Exit Sub
            End If
            If txtYear.Text.Length <> 4 Then
                MessageUtils.ShowInformation("请输入年份长度为4位，格式：yyyy(2019)!")
                Exit Sub
            End If
            SaveQuarterMaintenance()
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"

    '保存日保养
    Private Sub SaveDayMaintenance()
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim strSQL As String = "EXEC Exec_InsertAssetMaintenanceDay '{0}','{1}','{2}','{3}','{4}'   "
            strSQL = String.Format(strSQL, dtpStartDate.Text, dtpEndDate.Text,
                                   VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            DbOperateUtils.ExecSQL(strSQL)
            lbMsg.Text = "保养成功!"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetNonDayMaintenance", "SaveDayMaintenance", "sys")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    '保存月保养
    Private Sub SaveMonthMaintenance()
        Dim o_strSql As New StringBuilder
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim strSQL As String = "EXEC Exec_InsertAssetMaintenanceMonth '{0}','{1}','{2}','{3}','{4}'   "
            strSQL = String.Format(strSQL, txtStartYearMon.Text, txtEndYearMon.Text,
                                   VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("保养成功!")
            Me.lbMsg.Text = "保养成功!"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetNonDayMaintenance", "SaveDayMaintenance()", "sys")
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' 季度保养
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveQuarterMaintenance()
        Try
            Dim strSQL As String = "EXEC Exec_InsertAssetMaintenanceQuarter '{0}','{1}','{2}','{3}','{4}'   "
            strSQL = String.Format(strSQL, txtYear.Text, cmbQuarter.Text,
                                   VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            DbOperateUtils.ExecSQL(strSQL)

            MessageUtils.ShowInformation("保养成功!")
            Me.lbMsg.Text = "保养成功!"
        Catch ex As Exception
            MessageUtils.ShowError("季度保养失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

#End Region


End Class