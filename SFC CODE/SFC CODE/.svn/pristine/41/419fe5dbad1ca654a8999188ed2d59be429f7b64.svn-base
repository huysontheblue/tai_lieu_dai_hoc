Imports System.IO
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame
Public Class FrmBarCodePint
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Private Sub ButFileView_Click(sender As Object, e As EventArgs) Handles ButFileView.Click
        Me.OpenFileDialog1.ShowDialog()
        Me.OpenFileDialog1.Multiselect = False
        Dim sql As String = "UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" + Me.TxtFileName.Text + "' WHERE PARAMETER_CODE='BarcodeSnPrint'"
        DbOperateUtils.GetDataTable(sql)
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.TxtFileName.Text = Me.OpenFileDialog1.FileName
    End Sub
    Public Function BartendPrint(ByRef Sn As String) As Boolean
        Dim path As String = Me.TxtFileName.Text.Trim()
        Try
            btFormat = btApp.Formats.Open(path, False, "")
        Catch ex As Exception
            MessageBox.Show("加载BarTender实例失败！" + ex.Message)
        End Try

        Try
            btFormat.SetNamedSubStringValue("SN", Sn)
            btFormat.PrintOut(True, False)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            BartendPrint = True
        Catch ex As Exception
            MessageBox.Show("打印异常," + ex.Message)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            BartendPrint = False
        End Try
    End Function
    Private Sub FrmBarCodePint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mDataReader As DataTable = DbOperateUtils.GetDataTable("SELECT PARAMETER_VALUES FROM m_SystemSetting_t WHERE PARAMETER_CODE='BarcodeSnPrint'")
        If mDataReader.Rows.Count > 0 Then
            Me.TxtFileName.Text = mDataReader.Rows(0)!PARAMETER_VALUES.ToString
        End If
        btApp = New BarTender.Application()
    End Sub

    Private Sub BnOpenlock_Click(sender As Object, e As EventArgs) Handles BnOpenlock.Click
        Dim Userid As String = VbCommClass.VbCommClass.UseId
        If txtNewBarCode.Text = "" Then
            MessageBox.Show("条码不能为空！")
            Exit Sub
        End If
        If BartendPrint(txtNewBarCode.Text) = True Then
            Dim sql As String = "INSERT INTO M_Printlog_t(SN,USERID,InTime)VALUES('" + txtNewBarCode.Text + "','" + Userid + "',getdate())"
            DbOperateUtils.GetDataTable(sql)
            MessageBox.Show("打印OK！")
            txtNewBarCode.Text = ""
        End If
    End Sub

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub
End Class