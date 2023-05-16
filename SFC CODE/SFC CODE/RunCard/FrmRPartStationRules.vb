Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports LXWarehouseManage
Imports System.Windows.Forms

Public Class FrmRPartStationRules

    Dim DtContrast As DataTable
    Dim bmFoxStudio As BindingManagerBase
    Dim SqlStr As New StringBuilder
    Dim LostCheck As Boolean
    Dim SqlSearch As String
    Dim Searchy As Boolean
    Dim StrOldPart As String
    Dim StrOldPartp As String
    Public _Ppartid As String
    Public _Tpartid As String
    Public _Revid As String
    Public _StaOrderid As String
    Public _Stationid As String
    Public _ScanOrderid As String
    Public conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub dgScanShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgList.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub


#Region "�u����I���ƥ�"

    Private Sub NewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFile.Click
        SysMessageClass.EditFlag = True
        'Me.UpLmt.Value = 365
        'Me.UpYttishi.Value = 7
        AddRecord()
        txtRuleName.Focus()
        'TxtTavcPart.Enabled = True
        'Me.TxtTavcPart.Focus()
    End Sub

    Private Sub EditFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditFile.Click
        If DgList.RowCount < 1 Then Exit Sub
        If Me.DgList.CurrentRow.Index = -1 Then Exit Sub
        StrOldPart = Me.DgList.CurrentRow.Cells(0).Value
        StrOldPartp = Me.DgList.CurrentRow.Cells(1).Value.ToString
        SysMessageClass.EditFlag = False
        EditRecord()
        SetValueToControl()
        'Me.TxtTavcPart.Focus()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        SaveData()

    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        DeleteRecord()
    End Sub

    Private Sub UnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnDo.Click
        LostCheck = True
        CancelChg()
        LostCheck = False
        Searchy = False
    End Sub

    Private Sub Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim Frm As New FrmPartCope
        'Frm.ShowDialog()
        'Dim ExportClass As New MainFrame.SysDataHandle.SysDataBaseClass
        'ExportClass.ExporToExcel(SqlSearch, "�����ϼ���������")
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        NewFile.Enabled = False
        EditFile.Enabled = False
        Delete.Enabled = False
        Save.Enabled = False
        UnDo.Enabled = True
        'Export.Enabled = True
        Search.Enabled = False
        FileRefresh.Enabled = True
        ExitFrom.Enabled = True
        ClearControl()
        'TxtTavcPart.Enabled = True
        'TxtPavcPart.Enabled = True
        'CobCust.Enabled = True
        'TxtCustPartID.Enabled = True
        Searchy = True
        'Me.TxtTavcPart.Focus()

    End Sub

    Private Sub FileRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileRefresh.Click
        If Searchy = False Then
            SearchRecord("")
            SetValueToControl()
            Exit Sub
        End If

        Dim SqlStr As String = ""
        'If Me.TxtTavcPart.Text <> "" Then
        '    SqlStr = " and a.tavcpart like '%" & Trim(TxtTavcPart.Text) & "%'"
        'End If
        'If Me.TxtPavcPart.Text <> "" Then
        '    SqlStr = " and a.pavcpart like '" & Trim(TxtPavcPart.Text) & "%'"
        'End If
        'If Me.CobCust.Text <> "" Then
        '    SqlStr = SqlStr + " and a.cusid = '" & Mid(Trim(Me.CobCust.Text), 1, InStr(Trim(Me.CobCust.Text), "(") - 1) & "'"
        'End If
        'If Me.TxtCustPartID.Text <> "" Then
        '    SqlStr = SqlStr + " and a.CustPart like '" & Trim(TxtCustPartID.Text) & "%'"
        'End If
        'If SqlStr.Length = 0 Then
        '    MessageBox.Show("�п�J�d�߱���I", "���ܫH��", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        SearchRecord(SqlStr)
        EditFile.Enabled = True
        Delete.Enabled = True
    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub
#End Region

#Region "������"
    Private Sub SetValueToControl()

        If DgList.RowCount < 1 Then Exit Sub
        If Me.DgList.CurrentRow.Index < 0 Then Exit Sub
        'select id,RuleName,RuleCheckSQL,RuleKeyField,RuleType,Ruleusey,RuleOrderby 
        txtID.Text = Me.DgList.Item(0, DgList.CurrentRow.Index).Value.ToString
        txtRuleName.Text = Me.DgList.Item(1, DgList.CurrentRow.Index).Value.ToString
        txtRuleCheckSQL.Text = Me.DgList.Item(2, DgList.CurrentRow.Index).Value.ToString
        txtRuleKeyField.Text = Me.DgList.Item(3, DgList.CurrentRow.Index).Value.ToString
        txtRuleType.SelectedValue = Me.DgList.Item(4, DgList.CurrentRow.Index).Value.ToString
        chkRuleusey.Checked = IIf(Me.DgList.Item(5, DgList.CurrentRow.Index).Value.ToString = "Y", True, False)
        txtRuleOrderby.Text = Me.DgList.Item(6, DgList.CurrentRow.Index).Value.ToString
        Dim cot As Integer = chkParameters.Items.Count
        If txtRuleKeyField.Text.Trim.Split(",").Length > 0 Then
            SetControlValue(chkParameters, txtRuleKeyField.Text.Trim)
        End If
    End Sub
#End Region

#Region "�u�����ܤ�k"

    Private Sub SetControlStutas(ByVal FlagStr As String)

        Select Case UCase(FlagStr)
            Case "ADD"
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = True
                UnDo.Enabled = True
                'Export.Enabled = False
                Search.Enabled = False
                FileRefresh.Enabled = False
                ExitFrom.Enabled = True
                'Me.UpLmt.Enabled = True
                'Me.UpYttishi.Enabled = True
                'Me.CobPartCode.Enabled = True
                'Me.CobTypeDesc.Enabled = True
            Case "EDIT"
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = True
                UnDo.Enabled = True
                'Export.Enabled = False
                Search.Enabled = False
                FileRefresh.Enabled = False
                ExitFrom.Enabled = True
                'Me.UpLmt.Enabled = True
                'Me.UpYttishi.Enabled = True
                'Me.CobPartCode.Enabled = True
                'Me.CobTypeDesc.Enabled = True
            Case "UNDO"
                NewFile.Enabled = True
                EditFile.Enabled = True
                Delete.Enabled = True
                Save.Enabled = False
                UnDo.Enabled = False
                'Export.Enabled = True
                Search.Enabled = True
                FileRefresh.Enabled = True
                ExitFrom.Enabled = True
                'Me.UpLmt.Enabled = False
                'Me.UpYttishi.Enabled = False
                'Me.CobPartCode.Enabled = False
                'Me.CobTypeDesc.Enabled = False
        End Select

    End Sub
#End Region

#Region "�M�ű��󤺮e��k"
    Private Sub ClearControl()
        'Dim PubClear As New MainFrame.SysCheckData.TextHandle
        'ChBusey.Checked = True
        'PubClear.ClearControl(Me.SplitContainer1.Panel1)

        Dim ClearCon As Control

        For Each ClearCon In Me.Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Text = ""
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Text = ""
            End If
        Next
        'Me.CobCust.SelectedIndex = -1
    End Sub
#End Region

#Region "����i�Χ_��k"

    Private Sub ChgRecord(ByVal Flag As Integer)

        Dim EmsCon As Control
        Select Case Flag

            Case 0
                Me.DgList.Enabled = True
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is CheckedListBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is NumericUpDown Then
                        EmsCon.Enabled = True
                    End If

                Next
                DgList.Enabled = False
                'Me.TxtTavcPart.Enabled = False
            Case 1
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is CheckedListBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is NumericUpDown Then
                        EmsCon.Enabled = False
                    End If

                Next
                DgList.Enabled = True
        End Select
    End Sub

#End Region

#Region "�����B�z��k"

    Private Sub CancelChg()

        ChgRecord(1)
        SetControlStutas("UNDO")
        SetValueToControl()

    End Sub
#End Region

#Region "�s�W�ƾ�"

    Private Sub AddRecord()

        'Me.CobCust.SelectedIndex = -1
        ChgRecord(0)
        SetControlStutas("ADD")
        ClearControl()

    End Sub

#End Region

#Region "�ק�ƾ�"

    Private Sub EditRecord()

        ChgRecord(0)
        SetControlStutas("EDIT")

    End Sub

#End Region

#Region "�R���O��"

    Private Sub DeleteRecord()

        If DgList.RowCount < 1 Then Exit Sub
        If Me.DgList.CurrentRow.Index = -1 Then Exit Sub
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlString As String
        If MessageBox.Show("��ȷ��Ҫɾ���ü�¼��...", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                SqlString = "delete from m_RunCardPartStationRules_t where id='" & txtID.Text.Trim & "' "
                Sdbc.ExecSql(SqlString)
                SearchRecord("")
            Catch Eex As Exception
                MessageBox.Show(Eex.Message & vbNewLine & "ɾ��ʱ����������!", "��ʾ��Ϣ", MessageBoxButtons.OK)
            Finally
                Sdbc.PubConnection.Close()
                'Sdbc = Nothing
            End Try
        End If
        'Sdbc = Nothing
        SetValueToControl()
    End Sub
#End Region

#Region "��R�U�Ե����"
    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
        Loop
        ScanReader.Close()
        ScanClass.PubConnection.Close()
        CobName.SelectedIndex = -1
    End Sub

    Private Sub FillCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        CobName.Items.Add("ALL")
        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader.GetString(0).ToString)
        Loop
        ScanReader.Close()
        ScanClass.PubConnection.Close()
        CobName.SelectedIndex = 0
    End Sub
    Private Sub FillListCombox(ByVal ComControl As ComboBox, ByVal SqlStr As String, ByVal ValleField As String, ByVal TextField As String)
        Dim ScanClass As New SysDataBaseClass
        Dim dt As DataTable = ScanClass.GetDataTable(SqlStr)
        Dim dr As DataRow = dt.NewRow
        dr(ValleField) = ""
        dr(TextField) = ""
        dt.Rows.InsertAt(dr, 0)
        ComControl.DataSource = dt.DefaultView
        ComControl.ValueMember = ValleField
        ComControl.DisplayMember = TextField

    End Sub

#End Region

#Region "�d��AVC�Ƹ�"

    Private Sub SearchRecord(ByVal Sqlstring As String)

        Dim ChColsText As String = ""
        Dim DtContrast As DataTable
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        'DtContrast = Sdbc.GetDataTable("SELECT top 100 a.tavcpart,a.pavcpart,a.cusid + '(' + b.cusname + ')',a.custpart,case when a.Usey='Y' then 'Yes' else 'No' end,a.userid,convert(varchar(16),a.intime,120),Lmty,warndate,typedest,partcode,Supplierid,isupload,isasseble,islotscan,IsAlter FROM m_PartContrast_t a left join m_Customer_t b on a.cusid=b.cusid where 1=1  " & Sqlstring)

        'SqlSearch = "SELECT a.tavcpart �ϼ����,a.pavcpart ���ϼ����,a.cusid + '(' + b.cusname + ')' �ͻ�����,a.custpart �ͻ��Ϻ�,case when a.Usey='Y' then 'Yes' else 'No' end ״̬,a.userid ά����Ա,convert(varchar(16),a.intime,120)  ά����Ա,lmty ������,warndate Ԥ������,typedest ������,partcode �ϼ�����,Supplierid ��Ӧ�̴���,isnull(isupload,'') ��Panda��Ʒ,isnull(isasseble,'') ��Panda���,isnull(islotscan,'') ����ɨ������,isnull(IsAlter,'') ����ת��Ԥ�� FROM m_PartContrast_t a left join m_Customer_t b on a.cusid=b.cusid where 1=1 " & Sqlstring
        SqlSearch = String.Format("select id,RuleName,RuleCheckSQL,RuleKeyField,RuleType,Ruleusey,RuleOrderby from m_RunCardPartStationRules_t where 1=1  order by RuleOrderby ", _Ppartid, _Tpartid, _Revid, _StaOrderid, _Stationid, _ScanOrderid) & Sqlstring
        DtContrast = Sdbc.GetDataTable(SqlSearch)
        DgList.DataSource = DtContrast
        Dim i As Integer
        'For i = 0 To DtContrast.Rows.Count - 1

        'Next

        bmFoxStudio = Me.BindingContext(DtContrast)
        'Sdbc = Nothing
        'If LCase(SysMessageClass.Language) = "english" Then
        '    'ChColsText = "User ID|User Name|DepartmentID|Departmentname|Position|Team|Group ID|Factory ID|AutoID|Discription|Availability"
        'Else
        ChColsText = "ID|�������|SQL����|���SQL|���|�Ƿ�����|����"
        'End If

        Dim colNames As String() = ChColsText.Split("|")
        'Dim i%
        For i = 0 To DgList.Columns.Count - 1
            DgList.Columns(i).HeaderText = colNames(i)
            DgList.Columns(i).Name = colNames(i)
        Next
        DgList.Columns(0).Width = 20
        ToolStripStatusLabel1.Text = DtContrast.Rows.Count & "��"
        Sdbc.PubConnection.Close()
    End Sub

#End Region

#Region "�ƾګO�s"
    Private Sub SaveData()

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Dim SqlStr As String
        'Dim StrCust As String
        'Dim StryType As String
        'Dim StrCode As String
        'Dim StrSupplier As String
        'If Me.DgPartContrast.Rows.Count < 1 Then Exit Sub  TxtTavcPart
        Try
            CheckRecord()
            Dim IsRuleusey As String = IIf(chkRuleusey.Checked, "Y", "N")

            If SysMessageClass.EditFlag = True Then
                Dim sql As String = String.Format("select RuleName from m_RunCardPartStationRules_t where RuleName='{0}'  ", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleType.SelectedValue.ToString))
                DrCheck = Sdbc.GetDataReader(sql)
                ''DrCheck = Sdbc.GetDataReader("select 1 from m_PartContrast_t where TAvcPart='" & Trim(Me.TxtTavcPart.Text) & "' ")
                If DrCheck.HasRows Then
                    MessageBox.Show("ϵͳ���Ѵ��ڸü�¼", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DrCheck.Close()
                    Sdbc.PubConnection.Close()
                    Exit Sub
                End If
                DrCheck.Close()

                SqlStr = String.Format("insert into m_RunCardPartStationRules_t(RuleName,RuleCheckSQL,RuleKeyField,RuleType,Ruleusey,RuleOrderby) " _
                & " values('{0}','{1}','{2}','{3}','{4}','{5}') ", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleCheckSQL.Text).Replace("'", "''"), Trim(Me.txtRuleKeyField.Text), Trim(Me.txtRuleType.SelectedValue.ToString), IsRuleusey, Trim(Me.txtRuleOrderby.Text))
            Else
                SqlStr = String.Format(" update m_RunCardPartStationRules_t set RuleName='{0}',RuleCheckSQL='{1}',RuleKeyField='{2}',Ruleusey='{3}',RuleOrderby='{4}',RuleType='{6}' where id='{5}'", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleCheckSQL.Text).Replace("'", "''"), Trim(Me.txtRuleKeyField.Text), IsRuleusey, Trim(Me.txtRuleOrderby.Text), txtID.Text.ToString, Trim(Me.txtRuleType.SelectedValue.ToString))
            End If

            Sdbc.ExecSql(SqlStr)

            ChgRecord(1)
            SetControlStutas("UNDO")
            SearchRecord("")
            '' SetValueToControl()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Sdbc.PubConnection.Close()
            'Sdbc = Nothing
        End Try
    End Sub
