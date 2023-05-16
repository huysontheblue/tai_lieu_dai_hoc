''------------祘秨祇ら戳 2007/01/10----------------
''-------------秨祇 稼稻瞝-----------------------
''-------------祘:蝴臔虫膀娄戈-------------


Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports LXWarehouseManage


Public Class FrmWorkSheet

    Const GridColZero As Integer = 0    ''''check匡拒兜
    Const GridColOne As Integer = 1     ''''虫絪腹
    Const GridColTwo As Integer = 2     ''''ン絪絏
    Const GridColThree As Integer = 3   ''''珇
    Const GridColFour As Integer = 4   ''''め
    Const GridColFive As Integer = 5    ''''ネ玻场
    Const GridColSix As Integer = 6    ''''ネ玻絬
    Const GridColServ As Integer = 7    ''''虫计秖
    Const GridColEig As Integer = 8    ''''虫摸
    Const GridColNine As Integer = 9    ''''虫篈
    Const GridColTen As Integer = 10    ''''ネ玻硚祘
    Const GridEven As Integer = 11    ''''虫秨ミ
    Const GridTwe As Integer = 12        ''腹
    Dim ComboxFlag As Boolean
    Dim DataGridHeight As Integer = 0
    Dim DataGridNew As Integer = 0
    Dim DataLocation As Integer = 0
    Dim DataLocaNew As Integer = 0

