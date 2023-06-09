#Region "Imports"
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
#End Region

Public Class FrmScanErrPrompt

    Dim ExitFlag As Boolean
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Sub New(ByVal Sn As String, ByVal ErrorStr As String)

        InitializeComponent()
        Me.LabSn.Text = "条码序号：" & Sn
        RTxtErrdes.Text = ErrorStr
        Me.CobError.SelectedIndex = 0
        Me.TxtUserPass.Focus()
        'Me.TxtMoid.Text = moid
        'Me.TxtPartid.Text = partid
        'Me.TxtStationid.Text = stationid.Split(" ")(0)
        '"LA06US573-1H" '' 
    End Sub

    Private Sub FrmScanError_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ExitFlag = True Then
            Exit Sub
        Else
            e.Cancel = True
        End If

    End Sub


    Private Sub FrmScanError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



       

    End Sub

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.TxtUserPass.Text = ""

    End Sub

    Private Sub TxtUserPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserPass.KeyPress

        If e.KeyChar = Chr(13) Then
            If InStr(TxtUserPass.ToString.ToLower, "accessory serial") > 0 Then
                TxtUserPass.Clear()
                Exit Sub
            End If
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click


        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
        If CobError.Text = "" Then
            MessageBox.Show("錯誤備注不能為空！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtUserPass.Text & "' and b.tkey='m0510b_'")
        If Not CheckRead.Read Then
            MessageBox.Show("密碼不正確或無權限！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'WorkStantOption.vDeserTionFlag = False
            CheckRead.Close()
            Me.TxtUserPass.Focus()
            Me.TxtUserPass.SelectAll()
        Else
            'Data.CheckStr = True
            CheckRead.Close()

            'If (WorkStantOption.vSq = "Y" And WorkStantOption.vMainBarCode.Trim <> "") Then
            '    DeserTionMainCodeBar()
            'Else
            '    WorkStantOption.vDeserTionFlag = False
            '    PubClass.ExecSql("update m_AssysnE_t with(rowlock) set Errormark='" & CobError.Text & "',Solvetime=getdate() where ppid='" & Data.BarCodeStr & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')=''")

            'End If

            ExitFlag = True
            Me.Close()
        End If

    End Sub

    'Private Function DeserTionMainCodeBar() As Boolean

    '    Dim RecDr As SqlDataReader = Nothing
    '    Dim sqlStr As New StringBuilder


    '    If WorkStantOption.vPreStation <> "" Then
    '        sqlStr.Append("delete from m_AssysnD_t where ppid='" & WorkStantOption.vMainBarCode & "' and stationid='" & WorkStantOption.vStandId & "' " & vbNewLine)
    '        sqlStr.Append("update m_Assysn_t set stationid='" & WorkStantOption.vPreStation & "' where ppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
    '        sqlStr.Append("delete from m_Ppidlink_t where exppid='" & WorkStantOption.vMainBarCode & "'  and usey='Y'  and stationid='" & WorkStantOption.vStandId & "' " & vbNewLine)
    '    Else
    '        sqlStr.Append("delete from m_AssysnD_t where ppid='" & WorkStantOption.vMainBarCode & "' " & vbNewLine)
    '        sqlStr.Append("delete from m_Assysn_t where ppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
    '        sqlStr.Append("delete from m_Ppidlink_t where exppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
    '    End If

    '    sqlStr.Append("update m_AssysnE_t with(ROWLOCK) set Errormark='" & CobError.Text & "',Solvetime=getdate() where ppid='" & Data.BarCodeStr & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')=''")

    '    Try
    '        Conn.ExecSql(sqlStr.ToString)
    '        WorkStantOption.vDeserTionFlag = True
    '    Catch ex As Exception
    '        WorkStantOption.vDeserTionFlag = False
    '        Exit Function
    '    End Try

    'End Function

End Class
