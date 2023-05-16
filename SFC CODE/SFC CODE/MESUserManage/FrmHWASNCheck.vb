Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmHWASNCheck

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtOldASNQRCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOldASNQRCode.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(Me.txtOldASNQRCode.Text) Then
                MessageUtils.ShowError(" 旧ASN条码二维码不能为空 ")
                Me.txtOldASNQRCode.Focus()
                Exit Sub
            Else
                Me.txtNewASNQRCode.Focus()
                Me.lblMsg.Text = "请继续刷入新ASN条码二维码"
            End If
        End If
    End Sub

    Private Sub FrmHWASNCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lblMsg.Text = ""

    End Sub

    Private Sub txtNewASNQRCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewASNQRCode.KeyPress
        If e.KeyChar = Chr(13) Then

            If String.IsNullOrEmpty(Me.txtNewASNQRCode.Text) Then
                MessageUtils.ShowError(" 新ASN条码二维码不能为空 ")
                Me.txtNewASNQRCode.Focus()
                Exit Sub
            Else
                '进行比对
                Dim sqlHWASN As String =
              "declare  @Msg nvarchar(200),@ReturnValue int" & vbCrLf &
             "exec m_CheckHWASNQRCode  '" + Me.txtOldASNQRCode.Text.Trim + "','" + Me.txtNewASNQRCode.Text.Trim + "',@Msg out,@ReturnValue out" & vbCrLf &
             "select @Msg,@ReturnValue"
                Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(sqlHWASN)
                '条码判断
                If dtHWASN.Rows(0)(1).ToString() = "0" Then 'S19二维条码
                    '比对OK
                    Me.txtOldASNQRCode.Text = ""
                    Me.txtNewASNQRCode.Text = ""
                    ' Me.lblMsg.Text = "比对OK"
                    SetMessage("PASS", "比对OK")
                    Me.txtOldASNQRCode.Focus()
                ElseIf dtHWASN.Rows(0)(1).ToString() = "1" Then '抛错误信息
                    ' Me.lblMsg.Text = dtHWASN.Rows(0)(0).ToString()
                    SetMessage("FAIL", dtHWASN.Rows(0)(0).ToString())
                    Me.txtNewASNQRCode.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Me.txtOldASNQRCode.Text = ""
        Me.txtNewASNQRCode.Text = ""
        Me.lblMsg.Text = ""
    End Sub


    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            ' LabResult.Text = "FAIL"
            lblMsg.Text = message
            lblMsg.ForeColor = Color.Crimson
        Else
            ' LabResult.Text = "PASS"
            lblMsg.Text = message
            lblMsg.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class