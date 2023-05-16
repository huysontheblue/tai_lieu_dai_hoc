Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass
Public Class FrmHWHLTestResultDetail
#Region "PCBASN"
    Private _pcbaSn As String
    Public Property pcbaSn() As String
        Get
            Return _pcbaSn
        End Get

        Set(ByVal Value As String)
            _pcbaSn = Value
        End Set
    End Property
#End Region
#Region "工站编码"
    Private _stationId As String
    Public Property stationId() As String
        Get
            Return _stationId
        End Get

        Set(ByVal Value As String)
            _stationId = Value
        End Set
    End Property
    Private _productgroup As String
    Public Property productgroup() As String
        Get
            Return _productgroup
        End Get

        Set(ByVal Value As String)
            _productgroup = Value
        End Set
    End Property
#End Region

#Region "构造函数"

    Sub New(ByVal sPcbaSn As String, ByVal sStationId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._pcbaSn = sPcbaSn
        Me._stationId = sStationId

    End Sub
    Sub New(ByVal sPcbaSn As String, ByVal sStationId As String, ByVal sproductgroup As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._pcbaSn = sPcbaSn
        Me._stationId = sStationId
        Me._productgroup = sproductgroup
    End Sub
#End Region

    Private Sub FrmHWHLTestResultDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTestResultDetail(Me._pcbaSn, Me._stationId)
    End Sub


    Private Sub GetTestResultDetail(ByVal pcbasn As String, ByVal stationid As String)

        Try


            Dim o_strSQL As New StringBuilder
            o_strSQL.Append(GetHWHLSql())
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Me.DgDataDetail.DataSource = dt
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetHWHLSql() As String
        Dim sql As String = "select * from mesdatacenter.dbo.m_TestType_t where TestTypeID='" & Me._stationId & "'"
        Dim selsql As String = ""
        Dim keycol As String = ""
        Dim sns As String = ""
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql.ToString)
        If dt.Rows.Count > 0 Then

            selsql = dt.Rows(0)("selectsql").ToString
            keycol = dt.Rows(0)("keyfileld").ToString
        End If
        sql = "select * from mesdb.dbo.m_hwhlppidlink_t where ppid ='" & Me.pcbaSn & "'"
        dt = New DataTable
        dt = DbOperateUtils.GetDataTable(sql.ToString)
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                sns = "'" + dr("ppid1").ToString + "','" + dr("ppid2").ToString + "'," + sns
            Next
        End If
        sns = Mid(sns, 1, Len(sns) - 1)
        sql = selsql + " where " + keycol + " in(" + sns + ")"

        Return sql
    End Function
End Class