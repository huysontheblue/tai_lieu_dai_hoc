Imports System.Xml
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text

Public Class FrmPackingPartSetLog
    Private StrLPartID As String = ""

    Public Sub New(ByVal _StrLPartID As String)
        InitializeComponent()

        StrLPartID = _StrLPartID
    End Sub

    '加载数据
    Private Sub FrmPackingPartSetLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitData()
    End Sub

    '查询历史数据
    Private Sub InitData()
        Dim StrSql As String = String.Format(" SELECT a.LPartID,a.CartonStylePackID,a.CartonStylePackItem,a.CartonQtyI,a.IsAutoGenerateCarton,a.IsScanFixedCarton,a.IsSystemPrintCarton,a.IsScanCustProAndQtyI,a.IsScanQRCode, " &
                               " a.QRCodeStylePackID,a.QRCodeStylePackItem,a.IsSystemPrintQRCode,a.IsScanPECarton,a.PECartonStylePackID,a.PECartonStylePackItem,a.PECartonQtyI,a.IsSystemPrintPECarton, " &
                               " a.PpIDCodeStylePackID,a.PpIDCodeStylePackItem,a.IsFixedCode,a.PpIDQtyI,a.IsSystemPrintPpID,a.CreateUserID+'/'+b.UserName AS CreateUserID, " &
                               " a.CreateDate,a.IsChecked,a.CheckedUserID+'/'+c.UserName AS CheckedUserID,a.CheckedDate,a.OperType,a.OperUserid+'/'+d.UserName AS OperUserid,OperDate " &
                               " FROM dbo.m_PartScanStyleInof_t_Log a LEFT JOIN dbo.m_Users_t b ON a.CreateUserID=b.UserID " &
                               " LEFT JOIN dbo.m_Users_t c ON a.CheckedUserID=c.UserID LEFT JOIN dbo.m_Users_t d ON a.OperUserid=d.UserID " &
                               " WHERE a.LPartID='{0}' ORDER BY a.OperDate DESC ", StrLPartID)
        Me.LPartLogDg.DataSource = DbOperateUtils.GetDataTable(StrSql)
    End Sub
End Class