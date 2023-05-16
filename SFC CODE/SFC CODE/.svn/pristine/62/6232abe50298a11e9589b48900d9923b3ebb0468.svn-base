Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Drawing


Public Class FrmProductionLineBoard
    Private iSecond As Integer
    Private sql As New System.Text.StringBuilder
    Private sConn As New SysDataBaseClass
    Private styleBlue As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 20), .WrapMode = DataGridViewTriState.True, .BackColor = Color.LightBlue, .ForeColor = Color.Black}
    Private styleWhite As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 20), .WrapMode = DataGridViewTriState.True, .BackColor = Color.White, .ForeColor = Color.Black}

    Private Sub FrmProductionLineBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Text = ""
        '1分钟自动刷新
        iSecond = 60 * 1
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
                    dgvProductionLine.Rows.Clear()
                    Label1.Text = "暂无请求"
                Else
                    Label1.Text = "已备料如下:"
                    dgvProductionLine.Rows.Clear()
                    For Each row As DataRow In dt.Rows
                        '序号,申请人,工单编号,生产料号,工治具料号,课别,线别,剩余需求,状态,申请时间,申请时长,厂区,利润中心
                        dgvProductionLine.Rows.Add(Index, row("AppUserName").ToString, _
                                                   row("MOID").ToString, row("PNumber").ToString, row("EquipmentPNumber").ToString, _
                                                   row("DeptID").ToString, row("Line").ToString, _
                                                   row("Qty").ToString, row("Status").ToString, _
                                                   row("Intime").ToString, row("ApplayTimeSpan").ToString, _
                                                   row("FactoryName").ToString, row("Profitcenter").ToString)
                        If Index Mod 2 = 0 Then
                            dgvProductionLine.Rows(Index - 1).DefaultCellStyle = styleWhite
                        Else
                            dgvProductionLine.Rows(Index - 1).DefaultCellStyle = styleBlue
                        End If
                        Index += 1
                    Next
                    dgvProductionLine.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    dgvProductionLine.Columns("AppUserName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProductionLine.Columns("EquipmentPNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProductionLine.Columns("DeptID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProductionLine.Columns("Line").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProductionLine.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProductionLine.Columns("Intime").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End Using
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

    Public Function GetAllMoEquipmentInfo() As DataTable
        Dim sql As String = ""
        '显示申请状态为（1.待处理）的数据。
        sql = " SELECT DISTINCT TOP 100 A.AppUserName ,A.MOID,A.PNumber," & _
             " A.EquipmentPNumber,ISNULL(B.dqc,'') DeptID,A.Line," & _
             " REPLACE(QTY,' Set','') Qty,(CAST(A.AStatus1 AS varchar)+'.'+C.TEXT)　Status," & _
             " InTime,DATEDIFF(minute,InTime,GETDATE()) ApplayTimeSpan,A.FactoryName , " & _
             " A.Profitcenter,A.ID FROM m_Equipment_App_t A " & _
             " LEFT JOIN m_Dept_t B ON A.DeptID=B.deptid " & _
             " LEFT JOIN m_BaseData_t C ON CAST(A.AStatus1 AS varchar)=C.VALUE " & _
             " LEFT JOIN (SELECT TAvcPart,DESCRIPTION  FROM m_PartContrast_t WHERE TYPE='E') D ON A.EquipmentPNumber=D.TAvcPart " & _
             " WHERE C.ITEMKEY='EqpAppStatus' AND A.AStatus1=3" &
            EquManageCommon.GetFatoryProfitcenter("A")
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
End Class