
'����ά��
'Create by: �»���
'Create time: 2016/10/21
'Update by: 
'Update time: 

#Region "Imports�ޥ�"

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

Public Class FrmProduceLine


    Public opflag As Int16 = 0  '�P�_�O�s�W�٬O�ק�
    Dim lastindex As Int16 = -1

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                '����V�� 
                SendKeys.Send("{+Tab}")  '��Shift + Tab �զX�� 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 '�W��V�� 
            Case 39 '�k��V�� 
                'SendKeys.Send("{+Tab}")
            Case 40  '�U��V�� 
                'SendKeys.Send("{+Tab}")
            Case 27 'Esc�� 
                Me.Close()
        End Select
    End Sub
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Erightbutton()
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvRstation.Enabled = True
    End Sub

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        If (Reader.HasRows) Then
            While Reader.Read
                '�q�L����W�ٱo�챱����
                Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            End While
        End If
        Reader.Close()
        If (Conn.PubConnection.State = ConnectionState.Open) Then
            Conn.PubConnection.Close()
        End If
    End Sub
    '�]�m���s���s��TextBox���A
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '��
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.txtPartSeriesTypeCode.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.ActiveControl = Me.txtPartSeriesTypeCode
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtPartSeriesTypeCode.Enabled = False
                Me.txtPartSeriesTypeName.Enabled = True

            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.txtPartSeriesTypeName.Enabled = True
                Me.ActiveControl = Me.txtPartSeriesTypeName
        End Select
    End Sub



    '#Region "���ƾڱ���Cbo�BDg�[���ƾ�"
    '    '�˸�CboType�u�����O
    '    Private Sub LoadDataToCombox()

    '        Dim SqlStr As String = "select SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' order by Orderid"
    '        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    '        Dim Dreader As SqlDataReader = Conn.GetDataReader(SqlStr)
    '        cboType.Items.Clear()
    '        cboType.Items.Add("")
    '        Do While Dreader.Read()
    '            cboType.Items.Add(Dreader.Item(0) & "-" & Dreader.Item(1))
    '        Loop

    '        Dreader.Close()
    '        Conn = Nothing

    '    End Sub
    '�˸�Dg���
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "SELECT *, (" & _
                 "           SELECT  LEFT(LineIdList,LEN(LineIdList)-1) as  LineIdList  FROM (" & _
                 "               SELECT SericesCode, ( SELECT LineId + ',' FROM m_LineSericesPriority_t WHERE SericesCode = A.SericesCode FOR XML PATH('')) AS LineIdList " & _
                 "               FROM m_LineSericesPriority_t A WHERE SericesCode = m_PartSeriesType_t.PartSeriesTypeCode GROUP BY SericesCode) AS B " & _
                 "           ) SericesLineText " & _
                 "   FROM m_PartSeriesType_t "
        Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item("PartSeriesTypeCode").ToString, Dreader.Item("PartSeriesTypeName").ToString, Dreader.Item("SericesLineText").ToString, Dreader.Item("Usey").ToString, _
            Dreader.Item("CreateUserId").ToString, Dreader.Item("CreateTime").ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        Conn = Nothing
    End Sub



#Region "CBO/DG���ƾڱ�������ƥ�"
    '�����[��datagridview�椸�榳�J�I
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRstation.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '������ƥ�
    Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRstation.CellDoubleClick
        'tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        
        If Me.txtPartSeriesTypeName.Text.Trim = "" Then
            LblMsg.Text = "������Ʋ���Ϊ��"
            Me.ActiveControl = Me.txtPartSeriesTypeName
            Return False
        End If
      
        Return True
    End Function

#End Region

