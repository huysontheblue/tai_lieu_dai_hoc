
'--不良条码打印记录查询
'--Create by :　马锋
'--Create date :　2014/12/24
'--Update date :  
'--Ver : V01

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
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region


Public Class FrmReprintQuery



    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolNew.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolCancel.Enabled = False
                Me.ToolPrint.Enabled = False
                Me.ToolFind.Enabled = True
                Me.txtMOId.Text = ""
            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolCancel.Enabled = False
                Me.ToolPrint.Enabled = True
                Me.ToolFind.Enabled = False
        End Select
    End Sub

    Private Sub FrmReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStatus(0)
        Me.dtpTime.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFind.Click
        Try
            Me.lblMessage.Text = ""
            Dim strSQL As String
            Dim strWhere As String = ""

            If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim) And String.IsNullOrEmpty(dtpTime.Text.Trim)) Then
                Me.lblMessage.Text = "请输入查询条件."
            End If

            If (Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim())) Then
                strWhere = " AND MOID='" & Me.txtMOId.Text.Trim() & "'"
            End If

            If (Not String.IsNullOrEmpty(dtpTime.Text.Trim())) Then
                strWhere = " AND CONVERT(VARCHAR(10), CREATEDATE, 120)='" & dtpTime.Text.Trim & "'"
            End If


            strSQL = "SELECT MOID, PartId, SUM(CASE Packid  WHEN 'N' THEN ReprintQty WHEN 'C' THEN ReprintQty WHEN 'P' THEN ReprintQty ELSE 0 END) AS PackingReprintCount,SUM(CASE Packid WHEN 'S' THEN ReprintQty ELSE 0 END) AS ProductReprintCount,SUM(CASE Packid WHEN 'A' THEN ReprintQty ELSE 0 END) AS AffiliatedReprintCount, LineId  " & _
                    " FROM m_BarCodeReprint_t  WHERE STATE='1' " & strWhere & " GROUP BY MOID,PartId,LineId "
            LoadData(strSQL, Me.dgvLot)
        Catch ex As Exception
            Me.lblMessage.Text = "查询失败，系统异常."
        End Try
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Try
            dgvName.Rows.Clear()
            Dim DReader As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            For rowIndex As Integer = 0 To DReader.Rows.Count - 1
                If dgvName Is Me.dgvLot Then
                    dgvName.Rows.Add(DReader.Rows(rowIndex).Item("MOID").ToString, DReader.Rows(rowIndex).Item("PartId").ToString,
                                     DReader.Rows(rowIndex).Item("PackingReprintCount").ToString, DReader.Rows(rowIndex).Item("ProductReprintCount").ToString,
                                     DReader.Rows(rowIndex).Item("AffiliatedReprintCount").ToString, DReader.Rows(rowIndex).Item("LineId").ToString)
                ElseIf dgvName Is Me.dgvBarcode Then
                    dgvName.Rows.Add(DReader.Rows(rowIndex).Item("PartId").ToString, DReader.Rows(rowIndex).Item("SBarCode").ToString,
                                     DReader.Rows(rowIndex).Item("LabelType").ToString, DReader.Rows(rowIndex).Item("KLabelid").ToString,
                                     DReader.Rows(rowIndex).Item("Description").ToString, DReader.Rows(rowIndex).Item("DisorderType").ToString,
                                     DReader.Rows(rowIndex).Item("ReprintQty").ToString, DReader.Rows(rowIndex).Item("Username").ToString,
                                     DReader.Rows(rowIndex).Item("createdate").ToString, DReader.Rows(rowIndex).Item("PrintDate").ToString,
                                     DReader.Rows(rowIndex).Item("PrintUserName").ToString, DReader.Rows(rowIndex).Item("TemplatePath").ToString,
                                     "", DReader.Rows(rowIndex).Item("state").ToString)
                End If
            Next
        Catch ex As Exception
            Me.lblMessage.Text = "查询失败，系统异常！"
        End Try

    End Sub

    Private Sub dgvLot_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLot.CellEnter
        Try

            If Me.dgvLot.Rows.Count = 0 OrElse Me.dgvLot.CurrentRow Is Nothing Then
                Exit Sub
            End If

            Dim strMOId As String = Me.dgvLot.Item("Moid", Me.dgvLot.CurrentRow.Index).Value.ToString.Trim

            Dim strSQL As String
            strSQL = "SELECT distinct m_BarCodeReprint_t.MOID, m_BarCodeReprint_t.partid, m_BarCodeReprint_t.SBarCode, " & _
                    " m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType ,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType,  " & _
                    " m_BarCodeReprint_t.Packid, m_PartPack_t.PrinterName,  " & _
                    " ReprintQty, UserName, createdate,PrintDate,PrintUserName, m_SnPFormat_t.KLabelid, m_PartPack_t.Description, m_SnMFormat_t.TemplatePath, CASE m_BarCodeReprint_t.state WHEN '0' THEN N'未打印' ELSE N'已打印' END AS state " & _
                    " FROM m_BarCodeReprint_t  " & _
                    "  LEFT JOIN m_PartContrast_t ON m_PartContrast_t.TAvcPart=m_BarCodeReprint_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart  " & _
                    "  LEFT JOIN m_PartPack_t ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND   " & _
                    " m_PartPack_t.Packid = m_BarCodeReprint_t.Packid And m_PartPack_t.Packitem = m_BarCodeReprint_t.Packitem " & _
                    "  LEFT JOIN m_SnPFormat_t  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID  " & _
                    "  LEFT JOIN m_Sortset_t  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y'  " & _
                    "  LEFT JOIN m_Sortset_t AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y'  " & _
                    "  left join m_SnMFormat_t on m_PartPack_t.PFormatID=m_SnMFormat_t.PFormatID " & _
                    "  WHERE MOID='" & strMOId & "'  ORDER BY m_BarCodeReprint_t.createdate DESC"

            LoadData(strSQL, Me.dgvBarcode)
        Catch ex As Exception

        End Try
    End Sub


End Class