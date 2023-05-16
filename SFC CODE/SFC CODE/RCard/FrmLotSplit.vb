Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmLotSplit

#Region "扫描步骤"
    Private _scanStep As Integer
    Public Property ScanStep() As Integer
        Get
            Return _scanStep
        End Get
        Set(ByVal value As Integer)
            _scanStep = value
        End Set
    End Property
#End Region

#Region "序列号"
    Private _sn As String
    Public Property SerialNumber() As String
        Get
            Return _sn
        End Get
        Set(ByVal value As String)
            _sn = value
        End Set
    End Property
#End Region

#Region "员工工号"
    Private _userId As String
    Public Property ScanerUserId() As String
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property
#End Region

#Region "扫描数量"
    Private _scanQty As Integer
    Public Property ScanQty() As Integer
        Get
            Return _scanQty
        End Get
        Set(ByVal value As Integer)
            _scanQty = value
        End Set
    End Property
#End Region

#Region "拆分数量"
    Private _splitQty As Integer
    Public Property SplitQty() As Integer
        Get
            Return _splitQty
        End Get
        Set(ByVal value As Integer)
            _splitQty = value
        End Set
    End Property
#End Region

#Region "剩余数量"
    Private _remainQty As Integer
    Public Property RemainQty() As Integer
        Get
            Return _remainQty
        End Get
        Set(ByVal value As Integer)
            _remainQty = value
        End Set
    End Property
#End Region

#Region "初始化"
    Private Sub IniteScanning()
        Me.ScanStep = 1
        Me.lblMsg.Text = ""
        Me.SplitQty = 0
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
    End Sub
#End Region

#Region "显示错误提示"
    Private Sub ShowMsg(ByVal msg As String)
        Me.lblMsg.Text = msg
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
    End Sub
#End Region

#Region "显示提示信息"
    Private Sub ShowTips(ByVal tips As String)
        Me.lblTips.Text = tips
        Me.txtInput.Text = ""
        Me.txtInput.Focus()
    End Sub
#End Region

#Region "校验扫描数量"
    Private Function VerifyScanQty(ByVal qty As String) As String
        If Not System.Text.RegularExpressions.Regex.IsMatch(qty.ToString, "^\d+$") Then
            Return "拆分数量:" & qty & "为非纯数字"
        End If
        If Me.RemainQty = 0 Then
            Return Me.SerialNumber & "剩余数量为零、不可拆分"
        End If
        If CInt(qty) > Me.RemainQty Then
            Return "拆分数量:" & qty.ToString() & "不能大于剩余数量"
        End If
        Me.SplitQty = qty
        Return ""
    End Function
#End Region

#Region "加载扫描数据"
    Private Sub LoadScanData(ByVal sn As String)
        Dim StrSql As String =
            "select UN.WorkOrder 工单,PN.TAvcPart 料号,UN.SerialNumber 工站条码,ST.StationName 工站,UN.Qty 数量,UN.UserID 作业员,UN.InTime 生产时间  " &
            "from m_RCardLotUnit_t(nolock) UN  " &
            "inner join m_PartContrast_t(nolock) PN on UN.PartID=PN.TAvcPart   " &
            "inner join m_Rstation_t(nolock) ST on UN.StationID=ST.Stationid  " &
            "where SerialNumber='" & sn & "'" &
            RCardComBusiness.GetFatoryProfitcenter("UN") &
            "union all  " &
            "select UN.WorkOrder 工单,PN.TAvcPart 料号,UN.SerialNumber 工站条码,ST.StationName 工站,LS.Qty 数量,LS.UserID 作业员,LS.InTime 生产时间  " &
            "from m_RCardLotUnit_t(nolock) UN  " &
            "inner join m_PartContrast_t(nolock) PN on UN.PartID=PN.TAvcPart  " &
            "inner join m_Rstation_t(nolock) ST on UN.StationID=ST.StationID  " &
            "inner join m_RCardLotSplit_t(nolock) LS on UN.ID=LS.LotUnitID  " &
            "where SerialNumber='" & sn & "'" &
             RCardComBusiness.GetFatoryProfitcenter("UN")

        Dim sql As String = "select top 1 Qty from m_RCardLotUnit_t(nolock) where SerialNumber='" & sn & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()
        Dim ds As DataSet = RCardComBusiness.GetDataSet(StrSql & vbNewLine & sql)
        Me.dgvSplitData.DataSource = ds.Tables(0)
        Me.RemainQty = CInt(ds.Tables(1).Rows(0)(0).ToString)
        Me.lblRemainQty.Text = "剩余数量:" & ds.Tables(1).Rows(0)(0).ToString()
    End Sub
#End Region

#Region "保存拆分数据"
    Private Function SaveSplitData() As String
        '参数定义
        Dim param1 As New SqlParameter("@SerialNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@SplitQty", SqlDbType.Int, ParameterDirection.Input)
        Dim param4 As New SqlParameter("@Factoryid", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param5 As New SqlParameter("@Profitcenter", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param6 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = Me.SerialNumber
        param2.Value = Me.ScanerUserId
        param3.Value = Me.SplitQty
        param4.Value = Me.SplitQty
        param5.Value = Me.SplitQty
        param6.Direction = ParameterDirection.Output '?指定
        param4.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3, param4}
       
        '#If DEBUG Then
        '执行SP
        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpSaveSplitData2", Paramters)
'#Else
'          '执行SP
'        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpSaveSplitData", Paramters)
'#End If

        If err <> "" Then
            Return err
        Else
            If TypeOf param4.Value Is DBNull Then
                Return ""
            Else
                Return param4.Value.ToString()
            End If
        End If
    End Function
#End Region

    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress

        Try
            If Asc(e.KeyChar) = 13 Then
                Dim msg As String
                Dim strInput As String = txtInput.Text.Trim
                If strInput = "" Then
                    ShowMsg("输入不能为空")
                    Exit Sub
                End If
                '
                If Me.ScanStep = 1 Then
                    msg = ScanBusiness.VerifySnData(strInput, 2)
                    If msg <> "" Then
                        ShowMsg(msg)
                        Exit Sub
                    End If
                    '
                    Me.SerialNumber = strInput
                    LoadScanData(strInput)
                    ShowTips("请扫描工号")
                ElseIf Me.ScanStep = 2 Then '扫描员工编号
                    msg = ScanBusiness.VerifySnData(strInput, 1)
                    If msg <> "" Then
                        ShowMsg(msg)
                        Exit Sub
                    End If
                    Me.ScanerUserId = strInput
                    ShowTips("请扫描数量")
                ElseIf Me.ScanStep = 3 Then '扫描数量
                    msg = VerifyScanQty(strInput)
                    If msg <> "" Then
                        ShowMsg(msg)
                        Exit Sub
                    End If
                    'save data
                    msg = SaveSplitData()
                    If msg <> "" Then
                        ShowMsg(msg)
                        Exit Sub
                    End If
                    '刷新
                    LoadScanData(Me.SerialNumber)
                    '
                    IniteScanning()
                    ShowTips("请扫描工号")
                End If
                Me.ScanStep = Me.ScanStep + 1
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLotSplit", "txtInput_KeyPress", "WIP")
        End Try

    End Sub

    Private Sub FrmLotSplit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            IniteScanning()
            Me.lblTips.Text = "请扫描工站条码"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLotSplit", "FrmLotSplit_Load", "WIP")
        End Try

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            IniteScanning()
            Me.dgvSplitData.DataSource = Nothing
            Me.lblTips.Text = "请扫描工站条码"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLotSplit", "btnReset_Click", "WIP")
        End Try
    End Sub
End Class