Imports System.IO
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports SysBasicClass
Imports System.Text.RegularExpressions
Imports DevComponents.DotNetBar
Imports SampleManage.SampleCom

Public Class FrmSampleUpload
#Region "变量定义"

    Private m_strCurrentUserName As String
    Private m_strCurrentUserDept As String
    Private m_ChkboxAll As New CheckBox
#Region "EquFileName"
    Private _equFileName As String
    Public Property EquFileName() As String
        Get
            Return _equFileName
        End Get

        Set(ByVal Value As String)
            _equFileName = Value
        End Set
    End Property
#End Region

#Region "BlueFileName"
    Private _blueFileName As String
    Public Property BlueFileName() As String
        Get
            Return _blueFileName
        End Get

        Set(ByVal Value As String)
            _blueFileName = Value
        End Set
    End Property
#End Region

#Region "CusBlueFileName"
    Private _cblueFileName As String
    Public Property CusBlueFileName() As String
        Get
            Return _cblueFileName
        End Get

        Set(ByVal Value As String)
            _cblueFileName = Value
        End Set
    End Property
#End Region

#Region "BOMFileName"
    Private _bomFileName As String
    Public Property BOMFileName() As String
        Get
            Return _bomFileName
        End Get

        Set(ByVal Value As String)
            _bomFileName = Value
        End Set
    End Property
#End Region

#Region "PackFileName"
    Private _packFileName As String
    Public Property PackFileName() As String
        Get
            Return _packFileName
        End Get

        Set(ByVal Value As String)
            _packFileName = Value
        End Set
    End Property
#End Region

#Region "CutFileName"
    Private _cutFileName As String
    Public Property CutFileName() As String
        Get
            Return _cutFileName
        End Get

        Set(ByVal Value As String)
            _cutFileName = Value
        End Set
    End Property
#End Region

#Region "RCardFileName"
    Private _rCardFileName As String
    Public Property RCardFileName() As String
        Get
            Return _rCardFileName
        End Get

        Set(ByVal Value As String)
            _rCardFileName = Value
        End Set
    End Property
#End Region

#Region "ZEquFileName"
    Private _zEquFileName As String
    Public Property ZEquFileName() As String
        Get
            Return _zEquFileName
        End Get

        Set(ByVal Value As String)
            _zEquFileName = Value
        End Set
    End Property
#End Region

#Region "SampleNumber"
    Private _sampleNumber As String
    Public Property SampleNumber() As String
        Get
            Return _sampleNumber
        End Get
        Set(ByVal Value As String)
            _sampleNumber = Value
        End Set
    End Property

    Private m_custID As String
    Public Property strCustID() As String
        Get
            Return m_custID
        End Get
        Set(ByVal Value As String)
            m_custID = Value
        End Set
    End Property

    Private _ypsDutyName As String
    Public Property YPSDutyName() As String
        Get
            Return _ypsDutyName
        End Get
        Set(ByVal Value As String)
            _ypsDutyName = Value
        End Set
    End Property

    Private _sjDutyName As String
    Public Property SJDutyName() As String
        Get
            Return _sjDutyName
        End Get
        Set(ByVal Value As String)
            _sjDutyName = Value
        End Set
    End Property

    Private _ccDutyName As String
    Public Property CCDutyName() As String
        Get
            Return _ccDutyName
        End Get
        Set(ByVal Value As String)
            _ccDutyName = Value
        End Set
    End Property

    Private _sgDutyName As String
    Public Property SGDutyName() As String
        Get
            Return _sgDutyName
        End Get
        Set(ByVal Value As String)
            _sgDutyName = Value
        End Set
    End Property

    Private _zjDutyName As String
    Public Property ZJDutyName() As String
        Get
            Return _zjDutyName
        End Get
        Set(ByVal Value As String)
            _zjDutyName = Value
        End Set
    End Property

    Private _rdDutyName As String
    Public Property RDDutyName() As String
        Get
            Return _rdDutyName
        End Get
        Set(ByVal Value As String)
            _rdDutyName = Value
        End Set
    End Property

#End Region

    Public Enum OldSheetType
        Equ = 0
        BOM
        ZEqu
        Model
        Document
    End Enum

    Public Enum SheetType
        Equ = 0
        ZEqu
        Model
        Document
    End Enum

    Private Enum DocumentType
        Blue = 0
        Cut
        RCard
        ZEqu
        CusBlue
        Pack
        BOM
    End Enum

    Private Enum enumdgvEqu
        IsExist
        SampleNo
        No
        EquName
        Qty
        YPSDutyName
        SJDutyName
        PlanDueDate
        RealDueDate
    End Enum

    Private Enum enumdgvBOM
        IsExist
        SampleNo
        No
        PartNumber
        Specs
        supplier
        Qty
        Unit
        CCDutyUserName
        SGDutyUserName
        PlanDueDate
        RealDueDate
    End Enum

    Private Enum enumdgvZEqu
        SampleNo
        No
        ZEquName
        Qty
        IsShare
        SharePN
        ZJDutyUserName
        PlanDueDate
        RealDueDate
    End Enum

    Private Enum enumdgvModel
        SampleNo
        No
        ModelName
        Qty
        IsShare
        SharePN
        RDUserName
        PlanDueDate
        RealDueDate
    End Enum

    Private Enum enumdgvDocument
        SampleNo
        type
        path
    End Enum

    Private Enum CDImportGridOfEqu
        No
        EquName
        Qty
        IsExist
        YPSDutyUserName
        SJDutyUserName
        PlanDueDate
        RealDueDate
        '  SampleNo
    End Enum

    Private Enum ImportToGridOfBOM
        No
        PartNo
        Specs
        supplier
        Qty
        Unit
        CCDutyUserName
        SGDutyUserName
        PlanDuedate
        RealDuedate
    End Enum

    Private Enum CDImportGridOfZEqu
        No
        ZEquName
        Qty
        IsShare
        SharePN
        ZJDutyUserName
        PlanDuedate
        RealDuedate
    End Enum

    Private Enum CDImportGridOfModel
        No
        ModelName
        Qty
        IsShare
        SharePN
        RDUserName
        PlanDuedate
        RealDuedate
    End Enum

    Public Enum SampleFilterType
        研发
        样品室
        设备
        治具
    End Enum

    Public Enum LeftSampe
        SampleNo
        PartNo
        Status
        RDUserName
        YPSUserName
        EquUserName
    End Enum

#Region "左边树DataTable"
    Private _LeftTreeDataTable As DataTable
    Public Property LeftTreeDataTable() As DataTable
        Get
            Return _LeftTreeDataTable
        End Get

        Set(ByVal Value As DataTable)
            _LeftTreeDataTable = Value
        End Set
    End Property
