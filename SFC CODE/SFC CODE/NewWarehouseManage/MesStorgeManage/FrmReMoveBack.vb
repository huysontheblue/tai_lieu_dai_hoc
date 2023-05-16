Imports MainFrame
Imports System.Data.SqlClient
Imports System.Text

Public Class FrmReMoveBack
    Dim Pubclass As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmReMoveBack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BtNew_Click(sender, e)
        txtMoveid.Focus()

    End Sub

    '���s���A����
    Private Sub ContorState(ByVal flag As String)
        Select Case flag
            Case "NEW"

                DGMoveList.Enabled = True
                BtNew.Enabled = False
                BtSave.Enabled = True
                BtRefresh.Enabled = True
                BtReturn.Enabled = True
                BtExit.Enabled = True

                ChkSelectAll.Checked = False
                txtMoveid.Text = ""
                txtMoveid.Enabled = True
                txtPartid.Text = ""
                txtPartid.Enabled = True
                DGMoveList.Rows.Clear()
            Case "RETURN"

                DGMoveList.Enabled = False
                BtNew.Enabled = True
                BtSave.Enabled = False
                BtRefresh.Enabled = False
                BtReturn.Enabled = False
                BtExit.Enabled = True

                ChkSelectAll.Checked = False
                txtMoveid.Text = ""
                txtMoveid.Enabled = False
                txtPartid.Text = ""
                txtPartid.Enabled = False
                DGMoveList.Rows.Clear()
        End Select

    End Sub

