Imports MainFrame.SysCheckData
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports System.Text

Public Class FrmSampleReqNo
    Private buttonStatus As EnumStatus
    Private Enum EnumStatus
        UnDo = -1
        NewAdd = 0
        Edit = 1
        Delete = 2
        DownLoad = 3
        Search = 4
    End Enum
    Private Enum enumdgvSampleD
        LevelID
        Status
        DutyUserID
        PlanDueDate
        StartTime
        EndTime
    End Enum
    Public Enum SampleInfo
        Item_Number = 0 '样品单号
        State
        LX_Product_Type
        LX_PRODUCT_TYPE_Desc
        Applyid '申请厂区
        APPLY_Desc
        LX_IMA01 '
        LX_RDN_Projectno
        LX_PREL_RDNID
        LX_RFQ_PROJECT_NAME2
        LX_NeedQTY
        LX_UNIT
        LX_RD_TIME
        LX_RFQ_Customer_ID
        LX_RFQ_CUSTOMERX
        LX_USE
        LX_ACKNOWLEDGMENT
        LX_ACKNOWLEDGMENT_O
        LX_Sampling_Reason
        LX_CURRENCY
        LX_ISFEE
        LX_ORDERNO
        LX_COST
        LX_PRICE
        RD_USER_ID
        RD_USER_NAME
        SAMP_User_ID  '制样人员
        SAMP_User_Name
        DQA_User_ID
        DQA_User_Name
        PMC_User_ID
        PMC_User_Name '生管
        SAP_Created_ID '业务
        SAP_Created_Name
        lx_profitcenter
        lx_profitcenter_desc
    End Enum

    Public Enum enumdgvSample
        SampleNo
        CustID
        DeliveryDate
        DevNo
        PartNo
        Qty
        MadeQty 'cq20170118
        EBOMPartNo
        Intime
        UserID
        Status
        FormatDes
        RDUserName
        YWUserName
        PZUserName
        YPSUserName
        EquUserName
        SGUserName
        PIEUserName
        ZJUserName
        CCUserName
        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName
    End Enum

    Private m_strPLMFactoryID As String = SampleCom.GetPLMFactory(VbCommClass.VbCommClass.Factory)
    Private m_strPLMProfitcenter As String = SampleCom.GetPLMProfitcenter(VbCommClass.VbCommClass.profitcenter)
    Private m_strDutyDeptName As String = String.Empty

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        buttonStatus = EnumStatus.NewAdd
        AddRecord()
        TabControl1.Enabled = False
        Me.CobCust.Enabled = True
        Me.CobCust.Focus()
        Me.txtSampleNo.Enabled = True
        Me.txtSampleNo.Text = ""
        Me.txtDevNo.Enabled = True
        Me.txtDevNo.Text = ""
        Me.txtPartNo.Enabled = True
        Me.txtPartNo.Text = ""
        Me.txtQty.Enabled = True
        Me.txtQty.Text = ""
        Me.txtRDUserName.Enabled = True
        Me.txtFormatDes.Enabled = True
        Me.txtFormatDes.Text = ""
        If TabControl1.SelectedIndex = 0 Then
            TxtTavcPart.Enabled = True
        ElseIf TabControl1.SelectedIndex = 1 Then
            TxtTavcPart.Enabled = True
            TxtPavcPart.Enabled = False
            SetBomEnable()
        End If
    End Sub

    Private Sub SetBomEnable()
        CobCust.Enabled = False
        txtSampleNo.Enabled = False
    End Sub

#Region "增加记录"
    Private Sub AddRecord()
        Me.CobCust.SelectedIndex = -1
        ChgRecord(0)
        SetControlStates()
        ClearControl()
    End Sub
#End Region

#Region "改变记录"
    Private Sub ChgRecord(ByVal Flag As Integer)
        Dim EmsCon As Control
        Select Case Flag
            Case 0
                Me.dgvSampleReqNo.Enabled = True
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = True
                    End If
                Next
                dgvSampleReqNo.Enabled = False
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
                dgvSampleReqNo.Enabled = True
        End Select
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
                toolSave.Enabled = False
                SetControlEnable(False)
                SetErpVisible(True)
            Case EnumStatus.UnDo
                SetButtonEnable(True)
                SetControlEnable(False)
                SetErpVisible(False)
                Me.chkRequsteTime.Checked = False
                Me.txtFormatDes.Text = ""
                Me.txtFormatDes.Enabled = False
                Me.txtEBOMPN.Text = ""
                Me.txtEBOMPN.Enabled = False
        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolEdit.Enabled = bFlag
        Delete.Enabled = bFlag
        btnERP.Enabled = bFlag
        toolSave.Enabled = Not bFlag
        toolUndo.Enabled = Not bFlag
        Export.Enabled = bFlag
        toolSearch.Enabled = bFlag
        FileRefresh.Enabled = bFlag
    End Sub

    Private Sub SetControlEnable(bFlag As Boolean)
        Me.UpLmt.Enabled = bFlag
    End Sub

    Private Sub SetErpVisible(bFlag As Boolean)
        If Not bFlag Then
            Me.TabPage1.Parent = Me.TabControl1
            Me.TabPage2.Parent = Me.TabControl1
            Me.TabPage2.Parent = Nothing
        Else
            Me.TabPage1.Parent = Nothing
            Me.TabPage2.Parent = Nothing
            Me.TabPage2.Parent = Me.TabControl1
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
        Me.dtDeliveryDate.Checked = False

    End Sub
