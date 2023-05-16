Imports System.Xml
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text

Public Class FrmPackingPartSet
    '数据集
    Private dtData As DataTable = Nothing
    '导入列集合
    Dim FieldList As List(Of String)

    '加载数据
    Private Sub FrmPackingPartSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TxtLPartID.Focus()
        QueryData()
    End Sub

    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Dim frm As FrmPackingPartSetOper = New FrmPackingPartSetOper(0, "")
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            QueryData()
        End If
    End Sub

    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.LPartDg.RowCount <= 0 Then
            Exit Sub
        End If
        If Me.LPartDg.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim StrIsChecked As String = Me.LPartDg.Item("IsChecked", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim
        If StrIsChecked.ToUpper = "Y" Then
            MessageBox.Show("该料件已审核,不能修改！")
            Exit Sub
        End If
        Dim frm As FrmPackingPartSetOper = New FrmPackingPartSetOper(1, Me.LPartDg.Item("LPartID", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            QueryData()
        End If
    End Sub

    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If Me.LPartDg.RowCount <= 0 Then
            Exit Sub
        End If
        If Me.LPartDg.CurrentRow Is Nothing Then
            Exit Sub
        End If
        If MessageBox.Show("你确认要删除该料件包装扫描参数吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            Try
                Dim StrSql As String = String.Format(" INSERT INTO dbo.m_PartScanStyleInof_t_Log(OperLogID ,LPartID ,CartonStylePackID ,CartonStylePackItem , " &
                                        " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton,IsScanCustProAndQtyI, IsScanPECarton, " &
                                        " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
                                        " IsFixedCode, PpIDQtyI, IsChecked, CheckedUserID, CheckedDate, CreateUserID, CreateDate, OperType, OperUserid, OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton) " &
                                        " SELECT NEWID() AS OperLogID,LPartID,CartonStylePackID ,CartonStylePackItem , " &
                                        " CartonQtyI ,IsScanQRCode ,QRCodeStylePackID ,QRCodeStylePackItem ,IsAutoGenerateCarton ,IsScanCustProAndQtyI,IsScanPECarton , " &
                                        " PECartonStylePackID ,PECartonStylePackItem ,PECartonQtyI ,PpIDCodeStylePackID ,PpIDCodeStylePackItem , " &
                                        " IsFixedCode ,PpIDQtyI ,IsChecked ,CheckedUserID ,CheckedDate ,CreateUserID ,CreateDate ,'Delete' AS OperType, " &
                                        " '{1}' AS OperUserid,GETDATE() AS OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton FROM m_PartScanStyleInof_t WHERE LPartID='{0}' " &
                                        " DELETE FROM dbo.m_PartScanStyleInof_t WHERE LPartID='{0}' ", Me.LPartDg.Item("LPartID", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim, SysMessageClass.UseId)
                DbOperateUtils.ExecSQL(StrSql)
                MessageBox.Show("删除成功！")
                QueryData()
            Catch ex As Exception
                MessageBox.Show(ex.Message & vbNewLine & "删除时发生错误!", "提示信息", MessageBoxButtons.OK)
            End Try
        End If
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        QueryData()
    End Sub

    '查询数据方法
    Private Sub QueryData()
        Dim StrSql As String = " SELECT a.LPartID,a.CartonStylePackID,a.CartonStylePackItem,a.CartonQtyI,a.IsAutoGenerateCarton,a.IsScanFixedCarton,a.IsSystemPrintCarton,a.IsScanCustProAndQtyI,a.IsScanQRCode, " &
                               " a.QRCodeStylePackID,a.QRCodeStylePackItem,a.IsSystemPrintQRCode,a.IsScanPECarton,a.PECartonStylePackID,a.PECartonStylePackItem,a.PECartonQtyI,a.IsSystemPrintPECarton, " &
                               " a.PpIDCodeStylePackID,a.PpIDCodeStylePackItem,a.IsFixedCode,a.PpIDQtyI,a.IsSystemPrintPpID,a.CreateUserID+'/'+b.UserName AS CreateUserID, " &
                               " a.CreateDate,a.IsChecked,a.CheckedUserID+'/'+c.UserName AS CheckedUserID,a.CheckedDate " &
                               " FROM dbo.m_PartScanStyleInof_t a LEFT JOIN dbo.m_Users_t b ON a.CreateUserID=b.UserID " &
                               " LEFT JOIN dbo.m_Users_t c ON a.CheckedUserID=c.UserID "
        If Me.TxtLPartID.Text.Trim <> "" Then
            StrSql = StrSql & String.Format(" WHERE a.LPartID='{0}' ", Me.TxtLPartID.Text.Trim)
        End If
        dtData = DbOperateUtils.GetDataTable(StrSql)
        Me.LPartDg.DataSource = dtData
    End Sub

    '审核
    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        If Me.LPartDg.RowCount <= 0 Then
            Exit Sub
        End If
        If Me.LPartDg.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim StrChecked As String = Me.LPartDg.Item("IsChecked", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim
        Dim StrLpartID As String = Me.LPartDg.Item("LPartID", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim
        If StrChecked.ToUpper = "Y" Then
            MessageBox.Show("该料件参数已审核！")
            Exit Sub
        End If
        If MessageBox.Show("确定要审核吗？审核后不能再进行修改！", "提示", MessageBoxButtons.OKCancel) <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim StrSql As String = String.Format(" UPDATE dbo.m_PartScanStyleInof_t SET IsChecked='Y',CheckedUserID='{0}',CheckedDate=GETDATE() WHERE LPartID='{1}' ", SysMessageClass.UseId, StrLpartID)
        Try
            DbOperateUtils.ExecSQL(StrSql)
            MessageBox.Show("审核成功！")
            QueryData()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "审核时发生错误!", "提示信息", MessageBoxButtons.OK)
        End Try
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导入
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            Dim dtUploadData As DataTable = SysDataBaseClass.ExportFromExcelByAs(filename, 1, 0, errorMsg)

            If errorMsg <> "" Then
                MessageBox.Show(errorMsg)
                Exit Sub
            End If

            FieldList = Nothing
            FieldList = New List(Of String)
            FieldList.Add("LPartID")
            FieldList.Add("CartonStylePackID")
            FieldList.Add("CartonStylePackItem")
            FieldList.Add("CartonQtyI")
            FieldList.Add("IsAutoGenerateCarton")
            FieldList.Add("IsSystemPrintCarton")
            FieldList.Add("IsScanCustProAndQtyI")
            FieldList.Add("IsScanQRCode")
            FieldList.Add("QRCodeStylePackID")
            FieldList.Add("QRCodeStylePackItem")
            FieldList.Add("IsSystemPrintQRCode")
            FieldList.Add("IsScanPECarton")
            FieldList.Add("PECartonStylePackID")
            FieldList.Add("PECartonStylePackItem")
            FieldList.Add("PECartonQtyI")
            FieldList.Add("IsSystemPrintPECarton")
            FieldList.Add("PpIDCodeStylePackID")
            FieldList.Add("PpIDCodeStylePackItem")
            FieldList.Add("IsFixedCode")
            FieldList.Add("PpIDQtyI")
            FieldList.Add("IsSystemPrintPpID")
            If dtUploadData.Columns.Count = 21 Then
                Dim i%
                For i = 0 To dtUploadData.Columns.Count - 1
                    dtUploadData.Columns(i).ColumnName = FieldList(i)
                Next
            Else
                MessageBox.Show("导入文件格式有误！")
                Return
            End If

            Dim DrrR As DataRow() = dtUploadData.Select(" ISNULL(LPartID,'')<>'' ")

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)
            If strSQL = "" Then
                Exit Sub
            End If
            'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            'Sdbc.ExecSql(strSQL)
            'Sdbc.PubConnection.Close()
            'Sdbc = Nothing
            DbOperateUtils.ExecSQL(strSQL)
            MessageBox.Show("导入成功！")
            QueryData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmPackingPartSet", "ImportData", "sys")
            MessageBox.Show("导入失败:" & ex.Message.ToString)
        End Try
    End Sub

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim PartScanStyleInofSQL As String = " select distinct LPartID from m_PartScanStyleInof_t "
        Dim PartScanStyleInofDT As DataTable = DbOperateUtils.GetDataTable(PartScanStyleInofSQL)
        Dim hashtable As Hashtable = New Hashtable
        For index As Integer = 0 To DrrR.Length - 1
            Dim strKey As String = DrrR(index)("LPartID").ToString.Trim
            If hashtable.Contains(strKey) Then
                MessageBox.Show("上传数据中有重复的[料件编号]:'" + strKey + "'")
                Return False
            End If
            Dim drs As DataRow() = PartScanStyleInofDT.Select(" LPartID='" & strKey & "' ")
            If (Not drs Is Nothing) AndAlso (drs.Length > 0) Then
                MessageBox.Show("已经存在[料件编号]:'" + strKey + "'")
                Return False
            End If
            hashtable.Add(strKey, strKey)
        Next
        Return True
    End Function

    '获取插入SQL语句
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim strSQL As String = " INSERT INTO dbo.m_PartScanStyleInof_t(LPartID ,CartonStylePackID ,CartonStylePackItem , " &
                               " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, " &
                               " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
                               " IsFixedCode, PpIDQtyI, IsChecked, CreateUserID, CreateDate,IsScanCustProAndQtyI,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID) " &
                               " VALUES(N'{0}',N'{1}',{2},{3},N'{4}',N'{5}',{6},N'{7}',N'{8}',N'{9}',{10},{11},N'{12}',{13},N'{14}',{15},N'{16}', " &
                               " N'{17}',GETDATE(),N'{18}',N'{19}',N'{20}',N'{21}',N'{22}') "
        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            Dim LPartID As String = ""
            Dim CartonStylePackID As String = ""
            Dim CartonStylePackItem As Integer = 0
            Dim IntCartonQtyI As Integer = 0
            Dim IsScanQRCode As String = "N"
            Dim QRCodeStylePackID As String = ""
            Dim QRCodeStylePackItem As Integer = 0
            Dim IsAutoGenerateCarton As String = "N"
            Dim IsScanPECarton As String = "N"
            Dim PECartonStylePackID As String = ""
            Dim PECartonStylePackItem As Integer = 0
            Dim IntPECartonQtyI As Integer = 0
            Dim PpIDCodeStylePackID As String = ""
            Dim PpIDCodeStylePackItem As Integer = 0
            Dim IsFixedCode As String = "N"
            Dim IntPpIDQtyI As Integer = 0
            Dim IsScanCustProAndQtyI As String = "N"
            Dim IsSystemPrintCarton As String = "N"
            Dim IsSystemPrintQRCode As String = "N"
            Dim IsSystemPrintPECarton As String = "N"
            Dim IsSystemPrintPpID As String = "N"
            LPartID = row("LPartID").ToString.Trim
            CartonStylePackID = row("CartonStylePackID").ToString.Trim
            Try
                CartonStylePackItem = Convert.ToInt32(row("CartonStylePackItem").ToString.Trim)
            Catch ex As Exception
                MessageBox.Show("外箱条码项次格式错误！")
                Return ""
            End Try
            Try
                IntCartonQtyI = Convert.ToInt32(row("CartonQtyI").ToString.Trim)
            Catch ex As Exception
                MessageBox.Show("装箱数量格式错误！")
                Return ""
            End Try
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format(" SELECT Partid FROM dbo.m_PartPack_t WHERE Partid='{0}' AND Packid='{1}' AND Packitem={2} AND (Usey='C' OR Usey='Y') ", LPartID, CartonStylePackID, CartonStylePackItem))
            If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
                MessageBox.Show("料件:" & LPartID & "不存在该外箱条码类型和项次数据或未确认！")
                Return ""
            End If
            If (row("IsScanQRCode").ToString.Trim = "是") OrElse (row("IsScanQRCode").ToString.Trim = "Y") Then
                IsScanQRCode = "Y"
            End If
            If IsScanQRCode = "Y" Then
                QRCodeStylePackID = row("QRCodeStylePackID").ToString.Trim
                Try
                    QRCodeStylePackItem = Convert.ToInt32(row("QRCodeStylePackItem").ToString.Trim)
                Catch ex As Exception
                    MessageBox.Show("QR条码项次格式错误！")
                    Return ""
                End Try
                dtTemp = DbOperateUtils.GetDataTable(String.Format(" SELECT Partid FROM dbo.m_PartPack_t WHERE Partid='{0}' AND Packid='{1}' AND Packitem={2} AND (Usey='C' OR Usey='Y') ", LPartID, QRCodeStylePackID, QRCodeStylePackItem))
                If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
                    MessageBox.Show("料件:" & LPartID & "不存在该QR条码类型和项次数据或未确认！")
                    Return ""
                End If
            End If
            If (row("IsAutoGenerateCarton").ToString.Trim = "是") OrElse (row("IsAutoGenerateCarton").ToString.Trim = "Y") Then
                IsAutoGenerateCarton = "Y"
            End If
            If (row("IsScanPECarton").ToString.Trim = "是") OrElse (row("IsScanPECarton").ToString.Trim = "Y") Then
                IsScanPECarton = "Y"
            End If
            If IsScanPECarton = "Y" Then
                PECartonStylePackID = row("PECartonStylePackID").ToString.Trim
                Try
                    PECartonStylePackItem = Convert.ToInt32(row("PECartonStylePackItem").ToString.Trim)
                Catch ex As Exception
                    MessageBox.Show("PE袋条码项次格式错误！")
                    Return ""
                End Try
                dtTemp = DbOperateUtils.GetDataTable(String.Format(" SELECT Partid FROM dbo.m_PartPack_t WHERE Partid='{0}' AND Packid='{1}' AND Packitem={2} AND (Usey='C' OR Usey='Y') ", LPartID, PECartonStylePackID, PECartonStylePackItem))
                If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
                    MessageBox.Show("料件:" & LPartID & "不存在该PE袋条码类型和项次数据或未确认！")
                    Return ""
                End If
                Try
                    IntPECartonQtyI = Convert.ToInt32(row("PECartonQtyI").ToString.Trim)
                Catch ex As Exception
                    MessageBox.Show("PE袋数量格式错误！")
                    Return ""
                End Try
            End If
            PpIDCodeStylePackID = row("PpIDCodeStylePackID").ToString.Trim
            Try
                PpIDCodeStylePackItem = Convert.ToInt32(row("PpIDCodeStylePackItem").ToString.Trim)
            Catch ex As Exception
                MessageBox.Show("产品条码项次格式错误！")
                Return ""
            End Try
            dtTemp = DbOperateUtils.GetDataTable(String.Format(" SELECT Partid FROM dbo.m_PartPack_t WHERE Partid='{0}' AND Packid='{1}' AND Packitem={2} AND (Usey='C' OR Usey='Y') ", LPartID, PpIDCodeStylePackID, PpIDCodeStylePackItem))
            If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
                MessageBox.Show("料件:" & LPartID & "不存在该产品条码类型和项次数据或未确认！")
                Return ""
            End If
            Try
                IntPpIDQtyI = Convert.ToInt32(row("PpIDQtyI").ToString.Trim)
            Catch ex As Exception
                MessageBox.Show("产品数量格式错误！")
                Return ""
            End Try
            If (row("IsFixedCode").ToString.Trim = "是") OrElse (row("IsFixedCode").ToString.Trim = "Y") Then
                IsFixedCode = "Y"
            End If
            If (row("IsScanCustProAndQtyI").ToString.Trim = "是") OrElse (row("IsScanCustProAndQtyI").ToString.Trim.ToUpper = "Y") Then
                IsScanCustProAndQtyI = "Y"
            End If
            '是否系统打印条码 AddByKyLinQiu20171016
            If (row("IsSystemPrintCarton").ToString.Trim = "是") OrElse (row("IsSystemPrintCarton").ToString.Trim.ToUpper = "Y") Then
                IsSystemPrintCarton = "Y"
            End If
            If (row("IsSystemPrintQRCode").ToString.Trim = "是") OrElse (row("IsSystemPrintQRCode").ToString.Trim.ToUpper = "Y") Then
                IsSystemPrintQRCode = "Y"
            End If
            If (row("IsSystemPrintPECarton").ToString.Trim = "是") OrElse (row("IsSystemPrintPECarton").ToString.Trim.ToUpper = "Y") Then
                IsSystemPrintPECarton = "Y"
            End If
            If (row("IsSystemPrintPpID").ToString.Trim = "是") OrElse (row("IsSystemPrintPpID").ToString.Trim.ToUpper = "Y") Then
                IsSystemPrintPpID = "Y"
            End If

            strInsertSQL.AppendFormat(strSQL, LPartID, CartonStylePackID, CartonStylePackItem, IntCartonQtyI, IsScanQRCode, QRCodeStylePackID,
                                      QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, PECartonStylePackID, PECartonStylePackItem,
                                      IntPECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, IsFixedCode, IntPpIDQtyI, "N", SysMessageClass.UseId, IsScanCustProAndQtyI,
                                      IsSystemPrintCarton, IsSystemPrintQRCode, IsSystemPrintPECarton, IsSystemPrintPpID)
        Next
        Return strInsertSQL.ToString
    End Function

    '汇出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        If Me.LPartDg.RowCount <= 0 Then
            Exit Sub
        End If
        Dim dtExportData As DataTable = dtData.Copy
        For i As Integer = 0 To dtExportData.Columns.Count - 1
            dtExportData.Columns(i).Caption = Me.LPartDg.Columns(i).HeaderText
        Next
        SysBasicClass.Export.ExportExcelFromDataGridView("料件包装扫描参数设置数据", dtExportData)
    End Sub

    '双击查询历史编辑记录
    Private Sub LPartDg_DoubleClick(sender As Object, e As EventArgs) Handles LPartDg.DoubleClick
        If Me.LPartDg.RowCount <= 0 Then
            Exit Sub
        End If
        If Me.LPartDg.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim frm As FrmPackingPartSetLog = New FrmPackingPartSetLog(Me.LPartDg.Item("LPartID", Me.LPartDg.CurrentRow.Index).Value.ToString.Trim)
        frm.ShowDialog()
    End Sub
End Class