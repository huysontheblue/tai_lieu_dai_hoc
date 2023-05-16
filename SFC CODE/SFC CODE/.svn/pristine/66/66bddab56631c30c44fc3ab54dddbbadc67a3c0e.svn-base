Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmRunCardBodyModify

    Private sConn As New MainFrame.SysDataHandle.SysDataBaseClass
    Public outputSop As String = Nothing
    Public outputStationName As String = Nothing
    Public outputStationId As String = Nothing
    Public outputProcessStand As String = Nothing
    Public outputSql As String = Nothing
    Private dt As New DataTable
    Private m_ToleranceRange As String = ""
    Private isFormLoad As Boolean = True

    Private Sub FrmRunCardBodyModify_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            isClose = True
            UpdateData()
            Select Case Action
                Case ActionType.GetProcessParameter
                    'outputProcessStand = GetAddProcessStand()
                Case Else
                    outputProcessStand = GetProcessStand()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmRunCardBodyModify_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Select Case Action
                Case ActionType.ModifySop
                    GroupBox1.Enabled = False
                    TabControl1.Enabled = False
                    cboStation.Items.Clear()
                    cboStation.Enabled = False
                    txtSop.Text = _gridViewRow.Cells("SOP").Value.ToString
                Case ActionType.ModifyStation
                    GroupBox2.Enabled = False
                    TabControl1.Enabled = False
                    txtSop.Enabled = False
                    btnScan.Enabled = False
                    LoadStation()
                Case ActionType.ModifyProcessParameter
                    AddHandler txtFinishSize.LostFocus, AddressOf txtFinishSize_LostFocus
                    GroupBox1.Enabled = False
                    GroupBox2.Enabled = False
                    If _isQueryOldVersion = "false" Then
                        LoadPn()
                        LoadCutSize()
                        LoadProcessParameter()
                        GetLeftProcessParametersByFormLoad()
                        GetRightProcessParametersByFormLoad()
                        ResetCutSize()
                    End If
                    InitTools()
                Case ActionType.GetProcessParameter
                    AddHandler txtFinishSize.LostFocus, AddressOf txtFinishSize_LostFocus
                    GroupBox1.Enabled = False
                    GroupBox2.Enabled = False
                    If _isQueryOldVersion = "false" Then
                        LoadPn()
                        LoadCutSize()
                        LoadProcessParameter()
                    End If
                    InitTools()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            isFormLoad = False
        End Try
    End Sub

    Private Sub LoadStation()
        Dim sql As String = "SELECT " & _gridViewRow.Cells("工站ID").Value.ToString & " ID,N'" & _gridViewRow.Cells("工站名称").Value.ToString & "' StationName UNION "
        sql &= " select ID,StationName from M_RUNCARDSTATION_T(nolock) WHERE ID<>" & _gridViewRow.Cells("工站ID").Value.ToString & " "
        dt = sConn.GetDataTable(sql)
        cboStation.DataSource = dt
        cboStation.DisplayMember = "StationName"
        cboStation.ValueMember = "ID"
    End Sub

    Private Sub LoadPn()
        '    "SELECT A.PARTNUMBER,A.PARTNUMBER+'.'+A.DESCRIPTION1 FROM M_RUNCARDPARTNUMBER_T A,M_RUNCARDBOMINFO_T B" & vbNewLine & _
        '" WHERE B.PARENTPARTNUMBER='" & _runCardPn & "' AND B.PARTNUMBER=A.PARTNUMBER"
        Dim sql As String =
        "SELECT C.PARTNUMBER,C.PARTNUMBER+'.'+C.DESCRIPTION1 " &
        "FROM M_RUNCARDBOMINFO_T A,M_RUNCARDPARTNUMBER_T B,M_RUNCARDPARTNUMBER_T  C WHERE A.PARENTPARTID =B.ID AND A.PARTID=C.ID AND  B.PARTNUMBER = '" & _runCardPn & "'"
        dt = sConn.GetDataTable(Sql)
        Dim crs(dt.Rows.Count) As ComboxBoxItem
        Dim index As Integer = 0
        Dim cr As New ComboxBoxItem
        cr.Text = ""
        cr.Value = ""
        crs(index) = cr
        index += 1
        For Each dr As DataRow In dt.Rows
            Dim cob As New ComboxBoxItem
            cob.Text = dr(1).ToString
            cob.Value = dr(0).ToString
            crs(index) = cob
            index += 1
        Next
        cboRightTv.Items.AddRange(crs)
        cboRightLine.Items.AddRange(crs)
        cboRightLineTwo.Items.AddRange(crs)
        cboRightLineThree.Items.AddRange(crs)
        cboRightLineFour.Items.AddRange(crs)
        cboLeftTv.Items.AddRange(crs)
        cboLeftLine.Items.AddRange(crs)
        cboLeftLineTwo.Items.AddRange(crs)
        cboLeftLineThree.Items.AddRange(crs)
        cboLeftLineFour.Items.AddRange(crs)

    End Sub

    Private Sub LoadProcessParameter()
        Dim sql As String = Nothing
        sql = "SELECT A.CHECKITEMCODE,A.DESCRIPTION '校验项次',B.RESULTVALUE '校验值',A.CHECKGROUP,LEFTTVPARTNUMBER,LEFTLINEPARTNUMBER, " & vbNewLine & _
        " LEFTLINEPARTNUMBERTWO,LEFTLINEPARTNUMBERTHREE,LEFTLINEPARTNUMBERFOUR " & vbNewLine & _
         " FROM M_RUNCARDSTATIONCHECKITEM_T A LEFT JOIN  M_RUNCARDDETAILCHECKITEM_T B ON A.STATIONID=B.STATIONID AND A.CHECKITEMCODE=B.CHECKITEMCODE AND PARTNUMBER='" & _runCardPn & "'" & vbNewLine & _
         " WHERE A.STATUS='Y' AND A.CHECKGROUP='LH' AND A.STATIONID='" & _stationId & "' ORDER BY A.DESCRIPTION"
        Using dt As DataTable = sConn.GetDataTable(sql)
            dgvLeft.DataSource = dt
        End Using
        sql = " SELECT A.CHECKITEMCODE,A.DESCRIPTION '校验项次',B.RESULTVALUE '校验值',A.CHECKGROUP,RIGHTTVPARTNUMBER,RIGHTLINEPARTNUMBER, " & vbNewLine & _
         " RIGHTLINEPARTNUMBERTWO,RIGHTLINEPARTNUMBERTHREE,RIGHTLINEPARTNUMBERFOUR " & vbNewLine & _
         " FROM M_RUNCARDSTATIONCHECKITEM_T A LEFT JOIN  M_RUNCARDDETAILCHECKITEM_T B ON A.STATIONID=B.STATIONID AND A.CHECKITEMCODE=B.CHECKITEMCODE AND PARTNUMBER='" & _runCardPn & "'" & vbNewLine & _
         " WHERE A.STATUS='Y' AND A.CHECKGROUP='RH' AND A.STATIONID='" & _stationId & "' ORDER BY A.DESCRIPTION "
        Using dt As DataTable = sConn.GetDataTable(sql)
            dgvRight.DataSource = dt
        End Using
        SetDataGridStyle()
        SetComboxStyle()
    End Sub

    Private Sub SetDataGridStyle()
        dgvLeft.Columns(ProcessGrid.CheckCode).Visible = False
        dgvRight.Columns(ProcessGrid.CheckCode).Visible = False
        dgvLeft.Columns(ProcessGrid.CheckGroup).Visible = False
        dgvRight.Columns(ProcessGrid.CheckGroup).Visible = False
        dgvLeft.Columns(ProcessGrid.TVPARTNUMBER).Visible = False
        dgvRight.Columns(ProcessGrid.TVPARTNUMBER).Visible = False
        dgvLeft.Columns(ProcessGrid.LINEPARTNUMBER).Visible = False
        dgvRight.Columns(ProcessGrid.LINEPARTNUMBER).Visible = False
        dgvLeft.Columns(ProcessGrid.LINEPARTNUMBERTwo).Visible = False
        dgvRight.Columns(ProcessGrid.LINEPARTNUMBERTwo).Visible = False
        dgvLeft.Columns(ProcessGrid.LINEPARTNUMBERThree).Visible = False
        dgvRight.Columns(ProcessGrid.LINEPARTNUMBERThree).Visible = False
        dgvLeft.Columns(ProcessGrid.LINEPARTNUMBERFour).Visible = False
        dgvRight.Columns(ProcessGrid.LINEPARTNUMBERFour).Visible = False
        dgvLeft.Columns(ProcessGrid.Description).ReadOnly = True
        dgvRight.Columns(ProcessGrid.Description).ReadOnly = True
        dgvLeft.Columns(ProcessGrid.ResultValue).ReadOnly = False
        dgvRight.Columns(ProcessGrid.ResultValue).ReadOnly = False
        dgvLeft.Columns(ProcessGrid.Description).Width = 200
        dgvRight.Columns(ProcessGrid.Description).Width = 200
    End Sub

    Private Sub SetComboxStyle()
        If dgvLeft.Rows.Count <= 0 Then
            cboLeftTv.SelectedIndex = 0
            cboLeftLine.SelectedIndex = 0
            cboLeftLineTwo.SelectedIndex = 0
            cboLeftLineThree.SelectedIndex = 0
            cboLeftLineFour.SelectedIndex = 0
        Else
            cboLeftTv.SelectedIndex = cboLeftTv.FindString(dgvLeft.Rows(0).Cells(ProcessGrid.TVPARTNUMBER).Value.ToString)
            cboLeftLine.SelectedIndex = cboLeftLine.FindString(dgvLeft.Rows(0).Cells(ProcessGrid.LINEPARTNUMBER).Value.ToString)
            cboLeftLineTwo.SelectedIndex = cboLeftLineTwo.FindString(dgvLeft.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERTwo).Value.ToString)
            cboLeftLineThree.SelectedIndex = cboLeftLineThree.FindString(dgvLeft.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERThree).Value.ToString)
            cboLeftLineFour.SelectedIndex = cboLeftLineFour.FindString(dgvLeft.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERFour).Value.ToString)
            If cboLeftTv.SelectedIndex = -1 Then cboRightTv.SelectedIndex = 0
            If cboLeftLine.SelectedIndex = -1 Then cboRightLine.SelectedIndex = 0
            If cboLeftLineTwo.SelectedIndex = -1 Then cboLeftLineTwo.SelectedIndex = 0
            If cboLeftLineThree.SelectedIndex = -1 Then cboLeftLineThree.SelectedIndex = 0
            If cboLeftLineFour.SelectedIndex = -1 Then cboLeftLineFour.SelectedIndex = 0
        End If
        If dgvRight.Rows.Count <= 0 Then
            cboRightTv.SelectedIndex = 0
            cboRightLine.SelectedIndex = 0
            cboRightLineTwo.SelectedIndex = 0
            cboRightLineThree.SelectedIndex = 0
            cboRightLineFour.SelectedIndex = 0
        Else
            cboRightTv.SelectedIndex = cboRightTv.FindString(dgvRight.Rows(0).Cells(ProcessGrid.TVPARTNUMBER).Value.ToString)
            cboRightLine.SelectedIndex = cboRightLine.FindString(dgvRight.Rows(0).Cells(ProcessGrid.LINEPARTNUMBER).Value.ToString)
            cboRightLineTwo.SelectedIndex = cboRightLineTwo.FindString(dgvRight.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERTwo).Value.ToString)
            cboRightLineThree.SelectedIndex = cboRightLineThree.FindString(dgvRight.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERThree).Value.ToString)
            cboRightLineFour.SelectedIndex = cboRightLineFour.FindString(dgvRight.Rows(0).Cells(ProcessGrid.LINEPARTNUMBERFour).Value.ToString)
            If cboRightTv.SelectedIndex = -1 Then cboRightTv.SelectedIndex = 0
            If cboRightLine.SelectedIndex = -1 Then cboRightLine.SelectedIndex = 0
            If cboRightLineTwo.SelectedIndex = -1 Then cboRightLineTwo.SelectedIndex = 0
            If cboRightLineThree.SelectedIndex = -1 Then cboRightLineThree.SelectedIndex = 0
            If cboRightLineFour.SelectedIndex = -1 Then cboRightLineFour.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadCutSize()
        Dim sql As String = Nothing
        sql = "SELECT RESULTVALUE,FINISHSIZE,TOLERANCE,TOLERANCERANGE FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & " AND CHECKITEMCODE='LCL' AND STATUS='Y'"
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                txtCutSize.Text = dt.Rows(0)("RESULTVALUE").ToString
                txtFinishSize.Text = dt.Rows(0)("FINISHSIZE").ToString
                txtCD.Text = dt.Rows(0)("TOLERANCE").ToString
                m_ToleranceRange = dt.Rows(0)("TOLERANCERANGE").ToString
            End If
        End Using
        If String.IsNullOrEmpty(txtCD.Text) Then txtCD.Text = "±0"
        sql = " SELECT CHECKITEMCODE FROM M_RUNCARDSTATIONCHECKITEM_T WHERE STATIONID=" & _stationId & " AND STATUS='Y' AND CHECKITEMCODE='LCL'"
        If sConn.GetRowsCount(sql) > 0 Then
            txtCutSize.Enabled = True
        Else
            txtCutSize.Enabled = False
        End If
        'If Not String.IsNullOrEmpty(txtFinishSize.Text) Then
        'LoadCommonDifference()
        'End If
    End Sub

    Private Enum ProcessGrid
        CheckCode = 0
        Description
        ResultValue
        CheckGroup
        TVPARTNUMBER
        LINEPARTNUMBER
        LINEPARTNUMBERTwo
        LINEPARTNUMBERThree
        LINEPARTNUMBERFour
    End Enum

