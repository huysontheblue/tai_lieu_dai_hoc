Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports SysBasicClass

Public Class FrmCutCardBodyModify

    Public outputStationName As String = Nothing
    Public outputStationId As String = Nothing
    Public outputProcessStand As String = Nothing
    Public outputLeftProcessStand As String = String.Empty
    Public outputRightProcessStand As String = String.Empty  'cq20171020
    Public outputLCLValue As String = String.Empty  'cq20171020
    Public m_iTotalStdTime As Integer = 0
    Public outputSql As String = Nothing
    Private m_strToleranceRange As String = ""
    Private isFormLoad As Boolean = True
    Private m_blnChangeTV As Boolean = False
    Private m_blnChangeWire As Boolean = False
    Private _stationId As String = ""
    Private _stationName As String = ""
    Private _cutCardPn As String = ""
    Private _cutCardVersion As String =""
    Dim row As System.Data.DataRowView
    Dim leftFrontSize As String = Nothing
    Dim rightFrontSize As String = Nothing
    Private m_strLeftEquPN As String = String.Empty
    Private m_strRightEquPN As String = String.Empty
    Private m_strLeftDM As String = "", m_strRightDM As String = String.Empty
    Private factoryID As String = VbCommClass.VbCommClass.Factory
    Private profitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private m_strCardType As String = "C"  '裁线卡， cq20170831
    Private UserId As String = VbCommClass.VbCommClass.UseId
    Private m_blnExistsVar As Boolean = False
    Private m_blnExistLeftCut As Boolean = False, m_blnExistRightCut As Boolean = False

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal runcardpn As String, ByVal action As ActionType, _
                   ByVal input As DataGridViewRow, ByVal isQueryOldVersion As Boolean, _
                   ByVal cutcardVersion As String
                   )

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        MAction = action
        _cutCardPn = runcardpn
        _stationId = input.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString
        _stationName = input.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString
        Me.IsQueryOldVersion = isQueryOldVersion
        _cutCardVersion = cutcardVersion
    End Sub

    Public Sub New(ByVal cutcardpn As String, ByVal action As ActionType, ByVal stationId As String, ByVal isQueryOldVersion As Boolean, ByVal cutcardVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        MAction = action
        _cutCardPn = cutcardpn
        Me.IsQueryOldVersion = isQueryOldVersion
        _stationId = stationId
        _cutCardVersion = cutcardVersion
    End Sub

#Region "属性"

    Private Enum ProcessGrid
        CheckCode = 0
        Description
        Unit
        ResultValue
        CheckGroup
        TVPARTNUMBER
        LINEPARTNUMBER
        LINEPARTNUMBERTwo
        LINEPARTNUMBERThree
        LINEPARTNUMBERFour
    End Enum

#Region "Variables"

    Public Enum ActionType
        ModifyStation = 0
        ModifySop
        ModifyProcessParameter
        GetProcessParameter
        ' ClearUIMode
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

    Private _isQueryOldVersion As Boolean
    Public Property IsQueryOldVersion() As Boolean
        Get
            Return _isQueryOldVersion
        End Get
        Set(ByVal value As Boolean)
            _isQueryOldVersion = value
        End Set
    End Property

#End Region

#End Region

#Region "事件"

    Private Sub FrmCutCardBodyModify_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Select Case Action
                Case ActionType.ModifySop
                Case ActionType.ModifyStation
                    TabControl1.Enabled = False
                    Me.txtStationid.Text = _stationId + "-" + _stationName
                Case ActionType.ModifyProcessParameter
                    AddHandler txtFinishSize.LostFocus, AddressOf txtFinishSize_LostFocus
                    GroupBox1.Enabled = False
                    If _isQueryOldVersion = False Then
                        LoadPn()
                        LoadCutSize()
                        LoadProcessParameter()
                        GetLeftProcessParametersByFormLoad()
                        GetRightProcessParametersByFormLoad()
                        ResetCutSize()
                        LoadVar()
                    End If
                    InitTools()
                    Me.txtStationid.Text = _stationName
                Case ActionType.GetProcessParameter
                    AddHandler txtFinishSize.LostFocus, AddressOf txtFinishSize_LostFocus
                    GroupBox1.Enabled = False
                    ' GroupBox2.Enabled = False
                    If _isQueryOldVersion = False Then
                        LoadPn()
                        LoadCutSize()
                        LoadProcessParameter()
                        LoadVar() '?
                    End If
                    InitTools()
                    'Case ActionType.ClearUIMode
                    '    AddHandler txtFinishSize.LostFocus, AddressOf txtFinishSize_LostFocus
                    '    GroupBox1.Enabled = False
                    '    If _isQueryOldVersion = False Then
                    '        LoadPn()
                    '        LoadCutSize()
                    '        LoadProcessParameter()
                    '        LoadVar() '?
                    '    End If
                    '    InitTools()
            End Select
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        Finally
            isFormLoad = False
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not BasicCheck() Then
                Exit Sub
            End If

            If Not SaveData() Then
                Exit Sub
            End If
            MessageUtils.ShowInformation("保存成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboLeftTv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftTv.SelectedIndexChanged
        Try

            If cboLeftTv.SelectedIndex <> -1 Then
                If isFormLoad Then Exit Sub
                m_blnChangeTV = True

                m_blnShowed = False   'let repeat show cq20170323
                GetLeftProcessParameters()
                ResetCutSize()
                If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value.ToString) Then
                    ReSetLeftLineSelected()
                End If
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLine.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            m_blnChangeWire = True
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineTwo.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            m_blnChangeWire = True
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception

            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineThree_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineThree.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboLeftLineFour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftLineFour.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetLeftProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub FrmRunCardBodyModify_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        isClose = True
        Select Case Action
            Case ActionType.GetProcessParameter
                outputProcessStand = GetProcessStand()

                'Add by cq 20171020
                outputLeftProcessStand = GetLeftProcessStand()
                outputRightProcessStand = GetRightProcessStand()
                outputLCLValue = GetLCLValue()
            Case Else
                outputProcessStand = GetProcessStand()

                outputLeftProcessStand = GetLeftProcessStand()
                outputRightProcessStand = GetRightProcessStand()
                outputLCLValue = GetLCLValue()
                'Add by CQ 20150923
                If Not String.IsNullOrEmpty(outputProcessStand) OrElse Val(Me.txtFinishSize.Text.Trim()) > 0 Then
                    m_iTotalStdTime = GetStdTime(outputProcessStand)
                End If
        End Select
    End Sub

#End Region

#Region "标准工时"
    Private Function GetFinishSizeByPartID(ByVal parPartID As String, ByVal parStationID As String) As String
        Dim lsSQL As String = ""
        GetFinishSizeByPartID = ""
        lsSQL = " SELECT ISNULL(Detail.FinishSize, header.FinishSize) as FinishSize from m_RCardD_t Detail " & _
                " LEFT JOIN m_RCardM_t Header ON  detail.partid = header.partid " & _
                " WHERE  detail.partid ='" & parPartID & "' and detail.StationID='" & parStationID & "'"
        Using dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetFinishSizeByPartID = RCardComBusiness.DBNullToStr(dt.Rows(0).Item("FinishSize"))
            End If
        End Using
        Return GetFinishSizeByPartID
    End Function

    Private Function GetStdTime(ByVal paroutputProcessStand As String) As Integer
        '是否有维护工时基础资料？
        If Not IsExistStdTimeBase() Then
            GetStdTime = 0
            Return GetStdTime
        Else
            'Is Exist Std Tiem Base Data?
            '工时资料不含变量项, 则根据成品尺寸范围, 进行计算(如下, 通过判断成品尺寸, 得到总标准工时)
            If Not m_blnExistsVar Then
                If Val(Me.txtFinishSize.Text.Trim()) > 0 Then
                    GetStdTime = GetStdTimeByFinishSize(Val(Me.txtFinishSize.Text.Trim()))
                End If
            Else
                ' 工时资料含变量项，但未通过“工序修改页面”维护变量项(左端脱皮尺寸、右端脱皮尺寸、变量项1、变量项2)，
                ' 则为0，并提示：工时计算公式含变量项，请先维护至少一个变量项，才可计算工时。允许其直接手填工时，
                '或者重新点击“获取工艺标准”维护变量项，（关闭时）再自动计算工时
                GetStdTime = GetStdTimeWhenExistVar(paroutputProcessStand)
            End If
        End If
        Return GetStdTime
    End Function

    Private Function GetStdTimeWhenExistVar(ByVal paroutputProcessStand) As Integer
        Dim o_iLPLSize As Integer = 0, o_iRPLSize As Integer = 0, o_iSingleVarStdTime As Integer = 0


        '左端脱皮尺寸、右端脱皮尺寸、变量项1、变量项2
        For Each o_str As String In paroutputProcessStand.Split(";")
            '裁线尺寸(mm):983±2; 左端脱皮尺寸(mm):10±1; 右端拉拔力(kgf/min):10±1; 右端脱皮尺寸(mm):10±1;
            If o_str.IndexOf("左端脱皮尺寸") >= 0 Then
                o_iLPLSize = Val(o_str.Split(":")(1))
                Continue For
            End If

            If o_str.IndexOf("右端脱皮尺寸") >= 0 Then
                o_iRPLSize = Val(o_str.Split(":")(1))
            End If
        Next

        If o_iLPLSize > 0 Then
            GetStdTimeWhenExistVar = GetStdTimeBySingleVar(o_iLPLSize)
        End If

        If o_iRPLSize > 0 Then
            GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(o_iRPLSize)
        End If

        If Val(Me.txtValue1.Text) > 0 Then
            GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(Val(Me.txtValue1.Text))
        End If

        If Val(Me.txtValue2.Text) > 0 Then
            GetStdTimeWhenExistVar = GetStdTimeWhenExistVar + GetStdTimeBySingleVar(Val(Me.txtValue2.Text))
        End If
        Return GetStdTimeWhenExistVar
    End Function

    Private Function GetStdTimeBySingleVar(ByVal parVarValue As Double) As Integer
        Dim lsSQL As String = ""
        Dim o_strWorkHour As String = ""
        GetStdTimeBySingleVar = "0"

        lsSQL = " SELECT TOP 1 CASE WHEN FinishSizeMax< " & Val(Me.txtFinishSize.Text) & "  THEN WorkHour ELSE StandardHour END  WorkHour  " & _
                " FROM DBO.m_RstationWorkHour_t  " & _
                " WHERE ((VariableMin<" & parVarValue & " AND  VariableMax>=" & parVarValue & ") OR(VariableMin< " & parVarValue & " AND (VariableMax IS NULL OR VariableMax='')))" & _
                " and Stationid ='" & _stationId & "'"
        Dim o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
            o_strWorkHour = o_dt.Rows(0).Item("WorkHour")  '83+20*(X-1400)/300+0.4*(L-500)/1000 
        Else
            o_strWorkHour = "0"
        End If

        o_strWorkHour = o_strWorkHour.Replace("L", Val(Me.txtFinishSize.Text)).Replace("X", parVarValue)
        'SELECT  CEILING(" & WorkHour1.Replace("L", strFinishSize).Replace("X", strVariable1) & "+" & WorkHour2.Replace("L", strFinishSize).Replace("X", strVariable2) & ")
        lsSQL = " SELECT  CEILING(" & o_strWorkHour & ")"

        Dim o_dtSingleStdTime As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dtSingleStdTime) AndAlso o_dtSingleStdTime.Rows.Count > 0 Then
            GetStdTimeBySingleVar = o_dtSingleStdTime.Rows(0).Item(0)  '3+0.4*(L-500)/1000
        End If
        Return GetStdTimeBySingleVar
    End Function

    Private Function IsExistStdTimeBase() As Boolean
        Dim lsSQL As String = ""
        lsSQL = " SELECT TOP 1 ExistVariables  from  m_RstationWorkHour_t where stationid ='" & _stationId & "'"

        Dim o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
            IsExistStdTimeBase = True
            m_blnExistsVar = CBool(o_dt.Rows(0).Item("ExistVariables"))
        Else
            IsExistStdTimeBase = False
        End If
    End Function

    Private Function GetStdTimeByFinishSize(ByVal parFinishSize As Double) As Integer
        Dim lsSQL As String = ""
        Dim o_strWorkHour As String = ""

        lsSQL = " SELECT TOP 1 WorkHour  FROM DBO.m_RstationWorkHour_t  " & _
               " WHERE ((FinishSizeMin< " & parFinishSize & " AND  FinishSizeMax>=" & parFinishSize & ")  OR (FinishSizeMin< " & parFinishSize & " AND (FinishSizeMax IS NULL OR FinishSizeMax='')))" & _
               " AND Stationid ='" & _stationId & "'"

        Dim o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
            o_strWorkHour = o_dt.Rows(0).Item("WorkHour")  '3+0.4*(L-500)/1000 or 7+0
        Else
            o_strWorkHour = "0"
        End If

        If o_strWorkHour.ToUpper.Contains("L") Then
            o_strWorkHour = o_strWorkHour.Replace("L", parFinishSize)
        End If

        lsSQL = " SELECT  CEILING(" & o_strWorkHour & ")"

        Dim o_dtTotalStdTime As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dtTotalStdTime) AndAlso o_dtTotalStdTime.Rows.Count > 0 Then
            GetStdTimeByFinishSize = o_dtTotalStdTime.Rows(0).Item(0)  '3+0.4*(L-500)/1000
        Else
            GetStdTimeByFinishSize = 0
        End If
        Return GetStdTimeByFinishSize

    End Function

#End Region

