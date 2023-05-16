Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports MainFrame.SysDataHandle
Imports System.Reflection
Imports System.Data.SqlClient

Public Class FrmMouldManagement

#Region "枚举定义"
    Private Enum CDImportGrid
        MouldID     '模号
        UsedTimes '使用次数
    End Enum
#End Region

#Region "初始化"
    Private Sub FrmMouldManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCombox(cboStorage) '加载储位信息
        '  Erightbutton()  '权限

        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        ToolbtnState()  '按钮状态
        LoadMouldData() '数据初始化
    End Sub
#End Region

#Region "事件"
    '基础信息
    Private Sub toolMouldBasis_Click(sender As Object, e As EventArgs) Handles toolMouldBasis.Click
        Dim frm As FrmMouldBasis = New FrmMouldBasis
        frm.ShowDialog()
    End Sub

    '储位维护
    Private Sub toolStorage_Click(sender As Object, e As EventArgs) Handles toolStorage.Click
        Dim frm As FrmMoudleStorage = New FrmMoudleStorage
        frm.ShowDialog()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        LoadMouldData()
    End Sub

    '模具图档
    Private Sub toolMouldPic_Click(sender As Object, e As EventArgs) Handles toolMouldPic.Click
        If dgvBasis.Rows.Count <= 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        Dim frm As FrmMouldPic = New FrmMouldPic
        frm.MouldID = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
    End Sub

    Private Sub toolMouldRepair_Click(sender As Object, e As EventArgs) Handles toolMouldRepair.Click
        If dgvBasis.Rows.Count <= 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        Dim frm As FrmMouldRepair = New FrmMouldRepair
        frm.RepairMouldID = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
    End Sub

    '模具寿命管制
    Private Sub toolMouldLife_Click(sender As Object, e As EventArgs) Handles toolMouldLife.Click
        If dgvBasis.Rows.Count <= 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        Dim frm As FrmMouldLife = New FrmMouldLife
        frm.LifeMouldID = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '模号回车事件
    Private Sub txtMouldID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMouldID.KeyPress
        If e.KeyChar = Chr(13) Then
            LoadMouldData()
        End If
    End Sub

    'Tab面板切换事件
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If dgvBasis.Rows.Count = 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
            Dim mouldId As String = txtMouldID.Text.Trim
            Dim Parts As String = txtParts.Text.Trim
            Dim type As String
            Dim state As String
            If cboStatus.Text.Trim = "" Then
                type = ""
            Else
                type = cboStatus.Text.Trim.Substring(0, 1)
            End If
            If CheckBox1.Checked = True Then
                state = "Y"
            Else
                state = "N"
            End If

            Dim strSQL As String = String.Format(" exec Exec_MouldManagement '{0}','{1}',N'','','','','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','{2}'", mouldId, Parts, state)
            Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
            dgvBasis.DataSource = ds.Tables(0) 'add by cq 20190525
            dgvInOut.DataSource = ds.Tables(1)
            dgvRepair.DataSource = ds.Tables(2)
            dgvLife.DataSource = ds.Tables(3)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldManagement", "TabControl1_SelectedIndexChanged", "sys")
        End Try
    End Sub

    '出库
    Private Sub toolMouldOut_Click(sender As Object, e As EventArgs) Handles toolMouldOut.Click
        If dgvBasis.Rows.Count <= 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        Dim frm As FrmMouldOut = New FrmMouldOut
        frm.MouldID = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
    End Sub

    '入库
    Private Sub toolMouldIn_Click(sender As Object, e As EventArgs) Handles toolMouldIn.Click
        If dgvBasis.Rows.Count <= 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        Dim frm As FrmMouldIn = New FrmMouldIn
        frm.MouldID = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
    End Sub

    '下载模具使用数据导入模板
    Private Sub toolLoadMoBan_Click(sender As Object, e As EventArgs) Handles toolLoadMoBan.Click
        Try
            Dim ssf = New SaveFileDialog()
            ssf.FileName = "模具寿命导入模板.xls"
            ssf.Filter = "Excel|*.xls"
            If ssf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                    Dim data = System.IO.File.ReadAllBytes("\\192.168.20.123\SFCShare\File\模具导入模板\模具寿命导入模板.xls")
                    fs.Write(data, 0, data.Length)
                    fs.Flush()
                End Using
                MessageUtils.ShowInformation("下载成功!")
            Else
                MessageUtils.ShowInformation("下载失败!")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("下载异常:" & vbCrLf & ex.Message)
        End Try
    End Sub

    '模具使用数据导入
    Private Sub toolMouldImport_Click(sender As Object, e As EventArgs) Handles toolMouldImport.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传数据 （16：代表16列数据）
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 2, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" ")
            '= dtUploadData.Select(" Station is not null") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '数据插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)
            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入!")
            End If

            LoadMouldData() '数据初始化
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldManagement", "toolMouldImport_Click", "sys")
        End Try
    End Sub

    'DatagridView颜色显示
    Private Sub dgvBasis_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvBasis.DataBindingComplete
        Dim usedTimes As Integer    '使用次数
        Dim alertTimes As Integer   '预警次数
        Dim limitTimes As Integer   '寿命次数

        Try
            For Each item As DataGridViewRow In dgvBasis.Rows
                usedTimes = CInt(item.Cells("UsedTimes").Value.ToString)
                alertTimes = CInt(item.Cells("AlertTimes").Value.ToString)
                limitTimes = CInt(item.Cells("LimitTimes").Value.ToString)

                If usedTimes >= limitTimes Then
                    item.DefaultCellStyle.BackColor = Color.Red
                ElseIf usedTimes >= alertTimes Then
                    item.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "方法"
    '设置按钮状态
    Private Sub ToolbtnState()
        If IsNothing(toolMouldBasis.Tag) Then
            toolMouldBasis.Enabled = False
        Else
            toolMouldBasis.Enabled = IIf(toolMouldBasis.Tag.ToString.ToUpper() <> "YES", False, True)
        End If

        If IsNothing(toolMouldIn.Tag) Then
            toolMouldIn.Enabled = False
        Else
            toolMouldIn.Enabled = IIf(toolMouldIn.Tag.ToString.ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolMouldOut.Tag) Then
            toolMouldOut.Enabled = False
        Else
            toolMouldOut.Enabled = IIf(toolMouldOut.Tag.ToString().ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolMouldImport.Tag) Then
            toolMouldImport.Enabled = False
        Else
            toolMouldImport.Enabled = IIf(toolMouldImport.Tag.ToString.ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolMouldPic.Tag) Then
            toolMouldPic.Enabled = False
        Else
            toolMouldPic.Enabled = IIf(toolMouldPic.Tag.ToString.ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolMouldRepair.Tag) Then
            toolMouldRepair.Enabled = False
        Else
            toolMouldRepair.Enabled = IIf(toolMouldRepair.Tag.ToString.ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolStorage.Tag) Then
            toolStorage.Enabled = False
        Else
            toolStorage.Enabled = IIf(toolStorage.Tag.ToString.ToUpper <> "YES", False, True)
        End If

        If IsNothing(toolMouldLife.Tag) Then
            toolMouldLife.Enabled = False
        Else
            toolMouldLife.Enabled = IIf(toolMouldLife.Tag.ToString.ToUpper <> "YES", False, True)
        End If
    End Sub

    '权限
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02027' and b.listy='N' " & _
                " WHERE a.userid='" & SysMessageClass.UseId.ToLower.Trim & "' AND ISNULL(b.ButtonID,'') <>''"
        Dim Reader As SqlDataReader = Conn.GetDataReader(lsSQL)
        Dim Obj As Object
        While Reader.Read          '
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
        Conn = Nothing
    End Sub

    '加载储位信息
    Private Sub FillCombox(ByVal comboBox As ComboBox)
        Dim strSQL As String
        Dim dt As DataTable
        If comboBox.Name = "cboStorage" Then
            strSQL = "select '' StorageID,'' Warehouse union select StorageID,Warehouse  from m_Storage_t where FactoryID='" + VbCommClass.VbCommClass.Factory + "' and Usey ='Y'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            comboBox.DataSource = dt
            comboBox.DisplayMember = "StorageID"
            comboBox.ValueMember = "StorageID"
        End If
        dt = Nothing
    End Sub

    '加载模具基础信息
    Private Sub LoadMouldData()
        Dim type As String
        Dim state As String
        If cboStatus.Text.Trim = "" Then
            type = ""
        Else
            type = cboStatus.Text.Trim.Substring(0, 1)
        End If
        If CheckBox1.Checked = True Then
            state = "Y"
        Else
            state = "N"
        End If
        Dim MouldID As String = txtMouldID.Text.Trim
        Dim Parts As String = txtParts.Text
        Dim Location As String = txtLocation.Text.Trim
        Dim Storage As String = cboStorage.Text.Trim
        Dim AssetsID As String = txtAssetsID.Text.Trim
        Try
            'Dim strSQL As String = String.Format(" exec Exec_MouldManagement '{0}','{1}',N'{2}','{3}','{4}','{5}','{6}','{7}'", MouldID, Parts, Location, Storage, AssetsID, type, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dim strSQL As String = String.Format(" exec Exec_MouldManagement '{0}','{1}',N'{2}','{3}','{4}','{5}','{6}','{7}','{8}'", MouldID, Parts, Location, Storage, AssetsID, type, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, state)
            Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
            dgvBasis.DataSource = ds.Tables(0)
            dgvLife.DataSource = ds.Tables(3)
            dgvPastr.DataSource = ds.Tables(4)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldManagement", "LoadMouldData", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 改变列名
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB 模号
        Dim mouldIdSQL As String = " select MouldID,* from m_Mould_t "
        Dim mouldIdDT As DataTable = DbOperateUtils.GetDataTable(mouldIdSQL)

        Dim hashtable As Hashtable = New Hashtable

        For index As Integer = 0 To DrrR.Length - 1
            '模号
            Dim strMouldId As String = DrrR(index)("MouldID").ToString.Trim
            If hashtable.Contains(strMouldId) Then
                MessageUtils.ShowError("上传数据中有重复的模号[" + strMouldId + "]")
                Return False
            End If

            If strMouldId <> "" Then
                If CheckExistUserColumns(mouldIdDT, "MouldID", strMouldId) = False Then
                    MessageUtils.ShowError("上传[模号]不在资料库中:'" & strMouldId & "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("[模号]中有空值，请检查后重新上传")
                Return False
            End If

            '使用次数
            Dim strUsedTimes As String = DrrR(index)("UsedTimes").ToString.Trim
            If Not IsNumeric(strUsedTimes) Then
                MessageUtils.ShowWarning("[使用次数]应为数字类型，请检查后重新上传!")
                Return False
            End If
            If CInt(strUsedTimes) <= 0 Then
                MessageUtils.ShowWarning("[使用次数]应大于0，请检查后重新上传!")
                Return False
            End If

            hashtable.Add(strMouldId, strMouldId)
        Next
        Return True
    End Function

    '检查方法
    Private Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0}='{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '插入语句
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim strSQL As String = "update m_Mould_t set UsedTimes=UsedTimes+{0}  where MouldID='{1}'"
        Dim strUpdateSQL As New StringBuilder
        For Each row As DataRow In DRS
            strUpdateSQL.AppendFormat(strSQL, row(1).ToString, row(0).ToString)
            strUpdateSQL.AppendLine()
        Next
        Return strUpdateSQL.ToString
    End Function
