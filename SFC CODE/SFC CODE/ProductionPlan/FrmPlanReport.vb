
'--生产排单查询
'--Create by :　马锋
'--Create date :　2017/03/16
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmPlanReport

#Region "窗体事件"

    Private Sub FrmPlanReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvPlanWorkingHours.AutoGenerateColumns = False
            Me.dtpStartDate.Value = Now.AddDays(-1)
            Me.dtpEndDate.Value = Now.AddDays(1)
            LoadDate()
            Me.cboDept.Text = "ALL"
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If dtpStartDate.Value > dtpEndDate.Value Then
                GetMesData.SetMessage(Me.lblMessage, "起始時間不能大於結束時間!", False)
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(1), @RTMSG NVARCHAR(512)")
            strSQL.AppendLine(" EXEC GetPlanReport @RTVALUE OUTPUT, @RTMSG OUTPUT, '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & Me.txtMOId.Text.Trim & "', '" & Me.txtPartId.Text.Trim & "', '" & Me.dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00" & "', '" & Me.dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" & "', '" & Me.cboDept.SelectedValue & "', '" & Me.txtLineId.Text.Trim & "' , '" & Me.cboQueryType.SelectedValue & "' ")

            Me.dgvPlanWorkingHours.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "方法"

    Private Sub LoadDate()
        Try
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT djc, dqc FROM m_dept_t WHERE Factoryid='" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "' AND usey = 'Y'")

            If Not dtTemp Is Nothing And dtTemp.Rows.Count > 0 Then
                Dim drTemp As DataRow
                drTemp = dtTemp.NewRow
                drTemp(0) = "ALL"
                drTemp(1) = "ALL"
                dtTemp.Rows.Add(drTemp)
            End If

            Me.cboDept.DisplayMember = "dqc"
            Me.cboDept.ValueMember = "djc"
            Me.cboDept.DataSource = dtTemp

            Dim dt As DataTable = New DataTable("dt")
            dt.Columns.Add("dtText")
            dt.Columns.Add("dtValue")

            Dim drTypeTemp As DataRow
            drTypeTemp = dt.NewRow
            drTypeTemp(0) = "未派配"
            drTypeTemp(1) = "0"
            dt.Rows.Add(drTypeTemp)

            drTypeTemp = dt.NewRow
            drTypeTemp(0) = "已派配"
            drTypeTemp(1) = "1"
            dt.Rows.Add(drTypeTemp)

            cboQueryType.DataSource = dt
            cboQueryType.DisplayMember = "dtText"
            cboQueryType.ValueMember = "dtValue"

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

End Class