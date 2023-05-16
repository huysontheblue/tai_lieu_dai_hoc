Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MainFrame
Imports System.IO

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' 修改者： 田玉琳
''' 修改日： 2015/12/30
''' 修改内容：增加TT下载类别
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipment

#Region "变量定义"

    Private dics As New List(Of KeyValue)
    Private m_blnNeedAutoInsert As Boolean = False

    Private Id As String

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Public Enum EquipmentType
        PA = 0
        MA
        MJ
        FX
        YPZJ
        PJ
        ATE
    End Enum

    Private Enum CDImportGrid
        EquipmentNO
        BigCategory
        MiddleCategory
        SmallCategory
        PartNumber
        ProcessParameters
        ServiceCount
        AlertCount
        RemainCount
        Storage
        UserID
    End Enum
    Private Enum CDImportGridPJ
        EquipmentNO
        BigCategory
        MiddleCategory
        SmallCategory
        PartNumber
        ProcessParameters
        ServiceCount
        AlertCount
        RemainCount
        Storage
        UserID
        SafeQty
    End Enum

    Private Enum EquipmentGrid
        checkbox = 0
        EquipmentNO
        SmallCategory
        PartNumber
        ProcessParameters
        UseMultiple
        ServiceCount
        AlertCount
        RemainCount
        Status
        Storage
        InOut
        pnlist
        LineID
        OutUserID
        OutTime
        UserID
        Intime
        ModifyTime
        FactoryID
        ProfitCenter
        Remark
        ID
        SafeQty
        NextMonthKeep
        NextSeasonKeep
        '状态，储位， 在库状态，借出线别， 借出人，借出时间，创建人，创建时间，厂区，利润中心,
    End Enum

    Private Enum NewEquipmentGrid
        checkbox = 0
        EquipmentNO
        SmallCategory
        PartNumber
        ProcessParameters
        UseMultiple
        ServiceCount
        AlertCount
        RemainCount
        Status
        Storage
        InOut
        pnlist
        LineID
        OutUserID
        OutTime
        UserID
        Intime
        ModifyTime
        FactoryID
        ProfitCenter
        Remark
        ID
        '状态，储位， 在库状态，借出线别， 借出人，借出时间，创建人，创建时间，厂区，利润中心,REMARK, ID
    End Enum

    Public m_iSafeQtyOld As Double = -1 'Int16

#End Region

#Region "初期化"

    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Me.DesignMode = False Then
                LabelPrintHelper.InitPrinter(cboPrinter)
                '设定用戶權限
                Dim ERigth As New SysDataBaseClass
                ERigth.GetControlright(Me)
                '
                ERigth.GetContextMenuRight(Me, Me.ContextMenuStrip1)
                '设置当前操作模式
                Me.OperateFlag = EditMode.UNDO
                '绑定设备分类
                EquManageCommon.BindComboxCategory(cboBigCategory, "BIG")
                EquManageCommon.BindComboxCategory(cboMiddleCategory, "MID")

                '设置工具栏按钮状态
                SetControlStatus(Me.OperateFlag)
                '设置面板组控件状态
                ToogleGroupBox(0)
                cboMiddleCategory.SelectedIndex = TabEquipment.SelectedIndex + 1
                '绑定数据
                'add by 马跃平 2018-04-02 新增页签权限管控
                Dim tabPageIsEnable As Boolean = False '记录当前用户是否有所有页签的权限
                For yy = 0 To TabEquipment.TabCount - 1
                    Dim tp As TabPage = TabEquipment.TabPages(yy)
                    Dim sql As String = "select * FROM m_UserRight_t" & vbCrLf &
                    "where UserID='" + VbCommClass.VbCommClass.UseId + "' and Tkey='" + tp.Name + "'"
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
                    If dt.Rows.Count > 0 Then
                        tabPageIsEnable = True
                        TabEquipment.SelectedIndex = yy
                        Exit For
                    End If
                Next
                TabEquipment.Enabled = tabPageIsEnable
            End If
            TabEquipment_SelectedIndexChanged(Nothing, Nothing)
            'LoadEquipment()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

#End Region

#Region "设置工具栏控件状态"
    Private Sub SetControlStatus(ByVal flag As EditMode)
        SetButtonEnable(False)
        Select Case UCase(flag)
            Case EditMode.ADD '新增
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.UNDO '初始化
                Me.toolNew.Enabled = IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False)
                Me.toolModify.Enabled = IIf(DbOperateUtils.DBNullToStr(toolModify.Tag) = "YES", True, False)
                Me.tsmiCopyRecord.Enabled = IIf(DbOperateUtils.DBNullToStr(tsmiCopyRecord.Tag) = "YES", True, False)
                Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)
                toolPrint.Enabled = True
                toolImport.Enabled = True
                toolExport.Enabled = True
                toolSearch.Enabled = True
                TabEquipment.Enabled = True
            Case EditMode.SEARCH '搜索
                TabEquipment.Enabled = True
                Me.tsmiCopyRecord.Enabled = False
                toolUndo.Enabled = True
                toolSearch.Enabled = True
                toolRefresh.Enabled = True
                toolExport.Enabled = True
        End Select
    End Sub
    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
        toolPrint.Enabled = bFlag
        toolImport.Enabled = bFlag
        toolExport.Enabled = bFlag
        TabEquipment.Enabled = bFlag
    End Sub
#End Region

#Region "检查输入"
    Private Function CheckInput() As Boolean
        Dim txtBox As Control
        Dim strSql As String
        Try
            'check text
            For Each txtBox In Me.GroupBox1.Controls
                If TypeOf txtBox Is System.Windows.Forms.TextBox Then
                    If String.IsNullOrEmpty(txtBox.Text) AndAlso Not txtBox.Tag Is Nothing Then
                        MessageUtils.ShowError(txtBox.Tag.ToString() & ":不能为空!")
                        txtBox.Focus()
                        Return False
                    End If
                End If
            Next
            'check partnumber

            'Modify by cq20170725
            strSql = "SELECT TAvcPart FROM m_PartContrast_t(nolock) WHERE TAvcPart=N'" & Me.txtEquipmentPN.Text.Trim & "' AND type ='E' AND (UseY='Y' OR  UseY='1')"
            '
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

            If (dt.Rows.Count = 0) Then
                'MessageUtils.ShowError("设备料号:" & Me.txtEquipmentPN.Text.Trim & "不存在或者无效,请检查料件编号")
                'txtEquipmentPN.Focus()
                'Return False
                m_blnNeedAutoInsert = True
            End If

            Dim ServiceCount As Integer = CInt(Me.txtServiceCount.Text.Trim)
            Dim AlertCount As Integer = CInt(Me.txtAlertCount.Text.Trim)
            Dim RemainCount As Integer = CInt(Me.txtRemainCount.Text.Trim)

            If ServiceCount = 0 Then
                MessageUtils.ShowError("使用次数不可为0")
                Return False
            End If

            If AlertCount > ServiceCount Then
                MessageUtils.ShowError("预警次数不可大于使用次数")
                Return False
            End If
            If RemainCount > ServiceCount Then
                MessageUtils.ShowError("剩余次数不可大于使用次数")
                Return False
            End If
            '
            If Me.cboSmallCategory.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择设备类别")
                Return False
            End If
            If Me.cboInOut.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return True

    End Function
#End Region

