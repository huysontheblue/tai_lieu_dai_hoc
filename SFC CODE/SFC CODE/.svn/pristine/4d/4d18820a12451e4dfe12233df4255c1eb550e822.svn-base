Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports SysBasicClass
Imports System.Windows.Forms
'Imports SysBasicClass

Public Class FrmRunCardHeaderEdit

    Sub New(ByVal action As String, ByVal dataGridViewRow As DataGridViewRow)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._action = action
        Me._gridViewRow = dataGridViewRow

        If Not Me._gridViewRow Is Nothing Then
            Dim SeriesName = Me._gridViewRow.Cells(RunCardBusiness.NewHeaderGrid.SeriesName.ToString).Value
            SeriesName = IIf(SeriesName Is DBNull.Value, "", SeriesName.ToString())
            CobSeries.Text = SeriesName
        End If

    End Sub

#Region "属性"

    Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^(0|[1-9]\d{0,6})(\.\d{0,6}[1-9])?$")
    Private m_strInitialVersion As String = String.Empty



#Region "Version"
    Private _version As String
    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
#End Region

#Region "GridViewRow"
    Private _gridViewRow As DataGridViewRow
    Public ReadOnly Property GridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get
    End Property
#End Region

#Region "Action"
    Private _action As String
    Public ReadOnly Property Action() As String
        Get
            Return _action
        End Get
    End Property
#End Region

#Region "DrawingFileName"
    Private _DrawingFileName As String
    Public Property DrawingFileName() As String
        Get
            Return _DrawingFileName
        End Get

        Set(ByVal Value As String)
            _DrawingFileName = Value
        End Set
    End Property
#End Region

#End Region

#Region "事件"

