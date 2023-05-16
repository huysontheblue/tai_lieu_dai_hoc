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
''' <remarks>公共选择料件窗口:通过料号带出子件</remarks>
Public Class FrmSelectMaterials


#Region "属性"
#Region "产品料号"
    Private _PartID As String
    Public Property PartID() As String
        Get
            Return _PartID
        End Get

        Set(ByVal Value As String)
            _PartID = Value
        End Set
    End Property
#End Region
#End Region
#Region "构造函数"
    Sub New(ByVal partId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me._PartID = partId
    End Sub
#End Region


#Region "事件"
    Private Sub FrmSelectMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TT_PartBindGrid()
        Me.txtCondition.Focus()
    End Sub


    ''' <summary>
    ''' 查询
    ''' </summary>
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        TT_PartBindGrid()
    End Sub


    ''' <summary>
    ''' 确认
    ''' </summary>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    ''' <summary>
    ''' 取消
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub dgvMaterial_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvMaterial.CellBeginEdit
        If e.ColumnIndex > 0 Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "方法"

    '绑定DataGridView
    Private Sub BindGrid()
        Try
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sbSql As New StringBuilder
            '查询料件资料
            sbSql.Append("SELECT top 200  TAvcPart,TypeDest,REPLACE(DESCRIPTION,'""','') DESCRIPTION  FROM m_PartContrast_t ")
            If Not String.IsNullOrEmpty(Me.txtCondition.Text.Trim) Then
                sbSql.Append(String.Format(" where TAvcPart like'%{0}%' or TypeDest like '%{0}%' or DESCRIPTION like '%{0}%' ", txtCondition.Text.Trim))
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sbSql.ToString())

            Me.dgvMaterial.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSelectMaterials", "BindGrid()", "sys")
        End Try
    End Sub

    '数据来源TT,绑定DataGridView
    Private Sub TT_PartBindGrid()
        Try
            Dim dv As DataView
        
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                dv = SapCommon.GetPartInfoSap(_PartID, txtCondition.Text.Trim)
            Else
                dv = SapCommon.GetPartInfoTitop(_PartID, txtCondition.Text.Trim)
            End If

            Me.dgvMaterial.Rows.Clear()

            If Not dv Is Nothing Then
                If (dv.Table.Rows.Count > 0) Then
                    For i As Int16 = 0 To dv.Table.Rows.Count - 1
                        Me.dgvMaterial.Rows.Add(False, dv.Item(i).Item("TAVCPART").ToString, dv.Item(i).Item("TYPEDEST").ToString, dv.Item(i).Item("DESCRIPTION").ToString)
                    Next
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSelectMaterials", "BindGrid()", "sys")
        End Try
    End Sub


#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvMaterial.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

#End Region


End Class