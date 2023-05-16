Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Collections
Imports System.Xml
Imports System.IO
Imports MainFrame

Public Class FrmSampleSet

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Private Sub FrmNoBarCodeSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMsg.Text = ""
        Dim lsSQL As String = ""
        lsSQL = _
                "SELECT A.Cusid, B.CusName" + vbCrLf + _
                "  FROM (  SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_Mainmo_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''" + vbCrLf + _
                "        UNION" + vbCrLf + _
                "        SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_PartContrast_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''  ) A" + vbCrLf + _
                "       INNER JOIN m_Customer_t B ON A.Cusid = B.CusID" + vbCrLf + _
                "ORDER BY A.Cusid"

        LoadDataToCob(lsSQL, CboSupport) ''填充客戶
        InitailUI()
    End Sub

    Private Sub InitailUI()
        If String.IsNullOrEmpty(Data.SampleNOStr) Then
            ' Me.lblMOType.Text = "" : Me.lblMOQty.Text = "" : Me.lblPartID.Text = ""
        Else
            Me.CboSupport.SelectedIndex = Me.CboSupport.FindString(Data.CustID)
            Me.mtxtMOID.Text = Data.MoidStr

        End If
    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0) & "(" & PubDataReader.GetString(1) & ")")
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub

    Private Sub ButConfirm_Click(sender As Object, e As EventArgs) Handles ButConfirm.Click
        If ContorlCheck() = True Then
            getPartStyle()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub getPartStyle()  ''WorkStantOption
        Data.MoidStr = Me.mtxtMOID.Text
        Data.MoidqtyStr = lblMOQty.Text
        Data.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
        Data.CustID = CboSupport.Text.Split("(")(0)
        Data.PartidStr = lblPartID.Text
        Data.LineStr = lblLineID.Text
        Data.SampleNOStr = lblSampleNo.text
    End Sub

    Private Function ContorlCheck() As Boolean
        If Me.CboSupport.Text = "" Then
            MessageUtils.ShowError("客戶名稱不能為空！")
            CboSupport.Focus()
            CboSupport.SelectAll()
            Return False
        End If

        If Me.mtxtMOID.Text = "" Then
            MessageUtils.ShowError("工單編號不能為空！")
            mtxtMOID.Focus()
            Me.mtxtMOID.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub CboSupport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSupport.SelectedIndexChanged
        Me.mtxtMOID.Text = String.Empty

        Me.lblMOType.Text = ""
        Me.lblSampleNo.Text = ""
        Me.lblPartID.Text = ""
    End Sub

    Private Sub LoadDataToCboMoid(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0))
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOID.TextChanged

    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOID.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmSampleMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmMOQuery.ShowDialog()
            Me.lblSampleNo.Text = frmMOQuery.m_strSampleNO
            Me.lblMOQty.Text = frmMOQuery.m_strQty  'Add by cq 20161107
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Close()
    End Sub

End Class
