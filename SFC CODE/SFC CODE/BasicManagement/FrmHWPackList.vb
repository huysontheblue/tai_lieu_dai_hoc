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

Public Class FrmHWPackList

#Region "公共变量定义"

    Public opflag As Int16 = 0
    Public frmRstationid As String = ""
    Public frmRstationname As String = ""
    Public frmStationtype As String = ""

    Private Enum CDImportGrid
        PackID
        PartID
        Qty
    End Enum

#End Region

#Region "处理按键事件"

    Private Sub FrmHWPackList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab 舱龄 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38
            Case 39
            Case 40
            Case 27 'Esc
                Me.Close()
        End Select
    End Sub

    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Erightbutton() '
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvPackList.Enabled = True
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
                Me.txtQty.Enabled = False
                Me.txtPackID.Enabled = False
                Me.txtPartID.Enabled = False
                ' Me.dgvPackList.Enabled = False

                Me.ActiveControl = Me.txtPackID
            Case 1, 2  '1, 2.Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtQty.Enabled = True
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
                Me.txtQty.Enabled = False
                Me.txtPartID.Enabled = True
                Me.txtPartID.Enabled = True
                Me.dgvPackList.Enabled = True

                Me.ActiveControl = Me.txtPartID
        End Select
    End Sub

#End Region


    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""
        Try
            'dgvPackList.Rows.Clear()
            SqlStr = " SELECT [PackID],[PartID],[Qty],(a.UserID+'/'+b.UserName)UserID,a.Intime ," & _
                     "   Case [State] When  0 THEN  N'0.未检查' WHEN 1 THEN N'1.检查中' WHEN 2 THEN N'2.检验完成' END State , ScanQty " & _
                     " FROM m_HWPackList_t a Left join m_users_t  b on a.userid = b.userid  WHERE 1=1 "
            '  Dreader = Conn.GetDataReader(SqlStr & SqlWhere)

            'Do While Dreader.Read()
            '    dgvPackList.Rows.Add(
            '                         Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            '                         Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString, _
            '                         Dreader.Item(6).ToString
            '                         )
            'Loop
            'Dreader.Close()
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    dgvPackList.DataSource = o_dt
                End If
            End Using

            toolStripStatusLabel3.Text = Me.dgvPackList.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackList", "LoadDataToDatagridview", "BasicM")
        End Try
    End Sub



