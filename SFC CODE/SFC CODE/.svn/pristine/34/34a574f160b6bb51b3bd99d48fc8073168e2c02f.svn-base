
'--料件信息
'--Create by :　马锋
'--Create date :　2015/08/07
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

Public Class FrmMaterialMaster

#Region "变量声明"

    Shared _strMaterialCode As String
    Dim dtMaterialType As DataTable
    Dim dtTransactionType As DataTable
    Dim dtFIFOType As DataTable

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strMaterialCode As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strMaterialCode = strMaterialCode

    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmMaterialMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If Not (CheckSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Try
                Dim strQuantity As String = IIf(String.IsNullOrEmpty(Me.txtQuantity.Text.Trim), "0", Me.txtQuantity.Text.Trim)
                Dim strUnitPrice As String = IIf(String.IsNullOrEmpty(Me.txtUnitPrice.Text.Trim), "0", Me.txtUnitPrice.Text.Trim)
                strSQL.AppendLine(" INSERT INTO W_MATERIALS( MATERIAL_NO, DESCRIPTION, SPECIFICATION, UOM_NAME, UNITPRICE, CREATE_USERID, CREATE_TIME, QUANTITY, ")
                strSQL.AppendLine(" FIFO_TYPE, FIFO_RULE, Remark, STATUS, TYPEFLAG) VALUES( ")
                strSQL.AppendLine(" '" & Me.txtMaterialNO.Text.Trim & "', N'" & Me.txtDescription.Text.Trim.Replace("'", "''") & "', N'" & Me.txtSpecification.Text.Trim.Replace("'", "''") & "', N'" & Me.txtUnit.Text.Trim & "', '" & strUnitPrice & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), '" & strQuantity & "', ")
                strSQL.AppendLine(" '" & IIf(Me.chkFIFO.Checked, "Y", "N") & "', '" & IIf(IsDBNull(Me.cboFIFOType.SelectedValue), "NULL", Me.cboFIFOType.SelectedValue) & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "', '" & IIf(Me.chkActiveFlag.Checked, "0", "1") & "','" & Me.cboMaterialType.SelectedValue & "') ")

                If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                    Conn.ExecSql(strSQL.ToString())
                End If

                Conn.PubConnection.Close()
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

    Private Sub chkFIFO_CheckedChanged(sender As Object, e As EventArgs) Handles chkFIFO.CheckedChanged
        Try
            If (Me.chkFIFO.Checked) Then
                Me.cboFIFOType.Enabled = True
            Else
                Me.cboFIFOType.Enabled = False
                Me.cboFIFOType.SelectedIndex = -1
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改异常", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadData()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL = SQLStringHelper.GetSettingParameterSQL("MaterialType")
            dtMaterialType = Conn.GetDataTable(strSQL)

            strSQL = SQLStringHelper.GetSettingParameterSQL("TransactionType")
            dtTransactionType = Conn.GetDataTable(strSQL)

            strSQL = SQLStringHelper.GetSettingParameterSQL("FIFOType")
            dtFIFOType = Conn.GetDataTable(strSQL)

            Conn.PubConnection.Close()

            Me.cboFIFOType.DisplayMember = "PARAMETER_NAME"
            Me.cboFIFOType.ValueMember = "PARAMETER_VALUE"
            Me.cboFIFOType.DataSource = dtFIFOType

            Me.cboMaterialType.DisplayMember = "PARAMETER_NAME"
            Me.cboMaterialType.ValueMember = "PARAMETER_VALUE"
            Me.cboMaterialType.DataSource = dtMaterialType

            Me.cboTransactionType.DisplayMember = "PARAMETER_NAME"
            Me.cboTransactionType.ValueMember = "PARAMETER_VALUE"
            Me.cboTransactionType.DataSource = dtTransactionType


        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (String.IsNullOrEmpty(Me.txtMaterialNO.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入料号", False)
                Exit Function
            End If

            If Not (String.IsNullOrEmpty(Me.txtQuantity.Text.Trim)) Then
                If Not IsNumeric(Me.txtQuantity.Text.Trim) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入数量格式错误", False)
                    Exit Function
                End If
                If (CDbl(Me.txtQuantity.Text.Trim) <= 0) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入数量不能小于0", False)
                    Exit Function
                End If
            End If

            If Not (String.IsNullOrEmpty(Me.txtUnitPrice.Text.Trim)) Then
                If Not IsNumeric(Me.txtUnitPrice.Text.Trim) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入单价格式错误", False)
                    Exit Function
                End If
                If (CDbl(Me.txtUnitPrice.Text.Trim) <= 0) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入单价不能小于0", False)
                    Exit Function
                End If
            End If

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim DReader As SqlClient.SqlDataReader
            Try

                Dim strSQL As String
                Dim strWhere As String = ""

                strSQL = "SELECT MATERIAL_ID FROM W_MATERIALS WHERE  MATERIAL_NO='" & Me.txtMaterialNO.Text.Trim & "'"


                DReader = Conn.GetDataReader(strSQL)
                If (DReader.HasRows) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "输入料号已经存在", False)
                Else
                    rtValue = True
                End If

                DReader.Close()
                Conn.PubConnection.Close()

            Catch ex As Exception
                If Not (DReader.IsClosed) Then
                    DReader.Close()
                End If
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If

                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "检查料号是否存在异常", False)
            End Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

#End Region


    
End Class