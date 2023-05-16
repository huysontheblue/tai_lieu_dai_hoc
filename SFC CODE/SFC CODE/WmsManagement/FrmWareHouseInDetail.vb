Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmWareHouseInDetail

    Public Mmoid As String

    '初期化
    Private Sub FrmWareHouseInDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.gridView
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
        With Me.gridViewD
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
        txtMoid.Text = Mmoid

        Search()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Search()
    End Sub

    '删除箱记录
    Private Sub toolDeleteCartonid_Click(sender As Object, e As EventArgs) Handles toolDeleteCartonid.Click
        Try
            If MessageUtils.ShowConfirm("你确定删除选择箱数据吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                DeleteCartonId()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '退出
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked Then
            For Each row As DataGridViewRow In gridViewD.Rows
                row.Cells(0).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gridViewD.Rows
                row.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub DeleteCartonId()
        Dim bFlag As Boolean = False
        Dim message As String = ""
        For Each row As DataGridViewRow In gridViewD.Rows
            If row.Cells(0).EditedFormattedValue = True Then
                Dim cartondid As String = row.Cells(1).Value
                Dim strSQL As String =
                             " declare @strmsgid varchar(1),@strmsgText nvarchar(500)" &
                             " exec m_Wh_CartonScanDelete_p '{0}' ,'{1}',@strmsgid output , @strmsgText output " &
                             " select @strmsgid,@strmsgText "
                strSQL = String.Format(strSQL, cartondid, SysMessageClass.UseId)
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0).ToString()
                        Case "0"
                            bFlag = False
                            MessageUtils.ShowError(dt.Rows(0)(1).ToString())
                            Exit Sub
                        Case "1"
                            bFlag = True
                            message = dt.Rows(0)(1).ToString()

                    End Select
                End If
            End If
        Next
        '全部成功后提示信息
        If bFlag = True Then
            MessageUtils.ShowInformation(message)
        End If
        Search()
    End Sub

    Private Sub Search()
        Dim strSQL As String =
            "   SELECT A.moid, MM.partid, MM.Moqty, A.finishqty," &
            "   (CASE  WHEN MM.Moqty -A.finishqty = 0 THEN 1  ELSE 0  END )st" &
            "   FROM   m_mainmo_t MM INNER JOIN (SELECT moid,SUM(qty)finishqty FROM m_WHD_t" &
            "   WHERE  1 = 1 GROUP BY moid ) A  ON  MM.Moid = A.moid AND a.finishqty <> 0 "
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtCartonId.Text) = False Then
            strSQL = String.Format(strSQL, String.Format(" where cartonid = '{0}'", txtCartonId.Text))
        Else
            strSQL = String.Format(strSQL, " where 1 = 1 ")
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtMoid.Text)) = False Then
            strWhere.AppendFormat(" and a.moid = '{0}' ", txtMoid.Text)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtProNo.Text)) = False Then
            strWhere.AppendFormat(" and mm.partid = '{0}' ", txtProNo.Text)
        End If

        strSQL = strSQL + strWhere.ToString

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        gridView.DataSource = dt
        SetWhs(0)
    End Sub

    Private Sub gridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridView.CellClick
        If e.RowIndex = -1 Then Exit Sub

        Try
            SetWhs(e.RowIndex)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetWhs(rowIndex As Integer)
        If gridView.Rows.Count = 0 Then Exit Sub
        Dim Moid As String = Me.gridView.Rows(rowIndex).Cells(0).Value.ToString.Trim

        Dim strSQL As String = " select cartonid, qty,InUserId,inintime from m_WHd_t  " &
                                 " where moid = '{0}' and qty<>0 "
        strSQL = String.Format(strSQL, Moid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Me.gridViewD.DataSource = dt
    End Sub

    Private Sub gridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles gridView.DataBindingComplete
        Dim tempState As String = ""
        Try
            For Each item As DataGridViewRow In gridView.Rows
                tempState = item.Cells("st").Value.ToString
                If tempState = "1" Then
                    item.DefaultCellStyle.ForeColor = Color.Green
                Else
                    item.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception
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