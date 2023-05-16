Option Strict On
Option Explicit On
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports BasicManagement.FrmRStationSet
Imports MainFrame

Public Class FrmOldCutCardBodyEdit

#Region "构造函数"
    Sub New(ByVal cutCardPn As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As Boolean)
        Try
            ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent()

            '在 InitializeComponent() 调用之后添加任何初始化。
            'Me._runCardID = runCardPartId
            Me._cutCardPn = cutCardPn
            Me._gridViewRow = dataGridViewRow
            Me._action = action
            Me._isQueryOldVersion = isQueryOldVersion

            If _gridViewRow IsNot Nothing Then
                stationId = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
                stationName = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardBodyEdit", "New01", "RCard")
        End Try
    End Sub
    Private frm As FrmOldCutCardModify
    Sub New(ByVal cutCardPn As String, ByVal action As String, _
            ByVal dataGridViewRow As DataGridViewRow, ByVal form As FrmOldCutCardModify, _
            drawingVer As String, ByVal isQueryOldVersion As Boolean, Optional ByVal iMaxStationSQ As Integer = -1)
        Try
            ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent()

            '在 InitializeComponent() 调用之后添加任何初始化。
            'Me._runCardID = runCardPartId
            Me._cutCardPn = cutCardPn
            Me._gridViewRow = dataGridViewRow
            If _gridViewRow IsNot Nothing Then
                If iMaxStationSQ > 0 Then
                    Me.stationSeq = CStr(iMaxStationSQ)
                Else
                    Me.stationSeq = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value.ToString
                End If

                'add by cq20190624
                stationId = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
                stationName = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString
                m_strLeftProcessStdFromCut = dataGridViewRow.Cells(RunCardBusiness.CutBodyGrid.LeftProcessStandard.ToString).Value.ToString
                m_strRightProcessStdFromCut = dataGridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.RightProcessStandard.ToString).Value.ToString
            End If
            Me._action = action
            Me.drawingVer = drawingVer
            frm = form
            Me._isQueryOldVersion = isQueryOldVersion
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardBodyEdit", "New02", "RCard")
        End Try
    End Sub
#End Region

#Region "属性"

    Private processStandardSql As String = Nothing
    Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,6})(\.\d{0,6}[1-9])?$")
    Dim row As System.Data.DataRowView
    Public processStandand As String
    Public m_iFinishSize As Integer = 0
    Public m_iVarValue1 As Integer = 0
    Public m_iVarValue2 As Integer = 0
    Public m_strVarName1 As String = ""
    Public m_strVarName2 As String = ""
    Public workHour As String
    Public stationSeq As String
    Public sopPath As String
    Public equipment As String
    'Public id As String
    Public stationId As String
    Public stationName As String
    Public drawingVer As String
    Private _isQueryOldVersion As Boolean
    Public m_iTotalStdTime As Integer = 0
    Private m_blnExistsVar As Boolean = False
    Private m_strOldStationID As String = ""
    Public m_strLeftProcessStdFromCut As String = "" '接受从制作页面传过来的
    Public m_strRightProcessStdFromCut As String = ""
    Public m_strLeftTVPN As String = String.Empty
    Public m_strRightTVPN As String = String.Empty
    Public m_strLCLValue As String = String.Empty
    Public m_strOldWirePN As String = ""

#Region "CutCardID"
    Private _cutCardPn As String
    Public Property CutCardPN() As String
        Get
            Return _cutCardPn
        End Get

        Set(ByVal Value As String)
            _cutCardPn = Value
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
    Public Property Action() As String
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

#Region "事件"