#End Region

#Region "�ƾڮ���"
    Private Sub CheckRecord()

        'Dim DrNameShow As SqlDataReader
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim TavcPartErr As New Exception("������Ʋ���Ϊ��!")
        TavcPartErr.Source = "CheckRecord"
        If Me.txtRuleName.Text = "" Then
            Throw TavcPartErr
            txtRuleName.Focus()
        End If
        If txtRuleKeyField.Text <> "" Then
            Dim CheckSQLEmpty As New Exception("���SQL��䲻��Ϊ��")
            CheckSQLEmpty.Source = "CheckRecord"
            If Me.txtRuleCheckSQL.Text = "" Then
                txtRuleCheckSQL.Focus()
                Throw CheckSQLEmpty
            Else
                Dim CheckSQLErr As New Exception("���SQL���ʧ��")
                CheckSQLErr.Source = "CheckRecord"
                Dim i As Integer = 0
                Dim m As Integer = 0
                Dim keyfield As String() = txtRuleKeyField.Text.ToUpper.Split(",")
                If keyfield.Length > 0 Then

                    Dim sql As String = Me.txtRuleCheckSQL.Text.ToUpper

                    Dim notin As Boolean = False
                    For m = 0 To chkParameters.Items.Count - 1
                        If keyfield(i).ToLower = chkParameters.Items(m).ToString().Split("--")(0).ToLower Then
                            notin = True
                        End If
                    Next
                    If notin = False Then
                        MessageBox.Show("����" + keyfield(i).ToLower + "���Ϸ�")
                        Throw CheckSQLErr
                    End If

                    For i = 0 To keyfield.Length - 1
                        sql = sql.Replace(keyfield(i), "''")
                    Next
                    sql = "select top 1 1 from (" + sql + ") AA"
                    Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
                    Try
                        If Sdbc.CheckDataExistsBySql(sql) Then
                            'MessageBox.Show("SQL�﷨����")
                        End If
                    Catch ex As Exception
                        txtRuleCheckSQL.Focus()
                        txtRuleCheckSQL.SelectAll()
                        Throw CheckSQLErr
                    End Try
                End If

            End If
        End If


        'Dim CustPartErr As New Exception("�ͻ��ϺŲ���Ϊ��")
        'CustPartErr.Source = "CheckRecord"
        'If Me.TxtCustPartID.Text = "" Then
        '    Throw CustPartErr
        'End If



    End Sub
