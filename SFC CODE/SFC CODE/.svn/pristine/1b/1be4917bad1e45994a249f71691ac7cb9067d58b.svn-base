Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports LXWarehouseManage
Imports MainFrame
Imports VbCommClass
Imports SysBasicClass

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/09/08
''' </summary>
''' <remarks>修改流程卡后影响范围</remarks>
Public Class FrmPartContrast

    Dim StrOldPart As String
    Dim StrOldPartp As String
    Private buttonStatus As EnumStatus

    Private Enum EnumStatus
        UnDo = -1
        NewAdd = 0
        Edit = 1
        Delete = 2
        DownLoad = 3
        Search = 4
    End Enum

    Public Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        ParentFormat
        ChildFormat
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        ExtensibleF
        Qty
        CustID
        SerialID
    End Enum

    Private Enum CDImportGrid
        TAvcPart
        TypeDest
        DESCRIPTION
        Userid
    End Enum

#Region "所有事件"

    Private Sub FrmPartContrast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lsSQL As String = ""
        Try
            lsSQL = "SELECT cusid,cusname FROM m_Customer_t WHERE usey='Y' " 'Modify by cq20151231
            'select top 100 cusid,cusname from m_Customer_t where usey='Y' and  cusid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='c0_' and userid='" & SysMessageClass.UseId & "')
            FillGridCombox(Me.CobCust, lsSQL)
            FillGridCombox(Me.CobSerial, "SELECT [SeriesID],[SeriesName] FROM [m_Series_t] WHERE Usey='Y'")
            FillGridCombox(Me.CobPartDes, "SELECT SortID,SortName from dbo.m_Sortset_t where sorttype='PartType' and usey='Y'")
            FillGridCombox(Me.CobPartCode, "SELECT SortID,SortName from dbo.m_Sortset_t where sorttype='PartCode' and usey='Y'")
            FillGridCombox(Me.CobSupplyCode, "SELECT SortID,SortName from dbo.m_Sortset_t where sorttype='SubSupplierName' and usey='Y'")
            FillGridCombox(Me.CobPartSeriesType, "SELECT PartSeriesTypeCode, PartSeriesTypeName FROM m_PartSeriesType_t WHERE usey='Y'")

            buttonStatus = EnumStatus.UnDo
            SearchRecord("")
            SetValueToControl()
            SetControlStates()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartContrast", "FrmPartContrast_Load", "sys")
        End Try
    End Sub

    Private Sub NewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFile.Click
        buttonStatus = EnumStatus.NewAdd
        AddRecord()
        TabControl1.Enabled = False
        Me.TxtTavcPart.Focus()
        If rdoEqu.Checked = True Then ' 自动切换到工治具
            TabControl1.SelectedIndex = 1
        End If
        If TabControl1.SelectedIndex = 0 Then
            Me.UpLmt.Value = 365
            Me.UpYttishi.Value = 7
            TxtTavcPart.Enabled = True
        ElseIf TabControl1.SelectedIndex = 1 Then
            TxtTavcPart.Enabled = True
            TxtPavcPart.Enabled = False
            SetBomEnable()
        End If
    End Sub

    Private Sub EditFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditFile.Click
        If DgPartContrast.RowCount < 1 Then Exit Sub
        If Me.DgPartContrast.CurrentRow.Index = -1 Then Exit Sub
        buttonStatus = EnumStatus.Edit

        EditRecord()
        SetValueToControl()
        Me.TxtTavcPart.Focus()
        Me.TxtPavcPart.Enabled = False
        TabControl1.Enabled = False
        If TabControl1.SelectedIndex = 0 Then
            StrOldPart = Me.DgPartContrast.CurrentRow.Cells(0).Value
            StrOldPartp = Me.DgPartContrast.CurrentRow.Cells(1).Value.ToString
        ElseIf TabControl1.SelectedIndex = 1 Then
            StrOldPart = Me.DgPartContrast2.CurrentRow.Cells(0).Value
            StrOldPartp = Me.DgPartContrast2.CurrentRow.Cells(1).Value.ToString
            SetBomEnable()
        End If
    End Sub

    Private Sub SetBomEnable()
        CobCust.Enabled = False
        TxtCustPartID.Enabled = False
        CobPartCode.Enabled = False
        CobSupplyCode.Enabled = False
        CobSerial.Enabled = False
        UpLmt.Enabled = False
        UpYttishi.Enabled = False
        ChKisUpload.Enabled = False
        ChkAssemble.Enabled = False
        ChkIsLot.Enabled = False
        ChkAlter.Enabled = False
        Chkcheck.Enabled = False
        ChkTransData.Enabled = False
        rdoPN.Enabled = False
        rdoEqu.Enabled = False
    End Sub

    Private Sub btnDownloadFromERP_Click(sender As Object, e As EventArgs) Handles btnERP.Click
        buttonStatus = EnumStatus.DownLoad
        ErpDownLoad()
        TxtTavcPart.Enabled = True
        Me.TxtTavcPart.Focus()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            SaveData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartContrast", "Save_Click", "sys")
        End Try
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            DeleteRecord()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartContrast", "Delete_Click", "sys")
        End Try
    End Sub

    Private Sub UnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnDo.Click
        buttonStatus = EnumStatus.UnDo
        CancelChg()
    End Sub

    Private Sub Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Export.Click
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        buttonStatus = EnumStatus.Search

        SetButtonEnable(False)
        Save.Enabled = False
        toolSaveType.Enabled = True
        FileRefresh.Enabled = True
        TxtTavcPart.Enabled = True
        TxtPavcPart.Enabled = True
        CobCust.Enabled = True
        TxtCustPartID.Enabled = True
        Me.TxtTavcPart.Focus()
        ClearControl()
    End Sub

    Private Sub FileRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileRefresh.Click
        Try
            If buttonStatus = EnumStatus.DownLoad Then
                If ErpDownLoadData() Then
                    Save.Enabled = True
                Else
                    Save.Enabled = False
                End If
            Else
                If buttonStatus <> EnumStatus.Search Then
                    SearchRecord("")
                    SetValueToControl()
                    Exit Sub
                End If

                Dim SqlStr As String = ""
                If Me.TxtTavcPart.Text <> "" Then
                    SqlStr = " and a.tavcpart like '%" & Trim(TxtTavcPart.Text) & "%'"
                End If
                If Me.TxtPavcPart.Text <> "" Then
                    SqlStr = " and a.pavcpart like '" & Trim(TxtPavcPart.Text) & "%'"
                End If
                If Me.CobCust.Text <> "" Then
                    SqlStr = SqlStr + " and a.cusid = '" & Mid(Trim(Me.CobCust.Text), 1, InStr(Trim(Me.CobCust.Text), "(") - 1) & "'"
                End If
                If Me.TxtCustPartID.Text <> "" Then
                    SqlStr = SqlStr + " and a.CustPart like '" & Trim(TxtCustPartID.Text) & "%'"
                End If
                If Me.rdoPN.Checked Then
                    SqlStr = SqlStr + " and isnull(a.Type,'R') = 'R'"
                    Me.TabControl1.SelectedIndex = 0
                Else
                    SqlStr = SqlStr + " and isnull(a.Type,'R') = 'E'"
                    Me.TabControl1.SelectedIndex = 1
                End If

                SearchRecord(SqlStr)
                EditFile.Enabled = True
                Delete.Enabled = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartContrast", "FileRefresh_Click", "sys")
        End Try
    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub DgPartContrast_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPartContrast.CellClick
        If DgPartContrast.RowCount < 1 Then Exit Sub
        SetValueToControl(DgPartContrast)
    End Sub

    Private Sub DgPartContrast2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPartContrast2.CellClick
        If DgPartContrast2.RowCount < 1 Then Exit Sub
        SetValueToControl(DgPartContrast2)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            FillGridCombox(Me.CobPartDes, "select SortID,SortName from dbo.m_Sortset_t where sorttype='PartType' and usey='Y'")
            rdoPN.Checked = True
            ToolStripStatusLabel1.Text = DgPartContrast.Rows.Count & "笔"
        ElseIf TabControl1.SelectedIndex = 1 Then
            FillGridCombox(Me.CobPartDes, "select CODE,NAME from m_EquipmentCategory_t where Status=1 AND TYPE = 'MID' ")
            rdoEqu.Checked = True
            ToolStripStatusLabel1.Text = DgPartContrast2.Rows.Count & "笔"
        Else
            ToolStripStatusLabel1.Text = dgvBomInfo.Rows.Count & "笔"
        End If
    End Sub