#Region "FrmCutCardCutEdit_Load"
    Private Sub FrmCutCardEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblMsg.Text = ""
            Me.txtPartNumber.Text = Me.CutCardPN
            Select Case Action
                Case "add", "insert"
                    '绑定工站
                    FillCombox(Me.cboStation)
                    Me.txtSopFilePath.Enabled = False
                    Me.txtSopFilePath.ReadOnly = True
                    txtRemark.Enabled = True
                    Me.cboStation.SelectedIndex = -1
                Case "modify"
                    '绑定工站
                    FillCombox(Me.cboStation)
                    IniteControls()
                    If CheckStationMaintainCheckItem() Then
                        txtProcessStandard.Enabled = True
                    End If
                    txtSopFilePath.Enabled = False
                    txtEquipment.Enabled = False
                    txtRemark.Enabled = True
                    If stationId IsNot Nothing Then
                        cboStation.SelectedValue = stationId + "-" + Me.stationName
                        cboStation.Text = stationName
                    End If
                    Me.txtStationid.Text = stationId + "-" + stationName
                    m_strOldStationID = stationId
                Case Else
                    txtPartNumber.Enabled = False
                    txtProcessStandard.Enabled = True
                    txtEquipment.Enabled = False
                    txtSopFilePath.Enabled = False
                    txtRemark.Enabled = False
                    IniteControls()
                    m_strOldStationID = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)
            End Select

            Me.Top = CInt(Screen.PrimaryScreen.WorkingArea.Height * 0.15)
            Me.txtOldCutCardVer.Text = Me.drawingVer
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardBodyEdit", "FrmCutCardEdit_Load", "RCard")
        End Try
    End Sub

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
                If Action = "add" Then
                    frm.BindBodyWhenAdd(_cutCardPn)
                    Me.txtStationid.Text = ""
                    Me.txtProcessStandard.Text = ""
                    Me.txtEquipment.Text = ""
                    Me.txtSopFilePath.Text = ""
                    Me.txtRemark.Text = ""
                    Me.txtStationid.Focus()
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardBodyEdit", "btnOK_Click", "RCard")
        End Try
    End Sub
#End Region



#Region "Enter Event"

    Private Sub txtRemark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemark.KeyPress
        If e.KeyChar = Chr(13) Then
            btnOK.Select()
        End If
        Return
    End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStation.SelectedIndexChanged
        Dim o_stdTime As String = ""
        Try
            If IsNothing(Me.cboStation.SelectedValue) Then
                Exit Sub
            Else
                If Me.cboStation.SelectedValue.ToString = "System.Data.DataRowView" Then
                    Exit Sub
                End If
            End If

            Me.lblMsg.Text = ""
            processStandardSql = Nothing
            Me.txtStationid.Text = CStr(Me.cboStation.SelectedValue)
            CheckStationMaintainCheckItem()
            If Action = "modify" Then
                ' btnGetProcessStandard.Enabled = False, mark by CQ 20150925
            End If

            Call GetAndSetEquAndSOP()

            m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_cutCardPn, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)))
            If m_iFinishSize > 0 Then
                o_stdTime = CStr(GetStdTime(""))
                If Val(o_stdTime) > 0 Then
                    ' iiWoringHours.Text = o_stdTime
                Else
                    'do nothing
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "cboStation_SelectedIndexChanged", "RCard")
        End Try
    End Sub


    Private Sub GetAndSetEquAndSOP()
        Try
            If Not String.IsNullOrEmpty(Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then
                Dim sql As String = ""
                sql = " SELECT  ISNULL(Equipment,'') Equipment ,ISNULL(SopFilePath,'') SopFilePath " & _
                      " FROM m_Rstation_t WHERE Stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "'"

                Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                    If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                        Me.txtEquipment.Text = CStr(dt.Rows(0).Item("Equipment"))
                        Me.txtSopFilePath.Text = CStr(dt.Rows(0).Item("SopFilePath"))
                    End If
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "GetAndSetEquAndSOP", "RCard")
        End Try
    End Sub

#End Region

#Region "退出"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "方法"

#Region "Tab"
    'Private Sub FrmRunCardEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
#End Region

#Region "初始化控件并且赋值"
    Private Sub IniteControls()
        Try
            If Not Me.SelectedGridViewRow Is Nothing Then
                'Me.lblId.Text = _gridViewRow.Cells(BodyGrid.).Value.ToString
                Me.txtEquipment.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.Equipment.ToString).Value.ToString
                Me.txtProcessStandard.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Value.ToString
                If Not IsNothing(_gridViewRow.Cells(RunCardBusiness.CutBodyGrid.SOP.ToString).Value) Then
                    Me.txtSopFilePath.Text = _gridViewRow.Cells(RunCardBusiness.CutBodyGrid.SOP.ToString).Value.ToString
                Else
                    Me.txtSopFilePath.Text = ""
                End If
                Me.txtRemark.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.Remark.ToString).Value.ToString
                Me.txtLCLValue.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.LCLValue.ToString).Value.ToString
                Me.txtLeftProcessStandard.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.LeftProcessStandard.ToString).Value.ToString
                Me.txtRightProcessStandard.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.RightProcessStandard.ToString).Value.ToString
                Me.txtLeftTVPN.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.LeftTVPN.ToString).Value.ToString
                Me.txtRightTVPN.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.RightTVPN.ToString).Value.ToString

                Me.txtWirePN.Text = _gridViewRow.Cells(RunCardBusiness.OldCutBodyGrid.WirePN.ToString).Value.ToString
                m_strOldWirePN = Me.txtWirePN.Text
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "IniteControls", "RCard")
        End Try
    End Sub
