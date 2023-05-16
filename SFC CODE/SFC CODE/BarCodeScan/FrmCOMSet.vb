Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmCOMSet

    Private Sub FrmCOMSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        SetInitValue()
        GetCurrentCOMValue()
    End Sub

    Private Sub GetCurrentCOMValue()
        Dim lsSQL As String = String.Empty, strSetCOM As String = ""
        lsSQL = " SELECT Text,MachineType FROM m_AutoScanBaseData_t WHERE value ='" & My.Computer.Name & "'"
        Me.txtIP.Text = ""
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If o_dt.Rows.Count > 0 Then
                If o_dt.Rows(0).Item(1).ToString <> "3" Then
                    Me.txtCOMValue.Text = o_dt.Rows(0).Item(0).ToString.Split("|")(0)
                    Me.TxtBaudRate.Text = o_dt.Rows(0).Item(0).ToString.Split("|")(1)
                    Me.TxtCheckByte.Text = o_dt.Rows(0).Item(0).ToString.Split("|")(2)
                    Me.TxtDataByte.Text = o_dt.Rows(0).Item(0).ToString.Split("|")(3)
                    Me.TxtStopByte.Text = o_dt.Rows(0).Item(0).ToString.Split("|")(4)
                    '东莞机台 
                    If o_dt.Rows(0).Item(1).ToString = "1" Then
                        rdoMachine1.Checked = True
                        SetEnabled(False)
                    ElseIf o_dt.Rows(0).Item(1).ToString = "2" Then  '江西机台
                        rdoMachine2.Checked = True
                    ElseIf o_dt.Rows(0).Item(1).ToString = "4" Then
                        rblXN.Checked = True
                    Else  '东莞机台 
                        rdoMachine1.Checked = True
                        SetEnabled(False)
                    End If
                Else
                    Me.txtIP.Text = o_dt.Rows(0).Item(0).ToString
                End If
            End If
        End Using
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrEmpty(Me.txtCOMValue.Text) Then
            MessageUtils.ShowError("通信端口的值不能为空！")
            Me.txtCOMValue.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.TxtBaudRate.Text) Then
            MessageUtils.ShowError("波特率不能为空！")
            Me.TxtBaudRate.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.TxtCheckByte.Text) Then
            MessageUtils.ShowError("校验位不能为空！")
            Me.TxtCheckByte.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.TxtDataByte.Text) Then
            MessageUtils.ShowError("数据位不能为空！")
            Me.TxtDataByte.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.TxtStopByte.Text) Then
            MessageUtils.ShowError("停止位不能为空！")
            Me.TxtStopByte.Focus()
            Exit Sub
        End If
        Dim strSetText As String = String.Format("{0}|{1}|{2}|{3}|{4}", Me.txtCOMValue.Text.Trim, Me.TxtBaudRate.Text.Trim,
        TxtCheckByte.Text.Split("-")(0).Trim, TxtDataByte.Text.Trim, TxtStopByte.Text.Trim)
        Dim strMachine As String = IIf(Me.rdoMachine1.Checked = True, "1", "2")
        If rblXN.Checked = True Then
            strMachine = "4"
        End If
        Call UpdateComValue(strSetText, strMachine)

        Me.Close()
    End Sub

    '更新COM口数据
    Private Sub UpdateComValue(ByVal strSetText As String, ByVal strMachine As String)
        Try
            'Dim strSetText As String = String.Format("{0}|{1}|{2}|{3}|{4}", Me.txtCOMValue.Text.Trim, Me.TxtBaudRate.Text.Trim,
            'TxtCheckByte.Text.Trim, TxtDataByte.Text.Trim, TxtStopByte.Text.Trim)
            'Dim strMachine As String = IIf(Me.rdoMachine1.Checked = True, "1", "2")
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_AutoScanRecordCOM_P] '" & My.Computer.Name & "', '" & strSetText & "',  ")
            strSQL.AppendFormat(" '{0}','{1}' ,@RTVALUE OUTPUT, @strmsgText OUTPUT ", strMachine, VbCommClass.VbCommClass.UseId)
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmCOMSet", "UpdateComValue", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCOMSet", "RecordLineInfo", "UpdateComValue")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub rdoMachine1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMachine1.CheckedChanged
        SetInitValue()
        SetEnabled(False)
    End Sub

    Private Sub rdoMachine2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMachine2.CheckedChanged, rblXN.CheckedChanged
        SetEnabled(True)
    End Sub

    Private Sub SetInitValue()
        TxtBaudRate.Text = "38400"
        TxtCheckByte.Text = "0"
        TxtDataByte.Text = "8"
        TxtStopByte.Text = "1"
    End Sub

    Private Sub SetEnabled(bFlag As Boolean)
        TxtBaudRate.Enabled = bFlag
        TxtCheckByte.Enabled = bFlag
        TxtDataByte.Enabled = bFlag
        TxtStopByte.Enabled = bFlag
    End Sub

    Private Sub btnConfirmMod_Click(sender As Object, e As EventArgs) Handles btnConfirmMod.Click
        If String.IsNullOrEmpty(Me.txtIP.Text) Then
            MessageUtils.ShowError("IP不能为空！")
            Me.txtIP.Focus()
            Exit Sub
        End If
        Dim strSetText As String = Me.txtIP.Text.Trim
        Dim strMachine As String = "3"
        Call UpdateComValue(strSetText, strMachine)

        Me.Close()
    End Sub

    Private Sub btnCancelMod_Click(sender As Object, e As EventArgs) Handles btnCancelMod.Click

    End Sub
End Class