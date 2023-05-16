Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmCutCardStationCopy


    Sub New(ByVal cutCardId As String, ByVal runCardOldStation As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As Boolean)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me._cutCardPn = cutCardId
        Me._RCOldStationID = runCardOldStation
        Me._gridViewRow = dataGridViewRow
        Me._action = action
        ' Me._isQueryOldVersion = isQueryOldVersion
    End Sub


#Region "属性"

    Private _RCNewStationID As String

    Private _RCOldStationID As String
    Public Property RCOldStation() As String
        Get
            Return _RCOldStationID
        End Get

        Set(ByVal Value As String)
            _RCOldStationID = Value
        End Set
    End Property

    Private _cutCardPn As String
    Public Property RunCardPN() As String
        Get
            Return _cutCardPn
        End Get

        Set(ByVal Value As String)
            _cutCardPn = Value
        End Set
    End Property

    Private _RCNewStationName As String
    Public Property RCNewStationName() As String
        Get
            Return _RCNewStationName
        End Get

        Set(ByVal Value As String)
            _RCNewStationName = Value
        End Set
    End Property

    Private _action As String
    Public Property Actioin() As String
        Get
            Return _action
        End Get

        Set(ByVal Value As String)
            _action = Value
        End Set
    End Property

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

#Region "事件"

    Private Sub FrmRunCardBodyCopy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初始化
        IniteControls()
        Call FillCombox(Me.cboNewStation)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim strSql As String = ""
        Dim strNewSEQ As String = ""
        Try

            Me.lblMsg.Text = String.Empty

            'A,First get new Station Name from UI
            If Not (cboNewStation.SelectedItem Is Nothing) Then
                Me._RCNewStationName = cboNewStation.SelectedItem(1)
                Me._RCNewStationID = cboNewStation.SelectedItem(0)
            Else
                'Check Whehter is a real station name, user key in
                If Not IsStation(Me.cboNewStation.Text, Me._RCNewStationID) Then
                    MessageUtils.ShowError("输入的 新工站名称不存在, 请检查！")
                    Me.cboNewStation.Focus()
                    Exit Sub
                Else
                    Me._RCNewStationName = Me.cboNewStation.Text

                    Me._RCNewStationID = GetStationIDByName(Me._RCNewStationName)
                End If
            End If

            'B, check must old, new not the same
            If Me.cboOldStation.SelectedItem(1) = Me._RCNewStationName Then
                MessageUtils.ShowError("输入的新工站名称不能和旧工站的名称一样！")
                Me.cboNewStation.Focus()
                Exit Sub
            End If

            'B, check whether is already exist
            If StationAlreadyExist() Then
                MessageUtils.ShowError("新的工站已经存在, 请选择其他工站！")
                Me.cboNewStation.Focus()
                Exit Sub
            End If

            'Get the new station seq, Add dbnull process by CQ 20151101
            Dim dt As DataTable = GetRCardDTable(Me._RCOldStationID)
            If dt.Rows.Count > 0 Then
                Dim StationID As String = Me.cboNewStation.SelectedValue.ToString
                Dim WorkingHours As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.WorkingHours.ToString))
                Dim Equipment As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.Equipment.ToString))
                Dim ProcessStandard As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.ProcessStandard.ToString))
                Dim Shape As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.Shape.ToString))
                Dim remark As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.Remark.ToString))
                Dim NewProcessStandard As String = DBNullToStr(dt.Rows(0)(RunCardBusiness.BodyGrid.NewProcessStandard.ToString))
                Dim DrawingVer As String = DBNullToStr(dt.Rows(0).Item("DrawingVer"))
                Dim UserID As String = VbCommClass.VbCommClass.UseId
                Dim StationSQ As Integer = dt.Rows(0)("NUM").ToString + 1
                Dim factoryID As String = VbCommClass.VbCommClass.Factory
                Dim profitCenter As String = VbCommClass.VbCommClass.profitcenter

                strSql = " INSERT INTO m_RCardD_t(PartID,StationID,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark,Status,UserID,InTime,Shape,NewProcessStandard,DrawingVer,Factoryid,Profitcenter) VALUES(" & _
                         "'" & Me.RunCardPN & "','" & StationID & "','" & StationSQ.ToString & "','" & WorkingHours & "',N'" & Equipment & "',N'" & ProcessStandard & "',N'" &
                         remark & "',1,'" & UserID & "',getdate(),'" & Shape & "',N'" & NewProcessStandard & "','" & DrawingVer & "','" & factoryID & "','" & profitCenter & "' )"

                Dim result As String = RCardComBusiness.ExecSQL(strSql)
                If result = String.Empty Then
                    MessageUtils.ShowInformation("复制工站成功！")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.cboNewStation.Focus()
                Else
                    MessageUtils.ShowError(result)
                    Me.cboNewStation.Focus()
                End If
            End If

        Catch ex As Exception
            If cboNewStation.SelectedItem Is Nothing Then
                MessageUtils.ShowError("请检查工站名称是否正确！")
                Exit Sub
            End If
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' DBNULL转化为字符串
    ''' </summary>
    ''' <param name="obj">需要转化的数据</param>
    ''' <returns>如果是DBNULL返回空,否则返回本字符串</returns>
    ''' <remarks></remarks>
    Public Function DBNullToStr(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString().Trim()
            End If
        End If
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


#End Region

#Region "方法"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Try
            If ColComboBox.Name = "cboNewStation" Then
                ColComboBox.Items.Clear()
                Dim strSQL As String = "select Stationid,StationName from m_Rstation_t where usey ='Y' order by  case when substring(StationName,1,1) =N'" &
                                        Me.cboOldStation.Text.Substring(0, 1) & "'  then 1 else 1+RAND()  End"
                Dim dt As DataTable = RCardComBusiness.GetDataTable(strSQL)
                cboNewStation.DataSource = dt
                cboNewStation.DisplayMember = "StationName"
                cboNewStation.ValueMember = "Stationid"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "初始化控件"

    Private Sub IniteControls()
        Me.cboOldStation.Enabled = False
        If Not Me.SelectedGridViewRow Is Nothing Then
            Me.lblMsg.Text = String.Empty
            If Actioin = "copy" Then
                cboOldStation.Items.Clear()
                Using dt As New DataTable
                    dt.Columns.Add("Stationid", GetType(String))
                    dt.Columns.Add("StationName", GetType(String))
                    dt.Rows.Add(_gridViewRow.Cells(RunCardBusiness.BodyGrid.StationID.ToString).Value.ToString,
                                _gridViewRow.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Value.ToString)
                    cboOldStation.DataSource = dt.DefaultView
                    cboOldStation.DisplayMember = "StationName"
                    cboOldStation.ValueMember = "Stationid"
                End Using
            End If
        End If
    End Sub

    Private Function GetStationIDByName(ByVal parNewStationID As String) As String
        Dim strSQL As String = " select StationName from m_Rstation_t(nolock) where usey =1 and stationName =N'" & parNewStationID.Trim() & "' "
        Dim dt As DataTable = RCardComBusiness.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            GetStationIDByName = dt.Rows(0)(0).ToString
        Else
            GetStationIDByName = String.Empty
        End If
        Return GetStationIDByName
    End Function

    Private Function IsStation(ByVal parInput As String, ByRef refStationID As String) As Boolean
        Dim strSQL As String = " select Stationid from m_Rstation_t(nolock) where usey =1 and stationname =N'" & parInput.Trim() & "' "
        Dim dt As DataTable = RCardComBusiness.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            IsStation = True
            refStationID = dt.Rows(0)(0).ToString
        Else
            IsStation = False
        End If
        Return IsStation
    End Function

    Private Function StationAlreadyExist() As Boolean
        Dim dt As DataTable = GetRCardDTable(Me.cboNewStation.SelectedValue.ToString)
        If dt.Rows.Count > 0 Then
            StationAlreadyExist = True
        Else
            StationAlreadyExist = False
        End If

        Return StationAlreadyExist
    End Function

    Private Function GetRCardDTable(sationID As String) As DataTable
        Dim strSQL As String = "SELECT (SELECT COUNT(1) FROM m_RCardCutD_t WHERE  PartID ='" & _cutCardPn & "'  )NUM,* FROM " & _
                               " m_RCardCutD_t WHERE  PartID ='" & Me._cutCardPn & "' AND StationID= N'" & sationID & "' " & RCardComBusiness.GetFatoryProfitcenter()
        Dim dt As DataTable = RCardComBusiness.GetDataTable(strSQL)

        Return dt
    End Function

#End Region



End Class