Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports LXWarehouseManage
Imports MainFrame

Public Class FrmRPartStationRules

    Dim LostCheck As Boolean
    Dim Searchy As Boolean

#Region "事件"

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
        'StrOldPart = Me.DgList.CurrentRow.Cells(0).Value
        'StrOldPartp = Me.DgList.CurrentRow.Cells(1).Value.ToString
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
        'ExportClass.ExporToExcel(SqlSearch, "导出料件基本资料")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strWhere As String = ""

        If String.IsNullOrEmpty(txtRuleName.Text.Trim) = False Then
            strWhere = strWhere & " and RuleName like N'%" & Me.txtRuleName.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtTestID.Text.Trim) = False Then
            strWhere = strWhere & " and RuleCheckSQL like '%" & Me.txtTestID.Text.Trim & "%' "
        End If

        SearchRecord(strWhere)
    End Sub

    Private Sub FileRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        '    MessageBox.Show("叫块琩高兵ン", "矗ボ獺", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

#Region "设置内容"
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

#Region "控件状态"

    Private Sub SetControlStutas(ByVal FlagStr As String)

        Select Case UCase(FlagStr)
            Case "ADD"
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = True
                UnDo.Enabled = True
                'Export.Enabled = False
                btnSearch.Enabled = False
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
                btnSearch.Enabled = False
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
                btnSearch.Enabled = True
                ExitFrom.Enabled = True
                'Me.UpLmt.Enabled = False
                'Me.UpYttishi.Enabled = False
                'Me.CobPartCode.Enabled = False
                'Me.CobTypeDesc.Enabled = False
        End Select

    End Sub
#End Region

#Region "清空数据"
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

#Region "改变记录"

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

#Region "取消"

    Private Sub CancelChg()

        ChgRecord(1)
        SetControlStutas("UNDO")
        SetValueToControl()

    End Sub
#End Region

#Region "新增"

    Private Sub AddRecord()

        ChgRecord(0)
        SetControlStutas("ADD")
        ClearControl()

    End Sub

#End Region

#Region "编辑"

    Private Sub EditRecord()

        ChgRecord(0)
        SetControlStutas("EDIT")

    End Sub

#End Region

#Region "删除"

    Private Sub DeleteRecord()

        If DgList.RowCount < 1 Then Exit Sub
        If Me.DgList.CurrentRow.Index = -1 Then Exit Sub
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlString As String
        If MessageBox.Show("你确定要删除该记录吗...", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                SqlString = "delete from m_RPartStationRules_t where id='" & txtID.Text.Trim & "' "
                Sdbc.ExecSql(SqlString)
                SearchRecord("")
            Catch Eex As Exception
                MessageBox.Show(Eex.Message & vbNewLine & "删除时，发生错误!", "提示信息", MessageBoxButtons.OK)
            Finally
                Sdbc.PubConnection.Close()
                'Sdbc = Nothing
            End Try
        End If
        'Sdbc = Nothing
        SetValueToControl()
    End Sub
#End Region

#Region "设置初期值"
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

#Region "查询"

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim SqlSearch As String = String.Format("select id,RuleName,RuleCheckSQL,RuleKeyField,RuleType,Ruleusey,RuleOrderby from m_RPartStationRules_t where 1=1 {0} order by id,RuleOrderby ",
                                  Sqlstring)
        Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(SqlSearch)
        DgList.DataSource = DtContrast

        'bmFoxStudio = Me.BindingContext(DtContrast)

        Dim ChColsText As String = "ID|检测名称|SQL变量|检测SQL|类别|是否启用|排序"

        Dim colNames As String() = ChColsText.Split("|")
        Dim i As Integer
        For i = 0 To DgList.Columns.Count - 1
            DgList.Columns(i).HeaderText = colNames(i)
            DgList.Columns(i).Name = colNames(i)
        Next
        DgList.Columns(0).Width = 30
        ToolStripStatusLabel1.Text = DtContrast.Rows.Count & "笔"
    End Sub

#End Region

#Region "保持数据"
    Private Sub SaveData()

        Dim SqlStr As String
        Try
            CheckRecord()
            Dim IsRuleusey As String = IIf(chkRuleusey.Checked, "Y", "N")

            If SysMessageClass.EditFlag = True Then
                Dim sql As String = String.Format("select RuleName from m_RPartStationRules_t where RuleName='{0}'  ", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleType.SelectedValue.ToString))
                Dim DrCheck As DataTable = DbOperateUtils.GetDataTable(sql)
                ''DrCheck = Sdbc.GetDataReader("select 1 from m_PartContrast_t where TAvcPart='" & Trim(Me.TxtTavcPart.Text) & "' ")
                If DrCheck.Rows.Count > 0 Then
                    MessageBox.Show("系统中已存在该记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                SqlStr = String.Format("insert into m_RPartStationRules_t(RuleName,RuleCheckSQL,RuleKeyField,RuleType,Ruleusey,RuleOrderby) " _
                & " values(N'{0}',N'{1}',N'{2}','{3}','{4}','{5}') ", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleCheckSQL.Text).Replace("'", "''"), Trim(Me.txtRuleKeyField.Text), Trim(Me.txtRuleType.SelectedValue.ToString), IsRuleusey, Trim(Me.txtRuleOrderby.Text))
            Else
                SqlStr = String.Format(" update m_RPartStationRules_t set RuleName=N'{0}',RuleCheckSQL=N'{1}',RuleKeyField=N'{2}',Ruleusey='{3}',RuleOrderby='{4}',RuleType='{6}' where id='{5}'", Trim(Me.txtRuleName.Text), Trim(Me.txtRuleCheckSQL.Text).Replace("'", "''"), Trim(Me.txtRuleKeyField.Text), IsRuleusey, Trim(Me.txtRuleOrderby.Text), txtID.Text.ToString, Trim(Me.txtRuleType.SelectedValue.ToString))
            End If

            DbOperateUtils.ExecSQL(SqlStr)

            ChgRecord(1)
            SetControlStutas("UNDO")
            SearchRecord("")
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
        End Try
    End Sub
