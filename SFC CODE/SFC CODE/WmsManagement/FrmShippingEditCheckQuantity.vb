
'--仓库出货数量调整对话框
'--Create by :　马锋
'--Create date :　2015/09/25
'--Update date :  
'--Ver : V01

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
#End Region

Public Class FrmShippingEditCheckQuantity

#Region "变量声明"

    Dim _strShippingId As String
    Public Property ShippingId() As String
        Get
            Return _strShippingId
        End Get

        Set(value As String)
            _strShippingId = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _ShippingId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ShippingId = _ShippingId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmShippingEditCheckQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载数据异常!", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click
        If (String.IsNullOrEmpty(Me.txtQty.Text.Trim())) Then
            GetMesData.SetMessage(Me.lblMessage, "请输入调整出货数量!", False)
            Exit Sub
        End If

        If Not IsNumeric(Me.txtQty.Text.Trim) Then
            GetMesData.SetMessage(Me.lblMessage, "输入调整出货数量格式错误!", False)
            Exit Sub
        End If
        If (Int(Me.txtQty.Text.Trim) <= 0) Then
            GetMesData.SetMessage(Me.lblMessage, "输入调整出货数量必须大于0!", False)
            Exit Sub
        End If

        If (Not CheckSava()) Then
            Exit Sub
        End If

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim strSQL As String

            If (MessageBox.Show("你确定执行确认动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                strSQL = "UPDATE m_WhOutM_t SET  ShipCheckQty=N'" & Me.txtQty.Text.Trim & "'  WHERE Outwhid = '" & ShippingId & "'"
                Conn.ExecSql(strSQL)
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
                GetMesData.SetMessage(Me.lblMessage, "确定成功", False)
            End If
            Me.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "确定异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "函数"

    Private Sub LoadData()
        Try
            If (String.IsNullOrEmpty(ShippingId)) Then
                ClearStatus()
            Else
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Dim DReader As SqlClient.SqlDataReader
                Try
                    DReader = Conn.GetDataReader("SELECT ISNULL(Avcoutid, ''), ISNULL(CustDeliveryNO, ''), ISNULL(Saddress, ''), ISNULL(ShipCheckQty,'0') FROM m_WhOutM_t WHERE Outwhid='" & ShippingId & "' ")

                    If (DReader.HasRows) Then
                        DReader.Read()
                        Me.txtAvcoutid.Text = DReader.GetString(0)
                        Me.txtCustDeliveryNO.Text = DReader.GetString(1)
                        Me.txtQty.Text = DReader(3).ToString()
                    Else
                        ClearStatus()
                    End If

                    DReader.Close()
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Not DReader.IsClosed) Then
                        DReader.Close()
                    End If

                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    ClearStatus()
                    GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
                End Try
            End If
        Catch ex As Exception
            ClearStatus()
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub ClearStatus()
        Me.txtAvcoutid.Enabled = False
        Me.txtCustDeliveryNO.Enabled = False
        Me.txtQty.Enabled = False
        Me.btnDefine.Enabled = False
    End Sub

    Private Function CheckSava() As Boolean
        Dim rtValue As Boolean = False
        Dim strScanQty As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DReader As SqlClient.SqlDataReader
        Try
            DReader = Conn.GetDataReader("SELECT ISNULL(Shipqty,'0') FROM m_WhOutM_t WHERE Outwhid='" & ShippingId & "' ")

            If (DReader.HasRows) Then
                DReader.Read()
                strScanQty = DReader(0).ToString()

                DReader.Close()
                Conn.PubConnection.Close()

                If (CInt(Me.txtQty.Text.Trim) < strScanQty) Then
                    GetMesData.SetMessage(Me.lblMessage, "输入出货数量不能小于已扫描数量", False)
                Else
                    rtValue = True
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "获取单据信息失败", False)
            End If
        Catch ex As Exception
            If (Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常,请确认网络连接", False)
            rtValue = False
        End Try
        Return rtValue
    End Function
#End Region

  
End Class