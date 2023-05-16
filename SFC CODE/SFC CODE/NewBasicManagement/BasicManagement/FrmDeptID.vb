

#Region "Imports"

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
Imports MainFrame

#End Region

Public Class FrmDeptID

#Region "参数定义"

    Public opflag As Int16 = 0  '

    Private Enum CDImportGrid
        DeptID
        DeptName
        Factoryid
        Profitcenter
        Usey
    End Enum

#End Region

#Region "初期化"

    '初期化
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataToCombox() '
        LoadDataToDatagridview(" ", "Y")
        ToolbtnState(opflag)
        dgvDept.Enabled = True
    End Sub

    '下拉框初期化
    Private Sub LoadDataToCombox()
        'Dim strSQL As String = ""

        'If VbCommClass.VbCommClass.IsConSap = "Y" Then
        '    strSQL = "select Factoryid,Shortname from m_Factory_t where Usey='Y'"
        'Else
        '    strSQL = "select Factoryid,Shortname from m_Dcompany_t where Usey='Y'"
        'End If

        'Dim Reader As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'If Reader.Rows.Count > 0 Then
        '    For rowIndex As Integer = 0 To Reader.Rows.Count - 1
        '        cbbFactory.Items.Add(Reader.Rows(rowIndex)!Factoryid & "-" & Reader.Rows(rowIndex)!Shortname)
        '    Next
        'End If
        'cbbFactory.SelectedIndex = -1

        Dim Reader As DataTable = VbCommClass.CommClass.GetDcompanyDs().Tables(0)
        If Reader.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To Reader.Rows.Count - 1
                cbbFactory.Items.Add(Reader.Rows(rowIndex)!Name)
                ' cbbFactory.Items.Add(Reader.Rows(rowIndex)!Factoryid & "-" & Reader.Rows(rowIndex)!Shortname)
            Next
        End If
        cbbFactory.SelectedIndex = -1
    End Sub

    '设置状态
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False

                'GroupBox
                Me.cbbFactory.SelectedIndex = -1
                'Me.cbbFactory.Enabled = False
                Me.txtDeptCode.Enabled = True
                Me.txtDeptName.Enabled = False
                Me.dgvDept.Enabled = True

                Me.ActiveControl = Me.txtDeptCode
            Case 1, 2 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'Me.toolCheck.Enabled = False

                'GroupBox
                Me.txtDeptName.Enabled = True
                'Me.cbbFactory.Enabled = IIf(opflag = 1, True, False)
                'Me.txtStationName.Enabled = False
                Me.dgvDept.Enabled = False
                'Me.ActiveControl = IIf(opflag = 1, Me.cbbFactory, Me.txtDeptName)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                Me.cbbFactory.Enabled = True
                Me.txtDeptName.Enabled = True
                Me.txtDeptName.Enabled = True
                Me.dgvDept.Enabled = True

                Me.ActiveControl = Me.txtDeptName
        End Select
    End Sub

#End Region


#Region "方法"

    Private Function Checkdata() As Boolean
        If Me.txtDeptCode.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.txtDeptCode
            Return False
        End If
        If Me.txtDeptName.Text.Trim = "" Then
            LblMsg.Text = "部门名称不能为空..."
            Me.ActiveControl = Me.txtDeptName
            Return False
        End If
        If opflag = 1 Then
            If Me.cbbFactory.Text.Trim = "" Then
                LblMsg.Text = "部门所属公司不能为空..."
                Me.ActiveControl = Me.cbbFactory
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String, ByRef Interpret As String)
        Dim SqlStr As String = ""

        dgvDept.Rows.Clear()
        SqlStr = "select deptid,dqc,Factoryid,usey from m_Dept_t where usey='" & Interpret & "' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "') "

        If (Not String.IsNullOrEmpty(Me.cbbFactory.Text.Trim)) Then
            SqlStr = SqlStr & " AND factoryid='" & Me.cbbFactory.Text.Trim.Split("-")(0) & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.txtDeptCode.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptid='" & Me.txtDeptCode.Text.Trim & "' "
        End If

        Dim Dreader As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)
        For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
            dgvDept.Rows.Add(Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString, _
            Dreader.Rows(rowIndex).Item(3).ToString)
        Next
        toolStripStatusLabel3.Text = Me.dgvDept.Rows.Count
    End Sub

