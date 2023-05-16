


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

Public Class FrmDeptLine

#Region "变量定义"

    Public opflag As Int16 = 0
    Public deptad As String = "" '保存需要修改的部门
    Public UseId As String = VbCommClass.VbCommClass.UseId

    Private Enum CDImportGrid
        DeptID
        LineID
        LineJM
        Factoryid
        Usey
    End Enum

#End Region

#Region "加载"

    '初期化
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Erightbutton() '
        InitCombox()
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
        LoadDataToDatagridview(" ", cheUsy)
        ToolbtnState(opflag)
        dgvRstation.Enabled = True
        toolType.Enabled = True
    End Sub

    '权限
    Private Sub Erightbutton()
        Dim Reader As DataTable = DbOperateUtils.GetDataTable("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm15003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        If Reader.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To Reader.Rows.Count - 1
                Obj = CType(Me.GetType().GetField("_" & Reader.Rows(rowIndex)("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            Next
        End If

    End Sub

    Private Sub InitCombox()
        Dim Reader As DataTable
        Dim strSQL As String = ""
        'If VbCommClass.VbCommClass.IsConSap = "Y" Then
        '    strSQL = "select Factoryid,Shortname from m_Factory_t where Usey='Y'"
        'Else
        '    strSQL = "select Factoryid,Shortname from m_Dcompany_t where Usey='Y'"
        'End If

        'Reader = DbOperateUtils.GetDataTable(strSQL)
        Reader = VbCommClass.CommClass.GetDcompanyDs().Tables(0)
        If Reader.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To Reader.Rows.Count - 1
                cbbFactory.Items.Add(Reader.Rows(rowIndex)!Name)
                ' cbbFactory.Items.Add(Reader.Rows(rowIndex)!Factoryid & "-" & Reader.Rows(rowIndex)!Shortname)
            Next
        End If
        cbbFactory.SelectedIndex = -1
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag = "Yes", True, False)  'True
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag = "Yes", True, False)  'True
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag = "Yes", True, False)  'True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                'GroupBox
                Me.cbbFactory.Enabled = True
                Me.txtLineCode.Enabled = True
                Me.cbbDept.Enabled = True
                Me.txtLineJM.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.cbbFactory
            Case 1, 2 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtLineCode.Enabled = False
                Me.txtLineJM.Enabled = True
                Me.cbbFactory.Enabled = True
                Me.cbbDept.Enabled = True
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cbbFactory, Me.txtLineCode)
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                Me.cbbFactory.Enabled = True
                Me.txtLineCode.Enabled = False
                Me.txtLineJM.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.cbbFactory
        End Select
    End Sub