#End Region

    Private Sub ToolDownLoad_Click(sender As Object, e As EventArgs) Handles ToolDownLoad.Click
        buttonStatus = EnumStatus.DownLoad
        PLMDownLoad()
        Me.CobCust.Enabled = True
        Me.CobCust.Focus()
        Me.txtRDUserName.Enabled = True
        TxtTavcPart.Enabled = True
    End Sub

    Private Sub PLMDownLoad()
        Me.CobCust.SelectedIndex = -1
        'ChgRecord(0)
        TxtTavcPart.Enabled = True
        SetControlStates()
        ClearControl()

    End Sub

    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        buttonStatus = EnumStatus.UnDo
        CancelChg()
    End Sub

#Region "返回"
    Private Sub CancelChg()
        TabControl1.Enabled = True
        ChgRecord(1)
        SetControlStates()
    End Sub
#End Region

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            SaveData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "toolSave_Click", "Sample")
        End Try
    End Sub

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
                    StrCust = Mid(Trim(Me.CobCust.Text), 1, InStr(Trim(Me.CobCust.Text), "--") - 1)
                End If

                If String.IsNullOrEmpty(StrCust) Then
                    MessageUtils.ShowError("客户名称不能为空,请检查!")
                    Exit Sub
                End If
            End If

            If buttonStatus = EnumStatus.NewAdd Then
                Dim dt As DataTable = GetPartContrast(StrCust, Trim(Me.txtSampleNo.Text))
                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowInformation("系统中已存在该样品单号！")
                    Exit Sub
                End If
                '料件资料BOM的时总是相同
                If TabControl1.SelectedIndex = 1 Then
                    TxtPavcPart.Text = TxtTavcPart.Text.Trim
                End If

                Dim arrayList As New ArrayList
                arrayList.Add("SampleNo|" & Me.txtSampleNo.Text)
                arrayList.Add("CusID|" & StrCust)
                arrayList.Add("DeliveryDate|" & Me.dtDeliveryDate.Value.ToShortDateString)
                arrayList.Add("DevNo|" & Me.txtDevNo.Text.Trim)
                arrayList.Add("PartNo|" & Me.txtPartNo.Text.Trim)
                arrayList.Add("Qty|" & Me.txtQty.Text.Trim)
                arrayList.Add("FormatDes|" & Me.txtFormatDes.Text.Trim)
                arrayList.Add("RDUserName|" & Me.txtRDUserName.Text.Trim)
                arrayList.Add("Userid|" & SysMessageClass.UseId)
                arrayList.Add("Factoryid|" & VbCommClass.VbCommClass.Factory)
                arrayList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)
                Call InsertTable(arrayList)
                MessageUtils.ShowInformation("资料保存成功")
            ElseIf buttonStatus = EnumStatus.Edit Then
                Dim arrayList As New ArrayList
                arrayList.Add("SampleNo|" & Me.txtSampleNo.Text)
                arrayList.Add("CusID|" & StrCust)
                arrayList.Add("DeliveryDate|" & Me.dtDeliveryDate.Value.ToShortDateString)
                arrayList.Add("DevNo|" & Me.txtDevNo.Text.Trim)
                arrayList.Add("PartNo|" & Me.txtPartNo.Text.Trim)
                arrayList.Add("MadeQty|" & Me.txtMadeQty.Text.Trim)
                arrayList.Add("FormatDes|" & Me.txtFormatDes.Text.Trim)
                arrayList.Add("EBOMPartNo|" & Me.txtEBOMPN.Text.Trim)
                arrayList.Add("Userid|" & SysMessageClass.UseId)

                UpdateTable(arrayList)
                MessageUtils.ShowInformation("资料保存成功")
            ElseIf buttonStatus = EnumStatus.DownLoad Then
                ' Dim dt As DataTable = Nothing 'PartContrastBusiness.GetPartContrast(Trim(Me.TxtTavcPart.Text), Trim(Me.TxtTavcPart.Text))
                ' Dim plmService As New com.luxshare_ict.plm.WebService1
                ' Dim dt As DataTable = plmService.GetPLMSAP(m_strPLMFactoryID, m_strPLMProfitcenter, StrCust, "In Review")

                'If dt.Rows.Count > 0 Then
                '    If MessageUtils.ShowConfirm("已经存在该料件信息，确认是否需要重新下载;如需要,请检查该料号下面子件的版本信息！！！", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                '        Exit Sub
                '    End If
                'End If

                SavePLMData()
                MessageUtils.ShowInformation("资料保存成功!")
                lblMsg.Text = "提示信息"
            End If

            buttonStatus = EnumStatus.UnDo
            CancelChg()
            SearchRecord("")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message & vbCrLf & "错误")
            SysMessageClass.WriteErrLog(ex, "FrmSampleReqNo", "SaveData", "Sample")
        End Try
    End Sub

    Public Shared Function GetPartContrast(ByVal strCustID As String, ByVal strSampleNO As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String = " SELECT CustID FROM m_Sample_t WHERE CustID='" & strCustID & "' and SampleNO='" & strSampleNO & "' "

        dt = DbOperateUtils.GetDataTable(StrSql)

        Return dt
    End Function

    Public Shared Sub InsertTable(paramsList As ArrayList)
        Dim strSQL As String
        strSQL = "INSERT INTO dbo.m_Sample_t " &
            "(SampleNo ,CustID ,DeliveryDate,DevNo,PartNo,Qty,Userid ,Intime ,Status,FormatDes,RDUserName,Factoryid,Profitcenter)VALUES" &
            "(@SampleNo ,@CusID ,@DeliveryDate,@DevNo ,@PartNo ,@Qty ,@Userid,getdate(),'0',@FormatDes, @RDUserName, @Factoryid, @Profitcenter )"
        DbOperateUtils.ExecSQL(strSQL, paramsList)
    End Sub

    Public Shared Sub UpdateTable(paramsList As ArrayList)
        Dim strSQL As String
        strSQL = " UPDATE dbo.m_Sample_t" & _
                " SET DeliveryDate = @DeliveryDate" & _
                "    ,MadeQty = @MadeQty " & _
                "    ,DevNo = @DevNo " & _
                "    ,PartNo = @PartNo " & _
                "    ,FormatDes = @FormatDes " & _
                "    ,EBOMPartNo = @EBOMPartNo " & _
                "    ,Userid = @Userid" & _
                "    ,Intime = getdate()" & _
                " WHERE CUSTID = @CUSID" & _
                " AND SampleNO = @SampleNO"
        DbOperateUtils.ExecSQL(strSQL, paramsList)
    End Sub

#Region "检查记录"
    Private Sub CheckRecord()
        If TabControl1.SelectedIndex = 0 Then
            'Dim PavcPartErr As New Exception("父料件编号不能为空")
            'PavcPartErr.Source = "CheckRecord"
            'If Me.TxtPavcPart.Text = "" Then
            '    TxtPavcPart.Focus()
            '    Throw PavcPartErr
            'End If
            ' If Me.rdoPN.Checked = True Then 'Add by cq 20160118
            Dim CustPartErr As New Exception("客户料号不能为空")
            CustPartErr.Source = "CheckRecord"
            If Me.txtSampleNo.Text = "" Then
                txtSampleNo.Focus()
                Throw New Exception("客户料号不能为空")
            End If
            Dim CustNameErr As New Exception("客户名称不能为空")
            CustNameErr.Source = "CheckRecord"
            If Me.CobCust.Text = "" Then
                CobCust.Focus()
                Throw New Exception("客户名称不能为空")
            End If
        End If

    End Sub
#End Region

#Region "搜索记录"

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        If Sqlstring = "" Then
            dt = GetSampleList("")
            dgvSampleReqNo.DataSource = dt
        Else
            dt = GetSampleList(Sqlstring)
            dgvSampleReqNo.DataSource = dt
        End If
        '样品单号，客户代码，需求日期， 开发案号， 数量， 维护时间，维护人， 状态
        'SampleNo, CustID,DeliveryDate,DevNo,PartNo,Qty,Intime,UserID, Status
        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName,|策采责任人
        Dim ChColsText As String = "样品单号|客户代码|需求日期|开发案号|料件编号|需求数量|制样数量|对应E-BOM成品料号|维护时间|维护人|状态|规格描述|研发姓名|业务姓名|品质姓名|样品室责任人|生技责任人|生管姓名|PIE责任人|治具责任人"

        Dim colNames As String() = ChColsText.Split("|")
        If dt IsNot Nothing Then
            For i As Integer = 0 To dgvSampleReqNo.Columns.Count - 1
                dgvSampleReqNo.Columns(i).HeaderText = colNames(i)
                dgvSampleReqNo.Columns(i).Name = colNames(i)
            Next
            ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
        End If

        Me.dgvSampleReqNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Public Shared Function GetSampleList(Sqlstring As String) As DataTable
        Dim dt As DataTable

        Dim StrSql As String =
            " SELECT TOP 1000 SampleNo, (a.CustID + '--' + b.CusName) CustID ,DeliveryDate,DevNo,PartNo," & _
            " a.Qty, MadeQty,a.EBOMPartNo, a.Intime, " & _
            " (a.UserID + '/' + d.UserName) UserID , " & _
            " (a.Status +'.' + c.Description) Status, FormatDes, RDUserName,YWUserName,PZUserName,YPSUserName," & _
            " EquUserName,SGUserName,PIEUserName,ZJUserName " & _
            " FROM m_Sample_t a " & _
            " LEFT JOIN m_Customer_t b ON a.CUSTID=b.CUSID " & _
            " LEFT JOIN m_SampleBaseData_t c ON  c.Itemkey ='SampleStatus' AND  a.Status = c.StatusValue " & _
            " LEFT JOIN m_Users_t  d ON a.UserID=d.Userid " & _
            " WHERE 1=1 " & Sqlstring
        StrSql = StrSql & " ORDER BY a.intime DESC"

        dt = DbOperateUtils.GetDataTable(StrSql)

        Return dt
    End Function

    Private Sub SetDataGridViewStyle()
        dgvPLMSampleInfo.Columns(SampleInfo.Item_Number.ToString).HeaderText = "样品单号"
        dgvPLMSampleInfo.Columns(SampleInfo.Item_Number.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvPLMSampleInfo.Columns(SampleInfo.State.ToString).HeaderText = "状态"
        dgvPLMSampleInfo.Columns(SampleInfo.LX_Product_Type.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_PRODUCT_TYPE_Desc.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.Applyid.ToString).HeaderText = "厂区"
        dgvPLMSampleInfo.Columns(SampleInfo.APPLY_Desc.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_IMA01.ToString).HeaderText = "料件编号"
        dgvPLMSampleInfo.Columns(SampleInfo.LX_RDN_Projectno.ToString).HeaderText = "开发案号"  '开发案号
        dgvPLMSampleInfo.Columns(SampleInfo.LX_PREL_RDNID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_RFQ_PROJECT_NAME2).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_NeedQTY.ToString).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvPLMSampleInfo.Columns(SampleInfo.LX_UNIT.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_RD_TIME.ToString).HeaderText = "需求出货时间"
        dgvPLMSampleInfo.Columns(SampleInfo.LX_RFQ_Customer_ID.ToString).HeaderText = "客户代码"
        dgvPLMSampleInfo.Columns(SampleInfo.LX_RFQ_CUSTOMERX.ToString).HeaderText = "客户名称"
        dgvPLMSampleInfo.Columns(SampleInfo.LX_USE.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_ACKNOWLEDGMENT.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_ACKNOWLEDGMENT_O.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_Sampling_Reason.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_CURRENCY.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_ISFEE.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_ORDERNO.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_COST.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.LX_PRICE.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.RD_USER_ID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.RD_USER_NAME.ToString).HeaderText = "研发姓名"

        dgvPLMSampleInfo.Columns(SampleInfo.SAMP_User_ID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.SAMP_User_Name.ToString).Visible = False '制样人员

        dgvPLMSampleInfo.Columns(SampleInfo.DQA_User_ID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.DQA_User_Name.ToString).HeaderText = "品质姓名"

        dgvPLMSampleInfo.Columns(SampleInfo.PMC_User_ID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.PMC_User_Name.ToString).HeaderText = "生管姓名"

        dgvPLMSampleInfo.Columns(SampleInfo.SAP_Created_ID.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.SAP_Created_Name.ToString).HeaderText = "业务姓名"

        dgvPLMSampleInfo.Columns(SampleInfo.lx_profitcenter.ToString).Visible = False
        dgvPLMSampleInfo.Columns(SampleInfo.lx_profitcenter_desc.ToString).Visible = False
    End Sub
#End Region

    '保存PLM下载数据
    Private Sub SavePLMData()
        Dim SampleNo As String = "", CustID As String = ""
        Dim Deliverydate As String = "", DevNo As String = ""
        Dim PartNo As String = ""
        Dim Qty As String = String.Empty, strRDUserName As String = "", strPZUserName As String = "", strSGUserName As String = ""
        Dim strCustID As String = "", strSerialID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim strInsertSQL As String = ""
        Dim strYWUserName As String = ""
        Try
            'Add check by cq 20151122
            If dgvPLMSampleInfo.Rows.Count <= 0 Then
                Exit Sub
            End If

            Dim strUpdateSQL As String =
                    " UPDATE dbo.m_Sample_t "

            strInsertSQL =
                "INSERT INTO dbo.m_Sample_t " & _
                "(SampleNo ,CustID ,DeliveryDate ,DevNo ,PartNo ,Qty ,Intime ,UserID ,Status," & _
                "  Factoryid, Profitcenter, RDUserName,PZUserName, SGUserName,YWUserName)"

            '子料号
            For iCnt As Integer = 0 To dgvPLMSampleInfo.Rows.Count - 1
                SampleNo = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.Item_Number.ToString).Value.ToString
                CustID = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.LX_RFQ_Customer_ID.ToString).Value.ToString
                Deliverydate = Convert.ToDateTime(dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.LX_RD_TIME.ToString).Value.ToString)
                DevNo = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.LX_RDN_Projectno.ToString).Value.ToString
                PartNo = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.LX_IMA01.ToString).Value.ToString
                Qty = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.LX_NeedQTY.ToString).Value.ToString
                strRDUserName = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.RD_USER_NAME.ToString).Value.ToString
                strPZUserName = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.DQA_User_Name.ToString).Value.ToString
                strSGUserName = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.PMC_User_Name.ToString).Value.ToString
                strYWUserName = dgvPLMSampleInfo.Rows(iCnt).Cells(SampleInfo.SAP_Created_Name.ToString).Value.ToString

                insertSql.AppendFormat("IF NOT EXISTS (SELECT 1 FROM m_Sample_t WHERE SampleNO = '{0}' )", SampleNo)
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", SampleNo)
                insertSql.AppendFormat("N'{0}',", CustID)
                insertSql.AppendFormat("N'{0}',", Deliverydate)
                insertSql.AppendFormat("N'{0}',", DevNo)
                insertSql.AppendFormat("N'{0}',", PartNo)
                insertSql.AppendFormat("N'{0}',", Qty)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}',", SysMessageClass.UseId)
                insertSql.AppendFormat("N'{0}',", "0")
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.profitcenter)
                insertSql.AppendFormat("N'{0}',", strRDUserName)
                insertSql.AppendFormat("N'{0}',", strPZUserName)
                insertSql.AppendFormat("N'{0}',", strSGUserName)
                insertSql.AppendFormat("N'{0}'", strYWUserName)
                insertSql.Append(");")
            Next
            '保存数据，有事务处理
            DbOperateUtils.ExecSQL(insertSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "SavePLMData", "Sample")
        End Try
    End Sub

    Private Function TransferDBSpecChar(target As String) As String
        TransferDBSpecChar = target.Replace("'", "''")
    End Function

