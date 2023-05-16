#Region "Imports"
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports MainFrame

#End Region

Public Class FrmScanStation
    Dim IsTextScanCheck As Boolean = True
    Private _dt As DateTime = DateTime.Now
#Region "工单编号"
    Private _Moid As String
    Public Property Moid() As String
        Get
            Return _Moid
        End Get

        Set(ByVal Value As String)
            _Moid = Value
        End Set
    End Property
#End Region
#Region "工站"
    Private _StationId As String
    Public Property StationId() As String
        Get
            Return _StationId
        End Get

        Set(ByVal Value As String)
            _StationId = Value
        End Set
    End Property
#End Region
 

#Region "构造函数"

    Sub New(ByVal strMoid As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._Moid = strMoid

    End Sub
#End Region
    Private Sub txtStationId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStationId.KeyPress
        If IsTextScanCheck Then
            If e.KeyChar <> Chr(13) Then
                ''禁止用键盘手动输入
                Dim tempDt As DateTime = DateTime.Now
                Dim ts As TimeSpan = tempDt.Subtract(_dt)
                If (ts.Milliseconds > 50) Then
                    txtStationId.Text = ""
                End If
                _dt = tempDt
            Else
                If CheckScanStation(Me.txtStationId.Text) = False Then
                    MessageBox.Show("扫描的工站不存在!")
                Else

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

    End Sub
#Region "函数"
    Private Function CheckScanStation(ByVal stationid As String) As Boolean
        Dim bResult As Boolean = False
        Dim dt As New DataTable
        Dim o_strSql As New StringBuilder
        o_strSql.Append(" select (A.Stationid+' - '+C.Stationname) as Stationid from m_RPartStationD_t A  INNER JOIN ")
        o_strSql.Append(" m_Mainmo_t B ON B.PartID=A.PPartid  INNER JOIN m_Rstation_t C ON C.Stationid=A.Stationid ")
        o_strSql.Append("  WHERE B.Moid='" & Me.Moid & "' and A.Stationid='" & stationid & "' AND A.State='1'   ")
        dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
        If dt.Rows.Count > 0 Then
            bResult = True
            Me.StationId = dt.Rows(0)!Stationid.ToString
        Else
            Me.StationId = ""
        End If
        Return bResult
    End Function
#End Region

    Private Sub FrmScanStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtStationId.Focus()
    End Sub
End Class

