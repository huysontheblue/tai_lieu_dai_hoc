
'--供应商新增
'--Create by :　马锋
'--Create date :　2015/07/15
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
#End Region

Public Class FrmSupplierMaster

#Region "变量声明"

    Dim _strSupplierCode As String

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strSupplierCode As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strSupplierCode = strSupplierCode

    End Sub

#End Region

    Private Sub FrmSupplierMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not (String.IsNullOrEmpty(_strSupplierCode)) Then
                Dim dtSupplier As DataTable
                dtSupplier = GetMesData.GetSupplierList(_strSupplierCode)
                If (Not dtSupplier Is Nothing And dtSupplier.Rows.Count > 0) Then
                    Me.chkActiveFlag.Checked = IIf(dtSupplier.Rows(0).Item("ActiveFlag").ToString = "Y", True, False)
                    Me.txtSupplierName.Text = dtSupplier.Rows(0).Item("SupplierName").ToString
                    Me.txtSupplierCode.Text = dtSupplier.Rows(0).Item("SupplierCode").ToString
                    Me.txtAreaClassification.Text = dtSupplier.Rows(0).Item("AreaClassification").ToString
                    Me.txtContactsName.Text = dtSupplier.Rows(0).Item("ContactsName").ToString
                    Me.txtContactsTelphone.Text = dtSupplier.Rows(0).Item("ContactsTelphone").ToString
                    Me.txtFax.Text = dtSupplier.Rows(0).Item("Fax").ToString
                    Me.txtAddress.Text = dtSupplier.Rows(0).Item("Address").ToString
                    Me.txtZipCode.Text = dtSupplier.Rows(0).Item("ZipCode").ToString
                    Me.txtTaxId.Text = dtSupplier.Rows(0).Item("TaxId").ToString
                    Me.txtInternetSite.Text = dtSupplier.Rows(0).Item("InternetSite").ToString
                    Me.txtRemark.Text = dtSupplier.Rows(0).Item("Remark").ToString
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If (Not CheckSave()) Then
            Exit Sub
        End If

        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            Dim strSupplierType As String

            If (Me.chkCustomer.Checked And Me.chkSupplier.Checked) Then
                strSupplierType = "3"
            Else
                If (Me.chkCustomer.Checked) Then
                    strSupplierType = "1"
                End If

                If (Me.chkSupplier.Checked) Then
                    strSupplierType = "2"
                End If
            End If

            If (String.IsNullOrEmpty(_strSupplierCode)) Then
                strSQL = "INSERT INTO m_Supplier_t( SupplierCode, SupplierName, SupplierType, AreaClassification, ContactsName " & _
                         ", ContactsTelphone, Fax, Address, ZipCode, TaxId, InternetSite, Remark, ActiveFlag, CreateUser, CreateTime)" & _
                         "VALUES( '" & Me.txtSupplierCode.Text.Trim.Replace("'", "''") & "', N'" & Me.txtSupplierName.Text.Trim.Replace("'", "''") & "', '" & strSupplierType & "', N'" & Me.txtAreaClassification.Text.Trim.Replace("'", "''") & "', N'" & Me.txtContactsName.Text.Trim.Replace("'", "''") & "', N'" & Me.txtContactsTelphone.Text.Trim.Replace("'", "''") & "', N'" & Me.txtFax.Text.Trim.Replace("'", "''") & _
                         "', N'" & Me.txtAddress.Text.Trim.Replace("'", "''") & "', N'" & Me.txtZipCode.Text.Trim.Replace("'", "''") & "', N'" & Me.txtTaxId.Text.Trim.Replace("'", "''") & "', N'" & Me.txtInternetSite.Text.Trim.Replace("'", "''") & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "', '" & IIf(Me.chkActiveFlag.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper.Trim & "',GetDate())"
            Else
                strSQL = "UPDATE m_Supplier_t SET SupplierCode='" & Me.txtSupplierCode.Text.Trim.Replace("'", "''") & "', SupplierName= N'" & Me.txtSupplierName.Text.Trim.Replace("'", "''") & "', SupplierType='" & strSupplierType & "', AreaClassification=N'" & Me.txtAreaClassification.Text.Trim.Replace("'", "''") & "', ContactsName =N'" & Me.txtContactsName.Text.Trim.Replace("'", "''") & "'," & _
                         "ContactsTelphone= N'" & Me.txtContactsTelphone.Text.Trim.Replace("'", "''") & "', Fax=N'" & Me.txtFax.Text.Trim.Replace("'", "''") & "', Address=N'" & Me.txtAddress.Text.Trim.Replace("'", "''") & "',ZipCode=N'" & Me.txtZipCode.Text.Trim.Replace("'", "''") & "'," & _
                         "TaxId= N'" & Me.txtTaxId.Text.Trim.Replace("'", "''") & "', InternetSite=N'" & Me.txtInternetSite.Text.Trim.Replace("'", "''") & "',Remark=N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',ActiveFlag='" & IIf(Me.chkActiveFlag.Checked, "Y", "N") & "',UpdateUser='" & SysMessageClass.UseId.ToUpper.Trim & "', UpdateTime=GetDate() " & _
                         " WHERE SupplierCode='" & _strSupplierCode & "'"
            End If
            Conn.ExecSql(strSQL)
            Conn.PubConnection.Close()
            Me.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function CheckSave() As Boolean

        If (String.IsNullOrEmpty(Me.txtSupplierCode.Text.Trim())) Then
            GetMesData.SetMessage(Me.lblMessage, "供应商代码不能为空!", False)
            Return False
        End If

        If (String.IsNullOrEmpty(Me.txtSupplierName.Text.Trim())) Then
            GetMesData.SetMessage(Me.lblMessage, "供应商名称不能为空!", False)
            Return False
        End If

        Dim strCheckSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim ReTable As SqlDataReader
        Try
            If (String.IsNullOrEmpty(_strSupplierCode)) Then
                strCheckSQL = "SELECT SupplierCode FROM m_Supplier_t WHERE SupplierCode='" & Me.txtSupplierCode.Text.Trim.Replace("'", "''") & "'"
            Else
                strCheckSQL = "SELECT SupplierCode FROM m_Supplier_t WHERE SupplierCode='" & Me.txtSupplierCode.Text.Trim.Replace("'", "''") & "' AND SupplierCode<>'" & _strSupplierCode & "'"
            End If

            ReTable = Conn.GetDataReader(strCheckSQL)

            If (ReTable.HasRows) Then
                ReTable.Close()
                Conn.PubConnection.Close()
                GetMesData.SetMessage(Me.lblMessage, "供应商代码已经存在!", False)
                Return False
            End If
            ReTable.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (ReTable.IsClosed = False) Then
                ReTable.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try

        Return True
    End Function
End Class