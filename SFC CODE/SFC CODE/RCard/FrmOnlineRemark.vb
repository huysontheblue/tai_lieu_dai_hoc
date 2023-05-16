Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass
Public Class FrmOnlineRemark

#Region "产品料号"
    Private _SopId As String
    Public Property SopId() As String
        Get
            Return _SopId
        End Get

        Set(ByVal Value As String)
            _SopId = Value
        End Set
    End Property

#End Region

    Private _actionType As String
    Public Property actionType() As String
        Get
            Return _actionType
        End Get

        Set(ByVal Value As String)
            _actionType = Value
        End Set
    End Property
#Region "构造函数"

    Sub New(ByVal Id As String,Optional ByVal actionType As String ="")

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me._SopId = Id
        Me._actionType = actionType

    End Sub
#End Region

#Region "事件"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(Me.txtRemark.Text.Trim) Then
            Me.lbMsg.Text = "请输入备注!"
            Me.txtRemark.Focus()
        End If
        If SaveData() = True Then

            '退出
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"
    Public Function SaveData() As Boolean
        Dim r As Boolean = False
        Try
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim UserName As String = VbCommClass.VbCommClass.UseName
            Dim o_strSql As String = "", strRemark As String =""
            If Not String.IsNullOrEmpty(actionType) Then
                strRemark = actionType + Me.txtRemark.Text.Trim
                o_strSql = String.Format("UPDATE m_OnlineSop_t SET RemarkSign =N'{0}' where docID=N'{1}'", strRemark, SopId)
            Else
                strRemark = Me.txtRemark.Text.Trim
                o_strSql = String.Format("UPDATE m_OnlineSopItem_t set Remark =N'{0}' where Id=N'{1}'", strRemark, SopId)
            End If

            DbOperateUtils.ExecSQL(o_strSql)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineRemark", "SaveData()", "sys")
        End Try
        Return True
    End Function
#End Region
End Class