Imports System.Data.SqlClient

'****************************************************************************
'* 文件名稱：FrmWHChange.vb
'* 摘    要：倉庫儲位調撥源程序
'* 當前版本：1.01
'* 作    者：Tim Liu
'* 完成日期：2007年11月20日
'****************************************************************************

Public Class FrmWHChange

    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub Init()
        FillComboLine(CobFloor)
        FillComboLine(CobWH)
        FillComboLine(CobArea)
        FillComboLine(CobMO)
        FillComboLine(CobPart)
        FillComboLine(CobPallet)
        FillComboLine(CobCarton)
        CobFloor.Focus()
    End Sub

    Private Sub LoadProdList()
        Dim strSql As String

        strSql = " select c.moid, a.partid, b.cartonid,  b.cartonqty, c.floorid, c.whid, c.areaid " _
               & " from m_mainmo_t a,  m_carton_t b, m_whinm_t c , m_whind_t d where a.moid=b.moid " _
               & " and b.moid=c.moid and b.cartonid=d.cartonid and c.inwhid=d.inwhid " _
               & " and b.cartonstatus='I'  "

        If CobFloor.Text <> "ALL" Then
            strSql = strSql & " and c.floorid='" & CobFloor.Text & "' "
        End If

        If CobWH.Text <> "ALL" Then
            strSql = strSql & " and c.whid='" & CobWH.Text & "' "
        End If

        If CobArea.Text <> "ALL" Then
            strSql = strSql & " and c.areaid='" & CobWH.Text & "' "
        End If

        If CobMO.Text <> "ALL" Then
            strSql = strSql & " and a.moid='" & CobMO.Text & "' "
        End If

        If CobPart.Text <> "ALL" Then
            strSql = strSql & " and a.partid='" & CobPart.Text & "' "
        End If

        If CobPallet.Text <> "ALL" Then
            strSql = strSql & " and b.cartonid in (select distinct cartonid " _
                            & " from m_palletcarton_t where palletid='" & CobPallet.Text & "') "
        End If

        If CobCarton.Text <> "ALL" Then
            strSql = strSql & " and b.cartonid='" & CobCarton.Text & "' "
        End If

        Rs = objDB.GetDataReader(strSql)

        DgWHList.Rows.Clear()
        While Rs.Read
            DgWHList.Rows.Add(0, Rs(0), Rs(1), Rs(2), Rs(3), Rs(4), Rs(5), Rs(6))
        End While
        Rs.Close()
        ToolCount.Text = DgWHList.Rows.Count.ToString
        ToolSCount.Text = "0"
        Chk1.Checked = False
    End Sub

    Private Sub FrmWHChange_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub BtChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtChange.Click
        Dim FrmTranWH As New FrmTranWH

        If ToolSCount.Text = "0" Then Exit Sub

        FrmTranWH.ShowDialog()
    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click
        LoadProdList()
    End Sub

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Close()
    End Sub

    Private Sub Chk1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.Click
        Dim i, j, Value As Integer

        If Chk1.Checked Then
            Value = 1
            ToolSCount.Text = DgWHList.Rows.Count.ToString
        Else
            Value = 0
            ToolSCount.Text = "0"
        End If

        If Value = 1 Then
            j = 1
        Else
            j = 0
        End If

        For i = 0 To DgWHList.Rows.Count - 1
            DgWHList.Item(0, i).Value = Value
        Next i
    End Sub

    Private Sub DgWHList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgWHList.CellContentClick
        Dim strValue As Integer

        If e.ColumnIndex = 0 Then
            strValue = DgWHList.Item(e.ColumnIndex, e.RowIndex).Value

            If strValue = 0 Then
                DgWHList.Item(e.ColumnIndex, e.RowIndex).Value = 1
                ToolSCount.Text = CType(CType(ToolSCount.Text, Integer) + 1, String)
            Else
                DgWHList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                ToolSCount.Text = CType(CType(ToolSCount.Text, Integer) - 1, String)
            End If
        End If
    End Sub
End Class