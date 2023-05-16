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

Public Class FrmQuoteMaintenance

#Region "SopFileName1"
    Private _sopFileName1 As String
    Public Property SopFileName1() As String
        Get
            Return _sopFileName1
        End Get

        Set(ByVal Value As String)
            _sopFileName1 = Value
        End Set
    End Property

    Private _sopFileName2 As String
    Public Property SopFileName2() As String
        Get
            Return _sopFileName2
        End Get

        Set(ByVal Value As String)
            _sopFileName2 = Value
        End Set
    End Property

    Private _sqlWhere As String = ""
    Public Property sqlWhere() As String
        Get
            Return _sqlWhere
        End Get

        Set(ByVal Value As String)
            _sqlWhere = Value
        End Set
    End Property
#End Region

#Region "定义"

    Private folder As String = Environment.CurrentDirectory & "\UpLoadMessage\ErrorMessages_" & Date.Now.ToString("yyyyMMdd")
    Private bakFolder As String = Environment.CurrentDirectory & "\UpLoadMessage\SuccessFiles_" & Date.Now.ToString("yyyyMMdd")
    Private errorMsgs As New System.Text.StringBuilder
    Dim opflag As Integer = 1

    Public Enum enumdgvRStation
        Selected
        PartNumber
        ItemNum
        Ver
        ProductFrom
        StandardQuoteHour
        QuoteHour
        MatchingHour
        ChildCount  '8
        Efficiency
        TaxQuoHour
        Remark
        FilePath1
        FilePath2
        CreaterName
        CreateTime
        QuoteNo
        Creater
    End Enum


    Private Enum ImportGrid
        DevelopReference '开发案号
        PartNumber '料号
        ItemNum '项次
        Ver '版本
        ProductFrom '形态
        QuoteHour '评估工时
        MatchingHour '配套工时
        Efficiency '效率
        TaxQuoHour '效率工时
        Creater '创建工号
        CreaterName '创建姓名
        CreateTime '创建时间
        Remark '备注
    End Enum

#End Region

    Private Sub FrmQuoteMaintenance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")
            Case 13
                SendKeys.Send("{Tab}")
            Case 27
                Me.Close()
        End Select
    End Sub
    '初期化
    Private Sub FrmQuoteMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.DesignMode = False Then
            '设定用戶權限
            Dim sysDB As New SysDataBaseClass
            '权限 
            sysDB.GetControlright(Me)
            ReSet(5)
            LoadDataToDatagridview("")
            txt_Efficiency.SelectedIndex = 0
            ShowMaxHoursColumn()
        End If
    End Sub

