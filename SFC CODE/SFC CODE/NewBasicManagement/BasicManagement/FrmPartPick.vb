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

Public Class FrmPartPick

#Region "公共变量定义"

    Public opflag As Int16 = 0
    Public frmRstationid As String = ""
    Public frmRstationname As String = ""
    Public frmStationtype As String = ""

    Private Enum CDImportGrid
        StationLocSeq
        PartID
        AltPartID
        Feeder
        Qty
        FormatDes
        Position
        Remark  '// 以上为excel的上传所有列
        ProjectName
        Ver
    End Enum

    ' 站位	物料料号	FEEDER	用量	规格描述	位置	备注

#End Region

#Region "处理按键事件"

    Private Sub FrmPartPick_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38
            Case 39
            Case 40
            Case 27 'Esc
                '  Me.Close()
        End Select
    End Sub

    Private Sub FrmPartPick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Erightbutton() '
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvPickList.Enabled = True
    End Sub
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass

        Dim Reader As SqlDataReader = Conn.GetDataReader("select Factoryid,Shortname from m_Dcompany_t where Usey='Y'")
        If Reader.HasRows Then
            While Reader.Read
                ' cbbFactory.Items.Add(Reader!Factoryid & "-" & Reader!Shortname)
            End While
        End If
        Reader.Close()

    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 'default
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False

                'GroupBox
                ' Me.txtQty.Enabled = False
                Me.txtProjectName.Enabled = False
                Me.txtPartID.Enabled = False

                Me.ActiveControl = Me.txtProjectName
            Case 1, 2  '1, 2.Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtPartID.Enabled = True
                'Me.txtStationName.Enabled = False
                ' Me.dgvPackList.Enabled = False
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                'Me.txtQty.Enabled = False
                Me.txtPartID.Enabled = True
                Me.txtPartID.Enabled = True
                Me.dgvPickList.Enabled = True

                Me.ActiveControl = Me.txtPartID
        End Select
    End Sub

#End Region


    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""
        Try
            dgvPickList.Rows.Clear()
            SqlStr = " SELECT StationLocSeq,[PartID],a.AltPartID,Feeder,[Qty], FormatDes,Position,remark,ProjectName,Ver,(a.UserID+'/'+b.UserName)UserID,a.Intime " & _
                     " FROM m_PartPickList_t a LEFT JOIN m_users_t  b on a.userid = b.userid  WHERE 1=1 "
            Dreader = Conn.GetDataReader(SqlStr & SqlWhere + " ORDER BY cast(Seq as int)")
            Do While Dreader.Read()
                dgvPickList.Rows.Add(
                                     Dreader.Item("StationLocSeq").ToString, Dreader.Item("PartID").ToString, Dreader.Item("AltPartID").ToString, Dreader.Item("Feeder").ToString, _
                                     Dreader.Item("Qty").ToString, Dreader.Item("FormatDes").ToString, Dreader.Item("Position").ToString, _
                                     Dreader.Item("remark").ToString, Dreader.Item("ProjectName").ToString, Dreader.Item("Ver").ToString, _
                                     Dreader.Item("UserID").ToString, Dreader.Item("Intime").ToString
                                     )
            Loop
            Dreader.Close()
            toolStripStatusLabel3.Text = Me.dgvPickList.Rows.Count
            Conn = Nothing
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartPick", "LoadDataToDatagridview", "BasicM")
        End Try
    End Sub



#Region ""
    '
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvPickList.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '
    Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickList.CellDoubleClick
        ' tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtProjectName.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.txtProjectName
            Return False
        End If
        If Me.txtPartID.Text.Trim = "" Then
            LblMsg.Text = "部门名称不能为空..."
            Me.ActiveControl = Me.txtPartID
            Return False
        End If
        Return True
    End Function

#End Region

