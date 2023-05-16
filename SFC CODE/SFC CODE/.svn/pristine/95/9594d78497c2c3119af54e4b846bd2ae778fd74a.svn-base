
'--库位条码打印作业
'--Create by :　马锋
'--Create date :　2014/09/22
'--Update date :  
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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD

#End Region

Public Class FrmLocationPrint

#Region "窗體變量"

    Dim Sqlstr As New StringBuilder
    Dim opFlag As Int16 = 0
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = Application.StartupPath & "\BartenderFile\LocationBarcode.btw"
    Dim BarFile As New StringBuilder()
    Dim PrintName As String

#Region "包装"
    Dim MoidAllNum As Int64 = 0         '工單批量
    Dim MoidLastNum As Int64            '工單尾數量
    Dim CtPrtingNum As Int64            '工單可打印箱數
    Dim PackMethod As Int16 = 0         '裝箱數量
    Dim Packlink As String = ""         '箱標簽類型
    Dim PackItems As String = ""         '条码类型
#End Region

#End Region

#Region "窗体事件"

    Private Sub FrmListPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass
        LoadControlData()
    End Sub

    Private Sub FrmListPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)

    End Sub

    Private Sub LoadControlData()
        FillCombox(Me.CboWarehouse)
        FillCombox(Me.CboPrinter)
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click

    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click

    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click

    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrint.Click
        Dim TxtFileStr As New StringBuilder
        Try
            dgvWarehouse.Enabled = False
            If dgvWarehouse.RowCount > 0 Then
                If (CheckPrint(Me.dgvWarehouse)) Then
                    PrintName = Me.dgvWarehouse.Rows(0).Cells("PRINTERNAME").Value.ToString
                    Dim chkTemp As DataGridViewCheckBoxCell
                    For i As Int16 = 0 To Me.dgvWarehouse.RowCount - 1
                        chkTemp = dgvWarehouse.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                            If i = 0 Then
                                TxtFileStr.Append("""" & dgvWarehouse.Rows(i).Cells("WarehouseLocationCode").Value.ToString & """")
                            Else
                                TxtFileStr.Append(vbNewLine & """" & dgvWarehouse.Rows(i).Cells("WarehouseLocationCode").Value.ToString & """")
                            End If
                        End If
                    Next

                    '写入打印Text
                    TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                    If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                        File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
                    End If
                    File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

                    '打印
                    If (Not String.IsNullOrEmpty(TxtFileStr.ToString)) Then
                        FileToBarCodePrint(pFilePath, PrintName)
                    End If
                Else
                    dgvWarehouse.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If
            dgvWarehouse.Enabled = True
        Catch ex As Exception
            dgvWarehouse.Enabled = True
            SetMessage("打印失败，请联系开发人员!")
        End Try
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click

        If (String.IsNullOrEmpty(Me.CboWarehouse.Text.Trim)) Then
            SetMessage("请选择仓库!")
            Me.CboWarehouse.Focus()
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.CboPrinter.Text.Trim)) Then
            SetMessage("请选择打印机!")
            Me.CboPrinter.Focus()
            Exit Sub
        End If

        GetWarehouseLocation(Me.CboWarehouse.SelectedValue.ToString)
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvWarehouse.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvWarehouse.RowCount - 1
                    dgvWarehouse.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            SetMessage("选择执行异常，请联系开发人员!")
        End Try
    End Sub
#End Region