#End Region

#Region "按钮事件"
    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        ChkUsey.Checked = True
        txtDeptCode.Text = ""
        'txtRemark.Text = ""
        txtDeptName.Text = ""
        cbbFactory.SelectedIndex = -1
        opflag = 1
        ToolbtnState(1)
        txtDeptCode.Enabled = True
    End Sub
    '编辑
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvDept.Rows.Count = 0 OrElse Me.dgvDept.CurrentRow Is Nothing Then Exit Sub

        txtDeptCode.Text = dgvDept.CurrentRow.Cells("ColLineid").Value
        txtDeptName.Text = dgvDept.CurrentRow.Cells("ColLineName").Value
        cbbFactory.SelectedIndex = Me.cbbFactory.FindString(dgvDept.CurrentRow.Cells("Colgx").Value)
        ChkUsey.Checked = IIf(dgvDept.CurrentRow.Cells("ColUsey").Value = "Y", True, False)

        opflag = 2
        ToolbtnState(2)
    End Sub
    '作废
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvDept.Rows.Count = 0 OrElse Me.dgvDept.CurrentRow Is Nothing Then Exit Sub

        Try
            DbOperateUtils.ExecSQL(" update m_Logtree_t set Tparent='10109_Z' where ButtonID=N'" & dgvDept.CurrentRow.Cells("ColLineid").Value & "'")
            DbOperateUtils.ExecSQL(" update m_Dept_t set usey='N' where deptid = '" & dgvDept.CurrentRow.Cells("ColLineid").Value & "'")
            LoadDataToDatagridview(" and deptid='" & dgvDept.CurrentRow.Cells("ColLineid").Value & "'", "Y")
        Catch ex As Exception
            Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
            LoadDataToDatagridview(" ", cheUsy)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub
    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = ""
        Dim TreeId As String
        Dim Tkey As String
        Dim jieguo As String
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
        Dim Enname As String = Me.cbbFactory.Text + "{" + Me.txtDeptName.Text.Trim() + "(" + Me.txtDeptCode.Text.Trim() + ")" + "}"

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then

            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT deptid FROM m_Dept_t WHERE deptid='" & Me.txtDeptCode.Text.Trim() & "'")
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("部门已经存在！")
                Exit Sub
            End If

            Dim mRead As DataTable = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent LIKE '10109_%'")

            If mRead.Rows.Count > 0 Then
                TreeCount = Convert.ToInt16(mRead.Rows(0)!countTreeid) + 1
            Else
                TreeCount = "1"
            End If

            TreeId = "n01" + TreeCount.PadLeft(3, "0")
            Tkey = "n01" + TreeCount.PadLeft(3, "0") + "_"
            While DbOperateUtils.GetDataTable("SELECT * FROM m_Logtree_t mlt WHERE Tparent LIKE '10109_%' AND Treeid ='" + TreeId + "'and tkey ='" + Tkey + "'").Rows.Count
                TreeCount += 1
                TreeId = "n01" + TreeCount.PadLeft(3, "0")
                Tkey = "n01" + TreeCount.PadLeft(3, "0") + "_"
            End While
            SqlStr.AppendFormat(ControlChars.CrLf & "insert into m_Dept_t(deptid, djc, dqc,Factoryid,usey)" &
                          "values('{0}',N'{1}',N'{2}',N'{3}','Y')", txtDeptCode.Text, txtDeptCode.Text, txtDeptName.Text.Trim,
                           cbbFactory.Text.ToString.Trim.Split("-")(0))

            '新增权限
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, " _
              & " TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','10109_',N'" & Enname & "',N'" & Enname & "',null,'mes00','Line','" & Me.txtDeptCode.Text.Trim & "','4','4','2','3','" & cheUsy & "',null,'N')")

        ElseIf opflag = 2 Then
            SqlStr.Append("update m_Dept_t set dqc =N'" & txtDeptName.Text.Trim & "',Usey='" & cheUsy & "' where deptid = '" & txtDeptCode.Text.Trim & "'")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")

            If cheUsy = "Y" Then
                jieguo = "10109_"
            Else
                jieguo = "10109_Z"
            End If

            '更新权限
            SqlStr.Append(ControlChars.CrLf & " update m_Logtree_t set Ttext=N'" & Enname & "', Enname=N'" & Enname & "' ,Tparent='" & jieguo & "'where ButtonID=N'" & Me.txtDeptCode.Text.Trim() & "' ")

        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(" ", "Y")

            cbbFactory.SelectedIndex = -1
            txtDeptName.Text = ""
            txtDeptName.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        cbbFactory.SelectedIndex = -1
        txtDeptCode.Text = ""
        txtDeptName.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub
    '退出
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '查询
    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

        LoadDataToDatagridview(" ", cheUsy)
    End Sub
    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

        Dim SqlStr As String = "select deptid 部门编号,dqc 部门名称,Factoryid 厂区, Profitcenter 利润中心, usey 是否可用 from m_Dept_t where usey='" & cheUsy & "' "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub
    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据 (5:代表5列数据)
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 5, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select("DeptId  IS NOT NULL ") '防止追加

            '现在开始把数据保存到DB中,先要转
            'TableAddColumns("EsortName", "System.String", dtUploadData)

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)
            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入！")
            End If
            LoadDataToDatagridview(" ", "Y")

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    '查看导入文件
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "部门资料维护导入模板")
    End Sub

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim TreeCount As String = ""
        Dim TreeId As String
        Dim Tkey As String
        Dim Enname As String

        Dim mRead As DataTable = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent LIKE '10109_%'")

        If mRead.Rows.Count > 0 Then
            TreeCount = Convert.ToInt16(mRead.Rows(0)!countTreeid) + 1
        Else
            TreeCount = "1"
        End If

        Dim strSQL As String = "insert into m_Dept_t(deptid, djc, dqc,Factoryid,Profitcenter,usey) values('{0}',N'{0}',N'{1}',N'{2}',N'{3}','Y')"
        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString())
            strInsertSQL.AppendLine()

            TreeCount += 1
            TreeId = "n01" + TreeCount.PadLeft(3, "0")
            Tkey = "n01" + TreeCount.PadLeft(3, "0") + "_"

            Enname = row(2).ToString() + "{" + row(1).ToString() + "(" + row(0).ToString() + ")" + "}"

            '新增权限
            strInsertSQL.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','10109_',N'" & Enname & "',N'" & Enname & "',null,'mes00','Line','" & Me.txtDeptCode.Text.Trim & "','4','4','2','3','Y',null,'N')")
        Next

        Return strInsertSQL.ToString
    End Function

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB不良现象大类别
        Dim codeNameSQL As String = " select distinct deptid,dqc,Factoryid,Profitcenter from m_Dept_t  where 1= 1  "
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""


        For index As Integer = 0 To DrrR.Length - 1

            '不良现象大类别
            Dim DeptID As String = DrrR(index)("DeptID").ToString.Trim

            Dim returnCode As String = ""
            '部门ID
            If DeptID <> "" Then
                If CheckExistUserColumns(codeNameDT, "DeptID", DeptID, returnCode) = True Then
                    MessageUtils.ShowError("上传[部门ID]在资料库中存在：'" + DeptID + "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("[部门ID]有空值,请检查后重新上传。")
                Return False
            End If

            returnCode = ""
            '部门名称
            Dim DeptName As String = DrrR(index)("DeptName").ToString.Trim
            If DeptName <> "" Then
                If CheckExistUserColumns(codeNameDT, "dqc", DeptName, returnCode) = True Then
                    MessageUtils.ShowError("上传[部门名称]在资料库中存在：'" + DeptName + "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("[部门名称]有空值,请检查后重新上传。")
                Return False
            End If

            '厂区
            Dim Factoryid As String = DrrR(index)("Factoryid").ToString.Trim
            If Factoryid = "" Then
                MessageUtils.ShowError("[厂区]有空值,请检查后重新上传。")
                Return False
            End If
        Next

        Return True
    End Function

    '检查方法
    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function


#End Region

 
End Class