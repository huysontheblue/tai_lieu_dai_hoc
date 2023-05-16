Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text
Imports MainFrame
Imports SysBasicClass

Public Class FrmDistributionSel

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
#Region "编码原则"
    Private _CodeRuleId As String
    Public Property CodeRuleId() As String
        Get
            Return _CodeRuleId
        End Get

        Set(ByVal Value As String)
            _CodeRuleId = Value
        End Set
    End Property
#End Region
#Region "构造函数"

    Sub New(ByVal partId As String, ByVal coderuleId As String)

        ' 此调用是 Windows 窗体设计器所必需的。


        InitializeComponent()
        Me._PartID = partId
        Me._CodeRuleId = coderuleId
    End Sub
#End Region
    Private Sub FrmDistributionSel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
    '绑定DataGridView
    Private Sub BindGrid()
        Try
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sbSql As New StringBuilder
            '查询料件资料
            sbSql.Append("SELECT FactoryID,PartId,CodeRuleId ,MinSN,MaxSN,CreateUserId,CreateTime,SNDistributionID FROM m_SNDistribution_t WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' and  PartId='" & Me.PartID & "'")
            sbSql.Append("  and CodeRuleId='" & Me.CodeRuleId & "'")
            Dim dt As DataTable = DAL.GetDataTable(sbSql.ToString())
            Me.grvDistribution.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmDistributionSel", "BindGrid()", "sys")
        End Try
    End Sub

    Private Sub grvDistribution_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grvDistribution.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim _SelectValue As String

            _SelectValue = IIf(CType(Me.grvDistribution.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell).EditingCellFormattedValue = True, "Y", "N")
            If _SelectValue = "Y" Then
                For Each Row As DataGridViewRow In Me.grvDistribution.Rows
                    Row.Cells(0).Value = "N"
                Next
            End If
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim isSel As Boolean = False
        Dim _SelectValue As String
        For Each Row As DataGridViewRow In Me.grvDistribution.Rows
            _SelectValue = IIf(CType(Me.grvDistribution.Rows(Row.Index).Cells(0), DataGridViewCheckBoxCell).EditingCellFormattedValue = True, "Y", "N")

            If _SelectValue = "Y" Then
                isSel = True
            End If
        Next
        If isSel = False Then
            Me.lbMsg.Text = "请选择一个号段!"
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub grvDistribution_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grvDistribution.CellDoubleClick
   
        For Each Row As DataGridViewRow In Me.grvDistribution.Rows
            If Row.Index = Me.grvDistribution.CurrentRow.Index Then
                Row.Cells(0).Value = "Y"
            Else
                Row.Cells(0).Value = "N"
            End If

        Next

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class