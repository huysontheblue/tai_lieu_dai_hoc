
'�u�����@
'Create by: �E�l��
'Create time: 2009/8/20
'Update by: ���T�}
'Update time: 2009/8/27

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

Public Class FrmDClass

#Region "���餽�@�ܶq"

    Public opflag As Int16 = 0  '�P�_�O�s�W�٬O�ק�
    Public frmRstationid As String = "" '�VFrmRPartStation����^��stationid
    Public frmRstationname As String = "" '�VFrmRPartStation����^��stationname
    Public frmStationtype As String = ""  '�VFrmRPartStation����^��StationType

#End Region

#Region "����[��"

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
    '������J
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
        'DtEnd.Value = Now()
        Erightbutton() 'Ū�����s�v��
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvRstation.Enabled = True
    End Sub
    '����������s�v����k
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        If Reader.HasRows Then
            While Reader.Read
                '�q�L����W�ٱo�챱����
                Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            End While
        End If
        Reader.Close()

        'Reader = Conn.GetDataReader("select Factoryid,Shortname from m_Dclass_t where Usey='Y'")
        'If Reader.HasRows Then
        '    With Reader.Read
        '        CobShift.Items.Add(Reader!Factoryid & "-" & Reader!Shortname)
        '    End With
        'End If
        'Reader.Close()
        'CobShift.SelectedIndex = -1

    End Sub
    '�]�m���s���s��TextBox���A
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '��l�d�ߪ��A
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False
                Me.ToolOutDJ.Enabled = True
                Me.ToolScanDJ.Enabled = True
                Me.ToolCancelOutDJ.Enabled = True
                Me.ToolCancelScanDj.Enabled = True
                'GroupBox
                'Me.CobShift.Enabled = False
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = False
                Me.txtStationName.Enabled = False
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = Me.txtStationid
            Case 1, 2 '�s�W,�ק�
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'Me.toolCheck.Enabled = False
                Me.ToolOutDJ.Enabled = False
                Me.ToolScanDJ.Enabled = False
                Me.ToolCancelOutDJ.Enabled = False
                Me.ToolCancelScanDj.Enabled = False
                'GroupBox
                Me.txtStationdest.Enabled = True
                Me.txtStationName.Enabled = True
                'Me.CobShift.Enabled = IIf(opflag = 1, True, False)
                'Me.txtStationName.Enabled = False
                Me.dgvRstation.Enabled = False
                'Me.ActiveControl = IIf(opflag = 1, Me.CobShift, Me.txtStationName)
            Case 3 '�qFrmRPartStation���餤�}�Ҧ�����ɪ����A
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                'Me.CobShift.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationName.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ToolOutDJ.Enabled = False
                Me.ToolScanDJ.Enabled = False
                Me.ToolCancelOutDJ.Enabled = False
                Me.ToolCancelScanDj.Enabled = False
                Me.ActiveControl = Me.txtStationName
        End Select
    End Sub

#End Region

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
        SqlStr = "select Classid,Classname,BeginTime,EndTime,Description,usey from m_Dclass_t where usey='Y' "
        Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString)
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
        tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtStationid.Text.Trim = "" Then
            LblMsg.Text = "��������ϲ���Ϊ��..."
            Me.ActiveControl = Me.txtStationid
            Return False
        End If
        If Me.txtStationName.Text.Trim = "" Then
            LblMsg.Text = "������Ʋ���Ϊ��..."
            Me.ActiveControl = Me.txtStationName
            Return False
        End If
        'If Me.CobShift.Text.Trim = "" Then
        '    LblMsg.Text = "����������˾����Ϊ��..."
        '    Me.ActiveControl = Me.CobShift
        '    Return False
        'End If
        Return True
    End Function

#End Region

