Imports System.Windows.Forms

Public Class FrmPrtVer
    Private _PartID As String
    Public Property PartID() As String
        Get
            Return _PartID
        End Get

        Set(ByVal Value As String)
            _PartID = Value
        End Set
    End Property
    Private _MoID As String
    Public Property MoID() As String
        Get
            Return _MoID
        End Get

        Set(ByVal Value As String)
            _MoID = Value
        End Set
    End Property
    Private _Message As String
    Public Property Message() As String
        Get
            Return _Message
        End Get

        Set(ByVal Value As String)
            _Message = Value
        End Set
    End Property
    Private _CustVer As String
    Public Property CustVer() As String
        Get
            Return _CustVer
        End Get

        Set(ByVal Value As String)
            _CustVer = Value
        End Set
    End Property
    Private _SpeVer As String
    Public Property SpeVer() As String
        Get
            Return _SpeVer
        End Get

        Set(ByVal Value As String)
            _SpeVer = Value
        End Set
    End Property
    Private _ConfirmVer As String
    Public Property ConfirmVer() As String
        Get
            Return _ConfirmVer
        End Get

        Set(ByVal Value As String)
            _ConfirmVer = Value
        End Set
    End Property

    Private _Flag As Boolean
    Public Property Flag() As Boolean
        Get
            Return _Flag
        End Get

        Set(ByVal Value As Boolean)
            _Flag = Value
        End Set
    End Property
    Sub New(ByVal custver As String, ByVal specver As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.CustVer = custver
        Me.SpeVer = specver
        Me.Flag = False
    End Sub

    Private Sub FrmPrtVer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblMessage.Text = "TT中此工单对应的客户版本为" + Me.CustVer + ",请确认需要打印的标签版本！"
        Me.ChkCustVer.Text = Me.CustVer
        Me.ChkSpeVer.Text = Me.SpeVer

    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Me.Flag = False
        If Me.ChkSpeVer.Checked = False And ChkCustVer.Checked = False Then
            MessageBox.Show("请选择版本", "版本确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Me.ChkSpeVer.Checked = True And ChkCustVer.Checked = True Then
            MessageBox.Show("只能选择一个版本", "版本确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Me.ChkSpeVer.Checked = True Then
            Me.ConfirmVer = ChkSpeVer.Text
            Me.Flag = True
            Me.Close()
        End If
        If Me.ChkCustVer.Checked = True Then
            Me.ConfirmVer = ChkCustVer.Text
            Me.Flag = True
            Me.Close()
        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Flag = False
        Me.Close()
    End Sub

    Private Sub FrmPrtVer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '  Me.Flag = False
    End Sub
End Class