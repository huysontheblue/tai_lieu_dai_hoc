
'--PLM BOM查询
'--Create by :　马锋
'--Create date :　2016/01/29
'--Ver : V01
'--Update date :  
'--
'更新图纸查询

#Region "名称空间"

Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports LXWarehouseManage
Imports Aspose.Cells
Imports MainFrame
Imports VbCommClass
Imports SysBasicClass

#End Region

Public Class FrmBomQuery

    Private _SopTemplateListFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSopList_Template.xls"

    Private _SopTemplateImportantFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSop_Template_Important.xls"

    Private _SopTemplateFile As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\Template\OnlineSop_Template.xls"

    Private _SketchDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\SketchImg\"

    Dim obj As New com.luxshare_ict.plmNew.SAPService

#Region "打印、导出相关DataTable"
    Private _MainDataTable As DataTable
    Public Property MainDataTable() As DataTable
        Get
            _MainDataTable.TableName = "MainDt"
            Return _MainDataTable
        End Get

        Set(ByVal Value As DataTable)
            _MainDataTable = Value
        End Set
    End Property

    Private _PartDataTable As DataTable
    Public Property PartDataTable() As DataTable
        Get
            _PartDataTable.TableName = "PartDt"
            Return _PartDataTable
        End Get

        Set(ByVal Value As DataTable)
            _PartDataTable = Value
        End Set
    End Property

    Private _EquimentDataTable As DataTable
    Public Property EquimentDataTable() As DataTable
        Get
            _EquimentDataTable.TableName = "EquiDt"
            Return _EquimentDataTable
        End Get

        Set(ByVal Value As DataTable)
            _EquimentDataTable = Value
        End Set
    End Property

    Private _PictureDataTable As DataTable
    Public Property PictureDataTable() As DataTable
        Get
            _PictureDataTable.TableName = "PicDt"
            Return _PictureDataTable
        End Get

        Set(ByVal Value As DataTable)
            _PictureDataTable = Value
        End Set
    End Property

    Private _ItemDataTable As DataTable
    Public Property ItemDataTable() As DataTable
        Get
            _ItemDataTable.TableName = "Item"
            Return _ItemDataTable
        End Get

        Set(ByVal Value As DataTable)
            _ItemDataTable = Value
        End Set
    End Property

    '是否开启权限验证
    Private _StartRight As Boolean
    Public Property StartRight() As Boolean
        Get
            Return _StartRight
        End Get

        Set(ByVal Value As Boolean)
            _StartRight = Value
        End Set
    End Property

    Private Function GetHsDt() As DataTable
        Dim Ht As DataTable = New DataTable
        Ht.Columns.Add("Value")
        Ht.Columns.Add("Text")
        Ht.Rows.Add("Z01", "Z01-零件图")
        Ht.Rows.Add("Z02", "Z02-蓝图")
        Ht.Rows.Add("Z03", "Z03-包规")
        Ht.Rows.Add("Z04", "Z04-模具产品图")
        Ht.Rows.Add("Z06", "Z06-产品3D图")
        Ht.Rows.Add("Z07", "Z07-模具结构图")
        Ht.Rows.Add("Z08", "Z08-模具图")
        Ht.Rows.Add("Z19", "Z19-Gerber文件")
        Ht.Rows.Add("Z20", "Z20-SIP")
        Ht.Rows.Add("Z21", "Z21-CP")
        Ht.Rows.Add("Z22", "Z22-不良看板")
        Ht.Rows.Add("Z23", "Z23-产品特殊特性")
        Ht.Rows.Add("Z24", "Z24-品质异常履历")
        Ht.Rows.Add("Z25", "Z25-ORT")
        'Ht.Add("Z02", "半成品图") '重复
        'Ht.Add("Z06", "客户图")'重复
        'Ht.Add("Z19", "其它CAD")'重复
        Ht.Rows.Add("Z30", "Z30-SOP")
        Ht.Rows.Add("Z31", "Z31-制作流程表")
        Ht.Rows.Add("Z32", "Z32-裁线卡")
        Ht.Rows.Add("Z33", "Z33-产品规格书")
        Ht.Rows.Add("Z34", "Z34-标准排配")
        Ht.Rows.Add("Z35", "Z35-排线卡")
        Ht.Rows.Add("Z36", "Z36-RTP")
        Ht.Rows.Add("Z37", "Z37-PFMEA")
        Ht.Rows.Add("Z38", "Z38-成型条件设定表")
        Ht.Rows.Add("Z39", "Z39-QC工程图")
        Ht.Rows.Add("Z40", "Z40-铆压规范")
        Ht.Rows.Add("Z41", "Z41-冲压条件设定表")
        Ht.Rows.Add("Z42", "Z42-元件站位表")
        Ht.Rows.Add("Z43", "Z43-烧录分位程式F")
        Ht.Rows.Add("Z44", "Z44-评估报告")
        Ht.Rows.Add("Z45", "Z45-过程控制特性")
        Ht.Rows.Add("Z59", "Z59-其它Document")
        Return Ht
    End Function

    ''' <summary>
    ''' DOKAR	SAP类别代号	
    ''' DOKNR	文件编号	
    ''' DOKVR	文件版本	
    ''' DKTXT	文件名称
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPLMCADD_Dt() As DataTable
        Dim Ht As DataTable = New DataTable
        Ht.Columns.Add("DOKAR")
        Ht.Columns.Add("DOKNR")
        Ht.Columns.Add("DOKVR")
        Ht.Columns.Add("DKTXT")
        Return Ht
    End Function
    Private Function GetMES_Dt() As DataTable
        Dim Ht As DataTable = New DataTable
        Ht.Columns.Add("classification")
        Ht.Columns.Add("item_number")
        Ht.Columns.Add("name")
        Ht.Columns.Add("sop_ver")
        Ht.Columns.Add("State")
        Ht.Columns.Add("Create_id")
        Ht.Columns.Add("Create_name")
        Ht.Columns.Add("Modified_id")
        Ht.Columns.Add("Modified_name")
        Ht.Columns.Add("part_create_id")
        Ht.Columns.Add("part_create_name")
        Ht.Columns.Add("release_date")
        Return Ht
    End Function
    Private Function GetPLMDATA_Dt() As DataTable
        Dim Ht As DataTable = New DataTable
        Ht.Columns.Add("DOKAR")
        Ht.Columns.Add("DOKNR")
        Ht.Columns.Add("DOKVR")
        Ht.Columns.Add("DKTXT")
        Ht.Columns.Add("FILE_NAME")
        Ht.Columns.Add("FILEDESC")
        Ht.Columns.Add("FILE_URL")
        Ht.Columns.Add("FILE_ID")
        Ht.Columns.Add("FILE_SIZE")
        Ht.Columns.Add("DAPPL")
        Return Ht
    End Function
#End Region


#Region "事件"

    '初期化
    Private Sub FrmBomQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvECNList.AutoGenerateColumns = False
            ComboBoxEx1.DataSource = GetHsDt()
            ComboBoxEx1.DisplayMember = "Text"
            ComboBoxEx1.ValueMember = "Value"

            With Me.dgvECNList
                .AutoResizeColumns()
                .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                .ScrollBars = ScrollBars.Both
            End With

            With Me.dgvSAPList
                .AutoResizeColumns()
                .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                .ScrollBars = ScrollBars.Both
            End With
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBomQuery", "FrmBomQuery_Load", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            Me.txtPartNo.Enabled = False
            If (String.IsNullOrEmpty(Me.txtPartNo.Text.Trim)) Then
                Me.trBomList.Nodes.Clear()
                Me.dgvECNList.DataSource = Nothing
                Me.dgvECNList.Rows.Clear()
                SetMessage(Me.lblMessage, "查询料号不能为空", False)
                Me.txtPartNo.Enabled = True
                Exit Sub
            End If

            Me.trBomList.Nodes.Clear()
            Me.dgvECNList.DataSource = Nothing
            Me.dgvECNList.Rows.Clear()

            Dim dtBom As DataTable
            dtBom = GetDataTable(Me.txtPartNo.Text.Trim)

            If (Not dtBom Is Nothing) Then
                If (dtBom.Rows.Count > 0) Then
                    Dim node As DevComponents.AdvTree.Node = New DevComponents.AdvTree.Node
                    node.Tag = ""
                    node.Text = Me.txtPartNo.Text.Trim
                    Me.trBomList.Nodes.Add(node)
                    BindBom(dtBom.DefaultView.ToTable, node)
                Else
                    SetMessage(Me.lblMessage, "料号不存在或用户没有该料号PLM系统查询权限", False)
                End If
            Else
                SetMessage(Me.lblMessage, "料号不存在或用户没有该料号PLM系统查询权限", False)
            End If
            Me.txtPartNo.Enabled = True
        Catch ex As Exception
            Me.trBomList.Nodes.Clear()
            Me.dgvECNList.DataSource = Nothing
            Me.dgvECNList.Rows.Clear()
            SetMessage(Me.lblMessage, "获取数据异常" + ex.Message, False)
            SysMessageClass.WriteErrLog(ex, "FrmBomQuery", "btnQuery_Click", "sys")
            Me.txtPartNo.Enabled = True
        End Try
    End Sub

    Private Function GetDataTable(partid As String) As DataTable
        Dim strSQL As String
        Dim dtBom As DataTable
        'Dim BomQuery As New com.luxshare_ict.plm.WebService1()
        'dtBom = BomQuery.GetBOMData(VbCommClass.VbCommClass.UseId, Me.txtPartNo.Text.Trim)
        '连接到SAP
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            strSQL = CommClass.GetErpFilterSqlSap(partid, "2")
            dtBom = OracleOperateUtils.GetDataTableSap(strSQL)
            'bom表中没有数据再到物料表中查找
            If dtBom.Rows.Count = 0 Then
                strSQL = CommClass.GetErpFilterSqlSap(partid, "3")
                dtBom = OracleOperateUtils.GetDataTableSap(strSQL)
            End If
        Else
            strSQL = SapCommon.GetErpFilterSql(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, partid)
            dtBom = OracleOperateUtils.GetDataTable(strSQL)
        End If
        dtBom.DefaultView.RowFilter = "ParentPartId <> ChildPartId"
        GetDataTable = dtBom.DefaultView.ToTable
    End Function

    ''' <summary>
    ''' 显示MES流程卡
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub trBomList_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles trBomList.NodeClick
        SetMessage(Me.lblMessage, "", False)
        Try
            If (Not String.IsNullOrEmpty(e.Node.Text)) Then
                Dim tpartid As String = e.Node.Text.Trim
                txtAVpartID.Text = tpartid
                If (e.Node.Nodes.Count = 0) Then
                    Dim dtBom As DataTable
                    dtBom = GetDataTable(e.Node.Text)

                    If (Not dtBom Is Nothing) Then
                        If (dtBom.Rows.Count > 0) Then
                            BindBom(dtBom, e.Node)
                        End If
                    End If

                    Dim dtClassification As DataTable = GetMES_Dt.Copy

                    dtClassification = UnionRcardAndSOP(e.Node.Text, dtClassification)
                    Me.dgvECNList.DataSource = dtClassification


                    'Dim BomClassification As New com.luxshare_ict.plm.WebService1()
                    'dtClassification = BomQuery.GetPLMClassification(VbCommClass.VbCommClass.UseId, e.Node.Text)
                    'If (Not dtClassification Is Nothing) Then
                    '    dtClassification = UnionRcardAndSOP(e.Node.Text, dtClassification)
                    '    Me.dgvECNList.DataSource = dtClassification
                    'Else
                    '    Me.dgvECNList.DataSource = Nothing
                    '    Me.dgvECNList.Rows.Clear()
                    'End If
                    ClassificationButtonText()
                Else
                    Dim dtClassification As DataTable = GetMES_Dt.Copy

                    dtClassification = UnionRcardAndSOP(e.Node.Text, dtClassification)
                    Me.dgvECNList.DataSource = dtClassification

                    'Dim dtClassification1 As DataTable
                    'Dim BomClassification1 As New com.luxshare_ict.plm.WebService1()
                    'dtClassification1 = BomClassification1.GetPLMClassification(VbCommClass.VbCommClass.UseId, e.Node.Text)

                    'If (Not dtClassification1 Is Nothing) Then
                    '    dtClassification1 = UnionRcardAndSOP(e.Node.Text, dtClassification1)
                    '    Me.dgvECNList.DataSource = dtClassification1
                    'Else
                    '    Me.dgvECNList.DataSource = Nothing
                    '    Me.dgvECNList.Rows.Clear()
                    'End If
                    ClassificationButtonText()
                End If
            End If
        Catch ex As Exception
            Me.dgvECNList.DataSource = Nothing
            Me.dgvECNList.Rows.Clear()
            SetMessage(Me.lblMessage, "获取数据异常" + ex.Message, False)
            SysMessageClass.WriteErrLog(ex, "FrmBomQuery", "trBomList_NodeClick", "sys")
        End Try
    End Sub

    Private Sub btnQueryPlm_Click(sender As Object, e As EventArgs) Handles btnQueryPlm.Click
        Dim _tpartid As String = txtAVpartID.Text.Trim
        Dim _type As String = ComboBoxEx1.SelectedValue
        GetPLMData(_tpartid, _type)
    End Sub

    Private Sub dgvSAPList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSAPList.CellContentClick
        If dgvSAPList.Columns(e.ColumnIndex).Name = "SAPURLQuery" Then
            Dim url = Me.dgvSAPList.Rows(e.RowIndex).Cells("FILE_URL").Value.ToString()
            System.Diagnostics.Process.Start(url)
        End If
    End Sub

    Private Sub dgvECNList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvECNList.CellContentClick
        SetMessage(Me.lblMessage, "", False)
        Try

            If dgvECNList.Columns(e.ColumnIndex).Name = "btnClassification" Then
                '类别
                Dim classification = Me.dgvECNList.Rows(e.RowIndex).Cells("classification").Value.ToString()
                Dim PartID = Me.dgvECNList.Rows(e.RowIndex).Cells("names").Value.ToString() '料号
                Dim Version = Me.dgvECNList.Rows(e.RowIndex).Cells("sop_ver").Value.ToString() '版本
                Dim DocID = Me.dgvECNList.Rows(e.RowIndex).Cells("item_number").Value.ToString() '文件编号
                If classification = "流程卡" Then
                    Dim dtRCard As DataTable = DbOperateUtils.GetDataTable(GetExportSql(PartID, False, Version))
                    dtRCard.TableName = "RunCard"
                    If dtRCard.Rows.Count > 0 Then
                        Dim errorMsg = ""
                        Dim filePath = "\\192.168.20.123\RunCard\RunCardTemplate.xlsx"
                        Dim sfd As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
                        sfd.FileName = PartID + ".xlsx"
                        sfd.InitialDirectory = True
                        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            If SysDataBaseClass.Import2ExcelByAs(filePath, sfd.FileName, dtRCard, GetVariables(dtRCard), errorMsg) = False Then
                                MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageUtils.ShowInformation("导出流程卡:" & PartID & "成功!")
                            End If
                        End If

                    Else
                        MessageUtils.ShowError("料件找不到对应的流程卡")
                    End If
                ElseIf classification = "在线SOP制作" Then
                    Dim docIdList As List(Of String) = New List(Of String)
                    docIdList.Add(DocID)
                    If ExprotOrPrintSop(docIdList, False) = True Then
                        MessageBox.Show("SOP文件导出成功,导出位置：c:\MesExport文件夹中", " 导出SOP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else 'PLM图纸
                    'Dim arrPara(0) As String
                    'Dim dtPLMData As DataTable
                    'Dim BomQuery As New com.luxshare_ict.plm.WebService1()
                    'arrPara(0) = Me.dgvECNList.Rows(e.RowIndex).Cells("item_number").Value
                    'dtPLMData = BomQuery.GetPLMData(arrPara, "n/K67oxui8q8TFMwoAQKng==")

                    'If (Not dtPLMData Is Nothing) Then
                    '    If (dtPLMData.Rows.Count > 0) Then
                    '        Dim strEncryptionURL As String = dtPLMData.Rows(0).Item("url")

                    '        If (String.IsNullOrEmpty(strEncryptionURL)) Then
                    '            Exit Sub
                    '        End If

                    '        Dim strURL As String     'luxshareICT
                    '        strURL = CryptoMemoryStream.Decrypt(strEncryptionURL, "linkcode")
                    '        strURL = strURL.TrimStart(";")
                    '        If String.IsNullOrEmpty(strURL) Then
                    '            SetMessage(Me.lblMessage, "PLM没有上传图纸!", False)
                    '            Exit Sub
                    '        End If

                    '        System.Diagnostics.Process.Start(strURL)
                    '    End If
                    'Else
                    '    SetMessage(Me.lblMessage, "ECN图纸路径不存在", False)
                    'End If
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "获取ECN图纸数据异常", False)
            SysMessageClass.WriteErrLog(ex, "FrmBomQuery", "dgvECNList_CellContentClick", "sys")
        End Try
    End Sub

#End Region


#Region "函数"


    ''' <summary>
    ''' 资讯服务申请单ITFW-20180820-0121，贺声平提出需求
    '''第一条需求，把流程卡和SOP整合到一起
    ''' add by 马跃平 2018-08-22
    ''' </summary>
    ''' <remarks></remarks>
    Private Function UnionRcardAndSOP(ByVal PartID As String, ByVal dt As DataTable) As DataTable
        Try
            'dt.Rows.Clear()

            Dim sql = "select FileNO,PartID,DrawingVer,Status,UserID,isnull(ModifyTime,InTime) InTime from m_RCardM_t where partid='" & PartID & "'"
            Dim dtRCard As DataTable = DbOperateUtils.GetDataTable(sql)
            sql = "select DocId,SopName,Version,Status,CreateUserID,isnull(ModifyTime,CreateTime) CreateTime from m_OnlineSop_t where SopName='" & PartID & "' and Status<>'D'"
            Dim dtSOP As DataTable = DbOperateUtils.GetDataTable(sql)
            Dim MyDr As DataRow = dt.NewRow()
            If dtRCard.Rows.Count > 0 Then
                MyDr("classification") = "流程卡"
                MyDr("item_number") = dtRCard.Rows(0)("FileNO").ToString()
                MyDr("name") = dtRCard.Rows(0)("PartID").ToString()
                MyDr("sop_ver") = dtRCard.Rows(0)("DrawingVer").ToString()
                Dim Status = dtRCard.Rows(0)("Status").ToString()
                If Status = 1 Then
                    MyDr("State") = "已完成"
                ElseIf Status = 2 Then
                    MyDr("State") = "待审核"
                Else
                    MyDr("State") = "制作中"
                End If
                MyDr("Create_id") = dtRCard.Rows(0)("UserID").ToString()
                MyDr("Create_name") = DbOperateUtils.GetDataTable("select UserName from m_Users_t where UserID='" & MyDr("Create_id") & "'").Rows(0)(0).ToString()
                MyDr("Modified_id") = MyDr("Create_id")
                MyDr("Modified_name") = MyDr("Create_name")
                MyDr("part_create_id") = MyDr("Create_id")
                MyDr("part_create_name") = MyDr("Create_name")
                MyDr("release_date") = dtRCard.Rows(0)("InTime").ToString()
                dt.Rows.Add(MyDr)
            End If
            If dtSOP.Rows.Count > 0 Then
                MyDr = dt.NewRow()
                MyDr("classification") = "在线SOP制作"
                MyDr("item_number") = dtSOP.Rows(0)("DocId").ToString()
                MyDr("name") = dtSOP.Rows(0)("SopName").ToString()
                MyDr("sop_ver") = dtSOP.Rows(0)("Version").ToString()
                Dim Status = dtSOP.Rows(0)("Status").ToString()
                If Status = "N" Then
                    MyDr("State") = "制作中"
                ElseIf Status = "S" Then
                    MyDr("State") = "待审核"
                ElseIf Status = "P" Then
                    MyDr("State") = "待生产审核"
                ElseIf Status = "Q" Then
                    MyDr("State") = "待品管审核"
                ElseIf Status = "A" Then
                    MyDr("State") = "待核准"
                ElseIf Status = "C" Then
                    MyDr("State") = "待DCC审核"
                Else
                    MyDr("State") = "已生效"
                End If
                MyDr("Create_id") = dtSOP.Rows(0)("CreateUserID").ToString()
                MyDr("Create_name") = DbOperateUtils.GetDataTable("select UserName from m_Users_t where UserID='" & MyDr("Create_id") & "'").Rows(0)(0).ToString()
                MyDr("Modified_id") = MyDr("Create_id")
                MyDr("Modified_name") = MyDr("Create_name")
                MyDr("part_create_id") = MyDr("Create_id")
                MyDr("part_create_name") = MyDr("Create_name")
                MyDr("release_date") = dtSOP.Rows(0)("CreateTime").ToString()
                dt.Rows.Add(MyDr)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
        Return dt
    End Function


    Private Sub GetPLMData(ByVal partid As String, ByVal type As String)

        Dim dt1 As DataTable = New DataTable
        Dim json As Object = JsonClass.ToJson(obj.GetPLMData_SAP(partid, type))
        Dim item As Object
        For Each item In json
            If (item.Name = "Data") Then
                dt1 = JsonClass.ToTable(item.First.ToString)
            End If
        Next

        Dim dt2 As DataTable = New DataTable
        Dim json2 As Object = JsonClass.ToJson(obj.GetPLMCADD_SAP(partid, type))
        'Dim item2 As Object
        For Each item In json2
            If (item.Name = "Data") Then
                dt2 = JsonClass.ToTable(item.First.ToString)
            End If
        Next
        Dim dt As DataTable = GetPLMDATA_Dt().Copy
        Dim i As Integer = 0
        If Not dt1 Is Nothing Then
            If dt1.Rows.Count > 0 Then
                For i = 0 To dt1.Rows.Count - 1
                    Dim dr As DataRow = dt.NewRow
                    dr("DOKAR") = dt2.Rows(0)("DOKAR")
                    dr("DOKNR") = dt2.Rows(0)("DOKNR")
                    dr("DOKVR") = dt2.Rows(0)("DOKVR")
                    dr("DKTXT") = dt2.Rows(0)("DKTXT")
                    dr("FILE_NAME") = dt1.Rows(i)("FILE_NAME")
                    dr("FILEDESC") = dt1.Rows(i)("FILEDESC")
                    dr("FILE_URL") = dt1.Rows(i)("FILE_URL")
                    dr("FILE_ID") = dt1.Rows(i)("FILE_ID")
                    dr("FILE_SIZE") = dt1.Rows(i)("FILE_SIZE")
                    dr("DAPPL") = dt1.Rows(i)("DAPPL")
                    dt.Rows.Add(dr)
                Next
                lbsapMessage.Text = type + "图纸查询成功"
                lbsapMessage.ForeColor = Color.Green
            End If
        Else
            lbsapMessage.Text = type + "图纸数据为空"
            lbsapMessage.ForeColor = Color.Red
        End If

        dgvSAPList.DataSource = dt
        dgvSAPListButtonText()
    End Sub
    Private Sub dgvSAPListButtonText()
        For i As Int16 = 0 To Me.dgvSAPList.Rows.Count - 1
            Me.dgvSAPList.Rows(i).Cells("SAPURLQuery").Value = "文件预览"  '8
        Next
    End Sub

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    Public Shared Function GetExportSql(Optional ByVal runCardPn As String = "", Optional ByVal isQueryOldVersion As Boolean = False, Optional ByVal strRCardVersion As String = "") As String
        Dim sql As String = Nothing
        Dim strFilterVerSQL As String = String.Empty
        'As is:
        'DETAIL.EQUIPMENT EQUIPMENT,DETAIL.PROCESSSTANDARD STANDARD,
        ' Now: DETAIL.PROCESSSTANDARD + IIf(isnull(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD,
        'cq 20160803          remove   "        AND PARTD.Userid <> 'SYSTEM'" & _

        If String.IsNullOrEmpty(strRCardVersion) Then
            strFilterVerSQL = ""
        Else
            strFilterVerSQL = "	AND HEADER.DrawingVer = DETAIL.DrawingVer	AND DETAIL.DRAWINGVER = '" & strRCardVersion & "'"
        End If

        If isQueryOldVersion = False Then
            'cq 20170228
            'm_RCardDPart_t==>{2}, m_PartContrast_t ==>{3}
            sql = "SELECT PartID," &
                "       DRAWINGVER," &
                "       SHAPE," &
                "       ID AS SEQ," &
                "       STATIONNAME," &
                "       LABORHOUR AS HOURS," &
                " StdLabors," & _
                "       EQUIPMENT," &
                "       STANDARD," &
                "       REMARK,SID SECTIONID," &
                "       TypeDest," &
                "       DESCRIPTION," &
                "       STATUS," &
                "       AUDITUSERID," &
                "       CREATEUSERID ," &
                "       DID," &
                "        (CASE  WHEN LEN(ISNULL(rawinfo,''))>=3 THEN LEFT (RAWINFO, LEN (RAWINFO) - 3) ELSE '' END)RAWINFO, MODIFYTIME  FROM" &
                "  (SELECT A.*," &
                "     (SELECT DISTINCT PARTD.TAvcPart+ IIf(ISNULL(EwPNLRdirection,'') ='','',':'+ IIf(ewpnlrdirection='L','(左端)','(右端)')) +':' + case when  PARTD.DESCRIPTION is null or PARTD.DESCRIPTION='' or PARTD.DESCRIPTION='/' then PARTD.TypeDest else PARTD.DESCRIPTION end +' || '" &
                "      FROM {2} PARTDETAIL,{3} PARTD" &
                "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
                "        AND PARTDETAIL.Stationid  = A.Stationid" &
                "        AND PARTDETAIL.PartID = A.PartID" &
                "        AND ISNULL(PARTD.TYPE,'R') IN ('R','E')" &
                "        AND  PARTD.PAvcPart = '" & runCardPn & "' " & vbCrLf &
                "        AND PARTD.TAvcPart <> PARTD.PAvcPart" & vbCrLf &
                "        FOR XML PATH('')" & _
                "        ) AS RAWINFO" &
                "   FROM" &
                "     (SELECT " &
                "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
                "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
                "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
                "      IIf(DETAIL.PROCESSSTANDARD is null,DETAIL.PROCESSSTANDARDPrint,DETAIL.PROCESSSTANDARD) + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD," & _
                "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
                "       PART.DESCRIPTION," & _
                "         (SELECT TOP 1 username FROM m_Users_t AA, m_RCardMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & runCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
                "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
                "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
                "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" &
                "      FROM (SELECT TOP 1 * FROM v_m_PartContrast_t WHERE TAvcPart = PAvcPart AND TAvcPart='" & runCardPn & "' )  PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
                "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
                "      AND SECTION.USEY=1" &
                "      WHERE 1=1 " &
                "        AND HEADER.PARTID =PART.TAvcPart" &
                "        AND HEADER.PARTID=DETAIL.PARTID" &
                "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
                "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" + "" & strFilterVerSQL & "" & _
                GetFatoryProfitcenter("HEADER") &
                "  ) A)B " &
                "ORDER BY B.ID"
            sql = String.Format(sql, "m_RCardM_t", "m_RCardD_t", "m_RCardDPart_t", "m_PartContrast_t")
        Else
            sql = "SELECT PartID," &
             "       DRAWINGVER," &
             "       SHAPE," &
             "       ID AS SEQ," &
             "       STATIONNAME," &
             "       LABORHOUR AS HOURS," &
             "       StdLabors," & _
             "       EQUIPMENT," &
             "       STANDARD," &
             "       REMARK,SID SECTIONID," &
             "       TypeDest," &
             "       DESCRIPTION," &
             "       STATUS," &
             "       AUDITUSERID," &
             "       CREATEUSERID ," &
             "       DID," &
             "        (CASE  WHEN LEN(ISNULL(rawinfo,''))>=3 THEN LEFT (RAWINFO, LEN (RAWINFO) - 3) ELSE '' END)RAWINFO, MODIFYTIME  FROM" &
             "  (SELECT A.*," &
             "     (SELECT DISTINCT PARTD.TAvcPart+ IIf(ISNULL(EwPNLRdirection,'') ='','',':'+ IIf(ewpnlrdirection='L','(左端)','(右端)')) +':' + PARTD.DESCRIPTION+' || '" &
             "      FROM {2} PARTDETAIL,{3} PARTD" &
             "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
             "        AND PARTDETAIL.Stationid  = A.Stationid" &
             "        AND PARTDETAIL.PartID = A.PartID" &
             "        AND ISNULL(PARTD.TYPE,'R') IN ('R','E')" &
             "        AND  PARTD.PAvcPart = '" & runCardPn & "' " & vbCrLf &
             "        AND ISNULL(partdetail.DrawingVer,'" & strRCardVersion & "') = '" & strRCardVersion & "'" & _
             "        AND PARTD.TAvcPart <> PARTD.PAvcPart" & vbCrLf &
             "        FOR XML PATH('')" & _
             "        ) AS RAWINFO" &
             "   FROM" &
             "     (SELECT " &
             "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
             "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
             "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
             "       DETAIL.PROCESSSTANDARD + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD," & _
             "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
             "       PART.DESCRIPTION," & _
             " (SELECT TOP 1 username FROM m_Users_t AA, m_RCardMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & runCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
             "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
             "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
             "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" &
             "      FROM (SELECT TOP 1 * FROM v_m_PartContrast_t WHERE TAvcPart = PAvcPart  AND TAvcPart='" & runCardPn & "')PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
             "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
             "      AND SECTION.USEY=1" &
             "      WHERE 1=1 " &
             "        AND HEADER.PARTID =PART.TAvcPart" &
             "        AND HEADER.PARTID=DETAIL.PARTID" &
             "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
             "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" + "" & strFilterVerSQL & "" & _
             GetFatoryProfitcenter("HEADER") &
             "  ) A)B " &
             "ORDER BY B.ID"
            sql = String.Format(sql, "m_RCardMOldVer_t", "m_RCardDOldVer_t", "m_RCardDPartOldVer_t", "m_PartContrastOldVer_t")
        End If

        Return sql
    End Function

    ''' <summary>
    ''' 导出或打印SOP
    ''' </summary>
    ''' <param name="ListDocID">文件编码列表</param>
    ''' <param name="IsPrint">是否打印</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExprotOrPrintSop(ByVal ListDocID As List(Of String), ByVal IsPrint As Boolean, Optional ByVal m_Orientation As Integer = 2) As Boolean
        Dim result As Boolean = False
        Dim temp As String

        Dim ExcelFileList As List(Of String) = New List(Of String)
        Try

            If ListDocID Is Nothing OrElse ListDocID.Count < 1 Then
                Return False
            End If

            For Each _DocId As String In ListDocID
                '生产Excel
                temp = GetOutputExclePath(_DocId)
                If Not String.IsNullOrEmpty(temp) Then
                    ExcelFileList.Add(temp)
                End If
            Next
            ''需打印的SOP
            'If Not ExcelFileList Is Nothing AndAlso ExcelFileList.Count > 0 AndAlso IsPrint = True Then
            '    For Each _File As String In ExcelFileList
            '        PrintSop(_File)
            '    Next
            '    Return True
            'End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "ExprotSopList()", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 生产Excel并返回Excel地址
    ''' </summary>
    ''' <param name="docID">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOutputExclePath(ByVal docID As String) As String
        Dim excelPath As String = Nothing
        Dim o_TempoutputFile As String
        Dim _ListId As List(Of String) = New List(Of String)
        Dim errorMsg As String = Nothing

        Dim ds As DataSet
        Dim TemplatePath As String = Nothing
        Dim _tempFilePathList As List(Of String) = New List(Of String)
        Try
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If
            '获取明细ID列表
            _ListId = GetPrintListId(docID)

            '------------生成清单------------------
            o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"

            'If SimpleExprotExcel(Me._SopTemplateListFile, o_TempoutputFile, Me.ItemDataTable, GetBodyVariables(), errorMsg) Then
            '    _tempFilePathList.Add(o_TempoutputFile)
            'End If

            If ExprotPrintListExcel(Me._SopTemplateListFile, o_TempoutputFile, GetListVariable(docID), errorMsg) Then
                _tempFilePathList.Add(o_TempoutputFile)
            End If

            '--------------生成SOP--------------------------------

            '单个SOP,
            For Each _Id As String In _ListId
                ds = GetSopExprotData(_Id, IIf(Len(docID) <= 15, False, True))
                If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                    Me._MainDataTable = ds.Tables(0)
                    Me._PartDataTable = ds.Tables(1)
                    Me._EquimentDataTable = ds.Tables(2)
                    Me._PictureDataTable = ds.Tables(3)

                    o_TempoutputFile = "c:\MesExport\" & Guid.NewGuid().ToString & ".xlsx"

                    '判断是否为重点工站
                    If ds.Tables(0).Rows(0)("IsFocusStation").ToString.ToLower = "true" Then
                        TemplatePath = Me._SopTemplateImportantFile
                    Else
                        TemplatePath = Me._SopTemplateFile
                    End If

                    If SopDataOutPutExcel(TemplatePath, o_TempoutputFile, GetVariables(), errorMsg) = True Then
                        _tempFilePathList.Insert(1, o_TempoutputFile)
                    End If
                End If
            Next

            If Not _tempFilePathList Is Nothing AndAlso _tempFilePathList.Count > 0 Then
                '列出清单
                '合并成一个Excel
                Dim m_SopName = "c:\MesExport\" & docID & "_" & Now.ToString("yyyyMMddHHmmss") & ".xlsx"
                Dim fstreamAll As New FileStream(_tempFilePathList(0), FileMode.Open)
                Dim workbook As New Workbook(fstreamAll)
                workbook.Worksheets(0).Name = "明细"

                For idx As Integer = 1 To _tempFilePathList.Count - 1

                    Dim fstream As New FileStream(_tempFilePathList(idx), FileMode.Open)
                    Dim tempBook As New Workbook(fstream)
                    tempBook.Worksheets(0).Name = (idx)
                    workbook.Combine(tempBook)
                    o_TempoutputFile = m_SopName
                    workbook.Save(o_TempoutputFile, SaveFormat.Xlsx)
                    fstream.Close()
                    excelPath = o_TempoutputFile

                Next
                fstreamAll.Close()

                '删除临时文件
                For Each _fPath As String In _tempFilePathList

                    If (File.Exists(_fPath)) Then
                        File.Delete(_fPath)
                    End If
                Next
                Return excelPath
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetOutputExclePath()", "sys")
        End Try
        Return excelPath
    End Function

    ''' <summary>
    ''' 根据DOCID获取明细表ID
    ''' </summary>
    ''' <param name="docId">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPrintListId(ByVal docId As String) As List(Of String)
        Dim o_strSql As New StringBuilder
        Dim _List As List(Of String) = New List(Of String)
        Dim ds As DataSet

        If Len(docId) <= 15 Then
            o_strSql.Append("select Id from m_OnlineSopItem_t  a inner join  m_OnlineSop_t b on b.DocId=a.DocId where a.DocId='" & docId & "'  ORDER BY a.PageSize ;")
            'SOP清单
            o_strSql.Append(" select  Row_Number() OVER (ORDER BY a.PageSize ASC) as Idx, ")
            o_strSql.Append(" a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.Remark,c.DocId,c.SopName,c.Version,(N'制作:'+b.UserName) as UserName,")
            o_strSql.Append("  (N'审核:'+c.VerifyUserName) as VerifyUserName,(N'品管:'+c.QCUserName) as QCUserName, ")
            o_strSql.Append(" (N'生产:'+c.ProdUserName) as ProdUserName,(N'核准:'+c.ApprovalUserName) as ApprovalUserName ")
            o_strSql.Append(" from m_OnlineSopItem_t a left join  m_Users_t b on b.UserID=a.ModifyUserId  left join ")
            o_strSql.Append(" m_OnlineSop_t c on c.DocId=a.DocId  WHERE a.DocId='" & docId & "' ORDER BY a.PageSize")
        Else
            o_strSql.Append("select Id from m_OnlineSopItemOldVer_t  a inner join  m_OnlineSopOldVer_t b on b.DocId=a.DocId where a.DocId='" & docId & "'  ORDER BY a.PageSize ;")
            'SOP清单
            o_strSql.Append(" select  Row_Number() OVER (ORDER BY a.PageSize ASC) as Idx, ")
            o_strSql.Append(" a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.Remark,c.DocId,c.SopName,c.Version,(N'制作:'+b.UserName) as UserName,")
            o_strSql.Append("  (N'审核:'+c.VerifyUserName) as VerifyUserName,(N'品管:'+c.QCUserName) as QCUserName, ")
            o_strSql.Append(" (N'生产:'+c.ProdUserName) as ProdUserName,(N'核准:'+c.ApprovalUserName) as ApprovalUserName ")
            o_strSql.Append(" from m_OnlineSopItemOldVer_t a left join  m_Users_t b on b.UserID=a.ModifyUserId  left join ")
            o_strSql.Append(" m_OnlineSopOldVer_t c on c.DocId=a.DocId  WHERE a.DocId='" & docId & "' ORDER BY a.PageSize")
        End If

        ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                _List = New List(Of String)
                For Each Row As DataRow In ds.Tables(0).Rows
                    _List.Insert(0, Row(0).ToString)
                Next
            End If

            'If ds.Tables(1).Rows.Count > 0 Then
            '    Me._ItemDataTable = ds.Tables(1)
            'End If

        End If
        Return _List
    End Function

    ''' <summary>
    ''' 汇出Excel打印清单
    ''' </summary>
    ''' <param name="TemplatePath"></param>
    ''' <param name="OutPutFile"></param>
    ''' <param name="dics"></param>
    ''' <param name="errorMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExprotPrintListExcel(ByVal TemplatePath As String, ByVal OutPutFile As String, ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(TemplatePath)
            workBookDesigner.Workbook = wk
            Dim s As Aspose.Cells.Style = workBookDesigner.Workbook.Styles(workBookDesigner.Workbook.Styles.Add())

            s.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            s.Font.Color = Color.Black
            s.Font.Name = "宋体"
            s.Font.Size = 12

            s.ForegroundColor = Color.LimeGreen
            s.Pattern = Aspose.Cells.BackgroundType.Solid


            Dim r_Index As Integer = 0
            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
                If dic.Key.Contains("RecentlyEdit") AndAlso dic.Value = "Y" Then

                    r_Index = dic.Key.Split("_")(1)
                    If r_Index <= 28 Then
                        For index As Integer = 0 To 4
                            Dim cel As Aspose.Cells.Cell = workBookDesigner.Workbook.Worksheets(0).Cells(r_Index + 2, index)
                            cel.SetStyle(s)
                        Next
                    Else
                        For index As Integer = 5 To 9
                            Dim cel As Aspose.Cells.Cell = workBookDesigner.Workbook.Worksheets(0).Cells(r_Index - 26, index)
                            cel.SetStyle(s)
                        Next
                    End If

                End If


            Next
            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(OutPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 获取打印清单模板变量
    ''' </summary>
    ''' <param name="docId">文件编码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetListVariable(ByVal docId As String) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim o_strSql As New StringBuilder
        Dim ds As New DataSet
        Try
            '单头
            If Len(docId) <= 15 Then
                o_strSql.Append("select a.DocId,a.SopName,a.Version,(N'制作:'+b.UserName) as UserName, ")
                o_strSql.Append(" (N'审核:'+a.VerifyUserName) as VerifyUserName,(N'品管:'+a.QCUserName) as QCUserName, ")
                o_strSql.Append(" (N'生产:'+a.ProdUserName) as ProdUserName,(N'核准:'+a.ApprovalUserName) as ApprovalUserName  from m_OnlineSop_t a ")
                o_strSql.Append(String.Format(" left join  m_Users_t b on b.UserID=a.CreateUserId WHERE DocId='{0}';", docId))
            Else
                o_strSql.Append("select a.DocId,a.SopName,a.Version,(N'制作:'+b.UserName) as UserName, ")
                o_strSql.Append(" (N'审核:'+a.VerifyUserName) as VerifyUserName,(N'品管:'+a.QCUserName) as QCUserName, ")
                o_strSql.Append(" (N'生产:'+a.ProdUserName) as ProdUserName,(N'核准:'+a.ApprovalUserName) as ApprovalUserName  from m_OnlineSopOldVer_t a ")
                o_strSql.Append(String.Format(" left join  m_Users_t b on b.UserID=a.CreateUserId WHERE DocId='{0}';", docId))
            End If

            '单身
            If Len(docId) <= 15 Then
                o_strSql.Append(" SELECT  ID,StationName,VerNo,EcnNo,PageSize,RecentlyEdit ")
                o_strSql.Append(String.Format(" FROM m_OnlineSopItem_t where DocId='{0}' ORDER BY  PageSize ", docId))
            Else
                o_strSql.Append(" SELECT  ID,StationName,VerNo,EcnNo,PageSize,RecentlyEdit ")
                o_strSql.Append(String.Format(" FROM m_OnlineSopItemOldVer_t where DocId='{0}' ORDER BY  PageSize ", docId))
            End If
            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    dics.Add("DocId", ds.Tables(0).Rows(0)("DocId").ToString)
                    dics.Add("SopName", ds.Tables(0).Rows(0)("SopName").ToString)
                    dics.Add("Version", ds.Tables(0).Rows(0)("Version").ToString)
                    dics.Add("PageCount", ds.Tables(1).Rows.Count)
                    dics.Add("UserName", ds.Tables(0).Rows(0)("UserName").ToString)
                    dics.Add("VerifyUserName", ds.Tables(0).Rows(0)("VerifyUserName").ToString)
                    dics.Add("QCUserName", ds.Tables(0).Rows(0)("QCUserName").ToString)
                    dics.Add("ProdUserName", ds.Tables(0).Rows(0)("ProdUserName").ToString)
                    dics.Add("ApprovalUserName", ds.Tables(0).Rows(0)("ApprovalUserName").ToString)
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    For item As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        dics.Add("StationName_" + (item + 1).ToString, ds.Tables(1).Rows(item)("StationName").ToString)
                        dics.Add("VerNo_" + (item + 1).ToString, ds.Tables(1).Rows(item)("VerNo").ToString)
                        dics.Add("EcnNo_" + (item + 1).ToString, ds.Tables(1).Rows(item)("EcnNo").ToString)
                        dics.Add("PageSize_" + (item + 1).ToString, ds.Tables(1).Rows(item)("PageSize").ToString)
                        dics.Add("RecentlyEdit_" + (item + 1).ToString, ds.Tables(1).Rows(item)("RecentlyEdit").ToString)
                    Next

                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetListVariable()", "sys")
        End Try

        Return dics
    End Function
    ''' <summary>
    ''' 获取待导出SOP数据
    ''' </summary>
    ''' <param name="_Id">明细表ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSopExprotData(ByVal _Id As String, Optional ByVal isOldVer As Boolean = False) As DataSet
        Dim o_strSql As New StringBuilder
        Dim ds As DataSet = Nothing
        Try
            If isOldVer = False Then
                o_strSql.Append("SELECT A.Id,a.PartId,a.DocId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.IsFocusStation,a.InsItems,")
                o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName,a.IsFinger,a.IsAS")
                o_strSql.Append(" FROM m_OnlineSopItem_t a  INNER JOIN m_OnlineSop_t b on b.DocId=a.DocId")
                o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE A.Id='" & _Id & "';")
                o_strSql.Append(" SELECT  Row_Number() OVER (ORDER BY PartId desc) as Idx, PartName,PartId,Amount,Spec FROM m_OnlineSopPart_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT Row_Number() OVER (ORDER BY EquiNo desc) as Idx,EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipment_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT OrdIndex,PicPath,PicDesc FROM m_OnlineSopPicture_t WHERE PId='" & _Id & "' ORDER BY OrdIndex ASC;")
            Else
                o_strSql.Append("SELECT A.Id,a.PartId,a.DocId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.IsFocusStation,a.InsItems,")
                o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName,a.IsFinger,a.IsAS")
                o_strSql.Append(" FROM m_OnlineSopItemOldVer_t a  INNER JOIN m_OnlineSopOldVer_t b on b.DocId=a.DocId")
                o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE A.Id='" & _Id & "';")
                o_strSql.Append(" SELECT  Row_Number() OVER (ORDER BY PartId desc) as Idx, PartName,PartId,Amount,Spec FROM m_OnlineSopPartOldVer_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT Row_Number() OVER (ORDER BY EquiNo desc) as Idx,EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipmentOldVer_t WHERE PId='" & _Id & "';")
                o_strSql.Append(" SELECT OrdIndex,PicPath,PicDesc FROM m_OnlineSopPictureOldVer_t WHERE PId='" & _Id & "' ORDER BY OrdIndex ASC;")

            End If
            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSop", "GetSopExprotData()", "sys")
        End Try
        Return ds
    End Function
    ''' <summary>
    ''' SOP数据输出Excel
    ''' </summary>
    ''' <param name="TemplatePath">SOP模板路径</param>
    ''' <param name="OutPutFile">输出Excel路径</param>
    ''' <param name="dics">变量集合</param>
    ''' <param name="errorMsg">错误消息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SopDataOutPutExcel(ByVal TemplatePath As String, ByVal OutPutFile As String, _
                                               ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim img As Integer = 0
        Dim _IsFinger As Boolean = False '手指套
        Dim _IsAs As Boolean = False     '防静电
        Dim _ImgLeft As Int16 = 0   '图片左偏移
        Dim _ImgTop As Int16 = 0   '图片上偏移
        Dim _PicIndex As Int16 = 0 '图片索引
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(TemplatePath)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(Me.MainDataTable)
            workBookDesigner.SetDataSource(Me.PartDataTable)
            workBookDesigner.SetDataSource(Me.EquimentDataTable)
            workBookDesigner.SetDataSource(Me.PictureDataTable)

            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next
            '图片（210x200）

            If Me.PictureDataTable.Rows.Count > 0 Then
                For index As Integer = 0 To Me.PictureDataTable.Rows.Count - 1
                    img = Me.PictureDataTable.Rows(index)("PicPath").ToString.Length
                    Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
                    If index = 0 Then
                        If img > 0 Then
                            pictures.Add(4, 2, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 1 Then
                        If img > 0 Then
                            pictures.Add(4, 7, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 2 Then
                        If img > 0 Then
                            pictures.Add(4, 12, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 3 Then
                        If img > 0 Then
                            pictures.Add(23, 2, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    ElseIf index = 4 Then
                        If img > 0 Then
                            pictures.Add(23, 7, Me.PictureDataTable.Rows(index)("PicPath").ToString)

                        End If

                    Else
                        If img > 0 Then
                            pictures.Add(23, 12, Me.PictureDataTable.Rows(index)("PicPath").ToString)
                        End If

                    End If
                    '图片限定6个
                    If index > 5 Then
                        Exit For
                    End If
                Next

            End If
            'add by hgd 2017-05-02插入示意图，手指套或防静电标识
            If Me.MainDataTable.Rows.Count > 0 Then
                _IsFinger = CBool(Me.MainDataTable.Rows(0)("IsFinger").ToString)
                _IsAs = CBool(Me.MainDataTable.Rows(0)("IsAS").ToString)
                Dim SketchPic As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
                If _IsFinger = True AndAlso _IsAs = False Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Fingersleeve.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 3
                    pictureFingersleeve.Top = 10
                ElseIf _IsFinger = False AndAlso _IsAs = True Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                ElseIf _IsFinger = True AndAlso _IsAs = True Then
                    _PicIndex = SketchPic.Add(37, 15, Me._SketchDirector + "Antistatic.png")
                    Dim pictureAntistatic As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureAntistatic.Left = 3
                    pictureAntistatic.Top = 10
                    _PicIndex = SketchPic.Add(37, 17, Me._SketchDirector + "Fingersleeve.png")
                    Dim pictureFingersleeve As Aspose.Cells.Drawing.Picture = workBookDesigner.Workbook.Worksheets(0).Pictures(_PicIndex)
                    pictureFingersleeve.Left = 55
                    pictureFingersleeve.Top = 10
                Else
                End If
            End If
            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(OutPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function
    ''' <summary>
    ''' 获取模板变量并赋值
    ''' </summary>
    ''' <returns>Dictionary(Of String, String)</returns>
    ''' <remarks></remarks>
    Private Function GetVariables() As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)

        Dim ColInx() As String
        ColInx = {"One", "Two", "Tre", "Four", "Five", "Six", "Sev", "Eig"}
        Dim Pre_ColName As String = Nothing
        If Me.MainDataTable.Rows.Count > 0 Then
            dics.Add("PartID", Me.MainDataTable.Rows(0)("PartID").ToString)
            dics.Add("StationName", Me.MainDataTable.Rows(0)("StationName").ToString)
            dics.Add("EcnNo", Me.MainDataTable.Rows(0)("EcnNo").ToString)
            dics.Add("VerNo", Me.MainDataTable.Rows(0)("VerNo").ToString)
            dics.Add("PageSize", Me.MainDataTable.Rows(0)("PageSize").ToString)
            dics.Add("InsItems", Me.MainDataTable.Rows(0)("InsItems").ToString)
            dics.Add("UserName", Me.MainDataTable.Rows(0)("UserName").ToString)
            dics.Add("VerifyUserName", Me.MainDataTable.Rows(0)("VerifyUserName").ToString)
            dics.Add("ProdUserName", Me.MainDataTable.Rows(0)("ProdUserName").ToString)
            dics.Add("QCUserName", Me.MainDataTable.Rows(0)("QCUserName").ToString)
            dics.Add("ApprovalUserName", Me.MainDataTable.Rows(0)("ApprovalUserName").ToString)
        End If
        '使用物料
        If Me.PartDataTable.Rows.Count > 0 Then
            For index As Integer = 0 To Me.PartDataTable.Rows.Count - 1
                Pre_ColName = "Part_" & ColInx(index)
                dics.Add(Pre_ColName & "Idx", Me.PartDataTable.Rows(index)("Idx").ToString)
                dics.Add(Pre_ColName & "PartName", Me.PartDataTable.Rows(index)("PartName").ToString)
                dics.Add(Pre_ColName & "PartId", Me.PartDataTable.Rows(index)("PartId").ToString)
                dics.Add(Pre_ColName & "Amount", Me.PartDataTable.Rows(index)("Amount").ToString)
                dics.Add(Pre_ColName & "Spec", Me.PartDataTable.Rows(index)("Spec").ToString)
                '限定只取6行数据,否则导出的模板因内容过多，导致错位
                If index > 6 Then
                    Exit For
                End If
            Next

        End If
        '治工具
        If Me.EquimentDataTable.Rows.Count > 0 Then
            For index As Integer = 0 To Me.EquimentDataTable.Rows.Count - 1
                Pre_ColName = "Equi_" & ColInx(index)
                dics.Add(Pre_ColName & "Idx", Me.EquimentDataTable.Rows(index)("Idx").ToString)
                dics.Add(Pre_ColName & "EquiName", Me.EquimentDataTable.Rows(index)("EquiName").ToString)
                dics.Add(Pre_ColName & "EquiNo", Me.EquimentDataTable.Rows(index)("EquiNo").ToString)
                dics.Add(Pre_ColName & "EquiDesc", Me.EquimentDataTable.Rows(index)("EquiDesc").ToString)
                '限定只取6行数据,否则导出的模板因内容过多，导致错位
                If index > 4 Then
                    Exit For
                End If
            Next
        End If
        '图片
        If Me.PictureDataTable.Rows.Count > 0 Then
            For index As Integer = 0 To Me.PictureDataTable.Rows.Count - 1
                Pre_ColName = "Pic_" & ColInx(index)
                dics.Add(Pre_ColName & "PicDesc", Me.PictureDataTable.Rows(index)("PicDesc").ToString)
                If index > 5 Then
                    Exit For
                End If
            Next
        End If
        Return dics
    End Function

    Public Function GetVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim strArea As New StringBuilder
        Dim o_strStdUPPH As String = ""
        If dt.Rows.Count > 0 Then
            dics.Add("PN", dt.Rows(0)("PartID").ToString)
            dics.Add("VERSION", dt.Rows(0)("DRAWINGVER").ToString)
            dics.Add("SHAPE", dt.Rows(0)("SHAPE").ToString)
            dics.Add("DESCRIPTION1", dt.Rows(0)("DESCRIPTION").ToString)
            '铆端前加工 产线加工,成型加工,裁切前加工,生产线前加工, 半自动压接连接
            ' 裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）/总工时	
            dics.Add("Cut", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '04'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '04'")))
            dics.Add("PreAssembly", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '01'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '01'")))
            dics.Add("SemiAuto", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= 'A05'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= 'A05'")))
            dics.Add("Contour", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '03'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '03'")))
            dics.Add("Made", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '02'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '02'")))
            dics.Add("Total", dt.Compute("sum(HOURS)", ""))
            dics.Add("DESCRIPTION", dt.Rows(0)("TypeDest").ToString)
            dics.Add("STATUS", dt.Rows(0)("STATUS").ToString)
            dics.Add("CREATEUSER", dt.Rows(0)("CREATEUSERID").ToString)
            dics.Add("AuditUser", dt.Rows(0)("AUDITUSERID").ToString)
            dics.Add("MODIFYTIME", dt.Rows(0)("MODIFYTIME").ToString)

            dics.Add("StdLabors", dt.Rows(0)("StdLabors").ToString)
            o_strStdUPPH = IIf(dt.Compute("sum(HOURS)", "") = "0", "0", Math.Round((3600 / dt.Compute("sum(HOURS)", "")), 1))
            dics.Add("StdUPPH", o_strStdUPPH)
            dics.Add("StdUPH", IIf(dt.Compute("sum(HOURS)", "") = "0", "0", Math.Round(Val(o_strStdUPPH) * Val(dt.Rows(0)("StdLabors").ToString), 1)))
            'cq 20161113
            If dt.Rows(0)("DESCRIPTION").ToString.IndexOf("日本市场") >= 0 Or
                dt.Rows(0)("TypeDest").ToString.IndexOf("日本市场") >= 0 Then
                strArea.Append("(日本市场)")
            End If
            If dt.Rows(0)("TypeDest").ToString.IndexOf("贴UL标签") >= 0 Or dt.Rows(0)("DESCRIPTION").ToString.IndexOf("贴UL标签") >= 0 Then
                strArea.Append("(贴UL标签)")
            End If
            dics.Add("Area", strArea.ToString)
        End If
        Return dics
    End Function

    Private Sub BindBom(ByVal dtBom As DataTable, ByVal node As DevComponents.AdvTree.Node)
        SetMessage(Me.lblMessage, "", False)
        Try
            For i As Int16 = 0 To dtBom.Rows.Count - 1
                Dim nodeChild As DevComponents.AdvTree.Node = New DevComponents.AdvTree.Node
                'nodeChild.Tag = dtBom.Rows(i).Item("ChildDescription").ToString
                nodeChild.Text = dtBom.Rows(i).Item("ChildPartId").ToString
                nodeChild.Tooltip = dtBom.Rows(i).Item("ChildDescription").ToString
                node.Nodes.Add(nodeChild)
            Next
            node.Expand()
        Catch ex As Exception
            Me.dgvECNList.DataSource = Nothing
            Me.dgvECNList.Rows.Clear()
            SetMessage(Me.lblMessage, "填充Bom结构异常", False)
            SysMessageClass.WriteErrLog(ex, "FrmBomQuery", "BindBom", "sys")
        End Try
    End Sub

    Private Sub ClassificationButtonText()
        For i As Int16 = 0 To Me.dgvECNList.Rows.Count - 1
            Me.dgvECNList.Rows(i).Cells(10).Value = "文件预览"  '8
        Next
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region


    'Public Function GetExportSql(Optional ByVal runCardPn As String = "", Optional ByVal isQueryOldVersion As Boolean = False, Optional ByVal strRCardVersion As String = "") As String
    '    Dim sql As String = Nothing
    '    Dim strFilterVerSQL As String = String.Empty

    '    If String.IsNullOrEmpty(strRCardVersion) Then
    '        strFilterVerSQL = ""
    '    Else
    '        strFilterVerSQL = "	AND HEADER.DrawingVer = DETAIL.DrawingVer	AND DETAIL.DRAWINGVER = '" & strRCardVersion & "'"
    '    End If

    '    If isQueryOldVersion = False Then
    '        'cq 20170228
    '        'm_RCardDPart_t==>{2}, m_PartContrast_t ==>{3}
    '        sql = "SELECT PartID," &
    '            "       DRAWINGVER," &
    '            "       SHAPE," &
    '            "       ID AS SEQ," &
    '            "       STATIONNAME," &
    '            "       LABORHOUR AS HOURS," &
    '            " StdLabors," & _
    '            "       EQUIPMENT," &
    '            "       STANDARD," &
    '            "       REMARK,SID SECTIONID," &
    '            "       TypeDest," &
    '            "       DESCRIPTION," &
    '            "       STATUS," &
    '            "       AUDITUSERID," &
    '            "       CREATEUSERID ," &
    '            "       DID," &
    '            "        (CASE  WHEN LEN(ISNULL(rawinfo,''))>=3 THEN LEFT (RAWINFO, LEN (RAWINFO) - 3) ELSE '' END)RAWINFO, MODIFYTIME  FROM" &
    '            "  (SELECT A.*," &
    '            "     (SELECT DISTINCT PARTD.TAvcPart+ IIf(ISNULL(EwPNLRdirection,'') ='','',':'+ IIf(ewpnlrdirection='L','(左端)','(右端)')) +':' + case when  PARTD.DESCRIPTION is null or PARTD.DESCRIPTION='' or PARTD.DESCRIPTION='/' then PARTD.TypeDest else PARTD.DESCRIPTION end +' || '" &
    '            "      FROM {2} PARTDETAIL,{3} PARTD" &
    '            "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
    '            "        AND PARTDETAIL.Stationid  = A.Stationid" &
    '            "        AND PARTDETAIL.PartID = A.PartID" &
    '            "        AND ISNULL(PARTD.TYPE,'R') IN ('R','E')" &
    '            "        AND  PARTD.PAvcPart = '" & runCardPn & "' " & vbCrLf &
    '            "        AND PARTD.TAvcPart <> PARTD.PAvcPart" & vbCrLf &
    '            "        FOR XML PATH('')" & _
    '            "        ) AS RAWINFO" &
    '            "   FROM" &
    '            "     (SELECT " &
    '            "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
    '            "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
    '            "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
    '            "      IIf(DETAIL.PROCESSSTANDARD is null,DETAIL.PROCESSSTANDARDPrint,DETAIL.PROCESSSTANDARD) + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD," & _
    '            "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
    '            "       PART.DESCRIPTION," & _
    '            "         (SELECT TOP 1 username FROM m_Users_t AA, m_RCardMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & runCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
    '            "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
    '            "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
    '            "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" &
    '            "      FROM m_PartContrast_t PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
    '            "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
    '            "      AND SECTION.USEY=1" &
    '            "      WHERE PART.TAvcPart ='" & runCardPn & "'" &
    '            "        AND HEADER.PARTID =PART.TAvcPart" &
    '            "        AND HEADER.PARTID=DETAIL.PARTID" &
    '            "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
    '            "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" &
    '            "        AND PART.TAvcPart = PART.PAvcPart " + "" & strFilterVerSQL & "" & _
    '            GetFatoryProfitcenter("HEADER") &
    '            "  ) A)B " &
    '            "ORDER BY B.ID"
    '        sql = String.Format(sql, "m_RCardM_t", "m_RCardD_t", "m_RCardDPart_t", "m_PartContrast_t")
    '    Else
    '        sql = "SELECT PartID," &
    '         "       DRAWINGVER," &
    '         "       SHAPE," &
    '         "       ID AS SEQ," &
    '         "       STATIONNAME," &
    '         "       LABORHOUR AS HOURS," &
    '         "       StdLabors," & _
    '         "       EQUIPMENT," &
    '         "       STANDARD," &
    '         "       REMARK,SID SECTIONID," &
    '         "       TypeDest," &
    '         "       DESCRIPTION," &
    '         "       STATUS," &
    '         "       AUDITUSERID," &
    '         "       CREATEUSERID ," &
    '         "       DID," &
    '         "        (CASE  WHEN LEN(ISNULL(rawinfo,''))>=3 THEN LEFT (RAWINFO, LEN (RAWINFO) - 3) ELSE '' END)RAWINFO, MODIFYTIME  FROM" &
    '         "  (SELECT A.*," &
    '         "     (SELECT DISTINCT PARTD.TAvcPart+ IIf(ISNULL(EwPNLRdirection,'') ='','',':'+ IIf(ewpnlrdirection='L','(左端)','(右端)')) +':' + PARTD.DESCRIPTION+' || '" &
    '         "      FROM {2} PARTDETAIL,{3} PARTD" &
    '         "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
    '         "        AND PARTDETAIL.Stationid  = A.Stationid" &
    '         "        AND PARTDETAIL.PartID = A.PartID" &
    '         "        AND ISNULL(PARTD.TYPE,'R') IN ('R','E')" &
    '         "        AND  PARTD.PAvcPart = '" & runCardPn & "' " & vbCrLf &
    '         "        AND ISNULL(partdetail.DrawingVer,'" & strRCardVersion & "') = '" & strRCardVersion & "'" & _
    '         "        AND PARTD.TAvcPart <> PARTD.PAvcPart" & vbCrLf &
    '         "        FOR XML PATH('')" & _
    '         "        ) AS RAWINFO" &
    '         "   FROM" &
    '         "     (SELECT " &
    '         "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
    '         "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
    '         "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
    '         "       DETAIL.PROCESSSTANDARD + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD," & _
    '         "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
    '         "       PART.DESCRIPTION," & _
    '         " (SELECT TOP 1 username FROM m_Users_t AA, m_RCardMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & runCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
    '         "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
    '         "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
    '         "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" &
    '         "      FROM m_PartContrast_t PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
    '         "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
    '         "      AND SECTION.USEY=1" &
    '         "      WHERE PART.TAvcPart ='" & runCardPn & "'" &
    '         "        AND HEADER.PARTID =PART.TAvcPart" &
    '         "        AND HEADER.PARTID=DETAIL.PARTID" &
    '         "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
    '         "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" &
    '         "        AND PART.TAvcPart = PART.PAvcPart " + "" & strFilterVerSQL & "" & _
    '         GetFatoryProfitcenter("HEADER") &
    '         "  ) A)B " &
    '         "ORDER BY B.ID"
    '        sql = String.Format(sql, "m_RCardMOldVer_t", "m_RCardDOldVer_t", "m_RCardDPartOldVer_t", "m_PartContrastOldVer_t")
    '    End If

    '    Return sql
    'End Function
End Class