#End Region
#End Region

    Private Sub FrmSampleUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim tp As TabPage = TabSheet.TabPages(SheetType.BOM)
        'TabSheet.TabPages.Remove(tp)

        m_strCurrentUserName = SampleCom.GetUserName(VbCommClass.VbCommClass.UseId)

        m_strCurrentUserDept = SampleCom.GetUserDept(VbCommClass.VbCommClass.UseId)

        LoadSideBarByClick("", m_strCurrentUserDept)

    End Sub

    Private Sub LoadSideBarByClick(ByVal sort As String, ByVal type As String, Optional blnRefresh As Boolean = False)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Dim dvSample As DataView = Nothing
        Dim dvSampleCopy As DataView = Nothing

        Try
            item.Image = ImageList1.Images(0)
            item.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            item.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left

            If LeftTreeDataTable Is Nothing OrElse LeftTreeDataTable.Rows.Count < 1 OrElse blnRefresh Then
                '填充数据
                If SetSideBarData() = False Then Exit Sub
            End If

            dvSample = New DataView(LeftTreeDataTable)
            dvSampleCopy = dvSample
            '晒选
            ' dvSample.Sort = "InTime " & sort & ",MODIFYTIME " & sort

            Call FillUserSelfData(dvSampleCopy)

            Select Case type
                Case SampleFilterType.研发.ToString
                    '未完成
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.研发.ToString Then
                        dvSample.RowFilter = "RDUserName='" + m_strCurrentUserName + "' AND RDFinishFlag='0' "
                    End If
                    '清除现有Item
                    sbPanelRD.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "",
                                                            drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        sbPanelRD.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = sbPanelRD
                Case SampleFilterType.设备.ToString
                    '
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.设备.ToString Then
                        dvSample.RowFilter = "EquUserName='" & m_strCurrentUserName & "' AND EquFinishFlag='0' "
                    End If
                    ' dvSample.RowFilter = "Status=1 "
                    '清除现有Item
                    SideBarPanelEqu.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelEqu.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelEqu
                Case SampleFilterType.样品室.ToString
                    If m_strCurrentUserDept = SampleCom.EnumSampleDept.样品室.ToString Then
                        '确认已有设备
                        dvSample.RowFilter = "YPSUserName='" & m_strCurrentUserName & "'AND YPSEquFinishFlag='0' "
                    End If
                    '清除现有Item
                    SideBarPanelYP.SubItems.Clear()
                    '遍历
                    For Each drv As DataRowView In dvSample
                        newItem = item.Copy()
                        newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                        newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                        lst = New ArrayList
                        'lst.Add(drv.Item("ID").ToString())
                        lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                        lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                        newItem.Tag = lst
                        SideBarPanelYP.SubItems.Add(newItem)
                        index += 1
                        If index > 100 Then Exit For
                    Next
                    SideBar1.ExpandedPanel = SideBarPanelYP
            End Select
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "LoadSideBarByClick", "Sample")
        End Try
    End Sub

    Private Sub FillUserSelfData(ByVal o_dvSample As DataView)
        Dim item As New ButtonItem
        Dim newItem As BaseItem
        Dim lst As ArrayList
        Dim index As Integer = 0
        Try
            Select Case m_strCurrentUserDept
                Case EnumSampleDept.研发.ToString
                    o_dvSample.RowFilter = "RDUserName='" & m_strCurrentUserName & "'AND RDFinishFlag = '1'"
                Case EnumSampleDept.设备.ToString
                    o_dvSample.RowFilter = "EquUserName='" & m_strCurrentUserName & "'AND EquFinishFlag = '1'"
                Case EnumSampleDept.样品室.ToString
                    o_dvSample.RowFilter = "YPSUserName='" & m_strCurrentUserName & "'AND YPSEquFinishFlag = '1'"
                Case Else
                    Exit Sub
            End Select
            '清除现有Item
            SideBarPanelUserself.SubItems.Clear()
            '遍历
            For Each drv As DataRowView In o_dvSample
                newItem = item.Copy()
                newItem.Text = drv.Item(LeftSampe.SampleNo.ToString).ToString()
                newItem.Tooltip = CStr(IIf(IsDBNull(drv.Item(LeftSampe.PartNo.ToString)), "", drv.Item(LeftSampe.PartNo.ToString)))
                lst = New ArrayList
                lst.Add(drv.Item(LeftSampe.SampleNo.ToString).ToString())
                lst.Add(drv.Item(LeftSampe.Status.ToString).ToString())
                newItem.Tag = lst
                SideBarPanelUserself.SubItems.Add(newItem)
                index += 1
                If index > 100 Then Exit For
            Next
            SideBar1.ExpandedPanel = SideBarPanelUserself
        Catch ex As Exception
        Finally
            o_dvSample = Nothing
        End Try
    End Sub

    Private Function SetSideBarData() As Boolean
        Dim r As Boolean = False
        Try
            Dim strSQL As String = Nothing
            Dim dt As DataTable = Nothing
            Me._LeftTreeDataTable = Nothing
            strSQL = " SELECT SampleNo,PartNo,Status,RDUserName,YPSUserName, EquUserName,ZJUserName, " & _
                     " isnull(RDFinishFlag,'0')RDFinishFlag, isnull(EquFinishFlag,'0')EquFinishFlag, isnull(YPSEquFinishFlag,'0') YPSEquFinishFlag, isnull(ZJFinishFlag,'0')ZJFinishFlag " & _
                     " FROM m_Sample_t Where 1=1 AND  Status ='0'  ORDER BY DeliveryDate DESC "
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me._LeftTreeDataTable = dt
                '统计数量
                SetSideBarPanelAmout()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "SetSideBarData", "Sample")
        End Try
        Return True
    End Function

    Private Sub SetSideBarPanelAmout()
        Try
            Dim dv As DataView = Nothing

            dv = New DataView(LeftTreeDataTable)
            dv.RowFilter = " RDUserName='" & m_strCurrentUserName & "' AND RDFinishFlag ='0'"
            sbPanelRD.Text = sbPanelRD.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " EquUserName='" & m_strCurrentUserName & "' AND EquFinishFlag ='0'"
            SideBarPanelEqu.Text = SideBarPanelEqu.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " YPSUserName='" & m_strCurrentUserName & "'AND YPSEquFinishFlag ='0'"
            SideBarPanelYP.Text = SideBarPanelYP.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            dv.RowFilter = " ZJUserName='" & m_strCurrentUserName & "' AND ZJFinishFlag ='0'"
            SideBarPanelZEqu.Text = SideBarPanelZEqu.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"

            Select Case m_strCurrentUserDept
                Case EnumSampleDept.研发.ToString
                    dv.RowFilter = " RDUserName='" & m_strCurrentUserName & "'AND RDFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.设备.ToString
                    dv.RowFilter = " EquUserName='" & m_strCurrentUserName & "'AND EquFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.治具.ToString
                    dv.RowFilter = " ZJUserName='" & m_strCurrentUserName & "'AND ZJFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case EnumSampleDept.样品室.ToString
                    dv.RowFilter = " YPSUserName='" & m_strCurrentUserName & "'AND YPSEquFinishFlag ='1'"
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + dv.Count.ToString + ")"
                Case Else
                    SideBarPanelUserself.Text = SideBarPanelUserself.Text.Split(CChar("("))(0) + "(" + "0" + ")"
            End Select

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "SetSideBarPanelAmout", "Sample")
        End Try
    End Sub

    Private Sub btnUploadEqu_Click(sender As Object, e As EventArgs) Handles btnUploadEqu.Click
        btnUploadEqu.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtEquFilePath.Text = OpenFileDialog1.FileName
            Me.EquFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadEqu.Enabled = True
    End Sub

    '清单导入
    Private Sub btnImportEqu_Click(sender As Object, e As EventArgs) Handles btnImportEqu.Click
        If Not String.IsNullOrEmpty(Me.EquFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim o_strNotReadyDutyList As String = String.Empty
            If Not SampleCom.IsAllDutyNameReady(_sampleNumber, o_strNotReadyDutyList) Then
                MessageUtils.ShowError("该样品清单责任人没有维护完成,相关的部门为：" & o_strNotReadyDutyList & "，不允许导入!")
                Exit Sub
            End If

            Dim strPartNO As String = String.Empty, strFormatDes As String = "", strMadeQty As String = ""
            strPartNO = SampleCom.GetPNInfo(Me.txtSampleNo.Text, strFormatDes, strMadeQty)
            Me.txtPartNo.Text = strPartNO
            If String.IsNullOrEmpty(strFormatDes) Then
                MessageUtils.ShowError(" 请先维护样品的规格描述！")
                Exit Sub
            Else
                Me.txtFormatDes.Text = strFormatDes
            End If

            'check whether import the data 2016111
            If SampleCom.IsAlreadSheetImport(_sampleNumber) Then
                If MessageUtils.ShowConfirm("该样品清单已经导入，是否替换?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    'do nothing
                Else
                    MessageUtils.ShowError("该样品清单已经导入,不允许再导入!")
                    Exit Sub
                End If
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim ServerFile As String = ""
            Dim EquFilePath As String = Me.txtEquFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.EquFileName)
            File.Copy(EquFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If

        If Not UploadFileOfEqu() Then
            MessageUtils.ShowError("清单导入错误,请检查设备清单!")
            'rollback
            Call SampleCom.DeleteEqu(_sampleNumber)
            Exit Sub
        End If

        'mark by cq 20161210
        'If Not UploadFileOfBOM() Then
        '    MessageUtils.ShowError("清单导入错误,请检查BOM清单!")
        '    'rollback
        '    Call SampleCom.DeleteEqu(_sampleNumber)
        '    Call SampleCom.DeleteBOM(_sampleNumber)
        '    Exit Sub
        'End If

        If Not UploadFileOfZEqu() Then
            MessageUtils.ShowError("清单导入错误,请检查治工具清单!")
            'rollback
            Call SampleCom.DeleteEqu(_sampleNumber)
            Call SampleCom.DeleteBOM(_sampleNumber)
            Call SampleCom.DeleteZEqu(_sampleNumber)
            Exit Sub
        End If

        If Not UploadFileOfModel() Then
            MessageUtils.ShowError("清单导入错误,请检查模具清单!")
            'rollback
            Call SampleCom.DeleteEqu(_sampleNumber)
            Call SampleCom.DeleteBOM(_sampleNumber)
            Call SampleCom.DeleteZEqu(_sampleNumber)
            Call SampleCom.DeleteModel(_sampleNumber)
            Exit Sub
        End If

        'Update current steps finish and prepare next steps
        Call UpdateSheetUpload()

    End Sub

    Private Sub UpdateSheetUpload()
        Dim lsSQL As New StringBuilder
        Dim o_strExecSQLResult As String = ""
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId

            arrayList.Add("SampleNo|" & _sampleNumber)
            o_strExecSQLResult = DbOperateUtils.ExecuteNonQureyByProc("m_SampleSheetUpload_p", arrayList)
            If o_strExecSQLResult <> "" Then
                ' ShowMessage(File & "导入失败->" & o_strExecSQLResult)
                MessageUtils.ShowError(o_strExecSQLResult)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "UpdateSheetUpload", "Sample")
        End Try
    End Sub

    Private Function UploadFileOfEqu() As Boolean
        Dim errorMsg As String = Nothing
        Try
            '取得用户上传表数据 'EquName
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(txtEquFilePath.Text, "设备清单", 0, 0, errorMsg)

            'cq 20161117
            Dim column As DataColumn
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SampleNo"
            dtUploadData.Columns.Add("SampleNo")

            ChangeCDDataTableColumnName(dtUploadData, SheetType.Equ)
            Dim DrrR As DataRow() = dtUploadData.Select(" EquName IS NOT NULL ") '防止追加
            'If CheckUploadData(DrrR) = False Then
            '    Exit Sub
            'End If

            Dim dics As New Dictionary(Of String, String)
            dics.Add("No", "No")
            dics.Add("EquName", "EquName")
            dics.Add("Qty", "Qty")
            dics.Add("IsExist", "IsExist")
            dics.Add("YPSDutyUserName", "YPSDutyUserName")
            dics.Add("SJDutyUserName", "SJDutyUserName")
            dics.Add("PlanDuedate", "PlanDuedate")
            dics.Add("RealDuedate", "RealDuedate")
            '手动添加sampleNO
            dics.Add("SampleNo", "SampleNo")

            _ypsDutyName = SampleCom.GetYPSUserName(_sampleNumber)
            _sjDutyName = SampleCom.GetEquUserName(_sampleNumber)
            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值
            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    '[No],[EquName],[Qty],[SampleNo],[IsExist],[YPSDutyUserName],[SJDutyUserName],[PlanDuedate],[RealDuedate]
                    usercopy.Rows.Add(row(CDImportGridOfEqu.No).ToString(), row(CDImportGridOfEqu.EquName).ToString(), row(CDImportGridOfEqu.Qty).ToString,
                                       "0", _ypsDutyName, _sjDutyName, "", "", _sampleNumber)
                End If
            Next
            Call SampleCom.DeleteEqu(_sampleNumber)
            Dim errMsg As String = String.Empty
            '数据库表中有A、B、C三列，其中B列有默认值，这时用于插入的DataTable不能只有A、C两列, 
            '[No],[EquName],[Qty],[SampleNo],[IsExist],[YPSDutyUserName],[SJDutyUserName],[PlanDuedate],[RealDuedate]
            If DbOperateUtils.BulkCopy(usercopy, "m_SampleEqu_t", dics, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    ' MessageUtils.ShowInformation("成功导入！")
                    ' SearchRecord("")
                End If
            End If
            UploadFileOfEqu = True
        Catch ex As Exception
            UploadFileOfEqu = False
            lblMsg.Text = ex.Message
        End Try
    End Function

    Private Function UploadFileOfZEqu() As Boolean
        Dim errorMsg As String = Nothing
        Try
            '取得用户上传表数据 'EquName
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(txtEquFilePath.Text, "治工具清单", 0, 0, errorMsg)

            Dim column As DataColumn
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SampleNo"
            dtUploadData.Columns.Add("SampleNo")

            ChangeCDDataTableColumnName(dtUploadData, SheetType.ZEqu)
            Dim DrrR As DataRow() = dtUploadData.Select(" ZEquName IS NOT NULL ") '防止追加

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics As New Dictionary(Of String, String)
            dics.Add("No", "No")
            dics.Add("ZEquName", "ZEquName")
            dics.Add("Qty", "Qty")
            dics.Add("IsShare", "IsShare")
            dics.Add("SharePN", "SharePN")
            dics.Add("ZJDutyUserName", "ZJDutyUserName")
            dics.Add("PlanDuedate", "PlanDuedate")
            dics.Add("RealDuedate", "RealDuedate")
            dics.Add("SampleNo", "SampleNo")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            _zjDutyName = SampleCom.GetZJUserName(_sampleNumber)

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    usercopy.Rows.Add(row(CDImportGridOfZEqu.No).ToString, row(CDImportGridOfZEqu.ZEquName).ToString, row(CDImportGridOfZEqu.Qty).ToString,
                                      row(CDImportGridOfZEqu.IsShare).ToString, row(CDImportGridOfZEqu.SharePN).ToString, _zjDutyName,
                                      row(CDImportGridOfZEqu.PlanDuedate).ToString, row(CDImportGridOfZEqu.RealDuedate).ToString, _sampleNumber)
                End If
            Next

            Call SampleCom.DeleteZEqu(_sampleNumber)

            Dim errMsg As String = String.Empty
            '数据库表中有A、B、C三列，其中B列有默认值，这时用于插入的DataTable不能只有A、C两列, 
            If DbOperateUtils.BulkCopy(usercopy, "m_SampleZEqu_t", dics, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    ' MessageUtils.ShowInformation("成功导入！")
                End If
            End If
            UploadFileOfZEqu = True
        Catch ex As Exception
            UploadFileOfZEqu = False
            lblMsg.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "UploadFileOfZEqu", "sys")
        End Try
    End Function

    Private Function UploadFileOfModel() As Boolean
        Dim errorMsg As String = Nothing
        Try
            '取得用户上传表数据 'EquName
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(txtEquFilePath.Text, "模具清单", 0, 0, errorMsg)

            Dim column As DataColumn
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SampleNo"
            dtUploadData.Columns.Add("SampleNo")

            ' No ModelName Qty IsShare SharePN RDUserName PlanDuedate RealDuedate
            ChangeCDDataTableColumnName(dtUploadData, SheetType.Model)

            Dim DrrR As DataRow() = dtUploadData.Select(" ModelName IS NOT NULL ") '防止追加

            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics As New Dictionary(Of String, String)
            dics.Add("No", "No")
            dics.Add("ModelName", "ModelName")
            dics.Add("Qty", "Qty")
            dics.Add("IsShare", "IsShare")
            dics.Add("SharePN", "SharePN")
            dics.Add("RDUserName", "RDUserName")
            dics.Add("PlanDuedate", "PlanDuedate")
            dics.Add("RealDuedate", "RealDuedate")
            dics.Add("SampleNo", "SampleNo")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

            _rdDutyName = SampleCom.GetRDUserName(_sampleNumber)

            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    usercopy.Rows.Add(row(CDImportGridOfModel.No).ToString(), row(CDImportGridOfModel.ModelName).ToString(), row(CDImportGridOfModel.Qty).ToString,
                                      row(CDImportGridOfModel.IsShare).ToString, row(CDImportGridOfModel.SharePN).ToString, _rdDutyName,
                                      row(CDImportGridOfModel.PlanDuedate).ToString, row(CDImportGridOfModel.RealDuedate).ToString, _sampleNumber)
                End If
            Next

            Call SampleCom.DeleteModel(_sampleNumber)

            Dim errMsg As String = String.Empty
            '数据库表中有A、B、C三列，其中B列有默认值，这时用于插入的DataTable不能只有A、C两列, 
            'DB： No, equname,SampleNo, isexist
            If DbOperateUtils.BulkCopy(usercopy, "m_SampleModel_t", dics, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    ' SearchRecord("")
                End If
            End If
            UploadFileOfModel = True
        Catch ex As Exception
            UploadFileOfModel = False
            lblMsg.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "UploadFileOfModel", "sys")
        End Try
    End Function

    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub

    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable, ByVal iType As Integer)

        Select Case iType
            Case SheetType.Equ
                dt.Rows.RemoveAt(0)
                dt.Rows.RemoveAt(0)
                For Each i As CDImportGridOfEqu In [Enum].GetValues(GetType(CDImportGridOfEqu))
                    dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGridOfEqu), i).ToString
                Next
                ' Case SheetType.BOM
                'dt.Rows.RemoveAt(0)
                'dt.Rows.RemoveAt(0)
                'For Each i As ImportToGridOfBOM In [Enum].GetValues(GetType(ImportToGridOfBOM))
                '    dt.Columns(i).ColumnName = [Enum].Parse(GetType(ImportToGridOfBOM), i).ToString
                'Next
            Case SheetType.ZEqu
                dt.Rows.RemoveAt(0)
                dt.Rows.RemoveAt(0)
                dt.Rows.RemoveAt(0)
                For Each i As CDImportGridOfZEqu In [Enum].GetValues(GetType(CDImportGridOfZEqu))
                    dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGridOfZEqu), i).ToString
                Next
            Case SheetType.Model
                dt.Rows.RemoveAt(0)
                dt.Rows.RemoveAt(0)
                dt.Rows.RemoveAt(0)
                For Each i As CDImportGridOfModel In [Enum].GetValues(GetType(CDImportGridOfModel))
                    dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGridOfModel), i).ToString
                Next
        End Select
    End Sub

    Private Sub TabSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabSheet.SelectedIndexChanged
        LoadSheet()
    End Sub

    Private Sub LoadSheet()
        Dim strWhereSQL As String = String.Empty
        Try
            Dim StrSql As String = ""
            Dim index = TabSheet.SelectedIndex

            LoadData(StrSql, [Enum].Parse(GetType(SheetType), index.ToString))
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadData(ByVal Sql As String, ByVal type As SheetType)
        Dim strWhereSQL As String = String.Empty
        Dim strOrderBySQL As String = String.Empty
        Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
        col.Name = "选择"
        col.ReadOnly = False
        col.TrueValue = True
        col.FalseValue = False

        If Not String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            strWhereSQL = " AND a.SampleNO = '" & Me.txtSampleNo.Text.Trim & "'"
        Else
            Exit Sub
        End If

        Select Case type
            Case SheetType.Equ
                strOrderBySQL = " ORDER BY a.No"
                Sql = " SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist,a.SampleNO,NO,EquName,a.Qty, " & _
                      " b.YPSUserName as YPSDutyUserName,b.EquUserName as SJDutyUserName, " & _
                      " CONVERT(varchar(100), [PlanDuedate], 111) PlanDuedate , CONVERT(varchar(100), [RealDueDate], 111) RealDueDate" & _
                      " FROM m_SampleEqu_t a Left Join m_Sample_t b on a.SampleNO = b.SampleNo  " & _
                      " WHERE 1=1 " & strWhereSQL & strOrderBySQL
                'Case SheetType.BOM
                'Sql = " SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist,SampleNO,NO,PartNo,Specs,supplier,Qty,Unit,CCDutyUserName,SGDutyUserName,PlanDueDate,RealDueDate" & _
                '      " FROM m_SampleBOM_t a  WHERE 1=1 " & strWhereSQL & strOrderBySQL
            Case SheetType.ZEqu
                strOrderBySQL = " ORDER BY a.No"
                Sql = " SELECT a.SampleNO as SampleNO_ZEqu ,NO,ZEquName,a.Qty, IsShare,SharePN,b.ZJUserName as ZJDutyUserName,PlanDueDate,RealDueDate" & _
                      " FROM m_SampleZEqu_t a LEFT JOIN m_Sample_t b on a.SampleNO = b.SampleNo " & _
                      " WHERE 1=1 " & strWhereSQL & strOrderBySQL
            Case SheetType.Model
                strOrderBySQL = " ORDER BY a.No"
                Sql = " SELECT a.SampleNO, NO , ModelName,a.Qty, IsShare,SharePN,b.RDUserName,PlanDueDate,RealDueDate" & _
                      " FROM m_SampleModel_t a LEFT JOIN m_Sample_t b on a.SampleNO = b.SampleNo  " & _
                      " WHERE 1=1 " & strWhereSQL & strOrderBySQL
            Case SheetType.Document    '"TabDocument"
                'Sql = " SELECT SampleNO 样品单号, type 文件类型, path 文件路径  " & _
                '      " FROM m_SampleDocument_t a  " & _
                '      " WHERE 1 = 1 " & strWhereSQL
                Sql = " SELECT SampleNo,type, path   " & _
                      " FROM m_SampleDocument_t a  " & _
                      " WHERE 1 = 1 " & strWhereSQL
        End Select

        Using dt As DataTable = DbOperateUtils.GetDataTable(Sql)
            Select Case type
                Case SheetType.Equ
                    If Not IsNothing(dgvEqu) AndAlso Me.dgvEqu.Rows.Count > 0 Then
                        Me.dgvEqu.Rows.Clear()
                    End If
                    For Each row As DataRow In dt.Rows
                        'IIf(isnull(IsExist,'')='',0,IsExist) IsExist,SampleNO , NO , EquName , PlanDueDate , RealDueDate 
                        dgvEqu.Rows.Add(row("IsExist").ToString, row("SampleNO").ToString,
                                        row("No").ToString, row("EquName").ToString, row("Qty").ToString,
                                        row("YPSDutyUserName").ToString, row("SJDutyUserName").ToString,
                                        row("PlanDuedate").ToString, row("RealDueDate").ToString)
                    Next
                    Me.dgvEqu.ClearSelection()
                    Me.m_ChkboxAll.Text = "选择"
                    Me.dgvEqu.Controls.Add(Me.m_ChkboxAll)
                    AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
                    AddHandler dgvEqu.CellPainting, AddressOf dgvEqu_CellPainting
                Case SheetType.ZEqu
                    'first clear data
                    If (Not IsNothing(Me.dgvZEqu)) AndAlso Me.dgvZEqu.Rows.Count > 0 Then
                        dgvZEqu.Rows.Clear()
                    End If

                    Dim o_tempIsShareValue As String = ""
                    Dim cmbTmp As DataGridViewComboBoxColumn
                    cmbTmp = dgvZEqu.Columns("IsShare")
                    SampleCom.GetIsShareList(cmbTmp)
                    For Each dr As DataRow In dt.Rows
                        o_tempIsShareValue = dr.Item("IsShare").ToString
                        'SampleNO as SampleNO_ZEqu ,NO,ZEquName,Qty,IsShare,SharePN,ZJDutyUserName,PlanDueDate,RealDueDate
                        dgvZEqu.Rows.Add(dr.Item(enumdgvZEqu.SampleNo),
                                         dr.Item(enumdgvZEqu.No), dr.Item(enumdgvZEqu.ZEquName),
                                         dr.Item(enumdgvZEqu.Qty),
                                         o_tempIsShareValue, dr.Item(enumdgvZEqu.SharePN), dr.Item(enumdgvZEqu.ZJDutyUserName),
                                         dr.Item(enumdgvZEqu.PlanDueDate), dr.Item(enumdgvZEqu.RealDueDate))
                    Next
                    Me.dgvZEqu.ClearSelection()
                Case SheetType.Model
                    If (Not IsNothing(Me.dgvModel)) AndAlso Me.dgvModel.Rows.Count > 0 Then
                        dgvModel.Rows.Clear()
                    End If
                    Dim o_tempIsShareValue As String = ""
                    Dim cmbTmp As DataGridViewComboBoxColumn
                    cmbTmp = dgvModel.Columns("IsShare_Model")
                    SampleCom.GetIsShareList(cmbTmp)
                    For Each dr As DataRow In dt.Rows
                        o_tempIsShareValue = dr.Item("IsShare").ToString
                        ' SampleNO, NO , ModelName,Qty, IsShare,SharePN,RDUserName,PlanDueDate,RealDueDate
                        dgvModel.Rows.Add(dr.Item(enumdgvModel.SampleNo),
                                         dr.Item(enumdgvModel.No), dr.Item(enumdgvModel.ModelName),
                                         dr.Item(enumdgvModel.Qty),
                                         o_tempIsShareValue, dr.Item(enumdgvModel.SharePN), dr.Item(enumdgvModel.RDUserName),
                                         dr.Item(enumdgvModel.PlanDueDate), dr.Item(enumdgvModel.RealDueDate))
                    Next
                    Me.dgvModel.ClearSelection()
                Case SheetType.Document
                    ' SetColumnsProperty(col, dgvDocument, dt)
                    'first clear data
                    If (Not IsNothing(Me.dgvDocument)) AndAlso Me.dgvDocument.Rows.Count > 0 Then
                        dgvDocument.Rows.Clear()
                    End If
                    For Each dr As DataRow In dt.Rows
                        dgvDocument.Rows.Add(dr.Item(enumdgvDocument.SampleNo),
                                             dr.Item(enumdgvDocument.type), dr.Item(enumdgvDocument.path)
                                             )
                    Next
                    dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Case Else
                    ' Case SheetType.BOM
                    'first clear data
                    'If (Not IsNothing(Me.dgvBOM)) AndAlso Me.dgvBOM.Rows.Count > 0 Then
                    '    dgvBOM.Rows.Clear()
                    'End If

                    'For Each dr As DataRow In dt.Rows
                    '    dgvBOM.Rows.Add(dr.Item("IsExist").ToString, dr.Item(enumdgvBOM.SampleNo), dr.Item(enumdgvBOM.No), dr.Item(enumdgvBOM.PartNumber),
                    '                     dr.Item(enumdgvBOM.Specs), dr.Item(enumdgvBOM.supplier), dr.Item(enumdgvBOM.Qty),
                    '                     dr.Item(enumdgvBOM.Unit), dr.Item(enumdgvBOM.CCDutyUserName), dr.Item(enumdgvBOM.SGDutyUserName),
                    '                     dr.Item(enumdgvBOM.PlanDueDate), dr.Item(enumdgvBOM.RealDueDate))
                    'Next
                    'Me.dgvBOM.ClearSelection()
            End Select
        End Using
    End Sub

    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        If Me.dgvEqu.Rows.Count <= 0 Then Exit Sub

        Me.dgvEqu.EndEdit()

        For Each Row As DataGridViewRow In Me.dgvEqu.Rows
            Row.Cells(0).Value = IIf(m_ChkboxAll.Checked = True, "1", "0")
        Next
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
        dgGrid.DataSource = dt
        ' dgGrid.Columns.Insert(0, col)
        '"备注"列全屏显示
        ' dgGrid.Columns(EquipmentGrid.ID).Visible = False
        'dgGrid.Columns(EquipmentGrid.Remark).Visible = False

        ' ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
        dgGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Me.txtSampleNo.Enabled = True
    End Sub

    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        Dim strPartNO As String = "", strFormatDes As String = "", strMadeQty As String = ""
        Dim SqlStr As String = ""
        Try
            If Not String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                If String.IsNullOrEmpty(Me.txtPartNo.Text) Then
                    strPartNO = SampleCom.GetPNInfo(Me.txtSampleNo.Text, strFormatDes, strMadeQty)
                    Me.txtPartNo.Text = strPartNO
                    If String.IsNullOrEmpty(strFormatDes) Then
                        MessageUtils.ShowError(" 请先维护样品的规格描述！")
                        Exit Sub
                    Else
                        Me.txtFormatDes.Text = strFormatDes
                    End If
                End If
            Else
                Call ClearUI()
                Exit Sub
            End If

            Me.txtRCardFilePath.Text = ""
            Me.txtCutFilePath.Text = ""
            Me.txtBlueFilePath.Text = ""
            Me.txtEquFilePath.Text = ""

            Me.txtBlueTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.蓝图.ToString)
            Me.txtCutTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.裁线卡.ToString)
            Me.txtRCardTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.流程卡.ToString)
            Me.txtZEquTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.治具开立资料.ToString)
            Me.txtCBlueTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.客户蓝图.ToString)
            Me.txtPackTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.包规.ToString)
            Me.txtBOMTimes.Text = SampleCom.GetUploadTimes(Me.txtSampleNo.Text, SampleCom.enumRDDocumentType.BOM.ToString)
            If Me.txtSampleNo.Text <> "" Then
                SqlStr = " AND a.SAMPLENO = '" & Trim(Me.txtSampleNo.Text) & "'"
            End If

            SearchRecord(SqlStr)

        Catch ex As Exception

            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "ToolRefresh_Click", "Sample")
        End Try
    End Sub

    Private Sub ClearUI()
        Me.txtRCardFilePath.Text = ""
        Me.txtCutFilePath.Text = ""
        Me.txtBlueFilePath.Text = ""
        Me.txtEquFilePath.Text = ""
        Me.txtCBlueFilePath.Text = ""
        Me.txtPackFilePath.Text = ""
        Me.txtPartNo.Text = ""
        Me.txtFormatDes.Text = ""
    End Sub

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        Select Case TabSheet.SelectedTab.Name
            Case "TabEqu"
                dt = GetSheetInfo(Sqlstring)
                If Not IsNothing(dgvEqu) AndAlso dgvEqu.Rows.Count > 0 Then
                    dgvEqu.Rows.Clear()
                End If

                For Each row As DataRow In dt.Rows
                    'IsExist,SampleNO , NO , EquName, Qty, YPSDutyName,SJDutyName, PlanDueDate , RealDueDate 
                    dgvEqu.Rows.Add(row("IsExist").ToString, row(enumdgvEqu.SampleNo).ToString, row(enumdgvEqu.No).ToString,
                                     row(enumdgvEqu.EquName).ToString, row(enumdgvEqu.Qty).ToString, row(enumdgvEqu.YPSDutyName).ToString,
                                     row(enumdgvEqu.SJDutyName).ToString, row(enumdgvEqu.PlanDueDate).ToString, row(enumdgvEqu.RealDueDate).ToString
                                    )
                Next

                For rowIndex As Integer = 0 To dgvEqu.Rows.Count - 1
                    If dgvEqu.Rows(rowIndex).Cells(0).FormattedValue = "1" Then
                        For colIndex As Integer = 0 To dgvEqu.Rows(rowIndex).Cells.Count - 1
                            If colIndex = 0 Then
                                dgvEqu.Rows(rowIndex).Cells(0).ReadOnly = False
                            Else
                                dgvEqu.Rows(rowIndex).Cells(colIndex).ReadOnly = True
                            End If
                        Next
                    Else
                        ' dgvEqu.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGray
                        For colIndex As Integer = 0 To dgvEqu.Rows(rowIndex).Cells.Count - 1
                            If colIndex = 0 Then
                                dgvEqu.Rows(rowIndex).Cells(0).ReadOnly = False
                            Else
                                dgvEqu.Rows(rowIndex).Cells(colIndex).ReadOnly = False
                            End If
                        Next
                    End If
                Next
                dgvEqu.ClearSelection()
                Me.m_ChkboxAll.Text = "选择"
                Me.dgvEqu.Controls.Add(Me.m_ChkboxAll)
                AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
                AddHandler dgvEqu.CellPainting, AddressOf dgvEqu_CellPainting
            Case "TabBOM"
                'dt = GetSheetInfo(Sqlstring)
                'For Each dr As DataRow In dt.Rows
                '    ' IsExist, SampleNO , NO , PartNo , Specs,supplier ,Qty ,Unit,CCDutyUserName,SGDutyUserName,PlanDueDate,RealDueDate
                '    dgvBOM.Rows.Add(dr.Item("IsExist").ToString(), dr.Item(enumdgvBOM.SampleNo), dr.Item(enumdgvBOM.No), _
                '                     dr.Item(enumdgvBOM.PartNumber), dr.Item(enumdgvBOM.Specs), dr.Item(enumdgvBOM.supplier), _
                '                     dr.Item(enumdgvBOM.Qty), dr.Item(enumdgvBOM.Unit), dr.Item(enumdgvBOM.CCDutyUserName), _
                '                     dr.Item(enumdgvBOM.SGDutyUserName), dr.Item(enumdgvBOM.PlanDueDate), dr.Item(enumdgvBOM.RealDueDate)
                '                     )
                'Next
                'dgvBOM.ClearSelection()
            Case "TabZEqu"
                dt = GetSheetInfo(Sqlstring)
                'first clear data
                If (Not IsNothing(Me.dgvZEqu)) AndAlso Me.dgvZEqu.Rows.Count > 0 Then
                    Me.dgvZEqu.Rows.Clear()
                End If

                Dim o_tempIsShareValue As String = ""
                Dim cmbTmp As DataGridViewComboBoxColumn
                cmbTmp = dgvZEqu.Columns("IsShare")
                SampleCom.GetIsShareList(cmbTmp)

                For Each dr As DataRow In dt.Rows
                    o_tempIsShareValue = dr.Item("IsShare").ToString

                    dgvZEqu.Rows.Add(dr.Item(enumdgvZEqu.SampleNo), dr.Item(enumdgvZEqu.No), dr.Item(enumdgvZEqu.ZEquName),
                                     dr.Item(enumdgvZEqu.Qty), o_tempIsShareValue, dr.Item(enumdgvZEqu.SharePN),
                                     dr.Item(enumdgvZEqu.ZJDutyUserName), dr.Item(enumdgvZEqu.PlanDueDate), dr.Item(enumdgvZEqu.RealDueDate))
                Next
                dgvZEqu.ClearSelection()
            Case "TabModel"
                dt = GetSheetInfo(Sqlstring)
                'dgvModel.DataSource = dt
                If (Not IsNothing(Me.dgvModel)) AndAlso Me.dgvModel.Rows.Count > 0 Then
                    Me.dgvModel.Rows.Clear()
                End If

                Dim o_tempIsShareValue As String = ""
                Dim cmbTmp As DataGridViewComboBoxColumn
                cmbTmp = dgvModel.Columns("IsShare_Model")
                SampleCom.GetIsShareList(cmbTmp)

                For Each dr As DataRow In dt.Rows
                    o_tempIsShareValue = dr.Item("IsShare").ToString
                    dgvModel.Rows.Add(dr.Item(enumdgvModel.SampleNo),
                                      dr.Item(enumdgvModel.No), dr.Item(enumdgvModel.ModelName), o_tempIsShareValue, dr.Item(enumdgvModel.SharePN),
                                      dr.Item(enumdgvModel.RDUserName), dr.Item(enumdgvModel.PlanDueDate), dr.Item(enumdgvModel.RealDueDate))
                Next
                dgvModel.ClearSelection()
            Case "TabDocument"
                dt = GetSheetInfo(Sqlstring)
                dgvDocument.DataSource = dt
                Me.dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                dgvDocument.ClearSelection()
            Case Else
                'do nothing
        End Select
    End Sub

    Public Function GetSheetInfo(Sqlstring As String) As DataTable
        Dim dt As New DataTable
        Dim StrSql As String = ""

        Select Case TabSheet.SelectedTab.Name
            Case "TabEqu"
                StrSql = "SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist,a.SampleNO,NO,EquName, a.Qty, b.YPSUserName as YPSDutyUserName,b.EquUserName as SJDutyUserName," & _
                    " CONVERT(varchar(100), PlanDuedate, 111) PlanDuedate, CONVERT(varchar(100), RealDueDate, 111)RealDueDate  " & _
                    " FROM m_SampleEqu_t a  LEFT JOIN m_Sample_t b ON a.SampleNO = b.SampleNO " & _
                    " WHERE 1=1 " & Sqlstring
                StrSql = StrSql & " ORDER BY no"
            Case "TabBOM"
                ' [No],[SampleNo],[PartNo] ,[Specs],[supplier],[Unit],[Qty],[PlanDuedate],[RealDuedate]
                'StrSql = "SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist, SampleNO, NO , PartNo, Specs ,supplier,Qty, Unit, CCDutyUserName, SGDutyUserName, PlanDueDate, RealDueDate" & _
                '" FROM m_SampleBOM_t a  " & _
                '" WHERE 1=1 " & Sqlstring
                StrSql = StrSql & " ORDER BY no"
            Case "TabZEqu"
                ' [No] ,[ZEquName],[IsShare] ,[SharePN],[PlanDuedate],[RealDuedate] ,[SampleNo]
                StrSql = "SELECT a.SampleNO, NO , ZEquName, a.Qty,IsShare ,SharePN ,b.ZJUserName as ZJDutyUserName ,PlanDueDate, RealDueDate" & _
                " FROM m_SampleZEqu_t a  LEFT JOIN m_Sample_t b ON a.SampleNO = b.SampleNO " & _
                " WHERE 1=1 " & Sqlstring
                StrSql = StrSql & " ORDER BY no"
            Case "TabModel"
                StrSql = "SELECT a.SampleNO,NO,ModelName, a.Qty, IsShare ,SharePN ,b.RDUserName,PlanDueDate, RealDueDate" & _
                " FROM m_SampleModel_t a LEFT JOIN m_Sample_t b ON a.SampleNO = b.SampleNO " & _
                " WHERE 1=1 " & Sqlstring
                StrSql = StrSql & " ORDER BY no"
            Case "TabDocument"
                '  StrSql = " SELECT SampleNO 样品单号, type 文件类型, path 文件路径  " & _
                '" FROM m_SampleDocument_t a  Where 1=1 " & Sqlstring
                'StrSql = StrSql & " ORDER BY SampleNO"

                StrSql = " SELECT SampleNo, type , path  " & _
                         " FROM m_SampleDocument_t a  WHERE 1=1 " & Sqlstring
                StrSql = StrSql & " ORDER BY SampleNo"
            Case Else
                'do nothing
        End Select

        dt = DbOperateUtils.GetDataTable(StrSql)
        Return dt
    End Function

