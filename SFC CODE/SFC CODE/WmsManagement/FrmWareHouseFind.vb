Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmWareHouseFind

    Private Sub FrmWareHouseFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.dgvWhsD
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

    '退出
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Search()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '查询方法
    Private Sub Search()
        'ORDER BY Intime DESC 
        Dim strSQL As String =
            " SELECT distinct CartonID, PartId, Qty, Location, Status, InUserId, InIntime, OutUserId,OutIntime  FROM m_WHd_t where 1 = 1 "
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtPartID.Text)) = False Then
            strWhere.AppendFormat(" and PartId = '{0}' ", txtPartID.Text)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtCartonId.Text)) = False Then
            strWhere.AppendFormat(" and CartonID = '{0}' ", txtCartonId.Text)
        End If
    
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString)

        dgvWhsD.DataSource = dt
    End Sub

    Private Sub dgvWhsD_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvWhsD.DataBindingComplete
        Dim tempState As String = ""
        Try
            For Each item As DataGridViewRow In dgvWhsD.Rows
                tempState = item.Cells("Status").Value.ToString
                If tempState = "0" Then
                    item.DefaultCellStyle.BackColor = Color.Gray
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

End Class