#End Region

    '
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String, ByRef panduan As String)
        Dim Dreader As DataTable
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "select deptid,lineid,linejm,factoryid,usey,userid,intime, (" &
                " SELECT  LEFT(PartSeriesTypeNameList,LEN(PartSeriesTypeNameList)-1) as  PartSeriesTypeNameList  FROM (" &
                " SELECT LINEID, ( SELECT PartSeriesTypeName + ',' FROM m_LineSericesType_t WHERE LINEID = A.LINEID FOR XML PATH('')) AS PartSeriesTypeNameList" &
                " FROM m_LineSericesType_t A WHERE lineid = deptline_t.lineid GROUP BY LINEID) AS B" &
                " ) PartSeriesTypeName, PriorityFlag from deptline_t where usey='" & panduan & "' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "') "

        If (Not String.IsNullOrEmpty(Me.cbbFactory.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptline_t.factoryid='" & Me.cbbFactory.Text.Trim.Split("-")(0) & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.cbbDept.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptline_t.deptid='" & Me.cbbDept.Text.Trim.Split("-")(0) & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.txtLineCode.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptline_t.lineid LIKE '%" & Me.txtLineCode.Text.Trim & "%' "
        End If

        Dreader = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)
        For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
            dgvRstation.Rows.Add(Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString,
            Dreader.Rows(rowIndex).Item(3).ToString, Dreader.Rows(rowIndex).Item(4).ToString, Dreader.Rows(rowIndex).Item(7).ToString, Dreader.Rows(rowIndex).Item(8).ToString, Dreader.Rows(rowIndex).Item(5).ToString, Dreader.Rows(rowIndex).Item(6).ToString)
        Next
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
    End Sub


    Private Function Checkdata() As Boolean
        If Me.cbbDept.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.cbbDept
            Return False
        End If
        If Me.txtLineJM.Text.Trim = "" Then
            LblMsg.Text = "线别名称不能为空..."
            Me.ActiveControl = Me.txtLineJM
            Return False
        End If
        If Me.cbbFactory.Text.Trim = "" Then
            LblMsg.Text = "公司编号不能为空..."
            Me.ActiveControl = Me.cbbFactory
            Return False
        End If
        Return True
    End Function


#Region "菜单事件"
    '穝糤
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        cbbDept.Text = ""
        txtLineCode.Text = ""
        txtLineJM.Text = ""
        'CobShift.SelectedIndex = -1
        opflag = 1
        ToolbtnState(1)
        cbbDept.Enabled = True
        Me.txtLineCode.Enabled = True
    End Sub

    '编辑
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        cbbFactory.SelectedIndex = Me.cbbFactory.FindString(dgvRstation.CurrentRow.Cells("colFactoryID").Value)
        cbbDept.SelectedIndex = Me.cbbDept.FindString(dgvRstation.CurrentRow.Cells("ColDeptid").Value)
        txtLineCode.Text = dgvRstation.CurrentRow.Cells("colLine").Value
        txtLineJM.Text = dgvRstation.CurrentRow.Cells("colLineJm").Value
        txtPriorityFlag.Text = Me.dgvRstation.CurrentRow.Cells("colPriorityFlag").Value

        ChkUsey.Checked = IIf(dgvRstation.CurrentRow.Cells("ColUsey").Value = "Y", True, False)

        opflag = 2
        ToolbtnState(2)
        cbbDept.Enabled = True
        cbbFactory.Enabled = True
    End Sub

    '作废
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            DbOperateUtils.ExecSQL("update deptline_t set usey='N' where deptid = '" & dgvRstation.CurrentRow.Cells("ColDeptid").Value &
                                   "'and lineid='" & dgvRstation.CurrentRow.Cells("colLine").Value & "'")
            Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
            LoadDataToDatagridview(" ", cheUsy)
        Catch ex As Exception
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

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then

            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT  deptid,lineid FROM deptline_t WHERE lineid='" & Me.txtLineCode.Text.Trim() &
                                                              "' and deptid='" & cbbDept.Text.ToString.Trim.Split("-")(0) & "'")
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("线别已经存在！")
                Exit Sub
            End If

            Dim mRead As DataTable = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent LIKE 'z09_%'")

            If mRead.Rows.Count > 0 Then
                TreeCount = Convert.ToInt16(mRead.Rows(0)!countTreeid) + 1
            Else
                TreeCount = "1"
            End If


            TreeId = "zK2" + TreeCount.PadLeft(3, "0")
            Tkey = "zK2" + TreeCount.PadLeft(3, "0") + "_"

            While DbOperateUtils.GetDataTable("SELECT * FROM m_Logtree_t mlt WHERE Tparent LIKE 'z09_%' AND Treeid ='" + TreeId + "'and tkey ='" + Tkey + "'").Rows.Count
                TreeCount += 1
                TreeId = "zK2" + TreeCount.PadLeft(3, "0")
                Tkey = "zK2" + TreeCount.PadLeft(3, "0") + "_"
            End While

            SqlStr.Append(ControlChars.CrLf & "insert into deptline_t(deptid, lineid, factoryid,linejm,usey,userid,intime, cuslineid, PriorityFlag) " _
                     & " values('" & cbbDept.Text.Split("-")(0) & "',N'" & Me.txtLineCode.Text.Trim & "','" & cbbFactory.Text.ToString.Trim.Split("-")(0) & "'," _
                     & " N'" & txtLineJM.Text.Trim & "','" & cheUsy & "','" & SysMessageClass.UseId & "',GETDATE(),'" & Me.txtLineCode.Text.Trim & "', '" &
                     Me.txtPriorityFlag.Text.Trim & "')")

            Dim mRead1 As DataTable = DbOperateUtils.GetDataTable("select*FROM m_Logtree_t WHERE Ttext=N'" & txtLineJM.Text.Trim & "'")
            '新增权限
            If Not mRead1.Rows.Count > 0 Then
                SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, " _
                 & " TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','z09_',N'" & Me.txtLineCode.Text.Trim() & "',N'" &
                 Me.txtLineCode.Text.Trim() & "',null,'mes00','Line','" & Me.txtLineCode.Text.Trim & "','4','4','2','3','Y',null,'N')")
            End If

        ElseIf opflag = 2 Then

            deptad = cbbDept.Text.ToString.Trim.Split("-")(0)

            SqlStr.Append("update deptline_t set factoryid=N'" & cbbFactory.Text.Split("-")(0) & "', linejm =N'" & txtLineJM.Text.Trim & "', usey= '" &
                          cheUsy & "',userid='" & SysMessageClass.UseId & "',intime=getdate(), PriorityFlag = '" & Me.txtPriorityFlag.Text.Trim &
                          "' where  lineid =N'" & txtLineCode.Text.Trim & "' and deptid=N'" & deptad & "'")

            If cheUsy = "Y" Then
                jieguo = "z09_"
            Else
                jieguo = "z09_N"
            End If
            '更新权限
            Dim mRead1 As DataTable = DbOperateUtils.GetDataTable("select * FROM m_Logtree_t WHERE Ttext=N'" & txtLineCode.Text.Trim & "'")

            '新增权限
            If mRead1.Rows.Count = 0 Then
                Dim mRead As DataTable = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent LIKE 'z09_%'")

                If mRead.Rows.Count > 0 Then
                    TreeCount = Convert.ToInt16(mRead.Rows(0)!countTreeid) + 1
                Else
                    TreeCount = "1"
                End If

                TreeId = "zK2" + TreeCount.PadLeft(3, "0")
                Tkey = "zK2" + TreeCount.PadLeft(3, "0") + "_"

                DbOperateUtils.ExecSQL("INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, " &
                                       " TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','z09_',N'" & Me.txtLineCode.Text.Trim() & "',N'" &
                                       Me.txtLineCode.Text.Trim() & "',null,'mes00','Line','" & Me.txtLineCode.Text.Trim & "','4','4','2','3','Y',null,'N')")
            End If

        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(" ", "Y")

            txtLineJM.Text = ""
            txtLineJM.Text = ""
            txtLineCode.Text = ""
            cbbFactory.Text = ""
            opflag = 0
            ToolbtnState(0)
            dgvRstation.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmDeptLine", "tsbSave_Click", "sys")
        End Try
    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtLineJM.Text = ""
        txtLineJM.Text = ""
        txtLineCode.Text = ""
        'TxtFAX.Text = ""
        cbbFactory.Text = ""
        'TxtLinkman.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

        Dim SqlStr As String =
            "select deptid '部门',lineid '线别',linejm '线别简码',factoryid '厂区',usey '是否可用'," &
            "( SELECT  LEFT(PartSeriesTypeNameList,LEN(PartSeriesTypeNameList)-1) as  PartSeriesTypeNameList  " &
            "  FROM ( SELECT LINEID, ( SELECT PartSeriesTypeName + ',' FROM m_LineSericesType_t " &
            "  WHERE LINEID = A.LINEID FOR XML PATH('')) AS PartSeriesTypeNameList " &
            "  FROM m_LineSericesType_t A WHERE lineid = deptline_t.lineid GROUP BY LINEID) AS B ) '料件序列'" &
            "  from deptline_t where usey='" & cheUsy & "' "

        If (Not String.IsNullOrEmpty(Me.cbbFactory.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptline_t.factoryid='" & Me.cbbFactory.Text.Trim.Split("-")(0) & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.cbbDept.Text.Trim)) Then
            SqlStr = SqlStr & " AND deptline_t.deptid='" & Me.cbbDept.Text.Trim.Split("-")(0) & "' "
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub

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

            Dim DrrR As DataRow() = dtUploadData.Select("DeptId  IS NOT NULL and LineID IS NOT NULL") '防止追加

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

    '导入格式
    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "部门线别资料维护导入模板")
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

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

        'DB部门
        Dim deptNameSQL As String = " select distinct deptid,dqc,Factoryid,Profitcenter from m_Dept_t  where 1= 1  "
        Dim deptNameDT As DataTable = DbOperateUtils.GetDataTable(deptNameSQL)

        'DB不良现象大类别
        Dim codeNameSQL As String = " select distinct deptid,lineid,Factoryid from deptline_t where 1= 1 "
        Dim codeNameDT As DataTable = DbOperateUtils.GetDataTable(codeNameSQL)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""

        For index As Integer = 0 To DrrR.Length - 1

            '部门
            Dim DeptID As String = DrrR(index)("DeptID").ToString.Trim
            '线别
            Dim LineID As String = DrrR(index)("LineID").ToString.Trim

            If hastable.Contains(DeptID + ":" + LineID) Then
                MessageUtils.ShowError(String.Format("上传文件中[部门ID+线别ID]'{0}'+'{1}'有重复,请检查后重新上传。", DeptID, LineID))
                Return False
            End If

            Dim returnCode As String = ""

            '部门ID
            If DeptID <> "" Then
                If CheckExistUserColumns(deptNameDT, "DeptID", DeptID, returnCode) = False Then
                    MessageUtils.ShowError("上传[部门ID]在部门资料库中不存在：'" + DeptID + "',请先增加部门资料")
                    Return False
                End If
            End If

            '部门ID和线别ID
            If DeptID <> "" And LineID <> "" Then
                Dim dr() As DataRow = codeNameDT.Select(String.Format("{0} = '{1}' and {2} = '{3}'", "DeptID", DeptID, "LineID", LineID))
                If dr.Length > 0 Then
                    returnCode = dr(0).ItemArray(0).ToString
                    MessageUtils.ShowError(String.Format("上传[部门+线别]在资料库中存在：'{0}+{1}'", DeptID, LineID))
                    Return False
                End If
            Else
                MessageUtils.ShowError("[部门ID+线别ID]有空值,请检查后重新上传。")
                Return False
            End If

            '厂区
            Dim Factoryid As String = DrrR(index)("Factoryid").ToString.Trim
            If Factoryid = "" Then
                MessageUtils.ShowError("[厂区]有空值,请检查后重新上传。")
                Return False
            End If

            hastable.Add(DeptID + ":" + LineID, DeptID + ":" + LineID)
        Next

        Return True
    End Function

    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim TreeCount As String = ""
        Dim TreeId As String
        Dim Tkey As String
        Dim Enname As String

        Dim mRead As DataTable = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent LIKE 'z09_%'")

        If mRead.Rows.Count > 0 Then
            TreeCount = Convert.ToInt16(mRead.Rows(0)!countTreeid) + 1
        Else
            TreeCount = "1"
        End If


        Dim strSQL As String = "insert into deptline_t(deptid, lineid, linejm,factoryid,usey,userid,intime) values('{0}',N'{1}',N'{2}',N'{3}','Y','{4}',getdate())"
        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), UseId)
            strInsertSQL.AppendLine()

            TreeCount += 1
            TreeId = "zK2" + TreeCount.PadLeft(3, "0")
            Tkey = "zK2" + TreeCount.PadLeft(3, "0") + "_"

            Enname = row(1).ToString()

            '新增权限
            '新增权限
            strInsertSQL.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','z09_',N'" & Enname & "',N'" & Enname & "',null,'mes00','Line','" & Enname & "','4','4','2','3','Y',null,'N')")
        Next

        Return strInsertSQL.ToString
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

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
        LoadDataToDatagridview(" ", cheUsy)
    End Sub

    Private Sub cbbFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbFactory.SelectedIndexChanged
        cbbDept.Items.Clear()
        Dim Mread As DataTable = DbOperateUtils.GetDataTable("select deptid,dqc  from m_Dept_t where Factoryid='" & cbbFactory.Text.Split("-")(0) & "'")
        If Mread.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To Mread.Rows.Count - 1
                cbbDept.Items.Add(Mread.Rows(rowIndex)!deptid & "-" & Mread.Rows(rowIndex)!dqc)
            Next
        End If
    End Sub

    Private Sub toolType_Click(sender As Object, e As EventArgs) Handles toolType.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")

            'Id/StationNo/StationName
            Using frm As New FrmLineSeriesType(dgvRstation.Item(0, dgvRstation.CurrentRow.Index).Value.ToString(), dgvRstation.Item(1, dgvRstation.CurrentRow.Index).Value.ToString(),
                                                           isAdd, isDelete)
                frm.ShowDialog()
            End Using
            Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
            LoadDataToDatagridview(" ", cheUsy)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class