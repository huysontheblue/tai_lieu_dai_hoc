Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmScanRecord
    Private _PackBarCode As String = String.Empty
    Private _strParentMO As String = String.Empty
    Public m_strPVersion As String = String.Empty
    Private currentValue As String = ""
    Private currentRowIndex As Integer = 0
    Private currentColumnIndex As Integer = 0
    Private currentColumnName As String = ""
    Public m_iChildPNCount As Integer
    Public m_strPPartID As String = String.Empty
    Private Enum enumdgvScanRecord
        PartID
        PPartID
        Qty
        ScanedQty
        UserID
    End Enum

    Sub New(ByVal PackBarCode As String, ByVal strParentMO As String)
        _PackBarCode = PackBarCode
        _strParentMO = strParentMO
        InitializeComponent()
    End Sub


    Private Sub FrmScanRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblPackCode.Text = _PackBarCode
        LoadDataToDatagridview(" WHERE 1=1 AND ISNULL(b.PackBarCode,'" & _PackBarCode & "') like '%" & _PackBarCode & "%'")

    End Sub


    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""
        Dim i As Integer = 1
        Try
            dgvScanRecord.Rows.Clear()

            'cq 20160722,  and c.PAvcPart =b.PPartID
            SqlStr = " SELECT a.PartID,b.PPartID,ISNULL(c.AmountQty,1) Qty,b.ScanedQty,b.UserID" & _
                     " FROM  ( SELECT  MO.PARTID  FROM m_MainMO_t MO WHERE" & _
                     " MO.PARENTMO = '" & _strParentMO & "' AND MOID <> PARENTMO AND MO.ESTATEID <> 'A' )  a  " & _
                     " LEFT JOIN (SELECT PPartID,partid, ScanedQty,UserID,PackBarcode FROM m_SetScanD_t WHERE PackBarCode='" & Me.lblPackCode.Text & "') b ON a.PartID = b.PartID " & _
                     " LEFT JOIN  m_PartContrast_t c ON a.PartID = c.TAvcpart  AND c.PAvcPart =b.PPartID " & SqlWhere

            Dreader = Conn.GetDataReader(SqlStr & " ORDER BY a.PartID ")
            Do While Dreader.Read()
                '编号，子料号，父料号, 配置数, 已扫描数, 扫描人员
                dgvScanRecord.Rows.Add(i, Dreader.Item(enumdgvScanRecord.PartID).ToString, Dreader.Item(enumdgvScanRecord.PPartID).ToString, _
                Dreader.Item(enumdgvScanRecord.Qty).ToString, Dreader.Item(enumdgvScanRecord.ScanedQty).ToString, _
                Dreader.Item(enumdgvScanRecord.UserID).ToString
                )
                i = i + 1
            Loop
            Dreader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            Conn.PubConnection.Close()
            Conn = Nothing
        End Try
    End Sub


    Private Sub dgvScanRecord_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvScanRecord.CellFormatting
        Dim i As Integer = 0

        If Me.dgvScanRecord.Rows.Count <= 0 Then
            Exit Sub
        End If

        For Each dr As DataGridViewRow In dgvScanRecord.Rows
            If (Not IsNothing(dgvScanRecord.Rows(i).Cells(enumdgvScanRecord.ScanedQty + 1).Value)) AndAlso Val(dgvScanRecord.Rows(i).Cells(enumdgvScanRecord.ScanedQty + 1).Value) > 0 Then
                If Val(dgvScanRecord.Rows(i).Cells(enumdgvScanRecord.ScanedQty + 1).Value) = Val(dgvScanRecord.Rows(i).Cells(enumdgvScanRecord.Qty + 1).Value) Then
                    'show green
                    dgvScanRecord.Rows(i).DefaultCellStyle.BackColor = Color.Green
                End If
            End If
            i = i + 1
        Next
    End Sub
    Private Sub dgvScanRecord_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvScanRecord.CellEnter

        Try
            If e.RowIndex < dgvScanRecord.Rows.Count - 1 AndAlso Me.dgvScanRecord.ReadOnly = False Then
                currentRowIndex = e.RowIndex
                currentColumnIndex = e.ColumnIndex
                currentColumnName = dgvScanRecord.CurrentCell.OwningColumn.Name
                currentValue = dgvScanRecord.CurrentCell.FormattedValue.ToString
                ' currentOldWorkHour = dgvRunCardBody.Rows(currentRowIndex).Cells(RunCardBusiness.BodyGrid.WorkingHours).FormattedValue.ToString
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgvScanRecord_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvScanRecord.CellLeave

        Try

            If dgvScanRecord.CurrentCell.OwningColumn.Name <> enumdgvScanRecord.ScanedQty.ToString Then Exit Sub

            If dgvScanRecord.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                If String.IsNullOrEmpty(currentValue) Then  'Not CheckStatus(dgvScanRecord.CurrentRow) Then
                    Exit Sub
                Else
                    UpdateDetailData() 'dgvScanRecord.CurrentCell.OwningColumn.Name
                End If
            End If

        Catch ex As Exception
            ' MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub UpdateDetailData()
        Dim strSQL As New StringBuilder
        Dim o_strExecutSQLResult As String = ""
        Try
            If dgvScanRecord.RowCount > 0 Then
                If dgvScanRecord.IsCurrentCellInEditMode Then 'Or isClose Then
                    If Not dgvScanRecord.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvScanRecord.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                        Dim PartID As String = dgvScanRecord.CurrentRow.Cells(enumdgvScanRecord.PartID + 1).Value.ToString
                        Dim editValue As String = dgvScanRecord.CurrentCell.EditedFormattedValue.ToString.Trim.Replace("'", "'''")

                        ' strSQL = RunCardBusiness.GetHeaderUpdateSQL(Me.IsQueryOldVersion, parcurrentColumnName, editValue, runCardId)
                        strSQL.Append(" If ISNULL((SELECT TOP 1 1 FROM m_SetScanPass_t WHERE CPartID='" & PartID & "' AND PVersion=N'" & m_strPVersion & "'),0)=0")
                        strSQL.Append(" Begin")
                        strSQL.Append(" INSERT INTO m_SetScanPass_t(CPartID, PVersion) ")
                        strSQL.Append("  Values('" & PartID & "', N'" & m_strPVersion & "') ")
                        strSQL.Append(" End")
                        strSQL.Append(" Update m_SetScanD_t SET ScanedQty= Qty WHERE PartID='" & PartID & "' AND packbarcode='" & Me.lblPackCode.Text.Trim & "'")

                        If Not String.IsNullOrEmpty(strSQL.ToString) Then
                            o_strExecutSQLResult = RCardComBusiness.ExecSQL(strSQL.ToString)
                            If o_strExecutSQLResult <> "" Then
                                MessageUtils.ShowError(o_strExecutSQLResult)
                                Exit Sub
                            End If
                            ' dgvScanRecord.CurrentRow.Cells(RunCardBusiness.HeaderGrid.ModifyTime.ToString).Value = Date.Now
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub FrmScanRecord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim iChildPNFinishQty As Integer = 0
        Dim strSQL As New StringBuilder
        Dim o_strExecutSQLResult As String = ""
        Try
            iChildPNFinishQty = SetScan.GetFinishChildPNQty(m_strPPartID, Me.lblPackCode.Text.Trim)

            If iChildPNFinishQty = m_iChildPNCount Then
                'need update to 1.finish
                strSQL.Append(" Begin")
                strSQL.Append(" Update m_SetScanM_t Set Status='1', FinishTime=getdate() ")
                strSQL.Append("  Where PartID='" & m_strPPartID & "' And PackBarcode='" & Me.lblPackCode.Text.Trim & "' ")
                strSQL.Append(" End")
                If Not String.IsNullOrEmpty(strSQL.ToString) Then
                    o_strExecutSQLResult = RCardComBusiness.ExecSQL(strSQL.ToString)
                    If o_strExecutSQLResult <> "" Then
                        MessageUtils.ShowError(o_strExecutSQLResult)
                        Exit Sub
                    End If
                    ' dgvScanRecord.CurrentRow.Cells(RunCardBusiness.HeaderGrid.ModifyTime.ToString).Value = Date.Now
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            strSQL = Nothing
        End Try
    End Sub
End Class