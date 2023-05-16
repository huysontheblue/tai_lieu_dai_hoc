Imports MainFrame.SysCheckData
Imports Microsoft.Win32
Imports MainFrame
Imports System.Text

Public Class FrmPCCOMSet



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

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

        Call UpdateComValue()

        Me.Close()

    End Sub



    '更新COM口数据
    Private Sub UpdateComValue()
        Try
            Dim strSetText As String = String.Format("{0}|{1}", Me.txtCOMValue.Text.Trim, Me.TxtBaudRate.Text.Trim)
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_HWWeightBaseDataRecordCOM_P] '" & My.Computer.Name & "', '" & strSetText & "',  ")
            strSQL.AppendFormat(" '{0}' ,@RTVALUE OUTPUT, @strmsgText OUTPUT ", VbCommClass.VbCommClass.UseId)
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmPCCOMSet", "UpdateComValue", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPCCOMSet", "RecordLineInfo", "UpdateComValue")
        End Try
    End Sub


    Private Sub FrmPCCOMSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        Call GetComList()
        ' GetCurrentCOMValue()
    End Sub


    ''' <summary>
    ''' 获取COM口
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetComList()
        Dim keyCom As RegistryKey = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm")
        If Not keyCom Is Nothing Then
            Dim sSubKeys() As String = keyCom.GetValueNames()
            Me.txtCOMValue.Items.Clear()
            Dim sName As String
            For Each sName In sSubKeys
                Dim sValue As String = CType(keyCom.GetValue(sName), String)
                Me.txtCOMValue.Items.Add(sValue)
            Next
        End If
    End Sub
End Class