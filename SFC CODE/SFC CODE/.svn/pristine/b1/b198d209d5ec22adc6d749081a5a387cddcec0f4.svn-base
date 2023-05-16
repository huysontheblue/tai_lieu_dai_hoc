Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmMOLock
#Region "变量定义"
    ''' <summary>
    ''' 工单的各个状态EstateID
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumMOState
        ConfirmStart = 1 '1	確認生產工單(firm plan) 	
        BOMNoPrint '2	工單已發放,料表尚未列印	
        BOMPrinted '3	工單已發放,料表已列印	
        MOSend '4	工單已發料	
        WIP '5	在製過程中	
        FQC '6	工單已完工,進入F.Q.C 	
        StoreIn '7	完工入庫	
        Close '8	結案	
        RBatchAndClose '9	工單成功分批并結案	
        Lock = 10
    End Enum
    Public Enum enumlockType
        Unlock = 0
        Lock = 1
    End Enum
#End Region

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Dim lssql As New StringBuilder
        Try
            If Not BaseDataCheck() Then
                Exit Sub
            End If

            If Me.txtBeforeMOState.Text.Substring(0, 2) = "10" Then  '--鎖定
                MessageUtils.ShowError("已經鎖定，无需重复操作!")
                Exit Sub
            End If

            ' moid,locktype, reason, userid, intime
            lssql.Append(" Insert into m_molockorunlocklog_t([MOID],locktype,Reason,UserID,Intime)")
            lssql.Append(" values('{0}',{1},N'{2}',N'{3}',GETDATE())")

            Dim o_strSQL As String = String.Format(lssql.ToString, Me.txtMOID.Text, CInt(enumlockType.Lock), Me.txtReason.Text.Trim.Replace("'", ""), VbCommClass.VbCommClass.UseId)
            ' Dim o_strSQL As String =String.Empty
            o_strSQL = o_strSQL + "  UPDATE m_mainmo_t SET EstateID='" & enumMOState.Lock & "' where moid ='" & Me.txtMOID.Text.Trim & "' and factory='" & VbCommClass.VbCommClass.Factory & "' and profitcenter ='" & VbCommClass.VbCommClass.profitcenter & "'"

            DbOperateUtils.ExecSQL(o_strSQL)
            MessageUtils.ShowInformation("工单锁定操作成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    '基础检查 
    Private Function BaseDataCheck() As Boolean
        If Me.txtReason.Text = "" Then
            MessageUtils.ShowError(" 必须输入原因！")
            txtReason.Focus()
            Return False
        End If
        Return True
    End Function


    Private Sub btnUnLock_Click(sender As Object, e As EventArgs) Handles btnUnLock.Click
        Dim lssql As New StringBuilder
        Try
            If Not BaseDataCheck() Then
                Exit Sub
            End If

            If Me.txtBeforeMOState.Text.Substring(0, 2) <> "10" Then  '--锁定
                MessageUtils.ShowError("不需要做解锁操作!")
                Exit Sub
            End If

            ' moid,locktype, reason, userid, intime
            lssql.Append(" Insert into m_molockorunlocklog_t([MOID],locktype,Reason,UserID,Intime)")
            lssql.Append(" values('{0}',{1},N'{2}',N'{3}',GETDATE())")

            Dim o_strSQL As String = String.Format(lssql.ToString, Me.txtMOID.Text, CInt(enumlockType.Unlock), Me.txtReason.Text.Trim.Replace("'", ""), VbCommClass.VbCommClass.UseId)
            ' Dim o_strSQL As String =String.Empty
            o_strSQL = o_strSQL + "  UPDATE m_mainmo_t SET EstateID='" & enumMOState.WIP & "' where moid ='" & Me.txtMOID.Text.Trim & "' and factory='" & VbCommClass.VbCommClass.Factory & "' and profitcenter ='" & VbCommClass.VbCommClass.profitcenter & "'"

            DbOperateUtils.ExecSQL(o_strSQL)
            MessageUtils.ShowInformation("工单解锁操作成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmMOLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class