#End Region

#Region "绑定下拉列表框"
    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim lsSQL As String = ""
        Try
            If ColComboBox.Name = "cboStation" Then
                ColComboBox.Items.Clear()
                Select Case Action
                    Case "add", "insert"
                        lsSQL = " SELECT stationid + '-' + StationName as Stationid, (StationName + IIf(isnull(cabletype,'')='','', '-' + CableType))  StationName FROM m_Rstation_t(nolock)" & _
                                " WHERE  stationtype='R' AND usey='Y' ORDER BY STATIONNAME"
                        UserDg = DbOperateUtils.GetDataTable(lsSQL)
                        cboStation.DataSource = UserDg.DefaultView
                        cboStation.DisplayMember = "StationName"
                        cboStation.ValueMember = "Stationid"
                    Case "modify"
                        If stationId Is Nothing Then
                            stationId = String.Empty
                        End If
                        If stationName Is Nothing Then
                            stationName = String.Empty
                        End If
                        'Dim sql As String = " SELECT '" & stationId & "'+'-'+ N'" & stationName & "' StationID,N'" & stationName & "' StationName  UNION "
                        'sql += " SELECT stationid+'-'+ StationName as StationID, (StationName + IIf(isnull(cabletype,'')='','', '-' + CableType))  StationName FROM m_Rstation_t(nolock) " & _

                        Dim sql As String = " SELECT stationid+'-'+ StationName as StationID, (StationName + IIf(isnull(cabletype,'')='','', '-' + CableType))  StationName " & _
                                            " FROM m_Rstation_t(nolock) " & _
                               " WHERE  stationtype ='R' and usey='Y' ORDER BY STATIONNAME "
                        UserDg = DbOperateUtils.GetDataTable(sql)
                        cboStation.DataSource = UserDg
                        cboStation.DisplayMember = "StationName"
                        cboStation.ValueMember = "Stationid"
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "FillCombox", "RCard")
            Throw ex
        End Try
    End Sub
#End Region

