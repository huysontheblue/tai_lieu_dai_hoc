
'上线通知单
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
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmOnlineNotice

#Region "变量声明"

    Dim toolValue As String
    Dim dvEquipment As New DataView
    Dim opFlag As Int16 = 0
    Dim DataType As String
    Dim _EquipmentList As DataTable

    Public Property EquipmentList() As DataTable
        Get
            If (_EquipmentList Is Nothing) Then
                _EquipmentList = New DataTable()
                _EquipmentList.Columns.Add("OnlineNoticeEquipmentId", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("EquipmentId", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("EquipmentName", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("Quantity", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("RecordsQuantity", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("Remark", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _EquipmentList.Columns.Add("CreateTime", Type.GetType("System.String"))

            End If
            Return _EquipmentList
        End Get

        Set(ByVal Value As DataTable)
            _EquipmentList = Value
        End Set
    End Property

#End Region

#Region "窗體加載"

    Private Sub FrmOnlineNotice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvOnlineNotice.AutoGenerateColumns = False
            Me.dgvOnlineNoticeEquipment.AutoGenerateColumns = False
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
            toolValue = "ADD"
            ToolState(1)
            Me.dgvOnlineNotice.DataSource = Nothing
            Me.dgvOnlineNoticeEquipment.DataSource = Nothing
            Me.dgvOnlineNotice.Rows.Clear()
            Me.dgvOnlineNoticeEquipment.Rows.Clear()

            Me.dgvOnlineNotice.Rows.Add(1)
            Me.dgvOnlineNoticeEquipment.Rows.Add(1)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Try
            toolValue = "EDIT"
            ToolState(1)

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
            Me.dgvOnlineNotice.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Me.dgvOnlineNoticeEquipment.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If Me.dgvOnlineNotice.Rows.Count = 0 OrElse Me.dgvOnlineNotice.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "没有任何保存记录", False)
                Exit Sub
            End If

            If Me.dgvOnlineNoticeEquipment.Rows.Count = 0 OrElse Me.dgvOnlineNoticeEquipment.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "没有任何设备项目保存记录", False)
                Exit Sub
            End If

            If (Not CheckSava()) Then
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strPartId As String
            Dim strDeptid As String
            Dim strLineId As String
            Dim strDemandTime As String
            Dim strPRemark As String

            strPartId = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(0).Cells("PartId").Value), "", Me.dgvOnlineNotice.Rows(0).Cells("PartId").Value.ToString)
            strDeptid = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(0).Cells("Deptid").Value), "", Me.dgvOnlineNotice.Rows(0).Cells("Deptid").Value.ToString)
            strLineId = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(0).Cells("LineId").Value), "", Me.dgvOnlineNotice.Rows(0).Cells("LineId").Value.ToString)
            strDemandTime = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(0).Cells("DemandTime").Value), "", Me.dgvOnlineNotice.Rows(0).Cells("DemandTime").Value.ToString)
            strPRemark = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(0).Cells("Remark").Value), "", Me.dgvOnlineNotice.Rows(0).Cells("Remark").Value.ToString)

            strSQL.AppendLine(" DECLARE @OnlineNoticeId VARCHAR(32) ")
            strSQL.AppendLine(" INSERT INTO m_OnlineNotice_t(FactoryId, Profitcenter, PartId, Deptid, LineId, DemandTime, Remark, CreateUserId, CreateTime, StatusFlag)VALUES(")
            strSQL.AppendLine(" '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & strPartId & "', '" & strDeptid & "', '" & strLineId & "', '" & strDemandTime & "', N'" & strPRemark & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), 'N')")
            strSQL.AppendLine(" SELECT TOP 1 @OnlineNoticeId = OnlineNoticeId FROM m_OnlineNotice_t WHERE FactoryId = '" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "' AND PartId = '" & strPartId & "' AND LineId = '" & strLineId & "' ORDER BY CreateTime DESC ")

            Dim strHardWarePartNumber As String
            Dim strPartNumber As String
            Dim strPartNumberFormat As String
            Dim strQuantity As String
            Dim strCRemark As String

            For i As Int16 = 0 To Me.dgvOnlineNoticeEquipment.Rows.Count - 1
                strHardWarePartNumber = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("HardWarePartNumber").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("HardWarePartNumber").Value)
                strPartNumber = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumber").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumber").Value)
                strPartNumberFormat = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumberFormat").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumberFormat").Value)
                strQuantity = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("Quantity").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("Quantity").Value)
                strCRemark = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("CRemark").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("CRemark").Value)

                strSQL.AppendLine(" INSERT INTO m_OnlineNoticeEquipment_t(OnlineNoticeId, HardWarePartNumber, PartNumber, PartNumberFormat, Quantity, Remark, CreateUserId, CreateTime)VALUES( ")
                strSQL.AppendLine("  @OnlineNoticeId, N'" & strHardWarePartNumber & "', N'" & strPartNumber & "', N'" & strPartNumberFormat & "', '" & strQuantity & "', N'" & strCRemark & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
            Next

            DbOperateUtils.ExecSQL(strSQL.ToString)
            ToolState(0)
            GetOnlineNotice()
            toolValue = ""
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Try
            ToolState(0)
            Me.dgvOnlineNotice.DataSource = Nothing
            Me.dgvOnlineNoticeEquipment.DataSource = Nothing
            Me.dgvOnlineNotice.Rows.Clear()
            Me.dgvOnlineNoticeEquipment.Rows.Clear()
            toolValue = ""
            GetOnlineNotice()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            GetOnlineNotice()
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

    Private Sub toolReject_Click(sender As Object, e As EventArgs) Handles toolReject.Click
        Try
            If Me.dgvOnlineNotice.Rows.Count = 0 OrElse Me.dgvOnlineNotice.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择要驳回的行!", False)
                Exit Sub
            End If

            Dim strStatusFlagText As String = Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("StatusFlagText").Value

            If (strStatusFlagText.Split("-")(0) <> "N") Then
                SetMessage(Me.lblMessage, "该通知单已经驳回或审核!", False)
                Exit Sub
            End If

            If (MessageBox.Show("你确定执行驳回动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strOnlineNoticeId As String = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("OnlineNoticeId").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("OnlineNoticeId").Value)

            If (String.IsNullOrEmpty(strOnlineNoticeId)) Then
                SetMessage(Me.lblMessage, "该通知单ID不能为空!", False)
                Exit Sub
            End If

            strSQL.AppendLine("UPDATE m_OnlineNotice_t SET StatusFlag='P', ApprovedUserId = '" & VbCommClass.VbCommClass.UseId & "', ApprovedTime = GETDATE() WHERE OnlineNoticeId = '" & strOnlineNoticeId & "' ")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            SetMessage(Me.lblMessage, "驳回成功", True)
            GetOnlineNotice()

        Catch ex As Exception
            SetMessage(Me.lblMessage, "驳回异常", False)
        End Try
    End Sub

    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        Try
            If Me.dgvOnlineNotice.Rows.Count = 0 OrElse Me.dgvOnlineNotice.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择要审核的行!", False)
                Exit Sub
            End If

            Dim strStatusFlagText As String = Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("StatusFlagText").Value

            If (strStatusFlagText.Split("-")(0) <> "N") Then
                SetMessage(Me.lblMessage, "该通知单已经驳回或审核!", False)
                Exit Sub
            End If

            If (MessageBox.Show("你确定执行审核动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strOnlineNoticeId As String = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("OnlineNoticeId").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("OnlineNoticeId").Value)

            If (String.IsNullOrEmpty(strOnlineNoticeId)) Then
                SetMessage(Me.lblMessage, "该通知单ID不能为空!", False)
                Exit Sub
            End If

            strSQL.AppendLine(" UPDATE m_OnlineNotice_t SET StatusFlag='Y', CheckUserId = '" & VbCommClass.VbCommClass.UseId & "', CheckTime = GETDATE() WHERE OnlineNoticeId = '" & strOnlineNoticeId & "' ")
            strSQL.AppendLine(" INSERT INTO [m_Equipment_App_t]([AppID],[Dept],[Line],[AStatus],[QTY],[AppUserName],[AStatus1], [EquipmentPNumber],[AlreadyBorrowQty],ReturnQty,DeptID,HardWarePartNumber,[FactoryName],[Profitcenter],InTime) ")
            strSQL.AppendLine(" SELECT   m_OnlineNotice_t.CreateUserId, m_Dept_t.dqc, m_OnlineNotice_t.LineId, '申请', m_OnlineNoticeEquipment_t.Quantity, m_Users_t.UserName, '1', ")
            strSQL.AppendLine(" m_OnlineNoticeEquipment_t.PartNumber, '0', '0', m_OnlineNotice_t.DeptId,  m_OnlineNoticeEquipment_t.HardWarePartNumber, m_OnlineNotice_t.FactoryId, ")
            strSQL.AppendLine(" m_OnlineNotice_t.Profitcenter, getDate() FROM m_OnlineNotice_t ")
            strSQL.AppendLine(" INNER JOIN m_OnlineNoticeEquipment_t ON m_OnlineNotice_t.OnlineNoticeId = m_OnlineNoticeEquipment_t.OnlineNoticeId ")
            strSQL.AppendLine(" INNER JOIN m_Users_t ON m_OnlineNotice_t.CreateUserId = m_Users_t.UserID ")
            strSQL.AppendLine(" INNER JOIN m_Dept_t ON m_OnlineNotice_t.DeptId = m_Dept_t.deptid ")
            strSQL.AppendLine(" WHERE m_OnlineNotice_t.OnlineNoticeId = '" & strOnlineNoticeId & "'")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            SetMessage(Me.lblMessage, "审核成功", True)
            GetOnlineNotice()

        Catch ex As Exception
            SetMessage(Me.lblMessage, "审核异常", False)
        End Try
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            If Me.dgvOnlineNoticeEquipment.Rows.Count = 0 OrElse Me.dgvOnlineNoticeEquipment.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择上线通知单项目!", False)
                Exit Sub
            End If

            'Dim drTemp As DataRow
            'drTemp = EquipmentList.NewRow

            'drTemp("OnlineNoticeEquipmentId") = ""
            'drTemp("Quantity") = "0"
            'drTemp("RecordsQuantity") = "0"
            'drTemp("Remark") = "0"

            'EquipmentList.Rows.Add(drTemp)
            'EquipmentList.AcceptChanges()

            'Me.dgvOnlineNoticeEquipment.DataSource = EquipmentList

            Me.dgvOnlineNoticeEquipment.Rows.Add(1)
        Catch ex As Exception
            SetMessage(lblMessage, "新增行异常!", False)
        End Try
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvOnlineNoticeEquipment.Rows.Count = 0 OrElse Me.dgvOnlineNoticeEquipment.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If
            Dim strOnlineNoticeEquipmentId As String = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(Me.dgvOnlineNoticeEquipment.CurrentRow.Index).Cells("OnlineNoticeEquipmentId").Value), "", Me.dgvOnlineNoticeEquipment.Rows(Me.dgvOnlineNoticeEquipment.CurrentRow.Index).Cells("OnlineNoticeEquipmentId").Value)
            If (String.IsNullOrEmpty(strOnlineNoticeEquipmentId)) Then
                Me.dgvOnlineNoticeEquipment.Rows.RemoveAt(Me.dgvOnlineNoticeEquipment.CurrentRow.Index)
            Else
                If (Not CheckRowDelete(strOnlineNoticeEquipmentId)) Then
                    Exit Sub
                End If

                Dim strSQL As String
                strSQL = " DELETE m_OnlineNoticeEquipment_t WHERE OnlineNoticeEquipmentId = '" & strOnlineNoticeEquipmentId & "' "
                DbOperateUtils.ExecSQL(strSQL)
                Me.dgvOnlineNoticeEquipment.Rows.RemoveAt(Me.dgvOnlineNoticeEquipment.CurrentRow.Index)
            End If

        Catch ex As Exception
            SetMessage(lblMessage, "删除行异常!", False)
        End Try
    End Sub

    Private Sub dgvOnlineNotice_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOnlineNotice.CellEnter
        Try
            If Me.dgvOnlineNotice.Rows.Count = 0 OrElse Me.dgvOnlineNotice.CurrentRow Is Nothing Then
                Me.dgvOnlineNoticeEquipment.DataSource = Nothing
                Me.dgvOnlineNoticeEquipment.Rows.Clear()
                Exit Sub
            End If

            If toolValue = "ADD" OrElse toolValue = "EDIT" Then
                Exit Sub
            End If

            GetOnlineNoticeEquipment(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("OnlineNoticeId").Value.ToString)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询申请清单异常", False)
        End Try
    End Sub

    Private Sub mtxtHardWarePartNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles HardWarePartNumber.ButtonCustomClick
        Try

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvOnlineNoticeEquipment.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)

                If ec IsNot Nothing Then
                    Dim frmEquipmentQuery As New FrmEquipmentQuery(ec)
                    frmEquipmentQuery.ShowDialog()

                    If Not (String.IsNullOrEmpty(ec.Text.Trim)) Then
                        Dim strEquipment As String = ec.Text.Trim
                        ec.Text = strEquipment.Split("@@")(0)
                        Me.dgvOnlineNoticeEquipment.Rows(Me.dgvOnlineNoticeEquipment.CurrentRow.Index).Cells("PartNumber").Value = strEquipment.Split("@@")(2)
                        Me.dgvOnlineNoticeEquipment.Rows(Me.dgvOnlineNoticeEquipment.CurrentRow.Index).Cells("PartNumberFormat").Value = strEquipment.Split("@@")(4)
                    End If
                End If

                Me.dgvOnlineNoticeEquipment.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvOnlineNoticeEquipment_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvOnlineNoticeEquipment.EditingControlShowing
        Try
            If Me.dgvOnlineNoticeEquipment.CurrentCellAddress.X = 1 Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(e.Control, DataGridViewMaskedTextBoxAdvEditingControl)
                ec.MaskedTextBox.ReadOnly = True
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub mtxtDept_ButtonCustomClick(sender As Object, e As EventArgs) Handles DeptId.ButtonCustomClick
        SetMessage(Me.lblMessage, "", False)
        Try

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvOnlineNotice.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)

                If ec IsNot Nothing Then
                    Dim frmDeptQuery As New FrmDeptQuery(ec)
                    frmDeptQuery.ShowDialog()
                    Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("LineId").Value = ""
                End If

                Me.dgvOnlineNotice.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub mtxtLineId_ButtonCustomClick(sender As Object, e As EventArgs) Handles LineId.ButtonCustomClick
        SetMessage(Me.lblMessage, "", False)
        Try

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvOnlineNotice.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)
                Dim strDeptId As String = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("DeptId").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("DeptId").Value)

                If (String.IsNullOrEmpty(strDeptId)) Then
                    SetMessage(Me.lblMessage, "请选择部门", False)
                    Exit Sub
                End If

                If ec IsNot Nothing Then
                    Dim frmLineQuery As New FrmLineQuery(strDeptId, ec)
                    frmLineQuery.ShowDialog()
                End If

                Me.dgvOnlineNotice.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvOnlineNotice_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvOnlineNotice.EditingControlShowing
        Try
            If Me.dgvOnlineNotice.CurrentCellAddress.X = 2 Or Me.dgvOnlineNotice.CurrentCellAddress.X = 3 Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(e.Control, DataGridViewMaskedTextBoxAdvEditingControl)
                ec.MaskedTextBox.ReadOnly = True
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub GetOnlineNotice()
        Try
            Dim strSQL As String
            strSQL = " SELECT  OnlineNoticeId, PartId, deptid, LineId, DemandTime, Remark, ApprovedUserId, ApprovedTime, CheckUserId, CheckTime, CreateUserId, CreateTime, StatusFlag + '-' + CASE StatusFlag WHEN 'N' THEN N'待审核' WHEN 'Y' THEN N'已审核' ELSE N'驳回' END AS StatusFlagText " & _
            " FROM m_OnlineNotice_t(NOLOCK) WHERE FactoryId = '" & VbCommClass.VbCommClass.Factory & "' AND ISNULL(Profitcenter, '')='" & VbCommClass.VbCommClass.profitcenter & "' AND m_OnlineNotice_t.CreateTime between cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) "

            If Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim) Then
                strSQL = strSQL & " AND PartId = '" & Me.txtPartid.Text.Trim & "' "
            End If

            If Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim) Then
                strSQL = strSQL & " AND LineId = '" & Me.txtPartid.Text.Trim & "' "
            End If

            Me.dgvOnlineNotice.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub GetOnlineNoticeEquipment(ByVal strOnlineNoticeId As String)
        Try
            Dim strSQL As String
            strSQL = " SELECT     OnlineNoticeEquipmentId, HardWarePartNumber, PartNumber, PartNumberFormat, Quantity, RecordsQuantity, Remark, StatusFlag, CreateUserId, CreateTime" & _
                    " FROM m_OnlineNoticeEquipment_t(NOLOCK) WHERE OnlineNoticeId = '" & strOnlineNoticeId & "' "

            Me.dgvOnlineNoticeEquipment.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.toolCheck.Enabled = True
                Me.toolReject.Enabled = True
                Me.btnAddRow.Enabled = False
                Me.btnDeleteRow.Enabled = False

                Me.dgvOnlineNotice.Columns.Item("PartId").ReadOnly = True
                Me.dgvOnlineNotice.Columns.Item("DeptId").ReadOnly = True
                Me.dgvOnlineNotice.Columns.Item("LineId").ReadOnly = True
                Me.dgvOnlineNotice.Columns.Item("DemandTime").ReadOnly = True
                Me.dgvOnlineNotice.Columns.Item("Remark").ReadOnly = True

                Me.dgvOnlineNoticeEquipment.Columns.Item("HardWarePartNumber").ReadOnly = True
                Me.dgvOnlineNoticeEquipment.Columns.Item("Quantity").ReadOnly = True
                Me.dgvOnlineNoticeEquipment.Columns.Item("CRemark").ReadOnly = True

            Case 1
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.toolCheck.Enabled = False
                Me.toolReject.Enabled = False
                Me.btnAddRow.Enabled = True
                Me.btnDeleteRow.Enabled = True

                'GroupBox

                If (toolValue = "ADD") Then

                    Me.dgvOnlineNotice.DataSource = Nothing
                    Me.dgvOnlineNoticeEquipment.DataSource = Nothing

                    Me.dgvOnlineNotice.Rows.Clear()
                    Me.dgvOnlineNoticeEquipment.Rows.Clear()

                    Me.dgvOnlineNotice.Rows.Add(1)
                    Me.dgvOnlineNoticeEquipment.Rows.Add(1)

                End If

                Me.dgvOnlineNotice.Columns.Item("PartId").ReadOnly = False
                Me.dgvOnlineNotice.Columns.Item("DeptId").ReadOnly = False
                Me.dgvOnlineNotice.Columns.Item("LineId").ReadOnly = False
                Me.dgvOnlineNotice.Columns.Item("DemandTime").ReadOnly = False
                Me.dgvOnlineNotice.Columns.Item("Remark").ReadOnly = False

                Me.dgvOnlineNoticeEquipment.Columns.Item("HardWarePartNumber").ReadOnly = False
                Me.dgvOnlineNoticeEquipment.Columns.Item("Quantity").ReadOnly = False
                Me.dgvOnlineNoticeEquipment.Columns.Item("CRemark").ReadOnly = False
        End Select
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

    Private Function CheckSava() As Boolean
        Try
            Dim rtValue As Boolean = False
            Dim strPartId As String
            Dim strDeptid As String
            Dim strLineId As String
            Dim strDemandTime As String

            strPartId = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("PartId").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("PartId").Value)
            strDeptid = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("Deptid").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("Deptid").Value)
            strLineId = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("LineId").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("LineId").Value)
            strDemandTime = IIf(IsDBNull(Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("DemandTime").Value), "", Me.dgvOnlineNotice.Rows(Me.dgvOnlineNotice.CurrentRow.Index).Cells("DemandTime").Value)

            If (String.IsNullOrEmpty(strPartId)) Then
                SetMessage(Me.lblMessage, "料号不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(strDeptid)) Then
                SetMessage(Me.lblMessage, "部门不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(strLineId)) Then
                SetMessage(Me.lblMessage, "产线不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(strDemandTime)) Then
                SetMessage(Me.lblMessage, "需求时间不能为空", False)
                Return False
            End If

            Dim strHardWarePartNumber As String
            Dim strPartNumber As String
            Dim strQuantity As String

            For i As Int16 = 0 To Me.dgvOnlineNoticeEquipment.Rows.Count - 1
                strHardWarePartNumber = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("HardWarePartNumber").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("HardWarePartNumber").Value)
                strPartNumber = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumber").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("PartNumber").Value)
                strQuantity = IIf(IsDBNull(Me.dgvOnlineNoticeEquipment.Rows(i).Cells("Quantity").Value), "", Me.dgvOnlineNoticeEquipment.Rows(i).Cells("Quantity").Value)

                If (String.IsNullOrEmpty(strHardWarePartNumber)) Then
                    SetMessage(Me.lblMessage, "第" & i + 1 & "五金料号不能为空", False)
                    Return False
                    Exit Function
                End If

                If (String.IsNullOrEmpty(strPartNumber)) Then
                    SetMessage(Me.lblMessage, "第" & i + 1 & "设备料号不能为空", False)
                    Return False
                    Exit Function
                End If

                If (String.IsNullOrEmpty(strQuantity)) Then
                    SetMessage(Me.lblMessage, "第" & i + 1 & "设备需求数不能为空", False)
                    Return False
                    Exit Function
                End If
            Next

            Return True
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try
    End Function

    Private Function CheckRowDelete(ByVal strOnlineNoticeEquipmentId As String) As Boolean
        Try
            Dim dtTemp As DataTable
            dtTemp = DbOperateUtils.GetDataTable("SELECT ISNULL(PrinteQuantity,0) FROM m_CustomerOrderDetail_t WHERE CustomerOrderDetailID = '" & strOnlineNoticeEquipmentId & "' AND DeleteFlag = '0' ")
            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                If (CInt(dtTemp.Rows(0).Item(0)) > 0) Then

                    SetMessage(lblMessage, "删除设备项次失败,已经分配审核!", False)
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            SetMessage(lblMessage, "检查设备状态信息异常!", False)
            Return True
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