#Region "上传SOP"
    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        btnScan.Enabled = False
        Me.SopFileName = ""
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtSop.Text = OpenFileDialog1.FileName
            Me.SopFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnScan.Enabled = True
    End Sub
#End Region

#Region "Variables"

    Public Enum ActionType
        ModifyStation = 0
        ModifySop
        ModifyProcessParameter
        GetProcessParameter
    End Enum

    Private MAction As ActionType
    Public Property Action() As ActionType
        Get
            Return MAction
        End Get
        Set(ByVal value As ActionType)
            MAction = value
        End Set
    End Property

    Private _gridViewRow As DataGridViewRow
    Public Property GridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get
        Set(ByVal value As DataGridViewRow)
            _gridViewRow = value
        End Set
    End Property

    Private _runCardId As Integer
    Public Property RunCardId() As Integer
        Get
            Return _runCardId
        End Get
        Set(ByVal value As Integer)
            _runCardId = value
        End Set
    End Property

    Private sopName As String
    Public Property SopFileName() As String
        Get
            Return sopName
        End Get
        Set(ByVal value As String)
            sopName = value
        End Set
    End Property

    Private _runCardPn As String = ""

    Private _isQueryOldVersion As String = Nothing
    Public Property IsQueryOldVersion() As String
        Get
            Return _isQueryOldVersion
        End Get
        Set(ByVal value As String)
            _isQueryOldVersion = value
        End Set
    End Property

    Private _stationId As Integer

    Private _stationNo As String
