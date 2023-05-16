Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmWareHouseOutDetail

    Public outId As String

    Private Sub FrmWareHouseOutDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInvOut.Text = outId
        Search()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Search()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '查询方法
    Private Sub Search()
        With Me.gridView
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
        'ORDER BY Intime DESC 
        Dim strSQL As String =
            "  select distinct top 500  whsd.Outwhid, whsd.ProNo, whsd.LotNo, whsd.Version, CarType, LineName, Code, whsd.Qty, " &
            "  (case when whsd.IsFullCarton = 1 then '是' else '否' end) IsFullCarton, IsFinish " &
            "  from m_WHsDeliver_t whsd left join m_WhsOutD_t whsod on whsd.Outwhid = whsod.Outwhid and whsd.ProNo = whsod.ProNo where 1=1 "

        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtProNo.Text)) = False Then
            strWhere.AppendFormat(" and whsd.ProNo = '{0}' ", txtProNo.Text)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtLotNo.Text)) = False Then
            strWhere.AppendFormat(" and whsd.LotNo = '{0}' ", txtLotNo.Text)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtInvOut.Text)) = False Then
            strWhere.AppendFormat(" and whsd.Outwhid = '{0}' ", txtInvOut.Text)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtCartonid.Text)) = False Then
            strWhere.AppendFormat(" and whsod.CartonID = '{0}' ", txtCartonid.Text)
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtVersion.Text)) = False Then
            strWhere.AppendFormat(" and whsod.Version = '{0}' ", txtVersion.Text)
        End If

        'Dim strOrder As String = " order by whsd.intime desc "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString)

        gridView.DataSource = dt
        'gridView_CellClick(Nothing, Nothing)
    End Sub

    '
    Private Sub gridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridView.CellClick
        If e.RowIndex = -1 Then Exit Sub

        Dim Outwhid As String = Me.gridView.Rows(e.RowIndex).Cells(0).Value.ToString.Trim
        Dim ProNo As String = Me.gridView.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
        Dim LotNo As String = Me.gridView.Rows(e.RowIndex).Cells(2).Value.ToString.Trim
        Dim IsFullCarton As String = Me.gridView.Rows(e.RowIndex).Cells(8).Value.ToString.Trim

        Try
            IsFullCarton = IIf(IsFullCarton = "是", "1", "0")
            Dim strSQL As String = " select CartonID, Qty, UserId, Intime from m_WhsOutD_t " &
                                   " where Outwhid = '{0}'and  ProNo = '{1}' and LotNo= '{2}' and IsFullCarton = '{3}'   "
            strSQL = String.Format(strSQL, Outwhid, ProNo, LotNo, IsFullCarton)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            With Me.gridViewD
                .AutoResizeColumns()
                .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                .ScrollBars = ScrollBars.Both
            End With
            Me.gridViewD.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub gridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles gridView.DataBindingComplete
        Dim tempState As String = ""
        Try
            For Each item As DataGridViewRow In gridView.Rows
                tempState = item.Cells("IsFinish").Value.ToString
                If tempState = "0" Then
                    item.DefaultCellStyle.ForeColor = Color.Red
                Else
                    item.DefaultCellStyle.ForeColor = Color.Green
                End If
            Next
        Catch ex As Exception
            ' SysMessageClass.WriteErrLog(ex, "FrmMachineAllocList", "dgvMachineInfo_DataBindingComplete", "SysPrint")
        End Try
    End Sub


#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridView.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

#Region "Grid行数"
    Private Sub gridViewD_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridViewD.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class