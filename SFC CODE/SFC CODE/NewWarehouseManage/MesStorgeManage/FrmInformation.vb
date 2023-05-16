Imports System.Data.SqlClient
Imports MainFrame

'按先進先出控制產品出貨
Public Class FrmInformation
    Public StrPart As String = ""
    Public StrInvoice As String = ""
    Public IntCount As Integer = 0
    Dim Pubclass As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmInformation_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim StrSql As String
        Dim Rs As SqlDataReader
        StrSql = "select c.moid, a.partid, sum(b.cartonqty) qty,  c.floorid, c.whid, c.areaid," _
               & " convert(varchar(10),min(b.intime),101) proddt from m_mainmo_t a,  m_carton_t b," _
               & " m_whinm_t c , m_whind_t d where  a.moid=b.moid and a.partid='" & StrPart & "'" _
               & " and b.moid=c.moid and b.cartonid=d.cartonid  and c.inwhid=d.inwhid  and b.cartonstatus='I' and a.factory in (select factory from m_ShipM_t where invoice='" & StrInvoice & "')" _
               & " group by  c.moid, a.partid, c.floorid, c.whid, c.areaid "

        Rs = Pubclass.GetDataReader(StrSql)
        If Rs.HasRows Then
            While Rs.Read()
                Me.labTatalQty.Text = CType(Me.labTatalQty.Text, Integer) + CType(Rs(2).ToString, Integer)
                Me.LabCartonQty.Text = CType(Me.LabCartonQty.Text, Integer) + 1
                Me.DgvItem.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, Rs(4).ToString, Rs(5).ToString, Rs(6).ToString)
            End While
            Dim IntTotalQty As Integer = 0
            Dim PintTotalQty As Integer = 0
            For RowCount As Integer = 0 To Me.DgvItem.RowCount - 1
                PintTotalQty = IntTotalQty
                IntTotalQty += Me.DgvItem.Rows(RowCount).Cells(2).Value
                If IntTotalQty >= IntCount And PintTotalQty > IntCount Then
                    Me.DgvItem.Rows(RowCount).DefaultCellStyle.BackColor = Color.AliceBlue
                Else
                    Me.DgvItem.Rows(RowCount).DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        Else
            Rs.Close()
            Me.Close()
        End If
        Rs.Close()
        If CType(Me.labTatalQty.Text, Integer) < IntCount Then
            Me.Close()
        End If
    End Sub


    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem.Click
        For ColNum As Integer = 0 To Me.DgvItem.ColumnCount - 1
            Me.DgvItem.Columns(ColNum).Visible = True
        Next
    End Sub

    Private Sub FrmInformation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(113) Or e.KeyChar = Chr(81) Or e.KeyChar = Chr(27) Then
            Me.Close()
        End If
    End Sub
End Class