#Region "Imports"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

#End Region

Public Class FrmHWPackWeight

#Region "公共变量定义"

    Public opflag As Int16 = 0
    Public frmRstationid As String = ""
    Public frmRstationname As String = ""
    Public frmStationtype As String = ""

    Private Enum CDImportGrid
        PackNum
        PackID
        PartID
        Qty
        JianShu
        PackCode
        OrderNo
        NetWeight
        GrossWeight
        Size
        Volume
        OverSeaBoxNo
        'State
        'FactoryID
        'profitcenter
        'UseY
    End Enum

    Private Enum gridPackWeight
        SheetNo
        PartID
        RequestQty
        NetWeight
        GrossWeight
        UserID
        State
        RealWeight
        WeightTime
    End Enum

#End Region

#Region "处理按键事件"

    Private Sub FrmHWPackList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab 舱龄 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38
            Case 39
            Case 40
            Case 27 'Esc
                Me.Close()
        End Select
    End Sub

    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Erightbutton() '
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvPackWeight.Enabled = True
    End Sub
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass

        Dim Reader As SqlDataReader = Conn.GetDataReader("select Factoryid,Shortname from m_Dcompany_t where Usey='Y'")
        If Reader.HasRows Then
            While Reader.Read
                ' cbbFactory.Items.Add(Reader!Factoryid & "-" & Reader!Shortname)
            End While
        End If
        Reader.Close()

    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 'default
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False

                'GroupBox
                Me.txtRequestQty.Enabled = False
                Me.txtOverSeaBoxNo.Enabled = False
                Me.txtPartID.Enabled = False
                ' Me.dgvPackList.Enabled = False

                Me.ActiveControl = Me.txtOverSeaBoxNo
            Case 1, 2  '1, 2.Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtRequestQty.Enabled = True
                Me.txtPartID.Enabled = True
                'Me.txtStationName.Enabled = False
                ' Me.dgvPackList.Enabled = False
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                Me.txtRequestQty.Enabled = False
                Me.txtPartID.Enabled = True
                Me.txtPartID.Enabled = True
                Me.dgvPackWeight.Enabled = True

                Me.ActiveControl = Me.txtPartID
        End Select
    End Sub

#End Region


    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""
        Try

            dgvPackWeight.Rows.Clear()
            SqlStr = " SELECT PackNum ,PackID,[PartID],Qty,PackCode,OrderNo,NetWeight,GrossWeight,Size,Volume,OverSeaBoxNo," & _
                     " (a.UserID+'/'+b.UserName)UserID,a.Intime,Case [State] When  0 THEN  N'未称重' WHEN 1 THEN N'称重OK' WHEN 2 THEN N'称重NG' END State , " & _
                     " RealWeight,WeightTime " & _
                     " FROM m_HWPackWeightM_t a LEFT JOIN m_users_t  b ON a.userid = b.userid  " & _
                     " WHERE 1=1 "
            Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
            Do While Dreader.Read()
                dgvPackWeight.Rows.Add(
                                     Dreader.Item("PackNum").ToString, Dreader.Item("PackID").ToString, Dreader.Item("PartID").ToString, _
                                     Dreader.Item("Qty").ToString, Dreader.Item("PackCode").ToString, Dreader.Item("OrderNo").ToString, _
                                     Dreader.Item("NetWeight").ToString, Dreader.Item("GrossWeight").ToString, _
                                     Dreader.Item("Size").ToString, Dreader.Item("Volume").ToString, Dreader.Item("OverSeaBoxNo").ToString, _
                                      Dreader.Item("UserID").ToString, Dreader.Item("Intime").ToString, _
                                         Dreader.Item("State").ToString, Dreader.Item("RealWeight").ToString, Dreader.Item("WeightTime").ToString
                                     )
            Loop
            Dreader.Close()
            toolStripStatusLabel3.Text = Me.dgvPackWeight.Rows.Count
            Conn = Nothing




        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackWeight", "LoadDataToDatagridview", "BasicM")
        End Try
    End Sub



#Region "检查"
    '
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvPackWeight.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '
    Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPackWeight.CellDoubleClick
        tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtOverSeaBoxNo.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.txtOverSeaBoxNo
            Return False
        End If
        If Me.txtPartID.Text.Trim = "" Then
            LblMsg.Text = "部门名称不能为空..."
            Me.ActiveControl = Me.txtPartID
            Return False
        End If
        Return True
    End Function

#End Region