#Region "Function"

    Private Function GetTiptopWarehouseSQL() As String
        Dim Sql As String

        Sql = "SELECT IMD01,IMD02||'['||IMD01||']' AS IMD02 FROM " & VbCommClass.VbCommClass.Factory & ".IMD_FILE"
        Return Sql
    End Function

    Private Function GetTiptopPOSQL(ByVal OperationsCenter As String, ByVal ProfitCenter As String, ByVal POName As String) As String
        Dim Sql As String

        Sql = "SELECT PMM_FILE.PMM01, PMM_FILE.PMM04, PMM_FILE.PMM09, PMM_FILE.PMM13," _
            & " PMN_FILE.PMN02, PMN_FILE.PMN04, PMN_FILE.PMN041, PMN_FILE.PMN07, PMN_FILE.PMN20, PMN_FILE.PMN50, PMN_FILE.PMN55" _
            & " FROM " & VbCommClass.VbCommClass.Factory & ".PMM_FILE" _
            & " INNER JOIN " & VbCommClass.VbCommClass.Factory & ".PMN_FILE ON PMN_FILE.PMN01=PMM_FILE.PMM01" _
            & " WHERE PMMACTI='Y' AND PMM25='2'" _
            & " AND PMM01=PMN01  AND PMN20>(PMN50-PMN55) AND (NOT PMM02 LIKE 'WB%') AND PMM_FILE.PMM01='" & POName & "'"
        Return Sql
    End Function

    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell

        For I As Int16 = 0 To dgvWarehouse.RowCount - 1
            chkTemp = dgvWarehouse.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then

                '判断打印数量
                'If Not IsNumeric(dgvWarehouse.Rows(I).Cells("PrintNum").Value) Then
                '    SetMessage("第" + (I + 1).ToString + "行输入打印数量有误！")
                '    Return False
                '    Exit For
                'End If

                '判断打印机是否可用
                'If (String.IsNullOrEmpty(dgvWarehouse.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim)) Then
                '    SetMessage("请设置第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                '    Return False
                '    Exit For
                'Else
                '    Dim ps As New PrinterSettings
                '    ps.PrinterName = dgvWarehouse.Rows(I).Cells("PrinterName").FormattedValue.ToString.Trim
                '    If (ps.IsValid = False) Then
                '        SetMessage("第" + (I + 1).ToString + "行打印机不可用，请检查!")
                '        Return False
                '        Exit For
                '    End If
                'End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
        End If
        Return iSelect
    End Function

    Private Function FormatSQLString(ByVal Value As String) As String
        Return Value.Replace("'", "''")
    End Function

    Private Function FormatQuerySQLString(ByVal Value As String) As String
        Return "N'" & Value.Replace("'", "''") & "'"
    End Function

#End Region

#Region "Bind"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        If ColComboBox.Name = "CboWarehouse" Then
            'Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
            'Dim dvTiptopWarehouse As DataView
            'dvTiptopWarehouse = TiptopConn.getDataView(GetTiptopWarehouseSQL())
            ''获取Tiptop库位信息
            'If Not dvTiptopWarehouse Is Nothing Then
            '    ColComboBox.DataSource = dvTiptopWarehouse
            '    ColComboBox.DisplayMember = "IMD02"
            '    ColComboBox.ValueMember = "IMD01"
            'End If
            Me.CboWarehouse.DisplayMember = "WarehouseName"
            Me.CboWarehouse.ValueMember = "WarehouseCode"
            Me.CboWarehouse.DataSource = GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

        ElseIf ColComboBox.Name = "CboPrinter" Then
            SqlClassM.GetPrintersList(ColComboBox)
        End If
    End Sub

#End Region

