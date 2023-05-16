Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

#Region "Old"
'Public Class FrmMoMain

'    Const GridColZero As Integer = 1
'    Const GridColOne As Integer = 0
'    Dim ComBoxFlag As Boolean
'    Public Enum ActionType
'        SaveBatch = 0
'        CancelBatch
'        PrintMo
'    End Enum

'#Region "酶datagridview虫じ,匡い埃礘翴"

'    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

'        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

'    End Sub

'#End Region

'    Private Sub FrmMoMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

'        Dim TabTrans As New TextHandle
'        TabTrans.TabTransEnter(sender, e)
'        TabTrans = Nothing

'    End Sub

'    Private Sub FrmMoMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            CheckUserRight()
'            SetBatchControls(0)
'            FillComboLine(CboMoType)
'            FillComboLine(CboConsumer)
'            FillComboLine(CboDept)
'            DtStarDate.Value = DateAdd(DateInterval.Day, -1, Now())
'            DtEndDate.Value = Now()
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Private Function CheckUserRight() As Boolean
'        Dim PubClass As New SysDataBaseClass
'        Dim CheckRead As SqlDataReader = PubClass.GetDataReader("select distinct a.* from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m0510f_' and a.userid='" & SysMessageClass.UseId & "'")
'        If Not CheckRead.Read Then
'            ToolQuery.Enabled = True
'            ToolHandle.Enabled = False
'            ToolReEnd.Enabled = False
'            ToolUhanlde.Enabled = False
'            StopFile.Enabled = False
'            ExitFrom.Enabled = True
'            ToolPrint.Enabled = False
'            ToolRePrint.Enabled = False
'            CheckUserRight = False
'        Else
'            ToolQuery.Enabled = True
'            ToolHandle.Enabled = True
'            ToolReEnd.Enabled = True
'            ToolUhanlde.Enabled = True
'            StopFile.Enabled = True
'            ToolPrint.Enabled = True
'            ToolRePrint.Enabled = True
'            CheckUserRight = True
'        End If
'        CheckRead.Close()
'        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m0640_' and a.userid='" & SysMessageClass.UseId & "'")
'        If Not CheckRead.Read Then
'            btnBatchMoSave.Enabled = False
'            btnBatchMoCancel.Enabled = False
'        Else
'            btnBatchMoSave.Enabled = True
'            btnBatchMoCancel.Enabled = True
'        End If
'        PubClass.GetControlright(Me)
'        PubClass = Nothing
'        Return CheckUserRight
'    End Function

'    Private Sub TransDataGridLanguage()

'        Dim ColsText As String = "WO|P/N|Part Name|Customer code|Customer Name|PD|PD Name|Line type|WO  qty|PPID Count|PKG Count|WO type|WO status|Route|Maintainer|Maintain date"
'        Dim colNames As String() = ColsText.Split("|")
'        Dim i%
'        For i = 0 To DgMoData.Columns.Count - 1
'            DgMoData.Columns(i).HeaderText = colNames(i)
'        Next

'    End Sub

'    Private Sub FillComboLine(ByVal FillComBox As ComboBox)

'        Dim ScanClass As New SysDataBaseClass
'        'Dim ScanReader As SqlDataReader
'        ' ScanReader = Nothing
'        FillComBox.Items.Add("ALL")
'        If FillComBox.Name = "CboDept" Then
'            Using dt As DataTable = ScanClass.GetDataTable("Select  * from m_Dept_t where  listally='Y' and usey='Y' and dtype='R'")
'                For Each row As DataRow In dt.Rows
'                    FillComBox.Items.Add(row("deptid").ToString & "---" & row("dqc").ToString)
'                Next
'            End Using
'        ElseIf FillComBox.Name = "CboConsumer" Then
'            Using dt As DataTable = ScanClass.GetDataTable("Select  * from m_Customer_t")
'                For Each row As DataRow In dt.Rows
'                    FillComBox.Items.Add(row(0).ToString & "---" & row(1).ToString)
'                Next
'            End Using
'        ElseIf FillComBox.Name = "CboMoType" Then
'            Using dt As DataTable = ScanClass.GetDataTable("select * from motype_t")
'                For Each row As DataRow In dt.Rows
'                    FillComBox.Items.Add(row(0).ToString & "---" & row(1).ToString)
'                Next
'            End Using
'        End If
'        FillComBox.Text = FillComBox.Items.Item(0)
'    End Sub

'    Private Sub LoadDataInGrid(Optional ByVal FiterSqlStr As String = "")

'        Dim K As Integer
'        Dim UserDg As DataTable
'        Dim Sqlstr As String

'        DgMoData.Rows.Clear()
'        DgMoData.ScrollBars = ScrollBars.None

'        Sqlstr = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM M_MAINMO_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN M_CUSTOMER_T E ON A.CUSID=E.CUSID LEFT JOIN M_DEPT_T F ON A.DEPTID=F.DEPTID "
'        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
'        UserDg = DataHand.GetDataTable(Sqlstr & FiterSqlStr & " ORDER BY A.CREATETIME DESC ")

'        For K = 0 To UserDg.Rows.Count - 1
'            DgMoData.Rows.Add("false", UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"))
'        Next
'        DgMoData.Columns(0).ReadOnly = False
'        For idx As Integer = 1 To DgMoData.Columns.Count - 1
'            DgMoData.Columns(idx).ReadOnly = True
'        Next

'        DgMoData.ScrollBars = ScrollBars.Both
'        TlelCount.Text = UserDg.Rows.Count
'        DataHand = Nothing
'        UserDg.Dispose()
'        'DgMoData.AutoResizeColumns()
'        'DgMoData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells

'    End Sub

'    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        Me.Close()

'    End Sub

'    Private Sub QueryDataToGrid()

'        Dim MoControl As Control
'        Dim SqlStr As String = ""
'        Dim MoFlag As Boolean
'        For Each MoControl In GubQertyCondition.Controls
'            If TypeOf MoControl Is ComboBox Then
'                If UCase(MoControl.Text) <> "ALL" Then
'                    MoFlag = True
'                    Exit For
'                End If
'            End If
'        Next

'        Dim FiterSqlStr As String = ""
'        FiterSqlStr = GetFiterString()
'        If FiterSqlStr = "" Then
'            TlelCount.Text = "0"
'            Exit Sub
'        End If
'        LoadDataInGrid(FiterSqlStr)

'    End Sub

'    Private Function CobTextInstr(ByVal MoComBox As ComboBox) As String

'        If MoComBox.Text = "" Then
'            CobTextInstr = ""
'            Exit Function
'        End If

'        Dim I As Integer = InStr(MoComBox.Text.Trim, "-")
'        Dim LineStr As String = MoComBox.Text.Substring(0, I - 1)
'        CobTextInstr = LineStr

'    End Function