#End Region

#Region "检查记录"
    Private Sub CheckRecord()

        'Dim DrNameShow As SqlDataReader
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim TavcPartErr As New Exception("检测名称不能为空!")
        TavcPartErr.Source = "CheckRecord"
        If Me.txtRuleName.Text = "" Then
            Throw TavcPartErr
            txtRuleName.Focus()
        End If
        If txtRuleKeyField.Text <> "" Then
            Dim CheckSQLEmpty As New Exception("检测SQL语句不能为空")
            CheckSQLEmpty.Source = "CheckRecord"
            If Me.txtRuleCheckSQL.Text = "" Then
                txtRuleCheckSQL.Focus()
                Throw CheckSQLEmpty
            Else
                Dim CheckSQLErr As New Exception("检测SQL语句失败")
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
                        MessageBox.Show("变量" + keyfield(i).ToLower + "不合法")
                        Throw CheckSQLErr
                    End If

                    For i = 0 To keyfield.Length - 1
                        sql = sql.Replace(keyfield(i), "''")
                    Next
                    sql = "select top 1 1 from (" + sql + ") AA"
                    Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
                    Try
                        If Sdbc.CheckDataExistsBySql(sql) Then
                            'MessageBox.Show("SQL语法正常")
                        End If
                    Catch ex As Exception
                        txtRuleCheckSQL.Focus()
                        txtRuleCheckSQL.SelectAll()
                        Throw CheckSQLErr
                    End Try
                End If

            End If
        End If


        'Dim CustPartErr As New Exception("客户料号不能为空")
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

    Private Sub FrmPartContrast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillListCombox(txtRuleType, "select SortID,SortName from m_Sortset_t where sorttype=N'RuleType' order by orderid", "SortID", "SortName")
        SearchRecord("")
        SetValueToControl()
        SetControlStutas("UNDO")
    End Sub

    Private Sub txtRuleKeyField_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRuleKeyField.MouseEnter
        Dim ttip As ToolTip = New ToolTip
        ttip.Show("当变量栏位不为空的时候，检测SQL也不能为空", txtRuleKeyField, 1000)
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
                            MessageBox.Show("变量" + keyfield(i).ToLower + "不合法")
                            Return
                        End If
                    Next

                    sql = "select top 1 1 from (" + sql + ") AA"
                    Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
                    Try
                        If Sdbc.CheckDataExistsBySql(sql) Then

                        End If
                        MessageBox.Show("SQL语法正常")
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