#Region "只要用户有新增或者修改的权限就显示效率和效率工时"
    ''' <summary>
    ''' 只要用户有新增或者修改的权限就显示效率和效率工时
    ''' add by 马跃平 201807-18
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowMaxHoursColumn()
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim RightDr As SqlDataReader

        RightDr = Sdbc.GetDataReader("select ButtonID from m_Logtree_t a left join m_userright_t b on a.Tkey=b.tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' AND a.Formid=(select apid from m_SysapForm_t where Apformid='" & Me.Name & "' ) and a.listy='N'")
        Dim yy = False
        If RightDr.HasRows Then
            While RightDr.Read
                Dim ButtonID = RightDr("ButtonID").ToString()
                If ButtonID.ToUpper() = "TOOLADD" Or ButtonID.ToUpper() = "TOOLEDIT" Then
                    yy = True
                    Exit While
                End If
            End While
        End If
        RightDr.Close()
        dgvRstation.Columns("Efficiency").Visible = yy
        dgvRstation.Columns("QuoteHour").Visible = yy
    End Sub
#End Region


    'Private Sub Erightbutton()
    '    Dim Conn As New SysDataBaseClass
    '    Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
    '    Dim Obj As Object
    '    While Reader.Read
    '        Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
    '        Obj.Tag = "Yes"
    '    End While
    '    Reader.Close()
    '    Conn.PubConnection.Close()
    'End Sub

    '不同状态处理
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 ' 初期化
                'Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                'Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                'Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolAdd.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolAdd.Tag) = "YES", True, False)
                Me.toolEdit.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolEdit.Tag) = "YES", True, False)
                Me.toolAbandon.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolAbandon.Tag) = "YES", True, False)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
            Case 1, 2 '新增，编辑
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
        End Select
    End Sub

#Region "事件处理"

    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        txt_PartNumber.Text = ""
        txt_Versoon.Text = ""
        Me.ActiveControl = Me.txt_PartNumber
        ReSet(4)
        opflag = 1
        txt_Efficiency.SelectedIndex = 0
        ToolbtnState(1)
    End Sub

    '编辑处理
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'Dim Categroy As String = dgvRstation.Item(11, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim  
        '谁创建，谁修改

        Dim Creater = dgvRstation.Item(enumdgvRStation.Creater.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim  '15 + 1
        If Creater.Trim.ToUpper = SysMessageClass.UseId.Trim.ToUpper Then
            opflag = 2
            ReSet(3)

            txt_PartNumber.Text = dgvRstation.Item(enumdgvRStation.PartNumber.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_PartNumberCount.Text = dgvRstation.Item(enumdgvRStation.ItemNum.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_Versoon.Text = dgvRstation.Item(enumdgvRStation.Ver.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_ProductFrom.Text = dgvRstation.Item(enumdgvRStation.ProductFrom.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_QuoteHour.Text = dgvRstation.Item(enumdgvRStation.QuoteHour.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_MatchingHour.Text = dgvRstation.Item(enumdgvRStation.MatchingHour.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '7
            txt_Efficiency.Text = dgvRstation.Item(enumdgvRStation.Efficiency.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_TaxQuoHour.Text = dgvRstation.Item(enumdgvRStation.TaxQuoHour.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txt_Remark.Text = dgvRstation.Item(enumdgvRStation.Remark.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txtPath1.Text = dgvRstation.Item(enumdgvRStation.FilePath1.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            txtPath2.Text = dgvRstation.Item(enumdgvRStation.FilePath2.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim


            txtDevelopReference.Text = dgvRstation.Item("DevelopReference", Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_PartNumber.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_PartNumberCount.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_Versoon.Text = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_ProductFrom.Text = dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_QuoteHour.Text = dgvRstation.Item(5, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_MatchingHour.Text = dgvRstation.Item(enumdgvRStation.MatchingHour, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '7
            'txt_Efficiency.Text = dgvRstation.Item(8 + 1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txt_Remark.Text = dgvRstation.Item(9 + 1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txtPath1.Text = dgvRstation.Item(10 + 1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            'txtPath2.Text = dgvRstation.Item(11 + 1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim


            txtQuoteNo.Text = dgvRstation.Item(enumdgvRStation.QuoteNo.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '14
            ToolbtnState(2)

        Else
            MessageUtils.ShowError("此份报价由：" & Creater & " 创建,只有本人才能修改！")
        End If
    End Sub

    '作废处理
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 Then
            MessageUtils.ShowInformation("没有需要删除的记录！")
            Exit Sub
        End If

        Try

            Dim result As System.Windows.Forms.DialogResult = System.Windows.Forms.MessageBox.Show("确定要删除吗？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Dim Selected As Boolean = False
            Dim Sql As New StringBuilder
            For i As Integer = dgvRstation.Rows.Count - 1 To 0 Step -1
                Dim aaa = dgvRstation.Rows(i).Cells(0).Value
                If dgvRstation.Rows(i).Cells(0).EditedFormattedValue.ToString() = "True" Then
                    Selected = True
                    Dim QuoteNo As String = dgvRstation.Rows(i).Cells(enumdgvRStation.QuoteNo.ToString()).Value.ToString '14
                    'CreateTime=getdate()Creater='" & SysMessageClass.UseId & "'
                    Sql.AppendLine("delete m_RCardQuoteMaintenanceDetail where QuoteNo='" & QuoteNo & "'")
                    Sql.AppendLine("delete m_RCardQuoteMaintenance  where QuoteNo = '" & QuoteNo & "'  ")

                    ''判断是否为此人创建，若有不是此人创建的给出提配，并退出
                    Dim Creater = dgvRstation.Item(enumdgvRStation.Creater.ToString(), i).Value.ToString.Trim  '15
                    If Creater <> SysMessageClass.UseId Then
                        Dim PartNumber As String = dgvRstation.Item(1, i).Value.ToString.Trim
                        MessageUtils.ShowInformation("料号：" & PartNumber & "非本人创建,无法删除！")
                        Exit Sub
                    End If

                End If
            Next

            If Not Selected Then
                MessageUtils.ShowInformation("没有勾选中需要删除的行！")
            Else
                DbOperateUtils.ExecSQL(Sql.ToString())
                LoadDataToDatagridview("")
                MessageUtils.ShowInformation("删除成功！")
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbAbandon_Click", "sys")
            MessageUtils.ShowError("删除失败！")
        End Try
    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim usey As String = "N"
        Dim strfolder As String = ""
        Try
            If Checkdata() = False Then Exit Sub
            Dim SopFilePath1 As String = Me.txtPath1.Text.Trim
            Dim SopFilePath2 As String = Me.txtPath2.Text.Trim
            Dim ServerFile1 As String = ""
            Dim ServerFile2 As String = ""

            If Not String.IsNullOrEmpty(SopFilePath1) Then
                ' VbCommClass.VbCommClass.SopFilePath
                strfolder = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "PrintFile2\QuoteTimeBOMBluePrint\"
                Dim destFilePath As String = Path.Combine(strfolder, txtQuoteNo.Text.Trim)   'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
                If System.IO.Directory.Exists(destFilePath) = False Then
                    Directory.CreateDirectory(destFilePath)
                End If
                ServerFile1 = Path.Combine(destFilePath, GetFileName(SopFilePath1))

                If ServerFile1 <> SopFilePath1 Then
                    File.Copy(SopFilePath1, ServerFile1, True)
                End If

            Else '未选择上传
                ServerFile1 = SopFilePath1
            End If

            If Not String.IsNullOrEmpty(SopFilePath2) Then
                Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "PrintFile2\QuoteTimeBOMBluePrint\", txtQuoteNo.Text.Trim)   'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
                If System.IO.Directory.Exists(destFilePath) = False Then
                    Directory.CreateDirectory(destFilePath)
                End If
                ServerFile2 = Path.Combine(destFilePath, GetFileName(SopFilePath2))
                If ServerFile2 <> SopFilePath2 Then
                    File.Copy(SopFilePath2, ServerFile2, True)
                End If
            Else '未选择上传
                ServerFile2 = SopFilePath2
            End If

            Dim UserName As String = GetUserName(SysMessageClass.UseId)
            Dim TaxQuoHour = Nothing
            If String.IsNullOrEmpty(txt_QuoteHour.Text.Trim()) = False Then

                Dim sql = "select  cast(" & txt_QuoteHour.Text & "/cast (cast(replace('" & txt_Efficiency.Text & "','%','') as float)/100 as decimal(18,2)) as decimal(18,0))"
                TaxQuoHour = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString() '效率工时 add by 马跃平 2018-07-18
            End If
            If opflag = 1 Then
                '查询版次号
                Dim ItemNum As Integer = Val(ReturnItemNum(txt_PartNumber.Text))
                SqlStr.Append("UPDATE m_RCardQuoteMaintenance SET IsHigh=0  where ltrim(rtrim(PartNumber))='" & txt_PartNumber.Text & "'")
                SqlStr.Append(ControlChars.CrLf & "insert into m_RCardQuoteMaintenance (PartNumber,ItemNum ,Ver,ProductFrom,QuoteHour,MatchingHour,Efficiency,TaxQuoHour,Remark,FilePath1,FilePath2,CreateTime,Creater,CreaterName,DevelopReference) " _
                     & " values(N'" & txt_PartNumber.Text & "','" & ItemNum & "','" & txt_Versoon.Text.Trim & "',N'" & txt_ProductFrom.Text.Trim & "','" & txt_QuoteHour.Text.Trim & "','" & txt_MatchingHour.Text & "'," _
                     & "'" & txt_Efficiency.Text.Trim & "',N'" & TaxQuoHour & "',N'" & txt_Remark.Text.Trim & "',N'" & ServerFile1 & "',N'" & ServerFile2 & "',getdate(),'" & SysMessageClass.UseId & "',N'" & UserName & "' ,N'" & txtDevelopReference.Text.Trim() & "') ")

            ElseIf opflag = 2 Then
                'CreateTime=getdate(),Creater='" & SysMessageClass.UseId & "' ,CreaterName=N'" & UserName & "'
                SqlStr.Append("UPDATE m_RCardQuoteMaintenance SET PartNumber=N'" & txt_PartNumber.Text & "',  Ver=N'" & txt_Versoon.Text.Trim & "',ProductFrom =N'" & txt_ProductFrom.Text.Trim & "',QuoteHour='" & txt_QuoteHour.Text.Trim &
                              "',MatchingHour = '" & txt_MatchingHour.Text & "',Efficiency='" & txt_Efficiency.Text.Trim & "',Remark=N'" & txt_Remark.Text.Trim & "',FilePath1=N'" & ServerFile1 & "',FilePath2=N'" + ServerFile2 + "',TaxQuoHour=N'" & TaxQuoHour & "',Creater='" & SysMessageClass.UseId & "',CreaterName=N'" & UserName & "'  where QuoteNo = '" & txtQuoteNo.Text & "' ")
            End If

            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(" AND a.PartNumber= '" & txt_PartNumber.Text & "' ")
            txt_PartNumber.Text = ""
            txt_Versoon.Text = ""
            txt_ProductFrom.Text = ""
            txt_QuoteHour.Text = ""
            txt_TaxQuoHour.Text = ""
            txt_Efficiency.Text = ""
            txt_MatchingHour.Text = ""
            txt_Remark.Text = ""
            txtPath2.Text = ""
            txtPath1.Text = ""
            ServerFile1 = ""
            ServerFile2 = ""
            Me.SopFileName1 = ""
            Me.SopFileName2 = ""
            txtDevelopReference.Text = ""
            ReSet(5)
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "RCard.FrmQuoteMaintenance", "tsbSave_Click", "sys")
            Exit Sub
        End Try
    End Sub
    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txt_PartNumber.Text = ""
        txt_Versoon.Text = ""
        txt_ProductFrom.Text = ""
        txt_QuoteHour.Text = ""
        txt_TaxQuoHour.Text = ""
        txt_Efficiency.Text = ""
        txt_MatchingHour.Text = ""
        txt_Remark.Text = ""
        ReSet(5)
    End Sub
    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim FrmQuoteQuerySet As New FrmQuoteQuery()
        FrmQuoteQuerySet.Owner = Me
        FrmQuoteQuerySet.ShowDialog()
        If FrmQuoteQuerySet.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.sqlWhere = FrmQuoteQuerySet.sqlWhere
        End If
        LoadDataToDatagridview(Me.sqlWhere)
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        ImportData()
    End Sub
    '退出 
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"
    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = "", QuoteNo As String = ""
        SqlStr = " SELECT  TOP 2000  'N' as Selected ,a.QuoteNo,a.PartNumber," & _
                 " ItemNum, Ver, ProductFrom,DevelopReference,  case when StandardQuoteHour=0 then null else StandardQuoteHour end StandardQuoteHour, QuoteHour,  case when MatchingHour=0 then null else MatchingHour end MatchingHour," & _
                 " case when TaxQuoHour is null or TaxQuoHour='' then '0' else TaxQuoHour end TaxQuoHour,count(distinct b.C_PartNumber) ChildCount," & _
                 " Efficiency,a.Remark,FilePath1,FilePath2,a.Creater,a.CreateTime,a.CreaterName " & _
                 " from m_RCardQuoteMaintenance a LEFT JOIN m_RCardQuoteMaintenanceDetail b ON a.PartNumber = b.PartNumber " _
              & "  where a.Usey= '1' " _
              & "  " & SqlWhere & " " & _
              " group by a.QuoteNo,a.PartNumber,ItemNum,Ver,ProductFrom,DevelopReference,QuoteHour,StandardQuoteHour,MatchingHour,TaxQuoHour,Efficiency,a.Remark,FilePath1,FilePath2,a.Creater,a.CreaterName,a.CreateTime " & _
            " order by CreateTime desc "

        SqlStr = SqlStr + " SELECT COUNT(1)  from m_RCardQuoteMaintenance a    where a.Usey= '1' " & SqlWhere

        Dim ds As DataSet = DbOperateUtils.GetDataSet(SqlStr)
        If ds.Tables.Count > 0 AndAlso (Not IsNothing(ds.Tables(0))) Then 'dt.Rows.Count > 0 Then
            dgvRstation.AutoGenerateColumns = False
            dgvRstation.DataSource = ds.Tables(0) 'dt
            toolStripStatusLabel3.Text = CStr(Me.dgvRstation.Rows.Count) + "/总笔数:" + IIf(DbOperateUtils.DBNullToStr(ds.Tables(1).Rows(0).Item(0)) = "0", "0", CStr(ds.Tables(1).Rows(0).Item(0)))
            If dgvRstation.Rows.Count > 0 Then
                QuoteNo = dgvRstation.Rows(0).Cells(enumdgvRStation.QuoteNo.ToString()).Value  '14
            Else
                Exit Sub
            End If
            GridViewBound(QuoteNo)
        Else
            dgvRstation.DataSource = Nothing
            dgvChilds.Rows.Clear()
        End If
    End Sub

    '检查数据
    Private Function Checkdata() As Boolean
        Dim y As Integer = 0
        If Me.txt_PartNumber.Text.Trim = "" Then
            MessageUtils.ShowError("成品料号不能为空!")
            Me.ActiveControl = Me.txt_PartNumber
            Return False
        ElseIf String.IsNullOrEmpty(txt_QuoteHour.Text.Trim()) = False Then
            If Integer.TryParse(txt_QuoteHour.Text, y) = False Then
                MessageUtils.ShowError("报价工时必须是整数类型")
                Return False
            ElseIf Integer.Parse(txt_QuoteHour.Text) < 0 Then
                MessageUtils.ShowError("报价工时必须是大于0")
            End If
        End If
        Return True
    End Function

    '检查方法
    Public Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String, ByRef code As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0} = '{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            code = dr(0).ItemArray(0).ToString
            Return True
        Else
            Return False
        End If
    End Function


    '导入
    Private Sub ImportData()
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            Dim StandardQuoteHour As Integer = 0
            Dim MatchingHour As Integer = 0

            filename = sdfimport.FileName

            '取得用户上传表数据
            Dim dtUploadData As DataTable = NPOIExcle.ExcelInputByNPOI(filename) 'ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 14, errorMsg)

            ChangeTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PartNumber IS NOT NULL  ") '防止追加

            '现在开始把数据保存到DB中,先要转
            'TableAddColumns("Creater", "System.String", dtUploadData)
            '批量插入到DB中
            '设备类型及料号要将string 转int
            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)
            dics2.Add("DevelopReference", "DevelopReference")
            dics2.Add("PartNumber", "PartNumber")
            dics2.Add("ItemNum", "ItemNum")
            dics2.Add("Ver", "Ver")
            dics2.Add("ProductFrom", "ProductFrom")
            dics2.Add("QuoteHour", "QuoteHour")
            'dics2.Add("StandardQuoteHour", "StandardQuoteHour")
            dics2.Add("MatchingHour", "MatchingHour")
            dics2.Add("Efficiency", "Efficiency")
            dics2.Add("TaxQuoHour", "TaxQuoHour")
            dics2.Add("Creater", "Creater")
            dics2.Add("CreaterName", "CreaterName")
            dics2.Add("CreateTime", "CreateTime")
            dics2.Add("Remark", "Remark")
            'dics2.Add("FilePath1", "FilePath1")
            'dics2.Add("FilePath2", "FilePath2")
            




            'Dim usercopy As New DataTable
            'usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值
            'Dim UserID As String = VbCommClass.VbCommClass.UseId

            'For Each col As DataColumn In usercopy.Columns
            '    If col.ColumnName = "StandardQuoteHour" OrElse col.ColumnName = "MatchingHour" Then
            '        col.DataType = System.Type.GetType("System.Int32")
            '    End If

            'Next

            'For Each row As DataRow In DrrR
            '    If row(0).ToString <> "" Then

            '        '成品料号\版次\版本\产品形态\评估工时\子件总工时\配套工时\生产效率\含效率工时\备注\蓝图\BOM图纸\创建人\报价日期
            '        If row(5).ToString() <> "" AndAlso Not IsDBNull(row(5)) Then
            '            StandardQuoteHour = CInt(row(5).ToString())
            '        End If

            '        If row(6).ToString() <> "" AndAlso Not IsDBNull(row(6)) Then
            '            MatchingHour = CInt(row(6).ToString())
            '        End If

            '        usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), _
            '                           row(3).ToString(), row(4).ToString(),
            '                           StandardQuoteHour, MatchingHour, row(7).ToString(), _
            '                            row(8).ToString, row(9).ToString(), row(10).ToString(), _
            '                                 row(11).ToString(), row(12).ToString(), row(13).ToString(), UserID)
            '    End If
            'Next

            Dim errMsg As String = String.Empty

            If DbOperateUtils.BulkCopy(dtUploadData, "m_RCardQuoteMaintenance", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    '更新最新标记
                    UpdateHighState()
                    'LoadAsset()
                    LoadDataToDatagridview("")
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.m_RCardQuoteMaintenance", "toolImport_Click", "sys")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default
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
    Private Sub ChangeTableColumnName(ByVal dt As DataTable)
        'dt.Rows.RemoveAt(0)
        For Each i As ImportGrid In [Enum].GetValues(GetType(ImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(ImportGrid), i).ToString
        Next
    End Sub
#End Region

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect2.Click
        btnSelect2.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            ' Me.SopFileName = OpenFileDialog1.FileName
            txtPath2.Text = OpenFileDialog1.FileName
            ' Me.DrawingFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSelect2.Enabled = True
    End Sub

    Private Sub CreateFolder()
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If
        If Not Directory.Exists(bakFolder) Then
            Directory.CreateDirectory(bakFolder)
        End If
    End Sub

    Public Sub ReSet(ByVal Flag As String)
        Select Case Flag
            Case "1"  'P
                txt_PartNumber.Enabled = True
                txt_Versoon.Enabled = True
                lbl_Attchment.Visible = False
                txtPath2.Visible = False
                btnSelect2.Visible = False
                lbl_MatchingHour.Visible = False
                txt_MatchingHour.Visible = False

                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
            Case "2"  'C
                txt_PartNumber.Enabled = True
                txt_Versoon.Enabled = True
                lbl_Attchment.Visible = True
                txtPath2.Visible = True
                btnSelect2.Visible = True
                lbl_MatchingHour.Visible = True
                txt_MatchingHour.Visible = True
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
            Case "3" '修改
                txt_PartNumber.Enabled = True
                txt_Versoon.Enabled = True
                lbl_Attchment.Visible = True
                txtPath2.Visible = True
                btnSelect2.Visible = True
                lbl_MatchingHour.Visible = True
                txt_MatchingHour.Visible = True
                btnSelect2.Enabled = True
                btnSelect1.Enabled = True
                txt_QuoteHour.Enabled = True
                txt_TaxQuoHour.Enabled = True
                txt_ProductFrom.Enabled = True
                txt_Efficiency.Enabled = True
                txt_Remark.Enabled = True
                txt_MatchingHour.Enabled = True
                txtDevelopReference.Enabled = True
            Case "4"  '新增
                txt_PartNumber.Enabled = True
                txt_Versoon.Enabled = True
                lbl_Attchment.Visible = True
                txtPath2.Visible = True
                btnSelect2.Visible = True
                lbl_MatchingHour.Visible = True
                txt_MatchingHour.Visible = True
                btnSelect2.Enabled = True
                btnSelect1.Enabled = True
                txt_QuoteHour.Enabled = True
                txt_TaxQuoHour.Enabled = True
                txt_ProductFrom.Enabled = True
                txt_Efficiency.Enabled = True
                txt_Remark.Enabled = True
                txt_MatchingHour.Enabled = True
                txtDevelopReference.Enabled = True
            Case "5"  '初始化
                lbl_Attchment.Visible = True
                txtPath2.Visible = True
                btnSelect2.Visible = True
                lbl_MatchingHour.Visible = True
                txt_MatchingHour.Visible = True
                btnSelect2.Enabled = False
                btnSelect1.Enabled = False
                txt_QuoteHour.Enabled = False
                txt_TaxQuoHour.Enabled = False
                txt_ProductFrom.Enabled = False
                txt_Efficiency.Enabled = False
                txt_Remark.Enabled = False
                txt_MatchingHour.Enabled = False
                txt_PartNumber.Enabled = False
                txt_Versoon.Enabled = False
                Me.toolAdd.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolAdd.Tag) = "YES", True, False)
                Me.toolEdit.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolEdit.Tag) = "YES", True, False)
                Me.toolAbandon.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolAbandon.Tag) = "YES", True, False)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                txtDevelopReference.Enabled = False
        End Select
    End Sub

    Public Function CheckQuoteTime(ByVal PartNumber As String, ByVal C_PartNumber As String, ByVal Ver As String, ByVal QuoteHour As String, ByVal MatchingHour As String) As Boolean
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" exec Exec_CheckQuoteTime '" & PartNumber & "','" & C_PartNumber & "','" & Ver & "','" & QuoteHour & "','" & MatchingHour & "' ")
        If dt.Rows(0)(0).ToString = "Y" Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 弹出窗体
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolMantains_Click(sender As Object, e As EventArgs) Handles ToolMantains.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'Dim Categroy As String = dgvRstation.Item(11, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim  
        '谁创建，谁修改

        Dim Creater = dgvRstation.Item(enumdgvRStation.Creater.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '15
        Dim CreaterName = dgvRstation.Item(enumdgvRStation.CreaterName.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '15
        If Creater = SysMessageClass.UseId Then

            Dim QuoteNo As String = dgvRstation.Item(enumdgvRStation.QuoteNo.ToString(), Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '14
            Dim PartNumber As String = ""
            Dim Versoon As String = ""
            Dim QuoteHour As String = ""
            Dim MatchingHour As String = ""
            Dim SumHour As String = ""
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select PartNumber,Ver,QuoteHour,MatchingHour,StandardQuoteHour from [dbo].[m_RCardQuoteMaintenance] where QuoteNo='" & QuoteNo & "'")
            If dt.Rows.Count > 0 Then
                PartNumber = dt.Rows(0)(0).ToString
                Versoon = dt.Rows(0)(1).ToString
                QuoteHour = dt.Rows(0)(2).ToString
                MatchingHour = dt.Rows(0)(3).ToString
                SumHour = dt.Rows(0)(4).ToString
            End If
            Dim FrmChildPNQuoteSet As New FrmChildPNQuote(QuoteNo, PartNumber, Versoon, QuoteHour, MatchingHour, SumHour)
            FrmChildPNQuoteSet.Owner = Me
            FrmChildPNQuoteSet.ShowDialog()
            LoadDataToDatagridview("")
            ReSet(5)
        Else
            MessageUtils.ShowError("此份报价由：" & CreaterName & " 创建,只有本人才能修改！") '
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelect1.Click
        btnSelect1.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            ' Me.SopFileName = OpenFileDialog1.FileName
            txtPath1.Text = OpenFileDialog1.FileName
            ' Me.DrawingFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnSelect1.Enabled = True
    End Sub

    ''' <summary>
    ''' 回车事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_PartNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_PartNumber.KeyPress

        If opflag = 2 Then
            Exit Sub
        End If

        If txt_PartNumber.Text.Trim = "" Then
            Exit Sub
        End If

        If e.KeyChar = Chr(13) Then
            CheckPartNumber(txt_PartNumber.Text.Trim.Replace("'", "''"))
        End If
    End Sub

    ''' <summary>
    ''' 检查成品料号，并将结果显示与下拉列表中
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPartNumber(ByVal PartNumber As String)
        Dim lsSQL As String = ""

        lsSQL = " SELECT 'N' as Selected,QuoteNo,PartNumber,ItemNum,Ver,QuoteHour," & _
                " MatchingHour,StandardQuoteHour,ProductFrom,Efficiency,TaxQuoHour,Remark,FilePath1,FilePath2,Creater,CreateTime,CreaterName " & _
                " FROM [dbo].[m_RCardQuoteMaintenance] where PartNumber='" & PartNumber & "' and usey=1"
        'String.Replace("'", "''")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
        If dt.Rows.Count > 0 Then
            dgvRstation.AutoGenerateColumns = False
            dgvRstation.DataSource = dt
            toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
            Dim QuoteNo As String = dgvRstation.Rows(0).Cells(enumdgvRStation.QuoteNo.ToString()).Value '14
            GridViewBound(QuoteNo)
            txt_PartNumberCount.Text = dt.Rows.Count + 1
            Dim result As System.Windows.Forms.DialogResult = System.Windows.Forms.MessageBox.Show("该料已存在，是否要创建？", "料号确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = System.Windows.Forms.DialogResult.Cancel Then
                txt_PartNumber.Text = ""
                Exit Sub
            End If
        Else
            txt_PartNumberCount.Text = "1"
        End If
    End Sub

    ''' <summary>
    ''' 取用户姓名
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetUserName(ByVal Userid As String) As String
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select UserName from m_Users_t where Userid='" & Userid & "'")
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString()
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 返回版次号
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ReturnItemNum(ByVal PartNumber As String) As String
        Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT isnull(max(itemNum),0)+1 as itemNum from [dbo].[m_RCardQuoteMaintenance] where usey='1' and PartNumber='" & PartNumber & "' ")
        Return dt.Rows(0)(0).ToString()
    End Function

    ''' <summary>
    '''  点击显示子件列表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRstation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRstation.CellClick
        Dim index = e.RowIndex
        If index <> -1 Then
            Dim QuoteNo As String = dgvRstation.Rows(index).Cells(enumdgvRStation.QuoteNo.ToString()).Value '14
            GridViewBound(QuoteNo)
        End If
    End Sub


    ''' <summary>
    ''' 更新最新版本标记(导入时)
    ''' add by hgd 2017-04-19 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateHighState()
        Try
            Dim SqlStr As New StringBuilder
            '将料号有多个版本的标识初始化
            SqlStr.Append(" UPDATE m_RCardQuoteMaintenance SET IsHigh=0  WHERE PartNumber IN( select PartNumber from m_RCardQuoteMaintenance ")
            SqlStr.Append(" where PartNumber is not null  group by PartNumber having count(1)>1 ) ;")
            '更新料号有多个版本的最新标记
            SqlStr.Append(" UPDATE m_RCardQuoteMaintenance SET IsHigh=1 WHERE QuoteNo  IN( select MAX(QuoteNo) from m_RCardQuoteMaintenance ")
            SqlStr.Append(" where PartNumber is not null group by PartNumber having count(1)>1 );")

            DbOperateUtils.ExecSQL(SqlStr.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.m_RCardQuoteMaintenance", "UpdateHighState()", "sys")
        End Try

    End Sub


    Public Sub GridViewBound(ByVal QuoteNo As String)
        Dim SqlStr As String = ""
        SqlStr = " select QuoteNo,PartNumber,C_PartNumber,UQuoteHour,Ncount,UQuoteHour*Ncount as SumHours,Remark from m_RCardQuoteMaintenanceDetail where QuoteNo='" & QuoteNo & "'  order by C_PartNumber  "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        dgvChilds.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            dgvChilds.Rows.Add(dt.Rows(i)("C_PartNumber"), dt.Rows(i)("Ncount"), dt.Rows(i)("UQuoteHour"), dt.Rows(i)("SumHours"), dt.Rows(i)("Remark"))
        Next
    End Sub

    Private Sub dgvRstation_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRstation.CellDoubleClick
        Dim colindex As Integer = e.ColumnIndex
        Dim rowindex As Integer = e.RowIndex
        If rowindex <> -1 Then
            If dgvRstation.Columns(colindex).Name = "FilePath1" Then '10
                Dim filepath As String = dgvRstation.Rows(rowindex).Cells(enumdgvRStation.FilePath1.ToString()).Value
                System.Diagnostics.Process.Start("Explorer.exe", filepath)
            End If
            If dgvRstation.Columns(colindex).Name = "FilePath2" Then '11
                Dim filepath As String = dgvRstation.Rows(rowindex).Cells(enumdgvRStation.FilePath2.ToString()).Value
                System.Diagnostics.Process.Start("Explorer.exe", filepath)
            End If
        End If
    End Sub

    Private Sub txt_PartNumber_TextChanged(sender As Object, e As EventArgs) Handles txt_PartNumber.TextChanged
        If opflag = 2 Then
            Exit Sub
        End If

        If txt_PartNumber.Text.Trim = "" Then
            txt_PartNumberCount.Text = "1"
            Exit Sub
        Else
            CheckPartNumber(txt_PartNumber.Text.Trim.Replace("'", "''"))
        End If
    End Sub

    Private Sub ToolRefrech_Click(sender As Object, e As EventArgs) Handles ToolRefrech.Click
        ReSet(5)
        LoadDataToDatagridview("")
    End Sub

    ''' <summary>
    ''' 双击清除附件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtPath1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtPath1.MouseDoubleClick
        txtPath1.Text = ""
    End Sub

    Private Sub txtPath2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtPath2.MouseDoubleClick
        txtPath2.Text = ""
    End Sub

    Public Function GetFileName(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileName(FullPath)
        'System.IO.Path.GetExtension("c:\windows\test.txt") '获取扩展名   
        'System.IO.Path.GetFileName("c:\windows\test.txt") '获取文件名  
    End Function

    'Private Sub toolExport_Click(sender As Object, e As EventArgs)
    '    Dim SqlStr As String

    '    '     SqlStr = " select top 100  'N' as Selected ,QuoteNo,PartNumber,ItemNum,Ver,ProductFrom,StandardQuoteHour,QuoteHour,MatchingHour,Efficiency,Remark,FilePath1,FilePath2,Creater,CreateTime,CreaterName from m_RCardQuoteMaintenance  " _
    '    '     & "  where Usey=1 " _
    '    '     & "  " & SqlWhere & " order by CreateTime desc "
    '    SqlStr = " SELECT PartNumber 成品料号,ItemNum 版次,Ver 版本, ProductFrom 产品形态,StandardQuoteHour 报价工时, , QuoteHour 配套工时, " & _
    '             " Efficiency 效率, Remark 备注，FilePath1 蓝图, FilePath2 BOM图纸， CreaterName  创建人，CreateTime 日期 " & _
    '             " FROM m_RCardQuoteMaintenance a  where 1=1 & " & sqlWhere & ""
    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
    '    ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    'End Sub

    Private Sub toolMain_Click(sender As Object, e As EventArgs) Handles toolMain.Click
        Try
            Dim SqlStr As String = String.Empty
            'Add usey ='1' , not output the usey='0' record, cq20170302
            'SqlStr = " SELECT a.PartNumber 成品料号,ItemNum 版次,Ver 版本, ProductFrom 产品形态," & _
            '         "DevelopReference 开发案号, QuoteHour 报价工时, MatchingHour 配套工时,StandardQuoteHour 子件总工时," & _
            '         " COUNT(distinct b.C_PartNumber) 子件个数," & _
            '         " Efficiency 效率, a.Remark 备注,FilePath1 蓝图, FilePath2 as BOM图纸, a.CreaterName 创建人,a.CreateTime 日期 " & _
            '         " FROM m_RCardQuoteMaintenance a   LEFT JOIN m_RCardQuoteMaintenanceDetail b ON a.PartNumber = b.PartNumber  " & _
            '         " WHERE 1=1 and a.usey='1' and IsHigh=1 " & sqlWhere & "" & _
            '         " GROUP BY a.PartNumber,ItemNum,Ver,ProductFrom,DevelopReference,QuoteHour,StandardQuoteHour,MatchingHour,Efficiency,a.Remark,FilePath1,FilePath2,a.CreaterName,a.CreateTime " & _
            '         " ORDER BY a.CreateTime DESC "

            'update by 马跃平 2018-07-19
            SqlStr = "select DevelopReference '开发案号', PartNumber '料号'," & vbCrLf &
            "ItemNum '项次',Ver '版本',ProductFrom '产品形态',QuoteHour '估价工时'" & vbCrLf &
            ",StandardQuoteHour '子件总工时',MatchingHour '配套工时'," & vbCrLf &
            "Efficiency '效率',TaxQuoHour '报价工时(含效率)'," & vbCrLf &
            "(select count(*) from  m_RCardQuoteMaintenanceDetail " & vbCrLf &
            "where m_RCardQuoteMaintenanceDetail.QuoteNo=m_RCardQuoteMaintenance.QuoteNo)" & vbCrLf &
            "'子件个数',Remark '备注',FilePath1 '蓝图',FilePath2 'BOM'" & vbCrLf &
            ",Creater '创建人工号',CreaterName '创建人姓名',CreateTime '创建时间'" & vbCrLf &
            "from m_RCardQuoteMaintenance where usey='1' " & Replace(sqlWhere, "a.", "") & " order by CreateTime desc"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
            NPOIExcle.DataTableExportToExcle(dt, Nothing, "报价工时.xls")
            MessageUtils.ShowInformation("导出成功!")
            'ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQuoteMaintenance", "toolMain_Click", "RCard")
        End Try
    End Sub


    Private Sub txt_QuoteHour_TextChanged(sender As Object, e As EventArgs) Handles txt_QuoteHour.TextChanged
        GetTaxQuoHour()
    End Sub

#Region "自动计算效率工时"
    ''' <summary>
    ''' 自动计算效率工时
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetTaxQuoHour()
        Dim y = 0
        If String.IsNullOrEmpty(txt_QuoteHour.Text.Trim()) = False Then
            If Integer.TryParse(txt_QuoteHour.Text.Trim(), y) Then
                Dim sql = "select  cast(" & txt_QuoteHour.Text & "/cast (cast(replace('" & txt_Efficiency.Text & "','%','') as float)/100 as decimal(18,2)) as decimal(18,0))"
                Dim TaxQuoHour = DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString() '效率工时 add by 马跃平 2018-07-18
                txt_TaxQuoHour.Text = TaxQuoHour
            Else
                txt_TaxQuoHour.Text = Nothing
            End If
        Else
            txt_TaxQuoHour.Text = Nothing
        End If
    End Sub
#End Region


    Private Sub txt_Efficiency_SelectedValueChanged(sender As Object, e As EventArgs) Handles txt_Efficiency.SelectedValueChanged
        GetTaxQuoHour()
    End Sub

    ''' <summary>
    ''' 下载导入模板
    ''' add by 马跃平 2018-07-21
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsBtnExportDemo_Click(sender As Object, e As EventArgs) Handles tsBtnExportDemo.Click
        Try
            Dim ssf = New SaveFileDialog()
            ssf.FileName = "报价工时标准模板.xls"
            ssf.Filter = "Excel|*.xls"
            If ssf.ShowDialog() = DialogResult.OK Then
                Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                    Dim data = System.IO.File.ReadAllBytes("\\192.168.20.123\SFCShare\File\报价工时导入模板\报价工时标准模板.xls")
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
End Class