Option Strict On
Option Explicit On
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports BasicManagement.FrmRStationSet
Imports MainFrame

Public Class FrmRunCardBodyEdit

    ''' <summary>
    ''' 工时
    ''' </summary>
    ''' <remarks></remarks>
    Private StaionHour As String = ""
    ''' <summary>
    ''' 工艺标准
    ''' </summary>
    ''' <remarks></remarks>
    Private ProcessStandard As String = ""

    ''' <summary>
    ''' 建立用户ID
    ''' </summary>
    ''' <remarks></remarks>
    Private OldUserID As String = ""

    Private OldMofifyTime As Date

    Public m_blnAllowModifyWorkHour As Boolean

    ''' <summary>
    ''' 备注
    ''' </summary>
    ''' <remarks></remarks>
    Private Remark As String = ""

    Private _RCardType As String = "R"
    Public Property RCardType() As String
        Get
            Return _RCardType
        End Get
        Set(ByVal value As String)
            _RCardType = value
        End Set
    End Property


#Region "构造函数"
    Sub New(ByVal runCardPn As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As Boolean)
        Try
            ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent()

            '在 InitializeComponent() 调用之后添加任何初始化。
            'Me._runCardID = runCardPartId
            Me._runCardPn = runCardPn
            Me._gridViewRow = dataGridViewRow
            Me._action = action
            Me._isQueryOldVersion = isQueryOldVersion

            If _gridViewRow IsNot Nothing Then
                stationId = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
                stationName = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString

                StaionHour = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString()).Value.ToString

                ProcessStandard = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString()).Value.ToString()

                OldUserID = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.Uid.ToString).Value.ToString

                OldMofifyTime = Convert.ToDateTime(dataGridViewRow.Cells(RunCardBusiness.BodyGrid.InTime.ToString).Value)

                Remark = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.Remark.ToString).Value.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "New01", "RCard")
        End Try
    End Sub

    ' ''' <summary>
    ' ''' add by 马跃平 2018-06-04
    ' ''' </summary>
    ' ''' <param name="action"></param>
    ' ''' <param name="dataGridViewRow"></param>
    ' ''' <param name="isQueryOldVersion"></param>
    ' ''' <remarks></remarks>
    'Sub New(ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As Boolean)

    '    ' 此调用是设计器所必需的。
    '    InitializeComponent()

    '    ' 在 InitializeComponent() 调用之后添加任何初始化。
    '    'Me._gridViewRow = dataGridViewRow
    '    Me._action = action
    '    Me._isQueryOldVersion = isQueryOldVersion
    '    If dataGridViewRow IsNot Nothing And action <> "insert" Then
    '        Me._runCardPn = dataGridViewRow.Cells("BodyPartID").Value.ToString()
    '        stationId = dataGridViewRow.Cells("StationID").Value.ToString
    '        stationName = dataGridViewRow.Cells("StationName").Value.ToString
    '        iiStationSQ.Text = dataGridViewRow.Cells("StationSQ").Value.ToString()
    '        StaionHour = dataGridViewRow.Cells("WorkingHours").Value.ToString
    '        iiWoringHours.Text = StaionHour
    '        ProcessStandard = dataGridViewRow.Cells("ProcessStandard").Value.ToString()
    '        txtProcessStandard.Text = ProcessStandard
    '        OldUserID = dataGridViewRow.Cells("Uid").Value.ToString
    '        OldMofifyTime = Convert.ToDateTime(dataGridViewRow.Cells("BodyInTime").Value)
    '        txtStationid.Text = stationId
    '        Remark = dataGridViewRow.Cells("BodyRemark").Value.ToString
    '        txtRemark.Text = Remark
    '        txtEquipment.Text = dataGridViewRow.Cells("Equipment").Value.ToString()
    '        txtSopFilePath.Text = dataGridViewRow.Cells("SOP").Value.ToString()
    '        txtStationid.Text = stationId + "-" + stationName
    '    Else
    '        iiStationSQ.Text = dataGridViewRow.Cells("StationSQ").Value.ToString()
    '        Me.stationSeq = iiStationSQ.Text
    '        m_strOldStationID = dataGridViewRow.Cells("StationID").Value.ToString
    '    End If
    'End Sub

    Private frm As FrmRunCard
    Sub New(ByVal runCardPn As String, ByVal action As String, _
            ByVal dataGridViewRow As DataGridViewRow, ByVal form As FrmRunCard, _
            drawingVer As String, ByVal isQueryOldVersion As Boolean, Optional ByVal iMaxStationSQ As Integer = -1)
        Try
            ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent()

            '在 InitializeComponent() 调用之后添加任何初始化。
            'Me._runCardID = runCardPartId
            Me._runCardPn = runCardPn
            Me._gridViewRow = dataGridViewRow
            If _gridViewRow IsNot Nothing Then
                If iMaxStationSQ > 0 Then
                    Me.stationSeq = CStr(iMaxStationSQ)
                Else
                    Me.stationSeq = dataGridViewRow.Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value.ToString
                End If
            End If
            Me._action = action
            Me.drawingVer = drawingVer
            frm = form
            Me._isQueryOldVersion = isQueryOldVersion
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "New02", "RCard")
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
    Private m_ProductTypeID As String = ""