#Region "输入完整性检查"
    Private Function CheckInput() As Boolean
        Try
            '工站
            If String.IsNullOrEmpty(Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then
                lblMsg.Text = "请选择工站"
                Me.txtStationid.Focus()
                Return False
            End If

            row = CType(cboStation.SelectedItem, DataRowView)
            If IsNothing(row) Then
                lblMsg.Text = "工站不存在,请检查！"
                cboStation.Select()
                cboStation.SelectAll()
                Return False
            End If
            'Modify by cq20170705,add insert
            If Me.Action = "add" OrElse Me.Action = "modify" OrElse Me.Action = "insert" Then
                If StationExists(Me.CutCardPN, row.Item(0).ToString.Trim().Split(CChar("-"))(0)) Then 'StationExists(Me.RunCardPN, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then
                    If Not String.IsNullOrEmpty(m_strOldStationID) AndAlso m_strOldStationID = row.Item(0).ToString.Trim().Split(CChar("-"))(0) Then
                        'pass
                    Else
                        lblMsg.Text = "工站" & row.Item(0).ToString.Trim().Split(CChar("-"))(1) & "已存在,请勿重复"
                        cboStation.Select()
                        cboStation.SelectAll()
                        Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "CheckInput", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "检查工站是否存在"
    Private Function StationExists(ByVal runCardPartId As String, ByVal stationId As String) As Boolean
        Dim StrSql As String = Nothing
        Try
            If _isQueryOldVersion = False Then
                StrSql = "SELECT 1 FROM m_RCardCutD_t(NOLOCK) WHERE PartID='" & runCardPartId & "' AND StationID='" & stationId & "' "
            Else
                StrSql = "SELECT 1 FROM m_RCardCutDOldVer_t(NOLOCK) WHERE PartID='" & runCardPartId & "' AND StationID='" & stationId & "' "
            End If
            Using dt As DataTable = DbOperateUtils.GetDataTable(StrSql)
                If dt.Rows.Count > 0 Then Return True
            End Using
            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "StationExists", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "保存"
    Public Function SaveData() As Boolean
        Try
            Dim StrSql As String = String.Empty
            Dim StationID As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)
            Me.stationId = StationID
            Dim StationName As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(1)
            StationName = StationName.Replace("/", "").Replace("\", "").Replace(Chr(10), "").Replace(Chr(13), "").Trim
            Dim StationSQ As Integer = 0  ' CInt(Me.iiStationSQ.Value.ToString())
            Dim WorkingHours As Double = 0  ' Val(Me.iiWoringHours.Text)
            Dim Equipment As String = Me.txtEquipment.Text.Trim
            Dim ProcessStandard As String = Me.txtProcessStandard.Text.Trim
            Dim LeftProcessStandard As String = Me.txtLeftProcessStandard.Text.Trim
            Dim RightProcessStandard As String = Me.txtRightProcessStandard.Text.Trim
            Dim LCLValue As String = Me.txtLCLValue.Text.Trim
            Dim o_strLeftTVPN As String = Me.txtLeftTVPN.Text.Trim
            Dim o_strRightTVPN As String = Me.txtRightTVPN.Text.Trim
            Dim o_strWirePN As String = Me.txtWirePN.Text.Trim
            Dim remark As String = Me.txtRemark.Text.Trim
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim Shape As String = String.Empty
            Dim factoryID As String = VbCommClass.VbCommClass.Factory
            Dim profitCenter As String = VbCommClass.VbCommClass.profitcenter
            Dim result As String = String.Empty
            Dim iInsertStationSQ As Integer = -1
            '新增
            If Not CheckStationExists() Then
                lblMsg.Text = "选择的工站不存在"
                Return False
            End If

            If Me.stationId <> m_strOldStationID Then 'Add by CQ 20151102
                Me.stationId = m_strOldStationID
            End If

            Select Case Action
                Case "add"
                    StrSql = " DECLARE @StationSQ INT;UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.CutCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter() &
                              " SELECT @StationSQ=MAX(StationSQ) FROM {1}(nolock) where PartID='" & Me.CutCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter() &
                              " IF @StationSQ IS NULL SET @StationSQ=1 ELSE SET @StationSQ=@StationSQ+1 ;" & _
                              " IF NOT EXISTS( SELECT 1 FROM {1} WHERE PartID='" & Me.CutCardPN & "' AND StationID ='" & StationID & "')" & _
                              "   Begin " & _
                              " INSERT INTO {1}(PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark,Status,UserID,InTime," &
                              " Shape,NewProcessStandard, VariableName1,VariableValue1,VariableName2,VariableValue2, Factoryid,Profitcenter,LCLValue) VALUES(" &
                              "'" & Me.CutCardPN & "','" & StationID & "','" & drawingVer & "',@StationSQ,'" & WorkingHours & "',N'" & Equipment & "',N'" &
                              ProcessStandard & "',N'" & remark & "',1,'" & UserID & "',getdate(),'" & Shape & "',N'0'" &
                              " ,N'" & m_strVarName1 & "'," & m_iVarValue1 & ", '" & m_strVarName2 & "'," & m_iVarValue2 & "," &
                              " '" & factoryID & "','" & profitCenter & "','" & LCLValue & "' )" & _
                              " end "
                    StrSql &= GetInsertCutcardPartSQL(Me.CutCardPN, StationID, Me.drawingVer)

                    If Not String.IsNullOrEmpty(processStandardSql) Then
                        StrSql &= processStandardSql
                    End If
                Case "modify"
                    'StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter() &
                    StrSql = " insert into m_CutCardDOldVerModifyLog_t( [PartID],[StationID],[DrawingVer],[StationSQ],[WorkingHours]" & _
                             " ,[Equipment],[ProcessStandard],[Remark],[Status],[Shape],[NewProcessStandard] " & _
                             " ,[VariableName1],[VariableValue1],[VariableName2],[VariableValue2]" & _
                             " ,[Factoryid],[Profitcenter],[UserID],[InTime],[FinishSize],[ProcessStandardPrint]" & _
                             " ,[LeftProcessStandard],[RightProcessStandard],[LCLValue],[LeftTVPN],[RightTVPN],[backTime],[backUserID])" & _
                            "  select [PartID],[StationID],[DrawingVer],[StationSQ],[WorkingHours]" & _
                             " ,[Equipment],[ProcessStandard],[Remark],[Status],[Shape],[NewProcessStandard] " & _
                             " ,[VariableName1],[VariableValue1],[VariableName2],[VariableValue2]" & _
                             " ,[Factoryid],[Profitcenter],[UserID],[InTime],[FinishSize],[ProcessStandardPrint]" & _
                             " ,[LeftProcessStandard],[RightProcessStandard],[LCLValue],[LeftTVPN],[RightTVPN],getdate(),'" & VbCommClass.VbCommClass.UseId & "'" & _
                             " from m_CutCardDOldVer_t" & _
                            " WHERE PartID='" & Me.CutCardPN & "' AND DrawingVer='" & Me.drawingVer & "' AND StationID='" & Me.stationId & "'" &
                                RCardComBusiness.GetFatoryProfitcenter() & "; "

                    StrSql &= " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.CutCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter() &
                              " UPDATE {1} SET userid='" & UserID & "',intime=getdate()," &
                              " Equipment=N'" & Equipment & "'," & _
                              " ProcessStandard = N'" & ProcessStandard & "'," & _
                              " ProcessStandardPrint = N'" & ProcessStandard & "'," & _
                              " LeftProcessStandard = N'" & LeftProcessStandard & "'," & _
                              " RightProcessStandard = N'" & RightProcessStandard & "'," & _
                              " LCLValue = N'" & LCLValue & "'," & _
                              " remark = N'" & remark &
                              "',stationid='" & StationID & "' ," & _
                              " VariableName1='" & m_strVarName1 & "', VariableValue1='" & m_iVarValue1 & "'," & _
                              " LeftTVPN='" & o_strLeftTVPN & "', RightTVPN='" & o_strRightTVPN & "',wirepn ='" & o_strWirePN & "'" & _
                              " WHERE PartID='" & Me.CutCardPN & "' AND DrawingVer='" & Me.drawingVer & "' AND StationID='" & Me.stationId & "'" &
                                RCardComBusiness.GetFatoryProfitcenter() & "; "

                    StrSql &= GetInsertCutcardPartSQL(Me.CutCardPN, StationID, Me.drawingVer)

                    If m_strOldStationID <> StationID Then
                        StrSql &= GetUpdateCutcardPartSQL(Me.CutCardPN, StationID, m_strOldStationID)
                    End If

                    If m_strOldWirePN.Trim <> o_strWirePN.Trim Then
                        StrSql &= GetUpdateDPartSQL(Me.CutCardPN, o_strWirePN, StationID, Me.drawingVer)
                    End If

                Case Else
                    StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.CutCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter &
                      " UPDATE {1} SET StationSQ=B.ID,userid='" & UserID & "',intime=getdate() FROM {1} A," &
                          " (SELECT ROW_NUMBER() OVER(ORDER BY StationSQ) ID,StationSQ FROM m_RCardCutD_t WHERE PartID='" & Me.CutCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter & ") B" &
                          " WHERE A.PartID='" & Me.CutCardPN & "' AND A.StationSQ=B.StationSQ AND B.ID<>B.StationSQ " & RCardComBusiness.GetFatoryProfitcenter("A")
                    StrSql &= GetInsertCutcardPartSQL(Me.CutCardPN, StationID, Me.drawingVer)
            End Select

            StrSql = String.Format(StrSql, "m_CutCardMOldVer_t", "m_CutCardDOldVer_t")

            StrSql &= vbNewLine & "UPDATE m_CutCardMOldVer_t SET Status=0 WHERE PartID='" & Me.CutCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter

            '触发器保存修改记录
            result = DbOperateUtils.ExecSQL(StrSql)

            If result <> String.Empty Then
                lblMsg.Text = result
                Return False
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "SaveData", "RCard")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 自动从工站基础表里面带出工治具料塞入到表m_CutCardDPart_t
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="stationId"></param>
    ''' <param name="drawingVer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInsertCutcardPartSQL(partId As String, stationId As String, drawingVer As String) As String
        Dim userId As String = VbCommClass.VbCommClass.UseId
        Dim factoyId As String = VbCommClass.VbCommClass.Factory
        Dim proficenter As String = VbCommClass.VbCommClass.profitcenter
        Dim equPartId As String = ""
        Dim tableName As String = ""
        Dim strSQL As String

        strSQL = " declare @PartID as varchar(100)"
        strSQL = strSQL + " select @PartID = ISNULL(PartID,'')  from m_Rstation_t where Stationid  = '{0}' "
        strSQL = String.Format(strSQL, stationId)
        If _isQueryOldVersion = False Then
            tableName = "m_CutCardDPart_t"
        Else
            tableName = "m_CutCardDPartOldVer_t"
        End If

        strSQL = strSQL + " if isnull(@PartID,'') <> '' begin "
        strSQL = strSQL + " delete {0} where PartID='{1}' and Stationid = '{2}' and ewpntype = 'E'" & RCardComBusiness.GetFatoryProfitcenter()
        strSQL = strSQL + " insert into {0}(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
        strSQL = String.Format(strSQL, tableName, partId, stationId)
        strSQL = strSQL + String.Format("'{0}','{1}',@PartID,'{2}','{3}',getdate(),'{4}','{5}','E')  end ",
                                      partId, stationId, drawingVer, userId, factoyId, proficenter)


        Return strSQL
    End Function

    ''' <summary>
    ''' 更新物料表的线材的信息
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="o_strWirePN"></param>
    ''' <param name="StaionID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetUpdateDPartSQL(partId As String, o_strWirePN As String, StaionID As String, ByVal Version As String) As String
        Dim strSQL As String = String.Empty
        strSQL &= " Update m_CutCardDPartOldVer_t SET EWPartNumber ='" & o_strWirePN & "' WHERE PartID='" & partId & "' AND DrawingVer = '" & Version & "' AND (EWPartNumber LIKE '00%' OR EWPartNumber LIKE '01%'  OR  EWPartNumber LIKE '1_____-%' OR  EWPartNumber LIKE '16_-%' ) AND Stationid = '" & StaionID & "' " & RCardComBusiness.GetFatoryProfitcenter()

        Return strSQL
    End Function

    Private Function GetUpdateCutcardPartSQL(partId As String, NewStationId As String, oldStaionID As String) As String
        Dim strSQL As String = String.Empty
        strSQL = " DELETE FROM [MESDB].[dbo].[m_CutCardDPart_t] WHERE PartID ='" & partId & "' AND Stationid ='" & NewStationId & "'" & RCardComBusiness.GetFatoryProfitcenter()
        strSQL &= " Update m_CutCardDPart_t SET stationid ='" & NewStationId & "' where PartID='" & partId & "' and Stationid = '" & oldStaionID & "' " & RCardComBusiness.GetFatoryProfitcenter()

        Return strSQL
    End Function