'    Private Function GetFiterString() As String
'        Dim sMo As String = Nothing
'        Dim SqlStr As String = ""
'        Dim MoComBoxStr As String = ""
'        If CobMono.Text.StartsWith(vbNewLine) Then
'            CobMono.Text = CobMono.Text.Substring(CobMono.Text.IndexOf(vbNewLine), CobMono.Text.Trim.Length)
'        End If
'        If CobMono.Text.EndsWith(vbNewLine) Then
'            CobMono.Text = CobMono.Text.Substring(0, CobMono.Text.LastIndexOf(vbNewLine))
'        End If
'        'If CobMono.Text.Trim <> "" And UCase(CobMono.Text.Trim) <> "ALL" Then
'        '    SqlStr = " where a.Moid like '%" & CobMono.Text & "%'"
'        'End If
'        If CobMono.Text.Trim <> "" AndAlso CobMono.Text.Split(vbNewLine).Length > 1 Then
'            For Each mos As String In CobMono.Text.Split(vbNewLine)
'                sMo += "'" & mos.Trim & "'" & ","
'            Next
'            If Not String.IsNullOrEmpty(sMo) Then SqlStr = " where a.Moid in( " & sMo.Trim(",") & ") "
'        ElseIf CobMono.Text <> "" Then
'            SqlStr = " where a.Moid  like '%" & CobMono.Text.Trim & "%'"
'        End If
'        If UCase(CboMoType.Text.Trim) <> "ALL" And CboMoType.Text.Trim <> "" Then
'            MoComBoxStr = CobTextInstr(CboMoType)
'            If SqlStr = "" Then
'                SqlStr = " where a.typeid='" & MoComBoxStr & "'"
'            Else
'                SqlStr = SqlStr & " and a.typeid='" & MoComBoxStr & "'"
'            End If
'        End If
'        If UCase(CobPart.Text.Trim) <> "ALL" And CobPart.Text.Trim <> "" Then
'            If SqlStr = "" Then
'                SqlStr = " where a.partid='" & CobPart.Text.Trim & "'"
'            Else
'                SqlStr = SqlStr & " and a.partid='" & CobPart.Text.Trim & "'"
'            End If
'        End If
'        If UCase(CboConsumer.Text.Trim) <> "ALL" And CboConsumer.Text.Trim <> "" Then
'            MoComBoxStr = CobTextInstr(CboConsumer)
'            If SqlStr = "" Then
'                SqlStr = " where a.CusID='" & MoComBoxStr & "'"
'            Else
'                SqlStr = SqlStr & " and a.CusID='" & MoComBoxStr & "'"
'            End If
'        End If
'        If UCase(CboDept.Text.Trim) <> "ALL" And CboDept.Text.Trim <> "" Then
'            MoComBoxStr = CobTextInstr(CboDept)
'            If SqlStr = "" Then
'                SqlStr = " where a.Deptid='" & MoComBoxStr & "'"
'            Else
'                SqlStr = SqlStr & " and a.Deptid='" & MoComBoxStr & "'"
'            End If
'        End If
'        If SqlStr = "" Then
'            SqlStr = " where convert(datetime,CONVERT(varchar(10), Createtime,120)) between '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
'        Else
'            If String.IsNullOrEmpty(CobMono.Text.Trim) Then
'                SqlStr = SqlStr & " and convert(datetime,CONVERT(varchar(10), Createtime,120)) between '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
'            End If
'        End If
'        If CheckFiny.Checked = True Then
'            If SqlStr = "" Then
'                SqlStr = " where  FinalY='Y'"
'            Else
'                SqlStr = SqlStr & " and FinalY='Y'"
'            End If
'        End If
'        'If CobRouteid.Text.Trim <> "" And UCase(CobRouteid.Text.Trim) <> "ALL" Then
'        '    If SqlStr = "" Then
'        '        SqlStr = " where a.Routeid='" & CobRouteid.Text & "'"
'        '    Else
'        '        SqlStr = SqlStr & " and a.Routeid='" & CobRouteid.Text & "'"
'        '    End If
'        'End If
'        'If CobPart.Text.Trim <> "" And UCase(CobPart.Text.Trim) <> "ALL" Then
'        '    If SqlStr = "" Then
'        '        SqlStr = " where a.Partid like '%" & CobPart.Text & "%'"
'        '    Else
'        '        SqlStr = SqlStr & " and a.Partid like '%" & CobPart.Text & "%'"
'        '    End If
'        'End If

'        If String.IsNullOrEmpty(SqlStr) Then
'            SqlStr = " WHERE A.MOID=A.PARENTMO "
'        Else
'            SqlStr = SqlStr & " AND A.MOID=A.PARENTMO "
'        End If

'        Return SqlStr

'    End Function

'    Private Sub CboDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

'        If Asc(e.KeyChar) = 13 Then
'            QueryDataToGrid()
'        End If

'    End Sub


'    Private Sub CobMono_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        If ComBoxFlag = False Then
'            ComBoxFlag = True
'            Exit Sub
'        Else
'            DgMoData.Rows.Clear()
'            TlelCount.Text = "0"
'        End If

'    End Sub

'    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        Me.Close()

'    End Sub

'    Private Sub StopFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


'    End Sub


'    Private Sub DgMoData_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

'        Try

'        Catch ex As Exception
'            MessageBox.Show(e.ColumnIndex & ex.Message, ex.Source, MessageBoxButtons.OK)
'        End Try

'    End Sub

'    Private Sub CheckFiny_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        DgMoData.Rows.Clear()
'        TlelCount.Text = "0"

'    End Sub

'    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
'        Try
'            QueryDataToGrid()
'            If DgMoData.Rows.Count > 0 Then
'                txtMo.Text = DgMoData.CurrentRow.Cells(GridColZero).Value
'            Else
'                txtMo.Text = ""
'            End If
'            CobMono.Focus()
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try

'    End Sub

'    Private Sub ToolReEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


'    End Sub

'    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        If CboDept.Items.Count > 0 Then
'            CboDept.SelectedIndex = 0
'        End If
'    End Sub

'    Private Sub ToolQuery_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click

'    End Sub

'    Private Sub ExitFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
'        Me.Close()
'    End Sub

'    Private Sub StopFile_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopFile.Click

'        If DgMoData.Rows.Count < 1 Then Exit Sub
'        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
'        Dim MoHandle As New SysDataBaseClass
'        Dim sqlString As String = "SELECT MOID FROM M_MAINMO_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND (FINALY='Y' OR FINALY='D')"
'        If MoHandle.GetRowsCount(sqlString) > 0 Then
'            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已结案或被冻结,不允许做结案操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If
'        sqlString = "UPDATE M_MAINMO_T SET OLDESTATEID= ESTATEID WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
'        sqlString &= vbNewLine & "update m_Mainmo_t set FinalY='Y',EstateID='7',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
'        If MessageBox.Show("你是否对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
'            MoHandle.ExecSql(sqlString)
'            MessageBox.Show("工单已成功结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            QueryDataToGrid()
'        End If
'        MoHandle = Nothing

'    End Sub

'    Private Sub ToolReEnd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReEnd.Click

'        If DgMoData.Rows.Count < 1 Then Exit Sub
'        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
'        Dim MoHandle As New SysDataBaseClass
'        If MoHandle.GetRowsCount("SELECT MOID FROM M_MAINMO_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND FINALY='Y'") = 0 Then
'            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "没有结案,不允许做取消结案操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If
'        If MoHandle.GetRowsCount("SELECT MOID FROM M_MAINMO_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND FINALY='Y' AND ESTATEID=2") > 0 Then
'            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已分批,请做取消分批操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If
'        If MessageBox.Show("你是否取消对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
'            MoHandle.ExecSql("update m_Mainmo_t set FinalY='N',EstateID=OLDESTATEID,Finalman='" & SysMessageClass.UseId.ToLower & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'")
'            MessageBox.Show("工单已成功取消结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            QueryDataToGrid()
'        End If
'        MoHandle = Nothing

