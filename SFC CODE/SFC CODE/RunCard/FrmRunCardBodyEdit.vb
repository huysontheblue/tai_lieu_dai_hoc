Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmRunCardBodyEdit

#Region "构造函数"
    Sub New(ByVal runCardId As Integer, ByVal runCardPn As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化。
        Me._runCardId = runCardId
        Me._runCardPn = runCardPn
        Me._gridViewRow = dataGridViewRow
        Me._action = action
        Me._isQueryOldVersion = isQueryOldVersion
    End Sub
    Private frm As FrmRunCard
    Sub New(ByVal runCardId As Integer, ByVal runCardPn As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal form As Form, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化。
        Me._runCardId = runCardId
        Me._runCardPn = runCardPn
        Me._gridViewRow = dataGridViewRow
        Me._action = action
        frm = form
        Me._isQueryOldVersion = isQueryOldVersion
    End Sub
#End Region

#Region "自定义属性"
    Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,6})(\.\d{0,6}[1-9])?$")
    Dim row As System.Data.DataRowView
    Public processStandand As String
    Public workHour As String
    Public stationSeq As String
    Public sopPath As String
    Public equipment As String
    Public id As String
    Public stationId As String
    Public stationName As String
    Private _isQueryOldVersion As String

#Region "RunCardID"
    Private _runCardId As Integer
    Public Property RunCardID() As Integer
        Get
            Return _runCardId
        End Get

        Set(ByVal Value As Integer)
            _runCardId = Value
        End Set
    End Property
#End Region

#Region "RunCardPn"
    Private _runCardPn As String
    Public Property RunCardPn() As String
        Get
            Return _runCardPn
        End Get

        Set(ByVal Value As String)
            _runCardPn = Value
        End Set
    End Property
#End Region

#Region "SelectedGridViewRow"
    Private _gridViewRow As DataGridViewRow
    Public Property SelectedGridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get

        Set(ByVal Value As DataGridViewRow)
            _gridViewRow = Value
        End Set
    End Property
#End Region

#Region "Action"
    Private _action As String
    Public Property Actioin() As String
        Get
            Return _action
        End Get

        Set(ByVal Value As String)
            _action = Value
        End Set
    End Property
#End Region

#Region "SopFileName"
    Private _sopFileName As String
    Public Property SopFileName() As String
        Get
            Return _sopFileName
        End Get

        Set(ByVal Value As String)
            _sopFileName = Value
        End Set
    End Property
#End Region

#End Region

#Region "btnOK_Click"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            '校验输入是否合法
            If CheckInput() Then
                '保存
                If Not SaveData() Then
                    Exit Sub
                End If
                '提示
                'MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblMsg.Text = "保存成功"
                '退出
                If Actioin = "add" Then
                    frm.BindBodyWhenAdd(RunCardID)
                    Me.cboStation.SelectedIndex = -1
                    Me.txtProcessStandard.Text = ""
                    Me.iiWoringHours.Text = ""
                    Me.txtEquipment.Text = ""
                    Me.txtSopFilePath.Text = ""
                    Me.txtRemark.Text = ""
                    cboStation.Select()
                    cboStation.SelectAll()
                    TextBox1.Text = "1"
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
                'Me.DialogResult = Windows.Forms.DialogResult.OK
                'Me.Close()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardEdit", "btnOK_Click", "WIPS")
        End Try
    End Sub
#End Region

#Region "Tab"
    'Private Sub FrmRunCardEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
#End Region