#Region "New Add/Modify"
    'New Add
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtOverSeaBoxNo.Text = ""
        txtRequestQty.Text = ""
        txtPartID.Text = ""
        opflag = 1
        ToolbtnState(1)
        txtOverSeaBoxNo.Enabled = True
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvPackWeight.Rows.Count = 0 OrElse Me.dgvPackWeight.CurrentRow Is Nothing Then Exit Sub
        txtOverSeaBoxNo.Text = dgvPackWeight.CurrentRow.Cells(gridPackWeight.SheetNo).Value
        txtPartID.Text = dgvPackWeight.CurrentRow.Cells(gridPackWeight.PartID).Value
        txtRequestQty.Text = dgvPackWeight.CurrentRow.Cells(gridPackWeight.RequestQty).Value

        opflag = 2
        ToolbtnState(2)
    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.dgvPackWeight.Rows.Count = 0 OrElse Me.dgvPackWeight.CurrentRow Is Nothing Then Exit Sub
        Dim lsSQL As String = ""
        Try
            lsSQL = " UPDATE m_HWPackWeight_t SET usey='0' " & _
                    " WHERE SheetNo = '" & dgvPackWeight.CurrentRow.Cells(gridPackWeight.SheetNo).Value & "'"
            sConn.ExecSql(lsSQL)

            LoadDataToDatagridview(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackWeight", "tsbAbandon_Click", "BasicM")
        Finally
            sConn = Nothing
        End Try

    End Sub
    '
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = ""
        Dim lsSQL As String = ""

        If Checkdata() = False Then Exit Sub

        If opflag = 1 Then

            lsSQL = "SELECT PartID FROM m_HWPackWeight_t WHERE PackID='" & Me.txtOverSeaBoxNo.Text.Trim() & "'"

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader(lsSQL)
            If mCheckCodeRead.HasRows Then
                mCheckCodeRead.Close()
                MessageBox.Show("该箱名已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            SqlStr.Append(ControlChars.CrLf & "INSERT into m_HWPackWeight_t([PackID],[PartID] ,[Qty] ,[UserID],[Intime],")
            SqlStr.Append("[ScanQty],[State],[FactoryID],[profitcenter],useY) ")
            SqlStr.Append(" VALUES('" & txtOverSeaBoxNo.Text & "',N'" & txtPartID.Text.Trim & "','" & Me.txtRequestQty.Text.Trim & "',  '" & VbCommClass.VbCommClass.UseId & "',getdate(), 0, 0, ")
            SqlStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "',1 )")

        ElseIf opflag = 2 Then
            SqlStr.Append(" UPDATE m_HWPackList_t SET PartID =N'" & txtPartID.Text.Trim & "',Qty =N'" & txtRequestQty.Text.Trim & "' ")
            SqlStr.Append(" WHERE PackID = '" & txtOverSeaBoxNo.Text.Trim & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" ")



            txtPartID.Text = ""
            txtPartID.Text = ""
            txtRequestQty.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmHWPackList", "tsbSave_Click", "BasicM")
            Exit Sub
        End Try
    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtOverSeaBoxNo.Text = ""
        txtPartID.Text = ""
        txtRequestQty.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub

    '
    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''If Me.toolCheck.Enabled = False Then Exit Sub
        'If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.CurrentRow.Cells("ColUsey").Value <> "Y" Then
        '    MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        '  LoadDataToDatagridview(" ")

        ToolbtnState(1)
        Me.txtOverSeaBoxNo.Enabled = True
    End Sub


#Region "汇入汇出操作"
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Dim strTmpPO As String = ""
        Dim strTmpOverSeaBoxNo As String = ""
        Dim strTmpSheetNO As String = "", strTmpPartID As String = "", strTmpRequestQty As String = ""
        Try

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 12, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)


            If Not IsDBNull(dtUploadData.Rows(1).Item(2)) Then
                strTmpOverSeaBoxNo = dtUploadData.Rows(1).Item(2)
                '  strTmpHWCartonID = strTmpHWCartonID.Replace("：", ":")
                ' strTmpHWCartonID = strTmpHWCartonID.Substring(strTmpHWCartonID.LastIndexOf(":") + 1)
            Else
                strTmpOverSeaBoxNo = ""
            End If

            If String.IsNullOrEmpty(strTmpOverSeaBoxNo) Then
                MessageUtils.ShowError("抓取装箱单号失敗,請檢查導入文件！")
                Exit Sub
            End If


            For i As Integer = 0 To 2
                dtUploadData.Rows.RemoveAt(0)
            Next

            Dim DrrR As DataRow() = dtUploadData.Select(" PackNum is not null ") '防止追加SheetNo IS NOT NULL AND PartID IS NOT NULL

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("UserID", "System.String", dtUploadData)
            TableAddColumns("Intime", "System.String", dtUploadData)
            TableAddColumns("RealWeight", "System.String", dtUploadData)
            TableAddColumns("WeightTime", "System.String", dtUploadData)
            TableAddColumns("State", "System.String", dtUploadData)
            TableAddColumns("FactoryID", "System.String", dtUploadData)
            TableAddColumns("profitcenter", "System.String", dtUploadData)
            TableAddColumns("UseY", "System.String", dtUploadData)
            TableAddColumns("WeightUserID", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New Dictionary(Of String, String)
            dics2.Add("PackNum", "PackNum")  '[PackNum],[PackID],[PartID] 0-2
            dics2.Add("PackID", "PackID")
            dics2.Add("PartID", "PartID")
            dics2.Add("Qty", "Qty") '[Qty],[JianShu],[PackCode] 3-5
            dics2.Add("JianShu", "JianShu")
            dics2.Add("PackCode", "PackCode")
            dics2.Add("OrderNo", "OrderNo")  '  ,[OrderNo] ,[NetWeight], GrossWeight  6-8
            dics2.Add("NetWeight", "NetWeight")
            dics2.Add("GrossWeight", "GrossWeight")
            dics2.Add("Size", "Size") '[Size], [Volume], OverSeaPackNo 9-11
            dics2.Add("Volume", "Volume")
            dics2.Add("OverSeaBoxNo", "OverSeaBoxNo")
            dics2.Add("UserID", "UserID")   'UserID,Intime,RealWeight 12-14
            dics2.Add("Intime", "Intime")
            dics2.Add("RealWeight", "RealWeight")
            dics2.Add("WeightTime", "WeightTime")  'WeightTime,State,FactoryID 15-17
            dics2.Add("State", "State")
            dics2.Add("FactoryID", "FactoryID")
            dics2.Add("profitcenter", "profitcenter") 'profitcenter,UseY 18-20
            dics2.Add("UseY", "UseY")
            dics2.Add("WeightUserID", "WeightUserID")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    strTmpSheetNO = row(0).ToString : strTmpPartID = row(1).ToString() : strTmpRequestQty = row(3).ToString
                    usercopy.Rows.Add(
                           row(0).ToString(), row(1).ToString(), row(2).ToString(), _
                           row(3).ToString(), row(4).ToString(), row(5).ToString(),
                           row(6).ToString(), row(7).ToString(), row(8).ToString(),
                           row(9).ToString(), row(10).ToString(), strTmpOverSeaBoxNo,
                           VbCommClass.VbCommClass.UseId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), DBNull.Value,
                           DBNull.Value, 0, VbCommClass.VbCommClass.Factory, _
                           VbCommClass.VbCommClass.profitcenter, "1", "")
                Else
                    'usercopy.Rows.Add(
                    '    strTmpSheetNO, strTmpPartID, row(2).ToString(), _
                    '    strTmpRequestQty, row(4).ToString(), row(5).ToString(),
                    '    row(6).ToString(), row(7).ToString(), row(8).ToString(),
                    '    row(9).ToString(), row(10).ToString(), row(11).ToString(),
                    '    row(12).ToString(), row(13).ToString(), row(14).ToString(),
                    '    row(15).ToString(), row(16).ToString(), row(17).ToString(),
                    '    row(18).ToString(), row(19).ToString(), row(20).ToString(),
                    '    VbCommClass.VbCommClass.UseId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), 0,
                    '    DBNull.Value, 0, VbCommClass.VbCommClass.Factory, _
                    '    VbCommClass.VbCommClass.profitcenter, "1", strTmpPO, _
                    '    strTmpOverSeaBoxNo, "")
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_HWPackWeightM_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    '  SearchRecord("")
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmHWPackList", "toolImport_Click", "BasicM")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub


    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)

        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB中箱号
        Dim strSQL As String = " SELECT PackID FROM m_HWPackWeightM_t WHERE usey='1' "
        Dim dtSheetNo As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1
            Dim returnCode As String = ""
            Dim SheetNO_BoxNo As String = DrrR(index)(CDImportGrid.PackID.ToString).ToString.Trim
            Dim values As String = SheetNO_BoxNo

            If hastable.Contains(values) Then
                MessageUtils.ShowError(String.Format("上传文件中有重复的箱名{0}", SheetNo))
                Return False
            Else
                hastable.Add(values, values)
            End If

            If SheetNO_BoxNo <> "" Then
                If CheckExistUserColumns(dtSheetNo, "PackID", SheetNO_BoxNo, "") = True Then
                    MessageUtils.ShowError("数据库中箱名有重复数据：'" + SheetNO_BoxNo + "'")
                    Return False
                End If
            Else
                'mark by cq20170928,  sheetno 为合并单元格, by pass check
                ' MessageUtils.ShowError("备货单号有空值,请检查后重新上传。")
                'Return False
            End If
        Next

        Return True
    End Function

    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

#End Region


    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles FileRefresh.Click

        Dim SqlStr As String = ""
        If Me.txtOverSeaBoxNo.Text <> "" Then
            SqlStr = " AND OverSeaBoxNo LIKE '%" & Trim(txtOverSeaBoxNo.Text) & "%'"
        End If
        If Me.txtPartID.Text <> "" Then
            SqlStr = " AND  PartID like '%" & Trim(txtPartID.Text) & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
    End Sub
End Class