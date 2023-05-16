
'--仓库出货确认对话框
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
Imports MainFrame

#End Region

Public Class FrmShippingWarehouseCheck

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

    Private Sub FrmShippingWarehouseCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载数据异常!", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click
        If (String.IsNullOrEmpty(Me.txtSaddress.Text.Trim())) Then
            GetMesData.SetMessage(Me.lblMessage, "请输入出货地址!", False)
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strResult As String

            If (Me.rBtnPass.Checked) Then
                strResult = "1"
            Else
                strResult = "2"
            End If

            If (MessageBox.Show("你确定执行确认动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                strSQL = "UPDATE m_WhOutM_t SET  Saddress=N'" & Me.txtSaddress.Text.Trim.Replace("'", "''") & "', WarehouseCheckStatus='" & strResult &
                    "', WarehouseCheckNote=N'" & Me.txtWarehouseCheckNote.Text.Trim.Replace("'", "''") & "', WarehouseCheckUserId='" & VbCommClass.VbCommClass.UseId &
                    "', WarehouseCheckTime=GETDATE()  WHERE Outwhid = '" & ShippingId & "'"
                DbOperateUtils.ExecSQL(strSQL)
              
                GetMesData.SetMessage(Me.lblMessage, "确定成功", False)
            End If
            Me.Close()
        Catch ex As Exception
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
                Dim DReader As DataTable
                Try
                    DReader = DbOperateUtils.GetDataTable("SELECT ISNULL(Avcoutid, ''), ISNULL(CustDeliveryNO, ''), ISNULL(Saddress, '') FROM m_WhOutM_t WHERE Outwhid='" & ShippingId & "' ")

                    If (DReader.Rows.Count > 0) Then
                        Me.txtAvcoutid.Text = DReader.Rows(0)(0)
                        Me.txtCustDeliveryNO.Text = DReader.Rows(0)(1)
                        Me.txtSaddress.Text = DReader.Rows(0)(2)
                        Me.ActiveControl = Me.txtSaddress
                    Else
                        ClearStatus()
                    End If

                Catch ex As Exception
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
        Me.txtSaddress.Enabled = False
        Me.txtWarehouseCheckNote.Enabled = False
        Me.rBtnPass.Enabled = False
        Me.rBtnReject.Enabled = False
        Me.btnDefine.Enabled = False
    End Sub
#End Region

End Class