#End Region

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal runcardId As Integer, ByVal runcardpn As String, ByVal action As ActionType, ByVal input As DataGridViewRow, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        MAction = action
        GridViewRow = input
        Me.RunCardId = runcardId
        _runCardPn = runcardpn
        Me.IsQueryOldVersion = isQueryOldVersion
        _stationId = _gridViewRow.Cells("工站ID").Value.ToString
        _stationNo = _gridViewRow.Cells("工站编号").Value.ToString
    End Sub


    Public Sub New(ByVal runcardId As Integer, ByVal runcardpn As String, ByVal action As ActionType, ByVal stationId As String, ByVal stationNo As String, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        MAction = action
        Me.RunCardId = runcardId
        _runCardPn = runcardpn
        Me.IsQueryOldVersion = isQueryOldVersion
        _stationId = stationId
        _stationNo = stationNo
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not BasicCheck() Then
                Exit Sub
            End If
            If Not SaveData() Then
                Exit Sub
            End If
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function BasicCheck() As Boolean
        Select Case Action
            Case ActionType.ModifyStation
                If cboStation.SelectedIndex = -1 Then
                    MessageBox.Show("请选择工站")
                    Return False
                End If
                If StationExists() Then
                    MessageBox.Show("该工站已经存在，请确认！！")
                    Return False
                End If
            Case ActionType.ModifyProcessParameter, ActionType.GetProcessParameter
                If txtCutSize.Enabled = True AndAlso String.IsNullOrEmpty(txtFinishSize.Text) AndAlso String.IsNullOrEmpty(txtCutSize.Text) Then
                    MessageBox.Show("请至少输入成品尺寸或是裁线尺寸")
                    txtFinishSize.Select()
                    Return False
                End If
                If txtCutSize.Enabled = True And txtCutSize.Text.Contains("L") Then
                    MessageBox.Show("裁线尺寸输入错误")
                    txtCutSize.Select()
                    Return False
                End If
                If dgvLeft.Rows.Count > 0 Then
                    If IsLeftTvSelected() AndAlso Not IsAnyLeftLineSelected() Then
                        MessageBox.Show("选中了左端端子料号，请选择左端线材料号")
                        cboLeftLine.Select()
                        Return False
                    End If
                    If Not IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
                        MessageBox.Show("选中了左端线材料号,请选择左端端子料号")
                        cboLeftTv.Select()
                        Return False
                    End If
                    If IsLeftTvSelected() And IsAnyLeftLineSelected() Then
                        For Each dr As DataGridViewRow In dgvLeft.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageBox.Show("选择了左端信息，必须输入各个校验项的校验值或是检查加工参数是否维护")
                                Return False
                            End If
                        Next
                    End If
                End If
                If dgvRight.Rows.Count > 0 Then
                    If IsRightTvSelected() AndAlso Not IsAnyRightLineSelected() Then
                        MessageBox.Show("选中了右端端子料号，请选择右端线材料号")
                        cboLeftLine.Select()
                        Return False
                    End If
                    If Not IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
                        MessageBox.Show("选中了右端线材料号,请选择右端端子料号")
                        cboLeftTv.Select()
                        Return False
                    End If
                    If IsRightTvSelected() And IsAnyRightLineSelected() Then
                        For Each dr As DataGridViewRow In dgvRight.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageBox.Show("选择了右端信息，必须输入各个校验项的校验值或是检查加工参数是否维护")
                                Return False
                            End If
                        Next
                    End If
                End If
                If dgvLeft.Rows.Count <= 0 AndAlso dgvRight.Rows.Count > 0 Then
                    If Not IsRightTvSelected() OrElse Not IsAnyRightLineSelected() Then
                        MessageBox.Show("必须要维护右端子的信息")
                        Return False
                    End If
                ElseIf dgvLeft.Rows.Count > 0 AndAlso dgvRight.Rows.Count < 0 Then
                    If Not IsLeftTvSelected() OrElse Not IsAnyLeftLineSelected() Then
                        MessageBox.Show("必须要维护左端子的信息")
                        Return False
                    End If
                ElseIf dgvLeft.Rows.Count > 0 AndAlso dgvRight.Rows.Count > 0 Then
                    If Not IsAnyRightLineSelected() AndAlso Not IsRightTvSelected() Then
                        If Not IsAnyLeftLineSelected() AndAlso Not IsLeftTvSelected() Then
                            MessageBox.Show("必须要维护左右任意一个端子的信息")
                            Return False
                        End If
                    End If
                End If
        End Select
        Return True
    End Function

#Region "Basic Check"

    Private Function IsLeftTvSelected() As Boolean
        If cboLeftTv.SelectedItem Is Nothing OrElse String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            Return False
        End If
        Return True
    End Function

    Private Function IsAnyLeftLineSelected() As Boolean
        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        Return False
    End Function

    Private Function IsRightTvSelected() As Boolean
        If cboRightTv.SelectedItem Is Nothing OrElse String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            Return False
        End If
        Return True
    End Function

    Private Function IsAnyRightLineSelected() As Boolean
        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            Return True
        End If
        Return False
    End Function

#End Region

    Private Function SaveData() As Boolean
        Try
            Dim sql As String = ""

            Select Case Action
                Case ActionType.ModifySop

                    Dim SopFilePath As String = Me.txtSop.Text.Trim
                    Dim ServerFile As String = ""

                    If Not String.IsNullOrEmpty(Me.SopFileName) Then
                        If Not String.IsNullOrEmpty(SopFilePath) Then
                            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
                            If System.IO.Directory.Exists(destFilePath) = False Then
                                Directory.CreateDirectory(destFilePath)
                            End If
                            ServerFile = Path.Combine(destFilePath, Me.SopFileName)
                            File.Copy(SopFilePath, ServerFile, True)
                        End If
                    Else '未选择上传
                        ServerFile = SopFilePath
                    End If
                    If Me.IsQueryOldVersion = "false" Then
                        sql = "UPDATE M_RUNCARDDETAIL_T SET SOPFILEPATH=N'" & ServerFile & "'" & _
                                ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & _gridViewRow.Cells("ID").Value.ToString & "'"
                    Else
                        sql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET SOPFILEPATH=N'" & ServerFile & "'" & _
                              ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() WHERE ID='" & _gridViewRow.Cells("ID").Value.ToString & "'"
                    End If
                    outputSop = ServerFile
                Case ActionType.ModifyStation

                    row = cboStation.SelectedItem
                    Dim StationID As String = CInt(row.Item(0).ToString)
                    Dim StationName As String = row.Item(1).ToString
                    StationName = StationName.Replace("/", "")
                    StationName = StationName.Replace("\", "")
                    StationName = Replace(StationName, Chr(10), "")
                    StationName = Replace(StationName, Chr(13), "")
                    StationName = StationName.Replace(" ", "")
                    If Me.IsQueryOldVersion = "false" Then
                        sql = "UPDATE M_RUNCARDDETAIL_T SET STATIONID=" & StationID & ",EQUIPMENT=NULL,WORKINGHOURS=0,SOPFILEPATH=NULL,PROCESSSTANDARD=NULL,REMARK=NULL " & _
                        ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE(),STATIONNAME=N'" & StationName & "' WHERE ID='" & _gridViewRow.Cells("ID").Value.ToString & "'"
                        If _gridViewRow.Cells("工站ID").Value.ToString <> StationID Then
                            If MessageBox.Show("修改工站后，先前工站的检查参数都将被删除，请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                                Exit Function
                            Else
                                sql &= " DELETE FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _gridViewRow.Cells("工站ID").Value.ToString & ""
                                sql &= " DELETE A FROM M_RUNCARDPARTDETAIL_T  A,M_RUNCARDDETAIL_T B WHERE A.RUNCARDDETAILID=B.ID AND B.ID='" & _gridViewRow.Cells("ID").Value.ToString & "'"
                            End If
                        End If
                    Else
                        sql = "UPDATE M_RUNCARDDETAILOLDVERSION_T SET STATIONID=" & StationID & "" & _
                      ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE(),STATIONNAME=N'" & StationName & "' WHERE ID='" & _gridViewRow.Cells("ID").Value.ToString & "'"
                    End If
                    outputStationId = row.Item(0).ToString
                    outputStationName = row.Item(1).ToString
                Case ActionType.ModifyProcessParameter
                    If Me.IsQueryOldVersion = "false" Then
                        sql = GetSaveSql()
                        sql &= GetUpdateSql()
                        sql &= GetPnSql()
                    Else

                    End If
                Case ActionType.GetProcessParameter
                    If Me.IsQueryOldVersion = "false" Then
                        sql = GetSaveSql()
                        sql &= GetUpdateSql()
                        sql &= GetPnSqlByAdd()
                        outputProcessStand = GetAddProcessStand()
                    End If
                    outputSql = sql
                    Me.Close()
                    Exit Function
            End Select
            If sql <> "" Then
                sConn.ExecSql(sql)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Function GetSaveSql()
        Dim sql As String = Nothing
        If Not IsLeftTvSelected() OrElse Not IsAnyLeftLineSelected() Then
            For Each dr As DataGridViewRow In dgvLeft.Rows
                sql &= GetDeleteSql(dr, 0)
            Next
        Else
            If IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
                For Each dr As DataGridViewRow In dgvLeft.Rows
                    sql &= GetProcessSql(dr, 0)
                Next
            End If
        End If

        If Not IsRightTvSelected() OrElse Not IsAnyRightLineSelected() Then
            For Each dr As DataGridViewRow In dgvRight.Rows
                sql &= GetDeleteSql(dr, 1)
            Next
        Else
            If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
                For Each dr As DataGridViewRow In dgvRight.Rows
                    sql &= GetProcessSql(dr, 1)
                Next
            End If
        End If
        sql &= GetCutSql()
        Return sql
    End Function

    Private Function GetDeleteSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim sql As String = Nothing
        If type = 0 Then
            sql = "DELETE FROM M_RUNCARDDETAILCHECKITEM_T WHERE  PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='" & dr.Cells(ProcessGrid.CheckCode).Value.ToString & "'"
        ElseIf type = 1 Then
            sql = "DELETE FROM M_RUNCARDDETAILCHECKITEM_T WHERE  PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='" & dr.Cells(ProcessGrid.CheckCode).Value.ToString & "'"
        End If
        Return sql
    End Function

    Private Function GetProcessSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim sql As String = Nothing
        sql = "IF (SELECT TOP 1 1 FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='" & dr.Cells(ProcessGrid.CheckCode).Value.ToString & "')=1" & vbNewLine & _
           " BEGIN " & vbNewLine & _
           " UPDATE M_RUNCARDDETAILCHECKITEM_T SET DESCRIPTION=N'" & dr.Cells(ProcessGrid.Description).Value.ToString & "',RESULTVALUE=N'" & dr.Cells(ProcessGrid.ResultValue).Value.ToString & "' " & vbNewLine & _
           " ,STATUS='Y',USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE(),CHECKGROUP='" & dr.Cells(ProcessGrid.CheckGroup).Value.ToString & "'"
        If type = 0 Then
            If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTTVPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTTVPARTNUMBER=NULL"
            End If
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTLINEPARTNUMBER=NULL"
            End If
            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERTWO='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTLINEPARTNUMBERTWO=NULL"
            End If
            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERTHREE='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTLINEPARTNUMBERTHREE=NULL"
            End If
            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERFOUR='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTLINEPARTNUMBERFOUR=NULL"
            End If
        Else
            If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTTVPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,RIGHTTVPARTNUMBER=NULL"
            End If
            If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,LEFTLINEPARTNUMBER=NULL"
            End If
            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERTWO='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,RIGHTLINEPARTNUMBERTWO=NULL"
            End If
            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERTHREE='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,RIGHTLINEPARTNUMBERTHREE=NULL"
            End If
            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERFOUR='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'" & vbNewLine
            Else
                sql &= " ,RIGHTLINEPARTNUMBERFOUR=NULL"
            End If
        End If
        sql &= "  WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='" & dr.Cells(ProcessGrid.CheckCode).Value.ToString & "'" & vbNewLine & _
           " END " & vbNewLine & _
           " ELSE " & vbNewLine & _
            " BEGIN " & vbNewLine & _
           " INSERT INTO M_RUNCARDDETAILCHECKITEM_T(PARTNUMBER,STATIONID,STATIONNO,CHECKITEMCODE,DESCRIPTION,RESULTVALUE,STATUS,INTIME,USERID,CHECKGROUP,LEFTTVPARTNUMBER,LEFTLINEPARTNUMBER,RIGHTTVPARTNUMBER,RIGHTLINEPARTNUMBER " & vbNewLine & _
           ",LEFTLINEPARTNUMBERTWO,LEFTLINEPARTNUMBERTHREE,LEFTLINEPARTNUMBERFOUR,RIGHTLINEPARTNUMBERTWO,RIGHTLINEPARTNUMBERTHREE,RIGHTLINEPARTNUMBERFOUR" & vbNewLine & _
           " )VALUES( " & vbNewLine & _
           " '" & _runCardPn & "'," & _stationId & ",'" & _stationNo & "'," & vbNewLine & _
           " '" & dr.Cells(ProcessGrid.CheckCode).Value.ToString & "',N'" & dr.Cells(ProcessGrid.Description).Value.ToString & "',N'" & dr.Cells(ProcessGrid.ResultValue).Value.ToString & "','Y',GETDATE()," & vbNewLine & _
           " '" & VbCommClass.VbCommClass.UseId & "','" & dr.Cells(ProcessGrid.CheckGroup).Value.ToString & "',"
        If type = 0 Then
            If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            sql &= " NULL,NULL,"
            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            sql &= "NULL,NULL,NULL"
        Else
            sql &= "NULL,NULL,"
            If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            sql &= "NULL,NULL,NULL,"
            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "',"
            Else
                sql &= "NULL,"
            End If
            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= "'" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= "NULL"
            End If
        End If
        sql &= " )END " & vbNewLine
        Return sql
    End Function

    Private Function GetCutSql()
        'As is: RESULTVALUE=(SELECT " & txtCutSize.Text & "), Now:  *
        Dim sql As String = Nothing
        If txtCutSize.Enabled = True AndAlso Not String.IsNullOrEmpty(txtCutSize.Text) Then
            ReCalculateCutSize()
            sql &= "IF (SELECT TOP 1 1 FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='LCL')=1" & vbNewLine & _
                 " BEGIN " & vbNewLine & _
                " UPDATE M_RUNCARDDETAILCHECKITEM_T SET DESCRIPTION=N'裁线尺寸(mm)',RESULTVALUE= '" & txtCutSize.Text & "',LEFTCUTSIZE='" & leftFrontSize & "',RIGHTCUTSIZE='" & rightFrontSize & "' " & vbNewLine & _
                " ,STATUS='Y',USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE(),CHECKGROUP=NULL,FINISHSIZE='" & txtFinishSize.Text & "',TOLERANCE='" & txtCD.Text & "',TOLERANCERANGE='" & m_ToleranceRange & "' "
            If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTTVPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",LEFTTVPARTNUMBER=NULL "
            End If
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",LEFTLINEPARTNUMBER=NULL "
            End If
            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERTWO='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",LEFTLINEPARTNUMBERTWO=NULL "
            End If
            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERTHREE='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",LEFTLINEPARTNUMBERTHREE=NULL"
            End If
            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,LEFTLINEPARTNUMBERFOUR='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",LEFTLINEPARTNUMBERFOUR=NULL "
            End If
            If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTTVPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",RIGHTTVPARTNUMBER=NULL "
            End If
            If Not cboRightLine.SelectedItem Is Nothing And Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",RIGHTLINEPARTNUMBER=NULL"
            End If
            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERTWO='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",RIGHTLINEPARTNUMBERTWO=NULL"
            End If
            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERTHREE='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",RIGHTLINEPARTNUMBERTHREE=NULL "
            End If
            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= " ,RIGHTLINEPARTNUMBERFOUR='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",RIGHTLINEPARTNUMBERFOUR=NULL "
            End If
            sql &= " WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID='" & _stationId & "' AND CHECKITEMCODE='LCL'" & vbNewLine & _
            " END " & vbNewLine & _
            " ELSE " & vbNewLine & _
             " BEGIN " & vbNewLine & _
            " INSERT INTO M_RUNCARDDETAILCHECKITEM_T(PARTNUMBER,STATIONID,STATIONNO,CHECKITEMCODE,DESCRIPTION,RESULTVALUE," & vbNewLine & _
            " STATUS,INTIME,USERID,CHECKGROUP,TOLERANCE,TOLERANCERANGE,LEFTCUTSIZE,RIGHTCUTSIZE,LEFTTVPARTNUMBER,LEFTLINEPARTNUMBER,RIGHTTVPARTNUMBER,RIGHTLINEPARTNUMBER," & vbNewLine & _
            " FINISHSIZE,LEFTLINEPARTNUMBERTWO,LEFTLINEPARTNUMBERTHREE,LEFTLINEPARTNUMBERFOUR," & vbNewLine & _
            " RIGHTLINEPARTNUMBERTWO,RIGHTLINEPARTNUMBERTHREE,RIGHTLINEPARTNUMBERFOUR) VALUES (" & vbNewLine & _
            " '" & _runCardPn & "'," & _stationId & ",'" & _stationNo & "'," & vbNewLine & _
            " 'LCL',N'裁线尺寸(mm)', '" & txtCutSize.Text & "','Y',GETDATE()," & vbNewLine & _
            " '" & VbCommClass.VbCommClass.UseId & "',NULL,'" & txtCD.Text & "','" & m_ToleranceRange & "','" & leftFrontSize & "','" & rightFrontSize & "'"
            If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            sql &= ",'" & txtFinishSize.Text & "'"
            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString) Then
                sql &= ",'" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value.ToString & "'"
            Else
                sql &= ",NULL"
            End If
            sql &= " )END "
        End If
        Return sql
    End Function

    Private Function GetUpdateSql()
        Dim sql As String = Nothing
        sql = " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDDETAILCHECKITEM_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & " AND STATUS='Y'),0)=1" & vbNewLine & _
        " BEGIN " & vbNewLine & _
