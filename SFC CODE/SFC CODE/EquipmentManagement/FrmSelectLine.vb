Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmSelectLine

    Private Sub FrmSelectLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            initload()
        End If
    End Sub

    Private Sub initload()

        EquManageCommon.BindComboxClass(cboRequestClass)

        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If

        lblMsg.Text = ""
        ' SetUIValue()
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As New StringBuilder
        Dim strChecker As String = VbCommClass.VbCommClass.UseId
        Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
        Dim strProficenter As String = VbCommClass.VbCommClass.profitcenter
        Try
            'alList.Add("EquipmentNo|" & txtEquipment.Text.Trim)
            'alList.Add("Receiver|" & receiver)
            'alList.Add("Checker|" & VbCommClass.VbCommClass.UseId)
            'alList.Add("FactoryName|" & VbCommClass.VbCommClass.Factory)
            'alList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)
            'alList.Add("RequestID|" & requestID)

            'First check this equ, 是否可以借出
            If Not CheckInput() Then
                Exit Sub
            End If
            'prepare the data 
            ' Call SetUIValue()

            'eg : XT001 ==> XT003
            'For XT001, reference 入库logic
            sql.Append(" declare @RequestID varchar(50) ")
            sql.Append(" declare @ID varchar(50) ")
            sql.Append(" declare @QTY int ")
            sql.Append(" declare @ReturnQty int ")
            sql.Append("  begin try ")
            sql.Append("  Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t  ")
            sql.Append("  WHERE RequestID IS NOT NULL AND EquipmentNo ='" & Me.txtEquNo.Text.Trim & "' AND EEnable=0  ")
            sql.Append("  AND FactoryName='" & strFactoryName & "' AND Profitcenter='" & strProficenter & "'  ")
            sql.Append("  select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID ")
            sql.Append("  begin tran ")
            sql.Append("  if @QTY = @ReturnQty + 1 ")
            sql.Append("     begin  ")
            sql.Append("   Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID ")
            sql.Append("   end ")
            sql.Append(" else ")
            sql.Append("  begin ")
            sql.Append("  Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID ")
            sql.Append("  end ")
            sql.Append(" Update m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE() WHERE ID=@ID; ")
            sql.Append("  commit tran ")
            sql.Append("  end try ")
            sql.Append(" begin catch ")
            sql.Append("  rollback tran ")
            sql.Append("end catch ")

            'For XT003, reference 借出logic
            sql.Append(" DECLARE @Line varchar(50) ")
            sql.Append(" DECLARE @Storage nvarchar(50) ")
            sql.Append(" DECLARE @AlreadyBorrowQty int = 0 ")
            sql.Append(" DECLARE @oQTY int = 0 ")
            sql.Append(" DECLARE @UpdateStatus int  ")
            sql.Append(" BEGIN try ")
            sql.Append("  select @AlreadyBorrowQty=isnull(Replace(AlreadyBorrowQty,' Set',''),0), ")
            sql.Append("      @QTY=isnull(Replace(QTY,' Set',''),0),@Line = A.Line, @Storage = B.Storage ")
            sql.Append("  from m_Equipment_App_t  A ")
            sql.Append("    inner join  m_Equipment_t  B ")
            sql.Append("    on  A.EquipmentPNumber = B.PartNumber ")
            sql.Append("  where  A.ID = '" & Me.lblReceiveLineAppID.Text.Trim & "' and B.InOut = 1  AND B.EquipmentNo = '" & Me.txtEquNo.Text.Trim & "'   ")
            sql.Append("   AND A.FactoryName='" & strFactoryName & "' AND A.Profitcenter='" & strProficenter & "' ")
            sql.Append("   AND B.FactoryName=A.FactoryName AND B.Profitcenter=A.Profitcenter ")
            sql.Append("  if @AlreadyBorrowQty +1 = @QTY ")
            sql.Append("     begin  ")
            sql.Append("    set @UpdateStatus = 4 ")
            sql.Append("   end ")
            sql.Append("    else ")
            sql.Append("   begin  ")
            sql.Append("set @UpdateStatus = 2 ")
            sql.Append("  end ")
            sql.Append("   if @QTY = 0 OR @QTY = @AlreadyBorrowQty ")
            sql.Append("   begin  ")
            sql.Append("   return ")
            sql.Append("end ")
            sql.Append("  print @UpdateStatus ")
            sql.Append("   begin tran ")
            sql.Append(" update m_Equipment_App_t ")
            sql.Append(" set AlreadyBorrowQty = @AlreadyBorrowQty + 1 , ")
            sql.Append("   AStatus1 = @UpdateStatus ")
            sql.Append("  where ID = '" & Me.lblReceiveLineAppID.Text & "' ")
            sql.Append("   insert m_Equipment_BorrRetu_t ")
            sql.Append("  (EquipmentNo, EStatus, EEnable, Receiver, Checker, OutTime, Line, Storage, FactoryName, Profitcenter, RequestID) ")
            sql.Append(" values('" & Me.txtEquNo.Text.Trim & "',N'出库',0,'" & Me.txtOutToUserID.Text.Trim & "','" & strChecker & "',GETDATE(),'" & Me.cboRequestLine.SelectedValue.ToString & "',@Storage,'" & strFactoryName & "','" & strProficenter & "', '" & Me.lblReceiveLineAppID.Text & "') ")
            sql.Append("  UPDATE m_Equipment_t ")
            sql.Append("    set InOut =0, ")
            sql.Append("   OutUserID = '" & Me.txtOutToUserID.Text.Trim & "', ")
            sql.Append("   OutTime=getdate(),Lineid='" & Me.cboRequestLine.SelectedValue.ToString & "' ")
            sql.Append(" where EquipmentNo ='" & Me.txtEquNo.Text.Trim & "' AND FactoryName='" & strFactoryName & "' AND Profitcenter='" & strProficenter & "' ")
            sql.Append(" commit tran ")
            sql.Append(" end try ")
            sql.Append(" begin catch ")
            sql.Append(" rollback tran ")
            sql.Append(" end catch ")

            'add log, cq 201
            '           CREATE TABLE [dbo].[m_EquipmentLendLog_t](
            '[EquipmentNo] [varchar](20) NULL,
            '[FromLineID] [varchar](10) NULL,
            '[ToLineID] [varchar](10) NULL,
            '[FromUserID] [varchar](10) NULL,
            '[OutToUserID] [varchar](10) NULL,
            '[Intime] [datetime] NULL

            sql.Append(" INSERT m_EquipmentLendLog_t ")
            sql.Append("  (EquipmentNo, FromLineID, ToLineID, FromUserID, OutToUserID, Intime) ")
            sql.Append(" values('" & Me.txtEquNo.Text.Trim & "',N'" & Me.txtLineID.Text.Trim & "','" & Me.cboRequestLine.SelectedValue.ToString & "',")
            sql.Append(" '" & Me.txtGiveUserID.Text.Trim & "','" & Me.txtOutToUserID.Text.Trim & "',GETDATE()) ")


            DbOperateUtils.ExecSQL(sql.ToString)

            MessageUtils.ShowInformation("转借成功")
            Me.Close()

        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmSelectLine", "btnSave_Click", "WIP")
        End Try

    End Sub




    Private Function CheckInput() As Boolean
        'xt001 --> xt 003,
        If IsNothing(Me.cboRequestLine.SelectedValue) OrElse String.IsNullOrEmpty(Me.cboRequestLine.SelectedValue.ToString) Then
            SetMessage("E", "请选择线别！")
            Return False
        End If

        'check the selected line whether have request record
        If Not HaveRequest() Then
            SetMessage("E", "没有给线别:[" & Me.cboRequestLine.SelectedValue.ToString & "] 申请此类工治具,请先申请！")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtOutToUserID.Text.Trim()) Then
            SetMessage("E", "请填写借出给的人的工号！")
            Return False
        End If

        If Me.cboRequestLine.SelectedValue.ToString = Me.txtLineID.Text.Trim Then
            SetMessage("E", "不能借给相同的线别，请重新选择！")
            Return False
        End If

        Return True
    End Function

    Private Function HaveRequest() As Boolean
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        lsSQL = " SELECT ID FROM m_Equipment_App_t " & _
                " WHERE EquipmentPNumber ='" & txtEquPN.Text.Trim & "'  " & _
                " AND LINE ='" & Me.cboRequestLine.SelectedValue.ToString & "'" & _
                " AND ASTATUS1 NOT IN (0)  "
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) And o_dt.Rows.Count > 0 Then
                HaveRequest = True
                Me.lblReceiveLineAppID.Text = o_dt.Rows(0).Item(0)
            Else
                HaveRequest = False
            End If
        End Using
        Return HaveRequest
    End Function


    Private Sub SetMessage(ByVal type As String, ByVal msg As String)
        Select Case type
            Case "E"
                Me.lblMsg.Text = msg
                Me.lblMsg.BackColor = Drawing.Color.Red
            Case Else
                'do nothing
        End Select
    End Sub




    Private Sub btnCancal_Click(sender As Object, e As EventArgs) Handles btnCancal.Click
        Me.Close()
    End Sub

    Private Sub cboRequestLine_SelectedIndexChanged(sender As Object, e As EventArgs)




    End Sub

    Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If
    End Sub
End Class