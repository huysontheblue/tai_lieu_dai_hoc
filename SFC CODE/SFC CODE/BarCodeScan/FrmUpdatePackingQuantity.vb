
'--包装数量调整对话框
'--Create by :　马锋
'--Create date :　2015/10/08
'--Update date :  
'--Ver : V01

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
#End Region

Public Class FrmUpdatePackingQuantity

#Region "变量声明"

    Dim _strMoId As String
    Public Property MoId() As String
        Get
            Return _strMoId
        End Get

        Set(value As String)
            _strMoId = value
        End Set
    End Property

    Dim _strPackingId As String
    Public Property PackingId() As String
        Get
            Return _strPackingId
        End Get

        Set(value As String)
            _strPackingId = value
        End Set
    End Property

    Dim _strPackingType As String
    Public Property PackingType() As String
        Get
            Return _strPackingType
        End Get

        Set(value As String)
            _strPackingType = value
        End Set
    End Property

    Dim _strPackQuantity As String
    Public Property PackQuantity() As String
        Get
            Return _strPackQuantity
        End Get

        Set(value As String)
            _strPackQuantity = value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _MoId As String, ByVal _PackingId As String, ByVal _PackingType As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        MoId = _MoId
        PackingId = _PackingId
        PackingType = _PackingType
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmUpdatePackingQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadData()
        Catch ex As Exception
            ClearStatus()
            GetMesData.SetMessage(Me.lblMessage, "调整包装数量加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try

            If (Not CheckSava()) Then
                Exit Sub
            End If

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Try
                Dim strSQL As String=""

                If (MessageBox.Show("你确定执行确认动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                     Select (PackingType)
                        Case "1"
                            strSQL = "UPDATE m_PalletM_t SET Palletqty='" & Me.txtEditQuantity.Text.Trim & "' WHERE Palletid='" & PackingId & "' AND Moid='" & MoId & "'"
                        Case "2"
                            strSQL = "UPDATE m_Carton_t SET PackingQuantity='" & Me.txtEditQuantity.Text.Trim & "' WHERE Cartonid='" & PackingId & "' AND Moid='" & MoId & "'"
                    End Select

                    Conn.ExecSql(strSQL)
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "保存成功", False)
                End If
                Me.Close()
            Catch ex As Exception
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
                GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
            End Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

#Region "函数"

    Private Sub LoadData()
        Try
            Me.txtMoid.Text = MoId
            Me.txtPackingId.Text = PackingId

            If (String.IsNullOrEmpty(PackingId)) Then
                ClearStatus()
            Else
                Dim strSQL As New StringBuilder
                Select Case (PackingType)
                    Case "1"
                        Me.Text = "栈板数量调整"
                        strSQL.AppendLine(" SELECT m_PalletM_t.Palletid, MultiQty, Palletqty, SUM(ISNULL(m_Carton_t.Cartonqty, 0)), m_PalletM_t.PalletStatus   FROM m_PalletM_t ")
                        strSQL.AppendLine(" INNER JOIN m_PalletCarton_t ON m_PalletCarton_t.Palletid=m_PalletM_t.Palletid ")
                        strSQL.AppendLine(" INNER JOIN m_Carton_t ON m_PalletCarton_t.Cartonid=m_Carton_t.Cartonid")
                        strSQL.AppendLine(" WHERE m_PalletM_t.Palletid='" & PackingId & "' AND m_PalletM_t.Moid='" & MoId & "'")
                        strSQL.AppendLine(" GROUP BY  m_PalletM_t.Palletid, Palletqty, MultiQty, m_PalletM_t.PalletStatus ")
                    Case "2"
                        Me.Text = "箱数量调整"
                        strSQL.AppendLine(" SELECT m_Carton_t.Cartonid, PackingQuantity, Cartonqty, SUM(ISNULL(m_Cartonsn_t.ppidQty,1)), m_Carton_t.CartonStatus  FROM m_Carton_t ")
                        strSQL.AppendLine(" INNER JOIN m_Cartonsn_t ON m_Cartonsn_t.Cartonid=m_Carton_t.Cartonid ")
                        strSQL.AppendLine(" WHERE m_Carton_t.Cartonid='" & PackingId & "' AND m_Carton_t.Moid='" & MoId & "' ")
                        strSQL.AppendLine(" GROUP BY m_Carton_t.Cartonid, PackingQuantity, Cartonqty, m_Carton_t.CartonStatus ")
                End Select

                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Dim DReader As SqlClient.SqlDataReader = Nothing

                Try
                    DReader = Conn.GetDataReader(strSQL.ToString)

                    If (DReader.HasRows) Then
                        DReader.Read()

                        Me.txtQuantity.Text = Convert.ToString(DReader(2))
                        Me.txtEditQuantity.Text = Convert.ToString(DReader(3))
                        PackQuantity = Convert.ToString(DReader(3))

                        If (Convert.ToString(DReader(4)) = "Y") Then
                            Me.txtQuantity.Enabled = False
                            Me.btnDefine.Enabled = False
                        End If
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
        Me.txtEditQuantity.Enabled = False
        Me.btnDefine.Enabled = False
    End Sub

    Private Function CheckSava() As Boolean

        Try
            If (Not IsNumeric(Me.txtEditQuantity.Text.Trim())) Then
                GetMesData.SetMessage(Me.lblMessage, "输入的数量格式错误", False)
                Return False
            Else
                If (Convert.ToInt16(PackQuantity) > Convert.ToInt16(Me.txtEditQuantity.Text.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "输入的数量不能小于已经扫描数量", False)
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常,请确认网络连接", False)
            Return False
        End Try
    End Function
#End Region

End Class