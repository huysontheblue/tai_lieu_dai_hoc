Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmBiotechnologyboard
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
                    dgvEquipmentManual.Rows.Clear()
                    Label1.Text = "暂无请求"
                    m_strFixWords = Me.Label1.Text
                Else
                    Label1.Text = "待处理请求如下 "
                    dgvEquipmentManual.Rows.Clear()
                    For Each row As DataRow In dt.Rows
                        '序号,申请人,工单编号,生产料号,工治具料号,课别,线别,剩余需求,状态,申请时间,申请时长,厂区,利润中心
                        dgvEquipmentManual.Rows.Add(Index, row("AppUserName").ToString, _
                                                   row("MOID").ToString, row("PNumber").ToString, row("EquipmentPNumber").ToString, _
                                                   row("DeptID").ToString, row("Line").ToString, _
                                                   row("Qty").ToString, row("Status").ToString, _
                                                   row("Intime").ToString, row("ApplayTimeSpan").ToString, _
                                                   row("FactoryName").ToString, row("Profitcenter").ToString)
                        If Index Mod 2 = 0 Then
                            dgvEquipmentManual.Rows(Index - 1).DefaultCellStyle = styleWhite
                        Else
                            dgvEquipmentManual.Rows(Index - 1).DefaultCellStyle = styleBlue
                        End If
                        Index += 1
                    Next

                    dgvEquipmentManual.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    dgvEquipmentManual.Columns("AppUserName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.Columns("EquipmentPNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.Columns("DeptID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.Columns("Line").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.Columns("Intime").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvEquipmentManual.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If
            End Using
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

    Public Function GetAllMoEquipmentInfo() As DataTable
        Dim sql As String = ""
        '显示申请状态为（1.待处理）的数据。
        sql = " SELECT DISTINCT TOP 100 A.AppUserName ,A.MOID,A.PNumber," &
             " A.EquipmentPNumber,ISNULL(B.dqc,'') DeptID,A.Line," &
             " REPLACE(QTY,' Set','') Qty,(CAST(A.AStatus1 AS varchar)+'.'+C.TEXT) Status," &
             " A.InTime,DATEDIFF(minute,A.InTime,GETDATE()) ApplayTimeSpan,A.FactoryName , " &
             " A.Profitcenter,A.ID FROM m_Equipment_App_t A " &
             " LEFT JOIN m_Dept_t B ON A.DeptID=B.deptid " &
             " LEFT JOIN m_BaseData_t C ON CAST(A.AStatus1 AS varchar)=C.VALUE " &
             " LEFT JOIN (SELECT TAvcPart,DESCRIPTION  FROM m_PartContrast_t WHERE TYPE='E') D ON A.EquipmentPNumber=D.TAvcPart " &
             " INNER JOIN m_Equipment_t E on  A.EquipmentPNumber = E.PartNumber" &
             " WHERE C.ITEMKEY='EqpAppStatus' AND (A.AStatus1=1)" &
             EquManageCommon.GetFatoryProfitcenter("A")

        '增加查询条件
        If cboMiddleCategory.Text <> "" Then
            sql = sql & String.Format("  AND E.MiddleCategory = '{0}'", cboMiddleCategory.SelectedValue)
        End If

        Dim strOrderby As String = " order by A.intime desc"

        Using dt As DataTable = sConn.GetDataTable(sql + strOrderby)
            Return dt
        End Using
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
End Class