#Region "RunCardID"
    Private _runCardPn As String
    Public Property RunCardPN() As String
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

#Region "FrmRunCardEdit_Load"
    Private Sub FrmRunCardEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            lblMsg.Text = ""
            Me.txtPartNumber.Text = Me.RunCardPN
            Select Case Action
                Case "add", "insert"
                    '绑定工站
                    FillCombox(Me.cboStation)
                    If Action = "insert" Then
                        Me.iiStationSQ.Text = Me.stationSeq
                    End If
                    Me.iiStationSQ.Enabled = False
                    Me.txtSopFilePath.Enabled = False
                    Me.txtSopFilePath.ReadOnly = True
                    txtRemark.Enabled = True
                    'Me.cboStation.SelectedIndex = -1
                Case "modify"
                    '绑定工站
                    FillCombox(Me.cboStation)
                    IniteControls()
                    If CheckStationMaintainCheckItem() Then
                        txtProcessStandard.Enabled = False
                    End If
                    txtSopFilePath.Enabled = False
                    ' cboStation.Enabled = False
                    txtEquipment.Enabled = False
                    txtRemark.Enabled = True
                    If stationId IsNot Nothing Then
                        cboStation.SelectedValue = stationId + "-" + Me.stationName
                        cboStation.Text = stationName
                        bingComProductType(stationId)
                        Dim sql As String = "select ProductTypeID from m_RCardD_t where PartID='" + txtPartNumber.Text + "'and StationID='" + stationId + "'"
                        Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            m_ProductTypeID = dt.Rows(0)(0).ToString()
                        End If
                        ' CmbProductType.SelectedValue = ProductTypeID
                        If Not String.IsNullOrEmpty(m_ProductTypeID) Then
                            CmbProductType.SelectedValue = m_ProductTypeID  'SelectedValue
                        Else
                            CmbProductType.Text = String.Empty
                        End If
                    End If

                    Me.txtStationid.Text = stationId + "-" + stationName
                    m_strOldStationID = stationId

                    'add by cq 20180622
                    If m_blnAllowModifyWorkHour = True Then
                        Me.iiWoringHours.Enabled = True
                    Else
                        Me.iiWoringHours.Enabled = False
                    End If

                Case Else
                    txtPartNumber.Enabled = False
                    ' cboStation.Enabled = False
                    txtProcessStandard.Enabled = False
                    iiWoringHours.Enabled = False
                    txtEquipment.Enabled = False
                    txtSopFilePath.Enabled = False
                    txtRemark.Enabled = False
                    iiStationSQ.Enabled = True
                    IniteControls()
                    m_strOldStationID = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)  'CQ 20151103
                    If Action = "reset" Then
                        If RCardType = "H" Then
                            cboStation.Items.Clear()
                            Me.txtStationid.Text = ""
                            Using dt As New DataTable
                                dt.Columns.Add("StaionID", GetType(String))
                                dt.Columns.Add("StationName", GetType(String))
                                dt.Rows.Add(
                                    stationId + "-" + stationName,
                                   stationName)
                                cboStation.DataSource = dt.DefaultView
                                cboStation.DisplayMember = "StationName"
                                cboStation.ValueMember = "StaionID"
                                Me.txtStationid.Text = stationId + "-" + stationName
                            End Using
                        End If

                        Me.BtnSelectSta.Enabled = False
                        Me.iiStationSQ.Focus()
                        Me.iiStationSQ.Select()
                    End If
            End Select

            Me.Top = CInt(Screen.PrimaryScreen.WorkingArea.Height * 0.15)
            ' cboStation.Select()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "FrmRunCardEdit_Load", "RCard")
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
                    frm.BindBodyWhenAdd(_runCardPn)
                    Me.txtStationid.Text = ""
                    Me.txtProcessStandard.Text = ""
                    Me.iiWoringHours.Text = ""
                    Me.txtEquipment.Text = ""
                    Me.txtSopFilePath.Text = ""
                    Me.txtRemark.Text = ""
                    Me.txtStationid.Focus()
                    cboStation.SelectedIndex = -1
                    ' CmbProductType.SelectedIndex = -1
                    Me.CmbProductType.Text = String.Empty
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
                'Me.DialogResult = Windows.Forms.DialogResult.OK
                'Me.Close()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "获取标准工艺"
    Private Sub btnGetProcessStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProcessStandard.Click
        Try
            If String.IsNullOrEmpty(Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then
                MessageBox.Show("请先选择工站！")
                Exit Sub
            End If

            'cboStation.SelectedValue.ToString
            Using frm As New FrmRunCardBodyModify(RunCardPN, FrmRunCardBodyModify.ActionType.GetProcessParameter, Me.txtStationid.Text.Trim.Split(CChar("-"))(0), False)
                frm.ShowDialog()
                processStandardSql = frm.outputSql
                txtProcessStandard.Text = frm.outputProcessStand
                m_iFinishSize = CInt(Val(GetFinishSizeByPartID(RunCardPN)))  'CInt(Val(frm.txtFinishSize.Text))
                m_strVarName1 = frm.txtVarName1.Text : m_strVarName2 = frm.txtVarName2.Text
                m_iVarValue1 = CInt(Val(frm.txtValue1.Text)) : m_iVarValue2 = CInt(Val(frm.txtValue2.Text))
                Me.txtProcessStandard.Focus() 'Add by CQ 20150925

                If Me.txtProcessStandard.Text <> String.Empty OrElse m_iFinishSize > 0 Then
                    Me.txtSuggestTime.Text = GetStdTime(Me.txtProcessStandard.Text).ToString 'iiWoringHours
                    Me.iiWoringHours.Focus()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("获取标准工艺失败")
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "btnGetProcessStandard_Click", "RCard")
        Finally

        End Try
    End Sub

    Private Function GetFinishSizeByPartID(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetFinishSizeByPartID = ""
        lsSQL = "SELECT  ISNULL(FinishSize,0) FinishSize  FROM m_RCardM_t WHERE PartID='" & parPartID & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetFinishSizeByPartID = CStr(dt.Rows(0).Item("FinishSize"))
            End If
        End Using
        Return GetFinishSizeByPartID
    End Function


#End Region

#Region "上传SOP"
    'Private Sub btnSopUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSopUpload.Click
    '    btnSopUpload.Enabled = False
    '    Me.SopFileName = ""
    '    'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
    '    Dim result As DialogResult = OpenFileDialog1.ShowDialog()
    '    If result = System.Windows.Forms.DialogResult.OK Then
    '        Cursor.Current = Cursors.WaitCursor
    '        txtSopFilePath.Text = OpenFileDialog1.FileName
    '        Me.SopFileName = OpenFileDialog1.SafeFileName
    '        Cursor.Current = Cursors.Default
    '    End If
    '    btnSopUpload.Enabled = True
    'End Sub
#End Region

#Region "Enter Event"

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

    'Private Sub txtRemark_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyUp
    '    TextBox1.Text = ""
    'End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim o_stdTime As String = ""
        Try

            'If Me.cboStation.SelectedValue.ToString = "System.Data.DataRowView" Then
            '    Me.txtStationid.Text = Me.stationId + "-" + Me.stationName
            '    Exit Sub
            'End If

            'cq 20161213
            If IsNothing(Me.cboStation.SelectedValue) Then
                Exit Sub
            Else
                If Me.cboStation.SelectedValue.ToString = "System.Data.DataRowView" Then
                    ' Me.txtStationid.Text = Me.stationId + "-" + Me.stationName
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

            m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_runCardPn, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)))
            If m_iFinishSize > 0 Then
                '  iiWoringHours.Text = CStr(GetStdTime(""))
                o_stdTime = CStr(GetStdTime(""))
                If Val(o_stdTime) > 0 Then
                    iiWoringHours.Text = o_stdTime
                Else
                    'do nothing
                End If
            End If
            Dim sValue As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)
            bingComProductType(sValue)
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "cboStation_SelectedIndexChanged", "RCard")
        End Try
    End Sub

    ''' <summary>
    ''' 绑定产品类型
    ''' </summary>
    ''' <param name="resultValue">工站站点</param>
    ''' <remarks></remarks>
    Private Sub bingComProductType(ByVal resultValue As String)

        Dim sql As New StringBuilder
        sql.Append("select ProductTypeID, ProductType from (select distinct A.Stationid, A.ProductTypeID,b.ProductType  ")
        sql.Append(" from m_RstationWorkHour_t A left join ProductType_t b on b.ProductTypeID=a.ProductTypeID ")
        sql.Append(" where a.Stationid='" + resultValue + "' and isnull(a.ProductTypeID,'')<>'') t")
        sql.Append("   union ")
        sql.Append(" select D.ProductTypeID, b.ProductType  from m_RCardD_t D ")
        sql.Append("   left join ProductType_t b on b.ProductTypeID=D.ProductTypeID")
        sql.Append(" where D.PartID='" + txtPartNumber.Text + "'and D.StationID='" + stationId + "'")

        Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql.ToString)
        If dt.Rows.Count = 0 Then
            CmbProductType.Text = ""
        End If
        CmbProductType.DataSource = dt
        CmbProductType.DisplayMember = "ProductType"
        CmbProductType.ValueMember = "ProductTypeID"
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetAndSetEquAndSOP", "RCard")
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

#Region "初始化控件"
    Private Sub IniteControls()
        Try
            If Not Me.SelectedGridViewRow Is Nothing Then
                'Me.lblId.Text = _gridViewRow.Cells(BodyGrid.).Value.ToString
                Me.txtEquipment.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.Equipment.ToString).Value.ToString
                Me.txtProcessStandard.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.ProcessStandard.ToString).Value.ToString
                Me.txtSopFilePath.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.SOP.ToString).Value.ToString
                Me.iiStationSQ.Value = CInt(_gridViewRow.Cells(RunCardBusiness.BodyGrid.StationSQ.ToString).Value.ToString)
                Me.stationSeq = CStr(Me.iiStationSQ.Value)
                Me.iiWoringHours.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.WorkingHours.ToString).Value.ToString
                Me.txtRemark.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.Remark.ToString).Value.ToString
                If Action = "reset" Then
                    cboStation.Items.Clear()
                    Me.txtStationid.Text = ""
                    Using dt As New DataTable
                        dt.Columns.Add("StaionID", GetType(String))
                        dt.Columns.Add("StationName", GetType(String))
                        dt.Rows.Add(
                            _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString + "-" + _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString,
                            _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString)
                        cboStation.DataSource = dt.DefaultView
                        cboStation.DisplayMember = "StationName"
                        cboStation.ValueMember = "StaionID"
                        Me.txtStationid.Text = _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString + "-" + _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString
                    End Using
                    Me.BtnSelectSta.Enabled = False
                    Me.iiStationSQ.Focus()
                    Me.iiStationSQ.Select()
                End If
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
                'ColComboBox.Items.Clear()
                Select Case Action
                    Case "add", "insert"
                        lsSQL = " SELECT stationid + '-' + StationName as Stationid, (StationName + IIf(isnull(cabletype,'')='','', '-' + CableType))  StationName FROM m_Rstation_t(nolock)" & _
                                " WHERE  stationtype='" & Me.RCardType & "' AND usey='Y' ORDER BY STATIONNAME"
                        UserDg = DbOperateUtils.GetDataTable(lsSQL)
                        cboStation.DataSource = UserDg.DefaultView
                        cboStation.DisplayMember = "StationName"
                        cboStation.ValueMember = "Stationid"
                        cboStation.SelectedIndex = -1
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
                               " WHERE  stationtype ='" & Me.RCardType & "' and usey='Y' ORDER BY STATIONNAME "
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
            '工时
            If Not String.IsNullOrEmpty(iiWoringHours.Text) Then
                If Not reg.IsMatch(iiWoringHours.Text) Then
                    lblMsg.Text = """工时""不正确"
                    iiWoringHours.Select()
                    iiWoringHours.SelectAll()
                    Return False
                End If
            End If
            '工序
            If Me.iiStationSQ.Value <= 0 Then
                lblMsg.Text = """工序""不能小于1"
                iiStationSQ.Select()
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
                If StationExists(Me.RunCardPN, row.Item(0).ToString.Trim().Split(CChar("-"))(0)) Then 'StationExists(Me.RunCardPN, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)) Then
                    If Not String.IsNullOrEmpty(m_strOldStationID) AndAlso m_strOldStationID = row.Item(0).ToString.Trim().Split(CChar("-"))(0) Then
                        'pass
                    Else
                        '2018-06-25 何建邦提出不卡工站
                        'lblMsg.Text = "工站" & row.Item(0).ToString.Trim().Split(CChar("-"))(1) & "已存在,请勿重复"
                        'cboStation.Select()
                        'cboStation.SelectAll()
                        'TextBox1.Text = "1"
                        'Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "CheckInput", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "检查工站是否存在"
    Private Function StationExists(ByVal runCardPartId As String, ByVal stationId As String) As Boolean
        Dim StrSql As String = Nothing
        Try
            If _isQueryOldVersion = False Then
                StrSql = "SELECT 1 FROM m_RCardD_t(NOLOCK) WHERE PartID='" & runCardPartId & "' AND StationID='" & stationId & "' "
            Else
                StrSql = "SELECT 1 FROM m_RCardDOldVer_t(NOLOCK) WHERE PartID='" & runCardPartId & "' AND StationID='" & stationId & "' "
            End If
            Using dt As DataTable = DbOperateUtils.GetDataTable(StrSql)
                If dt.Rows.Count > 0 Then Return True
            End Using
            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "StationExists", "RCard")
            Return False
        End Try
    End Function
#End Region

#Region "保存"
    Public Function SaveData() As Boolean
        Try
            ' row = CType(cboStation.SelectedItem, DataRowView)
            Dim StrSql As String = String.Empty
            Dim StationID As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)  'row.Item(0).ToString
            Me.stationId = StationID
            Dim StationName As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(1) 'row.Item(1).ToString
            StationName = StationName.Replace("/", "").Replace("\", "").Replace(Chr(10), "").Replace(Chr(13), "").Trim
            Dim StationSQ As Integer = CInt(Me.iiStationSQ.Value.ToString())
            Dim WorkingHours As Double = Val(Me.iiWoringHours.Text) 'CDbl(Me.iiWoringHours.Text.ToString())
            Dim Equipment As String = Me.txtEquipment.Text.Trim
            Dim ProcessStandard As String = Me.txtProcessStandard.Text.Trim
            Dim NewProcessStandard As String = ProcessStandard
            Dim remark As String = Me.txtRemark.Text.Trim
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim Shape As String = String.Empty
            Dim factoryID As String = VbCommClass.VbCommClass.Factory
            Dim profitCenter As String = VbCommClass.VbCommClass.profitcenter
            Dim result As String = String.Empty
            Dim iInsertStationSQ As Integer = -1
            Dim ProductType As String = ""
            If CmbProductType.Items.Count > 0 Then
                ProductType = CmbProductType.SelectedValue.ToString()
            End If
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
                    StrSql = " DECLARE @StationSQ INT;UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter() &
                              " SELECT @StationSQ=MAX(StationSQ) FROM {1}(nolock) where PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter() &
                              " IF @StationSQ IS NULL SET @StationSQ=1 ELSE SET @StationSQ=@StationSQ+1 ;" &
                              " INSERT INTO {1}(PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark,Status,UserID,InTime," &
                              " Shape,NewProcessStandard, VariableName1,VariableValue1,VariableName2,VariableValue2, Factoryid,Profitcenter,ProductTypeID) VALUES(" &
                              "'" & Me.RunCardPN & "','" & StationID & "','" & drawingVer & "',@StationSQ,'" & WorkingHours & "',N'" & Equipment & "',N'" &
                              ProcessStandard & "',N'" & remark & "',1,'" & UserID & "',getdate(),'" & Shape & "',N'" & NewProcessStandard & "'" &
                              " ,N'" & m_strVarName1 & "'," & m_iVarValue1 & ", '" & m_strVarName2 & "'," & m_iVarValue2 & "," &
                              " '" & factoryID & "','" & profitCenter & "' ,'" + ProductType + "')"
                    StrSql &= GetInsertRcardPartSQL(Me.RunCardPN, StationID, Me.drawingVer)

                    If Not String.IsNullOrEmpty(processStandardSql) Then
                        StrSql &= processStandardSql
                    End If

                    StrSql &= " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter

                Case "insert"
                    If Val(Me.stationSeq) <= 0 Then
                        Me.stationSeq = CStr(Val(Me.stationSeq) + 1)
                    End If
                    Me.iiStationSQ.Text = CStr(Val(Me.stationSeq))  'cq20160627
                    '123 ==> 1 a, 2+1,3+1
                    StrSql =
                    "UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter() & _
                    " UPDATE {1} SET StationSQ=StationSQ+1 WHERE PartID='" & Me.RunCardPN & "' AND STATIONSQ >= " & Val(Me.stationSeq) & "" & RCardComBusiness.GetFatoryProfitcenter() & _
                    " INSERT INTO {1}(PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark,Status,UserID,InTime," &
                    " Shape,NewProcessStandard, VariableName1,VariableValue1,VariableName2,VariableValue2, Factoryid,Profitcenter) VALUES(" &
                    "'" & Me.RunCardPN & "','" & StationID & "','" & drawingVer & "'," & Val(Me.stationSeq) & ",'" & WorkingHours & "',N'" & Equipment & "',N'" &
                    ProcessStandard & "',N'" & remark & "',1,'" & UserID & "',getdate(),'" & Shape & "',N'" & NewProcessStandard & "'" &
                    " ,N'" & m_strVarName1 & "'," & m_iVarValue1 & ", '" & m_strVarName2 & "'," & m_iVarValue2 & "," &
                    " '" & factoryID & "','" & profitCenter & "' ) "
                    StrSql &= GetInsertRcardPartSQL(Me.RunCardPN, StationID, Me.drawingVer)

                    If Not String.IsNullOrEmpty(processStandardSql) Then
                        StrSql &= processStandardSql
                    End If
                Case "modify"
                    'StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter() &
                    '           " UPDATE {1} SET StationSQ=" & StationSQ & ",WorkingHours=" & WorkingHours & ",userid='" & UserID & "',intime=getdate()," &
                    '           " Equipment=N'" & Equipment & "',ProcessStandard=N'" & ProcessStandard & "',remark=N'" & remark &
                    '           "',stationid='" & StationID & "' ," & _
                    '           " VariableName1='" & m_strVarName1 & "', VariableValue1='" & m_iVarValue1 & "'," & _
                    '           " VariableName2='" & m_strVarName2 & "', VariableValue2='" & m_iVarValue2 & "'" & _
                    '           " WHERE PartID='" & Me.RunCardPN & "' AND StationID='" & Me.stationId & "'" &
                    '             RCardComBusiness.GetFatoryProfitcenter() & "; "
                    'cq 20170413
                    StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter() &
                              " UPDATE {1} SET  WorkingHours=" & WorkingHours & ",userid='" & UserID & "',intime=getdate()," &
                              " Equipment=N'" & Equipment & "'," & _
                              " ProcessStandard = N'" & ProcessStandard & "'," & _
                              " ProcessStandardPrint = N'" & ProcessStandard & "'," & _
                              " remark = N'" & remark &
                              "',stationid='" & StationID & "' ," & _
                              " VariableName1='" & m_strVarName1 & "', VariableValue1='" & m_iVarValue1 & "'," & _
                              " VariableName2='" & m_strVarName2 & "', VariableValue2='" & m_iVarValue2 & "',ProductTypeID='" + ProductType + "'" & _
                              " WHERE PartID='" & Me.RunCardPN & "' AND StationID='" & Me.stationId & "' and StationSQ='" & Me.stationSeq & "'" &
                                RCardComBusiness.GetFatoryProfitcenter() & "; "
                    StrSql &= GetInsertRcardPartSQL(Me.RunCardPN, StationID, Me.drawingVer)

                    '工时变更 add by 马跃平 2018-05-14
                    If String.Compare(Me.StaionHour.Trim, iiWoringHours.Text.Trim) <> 0 Then
                        StrSql = StrSql & vbCrLf & " insert into m_RCardChangeLog_t" & vbCrLf &
                            "(PartID,StationID,TYPE,OldUserID,OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & vbCrLf &
" values ('" & Me.RunCardPN & "','" & Me.stationId & "',N'工时','" & Me.OldUserID & "'" & vbCrLf &
",'" & OldMofifyTime & "','" & Me.StaionHour & "','" & SysMessageClass.UseId & "',getdate(),'" & iiWoringHours.Text.Trim & "')"
                    End If

                    '变更工艺标准 add by 马跃平 2018-05-14
                    If String.Compare(txtProcessStandard.Text.Trim, Me.ProcessStandard.Trim) <> 0 Then
                        StrSql = StrSql & vbCrLf & " insert into m_RCardChangeLog_t" & vbCrLf &
                                                    "(PartID,StationID,TYPE,OldUserID,OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & vbCrLf &
                        " values ('" & Me.RunCardPN & "','" & Me.stationId & "',N'工艺标准','" & Me.OldUserID & "'" & vbCrLf &
                        ",'" & OldMofifyTime & "',N'" & Me.ProcessStandard & "','" & SysMessageClass.UseId & "',getdate(),N'" & txtProcessStandard.Text.Trim & "')"
                    End If


                    '变更备注 add by 马跃平 2018-05-14
                    If String.Compare(Me.Remark.Trim(), txtRemark.Text.Trim) <> 0 Then
                        StrSql = StrSql & vbCrLf & " insert into m_RCardChangeLog_t" & vbCrLf &
                                                   "(PartID,StationID,TYPE,OldUserID,OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & vbCrLf &
                       " values ('" & Me.RunCardPN & "','" & Me.stationId & "',N'备注','" & Me.OldUserID & "'" & vbCrLf &
                       ",'" & OldMofifyTime & "',N'" & Me.Remark.Trim & "','" & SysMessageClass.UseId & "',getdate(),N'" & txtRemark.Text.Trim & "')"
                    End If

                Case Else
                    'StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter &
                    '      " UPDATE {1} SET StationSQ=StationSQ+1 WHERE PartID='" & Me.RunCardPN & "' AND StationSQ>=" & iiStationSQ.Value & RCardComBusiness.GetFatoryProfitcenter &
                    '      " UPDATE {1} SET StationSQ=" & iiStationSQ.Value & " WHERE PartID='" & Me.RunCardPN & "' AND StationID='" & Me.stationId & "' and StationSQ=" & Me.stationSeq & " " & RCardComBusiness.GetFatoryProfitcenter &
                    '      " UPDATE {1} SET StationSQ=B.ID,userid='" & UserID & "',intime=getdate() FROM {1} A," &
                    '      " (SELECT ROW_NUMBER() OVER(ORDER BY StationSQ) ID,StationSQ FROM m_RCardD_t WHERE PartID='" & Me.RunCardPN & "' " & RCardComBusiness.GetFatoryProfitcenter & ") B" &
                    '      " WHERE A.PartID='" & Me.RunCardPN & "' AND A.StationSQ=B.StationSQ AND B.ID<>B.StationSQ " & RCardComBusiness.GetFatoryProfitcenter("A")
                    'StrSql &= GetInsertRcardPartSQL(Me.RunCardPN, StationID, Me.drawingVer)

                    '----------------流程卡重置工站 add by马跃平 2018-08-07
                    StrSql = " UPDATE {0} SET ModifyTime=GETDATE() WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter
                    StrSql &= String.Format(" exec Proc_ModifyBRCardOrderBy '{0}',{1},'{2}',{3},'{4}','{5}'", Me.RunCardPN, Me.stationSeq, "reset", iiStationSQ.Value, Me.stationId, UserID)
                    StrSql &= GetInsertRcardPartSQL(Me.RunCardPN, StationID, Me.drawingVer)
                    '------------------------------------------------------
            End Select
            If _isQueryOldVersion = False Then
                StrSql = String.Format(StrSql, "m_RCardM_t", "m_RCardD_t")
            Else
                StrSql = String.Format(StrSql, "m_RCardMOldVer_t", "m_RCardDOldVer_t")
            End If

            '触发器保存修改记录
            If _isQueryOldVersion = False Then
                result = DbOperateUtils.ExecSQL(StrSql & vbNewLine & "UPDATE m_RCardM_t SET Status=0 WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter)
            Else
                result = DbOperateUtils.ExecSQL(StrSql & vbNewLine & "UPDATE m_RCardMOldVer_t SET Status=0 WHERE PartID='" & Me.RunCardPN & "'" & RCardComBusiness.GetFatoryProfitcenter)
            End If
            If result <> String.Empty Then
                lblMsg.Text = result
                Return False
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "SaveData", "RCard")
            Return False
        End Try
    End Function

    Private Function GetInsertRcardPartSQL(partId As String, stationId As String, drawingVer As String) As String
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
            tableName = "m_RCardDPart_t"
        Else
            tableName = "m_RCardDPartOldVer_t"
        End If

        strSQL = strSQL + " if isnull(@PartID,'') <> '' begin "
        strSQL = strSQL + " delete {0} where PartID='{1}' and Stationid = '{2}' and ewpntype = 'E'" & RCardComBusiness.GetFatoryProfitcenter()
        strSQL = strSQL + " insert into {0}(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
        strSQL = String.Format(strSQL, tableName, partId, stationId)
        strSQL = strSQL + String.Format("'{0}','{1}',@PartID,'{2}','{3}',getdate(),'{4}','{5}','E')  end ",
                                      partId, stationId, drawingVer, userId, factoyId, proficenter)


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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "CheckStationExists", "RCard")
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
                    btnGetProcessStandard.Enabled = True
                    txtProcessStandard.Enabled = False
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "CheckStationMaintainCheckItem", "RCard")
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetStdTime", "RCard")
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

    ''' <summary>
    ''' 根据产品类型和成品尺寸
    ''' </summary>
    ''' <param name="parFinishSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStdTimeBySizeAndType(ByVal parFinishSize As Double, ByVal parPrdouctType As String) As Integer
        Dim lsSQL As String = ""
        Dim o_strWorkHour As String = ""
        Try

            lsSQL = " SELECT TOP 1 IIF( " & parFinishSize & " > FinishSizeMax,WorkHour, StandardHour) as WorkHour  FROM DBO.m_RstationWorkHour_t  " & _
                    " WHERE 1=1 " & _
                    " AND stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "' and ProductTypeID='" + parPrdouctType + "'"

            'lsSQL = " SELECT TOP 1 WorkHour  FROM DBO.m_RstationWorkHour_t  " & _
            '       " WHERE ((FinishSizeMin< " & parFinishSize & " AND  FinishSizeMax>=" & parFinishSize & ") " & _
            '      "  OR (FinishSizeMin< " & parFinishSize & " AND (FinishSizeMax IS NULL OR FinishSizeMax='')))" & _
            '      "  AND stationid='" & Me.txtStationid.Text.Trim.Split(CChar("-"))(0) & "' and ProductTypeID='" + parPrdouctType + "'"

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
                GetStdTimeBySizeAndType = CInt(o_dtTotalStdTime.Rows(0).Item(0))  '3+0.4*(L-500)/1000
            End If
            Return GetStdTimeBySizeAndType
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetStdTimeBySizeAndType", "RCard")
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "GetStdTimeBySingleVar", "RCard")
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
                'Me.lblMsg.Text = "请选择工站类型为R的工站！"
                'Exit Sub
            End If
            Me.txtStationid.Text = frmStation.frmRstationid + "-" + frmStation.frmRstationname
            Me.cboStation.Text = frmStation.frmRstationname
            Call GetAndSetEquAndSOP()
            m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_runCardPn, frmStation.frmRstationid))
            If m_iFinishSize > 0 Then
                txtSuggestTime.Text = CStr(GetStdTimeBySizeAndType(m_iFinishSize, m_ProductTypeID)) 'iiWoringHours
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "BtnSelectSta_Click", "RCard")
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "txtStationid_TextChanged", "RCard")
        End Try
    End Sub


    Private Sub CmbProductType_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProductType.SelectedValueChanged
        'iiWoringHours.Text = "0"
        Dim o_stdTime As String = ""
        Dim stationID As String = Me.txtStationid.Text.Split(CChar("-"))(0)
        If CmbProductType.Items.Count > 0 Then
            m_ProductTypeID = CmbProductType.SelectedValue.ToString
        End If

        'Dim sql As String = "select StandardHour  from m_RstationWorkHour_t"
        'sql += " where stationID='" + stationID + "' and ProductTypeID='" + ProductTypeID + "'"
        'Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)

        m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_runCardPn, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)))
        o_stdTime = CStr(GetStdTimeBySizeAndType(m_iFinishSize, m_ProductTypeID))
        If Val(o_stdTime) > 0 Then
            txtSuggestTime.Text = o_stdTime 'iiWoringHours
        Else
            'do nothing
            txtSuggestTime.Text = "0"
        End If

        'If dt.Rows.Count > 0 Then
        '    txtSuggestTime.Text = dt.Rows(0)(0).ToString()
        'End If
    End Sub

    Private Sub cboStation_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedValueChanged
        Dim o_stdTime As String = ""
        Try

            'If Me.cboStation.SelectedValue.ToString = "System.Data.DataRowView" Then
            '    Me.txtStationid.Text = Me.stationId + "-" + Me.stationName
            '    Exit Sub
            'End If

            'cq 20161213
            If IsNothing(Me.cboStation.SelectedValue) Then
                Exit Sub
            Else
                If Me.cboStation.SelectedValue.ToString = "System.Data.DataRowView" Then
                    ' Me.txtStationid.Text = Me.stationId + "-" + Me.stationName
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

            m_iFinishSize = CInt(RunCardBusiness.GetFinishSizeByPartID(_runCardPn, Me.txtStationid.Text.Trim.Split(CChar("-"))(0)))
            If m_iFinishSize > 0 Then
                '  iiWoringHours.Text = CStr(GetStdTime(""))
                o_stdTime = CStr(GetStdTimeBySizeAndType(m_iFinishSize, m_ProductTypeID))
                If Val(o_stdTime) > 0 Then
                    txtSuggestTime.Text = o_stdTime 'iiWoringHours
                Else
                    'do nothing
                End If
            End If
            Dim sValue As String = Me.txtStationid.Text.Trim.Split(CChar("-"))(0)
            bingComProductType(sValue)
        Catch ex As Exception
            'Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyEdit", "cboStation_SelectedIndexChanged", "RCard")
        End Try
    End Sub
End Class