#Region "上传处理"
    '上传蓝图
    Private Sub btnImportBlue_Click(sender As Object, e As EventArgs) Handles btnImportBlue.Click
        Call ImportBlue()
        MessageUtils.ShowInformation("上传蓝图成功!")
    End Sub

    Private Sub ImportBlue()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.BlueFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)

            Dim BlueFilePath As String = Me.txtBlueFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.BlueFileName)
            File.Copy(BlueFilePath, ServerFile, True)
        Else '未选择上传
            Exit Sub
        End If

        Call UpdatePathToDB(DocumentType.Blue, ServerFile)
    End Sub

    '选择 流程卡
    Private Sub btnUploadRCard_Click(sender As Object, e As EventArgs) Handles btnUploadRCard.Click
        btnUploadRCard.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog2.ShowDialog()
        OpenFileDialog2.Filter = "Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtRCardFilePath.Text = OpenFileDialog2.FileName
            Me.RCardFileName = OpenFileDialog2.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadRCard.Enabled = True
    End Sub

    '选择上传蓝图
    Private Sub btnUploadBlue_Click(sender As Object, e As EventArgs) Handles btnUploadBlue.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        Dim strPartNo As String = "", strFormatdes As String = "", strMadeQty As String = ""

        'check whether have maintain 研发数量
        strPartNo = SampleCom.GetPNInfo(_sampleNumber, strFormatdes, strMadeQty)

        If String.IsNullOrEmpty(strMadeQty) Then
            MessageUtils.ShowError("请先维护制样数量!")
            Exit Sub
        End If

        btnUploadBlue.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtBlueFilePath.Text = OpenFileDialog1.FileName
            Me.BlueFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadBlue.Enabled = True
    End Sub

    '选择上传客户蓝图
    Private Sub btnUploadCBlue_Click(sender As Object, e As EventArgs) Handles btnUploadCBlue.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        btnUploadCBlue.Enabled = False
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtCBlueFilePath.Text = OpenFileDialog1.FileName
            Me.CusBlueFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadCBlue.Enabled = True
    End Sub

    Private m_DocumentPath As String = ""
    '选择裁线卡
    Private Sub btnUploadCut_Click(sender As Object, e As EventArgs) Handles btnUploadCut.Click
        btnUploadCut.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtCutFilePath.Text = OpenFileDialog1.FileName
            Me.CutFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadCut.Enabled = True
    End Sub

    '上传裁线卡
    Private Sub btnImportCut_Click(sender As Object, e As EventArgs) Handles btnImportCut.Click
        Call ImportCut()
        MessageUtils.ShowInformation("上传裁线卡成功！")
    End Sub

    '上传流程卡
    Private Sub btnImportRCard_Click(sender As Object, e As EventArgs) Handles btnImportRCard.Click
        Call ImportRCard()
        MessageUtils.ShowInformation("上传流程卡成功！")
    End Sub

