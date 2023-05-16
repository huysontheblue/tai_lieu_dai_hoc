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
Public Class FrmReworkRouteSet
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim opflag As Int16 = 0

    Private Sub FrmReworkRouteSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData(" where 1=1 ")
    End Sub
    Private Sub LoadData(ByVal SqlWhere As String)
        Dim dt As DataTable
        Dim SqlStr As String = ""

        'dgvRstation.DataSource
        SqlStr = "select Partid N'料号编码',Stationid N'子站点',StationName N'子站点名称',StationType N'子站点类型',parentStation N'父站点',case when usey='Y' then N'Y-有效'  when usey='N' then  N'N-作废' end states,BackStationid N'不良回流站点',userid N'设置人',intime N'设置时间' from m_ChildStation_t " & SqlWhere
        dt = Conn.GetDataTable(SqlStr)
        If dt.Rows.Count > 0 Then
            dgvRstation.DataSource = dt
        End If
        Conn.PubConnection.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
    End Sub

    Private Sub dgvRstation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvRstation.Click
        If dgvRstation.RowCount < 1 Then Exit Sub
        'If Searchy = True Then Exit Sub
        SetValueToControl()
    End Sub

    Private Sub SetValueToControl()

        If dgvRstation.RowCount < 1 Then Exit Sub
        If Me.dgvRstation.CurrentRow.Index < 0 Then Exit Sub
        If opflag <> 0 Then
            Exit Sub
        End If


        Me.txtPart.Text = Me.dgvRstation.Item(0, dgvRstation.CurrentRow.Index).Value.ToString
        Me.cobSunStation.Text = Me.dgvRstation.Item(1, dgvRstation.CurrentRow.Index).Value.ToString
        Me.cobPatStation.Text = Me.dgvRstation.Item(4, dgvRstation.CurrentRow.Index).Value.ToString
        Me.txtBackStation.Text = Me.dgvRstation.Item(6, dgvRstation.CurrentRow.Index).Value.ToString
        ChkUsey.Checked = IIf(Me.dgvRstation.Item(5, dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "Y", True, False)

    End Sub

    Private Sub toolAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        txtPart.Clear()
        txtBackStation.Clear()
        cobPatStation.Text = ""
        cobSunStation.Text = ""
        txtPart.Enabled = True
        cobSunStation.Enabled = True
        cobPatStation.Enabled = True
        txtBackStation.Enabled = True
        ChkUsey.Enabled = True
        opflag = 1
        ChkUsey.Checked = True
    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        'txtPart.Enabled = True
        'cobSunStation.Enabled = True
        cobPatStation.Enabled = True
        txtBackStation.Enabled = True
        ChkUsey.Enabled = True
        opflag = 2
    End Sub

    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
      Try
            Conn.ExecSql("update [m_ChildStation_t] set usey='N' where Partid='" & txtPart.Text.Trim & "' and Stationid='" & cobSunStation.Text.Trim & "'")
            Conn.PubConnection.Close()
            LoadData(" where Partid='" & txtPart.Text.Trim & "' and Stationid='" & cobSunStation.Text.Trim & "'")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误提示")
        End Try
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Rtable As New DataTable
        Dim SqlStr As String = ""
        Dim usey As String = ""
        If ChkUsey.Checked Then
            usey = "Y"
        Else
            usey = "N"
        End If
        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then

            Dim dt As DataTable
            Dim strStationname As String = ""
            Dim strStationtype As String = ""
            dt = Conn.GetDataTable("select Stationid,Stationname,Stationtype from m_Rstation_t where usey='Y' and Stationid='" & cobSunStation.Text.Trim & "'")
            If dt.Rows.Count > 0 Then
                strStationname = dt.Rows(0)(1)
                strStationtype = dt.Rows(0)(2)
            End If

            Conn.PubConnection.Close()

            SqlStr = "INSERT INTO [MESDB].[dbo].[m_ChildStation_t]([Partid],[Stationid],[StationName],[StationType],[parentStation],[usey],[intime],[userid],[BackStationid]) " _
                     & " values('" & txtPart.Text.Trim & "',N'" & cobSunStation.Text.Trim & "',N'" & strStationname & "',N'" & strStationtype & "'," _
                     & " N'" & cobPatStation.Text.Trim & "','" & usey & "',getdate(),'" & SysMessageClass.UseId & "','" & txtBackStation.Text.Trim & "' ) "
        ElseIf opflag = 2 Then
            SqlStr = "update [m_ChildStation_t] set parentStation='" & cobPatStation.Text.Trim & "',usey='" & usey & "',BackStationid='" & txtBackStation.Text.Trim & "' where Partid='" & txtPart.Text.Trim & "' and Stationid='" & cobSunStation.Text.Trim & "'"
        End If
        Try
            'Rtable = Conn.GetDataTable(SqlStr.ToString)
            Conn.ExecSql(SqlStr)
            LoadData(" where Partid='" & txtPart.Text.Trim & "' and Stationid='" & cobSunStation.Text.Trim & "'")
            Conn.PubConnection.Close()
        Catch ex As Exception
            'SysMessageClass.WriteErrLog(ex, "错误提示")
            MessageBox.Show(ex.Message, "错误提示")
        Finally
            txtPart.Enabled = False
            cobSunStation.Enabled = False
            cobPatStation.Enabled = False
            txtBackStation.Enabled = False
            ChkUsey.Enabled = False
            opflag = 0
            ChkUsey.Checked = False
        End Try
    End Sub

    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtPart.Clear()
        cobSunStation.Text = ""
        cobPatStation.Text = ""
        txtBackStation.Clear()
        txtPart.Enabled = False
        cobSunStation.Enabled = False
        cobPatStation.Enabled = False
        txtBackStation.Enabled = False
        ChkUsey.Enabled = False
        opflag = 0
        ChkUsey.Checked = False
    End Sub
    Private Function Checkdata() As Boolean

        If txtPart.Text.Trim = "" Then
            MessageBox.Show("料件编码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPart.Focus()
            Return False
        End If
        If cobSunStation.Text = "" Then
            MessageBox.Show("子站点编码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cobSunStation.Focus()
            Return False
        End If
        If cobPatStation.Text = "" Then
            MessageBox.Show("父站点编码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cobPatStation.Focus()
            Return False
        End If
        If txtBackStation.Text = "" Then
            MessageBox.Show("回流站编码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cobSunStation.Focus()
            Return False
        End If
        If opflag = 1 Then
            Dim Dreader As SqlDataReader
            Dreader = Conn.GetDataReader("select Stationid from m_ChildStation_t where Stationid='" & cobSunStation.Text.Trim & "' and Partid='" & txtPart.Text.Trim & "'")
            If Dreader.HasRows Then
                MessageBox.Show("已经存在该子站点编码", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dreader.Close()
                Return False
            End If
            Dreader.Close()
            Conn.PubConnection.Close()
        End If

        Return True
    End Function


    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadData(" where 1=1 ")
    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class