#Region "FrmRunCardEdit_Load"
    Private Sub FrmRunCardEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblId.Text = ""
            lblMsg.Text = ""
            Me.txtPartNumber.Text = Me.RunCardPn
            ''绑定工站
            'FillCombox(Me.cboStation)
            ''
            If Actioin = "add" Then
                '绑定工站
                '绑定工站
                FillCombox(Me.cboStation)
                Me.iiStationSQ.Enabled = False
                Me.txtSopFilePath.Enabled = False
                Me.txtSopFilePath.ReadOnly = True
                txtRemark.Enabled = True
            ElseIf Actioin = "modify" Then
                '绑定工站
                FillCombox(Me.cboStation)
                Me.txtSopFilePath.Enabled = True
                Me.txtSopFilePath.ReadOnly = False
                txtRemark.Enabled = True
                IniteControls()
                If CheckStationMaintainCheckItem() Then
                    txtProcessStandard.Enabled = False
                End If
            Else
                txtPartNumber.Enabled = False
                cboStation.Enabled = False
                txtProcessStandard.Enabled = False
                iiWoringHours.Enabled = False
                txtEquipment.Enabled = False
                txtSopFilePath.Enabled = False
                txtRemark.Enabled = False
                iiStationSQ.Enabled = True
                IniteControls()
            End If
            Me.Top = Screen.PrimaryScreen.WorkingArea.Height * 0.15
            cboStation.Select()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardEdit", "dgvRunCardBody_CellClick", "WIPS")
        End Try
    End Sub
#End Region

#Region "初始化控件"
    Private Sub IniteControls()
        If Not Me.SelectedGridViewRow Is Nothing Then
            Me.lblId.Text = _gridViewRow.Cells("ID").Value.ToString
            ' Me.cboStation.SelectedValue = _gridViewRow.Cells("工站ID").Value.ToString
            Me.txtEquipment.Text = _gridViewRow.Cells("设备治具").Value.ToString
            Me.txtProcessStandard.Text = _gridViewRow.Cells("工艺标准").Value.ToString
            Me.txtSopFilePath.Text = _gridViewRow.Cells("SOP").Value.ToString
            Me.iiStationSQ.Value = _gridViewRow.Cells("工序").Value.ToString
            Me.stationSeq = Me.iiStationSQ.Value
            Me.iiWoringHours.Text = _gridViewRow.Cells("工时").Value.ToString
            Me.txtRemark.Text = _gridViewRow.Cells("备注").Value.ToString
            If Actioin = "reset" Then
                cboStation.Items.Clear()
                Using dt As New DataTable
                    dt.Columns.Add("ID", GetType(String))
                    dt.Columns.Add("StationName", GetType(String))
                    dt.Rows.Add(_gridViewRow.Cells("工站ID").Value.ToString, _gridViewRow.Cells("工站名称").Value.ToString)
                    cboStation.DataSource = dt.DefaultView
                    cboStation.DisplayMember = "StationName"
                    cboStation.ValueMember = "ID"
                End Using
            End If
        End If
    End Sub
#End Region

#Region "绑定下拉列表框"
    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If ColComboBox.Name = "cboStation" Then
                ColComboBox.Items.Clear()
                If Actioin = "add" Then
                    UserDg = DataHand.GetDataTable("select ID,StationName from m_RUNCARDStation_t(nolock)")
                    cboStation.DataSource = UserDg.DefaultView
                    cboStation.DisplayMember = "StationName"
                    cboStation.ValueMember = "ID"
                ElseIf Actioin = "modify" Then
                    Dim sql As String = "SELECT " & _gridViewRow.Cells("工站ID").Value.ToString & " ID,N'" & _gridViewRow.Cells("工站名称").Value.ToString & "' StationName UNION "
                    sql &= " select ID,StationName from m_RUNCARDStation_t(nolock) WHERE ID<>" & _gridViewRow.Cells("工站ID").Value.ToString & " "
                    UserDg = DataHand.GetDataTable(sql)
                    cboStation.DataSource = UserDg
                    cboStation.DisplayMember = "StationName"
                    cboStation.ValueMember = "ID"
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            DataHand = Nothing
        End Try
    End Sub
#End Region

