
'--包装检查报表
'--Create by :　马锋
'--Create date :　2016/08/31
'--Ver : V01
'--Update date :  
'--

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
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class FrmPackingCheckQuery

#Region "变量声明"


#End Region

#Region "加载事件"

    Private Sub FrmPackingCheckQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvCarton.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            Me.dtpStartDate.Value = Now.AddDays(-1)
            Me.dtpEndDate.Value = Now.AddDays(1)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Try
            If CheckQueryParameter(True) Then
                Me.dgvCarton.DataSource = Nothing
                Me.dgvCarton.Rows.Clear()
                Me.dgvBarcode.DataSource = Nothing
                Me.dgvBarcode.Rows.Clear()
                Me.ToolCartonCount.Text = "0"
                Return
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.Append(" SELECT DISTINCT m_PackingCheckCarton_t.PackingCheckCartonId, m_PackingCheckCarton_t.CartonId, m_PackingCheckCarton_t.PalletId, Moid, PartId, Quantity, m_PackingCheckCarton_t.CheckUserId, m_PackingCheckCarton_t.CheckTime FROM m_PackingCheckCarton_t ")
            strSQL.Append(" INNER JOIN m_PackingCheckBarcode_t ON m_PackingCheckBarcode_t.CartonId = m_PackingCheckCarton_t.CartonId ")
            strSQL.Append(" WHERE m_PackingCheckCarton_t.CheckTime BETWEEN '" & Me.dtpStartDate.Text.Trim & "' AND '" & Me.dtpEndDate.Text.Trim & "'")

            If (Not String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                strSQL.Append(" AND Moid LIKE '%" & Me.txtMoId.Text.Trim & "%' ")
            End If

            If (Not String.IsNullOrEmpty(Me.txtCartonId.Text.Trim)) Then
                strSQL.Append(" AND PartId LIKE '%" & Me.txtCartonId.Text.Trim & "%' ")
            End If

            If (Not String.IsNullOrEmpty(Me.txtBarCode.Text.Trim)) Then
                strSQL.Append(" AND m_PackingCheckBarcode_t.BarCode LIKE '%" & Me.txtBarCode.Text.Trim & "%' ")
            End If

            Me.dgvCarton.DataSource = DbOperateReportUtils.GetDataTable(strSQL.ToString())
            Me.ToolCartonCount.Text = Me.dgvCarton.Rows.Count
        Catch ex As Exception
            SetMessage(Me.lblMessage, "刷新异常", False)
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Try
            If Me.dgvBarcode.RowCount < 1 Then Exit Sub
            LoadDataToExcel(Me.dgvBarcode, Me.Text)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "汇出异常", False)
        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "关闭异常", False)
        End Try
    End Sub

    Private Sub dgvCarton_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCarton.CellEnter
        Try
            If Me.dgvCarton.Rows.Count = 0 OrElse Me.dgvCarton.CurrentRow Is Nothing Then
                Me.dgvBarcode.DataSource = Nothing
                Me.dgvBarcode.Rows.Clear()
                Me.ToolPPIDCount.Text = "0"
                Exit Sub
            End If
            Dim strCartonId As String = Me.dgvCarton.Rows(Me.dgvCarton.CurrentRow.Index).Cells("CartonId").Value
            Dim strPackingCheckCartonId As String = Me.dgvCarton.Rows(Me.dgvCarton.CurrentRow.Index).Cells("PackingCheckCartonId").Value
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.Append(" SELECT   PackingCheckBarcodeId, CartonId, BarCode, CheckType, CheckUserId, CheckTime, m_SettingParameter_t.PARAMETER_NAME AS 'CheckTypeText', m_PackingCheckBarcode_t.CheckType ")
            strSQL.Append(" FROM m_PackingCheckBarcode_t ")
            strSQL.Append(" INNER JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE = m_PackingCheckBarcode_t.CheckType AND  m_SettingParameter_t.PARAMETER_CODE = 'PackingCheckText' ")
            strSQL.Append(" WHERE CartonId = '" & strCartonId & "' AND m_PackingCheckBarcode_t.PackingCheckCartonId = '" & strPackingCheckCartonId & "' ")
            Me.dgvBarcode.DataSource = DbOperateReportUtils.GetDataTable(strSQL.ToString())
            Me.ToolPPIDCount.Text = Me.dgvBarcode.Rows.Count
            DataRowColor()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "获取箱扫描异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub DataRowColor()
        Try
            For i As Int16 = 0 To Me.dgvBarcode.Rows.Count - 1
                Me.dgvBarcode.Rows(i).DefaultCellStyle.BackColor = IIf(Me.dgvBarcode.Rows(i).Cells("CheckType").Value = "0", Color.Red, Color.White)
            Next
        Catch ex As Exception
            SetMessage(Me.lblMessage, "格式化数据颜色异常", False)
        End Try
    End Sub

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpEndDate.Value < dtpStartDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MES") Then
                Directory.CreateDirectory("c:\MES")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MES\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            Dim r As Integer
            Dim c As Integer
            For r = 0 To DgMoData.Rows.Count - 1
                wValue = ""
                nColqty = 0
                For c = 0 To DgMoData.Columns.Count - 1
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        Else
                            wColName = wColName + "," + DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    'If DgMoData(c, r).Value Is System.DBNull.Value Then
                    If nColqty = 0 Then
                        wValue = DgMoData(c, r).Value.ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，")
                    End If

                    nColqty = nColqty + 1
                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)
            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MES\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region
   
End Class