#End Region
 
#Region "Grid行数"
    Private Sub dgvBasis_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvBasis.RowPostPaint, dgvRepair.RowPostPaint, dgvLife.RowPostPaint, dgvInOut.RowPostPaint,dgvPastr.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub tsmi_MaintenanceType_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceType.Click
        Dim frmmaintenType As New FrmEquMaintenanceType()
        frmmaintenType.ShowDialog()
    End Sub

    Private Sub tsmi_MaintenanceDay_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceDay.Click

        If Me.dgvBasis.CurrentRow Is Nothing OrElse Me.dgvBasis.RowCount < 1 Then Exit Sub
        Dim AssetName As String = "", AssetNo As String = "", Model As String
        AssetNo = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString  'Cells(0) 为绘制的编号
        AssetName = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString
        Model = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString
        Dim frmMpDay As New FrmEquMaintenanceDay(AssetNo, AssetName, Model)
        frmMpDay.ShowDialog()




    End Sub

    Private Sub tsmi_MaintenanceMonth_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceMonth.Click

        If Me.dgvBasis.CurrentRow Is Nothing OrElse Me.dgvBasis.RowCount < 1 Then Exit Sub
        Dim AssetName As String = "", AssetNo As String = "", Model As String = "", Storage As String = ""
        AssetNo = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString
        AssetName = Me.dgvBasis.CurrentRow.Cells("Type").Value.ToString
        Model = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString
        Storage = Me.dgvBasis.CurrentRow.Cells(1).Value.ToString
        Dim frmMpMorQ As New FrmEquMaintenanceMonth(AssetNo, AssetName, Model, Storage)
        frmMpMorQ.ShowDialog()



    End Sub

    Private Sub tsmiMaintenanceDetails_Click(sender As Object, e As EventArgs) Handles tsmiMaintenanceDetails.Click
        Dim EquimentNO As String = ""
        EquimentNO = dgvBasis.CurrentRow.Cells("MouldID").Value.ToString

        Dim frm = New FrmMaintenanceDetails()
        frm.EquimentNO = EquimentNO
        frm.ShowDialog()
    End Sub

    Private Sub dgvBasis_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim EquimentNO As String = ""
        EquimentNO = dgvBasis.CurrentRow.Cells("MouldID").Value.ToString
        Dim frm As FrmWireslot = New FrmWireslot
        frm.MouldID = EquimentNO
        frm.ShowDialog()
    End Sub

    Private Sub dgvBasis_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBasis.CellDoubleClick
        Dim EquimentNO As String = ""
        EquimentNO = dgvBasis.CurrentRow.Cells("MouldID").Value.ToString
        Dim frm As Frmslotdetails = New Frmslotdetails
        frm.MouldID = EquimentNO
        frm.ShowDialog()
    End Sub

    Private Sub dgvBasis_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBasis.CellClick
        Dim strURL As String
        Try
            If dgvBasis.Columns(e.ColumnIndex).Name = "MoldDrawingp" Then
                strURL = dgvBasis.CurrentRow.Cells("MoldDrawing").Value.ToString
            ElseIf dgvBasis.Columns(e.ColumnIndex).Name = "ProductDrawingp" Then
                strURL = dgvBasis.CurrentRow.Cells("ProductDrawing").Value.ToString
            ElseIf dgvBasis.Columns(e.ColumnIndex).Name = "FIlePathp" Then
                strURL = dgvBasis.CurrentRow.Cells("FIlePath").Value.ToString
            End If

            If Not String.IsNullOrEmpty(strURL) Then
                System.Diagnostics.Process.Start(strURL)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvLife_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLife.CellClick
        Dim Mouldid As String
        Try
            If dgvLife.Columns(e.ColumnIndex).Name = "query" Then
                Mouldid = dgvLife.CurrentRow.Cells("MouldID4").Value.ToString
                Dim frm As FrmLifecontrol = New FrmLifecontrol
                frm.Mouldid = Mouldid
                frm.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class