#Region "�������s�ƥ�"
    '�s�W
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtStationid.Text = ""
        txtStationdest.Text = ""
        txtStationName.Text = ""
        'CobShift.SelectedIndex = -1
        opflag = 1
        ToolbtnState(1)
        txtStationid.Enabled = True

    End Sub
    '�ק�
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        '�P�_�O���O�_�i�H�Q�ק�
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("�Ӥu���s���w�g�@�o�A�����\�i��ק�I", "�t�δ���", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        '������

        txtStationid.Text = dgvRstation.CurrentRow.Cells("ColLineid").Value
        txtStationName.Text = dgvRstation.CurrentRow.Cells("ColLineName").Value
        DtStar.Value = dgvRstation.CurrentRow.Cells("ColStar").Value
        DtEnd.Value = dgvRstation.CurrentRow.Cells("ColEnd").Value
        'CobShift.Text = dgvRstation.CurrentRow.Cells("ColLinegx").Value
        txtStationdest.Text = dgvRstation.CurrentRow.Cells("Colmark").Value
        '���ܵ��骬�A
        opflag = 2
        ToolbtnState(2)

    End Sub
    '�@�o
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '�P�_�O���O�_�i�H�Q�@�o
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("�ñʼ�¼������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'If MessageBox.Show("�T�w�n�@�o�u��: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "] ��?", "�t�δ���", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql("update m_Dclass_t set usey='N' where Classid = '" & dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
            'MessageBox.Show("���\�@�o�u��: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "�t�δ���", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub
    '�O�s
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then  '�s�W�Z�O�s���洡�J�ާ@

            SqlStr.Append(ControlChars.CrLf & "insert into m_Dclass_t(Classid,Classname,ExdDateY,BeginTime,EndTime,Description,usey) " _
                     & " values('" & txtStationid.Text & "',N'" & txtStationName.Text.Trim & "','Y','" & Me.DtStar.Value.ToShortTimeString & "'," _
                     & " N'" & DtEnd.Value.ToShortTimeString & "','" & txtStationdest.Text & "','Y')")
        ElseIf opflag = 2 Then     '�ק�Z�O�s�����s�ާ@
            SqlStr.Append("update m_Dclass_t set Classname =N'" & txtStationName.Text.Trim & "',Description =N'" & txtStationdest.Text.Trim & "',BeginTime='" & DtStar.Value.ToShortTimeString & "',EndTime='" & DtEnd.Value.ToShortTimeString & "' where Classid = '" & txtStationid.Text.Trim & "'")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" ")
            'LoadDataToDatagridview(" where a.usey='Y'")
            'MessageBox.Show("�O�s���\�I", "�t�δ���", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'CobShift.SelectedIndex = -1
            txtStationName.Text = ""
            txtStationName.Text = ""
            txtStationdest.Text = ""
            opflag = 0
            ToolbtnState(0)
            Me.dgvRstation.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '��^
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click

        'CobShift.SelectedIndex = -1
        txtStationid.Text = ""
        txtStationName.Text = ""
        txtStationdest.Text = ""
        opflag = 0
        ToolbtnState(0)

    End Sub
    '�d��
    'Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click

    '    Dim flag As Boolean = False
    '    Dim Sql As String = "where 1=1"

    '    If Me.CobShift.Text.Trim <> "" Then
    '        'If flag = False Then
    '        '    Sql = " where Stationtype='" & Me.cboType.Text.Trim.Split("-")(0) & "' "
    '        'Else
    '        Sql = Sql & " and Stationtype='" & Me.CobShift.Text.Trim.Split("-")(0) & "' "
    '        'flag = True
    '        'End If
    '    End If
    '    If Me.txtStationName.Text.Trim <> "" Then
    '        'If flag = False Then
    '        '    Sql = " where Stationid like '" & Me.txtStationid.Text.Trim & "%' "
    '        'Else
    '        Sql = Sql & " and Stationid like '" & Me.txtStationName.Text.Trim & "%' "
    '        'flag = True
    '        'End If
    '    End If
    '    If Me.txtStationName.Text.Trim <> "" Then
    '        'If flag = False Then
    '        '    Sql = " where Stationname like '" & Me.txtStationName.Text.Trim & "%' "
    '        'Else
    '        Sql = Sql & " and Stationname like '" & Me.txtStationName.Text.Trim & "%' "
    '        '    flag = True
    '        'End If
    '    End If
    '    LoadDataToDatagridview(Sql)

    'End Sub
    '���
    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.CurrentRow.Cells("ColUsey").Value <> "Y" Then
        '    MessageBox.Show("�ñ�����������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'frmRstationid = Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        'frmRstationname = Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        'frmStationtype = Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        'Me.Close()
    End Sub
    '�h�X
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

    Private Sub ToolScanDJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolScanDJ.Click

        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Try
        '    Conn.ExecSql("update m_Dline_t set usey='D',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Lineid = '" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        '    LblMsg.Text = "�ñ������Ѿ�����ɨ�足��,���߲�������ɨ��.."
        '    LoadDataToDatagridview(" where Lineid='" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        'End Try

    End Sub

    Private Sub ToolCancelScanDj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancelScanDj.Click

        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Try
        '    Conn.ExecSql("update m_Dline_t set usey='Y',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Lineid = '" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        '    LblMsg.Text = "�ñ������Ѿ����ɨ�足��,���߻ָ�ɨ��.."
        '    LoadDataToDatagridview(" where Lineid='" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        'End Try


    End Sub

    Private Sub ToolCancelOutDJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancelOutDJ.Click

        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Try
        '    Conn.ExecSql("update m_Dline_t set State='N',StateBegin='',StateEnd='',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Lineid = '" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        '    LblMsg.Text = "�ñ������Ѿ��������ɨ�足��,�ֿ�ָ�����ɨ��.."
        '    LoadDataToDatagridview(" where Lineid='" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        'End Try

    End Sub

    Private Sub ToolOutDJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOutDJ.Click

        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        'Try
        '    Conn.ExecSql("update m_Dline_t set State='Y',StateBegin='" & Me.DtStar.Value & "',StateEnd='" & Me.DtEnd.Value & "',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Lineid = '" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        '    LblMsg.Text = "�ñ������Ѿ����г���ɨ�足��,�ֿⲻ�ܽ��г���ɨ��.."
        '    LoadDataToDatagridview(" where Lineid='" & Me.dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        'End Try


    End Sub

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview(" ")
    End Sub


End Class