" UPDATE M_RUNCARDDETAIL_T SET PROCESSSTANDARD=( " & vbNewLine & _
" SELECT (DESCRIPTION+':'+RESULTVALUE)+'; ' FROM M_RUNCARDDETAILCHECKITEM_T " & vbNewLine & _
" WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "  " & vbNewLine & _
" AND  RESULTVALUE<>'' AND STATUS='Y' ORDER BY CHECKGROUP " & vbNewLine & _
" FOR XML PATH('')) WHERE  PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & " END"
        Return sql
    End Function

    Private Function GetPnSql() As String
        Dim sql As String = Nothing
        Dim leftExists As Boolean = False
        Dim rightExists As Boolean = False
        If IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            leftExists = True

        End If
        If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
            'If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            '    If leftExists AndAlso CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value = CType(cboRightLine.SelectedItem, ComboxBoxItem).Value Then
            '        rightExists = True
            '    End If
            '    If Not rightExists Then
            '        sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
            '           " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
            '           " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
            '           " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            '    End If
            '    If leftExists AndAlso CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value <> CType(cboRightTv.SelectedItem, ComboxBoxItem).Value Then
            '        rightExists = True
            '    End If
            '    If Not rightExists Then
            '        sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
            '      " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
            '      " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
            '      " GETDATE(),'" & _runCardPn & "','" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            '    End If
            'End If
            If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
                        " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
                        " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
                        " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES(" & _gridViewRow.Cells("ID").Value.ToString & ", " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
        End If
        Return sql
    End Function

    Private Function GetPnSqlByAdd() As String
        Dim sql As String = Nothing
        Dim leftExists As Boolean = False
        Dim rightExists As Boolean = False
        If IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
            If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            leftExists = True

        End If
        If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
            'If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            '    If leftExists AndAlso CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value = CType(cboRightLine.SelectedItem, ComboxBoxItem).Value Then
            '        rightExists = True
            '    End If
            '    If Not rightExists Then
            '        sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
            '           " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
            '           " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
            '           " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "', " & _runCardId & " ) END "
            '    End If
            '    If leftExists AndAlso CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value <> CType(cboRightTv.SelectedItem, ComboxBoxItem).Value Then
            '        rightExists = True
            '    End If
            '    If Not rightExists Then
            '        sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
            '      " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
            '      " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
            '      " GETDATE(),'" & _runCardPn & "','" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            '    End If
            'End If
            If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
                sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
            End If

            sql &= " IF ISNULL((SELECT TOP 1 1 FROM M_RUNCARDPARTDETAIL_T WHERE EWPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "' AND PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "),0)<>1" & vbNewLine & _
          " BEGIN INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER,STATIONID) VALUES((SELECT TOP 1 ID FROM M_RUNCARDDETAIL_T WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "), " & vbNewLine & _
          " (SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'),'" & VbCommClass.VbCommClass.UseId & "', " & vbNewLine & _
          " GETDATE(),'" & _runCardPn & "','" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "', " & _stationId & " ) END "
        End If
        Return sql
    End Function

    Private Function GetProcessStand()
        Dim sql As String = " SELECT (DESCRIPTION+':'+RESULTVALUE)+';'+CHAR(10) FROM M_RUNCARDDETAILCHECKITEM_T " & vbNewLine & _
" WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & "  " & vbNewLine & _
" AND  RESULTVALUE<>'' AND STATUS='Y' ORDER BY CHECKGROUP " & vbNewLine & _
" FOR XML PATH('')"
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return Nothing
            End If
        End Using

    End Function

    Dim row As System.Data.DataRowView

    Private Function StationExists() As Boolean
        row = cboStation.SelectedItem
        Dim sql As String = Nothing
        If Me.IsQueryOldVersion = "false" Then
            sql = "SELECT STATIONID FROM M_RUNCARDDETAIL_T WHERE RUNCARDID=" & Me.RunCardId & " AND STATIONID=" & row.Item(0).ToString & ""
        Else
            sql = "SELECT STATIONID FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=" & Me.RunCardId & " AND STATIONID=" & row.Item(0).ToString & ""
        End If
        If sConn.GetRowsCount(sql) > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not dt Is Nothing Then
            dt.Dispose()
            dt = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub cboLeftTv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftTv.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
            If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                ReSetLeftLineSelected()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReSetLeftLineSelected()
        If Not cboLeftLine.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            cboLeftLine.SelectedItem = cboRightLine.SelectedItem
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            cboLeftLineTwo.SelectedItem = cboRightLineTwo.SelectedItem
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            cboLeftLineThree.SelectedItem = cboRightLineThree.SelectedItem
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            cboLeftLineFour.SelectedItem = cboRightLineFour.SelectedItem
        End If
    End Sub

    Private Sub cboLeftLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLine.SelectedIndexChanged
        Try
            'If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            '    If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            '        GetLeftProcessParameters()
            '    Else
            '        ResetLeftProcessParameters()
            '        leftFrontSize = ""
            '    End If
            'Else
            '    ResetLeftProcessParameters()
            '    leftFrontSize = ""
            'End If
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineTwo.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineThree_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineThree.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineFour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineFour.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetLeftPns()
        Dim pns As String = Nothing
        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        Return pns.Trim(",")
    End Function

    Dim leftFrontSize As String = Nothing

    Private Sub GetLeftProcessParametersByFormLoad()
        Dim leftTvWhere As String = Nothing
        Dim leftLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False
        Dim Sql As String = "SELECT BRASSHEIGHT 'LCH',BRASSWIDTH 'LCW',DRAWFORCE 'LDF'," & vbNewLine & _
                   " PEELSIZE 'LPL',CUTSIZE 'LCL',FRONTSIZE FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1 "

        If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            leftTvWhere &= " AND TVPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If

        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBER IS NULL "
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERTWO IS NULL "
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERTHREE IS NULL "
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERFOUR IS NULL "
        End If
        Sql &= "  AND STATUS='Y' "
        If String.IsNullOrEmpty(leftTvWhere) OrElse Not isLineSelected Then
            leftFrontSize = ""
            ResetLeftProcessParameters()
        Else
            Using dt As DataTable = sConn.GetDataTable(Sql & leftTvWhere & leftLineWhere)
                If dt.Rows.Count > 0 Then
                    leftFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                Else
                    leftFrontSize = ""
                    ResetLeftProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub GetLeftProcessParameters()
        Dim leftTvWhere As String = Nothing
        Dim leftLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False
        ' LCL	裁线尺寸，CUTSIZE 'LPL'==》 CUTSIZE LCL,CQ 20150526

        Dim Sql As String = "SELECT BRASSHEIGHT 'LCH',BRASSWIDTH 'LCW',DRAWFORCE 'LDF'," & vbNewLine & _
                   " PEELSIZE 'LPL',CUTSIZE 'LCL',FRONTSIZE FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1 "

        If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            leftTvWhere &= " AND TVPARTNUMBER='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If

        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBER IS NULL "
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            leftLineWhere &= " AND WIREPARTNUMBERTWO IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERTWO IS NULL "
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            leftLineWhere &= " AND WIREPARTNUMBERTHREE IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERTHREE IS NULL "
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            leftLineWhere &= " AND WIREPARTNUMBERFOUR IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WIREPARTNUMBERFOUR IS NULL "
        End If
        Sql &= "  AND STATUS='Y' "
        If String.IsNullOrEmpty(leftTvWhere) OrElse Not isLineSelected Then
            leftFrontSize = ""
            ResetLeftProcessParameters()
        Else
            Using dt As DataTable = sConn.GetDataTable(Sql & leftTvWhere & leftLineWhere)
                If dt.Rows.Count > 0 Then
                    For index As Integer = 0 To dgvLeft.Rows.Count - 1
                        dgvLeft.Rows(index).Cells(ProcessGrid.ResultValue).Value = dt.Rows(0)(dgvLeft.Rows(index).Cells(ProcessGrid.CheckCode).Value).ToString
                    Next
                    leftFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                Else
                    leftFrontSize = ""
                    ResetLeftProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub ResetLeftProcessParameters()
        For index As Integer = 0 To dgvLeft.Rows.Count - 1
            dgvLeft.Rows(index).Cells(ProcessGrid.ResultValue).Value = ""
        Next
    End Sub

    Private Sub cboRightTv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightTv.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
            If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                ReSetRightLineSelected()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReSetRightLineSelected()
        If Not cboRightLine.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            cboRightLine.SelectedItem = cboLeftLine.SelectedItem
        End If
        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            cboRightLineTwo.SelectedItem = cboLeftLineTwo.SelectedItem
        End If
        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            cboRightLineThree.SelectedItem = cboLeftLineThree.SelectedItem
        End If
        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            cboRightLineFour.SelectedItem = cboLeftLineFour.SelectedItem
        End If
    End Sub

    Private Sub cboRightLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLine.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineTwo.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineThree_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineThree.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineFour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineFour.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetRightPns()
        Dim pns As String = Nothing
        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            pns &= "'" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "',"
        End If
        Return pns.Trim(",")
    End Function

    Dim rightFrontSize As String = Nothing

    Private Sub GetRightProcessParametersByFormLoad()
        Dim rightTvWhere As String = Nothing
        Dim rightLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False

        'CUTSIZE 'RPL' ==> CUTSIZE 'RCL, CQ
        Dim Sql As String = "SELECT BRASSHEIGHT 'RCH',BRASSWIDTH 'RCW',DRAWFORCE 'RDF'," & vbNewLine & _
                   " PEELSIZE 'RPL',CUTSIZE 'RCL',FRONTSIZE FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1" & vbNewLine
        If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            rightTvWhere = " AND TVPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If
        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBER IS NULL "
        End If

        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERTWO IS NULL "
        End If

        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERTHREE IS NULL "
        End If

        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERFOUR IS NULL "
        End If
        Sql &= " AND STATUS='Y' "
        If String.IsNullOrEmpty(rightTvWhere) OrElse Not isLineSelected Then
            rightFrontSize = ""
            ResetRightProcessParameters()
        Else
            Using dt As DataTable = sConn.GetDataTable(Sql & rightTvWhere & rightLineWhere)
                If dt.Rows.Count > 0 Then
                    rightFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                Else
                    rightFrontSize = ""
                    ResetRightProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub GetRightProcessParameters()
        Dim rightTvWhere As String = Nothing
        Dim rightLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False
        Dim Sql As String = "SELECT BRASSHEIGHT 'RCH',BRASSWIDTH 'RCW',DRAWFORCE 'RDF'," & vbNewLine & _
                   " PEELSIZE 'RPL',CUTSIZE 'RPL',FRONTSIZE FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1" & vbNewLine
        If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            rightTvWhere = " AND TVPARTNUMBER='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If
        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBER IS NULL "
        End If

        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WIREPARTNUMBERTWO IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERTWO IS NULL "
        End If

        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WIREPARTNUMBERTHREE IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERTHREE IS NULL "
        End If

        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WIREPARTNUMBER='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTWO='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERTHREE='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WIREPARTNUMBERFOUR='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WIREPARTNUMBERFOUR IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WIREPARTNUMBERFOUR IS NULL "
        End If
        Sql &= " AND STATUS='Y' "
        If String.IsNullOrEmpty(rightTvWhere) OrElse Not isLineSelected Then
            rightFrontSize = ""
            ResetRightProcessParameters()
        Else
            Using dt As DataTable = sConn.GetDataTable(Sql & rightTvWhere & rightLineWhere)
                If dt.Rows.Count > 0 Then
                    For index As Integer = 0 To dgvRight.Rows.Count - 1
                        dgvRight.Rows(index).Cells(ProcessGrid.ResultValue).Value = dt.Rows(0)(dgvRight.Rows(index).Cells(ProcessGrid.CheckCode).Value).ToString
                    Next
                    rightFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                Else
                    rightFrontSize = ""
                    ResetRightProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub ResetRightProcessParameters()
        For index As Integer = 0 To dgvRight.Rows.Count - 1
            dgvRight.Rows(index).Cells(ProcessGrid.ResultValue).Value = ""
        Next
    End Sub

    Private Sub ResetCutSize()
        If txtCutSize.Enabled = True Then
            If Not String.IsNullOrEmpty(leftFrontSize) AndAlso Not String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + leftFrontSize + "-" + rightFrontSize
            ElseIf Not String.IsNullOrEmpty(leftFrontSize) AndAlso String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + leftFrontSize
            ElseIf String.IsNullOrEmpty(leftFrontSize) AndAlso Not String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + rightFrontSize
            Else
                txtQDCutSize.Text = "-0"
            End If
        End If
    End Sub

    Private Function GetAddProcessStand() As String
        Dim stand As String = Nothing
        If IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
            For Each dr As DataGridViewRow In dgvLeft.Rows
                stand &= " " + dr.Cells(ProcessGrid.Description).Value.ToString + ":" + dr.Cells(ProcessGrid.ResultValue).Value.ToString + ";"
            Next
        End If
        If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
            For Each dr As DataGridViewRow In dgvRight.Rows
                stand &= " " + dr.Cells(ProcessGrid.Description).Value.ToString + ":" + dr.Cells(ProcessGrid.ResultValue).Value.ToString + ";"
            Next
        End If
        Return stand
    End Function

    Private Sub txtFinishSize_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadCommonDifference()
        ReCalculateCutSize()
    End Sub

    Private Sub LoadCommonDifference()
        If String.IsNullOrEmpty(txtFinishSize.Text) Or txtFinishSize.Text = "0" Then
            txtCD.Text = "-0"
            Exit Sub
        End If
        Dim sql As String = "SELECT TOP 1 CUTSIZEMIN, TOLERANCERANGE  FROM DBO.M_RUNCARDALLOWANCEPARAMETER_T " & vbNewLine & _
        " WHERE (FINISHSIZERANGEMIN<=" & txtFinishSize.Text & " AND  FINISHSIZERANGEMAX>=" & txtFinishSize.Text & ")" & vbNewLine & _
        " OR(FINISHSIZERANGEMIN<=" & txtFinishSize.Text & " AND (FINISHSIZERANGEMAX IS NULL OR FINISHSIZERANGEMAX=''))"
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Dim result = dt.Rows(0)(0).ToString

                m_ToleranceRange = dt.Rows(0)(1).ToString  '±1
                If result.Contains("L") Then
                    txtCD.Text = result.Replace("L", txtFinishSize.Text)
                    m_ToleranceRange = m_ToleranceRange.Replace("±L", "")
                    Call CalculateTolerance(m_ToleranceRange)  '±L*0.002
                Else
                    txtCD.Text = result
                End If
            Else
                txtCD.Text = "+0"
                m_ToleranceRange = "±0"
            End If
        End Using
    End Sub

    Private Sub CalculateTolerance(ByVal parToleranceRange As String)
        Using dt As DataTable = sConn.GetDataTable("SELECT  FLOOR(" & txtFinishSize.Text & parToleranceRange & ")")
            If dt.Rows.Count > 0 Then
                m_ToleranceRange = "±" + dt.Rows(0)(0).ToString  '20
            Else
                m_ToleranceRange = ""
            End If

        End Using
    End Sub

    Private Sub ReCalculateCutSize()
        Dim strCDSizeSign As String = ""
        Try
            If String.IsNullOrEmpty(txtFinishSize.Text) Or txtFinishSize.Text = "0" Then Exit Sub

            'SELECT 180-0± FLOOR(0)
            '加减符号
            If Me.txtCD.Text.Substring(0, 1) = "±" Then
                strCDSizeSign = "+"
            Else
                strCDSizeSign = Me.txtCD.Text.Substring(0, 1)
            End If

            Using dt As DataTable = sConn.GetDataTable("SELECT " & txtFinishSize.Text & txtQDCutSize.Text & strCDSizeSign & " FLOOR(" & txtCD.Text.Substring(1) & ")")
                If dt.Rows.Count > 0 Then
                    txtCutSize.Text = dt.Rows(0)(0).ToString
                Else
                    txtCutSize.Text = 0
                End If
            End Using

            txtCutSize.Text = txtCutSize.Text & m_ToleranceRange
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim currentValue As String = Nothing
    Private currentRowIndex As Integer
    Private currentDataGrid As Integer
    Private isClose = False
    Private updateSql = Nothing

