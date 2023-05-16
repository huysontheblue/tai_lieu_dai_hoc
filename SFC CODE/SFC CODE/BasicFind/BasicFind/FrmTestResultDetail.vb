Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports LXWarehouseManage
Public Class FrmTestResultDetail
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
#End Region

#Region "构造函数"

    Sub New(ByVal sPcbaSn As String, ByVal sStationId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._pcbaSn = sPcbaSn
        Me._stationId = sStationId

    End Sub
#End Region

    Private Sub FrmTestResultDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTestResultDetail(Me._pcbaSn, Me._stationId)
    End Sub


    Private Sub GetTestResultDetail(ByVal pcbasn As String, ByVal stationid As String)

        Try


            Dim o_strSQL As New StringBuilder
            Select Case stationid
                Case "A00081"
                    o_strSQL.Append("select barcode as PCBASN,STATIONID,RESULT,LINEID,'' as Fixno,CollectTime ")
                    o_strSQL.Append(" from MESDataCenter.dbo.m_MSRJBMACWrite_t  where Barcode='" & pcbasn & "'")
                Case "A00082"
                    o_strSQL.Append("select B.PCBASN,'AMZ002'AS STATIONID,Result,'' AS LINEID,'' as Fixno,CollectTime ")
                    o_strSQL.Append(" from MESDataCenter.dbo.M_AMZPCBATEST_T  A INNER JOIN ")
                    o_strSQL.Append(" m_AmzMACSNLink_t B ON B.MACAddress=A.MAC WHERE B.PCBASN='" & pcbasn & "'")
                Case "A00083"
                    o_strSQL.Append("select SN AS PCBASN,'AMZ003' AS STATIONID,Result,LineId,Fixno,CollectTime")
                    o_strSQL.Append("   from MESDataCenter.dbo.m_AMZ360Test_t WHERE SN='" & pcbasn & "'")
                Case "A00084"
                    o_strSQL.Append("select B.PCBASN,'AMZ004'AS STATIONID,Result, LINEID, Fixno,CollectTime")
                    o_strSQL.Append("   from MESDataCenter.dbo.m_AMZFunctionTest_t  A INNER JOIN ")
                    o_strSQL.Append(" m_AmzMACSNLink_t B ON B.MACAddress=A.MAC WHERE B.PCBASN='" & pcbasn & "'")
                Case "A00085"
                    o_strSQL.Append("select B.PCBASN,'AMZ005'AS STATIONID,Result,'' AS LINEID,'' as Fixno,CollectTime")
                    o_strSQL.Append("   from MESDataCenter.dbo.m_AMZLaserTest_t  A INNER JOIN")
                    o_strSQL.Append(" m_AmzMACSNLink_t B ON B.MACAddress=A.barcode WHERE B.PCBASN='" & pcbasn & "'")
                Case "A00086"
                    o_strSQL.Append(" select B.PCBASN,'AMZ006'AS STATIONID,Result, LINEID, Fixno,CollectTime ")
                    o_strSQL.Append("  from MESDataCenter.dbo.m_AMZReadInfo_t  A INNER JOIN ")
                    o_strSQL.Append(" m_AmzMACSNLink_t B ON B.MACAddress=A.MAC WHERE B.PCBASN='" & pcbasn & "'")
                Case Else

            End Select
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(o_strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Me.DgDataDetail.DataSource = dt
            End If


        Catch ex As Exception

        End Try

    End Sub
End Class