#Region "方法"

    Private Sub LoadStation()
        Dim sql As String = "SELECT '" & _stationId & "' stationID,N'" & _stationName & "' StationName UNION "
        sql &= " SELECT stationID,StationName from m_Rstation_t(nolock) WHERE stationID<>'" & _stationId & "'  and usey='Y'"
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
    End Sub

    'CQ 20160711
    Private Sub LoadPn()

        Call loadTVPN()

        Call LoadLinePN()

    End Sub

    Private Sub loadTVPN()
        '端子栏	2*****-*** ,03*-******-****,10*-******-****
        '	11*-******-****,27*-******-****,05*-******-****
        'TAvcPart LIKE '2_____-%'
        Dim sql As String = " SELECT TAvcPart,TAvcPart+'.'+DESCRIPTION + '.' + TypeDest FROM V_m_PartContrast_t WHERE PAvcPart <> TAvcPart AND " &
                            " PAvcPart='" & _cutCardPn & "' AND " & _
                            " ( TAvcPart LIKE '2_____-%' OR TAvcPart LIKE '03%' OR  TAvcPart LIKE '10_-%' OR  TAvcPart LIKE '11_-%' OR  TAvcPart LIKE '27%' OR  TAvcPart LIKE '05%') "
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
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
        cboLeftTv.Items.AddRange(crs)
    End Sub

    Private Sub LoadLinePN()
        '线材	00*-******-****
        '01*-******-****
        '1*****-***
        '料号+规格+品名
        Dim sql As String = " SELECT TAvcPart,TAvcPart+'.'+DESCRIPTION + '.' + TypeDest FROM V_m_PartContrast_t WHERE PAvcPart <> TAvcPart AND " &
                            " PAvcPart='" & _cutCardPn & "' AND " & _
                            " ( TAvcPart LIKE '00%' OR TAvcPart LIKE '01%' OR  TAvcPart LIKE '1_____-%') "

        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
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
        cboRightLine.Items.AddRange(crs)
        cboRightLineTwo.Items.AddRange(crs)
        cboRightLineThree.Items.AddRange(crs)
        cboRightLineFour.Items.AddRange(crs)
        cboLeftLine.Items.AddRange(crs)
        cboLeftLineTwo.Items.AddRange(crs)
        cboLeftLineThree.Items.AddRange(crs)
        cboLeftLineFour.Items.AddRange(crs)
    End Sub

    Private Sub LoadProcessParameter()
        Dim sql As String = Nothing
        sql = "SELECT A.CheckItemID,ISNULL(A.DESCRIPTION,'') '校验项次',c.Unit '单位', ISNULL(B.ResultValue,'') '校验值',A.CHECKGROUP,LeftTVPN,LeftWirePN1,LeftWirePN2, LeftWirePN3, LeftWirePN4 " &
             " FROM m_RstationCheckItem_t A LEFT JOIN  m_CutCardDCheckItem_t B ON A.Stationid=B.Stationid AND A.CheckItemID=B.CheckItemID AND PartID='" & _cutCardPn & "'" & _
             " LEFT JOIN m_CheckItem_t  C on a.CheckItemID= c.CheckItemID" & _
             " WHERE A.UseY=1 AND A.CHECKGROUP='LH' AND A.STATIONID='" & _stationId & "'ORDER BY C.CATEGORY,C.SortSeq"

        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            dgvLeft.DataSource = dt
            If Not IsNothing(dt.Select("CheckItemID='LPL'")) AndAlso dt.Select("CheckItemID='LPL'").Length > 0 Then  ' LPL 左脱皮, RPL 右脱皮 
                m_blnExistLeftCut = True
            End If
        End Using
        sql = " SELECT A.CheckItemID,ISNULL(A.DESCRIPTION,'') '校验项次',c.Unit '单位',ISNULL(B.ResultValue,'') '校验值',A.CHECKGROUP,RightTVPN,RightWirePN1,RightWirePN2,RightWirePN3,RightWirePN4  " &
               " FROM m_RstationCheckItem_t A LEFT JOIN  m_CutCardDCheckItem_t B ON A.Stationid=B.Stationid AND A.CheckItemID=B.CheckItemID AND PartID='" & _cutCardPn & "'" &
               " LEFT JOIN m_CheckItem_t  C ON a.CheckItemID= c.CheckItemID" & _
               " WHERE A.UseY=1 AND A.CHECKGROUP='RH' AND A.STATIONID='" & _stationId & "' ORDER BY C.CATEGORY,C.SortSeq"
        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            dgvRight.DataSource = dt
            If Not IsNothing(dt.Select("CheckItemID='RPL'")) AndAlso dt.Select("CheckItemID='RPL'").Length > 0 Then  ' LPL 左脱皮, RPL 右脱皮 
                m_blnExistRightCut = True
            End If
        End Using
        SetDataGridStyle()
        SetComboxStyle(_stationId, _cutCardPn)
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

        dgvLeft.Columns(ProcessGrid.Unit).ReadOnly = True
        dgvRight.Columns(ProcessGrid.Unit).ReadOnly = True

        dgvLeft.Columns(ProcessGrid.ResultValue).ReadOnly = False
        dgvRight.Columns(ProcessGrid.ResultValue).ReadOnly = False
        dgvLeft.Columns(ProcessGrid.Description).Width = 120
        dgvRight.Columns(ProcessGrid.Description).Width = 120
        dgvLeft.Columns(ProcessGrid.Unit).Width = 80
        dgvRight.Columns(ProcessGrid.Unit).Width = 80
    End Sub

    Private Sub SetComboxStyle(Optional ByVal stationID As String = "", Optional ByVal PartID As String = "")
        Dim o_strLeftTv As String = "", o_strLeftLine As String = "", o_strLeftLineTwo As String = "", o_strLeftLineThree As String = "", o_strLeftLineFour As String = ""
        Dim o_strRightTv As String = "", o_strRightLine As String = "", o_strRightLineTwo As String = "", o_strRightLineThree As String = "", o_strRightLineFour As String = ""

        If dgvLeft.Rows.Count <= 0 OrElse dgvRight.Rows.Count <= 0 Then
            Call GetTVAndWirePN(o_strLeftTv, o_strLeftLine, o_strLeftLineTwo, o_strLeftLineThree, o_strLeftLineFour, _
                                   o_strRightTv, o_strRightLine, o_strRightLineTwo, o_strRightLineThree, o_strRightLineFour _
                                   )
        End If

        If dgvLeft.Rows.Count <= 0 Then
            If Not String.IsNullOrEmpty(o_strLeftTv) Then
                cboLeftTv.SelectedIndex = cboLeftTv.FindString(o_strLeftTv)
            Else
                cboLeftTv.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strLeftLine) Then
                cboLeftLine.SelectedIndex = cboLeftLine.FindString(o_strLeftLine)
            Else
                cboLeftLine.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strLeftLineTwo) Then
                cboLeftLineTwo.SelectedIndex = cboLeftLineTwo.FindString(o_strLeftLineTwo)
            Else
                cboLeftLineTwo.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strLeftLineThree) Then
                cboLeftLineThree.SelectedIndex = cboLeftLineThree.FindString(o_strLeftLineThree)
            Else
                cboLeftLineThree.SelectedIndex = 0
            End If

            If Not String.IsNullOrEmpty(o_strLeftLineFour) Then
                cboLeftLineFour.SelectedIndex = cboLeftLineFour.FindString(o_strLeftLineFour)
            Else
                cboLeftLineFour.SelectedIndex = 0
            End If
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
            If Not String.IsNullOrEmpty(o_strRightTv) Then
                cboRightTv.SelectedIndex = cboRightTv.FindString(o_strRightTv)
            Else
                cboRightTv.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strRightLine) Then
                cboRightLine.SelectedIndex = cboRightLine.FindString(o_strRightLine)
            Else
                cboRightLine.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strRightLineTwo) Then
                cboRightLineTwo.SelectedIndex = cboRightLineTwo.FindString(o_strRightLineTwo)
            Else
                cboRightLineTwo.SelectedIndex = 0
            End If
            If Not String.IsNullOrEmpty(o_strRightLineThree) Then
                cboRightLineThree.SelectedIndex = cboRightLineThree.FindString(o_strRightLineThree)
            Else
                cboRightLineThree.SelectedIndex = 0
            End If

            If Not String.IsNullOrEmpty(o_strRightLineFour) Then
                cboRightLineFour.SelectedIndex = cboRightLineFour.FindString(o_strLeftLineFour)
            Else
                cboRightLineFour.SelectedIndex = 0
            End If
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

    Private Sub GetTVAndWirePN(ByRef o_strLeftTv As String, ByRef o_strLeftLine As String, ByRef o_strLeftLineTwo As String, _
                               ByRef o_strLeftLineThree As String, ByRef o_strLeftLineFour As String, _
                               ByRef o_strRightTv As String, ByRef o_strRightLine As String, ByRef o_strRightLineTwo As String,
                               ByRef o_strRightLineThree As String, ByRef o_strRightLineFour As String
                               )
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT LeftTVPN,leftwirepn1, leftwirepn2,leftwirepn3,LeftWirePN4," & _
                " RightTVPN, RightWirePN1, RightWirePN2, RightWirePN3, RightWirePN4" & _
                " FROM  m_CutCardDCheckItem_t " & _
                " WHERE partid ='" & _cutCardPn & "' and CheckItemID='LCL' and stationid ='" & _stationId & "'"

        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                o_strLeftTv = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("LeftTVPN"))
                o_strLeftLine = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("leftwirepn1"))
                o_strLeftLineTwo = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("leftwirepn2"))
                o_strLeftLineThree = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("leftwirepn3"))
                o_strLeftLineFour = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("LeftWirePN4"))
                o_strRightTv = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("RightTVPN"))
                o_strRightLine = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("RightWirePN1"))
                o_strRightLineTwo = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("RightWirePN2"))
                o_strRightLineThree = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("RightWirePN3"))
                o_strRightLineFour = RCardComBusiness.DBNullToStr(o_dt.Rows(0).Item("RightWirePN4"))
            End If
        End Using
    End Sub
    Private Sub LoadCutSize()
        Dim sql As String = Nothing
        sql = " SELECT ResultValue,FinishSize,Tolerance,ToleranceRange FROM m_CutCardDCheckItem_t WHERE PartID='" & _cutCardPn &
              "' AND Stationid='" & _stationId & "' AND CheckItemID='LCL' AND Status='1'"
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            txtCutSize.Text = dt.Rows(0)("ResultValue").ToString
            txtFinishSize.Text = dt.Rows(0)("FinishSize").ToString
            txtCD.Text = dt.Rows(0)("Tolerance").ToString
            m_strToleranceRange = dt.Rows(0)("ToleranceRange").ToString
        End If
        If String.IsNullOrEmpty(txtCD.Text) Then txtCD.Text = "±0"
        sql = " SELECT 1 FROM m_RstationCheckItem_t WHERE Stationid='" & _stationId & "' AND UseY=1 AND CheckItemID='LCL'"
        dt.Reset()
        dt = RCardComBusiness.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            txtCutSize.Enabled = True
        Else
            txtCutSize.Enabled = False
        End If
    End Sub

    Private Function BasicCheck() As Boolean
        Select Case Action
            Case ActionType.ModifyStation
                If String.IsNullOrEmpty(Me.txtStationid.Text.Trim().Split("-")(0)) Then
                    MessageUtils.ShowError("请选择工站！")
                    Return False
                End If

                If Not Me.txtStationid.Text.Trim().Split("-")(0).StartsWith("R") Then
                    MessageUtils.ShowError("请选择R类型的工站！")
                    Return False
                End If

                If StationExists() Then
                    MessageUtils.ShowError("该工站已经存在，请确认！！")
                    Return False
                End If
            Case ActionType.ModifyProcessParameter, ActionType.GetProcessParameter
                If txtCutSize.Enabled = True AndAlso String.IsNullOrEmpty(txtFinishSize.Text) AndAlso String.IsNullOrEmpty(txtCutSize.Text) Then
                    MessageUtils.ShowError("请至少输入成品尺寸或是裁线尺寸！")
                    txtFinishSize.Select()
                    Return False
                End If
                If txtCutSize.Enabled = True And txtCutSize.Text.Contains("L") Then
                    MessageUtils.ShowError("裁线尺寸输入错误！")
                    txtCutSize.Select()
                    Return False
                End If

                '如果只选了左端的端子线材，左端的参数必填（右端的可填，可不填）
                '如果只选了右端的端子线材，右端的参数必填（左端的可填，可不填）
                '如果两端都选了端子线材，两端的参数项必填
                '如果两端都没选端子线材，所有的参数都要填
                If dgvLeft.Rows.Count > 0 Then
                    If IsLeftTvSelected() AndAlso Not IsAnyLeftLineSelected() Then
                        MessageUtils.ShowError("选中了左端端子料号，请选择左端线材料号！")
                        cboLeftLine.Select()
                        Return False
                    End If
                    If Not IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
                        MessageUtils.ShowError("选中了左端线材料号,请选择左端端子料号！")
                        cboLeftTv.Select()
                        Return False
                    End If
                    If IsLeftTvSelected() And IsAnyLeftLineSelected() Then
                        For Each dr As DataGridViewRow In dgvLeft.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageUtils.ShowError("选择了左端信息，必须输入各个校验项的校验值或是检查加工参数是否维护！")
                                Return False
                            End If
                        Next
                        'cq 20160725
                        If String.IsNullOrEmpty(Me.txtCutSize.Text) AndAlso Me.txtCutSize.Enabled = True Then
                            MessageUtils.ShowError("裁线尺寸不能为空！")
                            Return False
                        End If
                    End If
                End If
                If dgvRight.Rows.Count > 0 Then
                    If IsRightTvSelected() AndAlso Not IsAnyRightLineSelected() Then
                        MessageUtils.ShowError("选中了右端端子料号，请选择右端线材料号！")
                        cboLeftLine.Select()
                        Return False
                    End If
                    If Not IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
                        MessageUtils.ShowError("选中了右端线材料号,请选择右端端子料号！")
                        cboLeftTv.Select()
                        Return False
                    End If
                    If IsRightTvSelected() And IsAnyRightLineSelected() Then
                        For Each dr As DataGridViewRow In dgvRight.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageUtils.ShowError("选择了右端信息，必须输入各个校验项的校验值或是检查加工参数是否维护！")
                                Return False
                            End If
                        Next
                        'cq 20160725
                        If String.IsNullOrEmpty(Me.txtCutSize.Text) AndAlso Me.txtCutSize.Enabled = True Then
                            MessageUtils.ShowError("裁线尺寸不能为空！")
                            Return False
                        End If
                    End If
                End If

                If dgvLeft.Rows.Count <= 0 AndAlso dgvRight.Rows.Count > 0 Then
                    'do nothing
                ElseIf dgvLeft.Rows.Count > 0 AndAlso dgvRight.Rows.Count < 0 Then
                    'do nothing 
                ElseIf dgvLeft.Rows.Count > 0 AndAlso dgvRight.Rows.Count > 0 Then
                    'do nothing
                End If

                If (Not IsLeftTvSelected() AndAlso Not IsAnyLeftLineSelected()) AndAlso (Not IsRightTvSelected() AndAlso Not IsAnyRightLineSelected()) Then
                    If dgvLeft.Rows.Count > 0 Then
                        For Each dr As DataGridViewRow In dgvLeft.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageUtils.ShowError("左端 必须输入各个校验项的校验值或是检查加工参数是否维护！")
                                Return False
                            End If
                        Next
                    End If

                    If dgvRight.Rows.Count > 0 Then
                        For Each dr As DataGridViewRow In dgvRight.Rows
                            If String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                                MessageUtils.ShowError("右端 必须输入各个校验项的校验值或是检查加工参数是否维护！")
                                Return False
                            End If
                        Next
                    End If
                End If

                If String.IsNullOrEmpty(Me.txtCutSize.Text) AndAlso Me.txtCutSize.Enabled = True Then
                    MessageUtils.ShowError("裁线尺寸不能为空！")
                    Return False
                End If

                'cq20170321
                If txtCutSize.Enabled = True Then
                    If String.IsNullOrEmpty(leftFrontSize) AndAlso (Me.cboLeftTv.Text <> String.Empty) Then
                        Dim a As String = Me.txtQDCutSize.Text
                        Dim iCount As Integer = 0
                        Dim r As String = a.Replace("-", "")
                        iCount = a.Length - r.Length
                        'add -- cq20170322
                        If a.IndexOf("--") < 0 Then
                            If (Not String.IsNullOrEmpty(Me.cboRightTv.Text)) Then
                                If iCount <= 0 Then
                                    MessageUtils.ShowError("请检查左边前端尺寸是否维护！")
                                    Return False
                                ElseIf iCount = 1 Then
                                    MessageUtils.ShowError("请检查左边或者右边前端尺寸是否维护！")
                                    Return False
                                End If
                            Else
                                If iCount <= 0 Then
                                    MessageUtils.ShowError("请检查左边前端尺寸是否维护！")
                                    Return False
                                End If
                            End If
                        Else
                            '--3
                            If (Not String.IsNullOrEmpty(Me.cboRightTv.Text)) Then
                                If iCount <= 2 Then
                                    MessageUtils.ShowError("请检查左边前端尺寸是否维护！")
                                    Return False
                                End If
                            End If
                        End If
                    End If
                End If

                'cq20170321
                If txtCutSize.Enabled = True Then
                    If String.IsNullOrEmpty(rightFrontSize) AndAlso (Me.cboRightTv.Text <> String.Empty) Then
                        Dim a As String = Me.txtQDCutSize.Text
                        Dim iCount As Integer = 0
                        Dim r As String = a.Replace("-", "")
                        iCount = a.Length - r.Length
                        If a.IndexOf("--") < 0 Then
                            If iCount <= 1 Then
                                MessageUtils.ShowError("请检查右边前端尺寸是否维护！")
                                Return False
                            End If
                        Else
                            If iCount <= 2 Then
                                MessageUtils.ShowError("请检查右边前端尺寸是否维护！")
                                Return False
                            End If
                        End If
                    End If
                End If

                If IsExistVar() Then
                    '维护变量项(左端脱皮尺寸、右端脱皮尺寸、变量项1、变量项2)
                    If (Not m_blnExistLeftCut) AndAlso (Not m_blnExistRightCut) AndAlso Val(Me.txtValue1.Text) <= 0 AndAlso Val(Me.txtValue2.Text) <= 0 Then
                        ' 含变量项, 请先维护至少一个变量项
                        MessageUtils.ShowError("该工站含变量项,请先维护至少一个变量项！")
                        Return False
                    End If
                End If
        End Select
        Return True
    End Function

    Private Function IsExistVar() As Boolean
        Dim lsSQL As String = ""
        lsSQL = "SELECT top 1 ExistVariables  FROM  m_RstationWorkHour_t WHERE stationid ='" & _stationId & "'"

        Dim o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
        If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
            IsExistVar = CBool(o_dt.Rows(0).Item("ExistVariables"))
        Else
            IsExistVar = False
        End If
        m_blnExistsVar = IsExistVar
        Return IsExistVar
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

    Private Function StationExists() As Boolean
        Dim sql As String = Nothing
        If Me.IsQueryOldVersion = False Then
            sql = "SELECT StationID FROM m_RCardCutD_t WHERE 1=1 " &
                    RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                    RCardComBusiness.GetWhereAnd("Stationid", Me.txtStationid.Text.Trim().Split("-")(0)) &
                    RCardComBusiness.GetFatoryProfitcenter()
        Else
            sql = "SELECT StationID FROM m_RCardCutDOldVer_t WHERE 1=1 " &
                    RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                    RCardComBusiness.GetWhereAnd("Stationid", Me.txtStationid.Text.Trim().Split("-")(0)) &
                    RCardComBusiness.GetFatoryProfitcenter()
        End If
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function SaveData() As Boolean
        Dim sql As String = "", result As String = ""
        Try
            Select Case Action
                Case ActionType.ModifySop
                Case ActionType.ModifyStation
                    Dim StationID As String = Me.txtStationid.Text.Trim.Split("-")(0)
                    Dim StationName As String = Me.txtStationid.Text.Trim.Split("-")(1)
                    StationName = StationName.Replace("/", "")
                    StationName = StationName.Replace("\", "")
                    StationName = Replace(StationName, Chr(10), "")
                    StationName = Replace(StationName, Chr(13), "")
                    StationName = StationName.Replace(" ", "")

                    Dim partId As String = _cutCardPn
                    Dim oldStaID As String = _stationId
                    If Me.IsQueryOldVersion = False Then
                        sql = " UPDATE m_RCardCutD_t SET StationID='" & StationID & "',Equipment=NULL,WorkingHours=0,ProcessStandard=NULL,Remark=NULL " & _
                        ",USERID='" & UserId & "',InTime=GETDATE() " &
                        " WHERE 1=1" & RCardComBusiness.GetWhereAnd("PartID", partId) &
                        RCardComBusiness.GetWhereAnd("Stationid", oldStaID) &
                        RCardComBusiness.GetFatoryProfitcenter()

                        'add by cq 20170531,add update modifytime
                        sql &= " UPDATE m_RCardCutM_t SET ModifyTime=GETDATE() " &
                    " WHERE 1=1" & RCardComBusiness.GetWhereAnd("PartID", partId) &
                    RCardComBusiness.GetWhereAnd("Stationid", oldStaID) &
                    RCardComBusiness.GetFatoryProfitcenter()
                        If oldStaID <> StationID Then
                            If MessageUtils.ShowConfirm("修改工站后，先前工站的检查参数都将被删除，请确认？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                                sql &= " DELETE FROM m_CutCardDCheckItem_t WHERE 1=1" &
                                        RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                                        RCardComBusiness.GetWhereAnd("Stationid", oldStaID) &
                                        RCardComBusiness.GetFatoryProfitcenter()
                                sql &= " DELETE FROM m_CutCardDPart_t WHERE 1=1" &
                                        RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                                        RCardComBusiness.GetWhereAnd("Stationid", oldStaID) &
                                        RCardComBusiness.GetFatoryProfitcenter()
                            End If
                        End If
                    Else
                        sql = "UPDATE m_RCardCutDOldVer_t SET Stationid='" & StationID & "'," & _
                            " USERID='" & UserId & "',INTIME=GETDATE() " &
                            " WHERE 1=1" &
                            RCardComBusiness.GetWhereAnd("PartID", partId) &
                            RCardComBusiness.GetWhereAnd("Stationid", oldStaID) &
                            RCardComBusiness.GetFatoryProfitcenter()
                    End If
                    outputStationId = Me.txtStationid.Text.Trim().Split("-")(0) 'row.Item(0).ToString
                    outputStationName = Me.txtStationid.Text.Trim().Split("-")(1) 'row.Item(1).ToString
                Case ActionType.ModifyProcessParameter
                    If Me.IsQueryOldVersion = False Then
                        'move auto update data for leave event to here ,when click save button, save the data, 20170304
                        Call UpdateData()
                        sql = GetSaveSql()
                        sql &= SetUpdateMDSql()
                        sql &= GetPnSqlByAdd()
                        sql &= SaveUIData()
                        Dim tempsql As String = String.Empty
                        tempsql = SaveBodyLCLUIValue()
                        sql &= tempsql

                    Else
                        'do nothing
                    End If


                    'Dim tempsql As String = String.Empty, tempsql2 As String = ""
                    'tempsql = SetUpdateMDSql()
                    'tempsql2 = SaveBodyModifyUIValue()
                    'sql &= tempsql

                    'sql &= tempsql2




                Case ActionType.GetProcessParameter
                    If Me.IsQueryOldVersion = False Then
                        'move auto update data for leave event to here ,when click save button, save the data, 20170303
                        Call UpdateData()
                        sql = GetSaveSql()
                        sql &= SetUpdateSql()
                        sql &= GetPnSqlByAdd()
                        'add by cq 20170930
                        sql &= SaveUIData()
                        outputProcessStand = GetAddProcessStand()
                    End If
                    outputSql = sql
            End Select
            If sql <> "" Then
                result = RCardComBusiness.ExecSQL(sql)
                If result <> "" Then
                    MessageUtils.ShowError(result)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 保存 该工站的裁线尺寸值
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveBodyLCLUIValue()
        Dim sql As String

        sql = " UPDATE m_RCardCutD_t " & _
              "  Set LCLValue= '" & Me.txtCutSize.Text.Trim & "'" & _
              "  Where 1=1" & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & _
                    RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
        RCardComBusiness.GetFatoryProfitcenter()
        Return sql.ToString
    End Function

    Private Function GetSaveSql()
        Dim sql As String = Nothing
        If Not IsLeftTvSelected() OrElse Not IsAnyLeftLineSelected() Then
            For Each dr As DataGridViewRow In dgvLeft.Rows
                If (Not IsLeftTvSelected()) AndAlso (Not IsAnyLeftLineSelected()) Then
                    'may be manual maintain , not delete
                    If IsDBNull(dr.Cells(ProcessGrid.ResultValue).Value) OrElse String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                        sql &= GetDeleteSql(dr, 0)  'Mark by CQ 20151201, in order to save data when not select TV and WirePN
                    End If
                    sql &= GetUpdateLTVAndWireSql(dr, 0)
                Else
                    sql &= GetDeleteSql(dr, 0)  'Mark by CQ 20151201, in order to save data when not select TV and WirePN
                End If
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
                If (Not IsRightTvSelected()) AndAlso (Not IsAnyRightLineSelected()) Then
                    If IsDBNull(dr.Cells(ProcessGrid.ResultValue).Value) OrElse String.IsNullOrEmpty(dr.Cells(ProcessGrid.ResultValue).Value) Then
                        sql &= GetDeleteSql(dr, 1) 'Mark by CQ 20151202, in order to save data when not select right TV and WirePN
                    End If
                    sql &= GetUpdateRTVAndWireSql(dr, 0)
                Else
                    sql &= GetDeleteSql(dr, 0)  'Mark by CQ 20151201, in order to save data when not select TV and WirePN
                End If
            Next
        Else
            ' If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
            For Each dr As DataGridViewRow In dgvRight.Rows
                sql &= GetProcessSql(dr, 1)
            Next
            ' End If
        End If

        sql &= GetCutSql()
        'Add by CQ 20151117
        sql &= GetVarAndFinishSizeSql()
        Return sql
    End Function


    Private Function SaveUIData()
        Dim sql As String = Nothing
        Dim strLeftProcess As String = "", strRightProcess As String = ""

        If dgvLeft.Rows.Count > 0 Then
            For Each dr As DataGridViewRow In dgvLeft.Rows
                strLeftProcess &= dr.Cells(ProcessGrid.Description).Value + ":" + dr.Cells(ProcessGrid.ResultValue).Value + ";"
            Next
        Else
            strLeftProcess = ""
        End If

        If dgvRight.Rows.Count > 0 Then
            For Each dr As DataGridViewRow In dgvRight.Rows
                strRightProcess &= dr.Cells(ProcessGrid.Description).Value + ":" + dr.Cells(ProcessGrid.ResultValue).Value + ";"
            Next
        Else
            strRightProcess = ""
        End If

        sql = " delete from m_CutCardBodyModifyLog where partid ='" & _cutCardPn & "' and stationid ='" & _stationId & "' and Version='" & _cutCardVersion & "'"

        sql &= " Insert into m_CutCardBodyModifyLog(PartID, Stationid, LeftTVPN,LeftLine,LeftLineTwo,LeftLineThree, LeftLineFour," & _
              " RightTVPN, RightLine,RightLineTwo,RightLineThree,RightLineFour, LeftCheckItem, RightCheckItem,QDCutSize,FinshSize,CutSize, UserID, Intime,Version)" & _
              " values( '" & _cutCardPn & "', '" & _stationId & "' , '" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "', " & _
              " '" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "', '" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "', " & _
              " '" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "', '" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'," & _
              " '" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "', '" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'," & _
              " '" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "', '" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "', " & _
              " '" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "', N'" & strLeftProcess & "',N'" & strRightProcess & "'," & _
              " '" & Me.txtQDCutSize.Text & "', '" & txtFinishSize.Text.Trim & "', '" & txtCutSize.Text.Trim & "'," & _
              " '" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & _cutCardVersion & "') "
        Return sql
    End Function

    Private Function GetVarAndFinishSizeSql()
        Dim sql As String = Nothing
        If m_blnExistsVar Then
            ' PartID, StationID, StationSQ,WorkingHours,Equipment,ProcessStandard,
            'Remark, Status,Shape,NewProcessStandard,Factoryid,Profitcenter,UserID, Intime, VariableName1,VariableValue1,VariableName2,VariableValue2 from m_RCardD_t
            sql &= " UPDATE m_RCardCutD_t SET VariableName1=N'" & Me.txtVarName1.Text.Trim() & "'," & _
                   " VariableValue1= '" & Val(Me.txtValue1.Text.Trim()) & "', " & _
                   " VariableName2=N'" & Me.txtVarName2.Text.Trim() & "', VariableValue2= '" & Val(Me.txtValue2.Text.Trim()) & "' " &
                 " ,USERID='" & UserId & "',INTIME=GETDATE(), FinishSize=" & Val(Me.txtFinishSize.Text.Trim()) & " " & _
                 " Where 1=1  " & _
                    RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                    RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
            RCardComBusiness.GetFatoryProfitcenter()
        End If
        'only need update finish Size
        sql &= " UPDATE m_RCardCutD_t SET USERID='" & UserId & "',INTIME=GETDATE(), FinishSize=" & Val(Me.txtFinishSize.Text.Trim()) & " " & _
         " Where 1=1  " & _
           RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
           RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
           RCardComBusiness.GetFatoryProfitcenter()
        Return sql
    End Function

    Private Function GetDeleteSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim sql As String = Nothing
        If type = 0 Or type = 1 Then
            sql = "DELETE FROM m_CutCardDCheckItem_t WHERE  1=1  " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString) &
                RCardComBusiness.GetFatoryProfitcenter()
        End If
        Return sql
    End Function

    Private Function GetUpdateLTVAndWireSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim sql As String = Nothing
        If type = 0 Or type = 1 Then
            sql = " Update  m_CutCardDCheckItem_t  SET lefttvpn = null, leftwirepn1 = null WHERE  1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString) &
                RCardComBusiness.GetFatoryProfitcenter()
        End If
        Return sql
    End Function

    Private Function GetUpdateRTVAndWireSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim sql As String = Nothing
        If type = 0 Or type = 1 Then
            sql = " Update  m_CutCardDCheckItem_t  SET rightTvpn = null, rightwirepn1 = null ,rightwirepn2 = null ,rightwirepn3 = null,rightwirepn4 = null WHERE  1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString) &
                RCardComBusiness.GetFatoryProfitcenter()
        End If
        Return sql
    End Function

    Private Function GetProcessSql(ByVal dr As DataGridViewRow, ByVal type As Integer)
        Dim Description As String = dr.Cells(ProcessGrid.Description).Value.ToString
        Dim ResultValue As String = dr.Cells(ProcessGrid.ResultValue).Value.ToString
        Dim CheckGroup As String = dr.Cells(ProcessGrid.CheckGroup).Value.ToString
        Dim CheckCode As String = dr.Cells(ProcessGrid.CheckCode).Value.ToString

        Dim sql As String = Nothing
        sql = "IF (SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", CheckCode) &
                RCardComBusiness.GetFatoryProfitcenter() & ")=1" &
           " BEGIN " &
           "    UPDATE m_CutCardDCheckItem_t SET Description=N'" & Description & "',ResultValue=N'" & ResultValue & "' " &
           "    ,STATUS='1',USERID='" & UserId & "',intime=GETDATE(),CheckGroup='" & CheckGroup & "'"
        If type = 0 Then
            sql &= GetUpdateSQL(cboLeftTv, "LeftTVPN")
            sql &= GetUpdateSQL(cboLeftLine, "LeftWirePN1")
            sql &= GetUpdateSQL(cboLeftLineTwo, "LeftWirePN2")
            sql &= GetUpdateSQL(cboLeftLineThree, "LeftWirePN3")
            sql &= GetUpdateSQL(cboLeftLineFour, "LeftWirePN4")
        Else
            sql &= GetUpdateSQL(cboRightTv, "RightTVPN")
            sql &= GetUpdateSQL(cboRightLine, "RightWirePN1")
            sql &= GetUpdateSQL(cboRightLineTwo, "RightWirePN2")
            sql &= GetUpdateSQL(cboRightLineThree, "RightWirePN3")
            sql &= GetUpdateSQL(cboRightLineFour, "RightWirePN4")
        End If
        sql &= "  WHERE 1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", CheckCode) &
                RCardComBusiness.GetFatoryProfitcenter() &
           " END " &
           " ELSE " &
            "  BEGIN " &
           "     INSERT INTO m_CutCardDCheckItem_t(PartID,Stationid,CheckItemID,Description,ResultValue,Status,UserID,InTime,CheckGroup, " &
           "     LeftTVPN,LeftWirePN1,LeftWirePN2,LeftWirePN3,LeftWirePN4,RightTVPN,RightWirePN1,RightWirePN2,RightWirePN3,RightWirePN4," &
           "     FinishSize,LeftCutSize,RightCutSize,Tolerance,ToleranceRange,Factoryid,Profitcenter,cardType)" &
           " VALUES( " &
           " '" & _cutCardPn & "','" & _stationId & "','" & CheckCode & "'," &
           " N'" & Description & "',N'" & ResultValue & "','1','" & UserId & "',GETDATE(),'" & CheckGroup & "'"
        If type = 0 Then
            sql &= GetInsertSQL(cboLeftTv)
            sql &= GetInsertSQL(cboLeftLine)
            sql &= GetInsertSQL(cboLeftLineTwo)
            sql &= GetInsertSQL(cboLeftLineThree)
            sql &= GetInsertSQL(cboLeftLineFour)
            sql &= ",NULL,NULL,NULL,NULL,NULL"
        Else
            sql &= ",NULL,NULL,NULL,NULL,NULL"
            sql &= GetInsertSQL(cboRightTv)
            sql &= GetInsertSQL(cboRightLine)
            sql &= GetInsertSQL(cboRightLineTwo)
            sql &= GetInsertSQL(cboRightLineThree)
            sql &= GetInsertSQL(cboRightLineFour)
        End If
        sql &= ",NULL,'" & leftFrontSize & "',NULL,NULL,NULL"
        sql &= String.Format(",'{0}','{1}'", factoryID, profitCenter)
        sql &= ", '" & m_strCardType & "'"
        sql &= " )END "
        Return sql
    End Function

    Private Function GetCutSql()
        'As is: RESULTVALUE=(SELECT " & txtCutSize.Text & "), Now:  *
        Dim sql As String = Nothing
        If txtCutSize.Enabled = True AndAlso Not String.IsNullOrEmpty(txtCutSize.Text) Then
            LoadCommonDifference()
            ReCalculateCutSize()
            'ReCalculateCutSize() 'Mark by cq, for special, need exact data, 20151201
            sql &= "IF (SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  1=1 " &
              RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
              RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
              RCardComBusiness.GetWhereAnd("CheckItemID", "LCL") &
              RCardComBusiness.GetFatoryProfitcenter() & ")=1 " &
              " BEGIN  " & _
              " UPDATE m_CutCardDCheckItem_t SET DESCRIPTION=N'裁线尺寸(mm)',RESULTVALUE= '" & txtCutSize.Text &
              "',LEFTCUTSIZE='" & leftFrontSize & "',RIGHTCUTSIZE='" & rightFrontSize & "' " &
              " ,STATUS='1',USERID='" & UserId & "',INTIME=GETDATE(),CHECKGROUP=NULL,FINISHSIZE='" & txtFinishSize.Text &
              "',TOLERANCE='" & txtCD.Text & "',TOLERANCERANGE='" & m_strToleranceRange & "' "
            sql &= GetUpdateSQL(cboLeftTv, "LeftTVPN")
            sql &= GetUpdateSQL(cboLeftLine, "LeftWirePN1")
            sql &= GetUpdateSQL(cboLeftLineTwo, "LeftWirePN2")
            sql &= GetUpdateSQL(cboLeftLineThree, "LeftWirePN3")
            sql &= GetUpdateSQL(cboLeftLineFour, "LeftWirePN4")
            sql &= GetUpdateSQL(cboRightTv, "RightTVPN")
            sql &= GetUpdateSQL(cboRightLine, "RightWirePN1")
            sql &= GetUpdateSQL(cboRightLineTwo, "RightWirePN2")
            sql &= GetUpdateSQL(cboRightLineThree, "RightWirePN3")
            sql &= GetUpdateSQL(cboRightLineFour, "RightWirePN4")
            sql &= "  WHERE 1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", "LCL") &
                RCardComBusiness.GetFatoryProfitcenter() &
            " END " &
            " ELSE " &
            " BEGIN " &
           "     INSERT INTO m_CutCardDCheckItem_t(PartID,Stationid,CheckItemID,Description,ResultValue,Status,UserID,InTime,CheckGroup, " &
           "     LeftTVPN,LeftWirePN1,LeftWirePN2,LeftWirePN3,LeftWirePN4,RightTVPN,RightWirePN1,RightWirePN2,RightWirePN3,RightWirePN4," &
           "     FinishSize,LeftCutSize,RightCutSize,Tolerance,ToleranceRange,Factoryid,Profitcenter,cardType)" &
           " VALUES( " &
           " '" & _cutCardPn & "','" & _stationId & "','LCL'," &
           " N'裁线尺寸(mm)',N'" & txtCutSize.Text & "',1,'" & UserId & "',GETDATE(), NULL"
            sql &= GetInsertSQL(cboLeftTv)
            sql &= GetInsertSQL(cboLeftLine)
            sql &= GetInsertSQL(cboLeftLineTwo)
            sql &= GetInsertSQL(cboLeftLineThree)
            sql &= GetInsertSQL(cboLeftLineFour)
            sql &= GetInsertSQL(cboRightTv)
            sql &= GetInsertSQL(cboRightLine)
            sql &= GetInsertSQL(cboRightLineTwo)
            sql &= GetInsertSQL(cboRightLineThree)
            sql &= GetInsertSQL(cboRightLineFour)
            sql &= GetInsertValue(txtFinishSize.Text)
            sql &= GetInsertValue(leftFrontSize)
            sql &= GetInsertValue(rightFrontSize)
            sql &= GetInsertValue(txtCD.Text)
            sql &= GetInsertValue(m_strToleranceRange)
            sql &= String.Format(",'{0}','{1}'", factoryID, profitCenter)
            sql &= ", '" & m_strCardType & "'"
            sql &= " )END "


            sql &= "IF (SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  1=1 " &
           RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
           RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
           RCardComBusiness.GetWhereAnd("CheckItemID", "LCL") &
           RCardComBusiness.GetFatoryProfitcenter() & ")=1 " &
           " BEGIN  " & _
           " UPDATE m_CutCardDCheckItemPrint_t SET DESCRIPTION=N'裁线尺寸(mm)',RESULTVALUE= '" & txtCutSize.Text &
           "',LEFTCUTSIZE='" & leftFrontSize & "',RIGHTCUTSIZE='" & rightFrontSize & "' " &
           " ,STATUS='1',USERID='" & UserId & "',INTIME=GETDATE(),CHECKGROUP=NULL,FINISHSIZE='" & txtFinishSize.Text &
           "',TOLERANCE='" & txtCD.Text & "',TOLERANCERANGE='" & m_strToleranceRange & "' "
            sql &= GetUpdateSQL(cboLeftTv, "LeftTVPN")
            sql &= GetUpdateSQL(cboLeftLine, "LeftWirePN1")
            sql &= GetUpdateSQL(cboLeftLineTwo, "LeftWirePN2")
            sql &= GetUpdateSQL(cboLeftLineThree, "LeftWirePN3")
            sql &= GetUpdateSQL(cboLeftLineFour, "LeftWirePN4")
            sql &= GetUpdateSQL(cboRightTv, "RightTVPN")
            sql &= GetUpdateSQL(cboRightLine, "RightWirePN1")
            sql &= GetUpdateSQL(cboRightLineTwo, "RightWirePN2")
            sql &= GetUpdateSQL(cboRightLineThree, "RightWirePN3")
            sql &= GetUpdateSQL(cboRightLineFour, "RightWirePN4")
            sql &= "  WHERE 1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetWhereAnd("CheckItemID", "LCL") &
                RCardComBusiness.GetFatoryProfitcenter() &
            " END " &
            " ELSE " &
            " BEGIN " &
           "     INSERT INTO m_CutCardDCheckItemPrint_t(PartID,Stationid,CheckItemID,Description,ResultValue,Status,UserID,InTime,CheckGroup, " &
           "     LeftTVPN,LeftWirePN1,LeftWirePN2,LeftWirePN3,LeftWirePN4,RightTVPN,RightWirePN1,RightWirePN2,RightWirePN3,RightWirePN4," &
           "     FinishSize,LeftCutSize,RightCutSize,Tolerance,ToleranceRange,Factoryid,Profitcenter)" &
           " VALUES( " &
           " '" & _cutCardPn & "','" & _stationId & "','LCL'," &
           " N'裁线尺寸(mm)',N'" & txtCutSize.Text & "',1,'" & UserId & "',GETDATE(), NULL"
            sql &= GetInsertSQL(cboLeftTv)
            sql &= GetInsertSQL(cboLeftLine)
            sql &= GetInsertSQL(cboLeftLineTwo)
            sql &= GetInsertSQL(cboLeftLineThree)
            sql &= GetInsertSQL(cboLeftLineFour)
            sql &= GetInsertSQL(cboRightTv)
            sql &= GetInsertSQL(cboRightLine)
            sql &= GetInsertSQL(cboRightLineTwo)
            sql &= GetInsertSQL(cboRightLineThree)
            sql &= GetInsertSQL(cboRightLineFour)
            sql &= GetInsertValue(txtFinishSize.Text)
            sql &= GetInsertValue(leftFrontSize)
            sql &= GetInsertValue(rightFrontSize)
            sql &= GetInsertValue(txtCD.Text)
            sql &= GetInsertValue(m_strToleranceRange)
            sql &= String.Format(",'{0}','{1}'", factoryID, profitCenter)
            sql &= " )END "
        End If
        Return sql
    End Function

    Private Function SetUpdateSql()
        Dim sql As String = String.Empty
        sql = " IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE 1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                RCardComBusiness.GetFatoryProfitcenter() & " AND STATUS=1),0)=1" &
        " BEGIN " &
        "   UPDATE m_RCardCutD_t SET ProcessStandard=( " &
        "   SELECT (a.DESCRIPTION+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a " &
        "   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID " &
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " & RCardComBusiness.GetFatoryProfitcenter() & _
        "   AND  RESULTVALUE<>'/' AND STATUS=1 ORDER BY a.CHECKGROUP,b.SortSeq " &
        "   FOR XML PATH('')),    " & _
        "  LCLValue=( " & _
        "    SELECT RESULTVALUE FROM m_CutCardDCheckItem_t  a " & _
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'" & _
        "   AND a.CheckItemID='LCL'), " & _
        "   LeftProcessStandard=( " &
        "   SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a " &
        "   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID " &
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " &
        "   AND  RESULTVALUE<>'/' AND STATUS=1 AND a.checkgroup='LH' ORDER BY a.CHECKGROUP,b.SortSeq " &
        "   FOR XML PATH('')),    " & _
        "   RightProcessStandard=( " &
        "   SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a " &
        "   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID " &
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " &
        "   AND  RESULTVALUE<>'/' AND STATUS=1 AND a.checkgroup='RH' ORDER BY a.CHECKGROUP,b.SortSeq " &
        "   FOR XML PATH('')),    " & _
        "   ProcessStandardPrint=isnull(( " &
        "   SELECT (a.DESCRIPTION+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItemPrint_t  a " &
        "   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID " &
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'" & RCardComBusiness.GetFatoryProfitcenter() & _
        "   AND  RESULTVALUE<>'/' AND STATUS=1 ORDER BY a.CHECKGROUP,b.SortSeq " &
        "   FOR XML PATH('')),'')  " & _
        "  WHERE  1=1 " &
            RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
            RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
            RCardComBusiness.GetFatoryProfitcenter() &
        "  UPDATE m_RCardCutM_t SET ModifyTime = getdate() WHERE 1=1 " & _
           RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
           RCardComBusiness.GetFatoryProfitcenter() &
        " END"
        Return sql
    End Function

    Private Function SetUpdateMDSql()
        Dim sql As New StringBuilder

        'add by cq20180126
        sql.Append(" Declare @OldProcessStandardPrint nvarchar(300) , @NewProcessStandardPrint nvarchar(300)")
        sql.Append(" select  @OldProcessStandardPrint= IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint)  FROM m_RCardCutD_t a")
        sql.Append(" WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
        sql.Append("select  @NewProcessStandardPrint= isnull(( SELECT (a.DESCRIPTION+':'+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a ")
        sql.Append("   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  ")
        sql.Append("   AND  isnull(RESULTVALUE,'')<>'/' AND STATUS=1 ORDER BY a.CHECKGROUP,b.SortSeq ")
        sql.Append("   FOR XML PATH('')),'')")
        sql.Append(" If @OldProcessStandardPrint<> @NewProcessStandardPrint  ")
        sql.Append(" Begin")
        sql.Append(" declare @OldUserID varchar(20), @OldModifyTime datetime")
        sql.Append("   SELECT  @OldUserID=USERID ,@OldModifyTime=Intime FROM m_RCardCutD_t WHERE PARTID='" & _cutCardPn & "' and stationid ='" & _stationId & "'")
        sql.Append(" Insert into m_CutCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)")
        sql.Append(" Values('" & _cutCardPn & "','" & _stationId & "',N'工艺标准', @OldUserID, @OldModifyTime,@OldProcessStandardPrint,")
        sql.Append(" '" & VbCommClass.VbCommClass.UseId & "',getdate(), @NewProcessStandardPrint)")
        sql.Append(" End")



        sql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE 1=1 ")
        sql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
        sql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
        sql.Append(RCardComBusiness.GetFatoryProfitcenter() & " AND STATUS=1),0)=1")
        sql.Append(" BEGIN ")
        sql.Append("   UPDATE m_RCardCutD_t SET ProcessStandard=( ")
        sql.Append("  SELECT (a.DESCRIPTION+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a ")
        sql.Append("   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'" & RCardComBusiness.GetFatoryProfitcenter())
        sql.Append("   AND  RESULTVALUE<>'/' AND STATUS=1 ORDER BY a.CHECKGROUP,b.SortSeq ")
        sql.Append("   FOR XML PATH('')), ")
        sql.Append("  LCLValue=( ")
        sql.Append("    SELECT RESULTVALUE FROM m_CutCardDCheckItem_t  a ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  ")
        sql.Append("   AND a.CheckItemID='LCL'), ")
        sql.Append("   LeftProcessStandard=( ")
        sql.Append("    SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a ")
        sql.Append("   left join m_CheckItem_t b on a.checkitemid = b.CheckItemID ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  ")
        sql.Append("   AND  RESULTVALUE<>'/' AND STATUS=1 and a.checkgroup='LH'  ORDER BY a.CHECKGROUP,b.SortSeq ")
        sql.Append("   FOR XML PATH('')), ")
        sql.Append("   RightProcessStandard=( ")
        sql.Append("    SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a ")
        sql.Append("   LEFT JOIN m_CheckItem_t b ON a.checkitemid = b.CheckItemID ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  ")
        sql.Append("   AND  RESULTVALUE<>'/' AND STATUS=1 and a.checkgroup='RH'  ORDER BY a.CHECKGROUP,b.SortSeq ")
        sql.Append("   FOR XML PATH('')), ")
        sql.Append(" ProcessStandardPrint= isnull(( select (a.DESCRIPTION+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItemPrint_t  a ")
        sql.Append("   LEFT JOIN m_CheckItem_t b on a.checkitemid = b.CheckItemID ")
        sql.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'" & RCardComBusiness.GetFatoryProfitcenter())
        sql.Append("   AND  isnull(RESULTVALUE,'')<>'/' AND STATUS=1 ORDER BY a.CHECKGROUP,b.SortSeq ")
        sql.Append("   FOR XML PATH('')),'')")
        sql.Append(" WHERE  1=1 ")
        sql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
        sql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
        sql.Append(RCardComBusiness.GetFatoryProfitcenter())
        sql.Append(" END")
        Return sql.ToString
    End Function


    Private Function LeftProcessStandard() As String

        'first get from m_CutCardDCheckItem_t
        Dim lsSQL As New StringBuilder

        LeftProcessStandard = ""

        lsSQL.Append("   SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a ")
        lsSQL.Append("   LEFT JOIN m_CheckItem_t b ON a.checkitemid = b.CheckItemID ")
        lsSQL.Append("   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  ")
        lsSQL.Append("   AND  RESULTVALUE<>'/' AND STATUS=1 and a.checkgroup='LH'  ORDER BY a.CHECKGROUP,b.SortSeq ")
        lsSQL.Append("   FOR XML PATH('') ")

        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL.ToString)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                LeftProcessStandard = o_dt.Rows(0).Item(0)
            End If
        End Using

        If String.IsNullOrEmpty(LeftProcessStandard) Then
            'get from 
            LeftProcessStandard = GetLeftFromProcessStd()
        End If

    End Function

    Private Function GetLeftFromProcessStd()
        Dim lssql As String = ""
        Dim strProcessStandard As String = ""
        GetLeftFromProcessStd = ""

        lssql = " SELECT ProcessStandard FROM  m_RCardCutD_t" & _
                " Where partid ='" & _cutCardPn & "' and stationid ='" & _stationId & "'" & _
                  RCardComBusiness.GetFatoryProfitcenter()
        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                strProcessStandard = o_dt.Rows(0).Item(0)
                For Each item As String In strProcessStandard.Split(";")

                    If item.IndexOf("左") > 0 Then
                        GetLeftFromProcessStd = GetLeftFromProcessStd + item
                    End If
                Next
            End If
        End Using
    End Function


    Private Function SetDeleteDPartIDSQL() As String
        Dim Sql As String = String.Empty
        Sql &= " DELETE FROM m_CutCardDPart_t  WHERE 1= 1" & _
                 RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                 RCardComBusiness.GetWhereAnd("Stationid", _stationId) & _
                 RCardComBusiness.GetFatoryProfitcenter()
        SetDeleteDPartIDSQL = Sql
        Return SetDeleteDPartIDSQL
    End Function

    Private Function SetInsertSQL(comBox As ComboBox, Optional ByVal strLR As String = "") As String
        Dim Sql As String = String.Empty
        Dim comBoxValue As String = CType(comBox.SelectedItem, ComboxBoxItem).Value
        If Not comBox.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(comBoxValue) Then
            'Mark by cq 20160707
            'Sql &= " DELETE FROM m_CutCardDPart_t  WHERE 1= 1" & _
            '         RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
            '         RCardComBusiness.GetWhereAnd("Stationid", _stationId) & _
            '         RCardComBusiness.GetFatoryProfitcenter()
            Sql &= " IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDPart_t WHERE 1=1 " &
                     RCardComBusiness.GetWhereAnd("EWPartNumber", comBoxValue) &
                     RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                     RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                     RCardComBusiness.GetFatoryProfitcenter() & "),0)<>1" &
                    " BEGIN INSERT INTO m_CutCardDPart_t(PartID,Stationid,EWPartNumber,UserID,InTime,Factoryid,Profitcenter,EWPNLRDirection,CardType,DrawingVer) VALUES(" &
                    " '" & _cutCardPn & "','" & _stationId & "','" & comBoxValue & "','" & UserId & "', " &
                    " GETDATE(),'" & factoryID & "','" & profitCenter & "','" & strLR & "','" & m_strCardType & "','" & _cutCardVersion & "') END " & _
                    " Else BEGIN Update m_CutCardDPart_t SET EWPNLRDirection='" & strLR & "' " & _
                    " WHERE PartID='" & _cutCardPn & "' AND EWPartNumber='" & comBoxValue & "' and " & _
                    " Factoryid ='" & factoryID & "' AND Profitcenter='" & profitCenter & "' END "
        End If
        SetInsertSQL = Sql
    End Function
    Private Function SetInsertDZSQL(comBox As ComboBox, ByVal strLRValue As String) As String
        Dim Sql As String = String.Empty
        Dim comBoxValue As String = CType(comBox.SelectedItem, ComboxBoxItem).Value
        If Not comBox.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(comBoxValue) Then
            'Sql &= "DELETE FROM m_CutCardDPart_t  WHERE 1= 1 AND EwPNLRdirection='" & strLR & "'" & _
            '         RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
            '         RCardComBusiness.GetWhereAnd("Stationid", _stationId) & _
            '         RCardComBusiness.GetFatoryProfitcenter()
            Sql &= " IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDPart_t WHERE 1=1 " &
                     RCardComBusiness.GetWhereAnd("EWPartNumber", comBoxValue) &
                     RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                     RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                     RCardComBusiness.GetFatoryProfitcenter() & "),0)<>1" &
                    " BEGIN INSERT INTO m_CutCardDPart_t(PartID,Stationid,EWPartNumber,UserID,InTime,Factoryid,Profitcenter,EWPNLRDirection,CardType,DrawingVer) VALUES(" &
                    " '" & _cutCardPn & "','" & _stationId & "','" & comBoxValue & "','" & UserId & "', " &
                    " GETDATE(),'" & factoryID & "','" & profitCenter & "','" & strLRValue & "','" & m_strCardType & "','" & _cutCardVersion & "') END " & _
                    " Else begin Update m_CutCardDPart_t set EWPNLRDirection='" & strLRValue & "' " & _
                    " WHERE PartID='" & _cutCardPn & "' and EWPartNumber='" & comBoxValue & "' and " & _
                    " Factoryid ='" & factoryID & "' and Profitcenter='" & profitCenter & "' end "
        End If
        SetInsertDZSQL = Sql
    End Function

    Private Function SetInsertEquPNSQL(ByVal parEquPN As String) As String
        Dim Sql As String = String.Empty
        Sql &= " IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDPart_t WHERE 1=1 " &
                    RCardComBusiness.GetWhereAndN("EWPartNumber", parEquPN) &
                    RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) &
                    RCardComBusiness.GetWhereAnd("Stationid", _stationId) &
                    RCardComBusiness.GetFatoryProfitcenter() & "),0)<>1" &
                   " BEGIN INSERT INTO m_CutCardDPart_t(PartID,Stationid,EWPartNumber,UserID,InTime,Factoryid,Profitcenter,EWPNType,CardType,DrawingVer) VALUES(" &
                   " '" & _cutCardPn & "','" & _stationId & "','" & parEquPN & "','" & UserId & "', " &
                   " GETDATE(),'" & factoryID & "','" & profitCenter & "','E','" & m_strCardType & "','" & _cutCardVersion & "') END "
        SetInsertEquPNSQL = Sql
    End Function

    Private Function GetPnSqlByAdd() As String
        Dim sql As String = Nothing
        Dim strDirection As String = String.Empty

        'Add by cq 20160707
        If (IsLeftTvSelected() AndAlso IsAnyLeftLineSelected()) OrElse (IsRightTvSelected() AndAlso IsAnyRightLineSelected()) Then
            sql &= SetDeleteDPartIDSQL()
        End If

        'Add 区分端子 左和右
        If IsLeftTvSelected() AndAlso IsAnyLeftLineSelected() Then
            sql &= SetInsertSQL(cboLeftLine)
            If Not IsNothing(cboLeftLineTwo.SelectedItem) Then
                sql &= SetInsertSQL(cboLeftLineTwo)
            End If
            If Not IsNothing(cboLeftLineThree.SelectedItem) Then
                sql &= SetInsertSQL(cboLeftLineThree)
            End If

            If Not IsNothing(cboLeftLineFour.SelectedItem) Then
                sql &= SetInsertSQL(cboLeftLineFour)
            End If

            sql &= SetInsertDZSQL(cboLeftTv, "L")
            If m_strLeftEquPN <> String.Empty Then
                sql &= SetInsertEquPNSQL(m_strLeftEquPN)
            End If

            If m_strLeftDM <> String.Empty Then 'Add by cq20160323
                sql &= SetInsertEquPNSQL(m_strLeftDM)
            End If
        End If
        If IsRightTvSelected() AndAlso IsAnyRightLineSelected() Then
            sql &= SetInsertSQL(cboRightLine)
            If Not IsNothing(cboRightLineTwo.SelectedItem) Then
                sql &= SetInsertSQL(cboRightLineTwo)
            End If
            If Not IsNothing(cboRightLineThree.SelectedItem) Then
                sql &= SetInsertSQL(cboRightLineThree)
            End If
            If Not IsNothing(cboRightLineFour.SelectedItem) Then
                sql &= SetInsertSQL(cboRightLineFour)
            End If
            If cboLeftTv.SelectedIndex = cboRightTv.SelectedIndex Then
                'Add by cq 20160706, 左右端子相同时，不显示 (右端)
                sql &= SetInsertDZSQL(cboRightTv, "")
            Else
                sql &= SetInsertDZSQL(cboRightTv, "R")
            End If
            If m_strRightEquPN <> String.Empty Then 'Add by cq20151231
                sql &= SetInsertEquPNSQL(m_strRightEquPN)
            End If

            If m_strRightDM <> String.Empty Then 'Add by cq20160323
                sql &= SetInsertEquPNSQL(m_strRightDM)
            End If
        End If
        Return sql
    End Function

    Private Function GetProcessStand()
        'cq 20170307 m_CutCardDCheckItem_t, ResultValue<>''==> m_CutCardDCheckItemPrint_t, ResultValue<>'/'
        Dim sql As String = " SELECT  (a.Description+'='+ResultValue)+';'+CHAR(10) " & _
                            " FROM m_CutCardDCheckItemPrint_t a" &
                            " LEFT JOIN m_CheckItem_t b ON a.checkitemid = b.CheckItemID" & _
                            " WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'" & RCardComBusiness.GetFatoryProfitcenter() & _
                            " AND  ResultValue<>'/' AND STATUS='1' ORDER BY a.CHECKGROUP,b.SortSeq " &
                            " FOR XML PATH('')"
        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Function GetLeftProcessStand()
        Dim sql As String = " SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a " &
        "   LEFT JOIN m_CheckItem_t b on a.checkitemid = b.CheckItemID " & _
        "   WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " & RCardComBusiness.GetFatoryProfitcenter() & _
        "   AND  RESULTVALUE<>'/' AND STATUS=1 AND a.checkgroup='LH' ORDER BY a.CHECKGROUP,b.SortSeq " & _
        "   FOR XML PATH('')"
  
        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Function GetRightProcessStand()
        Dim sql As String = " SELECT (b.DESCCut+'='+RESULTVALUE)+'; ' FROM m_CutCardDCheckItem_t  a " &
                            "  LEFT JOIN m_CheckItem_t b on a.checkitemid = b.CheckItemID " & _
                            " WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " & RCardComBusiness.GetFatoryProfitcenter() & _
                            "  AND  RESULTVALUE<>'/' AND STATUS=1 AND a.checkgroup='RH' ORDER BY a.CHECKGROUP,b.SortSeq " & _
                            "  FOR XML PATH('') "

        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Function GetLCLValue()
        Dim sql As String = " SELECT RESULTVALUE FROM m_CutCardDCheckItem_t  a " &
                            " WHERE PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'  " & _
                            "  AND  a.CheckItemID='LCL' "

        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return ""
            End If
        End Using
    End Function

