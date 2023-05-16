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
Imports Aspose.Cells

#End Region

Public Class FrmNCode

#Region "定义"

    Public opflag As Int16 = 0
    Dim lastindex As Int16 = -1

    Private Enum CDImportGrid
        CodeID
        CCName
        CEName
        CsortName
        Station
    End Enum
#End Region


#Region "KEYDOWN"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")
            Case 13
                SendKeys.Send("{Tab}")
            Case 27
                Me.Close()
        End Select
    End Sub

    '初期化
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   
        BMComDB.BindComboxNGCategory(cboNGXXType)
        BMComDB.BindComboxNGStation(cmbNgStationId)
        LoadDataToDatagridview("")
        Erightbutton()
        ToolbtnState(opflag)
    End Sub

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
    End Sub

    '不同状态处理
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 ' 初期化
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False
                'GroupBox
                Me.cboNGXXType.Enabled = True
                Me.txtNGXXENName.Enabled = False
                Me.txtNGXXCode.Enabled = True
                Me.txtNGXXName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtNGXXCode
            Case 1, 2 '新增，编辑
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtNGXXENName.Enabled = True
                Me.txtNGXXName.Enabled = True
                Me.cboNGXXType.Enabled = IIf(opflag = 1, True, False)
                Me.txtNGXXCode.Enabled = True
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cboNGXXType, Me.txtNGXXName)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                Me.cboNGXXType.Enabled = True
                Me.txtNGXXENName.Enabled = False
                Me.txtNGXXCode.Enabled = True
                Me.txtNGXXName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtNGXXCode
        End Select
    End Sub

#End Region


