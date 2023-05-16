
'标签记录
'Create by: 马锋
'Create time: 2016/11/22
'Update by: 
'Update time: 

#Region "Imports引用"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports DevComponents.DotNetBar
Imports MainFrame

#End Region

Public Class FrmBarCodeReceivedRecord

#Region "窗體加載"

    Private Sub FrmBarCodeReceivedRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvBarCodeReceived.AutoGenerateColumns = False
            Me.dgvBarCodeReceivedRecord.AutoGenerateColumns = False
            ToolState(0)
            Me.dtpStartDate.Value = Now.AddDays(-1)
            Me.dtpEndDate.Value = Now.AddDays(1)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Try
            ToolState(1)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Try

        Catch ex As Exception
            SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Try

        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvBarCodeReceived.Rows.Count = 0 OrElse Me.dgvBarCodeReceived.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "没有任何保存记录", False)
                Exit Sub
            End If

            Me.dgvBarCodeReceived.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If (Not CheckSava()) Then
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strPtaskid As String
            Dim strMOid As String
            Dim strPartId As String
            Dim strPPartId As String
            Dim strPackId As String
            Dim strPackItem As String
            Dim strLabelType As String
            Dim strContentText As String
            Dim strQuantity As String
            Dim strRemark As String
            Dim chkTemp As DataGridViewCheckBoxCell

            For i As Int16 = 0 To Me.dgvBarCodeReceived.Rows.Count - 1
                chkTemp = dgvBarCodeReceived.Rows(i).Cells("ChkSelect")

                If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                    strPtaskid = Me.dgvBarCodeReceived.Rows(i).Cells("Ptaskid").Value.ToString
                    strMOid = Me.dgvBarCodeReceived.Rows(i).Cells("MOid").Value.ToString
                    strPartId = Me.dgvBarCodeReceived.Rows(i).Cells("PartId").Value.ToString
                    strPPartId = Me.dgvBarCodeReceived.Rows(i).Cells("PPartId").Value.ToString
                    strPackId = Me.dgvBarCodeReceived.Rows(i).Cells("PackId").Value.ToString
                    strPackItem = Me.dgvBarCodeReceived.Rows(i).Cells("PackItem").Value.ToString
                    strLabelType = Me.dgvBarCodeReceived.Rows(i).Cells("LabelType").Value.ToString
                    strContentText = Me.dgvBarCodeReceived.Rows(i).Cells("ContentText").Value.ToString
                    strQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("Quantity").Value.ToString
                    strRemark = Me.dgvBarCodeReceived.Rows(i).Cells("Remark").Value.ToString

                    strSQL.AppendLine(" INSERT INTO m_BarCodeReceived_t(Ptaskid, FactoryId, Profitcenter, MOID, PartId, PPartId, PackId, PackItem, LabelType, ModelName, ContentText, Quantity, ")
                    strSQL.AppendLine(" ReceivedDate, ReceivedUserId, ReceivedQuantity, NOQuantity, ExchangeFlag, CreateUserId, CreateDate, Remark) VALUES( ")
                    strSQL.AppendLine(" '" & strPtaskid & "', '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & strMOid & "', '" & strPartId & "', '" & strPPartId & "', '" & strPackId & "', '" & strPackItem & "', N'" & strLabelType & "', NULL, N'" & strContentText & "', '" & strQuantity & "', ")
                    strSQL.AppendLine(" NULL, '" & Me.txtReceivedUserId.Text.Trim & "', 0, 0, 'Y', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), N'" & strRemark & "')")
                End If
            Next

            DbOperateUtils.ExecSQL(strSQL.ToString)
            ToolState(0)
            GetBarCodeReceied()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Try
            ToolState(0)
            GetBarCodeReceied()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            GetBarCodeReceied()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "关闭异常", False)
        End Try
    End Sub

    Private Sub toolIssued_Click(sender As Object, e As EventArgs) Handles toolIssued.Click
        Try
            Me.dgvBarCodeReceived.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If (Not CheckIssuedSava()) Then
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strBarCodeReceivedID As String
            Dim strPartId As String
            Dim strContentText As String
            Dim strYieldQuantity As String
            Dim strNoYieldQuantity As String
            Dim strReturnQuantity As String
            Dim strRemark As String

            For i As Int16 = 0 To Me.dgvBarCodeReceived.Rows.Count - 1

                strBarCodeReceivedID = Me.dgvBarCodeReceived.Rows(i).Cells("BarCodeReceivedID").Value.ToString
                strPartId = Me.dgvBarCodeReceived.Rows(i).Cells("PartId").Value.ToString
                strContentText = IIf(IsDBNull(Me.dgvBarCodeReceived.Rows(i).Cells("ContentText").Value), "", Me.dgvBarCodeReceived.Rows(i).Cells("ContentText").Value)
                strYieldQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("YieldQuantity").Value.ToString
                strNoYieldQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("NoYieldQuantity").Value.ToString
                strReturnQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("ReturnQuantity").Value.ToString
                strRemark = IIf(IsDBNull(Me.dgvBarCodeReceived.Rows(i).Cells("Remark").Value), "", Me.dgvBarCodeReceived.Rows(i).Cells("Remark").Value)

                If (strYieldQuantity = "0" And strNoYieldQuantity = "0" And strReturnQuantity = "0") Then
                    strBarCodeReceivedID = ""
                    Continue For
                Else
                    strSQL.AppendLine(" UPDATE m_BarCodeReceived_t SET ReceivedQuantity = ReceivedQuantity + " & strYieldQuantity - strReturnQuantity & ", NOQuantity = NOQuantity + " & strNoYieldQuantity & " WHERE BarCodeReceivedID='" & strBarCodeReceivedID & "'")
                    strSQL.AppendLine(" INSERT INTO m_BarCodeReceivedRecord_t(BarCodeReceivedID, PartId, ContentText, YieldQuantity, NoYieldQuantity, ReturnQuantity, ExchangeFlag, ")
                    strSQL.AppendLine(" ExchangeUserId, ExchangeDate, Remark)VALUES('" & strBarCodeReceivedID & "', '" & strPartId & "', N'" & strContentText & "', '" & strYieldQuantity & "', '" & strNoYieldQuantity & "', '" & strReturnQuantity & "', 'Y', ")
                    strSQL.AppendLine(" '" & VbCommClass.VbCommClass.UseId & "', getdate(), N'" & strRemark & "')")
                End If
            Next

            DbOperateUtils.ExecSQL(strSQL.ToString)
            GetBarCodeReceied()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "发放异常", False)
        End Try
    End Sub

    Private Sub txtMOId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOID.KeyDown
        SetMessage(Me.lblMessage, "", False)
        Try
            If (e.KeyCode = Keys.Enter) Then
                Dim strSQL As String
                strSQL = " SELECT m_SnAssign_t.Ptaskid, m_Mainmo_t.ParentMo AS MOID, m_PartContrast_t.TAvcPart AS PartId, m_PartContrast_t.PAvcPart AS PPartId, m_SnAssign_t.Packid, m_SnAssign_t.Packitem, " & _
                    " m_Sortset_t.SortID + '-' + m_Sortset_t.SortName + '-' + m_SnPFormat_t.KLabelid as LabelType, m_SnAssign_t.PrtQty*ISNULL(m_SnAssign_t.ConfigurationQty,1) Quantity, " & _
                    " CASE ISNULL(m_PartPack_t.Description,'') WHEN '' THEN m_PartPack_t.Remark ELSE m_PartPack_t.Description END AS ContentText, 0 AS ReceivedQuantity, 0 AS NOReceivedQuantity, 0 AS NoQuantity, 0 AS YieldQuantity, 0 AS NoYieldQuantity, 0 AS ReturnQuantity, '' AS ExchangeFlag, '' AS Remark " & _
                    " FROM m_Mainmo_t(NOLOCK) " & _
                    " INNER JOIN m_SnAssign_t(NOLOCK) ON m_Mainmo_t.Moid= m_SnAssign_t.Moid  " & _
                    " INNER JOIN m_PartContrast_t(NOLOCK) ON m_PartContrast_t.TAvcPart=m_Mainmo_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart " & _
                    " INNER JOIN m_PartPack_t(NOLOCK) ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND " & _
                    " m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND  m_PartPack_t.Packid=m_SnAssign_t.Packid AND m_PartPack_t.Packitem=m_SnAssign_t.Packitem " & _
                    " LEFT JOIN m_SnPFormat_t(NOLOCK)  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID " & _
                    " LEFT JOIN m_Sortset_t(NOLOCK)  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' " & _
                    " WHERE m_Mainmo_t.ParentMo='" & Me.txtMOID.Text.Trim & "' AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' " & _
                    " AND m_SnAssign_t.Ptaskid NOT IN (SELECT Ptaskid FROM m_BarCodeReceived_t WHERE MOID='" & Me.txtMOID.Text.Trim & "') " & _
                    " ORDER BY m_PartContrast_t.TAvcPart ASC"

                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dtTemp Is Nothing Or dtTemp.Rows.Count = 0 Then
                    SetMessage(Me.lblMessage, "工单不存在或无打印记录", False)
                    Me.ActiveControl = Me.txtMOID
                Else
                    Me.dgvBarCodeReceived.DataSource = dtTemp
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "生成领用标签清单异常", False)
        End Try
    End Sub

    Private Sub dgvBarCodeReceived_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBarCodeReceived.CellEnter
        Try
            If Me.dgvBarCodeReceived.Rows.Count = 0 OrElse Me.dgvBarCodeReceived.CurrentRow Is Nothing Then
                Me.dgvBarCodeReceivedRecord.DataSource = Nothing
                Me.dgvBarCodeReceivedRecord.Rows.Clear()
                Exit Sub
            End If

            GetBarCodeReceivedRecord(Me.dgvBarCodeReceived.Rows(Me.dgvBarCodeReceived.CurrentRow.Index).Cells("BarCodeReceivedID").Value.ToString)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询申请清单异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpEndDate.Value < dtpStartDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Private Sub ToolState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolIssued.Enabled = True
                Me.toolQuery.Enabled = True

                'GroupBox
                Me.ActiveControl = Me.txtMOID
            Case 1
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolIssued.Enabled = False
                Me.toolQuery.Enabled = False

                'GroupBox
                Me.dgvBarCodeReceived.DataSource = Nothing
                Me.dgvBarCodeReceivedRecord.DataSource = Nothing
                Me.dgvBarCodeReceived.Rows.Clear()
                Me.dgvBarCodeReceivedRecord.Rows.Clear()

                Me.txtMOID.Text = ""
                Me.txtPartID.Text = ""
                Me.ActiveControl = Me.txtMOID
        End Select
    End Sub

    Private Sub GetBarCodeReceied()
        Try
            Dim strSQL As String
            strSQL = " SELECT   BarCodeReceivedID, Ptaskid, MOID, PartId, PPartId, PackId, PackItem, LabelType, ContentText, ReceivedDate, " & _
            " ReceivedUserId, Quantity, ReceivedQuantity, Quantity - ReceivedQuantity AS NOReceivedQuantity, NoQuantity, ExchangeFlag, CreateUserId, CreateDate, " & _
            " 0 AS YieldQuantity, 0 AS NoYieldQuantity, 0 AS ReturnQuantity, '' AS ExchangeFlag, '' AS Remark " & _
            " FROM m_BarCodeReceived_t(NOLOCK) WHERE FactoryId = '" & VbCommClass.VbCommClass.Factory & "' AND ISNULL(Profitcenter, '')='" & VbCommClass.VbCommClass.profitcenter & "' AND m_BarCodeReceived_t.CreateDate between cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) "

            If Not String.IsNullOrEmpty(Me.txtMOID.Text.Trim) Then
                strSQL = strSQL & " AND MOID = '" & Me.txtMOID.Text.Trim & "' "
            End If

            If Not String.IsNullOrEmpty(Me.txtPartID.Text.Trim) Then
                strSQL = strSQL & " AND PARTID = '" & Me.txtPartID.Text.Trim & "' "
            End If

            Me.dgvBarCodeReceived.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub GetBarCodeReceivedRecord(ByVal strBarCodeReceivedID As String)
        Try
            Dim strSQL As String
            strSQL = " SELECT   BarCodeReceivedRecordID, PartId, ContentText, YieldQuantity, NoYieldQuantity, ExchangeFlag, ExchangeUserId, " & _
            " ExchangeDate, Remark FROM m_BarCodeReceivedRecord_t(NOLOCK) WHERE BarCodeReceivedID = '" & strBarCodeReceivedID & "' "

            Me.dgvBarCodeReceivedRecord.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Function CheckSava() As Boolean

        Try
            Dim SelectValue As Boolean = False
            'Dim strMOID As String = Me.dgvBarCodeReceived.Rows(0).Cells("MOID").Value.ToString
            'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 * FROM m_BarCodeReceived_t WHERE MOID = '" & strMOID & "'")

            'If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
            '    SetMessage(Me.lblMessage, "工单" & strMOID & "已经领用", False)
            '    Return False
            '    Exit Function
            'End If

            Dim chkTemp As DataGridViewCheckBoxCell

            For i As Int16 = 0 To Me.dgvBarCodeReceived.Rows.Count - 1
                chkTemp = dgvBarCodeReceived.Rows(i).Cells("ChkSelect")

                If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                    SelectValue = True
                End If
            Next

            If (SelectValue = False) Then
                SetMessage(Me.lblMessage, "未选择任何标签领用项目", False)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckIssuedSava() As Boolean
        Try
            Dim CheckValue As Boolean = False
            Dim strBarCodeReceivedID As String
            Dim strPartId As String
            Dim strContentText As String
            Dim strYieldQuantity As String
            Dim strNoYieldQuantity As String
            Dim strReturnQuantity As String
            Dim strQuantity As String

            For i As Int16 = 0 To Me.dgvBarCodeReceived.Rows.Count - 1

                strBarCodeReceivedID = Me.dgvBarCodeReceived.Rows(i).Cells("BarCodeReceivedID").Value.ToString
                strPartId = Me.dgvBarCodeReceived.Rows(i).Cells("PartId").Value.ToString
                strContentText = Me.dgvBarCodeReceived.Rows(i).Cells("ContentText").Value.ToString
                strYieldQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("YieldQuantity").Value.ToString
                strNoYieldQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("NoYieldQuantity").Value.ToString
                strReturnQuantity = Me.dgvBarCodeReceived.Rows(i).Cells("ReturnQuantity").Value.ToString

                If (strYieldQuantity = "0" And strNoYieldQuantity = "0" And strReturnQuantity = "0") Then
                    Continue For
                Else
                    CheckValue = True
                    strQuantity = strYieldQuantity - strReturnQuantity
                    If (Not CheckIssuedQuantity(strBarCodeReceivedID, strPartId, strContentText, strQuantity)) Then
                        Return False
                        Exit Function
                    End If
                End If
            Next

            If (Not CheckValue) Then
                SetMessage(Me.lblMessage, "请填写发放需求信息", False)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "发放检查标签数量异常", False)
            Return False
        End Try
    End Function

    Private Function CheckIssuedQuantity(ByVal strBarCodeReceivedID As String, ByVal strPartId As String, ByVal strContentText As String, ByVal strQuantity As String)
        Try
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 BarCodeReceivedID FROM m_BarCodeReceived_t WHERE BarCodeReceivedID ='" & strBarCodeReceivedID & "' AND Quantity - ReceivedQuantity - '" & strQuantity & "' < 0 ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                SetMessage(Me.lblMessage, strPartId & "[" & strContentText & "]发放标签数量超过领用数量", False)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            SetMessage(Me.lblMessage, "发放检查标签数量异常", False)
            Return False
        End Try
    End Function

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