#Region "上传并保存到DB"
    Private Sub ImportRCard()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.RCardFileName) Then

            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim RCardFilePath As String = Me.txtRCardFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.RCardFileName)
            File.Copy(RCardFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If
        Call UpdatePathToDB(DocumentType.RCard, ServerFile)
    End Sub

    Private Sub ImportCut()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.CutFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim CutFilePath As String = Me.txtCutFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.CutFileName)
            File.Copy(CutFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If

        Call UpdatePathToDB(DocumentType.Cut, ServerFile)
    End Sub

    Private Sub ImportZEqu()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.ZEquFileName) Then

            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
            Dim ZEquFilePath As String = Me.txtZEquFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.ZEquFileName)
            File.Copy(ZEquFilePath, ServerFile, True)
        Else '未选择上传
            'ServerFile = SopFilePath
            Exit Sub
        End If
        Call UpdatePathToDB(DocumentType.ZEqu, ServerFile)
    End Sub
#End Region

    '选择上传 治具开立资料
    Private Sub btnUploadZEqu_Click(sender As Object, e As EventArgs) Handles btnUploadZEqu.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        btnUploadZEqu.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*" '"Excel files(*.xls)|*.xls;*.xlsx"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtZEquFilePath.Text = OpenFileDialog1.FileName
            Me.ZEquFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadZEqu.Enabled = True
    End Sub

    Private Sub btnImportZEqu_Click(sender As Object, e As EventArgs) Handles btnImportZEqu.Click
        Call ImportZEqu()
        MessageUtils.ShowInformation("上传治具开立资料成功！")
    End Sub

#End Region

    Private Sub UpdatePathToDB(ByVal iDocumentType As Integer, ByVal strPath As String)
        Dim lsSQL As New StringBuilder
        Dim o_strExecSQLResult As String = ""
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId
            Dim currentUserName As String = SampleCom.GetUserName(userID)
            arrayList.Add("SampleNo|" & _sampleNumber)
            arrayList.Add("DocumentType|" & iDocumentType)
            arrayList.Add("Path|" & strPath)
            arrayList.Add("UserName|" & currentUserName)
            o_strExecSQLResult = DbOperateUtils.ExecuteNonQureyByProc("m_SampleUpload_p", arrayList)
            If o_strExecSQLResult <> "" Then
                ' Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "UpdatePathToDB", "Sample")
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolEquConfirm_Click(sender As Object, e As EventArgs) Handles ToolEquConfirm.Click
        Dim Sql As New StringBuilder
        Dim sTempIsExist As String = String.Empty
        Dim tempSampleNO As String = String.Empty
        Dim SqlStr As String = String.Empty
        Try
            Select Case TabSheet.SelectedTab.Name
                Case "TabEqu"
                    If Me.dgvEqu.Rows.Count > 0 Then
                        _sampleNumber = dgvEqu.Rows(0).Cells(1).FormattedValue.ToString
                    End If

                    For Each row As DataGridViewRow In dgvEqu.Rows
                        If row.Cells(1).FormattedValue.ToString <> "" Then
                            If row.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                                sTempIsExist = "1"
                            Else
                                sTempIsExist = "0"
                            End If
                            Sql.Append(" UPDATE m_SampleEqu_t SET IsExist = '" & sTempIsExist & "'")
                            Sql.Append(" WHERE SampleNO ='" & row.Cells(1).FormattedValue.ToString & "' AND NO = '" & row.Cells(enumdgvEqu.No).Value.ToString & "'")
                        End If
                    Next

                    If Sql.ToString <> "" Then
                        DbOperateUtils.ExecSQL(Sql.ToString)
                    End If
                    'Send to next step
                    Call EquSendNext(SampleCom.enumLevelID.EquConfirm)
                    If Me.txtSampleNo.Text <> "" Then
                        SqlStr = " AND a.SAMPLENO LIKE '" & Trim(Me.txtSampleNo.Text) & "%'"
                    End If
                    SearchRecord(SqlStr)
                Case "TabBOM"
                    'If Me.dgvBOM.Rows.Count > 0 Then
                    '    _sampleNumber = dgvBOM.Rows(0).Cells(1).FormattedValue.ToString
                    'End If

                    'For Each row As DataGridViewRow In dgvBOM.Rows
                    '    If row.Cells(1).FormattedValue.ToString <> "" Then
                    '        If row.Cells(0).EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    '            sTempIsExist = "1"
                    '        Else
                    '            sTempIsExist = "0"
                    '        End If
                    '        Sql.Append(" UPDATE m_SampleBOM_t SET IsExist = '" & sTempIsExist & "'")
                    '        Sql.Append(" WHERE SampleNO ='" & row.Cells(enumdgvBOM.SampleNo).FormattedValue.ToString & "' AND NO = '" & row.Cells(enumdgvBOM.No).Value.ToString & "' AND PartNo = '" & row.Cells(enumdgvBOM.PartNumber).Value.ToString & "'")
                    '    End If
                    'Next

                    'If Sql.ToString <> "" Then
                    '    DbOperateUtils.ExecSQL(Sql.ToString)
                    'End If
                    ''Send to next step
                    'Call EquSendNext(SampleCom.enumLevelID.MaterialGive)
                    'If Me.txtSampleNo.Text <> "" Then
                    '    SqlStr = " AND a.SAMPLENO LIKE '" & Trim(Me.txtSampleNo.Text) & "%'"
                    'End If
                    'SearchRecord(SqlStr)
                    'MessageUtils.ShowInformation("保存成功!")
                Case Else
                    'do nothing
            End Select

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "ToolEquConfirm_Click", "Sample")
        End Try
    End Sub

    Private Sub EquSendNext(ByVal iCurrentLevelID As Integer)
        Dim o_strExecSQLResult As String = String.Empty
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId
            arrayList.Add("SampleNo|" & _sampleNumber)
            arrayList.Add("LevelID|" & iCurrentLevelID)

            o_strExecSQLResult = DbOperateUtils.ExecuteNonQureyByProc("m_SampleEqu_p", arrayList)
            If o_strExecSQLResult <> "" Then
                ' ShowMessage(File & "导入失败->" & o_strExecSQLResult)
                MessageUtils.ShowError(o_strExecSQLResult)
            End If
            MessageUtils.ShowInformation("保存信息成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "EquSendNext", "WIP")
        End Try
    End Sub

    Private Sub toolEquDateSave_Click(sender As Object, e As EventArgs)
        Dim sql As New StringBuilder
        Dim stempPlanDuedate As String = "", stempRealDuedate As String = ""

        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("样品单号不能为空！")
            Exit Sub
        Else
            _sampleNumber = Me.txtSampleNo.Text.Trim
        End If

        For Each row As DataGridViewRow In dgvEqu.Rows
            If row.Cells(0).FormattedValue.ToString.ToUpper = "TRUE" Then
                Continue For
            Else
                If DbOperateUtils.DBNullToStr(row.Cells(enumdgvEqu.PlanDueDate).Value) = "" Then
                    MessageUtils.ShowError(" NO: [" & row.Cells(enumdgvEqu.No).Value & "]预计交期没有维护，请检查!")
                    Exit Sub
                End If
            End If
        Next

        For Each row As DataGridViewRow In dgvEqu.Rows
            If row.Cells(0).FormattedValue.ToString.ToUpper = "TRUE" Then
                Continue For
            Else
                stempPlanDuedate = row.Cells(enumdgvEqu.PlanDueDate).EditedFormattedValue.ToString()
                stempRealDuedate = row.Cells(enumdgvEqu.RealDueDate).EditedFormattedValue.ToString()
                sql.Append(" UPDATE m_SampleEqu_t SET PlanDuedate = '" & stempPlanDuedate & "', RealDuedate  = '" & stempRealDuedate & "'")
                sql.Append(" WHERE SampleNO ='" & row.Cells(enumdgvEqu.SampleNo).FormattedValue.ToString & "' AND NO = '" & row.Cells(enumdgvEqu.No).Value.ToString & "'")
            End If
        Next

        If sql.ToString <> "" Then
            DbOperateUtils.ExecSQL(sql.ToString)
        End If

        If Not SampleCom.CheckIsEquDateFinish(Me.txtSampleNo.Text.Trim()) Then
            MessageUtils.ShowWarning("该样品单存在设备的预计交期没有维护！")
            Exit Sub
        Else
            'Send to next step
            Call EquSendNext(SampleCom.enumLevelID.EquGive)
        End If
    End Sub


#Region "治具事件"
    Private Sub dgvZEqu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvZEqu.CellDoubleClick
        Dim o_strSQL As New StringBuilder
        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = ""
        Try
            If e.RowIndex < 0 OrElse Me.dgvZEqu.Rows.Count <= 0 Then Exit Sub
            Me.dgvZEqu.EndEdit()
            Dim o_tempRealDate As Date

            o_strColumnName = dgvZEqu.CurrentCell.OwningColumn.Name

            Dim b As String = dgvZEqu.Columns(enumdgvZEqu.PlanDueDate).Name + "," + dgvZEqu.Columns(enumdgvZEqu.RealDueDate).Name
            If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then 'o_strColumnName.IndexOf(b) > 0 Then
                Dim FrmEditTime As New FrmEditTime
                FrmEditTime.ShowDialog()
            Else
                'not show time
            End If

            If SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
                Select Case o_strColumnName
                    Case dgvZEqu.Columns(enumdgvZEqu.PlanDueDate).Name
                        strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        o_strSQL.Append(" Update m_SampleZEqu_t Set PlanDueDate = '" & strPlanDate & "' ")
                        o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                        Me.dgvZEqu.CurrentCell.Value = strPlanDate
                    Case dgvZEqu.Columns(enumdgvZEqu.RealDueDate).Name
                        strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        If Not String.IsNullOrEmpty(strRealDate) Then
                            Date.TryParse(strRealDate, o_tempRealDate)
                            If Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
                                MessageUtils.ShowError("填入的日期不能早于今天！！")
                                Me.dgvZEqu.CurrentCell.Value = ""
                                Exit Sub
                            End If
                        Else
                            'do nothing
                        End If
                        o_strSQL.Append(" Update m_SampleZEqu_t Set RealDueDate = '" & strRealDate & "' ")
                        o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                        Me.dgvZEqu.CurrentCell.Value = strRealDate
                End Select

                If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
                    DbOperateUtils.ExecSQL(o_strSQL.ToString)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvZEqu_CellClick", "Sample")
        End Try
    End Sub

    Private Sub dgvZEqu_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvZEqu.CellValueChanged
        If e.RowIndex < 0 OrElse Me.dgvZEqu.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = "", strIsShare As String = "", strSharePN As String = "", strQty As String = ""
        Dim o_strSQL As New StringBuilder
        Dim o_tempRealDate As Date
        Dim o_blnUpdateMaxPlanDate As Boolean = False
        o_strColumnName = dgvZEqu.CurrentCell.OwningColumn.Name
        Select Case o_strColumnName
            Case dgvZEqu.Columns(enumdgvZEqu.PlanDueDate).Name
                strPlanDate = dgvZEqu.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleZEqu_t Set PlanDueDate = '" & strPlanDate & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                Me.dgvZEqu.CurrentCell.Value = strPlanDate
                o_blnUpdateMaxPlanDate = True
            Case dgvZEqu.Columns(enumdgvZEqu.RealDueDate).Name
                strRealDate = dgvZEqu.CurrentCell.EditedFormattedValue
                If Not String.IsNullOrEmpty(strRealDate) Then
                    Date.TryParse(strRealDate, o_tempRealDate)
                    If Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
                        MessageUtils.ShowError("填入的日期不能早于今天！！")
                        Me.dgvZEqu.CurrentCell.Value = ""
                        Exit Sub
                    End If
                Else
                    'do nothing
                End If
                '可能 需要把realDate清掉
                o_strSQL.Append(" Update m_SampleZEqu_t SET RealDueDate = '" & strRealDate & "' ")
                o_strSQL.Append(" WHERE SampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                Me.dgvZEqu.CurrentCell.Value = strRealDate
                o_blnUpdateMaxPlanDate = True
            Case dgvZEqu.Columns(enumdgvZEqu.IsShare).Name
                strIsShare = dgvZEqu.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleZEqu_t Set IsShare = N'" & strIsShare & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                Me.dgvZEqu.CurrentCell.Value = strIsShare
            Case dgvZEqu.Columns(enumdgvZEqu.SharePN).Name
                strSharePN = dgvZEqu.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleZEqu_t Set SharePN = N'" & strSharePN & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                Me.dgvZEqu.CurrentCell.Value = strSharePN
            Case dgvZEqu.Columns(enumdgvZEqu.Qty).Name
                strQty = Val(dgvZEqu.CurrentCell.EditedFormattedValue)
                o_strSQL.Append(" Update m_SampleZEqu_t Set Qty = '" & strQty & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
                Me.dgvZEqu.CurrentCell.Value = strQty
        End Select

        If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
            DbOperateUtils.ExecSQL(o_strSQL.ToString)

            If o_blnUpdateMaxPlanDate Then
                Dim o_SQL As New StringBuilder
                'MAX( cast(nullif(PlanDuedate,'') as date)),cq20161128
                o_SQL.Append(" Declare @MaxPlanDate datetime")
                o_SQL.Append(" SELECT @MaxPlanDate= MAX( cast(nullif(PlanDuedate,'') as date)) FROM m_SampleZEqu_t WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND isnull(IsShare,'') =N'否' AND isnull(RealDuedate,'') = ''")
                o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE SAMPLENO = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.ZEquGive & "'")
                DbOperateUtils.ExecSQL(o_SQL.ToString)
            End If
            'check All Plandate and DueDate finish
            If SampleCom.CheckIsZEquDateFinish(Me.txtSampleNo.Text.Trim) Then
                'update the step finish
                Call UpdateStatus(SheetType.ZEqu, 1)
            Else
                Call UpdateStatus(SheetType.ZEqu, 0)
            End If
        End If
    End Sub
#End Region

    Private Sub dgvModel_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModel.CellValueChanged
        If e.RowIndex < 0 OrElse Me.dgvModel.Rows.Count <= 0 Then Exit Sub

        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = "", strIsShare As String = "", strSharePN As String = "", strQty As String = ""
        Dim o_strSQL As New StringBuilder
        Dim blnUpdateMaxPlanDate As Boolean = False
        o_strColumnName = dgvModel.CurrentCell.OwningColumn.Name
        Dim o_tempRealDate As Date
        Select Case o_strColumnName
            Case dgvModel.Columns(enumdgvModel.PlanDueDate).Name
                strPlanDate = dgvModel.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleModel_t Set PlanDueDate = '" & strPlanDate & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                Me.dgvModel.CurrentCell.Value = strPlanDate
                blnUpdateMaxPlanDate = True
            Case dgvModel.Columns(enumdgvModel.RealDueDate).Name
                strRealDate = dgvModel.CurrentCell.EditedFormattedValue
                Date.TryParse(strRealDate, o_tempRealDate)
                If strRealDate <> "" AndAlso Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
                    MessageUtils.ShowError("填入的日期不能早于今天！！")
                    Me.dgvModel.CurrentCell.Value = ""
                    Exit Sub
                End If
                o_strSQL.Append(" Update m_SampleModel_t SET RealDueDate = '" & strRealDate & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                Me.dgvModel.CurrentCell.Value = strRealDate
                blnUpdateMaxPlanDate = True
            Case dgvModel.Columns(enumdgvModel.IsShare).Name
                strIsShare = dgvModel.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleModel_t Set IsShare = N'" & strIsShare & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                Me.dgvModel.CurrentCell.Value = strIsShare
                If strIsShare = "是" Then
                    dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.PlanDueDate).ReadOnly = True
                    dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.RealDueDate).ReadOnly = True
                Else
                    dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.PlanDueDate).ReadOnly = False
                    dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.RealDueDate).ReadOnly = False
                End If
            Case dgvModel.Columns(enumdgvModel.SharePN).Name
                strSharePN = dgvModel.CurrentCell.EditedFormattedValue
                o_strSQL.Append(" Update m_SampleModel_t Set SharePN = N'" & strSharePN & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                Me.dgvModel.CurrentCell.Value = strSharePN
            Case dgvModel.Columns(enumdgvModel.Qty).Name
                strQty = Val(dgvModel.CurrentCell.EditedFormattedValue)
                o_strSQL.Append(" Update m_SampleModel_t Set Qty = N'" & strSharePN & "' ")
                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                Me.dgvModel.CurrentCell.Value = strQty
        End Select

        If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
            DbOperateUtils.ExecSQL(o_strSQL.ToString)

            If blnUpdateMaxPlanDate Then
                Dim o_SQL As New StringBuilder
                'MAX( cast(nullif(PlanDuedate,'') as date))
                o_SQL.Append(" Declare @MaxPlanDate datetime")
                o_SQL.Append(" SELECT @MaxPlanDate= MAX( cast(nullif(PlanDuedate,'') as date)) FROM m_SampleModel_t WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND isnull(IsShare,'') =N'否' and isnull(RealDuedate,'') = ''")
                o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE SAMPLENO = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.Model & "'")
                DbOperateUtils.ExecSQL(o_SQL.ToString)
            End If

            'check All Plandate and DueDate finish
            If CheckIsModelDateFinish() Then
                'update the step finish
                Call UpdateStatus(SheetType.Model, 1)
            Else
                Call UpdateStatus(SheetType.Model, 0)
            End If
        End If
    End Sub

    Private Function CheckIsModelDateFinish() As Boolean
        Dim lsSQL As String = String.Empty

        '存在, 表明没完成
        lsSQL = "  SELECT SampleNO  FROM m_SampleModel_t(nolock) " & _
                "  WHERE 1=1 AND IsShare = N'否' " & _
                "  AND  (PlanDuedate = '' OR RealDuedate = '') AND sampleno = '" & Me.txtSampleNo.Text.Trim & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                CheckIsModelDateFinish = False
            Else
                CheckIsModelDateFinish = True
            End If
        End Using
        Return CheckIsModelDateFinish
    End Function

    Private Sub UpdateStatus(ByVal iType As Double, ByVal iFinishFlag As Integer)
        Dim lsSQL As New StringBuilder
        Select Case iType
            Case SheetType.Model
                If iFinishFlag = 1 Then
                    lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='1', FINISHTIME = getdate() ")
                    lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.Model & "'")
                Else
                    lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='0', FINISHTIME = NULL ")
                    lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.Model & "'")
                End If
            Case SheetType.ZEqu
                If iFinishFlag = 1 Then
                    lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='1', finishtime = getdate() ")
                    lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.ZEquGive & "'")

                    lsSQL.Append(" Update  m_Sample_t SET ZJFinishFlag ='1' WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' ")
                Else
                    lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='0', finishtime = NULL ")
                    lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.ZEquGive & "'")
                End If
            Case Else
                'Case SheetType.BOM
                '    If iFinishFlag = 1 Then
                '        lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='1', finishtime = getdate() ")
                '        lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.MaterialGive & "'")
                '        'Info 生管开始
                '        lsSQL.Append(" If NOT  EXISTS (SELECT TOP 1 1 FROM m_SampleD_t WHERE sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND levelid = '" & SampleCom.enumLevelID.BOMConfirm & "') ")
                '        lsSQL.Append(" Insert m_SampleD_t(SampleNO, LevelID, StartTime,PICUserName) ")
                '        lsSQL.Append(" Values('" & Me.txtSampleNo.Text.Trim & "','" & SampleCom.enumLevelID.BOMConfirm & "',getdate(), N'" & SampleCom.GetSGUserName(Me.txtSampleNo.Text.Trim) & "' )")
                '    Else
                '        lsSQL.Append(" Update  m_SampleD_t SET FinishFlag ='0', finishtime = NULL ")
                '        lsSQL.Append(" WHERE SampleNo='" & Me.txtSampleNo.Text.Trim & "' AND LevelID ='" & SampleCom.enumLevelID.MaterialGive & "'")
                '    End If
        End Select

        If Not String.IsNullOrEmpty(lsSQL.ToString) Then
            DbOperateUtils.ExecSQL(lsSQL.ToString)
        End If
    End Sub