#Region "保存数据"
    Private Function SaveData() As Boolean
        Dim strSql As String = ""
        Dim o_strExcelSQLResult As String = ""
        Try
            Dim PPartId As String = Me.txtPartid.Text.Trim
            Dim EquipmentNo As String = Me.txtEquipmentNo.Text.Trim
            Dim SafeQty As String = Me.TextBoxkc.Text.Trim
            Dim CategoryID As Integer = Val(Me.cboSmallCategory.SelectedValue.ToString)  'cq 20170616,CInt(Me.cboSmallCategory.SelectedValue.ToString)
            Dim PartNumber As String = txtEquipmentPN.Text.Trim
            Dim ProcessParameters As String = Me.txtProcessParameters.Text.Trim
            Dim ServiceCount As Integer = CInt(Me.txtServiceCount.Text.Trim)
            Dim AlertCount As Integer = CInt(Me.txtAlertCount.Text.Trim)
            Dim RemainCount As Integer = CInt(Me.txtRemainCount.Text.Trim)
            Dim Status As Integer
            Dim NextMonthKeep = dtpNextMonthKeep.Text.Trim()
            Dim NextSeasonKeep = dtpNextSeasonKeep.Text.Trim()
            Select Case cboStatus.SelectedIndex
                Case 2
                    Status = 1
                Case 3
                    Status = 2
                Case Else
                    Status = 0
            End Select
            Dim InOut As Integer = Convert.ToInt16(cboInOut.SelectedItem.ToString().Substring(0, 1))
            Dim Storage As String = Me.txtStorage.Text.Trim
            Dim line As String = Me.txtLine.Text.Trim
            Dim bigCategory As String = cboBigCategory.SelectedValue.ToString
            Dim midCategory As String = cboMiddleCategory.SelectedValue.ToString
            Dim smallCategory As String = cboSmallCategory.SelectedValue.ToString

            'add by 马跃平 2018-05-15
            Dim midCategoryText = cboMiddleCategory.Text

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
            Dim strBSQL As New System.Text.StringBuilder

            '
            If OperateFlag = EditMode.ADD Then     '新增
                '设备编号是否存在
                strSql = "SELECT 1 FROM m_Equipment_t(nolock) where EquipmentNo=N'" & EquipmentNo & "'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("设备编号:" + EquipmentNo + " 已存在!")
                    Return False
                Else
                    If EquipmentNo = "" Then
                        EquipmentNo = EquipmentNoMAX(bigCategory, midCategory)
                    End If

                    strSql = " INSERT INTO m_Equipment_t(EquipmentNo,BigCategory,MiddleCategory,SmallCategory,ProcessParameters,ServiceCount,AlertCount,RemainCount," &
                             " Status,UserID,InTime,Storage,PartNumber,InOut,FactoryName,Profitcenter,SafeQty,LineID,PPartId)"

                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", EquipmentNo)
                    strBSQL.AppendFormat("N'{0}',", bigCategory)
                    strBSQL.AppendFormat("N'{0}',", midCategory)
                    strBSQL.AppendFormat("N'{0}',", smallCategory)
                    strBSQL.AppendFormat("N'{0}',", ProcessParameters)
                    strBSQL.AppendFormat("N'{0}',", ServiceCount)
                    strBSQL.AppendFormat("N'{0}',", AlertCount)
                    strBSQL.AppendFormat("N'{0}',", RemainCount)
                    strBSQL.AppendFormat("'{0}',", Status)
                    strBSQL.AppendFormat("N'{0}',", userId)
                    strBSQL.AppendFormat("getdate(),")
                    strBSQL.AppendFormat("N'{0}',", Storage)
                    strBSQL.AppendFormat("N'{0}',", PartNumber)
                    strBSQL.AppendFormat("{0},", InOut)
                    strBSQL.AppendFormat("N'{0}',", FactoryName)
                    strBSQL.AppendFormat("N'{0}',", Profitcenter)
                    strBSQL.AppendFormat("N'{0}',", SafeQty)
                    strBSQL.AppendFormat("N'{0}',", line)
                    strBSQL.AppendFormat("N'{0}'", PPartId)
                    strBSQL.Append(");")

                    strSql = "INSERT INTO m_EquPartLink_t (EquNo,PartID) "
                    strBSQL.Append(strSql)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", EquipmentNo)
                    strBSQL.AppendFormat("N'{0}'", PPartId)
                    strBSQL.Append(");")
                    'Add by cq 20170802
                    If m_blnNeedAutoInsert Then
                        strBSQL.Append(" INSERT INTO dbo.m_PartContrast_t ")
                        strBSQL.Append("  (TAvcPart ,PartName, PAvcPart,CusID,")
                        strBSQL.Append("  CustPart,MethodID,UseY, LmtY,")
                        strBSQL.Append(" WarnDate,userId,Intime,TypeDest,")
                        strBSQL.Append(" PartCode,Supplierid,IsUpload,Isasseble,")
                        strBSQL.Append(" IsLotScan,IsAlter, MaterialAlter,IsPrintFile,")
                        strBSQL.Append("  IsTransOracle,IsChkTransData,AmountQty, DESCRIPTION,")
                        strBSQL.Append(" SubstituteFlag,IngredientsPart,SubstituteNumber,IsReplace,")
                        strBSQL.Append(" Extensible, EffectiveDate, ExpirationDate,Version,")
                        strBSQL.Append(" Type, MARK,EcnChange,SeriesID,")
                        strBSQL.Append(" EquipmentType, PartSeriesType, PlanType)")
                        strBSQL.Append("VALUES  ( N'" & PartNumber & "',  N'',  N'" & PartNumber & "',  N'',")
                        strBSQL.Append(" N'', N'',N'Y' ,365 ,")
                        strBSQL.Append(" 7 , '" & VbCommClass.VbCommClass.UseId & "' ,getdate() ,  N'" & midCategoryText & "' ,")  '7	C025428	2017-05-09 16:26:40.320	NULL	--WarnDate
                        strBSQL.Append("   N'', N'', N'', N'', ")  'NULL	NULL	N	N --PartCode 	
                        strBSQL.Append(" N'' , N'' , N'' ,  N'' ,") 'N	N	N	NULL --IsLotScan  
                        strBSQL.Append(" N'' ,  N'' , NULL , N'" & ProcessParameters & "' ,") 'NULL	N	NULL	NULL   --IsTransOracle
                        strBSQL.Append(" '' , '', 0 , '' , ")    'NULL	NULL	0	N	--SubstituteFlag
                        strBSQL.Append("  '' , null ,  null , '' ,")  'NULL	NULL	NULL	NULL --Extensible	
                        strBSQL.Append("   'E' , '' , '' ,  '018' ,") 'E	NULL	NULL	018  --Type, MARK,EcnChange,SeriesID
                        strBSQL.Append("  '' ,  N'' ,N'')") '--EquipmentType, PartSeriesType, PlanType

                    End If
                End If
            Else    '修改
                strSql = "UPDATE m_Equipment_t "

                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" set EquipmentNo='{0}',", EquipmentNo)
                strBSQL.AppendFormat("  BigCategory = N'{0}', ", bigCategory)
                strBSQL.AppendFormat(" MiddleCategory = N'{0}', ", midCategory)
                strBSQL.AppendFormat(" SmallCategory = N'{0}', ", smallCategory)
                strBSQL.AppendFormat(" PartNumber = N'{0}' ,", PartNumber)
                strBSQL.AppendFormat(" ProcessParameters = N'{0}' ,", ProcessParameters)
                strBSQL.AppendFormat(" Status = '{0}',", Status)
                strBSQL.AppendFormat(" InOut = '{0}',", InOut)
                strBSQL.AppendFormat(" ServiceCount = N'{0}', ", ServiceCount)
                strBSQL.AppendFormat(" AlertCount = N'{0}', ", AlertCount)
                strBSQL.AppendFormat(" RemainCount = N'{0}', ", RemainCount)
                strBSQL.AppendFormat(" Storage = N'{0}', ", Storage)
                strBSQL.AppendFormat(" ModifyUserID = N'{0}', ", userId)
                strBSQL.AppendFormat(" ModifyTime=getdate() ,")
                strBSQL.AppendFormat(" SafeQty=N'{0}',", SafeQty)   '
                strBSQL.AppendFormat(" Lineid=N'{0}',", line)
                strBSQL.AppendFormat(" PPartId=N'{0}',", Ppartid)

                strBSQL.AppendLine(" UseMultiple='" & IIf(String.IsNullOrEmpty(txtUseMultiple.Text.Trim()), "1", txtUseMultiple.Text) & "',")
                If String.IsNullOrEmpty(NextMonthKeep) = False Then
                    strBSQL.AppendFormat(" NextMonthKeep='{0}',", NextMonthKeep)
                Else
                    strBSQL.Append(" NextMonthKeep=null,")
                End If
                If String.IsNullOrEmpty(NextSeasonKeep) = False Then
                    strBSQL.AppendFormat(" NextSeasonKeep='{0}'", NextSeasonKeep)
                Else
                    strBSQL.Append(" NextSeasonKeep=null ")
                End If

                strBSQL.AppendFormat(" WHERE ID = {0}", Val(Me.Id))

                'Add by cq 20180709
                If m_iSafeQtyOld <> Val(SafeQty) Then
                    strBSQL.Append(" UPDATE m_Equipment_t  SET SafeQty ='" & SafeQty & "' WHERE PartNumber = '" & PartNumber & "' " & EquManageCommon.GetFatoryProfitcenter())
                End If

            End If
            '执行SQL
            DbOperateUtils.ExecSQL(strBSQL.ToString)
            '*************************************************田玉琳 20171106 开始*************************************************
            EquManageCommon.ExecCNCUpdate(txtEquipmentNo.Text.Trim)
            '*************************************************田玉琳 20171106 结束*************************************************
            Return True
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                Me.txtEquipmentNo.Enabled = False
                Me.txtEquipmentPN.Enabled = False
                Me.txtProcessParameters.Enabled = False
                Me.txtRemainCount.Enabled = False
                Me.txtServiceCount.Enabled = False
                Me.txtAlertCount.Enabled = False
                Me.cboStatus.Enabled = False
                ' Me.cboInOut.Enabled = False
                Me.cboBigCategory.Enabled = False
                Me.cboMiddleCategory.Enabled = False
                Me.cboSmallCategory.Enabled = False
                Me.txtStorage.Enabled = False
                '  Me.txtLine.Enabled = False
                Me.cboPrinter.Enabled = True
                Me.TextBoxkc.Enabled = False
                Me.txtUseMultiple.Enabled = False
                Me.dtpNextMonthKeep.Enabled = False
                Me.dtpNextSeasonKeep.Enabled = False
            Case 1
                Me.txtEquipmentNo.Enabled = True
                Me.txtEquipmentPN.Enabled = True
                Me.txtProcessParameters.Enabled = True
                Me.txtRemainCount.Enabled = True
                Me.txtServiceCount.Enabled = True
                Me.txtAlertCount.Enabled = True
                Me.cboStatus.Enabled = True
                Me.cboInOut.Enabled = True
                Me.cboBigCategory.Enabled = True
                Me.cboMiddleCategory.Enabled = True
                Me.cboSmallCategory.Enabled = True
                Me.txtStorage.Enabled = True
                Me.txtLine.Enabled = True
                Me.TextBoxkc.Enabled = True
                Me.txtUseMultiple.Enabled = True
                Me.dtpNextMonthKeep.Enabled = True
                Me.dtpNextSeasonKeep.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.Id = ""
        Me.txtEquipmentNo.Text = ""
        Me.txtEquipmentPN.Text = ""
        Me.txtProcessParameters.Text = ""
        Me.txtRemainCount.Text = ""
        Me.txtServiceCount.Text = ""
        Me.txtAlertCount.Text = ""
        Me.txtStorage.Text = ""
        Me.cboBigCategory.SelectedIndex = 0
        Me.cboMiddleCategory.SelectedIndex = 0
        Me.cboSmallCategory.SelectedIndex = 0
        Me.cboStatus.SelectedIndex = 0
        Me.cboInOut.SelectedIndex = 0
        Me.txtLine.Text = ""
        Me.TextBoxkc.Text = ""
        Me.txtUseMultiple.Text = ""
        Me.txtOutUserID.Text = ""
    End Sub
#End Region

