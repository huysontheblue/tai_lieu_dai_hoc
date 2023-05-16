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

Public Class FrmSampleSum

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
        Remark
        FilePath1
        FilePath2
        CreaterName
        CreateTime
        QuoteNo
        Creater
    End Enum

    Private Enum enumdgvSampleSum
        PartNO
        RDUserName
        MakeDate
        Qty
        NGQty
        NGRate
        ProblemDes
        DesignProblem
        MaterialProblem
        TechnologyProblem
        ModelProblem
        TempDisposal
        DutyNameList
        PlanDueDate
        LongTermAction
        RealDueDate
        FilePath
        UserID
        Intime
    End Enum

#End Region

    Private Sub FrmSampleSum_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub FrmSampleSum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReSet(5)
        LoadDataToDatagridview("")
    End Sub

    '不同状态处理
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 ' 初期化
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
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
        ToolbtnState(1)
    End Sub

    '编辑处理
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvSampleSum.Rows.Count = 0 OrElse Me.dgvSampleSum.CurrentRow Is Nothing Then Exit Sub
        'Dim Categroy As String = dgvRstation.Item(11, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim  
        '谁创建，谁修改

        Dim Creater = dgvSampleSum.Item(15 + 1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
        If Creater.Trim.ToUpper = SysMessageClass.UseId.Trim.ToUpper Then
            opflag = 2
            ReSet(3)
            txt_PartNumber.Text = dgvSampleSum.Item(1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_PartNumberCount.Text = dgvSampleSum.Item(2, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_Versoon.Text = dgvSampleSum.Item(3, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_ProductFrom.Text = dgvSampleSum.Item(4, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_QuoteHour.Text = dgvSampleSum.Item(5, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_MatchingHour.Text = dgvSampleSum.Item(enumdgvRStation.MatchingHour, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim '7
            txt_Efficiency.Text = dgvSampleSum.Item(8 + 1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txt_Remark.Text = dgvSampleSum.Item(9 + 1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txtPath1.Text = dgvSampleSum.Item(10 + 1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txtPath2.Text = dgvSampleSum.Item(11 + 1, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim
            txtQuoteNo.Text = dgvSampleSum.Item(enumdgvRStation.QuoteNo, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim '14
            ToolbtnState(2)
        Else
            MessageUtils.ShowError("此份报价由：" & Creater & " 创建,只有本人才能修改！")
        End If
    End Sub

    '作废处理
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvSampleSum.Rows.Count = 0 Then
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
            For i As Integer = dgvSampleSum.Rows.Count - 1 To 0 Step -1
                Dim aaa = dgvSampleSum.Rows(i).Cells(0).Value
                If dgvSampleSum.Rows(i).Cells(0).EditedFormattedValue.ToString() = "True" Then
                    Selected = True
                    Dim QuoteNo As String = dgvSampleSum.Rows(i).Cells(enumdgvRStation.QuoteNo).Value.ToString '14
                    'CreateTime=getdate()Creater='" & SysMessageClass.UseId & "'
                    Sql.Append("update m_RCardQuoteMaintenance set usey='0' where QuoteNo = '" & QuoteNo & "'  ")

                    ''判断是否为此人创建，若有不是此人创建的给出提配，并退出
                    Dim Creater = dgvSampleSum.Item(enumdgvRStation.Creater, i).Value.ToString.Trim  '15
                    If Creater <> SysMessageClass.UseId Then
                        Dim PartNumber As String = dgvSampleSum.Item(1, i).Value.ToString.Trim
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

            If opflag = 1 Then

                '查询版次号
                Dim ItemNum As Integer = Val(ReturnItemNum(txt_PartNumber.Text))
                SqlStr.Append(ControlChars.CrLf & "insert into m_RCardQuoteMaintenance (PartNumber,ItemNum ,Ver,ProductFrom,QuoteHour,MatchingHour,Efficiency,Remark,FilePath1,FilePath2,CreateTime,Creater,CreaterName) " _
                     & " values('" & txt_PartNumber.Text & "','" & ItemNum & "','" & txt_Versoon.Text.Trim & "',N'" & txt_ProductFrom.Text.Trim & "','" & txt_QuoteHour.Text.Trim & "','" & txt_MatchingHour.Text & "'," _
                     & "'" & txt_Efficiency.Text.Trim & "',N'" & txt_Remark.Text.Trim & "',N'" & ServerFile1 & "',N'" & ServerFile2 & "',getdate(),'" & SysMessageClass.UseId & "',N'" & UserName & "' ) ")

            ElseIf opflag = 2 Then
                'CreateTime=getdate(),Creater='" & SysMessageClass.UseId & "' ,CreaterName=N'" & UserName & "'
                SqlStr.Append("UPDATE m_RCardQuoteMaintenance SET PartNumber=N'" & txt_PartNumber.Text & "',  Ver=N'" & txt_Versoon.Text.Trim & "',ProductFrom =N'" & txt_ProductFrom.Text.Trim & "',QuoteHour='" & txt_QuoteHour.Text.Trim &
                              "',MatchingHour = '" & txt_MatchingHour.Text & "',Efficiency='" & txt_Efficiency.Text.Trim & "',Remark=N'" & txt_Remark.Text.Trim & "',FilePath1=N'" & ServerFile1 & "',FilePath2=N'" + ServerFile2 + "'  where QuoteNo = '" & txtQuoteNo.Text & "' ")
            End If

            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(" AND a.PartNumber= '" & txt_PartNumber.Text & "' ")
            txt_PartNumber.Text = ""
            txt_Versoon.Text = ""
            txt_ProductFrom.Text = ""
            txt_QuoteHour.Text = ""
            txt_Efficiency.Text = ""
            txt_MatchingHour.Text = ""
            txt_Remark.Text = ""
            txtPath2.Text = ""
            txtPath1.Text = ""
            ServerFile1 = ""
            ServerFile2 = ""
            Me.SopFileName1 = ""
            Me.SopFileName2 = ""
            ReSet(5)
            MessageUtils.ShowInformation("保存成功！")

        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub

    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txt_PartNumber.Text = ""
        txt_Versoon.Text = ""
        txt_ProductFrom.Text = ""
        txt_QuoteHour.Text = ""
        txt_Efficiency.Text = ""
        txt_MatchingHour.Text = ""
        txt_Remark.Text = ""
        ReSet(5)
    End Sub

    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        'Dim FrmQuoteQuerySet As New FrmQuoteQuery()
        'FrmQuoteQuerySet.Owner = Me
        'FrmQuoteQuerySet.ShowDialog()
        'If FrmQuoteQuerySet.DialogResult = Windows.Forms.DialogResult.OK Then
        '    Me.sqlWhere = FrmQuoteQuerySet.sqlWhere
        'End If
        'LoadDataToDatagridview(Me.sqlWhere)
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
        SqlStr = " SELECT  TOP 2000  'N' as Selected ,a.PartNumber," & _
                 " ItemNum, Ver, ProductFrom, StandardQuoteHour, QuoteHour, MatchingHour, count(b.C_PartNumber) ChildCount," & _
                 " Efficiency,a.Remark,FilePath1,FilePath2,a.Creater,a.CreateTime,a.CreaterName " & _
                 " from m_SampleSum_t a LEFT JOIN m_RCardQuoteMaintenanceDetail b ON a.PartNumber = b.PartNumber " _
              & "  where a.Usey= '1' " _
              & "  " & SqlWhere & " " & _
              " group by a.QuoteNo,a.PartNumber,ItemNum,Ver,ProductFrom,QuoteHour,StandardQuoteHour,MatchingHour,Efficiency,a.Remark,FilePath1,FilePath2,a.Creater,a.CreaterName,a.CreateTime " & _
            " order by CreateTime desc "

        SqlStr = SqlStr + " SELECT COUNT(1)  from m_RCardQuoteMaintenance a    where a.Usey= '1' " & SqlWhere

        Dim ds As DataSet = DbOperateUtils.GetDataSet(SqlStr)
        If ds.Tables.Count > 0 AndAlso (Not IsNothing(ds.Tables(0))) Then 'dt.Rows.Count > 0 Then
            dgvSampleSum.AutoGenerateColumns = False
            dgvSampleSum.DataSource = ds.Tables(0) 'dt
            toolStripStatusLabel3.Text = CStr(Me.dgvSampleSum.Rows.Count) + "/总笔数:" + IIf(DbOperateUtils.DBNullToStr(ds.Tables(1).Rows(0).Item(0)) = "0", "0", CStr(ds.Tables(1).Rows(0).Item(0)))
            If dgvSampleSum.Rows.Count > 0 Then
                QuoteNo = dgvSampleSum.Rows(0).Cells(enumdgvRStation.QuoteNo).Value  '14
            Else
                Exit Sub
            End If
            GridViewBound(QuoteNo)
        Else
            dgvSampleSum.DataSource = Nothing
            'dgvChilds.Rows.Clear()
        End If
    End Sub

    '检查数据
    Private Function Checkdata() As Boolean
        If Me.txt_PartNumber.Text.Trim = "" Then
            MessageUtils.ShowError("成品料号不能为空!")
            Me.ActiveControl = Me.txt_PartNumber
            Return False
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


    Private Enum enumFlag
        P = 1
        C = 2
        Modify = 3
        NewAdd = 4
        initial = 5
    End Enum
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
            Case CStr(enumFlag.C)  'C
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
            Case CStr(enumFlag.Modify) '修改
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
                txt_ProductFrom.Enabled = True
                txt_Efficiency.Enabled = True
                txt_Remark.Enabled = True
                txt_MatchingHour.Enabled = True
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
                txt_ProductFrom.Enabled = True
                txt_Efficiency.Enabled = True
                txt_Remark.Enabled = True
                txt_MatchingHour.Enabled = True
            Case CStr(enumFlag.initial)  '初始化
                lbl_Attchment.Visible = True
                txtPath2.Visible = True
                btnSelect2.Visible = True
                lbl_MatchingHour.Visible = True
                txt_MatchingHour.Visible = True
                btnSelect2.Enabled = False
                btnSelect1.Enabled = False
                txt_QuoteHour.Enabled = False
                txt_ProductFrom.Enabled = False
                txt_Efficiency.Enabled = False
                txt_Remark.Enabled = False
                txt_MatchingHour.Enabled = False
                txt_PartNumber.Enabled = False
                txt_Versoon.Enabled = False
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
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
        If Me.dgvSampleSum.Rows.Count = 0 OrElse Me.dgvSampleSum.CurrentRow Is Nothing Then Exit Sub
        '谁创建，谁修改
        Dim Creater = dgvSampleSum.Item(enumdgvRStation.Creater, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim '15
        Dim CreaterName = dgvSampleSum.Item(enumdgvRStation.CreaterName, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim '15
        Dim lsSQL As String = String.Empty
        If Creater = SysMessageClass.UseId Then

            Dim QuoteNo As String = dgvSampleSum.Item(enumdgvRStation.QuoteNo, Me.dgvSampleSum.CurrentRow.Index).Value.ToString.Trim '14
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
            '   Dim FrmChildPNQuoteSet As New FrmChildPNQuote(QuoteNo, PartNumber, Versoon, QuoteHour, MatchingHour, SumHour)
            ' FrmChildPNQuoteSet.Owner = Me
            ' FrmChildPNQuoteSet.ShowDialog()
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
                " MatchingHour,StandardQuoteHour,ProductFrom,Efficiency,Remark,FilePath1,FilePath2,Creater,CreateTime,CreaterName " & _
                " FROM [dbo].[m_Sample_t] where PartNumber='" & PartNumber & "' and usey=1"
        'String.Replace("'", "''")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
        If dt.Rows.Count > 0 Then
            dgvSampleSum.AutoGenerateColumns = False
            dgvSampleSum.DataSource = dt
            toolStripStatusLabel3.Text = Me.dgvSampleSum.Rows.Count
            Dim QuoteNo As String = dgvSampleSum.Rows(0).Cells(enumdgvRStation.QuoteNo).Value '14
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

        Dim dt As DataTable = DbOperateUtils.GetDataTable("select isnull(max(itemNum),0)+1 as itemNum from [dbo].[m_RCardQuoteMaintenance] where usey='1' and PartNumber='" & PartNumber & "' ")
        Return dt.Rows(0)(0).ToString()
    End Function

    ''' <summary>
    '''  点击显示子件列表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRstation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSampleSum.CellClick
        Dim index = e.RowIndex
        If index <> -1 Then
            Dim QuoteNo As String = dgvSampleSum.Rows(index).Cells(enumdgvRStation.QuoteNo).Value '14
            GridViewBound(QuoteNo)
        End If

    End Sub

    Public Sub GridViewBound(ByVal QuoteNo As String)

        Dim SqlStr As String = ""
        SqlStr = " select QuoteNo,PartNumber,C_PartNumber,UQuoteHour,Ncount,UQuoteHour*Ncount as SumHours,Remark " & _
                 " from m_SampleSum_t where QuoteNo='" & QuoteNo & "'  order by C_PartNumber  "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        ' dgvChilds.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            ' dgvChilds.Rows.Add(dt.Rows(i)("C_PartNumber"), dt.Rows(i)("Ncount"), dt.Rows(i)("UQuoteHour"), dt.Rows(i)("SumHours"), dt.Rows(i)("Remark"))
        Next
    End Sub

    ''
    Private Sub dgvRstation_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSampleSum.CellDoubleClick

        Dim colindex As Integer = e.ColumnIndex
        Dim rowindex As Integer = e.RowIndex
        If rowindex <> -1 Then
            If colindex = enumdgvRStation.FilePath1 Then '10
                Dim filepath As String = dgvSampleSum.Rows(rowindex).Cells(enumdgvRStation.FilePath1).Value
                System.Diagnostics.Process.Start("Explorer.exe", filepath)
            End If
            If colindex = enumdgvRStation.FilePath2 Then '11
                Dim filepath As String = dgvSampleSum.Rows(rowindex).Cells(enumdgvRStation.FilePath2).Value
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
    End Function


    Private Sub toolMain_Click(sender As Object, e As EventArgs) Handles toolMain.Click
        Dim SqlStr As String = String.Empty

        SqlStr = " SELECT a.PartNumber 成品料号,ItemNum 版次,Ver 版本, ProductFrom," & _
                 " QuoteHour 报价工时, MatchingHour 配套工时,StandardQuoteHour 子件总工时," & _
                 " COUNT(b.C_PartNumber) 子件个数," & _
                 " Efficiency 效率, a.Remark 备注,FilePath1 蓝图, FilePath2 as BOM图纸, a.CreaterName 创建人,a.CreateTime 日期 " & _
                 " FROM m_SampleSum_t a   LEFT JOIN m_RCardQuoteMaintenanceDetail b ON a.PartNumber = b.PartNumber  WHERE 1=1 " & sqlWhere & "" & _
                 " GROUP BY a.PartNumber,ItemNum,Ver,ProductFrom,QuoteHour,StandardQuoteHour,MatchingHour,Efficiency,a.Remark,FilePath1,FilePath2,a.CreaterName,a.CreateTime " & _
                 " ORDER BY a.CreateTime desc "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub
End Class