#Region "事件处理"

    '新增处理
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        txtNGXXName.Text = ""
        txtNGXXENName.Text = ""
        txtNGXXCode.Text = ""
        cmbNgStationId.Text = ""
        ChkUsey.Checked = True
        opflag = 1
        ToolbtnState(1)
        cboNGXXType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    '编辑处理
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        txtNGXXCode.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtNGXXName.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtNGXXENName.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        cboNGXXType.Text = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "-" + dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        cmbNgStationId.Text = dgvRstation.Item(5, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "-" + dgvRstation.Item(6, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim

        Dim usey As String = dgvRstation.Item(7, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0).ToString
        If usey = "Y" Then
            ChkUsey.Checked = True
        Else
            ChkUsey.Checked = False
        End If
        ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(dgvRstation.Item(8, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)
        opflag = 2
        ToolbtnState(2)

        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        dgvRstation.Rows(dgvRstation.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = dgvRstation.CurrentRow.Index
        Me.txtNGXXCode.Enabled = False
        cboNGXXType.Enabled = True
    End Sub

    '作废处理
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            DbOperateUtils.ExecSQL("update m_Code_t set usey='N',intime=getdate() where CodeID = '" & Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            LoadDataToDatagridview(GetSqlWhere())
            MessageUtils.ShowInformation("作废成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbAbandon_Click", "sys")
            MessageUtils.ShowError("作废失败！")
        End Try
    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim usey As String = "N"
        If ChkUsey.Checked Then
            usey = "Y"
        End If
        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then
            SqlStr.Append(ControlChars.CrLf & "insert m_Code_t(CodeID, CCName, CsortName,EsortName,CEName, station, usey,  intime,userid) " _
                     & " values('" & txtNGXXCode.Text & "',N'" & txtNGXXName.Text.Trim & "',N'" & cboNGXXType.Text.ToString.Trim.Split("-")(1) & "',N'" & cboNGXXType.Text.ToString.Trim.Split("-")(0) & "'," _
                     & " N'" & txtNGXXENName.Text.Trim & "','" & cmbNgStationId.SelectedValue.ToString & "','" & usey & "',getdate(),'" & SysMessageClass.UseId & "') ")
        ElseIf opflag = 2 Then
            SqlStr.Append("update m_Code_t set CCName =N'" & txtNGXXName.Text.Trim & "',CsortName=N'" & cboNGXXType.Text.ToString.Trim.Split("-")(1) &
                          "',EsortName=N'" & cboNGXXType.Text.ToString.Trim.Split("-")(0) & "',CEName =N'" & txtNGXXENName.Text.Trim & "',usey='" & usey &
                          "', station = '" & cmbNgStationId.SelectedValue.ToString & "" &
                          "',intime=getdate(),userid='" & SysMessageClass.UseId & "',CLevel='" & ComboBox1.Text.ToString & "' where CodeID = '" & txtNGXXCode.Text.Trim & "' ")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(GetSqlWhere())

            cboNGXXType.SelectedIndex = -1
            txtNGXXCode.Text = ""
            txtNGXXName.Text = ""
            txtNGXXENName.Text = ""
            cmbNgStationId.Text = ""
            opflag = 0
            lastindex = -1 'dgvRstation.CurrentRow.Index
            ToolbtnState(0)
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub

    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        cboNGXXType.SelectedIndex = -1
        txtNGXXCode.Text = ""
        txtNGXXName.Text = ""
        txtNGXXENName.Text = ""
        cmbNgStationId.Text = ""
        opflag = 0
        ToolbtnState(0)
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview(GetSqlWhere())
    End Sub

    '退出 
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '维修方法代码
    Private Sub ToolNg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fr As FrmNMethodCode = New FrmNMethodCode
        fr.ShowDialog()
    End Sub

    '不良现象类别
    Private Sub cboNGXXType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNGXXType.SelectedIndexChanged
        '新增状态时
        If opflag = 1 Then
            If cboNGXXType.SelectedValue Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(cboNGXXType.SelectedValue.ToString) = False Then
                txtNGXXCode.Text = BMComDB.GetMAXCodeid(cboNGXXType.SelectedValue.ToString)
            End If
        End If
    End Sub

#End Region


#Region "方法"
    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""

        SqlStr = "select CodeID ,CCName,CEName,EsortName,CsortName, " _
              & " station , (select Stationname from m_Rstation_t b where a.station = b.Stationid) Stationname, " _
              & " case a.usey when 'Y' then N'Y-有效' when 'N' then N'N-作废' end as Usey,CLevel,convert(varchar(19),a.intime,21) as intime  " _
              & " from m_Code_t a  where 1=1 " _
              & "  " & SqlWhere
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        dgvRstation.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            dgvRstation.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString,
            dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString, dt.Rows(i).Item(5).ToString, dt.Rows(i).Item(6).ToString,
            dt.Rows(i).Item(7).ToString, dt.Rows(i).Item(8).ToString, dt.Rows(i).Item(9).ToString)
        Next

        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
    End Sub

    '检查数据
    Private Function Checkdata() As Boolean
        If Me.cboNGXXType.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因类别不能为空!")
            Me.ActiveControl = Me.cboNGXXType
            Return False
        End If

        If Me.txtNGXXCode.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因代码不能为空!")
            Me.ActiveControl = Me.txtNGXXCode
            Return False
        End If
        If Me.txtNGXXName.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因名称不能为空!")
            Me.ActiveControl = Me.txtNGXXName
            Return False
        End If
        If opflag = 1 Then
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select CodeID from m_Code_t where CodeID='" & txtNGXXCode.Text & "'")
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("已经存在该不良原因代码!")
                Me.ActiveControl = Me.cboNGXXType
                Return False
            End If
        End If

        Return True
    End Function

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If Me.cboNGXXType.Text.Trim <> "" Then
            Sql = Sql & " and EsortName='" & Me.cboNGXXType.Text.Trim.Split("-")(0) & "' "
        End If
        If Me.txtNGXXCode.Text.Trim <> "" Then
            Sql = Sql & " and CodeID like '%" & Me.txtNGXXCode.Text.Trim & "%' "
        End If
        If Me.txtNGXXName.Text.Trim <> "" Then
            Sql = Sql & " and CCName like N'%" & Me.txtNGXXName.Text.Trim & "%' "
        End If
        Return Sql
    End Function

#End Region


    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        LoadDataToExcel1(dgvRstation, "NGCode")
    End Sub

    Private Sub LoadDataToExcel1(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try
            Dim strpath As String = ""
            If DgMoData.RowCount = 0 Then
                MessageUtils.ShowError("请确认需导出的数据资料！")
                Exit Sub
            End If
            Dim wb = New Aspose.Cells.Workbook()

            Dim style = wb.Styles(wb.Styles.Add())
            style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0)
            style.Pattern = BackgroundType.Solid
            style.Font.IsBold = True


            Dim getTable As New DataTable
            getTable.TableName = "不良基础数据"

            Dim index As Int32
            Dim inde As Int32
            For index = 0 To DgMoData.ColumnCount - 1
                getTable.Columns.Add("" & index & "")
            Next

            For index = 0 To DgMoData.Rows.Count - 1
                getTable.Rows.Add()
                For inde = 0 To DgMoData.ColumnCount - 1
                    getTable.Rows(index)(inde) = DgMoData.Rows(index).Cells(inde).Value
                Next
            Next
            'getTable = DgMoData.DataSource
            'strpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            'Environment.SpecialFolder.Desktop()
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If
            strpath = "c:\MesExport"
            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                Dim columnName As String = DgMoData.Columns(comIndex).HeaderText
                wb.Worksheets(0).Cells(0, comIndex).PutValue(columnName)
                wb.Worksheets(0).Cells(0, comIndex).SetStyle(style)
                wb.Worksheets(0).AutoFitColumn(comIndex, 0, 150)
            Next
            nColqty = 1
            For Each r As DataRow In getTable.Rows
                For comIndex As Integer = 0 To getTable.Columns.Count - 1
                    wb.Worksheets(0).Cells(nColqty, comIndex).PutValue(r(comIndex).ToString())
                Next
                nColqty = nColqty + 1
            Next
            wb.Worksheets(0).Name = "不良基础数据"
            wb.Worksheets(0).FreezePanes(1, 0, 1, getTable.Columns.Count)
            Dim filepath As String = strpath + "\" + tbname + ".xls"
            wb.Save(filepath)
            MessageUtils.ShowInformation("文件导出成功,导出位置：" + filepath + "!")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

End Class