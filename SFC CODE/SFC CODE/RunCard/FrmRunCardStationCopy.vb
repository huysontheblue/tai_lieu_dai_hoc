Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmRunCardStationCopy

    Sub New(ByVal runCardId As Integer, ByVal runCardOldStation As String, ByVal action As String, ByVal dataGridViewRow As DataGridViewRow, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化。
        Me._RCID = runCardId
        ' Me._RCPN = runCardPN
        Me._RCOldStationID = runCardOldStation
        Me._gridViewRow = dataGridViewRow
        Me._action = action
        ' Me._isQueryOldVersion = isQueryOldVersion
    End Sub



    Private _RCOldStationID As String
    Private _RCID As String
    Private _RCNewStationName As String
    Private _RCNewStationID As String


    Public Property RCID() As String
        Get
            Return _RCID
        End Get

        Set(ByVal Value As String)
            _RCID = Value
        End Set
    End Property

#Region "Old Station ID"
    Public Property RCOldStation() As String
        Get
            Return _RCOldStationID
        End Get

        Set(ByVal Value As String)
            _RCOldStationID = Value
        End Set
    End Property
#End Region

    Public Property RCNewStationName() As String
        Get
            Return _RCNewStationName
        End Get

        Set(ByVal Value As String)
            _RCNewStationName = Value
        End Set
    End Property

#Region "PartNumber"

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


    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable = Nothing
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If ColComboBox.Name = "cboNewStation" Then
                ColComboBox.Items.Clear()
                If 1 Then 'Actioin = "add" Then
                    ' UserDg = DataHand.GetDataTable("select ID,StationName from m_RUNCARDStation_t(nolock)")
                    UserDg = DataHand.GetDataTable("select ID,StationName from M_RUNCARDSTATION_T where Status ='1' order by  case when substring(StationName,1,1) =N'" & Me.cboOldStation.Text.Substring(0, 1) & "'  then 1  " & _
                                                     " else 1+RAND()  End ")

                    cboNewStation.DataSource = UserDg.DefaultView
                    cboNewStation.DisplayMember = "StationName"
                    cboNewStation.ValueMember = "ID"
                ElseIf 1 Then 'Actioin = "modify" Then
                    ' Dim sql As String = "SELECT " & _gridViewRow.Cells("工站ID").Value.ToString & " ID,N'" & _gridViewRow.Cells("工站名称").Value.ToString & "' StationName UNION "
                    '  sql &= " select ID,StationName from m_RUNCARDStation_t(nolock) WHERE ID<>" & _gridViewRow.Cells("工站ID").Value.ToString & " "
                    ' UserDg = DataHand.GetDataTable(sql)
                    cboNewStation.DataSource = UserDg
                    cboNewStation.DisplayMember = "StationName"
                    cboNewStation.ValueMember = "ID"
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            DataHand = Nothing
        End Try
    End Sub




    Private Sub FrmRunCardBodyCopy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初始化
        IniteControls()
        'Me.txtOldStation.Text = _RCOldStation
        Call FillCombox(Me.cboNewStation)
    End Sub





#Region "初始化控件"
    Private Sub IniteControls()
        Me.cboOldStation.Enabled = False
        If Not Me.SelectedGridViewRow Is Nothing Then
            ' Me.lblId.Text = _gridViewRow.Cells("ID").Value.ToString
            ' Me.cboStation.SelectedValue = _gridViewRow.Cells("工站ID").Value.ToString
            ' Me.txtEquipment.Text = _gridViewRow.Cells("设备治具").Value.ToString
            ' Me.txtProcessStandard.Text = _gridViewRow.Cells("工艺标准").Value.ToString
            ' Me.txtSopFilePath.Text = _gridViewRow.Cells("SOP").Value.ToString
            ' Me.iiStationSQ.Value = _gridViewRow.Cells("工序").Value.ToString
            ' Me.stationSeq = Me.iiStationSQ.Value
            ' Me.iiWoringHours.Text = _gridViewRow.Cells("工时").Value.ToString
            ' Me.txtRemark.Text = _gridViewRow.Cells("备注").Value.ToString
            Me.lblMsg.Text = String.Empty
            If Actioin = "copy" Then
                cboOldStation.Items.Clear()
                Using dt As New DataTable
                    dt.Columns.Add("ID", GetType(String))
                    dt.Columns.Add("StationName", GetType(String))
                    dt.Rows.Add(_gridViewRow.Cells("工站ID").Value.ToString, _gridViewRow.Cells("工站名称").Value.ToString)
                    cboOldStation.DataSource = dt.DefaultView
                    cboOldStation.DisplayMember = "StationName"
                    cboOldStation.ValueMember = "ID"
                End Using
            End If
        End If
    End Sub
#End Region


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim strSql As String = ""
        Dim strNewSEQ As String = ""
        Try

            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Me.lblMsg.Text = String.Empty

            'A,First get new Station Name from UI
            If Not (cboNewStation.SelectedItem Is Nothing) Then
                Me._RCNewStationName = cboNewStation.SelectedItem(1)
                Me._RCNewStationID = cboNewStation.SelectedItem(0)
            Else
                'Check Whehter is a real station name, user key in
                If Not IsStation(Me.cboNewStation.Text, Me._RCNewStationID) Then
                    MessageBox.Show("输入的 新工站名称不存在, 请检查")
                    Me.cboNewStation.Focus()
                    Exit Sub
                Else
                    Me._RCNewStationName = Me.cboNewStation.Text

                    Me._RCNewStationID = GetStationIDByName(Me._RCNewStationName)
                End If
            End If

            'B, check must old, new not the same
            If Me.cboOldStation.SelectedItem(1) = Me._RCNewStationName Then
                MessageBox.Show("输入的新工站名称不能和旧工站的名称一样！")
                Me.cboNewStation.Focus()
                Exit Sub
            End If

            'B, check whether is already exist
            If StationAlreadyExist(Me._RCNewStationName) Then
                MessageBox.Show("新的工站已经存在, 请选择其他工站")
                Me.cboNewStation.Focus()
                Exit Sub
            End If

            'Get the new station seq
            strNewSEQ = GetNewSEQ(Me._RCID)


            strSql = " Insert into m_RunCardDetail_t(RunCardID,StationSQ,StationID,WorkingHours," & _
                    " Equipment,ProcessStandard, SopFilePath,Remark, UserID, status, Intime,Shape, PARTNUMBER, STATIONNAME, newprocessstandard ) " & _
                    " select RunCardID, " & strNewSEQ & " as StationSQ ," & Me._RCNewStationID & " as StationID,WorkingHours,Equipment, '' as ProcessStandard, " & _
                    " SopFilePath,Remark, N'" & VbCommClass.VbCommClass.UseId & "' as UserID, status, GETDATE() as Intime,Shape, PARTNUMBER, N'" & Me._RCNewStationName & "' as STATIONNAME, newprocessstandard " & _
                    " from m_RunCardDetail_t(nolock) " & _
                    " where runcardid='" & Me._RCID & "'" & _
                    " and StationID ='" & Me._RCOldStationID & "'"

            DAL.ExecSql(strSql)

            MessageBox.Show("复制工站成功")
            'Me.lblMsg.ForeColor = Drawing.Color.Red
            'Me.lblMsg.Text = "复制工站成功！"

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.cboNewStation.Focus()

        Catch ex As Exception
            If cboNewStation.SelectedItem Is Nothing Then
                MessageBox.Show(" 请检查工站名称是否正确")
                Exit Sub
            End If
            Throw ex
        End Try
    End Sub

    Private Function GetStationIDByName(ByVal parNewStationID As String) As String
        Dim strSql As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SeqReader As SqlDataReader
        GetStationIDByName = String.Empty

        Try
            SeqReader = Conn.GetDataReader(" select StationName from M_RUNCARDSTATION_T(nolock) where Status ='1' and stationName =N'" & parNewStationID.Trim() & "' ")

            While (SeqReader.Read())

                If SeqReader.HasRows Then
                    GetStationIDByName = SeqReader.GetString(0)
                    Exit While
                End If
            End While

            Return GetStationIDByName
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function IsStation(ByVal parInput As String, ByRef refStationID As String) As Boolean
        Dim strSql As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SeqReader As SqlDataReader = Nothing

        Try

            SeqReader = Conn.GetDataReader(" select ID from M_RUNCARDSTATION_T where Status ='1' and stationname =N'" & parInput.Trim() & "' ")

            While (SeqReader.Read())

                If SeqReader.HasRows Then
                    IsStation = True
                    refStationID = SeqReader.GetInt32(0)
                Else
                    IsStation = False
                End If
            End While

            Return IsStation

        Catch ex As Exception
            Throw ex
        Finally
            SeqReader.Close()
        End Try

    End Function

    Private Function StationAlreadyExist(ByVal parNewStationName As String) As Boolean
        Dim strSql As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SeqReader As SqlDataReader
        Try

            SeqReader = Conn.GetDataReader(" SELECT 1 FROM M_RUNCARDDETAIL_T(nolock) WHERE RunCardID ='" & Me._RCID.Trim() & "' AND STATIONNAME= N'" & parNewStationName & "' ")


            While (SeqReader.Read())

                If SeqReader.HasRows Then
                    StationAlreadyExist = True
                Else
                    StationAlreadyExist = False
                End If
            End While
            Return StationAlreadyExist
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Private Function GetNewSEQ(ByVal parRCID As String) As String

        Dim strSql As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SeqReader As SqlDataReader = Nothing
        GetNewSEQ = ""
        Try

            SeqReader = Conn.GetDataReader(" SELECT ISNULL(MAX(STATIONSQ),0)+1 FROM M_RUNCARDDETAIL_T WHERE RunCardID ='" & parRCID.Trim() & "' ")

            While (SeqReader.Read())
                GetNewSEQ = SeqReader.GetInt32(0)
            End While
        Catch ex As Exception
            Throw ex
        Finally
            SeqReader.Close()
        End Try
    End Function




    'Private Sub cboNewStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewStation.SelectedIndexChanged

    '    Dim comboBox As ComboBox = CType(sender, ComboBox)

    '    ' Save the selected employee's name, because we will remove
    '    ' the employee's name from the list.
    '    Dim selectedNewStationName = CType(cboNewStation.SelectedItem, String)

    '    Dim count As Integer = 0
    '    Dim resultIndex As Integer = -1

    '    ' Call the FindStringExact method to find the first 
    '    ' occurrence in the list.
    '    resultIndex = cboNewStation.FindStringExact(cboNewStation.SelectedItem)

    '    _RCNewStationName = selectedNewStationName

    'End Sub
End Class