#End Region

    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        Dim strQueryRDNamelist As String = ""
        Try
            If buttonStatus = EnumStatus.DownLoad Then
                If PLMDownLoadData() Then
                    toolSave.Enabled = True
                Else
                    toolSave.Enabled = False
                End If
            Else
                If buttonStatus <> EnumStatus.Search Then
                    SearchRecord("")
                    SetValueToControl()
                    Exit Sub
                End If

                Dim SqlStr As New StringBuilder

                If Me.CobCust.Text <> "" Then
                    SqlStr.Append(" AND a.Custid = '" & Mid(Trim(Me.CobCust.Text), 1, InStr(Trim(Me.CobCust.Text), "--") - 1) & "'")
                End If

                If Me.txtSampleNo.Text <> "" Then
                    SqlStr.Append(" AND a.SampleNO LIKE '" & Trim(Me.txtSampleNo.Text) & "%'")
                End If

                If Me.txtPartNo.Text <> "" Then
                    SqlStr.Append(" AND a.PartNo LIKE '" & Trim(Me.txtPartNo.Text) & "%'")
                End If

                If Me.txtDevNo.Text <> "" Then
                    SqlStr.Append(" AND a.DevNo LIKE '" & Trim(Me.txtDevNo.Text) & "%'")
                End If

                If Me.txtRDUserName.Text <> "" Then
                    Select Case m_strDutyDeptName
                        Case SampleCom.EnumSampleDept.研发.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.RDUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.RDUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.样品室.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.YPSUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.YPSUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.生管.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.SGUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.SGUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.设备.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.EquUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.EquUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.治具.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.ZJUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.ZJUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.业务.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.YWUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.YWUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case SampleCom.EnumSampleDept.PIE.ToString
                            If Me.txtRDUserName.Text.Split(",").Length > 1 Then
                                strQueryRDNamelist = GetQueryRDNamelist(Me.txtRDUserName.Text.Trim)
                                SqlStr.Append(" AND a.PIEUserName IN (" & strQueryRDNamelist & ") ")
                            Else
                                SqlStr.Append(" AND a.PIEUserName LIKE N'" & Trim(Me.txtRDUserName.Text) & "%'")
                            End If
                        Case Else
                            'do nothing
                    End Select
                End If

                If Me.cboQueryStatus.Text <> "" Then
                    SqlStr.Append(" AND a.Status = '" & Trim(Me.cboQueryStatus.SelectedValue.ToString) & "'")
                Else
                    SqlStr.Append(" AND a.Status = '0'")
                End If

                'If Me.dtDeliveryDate.Checked Then
                '    SqlStr = SqlStr + " AND a.deliveryDate = '" & dtDeliveryDate.Value.ToShortDateString & "'"
                'End If

                If chkRequsteTime.Checked = True Then
                    SqlStr.AppendFormat(" and CONVERT(NVARCHAR(10), A.DeliveryDate ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
                    SqlStr.AppendFormat(" and CONVERT(NVARCHAR(10), A.DeliveryDate ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)
                End If

                SearchRecord(SqlStr.ToString)
                toolEdit.Enabled = True
                Delete.Enabled = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "ToolRefresh_Click", "Sample")
        End Try
    End Sub

    Private Function GetQueryRDNamelist(ByVal strRDNameList As String) As String
        '  Dim strRDNameList As String = "陈山,陈琦,鲁红兵"
        strRDNameList = strRDNameList.Replace(",", "',N'")
        strRDNameList = "N'" + strRDNameList + "'"
        GetQueryRDNamelist = strRDNameList
    End Function

    Sub SetValueToControl()
        If TabControl1.SelectedIndex = 0 Then
            SetValueToControl(dgvSampleReqNo)
        ElseIf TabControl1.SelectedIndex = 1 Then
            ' SetValueToControl(DgPartContrast2)
        End If
    End Sub

    Private Sub SetValueToControl(dgGrid As DataGridView)
        If dgGrid.RowCount < 1 OrElse dgGrid.CurrentRow.Index < 0 Then Exit Sub
        Me.CobCust.SelectedIndex = -1
        Select Case dgGrid.Name
            Case "dgvSampleReqNo"
                Me.txtSampleNo.Text = dgGrid.Item(enumdgvSample.SampleNo, dgGrid.CurrentRow.Index).Value.ToString
                Me.CobCust.SelectedIndex = Me.CobCust.FindString(dgGrid.Item(enumdgvSample.CustID, dgGrid.CurrentRow.Index).Value.Split("--")(0))
                Me.dtDeliveryDate.Text = dgGrid.Item(enumdgvSample.DeliveryDate, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtDevNo.Text = dgGrid.Item(enumdgvSample.DevNo, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtPartNo.Text = dgGrid.Item(enumdgvSample.PartNo, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtQty.Text = dgGrid.Item(enumdgvSample.Qty, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtMadeQty.Text = dgGrid.Item(enumdgvSample.MadeQty, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtFormatDes.Text = dgGrid.Item(enumdgvSample.FormatDes, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtEBOMPN.Text = dgGrid.Item(enumdgvSample.EBOMPartNo, dgGrid.CurrentRow.Index).Value.ToString
            Case Else
                Me.txtSampleNo.Text = dgGrid.Item(0, dgGrid.CurrentRow.Index).Value.ToString
                Me.dtDeliveryDate.Text = dgGrid.Item(2, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtDevNo.Text = dgGrid.Item(3, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtPartNo.Text = dgGrid.Item(4, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtQty.Text = dgGrid.Item(5, dgGrid.CurrentRow.Index).Value.ToString
                Me.txtFormatDes.Text = dgGrid.Item(9, dgGrid.CurrentRow.Index).Value.ToString
        End Select

        'SampleNo,CustID,DeliveryDate,DevNo,PartNo,Qty,Intime,UserID,Status
    End Sub

    Private Function PLMDownLoadData() As Boolean
        Dim o_strCustID As String = "", o_strRDUserName As String = ""
        Dim o_strPLMFactoryID As String = String.Empty
        Dim strPICUserNotReadyList As String = String.Empty
        PLMDownLoadData = True

        Try
            If Me.CobCust.Text.Trim = String.Empty Then
                lblMsg.Text = "请先选择客户..."
                CobCust.Focus()
                Exit Function
            Else
                o_strCustID = Me.CobCust.SelectedItem.ToString.Split("--")(0)
            End If

            If String.IsNullOrEmpty(Me.txtRDUserName.Text) Then
                lblMsg.Text = "请先选择研发姓名..."
                txtRDUserName.Focus()
                Exit Function
            Else
                o_strRDUserName = Me.txtRDUserName.Text.Trim
            End If

            'strPICUserNotReadyList = GetPICUserNotReadyList(o_strCustID)
            'If Not String.IsNullOrEmpty(strPICUserNotReadyList) Then
            '    lblMsg.Text = "请先维护该客户的如下部门的责任人！！" + strPICUserNotReadyList
            '    Exit Function
            'Else
            '    'bypass check
            'End If

            Dim plmWS As New com.luxshare_ict.plm.WebService1
            Dim dt As DataTable = plmWS.GetPLMSAP(m_strPLMFactoryID, m_strPLMProfitcenter, o_strCustID, "In Review", o_strRDUserName)
            If dt.Rows.Count = 0 Then
                lblMsg.Text = "PLM中找不到该客户的样品申请单信息..."
                toolSave.Enabled = False
                Exit Function
            Else
                dgvPLMSampleInfo.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
                lblMsg.Text = "该料件在PLM中的数据如下表所示..."
                toolSave.Enabled = True
                SetDataGridViewStyle()
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageUtils.ShowError(ex.Message)
        End Try
    End Function

    'Private Function GetPICUserNotReadyList(ByVal strCustID As String) As String
    '    Dim lsSQL As String = String.Empty
    '    GetPICUserNotReadyList = ""

    '    lsSQL = " SELECT ISNULL(a.DutyDept,'')DutyDept, b.DutyUserID FROM m_SampleDept_t a " & _
    '            " LEFT JOIN m_SampleCustPic_t  b ON a.DutyDept = b.DutyDeptName AND A.USEY ='Y'" & _
    '            " WHERE 1=1 AND isnull(b.CustID, '" & strCustID & "') = '" & strCustID & "' AND ISNULL(b.DutyUserID,'')='' "

    '    Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
    '        If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In o_dt.Rows
    '                GetPICUserNotReadyList = GetPICUserNotReadyList + IIf(GetPICUserNotReadyList = String.Empty, "", ",") + CStr(dr.Item(0))
    '            Next
    '        Else
    '            GetPICUserNotReadyList = ""
    '        End If
    '    End Using
    'End Function

    Private Sub FrmSampleReqNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lsSQL As String = ""
        Try
            lsSQL = " SELECT CUSID,CUSNAME FROM m_Customer_t WHERE usey='Y' " 'Modify by cq20151231
            FillGridCombox(Me.CobCust, lsSQL)
            buttonStatus = EnumStatus.UnDo
            SearchRecord("")
            SetValueToControl()
            SetControlStates()

            If Me.DesignMode = False Then
                Call InitLoad()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "FrmSampleReqNo_Load", "Sample")
        End Try
    End Sub

    Private Sub InitLoad()
        '状态
        SampleCom.BindComboxStatus(cboQueryStatus)
        '样品流程跟踪明细(绿色：已完成,黄色：进行中，红色：超预计交期)
        ' TabPage3.Text = "<html>样品流程跟踪明细(" + "<font color='#FFFFFF'>" + "绿色 : 已完成" + "</font>" + "+456</html>"
        ToolDownLoad.Enabled = SampleCom.IsRDUserID(VbCommClass.VbCommClass.UseId)

    End Sub

#Region "查找GridComBox"
    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader(0).ToString & "--" & ScanReader(1).ToString)
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

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        buttonStatus = EnumStatus.Search
        SetButtonEnable(False)
        toolSave.Enabled = False
        Me.ToolRefresh.Enabled = True
        txtSampleNo.Enabled = True
        Me.txtSampleNo.Text = ""
        txtPartNo.Enabled = True
        Me.txtPartNo.Text = ""
        Me.txtDevNo.Enabled = True
        Me.txtDevNo.Text = ""
        Me.txtRDUserName.Enabled = True
        Me.txtRDUserName.Text = ""
        Me.cboQueryStatus.Enabled = True
        CobCust.Enabled = True
        Me.cboQueryStatus.Text = ""
        ClearControl()
        Me.dtDeliveryDate.Checked = False
        Me.txtQty.Text = ""
        Me.txtFormatDes.Text = ""
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If dgvSampleReqNo.RowCount < 1 OrElse Me.dgvSampleReqNo.CurrentRow.Index = -1 Then Exit Sub
        buttonStatus = EnumStatus.Edit
        EditRecord()
        SetValueToControl()
        Me.txtSampleNo.Enabled = False
        Me.txtDevNo.Enabled = False
        TabControl1.Enabled = False
        Me.txtFormatDes.Enabled = True
        Me.txtQty.Enabled = False
        Me.txtMadeQty.Enabled = True
        Me.txtEBOMPN.Enabled = True
        If TabControl1.SelectedIndex = 0 Then
            ' do nothing
        ElseIf TabControl1.SelectedIndex = 1 Then
            SetBomEnable()
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress, txtMadeQty.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtQty.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtQty.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub

#Region "编辑记录"
    Private Sub EditRecord()
        ChgRecord(0)
        SetControlStates()
    End Sub

#End Region

#Region "样品单结案"
    Private Sub toolClose_Click(sender As Object, e As EventArgs) Handles toolClose.Click
        Dim lsSQL As String = ""
        If dgvSampleReqNo.Rows.Count < 1 Then Exit Sub
        If dgvSampleReqNo.CurrentRow.Cells(0).Value.ToString = "" Then Exit Sub
        ' If MessageBox.Show("你是否对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        lsSQL = " UPDATE m_Sample_t SET  Status='1'," & _
                " CloseUserID='" & SysMessageClass.UseId & "'" & _
                " WHERE SampleNO='" & dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString & "'"
        DbOperateUtils.ExecSQL(lsSQL)
        MessageUtils.ShowInformation("已成功结案...")
    End Sub
#End Region

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        Dim lsSQL As String = ""
        If dgvSampleReqNo.Rows.Count < 1 Then Exit Sub
        If dgvSampleReqNo.CurrentRow.Cells(0).Value.ToString = "" Then Exit Sub
        lsSQL = " UPDATE m_Sample_t SET  Status='" & SampleCom.enumSampleStatus.Make & "'," & _
                " CloseUserID='" & SysMessageClass.UseId & "'" & _
                " WHERE SampleNO='" & dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.SampleNo).Value.ToString & "'"
        DbOperateUtils.ExecSQL(lsSQL)
        MessageUtils.ShowInformation("已成功取消结案...")
    End Sub

    Private Sub dgvSampleReqNo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSampleReqNo.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            ' Me.dgvSample.Columns(0).ReadOnly = False
            LoadSampleDetail(e.RowIndex)

            LoadSampleDocument(e.RowIndex)

            Me.txtSampleNo.Text = Me.dgvSampleReqNo.Rows(e.RowIndex).Cells(enumdgvSample.SampleNo).Value.ToString

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "dgvSample_CellClick", "Sample")
            ' MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadSampleDetail(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim SampleNo As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvSampleReqNo.Rows.Count = 0 Then
                Exit Sub
            End If
            ' LevelID Status DutyUserID,StartTime EndTime
            strSQL = " SELECT   (Cast(a.LevelID as varchar) + '.' + b.levelName) Levelid  , " & _
                " CASE a.FinishFlag WHEN 0 THEN N'0.进行中' WHEN 1 THEN N'1.已完成' ELSE  N'0.进行中' END STATUS , d.DutyUserName as PICUserID, a.PlanDueDate" & _
                " ,StartTime,Finishtime" & _
                " FROM m_SampleD_t a " & _
                " LEFT JOIN m_SampleLevel_t b ON a.levelid = b.levelid " & _
                " LEFT JOIN m_SamplePICD_t d ON d.sampleno=a.sampleno AND d.DeptName = b.DutyDept " & _
                " WHERE 1=1 "

            '0.编号, 1.
            If IsNothing(dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) OrElse IsDBNull(dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) Then
                Exit Sub
            Else
                SampleNo = dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value
            End If

            strWhere = String.Format(" AND a.SampleNo = '{0}'", SampleNo)
            Dim strOrder As String = " ORDER BY a.LEVELID "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvSampleD.DataSource = dt

            dgvSampleD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "LoadSampleDetail", "Sample")
        End Try
    End Sub

    Private Sub LoadSampleDocument(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim SampleNo As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvSampleReqNo.Rows.Count = 0 Then
                Exit Sub
            End If
            ' LevelID Status DutyUserID,StartTime EndTime
            strSQL = " SELECT SampleNO 样品单号,  type 文件类型, Path 路径 " & _
                              " FROM m_SampleDocument_t a  " & _
                              " WHERE 1 = 1 "

            '0.编号, 1.
            If IsNothing(dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) OrElse IsDBNull(dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value) Then
                Exit Sub
            Else
                SampleNo = dgvSampleReqNo.Rows(curRowIndex).Cells(enumdgvSample.SampleNo).Value
            End If

            strWhere = String.Format(" AND a.SampleNo = '{0}'", SampleNo)
            Dim strOrder As String = " ORDER BY a.sampleNo "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvDocument.DataSource = dt

            dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleReqNo", "LoadSampleDocument", "Sample")
        End Try
    End Sub

    Private Sub btnSelectRD_Click(sender As Object, e As EventArgs) Handles btnSelectRD.Click
        Dim frm As FrmRDList = New FrmRDList()

        frm.txtSelectedDept.Text = SampleCom.EnumSampleDept.研发.ToString

        Dim result As DialogResult = frm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            txtRDUserName.Text = frm.checkedLine
            m_strDutyDeptName = frm.m_strDept
        End If

    End Sub

    Private Sub ToolAddDutyName_Click(sender As Object, e As EventArgs) Handles ToolAddDutyName.Click

        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName
        Dim frm As FrmSampleDutyName = New FrmSampleDutyName

        frm.m_strSampleNO = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.SampleNo).Value)
        frm.m_strYWDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.YWUserName).Value)
        frm.m_strPZDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.PZUserName).Value)
        frm.m_strYPSDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.YPSUserName).Value)
        frm.m_strEquDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.EquUserName).Value)
        frm.m_strSGDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.SGUserName).Value)
        frm.m_strPIEDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.PIEUserName).Value)
        frm.m_strZEquDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.ZJUserName).Value)
        ' frm.m_strCCDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.CCUserName).Value)
        frm.m_strRDDutyName = DbOperateUtils.DBNullToStr(dgvSampleReqNo.CurrentRow.Cells(enumdgvSample.RDUserName).Value)
        Dim result As DialogResult = frm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            SearchRecord(" AND a.sampleno = '" & frm.m_strSampleNO & "'")
        End If
    End Sub

    Private Sub dgvSampleD_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvSampleD.RowPrePaint

        If e.RowIndex = -1 OrElse Me.dgvSampleD.Rows.Count <= 0 Then Exit Sub
        Dim strTempStatus As String = ""
        Dim o_tempPlanDueDate As String
        Try
            For rowIndex As Integer = 0 To Me.dgvSampleD.Rows.Count - 1
                strTempStatus = DbOperateUtils.DBNullToStr(dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.Status).Value)

                If Not String.IsNullOrEmpty(strTempStatus) Then
                    Select Case strTempStatus.Substring(0, 1)
                        Case "0"
                            o_tempPlanDueDate = DbOperateUtils.DBNullToStr(Me.dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.PlanDueDate).Value)
                            If DbOperateUtils.DBNullToStr(Me.dgvSampleD.Rows(rowIndex).Cells(enumdgvSampleD.PlanDueDate).Value) <> "" AndAlso DateTime.Compare(o_tempPlanDueDate, DateTime.Now.Date) <= 0 Then
                                dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Red
                            Else
                                dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        Case "1"
                            dgvSampleD.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case Else
                            'do nothing 
                    End Select
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        If e.RowIndex = -1 OrElse Me.dgvDocument.Rows.Count <= 0 Then Exit Sub
        Try
            System.Diagnostics.Process.Start(Me.dgvDocument.CurrentCell.Value.ToString)
        Catch ex As Exception
        End Try
    End Sub
End Class