#End Region

    Private Sub DgPartContrast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgList.Click

        If DgList.RowCount < 1 Then Exit Sub
        If Searchy = True Then Exit Sub
        SetValueToControl()

    End Sub




#Region "�^���ഫ"
    Private Sub FrmPartContrast_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
        End If
    End Sub
#End Region

    Private Sub FrmPartContrast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       
        FillListCombox(txtRuleType, "select SortID,SortName from m_Sortset_t where sorttype=N'RuleType' order by orderid", "SortID", "SortName")
        SearchRecord("")
        SetValueToControl()
        SetControlStutas("UNDO")

    End Sub
   
    Private Sub txtRuleKeyField_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRuleKeyField.MouseEnter
        Dim ttip As ToolTip = New ToolTip
        ttip.Show("��������λ��Ϊ�յ�ʱ�򣬼��SQLҲ����Ϊ��", txtRuleKeyField, 1000)
    End Sub

  

    Private Sub chkParameters_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkParameters.SelectedValueChanged
        Dim count As Integer = chkParameters.CheckedItems.Count
        Dim str As String = ""
        Dim i As Integer = 0
        For i = 0 To count - 1
            Dim val As String = chkParameters.CheckedItems.Item(i).Split("--")(0).ToString()
            If i = 0 Then
                str = val
            Else
                str = str + "," + val
            End If
        Next
        txtRuleKeyField.Text = str
    End Sub
    Private Sub SetControlValue(ByVal chk As CheckedListBox, ByVal val As String)
        If (val.Split(",").Length > 0) Then
            Dim i As Integer = 0
            Dim m As Integer = 0
            For i = 0 To val.Split(",").Length - 1
                Dim str As String = val.Split(",")(0).ToString
                For m = 0 To chkParameters.Items.Count - 1
                    If str.ToLower() = chkParameters.Items(m).ToString().Split("--")(0).ToLower Then
                        chkParameters.SetItemChecked(m, True)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub toolCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCheck.Click


       


        Dim sql As String = Me.txtRuleCheckSQL.Text.ToUpper
        Dim keyfield As String() = txtRuleKeyField.Text.ToUpper.Split(",")

        Dim i As Integer = 0
        Dim m As Integer = 0
        If txtRuleKeyField.Text <> "" Then
            If keyfield.Length > 0 Then
                If sql <> "" Then
                    For i = 0 To keyfield.Length - 1
                        sql = sql.Replace(keyfield(i), "''")
                        Dim notin As Boolean = False
                        For m = 0 To chkParameters.Items.Count - 1
                            If keyfield(i).ToLower = chkParameters.Items(m).ToString().Split("--")(0).ToLower Then
                                notin = True
                            End If
                        Next
                        If notin = False Then
                            MessageBox.Show("����" + keyfield(i).ToLower + "���Ϸ�")
                            Return
                        End If
                    Next

                    sql = "select top 1 1 from (" + sql + ") AA"
                    Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
                    Try
                        If Sdbc.CheckDataExistsBySql(sql) Then

                        End If
                        MessageBox.Show("SQL�﷨����")
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        txtRuleCheckSQL.SelectAll()
                        txtRuleCheckSQL.Focus()
                        'Throw ex
                    End Try
                End If

            End If
        End If



    End Sub

    
End Class