#Region "FrmRunCardHeaderEdit_Load"
    Private Sub FrmRunCardHeaderEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        loadStationType()

        Dim lsSQL As String = ""
        Try
            lblMsg.Text = ""
            lblId.Text = ""
            lblPartId.Text = ""

            IniteControls(Me.Action)
            If Me.CobCust.Enabled = True Then
                lsSQL = " SELECT  cusid,cusname from m_Customer_t WHERE usey='Y' " '& _
                '" AND  cusid in (SELECT  buttonid from m_UserRight_t a INNER JOIN m_Logtree_t b on a.tkey =b.tkey " & _
                '" WHERE b.tparent='c0_' and userid='" & SysMessageClass.UseId & "')"
                FillGridCombox(Me.CobCust, lsSQL)
                If Me.CobCust.Text = "" Then
                    FillGridCombox(Me.CobSeries, " SELECT [SeriesID],[SeriesName] FROM [m_Series_t] WHERE Usey='Y'")
                Else
                    'Me.CobCust.SelectedItem.ToString.Split("(")(0)
                    '  FillGridCombox(Me.CobSeries, " SELECT a.SeriesID,b.SeriesName FROM m_CusSerMap_t a left join m_Series_t b on a.SeriesID = b.SeriesID WHERE cusID='" & Me.CobCust.SelectedItem.ToString.Split("(")(0) & "' ")
                    FillGridCombox(Me.CobSeries, "SELECT a.SeriesID,b.SeriesName FROM m_CusSerMap_t a left join m_Series_t b on a.SeriesID = b.SeriesID  WHERE cusID='" & Me.CobCust.SelectedItem.ToString.Split("(")(0) & "' ")

                End If
            End If
            m_strInitialVersion = Me.txtDrawingVer.Text
        Catch ex As Exception
            MessageUtils.ShowError("加载数据异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

#Region "加载工站类型"
    ''' <summary>
    ''' 加载工站类型
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadStationType()
        Dim sql = String.Format("SELECT SortID, SortName from m_Sortset_t " & vbCrLf &
        "where SortType = 'StationType'" & vbCrLf &
        "and Usey='Y' and SortID" & vbCrLf &
        "in" & vbCrLf &
        "(" & vbCrLf &
        "select substring(Ttext,0,  charindex('-',Ttext,0))" & vbCrLf &
        "from m_Logtree_t where Tkey in (" & vbCrLf &
        "select tkey from m_UserRight_t" & vbCrLf &
        "where UserID='" & MainFrame.SysCheckData.SysMessageClass.UseId & "'" & vbCrLf &
        "and Tkey in ('RCard2_24','RCard2_25'))) order by Orderid")
        Dim dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        cmbStationType.DataSource = dt
        cmbStationType.ValueMember = "SortID"
        cmbStationType.DisplayMember = "SortName"
        If dt.Rows.Count > 0 Then
            cmbStationType.SelectedIndex = 0
        Else
            cmbStationType.SelectedIndex = -1
        End If
    End Sub
#End Region

    Public listSerial As New List(Of String)

    Public listCust As New List(Of String) '客户数据源

    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        listSerial.Clear()

        Do While ScanReader.Read()
            If CobName.Name <> "CobSeries" Then
                'CobName.Items.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
                listCust.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
            Else
                ' CobName.Items.Add(ScanReader(1).ToString & "-" & ScanReader(0).ToString)
                listSerial.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
            End If
        Loop
        ScanReader.Close()
        If CobName.Name = "CobSeries" Then
            CobName.Items.AddRange(listSerial.ToArray())
        ElseIf CobName.Name = "CobCust" Then
            CobName.Items.AddRange(listCust.ToArray())
        End If
        CobName.SelectedIndex = -1
    End Sub
#End Region

    '''<summary>
    ''' 自动生成文件编号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFileNO() As String
        Dim FileNO = ""
        Dim sb = New System.Text.StringBuilder()
        '获取最新文件编码:DOC+yy+10位流水码
        sb.Append(" declare @No nvarchar(20);declare @prevNo nvarchar(20);declare @prefix nvarchar(20);")
        sb.Append(" set @No=right(DATEPART(YEAR,getdate()),2);set @prefix='DOC' ;")
        sb.Append(" select top 1 @prevNo=FileNO from m_RCardM_t where  right(DATEPART(YEAR,InTime),2) =right(DATEPART(YEAR,getdate()),2)   and isnull(FileNO,'')<>'' order by InTime desc; ")
        sb.Append(" if(@prevNo is null) begin  set @No=@prefix+@No+'-00000001'; End")
        sb.Append(" else begin set @prevNo = cast((cast(right(@prevNo,8) as int) + 1) AS varchar(10));")
        sb.Append("  set @prevNo='-'+replicate('0',8-len(@prevNo))+ @prevNo;  ")
        sb.Append(" set @No=@prefix+@No+@prevNo; End select @No")
        FileNO = MainFrame.DbOperateUtils.GetDataTable(sb.ToString()).Rows(0)(0).ToString
        Return FileNO
    End Function

#Region "btnCheckBom_Click"

    Private Sub btnCheckBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckBom.Click
        Try
            Me.lblMsg.Text = String.Empty
            Dim partNumber As String = Me.txtPartNumber.Text.Trim
            If String.IsNullOrEmpty(partNumber) Then
                lblMsg.Text = "料件编号不能为空!"
                Me.txtPartNumber.Focus()
                Exit Sub
            End If
            '下载BOM
            Dim msg As String = ""
            'If is a set PN, then get the SetPN
            'If partNumber.IndexOf("-") > 0 Then
            '    If RunCardBusiness.IsSetPN(partNumber.Substring(0, InStr(partNumber, "-") - 1)) Then
            '        partNumber = partNumber.Substring(0, InStr(partNumber, "-") - 1)
            '    End If
            'End If
            If DownloadBom(partNumber, msg) = False Then
                Me.lblMsg.Text = msg
                Exit Sub
            End If
            ' End If
            '设置可编辑状态
            IniteControls("checked")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", " btnCheckBom_Click", "RCard")
        End Try
    End Sub

#End Region

#Region "文件上传"
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        btnUpload.Enabled = False
        Me.DrawingFileName = ""
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Me.txtDrawingPath.Text = OpenFileDialog1.FileName
            Me.DrawingFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUpload.Enabled = True
    End Sub
#End Region

#Region "btnOK_Click"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If CheckInput() = True Then
                '保存
                SaveData()
                '提示
                MessageUtils.ShowInformation("保存成功！")
                '退出
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "btnOK_Click", "sys")
        End Try
    End Sub
#End Region

#Region "退出"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "方法"

#Region "输入检查"
    Private Function CheckInput() As Boolean
        Dim partNumber As String = Me.txtPartNumber.Text.Trim
        If Action = "add" Then
            '料件是否已建档
            If RunCardExists(partNumber) = True Then
                Me.lblMsg.Text = "料件：" & partNumber & " 工艺流程已存在,请勿重复!"
                Me.txtPartNumber.Focus()
                Return False
            End If
        End If
        If String.IsNullOrEmpty(partNumber) Then
            Me.lblMsg.Text = "料件编号不能为空!"
            Me.txtPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtDrawingVer.Text.Trim) Then
            Me.lblMsg.Text = "版本号不能为空!"
            Me.txtDrawingVer.Focus()
            Return False
        Else '跟TT中的版本进行校验
            '以“9”开头成品料号，系统自动校验版本；其他料号不用校验版本, CQ 20151127, 研发虚拟订单不卡版本
            If partNumber.Trim.StartsWith("9") Then
                Dim verErp As String = RunCardBusiness.GetVerFromErp(partNumber).ToUpper()
                If (Not String.IsNullOrEmpty(verErp)) AndAlso verErp.Trim <> Me.txtDrawingVer.Text.Trim Then  'cq 20170206 
                    Me.lblMsg.Text = "版本号与Erp（" & verErp & ")不匹配，请检查!"
                    Me.txtDrawingVer.Focus()
                    Return False
                End If
            Else
                'bypass check 
            End If
        End If

        'If Not reg.IsMatch(txtFinishSize.Text) Then
        '    lblMsg.Text = """成品尺寸""不正确"
        '    txtFinishSize.SelectAll()
        '    Return False
        'End If
        'cq 20160815
        If String.IsNullOrEmpty(Me.txtShape.Text.Trim) Then
            Me.lblMsg.Text = "形态不能为空!"
            Me.txtShape.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Me.txtStdLabors.Text) Then
            If Val(Me.txtStdLabors.Text) = 0 Then
                Me.lblMsg.Text = "标准拍配人力输入错误!"
                Me.txtStdLabors.Focus()
                Return False
            End If
        End If

        If cmbStationType.SelectedValue Is Nothing Then
            Me.lblMsg.Text = "请联系MES相关人员维护当前用户的工站类型的权限"
            Return False
        End If

        Return True
    End Function