'    End Sub

'    Private Sub ToolHandle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHandle.Click

'        If DgMoData.Rows.Count < 1 Then Exit Sub
'        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
'        Dim MoHandle As New SysDataBaseClass
'        Dim sqlString As String = "SELECT MOID FROM M_MAINMO_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'AND( FINALY='D' OR FINALY='Y')"
'        If MoHandle.GetRowsCount(sqlString) > 0 Then
'            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已被冻结或结案,不允许做冻结操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If

'        sqlString = "UPDATE M_MAINMO_T SET OLDESTATEID=ESTATEID WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
'        sqlString &= vbNewLine & "update m_Mainmo_t set FinalY='D',EstateID='7',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
'        If MessageBox.Show("你是否对该工单进行扫描冻结,产线将无法进行该工单扫描？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
'            MoHandle.ExecSql(sqlString)
'            MessageBox.Show("工单已成功冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            QueryDataToGrid()
'        End If
'        MoHandle = Nothing

'    End Sub

'    Private Sub ToolUhanlde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolUhanlde.Click

'        If DgMoData.Rows.Count < 1 Then Exit Sub
'        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
'        Dim MoHandle As New SysDataBaseClass
'        Dim sqlString As String = "SELECT MOID FROM M_MAINMO_T WHERE FINALY='D' AND MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
'        If MoHandle.GetRowsCount(sqlString) = 0 Then
'            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "未被冻结,不允许做取消冻结操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If
'        If MessageBox.Show("你是否取消该工单进行扫描冻结,产线将恢复？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
'            MoHandle.ExecSql("update m_Mainmo_t set FinalY='N',EstateID=OLDESTATEID,Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'")
'            MessageBox.Show("工单已成功取消冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            QueryDataToGrid()
'        End If
'        MoHandle = Nothing

'    End Sub

'    Private Sub cboCount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCount.SelectedIndexChanged
'        If cboCount.SelectedItem <> Nothing And cboCount.SelectedItem <> "" Then
'            SetBatchControls(cboCount.SelectedItem)
'        End If
'        If cboCount.SelectedItem = Nothing Then
'            SetBatchControls(0)
'        End If
'    End Sub

'    Private Sub SetBatchControls(ByVal index As Integer)
'        For Each frmControl As Control In autoPanel.Controls
'            If CInt(frmControl.Name.Substring(10)) <= index Then
'                frmControl.Visible = True
'                If TypeOf frmControl Is TextBox Then
'                    frmControl.Text = ""
'                End If
'            Else
'                frmControl.Visible = False
'            End If
'        Next
'    End Sub

'    Private Sub BtnBatchMoQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchQuery.Click
'        If Not BasicCheck(False) Then
'            Exit Sub
'        End If
'        Dim Sqlstr As String = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM M_MAINMO_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID " & _
'        "LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN M_CUSTOMER_T E ON A.CUSID=E.CUSID " & _
'        "LEFT JOIN M_DEPT_T F ON A.DEPTID=F.DEPTID WHERE A.MOID='" & txtMo.Text.Trim & "'"
'        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
'        Using UserDg As DataTable = DataHand.GetDataTable(Sqlstr)
'            If UserDg.Rows.Count = 0 Then
'                MessageBox.Show("查不到工单信息,请确认工单号是否正确", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                lblBatchMsg.Text = "查不到工单信息,请确认工单号是否正确"
'                Exit Sub
'            End If
'            dgMo.Rows.Clear()
'            For K As Integer = 0 To UserDg.Rows.Count - 1
'                dgMo.Rows.Add(UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"))
'            Next
'        End Using
'        Sqlstr = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM M_MAINMO_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID " & _
'        "LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN M_CUSTOMER_T E ON A.CUSID=E.CUSID " & _
'        "LEFT JOIN M_DEPT_T F ON A.DEPTID=F.DEPTID WHERE A.PARENTMO='" & txtMo.Text.Trim & "' AND A.MOID<>'" & txtMo.Text & "'AND A.MOID LIKE '" & txtMo.Text.Trim & "-P%'"
'        Using UserDg As DataTable = DataHand.GetDataTable(Sqlstr)
'            dgMoBatch.Rows.Clear()
'            For K As Integer = 0 To UserDg.Rows.Count - 1
'                dgMoBatch.Rows.Add(UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"))
'            Next
'            'ToolStripLabel1.Text = UserDg.Rows.Count
'        End Using
'    End Sub

'    Private Function BasicCheck(ByVal needCheck As Boolean) As Boolean
'        If txtMo.Text.Trim = "" Then
'            MessageBox.Show("工单编号不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            lblBatchMsg.Text = "工单编号不能为空"
'            Return False
'        End If
'        If cboCount.SelectedItem = Nothing AndAlso cboCount.SelectedItem = "" And needCheck Then
'            MessageBox.Show("请选择分批次数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            lblBatchMsg.Text = "请选择分批次数"
'            Return False
'        End If
'        Return True
'    End Function

'    Private Sub BtnBatchMoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMoBatch.Click
'        Try
'            If Not BasicCheck(True) Then
'                Exit Sub
'            End If
'            If Not CheckMoQty() Then
'                Exit Sub
'            End If
'            If CheckMoStatus(ActionType.SaveBatch) Then
'                MessageBox.Show("工单已分批过或是在制程中或是以完工结案", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                lblBatchMsg.Text = "工单已分批过或是在制程中或是以完工结案"
'                Exit Sub
'            End If
'            If MessageBox.Show("确定要分批吗？？？", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
'                SaveBatchMo()
'                MessageBox.Show("工单分批成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                lblBatchMsg.Text = "工单分批成功"
'            Else
'                Exit Sub
'            End If
'            SetBatchControls(0)
'            cboCount.SelectedItem = Nothing
'            BtnBatchMoQuery_Click(Nothing, Nothing)
'        Catch ex As Exception
'            lblBatchMsg.Text = ex.Message
'        End Try
'    End Sub

'    Private Function CheckMoStatus(ByVal actionType As ActionType) As Boolean
'        Dim sqlConn As New SysDataBaseClass
'        Dim sqlString As String = ""
'        Select Case actionType
'            Case actionType.SaveBatch
'                sqlString = "SELECT MOID FROM M_MAINMO_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
'                Return sqlConn.GetRowsCount(sqlString) > 0
'            Case actionType.CancelBatch
'                sqlString = "SELECT MOID FROM M_MAINMO_T WHERE PARENTMO='" & txtMo.Text.Trim & "' AND MOID<>'" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
'                If sqlConn.GetRowsCount(sqlString) > 0 Then
'                    MessageBox.Show("工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    lblBatchMsg.Text = "工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案"
'                    Return True
'                End If
'                sqlString = "SELECT MOID FROM M_MAINMO_T WHERE  MOID<>'" & txtMo.Text.Trim & "' AND PARENTMO IN( SELECT MOID FROM M_MAINMO_T WHERE ESTATEID=2 AND FINALY='Y' AND MOID='" & txtMo.Text & "')"
'                If sqlConn.GetRowsCount(sqlString) = 0 Then
'                    MessageBox.Show("工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    lblBatchMsg.Text = "工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作"
'                    Return True
'                End If
'            Case FrmMoMain.ActionType.PrintMo
'                sqlString = "SELECT MOID FROM M_MAINMO_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID=2 AND FINALY='Y'"
'                If sqlConn.GetRowsCount(sqlString) = 1 Then
'                    MessageBox.Show("工单：" + txtMo.Text + "已经分批,不需要列印流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                    Return True
'                End If
'        End Select