#End Region

#Region "Gird选择设置数据"

    Sub SetValueToControl()
        If TabControl1.SelectedIndex = 0 Then
            SetValueToControl(DgPartContrast)
        ElseIf TabControl1.SelectedIndex = 1 Then
            SetValueToControl(DgPartContrast2)
        End If
    End Sub

    Private Sub SetValueToControl(dgGrid As DataGridView)

        If dgGrid.RowCount < 1 Then Exit Sub
        If dgGrid.CurrentRow.Index < 0 Then Exit Sub

        Me.rdoPN.Checked = True
        Me.CobCust.SelectedIndex = -1
        Me.TxtTavcPart.Text = dgGrid.Item(0, dgGrid.CurrentRow.Index).Value.ToString
        Me.TxtPavcPart.Text = dgGrid.Item(1, dgGrid.CurrentRow.Index).Value.ToString
        Me.CobCust.Text = dgGrid.Item(4, dgGrid.CurrentRow.Index).Value.ToString
        Me.TxtCustPartID.Text = dgGrid.Item(5, dgGrid.CurrentRow.Index).Value.ToString
        If IsDBNull(dgGrid.Item(6, dgGrid.CurrentRow.Index).Value) Then
            Me.CobSerial.SelectedIndex = -1
        Else
            Me.CobSerial.Text = dgGrid.Item(6, dgGrid.CurrentRow.Index).Value.ToString()
        End If

        Me.UpLmt.Value = IIf(dgGrid.Item(10, dgGrid.CurrentRow.Index).Value.ToString = "", 0, dgGrid.Item(10, dgGrid.CurrentRow.Index).Value.ToString)
        Me.UpYttishi.Value = IIf(dgGrid.Item(11, dgGrid.CurrentRow.Index).Value.ToString = "", 0, dgGrid.Item(11, dgGrid.CurrentRow.Index).Value.ToString)
        Me.CobPartDes.Text = IIf(dgGrid.Item(12, dgGrid.CurrentRow.Index).Value.ToString = "", 0, dgGrid.Item(12, dgGrid.CurrentRow.Index).Value.ToString)
        Me.CobPartCode.Text = IIf(dgGrid.Item(13, dgGrid.CurrentRow.Index).Value.ToString = "", 0, dgGrid.Item(13, dgGrid.CurrentRow.Index).Value.ToString)
        Me.CobSupplyCode.Text = dgGrid.Item(14, dgGrid.CurrentRow.Index).Value.ToString
        Me.ChKisUpload.Checked = IIf(dgGrid.Item(15, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.ChkAssemble.Checked = IIf(dgGrid.Item(16, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.ChkIsLot.Checked = IIf(dgGrid.Item(17, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.ChkAlter.Checked = IIf(dgGrid.Item(18, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.chkMSCust.Checked = IIf(dgGrid.Item(22, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)
        'Me.CobPartSeriesType.SelectedValue = IIf(dgGrid.Item(2, dgGrid.CurrentRow.Index).Value.ToString = "", "", dgGrid.Item(2, dgGrid.CurrentRow.Index).Value.ToString)
        Me.chkPlanType.Checked = IIf(dgGrid.Item(3, dgGrid.CurrentRow.Index).Value.ToString = "Y", True, False)

        Me.txtDescription.Text = dgGrid.Item(19, dgGrid.CurrentRow.Index).Value.ToString
        Me.rdoPN.Checked = IIf(dgGrid.Item(20, dgGrid.CurrentRow.Index).Value.ToString = "R", True, False)
        Me.rdoEqu.Checked = IIf(dgGrid.Item(20, dgGrid.CurrentRow.Index).Value.ToString = "E", True, False)
        'PartSeriesTypeName ,PartSeriesTypeName, cq 20170428
        Me.CobPartSeriesType.Text = IIf(dgGrid.Item(21, dgGrid.CurrentRow.Index).Value.ToString = "", "", dgGrid.Item(21, dgGrid.CurrentRow.Index).Value.ToString)
    End Sub
#End Region

#Region "设置控件状态"

    Private Sub SetControlStates()
        Select Case buttonStatus
            Case EnumStatus.NewAdd
                SetButtonEnable(False)
                SetControlEnable(True)
                SetErpVisible(False)
            Case EnumStatus.Edit
                SetButtonEnable(False)
                SetControlEnable(True)
                SetErpVisible(False)
            Case EnumStatus.DownLoad
                SetButtonEnable(False)
                FileRefresh.Enabled = True
                Save.Enabled = False
                SetControlEnable(False)
                SetErpVisible(True)
                If rdoPN.Checked = True Then
                    Me.CobCust.Enabled = True : Me.CobSerial.Enabled = True
                Else
                    Me.CobCust.Enabled = False : Me.CobSerial.Enabled = False
                End If
            Case EnumStatus.UnDo
                SetButtonEnable(True)
                SetControlEnable(False)
                SetErpVisible(False)
        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        NewFile.Enabled = bFlag
        EditFile.Enabled = bFlag
        Delete.Enabled = bFlag
        btnERP.Enabled = bFlag
        Save.Enabled = Not bFlag
        UnDo.Enabled = Not bFlag
        toolSaveType.Enabled = bFlag
        Export.Enabled = bFlag
        Search.Enabled = bFlag
        FileRefresh.Enabled = bFlag
    End Sub

    Private Sub SetControlEnable(bFlag As Boolean)
        Me.UpLmt.Enabled = bFlag
        Me.UpYttishi.Enabled = bFlag
        Me.CobPartCode.Enabled = bFlag
        Me.CobPartDes.Enabled = bFlag

    End Sub

    Private Sub SetErpVisible(bFlag As Boolean)
        If Not bFlag Then
            Me.TabPage1.Parent = Me.TabControl1
            Me.TabPage2.Parent = Me.TabControl1
            Me.TabPage3.Parent = Nothing
        Else
            Me.TabPage1.Parent = Nothing
            Me.TabPage2.Parent = Nothing
            Me.TabPage3.Parent = Me.TabControl1
        End If
    End Sub

#End Region

#Region "清空控件"
    Private Sub ClearControl()
        Dim ClearCon As Control

        For Each ClearCon In Me.Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Text = ""
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Text = ""
            End If
        Next
        Me.CobCust.SelectedIndex = -1
        Me.CobSerial.SelectedIndex = -1
    End Sub
#End Region

#Region "改变记录"

    Private Sub ChgRecord(ByVal Flag As Integer)

        Dim EmsCon As Control
        Select Case Flag

            Case 0
                Me.DgPartContrast.Enabled = True
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = True
                    End If
                Next
                DgPartContrast.Enabled = False
                Me.TxtTavcPart.Enabled = False
            Case 1
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = False
                    End If
                Next
                DgPartContrast.Enabled = True
        End Select
    End Sub

#End Region

#Region "返回"
    Private Sub CancelChg()
        TabControl1.Enabled = True
        ChgRecord(1)
        SetControlStates()
    End Sub
#End Region

#Region "增加记录"

    Private Sub AddRecord()

        Me.CobCust.SelectedIndex = -1
        ChgRecord(0)
        SetControlStates()
        ClearControl()

    End Sub

#End Region

#Region "编辑记录"

    Private Sub EditRecord()
        ChgRecord(0)
        SetControlStates()
    End Sub

#End Region

#Region "删除记录"

    Private Sub DeleteRecord()
        If DgPartContrast.RowCount < 1 Then Exit Sub
        If Me.DgPartContrast.CurrentRow.Index = -1 Then Exit Sub
        Dim SqlString As String = String.Empty

        If MessageUtils.ShowConfirm("你确定要删除该料号吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            Try
                If TabControl1.SelectedIndex = 0 Then
                    SqlString = "delete from m_PartContrast_t where TAvcPart='" & Me.DgPartContrast.CurrentRow.Cells(0).Value & "' and PAvcPart='" & Me.DgPartContrast.CurrentRow.Cells(1).Value & "'"
                ElseIf TabControl1.SelectedIndex = 1 Then
                    SqlString = "delete from m_PartContrast_t where TAvcPart='" & Me.DgPartContrast2.CurrentRow.Cells(0).Value & "' and PAvcPart='" & Me.DgPartContrast2.CurrentRow.Cells(1).Value & "'"
                End If
                DbOperateUtils.ExecSQL(SqlString)
                SearchRecord("")
            Catch ex As Exception
                MessageUtils.ShowError(ex.Message & vbNewLine & "料件删除时，发生错误!")
            End Try
        End If
        SetValueToControl()
    End Sub
#End Region

#Region "ERP下载"

    Private Sub ErpDownLoad()

        Me.CobCust.SelectedIndex = -1
        'ChgRecord(0)
        TxtTavcPart.Enabled = True
        SetControlStates()
        ClearControl()

    End Sub

    Private Function ErpDownLoadData() As Boolean
        Dim o_strCustID As String = ""
        Dim o_strSerial As String = ""
        ErpDownLoadData = True

        Try
            If TxtTavcPart.Text.Trim = String.Empty Then
                lblMsg.Text = "请输入料件编号..."
                TxtTavcPart.Focus()
                Exit Function
            End If

            If rdoPN.Checked = True Then
                If Me.CobCust.SelectedItem = "" Then
                    If VbCommClass.VbCommClass.IsConSap = "Y" Then
                        Dim dtPart As DataTable = CommClass.GetPartCusIdSeriIDDt(TxtTavcPart.Text)
                        If dtPart.Rows.Count = 0 Then
                            lblMsg.Text = "请找PQE在SPC中【物料客户别/系列别】维护或手动选择客户名称..."
                            Exit Function
                        End If
                        o_strCustID = dtPart.Rows(0)("CusID").ToString
                        o_strSerial = dtPart.Rows(0)("SeriesID").ToString
                        Me.CobCust.SelectedIndex = Me.CobCust.FindString(o_strCustID)
                        Me.CobSerial.SelectedIndex = Me.CobSerial.FindString(o_strSerial)
                    Else
                        o_strCustID = SapCommon.GetCustIDFormTT(TxtTavcPart.Text)
                        If String.IsNullOrEmpty(o_strCustID) Then
                            lblMsg.Text = "请先在ERP维护客户名称或者手动选择客户名称..."
                            CobCust.Focus()
                            ErpDownLoadData = False
                            Exit Function
                        Else
                            Me.CobCust.SelectedIndex = Me.CobCust.FindString(o_strCustID)
                        End If
                    End If
                End If

                If Me.CobSerial.SelectedItem = "" Then
                    If VbCommClass.VbCommClass.IsConSap = "Y" Then
                        lblMsg.Text = "请找PQE在SPC中【物料客户别/系列别】维护或手动选择系列别..."
                        Exit Function
                    Else
                        o_strSerial = SapCommon.GetSerialFormTT(TxtTavcPart.Text)
                        If String.IsNullOrEmpty(o_strSerial) Then
                            lblMsg.Text = "请先在ERP维护系列别或者手动选择系列别..."
                            CobSerial.Focus()
                            ErpDownLoadData = False
                            Exit Function
                        Else
                            Me.CobSerial.SelectedIndex = Me.CobSerial.FindString(o_strSerial)
                        End If
                    End If
                End If
            End If


            Dim strSQL As String
            Dim dt As DataTable = New DataTable
            Dim dt1 As DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("ParentPartId")
            dt.Columns.Add("ChildPartId")
            dt.Columns.Add("ParentFormat")
            dt.Columns.Add("ChildFormat")
            dt.Columns.Add("ParentDescription")
            dt.Columns.Add("ChildDescription")
            dt.Columns.Add("Version")
            dt.Columns.Add("EffectiveDate")
            dt.Columns.Add("ExpirationDate")
            dt.Columns.Add("Qty")
            dt.Columns.Add("Extensible")
            '连接到SAP
            '优化子工单循环下载
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                strSQL = CommClass.GetErpFilterSqlSap(TxtTavcPart.Text, "2")
                dt1 = OracleOperateUtils.GetDataTableSap(strSQL)
                Dim index As Int32
                Dim MATNR As String
                Dim dt2 As DataTable
                For index = 0 To dt1.Rows.Count - 1
                    Dim i As Int32
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1)(0) = dt.Rows.Count
                    dt.Rows(dt.Rows.Count - 1)(1) = dt1.Rows(index)(1)
                    dt.Rows(dt.Rows.Count - 1)(2) = dt1.Rows(index)(2)
                    dt.Rows(dt.Rows.Count - 1)(3) = dt1.Rows(index)(3)
                    dt.Rows(dt.Rows.Count - 1)(4) = dt1.Rows(index)(4)
                    dt.Rows(dt.Rows.Count - 1)(5) = dt1.Rows(index)(5)
                    dt.Rows(dt.Rows.Count - 1)(6) = dt1.Rows(index)(6)
                    dt.Rows(dt.Rows.Count - 1)(7) = dt1.Rows(index)(7)
                    dt.Rows(dt.Rows.Count - 1)(8) = dt1.Rows(index)(8)
                    dt.Rows(dt.Rows.Count - 1)(9) = dt1.Rows(index)(9)
                    dt.Rows(dt.Rows.Count - 1)(10) = dt1.Rows(index)(10)
                    dt.Rows(dt.Rows.Count - 1)(11) = dt1.Rows(index)(11)
                    If dt1.Rows(index)(11) = "Y" Then
                        MATNR = dt1.Rows(index)(2).ToString()
                        strSQL = CommClass.GetErpFilterSqlSap(MATNR, "2")
                        dt2 = OracleOperateUtils.GetDataTableSap(strSQL)
                        For i = 0 To dt2.Rows.Count - 1
                            dt.Rows.Add()
                            dt.Rows(dt.Rows.Count - 1)(0) = dt.Rows.Count
                            dt.Rows(dt.Rows.Count - 1)(1) = dt2.Rows(i)(1)
                            dt.Rows(dt.Rows.Count - 1)(2) = dt2.Rows(i)(2)
                            dt.Rows(dt.Rows.Count - 1)(3) = dt2.Rows(i)(3)
                            dt.Rows(dt.Rows.Count - 1)(4) = dt2.Rows(i)(4)
                            dt.Rows(dt.Rows.Count - 1)(5) = dt2.Rows(i)(5)
                            dt.Rows(dt.Rows.Count - 1)(6) = dt2.Rows(i)(6)
                            dt.Rows(dt.Rows.Count - 1)(7) = dt2.Rows(i)(7)
                            dt.Rows(dt.Rows.Count - 1)(8) = dt2.Rows(i)(8)
                            dt.Rows(dt.Rows.Count - 1)(9) = dt2.Rows(i)(9)
                            dt.Rows(dt.Rows.Count - 1)(10) = dt2.Rows(i)(10)
                            dt.Rows(dt.Rows.Count - 1)(11) = dt2.Rows(i)(11)
                        Next
                    End If
                Next
                'bom表中没有数据再到物料表中查找
                If dt.Rows.Count = 0 Then
                    strSQL = CommClass.GetErpFilterSqlSap(TxtTavcPart.Text, "3")
                    dt = OracleOperateUtils.GetDataTableSap(strSQL)
                End If
            Else
                strSQL = SapCommon.GetErpFilterSql(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TxtTavcPart.Text)
                dt = OracleOperateUtils.GetDataTable(strSQL)
            End If

            If dt.Rows.Count = 0 Then
                lblMsg.Text = "ERP中找不到该料件的信息..."
                'MessageUtils.ShowError("ERP中找不到该料件的信息...")
                Save.Enabled = False
                Exit Function
            Else

                If rdoPN.Checked = True Then
                    dt.Columns.Add("CustID", GetType(String))
                    For Each dr As DataRow In dt.Rows()
                        dr.Item("CustID") = Me.CobCust.SelectedItem.ToString.Split("(")(0)
                    Next

                    dt.Columns.Add("SerialID", GetType(String))
                    For Each dr As DataRow In dt.Rows()
                        dr.Item("SerialID") = Me.CobSerial.SelectedItem.ToString.Split("(")(0)
                    Next
                End If

                dgvBomInfo.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
                lblMsg.Text = "该料件在ERP中的数据如下表所示..."
                Save.Enabled = True
                SetDataGridViewStyle()

            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageUtils.ShowError(ex.Message)
        End Try
    End Function


    Private Function GetPartSeriesTypeCode(ByVal parTypeName As String) As String
        Dim lsSQL As String = ""
        GetPartSeriesTypeCode = ""
        Try
            lsSQL = " SELECT PartSeriesTypeCode  FROM m_PartSeriesType_t " & _
                    " WHERE PartSeriesTypeName='" & parTypeName & "'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetPartSeriesTypeCode = dt.Rows(0).Item(0)
            Else
                GetPartSeriesTypeCode = ""
            End If
            Return GetPartSeriesTypeCode
        Catch ex As Exception
        End Try
    End Function

#End Region

#Region "查找GridComBox"
    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            ' If CobName.Name <> "CobSerial" Then
            CobName.Items.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
            '  Else
            ' CobName.Items.Add(ScanReader(1).ToString & "-" & ScanReader(0).ToString)
            ' End If
        Loop
        ScanReader.Close()
        CobName.SelectedIndex = -1
    End Sub

    Private Sub FillCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        CobName.Items.Add("ALL")
        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader.GetString(0).ToString)
        Loop
        ScanReader.Close()
        CobName.SelectedIndex = 0
    End Sub

#End Region

#Region "搜索记录"

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Try

            Dim cmbTmp As DataGridViewComboBoxColumn
            cmbTmp = DgPartContrast.Columns(2)
            cmbTmp.DisplayMember = "PartSeriesTypeName"
            cmbTmp.ValueMember = "PartSeriesTypeCode"
            cmbTmp.DataSource = DbOperateUtils.GetDataTable("SELECT PartSeriesTypeCode, PartSeriesTypeName FROM m_PartSeriesType_t WHERE Usey = 'Y' UNION SELECT '' AS PartSeriesTypeCode, '' AS PartSeriesTypeName ORDER BY PartSeriesTypeCode ")

            If Sqlstring = "" Then
                dt = PartContrastBusiness.GetPartContrastList("and isnull(a.Type,'R') = 'R'")
                dt2 = PartContrastBusiness.GetPartContrastList("and isnull(a.Type,'R')= 'E'")
                DgPartContrast.DataSource = dt
                DgPartContrast2.DataSource = dt2
            Else
                If Me.rdoPN.Checked Then
                    dt = PartContrastBusiness.GetPartContrastList(Sqlstring)
                    DgPartContrast.DataSource = dt
                Else
                    dt2 = PartContrastBusiness.GetPartContrastList(Sqlstring)
                    DgPartContrast2.DataSource = dt2
                End If
            End If
            'cq 20170428
            Dim ChColsText As String = "料件编号|父料件编号|料件类别|子健类别|客户名称|客户料号|系列别|状态|维护人员|维护时间|保质期|预警周期|料件描述|" & _
                                       "料件代号|供应商代码|传Panda成品|传Panda组件|需扫描批次|需转移预警|规格|类别|料件类别名称|微软客户来料"

            Dim colNames As String() = ChColsText.Split("|")
            If dt IsNot Nothing Then

                For i As Integer = 0 To DgPartContrast.Columns.Count - 1
                    DgPartContrast.Columns(i).HeaderText = colNames(i)
                    DgPartContrast.Columns(i).Name = colNames(i)
                Next
                ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
            End If
            If dt2 IsNot Nothing Then
                For i As Integer = 0 To DgPartContrast2.Columns.Count - 1
                    DgPartContrast2.Columns(i).HeaderText = colNames(i)
                    DgPartContrast2.Columns(i).Name = colNames(i)
                Next
                ToolStripStatusLabel1.Text = dt2.Rows.Count & "笔"
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartConstrast", "SearchRecord", "BasicM")
        End Try
    End Sub

    Private Sub SetDataGridViewStyle()
        dgvBomInfo.Columns(BomInfo.ID.ToString).HeaderText = "序号"
        dgvBomInfo.Columns(BomInfo.ID.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.ParentPartId.ToString).HeaderText = "父料件编号"
        dgvBomInfo.Columns(BomInfo.ChildPartId.ToString).HeaderText = "子料件编号"
        dgvBomInfo.Columns(BomInfo.ParentFormat.ToString).HeaderText = "父规格"
        dgvBomInfo.Columns(BomInfo.ParentFormat.ToString).Visible = False
        dgvBomInfo.Columns(BomInfo.ChildFormat.ToString).HeaderText = "规格"
        dgvBomInfo.Columns(BomInfo.ChildFormat.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.ParentDescription.ToString).HeaderText = "父描述"
        dgvBomInfo.Columns(BomInfo.ParentDescription.ToString).Visible = False
        dgvBomInfo.Columns(BomInfo.ChildDescription.ToString).HeaderText = "描述"
        dgvBomInfo.Columns(BomInfo.ChildDescription.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.EffectiveDate.ToString).HeaderText = "有效开始日期"
        dgvBomInfo.Columns(BomInfo.EffectiveDate.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.ExpirationDate.ToString).HeaderText = "失效日期"
        dgvBomInfo.Columns(BomInfo.ExpirationDate.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.Extensible.ToString).HeaderText = "可展开否"
        dgvBomInfo.Columns(BomInfo.Extensible.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.Qty.ToString).HeaderText = "数量"
        dgvBomInfo.Columns(BomInfo.Qty.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.Version.ToString).Visible = False
        'dgvBomInfo.Columns(BomInfo.CustID.ToString).HeaderText = "客户名称"
        'dgvBomInfo.Columns(BomInfo.SerialID.ToString).HeaderText = "系列别"
    End Sub
#End Region

#Region "保存数据"

    Private Sub SaveData()
        Dim StrCust As String = String.Empty, StrSeriesID As String = ""
        Dim StryType As String = String.Empty
        Dim StrCode As String = String.Empty
        Dim StrSupplier As String = String.Empty
        Try

            If buttonStatus <> EnumStatus.DownLoad Then
                CheckRecord()
                If Me.CobCust.Text = "" Then
                    StrCust = ""
                Else
                    StrCust = Mid(Trim(Me.CobCust.Text), 1, InStr(Trim(Me.CobCust.Text), "(") - 1)
                End If

                If String.IsNullOrEmpty(StrCust) Then
                    If Me.rdoPN.Checked = True Then
                        MessageUtils.ShowError("客户名称不能为空,请检查!")
                        Exit Sub
                    End If
                End If

                If Me.CobSerial.Text = "" Then
                    StrSeriesID = ""
                Else
                    StrSeriesID = Me.CobSerial.SelectedItem.ToString.Split("(")(0)
                End If

                StryType = CobPartDes.Text
                StrCode = CobPartCode.Text
                StrSupplier = CobSupplyCode.Text
            End If

            Dim IsupLoad As String = IIf(ChKisUpload.Checked, "Y", "N")
            Dim IsAssemble As String = IIf(ChkAssemble.Checked, "Y", "N")
            Dim IsLotScan As String = IIf(ChkIsLot.Checked, "Y", "N")
            Dim IsAlter As String = IIf(ChkAlter.Checked, "Y", "N")
            Dim MaterialAlter As String = IIf(Chkcheck.Checked, "Y", "N")
            Dim IsTranData As String = IIf(ChkTransData.Checked, "Y", "N")
            Dim type As String = IIf(rdoPN.Checked, "R", "E")
            Dim mscusttype As String = IIf(chkMSCust.Checked, "Y", "N")
            Dim strPartSeriesType As String
            If Me.CobPartSeriesType.Text = "" Then
                strPartSeriesType = ""
            Else
                If InStr(Trim(Me.CobPartSeriesType.Text), "(") > 0 Then
                    strPartSeriesType = Mid(Trim(Me.CobPartSeriesType.Text), 1, InStr(Trim(Me.CobPartSeriesType.Text), "(") - 1)
                Else
                    'cq 20170223
                    strPartSeriesType = GetPartSeriesTypeCode(Me.CobPartSeriesType.Text)
                End If
            End If
            Dim strPlanType As String = IIf(Me.chkPlanType.Checked, "Y", "N")

            If buttonStatus = EnumStatus.NewAdd Then
                Dim dt As DataTable = PartContrastBusiness.GetPartContrast(Trim(Me.TxtTavcPart.Text), Trim(Me.TxtPavcPart.Text))
                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowInformation("系统中已存在该料号！")
                    Exit Sub
                End If
                '料件资料BOM的时总是相同
                If TabControl1.SelectedIndex = 1 Then
                    TxtPavcPart.Text = TxtTavcPart.Text.Trim
                End If

                Dim arrayList As New ArrayList
                arrayList.Add("TAvcPart|" & Me.TxtTavcPart.Text)
                arrayList.Add("PartName|")
                arrayList.Add("PAvcPart|" & Me.TxtPavcPart.Text)
                arrayList.Add("CusID|" & StrCust)
                arrayList.Add("SeriesID|" & StrSeriesID)
                arrayList.Add("CustPart|" & Trim(Me.TxtCustPartID.Text))
                arrayList.Add("MethodID|")
                arrayList.Add("LmtY|" & Me.UpLmt.Value)
                arrayList.Add("WarnDate|" & Me.UpYttishi.Value)
                arrayList.Add("Userid|" & SysMessageClass.UseId)
                arrayList.Add("TypeDest|" & TransferDBSpecChar(Me.CobPartDes.Text))
                arrayList.Add("PartCode|" & StrCode)
                arrayList.Add("Supplierid|" & StrSupplier)
                arrayList.Add("IsUpload|" & IsupLoad)
                arrayList.Add("Isasseble|" & IsAssemble)
                arrayList.Add("IsLotScan|" & IsLotScan)
                arrayList.Add("IsAlter|" & IsAlter)
                arrayList.Add("MaterialAlter|" & MaterialAlter)
                arrayList.Add("IsPrintFile|")
                arrayList.Add("IsTransOracle|")
                arrayList.Add("IsChkTransData|" & IsTranData)
                arrayList.Add("AmountQty|")
                arrayList.Add("DESCRIPTION|" & TransferDBSpecChar(txtDescription.Text.Trim))
                arrayList.Add("SubstituteFlag|")
                arrayList.Add("IngredientsPart|")
                arrayList.Add("SubstituteNumber|0")
                arrayList.Add("Extensible|")
                arrayList.Add("EffectiveDate|")
                arrayList.Add("ExpirationDate|")
                arrayList.Add("VERSION|")
                arrayList.Add("TYPE|" & type)
                arrayList.Add("MARK|")
                arrayList.Add("EcnChange|")
                arrayList.Add("PartSeriesType|" & strPartSeriesType)
                arrayList.Add("PlanType|" & strPlanType)
                arrayList.Add("MSCustType|" & mscusttype)
                arrayList.Add("Factory|" & VbCommClass.VbCommClass.Factory) 'ADD 20190710
                PartContrastBusiness.InsertTable(arrayList)

                MessageUtils.ShowInformation("资料保存成功")
            ElseIf buttonStatus = EnumStatus.Edit Then

                Dim arrayList As New ArrayList

                arrayList.Add("TAvcPart|" & StrOldPart)
                arrayList.Add("PartName|")
                arrayList.Add("PAvcPartKey|" & StrOldPartp)
                arrayList.Add("PAvcPart|" & Trim(Me.TxtPavcPart.Text))
                arrayList.Add("CusID|" & StrCust)
                arrayList.Add("SeriesID|" & StrSeriesID)
                arrayList.Add("CustPart|" & Trim(Me.TxtCustPartID.Text))
                arrayList.Add("MethodID|")
                arrayList.Add("LmtY|" & Me.UpLmt.Value)
                arrayList.Add("WarnDate|" & Me.UpYttishi.Value)
                arrayList.Add("Userid|" & SysMessageClass.UseId)
                arrayList.Add("TypeDest|" & TransferDBSpecChar(Me.CobPartDes.Text))
                arrayList.Add("PartCode|" & StrCode)
                arrayList.Add("Supplierid|" & StrSupplier)
                arrayList.Add("IsUpload|" & IsupLoad)
                arrayList.Add("Isasseble|" & IsAssemble)
                arrayList.Add("IsLotScan|" & IsLotScan)
                arrayList.Add("IsAlter|" & IsAlter)
                arrayList.Add("MaterialAlter|" & MaterialAlter)
                arrayList.Add("IsPrintFile|")
                arrayList.Add("IsTransOracle|")
                arrayList.Add("IsChkTransData|" & IsTranData)
                arrayList.Add("AmountQty|")
                arrayList.Add("DESCRIPTION|" & TransferDBSpecChar(txtDescription.Text.Trim))
                arrayList.Add("SubstituteFlag|")
                arrayList.Add("IngredientsPart|")
                arrayList.Add("SubstituteNumber|0")
                arrayList.Add("Extensible|")
                arrayList.Add("EffectiveDate|")
                arrayList.Add("ExpirationDate|")
                arrayList.Add("VERSION|")
                arrayList.Add("TYPE|" & type)
                arrayList.Add("MARK|")
                arrayList.Add("EcnChange|")
                arrayList.Add("PartSeriesType|" & strPartSeriesType)
                arrayList.Add("PlanType|" & strPlanType)
                arrayList.Add("MSCustType|" & mscusttype)
                arrayList.Add("Factory|" & VbCommClass.VbCommClass.Factory) 'ADD 20190710
                PartContrastBusiness.UpdateTable(arrayList)

                MessageUtils.ShowInformation("资料保存成功")
            ElseIf buttonStatus = EnumStatus.DownLoad Then

                Dim dt As DataTable = PartContrastBusiness.GetPartContrast(Trim(Me.TxtTavcPart.Text), Trim(Me.TxtTavcPart.Text))

                If dt.Rows.Count > 0 Then
                    If MessageUtils.ShowConfirm("已经存在该料件信息，确认是否需要重新下载;如需要,请检查该料号下面子件的版本信息！！！", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                        Exit Sub
                    End If
                End If

                SaveErpData()
                MessageUtils.ShowInformation("资料保存成功!")
                lblMsg.Text = "提示信息"
            End If

            buttonStatus = EnumStatus.UnDo
            CancelChg()
            SearchRecord("")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message & vbCrLf & "错误")
            SysMessageClass.WriteErrLog(ex, "FrmPartConstrast", "SaveData_Click", "WIP")
        End Try
    End Sub

    '保存ERP下载数据
    Private Sub SaveErpData()

        Dim tavcPart As String = String.Empty
        Dim pavcPart As String = String.Empty
        Dim Version As String = String.Empty
        Dim ParentFormat As String = String.Empty
        Dim ChildFormat As String = String.Empty
        Dim ParentDes As String = String.Empty
        Dim ChildDes As String = String.Empty
        Dim EffectiveDate As String = String.Empty
        Dim ExpirationDate As Object = String.Empty
        Dim EXTENSIABLE As String = String.Empty
        Dim Qty As String = String.Empty
        Dim strCustID As String = "", strSerialID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim strInsertSQL As String = ""
        Dim Factory As String = VbCommClass.VbCommClass.Factory

        'Add check by cq 20151122
        If dgvBomInfo.Rows.Count <= 0 Then
            Exit Sub
        End If

        'Add by cq 20160606
        'insertSql.Append("DELETE FROM m_PartContrast_t WHERE PAVCPART ='" & dgvBomInfo.Rows(0).Cells(BomInfo.ParentPartId.ToString).Value.ToString & "' ")
        pavcPart = dgvBomInfo.Rows(0).Cells(BomInfo.ParentPartId.ToString).Value.ToString
        insertSql.Append("DELETE FROM m_PartContrast_t WHERE ")
        insertSql.AppendFormat(" PAVCPART  = '{0}' AND isnull([TYPE],'R')='R' " & BMComDB.GetPartFatoryNoBlank, pavcPart)

        'strInsertSQL =
        '    "INSERT INTO dbo.m_PartContrast_t " &
        '        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
        '         "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE, CusID, SeriesID)"
        Dim strUpdateSQL As String =
                " UPDATE dbo.m_PartContrast_t "

        '子料号
        For iCnt As Integer = 0 To dgvBomInfo.Rows.Count - 1
            tavcPart = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ChildPartId.ToString).Value.ToString
            pavcPart = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ParentPartId.ToString).Value.ToString
            Version = dgvBomInfo.Rows(iCnt).Cells(BomInfo.Version.ToString).Value.ToString
            ParentFormat = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ParentFormat.ToString).Value.ToString
            ChildFormat = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ChildFormat.ToString).Value.ToString
            ParentDes = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ParentDescription.ToString).Value.ToString
            ChildDes = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ChildDescription.ToString).Value.ToString
            EffectiveDate = dgvBomInfo.Rows(iCnt).Cells(BomInfo.EffectiveDate.ToString).Value.ToString
            If IsDBNull(dgvBomInfo.Rows(iCnt).Cells(BomInfo.ExpirationDate.ToString).Value) Then
                ExpirationDate = DBNull.Value
                strInsertSQL =
                  "INSERT INTO dbo.m_PartContrast_t " &
                  "(TAvcPart ,PAvcPart , Factory, UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                  "Extensible ,EffectiveDate ,VERSION ,TYPE, CusID, SeriesID)"
            Else
                ExpirationDate = dgvBomInfo.Rows(iCnt).Cells(BomInfo.ExpirationDate.ToString).Value.ToString
                strInsertSQL =
               "INSERT INTO dbo.m_PartContrast_t " &
               "(TAvcPart ,PAvcPart , Factory, UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
               "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE, CusID, SeriesID)"
            End If
            EXTENSIABLE = dgvBomInfo.Rows(iCnt).Cells(BomInfo.Extensible.ToString).Value.ToString
            Qty = dgvBomInfo.Rows(iCnt).Cells(BomInfo.Qty.ToString).Value.ToString

            strCustID = dgvBomInfo.Rows(iCnt).Cells(BomInfo.CustID.ToString).Value.ToString
            strSerialID = dgvBomInfo.Rows(iCnt).Cells(BomInfo.SerialID.ToString).Value.ToString

            '料件修改 20151108 Daniel
            If (pavcPartList.Contains(pavcPart)) = False Then
                pavcPartList.Add(pavcPart)
                '父料号
                insertSql.AppendFormat("IF EXISTS (select 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' " & BMComDB.GetPartFatoryNoBlank & ")",
                                       pavcPart, pavcPart, Factory)
                insertSql.Append(strUpdateSQL)
                insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
                insertSql.AppendFormat(" Userid = N'{0}',", SysMessageClass.UseId)
                insertSql.AppendFormat(" Intime = getdate(),")
                insertSql.AppendFormat(" TypeDest = N'{0}',", TransferDBSpecChar(ParentDes)) 'ChildDes
                insertSql.AppendFormat(" DESCRIPTION = N'{0}' ", TransferDBSpecChar(ParentFormat)) 'ChildFormat
                insertSql.AppendFormat(" WHERE TAvcPart ='{0}'", pavcPart)
                insertSql.AppendFormat(" AND PAvcPart = '{0}'", pavcPart)
                insertSql.AppendFormat(" AND Factory = '{0}'", Factory)
                insertSql.Append(" ELSE ")
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'{0}',", Factory) 'add 20190710
                insertSql.AppendFormat("N'Y',")
                insertSql.AppendFormat("N'{0}',", SysMessageClass.UseId)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentDes))
                insertSql.AppendFormat("N'{0}',", 1)  'cq 20160510  --田玉琳 20180305，父料号=子料号 数量为1 
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentFormat))
                insertSql.AppendFormat("'{0}',", "Y")
                insertSql.AppendFormat("{0},", "NULL")
                If Not IsDBNull(ExpirationDate) Then
                    insertSql.AppendFormat("{0},", "NULL")
                End If
                insertSql.AppendFormat("N'{0}',", "")
                insertSql.AppendFormat("N'{0}',", "R")
                insertSql.AppendFormat("N'{0}',", strCustID)
                insertSql.AppendFormat("N'{0}'", strSerialID) 'Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE, CusID, SeriesID
                insertSql.Append(");")
            End If
            insertSql.AppendFormat("IF EXISTS (select 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' " & BMComDB.GetPartFatoryNoBlank & ")",
                                     tavcPart, pavcPart, Factory)
            insertSql.Append(strUpdateSQL)
            insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
            insertSql.AppendFormat("UseY = 'Y',")
            insertSql.AppendFormat("Userid = N'{0}',", SysMessageClass.UseId)
            insertSql.AppendFormat("Intime = getdate(),")
            insertSql.AppendFormat("TypeDest = N'{0}',", TransferDBSpecChar(ChildDes))
            insertSql.AppendFormat("AmountQty = '{0}',", Qty)
            insertSql.AppendFormat("DESCRIPTION = N'{0}',", TransferDBSpecChar(ChildFormat))
            insertSql.AppendFormat("Extensible = N'{0}',", EXTENSIABLE)
            insertSql.AppendFormat("EffectiveDate = N'{0}',", EffectiveDate)
            If IsDBNull(ExpirationDate) Then
                insertSql.AppendFormat("ExpirationDate = NULL,")
            Else
                insertSql.AppendFormat("ExpirationDate = '{0}',", ExpirationDate)
            End If
            insertSql.AppendFormat("VERSION = N'{0}',", Version)
            insertSql.AppendFormat("CusID = N'{0}',", strCustID)
            insertSql.AppendFormat("SeriesID = N'{0}',", strSerialID)
            insertSql.AppendFormat("TYPE = N'{0}'", "R")
            insertSql.AppendFormat("WHERE TAvcPart ='{0}'", tavcPart)
            insertSql.AppendFormat("AND PAvcPart = '{0}'", pavcPart)
            insertSql.AppendFormat("AND Factory = '{0}'", Factory)
            insertSql.Append(" else ")
            insertSql.Append(strInsertSQL)
            insertSql.Append(" VALUES(")
            insertSql.AppendFormat("N'{0}',", tavcPart)
            insertSql.AppendFormat("N'{0}',", pavcPart)
            insertSql.AppendFormat("N'{0}',", Factory) 'add 20190710
            insertSql.AppendFormat("N'Y',")
            insertSql.AppendFormat("N'{0}',", SysMessageClass.UseId)
            insertSql.AppendFormat("getdate(),")
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
            insertSql.AppendFormat("N'{0}',", Qty) 'cq 20160510
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
            insertSql.AppendFormat("N'{0}',", EXTENSIABLE) 'cq 20160618  "N" ==> EXTENSIABLE
            insertSql.AppendFormat("N'{0}',", EffectiveDate)
            If Not IsDBNull(ExpirationDate) Then
                insertSql.AppendFormat("'{0}',", ExpirationDate)
            End If
            insertSql.AppendFormat("N'{0}',", Version)
            insertSql.AppendFormat("N'{0}',", "R")
            insertSql.AppendFormat("N'{0}',", strCustID)
            insertSql.AppendFormat("N'{0}'", strSerialID) ' 'Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE, CusID, SeriesID
            insertSql.Append(");")

        Next
        '保存数据，有事务处理
        DbOperateUtils.ExecSQL(insertSql.ToString)
    End Sub

    Private Function TransferDBSpecChar(target As String) As String
        TransferDBSpecChar = target.Replace("'", "''")
    End Function