#End Region

#Region "初始化控件"
    Private Sub IniteControls(ByVal flag As String)
        Select Case flag
            Case "add"
                Me.txtDrawingVer.Enabled = False
                Me.txtShape.Enabled = False
                Me.txtDrawingPath.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnUpload.Enabled = False
                Me.CobCust.Enabled = True
                Me.CobSeries.Enabled = True
                txtFileNO.Text = getFileNO()
            Case "modify"
                Me.Text = "编辑流程卡"
                If Not Me.GridViewRow Is Nothing Then
                    Me.txtPartNumber.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.PartId.ToString).Value.ToString
                    Me.txtDrawingVer.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    Me.txtShape.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.Shape.ToString).Value.ToString
                    Me.txtDrawingPath.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.DrawingFilePath.ToString).Value.ToString
                    Me.txtFinishSize.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.FinishSize.ToString).Value.ToString
                    txtFileNO.Text = GridViewRow.Cells(RunCardBusiness.HeaderGrid.FileNO.ToString).Value.ToString
                    Me.Version = GridViewRow.Cells(RunCardBusiness.HeaderGrid.DrawingVer.ToString).Value.ToString
                    Me.txtPartNumber.Enabled = False
                    Me.btnCheckBom.Enabled = False
                    cmbStationType.SelectedValue = GridViewRow.Cells(RunCardBusiness.HeaderGrid.RCardType.ToString).Value.ToString
                    'Me.CobCust.Enabled = False 'update by 马跃平 2018-05-15
                    'Me.CobSeries.Enabled = False 'update by 马跃平 2018-05-15
                End If
            Case "checked"
                Me.txtPartNumber.Enabled = False
                Me.txtDrawingVer.Enabled = True
                Me.txtShape.Enabled = True
                Me.txtDrawingPath.Enabled = True
                Me.btnUpload.Enabled = True
                Me.btnOK.Enabled = True
        End Select
    End Sub
#End Region

