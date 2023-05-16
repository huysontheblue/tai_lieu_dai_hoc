Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports Aspose.Cells
Imports System.Text
Imports MainFrame
Imports SysBasicClass


''' <summary>
''' 修改者： 黄广都
''' 修改日： 2016/11/23
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>公共选择设备、工治具窗口</remarks>
Public Class FrmSelectEquipment

#Region "事件"
    Private Sub FrmSelectEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
        Me.txtCondition.Focus()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        BindGrid()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvEqui_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvEqui.CellBeginEdit
        If e.ColumnIndex > 0 Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "方法"
    Private Sub BindGrid()
        Try
            Dim sbSql As New StringBuilder
            '查询料件资料
            sbSql.Append(" SELECT top 200 A.AssetNO , A.AssetNAME , A.Model , ")
            sbSql.Append(" A.KeeperName ,A.STORAGE, A.CreateUserID+'/'+E.UserName as UserName ")
            sbSql.Append(" FROM M_Asset_T(NOLOCK) A   LEFT JOIN m_Users_t E ON A.CreateUserID=E.UserID ")
            If Not String.IsNullOrEmpty(Me.txtCondition.Text.Trim) Then
                sbSql.Append(String.Format(" where A.AssetNO like'%{0}%' or A.AssetNAME like '%{0}%' or A.Model  like '%{0}%' ", txtCondition.Text.Trim))
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sbSql.ToString())

            Me.dgvEqui.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSelectEquipment", "BindGrid()", "sys")
        End Try
    End Sub
#End Region

#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvEqui.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

  
End Class