#Region " auto update"
    Private Sub dgvRight_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRight.CellEnter
        Try
            If e.RowIndex < dgvRight.Rows.Count AndAlso Me.dgvRight.ReadOnly = False Then
                currentDataGrid = 1
                currentRowIndex = e.RowIndex
                currentValue = dgvRight.CurrentCell.FormattedValue.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvRight_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRight.CellLeave
        Try
            If dgvRight.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                UpdateData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvLeft_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLeft.CellEnter
        Try
            If e.RowIndex < dgvLeft.Rows.Count AndAlso Me.dgvLeft.ReadOnly = False Then
                currentDataGrid = 0
                currentRowIndex = e.RowIndex
                currentValue = dgvLeft.CurrentCell.FormattedValue.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvLeft_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLeft.CellLeave
        Try
            If dgvLeft.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                UpdateData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UpdateData()
        updateSql = Nothing
        If currentDataGrid = 0 Then
            If dgvLeft.Rows.Count > 0 Then
                If dgvLeft.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvLeft.CurrentCell Is Nothing AndAlso Not dgvLeft.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvLeft.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                        updateSql = "UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & dgvLeft.CurrentCell.EditedFormattedValue.ToString & "' " & vbNewLine & _
                        " WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & " AND CHECKITEMCODE='" & dgvLeft.Rows(currentRowIndex).Cells(ProcessGrid.CheckCode).Value & "'"
                        updateSql &= GetUpdateSql()
                    End If
                End If
            End If
        ElseIf currentDataGrid = 1 Then
            If dgvRight.Rows.Count > 0 Then
                If dgvRight.IsCurrentCellInEditMode Or isClose Then
                    If Not dgvRight.CurrentCell Is Nothing AndAlso Not dgvRight.CurrentCell.EditedFormattedValue.ToString Is Nothing AndAlso dgvRight.CurrentCell.EditedFormattedValue.ToString <> currentValue Then
                        updateSql = "UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & dgvRight.CurrentCell.EditedFormattedValue.ToString & "' " & vbNewLine & _
                        " WHERE PARTNUMBER='" & _runCardPn & "' AND STATIONID=" & _stationId & " AND CHECKITEMCODE='" & dgvRight.Rows(currentRowIndex).Cells(ProcessGrid.CheckCode).Value & "'"
                        updateSql &= GetUpdateSql()
                    End If
                End If
            End If
        End If
        If Not String.IsNullOrEmpty(updateSql) Then
            sConn.ExecSql(updateSql)
        End If
    End Sub