'    End Function

'    Private Function CheckMoQty() As Boolean
'        Dim moQty As Double = 0
'        For Each frmControl As Control In autoPanel.Controls
'            If TypeOf frmControl Is TextBox And frmControl.Visible Then
'                If Not IsNumeric(frmControl.Text) Then
'                    MessageBox.Show("工单数量不能为空且必须是大于零的整数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    lblBatchMsg.Text = "工单数量不能为空且必须是大于零的整数"
'                    Return False
'                ElseIf frmControl.Text <= 0 Then
'                    MessageBox.Show("工单数量不能为空且必须是大于零的整数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    lblBatchMsg.Text = "工单数量不能为空且必须是大于零的整数"
'                    Return False
'                Else
'                    moQty += CDbl(frmControl.Text)
'                End If
'            End If
'        Next
'        Dim sqlConn As New SysDataBaseClass
'        Dim sqlString As String = "SELECT ISNULL(MOQTY,0) MOQTY FROM M_MAINMO_T WHERE MOID='" & txtMo.Text.Trim & "'"
'        Dim dt As DataTable = sqlConn.GetDataTable(sqlString)
'        If dt.Rows.Count > 0 Then
'            If moQty <> CDbl(dt.Rows(0)(0).ToString) Then
'                MessageBox.Show("分批后工单数量应等于当前要分批数量", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                lblBatchMsg.Text = "分批后工单数量应等于当前要分批数量"
'                Return False
'            End If
'        Else
'            MessageBox.Show("工单不存在", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            lblBatchMsg.Text = "工单不存在"
'            Return False
'        End If
'        Return True
'    End Function

'    Private Sub SaveBatchMo()
'        Dim sqlConn As New SysDataBaseClass
'        Dim sqlString As String = " declare @maxseq VARCHAR(2)"
'        For Each frmControl As Control In autoPanel.Controls
'            If TypeOf frmControl Is TextBox AndAlso frmControl.Visible Then
'                sqlString &= vbNewLine & " IF NOT EXISTS(SELECT MOID FROM M_MAINMO_T WHERE MOID<>'" & txtMo.Text.Trim & "' AND PARENTMO='" & txtMo.Text.Trim & "' AND MOID NOT LIKE '" & txtMo.Text.Trim & "-Z%')" & _
'                 "SET @MAXSEQ='01' " & _
'                 " ELSE begin SELECT @MAXSEQ=RIGHT('00'+CAST(SUBSTRING(MAX(MOID),LEN(MAX(MOID))-1,2)+1 AS VARCHAR),2) FROM m_Mainmo_t WHERE ParentMo='" & txtMo.Text & "'AND MOID<>'" & txtMo.Text & "'AND MOID NOT LIKE '" & txtMo.Text.Trim & "-Z%' end " & _
'                 " INSERT INTO M_MAINMO_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,ORDERNO,VERSION)  SELECT " & _
'                 "MOID+'-P'+@MAXSEQ,PARTID,DEPTID,LINEID,'" & frmControl.Text & "',TYPEID,1,CUSID,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & VbCommClass.VbCommClass.Factory & "'," & _
'                 "'" & VbCommClass.VbCommClass.profitcenter & "',MOID,1,ORDERNO,VERSION FROM M_MAINMO_T WHERE MOID='" & txtMo.Text.Trim & "'"
'            End If
'        Next
'        sqlString &= vbNewLine & " UPDATE M_MAINMO_T SET OLDESTATEID=ESTATEID WHERE MOID='" & txtMo.Text.Trim & "'"
'        sqlString &= vbNewLine & " UPDATE M_MAINMO_T SET ESTATEID=2 , FINALY='Y' WHERE MOID='" & txtMo.Text.Trim & "'"
'        sqlConn.ExecSql(sqlString)
'    End Sub

'    Private Sub btnBatchMoCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMoBatch.Click
'        Try
'            If Not BasicCheck(False) Then
'                Exit Sub
'            End If
'            If CheckMoStatus(ActionType.CancelBatch) Then
'                Exit Sub
'            End If
'            If MessageBox.Show("确定要取消分批吗？？？", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
'                CancelBatchMo()
'                MessageBox.Show("取消分批成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                lblBatchMsg.Text = "取消分批成功"
'                BtnBatchMoQuery_Click(Nothing, Nothing)
'                SetBatchControls(0)
'                cboCount.SelectedItem = Nothing
'            Else
'                Exit Sub
'            End If
'        Catch ex As Exception
'            lblBatchMsg.Text = ex.Message
'        End Try
'    End Sub

'    Private Sub CancelBatchMo()
'        Dim sqlConn As New SysDataBaseClass
'        Dim sqlString As String = ""
'        sqlString = "DELETE FROM M_MAINMO_T WHERE PARENTMO='" & txtMo.Text.Trim & "' AND MOID<>'" & txtMo.Text.Trim & "' AND MOID  NOT LIKE '" & txtMo.Text.Trim & "-Z%'"
'        sqlString &= " UPDATE M_MAINMO_T SET ESTATEID=OLDESTATEID, FINALY='N' WHERE MOID='" & txtMo.Text.Trim & "'"
'        sqlConn.ExecSql(sqlString)
'    End Sub

'    Private Sub BtnBatchMoQuery_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatchMoQuery.Click
'        BtnBatchMoQuery_Click(Nothing, Nothing)
'    End Sub

'    Private Sub btnBatchMoSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchMoSave.Click
'        BtnBatchMoSave_Click(Nothing, Nothing)
'    End Sub

'    Private Sub btnBatchMoCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchMoCancel.Click
'        btnBatchMoCancel_Click(Nothing, Nothing)
'    End Sub

'    Private Sub DgMoData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellClick
'        txtMo.Text = DgMoData.CurrentRow.Cells(GridColZero).Value
'        If e.ColumnIndex = 1 Then
'            Try
'                LoadChildMo(DgMoData.CurrentRow.Cells(GridColZero).Value)
'            Catch ex As Exception
'                MessageBox.Show(ex.Message)
'            End Try
'        Else
'            dgvChild.Rows.Clear()
'        End If
'    End Sub

'    Private Sub LoadChildMo(ByVal mo As String)
'        Dim sqlConn As New SysDataBaseClass
'        Dim sql As String = "SELECT MOID,PARTID,VERSION,ESTATEID+'.'+STATENAME STATUS FROM M_MAINMO_T A  LEFT JOIN M_MOSTATE_T ON A.ESTATEID=STATEID WHERE A.PARENTMO='" & mo & "' AND A.MOID<> PARENTMO"
'        dgvChild.Rows.Clear()
'        Using dt As DataTable = sqlConn.GetDataTable(sql)
'            For Each row As DataRow In dt.Rows
'                'dgvChild.Rows.Add(row("MOID").ToString, row("PARTID").ToString, row("MOQTY").ToString, row("LINEID").ToString)
'                dgvChild.Rows.Add(row("MOID").ToString, row("PARTID").ToString, row("VERSION").ToString)
'            Next
'        End Using
'        sqlConn = Nothing
'    End Sub