#Region "酶datagridview虫じ,匡い埃礘翴"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click

        Me.Close()

    End Sub

    ''Private Sub FrmWorkSheet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoNo.KeyPress, TxtPartID.KeyPress

    ''    Dim TabTrans As New TextHandle
    ''    TabTrans.TabTransEnter(sender, e)
    ''    TabTrans = Nothing

    ''End Sub

    Private Sub FrmWorkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim PubClass As New SysDataBaseClass
        Dim CheckRead As SqlDataReader = PubClass.GetDataReader("select distinct a.userid from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='RCm06_' and a.userid='" & SysMessageClass.UseId & "'")
        If Not CheckRead.Read Then
            Me.ToolNew.Enabled = False
        Else
            Me.ToolNew.Enabled = True
        End If
        CheckRead.Close()
        PubClass = Nothing
        '' InitFormContol()
        Panel1.Enabled = False
        FillCombox(CobFactory)
        FillComboLine(CboMoType)
        'FillGridCombox(ColDept)
        ''FillCombox(CboDept)
        FillCombox(CboCust)
        FillCombox(ComMoType)
        FillGridCombox(ColCustomer)


        CobFactory.SelectedIndex = -1

        ComMoType.SelectedIndex = -1
        CboDept.SelectedIndex = -1
        CboCust.SelectedIndex = -1
        Me.ToolCancel.Enabled = False
        Me.ToolSave.Enabled = False
        chkVersion.Checked = True
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        If ColComboBox.Name = "CboDept" Then
            UserDg = DataHand.GetDataTable("select deptid,dqc from   m_RunCardDepartment_t where factoryid='" & CobFactory.SelectedValue & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='RC10109_' and userid='" & SysMessageClass.UseId & "')")
            'UserDg = DataHand.GetDataTable("select deptid,dqc from   m_Dept_t where factoryid='" & CobFactory.SelectedValue & "' ")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "dqc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = DataHand.GetDataTable("Select  (CusID+'---'+CusName) CusName ,CusID from m_RunCardConsumer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "CboLine" Then
            UserDg = DataHand.GetDataTable("Select  lineid,lineid from m_RunCardDepartmentLine_t where deptid='" & CboDept.SelectedValue & "'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        ElseIf ColComboBox.Name = "CobFactory" Then
            UserDg = DataHand.GetDataTable("Select  factoryid,shortname from m_Dcompany_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "shortname"
            ColComboBox.ValueMember = "factoryid"
        ElseIf ColComboBox.Name = "ComMoType" Then
            UserDg = DataHand.GetDataTable("Select  motype,typeid from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        End If
        UserDg = Nothing

    End Sub

    Private Sub InitFormContol()

        Panel1.Visible = False
        Me.Panel2.Location = New System.Drawing.Point(0, Panel1.Location.Y)
        Me.DgMoData.Height = Me.DgMoData.Height + Panel1.Height + 6
        Me.DgMoData.Location = New System.Drawing.Point(0, DgMoData.Location.Y - Panel2.Location.Y - Panel1.Location.Y - 16)

    End Sub

    Private Sub ResetFormContol()

        Panel1.Hide()
        Panel2.Show()
        If DataGridHeight = 0 Then
            Me.DgMoData.Height = Me.DgMoData.Height + 8
            DataGridHeight = Me.DgMoData.Height
        Else
            Me.DgMoData.Height = DataGridHeight
        End If
        If DataLocation = 0 Then
            Me.DgMoData.Location = New System.Drawing.Point(0, DgMoData.Location.Y - Panel2.Location.Y - Panel1.Location.Y + 30)
            DataLocation = DgMoData.Location.Y - Panel2.Location.Y - Panel1.Location.Y + 30
        Else
            Me.DgMoData.Location = New System.Drawing.Point(0, DataLocation - 13)
        End If

    End Sub

    Private Sub FillGridCombox(ByVal ColComboBox As DataGridViewComboBoxColumn)

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        If ColComboBox.Name = "ColDept" Then
            ColComboBox.DataPropertyName = "deptid"
            UserDg = DataHand.GetDataTable("select deptid,(deptid+'---' +djc) djc from m_RunCardDepartment_t where deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='RC10109_' and userid='" & SysMessageClass.UseId & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"

        ElseIf ColComboBox.Name = "ColCustomer" Then
            ColComboBox.DataPropertyName = "CusID"
            UserDg = DataHand.GetDataTable("Select  CusName,CusID from m_RunCardConsumer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "ColLine" Then
            If DgMoData.CurrentRow.Cells(GridColFive).Value = "" Then Exit Sub
            ColComboBox.DataPropertyName = "lineid"
            UserDg = DataHand.GetDataTable("Select  lineid from M_RUNCARDDEPARTMENTLINE_T where deptid='" & DgMoData.CurrentRow.Cells(GridColFive).Value & "'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        End If

    End Sub

    Private Sub LoadDataInGrid(ByVal FiterSqlStr)

        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String
        Dim Flagstr As Boolean

        DgMoData.Rows.Clear()
        DgMoData.ScrollBars = ScrollBars.None
        Sqlstr = "SELECT TOP 10  A.*,B.MOTYPE,C.STATENAME,CUSTPART,D.* FROM M_RUNCARDWORKORDER_T A LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID LEFT JOIN M_MOSTATE_T C ON A.ESTATEID=C.STATEID"

        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        UserDg = DataHand.GetDataTable(Sqlstr & FiterSqlStr)

        For K = 0 To UserDg.Rows.Count - 1
            Try
                If UserDg.Rows(K)("PartID") <> UserDg.Rows(K)("TavcPart") Then
                    Flagstr = True
                End If
                DgMoData.Rows.Add(False, UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)("Partname"), UserDg.Rows(K)("cusid") & "--" & UserDg.Rows(K)("cusname"), "", "", UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("typeid") & "--" & UserDg.Rows(K)("motype"), UserDg.Rows(K)("EstateID") & "--" & UserDg.Rows(K)("statename"), "", UserDg.Rows(K)("cusintime"), UserDg.Rows(K)("TavcPart"))

            Catch ex As Exception
                Continue For
            End Try
        Next


        If Flagstr = True Then
            For Each Row As DataGridViewRow In DgMoData.Rows
                If Row.Cells(GridColTwo).Value = Row.Cells(GridTwe).Value Then
                    DgMoData.Rows.Remove(Row)
                End If
            Next
        End If
        DgMoData.ScrollBars = ScrollBars.Both
        TlelCount.Text = UserDg.Rows.Count
        DataHand = Nothing
        UserDg.Dispose()
    End Sub

    Private Sub DgMoData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellClick

        'If DgMoData.CurrentCell Is Nothing Then Exit Sub
        'If DgMoData.CurrentCell.RowIndex = DgMoData.Rows.Count Then Exit Sub

        'If DgMoData.CurrentCell.ColumnIndex = GridColZero Then
        '    DgMoData.CurrentRow.Cells(GridColZero).Value = Not (DgMoData.CurrentRow.Cells(GridColZero).Value)
        'End If

    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlDataReader

        ScanReader = ScanClass.GetDataReader("select * from motype_t")
        FillComBox.Items.Add("ALL")
        Do While ScanReader.Read()
            FillComBox.Items.Add(ScanReader.GetString(0).ToString & "---" & ScanReader.GetString(1).ToString)
        Loop
        ScanReader.Close()
        FillComBox.Text = FillComBox.Items.Item(0)
        DgMoData.Columns.Item(GridColNine).ReadOnly = False

    End Sub

    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            QueryDataToGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub QueryDataToGrid()

        If Not CheckBasicInput() Then
            Exit Sub
        End If

        Dim OracleObject As New OracleDb("")
        Dim PartCount As New DataTable
        If VbCommClass.VbCommClass.profitcenter <> "" Then
            PartCount = OracleObject.ExecuteQuery(GetSql2Erp(False)).Tables(0)
        Else
            PartCount = OracleObject.ExecuteQuery(GetSql2Erp(True)).Tables(0)
        End If
        If PartCount.Rows.Count > 0 Then
            Me.DgMoData.Rows.Clear()
            Me.DgMoData.Refresh()
            For i As Byte = 0 To PartCount.Rows.Count - 1
                Me.DgMoData.Rows.Add(False, PartCount.Rows.Item(i)("SFB01").ToString, PartCount.Rows.Item(i)("SFB05").ToString, PartCount.Rows.Item(i)("PARTNAME").ToString, PartCount.Rows.Item(i)("TC_IMC03").ToString, PartCount.Rows.Item(i)("SFB82").ToString, PartCount.Rows.Item(i)("SFB08").ToString, PartCount.Rows.Item(i)("SFB02").ToString, PartCount.Rows.Item(i)("SFB04").ToString, PartCount.Rows.Item(i)("CUSTOR").ToString, PartCount.Rows.Item(i)("SFB22").ToString, PartCount.Rows.Item(i)("SFB221").ToString, GetVersion(PartCount.Rows.Item(i)("IMA021").ToString()))
            Next
            ToolSave.Enabled = True
        Else
            LblMsg.Text = "工单编号在ERP中不存在..."
        End If
        FillGridCombox(ColCustomer)
        MesMoDg.Rows.Clear()
    End Sub

    Private Function GetVersion(ByVal version As String) As String
        Dim arr() As String
        'Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]")
        'Dim reg1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[A-Z]{0,2}([0-9]{0,2})?$")
        arr = version.Split("-")
        If arr.Length > 1 Then 'AndAlso Not reg.IsMatch(arr(arr.Length - 1)) And reg1.IsMatch(arr(arr.Length - 1)) Then
            If arr(arr.Length - 1).Length > 5 Then Return ""
            Return arr(arr.Length - 1)
            'ElseIf arr.Length > 2 AndAlso reg1.IsMatch(arr(arr.Length - 2)) Then
            'Return arr(arr.Length - 2)
            'ElseIf arr.Length > 3 AndAlso reg1.IsMatch(arr(arr.Length - 3)) Then
            'Return arr(arr.Length - 3)
            'ElseIf arr.Length > 4 AndAlso reg1.IsMatch(arr(arr.Length - 4)) Then
            'Return arr(arr.Length - 4)
        End If
        Return ""
    End Function

    Private Function GetChildPnByCurrentMoPn(ByVal moPn As String) As DataTable
        Dim oConn As New OracleDb("")
        Return oConn.ExecuteQuery(GetPnSql(moPn)).Tables(0)
    End Function

    Private Function GetPnByInputMo() As String
        Dim oConn As New OracleDb("")
        Using dt As DataTable = oConn.ExecuteQuery(GetPnByInputMoSql(TxtItmnbr.Text)).Tables(0)
            If dt.Rows.Count > 0 Then
                Return GetVersion(dt.Rows(0)(0).ToString)
            End If
        End Using
        Return ""
    End Function

    Private Function GetPnSql(ByVal moPn As String) As String
        Dim pnPrefix As String = moPn.Substring(0, 1)
        Return "SELECT A.BMB03 PN,B.IMA021 VERSION FROM " & VbCommClass.VbCommClass.Factory & ".BMB_FILE A," & VbCommClass.VbCommClass.Factory & ".IMA_FILE B" & _
        " WHERE A.BMB01='" & moPn & "'" & _
        " AND A.BMB19=3" & _
        " AND A.BMB03 LIKE '" & pnPrefix & "%'" & _
        " AND TO_CHAR(A.BMB04,'YYYY/MM/DD')<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR TO_CHAR(A.BMB05,'YYYY/MM/DD')>=TO_CHAR(SYSDATE,'YYYY/MM/DD'))" & _
        " AND A.BMB03=B.IMA01 ORDER BY A.BMB03"
    End Function

    Private Function GetPnByInputMoSql(ByVal pn As String) As String
        ' Return "SELECT IMA01 PN,IMA021 VERSION FROM IMA_FILE WHERE IMA01='" & pn & "'"
        Return "SELECT IMA01 PN,IMA021 VERSION FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & pn & "'"
    End Function

    Private Function CheckPnVersion(ByVal dt As DataTable, ByRef rpn As String) As Boolean
        Dim oConn As SysDataBaseClass = New SysDataBaseClass
        Dim pn As String = Nothing
        Dim index As Integer = 0
        rpn = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            pn += "'" + dt.Rows(i)(0).ToString + "'" + ","
        Next
        pn = pn.Trim(",")
        Using dtPn As DataTable = oConn.GetDataTable("SELECT B.PARTNUMBER PN,DRAWINGVER VERSION FROM M_RUNCARD_T A,M_RUNCARDPARTNUMBER_T B WHERE A.PARTID= B.ID AND B.PARTNUMBER IN(" & pn & ")")
            If dtPn.Rows.Count <= 0 Then
                rpn = pn
                Return False
            End If
            For Each pnr As DataRow In dtPn.Rows
                If dt.Select("PN='" & pnr(0).ToString & "'").Length > 0 Then
                    If GetVersion(dt.Select("PN='" & pnr(0).ToString & "'")(0)(1)) <> pnr(1) Then
                        rpn = pnr(0)
                        Return False
                    End If
                End If
            Next
        End Using
        Return True
    End Function

    Private Function CheckBasicInput() As Boolean
        If TxtMoNo.Text.StartsWith(vbNewLine) Then
            TxtMoNo.Text = TxtMoNo.Text.Substring(TxtMoNo.Text.IndexOf(vbNewLine), TxtMoNo.Text.Trim.Length)
        End If
        If TxtMoNo.Text.EndsWith(vbNewLine) Then
            TxtMoNo.Text = TxtMoNo.Text.Substring(0, TxtMoNo.Text.LastIndexOf(vbNewLine))
        End If
        If TxtMoNo.Text.Trim = "" Then
            LblMsg.Text = "工单编号不能为空..."
            TxtMoNo.Focus()
            Return False
        End If
        If txtDepartment.Text = "" Then
            LblMsg.Text = "部门编号不能为空..."
            txtDepartment.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function GetSql2Erp(ByVal isProfitCenterEmpty As Boolean) As String
        Dim sql As String = ""
        Dim mos As String = Nothing
        For Each sMO As String In TxtMoNo.Text.Trim.Split(vbNewLine)
            If Not String.IsNullOrEmpty(sMO) Then
                mos &= "'" & sMO.ToUpper.Trim & "'" & ","
            End If
        Next
        If Not String.IsNullOrEmpty(mos) Then mos = mos.Trim(",")
        If isProfitCenterEmpty Then
            sql = "SELECT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021 FROM " & _
             VbCommClass.VbCommClass.Factory & ".SFB_FILE," & VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE," & VbCommClass.VbCommClass.Factory & ".IMA_FILE" & _
             " WHERE SFB82=TC_IMC01 AND SFB05=IMA01 AND UPPER(SFB01) IN(" & mos & ") AND UPPER(TC_IMC03)='" & txtDepartment.Text.Trim.ToUpper & "' AND SFB87 = 'Y' "
        Else
            sql = "SELECT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021 FROM " & _
                  VbCommClass.VbCommClass.Factory & ".SFB_FILE," & VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE," & VbCommClass.VbCommClass.Factory & ".IMA_FILE" & _
                  " WHERE SFB82=TC_IMC01 AND SFB05=IMA01 AND UPPER(SFB01) IN(" & mos & ") AND UPPER(TC_IMC03)='" & txtDepartment.Text.Trim.ToUpper & "'" & _
                  " AND SFB87 = 'Y' AND SFBBU = '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        If CboMoType.SelectedValue <> "" Then
            sql = sql & " AND SFB02='" & CboMoType.SelectedValue.ToString & "' "
        End If
        Return sql
    End Function

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

        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        If TxtMoNo.Text.Trim <> "" Then
            SqlStr = " where a.Moid like '%" & TxtMoNo.Text & "%'"
        End If
        If TxtPartID.Text.Trim <> "" And UCase(TxtPartID.Text.Trim) <> "ALL" Then
            If SqlStr = "" Then
                SqlStr = " where a.PartID like '%" & TxtPartID.Text & "%'"
            Else
                SqlStr = SqlStr & " and a.PartID like '%" & TxtPartID.Text & "%'"
            End If
        End If

        If UCase(CboMoType.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(CboMoType)
            If SqlStr = "" Then
                SqlStr = " where a.typeid='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " and a.typeid='" & MoComBoxStr & "'"
            End If
        End If
        If DtpCreatDate.Checked = True Then
            If SqlStr = "" Then
                If DtMoStart.Checked = True Then
                    SqlStr = " where convert(datetime,CONVERT(varchar(10), createtime,120)) between '" & DtMoStart.Value.ToShortDateString & "' and '" & DtpCreatDate.Value.ToShortDateString & "'"
                Else
                    SqlStr = " where convert(datetime,CONVERT(varchar(10), createtime,120))<='" & DtpCreatDate.Value.ToShortDateString & "'"
                End If
            Else
                If DtMoStart.Checked = True Then
                    SqlStr = SqlStr & " and convert(datetime,CONVERT(varchar(10), createtime,120)) between '" & DtMoStart.Value.ToShortDateString & "' and '" & DtpCreatDate.Value.ToShortDateString & "'"
                Else
                    SqlStr = SqlStr & " and convert(datetime,CONVERT(varchar(10), createtime,120))<='" & DtpCreatDate.Value.ToShortDateString & "'"
                End If
            End If
        Else
            If DtMoStart.Checked = True Then
                If SqlStr = "" Then
                    SqlStr = " where convert(datetime,CONVERT(varchar(10), createtime,120))>='" & DtMoStart.Value.ToShortDateString & "'"
                Else
                    SqlStr = SqlStr & " and convert(datetime,CONVERT(varchar(10), createtime,120))>='" & DtMoStart.Value.ToShortDateString & "'"
                End If
            End If

        End If


        Return SqlStr + "  order by TAvcPart desc"

    End Function

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click

        Dim SqlItemStr As New System.Text.StringBuilder
        Dim ExecuteCmd As New SysDataBaseClass
        Dim pnr As String = ""
        DgMoData.EndEdit()

        If Me.ToolCancel.Enabled = True Then
            If Not CheckBasicInputManual() Then
                Exit Sub
            End If
            If Me.TxtparentMo.Text.Trim = "" Then
                MessageBox.Show("必须输入上级工单(包装站工单),如为成品工单则相同...")
                TxtparentMo.Focus()
                Exit Sub
            End If

            Dim ExecuteReader As New SysDataBaseClass
            'Dim CheckReader As SqlDataReader
            Dim ExFlag As Integer = 0
            If CboLine.Text = "" Then
                MessageBox.Show("线别不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If CheckMoExists(TxtMoNumber.Text) Then
                Exit Sub
            End If
            SqlItemStr.Append(" SELECT MOID FROM M_RUNCARDWORKORDER_T ROWLOCK WHERE MOID='" & Trim(TxtMoNumber.Text) & "'")
            SqlItemStr.Append(" DELETE FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & Trim(TxtMoNumber.Text) & "'").Append(vbNewLine)
            SqlItemStr.Append(" INSERT INTO M_RUNCARDWORKORDER_T(MOID,PARTID,CUSID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,PLANDATE").Append(vbNewLine)
            SqlItemStr.Append(",CREATEUSER,CREATETIME,FINALY,FINALMAN,FINALTIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO)").Append(vbNewLine)
            SqlItemStr.Append(" VALUES('" & Trim(TxtMoNumber.Text) & "','" & Trim(TxtItmnbr.Text) & "','" & CboCust.SelectedValue & "',").Append(vbNewLine)
            SqlItemStr.Append("'" & Trim(CboDept.SelectedValue) & "','" & Trim(CboLine.SelectedValue) & "','" & Trim(TxtMoQty.Text) & "','" & ComMoType.SelectedValue & "','1',").Append(vbNewLine)
            SqlItemStr.Append(" GETDATE(),'" & SysMessageClass.UseId.ToLower & "',GETDATE(),'N','" & SysMessageClass.UseId.ToLower & "',GETDATE()").Append(vbNewLine)
            SqlItemStr.Append(",'" & CobFactory.SelectedValue & "','" & VbCommClass.VbCommClass.profitcenter & "','" & TxtparentMo.Text & "','1','" & GetPnByInputMo() & "','')").Append(vbNewLine)
            Using dt As DataTable = GetChildPnByCurrentMoPn(Trim(TxtItmnbr.Text))
                If dt.Rows.Count > 0 Then
                    If chkVersion.Checked = True AndAlso Not CheckPnVersion(dt, pnr) Then
                        MessageBox.Show("料件" + pnr + "的版本不符,请确认！！！")
                        SqlItemStr = Nothing
                        Exit Sub
                    End If
                    SqlItemStr.Append(" DECLARE @MAXSEQ VARCHAR(3)").Append(vbNewLine)
                    SqlItemStr.Append(" IF NOT EXISTS(SELECT 1 FROM M_RUNCARDWORKORDER_T WHERE MOID<>'" & TxtMoNumber.Text & "' AND PARENTMO='" & TxtMoNumber.Text & "')").Append(vbNewLine)
                    SqlItemStr.Append(" SET @MAXSEQ='000'").Append(vbNewLine)
                    SqlItemStr.Append(" ELSE BEGIN SELECT @MAXSEQ=CAST(SUBSTRING(MAX(MOID),LEN(MAX(MOID))-2,3) AS VARCHAR) FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & TxtMoNumber.Text & "'AND MOID<>'" & TxtMoNumber.Text & "' end ").Append(vbNewLine)
                    For i As Integer = 1 To dt.Rows.Count
                        SqlItemStr.Append(" SELECT @MAXSEQ=RIGHT('000'+CAST((@MAXSEQ+" & 1 & ") AS VARCHAR),3)").Append(vbNewLine)
                        SqlItemStr.Append(" INSERT INTO M_RUNCARDWORKORDER_T(MOID,PARTID,CUSID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,PLANDATE").Append(vbNewLine)
                        SqlItemStr.Append(",CREATEUSER,CREATETIME,FINALY,FINALMAN,FINALTIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO)").Append(vbNewLine)
                        SqlItemStr.Append(" SELECT MOID+'-Z'+@MAXSEQ,'" & dt.Rows(i - 1)(0).ToString & "',CUSID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,PLANDATE,CREATEUSER").Append(vbNewLine)
                        SqlItemStr.Append(",CREATETIME,FINALY,FINALMAN,FINALTIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & GetVersion(dt.Rows(i - 1)(1).ToString) & "',ORDERNO FROM M_RUNCARDWORKORDER_T WHERE MOID ='" & TxtMoNumber.Text & "'").Append(vbNewLine)
                    Next
                End If
            End Using '
            Try
                ExecuteCmd.ExecSql(SqlItemStr.ToString())
                Me.ToolNew.Enabled = True
                ToolCancel.Enabled = False
                ToolQuery.Enabled = True
                ToolSave.Enabled = False
                Me.Panel1.Enabled = False : Me.Panel2.Enabled = True
                MessageBox.Show("工单资料保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetMesMoInfo()
                RegisterMoEquipmentJob(TxtMoNumber.Text)
                For Each c As Control In Panel1.Controls
                    If TypeOf c Is TextBox Then
                        c.Text = ""
                    End If
                Next
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If
        DgMoData.EndEdit()
        'Dim pn As String = ""
        Dim mos As String = Nothing
        Dim idx As Integer = 0
        For Each Row As DataGridViewRow In DgMoData.Rows
            If Row.Index = DgMoData.Rows.Count Then Exit For
            'If Row.Cells(GridColZero).Value = True Then
            If Row.Cells(1).Value Is Nothing Then Exit Sub
            If Not Row.Cells(0).FormattedValue Is Nothing AndAlso Row.Cells(0).FormattedValue.ToString = "True" Then
                If CheckMoExists(Row.Cells(1).Value) Then
                    mos += Row.Cells(1).Value + ","
                    Continue For
                End If
                Me.TxtAparentMo.Text = Row.Cells(1).Value
                If Row.Cells("ColLine").Value = "" Then
                    MessageBox.Show("线别不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                SqlItemStr.Append(" SELECT MOID FROM M_RUNCARDWORKORDER_T ROWLOCK WHERE MOID='" & Row.Cells("COMOID").Value & "'").Append(vbNewLine)
                SqlItemStr.Append(" DELETE FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & Row.Cells("COMOID").Value & "'").Append(vbNewLine)
                SqlItemStr.Append(" INSERT INTO M_RUNCARDWORKORDER_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO)").Append(vbNewLine)
                SqlItemStr.Append(" VALUES('" & Row.Cells("COMOID").Value & "','" & Row.Cells("COLPARTID").Value & "','" & Row.Cells("COLDEPT").Value & "','" & Row.Cells("COLLINE").Value & "' ").Append(vbNewLine)
                SqlItemStr.Append(",'" & Row.Cells("COLQTY").Value & "','" & Row.Cells("COLTYPE").Value & "','1','" & Row.Cells("COLCUSTOMER").Value & "',").Append(vbNewLine)
                SqlItemStr.Append(" '" & SysMessageClass.UseId & "',GETDATE(),'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & TxtAparentMo.Text & "','1','" & Row.Cells("ColVersion").Value & "','" & Row.Cells("ColOrderNo").Value & "')").Append(vbNewLine)
                'End If
                'pn = Row.Cells("COLPARTID").Value
                Using dt As DataTable = GetChildPnByCurrentMoPn(Trim(Row.Cells("COLPARTID").Value))
                    If dt.Rows.Count > 0 Then
                        If chkVersion.Checked = True AndAlso Not CheckPnVersion(dt, pnr) Then
                            MessageBox.Show("料件" + pnr + "的版本不符,请确认！！！")
                            SqlItemStr = Nothing
                            Exit Sub
                        End If
                        If idx = 0 Then SqlItemStr.Append(" DECLARE @MAXSEQ VARCHAR(3)").Append(vbNewLine)
                        SqlItemStr.Append(" IF NOT EXISTS(SELECT 1 FROM M_RUNCARDWORKORDER_T WHERE MOID<>'" & Row.Cells("COMOID").Value & "' AND PARENTMO='" & Row.Cells("COMOID").Value & "') ").Append(vbNewLine)
                        SqlItemStr.Append(" SET @MAXSEQ='000' ELSE ").Append(vbNewLine)
                        SqlItemStr.Append(" BEGIN SELECT @MAXSEQ=CAST(SUBSTRING(MAX(MOID),LEN(MAX(MOID))-2,3) AS VARCHAR) FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & TxtMoNo.Text & "'AND MOID<>'" & TxtMoNo.Text & "' end ").Append(vbNewLine)
                        For i As Integer = 1 To dt.Rows.Count
                            SqlItemStr.Append(" SELECT @MAXSEQ=RIGHT('000'+CAST((@MAXSEQ+" & 1 & ") AS VARCHAR),3)").Append(vbNewLine)
                            SqlItemStr.Append(" INSERT INTO M_RUNCARDWORKORDER_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO)").Append(vbNewLine)
                            SqlItemStr.Append(" SELECT MOID+'-Z'+@MAXSEQ,'" & dt.Rows(i - 1)(0).ToString & "',DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & GetVersion(dt.Rows(i - 1)(1).ToString) & "',ORDERNO FROM M_RUNCARDWORKORDER_T WHERE MOID='" & Row.Cells("COMOID").Value & "'").Append(vbNewLine)
                        Next
                        idx += 1
                    End If
                End Using
            End If
        Next
        'Using dt As DataTable = GetChildPnByCurrentMoPn(Trim(pn))
        '    If dt.Rows.Count > 0 Then
        '        If chkVersion.Checked = True AndAlso Not CheckPnVersion(dt, pnr) Then
        '            MessageBox.Show("料件" + pnr + "的版本不符,请确认！！！")
        '            SqlItemStr = Nothing
        '            Exit Sub
        '        End If
        '        SqlItemStr.Append(" DECLARE @MAXSEQ VARCHAR(3)").Append(vbNewLine)
        '        SqlItemStr.Append(" IF NOT EXISTS(SELECT 1 FROM M_MAINMO_T WHERE MOID<>'" & TxtMoNo.Text & "' AND PARENTMO='" & TxtMoNo.Text & "') ").Append(vbNewLine)
        '        SqlItemStr.Append(" SET @MAXSEQ='000' ELSE ").Append(vbNewLine)
        '        SqlItemStr.Append(" BEGIN SELECT @MAXSEQ=CAST(SUBSTRING(MAX(MOID),LEN(MAX(MOID))-2,3) AS VARCHAR) FROM M_MAINMO_T WHERE PARENTMO='" & TxtMoNo.Text & "'AND MOID<>'" & TxtMoNo.Text & "' end ").Append(vbNewLine)
        '        For i As Integer = 1 To dt.Rows.Count
        '            SqlItemStr.Append(" SELECT @MAXSEQ=RIGHT('000'+CAST((@MAXSEQ+" & 1 & ") AS VARCHAR),3)").Append(vbNewLine)
        '            SqlItemStr.Append(" INSERT INTO M_MAINMO_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO)").Append(vbNewLine)
        '            SqlItemStr.Append(" SELECT MOID+'-Z'+@MAXSEQ,'" & dt.Rows(i - 1)(0).ToString & "',DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & GetVersion(dt.Rows(i - 1)(1).ToString) & "',ORDERNO FROM M_MAINMO_T WHERE MOID='" & TxtMoNo.Text & "'").Append(vbNewLine)
        '        Next
        '    End If
        'End Using
        If Not String.IsNullOrEmpty(mos) Then
            mos = mos.Trim
            LblMsg.Text = "{" & mos & "}工单已存在或在有子工单在制程中！！！"
        End If
        If SqlItemStr.Length = 0 Then
            MessageBox.Show("请选择要下载的工单")
            Exit Sub
        End If

        Try
            ExecuteCmd.ExecSql(SqlItemStr.ToString)
            ToolSave.Enabled = False
            MessageBox.Show("工单资料保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'GetMesMoInfo()
            'RegisterMoEquipmentJob(TxtMoNo.Text)
            Exit Sub
        Catch ex As Exception
            'Moreader.Close()
            'Moreader.Dispose()
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GetMesMoInfo()
        Dim sConn As New SysDataBaseClass
        Using dt As DataTable = sConn.GetDataTable(GetMesMoSql)
            If dt.Rows.Count > 0 Then
                Me.MesMoDg.Rows.Clear()
                Me.MesMoDg.Refresh()
                For i As Byte = 0 To dt.Rows.Count - 1
                    Me.MesMoDg.Rows.Add(False, dt.Rows.Item(i)("MOID").ToString, dt.Rows.Item(i)("PARTID").ToString, dt.Rows.Item(i)("DEPTID").ToString, dt.Rows.Item(i)("LINEID").ToString, dt.Rows.Item(i)("MOQTY").ToString, dt.Rows.Item(i)("TYPEID").ToString, dt.Rows.Item(i)("ESTATEID").ToString, dt.Rows.Item(i)("CUSID").ToString, dt.Rows.Item(i)("ORDERNO").ToString, dt.Rows.Item(i)("VERSION").ToString, dt.Rows.Item(i)("PARENTMO").ToString)
                Next
            End If
        End Using
    End Sub

    Private Function GetMesMoSql()
        Dim sql As String = "SELECT TOP 600 MOID,PARTID,DEPTID,LINEID,MOQTY,A.TYPEID+'.'+MOTYPE AS TYPEID,ESTATEID+'.'+STATENAME" & _
" AS ESTATEID,CUSID,VERSION,ORDERNO,PARENTMO FROM M_RUNCARDWORKORDER_T A LEFT JOIN M_MOSTATE_T ON A.ESTATEID=STATEID" & _
" LEFT JOIN MOTYPE_T B ON A.TYPEID=B.TYPEID"
        If TxtMoNumber.Text <> "" Then
            sql += " WHERE MOID = '" & TxtMoNumber.Text & "' OR MOID LIKE '" & TxtMoNumber.Text & "-Z%'"
        ElseIf TxtMoNo.Text <> "" Then
            Dim mos As String = Nothing
            For Each sMO As String In TxtMoNo.Text.Trim.Split(vbNewLine)
                If Not String.IsNullOrEmpty(sMO) Then
                    mos &= "'" & sMO.ToUpper.Trim & "'" & ","
                End If
            Next
            If Not String.IsNullOrEmpty(mos) Then mos = mos.Trim(",")
            sql += " WHERE PARENTMO IN( " & mos & ")"
        End If
        sql += " ORDER BY MOID"
        Return sql
    End Function

    Private Function CheckMoExists(ByVal mo As String) As Boolean
        Dim ExecuteCmd As New SysDataBaseClass
        If ExecuteCmd.GetRowsCount("SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & Trim(mo) & "'AND ESTATEID NOT IN(1,3)") > 0 Then
            LblMsg.Text = "{" & mo & "}工单已存在或其可能存在已分批或在制程中或已完工结案的子工单！！！"
            Return True
        End If
        Return False
    End Function

    Private Function CheckBasicInputManual() As Boolean
        If TxtMoNumber.Text = "" Then
            MessageBox.Show("请输入工单号！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtMoNumber.Select()
            Return False
        End If
        If TxtItmnbr.Text.ToCharArray = "" Then
            MessageBox.Show("请输入料件编号！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtItmnbr.Select()
            Return False
        End If
        If TxtMoQty.Text = "" Or Not IsNumeric(TxtMoQty.Text) Then
            MessageBox.Show("请输入工单数量并且为整数！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtMoQty.Select()
            Return False
        End If
        If CboLine.SelectedValue = Nothing Or CboLine.SelectedValue = "" Then
            MessageBox.Show("请选择线别！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CboLine.Select()
            Return False
        End If
        Return True
    End Function

    Private Function GetSqlstring(ByVal Flag As Boolean) As String
        Flag = False
        Dim I As Integer
        Dim K As Integer
        Dim J As Integer
        Dim ExFlag As Integer = 0
        Dim EigStr As String
        Dim LineStr As String
        Dim SqlStr As String = ""
        Dim FourStr As String
        Dim mostr As String
        Dim Exmoldid As String = "X"
        Dim ExmoldidAsc As Integer = Asc("X")
        GetSqlstring = ""
        DgMoData.EndEdit()
        For Each Row As DataGridViewRow In DgMoData.Rows
            If Row.Index = DgMoData.Rows.Count Then Exit For
            If Row.Cells(GridColZero).Value = True Then
                If Row.Cells(1).Value Is Nothing Then Exit Function
                I = InStr(Row.Cells(GridColEig).Value, "-")
                LineStr = Row.Cells(GridColEig).Value.Substring(0, I - 1)
                K = InStr(Row.Cells(GridColNine).Value, "-")
                EigStr = Row.Cells(GridColNine).Value.Substring(0, K - 1)
                J = InStr(Row.Cells(GridColFour).Value, "-")
                FourStr = Row.Cells(GridColFour).Value.Substring(0, J - 1)
                ''If UCase(Trim(Row.Cells(GridColOne).Value).Substring(0, 2)) = "WO" Then
                ''    factoryStr = "SZ"
                ''Else
                ''    factoryStr = "CN"
                ''End If
                If Flag Then
                    If ExFlag = 0 Then SqlStr = SqlStr & vbCrLf & "update M_RUNCARDWORKORDER_T set partid='" & Row.Cells("ColPartid").Value & "',cusid='" & FourStr & "',Deptid='" & Row.Cells("ColDept").Value & "',lineid='" & Row.Cells("ColLine").Value & "',Createuser='" & SysMessageClass.UseId & "',Createtime=getdate() where Moid='" & Row.Cells(GridColOne).Value & "'"
                Else
                    If ExFlag = 0 Then SqlStr = SqlStr & vbCrLf & "delete M_RUNCARDWORKORDER_T where Moid='" & Row.Cells(GridColOne).Value & "'" & vbCrLf & "insert into M_RUNCARDWORKORDER_T(Orderseq,Moid,Tmoid,PartID,Cusid,Deptid,lineid,Moqty,Outqty,Notqty" & _
                    ",Scrapqty,Typeid,EstateID,Routeid,Plandate,Createuser,Createtime,FinalY,Finalqty,Remark,Finalman,Finaltime)" & _
                    " values('','" & Row.Cells(GridColOne).Value & "','','" & Row.Cells(GridColTwo).Value & "','" & FourStr & "'," & _
                    "'" & Row.Cells(GridColFive).Value & "','" & Row.Cells(GridColSix).Value & "','" & Row.Cells(GridColServ).Value & "',0,0,0,'" & LineStr & "'," & _
                    "'" & EigStr & "','" & Row.Cells(GridColTen).Value & "',null,'" & SysMessageClass.UseId & "'," & _
                    "getdate(),'N',0,'','',null)"
                End If
                If Row.Cells(GridColTwo).Value <> Row.Cells(GridTwe).Value Then
                    'mostr = Row.Cells(GridColOne).Value & "-X"
                    Exmoldid = Chr(ExmoldidAsc + ExFlag)
                    mostr = Row.Cells(GridColOne).Value & "-" & Exmoldid
                    ExFlag = ExFlag + 1
                    If Flag Then
                        ''SqlStr = SqlStr & vbCrLf & "update m_Mainmo_t set Deptid='" & Row.Cells("ColDept").Value & "',lineid='" & Row.Cells("ColLine").Value & "' where Moid='" & Row.Cells(GridColOne).Value & "'"
                        SqlStr = SqlStr & vbCrLf & "update M_RUNCARDWORKORDER_T set Deptid='" & Row.Cells("ColDept").Value & "',lineid='" & Row.Cells("ColLine").Value & "' where Moid='" & mostr & "'"
                    Else
                        SqlStr = SqlStr & vbCrLf & "delete M_RUNCARDWORKORDER_T where Moid='" & mostr & "'"
                        SqlStr = SqlStr & vbCrLf & "insert into M_RUNCARDWORKORDER_T(Orderseq,Moid,Tmoid,PartID,Cusid,Deptid,lineid,Moqty,Outqty,Notqty" & _
                       ",Scrapqty,Typeid,EstateID,Routeid,Plandate,Createuser,Createtime,FinalY,Finalqty,Remark,Finalman,Finaltime)" & _
                       " values('','" & mostr & "','','" & Row.Cells(GridTwe).Value & "','" & FourStr & "'," & _
                       "'" & Row.Cells(GridColFive).Value & "','" & Row.Cells(GridColSix).Value & "','" & Row.Cells(GridColServ).Value & "',0,0,0,'" & LineStr & "'," & _
                        "'" & EigStr & "','" & Row.Cells(GridColTen).Value & "',null,'" & SysMessageClass.UseId & "'," & _
                        "getdate(),'N',0,'','',null)"
                    End If
                End If
            End If
        Next
        Return SqlStr

    End Function

    Private Sub CboMoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoType.TextChanged

        If ComboxFlag = False Then
            ComboxFlag = True
            Exit Sub
        Else
            DgMoData.Rows.Clear()
            TlelCount.Text = "0"
        End If

    End Sub

    Private Sub DtpCreatDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpCreatDate.KeyPress

        QueryDataToGrid()

    End Sub

    Private Sub DtpCreatDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpCreatDate.ValueChanged

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub TxtMoNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpCreatDate.ValueChanged

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub TxtPartID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPartID.TextChanged

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub DtMoStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtMoStart.ValueChanged

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub DgMoData_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellLeave

        If DgMoData.CurrentCell.ColumnIndex = GridColFive Then
            DgMoData.EndEdit()
            'FillGridCombox(ColLine)
        End If

    End Sub

    Private Sub DgMoData_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgMoData.DataError
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Try
            QueryDataToGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click

        ''SysMessageClass.EditFlag = False
        DgMoData.Rows.Clear() : TlelCount.Text = "0"
        ToolNew.Enabled = False
        ''ToolEdit.Enabled = False
        ToolQuery.Enabled = False
        ToolCancel.Enabled = True
        ComMoType.SelectedIndex = -1
        CboDept.SelectedIndex = -1
        CboCust.SelectedIndex = -1
        CboLine.SelectedIndex = -1

        Me.Panel1.Enabled = True
        Me.Panel2.Enabled = False
        Me.TxtMoNumber.Clear() : Me.TxtItmnbr.Clear() : Me.TxtMoQty.Clear()
        Me.TxtMoNumber.Focus()
        TxtMoNo.Text = ""
        txtDepartment.Text = ""
        TxtAparentMo.Text = ""
        CboMoType.SelectedValue = ""
        ToolSave.Enabled = True
    End Sub

    Private Sub TxtMoQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoQty.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
        If Me.TxtMoQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click

        ToolNew.Enabled = True
        '' ToolEdit.Enabled = True
        ToolQuery.Enabled = True
        ToolCancel.Enabled = False
        Me.Panel1.Enabled = False
        Me.Panel2.Enabled = True
        Me.TxtMoNo.Focus()
        ''  ResetFormContol()

    End Sub

    ''Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click

    ''SysMessageClass.EditFlag = True
    ''TxtMoNumber.Enabled = False
    ''ToolNew.Enabled = False
    ''ToolEdit.Enabled = False
    ''ToolQuery.Enabled = False
    ''ToolCancel.Enabled = True
    ''Me.Panel1.Enabled = True
    ''Me.Panel2.Enabled = False
    ''Me.TxtItmnbr.Focus()

    ''End Sub

    Private Sub TxtMoNo_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoNo.TextChanged

        DgMoData.Rows.Clear()
        TlelCount.Text = "0"

    End Sub

    Private Sub TxtMoNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoNumber.KeyPress, TxtItmnbr.KeyPress, CboCust.KeyPress, TxtMoQty.KeyPress, CboDept.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
        End If

    End Sub

    Private Sub CboLine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboLine.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            TxtMoNumber.Focus()
        End If

    End Sub

    Private Sub CobFactory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobFactory.LostFocus

        CboLine.DataSource = Nothing
        CboDept.DataSource = Nothing
        FillCombox(CboDept)
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
    End Sub

    'Private Sub CobFactory_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobFactory.Leave
    '    CboDept.SelectedIndex = -1
    '    CboLine.SelectedIndex = -1
    '    CboLine.DataSource = Nothing
    '    CboDept.DataSource = Nothing
    '    FillCombox(CboDept)
    'End Sub

    'Private Sub CboDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.Leave

    '    CboLine.DataSource = Nothing
    '    FillCombox(CboLine)

    'End Sub

    Private Sub CboDept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.LostFocus

        CboLine.DataSource = Nothing
        FillCombox(CboLine)
        CboLine.SelectedIndex = -1
    End Sub

    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobFactory.SelectedIndexChanged
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
    End Sub

    Private Sub CboDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.SelectedIndexChanged
        CboLine.SelectedIndex = -1
    End Sub

    Public Sub RegisterMoEquipmentJob(ByVal moid As String)
        'Dim sConn As New SysDataBaseClass

        'Using dt As DataTable = sConn.GetDataTable("SELECT MOID FROM M_MAINMO_T WHERE MOID='" & moid & "'")
        '    If dt.Rows.Count <= 0 Then
        '        MessageBox.Show("工单不存在", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    End If
        'End Using
        'Dim sql As String = "IF EXISTS(SELECT 1 FROM M_MAINMO_T WHERE MOID<>'" & moid & "' AND PARENTMO='" & moid & "')" & vbNewLine & _
        '" BEGIN " & vbNewLine & _
        '" INSERT INTO M_MOEQUIPMENTREQUESTJOB_T(MOID,PARTID,PARENTMOID,INTIME,LINEID,STATUS) " & vbNewLine & _
        '" SELECT A.MOID,A.PARTID,A.PARENTMO,GETDATE(),A.LINEID,0 FROM M_MAINMO_T A " & vbNewLine & _
        '" WHERE A.PARENTMO='" & moid & "' AND A.MOID<>'" & moid & "'" & vbNewLine & _
        '" AND NOT EXISTS(SELECT MOID FROM M_MOEQUIPMENTREQUESTJOB_T WHERE MOID=A.MOID AND STATUS=0) " & vbNewLine & _
        '" END" & vbNewLine & _
        '" ELSE" & vbNewLine & _
        '" BEGIN " & vbNewLine & _
        '" INSERT INTO M_MOEQUIPMENTREQUESTJOB_T(MOID,PARTID,PARENTMOID,INTIME,LINEID,STATUS)" & vbNewLine & _
        '" SELECT A.MOID,A.PARTID,A.PARENTMO,GETDATE(),A.LINEID,0 FROM M_MAINMO_T A " & vbNewLine & _
        '" WHERE A.PARENTMO='" & moid & "' AND A.MOID='" & moid & "'" & vbNewLine & _
        '" AND NOT EXISTS(SELECT MOID FROM M_MOEQUIPMENTREQUESTJOB_T WHERE MOID=A.MOID AND STATUS=0) " & vbNewLine & _
        '" END"
        'sConn.ExecuteNonQuery(sql)
    End Sub

    Private Sub ChkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAll.CheckedChanged
        For Each row As DataGridViewRow In DgMoData.Rows
            row.Cells(GridColZero).Value = ChkAll.Checked
        Next
    End Sub
End Class





