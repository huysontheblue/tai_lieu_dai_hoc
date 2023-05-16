Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmHWOQCSet
    Public OQCSetting As New ScanSetting
    Public Sub New()
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _scanSetting As ScanSetting)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        LoadItemData()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim partid As String = txtPartID.Text.Trim.ToUpper
        Dim lineid As String = txtLineID.Text.Trim.ToUpper
        Dim planqty As String = txtSampleQty.Text.Trim.ToUpper
        Dim totalqty As String = txtTotalQty.Text.Trim.ToUpper
        Dim sino As String = txtSINo.Text.Trim.ToUpper
        Dim userid As String = VbCommClass.VbCommClass.UseId
        Dim factory As String = VbCommClass.VbCommClass.Factory
        Dim profit As String = VbCommClass.VbCommClass.profitcenter
        If Not Check() Then
            Exit Sub
        End If
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("DECLARE @SINO varchar(20)='" + sino + "', @SIType varchar(5)='" + cboType.Text + "' ,@SIStatus int =0, @SaveType varchar(10)='', @Msg nvarchar(50), @RetVal varchar(5)")
            strSQL.AppendLine("EXECUTE  [dbo].[Exec_HWSISet]  @SINO  ,@SIType ,'" + partid + "' ,'" + lineid + "'," + totalqty + "," + planqty + ",@SIStatus " & _
              ",'" + userid + "' ,''  ,@SaveType  ,'" + factory + "','" + profit + "'  ,@Msg OUTPUT  ,@RetVal OUTPUT ")
            strSQL.AppendLine(" SELECT @RetVal ,@Msg  ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        MessageUtils.ShowInformation(dt.Rows(0)(1).ToString)
                    Case "1" 'SINO
                        OQCSetting.CodeRuleID = dt.Rows(0)(1).ToString
                        OQCSetting.PartidStr = partid
                        OQCSetting.LineStr = lineid
                        OQCSetting.MoTotalScanQty = totalqty
                        OQCSetting.PartPackQty = planqty
                        OQCSetting.vPackType = cboType.Text
                        Me.Close()
                End Select
            End If
        Catch
            MessageBox.Show("设置异常，请重新设置!")
            Me.Close()
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmHWOQCSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPartID.Focus()
    End Sub
    Private Sub Clear()
        txtPartID.Text = ""
        txtLineID.Text = ""
        txtTotalQty.Text = ""
        txtSampleQty.Text = ""
        txtSINo.Text = ""
    End Sub
    Private Function Check() As Boolean
        If (cboType.Text.Trim = "") Then
            txtSampleQty.Focus()
            MessageUtils.ShowInformation("扫描类型不能为空!")
            Return False
            Exit Function
        End If
        If txtPartID.Text.Trim = String.Empty Then
            txtPartID.Focus()
            MessageUtils.ShowInformation("请填写料件编号!")
            Return False

        End If
        If txtLineID.Text.Trim = String.Empty Then
            txtLineID.Focus()
            MessageUtils.ShowInformation("请填写线别编号!")
            Return False
            Exit Function
        End If
        If txtTotalQty.Text.Trim = String.Empty Then
            txtTotalQty.Focus()
            MessageUtils.ShowInformation("请填写总数量!")
            Return False
            Exit Function
        End If
        If txtSampleQty.Text.Trim = String.Empty Then
            txtSampleQty.Focus()
            MessageUtils.ShowInformation("请填写抽检数量!")
            Return False
            Exit Function
        End If
        If Not IsNumeric(txtTotalQty.Text.Trim) Then
            txtTotalQty.Focus()
            MessageUtils.ShowInformation("总数量不是数字!")
            Return False
            Exit Function
        End If
        If Not IsNumeric(txtSampleQty.Text.Trim) Then
            txtSampleQty.Focus()
            MessageUtils.ShowInformation("抽检数量不是数字!")
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Sub LoadItemData()
        Dim strSQL As String =
        "SELECT  A.SINO ,A.PartID ,A.LineID ,TotalQTY ,A.PlanSIQTY ,COUNT(PPID) QTY,A.SITYPE FROM m_HWSISET_t A LEFT JOIN M_HWSISCAN_T B ON A.SINO=B.SINO WHERE    A.CreateUser  ='{0}' AND SIStatus ='0' GROUP BY A.SINO ,A.PartID ,LineID ,TotalQTY ,PlanSIQTY,A.SITYPE "
        strSQL = String.Format(strSQL, VbCommClass.VbCommClass.UseId)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Dim orderIndex As Integer = 0
        If dt.Rows.Count > 0 Then
            OQCSetting.CodeRuleID = dt.Rows(0)("SINO").ToString
            OQCSetting.PartidStr = dt.Rows(0)("PartID").ToString
            OQCSetting.LineStr = dt.Rows(0)("LineID").ToString
            OQCSetting.MoTotalScanQty = Integer.Parse(dt.Rows(0)("TotalQTY").ToString)
            OQCSetting.PartPackQty = dt.Rows(0)("PlanSIQTY").ToString
            OQCSetting.vPackType = cboType.Text
            txtSINo.Visible = True
            cboType.Text = dt.Rows(0)("SITYPE").ToString
            txtSINo.Text = OQCSetting.CodeRuleID
            txtPartID.Text = OQCSetting.PartidStr
            txtLineID.Text = OQCSetting.LineStr
            txtTotalQty.Text = OQCSetting.MoTotalScanQty.ToString
            txtSampleQty.Text = OQCSetting.PartPackQty
        Else
            OQCSetting.CodeRuleID = ""
            OQCSetting.PartidStr = ""
            OQCSetting.LineStr = ""
            OQCSetting.MoTotalScanQty = 0
            OQCSetting.vPackType = ""
            OQCSetting.PartPackQty = ""
            cboType.Text = ""
            txtPartID.Text = ""
            txtLineID.Text = ""
            txtTotalQty.Text = ""
            txtSampleQty.Text = ""
            txtSINo.Visible = False
        End If

    End Sub

    Private Sub txtPartID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartID.KeyPress
        If e.KeyChar = Chr(13) Then
            txtLineID.Focus()
        End If

    End Sub

    Private Sub txtLineID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLineID.KeyPress
        If e.KeyChar = Chr(13) Then
            txtTotalQty.Focus()
        End If
    End Sub

    Private Sub txtTotalQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalQty.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSampleQty.Focus()
        End If
    End Sub
End Class