#Region "Excel 导出"
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Dim strSQL As String = String.Empty
        Dim sqlstring As String = String.Empty
        Dim strFileName As String = ""
        Try
            If Not String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                sqlstring = " AND SampleNo = '" & Me.txtSampleNo.Text.Trim & "'"
            End If

            Select Case TabSheet.SelectedTab.Name
                Case "TabEqu"
                    strSQL = "SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist,SampleNO 样品单号, NO , EquName 设备名称,  CONVERT(varchar(100), PlanDuedate, 111) 预计交期,  CONVERT(varchar(100), RealDueDate, 111)  实际交期  " & _
                        " FROM m_SampleEqu_t a  " & _
                        " WHERE 1=1 " & sqlstring
                    strSQL = strSQL & " ORDER BY no"
                    strFileName = Me.Text + "--" + "设备清单"
                Case "TabBOM"
                    ' [No], [SampleNo],[PartNo] ,[Specs] ,[supplier],[Unit] ,[Qty],[PlanDuedate],[RealDuedate]
                    strSQL = "SELECT IIf(isnull(IsExist,'')='',0,IsExist) IsExist,SampleNO 样品单号, NO , PartNo 料号, Specs 规格描述,supplier 供应商,Qty 用量, Unit 单位,  PlanDueDate 预计交期, RealDueDate 实际交期  " & _
                    " FROM m_SampleBOM_t a  " & _
                    " WHERE 1=1 " & sqlstring
                    strSQL = strSQL & " ORDER BY no"
                Case "TabZEqu"
                    ' [No] ,[ZEquName],[IsShare] ,[SharePN],[PlanDuedate],[RealDuedate] ,[SampleNo]
                    strSQL = "SELECT SampleNO 样品单号, NO , ZEquName 治工具名称, IsShare 是否共用,SharePN 共用备注料号,PlanDueDate 预计交期, RealDueDate 实际交期  " & _
                    " FROM m_SampleZEqu_t a  " & _
                    " WHERE 1=1 " & sqlstring
                    strSQL = strSQL & " ORDER BY no"
                Case "TabModel"
                    ' [No] ,[ModelName] ,[IsShare] ,[SharePN],[PlanDuedate] ,[RealDuedate] ,[SampleNo]
                    strSQL = "SELECT SampleNO 样品单号, NO , ModelName 模具名称, IsShare 是否共用,SharePN 共用备注料号,PlanDueDate 预计交期, RealDueDate 实际交期  " & _
                    " FROM m_SampleModel_t a  " & _
                    " WHERE 1=1 " & sqlstring
                    strSQL = strSQL & " ORDER BY no"
                Case "TabDocument"
                    strSQL = " SELECT SampleNO 样品单号,  BluePath 蓝图, CutPath 裁线卡, RCardPath 流程卡 " & _
                             " FROM m_SampleDocument_t a  " & _
                             " WHERE 1 = 1 " & sqlstring
                    strSQL = strSQL & " ORDER BY SampleNO"

                Case Else
            End Select

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "toolExcel_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click

        Select Case TabSheet.SelectedTab.Name
            Case "TabEqu"

            Case "TabZEqu"
                For Each dr As DataGridViewRow In Me.dgvZEqu.Rows
                    If DbOperateUtils.DBNullToStr(dr.Cells(enumdgvZEqu.IsShare).Value) = "是" Then
                        If IsDBNull(dr.Cells(enumdgvZEqu.SharePN).Value) OrElse dr.Cells(enumdgvZEqu.SharePN).Value = "" Then
                            MessageUtils.ShowError(" NO: [" & dr.Cells(enumdgvZEqu.No).Value & "] 需要填写共用料号！")
                            Exit Sub
                        End If
                    ElseIf DbOperateUtils.DBNullToStr(dr.Cells(enumdgvZEqu.IsShare).Value) = "否" Then
                        If IsDBNull(dr.Cells(enumdgvZEqu.PlanDueDate).Value) OrElse dr.Cells(enumdgvZEqu.PlanDueDate).Value = "" Then
                            MessageUtils.ShowError(" NO: [" & dr.Cells(enumdgvZEqu.No).Value & "] 需要填写预计交期！")
                            Exit Sub
                        End If
                    End If
                Next
            Case "TabModel"
                For Each dr As DataGridViewRow In Me.dgvModel.Rows
                    If DbOperateUtils.DBNullToStr(dr.Cells(enumdgvModel.IsShare).Value) = "是" Then
                        If IsDBNull(dr.Cells(enumdgvModel.SharePN).Value) OrElse dr.Cells(enumdgvModel.SharePN).Value = "" Then
                            MessageUtils.ShowError(" NO: [" & dr.Cells(enumdgvModel.No).Value & "] 需要填写共用料号！")
                            Exit Sub
                        End If
                    ElseIf DbOperateUtils.DBNullToStr(dr.Cells(enumdgvModel.IsShare).Value) = "否" Then
                        If IsDBNull(dr.Cells(enumdgvModel.PlanDueDate).EditedFormattedValue) OrElse dr.Cells(enumdgvModel.PlanDueDate).EditedFormattedValue = "" Then
                            MessageUtils.ShowError(" NO: [" & dr.Cells(enumdgvModel.No).Value & "] 需要填写预计交期！")
                            Exit Sub
                        End If
                    End If
                Next
            Case "TabBOM"
                'For Each dr As DataGridViewRow In Me.dgvBOM.Rows
                '    If DbOperateUtils.DBNullToStr(dr.Cells(enumdgvBOM.IsExist).EditedFormattedValue) = "0" Then
                '        If DbOperateUtils.DBNullToStr(dr.Cells(enumdgvBOM.PlanDueDate).EditedFormattedValue) = "" Then
                '            MessageUtils.ShowError(" NO: [" & dr.Cells(enumdgvBOM.No).Value & "] 需要填写预计交期！")
                '            Exit Sub
                '        End If
                '    End If
                'Next
            Case Else
                'do nothing
        End Select

        MessageUtils.ShowInformation("保存成功")
    End Sub