#Region "输入完整性检查"
    Private Function CheckInput() As Boolean
        '工站
        If cboStation.SelectedIndex = -1 Then
            lblMsg.Text = "请选择工站"
            cboStation.Select()
            cboStation.SelectAll()
            TextBox1.Text = "1"
            Return False
        End If
        '工时
        If Not reg.IsMatch(iiWoringHours.Text) Then
            lblMsg.Text = """工时""不正确"
            iiWoringHours.Select()
            iiWoringHours.SelectAll()
            Return False
        End If
        '工序
        If Me.iiStationSQ.Value <= 0 Then
            lblMsg.Text = """工序""不能小于1"
            iiStationSQ.Select()
            Return False
        End If
        row = cboStation.SelectedItem
        If Me.Actioin = "add" Then
            If StationExists(Me.RunCardID, CInt(row.Item(0).ToString)) Then
                lblMsg.Text = "工站""" & row.Item(1).ToString & """已存在,请勿重复"
                cboStation.Select()
                cboStation.SelectAll()
                TextBox1.Text = "1"
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "检查工站是否存在"
    Private Function StationExists(ByVal runCardId As Integer, ByVal stationId As Integer) As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = Nothing
        If _isQueryOldVersion = "false" Then
            StrSql = "SELECT 1 FROM m_RunCardDetail_t(NOLOCK) WHERE RunCardID=" & runCardId & " AND StationID=" & stationId & " "
        Else
            StrSql = "SELECT 1 FROM m_RunCardDetailOLDVERSION_t(NOLOCK) WHERE RunCardID=" & runCardId & " AND StationID=" & stationId & " "
        End If
        'Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
        'If Not reader.HasRows Then
        '    reader.Close()
        '    Return False
        'End If
        'reader.Close()
        'Return True
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then Return True
        End Using
        Return False
    End Function
#End Region

#Region "保存"
    Public Function SaveData() As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            row = cboStation.SelectedItem
            Dim ID As Integer
            Dim StrSql As String
            Dim ServerFile As String = ""
            Dim StationID As String = CInt(row.Item(0).ToString)
            Me.stationId = StationID
            Dim StationName As String = row.Item(1).ToString
            StationName = StationName.Replace("/", "")
            StationName = StationName.Replace("\", "")
            StationName = Replace(StationName, Chr(10), "")
            StationName = Replace(StationName, Chr(13), "")
            StationName = StationName.Replace(" ", "")
            Dim StationSQ As Integer = CInt(Me.iiStationSQ.Value.ToString())
            Dim WorkingHours As Double = Me.iiWoringHours.Text.ToString()
            Dim Equipment As String = Me.txtEquipment.Text.Trim
            Dim ProcessStandard As String = Me.txtProcessStandard.Text.Trim
            Dim SopFilePath As String = Me.txtSopFilePath.Text.Trim
            'Dim ID As Integer = IIf(Me.lblId.Text.Trim = "", 0, CInt(Me.lblId.Text.Trim))
            If Me.lblId.Text.Trim = "" Then
                ID = 0
            Else
                ID = CInt(Me.lblId.Text.Trim)
            End If
            '有选择上传
            'If Actioin = "modify" AndAlso SopFilePath.StartsWith(VbCommClass.VbCommClass.SopFilePath) AndAlso Me.stationId <> _gridViewRow.Cells("工站ID").Value.ToString Then
            '    lblMsg.Text = "请选择本地的SOP"
            '    Return False
            'End If
            If Not String.IsNullOrEmpty(Me.SopFileName) Then
                If Not String.IsNullOrEmpty(SopFilePath) Then
                    Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath + Me.RunCardPn + "\\", StationName)
                    If System.IO.Directory.Exists(destFilePath) = False Then
                        Directory.CreateDirectory(destFilePath)
                    End If
                    ServerFile = Path.Combine(destFilePath, Me.SopFileName)
                    File.Copy(SopFilePath, ServerFile, True)
                End If
            Else '未选择上传
                ServerFile = SopFilePath
            End If
            'Dim Remark As String = Me.txtPartNumber.Text.Trim
            '新增
            If Not CheckStationExists() Then
                lblMsg.Text = "选择的工站不存在"
                Return False
            End If
            If Actioin = "add" Then
                If _isQueryOldVersion = "false" Then
                    StrSql = "DECLARE @StationSQ INT;UPDATE M_RUNCARD_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " SELECT @StationSQ=MAX(StationSQ) FROM m_RunCardDetail_t(nolock) where RunCardID=" & Me.RunCardID & _
                             "IF @StationSQ IS NULL SET @StationSQ=1 ELSE SET @StationSQ=@StationSQ+1 ;" & _
                             "INSERT INTO m_RunCardDetail_t(RunCardID,StationSQ,StationID,WorkingHours,Equipment,ProcessStandard,SopFilePath,Status,UserID,InTime,remark,partnumber,STATIONNAME) VALUES(" & _
                             "" & Me.RunCardID & ",@StationSQ ," & StationID & "," & WorkingHours & ",N'" & Equipment & "',N'" & ProcessStandard & "',N'" & ServerFile & "',1,'" & SysMessageClass.UseId & "',getdate(),N'" & txtRemark.Text & "','" & _runCardPn & "',N'" & StationName & "' )"
                    If Not String.IsNullOrEmpty(processStandardSql) Then
                        StrSql &= processStandardSql
                    End If
                Else
                    StrSql = "DECLARE @StationSQ INT;UPDATE M_RUNCARDOLDVERSION_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " SELECT @StationSQ=MAX(StationSQ) FROM m_RunCardDetailOLDVERSION_t(nolock) where RunCardID=" & Me.RunCardID & _
                         "IF @StationSQ IS NULL SET @StationSQ=1 ELSE SET @StationSQ=@StationSQ+1 ;" & _
                         "INSERT INTO m_RunCardDetailOLDVERSION_t(RunCardID,StationSQ,StationID,WorkingHours,Equipment,ProcessStandard,SopFilePath,Status,UserID,InTime,remark,partnumber,STATIONNAME) VALUES(" & _
                         "" & Me.RunCardID & ",@StationSQ ," & StationID & "," & WorkingHours & ",N'" & Equipment & "',N'" & ProcessStandard & "',N'" & ServerFile & "',1,'" & SysMessageClass.UseId & "',getdate(),N'" & txtRemark.Text & "','" & _runCardPn & "',N'" & StationName & "' )"
                    If Not String.IsNullOrEmpty(processStandardSql) Then
                        StrSql &= processStandardSql
                    End If
                End If
            ElseIf Actioin = "modify" Then '修改
                If _isQueryOldVersion = "false" Then
                    StrSql = "UPDATE M_RUNCARD_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " UPDATE m_RunCardDetail_t SET StationSQ=" & StationSQ & ",WorkingHours=" & WorkingHours & ",userid='" & VbCommClass.VbCommClass.UseId & "',intime=getdate()," & _
                             "Equipment=N'" & Equipment & "',ProcessStandard=N'" & ProcessStandard & "',SopFilePath=N'" & ServerFile & "',remark=N'" & txtRemark.Text & "',stationid=" & StationID & " ,STATIONNAME='" & StationName & "' WHERE ID=" & ID & "; "
                    '"UserID=N'" & SysMessageClass.UseId & "',InTime=getdate() WHERE ID=" & ID
                Else
                    StrSql = "UPDATE M_RUNCARDOLDVERSION_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " UPDATE m_RunCardDetailOLDVERSION_t SET StationSQ=" & StationSQ & ",WorkingHours=" & WorkingHours & ",userid='" & VbCommClass.VbCommClass.UseId & "',intime=getdate()," & _
                           "Equipment=N'" & Equipment & "',ProcessStandard=N'" & ProcessStandard & "',SopFilePath=N'" & ServerFile & "',remark=N'" & txtRemark.Text & "',stationid=" & StationID & " ,STATIONNAME='" & StationName & "' WHERE ID=" & ID & "; "
                    '"UserID=N'" & SysMessageClass.UseId & "',InTime=getdate() WHERE ID=" & ID
                End If
                If Not String.IsNullOrEmpty(processStandardSql) Then
                    StrSql &= processStandardSql
                End If
            Else
                If _isQueryOldVersion = "false" Then
                    StrSql = "UPDATE M_RUNCARD_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " UPDATE m_RunCardDetail_t SET STATIONSQ=STATIONSQ+1 WHERE RUNCARDID=" & Me.RunCardID & " AND STATIONSQ>=" & iiStationSQ.Value & "" & vbNewLine & _
                    " UPDATE m_RunCardDetail_t SET STATIONSQ=" & iiStationSQ.Value & " WHERE RUNCARDID=" & Me.RunCardID & " AND StationID=" & Me.stationId & " " & vbNewLine & _
                    " UPDATE  M_RUNCARDDETAIL_T  SET STATIONSQ=B.ID,userid='" & VbCommClass.VbCommClass.UseId & "',intime=getdate() FROM M_RUNCARDDETAIL_T A," & vbNewLine & _
                    " (SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM M_RUNCARDDETAIL_T WHERE RUNCARDID=" & Me.RunCardID & ") B" & vbNewLine & _
                    " WHERE A.RUNCARDID=" & Me.RunCardID & " AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ"
                Else
                    StrSql = "UPDATE M_RUNCARDOLDVERSION_T SET MODIFYTIME=GETDATE() WHERE ID=" & Me.RunCardID & " UPDATE m_RunCardDetailOLDVERSION_t SET STATIONSQ=STATIONSQ+1 WHERE RUNCARDID=" & Me.RunCardID & " AND STATIONSQ>=" & iiStationSQ.Value & "" & vbNewLine & _
                   " UPDATE m_RunCardDetailOLDVERSION_t SET STATIONSQ=" & iiStationSQ.Value & " WHERE RUNCARDID=" & Me.RunCardID & " AND StationID=" & Me.stationId & " " & vbNewLine & _
                   " UPDATE  M_RUNCARDDETAILOLDVERSION_T  SET STATIONSQ=B.ID,userid='" & VbCommClass.VbCommClass.UseId & "',intime=getdate() FROM M_RUNCARDDETAIL_T A," & vbNewLine & _
                   " (SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=" & Me.RunCardID & ") B" & vbNewLine & _
                   " WHERE A.RUNCARDID=" & Me.RunCardID & " AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ"
                End If
            End If
            '触发器保存修改记录
            If _isQueryOldVersion = "false" Then
                DAL.ExecSql(StrSql & vbNewLine & "UPDATE m_RunCard_t SET Status=0 WHERE ID=" & Me.RunCardID & ";")
            Else
                DAL.ExecSql(StrSql & vbNewLine & "UPDATE m_RunCardOLDVERSION_t SET Status=0 WHERE ID=" & Me.RunCardID & ";")
            End If
            Return True
        Catch ex As Exception
            lblMsg.Text = ex.Message
            Return False
        Finally
            DAL = Nothing
        End Try
    End Function
#End Region

#Region "退出"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "上传SOP"
    Private Sub btnSopUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSopUpload.Click
        btnSopUpload.Enabled = False
        Me.SopFileName = ""
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtSopFilePath.Text = OpenFileDialog1.FileName
            Me.SopFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSopUpload.Enabled = True
    End Sub
#End Region

    Private Function CheckStationExists() As Boolean
        Dim sConn As New SysDataBaseClass
        row = cboStation.SelectedItem
        Dim sql As String = "SELECT ID FROM m_RUNCARDStation_t WHERE ID='" & row.Item(0).ToString & "'"
        If sConn.GetRowsCount(sql) > 0 Then
            Return True
        End If
        Return False
    End Function

#Region "Enter Event"

    Private Sub cboStation_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStation.KeyUp
        If e.KeyCode = 13 AndAlso TextBox1.Text = "" Then
            txtProcessStandard.Focus()
            txtProcessStandard.SelectAll()
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub txtProcessStandard_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProcessStandard.KeyPress
        If e.KeyChar = Chr(13) Then
            iiWoringHours.Focus()
            iiWoringHours.SelectAll()
        End If
        Return
    End Sub

    Private Sub iiWoringHours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iiWoringHours.KeyPress
        If e.KeyChar = Chr(13) Then
            If iiStationSQ.Enabled = False Then
                txtEquipment.Focus()
                txtEquipment.SelectAll()
            Else
                iiStationSQ.Focus()
                iiStationSQ.Select()
            End If
        End If
        Return
    End Sub

    Private Sub iiStationSQ_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iiStationSQ.KeyPress
        If e.KeyChar = Chr(13) Then
            txtEquipment.Focus()
            txtEquipment.SelectAll()
        End If
        Return
    End Sub

    Private Sub txtEquipment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEquipment.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtSopFilePath.Enabled = False Or txtSopFilePath.ReadOnly = True Then
                txtRemark.Select()
                txtRemark.SelectAll()
            Else
                txtSopFilePath.Select()
                txtSopFilePath.SelectAll()
            End If
        End If
        Return
    End Sub

    Private Sub txtSopFilePath_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSopFilePath.KeyPress
        If e.KeyChar = Chr(13) Then
            txtRemark.Focus()
            txtRemark.SelectAll()
        End If
        Return
    End Sub

    Private Sub txtRemark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemark.KeyPress
        If e.KeyChar = Chr(13) Then
            btnOK.Select()
        End If
        Return
    End Sub

    Private Sub txtRemark_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyUp
        TextBox1.Text = ""
    End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStation.SelectedIndexChanged
        TextBox1.Text = "1"
        processStandardSql = Nothing
        CheckStationMaintainCheckItem()
        If Actioin = "modify" Then
            btnGetProcessStandard.Enabled = False
        End If
    End Sub

#End Region

    Private Function CheckStationMaintainCheckItem()
        If cboStation.SelectedIndex <> -1 Then
            Dim sql As String
            Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim row As DataRowView = cboStation.SelectedItem
            sql = "SELECT CHECKITEMCODE FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONID=" & row.Item(0).ToString & " AND STATUS='Y'"
            If sConn.GetRowsCount(sql) > 0 Then
                btnGetProcessStandard.Enabled = True
                txtProcessStandard.Enabled = False
                If Actioin = "add" Then
                    txtProcessStandard.Text = ""
                End If
                Return True
            End If
            txtProcessStandard.Enabled = True
            btnGetProcessStandard.Enabled = False
            Return False
        End If
        Return False
    End Function

    Private Sub btnGetProcessStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProcessStandard.Click
        Try
            Using frm As New FrmRunCardBodyModify(_runCardId, _runCardPn, FrmRunCardBodyModify.ActionType.GetProcessParameter, cboStation.SelectedValue.ToString, GetStationNo(), "false")
                frm.ShowDialog()
                processStandardSql = frm.outputSql
                txtProcessStandard.Text = frm.outputProcessStand
            End Using
        Catch ex As Exception
            MessageBox.Show("获取标准工艺失败")
        Finally

        End Try
    End Sub

    Private Function GetStationNo() As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sql As String = "SELECT STATIONNO FROM m_RUNCARDStation_t WHERE ID=" & cboStation.SelectedValue.ToString & ""
        Using dt As DataTable = DAL.GetDataTable(sql)
            If dt.Rows.Count > 0 Then Return dt.Rows(0)("STATIONNO").ToString
        End Using
        Return ""
    End Function

    Private processStandardSql As String = Nothing
End Class
Public Class TextValue
    Private _text As String
    Public Property Text()
        Get
            Return _text
        End Get
        Set(ByVal value)
            _text = value
        End Set
    End Property


    Private _value As String

    Public Property Value()
        Get
            Return _value
        End Get
        Set(ByVal value)
            _value = value
        End Set
    End Property
    Sub New(ByVal text As String, ByVal value As String)
        _text = text
        _value = value
    End Sub
    Public Overrides Function ToString() As String
        Return _text
    End Function
End Class