#Region ""
    '
    Private Sub dgvPackList_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvPackList.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '
    Private Sub dgvPackList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPackList.CellDoubleClick
        '  tsbCheck_Click(sender, e)
        ' Call bindCheckListLog()

        If IsNothing(Me.dgvPackList.CurrentRow) Then Exit Sub

        Dim o_strPackID As String = String.Empty
        o_strPackID = Me.dgvPackList.CurrentRow.Cells(0).Value.ToString
        If String.IsNullOrEmpty(o_strPackID) Then Exit Sub
        Using o_FrmPNList As FrmHWPackCheckLog = New FrmHWPackCheckLog(o_strPackID)
            o_FrmPNList.ShowDialog()
        End Using

    End Sub

  

    Private Function Checkdata() As Boolean
        If Me.txtPackID.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.txtPackID
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

        txtPackID.Text = ""
        txtQty.Text = ""
        txtPartID.Text = ""
        opflag = 1
        ToolbtnState(1)
        txtPackID.Enabled = True
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvPackList.Rows.Count = 0 OrElse Me.dgvPackList.CurrentRow Is Nothing Then Exit Sub
        txtPackID.Text = dgvPackList.CurrentRow.Cells("PackID").Value
        txtPartID.Text = dgvPackList.CurrentRow.Cells("PartID").Value
        txtQty.Text = dgvPackList.CurrentRow.Cells("Qty").Value

        opflag = 2
        ToolbtnState(2)
    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.dgvPackList.Rows.Count = 0 OrElse Me.dgvPackList.CurrentRow Is Nothing Then Exit Sub

        Try
            Conn.ExecSql("UPDATE m_HWPackList_t set usey='0' where packid = '" & dgvPackList.CurrentRow.Cells("PackID").Value & "'")

            LoadDataToDatagridview(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackList", "tsbAbandon_Click", "BasicM")
        End Try

    End Sub
    '
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = ""

        If Checkdata() = False Then Exit Sub

        If opflag = 1 Then

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT PartID FROM m_HWPackList_t WHERE PackID='" & Me.txtPackID.Text.Trim() & "'")
            If mCheckCodeRead.HasRows Then
                mCheckCodeRead.Close()
                MessageBox.Show("该箱名已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            SqlStr.Append(ControlChars.CrLf & "INSERT into m_HWPackList_t([PackID],[PartID] ,[Qty] ,[UserID],[Intime],")
            SqlStr.Append("[ScanQty],[State],[FactoryID],[profitcenter],useY) ")
            SqlStr.Append(" VALUES('" & txtPackID.Text & "',N'" & txtPartID.Text.Trim & "','" & Me.txtQty.Text.Trim & "',  '" & VbCommClass.VbCommClass.UseId & "',getdate(), 0, 0, ")
            SqlStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "',1 )")

        ElseIf opflag = 2 Then
            SqlStr.Append(" UPDATE m_HWPackList_t SET PartID =N'" & txtPartID.Text.Trim & "',Qty =N'" & txtQty.Text.Trim & "' ")
            SqlStr.Append(" WHERE PackID = '" & txtPackID.Text.Trim & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" ")

            txtPartID.Text = ""
            txtPartID.Text = ""
            txtQty.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackList", "tsbSave_Click", "BasicM")
            Exit Sub
        End Try
    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtPackID.Text = ""
        txtPartID.Text = ""
        txtQty.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub

    '
    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.CurrentRow.Cells("ColUsey").Value <> "Y" Then
        '    MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        '  LoadDataToDatagridview(" ")

        ToolbtnState(1)
        Me.txtPackID.Enabled = True
    End Sub


#Region "汇入汇出操作"
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

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 3, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PackID IS NOT NULL ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("UserID", "System.String", dtUploadData)
            TableAddColumns("Intime", "System.String", dtUploadData)
            TableAddColumns("ScanQty", "System.String", dtUploadData)
            TableAddColumns("State", "System.String", dtUploadData)
            TableAddColumns("FactoryID", "System.String", dtUploadData)
            TableAddColumns("profitcenter", "System.String", dtUploadData)
            TableAddColumns("UseY", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New Dictionary(Of String, String)
            dics2.Add("PackID", "PackID")
            dics2.Add("PartID", "PartID")
            dics2.Add("Qty", "Qty")
            dics2.Add("UserID", "UserID")
            dics2.Add("Intime", "Intime")
            dics2.Add("ScanQty", "ScanQty")
            dics2.Add("State", "State")
            dics2.Add("FactoryID", "FactoryID")
            dics2.Add("profitcenter", "profitcenter")
            dics2.Add("UseY", "UseY")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    usercopy.Rows.Add(
                           row(0).ToString(), row(1).ToString(), row(2).ToString(), VbCommClass.VbCommClass.UseId, _
                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), 0, 0, VbCommClass.VbCommClass.Factory, _
                           VbCommClass.VbCommClass.profitcenter, "1")
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_HWPackList_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    '  SearchRecord("")
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmHWPackList", "toolImport_Click", "BasicM")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub


    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB中设备料号
        Dim strSQL As String = " SELECT PackID FROM m_HWPackList_t WHERE 1=1 "
        Dim dtPackID As DataTable = DbOperateUtils.GetDataTable(strSQL)

        'Dim strSQL2 As String = " select (CODE +'('+NAME+')') CODE,NAME from m_EquipmentCategory_t where Status=1 AND TYPE = 'MID' "
        'Dim dtPNDes As DataTable = DbOperateUtils.GetDataTable(strSQL2)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1
            Dim returnCode As String = ""
            Dim PackID As String = DrrR(index)(CDImportGrid.PackID.ToString).ToString.Trim
            Dim values As String = PackID
            If hastable.Contains(values) Then
                MessageUtils.ShowError(String.Format("上传文件中有重复的箱名{0}", PackID))
                Return False
            Else
                hastable.Add(values, values)
            End If

            If PackID <> "" Then
                If CheckExistUserColumns(dtPackID, "PackID", PackID, "") = True Then
                    MessageUtils.ShowError("数据库中箱名有重复数据：'" + PackID + "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("有空值,请检查后重新上传。")
                Return False
            End If
        Next

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
        If Me.txtPackID.Text <> "" Then
            SqlStr = " AND PackID like '%" & Trim(txtPackID.Text) & "%'"
        End If
        If Me.txtPartID.Text <> "" Then
            SqlStr = " AND  PartID like '%" & Trim(txtPartID.Text) & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)





    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Me.dgvPackList.Rows.Count > 0 Then
            ExcelUtils.LoadDataToExcel(Me.dgvPackList, Me.Text)
        End If
    End Sub
End Class