#Region "设备事件"
    Private Sub dgvEqu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEqu.CellDoubleClick
        If e.RowIndex < 0 OrElse Me.dgvEqu.Rows.Count <= 0 Then Exit Sub

        Dim o_strSQL As New StringBuilder
        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = ""
        Try
            Me.dgvEqu.EndEdit()
            o_strColumnName = dgvEqu.CurrentCell.OwningColumn.Name

            Dim b As String = dgvEqu.Columns(enumdgvEqu.PlanDueDate).Name + "," + dgvEqu.Columns(enumdgvEqu.RealDueDate).Name
            If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then 'o_strColumnName.IndexOf(b) > 0 Then
                Dim FrmEditTime As New FrmEditTime
                FrmEditTime.ShowDialog()
            Else
                'not show time
            End If

            If SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
                Select Case o_strColumnName
                    Case dgvEqu.Columns(enumdgvEqu.PlanDueDate).Name
                        strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        o_strSQL.Append(" Update m_SampleEqu_t SET PlanDueDate = '" & strPlanDate & "' ")
                        o_strSQL.Append(" WHERE  SampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
                        Me.dgvEqu.CurrentCell.Value = strPlanDate
                    Case dgvEqu.Columns(enumdgvModel.RealDueDate).Name
                        strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        o_strSQL.Append(" Update m_SampleEqu_t SET RealDueDate = '" & strRealDate & "' ")
                        o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
                        Me.dgvEqu.CurrentCell.Value = strRealDate
                End Select

                If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
                    DbOperateUtils.ExecSQL(o_strSQL.ToString)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvEqu_CellDoubleClick", "Sample")
        End Try
    End Sub

    Private Sub dgvEqu_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvEqu.RowPrePaint
        If e.RowIndex = -1 OrElse Me.dgvEqu.Rows.Count <= 0 Then Exit Sub
        Dim strIsExist As String = ""
        Dim o_blnEquConfirm As Boolean = False
        Dim o_tempPlanDueDate As Date
        Try
            For rowIndex As Integer = 0 To Me.dgvEqu.Rows.Count - 1
                strIsExist = DbOperateUtils.DBNullToStr(dgvEqu.Rows(rowIndex).Cells(enumdgvEqu.IsExist).Value)
                If Not String.IsNullOrEmpty(strIsExist) Then
                    Select Case strIsExist
                        Case "0"
                            Date.TryParse(Me.dgvEqu.Rows(rowIndex).Cells(enumdgvEqu.PlanDueDate).Value, o_tempPlanDueDate)
                            If DateTime.Compare(o_tempPlanDueDate, DateTime.Now) < 0 AndAlso DbOperateUtils.DBNullToStr(Me.dgvEqu.Rows(rowIndex).Cells(enumdgvEqu.RealDueDate).Value) = "" Then
                                dgvEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.Red
                            Else
                                If DbOperateUtils.DBNullToStr(Me.dgvEqu.Rows(rowIndex).Cells(enumdgvEqu.RealDueDate).Value) = "" Then
                                    dgvEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
                                Else
                                    dgvEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                                End If
                            End If
                        Case "1"
                            dgvEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                            o_blnEquConfirm = True
                        Case Else
                            'do nothing 
                    End Select
                End If
            Next
            If o_blnEquConfirm Then
                dgvEqu.Columns(enumdgvEqu.YPSDutyName).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvEqu_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEqu.CellValueChanged
        If e.RowIndex < 0 OrElse Me.dgvEqu.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = "", strIsShare As String = "", strSharePN As String = "", strQty As String = ""
        Dim o_strSQL As New StringBuilder
        Dim o_tempRealDate As Date
        Dim blnUpdateMaxPlanDate As Boolean = False
        o_strColumnName = dgvEqu.CurrentCell.OwningColumn.Name
        Try
            Select Case o_strColumnName
                Case dgvEqu.Columns(enumdgvEqu.PlanDueDate).Name
                    strPlanDate = dgvEqu.CurrentCell.EditedFormattedValue
                    o_strSQL.Append(" Update m_SampleEqu_t SET PlanDueDate = '" & strPlanDate & "' ")
                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
                    Me.dgvEqu.CurrentCell.Value = strPlanDate
                    blnUpdateMaxPlanDate = True
                Case dgvEqu.Columns(enumdgvEqu.RealDueDate).Name
                    strRealDate = dgvEqu.CurrentCell.EditedFormattedValue
                    Date.TryParse(strRealDate, o_tempRealDate)
                    If strRealDate <> "" AndAlso Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
                        MessageUtils.ShowError("填入的日期不能早于今天！！")
                        Me.dgvEqu.CurrentCell.Value = ""
                        Exit Sub
                    End If
                    o_strSQL.Append(" Update m_SampleEqu_t Set RealDueDate = '" & strRealDate & "' ")
                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
                    Me.dgvEqu.CurrentCell.Value = strRealDate
                    blnUpdateMaxPlanDate = True
                Case dgvEqu.Columns(enumdgvEqu.Qty).Name
                    strQty = Val(dgvEqu.CurrentCell.EditedFormattedValue)
                    o_strSQL.Append(" Update m_SampleEqu_t SET qty = '" & strQty & "' ")
                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
                    Me.dgvEqu.CurrentCell.Value = strQty
                Case Else
                    'do nothing
            End Select

            If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
                DbOperateUtils.ExecSQL(o_strSQL.ToString)
                If blnUpdateMaxPlanDate Then
                    Dim o_SQL As New StringBuilder
                    'MAX( cast(nullif(PlanDuedate,'') as date))
                    o_SQL.Append(" Declare @MaxPlanDate datetime")
                    o_SQL.Append(" SELECT @MaxPlanDate= MAX(cast(nullif(PlanDuedate,'') as date)) FROM m_SampleEqu_t WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND IsExist ='0' AND ISNULL(RealDuedate,'') = ''")
                    o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE sampleno = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.EquGive & "'")
                    DbOperateUtils.ExecSQL(o_SQL.ToString)
                End If
                'check All Plandate and DueDate finish
                If SampleCom.CheckIsEquDateFinish(Me.txtSampleNo.Text.Trim) Then
                    'update the step finish
                    Call UpdateStatus(SheetType.ZEqu, 1)
                Else
                    Call UpdateStatus(SheetType.ZEqu, 0)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub dgvZEqu_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvZEqu.RowPrePaint
        If e.RowIndex = -1 OrElse Me.dgvZEqu.Rows.Count <= 0 Then Exit Sub
        Dim strIsShare As String = "", o_tempstrPlanDueDate As String = ""
        Dim o_blnEquConfirm As Boolean = False

        Dim o_tempPlanDueDate As Date
        Try
            For rowIndex As Integer = 0 To Me.dgvZEqu.Rows.Count - 1
                strIsShare = DbOperateUtils.DBNullToStr(dgvZEqu.Rows(rowIndex).Cells(enumdgvZEqu.IsShare).Value)
                If Not String.IsNullOrEmpty(strIsShare) Then
                    Select Case strIsShare
                        Case "否"
                            o_tempstrPlanDueDate = DbOperateUtils.DBNullToStr(Me.dgvZEqu.Rows(rowIndex).Cells(enumdgvZEqu.PlanDueDate).Value)
                            If String.IsNullOrEmpty(o_tempstrPlanDueDate) Then
                                dgvZEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
                            Else
                                Date.TryParse(Me.dgvZEqu.Rows(rowIndex).Cells(enumdgvZEqu.PlanDueDate).Value, o_tempPlanDueDate)
                                If DateTime.Compare(o_tempPlanDueDate, DateTime.Now.Date) <= 0 AndAlso DbOperateUtils.DBNullToStr(Me.dgvZEqu.Rows(rowIndex).Cells(enumdgvZEqu.RealDueDate).Value) = "" Then
                                    dgvZEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.Red
                                Else
                                    If DbOperateUtils.DBNullToStr(Me.dgvZEqu.Rows(rowIndex).Cells(enumdgvZEqu.RealDueDate).Value) = "" Then
                                        dgvZEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
                                    Else
                                        dgvZEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                                    End If
                                End If
                            End If
                        Case "是"
                            dgvZEqu.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                        Case Else
                            'do nothing 
                    End Select
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvModel_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvModel.RowPrePaint
        If e.RowIndex = -1 OrElse Me.dgvModel.Rows.Count <= 0 Then Exit Sub
        Dim strIsShare As String = "", o_tempstrPlanDueDate As String = ""
        Dim o_blnEquConfirm As Boolean = False
        Dim o_tempPlanDueDate As Date
        Try
            For rowIndex As Integer = 0 To Me.dgvModel.Rows.Count - 1
                strIsShare = DbOperateUtils.DBNullToStr(dgvModel.Rows(rowIndex).Cells(enumdgvModel.IsShare).Value)
                If Not String.IsNullOrEmpty(strIsShare) Then
                    Select Case strIsShare
                        Case "否"
                            o_tempstrPlanDueDate = DbOperateUtils.DBNullToStr(Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.PlanDueDate).Value)
                            If String.IsNullOrEmpty(o_tempstrPlanDueDate) Then
                                dgvModel.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
                            Else
                                Date.TryParse(Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.PlanDueDate).Value, o_tempPlanDueDate)
                                If DateTime.Compare(o_tempPlanDueDate, DateTime.Now.Date) <= 0 AndAlso DbOperateUtils.DBNullToStr(Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.RealDueDate).Value) = "" Then
                                    dgvModel.Rows(rowIndex).Cells(0).Style.BackColor = Color.Red
                                Else
                                    If DbOperateUtils.DBNullToStr(Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.RealDueDate).Value) = "" Then
                                        dgvModel.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
                                    Else
                                        dgvModel.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                                    End If
                                End If
                            End If
                        Case "是"
                            dgvModel.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
                            Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.PlanDueDate).ReadOnly = True
                            Me.dgvModel.Rows(rowIndex).Cells(enumdgvModel.RealDueDate).ReadOnly = True
                        Case Else
                            'do nothing 
                    End Select
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOMConfirm()
        Dim o_strSQL As New StringBuilder
        o_strSQL.Append(" UPDATE M_SampleD_t SET FinishTime=getdate(),FinishFlag='1' WHERE sampleno ='" & Me.txtSampleNo.Text & "' ")
        o_strSQL.Append(" And levelid ='" & SampleCom.enumLevelID.BOMConfirm & "'")
        DbOperateUtils.ExecSQL(o_strSQL.ToString)
    End Sub

    Private Sub dgvModel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModel.CellDoubleClick
        Dim o_strSQL As New StringBuilder
        Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = ""
        Try
            If e.RowIndex < 0 OrElse Me.dgvModel.Rows.Count <= 0 Then Exit Sub

            o_strColumnName = dgvModel.CurrentCell.OwningColumn.Name

            Dim b As String = dgvModel.Columns(enumdgvModel.PlanDueDate).Name + "," + dgvModel.Columns(enumdgvModel.RealDueDate).Name
            If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then 'o_strColumnName.IndexOf(b) > 0 Then
                Dim FrmEditTime As New FrmEditTime
                FrmEditTime.ShowDialog()
            Else
                'not show time
            End If

            If SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
                Select Case o_strColumnName
                    Case dgvModel.Columns(enumdgvModel.PlanDueDate).Name
                        strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        o_strSQL.Append(" UPDATE m_SampleModel_t SET PlanDueDate = '" & strPlanDate & "' ")
                        o_strSQL.Append(" WHERE  SampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                        Me.dgvModel.CurrentCell.Value = strPlanDate
                    Case dgvModel.Columns(enumdgvModel.RealDueDate).Name
                        strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                        SampleCom.SqlClassD.UpdateTime = ""
                        o_strSQL.Append(" UPDATE m_SampleModel_t SET RealDueDate = '" & strRealDate & "' ")
                        o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
                        Me.dgvModel.CurrentCell.Value = strRealDate
                End Select

                If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
                    DbOperateUtils.ExecSQL(o_strSQL.ToString)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "dgvModel_CellClick", "Sample")
        End Try
    End Sub

    Private Sub dgvDocument_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellContentDoubleClick
        If e.RowIndex = -1 OrElse Me.dgvDocument.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName As String = String.Empty
        o_strColumnName = dgvDocument.CurrentCell.OwningColumn.Name
        Select Case o_strColumnName
            Case dgvDocument.Columns(enumdgvDocument.path).Name
                System.Diagnostics.Process.Start(Me.dgvDocument.CurrentCell.Value.ToString)
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub dgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        If e.RowIndex = -1 OrElse Me.dgvDocument.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName As String = String.Empty
        o_strColumnName = dgvDocument.CurrentCell.OwningColumn.Name
        Select Case o_strColumnName
            Case dgvDocument.Columns(enumdgvDocument.path).Name
                System.Diagnostics.Process.Start(Me.dgvDocument.CurrentCell.Value.ToString)
            Case Else
                Dim o_strDocType As String = String.Empty, o_strSampleNo As String = ""
                o_strDocType = Me.dgvDocument.CurrentRow.Cells(enumdgvDocument.type).Value
                o_strSampleNo = Me.dgvDocument.CurrentRow.Cells(enumdgvDocument.SampleNo).Value
                Using o_FrmDocHisList As FrmSampleDocHis = New FrmSampleDocHis(o_strSampleNo, o_strDocType)
                    o_FrmDocHisList.ShowDialog()
                End Using
        End Select
    End Sub

    Private Sub SideBar1_ItemClick(sender As Object, e As EventArgs) Handles SideBar1.ItemClick
        Dim _sampleNo As String = ""
        Try
            If TypeOf sender Is ButtonItem Then
                Dim SelectedItem As ButtonItem = CType(sender, ButtonItem)
                If SelectedItem.Tag.ToString() <> "" Then
                    '清除样式
                    For Each item As ButtonItem In SelectedItem.Parent.SubItems
                        item.ForeColor = Color.Black
                        item.FontBold = False
                    Next
                    '添加样式()
                    SelectedItem.ForeColor = Color.Blue
                    SelectedItem.FontBold = True

                    If CType(SelectedItem.Tag, ArrayList).Count < 1 Then
                        Exit Sub
                    End If
                    _sampleNo = CStr(CType(SelectedItem.Tag, ArrayList).Item(0))

                    Me.txtSampleNo.Text = _sampleNo

                    'Add by cq 20170107
                    LoadSheet()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "SideBar1_ItemClick", "Sample")
        End Try
    End Sub

    Private Sub btnImportCBlue_Click(sender As Object, e As EventArgs) Handles btnImportCBlue.Click
        Call ImportCBlue()
        MessageUtils.ShowInformation("上传客户蓝图成功!")
    End Sub

    Private Sub ImportBOM()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.CusBlueFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber)

            Dim BOMFilePath As String = Me.txtBOMFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.BOMFileName)
            File.Copy(BOMFilePath, ServerFile, True)
        Else '未选择上传
            Exit Sub
        End If
        Call UpdatePathToDB(DocumentType.BOM, ServerFile)
    End Sub

    Private Sub ImportCBlue()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.CusBlueFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)

            Dim CusBlueFilePath As String = Me.txtCBlueFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.CusBlueFileName)
            File.Copy(CusBlueFilePath, ServerFile, True)
        Else '未选择上传
            Exit Sub
        End If
        Call UpdatePathToDB(DocumentType.CusBlue, ServerFile)
    End Sub

    Private Sub btnUploadPack_Click(sender As Object, e As EventArgs) Handles btnUploadPack.Click
        btnUploadPack.Enabled = False
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPackFilePath.Text = OpenFileDialog1.FileName
            Me.PackFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadPack.Enabled = True
    End Sub

    Private Sub btnImportPack_Click(sender As Object, e As EventArgs) Handles btnImportPack.Click
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.PackFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)

            Dim PackFilePath As String = Me.txtPackFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.PackFileName)
            File.Copy(PackFilePath, ServerFile, True)
        Else '未选择上传
            Exit Sub
        End If

        Call UpdatePathToDB(DocumentType.Pack, ServerFile)
        MessageUtils.ShowInformation("上传包规成功!")

    End Sub

    Private Sub ImportPack()
        Dim ServerFile As String = ""
        If Not String.IsNullOrEmpty(Me.PackFileName) Then
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                MessageUtils.ShowError("请先填写样品单号")
                Exit Sub
            Else
                _sampleNumber = Me.txtSampleNo.Text.Trim
            End If

            Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\", _sampleNumber) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)

            Dim PackFilePath As String = Me.txtPackFilePath.Text.Trim
            If System.IO.Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If
            ServerFile = Path.Combine(destFilePath, Me.PackFileName)
            File.Copy(PackFilePath, ServerFile, True)
        Else '未选择上传
            Exit Sub
        End If
        Call UpdatePathToDB(DocumentType.Pack, ServerFile)
    End Sub

    Private Sub ToolAddDutyName_Click(sender As Object, e As EventArgs) Handles ToolAddDutyName.Click
        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName

        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            MessageUtils.ShowError("请先填写样品单号！")
            Exit Sub
        End If
        Dim frm As FrmSampleDutyName = New FrmSampleDutyName

        frm.m_strSampleNO = Me.txtSampleNo.Text
        frm.m_strYWDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.业务.ToString)
        frm.m_strPZDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.品质.ToString)
        frm.m_strYPSDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.样品室.ToString)
        frm.m_strEquDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.设备.ToString)
        frm.m_strSGDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.生管.ToString)
        frm.m_strPIEDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.PIE.ToString)
        frm.m_strZEquDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.治具.ToString)
        frm.m_strRDDutyName = SampleCom.GetPICUserNames(frm.m_strSampleNO, SampleCom.EnumSampleDept.研发.ToString)
        Dim result As DialogResult = frm.ShowDialog()
    End Sub

    Private Sub btnSetFinish_Click(sender As Object, e As EventArgs) Handles btnSetFinish.Click
        If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
            Exit Sub
        End If

        Dim lsSQL As StringBuilder = New StringBuilder

        Select Case m_strCurrentUserDept
            Case EnumSampleDept.研发.ToString
                lsSQL.Append(" Update m_Sample_t SET RDFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.治具.ToString
                lsSQL.Append(" Update m_Sample_t SET ZJFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.设备.ToString
                lsSQL.Append(" Update m_Sample_t Set EquFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
            Case EnumSampleDept.样品室.ToString
                lsSQL.Append(" Update m_Sample_t Set YPSEquFinishFlag ='1' Where Sampleno ='" & Me.txtSampleNo.Text.Trim & "'")
        End Select

        If Not String.IsNullOrEmpty(lsSQL.ToString) Then
            DbOperateUtils.ExecSQL(lsSQL.ToString)
            'Refersh data
            LoadSideBarByClick("", m_strCurrentUserDept, True)
        End If
    End Sub

    Private Sub dgvEqu_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEqu.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.dgvEqu.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                p.Offset(CInt("0"), CInt("0"))
                Me.m_ChkboxAll.Location = p

                Me.m_ChkboxAll.Size = dgvEqu.Columns(0).HeaderCell.Size
                Me.m_ChkboxAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))

                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "dgvEqu_CellPainting", "Sample")
        End Try
    End Sub

    Private Sub ToolAllUpload_Click(sender As Object, e As EventArgs) Handles ToolAllUpload.Click
        Try
            If String.IsNullOrEmpty(Me.txtSampleNo.Text) Then
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(txtBlueFilePath.Text) Then
                Call ImportBlue()
            End If

            If Not String.IsNullOrEmpty(txtCutFilePath.Text) Then
                Call ImportCut()
            End If

            If Not String.IsNullOrEmpty(txtRCardFilePath.Text) Then
                Call ImportRCard()
            End If

            '治具开立资料
            If Not String.IsNullOrEmpty(txtZEquFilePath.Text) Then
                Call ImportZEqu()
            End If

            '客户蓝图
            If Not String.IsNullOrEmpty(txtCBlueFilePath.Text) Then
                Call ImportCBlue()
            End If

            '包规
            If Not String.IsNullOrEmpty(txtPackFilePath.Text) Then
                Call ImportPack()
            End If

            'BOM
            If Not String.IsNullOrEmpty(txtBOMFilePath.Text) Then
                Call ImportBOM()
            End If

            MessageUtils.ShowInformation("上传成功!")
        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmSampleUpload", "ToolAllUpload_Click", "Sample")
        End Try
    End Sub

    '蓝图预览
    Private Sub btnBlueLook_Click(sender As Object, e As EventArgs) Handles btnBlueLook.Click

        If String.IsNullOrEmpty(Me.txtBlueFilePath.Text) Then
            Exit Sub
        End If

        'Using frm As FrmDocLook = New FrmDocLook
        '    frm.m_strFileName = Me.txtBlueFilePath.Text
        '    frm.ShowDialog()
        'End Using

        System.Diagnostics.Process.Start(Me.txtBlueFilePath.Text)

    End Sub

    Private Sub btnRCardLook_Click(sender As Object, e As EventArgs) Handles btnRCardLook.Click
        If String.IsNullOrEmpty(Me.txtRCardFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtRCardFilePath.Text)
    End Sub

    Private Sub btnCutLook_Click(sender As Object, e As EventArgs) Handles btnCutLook.Click
        If String.IsNullOrEmpty(Me.txtCutFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtCutFilePath.Text)
    End Sub

    Private Sub btnZEquLook_Click(sender As Object, e As EventArgs) Handles btnZEquLook.Click
        If String.IsNullOrEmpty(Me.txtZEquFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtZEquFilePath.Text)
    End Sub

    Private Sub btnPackLook_Click(sender As Object, e As EventArgs) Handles btnPackLook.Click
        If String.IsNullOrEmpty(Me.txtPackFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtPackFilePath.Text)
    End Sub

    Private Sub btnUploadBOM_Click(sender As Object, e As EventArgs) Handles btnUploadBOM.Click
        btnUploadBOM.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"  ’ofd.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtBOMFilePath.Text = OpenFileDialog1.FileName
            Me.BOMFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadBOM.Enabled = True
    End Sub


    Private Sub btnCBlueLook_Click(sender As Object, e As EventArgs) Handles btnCBlueLook.Click
        If String.IsNullOrEmpty(Me.txtCBlueFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtCBlueFilePath.Text)
    End Sub


