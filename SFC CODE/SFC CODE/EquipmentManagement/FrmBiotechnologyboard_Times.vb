Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Drawing
Imports MainFrame

Public Class FrmBiotechnologyboard_Times
    Private iSecond As Integer
    Private sql As New System.Text.StringBuilder
    Private sConn As New SysDataBaseClass
    Private styleBlue As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 20), .WrapMode = DataGridViewTriState.True, .BackColor = Color.LightBlue, .ForeColor = Color.Black}
    Private styleWhite As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 20), .WrapMode = DataGridViewTriState.True, .BackColor = Color.White, .ForeColor = Color.Black}
    Private m_strFixWords As String = ""

    Private Sub FrmBiotechnologyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Text = "" : Me.lblRemain.Text = ""
        '1分钟自动刷新
        iSecond = 60 * 1
        EquManageCommon.BindComboxCategory(cboMiddleCategory, "MID")
        Call ShowProdBoard()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        iSecond = iSecond - 1
        If iSecond > 0 Then
            lblRemain.Text = iSecond.ToString + "秒后刷新"
        Else
            lblRemain.Text = ""
        End If
        If iSecond < 0 Then
            Call ShowProdBoard()
            iSecond = 60 * 1
        End If
    End Sub

    Private Sub ShowProdBoard()
        Dim Index As Integer = 1
        Try
            Using dt As DataTable = GetAllMoEquipmentInfo()
                If dt.Rows.Count = 0 Then
                    dgvEquUsedTimes.Rows.Clear()
                    Label1.Text = "暂无需要处理的工治具"
                    m_strFixWords = Me.Label1.Text
                Else
                    Label1.Text = "待处理列表如下 "
                    ' dgvEquUsedTimes.Rows.Clear()


                    Dim o_dt As New DataTable
                    o_dt = CType(dgvEquUsedTimes.DataSource, DataTable)
                    If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                        o_dt.Rows.Clear()
                    End If
                    dgvEquUsedTimes.DataSource = o_dt

                    'For Each row As DataRow In dt.Rows
                    '    '序号,申请人,工单编号,生产料号,工治具料号,课别,线别,剩余需求,状态,申请时间,申请时长,厂区,利润中心
                    '    dgvEquipmentManual.Rows.Add(Index, row("AppUserName").ToString, _
                    '                               row("MOID").ToString, row("PNumber").ToString, row("EquipmentPNumber").ToString, _
                    '                               row("DeptID").ToString, row("Line").ToString, _
                    '                               row("Qty").ToString, row("Status").ToString, _
                    '                               row("Intime").ToString, row("ApplayTimeSpan").ToString, _
                    '                               row("FactoryName").ToString, row("Profitcenter").ToString)
                    '    If Index Mod 2 = 0 Then
                    '        dgvEquipmentManual.Rows(Index - 1).DefaultCellStyle = styleWhite
                    '    Else
                    '        dgvEquipmentManual.Rows(Index - 1).DefaultCellStyle = styleBlue
                    '    End If
                    '    Index += 1
                    'Next

                    'dgvEquipmentManual.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    'dgvEquipmentManual.Columns("AppUserName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.Columns("EquipmentPNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.Columns("DeptID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.Columns("Line").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.Columns("Intime").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgvEquipmentManual.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True



                    Dim strSQL As String = String.Format(" exec Exec_Biotechnologyboard_UsedTimes '{0}','{1}'", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
                    Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

                    dgvEquUsedTimes.DataSource = ds.Tables(0)

                End If
            End Using
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

    Public Function GetAllMoEquipmentInfo() As DataTable

        Dim strSQL As String = String.Format(" exec Exec_Biotechnologyboard_UsedTimes '{0}','{1}'", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

        Return ds.Tables(0)
    End Function

    Private Sub chkStop_CheckedChanged(sender As Object, e As EventArgs) Handles chkStop.CheckedChanged
        If chkStop.Checked Then
            Me.Timer1.Enabled = False
        Else
            Me.Timer1.Enabled = True
        End If
    End Sub

    Private Sub cboMiddleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMiddleCategory.SelectedIndexChanged
        Call ShowProdBoard()
    End Sub

    Private Sub dgvEquUsedTimes_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvEquUsedTimes.DataBindingComplete
        For Each item As DataGridViewRow In dgvEquUsedTimes.Rows
            If Val(item.Cells("RemainCount").Value.ToString) < 0 Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub
End Class