#End Region

#Region "提示"
    Private ttLeft As ToolTip = Nothing
    Private ttRight As ToolTip = Nothing
    Private Sub InitTools()
        ttLeft = New ToolTip()
        ttRight = New ToolTip
    End Sub

    Private Sub cboLeftTv_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftTv.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboLeftTv.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttLeft.Show(cboLeftTv.Items(e.Index).ToString(), cboLeftTv, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboLeftTv_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftTv.DropDownClosed
        ttLeft.Hide(cboLeftTv)
    End Sub

    Private Sub cboLeftLine_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftLine.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboLeftLine.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttLeft.Show(cboLeftLine.Items(e.Index).ToString(), cboLeftLine, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboLeftLine_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLine.DropDownClosed
        ttLeft.Hide(cboLeftLine)
    End Sub

    Private Sub cboLeftLineTwo_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftLineTwo.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboLeftLineTwo.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttLeft.Show(cboLeftLineTwo.Items(e.Index).ToString(), cboLeftLineTwo, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboLeftLineTwo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineTwo.DropDownClosed
        ttLeft.Hide(cboLeftLineTwo)
    End Sub

    Private Sub cboLeftLineThree_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftLineThree.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboLeftLineThree.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttLeft.Show(cboLeftLineThree.Items(e.Index).ToString(), cboLeftLineThree, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboLeftLineThree_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineThree.DropDownClosed
        ttLeft.Hide(cboLeftLineThree)
    End Sub

    Private Sub cboLeftLineFour_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftLineFour.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboLeftLineFour.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttLeft.Show(cboLeftLineFour.Items(e.Index).ToString(), cboLeftLineFour, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboLeftLineFour_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineFour.DropDownClosed
        ttLeft.Hide(cboLeftLineFour)
    End Sub

    Private Sub cboRightTv_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboRightTv.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboRightTv.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttRight.Show(cboRightTv.Items(e.Index).ToString(), cboRightTv, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboRightTv_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightTv.DropDownClosed
        ttRight.Hide(cboRightTv)
    End Sub

    Private Sub cboRightLine_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboRightLine.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboRightLine.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttRight.Show(cboRightLine.Items(e.Index).ToString(), cboRightLine, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboRightLine_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLine.DropDownClosed
        ttRight.Hide(cboRightLine)
    End Sub

    Private Sub cboRightLineTwo_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboRightLineTwo.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboRightLineTwo.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttRight.Show(cboRightLineTwo.Items(e.Index).ToString(), cboRightLineTwo, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboRightLineTwo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineTwo.DropDownClosed
        ttRight.Hide(cboRightLineTwo)
    End Sub

    Private Sub cboRightLineThree_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboRightLineThree.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboRightLineThree.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttRight.Show(cboRightLineThree.Items(e.Index).ToString(), cboRightLineThree, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboRightLineThree_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineThree.DropDownClosed
        ttRight.Hide(cboRightLineThree)
    End Sub

    Private Sub cboRightLineFour_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboRightLineFour.DrawItem
        e.DrawBackground()
        e.Graphics.DrawString(cboRightLineThree.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ttRight.Show(cboRightLineFour.Items(e.Index).ToString(), cboRightLineFour, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub cboRightLineFour_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineFour.DropDownClosed
        ttRight.Hide(cboRightLineFour)
    End Sub
#End Region

End Class

#Region "ComboxBoxItem"
Public Class ComboxBoxItem
    Private _text As String = Nothing
    Private _value As Object = Nothing
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return _text
    End Function
End Class
#End Region