#End Region

#Region "检查记录"
    Private Sub CheckRecord()

        Dim TavcPartErr As New Exception("料件编号不能为空!")
        TavcPartErr.Source = "CheckRecord"
        If Me.TxtTavcPart.Text = "" Then
            TxtTavcPart.Focus()
            Throw TavcPartErr
        End If

        If TabControl1.SelectedIndex = 0 Then

            Dim PavcPartErr As New Exception("父料件编号不能为空")
            PavcPartErr.Source = "CheckRecord"
            If Me.TxtPavcPart.Text = "" Then
                TxtPavcPart.Focus()
                Throw PavcPartErr
            End If

            If Me.rdoPN.Checked = True Then 'Add by cq 20160118
                Dim CustPartErr As New Exception("客户料号不能为空")
                CustPartErr.Source = "CheckRecord"
                If Me.TxtCustPartID.Text = "" Then
                    TxtCustPartID.Focus()
                    Throw New Exception("客户料号不能为空")
                End If

                Dim CustNameErr As New Exception("客户名称不能为空")
                CustNameErr.Source = "CheckRecord"
                If Me.CobCust.Text = "" Then
                    CobCust.Focus()
                    Throw New Exception("客户名称不能为空")
                End If

                Dim SerialErr As New Exception("系列别不能为空")
                SerialErr.Source = "CheckRecord"
                If Me.CobSerial.Text = "" Then
                    CobSerial.Focus()
                    Throw New Exception("系列别不能为空")
                Else
                    If IsNothing(Me.CobSerial.SelectedItem) Then
                        CobSerial.Focus()
                        Throw New Exception("需要选择系列别！")
                    End If
                End If
            End If
        End If

    End Sub
