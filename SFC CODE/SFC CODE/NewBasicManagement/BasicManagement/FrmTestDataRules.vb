Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports System.Text

Public Class FrmTestDataRules
    Public frmRTestTypeid As String = "" '
    Public frmRTestTypenName As String = ""
    Public opflag As Int16 = 0
    Public strWhere As String = ""

    Private Sub FrmTestDataRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Erightbutton()
        BindCombox(cbbdatabase)   '数据库下拉框
        cbbdatabase.SelectedIndex = -1
        SetControlStutas(0)
        SelectQuery()
        Me.chkUsey.Checked = True
    End Sub
    '查询
    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim SqlSearch As String = String.Format("select TestTypeID,TestTypeName,DocumentType,SelectSql,SaveTableName,Usey,KeyFileld,KeyIndex,StationSEQ,ProductGroup,CheckFunction,CompleteProcess,Userid,Intime from " & cbbdatabase.Text.Trim & ".[MESDataCenter].dbo.m_testtype_t where 1=1 {0}", Sqlstring)
        Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(SqlSearch)
        DgList.DataSource = DtContrast
        ToolCount.Text = DgList.RowCount.ToString()
    End Sub
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        SetControlStutas(0)
        SelectQuery()
    End Sub
    Private Sub SelectQuery()
        strWhere = ""
        If String.IsNullOrEmpty(txtTestTypeid.Text.Trim) = False Then
            strWhere = strWhere & " and TestTypeid like N'%" & Me.txtTestTypeid.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtTestTypeName.Text.Trim) = False Then
            strWhere = strWhere & " and TestTypeName like N'%" & Me.txtTestTypeName.Text.Trim & "%' "
        End If


        If String.IsNullOrEmpty(txtDocumentType.Text.Trim) = False Then
            strWhere = strWhere & " and DocumentType like N'%" & Me.txtDocumentType.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtSelectSql.Text.Trim) = False Then
            strWhere = strWhere & " and SelectSql like N'%" & Me.txtSelectSql.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtSaveTableName.Text.Trim) = False Then
            strWhere = strWhere & " and SaveTableName like N'%" & Me.txtSaveTableName.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtKeyFileld.Text.Trim) = False Then
            strWhere = strWhere & " and KeyFileld like N'%" & Me.txtKeyFileld.Text.Trim & "%' "
        End If

        If String.IsNullOrEmpty(txtKeyIndex.Text.Trim) = False Then
            strWhere = strWhere & " and KeyIndex like N'%" & Me.txtKeyIndex.Text.Trim & "%' "
        End If
        If Me.chkUsey.Checked Then
            strWhere &= " and Usey = 'Y'"
        Else
            strWhere &= " and Usey = 'N'"
        End If

        SearchRecord(strWhere)

        'If String.IsNullOrEmpty(txtuserid.Text.Trim) = False Then
        '    strWhere = strWhere & " and userid like N'%" & Me.txtuserid.Text.Trim & "%' "
        'End If

        'If String.IsNullOrEmpty(txtIntime.Text.Trim) = False Then
        '    strWhere = strWhere & " and CONVERT(varchar(10), Intime,121) like N'%" & Me.txtIntime.Text.Trim & "%'"
        'End If
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '新增，改变按钮状态
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        txtTestTypeid.Text = ""
        txtTestTypeName.Text = ""
        txtDocumentType.Text = ""
        txtSelectSql.Text = ""
        txtSaveTableName.Text = ""
        txtKeyFileld.Text = ""
        txtKeyIndex.Text = ""
        SysMessageClass.EditFlag = True
        opflag = 1
        SetControlStutas(1)
        txtTestTypeid.Focus()
        'DataAdd()
    End Sub
    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.DgList.Rows.Count = 0 OrElse Me.DgList.CurrentRow Is Nothing Then Exit Sub
        txtTestTypeid.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("TestTypeID").Value)
        txtTestTypeName.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("TestTypeName").Value)
        'txtNetSavePath.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells(2).Value)
        'txtNetMovePath.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells(3).Value)
        txtDocumentType.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("DocumentType").Value)
        txtSelectSql.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("SelectSql").Value)
        txtSaveTableName.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("SaveTableName").Value)
        txtKeyFileld.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("KeyFileld").Value)
        txtKeyIndex.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("KeyIndex").Value)
        txtstationseq.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("StationSEQ").Value)
        txtprogroup.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("ProductGroup").Value)
        txtcheckfuction.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("checkfunction").Value)
        txtcompletecross.Text = DbOperateUtils.DBNullToStr(DgList.CurrentRow.Cells("CompleteProcess").Value)
        opflag = 2
        SetControlStutas(2)
    End Sub
    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim SqlStr As New StringBuilder
            If Me.DgList.Rows.Count = 0 OrElse Me.DgList.CurrentRow Is Nothing Then Exit Sub
        Try
            Dim o_StrDBPrefix As String = ""
            If cbbdatabase.Text.Trim() = "" Then
                o_StrDBPrefix = ""
            Else
                o_StrDBPrefix = cbbdatabase.Text + "."
            End If
            SqlStr.Append(" UPDATE " & o_StrDBPrefix & "[MESDataCenter].dbo.m_testtype_t ")
            SqlStr.Append(" SET Usey = 'N' WHERE TestTypeid = '" & Me.DgList.CurrentRow.Cells("TestTypeID").Value & "'")
            If MessageUtils.ShowConfirm("确定要作废吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                DbOperateUtils.ExecSQLNoTran(SqlStr.ToString)
                MessageUtils.ShowInformation("作废成功！")
                SearchRecord(strWhere)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestDataRules", "toolDelete_Click", "sys")
        End Try
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        'Dim SqlStr As String
        Dim SqlStr As New StringBuilder
        Dim o_StrDBPrefix As String = ""
        LblMsg.Text = ""
        If Checkdata() = False Then Exit Sub
        Dim mCheckCodeRead As DataTable = Nothing
        mCheckCodeRead = DbOperateUtils.GetDataTable("SELECT 1 from m_testtype_v where  TestTypeid='" & Me.txtTestTypeid.Text.Trim() & "'and Usey='Y'")
        If opflag = 1 Then '新增保存
            If mCheckCodeRead.Rows.Count > 0 Then
                MessageBox.Show("该测试工站说已存在!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                opflag = 0
                SetControlStutas(0)
                Exit Sub
            End If
            If cbbdatabase.Text.Trim() = "" Then
                o_StrDBPrefix = ""
            Else
                o_StrDBPrefix = cbbdatabase.Text + "."
            End If
            SqlStr.AppendFormat(" IF NOT EXISTS(SELECT 1 FROM " & o_StrDBPrefix & "[MESDataCenter].dbo.m_testtype_t WHERE TestTypeid = '{0}' AND TestTypeName = '{1}') ", txtTestTypeid.Text.Trim, txtTestTypeName.Text.Trim)
            SqlStr.Append("BEGIN")
            SqlStr.Append("   INSERT INTO  " & o_StrDBPrefix & "[MESDataCenter].dbo.m_testtype_t")
            SqlStr.AppendFormat("(TestTypeid,TestTypeName,DefaultSaveWay,DocumentType,IsMultFolder,GetMethod,GetRate,InSertSql,SelectSql,TestParamList")
            SqlStr.AppendFormat(",SaveTableName,UploadY,Usey,Userid,Intime,MovePath,FhandleType,readType,split,KeyIndex,KeyFileld,StartReadLine,")
            SqlStr.AppendFormat("PreStation,NetSavePath,NetMovePath,DetUsey,DetInsertSql,MailUsey,Mails,MobileUsey,Mobiles,ResultIndex,FieldZipUsey,")
            SqlStr.AppendFormat("FieldZipNames,IsControlAAB,ControlKeyField,CheckFunction,StationSEQ,ProductGroup,MaxTestCount,CompleteProcess")
            SqlStr.AppendFormat(")")
            SqlStr.AppendFormat(" VALUES ( ")
            SqlStr.AppendFormat("'{0}',", txtTestTypeid.Text.Trim)
            SqlStr.AppendFormat("N'{0}',", txtTestTypeName.Text.Trim)
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'{0}',", txtDocumentType.Text.Trim)
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'1',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("N'{0}',", txtSelectSql.Text.Trim)
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("N'{0}',", txtSaveTableName.Text.Trim)
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("N'{0}',", IIf(chkUsey.Checked = True, "Y", "N"))
            SqlStr.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
            SqlStr.AppendFormat("getdate(),")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("{0},", txtKeyIndex.Text.Trim)
            SqlStr.AppendFormat("N'{0}',", txtKeyFileld.Text.Trim)
            SqlStr.AppendFormat("1,")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'1',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'N',") 'mainusey
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("1,")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'N',")
            SqlStr.AppendFormat("'NULL',")
            SqlStr.AppendFormat("'{0}',", txtcheckfuction.Text.Trim)
            SqlStr.AppendFormat("'{0}',", txtstationseq.Text.Trim)
            SqlStr.AppendFormat("'{0}',", txtprogroup.Text.Trim)
            SqlStr.AppendFormat("'{0}',", txttestcount.Text.Trim)
            SqlStr.AppendFormat("'{0}'", txtcompletecross.Text.Trim)
            SqlStr.AppendFormat(")")
            SqlStr.Append("END ")

            '修改保存
        ElseIf opflag = 2 Then
            frmRTestTypeid = DgList.CurrentRow.Cells(0).Value.ToString.Trim
            SqlStr.Append(" UPDATE" & o_StrDBPrefix & "[MESDataCenter].dbo.m_testtype_t ")
            SqlStr.AppendFormat(" SET TestTypeName = N'{0}'", txtTestTypeName.Text.Trim)
            SqlStr.AppendFormat(" ,DocumentType = '{0}'", txtDocumentType.Text.Trim)
            SqlStr.AppendFormat(" ,SelectSql = '{0}'", txtSelectSql.Text.Trim)
            SqlStr.AppendFormat(" ,SaveTableName = '{0}'", txtSaveTableName.Text.Trim)
            SqlStr.AppendFormat(" ,Usey ='{0}'", IIf(chkUsey.Checked = True, "Y", "N"))
            SqlStr.AppendFormat(" ,KeyFileld = '{0}'", txtKeyFileld.Text.Trim)
            SqlStr.AppendFormat(" ,KeyIndex = '{0}'", txtKeyIndex.Text.Trim)
            SqlStr.AppendFormat(" ,StationSEQ = '{0}'", txtstationseq.Text.Trim)
            SqlStr.AppendFormat(" ,Productgroup = '{0}'", txtprogroup.Text.Trim)
            SqlStr.AppendFormat(" ,CheckFunction = '{0}'", txtcheckfuction.Text.Trim)
            SqlStr.AppendFormat(" ,CompleteProcess = '{0}'", txtcompletecross.Text.Trim)
            SqlStr.AppendFormat(" ,Userid = '{0}'", SysMessageClass.UseId)
            SqlStr.AppendFormat(" ,Intime =getdate()")
            SqlStr.Append(" WHERE TestTypeId = N'" & frmRTestTypeid & "'")
        End If
        Try
            DbOperateUtils.ExecSQLNoTran(SqlStr.ToString)
            SearchRecord(strWhere)
            opflag = 3
            SetControlStutas(3)
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestDataRules", "toolSave_Click", "BasicM")
            Exit Sub
        End Try
    End Sub
    Private Function Checkdata() As Boolean
        If Me.txtTestTypeid.Text.Trim = "" Then
            LblMsg.Text = "测试站点编号不能为空..."
            Me.ActiveControl = Me.txtTestTypeid
            Return False
        End If
        If Me.txtTestTypeName.Text.Trim = "" Then
            LblMsg.Text = "测试站点名称不能为空..."
            Me.ActiveControl = Me.txtTestTypeName
            Return False
        End If
        If Me.txtDocumentType.Text.Trim = "" Then
            LblMsg.Text = "文件类型不能为空..."
            Me.ActiveControl = Me.txtDocumentType
            Return False
        End If
        If Me.txtSaveTableName.Text.Trim = "" Then
            LblMsg.Text = "保存表不能为空..."
            Me.ActiveControl = Me.txtSaveTableName
            Return False
        End If
        If Me.txtKeyFileld.Text.Trim = "" Then
            LblMsg.Text = "主键不能为空..."
            Me.ActiveControl = Me.txtKeyFileld
            Return False
        End If
        Return True
    End Function
    ''清空数据
    'Private Sub ClearControl()
    '    Dim ClearCon As Control
    '    For Each ClearCon In Me.Controls
    '        If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
    '            ClearCon.Text = ""
    '        ElseIf TypeOf ClearCon Is ComboBox Then
    '            ClearCon.Text = ""
    '        End If
    '    Next
    'End Sub
    Private Sub SetControlStutas(ByVal flag As Int16)
        Select Case flag
            Case 0 '返回
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                toolQuery.Enabled = True
                toolExit.Enabled = True
                Me.txtTestTypeid.Enabled = True
            Case 1 '新增
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolQuery.Enabled = False
                toolExit.Enabled = True
                'Me.cbbdatabase.SelectedIndex = -1
                Me.cbbdatabase.Enabled = True
                Me.txtTestTypeid.Enabled = True
                Me.txtTestTypeName.Enabled = True
                Me.txtDocumentType.Enabled = True
                Me.txtSelectSql.Enabled = True
                Me.txtSaveTableName.Enabled = True
                Me.txtKeyFileld.Enabled = True
                Me.txtKeyIndex.Enabled = True
            Case 2 '修改
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolQuery.Enabled = False
                toolExit.Enabled = True
                Me.cbbdatabase.Enabled = True
                Me.txtTestTypeid.Enabled = False
                Me.txtTestTypeName.Enabled = True
                Me.txtDocumentType.Enabled = True
                Me.txtSelectSql.Enabled = True
                Me.txtSaveTableName.Enabled = True
                Me.txtKeyFileld.Enabled = True
                Me.txtKeyIndex.Enabled = True
            Case 3 '返回
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                toolQuery.Enabled = True
                toolExit.Enabled = True
                txtTestTypeid.Text = ""
                txtTestTypeName.Text = ""
                Me.txtDocumentType.Text = ""
                Me.txtSelectSql.Text = ""
                Me.txtSaveTableName.Text = ""
                Me.txtKeyFileld.Text = ""
                Me.txtKeyIndex.Text = ""
                Me.txtcheckfuction.Text = ""
                Me.txtstationseq.Text = ""
                Me.txtprogroup.Text = ""
                Me.txttestcount.Text = ""
                Me.txtcompletecross.Text = ""
                Me.txtTestTypeid.Enabled = True
        End Select

    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opflag = 3
        SetControlStutas(3)
    End Sub
    Private Sub toolCheck_Click(sender As Object, e As EventArgs)
        SetSelectedData()
    End Sub
    'GRID数据选择
    Private Sub SetSelectedData()
        If Me.DgList.Rows.Count = 0 OrElse Me.DgList.CurrentRow Is Nothing Then Exit Sub
        frmRTestTypeid = Me.DgList.Item(0, Me.DgList.CurrentRow.Index).Value.ToString.Trim
        frmRTestTypenName = Me.DgList.Item(1, Me.DgList.CurrentRow.Index).Value.ToString.Trim '2
        Me.Close()
    End Sub

    Private Sub dgvRstation_DoubleClick(sender As Object, e As EventArgs) Handles DgList.DoubleClick
        SetSelectedData()
    End Sub
    '下拉框绑定数据
    'Private Sub Erightbutton()
    '    Dim Conn As New SysDataBaseClass
    '    Dim Reader As SqlDataReader = Conn.GetDataReader("SELECT TEXT FROM m_BaseData_t WHERE ITEMKEY = 'TESTDB' ")
    '    If Reader.HasRows Then
    '        While Reader.Read
    '            cbbdatabase.Items.Add(Reader!TEXT)
    '        End While
    '    End If
    '    Reader.Close()
    '    cbbdatabase.SelectedIndex = -1
    'End Sub
    '下拉框绑定数据库
    Private Sub BindCombox(ByVal ColComboBox As ComboBox)
        Try
            Dim strSQL As String
            If ColComboBox.Name.ToUpper = "CBBDATABASE" Then
                strSQL = "SELECT VALUE,TEXT FROM m_BaseData_t WHERE ITEMKEY = 'TESTDB' "
                BindCombox(strSQL, ColComboBox, "TEXT", "VALUE")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub BindCombox(ByVal SQL As String, ByVal cbbdatabase As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        Dim dr As DataRow = dt.NewRow
        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        cbbdatabase.DataSource = dt
        cbbdatabase.DisplayMember = Text
        cbbdatabase.ValueMember = value
    End Sub
    Public Shared Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            'WriteLog(sql)
            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function
#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgList.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

End Class