'    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrint.Click
'        'If txtMo.Text = "" Then
'        '    MessageBox.Show("请先选择需要打印流程卡的工单", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'        '    Exit Sub
'        'End If
'        If CheckMoStatus(ActionType.PrintMo) Then
'            Exit Sub
'        End If
'        ToolRePrint_Click(Nothing, Nothing)
'    End Sub

'    Private Sub ToolRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRePrint.Click
'        Dim isExist As Boolean = False
'        Dim strMo As String = Nothing
'        Dim idx As Integer = 0
'        If Not System.Windows.Forms.Application.OpenForms.Item("流程卡列印") Is Nothing Then
'            'Application.OpenForms.Item("FrmPrintCard").Activate()
'            ' Application.OpenForms.Item("FrmPrintCard").Visible = False
'            System.Windows.Forms.Application.OpenForms.Item("流程卡列印").Dispose()
'        End If
'        If Not isExist Then
'            For Each row As DataGridViewRow In DgMoData.Rows
'                If Not row.Cells(GridColOne).EditedFormattedValue Is Nothing AndAlso row.Cells(GridColOne).EditedFormattedValue.ToString = "True" Then
'                    strMo += row.Cells(GridColZero).Value.ToString & vbNewLine
'                    idx += 1
'                End If
'            Next
'            If idx = 0 Then
'                strMo = txtMo.Text
'            End If
'            Dim fm As New FrmPrintCard(strMo.Trim, IIf(idx > 1, True, False))
'            fm.Show()
'        End If

'    End Sub

'    Public Sub New()

'        ' 此调用是 Windows 窗体设计器所必需的。
'        InitializeComponent()
'        ' 在 InitializeComponent() 调用之后添加任何初始化。

'    End Sub

'    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
'        For Each row As DataGridViewRow In DgMoData.Rows
'            row.Cells(0).Value = ChkAll.Checked
'        Next
'    End Sub
'End Class
#End Region


Public Class FrmMoMain

    Const GridColZero As Integer = 1
    Const GridColOne As Integer = 0
    Dim ComBoxFlag As Boolean
    Public Enum ActionType
        SaveBatch = 0
        CancelBatch
        PrintMo
    End Enum

#Region "酶datagridview虫じ,匡い埃礘翴"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub FrmMoMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim TabTrans As New TextHandle
        TabTrans.TabTransEnter(sender, e)
        TabTrans = Nothing

    End Sub

    Private Sub FrmMoMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CheckUserRight()
            SetBatchControls(0)
            FillComboLine(CboMoType)
            FillComboLine(CboConsumer)
            FillComboLine(CboDept)
            DtStarDate.Value = DateAdd(DateInterval.Day, -1, Now())
            DtEndDate.Value = Now()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CheckUserRight() As Boolean
        Dim PubClass As New SysDataBaseClass
        Dim CheckRead As SqlDataReader = PubClass.GetDataReader("select distinct a.* from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='RCm06_' and a.userid='" & SysMessageClass.UseId & "'")
        If Not CheckRead.Read Then
            ToolQuery.Enabled = True
            ToolHandle.Enabled = False
            ToolReEnd.Enabled = False
            ToolUhanlde.Enabled = False
            StopFile.Enabled = False
            ExitFrom.Enabled = True
            ToolPrint.Enabled = False
            ToolRePrint.Enabled = False
            CheckUserRight = False
        Else
            ToolQuery.Enabled = True
            ToolHandle.Enabled = True
            ToolReEnd.Enabled = True
            ToolUhanlde.Enabled = True
            StopFile.Enabled = True
            ToolPrint.Enabled = True
            ToolRePrint.Enabled = True
            CheckUserRight = True
        End If
        CheckRead.Close()
        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m0640_' and a.userid='" & SysMessageClass.UseId & "'")
        If Not CheckRead.Read Then
            btnBatchMoSave.Enabled = False
            btnBatchMoCancel.Enabled = False
        Else
            btnBatchMoSave.Enabled = True
            btnBatchMoCancel.Enabled = True
        End If
        PubClass.GetControlright(Me)
        PubClass = Nothing
        Return CheckUserRight
    End Function

    Private Sub TransDataGridLanguage()

        Dim ColsText As String = "WO|P/N|Part Name|Customer code|Customer Name|PD|PD Name|Line type|WO  qty|PPID Count|PKG Count|WO type|WO status|Route|Maintainer|Maintain date"
        Dim colNames As String() = ColsText.Split("|")
        Dim i%
        For i = 0 To DgMoData.Columns.Count - 1
            DgMoData.Columns(i).HeaderText = colNames(i)
        Next

    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)

        Dim ScanClass As New SysDataBaseClass
        'Dim ScanReader As SqlDataReader
        ' ScanReader = Nothing
        FillComBox.Items.Add("ALL")
        If FillComBox.Name = "CboDept" Then
            Using dt As DataTable = ScanClass.GetDataTable("Select  * from m_RunCardDepartment_t where  listally='Y' and usey='Y' and dtype='R'")
                For Each row As DataRow In dt.Rows
                    FillComBox.Items.Add(row("deptid").ToString & "---" & row("dqc").ToString)
                Next
            End Using
        ElseIf FillComBox.Name = "CboConsumer" Then
            Using dt As DataTable = ScanClass.GetDataTable("Select  * from m_RunCardConsumer_t")
                For Each row As DataRow In dt.Rows
                    FillComBox.Items.Add(row(0).ToString & "---" & row(1).ToString)
                Next
            End Using
        ElseIf FillComBox.Name = "CboMoType" Then
            Using dt As DataTable = ScanClass.GetDataTable("select * from motype_t")
                For Each row As DataRow In dt.Rows
                    FillComBox.Items.Add(row(0).ToString & "---" & row(1).ToString)
                Next
            End Using
        End If
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub LoadDataInGrid(Optional ByVal FiterSqlStr As String = "")

        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String

        DgMoData.Rows.Clear()
        DgMoData.ScrollBars = ScrollBars.None

        Sqlstr = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM m_RunCardWorkOrder_t A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN m_RunCardConsumer_t E ON A.CUSID=E.CUSID LEFT JOIN m_RunCardDepartment_t F ON A.DEPTID=F.DEPTID "
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        UserDg = DataHand.GetDataTable(Sqlstr & FiterSqlStr & " ORDER BY A.CREATETIME DESC ")

        For K = 0 To UserDg.Rows.Count - 1
            DgMoData.Rows.Add("false", UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"), UserDg.Rows(K)("IsPrinted"))
        Next
        DgMoData.Columns(0).ReadOnly = False
        For idx As Integer = 1 To DgMoData.Columns.Count - 1
            DgMoData.Columns(idx).ReadOnly = True
        Next

        DgMoData.ScrollBars = ScrollBars.Both
        TlelCount.Text = UserDg.Rows.Count
        DataHand = Nothing
        UserDg.Dispose()
        'DgMoData.AutoResizeColumns()
        'DgMoData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub QueryDataToGrid()

        Dim MoControl As Control
        Dim SqlStr As String = ""
        Dim MoFlag As Boolean
        For Each MoControl In GubQertyCondition.Controls
            If TypeOf MoControl Is ComboBox Then
                If UCase(MoControl.Text) <> "ALL" Then
                    MoFlag = True
                    Exit For
                End If
            End If
        Next

        Dim FiterSqlStr As String = ""
        FiterSqlStr = GetFiterString()
        If FiterSqlStr = "" Then
            TlelCount.Text = "0"
            Exit Sub
        End If
        LoadDataInGrid(FiterSqlStr)

    End Sub

    Private Function CobTextInstr(ByVal MoComBox As ComboBox) As String

        If MoComBox.Text = "" Then
            CobTextInstr = ""
            Exit Function
        End If

        Dim I As Integer = InStr(MoComBox.Text.Trim, "-")
        Dim LineStr As String = MoComBox.Text.Substring(0, I - 1)
        CobTextInstr = LineStr

    End Function

    Private Function GetFiterString() As String
        Dim sMo As String = Nothing
        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        If CobMono.Text.StartsWith(vbNewLine) Then
            CobMono.Text = CobMono.Text.Substring(CobMono.Text.IndexOf(vbNewLine), CobMono.Text.Trim.Length)
        End If
        If CobMono.Text.EndsWith(vbNewLine) Then
            CobMono.Text = CobMono.Text.Substring(0, CobMono.Text.LastIndexOf(vbNewLine))
        End If
        'If CobMono.Text.Trim <> "" And UCase(CobMono.Text.Trim) <> "ALL" Then
        '    SqlStr = " where a.Moid like '%" & CobMono.Text & "%'"
        'End If
        If CobMono.Text.Trim <> "" AndAlso CobMono.Text.Split(vbNewLine).Length > 1 Then
            For Each mos As String In CobMono.Text.Split(vbNewLine)
                sMo += "'" & mos.Trim & "'" & ","
            Next
            If Not String.IsNullOrEmpty(sMo) Then SqlStr = " where a.Moid in( " & sMo.Trim(",") & ") "
        ElseIf CobMono.Text <> "" Then
            SqlStr = " where a.Moid  like '%" & CobMono.Text.Trim & "%'"
        End If
        If UCase(CboMoType.Text.Trim) <> "ALL" And CboMoType.Text.Trim <> "" Then
            MoComBoxStr = CobTextInstr(CboMoType)
            If SqlStr = "" Then
                SqlStr = " where a.typeid='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " and a.typeid='" & MoComBoxStr & "'"
            End If
        End If
        If UCase(CobPart.Text.Trim) <> "ALL" And CobPart.Text.Trim <> "" Then
            If SqlStr = "" Then
                SqlStr = " where a.partid='" & CobPart.Text.Trim & "'"
            Else
                SqlStr = SqlStr & " and a.partid='" & CobPart.Text.Trim & "'"
            End If
        End If
        If UCase(CboConsumer.Text.Trim) <> "ALL" And CboConsumer.Text.Trim <> "" Then
            MoComBoxStr = CobTextInstr(CboConsumer)
            If SqlStr = "" Then
                SqlStr = " where a.CusID='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " and a.CusID='" & MoComBoxStr & "'"
            End If
        End If
        If UCase(CboDept.Text.Trim) <> "ALL" And CboDept.Text.Trim <> "" Then
            MoComBoxStr = CobTextInstr(CboDept)
            If SqlStr = "" Then
                SqlStr = " where a.Deptid='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " and a.Deptid='" & MoComBoxStr & "'"
            End If
        End If
        If SqlStr = "" Then
            SqlStr = " where convert(datetime,CONVERT(varchar(10), Createtime,120)) between '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
        Else
            If String.IsNullOrEmpty(CobMono.Text.Trim) Then
                SqlStr = SqlStr & " and convert(datetime,CONVERT(varchar(10), Createtime,120)) between '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
            End If
        End If
        If CheckFiny.Checked = True Then
            If SqlStr = "" Then
                SqlStr = " where  FinalY='Y'"
            Else
                SqlStr = SqlStr & " and FinalY='Y'"
            End If
        End If
        'If CobRouteid.Text.Trim <> "" And UCase(CobRouteid.Text.Trim) <> "ALL" Then
        '    If SqlStr = "" Then
        '        SqlStr = " where a.Routeid='" & CobRouteid.Text & "'"
        '    Else
        '        SqlStr = SqlStr & " and a.Routeid='" & CobRouteid.Text & "'"
        '    End If
        'End If
        'If CobPart.Text.Trim <> "" And UCase(CobPart.Text.Trim) <> "ALL" Then
        '    If SqlStr = "" Then
        '        SqlStr = " where a.Partid like '%" & CobPart.Text & "%'"
        '    Else
        '        SqlStr = SqlStr & " and a.Partid like '%" & CobPart.Text & "%'"
        '    End If
        'End If

        If String.IsNullOrEmpty(SqlStr) Then
            SqlStr = " WHERE A.MOID=A.PARENTMO "
        Else
            SqlStr = SqlStr & " AND A.MOID=A.PARENTMO "
        End If

        Return SqlStr

    End Function

    Private Sub CboDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Asc(e.KeyChar) = 13 Then
            QueryDataToGrid()
        End If

    End Sub


    Private Sub CobMono_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ComBoxFlag = False Then
            ComBoxFlag = True
            Exit Sub
        Else
            DgMoData.Rows.Clear()
            TlelCount.Text = "0"
        End If

    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub StopFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub DgMoData_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

        Try

        Catch ex As Exception
            MessageBox.Show(e.ColumnIndex & ex.Message, ex.Source, MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub CheckFiny_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Try
            QueryDataToGrid()
            If DgMoData.Rows.Count > 0 Then
                txtMo.Text = DgMoData.CurrentRow.Cells(GridColZero).Value
            Else
                txtMo.Text = ""
            End If
            CobMono.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolReEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CboDept.Items.Count > 0 Then
            CboDept.SelectedIndex = 0
        End If
    End Sub

    Private Sub ToolQuery_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click

    End Sub

    Private Sub ExitFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub StopFile_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopFile.Click

        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        Dim sqlString As String = "SELECT MOID FROM m_RunCardWorkOrder_t WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND (FINALY='Y' OR FINALY='D')"
        If MoHandle.GetRowsCount(sqlString) > 0 Then
            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已结案或被冻结,不允许做结案操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        sqlString = "UPDATE m_RunCardWorkOrder_t SET OLDESTATEID= ESTATEID WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
        sqlString &= vbNewLine & "update m_RunCardWorkOrder_t set FinalY='Y',EstateID='7',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
        If MessageBox.Show("你是否对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            MoHandle.ExecSql(sqlString)
            MessageBox.Show("工单已成功结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
        MoHandle = Nothing

    End Sub

    Private Sub ToolReEnd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReEnd.Click

        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        If MoHandle.GetRowsCount("SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND FINALY='Y'") = 0 Then
            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "没有结案,不允许做取消结案操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MoHandle.GetRowsCount("SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "' AND FINALY='Y' AND ESTATEID=2") > 0 Then
            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已分批,请做取消分批操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MessageBox.Show("你是否取消对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            MoHandle.ExecSql("update M_RUNCARDWORKORDER_T set FinalY='N',EstateID=OLDESTATEID,Finalman='" & SysMessageClass.UseId.ToLower & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'")
            MessageBox.Show("工单已成功取消结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
        MoHandle = Nothing

    End Sub

    Private Sub ToolHandle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHandle.Click

        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        Dim sqlString As String = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'AND( FINALY='D' OR FINALY='Y')"
        If MoHandle.GetRowsCount(sqlString) > 0 Then
            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "已被冻结或结案,不允许做冻结操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        sqlString = "UPDATE M_RUNCARDWORKORDER_T SET OLDESTATEID=ESTATEID WHERE MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
        sqlString &= vbNewLine & "update m_Mainmo_t set FinalY='D',EstateID='7',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
        If MessageBox.Show("你是否对该工单进行扫描冻结,产线将无法进行该工单扫描？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            MoHandle.ExecSql(sqlString)
            MessageBox.Show("工单已成功冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
        MoHandle = Nothing

    End Sub

    Private Sub ToolUhanlde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolUhanlde.Click

        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value = "" Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        Dim sqlString As String = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE FINALY='D' AND MOID='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'"
        If MoHandle.GetRowsCount(sqlString) = 0 Then
            MessageBox.Show("工单" + DgMoData.CurrentRow.Cells(GridColZero).Value + "未被冻结,不允许做取消冻结操作...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MessageBox.Show("你是否取消该工单进行扫描冻结,产线将恢复？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            MoHandle.ExecSql("update M_RUNCARDWORKORDER_T set FinalY='N',EstateID=OLDESTATEID,Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() where Moid='" & DgMoData.CurrentRow.Cells(GridColZero).Value & "'")
            MessageBox.Show("工单已成功取消冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
        MoHandle = Nothing

    End Sub

    Private Sub cboCount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCount.SelectedIndexChanged
        If cboCount.SelectedItem <> Nothing And cboCount.SelectedItem <> "" Then
            SetBatchControls(cboCount.SelectedItem)
        End If
        If cboCount.SelectedItem = Nothing Then
            SetBatchControls(0)
        End If
    End Sub

    Private Sub SetBatchControls(ByVal index As Integer)
        For Each frmControl As Control In autoPanel.Controls
            If CInt(frmControl.Name.Substring(10)) <= index Then
                frmControl.Visible = True
                If TypeOf frmControl Is TextBox Then
                    frmControl.Text = ""
                End If
            Else
                frmControl.Visible = False
            End If
        Next
    End Sub

    Private Sub BtnBatchMoQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchQuery.Click
        If Not BasicCheck(False) Then
            Exit Sub
        End If
        Dim Sqlstr As String = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM M_RUNCARDWORKORDER_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID " & _
        "LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN M_RUNCARDCONSUMER_T E ON A.CUSID=E.CUSID " & _
        "LEFT JOIN M_RUNCARDDEPARTMENT_T F ON A.DEPTID=F.DEPTID WHERE A.MOID='" & txtMo.Text.Trim & "'"
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Using UserDg As DataTable = DataHand.GetDataTable(Sqlstr)
            If UserDg.Rows.Count = 0 Then
                MessageBox.Show("查不到工单信息,请确认工单号是否正确", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblBatchMsg.Text = "查不到工单信息,请确认工单号是否正确"
                Exit Sub
            End If
            dgMo.Rows.Clear()
            For K As Integer = 0 To UserDg.Rows.Count - 1
                dgMo.Rows.Add(UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"))
            Next
        End Using
        Sqlstr = "SELECT DISTINCT TOP 100 D.PARTNAME,A.*,B.MOTYPE,C.STATENAME,E.CUSNAME,F.DJC FROM M_RUNCARDWORKORDER_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID " & _
        "LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID  LEFT JOIN MATTER_TAB D ON A.PARTID=D.PARTID LEFT JOIN M_RUNCARDCONSUMER_T E ON A.CUSID=E.CUSID " & _
        "LEFT JOIN M_RUNCARDDEPARTMENT_T F ON A.DEPTID=F.DEPTID WHERE A.PARENTMO='" & txtMo.Text.Trim & "' AND A.MOID<>'" & txtMo.Text & "'AND A.MOID LIKE '" & txtMo.Text.Trim & "-P%'"
        Using UserDg As DataTable = DataHand.GetDataTable(Sqlstr)
            dgMoBatch.Rows.Clear()
            For K As Integer = 0 To UserDg.Rows.Count - 1
                dgMoBatch.Rows.Add(UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), UserDg.Rows(K)("factory"), UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"), UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("version"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("Createuser"), UserDg.Rows(K)("Createtime"))
            Next
            'ToolStripLabel1.Text = UserDg.Rows.Count
        End Using
    End Sub

    Private Function BasicCheck(ByVal needCheck As Boolean) As Boolean
        If txtMo.Text.Trim = "" Then
            MessageBox.Show("工单编号不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblBatchMsg.Text = "工单编号不能为空"
            Return False
        End If
        If cboCount.SelectedItem = Nothing AndAlso cboCount.SelectedItem = "" And needCheck Then
            MessageBox.Show("请选择分批次数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblBatchMsg.Text = "请选择分批次数"
            Return False
        End If
        Return True
    End Function

    Private Sub BtnBatchMoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMoBatch.Click
        Try
            If Not BasicCheck(True) Then
                Exit Sub
            End If
            If Not CheckMoQty() Then
                Exit Sub
            End If
            If CheckMoStatus(ActionType.SaveBatch) Then
                MessageBox.Show("工单已分批过或是在制程中或是以完工结案", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblBatchMsg.Text = "工单已分批过或是在制程中或是以完工结案"
                Exit Sub
            End If
            If MessageBox.Show("确定要分批吗？？？", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                SaveBatchMo()
                MessageBox.Show("工单分批成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblBatchMsg.Text = "工单分批成功"
            Else
                Exit Sub
            End If
            SetBatchControls(0)
            cboCount.SelectedItem = Nothing
            BtnBatchMoQuery_Click(Nothing, Nothing)
        Catch ex As Exception
            lblBatchMsg.Text = ex.Message
        End Try
    End Sub

    Private Function CheckMoStatus(ByVal actionType As ActionType) As Boolean
        Dim sqlConn As New SysDataBaseClass
        Dim sqlString As String = ""
        Select Case actionType
            Case actionType.SaveBatch
                sqlString = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
                Return sqlConn.GetRowsCount(sqlString) > 0
            Case actionType.CancelBatch
                sqlString = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & txtMo.Text.Trim & "' AND MOID<>'" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
                If sqlConn.GetRowsCount(sqlString) > 0 Then
                    MessageBox.Show("工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案"
                    Return True
                End If
                sqlString = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE  MOID<>'" & txtMo.Text.Trim & "' AND PARENTMO IN( SELECT MOID FROM M_MAINMO_T WHERE ESTATEID=2 AND FINALY='Y' AND MOID='" & txtMo.Text & "')"
                If sqlConn.GetRowsCount(sqlString) = 0 Then
                    MessageBox.Show("工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作"
                    Return True
                End If
            Case FrmMoMain.ActionType.PrintMo
                sqlString = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID=2 AND FINALY='Y'"
                If sqlConn.GetRowsCount(sqlString) = 1 Then
                    MessageBox.Show("工单：" + txtMo.Text + "已经分批,不需要列印流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
                End If
        End Select

    End Function

    Private Function CheckMoQty() As Boolean
        Dim moQty As Double = 0
        For Each frmControl As Control In autoPanel.Controls
            If TypeOf frmControl Is TextBox And frmControl.Visible Then
                If Not IsNumeric(frmControl.Text) Then
                    MessageBox.Show("工单数量不能为空且必须是大于零的整数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单数量不能为空且必须是大于零的整数"
                    Return False
                ElseIf frmControl.Text <= 0 Then
                    MessageBox.Show("工单数量不能为空且必须是大于零的整数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单数量不能为空且必须是大于零的整数"
                    Return False
                Else
                    moQty += CDbl(frmControl.Text)
                End If
            End If
        Next
        Dim sqlConn As New SysDataBaseClass
        Dim sqlString As String = "SELECT ISNULL(MOQTY,0) MOQTY FROM M_RUNCARDWORKORDER_T WHERE MOID='" & txtMo.Text.Trim & "'"
        Dim dt As DataTable = sqlConn.GetDataTable(sqlString)
        If dt.Rows.Count > 0 Then
            If moQty <> CDbl(dt.Rows(0)(0).ToString) Then
                MessageBox.Show("分批后工单数量应等于当前要分批数量", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblBatchMsg.Text = "分批后工单数量应等于当前要分批数量"
                Return False
            End If
        Else
            MessageBox.Show("工单不存在", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblBatchMsg.Text = "工单不存在"
            Return False
        End If
        Return True
    End Function

    Private Sub SaveBatchMo()
        Dim sqlConn As New SysDataBaseClass
        Dim sqlString As String = " declare @maxseq VARCHAR(2)"
        For Each frmControl As Control In autoPanel.Controls
            If TypeOf frmControl Is TextBox AndAlso frmControl.Visible Then
                sqlString &= vbNewLine & " IF NOT EXISTS(SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID<>'" & txtMo.Text.Trim & "' AND PARENTMO='" & txtMo.Text.Trim & "' AND MOID NOT LIKE '" & txtMo.Text.Trim & "-Z%')" & _
                 "SET @MAXSEQ='01' " & _
                 " ELSE begin SELECT @MAXSEQ=RIGHT('00'+CAST(SUBSTRING(MAX(MOID),LEN(MAX(MOID))-1,2)+1 AS VARCHAR),2) FROM m_Mainmo_t WHERE ParentMo='" & txtMo.Text & "'AND MOID<>'" & txtMo.Text & "'AND MOID NOT LIKE '" & txtMo.Text.Trim & "-Z%' end " & _
                 " INSERT INTO M_RUNCARDWORKORDER_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,ORDERNO,VERSION)  SELECT " & _
                 "MOID+'-P'+@MAXSEQ,PARTID,DEPTID,LINEID,'" & frmControl.Text & "',TYPEID,1,CUSID,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & VbCommClass.VbCommClass.Factory & "'," & _
                 "'" & VbCommClass.VbCommClass.profitcenter & "',MOID,1,ORDERNO,VERSION FROM M_MAINMO_T WHERE MOID='" & txtMo.Text.Trim & "'"
            End If
        Next
        sqlString &= vbNewLine & " UPDATE M_RUNCARDWORKORDER_T SET OLDESTATEID=ESTATEID WHERE MOID='" & txtMo.Text.Trim & "'"
        sqlString &= vbNewLine & " UPDATE M_RUNCARDWORKORDER_T SET ESTATEID=2 , FINALY='Y' WHERE MOID='" & txtMo.Text.Trim & "'"
        sqlConn.ExecSql(sqlString)
    End Sub

    Private Sub btnBatchMoCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMoBatch.Click
        Try
            If Not BasicCheck(False) Then
                Exit Sub
            End If
            If CheckMoStatus(ActionType.CancelBatch) Then
                Exit Sub
            End If
            If MessageBox.Show("确定要取消分批吗？？？", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                CancelBatchMo()
                MessageBox.Show("取消分批成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblBatchMsg.Text = "取消分批成功"
                BtnBatchMoQuery_Click(Nothing, Nothing)
                SetBatchControls(0)
                cboCount.SelectedItem = Nothing
            Else
                Exit Sub
            End If
        Catch ex As Exception
            lblBatchMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub CancelBatchMo()
        Dim sqlConn As New SysDataBaseClass
        Dim sqlString As String = ""
        sqlString = "DELETE FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & txtMo.Text.Trim & "' AND MOID<>'" & txtMo.Text.Trim & "' AND MOID  NOT LIKE '" & txtMo.Text.Trim & "-Z%'"
        sqlString &= " UPDATE M_RUNCARDWORKORDER_T SET ESTATEID=OLDESTATEID, FINALY='N' WHERE MOID='" & txtMo.Text.Trim & "'"
        sqlConn.ExecSql(sqlString)
    End Sub

    Private Sub BtnBatchMoQuery_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatchMoQuery.Click
        BtnBatchMoQuery_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBatchMoSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchMoSave.Click
        BtnBatchMoSave_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBatchMoCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchMoCancel.Click
        btnBatchMoCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub DgMoData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellClick
        txtMo.Text = DgMoData.CurrentRow.Cells(GridColZero).Value
        If e.ColumnIndex = 1 Then
            Try
                LoadChildMo(DgMoData.CurrentRow.Cells(GridColZero).Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            dgvChild.Rows.Clear()
        End If
    End Sub

    Private Sub LoadChildMo(ByVal mo As String)
        Dim sqlConn As New SysDataBaseClass
        Dim sql As String = "SELECT MOID,PARTID,VERSION,ISPRINTED,ESTATEID+'.'+STATENAME STATUS FROM M_RUNCARDWORKORDER_T A  LEFT JOIN M_MOSTATE_T ON A.ESTATEID=STATEID WHERE A.PARENTMO='" & mo & "' AND A.MOID<> PARENTMO"
        dgvChild.Rows.Clear()
        Using dt As DataTable = sqlConn.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                'dgvChild.Rows.Add(row("MOID").ToString, row("PARTID").ToString, row("MOQTY").ToString, row("LINEID").ToString)
                dgvChild.Rows.Add(row("MOID").ToString, row("PARTID").ToString, row("VERSION").ToString, row("ISPRINTED").ToString)
            Next
        End Using
        sqlConn = Nothing
    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrint.Click
        'If txtMo.Text = "" Then
        '    MessageBox.Show("请先选择需要打印流程卡的工单", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        If CheckMoStatus(ActionType.PrintMo) Then
            Exit Sub
        End If
        ToolRePrint_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRePrint.Click
        Dim isExist As Boolean = False
        Dim strMo As String = Nothing
        Dim idx As Integer = 0
        If Not System.Windows.Forms.Application.OpenForms.Item("流程卡列印") Is Nothing Then
            'Application.OpenForms.Item("FrmPrintCard").Activate()
            ' Application.OpenForms.Item("FrmPrintCard").Visible = False
            System.Windows.Forms.Application.OpenForms.Item("流程卡列印").Dispose()
        End If
        If Not isExist Then
            For Each row As DataGridViewRow In DgMoData.Rows
                If Not row.Cells(GridColOne).EditedFormattedValue Is Nothing AndAlso row.Cells(GridColOne).EditedFormattedValue.ToString = "True" Then
                    strMo += row.Cells(GridColZero).Value.ToString & vbNewLine
                    idx += 1
                End If
            Next
            If idx = 0 Then
                strMo = txtMo.Text
            End If
            Dim fm As New FrmPrintCard(strMo.Trim, IIf(idx > 1, True, False))
            fm.Show()
        End If

    End Sub

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        For Each row As DataGridViewRow In DgMoData.Rows
            row.Cells(0).Value = ChkAll.Checked
        Next
    End Sub
End Class