#Region "检查料件是否已经建档"
    Private Function RunCardExists(ByVal pn As String) As Boolean
        Dim strSql As String = Nothing
        'Modfiy by cq 20170517 PAvcPart ==>TAvcPart
        If Action = "add" Then
            strSql = "SELECT 1 FROM m_RCardM_t(nolock) where PartID in(select TAvcPart from m_PartContrast_t(nolock) where TAvcPart=N'" & pn & "' and UseY='Y') " &
                    RCardComBusiness.GetFatoryProfitcenter()
        Else
            If Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
                strSql = "SELECT 1 FROM m_RCardDOldVer_t(nolock) where PartID in(select TAvcPart from m_PartContrast_t(nolock) where PAvcPart=N'" & pn & "' and UseY='Y')" &
                RCardComBusiness.GetFatoryProfitcenter()
            End If
        End If
        Dim dt As DataTable = RCardComBusiness.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function
#End Region

#Region "下载BOM"

    Private Function DownloadBom(ByVal pn As String, ByRef msg As String, Optional ByVal HasUI As Boolean = False) As Boolean
        Dim strCustID As String = "", strSeriesID
        Try

            Dim strSQL As String
            Dim dt As DataTable

            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                strSQL = SapCommon.GetErpFilterSqlSap(pn)
                dt = OracleOperateUtils.GetDataTableSap(strSQL)
            Else
                'A. First Download PN from ERP,Add by CQ 20151116
                strSQL = SapCommon.GetErpFilterSqlUnion(pn)
                dt = OracleOperateUtils.GetDataTable(strSQL)
            End If

            If dt.Rows.Count <= 0 Then
                msg = "ERP 中找不到料件""" & pn & """ 信息"
                Return False
            Else
                'As is: Get CustID from TT first, if not get, then get from UI 
                'Now: first get from MES  , cq 
                strCustID = RunCardBusiness.GetCustIDFromMES(pn)
                If String.IsNullOrEmpty(strCustID) Then
                    strCustID = RunCardBusiness.GetCustIDFromTT(pn)
                    If String.IsNullOrEmpty(strCustID) Then
                        If (Not IsNothing(Me.CobCust.SelectedItem)) AndAlso Me.CobCust.SelectedItem.ToString <> "" Then
                            strCustID = Me.CobCust.SelectedItem.ToString.Split("(")(0)
                        Else
                            msg = "请先选择客户编号！！"
                            Return False
                        End If
                    Else
                        Me.CobCust.SelectedIndex = Me.CobCust.FindString(strCustID)

                    End If
                Else
                    Me.CobCust.SelectedIndex = Me.CobCust.FindString(strCustID)

                End If

                'Get Serial from TT first, if not get, then get from UI
                'Now: first get from MES  , cq 2016/06/14
                strSeriesID = RunCardBusiness.GetSerialIDFromMES(pn)
                If String.IsNullOrEmpty(strSeriesID) Then
                    strSeriesID = RunCardBusiness.GetSerialIDFromTT(pn)
                    If String.IsNullOrEmpty(strSeriesID) Then
                        If (Not IsNothing(Me.CobSeries.SelectedItem)) AndAlso Me.CobSeries.SelectedItem.ToString <> "" Then
                            strSeriesID = Me.CobSeries.SelectedItem.ToString.Split("(")(0)
                        Else
                            If Not HasUI Then
                                'strSeriesID = "018"

                                Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(strSeriesID)
                            Else
                                msg = "请先选择系列别！！"
                                Return False
                            End If
                        End If
                    Else
                        Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(strSeriesID)
                    End If
                Else
                    Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(strSeriesID)
                End If

                dt.Columns.Add("CustID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("CustID") = strCustID
                Next

                dt.Columns.Add("SeriesID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("SeriesID") = strSeriesID
                Next

                RunCardBusiness.SaveErpData(dt)
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "DownloadBom", "RCard")
            Throw ex
        End Try
    End Function

#End Region

#Region "TAB 处理"
    Private Sub FrmRunCardHeaderEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "保存数据"
    Private Sub SaveData()

        Dim result As String = String.Empty
        Dim ServerFile As String = ""
        Dim PartNumber As String = Me.txtPartNumber.Text.Trim
        Dim DrawingVer As String = Me.txtDrawingVer.Text.Trim
        Dim DrawingFilePath As String = Me.txtDrawingPath.Text.Trim
        Dim Shape As String = Me.txtShape.Text.Trim
        Dim FinishSize As String = IIf(txtFinishSize.Text.Trim = "", "0", CStr(Val(txtFinishSize.Text.Trim)))
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
        Dim msg As String = String.Empty
        Dim o_blnOnlyUpdateBOM As Boolean = False
        Dim StdLabors As String = IIf(Val(Me.txtStdLabors.Text.Trim) = 0, "", Val(Me.txtStdLabors.Text.Trim))
        Dim SeriesID = ""
        If Not String.IsNullOrEmpty(CobSeries.Text) Then
            SeriesID = CobSeries.Text.Substring(0, CobSeries.Text.IndexOf("("))
        End If
        Dim FileNO = txtFileNO.Text.Trim()
        Try
            '有选择上传
            If Not String.IsNullOrEmpty(Me.DrawingFileName) Then
                If Not String.IsNullOrEmpty(DrawingFilePath) Then
                    Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath, PartNumber)
                    If System.IO.Directory.Exists(destFilePath) = False Then
                        Directory.CreateDirectory(destFilePath)
                    End If
                    ServerFile = Path.Combine(destFilePath, Me.DrawingFileName)
                    File.Copy(DrawingFilePath, ServerFile, True)
                End If
            Else '未选择上传
                ServerFile = DrawingFilePath
            End If
            '新增
            Dim StrSql As String = String.Empty
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            If Action = "add" Then
                '写入DB
                StrSql = " IF NOT EXISTS(SELECT TOP 1 1 FROM m_RCardM_t WHERE PARTID='" & PartNumber & "' AND Factoryid='" & Factoryid & "' AND Profitcenter='" & Profitcenter & "') " & _
                         " Begin " & _
                         "INSERT INTO m_RCardM_t(PartID,DrawingVer,DrawingFilePath,Shape,FinishSize,Status,UserID,InTime,Factoryid,Profitcenter,StdLabors,SeriesID,RCardType,FileNO) VALUES(" &
                         "'{0}',N'{1}',N'{2}',N'{3}',{4},0,'{5}',getdate(),'{6}','{7}','{8}','{9}','{10}','{11}')" & _
                         " End"
                StrSql = String.Format(StrSql, PartNumber, DrawingVer, ServerFile, Shape, FinishSize, UserID, Factoryid, Profitcenter, StdLabors, SeriesID, cmbStationType.SelectedValue, FileNO)
            Else
                If Not String.IsNullOrEmpty(Me.Version) AndAlso Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
                    StrSql = (RunCardBusiness.GetRCardEditSQLOfValue(PartNumber, Me.Version, Factoryid, Profitcenter))

                    StrSql = StrSql + RunCardBusiness.GetSaveOldBOMSQL(PartNumber, DrawingVer, Factoryid, Profitcenter)

                    StrSql = StrSql + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                       " SELECT  @OldUserID=USERID ,@OldModifyTime=ModifyTime FROM m_RCardM_t WHERE PARTID='" & PartNumber & "'" & _
                        " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                       " Values('" & PartNumber & "','',N'版本', @OldUserID, @OldModifyTime,N'" & Me.Version.ToUpper & "'," & _
                       " '" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & txtDrawingVer.Text.Trim.ToUpper & "')"
                    'Add when change version, also auto download bom data 20160614
                    If Not DownloadBom(PartNumber, msg) Then
                        Me.lblMsg.Text = msg
                        Exit Sub
                    End If
                Else
                    'Add when click "modify" ,  auto download bom data 20160705
                    If Not DownloadBom(PartNumber, msg) Then
                        Me.lblMsg.Text = msg
                        Exit Sub
                    End If
                    o_blnOnlyUpdateBOM = True
                End If

                If Not o_blnOnlyUpdateBOM Then
                    'CQ 20160707, update userid
                    StrSql += " UPDATE m_RCardM_t SET MODIFYTIME=GETDATE() ,DrawingVer=N'" & DrawingVer & "',STATUS=0,DrawingFilePath=N'" & ServerFile &
                                "',Shape=N'" & Shape & "',FinishSize = '" & FinishSize & "', StdLabors='" & StdLabors & "',InTime=getdate()," & _
                                " userid ='" & VbCommClass.VbCommClass.UseId & "' ,SeriesID='" & SeriesID & "',FileNO='" & FileNO & "' WHERE PartID='" & PartNumber & "'"
                    'Modify by cq 20160705,remove update intime
                    StrSql += " UPDATE m_RCardD_t SET DrawingVer=N'" & DrawingVer & "' WHERE PartID='" & PartNumber & "'"
                    StrSql += " UPDATE m_RCardDPart_t SET InTime=GETDATE() ,DrawingVer=N'" & DrawingVer & "' WHERE PartID='" & PartNumber & "'"
                Else
                    'Add moidy shape, cq20170320
                    StrSql += " UPDATE m_RCardM_t SET MODIFYTIME=GETDATE() ,Shape=N'" & Shape & "',FinishSize = '" & FinishSize & "',StdLabors='" & StdLabors & "',SeriesID='" & SeriesID & "',FileNO='" & FileNO & "' WHERE PartID='" & PartNumber & "'"
                End If
            End If

            If Not String.IsNullOrEmpty(StrSql) Then
                Dim al As ArrayList = New ArrayList
                al.Add("PartID|" & PartNumber)
                al.Add("Version|" & Me.Version)
                al.Add("Factoryid|" & Factoryid)
                al.Add("Profitcenter|" & Profitcenter)

                RCardComBusiness.ExecSQL(StrSql, al)
            End If
            If result <> "" Then
                Throw New Exception(result)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "SaveData", "RCard")
        End Try
    End Sub
#End Region

#End Region

    Private listNew As List(Of String) = New List(Of String)()
    Private Sub CobSeriesID_TextUpdate(sender As Object, e As EventArgs) Handles CobSeries.TextUpdate
        '清空combobox
        Me.CobSeries.Items.Clear()
        '清空listNew
        listNew.Clear()
        '遍历全部备查数据
        For Each item In listSerial
            If (item.ToUpper.Contains(Me.CobSeries.Text.ToUpper)) Then
                listNew.Add(item)
            End If
        Next
        'combobox添加已经查到的关键词
        Me.CobSeries.Items.AddRange(listNew.ToArray())
        '设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        Me.CobSeries.SelectionStart = Me.CobSeries.Text.Length
        ' //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        Cursor = Cursors.Default
        '自动弹出下拉框
        Me.CobSeries.DroppedDown = True
    End Sub

    Private Sub CobCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobCust.SelectedIndexChanged
        Dim Cust = CobCust.Text.Substring(0, CobCust.Text.IndexOf("("))
        If Cust = "99" Then
            If (Not IsNothing(Me.CobCust.SelectedItem)) AndAlso CobCust.Text <> String.Empty Then
                FillGridCombox(Me.CobSeries, "SELECT a.SeriesID,b.SeriesName FROM m_CusSerMap_t a left join m_Series_t b on a.SeriesID = b.SeriesID  WHERE cusID='" & Cust & "' ")
            End If
        Else
            FillGridCombox(Me.CobSeries, "select SeriesID,SeriesName from m_Series_t")
        End If
    End Sub

    Private Sub CobCust_TextUpdate(sender As Object, e As EventArgs) Handles CobCust.TextUpdate
        '清空combobox
        Me.CobCust.Items.Clear()
        '清空listNew
        listNew.Clear()
        '遍历全部备查数据
        For Each item In listCust
            If (item.ToUpper.Contains(Me.CobCust.Text.ToUpper)) Then
                listNew.Add(item)
            End If
        Next
        'combobox添加已经查到的关键词
        Me.CobCust.Items.AddRange(listNew.ToArray())
        '设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        Me.CobCust.SelectionStart = Me.CobCust.Text.Length
        ' //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        Cursor = Cursors.Default
        '自动弹出下拉框
        Me.CobCust.DroppedDown = True
        'Dim where = ""
        'If Not String.IsNullOrEmpty(CobCust.Text.Trim()) Then
        '    Dim txt = CobCust.Text.Trim()
        '    where = " and (cusid like '%" & txt & "%' or cusname like N'%" & txt & "%' )"
        'End If
        'Dim lsSQL = " SELECT  cusid,cusname from m_Customer_t WHERE usey='Y' " & where
        'FillGridCombox(Me.CobCust, lsSQL)
    End Sub
End Class