#End Region

    Private Function GetUpdateSQL(combox As ComboBox, tableName As String) As String
        Dim sql As String
        If Not combox.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(combox.SelectedItem, ComboxBoxItem).Value.ToString) Then
            sql = String.Format(" ,{0}='{1}' ", tableName, CType(combox.SelectedItem, ComboxBoxItem).Value.ToString)
        Else
            sql = String.Format(" ,{0}=NULL", tableName)
        End If
        GetUpdateSQL = sql
    End Function

    Private Function GetInsertSQL(combox As ComboBox) As String
        Dim sql As String
        If Not combox.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(combox.SelectedItem, ComboxBoxItem).Value.ToString) Then
            sql = String.Format(" ,'{0}' ", CType(combox.SelectedItem, ComboxBoxItem).Value.ToString)
        Else
            sql = " ,NULL"
        End If
        GetInsertSQL = sql
    End Function

    Private Function GetInsertSQLG(combox As ComboBox) As String
        Dim sql As String
        If Not combox.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(combox.SelectedItem, ComboxBoxItem).Value.ToString) Then
            sql = String.Format(" '{0}' ", CType(combox.SelectedItem, ComboxBoxItem).Value.ToString)
        Else
            sql = " NULL"
        End If
        GetInsertSQLG = sql
    End Function

    Private Function GetInsertValue(value As String) As String
        Dim result As String = String.Format(",'{0}'", value)
        GetInsertValue = result
    End Function
