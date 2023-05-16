#Region "Importsまノ"

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

#End Region
Public Class FrmPartCope

    Dim Conn As New SysDataBaseClass

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If TxtToPartid.Text.Trim = "" Then Exit Sub
        Dim Reader As SqlDataReader = Conn.GetDataReader(" select distinct TAvcPart from m_PartContrast_t where PAvcPart='" & TxtToPartid.Text & "' or TAvcPart='" & TxtToPartid.Text & "'")
        If Reader.HasRows Then
            Reader.Close()
            MessageBox.Show("系统中已经维护过该料件编号的资料,请删除再复制作业...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Reader.Close()
        Dim mSqlStr As String = " insert into m_PartContrast_t select replace([TAvcPart],'" & TxtPartid.Text & "','" & TxtToPartid.Text & "') TAvcPart, [PartName] " & _
          " ,[PAvcPart] ,[CusID],[CustPart] ,[MethodID] ,[UseY],[LmtY],[WarnDate] ,[Userid] ,[Intime] ,[TypeDest]" & _
          " ,[PartCode],[Supplierid],[IsUpload] ,[Isasseble],[IsLotScan],[IsAlter],[MaterialAlter],[IsPrintFile])"

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButQuery.Click

        If TxtPartid.Text.Trim = "" Then Exit Sub
        Dim Reader As SqlDataReader = Conn.GetDataReader(" select distinct TAvcPart,PartName,PAvcPart,CusID,CustPart,PartCode,TypeDest,Supplierid from m_PartContrast_t where PAvcPart='" & TxtPartid.Text & "' or TAvcPart='" & TxtPartid.Text & "'")
        If Reader.HasRows Then
            DgPart.Rows.Add(Reader!TAvcPart, Reader!PartName, Reader!PAvcPart, Reader!CusID, Reader!CustPart, Reader!PartCode, Reader!TypeDest, Reader!Supplierid)
        Else
            Reader.Close()
            MessageBox.Show("系统中不存在该料件编号的资料...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Reader.Close()

    End Sub
End Class