#End Region

    Private Function CheckStationExists() As Boolean
        Try
            'Modify by cq 20170525,remove the usey
            Dim sql As String = " SELECT Stationid FROM m_Rstation_t " & _
                                " WHERE Stationid='" & Me.txtStationid.Text.Trim().Split(CChar("-"))(0) & "'"
            If DbOperateUtils.GetRowsCount(sql) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "CheckStationExists", "RCard")
            Return False
        End Try
    End Function

    Private Function CheckStationMaintainCheckItem() As Boolean
        Try
            If Not String.IsNullOrEmpty(Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then 'cboStation.SelectedIndex <> -1 Then
                Dim sql As String
                sql = " SELECT CheckItemID FROM m_RstationCheckItem_t WHERE Stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "' AND UseY=1"
                '获取工艺标准”改为都可点击（不含工艺参数时，可能需要点击起来维护变量项）。保留原有的不含工艺参数可手填，含工艺参数不能手填的逻辑。
                If DbOperateUtils.GetRowsCount(sql) > 0 Then
                    ' btnGetProcessStandard.Enabled = True
                    txtProcessStandard.Enabled = True
                    If Action = "add" Then
                        txtProcessStandard.Text = ""
                    End If
                    Return True
                End If
                txtProcessStandard.Enabled = True
                ' btnGetProcessStandard.Enabled = False  ' Mark by CQ 20150925
                Return False
            End If
            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "CheckStationMaintainCheckItem", "RCard")
            Return False
        End Try
    End Function