#End Region

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

    Private Sub GetLeftProcessParametersByFormLoad()
        Dim leftTvWhere As String = Nothing
        Dim leftLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False
        Dim LeftLineValue As String = ""
        Dim Sql As String = "SELECT BRASSHEIGHT 'LCH',BRASSWIDTH 'LCW',DRAWFORCE 'LDF'," &
                            " PEELSIZE 'LPL',CUTSIZE 'LCL',FRONTSIZE,EquPN,CutPN FROM m_RCardProParam_t WHERE 1=1 "

        If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            leftTvWhere &= " AND TVPN='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If

        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            LeftLineValue = CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value
            leftLineWhere &= " AND ( WirePN='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= ")" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN IS NULL "
            LeftLineValue = ""
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            'Modify by cq 20161027
            leftLineWhere &= " AND ( WirePN='" & LeftLineValue & "'" & vbNewLine
            leftLineWhere &= " AND WirePN2='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN3='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN4='" & CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN2 IS NULL "
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WirePN='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN2='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN3='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN4='" & CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN3 IS NULL "
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WirePN='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN2='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN3='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN4='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN4 IS NULL "
        End If
        Sql &= "  AND STATUS='1' "
        If String.IsNullOrEmpty(leftTvWhere) OrElse Not isLineSelected Then
            leftFrontSize = ""
            'Add by cq 20160726
            If m_blnChangeTV Then
                ClearLeftProcessParameters()
            End If
        Else
            Using dt As DataTable = RCardComBusiness.GetDataTable(Sql & leftTvWhere & leftLineWhere)
                If dt.Rows.Count > 0 Then
                    leftFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                    m_strLeftEquPN = dt.Rows(0)("EquPN").ToString
                    m_strLeftDM = dt.Rows(0)("CUTPN").ToString
                Else
                    leftFrontSize = ""
                    'mark by cq 20160923
                    ' ClearLeftProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub GetLeftProcessParameters()
        Dim leftTvWhere As String = Nothing
        Dim leftLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False

        Dim Sql As String = "SELECT BRASSHEIGHT 'LCH',BRASSWIDTH 'LCW',DRAWFORCE 'LDF'," & _
                            " PEELSIZE 'LPL',CUTSIZE 'LCL',FRONTSIZE, EquPN,CutPN, outdaoheight 'LCH2', OutDaoWidth 'LCW2'" & _
                            " FROM m_RCardProParam_t WHERE 1=1 "

        If Not cboLeftTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value) Then
            leftTvWhere &= " AND TVPN='" & CType(cboLeftTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If

        If Not cboLeftLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND  WirePN='" & CType(cboLeftLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN IS NULL "
        End If
        If Not cboLeftLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            'Modify by cq 20170809
            leftLineWhere &= " AND WirePN2 IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN2 IS NULL "
        End If
        If Not cboLeftLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineThree.SelectedItem, ComboxBoxItem).Value) Then
            'Modify by cq20170803
            leftLineWhere &= " AND WirePN3 IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN3 IS NULL "
        End If
        If Not cboLeftLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value) Then
            leftLineWhere &= " AND ( WirePN='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN2='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN3='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            leftLineWhere &= " OR WirePN4='" & CType(cboLeftLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            leftLineWhere &= " AND WirePN4 IN(" & GetLeftPns() & ")"
            isLineSelected = True
        Else
            leftLineWhere &= " AND WirePN4 IS NULL "
        End If
        Sql &= "  AND STATUS='1' "
        If String.IsNullOrEmpty(leftTvWhere) OrElse Not isLineSelected Then
            leftFrontSize = ""
            'mark by cq 20160725, add OrElse m_blnChangeWire, cq20170809
            If m_blnChangeTV OrElse m_blnChangeWire Then
                ClearLeftProcessParameters()
            End If
        Else
            Using dt As DataTable = RCardComBusiness.GetDataTable(Sql & leftTvWhere & leftLineWhere)
                If dt.Rows.Count > 0 Then
                    For index As Integer = 0 To dgvLeft.Rows.Count - 1
                        dgvLeft.Rows(index).Cells(ProcessGrid.ResultValue).Value = dt.Rows(0)(dgvLeft.Rows(index).Cells(ProcessGrid.CheckCode).Value).ToString
                        'If 1 Then

                        'End If
                    Next
                    leftFrontSize = dt.Rows(0)("FRONTSIZE").ToString
                    m_strLeftEquPN = dt.Rows(0)("EquPN").ToString
                    m_strLeftDM = dt.Rows(0)("CUTPN").ToString  'Add by CQ 20160323
                Else
                    leftFrontSize = ""
                    'mark by cq 20160923,readd by cq20170809
                    ClearLeftProcessParameters()
                End If
            End Using
        End If
    End Sub

    'Private Function GetLeftHWGC(ByVal strCode As String, ByVal strValue As String) As String

    '    Select Case strCode
    '        Case "LCH"
    '            GetLeftHWGC = GetH1(strValue)
    '        Case ""

    '        Case Else
    '            GetLeftHWGC = ""
    '    End Select
    'End Function

    Private Function GetH1(ByVal strValue As String) As String
        Dim lsSQL As New StringBuilder
        lsSQL.Append(" SELECT TOP 1  ToleranceRange  FROM m_RCardAllowanceParamHW_t ")
        lsSQL.Append(" WHERE ( RangeMin<= " & strValue & " AND RangeMax>=" & strValue & "")
        lsSQL.Append(" OR(RangeMin<=" & txtFinishSize.Text & " AND ( ISNULL(RangeMax,'')='')")
        Using o_dt As DataTable = RCardComBusiness.GetDataTable(lsSQL.ToString)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetH1 = o_dt.Rows(0).Item(0)
            Else
                GetH1 = ""
            End If
        End Using
    End Function

    Private Sub ClearLeftProcessParameters()
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "cboRightTv_SelectedIndexChanged", "RCard")
            MessageUtils.ShowError(ex.Message)
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "cboRightLine_SelectedIndexChanged", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineTwo.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "Two_SelectedIndexChanged", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineThree_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineThree.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "Three_SelectedIndexChanged", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub cboRightLineFour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightLineFour.SelectedIndexChanged
        Try
            If isFormLoad Then Exit Sub
            GetRightProcessParameters()
            ResetCutSize()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "RightLineFour_SelectedIndexChanged", "RCard")
            MessageUtils.ShowError(ex.Message)
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

    Private Sub GetRightProcessParametersByFormLoad()
        Dim rightTvWhere As String = Nothing
        Dim rightLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False

        'CUTSIZE 'RPL' ==> CUTSIZE 'RCL, CQ
        Dim Sql As String = "SELECT BRASSHEIGHT 'RCH',BRASSWIDTH 'RCW',DRAWFORCE 'RDF'," &
                   " PEELSIZE 'RPL',CUTSIZE 'RCL',FRONTSIZE " & _
                   " FROM m_RCardProParam_t WHERE 1=1 " &
                   RCardComBusiness.GetFatoryProfitcenter() & vbNewLine

        If Not cboRightTv.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) Then
            rightTvWhere = " AND TVPN='" & CType(cboRightTv.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
        End If
        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN IS NULL "
        End If

        'cq 20160830
        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " AND WirePN2='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN2 IS NULL "
        End If

        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN2='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN3 IS NULL "
        End If

        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN2='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN4 IS NULL "
        End If
        Sql &= " AND STATUS='1' "
        If String.IsNullOrEmpty(rightTvWhere) OrElse Not isLineSelected Then
            rightFrontSize = ""
            'mark by cq 20160725
            ' ResetRightProcessParameters()
        Else
            Using dt As DataTable = RCardComBusiness.GetDataTable(Sql & rightTvWhere & rightLineWhere)
                If dt.Rows.Count > 0 Then
                    rightFrontSize = dt.Rows(0)("FrontSize").ToString
                Else
                    rightFrontSize = ""
                    'Mark by cq 20170227
                    ' ResetRightProcessParameters()
                End If
            End Using
        End If
    End Sub

    Private Sub GetRightProcessParameters()
        Dim rightTvWhere As String = Nothing
        Dim rightLineWhere As String = Nothing
        Dim isLineSelected As Boolean = False
        Dim Sql As String = "SELECT BrassHeight 'RCH',BrassWidth 'RCW',DrawForce 'RDF'," &
                   " PeelSize 'RPL',CutSize 'RPL',FrontSize,EquPN,CutPN, outdaoheight 'RCH2',  OutDaoWidth 'RCW2'" & _
                   " FROM m_RCardProParam_t WHERE 1=1" &
                   RCardComBusiness.GetFatoryProfitcenter() & vbNewLine

        rightTvWhere = RCardComBusiness.GetWhereAnd("TVPN", CType(cboRightTv.SelectedItem, ComboxBoxItem).Value) 'cboRightLine

        If Not cboRightLine.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLine.SelectedItem, ComboxBoxItem).Value) Then
            'Modify by cq 20161019
            rightLineWhere &= " AND  WirePN='" & CType(cboRightLine.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN IS NULL "
        End If

        If Not cboRightLineTwo.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN2='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineTwo.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WirePN2 IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN2 IS NULL "
        End If

        'Modify by cq 20160324, As is: WirePN=2 
        If Not cboRightLineThree.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN2='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineThree.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WirePN3 IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN3 IS NULL "
        End If

        If Not cboRightLineFour.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value) Then
            rightLineWhere &= " AND ( WirePN='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN2='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN3='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "'" & vbNewLine
            rightLineWhere &= " OR WirePN4='" & CType(cboRightLineFour.SelectedItem, ComboxBoxItem).Value & "')" & vbNewLine
            rightLineWhere &= " AND WirePN4 IN(" & GetRightPns() & ")" & vbNewLine
            isLineSelected = True
        Else
            rightLineWhere &= " AND WirePN4 IS NULL "
        End If
        Sql &= " AND status='1' "
        If String.IsNullOrEmpty(rightTvWhere) OrElse Not isLineSelected Then
            rightFrontSize = ""
            ' ResetRightProcessParameters()
        Else
            Using dt As DataTable = RCardComBusiness.GetDataTable(Sql & rightTvWhere & rightLineWhere)
                If dt.Rows.Count > 0 Then
                    For index As Integer = 0 To dgvRight.Rows.Count - 1
                        dgvRight.Rows(index).Cells(ProcessGrid.ResultValue).Value = dt.Rows(0)(dgvRight.Rows(index).Cells(ProcessGrid.CheckCode).Value).ToString
                    Next
                    rightFrontSize = dt.Rows(0)("FrontSize").ToString
                    m_strRightEquPN = dt.Rows(0)("EquPN").ToString
                    m_strRightDM = dt.Rows(0)("CutPN").ToString
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
                'Modify by cq 20170322
                txtQDCutSize.Text = ""  '  "-0"
            End If
        End If
    End Sub

    Private Function ResetCutSizeAndCheck() As Boolean
        If txtCutSize.Enabled = True Then
            If Not String.IsNullOrEmpty(leftFrontSize) AndAlso Not String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + leftFrontSize + "-" + rightFrontSize
            ElseIf Not String.IsNullOrEmpty(leftFrontSize) AndAlso String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + leftFrontSize
            ElseIf String.IsNullOrEmpty(leftFrontSize) AndAlso Not String.IsNullOrEmpty(rightFrontSize) Then
                txtQDCutSize.Text = "-" + rightFrontSize
            Else
                txtQDCutSize.Text = ""
            End If

            If String.IsNullOrEmpty(leftFrontSize) Then
                MessageUtils.ShowWarning("请检查左边前端尺寸是否维护！")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub LoadVar()
        Dim Sql As String = "SELECT ISNULL(VariableName1,'') as VariableName1,isnull(VariableValue1,'') as VariableValue1 ," & _
                 " ISNULL(VariableName2,'') as VariableName2 ,isnull(VariableValue2,'') as VariableValue2 " &
                 "  FROM m_RCardD_t WHERE 1=1" & _
                 RCardComBusiness.GetFatoryProfitcenter() & _
                 " and PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "'"
        Using dt As DataTable = RCardComBusiness.GetDataTable(Sql)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                Me.txtVarName1.Text = dt.Rows(0).Item("VariableName1")
                Me.txtValue1.Text = IIf(Val(dt.Rows(0).Item("VariableValue1")) = 0, "", dt.Rows(0).Item("VariableValue1"))
                Me.txtVarName2.Text = dt.Rows(0).Item("VariableName2")
                Me.txtValue2.Text = IIf(Val(dt.Rows(0).Item("VariableValue2")) = 0, "", dt.Rows(0).Item("VariableValue2"))
            End If
        End Using
    End Sub


    Private Function GetAddProcessStand() As String
        Dim stand As String = Nothing

        For Each dr As DataGridViewRow In dgvLeft.Rows
            stand &= " " + dr.Cells(ProcessGrid.Description).Value.ToString + ":" + dr.Cells(ProcessGrid.ResultValue).Value.ToString + ";"
        Next

        For Each dr As DataGridViewRow In dgvRight.Rows
            stand &= " " + dr.Cells(ProcessGrid.Description).Value.ToString + ":" + dr.Cells(ProcessGrid.ResultValue).Value.ToString + ";"
        Next

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
        Dim sql As String = "SELECT TOP 1 CutSizeMin, ToleranceRange  FROM m_RCardAllowanceParam_t " &
        " WHERE (FinishSizeRangeMin<=" & txtFinishSize.Text & " AND  FinishSizeRangeMax>=" & txtFinishSize.Text & ")" &
        " OR(FinishSizeRangeMin<=" & txtFinishSize.Text & " AND (FinishSizeRangeMax IS NULL OR FinishSizeRangeMax=''))"
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            Dim result = dt.Rows(0)(0).ToString

            m_strToleranceRange = dt.Rows(0)(1).ToString  '±1
            If result.Contains("L") Then
                txtCD.Text = result.Replace("L", txtFinishSize.Text)
                m_strToleranceRange = m_strToleranceRange.Replace("±L", "")
                Call CalculateTolerance(m_strToleranceRange)  '±L*0.002
            Else
                txtCD.Text = result
            End If
        Else
            txtCD.Text = "+0"
            m_strToleranceRange = "±0"
        End If
    End Sub

    Private Sub CalculateTolerance(ByVal parToleranceRange As String)
        Using dt As DataTable = RCardComBusiness.GetDataTable("SELECT  FLOOR(" & txtFinishSize.Text & parToleranceRange & ")")
            If dt.Rows.Count > 0 Then
                m_strToleranceRange = "±" + dt.Rows(0)(0).ToString  '20
            Else
                m_strToleranceRange = ""
            End If
        End Using
    End Sub

    Private Sub ReCalculateCutSize()
        Dim strCDSizeSign As String = ""
        Try
            If String.IsNullOrEmpty(txtFinishSize.Text) Or txtFinishSize.Text = "0" Then Exit Sub

            'SELECT 180-0± FLOOR(0) '加减符号,'(5), (±5)，-5, +5
            If Me.txtCD.Text.Substring(0, 1) = "±" Then
                strCDSizeSign = "+"
            Else
                If Val(Me.txtCD.Text.Substring(0, 1)) > 0 Then '(5)
                    strCDSizeSign = "+"
                    txtCD.Text = "+" & txtCD.Text
                Else
                    strCDSizeSign = Me.txtCD.Text.Substring(0, 1)
                End If
            End If

            txtQDCutSize.Text = IIf(Val(txtQDCutSize.Text) > 0, "+" & CStr(Val(txtQDCutSize.Text)), txtQDCutSize.Text)

            Using dt As DataTable = RCardComBusiness.GetDataTable("SELECT " & txtFinishSize.Text & txtQDCutSize.Text.Trim.Replace("--", "+").Replace("-+", "-").Replace("+-", "-").Replace("++", "+") & strCDSizeSign & " FLOOR(" & txtCD.Text.Substring(1) & ")")
                If dt.Rows.Count > 0 Then
                    txtCutSize.Text = dt.Rows(0)(0).ToString
                Else
                    txtCutSize.Text = 0
                End If
            End Using

            txtCutSize.Text = txtCutSize.Text & m_strToleranceRange
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "ReCalculateCutSize", "RCard")
            MessageUtils.ShowError(ex.Message)
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardBodyModify", "dgvRight_CellEnter", "RCard")
            MessageUtils.ShowError(ex.Message)
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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "dgvLeft_CellEnter", "RCard")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub UpdateData()
        Dim updateSql As New StringBuilder
        Dim o_blnSame As Boolean = False, o_strResultValue As String = "", o_strDes As String = ""
        Try
            If (Not String.IsNullOrEmpty(Me.cboLeftTv.Text)) AndAlso (Me.cboLeftTv.Text = Me.cboRightTv.Text) Then
                o_blnSame = True
            End If

            If dgvLeft.Rows.Count > 0 Then
                'add by cq 20170728, for clear the not use check item, not only the current checkitem, include the before check item.
                'Modify by cq20170821, RH==>LH
                updateSql.Append(" DELETE FROM  m_CutCardDCheckItemPrint_t  ")
                updateSql.Append(" WHERE 1=1 AND CheckGroup ='LH'" & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())

                For Each dr As DataGridViewRow In dgvLeft.Rows
                    If o_blnSame Then
                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  PartID='" & _cutCardPn & "' ")
                        updateSql.Append("   AND Stationid='" & _stationId & "'" & RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value) & RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItem_t SET CARDTYPE='" & m_strCardType & "',")
                        updateSql.Append("  RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                        updateSql.Append(" WHERE 1=1 " & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItem_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append("  [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append(" [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter],cardType) ")
                        updateSql.Append("  values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append("  N'" & dr.Cells(ProcessGrid.Description).Value & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                        updateSql.Append("  '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),")
                        'updateSql.Append(" null,null,null,null,null,|null,null,null,null,null,null,")
                        updateSql.Append(" " & GetInsertSQLG(cboLeftTv) & "," & GetInsertSQLG(cboLeftLine) & "," & GetInsertSQLG(cboLeftLineTwo) & "," & GetInsertSQLG(cboLeftLineThree) & "," & GetInsertSQLG(cboLeftLineFour) & ",null,null,null,null,null,null,")
                        updateSql.Append("  null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & m_strCardType & "')")

                        'add by cq20170306, need combin left and right checkitem
                        o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                        If String.IsNullOrEmpty(o_strResultValue) OrElse o_strResultValue = "\" Then
                            o_strResultValue = "/"
                        End If

                        'cq 20170316, not 左脱皮, 进行合并
                        If dr.Cells(ProcessGrid.CheckCode).Value <> "LPL" Then
                            o_strDes = dr.Cells(ProcessGrid.Description).Value.ToString.Replace("左", "") + "(" + dr.Cells(ProcessGrid.Unit).Value + ")"
                            updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' ")
                            updateSql.Append("   AND Stationid='" & _stationId & "'" & RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString.Replace("L", "")) & RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                            updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET ")
                            updateSql.Append("    RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                            updateSql.Append(" WHERE 1=1 " & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString.Replace("L", "")))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                            updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                            updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                            updateSql.Append("  [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                            updateSql.Append(" [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                            updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                            updateSql.Append("  VALUES ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value.ToString.Replace("L", "") & "',")
                            updateSql.Append("  N'" & o_strDes & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                            updateSql.Append("  '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),")
                            '[LeftTVPN],[LeftWirePN1],
                            updateSql.Append(" " & GetInsertSQLG(cboLeftTv) & "," & GetInsertSQLG(cboLeftLine) & "," & GetInsertSQLG(cboLeftLineTwo) & "," & GetInsertSQLG(cboLeftLineThree) & "," & GetInsertSQLG(cboLeftLineFour) & ",null,null,null,null,null,null,")
                            updateSql.Append("  null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")
                        Else
                            o_strDes = dr.Cells(ProcessGrid.Description).Value.ToString + "(" + dr.Cells(ProcessGrid.Unit).Value + ")"
                            updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' ")
                            updateSql.Append("   AND Stationid='" & _stationId & "'" & RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value) & RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                            updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET ")
                            updateSql.Append("    RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                            updateSql.Append(" WHERE 1=1 " & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                            updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                            updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                            updateSql.Append("  [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                            updateSql.Append(" [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                            updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                            updateSql.Append("  values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                            updateSql.Append("  N'" & o_strDes & "' ,'" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                            updateSql.Append("  '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),")
                            updateSql.Append(" " & GetInsertSQLG(cboLeftTv) & "," & GetInsertSQLG(cboLeftLine) & "," & GetInsertSQLG(cboLeftLineTwo) & "," & GetInsertSQLG(cboLeftLineThree) & "," & GetInsertSQLG(cboLeftLineFour) & ",null,null,null,null,null,null,")
                            updateSql.Append("  null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")
                        End If
                    Else
                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  PartID='" & _cutCardPn & "'")
                        updateSql.Append("   AND Stationid='" & _stationId & "'" & RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value) & RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItem_t SET cardType='" & m_strCardType & "',")
                        updateSql.Append("  RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "'")
                        updateSql.Append(" WHERE 1=1 " & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItem_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append("  [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append(" [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter],cardType) ")
                        updateSql.Append("  values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append("  N'" & dr.Cells(ProcessGrid.Description).Value & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                        updateSql.Append("  '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),")
                        updateSql.Append(" " & GetInsertSQLG(cboLeftTv) & "," & GetInsertSQLG(cboLeftLine) & "," & GetInsertSQLG(cboLeftLineTwo) & "," & GetInsertSQLG(cboLeftLineThree) & "," & GetInsertSQLG(cboLeftLineFour) & ",null,null,null,null,null,null,")
                        updateSql.Append("  null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & m_strCardType & "')")

                        o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                        If String.IsNullOrEmpty(o_strResultValue) OrElse o_strResultValue = "\" Then
                            o_strResultValue = "/"
                        End If

                        o_strDes = dr.Cells(ProcessGrid.Description).Value.ToString + "(" + dr.Cells(ProcessGrid.Unit).Value + ")"

                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' ")
                        updateSql.Append("   AND Stationid='" & _stationId & "'" & RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value) & RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET ")
                        updateSql.Append("    RESULTVALUE='" & o_strResultValue & "' ")
                        updateSql.Append(" WHERE 1=1 " & RCardComBusiness.GetWhereAnd("PartID", _cutCardPn) & RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append("  [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append(" [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                        updateSql.Append("  values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append("  N'" & o_strDes & "','" & o_strResultValue & "',")
                        updateSql.Append("  '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),")
                        'Modify by cq20170726
                        updateSql.Append(" " & GetInsertSQLG(cboLeftTv) & "," & GetInsertSQLG(cboLeftLine) & "," & GetInsertSQLG(cboLeftLineTwo) & "," & GetInsertSQLG(cboLeftLineThree) & "," & GetInsertSQLG(cboLeftLineFour) & ",null,null,null,null,null,null,")
                        updateSql.Append("  null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")
                    End If
                Next
            End If

            If dgvRight.Rows.Count > 0 Then
                If o_blnSame Then

                    For Each dr As DataGridViewRow In dgvRight.Rows
                        o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItem_t SET RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                        updateSql.Append("  WHERE 1=1 ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItem_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append(" [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append("  [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter],CardType) ")
                        updateSql.Append(" values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append(" N'" & dr.Cells(ProcessGrid.Description).Value & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                        updateSql.Append(" '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),null,null,")
                        ' updateSql.Append(" null,null,|null,null,null,null,null,|null,null,null,null,")
                        updateSql.Append(" null,null,null, " & GetInsertSQLG(cboRightTv) & "," & GetInsertSQLG(cboRightLine) & " ")
                        updateSql.Append(" ," & GetInsertSQLG(cboRightLineTwo) & "," & GetInsertSQLG(cboRightLineThree) & "," & GetInsertSQLG(cboRightLineFour) & ",null,")
                        updateSql.Append(" null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & m_strCardType & "')")
                    Next

                    'Add by cq 20171011 ,First delete, then update or insert
                    updateSql.Append(" Delete from  m_CutCardDCheckItemPrint_t ")
                    updateSql.Append("  WHERE 1=1 AND  CheckGroup ='RH'  ")
                    updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                    updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                    updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())

                    'clear right checkitem, cq20170308
                    For Each dr As DataGridViewRow In dgvRight.Rows
                        o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                        If String.IsNullOrEmpty(o_strResultValue) OrElse o_strResultValue = "\" Then
                            o_strResultValue = "/"
                        End If

                        If dr.Cells(ProcessGrid.CheckCode).Value <> "RPL" Then
                            'add by cq20170911, 进行合并： RCH ==》CH, 20171011
                            updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value.ToString.Replace("R", "").Trim))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                            updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                            updateSql.Append("  WHERE 1=1 ")
                            updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                            updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                            updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                            updateSql.Append(" [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                            updateSql.Append("  [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                            updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                            updateSql.Append(" values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                            updateSql.Append(" N'" & dr.Cells(ProcessGrid.Description).Value & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                            updateSql.Append(" '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),null,null,")
                            ' updateSql.Append(" null,null,|null,null,null,null,null,|null,null,null,null,")
                            updateSql.Append(" null,null,null, " & GetInsertSQLG(cboRightTv) & "," & GetInsertSQLG(cboRightLine) & " ")
                            updateSql.Append(" ," & GetInsertSQLG(cboRightLineTwo) & "," & GetInsertSQLG(cboRightLineThree) & "," & GetInsertSQLG(cboRightLineFour) & ",null,")
                            updateSql.Append(" null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")

                        Else
                            o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                            If String.IsNullOrEmpty(o_strResultValue) OrElse o_strResultValue = "\" Then
                                o_strResultValue = "/"
                            End If

                            o_strDes = dr.Cells(ProcessGrid.Description).Value.ToString + "(" + dr.Cells(ProcessGrid.Unit).Value + ")"

                            updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                            updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET RESULTVALUE='" & o_strResultValue & "' ")
                            updateSql.Append("  WHERE 1=1 ")
                            updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                            updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                            updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                            updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                            updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                            updateSql.Append(" [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                            updateSql.Append("  [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                            updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                            updateSql.Append(" values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                            updateSql.Append(" N'" & o_strDes & "','" & o_strResultValue & "',")
                            updateSql.Append(" '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),null,null,")
                            updateSql.Append(" null,null,null, " & GetInsertSQLG(cboRightTv) & "," & GetInsertSQLG(cboRightLine) & " ")
                            updateSql.Append(" ," & GetInsertSQLG(cboRightLineTwo) & "," & GetInsertSQLG(cboRightLineThree) & "," & GetInsertSQLG(cboRightLineFour) & ",null,")
                            updateSql.Append(" null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")
                        End If
                    Next
                Else

                    'Add by cq 20170703 ,First delete, then update or insert,20170704 add checkgroup=RH
                    updateSql.Append(" Delete from  m_CutCardDCheckItemPrint_t ")
                    updateSql.Append("  WHERE 1=1 AND  CheckGroup ='RH'  ")
                    updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                    updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                    updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())

                    For Each dr As DataGridViewRow In dgvRight.Rows
                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItem_t WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItem_t SET cardType='" & m_strCardType & "',RESULTVALUE='" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "' ")
                        updateSql.Append("  WHERE 1=1 ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItem_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append(" [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append("  [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter],cardtype) ")
                        updateSql.Append(" values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append(" N'" & dr.Cells(ProcessGrid.Description).Value & "','" & dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString & "',")
                        updateSql.Append(" '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(), null,null,")
                        ' updateSql.Append(" null,null,|null,null,null,null,null,|null,null,null,null,")
                        updateSql.Append(" null,null,null," & GetInsertSQLG(cboRightTv) & "," & GetInsertSQLG(cboRightLine) & ",")
                        updateSql.Append(" " & GetInsertSQLG(cboRightLineTwo) & "," & GetInsertSQLG(cboRightLineThree) & "," & GetInsertSQLG(cboRightLineFour) & ",null,")
                        updateSql.Append(" null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & m_strCardType & "')")
                    Next

                    For Each dr As DataGridViewRow In dgvRight.Rows
                        o_strResultValue = dr.Cells(ProcessGrid.ResultValue).EditedFormattedValue.ToString
                        If String.IsNullOrEmpty(o_strResultValue) OrElse o_strResultValue = "\" Then
                            o_strResultValue = "/"
                        End If
                        o_strDes = dr.Cells(ProcessGrid.Description).Value + "(" + dr.Cells(ProcessGrid.Unit).Value + ")"
                        updateSql.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_CutCardDCheckItemPrint_t WHERE  PartID='" & _cutCardPn & "' AND Stationid='" & _stationId & "' ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter() & " ),0)=1")
                        updateSql.Append(" UPDATE m_CutCardDCheckItemPrint_t SET RESULTVALUE='" & o_strResultValue & "' ")
                        updateSql.Append("  WHERE 1=1 ")
                        updateSql.Append(RCardComBusiness.GetWhereAnd("PartID", _cutCardPn))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("Stationid", _stationId))
                        updateSql.Append(RCardComBusiness.GetWhereAnd("CheckItemID", dr.Cells(ProcessGrid.CheckCode).Value))
                        updateSql.Append(RCardComBusiness.GetFatoryProfitcenter())
                        updateSql.Append(" ELSE INSERT INTO [m_CutCardDCheckItemPrint_t]([PartID],[Stationid],[CheckItemID],[Description],[ResultValue],")
                        updateSql.Append(" [Status],[CheckGroup],[UserID],[InTime],[LeftTVPN],[LeftWirePN1],")
                        updateSql.Append(" [LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1],")
                        updateSql.Append("  [RightWirePN2],[RightWirePN3],[RightWirePN4],[FinishSize],")
                        updateSql.Append("  [LeftCutSize],[RightCutSize],[Tolerance],[ToleranceRange],[Factoryid],[Profitcenter]) ")
                        updateSql.Append(" values ('" & _cutCardPn & "','" & _stationId & "','" & dr.Cells(ProcessGrid.CheckCode).Value & "',")
                        updateSql.Append(" N'" & o_strDes & "','" & o_strResultValue & "',")
                        updateSql.Append(" '1','" & dr.Cells(ProcessGrid.CheckGroup).Value & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),null,null,")
                        '[LeftWirePN2],[LeftWirePN3],[LeftWirePN4],[RightTVPN],[RightWirePN1]
                        updateSql.Append(" null,null,null," & GetInsertSQLG(cboRightTv) & "," & GetInsertSQLG(cboRightLine) & ",")
                        updateSql.Append(" " & GetInsertSQLG(cboRightLineTwo) & "," & GetInsertSQLG(cboRightLineThree) & "," & GetInsertSQLG(cboRightLineFour) & ",null,")
                        updateSql.Append(" null,null,null,null,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "')")

                    Next
                End If
            End If
            If Not String.IsNullOrEmpty(updateSql.ToString) Then
                ' updateSql &= SetUpdateSql()
                Dim updateAllSql As String = updateSql.ToString + "" 'updateSql.ToString + SetUpdateSql()
                RCardComBusiness.ExecSQL(updateAllSql)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCutBodyModify", "UpdateData", "RCard")
        End Try
    End Sub

#End Region

#Region "提示"
    Private ttLeft As ToolTip = Nothing
    Private ttRight As ToolTip = Nothing
    Public m_blnShowed As Boolean = False
    Public m_strShowLastText As String = ""
    Public m_strShowRTVLastText As String = ""
    Private Sub InitTools()
        ttLeft = New ToolTip()
        ttRight = New ToolTip
    End Sub

    Private Sub cboLeftTv_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboLeftTv.DrawItem
        Dim o_currentShowText As String = ""
        Try
            e.DrawBackground()
            o_currentShowText = cboLeftTv.Items(e.Index).ToString()
            e.Graphics.DrawString(cboLeftTv.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                If (m_strShowLastText = "") OrElse (m_strShowLastText <> "" AndAlso o_currentShowText <> m_strShowLastText) Then
                    ttLeft.Show(cboLeftTv.Items(e.Index).ToString(), cboLeftTv, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
                    e.DrawFocusRectangle()
                    m_blnShowed = True
                    m_strShowLastText = cboLeftTv.Items(e.Index).ToString()
                End If
            End If
            ' e.DrawFocusRectangle()

        Catch ex As Exception
            ' AddHandler cboLeftTv.DrawItem, AddressOf cboLeftTv_DrawItem
        Finally
            '  AddHandler cboLeftTv.DrawItem, AddressOf cboLeftTv_DrawItem
        End Try
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
        Dim o_currentShowText As String = ""
        Try
            e.DrawBackground()
            o_currentShowText = cboRightTv.Items(e.Index).ToString()
            e.Graphics.DrawString(cboRightTv.Items(e.Index).ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                If (m_strShowRTVLastText = "") OrElse (m_strShowRTVLastText <> "" AndAlso o_currentShowText <> m_strShowRTVLastText) Then
                    ttRight.Show(cboRightTv.Items(e.Index).ToString(), cboRightTv, e.Bounds.X + e.Bounds.Width - CType(sender, ComboBox).Width - 20, e.Bounds.Y + e.Bounds.Height)
                    m_strShowRTVLastText = cboRightTv.Items(e.Index).ToString()
                End If
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
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

    Private Sub BtnSelectSta_Click(sender As Object, e As EventArgs) Handles BtnSelectSta.Click
        Dim frm As New BasicManagement.FrmRStationSet
        frm.opflag = 3
        frm.ShowDialog()
        Me.txtStationid.Text = frm.frmRstationid + "-" + frm.frmRstationname + "-" + frm.frmStationCableType
    End Sub
End Class