#Region "Not Use"
    'Private Sub dgvModel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModel.CellDoubleClick
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = ""
    '    Try
    '        If e.RowIndex < 0 OrElse Me.dgvModel.Rows.Count <= 0 Then Exit Sub

    '        o_strColumnName = dgvModel.CurrentCell.OwningColumn.Name

    '        'Dim b As String = dgvModel.Columns(enumdgvModel.PlanDueDate).Name + "," + dgvModel.Columns(enumdgvModel.RealDueDate).Name
    '        'If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then
    '        '    Dim FrmEditTime As New FrmEditTime
    '        '    FrmEditTime.ShowDialog()
    '        'Else
    '        '    'not show time
    '        'End If

    '        If (Not IsNothing(SampleCom.SqlClassD.UpdateTime)) AndAlso SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
    '            Select Case o_strColumnName
    '                Case dgvModel.Columns(enumdgvModel.PlanDueDate).Name
    '                    strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    SampleCom.SqlClassD.UpdateTime = ""
    '                    'If String.IsNullOrEmpty(strPlanDate) Then
    '                    '    Exit Sub
    '                    'End If
    '                    o_strSQL.Append(" Update m_SampleModel_t Set PlanDueDate = '" & strPlanDate & "' ")
    '                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
    '                    Me.dgvModel.CurrentCell.Value = strPlanDate
    '                Case dgvModel.Columns(enumdgvModel.RealDueDate).Name
    '                    strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    SampleCom.SqlClassD.UpdateTime = ""
    '                    'If String.IsNullOrEmpty(strPlanDate) Then
    '                    '    Exit Sub
    '                    'End If
    '                    o_strSQL.Append(" Update m_SampleModel_t Set RealDueDate = '" & strRealDate & "' ")
    '                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvModel.Rows(e.RowIndex).Cells(enumdgvModel.No).Value & "' ")
    '                    Me.dgvModel.CurrentCell.Value = strRealDate
    '            End Select

    '            If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '                DbOperateUtils.ExecSQL(o_strSQL.ToString)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvModel_CellClick", "sys")
    '    End Try
    'End Sub

    'Private Sub dgvBOM_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
    '    If e.RowIndex = -1 OrElse Me.dgvBOM.Rows.Count <= 0 Then Exit Sub
    '    Dim strIsExist As String = "", o_tempstrPlanDueDate As String = ""
    '    Dim o_blnEquConfirm As Boolean = False
    '    Dim o_tempPlanDueDate As Date
    '    Try
    '        For rowIndex As Integer = 0 To Me.dgvBOM.Rows.Count - 1
    '            strIsExist = DbOperateUtils.DBNullToStr(dgvBOM.Rows(rowIndex).Cells(enumdgvBOM.IsExist).Value)
    '            If Not String.IsNullOrEmpty(strIsExist) Then
    '                Select Case strIsExist
    '                    Case "0"
    '                        o_tempstrPlanDueDate = DbOperateUtils.DBNullToStr(Me.dgvBOM.Rows(rowIndex).Cells(enumdgvBOM.PlanDueDate).Value)
    '                        If String.IsNullOrEmpty(o_tempstrPlanDueDate) Then
    '                            dgvBOM.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
    '                        Else
    '                            Date.TryParse(Me.dgvBOM.Rows(rowIndex).Cells(enumdgvBOM.PlanDueDate).Value, o_tempPlanDueDate)
    '                            If DateTime.Compare(o_tempPlanDueDate, DateTime.Now) < 0 AndAlso DbOperateUtils.DBNullToStr(Me.dgvBOM.Rows(rowIndex).Cells(enumdgvBOM.RealDueDate).Value) = "" Then
    '                                dgvBOM.Rows(rowIndex).Cells(0).Style.BackColor = Color.Red
    '                            Else
    '                                If DbOperateUtils.DBNullToStr(Me.dgvBOM.Rows(rowIndex).Cells(enumdgvBOM.RealDueDate).Value) = "" Then
    '                                    dgvBOM.Rows(rowIndex).Cells(0).Style.BackColor = Color.Yellow
    '                                Else
    '                                    dgvBOM.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
    '                                End If
    '                            End If
    '                        End If
    '                    Case "1"
    '                        dgvBOM.Rows(rowIndex).Cells(0).Style.BackColor = Color.LightGreen
    '                    Case Else
    '                        'do nothing 
    '                End Select
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub dgvBOM_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)

    '    If e.RowIndex < 0 OrElse Me.dgvBOM.Rows.Count <= 0 Then Exit Sub

    '    Dim o_strSQL As New StringBuilder
    '    Dim o_strColumnName As String = "", strPlanDate As Date = Nothing, strRealDate As Date = Nothing
    '    Dim o_blnUpdatePlanDate As Boolean = False
    '    Try
    '        If Not SampleCom.IsSGUserID(VbCommClass.VbCommClass.UseId) Then
    '            MessageUtils.ShowWarning(" 你没有权限修改！")
    '            Exit Sub
    '        End If
    '        o_strColumnName = dgvBOM.CurrentCell.OwningColumn.Name
    '        Select Case o_strColumnName
    '            Case dgvBOM.Columns(enumdgvBOM.PlanDueDate).Name
    '                If IsDBNull(dgvBOM.CurrentCell.EditedFormattedValue) Then
    '                    strPlanDate = ""
    '                Else
    '                    DateTime.TryParse(dgvBOM.CurrentCell.EditedFormattedValue, strPlanDate)
    '                End If
    '                o_strSQL.Append(" Update m_SampleBOM_t Set PlanDueDate = '" & strPlanDate & "' ")
    '                o_strSQL.Append(" WHERE  SampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                o_blnUpdatePlanDate = True
    '            Case dgvBOM.Columns(enumdgvBOM.RealDueDate).Name
    '                If IsDBNull(dgvBOM.CurrentCell.EditedFormattedValue) Then
    '                    strRealDate = ""
    '                Else
    '                    DateTime.TryParse(dgvBOM.CurrentCell.EditedFormattedValue, strRealDate)
    '                End If
    '                If Date.Compare(strRealDate, DateTime.Now.Date) < 0 Then
    '                    MessageUtils.ShowError("填入的日期不能早于今天！！")
    '                    Me.dgvBOM.CurrentCell.Value = ""
    '                    Exit Sub
    '                End If

    '                o_strSQL.Append(" Update m_SampleBOM_t SET RealDueDate = '" & strRealDate & "' ")
    '                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                o_blnUpdatePlanDate = True
    '        End Select

    '        If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '            DbOperateUtils.ExecSQL(o_strSQL.ToString)

    '            If o_blnUpdatePlanDate Then
    '                Dim o_SQL As New StringBuilder
    '                'MAX( cast(nullif(PlanDuedate,'') as date))
    '                o_SQL.Append(" Declare @MaxPlanDate datetime")
    '                o_SQL.Append(" SELECT @MaxPlanDate= MAX( cast(nullif(PlanDuedate,'') as date)) FROM m_SampleBOM_t WHERE sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND IsExist ='0' AND ISNULL(RealDuedate,'') = ''")
    '                o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE sampleno = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.MaterialGive & "'")
    '                DbOperateUtils.ExecSQL(o_SQL.ToString())
    '            End If

    '            'check All Plandate and DueDate finish
    '            If SampleCom.CheckIsBOMDateFinish(Me.txtSampleNo.Text.Trim) Then
    '                'update the step finish
    '                Call UpdateStatus(SheetType.BOM, 1)
    '            Else
    '                Call UpdateStatus(SheetType.BOM, 0)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub dgvBOM_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBOM.CellClick
    '    If e.RowIndex < 0 OrElse Me.dgvBOM.Rows.Count <= 0 Then Exit Sub
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_strColumnName As String = "", strPlanDate As Date = Nothing, strRealDate As Date = Nothing
    '    Try
    '        If Not SampleCom.IsSGUserID(VbCommClass.VbCommClass.UseId.Trim) Then
    '            MessageUtils.ShowWarning(" 你没有权限修改！")
    '            Exit Sub
    '        End If
    '        o_strColumnName = dgvBOM.CurrentCell.OwningColumn.Name
    '        'Dim b As String = dgvBOM.Columns(enumdgvBOM.PlanDueDate).Name + "," + dgvBOM.Columns(enumdgvBOM.RealDueDate).Name
    '        'If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then 'o_strColumnName.IndexOf(b) > 0 Then
    '        '    Dim FrmEditTime As New FrmEditTime
    '        '    FrmEditTime.ShowDialog()
    '        'Else
    '        '    'not show time
    '        'End If
    '        'Dim FrmEditTime As New FrmEditTime
    '        'FrmEditTime.ShowDialog()
    '        If SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
    '            Select Case o_strColumnName
    '                Case dgvBOM.Columns(enumdgvBOM.PlanDueDate).HeaderText
    '                    strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    o_strSQL.Append(" Update m_SampleBOM_t Set PlanDueDate = '" & strPlanDate & "' ")
    '                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                    Me.dgvBOM.CurrentCell.Value = strPlanDate
    '                Case dgvBOM.Columns(enumdgvBOM.RealDueDate).HeaderText
    '                    strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    SampleCom.SqlClassD.UpdateTime = ""
    '                    'If String.IsNullOrEmpty(strPlanDate) Then
    '                    '    Exit Sub
    '                    'End If
    '                    o_strSQL.Append(" Update m_SampleBOM_t Set RealDueDate = '" & strRealDate & "' ")
    '                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                    Me.dgvBOM.CurrentCell.Value = strRealDate
    '            End Select

    '            If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '                DbOperateUtils.ExecSQL(o_strSQL.ToString)

    '                If SampleCom.CheckIsBOMDateFinish(Me.txtSampleNo.Text.Trim) Then
    '                    UpdateStatus(SheetType.BOM)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvBOM_CellClick", "sys")
    '    End Try
    'End Sub

    'Private Sub dgvBOM_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If e.RowIndex < 0 OrElse Me.dgvBOM.Rows.Count <= 0 Then Exit Sub
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_strColumnName As String = "", strPlanDate As Date = Nothing, strRealDate As Date = Nothing
    '    Try
    '        If Not SampleCom.IsSGUserID(VbCommClass.VbCommClass.UseId.Trim) Then
    '            MessageUtils.ShowWarning(" 你没有权限修改！")
    '            Exit Sub
    '        End If
    '        o_strColumnName = dgvBOM.CurrentCell.OwningColumn.Name

    '        Select Case o_strColumnName
    '            Case dgvBOM.Columns(enumdgvBOM.PlanDueDate).HeaderText
    '                strPlanDate = Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvEqu.PlanDueDate).EditedFormattedValue.ToString
    '                o_strSQL.Append(" Update m_SampleBOM_t Set PlanDueDate = '" & strPlanDate & "' ")
    '                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                Me.dgvBOM.CurrentCell.Value = strPlanDate
    '            Case dgvBOM.Columns(enumdgvBOM.RealDueDate).HeaderText
    '                strRealDate = Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvEqu.RealDueDate).EditedFormattedValue.ToString
    '                o_strSQL.Append(" Update m_SampleBOM_t Set RealDueDate = '" & strRealDate & "' ")
    '                o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND partno ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.PartNumber).Value & "' ")
    '                Me.dgvBOM.CurrentCell.Value = strRealDate
    '        End Select

    '        If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '            DbOperateUtils.ExecSQL(o_strSQL.ToString)

    '            If SampleCom.CheckIsBOMDateFinish(Me.txtSampleNo.Text.Trim) Then
    '                UpdateStatus(SheetType.BOM, 1)
    '            Else
    '                UpdateStatus(SheetType.BOM, 0)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvBOM_CellClick", "sys")
    '    End Try
    'End Sub


    'Private Sub dgvBOM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = ""
    '    Try
    '        If e.RowIndex < 0 OrElse Me.dgvBOM.Rows.Count <= 0 Then Exit Sub

    '        o_strColumnName = dgvBOM.CurrentCell.OwningColumn.Name

    '        Dim b As String = dgvBOM.Columns(enumdgvBOM.PlanDueDate).Name + "," + dgvBOM.Columns(enumdgvBOM.RealDueDate).Name
    '        If ("," & b & ",").IndexOf("," & o_strColumnName & ",") >= 0 Then 'o_strColumnName.IndexOf(b) > 0 Then
    '            Dim FrmEditTime As New FrmEditTime
    '            FrmEditTime.ShowDialog()
    '        Else
    '            'not show time
    '        End If

    '        If SampleCom.SqlClassD.UpdateTime.ToString <> "" Then
    '            Select Case o_strColumnName
    '                Case dgvBOM.Columns(enumdgvBOM.PlanDueDate).Name
    '                    strPlanDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    SampleCom.SqlClassD.UpdateTime = ""
    '                    o_strSQL.Append(" Update m_SampleBOM_t SET PlanDueDate = '" & strPlanDate & "' ")
    '                    o_strSQL.Append(" WHERE  SampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND NO ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.No).Value & "' ")
    '                    Me.dgvBOM.CurrentCell.Value = strPlanDate
    '                Case dgvBOM.Columns(enumdgvModel.RealDueDate).Name
    '                    strRealDate = String.Format(CDate(SampleCom.SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
    '                    SampleCom.SqlClassD.UpdateTime = ""
    '                    o_strSQL.Append(" Update m_SampleBOM_t Set RealDueDate = '" & strRealDate & "' ")
    '                    o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvBOM.Rows(e.RowIndex).Cells(enumdgvBOM.No).Value & "' ")
    '                    Me.dgvBOM.CurrentCell.Value = strRealDate
    '            End Select

    '            If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '                DbOperateUtils.ExecSQL(o_strSQL.ToString)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "dgvBOM_CellClick", "sys")
    '    End Try
    'End Sub

    'Private Sub dgvEqu_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEqu.CellMouseLeave
    '    If e.RowIndex < 0 OrElse Me.dgvEqu.Rows.Count <= 0 Then Exit Sub
    '    Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = "", strIsShare As String = "", strSharePN As String = ""
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_tempRealDate As Date
    '    Dim blnUpdateMaxPlanDate As Boolean = False
    '    o_strColumnName = dgvEqu.CurrentCell.OwningColumn.Name

    '    Select Case o_strColumnName
    '        Case dgvEqu.Columns(enumdgvEqu.PlanDueDate).Name
    '            strPlanDate = dgvEqu.CurrentCell.EditedFormattedValue
    '            o_strSQL.Append(" Update m_SampleEqu_t Set PlanDueDate = '" & strPlanDate & "' ")
    '            o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
    '            Me.dgvEqu.CurrentCell.Value = strPlanDate
    '            blnUpdateMaxPlanDate = True
    '        Case dgvEqu.Columns(enumdgvEqu.RealDueDate).Name
    '            strRealDate = dgvEqu.CurrentCell.EditedFormattedValue
    '            Date.TryParse(strRealDate, o_tempRealDate)
    '            If strRealDate <> "" AndAlso Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
    '                MessageUtils.ShowError("填入的日期不能早于今天！！")
    '                Me.dgvEqu.CurrentCell.Value = ""
    '                Exit Sub
    '            End If
    '            o_strSQL.Append(" Update m_SampleEqu_t Set RealDueDate = '" & strRealDate & "' ")
    '            o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvEqu.Rows(e.RowIndex).Cells(enumdgvEqu.No).Value & "' ")
    '            Me.dgvEqu.CurrentCell.Value = strRealDate
    '        Case Else
    '            'do nothing
    '    End Select

    '    If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '        DbOperateUtils.ExecSQL(o_strSQL.ToString)
    '        If blnUpdateMaxPlanDate Then
    '            Dim o_SQL As New StringBuilder
    '            'MAX( cast(nullif(PlanDuedate,'') as date))
    '            o_SQL.Append(" Declare @MaxPlanDate datetime")
    '            o_SQL.Append(" SELECT @MaxPlanDate= MAX( cast(nullif(PlanDuedate,'') as date)) FROM m_SampleEqu_t WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND IsExist ='0' AND ISNULL(RealDuedate,'') = ''")
    '            o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE sampleno = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.EquGive & "'")
    '            DbOperateUtils.ExecSQL(o_SQL.ToString)
    '        End If
    '        'check All Plandate and DueDate finish
    '        If SampleCom.CheckIsEquDateFinish(Me.txtSampleNo.Text.Trim) Then
    '            'update the step finish
    '            Call UpdateStatus(SheetType.ZEqu, 1)
    '        Else
    '            Call UpdateStatus(SheetType.ZEqu, 0)
    '        End If
    '    End If
    'End Sub

    'Private Sub dgvZEqu_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvZEqu.CellMouseLeave
    '    If e.RowIndex < 0 OrElse Me.dgvZEqu.Rows.Count <= 0 Then Exit Sub
    '    Dim o_strColumnName As String = "", strPlanDate As String = "", strRealDate As String = "", strIsShare As String = "", strSharePN As String = ""
    '    Dim o_strSQL As New StringBuilder
    '    Dim o_tempRealDate As Date
    '    Dim o_blnUpdateMaxPlanDate As Boolean = False
    '    o_strColumnName = dgvZEqu.CurrentCell.OwningColumn.Name
    '    Select Case o_strColumnName
    '        Case dgvZEqu.Columns(enumdgvZEqu.PlanDueDate).Name
    '            strPlanDate = dgvZEqu.CurrentCell.EditedFormattedValue
    '            o_strSQL.Append(" Update m_SampleZEqu_t Set PlanDueDate = '" & strPlanDate & "' ")
    '            o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
    '            Me.dgvZEqu.CurrentCell.Value = strPlanDate
    '            o_blnUpdateMaxPlanDate = True
    '        Case dgvZEqu.Columns(enumdgvZEqu.RealDueDate).Name
    '            strRealDate = dgvZEqu.CurrentCell.EditedFormattedValue
    '            If Not String.IsNullOrEmpty(strRealDate) Then
    '                Date.TryParse(strRealDate, o_tempRealDate)
    '                If Date.Compare(o_tempRealDate, DateTime.Now.Date) < 0 Then
    '                    MessageUtils.ShowError("填入的日期不能早于今天！！")
    '                    Me.dgvZEqu.CurrentCell.Value = ""
    '                    Exit Sub
    '                End If
    '            Else
    '                'do nothing
    '            End If
    '            'o_strSQL.Append(" Update m_SampleZEqu_t Set RealDueDate = '" & strRealDate & "' ")
    '            'o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' AND no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
    '            Me.dgvZEqu.CurrentCell.Value = strRealDate

    '        Case dgvZEqu.Columns(enumdgvZEqu.IsShare).Name
    '            strIsShare = dgvZEqu.CurrentCell.EditedFormattedValue
    '            o_strSQL.Append(" Update m_SampleZEqu_t Set IsShare = N'" & strIsShare & "' ")
    '            o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
    '            Me.dgvZEqu.CurrentCell.Value = strIsShare
    '        Case dgvZEqu.Columns(enumdgvZEqu.SharePN).Name
    '            strSharePN = dgvZEqu.CurrentCell.EditedFormattedValue
    '            o_strSQL.Append(" Update m_SampleZEqu_t Set SharePN = N'" & strSharePN & "' ")
    '            o_strSQL.Append(" WHERE  sampleNO ='" & Me.txtSampleNo.Text.Trim & "' and no ='" & Me.dgvZEqu.Rows(e.RowIndex).Cells(enumdgvZEqu.No).Value & "' ")
    '            Me.dgvZEqu.CurrentCell.Value = strSharePN
    '    End Select

    '    If Not String.IsNullOrEmpty(o_strSQL.ToString) Then
    '        DbOperateUtils.ExecSQL(o_strSQL.ToString)

    '        If o_blnUpdateMaxPlanDate Then
    '            Dim o_SQL As New StringBuilder
    '            'MAX( cast(nullif(PlanDuedate,'') as date))
    '            o_SQL.Append(" Declare @MaxPlanDate datetime")
    '            o_SQL.Append(" SELECT @MaxPlanDate= MAX( cast(nullif(PlanDuedate,'') as date)) FROM m_SampleZEqu_t WHERE Sampleno ='" & Me.txtSampleNo.Text.Trim & "' AND isnull(IsShare,'') =N'否' AND isnull(RealDuedate,'') = ''")
    '            o_SQL.Append(" Update M_SampleD_t SET PlanDueDate = @MaxPlanDate WHERE SAMPLENO = '" & Me.txtSampleNo.Text.Trim & "' AND levelid ='" & SampleCom.enumLevelID.ZEquGive & "'")
    '            DbOperateUtils.ExecSQL(o_SQL.ToString)
    '        End If
    '        'check All Plandate and DueDate finish
    '        If SampleCom.CheckIsZEquDateFinish(Me.txtSampleNo.Text.Trim) Then
    '            'update the step finish
    '            Call UpdateStatus(SheetType.ZEqu, 1)
    '        Else
    '            Call UpdateStatus(SheetType.ZEqu, 0)
    '        End If
    '    End If
    'End Sub


    'Private Function UploadFileOfBOM() As Boolean
    '    Dim errorMsg As String = Nothing
    '    Dim dtUploadData As New DataTable
    '    Try
    '        '取得用户上传表数据 'EquName
    '        dtUploadData = ExcelUtils.ExportFromExcelByAs(txtEquFilePath.Text, "BOM清单", 0, 0, errorMsg)

    '        '在表的末尾加两列
    '        Dim column As DataColumn
    '        column = New DataColumn()
    '        column.DataType = System.Type.GetType("System.String")
    '        column.ColumnName = "SampleNo"
    '        dtUploadData.Columns.Add("SampleNo")

    '        Dim columnIsExist As DataColumn
    '        columnIsExist = New DataColumn()
    '        columnIsExist.DataType = System.Type.GetType("System.String")
    '        columnIsExist.ColumnName = "IsExist"
    '        dtUploadData.Columns.Add("IsExist")

    '        ChangeCDDataTableColumnName(dtUploadData, SheetType.BOM)

    '        Dim DrrR As DataRow() = dtUploadData.Select("No is not null and  PartNo IS NOT NULL ") '防止追加

    '        '批量插入到DB中
    '        Dim dics As New Dictionary(Of String, String)
    '        'No, PartNO, Specs,supplier, Qty, Unit, PlanDuedate, RealDuedate
    '        dics.Add("No", "No")
    '        dics.Add("PartNo", "PartNo")
    '        dics.Add("Specs", "Specs")
    '        dics.Add("supplier", "supplier")
    '        dics.Add("Qty", "Qty")
    '        dics.Add("Unit", "Unit")
    '        dics.Add("CCDutyUserName", "CCDutyUserName")
    '        dics.Add("SGDutyUserName", "SGDutyUserName")
    '        dics.Add("PlanDuedate", "PlanDuedate")
    '        dics.Add("RealDuedate", "RealDuedate")
    '        dics.Add("SampleNo", "SampleNo")
    '        dics.Add("IsExist", "IsExist")

    '        Dim usercopy As New DataTable
    '        usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值

    '        _ccDutyName = SampleCom.GetCCUserName(_sampleNumber)
    '        _sgDutyName = SampleCom.GetSGUserName(_sampleNumber)

    '        For Each row As DataRow In DrrR
    '            If row(0).ToString <> "" Then
    '                usercopy.Rows.Add(row(ImportToGridOfBOM.No).ToString(), row(ImportToGridOfBOM.PartNo).ToString(), row(ImportToGridOfBOM.Specs).ToString, _
    '                                  row(ImportToGridOfBOM.supplier).ToString, row(ImportToGridOfBOM.Qty).ToString, row(ImportToGridOfBOM.Unit).ToString,
    '                                 _ccDutyName, _sgDutyName, row(ImportToGridOfBOM.PlanDuedate).ToString, _
    '                                 row(ImportToGridOfBOM.RealDuedate).ToString, _sampleNumber, "")
    '            End If
    '        Next

    '        Call SampleCom.DeleteBOM(_sampleNumber)

    '        Dim errMsg As String = String.Empty
    '        '数据库表中有A、B、C三列，其中B列有默认值，这时用于插入的DataTable不能只有A、C两列, 
    '        If DbOperateUtils.BulkCopy(usercopy, "m_SampleBOM_t", dics, errMsg) = True Then
    '            If errMsg <> String.Empty Then
    '                MessageUtils.ShowInformation(errMsg)
    '            Else
    '                ' SearchRecord("")
    '            End If
    '        End If
    '        UploadFileOfBOM = True
    '    Catch ex As Exception
    '        UploadFileOfBOM = False
    '        lblMsg.Text = ex.Message
    '        SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleUpload", "UploadFileOfBOM", "sys")
    '    End Try
    'End Function
#End Region

    Private Sub btnBOMLook_Click(sender As Object, e As EventArgs) Handles btnBOMLook.Click
        If String.IsNullOrEmpty(Me.txtBOMFilePath.Text) Then
            Exit Sub
        End If

        System.Diagnostics.Process.Start(Me.txtBOMFilePath.Text)
    End Sub

    Private Sub btnImportBOM_Click(sender As Object, e As EventArgs) Handles btnImportBOM.Click
        Call ImportBOM()
        MessageUtils.ShowInformation("上传BOM成功!")
    End Sub
End Class