#End Region

#Region "汇入汇出操作"
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
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
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 4, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" TAvcPart IS NOT NULL ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("PAvcPart", "System.String", dtUploadData)
            TableAddColumns("TYPE", "System.String", dtUploadData)
            TableAddColumns("UseY", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New Dictionary(Of String, String)
            dics2.Add("TAvcPart", "TAvcPart")
            dics2.Add("TypeDest", "TypeDest")
            dics2.Add("DESCRIPTION", "DESCRIPTION")
            dics2.Add("Userid", "Userid")
            dics2.Add("PAvcPart", "PAvcPart")
            dics2.Add("TYPE", "TYPE")
            dics2.Add("UseY", "UseY")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(0).ToString(), "E", "Y")
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_PartContrast_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    SearchRecord("")
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartContrast.toolImport_Click", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub


    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB中设备料号
        Dim strSQL As String = " select TAvcPart from m_PartContrast_t where type = 'E' and TAvcPart = PAvcPart " & BMComDB.GetPartFatory
        Dim dtPN As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim strSQL2 As String = " select (CODE +'('+NAME+')') CODE,NAME from m_EquipmentCategory_t where Status=1 AND TYPE = 'MID' "
        Dim dtPNDes As DataTable = DbOperateUtils.GetDataTable(strSQL2)

        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1
            Dim returnCode As String = ""
            Dim PartNumber As String = DrrR(index)(CDImportGrid.TAvcPart.ToString).ToString.Trim
            Dim PartNumberDes As String = DrrR(index)(CDImportGrid.TypeDest.ToString).ToString.Trim
            Dim values As String = PartNumber
            If hastable.Contains(values) Then
                MessageUtils.ShowError(String.Format("上传文件中有重复的设备治具料号{0}", PartNumber))
                Return False
            Else
                hastable.Add(values, values)
            End If

            If PartNumberDes <> "" Then
                If CheckExistUserColumns(dtPNDes, "NAME", PartNumberDes, returnCode) = False Then
                    MessageUtils.ShowError(String.Format("料件描述{0}不在资料表", PartNumberDes))
                    Return False
                Else
                    DrrR(index)(CDImportGrid.TypeDest.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("料件描述有空值,请检查后重新上传。")
                Return False
            End If

            If PartNumber <> "" Then
                If CheckExistUserColumns(dtPN, "TAvcPart", PartNumber, "") = True Then
                    MessageUtils.ShowError("料件表中料件编号有重复数据：'" + PartNumber + "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("料件表中料件编号有空值,请检查后重新上传。")
                Return False
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

    Private Sub toolImportType_Click(sender As Object, e As EventArgs) Handles toolImportType.Click
        Try
            Dim strFilePath As String
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "Execl文件|*.xls;*.xlsx"
            openFileDialog.Multiselect = False
            openFileDialog.Title = "选择计划导入Execl文件"
            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                strFilePath = openFileDialog.FileName
                Dim strMsg As String = ""
                If (Not String.IsNullOrEmpty(strFilePath)) Then

                    Dim dtLoadData As DataTable = ExcelUtils.ExportFromExcelByAs(strFilePath, 1, 0, 5, strMsg)
                    If (Not String.IsNullOrEmpty(strMsg)) Then
                        MessageUtils.ShowInformation(strMsg)
                        Exit Sub
                    End If

                    If (Not dtLoadData Is Nothing And dtLoadData.Rows.Count > 0) Then
                        Dim strSQL As StringBuilder = New StringBuilder
                        Dim strPartId As String
                        Dim strPartSeriesType As String
                        Dim strPlanType As String

                        strSQL.AppendLine(" DECLARE @PartSeriesTypeCode VARCHAR(32) ")

                        For i As Int16 = 0 To dtLoadData.Rows.Count - 1
                            strPartId = dtLoadData.Rows(i).Item(0).ToString.Trim
                            strPartSeriesType = dtLoadData.Rows(i).Item(3).ToString.Trim
                            strPlanType = IIf(dtLoadData.Rows(i).Item(4).ToString.Trim = "Y", "Y", "N")

                            If (String.IsNullOrEmpty(strPartId)) Then
                                Exit For
                            End If

                            strSQL.AppendLine(" IF EXISTS(SELECT 1 FROM m_PartContrast_t WHERE TAvcPart=PAvcPart AND TAvcPart = '" & strPartId &
                                              "' " & BMComDB.GetPartFatory & ")")
                            strSQL.AppendLine(" BEGIN IF EXISTS(SELECT 1 FROM m_PartSeriesType_t WHERE PartSeriesTypeName = N'" & strPartSeriesType & "')")
                            strSQL.AppendLine(" BEGIN SELECT TOP 1 @PartSeriesTypeCode = PartSeriesTypeCode FROM m_PartSeriesType_t WHERE PartSeriesTypeName = N'" & strPartSeriesType & "' UPDATE m_PartContrast_t SET PartSeriesType=@PartSeriesTypeCode, PlanType = '" & strPlanType & "' WHERE TAvcPart=PAvcPart AND TAvcPart = '" & strPartId & "'")
                            strSQL.AppendLine(" End  End Else BEGIN")
                            strSQL.AppendLine(" UPDATE m_PartContrast_t SET PlanType = '" & strPlanType & "' WHERE TAvcPart=PAvcPart AND TAvcPart = '" & strPartId &
                                              "' " & BMComDB.GetPartFatory & " End")
                        Next

                        DbOperateUtils.ExecSQL(strSQL.ToString)
                    Else
                        MessageUtils.ShowInformation("没有任何汇入记录！")
                    End If

                    SearchRecord("")
                End If
            End If
            MessageUtils.ShowInformation("汇入成功!")
        Catch ex As Exception
            MessageUtils.ShowInformation("汇入异常!")
        End Try
    End Sub


    Private Sub DgPartContrast_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgPartContrast.DataError
        e.Cancel = True
    End Sub

    Private Sub toolSaveType_Click(sender As Object, e As EventArgs) Handles toolSaveType.Click
        Try

            If Me.DgPartContrast.Rows.Count = 0 OrElse Me.DgPartContrast.CurrentRow Is Nothing Then
                MessageBox.Show("没有任何报错数据!")
                Exit Sub
            End If

            If (MessageBox.Show("你确定料号类别修改正确保存,取消继续修改！", "料号类别修改正确", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.OK) Then
                Me.DgPartContrast.EndEdit()
                Dim strSQL As New StringBuilder
                Dim strTPartId As String
                Dim strPPartId As String
                Dim strPartType As String
                For i As Integer = 0 To Me.DgPartContrast.RowCount - 1
                    strTPartId = IIf(IsDBNull(Me.DgPartContrast.Rows(i).Cells(0).Value), "", Me.DgPartContrast.Rows(i).Cells(0).Value)
                    strPPartId = IIf(IsDBNull(Me.DgPartContrast.Rows(i).Cells(1).Value), "", Me.DgPartContrast.Rows(i).Cells(1).Value)
                    strPartType = IIf(IsDBNull(Me.DgPartContrast.Rows(i).Cells(2).Value), "", Me.DgPartContrast.Rows(i).Cells(2).Value)
                    strSQL.AppendLine(" UPDATE m_PartContrast_t SET PartSeriesType='" & strPartType & "' WHERE tavcpart='" & strTPartId &
                                      "' AND pavcpart='" & strPPartId & "' " & BMComDB.GetPartFatory & " ")
                Next

                If Not String.IsNullOrEmpty(strSQL.ToString) Then
                    DbOperateUtils.ExecSQL(strSQL.ToString)
                    MessageBox.Show("保存成功!")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartContrast", "toolSaveType", "sys")
        End Try
    End Sub

    Private Sub ToolTestRules_Click(sender As Object, e As EventArgs) Handles ToolTestRules.Click
        Dim fr As FrmPartTestRules = New FrmPartTestRules
        fr.ShowDialog()
    End Sub

    Private Sub toolUpdateSeries_Click(sender As Object, e As EventArgs) Handles toolUpdateSeries.Click
        'GetMesData.SetMessage(Me.lblMessage, "", False)
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx;*.csv"
        'GetMesData.SetMessage(Me.lblMessage, "", False)
        If (sdfimport.ShowDialog() <> DialogResult.OK) Then
            Exit Sub
        End If
        Dim filename As String = ""
        Dim errorMsg As String = ""
        filename = sdfimport.FileName
        Dim o_strSql As New StringBuilder
        Dim index As Integer
        Try
            '导入模板格式
            '料件编码，系列别两栏
            '
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 2, errorMsg)
            If dtUploadData.Rows.Count < 1 Then
                MessageBox.Show("没有需要汇入的数据!")
                Exit Sub
            Else
                For index = 1 To dtUploadData.Rows.Count - 1
                    Dim strPartId As String = If(IsDBNull(dtUploadData.Rows(index)(0)), "", dtUploadData.Rows(index)(0).ToString)
                    Dim strSeriesID As String = If(IsDBNull(dtUploadData.Rows(index)(1)), "", dtUploadData.Rows(index)(1).ToString)
                    If String.IsNullOrEmpty(strPartId) Then
                        MessageBox.Show("第 " + (index + 1).ToString + " 行料件编码为空")
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(strPartId) Then
                        MessageBox.Show("第 " + (index + 1).ToString + " 行系列别为空")
                        Exit Sub
                    End If


                    o_strSql.Append(" update m_mainmo_t set SeriesID='" & strSeriesID & "' where   PartID='" & strPartId & "' ;")
                    o_strSql.Append(" update m_RCardM_t set SeriesID='" & strSeriesID & "',ModifyTime=getdate() where PartID='" & strPartId & "';   ")
                    o_strSql.Append(" update m_PartContrast_t set SeriesID='" & strSeriesID & "' where TavcPart='" & strPartId & "'" & BMComDB.GetPartFatory & " ;  ")

                Next
                DbOperateUtils.ExecSQL(o_strSql.ToString())

                MessageBox.Show("更新成功!")
            End If
        Catch ex As Exception
            MessageBox.Show("更新失败!")
        End Try
    End Sub

    ''' <summary>
    ''' 导出按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim o_fileName As String = ""

        Dim dt As New DataTable

        Select Case TabControl1.SelectedIndex
            Case 0
                dt = CType(DgPartContrast.DataSource, DataTable)
                o_fileName = "料件基础资料.xls"
            Case 1
                dt = CType(DgPartContrast2.DataSource, DataTable)
                o_fileName = "工治具基础资料.xls"
            Case Else
                dt = CType(DgPartContrast.DataSource, DataTable)
                o_fileName = "料件基础资料.xls"
        End Select


        NPOIExcle.DataTableExportToExcle(dt, Nothing, o_fileName)
        'MessageUtils.ShowInformation("导出成功!")
    End Sub
End Class

Public Class PartContrastBusiness

    Public Shared Function GetPartContrastList(Sqlstring As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String = "SELECT TOP 100 a.tavcpart , a.pavcpart, m_PartSeriesType_t.PartSeriesTypeCode, PlanType, a.cusid + '(' + b.cusname + ')' cusname ,a.custpart custpart,a.SeriesID + '(' + c.SeriesName + ')' SeriesID," & _
            "case when a.Usey='Y' then 'Yes' else 'No' end Usey,a.userid ,convert(varchar(16),a.intime,120)  intime," & _
            "lmty ,warndate ,typedest ,partcode ,Supplierid ,isnull(isupload,'') isupload," & _
            "isnull(isasseble,'') isasseble,isnull(islotscan,'') islotscan,isnull(IsAlter,'') IsAlter, " & _
            "isnull(DESCRIPTION,'') DESCRIPTION ,isnull(TYPE,'R') TYPE, m_PartSeriesType_t.PartSeriesTypeName,MSCustType  " & _
            "FROM m_PartContrast_t a left join m_Customer_t b on a.cusid=b.cusid " & _
            "Left join m_Series_t c on a.SeriesID=c.SeriesID " & _
            "left join m_PartSeriesType_t on a.PartSeriesType=m_PartSeriesType_t.PartSeriesTypeCode " & _
            " WHERE 1=1 " & BMComDB.GetPartFatory & Sqlstring
        StrSql = StrSql & " ORDER BY a.intime desc"

        dt = DbOperateUtils.GetDataTable(StrSql)

        Return dt
    End Function

    Public Shared Function GetPartContrast(tavcPart As String, pavcPart As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String = "select TAvcPart from m_PartContrast_t where 1=1 " & BMComDB.GetPartFatoryNoBlank &
                               " and TAvcPart='" & tavcPart & " ' and PAvcPart='" & pavcPart & "' "

        dt = DbOperateUtils.GetDataTable(StrSql)

        Return dt
    End Function

    Public Shared Sub InsertTable(paramsList As ArrayList)
        Dim strSQL As String
        strSQL = "INSERT INTO dbo.m_PartContrast_t " &
            "(TAvcPart ,PartName ,PAvcPart ,Factory,CusID ,SeriesID,CustPart ,MethodID ,UseY ,LmtY ,WarnDate ,Userid ,Intime ," &
            "TypeDest ,PartCode ,Supplierid ,IsUpload ,Isasseble ,IsLotScan ,IsAlter ,MaterialAlter ,IsPrintFile ," &
            "IsTransOracle ,IsChkTransData ,AmountQty ,DESCRIPTION ,SubstituteFlag ,IngredientsPart ,SubstituteNumber ," &
            "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE ,MARK ,EcnChange, PartSeriesType, PlanType,MSCustType)VALUES" &
            "(@TAvcPart ,@PartName ,@PAvcPart ,@Factory,@CusID ,@SeriesID,@CustPart ,@MethodID ,'Y' ,@LmtY ,@WarnDate ,@Userid,getdate()," &
            "@TypeDest,@PartCode,@Supplierid,@IsUpload,@Isasseble,@IsLotScan,@IsAlter,@MaterialAlter,@IsPrintFile," &
            "@IsTransOracle,@IsChkTransData,@AmountQty,@DESCRIPTION,@SubstituteFlag,@IngredientsPart,@SubstituteNumber," &
            "@Extensible ,@EffectiveDate ,@ExpirationDate ,@VERSION ,@TYPE ,@MARK ,@EcnChange, @PartSeriesType, @PlanType,@MSCustType)"
        Dim strSQL2 As String = "IF NOT EXISTS(SELECT 1 FROM m_PartContrastExtend_t WHERE PAvcPart = @PAvcPart AND PAvcPart = TAvcPart AND Factory = '')" &
            " BEGIN INSERT INTO dbo.m_PartContrastExtend_t " &
            "(TAvcPart ,PAvcPart ,Factory,CusID ,SeriesID,CustPart,Userid ,Intime)VALUES" &
            "(@TAvcPart,@PAvcPart ,'',@CusID ,@SeriesID,@CustPart,@Userid,getdate()) END"

        DbOperateUtils.ExecSQL(strSQL + strSQL2, paramsList)

    End Sub

    Public Shared Sub UpdateTable(paramsList As ArrayList)
        Dim strSQL As String
        strSQL = " UPDATE dbo.m_PartContrast_t" & _
                " SET PAvcPart = @PAvcPart" & _
                "    ,PartName = @PartName " & _
                "    ,CusID = @CusID" & _
                "    ,SeriesID = @SeriesID" & _
                "    ,CustPart = @CustPart" & _
                "    ,MethodID = @MethodID" & _
                "    ,UseY = 'Y'" & _
                "    ,LmtY = @LmtY" & _
                "    ,WarnDate = @WarnDate" & _
                "    ,Userid = @Userid" & _
                "    ,Intime = getdate()" & _
                "    ,TypeDest = @TypeDest" & _
                "    ,PartCode = @PartCode" & _
                "    ,Supplierid = @Supplierid" & _
                "    ,IsUpload = @IsUpload" & _
                "    ,Isasseble = @Isasseble" & _
                "    ,IsLotScan = @IsLotScan" & _
                "    ,IsAlter = @IsAlter" & _
                "    ,MaterialAlter = @MaterialAlter" & _
                "    ,IsPrintFile = @IsPrintFile" & _
                "    ,IsTransOracle = @IsTransOracle" & _
                "    ,IsChkTransData = @IsChkTransData" & _
                "    ,AmountQty = @AmountQty" & _
                "    ,DESCRIPTION = @DESCRIPTION" & _
                "    ,SubstituteFlag = @SubstituteFlag" & _
                "    ,IngredientsPart = @IngredientsPart" & _
                "    ,SubstituteNumber = @SubstituteNumber" & _
                "    ,Extensible = @Extensible" & _
                "    ,EffectiveDate = @EffectiveDate" & _
                "    ,ExpirationDate = @ExpirationDate" & _
                "    ,VERSION = @VERSION" & _
                "    ,TYPE = @TYPE" & _
                "    ,MARK = @MARK" & _
                "    ,EcnChange = @EcnChange" & _
                "    ,PartSeriesType=@PartSeriesType" & _
                "    ,PlanType=@PlanType" & _
                "    ,MSCustType=@MSCustType" & _
                " WHERE TAvcPart = @TAvcPart" & _
                " AND PAvcPart = @PAvcPartKey" &
                 BMComDB.GetPartFatoryNoBlank

        Dim strSQL2 As String =
            " UPDATE dbo.m_PartContrastExtend_t" & _
            " SET CusID = @CusID" & _
            "    ,SeriesID = @SeriesID" & _
            "    ,CustPart = @CustPart" & _
            " WHERE TAvcPart = PAvcPart" & _
            " AND PAvcPart = @PAvcPartKey and Factory = '' "


        DbOperateUtils.ExecSQL(strSQL + strSQL2, paramsList)

    End Sub


End Class
