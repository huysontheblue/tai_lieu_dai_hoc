
'--物料粘贴
'--Create by :　马锋
'--Create date :　2015/07/23
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

Public Class FrmBulkPasteMaterialQuery

#Region "变量声明"

    Dim _MaterialList As DataTable
#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dtSelectMaterial As DataTable)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _MaterialList = dtSelectMaterial

    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmBulkPasteMaterialQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvSelectMaterial.AutoGenerateColumns = False
            Me.dgvSelectMaterial.Rows.Add(7)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

    End Sub

    Private Sub btnGeneration_Click(sender As Object, e As EventArgs) Handles btnGeneration.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (String.IsNullOrEmpty(Me.txtPasteMaterial.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "料号信息不能为空", False)
                Exit Sub
            End If

            Dim arrMaterialList As Array
            Dim dtTemp As DataTable
            Dim strMaterialNoTemp As String
            Dim drTemp As DataRow
            Dim CheckMaterial As Boolean = False

            arrMaterialList = Split(Me.txtPasteMaterial.Text.Trim, vbLf)
            If (arrMaterialList.Length > 0) Then
                For i As Int32 = 0 To arrMaterialList.Length - 1
                    If (String.IsNullOrEmpty(arrMaterialList(i).ToString.Trim.Replace("\N", ""))) Then
                        Continue For
                    End If
                    If (_MaterialList.Rows.Count > 0) Then
                        For j As Int16 = 0 To _MaterialList.Rows.Count - 1
                            strMaterialNoTemp = _MaterialList.Rows(j).Item("MATERIALNO").ToString.Trim
                            If (arrMaterialList(i).ToString.Trim.Replace("\N", "") = strMaterialNoTemp) Then
                                CheckMaterial = True
                                Exit For
                            End If
                        Next
                        If (CheckMaterial) Then
                            Continue For
                        End If
                    End If
                    dtTemp = GetMesData.GetMaterialQuery(arrMaterialList(i).ToString.Trim.Replace("\N", ""))
                    If (dtTemp.Rows.Count > 0) Then

                        drTemp = _MaterialList.NewRow
                        drTemp("MATERIALNO") = dtTemp.Rows(0).Item("MATERIALNO").ToString
                        drTemp("DESCRIPTION") = dtTemp.Rows(0).Item("DESCRIPTION").ToString
                        drTemp("SPECIFICATION") = dtTemp.Rows(0).Item("SPECIFICATION").ToString
                        drTemp("UOM_NAME") = dtTemp.Rows(0).Item("UOM_NAME").ToString
                        'QUANTITY
                        drTemp("STOCKQUANTITY") = dtTemp.Rows(0).Item("QUANTITY").ToString
                        drTemp("UNITPRICE") = dtTemp.Rows(0).Item("UNITPRICE").ToString

                        drTemp("TransactionType") = "0"

                        If (_MaterialList.Columns.Contains("ProfitQuantity")) Then
                            drTemp("ProfitQuantity") = 0
                        End If
                        If (_MaterialList.Columns.Contains("LossQuantity")) Then
                            drTemp("LossQuantity") = 0
                        End If
                        _MaterialList.Rows.Add(drTemp)
                        _MaterialList.AcceptChanges()
                    End If
                Next
                Me.dgvSelectMaterial.DataSource = _MaterialList
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "解析异常", False)
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "确定异常", False)
        End Try
    End Sub
#End Region

#Region "函数"


#End Region

    
End Class