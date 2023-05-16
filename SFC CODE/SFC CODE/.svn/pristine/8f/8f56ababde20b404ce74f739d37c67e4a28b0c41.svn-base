
'--仓库系统设置
'--Create by :　马锋
'--Create date :　2015/07/15
'--Update date :  
'--
'--Ver : V01

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

Public Class FrmWarehouseSetting

#Region "变量声明"

    Dim dtInvoiceDefinitionsType As DataTable
    Dim dtInvoiceObject As DataTable
#End Region

#Region "加载事件"

    Private Sub FrmWarehouseSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Try
            Me.dgvWarehouse.AutoGenerateColumns = False

            '全局变量赋值
            GetVariableAssignment()
            '全局读取
            GetGlobalSettings()
            '单据定义读取
            GetDefinitions()
            '仓库
            GetWarehouse()
            Me.SuperTabControlList.SelectedTabIndex = 0
            Me.dgvInvoiceDefinitions.BeginEdit(True)
        Catch ex As Exception
            MessageBox.Show("数据加载异常!")
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SetMessage("", True)
        If (Me.SuperTabControlList.SelectedTabIndex < 1) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

        Try
            Select Case (Me.SuperTabControlList.SelectedTabIndex)
                Case 0
                    'AutomaticNO
                    strSQL.Append(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='AutomaticNO')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'AutomaticNO', N'自动序号', N'" & IIf(Me.chkAutomaticNO.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkAutomaticNO.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='AutomaticNO' END")

                    'RuleDateTime"
                    strSQL.Append(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='RuleDateTime')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'RuleDateTime', N'单据时间规则', N'" & Me.txtRuleDateTime.Text.Trim.Replace("'", "''") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & Me.txtRuleDateTime.Text.Trim.Replace("'", "''") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='RuleDateTime' END")

                    'RuleCode"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='RuleCode')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'RuleCode', N'单据流水码规则', N'" & Me.txtRuleCode.Text.Trim.Replace("'", "''") & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & Me.txtRuleCode.Text.Trim.Replace("'", "''") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToLower & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='RuleCode' END")

                    'OutStorageCheck"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='AllocationCheck')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'OutStorageCheck', N'出入库审核', N'" & IIf(Me.chkOutStorageCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkOutStorageCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OutStorageCheck' END")

                    'AllocationCheck"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='AllocationCheck')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'AllocationCheck', N'调拨审核', N'" & IIf(Me.chkAllocationCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkAllocationCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='AllocationCheck' END")

                    'InventoryChecking
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='InventoryChecking')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'InventoryChecking', N'盘点审核', N'" & IIf(Me.chkInventoryCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkInventoryCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='InventoryChecking' END")

                    'InventoryCheckQuantity
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='InventoryCheckQuantity')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'InventoryCheckQuantity', N'盘点库存更新', N'" & IIf(Me.chkInventoryCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkInventoryCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='InventoryCheckQuantity' END")


                    'StockMessage"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='StockMessage')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'StockMessage', N'库存不足提示', N'" & Me.cboStockMessage.SelectedIndex & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & Me.cboStockMessage.SelectedIndex & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='StockMessage' END")

                    'StockAmount"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='StockAmount')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'StockAmount', N'库存金额', N'" & Me.cboStockAmount.SelectedIndex & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & Me.cboStockAmount.SelectedIndex & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='StockAmount' END")

                    'MaterialCodingCheck"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='MaterialCodingCheck')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'MaterialCodingCheck', N'物料编码唯一性检查', N'" & IIf(Me.chkMaterialCodingCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkMaterialCodingCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='MaterialCodingCheck' END")

                    'OutStorageUniquenessCheck"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OutStorageUniquenessCheck')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'OutStorageUniquenessCheck', N'出入库料号唯一性检查', N'" & IIf(Me.ChkOutStorageUniquenessCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.ChkOutStorageUniquenessCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OutStorageUniquenessCheck' END")

                    'OrderManange"
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OrderManange')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'OrderManange', N'订单管理', N'" & IIf(Me.chkOrderManange.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToUpper & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkOrderManange.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OrderManange' END")

                    'OrderCheck
                    strSQL.AppendLine(" IF EXISTS(SELECT SYSTEMSETTING_ID FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OrderCheck')")
                    strSQL.Append(" BEGIN INSERT INTO m_SystemSetting_t(MODE_NAME, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, ")
                    strSQL.Append(" VALUES('WMS', 'OrderCheck', N'订单审核', N'" & IIf(Me.chkOrderCheck.Checked, "Y", "N") & "', '" & SysMessageClass.UseId.ToLower & "', GETDATE()) End ")
                    strSQL.Append(" ELSE BEGIN UPDATE m_SystemSetting_t SET PARAMETER_VALUES='" & IIf(Me.chkOrderCheck.Checked, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId.ToUpper & "', UPDATETIME=GETDATE() WHERE MODE_NAME='WMS' AND PARAMETER_CODE='OrderCheck' END")

                Case 1
                    Me.dgvInvoiceDefinitions.EndEdit()
                    Dim cboInvoiceDefinitionsType As DataGridViewComboBoxExCell
                    Dim cboInvoiceObject As DataGridViewComboBoxExCell
                    Dim strInvoiceDefinitionsID As String
                    Dim strInvoiceDefinitionsName As String
                    Dim strInvoicePrefix As String
                    Dim strPriceAlgorithm As String
                    Dim strERPDefinitionsName As String
                    Dim strERPSQLString As String

                    For I As Int16 = 0 To Me.dgvInvoiceDefinitions.RowCount - 1
                        strInvoiceDefinitionsID = Me.dgvInvoiceDefinitions.Rows(I).Cells("InvoiceDefinitionsID").Value
                        cboInvoiceDefinitionsType = Me.dgvInvoiceDefinitions.Rows(I).Cells("InvoiceDefinitionsType")
                        strInvoiceDefinitionsName = Me.dgvInvoiceDefinitions.Rows(I).Cells("InvoiceDefinitionsName").Value.ToString.Replace("'", "''")
                        strInvoicePrefix = Me.dgvInvoiceDefinitions.Rows(I).Cells("InvoicePrefix").Value.ToString.Replace("'", "''")
                        cboInvoiceObject = Me.dgvInvoiceDefinitions.Rows(I).Cells("InvoiceObject")
                        strPriceAlgorithm = Me.dgvInvoiceDefinitions.Rows(I).Cells("PriceAlgorithm").Value.ToString.Replace("'", "''")
                        strERPDefinitionsName = Me.dgvInvoiceDefinitions.Rows(I).Cells("ERPDefinitionsName").Value.ToString.Replace("'", "''")
                        strERPSQLString = Me.dgvInvoiceDefinitions.Rows(I).Cells("ERPSQLString").Value.ToString.Replace("'", "''")

                        If (String.IsNullOrEmpty(strInvoiceDefinitionsID)) Then
                            strSQL.AppendLine(" INSERT INTO m_InvoiceDefinitions_t")
                            strSQL.Append(" (InvoiceDefinitionsType, InvoiceDefinitionsName, InvoicePrefix, InvoiceObject, PriceAlgorithm, ERPDefinitionsName, ERPSQLString, CreateUser, CreateTime)")
                            strSQL.Append(" VALUES('" & cboInvoiceDefinitionsType.FormattedValue.ToString.Trim.Split("[")(1).Replace("]", "") & "', N'" & strInvoiceDefinitionsName & "', N'" & strInvoicePrefix & "', '" & cboInvoiceObject.FormattedValue.ToString.Trim.Split("[")(1).Replace("]", "") & "', '" & strPriceAlgorithm & "', N'" & strERPDefinitionsName & "', '" & strERPSQLString & "', '" & SysMessageClass.UseId.ToUpper & "',GETDATE())")

                        Else
                            strSQL.AppendLine(" UPDATE m_InvoiceDefinitions_t SET")
                            strSQL.Append(" InvoiceDefinitionsType='" & cboInvoiceDefinitionsType.FormattedValue.ToString.Trim.Split("[")(1).Replace("]", "") & "', InvoiceDefinitionsName=N'" & strInvoiceDefinitionsName & "', InvoicePrefix=N'" & strInvoicePrefix & "', InvoiceObject='" & cboInvoiceObject.FormattedValue.ToString.Trim.Split("[")(1).Replace("]", "") & "', PriceAlgorithm='" & strPriceAlgorithm & "', ")
                            strSQL.Append(" ERPDefinitionsName=N'" & strERPDefinitionsName & "', ERPSQLString='" & strERPSQLString & "',UpdateUser='" & SysMessageClass.UseId.ToUpper & "',UpdateTime=GETDATE()")
                            strSQL.Append(" WHERE InvoiceDefinitionsID='" & strInvoiceDefinitionsID & "'")
                        End If
                    Next
                Case 2

                Case 3

            End Select

            If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                Conn.ExecSql(strSQL.ToString)
            End If

            Conn.PubConnection.Close()

            '全局读取
            GetGlobalSettings()
            '单据定义读取
            GetDefinitions()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            MessageBox.Show("保存异常!")
        End Try
    End Sub

    Private Sub btnInsertDefinitions_Click(sender As Object, e As EventArgs) Handles btnInsertDefinitions.Click
        SetMessage("", True)
        Try
            Dim addRow As Int16
            addRow = Me.dgvInvoiceDefinitions.Rows.Add()
            Me.dgvInvoiceDefinitions.Rows(addRow).Cells("InvoiceDefinitionsID").Value = ""
            Me.dgvInvoiceDefinitions.Rows(addRow).Cells("ERPDefinitionsName").Value = ""
            Me.dgvInvoiceDefinitions.Rows(addRow).Cells("ERPSQLString").Value = ""
            'Me.dgvInvoiceDefinitions.FirstDisplayedScrollingRowIndex = Me.dgvInvoiceDefinitions.Rows(Me.dgvInvoiceDefinitions.RowCount).Index - 1
        Catch ex As Exception
            SetMessage("新增异常!", False)
        End Try
    End Sub

    Private Sub btnDeleteDefinitions_Click(sender As Object, e As EventArgs) Handles btnDeleteDefinitions.Click
        SetMessage("", True)

        If Me.dgvInvoiceDefinitions.Rows.Count = 0 OrElse Me.dgvInvoiceDefinitions.CurrentRow Is Nothing Then
            SetMessage("请选择要删除数据行!", False)
            Exit Sub
        End If

        Dim strInvoiceDefinitionsID As String
        strInvoiceDefinitionsID = Me.dgvInvoiceDefinitions.Rows(Me.dgvInvoiceDefinitions.CurrentRow.Index).Cells("InvoiceDefinitionsID").Value.ToString

        If (String.IsNullOrEmpty(strInvoiceDefinitionsID)) Then
            Me.dgvInvoiceDefinitions.Rows.RemoveAt(Me.dgvInvoiceDefinitions.CurrentRow.Index)
            SetMessage("删除成功!", False)
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

        Try

            strSQL.AppendLine("UPDATE m_InvoiceDefinitions_t SET ActiveFlag='0' WHERE InvoiceDefinitionsID='" & strInvoiceDefinitionsID & "' ")

            Conn.ExecSql(strSQL.ToString())
            Conn.PubConnection.Close()
            GetDefinitions()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("删除异常!", False)
        End Try
    End Sub

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

            GetWarehouse()
            GetMesData.SetMessage(Me.lblMessage, "下载成功", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
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
            GetMesData.SetMessage(Me.lblMessage, "下载成功", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub GetVariableAssignment()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

        Try
            strSQL = GetSettingParameterSQL("OutStorageDirection")
            dtInvoiceDefinitionsType = Conn.GetDataTable(strSQL)

            strSQL = GetSettingParameterSQL("InvoiceObject")
            dtInvoiceObject = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

    Private Function GetSettingParameterSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUE, PARAMETER_NAME + '[' + PARAMETER_VALUE + ']' AS PARAMETER_NAME FROM m_SettingParameter_t WHERE PARAMETER_MODE='" & ParameterCode & "' ORDER BY ORDERID ASC"
    End Function

    Private Sub GetGlobalSettings()
        Dim strSQL As String
        strSQL = "SELECT PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS'"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            DReader = Conn.GetDataReader(strSQL)
            If (DReader.HasRows) Then
                Do While DReader.Read()
                    Select Case (DReader.Item("PARAMETER_CODE").ToString)
                        Case "AutomaticNO"
                            Me.chkAutomaticNO.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "RuleDateTime"
                            Me.txtRuleDateTime.Text = DReader.Item("PARAMETER_VALUES").ToString
                        Case "RuleCode"
                            Me.txtRuleCode.Text = DReader.Item("PARAMETER_VALUES").ToString
                        Case "OutStorageCheck"
                            Me.chkOutStorageCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "AllocationCheck"
                            Me.chkAllocationCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "InventoryChecking"
                            Me.chkInventoryCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "InventoryCheckQuantity"
                            Me.chkInventoryCheckQuantity.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "StockMessage"
                            Me.cboStockMessage.SelectedIndex = DReader.Item("PARAMETER_VALUES").ToString
                        Case "StockAmount"
                            Me.cboStockAmount.SelectedIndex = DReader.Item("PARAMETER_VALUES").ToString
                        Case "MaterialCodingCheck"
                            Me.chkMaterialCodingCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "OutStorageUniquenessCheck"
                            Me.ChkOutStorageUniquenessCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "OrderManange"
                            Me.chkOrderManange.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                        Case "OrderCheck"
                            Me.chkOrderCheck.Checked = IIf(DReader.Item("PARAMETER_VALUES").ToString = "Y", True, False)
                    End Select
                Loop
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
        End Try
    End Sub

    Private Sub GetDefinitions()
        Me.dgvInvoiceDefinitions.Rows.Clear()
        Dim strSQL As String
        strSQL = "SELECT InvoiceDefinitionsID, InvoiceDefinitionsType, InvoiceDefinitionsType.PARAMETER_NAME + '[' + InvoiceDefinitionsType.PARAMETER_VALUE +  ']' as InvoiceDefinitionsTypeName, InvoiceDefinitionsName, InvoicePrefix, InvoiceObject, InvoiceObject.PARAMETER_NAME+ '[' + InvoiceObject.PARAMETER_VALUE +  ']' as InvoiceObjectName, PriceAlgorithm, ERPDefinitionsName, ERPSQLString " & _
                 " FROM m_InvoiceDefinitions_t " & _
                 " INNER JOIN m_SettingParameter_t InvoiceDefinitionsType ON InvoiceDefinitionsType.PARAMETER_VALUE=m_InvoiceDefinitions_t.InvoiceDefinitionsType AND InvoiceDefinitionsType.PARAMETER_MODE='OutStorageDirection' " & _
                 " INNER JOIN m_SettingParameter_t InvoiceObject ON InvoiceObject.PARAMETER_VALUE=m_InvoiceDefinitions_t.InvoiceObject AND InvoiceObject.PARAMETER_MODE='InvoiceObject'"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            DReader = Conn.GetDataReader(strSQL)

            Dim cmbInvoiceDefinitionsTypeTmp As DataGridViewComboBoxExColumn
            Dim cmbInvoiceObjectTmp As DataGridViewComboBoxExColumn

            cmbInvoiceDefinitionsTypeTmp = Me.dgvInvoiceDefinitions.Columns("InvoiceDefinitionsType")
            cmbInvoiceDefinitionsTypeTmp.DisplayMember = "PARAMETER_NAME"
            cmbInvoiceDefinitionsTypeTmp.ValueMember = "PARAMETER_NAME"
            cmbInvoiceDefinitionsTypeTmp.DataSource = dtInvoiceDefinitionsType

            cmbInvoiceObjectTmp = Me.dgvInvoiceDefinitions.Columns("InvoiceObject")
            cmbInvoiceObjectTmp.DisplayMember = "PARAMETER_NAME"
            cmbInvoiceObjectTmp.ValueMember = "PARAMETER_NAME"
            cmbInvoiceObjectTmp.DataSource = dtInvoiceObject

            If (DReader.HasRows) Then
                Do While DReader.Read()
                    Me.dgvInvoiceDefinitions.Rows.Add(DReader.Item("InvoiceDefinitionsID").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("InvoiceDefinitionsTypeName").ToString, DReader.Item("InvoicePrefix").ToString, DReader.Item("PriceAlgorithm").ToString, DReader.Item("InvoiceObjectName").ToString, DReader.Item("ERPDefinitionsName").ToString, DReader.Item("ERPSQLString").ToString)
                Loop
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
        End Try
    End Sub

    Private Sub GetWarehouse()
        Try
            Me.dgvWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取仓库信息异常", False)
        End Try
    End Sub

    Private Sub SetMessage(ByVal Message As String, ByVal Type As Boolean)
        If (Type) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

#End Region

 
End Class