#Region "给 GroupBox 面板控件赋值"
    Private Sub SetGroupBox()
        Dim index As Integer = TabEquipment.SelectedIndex
        If index = 0 Then
            SetControlValue(dgvPA)
        ElseIf index = 1 Then
            SetControlValue(dgvMA)
        ElseIf index = 2 Then
            SetControlValue(dgvMJ)
        ElseIf index = 3 Then
            SetControlValue(dgvFX)
        ElseIf index = 4 Then
            SetControlValue(dgvYPZJ)
        ElseIf index = 5 Then
            SetControlValue(dgvPJ)
        ElseIf index = 6 Then
            SetControlValue(dgvATE)
        Else
            SetControlValue(dgvMJ)
        End If
    End Sub

    Private Sub SetControlValue(dgGrid As DataGridView)

        If dgGrid.RowCount < 1 Then Exit Sub
        ''当前行没有时把第一行默认选中
        If dgGrid.Item(EquipmentGrid.ID, dgGrid.CurrentRow.Index).Value IsNot Nothing Then
            Me.Id = dgGrid.Item(NewEquipmentGrid.ID, dgGrid.CurrentRow.Index).Value.ToString()  'EquipmentGrid
        Else
            Me.Id = dgGrid.Item(EquipmentGrid.checkbox, dgGrid.CurrentRow.Index).Value.ToString()
        End If
        Dim bigCategory As String = ""
        Dim middleCategory As String = ""
        Dim smallCategory As String = ""
        Dim dt As DataTable = GetCategoryData(Me.Id)
        If dt.Rows.Count > 0 Then
            bigCategory = dt.Rows(0)(0).ToString
            middleCategory = dt.Rows(0)(1).ToString
            smallCategory = dt.Rows(0)(2).ToString
        End If

        Me.txtEquipmentNo.Text = dgGrid.Item(EquipmentGrid.EquipmentNO, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtEquipmentPN.Text = dgGrid.Item(EquipmentGrid.PartNumber, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtProcessParameters.Text = dgGrid.Item(EquipmentGrid.ProcessParameters, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtServiceCount.Text = dgGrid.Item(EquipmentGrid.ServiceCount, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtAlertCount.Text = dgGrid.Item(EquipmentGrid.AlertCount, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtRemainCount.Text = dgGrid.Item(EquipmentGrid.RemainCount, dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtStorage.Text = dgGrid.Item(EquipmentGrid.Storage, dgGrid.CurrentRow.Index).Value.ToString()
        Me.cboBigCategory.SelectedValue = bigCategory
        Me.cboMiddleCategory.SelectedValue = middleCategory
        Me.cboSmallCategory.SelectedValue = smallCategory
        Me.cboStatus.SelectedIndex = Me.cboStatus.FindString((dgGrid.Item(EquipmentGrid.Status, dgGrid.CurrentRow.Index).Value.ToString))
        Me.cboInOut.SelectedIndex = Me.cboInOut.FindString(dgGrid.Item(EquipmentGrid.InOut, dgGrid.CurrentRow.Index).Value.ToString)
        Me.txtLine.Text = dgGrid.Item(EquipmentGrid.LineID, dgGrid.CurrentRow.Index).Value.ToString()
        Me.TextBoxkc.Text = dgGrid.Item(EquipmentGrid.SafeQty, dgGrid.CurrentRow.Index).Value.ToString()
        m_iSafeQtyOld = Val(Me.TextBoxkc.Text)

        Dim NextMonthKeep = dgGrid.Item(EquipmentGrid.NextMonthKeep, dgGrid.CurrentRow.Index).Value

        Dim NextSeasonKeep = dgGrid.Item(EquipmentGrid.NextSeasonKeep, dgGrid.CurrentRow.Index).Value

        txtUseMultiple.Text = dgGrid.Item(EquipmentGrid.UseMultiple, dgGrid.CurrentRow.Index).Value.ToString()

        If IsDBNull(NextMonthKeep) = False Then
            dtpNextMonthKeep.CustomFormat = "yyyy-MM-dd"
            dtpNextMonthKeep.Text = NextMonthKeep
        Else
            dtpNextMonthKeep.CustomFormat = " "
        End If

        If IsDBNull(NextSeasonKeep) = False Then
            dtpNextSeasonKeep.CustomFormat = "yyyy-MM-dd"
            dtpNextSeasonKeep.Text = NextSeasonKeep
        Else
            dtpNextSeasonKeep.CustomFormat = " "
        End If
    End Sub
#End Region

#Region "工具条事件"

    '新增
    Private Sub toolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        Me.txtEquipmentNo.Focus()
        Me.cboStatus.SelectedIndex = 2 : Me.cboInOut.SelectedIndex = 2
        ' Me.txtLine.ReadOnly = True, mark by cq 20181015
        'Me.cboStatus.Enabled = False : Me.cboInOut.Enabled = False : Me.txtLine.ReadOnly = True : Me.cboPrinter.Enabled = False
        'add by 马跃平 2018-04-03 模具室张康提出需求
        If TabEquipment.SelectedTab.Name = "m131a8_" Then
            txtServiceCount.Text = "2000000"
            txtAlertCount.Text = "1900000"
            txtRemainCount.Text = "2000000"
        Else
            Me.txtServiceCount.Text = "200000"
            Me.txtAlertCount.Text = "200000"
            Me.txtRemainCount.Text = "200000"
        End If
        Me.txtUseMultiple.Text = 1
    End Sub
    '修改
    Private Sub toolModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
        '面板控件可写
        ToogleGroupBox(1)
        '面板控件赋值
        SetGroupBox()
        'Me.txtEquipmentNo.Enabled = False
        'mark cboInOut,txtLine cq 20181015
        ' Me.cboInOut.Enabled = False
        ' Me.txtLine.ReadOnly = True
        Me.cboPrinter.Enabled = False

        If String.IsNullOrEmpty(dtpNextSeasonKeep.Text.Trim()) = False Then
            dtpNextSeasonKeep.Enabled = False
        Else
            dtpNextSeasonKeep.Enabled = True
        End If
        If String.IsNullOrEmpty(dtpNextMonthKeep.Text.Trim()) = False Then
            dtpNextMonthKeep.Enabled = False
        Else
            dtpNextMonthKeep.Enabled = True
        End If
        txtRemainCount.Enabled = False
    End Sub
    '保存
    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Try
            Dim index As Integer = TabEquipment.SelectedIndex
            If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
                '检查输入
                If CheckInput() = False Then
                    Exit Sub
                End If
                '确认信息
                If MessageUtils.ShowConfirm("你确定保存吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                '保存
                If SaveData() = False Then Exit Sub

                MessageUtils.ShowInformation("保存成功")
                '清除面板控件值
                ClearGroupBox()

                ToogleGroupBox(0)
                '刷新
                cboMiddleCategory.SelectedIndex = TabEquipment.SelectedIndex + 1
                LoadEquipment()
                SetControlStatus(EditMode.UNDO)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnSave_Click", "sys")
        End Try
    End Sub
    '退出
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '查找 
    Private Sub toolSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        cboStatus.Enabled = True
        txtLine.Enabled = True
        txtLine.ReadOnly = False
        cboInOut.Enabled = True
        txtEquipmentNo.Enabled = True
        Me.txtEquipmentNo.ReadOnly = False
        Me.txtEquipmentNo.Focus()
        Me.txtAlertCount.Text = ""
        Me.txtServiceCount.Text = ""
    End Sub
    '刷新
    Private Sub toolRefreshClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            LoadEquipment()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "btnRefresh_Click", "sys")
        End Try
    End Sub
    '返回
    Private Sub toolUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
        '面板控件只读
        ToogleGroupBox(0)
        '
    End Sub
    '打印
    Private Sub toolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPrint.Click
        Dim msg As String = Nothing
        Dim fileName As String = Nothing
        Dim copies As Integer = 1
        Dim index As Integer = 1
        Dim prePage As Integer = 1
        Try
            dics.Clear()
            Dim printPath As String = VbCommClass.VbCommClass.PrintDataModle + "EquipmentTemplate\"

            Select Case TabEquipment.SelectedIndex
                '刀模标签/ '刀片标签
                Case 0
                    If chkPrint.Checked Then
                        For Each row As DataGridViewRow In dgvPA.Rows
                            If Not row.Cells(0).EditedFormattedValue Is Nothing AndAlso row.Cells(0).EditedFormattedValue.ToString = "True" Then
                                dics.Add(New KeyValue(copies, "EquipmentNo1", row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                                dics.Add(New KeyValue(copies, "Bin1", row.Cells(EquipmentGrid.Storage).Value.ToString))
                                dics.Add(New KeyValue(copies, "EquipmentName1", "标准部件名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                                dics.Add(New KeyValue(copies, "PartNumber1", row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                                index += 1
                                copies += 1
                            End If
                        Next
                        index -= 1
                        copies -= 1
                        fileName = printPath + "EquipmentPA.btw"
                    Else
                        For Each row As DataGridViewRow In dgvPA.Rows
                            If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                                dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                                dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                                dics.Add(New KeyValue(copies, "EquipmentName" + index.ToString, "标准部件名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                                dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                                index += 1
                            End If
                            If index = 4 Then
                                index = 1
                                copies += 1
                            End If
                        Next
                        prePage = 4
                        fileName = printPath + "EquipmentMA.btw"
                        copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                        If index <> 1 Then
                            For i As Integer = index To 3
                                dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                                dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                                dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                                '  dics.Add(New KeyValue(copies, "IPQC" + i.ToString, ""))
                                dics.Add(New KeyValue(copies, "EquipmentName" + i.ToString, ""))
                                dics.Add(New KeyValue(copies, "PartNumber" + i.ToString, ""))
                            Next
                        End If
                    End If
                Case 1  '辅助设备
                    For Each row As DataGridViewRow In dgvMA.Rows
                        If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                            dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                            dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                            dics.Add(New KeyValue(copies, "EquipmentName" + index.ToString, "机台设备名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                            dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                            index += 1
                        End If
                        If index = 4 Then
                            index = 1
                            copies += 1
                        End If
                    Next
                    prePage = 4
                    fileName = printPath + "EquipmentMA.btw"
                    copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                    If index <> 1 Then
                        For i As Integer = index To 3
                            dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                            '  dics.Add(New KeyValue(copies, "IPQC" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "EquipmentName" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "PartNumber" + i.ToString, ""))
                        Next
                    End If
                Case 2  '模具标签
                    For Each row As DataGridViewRow In dgvMJ.Rows
                        If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                            dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                            dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                            'dics.Add(New KeyValue("EquipmentName" + index.ToString, row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                            index += 1
                        End If
                        If index = 4 Then
                            index = 1
                            copies += 1
                        End If
                    Next
                    prePage = 2
                    fileName = printPath + "EquipmentMJ.btw"
                    copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                    If index <> 1 Then
                        For i As Integer = index To 3
                            dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                        Next
                    End If
                Case 3   '治具标签
                    For Each row As DataGridViewRow In dgvFX.Rows
                        If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                            dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                            dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                            dics.Add(New KeyValue(copies, "EquipmentName" + index.ToString, "治具名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                            dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                            index += 1
                        End If
                        If index = 4 Then
                            index = 1
                            copies += 1
                        End If
                    Next
                    prePage = 4
                    fileName = printPath + "EquipmentFX.btw"
                    copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                    If index <> 1 Then
                        For i As Integer = index To 3
                            dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "EquipmentName" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "PartNumber" + i.ToString, ""))
                        Next
                    End If
                Case 5

                    For Each row As DataGridViewRow In dgvPJ.Rows
                        If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                            dics.Add(New KeyValue(copies, "EquipmentNo" + index.ToString, row.Cells(EquipmentGrid.EquipmentNO).Value.ToString))
                            dics.Add(New KeyValue(copies, "Bin" + index.ToString, row.Cells(EquipmentGrid.Storage).Value.ToString))
                            dics.Add(New KeyValue(copies, "EquipmentName" + index.ToString, "配件名称:" & row.Cells(EquipmentGrid.ProcessParameters).Value.ToString))
                            dics.Add(New KeyValue(copies, "PartNumber" + index.ToString, row.Cells(EquipmentGrid.PartNumber).Value.ToString))
                            index += 1
                        End If
                        If index = 4 Then
                            index = 1
                            copies += 1
                        End If
                    Next
                    prePage = 4
                    fileName = printPath + "EquipmentPJ.btw"
                    copies = System.Math.Ceiling(dics.Count / (prePage * 3))
                    If index <> 1 Then
                        For i As Integer = index To 3
                            dics.Add(New KeyValue(copies, "EquipmentNo" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "Bin" + i.ToString, ""))
                            'dics.Add(New KeyValue(copies, "BinT" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "EquipmentName" + i.ToString, ""))
                            dics.Add(New KeyValue(copies, "PartNumber" + i.ToString, ""))
                        Next
                    End If


            End Select
            If Not BasicCheck() Then
                Exit Sub
            End If
            If LabelPrintHelper.PrintLabel(dics, cboPrinter.Text, msg, fileName, prePage, copies) Then
                MessageUtils.ShowInformation("打印成功")
            Else
                MessageUtils.ShowError(msg)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "toolPrint_Click", "sys")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    '撤销
    Private Sub toolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDelete.Click

        Dim sql As String = String.Empty
        Select Case TabEquipment.SelectedIndex
            Case 0
                If CheckStatus(dgvPA) = False Then Exit Sub
                sql = GetDeleteSQL(dgvPA)
            Case 1
                If CheckStatus(dgvMA) = False Then Exit Sub
                sql = GetDeleteSQL(dgvMA)
            Case 2
                If CheckStatus(dgvMJ) = False Then Exit Sub
                sql = GetDeleteSQL(dgvMJ)
            Case 3
                If CheckStatus(dgvFX) = False Then Exit Sub
                sql = GetDeleteSQL(dgvFX)
            Case 4
                If CheckStatus(dgvYPZJ) = False Then Exit Sub
                sql = GetDeleteSQL(dgvYPZJ)
            Case 5  '消耗性配件, cq 20180124
                If CheckStatus(dgvPJ) = False Then Exit Sub
                sql = GetDeleteSQL(dgvPJ)
        End Select
        If String.IsNullOrEmpty(sql) Then
            MessageUtils.ShowError("请选择要删除的设备!")
            Exit Sub
        End If
        Try
            If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                DbOperateUtils.ExecSQL(sql)
                '*************************************************田玉琳 20171213 开始*************************************************
                EquManageCommon.ExecCNCUpdate(txtEquipmentNo.Text.Trim)
                '*************************************************田玉琳 20171213 结束*************************************************
                MessageUtils.ShowInformation("删除成功")
                LoadEquipment()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    '导出
    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExport.Click
        Dim strSql As String = ""
        Dim sqlWhere As String = Nothing
        Dim IsSearch As Boolean = True
        strSql = " SELECT A.ID ,A.EquipmentNo 设备编号,D.NAME 设备大类,E.NAME 设备中类,F.NAME 设备小类, A.PartNumber 设备料号, " &
                 " A.ProcessParameters 加工参数,A.ServiceCount 使用次数,A.AlertCount 预警次数," &
                 " A.RemainCount 剩下次数,A.STORAGE 储位,A.SafeQty 安全库存,A.Lineid AS 借出线别," &
                 " A.OutUserID + '/' + ISNULL(G.UserName, N'') AS 借出人, A.OutTime AS 借出时间," &
                 "A.UserID AS 创建人ID, C.UserName 创建人姓名 ,A.InTime 创建时间,A.ModifyTime 更新时间,A.Status 状态,A.Remark 备注 " &
                 " FROM m_Equipment_t(nolock) A " &
                 "  LEFT JOIN m_Users_t(nolock) C ON A.UserID=C.UserID    " &
                 " LEFT JOIN m_Users_t G ON A.OutUserID=G.UserID  " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) D ON A.BigCategory=D.CODE AND D.TYPE = 'BIG'  " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) E ON A.MiddleCategory=E.CODE AND E.TYPE = 'MID'  " &
                 "  LEFT JOIN m_EquipmentCategory_t(nolock) F ON A.SmallCategory=F.CODE AND F.TYPE = A.MiddleCategory " &
                 " WHERE 1=1  AND A.Status =1 " &
        EquManageCommon.GetFatoryProfitcenter("A")

        If IsSearch = toolRefresh.Enabled Then '如果查询为true,就带查询条件
            If cboSmallCategory.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择设备类别")
                Exit Sub
            End If

            If cboInOut.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Exit Sub
            End If
            sqlWhere = GetSqlWhereOfOut()
        End If

        strSql = strSql + "  " & sqlWhere & " ORDER BY A.INTIME DESC"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        'ExcelHelper.ExportDTtoExcel(dt, "载治具基本资料表", filename)
        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

    End Sub
    '导入 
    Private Sub toolImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImport.Click
        Try

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName



            
            '取得用户上传表数据()
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 11, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PartNumber IS NOT NULL AND MiddleCategory IS NOT NULL ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("InOut", "System.String", dtUploadData)
            TableAddColumns("FactoryName", "System.String", dtUploadData)
            TableAddColumns("Profitcenter", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)
            dics2.Add("EquipmentNo", "EquipmentNo")
            dics2.Add("BigCategory", "BigCategory")
            dics2.Add("MiddleCategory", "MiddleCategory")
            dics2.Add("SmallCategory", "SmallCategory")
            dics2.Add("PartNumber", "PartNumber")
            dics2.Add("ProcessParameters", "ProcessParameters")
            dics2.Add("ServiceCount", "ServiceCount")
            dics2.Add("AlertCount", "AlertCount")
            dics2.Add("RemainCount", "RemainCount")
            dics2.Add("UserID", "UserID")
            dics2.Add("Storage", "Storage")
            dics2.Add("InOut", "InOut")
            dics2.Add("FactoryName", "FactoryName")
            dics2.Add("Profitcenter", "Profitcenter")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(3).ToString <> "" Then
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(4).ToString(),
                                      row(5).ToString(), row(6).ToString(), row(7).ToString(), row(8).ToString(), row(9).ToString(),
                                      row(10).ToString(), "1", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_Equipment_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    '*************************************************田玉琳 20171106 开始*************************************************
                    EquManageCommon.ExecCNCUpdateList(usercopy)
                    '*************************************************田玉琳 20171106 结束*************************************************
                    MessageUtils.ShowInformation("成功导入！")
                    LoadEquipment()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ImportData(ByVal dt As DataTable)
        Dim sql = New System.Text.StringBuilder()
        For Each dr As DataRow In dt.Rows
            Dim EquipmentNo = dr("设备编号")
            Dim ProcessParameters = dr("加工参数")
            Dim ServiceCount = "2000000"
            Dim AlertCount = "1900000"
            Dim RemainCount = "2000000"
            Dim Remark = dr("备注")
            Dim SafeQty = dr("安全库存")
            Dim Storage = dr("储位")
            Dim BigCategory = dr("大分类(VMD立式成型模具)")
            Dim MiddleCategory = dr("中分类(MJ:模具)")
            Dim SmallCategory = dr("小分类(1:内模,2:外模,3:SR)")
            Dim UserID = VbCommClass.VbCommClass.UseId
            Dim FactoryName = VbCommClass.VbCommClass.Factory
            Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
            If DbOperateUtils.GetDataTable("select EquipmentNo from m_Equipment_t where EquipmentNo='" & EquipmentNo & "'").Rows.Count = 0 Then
                sql.AppendLine("insert into m_Equipment_t(EquipmentNo,ProcessParameters,PartNumber,ServiceCount,AlertCount,RemainCount,Remark,Storage,BigCategory,MiddleCategory,SmallCategory,UserID,InTime,FactoryName,Profitcenter,SafeQty) ")
                sql.AppendLine("values ('" & EquipmentNo & "',N'" & ProcessParameters & "','" & EquipmentNo & "','" & ServiceCount & "','" & AlertCount & "','" & RemainCount & "',N'" & Remark & "',N'" & Storage & "',N'" & BigCategory & "',N'" & MiddleCategory & "',N'" & SmallCategory & "','" & UserID & "',getdate(),'" & FactoryName & "','" & Profitcenter & "','" & SafeQty & "')")
            End If
        Next
        DbOperateUtils.ExecSQL(sql.ToString())
    End Sub

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub
    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    Private Sub ChangeCDDataTableColumnNamePJ(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGridPJ In [Enum].GetValues(GetType(CDImportGridPJ))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGridPJ), i).ToString
        Next
    End Sub

    '中分类选择改变事件
    Private Sub cboMiddleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMiddleCategory.SelectedIndexChanged
        If String.IsNullOrEmpty(cboMiddleCategory.SelectedValue.ToString) = False Then
            EquManageCommon.BindComboxCategory(cboSmallCategory, cboMiddleCategory.SelectedValue.ToString)
            'ADD IF by cq 20180719
            If VbCommClass.VbCommClass.Factory = "SEE-D" Then
                '为EBU处暂时设置，把6.测试设置为默认
                If cboMiddleCategory.SelectedValue.ToString = "FX" Then
                    cboSmallCategory.SelectedValue = 6
                End If
            Else
                'do nothing 
            End If
        End If
        Select Case cboMiddleCategory.SelectedValue.ToString()
            Case "PA"
                TabEquipment.SelectedIndex = 0
            Case "MA"
                TabEquipment.SelectedIndex = 1
            Case "MJ"
                TabEquipment.SelectedIndex = 2
            Case "FX"
                TabEquipment.SelectedIndex = 3
            Case "YPFX"
                TabEquipment.SelectedIndex = 4
            Case "PJ"
                TabEquipment.SelectedIndex = 5
            Case "YP", "SP", "GN", "SX", "FC"
                TabEquipment.SelectedIndex = 6
        End Select

    End Sub
#End Region

#Region "复制记录"
    Private Sub tsmiCopyRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopyRecord.Click
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '
            Dim index As Integer = TabEquipment.SelectedIndex
            Dim EquipmentNo As String = Nothing
            '参数定义
            Dim p As New SqlClient.SqlParameter
            Dim param1 As New SqlParameter("@ID", SqlDbType.Int, ParameterDirection.Input)
            Dim param2 As New SqlParameter("@OldEquipmentNo", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
            Dim Paramters As SqlParameter() = Nothing

            If index = 0 Then
                EquipmentNo = dgvPA.Rows(dgvPA.CurrentRow.Index).Cells("设备编号").Value.ToString()
                param1.Value = CInt(dgvPA.Rows(dgvPA.CurrentRow.Index).Cells("ID").Value.ToString)
            ElseIf index = 1 Then
                EquipmentNo = dgvMA.Rows(dgvPA.CurrentRow.Index).Cells("设备编号").Value.ToString()
                param1.Value = CInt(dgvMA.Rows(dgvPA.CurrentRow.Index).Cells("ID").Value.ToString)
            Else
                EquipmentNo = dgvMJ.Rows(dgvPA.CurrentRow.Index).Cells("设备编号").Value.ToString()
                param1.Value = CInt(dgvMJ.Rows(dgvPA.CurrentRow.Index).Cells("ID").Value.ToString)
            End If

            '参数赋值
            param2.Value = EquipmentNo
            param3.Value = SysMessageClass.UseId
            param4.Direction = ParameterDirection.Output '指定
            param4.Value = ""
            Paramters = New SqlParameter() {param1, param2, param3, param4}

            If MessageUtils.ShowConfirm("确认复制设备""" & EquipmentNo & """?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            '执行SP
            DAL.ExecuteNonQureyByProc("udpCopyEquipment", Paramters)

            If param4.Value.ToString() <> "" Then
                MessageUtils.ShowError(param4.Value.ToString())
                Exit Sub
            End If
            MessageUtils.ShowInformation("复制成功!")

            LoadEquipment()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipment", "tsmiCopyRecord_Click", "sys")
        Finally
            DAL = Nothing
        End Try
    End Sub
#End Region

#Region "绑定右健菜单"
    Private Sub dgvEquipment_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvPA.CellContextMenuStripNeeded
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub
    Private Sub dgvMEquipment_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvMA.CellContextMenuStripNeeded, dgvMJ.CellContextMenuStripNeeded
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub
    Private Sub dgvZEquipment_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs)
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub
#End Region

#Region "右健改变当前行号"
    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPA.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvPA.ClearSelection()
                dgvPA.Rows(e.RowIndex).Selected = True
                dgvPA.CurrentCell = dgvPA.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If

    End Sub
    Private Sub dgvMEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMA.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvPA.ClearSelection()
                dgvPA.Rows(e.RowIndex).Selected = True
                dgvPA.CurrentCell = dgvPA.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If

    End Sub
    Private Sub dgvZEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                '右健改变当前行号
                dgvPA.ClearSelection()
                dgvPA.Rows(e.RowIndex).Selected = True
                dgvPA.CurrentCell = dgvPA.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If

    End Sub
#End Region

#Region "复制单元格"
    Private Sub tsmiCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopy.Click
        Dim index As Integer = TabEquipment.SelectedIndex
        If index = 0 Then

            If Not dgvPA.CurrentCell Is Nothing Then
                Dim Selected As String = dgvPA.CurrentCell.Value.ToString()
                Clipboard.SetDataObject(Selected)
            End If
        ElseIf index = 1 Then
            If Not dgvMA.CurrentCell Is Nothing Then
                Dim Selected As String = dgvMA.CurrentCell.Value.ToString()
                Clipboard.SetDataObject(Selected)
            End If
        Else
            If Not dgvMJ.CurrentCell Is Nothing Then
                Dim Selected As String = dgvMJ.CurrentCell.Value.ToString()
                Clipboard.SetDataObject(Selected)
            End If

        End If
    End Sub
#End Region

#Region "背景色"
    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvPA.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvMEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvMA.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
    Private Sub dgvZEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        For Each item As DataGridViewRow In dgvMJ.Rows

            If Not item.Cells("状态").Value Is Nothing AndAlso item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
#End Region

#Region "GridClick"
    Private Sub dgvPA_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPA.CellClick
        GridClick(dgvPA, e)
    End Sub
    Private Sub dgvMA_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMA.CellClick
        ' dgvMA.EndEdit() 'add by cq20181015
        'Me.dgvMA.ReadOnly = True
        GridClick(dgvMA, e)
    End Sub
    Private Sub dgvMJ_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMJ.CellClick
        GridClick(dgvMJ, e)
    End Sub
    Private Sub dgvFX_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFX.CellClick
        GridClick(dgvFX, e)
    End Sub
    Private Sub GridClick(dgGrid As DataGridView, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgGrid.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        If e.RowIndex < 0 Then Exit Sub
        SetGroupBox()
    End Sub
#End Region

    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB中设备类别
        Dim categorytypesql As String = " SELECT CODE,NAME FROM m_EquipmentCategory_t where status = 1"
        Dim cytypeDT As DataTable = DbOperateUtils.GetDataTable(categorytypesql)

        Dim categorytypeSmallsql As String = " SELECT CODE,NAME FROM m_EquipmentCategory_t where status = 1 and TYPE <> 'MID'"
        Dim cytypeSamallDT As DataTable = DbOperateUtils.GetDataTable(categorytypeSmallsql)

        'DB中设备编号
        Dim equPNSql As String = " select EquipmentNo from m_Equipment_t where 1=1 " & EquManageCommon.GetFatoryProfitcenter()
        Dim dtEquPN As DataTable = DbOperateUtils.GetDataTable(equPNSql)

        'DB中设备料号
        Dim partnumberSql As String = " select TAvcPart from m_PartContrast_t where type = 'E' "
        Dim dtPN As DataTable = DbOperateUtils.GetDataTable(partnumberSql)

        'Dim ht As New Hashtable
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""
        For index As Integer = 0 To DrrR.Length - 1
            '设备类别
            Dim bigCategory As String = DrrR(index)(CDImportGrid.BigCategory.ToString).ToString.Trim
            Dim returnCode As String = ""
            If bigCategory <> "" Then
                If CheckExistUserColumns(cytypeDT, "NAME", bigCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备大类没有在资料库中：'" + bigCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.BigCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备大类有空值,请检查后重新上传。")
                Return False
            End If

            Dim middleCategory As String = DrrR(index)(CDImportGrid.MiddleCategory.ToString).ToString.Trim
            If middleCategory <> "" Then
                If CheckExistUserColumns(cytypeDT, "NAME", middleCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备中类没有在资料库中：'" + middleCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.MiddleCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备中类有空值,请检查后重新上传。")
                Return False
            End If

            Dim smallCategory As String = DrrR(index)(CDImportGrid.SmallCategory.ToString).ToString.Trim
            If smallCategory <> "" Then
                If CheckExistUserColumns(cytypeSamallDT, "NAME", smallCategory, returnCode) = False Then
                    MessageUtils.ShowError("上传设备小类没有在资料库中：'" + smallCategory + "'")
                    Return False
                Else
                    DrrR(index)(CDImportGrid.SmallCategory.ToString) = returnCode
                End If
            Else
                MessageUtils.ShowError("设备小类有空值,请检查后重新上传。")
                Return False
            End If


            '比对设备编号 
            If (DrrR(index)("EquipmentNO").ToString <> "") Then
                If hastable.Contains(DrrR(index)("EquipmentNO")) Then
                    MessageUtils.ShowError("上传文件中有重复的设备编号：'" + DrrR(index)("EquipmentNO").ToString + "'")
                    Return False
                End If
                If CheckExistUserColumns(dtEquPN, "EquipmentNo", DrrR(index)("EquipmentNO").ToString, returnCode) = True Then
                    MessageUtils.ShowError("不能上传重复的设备编号：'" + DrrR(index)("EquipmentNO").ToString + "'")
                    Return False
                End If
                hastable.Add(DrrR(index)("EquipmentNO"), DrrR(index)("EquipmentNO"))
            Else
                '自动生成新的设备编号
                Dim bigCategoryCode As String = DrrR(index)(CDImportGrid.BigCategory.ToString)
                Dim middelCategoryCode As String = DrrR(index)(CDImportGrid.MiddleCategory.ToString)
                If hastable.Contains(bigCategoryCode + middelCategoryCode) = False Then
                    firstNo = EquipmentNoMAX(bigCategoryCode, middelCategoryCode)
                    hastable.Add(bigCategoryCode + middelCategoryCode, firstNo)
                    DrrR(index)("EquipmentNO") = firstNo
                Else
                    firstNo = hastable(bigCategoryCode + middelCategoryCode).ToString
                    DrrR(index)("EquipmentNO") = firstNo.Substring(0, 4) + CStr(CInt(firstNo.Substring(4)) + 1)
                    hastable.Remove(bigCategoryCode + middelCategoryCode)
                    hastable.Add(bigCategoryCode + middelCategoryCode, DrrR(index)("EquipmentNO"))
                End If
            End If

            '比对设备料号
            If DrrR(index)("PartNumber").ToString <> "" Then
                If CheckExistUserColumns(dtPN, "TAvcPart", DrrR(index)("PartNumber").ToString, returnCode) = False Then
                    MessageUtils.ShowError("上传设备料号没有在资料库中：'" + DrrR(index)("PartNumber").ToString + "'")
                    Return False
                Else
                    'DrrR(index)("PartNumber") = returnCode
                End If
            Else
                MessageUtils.ShowError("设备料号有空值,请检查后重新上传。")
                Return False
            End If
        Next

        Return True
    End Function

    '根据厂区和分类取得设备中最大的值
    Private Function EquipmentNoMAX(bigCategory As String, midCategory As String) As String
        'MARK BY CQ 20181219, FactoryName=@FactoryName AND Profitcenter=@Profitcenter ,防止公用一个表，其他厂区导入报主键重复的错误。
        Dim strSQL As String =
            "   DECLARE @STARTNO VARCHAR(20)" &
            "   DECLARE @EquipmentNo VARCHAR(20)" &
            "   SET @STARTNO = @BigCategory + @MiddleCategory + CONVERT(VARCHAR(4),GETDATE(),112) + '000000' " &
            "   SELECT @EquipmentNo = ISNULL(MAX(EquipmentNo),@STARTNO) FROM m_Equipment_t " &
            "   WHERE 1=1  " &
            "   AND BigCategory = @BigCategory AND MiddleCategory = @MiddleCategory AND EquipmentNo LIKE @BigCategory + @MiddleCategory + '%'" &
            "   SET @EquipmentNo = @BigCategory + @MiddleCategory + CAST((SUBSTRING (@EquipmentNo,5,10)+1) AS VARCHAR)" &
            "   SELECT  ISNULL(@EquipmentNo,'')"

        Dim pars As ArrayList = New ArrayList

        pars.Add(String.Format("FactoryName|{0}", VbCommClass.VbCommClass.Factory))
        pars.Add(String.Format("Profitcenter|{0}", VbCommClass.VbCommClass.profitcenter))
        pars.Add(String.Format("BigCategory|{0}", bigCategory))
        pars.Add(String.Format("MiddleCategory|{0}", midCategory))

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL, pars)
        Return dt.Rows(0)(0).ToString
    End Function

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If cboSmallCategory.Enabled = True Then
                If Not cboSmallCategory.SelectedValue Is Nothing AndAlso cboSmallCategory.SelectedValue.ToString <> "" Then
                    Dim id As String = cboSmallCategory.SelectedValue.ToString
                    If id = "System.Data.DataRowView" Then Exit Sub

                    Dim sql As String = " SELECT ServiceCount,AlertCount,RemainCount  FROM m_EquipmentCategory_t WHERE ID = " + id

                    Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)

                    If dt.Rows.Count > 0 Then
                        Me.txtServiceCount.Text = dt.Rows(0)(0).ToString
                        Me.txtAlertCount.Text = dt.Rows(0)(1).ToString
                        Me.txtRemainCount.Text = dt.Rows(0)(2).ToString
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabEquipment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabEquipment.SelectedIndexChanged
        cboMiddleCategory.SelectedIndex = TabEquipment.SelectedIndex + 1
        'add PA by cq 20180823
        If TabEquipment.SelectedIndex = 2 OrElse (TabEquipment.SelectedIndex = EquipmentType.PA) Then
            dtpNextMonthKeep.Enabled = True
            dtpNextSeasonKeep.Enabled = True
        Else
            dtpNextMonthKeep.CustomFormat = " "
            dtpNextMonthKeep.Enabled = False
            dtpNextSeasonKeep.CustomFormat = " "
            dtpNextSeasonKeep.Enabled = False
        End If
        LoadEquipment()
    End Sub

    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.cboBigCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboMiddleCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.MiddleCategory = N'" & Me.cboMiddleCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND MiddleCategory = N'" & Me.cboMiddleCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboSmallCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.SmallCategory = N'" & Me.cboSmallCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND SmallCategory = N'" & Me.cboSmallCategory.SelectedValue.ToString & "' ")
        End If

        If Me.txtEquipmentNo.Text.Trim() <> "" Then
            ' sbSqlWhere.Append(" AND [EquipmentNo] like N'%" & txtEquipmentNo.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 设备编号 like N'%" & txtEquipmentNo.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.txtEquipmentPN.Text.Trim() <> "" Then
            ' sbSqlWhere.Append(" AND [PartNumber] LIKE N'%" & txtEquipmentPN.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 设备料号 like N'%" & txtEquipmentPN.Text.Trim().Replace("'", "''") & "%' ")
        End If

        '是否有效
        If Not cboStatus.SelectedItem Is Nothing AndAlso Me.cboStatus.SelectedItem().ToString <> "" Then
            ' sbSqlWhere.Append(" AND A.Status = " & cboStatus.SelectedItem().ToString().Substring(0, 1) & " ")
            sbSqlWhere.Append(" AND 状态 like '%" & cboStatus.SelectedItem().ToString().Substring(0, 1) & "%' ")
        End If

        '是否在库
        If Not cboInOut.SelectedItem Is Nothing AndAlso Me.cboInOut.SelectedItem().ToString <> "" Then
            ' sbSqlWhere.Append(" AND A.InOut = " & cboInOut.SelectedItem().ToString().Substring(0, 1) & " ")
            sbSqlWhere.Append(" AND 在库状态 like '%" & cboInOut.SelectedItem().ToString().Substring(0, 1) & "%' ")
        End If

        If Me.txtServiceCount.Text.Trim() <> "" Then
            ' sbSqlWhere.Append(" AND ServiceCount like N'%" & txtServiceCount.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 使用次数 like N'%" & txtServiceCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtAlertCount.Text.Trim() <> "" Then
            ' sbSqlWhere.Append(" AND AlertCount like N'%" & txtAlertCount.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 预警次数 like N'%" & txtAlertCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtRemainCount.Text.Trim() <> "" Then
            'sbSqlWhere.Append(" AND RemainCount like N'%" & txtRemainCount.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 剩下次数 like N'%" & txtRemainCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtProcessParameters.Text.Trim() <> "" Then
            'Modify by cq 20190329
            ' sbSqlWhere.Append(" AND ProcessParameters LIKE N'%" & txtProcessParameters.Text.Trim().Replace("'", "''") & "%' ")
            sbSqlWhere.Append(" AND 加工参数 like N'%" & txtProcessParameters.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtStorage.Text.Trim <> "" Then
            ' sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
            sbSqlWhere.Append(" AND 储位 like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        If Me.txtLine.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.LineId like N'%" & Me.txtLine.Text.Trim & "%' ")
            sbSqlWhere.Append(" AND 借出线别 like N'%" & Me.txtLine.Text.Trim & "%' ")
        End If

        If Me.txtOutUserID.Text.Trim() <> "" Then
            'sbSqlWhere.Append(" AND A.OutUserID like N'%" & Me.txtOutUserID.Text.Trim & "%' ")
            sbSqlWhere.Append(" AND OutUserID like N'%" & Me.txtOutUserID.Text.Trim & "%' ")
        End If

        If Me.txtPartid.Text.Trim() <> "" Then
            'sbSqlWhere.Append(" AND A.OutUserID like N'%" & Me.txtOutUserID.Text.Trim & "%' ")
            sbSqlWhere.Append(" AND 产品料号 like N'%" & Me.txtPartid.Text.Trim & "%' ")
        End If

        Return sbSqlWhere.ToString
    End Function


    Private Function GetSqlWhereOfOut() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.cboBigCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND BigCategory = N'" & Me.cboBigCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboMiddleCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.MiddleCategory = N'" & Me.cboMiddleCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND MiddleCategory = N'" & Me.cboMiddleCategory.SelectedValue.ToString & "' ")
        End If

        If Me.cboSmallCategory.Text.Trim <> "" Then
            'sbSqlWhere.Append(" AND A.SmallCategory = N'" & Me.cboSmallCategory.SelectedValue.ToString & "' ")
            sbSqlWhere.Append(" AND SmallCategory = N'" & Me.cboSmallCategory.SelectedValue.ToString & "' ")
        End If

        If Me.txtEquipmentNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [EquipmentNo] like N'%" & txtEquipmentNo.Text.Trim().Replace("'", "''") & "%' ")
            'sbSqlWhere.Append(" AND 设备编号 like N'%" & txtEquipmentNo.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.txtEquipmentPN.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [PartNumber] LIKE N'%" & txtEquipmentPN.Text.Trim().Replace("'", "''") & "%' ")
            'sbSqlWhere.Append(" AND 设备料号 like N'%" & txtEquipmentPN.Text.Trim().Replace("'", "''") & "%' ")
        End If

        '是否有效
        If Not cboStatus.SelectedItem Is Nothing AndAlso Me.cboStatus.SelectedItem().ToString <> "" Then
            sbSqlWhere.Append(" AND A.Status = " & cboStatus.SelectedItem().ToString().Substring(0, 1) & " ")
            'sbSqlWhere.Append(" AND 状态 like '%" & cboStatus.SelectedItem().ToString().Substring(0, 1) & "%' ")
        End If

        '是否在库
        If Not cboInOut.SelectedItem Is Nothing AndAlso Me.cboInOut.SelectedItem().ToString <> "" Then
            sbSqlWhere.Append(" AND A.InOut = " & cboInOut.SelectedItem().ToString().Substring(0, 1) & " ")
            ' sbSqlWhere.Append(" AND 在库状态 like '%" & cboInOut.SelectedItem().ToString().Substring(0, 1) & "%' ")
        End If

        If Me.txtServiceCount.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND ServiceCount like N'%" & txtServiceCount.Text.Trim().Replace("'", "''") & "%' ")
            ' sbSqlWhere.Append(" AND 使用次数 like N'%" & txtServiceCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtAlertCount.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND AlertCount like N'%" & txtAlertCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtRemainCount.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND RemainCount like N'%" & txtRemainCount.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtProcessParameters.Text.Trim() <> "" Then
            'Modify by cq 20190329
            sbSqlWhere.Append(" AND ProcessParameters LIKE N'%" & txtProcessParameters.Text.Trim().Replace("'", "''") & "%' ")
        End If

        If Me.txtStorage.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND Storage like N'%" & Me.txtStorage.Text.Trim & "%' ")
        End If

        If Me.txtLine.Text.Trim <> "" Then
            sbSqlWhere.Append(" AND A.LineId like N'%" & Me.txtLine.Text.Trim & "%' ")
        End If

        If Me.txtOutUserID.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND OutUserID like N'%" & Me.txtOutUserID.Text.Trim & "%' ")
        End If

        Return sbSqlWhere.ToString
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

    Private Function BasicCheck() As Boolean
        If cboPrinter.SelectedIndex = -1 Then
            MessageUtils.ShowError("请选择打印机")
            cboPrinter.Focus()
            Return False
        End If
        If dics.Count <= 0 Then
            MessageUtils.ShowError("请选择需要列印的工治具编号")
            Return False
        End If
        Return True
    End Function

    '检查 借出的工治具不能删除
    Private Function CheckStatus(dgvGrid As DataGridView) As Boolean
        Dim strSQL As String = String.Empty

        '借出的工治具不能删除。
        For Each row As DataGridViewRow In dgvGrid.Rows
            If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                If Not row.Cells(EquipmentGrid.InOut).EditedFormattedValue Is Nothing AndAlso
                row.Cells(EquipmentGrid.InOut).EditedFormattedValue.ToString.Substring(0, 1) = "0" Then
                    MessageUtils.ShowError("借出的工治具不能删除!")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function GetDeleteSQL(dgvGrid As DataGridView) As String
        Dim strSQL As String = String.Empty

        '移除删除功能，改为更新。
        For Each row As DataGridViewRow In dgvGrid.Rows
            If Not row.Cells(EquipmentGrid.checkbox).EditedFormattedValue Is Nothing AndAlso
                   row.Cells(EquipmentGrid.checkbox).EditedFormattedValue.ToString = "True" Then
                'add backup by cq20171024
                strSQL = strSQL + " INSERT INTO m_Equipmentback_t(EquipmentNo" & _
                 " ,CategoryID,PartID,ProcessParameters,ServiceCount" & _
                " ,AlertCount,RemainCount,Status,UserID" & _
                " ,InTime,ModifyTime,Remark ,Storage ,Lineid" & _
                " ,terminalPartNumber ,[FactoryName],[Profitcenter],[PartNumber]" & _
                " ,[InOut],[OutUserID] ,[OutTime] ,[BigCategory] " & _
                " ,MiddleCategory, SmallCategory,ModifyUserID,backTime)" & _
                " SELECT EquipmentNo ,CategoryID,PartID" & _
                " ,[ProcessParameters],ServiceCount," & _
                " AlertCount, RemainCount, Status, UserID" & _
                " ,[InTime],ModifyTime,[Remark],[Storage],Lineid " & _
                " ,[terminalPartNumber],FactoryName" & _
                " ,[Profitcenter],PartNumber" & _
                " ,[InOut],[OutUserID],OutTime" & _
                " ,BigCategory,MiddleCategory,SmallCategory,ModifyUserID,getdate()" & _
                " FROM m_Equipment_t WHERE ID=" & row.Cells(EquipmentGrid.ID).Value.ToString & ""

                strSQL &= " DELETE FROM M_EQUIPMENT_T WHERE ID=" & row.Cells(EquipmentGrid.ID).Value.ToString & "" & vbNewLine
                'strSQL &= " UPDATE M_EQUIPMENT_T SET Status = 0 WHERE ID=" & row.Cells(EquipmentGrid.ID).Value.ToString & "" & vbNewLine
            End If
        Next
        GetDeleteSQL = strSQL
    End Function

    Private Function GetCategoryData(id As String)
        Dim strSQL As String = " SELECT BigCategory ,MiddleCategory,SmallCategory  FROM m_Equipment_t WHERE id = '{0}'"
        strSQL = String.Format(strSQL, id)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

#Region "加载数据"

    Protected Friend Sub LoadEquipment()
        Try
            Dim Where = " where 1=1 "
            Where &= " and 厂区 ='" & VbCommClass.VbCommClass.Factory & "'"
            Where &= " and 利润中心 ='" & VbCommClass.VbCommClass.profitcenter & "'"
            Dim StrSql As String = "select * from V_m_Equipment_t" & Where

            'StrSql = " SELECT  A.EQUIPMENTNO 设备编号, C.NAME 设备类型, A.PARTNUMBER 设备料号," &
            '" A.PROCESSPARAMETERS 加工参数,A.UseMultiple '使用倍数',A.SERVICECOUNT 使用次数,A.ALERTCOUNT 预警次数,A.REMAINCOUNT 剩下次数," &
            '" CASE A.STATUS WHEN 1 THEN N'1.有效' WHEN 2 THEN N'2.待检收' ELSE N'0.无效' END 状态,A.STORAGE 储位," &
            '" CASE A.InOut WHEN 1 THEN N'1.在库' ELSE N'0.借出' END 在库状态,A.LINEID 借出线别," &
            '" OutUserID+'/'+isnull(D.UserName,'') 借出人,OutTime 借出时间 ,A.USERID+'/'+E.UserName 创建人," &
            '" A.INTIME 创建时间 ,A.FactoryName 厂区,A.Profitcenter 利润中心,A.REMARK 备注,A.ID, A.SafeQty 安全库存,NextMonthKeep 月保养时间,NextSeasonKeep 季保养时间 " &
            '" FROM M_EQUIPMENT_T(NOLOCK) A  LEFT JOIN M_EQUIPMENTCATEGORY_T(NOLOCK) C " &
            '" ON A.SmallCategory=C.CODE AND C.TYPE =A.MiddleCategory  LEFT JOIN m_Users_t D ON A.OutUserID=D.UserID" &
            '" LEFT JOIN m_Users_t E ON A.UserID=E.UserID WHERE 1=1 and a.status=1 " &
            'EquManageCommon.GetFatoryProfitcenter("A")

            If OperateFlag = EditMode.SEARCH Then
                StrSql = StrSql + GetSqlWhere()
            End If

            Dim index = TabEquipment.SelectedIndex
            If cboMiddleCategory.Text = "" Then
                'StrSql = StrSql + " AND A.MiddleCategory='" & [Enum].Parse(GetType(EquipmentType), index.ToString).ToString & "'"
            Else
                'StrSql = StrSql + " AND A.MiddleCategory='" & cboMiddleCategory.SelectedValue.ToString & "'"
                StrSql = StrSql + " AND MiddleCategory='" & cboMiddleCategory.SelectedValue.ToString & "'"
                'TabEquipment.SelectedIndex = cboMiddleCategory.SelectedIndex - 1
            End If
            StrSql &= " order by OutOfDateMonthKeep desc,OutOfDateSeasonKeep desc,创建时间 desc "
            'StrSql = StrSql + " ORDER BY A.INTIME DESC "
            LoadData(StrSql, [Enum].Parse(GetType(EquipmentType), index.ToString))
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadData(ByVal Sql As String, ByVal type As EquipmentType)
        Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
        col.Name = "选择"
        col.ReadOnly = False
        col.TrueValue = True
        col.FalseValue = False
        Using dt As DataTable = DbOperateUtils.GetDataTable(Sql)
            Select Case type
                Case EquipmentType.PA
                    SetColumnsProperty(col, dgvPA, dt)
                Case EquipmentType.MA
                    SetColumnsProperty(col, dgvMA, dt)
                Case EquipmentType.MJ
                    SetColumnsProperty(col, dgvMJ, dt)
                Case EquipmentType.FX
                    SetColumnsProperty(col, dgvFX, dt)
                Case EquipmentType.YPZJ
                    SetColumnsProperty(col, dgvYPZJ, dt)
                Case EquipmentType.PJ
                    SetColumnsProperty(col, dgvPJ, dt)
                Case EquipmentType.ATE
                    SetColumnsProperty(col, dgvATE, dt)
            End Select
        End Using
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
        dgGrid.DataSource = dt
        dgGrid.Columns.Insert(0, col)
        '"备注"列全屏显示
        ' dgGrid.Columns(EquipmentGrid.ID).Visible = False
        dgGrid.Columns(EquipmentGrid.ID).Visible = False
        ' dgGrid.Columns(EquipmentGrid.Remark).Visible = False
        dgGrid.Columns(EquipmentGrid.Remark).Visible = False
        dgGrid.ReadOnly = False
        dgGrid.Columns(0).HeaderText = "   选择"
        SetSelectAll(dgGrid)
        dgGrid.Columns(EquipmentGrid.ID).Width = 40
        dgGrid.Columns(EquipmentGrid.checkbox).Width = 60
        dgGrid.Columns(EquipmentGrid.EquipmentNO).Width = 100
        dgGrid.Columns(EquipmentGrid.SmallCategory).Width = 80
        dgGrid.Columns(EquipmentGrid.UseMultiple).Width = 40
        dgGrid.Columns(EquipmentGrid.PartNumber).Width = 80
        dgGrid.Columns(EquipmentGrid.ProcessParameters).Width = 110
        dgGrid.Columns(EquipmentGrid.ServiceCount).Width = 80
        dgGrid.Columns(EquipmentGrid.AlertCount).Width = 80
        dgGrid.Columns(EquipmentGrid.RemainCount).Width = 80
        dgGrid.Columns(EquipmentGrid.Status).Width = 60
        dgGrid.Columns(EquipmentGrid.Storage).Width = 60
        dgGrid.Columns(EquipmentGrid.InOut).Width = 80
        dgGrid.Columns(EquipmentGrid.pnlist).Width = 180
        dgGrid.Columns(EquipmentGrid.LineID).Width = 76
        dgGrid.Columns(EquipmentGrid.OutUserID).Width = 90
        dgGrid.Columns(EquipmentGrid.Intime).Width = 95
        dgGrid.Columns(EquipmentGrid.ModifyTime).Width = 95
        dgGrid.Columns(EquipmentGrid.FactoryID).Width = 60
        dgGrid.Columns(EquipmentGrid.ProfitCenter).Width = 80
        ' dgGrid.Columns(NewEquipmentGrid.OAUrl).Width = 80

        If dgGrid.Name = "dgvMJ" Or dgGrid.Name = "dgvPA" Then
            dgGrid.Columns(EquipmentGrid.UserID).Visible = False
            dgGrid.Columns(EquipmentGrid.Intime).Visible = False
            dgGrid.Columns(EquipmentGrid.ModifyTime).Visible = False
            dgGrid.Columns(EquipmentGrid.FactoryID).Visible = False
            dgGrid.Columns(EquipmentGrid.ProfitCenter).Visible = False
        Else
            dgGrid.Columns(EquipmentGrid.NextMonthKeep).Visible = False
            dgGrid.Columns(EquipmentGrid.NextSeasonKeep).Visible = False
        End If

        Dim UserID = VbCommClass.VbCommClass.UseId

        Dim sql = "select Tkey from m_UserRight_t where UserID='" & UserID & "' and Tkey='M131A012_'"
        If DbOperateUtils.GetDataTable(sql).Rows.Count = 0 Then
            'add hide the 标准件的 使用次数等栏位, zyf 提出，20180831
            Select Case dgGrid.Name
                Case "dgvPA", "dgvMJ"
                    dgGrid.Columns(EquipmentGrid.ServiceCount).Visible = False
                    dgGrid.Columns(EquipmentGrid.AlertCount).Visible = False
                    dgGrid.Columns(EquipmentGrid.RemainCount).Visible = False
                Case Else
                    'do nothing
            End Select
        End If

        dgGrid.Columns("OutOfDateMonthKeep").Visible = False
        dgGrid.Columns("OutOfDateSeasonKeep").Visible = False
        dgGrid.Columns("BigCategory").Visible = False
        dgGrid.Columns("MiddleCategory").Visible = False
        dgGrid.Columns("SmallCategory").Visible = False
        dgGrid.Columns("OutUserID").Visible = False
        ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
    End Sub

    Private Sub SetSelectAll(dgGrid As DataGridView)
        Dim rect As Rectangle = dgGrid.GetCellDisplayRectangle(0, -1, True)
        rect.X = rect.Location.X + rect.Width / 4 - 20
        rect.Y = rect.Location.Y + (rect.Height / 2 - 9)
        Dim cbHeader As CheckBox = New CheckBox()
        cbHeader.Name = "checkboxHeader"
        cbHeader.Size = New Size(18, 18)
        cbHeader.Location = rect.Location
        cbHeader.Checked = False
        AddHandler cbHeader.CheckedChanged, AddressOf cbHeader_CheckedChanged
        dgGrid.Controls.Add(cbHeader)
    End Sub

    Private Sub cbHeader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim gvr As DataGridView = DirectCast(chk.Parent, DataGridView)

        SetCheckBox(chk, gvr)
    End Sub

    Private Sub SetCheckBox(chk As CheckBox, gvr As DataGridView)
        If chk.Checked Then
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(EquipmentGrid.checkbox).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(EquipmentGrid.checkbox).Value = False
            Next
        End If
    End Sub
#End Region

    Private Sub dgvPA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPA.CellDoubleClick

        If dgvPA.RowCount < 0 Then Exit Sub
        Dim o_strColumnName As String = String.Empty
        o_strColumnName = dgvPA.CurrentCell.OwningColumn.Name
        'Select Case o_strColumnName
        '    Case dgvPA.Columns(NewEquipmentGrid.OAUrl).Name
        '        If Not String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(dgvPA.CurrentCell.Value)) Then
        '            System.Diagnostics.Process.Start(dgvPA.CurrentCell.Value)
        '        End If
        '    Case Else
        'End Select
        Me.dgvPA.ReadOnly = True
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvPA.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvPA.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' 日保养
    ''' </summary>
    Private Sub tsmi_MaintenanceDay_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceDay.Click
        Select Case TabEquipment.SelectedIndex
            Case 3
                If Me.dgvFX.CurrentRow Is Nothing OrElse Me.dgvFX.RowCount < 1 Then Exit Sub
                Dim AssetName As String, AssetNo As String = "", Model As String = ""
                AssetNo = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Dim frmMpDay As New FrmEquMaintenanceDay(AssetNo, AssetName, Model)
                frmMpDay.ShowDialog()
            Case 2
                If Me.dgvMJ.CurrentRow Is Nothing OrElse Me.dgvMJ.RowCount < 1 Then Exit Sub
                Dim AssetName As String, AssetNo As String = "", Model As String = ""
                AssetNo = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Dim frmMpDay As New FrmEquMaintenanceDay(AssetNo, AssetName, Model)
                frmMpDay.ShowDialog()
            Case 0
                If Me.dgvPA.CurrentRow Is Nothing OrElse Me.dgvPA.RowCount < 1 Then Exit Sub
                Dim AssetName As String = "", AssetNo As String = "", Model As String
                AssetNo = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Dim frmMpDay As New FrmEquMaintenanceDay(AssetNo, AssetName, Model)
                frmMpDay.ShowDialog()
        End Select
    End Sub

    Private Sub tsmi_MaintenanceType_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceType.Click
        Dim frmmaintenType As New FrmEquMaintenanceType()
        frmmaintenType.ShowDialog()
    End Sub

    ''' <summary>
    ''' 月、季保养
    ''' </summary>
    Private Sub tsmi_MaintenanceMonth_Click(sender As Object, e As EventArgs) Handles tsmi_MaintenanceMonth.Click
        RemoveHandler dgvMJ.RowPostPaint, AddressOf dgvMJ_RowPostPaint
        Select Case TabEquipment.SelectedIndex
            Case 3
                If Me.dgvFX.CurrentRow Is Nothing OrElse Me.dgvFX.RowCount < 1 Then Exit Sub
                Dim AssetName As String = "", AssetNo As String = "", Model As String = "", Storage As String = ""
                AssetNo = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Storage = Me.dgvFX.CurrentRow.Cells(EquipmentGrid.Storage).Value.ToString
                Dim frmMpMorQ As New FrmEquMaintenanceMonth(AssetNo, AssetName, Model, Storage)
                frmMpMorQ.ShowDialog()
            Case 2
                If Me.dgvMJ.CurrentRow Is Nothing OrElse Me.dgvMJ.RowCount < 1 Then Exit Sub
                Dim AssetName As String = "", AssetNo As String = "", Model As String = "", Storage As String = ""
                AssetNo = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Storage = Me.dgvMJ.CurrentRow.Cells(EquipmentGrid.Storage).Value.ToString
                Dim frmMpMorQ As New FrmEquMaintenanceMonth(AssetNo, AssetName, Model, Storage)
                frmMpMorQ.ShowDialog()
            Case 0
                If Me.dgvPA.CurrentRow Is Nothing OrElse Me.dgvPA.RowCount < 1 Then Exit Sub
                Dim AssetName As String = "", AssetNo As String = "", Model As String = "", Storage As String = ""
                AssetNo = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.EquipmentNO).Value.ToString
                AssetName = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.SmallCategory).Value.ToString
                Model = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.PartNumber).Value.ToString
                Storage = Me.dgvPA.CurrentRow.Cells(EquipmentGrid.Storage).Value.ToString
                Dim frmMpMorQ As New FrmEquMaintenanceMonth(AssetNo, AssetName, Model, Storage)
                frmMpMorQ.ShowDialog()
        End Select
        cboMiddleCategory.SelectedIndex = TabEquipment.SelectedIndex + 1
        LoadEquipment()
        AddHandler dgvMJ.RowPostPaint, AddressOf dgvMJ_RowPostPaint
    End Sub

    Private Sub ToolImportPJ_Click(sender As Object, e As EventArgs) Handles ToolImportPJ.Click
        Dim o_strPartNumber As String = ""
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

            ChangeCDDataTableColumnNamePJ(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PartNumber IS NOT NULL AND MiddleCategory IS NOT NULL ") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '现在开始把数据保存到DB中,先要转
            TableAddColumns("InOut", "System.String", dtUploadData)
            TableAddColumns("FactoryName", "System.String", dtUploadData)
            TableAddColumns("Profitcenter", "System.String", dtUploadData)

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)
            dics2.Add("EquipmentNo", "EquipmentNo")
            dics2.Add("BigCategory", "BigCategory")
            dics2.Add("MiddleCategory", "MiddleCategory")
            dics2.Add("SmallCategory", "SmallCategory")
            dics2.Add("PartNumber", "PartNumber")
            dics2.Add("ProcessParameters", "ProcessParameters")
            dics2.Add("ServiceCount", "ServiceCount")
            dics2.Add("AlertCount", "AlertCount")
            dics2.Add("RemainCount", "RemainCount")
            dics2.Add("UserID", "UserID")
            dics2.Add("Storage", "Storage")
            dics2.Add("InOut", "InOut")
            dics2.Add("FactoryName", "FactoryName")
            dics2.Add("Profitcenter", "Profitcenter")
            dics2.Add("SafeQty", "SafeQty")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            For Each row As DataRow In DrrR
                If row(3).ToString <> "" Then
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(4).ToString(),
                                      row(5).ToString(), row(6).ToString(), row(7).ToString(), row(8).ToString(), row(9).ToString(),
                                      row(10).ToString(), row(11).ToString, _
                                      "1", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
                End If
            Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(usercopy, "m_Equipment_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    LoadEquipment()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TabEquipment_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabEquipment.Selecting
        Dim sql As String = "select * FROM m_UserRight_t" & vbCrLf &
                    "where UserID='" + VbCommClass.VbCommClass.UseId + "' and Tkey='" + e.TabPage.Name + "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count = 0 Then
            MainFrame.SysCheckData.MessageUtils.ShowError("没有" + e.TabPage.Text + "权限,请联系系统管理员!")
            e.Cancel = True
        End If
    End Sub

    '模具寿命管控
    Private Sub tsMJSMGK_Click(sender As Object, e As EventArgs) Handles toolMJSMGK.Click
        Dim frmmjsmgk As Form = New FrmMJSMGK()
        frmmjsmgk.Owner = Me
        frmmjsmgk.ShowDialog()
    End Sub

    '双击弹出模具使用次数扣减记录
    Private Sub dgvFX_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFX.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvFX.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvFX.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
            End If
    End Sub
    'Private Sub dgvPA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPA.CellDoubleClick
    '    If e.RowIndex > -1 Then
    '        Dim EquimentNo As String = dgvPA.Rows(e.RowIndex).Cells(1).Value.ToString()
    '        Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
    '        FrmEquPartLink.EquNo = EquimentNo
    '        FrmEquPartLink.ShowDialog()
    '    End If
    'End Sub
    Private Sub dgvMA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMA.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvMA.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvMA.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub
    Private Sub dgvMJ_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMJ.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvMJ.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvMJ.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub
    Private Sub dgvYPZJ_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvYPZJ.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvYPZJ.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvYPZJ.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub
    Private Sub dgvPJ_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPJ.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvPJ.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvPJ.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub
    Private Sub dgvATE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvATE.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim EquimentNo As String = dgvATE.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value.ToString()
            Dim PartNumber As String = dgvATE.Rows(e.RowIndex).Cells(EquipmentGrid.PartNumber).Value.ToString()
            Dim FrmEquPartLink As FrmEquPartLink = New FrmEquPartLink()
            FrmEquPartLink.EquNo = EquimentNo
            FrmEquPartLink.Label3.Text = EquimentNo
            FrmEquPartLink.Label5.Text = PartNumber
            FrmEquPartLink.ShowDialog()
        End If
    End Sub


    Private Sub txtEquipmentNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipmentNo.KeyPress
        If e.KeyChar = Chr(13) Then
            If TabEquipment.SelectedTab.Name = "m131a8_" Then
                txtEquipmentPN.Text = txtEquipmentNo.Text.Trim()
            End If
        End If
    End Sub

    Private Sub dtpNextMonthKeep_ValueChanged(sender As Object, e As EventArgs) Handles dtpNextMonthKeep.ValueChanged
        dtpNextMonthKeep.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub dtpNextSeasonKeep_ValueChanged(sender As Object, e As EventArgs) Handles dtpNextSeasonKeep.ValueChanged
        dtpNextSeasonKeep.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub dgvMJ_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvMJ.RowPostPaint
        Dim OutOfDateMonthKeep = dgvMJ.Rows(e.RowIndex).Cells("OutOfDateMonthKeep").Value.ToString()
        Dim OutOfDateSeasonKeep = dgvMJ.Rows(e.RowIndex).Cells("OutOfDateSeasonKeep").Value.ToString()
        If OutOfDateMonthKeep = "Y" Or OutOfDateSeasonKeep = "Y" Then
            dgvMJ.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            dgvMJ.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        End If
        'Dim NextMonthKeep = dgvMJ.Rows(e.RowIndex).Cells(EquipmentGrid.NextMonthKeep).Value
        'Dim NextSeasonKeep = dgvMJ.Rows(e.RowIndex).Cells(EquipmentGrid.NextSeasonKeep).Value
        'Dim EquipmentNo = dgvMJ.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value
        'Dim sql = ""
        'If IsDBNull(NextMonthKeep) = False Then
        '    sql = "select dbo.MouldIsOutOfDate('" & EquipmentNo & "','1')"
        '    Dim MouldIsOutOfDate = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        '    If MouldIsOutOfDate = "Y" Then
        '        dgvMJ.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        '        dgvMJ.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        '    End If
        'End If

        'If IsDBNull(NextSeasonKeep) = False Then
        '    sql = "select dbo.MouldIsOutOfDate('" & EquipmentNo & "','2')"
        '    Dim MouldIsOutOfDate = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        '    If MouldIsOutOfDate = "Y" Then
        '        dgvMJ.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        '        dgvMJ.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        '    End If
        'End If
    End Sub

    ''' <summary>
    ''' 标准部件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPA_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvPA.RowPostPaint
        Dim OutOfDateMonthKeep = dgvPA.Rows(e.RowIndex).Cells("OutOfDateMonthKeep").Value.ToString()
        Dim OutOfDateSeasonKeep = dgvPA.Rows(e.RowIndex).Cells("OutOfDateSeasonKeep").Value.ToString()
        If OutOfDateMonthKeep = "Y" Or OutOfDateSeasonKeep = "Y" Then
            dgvPA.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            dgvPA.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        End If
        'Dim NextMonthKeep = dgvPA.Rows(e.RowIndex).Cells(EquipmentGrid.NextMonthKeep).Value
        'Dim NextSeasonKeep = dgvPA.Rows(e.RowIndex).Cells(EquipmentGrid.NextSeasonKeep).Value
        'Dim EquipmentNo = dgvPA.Rows(e.RowIndex).Cells(EquipmentGrid.EquipmentNO).Value
        'Dim sql = ""
        'If IsDBNull(NextMonthKeep) = False Then
        '    sql = "select dbo.EquPAIsOutOfDate('" & EquipmentNo & "','1')"
        '    Dim MouldIsOutOfDate = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        '    If MouldIsOutOfDate = "Y" Then
        '        dgvPA.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        '        dgvPA.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        '    End If
        'End If

        'If IsDBNull(NextSeasonKeep) = False Then
        '    sql = "select dbo.EquPAIsOutOfDate('" & EquipmentNo & "','2')"
        '    Dim MouldIsOutOfDate = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString()
        '    If MouldIsOutOfDate = "Y" Then
        '        dgvPA.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        '        dgvPA.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
        '    End If
        'End If
    End Sub

    Private Sub tsmiMaintenanceDetails_Click(sender As Object, e As EventArgs) Handles tsmiMaintenanceDetails.Click
        Dim EquimentNO = ""
        Select Case TabEquipment.SelectedIndex
            Case 0
                EquimentNO = dgvPA.CurrentRow.Cells("设备编号").Value.ToString
            Case 1
                EquimentNO = dgvMA.CurrentRow.Cells("设备编号").Value.ToString
            Case 2
                EquimentNO = dgvMJ.CurrentRow.Cells("设备编号").Value.ToString
            Case 3
                EquimentNO = dgvFX.CurrentRow.Cells("设备编号").Value.ToString
            Case 4
                EquimentNO = dgvYPZJ.CurrentRow.Cells("设备编号").Value.ToString
            Case 5
                EquimentNO = dgvPJ.CurrentRow.Cells("设备编号").Value.ToString
        End Select
        Dim frm = New FrmMaintenanceDetails()
        frm.EquimentNO = EquimentNO
        frm.ShowDialog()
    End Sub

    Private Sub tsmiBtnLoadMoBan_Click(sender As Object, e As EventArgs) Handles tsmiBtnLoadMoBan.Click
        Try
            Dim ssf = New SaveFileDialog()
            ssf.FileName = "治具导入准表模板.xls"
            ssf.Filter = "Excel|*.xls"
            If ssf.ShowDialog() = DialogResult.OK Then
                Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                    Dim data = System.IO.File.ReadAllBytes("\\192.168.20.123\SFCShare\File\治具导入准表模板\治具导入准表模板.xls")
                    fs.Write(data, 0, data.Length)
                    fs.Flush()
                End Using
                MessageUtils.ShowInformation("下载成功!")
            Else
                MessageUtils.ShowInformation("下载失败!")
            End If

        Catch ex As Exception
            MessageUtils.ShowError("下载异常:" & vbCrLf & "" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 模具汇入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBtnMojuHuiRu_Click(sender As Object, e As EventArgs) Handles tsmiBtnMojuHuiRu.Click
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
        If (sdfimport.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        Dim filename As String = ""
        Dim errorMsg As String = ""
        filename = sdfimport.FileName
        Try
            Dim dtUploadData As DataTable = VbCommClass.NPOIExcle.ExcelInputByNPOI(filename)
            ImportData(dtUploadData)
            MessageUtils.ShowInformation("成功导入！")
            LoadEquipment()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipment", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
    End Sub



    Private Sub dgvATE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvATE.CellClick
        GridClick(dgvATE, e)
    End Sub
End Class



Public Class KeyValue
    Private _key As String
    Private _value As String
    Private _index As Integer

    Public Property Key() As String
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property
    Public Property Index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property
    Public Sub New(ByVal index As Integer, ByVal key As String, ByVal value As String)
        _index = index
        _key = key
        _value = value
    End Sub
End Class
