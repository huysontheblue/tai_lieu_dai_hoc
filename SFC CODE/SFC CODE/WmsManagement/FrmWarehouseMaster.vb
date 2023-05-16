
'--仓库管理
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

Public Class FrmWarehouseMaster

#Region "变量声明"
    Shared _strWarehouseId As String
    Shared _strStatusFlag As String            '单据审核状态

    Public Shared Property strWarehouseId() As String
        Get
            Return _strWarehouseId
        End Get

        Set(value As String)
            _strWarehouseId = value
        End Set
    End Property

    Public Shared Property strStatusFlag() As String
        Get
            Return _strStatusFlag
        End Get

        Set(value As String)
            _strStatusFlag = value
        End Set
    End Property

    Dim dtWarehouseLocation As DataTable
#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _WarehouseId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        strWarehouseId = _WarehouseId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmWarehouseMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvWarehouseLocation.AutoGenerateColumns = False
            '基础数据加载
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (Not dtWarehouseLocation Is Nothing) Then
                dtWarehouseLocation.Rows.Add(1)
            Else
                Me.dgvWarehouseLocation.Rows.Add(1)
            End If
            'Me.dgvWarehouseLocation.DataSource = GetMesData.GetWarehouseLocation(strWarehouseId, "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增失败", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Me.dgvWarehouseLocation.Rows.Count = 0 OrElse Me.dgvWarehouseLocation.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除库位", False)
                Exit Sub
            End If
            Dim strWarehouseLoactionId As String
            strWarehouseLoactionId = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(Me.dgvWarehouseLocation.CurrentRow.Index).Cells("WarehouseLocationId").Value), "", Me.dgvWarehouseLocation.Rows(Me.dgvWarehouseLocation.CurrentRow.Index).Cells("WarehouseLocationId").Value)
            If (Not String.IsNullOrEmpty(strWarehouseLoactionId)) Then
                Dim strSQL As String
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL = "UPDATE m_WarehouseLocation_t SET StatusFlag='0' WHERE WarehouseLocationId='" & strWarehouseLoactionId & "' AND WarehouseId='" & strWarehouseId & "'"
                    Conn.ExecSql(strSQL)
                    Conn.PubConnection.Close()

                    Me.dgvWarehouseLocation.Rows(Me.dgvWarehouseLocation.CurrentRow.Index).Cells("StatusFlag").Value = "无效"
                    GetMesData.SetMessage(Me.lblMessage, "删除成功", False)
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                    Exit Sub
                End Try
            Else
                Me.dgvWarehouseLocation.Rows.RemoveAt(Me.dgvWarehouseLocation.CurrentRow.Index)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除失败", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not (CheckSave()) Then
                Exit Sub
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存失败", False)
        End Try

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            If (String.IsNullOrEmpty(strWarehouseId)) Then
                strSQL.AppendLine(" INSERT INTO m_Warehouse_t( FactoryId, Profitcenter, WarehouseCode, WarehouseName, StatusFlag, CreateUser, CreateTime) VALUES('" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', N'" & Me.txtWarehouseCode.Text.Trim & "', N'" & Me.txtWarehouseName.Text.Trim & "', '" & IIf(Me.chkStatusFlag.Checked = True, "1", "0") & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
            Else
                strSQL.AppendLine(" UPDATE m_Warehouse_t SET WarehouseName = N'" & Me.txtWarehouseName.Text.Trim & "', StatusFlag = '" & IIf(Me.chkStatusFlag.Checked = True, "1", "0") & "' WHERE WarehouseCode='" & strWarehouseId & "'")
            End If

            Dim strWarehouseLoactionCode As String
            Dim strWarehouseLoactionName As String
            Dim strWarehouseLoactionType As String
            Dim strMaterialNo As String

            For i As Int32 = 0 To Me.dgvWarehouseLocation.Rows.Count - 1
                strWarehouseLoactionCode = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value)
                strWarehouseLoactionName = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationName").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationName").Value)
                strWarehouseLoactionType = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationType").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationType").Value)
                strMaterialNo = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("MaterialNO").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("MaterialNO").Value)

                If (IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationId").Value) Or Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationId").Value Is Nothing) Then
                    strSQL.AppendLine(" INSERT INTO m_WarehouseLocation_t(WarehouseId, WarehouseLocationCode, WarehouseLocationName, WarehouseLocationType, MaterialNO, StatusFlag, CreateUser,  CreateTime) VALUES(N'" & Me.txtWarehouseCode.Text.Trim & "', N'" & strWarehouseLoactionCode & "', N'" & strWarehouseLoactionName & "', N'" & strWarehouseLoactionType & "', N'" & strMaterialNo & "', '1' , '" & VbCommClass.VbCommClass.UseId & "',GETDATE())")
                Else
                    strSQL.AppendLine(" UPDATE m_WarehouseLocation_t SET WarehouseLocationName = N'" & strWarehouseLoactionName & "', WarehouseLocationType = N'" & strWarehouseLoactionType & "', MaterialNO = N'" & strMaterialNo & "' WHERE WarehouseLocationCode='" & strWarehouseLoactionCode & "' ")
                End If
            Next

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
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "取消失败", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadControlData()
        If (String.IsNullOrEmpty(strWarehouseId)) Then
            Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
        Else

            Dim dtTemp As DataTable
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Try

                dtTemp = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, strWarehouseId)

                If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                    Me.txtWarehouseCode.Text = dtTemp.Rows(0).Item("WarehouseCode").ToString
                    Me.txtWarehouseName.Text = dtTemp.Rows(0).Item("WarehouseNameAliases").ToString
                    Me.txtCreateUser.Text = dtTemp.Rows(0).Item("CreateUser").ToString
                    Me.txtCreateTime.Text = dtTemp.Rows(0).Item("CreateTime").ToString
                    Me.chkStatusFlag.Checked = IIf(dtTemp.Rows(0).Item("StatusFlag").ToString = "有效", True, False)
                    Me.txtWarehouseCode.Enabled = False
                    dtWarehouseLocation = GetMesData.GetWarehouseLocation(strWarehouseId, "")
                    Me.dgvWarehouseLocation.DataSource = dtWarehouseLocation
                End If
            Catch ex As Exception
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
                GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
            End Try
        End If
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = True
        Try
            If (String.IsNullOrEmpty(Me.txtWarehouseCode.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入仓库代码", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.txtWarehouseName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请输入仓库名称", False)
                Exit Function
            End If

            If (GetMesData.CheckWarehouse(strWarehouseId, Me.txtWarehouseCode.Text.Trim, lblMessage)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "输入仓库代码已经存在", False)
                Exit Function
            End If

            If (Me.dgvWarehouseLocation.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim strWarehouseLoactionCode As String
                Dim strWarehouseLoactionId As String
                Dim strMaterialNo As String
                Dim strMaterialNOCheck As String
                Dim CheckCode As Boolean = True
                For i As Int16 = 0 To Me.dgvWarehouseLocation.Rows.Count - 1

                    If (IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value) Or Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value Is Nothing) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "请输入第'" & i & "'行库位代码", False)
                        Exit For
                    End If

                    strMaterialNo = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("MaterialNO").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("MaterialNO").Value)

                    For j As Int16 = 0 To i
                        If (j <> i) Then
                            If (Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value = Me.dgvWarehouseLocation.Rows(j).Cells("WarehouseLocationCode").Value) Then
                                CheckCode = False
                                GetMesData.SetMessage(Me.lblMessage, "请输入第'" & i & "'行和第'" & i & "'行库位代码不能相同", False)
                                Exit For
                            End If
                            strMaterialNOCheck = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(j).Cells("MaterialNO").Value), "", Me.dgvWarehouseLocation.Rows(j).Cells("MaterialNO").Value)
                            If (Not String.IsNullOrEmpty(strMaterialNo)) Then
                                If (Not String.IsNullOrEmpty(strMaterialNOCheck)) Then
                                    If (Me.dgvWarehouseLocation.Rows(i).Cells("MaterialNO").Value.ToString.Trim = Me.dgvWarehouseLocation.Rows(j).Cells("MaterialNO").Value.ToString.Trim) Then
                                        CheckCode = False
                                        GetMesData.SetMessage(Me.lblMessage, "请输入第'" & i & "'行和第'" & i & "'行料件代码不能相同", False)
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If (CheckCode = False) Then
                        Exit For
                    End If

                    If (Not String.IsNullOrEmpty(strMaterialNo)) Then
                        strWarehouseLoactionCode = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationCode").Value)
                        strWarehouseLoactionId = IIf(IsDBNull(Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationId").Value), "", Me.dgvWarehouseLocation.Rows(i).Cells("WarehouseLocationId").Value)

                        If (Not GetMesData.CheckLocationMaterial(strWarehouseLoactionId, strWarehouseLoactionCode, strMaterialNo, Me.lblMessage)) Then
                            rtValue = False
                            GetMesData.SetMessage(Me.lblMessage, "请输入第'" & i & "'行库位对应料号/库位已经存在", False)
                            Exit For
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try
        Return rtValue
    End Function


#End Region


End Class