#End Region

#Region "标准工时"
    Private Sub txtProcessStandard_LostFocus(sender As Object, e As EventArgs) Handles txtProcessStandard.LostFocus
        Try
            If Me.txtProcessStandard.Text <> String.Empty Then
                m_iTotalStdTime = GetStdTime(Me.txtProcessStandard.Text)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "txtProcessStandard_LostFocus", "RCard")
        End Try
    End Sub

    Private Function GetStdTime(ByVal paroutputProcessStand As String) As Integer
        Try
            '是否有维护工时基础资料？
            If Not IsExistStdTimeBase() Then
                GetStdTime = 0
                Return GetStdTime
            Else
                'Exist Std Tiem Base Data?
                '工时资料不含变量项, 则根据成品尺寸范围, 进行计算(如下, 通过判断成品尺寸, 得到总标准工时)
                If Not m_blnExistsVar Then
                    If Val(m_iFinishSize) > 0 Then
                        GetStdTime = GetStdTimeByFinishSize(m_iFinishSize)
                    End If
                Else
                    ' 工时资料含变量项，但未通过“工序修改页面”维护变量项(左端脱皮尺寸、右端脱皮尺寸、变量项1、变量项2)，
                    ' 则为0，并提示：工时计算公式含变量项，请先维护至少一个变量项，才可计算工时。允许其直接手填工时，
                    '或者重新点击“获取工艺标准”维护变量项，（关闭时）再自动计算工时
                    GetStdTime = GetStdTimeWhenExistVar(paroutputProcessStand)
                End If
            End If
            Return GetStdTime
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "GetStdTime", "RCard")
            Return CInt("0")
        End Try
    End Function

    Private Function GetStdTimeByFinishSize(ByVal parFinishSize As Double) As Integer
        Dim lsSQL As String = ""
        Dim o_strWorkHour As String = ""
        Try
            lsSQL = " SELECT TOP 1 WorkHour  FROM DBO.m_RstationWorkHour_t  " & _
                   " WHERE ((FinishSizeMin< " & parFinishSize & " AND  FinishSizeMax>=" & parFinishSize & ") " & _
                  "  OR (FinishSizeMin< " & parFinishSize & " AND (FinishSizeMax IS NULL OR FinishSizeMax='')))" & _
                  "  AND stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "'"

            Dim o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                o_strWorkHour = CStr(o_dt.Rows(0).Item("WorkHour"))  '3+0.4*(L-500)/1000 or 7+0
            Else
                o_strWorkHour = "0" 'Add by cq 20151027
            End If

            If o_strWorkHour.ToUpper.Contains("L") Then
                o_strWorkHour = o_strWorkHour.Replace("L", parFinishSize.ToString)
            End If

            lsSQL = " SELECT  CEILING(" & o_strWorkHour & ")"

            Dim o_dtTotalStdTime As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dtTotalStdTime) AndAlso o_dtTotalStdTime.Rows.Count > 0 Then
                GetStdTimeByFinishSize = CInt(o_dtTotalStdTime.Rows(0).Item(0))  '3+0.4*(L-500)/1000
            End If
            Return GetStdTimeByFinishSize
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetStdTimeByFinishSize", "RCard")
            Return CInt("0")
        End Try
    End Function

    Private Function IsExistStdTimeBase() As Boolean
        Dim lsSQL As String = ""
        Try
            lsSQL = " SELECT TOP 1 ExistVariables  FROM  m_RstationWorkHour_t WHERE stationid ='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "'"
            Dim o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsExistStdTimeBase = True
                m_blnExistsVar = CBool(o_dt.Rows(0).Item("ExistVariables"))
            Else
                IsExistStdTimeBase = False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "IsExistStdTimeBase", "RCard")
            Return False
        End Try
    End Function

    Private Function GetStdTimeWhenExistVar(ByVal paroutputProcessStand As String) As Integer
        Dim o_iLPLSize As Integer = 0, o_iRPLSize As Integer = 0, o_iSingleVarStdTime As Integer = 0
        Try
            '左端脱皮尺寸、右端脱皮尺寸、变量项1、变量项2
            For Each o_str As String In paroutputProcessStand.Split(CChar(";"))
                '裁线尺寸(mm):983±2; 左端脱皮尺寸(mm):10±1; 右端拉拔力(kgf/min):10±1; 右端脱皮尺寸(mm):10±1;
                If o_str.IndexOf("左端脱皮尺寸") >= 0 Then
                    o_iLPLSize = CInt(Val(o_str.Split(CChar(":"))(1)))
                    Continue For
                End If

                If o_str.IndexOf("右端脱皮尺寸") >= 0 Then
                    o_iRPLSize = CInt(Val(o_str.Split(CChar(":"))(1)))
                End If
            Next

            If o_iLPLSize > 0 Then
                GetStdTimeWhenExistVar = GetStdTimeBySingleVar(o_iLPLSize)
            End If

            If o_iRPLSize > 0 Then
                GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(o_iRPLSize)
            End If

            If m_iVarValue1 > 0 Then
                GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(m_iVarValue1)
            End If

            If m_iVarValue2 > 0 Then
                GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(m_iVarValue2)
            End If
            Return GetStdTimeWhenExistVar
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetStdTimeWhenExistVar", "RCard")
            Return CInt("0")
        End Try
    End Function

    Private Function GetStdTimeBySingleVar(ByVal parVarValue As Double) As Integer
        Dim lsSQL As String = ""
        Dim o_strWorkHour As String = ""
        Try
            GetStdTimeBySingleVar = 0

            lsSQL = " SELECT TOP 1 CASE WHEN FinishSizeMax< " & m_iFinishSize & "  THEN WorkHour ELSE StandardHour END  WorkHour  " & _
                    " FROM DBO.m_RstationWorkHour_t  " & _
                    " WHERE ((VariableMin<" & parVarValue & " AND  VariableMax>=" & parVarValue & ") OR (VariableMin< " & parVarValue & " AND (VariableMax IS NULL OR VariableMax=''))) " & _
                    " AND stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "'"

            Dim o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                o_strWorkHour = CStr(o_dt.Rows(0).Item("WorkHour"))  '83+20*(X-1400)/300+0.4*(L-500)/1000 
            Else
                o_strWorkHour = "0"
            End If

            o_strWorkHour = o_strWorkHour.Replace("L", m_iFinishSize.ToString).Replace("X", parVarValue.ToString)
            lsSQL = " SELECT  CEILING(" & o_strWorkHour & ")"

            Dim o_dtSingleStdTime As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dtSingleStdTime) AndAlso o_dtSingleStdTime.Rows.Count > 0 Then
                GetStdTimeBySingleVar = CInt(o_dtSingleStdTime.Rows(0).Item(0))  '3+0.4*(L-500)/1000
            End If
            Return GetStdTimeBySingleVar
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "GetStdTimeBySingleVar", "RCard")
            Return CInt("0")
        End Try
    End Function