#Region "方法"

    Private Sub ClearQuery()
        Me.txtLocation.Text = ""
    End Sub

    '取得库位清单
    Private Sub GetLocation()
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append("SELECT IME02,IME01,IMEBU,'" & Me.CboPrinter.Text.Trim & "' AS PRINTERNAME FROM " & VbCommClass.VbCommClass.Factory & ".IME_FILE WHERE IME05='Y' AND NVL(IME02,' ')<>' ' ")

        If Not String.IsNullOrEmpty(Me.CboWarehouse.SelectedValue.Trim) Then
            Sqlstr.Append(" AND IME01='" & Me.CboWarehouse.SelectedValue.ToString.Trim & "'")
        End If

        If Not String.IsNullOrEmpty(Me.txtLocation.Text.Trim) Then
            Sqlstr.Append(" AND IME02='%" & Me.CboWarehouse.SelectedValue.ToString.Trim & "%'")
        End If
        Sqlstr.Append(" ORDER BY IME02 DESC")

        LoadData(Sqlstr.ToString, Me.dgvWarehouse)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
        Dim dvTiptopWarehouse As DataView

        Try
            dgvName.Rows.Clear()
            dvTiptopWarehouse = TiptopConn.getDataView(Sqlstr)

            If Not dvTiptopWarehouse Is Nothing Then
                If (dvTiptopWarehouse.Table.Rows.Count > 0) Then
                    For i As Int16 = 0 To dvTiptopWarehouse.Table.Rows.Count - 1
                        dgvName.Rows.Add(True, dvTiptopWarehouse.Item(i).Item("IME02").ToString, dvTiptopWarehouse.Item(i).Item("IME01").ToString, dvTiptopWarehouse.Item(i).Item("PRINTERNAME").ToString)
                    Next

                    Me.ToolLblCount.Text = Me.dgvWarehouse.Rows.Count
                    TiptopConn = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BindPrintList(ByVal strSQL As String, ByVal dgvName As DataGridView)
        Dim dtTemp As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            dtTemp = DataHand.GetDataTable(strSQL)

            dtTemp = Nothing
            DataHand = Nothing
        Catch ex As Exception
            dtTemp = Nothing
            DataHand = Nothing
        End Try
    End Sub

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)

        If (Not PrintData Is Nothing) Then
            BuildSBarCode(PrintData)
        Else
            SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
        End If
    End Sub

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub


    Public Shared Function GetWarehouse(ByVal strFactoryId As String, ByVal strProfitcenter As String, ByVal strWarehouseCode As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable = Nothing

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strWarehouseCode)) Then
                strWhere = " AND WarehouseCode='" & strWarehouseCode & "'"
            End If
            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY WarehouseId )as RowNum, WarehouseId, WarehouseCode, '[' + WarehouseCode + ']' + WarehouseName AS WarehouseName, WarehouseName AS WarehouseNameAliases, CreateUser, CreateTime, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlag FROM  m_Warehouse_t WHERE FactoryId='" & strFactoryId & "' AND Profitcenter='" & strProfitcenter & "' " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Sub GetWarehouseLocation(ByVal strWarehouseCode As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strWarehouseCode)) Then
                strWhere = " AND WarehouseId='" & strWarehouseCode & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY WarehouseLocationId )as RowNum, WarehouseId, WarehouseLocationCode, WarehouseLocationName, '" & Me.CboPrinter.Text.Trim & "' AS PRINTERNAME FROM  m_WarehouseLocation_t WHERE 1=1 " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()

            dgvWarehouse.Rows.Clear()
            If Not dtTemp Is Nothing Then
                If (dtTemp.Rows.Count > 0) Then
                    For i As Int16 = 0 To dtTemp.Rows.Count - 1
                        dgvWarehouse.Rows.Add(True, dtTemp.Rows(i).Item("WarehouseLocationCode").ToString, dtTemp.Rows(i).Item("WarehouseLocationName").ToString, dtTemp.Rows(i).Item("WarehouseId").ToString, dtTemp.Rows(i).Item("PRINTERNAME").ToString)
                    Next

                    Me.ToolLblCount.Text = Me.dgvWarehouse.Rows.Count
                End If
            End If
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

#End Region

#Region "打印"

    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim TxtFileStr As New StringBuilder

            '生成数据库脚本
            For I As Int16 = 0 To PrintName - 1
                '生成打印Text
                'If I = 0 Then
                '    TxtFileStr.Append("""" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.MantissaPackingQty & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                'Else
                '    TxtFileStr.Append(vbNewLine & """" & strReelBarcode & """,""" & reelPrint.CustomerName & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.SupplierPN & """,""" & reelPrint.DateCode & """,""" & reelPrint.Rev & """,""" & reelPrint.MantissaPackingQty & """,""" & reelPrint.Unit & """,""" & reelPrint.GW & """")
                'End If
            Next

            '写入打印Text
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, Encoding.UTF8)

            '打印
            If (Not String.IsNullOrEmpty(TxtFileStr.ToString)) Then
                FileToBarCodePrint(pFilePath, PrintName)
            End If
        Catch ex As Exception
            SetMessage("打印失败，请联系开发人员!")
        End Try
    End Sub

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)VbCommClass.VbCommClass.PrintDataModle & 
        btFormat = btApp.Formats.Open(pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

#End Region

End Class
