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

Public Class FrmStdTime
    Public opflag As Int16 = 0  '
    Private _stationId_Name As String

    ' add by 马跃平 2018-03-07
    Private StationID As String  '工站编号
    Private StationName As String '工站名称

    Private Enum enumdgvStdTime
        ID = 0 'PK
        Stationid ' 工站编号
        StationName '工站名称
        VariableMin '变量项最小值
        VariableMax '变量项最大值
        FinishSizeMin '成品尺寸最小值
        FinishSizeMax '成品尺寸最大值
        StandardHour '标准工时
        FinishSizeAdd '长度加项
        WorkHour '总标准工时
        UserID '设置人员
        InTime '设置时间
    End Enum
    Sub New(ByVal stationId_Name As String)
        _stationId_Name = stationId_Name
        InitializeComponent()
    End Sub

    ' add by 马跃平 2017-03-07
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_StationID">工站编号</param>
    ''' <param name="_StationName">工站名称</param>
    ''' <remarks></remarks>
    Sub New(ByVal _StationID As String, ByVal _StationName As String)
        StationID = _StationID
        StationName = _StationName
        _stationId_Name = StationID + "-" + StationName
        InitializeComponent()
    End Sub

    Private Sub BtnSelectSta_Click(sender As Object, e As EventArgs) Handles BtnSelectSta.Click
        Dim frm As New FrmRStationSet
        Try
            frm.opflag = 3
            frm.ShowDialog()
            Me.txtStationid.Text = frm.frmRstationid + "-" + frm.frmRstationname
        Catch ex As Exception
        Finally
            frm = Nothing
        End Try
    End Sub

    Private Sub FrmStdTime_Load(sender As Object, e As EventArgs) Handles Me.Load
        Erightbutton() '
        bindProductType()
        Me.txtStationid.Text = _stationId_Name
        LoadDataToDatagridview(" WHERE 1=1 and a.stationid like '%" & _stationId_Name.Trim.Split("-")(0) & "'")
        ToolbtnState(opflag)
        Me.LblMsg.Text = ""
        ControlIsEnable(False)
    End Sub

    '共用工站维护的权限
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Try
            Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
            Dim Obj As Object
            While Reader.Read
                Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            End While
            Reader.Close()
            Conn.PubConnection.Close()
            Conn = Nothing
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click

        '只有工站、是否含变量项，能够作为查询条件
        Dim flag As Boolean = False
        Dim Sql As String = "WHERE 1=1"

        If Me.chkVariable.Checked Then
            Sql = Sql & " AND a.ExistVariables= 1 "
        End If
        If Me.txtStationid.Text.Trim <> "" Then
            Sql = Sql & " AND a.Stationid like '" & Me.txtStationid.Text.Trim.Split("-")(0) & "%' "
        End If
        bindProductType()
        LoadDataToDatagridview(Sql)
    End Sub

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        Try
            'dgvStdTime.Rows.Clear()

            SqlStr = " SELECT a.id, a.stationid, b.StationName, A.ProductTypeID+'-'+D.ProductType as ProductType, a.VariableMin,VariableMax,FinishSizeMin, " & _
                     " FinishSizeMax,StandardHour,FinishSizeAdd,WorkHour," & _
                     " ISNULL(c.UserName, a.userid) AS Userid,a.InTime" & _
                     " FROM m_RstationWorkHour_t a  " & _
                     " left join  ProductType_t d on d.ProductTypeID=a.ProductTypeID" & _
                     " LEFT JOIN m_Rstation_t b ON a.stationid = b.stationid " & _
                     " LEFT JOIN m_Users_t c ON  a.userid= c.userid " & SqlWhere
            dgvStdTime.AutoGenerateColumns = False
            dgvStdTime.DataSource = MainFrame.DbOperateUtils.GetDataTable(SqlStr)
            'Dreader = Conn.GetDataReader(SqlStr & " ORDER BY a.stationid,a.VariableMin ")
            'Do While Dreader.Read()
            '    '工站编号,工站名称,变量项最小值,变量项最大值,成品尺寸最小值,成品尺寸最大值, 标准工时() 长度加项()总标准工时()设置人员()设置时间()
            '    dgvStdTime.Rows.Add(Dreader.Item(enumdgvStdTime.ID).ToString, Dreader.Item(enumdgvStdTime.Stationid).ToString, Dreader.Item(enumdgvStdTime.StationName).ToString, Dreader.Item(enumdgvStdTime.VariableMin).ToString, _
            '    Dreader.Item(enumdgvStdTime.VariableMax).ToString, Dreader.Item(enumdgvStdTime.FinishSizeMin).ToString, Dreader.Item(enumdgvStdTime.FinishSizeMax).ToString,
            '    Dreader.Item(enumdgvStdTime.StandardHour).ToString, _
            '    Dreader.Item(enumdgvStdTime.FinishSizeAdd).ToString, Dreader.Item(enumdgvStdTime.WorkHour).ToString, _
            '    Dreader.Item(enumdgvStdTime.UserID).ToString, Dreader.Item(enumdgvStdTime.InTime).ToString)
            'Loop
            'Dreader.Close()
            Me.TlelCount.Text = Me.dgvStdTime.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            Conn.PubConnection.Close()
            Conn = Nothing
        End Try

    End Sub

    Private Sub ControlIsEnable(ByVal yy As Boolean)
        txtStationid.Enabled = yy
        cmbProductType.Enabled = yy
        txtStdTime.Enabled = yy
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        ' Me.txtStationName.Text = ""
        bindProductType()
        Me.txtNewStationID.Enabled = False : Me.btnSelectDestSta.Enabled = False
        Me.chkVariable.Enabled = True
        Me.txtNewStationID.ReadOnly = True
        ' txtStationid.Text = "" 'Mark by CQ 20151027
        Me.txtNewStationID.Text = ""
        Me.txtStdTime.Text = "" : Me.txtAdd.Text = ""
        txtVarMin.Text = ""
        txtVarMax.Text = ""
        txtFinishMin.Text = ""
        txtFinishMax.Text = ""
        cmbProductType.SelectedIndex = -1

        cmbProductType.Text = ""
        ControlIsEnable(True)
        opflag = 1
        ToolbtnState(1)
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolDelete.Enabled = True 'IIf(Me.toolDelete.Tag.ToString <> "Yes", False, True)  '借用 
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.ToolCopy.Enabled = True
                'GroupBox
                '  Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.ActiveControl = Me.txtStationid
                Me.dgvStdTime.Enabled = True

            Case 1, 2  'New or Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolDelete.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.ToolCopy.Enabled = False
                'GroupBox
                '  Me.txtStationdest.Enabled = True
                '  Me.cboType.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = False
                Me.BtnSelectSta.Enabled = IIf(opflag = 1, True, False)
                'Me.dgvStdTime.Enabled = False
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolDelete.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                ' Me.cboType.Enabled = True
                Me.txtStationid.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
        End Select
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As New StringBuilder
        Dim o_strTotalStdTime As String = "", o_strSqlVarMin As String = "", o_strSqlVarMax As String = "", o_strSqlFinishSizeMax As String = ""
        Dim o_ColFinishMax As String = "", o_ValueOfFinishMax As Object = Nothing
        Dim o_ColVarMin As String = "", o_ValueOfVarMin As Object = Nothing
        Dim o_ColVarMax As String = "", o_ValueOfVarMax As Object = Nothing
        Me.lblmsg.Text = ""

        Dim yy As Double = 1
        Dim culcResult As Boolean = Double.TryParse(txtStdTime.Text.Trim, yy)
        If culcResult = False Then
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "标准工时必须是数字类型"
            ActiveControl = txtStdTime
            Exit Sub
        End If
        If Convert.ToDouble(txtStdTime.Text.Trim < 0) Then
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "标准工时必须大于0"
            ActiveControl = txtStdTime
            Exit Sub
        End If

        If cmbProductType.SelectedValue = Nothing Then
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "请选择产品类型"
            Exit Sub
        End If

        'If Checkdata() = False Then Exit Sub

        If Not String.IsNullOrEmpty(Me.txtAdd.Text.Trim()) Then
            o_strTotalStdTime = (Me.txtStdTime.Text.Trim() & "+" & Me.txtAdd.Text.Trim()).Replace("（", "(").Replace("）", ")").Replace("\", "/")
        Else
            o_strTotalStdTime = (Me.txtStdTime.Text.Trim()).Replace("（", "(").Replace("）", ")").Replace("\", "/")
        End If

        If opflag = 1 Then  'New Save
            '   复制工站不可编辑。
            '	修改时，不可更改是否勾选“含变量项”。
            '	同一工站，必须都勾选或都被勾选“含变量项”：以第一笔资料为准，新增第2+笔，不可更改是否勾选“变量项”。
            '	勾选“含变量项”时：①允许填变量项最大最小值；②成品尺寸最小值为0，不可编辑。
            '	不勾选“含变量项”时：①不允许填变量项最大最小值（清空）；②允许填成品尺寸最大最小值。
            '	标准工时：只能带X变量，或者不带变量(保存时记得左右括号、除法符号，替换为SQL可识别的可计算的英文符号)。
            '	长度加项：只能带L变量，或者不带变量(保存时记得左右括号、除法符号，替换为SQL可识别的可计算的英文符号)。
            '	总标准工时=标准工时+长度加项
            '变量项X（线径/PIN数/剥皮长度等）成品尺寸mm	    标准工时	               长度加项	            总标准工时	                            工艺备注
            'X＞1400	                    L≤500	        83+20*（X-1400）/300	    0.4*（L-500）/1000	 83+20*（X-1400）/300+0.4*（L-500）/1000	 两次剥

            Dim sql As String = String.Format("select * from m_RstationWorkHour_t where Stationid='{0}' and ProductTypeID=N'{1}'", StationID, cmbProductType.SelectedValue)
            If MainFrame.DbOperateUtils.GetRowsCount(sql) > 0 Then
                LblMsg.ForeColor = Color.Red
                LblMsg.Text = "工站:" + StationName + ",只能对应一个产品类型:" + cmbProductType.Text.Trim()
                Me.ActiveControl = cmbProductType
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(Me.txtVarMin.Text.Trim()) Then
                o_ColVarMin = "VariableMin,"
                o_ValueOfVarMin = Me.txtVarMin.Text + ","
            Else
                o_ColVarMin = ""
                o_ValueOfVarMin = DBNull.Value
            End If

            If Not String.IsNullOrEmpty(Me.txtVarMax.Text.Trim()) Then
                o_ColVarMax = "VariableMax,"
                o_ValueOfVarMax = Me.txtVarMax.Text + ","
            Else
                o_ColVarMax = ""
                o_ValueOfVarMax = DBNull.Value
            End If

            If Not String.IsNullOrEmpty(Me.txtFinishMax.Text.Trim()) Then
                o_ColFinishMax = "FinishSizeMax,"
                o_ValueOfFinishMax = Me.txtFinishMax.Text + ","
            Else
                o_ColFinishMax = ""
                o_ValueOfFinishMax = DBNull.Value
            End If

            o_strTotalStdTime = (Me.txtStdTime.Text.Trim() & "+" & Me.txtAdd.Text.ToUpper().Trim()).Replace("（", "(").Replace("）", ")").Replace("\", "/")
            SqlStr.Append(" INSERT into m_RstationWorkHour_t")
            SqlStr.Append(" (Stationid,ExistVariables," & o_ColVarMin & " " & o_ColVarMax & "FinishSizeMin, " & o_ColFinishMax & "")
            SqlStr.Append(" StandardHour,FinishSizeAdd,WorkHour,UserID, InTime,ProductTypeid)")
            SqlStr.Append(" Values( '" & StationID & "', '" & IIf(Me.chkVariable.Checked = True, 1, 0) & "',")
            SqlStr.Append(" " & o_ValueOfVarMin & "")
            SqlStr.Append(" " & o_ValueOfVarMax & "")
            SqlStr.Append(" '" & Me.txtFinishMin.Text.Trim() & "', " & o_ValueOfFinishMax & "")
            SqlStr.Append(" '" & Me.txtStdTime.Text.ToUpper.Trim() & "', '" & Me.txtAdd.Text.ToUpper.Trim() & "',")
            SqlStr.Append(" '" & o_strTotalStdTime & "',")
            SqlStr.Append(" '" & SysMessageClass.UseId.ToLower.Trim & "', getdate(),N'" + cmbProductType.SelectedValue + "')")
        ElseIf opflag = 2 Then ' Update save

            If String.IsNullOrEmpty(Me.txtVarMin.Text) Then
                o_strSqlVarMin = "VariableMin = NULL"
            Else
                o_strSqlVarMin = " VariableMin = N'" & Me.txtVarMin.Text.Trim() & "'"
            End If

            If String.IsNullOrEmpty(Me.txtVarMax.Text) Then
                o_strSqlVarMax = "VariableMax = NULL"
            Else
                o_strSqlVarMax = " VariableMax = N'" & Me.txtVarMax.Text.Trim() & "'"
            End If

            If String.IsNullOrEmpty(Me.txtFinishMax.Text) Then
                o_strSqlFinishSizeMax = "FinishSizeMax = NULL"
            Else
                o_strSqlFinishSizeMax = " FinishSizeMax = N'" & Me.txtFinishMax.Text.Trim() & "'"
            End If

            SqlStr.Append("UPDATE m_RstationWorkHour_t set ") 'VariableMin =N'" & Me.txtVarMin.Text.Trim() & "',")
            SqlStr.Append(" " & o_strSqlVarMin & ", ")
            SqlStr.Append(" " & o_strSqlVarMax & ", ")
            SqlStr.Append("  FinishSizeMin='" & Me.txtFinishMin.Text.Trim() & "', ")
            SqlStr.Append(" " & o_strSqlFinishSizeMax & ",")
            SqlStr.Append("userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate(), ")
            SqlStr.Append("StandardHour='" & Me.txtStdTime.Text.ToUpper.Replace("（", "(").Replace("）", ")").Replace("\", "/") & "', ")
            SqlStr.Append(" FinishSizeAdd='" & Me.txtAdd.Text.ToUpper.Replace("（", "(").Replace("）", ")").Replace("\", "/") & "',")
            SqlStr.Append(" WorkHour='" & o_strTotalStdTime & "',")
            SqlStr.Append("ProductTypeid=N'" + cmbProductType.SelectedValue + "'")
            SqlStr.Append("where ID = '" & dgvStdTime.Item(enumdgvStdTime.ID, Me.dgvStdTime.CurrentRow.Index).Value & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            Conn.PubConnection.Close()
            LoadDataToDatagridview("  WHERE a.Stationid='" & StationID & "'")

            '' Me.txtStationid.Text = "" '默认不清掉
            'Me.txtVarMin.Text = "" : Me.txtVarMax.Text = "" : Me.chkVariable.Checked = False
            'Me.txtFinishMin.Text = "" : Me.txtFinishMax.Text = ""
            'Me.txtStdTime.Text = "" : Me.txtAdd.Text = ""
            'Me.LblMsg.Text = ""
            opflag = 0
            ToolbtnState(0)
            ControlIsEnable(False)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmStdTime", "toolSave_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Function Checkdata() As Boolean
        'If Me.cboType.Text.Trim = "" Then
        '    Me.ActiveControl = Me.cboType
        '    Return False
        'End If
        If String.IsNullOrEmpty(Me.txtAdd.Text) Then
            Me.ActiveControl = Me.txtAdd
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "必须填写长度加项!"
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtStdTime.Text) Then
            Me.ActiveControl = Me.txtStdTime
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "必须填写标准工时!"
            Return False
        Else
            If Val(Me.txtStdTime.Text.Trim()) <= 0 Then
                LblMsg.ForeColor = Color.Red
                LblMsg.Text = "标准工时必须大于0!"
                Return False
            End If
        End If

        If Me.txtFinishMin.Text <> "" AndAlso Me.txtFinishMax.Text <> "" Then
            If Val(Me.txtFinishMin.Text) > Val(Me.txtFinishMax.Text) Then
                Me.ActiveControl = Me.txtFinishMax
                LblMsg.ForeColor = Color.Red
                LblMsg.Text = "成品尺寸范围填写错误!"
                Return False
            End If
        End If

        If Me.txtVarMin.Text <> "" AndAlso Me.txtVarMax.Text <> "" Then
            If Val(Me.txtVarMin.Text) > Val(Me.txtVarMax.Text) Then
                LblMsg.ForeColor = Color.Red
                LblMsg.Text = "变量项范围填写错误!"
                Me.ActiveControl = Me.txtVarMax
                Return False
            End If
        End If

        If Me.txtStdTime.Text <> "" Then
            For Each o_object As Char In Me.txtStdTime.Text
                If (o_object >= "a" AndAlso o_object <= "z") OrElse (o_object >= "A" AndAlso o_object <= "Z") Then
                    If o_object <> "X" AndAlso o_object <> "x" Then
                        LblMsg.ForeColor = Color.Red
                        LblMsg.Text = "标准工时的变量只能是字母[X],填写错误!"
                        Me.ActiveControl = Me.txtStdTime
                        Return False
                    End If
                End If
            Next
        End If

        If Me.txtAdd.Text <> "" Then
            For Each o_object As Char In Me.txtAdd.Text
                If (o_object >= "a" AndAlso o_object <= "z") OrElse (o_object >= "A" AndAlso o_object <= "Z") Then
                    If o_object <> "L" AndAlso o_object <> "l" Then
                        LblMsg.ForeColor = Color.Red
                        LblMsg.Text = "长度加项的字母只能是固定字母[L],填写错误!"
                        Me.ActiveControl = Me.txtAdd
                        Return False
                    End If
                End If
            Next
        End If
        If String.IsNullOrEmpty(cmbProductType.Text.Trim()) Then
            LblMsg.ForeColor = Color.Red
            LblMsg.Text = "产品类型不能为空"
            Me.ActiveControl = cmbProductType
            Return False
        End If
        Return True
    End Function

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        ' Me.txtStationid.Text = "" Mark by CQ 20151028
        Me.BtnSelectSta.Enabled = True
        Me.txtNewStationID.Text = "" : Me.btnSelectDestSta.Enabled = False
        Me.txtVarMin.Text = "" : Me.txtVarMax.Text = ""
        Me.txtFinishMin.Text = "" : Me.txtFinishMax.Text = ""
        Me.txtStdTime.Text = "" : Me.txtadd.Text = ""
        opflag = 0
        ControlIsEnable(False)
        ToolbtnState(0)
        LoadDataToDatagridview("  WHERE a.Stationid='" & StationID & "'")
    End Sub

    Private Sub ToolCopy_Click(sender As Object, e As EventArgs) Handles ToolCopy.Click
        '   将所复制工站的所有工时资料，都复制一份到当前的工站。
        '	复制时，新增的工站，要求还未维护任何工时信息。
        '	复制时，除了工站/复制工站，其他资料不可编辑、维护。
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            If Me.dgvStdTime.Rows.Count = 0 OrElse Me.dgvStdTime.CurrentRow Is Nothing Then Exit Sub
            Me.txtStationid.Text = Me.dgvStdTime.Item(enumdgvStdTime.Stationid, Me.dgvStdTime.CurrentRow.Index).Value + "-" + Me.dgvStdTime.Item(enumdgvStdTime.StationName, Me.dgvStdTime.CurrentRow.Index).Value
            Me.btnSelectDestSta.Enabled = True
            If Me.txtNewStationID.Text = "" Then
                MessageBox.Show(" 请先选择复制工站，不允许复制！")
                Me.txtNewStationID.Focus()
                Exit Sub
            End If

            'First check  the new stationid not exist any data
            If CheckNewStationExist(Me.txtNewStationID.Text.Trim().Split("-")(0)) Then
                MessageBox.Show(" 该复制工站已经有维护工站信息，不允许复制！")
                Exit Sub
            End If

            lsSQL = " INSERT into m_RstationWorkHour_t " & _
                    "(Stationid,ExistVariables,VariableMin,VariableMax,FinishSizeMin,FinishSizeMax," & _
                    " StandardHour,FinishSizeAdd,WorkHour,UserID,InTime)" & _
                    " SELECT  '" & Me.txtNewStationID.Text.Trim().Split("-")(0) & "',ExistVariables,VariableMin,VariableMax,FinishSizeMin,FinishSizeMax," & _
                    " StandardHour,FinishSizeAdd,WorkHour, '" & SysMessageClass.UseId.ToLower.Trim & "', getdate()" & _
                    " from m_RstationWorkHour_t " & _
                    " Where Stationid='" & Me.txtStationid.Text.Trim.Split("-")(0) & "' "
            sConn.ExecSql(lsSQL)
            MessageBox.Show("复制成功！")
            LoadDataToDatagridview(" WHERE a.stationid in ( '" & Me.txtNewStationID.Text.Trim().Split("-")(0) & "', '" & Me.txtStationid.Text.Trim().Split("-")(0) & "')")

            Me.toolBack.Enabled = True
        Catch ex As Exception
            Throw ex
        Finally
            sConn = Nothing
        End Try
    End Sub

    Private Function CheckNewStationExist(ByVal parNewStationID As String) As Boolean
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        lsSQL = " SELECT Stationid from  m_RstationWorkHour_t " & _
                " where Stationid='" & parNewStationID & "'"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                CheckNewStationExist = True  '已经存在，不允许复制
            Else
                CheckNewStationExist = False
            End If
        End Using
        Return CheckNewStationExist
    End Function

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvStdTime.Rows.Count = 0 OrElse Me.dgvStdTime.CurrentRow Is Nothing Then Exit Sub
        ' VariableMin = N '800',VariableMax =N'1100',userid='c046428',intime=getdate(), StandardHour='',  FinishSizeAdd='0.4*(L-500)/1000', WorkHour=''where Stationid = ''
        'Me.txtStationid.Text = Me.dgvStdTime.Item(enumdgvStdTime.Stationid, Me.dgvStdTime.CurrentRow.Index).Value
        'If Not String.IsNullOrEmpty(Me.dgvStdTime.Item(enumdgvStdTime.VariableMin, Me.dgvStdTime.CurrentRow.Index).Value) Then
        '    Me.chkVariable.Checked = True
        'Else
        '    Me.chkVariable.Checked = False
        'End If

        'Me.txtVarMin.Text = Me.dgvStdTime.Item(enumdgvStdTime.VariableMin, Me.dgvStdTime.CurrentRow.Index).Value
        'Me.txtVarMax.Text = Me.dgvStdTime.Item(enumdgvStdTime.VariableMax, Me.dgvStdTime.CurrentRow.Index).FormattedValue
        'Me.txtFinishMin.Text = Me.dgvStdTime.Item(enumdgvStdTime.FinishSizeMin, Me.dgvStdTime.CurrentRow.Index).Value
        'Me.txtFinishMax.Text = Me.dgvStdTime.Item(enumdgvStdTime.FinishSizeMax, Me.dgvStdTime.CurrentRow.Index).Value
        'Me.txtStdTime.Text = Me.dgvStdTime.Item(enumdgvStdTime.StandardHour, Me.dgvStdTime.CurrentRow.Index).Value
        'Me.txtAdd.Text = Me.dgvStdTime.Item(enumdgvStdTime.FinishSizeAdd, Me.dgvStdTime.CurrentRow.Index).Value

        ' 修改时，不可更改是否勾选“含变量项”
        'Me.chkVariable.Enabled = False : Me.BtnSelectSta.Enabled = False
        'Me.txtNewStationID.Enabled = False : Me.btnSelectDestSta.Enabled = False 'Me.txtNewStationID.Text =""
        ControlIsEnable(True)
        opflag = 2
        ToolbtnState(2)
    End Sub

    '选择复制工站
    Private Sub btnSelectDestSta_Click(sender As Object, e As EventArgs) Handles btnSelectDestSta.Click
        Dim frm As New FrmRStationSet
        frm.opflag = 3
        frm.ShowDialog()
        Me.txtNewStationID.Text = frm.frmRstationid + "-" + frm.frmRstationname 'frm.frmRstationid,cq 20151022 add stationName
    End Sub

    Private Sub txtStationid_TextChanged(sender As Object, e As EventArgs)
        'Dim o_blnExistVar As Boolean = False

        'If Me.txtStationid.Text <> String.Empty Then
        '    If CheckStationExistData(Me.txtStationid.Text.Split("-")(0), o_blnExistVar) Then   '非第一笔
        '        Me.chkVariable.Checked = o_blnExistVar
        '        If Me.chkVariable.Checked = True Then
        '            Me.txtVarMin.ReadOnly = False : Me.txtVarMax.ReadOnly = False
        '        Else
        '            Me.txtVarMin.ReadOnly = True : Me.txtVarMax.ReadOnly = True
        '        End If
        '        Me.chkVariable.Enabled = False
        '    Else
        '        Me.chkVariable.Enabled = True
        '    End If
        'End If
    End Sub

    Private Function CheckStationExistData(ByVal parStationID As String, Optional ByRef o_blnExistVar As Boolean = False) As Boolean
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        lsSQL = " Select Stationid, ExistVariables from  m_RstationWorkHour_t " & _
                " where Stationid='" & parStationID & "'"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                CheckStationExistData = True  '已经存在，不允许复制
                o_blnExistVar = o_dt.Rows(0).Item("ExistVariables")
            Else
                CheckStationExistData = False
                ' Me.chkVariable.Checked = False  'default
            End If
        End Using
        Return CheckStationExistData

    End Function

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub


    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = ""
        If Me.dgvStdTime.Rows.Count = 0 OrElse Me.dgvStdTime.CurrentRow Is Nothing Then Exit Sub
        Try

            lsSQL = " DELETE from m_RstationWorkHour_t " & _
                    " WHERE id ='" & Me.dgvStdTime.CurrentRow.Cells("ColID").Value & "'"
            sConn.ExecSql(lsSQL)
            sConn.PubConnection.Close()
            LoadDataToDatagridview(" WHERE 1=1 and a.stationid='" + StationID + "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmStdTime", "toolDelete_Click", "sys")
        Finally
            If Not IsNothing(sConn) Then sConn = Nothing
        End Try
    End Sub

    Private Sub chkVariable_CheckedChanged(sender As Object, e As EventArgs) Handles chkVariable.CheckedChanged

        '    勾选“含变量项”时：①允许填变量项最大最小值；②成品尺寸最小值为0，不可编辑。
        '	不勾选“含变量项”时：①不允许填变量项最大最小值（清空）；②允许填成品尺寸最大最小值。
        If Me.chkVariable.Checked = True Then
            Me.txtVarMin.ReadOnly = False : Me.txtVarMax.ReadOnly = False
        Else
            Me.txtVarMin.Text = "" : Me.txtVarMax.Text = ""
            Me.txtVarMin.ReadOnly = True : Me.txtVarMax.ReadOnly = True
        End If
    End Sub

    Private Sub dgvStdTime_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If Me.dgvStdTime.Rows.Count = 0 OrElse Me.dgvStdTime.CurrentRow Is Nothing Then Exit Sub
        Me.txtStationid.Text = Me.dgvStdTime.Item(enumdgvStdTime.Stationid, Me.dgvStdTime.CurrentRow.Index).Value + "-" + Me.dgvStdTime.Item(enumdgvStdTime.StationName, Me.dgvStdTime.CurrentRow.Index).Value
    End Sub

    Private Sub dgvStdTime_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStdTime.DataBindingComplete
        If Not Me.dgvStdTime.CurrentRow Is Nothing Then
            Me.dgvStdTime.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub dgvStdTime_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStdTime.SelectionChanged
        Dim dgr As DataGridViewRow = dgvStdTime.CurrentRow
        txtStationid.Text = StationID + "-" + StationName
        chkVariable.Checked = IIf(dgr.Cells("ColExistVariables").Value = 1, True, False)
        txtVarMin.Text = IIf(IsDBNull(dgr.Cells("ColVariableMin").Value), "", dgr.Cells("ColVariableMin").Value)
        txtVarMax.Text = IIf(IsDBNull(dgr.Cells("ColVariableMax").Value), "", dgr.Cells("ColVariableMax").Value)
        txtStdTime.Text = IIf(IsDBNull(dgr.Cells("ColStandardHour").Value), "", dgr.Cells("ColStandardHour").Value)
        cmbProductType.SelectedValue = IIf(IsDBNull(dgr.Cells("ColProductType").Value), "", dgr.Cells("ColProductType").Value.ToString().Split("-")(0))
        txtFinishMin.Text = IIf(IsDBNull(dgr.Cells("ColFinishSizeMin").Value), "", dgr.Cells("ColFinishSizeMin").Value)
        txtFinishMax.Text = IIf(IsDBNull(dgr.Cells("ColFinishSizeMax").Value), "", dgr.Cells("ColFinishSizeMax").Value)
        txtAdd.Text = IIf(IsDBNull(dgr.Cells("ColFinishSizeAdd").Value), "", dgr.Cells("ColFinishSizeAdd").Value)
    End Sub

  
    '绑定产品类型
    Private Sub bindProductType()
        Dim sql As String = "select ProductTypeID,ProductType from ProductType_t"
        cmbProductType.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
        cmbProductType.ValueMember = "ProductTypeID"
        cmbProductType.DisplayMember = "ProductType"
    End Sub

    ''' <summary>
    ''' 产品类型基础资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsProductTypeInfo_Click(sender As Object, e As EventArgs) Handles tsProductTypeInfo.Click
        Dim info As Form = New FrmProductTypeInfo()
        info.ShowDialog()
    End Sub
End Class