#Region "New Add/Modify"
    'New Add
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtProjectName.Text = ""
        txtPartID.Text = ""
        opflag = 1
        ToolbtnState(1)
        txtProjectName.Enabled = True
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvPickList.Rows.Count = 0 OrElse Me.dgvPickList.CurrentRow Is Nothing Then Exit Sub
        txtProjectName.Text = dgvPickList.CurrentRow.Cells("ProjectName").Value
        txtPartID.Text = dgvPickList.CurrentRow.Cells("PartID").Value

        opflag = 2
        ToolbtnState(2)
    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        ' Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.dgvPickList.Rows.Count = 0 OrElse Me.dgvPickList.CurrentRow Is Nothing Then Exit Sub
        Dim lssql As String = String.Empty
        Try
            lssql = " UPDATE m_PartPickList_t set usey='0' where packid = '" & dgvPickList.CurrentRow.Cells("PackID").Value & "'"
            DbOperateUtils.ExecSQL(lssql)
            ' Conn.ExecSql("UPDATE m_PartPickList_t set usey='0' where packid = '" & dgvPickList.CurrentRow.Cells("PackID").Value & "'")

            LoadDataToDatagridview(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartPick", "tsbAbandon_Click", "BasicM")
        End Try

    End Sub
    '
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = ""

        If Checkdata() = False Then Exit Sub

        If opflag = 1 Then

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT PartID FROM m_PartPickList_t WHERE ProjectName='" & Me.txtProjectName.Text.Trim() & "'")
            If mCheckCodeRead.HasRows Then
                mCheckCodeRead.Close()
                MessageBox.Show("该程序名称已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            SqlStr.Append(ControlChars.CrLf & "INSERT into m_PartPickList_t(PackID,[PartID] ,[Qty] ,[UserID],[Intime],")
            SqlStr.Append("[ScanQty],[State],[FactoryID],[profitcenter],useY) ")
            SqlStr.Append(" VALUES('" & txtProjectName.Text & "',N'" & txtPartID.Text.Trim & "','1',  '" & VbCommClass.VbCommClass.UseId & "',getdate(), 0, 0, ")
            SqlStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "',1 )")

        ElseIf opflag = 2 Then
            SqlStr.Append(" UPDATE m_PartPickList_t SET PartID =N'" & txtPartID.Text.Trim & "',Qty =N'1' ")
            SqlStr.Append(" WHERE ProjectName = '" & txtProjectName.Text.Trim & "'")
        End If

        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" ")

            txtPartID.Text = ""
            txtPartID.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartPick", "tsbSave_Click", "BasicM")
            Exit Sub
        Finally
            Conn = Nothing
        End Try
    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtProjectName.Text = ""
        txtPartID.Text = ""
        ' txtQty.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub

    '退出程序
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        '  LoadDataToDatagridview(" ")
        ToolbtnState(1)
        Me.txtProjectName.Enabled = True
    End Sub


#Region "汇入汇出操作"
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try

            Dim sdfimport As New OpenFileDialog
            Dim o_strSQL As New StringBuilder
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            Dim o_strProjectName As String = "", o_strProjectName2 As String = "", o_strVer As String = ""
            filename = sdfimport.FileName
            Dim table2 As DataTable = Nothing, table3 As DataTable = Nothing

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 10, errorMsg)

            dtUploadData.Rows.RemoveAt(0)
            ChangeCDDataTableColumnName(dtUploadData)

            dtUploadData.Columns.Add("Seq", GetType(Integer))

            For i As Integer = 0 To dtUploadData.Rows.Count - 1
                dtUploadData.Rows(i)("Seq") = i
            Next

            dtUploadData = BMComDB.GetNewDataTable(dtUploadData, " StationLocSeq is not null", "Seq")

            o_strVer = dtUploadData.Rows(0).Item(6)

            o_strProjectName = IIf(dtUploadData.Rows(2).Item(3).ToString = "", dtUploadData.Rows(2).Item(2).ToString, dtUploadData.Rows(2).Item(3).ToString)
            o_strProjectName = Replace(Replace(o_strProjectName, "前段", "BEFORE"), "后段", "AFTER")

            If dtUploadData.Select(" StationLocSeq ='程序名称'").Length > 1 Then
                table2 = dtUploadData.Clone() '复制table的结构(table.copy() 为复制结构与数据）
                table3 = dtUploadData.Clone()
                Dim i As Integer = 0
                For i = 4 To dtUploadData.Rows.Count - 1
                    If dtUploadData.Rows(i).Item(0) <> "程序名称" Then
                        table2.NewRow()
                        table2.ImportRow(dtUploadData.Rows(i)) '复制row到table2中
                    Else
                        o_strProjectName2 = IIf(dtUploadData.Rows(i).Item(3).ToString = "", dtUploadData.Rows(i).Item(2).ToString, dtUploadData.Rows(i).Item(3).ToString)
                        o_strProjectName2 = Replace(Replace(o_strProjectName2, "前段", "BEFORE"), "后段", "AFTER")
                        Exit For
                    End If
                Next

                For j As Integer = i To dtUploadData.Rows.Count - 2
                    If dtUploadData.Rows(j).Item(0) <> "程序名称" AndAlso dtUploadData.Rows(j).Item(0) <> "审核:" Then
                        table3.NewRow()
                        table3.ImportRow(dtUploadData.Rows(j)) '复制row到table2中
                    End If
                Next
            End If

            If Not IsNothing(table2) Then
                If Not ImportToTable(table2, o_strProjectName, o_strVer) Then
                    Exit Sub
                End If

                If table3.Rows.Count > 1 Then
                    table3.Rows.RemoveAt(0)
                End If

                If Not ImportToTable(table3, o_strProjectName2, o_strVer) Then
                    Exit Sub
                Else
                    MessageUtils.ShowInformation("成功导入！")
                End If

            Else

                Dim i As Integer = 0
                table2 = dtUploadData.Clone() '复制table的结构(table.copy() 为复制结构与数据）
                For i = 4 To dtUploadData.Rows.Count - 1
                    If (Not IsDBNull(dtUploadData.Rows(i).Item(0))) AndAlso dtUploadData.Rows(i).Item(0) <> "程序名称" AndAlso dtUploadData.Rows(i).Item(0) <> "审核:" Then
                        table2.NewRow()
                        table2.ImportRow(dtUploadData.Rows(i)) '复制row到table2中
                    Else
                        'do nothing
                    End If
                Next

                ImportToTable_Single(table2, o_strProjectName, o_strVer)

            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartPick", "toolImport_Click", "BasicM")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    Private Function ImportToTable(ByVal o_dtUploadData As DataTable, o_strProjectName As String, o_strVer As String) As Boolean
        Dim DrrR As DataRow() = o_dtUploadData.Select(" StationLocSeq IS NOT NULL ") '防止追加

        If CheckUploadData(DrrR, o_strProjectName, o_strVer) = False Then
            ' Exit Sub
            Return False
        End If

        '现在开始把数据保存到DB中,先要转
        TableAddColumns("UserID", "System.String", o_dtUploadData)
        TableAddColumns("Intime", "System.String", o_dtUploadData)
        TableAddColumns("State", "System.String", o_dtUploadData)
        TableAddColumns("FactoryID", "System.String", o_dtUploadData)
        TableAddColumns("profitcenter", "System.String", o_dtUploadData)


        '批量插入到DB中
        '设备类型及料号要将string 转int
        Dim dics2 As New Dictionary(Of String, String)
        dics2.Add("StationLocSeq", "StationLocSeq")
        dics2.Add("PartID", "PartID")
        dics2.Add("AltPartID", "AltPartID")
        dics2.Add("Feeder", "Feeder")
        dics2.Add("Qty", "Qty")
        dics2.Add("FormatDes", "FormatDes")
        dics2.Add("Position", "Position")
        dics2.Add("remark", "remark")
        dics2.Add("ProjectName", "ProjectName")
        dics2.Add("Ver", "Ver")
        dics2.Add("Seq", "Seq")
        dics2.Add("UserID", "UserID")
        dics2.Add("Intime", "Intime")
        dics2.Add("State", "State")
        dics2.Add("FactoryID", "FactoryID")
        dics2.Add("profitcenter", "profitcenter")

        Dim usercopy As New DataTable
        usercopy = o_dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值
        For Each row As DataRow In DrrR
            If row(0).ToString <> "" Then
                usercopy.Rows.Add(row(0).ToString, _
                       row("PartID").ToString(), row("AltPartID").ToString, row("FEEDER").ToString, _
                       row("Qty").ToString(), row("FormatDes").ToString(), row("Position").ToString(), row("remark").ToString, o_strProjectName, o_strVer, row("Seq").ToString, VbCommClass.VbCommClass.UseId, _
                       DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), 0, VbCommClass.VbCommClass.Factory, _
                       VbCommClass.VbCommClass.profitcenter)
            End If
        Next

        Dim errMsg As String = String.Empty

        If DbOperateUtils.BulkCopy(usercopy, "m_PartPickList_t", dics2, errMsg) = True Then
            If errMsg <> String.Empty Then
                MessageUtils.ShowInformation(errMsg)
                Return False
            Else
                '   MessageUtils.ShowInformation("成功导入！")
                Return True
            End If
        End If
    End Function

    Private Sub ImportToTable_Single(ByVal dtUploadData As DataTable, o_strProjectName As String, o_strVer As String)
        Dim DrrR As DataRow() = dtUploadData.Select(" StationLocSeq IS NOT NULL ") '防止追加

        If CheckUploadData(DrrR, o_strProjectName, o_strVer) = False Then
            Exit Sub
        End If

        '现在开始把数据保存到DB中,先要转
        TableAddColumns("UserID", "System.String", dtUploadData)
        TableAddColumns("Intime", "System.String", dtUploadData)
        TableAddColumns("State", "System.String", dtUploadData)
        TableAddColumns("FactoryID", "System.String", dtUploadData)
        TableAddColumns("profitcenter", "System.String", dtUploadData)

        '批量插入到DB中
        '设备类型及料号要将string 转int
        Dim dics2 As New Dictionary(Of String, String)
        dics2.Add("StationLocSeq", "StationLocSeq")
        dics2.Add("PartID", "PartID")
        dics2.Add("AltPartID", "AltPartID")
        dics2.Add("Feeder", "Feeder")
        dics2.Add("Qty", "Qty")
        dics2.Add("FormatDes", "FormatDes")
        dics2.Add("Position", "Position")
        dics2.Add("remark", "remark")
        dics2.Add("ProjectName", "ProjectName")
        dics2.Add("Ver", "Ver")
        dics2.Add("Seq", "Seq")
        '===========  分隔线， 以下为新添加的列 ==============
        dics2.Add("UserID", "UserID")
        dics2.Add("Intime", "Intime")
        dics2.Add("State", "State")
        dics2.Add("FactoryID", "FactoryID")
        dics2.Add("profitcenter", "profitcenter")


        Dim usercopy As New DataTable
        usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

        For Each row As DataRow In DrrR
            If row(0).ToString <> "" Then
                usercopy.Rows.Add(
                       row(0).ToString, _
                       row("PartID").ToString(), row("AltPartID").ToString(), row("FEEDER").ToString, row("Qty").ToString(), row("FormatDes").ToString(), row("Position").ToString(), row("remark").ToString, o_strProjectName, o_strVer, row("Seq").ToString, VbCommClass.VbCommClass.UseId, _
                       DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), 0, VbCommClass.VbCommClass.Factory, _
                       VbCommClass.VbCommClass.profitcenter
                       )
            End If
        Next

        Dim errMsg As String = String.Empty

        If DbOperateUtils.BulkCopy(usercopy, "m_PartPickList_t", dics2, errMsg) = True Then
            If errMsg <> String.Empty Then
                MessageUtils.ShowInformation(errMsg)
            Else
                MessageUtils.ShowInformation("成功导入！")
            End If
        End If
    End Sub


    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Function CheckUploadData(DrrR As DataRow(), o_strProjectName As String, o_strVer As String) As Boolean
        'DB中设备料号
        Dim strSQL As String = " SELECT TOP 1 PartID FROM m_PartPickList_t WHERE 1=1 AND ProjectName=N'" & o_strProjectName & "' AND Ver='" & o_strVer & "'"
        Using o_dtPartID As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dtPartID) AndAlso o_dtPartID.Rows.Count > 0 Then
                MessageUtils.ShowError(String.Format("已经上传了该文件,程序名称:{0}", o_strProjectName))
                Return False
            End If
        End Using


        'For index As Integer = 0 To DrrR.Length - 1
        '    Dim returnCode As String = ""
        '    Dim PackID As String = DrrR(index)(CDImportGrid.StationLocSeq.ToString).ToString.Trim
        '    Dim values As String = PackID
        '    If hastable.Contains(values) Then
        '        MessageUtils.ShowError(String.Format("上传文件中有重复的料号{0}", PackID))
        '        Return False
        '    Else
        '        hastable.Add(values, values)
        '    End If

        '    'If PackID <> "" Then
        '    '    If CheckExistUserColumns(dtPackID, "PackID", PackID, "") = True Then
        '    '        MessageUtils.ShowError("数据库中箱名有重复数据：'" + PackID + "'")
        '    '        Return False
        '    '    End If
        '    'Else
        '    '    MessageUtils.ShowError("有空值,请检查后重新上传。")
        '    '    Return False
        '    'End If
        'Next

        Return True
    End Function

    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

#End Region


    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles FileRefresh.Click

        Dim SqlStr As String = ""
        If Me.txtProjectName.Text <> "" Then
            SqlStr = " AND ProjectName LIKE N'%" & Trim(txtProjectName.Text) & "%'"
        End If

        If Me.txtPartID.Text <> "" Then
            SqlStr = " AND  PartID LIKE '%" & Trim(txtPartID.Text) & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
    End Sub
End Class