#End Region

    Private Sub BtnSelectSta_Click(sender As Object, e As EventArgs) Handles BtnSelectSta.Click

        Dim frmStation As New BasicManagement.FrmRStationSet
        Try
            frmStation.opflag = 3
            frmStation.ShowDialog()
            'cq 20160811
            If frmStation.frmStationtype.Contains("R") = False Then
                Me.lblMsg.Text = "请选择工站类型为R的工站！"
                Exit Sub
            End If
            Me.txtStationid.Text = frmStation.frmRstationid + "-" + frmStation.frmRstationname
            Me.cboStation.Text = frmStation.frmRstationname
            Call GetAndSetEquAndSOP()
            m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_cutCardPn, frmStation.frmRstationid))
            If m_iFinishSize > 0 Then
                '  iiWoringHours.Text = CStr(GetStdTime(""))
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "BtnSelectSta_Click", "RCard")
        Finally
            frmStation = Nothing
        End Try
    End Sub

    Private Sub txtStationid_TextChanged(sender As Object, e As EventArgs) Handles txtStationid.TextChanged
        processStandardSql = Nothing
        Try
            CheckStationMaintainCheckItem()
            If Action = "modify" Then
                ' btnGetProcessStandard.Enabled = False, mark by CQ 20150925
            End If

            ' Call GetAndSetEquAndSOP()

            'm_iFinishSize = CInt(GetFinishSizeByPartID(_runCardPn))
            'If m_iFinishSize > 0 Then
            '    iiWoringHours.Text = CStr(GetStdTime(""))
            'End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyEdit", "txtStationid_TextChanged", "RCard")
        End Try
    End Sub

End Class