#Region "���s�����ƥ�"

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ContorState("NEW")
        txtMoveid.Focus()
    End Sub     '�s�W

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim Strsql As New StringBuilder
        Dim Inti As Integer '�Ω�for�`��
        Dim StrBackid As String = "" '�s�x��^�渹

        DGMoveList.EndEdit()
        If DGMoveList.Rows.Count <= 0 Then
            MessageBox.Show("��e����U�L��ơI�Ϊ̱z�ݭn���U[��s]���s", "���ܫH��", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '�P�_��椤�O�_���襤��
        If CheckNull(DGMoveList, 0) = True Then
            MessageBox.Show("��椤�L�襤���A�ФĿ�ݨ����ި���I", "�H������", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            '�ƾڳB�z      
            For Inti = 0 To DGMoveList.Rows.Count - 1
                If DGMoveList.Item(0, Inti).Value = 1 Then
                    StrBackid = Getmaxid()
                    Strsql.Append("insert into M_AfterMove_t(DisposeId,ERPmoveid,Moveid,DisposeType,DisposeQty,UserID,Intime)values " & _
                                  "('" & StrBackid & "','" & DGMoveList.Item(2, Inti).Value.ToString & "','" & DGMoveList.Item(1, Inti).Value.ToString & "'," & _
                                  "'U','" & DGMoveList.Item(4, Inti).Value & "','" & SysCheckData.SysMessageClass.UseId & "',getdate())")
                    Strsql.Append(Environment.NewLine)
                    Strsql.Append("update m_carton_t set whid='" & DGMoveList.Item(7, Inti).Value.ToString & "',areaid='" & DGMoveList.Item(8, Inti).Value.ToString & "'," & _
                                 "floorid='" & DGMoveList.Item(9, Inti).Value.ToString & "',updateuser='" & SysCheckData.SysMessageClass.UseId & "'," & _
                                 "updatetime=getdate() where cartonid in(select a.cartonid from M_RemoveD_t a join M_RemoveM_t b on a.Moveid=b.Moveid " & _
                                 "where b.Moveid='" & DGMoveList.Item(1, Inti).Value.ToString & "') and cartonstatus='I' ")
                    Strsql.Append(Environment.NewLine)
                    Strsql.Append("update M_RemoveD_t set DisposeY='Y' where Moveid='" & DGMoveList.Item(1, Inti).Value.ToString & "'")
                    Pubclass.ExecSql(Strsql.ToString)
                    Strsql.Remove(0, Strsql.Length)
                End If
            Next
            MessageBox.Show("�O�s���\�I", "���ܫH��", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ContorState("RETURN")
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "FrmReMoveBack", "MesWarehouseManage", "BtSave_Click")
        End Try

    End Sub    '�O�s

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click
        Dim Strsql As String
        Dim Dr As SqlDataReader

        DGMoveList.Rows.Clear()
        Strsql = "select distinct a.moveid,a.ERPmoveid,a.partid,a.mvqty,a.controller,substring(convert(varchar,a.movedate,120),1,10)," & _
                 "b.Cwhid,b.Careaid,b.Cfloorid from m_RemoveM_t a left join m_Removed_t b on a.moveid=b.moveid where " & _
                 "a.erpmoveid like'" & Trim(txtMoveid.Text) & "%' and a.partid like'" & Trim(txtPartid.Text) & "%' and " & _
                 "a.Typeid='GC' and a.moveid not in(select Moveid from M_AfterMove_t )"
        Dr = Pubclass.GetDataReader(Strsql)
        If Dr.HasRows Then
            While Dr.Read
                DGMoveList.Rows.Add(0, Dr(0).ToString, Dr(1).ToString, Dr(2).ToString, Dr(3), Dr(4).ToString, Dr(5).ToString, Dr(6).ToString, Dr(7).ToString, Dr(8).ToString)
            End While
        End If
        Dr.Close()

    End Sub '��s

    Private Sub BtReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReturn.Click
        ContorState("RETURN")
    End Sub  '��^

    Private Sub BtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub    '�h�X

#End Region

    Private Sub txtMoveid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoveid.KeyPress, txtPartid.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub DGMoveList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMoveList.CellClick
        If DGMoveList.Rows.Count <= 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        '����
        If e.ColumnIndex = 0 Then
            If DGMoveList.Item(0, e.RowIndex).Value = 0 Then
                DGMoveList.Item(0, e.RowIndex).Value = 1
            Else
                DGMoveList.Item(0, e.RowIndex).Value = 0
            End If
        End If
    End Sub

    Private Sub txtMoveid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMoveid.TextChanged, txtPartid.TextChanged
        DGMoveList.Rows.Clear()
    End Sub

    Private Sub ChkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelectAll.CheckedChanged
        Dim Inti As Integer

        If ChkSelectAll.Checked = True Then
            '���襤
            For Inti = 0 To DGMoveList.Rows.Count - 1
                DGMoveList.Item(0, Inti).Value = 1
            Next
        Else
            '���m��
            For Inti = 0 To DGMoveList.Rows.Count - 1
                DGMoveList.Item(0, Inti).Value = 0
            Next
        End If
    End Sub

    ' �P�_�ƾڬO�_�����S��    
    '
    Private Function CheckNull(ByVal DgName As DataGridView, ByVal Intindex As Integer) As Boolean
        Dim i As Integer

        For i = 0 To DgName.RowCount - 1
            If DgName.Item(Intindex, i).Value Then
                Return False
                Exit Function
            End If
        Next
        Return True

    End Function

    '���̤j�ռ��渹
    Private Function Getmaxid() As String
        Dim strSql As String
        Dim strReturn As String '��^�r�Ŧ�
        Dim StrTemp As String = ""
        Dim Rs As SqlDataReader

        strSql = "select right(max(DisposeId),3) From M_AfterMove_t Where " & _
                 "DisposeId like 'AM' + convert(varchar(6),getdate(),12)+'%'"
        Rs = Pubclass.GetDataReader(strSql)

        If Rs.Read Then
            StrTemp = Rs(0).ToString
            StrTemp = "1" & StrTemp
            StrTemp = Mid(CType(CType(StrTemp, Integer) + 1, String), 2, 3)
        End If
        If StrTemp = "" Then
            StrTemp = "001"
        End If
        Rs.Close()

        strReturn = "AM" & Now.Date.ToString("yyMMdd") & StrTemp

        Return strReturn

    End Function


End Class