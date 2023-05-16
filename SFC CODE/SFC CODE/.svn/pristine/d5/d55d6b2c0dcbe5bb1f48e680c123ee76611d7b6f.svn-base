Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmSubmission
    Public moid, LineId, QTY, Prod, SP As String
    Private Sub FrmSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlStr As String = "select  DISTINCT b.ButtonID from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " &
        " inner JOIN deptline_t c ON c.lineid=b.ButtonID where b.tparent in('z09_','z0s_','z0t_','z0Y_') and a.userid='" + VbCommClass.VbCommClass.UseId + "' AND c.factoryid = '" + VbCommClass.VbCommClass.PCompany + "'"
        Dim dt2 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        Me.CobLine.Items.Clear()
        For cnt As Integer = 0 To dt2.Rows.Count - 1
            CobLine.Items.Add(dt2.Rows(cnt)(0).ToString)
        Next
        Me.dtpTime.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime1.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        If moid <> "" Then
            txtMOid.Enabled = False
            txtMOid.Text = moid
            TxtMoQty.Text = QTY
            TxtAvcPart.Text = Prod
            CobLine.Text = LineId
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If Int16.Parse(txtInspectionQuantity.Text) = 0 OrElse Int16.Parse(Int16.Parse(TxtMoQty.Text.Trim()) - Int16.Parse(txtInspectionQuantity.Text.Trim())) < 0 Then
            MessageUtils.ShowError("送检数量不能小于0或大于工单数量！")
            Exit Sub
        End If
        If CobLine.Text.Trim = "" Then
            MessageUtils.ShowError("线别不能为空！")
            Exit Sub
        End If
        If txtMOid.Text.Trim = "" Then
            MessageUtils.ShowError("工单不能为空！")
            Exit Sub
        End If
        Dim FQC As FQC.FQC = New FQC.FQC()
        Dim Model As FQC.SendFQCModel = New FQC.SendFQCModel
        Model.WorkOrderCode = "" + txtMOId.Text.Trim() + ""
        Model.Line = "" + CobLine.Text.Trim() + ""
        Model.UserCode = "" + VbCommClass.VbCommClass.UseId + ""
        Model.StorageQuantity = txtInspectionQuantity.Text.Trim()
        Model.BiaoQianTime = dtpTime.Text.Trim()
        Model.ProducDate = dtpTime1.Text.Trim()
        Model.Remark = RichTextBoxEx1.Text.Trim()
        Dim Sql As String = "SELECT TOP 1* FROM dbo.m_Mainmo_t (NOLOCK) WHERE Moid ='" + txtMOid.Text.Trim() + "' AND ParentMo<>Moid"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sql)
        Dim SPC As FQC.BizResultOfSendFQCResultModel
        If dt.Rows.Count > 0 Then
            SPC = FQC.SendSubFQC(Model)
        Else
            SPC = FQC.SendFQC(Model)
        End If
        Dim Code As String = SPC.Code
        Dim Message As String = SPC.Message
        Dim Result As FQC.SendFQCResultModel = SPC.Result

        If Code = "Error" Then
            MessageUtils.ShowError("SPC返回:" + Message)
            DialogResult = Windows.Forms.DialogResult.No
            Exit Sub
        Else
            Dim SPCNO As String = Result.SPCNO
            MessageUtils.ShowInformation("SPC返回:" + SPCNO)
            DialogResult = Windows.Forms.DialogResult.OK
            SP = SPCNO
            Me.Close()
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
    Private Sub txtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtMOid.ButtonCustomClick
        Try
            Dim FrmMOID As New FrmMOID
            If FrmMOID.ShowDialog() = DialogResult.OK Then
                txtMOid.Text = FrmMOID.mo
                TxtMoQty.Text = FrmMOID.MoQt
                TxtAvcPart.Text = FrmMOID.Part
                CobLine.Text = FrmMOID.Line
            End If
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub
End Class