#Region "�������s�ƥ�"
    '�s�W
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtPartSeriesTypeCode.Text = ""
        txtPartSeriesTypeCode.Enabled = False
        txtPartSeriesTypeName.Text = ""
        chkUsey.Checked = True
        opflag = 1
        ToolbtnState(1)
        LblMsg.Text = "����������"
        Me.ActiveControl = Me.txtPartSeriesTypeName


    End Sub
    '�ק�
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click


        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
      

        txtPartSeriesTypeCode.Text = dgvRstation.CurrentRow.Cells("PartSeriesTypeCode").Value
        txtPartSeriesTypeName.Text = dgvRstation.CurrentRow.Cells("PartSeriesTypeName").Value
        Dim usey As String = dgvRstation.CurrentRow.Cells("Usey").Value
        If usey = "Y" Then
            chkUsey.Checked = True
        Else
            chkUsey.Checked = False
        End If

        '���ܵ��骬�A
        opflag = 2
        ToolbtnState(2)
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        dgvRstation.Rows(dgvRstation.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = dgvRstation.CurrentRow.Index
        LblMsg.Text = "���޸�����"
    End Sub
    '�@�o
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            Conn.ExecSql("update m_PartSeriesType_t set usey='N',CreateUserId='" & SysMessageClass.UseId.ToLower.Trim & "',CreateTime=getdate() where PartSeriesTypeCode = '" & dgvRstation.CurrentRow.Cells("PartSeriesTypeCode").Value & "'")
            MessageBox.Show("���ϲ����ɹ�")
            LoadDataToDatagridview(" where PartSeriesTypeCode='" & dgvRstation.CurrentRow.Cells("PartSeriesTypeCode").Value & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmProduceLine", "tsbAbandon_Click", "sys")
        End Try

    End Sub
    '�O�s
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder

        If Checkdata() = False Then Exit Sub


        Dim usey As String = "N"
        If chkUsey.Checked Then
            usey = "Y"
        End If
        Dim msg As String = ""
        If opflag = 1 Then  '�s�W�Z�O�s���洡�J�ާ@
            SqlStr.Append("declare @PartSeriesTypeCode as varchar(50)")
            SqlStr.Append(ControlChars.CrLf & "select @PartSeriesTypeCode=[dbo].f_IncIdent(isnull(max(PartSeriesTypeCode),'S1000'),0) from m_PartSeriesType_t")
            SqlStr.Append(ControlChars.CrLf & "insert into m_PartSeriesType_t(PartSeriesTypeCode, PartSeriesTypeName, Usey, CreateUserId,CreateTime) " _
                     & " values(@PartSeriesTypeCode,N'" & txtPartSeriesTypeName.Text.Trim & "','" & usey & "'," _
                     & " '" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
            msg = "����"
        ElseIf opflag = 2 Then     '�ק�Z�O�s�����s�ާ@
            SqlStr.Append("update m_PartSeriesType_t set PartSeriesTypeName =N'" & txtPartSeriesTypeName.Text.Trim & "',Usey =N'" & usey & "' where PartSeriesTypeCode = '" & txtPartSeriesTypeCode.Text.Trim & "'")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")
            msg = "�޸�"
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LblMsg.Text = msg + "�����ɹ�..."
            MessageBox.Show(msg + "�����ɹ�")
            If txtPartSeriesTypeCode.Text.Trim <> "" Then
                LoadDataToDatagridview("  where PartSeriesTypeCode='" & txtPartSeriesTypeCode.Text.Trim & "'")
            Else
                LoadDataToDatagridview("")
            End If
            txtPartSeriesTypeCode.Text = ""
            txtPartSeriesTypeName.Text = ""
            opflag = 0
            ToolbtnState(0)
            lastindex = -1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmProduceLine", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '��^
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click


        txtPartSeriesTypeCode.Text = ""
        txtPartSeriesTypeName.Text = ""
        chkUsey.Checked = False

        opflag = 0
        ToolbtnState(0)
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub
   
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

  
    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim str As String = " where (1=1) "
        If txtPartSeriesTypeCode.Text <> "" Then
            str = str + " and PartSeriesTypeCode like '%" & txtPartSeriesTypeCode.Text.Trim & "%'"
        End If
        If txtPartSeriesTypeName.Text <> "" Then
            str = str + " and PartSeriesTypeName like '%" & txtPartSeriesTypeName.Text.Trim & "%'"
        End If

        LoadDataToDatagridview(str)
        lastindex = -1
        LblMsg.Text = "���ݼ��سɹ�"
    End Sub

    Private Sub toolBtnLineSericesPriority_Click(sender As Object, e As EventArgs) Handles toolBtnLineSericesPriority.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            isAdd = True
            isDelete = True

            Using frm As New FrmLineSeriesPriority(dgvRstation.Item(0, dgvRstation.CurrentRow.Index).Value.ToString(), dgvRstation.Item(1, dgvRstation.CurrentRow.Index).Value.ToString(), _
                                                           isAdd, isDelete)
                frm.ShowDialog()
            End Using
            LoadDataToDatagridview(" ")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class