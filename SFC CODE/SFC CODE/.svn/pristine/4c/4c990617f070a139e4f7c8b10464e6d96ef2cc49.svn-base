Imports System.Data.SqlClient

Public Class FrmTranWH

    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader

    Private Sub LoadFloor()
        Dim strSql As String

        '更加糷
        CobFloor.Items.Clear()
        strSql = " select distinct(floorid) from m_wh_t where floorid is not null order by 1 "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobFloor.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
        CobFloor.SelectedIndex = -1
    End Sub

    Private Sub Init()
        LoadFloor()
    End Sub

    Private Sub FrmTranWH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Close()
    End Sub

    Private Sub btConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirm.Click
        MsgBox("巨Θ", 48, "矗ボ獺")
        Close()
    End Sub

    Private Sub CobFloor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobFloor.SelectedIndexChanged
        Dim strSql As String

        '更畐嘿
        CobWHName.Items.Clear()
        strSql = " select distinct whid, whname from m_wh_t where floorid='" & CobFloor.Text & "'  "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobWHName.Items.Add(Rs(0).ToString & "-" & Rs(1).ToString)
        End While
        CobWHName.SelectedIndex = -1
        Rs.Close()

        '更纗嘿
        CobArea.Items.Clear()
        strSql = " select distinct areaid from m_wharea_t where floorid='" & CobFloor.Text & "' "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobArea.Items.Add(Rs(0).ToString)
        End While
        CobArea.SelectedIndex = -1
        Rs.Close()
    End Sub
End Class