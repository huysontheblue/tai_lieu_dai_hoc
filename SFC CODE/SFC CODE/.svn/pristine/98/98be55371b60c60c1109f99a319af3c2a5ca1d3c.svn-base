
'--库位管理
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

Public Class FrmWarehouseManagment

#Region "加载事件"

    Private Sub FrmWarehouseManagment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvWarehouse.AutoGenerateColumns = False
            Me.dgvWarehouseLocation.AutoGenerateColumns = False
            '基础数据加载
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnDownWarehouse_Click(sender As Object, e As EventArgs) Handles btnDownWarehouse.Click
        Try
            If (MsgBox("你确定执行仓库下载，将删除原有数据!", 4 + 32) = MsgBoxResult.No) Then
                Return
            End If

            Dim strSQL As New StringBuilder
            Dim dvWarehouse As DataView
            dvWarehouse = GetTiptopDate.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            If (Not dvWarehouse Is Nothing And dvWarehouse.Count > 0) Then
                Dim strWarehouseCode As String
                Dim strWarehouseName As String

                For I As Int16 = 0 To dvWarehouse.Count - 1
                    strWarehouseCode = dvWarehouse.Item(I).Item("IMD01").ToString
                    strWarehouseName = dvWarehouse.Item(I).Item("IMD02").ToString

                    strSQL.AppendLine(" IF NOT EXISTS( SELECT WarehouseCode FROM m_Warehouse_t WHERE WarehouseCode='" & strWarehouseCode & "') BEGIN ")
                    strSQL.AppendLine(" INSERT INTO m_Warehouse_t(FactoryId, Profitcenter, WarehouseCode, WarehouseName, CreateUser, CreateTime) VALUES('" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & strWarehouseCode & "', N'" & strWarehouseName & "', '" & VbCommClass.VbCommClass.UseId & "', Getdate()) END ")

                Next

                If (Not String.IsNullOrEmpty(strSQL.ToString())) Then
                    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                    Try
                        Conn.ExecSql(strSQL.ToString())
                        Conn.PubConnection.Close()
                    Catch ex As Exception
                        If (Conn.PubConnection.State = ConnectionState.Open) Then
                            Conn.PubConnection.Close()
                        End If
                    End Try
                End If
            End If
            GetMesData.SetMessage(Me.lblMessage, "下载成功", True)
            Me.dgvWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtWarehouseCode.Text.Trim())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDownWarehouseLocation_Click(sender As Object, e As EventArgs) Handles btnDownWarehouseLocation.Click
        Try
            If (MsgBox("你确定执行储位下载，将删除原有数据!", 4 + 32) = MsgBoxResult.No) Then
                Return
            End If

            If Me.dgvWarehouse.Rows.Count = 0 OrElse Me.dgvWarehouse.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要下载仓库", False)
                Exit Sub
            End If

            Dim strWarehouseId As String
            strWarehouseId = Me.dgvWarehouse.Rows(Me.dgvWarehouse.CurrentRow.Index).Cells("WarehouseCode").Value
            If (String.IsNullOrEmpty(strWarehouseId)) Then
                GetMesData.SetMessage(Me.lblMessage, "下载仓库代码不能为空", False)
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim dvWarehouseLocation As DataView
            dvWarehouseLocation = GetTiptopDate.GetWarehouseLocation(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, strWarehouseId)

            If (Not dvWarehouseLocation Is Nothing And dvWarehouseLocation.Count > 0) Then
                Dim strWarehouseLocationCode As String
                Dim strWarehouseLocationName As String
                Dim strWarehouseLocationType As String

                For I As Int16 = 0 To dvWarehouseLocation.Count - 1
                    strWarehouseLocationCode = dvWarehouseLocation.Item(I).Item("IME02").ToString
                    strWarehouseLocationName = dvWarehouseLocation.Item(I).Item("IME03").ToString
                    strWarehouseLocationType = dvWarehouseLocation.Item(I).Item("IME04").ToString

                    strSQL.AppendLine(" IF NOT EXISTS( SELECT WarehouseLocationCode FROM m_WarehouseLocation_t WHERE WarehouseLocationCode='" & strWarehouseLocationCode & "') BEGIN ")
                    strSQL.AppendLine(" INSERT INTO m_WarehouseLocation_t(WarehouseId, WarehouseLocationCode, WarehouseLocationName, WarehouseLocationType, CreateUser, CreateTime) VALUES('" & strWarehouseId & "', '" & strWarehouseLocationCode & "', '" & strWarehouseLocationName & "', N'" & strWarehouseLocationType & "', '" & VbCommClass.VbCommClass.UseId & "', Getdate()) END ")

                Next

                If (Not String.IsNullOrEmpty(strSQL.ToString())) Then
                    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                    Try
                        Conn.ExecSql(strSQL.ToString())
                        Conn.PubConnection.Close()
                    Catch ex As Exception
                        If (Conn.PubConnection.State = ConnectionState.Open) Then
                            Conn.PubConnection.Close()
                        End If
                    End Try
                End If
            End If
            Me.dgvWarehouseLocation.DataSource = GetMesData.GetWarehouseLocation(strWarehouseId, "")
            GetMesData.SetMessage(Me.lblMessage, "下载成功", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvOrderTranscation_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWarehouse.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvWarehouse.Rows.Count = 0 OrElse Me.dgvWarehouse.CurrentRow Is Nothing Then
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.dgvWarehouse.Rows(Me.dgvWarehouse.CurrentRow.Index).Cells("WarehouseCode").Value)) Then
            GetMesData.SetMessage(Me.lblMessage, "仓库代码不能为空", False)
            Exit Sub
        End If
        Try
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Try

                Dim strSQL As String

                strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY WarehouseLocationId )as RowNum, WarehouseLocationId, WarehouseLocationCode, WarehouseLocationName, WarehouseLocationType, CreateUser, CreateTime, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlag FROM  m_WarehouseLocation_t WHERE WarehouseId = '" & Me.dgvWarehouse.Rows(Me.dgvWarehouse.CurrentRow.Index).Cells("WarehouseCode").Value & "' "

                Me.dgvWarehouseLocation.DataSource = Conn.GetDataTable(strSQL)
                Conn.PubConnection.Close()
            Catch ex As Exception
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
            End Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim warehouseMaster As New FrmWarehouseMaster("")
            warehouseMaster.ShowDialog()
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvWarehouse.Rows.Count = 0 OrElse Me.dgvWarehouse.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改仓库", False)
            Exit Sub
        End If

        Try
            Dim WarehouseCode As String
            WarehouseCode = Me.dgvWarehouse.Rows(Me.dgvWarehouse.CurrentRow.Index).Cells("WarehouseCode").Value.ToString
            Dim warehouseMaster As New FrmWarehouseMaster(WarehouseCode)
            warehouseMaster.ShowDialog()
            LoadControlData()

            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadControlData()

        Try
            Me.dgvWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

    
End Class